Imports System.Net
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module DG_Devices
    Public wledDevices As New Dictionary(Of String, Tuple(Of String, JObject)) ' Dictionary om WLED-apparaten, namen en alle data op te slaan

    ' ****************************************************************************************
    '  Opent de WLED-website in de standaardbrowser.
    ' ****************************************************************************************
    Public Sub OpenWebsiteOfWLED(DG_Devices As DataGridView, txt_APIResult As TextBox, e As DataGridViewCellEventArgs)
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


    ' ****************************************************************************************
    '  Update het aantal segmenten in de DataGridView voor elk WLED-apparaat.
    ' ****************************************************************************************
    Public Sub UpdateSegmenten_PerWLED(DG_Devices As DataGridView)
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


    Public Function GetIpFromWLedName(SearchName As String) As String
        ' Zoek de IP-adres in de DG_Devices DataGridView.
        For Each deviceRow As DataGridViewRow In FrmMain.DG_Devices.Rows()
            Dim deviceNameCellValue = deviceRow.Cells("colInstance").Value
            Dim deviceIpCellValue = deviceRow.Cells("colIPAddress").Value
            If deviceNameCellValue IsNot Nothing AndAlso deviceNameCellValue.ToString() = SearchName Then
                If deviceIpCellValue IsNot Nothing Then
                    Return deviceIpCellValue.ToString()
                Else
                    Return ""
                End If
            End If
        Next

        Return "Unknown DeviceName"
    End Function

End Module