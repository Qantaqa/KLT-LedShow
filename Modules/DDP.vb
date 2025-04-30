Imports System.Net
Imports System.Net.Sockets

Module DDP
    Private WithEvents ddpTimer As New Timer With {.Interval = 100}


    Public Sub StartDDPStream()
        ddpTimer.Start()
    End Sub

    Public Sub StopDDPStream()
        ddpTimer.Stop()
    End Sub

    Private Sub ddpTimer_Tick(sender As Object, e As EventArgs) Handles ddpTimer.Tick
        For Each row As DataGridViewRow In FrmMain.DG_Devices.Rows
            If row.Cells("colEnabled").Value = True Then
                Dim ip As String = row.Cells("colIPAddress").Value.ToString()
                Dim data As Byte() = TryCast(row.Cells("colDDPData").Value, Byte())
                If data IsNot Nothing AndAlso data.Length > 0 Then
                    SendDDP(ip, data)
                End If
            End If
        Next
    End Sub



    ' ****************************************************************************************
    '  SendDDP
    '  Stuurt een DDP-pakket met RGB-data naar het opgegeven IP-adres.
    ' ****************************************************************************************

    Public Sub SendDDP(ByVal ip As String, ByVal rgbData() As Byte, Optional ByVal ddpOffset As Integer = 0)
        Dim endpoint As New IPEndPoint(IPAddress.Parse(ip), My.Settings.DDPPort)
        Using client As New UdpClient()
            ' Header: 10 bytes
            Dim header(9) As Byte
            header(0) = &H41 ' DDP flags: push + RGB data
            header(1) = 0 ' Reserved
            header(2) = (ddpOffset >> 8) And &HFF
            header(3) = ddpOffset And &HFF
            header(4) = 0 ' Data offset upper bits (24-bit)
            header(5) = 0
            header(6) = 0
            header(7) = (rgbData.Length >> 8) And &HFF
            header(8) = rgbData.Length And &HFF
            header(9) = 1 ' DDP data type = RGB

            Dim packet(header.Length + rgbData.Length - 1) As Byte
            Array.Copy(header, 0, packet, 0, header.Length)
            Array.Copy(rgbData, 0, packet, header.Length, rgbData.Length)

            client.Send(packet, packet.Length, endpoint)
        End Using
    End Sub

End Module
