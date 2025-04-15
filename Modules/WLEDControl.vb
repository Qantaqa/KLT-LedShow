Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq

Module WLEDControl


    Public Async Sub SendOnOffToWLed(IPAddress As String, Segment As String, state As String)
        Dim Payload As String
        If state.ToLower() = "on" Then
            Payload = "{""seg"":[{""on"":true,""id"":""" & Segment & """}]}"
        Else
            Payload = "{""seg"":[{""on"":false,""id"":""" & Segment & """}]}"
        End If
        ' Bouw de JSON-payload voor het POST-verzoek



        Dim content As New StringContent(Payload, Encoding.UTF8, "application/json")

        Await SendJsonToWLED2(IPAddress, content)
    End Sub




    ' **********************************************************
    ' Deze sub roept de WLED api aan om de kleuren in te stellen
    ' **********************************************************
    Public Async Sub SendColorsToWLed(ipAddress As String, color1 As Integer, color2 As Integer, color3 As Integer)
        Dim color1Value = ColorTranslator.FromOle(color1)
        Dim color2Value = ColorTranslator.FromOle(color2)
        Dim color3Value = ColorTranslator.FromOle(color3)
        Dim colorsArray = New JArray()
        colorsArray.Add(New JArray(color1Value.R, color1Value.G, color1Value.B))
        colorsArray.Add(New JArray(color2Value.R, color2Value.G, color2Value.B))
        colorsArray.Add(New JArray(color3Value.R, color3Value.G, color3Value.B))

        Dim payload = New JObject From {
            {"seg", New JArray(
                New JObject From {
                    {"col", colorsArray}
                }
            )}
        }

        Dim content As New StringContent(payload, Encoding.UTF8, "application/json")
        Await SendJsonToWLED2(ipAddress, content)
    End Sub







    ' ****************************************************************************************
    '  Stuur een effect naar de WLED-instantie.
    ' ****************************************************************************************
    Public Async Function SendEffectToWLed(IPAddress As String, Segment As String, effectId As Integer) As Task
        Using client As New HttpClient()
            Try
                ' Bouw de JSON-payload voor het POST-verzoek
                Dim payload As String = "{""seg"":[{""fx"":" & effectId & ",""id"":""" & Segment & """}]}"

                Dim content As New StringContent(payload, Encoding.UTF8, "application/json")

                ' Stuur het POST-verzoek naar de WLED API
                Dim postResponse As HttpResponseMessage = Await client.PostAsync("http://" + IPAddress + "/json/state", content)

                ' Lees de volledige responsinhoud
                Dim responseContent As String = Await postResponse.Content.ReadAsStringAsync()

                ' Plaats de respons in het tekstveld
                FrmMain.txt_APIResult.Text = responseContent

                ' Controleer de statuscode van het antwoord
                If postResponse.IsSuccessStatusCode Then
                    FrmMain.txt_APIResult.Text = $"Effect met ID '{effectId}' toegepast op '{IPAddress }'."
                Else
                    MessageBox.Show($"Fout bij het toepassen van effect (HTTP {postResponse.StatusCode}): {responseContent}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As HttpRequestException
                FrmMain.txt_APIResult.Text = $"Fout bij het toepassen van effect: {ex.Message}"
                MessageBox.Show($"Fout bij het toepassen van effect: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Function


    ' *********************************************************
    ' Deze functie stuurt een POST-verzoek naar de WLED API om het effect toe te passen
    ' *********************************************************
    Public Async Function SendPaletteToWLed(ipAddress As String, paletteId As Integer) As Task
        ' Bouw de JSON-payload voor het POST-verzoek
        Dim payload As String = "{""seg"":[{""pal"":" & paletteId & "}]}"
        Dim content As New StringContent(payload, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Try

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
    End Function













    ' **********************************************************
    ' Deze functie stuurt de JSON payload naar de WLED API
    ' **********************************************************
    Private Async Function SendJsonToWLED2(ipAddress As String, content As StringContent) As Task
        Dim client As New HttpClient()
        Try
            ' Stuur het POST-verzoek naar de WLED API
            Dim postResponse As HttpResponseMessage = Await client.PostAsync("http://" + ipAddress + "/json/state", content)
            postResponse.EnsureSuccessStatusCode()                                                                               ' Throw on error status

            ' Lees de volledige responsinhoud
            Dim responseContent As String = Await postResponse.Content.ReadAsStringAsync()

            ' Plaats de respons in het tekstveld
            FrmMain.txt_APIResult.Text = responseContent



            ' Controleer de statuscode van het antwoord
            If postResponse.IsSuccessStatusCode Then
                FrmMain.txt_APIResult.Text = $"Succes"
            Else
                MessageBox.Show($"Fout bij het verzenden van commando naar WLED {ipAddress}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As HttpRequestException
            MessageBox.Show($"Fout bij het verzenden van commando naar WLED {ipAddress}: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FrmMain.txt_APIResult.Text = $"Fout: {ex.Message}"


        Catch ex As Exception
            MessageBox.Show($"Onverwachte fout: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FrmMain.txt_APIResult.Text = $"Fout: {ex.Message}"

        End Try

    End Function



End Module
