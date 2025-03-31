Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Xml
Imports System.Diagnostics  ' Toegevoegd voor Process.Start
Imports System.Windows.Forms ' Toegevoegd voor toegang tot UI-elementen

Public Class FrmMain

    Private Sub FrmMain_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Configureer de DataGridView voor de Devices tab
            DG_Devices.Dock = DockStyle.Fill
            DG_Devices.AutoGenerateColumns = False
            DG_Devices.AllowUserToAddRows = False
            DG_Devices.AllowUserToDeleteRows = False
            DG_Devices.ReadOnly = True

            ' Definieer de kolommen voor de DataGridView
            Dim ipColumn As New DataGridViewTextBoxColumn
            ipColumn.Name = "colIPAddress"
            ipColumn.HeaderText = "IP Address"
            ipColumn.DataPropertyName = "IPAddress"

            Dim nameColumn As New DataGridViewTextBoxColumn
            nameColumn.Name = "colInstance"
            nameColumn.HeaderText = "WLED Name"
            nameColumn.DataPropertyName = "WLEDName"

            'DG_Devices.Columns.AddRange(ipColumn, nameColumn) ' Voeg de kolommen toe aan de DataGridView

            ' Configureer de DataGridView voor de Effecten tab
            DG_Effecten.AllowUserToAddRows = False
            DG_Effecten.AllowUserToDeleteRows = False
            DG_Effecten.ReadOnly = True

            ' Configureer de DataGridView voor de Paletten tab
            DG_Paletten.AllowUserToAddRows = False
            DG_Paletten.AllowUserToDeleteRows = False
            DG_Paletten.ReadOnly = True

            'ShowHandler.ConfigureDG_Show(Me.DG_Show)
            txtIPRange.Text = My.Settings.IPRange
            cbMonitorControl.Text = My.Settings.MonitorControl
            cbMonitorPrime.Text = My.Settings.MonitorPrimary
            cbMonitorSecond.Text = My.Settings.MonitorSecond

            UpdateMonitorStatusIndicators(cbMonitorControl, cbMonitorPrime, cbMonitorSecond)


        Catch ex As Exception
            MessageBox.Show($"Fout tijdens laden van form: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Log de fout eventueel naar een bestand of de Event Viewer
        End Try
    End Sub

    Private Sub btnScanNetwork_Click(sender As Object, e As EventArgs) Handles btnScanNetwork.Click
        ' Code is verplaatst naar de module DetectDevices
        DetectDevices.doScanNetwork_Click(Me.DG_Devices, Me.DG_Effecten)
    End Sub

    Private Sub DG_Devices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Devices.CellContentClick
        ' Controleer of er op een geldige cel is geklikt (niet de header)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Haal de IP-adres op van de geselecteerde rij
            Dim ipAddress As String = TryCast(DG_Devices.Rows(e.RowIndex).Cells("colIPAddress").Value, String)
            If Not String.IsNullOrEmpty(ipAddress) Then
                Try
                    ' Open de browser met het IP-adres
                    Process.Start(New ProcessStartInfo($"http://{ipAddress}") With {.UseShellExecute = True})
                Catch ex As Exception
                    MessageBox.Show($"Fout bij het openen van de browser: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub



    Private Sub DG_Effecten_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Effecten.CellContentClick
        ShowHandler.DG_Effecten_CellContentClick(sender, e, Me.DG_Effecten, Me.DG_Devices)
    End Sub

    Private Sub btnSaveShow_Click(sender As Object, e As EventArgs) Handles btnSaveShow.Click
        Dim Folder As String = My.Settings.DatabaseFolder

        SaveDataGridViewToXml(DG_Devices, Folder + "\Devices.xml")
        SaveWLEDDevicesToJson(wledDevices, Folder + "\Devices.json")
        SaveDataGridViewToXml(DG_Effecten, Folder + "\Effects.xml")
        SaveDataGridViewToXml(DG_Paletten, Folder + "\Paletten.xml")
        SaveDataGridViewToXml(DG_Show, Folder + "\Show.xml")

        MessageBox.Show("All data has been saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim Folder As String = My.Settings.DatabaseFolder


        LoadJSonToWLEDDevices(wledDevices, Folder + "\Devices.json")
        LoadXmlToDataGridView(DG_Devices, Folder + "\Devices.xml", False)
        LoadXmlToDataGridView(DG_Effecten, Folder + "\Effects.xml", True)
        LoadXmlToDataGridView(DG_Paletten, Folder + "\Paletten.xml", True)

        LoadXmlToDataGridView(DG_Show, Folder + "\Show.xml", False)



        For Each row As DataGridViewRow In DG_Show.Rows
            ShowHandler.DG_Show_UpdatePulldownField_For_CurrentFixture(DG_Show, New DataGridViewCellEventArgs(0, row.Index))
            ShowHandler.DG_Show_UpdatePulldownField_For_CurrentEffect(DG_Show, row.Index)
            ShowHandler.DG_Show_UpdatePulldownField_For_CurrentPalette(DG_Show, row.Index)
        Next


        ShowHandler.UpdateEffectAndPaletteDropdowns(DG_Show, 1)
    End Sub

    Private Sub DG_Paletten_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Paletten.CellContentClick
        ShowHandler.DG_Paletten_CellContentClick(sender, e, Me.DG_Paletten, Me.DG_Devices)
    End Sub

    ' ON ENTER of Cell
    Private Sub DG_Show_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Show.CellEnter
        If DG_Show.Rows.Count > 0 AndAlso e.RowIndex >= 0 Then
            If e.ColumnIndex = DG_Show.Columns("colFixture").Index Then
                ShowHandler.DG_Show_UpdatePulldownField_For_CurrentFixture(DG_Show, e)
            End If

            If ((e.ColumnIndex = DG_Show.Columns("colEffect").Index) Or
                (e.ColumnIndex = DG_Show.Columns("colPalette").Index)) Then
                ShowHandler.UpdateEffectAndPaletteDropdowns(DG_Show, e.RowIndex)
            End If
        End If
    End Sub

    ' ON CHANGE of Cell
    Private Sub DG_Show_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Show.CellValueChanged
        If DG_Show.Rows.Count > 0 AndAlso e.RowIndex >= 0 Then
            If e.ColumnIndex = DG_Show.Columns("colFixture").Index Then
                ' When fixture is updated, update the other fields
                ShowHandler.DG_Show_UpdateOtherFieldsWithDefaultValues(DG_Show, e.RowIndex)
                ShowHandler.DG_Show_UpdatePulldownField_For_CurrentEffect(DG_Show, e.RowIndex)
                ShowHandler.DG_Show_UpdatePulldownField_For_CurrentPalette(DG_Show, e.RowIndex)
                ShowHandler.DG_Show_UpdateEffectAndPaletteName(DG_Show, DG_Effecten, DG_Paletten)
            ElseIf e.ColumnIndex = DG_Show.Columns("colEffect").Index Then
                'ShowHandler.DG_Show_UpdateWLEDEffect(DG_Show, e.RowIndex, DG_Devices)
            ElseIf e.ColumnIndex = DG_Show.Columns("colPalette").Index Then
            ElseIf e.ColumnIndex = DG_Show.Columns("colAct").Index Then
                ' When act is updated, update the other fields like scene or event number
                ShowHandler.DG_Show_UpdateActOrSceneNumber(DG_Show, e)
            End If
        End If
    End Sub

    ' ON VALIDATING of Cell
    Private Sub DG_Show_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DG_Show.CellValidating
        ShowHandler.DG_Show_CellValidating(Me.DG_Show, e)
    End Sub



    Private Sub DG_Show_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DG_Show.RowsAdded
        ShowHandler.DG_Show_RowsAdded(Me.DG_Show, e)
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles filterAct.Click
        FilterDG_Show(DG_Show, filterAct)
    End Sub

    Private Sub btn_DGGrid_AddNewRowBefore_Click(sender As Object, e As EventArgs) Handles btn_DGGrid_AddNewRowBefore.Click
        DGGrid_AddNewRowBefore_Click(DG_Show)
    End Sub

    Private Sub btn_DGGrid_AddNewRowAfter_Click(sender As Object, e As EventArgs) Handles btn_DGGrid_AddNewRowAfter.Click
        DGGrid_AddNewRowAfter_Click(DG_Show)
    End Sub

    Private Sub btn_DGGrid_RemoveCurrentRow_Click(sender As Object, e As EventArgs) Handles btn_DGGrid_RemoveCurrentRow.Click
        DGGrid_RemoveCurrentRow_Click(DG_Show)
    End Sub

    Private Sub DG_Show_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DG_Show.DataError
        On Error Resume Next
        'MessageBox.Show("DG_Show_DataError: " & e.Exception.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub cbMonitorControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMonitorControl.SelectedIndexChanged
        My.Settings.MonitorControl = cbMonitorControl.Text
        My.Settings.Save()
        MoveAndMaximizeForm(cbMonitorControl.Text)
    End Sub

    Private Sub cbMonitorPrime_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMonitorPrime.SelectedIndexChanged
        My.Settings.MonitorPrimary = cbMonitorPrime.Text
        My.Settings.Save()
    End Sub

    Private Sub cbMonitorSecond_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMonitorSecond.SelectedIndexChanged
        My.Settings.MonitorSecond = cbMonitorSecond.Text
        My.Settings.Save()
    End Sub

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
            StartPosition = FormStartPosition.Manual
            Location = screenToUse.WorkingArea.Location 'Top-left of the screen's working area
            WindowState = FormWindowState.Maximized 'Maximize the window
            Show() 'Ensure the form is shown.
        Else
            MessageBox.Show("Could not determine the correct screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerEverySecond.Tick
        UpdateMonitorStatusIndicators(cbMonitorControl, cbMonitorPrime, cbMonitorSecond)
    End Sub


    Private Sub DG_Show_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DG_Show.MouseDoubleClick
        MsgBox("Mouse Double click")
    End Sub
End Class
