Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FrmMain


    Private Sub FrmMain_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Configureer de DataGridView voor de Devices tab
            DG_Devices.Dock = DockStyle.Fill
            DG_Devices.AutoGenerateColumns = False
            DG_Devices.AllowUserToAddRows = False
            DG_Devices.AllowUserToDeleteRows = False
            DG_Devices.ReadOnly = True

            ' Definieer de kolommen voor de DataGridView
            Dim ipColumn As New DataGridViewTextBoxColumn
            ipColumn.Name = "colIPAddress" ' Gewijzigd in colIPAddress
            ipColumn.HeaderText = "IP Address"
            ipColumn.DataPropertyName = "IPAddress"

            Dim nameColumn As New DataGridViewTextBoxColumn
            nameColumn.Name = "colInstance" ' Gewijzigd in colInstance
            nameColumn.HeaderText = "WLED Name"
            nameColumn.DataPropertyName = "WLEDName"

            'DG_Devices.Columns.AddRange(ipColumn, nameColumn)

            ' Configureer de DataGridView voor de Effecten tab
            DG_Effecten.AllowUserToAddRows = False
            DG_Effecten.AllowUserToDeleteRows = False
            DG_Effecten.ReadOnly = True

        Catch ex As Exception
            MessageBox.Show($"Fout tijdens laden van form: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Log de fout eventueel naar een bestand of de Event Viewer
        End Try
    End Sub

    Private Sub btnScanNetwork_Click(sender As Object, e As EventArgs) Handles btnScanNetwork.Click
        doScanNetwork_Click(Me.DG_Devices, Me.DG_Effecten)
    End Sub

    Private Sub DG_Devices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Devices.CellContentClick
        do_Devices_CellContentClick(Me.DG_Devices, Me.txt_APIResult, e)
    End Sub

    Private Async Function ApplyEffect(ip As String, effectId As Integer) As Task
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
                txt_APIResult.Text = responseContent

                ' Controleer de statuscode van het antwoord
                If postResponse.IsSuccessStatusCode Then
                    txt_APIResult.Text = $"Effect met ID '{effectId}' toegepast op '{ip}'."
                Else
                    MessageBox.Show($"Fout bij het toepassen van effect (HTTP {postResponse.StatusCode}): {responseContent}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As HttpRequestException
                txt_APIResult.Text = $"Fout bij het toepassen van effect: {ex.Message}"
                MessageBox.Show($"Fout bij het toepassen van effect: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Function


    Private Async Sub btnApplyEffect_Click(sender As Object, e As EventArgs)
        If DG_Effecten.SelectedRows.Count > 0 Then
            Dim selectedEffectName As String = TryCast(DG_Effecten.SelectedRows(0).Cells("Effect").Value, String)
            Dim selectedWledNaam As String = TryCast(DG_Effecten.SelectedCells(0).OwningColumn.Name, String)
            If selectedEffectName Is Nothing OrElse selectedWledNaam Is Nothing Then
                MessageBox.Show("Ongeldige selectie in de effectenlijst.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim selectedWledIp = ""
            Debug.WriteLine($"btnApplyEffect_Click: selectedEffectName = {selectedEffectName}, selectedWledNaam = {selectedWledNaam}")

            For Each keyValuePair In wledDevices
                If keyValuePair.Value.Item1 = selectedWledNaam Then
                    selectedWledIp = keyValuePair.Key
                    Debug.WriteLine($"btnApplyEffect_Click: Found WLED IP = {selectedWledIp}")
                    Exit For
                End If
            Next

            If selectedWledIp <> "" Then
                Dim effectId = -1
                Dim wledData = wledDevices(selectedWledIp)
                Dim effecten = TryCast(wledData.Item2("effects"), JArray) ' Haal effecten op uit de JObject
                For i = 0 To effecten.Count - 1
                    If effecten(i).ToString() = selectedEffectName Then
                        effectId = i
                        Debug.WriteLine($"btnApplyEffect_Click: Found effectId = {effectId}")
                        Exit For
                    End If
                Next
                If effectId <> -1 Then
                    Await ApplyEffect(selectedWledIp, effectId)
                Else
                    MessageBox.Show("Effect niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("WLED IP niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Selecteer een effect in de lijst.", "Geen effect geselecteerd", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Async Sub DG_Effecten_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Effecten.CellContentClick
        If e.RowIndex < 0 Then Exit Sub ' Make sure it is not header click
        If e.ColumnIndex <= 1 Then Exit Sub ' Make sure it is not the first columns

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
        For Each row As DataGridViewRow In Me.DG_Devices.Rows
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
            For i = 0 To effecten.Count - 1
                If effecten(i).ToString() = effectNaam Then
                    effectId = i
                    Debug.WriteLine($"DG_Effecten_CellContentClick: Found effectId = {effectId}")
                    Exit For
                End If
            Next

            If effectId <> -1 Then
                Await ApplyEffect(wledIp, effectId)
            Else
                MessageBox.Show("Effect niet beschikbaar.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("WLED IP niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub btnSaveShow_Click(sender As Object, e As EventArgs) Handles btnSaveShow.Click
        SaveDataGridViewToXml(DG_Show, "Show.xml")

        MessageBox.Show("All data has been saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadXmlToDataGridView(DG_Show, "Show.xml")
    End Sub
End Class
