Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Configuration
Imports System.Net
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Threading

Module DetectDevices
    Private scanForm As Form
    Private progressBar As ProgressBar
    Private foundDevicesLabel As Label
    Private foundDevicesCount As Integer = 0
    Public wledDevices As New Dictionary(Of String, Tuple(Of String, JObject)) ' Dictionary om WLED-apparaten, namen en alle data op te slaan

    Public Function GetCurrentIPRange() As String
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


    Public Async Sub doScanNetwork_Click(DG_Devices As DataGridView, DG_Effecten As DataGridView)

        Dim MyIpRange As String = GetCurrentIPRange()

        foundDevicesCount = 0
        wledDevices.Clear()
        DG_Effecten.Columns.Clear()
        DG_Effecten.Rows.Clear()
        DG_Devices.Rows.Clear() ' Clear de devices list

        ' Lees het IP-bereik uit de applicatie settings
        Dim ipRange As String = My.Settings.IPRange
        If String.IsNullOrEmpty(ipRange) Then
            ipRange = "192.168.86.0/24" ' Standaardwaarde als de setting niet is gevonden
        End If

        If (MyIpRange <> ipRange) Then
            If (MsgBox("Het IP-bereik is gewijzigd naar: " & MyIpRange & ".", MsgBoxStyle.YesNo, "Bevestig") = vbYes) Then
                ipRange = MyIpRange
                If (MsgBox("Wilt u het nieuwe IP-bereik opslaan?", MsgBoxStyle.YesNo, "Opslaan?")) Then
                    My.Settings.IPRange = ipRange
                End If
            End If
        End If

        scanForm = New Form()
        scanForm.Text = "Scannen range " + ipRange
        scanForm.StartPosition = FormStartPosition.CenterScreen
        scanForm.Size = New Size(300, 150)
        scanForm.ControlBox = False

        progressBar = New ProgressBar()
        progressBar.Location = New Point(10, 10)
        progressBar.Size = New Size(250, 20)
        progressBar.Maximum = 254
        progressBar.MarqueeAnimationSpeed = 100
        progressBar.Style = ProgressBarStyle.Blocks

        scanForm.Controls.Add(progressBar)

        foundDevicesLabel = New Label()
        foundDevicesLabel.Location = New Point(10, 40)
        foundDevicesLabel.Size = New Size(280, 20)
        scanForm.Controls.Add(foundDevicesLabel)

        scanForm.Show()


        Await ScanNetwork(ipRange) ' Pas het IP-bereik aan

        scanForm.Close()
        VulEffectenPerWLEDGrid()
        If wledDevices.Count = 0 Then
            MessageBox.Show("Geen WLED apparaten gevonden in het gespecificeerde netwerk.", "Geen apparaten gevonden", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            FrmMain.txt_APIResult.Text = "Gevonden WLED apparaten: " & wledDevices.Count
            UpdateSegmentCounts(DG_Devices)

        End If
    End Sub

    Private Async Function ScanNetwork(ipRange As String) As Task
        Dim tasks As New List(Of Task)
        Dim ipBase As String
        Dim subnetBits As Integer
        Dim baseIpAddress As IPAddress = IPAddress.Parse("192.168.86.0")

        ' Parse het IP-bereik om basis-IP en subnetmasker te verkrijgen
        Dim parts() As String = ipRange.Split("/"c)
        If parts.Length = 2 Then
            ipBase = parts(0)
            If Not Integer.TryParse(parts(1), subnetBits) Then
                MessageBox.Show("Ongeldig subnetmasker formaat.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

        ElseIf parts.Length = 1 Then
            ipBase = parts(0)
            subnetBits = 24 ' Standaard /24 als er geen masker is opgegeven
        Else
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

        ' Loop door alle IP-adressen in het subnet
        For i As UInteger = 0 To addressCount - 1
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
        Next

        Await Task.WhenAll(tasks)
    End Function

    Private Function GetAddressCount(ipRange As String) As Integer
        Dim parts() As String = ipRange.Split("/"c)
        If parts.Length <> 2 Then
            Return 254 ' Standaard /24 als er geen masker is opgegeven of ongeldig formaat
        End If

        Dim subnetBits As Integer
        If Not Integer.TryParse(parts(1), subnetBits) Then
            Return 254 ' Standaard /24 als het masker ongeldig is
        End If

        Return CInt(Math.Pow(2, 32 - subnetBits)) - 2 ' -2 voor netwerk en broadcast adres
    End Function

    Private Async Function CheckIfIpAdressIsWLED(ipAddress As String, scanIndex As Integer) As Task
        Using client As New HttpClient()
            Try
                Dim url As String = $"http://{ipAddress}/json"
                Debug.WriteLine($"Scannen van {url}, index: {scanIndex}")
                Dim response As HttpResponseMessage = Await client.GetAsync(url, New CancellationTokenSource(2000).Token)

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

        ' Controleer of scanIndex niet groter is dan het maximum
        If scanIndex <= progressBar.Maximum Then
            FrmMain.Invoke(Sub() progressBar.Value = scanIndex)
        Else
            FrmMain.Invoke(Sub() progressBar.Value = progressBar.Maximum)
        End If

    End Function

    Private Sub VulEffectenPerWLEDGrid()
        If wledDevices.Count = 0 Then Return

        Dim effectenLijst As New List(Of Tuple(Of Integer, String))()
        Dim paletteLijst As New List(Of Tuple(Of Integer, String))() ' Lijst voor paletten

        For Each wledData In wledDevices.Values
            Dim effectenJArray = TryCast(wledData.Item2("effects"), JArray)
            Dim paletteJArray = TryCast(wledData.Item2("palettes"), JArray)

            If effectenJArray IsNot Nothing Then
                For i As Integer = 0 To effectenJArray.Count - 1
                    Dim effectNaam As String = effectenJArray(i).ToString()
                    If Not effectenLijst.Any(Function(x) x.Item2 = effectNaam) Then
                        effectenLijst.Add(New Tuple(Of Integer, String)(i, effectNaam))
                    End If
                Next
            End If

            If paletteJArray IsNot Nothing Then
                For i As Integer = 0 To paletteJArray.Count - 1
                    Dim paletteNaam As String = paletteJArray(i).ToString()
                    If Not paletteLijst.Any(Function(x) x.Item2 = paletteNaam) Then
                        paletteLijst.Add(New Tuple(Of Integer, String)(i, paletteNaam))
                    End If
                Next
            End If
        Next

        FrmMain.DG_Effecten.Columns.Clear()
        FrmMain.DG_Effecten.Columns.Add("EffectId", "Effect ID")
        FrmMain.DG_Effecten.Columns.Add("Effect", "Effect") ' Effect kolom

        FrmMain.DG_Paletten.Columns.Clear()
        FrmMain.DG_Paletten.Columns.Add("PaletteId", "Palette ID") ' Palette kolom
        FrmMain.DG_Paletten.Columns.Add("Palette", "Palette")

        For Each ipAddress As String In wledDevices.Keys
            Dim wledName As String = wledDevices(ipAddress).Item1
            Dim effectCheckBoxColumn As New DataGridViewCheckBoxColumn()
            effectCheckBoxColumn.Name = wledName
            effectCheckBoxColumn.HeaderText = wledName
            FrmMain.DG_Effecten.Columns.Add(effectCheckBoxColumn)

            Dim paletteCheckBoxColumn As New DataGridViewCheckBoxColumn()
            paletteCheckBoxColumn.Name = wledName
            paletteCheckBoxColumn.HeaderText = wledName
            FrmMain.DG_Paletten.Columns.Add(paletteCheckBoxColumn)
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

        FrmMain.DG_Effecten.Sort(FrmMain.DG_Effecten.Columns("Effect"), System.ComponentModel.ListSortDirection.Ascending)
        FrmMain.DG_Paletten.Sort(FrmMain.DG_Paletten.Columns("Palette"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Public Sub UpdateSegmentCounts(DG_Devices As DataGridView)
        For Each row As DataGridViewRow In DG_Devices.Rows
            Dim ipAddress As String = TryCast(row.Cells("colIPAddress").Value, String)
            If Not String.IsNullOrEmpty(ipAddress) Then
                If wledDevices.ContainsKey(ipAddress) Then
                    Dim wledData As JObject = wledDevices(ipAddress).Item2
                    If wledData IsNot Nothing AndAlso wledData("state") IsNot Nothing Then
                        Dim maxSegments As Integer = TryCast(wledData("state")("seg"), JArray).Count
                        row.Cells("colNumberOfSegments").Value = maxSegments
                    End If
                End If
            End If
        Next
    End Sub
End Module