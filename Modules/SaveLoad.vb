Imports System.IO
Imports System.Runtime
Imports System.Xml
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module SaveLoad

    Public Sub SaveDataGridViewToXml(dataGridView As DataGridView, filePath As String)
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        settings.IndentChars = "    "

        Using writer As XmlWriter = XmlWriter.Create(filePath, settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("DataGridData")

            ' Sla de structuur van de DataGridView op
            writer.WriteStartElement("Structure")
            For Each column As DataGridViewColumn In dataGridView.Columns
                writer.WriteStartElement("Column")
                writer.WriteAttributeString("Name", column.Name.Replace(" ", "_")) ' Vervang spaties door underscores
                writer.WriteAttributeString("Type", column.GetType().ToString())
                ' Voeg lengte toe als attribuut (als van toepassing)
                If TypeOf column Is DataGridViewTextBoxColumn Then
                    Dim textColumn As DataGridViewTextBoxColumn = DirectCast(column, DataGridViewTextBoxColumn)
                    writer.WriteAttributeString("MaxLength", textColumn.MaxInputLength.ToString())
                End If
                ' Voeg AutoSizeMode toe als attribuut
                writer.WriteAttributeString("AutoSizeMode", column.AutoSizeMode.ToString())
                writer.WriteEndElement()
            Next
            writer.WriteEndElement()

            ' Sla de data van de DataGridView op
            writer.WriteStartElement("Data")
            For Each row As DataGridViewRow In dataGridView.Rows
                writer.WriteStartElement("Row")
                For Each cell As DataGridViewCell In row.Cells
                    writer.WriteStartElement(dataGridView.Columns(cell.ColumnIndex).Name.Replace(" ", "_")) ' Vervang spaties door underscores
                    If cell.Value IsNot Nothing Then
                        If dataGridView.Columns(cell.ColumnIndex).Name = "colDDPData" AndAlso TypeOf cell.Value Is Byte() Then
                            writer.WriteString(Convert.ToBase64String(CType(cell.Value, Byte())))
                        Else
                            writer.WriteString(cell.Value.ToString())
                        End If
                    Else
                        writer.WriteString("")
                    End If
                    writer.WriteEndElement()
                Next
                writer.WriteEndElement()
            Next
            writer.WriteEndElement()

            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub




    Public Sub LoadXmlToDataGridView(dataGridView As DataGridView, filePath As String, inclusiveLayout As Boolean)
        If Not File.Exists(filePath) Then
            MessageBox.Show($"Bestand '{filePath}' niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim doc As New XmlDocument()
            doc.Load(filePath)

            ' Clear existing data
            dataGridView.Rows.Clear()


            If (inclusiveLayout) Then
                dataGridView.Columns.Clear()
                ' Load the structure of the DataGridView
                Dim structureNode As XmlNode = doc.SelectSingleNode("DataGridData/Structure")
                If structureNode IsNot Nothing Then
                    For Each columnNode As XmlNode In structureNode.ChildNodes
                        Dim columnName As String = columnNode.Attributes("Name").Value.Replace("_", " ") ' Replace underscores with spaces
                        Dim columnType As String = columnNode.Attributes("Type").Value

                        ' Create the column based on the type
                        Dim newColumn As DataGridViewColumn = Nothing
                        If columnType = GetType(DataGridViewCheckBoxColumn).ToString() Then
                            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                            checkBoxColumn.Name = columnName
                            checkBoxColumn.HeaderText = columnName
                            If columnNode.Attributes("AutoSizeMode") IsNot Nothing Then
                                checkBoxColumn.AutoSizeMode = DirectCast(System.Enum.Parse(GetType(DataGridViewAutoSizeColumnMode), columnNode.Attributes("AutoSizeMode").Value), DataGridViewAutoSizeColumnMode)
                            End If
                            newColumn = checkBoxColumn
                        Else
                            Dim textColumn As New DataGridViewTextBoxColumn()
                            textColumn.Name = columnName
                            textColumn.HeaderText = columnName
                            ' Load MaxLength if available
                            If columnNode.Attributes("MaxLength") IsNot Nothing Then
                                textColumn.MaxInputLength = Integer.Parse(columnNode.Attributes("MaxLength").Value)
                            End If
                            If columnNode.Attributes("AutoSizeMode") IsNot Nothing Then
                                textColumn.AutoSizeMode = DirectCast(System.Enum.Parse(GetType(DataGridViewAutoSizeColumnMode), columnNode.Attributes("AutoSizeMode").Value), DataGridViewAutoSizeColumnMode)
                            End If
                            newColumn = textColumn
                        End If
                        If newColumn IsNot Nothing Then
                            dataGridView.Columns.Add(newColumn)
                        End If
                    Next
                End If
            End If

            ' Load the data of the DataGridView
            Dim dataNode As XmlNode = doc.SelectSingleNode("DataGridData/Data")
            If dataNode IsNot Nothing Then
                For Each rowNode As XmlNode In dataNode.ChildNodes
                    Dim rowValues As New List(Of Object)()
                    For Each cellNode As XmlNode In rowNode.ChildNodes
                        Dim columnName As String = cellNode.Name.Replace("_", " ") ' Replace underscores with spaces
                        Dim cellValue As String = cellNode.InnerText ' Translate hex value back to string

                        If dataGridView.Columns.Contains(columnName) Then
                            If (TypeOf dataGridView.Columns(columnName) Is DataGridViewCheckBoxColumn) Or (cellValue = "True") Or (cellValue = "False") Then
                                Dim boolValue As Boolean
                                If cellValue Is Nothing Or cellValue = "" Then
                                    boolValue = False
                                Else
                                    boolValue = Boolean.Parse(cellValue)
                                End If
                                rowValues.Add(boolValue)
                            Else
                                If (TypeOf dataGridView.Columns(columnName) Is DataGridViewImageColumn) Then
                                    ' do nothing
                                Else
                                    If columnName = "colDDPData" Then
                                        If Not String.IsNullOrEmpty(cellValue) Then
                                            rowValues.Add(Convert.FromBase64String(cellValue))
                                        Else
                                            rowValues.Add(Nothing)
                                        End If
                                    Else
                                        rowValues.Add(cellValue)
                                    End If
                                End If
                            End If
                        End If
                    Next
                    dataGridView.Rows.Add(rowValues.ToArray())
                Next
            End If

        Catch ex As Exception
            MessageBox.Show($"Fout bij het laden van XML: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub






    Public Sub LoadJSonToWLEDDevices(wledDevices As Dictionary(Of String, Tuple(Of String, JObject)), filename As String)
        Return

        If File.Exists(filename) Then
            Try
                Dim jsonString As String = File.ReadAllText(filename)
                Dim savedDevices As Dictionary(Of String, Dictionary(Of String, Object)) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Dictionary(Of String, Object)))(jsonString)

                wledDevices.Clear() ' Clear de huidige lijst

                ' Converteer de geladen data naar het Tuple-formaat
                For Each kvp In savedDevices
                    Dim ipAddress As String = kvp.Key
                    Dim deviceData As Dictionary(Of String, Object) = kvp.Value

                    ' Haal de naam op, default naar "Unknown" als niet gevonden
                    Dim name As String = If(deviceData.ContainsKey("name"), deviceData("name").ToString(), "Unknown")

                    ' Zet de rest van de data om naar een JObject
                    Dim jObjectData As JObject = JObject.FromObject(deviceData)

                    wledDevices.Add(ipAddress, New Tuple(Of String, JObject)(name, jObjectData))
                Next
            Catch ex As Exception
                MessageBox.Show($"Fout bij het laden van opgeslagen WLED-apparaten: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                wledDevices.Clear()
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Slaat de WLED-apparaten op in een JSON-bestand.
    ''' </summary>
    Public Sub SaveWLEDDevicesToJson(wledDevices As Dictionary(Of String, Tuple(Of String, JObject)), filename As String)
        Try
            ' Converteer de data naar een serialiseerbaar formaat (Dictionary van Dictionary)
            Dim serializableDevices As New Dictionary(Of String, Dictionary(Of String, Object))()
            For Each kvp In wledDevices
                Dim ipAddress As String = kvp.Key
                Dim deviceTuple As Tuple(Of String, JObject) = kvp.Value
                Dim deviceData As New Dictionary(Of String, Object)()
                deviceData.Add("name", deviceTuple.Item1) ' Sla de naam op
                ' Zet de JObject om naar een Dictionary
                For Each prop In deviceTuple.Item2.Properties
                    deviceData.Add(prop.Name, prop.Value)
                Next
                serializableDevices.Add(ipAddress, deviceData)
            Next

            Dim jsonString As String = JsonConvert.SerializeObject(serializableDevices, Newtonsoft.Json.Formatting.Indented)
            File.WriteAllText(filename, jsonString)
        Catch ex As Exception
            MessageBox.Show($"Fout bij het opslaan van WLED-apparaten: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SaveAll()
        Dim Folder As String = My.Settings.DatabaseFolder

        SaveDataGridViewToXml(FrmMain.DG_Devices, Folder + "\Devices.xml")
        SaveDataGridViewToXml(FrmMain.DG_Groups, Folder + "\Groups.xml")
        SaveWLEDDevicesToJson(wledDevices, Folder + "\Devices.json")
        SaveDataGridViewToXml(FrmMain.DG_Effecten, Folder + "\Effects.xml")
        SaveDataGridViewToXml(FrmMain.DG_Paletten, Folder + "\Paletten.xml")
        SaveDataGridViewToXml(FrmMain.DG_Show, Folder + "\Show.xml")

        MessageBox.Show("All data has been saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Public Sub LoadAll()
        Dim progressPopUpForm As Form
        Dim progressBar As ProgressBar
        Dim progressText As Label

        Dim Folder As String = My.Settings.DatabaseFolder

        ' Maak een nieuw formulier voor de voortgang te kunnen tonen
        progressPopUpForm = New Form()
        progressPopUpForm.Text = "Loading..."
        progressPopUpForm.StartPosition = FormStartPosition.CenterScreen
        progressPopUpForm.Size = New Size(300, 150)
        progressPopUpForm.ControlBox = False
        progressBar = New ProgressBar()
        progressBar.Location = New Point(10, 10)
        progressBar.Size = New Size(250, 20)
        progressBar.Maximum = 254
        progressBar.MarqueeAnimationSpeed = 100
        progressBar.Minimum = 0
        progressBar.Value = 0
        progressBar.Step = 1
        progressBar.Maximum = 15
        progressBar.Style = ProgressBarStyle.Blocks
        progressPopUpForm.Controls.Add(progressBar)

        progressText = New Label()
        progressText.Location = New Point(10, 40)
        progressText.Size = New Size(280, 20)

        progressPopUpForm.Controls.Add(progressText)

        progressPopUpForm.Show()


        progressBar.Value = 1
        progressText.Text = "Loading WLED devices..."
        LoadJSonToWLEDDevices(wledDevices, Folder + "\Devices.json")

        progressText.Text = "Loading devices..."
        progressBar.Value = progressBar.Value + 1
        LoadXmlToDataGridView(FrmMain.DG_Devices, Folder + "\Devices.xml", False)

        progressText.Text = "Loading groups..."
        progressBar.Value = progressBar.Value + 1
        LoadXmlToDataGridView(FrmMain.DG_Groups, Folder + "\Groups.xml", False)

        progressText.Text = "Loading effects..."
        progressBar.Value = progressBar.Value + 1
        LoadXmlToDataGridView(FrmMain.DG_Effecten, Folder + "\Effects.xml", True)

        progressText.Text = "Loading palettes..."
        progressBar.Value = progressBar.Value + 1
        LoadXmlToDataGridView(FrmMain.DG_Paletten, Folder + "\Paletten.xml", True)

        progressText.Text = "Loading show..."
        progressBar.Value = progressBar.Value + 1
        LoadXmlToDataGridView(FrmMain.DG_Show, Folder + "\Show.xml", False)



        progressText.Text = "Update fixure pulldown..."
        progressBar.Value = progressBar.Value + 1
        UpdateFixuresPulldown_ForShow(FrmMain.DG_Show)





        If (FrmMain.DG_Show.RowCount > 0) Then
            FrmMain.DG_Show.CurrentCell = FrmMain.DG_Show.Rows(0).Cells(0)
        End If
        progressText.Text = "Update effecten in show..."
        progressBar.Value = progressBar.Value + 1
        UpdateEffectenPulldown_ForCurrentFixure(FrmMain.DG_Show)

        progressText.Text = "Update palettes in show..."
        progressBar.Value = progressBar.Value + 1
        UpdatePalettePulldown_ForCurrentFixure(FrmMain.DG_Show)


        progressText.Text = "Drawing palettes..."
        progressBar.Value = progressBar.Value + 1
        DG_Palette_LoadImages(FrmMain.DG_Paletten)

        progressText.Text = "Finishing up..."
        progressBar.Value = 15
        progressPopUpForm.Close()

        CheckWLEDOnlineStatus(FrmMain.DG_Devices)
        PopulateFixtureDropdown_InGroups(FrmMain.DG_Devices, FrmMain.DG_Groups)
        PopulateTreeView(FrmMain.DG_Groups, FrmMain.tvGroupsSelected)
        GenereerLedLijst(FrmMain.DG_Devices, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
        TekenPodium(FrmMain.pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
    End Sub


    Sub LoadShow()
        Dim Folder As String = My.Settings.DatabaseFolder

        LoadXmlToDataGridView(FrmMain.DG_Show, Folder + "\Show.xml", False)
        UpdateFixuresPulldown_ForShow(FrmMain.DG_Show)
        UpdateEffectenPulldown_ForCurrentFixure(FrmMain.DG_Show)
        UpdatePalettePulldown_ForCurrentFixure(FrmMain.DG_Show)
    End Sub


    Sub LoadEffectPalettes()
        Dim Folder As String = My.Settings.DatabaseFolder

        LoadXmlToDataGridView(FrmMain.DG_Effecten, Folder + "\Effects.xml", True)
        LoadXmlToDataGridView(FrmMain.DG_Paletten, Folder + "\Paletten.xml", True)
    End Sub


End Module