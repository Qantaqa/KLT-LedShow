Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Module Stage
    ' *********************************************************************************
    ' Structuur om de eigenschappen van een LED te bevatten,
    ' inclusief layout-coördinaten (mm), pixel-coördinaten (px) en index in device.
    ' *********************************************************************************
    Public Structure LedInfo
        Public DeviceNaam As String   ' WLED-instance naam
        Public IndexInDevice As Integer ' Zero-based position in the device strip
        Public Xmm As Double          ' X in mm on stage
        Public Ymm As Double          ' Y in mm on stage
        Public Xpx As Integer         ' Precomputed X coordinate in pixels
        Public Ypx As Integer         ' Precomputed Y coordinate in pixels
    End Structure
    Public LedLijst As New List(Of LedInfo)()

    ' *********************************************************************************
    ' GenereerLedLijst
    ' - Parseert layoutstrings, bouwt LedLijst met mm-posities en device-index
    ' - Berekent eenmalig pixel-coördinaten (Xpx,Ypx) op basis van PictureBox en stage dims
    ' *********************************************************************************
    Public Sub GenereerLedLijst(
            dgDevices As DataGridView,
            pbStage As PictureBox,
            podiumBreedteCm As Integer,
            podiumHoogteinCm As Integer)

        ' Zorg ervoor dat PB_Stage het juiste formaat heeft bij opstarten.
        pbStage.Refresh()
        Application.DoEvents()

        LedLijst.Clear()
        Dim ledsPerMeter = My.Settings.LedsPerMeter
        Dim stepMm = 1000.0F / ledsPerMeter

        ' Bereken schaal en offsets
        Dim wPx = pbStage.ClientSize.Width
        Dim hPx = pbStage.ClientSize.Height
        Dim mL = 50, mR = 20, mT = 20, mB = 40
        Dim drawW = wPx - mL - mR
        Dim drawH = hPx - mT - mB
        Dim bwMm = podiumBreedteCm * 10
        Dim bhMm = podiumHoogteinCm * 10
        Dim pxPerMm = Math.Min(drawW / bwMm, drawH / bhMm)
        Dim axisX = mL
        Dim axisY = mT + drawH

        ' Loop alle devices
        For Each row As DataGridViewRow In dgDevices.Rows
            If row.IsNewRow Then Continue For
            Dim deviceNaam = CStr(row.Cells("colInstance").Value)
            Dim rawLayout = CStr(row.Cells("colLayout").Value)
            If String.IsNullOrEmpty(deviceNaam) OrElse String.IsNullOrEmpty(rawLayout) Then Continue For

            ' Parse layoutstring
            Dim segments = ValidateLayoutString(rawLayout).Split(","c)
            Dim currXmm As Double = 0
            Dim currYmm As Double = 0
            Dim deviceIndex = 0

            For Each seg In segments
                Dim s = seg.Trim().ToUpper()
                If s.StartsWith("X") Then
                    ' Reset X coordinate in mm (value in cm from layout)
                    Dim cm As Double
                    If Double.TryParse(s.Substring(1), cm) Then currXmm = cm * 10
                    Continue For
                ElseIf s.StartsWith("Y") Then
                    ' Reset Y coordinate in mm (value in cm from layout)
                    Dim cmY As Double
                    If Double.TryParse(s.Substring(1), cmY) Then currYmm = cmY * 10
                    Continue For
                End If
                ' Aantal leds en richting
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

                ' Voeg leds toe
                For i = 1 To count
                    ' Bereken pixel-posities
                    Dim xpx = axisX + CInt(Math.Round(currXmm * pxPerMm))
                    Dim ypx = axisY - CInt(Math.Round(currYmm * pxPerMm))
                    ' Voeg LedInfo toe
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
            ' Update LED-count in grid
            row.Cells("colLedCount").Value = deviceIndex
        Next
    End Sub

    ' *********************************************************************************
    ' TekenPodium
    ' - Tekent achtergrond, assen, baseline en effect (via pixel-coördinaten uit LedInfo)
    ' *********************************************************************************
    Public Sub TekenPodium(
            pbStage As PictureBox,
            podiumBreedteCm As Integer,
            podiumHoogteinCm As Integer)

        ' Bouw kleurdata
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

        ' Maak bitmap
        Dim w = pbStage.ClientSize.Width, h = pbStage.ClientSize.Height
        Using bmp As New Bitmap(w, h, PixelFormat.Format24bppRgb)
            ' Achtergrond
            Using g = Graphics.FromImage(bmp) : g.Clear(Color.Black) : End Using
            ' Assen
            DrawAxes(bmp, podiumBreedteCm, podiumHoogteinCm, pbStage.Font)

            'Baseline:   grijs vlak
            DrawBaselinePixels(bmp)

            ' Effects: overschrijf waar nodig
            DrawEffectPixels(bmp, colorMap)

            pbStage.Image?.Dispose()
            pbStage.Image = CType(bmp.Clone(), Bitmap)
        End Using
        pbStage.Invalidate()
    End Sub

    ' *********************************************************************************
    ' Helper: teken assen met ticks en labels
    ' *********************************************************************************
    Private Sub DrawAxes(bmp As Bitmap, bwCm As Integer, bhCm As Integer, font As Font)
        ' Bereken marges en schaal
        Dim wPx = bmp.Width, hPx = bmp.Height
        Dim mL = 50, mR = 20, mT = 20, mB = 40
        Dim drawW = wPx - mL - mR, drawH = hPx - mT - mB
        Dim bwMm = bwCm * 10, bhMm = bhCm * 10
        Dim pxPerMm = Math.Min(drawW / bwMm, drawH / bhMm)
        Dim axisX = mL, axisY = mT + drawH

        Using g = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.None
            Using pen As New Pen(Color.Gray)
                g.DrawLine(pen, axisX, mT, axisX, axisY)                                         ' Y-as
                g.DrawLine(pen, axisX, axisY, axisX + CInt(Math.Round(bwMm * pxPerMm)), axisY)   ' X-as
            End Using
            Dim tickFont = New Font(font.FontFamily, font.Size - 2, FontStyle.Regular)
            Using brush As New SolidBrush(Color.Gray)
                ' X-as ticks/labels
                For cmMark = 0 To bwCm Step 10
                    Dim xPos = axisX + CInt(Math.Round(cmMark * 10 * pxPerMm))
                    Dim tickH = If(cmMark Mod 50 = 0, 10, 4)
                    g.DrawLine(Pens.Gray, xPos, axisY, xPos, axisY + tickH)
                    If cmMark Mod 50 = 0 Then
                        Dim lbl = (cmMark / 100.0).ToString("0.0") & "m"
                        Dim sz = g.MeasureString(lbl, tickFont)
                        g.DrawString(lbl, tickFont, brush, xPos - sz.Width / 2, axisY + tickH)
                    End If
                Next
                ' Y-as ticks/labels
                For cmMark = 0 To bhCm Step 10
                    Dim yPos = axisY - CInt(Math.Round(cmMark * 10 * pxPerMm))
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

    ' *********************************************************************************
    ' Helper: teken baseline pixels met LedInfo.Xpx/Ypx
    ' *********************************************************************************
    Private Sub DrawBaselinePixels(bmp As Bitmap)
        Const size As Integer = 2
        Dim gray As Color = Color.FromArgb(40, 40, 40)
        ' Lock full read/write to preserve existing axes
        Dim bmpData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat)
        Dim stride = bmpData.Stride, ptr = bmpData.Scan0
        Dim totalBytes As Long = CLng(stride) * bmp.Height
        Dim raw(CInt(totalBytes) - 1) As Byte
        ' Copy existing pixels (axes, background) into buffer
        System.Runtime.InteropServices.Marshal.Copy(ptr, raw, 0, raw.Length)

        ' Overlay baseline only (preserve axes)
        For Each led In LedLijst
            For dx = 0 To size - 1
                For dy = 0 To size - 1
                    Dim idx = (led.Ypx + dy) * stride + (led.Xpx + dx) * 3
                    raw(idx) = gray.B : raw(idx + 1) = gray.G : raw(idx + 2) = gray.R
                Next
            Next
        Next

        ' Write back modified buffer
        System.Runtime.InteropServices.Marshal.Copy(raw, 0, ptr, raw.Length)
        bmp.UnlockBits(bmpData)
    End Sub

    ' *********************************************************************************
    ' Helper: teken effect pixels via LedInfo.Xpx/Ypx en colorMap[IndexInDevice]
    ' *********************************************************************************
    Private Sub DrawEffectPixels(bmp As Bitmap, colorMap As Dictionary(Of String, List(Of Color)))
        Const size As Integer = 2
        Const threshold As Integer = 30
        Dim bmpData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat)
        Dim stride = bmpData.Stride, ptr = bmpData.Scan0
        Dim totalBytes As Long = CLng(stride) * bmp.Height
        Dim raw(CInt(totalBytes) - 1) As Byte
        System.Runtime.InteropServices.Marshal.Copy(ptr, raw, 0, raw.Length)
        For Each led In LedLijst
            Dim inst = led.DeviceNaam
            Dim idx = led.IndexInDevice
            If colorMap.ContainsKey(inst) AndAlso idx < colorMap(inst).Count Then
                Dim col = colorMap(inst)(idx)
                If CInt(col.R) + CInt(col.G) + CInt(col.B) >= threshold Then
                    For dx = 0 To size - 1
                        For dy = 0 To size - 1
                            Dim i = (led.Ypx + dy) * stride + (led.Xpx + dx) * 3
                            raw(i) = col.B : raw(i + 1) = col.G : raw(i + 2) = col.R
                        Next
                    Next
                End If
            End If
        Next
        System.Runtime.InteropServices.Marshal.Copy(raw, 0, ptr, raw.Length)
        bmp.UnlockBits(bmpData)
    End Sub

    ' *********************************************************************************
    ' ValidateLayoutString ongewijzigd
    ' *********************************************************************************
    Public Function ValidateLayoutString(layoutString As String) As String
        Dim allowed = "UDLRXY", digits = "0123456789"
        Return String.Concat(layoutString.ToUpper().Where(Function(c) allowed.Contains(c) OrElse digits.Contains(c) OrElse c = ","c))
    End Function
End Module
