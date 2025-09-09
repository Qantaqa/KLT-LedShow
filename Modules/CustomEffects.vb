Imports System.Drawing
Imports System.Windows.Forms

Partial Public Module CustomEffects
    ' ***************************************************************************************
    ' CUSTOM EFFECT LOCAL PARAMETERS STRUCT
    ' ***************************************************************************************
    Public Structure EffectParams
        Public EffectName As String
        Public Duration As Integer            ' in seconden
        Public FPS As Integer
        Public Intensity As Single
        Public Brightness_Baseline As Single
        Public Brightness_Effect As Single
        Public Dispersion As Single
        Public Speed As Single
        Public Kleuren As Color()
        Public Direction As EffectDirection
        Public StartPostion As EffectStartPosition
        Public Repeat As Boolean
    End Structure

    Public Structure LedCoord
        Public Property Index As Integer
        Public Property X As Integer
        Public Property Y As Integer
    End Structure

    Public Enum EffectDirection
        Up
        Down
        Left
        Right
        UpLeft
        UpRight
        DownLeft
        DownRight
    End Enum

    Public Enum EffectStartPosition
        TopLeft
        Top
        TopRight
        Right
        BottomRight
        Bottom
        BottomLeft
        Left
        Center
    End Enum

    ' ***************************************************************************************
    ' PARSE LAYOUT
    ' ***************************************************************************************
    Public Function ParseLayout(layoutString As String) As List(Of LedCoord)
        Dim coords As New List(Of LedCoord)()

        If String.IsNullOrWhiteSpace(layoutString) Then
            Return coords ' Lege lijst teruggeven als layout ontbreekt
        End If

        Dim tokens = layoutString.Split(","c).Select(Function(t) t.Trim().ToUpper()).ToArray()
        Dim x = 0, y = 0, idx = 0

        For Each token In tokens
            If token.StartsWith("X") Then
                Dim val = 0
                Integer.TryParse(New String(token.Skip(1).Where(AddressOf Char.IsDigit).ToArray()), val)
                x = val
            ElseIf token.StartsWith("Y") Then
                Dim val = 0
                Integer.TryParse(New String(token.Skip(1).Where(AddressOf Char.IsDigit).ToArray()), val)
                y = val
            ElseIf token.Length > 1 Then
                Dim letters = token.TakeWhile(AddressOf Char.IsLetter).ToArray()
                Dim dist = 0
                Integer.TryParse(New String(token.SkipWhile(AddressOf Char.IsLetter).ToArray()), dist)
                Dim stepX = 0, stepY = 0
                For Each c In letters
                    Select Case c
                        Case "U"c : stepY = -1
                        Case "D"c : stepY = 1
                        Case "L"c : stepX = -1
                        Case "R"c : stepX = 1
                    End Select
                Next
                For d = 1 To dist
                    coords.Add(New LedCoord With {.Index = idx, .X = x, .Y = y})
                    x += stepX : y += stepY : idx += 1
                Next
            End If
        Next

        Return coords
    End Function

    ' ***************************************************************************************
    ' SORTING & COLOR HELPERS
    ' ***************************************************************************************
    Private Function SortByDirection(leds As IEnumerable(Of LedCoord), dir As EffectDirection) As List(Of LedCoord)
        Select Case dir
            Case EffectDirection.Up : Return leds.OrderBy(Function(l) l.Y).ThenBy(Function(l) l.X).ToList()
            Case EffectDirection.Down : Return leds.OrderByDescending(Function(l) l.Y).ThenBy(Function(l) l.X).ToList()
            Case EffectDirection.Left : Return leds.OrderByDescending(Function(l) l.X).ThenBy(Function(l) l.Y).ToList()
            Case EffectDirection.Right : Return leds.OrderBy(Function(l) l.X).ThenBy(Function(l) l.Y).ToList()
            Case EffectDirection.UpLeft : Return leds.OrderBy(Function(l) l.Y - l.X).ToList()
            Case EffectDirection.UpRight : Return leds.OrderBy(Function(l) l.Y + l.X).ToList()
            Case EffectDirection.DownLeft : Return leds.OrderByDescending(Function(l) l.Y + l.X).ToList()
            Case EffectDirection.DownRight : Return leds.OrderByDescending(Function(l) l.Y - l.X).ToList()
            Case Else : Return leds.ToList()
        End Select
    End Function

    Private Function InterpolateColors(kleuren As Color(), pct As Single) As Color
        Try
            If kleuren Is Nothing OrElse kleuren.Length = 0 Then Return Color.Black
            If kleuren.Length = 1 Then Return kleuren(0)
            Dim segments = kleuren.Length - 1
            Dim clampedPct As Single = Math.Max(0F, Math.Min(pct, 1.0F))
            Dim pos As Single = clampedPct * segments
            Dim idx As Integer = CInt(Math.Floor(pos))
            If idx >= segments Then idx = segments - 1
            If idx < 0 Then idx = 0
            Dim t As Single = pos - idx
            Dim c1 As Color = kleuren(idx)
            Dim c2 As Color = kleuren(idx + 1)
            Return Color.FromArgb(
                CInt(Math.Round(c1.R + (c2.R - c1.R) * t)),
                CInt(Math.Round(c1.G + (c2.G - c1.G) * t)),
                CInt(Math.Round(c1.B + (c2.B - c1.B) * t))
            )
        Catch ex As OverflowException
            Return Color.Black
        End Try
    End Function

    ' ***************************************************************************************
    ' GENERIC EFFECT ENGINE
    ' ***************************************************************************************
    Public Function GenerateEffectFrames(
        frameCount As Integer,
        totalPixels As Integer,
        pixelSelector As Func(Of Integer, Integer),
        colorSelector As Func(Of Single, Color),
        intensityFunction As Func(Of Integer, Integer, Single)
    ) As List(Of Byte())
        Dim result As New List(Of Byte())
        For f = 0 To frameCount - 1
            Dim buf(totalPixels * 3 - 1) As Byte
            Dim pos = pixelSelector(f)
            For i = 0 To totalPixels - 1
                Dim dist = Math.Abs(i - pos)
                Dim factor = intensityFunction(dist, totalPixels)
                ' Clamp factor between 0 and 1
                If factor < 0F Then factor = 0F
                If factor > 1.0F Then factor = 1.0F
                Dim pct As Single = If(totalPixels > 1, i / CSng(totalPixels - 1), 0F)
                Dim col = colorSelector(pct)
                ' Bereken en clamping voor elke component met exception handling
                Dim rByte As Byte
                Dim gByte As Byte
                Dim bByte As Byte
                Try
                    Dim rawR = col.R * factor
                    If Double.IsNaN(rawR) Then rawR = 0
                    Dim tmpR = CInt(Math.Round(rawR))
                    tmpR = Math.Min(255, Math.Max(0, tmpR))
                    rByte = CByte(tmpR)
                Catch ex As OverflowException
                    rByte = 0
                End Try
                Try
                    Dim rawG = col.G * factor
                    If Double.IsNaN(rawG) Then rawG = 0
                    Dim tmpG = CInt(Math.Round(rawG))
                    tmpG = Math.Min(255, Math.Max(0, tmpG))
                    gByte = CByte(tmpG)
                Catch ex As OverflowException
                    gByte = 0
                End Try
                Try
                    Dim rawB = col.B * factor
                    If Double.IsNaN(rawB) Then rawB = 0
                    Dim tmpB = CInt(Math.Round(rawB))
                    tmpB = Math.Min(255, Math.Max(0, tmpB))
                    bByte = CByte(tmpB)
                Catch ex As OverflowException
                    bByte = 0
                End Try
                buf(i * 3) = rByte
                buf(i * 3 + 1) = gByte
                buf(i * 3 + 2) = bByte
            Next
            result.Add(buf)
        Next
        Return result
    End Function



    ' ***************************************************************************************
    ' CLEAR GROUPS TO BLACK
    ' ***************************************************************************************
    ''' <summary>
    ''' Zet alle LEDs van de opgegeven groepen direct op zwart.
    ''' </summary>
    Public Sub ClearGroupsToBlack_WithDDP()
        For Each row As DataGridViewRow In FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)()
            If row.IsNewRow Then Continue For
            Dim fixture = CStr(row.Cells("colGroupFixture").Value)
            Dim startLed = CInt(row.Cells("colGroupStartLedNr").Value) - 1 ' zero-based
            Dim stopLed = CInt(row.Cells("colGroupStopLedNr").Value) - 1  ' zero-based
            Dim count = stopLed - startLed + 1

            ' Vind devices voor deze fixture
            For Each devRow As DataGridViewRow In FrmMain.DG_Devices.Rows.Cast(Of DataGridViewRow)()
                If devRow.IsNewRow Then Continue For
                If CStr(devRow.Cells("colInstance").Value) <> fixture Then Continue For

                ' Lees bestaande data of maak nieuw buffer
                Dim existing = TryCast(devRow.Cells("colDDPData").Value, Byte())
                Dim length = If(existing?.Length, (stopLed + 1) * 3)
                Dim buf As Byte()
                If existing Is Nothing OrElse existing.Length < (stopLed + 1) * 3 Then
                    buf = New Byte((stopLed + 1) * 3 - 1) {}  ' zero-init
                    If existing IsNot Nothing Then Array.Copy(existing, buf, existing.Length)
                Else
                    buf = existing
                End If

                ' Overwrite segment met zeros (black)
                For i = startLed To stopLed
                    buf(i * 3) = 0
                    buf(i * 3 + 1) = 0
                    buf(i * 3 + 2) = 0
                Next

                devRow.Cells("colDDPData").Value = buf
                devRow.Cells("colDataProvider").Value = "Effects"
            Next
        Next
        ToonFlashBericht("Alle groepen op zwart gezet.", 2)
    End Sub

    Public Sub ResetGroupsEffects()
        For Each row As DataGridViewRow In FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)()
            If row.IsNewRow Then Continue For
            row.Cells("colAllFrames").Value = Nothing
            row.Cells("colActiveFrame").Value = 0
        Next
    End Sub

    Private Sub CollectCheckedNodes(node As TreeNode, list As List(Of Integer))
        If node.Checked Then
            Dim id As Integer
            If Integer.TryParse(node.Name, id) Then list.Add(id)
        End If
        For Each child As TreeNode In node.Nodes
            CollectCheckedNodes(child, list)
        Next
    End Sub

    ' ***************************************************************************************
    ' SELECTED EFFECT SETTINGS
    ' ***************************************************************************************
    Public Function GetSelectedEffectDirection(gb As GroupBox) As EffectDirection
        For Each ctl As Control In gb.Controls
            If TypeOf ctl Is RadioButton Then
                Dim rb = DirectCast(ctl, RadioButton)
                If rb.Checked Then
                    Dim enumName = rb.Name.Replace("EffectDirection", "")
                    Return CType([Enum].Parse(GetType(EffectDirection), enumName), EffectDirection)
                End If
            End If
        Next
        Return EffectDirection.Up
    End Function

    Public Function GetSelectedEffectStartPosition(gb As GroupBox) As EffectStartPosition
        For Each ctl As Control In gb.Controls
            If TypeOf ctl Is RadioButton Then
                Dim rb = DirectCast(ctl, RadioButton)
                If rb.Checked Then
                    Dim enumName = rb.Name.Replace("EffectStartPosition", "")
                    Return CType([Enum].Parse(GetType(EffectStartPosition), enumName), EffectStartPosition)
                End If
            End If
        Next
        Return EffectStartPosition.Center
    End Function

    Private Function GetVectorFromDirection(dir As EffectDirection) As PointF
        Select Case dir
            Case EffectDirection.Up : Return New PointF(0, -1)
            Case EffectDirection.Down : Return New PointF(0, 1)
            Case EffectDirection.Left : Return New PointF(-1, 0)
            Case EffectDirection.Right : Return New PointF(1, 0)
            Case EffectDirection.UpLeft : Return New PointF(-1, -1)
            Case EffectDirection.UpRight : Return New PointF(1, -1)
            Case EffectDirection.DownLeft : Return New PointF(-1, 1)
            Case EffectDirection.DownRight : Return New PointF(1, 1)
            Case Else : Return New PointF(0, -1)
        End Select
    End Function

    Private Function GetStartVector(pos As EffectStartPosition, coords As List(Of LedCoord)) As PointF
        Dim minX = coords.Min(Function(c) c.X)
        Dim maxX = coords.Max(Function(c) c.X)
        Dim minY = coords.Min(Function(c) c.Y)
        Dim maxY = coords.Max(Function(c) c.Y)
        Dim midX = (minX + maxX) \ 2
        Dim midY = (minY + maxY) \ 2

        Select Case pos
            Case EffectStartPosition.TopLeft : Return New PointF(minX, minY)
            Case EffectStartPosition.Top : Return New PointF(midX, minY)
            Case EffectStartPosition.TopRight : Return New PointF(maxX, minY)
            Case EffectStartPosition.Right : Return New PointF(maxX, midY)
            Case EffectStartPosition.BottomRight : Return New PointF(maxX, maxY)
            Case EffectStartPosition.Bottom : Return New PointF(midX, maxY)
            Case EffectStartPosition.BottomLeft : Return New PointF(minX, maxY)
            Case EffectStartPosition.Left : Return New PointF(minX, midY)
            Case EffectStartPosition.Center : Return New PointF(midX, midY)
            Case Else : Return New PointF(midX, maxY)
        End Select
    End Function


    Private Function ProjectOntoDirection(c As LedCoord, origin As PointF, dir As PointF) As Single
        Dim dx = c.X - origin.X
        Dim dy = c.Y - origin.Y
        Dim mag = Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y)
        If mag = 0 Then Return 0
        Return CSng((dx * dir.X + dy * dir.Y) / mag)
    End Function

    '' ***************************************************************************************
    '' BUTTON CLICK HANDLER
    ''***************************************************************************************
    'Public Sub HandleApplyCustomEffectClick()
    '    Dim tv = FrmMain.tvGroupsSelected
    '    Dim kleuren = {
    '        FrmMain.EffectColor1.BackColor,
    '        FrmMain.EffectColor2.BackColor,
    '        FrmMain.EffectColor3.BackColor,
    '        FrmMain.EffectColor4.BackColor,
    '        FrmMain.EffectColor5.BackColor
    '    }
    '    Dim direction = GetSelectedEffectDirection(FrmMain.gbEffectDirection)
    '    Dim position = GetSelectedEffectStartPosition(FrmMain.gbEffectsStartPosition)

    '    Dim groupIds As New List(Of Integer)
    '    For Each node As TreeNode In tv.Nodes
    '        CollectCheckedNodes(node, groupIds)
    '    Next
    '    If groupIds.Count = 0 Then
    '        ToonFlashBericht("Selecteer minstens één groep.", 2)
    '        Return
    '    End If

    '    ' Haal volledige tekst en split op '-' voor effectnaam
    '    Dim fullText = FrmMain.cbListCustomEffects.Text
    '    Dim effectName = fullText.Split("-"c)(0).Trim()

    '    Dim Params As New EffectParams With {
    '        .EffectName = effectName,
    '        .Duration = FrmMain.tbEffectDuration.Value,
    '        .FPS = FrmMain.tbEffectFPS.Value,
    '        .Intensity = FrmMain.tbEffectIntensity.Value / 100.0F,
    '        .Brightness_Baseline = FrmMain.tbEffectBrightnessBaseline.Value / 100.0F,
    '        .Brightness_Effect = FrmMain.tbEffectBrightnessEffect.Value / 100.0F,
    '        .Speed = FrmMain.tbEffectSpeed.Value / 100.0F,
    '        .Dispersion = FrmMain.tbEffectDispersion.Value / 100.0F,
    '        .Kleuren = kleuren,
    '        .Direction = direction,
    '        .StartPostion = position,
    '        .Repeat = FrmMain.cbEffectRepeat.Checked
    '    }

    '    Select Case Params.EffectName
    '        Case "DawnHarbor"
    '            CompileCustomEffect_DawnHarbor(groupIds, Params)
    '        Case "FixedTwinkle"
    '            CompileCustomEffect_FixedTwinkle(groupIds, Params)
    '        Case "CalmOcean"
    '            CompileCustomEffect_CalmOcean(groupIds, Params)
    '        Case "Iceberg"
    '            CompileCustomEffect_Iceberg(groupIds, Params)
    '        Case "IcebergHit"
    '            CompileCustomEffect_IcebergHit(groupIds, Params)

    '    End Select
    'End Sub

End Module
