Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports Newtonsoft.Json

Public Class FrmMain
    'Private LedKleuren As New List(Of Color)
    Dim LastOfflineDevices As Integer = 0       'Nummer van offline apparaten
    Public CurrentGroupId As Integer = 0
    Public CurrentDeviceId As Integer = 0
    Private laatsteDDPHash As Integer = 0


    ' Importeer de functie voor het ophalen van Frame delays
    <DllImport("gdi32.dll", SetLastError:=True, ExactSpelling:=True)>
    Private Shared Function GetEnhMetaFilePixelFormat(ByVal hEmf As IntPtr) As UInteger
    End Function


    ' **************************************************************************************************************************
    ' MAIN FORM LOAD
    ' **************************************************************************************************************************
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
            settings_DDPPort.Text = My.Settings.DDPPort
            EffectColor1.BackColor = Color.FromArgb(My.Settings.CustomEffectC1)
            EffectColor2.BackColor = Color.FromArgb(My.Settings.CustomEffectC2)
            EffectColor3.BackColor = Color.FromArgb(My.Settings.CustomEffectC3)
            EffectColor4.BackColor = Color.FromArgb(My.Settings.CustomEffectC4)
            EffectColor5.BackColor = Color.FromArgb(My.Settings.CustomEffectC5)
            tbEffectIntensity.Value = My.Settings.CustomEffectIntensity
            tbEffectSpeed.Value = My.Settings.CustomEffectSpeed
            tbEffectBrightnessBaseline.Value = My.Settings.CustomEffectBrightness
            tbEffectBrightnessEffect.Value = My.Settings.CustomEffectBrightnessEffect
            tbEffectDispersion.Value = My.Settings.CustomEffectDispersion

            Dim tip As New ToolTip()
            tip.SetToolTip(tbEffectSpeed, "Snelheid van het effect. Hoe hoger, hoe sneller de animatie verloopt (range 1-100%).")
            tip.SetToolTip(tbEffectIntensity, "Hoe intens is de beweging of kleurenwissel. Bepaalt het bereik van de helderheid. (range 1-100%)")
            tip.SetToolTip(tbEffectBrightnessBaseline, "Maximale helderheid van het effect (globale limiet). (1-100%)")
            tip.SetToolTip(tbEffectFPS, "Aantal frames per seconde. Hoger = vloeiender, maar ook meer belasting. (15-60 fps, advies 15")
            tip.SetToolTip(tbEffectDuration, "Duur van het effect in seconden. (5-90 sec)")



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

            CurrentGroupId = -1
            CurrentDeviceId = -1

            'StartDDPStream()

        Catch ex As Exception
            MessageBox.Show($"Fout tijdens laden van form: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Log de fout eventueel naar een bestand of de Event Viewer
        End Try
    End Sub

    ' **************************************************************************************************************************
    ' EVENT HANDLERS - Klik op DG Devices en open de bijbehorende webste
    ' **************************************************************************************************************************
    Private Sub DG_Devices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Devices.CellContentClick
        If (e.ColumnIndex < 2) Then
            OpenWebsiteOfWLED(Me.DG_Devices, txt_APIResult, e)
        End If
    End Sub


    ' **************************************************************************************************************************
    ' EVENT HANDLERS - Klikken in de effecten tabel
    ' **************************************************************************************************************************
    Private Sub DG_Effecten_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Effecten.CellContentClick
        Handle_DGEffecten_CellContentClick(sender, e, Me.DG_Effecten, Me.DG_Devices)

    End Sub

    ' **************************************************************************************************************************
    ' EVENT HANDLERS - Opslaan
    ' **************************************************************************************************************************
    Private Sub btnSaveShow_Click(sender As Object, e As EventArgs) Handles btnSaveShow.Click
        SaveAll()
    End Sub

    ' **************************************************************************************************************************
    ' EVENT HANDLERS - Klikken in pallet tabel
    ' **************************************************************************************************************************
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
        ScanNetworkForWLEDDevices(DG_Devices)
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
        My.Settings.Save()
    End Sub

    Private Sub settings_ProjectName_TextChanged(sender As Object, e As EventArgs) Handles settings_ProjectName.TextChanged
        My.Settings.ProjectName = settings_ProjectName.Text
        lblTitleProject.Text = settings_ProjectName.Text

        My.Settings.Save()
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
        'ClearGroupsToBlack()
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
        TextExistanceEffects(DG_Effecten, My.Settings.EffectsImagePath)
    End Sub

    Private Sub btnGenerateStage_Click(sender As Object, e As EventArgs) Handles btnGenerateStage.Click
        GenereerLedLijst(DG_Devices, pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
        TekenPodium(pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
    End Sub


    Private Sub btnUpdateStage_Click(sender As Object, e As EventArgs) Handles btnUpdateStage.Click
        TekenPodium(pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
    End Sub

    Private Sub DG_Devices_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Devices.CellValidated
        On Error Resume Next

        If (e.ColumnIndex = DG_Devices.Columns("colLayout").Index) Then

            Dim oldValue = DG_Devices.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim newValue = ValidateLayoutString(oldValue)
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



    Sub ControlOneLed(DeviceRow As DataGridViewRow, lednr As Integer, redvalue As Integer, greenvalue As Integer, bluevalue As Integer)
        Dim r As Integer = redvalue
        Dim g As Integer = greenvalue
        Dim b As Integer = bluevalue

        ' Segment voor LED 0 instellen (start 0, stop 1)
        Dim json As String = JsonConvert.SerializeObject(New With {
        .seg = New Object() {
            New With {
                .id = 0,
                .start = lednr - 1,
                .stop = lednr,
                .col = New Integer()() {New Integer() {r, g, b}}
            }
        }
    })

        Dim client As New WebClient()
        client.Headers(HttpRequestHeader.ContentType) = "application/json"

        Dim MyUrl = "http://" + DeviceRow.Cells("colIPAddress").Value + "/json/state"
        Try
            client.UploadString(MyUrl, "POST", json)
        Catch ex As Exception
            MessageBox.Show("Fout bij verzenden naar WLED: " & ex.Message)
        End Try

    End Sub

    Private Sub btnGenerateSlider_Click(sender As Object, e As EventArgs) Handles btnGenerateSliders.Click

        If (DG_Devices.CurrentRow Is Nothing) Then
            ToonFlashBericht("Selecteer eerst een device in de tabel.", 2)
            Return
        End If
        CurrentDeviceId = DG_Devices.CurrentRow.Index
        CurrentGroupId = -1
        GenerateSlidersForSelectedFixture(DG_Devices.CurrentRow, SplitContainer_Devices.Panel2)
    End Sub

    Private Sub settings_EffectsPath_TextChanged(sender As Object, e As EventArgs) Handles settings_EffectsPath.TextChanged
        My.Settings.EffectsImagePath = settings_EffectsPath.Text
        My.Settings.Save()
    End Sub

    Private Sub settings_PalettesPath_TextChanged(sender As Object, e As EventArgs) Handles settings_PalettesPath.TextChanged
        My.Settings.PaletteImagesPath = settings_PalettesPath.Text
        My.Settings.Save()
    End Sub

    Private Sub settings_DDPPort_TextChanged(sender As Object, e As EventArgs) Handles settings_DDPPort.TextChanged
        My.Settings.DDPPort = CInt(settings_DDPPort.Text)
        My.Settings.Save()
    End Sub

    Private Sub ddpTimer_Tick(sender As Object, e As EventArgs)
        'UpdateWLEDFromSliders_DDP()
    End Sub

    Private Sub btnApplyCustomEffect_Click(sender As Object, e As EventArgs) Handles btnApplyCustomEffect.Click
        HandleApplyCustomEffectClick()
    End Sub


    Private Sub EffectColor1_Click(sender As Object, e As EventArgs) Handles EffectColor1.Click
        EffectColor1.BackColor = GetColorByColorWheel()
        My.Settings.CustomEffectC1 = EffectColor1.BackColor.ToArgb()
        My.Settings.Save()
    End Sub

    Private Sub EffectColor2_Click(sender As Object, e As EventArgs) Handles EffectColor2.Click
        EffectColor2.BackColor = GetColorByColorWheel()
        My.Settings.CustomEffectC2 = EffectColor2.BackColor.ToArgb()
        My.Settings.Save()
    End Sub

    Private Sub EffectColor3_Click(sender As Object, e As EventArgs) Handles EffectColor3.Click
        EffectColor3.BackColor = GetColorByColorWheel()
        My.Settings.CustomEffectC3 = EffectColor3.BackColor.ToArgb()
        My.Settings.Save()
    End Sub

    Private Sub EffectColor4_Click(sender As Object, e As EventArgs) Handles EffectColor4.Click
        EffectColor4.BackColor = GetColorByColorWheel()
        My.Settings.CustomEffectC4 = EffectColor4.BackColor.ToArgb()
        My.Settings.Save()
    End Sub

    Private Sub EffectColor5_Click(sender As Object, e As EventArgs) Handles EffectColor5.Click
        EffectColor5.BackColor = GetColorByColorWheel()
        My.Settings.CustomEffectC5 = EffectColor5.BackColor.ToArgb()
        My.Settings.Save()
    End Sub

    Private Sub btnDevicesRefreshIPs_Click(sender As Object, e As EventArgs) Handles btnDevicesRefreshIPs.Click
        RefreshIPAddresses(DG_Devices)
    End Sub

    Private Sub btnGroupsAutoSplit_Click(sender As Object, e As EventArgs) Handles btnGroupsAutoSplit.Click
        SplitIntoGroups(DG_Devices, DG_Groups)
        PopulateTreeView(DG_Groups, tvGroupsSelected)
        ClearGroupsToBlack()
    End Sub

    Private Sub tbEffectSpeed_Scroll(sender As Object, e As EventArgs) Handles tbEffectSpeed.Scroll
        My.Settings.CustomEffectSpeed = tbEffectSpeed.Value
        My.Settings.Save()
    End Sub

    Private Sub tbEffectIntensity_Scroll(sender As Object, e As EventArgs) Handles tbEffectIntensity.Scroll
        My.Settings.CustomEffectIntensity = tbEffectIntensity.Value
        My.Settings.Save()
    End Sub

    Private Sub tbEffectBrightness_Scroll(sender As Object, e As EventArgs) Handles tbEffectBrightnessBaseline.Scroll
        My.Settings.CustomEffectBrightness = tbEffectBrightnessBaseline.Value
        My.Settings.Save()
    End Sub

    Private Sub ddpTimer_Tick_1(sender As Object, e As EventArgs) Handles ddpTimer.Tick
        HandleDDPTimer_Tick()
    End Sub

    Private Sub btnStartEffectPreview_Click(sender As Object, e As EventArgs) Handles btnStartEffectPreview.Click
        ' Start voor alle groepen die frames hebben
        For Each row As DataGridViewRow In DG_Groups.Rows.Cast(Of DataGridViewRow)()
            If Not row.IsNewRow Then
                Dim frames = TryCast(row.Cells("colAllFrames").Value, List(Of Byte()))
                If frames IsNot Nothing AndAlso frames.Count > 0 Then
                    Dim groupId = CInt(row.Cells("colGroupId").Value)
                    DDP.StartGroupStream(groupId)
                End If
            End If
        Next
    End Sub

    Private Sub btnStopEffectPreview_Click(sender As Object, e As EventArgs) Handles btnStopEffectPreview.Click
        ' Stop voor álle actieve groep-streamers
        For Each row As DataGridViewRow In DG_Groups.Rows.Cast(Of DataGridViewRow)()
            If Not row.IsNewRow Then
                Dim frames = TryCast(row.Cells("colAllFrames").Value, List(Of Byte()))
                If frames IsNot Nothing AndAlso frames.Count > 0 Then
                    Dim groupId = CInt(row.Cells("colGroupId").Value)
                    DDP.StopGroupStream(groupId)
                End If
            End If
        Next
    End Sub

    Private Sub tbEffectDuration_Scroll(sender As Object, e As EventArgs) Handles tbEffectDuration.Scroll
        My.Settings.CustomEffectDuration = tbEffectDuration.Value
        My.Settings.Save()
    End Sub

    Private Sub btnGroupDMXSlider_Click(sender As Object, e As EventArgs) Handles btnGroupDMXSlider.Click

        If (DG_Groups.CurrentRow Is Nothing) Then
            ToonFlashBericht("Selecteer eerst een groep in de tabel.", 2)
            Return
        End If

        CurrentDeviceId = -1
        CurrentGroupId = DG_Groups.CurrentRow.Cells("colGroupId").Value
        GenerateSlidersForSelectedGroup(DG_Groups.CurrentRow, SplitContainer_Devices.Panel2)
    End Sub

    Private Sub stageTimer_Tick(sender As Object, e As EventArgs) Handles stageTimer.Tick
        Try
            ' Dim huidigeHash As ULong = 0UL
            'Const prime As ULong = 31UL

            ' Bepaal hash op basis van alle DDP-data
            'For Each row As DataGridViewRow In DG_Devices.Rows
            '    If row.IsNewRow Then Continue For
            '    Dim buf = TryCast(row.Cells("colDDPData").Value, Byte())
            '    If buf IsNot Nothing Then
            '        For i = 0 To buf.Length - 1
            '            huidigeHash = ((huidigeHash * prime) Xor buf(i))
            '        Next
            '    End If
            'Next

            ' Alleen tekenen bij verandering
            'If huidigeHash <> laatsteDDPHash Then
            Stage.TekenPodium(pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
            '    laatsteDDPHash = huidigeHash
            'End If

        Catch ex As Exception
            Debug.WriteLine("[stageTimer_Tick] Fout: " & ex.Message)
        End Try
    End Sub

    Private Sub pb_Stage_Resize(sender As Object, e As EventArgs) Handles pb_Stage.Resize
        GenereerLedLijst(DG_Devices, pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
    End Sub

    Private Sub tbEffectBrightnessBaselineEffect_Scroll(sender As Object, e As EventArgs) Handles tbEffectBrightnessEffect.Scroll
        My.Settings.CustomEffectBrightnessEffect = tbEffectBrightnessEffect.Value
        My.Settings.Save()
    End Sub

    Private Sub tbEffectDispersion_Scroll(sender As Object, e As EventArgs) Handles tbEffectDispersion.Scroll
        My.Settings.CustomEffectDispersion = tbEffectDispersion.Value
        My.Settings.Save()

    End Sub

    Private Sub btnResetEffect_Click(sender As Object, e As EventArgs) Handles btnResetEffect.Click
        ResetGroupsEffects()
        ClearGroupsToBlack()
    End Sub
End Class