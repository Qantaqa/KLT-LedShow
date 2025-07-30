Module ScreenHandler
    ' Track previous monitor states
    Private ConnectAtLaunch As Boolean = True
    Private wasPrimaryOnline As Boolean = False
    Private wasSecondairyOnline As Boolean = False

    Public Sub UpdateMonitorStatusIndicators(ByVal cbMonitorControl As ComboBox, ByVal cbMonitorPrimary As ComboBox, ByVal cbMonitorSecond As ComboBox)
        Dim primaryScreenDetected As Boolean = False
        Dim secondaryScreenDetected As Boolean = False
        Dim controlScreenDetected As Boolean = False

        ' Check if each screen is detected based on the ComboBox values
        If cbMonitorPrimary.SelectedItem IsNot Nothing Then
            If ((cbMonitorPrimary.SelectedItem.ToString().ToLower() = "output 1" And Screen.AllScreens.Length >= 1) Or
                (cbMonitorPrimary.SelectedItem.ToString().ToLower() = "output 2" And Screen.AllScreens.Length >= 2) Or
                (cbMonitorPrimary.SelectedItem.ToString().ToLower() = "output 3" And Screen.AllScreens.Length >= 3)) Then
                primaryScreenDetected = True
            End If
        End If

        If cbMonitorSecond.SelectedItem IsNot Nothing Then
            If ((cbMonitorSecond.SelectedItem.ToString().ToLower() = "output 1" And Screen.AllScreens.Length >= 1) Or
                (cbMonitorSecond.SelectedItem.ToString().ToLower() = "output 2" And Screen.AllScreens.Length >= 2) Or
                (cbMonitorSecond.SelectedItem.ToString().ToLower() = "output 3" And Screen.AllScreens.Length >= 3)) Then
                secondaryScreenDetected = True
            End If
        End If

        If cbMonitorControl.SelectedItem IsNot Nothing Then
            If ((cbMonitorControl.SelectedItem.ToString().ToLower() = "output 1" And Screen.AllScreens.Length >= 1) Or
                (cbMonitorControl.SelectedItem.ToString().ToLower() = "output 2" And Screen.AllScreens.Length >= 2) Or
                (cbMonitorControl.SelectedItem.ToString().ToLower() = "output 3" And Screen.AllScreens.Length >= 3)) Then
                controlScreenDetected = True
            End If
        End If

        ' Update the PictureBoxes based on the detection results
        UpdatePictureBox(FrmMain.pbPrimaryStatus, primaryScreenDetected)
        UpdatePictureBox(FrmMain.pbSecondaryStatus, secondaryScreenDetected)
        UpdatePictureBox(FrmMain.pbControlStatus, controlScreenDetected)

        ' Detect offline/online transitions and show reconnect buttons, with flash messages
        If wasPrimaryOnline AndAlso Not primaryScreenDetected Then
            FrmMain.btn_ReconnectPrimaryBeamer.Visible = True
            ToonFlashBericht("Primary beamer disconnected.", 10, FlashSeverity.IsWarning)
            FrmMain.warning_PrimaryBeamerOffline.Visible = True
            FrmMain.WMP_PrimaryPlayer_Preview.Visible = False

        ElseIf Not wasPrimaryOnline AndAlso primaryScreenDetected Then
            FrmMain.btn_ReconnectPrimaryBeamer.Visible = False
            ToonFlashBericht("Primary beamer reconnected.", 5, FlashSeverity.IsInfo)
            FrmMain.warning_PrimaryBeamerOffline.Visible = False
            FrmMain.WMP_PrimaryPlayer_Preview.Visible = True

        End If
        wasPrimaryOnline = primaryScreenDetected

        If wasSecondairyOnline AndAlso Not secondaryScreenDetected Then
            FrmMain.btn_ReconnectSecondairyBeamer.Visible = True

            FrmMain.warning_SecondairyBeamerOffline.Visible = True
            FrmMain.WMP_SecondairyPlayer_Preview.Visible = False
            If (ConnectAtLaunch) Then
                ConnectAtLaunch = False
            Else
                ToonFlashBericht("Secondary beamer disconnected.", 10, FlashSeverity.IsWarning)
            End If

        ElseIf Not wasSecondairyOnline AndAlso secondaryScreenDetected Then
            FrmMain.btn_ReconnectSecondairyBeamer.Visible = False
            ToonFlashBericht("Secondary beamer reconnected.", 5, FlashSeverity.IsInfo)
            FrmMain.warning_SecondairyBeamerOffline.Visible = False
            FrmMain.WMP_SecondairyPlayer_Preview.Visible = True
        End If
        wasSecondairyOnline = secondaryScreenDetected
    End Sub

    Private Sub UpdatePictureBox(pictureBox As PictureBox, screenDetected As Boolean)
        If screenDetected Then
            pictureBox.Image = My.Resources.iconGreenBullet1
        Else
            pictureBox.Image = My.Resources.iconRedBullet1
        End If
    End Sub
End Module
