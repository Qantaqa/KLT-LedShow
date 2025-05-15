Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System

''' <summary>
''' Module om de LED-layout en effectvisualisatie op het podium weer te geven.
''' Bevat:
''' - Generatie van LedLijst met mm- en px-coördinaten
''' - Tekenen van podium: achtergrond, assen, baseline en effect-pixels
''' - Marker voor geselecteerde LightSource in pb_Stage
''' </summary>
Public Module Stage
    ' Marker flags voor geselecteerde LightSource
    Public DrawSelectedMarker As Boolean = False
    Public SelectedLSIndex As Integer = -1


    ' Structuur om LED-eigenschappen en positie bij te houden
    Public Structure LedInfo
        Public DeviceNaam As String       ' WLED-instance naam
        Public GroupId As String        ' Groep-ID (voor WLED)
        Public IndexInDevice As Integer   ' Zero-based index in device
        Public Xmm As Double              ' X-positie (mm) op podium
        Public Ymm As Double              ' Y-positie (mm) op podium
        Public Xpx As Integer             ' X-positie (px) in PictureBox
        Public Ypx As Integer             ' Y-positie (px) in PictureBox
    End Structure
    Public LedLijst As New List(Of LedInfo)()

    ''' <summary>
    ''' Bouwt LedLijst op basis van layout-strings in DG_Devices.
    ''' Berekent mm- en px-coördinaten.
    ''' </summary>
    Public Sub GenereerLedLijst(
            dgDevices As DataGridView,
            dgGroups As DataGridView,
            pbStage As PictureBox,
            podiumBreedteCm As Integer,
            podiumHoogteinCm As Integer)

        pbStage.Refresh()
        Application.DoEvents()


        LedLijst.Clear()
        Dim ledsPerMeter = My.Settings.LedsPerMeter
        Dim stepMm = 1000.0F / ledsPerMeter

        ' Schaal en marges
        Dim wPx = pbStage.ClientSize.Width
        Dim hPx = pbStage.ClientSize.Height
        Dim mL = MarginLeft, mR = 20, mT = MarginTop, mB = 40
        Dim drawW = wPx - mL - mR
        Dim drawH = hPx - mT - mB
        Dim bwMm = podiumBreedteCm * 10
        Dim bhMm = podiumHoogteinCm * 10
        Dim pxPerMm = Math.Min(drawW / bwMm, drawH / bhMm)
        Dim axisX = mL
        Dim axisY = mT + drawH

        If (dgGroups.Rows.Count = 0 Or dgDevices.Rows.Count = 0) Then
            Exit Sub
        End If

        ' 1) Bouw alvast een tijdelijke lijst van alle groepen
        Dim groepen As New List(Of (fixture As String, id As Integer, startIdx As Integer, stopIdx As Integer))
        For Each grRow As DataGridViewRow In FrmMain.DG_Groups.Rows
            If grRow.IsNewRow Then Continue For
            Dim fix = CStr(grRow.Cells("colGroupFixture").Value)
            Dim gid = CInt(grRow.Cells("colGroupId").Value)
            ' in de grid staan 1-based LED-nummers, maak zero-based
            Dim startLed = CInt(grRow.Cells("colGroupStartLedNr").Value) - 1
            Dim stopLed = CInt(grRow.Cells("colGroupStopLedNr").Value) - 1
            groepen.Add((fix, gid, startLed, stopLed))
        Next

        ' 2) Loop alle devices en bouw LedLijst
        For Each row As DataGridViewRow In dgDevices.Rows
            If row.IsNewRow Then Continue For
            Dim deviceNaam = CStr(row.Cells("colInstance").Value)
            Dim rawLayout = CStr(row.Cells("colLayout").Value)
            If String.IsNullOrEmpty(deviceNaam) OrElse String.IsNullOrEmpty(rawLayout) Then Continue For

            Dim segments = ValidateLayoutString(rawLayout).Split(","c)
            Dim currXmm As Double = 0
            Dim currYmm As Double = 0
            Dim deviceIndex As Integer = 0

            For Each seg In segments
                Dim s = seg.Trim().ToUpper()
                If s.StartsWith("X") Then
                    Dim cm As Double
                    If Double.TryParse(s.Substring(1), cm) Then currXmm = cm * 10
                    Continue For
                ElseIf s.StartsWith("Y") Then
                    Dim cmY As Double
                    If Double.TryParse(s.Substring(1), cmY) Then currYmm = cmY * 10
                    Continue For
                End If

                Dim count = Integer.Parse(New String(s.Where(AddressOf Char.IsDigit).ToArray()))
                Dim dir = New String(s.Where(AddressOf Char.IsLetter).ToArray())
                Dim dx = 0.0F, dy = 0.0F
                Select Case dir
                    Case "U" : dy = stepMm
                    Case "D" : dy = -stepMm
                    Case "L" : dx = -stepMm
                    Case "R" : dx = stepMm
                    Case "UL" : dx = -stepMm / Math.Sqrt(2) : dy = stepMm / Math.Sqrt(2)
                    Case "UR" : dx = stepMm / Math.Sqrt(2) : dy = stepMm / Math.Sqrt(2)
                    Case "DL" : dx = -stepMm / Math.Sqrt(2) : dy = -stepMm / Math.Sqrt(2)
                    Case "DR" : dx = stepMm / Math.Sqrt(2) : dy = -stepMm / Math.Sqrt(2)
                End Select

                For i = 1 To count
                    ' pixel-coördinaten
                    Dim xpx = axisX + CInt(Math.Round(currXmm * pxPerMm))
                    Dim ypx = axisY - CInt(Math.Round(currYmm * pxPerMm))

                    ' bepaal groepsIDs voor deze led
                    Dim gids As New List(Of Integer)
                    For Each g In groepen
                        If g.fixture = deviceNaam AndAlso
                           deviceIndex >= g.startIdx AndAlso deviceIndex <= g.stopIdx Then
                            gids.Add(g.id)
                        End If
                    Next

                    ' voeg toe aan LedLijst
                    LedLijst.Add(New LedInfo With {
                        .DeviceNaam = deviceNaam,
                        .IndexInDevice = deviceIndex,
                        .Xmm = currXmm,
                        .Ymm = currYmm,
                        .Xpx = xpx,
                        .Ypx = ypx,
                        .GroupId = String.Join(",", gids)
                    })

                    deviceIndex += 1
                    currXmm += dx
                    currYmm += dy
                Next
            Next

            ' Update aantal leds in grid
            row.Cells("colLedCount").Value = deviceIndex
        Next
    End Sub

    ''' <summary>
    ''' Tekent podium in PictureBox: achtergrond, assen, baseline en effect-pixels.
    ''' Indien DrawSelectedMarker, tekent ook marker voor geselecteerde LightSource.
    ''' </summary>
    Public Sub TekenPodium(
            pbStage As PictureBox,
            podiumBreedteCm As Integer,
            podiumHoogteinCm As Integer)

        ' 1) Bouw een kleurmap per device
        Dim colorMap As New Dictionary(Of String, List(Of Color))()
        For Each r As DataGridViewRow In FrmMain.DG_Devices.Rows
            If r.IsNewRow Then Continue For
            Dim inst = CStr(r.Cells("colInstance").Value)
            Dim data = TryCast(r.Cells("colDDPData").Value, Byte())
            Dim lst As New List(Of Color)
            If data IsNot Nothing AndAlso data.Length Mod 3 = 0 Then
                For i = 0 To data.Length \ 3 - 1
                    lst.Add(Color.FromArgb(data(i * 3), data(i * 3 + 1), data(i * 3 + 2)))
                Next
            End If
            colorMap(inst) = lst
        Next

        ' 2) Maak een bitmap waarin we alles tekenen
        Dim w = pbStage.ClientSize.Width
        Dim h = pbStage.ClientSize.Height
        Using bmp As New Bitmap(w, h, PixelFormat.Format24bppRgb)
            Using g = Graphics.FromImage(bmp)
                g.Clear(Color.Black)
            End Using

            ' 3) Teken de onderdelen
            DrawAxes(bmp, podiumBreedteCm, podiumHoogteinCm, pbStage.Font)
            DrawBaselinePixels(bmp)
            DrawEffectPixels(bmp, colorMap)

            ' 4) Indien gewenst: marker voor geselecteerde LightSource
            If DrawSelectedMarker AndAlso SelectedLSIndex >= 0 Then
                Using g = Graphics.FromImage(bmp)
                    g.SmoothingMode = SmoothingMode.AntiAlias

                    Dim lsRow = FrmMain.DG_LightSources.Rows(SelectedLSIndex)
                    Dim xCm = CDbl(lsRow.Cells("colLSPositionX").Value)     ' in cm
                    Dim xMm = xCm * 10                                      ' in mm
                    Dim yCm = CDbl(lsRow.Cells("colLSPositionY").Value)     ' in cm
                    Dim yMM = yCm * 10                                      ' in mm
                    Dim pxPerMm = GetMmPerPixel(pbStage)
                    Dim xPx = MarginLeft + CInt(xMm * pxPerMm)
                    Dim yPx = MarginTop + DrawHeight - CInt(yMM * pxPerMm)

                    ' **NIET MEER**: sizePx = 12  
                    Dim sizeCm = CDbl(lsRow.Cells("colLSSize").Value)       ' in cm
                    Dim sizeMm = sizeCm * 10                                ' in mm
                    Dim sizePx = CInt(sizeMm * pxPerMm)                     ' nu écht 1 mm → px

                    Dim shape = CStr(lsRow.Cells("colLSShape").Value)
                    Dim dir = CStr(lsRow.Cells("colLSDirection").Value)
                    Dim c1 = CType(lsRow.Cells("colLSColor1").Tag, Color)

                    Using fillBrush = New SolidBrush(Color.FromArgb(128, c1))
                        Using outlinePen = New Pen(Color.Yellow, 2)
                            DrawShapes(g, shape, xPx, yPx, sizePx, fillBrush, outlinePen, dir)
                        End Using
                    End Using


                End Using
            End If

            ' 5) Toon resultaat in PictureBox
            pbStage.Image?.Dispose()
            pbStage.Image = CType(bmp.Clone(), Bitmap)
        End Using

        pbStage.Invalidate()
    End Sub

    ''' <summary>
    ''' Teken in het beeld de “shape” (Circle, Square of Cone) 
    ''' op (xPx,yPx) met afmeting sizePx, met een gevulde brush en outline pen.
    ''' Voor de cone wordt de richting uit dir gebruikt.
    ''' </summary>
    Private Sub DrawShapes(
        g As Graphics,
        shape As String,
        xPx As Integer,
        yPx As Integer,
        sizePx As Integer,
        fillBrush As Brush,
        outlinePen As Pen,
        dir As String)

        Select Case shape
            Case "Circle"
                Dim r = sizePx \ 2
                Dim rectC = New Rectangle(xPx - r, yPx - r, sizePx, sizePx)
                g.FillEllipse(fillBrush, rectC)
                g.DrawEllipse(outlinePen, rectC)

            Case "Square"
                Dim r = sizePx \ 2
                Dim rectS = New Rectangle(xPx - r, yPx - r, sizePx, sizePx)
                g.FillRectangle(fillBrush, rectS)
                g.DrawRectangle(outlinePen, rectS)

            Case "Cone"
                ' apex-based cone met hoogte = sizePx
                Dim height = sizePx
                Dim halfBase = height * Math.Tan(Math.PI / 6)
                Dim ang As Double = 0
                Select Case dir
                    Case "Up" : ang = Math.PI / 2
                    Case "Down" : ang = 3 * Math.PI / 2
                    Case "Left" : ang = Math.PI
                    Case "Right" : ang = 0
                    Case "Left-Up" : ang = 3 * Math.PI / 4
                    Case "Right-Up" : ang = Math.PI / 4
                    Case "Left-Down" : ang = 5 * Math.PI / 4
                    Case "Right-Down" : ang = 7 * Math.PI / 4
                End Select
                Dim apex = New PointF(xPx, yPx)
                Dim bx = xPx + CInt(Math.Cos(ang) * height)
                Dim by = yPx - CInt(Math.Sin(ang) * height)
                Dim perp = ang + Math.PI / 2
                Dim p1 = New PointF(bx + CInt(halfBase * Math.Cos(perp)), by - CInt(halfBase * Math.Sin(perp)))
                Dim p2 = New PointF(bx - CInt(halfBase * Math.Cos(perp)), by + CInt(halfBase * Math.Sin(perp)))
                g.FillPolygon(fillBrush, {apex, p1, p2})
                g.DrawPolygon(outlinePen, {apex, p1, p2})

            Case Else
                ' fallback vierkant
                Dim r = sizePx \ 2
                Dim rectF = New Rectangle(xPx - r, yPx - r, sizePx, sizePx)
                g.FillRectangle(fillBrush, rectF)
                g.DrawRectangle(outlinePen, rectF)
        End Select

        ' altijd een klein geel stipje in het midden
        Using yellowBrush As New SolidBrush(Color.Yellow)
            g.FillEllipse(yellowBrush, xPx - 2, yPx - 2, 5, 5)
        End Using
    End Sub


    ''' <summary>
    ''' Teken assen met ticks en labels
    ''' </summary>
    Private Sub DrawAxes(bmp As Bitmap, bwCm As Integer, bhCm As Integer, font As Font)
        Dim wPx = bmp.Width, hPx = bmp.Height
        Dim mL = MarginLeft, mR = 20
        Dim mT = MarginTop, mB = 40
        Dim drawW = wPx - mL - mR, drawH = hPx - mT - mB
        Dim bwMm = bwCm * 10, bhMm = bhCm * 10
        Dim pxPerMm = Math.Min(drawW / bwMm, drawH / bhMm)
        Dim axisX = mL, axisY = mT + drawH

        Using g = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.None
            Using pen As New Pen(Color.Gray)
                g.DrawLine(pen, axisX, mT, axisX, axisY)
                g.DrawLine(pen, axisX, axisY, axisX + CInt(bwMm * pxPerMm), axisY)
            End Using
            Dim tickFont = New Font(font.FontFamily, font.Size - 2)
            Using brush As New SolidBrush(Color.Gray)
                For cmMark = 0 To bwCm Step 10
                    Dim xPos = axisX + CInt(cmMark * 10 * pxPerMm)
                    Dim tickH = If(cmMark Mod 50 = 0, 10, 4)
                    g.DrawLine(Pens.Gray, xPos, axisY, xPos, axisY + tickH)
                    If cmMark Mod 50 = 0 Then
                        Dim lbl = (cmMark / 100.0).ToString("0.0") & "m"
                        Dim sz = g.MeasureString(lbl, tickFont)
                        g.DrawString(lbl, tickFont, brush, xPos - sz.Width / 2, axisY + tickH)
                    End If
                Next
                For cmMark = 0 To bhCm Step 10
                    Dim yPos = axisY - CInt(cmMark * 10 * pxPerMm)
                    Dim tickW = If(cmMark Mod 50 = 0, 10, 4)
                    g.DrawLine(Pens.Gray, axisX - tickW, yPos, axisX, yPos)
                    If cmMark Mod 50 = 0 Then
                        Dim lbl = (cmMark / 100.0).ToString("0.0") & "m"
                        Dim sz = g.MeasureString(lbl, tickFont)
                        g.DrawString(lbl, tickFont, brush, axisX - tickW - sz.Width, yPos - sz.Height / 2)
                    End If
                Next
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Teken baseline-pixels
    ''' </summary>
    Private Sub DrawBaselinePixels(bmp As Bitmap)
        Const size As Integer = 2
        Dim gray = Color.FromArgb(40, 40, 40)
        Dim bmpData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat)
        Dim stride = bmpData.Stride, ptr = bmpData.Scan0
        Dim total = CLng(stride) * bmp.Height
        Dim raw(CInt(total) - 1) As Byte
        Marshal.Copy(ptr, raw, 0, raw.Length)
        For Each led In LedLijst
            For dx = 0 To size - 1
                For dy = 0 To size - 1
                    Dim idx = (led.Ypx + dy) * stride + (led.Xpx + dx) * 3
                    raw(idx) = gray.B : raw(idx + 1) = gray.G : raw(idx + 2) = gray.R
                Next
            Next
        Next
        Marshal.Copy(raw, 0, ptr, raw.Length)
        bmp.UnlockBits(bmpData)
    End Sub

    ''' <summary>
    ''' Teken effect-pixels
    ''' </summary>
    Private Sub DrawEffectPixels(bmp As Bitmap, colorMap As Dictionary(Of String, List(Of Color)))
        On Error Resume Next

        Const size As Integer = 2, threshold As Integer = 30
        Dim bmpData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat)
        Dim stride = bmpData.Stride, ptr = bmpData.Scan0
        Dim total = CLng(stride) * bmp.Height
        Dim raw(CInt(total) - 1) As Byte
        Marshal.Copy(ptr, raw, 0, raw.Length)
        For Each led In LedLijst
            Dim inst = led.DeviceNaam, idxLed = led.IndexInDevice
            If colorMap.ContainsKey(inst) AndAlso idxLed < colorMap(inst).Count Then
                Dim col = colorMap(inst)(idxLed)
                If col.R + col.G + col.B >= threshold Then
                    For dx = 0 To size - 1
                        For dy = 0 To size - 1
                            Dim idx = (led.Ypx + dy) * stride + (led.Xpx + dx) * 3
                            raw(idx) = col.B : raw(idx + 1) = col.G : raw(idx + 2) = col.R
                        Next
                    Next
                End If
            End If
        Next
        Marshal.Copy(raw, 0, ptr, raw.Length)
        bmp.UnlockBits(bmpData)
    End Sub

    ''' <summary>
    ''' Cleanup layout-string
    ''' </summary>
    Public Function ValidateLayoutString(layoutString As String) As String
        Dim allowed = "UDLRXY", digits = "0123456789"
        Return String.Concat(layoutString.ToUpper().Where(Function(c) allowed.Contains(c) OrElse digits.Contains(c) OrElse c = ","c))
    End Function

    Public ReadOnly Property MarginLeft As Integer
        Get
            Return 50
        End Get
    End Property
    Public ReadOnly Property MarginTop As Integer
        Get
            Return 20
        End Get
    End Property
    Public ReadOnly Property DrawHeight As Integer
        Get
            Return FrmMain.pb_Stage.ClientSize.Height - MarginTop - 40
        End Get
    End Property

    ''' <summary>
    ''' Bereken mm-per-pixel
    ''' </summary>
    Public Function GetMmPerPixel(pb As PictureBox) As Double
        Dim bwMm = My.Settings.PodiumBreedte * 10
        Return (pb.ClientSize.Width - MarginLeft - 20) / bwMm
    End Function

    Private Function DrawWidthPx(pb As PictureBox) As Double
        Return pb.ClientSize.Width - MarginLeft - 20
    End Function

    ''' Richtingsvector voor marker/pijl
    Public Function DirectionVector(dir As String, length As Integer) As Point
        Select Case dir
            Case "Up" : Return New Point(0, -length)
            Case "Down" : Return New Point(0, length)
            Case "Left" : Return New Point(-length, 0)
            Case "Right" : Return New Point(length, 0)
            Case "Left-Up" : Return New Point(-length, -length)
            Case "Right-Up" : Return New Point(length, -length)
            Case "Left-Down" : Return New Point(-length, length)
            Case "Right-Down" : Return New Point(length, length)
            Case Else : Return Point.Empty
        End Select
    End Function


    ''' Maakt het mogelijk om door op het podium te klikken
    ''' de positie van de geselecteerde LightSource bij te werken (in cm, afgerond).
    Public Sub OnStageClick(sender As Object, e As MouseEventArgs)
        ' Alleen als er een LS geselecteerd is
        If Not Stage.DrawSelectedMarker OrElse Stage.SelectedLSIndex < 0 Then
            Return
        End If

        ' Bereken mm-per-pixel
        Dim pxPerMm = Stage.GetMmPerPixel(FrmMain.pb_Stage)
        Dim mleft = Stage.MarginLeft
        Dim mtop = Stage.MarginTop
        Dim drawH = Stage.DrawHeight

        ' Muisklik omzetten naar mm
        Dim xMm = (e.X - mleft) / pxPerMm
        Dim yMm = (drawH - (e.Y - mtop)) / pxPerMm

        ' Omschakelen naar cm en afronden
        Dim xCm = CInt(Math.Round(xMm / 10.0))
        Dim yCm = CInt(Math.Round(yMm / 10.0))

        ' Clamp binnen podium-afmetingen
        Dim Breedte As Integer = My.Settings.PodiumBreedte
        Dim Hoogte As Integer = My.Settings.PodiumHoogte
        xCm = Math.Max(0, Math.Min(Breedte, xCm))
        yCm = Math.Max(0, Math.Min(Hoogte, yCm))

        ' Schrijf terug naar de DataGridView (in cm)
        Dim row = FrmMain.DG_LightSources.Rows(Stage.SelectedLSIndex)
        row.Cells("colLSPositionX").Value = xCm
        row.Cells("colLSPositionY").Value = yCm

        ' Herteken podium & timeline
        Stage.TekenPodium(FrmMain.pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
        EffectBuilder.RefreshTimeline()
    End Sub

End Module
