Imports System.Collections.Generic
Imports System.Configuration
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Module Stage

    ' *********************************************************************************
    ' Structuur om de eigenschappen van een LED te bevatten voor de layout
    ' *********************************************************************************
    Public Structure LedInfo
        Public DeviceNaam As String ' Naam van het apparaat (WLED-instance naam)
        Public X As Integer ' X-positie in de podiummatrix
        Public Y As Integer ' Y-positie in de podiummatrix
    End Structure
    Public LedLijst As New List(Of LedInfo)()


    ' *********************************************************************************
    ' GenereerLedLijst
    ' Genereert een lijst van LED-informatie op basis van de gegevens in de DataGridView.
    ' *********************************************************************************
    Public Sub GenereerLedLijst(ByVal dgDevices As DataGridView, ByVal podiumBreedteinCm As Integer, ByVal podiumHoogteinCm As Integer)
        Dim LedsPerMeter As Integer = My.Settings.LedsPerMeter
        ' Clear de lijst eerst
        LedLijst.Clear()

        ' Herbereken de podiumbreedte en hoogte naar aantal led
        Dim podiumBreedteMeters As Double = podiumBreedteinCm / 100
        Dim podiumHoogteMeters As Double = podiumHoogteinCm / 100

        Dim podiumBreedteLeds As Integer = CInt(Math.Ceiling(podiumBreedteMeters * LedsPerMeter))
        Dim podiumHoogteLeds As Integer = CInt(Math.Ceiling(podiumHoogteMeters * LedsPerMeter))

        ' Loop door alle rijen in de DataGridView met de WLED-apparaten.
        For Each row As DataGridViewRow In dgDevices.Rows
            If Not row.IsNewRow Then ' Zorg ervoor dat we geen nieuwe, lege rij verwerken.
                Dim deviceNaam As String = TryCast(row.Cells("colInstance").Value, String)
                Dim deviceIpAdres As String = TryCast(row.Cells("colIPAddress").Value, String)
                Dim layoutString As String = TryCast(row.Cells("colLayout").Value, String)
                Dim totalLedInStrip As Integer = 0

                If Not String.IsNullOrEmpty(deviceNaam) And Not String.IsNullOrEmpty(deviceIpAdres) Then
                    ' Parse de layout string.
                    Dim ledSegments() As String = layoutString.Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)
                    Dim segmentIndex As Integer = 0

                    Dim currentX As Integer = 0
                    Dim currentY As Integer = 0
                    Dim parsedXCm As Integer = 0 ' Opslag in cm.
                    Dim parsedYCm As Integer = 0

                    If ledSegments.Length > 0 Then
                        For i As Integer = 0 To ledSegments.Length - 1
                            Dim segment = ledSegments(i).Trim()
                            Dim directionChar As Char = Char.ToUpper(segment(0))
                            Dim ledsInSegment As Integer = 0

                            ' Controleer of de eerste character een X of Y is.
                            If directionChar = "X" OrElse directionChar = "Y" Then
                                ' Parse de coördinaat
                                If Integer.TryParse(segment.Substring(1), ledsInSegment) Then
                                    If directionChar = "X" Then
                                        parsedXCm = ledsInSegment
                                    Else
                                        parsedYCm = ledsInSegment
                                    End If
                                    ' Zet cm om naar LED index (aantal LEDs).
                                    currentX = CInt(Math.Round(parsedXCm * LedsPerMeter / 100.0))
                                    currentY = CInt(Math.Round(parsedYCm * LedsPerMeter / 100.0))
                                Else
                                    Debug.WriteLine($"Ongeldige X of Y waarde: {segment}")
                                End If
                            Else
                                ' Probeer de richting en lengte te parsen
                                directionChar = Char.ToUpper(segment(segment.Length - 1))
                                If Not Char.IsLetter(directionChar) Then
                                    directionChar = Char.ToUpper(segment(0))
                                End If
                                Dim numberString As String = ""
                                For Each c As Char In segment
                                    If Char.IsDigit(c) Then
                                        numberString += c
                                    End If
                                Next
                                If Not Integer.TryParse(numberString, ledsInSegment) Then
                                    Debug.WriteLine($"Ongeldige lengte waarde: {segment}")
                                    ledsInSegment = 0
                                End If

                                Dim directionX As Integer = 0
                                Dim directionY As Integer = 0
                                Select Case directionChar
                                    Case "U"
                                        directionX = 0
                                        directionY = 1
                                    Case "D"
                                        directionX = 0
                                        directionY = -1
                                    Case "L"
                                        directionX = -1
                                        directionY = 0
                                    Case "R"
                                        directionX = 1
                                        directionY = 0
                                    Case Else
                                        Debug.WriteLine($"Ongeldige richting karakter: {directionChar} in segment: {segment}")
                                        directionX = 0
                                        directionY = 0
                                End Select


                                For j As Integer = 0 To ledsInSegment - 1
                                    If LedLijst.Count < (podiumBreedteLeds * podiumHoogteLeds) Then
                                        Dim ledInfo As LedInfo
                                        ledInfo.DeviceNaam = deviceNaam
                                        ledInfo.X = currentX
                                        ledInfo.Y = currentY
                                        LedLijst.Add(ledInfo)


                                        ' Update de huidige positie
                                        currentX += directionX
                                        currentY += directionY

                                        totalLedInStrip += 1
                                    Else
                                        Exit For
                                    End If
                                Next
                            End If
                        Next
                    End If
                End If

                ' Update aantal leds in string
                FrmMain.DG_Devices.Rows(row.Index).Cells("colLedCount").Value = totalLedInStrip
            End If
        Next

        ' Sorteer de LedLijst op X, dan Y.  Dit is handig voor het tekenen van de matrix.
        LedLijst.Sort(Function(a, b)
                          If a.X = b.X Then
                              Return a.Y.CompareTo(b.Y)
                          Else
                              Return a.X.CompareTo(b.X)
                          End If
                      End Function)
    End Sub


    ' *********************************************************************************
    ' TekenPodium
    ' Teken het podium in de opgegeven PictureBox met de opgegeven breedte en hoogte.
    ' *********************************************************************************
    Public Sub TekenPodium(ByVal pbStage As PictureBox, ByVal podiumBreedteCm As Integer, ByVal podiumHoogteCm As Integer)
        ' Stel het aantal LEDs per meter vast.
        Dim ledsPerMeter As Integer = My.Settings.LedsPerMeter
        Dim cmPerMeter As Integer = 100

        ' Bereken de breedte en hoogte van het podium in LEDs.
        Dim podiumBreedteLeds As Integer = CInt(Math.Ceiling((podiumBreedteCm / cmPerMeter) * ledsPerMeter))
        Dim podiumHoogteLeds As Integer = CInt(Math.Ceiling((podiumHoogteCm / cmPerMeter) * ledsPerMeter))

        ' Bereken de pixelgrootte op basis van de PictureBox afmetingen en het aantal LEDs.
        Dim beschikbareBreedtePixels As Integer = FrmMain.TabShow.Width
        Dim beschikbareHoogtePixels As Integer = FrmMain.TabShow.Height - 25

        pbStage.Location = New Point(1, 25)
        pbStage.Size = New Size(beschikbareBreedtePixels, beschikbareHoogtePixels)


        Dim pixelBreedte As Single = Math.Floor(CSng(beschikbareBreedtePixels) / podiumBreedteLeds)
        Dim pixelHoogte As Single = Math.Floor(CSng(beschikbareHoogtePixels) / podiumHoogteLeds)


        Dim pixelGrootte As Integer = CInt(Math.Min(pixelBreedte, pixelHoogte)) ' Gebruik de kleinste van de twee om vervorming te voorkomen.
        If pixelGrootte < 1 Then
            pixelGrootte = 1
        End If

        ' Maak een nieuwe Bitmap waarop getekend kan worden.
        Dim stageBitmap As New Bitmap(beschikbareBreedtePixels, beschikbareHoogtePixels)
        ' Maak een Graphics object van de Bitmap.
        Dim g As Graphics = Graphics.FromImage(stageBitmap)

        ' Vul de achtergrond van de PictureBox met een kleur (bijvoorbeeld zwart).
        g.Clear(Color.Black)

        ' Bereken de offset om het podium te centreren en de startpositie aan te passen
        Dim xOffset As Integer = (beschikbareBreedtePixels - (podiumBreedteLeds * pixelGrootte)) \ 2 ' 20 + 50 = 70,  40 + 100 = 140
        Dim yOffset As Integer = (beschikbareHoogtePixels - (podiumHoogteLeds * pixelGrootte)) \ 2

        ' Sla de startpositie op
        Dim StartPosX = xOffset
        Dim StartPosY = beschikbareHoogtePixels - yOffset

        ' Teken de markeringen langs de zijkanten
        Dim markerLengteKlein As Integer = 5
        Dim markerLengteMiddel As Integer = 10
        Dim markerLengteGroot As Integer = 15
        Dim tekstOffsetY As Integer = -50
        Dim tekstOffsetX As Integer = -40




        ' Teken verticale markeringen (Y-as, hoogte)
        Dim yPosCmMarker As Integer = 0
        While yPosCmMarker <= podiumHoogteCm
            Dim yPixelPos As Single = beschikbareHoogtePixels - yOffset - CSng((yPosCmMarker / podiumHoogteCm) * (beschikbareHoogtePixels - 2 * yOffset)) ' Omgekeerde Y-as, rekening houdend met offset

            Dim markerLengte As Integer
            If yPosCmMarker Mod 100 = 0 Then
                markerLengte = markerLengteGroot
                g.DrawString((yPosCmMarker / 100).ToString("0") & " m", pbStage.Font, Brushes.White, xOffset + tekstOffsetY, CSng(yPixelPos - pbStage.Font.Height / 2)) ' Eenheid in meters
            ElseIf yPosCmMarker Mod 50 = 0 Then
                markerLengte = markerLengteMiddel
            ElseIf yPosCmMarker Mod 10 = 0 Then
                markerLengte = markerLengteKlein
            Else
                yPosCmMarker += 10
                Continue While
            End If

            g.DrawLine(Pens.White, xOffset - markerLengte, yPixelPos, xOffset, yPixelPos)
            yPosCmMarker += 10
        End While

        ' Teken horizontale markeringen (X-as, breedte)
        Dim xPosCmMarker As Integer = -20
        While xPosCmMarker <= podiumBreedteCm
            Dim xPixelPos As Single = xOffset + CSng((xPosCmMarker / podiumBreedteCm) * (beschikbareBreedtePixels - 2 * xOffset))


            Dim markerLengte As Integer
            If xPosCmMarker Mod 100 = 0 Then
                markerLengte = markerLengteGroot
                Dim stringSize As SizeF = g.MeasureString((xPosCmMarker / 100).ToString("0.00") & " m", pbStage.Font)
                g.DrawString((xPosCmMarker / 100).ToString("0") & " m", pbStage.Font, Brushes.White, CSng(xPixelPos - stringSize.Width / 2), beschikbareHoogtePixels - yOffset - pbStage.Font.Height - tekstOffsetX) ' Eenheid in meters
            ElseIf xPosCmMarker Mod 50 = 0 Then
                markerLengte = markerLengteMiddel
            ElseIf xPosCmMarker Mod 10 = 0 Then
                markerLengte = markerLengteKlein
            Else
                xPosCmMarker += 10
                Continue While
            End If

            g.DrawLine(Pens.White, xPixelPos, beschikbareHoogtePixels - yOffset + markerLengte, xPixelPos, beschikbareHoogtePixels - yOffset)
            xPosCmMarker += 10
        End While


        ' Toon een gele punt op start positie
        Dim puntGrootte As Integer = 10  ' Grootte van het gele punt
        Dim xPos As Integer = StartPosX - puntGrootte \ 2 ' Centreer het punt rond de x-coördinaat
        Dim yPos As Integer = StartPosY - puntGrootte \ 2 ' Centreer het punt rond de y-coördinaat

        g.FillRectangle(Brushes.Yellow, xPos, yPos, puntGrootte, puntGrootte)



        ' Loop door de LED's in de LedLijst en teken ze op de Bitmap.
        For Each ledInfo As LedInfo In LedLijst
            Dim xPosPixel As Integer = StartPosX + CInt(ledInfo.X * pixelGrootte)

            ' Gebruik StartPosY en trek de Y-positie van de LED er vanaf, rekening houdend met de pixelgrootte
            Dim yPosPixel As Integer = StartPosY - CInt(ledInfo.Y * pixelGrootte)

            ' Bepaal de kleur van de LED (voorbeeld: rood)
            Dim ledKleur As Color = Color.Red ' Standaard rood.
            ' Hier zou je de DMX-waarden kunnen ophalen en de kleur bepalen.
            ' Bijvoorbeeld:
            ' Dim roodWaarde As Byte = GetDmxValue(ledInfo.RoodKanaal, ledInfo.UniverseNummer)
            ' Dim groenWaarde As Byte = GetDmxValue(ledInfo.GroenKanaal, ledInfo.UniverseNummer)
            ' Dim blauwWaarde As Byte = GetDmxValue(ledInfo.BlauwKanaal, ledInfo.UniverseNummer)
            ' ledKleur = Color.FromArgb(roodWaarde, groenWaarde, blauwWaarde)

            ' Teken een rechthoekje voor de LED.
            g.FillRectangle(New SolidBrush(ledKleur), xPosPixel, yPosPixel, pixelGrootte, pixelGrootte)
            g.DrawRectangle(Pens.Gray, xPosPixel, yPosPixel, pixelGrootte, pixelGrootte) ' Grijze rand
        Next






        ' Stel de Bitmap in als de Image van de PictureBox.
        pbStage.Image = stageBitmap
        g.Dispose()
        pbStage.Invalidate()
    End Sub


    ' *********************************************************************************
    ' VervangRichtingDoorPijlen
    ' Vervangt de richtingkarakters in de layoutstring door pijlen.
    ' *********************************************************************************
    Public Function VervangRichtingDoorPijlen(ByVal layoutString As String) As String
        Dim aangepasteString As String

        ' Controleer of de inputstring niet leeg is
        If String.IsNullOrEmpty(layoutString) Then
            Return layoutString
        End If

        ' Vervang de richtingkarakters door ASCII-pijlen
        aangepasteString = layoutString.ToUpper

        Return aangepasteString
    End Function

End Module
