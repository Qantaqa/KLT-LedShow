Imports System.Drawing
Imports System.Windows.Forms


Partial Public Module CustomEffects

    ' ***************************************************************************************
    ' ICEBERG HIT EFFECT
    ' Knippert van kleur1 naar kleur5, daarna blijft wit
    Public Sub CompileCustomEffect_IcebergHit(groupIds As List(Of Integer), Params As EffectParams)
        ' Setup
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

        ' Frame parameters
        Dim hitFrames = Params.Duration * Params.FPS  ' total frames for hit effect
        Dim holdSeconds = 5                            ' hold white duration
        Dim holdFrames = holdSeconds * Params.FPS

        ' Colors
        Dim col1 = Params.Kleuren(0)
        Dim col5 = If(Params.Kleuren.Length >= 5, Params.Kleuren(4), Color.White)
        Dim white = Color.White

        ' Brightness
        Dim baseB = Params.Brightness_Baseline
        Dim effB = Params.Brightness_Effect

        Dim rnd As New Random()
        Dim globalFrames As New List(Of Byte())

        ' Hit flash: alternate between col1 and col5
        For f = 0 To hitFrames - 1
            Dim buf(totalLEDs * 3 - 1) As Byte
            Dim t = (f Mod 2)
            Dim c As Color = If(t = 0, col1, col5)
            For i = 0 To totalLEDs - 1
                buf(i * 3) = CByte(c.R * effB)
                buf(i * 3 + 1) = CByte(c.G * effB)
                buf(i * 3 + 2) = CByte(c.B * effB)
            Next
            globalFrames.Add(buf)
        Next

        ' Hold white
        For h = 1 To holdFrames
            Dim buf(totalLEDs * 3 - 1) As Byte
            For i = 0 To totalLEDs - 1
                buf(i * 3) = CByte(white.R * effB)
                buf(i * 3 + 1) = CByte(white.G * effB)
                buf(i * 3 + 2) = CByte(white.B * effB)
            Next
            globalFrames.Add(buf)
        Next

        ' Distribute to groups
        Dim offset = 0
        For gi = 0 To groupIds.Count - 1
            Dim count = groupLengths(gi)
            Dim subset = globalFrames.Select(Function(b) b.Skip(offset * 3).Take(count * 3).ToArray()).ToList()
            Dim row = FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)() _
                .First(Function(r) CInt(r.Cells("colGroupId").Value) = groupIds(gi))
            row.Cells("colAllFrames").Value = subset
            row.Cells("colActiveFrame").Value = 0
            row.Cells("colGroupRepeat").Value = False  ' no repeat
            offset += count
        Next

        ToonFlashBericht("IcebergHit: " & globalFrames.Count & " frames gecompileerd.", 2)
    End Sub
End Module
