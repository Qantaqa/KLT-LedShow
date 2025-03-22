Imports Newtonsoft.Json.Linq
Imports System.Net.Http

Module CommandWLed

    Private Async Function GetWledStatus(url As String, txt_APIResult As TextBox) As Task
        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                response.EnsureSuccessStatusCode()
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                txt_APIResult.Text = responseBody

                ' Parse de JSON-respons
                Dim json As JObject = JObject.Parse(responseBody)



            Catch ex As HttpRequestException
                txt_APIResult.Text = "Fout: " & ex.Message
            End Try
        End Using
    End Function



    Public Sub do_Devices_CellContentClick(DG_Devices As DataGridView, txt_APIResult As TextBox, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub ' Make sure it is not header click
        Dim currentRow = DG_Devices.Rows(e.RowIndex)
        Dim ip = Convert.ToString(currentRow.Cells("colIPAddress").Value) ' Gebruik colIPAddress
        ' Add logging
        txt_APIResult.Text = $"Ophalen van status van {ip}..."
        Debug.WriteLine($"DG_Devices_CellContentClick: IP Address = {ip}") ' Log the IP
        Dim task = GetWledStatus("http://" + ip + "/json", txt_APIResult)
    End Sub





End Module
