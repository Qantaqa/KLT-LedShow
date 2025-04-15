Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq

Module DG_Paletten

    ' *********************************************************************************************
    ' Deze sub werkt de pulldown veld voor palette, in geval de fixure is gewijzigd
    ' *********************************************************************************************
    Public Sub UpdatePalettePulldown_ForCurrentFixure(ByVal DG_Show As DataGridView)
        Dim RowIndex = DG_Show.CurrentRow.Index
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
                    For Each kvp In DG_Devices.wledDevices
                        If kvp.Value.Item1 = wledName Then
                            wledIp = kvp.Key
                            Exit For
                        End If
                    Next

                    If wledIp <> "" Then
                        Dim wledData = DG_Devices.wledDevices(wledIp).Item2
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



    ' *********************************************************************************************
    ' behandelt de klik op een cel in de paletten DataGridView.
    ' *********************************************************************************************
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
                Await SendPaletteToWLed(wledIp, paletteId)
            Else
                MessageBox.Show("Palet niet beschikbaar.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("WLED IP niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    ' *********************************************************************************************
    ' Update de paletten pulldown voor alle WLED apparaten
    ' *********************************************************************************************
    Public Sub UpdatePalettenPulldown_ForEachWLED()
        If wledDevices.Count = 0 Then Return

        Dim paletteLijst As New List(Of Tuple(Of Integer, String))() ' Lijst voor paletten

        For Each wledData In wledDevices.Values
            Dim paletteJArray = TryCast(wledData.Item2("palettes"), JArray)


            If paletteJArray IsNot Nothing Then
                For i As Integer = 0 To paletteJArray.Count - 1
                    Dim paletteNaam As String = paletteJArray(i).ToString()
                    If Not paletteLijst.Any(Function(x) x.Item2 = paletteNaam) Then
                        paletteLijst.Add(New Tuple(Of Integer, String)(i, paletteNaam))
                    End If
                Next
            End If
        Next

        FrmMain.DG_Paletten.Columns.Clear()
        FrmMain.DG_Paletten.Columns.Add("PaletteId", "Palette ID") ' Palette kolom
        FrmMain.DG_Paletten.Columns.Add("Palette", "Palette")

        For Each ipAddress As String In wledDevices.Keys
            Dim wledName As String = wledDevices(ipAddress).Item1

            Dim paletteCheckBoxColumn As New DataGridViewCheckBoxColumn()
            paletteCheckBoxColumn.Name = wledName
            paletteCheckBoxColumn.HeaderText = wledName
            FrmMain.DG_Paletten.Columns.Add(paletteCheckBoxColumn)
        Next

        FrmMain.DG_Paletten.Rows.Clear()

        ' Voeg Paletten toe
        For Each paletteTuple As Tuple(Of Integer, String) In paletteLijst
            Dim rowIndex As Integer = FrmMain.DG_Paletten.Rows.Add(paletteTuple.Item1, paletteTuple.Item2)

            For Each ipAddress As String In wledDevices.Keys
                Dim wledName = wledDevices(ipAddress).Item1
                Dim wledData = wledDevices(ipAddress).Item2
                Dim paletteJArray = TryCast(wledData("palettes"), JArray)
                Dim checkBoxCell As DataGridViewCheckBoxCell = TryCast(FrmMain.DG_Paletten.Rows(rowIndex).Cells(wledName), DataGridViewCheckBoxCell)
                checkBoxCell.Value = True

            Next
        Next

        FrmMain.DG_Paletten.Sort(FrmMain.DG_Paletten.Columns("Palette"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub


    ' *********************************************************
    ' Deze functie haalt de palettenaam op aan de hand van het palette-ID 
    ' *********************************************************
    Public Function GetPaletteNameFromId(ByVal paletteId As String, ByVal DG_Palette As DataGridView) As String
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



End Module
