Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Threading
Module Network
    Private Const TimeoutValue = 5000       ' Aantal milliseconden voor de timeout afgaat bij testen of het een WLED device is

    Private foundDevicesLabel As Label
    Private foundDevicesCount As Integer = 0
    Private progressBar As ProgressBar
    Private progressPopUpForm As Form

    '*************************************************************************************************
    ' Functie om het IP-bereik te berekenen op basis van een IP-adres en subnetmasker   
    '*************************************************************************************************
    Private Function CalculateIPRange(ipAddress As IPAddress, subnetMask As IPAddress) As String
        Dim ipBytes As Byte() = ipAddress.GetAddressBytes()
        Dim maskBytes As Byte() = subnetMask.GetAddressBytes()
        Dim networkAddressBytes(3) As Byte

        For i As Integer = 0 To 3
            networkAddressBytes(i) = ipBytes(i) And maskBytes(i)
        Next

        Dim networkAddress As New IPAddress(networkAddressBytes)
        Dim cidr As Integer = maskBytes.Sum(Function(b) Convert.ToString(b, 2).Count(Function(c) c = "1"c))

        Return $"{networkAddress}/{cidr}"
    End Function


    '*************************************************************************************************  
    ' Functie om het huidige IP-bereik van de actieve netwerkinterface te verkrijgen    
    '*************************************************************************************************  
    Private Function GetCurrentIPRange() As String
        Dim ipRange As String = String.Empty

        For Each networkInterface As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
            If networkInterface.NetworkInterfaceType = NetworkInterfaceType.Wireless80211 AndAlso networkInterface.OperationalStatus = OperationalStatus.Up Then
                Dim ipProperties As IPInterfaceProperties = networkInterface.GetIPProperties()
                For Each ipAddressInfo As UnicastIPAddressInformation In ipProperties.UnicastAddresses
                    If ipAddressInfo.Address.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                        Dim ipAddress As IPAddress = ipAddressInfo.Address
                        Dim subnetMask As IPAddress = ipAddressInfo.IPv4Mask
                        ipRange = CalculateIPRange(ipAddress, subnetMask)
                        Exit For
                    End If
                Next
            End If
        Next

        Return ipRange
    End Function



    ' ************************************************************************************************* 
    ' Functie om te controleren of een IP-adres een WLED-apparaat is
    ' *************************************************************************************************
    Private Async Function CheckIfIpAdressIsWLED(ipAddress As String, scanIndex As Integer) As Task
        Using client As New HttpClient()
            Try
                Dim url As String = $"http://{ipAddress}/json"
                Debug.WriteLine($"Scannen van {url}, index: {scanIndex}")
                Dim response As HttpResponseMessage = Await client.GetAsync(url, New CancellationTokenSource(TimeoutValue).Token)

                Debug.WriteLine($"HTTP statuscode voor {ipAddress}: {response.StatusCode}")

                If response.IsSuccessStatusCode Then
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                    Try
                        Dim json As JObject = JObject.Parse(responseBody)
                        Dim wledName As String = json("info")("name").ToString()

                        ' Sla het volledige JSON object op, niet alleen de effecten
                        wledDevices.Add(ipAddress, New Tuple(Of String, JObject)(wledName, json))

                        FrmMain.Invoke(Sub()
                                           foundDevicesCount += 1
                                           foundDevicesLabel.Text = $"Gevonden apparaten: {foundDevicesCount}"
                                           FrmMain.DG_Devices.Rows.Add(ipAddress, wledName)
                                       End Sub)
                    Catch jsonEx As JsonReaderException
                        Debug.WriteLine($"Fout bij het parsen van JSON van {ipAddress}: {jsonEx.Message}")
                    Catch nullEx As NullReferenceException
                        Debug.WriteLine($"Fout bij het ophalen van gegevens van {ipAddress}: {nullEx.Message}")
                    End Try
                Else
                    Debug.WriteLine($"HTTP fout bij scannen van {ipAddress}: {response.StatusCode}")
                End If
            Catch ex As Exception
                Debug.WriteLine($"Fout bij scannen van {ipAddress}: {ex.Message}")
            End Try
        End Using
    End Function


    ' *************************************************************************************************
    ' Functie om het netwerk te scannen op WLED-apparaten
    ' *************************************************************************************************
    Private Async Function ScanNetworkRange(ipRange As String) As Task
        Dim tasks As New List(Of Task)
        Dim ipBase As String
        Dim subnetBits As Integer
        Dim baseIpAddress As IPAddress = IPAddress.Parse("192.168.86.0")

        ' Parse het IP-bereik om basis-IP en subnetmasker te verkrijgen
        Dim parts() As String = ipRange.Split("/"c)
        If parts.Length = 2 Then
            ' Als er een subnetmasker is opgegeven, splits het dan
            ipBase = parts(0)
            If Not Integer.TryParse(parts(1), subnetBits) Then
                MessageBox.Show("Ongeldig subnetmasker formaat.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        ElseIf parts.Length = 1 Then
            ' Als er geen subnetmasker is opgegeven, gebruik dan standaard /24
            ipBase = parts(0)
            subnetBits = 24 ' Standaard /24 als er geen masker is opgegeven
        Else
            ' Ongeldig IP -bereik formaat
            MessageBox.Show("Ongeldig IP-bereik formaat.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        ' Zet het basis-IP om naar een IPAddress object
        If Not IPAddress.TryParse(ipBase, baseIpAddress) Then
            MessageBox.Show("Ongeldig IP-adres formaat.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Zet het IP-adres om naar een integer voor bitwise operaties
        Dim baseIpBytes As Byte() = baseIpAddress.GetAddressBytes()
        If baseIpBytes.Length <> 4 Then
            MessageBox.Show("Ongeldig IP-adres formaat (IPv4 verwacht).", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim baseIpInt As UInteger = CUInt(baseIpBytes(0)) << 24 Or CUInt(baseIpBytes(1)) << 16 Or CUInt(baseIpBytes(2)) << 8 Or CUInt(baseIpBytes(3))

        ' Bereken het aantal adressen in het subnet
        Dim addressCount As UInteger = CUInt(Math.Pow(2, 32 - subnetBits))
        Dim progressBarValue As Integer = 0

        ' Loop door alle IP-adressen in het subnet
        For i As UInteger = 0 To addressCount - 1
            progressBarValue = CInt(i)

            ' Bereken het IP-adres door de offset toe te voegen
            Dim currentIpInt As UInteger = baseIpInt + i

            ' Zet de integer terug om naar een IPAddress
            Dim currentIpBytes As Byte() = {
                CByte(currentIpInt >> 24),
                CByte(currentIpInt >> 16 And 255),
                CByte(currentIpInt >> 8 And 255),
                CByte(currentIpInt And 255)
            }
            Dim currentIpAddress As IPAddress = New IPAddress(currentIpBytes)
            Dim currentIpString = currentIpAddress.ToString()

            tasks.Add(CheckIfIpAdressIsWLED(currentIpString, CInt(i)))

            ' Controleer of scanIndex niet groter is dan het maximum
            If progressBarValue <= progressBar.Maximum Then
                FrmMain.Invoke(Sub() progressBar.Value = progressBarValue)
            Else
                FrmMain.Invoke(Sub() progressBar.Value = progressBar.Maximum)
            End If

        Next

        Await Task.WhenAll(tasks)
    End Function




    ' *************************************************************************************************
    ' Handler voor de knop om het netwerk te scannen
    ' *************************************************************************************************
    Public Async Sub ScanNetworkForWLEDdevices(DG_Devices As DataGridView, DG_Effecten As DataGridView, DG_Show As DataGridView)

        ' Haal het huidige IP-bereik op
        Dim MyIpRange As String = GetCurrentIPRange()


        ' Initialiseer variabelen
        foundDevicesCount = 0

        ' Clear de devices, effecten en paletten lists
        wledDevices.Clear()
        DG_Effecten.Columns.Clear()
        DG_Effecten.Rows.Clear()
        DG_Devices.Rows.Clear()


        ' Lees het IP-bereik uit de applicatie settings
        Dim ipRange As String = My.Settings.IPRange
        If String.IsNullOrEmpty(ipRange) Then
            ipRange = "192.168.86.0/24" ' Standaardwaarde als de setting niet is gevonden
        End If

        ' Als het IP-bereik is gewijzigd, vraag de gebruiker om bevestiging
        If (MyIpRange <> ipRange) Then
            If (MsgBox("Het IP-bereik is gewijzigd naar: " & MyIpRange & ".", MsgBoxStyle.YesNo, "Bevestig") = vbYes) Then
                ipRange = MyIpRange
                If (MsgBox("Wilt u het nieuwe IP-bereik opslaan?", MsgBoxStyle.YesNo, "Opslaan?")) Then
                    My.Settings.IPRange = ipRange
                End If
            End If
        End If


        ' Maak een nieuw formulier voor de voortgang te kunnen tonen
        progressPopUpForm = New Form()
        progressPopUpForm.Text = "Scannen range " + ipRange
        progressPopUpForm.StartPosition = FormStartPosition.CenterScreen
        progressPopUpForm.Size = New Size(300, 150)
        progressPopUpForm.ControlBox = False

        progressBar = New ProgressBar()
        progressBar.Location = New Point(10, 10)
        progressBar.Size = New Size(250, 20)
        progressBar.Maximum = 254
        progressBar.MarqueeAnimationSpeed = 100
        progressBar.Style = ProgressBarStyle.Blocks

        progressPopUpForm.Controls.Add(progressBar)

        foundDevicesLabel = New Label()
        foundDevicesLabel.Location = New Point(10, 40)
        foundDevicesLabel.Size = New Size(280, 20)

        progressPopUpForm.Controls.Add(foundDevicesLabel)

        progressPopUpForm.Show()


        ' Start de netwerk scan
        Await ScanNetworkRange(ipRange)

        ' Sluit het voortgangsformulier
        progressPopUpForm.Close()


        ' Controleer of er apparaten zijn gevonden
        If wledDevices.Count = 0 Then
            MessageBox.Show("Geen WLED apparaten gevonden op het netwerk (" + ipRange + ").", "Geen apparaten gevonden", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            FrmMain.txt_APIResult.Text = "Gevonden WLED apparaten: " & wledDevices.Count

            UpdateFixuresPulldown(DG_Show)

            ' Werk de effecten en paletten bij voor de gevonden apparaten
            UpdateEffectenPulldown_ForEachWLED()
            UpdatePalettenPulldown_ForEachWLED()

            ' Werk het aantal segmenten bij voor de gevonden apparaten
            UpdateSegmenten_PerWLED(DG_Devices)
        End If
    End Sub

End Module
