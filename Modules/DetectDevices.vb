Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net.Http
Imports System.Threading

Module DetectDevices
    Private scanForm As Form
    Private progressBar As ProgressBar
    Private foundDevicesLabel As Label
    Private foundDevicesCount As Integer = 0
    Public wledDevices As New Dictionary(Of String, Tuple(Of String, JObject)) ' Dictionary om WLED-apparaten, namen en alle data op te slaan

    Public Async Sub doScanNetwork_Click(DG_Devices As DataGridView, DG_Effecten As DataGridView)
        foundDevicesCount = 0
        wledDevices.Clear()
        DG_Effecten.Columns.Clear()
        DG_Effecten.Rows.Clear()
        DG_Devices.Rows.Clear() ' Clear de devices list

        scanForm = New Form()
        scanForm.Text = "Scannen..."
        scanForm.StartPosition = FormStartPosition.CenterScreen
        scanForm.Size = New Size(300, 150)
        scanForm.ControlBox = False

        progressBar = New ProgressBar()
        progressBar.Location = New Point(10, 10)
        progressBar.Size = New Size(280, 20)
        progressBar.Maximum = 254
        progressBar.MarqueeAnimationSpeed = 100
        progressBar.Style = ProgressBarStyle.Blocks

        scanForm.Controls.Add(progressBar)

        foundDevicesLabel = New Label()
        foundDevicesLabel.Location = New Point(10, 40)
        foundDevicesLabel.Size = New Size(280, 20)
        scanForm.Controls.Add(foundDevicesLabel)

        scanForm.Show()

        Await ScanNetwork("192.168.86") ' Pas het IP-bereik aan

        scanForm.Close()
        VulEffectenPerWLEDGrid()
        If wledDevices.Count = 0 Then
            MessageBox.Show("Geen WLED apparaten gevonden in het gespecificeerde netwerk.", "Geen apparaten gevonden", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Async Function ScanNetwork(ipBase As String) As Task
        Dim tasks As New List(Of Task)

        For i As Integer = 1 To 254 ' Scan IP-adressen 1 tot 254
            Dim ipAddress As String = $"{ipBase}.{i}"
            tasks.Add(CheckWLED(ipAddress, i))
        Next

        Await Task.WhenAll(tasks)
    End Function

    Private Async Function CheckWLED(ipAddress As String, scanIndex As Integer) As Task
        Using client As New HttpClient()
            Try
                Dim url As String = $"http://{ipAddress}/json"
                Debug.WriteLine($"Scannen van {url}, index: {scanIndex}")
                Dim response As HttpResponseMessage = Await client.GetAsync(url, New CancellationTokenSource(1000).Token)

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

        FrmMain.Invoke(Sub() progressBar.Value = scanIndex)
    End Function


    Private Sub VulEffectenPerWLEDGrid()
        If wledDevices.Count = 0 Then Return

        Dim effectenLijst As New List(Of Tuple(Of Integer, String))()
        Dim paletteLijst As New List(Of Tuple(Of Integer, String))() ' Lijst voor paletten

        For Each wledData In wledDevices.Values
            Dim effectenJArray = TryCast(wledData.Item2("effects"), JArray)
            Dim paletteJArray = TryCast(wledData.Item2("palettes"), JArray) ' Haal paletten op

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
                If checkBoxCell IsNot Nothing AndAlso effectenJArray IsNot Nothing Then
                    If effectenJArray.Contains(effectTuple.Item2) Then
                        checkBoxCell.Value = True
                        checkBoxCell.ReadOnly = True
                    Else
                        checkBoxCell.Value = False
                        checkBoxCell.ReadOnly = False
                    End If
                End If
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
                If checkBoxCell IsNot Nothing AndAlso paletteJArray IsNot Nothing Then
                    If paletteJArray.Contains(paletteTuple.Item2) Then
                        checkBoxCell.Value = True
                        checkBoxCell.ReadOnly = True
                    Else
                        checkBoxCell.Value = False
                        checkBoxCell.ReadOnly = False
                    End If
                End If
            Next
        Next

        FrmMain.DG_Effecten.Sort(FrmMain.DG_Effecten.Columns("Effect"), System.ComponentModel.ListSortDirection.Ascending)
        FrmMain.DG_Paletten.Sort(FrmMain.DG_Paletten.Columns("Palette"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
End Module