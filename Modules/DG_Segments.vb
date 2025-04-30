Imports System.Net
Imports Newtonsoft.Json
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

' Deze module bevat code om de DataGridView voor segmenten te vullen en aan te passen.
Module Segments

    ' Definieer een structuur om de segmentdata van de WLED JSON response op te slaan.
    Private Structure SegmentData
        Dim Segments As List(Of Segment)
    End Structure

    ' Definieer een structuur om individuele segmenten op te slaan.  Dit komt overeen met de JSON structuur.
    Private Structure Segment
        Dim Id As Integer
        Dim ledStart As Integer
        Dim ledStop As Integer
        Dim len As Integer ' Toegevoegd: voor het aantal leds
        Dim grp As Integer
        Dim spc As Integer
        Dim LedOnOff As Boolean
        Dim bri As Integer
        <JsonProperty("col")>
        Dim Kleuren As List(Of List(Of Integer)) ' Geneneraliseerde naamgeving
        Dim rev As Boolean ' toegevoegd voor de reverse status
    End Structure

    ' Functie om de segmentgegevens van een WLED apparaat op te halen via de API.
    ' Vereist het IP-adres van het WLED apparaat.
    Private Function GetWLEDSegmentData(ByVal ipAddress As String) As SegmentData
        ' Stel de URI samen om de segmentinformatie op te halen.
        Dim uri As New Uri($"http://{ipAddress}/json")

        ' Maak een WebRequest object om de aanvraag te versturen.
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
        request.Method = "GET" ' Stel de methode in op GET.

        ' Probeer de response van de server te lezen.
        Try
            Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                ' Controleer de statuscode van de response.  Ga alleen verder bij een succesvolle response.
                If response.StatusCode = HttpStatusCode.OK Then
                    ' Maak een StreamReader om de inhoud van de response te lezen.
                    Using reader As New System.IO.StreamReader(response.GetResponseStream())
                        ' Lees de JSON string van de response.
                        Dim json As String = reader.ReadToEnd()
                        ' Deserialiseer de JSON string naar een JObject om de segmenten eruit te halen
                        Dim segmentDataJObject As JObject = JsonConvert.DeserializeObject(Of JObject)(json)
                        Dim segmentData As New SegmentData
                        Dim segmentList As New List(Of Segment)

                        ' Haal de segmenten array op
                        Dim segmentsArray = TryCast(segmentDataJObject("state")("seg"), JArray)
                        If segmentsArray IsNot Nothing Then
                            For Each segmentJToken In segmentsArray
                                Dim segment As Segment
                                segment.Id = segmentJToken("id").Value(Of Integer)
                                segment.ledStart = segmentJToken("start").Value(Of Integer)
                                segment.ledStop = segmentJToken("stop").Value(Of Integer)
                                segment.len = segmentJToken("len").Value(Of Integer)
                                segment.grp = segmentJToken("grp").Value(Of Integer)
                                segment.spc = segmentJToken("spc").Value(Of Integer)
                                segment.LedOnOff = segmentJToken("on").Value(Of Boolean)
                                segment.bri = segmentJToken("bri").Value(Of Integer)
                                segment.Kleuren = segmentJToken("col").ToObject(Of List(Of List(Of Integer)))
                                segment.rev = segmentJToken("rev").Value(Of Boolean)
                                segmentList.Add(segment)
                            Next
                        End If
                        segmentData.Segments = segmentList
                        Return segmentData ' Retourneer de data.
                    End Using
                Else
                    ' Als de statuscode niet OK is, geef dan een leeg SegmentData object terug en toon een foutmelding.
                    ' Dit voorkomt een crash als er een probleem is met de verbinding.
                    Console.WriteLine($"Fout bij het ophalen van segmentdata van {ipAddress}. Statuscode: {response.StatusCode}")
                    Return New SegmentData With {.Segments = New List(Of Segment)()} ' Retourneer een leeg object.
                End If
            End Using
        Catch ex As WebException
            ' Vang WebExceptions op (bijvoorbeeld als de server niet bereikbaar is).
            Console.WriteLine($"Fout bij het communiceren met WLED apparaat op {ipAddress}: {ex.Message}")
            Return New SegmentData With {.Segments = New List(Of Segment)()} ' Retourneer een leeg object.
        End Try
        ' Als er iets misgaat, retourneer dan een leeg SegmentData object.
        Return New SegmentData With {.Segments = New List(Of Segment)()}
    End Function






End Module
