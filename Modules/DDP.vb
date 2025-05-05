Imports System.Net
Imports System.Net.Sockets
Imports System.Windows.Forms

Module DDP
    ' ****************************************************************************************
    ' Group timers voor animaties
    ' ****************************************************************************************
    Private groupTimers As New Dictionary(Of Integer, Timer)()

    ' ****************************************************************************************
    ' StartGroupStream
    ' Initialiseert en start de timer voor een specifieke groep-ID.
    ' ****************************************************************************************
    Public Sub StartGroupStream(groupId As Integer)
        If groupTimers.ContainsKey(groupId) Then Return

        Dim t As New Timer() With {
            .Interval = 100 ' of haal uit instellingen / FPS omzetten naar ms
        }
        AddHandler t.Tick, Sub(sender As Object, e As EventArgs)
                               UpdateGroupFrame(groupId)
                           End Sub
        groupTimers(groupId) = t
        t.Start()
    End Sub

    ' ****************************************************************************************
    ' StopGroupStream
    ' Stopt en verwijdert de timer voor de gegeven groep-ID.
    ' ****************************************************************************************
    Public Sub StopGroupStream(groupId As Integer)
        If Not groupTimers.ContainsKey(groupId) Then Return
        Dim t = groupTimers(groupId)
        t.Stop()
        RemoveHandler t.Tick, Nothing
        groupTimers.Remove(groupId)
    End Sub

    ' ****************************************************************************************
    ' UpdateGroupFrame
    ' Verwerkt de volgende frame voor een groep: leest alle frames uit DG_Groups,
    ' bepaalt de volgende actieve frame-index en schrijft buffers naar DG_Devices.
    ' ****************************************************************************************
    Private Sub UpdateGroupFrame(groupId As Integer)
        Dim dgGroups = FrmMain.DG_Groups

        ' Zoek de rij voor deze groep
        Dim row = dgGroups.Rows.Cast(Of DataGridViewRow)() _
        .FirstOrDefault(Function(r) CInt(r.Cells("colGroupId").Value) = groupId)
        If row Is Nothing Then
            StopGroupStream(groupId)
            Return
        End If

        ' Haal frames-list en huidige index
        Dim frames = TryCast(row.Cells("colAllFrames").Value, List(Of Byte()))
        If frames Is Nothing OrElse frames.Count = 0 Then
            StopGroupStream(groupId)
            Return
        End If
        Dim currentIndex = CInt(row.Cells("colActiveFrame").Value)

        ' Bepaal volgende index (cyclus) en update groep
        Dim nextIndex = (currentIndex + 1) Mod frames.Count
        row.Cells("colActiveFrame").Value = nextIndex

        ' Haal buffer voor deze frame
        Dim fixture = CStr(row.Cells("colGroupFixture").Value)
        Dim buf = frames(nextIndex)

        ' Zoek device waar deze groep bij hoort
        For Each devRow As DataGridViewRow In FrmMain.DG_Devices.Rows.Cast(Of DataGridViewRow)()
            If devRow.IsNewRow Then Continue For
            If CStr(devRow.Cells("colInstance").Value) <> fixture Then Continue For

            ' Bereken juiste offset voor deze groep binnen het device
            Dim ddpOffset As Integer = 0
            For Each groupRow In FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)()
                If Not groupRow.IsNewRow AndAlso
               CStr(groupRow.Cells("colGroupFixture").Value) = fixture AndAlso
               CInt(groupRow.Cells("colGroupId").Value) = groupId Then
                    ddpOffset = (CInt(groupRow.Cells("colGroupStartLedNr").Value) - 1) * 3
                    Exit For
                End If
            Next

            ' Init of haal bestaande device buffer
            Dim ledCount = CInt(devRow.Cells("colLedCount").Value)
            Dim totalSize = ledCount * 3
            Dim deviceBuf = TryCast(devRow.Cells("colDDPData").Value, Byte())
            If deviceBuf Is Nothing OrElse deviceBuf.Length <> totalSize Then
                deviceBuf = New Byte(totalSize - 1) {}
            End If

            ' Kopieer groepsbuffer naar juiste plek in device-buffer
            If ddpOffset + buf.Length <= deviceBuf.Length Then
                Array.Copy(buf, 0, deviceBuf, ddpOffset, buf.Length)
            Else
                Debug.WriteLine($"[DDP] Buffer overflow: groep {groupId} ({fixture}) past niet binnen device-buffer.")
                Return
            End If

            ' Schrijf aangepaste buffer terug
            devRow.Cells("colDDPData").Value = deviceBuf
            devRow.Cells("colDataProvider").Value = "Effects"
            devRow.Cells("colDDPOffset").Value = 0
        Next
    End Sub

    ' ****************************************************************************************
    ' SendDDP
    ' Stuurt een LOW LEVEL DDP-pakket met RGB-data naar het opgegeven IP-adres.
    ' ****************************************************************************************
    Public Sub SendDDP(ByVal ip As String, ByVal rgbData() As Byte, Optional ByVal ddpOffset As Integer = 0)
        Dim endpoint As New IPEndPoint(IPAddress.Parse(ip), My.Settings.DDPPort)
        Using client As New UdpClient()
            Dim header(9) As Byte
            header(0) = &H41 ' DDP flags: push + RGB data
            header(1) = 0 ' Reserved
            header(2) = (ddpOffset >> 8) And &HFF
            header(3) = ddpOffset And &HFF
            header(4) = 0 : header(5) = 0 : header(6) = 0
            header(7) = (rgbData.Length >> 8) And &HFF
            header(8) = rgbData.Length And &HFF
            header(9) = 1 ' DDP data type = RGB

            Dim packet(header.Length + rgbData.Length - 1) As Byte
            Array.Copy(header, 0, packet, 0, header.Length)
            Array.Copy(rgbData, 0, packet, header.Length, rgbData.Length)

            client.Send(packet, packet.Length, endpoint)
        End Using
    End Sub

    ' ****************************************************************************************
    ' HandleDDPTimer_Tick
    ' Verzendt alle buffers die in DG_Devices staan (DMX, Show of Effects).
    ' ****************************************************************************************
    Public Sub HandleDDPTimer_Tick()
        For Each devRow As DataGridViewRow In FrmMain.DG_Devices.Rows
            Try
                If devRow.IsNewRow Then Continue For

                Dim enabled = Convert.ToBoolean(devRow.Cells("colEnabled").Value)
                If Not enabled Then Continue For

                Dim provider = CStr(devRow.Cells("colDataProvider").Value)
                If Not {"Effects", "DMX", "Show"}.Contains(provider) Then Continue For

                Dim ip = CStr(devRow.Cells("colIPAddress").Value)
                If String.IsNullOrWhiteSpace(ip) Then
                    Debug.WriteLine("DDP: IP-adres ontbreekt.")
                    Continue For
                End If

                Dim buf As Byte() = TryCast(devRow.Cells("colDDPData").Value, Byte())
                If buf Is Nothing OrElse buf.Length = 0 Then
                    Debug.WriteLine($"DDP: Geen geldige data voor device op {ip}")
                    Continue For
                End If

                Dim offset As Integer = 0
                If devRow.Cells("colDDPOffset").Value IsNot Nothing Then
                    Integer.TryParse(devRow.Cells("colDDPOffset").Value.ToString(), offset)
                End If

                SendDDP(ip, buf, offset)

            Catch ex As Exception
                Dim ip = If(devRow.Cells("colIPAddress")?.Value, "[onbekend]")
                Debug.WriteLine($"Fout bij DDP-versturen naar {ip}: {ex.Message}")
            End Try
        Next
    End Sub

End Module
