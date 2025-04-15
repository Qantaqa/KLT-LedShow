Module Settings
    Public Sub MoveAndMaximizeForm(outputValue As String)
        Dim screenToUse As Screen = Nothing

        Select Case outputValue.ToLower()
            Case "output 1"
                screenToUse = Screen.AllScreens(0) 'First screen
            Case "output 2"
                If Screen.AllScreens.Length > 1 Then
                    screenToUse = Screen.AllScreens(1) 'Second screen, if available
                Else
                    screenToUse = Screen.AllScreens(0) 'Default to first screen if second not found
                End If
            Case "output 3"
                If Screen.AllScreens.Length > 2 Then
                    screenToUse = Screen.AllScreens(2) 'Third screen, if available
                ElseIf Screen.AllScreens.Length > 1 Then
                    screenToUse = Screen.AllScreens(1) 'Default to second screen if third not found
                Else
                    screenToUse = Screen.AllScreens(0) 'Default to first screen if second and third not found
                End If
            Case Else
                'Handle invalid input (e.g., default to the primary screen)
                screenToUse = Screen.PrimaryScreen
        End Select

        If screenToUse IsNot Nothing Then
            FrmMain.StartPosition = FormStartPosition.Manual
            FrmMain.Location = screenToUse.WorkingArea.Location 'Top-left of the screen's working area
            FrmMain.WindowState = FormWindowState.Maximized 'Maximize the window
            FrmMain.Show() 'Ensure the form is shown.
        Else
            MessageBox.Show("Could not determine the correct screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Sub UpdateCurrentTime()
        FrmMain.lblCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Public Sub Update_LockUnlocked()
        If FrmMain.btnLockUnlocked.Text = "Unlocked" Then
            FrmMain.btnLockUnlocked.Text = "Locked"
            FrmMain.btnLockUnlocked.Image = My.Resources.iconLocked

            FrmMain.btnLoad.Enabled = False
            FrmMain.btnSaveShow.Enabled = False
            FrmMain.btn_DGGrid_AddNewRowBefore.Enabled = False
            FrmMain.btn_DGGrid_AddNewRowAfter.Enabled = False
            FrmMain.btn_DGGrid_RemoveCurrentRow.Enabled = False
            FrmMain.DG_Show.ReadOnly = True
            My.Settings.Locked = True
        Else
            FrmMain.btnLockUnlocked.Text = "Unlocked"
            FrmMain.btnLockUnlocked.Image = My.Resources.iconUnlocked_Green

            FrmMain.btnLoad.Enabled = True
            FrmMain.btnSaveShow.Enabled = True
            FrmMain.btn_DGGrid_AddNewRowBefore.Enabled = True
            FrmMain.btn_DGGrid_AddNewRowAfter.Enabled = True
            FrmMain.btn_DGGrid_RemoveCurrentRow.Enabled = True
            FrmMain.DG_Show.ReadOnly = True
            My.Settings.Locked = True

        End If
    End Sub
End Module
