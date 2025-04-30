Imports System.Net.Sockets
Imports System.Net
Imports System.Threading
Imports System.Collections.Concurrent

Module Sacn
    ' Constanten voor sACN
    Private Const SACN_PORT As Integer = 5568
    Private ReadOnly SACN_PREAMBLE As Byte() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Private ReadOnly SACN_IDENTIFIER As String = "ACN\x00\x00\x00\x00" ' Null-terminated string
    Private Const SACN_VERSION As Byte = 1
    Private sequenceNumbers As New ConcurrentDictionary(Of Integer, Byte) ' Thread-safe dictionary

    ' Functie om het sACN-pakket samen te stellen
    Private Function BuildSacnPacket(universe As Integer, sequenceNumber As Byte, data As Byte(), priority As Byte) As Byte()
        ' Bereken de lengtes
        Dim propertyValueCount As Short = CShort(2 + data.Length) ' Lengte van de data + 2 bytes voor property value count
        Dim packetLength As Short = CShort(12 + 63 + data.Length) ' 12 bytes pre-amble + 63 bytes post-amble + data length

        ' Maak de buffer voor het pakket
        Dim packet As New List(Of Byte)

        ' Voeg de preamble en identifier toe
        packet.AddRange(SACN_PREAMBLE)
        packet.AddRange(System.Text.Encoding.ASCII.GetBytes(SACN_IDENTIFIER))

        ' Preamble Size en Post-amble Size
        packet.Add(0)
        packet.Add(0)

        ' Voeg de Preamble Size, Post-amble Size en Packet Length toe
        packet.AddRange(BitConverter.GetBytes(SwapBytes(CShort(&H7200 + packetLength)))) ' Preamble Size: 0x0000, Post-amble Size: 0x0000, Packet Length als Short (2 bytes)

        ' Voeg het Vector en Priority toe
        packet.AddRange(BitConverter.GetBytes(SwapBytes(CUInt(&H20000000 + priority)))) ' Vector: 0x00000200, Priority
        packet.AddRange(BitConverter.GetBytes(SwapBytes(CUInt(universe))))    ' Universe als Integer (4 bytes)

        ' Voeg de Originator ID toe (16 bytes)
        packet.AddRange(System.Text.Encoding.ASCII.GetBytes("WLED"))  ' Originator ID (10 bytes)
        packet.AddRange(New Byte(6) {})       ' Padding tot 16 bytes

        ' Voeg de Sequence Number en Options toe
        packet.Add(sequenceNumber)          ' Sequence Number
        packet.Add(0)                      ' Options: 0x00

        ' Voeg de Property Value Count toe
        packet.AddRange(BitConverter.GetBytes(SwapBytes(propertyValueCount))) ' Property Value Count als Short (2 bytes)

        ' Voeg de data toe
        packet.AddRange(data)

        Return packet.ToArray()
    End Function

    ' Functie om de byte-volgorde om te draaien (network byte order)
    Private Function SwapBytes(value As Short) As Short
        Return CShort((value And &HFF00) >> 8 Or (value And &HFF) << 8)
    End Function

    Private Function SwapBytes(value As UInteger) As UInteger
        Return ((value And &HFF000000) >> 24) Or
               ((value And &HFF0000) >> 8) Or
               ((value And &HFF00) << 8) Or
               ((value And &HFF00) << 24)
    End Function

    ' Functie om de sACN-data te verzenden
    Public Sub SendSacnData(myIpAddress As String, universe As Integer, data As Byte(), priority As Byte)
        Try
            ' Haal het sequence number op of initialiseer het.
            Dim sequenceNumber As Byte = sequenceNumbers.GetOrAdd(universe, 0)

            ' Bouw het sACN-pakket
            Dim packet As Byte() = BuildSacnPacket(universe, sequenceNumber, data, priority)

            ' Verzend het pakket
            Dim client As New UdpClient
            Dim endPoint As New IPEndPoint(IPAddress.Parse(myIpAddress), SACN_PORT)
            client.Send(packet, packet.Length, endPoint)
            client.Close()

            ' Verhoog het sequence number voor de volgende keer.
            sequenceNumber = CByte((sequenceNumber + 1) Mod 256) ' Increment and wrap around
            sequenceNumbers.AddOrUpdate(universe, sequenceNumber, Function(key, oldValue) sequenceNumber) ' Correcte AddOrUpdate aanroep

        Catch ex As Exception
            ' Log de foutmelding
            Console.WriteLine($"Fout bij het verzenden van sACN data naar {myIpAddress}: {ex.Message}")
        End Try
    End Sub
End Module
