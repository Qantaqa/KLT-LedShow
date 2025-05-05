Imports System.Collections.Generic
Imports System.Configuration
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Module Stage

    ' *********************************************************************************
    ' Structuur om de eigenschappen van een LED te bevatten met posities in mm
    ' *********************************************************************************
    Public Structure LedInfo
        Public DeviceNaam As String  ' Naam van het apparaat (WLED-instance naam)
        Public Xmm As Integer        ' X-positie in millimeters t.o.v. (0,0)
        Public Ymm As Integer        ' Y-positie in millimeters t.o.v. (0,0)
    End Structure
    Public LedLijst As New List(Of LedInfo)()

    ' *********************************************************************************
    ' GenereerLedLijst
    ' Genereert een lijst van LED-informatie (in mm) op basis van layoutstrings.
    ' *********************************************************************************
    Public Sub GenereerLedLijst(ByVal dgDevices As DataGridView, ByVal podiumBreedteinCm As Integer, ByVal podiumHoogteinCm As Integer)
        Dim ledsPerMeter As Integer = My.Settings.LedsPerMeter
        LedLijst.Clear()

        ' Stapgrootte in mm per LED
        Dim stepMm As Single = 1000.0F / ledsPerMeter

        For Each row As DataGridViewRow In dgDevices.Rows
            If row.IsNewRow Then Continue For
            Dim deviceNaam As String = TryCast(row.Cells("colInstance").Value, String)
            Dim rawLayout As String = TryCast(row.Cells("colLayout").Value, String)
            If String.IsNullOrEmpty(deviceNaam) OrElse String.IsNullOrEmpty(rawLayout) Then Continue For

            ' Valideer en splits de layoutstring
            Dim layoutString = ValidateLayoutString(rawLayout)
            Dim segments() As String = layoutString.Split(","c)

            Dim currXmm As Integer = 0
            Dim currYmm As Integer = 0
            Dim totalLedInStrip As Integer = 0

            For Each seg In segments
                Dim s = seg.Trim().ToUpper()
                If s.Length < 2 Then Continue For

                ' Reset coördinaten: Xnn of Ynn (in cm) => omzetten naar mm
                If s.StartsWith("X") Then
                    Dim valCm As Integer
                    If Integer.TryParse(s.Substring(1), valCm) Then
                        currXmm = valCm * 10
                    End If
                    Continue For
                ElseIf s.StartsWith("Y") Then
                    Dim valCm As Integer
                    If Integer.TryParse(s.Substring(1), valCm) Then
                        currYmm = valCm * 10
                    End If
                    Continue For
                End If

                ' Bepaal lengte (aantal leds) en richtingen
                Dim numStr = String.Concat(s.Where(AddressOf Char.IsDigit))
                Dim aantalleds As Integer
                Integer.TryParse(numStr, aantalleds)
                Dim dirStr = String.Concat(s.Where(AddressOf Char.IsLetter))

                ' Bereken vector in mm
                Dim dxMm As Single = 0.0F, dyMm As Single = 0.0F

                Select Case dirStr
                    Case "U" : dyMm = stepMm
                    Case "D" : dyMm = -stepMm
                    Case "L" : dxMm = -stepMm
                    Case "R" : dxMm = stepMm
                    Case "UL" : dxMm = -stepMm / Math.Sqrt(2)
                        dyMm = stepMm / Math.Sqrt(2)
                    Case "UR" : dxMm = stepMm / Math.Sqrt(2)
                        dyMm = stepMm / Math.Sqrt(2)
                    Case "DL" : dxMm = -stepMm / Math.Sqrt(2)
                        dyMm = -stepMm / Math.Sqrt(2)
                    Case "DR" : dxMm = stepMm / Math.Sqrt(2)
                        dyMm = -stepMm / Math.Sqrt(2)
                End Select

                ' Voeg voor elk LED stap in mm toe
                For i As Integer = 1 To aantalleds
                    LedLijst.Add(New LedInfo With {.DeviceNaam = deviceNaam, .Xmm = CInt(currXmm), .Ymm = CInt(currYmm)})
                    currXmm += CInt(dxMm)
                    currYmm += CInt(dyMm)
                    totalLedInStrip += 1
                Next
            Next

            ' Werk teller bij in grid
            row.Cells("colLedCount").Value = totalLedInStrip
        Next

        ' (optioneel) sorteer op Xmm en dan Ymm
        LedLijst.Sort(Function(a, b)
                          If a.Xmm = b.Xmm Then Return a.Ymm.CompareTo(b.Ymm)
                          Return a.Xmm.CompareTo(b.Xmm)
                      End Function)
    End Sub

    ' *********************************************************************************
    ' TekenPodium
    ' Teken het podium in cm schaal: lijst Xmm/Ymm wordt omgezet naar px
    ' *********************************************************************************
    Public Sub TekenPodium(ByVal pbStage As PictureBox, ByVal podiumBreedteCm As Integer, ByVal podiumHoogteinCm As Integer)
        ' Omzetten cm naar mm
        Dim podiumBreedteMm As Integer = podiumBreedteCm * 10
        Dim podiumHoogteMm As Integer = podiumHoogteinCm * 10

        ' Bereken tekengebied (met marges voor labels)
        Dim wPx = pbStage.ClientSize.Width
        Dim hPx = pbStage.ClientSize.Height
        Dim marginLeft As Integer = 50, marginRight As Integer = 20, marginTop As Integer = 20, marginBottom As Integer = 40
        Dim drawWidth = wPx - marginLeft - marginRight
        Dim drawHeight = hPx - marginTop - marginBottom

        ' Pixel per mm (zodat het volledige podium in beeld past)
        Dim pxPerMm As Single = Math.Min(drawWidth / podiumBreedteMm, drawHeight / podiumHoogteMm)

        ' Assenpunten
        Dim axisX As Integer = marginLeft
        Dim axisY As Integer = marginTop + drawHeight

        ' Voor LED-squares
        Dim ledPixelSize As Integer = 2
        Using bmp As New Bitmap(wPx, hPx),
              g As Graphics = Graphics.FromImage(bmp),
              grayPen As New Pen(Color.Gray),
              brushRed As New SolidBrush(Color.Red)

            g.Clear(Color.Black)
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            ' 2) teken assen
            g.DrawLine(grayPen, axisX, marginTop, axisX, axisY) ' Y-as
            g.DrawLine(grayPen, axisX, axisY, axisX + podiumBreedteMm * pxPerMm, axisY) ' X-as

            ' 3) ticks en labels
            Dim font As Font = pbStage.Font
            ' op X-as iedere 10cm
            For cmMark As Integer = 0 To podiumBreedteCm Step 10
                Dim xPos As Integer = axisX + CInt(cmMark * 10 * pxPerMm)
                Dim tickH As Integer = If(cmMark Mod 100 = 0, 10, If(cmMark Mod 50 = 0, 7, 4))
                g.DrawLine(grayPen, xPos, axisY, xPos, axisY + tickH)
                If cmMark Mod 100 = 0 Then
                    Dim label = (cmMark / 100).ToString("0") & "m"
                    Dim size = g.MeasureString(label, font)
                    g.DrawString(label, font, Brushes.White, xPos - size.Width / 2, axisY + tickH)
                End If
            Next
            ' op Y-as iedere 10cm
            For cmMark As Integer = 0 To podiumHoogteinCm Step 10
                Dim yPos As Integer = axisY - CInt(cmMark * 10 * pxPerMm)
                Dim tickW As Integer = If(cmMark Mod 100 = 0, 10, If(cmMark Mod 50 = 0, 7, 4))
                g.DrawLine(grayPen, axisX - tickW, yPos, axisX, yPos)
                If cmMark Mod 100 = 0 Then
                    Dim label = (cmMark / 100).ToString("0") & "m"
                    Dim size = g.MeasureString(label, font)
                    g.DrawString(label, font, Brushes.White, axisX - tickW - size.Width, yPos - size.Height / 2)
                End If
            Next

            ' 4) teken LEDs als 2x2 squares met border
            For Each led In LedLijst
                Dim xC As Integer = axisX + CInt(led.Xmm * pxPerMm)
                Dim yC As Integer = axisY - CInt(led.Ymm * pxPerMm)
                ' teken border
                g.DrawRectangle(grayPen, xC - 1, yC - 1, ledPixelSize + 1, ledPixelSize + 1)
                ' teken fill
                g.FillRectangle(brushRed, xC, yC, ledPixelSize, ledPixelSize)
            Next

            ' toon
            pbStage.Image = CType(bmp.Clone(), Bitmap)
        End Using
        pbStage.Invalidate()
    End Sub

    ' *********************************************************************************
    ' VervangRichtingDoorPijlen en ValidateLayoutString ongewijzigd
    ' *********************************************************************************
    Public Function VervangRichtingDoorPijlen(ByVal layoutString As String) As String
        If String.IsNullOrEmpty(layoutString) Then Return layoutString
        Dim s = layoutString.ToUpper()
        Return s
    End Function

    Public Function ValidateLayoutString(ByVal layoutString As String) As String
        If String.IsNullOrEmpty(layoutString) Then Return layoutString
        Dim allowedLetters = "UDLRXY"
        Dim digits = "0123456789"
        Return String.Concat(layoutString.ToUpper().Where(Function(c)
                                                              Return allowedLetters.Contains(c) OrElse digits.Contains(c) OrElse c = ","
                                                          End Function))
    End Function

End Module
