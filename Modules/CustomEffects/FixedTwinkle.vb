Imports System.Drawing
Imports System.Windows.Forms


Partial Public Module CustomEffects
    ' ***************************************************************************************
    ' FIXED TWINKLE EFFECT
    ' ***************************************************************************************
    Public Sub CompileCustomEffect_FixedTwinkle(groupIds As List(Of Integer), Params As EffectParams)
        ' Progress dialog
        Dim estimatedSteps = groupIds.Count * Params.FPS * Params.Duration
        Dim dlg As New Form() With {
    .Text = "Compiling FixedTwinkle...",
    .FormBorderStyle = FormBorderStyle.FixedDialog,
    .ControlBox = False,
    .StartPosition = FormStartPosition.CenterParent,
    .Width = 300,
    .Height = 80
}
        Dim pb As New ProgressBar() With {.Minimum = 0, .Maximum = estimatedSteps, .Dock = DockStyle.Fill}
        dlg.Controls.Add(pb)
        dlg.Show(FrmMain)
        Dim stepCount As Integer = 0

        ' Collect all LED coords and group lengths
        Dim allCoords As New List(Of LedCoord)
        Dim groupLengths As New List(Of Integer)
        For Each grpId In groupIds
            Dim row = FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)().First(Function(r) CInt(r.Cells("colGroupId").Value) = grpId)
            Dim fixture = CStr(row.Cells("colGroupFixture").Value)
            Dim startLed = CInt(row.Cells("colGroupStartLedNr").Value)
            Dim stopLed = CInt(row.Cells("colGroupStopLedNr").Value)
            Dim devRow = FrmMain.DG_Devices.Rows.Cast(Of DataGridViewRow)().First(Function(r) CStr(r.Cells("colInstance").Value) = fixture)
            Dim coords = ParseLayout(CStr(devRow.Cells("colLayout").Value)).Where(Function(c) c.Index + 1 >= startLed AndAlso c.Index + 1 <= stopLed).ToList()
            allCoords.AddRange(coords)
            groupLengths.Add(coords.Count)
        Next
        Dim totalLeds = allCoords.Count

        ' Frame and probability settings
        Dim rawCount = Params.Duration * Params.FPS
        ' Probability per LED per frame: speed * intensity
        Dim prob As Single = Params.Speed * Params.Intensity

        ' Brightness factors
        Dim baseB = Params.Brightness_Baseline
        Dim effB = Params.Brightness_Effect

        ' Dispersion radius in number of LEDs
        Dim dispSteps = Math.Max(0, CInt(Params.Dispersion * totalLeds))

        Dim baseColor = Params.Kleuren(0)
        Dim twinkleColor = If(Params.Kleuren.Length >= 5, Params.Kleuren(4), baseColor)
        Dim rnd As New Random()

        ' Generate global frames buffer
        Dim globalFrames As New List(Of Byte())
        For f As Integer = 0 To rawCount - 1
            Dim buf(totalLeds * 3 - 1) As Byte
            For i As Integer = 0 To totalLeds - 1
                ' draw baseline
                buf(i * 3) = CByte(baseColor.R * baseB)
                buf(i * 3 + 1) = CByte(baseColor.G * baseB)
                buf(i * 3 + 2) = CByte(baseColor.B * baseB)
                ' random twinkle check
                If rnd.NextDouble() < prob Then
                    ' primary LED
                    buf(i * 3) = CByte(twinkleColor.R * effB)
                    buf(i * 3 + 1) = CByte(twinkleColor.G * effB)
                    buf(i * 3 + 2) = CByte(twinkleColor.B * effB)
                    ' dispersion around
                    For d As Integer = 1 To dispSteps
                        Dim factor = 1.0F - d / (dispSteps + 1)
                        For Each neigh In {i - d, i + d}
                            If neigh >= 0 AndAlso neigh < totalLeds Then
                                Dim idx = neigh * 3
                                buf(idx) = CByte(buf(idx) * (1 - factor) + twinkleColor.R * effB * factor)
                                buf(idx + 1) = CByte(buf(idx + 1) * (1 - factor) + twinkleColor.G * effB * factor)
                                buf(idx + 2) = CByte(buf(idx + 2) * (1 - factor) + twinkleColor.B * effB * factor)
                            End If
                        Next
                    Next
                End If
            Next
            globalFrames.Add(buf)
            ' progress update
            stepCount += 1
            pb.Value = Math.Min(pb.Maximum, stepCount)
            Application.DoEvents()
        Next
        ' add last frame if non-repeat
        If Not Params.Repeat AndAlso globalFrames.Count > 0 Then globalFrames.Add(globalFrames.Last())

        ' distribute frames per group
        Dim offset As Integer = 0
        For gi As Integer = 0 To groupIds.Count - 1
            Dim length = groupLengths(gi)
            Dim subset = globalFrames.Select(Function(b) b.Skip(offset * 3).Take(length * 3).ToArray()).ToList()
            Dim row = FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)().First(Function(r) CInt(r.Cells("colGroupId").Value) = groupIds(gi))
            row.Cells("colAllFrames").Value = subset
            row.Cells("colActiveFrame").Value = 0
            row.Cells("colGroupRepeat").Value = Params.Repeat
            offset += length
        Next

        dlg.Close()
        ToonFlashBericht("FixedTwinkle: " & globalFrames.Count & " frames gecompileerd.", 2)
    End Sub

End Module