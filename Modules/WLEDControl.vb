Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks.Dataflow
Imports System.Windows.Forms.AxHost
Imports Newtonsoft.Json.Linq

Module WLEDControl


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




    Public Async Sub Apply_DGShowRow_ToWLED(ByVal DG_Show As DataGridView, ByVal DG_Devices As DataGridView, ByVal DG_Effecten As DataGridView, ByVal DG_Paletten As DataGridView, notify As Boolean)
        Dim Payload As String = ""          ' JSON payload
        Dim Segment As String = ""          ' Segment of de WLED
        Dim wledIp As String = ""           ' IPAddress Of WLED
        Dim wledName As String = ""
        Dim stateOnOff As String = "True"
        Dim effectId As String = ""
        Dim effectName As String = ""
        Dim paletteId As String = ""
        Dim paletteName As String = ""
        Dim Speed As String = "127"
        Dim Brightness As String = "255"
        Dim Intensity As String = "127"


        If DG_Show.RowCount = 0 Then
            Exit Sub
        End If

        ' Controleer of er een rij is geselecteerd
        If DG_Show.CurrentCell IsNot Nothing And Not DG_Show.CurrentRow.IsNewRow Then
            Dim currentRow = DG_Show.Rows(DG_Show.CurrentCell.RowIndex)

            Dim selectedFixture = currentRow.Cells("colFixture").Value                      ' De geselecteerde fixture
            If selectedFixture IsNot Nothing And selectedFixture.substring(0, 2) <> "**" Then      ' Als deze niet een beamer is
                Dim fixtureParts = selectedFixture.ToString().Split("/").ToArray()          ' De fixture naam en segment
                If fixtureParts.Length = 2 Then
                    wledName = fixtureParts(0)                                              ' De naam van de fixture
                    Segment = Integer.Parse(fixtureParts(1))

                    For Each row In DG_Devices.Rows
                        If row.cells("colInstance").value = wledName Then
                            wledIp = row.cells("colIPAddress").value
                            Exit For
                        End If
                    Next

                    If wledIp <> "" Then
                        ' Er is een IP adres aanwezig. Bouw de JSON payload

                        ' Segment aan of uit
                        stateOnOff = currentRow.Cells("colStateOnOff").Value
                        If stateOnOff = "Uit" Then
                            stateOnOff = "false"
                        Else
                            stateOnOff = "true"
                        End If

                        effectName = currentRow.Cells("colEffect").Value
                        effectId = GetEffectIdFromName(effectName, DG_Effecten)
                        paletteName = currentRow.Cells("colPalette").Value
                        paletteId = GetPaletteIdFromName(paletteName, DG_Paletten)

                        Brightness = currentRow.Cells("colBrightness").Value


                        Payload = "{" &
                                  """seg"": [" &
                                  "{" &
                                  """id"": " & Segment.ToString() & "," &   ' Segment id
                                  """on"": " & stateOnOff.ToLower() & "," & ' Segment On or off
                                  """fx"": " & effectId & "," &             ' Effect
                                  """pal"": " & paletteId & "," &           ' Palette
                                  """sel"": true," &                        ' Selected
                                  """bri"": " & Brightness &                ' Brighness
                                  "}" &
                                  "]" &
                                  "}"
                    End If
                End If
            End If


            Dim content As New StringContent(Payload, Encoding.UTF8, "application/json")

            Await SendJsonToWLED2(wledIp, content)

            If (notify) Then
                ' Toon een melding dat het effect is toegepast
                ToonFlashBericht("Segment " & Segment & " van " & wledName & " is ingesteld op " & effectName & " met palette " & paletteName, 2)
            End If
        End If
    End Sub

    Public Sub Apply_Selected_Rows(DG_Show As DataGridView)
        Dim rowNr As Integer = 0

        For Each row In DG_Show.Rows
            If row.cells("btnApply").value = ">" Then
                rowNr = row.index
                'Stel de focus op de nieuwe rij
                DG_Show.CurrentCell = DG_Show.Rows(rowNr).Cells(0)
                Apply_DGShowRow_ToWLED(DG_Show, FrmMain.DG_Devices, FrmMain.DG_Effecten, FrmMain.DG_Paletten, False)

            End If
        Next
    End Sub



End Module


