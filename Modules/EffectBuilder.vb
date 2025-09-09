Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.Intrinsics.Arm
Imports System.Windows.Forms


Module EffectBuilder
    ' Preview-marker posities (in seconden)
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

    Private Class ShapeInstance
        Public Property HitLEDs As List(Of LedInfo)
        Public Property Color As Color
        Public Property Blend As Boolean
        Public Property Params As EffectParams
        Public Property EffectName As String

    End Class


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
        RemoveHandler _panel.MouseDoubleClick, AddressOf OnPanelDoubleClick   ' added

        ' Voeg de nieuwe handlers toe
        AddHandler _panel.Paint, AddressOf OnPanelPaint
        AddHandler _panel.MouseClick, AddressOf OnPanelClick
        AddHandler _panel.MouseDown, AddressOf OnPanelMouseDown
        AddHandler _panel.MouseMove, AddressOf OnPanelMouseMove
        AddHandler _panel.MouseUp, AddressOf OnPanelMouseUp
        AddHandler _panel.Scroll, AddressOf OnPanelScroll
        AddHandler _panel.MouseDoubleClick, AddressOf OnPanelDoubleClick

        panel.Cursor = Cursors.Default
        panel.Invalidate()
    End Sub


    ''' Wordt aangeroepen als je op een LightSource-blokje klikt
    Public Sub OnLightSourceClicked(trackId As Integer, lsRowIndex As Integer)
        On Error Resume Next

        Dim ValueString As String = ""

        ' 1) Select correct track in DG_Tracks
        For Each row As DataGridViewRow In _dgTracks.Rows
            If Not row.IsNewRow AndAlso CInt(row.Cells("colTrackId").Value) = trackId Then
                _dgTracks.ClearSelection()
                row.Selected = True
                Exit For
            End If
        Next

        ' 2) Select LS row
        _dgLightSources.ClearSelection()
        If lsRowIndex >= 0 AndAlso lsRowIndex < _dgLightSources.Rows.Count Then
            _dgLightSources.Rows(lsRowIndex).Selected = True
        End If

        ' 3) Stage marker
        Stage.SelectedLSIndex = lsRowIndex
        Stage.DrawSelectedMarker = True
        FrmMain.pb_Stage.Invalidate()

        ' 4) Open detail form
        Dim lsRow = _dgLightSources.Rows(lsRowIndex)
        Dim detailForm As New DetailLightSource()

        ' 5) Fill fields
        With detailForm
            .txtStartMoment.Text = lsRow.Cells("colLSStartMoment").Value.ToString()
            .txtDuration.Text = lsRow.Cells("colLSDuration").Value.ToString()
            .txtPositionX.Text = lsRow.Cells("colLSPositionX").Value.ToString()
            .txtPositionY.Text = lsRow.Cells("colLSPositionY").Value.ToString()
            .txtSize.Text = lsRow.Cells("colLSSize").Value.ToString()
            .cmbShape.SelectedItem = lsRow.Cells("colLSShape").Value
            .cmbDirection.SelectedItem = lsRow.Cells("colLSDirection").Value
            .chkBlend.Checked = CBool(lsRow.Cells("colLSBlend").Value)

            ValueString = lsRow.Cells("colLSEffectSpeed").Value
            If ValueString <> "" Then .tbEffectSpeed.Value = CInt(ValueString) Else .tbEffectSpeed.Value = 0

            ValueString = lsRow.Cells("colLSEffectIntensity").Value
            If ValueString <> "" Then .TBEffectIntensity.Value = CInt(ValueString) Else .TBEffectIntensity.Value = 0

            ValueString = lsRow.Cells("colLSEffectDispersion").Value
            If ValueString <> "" Then .TBEffectDispersion.Value = CInt(ValueString) Else .TBEffectDispersion.Value = 0

            Select Case lsRow.Cells("colLSEffectDirection").Value.ToString().ToUpper()
                Case "UPLEFT" : .EffectDirectionUpLeft.Checked = True
                Case "UP" : .EffectDirectionUp.Checked = True
                Case "UPRIGHT" : .EffectDirectionUpRight.Checked = True
                Case "RIGHT" : .EffectDirectionRight.Checked = True
                Case "DOWNRIGHT" : .EffectDirectionDownRight.Checked = True
                Case "DOWN" : .EffectDirectionDown.Checked = True
                Case "DOWNLEFT" : .EffectDirectionDownLeft.Checked = True
                Case "LEFT" : .EffectDirectionLeft.Checked = True
            End Select

            .btnC1.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor1").Value))
            .btnC2.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor2").Value))
            .btnC3.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor3").Value))
            .btnC4.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor4").Value))
            .btnC5.BackColor = Color.FromArgb(CInt(lsRow.Cells("colLSColor5").Value))

            .cmbEffect.SelectedItem = lsRow.Cells("colLSEffect").Value
            .tbBrightnessBaseline.Value = CInt(lsRow.Cells("colLSBrightnessBaseline").Value)
            .tbBrightnessEffect.Value = CInt(lsRow.Cells("colLSBrightnessEffect").Value)

            ' Populate groups TreeView from DG_Groups
            Groups.PopulateTreeView(.tvGroupsSelected, FrmMain.DG_Groups)

            ' b) Read stored selection (CSV in colLSGroups) and mark in TreeView
            Dim selGroupIds As New List(Of String)
            If (Not IsDBNull(lsRow.Cells("colLSGroups").Value) AndAlso Not IsNothing(lsRow.Cells("colLSGroups").Value)) Then
                selGroupIds = CStr(lsRow.Cells("colLSGroups").Value).
                    Split(","c).
                    Select(Function(s) s.Trim()).
                    Where(Function(s) s <> "").
                    ToList()
            End If

            .tvGroupsSelected.BeginUpdate()
            DetailLightSource.CheckAndMarkNodes(.tvGroupsSelected.Nodes, selGroupIds)
            .tvGroupsSelected.ExpandAll()
            .tvGroupsSelected.EndUpdate()
        End With

        If detailForm.ShowDialog() = DialogResult.OK Then
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

            ' Persist group selections
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

        ' 2) Deselecteer eventueel geselecteerde shape/lightSource
        FrmMain.DG_LightSources.ClearSelection()
        SelectedLSIndex = -1

        'Stage.TekenPodium(FrmMain.pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
        Dim e As PaintEventArgs = Nothing

        RefreshTimeline()

    End Sub



    Public Sub Compile_EffectDesigner()


        ' Controleer eerst of er een effect geselecteerd in de DG_MyEffects table, zo niet skippen met een melding
        If FrmMain.DG_Templates.CurrentRow Is Nothing Then
            Dim selectedName As String = FrmMain.cbSelectedEffect.Text
            If String.IsNullOrWhiteSpace(selectedName) Then Exit Sub

            ' Zoek de bijbehorende rij in DG_MyEffects en selecteer deze
            For Each MErow As DataGridViewRow In FrmMain.DG_Templates.Rows
                If MErow.IsNewRow Then Continue For
                If CStr(MErow.Cells("colTemplateName").Value) = selectedName Then
                    MErow.Selected = True
                    FrmMain.DG_Templates.CurrentCell = MErow.Cells("colTemplateName")
                    Exit For
                End If
            Next

            ' Als er nog steeds geen rij is geselecteerd, geef een melding
            If FrmMain.DG_Templates.CurrentRow Is Nothing Then
                ToonFlashBericht("Selecteer eerst een effect.", 2)
                Return
            End If
        End If

        ' Sla het effectid op
        Dim effectId = CInt(FrmMain.DG_Templates.CurrentRow.Cells("colTemplateId").Value)


        ' Verwijder oude frames van vorige compile op dit effect.
        For i As Integer = FrmMain.DG_Frames.Rows.Count - 1 To 0 Step -1
            If CInt(FrmMain.DG_Frames.Rows(i).Cells("colFrame_Id").Value) = effectId Then
                FrmMain.DG_Frames.Rows.RemoveAt(i)
            End If
        Next

        ' Bepaal maxEnd van de actieven LightSources, is nodig om het aantal frames te kunnen bepalen
        Dim maxEnd As Double = 0
        For Each lsRow As DataGridViewRow In FrmMain.DG_LightSources.Rows
            If lsRow.IsNewRow Then Continue For
            If lsRow.Cells("colLSTrackId").Value.ToString = "" Then Continue For

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

        ' Bepaal het aantal frames dat we gaan maken, gebaseerd op 200ms per frame zijn dit 5 frames per seconde (fps)
        Dim fps = 5
        Dim totalFrames = CInt(Math.Ceiling(maxEnd * fps))


        ' Bereken mm-offset door de UI margins (in px) om te rekenen naar mm
        Dim mmPerPx = Stage.DetermineScaleOfScreen(FrmMain.pb_Stage)
        Dim offsetXmm = Stage.MarginLeft * mmPerPx
        Dim offsetYmm = Stage.MarginTop * mmPerPx



        ' Bepaal het aantal devices dat door dit effect gebruikt moeten worden, dit zal resulteren in aantal records in de resultList, waarin per device 
        ' de frames worden opgeslagen. 
        Dim deviceCounts = New Dictionary(Of String, Integer)
        For Each led In LedLijst
            Dim current As Integer = If(deviceCounts.ContainsKey(led.DeviceNaam), deviceCounts(led.DeviceNaam), 0)
            deviceCounts(led.DeviceNaam) = Math.Max(current, led.IndexInDevice + 1)
        Next

        ' En maak een lijstje aan, waar we het resultaat in op gaan slaan
        Dim resultList = New Dictionary(Of String, List(Of Byte()))()
        For Each dev In deviceCounts.Keys
            resultList(dev) = New List(Of Byte())()
        Next







        ' We weten hoeveel frames we moeten maken, dus we kunnen nu de buffers aanmaken. Doorloop frame per frame
        For frameIndex = 0 To totalFrames - 1

            ' Bepaal de tijdspositie van dit frame in seconden
            Dim framePosition = frameIndex / fps


            ' Reserveer ruimte voor buffer per device, per LED hebben we 3 bytes nodig (RGB)
            Dim buffers = New Dictionary(Of String, Byte())
            For Each device In deviceCounts.Keys
                buffers(device) = New Byte(deviceCounts(device) * 3 - 1) {}
            Next

            ' Verzamel per shape welke leds geraakt worden
            Dim activeShapes As New List(Of (ShapeRow As DataGridViewRow, Effect As String, Color As Color, Params As EffectParams, Blend As Boolean, HitLEDs As List(Of Integer)))

            ' Doorloop alle shapes (lightsources) en bepaal of ze actief zijn op dit moment
            For Each shapeLightsource As DataGridViewRow In FrmMain.DG_LightSources.Rows

                ' Als deze rij niet actief is of leeg is, skippen
                If shapeLightsource.IsNewRow Then Continue For
                If shapeLightsource.Cells("colLSTrackId").Value.ToString = "" Then Continue For

                ' Bepaal trackID van deze shape
                Dim trackId = CInt(shapeLightsource.Cells("colLSTrackId").Value)

                ' Bepaal of track op  waarop deze shape staat op actief staat, zo niet overslaan.
                Dim trRow = FrmMain.DG_Tracks.Rows _
                        .Cast(Of DataGridViewRow)() _
                        .FirstOrDefault(Function(r) Not r.IsNewRow AndAlso CInt(r.Cells("colTrackId").Value) = trackId)
                If trRow Is Nothing OrElse Not CBool(trRow.Cells("colTrackActive").Value) Then Continue For


                ' Bepaal het start moment en de duur van deze shape, en of deze binnen de tijdsperiode van dit frame valt
                Dim startSec = CDbl(shapeLightsource.Cells("colLSStartMoment").Value)
                Dim durSec = CDbl(shapeLightsource.Cells("colLSDuration").Value)
                If framePosition < startSec OrElse framePosition > startSec + durSec Then Continue For


                ' *************************************************************************************************
                ' Vanaf dit punt is de shape bekend en actief, ook de track is actief en de tijdspositie is goed. 
                ' We kunnen nu de shape-parameters uitlezen en bepalen welke led's in de shape vallen. Daarna kunnen
                ' we de kleuren in de buffers zetten en een subgroep aanmaken.
                ' *************************************************************************************************

                ' Haal informatie van de shape op, zoals kleuren, richting, grootte en blenden van de kleuren, etc
                Dim c1 = Color.FromArgb(CInt(shapeLightsource.Cells("colLSColor1").Value))
                Dim c2 = Color.FromArgb(CInt(shapeLightsource.Cells("colLSColor2").Value))
                Dim c3 = Color.FromArgb(CInt(shapeLightsource.Cells("colLSColor3").Value))
                Dim c4 = Color.FromArgb(CInt(shapeLightsource.Cells("colLSColor4").Value))
                Dim c5 = Color.FromArgb(CInt(shapeLightsource.Cells("colLSColor5").Value))
                Dim blend = CBool(shapeLightsource.Cells("colLSBlend").Value)
                Dim direction = shapeLightsource.Cells("colLSDirection").Value.ToString()
                Dim shapeEffect = shapeLightsource.Cells("colLSEffect").Value.ToString().Split("-"c)(0).Trim()
                Dim shapePosXmm = CDbl(shapeLightsource.Cells("colLSPositionX").Value) * 10
                Dim shapePosYmm = CDbl(shapeLightsource.Cells("colLSPositionY").Value) * 10
                Dim shapeType = shapeLightsource.Cells("colLSShape").Value.ToString()
                Dim sizeMm = (CDbl(shapeLightsource.Cells("colLSSize").Value) * 10) / 2


                Dim strSpeed As String = shapeLightsource.Cells("colLSEffectSpeed").Value
                If strSpeed = "" Then strSpeed = "0"

                Dim strIntensity As String = shapeLightsource.Cells("colLSEffectIntensity").Value
                If strIntensity = "" Then strIntensity = "0"

                Dim strDispersion As String = shapeLightsource.Cells("colLSEffectDispersion").Value
                If strDispersion = "" Then strDispersion = "0"


                Dim parameters As New EffectParams With {
                    .EffectName = shapeEffect,
                    .FPS = fps,
                    .Duration = CInt(durSec * 1000),
                    .Brightness_Baseline = CInt(shapeLightsource.Cells("colLSBrightnessBaseline").Value),
                    .Brightness_Effect = CInt(shapeLightsource.Cells("colLSBrightnessEffect").Value),
                    .Speed = CInt(strSpeed),
                    .Intensity = CInt(strIntensity),
                    .Dispersion = CInt(strDispersion),
                    .Kleuren = {c1, c2, c3, c4, c5}
                }


                ' Haal ook even de CSV lijst van groepen van de shape op, en split deze in een lijst
                Dim shapeGroups = CStr(shapeLightsource.Cells("colLSGroups").Value) _
                            .Split(","c) _
                            .Where(Function(s) Not String.IsNullOrWhiteSpace(s)) _
                            .Select(Function(s) CInt(s.Trim())) _
                            .ToList()


                ' **********************************************************
                ' DEEL 1: Dooploop alle leds en kijk of deze in de shape vallen, voeg ze dan toe aan 
                ' een lijstje van hitLEDs
                ' **********************************************************
                Dim hitLeds As New List(Of Integer)
                For Each led In LedLijst
                    ' Check of LED in de juiste groep zit
                    Dim ledGroups = If(
                        String.IsNullOrEmpty(led.GroupId),
                        New List(Of Integer),
                        led.GroupId.Split(","c).Select(Function(s) CInt(s.Trim())).ToList()
                    )
                    If Not ledGroups.Any(Function(g) shapeGroups.Contains(g)) Then Continue For

                    ' Bepaal of de led in de shape valt
                    Dim dxMm = (led.Xmm - offsetXmm) - (shapePosXmm - offsetXmm)
                    Dim dyMm = (led.Ymm - offsetYmm) - (shapePosYmm - offsetYmm)
                    Dim inShape As Boolean = False

                    Select Case shapeType
                        Case "Circle"
                            inShape = (dxMm * dxMm + dyMm * dyMm) <= sizeMm * sizeMm
                        Case "Square"
                            inShape = (Math.Abs(dxMm) <= sizeMm AndAlso Math.Abs(dyMm) <= sizeMm)
                        Case "Cone"
                            Dim v = Stage.DirectionVector(direction, 1)
                            Dim len = Math.Sqrt(v.X * v.X + v.Y * v.Y)
                            If len > 0 Then
                                Dim ux = v.X / len, uy = -v.Y / len
                                Dim dist = Math.Sqrt(dxMm * dxMm + dyMm * dyMm)
                                If dist > 0 Then
                                    Dim proj = dxMm * ux + dyMm * uy
                                    Dim cosHalf = Math.Cos(Math.PI / 6)
                                    If proj > 0 AndAlso proj <= sizeMm AndAlso proj / dist >= cosHalf Then
                                        inShape = True
                                    End If
                                End If
                            End If
                    End Select

                    If inShape Then hitLeds.Add(led.IndexInDevice)
                Next

                If hitLeds.Count > 0 Then
                    activeShapes.Add((shapeLightsource, shapeEffect, c1, parameters, blend, hitLeds))
                End If
            Next



            ' *********************************************************************************
            ' DEEL 2: Geef de leds in de shapes nu de juiste kleur en effect
            ' *********************************************************************************
            ' Doorloop alle leds en bepaal kleur per frame
            For Each led In LedLijst
                Dim idx = led.IndexInDevice * 3
                Dim r As Byte = 0, g As Byte = 0, b As Byte = 0
                Dim hasColor As Boolean = False

                For Each shape In activeShapes
                    If Not shape.HitLEDs.Contains(led.IndexInDevice) Then Continue For

                    Dim rr As Byte = shape.Color.R
                    Dim gg As Byte = shape.Color.G
                    Dim bb As Byte = shape.Color.B


                    If shape.Effect = "Twinkle" Then
                        CustomEffects_Twinkle.CompileCustomEffect_Twinkle(
                            rr, gg, bb,
                            frameIndex,
                            led.IndexInDevice,
                            led.Xmm, led.Ymm,
                            shape.HitLEDs,
                            shape.Params,
                            0
                        )
                    End If

                    If shape.Blend And hasColor Then
                        Dim tot_r As Integer = CInt(r) + CInt(rr)
                        r = Math.Min(255, tot_r)

                        Dim tot_g As Integer = CInt(g) + CInt(gg)
                        g = Math.Min(255, tot_g)

                        Dim tot_b As Integer = CInt(b) + CInt(bb)
                        b = Math.Min(255, tot_b)
                    Else
                        r = rr : g = gg : b = bb
                    End If
                    hasColor = True
                Next

                If hasColor Then
                    Dim buf = buffers(led.DeviceNaam)
                    buf(idx) = r
                    buf(idx + 1) = g
                    buf(idx + 2) = b
                End If
            Next

            ' Sla buffers op
            For Each frame In resultList.Keys
                resultList(frame).Add(buffers(frame))
            Next
        Next

        ' Wegschrijven naar DG_MyEffectsFrames
        For Each thisResult In resultList
            Dim fixureId = thisResult.Key
            Dim framesList = thisResult.Value
            Dim rowIdx = FrmMain.DG_Frames.Rows.Add()
            With FrmMain.DG_Frames.Rows(rowIdx)
                .Cells("colFrame_Id").Value = effectId
                .Cells("colFrame_FixtureID").Value = fixureId
                .Cells("colFrame_Frames").Value = framesList
            End With
        Next

        ToonFlashBericht($"Compile klaar {totalFrames} frames per device aangemaakt.", 3)
    End Sub













    '' Doorloop alle LED, om te bepalen of deze led aangeraakt wordt door deze shape en in de groep zit
    'For Each individualLed In LedLijst


    '            ' Bepaal de groepen van de led, en kijk of deze in de shape-groepen zit, zo niet volgende led
    '            Dim individualLedGroups = If(
    '                String.IsNullOrEmpty(individualLed.GroupId),
    '                New List(Of Integer),
    '                    individualLed.GroupId.Split(","c).Select(Function(s) CInt(s.Trim())).ToList()
    '            )
    '            If Not individualLedGroups.Any(Function(g) shapeGroups.Contains(g)) Then Continue For


    '            ' Bepaal de positie de shape, grootte (en richting in geval van cone)
    '            Dim inShape As Boolean = False

    '            Dim dxMm = (individualLed.Xmm - offsetXmm) - (shapePosXmm - offsetXmm)
    '            Dim dyMm = (individualLed.Ymm - offsetYmm) - (shapePosYmm - offsetYmm)

    '            ' Bepaal of de led in de shape valt, afhankelijk van de shape
    '            Select Case CStr(shapeLightsource.Cells("colLSShape").Value)
    '                Case "Circle"
    '                    ' Cirkelvormige shape, X en Y zijn altijd het middelpunt, inshape als afstand <= radius van de cirkel
    '                    inShape = (dxMm * dxMm + dyMm * dyMm) <= sizeMm * sizeMm

    '                Case "Square"
    '                    ' Vierkante shape, X en Y zijn altijd het middelpunt, inshape als afstand <= grootte van het vierkant
    '                    inShape = (Math.Abs(dxMm) <= sizeMm AndAlso Math.Abs(dyMm) <= sizeMm)

    '                Case "Cone"
    '                    ' Een cone is wat moeilijker. We gaan uit dat x,y hoek is met scherpte punt en houden dan rekening met de richting 
    '                    Dim v = Stage.DirectionVector(direction, 1)

    '                    Dim len = Math.Sqrt(v.X * v.X + v.Y * v.Y)
    '                    If len > 0 Then
    '                        Dim ux = v.X / len, uy = -v.Y / len
    '                        Dim dist = Math.Sqrt(dxMm * dxMm + dyMm * dyMm)
    '                        If dist > 0 Then
    '                            Dim proj = dxMm * ux + dyMm * uy
    '                            Dim cosHalf = Math.Cos(Math.PI / 6)
    '                            If proj > 0 AndAlso proj <= sizeMm AndAlso proj / dist >= cosHalf Then
    '                                inShape = True
    '                            End If
    '                        End If
    '                    End If
    '            End Select
    '            ' Als de led niet in de shape valt, dan verder met de volgende led
    '            If Not inShape Then Continue For

    '            ' *************************************************************************************************
    '            ' Vanaf dit punt weten we dat deze led binnen de shape valt. We kunnen dus de kleuren in het buffer
    '            ' zetten.
    '            ' *************************************************************************************************

    '            Dim buf = buffers(individualLed.DeviceNaam)
    '            Dim idx = individualLed.IndexInDevice * 3

    '            Select Case shapeEffect
    '                Case "Twinkle"
    '                    ' Initieel RGB van kleur 1 (achtergrondkleur)
    '                    Dim r As Byte = c1.R
    '                    Dim g As Byte = c1.G
    '                    Dim b As Byte = c1.B

    '                    ' Bouw EffectParams op basis van shape-informatie
    '                    Dim parameters As New EffectParams With {
    '                        .EffectName = "Twinkle",
    '                        .FPS = fps,
    '                        .Duration = CInt(durSec * 1000),
    '                        .Brightness_Baseline = CInt(shapeLightsource.Cells("colLSBrightnessBaseline").Value),
    '                        .Brightness_Effect = CInt(shapeLightsource.Cells("colLSBrightnessEffect").Value),
    '                        .Speed = CInt(shapeLightsource.Cells("colLSEffectSpeed").Value),
    '                        .Intensity = CInt(shapeLightsource.Cells("colLSEffectIntensity").Value),
    '                        .Dispersion = CInt(shapeLightsource.Cells("colLSEffectDispersion").Value)
    '                    }


    '                    ' Vul lichtbron in (vereist dat je deze ergens als LightSource-object construeert)
    '                    Dim source As New LightSource With {
    '                        .HitLEDs = New List(Of Integer) From {individualLed.IndexInDevice}
    '                    }

    '                    ' Aanroep naar Twinkle compiler
    '                    CustomEffects_Twinkle.CompileCustomEffect_Twinkle(
    '                        r, g, b,
    '                        frameIndex,
    '                        individualLed.IndexInDevice,
    '                        individualLed.Xmm,
    '                        individualLed.Ymm,
    '                        source,
    '                        parameters,
    '                        0
    '                    )

    '                    ' Kleur in buffer zetten (rekening houden met blend)
    '                    If Blend Then
    '                        Dim sumR = CInt(buf(idx)) + r : If sumR > 255 Then sumR = 255
    '                        Dim sumG = CInt(buf(idx + 1)) + g : If sumG > 255 Then sumG = 255
    '                        Dim sumB = CInt(buf(idx + 2)) + b : If sumB > 255 Then sumB = 255
    '                        buf(idx) = CByte(sumR)
    '                        buf(idx + 1) = CByte(sumG)
    '                        buf(idx + 2) = CByte(sumB)
    '                    Else
    '                        buf(idx) = r
    '                        buf(idx + 1) = g
    '                        buf(idx + 2) = b
    '                    End If

    '                Case Else
    '                    ' ****************************************
    '                    ' SOLID KLEUR, GEEN EFFECT
    '                    ' ****************************************

    '                    ' Bepaal de kleur die we in de buffer moeten zetten, afhankelijk of we de kleuren moeten blenden of niet
    '                    If Blend Then
    '                        Dim sumR = CInt(buf(idx)) + c1.R : If sumR > 255 Then sumR = 255
    '                        Dim sumG = CInt(buf(idx + 1)) + c1.G : If sumG > 255 Then sumG = 255
    '                        Dim sumB = CInt(buf(idx + 2)) + c1.B : If sumB > 255 Then sumB = 255
    '                        buf(idx) = CByte(sumR)
    '                        buf(idx + 1) = CByte(sumG)
    '                        buf(idx + 2) = CByte(sumB)
    '                    Else
    '                        buf(idx) = CByte(c1.R)
    '                        buf(idx + 1) = CByte(c1.G)
    '                        buf(idx + 2) = CByte(c1.B)
    '                    End If
    '            End Select
    '        Next
    '    Next

    '    ' Sla buffers op
    '    For Each frame In resultList.Keys
    '        resultList(frame).Add(Buffers(frame))
    '    Next
    '    Next

    '    ' Wegschrijven naar DG_MyEffectsFrames
    '    For Each thisResult In resultList
    '        Dim fixureId = thisResult.Key
    '        Dim framesList = thisResult.Value
    '        Dim rowIdx = FrmMain.DG_MyEffectsFrames.Rows.Add()
    '        With FrmMain.DG_MyEffectsFrames.Rows(rowIdx)
    '            .Cells("colFrames_Id").Value = effectId
    '            .Cells("colFrame_FixtureID").Value = fixureId
    '            .Cells("colFrame_Frames").Value = framesList
    '        End With
    '    Next

    '    ToonFlashBericht($"Compile klaar {totalFrames} frames per device aangemaakt.", 3)
    'End Sub

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
    Public Sub DrawTimeLine(e As PaintEventArgs)
        On Error Resume Next

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.Clear(_panel.BackColor)
        If _dgTracks Is Nothing OrElse _dgLightSources Is Nothing Then Return

        Dim xOffset = _panel.AutoScrollPosition.X
        Dim yOffset = _panel.AutoScrollPosition.Y

        DrawTimelineAxis(g, xOffset, yOffset)
        DrawZoomButtons(g, xOffset, yOffset)

        Dim selectedTemplateId As Integer = -1
        If FrmMain.cbSelectedEffect.SelectedItem IsNot Nothing Then
            For Each row As DataGridViewRow In FrmMain.DG_Templates.Rows
                If Not row.IsNewRow AndAlso CStr(row.Cells("colTemplateName").Value) = FrmMain.cbSelectedEffect.SelectedItem.ToString() Then
                    selectedTemplateId = CInt(row.Cells("colTemplateId").Value)
                    Exit For
                End If
            Next
        End If

        Dim fontLarge = New Font(SystemFonts.DefaultFont.FontFamily, 12, FontStyle.Bold)
        Dim fontSmall = New Font(SystemFonts.DefaultFont.FontFamily, 8, FontStyle.Regular)

        For i = 0 To _dgTracks.Rows.Count - 1
            Dim rowT = _dgTracks.Rows(i)
            If rowT.IsNewRow Then Continue For

            Dim trackId = CInt(rowT.Cells("colTrackId").Value)
            Dim trackName = CStr(rowT.Cells("colTrackName").Value)

            ' Robust boolean parsing for Active
            Dim trackActive As Boolean
            Dim v = rowT.Cells("colTrackActive").Value
            If TypeOf v Is Boolean Then
                trackActive = CBool(v)
            Else
                trackActive = String.Equals(Convert.ToString(v), "True", StringComparison.OrdinalIgnoreCase)
            End If

            Dim isSelected = (_dgTracks.CurrentRow IsNot Nothing AndAlso _dgTracks.CurrentRow.Index = i)

            Dim yTop = yOffset + TimelineHeight + TrackMargin + i * (RowHeight + TrackMargin)
            Dim trackRect = New Rectangle(0, yTop, _panel.ClientSize.Width, RowHeight)
            Dim bgColor As Color = If(trackActive, Color.Black, If(isSelected, Color.Blue, Color.FromArgb(30, 30, 30)))

            Using bg As New SolidBrush(bgColor)
                g.FillRectangle(bg, trackRect)
            End Using

            HighlightSelectedTrackInPanel(g, _panel, _dgTracks)

            Dim textBrush = If(isSelected, Brushes.White, Brushes.Gray)
            g.DrawString(trackId.ToString(), fontLarge, textBrush, 4, yTop + 2)
            g.DrawString(trackName, fontSmall, textBrush, 4, yTop + 2 + fontLarge.Height)

            ' Controleer of er een shape op startSec=0 zit
            Dim hasStartZero As Boolean = False

            For j = 0 To _dgLightSources.Rows.Count - 1
                Dim rowLS = _dgLightSources.Rows(j)
                If rowLS.IsNewRow Then Continue For
                If CInt(rowLS.Cells("colLSTrackId").Value) <> trackId Then Continue For
                If selectedTemplateId >= 0 AndAlso CInt(rowLS.Cells("colLSTemplateId").Value) <> selectedTemplateId Then Continue For

                Dim startSec = CSng(rowLS.Cells("colLSStartMoment").Value)
                If Math.Abs(startSec) < 0.01 Then hasStartZero = True

                Dim durSec = CSng(rowLS.Cells("colLSDuration").Value)
                Dim xPx = xOffset + LeftMargin + CInt(startSec * _zoomScale)
                Dim wPx = Math.Max(HandleWidth, CInt(durSec * _zoomScale))
                Dim lsRect = New Rectangle(xPx, yTop + 4, wPx, RowHeight - 8)

                Dim isLSSelected As Boolean = _dgLightSources.Rows(j).Selected
                Dim borderPen As Pen = If(isLSSelected, Pens.Yellow, Pens.White)
                g.DrawRectangle(borderPen, lsRect)

                Using gripL As New SolidBrush(Color.Green)
                    g.FillRectangle(gripL, New Rectangle(lsRect.Left, lsRect.Top, HandleWidth, lsRect.Height))
                End Using
                Using gripR As New SolidBrush(Color.Red)
                    g.FillRectangle(gripR, New Rectangle(lsRect.Right - HandleWidth, lsRect.Top, HandleWidth, lsRect.Height))
                End Using

                Dim shape = CStr(rowLS.Cells("colLSShape").Value)
                DrawShapeIcon(g, shape, lsRect)
            Next

            ' Als geen shape op start=0 → teken rode marker
            If Not hasStartZero Then
                Dim markerX = xOffset + LeftMargin
                Dim markerY1 = yTop + 2
                Dim markerY2 = yTop + RowHeight - 4
                Using p As New Pen(Color.Red, 2)
                    g.DrawLine(p, markerX - 2, markerY1, markerX - 2, markerY2)
                End Using
            End If
        Next

        fontLarge.Dispose()
        fontSmall.Dispose()

        DrawPreviewMarkers(g, xOffset, yOffset)
    End Sub

    Private Sub OnPanelPaint(sender As Object, e As PaintEventArgs)
        DrawTimeLine(e)
    End Sub

    Public Sub HighlightSelectedTrackInPanel(g As Graphics, panel As Panel, dgTracks As DataGridView)
        If dgTracks.CurrentRow Is Nothing OrElse dgTracks.CurrentRow.IsNewRow Then Exit Sub

        Dim selectedTrackId = CInt(dgTracks.CurrentRow.Cells("colTrackID").Value)
        Dim rowIndex = dgTracks.CurrentRow.Index
        Dim yOffset = panel.AutoScrollPosition.Y
        Dim yTop = yOffset + TimelineHeight + TrackMargin + rowIndex * (RowHeight + TrackMargin)
        Dim trackRect = New Rectangle(0, yTop, 1, RowHeight - 1)

        Using bluePen As New Pen(Color.LightBlue, 2)
            g.DrawRectangle(bluePen, trackRect)
        End Using

    End Sub

    Public Sub SetCurrentRow_DGTracks(yPos As Integer, panel As Panel, dgTracks As DataGridView)
        Dim yOffset = panel.AutoScrollPosition.Y
        For i = 0 To dgTracks.Rows.Count - 1
            Dim row = dgTracks.Rows(i)
            If row.IsNewRow Then Continue For
            Dim yTop = yOffset + TimelineHeight + TrackMargin + i * (RowHeight + TrackMargin)
            Dim yBottom = yTop + RowHeight
            If yPos >= yTop AndAlso yPos <= yBottom Then
                dgTracks.CurrentCell = row.Cells("colTrackName")
                dgTracks.Refresh()
                Exit Sub
            End If
        Next
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
                'Dim xS = xOffset + LeftMargin + CInt(FrmMain.lblPreviewFromPosition.text * _zoomScale)
                'Dim xE = xOffset + LeftMargin + CInt(FrmMain.lblPreviewToPosition.text * _zoomScale)
                Dim xC = xOffset + LeftMargin + CInt(PreviewMarkerCurrent * _zoomScale)
                Const tol = 5

                'If Math.Abs(e.X - xS) < tol Then
                '    ' Start-marker slepen
                '    markerDragType = "Start"
                '    markerMouseOffset = e.X - xS
                'ElseIf Math.Abs(e.X - xE) < tol Then
                '    ' End-marker slepen
                '    markerDragType = "End"
                '    markerMouseOffset = e.X - xE
                'Else

                If Math.Abs(e.X - xC) < tol Then
                    ' Current-marker slepen
                    markerDragType = "Current"
                    markerMouseOffset = e.X - xC
                Else
                    ' nieuw plaatsen: eerst Start, daarna End, anders Current
                    'If FrmMain.lblPreviewFromPosition.text <= 0 Then
                    '    FrmMain.lblPreviewFromPosition.text = Math.Max(0, Math.Min(_maxSeconds, sec))
                    'ElseIf FrmMain.lblPreviewToPosition.text >= _maxSeconds Then
                    '    FrmMain.lblPreviewToPosition.text = Math.Max(0, Math.Min(_maxSeconds, sec))
                    'Else
                    PreviewMarkerCurrent = Math.Max(0, Math.Min(_maxSeconds, sec))
                    'End If

                    ' omdat we hier echt op de as klikken: meteen preview sturen
                    RefreshTimeline()
                    SendPreviewFrame()
                    Return
                End If

            ElseIf e.Button = MouseButtons.Right Then
                ' resetten van markers
                Dim xS = xOffset + LeftMargin + CInt(FrmMain.lblPreviewFromPosition.Text * _zoomScale)
                Dim xE = xOffset + LeftMargin + CInt(FrmMain.lblPreviewToPosition.Text * _zoomScale)
                Dim xC = xOffset + LeftMargin + CInt(PreviewMarkerCurrent * _zoomScale)
                Const tol = 5

                If Math.Abs(e.X - xS) < tol Then FrmMain.lblPreviewFromPosition.Text = 0
                If Math.Abs(e.X - xE) < tol Then FrmMain.lblPreviewToPosition.Text = _maxSeconds
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
        SetCurrentRow_DGTracks(e.Y, _panel, _dgTracks)

    End Sub


    Private Sub OnPanelDoubleClick(sender As Object, e As MouseEventArgs)
        Dim yOffset = _panel.AutoScrollPosition.Y
        Dim y = e.Y
        Dim x = e.X

        ' Zoek bijbehorende track bij Y-positie
        For i = 0 To _dgTracks.Rows.Count - 1
            Dim row = _dgTracks.Rows(i)
            If row.IsNewRow Then Continue For
            Dim yTop = yOffset + TimelineHeight + TrackMargin + i * (RowHeight + TrackMargin)
            Dim yBottom = yTop + RowHeight
            If y >= yTop AndAlso y <= yBottom Then
                ' Toggle actief-status
                Dim curr = If(IsDBNull(row.Cells("colTrackActive").Value), False, CBool(row.Cells("colTrackActive").Value))
                row.Cells("colTrackActive").Value = Not curr

                ' Forceer hertekenen
                _panel.Invalidate()
                Exit For
            End If
        Next

        Dim f As PaintEventArgs = Nothing
        DrawTimeLine(f)
        RefreshTimeline()

    End Sub



    ' Start van een drag/resize op een LightSource
    Private Sub OnPanelMouseDown(sender As Object, e As MouseEventArgs)
        Dim xOffset = _panel.AutoScrollPosition.X

        ' Reset slepen-flag
        markerIsDragging = False

        ' 1) Begin eventueel marker-drag
        If e.Button = MouseButtons.Left Then
            Dim mxStart = xOffset + LeftMargin + CInt(FrmMain.lblPreviewFromPosition.Text * _zoomScale)
            Dim mxEnd = xOffset + LeftMargin + CInt(FrmMain.lblPreviewToPosition.Text * _zoomScale)
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
                Case "Start" : FrmMain.lblPreviewFromPosition.Text = sec
                Case "End" : FrmMain.lblPreviewToPosition.Text = sec
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



    ' Bij scroll (vertical of horizontale) de timeline verversen
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
        g.DrawString("-10S",
                 SystemFonts.DefaultFont,
                 Brushes.White,
                 minusRect.Location)

        g.DrawRectangle(Pens.White, plusRect)
        g.DrawString("+10S",
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
        Dim xS = xOffset + LeftMargin + CInt(Convert.ToDouble(FrmMain.lblPreviewFromPosition.Text) * _zoomScale)
        Using pen As New Pen(Color.Lime, 2)
            g.DrawLine(pen, xS, axisY1, xS, axisY2)
        End Using

        ' END marker (rood)
        Dim xE = xOffset + LeftMargin + CInt(Convert.ToDouble(FrmMain.lblPreviewToPosition.Text) * _zoomScale)
        Using pen As New Pen(Color.Red, 2)
            g.DrawLine(pen, xE, axisY1, xE, axisY2)
        End Using

        ' CURRENT marker (lichtblauwe pijl, wat dikker)
        Dim xC = xOffset + LeftMargin + CInt(PreviewMarkerCurrent * _zoomScale)
        Using pen As New Pen(Color.LightSkyBlue, 3)
            Dim topY = axisY1 + 1
            Dim botY = axisY1 + 15
            g.DrawLine(pen, xC, botY, xC, topY)
            g.DrawLine(pen, xC, botY, xC - 6, botY - 6)
            g.DrawLine(pen, xC, botY, xC + 6, botY - 6)
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

        ' Alleen klikken in de linkse "header" zone (tot aan de tijdlijn-LeftMargin) openen Track-editor
        If isClick Then
            Dim headerRightX = xOffset + LeftMargin
            If x <= headerRightX Then
                RaiseEvent TrackClicked(trackId)
            End If
        End If
    End Sub
    Public Sub SetZoom(zoomSeconds As Integer)
        _zoomSeconds = zoomSeconds
        RecalcScale()
        RefreshTimeline()
    End Sub


    Public Sub SendPreviewFrame()
        ' 1) Bepaal welke effect-id actief is
        Dim meGrid = FrmMain.DG_Templates
        If meGrid.CurrentRow Is Nothing Then Return
        Dim effectId = CInt(meGrid.CurrentRow.Cells("colTemplateId").Value)

        ' 2) Bepaal het frame-index op basis van PreviewMarkerCurrent en fps
        Const fps As Integer = 5
        Dim frameIdx = CInt(Math.Floor(PreviewMarkerCurrent * fps))

        ' 3) Loop alle voor dit effect gegenereerde rijen in DG_MyEffectsFrames
        For Each row As DataGridViewRow In FrmMain.DG_Frames.Rows
            If row.IsNewRow Then Continue For
            If CInt(row.Cells("colFrame_Id").Value) <> effectId Then Continue For

            Dim fixture = CStr(row.Cells("colFrame_FixtureID").Value)
            Dim frames = TryCast(row.Cells("colFrame_Frames").Value, List(Of Byte()))
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

        ' Refresh Stage to visualize the buffer immediately
        Stage.TekenPodium(FrmMain.pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
    End Sub

    Public Sub VulEffectCombo()
        FrmMain.cbSelectedEffect.Items.Clear()
        For Each row As DataGridViewRow In FrmMain.DG_Templates.Rows
            If row.IsNewRow Then Continue For
            Dim effectName As String = CStr(row.Cells("colTemplateName").Value)
            FrmMain.cbSelectedEffect.Items.Add(effectName)
        Next

        If FrmMain.cbSelectedEffect.Items.Count > 0 Then
            FrmMain.cbSelectedEffect.SelectedIndex = 0
        End If
    End Sub

    Public Sub AddTrack()
        ' 1) Ophalen huidig effect-ID uit combobox
        Dim selectedEffect = FrmMain.cbSelectedEffect.Text
        Dim effectId As Integer = -1

        For Each row As DataGridViewRow In FrmMain.DG_Templates.Rows
            If Not row.IsNewRow AndAlso CStr(row.Cells("colTemplateName").Value) = selectedEffect Then
                effectId = CInt(row.Cells("colTemplateId").Value)
                Exit For
            End If
        Next

        If effectId < 0 Then
            MessageBox.Show("Selecteer eerst een geldig effect.", "Geen effect geselecteerd", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2) Vraag naam en bepaal nieuw ID
        Dim trackName = InputBox("Geef een naam voor de nieuwe track", "Nieuwe Track")
        If String.IsNullOrWhiteSpace(trackName) Then Exit Sub

        Dim nextId = 1
        For Each row As DataGridViewRow In FrmMain.DG_Tracks.Rows
            If Not row.IsNewRow Then
                Dim id = CInt(row.Cells("colTrackId").Value)
                If id >= nextId Then nextId = id + 1
            End If
        Next

        ' 3) Voeg toe met effect-ID
        FrmMain.DG_Tracks.Rows.Add(nextId, effectId, trackName)
        RefreshTimeline()
    End Sub


    Public Sub RemoveTrack()
        If FrmMain.DG_Tracks.CurrentRow Is Nothing OrElse FrmMain.DG_Tracks.CurrentRow.IsNewRow Then Exit Sub

        Dim trackId = CInt(FrmMain.DG_Tracks.CurrentRow.Cells("colTrackID").Value)
        Dim trackName = CStr(FrmMain.DG_Tracks.CurrentRow.Cells("colTrackName").Value)
        If MessageBox.Show($"Weet je zeker dat je track '{trackName}' wilt verwijderen?", "Bevestigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            ' Verwijder bijbehorende lichtbronnen
            For i = FrmMain.DG_LightSources.Rows.Count - 1 To 0 Step -1
                Dim row = FrmMain.DG_LightSources.Rows(i)
                If Not row.IsNewRow AndAlso CInt(row.Cells("colLSTrackID").Value) = trackId Then
                    FrmMain.DG_LightSources.Rows.RemoveAt(i)
                End If
            Next
            ' Verwijder track
            FrmMain.DG_Tracks.Rows.Remove(FrmMain.DG_Tracks.CurrentRow)
        End If
        RefreshTimeline()
    End Sub

    Public Sub AddShape()
        If FrmMain.DG_Tracks.CurrentRow Is Nothing OrElse FrmMain.DG_Tracks.CurrentRow.IsNewRow Then Exit Sub

        ' 1) Bepaal actief track ID
        Dim trackRow = FrmMain.DG_Tracks.CurrentRow
        Dim trackId = CInt(trackRow.Cells("colTrackID").Value)
        Dim trackEffectId = CInt(trackRow.Cells("colTrackMEId").Value)

        ' 2) Zoek huidig geselecteerde MyEffect ID uit combobox
        Dim myEffectId As Integer = -1
        Dim selectedEffect = FrmMain.cbSelectedEffect.Text
        For Each row As DataGridViewRow In FrmMain.DG_Templates.Rows
            If Not row.IsNewRow AndAlso CStr(row.Cells("colTemplateName").Value) = selectedEffect Then
                myEffectId = CInt(row.Cells("colTemplateId").Value)
                Exit For
            End If
        Next
        If myEffectId < 0 Then
            MessageBox.Show("Geen geldig effect geselecteerd.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 3) Check of track hoort bij huidig effect
        If trackEffectId <> myEffectId Then
            MessageBox.Show("De gekozen track hoort niet bij het geselecteerde effect.", "Verkeerde koppeling", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 4) Bepaal nieuw ID
        Dim nextId As Integer = 1
        For Each row As DataGridViewRow In FrmMain.DG_LightSources.Rows
            If Not row.IsNewRow Then
                Dim id = CInt(row.Cells("colLSID").Value)
                If id >= nextId Then nextId = id + 1
            End If
        Next

        ' 5) Startmoment ophalen vanuit previewmarker
        Dim startMoment As Single = PreviewMarkerCurrent ' zorg dat deze beschikbaar is

        ' 6) Voeg nieuwe rij toe
        Dim newRow = FrmMain.DG_LightSources.Rows(FrmMain.DG_LightSources.Rows.Add())
        newRow.Cells("colLSID").Value = nextId
        newRow.Cells("colLSTrackID").Value = trackId
        newRow.Cells("colLSMyEffectId").Value = myEffectId

        SelectedLSIndex = newRow.Index

        ' 7) Toon dialoog met voorgestelde waarden
        Dim detailForm As New DetailLightSource()
        With detailForm
            .txtStartMoment.Text = startMoment.ToString("0.00")
            .txtDuration.Text = "5"
            .txtPositionX.Text = "0"
            .txtPositionY.Text = "0"
            .txtSize.Text = "100"
            .cmbShape.SelectedItem = "Circle"
            .cmbDirection.SelectedItem = "Up"
            .chkBlend.Checked = False

            .btnC1.BackColor = Color.Blue
            .btnC2.BackColor = Color.Red
            .btnC3.BackColor = Color.Green
            .btnC4.BackColor = Color.Purple
            .btnC5.BackColor = Color.Yellow

            .cmbEffect.SelectedItem = ""
            .tbBrightnessBaseline.Value = .tbBrightnessBaseline.Maximum
            .tbBrightnessEffect.Value = .tbBrightnessEffect.Maximum

            .tvGroupsSelected.Nodes.Clear()
            .tvGroupsSelected.ExpandAll()
        End With

        If detailForm.ShowDialog() = DialogResult.OK Then
            newRow.Cells("colLSStartMoment").Value = CSng(detailForm.txtStartMoment.Text)
            newRow.Cells("colLSDuration").Value = CSng(detailForm.txtDuration.Text)
            newRow.Cells("colLSPositionX").Value = CSng(detailForm.txtPositionX.Text)
            newRow.Cells("colLSPositionY").Value = CSng(detailForm.txtPositionY.Text)
            newRow.Cells("colLSSize").Value = CSng(detailForm.txtSize.Text)
            If (IsNothing(detailForm.cmbShape.SelectedItem)) Then
                newRow.Cells("colLSShape").Value = "Circle"
            Else
                newRow.Cells("colLSShape").Value = detailForm.cmbShape.SelectedItem.ToString()
            End If
            newRow.Cells("colLSDirection").Value = detailForm.cmbDirection.SelectedItem.ToString()
            newRow.Cells("colLSColor1").Tag = detailForm.btnC1.BackColor
            newRow.Cells("colLSColor2").Tag = detailForm.btnC2.BackColor
            newRow.Cells("colLSColor3").Tag = detailForm.btnC3.BackColor
            newRow.Cells("colLSColor4").Tag = detailForm.btnC4.BackColor
            newRow.Cells("colLSColor5").Tag = detailForm.btnC5.BackColor
            newRow.Cells("colLSBlend").Value = detailForm.chkBlend.Checked
            newRow.Cells("colLSBrightnessBaseline").Value = detailForm.tbBrightnessBaseline.Value
            newRow.Cells("colLSBrightnessEffect").Value = detailForm.tbBrightnessEffect.Value
        Else
            FrmMain.DG_LightSources.Rows.Remove(newRow)
        End If
        RefreshTimeline()
    End Sub

    Public Sub RemoveShape()
        If FrmMain.DG_LightSources.CurrentRow Is Nothing OrElse FrmMain.DG_LightSources.CurrentRow.IsNewRow Then Exit Sub
        FrmMain.DG_LightSources.Rows.Remove(FrmMain.DG_LightSources.CurrentRow)
        RefreshTimeline()
    End Sub

    Public Sub AddTemplate()
        Dim TemplateName = InputBox("Geef een naam voor het nieuwe template:", "Nieuw Template")
        If String.IsNullOrWhiteSpace(TemplateName) Then Exit Sub
        Dim effectDesc = InputBox("Geef een beschrijving voor het effect:", "Beschrijving")

        Dim nextId = 1
        For Each row As DataGridViewRow In FrmMain.DG_Templates.Rows
            If Not row.IsNewRow Then
                Dim id = CInt(row.Cells("colTemplateId").Value)
                If id >= nextId Then nextId = id + 1
            End If
        Next

        FrmMain.DG_Templates.Rows.Add(nextId, TemplateName, effectDesc)
        VulEffectCombo()
        TekenPodium(FrmMain.pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
        RefreshTimeline()
    End Sub

    Public Sub RemoveTemplate()
        Dim selectedName As String = FrmMain.cbSelectedEffect.Text
        If String.IsNullOrWhiteSpace(selectedName) Then Exit Sub

        For Each row As DataGridViewRow In FrmMain.DG_Templates.Rows
            If Not row.IsNewRow AndAlso CStr(row.Cells("colTemplateName").Value) = selectedName Then
                If MessageBox.Show($"Template '{selectedName}' verwijderen?", "Bevestigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    FrmMain.DG_Templates.Rows.Remove(row)
                    Exit For
                End If
            End If
        Next
        VulEffectCombo()
        TekenPodium(FrmMain.pb_Stage, My.Settings.PodiumBreedte, My.Settings.PodiumHoogte)
        RefreshTimeline()
    End Sub


    Public Function GetTimelineXPosition(seconds As Double) As Integer
        Dim panel = FrmMain.PanelTracks
        Dim totalWidth = panel.ClientSize.Width
        Dim scrollOffsetX = panel.AutoScrollPosition.X

        ' Bereken schaal (pixels per seconde)
        Dim pxPerSec As Double = totalWidth / _maxSeconds

        ' Bereken positie inclusief scroll
        Return CInt(seconds * pxPerSec + scrollOffsetX)
    End Function

End Module
