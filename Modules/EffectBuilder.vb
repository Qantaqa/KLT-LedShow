Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Module EffectBuilder
    ' Preview-marker posities (in seconden)
    Public PreviewMarkerStart As Double = 0.0
    Public PreviewMarkerEnd As Double = 90.0
    Public PreviewMarkerCurrent As Double = 0.0

    ' Marker-drag state
    Private markerDragType As String = ""
    Private markerMouseOffset As Integer = 0

    ' Panel en gekoppelde grids
    Private WithEvents _panel As Panel
    Private _dgTracks As DataGridView
    Private _dgLightSources As DataGridView

    ' Zoom/timeline parameters
    Private _zoomSeconds As Integer = 30    ' aantal seconden dat je standaard ziet
    Private _zoomScale As Single         ' pixels per seconde (berekend via RecalcScale)
    Private _maxSeconds As Integer = 90   ' maximale lengte van de tijdlijn

    ' Layout constants
    Private Const RowHeight As Integer = 36
    Private Const TrackMargin As Integer = 6
    Private Const LeftMargin As Integer = 60
    Private Const TimelineHeight As Integer = 24
    Private Const HandleWidth As Integer = 6

    ' Zoom-buttons
    Private minusRect As Rectangle
    Private plusRect As Rectangle

    ' Drag & resize state voor LightSources
    Private draggingLSRowIdx As Integer = -1
    Private dragMode As String = ""
    Private dragStartX As Integer
    Private origStartSec As Single
    Private origDurSec As Single

    ' Events om uit MainForm af te handelen
    Public Event LightSourceClicked(trackId As Integer, lsRowIndex As Integer)
    Public Event TrackClicked(trackId As Integer)


    ''' In je EffectBuilder-module:
    Public Sub Initialize(panel As Panel, dgTracks As DataGridView, dgLightSources As DataGridView, Optional zoomSeconds As Integer = 30)

        RecalcScale()

        panel.Dock = DockStyle.Fill
        panel.AutoScroll = True
        UpdateScrollRange()

        ' Haal oude handlers weg
        RemoveHandler panel.Paint, AddressOf OnPanelPaint
        RemoveHandler panel.MouseClick, AddressOf OnPanelClick
        RemoveHandler panel.MouseDown, AddressOf OnPanelMouseDown
        RemoveHandler panel.MouseMove, AddressOf OnPanelMouseMove
        RemoveHandler panel.MouseUp, AddressOf OnPanelMouseUp
        RemoveHandler panel.Scroll, AddressOf OnPanelScroll

        ' Voeg de nieuwe handlers toe
        AddHandler panel.Paint, AddressOf OnPanelPaint
        AddHandler panel.MouseClick, AddressOf OnPanelClick
        AddHandler panel.MouseDown, AddressOf OnPanelMouseDown
        AddHandler panel.MouseMove, AddressOf OnPanelMouseMove
        AddHandler panel.MouseUp, AddressOf OnPanelMouseUp
        AddHandler panel.Scroll, AddressOf OnPanelScroll

        panel.Cursor = Cursors.Default
        panel.Invalidate()
    End Sub


    ''' Wordt aangeroepen als je op een LightSource-blokje klikt
    Public Sub OnLightSourceClicked(trackId As Integer, lsRowIndex As Integer)
        On Error Resume Next

        ' 1) Selecteer eerst de juiste track in DG_Tracks
        For Each row As DataGridViewRow In FrmMain.DG_Tracks.Rows
            If Not row.IsNewRow AndAlso CInt(row.Cells("colTrackId").Value) = trackId Then
                FrmMain.DG_Tracks.ClearSelection()
                row.Selected = True
                Exit For
            End If
        Next

        ' 2) Selecteer de LightSource-rij in DG_LightSources
        FrmMain.DG_LightSources.ClearSelection()
        If lsRowIndex >= 0 AndAlso lsRowIndex < FrmMain.DG_LightSources.Rows.Count Then
            FrmMain.DG_LightSources.Rows(lsRowIndex).Selected = True
        End If

        ' 3) Bewaar selectie en toon marker op podium
        Dim SelectedLSRow = lsRowIndex
        Stage.SelectedLSIndex = lsRowIndex
        Stage.DrawSelectedMarker = True
        FrmMain.pb_Stage.Invalidate()

        ' 4) Open je detail-formulier
        Dim lsRow = FrmMain.DG_LightSources.Rows(lsRowIndex)
        Dim detailForm As New DetailLightSource()

        ' 5) Vul alle velden in het formulier
        With detailForm
            .txtStartMoment.Text = lsRow.Cells("colLSStartMoment").Value.ToString()
            .txtDuration.Text = lsRow.Cells("colLSDuration").Value.ToString()
            .txtPositionX.Text = lsRow.Cells("colLSPositionX").Value.ToString()
            .txtPositionY.Text = lsRow.Cells("colLSPositionY").Value.ToString()
            .txtSize.Text = lsRow.Cells("colLSSize").Value.ToString()
            .cmbShape.SelectedItem = lsRow.Cells("colLSShape").Value
            .cmbDirection.SelectedItem = lsRow.Cells("colLSDirection").Value
            .chkBlend.Checked = CBool(lsRow.Cells("colLSBlend").Value)

            ' Kleuren: ARGB-int omzetten naar Color
            .btnC1.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor1").Value))
            .btnC2.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor2").Value))
            .btnC3.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor3").Value))
            .btnC4.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor4").Value))
            .btnC5.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor5").Value))

            .cmbEffect.SelectedItem = lsRow.Cells("colLSEffect").Value
            .tbBrightnessBaseline.Value = CInt(lsRow.Cells("colLSBrightnessBaseline").Value)
            .tbBrightnessEffect.Value = CInt(lsRow.Cells("colLSBrightnessEffect").Value)

            ' Groepen: lees huidige ID-lijst uit grid
            Dim selGroupIds = CStr(lsRow.Cells("colLSGroups").Value) _
            .Split(","c) _
            .Select(Function(s) s.Trim()) _
            .Where(Function(s) s <> "") _
            .ToList()

            ' Vink in de TreeView die groeps-nodes aan
            For Each node As TreeNode In FrmMain.tvGroupsSelected.Nodes
                ' Hier gaan we ervan uit dat node.Tag = GroupId (String of Integer)
                Dim nodeId = CStr(node.Tag)
                node.Checked = selGroupIds.Contains(nodeId)
            Next
        End With

        ' 6) Toon dialog en sla wijzigingen op bij OK
        If detailForm.ShowDialog() = DialogResult.OK Then
            ' Schrijf alle waarden terug naar de grid
            lsRow.Cells("colLSStartMoment").Value = CDec(detailForm.txtStartMoment.Text)
            lsRow.Cells("colLSDuration").Value = CDec(detailForm.txtDuration.Text)
            lsRow.Cells("colLSPositionX").Value = CDec(detailForm.txtPositionX.Text)
            lsRow.Cells("colLSPositionY").Value = CDec(detailForm.txtPositionY.Text)
            lsRow.Cells("colLSSize").Value = CDec(detailForm.txtSize.Text)
            lsRow.Cells("colLSShape").Value = CStr(detailForm.cmbShape.SelectedItem)
            lsRow.Cells("colLSDirection").Value = CStr(detailForm.cmbDirection.SelectedItem)
            lsRow.Cells("colLSBlend").Value = detailForm.chkBlend.Checked

            lsRow.Cells("colLSColor1").Value = detailForm.btnC1.BackColor.ToArgb()
            lsRow.Cells("colLSColor2").Value = detailForm.btnC2.BackColor.ToArgb()
            lsRow.Cells("colLSColor3").Value = detailForm.btnC3.BackColor.ToArgb()
            lsRow.Cells("colLSColor4").Value = detailForm.btnC4.BackColor.ToArgb()
            lsRow.Cells("colLSColor5").Value = detailForm.btnC5.BackColor.ToArgb()

            lsRow.Cells("colLSEffect").Value = CStr(detailForm.cmbEffect.SelectedItem)
            lsRow.Cells("colLSBrightnessBaseline").Value = detailForm.tbBrightnessBaseline.Value
            lsRow.Cells("colLSBrightnessEffect").Value = detailForm.tbBrightnessEffect.Value

            ' Schrijf nieuwe groep-ID-lijst (gekoppeld aan node.Tag) terug
            Dim newGroupIds As New List(Of String)
            For Each node As TreeNode In detailForm.tvGroupsSelected.Nodes
                If node.Checked Then newGroupIds.Add(CStr(node.Tag))
            Next
            lsRow.Cells("colLSGroups").Value = String.Join(",", newGroupIds)

            ' Vernieuw timeline
            RefreshTimeline()
        End If
    End Sub

    ''' In je FrmMain (of waar je de events afgehandeld hebt):
    ''' Wordt aangeroepen als je op een lege track klikt
    Public Sub OnTrackClicked(trackId As Integer)
        ' Selecteer de juiste rij in DG_Tracks
        FrmMain.DG_Tracks.ClearSelection()
        For Each row As DataGridViewRow In FrmMain.DG_Tracks.Rows
            If Not row.IsNewRow AndAlso CInt(row.Cells("colTrackId").Value) = trackId Then
                row.Selected = True
                Exit For
            End If
        Next

        ' (optioneel) open hier je track-editor
        ' Dim tf As New TrackEditorForm(trackId)
        ' tf.ShowDialog()
    End Sub




    Public Sub EffectDesigner_Compile()
        ' 1) Bereken mm-offset door de UI margins (in px) om te rekenen naar mm
        Dim mmPerPx = Stage.GetMmPerPixel(FrmMain.pb_Stage)
        Dim offsetXmm = Stage.MarginLeft * mmPerPx
        Dim offsetYmm = Stage.MarginTop * mmPerPx

        ' Reference naar grids
        Dim meGrid = FrmMain.DG_MyEffects
        Dim framesGrid = FrmMain.DG_MyEffectsFrames

        If meGrid.CurrentRow Is Nothing Then
            MessageBox.Show("Selecteer eerst een effect in DG_MyEffect.", "Geen effect", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim effectId = CInt(meGrid.CurrentRow.Cells("colMEID").Value)

        ' Verwijder oude frames
        For i As Integer = framesGrid.Rows.Count - 1 To 0 Step -1
            If CInt(framesGrid.Rows(i).Cells("colMF_MEID").Value) = effectId Then
                framesGrid.Rows.RemoveAt(i)
            End If
        Next

        ' Bepaal maxEnd
        Dim maxEnd As Double = 0
        For Each lsRow As DataGridViewRow In FrmMain.DG_LightSources.Rows
            If lsRow.IsNewRow Then Continue For
            If lsRow.Cells("colLSTrackId").Value = "" Then Continue For

            Dim trackId = CInt(lsRow.Cells("colLSTrackId").Value)
            Dim trackRow = FrmMain.DG_Tracks.Rows _
                       .Cast(Of DataGridViewRow)() _
                       .FirstOrDefault(Function(r) Not r.IsNewRow AndAlso CInt(r.Cells("colTrackId").Value) = trackId)
            If trackRow Is Nothing OrElse Not CBool(trackRow.Cells("colTrackActive").Value) Then Continue For

            Dim startSec = CDbl(lsRow.Cells("colLSStartMoment").Value)
            Dim durSec = CDbl(lsRow.Cells("colLSDuration").Value)
            maxEnd = Math.Max(maxEnd, startSec + durSec)
        Next
        maxEnd = Math.Min(maxEnd, 90)

        Dim fps = 5, totalFrames = CInt(Math.Ceiling(maxEnd * fps))

        ' Digi de device-led counts
        Dim deviceCounts = New Dictionary(Of String, Integer)
        For Each info In LedLijst
            deviceCounts(info.DeviceNaam) = Math.Max(deviceCounts.GetValueOrDefault(info.DeviceNaam, 0), info.IndexInDevice + 1)
        Next

        ' Initialiseér deviceFrames
        Dim deviceFrames = New Dictionary(Of String, List(Of Byte()))()
        For Each dev In deviceCounts.Keys
            deviceFrames(dev) = New List(Of Byte())()
        Next

        ' Frame-loop
        For frameIdx = 0 To totalFrames - 1
            Dim t = frameIdx / fps

            ' Maak buffers
            Dim buffers = New Dictionary(Of String, Byte())
            For Each dev In deviceCounts.Keys
                buffers(dev) = New Byte(deviceCounts(dev) * 3 - 1) {}
            Next

            ' LightSources
            For Each lsRow As DataGridViewRow In FrmMain.DG_LightSources.Rows
                If lsRow.IsNewRow OrElse lsRow.Cells("colLSTrackId").Value = "" Then Continue For

                Dim trackId = CInt(lsRow.Cells("colLSTrackId").Value)
                Dim trRow = FrmMain.DG_Tracks.Rows _
                        .Cast(Of DataGridViewRow)() _
                        .FirstOrDefault(Function(r) Not r.IsNewRow AndAlso CInt(r.Cells("colTrackId").Value) = trackId)
                If trRow Is Nothing OrElse Not CBool(trRow.Cells("colTrackActive").Value) Then Continue For

                Dim startSec = CDbl(lsRow.Cells("colLSStartMoment").Value)
                Dim durSec = CDbl(lsRow.Cells("colLSDuration").Value)
                If t < startSec OrElse t > startSec + durSec Then Continue For

                Dim c1 = Color.FromArgb(CInt(lsRow.Cells("colLSColor1").Value))
                Dim blend = CBool(lsRow.Cells("colLSBlend").Value)

                ' Groepslijst van LS
                Dim groupList = CStr(lsRow.Cells("colLSGroups").Value) _
                            .Split(","c) _
                            .Where(Function(s) Not String.IsNullOrWhiteSpace(s)) _
                            .Select(Function(s) CInt(s.Trim())) _
                            .ToList()

                ' LS-center in mm (UI offset al afgetrokken bij instellen)
                Dim lsXmm = CDbl(lsRow.Cells("colLSPositionX").Value)
                Dim lsYmm = CDbl(lsRow.Cells("colLSPositionY").Value)

                ' Pas toe op elke LED
                For Each info In LedLijst
                    ' Led-groepen
                    Dim infoGroups = If(
                    String.IsNullOrEmpty(info.GroupId),
                    New List(Of Integer),
                    info.GroupId.Split(","c).Select(Function(s) CInt(s.Trim())).ToList()
                )

                    ' 1) overlap qua groep?
                    If Not infoGroups.Any(Function(g) groupList.Contains(g)) Then Continue For

                    ' 2) offset-meerekening in mm-space
                    Dim dxMm = (info.Xmm - offsetXmm) - (lsXmm - offsetXmm)
                    Dim dyMm = (info.Ymm - offsetYmm) - (lsYmm - offsetYmm)

                    ' 3) shape-test (bv. cirkel)
                    Dim inShape As Boolean = False
                    Dim shape = CStr(lsRow.Cells("colLSShape").Value)
                    Dim sizeMm = CDbl(lsRow.Cells("colLSSize").Value)
                    Select Case shape
                        Case "Circle"
                            inShape = (dxMm * dxMm + dyMm * dyMm) <= sizeMm * sizeMm
                        Case "Square"
                            Dim half = sizeMm
                            inShape = (Math.Abs(dxMm) <= half AndAlso Math.Abs(dyMm) <= half)
                        Case "Cone"
                            Dim v = Stage.DirectionVector(Dir, 1)
                            Dim len = Math.Sqrt(v.X * v.X + v.Y * v.Y)
                            If len > 0 Then
                                Dim ux = v.X / len, uy = -v.Y / len
                                Dim dist = Math.Sqrt(dxMm * dxMm + dyMm * dyMm)
                                If dist > 0 Then
                                    Dim proj = dxMm * ux + dyMm * uy
                                    Dim cosHalf = Math.Cos(Math.PI / 6)
                                    If proj > 0 AndAlso proj <= sizeMm AndAlso proj / dist >= cosHalf Then inShape = True
                                End If
                            End If
                    End Select
                    If Not inShape Then Continue For

                    ' 4) kleuren inbuffer
                    Dim buf = buffers(info.DeviceNaam)
                    Dim idx = info.IndexInDevice * 3
                    If blend Then
                        Dim sumR = CInt(buf(idx)) + c1.R : If sumR > 255 Then sumR = 255
                        Dim sumG = CInt(buf(idx + 1)) + c1.G : If sumG > 255 Then sumG = 255
                        Dim sumB = CInt(buf(idx + 2)) + c1.B : If sumB > 255 Then sumB = 255
                        buf(idx) = CByte(sumR)
                        buf(idx + 1) = CByte(sumG)
                        buf(idx + 2) = CByte(sumB)
                    Else
                        buf(idx) = CByte(c1.R)
                        buf(idx + 1) = CByte(c1.G)
                        buf(idx + 2) = CByte(c1.B)
                    End If
                Next
            Next

            ' Sla buffers op
            For Each dev In deviceFrames.Keys
                deviceFrames(dev).Add(buffers(dev))
            Next
        Next

        ' Wegschrijven naar DG_MyEffectsFrames
        For Each kvp In deviceFrames
            Dim devName = kvp.Key
            Dim framesList = kvp.Value
            Dim rowIdx = framesGrid.Rows.Add()
            With framesGrid.Rows(rowIdx)
                .Cells("colMF_MEID").Value = effectId
                .Cells("colMF_FixtureID").Value = devName
                .Cells("colMF_Frames").Value = framesList
            End With
        Next

        ToonFlashBericht($"Compile klaar: {totalFrames} frames per device aangemaakt.", 3)
    End Sub

    ' Herverschaalt de pixel-per-seconde factor
    Private Sub RecalcScale()
        If _panel IsNot Nothing Then
            Dim availWidth = Math.Max(1, _panel.ClientSize.Width - LeftMargin)
            _zoomScale = availWidth / _zoomSeconds
        End If
    End Sub

    ' Past de AutoScrollMinSize van het panel aan op basis van tracks en timeline-lengte
    Private Sub UpdateScrollRange()
        On Error Resume Next
        If (FrmMain.DG_Tracks.Rows.Count <> 0) Then
            Dim trackCount = _dgTracks.Rows.Cast(Of DataGridViewRow)().Count(Function(r) Not r.IsNewRow)
            Dim totalHeight = TimelineHeight + TrackMargin + trackCount * (RowHeight + TrackMargin)
            Dim totalWidth = LeftMargin + CInt(_maxSeconds * _zoomScale)
            _panel.AutoScrollMinSize = New Size(totalWidth, totalHeight)
        End If
    End Sub

    ' Hertekent de hele timeline (tracks, blocks, markers, etc.)
    Private Sub OnPanelPaint(sender As Object, e As PaintEventArgs)

        Dim g = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.Clear(FrmMain.PanelTracks.BackColor)
        If _dgTracks Is Nothing OrElse _dgLightSources Is Nothing Then Return

        Dim xOffset = FrmMain.PanelTracks.AutoScrollPosition.X
        Dim yOffset = FrmMain.PanelTracks.AutoScrollPosition.Y

        DrawTimelineAxis(g, xOffset, yOffset)
        DrawZoomButtons(g, xOffset, yOffset)

        ' <-- hier je bestaande loop om tracks & light-sources te tekenen -->

        DrawPreviewMarkers(g, xOffset, yOffset)
    End Sub

    ' Handelt klikken op de panel (zoom-knoppen of selectie/markers) af
    Private Sub OnPanelClick(sender As Object, e As MouseEventArgs)
        Dim pt = e.Location
        If minusRect.Contains(pt) Then
            _maxSeconds = Math.Max(10, _maxSeconds - 10)
            RefreshTimeline() : Return
        ElseIf plusRect.Contains(pt) Then
            _maxSeconds += 10
            RefreshTimeline() : Return
        End If

        HandleMouseEvent(e.X, e.Y, isClick:=True)

        ' Timeline-area: maak of sleep preview-markers
        Dim ty = FrmMain.PanelTracks.AutoScrollPosition.Y + TimelineHeight
        If e.Y < ty Then
            If e.Button = MouseButtons.Left Then
                ' bepaal sec, zet of sleep Start/End/Current
                Dim sec = (e.X - FrmMain.PanelTracks.AutoScrollPosition.X - LeftMargin) / _zoomScale
                ' … jouw marker-logica …
                RefreshTimeline()
            ElseIf e.Button = MouseButtons.Right Then
                ' reset marker
                ' … jouw reset-logica …
                RefreshTimeline()
            End If
            Return
        End If
    End Sub

    ' Start van een drag/resize op een LightSource
    Private Sub OnPanelMouseDown(sender As Object, e As MouseEventArgs)
        HandleMouseEvent(e.X, e.Y, isDown:=True)
    End Sub

    ' Tijdens muis-beweging: sleep markers of LightSources
    Private Sub OnPanelMouseMove(sender As Object, e As MouseEventArgs)
        ' Sleep Preview-marker?
        If markerDragType <> "" AndAlso e.Button = MouseButtons.Left Then
            ' … jouw marker-verplaats-code …
            RefreshTimeline() : Return
        End If

        ' Sleep LightSource?
        If draggingLSRowIdx >= 0 Then
            ' … jouw LightSource drag/resize code …
            _panel.Invalidate()
        End If
    End Sub

    ' Einde van drag-operatie
    Private Sub OnPanelMouseUp(sender As Object, e As MouseEventArgs)
        draggingLSRowIdx = -1
        dragMode = ""
        markerDragType = ""
    End Sub

    ' Bij scroll (vertical of horizontal) de timeline verversen
    Private Sub OnPanelScroll(sender As Object, e As ScrollEventArgs)
        RefreshTimeline()
    End Sub

    ' Public helper om alles opnieuw te schalen en tekenen
    Public Sub RefreshTimeline()
        If _panel IsNot Nothing Then
            RecalcScale()
            UpdateScrollRange()
            _panel.Invalidate()
        End If
    End Sub

    ''' <summary>
    ''' Teken de tijdlijn-as met tickmarks en labels.
    ''' </summary>
    Private Sub DrawTimelineAxis(g As Graphics, xOffset As Integer, yOffset As Integer)
        Dim axisY = yOffset + TimelineHeight - 1
        Dim axisW = CInt(_maxSeconds * _zoomScale)
        ' Hoofd-as
        g.DrawLine(Pens.Gray,
               xOffset + LeftMargin, axisY,
               xOffset + LeftMargin + axisW, axisY)
        ' Tickmarks en 5-sec labels
        For s = 0 To _maxSeconds
            Dim xPos = xOffset + LeftMargin + CInt(s * _zoomScale)
            g.DrawLine(Pens.Gray,
                   xPos, axisY,
                   xPos, axisY - 6)
            If s Mod 5 = 0 Then
                g.DrawString(s.ToString(),
                         SystemFonts.DefaultFont,
                         Brushes.White,
                         xPos - 6,
                         axisY - 18)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Teken de +10s/–10s knopjes aan het eind van de as.
    ''' </summary>
    Private Sub DrawZoomButtons(g As Graphics, xOffset As Integer, yOffset As Integer)
        Dim axisEndX = xOffset + LeftMargin + CInt(_maxSeconds * _zoomScale)
        Dim cy = yOffset + 2
        minusRect = New Rectangle(axisEndX + 4, cy, 24, 16)
        plusRect = New Rectangle(axisEndX + 32, cy, 24, 16)

        g.DrawRectangle(Pens.White, minusRect)
        g.DrawString("-10s",
                 SystemFonts.DefaultFont,
                 Brushes.White,
                 minusRect.Location)

        g.DrawRectangle(Pens.White, plusRect)
        g.DrawString("+10s",
                 SystemFonts.DefaultFont,
                 Brushes.White,
                 plusRect.Location)
    End Sub

    ''' <summary>
    ''' Teken de drie preview-markers: start (groen), end (rood) en current (lichtblauwe pijl).
    ''' </summary>
    Private Sub DrawPreviewMarkers(g As Graphics, xOffset As Integer, yOffset As Integer)
        ' Bepaal verticale extent: van top tot onder tracks
        Dim axisY1 = yOffset
        Dim trackCount = _dgTracks.Rows.Cast(Of DataGridViewRow)().Count(Function(r) Not r.IsNewRow)
        Dim axisY2 = yOffset + TimelineHeight + trackCount * (RowHeight + TrackMargin)

        ' START marker (groen)
        Dim xS = xOffset + LeftMargin + CInt(PreviewMarkerStart * _zoomScale)
        Using pen As New Pen(Color.Lime, 2)
            g.DrawLine(pen, xS, axisY1, xS, axisY2)
        End Using

        ' END marker (rood)
        Dim xE = xOffset + LeftMargin + CInt(PreviewMarkerEnd * _zoomScale)
        Using pen As New Pen(Color.Red, 2)
            g.DrawLine(pen, xE, axisY1, xE, axisY2)
        End Using

        ' CURRENT marker (lichtblauwe pijl, wat dikker)
        Dim xC = xOffset + LeftMargin + CInt(PreviewMarkerCurrent * _zoomScale)
        Using pen As New Pen(Color.LightSkyBlue, 3)
            ' pijl omhoog
            Dim topY = axisY1 + 2
            Dim botY = axisY1 + 14
            g.DrawLine(pen, xC, botY, xC, topY)               ' steel
            g.DrawLine(pen, xC, topY, xC - 6, topY + 8)       ' vleugel links
            g.DrawLine(pen, xC, topY, xC + 6, topY + 8)       ' vleugel rechts
        End Using
    End Sub

    ''' <summary>
    ''' Afhandelen van klik/drag events voor LightSources en voor TrackClick-events.
    ''' </summary>
    Private Sub HandleMouseEvent(x As Integer, y As Integer, Optional isClick As Boolean = False, Optional isDown As Boolean = False)
        On Error Resume Next
        If _dgTracks Is Nothing OrElse _dgLightSources Is Nothing Then Return

        Dim xOffset = _panel.AutoScrollPosition.X
        Dim yOffset = _panel.AutoScrollPosition.Y

        ' Bepaal welke track-rij (verticale index) je hebt aangeklikt
        Dim idx = (y - yOffset - TimelineHeight - TrackMargin) \ (RowHeight + TrackMargin)
        If idx < 0 OrElse idx >= _dgTracks.Rows.Count Then
            If isClick Then RaiseEvent TrackClicked(-1)
            Return
        End If
        Dim trackId = CInt(_dgTracks.Rows(idx).Cells("colTrackId").Value)
        Dim yTop = yOffset + TimelineHeight + TrackMargin + idx * (RowHeight + TrackMargin)

        ' Loop langs alle LightSources voor deze track
        For j = 0 To _dgLightSources.Rows.Count - 1
            Dim rowLS = _dgLightSources.Rows(j)
            If rowLS.IsNewRow OrElse CInt(rowLS.Cells("colLSTrackId").Value) <> trackId Then Continue For

            Dim startSec = CSng(rowLS.Cells("colLSStartMoment").Value)
            Dim durSec = CSng(rowLS.Cells("colLSDuration").Value)
            Dim rx = xOffset + LeftMargin + CInt(startSec * _zoomScale)
            Dim rw = Math.Max(HandleWidth, CInt(durSec * _zoomScale))
            Dim rect = New Rectangle(rx, yTop + 4, rw, RowHeight - 8)

            If rect.Contains(New Point(x, y)) Then
                If isDown Then
                    ' Begin drag/resize
                    draggingLSRowIdx = j
                    dragStartX = x
                    origStartSec = startSec
                    origDurSec = durSec
                    dragMode = If(x >= rect.Right - HandleWidth, "Resize", "Move")
                ElseIf isClick Then
                    ' Klik binnen LightSource → event om detail te openen
                    RaiseEvent LightSourceClicked(trackId, j)
                End If
                Return
            End If
        Next

        ' Als we hier zijn en het was een click in de lege track-zone:
        If isClick Then RaiseEvent TrackClicked(trackId)
    End Sub

    Public Sub SetZoom(zoomSeconds As Integer)
        _zoomSeconds = zoomSeconds
        RecalcScale()
        RefreshTimeline()
    End Sub
End Module
