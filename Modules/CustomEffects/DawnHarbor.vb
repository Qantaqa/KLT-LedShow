Imports System.Drawing
Imports System.Windows.Forms


Partial Public Module CustomEffects
    Public Sub CompileCustomEffect_DawnHarbor(groupIds As List(Of Integer), Params As EffectParams)
        ' Progress popup
        Dim estimatedSteps = groupIds.Count * Params.FPS * Params.Duration
        Dim dlg As New Form() With {
        .Text = "Compiling DawnHarbor...",
        .FormBorderStyle = FormBorderStyle.FixedDialog,
        .ControlBox = False,
        .StartPosition = FormStartPosition.CenterParent,
        .Width = 300,
        .Height = 80
    }
        Dim pb As New ProgressBar() With {
        .Minimum = 0,
        .Maximum = estimatedSteps,
        .Dock = DockStyle.Fill
    }
        dlg.Controls.Add(pb)
        dlg.Show(FrmMain)
        Dim stepCount As Integer = 0

        For Each grpId As Integer In groupIds
            ' Bepaal groep en coords
            Dim row = FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)() _
            .First(Function(r) CInt(r.Cells("colGroupId").Value) = grpId)
            Dim fixture = CStr(row.Cells("colGroupFixture").Value)
            Dim startLed = CInt(row.Cells("colGroupStartLedNr").Value)
            Dim stopLed = CInt(row.Cells("colGroupStopLedNr").Value)
            Dim devRow = FrmMain.DG_Devices.Rows.Cast(Of DataGridViewRow)() _
            .First(Function(r) CStr(r.Cells("colInstance").Value) = fixture)
            Dim allCoords = ParseLayout(CStr(devRow.Cells("colLayout").Value))
            Dim grpCoords = allCoords.Where(Function(c) c.Index + 1 >= startLed AndAlso c.Index + 1 <= stopLed).ToList()
            ' Frames count
            Dim rawCount = Params.Duration * Params.FPS
            Dim ledCount = grpCoords.Count
            Dim minFrames = Math.Max(15, CInt(ledCount * Params.Intensity))
            Dim maxFrames = Math.Min(60, rawCount)
            Dim frameCount = Math.Min(maxFrames, Math.Max(minFrames, rawCount))
            ' Prepare selectors...
            Dim sorted = SortByDirection(grpCoords, Params.Direction)
            Dim total = sorted.Count
            Dim startIndex As Integer = If(Params.StartPostion = EffectStartPosition.Center, total \ 2, If({EffectStartPosition.Top, EffectStartPosition.TopLeft, EffectStartPosition.TopRight, EffectStartPosition.Left}.Contains(Params.StartPostion), 0, total - 1))
            Dim stepDir = If(startIndex = 0, 1, -1)
            Dim pixelSelector = Function(f As Integer) If(frameCount <= 1, startIndex, Math.Max(0, Math.Min(total - 1, startIndex + stepDir * CInt((f / CSng(frameCount - 1)) * (total - 1)))))
            Dim colorSelector = Function(p As Single) InterpolateColors(Params.Kleuren, p)
            Dim intensityFn = Function(dist As Integer, tot As Integer) If(tot <= 0 OrElse Params.Intensity <= 0F, Params.Brightness_Baseline, Math.Max(0F, 1.0F - (dist / (tot * Params.Intensity))) * Params.Brightness_Baseline)
            ' Generate frames
            Dim frames = GenerateEffectFrames(frameCount, total, pixelSelector, colorSelector, intensityFn)
            If Not Params.Repeat Then frames.Add(frames.Last())
            ' Save
            row.Cells("colAllFrames").Value = frames
            row.Cells("colActiveFrame").Value = 0
            row.Cells("colGroupRepeat").Value = Params.Repeat
            ' Update progress
            stepCount += frameCount
            pb.Value = Math.Min(pb.Maximum, stepCount)
            Application.DoEvents()
        Next
        dlg.Close()
        ToonFlashBericht($"DawnHarbor: {estimatedSteps} stappen voltooid.", 2)
    End Sub


End Module
