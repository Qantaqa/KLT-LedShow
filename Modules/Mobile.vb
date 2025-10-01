Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Net.NetworkInformation
Imports System.Collections.Generic

Module Mobile

    Private listener As HttpListener
    Private serverThread As Thread
    Private serverRunning As Boolean = False
    Private Prefix As String = Nothing

    ' Simple in-memory session tracking
    Private Class SessionInfo
        Public Property Id As String
        Public Property Name As String
        Public Property LastSeenUtc As DateTime
    End Class
    Private ReadOnly sessions As New Dictionary(Of String, SessionInfo)()
    Private ReadOnly sessionsLock As New Object()

    Public Sub Start()
        Try
            If serverRunning Then Return

            Dim myIp = GetLocalIPv4()
            If String.IsNullOrEmpty(myIp) Then myIp = "127.0.0.1"
            Prefix = $"http://{myIp}:80/"

            listener = New HttpListener()
            listener.Prefixes.Add(Prefix)
            listener.Start()
            serverRunning = True

            serverThread = New Thread(AddressOf ListenLoop)
            serverThread.IsBackground = True
            serverThread.Start()

            ToonFlashBericht($"Mobile webinterface gestart op {Prefix}", 30, FlashSeverity.IsInfo)
        Catch ex As Exception
            ToonFlashBericht("Kon mobile webinterface niet starten: " & ex.Message, 8, FlashSeverity.IsWarning)
        End Try
    End Sub

    Public Sub [Stop]()
        Try
            serverRunning = False
            If listener IsNot Nothing Then
                listener.Stop()
                listener.Close()
                listener = Nothing
            End If
            If serverThread IsNot Nothing AndAlso serverThread.IsAlive Then
                serverThread.Join(500)
            End If
        Catch
        End Try
    End Sub

    Private Sub ListenLoop()
        While serverRunning
            Try
                Dim ctx = listener.GetContext()
                System.Threading.ThreadPool.QueueUserWorkItem(AddressOf HandleContext, ctx)
            Catch ex As HttpListenerException
                Exit While
            Catch
                ' ignore
            End Try
        End While
    End Sub

    Private Function GetOrCreateSession(ctx As HttpListenerContext) As SessionInfo
        Dim sid As String = Nothing
        Try
            Dim c = ctx.Request.Cookies("sid")
            If c IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(c.Value) Then sid = c.Value
        Catch
        End Try
        Dim sess As SessionInfo = Nothing
        SyncLock sessionsLock
            If Not String.IsNullOrEmpty(sid) AndAlso sessions.TryGetValue(sid, sess) Then
                ' found
            Else
                sid = Guid.NewGuid().ToString("N")
                sess = New SessionInfo() With {.Id = sid, .Name = Nothing, .LastSeenUtc = DateTime.UtcNow}
                sessions(sid) = sess
            End If
        End SyncLock
        ' Ensure cookie set
        Try
            Dim outCookie As New Cookie("sid", sid)
            outCookie.Path = "/"
            ctx.Response.Cookies.Add(outCookie)
        Catch
        End Try
        sess.LastSeenUtc = DateTime.UtcNow
        Return sess
    End Function

    Private Sub HandleContext(state As Object)
        Dim ctx = CType(state, HttpListenerContext)
        Dim req = ctx.Request
        Dim resp = ctx.Response
        Dim sess = GetOrCreateSession(ctx)
        Try
            Dim path = req.Url.AbsolutePath.ToLowerInvariant()
            If path = "/" Then
                WriteHtml(resp, BuildHtml(sess))
            ElseIf path = "/setname" Then
                Dim nm As String = Nothing
                If String.Equals(req.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase) Then
                    Try
                        Using sr As New IO.StreamReader(req.InputStream, req.ContentEncoding)
                            Dim body = sr.ReadToEnd()
                            nm = GetQueryParam(body, "name").Trim()
                        End Using
                    Catch
                    End Try
                End If
                If String.IsNullOrWhiteSpace(nm) Then
                    nm = GetQueryParam(req.Url.Query, "name").Trim()
                End If
                SyncLock sessionsLock
                    sess.Name = nm
                End SyncLock
                ' Redirect back to home
                resp.StatusCode = 302
                resp.RedirectLocation = "/"
                Try
                    resp.OutputStream.Close()
                Catch
                End Try
                Return
            ElseIf path = "/status" Then
                WriteJson(resp, GetCrewStatusJson(sess))
            ElseIf path = "/image" Then
                Dim idStr = GetQueryParam(req.Url.Query, "id")
                Dim id As Integer
                If Integer.TryParse(idStr, id) Then
                    If Not TryWriteImageForAction(resp, id) Then
                        resp.StatusCode = 404
                        WriteText(resp, "Image not found", "text/plain")
                    End If
                Else
                    resp.StatusCode = 400
                    WriteText(resp, "Bad id", "text/plain")
                End If
            ElseIf path = "/action" Then
                ' Bedieningsopties zijn uitgeschakeld
                resp.StatusCode = 403
                WriteJson(resp, "{""ok"":false,""error"":""disabled""}")
            Else
                resp.StatusCode = 404
                WriteText(resp, "Not Found", "text/plain")
            End If
        Catch ex As Exception
            Try
                resp.StatusCode = 500
                WriteText(resp, "Server error: " & ex.Message, "text/plain")
            Catch
            End Try
        Finally
            Try
                resp.OutputStream.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Function TryWriteImageForAction(resp As HttpListenerResponse, actionId As Integer) As Boolean
        Dim path As String = Nothing
        RunOnUI(Sub()
                    Try
                        Dim mf = FrmMain
                        If mf Is Nothing Then Return
                        Dim idCol = GetColumnIndex(mf.DG_Actions, New String() {"colActionId", "ID", "colID", "colActionID"})
                        Dim imgCol = GetColumnIndex(mf.DG_Actions, New String() {"colActionImage", "Image", "colImage"})
                        If idCol = -1 OrElse imgCol = -1 Then Return
                        For Each r As DataGridViewRow In mf.DG_Actions.Rows
                            If r.IsNewRow Then Continue For
                            Dim v = r.Cells(idCol).Value
                            Dim n As Integer
                            If v IsNot Nothing AndAlso Integer.TryParse(v.ToString(), n) AndAlso n = actionId Then
                                Dim p = r.Cells(imgCol).Value
                                If p IsNot Nothing Then path = p.ToString()
                                Exit For
                            End If
                        Next
                    Catch
                    End Try
                End Sub)
        If String.IsNullOrWhiteSpace(path) OrElse Not IO.File.Exists(path) Then Return False
        Try
            Dim bytes = IO.File.ReadAllBytes(path)
            resp.ContentType = GetMimeFromPath(path)
            resp.ContentLength64 = bytes.LongLength
            resp.OutputStream.Write(bytes, 0, bytes.Length)
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Function GetMimeFromPath(p As String) As String
        Dim ext = IO.Path.GetExtension(p).ToLowerInvariant()
        Select Case ext
            Case ".png" : Return "image/png"
            Case ".jpg", ".jpeg" : Return "image/jpeg"
            Case ".gif" : Return "image/gif"
            Case ".bmp" : Return "image/bmp"
            Case Else : Return "application/octet-stream"
        End Select
    End Function

    Private Function GetCrewStatusJson(sess As SessionInfo) As String
        Dim name As String = Nothing
        SyncLock sessionsLock
            name = sess.Name
        End SyncLock

        Dim page As Integer = 0
        Dim items As New List(Of CrewItem)()
        RunOnUI(Sub()
                    Try
                        page = FrmMain.currentPage
                        If page <= 0 Then Return
                        Dim mf = FrmMain
                        If mf Is Nothing Then Return
                        Dim idCol = GetColumnIndex(mf.DG_Actions, New String() {"colActionId", "ID", "colID", "colActionID"})
                        Dim pageCol = GetColumnIndex(mf.DG_Actions, New String() {"colActionPage", "Pagenr", "colPagenr", "Page", "colPage"})
                        Dim imgCol = GetColumnIndex(mf.DG_Actions, New String() {"colActionImage", "Image", "colImage"})
                        If idCol = -1 OrElse pageCol = -1 Then Return

                        ' Build lookup of details by actionId
                        Dim linkCol = GetColumnIndex(mf.DG_ActionsDetail, New String() {"colActionRowID", "ActionRowID", "ActionId", "colActionId"})
                        Dim orderCol = GetColumnIndex(mf.DG_ActionsDetail, New String() {"colActionRowOrder", "Order", "colOrder"})
                        Dim descrCol = GetColumnIndex(mf.DG_ActionsDetail, New String() {"colActionRowDescr", "Descr", "Description", "colDescr"})
                        Dim actorCol = GetColumnIndex(mf.DG_ActionsDetail, New String() {"colActionRowActor", "Actor", "colActor"})

                        For Each r As DataGridViewRow In mf.DG_Actions.Rows
                            If r.IsNewRow Then Continue For
                            Dim pObj = r.Cells(pageCol).Value
                            Dim p As Integer
                            If pObj Is Nothing OrElse Not Integer.TryParse(pObj.ToString(), p) Then Continue For
                            If p <> page Then Continue For

                            Dim idObj = r.Cells(idCol).Value
                            Dim aid As Integer
                            If idObj Is Nothing OrElse Not Integer.TryParse(idObj.ToString(), aid) Then Continue For

                            ' Collect relevant detail rows for this actionId filtered by actor
                            Dim steps As New List(Of CrewStep)()
                            If linkCol <> -1 Then
                                For Each dr As DataGridViewRow In mf.DG_ActionsDetail.Rows
                                    If dr.IsNewRow Then Continue For
                                    Dim l = dr.Cells(linkCol).Value
                                    Dim linkId As Integer
                                    If l Is Nothing OrElse Not Integer.TryParse(l.ToString(), linkId) Then Continue For
                                    If linkId <> aid Then Continue For

                                    Dim actorVal As String = If(If(actorCol <> -1, dr.Cells(actorCol).Value, Nothing), String.Empty).ToString()
                                    If Not IsActorMatch(name, actorVal) Then Continue For

                                    Dim ord As Integer = 0
                                    If orderCol <> -1 Then
                                        Dim ov = dr.Cells(orderCol).Value
                                        If ov IsNot Nothing Then Integer.TryParse(ov.ToString(), ord)
                                    End If
                                    Dim descr As String = If(If(descrCol <> -1, dr.Cells(descrCol).Value, Nothing), String.Empty).ToString()
                                    steps.Add(New CrewStep With {.Order = ord, .Descr = descr, .Actor = actorVal})
                                Next
                            End If
                            If steps.Count = 0 Then Continue For
                            steps.Sort(Function(a, b) a.Order.CompareTo(b.Order))

                            Dim imgUrl As String = Nothing
                            If imgCol <> -1 Then
                                Dim pv = r.Cells(imgCol).Value
                                If pv IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(pv.ToString()) Then
                                    imgUrl = "/image?id=" & aid
                                End If
                            End If
                            items.Add(New CrewItem With {.Id = aid, .ImageUrl = imgUrl, .Steps = steps})
                        Next
                    Catch
                    End Try
                End Sub)

        Dim sb As New StringBuilder()
        sb.Append("{")
        sb.Append("""name"":""").Append(Escape(If(name, ""))).Append(""",")
        sb.Append("""pdfPage"":").Append(page).Append(",")
        sb.Append("""items"":[")
        For i = 0 To items.Count - 1
            If i > 0 Then sb.Append(",")
            Dim it = items(i)
            sb.Append("{")
            sb.Append("""id"":").Append(it.Id).Append(",")
            sb.Append("""image"":").Append(If(String.IsNullOrEmpty(it.ImageUrl), "null", """" & Escape(it.ImageUrl) & """")).Append(",")
            sb.Append("""steps"":[")
            For j = 0 To it.Steps.Count - 1
                If j > 0 Then sb.Append(",")
                Dim st = it.Steps(j)
                sb.Append("{")
                sb.Append("""order"":").Append(st.Order).Append(",")
                sb.Append("""descr"":""").Append(Escape(st.Descr)).Append("""")
                sb.Append("}")
            Next
            sb.Append("]}")
        Next
        sb.Append("]}")
        Return sb.ToString()
    End Function

    Private Function Escape(s As String) As String
        If s Is Nothing Then Return ""
        Dim t = s.Replace("\", "\\")
        t = t.Replace("""", "\""")
        Return t
    End Function

    Private Sub WriteHtml(resp As HttpListenerResponse, html As String)
        Dim data = Encoding.UTF8.GetBytes(html)
        resp.ContentType = "text/html; charset=utf-8"
        resp.ContentLength64 = data.LongLength
        resp.OutputStream.Write(data, 0, data.Length)
    End Sub

    Private Sub WriteJson(resp As HttpListenerResponse, json As String)
        Dim data = Encoding.UTF8.GetBytes(json)
        resp.ContentType = "application/json; charset=utf-8"
        resp.ContentLength64 = data.LongLength
        resp.OutputStream.Write(data, 0, data.Length)
    End Sub

    Private Sub WriteText(resp As HttpListenerResponse, text As String, mime As String)
        Dim data = Encoding.UTF8.GetBytes(text)
        resp.ContentType = mime
        resp.ContentLength64 = data.LongLength
        resp.OutputStream.Write(data, 0, data.Length)
    End Sub

    Private Function IsActorMatch(name As String, actorVal As String) As Boolean
        If String.IsNullOrWhiteSpace(actorVal) Then Return False
        If String.IsNullOrWhiteSpace(name) Then Return False
        Dim wanted = name.Trim().ToLowerInvariant()
        For Each part In actorVal.Split({","c, ";"c, "/"c, "|"c}, StringSplitOptions.RemoveEmptyEntries)
            If part.Trim().ToLowerInvariant() = wanted Then Return True
        Next
        Return actorVal.ToLowerInvariant().Contains(wanted)
    End Function

    Private Function GetStatusJson() As String
        Dim currentAct As String = ""
        Dim currentScene As Integer = 0
        Dim currentEvent As Integer = 0
        Dim nextHint As String = ""
        Dim page As Integer = 0
        Dim autoGoto As Boolean = False

        RunOnUI(Sub()
                    ' Vind eerste actieve rij (btnApply = ">")
                    Dim activeRow As DataGridViewRow = Nothing
                    For Each r As DataGridViewRow In FrmMain.DG_Show.Rows
                        If r.IsNewRow Then Continue For
                        If Convert.ToString(r.Cells("btnApply").Value) = ">" Then
                            activeRow = r
                            Exit For
                        End If
                    Next
                    If activeRow IsNot Nothing Then
                        currentAct = Convert.ToString(activeRow.Cells("colAct").Value)
                        Integer.TryParse(Convert.ToString(activeRow.Cells("colSceneId").Value), currentScene)
                        Integer.TryParse(Convert.ToString(activeRow.Cells("colEventId").Value), currentEvent)
                        ' Hint: neem volgende zichtbare rij als cue
                        Dim idx = activeRow.Index
                        For i = idx + 1 To FrmMain.DG_Show.Rows.Count - 1
                            Dim rr = FrmMain.DG_Show.Rows(i)
                            If rr.IsNewRow OrElse Not rr.Visible Then Continue For
                            nextHint = Convert.ToString(rr.Cells("colAct").Value) & " / S" & rr.Cells("colSceneId").Value & " / E" & rr.Cells("colEventId").Value
                            Exit For
                        Next
                    End If
                    page = FrmMain.currentPage
                    autoGoto = (FrmMain.btnAutoGotoPDFPage IsNot Nothing AndAlso FrmMain.btnAutoGotoPDFPage.Text = "on")
                End Sub)

        Dim json As String = "{""act"":""" & Escape(currentAct) & """,""scene"":" & currentScene & ",""event"":" & currentEvent & ",""next"":""" & Escape(nextHint) & """,""pdfPage"":" & page & ",""autoGoto"":" & LCase(autoGoto.ToString()) & "}"
        Return json
    End Function

    Private Class CrewItem
        Public Property Id As Integer
        Public Property ImageUrl As String
        Public Property Steps As List(Of CrewStep)
    End Class
    Private Class CrewStep
        Public Property Order As Integer
        Public Property Descr As String
        Public Property Actor As String
    End Class

    Private Sub RunOnUI(a As Action)
        'If FrmMain Is Nothing Then Return
        If FrmMain.InvokeRequired Then
            FrmMain.Invoke(a)
        Else
            a()
        End If
    End Sub

    Private Function BuildHtml(sess As SessionInfo) As String
        Dim hasName As Boolean
        Dim name As String = Nothing
        SyncLock sessionsLock
            hasName = Not String.IsNullOrWhiteSpace(sess.Name)
            name = sess.Name
        End SyncLock

        Dim sb As New StringBuilder()
        sb.AppendLine("<!doctype html>")
        sb.AppendLine("<html><head><meta name='viewport' content='width=device-width, initial-scale=1'>")
        sb.AppendLine("<title>KLT Mobile</title>")
        sb.AppendLine("<style>")
        sb.AppendLine("body{font-family:system-ui,-apple-system,Segoe UI,Roboto,Arial,sans-serif;padding:16px;margin:0;background:#111;color:#eee}")
        sb.AppendLine("h2{margin:0 0 12px 0}")
        sb.AppendLine(".card{background:#1b1b1b;border:1px solid #333;border-radius:10px;margin:12px 0;overflow:hidden}")
        sb.AppendLine(".img{width:100%;max-height:50vh;object-fit:contain;background:#000}")
        sb.AppendLine(".steps{padding:12px 14px}")
        sb.AppendLine(".muted{color:#aaa;font-size:13px}")
        sb.AppendLine("input[type=text]{width:100%;padding:12px 14px;border-radius:8px;border:1px solid #333;background:#222;color:#eee}")
        sb.AppendLine("button{padding:12px 16px;border-radius:8px;border:0;background:#2d6cdf;color:#fff;font-size:16px}")
        sb.AppendLine("#nameForm{margin-top:18px}")
        sb.AppendLine("</style>")
        sb.AppendLine("</head><body>")
        sb.AppendLine("<h2>KLT LedShow - Backstage</h2>")
        If Not hasName Then
            sb.AppendLine("<div class='muted'>Vul je naam in zoals die in de PDF-annotaties bij 'Actor' staat.</div>")
            sb.AppendLine("<form id='nameForm' method='post' action='/setname'>")
            sb.AppendLine("<input type='text' name='name' placeholder='Naam' autocomplete='name' required>")
            sb.AppendLine("<div style='margin-top:12px'><button type='submit'>Start</button></div>")
            sb.AppendLine("</form>")
        Else
            sb.AppendLine("<div class='muted'>Ingelogd als: <b>" & Escape(name) & "</b></div>")
            sb.AppendLine("<div id='pg' class='muted' style='margin:8px 0'></div>")
            sb.AppendLine("<div id='container'></div>")
            sb.AppendLine("<script>")
            sb.AppendLine("async function refresh(){")
            sb.AppendLine("  try{")
            sb.AppendLine("    const r=await fetch('/status'); const j=await r.json();")
            sb.AppendLine("    document.getElementById('pg').innerText='PDF pagina: '+(j.pdfPage||'-');")
            sb.AppendLine("    const cont=document.getElementById('container'); cont.innerHTML='';")
            sb.AppendLine("    if(!j.items||j.items.length===0){cont.innerHTML='<div class=\'muted\'>Geen taken op deze pagina voor jou.</div>'; return;}")
            sb.AppendLine("    j.items.forEach(it=>{")
            sb.AppendLine("      const card=document.createElement('div'); card.className='card';")
            sb.AppendLine("      if(it.image){ const img=new Image(); img.className='img'; img.src=it.image; card.appendChild(img);} ")
            sb.AppendLine("      const steps=document.createElement('div'); steps.className='steps';")
            sb.AppendLine("      it.steps.forEach(s=>{ const p=document.createElement('div'); p.textContent=(s.order? (s.order+'. '):'')+s.descr; steps.appendChild(p); });")
            sb.AppendLine("      card.appendChild(steps); cont.appendChild(card);")
            sb.AppendLine("    });")
            sb.AppendLine("  }catch(e){}")
            sb.AppendLine("}")
            sb.AppendLine("refresh(); setInterval(refresh,2000);")
            sb.AppendLine("</script>")
        End If
        sb.AppendLine("</body></html>")
        Return sb.ToString()
    End Function

    Private Function GetQueryParam(query As String, key As String) As String
        If String.IsNullOrEmpty(query) Then Return ""
        Dim q = query
        If q.StartsWith("?") Then q = q.Substring(1)
        For Each part In q.Split("&"c)
            Dim kv = part.Split("="c)
            If kv.Length >= 2 Then
                If String.Equals(kv(0), key, StringComparison.OrdinalIgnoreCase) Then
                    Return Uri.UnescapeDataString(kv(1))
                End If
            End If
        Next
        Return ""
    End Function

    Private Sub HandleAction(action As String)
        If String.IsNullOrWhiteSpace(action) Then Return
        Try
            Select Case action.ToLowerInvariant()
                Case "start"
                    RunOnUI(Sub() DG_Show.Start_Show(FrmMain.DG_Show))
                Case "nextscene"
                    RunOnUI(Sub() DG_Show.Next_EventOrScene(FrmMain.DG_Show, FrmMain.nextScene))
                Case "nextevent"
                    RunOnUI(Sub() DG_Show.Next_EventOrScene(FrmMain.DG_Show, FrmMain.nextEvent))
                Case "nextact"
                    RunOnUI(Sub() DG_Show.Next_Act(FrmMain.DG_Show, FrmMain.filterAct))
            End Select
        Catch
        End Try
    End Sub

    ' Helper to find a column by well-known names, similar to ScriptEditor
    Private Function GetColumnIndex(dgv As DataGridView, candidates As IEnumerable(Of String)) As Integer
        If dgv Is Nothing Then Return -1
        For Each name In candidates
            For Each col As DataGridViewColumn In dgv.Columns
                If String.Equals(col.Name, name, StringComparison.OrdinalIgnoreCase) Then
                    Return col.Index
                End If
            Next
        Next
        Return -1
    End Function

    Private Function BuildHtml() As String
        Dim sb As New StringBuilder()
        sb.AppendLine("<!doctype html>")
        sb.AppendLine("<html><head><meta name='viewport' content='width=device-width, initial-scale=1'>")
        sb.AppendLine("<title>KLT Mobile</title>")
        sb.AppendLine("<style>body{font-family:sans-serif;padding:12px;} .row{margin:8px 0;} button{padding:12px 16px;font-size:16px;margin:4px;} .grid{display:grid;grid-template-columns:1fr 1fr;gap:8px}</style>")
        sb.AppendLine("</head><body>")
        sb.AppendLine("<h2>KLT LedShow - Mobile</h2>")
        sb.AppendLine("<div class='row'>Actief: <span id='cur'>-</span></div>")
        sb.AppendLine("<div class='row'>Volgende: <span id='next'>-</span></div>")
        sb.AppendLine("<div class='row'>PDF pagina: <span id='pg'>-</span> <span id='auto' style='font-size:12px;color:#666'></span></div>")
        sb.AppendLine("<div class='grid'>")
        sb.AppendLine("<button onclick=""doAction('start')"">Start</button>")
        sb.AppendLine("<button onclick=""doAction('nextact')"">Next Act</button>")
        sb.AppendLine("<button onclick=""doAction('nextevent')"">Next Event</button>")
        sb.AppendLine("<button onclick=""doAction('nextscene')"">Next Scene</button>")
        sb.AppendLine("<button onclick=""doAction('blackout')"">Blackout/Stop</button>")
        sb.AppendLine("</div>")
        sb.AppendLine("<script>async function refresh(){try{let r=await fetch('/status');let j=await r.json();document.getElementById('cur').innerText=j.act+' / S'+j.scene+' / E'+j.event;document.getElementById('next').innerText=j.next||'-';document.getElementById('pg').innerText=j.pdfPage;document.getElementById('auto').innerText=j.autoGoto?'(auto goto aan)':'(auto goto uit)';}catch(e){}};async function doAction(a){try{await fetch('/action?action='+a,{method:'POST'});setTimeout(refresh,200);}catch(e){}};refresh();setInterval(refresh,2000);</script>")
        sb.AppendLine("</body></html>")
        Return sb.ToString()
    End Function


    Private Function GetLocalIPv4() As String
        Try
            Dim bestIp As String = ""
            Dim bestScore As Integer = Integer.MinValue

            For Each ni In NetworkInterface.GetAllNetworkInterfaces()
                If ni.OperationalStatus <> OperationalStatus.Up Then Continue For
                If ni.NetworkInterfaceType = NetworkInterfaceType.Loopback _
                   OrElse ni.NetworkInterfaceType = NetworkInterfaceType.Tunnel _
                   OrElse ni.NetworkInterfaceType = NetworkInterfaceType.Ppp Then Continue For

                Dim nd = (ni.Name & " " & ni.Description).ToLowerInvariant()
                If nd.Contains("virtual") OrElse nd.Contains("hyper-v") OrElse nd.Contains("vmware") _
                   OrElse nd.Contains("vbox") OrElse nd.Contains("docker") OrElse nd.Contains("wintun") _
                   OrElse nd.Contains("wireguard") OrElse nd.Contains("tap") OrElse nd.Contains("tun") Then
                    Continue For
                End If

                Dim props = ni.GetIPProperties()
                Dim hasGw As Boolean = props.GatewayAddresses.Any(Function(g) g.Address IsNot Nothing AndAlso
                                                                 g.Address.AddressFamily = Sockets.AddressFamily.InterNetwork AndAlso
                                                                 Not g.Address.Equals(IPAddress.Parse("0.0.0.0")))

                For Each ua In props.UnicastAddresses
                    If ua.Address Is Nothing OrElse ua.Address.AddressFamily <> Sockets.AddressFamily.InterNetwork Then Continue For
                    Dim addr = ua.Address
                    Dim b = addr.GetAddressBytes()
                    ' Skip link-local 169.254.x.x
                    If b(0) = 169 AndAlso b(1) = 254 Then Continue For

                    Dim ipStr = addr.ToString()
                    Dim score As Integer = 0

                    ' Prefer default-gateway interfaces (likely the active LAN)
                    If hasGw Then score += 4

                    ' Prefer Ethernet/Wi-Fi
                    If ni.NetworkInterfaceType = NetworkInterfaceType.Ethernet OrElse
                       ni.NetworkInterfaceType = NetworkInterfaceType.Wireless80211 Then
                        score += 2
                    End If

                    ' Prefer your LAN range
                    If ipStr.StartsWith("192.168.86.") Then
                        score += 3
                    ElseIf ipStr.StartsWith("192.168.") Then
                        score += 2
                    ElseIf ipStr.StartsWith("172.") Then
                        ' Only 172.16.0.0 � 172.31.255.255 are private
                        If b(0) = 172 AndAlso b(1) >= 16 AndAlso b(1) <= 31 Then score += 1
                    ElseIf ipStr.StartsWith("10.") Then
                        ' Private but less specific for many VPNs; no bonus
                    End If

                    If score > bestScore Then
                        bestScore = score
                        bestIp = ipStr
                    End If
                Next
            Next

            If Not String.IsNullOrEmpty(bestIp) Then Return bestIp

            ' Fallback to any non-loopback IPv4
            For Each ip In Dns.GetHostAddresses(Dns.GetHostName())
                If ip.AddressFamily = Sockets.AddressFamily.InterNetwork AndAlso Not IPAddress.IsLoopback(ip) Then
                    Return ip.ToString()
                End If
            Next
        Catch
        End Try
        Return String.Empty
    End Function
End Module
