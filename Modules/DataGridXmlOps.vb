Imports System.IO
Imports System.Xml
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.Net.Http

Module DataGridXmlOps

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
                        writer.WriteString(StringToHexString(cell.Value.ToString()))
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


    Private Function StringToHexString(input As String) As String
        Dim hexBuilder As New System.Text.StringBuilder()
        For Each c As Char In input
            hexBuilder.Append(String.Format("{0:X2}", AscW(c)))
        Next
        Return hexBuilder.ToString()
    End Function


    Public Sub LoadXmlToDataGridView(dataGridView As DataGridView, filePath As String)
        If Not File.Exists(filePath) Then
            MessageBox.Show($"Bestand '{filePath}' niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim doc As New XmlDocument()
            doc.Load(filePath)

            ' Clear existing data
            dataGridView.Rows.Clear()
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

            ' Populate wledDevices dictionary from loaded device data
            If dataGridView Is dataGridView Then
                wledDevices.Clear() ' Clear the dictionary before loading
                For Each row As DataGridViewRow In dataGridView.Rows
                    Dim ipAddress As String = TryCast(row.Cells("colIPAddress").Value, String)
                    Dim wledName As String = TryCast(row.Cells("colInstance").Value, String)

                    ' Load all data for the device.
                    Dim wledData As JObject = LoadWLEDData(ipAddress)

                    If Not String.IsNullOrEmpty(ipAddress) AndAlso Not String.IsNullOrEmpty(wledName) Then
                        wledDevices.Add(ipAddress, New Tuple(Of String, JObject)(wledName, wledData))
                    End If
                Next
            End If

            ' Load the data of the DataGridView
            Dim dataNode As XmlNode = doc.SelectSingleNode("DataGridData/Data")
            If dataNode IsNot Nothing Then
                For Each rowNode As XmlNode In dataNode.ChildNodes
                    Dim rowValues As New List(Of Object)()
                    For Each cellNode As XmlNode In rowNode.ChildNodes
                        Dim columnName As String = cellNode.Name.Replace("_", " ") ' Replace underscores with spaces
                        Dim cellValue As String = HexStringToString(cellNode.InnerText) ' Translate hex value back to string

                        If dataGridView.Columns.Contains(columnName) Then
                            If TypeOf dataGridView.Columns(columnName) Is DataGridViewCheckBoxColumn Then
                                Dim boolValue As Boolean = Boolean.Parse(cellValue)
                                rowValues.Add(boolValue)
                            Else
                                rowValues.Add(cellValue)
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



    Private Function HexStringToString(hexString As String) As String
        Dim result As New System.Text.StringBuilder()
        For i As Integer = 0 To hexString.Length - 1 Step 2
            Dim byteValue As Byte = Byte.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber)
            result.Append(ChrW(byteValue))
        Next
        Return result.ToString()
    End Function


    Private Function LoadWLEDData(ipAddress As String) As JObject
        Dim wledData As New JObject
        Try
            ' Maak een HTTP-client object.
            Using client = New HttpClient()
                ' Haal de JSON op van de WLED-instantie.  Zorg ervoor dat het een geldige URL is.
                Dim response = client.GetAsync($"http://{ipAddress}/json").Result
                response.EnsureSuccessStatusCode() ' Gooi een exception als de request niet succesvol is.
                Dim jsonString = response.Content.ReadAsStringAsync().Result
                ' Parse de JSON.
                wledData = JObject.Parse(jsonString)
            End Using
        Catch ex As Exception
            ' Log de exception.  Dit is belangrijk voor debugging.
            Debug.WriteLine($"Exception in LoadWLEDData: {ex.Message}")
            ' Retourneer een lege JObject.  Dit voorkomt een NullReferenceException.
        End Try
        Return wledData
    End Function


End Module