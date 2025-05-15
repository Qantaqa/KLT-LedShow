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
    Private markerIsDragging As Boolean = False
    Private skipNextClick As Boolean = False

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
        _panel = panel
        _dgTracks = dgTracks
        _dgLightSources = dgLightSources
        _zoomSeconds = zoomSeconds

        RecalcScale()

        _panel.Dock = DockStyle.Fill
        _panel.AutoScroll = True
        UpdateScrollRange()

        ' Haal oude handlers weg
        RemoveHandler _panel.Paint, AddressOf OnPanelPaint
        RemoveHandler _panel.MouseClick, AddressOf OnPanelClick
        RemoveHandler _panel.MouseDown, AddressOf OnPanelMouseDown
        RemoveHandler _panel.MouseMove, AddressOf OnPanelMouseMove
        RemoveHandler _panel.MouseUp, AddressOf OnPanelMouseUp
        RemoveHandler _panel.Scroll, AddressOf OnPanelScroll

        ' Voeg de nieuwe handlers toe
        AddHandler _panel.Paint, AddressOf OnPanelPaint
        AddHandler _panel.MouseClick, AddressOf OnPanelClick
        AddHandler _panel.MouseDown, AddressOf OnPanelMouseDown
        AddHandler _panel.MouseMove, AddressOf OnPanelMouseMove
        AddHandler _panel.MouseUp, AddressOf OnPanelMouseUp
        AddHandler _panel.Scroll, AddressOf OnPanelScroll

        panel.Cursor = Cursors.Default
        panel.Invalidate()
    End Sub


    ''' Wordt aangeroepen als je op een LightSource-blokje klikt
    Public Sub OnLightSourceClicked(trackId As Integer, lsRowIndex As Integer)
        On Error Resume Next

        ' 1) Selecteer de juiste track in DG_Tracks
        For Each row As DataGridViewRow In _dgTracks.Rows
            If Not row.IsNewRow AndAlso CInt(row.Cells("colTrackId").Value) = trackId Then
                _dgTracks.ClearSelection()
                row.Selected = True
                Exit For
            End If
        Next

        ' 2) Selecteer de LightSource-rij in DG_LightSources
        _dgLightSources.ClearSelection()
        If lsRowIndex >= 0 AndAlso lsRowIndex < _dgLightSources.Rows.Count Then
            _dgLightSources.Rows(lsRowIndex).Selected = True
        End If

        ' 3) Toon marker op het podium
        Stage.SelectedLSIndex = lsRowIndex
        Stage.DrawSelectedMarker = True
        FrmMain.pb_Stage.Invalidate()

        ' 4) Haal de DataGridViewRow op en maak detailForm
        Dim lsRow = _dgLightSources.Rows(lsRowIndex)
        Dim detailForm As New DetailLightSource()

        ' 5) Vul alle velden in detailForm
        With detailForm
            .txtStartMoment.Text = lsRow.Cells("colLSStartMoment").Value.ToString()
            .txtDuration.Text = lsRow.Cells("colLSDuration").Value.ToString()
            .txtPositionX.Text = lsRow.Cells("colLSPositionX").Value.ToString()
            .txtPositionY.Text = lsRow.Cells("colLSPositionY").Value.ToString()
            .txtSize.Text = lsRow.Cells("colLSSize").Value.ToString()
            .cmbShape.SelectedItem = lsRow.Cells("colLSShape").Value
            .cmbDirection.SelectedItem = lsRow.Cells("colLSDirection").Value
            .chkBlend.Checked = CBool(lsRow.Cells("colLSBlend").Value)

            ' Kleuren
            .btnC1.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor1").Value))
            .btnC2.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor2").Value))
            .btnC3.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor3").Value))
            .btnC4.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor4").Value))
            .btnC5.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor5").Value))

            .cmbEffect.SelectedItem = lsRow.Cells("colLSEffect").Value
            .tbBrightnessBaseline.Value = CInt(lsRow.Cells("colLSBrightnessBaseline").Value)
            .tbBrightnessEffect.Value = CInt(lsRow.Cells("colLSBrightnessEffect").Value)

            ' —————————————————————————————————————————————————————————
            ' 6) Groepen: clone & vink nodes aan
            ' —————————————————————————————————————————————————————————

            ' a) Clone de hoofd-TreeView inclusief Tag
            .tvGroupsSelected.BeginUpdate()
            .tvGroupsSelected.Nodes.Clear()
            For Each rootNode As TreeNode In FrmMain.tvGroupsSelected.Nodes
                Dim clone As TreeNode = DirectCast(rootNode.Clone(), TreeNode)
                clone.Tag = rootNode.Tag   ' **zorg dat Tag wordt meegekopieerd**
                ' voor alle child-nodes geldt hetzelfde, maar Clone() kopieert Children+Tags
                .tvGroupsSelected.Nodes.Add(clone)
            Next
            .tvGroupsSelected.ExpandAll()
            .tvGroupsSelected.EndUpdate()

            ' b) Lees opgeslagen groep-IDs (CSV in colLSGroups)
            Dim selGroupIds As New List(Of String)
            If Not IsDBNull(lsRow.Cells("colLSGroups").Value) Then
                selGroupIds = CStr(lsRow.Cells("colLSGroups").Value) _
                .Split(","c) _
                .Select(Function(s) s.Trim()) _
                .Where(Function(s) s <> "") _
                .ToList()
            End If

            ' c) Recursief alle nodes controleren
            .tvGroupsSelected.BeginUpdate()
            DetailLightSource.CheckAndMarkNodes(.tvGroupsSelected.Nodes, selGroupIds)
            .tvGroupsSelected.ExpandAll()
            .tvGroupsSelected.EndUpdate()
        End With

        ' 7) Toon dialog en sla wijzigingen op bij OK
        If detailForm.ShowDialog() = DialogResult.OK Then
            ' a) Update alle LightSource velden
            lsRow.Cells("colLSStartMoment").Value = CDec(detailForm.txtStartMoment.Text)
            lsRow.Cells("colLSDuration").Value = CDec(detailForm.txtDuration.Text)
            lsRow.Cells("colLSPositionX").Value = CDec(detailForm.txtPositionX.Text)
            lsRow.Cells("colLSPositionY").Value = CDec(detailForm.txtPositionY.Text)
            lsRow.Cells("colLSSize").Value = CDec(detailForm.txtSize.Text)
            lsRow.Cells("colLSShape").Value = detailForm.cmbShape.SelectedItem.ToString()
            lsRow.Cells("colLSDirection").Value = detailForm.cmbDirection.SelectedItem.ToString()
            lsRow.Cells("colLSBlend").Value = detailForm.chkBlend.Checked

            lsRow.Cells("colLSColor1").Value = detailForm.btnC1.BackColor.ToArgb()
            lsRow.Cells("colLSColor2").Value = detailForm.btnC2.BackColor.ToArgb()
            lsRow.Cells("colLSColor3").Value = detailForm.btnC3.BackColor.ToArgb()
            lsRow.Cells("colLSColor4").Value = detailForm.btnC4.BackColor.ToArgb()
            lsRow.Cells("colLSColor5").Value = detailForm.btnC5.BackColor.ToArgb()

            If (detailForm.cmbEffect.SelectedItem Is Nothing) Then
                lsRow.Cells("colLSEffect").Value = ""
            Else
                lsRow.Cells("colLSEffect").Value = detailForm.cmbEffect.SelectedItem.ToString()
            End If
            lsRow.Cells("colLSBrightnessBaseline").Value = detailForm.tbBrightnessBaseline.Value
            lsRow.Cells("colLSBrightnessEffect").Value = detailForm.tbBrightnessEffect.Value

            lsRow.Cells("colLSGroups").Value = String.Join(",", detailForm.SelectedGroupIds)
        End If
        RefreshTimeline()
    End Sub

    ''' <summary>
    ''' Helper om alle child-nodes (recursief) dezelfde Checked-status te geven.
    ''' </summary>
    Private Sub CheckAllChildNodes(node As TreeNode, isChecked As Boolean)
        For Each child As TreeNode In node.Nodes
            child.Checked = isChecked
            CheckAllChildNodes(child, isChecked)
        Next
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

        Dim fps = 5
        Dim totalFrames = CInt(Math.Ceiling(maxEnd * fps))

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
                Dim direction = lsRow.Cells("colLSDirection").Value.ToString()
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
                Dim lsXcm = CDbl(lsRow.Cells("colLSPositionX").Value)
                Dim lsXmm = lsXcm * 10
                Dim lsYCm = CDbl(lsRow.Cells("colLSPositionY").Value)
                Dim lsYmm = lsYCm * 10

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
                    Dim sizeCm = CDbl(lsRow.Cells("colLSSize").Value)
                    Dim sizeMm = (sizeCm * 10) / 2
                    Select Case shape
                        Case "Circle"
                            inShape = (dxMm * dxMm + dyMm * dyMm) <= sizeMm * sizeMm
                        Case "Square"
                            Dim half = sizeMm
                            inShape = (Math.Abs(dxMm) <= half AndAlso Math.Abs(dyMm) <= half)
                        Case "Cone"
                            Dim v = Stage.DirectionVector(direction, 1)
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
        On Error Resume Next

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.Clear(_panel.BackColor)
        If _dgTracks Is Nothing OrElse _dgLightSources Is Nothing Then Return

        Dim xOffset = _panel.AutoScrollPosition.X
        Dim yOffset = _panel.AutoScrollPosition.Y

        ' 1) Teken as en zoom-knoppen
        DrawTimelineAxis(g, xOffset, yOffset)
        DrawZoomButtons(g, xOffset, yOffset)

        ' 2) Track- en LightSource-balkjes
        Dim fontLarge = New Font(SystemFonts.DefaultFont.FontFamily, 12, FontStyle.Bold)
        Dim fontSmall = New Font(SystemFonts.DefaultFont.FontFamily, 8, FontStyle.Regular)

        For i = 0 To _dgTracks.Rows.Count - 1
            Dim rowT = _dgTracks.Rows(i)
            If rowT.IsNewRow Then Continue For

            Dim trackId = CInt(rowT.Cells("colTrackId").Value)
            Dim trackName = CStr(rowT.Cells("colTrackName").Value)
            Dim active = If(IsDBNull(rowT.Cells("colTrackActive").Value), False, CBool(rowT.Cells("colTrackActive").Value))

            ' bepaal vertical positie
            Dim yTop = yOffset + TimelineHeight + TrackMargin + i * (RowHeight + TrackMargin)
            Dim trackRect = New Rectangle(0, yTop, _panel.ClientSize.Width, RowHeight)
            Dim bgColor = If(active, Color.Black, Color.FromArgb(30, 30, 30))

            Using bg As New SolidBrush(bgColor)
                g.FillRectangle(bg, trackRect)
            End Using

            Dim textBrush = If(active, Brushes.White, Brushes.Gray)
            g.DrawString(trackId.ToString(), fontLarge, textBrush, 4, yTop + 2)
            g.DrawString(trackName, fontSmall, textBrush, 4, yTop + 2 + fontLarge.Height)

            ' draw each LightSource in deze track
            For j = 0 To _dgLightSources.Rows.Count - 1
                Dim rowLS = _dgLightSources.Rows(j)
                If rowLS.IsNewRow OrElse CInt(rowLS.Cells("colLSTrackId").Value) <> trackId Then Continue For

                Dim startSec = CSng(rowLS.Cells("colLSStartMoment").Value)
                Dim durSec = CSng(rowLS.Cells("colLSDuration").Value)
                Dim col1 = CType(rowLS.Cells("colLSColor1").Tag, Color)
                Dim col2 = CType(rowLS.Cells("colLSColor2").Tag, Color)
                Dim shape = CStr(rowLS.Cells("colLSShape").Value)

                Dim xPx = xOffset + LeftMargin + CInt(startSec * _zoomScale)
                Dim wPx = Math.Max(HandleWidth, CInt(durSec * _zoomScale))
                Dim lsRect = New Rectangle(xPx, yTop + 4, wPx, RowHeight - 8)

                ' 1) vul de gradient
                Using br As New LinearGradientBrush(lsRect, col1, col2, LinearGradientMode.Horizontal)
                    g.FillRectangle(br, lsRect)
                End Using

                ' 2) kies pen-kleur op basis van selectie-status
                Dim isSelected As Boolean = _dgLightSources.Rows(j).Selected
                Dim borderPen As Pen = If(isSelected, Pens.Yellow, Pens.White)
                g.DrawRectangle(borderPen, lsRect)

                ' 3) grips blijven hetzelfde
                Using gripL As New SolidBrush(Color.Green)
                    g.FillRectangle(gripL, New Rectangle(lsRect.Left, lsRect.Top, HandleWidth, lsRect.Height))
                End Using
                Using gripR As New SolidBrush(Color.Red)
                    g.FillRectangle(gripR, New Rectangle(lsRect.Right - HandleWidth, lsRect.Top, HandleWidth, lsRect.Height))
                End Using

                ' 4) en tenslotte je shape-icoon
                DrawShapeIcon(g, shape, lsRect)
            Next
        Next

        fontLarge.Dispose()
        fontSmall.Dispose()

        ' 3) Preview-markers (start / end / current)
        DrawPreviewMarkers(g, xOffset, yOffset)
    End Sub

    ' Handelt klikken op de panel (zoom-knoppen of selectie/markers) af
    Private Sub OnPanelClick(sender As Object, e As MouseEventArgs)
        ' 1) Als we net een marker gesleept hebben, de click negeren
        If skipNextClick Then
            skipNextClick = False
            Return
        End If

        ' 2) Zoom-knoppen?
        Dim pt As Point = e.Location
        If minusRect.Contains(pt) Then
            _maxSeconds = Math.Max(10, _maxSeconds - 10)
            RefreshTimeline()
            Return
        ElseIf plusRect.Contains(pt) Then
            _maxSeconds += 10
            RefreshTimeline()
            Return
        End If

        ' 3) Eerst LightSource of Track clicks (zorg dat detail-scherm niet opent bij marker-drag)
        HandleMouseEvent(e.X, e.Y, isClick:=True)

        ' 4) Timeline-gebied (boven de track-bars): plaats of sleep preview-markers
        Dim xOffset = _panel.AutoScrollPosition.X
        Dim yOffset = _panel.AutoScrollPosition.Y
        Dim ty = yOffset + TimelineHeight
        If e.Y < ty Then
            Dim sec As Double = (e.X - xOffset - LeftMargin) / _zoomScale

            If e.Button = MouseButtons.Left Then
                ' a) Klik of begin drag op bestaande marker?
                Dim xS = xOffset + LeftMargin + CInt(PreviewMarkerStart * _zoomScale)
                Dim xE = xOffset + LeftMargin + CInt(PreviewMarkerEnd * _zoomScale)
                Dim xC = xOffset + LeftMargin + CInt(PreviewMarkerCurrent * _zoomScale)
                Const tol = 5

                If Math.Abs(e.X - xS) < tol Then
                    ' Start-marker slepen
                    markerDragType = "Start"
                    markerMouseOffset = e.X - xS
                ElseIf Math.Abs(e.X - xE) < tol Then
                    ' End-marker slepen
                    markerDragType = "End"
                    markerMouseOffset = e.X - xE
                ElseIf Math.Abs(e.X - xC) < tol Then
                    ' Current-marker slepen
                    markerDragType = "Current"
                    markerMouseOffset = e.X - xC
                Else
                    ' nieuw plaatsen: eerst Start, daarna End, anders Current
                    If PreviewMarkerStart <= 0 Then
                        PreviewMarkerStart = Math.Max(0, Math.Min(_maxSeconds, sec))
                    ElseIf PreviewMarkerEnd >= _maxSeconds Then
                        PreviewMarkerEnd = Math.Max(0, Math.Min(_maxSeconds, sec))
                    Else
                        PreviewMarkerCurrent = Math.Max(0, Math.Min(_maxSeconds, sec))
                    End If
                    ' omdat we hier echt op de as klikken: meteen preview sturen
                    RefreshTimeline()
                    SendPreviewFrame()
                    Return
                End If

            ElseIf e.Button = MouseButtons.Right Then
                ' resetten van markers
                Dim xS = xOffset + LeftMargin + CInt(PreviewMarkerStart * _zoomScale)
                Dim xE = xOffset + LeftMargin + CInt(PreviewMarkerEnd * _zoomScale)
                Dim xC = xOffset + LeftMargin + CInt(PreviewMarkerCurrent * _zoomScale)
                Const tol = 5

                If Math.Abs(e.X - xS) < tol Then PreviewMarkerStart = 0
                If Math.Abs(e.X - xE) < tol Then PreviewMarkerEnd = _maxSeconds
                If Math.Abs(e.X - xC) < tol Then PreviewMarkerCurrent = 0

                RefreshTimeline()
                SendPreviewFrame()
                Return
            End If

            ' Als we tot hier komen: we zijn begonnen met slepen
            skipNextClick = True
            RefreshTimeline()
            Return
        End If

        ' 5) Als we hier zijn geweest zonder in de timeline te klikken,
        '    dan is het een klik op lege track-ruimte of op een LightSource.
        '    Die worden al afgehandeld in HandleMouseEvent / RaiseEvent.
    End Sub





    ' Start van een drag/resize op een LightSource
    Private Sub OnPanelMouseDown(sender As Object, e As MouseEventArgs)
        Dim xOffset = _panel.AutoScrollPosition.X

        ' Reset slepen-flag
        markerIsDragging = False

        ' 1) Begin eventueel marker-drag
        If e.Button = MouseButtons.Left Then
            Dim mxStart = xOffset + LeftMargin + CInt(PreviewMarkerStart * _zoomScale)
            Dim mxEnd = xOffset + LeftMargin + CInt(PreviewMarkerEnd * _zoomScale)
            Dim mxCur = xOffset + LeftMargin + CInt(PreviewMarkerCurrent * _zoomScale)
            If Math.Abs(e.X - mxStart) <= 5 Then
                markerDragType = "Start"
                markerMouseOffset = e.X - mxStart
                Return
            ElseIf Math.Abs(e.X - mxEnd) <= 5 Then
                markerDragType = "End"
                markerMouseOffset = e.X - mxEnd
                Return
            ElseIf Math.Abs(e.X - mxCur) <= 5 Then
                markerDragType = "Current"
                markerMouseOffset = e.X - mxCur
                Return
            End If
        End If

        ' 2) Anders LightSource-drag
        HandleMouseEvent(e.X, e.Y, isDown:=True)
    End Sub

    ' Tijdens muis-beweging: sleep markers of LightSources
    Private Sub OnPanelMouseMove(sender As Object, e As MouseEventArgs)
        ' 1) Marker slepen
        If markerDragType <> "" AndAlso e.Button = MouseButtons.Left Then
            markerIsDragging = True
            Dim xOffset = _panel.AutoScrollPosition.X
            Dim rawSec = (e.X - markerMouseOffset - xOffset - LeftMargin) / _zoomScale
            Dim sec = Math.Max(0, Math.Min(_maxSeconds, rawSec))
            Select Case markerDragType
                Case "Start" : PreviewMarkerStart = sec
                Case "End" : PreviewMarkerEnd = sec
                Case "Current" : PreviewMarkerCurrent = sec
            End Select
            _panel.Invalidate()
            Return
        End If

        ' 2) LightSource slepen
        If draggingLSRowIdx >= 0 Then
            Dim dx = e.X - dragStartX
            Dim dSec = dx / _zoomScale
            Dim rowLS = _dgLightSources.Rows(draggingLSRowIdx)
            If dragMode = "Move" Then
                rowLS.Cells("colLSStartMoment").Value = Math.Max(0, origStartSec + dSec)
            Else
                rowLS.Cells("colLSDuration").Value = Math.Max(0.1F, origDurSec + dSec)
            End If
            _panel.Invalidate()
        End If
    End Sub
    ' Einde van drag-operatie
    Private Sub OnPanelMouseUp(sender As Object, e As MouseEventArgs)
        ' Als we net een Current-marker gesleept hebben,
        ' stuur dan meteen de preview
        If markerDragType = "Current" OrElse markerIsDragging Then
            SendPreviewFrame()
        End If

        ' Als we een marker aan het slepen waren, skip de volgende Click
        If markerDragType <> "" OrElse markerIsDragging Then
            skipNextClick = True
        End If


        ' reset alle drag-flags
        draggingLSRowIdx = -1
        dragMode = ""
        markerDragType = ""
        markerIsDragging = False
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
    ''' Tekent in het midden van een LightSource-balkje een icoon voor de shape.
    ''' </summary>
    Private Sub DrawShapeIcon(g As Graphics, shape As String, rect As Rectangle)
        ' bepaal halve grootte en centrum
        Dim size = Math.Min(rect.Width, rect.Height) \ 2
        Dim cx = rect.Left + rect.Width \ 2
        Dim cy = rect.Top + rect.Height \ 2
        Dim r = size \ 2

        Select Case shape
            Case "Circle"
                ' cirkel
                g.DrawEllipse(Pens.White, cx - r, cy - r, size, size)

            Case "Square"
                ' vierkant
                g.DrawRectangle(Pens.White, cx - r, cy - r, size, size)

            Case "Cone"
                ' gelijkzijdige driehoek, punt omhoog
                Dim pts = {
                New Point(cx, cy - r),
                New Point(cx - r, cy + r),
                New Point(cx + r, cy + r)
            }
                g.DrawPolygon(Pens.White, pts)

            Case Else
                ' fallback: vierkant
                g.DrawRectangle(Pens.White, cx - r, cy - r, size, size)
        End Select
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


    Public Sub SendPreviewFrame()
        ' 1) Bepaal welke effect-id actief is
        Dim meGrid = FrmMain.DG_MyEffects
        If meGrid.CurrentRow Is Nothing Then Return
        Dim effectId = CInt(meGrid.CurrentRow.Cells("colMEID").Value)

        ' 2) Bepaal het frame-index op basis van PreviewMarkerCurrent en fps
        Const fps As Integer = 5
        Dim frameIdx = CInt(Math.Floor(PreviewMarkerCurrent * fps))

        ' 3) Loop alle voor dit effect gegenereerde rijen in DG_MyEffectsFrames
        For Each row As DataGridViewRow In FrmMain.DG_MyEffectsFrames.Rows
            If row.IsNewRow Then Continue For
            If CInt(row.Cells("colMF_MEID").Value) <> effectId Then Continue For

            Dim fixture = CStr(row.Cells("colMF_FixtureID").Value)
            Dim frames = TryCast(row.Cells("colMF_Frames").Value, List(Of Byte()))
            If frames Is Nothing OrElse frameIdx < 0 OrElse frameIdx >= frames.Count Then Continue For

            ' 4) Haal het juiste frame-buffer
            Dim buf = frames(frameIdx)

            ' 5) Zoek in DG_Devices naar dezelfde fixture en stuur
            For Each devRow As DataGridViewRow In FrmMain.DG_Devices.Rows
                If devRow.IsNewRow Then Continue For
                If CStr(devRow.Cells("colInstance").Value) <> fixture Then Continue For

                ' Vul DDP-data in en stuur
                devRow.Cells("colDDPData").Value = buf
                devRow.Cells("colDataProvider").Value = "Effects"
                devRow.Cells("colDDPOffset").Value = 0

                Dim ip = CStr(devRow.Cells("colIPAddress").Value)
                DDP.SendDDP(ip, buf)
                Exit For
            Next
        Next
    End Sub

End Module
