Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq

Module DG_Show
    Public Class WledSegmentData
        Public Property id As Integer
        Public Property fx As String
    End Class


    ' Deze variabelen zijn nu op moduleniveau gedefinieerd
    Public Event AddNewRowBeforeClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event AddNewRowAfterClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event RemoveCurrentRowClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ' *********************************************************
    ' Deze sub werkt het fixure pulldown veld bij, met beschikbare fixured
    ' *********************************************************
    Public Sub UpdateFixuresPulldown(ByVal DG_Show As DataGridView)
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
            For Each kvp In DG_Devices.wledDevices
                Dim ipAddress As String = kvp.Key
                Dim wledName As String = kvp.Value.Item1
                Dim wledData As JObject = kvp.Value.Item2
                If wledData IsNot Nothing AndAlso wledData("state") IsNot Nothing AndAlso wledData("state")("seg") IsNot Nothing Then
                    Dim segmentCount = TryCast(wledData("state")("seg"), JArray).Count
                    For i As Integer = 0 To segmentCount - 1
                        fixtureColumn.Items.Add($"{wledName}/{i}") ' Bv: "WLED_Main/0", "WLED_Main/1", ...
                    Next
                End If
            Next
        End If
    End Sub



    ' *********************************************************************************************
    ' Deze sub werkt de overige waarden bij met default waarden van de wled, in geval de fixure is gewijzigd
    ' *********************************************************************************************
    Public Sub UpdateOtherFields_ForCurrentFixure(ByVal DG_Show As DataGridView, RowIndex As Integer)
        Dim currentRow = DG_Show.Rows(RowIndex)

        Dim selectedFixture = currentRow.Cells("colFixture").Value
        If selectedFixture IsNot Nothing And Left(selectedFixture, 2) <> "**" Then
            Dim fixtureParts = selectedFixture.ToString().Split("/").ToArray()
            If fixtureParts.Length = 2 Then
                Dim wledName = fixtureParts(0)
                Dim segmentIndex = Integer.Parse(fixtureParts(1))
                Dim wledIp As String = ""
                For Each kvp In DG_Devices.wledDevices
                    If kvp.Value.Item1 = wledName Then
                        wledIp = kvp.Key
                        Exit For
                    End If
                Next

                If wledIp <> "" Then
                    ' Aan/uit moet altijd dan naar aan
                    currentRow.Cells("colStateOnOff").Value = True

                    ' Lees het segment uit, hierin zitten de kleuren, (fx) huidig effect, (sx) speed, (ix) Intensity, (pal) huidig pallet
                    Dim wledData = DG_Devices.wledDevices(wledIp).Item2
                    If wledData IsNot Nothing AndAlso wledData("state") IsNot Nothing AndAlso wledData("state")("seg") IsNot Nothing Then
                        Dim segments = TryCast(wledData("state")("seg"), JArray)
                        If segments IsNot Nothing AndAlso segments.Count > segmentIndex Then
                            Dim segment = TryCast(segments(segmentIndex), JObject)

                            ' Speed
                            currentRow.Cells("colSpeed").Value = segment("sx").Value(Of Integer)

                            ' Intensity
                            currentRow.Cells("colIntensity").Value = segment("ix").Value(Of Integer)

                            ' Huidige effect en palette waarde
                            currentRow.Cells("colEffectId").Value = segment("fx").Value(Of String)
                            currentRow.Cells("colPaletteId").Value = segment("pal").Value(Of String)

                            ' Kleur 1 2 en 3 van wled
                            Dim colors = TryCast(segment("col"), JArray)
                            If colors IsNot Nothing Then
                                If colors.Count > 0 Then
                                    currentRow.Cells("colColor1").Value = ColorTranslator.ToOle(Color.FromArgb(colors(0)(0).Value(Of Integer), colors(0)(1).Value(Of Integer), colors(0)(2).Value(Of Integer)))
                                    KleurDataGridViewKolomMetTekstContrast(DG_Show, "colColor1")
                                End If
                                If colors.Count > 1 Then
                                    currentRow.Cells("colColor2").Value = ColorTranslator.ToOle(Color.FromArgb(colors(1)(0).Value(Of Integer), colors(1)(1).Value(Of Integer), colors(1)(2).Value(Of Integer)))
                                    KleurDataGridViewKolomMetTekstContrast(DG_Show, "colColor2")
                                End If
                                If colors.Count > 2 Then
                                    currentRow.Cells("colColor3").Value = ColorTranslator.ToOle(Color.FromArgb(colors(2)(0).Value(Of Integer), colors(2)(1).Value(Of Integer), colors(2)(2).Value(Of Integer)))
                                    KleurDataGridViewKolomMetTekstContrast(DG_Show, "colColor3")
                                End If
                            End If

                            ' Brightness van wled
                            currentRow.Cells("colBrightness").Value = segment("bri").Value(Of Integer)

                            ' Overgang (transition) van wled
                            If segment("transition") IsNot Nothing Then
                                currentRow.Cells("colTransition").Value = segment("transition").Value(Of Integer)
                            Else
                                currentRow.Cells("colTransition").Value = 0 ' or some default value
                            End If



                            currentRow.Cells("colBrightness").Value = segment("bri").Value(Of Integer)

                            ' Geluid standaard uit
                            currentRow.Cells("colMicrophone").Value = False
                        End If
                    End If
                End If
            End If
        End If
    End Sub


    ' *********************************************************
    ' Deze sub werkt het Scenenummer of Eventnummer bij, in geval de Act is gewijzigd
    ' *********************************************************
    Public Sub UpdateSceneOrEventNumber_AfterUpdateAct(ByVal DG_Show As DataGridView, ByVal e As DataGridViewCellEventArgs)
        Dim currentRow = DG_Show.Rows(e.RowIndex)
        Dim currentAct = TryCast(currentRow.Cells("colAct").Value, String)

        If String.IsNullOrEmpty(currentAct) Then
            Return  ' Doe niets als de act leeg is
        End If

        Dim previousRow = If(e.RowIndex > 0, DG_Show.Rows(e.RowIndex - 1), Nothing)
        If previousRow IsNot Nothing Then
            Dim previousAct = TryCast(previousRow.Cells("colAct").Value, String)
            If currentAct <> previousAct Then
                ' Vraag de gebruiker om actie
                Dim result = MessageBox.Show($"Wil je een nieuwe scène toevoegen voor Act '{currentAct}'?", "Nieuwe Act", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Dim previousScene = DirectCast(previousRow.Cells("colSceneId").Value, Integer)
                If result = DialogResult.Yes Then
                    ' Nieuwe scène
                    Dim newSceneNumber = previousScene + 1
                    currentRow.Cells("colSceneId").Value = 1
                    currentRow.Cells("colEventId").Value = 1 ' Reset event nummer
                ElseIf result = DialogResult.No Then
                    ' Nieuw event in dezelfde scene
                    Dim previousEvent = DirectCast(previousRow.Cells("colEventId").Value, Integer)
                    currentRow.Cells("colSceneId").Value = previousScene
                    currentRow.Cells("colEventId").Value = previousEvent + 1
                Else
                    ' Annuleer de wijziging
                    currentRow.Cells("colAct").Value = previousAct
                End If
            End If
        Else
            currentRow.Cells("colSceneId").Value = 1
            currentRow.Cells("colEventId").Value = 1
        End If
    End Sub

    ' *********************************************************
    ' Deze sub kleurt de cellen in de datagridview op basis van de waarde in de kolom
    ' *********************************************************
    Private Sub KleurDataGridViewKolomMetTekstContrast(ByVal dataGridView As DataGridView, ByVal kolomNaam As String)
        For Each rij As DataGridViewRow In dataGridView.Rows
            For Each cel As DataGridViewCell In rij.Cells
                If dataGridView.Columns(cel.ColumnIndex).Name = kolomNaam Then
                    If cel.Value IsNot Nothing AndAlso IsNumeric(cel.Value) Then
                        Dim kleurCode As Integer = CInt(cel.Value)
                        If kleurCode >= 1 AndAlso kleurCode <= 65535 Then
                            Dim achtergrondKleur As Color = Color.FromArgb(kleurCode)
                            cel.Style.BackColor = achtergrondKleur

                            ' Bereken de luminantie van de achtergrondkleur
                            Dim luminantie As Double = (0.299 * achtergrondKleur.R + 0.587 * achtergrondKleur.G + 0.114 * achtergrondKleur.B) / 255

                            ' Kies de tekstkleur op basis van de luminantie
                            If luminantie > 0.5 Then
                                ' Achtergrond is licht, gebruik zwarte tekst
                                cel.Style.ForeColor = Color.Black
                            Else
                                ' Achtergrond is donker, gebruik witte tekst
                                cel.Style.ForeColor = Color.White
                            End If

                            'Markeer de cel om opnieuw te schilderen
                            dataGridView.InvalidateCell(cel)
                        End If
                    End If
                End If
                'Markeer de kolom om opnieuw te schilderen
                '                dataGridView.InvalidateColumn(dataGridView.Columns(kolomNaam).Index)
            Next
        Next

        'Markeer de hele datagridview om opnieuw te schilderen
        dataGridView.Invalidate()
        dataGridView.Refresh()
        dataGridView.Update()
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
        UpdateFixuresPulldown(DG_Show)
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

        UpdateFixuresPulldown(DG_Show)
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
    Private Sub UpdateColor123WithColorWheel(ByVal DG_Show As DataGridView)
        Dim rowIndex As Integer = DG_Show.CurrentCell.RowIndex
        Dim colIndex As Integer = DG_Show.CurrentCell.ColumnIndex
        Dim currentRow = DG_Show.Rows(rowIndex)
        Dim colorColumn As DataGridViewTextBoxColumn = TryCast(DG_Show.Columns(colIndex), DataGridViewTextBoxColumn)
        If colorColumn IsNot Nothing Then
            ' Voeg de kleuren toe aan de dropdown list
            Dim colorDialog As New ColorDialog()
            If colorDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedColor = colorDialog.Color
                currentRow.Cells(colIndex).Value = selectedColor.ToArgb()
                KleurDataGridViewKolomMetTekstContrast(DG_Show, colIndex)
            End If
        End If
    End Sub



    ' *******************************************************************************************************************
    ' DG_SHOW event VALUE CHANGED 
    ' *******************************************************************************************************************   
    Public Sub DG_Show_AfterUpdateCellValue(sender As Object, e As DataGridViewCellEventArgs, DG_Show As DataGridView, DG_Effecten As DataGridView, DG_Paletten As DataGridView)
        On Error GoTo DG_Show_AfterUpdateCellValue_Error

        Dim wledName As String
        Dim wledIP As String
        Dim wledSegment As String

        If DG_Show.Rows.Count > 0 AndAlso e.RowIndex >= 0 Then

            ' Haal waardes op van de geselecteerde rij
            Dim fixtureValue = TryCast(DG_Show.CurrentRow.Cells("colFixture").Value, String)
            If fixtureValue <> "" Then
                wledName = fixtureValue.Split("/"c)(0)
                wledIP = GetIpFromWLedName(wledName)
                wledSegment = fixtureValue.Split("/")(1)
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
                    ' Act wijzigd, update de scene en eventnummers
                Case DG_Show.Columns("colAct").Index
                    UpdateSceneOrEventNumber_AfterUpdateAct(DG_Show, e)             ' Werkt het scene en event nummer bij

                    ' **************************************************
                    ' Effect update
                    ' **************************************************
                Case DG_Show.Columns("colEffect").Index

                    Dim effectName = TryCast(DG_Show.CurrentRow.Cells("colEffect").Value, String)
                    Dim effectIdValue = GetEffectIdFromName(effectName, DG_Effecten)
                    If effectName IsNot Nothing AndAlso effectIdValue IsNot Nothing Then
                        Dim result = MessageBox.Show($"Wil je het effect '{effectName}' op '{fixtureValue}' toepassen?", "Effect Toepassen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If result = DialogResult.Yes Then
                            SendEffectToWLed(wledName, wledSegment, effectIdValue)
                        End If
                    End If

                    ' **************************************************
                    ' On Off wijzigd, update de scene en eventnummers
                Case DG_Show.Columns("colStateOnOff").Index
                    If DG_Show.CurrentRow.Cells("colStateOnOff").Value = "Uit" Then

                        Dim result = MessageBox.Show("Wil je de " & fixtureValue & " uitzetten?", "WLED Uitzetten", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If result = DialogResult.Yes Then
                            If fixtureValue IsNot Nothing Then
                                SendOnOffToWLed(wledName, wledSegment, DG_Show.CurrentRow.Cells("colStateOnOff").Value)
                            End If
                        End If
                    End If


            End Select
        End If

DG_Show_AfterUpdateCellValue_Error:
        ' Do nothing else.

    End Sub

    ' *******************************************************************************************************************
    ' DG_SHOW event DOUBLCLICK on row
    ' *******************************************************************************************************************   
    Public Sub DG_Show_DoubleClick(ByVal DG_Show As DataGridView, ByVal DG_Devices As DataGridView, ByVal DG_Effecten As DataGridView, ByVal DG_Paletten As DataGridView)
        ' Controleer of er een rij is geselecteerd
        If DG_Show.CurrentCell IsNot Nothing Then
            Dim currentRow = DG_Show.Rows(DG_Show.CurrentCell.RowIndex)

            ' Haal de relevante waarden uit de geselecteerde rij
            Dim fixtureValue = currentRow.Cells("colFixture").Value?.ToString()
            Dim effectId = TryCast(currentRow.Cells("colEffectId").Value, String)
            Dim paletteId = TryCast(currentRow.Cells("colPaletteId").Value, String)
            Dim color1 = currentRow.Cells("colColor1").Value
            Dim color2 = currentRow.Cells("colColor2").Value
            Dim color3 = currentRow.Cells("colColor3").Value
            Dim brightness = currentRow.Cells("colBrightness").Value
            Dim transition = currentRow.Cells("colTransition").Value
            Dim stateOnOff = currentRow.Cells("colStateOnOff").Value
            Dim speed = currentRow.Cells("colSpeed").Value
            Dim intensity = currentRow.Cells("colIntensity").Value
            Dim blend = currentRow.Cells("colBlend").Value
            Dim repeat = currentRow.Cells("colRepeat").Value

            ' Bepaal welke kolom is geselecteerd    
            Select Case (DG_Show.CurrentCell.ColumnIndex)

                    ' **************************************************
                    ' Kleur velden, update met een kleurenwiel
                    ' **************************************************
                Case DG_Show.Columns("colColor1").Index
                    UpdateColor123WithColorWheel(DG_Show)
                Case DG_Show.Columns("colColor2").Index
                    UpdateColor123WithColorWheel(DG_Show)
                Case DG_Show.Columns("colColor3").Index
                    UpdateColor123WithColorWheel(DG_Show)


            End Select
        End If
    End Sub


End Module
