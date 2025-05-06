Imports System.Drawing
Imports System.Windows.Forms


Partial Public Module CustomEffects

    ' ***************************************************************************************
    ' ICEBERG WARNING EFFECT
    ' ***************************************************************************************
    Public Sub CompileCustomEffect_Iceberg(groupIds As List(Of Integer), Params As EffectParams)
        ' Iceberg Warning: compile effect frames using growth + impact phases
        ' Collect LED coordinates and determine group lengths
        Dim allCoords As New List(Of LedCoord)
        Dim groupLengths As New List(Of Integer)
        For Each grpId In groupIds
            Dim row = FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)() _
            .First(Function(r) CInt(r.Cells("colGroupId").Value) = grpId)
            Dim fixture = CStr(row.Cells("colGroupFixture").Value)
            Dim startLed = CInt(row.Cells("colGroupStartLedNr").Value)
            Dim stopLed = CInt(row.Cells("colGroupStopLedNr").Value)
            Dim devRow = FrmMain.DG_Devices.Rows.Cast(Of DataGridViewRow)() _
            .First(Function(r) CStr(r.Cells("colInstance").Value) = fixture)
            Dim coords = ParseLayout(CStr(devRow.Cells("colLayout").Value)) _
                       .Where(Function(c) c.Index + 1 >= startLed AndAlso c.Index + 1 <= stopLed) _
                       .ToList()
            allCoords.AddRange(coords)
            groupLengths.Add(coords.Count)
        Next
        Dim totalLEDs = allCoords.Count

        ' Timing
        Dim totalFrames = Params.Duration * Params.FPS
        Dim growthFrames = CInt(totalFrames * 0.8F)
        Dim impactFrames = totalFrames - growthFrames

        ' Parameter fractions
        Dim baseB = Params.Brightness_Baseline
        Dim effB = Params.Brightness_Effect
        Dim intensityFrac = Params.Intensity
        Dim dispFrac = Params.Dispersion

        ' Colors
        Dim col1 = Params.Kleuren(0)
        Dim col2 = Params.Kleuren(1)
        Dim col3 = Params.Kleuren(2)
        Dim col4 = Params.Kleuren(3)
        Dim rnd As New Random()

        Dim globalFrames As New List(Of Byte())

        ' Growth phase: contour expands from center
        For f = 0 To growthFrames - 1
            Dim phase = f / CSng(growthFrames - 1)
            Dim sizeFactor = phase * intensityFrac
            Dim buf(totalLEDs * 3 - 1) As Byte
            For i = 0 To totalLEDs - 1
                ' baseline
                buf(i * 3) = CByte(col1.R * baseB)
                buf(i * 3 + 1) = CByte(col1.G * baseB)
                buf(i * 3 + 2) = CByte(col1.B * baseB)
                ' distance fraction from center
                Dim distFrac = Math.Abs(i - totalLEDs \ 2) / CSng(totalLEDs \ 2)
                If distFrac <= sizeFactor Then
                    ' interpolate contour color
                    Dim c = InterpolateColors(New Color() {col1, col2}, phase)
                    ' brightness interpolation
                    Dim bright = baseB + (effB - baseB) * phase
                    ' dispersion falloff
                    bright *= 1 - dispFrac * distFrac
                    buf(i * 3) = CByte(c.R * bright)
                    buf(i * 3 + 1) = CByte(c.G * bright)
                    buf(i * 3 + 2) = CByte(c.B * bright)
                End If
            Next
            globalFrames.Add(buf)
        Next

        ' Impact phase: quick twinkle bursts
        For f = 0 To impactFrames - 1
            Dim lastBuf = globalFrames.Last()
            Dim buf = CType(lastBuf.Clone(), Byte())
            Dim twinkleProb = intensityFrac * dispFrac
            ' speed mapping: 1=fast(0 delay),0=slow(max half-second)
            Dim speedMs = (1 - Params.Speed) * 500
            Dim interval = Math.Max(1, CInt(Params.FPS * speedMs / 1000))
            For i = 0 To totalLEDs - 1
                If rnd.NextDouble() < twinkleProb Then
                    If (f Mod interval) < (interval \ 2) Then
                        buf(i * 3) = CByte(col3.R * effB)
                        buf(i * 3 + 1) = CByte(col3.G * effB)
                        buf(i * 3 + 2) = CByte(col3.B * effB)
                    Else
                        ' revert to growth contour color
                        buf(i * 3) = CByte(col2.R * effB)
                        buf(i * 3 + 1) = CByte(col2.G * effB)
                        buf(i * 3 + 2) = CByte(col2.B * effB)
                    End If
                End If
            Next
            globalFrames.Add(buf)
        Next

        ' hold last frame if not repeating
        If Not Params.Repeat Then globalFrames.Add(globalFrames.Last())

        ' distribute frames to groups
        Dim offset = 0
        For gi = 0 To groupIds.Count - 1
            Dim count = groupLengths(gi)
            Dim subset = globalFrames.Select(Function(b) b.Skip(offset * 3).Take(count * 3).ToArray()).ToList()
            Dim row = FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)() _
            .First(Function(r) CInt(r.Cells("colGroupId").Value) = groupIds(gi))
            row.Cells("colAllFrames").Value = subset
            row.Cells("colActiveFrame").Value = 0
            row.Cells("colGroupRepeat").Value = Params.Repeat
            offset += count
        Next

        ToonFlashBericht("Iceberg Warning: " & globalFrames.Count & " frames gecompileerd.", 2)
    End Sub
End Module