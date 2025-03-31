Imports System.Diagnostics  ' Toegevoegd voor Process.Start
Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports System.Threading.Tasks

Module WLEDControl

    ''' <summary>
    ''' Stuurt een HTTP-verzoek naar de WLED-instantie om het palet in te stellen.
    ''' </summary>

    '  Haal de WLED-status op en toon deze in het tekstvak.
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

    '  Handel de klik op een cel in de DG_Devices DataGridView af.
    '  Opent de WLED-website in de standaardbrowser.
    Public Sub do_Devices_CellContentClick(DG_Devices As DataGridView, txt_APIResult As TextBox, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub ' Zorg ervoor dat er niet op de header is geklikt.

        Try
            ' Haal het IP-adres op van de geselecteerde rij.
            Dim ipAddress As String = Convert.ToString(DG_Devices.Rows(e.RowIndex).Cells("colIPAddress").Value)

            ' Controleer of het IP-adres geldig is.
            If Not String.IsNullOrEmpty(ipAddress) Then
                ' Open de WLED-website in de standaardbrowser.
                Process.Start(New ProcessStartInfo($"http://{ipAddress}") With {.UseShellExecute = True})
            Else
                txt_APIResult.Text = "Ongeldig IP-adres."
            End If

        Catch ex As Exception
            txt_APIResult.Text = "Fout bij het openen van de browser: " & ex.Message
        End Try
    End Sub

End Module
