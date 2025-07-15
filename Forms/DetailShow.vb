﻿Public Class DetailShow
    Public Property RowData As Dictionary(Of String, Object)

    Public Sub New(rowData As Dictionary(Of String, Object))
        InitializeComponent()
        Me.RowData = rowData
        PopulatePulldownLists()
        InitializeFieldsFromRowData()
    End Sub

    Private Sub InitializeFieldsFromRowData()
        On Error Resume Next
        If RowData.ContainsKey("colAct") Then cbAct.Text = RowData("colAct").ToString()
        If RowData.ContainsKey("colSceneID") Then tbScene.Text = RowData("colSceneID").ToString()
        If RowData.ContainsKey("colEventId") Then tbEvent.Text = RowData("colEventId").ToString()
        If RowData.ContainsKey("colTimer") Then tbTimer.Text = RowData("colTimer").ToString()
        If RowData.ContainsKey("colCue") Then tbCue.Text = RowData("colCue").ToString()
        If RowData.ContainsKey("colFixture") Then cbDevice.Text = RowData("colFixture").ToString()
        If RowData.ContainsKey("colStateOnOff") Then cbPower.Checked = Convert.ToBoolean(RowData("colStateOnOff"))
        If RowData.ContainsKey("colEffect") Then cbEffect.Text = RowData("colEffect").ToString()
        If RowData.ContainsKey("colPalette") Then cbPalette.Text = RowData("colPalette").ToString()
        If RowData.ContainsKey("colColor1") Then btnColor1.BackColor = ColorTranslator.FromHtml(RowData("colColor1").ToString())
        If RowData.ContainsKey("colColor2") Then btnColor2.BackColor = ColorTranslator.FromHtml(RowData("colColor2").ToString())
        If RowData.ContainsKey("colColor3") Then btnColor3.BackColor = ColorTranslator.FromHtml(RowData("colColor3").ToString())
        If RowData.ContainsKey("colBrightness") Then tbBrightness.Value = Convert.ToInt32(RowData("colBrightness"))
        If RowData.ContainsKey("colSpeed") Then tbSpeed.Value = Convert.ToInt32(RowData("colSpeed"))
        If RowData.ContainsKey("colIntensity") Then tbIntensity.Value = Convert.ToInt32(RowData("colIntensity"))
        If RowData.ContainsKey("colTransition") Then tbTransition.Value = Convert.ToInt32(RowData("colTransition"))
        If RowData.ContainsKey("colBlend") Then cbBlend.Checked = Convert.ToBoolean(RowData("colBlend"))
        If RowData.ContainsKey("colRepeat") Then cbRepeat.Checked = Convert.ToBoolean(RowData("colRepeat"))
        If RowData.ContainsKey("colMicrophone") Then cbSound.Checked = Convert.ToBoolean(RowData("colMicrophone"))
        If RowData.ContainsKey("colFilename") Then tbFilename.Text = RowData("colFilename").ToString()
    End Sub

    Private Sub PopulatePulldownLists()
        ' Access the main form instance
        Dim mainForm As FrmMain = CType(Application.OpenForms("FrmMain"), FrmMain)
        If mainForm Is Nothing Then Return

        ' --- Effects ---
        cbEffect.Items.Clear()
        For Each row As DataGridViewRow In mainForm.DG_Effecten.Rows
            If row.IsNewRow Then Continue For
            Dim effectName = TryCast(row.Cells(0).Value, String)
            If Not String.IsNullOrEmpty(effectName) Then
                cbEffect.Items.Add(effectName)
            End If
        Next

        ' --- Palettes ---
        cbPalette.Items.Clear()
        For Each row As DataGridViewRow In mainForm.DG_Paletten.Rows
            If row.IsNewRow Then Continue For
            Dim paletteName = TryCast(row.Cells(0).Value, String)
            If Not String.IsNullOrEmpty(paletteName) Then
                cbPalette.Items.Add(paletteName)
            End If
        Next

        ' --- Devices (Fixtures) from DG_Groups ---
        cbDevice.Items.Clear()
        ' Add fixed video outputs first
        cbDevice.Items.Add("** Video **/ Output 1")
        cbDevice.Items.Add("** Video **/ Output 2")
        cbDevice.Items.Add("** Video **/ Output 3")
        For Each row As DataGridViewRow In mainForm.DG_Groups.Rows
            If row.IsNewRow Then Continue For
            Dim device = TryCast(row.Cells("colGroupFixture").Value, String)
            Dim groupNumber = TryCast(row.Cells("colGroupSegment").Value, Object)
            If Not String.IsNullOrEmpty(device) Then
                Dim groupStr = If(groupNumber IsNot Nothing, groupNumber.ToString(), "").Trim()
                If groupStr <> "" Then
                    cbDevice.Items.Add($"{device}/{groupStr}")
                Else
                    cbDevice.Items.Add(device)
                End If
            End If
        Next
    End Sub

    ' Call this when OK is pressed
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        UpdateRowDataFromFields()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub UpdateRowDataFromFields()
        RowData("colAct") = cbAct.Text
        RowData("colSceneID") = tbScene.Text
        RowData("colEventId") = tbEvent.Text
        RowData("colTimer") = tbTimer.Text
        RowData("colCue") = tbCue.Text
        RowData("colFixture") = cbDevice.Text
        RowData("colStateOnOff") = cbPower.Checked
        RowData("colEffect") = cbEffect.Text
        RowData("colPalette") = cbPalette.Text
        RowData("colColor1") = ColorTranslator.ToHtml(btnColor1.BackColor)
        RowData("colColor2") = ColorTranslator.ToHtml(btnColor2.BackColor)
        RowData("colColor3") = ColorTranslator.ToHtml(btnColor3.BackColor)
        RowData("colBrightness") = tbBrightness.Value
        RowData("colSpeed") = tbSpeed.Value
        RowData("colIntensity") = tbIntensity.Value
        RowData("colTransition") = tbTransition.Value
        RowData("colBlend") = cbBlend.Checked
        RowData("colRepeat") = cbRepeat.Checked
        RowData("colMicrophone") = cbSound.Checked
        RowData("colFilename") = tbFilename.Text

        ' Lookup EffectId from DG_Effecten
        Dim mainForm As FrmMain = CType(Application.OpenForms("FrmMain"), FrmMain)
        If mainForm IsNot Nothing Then
            RowData("colEffectId") = Nothing
            For Each row As DataGridViewRow In mainForm.DG_Effecten.Rows
                If row.IsNewRow Then Continue For
                If String.Equals(CStr(row.Cells(0).Value), cbEffect.Text, StringComparison.OrdinalIgnoreCase) Then
                    RowData("colEffectId") = row.Cells(1).Value
                    Exit For
                End If
            Next

            ' Lookup PaletteId from DG_Paletten
            RowData("colPaletteId") = Nothing
            For Each row As DataGridViewRow In mainForm.DG_Paletten.Rows
                If row.IsNewRow Then Continue For
                If String.Equals(CStr(row.Cells(0).Value), cbPalette.Text, StringComparison.OrdinalIgnoreCase) Then
                    RowData("colPaletteId") = row.Cells(1).Value
                    Exit For
                End If
            Next
        End If
    End Sub

    ' Call this when Cancel is pressed

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SendPreviewIfAuto()
        If cbAutoPreview IsNot Nothing AndAlso cbAutoPreview.Checked Then
            UpdateRowDataFromFields()
            btnPreview_Click(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnColor1_Click(sender As Object, e As EventArgs) Handles btnColor1.Click
        Using dlg As New ColorDialog()
            dlg.Color = btnColor1.BackColor
            If dlg.ShowDialog() = DialogResult.OK Then
                btnColor1.BackColor = dlg.Color
                SendPreviewIfAuto()
            End If
        End Using
    End Sub

    Private Sub btnColor2_Click(sender As Object, e As EventArgs) Handles btnColor2.Click
        Using dlg As New ColorDialog()
            dlg.Color = btnColor2.BackColor
            If dlg.ShowDialog() = DialogResult.OK Then
                btnColor2.BackColor = dlg.Color
                SendPreviewIfAuto()
            End If
        End Using
    End Sub

    Private Sub btnColor3_Click(sender As Object, e As EventArgs) Handles btnColor3.Click
        Using dlg As New ColorDialog()
            dlg.Color = btnColor3.BackColor
            If dlg.ShowDialog() = DialogResult.OK Then
                btnColor3.BackColor = dlg.Color
                SendPreviewIfAuto()
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using dlg As New OpenFileDialog()
            dlg.Title = "Select Movie File"
            dlg.Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv|All Files|*.*"
            dlg.CheckFileExists = True
            dlg.CheckPathExists = True
            If dlg.ShowDialog() = DialogResult.OK Then
                tbFilename.Text = dlg.FileName
            End If
        End Using
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        UpdateRowDataFromFields()
        Dim mainForm As FrmMain = CType(Application.OpenForms("FrmMain"), FrmMain)
        If mainForm Is Nothing Then Return

        Dim fixtureValue = If(RowData.ContainsKey("colFixture"), RowData("colFixture"), Nothing)
        If fixtureValue Is Nothing OrElse fixtureValue.ToString().Trim() = "" Then Return

        Dim fixtureParts = fixtureValue.ToString().Split("/"c)
        If fixtureParts.Length = 2 Then
            ' Device with segment: normal behavior
            WLEDControl.Apply_RowData_ToWLED(RowData, mainForm.DG_Devices, mainForm.DG_Effecten, mainForm.DG_Paletten)
            ToonFlashBericht("Preview sent to device.", 2)
        ElseIf fixtureParts.Length = 1 Then
            ' Device without segment: apply to all segments
            Dim wledName = fixtureParts(0).Trim()
            ' Find the device row
            Dim devRow As DataGridViewRow = Nothing
            For Each row As DataGridViewRow In mainForm.DG_Devices.Rows
                If row.IsNewRow Then Continue For
                If String.Equals(CStr(row.Cells("colInstance").Value), wledName, StringComparison.OrdinalIgnoreCase) Then
                    devRow = row
                    Exit For
                End If
            Next
            If devRow Is Nothing Then Return

            ' Get segments from colSegments (format: "(0-49),(50-99)", etc.)
            Dim segmentsStr = CStr(devRow.Cells("colSegments").Value)
            If String.IsNullOrWhiteSpace(segmentsStr) Then Return

            Dim segmentMatches = System.Text.RegularExpressions.Regex.Matches(segmentsStr, "\((\d+)-(\d+)\)")
            Dim segmentIndex As Integer = 0
            For Each m As System.Text.RegularExpressions.Match In segmentMatches
                ' For each segment, set RowData("colFixture") to "DeviceName/SegmentIndex"
                Dim tempRowData = New Dictionary(Of String, Object)(RowData)
                tempRowData("colFixture") = wledName & "/" & segmentIndex.ToString()
                WLEDControl.Apply_RowData_ToWLED(tempRowData, mainForm.DG_Devices, mainForm.DG_Effecten, mainForm.DG_Paletten)
                segmentIndex += 1
            Next
            ToonFlashBericht("Preview sent to all segments of device.", 2)
        End If
    End Sub

    Private Sub cbPalette_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPalette.SelectedIndexChanged
        UpdatePalettePreviewImage()
        SendPreviewIfAuto()
    End Sub

    Private Sub cbPalette_TextChanged(sender As Object, e As EventArgs) Handles cbPalette.TextChanged
        UpdatePalettePreviewImage()
        SendPreviewIfAuto()
    End Sub

    Private Sub UpdatePalettePreviewImage()
        If pbPreviewPalette Is Nothing Then Return

        Dim paletteName As String = cbPalette.Text
        If String.IsNullOrWhiteSpace(paletteName) Then
            pbPreviewPalette.Image = Nothing
            Return
        End If

        ' Find the palette number (ID) for the selected palette
        Dim paletteId As String = ""
        Dim mainForm As FrmMain = TryCast(Application.OpenForms("FrmMain"), FrmMain)
        If mainForm IsNot Nothing Then
            For Each row As DataGridViewRow In mainForm.DG_Paletten.Rows
                If row.IsNewRow Then Continue For
                If String.Equals(CStr(row.Cells("PaletteName").Value), paletteName, StringComparison.OrdinalIgnoreCase) Then
                    paletteId = CStr(row.Cells("PaletteId").Value)
                    Exit For
                End If
            Next
        End If

        If String.IsNullOrWhiteSpace(paletteId) Then
            pbPreviewPalette.Image = Nothing
            Return
        End If

        Dim imagePath As String = System.IO.Path.Combine(My.Settings.PaletteImagesPath, $"PAL_{CInt(paletteId):D2}.gif")
        If System.IO.File.Exists(imagePath) Then
            Try
                ' Dispose previous image to avoid file lock
                If pbPreviewPalette.Image IsNot Nothing Then
                    pbPreviewPalette.Image.Dispose()
                    pbPreviewPalette.Image = Nothing
                End If
                pbPreviewPalette.Image = Image.FromFile(imagePath)
            Catch
                pbPreviewPalette.Image = Nothing
            End Try
        Else
            pbPreviewPalette.Image = Nothing
        End If
    End Sub

    Private Sub cbEffect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEffect.SelectedIndexChanged
        UpdateEffectPreviewImage()
        SendPreviewIfAuto()
    End Sub

    Private Sub cbEffect_TextChanged(sender As Object, e As EventArgs) Handles cbEffect.TextChanged
        UpdateEffectPreviewImage()
        SendPreviewIfAuto()
    End Sub

    Private Sub UpdateEffectPreviewImage()
        If pbPreviewEffect Is Nothing Then Return

        Dim effectName As String = cbEffect.Text
        If String.IsNullOrWhiteSpace(effectName) Then
            pbPreviewEffect.Image = Nothing
            Return
        End If

        ' Find the effect number (ID) for the selected effect
        Dim effectId As String = ""
        Dim mainForm As FrmMain = TryCast(Application.OpenForms("FrmMain"), FrmMain)
        If mainForm IsNot Nothing Then
            For Each row As DataGridViewRow In mainForm.DG_Effecten.Rows
                If row.IsNewRow Then Continue For
                If String.Equals(CStr(row.Cells(0).Value), effectName, StringComparison.OrdinalIgnoreCase) Then
                    effectId = CStr(row.Cells(1).Value)
                    Exit For
                End If
            Next
        End If

        If String.IsNullOrWhiteSpace(effectId) Then
            pbPreviewEffect.Image = Nothing
            Return
        End If

        Dim imagePath As String = System.IO.Path.Combine(My.Settings.EffectsImagePath, $"FX_{CInt(effectId):D3}.gif")
        If System.IO.File.Exists(imagePath) Then
            Try
                If pbPreviewEffect.Image IsNot Nothing Then
                    pbPreviewEffect.Image.Dispose()
                    pbPreviewEffect.Image = Nothing
                End If
                pbPreviewEffect.Image = Image.FromFile(imagePath)
            Catch
                pbPreviewEffect.Image = Nothing
            End Try
        Else
            pbPreviewEffect.Image = Nothing
        End If
    End Sub

    Private Sub tbIntensity_ValueChanged(sender As Object, e As EventArgs) Handles tbIntensity.ValueChanged
        txtIntensity.Text = tbIntensity.Value.ToString()
        SendPreviewIfAuto()
    End Sub

    Private Sub tbSpeed_ValueChanged(sender As Object, e As EventArgs) Handles tbSpeed.ValueChanged
        txtSpeed.Text = tbSpeed.Value.ToString()
        SendPreviewIfAuto()
    End Sub

    Private Sub tbTransition_ValueChanged(sender As Object, e As EventArgs) Handles tbTransition.ValueChanged
        txtTransition.Text = tbTransition.Value.ToString()
        SendPreviewIfAuto()
    End Sub

    Private Sub tbBrightness_ValueChanged(sender As Object, e As EventArgs) Handles tbBrightness.ValueChanged
        txtBrightness.Text = tbBrightness.Value.ToString()
        SendPreviewIfAuto()
    End Sub

    Private Sub txtIntensity_TextChanged(sender As Object, e As EventArgs) Handles txtIntensity.TextChanged
        Dim value As Integer
        If Integer.TryParse(txtIntensity.Text, value) Then
            value = Math.Max(tbIntensity.Minimum, Math.Min(tbIntensity.Maximum, value))
            tbIntensity.Value = value
        End If
    End Sub

    Private Sub txtSpeed_TextChanged(sender As Object, e As EventArgs) Handles txtSpeed.TextChanged
        Dim value As Integer
        If Integer.TryParse(txtSpeed.Text, value) Then
            value = Math.Max(tbSpeed.Minimum, Math.Min(tbSpeed.Maximum, value))
            tbSpeed.Value = value
        End If
    End Sub

    Private Sub txtTransition_TextChanged(sender As Object, e As EventArgs) Handles txtTransition.TextChanged
        Dim value As Integer
        If Integer.TryParse(txtTransition.Text, value) Then
            value = Math.Max(tbTransition.Minimum, Math.Min(tbTransition.Maximum, value))
            tbTransition.Value = value
        End If
    End Sub

    Private Sub txtBrightness_TextChanged(sender As Object, e As EventArgs) Handles txtBrightness.TextChanged
        Dim value As Integer
        If Integer.TryParse(txtBrightness.Text, value) Then
            value = Math.Max(tbBrightness.Minimum, Math.Min(tbBrightness.Maximum, value))
            tbBrightness.Value = value
        End If
    End Sub

    ' Shared buffer for copy/paste functionality
    Private Shared CopiedRowData As New Dictionary(Of String, Object)()

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        CopiedRowData.Clear()
        CopiedRowData("colEffect") = cbEffect.Text
        CopiedRowData("colPalette") = cbPalette.Text
        CopiedRowData("colStateOnOff") = cbPower.Checked
        CopiedRowData("colMicrophone") = cbSound.Checked
        CopiedRowData("colBlend") = cbBlend.Checked
        CopiedRowData("colBrightness") = tbBrightness.Value
        CopiedRowData("colIntensity") = tbIntensity.Value
        CopiedRowData("colSpeed") = tbSpeed.Value
        CopiedRowData("colTransition") = tbTransition.Value
        CopiedRowData("colColor1") = ColorTranslator.ToHtml(btnColor1.BackColor)
        CopiedRowData("colColor2") = ColorTranslator.ToHtml(btnColor2.BackColor)
        CopiedRowData("colColor3") = ColorTranslator.ToHtml(btnColor3.BackColor)

        ToonFlashBericht("Copied settings to clipboard.", 2)
    End Sub

    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        If CopiedRowData.Count = 0 Then Return

        If CopiedRowData.ContainsKey("colEffect") Then cbEffect.Text = CopiedRowData("colEffect").ToString()
        If CopiedRowData.ContainsKey("colPalette") Then cbPalette.Text = CopiedRowData("colPalette").ToString()
        If CopiedRowData.ContainsKey("colStateOnOff") Then cbPower.Checked = Convert.ToBoolean(CopiedRowData("colStateOnOff"))
        If CopiedRowData.ContainsKey("colMicrophone") Then cbSound.Checked = Convert.ToBoolean(CopiedRowData("colMicrophone"))
        If CopiedRowData.ContainsKey("colBlend") Then cbBlend.Checked = Convert.ToBoolean(CopiedRowData("colBlend"))
        If CopiedRowData.ContainsKey("colBrightness") Then tbBrightness.Value = Convert.ToInt32(CopiedRowData("colBrightness"))
        If CopiedRowData.ContainsKey("colIntensity") Then tbIntensity.Value = Convert.ToInt32(CopiedRowData("colIntensity"))
        If CopiedRowData.ContainsKey("colSpeed") Then tbSpeed.Value = Convert.ToInt32(CopiedRowData("colSpeed"))
        If CopiedRowData.ContainsKey("colTransition") Then tbTransition.Value = Convert.ToInt32(CopiedRowData("colTransition"))
        If CopiedRowData.ContainsKey("colColor1") Then btnColor1.BackColor = ColorTranslator.FromHtml(CopiedRowData("colColor1").ToString())
        If CopiedRowData.ContainsKey("colColor2") Then btnColor2.BackColor = ColorTranslator.FromHtml(CopiedRowData("colColor2").ToString())
        If CopiedRowData.ContainsKey("colColor3") Then btnColor3.BackColor = ColorTranslator.FromHtml(CopiedRowData("colColor3").ToString())
        ToonFlashBericht("Pasted settings from clipboard.", 2)
    End Sub


End Class