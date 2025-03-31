Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Xml
Imports System.Diagnostics       ' Toegevoegd voor Process.Start
Imports System.Windows.Forms     ' Toegevoegd voor toegang tot UI-elementen
Imports System.ComponentModel    ' Toegevoegd voor toegang tot UI-elementen

Module ShowHandler
    Public Class WledSegmentData
        Public Property id As Integer
        Public Property fx As String
    End Class


    ' Deze variabelen zijn nu op moduleniveau gedefinieerd
    Public Event AddNewRowBeforeClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event AddNewRowAfterClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event RemoveCurrentRowClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ' Deze sub werkt de pulldown velden bij in de Show grid zodra het betreffende veld wordt geopend    
    Public Sub DG_Show_UpdatePulldownField_For_CurrentFixture(ByVal DG_Show As DataGridView, ByVal e As DataGridViewCellEventArgs)
        Dim currentRow = DG_Show.Rows(e.RowIndex)
        Dim fixtureColumn As DataGridViewComboBoxColumn = TryCast(DG_Show.Columns("colFixture"), DataGridViewComboBoxColumn)
        If fixtureColumn IsNot Nothing Then
            ' Clear de vorige items
            fixtureColumn.Items.Clear()

            fixtureColumn.Items.Add("** Video **/1")
            fixtureColumn.Items.Add("** Video **/2")
            fixtureColumn.Items.Add("** Video **/3")

            ' Voeg de WLED devices en segmenten toe aan de dropdown list
            For Each kvp In DetectDevices.wledDevices
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

    Public Sub DG_Show_UpdatePulldownField_For_CurrentPalette(ByVal DG_Show As DataGridView, RowIndex As Integer)
        Dim currentRow = DG_Show.Rows(RowIndex)
        Dim paletteColumn As DataGridViewComboBoxColumn = TryCast(DG_Show.Columns("colPalette"), DataGridViewComboBoxColumn)
        If paletteColumn IsNot Nothing Then
            paletteColumn.Items.Clear()
            Dim selectedFixture = currentRow.Cells("colFixture").Value
            If selectedFixture IsNot Nothing Then
                Dim fixtureParts = selectedFixture.ToString().Split("/").ToArray()
                If fixtureParts.Length = 2 Then
                    Dim wledName = fixtureParts(0)
                    Dim wledIp As String = ""
                    For Each kvp In DetectDevices.wledDevices
                        If kvp.Value.Item1 = wledName Then
                            wledIp = kvp.Key
                            Exit For
                        End If
                    Next

                    If wledIp <> "" Then
                        Dim wledData = DetectDevices.wledDevices(wledIp).Item2
                        If wledData IsNot Nothing AndAlso wledData("palettes") IsNot Nothing Then
                            Dim palettesArray = TryCast(wledData("palettes"), JArray)
                            If palettesArray IsNot Nothing Then
                                For i As Integer = 0 To palettesArray.Count - 1
                                    paletteColumn.Items.Add(palettesArray(i).ToString())
                                Next
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub DG_Show_UpdatePulldownField_For_CurrentEffect(ByVal DG_Show As DataGridView, RowIndex As Integer)
        Dim currentRow = DG_Show.Rows(RowIndex)

        Dim effectColumn As DataGridViewComboBoxColumn = TryCast(DG_Show.Columns("colEffect"), DataGridViewComboBoxColumn)
        If effectColumn IsNot Nothing Then
            effectColumn.Items.Clear()
            effectColumn.Items.Add("")

            Dim selectedFixture = currentRow.Cells("colFixture").Value
            If selectedFixture IsNot Nothing Then
                Dim fixtureParts = selectedFixture.ToString().Split("/").ToArray()
                If fixtureParts.Length = 2 Then
                    Dim wledName = fixtureParts(0)
                    Dim wledIp As String = ""
                    For Each kvp In DetectDevices.wledDevices
                        If kvp.Value.Item1 = wledName Then
                            wledIp = kvp.Key
                            Exit For
                        End If
                    Next

                    If wledIp <> "" Then
                        Dim wledData = DetectDevices.wledDevices(wledIp).Item2
                        If wledData IsNot Nothing AndAlso wledData("effects") IsNot Nothing Then
                            Dim effectsArray = TryCast(wledData("effects"), JArray)
                            If effectsArray IsNot Nothing Then
                                For Each effect In effectsArray
                                    effectColumn.Items.Add(effect.ToString())
                                Next
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub


    Public Sub DG_Show_UpdateOtherFieldsWithDefaultValues(ByVal DG_Show As DataGridView, RowIndex As Integer)
        Dim currentRow = DG_Show.Rows(RowIndex)

        Dim selectedFixture = currentRow.Cells("colFixture").Value
        If selectedFixture IsNot Nothing And Left(selectedFixture, 2) <> "**" Then
            Dim fixtureParts = selectedFixture.ToString().Split("/").ToArray()
            If fixtureParts.Length = 2 Then
                Dim wledName = fixtureParts(0)
                Dim segmentIndex = Integer.Parse(fixtureParts(1))
                Dim wledIp As String = ""
                For Each kvp In DetectDevices.wledDevices
                    If kvp.Value.Item1 = wledName Then
                        wledIp = kvp.Key
                        Exit For
                    End If
                Next

                If wledIp <> "" Then

                    ' Aan/uit moet altijd dan naar aan
                    currentRow.Cells("colStateOnOff").Value = True

                    ' Lees het segment uit, hierin zitten de kleuren, (fx) huidig effect, (sx) speed, (ix) Intensity, (pal) huidig pallet
                    Dim wledData = DetectDevices.wledDevices(wledIp).Item2
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

    Public Sub DG_Show_UpdateActOrSceneNumber(ByVal DG_Show As DataGridView, ByVal e As DataGridViewCellEventArgs)
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
                dataGridView.InvalidateColumn(dataGridView.Columns(kolomNaam).Index)
            Next
        Next

        'Markeer de hele datagridview om opnieuw te schilderen
        dataGridView.Invalidate()
        dataGridView.Refresh()
        dataGridView.Update()
    End Sub


    Public Sub DG_Show_CellValidating(ByVal DG_Show As DataGridView, ByVal e As DataGridViewCellValidatingEventArgs)
        If e.ColumnIndex = DG_Show.Columns("colAct").Index Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                e.Cancel = True
                MessageBox.Show("Act mag niet leeg zijn.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Sub DG_Show_RowsAdded(ByVal DG_Show As DataGridView, ByVal e As DataGridViewRowsAddedEventArgs)
        On Error Resume Next

        Dim currentRowId = e.RowIndex - 1

        Select Case e.RowIndex
            Case 0
                ' Doe niets, de rij is nog leeg
            Case 1
                ' Eerste rij, stel Scene en Event op 1 in
                DG_Show.Rows(currentRowId).Cells("colSceneId").Value = 1
                DG_Show.Rows(currentRowId).Cells("colEventId").Value = 1
            Case Else
                ' Volgende rijen, neem waarden van vorige rij over en increment EventId
                'Dim previousRowId = currentRowId - 1

                'Dim previousAct = TryCast(DG_Show.Rows(previousRowId).Cells("colAct").Value, String)
                'Dim previousScene = DirectCast(DG_Show.Rows(previousRowId).Cells("colSceneId").Value, Integer)
                'Dim previousEvent = DirectCast(DG_Show.Rows(previousRowId).Cells("colEventId").Value, Integer)
                'If MsgBox("Doorgaan met dezelfde scene?", MsgBoxStyle.YesNo, "Vraag") = MsgBoxResult.Yes Then

                '    DG_Show.Rows(currentRowId).Cells("colAct").Value = previousAct
                '    DG_Show.Rows(currentRowId).Cells("colSceneId").Value = previousScene
                '    DG_Show.Rows(currentRowId).Cells("colEventId").Value = previousEvent + 1

                'Else
                '    DG_Show.Rows(currentRowId).Cells("colAct").Value = previousAct
                '    DG_Show.Rows(currentRowId).Cells("colSceneId").Value = previousScene + 1
                '    DG_Show.Rows(currentRowId).Cells("colEventId").Value = 1

                'End If

        End Select
    End Sub


    ' Als het filter veld is gewijzigd, filter de Show grid op basis van de geselecteerde Act
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



    ' Handlers voor de knoppen voor het toevoegen van een rij voor de huidige rij
    Public Sub DGGrid_AddNewRowBefore_Click(ByVal DG_Show As DataGridView)

        'Voeg hier de logica toe om een nieuwe rij voor de huidige rij toe te voegen
        Dim currentRowIndex As Integer = 0
        If DG_Show.Rows.Count > 0 Then
            currentRowIndex = DG_Show.CurrentCell.RowIndex
        End If
        DG_Show.Rows.Insert(currentRowIndex, 1) 'Voegt een nieuwe rij in op de gespecificeerde index

        'Stel de focus op de nieuwe rij
        DG_Show.CurrentCell = DG_Show.Rows(currentRowIndex).Cells(0)
    End Sub

    ' Handlers voor de knoppen voor het toevoegen van een rij achter de huidige rij
    Public Sub DGGrid_AddNewRowAfter_Click(ByVal DG_Show As DataGridView)
        'Voeg hier de logica toe om een nieuwe rij na de huidige rij toe te voegen
        Dim currentRowIndex As Integer = 0
        If DG_Show.Rows.Count > 0 Then
            currentRowIndex = DG_Show.CurrentCell.RowIndex
        End If
        DG_Show.Rows.Insert(currentRowIndex + 1, 1) 'Voegt een nieuwe rij in na de huidige rij

        'Stel de focus op de nieuwe rij
        DG_Show.CurrentCell = DG_Show.Rows(currentRowIndex + 1).Cells(0)
    End Sub

    ' Handlers voor de knoppen voor het verwijderen van de huidige rij
    Public Sub DGGrid_RemoveCurrentRow_Click(ByVal DG_Show As DataGridView)

        'Voeg hier de logica toe om de huidige rij te verwijderen
        Dim currentRowIndex As Integer = DG_Show.CurrentCell.RowIndex
        If DG_Show.Rows.Count > 0 Then
            DG_Show.Rows.RemoveAt(currentRowIndex)
        End If
    End Sub



    Public Sub DG_Show_UpdateEffectAndPaletteName(ByVal DG_Show As DataGridView, ByVal DG_Effects As DataGridView, ByVal DG_Palette As DataGridView)
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

    Private Function GetEffectNameFromId(ByVal effectId As String, ByVal DG_Effects As DataGridView) As String
        ' Zoek de effectnaam in de DG_Effects DataGridView.
        For Each effectRow As DataGridViewRow In DG_Effects.Rows
            Dim effectIdCellValue = effectRow.Cells("EffectId").Value
            Dim effectNameCellValue = effectRow.Cells("Effect").Value
            If effectIdCellValue IsNot Nothing AndAlso effectIdCellValue.ToString() = effectId Then
                ' Zorg ervoor dat je de juiste datatype vergelijkt.
                If effectNameCellValue IsNot Nothing Then
                    Return effectNameCellValue.ToString()
                Else
                    Return "" ' Of een andere standaardwaarde als de naam null is
                End If
            End If
        Next
        Return "Unknown Effect" ' Retourneer dit als het effect niet wordt gevonden
    End Function

    Private Function GetPaletteNameFromId(ByVal paletteId As String, ByVal DG_Palette As DataGridView) As String
        ' Zoek de paletnaam in de DG_Palette DataGridView.
        For Each paletteRow As DataGridViewRow In DG_Palette.Rows
            Dim paletteIdCellValue = paletteRow.Cells("PaletteId").Value
            Dim paletteNameCellValue = paletteRow.Cells("Palette").Value
            If paletteIdCellValue IsNot Nothing AndAlso paletteIdCellValue.ToString() = paletteId Then
                If paletteNameCellValue IsNot Nothing Then
                    Return paletteNameCellValue.ToString()
                Else
                    Return ""
                End If
            End If
        Next
        Return "Unknown Palette"
    End Function

    Public Async Sub DG_Paletten_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs, ByVal DG_Paletten As DataGridView, ByVal DG_Devices As DataGridView)
        If e.RowIndex < 0 Then Exit Sub ' Make sure it is not header click
        If e.ColumnIndex <= 1 Then Exit Sub ' Make sure it is not the first columns

        Dim grid As DataGridView = DirectCast(sender, DataGridView)
        Dim currentRow = grid.Rows(e.RowIndex)
        Dim paletteNaam As String = TryCast(currentRow.Cells("Palette").Value, String)
        Dim wledNaam As String = grid.Columns(e.ColumnIndex).Name ' Dit is de WLED naam

        If paletteNaam Is Nothing OrElse wledNaam Is Nothing Then
            MessageBox.Show("Ongeldige selectie in de palettenlijst.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim wledIp = ""
        Debug.WriteLine($"DG_Paletten_CellContentClick: paletteNaam = {paletteNaam}, wledNaam = {wledNaam}")

        ' Haal het IP-adres op van DG_Devices
        For Each row As DataGridViewRow In DG_Devices.Rows
            If TryCast(row.Cells("colInstance").Value, String) = wledNaam Then
                wledIp = TryCast(row.Cells("colIPAddress").Value, String)
                Debug.WriteLine($"DG_Paletten_CellContentClick: Found WLED IP = {wledIp}")
                Exit For
            End If
        Next

        If wledIp <> "" Then
            Dim paletteId = -1
            Dim wledData = wledDevices(wledIp)
            Dim paletten = TryCast(wledData.Item2("palettes"), JArray)  ' Haal paletten op uit de JObject

            If Not (paletten Is Nothing) Then
                For i = 0 To paletten.Count - 1
                    If paletten(i).ToString() = paletteNaam Then
                        paletteId = i
                        Debug.WriteLine($"DG_Paletten_CellContentClick: Found paletteId = {paletteId}")
                        Exit For
                    End If
                Next
            End If

            If paletteId <> -1 Then
                Await SendUpdatedPaletteToWLed(wledIp, paletteId)
            Else
                MessageBox.Show("Palet niet beschikbaar.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("WLED IP niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Async Sub DG_Effecten_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs, ByVal DG_Effecten As DataGridView, ByVal DG_Devices As DataGridView)
        If e.RowIndex < 0 Then Exit Sub ' Zorg ervoor dat het geen headerklik is
        If e.ColumnIndex <= 1 Then Exit Sub ' Zorg ervoor dat het niet de eerste kolom is

        Dim currentRow = DG_Effecten.Rows(e.RowIndex)
        Dim effectNaam As String = TryCast(currentRow.Cells("Effect").Value, String)
        Dim wledNaam As String = TryCast(DG_Effecten.Columns(e.ColumnIndex).Name, String)

        If effectNaam Is Nothing OrElse wledNaam Is Nothing Then
            MessageBox.Show("Ongeldige selectie in de effectenlijst.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim wledIp = ""

        Debug.WriteLine($"DG_Effecten_CellContentClick: effectNaam = {effectNaam}, wledNaam = {wledNaam}")

        ' Haal het IP-adres op uit DG_Devices
        For Each row As DataGridViewRow In DG_Devices.Rows
            If TryCast(row.Cells("colInstance").Value, String) = wledNaam Then
                wledIp = TryCast(row.Cells("colIPAddress").Value, String)
                Debug.WriteLine($"DG_Effecten_CellContentClick: Found WLED IP = {wledIp}")
                Exit For
            End If
        Next

        If wledIp <> "" Then
            Dim effectId = -1
            Dim wledData = wledDevices(wledIp)
            Dim effecten = TryCast(wledData.Item2("effects"), JArray) ' Haal effecten op uit de JObject
            If effecten IsNot Nothing Then
                For i = 0 To effecten.Count - 1
                    If effecten(i).ToString() = effectNaam Then
                        effectId = i
                        Debug.WriteLine($"DG_Effecten_CellContentClick: Found effectId = {effectId}")
                        Exit For
                    End If
                Next
            End If

            If effectId <> -1 Then
                Await SendUpdatedEffectToWLed(wledIp, effectId)
            Else
                MessageBox.Show("Effect niet beschikbaar.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("WLED IP niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Public Async Function SendUpdatedPaletteToWLed(ipAddress As String, paletteId As Integer) As Task
        Using client As New HttpClient()
            Try
                ' Bouw de JSON-payload voor het POST-verzoek
                Dim payload As String = "{""seg"":[{""pal"":" & paletteId & "}]}"

                Dim content As New StringContent(payload, Encoding.UTF8, "application/json")

                ' Stuur het POST-verzoek naar de WLED API
                Dim postResponse As HttpResponseMessage = Await client.PostAsync("http://" + ipAddress + "/json/state", content)

                ' Lees de volledige responsinhoud
                Dim responseContent As String = Await postResponse.Content.ReadAsStringAsync()

                ' Plaats de respons in het tekstveld
                FrmMain.txt_APIResult.Text = responseContent

                ' Controleer de statuscode van het antwoord
                If postResponse.IsSuccessStatusCode Then
                    FrmMain.txt_APIResult.Text = $"Palette met ID '{paletteId}' toegepast op '{ipAddress}'."
                Else
                    MessageBox.Show($"Fout bij het toepassen van effect (HTTP {postResponse.StatusCode}): {responseContent}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As HttpRequestException
                FrmMain.txt_APIResult.Text = $"Fout bij het toepassen van palette: {ex.Message}"
                MessageBox.Show($"Fout bij het toepassen van palette: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using


        'Using client As New HttpClient()
        '    Try
        '        Dim url As String = $"http://{ipAddress}/json/state"
        '        Dim jsonData = New JObject(
        '            New JProperty("seg", New JArray(
        '                New JObject(
        '                    New JProperty("pal", paletteId)
        '                )
        '            ))
        '        )
        '        Dim jsonString = JsonConvert.SerializeObject(jsonData)
        '        Dim content = New StringContent(jsonString, System.Text.Encoding.UTF8, "application/json")

        '        Dim response = Await client.PostAsync(url, content)
        '        response.EnsureSuccessStatusCode() ' Zorg ervoor dat de request succesvol is

        '        Dim responseContent = Await response.Content.ReadAsStringAsync()
        '        Debug.WriteLine($"Palette set response from {ipAddress}: {responseContent}")

        '    Catch ex As Exception
        '        MessageBox.Show($"Fout bij het instellen van palet voor {ipAddress}: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Using
    End Function


    Private Async Function SendUpdatedEffectToWLed(ip As String, effectId As Integer) As Task
        Using client As New HttpClient()
            Try
                ' Bouw de JSON-payload voor het POST-verzoek
                Dim payload As String = "{""seg"":[{""fx"":" & effectId & "}]}"

                Dim content As New StringContent(payload, Encoding.UTF8, "application/json")

                ' Stuur het POST-verzoek naar de WLED API
                Dim postResponse As HttpResponseMessage = Await client.PostAsync("http://" + ip + "/json/state", content)

                ' Lees de volledige responsinhoud
                Dim responseContent As String = Await postResponse.Content.ReadAsStringAsync()

                ' Plaats de respons in het tekstveld
                FrmMain.txt_APIResult.Text = responseContent

                ' Controleer de statuscode van het antwoord
                If postResponse.IsSuccessStatusCode Then
                    FrmMain.txt_APIResult.Text = $"Effect met ID '{effectId}' toegepast op '{ip}'."
                Else
                    MessageBox.Show($"Fout bij het toepassen van effect (HTTP {postResponse.StatusCode}): {responseContent}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As HttpRequestException
                FrmMain.txt_APIResult.Text = $"Fout bij het toepassen van effect: {ex.Message}"
                MessageBox.Show($"Fout bij het toepassen van effect: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Function

    ' New sub to update both Effect and Palette dropdowns for a given row
    Public Sub UpdateEffectAndPaletteDropdowns(ByVal DG_Show As DataGridView, ByVal rowIndex As Integer)
        DG_Show_UpdatePulldownField_For_CurrentEffect(DG_Show, rowIndex)
        DG_Show_UpdatePulldownField_For_CurrentPalette(DG_Show, rowIndex)
    End Sub

End Module
