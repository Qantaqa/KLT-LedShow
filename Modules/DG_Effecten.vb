Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Module DG_Effecten
    ' *********************************************************************************************
    ' Deze sub werkt de pulldown veld voor effecten, in geval de fixure is gewijzigd
    ' *********************************************************************************************
    Public Sub UpdateEffectenPulldown_ForCurrentFixure(ByVal DG_Show As DataGridView)
        If DG_Show.RowCount = 0 Then
            Exit Sub
        End If
        Dim rowIndex = DG_Show.CurrentRow.Index
        Dim currentRow = DG_Show.Rows(rowIndex)


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
                    For Each kvp In DG_Devices.wledDevices
                        If kvp.Value.Item1 = wledName Then
                            wledIp = kvp.Key
                            Exit For
                        End If
                    Next

                    If wledIp <> "" Then
                        Dim wledData = DG_Devices.wledDevices(wledIp).Item2
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


    ' ****************************************************************************************
    '  Behandel de klik op een cel in de effecten DataGridView. 
    ' ****************************************************************************************
    Public Async Sub Handle_DGEffecten_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs, ByVal DG_Effecten As DataGridView, ByVal DG_Devices As DataGridView)
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

        Debug.WriteLine($"Handle_DGEffecten_CellContentClick: effectNaam = {effectNaam}, wledNaam = {wledNaam}")

        ' Haal het IP-adres op uit DG_Devices
        For Each row As DataGridViewRow In DG_Devices.Rows
            If TryCast(row.Cells("colInstance").Value, String) = wledNaam Then
                wledIp = TryCast(row.Cells("colIPAddress").Value, String)
                Debug.WriteLine($"Handle_DGEffecten_CellContentClick: Found WLED IP = {wledIp}")
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
                        Debug.WriteLine($"Handle_DGEffecten_CellContentClick: Found effectId = {effectId}")
                        ToonFlashBericht(wledNaam & " op segment 0 effect " & effectNaam & " toegepast.", 2)
                        Exit For
                    End If
                Next
            End If

            If effectId <> -1 Then
                Await SendEffectToWLed(wledIp, "1", effectId)
            Else
                MessageBox.Show("Effect niet beschikbaar.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("WLED IP niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    ' ****************************************************************************************  
    '  Update de effectenpulldown in de DataGridView voor elk WLED-apparaat.
    ' ****************************************************************************************
    Public Sub Update_DGEffecten_BasedOnTuple()
        If wledDevices.Count = 0 Then Return

        Dim effectenLijst As New List(Of Tuple(Of Integer, String))()


        For Each wledData In wledDevices.Values
            Dim effectenJArray = TryCast(wledData.Item2("effects"), JArray)

            If effectenJArray IsNot Nothing Then
                For i As Integer = 0 To effectenJArray.Count - 1
                    Dim effectNaam As String = effectenJArray(i).ToString()
                    If Not effectenLijst.Any(Function(x) x.Item2 = effectNaam) Then
                        effectenLijst.Add(New Tuple(Of Integer, String)(i, effectNaam))
                    End If
                Next
            End If

        Next

        FrmMain.DG_Effecten.Columns.Clear()
        FrmMain.DG_Effecten.Columns.Add("EffectId", "Effect ID")
        FrmMain.DG_Effecten.Columns.Add("Effect", "Effect") ' Effect kolom


        For Each ipAddress As String In wledDevices.Keys
            Dim wledName As String = wledDevices(ipAddress).Item1
            Dim effectCheckBoxColumn As New DataGridViewCheckBoxColumn()
            effectCheckBoxColumn.Name = wledName
            effectCheckBoxColumn.HeaderText = wledName
            FrmMain.DG_Effecten.Columns.Add(effectCheckBoxColumn)

        Next

        FrmMain.DG_Effecten.Rows.Clear()
        ' Voeg effecten toe

        For Each effectTuple As Tuple(Of Integer, String) In effectenLijst
            Dim rowIndex As Integer = FrmMain.DG_Effecten.Rows.Add(effectTuple.Item1, effectTuple.Item2)

            For Each ipAddress As String In wledDevices.Keys
                Dim wledName = wledDevices(ipAddress).Item1
                Dim wledData = wledDevices(ipAddress).Item2
                Dim effectenJArray = TryCast(wledData("effects"), JArray)
                Dim checkBoxCell As DataGridViewCheckBoxCell = TryCast(FrmMain.DG_Effecten.Rows(rowIndex).Cells(wledName), DataGridViewCheckBoxCell)
                checkBoxCell.Value = True

                'End If
            Next
        Next

        FrmMain.DG_Effecten.Sort(FrmMain.DG_Effecten.Columns("Effect"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    ' *********************************************************
    ' Deze functie haalt de effectnaam op uit de effect ID
    ' *********************************************************
    Public Function GetEffectNameFromId(ByVal effectId As String, ByVal DG_Effects As DataGridView) As String
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

    ' *********************************************************
    ' Deze functie haalt de effectnaam op uit de effect ID
    ' *********************************************************
    Public Function GetEffectIdFromName(ByVal SearchEffectName As String, ByVal DG_Effects As DataGridView) As String
        ' Zoek de effectid in de DG_Effects DataGridView.
        For Each effectRow As DataGridViewRow In DG_Effects.Rows
            Dim effectIdCellValue = effectRow.Cells("EffectId").Value
            Dim effectNameCellValue = effectRow.Cells("Effect").Value

            If effectNameCellValue IsNot Nothing AndAlso effectNameCellValue.ToString() = SearchEffectName Then
                ' Zorg ervoor dat je de juiste datatype vergelijkt.
                If effectIdCellValue IsNot Nothing Then
                    Return effectIdCellValue.ToString()
                Else
                    Return "" ' Of een andere standaardwaarde als de naam null is
                End If
            End If
        Next
        Return "Unknown Effect" ' Retourneer dit als het effect niet wordt gevonden
    End Function


    ' ****************************************************************************************
    '  Deze functie controleert of de effecten bestaan en toont een vinkje of kruisje in de DataGridView
    ' ****************************************************************************************
    Public Sub TextExistanceEffects(ByVal DG_Effecten As DataGridView, ByVal effectsImagePath As String)
        ' Controleer of de DataGridView geldig is.
        If DG_Effecten Is Nothing Then
            Return
        End If

        ' Voeg de kolom toe als deze nog niet bestaat.
        If DG_Effecten.Columns.Contains("colExists") = False Then
            Dim imageColumn As New DataGridViewImageColumn()
            imageColumn.Name = "colExists"
            imageColumn.HeaderText = "Exists"
            imageColumn.Width = 50
            DG_Effecten.Columns.Add(imageColumn)
        End If

        ' Loop door alle rijen in de DataGridView.
        For Each row As DataGridViewRow In DG_Effecten.Rows
            ' Haal de effectnaam op.
            Dim effectName As String = TryCast(row.Cells("Effect").Value, String)
            If Not String.IsNullOrEmpty(effectName) Then
                ' Stel het pad naar de image samen.
                Dim imagePath As String = Path.Combine(effectsImagePath, effectName.Replace(" ", "_") & ".gif")

                ' Controleer of het bestand bestaat.
                If File.Exists(imagePath) Then
                    ' Stel de celwaarde in op een groene vink.
                    row.Cells("colExists").Value = My.Resources.iconGreenBullet1

                Else
                    ' Stel de celwaarde in op een rood kruis.
                    row.Cells("colExists").Value = My.Resources.iconRedBullet1

                End If
            Else
                row.Cells("colExists").Value = DBNull.Value
            End If
        Next
    End Sub

End Module
