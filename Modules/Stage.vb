Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

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

        For Each row As DataGridViewRow In dgDevices.Rows
            If row.IsNewRow Then Continue For
            Dim deviceNaam = CStr(row.Cells("colInstance").Value)
            Dim rawLayout = CStr(row.Cells("colLayout").Value)
            If String.IsNullOrEmpty(deviceNaam) OrElse String.IsNullOrEmpty(rawLayout) Then Continue For

            Dim segments = ValidateLayoutString(rawLayout).Split(","c)
            Dim currXmm As Double = 0, currYmm As Double = 0
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
                    Dim xpx = axisX + CInt(Math.Round(currXmm * pxPerMm))
                    Dim ypx = axisY - CInt(Math.Round(currYmm * pxPerMm))
                    LedLijst.Add(New LedInfo With {
                        .DeviceNaam = deviceNaam,
                        .IndexInDevice = deviceIndex,
                        .Xmm = currXmm,
                        .Ymm = currYmm,
                        .Xpx = xpx,
                        .Ypx = ypx
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

        ' Bouw kleurmap per device
        Dim colorMap As New Dictionary(Of String, List(Of Color))
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

        ' Maak bitmap en teken
        Dim w = pbStage.ClientSize.Width, h = pbStage.ClientSize.Height
        Using bmp As New Bitmap(w, h, PixelFormat.Format24bppRgb)
            Using g = Graphics.FromImage(bmp)
                g.Clear(Color.Black)
            End Using

            DrawAxes(bmp, podiumBreedteCm, podiumHoogteinCm, pbStage.Font)
            DrawBaselinePixels(bmp)
            DrawEffectPixels(bmp, colorMap)

            ' Geselecteerde LightSource marker
            If DrawSelectedMarker AndAlso SelectedLSIndex >= 0 Then
                Using g = Graphics.FromImage(bmp)
                    g.SmoothingMode = SmoothingMode.AntiAlias
                    Dim lsRow = FrmMain.DG_LightSources.Rows(SelectedLSIndex)
                    Dim xMm = CSng(lsRow.Cells("colLSPositionX").Value)
                    Dim yMm = CSng(lsRow.Cells("colLSPositionY").Value)
                    Dim pxPerMm = GetMmPerPixel(pbStage)
                    Dim xPx = MarginLeft + CInt(xMm * pxPerMm)
                    Dim yPx = MarginTop + DrawHeight - CInt(yMm * pxPerMm)

                    ' Marker-icoon (gevuld 50% in kleur1 + gele outline)
                    Dim c1 = CType(lsRow.Cells("colLSColor1").Tag, Color)
                    Dim fillBrush As New SolidBrush(Color.FromArgb(128, c1))
                    Dim outlinePen As New Pen(Color.Yellow, 2)
                    Dim sizePx = 12
                    Dim markerRect = New Rectangle(xPx - sizePx \ 2, yPx - sizePx \ 2, sizePx, sizePx)

                    g.FillEllipse(fillBrush, markerRect)
                    g.DrawEllipse(outlinePen, markerRect)

                    ' Richtingspijl
                    Dim dir = CStr(lsRow.Cells("colLSDirection").Value)
                    Dim arrow = DirectionVector(dir, sizePx)
                    arrow = New Point(arrow.X + xPx, arrow.Y + yPx)
                    Using penArr As New Pen(Color.Yellow, 2)
                        g.DrawLine(penArr, xPx, yPx, arrow.X, arrow.Y)
                    End Using
                End Using
            End If

            pbStage.Image?.Dispose()
            pbStage.Image = CType(bmp.Clone(), Bitmap)
        End Using
        pbStage.Invalidate()
    End Sub



    ''' <summary>
    ''' Teken assen met ticks en labels
    ''' </summary>
    Private Sub DrawAxes(bmp As Bitmap, bwCm As Integer, bhCm As Integer, font As Font)
        Dim wPx = bmp.Width, hPx = bmp.Height
        Dim mL = MarginLeft, mR = 20, mT = MarginTop, mB = 40
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

    ''' <summary>
    ''' Richtingsvector voor marker/pijl
    ''' </summary>
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
End Module
