Imports System.Windows.Forms
Imports System.Drawing
Imports WMPLib

Public Module SoundButtons
    Private soundPanel As Panel
    Private flow As FlowLayoutPanel
    Private hoverTimer As Timer
    Private hostPanel As Panel
    Private expandedWidth As Integer = 120
    Private hotZoneWidth As Integer = 8

    ' audio
    Private wmp As WindowsMediaPlayer
    Private remainingPlays As Integer = 0
    Private collapseDelayMs As Integer = 600
    Private lastHoverKeepAlive As DateTime = DateTime.MinValue

    Public Sub Initialize(hostSplit As SplitContainer, formOwner As Form)
        If hostSplit Is Nothing OrElse formOwner Is Nothing Then Return
        hostPanel = hostSplit.Panel2

        ' Panel dat uitschuift
        soundPanel = New Panel With {
            .Name = "pnlSoundBar",
            .Dock = DockStyle.Right,
            .Width = 0,
            .BackColor = Color.Black,
            .Visible = True
        }
        ' Buttons verticaal stapelen
        flow = New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .AutoScroll = True,
            .BackColor = Color.Black
        }
        soundPanel.Controls.Add(flow)
        hostPanel.Controls.Add(soundPanel)
        soundPanel.BringToFront()

        ' Hover detectie via timer
        hoverTimer = New Timer With {.Interval = 120, .Enabled = True}
        AddHandler hoverTimer.Tick, Sub() HandleHover()

        ' WMP instantie voor audio
        wmp = New WindowsMediaPlayer()
        wmp.settings.setMode("loop", False)
        AddHandler wmp.PlayStateChange, AddressOf OnWmpPlayStateChange


        ' Init knoppen
        RefreshButtons(formOwner)
    End Sub

    ' Publieke wrappers om de wizard vanuit FrmMain te starten
    Public Sub StartAddWizard(formOwner As Form, insertBefore As Boolean)
        RunAddWizard(formOwner, insertBefore)
    End Sub

    Public Sub StartDelete(formOwner As Form)
        RunDeleteForSoundButtons(formOwner)
    End Sub

    Public Sub RefreshButtons(formOwner As Form)
        If formOwner Is Nothing Then Return
        If flow Is Nothing Then Return
        flow.SuspendLayout()
        Try
            flow.Controls.Clear()
            Dim dgv = TryFindSoundButtonsGrid(formOwner)
            If dgv Is Nothing Then Return

            Dim maxButtons As Integer = 10
            Dim count As Integer = 0
            For Each r As DataGridViewRow In dgv.Rows
                If r.IsNewRow Then Continue For
                If count >= maxButtons Then Exit For

                Dim idVal As Object = r.Cells(GetColIndex(dgv, "colButtonsId")).Value
                Dim nameVal As Object = r.Cells(GetColIndex(dgv, "colButtonsName")).Value
                Dim iconVal As String = SafeStr(r.Cells(GetColIndex(dgv, "colButtonsIcon")).Value)
                Dim repeatObj As Object = r.Cells(GetColIndex(dgv, "colButtonsRepeat")).Value
                Dim fileVal As String = SafeStr(r.Cells(GetColIndex(dgv, "colButtonsSoundFile")).Value)

                If String.IsNullOrWhiteSpace(fileVal) Then Continue For

                Dim btn As New Button With {
                    .Width = 96,
                    .Height = 96,
                    .BackColor = Color.FromArgb(235, 235, 235),
                    .ForeColor = Color.Black,
                    .FlatStyle = FlatStyle.Flat,
                    .TextImageRelation = TextImageRelation.ImageAboveText,
                    .Text = If(nameVal IsNot Nothing, nameVal.ToString(), "")
                }
                btn.FlatAppearance.BorderColor = Color.FromArgb(120, 120, 120)
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 220, 220)
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 210, 210)
                btn.Padding = New Padding(6)

                ' Icon laden indien beschikbaar
                If Not String.IsNullOrWhiteSpace(iconVal) AndAlso IO.File.Exists(iconVal) Then
                    Try
                        Dim img = Image.FromFile(iconVal)
                        btn.Image = New Bitmap(img, New Size(48, 48))
                    Catch
                    End Try
                End If

                Dim repeatCount As Integer = 1
                Dim tmp As Integer
                If repeatObj IsNot Nothing AndAlso Integer.TryParse(Convert.ToString(repeatObj), tmp) Then
                    repeatCount = tmp
                End If
                If repeatCount <= 1 Then repeatCount = 1

                btn.Tag = New SoundButtonInfo With {
                    .Id = idVal,
                    .Name = btn.Text,
                    .IconPath = iconVal,
                    .SoundPath = fileVal,
                    .Repeat = repeatCount
                }
                AddHandler btn.Click, AddressOf OnSoundButtonClick

                flow.Controls.Add(btn)
                count += 1
            Next
        Finally
            flow.ResumeLayout()
        End Try
    End Sub

    Private Sub OnSoundButtonClick(sender As Object, e As EventArgs)
        Dim btn = TryCast(sender, Button)
        If btn Is Nothing Then Return
        Dim info = TryCast(btn.Tag, SoundButtonInfo)
        If info Is Nothing Then Return
        If String.IsNullOrWhiteSpace(info.SoundPath) OrElse Not IO.File.Exists(info.SoundPath) Then Return

        Try
            If wmp IsNot Nothing Then
                Dim isPlaying As Boolean = (wmp.playState = WMPPlayState.wmppsPlaying)
                Dim sameTrack As Boolean = False
                Try
                    sameTrack = String.Equals(wmp.URL, info.SoundPath, StringComparison.OrdinalIgnoreCase)
                Catch
                End Try

                ' Toggle: als dezelfde knop nog speelt -> direct stoppen
                If isPlaying AndAlso sameTrack Then
                    remainingPlays = 0
                    wmp.controls.stop()
                    Return
                End If

                ' Stop elk huidig fragment voor we nieuwe starten
                wmp.controls.stop()
            End If

            remainingPlays = Math.Max(1, info.Repeat)
            wmp.URL = info.SoundPath
            wmp.controls.currentPosition = 0
            wmp.controls.play()
        Catch
        End Try
    End Sub

    Private Sub OnWmpPlayStateChange(NewState As Integer)
        ' 8 = MediaEnded, 1 = Stopped
        If NewState = CInt(WMPPlayState.wmppsMediaEnded) OrElse NewState = CInt(WMPPlayState.wmppsStopped) Then
            If remainingPlays > 1 Then
                remainingPlays -= 1
                Try
                    wmp.controls.currentPosition = 0
                    wmp.controls.play()
                Catch
                End Try
            Else
                remainingPlays = 0
            End If
        End If
    End Sub

    Private Sub HandleHover()
        If hostPanel Is Nothing OrElse soundPanel Is Nothing Then Return
        Dim pt = hostPanel.PointToClient(Cursor.Position)
        Dim insideHotzone As Boolean = pt.X >= hostPanel.ClientSize.Width - hotZoneWidth AndAlso pt.X <= hostPanel.ClientSize.Width AndAlso pt.Y >= 0 AndAlso pt.Y <= hostPanel.ClientSize.Height
        Dim overPanel As Boolean = soundPanel.Bounds.Contains(pt)

        If insideHotzone OrElse overPanel Then
            ExpandPanel()
            lastHoverKeepAlive = DateTime.Now
        Else
            ' Alleen inklappen als muis al even buiten de panel-zone is geweest
            If soundPanel.Width > 0 Then
                Dim elapsed = DateTime.Now - lastHoverKeepAlive
                If elapsed.TotalMilliseconds >= collapseDelayMs Then
                    CollapsePanel()
                End If
            End If
        End If
    End Sub

    Private Sub ExpandPanel()
        If soundPanel.Width <> expandedWidth Then
            soundPanel.Width = expandedWidth
            soundPanel.Visible = True
            soundPanel.BringToFront()
        End If
    End Sub

    Private Sub CollapsePanel()
        If soundPanel.Width <> 0 Then
            soundPanel.Width = 0
        End If
    End Sub

    Private Function TryFindSoundButtonsGrid(root As Control) As DataGridView
        Dim found = FindControlRecursive(root, "DG_SoundButtons")
        Return TryCast(found, DataGridView)
    End Function

    Private Function FindControlRecursive(parent As Control, name As String) As Control
        If parent Is Nothing Then Return Nothing
        For Each c As Control In parent.Controls
            If String.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase) Then
                Return c
            End If
            Dim child = FindControlRecursive(c, name)
            If child IsNot Nothing Then Return child
        Next
        Return Nothing
    End Function

    Private Function GetColIndex(dgv As DataGridView, name As String) As Integer
        If dgv Is Nothing Then Return -1
        If dgv.Columns.Contains(name) Then Return dgv.Columns(name).Index
        ' fallback: try case-insensitive search
        For Each col As DataGridViewColumn In dgv.Columns
            If String.Equals(col.Name, name, StringComparison.OrdinalIgnoreCase) Then Return col.Index
        Next
        Return -1
    End Function

    Private Function SafeStr(v As Object) As String
        If v Is Nothing Then Return String.Empty
        Return v.ToString()
    End Function

    Private Class SoundButtonInfo
        Public Property Id As Object
        Public Property Name As String
        Public Property IconPath As String
        Public Property SoundPath As String
        Public Property Repeat As Integer
    End Class

    ' ===================== Wizard functionaliteit =====================
    Private Sub RunAddWizard(formOwner As Form, insertBefore As Boolean)
        Try
            Dim dgv = TryFindSoundButtonsGrid(formOwner)
            If dgv Is Nothing OrElse Not dgv.Visible Then Return

            ' ID automatisch (max + 1)
            Dim idIdx = GetColIndex(dgv, "colButtonsId")
            Dim nextId As Integer = 1
            If idIdx <> -1 Then
                For Each r As DataGridViewRow In dgv.Rows
                    If r.IsNewRow Then Continue For
                    Dim v = r.Cells(idIdx).Value
                    Dim n As Integer
                    If v IsNot Nothing AndAlso Integer.TryParse(v.ToString(), n) Then
                        If n >= nextId Then nextId = n + 1
                    End If
                Next
            End If

            ' Name
            Dim nm = Microsoft.VisualBasic.Interaction.InputBox("Naam van de knop:", "Nieuwe SoundButton", "")
            If String.IsNullOrWhiteSpace(nm) Then Return

            ' MP3
            Dim mp3 As String = ""
            Using ofd As New OpenFileDialog()
                ofd.Title = "Kies geluidsbestand (mp3)"
                ofd.Filter = "MP3 (*.mp3)|*.mp3|Alle bestanden (*.*)|*.*"
                If ofd.ShowDialog() <> DialogResult.OK Then Return
                mp3 = ofd.FileName
            End Using

            ' Icon (optioneel)
            Dim ico As String = ""
            Using ofd As New OpenFileDialog()
                ofd.Title = "Kies icoon (png/jpg/ico)"
                ofd.Filter = "Afbeeldingen (*.png;*.jpg;*.jpeg;*.ico)|*.png;*.jpg;*.jpeg;*.ico|Alle bestanden (*.*)|*.*"
                If ofd.ShowDialog() = DialogResult.OK Then
                    ico = ofd.FileName
                End If
            End Using

            ' Repeat
            Dim repeatStr = Microsoft.VisualBasic.Interaction.InputBox("Aantal herhalingen:", "Repeat", "1")
            Dim repeat As Integer = 1
            Integer.TryParse(repeatStr, repeat)
            If repeat <= 1 Then repeat = 1

            ' Kolommen
            Dim nameIdx = GetColIndex(dgv, "colButtonsName")
            Dim iconIdx = GetColIndex(dgv, "colButtonsIcon")
            Dim repIdx = GetColIndex(dgv, "colButtonsRepeat")
            Dim fileIdx = GetColIndex(dgv, "colButtonsSoundFile")

            ' Insert positie
            Dim baseIndex As Integer = If(dgv.CurrentCell IsNot Nothing, dgv.CurrentCell.RowIndex, dgv.Rows.Count - 1)
            If baseIndex < 0 Then baseIndex = dgv.Rows.Count - 1
            Dim insertIndex As Integer = If(insertBefore, baseIndex, baseIndex + 1)
            If insertIndex < 0 Then insertIndex = 0
            If insertIndex > dgv.Rows.Count Then insertIndex = dgv.Rows.Count

            dgv.Rows.Insert(insertIndex, 1)
            Dim newRow = dgv.Rows(insertIndex)

            If idIdx <> -1 Then newRow.Cells(idIdx).Value = nextId
            If nameIdx <> -1 Then newRow.Cells(nameIdx).Value = nm
            If iconIdx <> -1 Then newRow.Cells(iconIdx).Value = ico
            If repIdx <> -1 Then newRow.Cells(repIdx).Value = repeat
            If fileIdx <> -1 Then newRow.Cells(fileIdx).Value = mp3

            ' Selecteer nieuwe rij
            dgv.CurrentCell = newRow.Cells(If(nameIdx <> -1, nameIdx, 0))

            ' UI bijwerken (balk knoppen)
            RefreshButtons(formOwner)
        Catch
        End Try
    End Sub

    Private Sub RunDeleteForSoundButtons(formOwner As Form)
        Try
            Dim dgv = TryFindSoundButtonsGrid(formOwner)
            If dgv Is Nothing OrElse Not dgv.Visible Then Return
            If dgv.CurrentRow Is Nothing OrElse dgv.CurrentRow.IsNewRow Then Return
            Dim idx = dgv.CurrentRow.Index
            dgv.Rows.RemoveAt(idx)
            RefreshButtons(formOwner)
        Catch
        End Try
    End Sub
End Module
