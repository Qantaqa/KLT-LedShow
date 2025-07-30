Public Class Beamer_Primary
    Private Sub WMP_PrimaryPlayer_Live_Open_State_Change(sender As Object, e As AxWMPLib._WMPOCXEvents_OpenStateChangeEvent) Handles WMP_PrimaryPlayer_Live.OpenStateChange
        On Error Resume Next

        If WMP_PrimaryPlayer_Live.status.Substring(0, 7) = "Playing" Then
            FrmMain.Timer_LoadBuffer.Stop()
            FrmMain.Timer_LoadBuffer.Interval = 500
            FrmMain.Timer_LoadBuffer.Start()


        End If

        ' Update status
        FrmMain.gbPrimaryBeamer.Text = "Primary Beamer - " & WMP_PrimaryPlayer_Live.status
    End Sub


    Private Sub WMP_PrimaryPlayer_Live_Play_State_Change(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles WMP_PrimaryPlayer_Live.PlayStateChange
        On Error Resume Next
        If (WMP_PrimaryPlayer_Live.status.Substring(0, 7) = "Stopped") Then
            FrmMain.gbPrimaryBeamer.Text = "Primary Beamer - Stopped"
        End If
    End Sub



End Class