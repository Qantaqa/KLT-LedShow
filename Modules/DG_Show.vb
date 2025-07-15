Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Security.AccessControl
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.AxHost
Imports Newtonsoft.Json.Linq
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports AxWMPLib ' Nodig voor Import



Module DG_Show
    Dim booleanBlinkStart As Boolean = True
    Dim booleanBlinkNextEvent As Boolean = False
    Dim booleanBlinkNextScene As Boolean = False
    Dim booleanBlinkTimer As Boolean = False
    Dim colorBlinkTimer As Color = Color.Green

    ' Variabelen voor het afspelen van GIF-afbeeldingen
    Private gifImage As Image
    Private currentFrame As Integer
    Private frameTimer As Timer
    Private frameDelayList() As Integer ' Array om de frame delays op te slaan



    Public Class WledSegmentData
        Public Property id As Integer
        Public Property fx As String
    End Class


    ' Deze variabelen zijn nu op moduleniveau gedefinieerd
    'Public Event AddNewRowBeforeClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Public Event AddNewRowAfterClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Public Event RemoveCurrentRowClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)



    ' *********************************************************
    ' Deze sub werkt het fixure pulldown veld bij, met beschikbare fixured
    ' *********************************************************
    Public Sub UpdateFixuresPulldown_ForShow(ByVal DG_Show As DataGridView)
        Dim currentRow As DataGridViewRow
        If (DG_Show.RowCount = 0) Then
            ' No show loaded yet, nothing to update
            Return
        Else
            currentRow = DG_Show.Rows(DG_Show.CurrentRow.Index)
        End If

        Dim fixtureColumn As DataGridViewComboBoxColumn = TryCast(DG_Show.Columns("colFixture"), DataGridViewComboBoxColumn)
        If fixtureColumn IsNot Nothing Then
            ' Clear de vorige items
            fixtureColumn.Items.Clear()

            fixtureColumn.Items.Add("** Video **/ Output 1")
            fixtureColumn.Items.Add("** Video **/ Output 2")
            fixtureColumn.Items.Add("** Video **/ Output 3")

            ' Voeg de WLED devices en segmenten toe aan de dropdown list
            For Each devRow As DataGridViewRow In FrmMain.DG_Devices.Rows
                If devRow.IsNewRow Then Continue For

                Dim wledName As String = Convert.ToString(devRow.Cells("colInstance").Value)
                Dim segmentsValue As String = Convert.ToString(devRow.Cells("colSegments").Value)

                If Not String.IsNullOrWhiteSpace(wledName) AndAlso Not String.IsNullOrWhiteSpace(segmentsValue) Then
                    ' Zoek alle segmenten in de vorm (start-end)
                    Dim matches = System.Text.RegularExpressions.Regex.Matches(segmentsValue, "\([^\)]+\)")
                    For i As Integer = 0 To matches.Count - 1
                        fixtureColumn.Items.Add($"{wledName}/{i}")
                    Next
                End If
            Next
        End If
    End Sub


    ' *********************************************************************************************
    ' Deze sub werkt de overige waarden bij met default waarden van de wled, in geval de fixure is gewijzigd
    ' *********************************************************************************************
    ' *********************************************************************************************
    ' Deze sub werkt de overige waarden bij met default waarden van de wled, in geval de fixure is gewijzigd
    ' *********************************************************************************************
    Public Sub UpdateOtherFields_ForCurrentFixure(ByVal DG_Show As DataGridView, RowIndex As Integer)
        Dim currentRow = DG_Show.Rows(RowIndex)

        Dim selectedFixture = currentRow.Cells("colFixture").Value
        If selectedFixture IsNot Nothing AndAlso selectedFixture.ToString().Substring(0, 2) <> "**" Then
            Dim fixtureParts = selectedFixture.ToString().Split("/"c)
            If fixtureParts.Length = 2 Then
                Dim wledName = fixtureParts(0)
                Dim segmentIndex = Integer.Parse(fixtureParts(1))

                ' Zoek de juiste device row in DG_Devices
                Dim devRow As DataGridViewRow = Nothing
                For Each row As DataGridViewRow In FrmMain.DG_Devices.Rows
                    If row.IsNewRow Then Continue For
                    If Convert.ToString(row.Cells("colInstance").Value) = wledName Then
                        devRow = row
                        Exit For
                    End If
                Next

                If devRow IsNot Nothing Then
                    ' Aan/uit moet altijd dan naar aan
                    currentRow.Cells("colStateOnOff").Value = True

                    ' Verwacht een JSON string met segmentdata in colSegmentsData
                    Dim segmentsJson As String = TryCast(devRow.Cells("colSegmentsData").Value, String)
                    If Not String.IsNullOrWhiteSpace(segmentsJson) Then
                        Try
                            Dim segments = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JArray)(segmentsJson)
                            If segments IsNot Nothing AndAlso segments.Count > segmentIndex Then
                                Dim segment = TryCast(segments(segmentIndex), JObject)

                                ' Speed
                                If segment("sx") IsNot Nothing Then
                                    currentRow.Cells("colSpeed").Value = segment("sx").Value(Of Integer)
                                End If

                                ' Intensity
                                If segment("ix") IsNot Nothing Then
                                    currentRow.Cells("colIntensity").Value = segment("ix").Value(Of Integer)
                                End If

                                ' Huidige effect en palette waarde
                                If segment("fx") IsNot Nothing Then
                                    currentRow.Cells("colEffectId").Value = segment("fx").ToString()
                                End If
                                If segment("pal") IsNot Nothing Then
                                    currentRow.Cells("colPaletteId").Value = segment("pal").ToString()
                                End If

                                ' Kleur 1 2 en 3 van wled
                                Dim colors = TryCast(segment("col"), JArray)
                                If colors IsNot Nothing Then
                                    If colors.Count > 0 Then
                                        currentRow.Cells("colColor1").Value = ColorTranslator.ToOle(Color.FromArgb(colors(0)(0).Value(Of Integer), colors(0)(1).Value(Of Integer), colors(0)(2).Value(Of Integer)))
                                    End If
                                    If colors.Count > 1 Then
                                        currentRow.Cells("colColor2").Value = ColorTranslator.ToOle(Color.FromArgb(colors(1)(0).Value(Of Integer), colors(1)(1).Value(Of Integer), colors(1)(2).Value(Of Integer)))
                                    End If
                                    If colors.Count > 2 Then
                                        currentRow.Cells("colColor3").Value = ColorTranslator.ToOle(Color.FromArgb(colors(2)(0).Value(Of Integer), colors(2)(1).Value(Of Integer), colors(2)(2).Value(Of Integer)))
                                    End If
                                End If

                                ' Brightness van wled
                                If segment("bri") IsNot Nothing Then
                                    currentRow.Cells("colBrightness").Value = segment("bri").Value(Of Integer)
                                End If

                                ' Overgang (transition) van wled
                                If segment("transition") IsNot Nothing Then
                                    currentRow.Cells("colTransition").Value = segment("transition").Value(Of Integer)
                                Else
                                    currentRow.Cells("colTransition").Value = 0 ' or some default value
                                End If

                                ' Geluid standaard uit
                                currentRow.Cells("colMicrophone").Value = False
                            End If
                        Catch ex As Exception
                            ' Foutafhandeling: JSON niet goed of segment ontbreekt
                            currentRow.Cells("colSpeed").Value = 0
                            currentRow.Cells("colIntensity").Value = 0
                            currentRow.Cells("colEffectId").Value = ""
                            currentRow.Cells("colPaletteId").Value = ""
                            currentRow.Cells("colColor1").Value = 0
                            currentRow.Cells("colColor2").Value = 0
                            currentRow.Cells("colColor3").Value = 0
                            currentRow.Cells("colBrightness").Value = 0
                            currentRow.Cells("colTransition").Value = 0
                            currentRow.Cells("colMicrophone").Value = False
                        End Try
                    End If
                End If
            End If
        End If
    End Sub



    ' *********************************************************
    ' Als het filter veld is gewijzigd, filter de Show grid op basis van de geselecteerde Act
    ' *********************************************************
    Public Sub FilterDG_Show(ByVal DG_Show As DataGridView, ByVal filterAct As ToolStripComboBox)
        On Error Resume Next

        Dim filterValue As String = filterAct.SelectedItem?.ToString()

        If String.IsNullOrEmpty(filterValue) Then
            ' Toon alle rijen als het filter leeg is
            For Each row As DataGridViewRow In DG_Show.Rows
                row.Visible = True
            Next
        Else
            ' Filter de rijen op basis van de geselecteerde Act
            For Each row As DataGridViewRow In DG_Show.Rows
                If row.Cells("colAct").Value?.ToString() = filterValue Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            Next
        End If
    End Sub


    ' *********************************************************
    ' Add Row BEFORE
    ' *********************************************************
    Public Sub DG_Show_AddNewRowBefore_Click(ByVal DG_Show As DataGridView)

        'Voeg hier de logica toe om een nieuwe rij voor de huidige rij toe te voegen
        Dim currentRowIndex As Integer = 0
        If DG_Show.Rows.Count > 0 Then
            currentRowIndex = DG_Show.CurrentCell.RowIndex
        End If
        DG_Show.Rows.Insert(currentRowIndex, 1) 'Voegt een nieuwe rij in op de gespecificeerde index

        'Stel de focus op de nieuwe rij
        DG_Show.CurrentCell = DG_Show.Rows(currentRowIndex).Cells(0)

        ' Vul het pulldown veld voor de fixture
        UpdateFixuresPulldown_ForShow(DG_Show)

    End Sub

    ' *********************************************************
    ' Add Row AFTER
    ' *********************************************************
    Public Sub DG_Show_AddNewRowAfter_Click(ByVal DG_Show As DataGridView)
        'Voeg hier de logica toe om een nieuwe rij na de huidige rij toe te voegen
        Dim currentRowIndex As Integer = 0

        If DG_Show.Rows.Count > 0 Then
            currentRowIndex = DG_Show.CurrentCell.RowIndex
            DG_Show.Rows.Insert(currentRowIndex + 1, 1) 'Voegt een nieuwe rij in na de huidige rij
        Else
            DG_Show.Rows.Insert(0, 1) 'Voegt een nieuwe rij in op de gespecificeerde index
            currentRowIndex = -1
        End If


        'Stel de focus op de nieuwe rij
        DG_Show.CurrentCell = DG_Show.Rows(currentRowIndex + 1).Cells(0)

        UpdateFixuresPulldown_ForShow(DG_Show)


    End Sub

    ' *********************************************************
    ' REMOVE Row
    ' *********************************************************
    Public Sub DG_Show_RemoveCurrentRow_Click(ByVal DG_Show As DataGridView)

        'Voeg hier de logica toe om de huidige rij te verwijderen
        Dim currentRowIndex As Integer = DG_Show.CurrentCell.RowIndex
        If DG_Show.Rows.Count > 0 Then
            DG_Show.Rows.RemoveAt(currentRowIndex)
        End If
    End Sub


    ' *********************************************************
    ' Deze sub werkt de effect en palette naam bij, in geval het ID van effect of palette is gewijzigd
    ' *********************************************************
    Public Sub AfterUpdateEffectOrPaletteId_UpdateEffectAndPaletteName(ByVal DG_Show As DataGridView, ByVal DG_Effects As DataGridView, ByVal DG_Palette As DataGridView)
        For Each row As DataGridViewRow In DG_Show.Rows
            Dim effectIdCell As DataGridViewCell = row.Cells("colEffectId")
            Dim effectNameCell As DataGridViewCell = row.Cells("colEffect")
            Dim paletteIdCell As DataGridViewCell = row.Cells("colPaletteId")
            Dim paletteNameCell As DataGridViewCell = row.Cells("colPalette")


            If effectIdCell.Value IsNot Nothing Then
                Dim effectId As String = effectIdCell.Value.ToString()
                Dim effectName As String = GetEffectNameFromId(effectId, DG_Effects)  ' Roep de functie aan om de naam op te halen
                effectNameCell.Value = effectName
            End If

            If paletteIdCell.Value IsNot Nothing Then
                Dim paletteId As String = paletteIdCell.Value.ToString()
                Dim paletteName As String = GetPaletteNameFromId(paletteId, DG_Palette)
                paletteNameCell.Value = paletteName
            End If
        Next
    End Sub

    ' *********************************************************
    ' Deze sub werkt de kleurvelden bij met een kleurenwiel
    ' *********************************************************
    Public Function GetColorByColorWheel() As System.Drawing.Color
        ' Voeg de kleuren toe aan de dropdown list
        Dim colorDialog As New ColorDialog()
        If colorDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedColor = colorDialog.Color
            Return colorDialog.Color
        End If
        Return Nothing
    End Function





    ' *******************************************************************************************************************
    ' DG_SHOW event VALUE CHANGED 
    ' *******************************************************************************************************************   
    Public Async Sub DG_Show_AfterUpdateCellValue(sender As Object, e As DataGridViewCellEventArgs, DG_Show As DataGridView, DG_Effecten As DataGridView, DG_Paletten As DataGridView)

        Dim wledName As String
        Dim wledIP As String
        Dim wledSegment As String

        If DG_Show.Rows.Count > 0 AndAlso e.RowIndex >= 0 Then

            ' Haal waardes op van de geselecteerde rij
            Dim fixtureValue = TryCast(DG_Show.CurrentRow.Cells("colFixture").Value, String)
            If fixtureValue <> "" Then
                If fixtureValue.Contains("/") Then
                    wledName = fixtureValue.Split("/"c)(0)
                    wledSegment = fixtureValue.Split("/"c)(1)
                Else
                    wledName = fixtureValue
                    wledSegment = ""
                End If
                wledIP = GetIpFromWLedName(wledName)
            Else
                wledName = ""
                wledIP = ""
                wledSegment = ""
            End If

            ' Wat is bijgewerkt?
            Select Case DG_Show.CurrentCell.ColumnIndex

                    ' **************************************************
                    ' Fixure wijzigd, update de effecten en paletten
                Case DG_Show.Columns("colFixture").Index
                    UpdateEffectenPulldown_ForCurrentFixure(DG_Show)                ' Update de Effect dropdown met de juiste effecten
                    UpdatePalettePulldown_ForCurrentFixure(DG_Show)                 ' Update de Palette dropdown met de juiste paletten
                    UpdateOtherFields_ForCurrentFixure(DG_Show, e.RowIndex)         ' Reset alle overige waarden conform de WLED instellingen

                    AfterUpdateEffectOrPaletteId_UpdateEffectAndPaletteName(DG_Show, DG_Effecten, DG_Paletten)


                    ' **************************************************
                    ' Effect update
                    ' **************************************************
                Case DG_Show.Columns("colEffect").Index

                    Dim effectName = TryCast(DG_Show.CurrentRow.Cells("colEffect").Value, String)
                    DG_Show.CurrentRow.Cells("colEffectId").Value = GetEffectIdFromName(effectName, DG_Effecten)


                    ' **************************************************
                    ' Pallet update
                    ' **************************************************
                Case DG_Show.Columns("colPalette").Index
                    Dim paletteName = TryCast(DG_Show.CurrentRow.Cells("colPalette").Value, String)
                    DG_Show.CurrentRow.Cells("colPaletteId").Value = GetPaletteIdFromName(paletteName, DG_Paletten)

            End Select
        End If


    End Sub


    Sub Update_DGGRid_Details(DG_Show As DataGridView, RowId As Integer)
        Dim PaletteImagesPath As String = My.Settings.PaletteImagesPath
        Dim EffectsImagesPath As String = My.Settings.EffectsImagePath

        Dim imagePath As String = ""

        Dim CurrentRow = DG_Show.Rows(RowId)

        If Not IsNothing(CurrentRow) Then
            ' Controleer of er exact één rij geselecteerd is
            If DG_Show.SelectedRows.Count = 1 Then
                FrmMain.gb_DetailWLed.Visible = True

                Dim PaletteName As String = CurrentRow.Cells("colPalette").Value
                Dim EffectName As String = CurrentRow.Cells("colEffect").Value


                FrmMain.detailWLed_Brightness.Value = CurrentRow.Cells("colBrightness").Value
                FrmMain.detailWLed_Intensity.Value = CurrentRow.Cells("colIntensity").Value
                FrmMain.detailWLed_Speed.Value = CurrentRow.Cells("colSpeed").Value
                If CurrentRow.Cells("colColor1").Value IsNot Nothing Then
                    FrmMain.detailWLed_Color1.BackColor = ColorTranslator.FromHtml(CurrentRow.Cells("colColor1").Value.ToString())
                End If
                If CurrentRow.Cells("colColor2").Value IsNot Nothing Then
                    FrmMain.detailWLed_Color2.BackColor = ColorTranslator.FromHtml(CurrentRow.Cells("colColor2").Value.ToString())
                End If
                If CurrentRow.Cells("colColor3").Value IsNot Nothing Then
                    FrmMain.detailWLed_Color3.BackColor = ColorTranslator.FromHtml(CurrentRow.Cells("colColor3").Value.ToString())
                End If

                ' Toon plaatje van palette
                If PaletteName IsNot Nothing Then
                    PaletteName = PaletteName.ToString().Replace(" ", "_") & ".png"
                    PaletteName = PaletteName.ToString().Replace("*_", "")
                    imagePath = Path.Combine(PaletteImagesPath, PaletteName)
                End If

                ' Controleer of het bestand bestaat voordat je het laadt.
                If File.Exists(imagePath) Then
                        Try
                            ' Laad de afbeelding en wijs deze toe aan de cel.
                            Dim image As Image = Image.FromFile(imagePath)

                            FrmMain.detailWLed_Palette.Image = image
                        Catch ex As Exception
                            ' Foutafhandeling: Log de fout en toon een bericht.
                            Console.WriteLine($"Fout bij het laden van afbeelding: {imagePath}. Fout: {ex.Message}")
                            ' Je kunt er ook voor kiezen om een standaardafbeelding in te stellen of de cel leeg te laten.

                        End Try
                    Else
                        ' Als het bestand niet bestaat, laat de cel dan leeg en log een waarschuwing.
                        Console.WriteLine($"Afbeelding niet gevonden: {imagePath}")
                    End If



                ' Toon plaatje van effect
                If EffectName IsNot Nothing Then
                    EffectName = EffectName.ToString().Replace(" ", "_") & ".gif"
                    EffectName = EffectName.ToString().Replace("*_", "")
                    imagePath = Path.Combine(EffectsImagesPath, EffectName)

                    ' Controleer of het bestand bestaat voordat je het laadt.
                    If File.Exists(imagePath) Then
                        Try
                            ' Laad de afbeelding en wijs deze toe aan de cel.
                            Dim image As Image = Image.FromFile(imagePath)
                            gifImage = image

                            ' Initialiseert de timer voor de animatie
                            frameTimer = New Timer()
                            frameTimer.Interval = 100  ' Standaard interval, wordt later overschreven door de GIF's frame delays.
                            AddHandler frameTimer.Tick, AddressOf FrameTimer_Tick
                            frameTimer.Start()

                            FrmMain.detailWLed_Effect.Image = image

                            ' Haal de frame delays op en sla ze op in een array
                            If gifImage IsNot Nothing Then
                                Dim frameDimension As New FrameDimension(gifImage.FrameDimensionsList(0))
                                Dim frameCount As Integer = gifImage.GetFrameCount(FrameDimension.Time)
                                ReDim frameDelayList(frameCount - 1) ' Array initialiseren met de juiste grootte

                                For i As Integer = 0 To frameCount - 1
                                    gifImage.SelectActiveFrame(frameDimension, i)
                                    Dim frameDelayBytes() As Byte = gifImage.GetPropertyItem(207).Value ' Property ID 207 bevat de frame delays
                                    frameDelayList(i) = BitConverter.ToInt32(frameDelayBytes, i * 4) * 10 ' Omzetten naar milliseconden
                                Next

                                ' Start de animatie met de eerste frame delay
                                If frameDelayList.Length > 0 Then
                                    frameTimer.Interval = frameDelayList(0)
                                End If
                            End If


                        Catch ex As Exception
                            ' Foutafhandeling: Log de fout en toon een bericht.
                            Console.WriteLine($"Fout bij het laden van afbeelding: {imagePath}. Fout: {ex.Message}")
                            ' Je kunt er ook voor kiezen om een standaardafbeelding in te stellen of de cel leeg te laten.

                        End Try
                    Else
                        ' Als het bestand niet bestaat, laat de cel dan leeg en log een waarschuwing.
                        Console.WriteLine($"Afbeelding niet gevonden: {imagePath}")
                    End If
                End If


                FrmMain.detailWLed__EffectName.Text = CurrentRow.Cells("colEffect").Value

                Else
                    ' Meerdere regels geselecterd
                    FrmMain.gb_DetailWLed.Visible = False
            End If
        End If
    End Sub


    Private Sub FrameTimer_Tick(sender As Object, e As EventArgs)
        Dim frameDimension As New FrameDimension(gifImage.FrameDimensionsList(0))

        ' Gaat naar het volgende frame
        currentFrame = (currentFrame + 1) Mod gifImage.GetFrameCount(frameDimension.Time)

        ' Selecteert het actieve frame
        gifImage.SelectActiveFrame(frameDimension, currentFrame)

        ' Tekent het huidige frame in de PictureBox
        FrmMain.detailWLed_Effect.Invalidate() ' Forceer PictureBox om opnieuw te tekenen

        ' Stel het timer interval in op de delay van het huidige frame
        If frameDelayList.Length > 0 Then
            If frameDelayList(currentFrame) > 0 Then
                frameTimer.Interval = frameDelayList(currentFrame)
            Else
                frameTimer.Interval = 100 ' Standaard interval als er geen delay is     
            End If
        End If
    End Sub


    Public Sub Show_PaintEvent(sender As Object, e As PaintEventArgs)
        ' Tekent het huidige frame van de GIF
        If gifImage IsNot Nothing Then
            e.Graphics.DrawImage(gifImage, 0, 0, FrmMain.detailWLed_Effect.Width, FrmMain.detailWLed_Effect.Height)
        End If
    End Sub

    Sub UpdateBlinkingButton()

        If My.Settings.Locked Then
            FrmMain.gb_Controls.Enabled = True

            ' Start button
            If booleanBlinkStart Then
                If FrmMain.btnControl_Start.BackColor = Color.Black Then
                    FrmMain.btnControl_Start.BackColor = Color.Green
                Else
                    FrmMain.btnControl_Start.BackColor = Color.Black
                End If
            Else
                FrmMain.btnControl_Start.BackColor = Color.Black
            End If

            ' Next event button
            If booleanBlinkNextEvent Then
                If FrmMain.btnControl_NextEvent.BackColor = Color.Black Then
                    FrmMain.btnControl_NextEvent.BackColor = Color.Green
                Else
                    FrmMain.btnControl_NextEvent.BackColor = Color.Black
                End If
            Else
                FrmMain.btnControl_NextEvent.BackColor = Color.Black
            End If

            ' Next scene button
            If booleanBlinkNextScene Then
                If FrmMain.btnControl_NextScene.BackColor = Color.Black Then
                    FrmMain.btnControl_NextScene.BackColor = Color.Green
                Else
                    FrmMain.btnControl_NextScene.BackColor = Color.Black
                End If
            Else
                FrmMain.btnControl_NextScene.BackColor = Color.Black
            End If

            ' Timer
            If booleanBlinkTimer Then
                If FrmMain.lblControl_TimeLeft.BackColor = Color.Black Then
                    FrmMain.lblControl_TimeLeft.BackColor = colorBlinkTimer
                Else
                    FrmMain.lblControl_TimeLeft.BackColor = Color.Black
                End If
            Else
                FrmMain.lblControl_TimeLeft.BackColor = Color.Black
            End If

        Else
            FrmMain.gb_Controls.Enabled = False
            FrmMain.btnControl_Start.BackColor = Color.DarkRed
            FrmMain.btnControl_NextEvent.BackColor = Color.DarkRed
            FrmMain.btnControl_NextScene.BackColor = Color.DarkRed
            FrmMain.lblControl_TimeLeft.BackColor = Color.Black
        End If
    End Sub

    Sub EndEventTimer()
        colorBlinkTimer = Color.DarkRed
        FrmMain.TimerNextEvent.Stop()

        booleanBlinkNextEvent = True


    End Sub


    Sub Start_Show(DG_Show As DataGridView)
        Dim FoundRows As Integer = 0

        ' Find number of preshow - scene 1, event 1
        For Each row In DG_Show.Rows
            If row.cells("colAct").value = "Pre-Show" And row.cells("colSceneId").value = "1" And row.cells("colEventId").value = "1" Then
                FoundRows = FoundRows + 1

                ' Mark down this cell as active
                row.cells("btnApply").value = ">"

                If row.cells("colTimer").value <> "" Then
                    ' A timer value is set
                    FrmMain.TimerNextEvent.Interval = TimeStringToMilliseconds(row.cells("colTimer").value)
                    FrmMain.TimerNextEvent.Start()
                    colorBlinkTimer = Color.Green
                    booleanBlinkTimer = True
                    FrmMain.lblControl_TimeLeft.Text = row.cells("colTimer").value
                End If
            Else
                row.cells("btnApply").value = ""
            End If
        Next


        ' Update the blinking of buttons
        booleanBlinkStart = False
        booleanBlinkNextEvent = False
        booleanBlinkNextScene = False

        If FoundRows = 1 Then
            booleanBlinkNextScene = True
        Else
            If Not booleanBlinkTimer Then
                booleanBlinkNextScene = True
            End If
        End If

        ' Apply the selected rows
        Apply_Selected_Rows(DG_Show)
        Reselect_Rows(DG_Show)
    End Sub


    Public Sub Reselect_Rows(DG_Show As DataGridView)
        For Each row In DG_Show.Rows
            If row.cells("btnApply").value = ">" Then
                row.selected = True
            End If
        Next
    End Sub




End Module
