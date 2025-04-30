Imports System.IO
Imports System.Runtime.InteropServices

Public Class FrmMain
    Dim LastOfflineDevices As Integer = 0       'Nummer van offline apparaten


    ' Importeer de functie voor het ophalen van Frame delays
    <DllImport("gdi32.dll", SetLastError:=True, ExactSpelling:=True)>
    Private Shared Function GetEnhMetaFilePixelFormat(ByVal hEmf As IntPtr) As UInteger
    End Function

    Private Sub FrmMain_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim c As Integer = 0

            ' Configureer de DataGridView voor de Devices tab
            'DG_Devices.Dock = DockStyle.Fill
            DG_Devices.AutoGenerateColumns = False
            DG_Devices.AllowUserToAddRows = False
            DG_Devices.AllowUserToDeleteRows = False
            DG_Devices.ReadOnly = False

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
            settings_ProjectFolder.Text = My.Settings.DatabaseFolder
            settings_ProjectName.Text = My.Settings.ProjectName
            lblTitleProject.Text = My.Settings.ProjectName
            settings_PalettesPath.Text = My.Settings.PaletteImagesPath
            settings_EffectsPath.Text = My.Settings.EffectsImagePath
            cbMonitorControl.Text = My.Settings.MonitorControl
            cbMonitorPrime.Text = My.Settings.MonitorPrimary
            cbMonitorSecond.Text = My.Settings.MonitorSecond

            If My.Settings.Locked Then
                Update_LockUnlocked("Locked")
                LoadAll()
            Else

                Update_LockUnlocked("Unlocked")
            End If




            UpdateMonitorStatusIndicators(cbMonitorControl, cbMonitorPrime, cbMonitorSecond)
            c = CheckWLEDOnlineStatus(DG_Devices)
            If (c > 0) Then
                ' 1 of meerdere WLED-apparaten offline, geef een melding weer
                ToonFlashBericht("Er zijn " + c.ToString + " WLED-apparaten offline op het netwerk.", 2)
            End If



        Catch ex As Exception
            MessageBox.Show($"Fout tijdens laden van form: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Log de fout eventueel naar een bestand of de Event Viewer
        End Try
    End Sub


    Private Sub DG_Devices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Devices.CellContentClick
        If (e.ColumnIndex < 2) Then
            OpenWebsiteOfWLED(Me.DG_Devices, txt_APIResult, e)
        End If
    End Sub



    Private Sub DG_Effecten_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Effecten.CellContentClick
        Handle_DGEffecten_CellContentClick(sender, e, Me.DG_Effecten, Me.DG_Devices)

    End Sub

    Private Sub btnSaveShow_Click(sender As Object, e As EventArgs) Handles btnSaveShow.Click
        SaveAll()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DG_Paletten_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Paletten.CellContentClick
        KLT_LedShow.DG_Paletten_CellContentClick(sender, e, DG_Paletten, DG_Devices)
    End Sub


    Private Sub DG_Show_AfterUpdateCellValue(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Show.CellValueChanged
        KLT_LedShow.DG_Show_AfterUpdateCellValue(sender, e, DG_Show, DG_Effecten, DG_Paletten)
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles filterAct.Click
        FilterDG_Show(DG_Show, filterAct)
    End Sub

    Private Sub btn_DG_Show_AddNewRowBefore_Click(sender As Object, e As EventArgs) Handles btn_DGGrid_AddNewRowBefore.Click
        DG_Show_AddNewRowBefore_Click(DG_Show)
    End Sub

    Private Sub btn_DG_Show_AddNewRowAfter_Click(sender As Object, e As EventArgs) Handles btn_DGGrid_AddNewRowAfter.Click
        DG_Show_AddNewRowAfter_Click(DG_Show)
    End Sub

    Private Sub btn_DG_Show_RemoveCurrentRow_Click(sender As Object, e As EventArgs) Handles btn_DGGrid_RemoveCurrentRow.Click
        DG_Show_RemoveCurrentRow_Click(DG_Show)
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerEverySecond.Tick
        UpdateMonitorStatusIndicators(cbMonitorControl, cbMonitorPrime, cbMonitorSecond)
        UpdateCurrentTime()
        UpdateBlinkingButton()

        lblControl_TimeLeft.Text = RemoveSecondFromStringTime(lblControl_TimeLeft.Text)
    End Sub




    Private Sub btnScanNetworkForWLed_Click(sender As Object, e As EventArgs) Handles btnScanNetworkForWLed.Click
        ScanNetworkForWLEDdevices(DG_Devices, DG_Effecten, DG_Show, DG_Paletten, DG_Groups)
        '        PopulateSegmentsDataGridView(DG_Devices, DG_Segments)'
    End Sub

    Private Sub btnProjectFolder_Click(sender As Object, e As EventArgs) Handles btnProjectFolder.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim fileName As String = OpenFileDialog1.FileName
                Dim filePath As String = Path.GetDirectoryName(fileName)
                Me.settings_ProjectFolder.Text = filePath
                My.Settings.DatabaseFolder = filePath
            Catch ex As Exception
                MsgBox("Fout bij het openen van het bestand: " & ex.Message, MsgBoxStyle.Critical, "Fout")
            End Try
        End If

    End Sub

    Private Sub settings_ProjectName_TextChanged(sender As Object, e As EventArgs) Handles settings_ProjectName.TextChanged
        My.Settings.ProjectName = settings_ProjectName.Text
        lblTitleProject.Text = settings_ProjectName.Text
    End Sub

    Private Sub btnLockUnlocked_Click(sender As Object, e As EventArgs) Handles btnLockUnlocked.Click
        If btnLockUnlocked.Text = "Locked" Then
            Update_LockUnlocked("Unlocked")
            ToonFlashBericht("Project " & lblTitleProject.Text & " is nu unlocked.", 2)
        Else
            Update_LockUnlocked("Locked")
            ToonFlashBericht("Project " & lblTitleProject.Text & " is locked.", 2)
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        DG_Palette_LoadImages(DG_Paletten)

    End Sub

    Private Sub DG_Show_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Show.CellClick
        ' Controleer of de klik op een knopcel in de gewenste kolom was
        Dim RowId = e.RowIndex
        If e.ColumnIndex = DG_Show.Columns("btnApply").Index AndAlso e.RowIndex >= 0 Then
            KLT_LedShow.Apply_DGShowRow_ToWLED(sender, DG_Devices, DG_Effecten, DG_Paletten, True)

        End If
    End Sub

    Private Sub DG_Show_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Show.RowEnter
        Update_DGGRid_Details(DG_Show, e.RowIndex)
    End Sub

    Private Sub detailWLed_Brightness_Scroll(sender As Object, e As EventArgs) Handles detailWLed_Brightness.Scroll
        DG_Show.CurrentRow.Cells("colBrightness").Value = detailWLed_Brightness.Value
    End Sub

    Private Sub detailWLed_Intensity_Scroll(sender As Object, e As EventArgs) Handles detailWLed_Intensity.Scroll
        DG_Show.CurrentRow.Cells("colIntensity").Value = detailWLed_Intensity.Value
    End Sub

    Private Sub detailWLed_Speed_Scroll(sender As Object, e As EventArgs) Handles detailWLed_Speed.Scroll
        DG_Show.CurrentRow.Cells("colSpeed").Value = detailWLed_Speed.Value
    End Sub

    Private Sub detailWLed_Color1_Click(sender As Object, e As EventArgs) Handles detailWLed_Color1.Click
        detailWLed_Color1.BackColor = GetColorByColorWheel()
        DG_Show.CurrentRow.Cells("colColor1").Value = detailWLed_Color1.BackColor.ToArgb()
    End Sub

    Private Sub detailWLed_Color2_Click(sender As Object, e As EventArgs) Handles detailWLed_Color2.Click
        detailWLed_Color2.BackColor = GetColorByColorWheel()
        DG_Show.CurrentRow.Cells("colColor2").Value = detailWLed_Color2.BackColor.ToArgb()
    End Sub

    Private Sub detailWLed_Color3_Click(sender As Object, e As EventArgs) Handles detailWLed_Color3.Click
        detailWLed_Color3.BackColor = GetColorByColorWheel()
        DG_Show.CurrentRow.Cells("colColor3").Value = detailWLed_Color3.BackColor.ToArgb()

    End Sub

    Private Sub btnControl_Start_Click(sender As Object, e As EventArgs) Handles btnControl_Start.Click
        Start_Show(DG_Show)
    End Sub

    Private Sub TimerNextEvent_Tick(sender As Object, e As EventArgs) Handles TimerNextEvent.Tick
        EndEventTimer()
    End Sub

    Private Sub TimerPingDevices_Tick(sender As Object, e As EventArgs) Handles TimerPingDevices.Tick
        Dim C As Integer = 0
        C = CheckWLEDOnlineStatus(DG_Devices)

        If (C <> LastOfflineDevices) Then
            LastOfflineDevices = C
            ToonFlashBericht("Er zijn " & C.ToString & " WLED-apparaten offline op het netwerk.", 2)
        End If
    End Sub

    Private Sub btnPingDevice_Click(sender As Object, e As EventArgs) Handles btnPingDevice.Click
        TimerPingDevices_Tick(sender, e)
    End Sub

    Private Sub btnAddDevice_Click(sender As Object, e As EventArgs) Handles btnAddDevice.Click
        DG_Devices_AddNewRowAfter_Click(DG_Devices, DG_Show, DG_Groups)
    End Sub

    Private Sub btnDeleteDevice_Click(sender As Object, e As EventArgs) Handles btnDeleteDevice.Click
        DG_Devices_RemoveCurrentRow_Click(DG_Devices)
    End Sub

    Private Sub btnLoadAll_Click(sender As Object, e As EventArgs) Handles btnLoadAll.Click
        LoadAll()
    End Sub

    Private Sub btnLoadShow_Click(sender As Object, e As EventArgs) Handles btnLoadShow.Click
        LoadShow()
    End Sub

    Private Sub btnLoadEffectPalettes_Click(sender As Object, e As EventArgs) Handles btnLoadEffectPalettes.Click
        LoadEffectPalettes()
    End Sub

    Private Sub detailWLed_Effect_Paint(sender As Object, e As PaintEventArgs) Handles detailWLed_Effect.Paint
        Show_PaintEvent(sender, e)
    End Sub

    Private Sub btnTestExistanceEffects_Click(sender As Object, e As EventArgs) Handles btnTestExistanceEffects.Click
        TestEffectImages(DG_Effecten, My.Settings.EffectsImagePath)
    End Sub

    Private Sub btnGenerateStage_Click(sender As Object, e As EventArgs) Handles btnGenerateStage.Click
        GenereerLedLijst(DG_Devices, 1000, 400)
        TekenPodium(pb_Stage, 1000, 400)
    End Sub


    Private Sub btnUpdateStage_Click(sender As Object, e As EventArgs) Handles btnUpdateStage.Click
        TekenPodium(pb_Stage, 1000, 400)
    End Sub

    Private Sub DG_Devices_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Devices.CellValidated
        On Error Resume Next

        If (e.ColumnIndex = DG_Devices.Columns("colLayout").Index) Then

            Dim oldValue = DG_Devices.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim newValue = VervangRichtingDoorPijlen(oldValue)
            DG_Devices.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = newValue
        End If
    End Sub

    Private Sub btnGroupAddRowAfter_Click(sender As Object, e As EventArgs) Handles btnGroupAddRowAfter.Click
        GroupAddRowAfter(DG_Groups)
    End Sub

    Private Sub btnGroupAddRowBefore_Click(sender As Object, e As EventArgs) Handles btnGroupAddRowBefore.Click
        GroupAddRowBefore(DG_Groups)
    End Sub

    Private Sub btnGroupDeleteRow_Click(sender As Object, e As EventArgs) Handles btnGroupDeleteRow.Click
        GroupDeleteRow(DG_Groups)
    End Sub


    Private Sub DMX_1_R_Scroll(sender As Object, e As EventArgs) Handles DMX_1_R.Scroll
        Dim ipAddress As String = "192.168.86.62" ' Haal dit eventueel uit een globale variabele of configuratie
        Dim universe As Integer = 1
        Dim dmxValue As Integer = DMX_1_R.Value
        Dim dmxData(0) As Byte ' Maak een byte array van de juiste grootte (1 in dit geval, index 0)
        dmxData(0) = CByte(dmxValue) ' Zet de integer waarde om naar een byte

        SetDMXData(universe, dmxData)
    End Sub

    Private Sub btnStartDMXSync_Click(sender As Object, e As EventArgs) Handles btnStartDMXSync.Click
        For Each row As DataGridViewRow In DG_Devices.Rows
            If CBool(row.Cells("colEnabled").Value) Then
                Dim ipAddress As String = row.Cells("colIPAddress").Value.ToString()
                Dim startUniverse As Integer = CInt(row.Cells("colStartUniverse").Value)
                Dim ledCount As Integer = CInt(row.Cells("colLedCount").Value)
                Dim dmxDataLength As Integer = ledCount * 3
                Dim currentUniverse As Integer = startUniverse
                Dim ledsLeft As Integer = ledCount
                Dim endUniverse As Integer = 0
                Dim priority As Byte = 100 ' Prioriteit van het sACN-pakket

                If DG_Devices.Columns.Contains("colEndUniverse") Then
                    ' Lees de waarde van colEndUniverse uit de DataGridView.
                    If row.Cells("colEndUniverse").Value IsNot Nothing AndAlso row.Cells("colEndUniverse").Value.ToString() <> "" Then
                        endUniverse = CInt(row.Cells("colEndUniverse").Value)
                    End If
                End If

                ' Controleer of het aantal LEDs groter is dan 170.
                If ledCount > 170 Then
                    Dim universesNeeded As Integer = CInt(Math.Ceiling(ledCount / 170))
                    For i As Integer = 0 To universesNeeded - 1
                        Dim ledsForUniverse As Integer = Math.Min(ledsLeft, 170)
                        Dim dmxLengthForUniverse As Integer = ledsForUniverse * 3
                        If dmxLengthForUniverse > 512 Then
                            dmxLengthForUniverse = 512
                        End If

                        Dim rowCopy As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                        For j As Integer = 0 To row.Cells.Count - 1
                            rowCopy.Cells(j).Value = row.Cells(j).Value
                        Next

                        ' Gebruik colStartUniverse als het beschikbaar is, anders bereken het universe nummer.
                        Dim universeToSend As Integer
                        If DG_Devices.Columns.Contains("colStartUniverse") Then
                            universeToSend = currentUniverse ' Stel het universe nummer in voor deze iteratie
                            rowCopy.Cells("colStartUniverse").Value = currentUniverse
                        ElseIf DG_Devices.Columns.Contains("colEndUniverse") Then
                            universeToSend = currentUniverse
                        Else
                            ' Als colStartUniverse niet beschikbaar is, gebruik dan currentUniverse.
                            universeToSend = currentUniverse
                            rowCopy.Cells("colUniverse").Value = currentUniverse
                        End If

                        ' Maak de DMX data array.
                        Dim dmxData(dmxLengthForUniverse - 1) As Byte
                        For k As Integer = 0 To dmxLengthForUniverse - 1
                            dmxData(k) = CByte(k) ' Vul de array met voorbeeldwaarden.  Dit moet uiteindelijk de juiste data zijn.
                        Next

                        ' Verzend de sACN data.
                        SendSacnData(ipAddress, universeToSend, dmxData, priority)

                        currentUniverse += 1
                        ledsLeft -= ledsForUniverse
                    Next
                Else
                    ' Als het aantal LEDs <= 170, handel het af zoals voorheen.
                    If dmxDataLength > 512 Then
                        dmxDataLength = 512
                        MessageBox.Show($"Het aantal DMX kanalen voor IP: {ipAddress}, Universe: {startUniverse} is te hoog. Maximale waarde van 512 wordt gebruikt.", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    ' Maak de DMX data array.
                    Dim dmxData(dmxDataLength - 1) As Byte
                    For k As Integer = 0 To dmxDataLength - 1
                        dmxData(k) = CByte(k) ' Vul de array met voorbeeldwaarden. Dit moet uiteindelijk de juiste data zijn.
                    Next

                    ' Verzend de sACN data.
                    SendSacnData(ipAddress, startUniverse, dmxData, priority)
                End If
            End If
        Next
    End Sub


End Class