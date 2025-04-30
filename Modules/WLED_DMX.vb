Imports System.Net.Sockets
Imports System.Net
Imports System.Threading
Imports System.Collections.Concurrent
Imports System.Diagnostics
Imports System.Windows.Forms ' Toegevoegd voor DataGridView
Imports System.Text ' Toegevoegd voor Encoding

Module WLED_DMX

    ' Een dictionary om sockets op te slaan, zodat ze kunnen worden hergebruikt.
    Private _sockets As New ConcurrentDictionary(Of String, Socket)
    Private _threads As New ConcurrentDictionary(Of String, Thread)
    Private _cancellationTokenSources As New ConcurrentDictionary(Of String, CancellationTokenSource)
    Private _originatorCID As Guid = Guid.NewGuid() ' Genereer 1x, hergebruik.
    Private _sourceName As String = "WLED_DMX_Controller" ' Bronnaam voor sACN

    ' Constanten voor sACN
    Private Const SACN_PORT As Integer = 5568
    Private Const SACN_UNIVERSE_MIN As Integer = 1
    Private Const SACN_UNIVERSE_MAX As Integer = 63999
    Private Const SACN_PACKET_SIZE As Integer = 512 + 126 ' Maximaal 512 databytes + 126 bytes header
    Private Const PREAMBLE_SIZE As Short = 0
    Private Const VERSION As Short = 1

    ' Structuur voor sACN header
    Structure sACN_Header
        Dim Preamble() As Byte        ' 8 bytes
        Dim Postamble() As Byte       ' 2 bytes
        Dim AcnPacketIdentifier() As Byte ' 12 bytes
        Dim FlagsLength() As Byte    ' 2 bytes
        Dim Vector As Integer         ' 4 bytes (32 bits)
        Dim Priority As Byte          ' 1 byte
        Dim SequenceNumber As Byte    ' 1 byte
        Dim OriginatorCID() As Byte   ' 16 bytes
        Dim Universe As Short         ' 2 bytes
        Dim Length As Short          ' 2 bytes, inclusief header
        Dim SourceName() As Byte      ' 64 bytes
    End Structure

    ' Een dictionary om de IP-adressen op te slaan voor elk universe.
    Private _universeIpMap As New ConcurrentDictionary(Of Integer, String)

    ''' <summary>
    ''' Start de DMX-output over sACN.
    ''' </summary>
    ''' <param name="deviceRow">De DataGridViewRow met de apparaat informatie.</param>
    ''' <param name="dmxDataLength">De lengte van de DMX-data (maximaal 512).</param>
    ''' <returns>True als het starten is gelukt, false als er een fout is opgetreden.</returns>
    ''' <remarks>
    ''' Deze functie zet de socket op, start een thread om data te verzenden,
    ''' en slaat de socket en thread op in dictionaries voor hergebruik en beheer.
    ''' </remarks>
    Public Function StartDMXOutput(ByVal deviceRow As DataGridViewRow, ByVal dmxDataLength As Integer) As Boolean
        Dim ipAddress As String = ""
        Dim universe As Integer = 0
        Dim protocol As String = ""
        Dim priority As Byte = 100

        Try
            ' Haal de gegevens uit de DataGridViewRow.  Zorg ervoor dat de kolomnamen correct zijn.
            ipAddress = deviceRow.Cells("colIPAddress").Value.ToString() ' Gebruik de correcte kolomnaam
            universe = Integer.Parse(deviceRow.Cells("colStartUniverse").Value.ToString()) ' Gebruik de correcte kolomnaam
            protocol = deviceRow.Cells("colProtocol").Value.ToString() ' Gebruik de correcte kolomnaam
            If deviceRow.Cells("colPriority") IsNot Nothing AndAlso deviceRow.Cells("colPriority").Value IsNot DBNull.Value Then  ' Gebruik de correcte kolomnaam
                priority = Convert.ToByte(deviceRow.Cells("colPriority").Value) ' Gebruik de correcte kolomnaam
            End If
        Catch ex As Exception
            Debug.WriteLine($"Fout bij het ophalen van gegevens uit DataGridViewRow: {ex.Message}")
            Return False
        End Try

        If String.IsNullOrEmpty(ipAddress) Then
            Debug.WriteLine("IP-adres is niet geldig.")
            Return False
        End If

        If universe < SACN_UNIVERSE_MIN OrElse universe > SACN_UNIVERSE_MAX Then
            Debug.WriteLine($"Universe nummer moet tussen {SACN_UNIVERSE_MIN} en {SACN_UNIVERSE_MAX} zijn.")
            Return False
        End If

        If protocol.ToLower() <> "sacn" Then
            Debug.WriteLine("Protocol moet 'sACN' zijn.")
            Return False
        End If

        If dmxDataLength < 1 OrElse dmxDataLength > 512 Then
            Debug.WriteLine("DMX data lengte moet tussen 1 en 512 zijn.")
            Return False
        End If

        Dim endpoint As New IPEndPoint(ipAddress, SACN_PORT)
        Dim socketKey As String = $"{ipAddress}:{universe}"

        ' Controleer of er al een socket voor dit IP-adres en universe bestaat.
        If _sockets.ContainsKey(socketKey) Then
            Dim existingSocket = _sockets(socketKey)
            If existingSocket IsNot Nothing AndAlso existingSocket.Connected Then
                Debug.WriteLine($"sACN output al gestart voor {ipAddress} universe {universe}.")
                Return True ' Er is al een werkende verbinding.
            Else
                ' Socket bestaat, maar is niet verbonden, dus we verwijderen deze en maken een nieuwe.
                _sockets.TryRemove(socketKey, Nothing)
            End If
        End If

        Try
            ' Maak een nieuwe socket aan.
            Dim senderSocket As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            senderSocket.Connect(endpoint) ' Verbind de socket (voor UDP is dit virtueel)
            _sockets.TryAdd(socketKey, senderSocket) ' Voeg de socket toe aan de dictionary.

            ' Maak een CancellationTokenSource voor deze thread, zodat we deze kunnen stoppen.
            Dim cts As New CancellationTokenSource()
            _cancellationTokenSources.TryAdd(socketKey, cts)
            Dim token As CancellationToken = cts.Token

            ' Start een nieuwe thread om sACN-data te verzenden.
            Dim sendThread As New Thread(Sub()
                                             SendDataOverSacn(senderSocket, ipAddress, universe, dmxDataLength, token, priority)
                                         End Sub)
            sendThread.IsBackground = True
            sendThread.Start()
            _threads.TryAdd(socketKey, sendThread) ' Voeg de thread toe aan de dictionary.

            ' Sla het IP-adres op voor dit universe.
            _universeIpMap.AddOrUpdate(universe, ipAddress, Function(key, oldValue) ipAddress)

            Debug.WriteLine($"sACN output gestart naar {ipAddress} universe {universe}.")
            Return True
        Catch ex As Exception
            Debug.WriteLine($"Fout bij het starten van sACN: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Stopt de DMX-output voor een gegeven IP-adres en universe.
    ''' </summary>
    ''' <param name="ipAddress">Het IP-adres van het WLED-apparaat.</param>
    ''' <param name="universe">Het sACN universe nummer.</param>
    Public Sub StopDMXOutput(ByVal ipAddress As String, ByVal universe As Integer)
        Dim socketKey As String = $"{ipAddress}:{universe}"

        ' Controleer of de socket bestaat en sluit deze.
        If _sockets.ContainsKey(socketKey) Then
            Dim socketToClose As Socket
            If _sockets.TryRemove(socketKey, socketToClose) Then
                Try
                    socketToClose.Shutdown(SocketShutdown.Both)
                    socketToClose.Close()
                    Debug.WriteLine($"Socket gesloten voor {ipAddress} universe {universe}.")
                Catch ex As Exception
                    Debug.WriteLine($"Fout bij het sluiten van de socket: {ex.Message}")
                End Try
            End If
        End If

        ' Stop de thread.
        If _threads.ContainsKey(socketKey) Then
            Dim threadToStop As Thread
            If _threads.TryRemove(socketKey, threadToStop) Then
                ' Annuleer de CancellationToken om de thread te stoppen.
                If _cancellationTokenSources.ContainsKey(socketKey) Then
                    Dim cts As CancellationTokenSource
                    If _cancellationTokenSources.TryRemove(socketKey, cts) Then
                        cts.Cancel()
                        Debug.WriteLine($"Thread gestopt voor {ipAddress} universe {universe}.")
                    End If
                End If
                ' Wacht eventueel op het beëindigen van de thread (met timeout).
                threadToStop.Join(1000) ' Wacht maximaal 1 seconde.
                If threadToStop.IsAlive Then
                    Debug.WriteLine($"Thread voor {ipAddress} universe {universe} kon niet op tijd worden gestopt.")
                    ' Forceer eventueel de thread te stoppen (wees hier voorzichtig mee).
                    ' threadToStop.Abort() ' Dit is over het algemeen niet aanbevolen.
                End If
            End If
        End If

        ' Verwijder het IP-adres uit de universe map.
        _universeIpMap.TryRemove(universe, Nothing)
    End Sub

    ''' <summary>
    ''' Stopt alle actieve DMX-outputs.
    ''' </summary>
    Public Sub StopAllDMXOutputs()
        ' Kopieer de keys om thread-safe iteratie mogelijk te maken.
        Dim socketKeys = _sockets.Keys.ToArray()

        For Each key In socketKeys
            Dim parts = key.Split(":")
            If parts.Length = 2 Then
                Dim ipAddress = parts(0)
                Dim universe = Integer.Parse(parts(1))
                StopDMXOutput(ipAddress, universe) ' Gebruik de bestaande StopDMXOutput functie.
            End If
        Next
    End Sub

    ''' <summary>
    ''' Verzendt sACN-data over de opgegeven socket.  Deze sub wordt uitgevoerd in een aparte thread.
    ''' </summary>
    ''' <param name="senderSocket">De socket om de data over te verzenden.</param>
    ''' <param name="ipAddress">Het IP-adres van de ontvanger.</param>
    ''' <param name="universe">Het sACN universe nummer.</param>
    ''' <param name="dmxDataLength">De lengte van de DMX-data.</param>
    ''' <param name="cancellationToken">Een CancellationToken om de bewerking te annuleren.</param>
    ''' <param name="priority">De prioriteit van het sACN-pakket.</param>
    Private Sub SendDataOverSacn(ByVal senderSocket As Socket, ByVal ipAddress As String, ByVal universe As Integer, ByVal dmxDataLength As Integer, ByVal cancellationToken As CancellationToken, ByVal priority As Byte)
        Dim sacnHeader As sACN_Header
        Dim dmxData(dmxDataLength - 1) As Byte ' 0-based index
        Dim sequenceNumber As Byte = 0

        ' Initialize the arrays in the sACN_Header structure.
        ReDim sacnHeader.Preamble(7)           ' 8 bytes
        ReDim sacnHeader.Postamble(1)          ' 2 bytes
        ReDim sacnHeader.AcnPacketIdentifier(11) ' 12 bytes
        ReDim sacnHeader.FlagsLength(1)       ' 2 bytes
        ReDim sacnHeader.OriginatorCID(15)
        ReDim sacnHeader.SourceName(63)

        ' Vul de sACN header.
        sacnHeader.Preamble = New Byte() {0, 0, 0, 0, 0, 0, 0, 0}
        sacnHeader.Postamble = New Byte() {0, 0}
        sacnHeader.AcnPacketIdentifier = System.Text.Encoding.ASCII.GetBytes("ACN\x00\x00\x00\x00\x00\x00\x00\x01")
        Dim flagsLengthValue As UShort = Convert.ToUInt16(&H7000 Or (CUShort(126 + dmxDataLength))) ' Preamble Size: 0x7000
        sacnHeader.FlagsLength = BitConverter.GetBytes(SwapBytes(flagsLengthValue))
        sacnHeader.Vector = &H4 ' VECTOR_DATA
        sacnHeader.Priority = priority
        sacnHeader.SequenceNumber = sequenceNumber
        sacnHeader.OriginatorCID = _originatorCID.ToByteArray()
        sacnHeader.Universe = SwapBytes(Convert.ToUInt16(universe))
        For i As Integer = 0 To Math.Min(_sourceName.Length - 1, 63)
            sacnHeader.SourceName(i) = AscW(_sourceName(i))
        Next
        For i As Integer = _sourceName.Length To 63
            sacnHeader.SourceName(i) = 0
        Next

        ' Correctie voor overflow: Zorg ervoor dat de lengte niet groter is dan Short.MaxValue
        Dim totalLength As Integer = 126 + dmxDataLength
        If totalLength > Short.MaxValue Then
            totalLength = Short.MaxValue
            Debug.WriteLine($"Totale lengte ({totalLength}) overschrijdt maximum Short waarde. Afgekapt.")
        End If
        sacnHeader.Length = SwapBytes(Convert.ToUInt16(totalLength))

        ' Maak de buffer voor het hele sACN-pakket.
        Dim packet(totalLength - 1) As Byte ' 0-based index

        While Not cancellationToken.IsCancellationRequested
            Try
                ' Vul de header in de buffer.
                Buffer.BlockCopy(sacnHeader.Preamble, 0, packet, 0, 8)
                Buffer.BlockCopy(sacnHeader.Postamble, 0, packet, 8, 2)
                Buffer.BlockCopy(sacnHeader.AcnPacketIdentifier, 0, packet, 10, 12)
                Buffer.BlockCopy(sacnHeader.FlagsLength, 0, packet, 22, 2)
                Buffer.BlockCopy(BitConverter.GetBytes(sacnHeader.Vector), 0, packet, 24, 4)
                packet(28) = sacnHeader.Priority
                packet(29) = sequenceNumber
                Buffer.BlockCopy(sacnHeader.OriginatorCID, 0, packet, 30, 16)
                Buffer.BlockCopy(BitConverter.GetBytes(sacnHeader.Universe), 0, packet, 46, 2)
                Buffer.BlockCopy(BitConverter.GetBytes(sacnHeader.Length), 0, packet, 48, 2)
                Buffer.BlockCopy(sacnHeader.SourceName, 0, packet, 50, 63)

                ' Vul de DMX-data in de buffer.
                Buffer.BlockCopy(dmxData, 0, packet, 113, dmxDataLength)

                ' Verzenden van het pakket.
                senderSocket.Send(packet)
                Debug.WriteLine($"sACN data verzonden naar {ipAddress} universe {universe}, sequence number: {sequenceNumber}")

                ' Verhoog het sequence number.
                sequenceNumber = (sequenceNumber + 1) Mod 256 ' Sequence number loopt van 0-255.
                sacnHeader.SequenceNumber = sequenceNumber

                ' Wacht even voordat het volgende pakket wordt verzonden.
                Thread.Sleep(23) ' WLED default interval is 23ms
            Catch ex As SocketException When ex.SocketErrorCode = SocketError.ConnectionReset
                Debug.WriteLine($"Verbinding verbroken met {ipAddress} universe {universe}. Thread wordt beëindigd.")
                Exit While ' Verlaat de loop, thread wordt beëindigd.
            Catch ex As Exception
                Debug.WriteLine($"Fout tijdens het verzenden van sACN data: {ex.Message}. Thread wordt beëindigd.")
                Exit While ' Verlaat de loop, thread wordt beëindigd.
            End Try
        End While

        ' Cleanup: Zorg ervoor dat de socket wordt gesloten als de thread wordt gestopt.
        Try
            senderSocket.Shutdown(SocketShutdown.Both)
            senderSocket.Close()
        Catch ex As Exception
            Debug.WriteLine($"Fout bij het afsluiten van de socket in SendDataOverSacn: {ex.Message}")
        End Try

        Debug.WriteLine($"Thread voor {ipAddress} universe {universe} beëindigd.")
    End Sub

    ''' <summary>
    ''' Stelt de DMX-data in die verzonden moet worden.
    ''' </summary>
    ''' <param name="universe">Het sACN universe nummer.</param>
    ''' <param name="dmxData">De DMX-data als een array van bytes.</param>
    Public Sub SetDMXData(ByVal universe As Integer, ByVal dmxData As Byte())
        Dim ipAddress As String = GetIpAddressForUniverse(universe)
        If String.IsNullOrEmpty(ipAddress) Then
            Debug.WriteLine($"sACN output is niet gestart voor universe {universe}.")
            Return
        End If

        Dim socketKey As String = $"{ipAddress}:{universe}"

        ' Controleer of de data niet langer is dan 512 bytes.
        If dmxData.Length > 512 Then
            Debug.WriteLine("DMX data mag maximaal 512 bytes lang zijn.")
            Return
        End If

        ' Haal de socket op. Als de socket niet bestaat, doe niets.
        Dim senderSocket As Socket
        If Not _sockets.TryGetValue(socketKey, senderSocket) Then
            Return
        End If

        ' Kopieer de data naar een buffer.
        Dim buffer(511) As Byte ' Maximaal 512 bytes, 0-based index.
        Array.Copy(dmxData, buffer, Math.Min(dmxData.Length, 512)) ' Kopieer tot 512 bytes.

        ' Gebruik BeginSend/EndSend voor asynchrone verzending.
        Try
            ' Controleer of de socket nog verbonden is voordat we proberen te verzenden.
            If senderSocket.Connected Then
                senderSocket.Send(buffer)
            Else
                Debug.WriteLine($"Socket is niet verbonden voor universe {universe}. Data niet verzonden.")
            End If

        Catch ex As Exception
            Debug.WriteLine($"Fout bij het instellen van DMX data: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Verwisselt de bytevolgorde van een ushort (van little-endian naar big-endian of omgekeerd).
    ''' </summary>
    ''' <param name="value">De ushort waarde waarvan de bytes verwisseld moeten worden.</param>
    ''' <returns>De ushort waarde met de bytes verwisseld.</returns>
    Private Function SwapBytes(ByVal value As UShort) As UShort
        Return CUShort((value And &HFF00) >> 8 Or ((value And &HFF) << 8))
    End Function

    ''' <summary>
    ''' Haalt het IP-adres op dat is geconfigureerd voor een bepaald universe.
    ''' </summary>
    ''' <param name="universe">Het universe nummer.</param>
    ''' <returns>Het IP-adres, of een lege string als het niet gevonden is.</returns>
    Private Function GetIpAddressForUniverse(ByVal universe As Integer) As String
        If _universeIpMap.ContainsKey(universe) Then
            Return _universeIpMap(universe)
        Else
            Return String.Empty
        End If
    End Function

End Module
