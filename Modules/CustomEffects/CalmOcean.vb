Imports System.Drawing
Imports System.Windows.Forms


Partial Public Module CustomEffects
    Public Sub CompileCustomEffect_CalmOcean(groupIds As List(Of Integer), Params As EffectParams)
        ' 1. Verzamel alle coördinaten en hun groepsinfo
        Dim allEntries As New List(Of (Coord As LedCoord, GroupId As Integer, GroupIndex As Integer))()
        Dim groupRows As New Dictionary(Of Integer, DataGridViewRow)

        For Each grpId In groupIds
            Dim row = FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)().
            FirstOrDefault(Function(r) CInt(r.Cells("colGroupId").Value) = grpId)
            If row Is Nothing Then Continue For
            groupRows(grpId) = row

            Dim layoutStr = CStr(row.Cells("colGroupLayout").Value)
            Dim coords = ParseLayout(layoutStr)
            For i = 0 To coords.Count - 1
                allEntries.Add((coords(i), grpId, i))
            Next
        Next

        If allEntries.Count = 0 Then
            ToonFlashBericht("Geen coördinaten beschikbaar voor CalmOcean.", 3)
            Exit Sub
        End If

        ' 2. Richting en oorsprong bepalen
        Dim allCoords = allEntries.Select(Function(e) e.Coord).ToList()
        Dim dirVector = GetVectorFromDirection(Params.Direction)
        Dim origin = GetStartVector(Params.StartPostion, allCoords)

        ' 3. Projecteer alles
        Dim projected = allEntries.Select(Function(e) New With {
        .Coord = e.Coord,
        .GroupId = e.GroupId,
        .GroupIndex = e.GroupIndex,
        .Projection = ProjectOntoDirection(e.Coord, origin, dirVector)
    }).ToList()

        Dim minP = projected.Min(Function(p) p.Projection)
        Dim maxP = projected.Max(Function(p) p.Projection)
        Dim spanP = Math.Max(1.0F, maxP - minP)

        Dim normalized = projected.Select(Function(p) New With {
        p.GroupId,
        p.GroupIndex,
        .Pct = (p.Projection - minP) / spanP
    }).ToList()

        ' 4. Frames berekenen over alle LEDs
        Dim frameCount = Math.Max(15, Params.Duration * Params.FPS)
        Dim speedFactor = Math.Max(0.01F, Params.Intensity * 2)
        Dim groupMap = normalized.GroupBy(Function(p) p.GroupId).ToDictionary(Function(g) g.Key, Function(g) g.ToList())

        ' Vooruitgangsvenster
        Dim dlg As New Form() With {.Text = "Compiling CalmOcean...", .FormBorderStyle = FormBorderStyle.FixedDialog, .ControlBox = False, .StartPosition = FormStartPosition.CenterParent, .Width = 300, .Height = 80}
        Dim pb As New ProgressBar() With {.Minimum = 0, .Maximum = frameCount * groupMap.Count, .Dock = DockStyle.Fill}
        dlg.Controls.Add(pb)
        dlg.Show(FrmMain)

        ' 5. Per groep: eigen frames genereren gebaseerd op gedeeld patroon
        For Each grpId In groupMap.Keys
            Dim ledList = groupMap(grpId).OrderBy(Function(p) p.GroupIndex).ToList()
            Dim frames As New List(Of Byte())

            For f = 0 To frameCount - 1
                Dim buf(ledList.Count * 3 - 1) As Byte

                For i = 0 To ledList.Count - 1
                    Dim pct = ledList(i).Pct
                    Dim phase = pct * 2 * Math.PI - f * speedFactor
                    Dim wave = (Math.Sin(phase) + 1.0F) / 2.0F
                    wave = Math.Pow(wave, 2.2)
                    wave *= Params.Intensity * Params.Brightness_Baseline
                    wave = Math.Min(1.0F, Math.Max(0.0F, wave))

                    Dim col = InterpolateColors(Params.Kleuren, pct)
                    buf(i * 3) = CByte(col.R * wave)
                    buf(i * 3 + 1) = CByte(col.G * wave)
                    buf(i * 3 + 2) = CByte(col.B * wave)
                Next

                frames.Add(buf)
                pb.Value = Math.Min(pb.Maximum, pb.Value + 1)
                Application.DoEvents()
            Next

            If Not Params.Repeat Then frames.Add(frames.Last())

            Dim row = groupRows(grpId)
            row.Cells("colAllFrames").Value = frames
            row.Cells("colActiveFrame").Value = 0
            row.Cells("colGroupRepeat").Value = Params.Repeat
        Next

        dlg.Close()
        ToonFlashBericht($"CalmOcean: {groupMap.Count} groep(en), {frameCount} frames gegenereerd.", 2)
    End Sub



End Module
