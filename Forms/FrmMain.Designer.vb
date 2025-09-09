﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DG_Devices = New DataGridView()
        colIPAddress = New DataGridViewTextBoxColumn()
        colInstance = New DataGridViewTextBoxColumn()
        colLayout = New DataGridViewTextBoxColumn()
        colLedCount = New DataGridViewTextBoxColumn()
        colSegments = New DataGridViewTextBoxColumn()
        colEffects = New DataGridViewTextBoxColumn()
        colPalettes = New DataGridViewTextBoxColumn()
        colEnabled = New DataGridViewCheckBoxColumn()
        colOnline = New DataGridViewImageColumn()
        colDDPData = New DataGridViewTextBoxColumn()
        colDDPOffset = New DataGridViewTextBoxColumn()
        colSegmentsData = New DataGridViewTextBoxColumn()
        colDataProvider = New DataGridViewComboBoxColumn()
        DG_Effecten = New DataGridView()
        TabControl = New TabControl()
        TabShow = New TabPage()
        SplitContainer2 = New SplitContainer()
        DG_Show = New DataGridView()
        pbPDFViewer = New PictureBox()
        gb_Controls = New GroupBox()
        btnControl_NextAct = New Button()
        btnStopLoopingAtEndOfVideo = New Button()
        btn_ReconnectSecondairyBeamer = New Button()
        btn_ReconnectPrimaryBeamer = New Button()
        btnControl_StopAll = New Button()
        lblControl_TimeLeft = New Label()
        btnControl_NextScene = New Button()
        btnControl_NextEvent = New Button()
        btnControl_Start = New Button()
        gb_DetailWLed = New GroupBox()
        Label13 = New Label()
        Label12 = New Label()
        detailWLed_Effect = New PictureBox()
        detailWLed__EffectName = New Label()
        GroupBox11 = New GroupBox()
        detailWLed_Color3 = New PictureBox()
        GroupBox10 = New GroupBox()
        detailWLed_Color2 = New PictureBox()
        GroupBox9 = New GroupBox()
        detailWLed_Color1 = New PictureBox()
        Label9 = New Label()
        detailWLed_Speed = New TrackBar()
        Label8 = New Label()
        detailWLed_Intensity = New TrackBar()
        Label7 = New Label()
        detailWLed_Brightness = New TrackBar()
        detailWLed_Palette = New PictureBox()
        gbSecondairyBeamer = New GroupBox()
        warning_SecondairyBeamerOffline = New Label()
        WMP_SecondairyPlayer_Preview = New AxWMPLib.AxWindowsMediaPlayer()
        gbPrimaryBeamer = New GroupBox()
        warning_PrimaryBeamerOffline = New Label()
        WMP_PrimaryPlayer_Preview = New AxWMPLib.AxWindowsMediaPlayer()
        ToolStip_Show = New ToolStrip()
        lblFilter = New ToolStripLabel()
        filterAct = New ToolStripComboBox()
        btn_DGGrid_RemoveCurrentRow = New ToolStripButton()
        btn_DGGrid_AddNewRowAfter = New ToolStripButton()
        btn_DGGrid_AddNewRowBefore = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        btnLockUnlocked = New ToolStripButton()
        ToolStripLabel7 = New ToolStripLabel()
        lblPDFPage = New ToolStripLabel()
        TabStage = New TabPage()
        SplitContainerStage = New SplitContainer()
        SplitContainer1 = New SplitContainer()
        PanelTracks = New Panel()
        btnApplyCustomEffect = New Button()
        btnResetEffect = New Button()
        btnStopEffectPreview = New Button()
        btnStartEffectPreview = New Button()
        pb_Stage = New PictureBox()
        ToolStripSegments = New ToolStrip()
        btnResetFrames = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        BtnZoomPulldown = New ToolStripDropDownButton()
        btnZoom10 = New ToolStripMenuItem()
        btnZoom30 = New ToolStripMenuItem()
        btnZoom60 = New ToolStripMenuItem()
        btnZoom90 = New ToolStripMenuItem()
        ToolStripSeparator6 = New ToolStripSeparator()
        ToolStripLabel3 = New ToolStripLabel()
        cbSelectedEffect = New ToolStripComboBox()
        btnEditTemplate = New ToolStripButton()
        btnEffectAdd = New ToolStripButton()
        btnEffectDelete = New ToolStripButton()
        ToolStripSeparator7 = New ToolStripSeparator()
        ToolStripLabel2 = New ToolStripLabel()
        BtnAddTrack = New ToolStripButton()
        BtnRemoveTrack = New ToolStripButton()
        ToolStripSeparator8 = New ToolStripSeparator()
        ToolStripLabel4 = New ToolStripLabel()
        btnAddShape = New ToolStripButton()
        btnRemoveShape = New ToolStripButton()
        ToolStripSeparator9 = New ToolStripSeparator()
        ToolStripLabel5 = New ToolStripLabel()
        lblPreviewFromPosition = New ToolStripTextBox()
        ToolStripLabel6 = New ToolStripLabel()
        lblPreviewToPosition = New ToolStripTextBox()
        btnRepeat = New ToolStripButton()
        btnPreviewPlayPause = New ToolStripButton()
        pbPreview = New ToolStripProgressBar()
        TabTables = New TabPage()
        ToolStripTables = New ToolStrip()
        btnTablesAddRowBefore = New ToolStripButton()
        btnTablesAddRowAfter = New ToolStripButton()
        btnTablesDeleteSingleRow = New ToolStripButton()
        ToolStripSeparator3 = New ToolStripSeparator()
        btnDeleteAllTables = New ToolStripButton()
        ToolStripSeparator5 = New ToolStripSeparator()
        TabControlTables = New TabControl()
        TabTemplates = New TabPage()
        DG_Templates = New DataGridView()
        colTemplateID = New DataGridViewTextBoxColumn()
        colTemplateName = New DataGridViewTextBoxColumn()
        colTemplateDescription = New DataGridViewTextBoxColumn()
        colTemplateDuration = New DataGridViewTextBoxColumn()
        colTemplateRepeat = New DataGridViewCheckBoxColumn()
        colTemplateDDPData = New DataGridViewTextBoxColumn()
        TabTracks = New TabPage()
        DG_Tracks = New DataGridView()
        colTrackId = New DataGridViewTextBoxColumn()
        colTrackTemplateId = New DataGridViewTextBoxColumn()
        colTrackName = New DataGridViewTextBoxColumn()
        colTrackActive = New DataGridViewCheckBoxColumn()
        TabLightSources = New TabPage()
        DG_LightSources = New DataGridView()
        colLSId = New DataGridViewTextBoxColumn()
        colLSTrackId = New DataGridViewTextBoxColumn()
        colLSTemplateId = New DataGridViewTextBoxColumn()
        colLSStartMoment = New DataGridViewTextBoxColumn()
        colLSDuration = New DataGridViewTextBoxColumn()
        colLSPositionX = New DataGridViewTextBoxColumn()
        colLSPositionY = New DataGridViewTextBoxColumn()
        colLSSize = New DataGridViewTextBoxColumn()
        colLSShape = New DataGridViewTextBoxColumn()
        colLSBlend = New DataGridViewTextBoxColumn()
        colLSDirection = New DataGridViewTextBoxColumn()
        colLSColor1 = New DataGridViewTextBoxColumn()
        colLSColor2 = New DataGridViewTextBoxColumn()
        colLSColor3 = New DataGridViewTextBoxColumn()
        colLSColor4 = New DataGridViewTextBoxColumn()
        colLSColor5 = New DataGridViewTextBoxColumn()
        colLSBrightnessBaseline = New DataGridViewTextBoxColumn()
        colLSBrightnessEffect = New DataGridViewTextBoxColumn()
        colLSEffect = New DataGridViewTextBoxColumn()
        colLSGroups = New DataGridViewTextBoxColumn()
        colLSEffectSpeed = New DataGridViewTextBoxColumn()
        colLSEffectIntensity = New DataGridViewTextBoxColumn()
        colLSEffectDispersion = New DataGridViewTextBoxColumn()
        colLSEffectStartPosition = New DataGridViewComboBoxColumn()
        colLSEffectDirection = New DataGridViewComboBoxColumn()
        TabFrames = New TabPage()
        DG_Frames = New DataGridView()
        colFrame_Id = New DataGridViewTextBoxColumn()
        colFrame_FixtureID = New DataGridViewTextBoxColumn()
        colFrame_Frames = New DataGridViewTextBoxColumn()
        TabDevices = New TabPage()
        SplitContainer_Devices = New SplitContainer()
        RichTextBox1 = New RichTextBox()
        ToolStrip_Devices = New ToolStrip()
        LblDeviceStatus = New ToolStripLabel()
        btnScanNetworkForWLed = New ToolStripButton()
        btnDevicesRefreshIPs = New ToolStripButton()
        btnSendUpdatedSegmentsToWLED = New ToolStripButton()
        btnPingDevice = New ToolStripButton()
        btnDeleteDevice = New ToolStripButton()
        btnAddDevice = New ToolStripButton()
        ToolStripSeparator4 = New ToolStripSeparator()
        btnGenerateStage = New ToolStripButton()
        btnGenerateSliders = New ToolStripButton()
        TabGroups = New TabPage()
        RichTextBox4 = New RichTextBox()
        ToolStripGroups = New ToolStrip()
        btnGroupDeleteRow = New ToolStripButton()
        btnGroupAddRowBefore = New ToolStripButton()
        btnGroupAddRowAfter = New ToolStripButton()
        btnGroupsAutoSplit = New ToolStripButton()
        btnGroupDMXSlider = New ToolStripButton()
        DG_Groups = New DataGridView()
        colGroupId = New DataGridViewTextBoxColumn()
        colGroupParentId = New DataGridViewTextBoxColumn()
        colGroupName = New DataGridViewTextBoxColumn()
        colGroupFixture = New DataGridViewComboBoxColumn()
        colGroupSegment = New DataGridViewTextBoxColumn()
        colGroupStartLedNr = New DataGridViewTextBoxColumn()
        colGroupStopLedNr = New DataGridViewTextBoxColumn()
        colGroupOrder = New DataGridViewTextBoxColumn()
        colAllFrames = New DataGridViewTextBoxColumn()
        colActiveFrame = New DataGridViewTextBoxColumn()
        colGroupRepeat = New DataGridViewCheckBoxColumn()
        colGroupLayout = New DataGridViewTextBoxColumn()
        TabEffects = New TabPage()
        ToolStrip_Effecten = New ToolStrip()
        btnRebuildDGEffects = New ToolStripButton()
        btnTestExistanceEffects = New ToolStripButton()
        RichTextBox2 = New RichTextBox()
        TabPaletten = New TabPage()
        RichTextBox3 = New RichTextBox()
        ToolStrip_Paletten = New ToolStrip()
        btnRebuildDGPalettes = New ToolStripButton()
        ToolStripButton1 = New ToolStripButton()
        DG_Paletten = New DataGridView()
        TabSettings = New TabPage()
        GroupBox8 = New GroupBox()
        btn_ScriptPDF = New Button()
        settings_ScriptPDF = New TextBox()
        Label4 = New Label()
        Label14 = New Label()
        settings_DDPPort = New TextBox()
        settings_EffectsPath = New TextBox()
        Label11 = New Label()
        settings_PalettesPath = New TextBox()
        Label10 = New Label()
        settings_ProjectName = New TextBox()
        Label6 = New Label()
        btnProjectFolder = New Button()
        settings_ProjectFolder = New TextBox()
        Label5 = New Label()
        GroupBox4 = New GroupBox()
        txt_APIResult = New TextBox()
        GroupBox2 = New GroupBox()
        pbSecondaryStatus = New PictureBox()
        Label1 = New Label()
        pbPrimaryStatus = New PictureBox()
        cbMonitorSecond = New ComboBox()
        pbControlStatus = New PictureBox()
        cbMonitorPrime = New ComboBox()
        cbMonitorControl = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        lblShowMonitor = New Label()
        GroupBox1 = New GroupBox()
        txtIPRange = New TextBox()
        lblIPRange = New Label()
        ToolStrip_Form = New ToolStrip()
        btnSaveShow = New ToolStripButton()
        ToolStripLabel1 = New ToolStripLabel()
        btnLoadAll = New ToolStripButton()
        TimerEverySecond = New Timer(components)
        PictureBox1 = New PictureBox()
        OpenFileDialog1 = New OpenFileDialog()
        lblTitleProject = New Label()
        lblCurrentTime = New Label()
        TimerNextEvent = New Timer(components)
        TimerPingDevices = New Timer(components)
        ddpTimer = New Timer(components)
        stageTimer = New Timer(components)
        Timer_LoadBuffer = New Timer(components)
        btnApply = New DataGridViewButtonColumn()
        colAct = New DataGridViewComboBoxColumn()
        colSceneId = New DataGridViewTextBoxColumn()
        colEventId = New DataGridViewTextBoxColumn()
        colTimer = New DataGridViewTextBoxColumn()
        colCue = New DataGridViewTextBoxColumn()
        colFixture = New DataGridViewComboBoxColumn()
        colStateOnOff = New DataGridViewComboBoxColumn()
        colEffectId = New DataGridViewTextBoxColumn()
        colEffect = New DataGridViewComboBoxColumn()
        colPaletteId = New DataGridViewTextBoxColumn()
        colPalette = New DataGridViewComboBoxColumn()
        colColor1 = New DataGridViewTextBoxColumn()
        colColor2 = New DataGridViewTextBoxColumn()
        colColor3 = New DataGridViewTextBoxColumn()
        colBrightness = New DataGridViewTextBoxColumn()
        colSpeed = New DataGridViewTextBoxColumn()
        colIntensity = New DataGridViewTextBoxColumn()
        colTransition = New DataGridViewTextBoxColumn()
        colBlend = New DataGridViewCheckBoxColumn()
        colRepeat = New DataGridViewCheckBoxColumn()
        colSound = New DataGridViewCheckBoxColumn()
        colFilename = New DataGridViewTextBoxColumn()
        colSend = New DataGridViewCheckBoxColumn()
        ScriptPg = New DataGridViewTextBoxColumn()
        CType(DG_Devices, ComponentModel.ISupportInitialize).BeginInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).BeginInit()
        TabControl.SuspendLayout()
        TabShow.SuspendLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        CType(DG_Show, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbPDFViewer, ComponentModel.ISupportInitialize).BeginInit()
        gb_Controls.SuspendLayout()
        gb_DetailWLed.SuspendLayout()
        CType(detailWLed_Effect, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox11.SuspendLayout()
        CType(detailWLed_Color3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox10.SuspendLayout()
        CType(detailWLed_Color2, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox9.SuspendLayout()
        CType(detailWLed_Color1, ComponentModel.ISupportInitialize).BeginInit()
        CType(detailWLed_Speed, ComponentModel.ISupportInitialize).BeginInit()
        CType(detailWLed_Intensity, ComponentModel.ISupportInitialize).BeginInit()
        CType(detailWLed_Brightness, ComponentModel.ISupportInitialize).BeginInit()
        CType(detailWLed_Palette, ComponentModel.ISupportInitialize).BeginInit()
        gbSecondairyBeamer.SuspendLayout()
        CType(WMP_SecondairyPlayer_Preview, ComponentModel.ISupportInitialize).BeginInit()
        gbPrimaryBeamer.SuspendLayout()
        CType(WMP_PrimaryPlayer_Preview, ComponentModel.ISupportInitialize).BeginInit()
        ToolStip_Show.SuspendLayout()
        TabStage.SuspendLayout()
        CType(SplitContainerStage, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainerStage.Panel1.SuspendLayout()
        SplitContainerStage.Panel2.SuspendLayout()
        SplitContainerStage.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(pb_Stage, ComponentModel.ISupportInitialize).BeginInit()
        ToolStripSegments.SuspendLayout()
        TabTables.SuspendLayout()
        ToolStripTables.SuspendLayout()
        TabControlTables.SuspendLayout()
        TabTemplates.SuspendLayout()
        CType(DG_Templates, ComponentModel.ISupportInitialize).BeginInit()
        TabTracks.SuspendLayout()
        CType(DG_Tracks, ComponentModel.ISupportInitialize).BeginInit()
        TabLightSources.SuspendLayout()
        CType(DG_LightSources, ComponentModel.ISupportInitialize).BeginInit()
        TabFrames.SuspendLayout()
        CType(DG_Frames, ComponentModel.ISupportInitialize).BeginInit()
        TabDevices.SuspendLayout()
        CType(SplitContainer_Devices, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer_Devices.Panel1.SuspendLayout()
        SplitContainer_Devices.SuspendLayout()
        ToolStrip_Devices.SuspendLayout()
        TabGroups.SuspendLayout()
        ToolStripGroups.SuspendLayout()
        CType(DG_Groups, ComponentModel.ISupportInitialize).BeginInit()
        TabEffects.SuspendLayout()
        ToolStrip_Effecten.SuspendLayout()
        TabPaletten.SuspendLayout()
        ToolStrip_Paletten.SuspendLayout()
        CType(DG_Paletten, ComponentModel.ISupportInitialize).BeginInit()
        TabSettings.SuspendLayout()
        GroupBox8.SuspendLayout()
        GroupBox4.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(pbSecondaryStatus, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbPrimaryStatus, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbControlStatus, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        ToolStrip_Form.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DG_Devices
        ' 
        DG_Devices.BackgroundColor = Color.DimGray
        DG_Devices.Columns.AddRange(New DataGridViewColumn() {colIPAddress, colInstance, colLayout, colLedCount, colSegments, colEffects, colPalettes, colEnabled, colOnline, colDDPData, colDDPOffset, colSegmentsData, colDataProvider})
        DG_Devices.Dock = DockStyle.Fill
        DG_Devices.Location = New Point(0, 0)
        DG_Devices.MultiSelect = False
        DG_Devices.Name = "DG_Devices"
        DG_Devices.RowHeadersWidth = 10
        DG_Devices.Size = New Size(1827, 393)
        DG_Devices.TabIndex = 1
        ' 
        ' colIPAddress
        ' 
        colIPAddress.HeaderText = "IP"
        colIPAddress.Name = "colIPAddress"
        colIPAddress.Width = 200
        ' 
        ' colInstance
        ' 
        colInstance.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colInstance.HeaderText = "WLed Instantie"
        colInstance.Name = "colInstance"
        ' 
        ' colLayout
        ' 
        colLayout.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colLayout.HeaderText = "Layout"
        colLayout.Name = "colLayout"
        colLayout.Resizable = DataGridViewTriState.True
        colLayout.SortMode = DataGridViewColumnSortMode.NotSortable
        ' 
        ' colLedCount
        ' 
        colLedCount.HeaderText = "#Leds"
        colLedCount.Name = "colLedCount"
        colLedCount.Width = 63
        ' 
        ' colSegments
        ' 
        colSegments.HeaderText = "Segments"
        colSegments.Name = "colSegments"
        ' 
        ' colEffects
        ' 
        colEffects.HeaderText = "Effects"
        colEffects.MaxInputLength = 65535
        colEffects.Name = "colEffects"
        ' 
        ' colPalettes
        ' 
        colPalettes.HeaderText = "Palettes"
        colPalettes.MaxInputLength = 65535
        colPalettes.Name = "colPalettes"
        ' 
        ' colEnabled
        ' 
        colEnabled.HeaderText = "Enabled"
        colEnabled.Name = "colEnabled"
        colEnabled.Width = 55
        ' 
        ' colOnline
        ' 
        colOnline.HeaderText = "Online"
        colOnline.Name = "colOnline"
        colOnline.Width = 48
        ' 
        ' colDDPData
        ' 
        colDDPData.HeaderText = "Data"
        colDDPData.Name = "colDDPData"
        ' 
        ' colDDPOffset
        ' 
        colDDPOffset.HeaderText = "Offset"
        colDDPOffset.Name = "colDDPOffset"
        ' 
        ' colSegmentsData
        ' 
        colSegmentsData.HeaderText = "SegmentData"
        colSegmentsData.Name = "colSegmentsData"
        ' 
        ' colDataProvider
        ' 
        colDataProvider.HeaderText = "Source"
        colDataProvider.Items.AddRange(New Object() {"DMX", "Effects", "Show"})
        colDataProvider.MaxDropDownItems = 3
        colDataProvider.Name = "colDataProvider"
        colDataProvider.Resizable = DataGridViewTriState.True
        colDataProvider.SortMode = DataGridViewColumnSortMode.Automatic
        ' 
        ' DG_Effecten
        ' 
        DG_Effecten.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DG_Effecten.BackgroundColor = Color.DimGray
        DG_Effecten.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Effecten.Location = New Point(3, 71)
        DG_Effecten.Name = "DG_Effecten"
        DG_Effecten.RowHeadersWidth = 10
        DG_Effecten.Size = New Size(1830, 775)
        DG_Effecten.TabIndex = 2
        ' 
        ' TabControl
        ' 
        TabControl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl.Controls.Add(TabShow)
        TabControl.Controls.Add(TabStage)
        TabControl.Controls.Add(TabTables)
        TabControl.Controls.Add(TabDevices)
        TabControl.Controls.Add(TabGroups)
        TabControl.Controls.Add(TabEffects)
        TabControl.Controls.Add(TabPaletten)
        TabControl.Controls.Add(TabSettings)
        TabControl.Location = New Point(0, 77)
        TabControl.Name = "TabControl"
        TabControl.SelectedIndex = 0
        TabControl.Size = New Size(1844, 877)
        TabControl.TabIndex = 3
        ' 
        ' TabShow
        ' 
        TabShow.BackColor = Color.DimGray
        TabShow.Controls.Add(SplitContainer2)
        TabShow.Controls.Add(gb_Controls)
        TabShow.Controls.Add(gb_DetailWLed)
        TabShow.Controls.Add(gbSecondairyBeamer)
        TabShow.Controls.Add(gbPrimaryBeamer)
        TabShow.Controls.Add(ToolStip_Show)
        TabShow.Location = New Point(4, 24)
        TabShow.Name = "TabShow"
        TabShow.Size = New Size(1836, 849)
        TabShow.TabIndex = 2
        TabShow.Text = "Show"
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        SplitContainer2.Location = New Point(3, 28)
        SplitContainer2.Name = "SplitContainer2"
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(DG_Show)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(pbPDFViewer)
        SplitContainer2.Size = New Size(1833, 627)
        SplitContainer2.SplitterDistance = 1161
        SplitContainer2.TabIndex = 8
        ' 
        ' DG_Show
        ' 
        DG_Show.AllowUserToAddRows = False
        DG_Show.AllowUserToDeleteRows = False
        DG_Show.AllowUserToResizeRows = False
        DG_Show.BackgroundColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        DG_Show.ColumnHeadersHeight = 24
        DG_Show.Columns.AddRange(New DataGridViewColumn() {btnApply, colAct, colSceneId, colEventId, colTimer, colCue, colFixture, colStateOnOff, colEffectId, colEffect, colPaletteId, colPalette, colColor1, colColor2, colColor3, colBrightness, colSpeed, colIntensity, colTransition, colBlend, colRepeat, colSound, colFilename, colSend, ScriptPg})
        DG_Show.Dock = DockStyle.Fill
        DG_Show.Location = New Point(0, 0)
        DG_Show.Name = "DG_Show"
        DG_Show.RowHeadersWidth = 25
        DG_Show.Size = New Size(1161, 627)
        DG_Show.TabIndex = 0
        ' 
        ' pbPDFViewer
        ' 
        pbPDFViewer.Dock = DockStyle.Fill
        pbPDFViewer.Location = New Point(0, 0)
        pbPDFViewer.Name = "pbPDFViewer"
        pbPDFViewer.Size = New Size(668, 627)
        pbPDFViewer.TabIndex = 0
        pbPDFViewer.TabStop = False
        ' 
        ' gb_Controls
        ' 
        gb_Controls.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        gb_Controls.AutoSize = True
        gb_Controls.Controls.Add(btnControl_NextAct)
        gb_Controls.Controls.Add(btnStopLoopingAtEndOfVideo)
        gb_Controls.Controls.Add(btn_ReconnectSecondairyBeamer)
        gb_Controls.Controls.Add(btn_ReconnectPrimaryBeamer)
        gb_Controls.Controls.Add(btnControl_StopAll)
        gb_Controls.Controls.Add(lblControl_TimeLeft)
        gb_Controls.Controls.Add(btnControl_NextScene)
        gb_Controls.Controls.Add(btnControl_NextEvent)
        gb_Controls.Controls.Add(btnControl_Start)
        gb_Controls.ForeColor = Color.Gold
        gb_Controls.Location = New Point(787, 661)
        gb_Controls.Name = "gb_Controls"
        gb_Controls.Size = New Size(767, 186)
        gb_Controls.TabIndex = 7
        gb_Controls.TabStop = False
        gb_Controls.Text = "Show controls"
        ' 
        ' btnControl_NextAct
        ' 
        btnControl_NextAct.BackColor = Color.Black
        btnControl_NextAct.ForeColor = Color.White
        btnControl_NextAct.Image = CType(resources.GetObject("btnControl_NextAct.Image"), Image)
        btnControl_NextAct.ImageAlign = ContentAlignment.MiddleRight
        btnControl_NextAct.Location = New Point(111, 119)
        btnControl_NextAct.Name = "btnControl_NextAct"
        btnControl_NextAct.Size = New Size(368, 41)
        btnControl_NextAct.TabIndex = 8
        btnControl_NextAct.Text = "Volgende act"
        btnControl_NextAct.UseVisualStyleBackColor = False
        ' 
        ' btnStopLoopingAtEndOfVideo
        ' 
        btnStopLoopingAtEndOfVideo.BackColor = Color.Black
        btnStopLoopingAtEndOfVideo.BackgroundImageLayout = ImageLayout.None
        btnStopLoopingAtEndOfVideo.ForeColor = SystemColors.ActiveCaption
        btnStopLoopingAtEndOfVideo.Location = New Point(644, 118)
        btnStopLoopingAtEndOfVideo.Name = "btnStopLoopingAtEndOfVideo"
        btnStopLoopingAtEndOfVideo.Size = New Size(117, 42)
        btnStopLoopingAtEndOfVideo.TabIndex = 7
        btnStopLoopingAtEndOfVideo.Text = "Stop looping at end of video"
        btnStopLoopingAtEndOfVideo.UseVisualStyleBackColor = False
        btnStopLoopingAtEndOfVideo.Visible = False
        ' 
        ' btn_ReconnectSecondairyBeamer
        ' 
        btn_ReconnectSecondairyBeamer.BackColor = Color.Black
        btn_ReconnectSecondairyBeamer.BackgroundImageLayout = ImageLayout.None
        btn_ReconnectSecondairyBeamer.ForeColor = SystemColors.ActiveCaption
        btn_ReconnectSecondairyBeamer.Location = New Point(644, 69)
        btn_ReconnectSecondairyBeamer.Name = "btn_ReconnectSecondairyBeamer"
        btn_ReconnectSecondairyBeamer.Size = New Size(117, 42)
        btn_ReconnectSecondairyBeamer.TabIndex = 6
        btn_ReconnectSecondairyBeamer.Text = "Reconnect Secondairy Beamer"
        btn_ReconnectSecondairyBeamer.UseVisualStyleBackColor = False
        btn_ReconnectSecondairyBeamer.Visible = False
        ' 
        ' btn_ReconnectPrimaryBeamer
        ' 
        btn_ReconnectPrimaryBeamer.BackColor = Color.Black
        btn_ReconnectPrimaryBeamer.BackgroundImageLayout = ImageLayout.None
        btn_ReconnectPrimaryBeamer.ForeColor = SystemColors.ActiveCaption
        btn_ReconnectPrimaryBeamer.Location = New Point(644, 22)
        btn_ReconnectPrimaryBeamer.Name = "btn_ReconnectPrimaryBeamer"
        btn_ReconnectPrimaryBeamer.Size = New Size(117, 41)
        btn_ReconnectPrimaryBeamer.TabIndex = 5
        btn_ReconnectPrimaryBeamer.Text = "Reconnect Primary Beamer"
        btn_ReconnectPrimaryBeamer.UseVisualStyleBackColor = False
        btn_ReconnectPrimaryBeamer.Visible = False
        ' 
        ' btnControl_StopAll
        ' 
        btnControl_StopAll.BackColor = Color.Black
        btnControl_StopAll.ForeColor = Color.White
        btnControl_StopAll.Image = My.Resources.Resources.iconCancel
        btnControl_StopAll.ImageAlign = ContentAlignment.MiddleRight
        btnControl_StopAll.Location = New Point(485, 118)
        btnControl_StopAll.Name = "btnControl_StopAll"
        btnControl_StopAll.Size = New Size(153, 41)
        btnControl_StopAll.TabIndex = 4
        btnControl_StopAll.Text = "Stop / Blackout"
        btnControl_StopAll.UseVisualStyleBackColor = False
        ' 
        ' lblControl_TimeLeft
        ' 
        lblControl_TimeLeft.BackColor = Color.Black
        lblControl_TimeLeft.BorderStyle = BorderStyle.Fixed3D
        lblControl_TimeLeft.FlatStyle = FlatStyle.Flat
        lblControl_TimeLeft.ForeColor = Color.White
        lblControl_TimeLeft.Image = My.Resources.Resources.iconTime
        lblControl_TimeLeft.ImageAlign = ContentAlignment.MiddleLeft
        lblControl_TimeLeft.Location = New Point(485, 24)
        lblControl_TimeLeft.Name = "lblControl_TimeLeft"
        lblControl_TimeLeft.Size = New Size(153, 39)
        lblControl_TimeLeft.TabIndex = 3
        lblControl_TimeLeft.Text = "00:00"
        lblControl_TimeLeft.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' btnControl_NextScene
        ' 
        btnControl_NextScene.BackColor = Color.Black
        btnControl_NextScene.ForeColor = Color.White
        btnControl_NextScene.Image = My.Resources.Resources.iconFastForward
        btnControl_NextScene.ImageAlign = ContentAlignment.MiddleRight
        btnControl_NextScene.Location = New Point(111, 70)
        btnControl_NextScene.Name = "btnControl_NextScene"
        btnControl_NextScene.Size = New Size(368, 41)
        btnControl_NextScene.TabIndex = 2
        btnControl_NextScene.Text = "Volgende scene"
        btnControl_NextScene.UseVisualStyleBackColor = False
        ' 
        ' btnControl_NextEvent
        ' 
        btnControl_NextEvent.BackColor = Color.Black
        btnControl_NextEvent.ForeColor = Color.White
        btnControl_NextEvent.Image = My.Resources.Resources.iconPlay
        btnControl_NextEvent.ImageAlign = ContentAlignment.MiddleRight
        btnControl_NextEvent.Location = New Point(111, 23)
        btnControl_NextEvent.Name = "btnControl_NextEvent"
        btnControl_NextEvent.Size = New Size(368, 41)
        btnControl_NextEvent.TabIndex = 1
        btnControl_NextEvent.Text = "Volgende event"
        btnControl_NextEvent.UseVisualStyleBackColor = False
        ' 
        ' btnControl_Start
        ' 
        btnControl_Start.BackColor = Color.Black
        btnControl_Start.ForeColor = Color.White
        btnControl_Start.Image = My.Resources.Resources.iconChecked
        btnControl_Start.ImageAlign = ContentAlignment.MiddleLeft
        btnControl_Start.Location = New Point(6, 23)
        btnControl_Start.Name = "btnControl_Start"
        btnControl_Start.Size = New Size(99, 40)
        btnControl_Start.TabIndex = 0
        btnControl_Start.Text = "Start"
        btnControl_Start.UseVisualStyleBackColor = False
        ' 
        ' gb_DetailWLed
        ' 
        gb_DetailWLed.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        gb_DetailWLed.Controls.Add(Label13)
        gb_DetailWLed.Controls.Add(Label12)
        gb_DetailWLed.Controls.Add(detailWLed_Effect)
        gb_DetailWLed.Controls.Add(detailWLed__EffectName)
        gb_DetailWLed.Controls.Add(GroupBox11)
        gb_DetailWLed.Controls.Add(GroupBox10)
        gb_DetailWLed.Controls.Add(GroupBox9)
        gb_DetailWLed.Controls.Add(Label9)
        gb_DetailWLed.Controls.Add(detailWLed_Speed)
        gb_DetailWLed.Controls.Add(Label8)
        gb_DetailWLed.Controls.Add(detailWLed_Intensity)
        gb_DetailWLed.Controls.Add(Label7)
        gb_DetailWLed.Controls.Add(detailWLed_Brightness)
        gb_DetailWLed.Controls.Add(detailWLed_Palette)
        gb_DetailWLed.ForeColor = Color.MidnightBlue
        gb_DetailWLed.Location = New Point(282, 661)
        gb_DetailWLed.Name = "gb_DetailWLed"
        gb_DetailWLed.Size = New Size(499, 188)
        gb_DetailWLed.TabIndex = 6
        gb_DetailWLed.TabStop = False
        gb_DetailWLed.Text = "Details selected WLED"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(6, 44)
        Label13.Name = "Label13"
        Label13.Size = New Size(87, 15)
        Label13.TabIndex = 12
        Label13.Text = "Palette preview"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(6, 24)
        Label12.Name = "Label12"
        Label12.Size = New Size(81, 15)
        Label12.TabIndex = 11
        Label12.Text = "Effect preview"
        ' 
        ' detailWLed_Effect
        ' 
        detailWLed_Effect.Location = New Point(102, 15)
        detailWLed_Effect.Name = "detailWLed_Effect"
        detailWLed_Effect.Size = New Size(121, 25)
        detailWLed_Effect.TabIndex = 10
        detailWLed_Effect.TabStop = False
        ' 
        ' detailWLed__EffectName
        ' 
        detailWLed__EffectName.AutoSize = True
        detailWLed__EffectName.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        detailWLed__EffectName.ForeColor = Color.Gold
        detailWLed__EffectName.Location = New Point(99, 23)
        detailWLed__EffectName.Name = "detailWLed__EffectName"
        detailWLed__EffectName.Size = New Size(0, 15)
        detailWLed__EffectName.TabIndex = 9
        ' 
        ' GroupBox11
        ' 
        GroupBox11.Controls.Add(detailWLed_Color3)
        GroupBox11.Location = New Point(237, 139)
        GroupBox11.Name = "GroupBox11"
        GroupBox11.Size = New Size(64, 38)
        GroupBox11.TabIndex = 8
        GroupBox11.TabStop = False
        GroupBox11.Text = "Color 3"
        ' 
        ' detailWLed_Color3
        ' 
        detailWLed_Color3.Dock = DockStyle.Fill
        detailWLed_Color3.Location = New Point(3, 19)
        detailWLed_Color3.Name = "detailWLed_Color3"
        detailWLed_Color3.Size = New Size(58, 16)
        detailWLed_Color3.TabIndex = 0
        detailWLed_Color3.TabStop = False
        ' 
        ' GroupBox10
        ' 
        GroupBox10.Controls.Add(detailWLed_Color2)
        GroupBox10.Location = New Point(167, 139)
        GroupBox10.Name = "GroupBox10"
        GroupBox10.Size = New Size(64, 38)
        GroupBox10.TabIndex = 8
        GroupBox10.TabStop = False
        GroupBox10.Text = "Color 2"
        ' 
        ' detailWLed_Color2
        ' 
        detailWLed_Color2.Dock = DockStyle.Fill
        detailWLed_Color2.Location = New Point(3, 19)
        detailWLed_Color2.Name = "detailWLed_Color2"
        detailWLed_Color2.Size = New Size(58, 16)
        detailWLed_Color2.TabIndex = 0
        detailWLed_Color2.TabStop = False
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(detailWLed_Color1)
        GroupBox9.Location = New Point(97, 139)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(64, 38)
        GroupBox9.TabIndex = 7
        GroupBox9.TabStop = False
        GroupBox9.Text = "Color 1"
        ' 
        ' detailWLed_Color1
        ' 
        detailWLed_Color1.Dock = DockStyle.Fill
        detailWLed_Color1.Location = New Point(3, 19)
        detailWLed_Color1.Name = "detailWLed_Color1"
        detailWLed_Color1.Size = New Size(58, 16)
        detailWLed_Color1.TabIndex = 0
        detailWLed_Color1.TabStop = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(6, 109)
        Label9.Name = "Label9"
        Label9.Size = New Size(39, 15)
        Label9.TabIndex = 6
        Label9.Text = "Speed"
        ' 
        ' detailWLed_Speed
        ' 
        detailWLed_Speed.LargeChange = 100
        detailWLed_Speed.Location = New Point(97, 109)
        detailWLed_Speed.Maximum = 255
        detailWLed_Speed.Name = "detailWLed_Speed"
        detailWLed_Speed.Size = New Size(396, 45)
        detailWLed_Speed.SmallChange = 25
        detailWLed_Speed.TabIndex = 5
        detailWLed_Speed.TickFrequency = 25
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(6, 88)
        Label8.Name = "Label8"
        Label8.Size = New Size(52, 15)
        Label8.TabIndex = 4
        Label8.Text = "Intensity"
        ' 
        ' detailWLed_Intensity
        ' 
        detailWLed_Intensity.Location = New Point(97, 88)
        detailWLed_Intensity.Maximum = 255
        detailWLed_Intensity.Name = "detailWLed_Intensity"
        detailWLed_Intensity.Size = New Size(396, 45)
        detailWLed_Intensity.TabIndex = 3
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(6, 67)
        Label7.Name = "Label7"
        Label7.Size = New Size(62, 15)
        Label7.TabIndex = 2
        Label7.Text = "Brightness"
        ' 
        ' detailWLed_Brightness
        ' 
        detailWLed_Brightness.Location = New Point(97, 67)
        detailWLed_Brightness.Maximum = 255
        detailWLed_Brightness.Name = "detailWLed_Brightness"
        detailWLed_Brightness.Size = New Size(396, 45)
        detailWLed_Brightness.TabIndex = 1
        ' 
        ' detailWLed_Palette
        ' 
        detailWLed_Palette.Location = New Point(102, 46)
        detailWLed_Palette.Name = "detailWLed_Palette"
        detailWLed_Palette.Size = New Size(393, 11)
        detailWLed_Palette.TabIndex = 0
        detailWLed_Palette.TabStop = False
        ' 
        ' gbSecondairyBeamer
        ' 
        gbSecondairyBeamer.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        gbSecondairyBeamer.Controls.Add(warning_SecondairyBeamerOffline)
        gbSecondairyBeamer.Controls.Add(WMP_SecondairyPlayer_Preview)
        gbSecondairyBeamer.ForeColor = Color.MidnightBlue
        gbSecondairyBeamer.Location = New Point(1560, 661)
        gbSecondairyBeamer.Name = "gbSecondairyBeamer"
        gbSecondairyBeamer.Size = New Size(273, 186)
        gbSecondairyBeamer.TabIndex = 5
        gbSecondairyBeamer.TabStop = False
        gbSecondairyBeamer.Text = "Secondairy beamer - not playing"
        ' 
        ' warning_SecondairyBeamerOffline
        ' 
        warning_SecondairyBeamerOffline.AutoSize = True
        warning_SecondairyBeamerOffline.BackColor = Color.Transparent
        warning_SecondairyBeamerOffline.FlatStyle = FlatStyle.Flat
        warning_SecondairyBeamerOffline.ForeColor = Color.Red
        warning_SecondairyBeamerOffline.Location = New Point(89, 86)
        warning_SecondairyBeamerOffline.Name = "warning_SecondairyBeamerOffline"
        warning_SecondairyBeamerOffline.Size = New Size(94, 15)
        warning_SecondairyBeamerOffline.TabIndex = 2
        warning_SecondairyBeamerOffline.Text = "DISCONNECTED"
        ' 
        ' WMP_SecondairyPlayer_Preview
        ' 
        WMP_SecondairyPlayer_Preview.Dock = DockStyle.Fill
        WMP_SecondairyPlayer_Preview.Enabled = True
        WMP_SecondairyPlayer_Preview.Location = New Point(3, 19)
        WMP_SecondairyPlayer_Preview.Name = "WMP_SecondairyPlayer_Preview"
        WMP_SecondairyPlayer_Preview.OcxState = CType(resources.GetObject("WMP_SecondairyPlayer_Preview.OcxState"), AxHost.State)
        WMP_SecondairyPlayer_Preview.Size = New Size(267, 164)
        WMP_SecondairyPlayer_Preview.TabIndex = 0
        ' 
        ' gbPrimaryBeamer
        ' 
        gbPrimaryBeamer.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        gbPrimaryBeamer.BackColor = Color.DimGray
        gbPrimaryBeamer.Controls.Add(warning_PrimaryBeamerOffline)
        gbPrimaryBeamer.Controls.Add(WMP_PrimaryPlayer_Preview)
        gbPrimaryBeamer.ForeColor = Color.MidnightBlue
        gbPrimaryBeamer.Location = New Point(8, 661)
        gbPrimaryBeamer.Name = "gbPrimaryBeamer"
        gbPrimaryBeamer.Size = New Size(268, 188)
        gbPrimaryBeamer.TabIndex = 4
        gbPrimaryBeamer.TabStop = False
        gbPrimaryBeamer.Text = "Primary beamer - Not playing"
        ' 
        ' warning_PrimaryBeamerOffline
        ' 
        warning_PrimaryBeamerOffline.AutoSize = True
        warning_PrimaryBeamerOffline.BackColor = Color.Transparent
        warning_PrimaryBeamerOffline.FlatStyle = FlatStyle.Flat
        warning_PrimaryBeamerOffline.ForeColor = Color.Red
        warning_PrimaryBeamerOffline.Location = New Point(82, 80)
        warning_PrimaryBeamerOffline.Name = "warning_PrimaryBeamerOffline"
        warning_PrimaryBeamerOffline.Size = New Size(94, 15)
        warning_PrimaryBeamerOffline.TabIndex = 1
        warning_PrimaryBeamerOffline.Text = "DISCONNECTED"
        ' 
        ' WMP_PrimaryPlayer_Preview
        ' 
        WMP_PrimaryPlayer_Preview.Dock = DockStyle.Fill
        WMP_PrimaryPlayer_Preview.Enabled = True
        WMP_PrimaryPlayer_Preview.Location = New Point(3, 19)
        WMP_PrimaryPlayer_Preview.Name = "WMP_PrimaryPlayer_Preview"
        WMP_PrimaryPlayer_Preview.OcxState = CType(resources.GetObject("WMP_PrimaryPlayer_Preview.OcxState"), AxHost.State)
        WMP_PrimaryPlayer_Preview.Size = New Size(262, 166)
        WMP_PrimaryPlayer_Preview.TabIndex = 0
        ' 
        ' ToolStip_Show
        ' 
        ToolStip_Show.BackColor = Color.MidnightBlue
        ToolStip_Show.GripStyle = ToolStripGripStyle.Hidden
        ToolStip_Show.Items.AddRange(New ToolStripItem() {lblFilter, filterAct, btn_DGGrid_RemoveCurrentRow, btn_DGGrid_AddNewRowAfter, btn_DGGrid_AddNewRowBefore, ToolStripSeparator2, btnLockUnlocked, ToolStripLabel7, lblPDFPage})
        ToolStip_Show.Location = New Point(0, 0)
        ToolStip_Show.Name = "ToolStip_Show"
        ToolStip_Show.Size = New Size(1836, 25)
        ToolStip_Show.TabIndex = 3
        ToolStip_Show.Text = "ToolStrip_Show"
        ' 
        ' lblFilter
        ' 
        lblFilter.ForeColor = SystemColors.ControlLightLight
        lblFilter.Image = My.Resources.Resources.iconFilter2
        lblFilter.Name = "lblFilter"
        lblFilter.Size = New Size(88, 22)
        lblFilter.Text = "Filter op act:"
        ' 
        ' filterAct
        ' 
        filterAct.Items.AddRange(New Object() {"", "Pre-Show", "Act 1", "Pauze", "Act 2", "Act 3", "Post-Show"})
        filterAct.Name = "filterAct"
        filterAct.Size = New Size(121, 25)
        ' 
        ' btn_DGGrid_RemoveCurrentRow
        ' 
        btn_DGGrid_RemoveCurrentRow.Alignment = ToolStripItemAlignment.Right
        btn_DGGrid_RemoveCurrentRow.DisplayStyle = ToolStripItemDisplayStyle.Image
        btn_DGGrid_RemoveCurrentRow.Image = CType(resources.GetObject("btn_DGGrid_RemoveCurrentRow.Image"), Image)
        btn_DGGrid_RemoveCurrentRow.ImageTransparentColor = Color.Magenta
        btn_DGGrid_RemoveCurrentRow.Name = "btn_DGGrid_RemoveCurrentRow"
        btn_DGGrid_RemoveCurrentRow.Size = New Size(23, 22)
        btn_DGGrid_RemoveCurrentRow.Text = "Verwijder huidige regel"
        btn_DGGrid_RemoveCurrentRow.ToolTipText = "Verwijder de geselecteerde regel"
        ' 
        ' btn_DGGrid_AddNewRowAfter
        ' 
        btn_DGGrid_AddNewRowAfter.Alignment = ToolStripItemAlignment.Right
        btn_DGGrid_AddNewRowAfter.DisplayStyle = ToolStripItemDisplayStyle.Image
        btn_DGGrid_AddNewRowAfter.Image = CType(resources.GetObject("btn_DGGrid_AddNewRowAfter.Image"), Image)
        btn_DGGrid_AddNewRowAfter.ImageTransparentColor = Color.Magenta
        btn_DGGrid_AddNewRowAfter.Name = "btn_DGGrid_AddNewRowAfter"
        btn_DGGrid_AddNewRowAfter.Size = New Size(23, 22)
        btn_DGGrid_AddNewRowAfter.Text = "Toevoegen regel na huidige regel"
        btn_DGGrid_AddNewRowAfter.ToolTipText = "Voeg een regel in na de huidige regel."
        ' 
        ' btn_DGGrid_AddNewRowBefore
        ' 
        btn_DGGrid_AddNewRowBefore.Alignment = ToolStripItemAlignment.Right
        btn_DGGrid_AddNewRowBefore.DisplayStyle = ToolStripItemDisplayStyle.Image
        btn_DGGrid_AddNewRowBefore.Image = CType(resources.GetObject("btn_DGGrid_AddNewRowBefore.Image"), Image)
        btn_DGGrid_AddNewRowBefore.ImageTransparentColor = Color.Magenta
        btn_DGGrid_AddNewRowBefore.Name = "btn_DGGrid_AddNewRowBefore"
        btn_DGGrid_AddNewRowBefore.Size = New Size(23, 22)
        btn_DGGrid_AddNewRowBefore.Text = "Toevoegen voor huidige regel"
        btn_DGGrid_AddNewRowBefore.TextImageRelation = TextImageRelation.ImageAboveText
        btn_DGGrid_AddNewRowBefore.ToolTipText = "Voeg een regel in voor huidige regel."
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Alignment = ToolStripItemAlignment.Right
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 25)
        ' 
        ' btnLockUnlocked
        ' 
        btnLockUnlocked.Alignment = ToolStripItemAlignment.Right
        btnLockUnlocked.ForeColor = SystemColors.ControlLightLight
        btnLockUnlocked.Image = My.Resources.Resources.iconUnlocked_Green
        btnLockUnlocked.ImageTransparentColor = Color.Magenta
        btnLockUnlocked.Name = "btnLockUnlocked"
        btnLockUnlocked.Size = New Size(77, 22)
        btnLockUnlocked.Text = "Unlocked"
        ' 
        ' ToolStripLabel7
        ' 
        ToolStripLabel7.ForeColor = SystemColors.ActiveCaption
        ToolStripLabel7.Name = "ToolStripLabel7"
        ToolStripLabel7.Size = New Size(54, 22)
        ToolStripLabel7.Text = "At page: "
        ' 
        ' lblPDFPage
        ' 
        lblPDFPage.ForeColor = SystemColors.ButtonFace
        lblPDFPage.Name = "lblPDFPage"
        lblPDFPage.Size = New Size(23, 22)
        lblPDFPage.Text = "n.a"
        ' 
        ' TabStage
        ' 
        TabStage.BackColor = Color.Black
        TabStage.Controls.Add(SplitContainerStage)
        TabStage.Controls.Add(ToolStripSegments)
        TabStage.Location = New Point(4, 24)
        TabStage.Name = "TabStage"
        TabStage.Padding = New Padding(3)
        TabStage.Size = New Size(1836, 849)
        TabStage.TabIndex = 6
        TabStage.Text = "Stage"
        ' 
        ' SplitContainerStage
        ' 
        SplitContainerStage.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        SplitContainerStage.FixedPanel = FixedPanel.Panel1
        SplitContainerStage.Location = New Point(3, 31)
        SplitContainerStage.Name = "SplitContainerStage"
        SplitContainerStage.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainerStage.Panel1
        ' 
        SplitContainerStage.Panel1.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        SplitContainerStage.Panel1.Controls.Add(SplitContainer1)
        ' 
        ' SplitContainerStage.Panel2
        ' 
        SplitContainerStage.Panel2.Controls.Add(pb_Stage)
        SplitContainerStage.Size = New Size(1830, 815)
        SplitContainerStage.SplitterDistance = 171
        SplitContainerStage.TabIndex = 3
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(PanelTracks)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(btnApplyCustomEffect)
        SplitContainer1.Panel2.Controls.Add(btnResetEffect)
        SplitContainer1.Panel2.Controls.Add(btnStopEffectPreview)
        SplitContainer1.Panel2.Controls.Add(btnStartEffectPreview)
        SplitContainer1.Size = New Size(1830, 171)
        SplitContainer1.SplitterDistance = 1671
        SplitContainer1.TabIndex = 12
        ' 
        ' PanelTracks
        ' 
        PanelTracks.Dock = DockStyle.Fill
        PanelTracks.Location = New Point(0, 0)
        PanelTracks.Name = "PanelTracks"
        PanelTracks.Size = New Size(1671, 171)
        PanelTracks.TabIndex = 0
        ' 
        ' btnApplyCustomEffect
        ' 
        btnApplyCustomEffect.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnApplyCustomEffect.Image = My.Resources.Resources.iconChecked
        btnApplyCustomEffect.ImageAlign = ContentAlignment.MiddleLeft
        btnApplyCustomEffect.Location = New Point(14, 48)
        btnApplyCustomEffect.Name = "btnApplyCustomEffect"
        btnApplyCustomEffect.Size = New Size(138, 23)
        btnApplyCustomEffect.TabIndex = 4
        btnApplyCustomEffect.Text = "Apply effect"
        btnApplyCustomEffect.UseVisualStyleBackColor = True
        ' 
        ' btnResetEffect
        ' 
        btnResetEffect.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnResetEffect.Image = My.Resources.Resources.iconCancel
        btnResetEffect.ImageAlign = ContentAlignment.MiddleLeft
        btnResetEffect.Location = New Point(14, 78)
        btnResetEffect.Name = "btnResetEffect"
        btnResetEffect.Size = New Size(138, 23)
        btnResetEffect.TabIndex = 10
        btnResetEffect.Text = "Reset effect"
        btnResetEffect.UseVisualStyleBackColor = True
        ' 
        ' btnStopEffectPreview
        ' 
        btnStopEffectPreview.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnStopEffectPreview.Image = My.Resources.Resources.iconPause
        btnStopEffectPreview.ImageAlign = ContentAlignment.MiddleLeft
        btnStopEffectPreview.Location = New Point(14, 137)
        btnStopEffectPreview.Name = "btnStopEffectPreview"
        btnStopEffectPreview.Size = New Size(138, 23)
        btnStopEffectPreview.TabIndex = 8
        btnStopEffectPreview.Text = "Stop preview"
        btnStopEffectPreview.UseVisualStyleBackColor = True
        ' 
        ' btnStartEffectPreview
        ' 
        btnStartEffectPreview.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnStartEffectPreview.Image = My.Resources.Resources.iconPlay
        btnStartEffectPreview.ImageAlign = ContentAlignment.MiddleLeft
        btnStartEffectPreview.Location = New Point(14, 108)
        btnStartEffectPreview.Name = "btnStartEffectPreview"
        btnStartEffectPreview.Size = New Size(138, 23)
        btnStartEffectPreview.TabIndex = 7
        btnStartEffectPreview.Text = "Start preview"
        btnStartEffectPreview.UseVisualStyleBackColor = True
        ' 
        ' pb_Stage
        ' 
        pb_Stage.BackColor = Color.Black
        pb_Stage.Dock = DockStyle.Fill
        pb_Stage.Location = New Point(0, 0)
        pb_Stage.Name = "pb_Stage"
        pb_Stage.Size = New Size(1830, 640)
        pb_Stage.TabIndex = 2
        pb_Stage.TabStop = False
        ' 
        ' ToolStripSegments
        ' 
        ToolStripSegments.BackColor = Color.MidnightBlue
        ToolStripSegments.GripStyle = ToolStripGripStyle.Hidden
        ToolStripSegments.Items.AddRange(New ToolStripItem() {btnResetFrames, ToolStripSeparator1, BtnZoomPulldown, ToolStripSeparator6, ToolStripLabel3, cbSelectedEffect, btnEditTemplate, btnEffectAdd, btnEffectDelete, ToolStripSeparator7, ToolStripLabel2, BtnAddTrack, BtnRemoveTrack, ToolStripSeparator8, ToolStripLabel4, btnAddShape, btnRemoveShape, ToolStripSeparator9, ToolStripLabel5, lblPreviewFromPosition, ToolStripLabel6, lblPreviewToPosition, btnRepeat, btnPreviewPlayPause, pbPreview})
        ToolStripSegments.Location = New Point(3, 3)
        ToolStripSegments.Name = "ToolStripSegments"
        ToolStripSegments.Size = New Size(1830, 25)
        ToolStripSegments.TabIndex = 1
        ToolStripSegments.Text = "ToolStripSegments"
        ' 
        ' btnResetFrames
        ' 
        btnResetFrames.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnResetFrames.Image = CType(resources.GetObject("btnResetFrames.Image"), Image)
        btnResetFrames.ImageTransparentColor = Color.Black
        btnResetFrames.Name = "btnResetFrames"
        btnResetFrames.Size = New Size(23, 22)
        btnResetFrames.Text = "Reset"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 25)
        ' 
        ' BtnZoomPulldown
        ' 
        BtnZoomPulldown.DisplayStyle = ToolStripItemDisplayStyle.Image
        BtnZoomPulldown.DropDownItems.AddRange(New ToolStripItem() {btnZoom10, btnZoom30, btnZoom60, btnZoom90})
        BtnZoomPulldown.Image = CType(resources.GetObject("BtnZoomPulldown.Image"), Image)
        BtnZoomPulldown.ImageTransparentColor = Color.White
        BtnZoomPulldown.Name = "BtnZoomPulldown"
        BtnZoomPulldown.Size = New Size(29, 22)
        BtnZoomPulldown.Text = "ToolStripDropDownButton1"
        ' 
        ' btnZoom10
        ' 
        btnZoom10.Name = "btnZoom10"
        btnZoom10.Size = New Size(140, 22)
        btnZoom10.Text = "10 seconden"
        ' 
        ' btnZoom30
        ' 
        btnZoom30.Name = "btnZoom30"
        btnZoom30.Size = New Size(140, 22)
        btnZoom30.Text = "30 seconden"
        ' 
        ' btnZoom60
        ' 
        btnZoom60.Checked = True
        btnZoom60.CheckOnClick = True
        btnZoom60.CheckState = CheckState.Checked
        btnZoom60.Name = "btnZoom60"
        btnZoom60.Size = New Size(140, 22)
        btnZoom60.Text = "60 seconden"
        ' 
        ' btnZoom90
        ' 
        btnZoom90.Name = "btnZoom90"
        btnZoom90.Size = New Size(140, 22)
        btnZoom90.Text = "90 seconden"
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(6, 25)
        ' 
        ' ToolStripLabel3
        ' 
        ToolStripLabel3.DisplayStyle = ToolStripItemDisplayStyle.Text
        ToolStripLabel3.ForeColor = SystemColors.ActiveCaption
        ToolStripLabel3.Name = "ToolStripLabel3"
        ToolStripLabel3.Size = New Size(59, 22)
        ToolStripLabel3.Text = "Template:"
        ' 
        ' cbSelectedEffect
        ' 
        cbSelectedEffect.Name = "cbSelectedEffect"
        cbSelectedEffect.Size = New Size(121, 25)
        cbSelectedEffect.Sorted = True
        ' 
        ' btnEditTemplate
        ' 
        btnEditTemplate.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnEditTemplate.Image = CType(resources.GetObject("btnEditTemplate.Image"), Image)
        btnEditTemplate.ImageTransparentColor = Color.Magenta
        btnEditTemplate.Name = "btnEditTemplate"
        btnEditTemplate.Size = New Size(23, 22)
        btnEditTemplate.Text = "Edit template"
        ' 
        ' btnEffectAdd
        ' 
        btnEffectAdd.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnEffectAdd.Image = My.Resources.Resources.iconEffectAdd
        btnEffectAdd.ImageTransparentColor = Color.Magenta
        btnEffectAdd.Name = "btnEffectAdd"
        btnEffectAdd.Size = New Size(23, 22)
        btnEffectAdd.Text = "Add template"
        ' 
        ' btnEffectDelete
        ' 
        btnEffectDelete.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnEffectDelete.Image = My.Resources.Resources.iconEffectDelete
        btnEffectDelete.ImageTransparentColor = Color.Magenta
        btnEffectDelete.Name = "btnEffectDelete"
        btnEffectDelete.Size = New Size(23, 22)
        btnEffectDelete.Text = "Remove template"
        ' 
        ' ToolStripSeparator7
        ' 
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New Size(6, 25)
        ' 
        ' ToolStripLabel2
        ' 
        ToolStripLabel2.ForeColor = SystemColors.ActiveCaption
        ToolStripLabel2.Name = "ToolStripLabel2"
        ToolStripLabel2.Size = New Size(38, 22)
        ToolStripLabel2.Text = "Track:"
        ' 
        ' BtnAddTrack
        ' 
        BtnAddTrack.DisplayStyle = ToolStripItemDisplayStyle.Image
        BtnAddTrack.Image = CType(resources.GetObject("BtnAddTrack.Image"), Image)
        BtnAddTrack.ImageTransparentColor = Color.Magenta
        BtnAddTrack.Name = "BtnAddTrack"
        BtnAddTrack.Size = New Size(23, 22)
        BtnAddTrack.Text = "Add track"
        ' 
        ' BtnRemoveTrack
        ' 
        BtnRemoveTrack.DisplayStyle = ToolStripItemDisplayStyle.Image
        BtnRemoveTrack.Image = CType(resources.GetObject("BtnRemoveTrack.Image"), Image)
        BtnRemoveTrack.ImageTransparentColor = Color.Magenta
        BtnRemoveTrack.Name = "BtnRemoveTrack"
        BtnRemoveTrack.Size = New Size(23, 22)
        BtnRemoveTrack.Text = "Remove track"
        ' 
        ' ToolStripSeparator8
        ' 
        ToolStripSeparator8.Name = "ToolStripSeparator8"
        ToolStripSeparator8.Size = New Size(6, 25)
        ' 
        ' ToolStripLabel4
        ' 
        ToolStripLabel4.DisplayStyle = ToolStripItemDisplayStyle.Text
        ToolStripLabel4.ForeColor = SystemColors.ActiveCaption
        ToolStripLabel4.Name = "ToolStripLabel4"
        ToolStripLabel4.Size = New Size(42, 22)
        ToolStripLabel4.Text = "Shape:"
        ' 
        ' btnAddShape
        ' 
        btnAddShape.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnAddShape.Image = CType(resources.GetObject("btnAddShape.Image"), Image)
        btnAddShape.ImageTransparentColor = Color.Magenta
        btnAddShape.Name = "btnAddShape"
        btnAddShape.Size = New Size(23, 22)
        btnAddShape.Text = "AddShape"
        ' 
        ' btnRemoveShape
        ' 
        btnRemoveShape.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnRemoveShape.Image = CType(resources.GetObject("btnRemoveShape.Image"), Image)
        btnRemoveShape.ImageTransparentColor = Color.Magenta
        btnRemoveShape.Name = "btnRemoveShape"
        btnRemoveShape.Size = New Size(23, 22)
        btnRemoveShape.Text = "Remove shape"
        ' 
        ' ToolStripSeparator9
        ' 
        ToolStripSeparator9.Name = "ToolStripSeparator9"
        ToolStripSeparator9.Size = New Size(6, 25)
        ' 
        ' ToolStripLabel5
        ' 
        ToolStripLabel5.ForeColor = SystemColors.ActiveCaption
        ToolStripLabel5.Name = "ToolStripLabel5"
        ToolStripLabel5.Size = New Size(54, 22)
        ToolStripLabel5.Text = "Preview: "
        ' 
        ' lblPreviewFromPosition
        ' 
        lblPreviewFromPosition.Name = "lblPreviewFromPosition"
        lblPreviewFromPosition.Size = New Size(50, 25)
        ' 
        ' ToolStripLabel6
        ' 
        ToolStripLabel6.ForeColor = SystemColors.ActiveCaption
        ToolStripLabel6.Name = "ToolStripLabel6"
        ToolStripLabel6.Size = New Size(20, 22)
        ToolStripLabel6.Text = "To"
        ' 
        ' lblPreviewToPosition
        ' 
        lblPreviewToPosition.Name = "lblPreviewToPosition"
        lblPreviewToPosition.Size = New Size(50, 25)
        ' 
        ' btnRepeat
        ' 
        btnRepeat.ForeColor = SystemColors.ActiveCaption
        btnRepeat.Image = My.Resources.Resources.iconCheckbox_checked
        btnRepeat.ImageTransparentColor = Color.Magenta
        btnRepeat.Name = "btnRepeat"
        btnRepeat.Size = New Size(63, 22)
        btnRepeat.Text = "Repeat"
        ' 
        ' btnPreviewPlayPause
        ' 
        btnPreviewPlayPause.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnPreviewPlayPause.Image = My.Resources.Resources.iconPause
        btnPreviewPlayPause.ImageTransparentColor = Color.Magenta
        btnPreviewPlayPause.Name = "btnPreviewPlayPause"
        btnPreviewPlayPause.Size = New Size(23, 22)
        btnPreviewPlayPause.Text = "Play/Pause"
        ' 
        ' pbPreview
        ' 
        pbPreview.MarqueeAnimationSpeed = 4500
        pbPreview.Maximum = 4500
        pbPreview.Name = "pbPreview"
        pbPreview.Size = New Size(100, 22)
        pbPreview.Style = ProgressBarStyle.Continuous
        ' 
        ' TabTables
        ' 
        TabTables.Controls.Add(ToolStripTables)
        TabTables.Controls.Add(TabControlTables)
        TabTables.Location = New Point(4, 24)
        TabTables.Name = "TabTables"
        TabTables.Size = New Size(1836, 849)
        TabTables.TabIndex = 9
        TabTables.Text = "Tables"
        TabTables.UseVisualStyleBackColor = True
        ' 
        ' ToolStripTables
        ' 
        ToolStripTables.BackColor = Color.MidnightBlue
        ToolStripTables.GripStyle = ToolStripGripStyle.Hidden
        ToolStripTables.Items.AddRange(New ToolStripItem() {btnTablesAddRowBefore, btnTablesAddRowAfter, btnTablesDeleteSingleRow, ToolStripSeparator3, btnDeleteAllTables, ToolStripSeparator5})
        ToolStripTables.Location = New Point(0, 0)
        ToolStripTables.Name = "ToolStripTables"
        ToolStripTables.Size = New Size(1836, 25)
        ToolStripTables.TabIndex = 1
        ToolStripTables.Text = "ToolStrip1"
        ' 
        ' btnTablesAddRowBefore
        ' 
        btnTablesAddRowBefore.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnTablesAddRowBefore.Image = My.Resources.Resources.iconRowAddBefore
        btnTablesAddRowBefore.ImageTransparentColor = Color.Magenta
        btnTablesAddRowBefore.Name = "btnTablesAddRowBefore"
        btnTablesAddRowBefore.Size = New Size(23, 22)
        btnTablesAddRowBefore.Text = "Add before"
        ' 
        ' btnTablesAddRowAfter
        ' 
        btnTablesAddRowAfter.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnTablesAddRowAfter.Image = My.Resources.Resources.iconRowAddAfter
        btnTablesAddRowAfter.ImageTransparentColor = Color.Magenta
        btnTablesAddRowAfter.Name = "btnTablesAddRowAfter"
        btnTablesAddRowAfter.Size = New Size(23, 22)
        btnTablesAddRowAfter.Text = "Add row after"
        ' 
        ' btnTablesDeleteSingleRow
        ' 
        btnTablesDeleteSingleRow.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnTablesDeleteSingleRow.Image = My.Resources.Resources.iconRowDelete
        btnTablesDeleteSingleRow.ImageTransparentColor = Color.Magenta
        btnTablesDeleteSingleRow.Name = "btnTablesDeleteSingleRow"
        btnTablesDeleteSingleRow.Size = New Size(23, 22)
        btnTablesDeleteSingleRow.Text = "Delete row"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(6, 25)
        ' 
        ' btnDeleteAllTables
        ' 
        btnDeleteAllTables.Alignment = ToolStripItemAlignment.Right
        btnDeleteAllTables.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnDeleteAllTables.ForeColor = SystemColors.ButtonFace
        btnDeleteAllTables.Image = CType(resources.GetObject("btnDeleteAllTables.Image"), Image)
        btnDeleteAllTables.ImageTransparentColor = Color.Magenta
        btnDeleteAllTables.Name = "btnDeleteAllTables"
        btnDeleteAllTables.Size = New Size(59, 22)
        btnDeleteAllTables.Text = "Delete all"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Alignment = ToolStripItemAlignment.Right
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(6, 25)
        ' 
        ' TabControlTables
        ' 
        TabControlTables.Controls.Add(TabTemplates)
        TabControlTables.Controls.Add(TabTracks)
        TabControlTables.Controls.Add(TabLightSources)
        TabControlTables.Controls.Add(TabFrames)
        TabControlTables.Dock = DockStyle.Bottom
        TabControlTables.Location = New Point(0, 32)
        TabControlTables.Name = "TabControlTables"
        TabControlTables.SelectedIndex = 0
        TabControlTables.Size = New Size(1836, 817)
        TabControlTables.TabIndex = 0
        ' 
        ' TabTemplates
        ' 
        TabTemplates.Controls.Add(DG_Templates)
        TabTemplates.Location = New Point(4, 24)
        TabTemplates.Name = "TabTemplates"
        TabTemplates.Size = New Size(1828, 789)
        TabTemplates.TabIndex = 3
        TabTemplates.Text = "Templates"
        TabTemplates.UseVisualStyleBackColor = True
        ' 
        ' DG_Templates
        ' 
        DG_Templates.AllowUserToAddRows = False
        DG_Templates.AllowUserToDeleteRows = False
        DG_Templates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Templates.Columns.AddRange(New DataGridViewColumn() {colTemplateID, colTemplateName, colTemplateDescription, colTemplateDuration, colTemplateRepeat, colTemplateDDPData})
        DG_Templates.Dock = DockStyle.Fill
        DG_Templates.Location = New Point(0, 0)
        DG_Templates.Name = "DG_Templates"
        DG_Templates.Size = New Size(1828, 789)
        DG_Templates.TabIndex = 0
        ' 
        ' colTemplateID
        ' 
        colTemplateID.HeaderText = "ID"
        colTemplateID.Name = "colTemplateID"
        colTemplateID.Width = 50
        ' 
        ' colTemplateName
        ' 
        colTemplateName.HeaderText = "Name"
        colTemplateName.Name = "colTemplateName"
        colTemplateName.Width = 200
        ' 
        ' colTemplateDescription
        ' 
        colTemplateDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colTemplateDescription.HeaderText = "Description"
        colTemplateDescription.Name = "colTemplateDescription"
        ' 
        ' colTemplateDuration
        ' 
        colTemplateDuration.HeaderText = "Duration"
        colTemplateDuration.Name = "colTemplateDuration"
        ' 
        ' colTemplateRepeat
        ' 
        colTemplateRepeat.HeaderText = "Repeat"
        colTemplateRepeat.Name = "colTemplateRepeat"
        ' 
        ' colTemplateDDPData
        ' 
        colTemplateDDPData.HeaderText = "DDPData"
        colTemplateDDPData.Name = "colTemplateDDPData"
        ' 
        ' TabTracks
        ' 
        TabTracks.Controls.Add(DG_Tracks)
        TabTracks.Location = New Point(4, 24)
        TabTracks.Name = "TabTracks"
        TabTracks.Padding = New Padding(3)
        TabTracks.Size = New Size(1828, 789)
        TabTracks.TabIndex = 1
        TabTracks.Text = "Tracks"
        TabTracks.UseVisualStyleBackColor = True
        ' 
        ' DG_Tracks
        ' 
        DG_Tracks.AllowUserToAddRows = False
        DG_Tracks.AllowUserToDeleteRows = False
        DG_Tracks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Tracks.Columns.AddRange(New DataGridViewColumn() {colTrackId, colTrackTemplateId, colTrackName, colTrackActive})
        DG_Tracks.Dock = DockStyle.Fill
        DG_Tracks.Location = New Point(3, 3)
        DG_Tracks.Name = "DG_Tracks"
        DG_Tracks.Size = New Size(1822, 783)
        DG_Tracks.TabIndex = 0
        ' 
        ' colTrackId
        ' 
        colTrackId.HeaderText = "TrackID"
        colTrackId.Name = "colTrackId"
        colTrackId.Width = 50
        ' 
        ' colTrackTemplateId
        ' 
        colTrackTemplateId.HeaderText = "TemplateID"
        colTrackTemplateId.Name = "colTrackTemplateId"
        colTrackTemplateId.Width = 50
        ' 
        ' colTrackName
        ' 
        colTrackName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colTrackName.HeaderText = "Track naam"
        colTrackName.Name = "colTrackName"
        ' 
        ' colTrackActive
        ' 
        colTrackActive.HeaderText = "Active"
        colTrackActive.Name = "colTrackActive"
        ' 
        ' TabLightSources
        ' 
        TabLightSources.Controls.Add(DG_LightSources)
        TabLightSources.Location = New Point(4, 24)
        TabLightSources.Name = "TabLightSources"
        TabLightSources.Padding = New Padding(3)
        TabLightSources.Size = New Size(1828, 789)
        TabLightSources.TabIndex = 0
        TabLightSources.Text = "Lichtbronnen"
        TabLightSources.UseVisualStyleBackColor = True
        ' 
        ' DG_LightSources
        ' 
        DG_LightSources.AllowUserToAddRows = False
        DG_LightSources.AllowUserToDeleteRows = False
        DG_LightSources.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_LightSources.Columns.AddRange(New DataGridViewColumn() {colLSId, colLSTrackId, colLSTemplateId, colLSStartMoment, colLSDuration, colLSPositionX, colLSPositionY, colLSSize, colLSShape, colLSBlend, colLSDirection, colLSColor1, colLSColor2, colLSColor3, colLSColor4, colLSColor5, colLSBrightnessBaseline, colLSBrightnessEffect, colLSEffect, colLSGroups, colLSEffectSpeed, colLSEffectIntensity, colLSEffectDispersion, colLSEffectStartPosition, colLSEffectDirection})
        DG_LightSources.Dock = DockStyle.Fill
        DG_LightSources.Location = New Point(3, 3)
        DG_LightSources.Name = "DG_LightSources"
        DG_LightSources.Size = New Size(1822, 783)
        DG_LightSources.TabIndex = 0
        ' 
        ' colLSId
        ' 
        colLSId.HeaderText = "colLSId"
        colLSId.Name = "colLSId"
        ' 
        ' colLSTrackId
        ' 
        colLSTrackId.HeaderText = "colLSTrackId"
        colLSTrackId.Name = "colLSTrackId"
        ' 
        ' colLSTemplateId
        ' 
        colLSTemplateId.HeaderText = "colLSMyTemplateId"
        colLSTemplateId.Name = "colLSTemplateId"
        ' 
        ' colLSStartMoment
        ' 
        colLSStartMoment.HeaderText = "colLSStartMoment"
        colLSStartMoment.Name = "colLSStartMoment"
        ' 
        ' colLSDuration
        ' 
        colLSDuration.HeaderText = "colLSDuration"
        colLSDuration.Name = "colLSDuration"
        ' 
        ' colLSPositionX
        ' 
        colLSPositionX.HeaderText = "colLSPositionX"
        colLSPositionX.Name = "colLSPositionX"
        ' 
        ' colLSPositionY
        ' 
        colLSPositionY.HeaderText = "colLSPositionY"
        colLSPositionY.Name = "colLSPositionY"
        ' 
        ' colLSSize
        ' 
        colLSSize.HeaderText = "colLSSize"
        colLSSize.Name = "colLSSize"
        ' 
        ' colLSShape
        ' 
        colLSShape.HeaderText = "colLSShape"
        colLSShape.Name = "colLSShape"
        ' 
        ' colLSBlend
        ' 
        colLSBlend.HeaderText = "colLSBlend"
        colLSBlend.Name = "colLSBlend"
        ' 
        ' colLSDirection
        ' 
        colLSDirection.HeaderText = "colLSDirection"
        colLSDirection.Name = "colLSDirection"
        ' 
        ' colLSColor1
        ' 
        colLSColor1.HeaderText = "colLSColor1"
        colLSColor1.Name = "colLSColor1"
        ' 
        ' colLSColor2
        ' 
        colLSColor2.HeaderText = "colLSColor2"
        colLSColor2.Name = "colLSColor2"
        ' 
        ' colLSColor3
        ' 
        colLSColor3.HeaderText = "colLSColor3"
        colLSColor3.Name = "colLSColor3"
        ' 
        ' colLSColor4
        ' 
        colLSColor4.HeaderText = "colLSColor4"
        colLSColor4.Name = "colLSColor4"
        ' 
        ' colLSColor5
        ' 
        colLSColor5.HeaderText = "colLSColor5"
        colLSColor5.Name = "colLSColor5"
        ' 
        ' colLSBrightnessBaseline
        ' 
        colLSBrightnessBaseline.HeaderText = "colLSBrightnessBaseline"
        colLSBrightnessBaseline.Name = "colLSBrightnessBaseline"
        ' 
        ' colLSBrightnessEffect
        ' 
        colLSBrightnessEffect.HeaderText = "colLSBrightnessEffect"
        colLSBrightnessEffect.Name = "colLSBrightnessEffect"
        ' 
        ' colLSEffect
        ' 
        colLSEffect.HeaderText = "colLSEffect"
        colLSEffect.Name = "colLSEffect"
        ' 
        ' colLSGroups
        ' 
        colLSGroups.HeaderText = "colLSGroups"
        colLSGroups.Name = "colLSGroups"
        ' 
        ' colLSEffectSpeed
        ' 
        colLSEffectSpeed.HeaderText = "colLSEffectSpeed"
        colLSEffectSpeed.Name = "colLSEffectSpeed"
        ' 
        ' colLSEffectIntensity
        ' 
        colLSEffectIntensity.HeaderText = "colLSEffectIntensity"
        colLSEffectIntensity.Name = "colLSEffectIntensity"
        ' 
        ' colLSEffectDispersion
        ' 
        colLSEffectDispersion.HeaderText = "colLSEffectDispersion"
        colLSEffectDispersion.Name = "colLSEffectDispersion"
        ' 
        ' colLSEffectStartPosition
        ' 
        colLSEffectStartPosition.HeaderText = "colLSEffectStartPosition"
        colLSEffectStartPosition.Items.AddRange(New Object() {"TopLeft", "Top", "TopRight", "Right", "BottomRight", "Bottom", "BottomLeft", "Left", "Center"})
        colLSEffectStartPosition.Name = "colLSEffectStartPosition"
        ' 
        ' colLSEffectDirection
        ' 
        colLSEffectDirection.HeaderText = "colLSEffectDirection"
        colLSEffectDirection.Items.AddRange(New Object() {"UpLeft", "Up", "UpRight", "Right", "DownRight", "Down", "DownLeft", "Left"})
        colLSEffectDirection.Name = "colLSEffectDirection"
        ' 
        ' TabFrames
        ' 
        TabFrames.Controls.Add(DG_Frames)
        TabFrames.Location = New Point(4, 24)
        TabFrames.Name = "TabFrames"
        TabFrames.Size = New Size(1828, 789)
        TabFrames.TabIndex = 2
        TabFrames.Text = "Frames"
        TabFrames.UseVisualStyleBackColor = True
        ' 
        ' DG_Frames
        ' 
        DG_Frames.AllowUserToAddRows = False
        DG_Frames.AllowUserToDeleteRows = False
        DG_Frames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Frames.Columns.AddRange(New DataGridViewColumn() {colFrame_Id, colFrame_FixtureID, colFrame_Frames})
        DG_Frames.Dock = DockStyle.Fill
        DG_Frames.Location = New Point(0, 0)
        DG_Frames.Name = "DG_Frames"
        DG_Frames.Size = New Size(1828, 789)
        DG_Frames.TabIndex = 1
        ' 
        ' colFrame_Id
        ' 
        colFrame_Id.HeaderText = "ID"
        colFrame_Id.Name = "colFrame_Id"
        ' 
        ' colFrame_FixtureID
        ' 
        colFrame_FixtureID.HeaderText = "Fixture"
        colFrame_FixtureID.Name = "colFrame_FixtureID"
        ' 
        ' colFrame_Frames
        ' 
        colFrame_Frames.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colFrame_Frames.HeaderText = "Frames"
        colFrame_Frames.Name = "colFrame_Frames"
        ' 
        ' TabDevices
        ' 
        TabDevices.BackColor = Color.DimGray
        TabDevices.Controls.Add(SplitContainer_Devices)
        TabDevices.Controls.Add(RichTextBox1)
        TabDevices.Controls.Add(ToolStrip_Devices)
        TabDevices.Location = New Point(4, 24)
        TabDevices.Name = "TabDevices"
        TabDevices.Padding = New Padding(3)
        TabDevices.Size = New Size(1836, 849)
        TabDevices.TabIndex = 0
        TabDevices.Text = "Devices"
        ' 
        ' SplitContainer_Devices
        ' 
        SplitContainer_Devices.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        SplitContainer_Devices.Location = New Point(3, 63)
        SplitContainer_Devices.Name = "SplitContainer_Devices"
        SplitContainer_Devices.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer_Devices.Panel1
        ' 
        SplitContainer_Devices.Panel1.Controls.Add(DG_Devices)
        ' 
        ' SplitContainer_Devices.Panel2
        ' 
        SplitContainer_Devices.Panel2.AutoScroll = True
        SplitContainer_Devices.Size = New Size(1827, 786)
        SplitContainer_Devices.SplitterDistance = 393
        SplitContainer_Devices.TabIndex = 4
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        RichTextBox1.BackColor = Color.DimGray
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Location = New Point(3, 31)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ReadOnly = True
        RichTextBox1.Size = New Size(1463, 32)
        RichTextBox1.TabIndex = 3
        RichTextBox1.Text = "Hier vindt u de gevonden WLED devices. Door op het veld IP-adrdess te klikken opent u de directe interface van dat apparaat. " & vbLf & "Een WLED device kan meerdere segmenten hebben."
        ' 
        ' ToolStrip_Devices
        ' 
        ToolStrip_Devices.BackColor = Color.MidnightBlue
        ToolStrip_Devices.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolStrip_Devices.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip_Devices.Items.AddRange(New ToolStripItem() {LblDeviceStatus, btnScanNetworkForWLed, btnDevicesRefreshIPs, btnSendUpdatedSegmentsToWLED, btnPingDevice, btnDeleteDevice, btnAddDevice, ToolStripSeparator4, btnGenerateStage, btnGenerateSliders})
        ToolStrip_Devices.Location = New Point(3, 3)
        ToolStrip_Devices.Name = "ToolStrip_Devices"
        ToolStrip_Devices.Size = New Size(1830, 25)
        ToolStrip_Devices.TabIndex = 2
        ToolStrip_Devices.Text = "ToolStrip_Devices"
        ' 
        ' LblDeviceStatus
        ' 
        LblDeviceStatus.Alignment = ToolStripItemAlignment.Right
        LblDeviceStatus.Name = "LblDeviceStatus"
        LblDeviceStatus.Size = New Size(0, 22)
        ' 
        ' btnScanNetworkForWLed
        ' 
        btnScanNetworkForWLed.BackColor = Color.Transparent
        btnScanNetworkForWLed.ForeColor = Color.White
        btnScanNetworkForWLed.Image = My.Resources.Resources.iconScanNetwork_21
        btnScanNetworkForWLed.ImageTransparentColor = Color.Magenta
        btnScanNetworkForWLed.Name = "btnScanNetworkForWLed"
        btnScanNetworkForWLed.Size = New Size(192, 22)
        btnScanNetworkForWLed.Text = "Scan network for WLED devices"
        ' 
        ' btnDevicesRefreshIPs
        ' 
        btnDevicesRefreshIPs.ForeColor = SystemColors.ButtonFace
        btnDevicesRefreshIPs.Image = My.Resources.Resources.iconTime
        btnDevicesRefreshIPs.ImageTransparentColor = Color.Magenta
        btnDevicesRefreshIPs.Name = "btnDevicesRefreshIPs"
        btnDevicesRefreshIPs.Size = New Size(87, 22)
        btnDevicesRefreshIPs.Text = "Refresh IP's"
        ' 
        ' btnSendUpdatedSegmentsToWLED
        ' 
        btnSendUpdatedSegmentsToWLED.ForeColor = SystemColors.ControlLightLight
        btnSendUpdatedSegmentsToWLED.Image = CType(resources.GetObject("btnSendUpdatedSegmentsToWLED.Image"), Image)
        btnSendUpdatedSegmentsToWLED.ImageTransparentColor = Color.Magenta
        btnSendUpdatedSegmentsToWLED.Name = "btnSendUpdatedSegmentsToWLED"
        btnSendUpdatedSegmentsToWLED.Size = New Size(153, 22)
        btnSendUpdatedSegmentsToWLED.Text = "Update WLED segments"
        ' 
        ' btnPingDevice
        ' 
        btnPingDevice.ForeColor = SystemColors.ControlLightLight
        btnPingDevice.Image = My.Resources.Resources.iconPing
        btnPingDevice.ImageTransparentColor = Color.Magenta
        btnPingDevice.Name = "btnPingDevice"
        btnPingDevice.Size = New Size(51, 22)
        btnPingDevice.Text = "Ping"
        ' 
        ' btnDeleteDevice
        ' 
        btnDeleteDevice.Alignment = ToolStripItemAlignment.Right
        btnDeleteDevice.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnDeleteDevice.Image = CType(resources.GetObject("btnDeleteDevice.Image"), Image)
        btnDeleteDevice.ImageTransparentColor = Color.Magenta
        btnDeleteDevice.Name = "btnDeleteDevice"
        btnDeleteDevice.Size = New Size(23, 22)
        btnDeleteDevice.Text = "Delete device"
        ' 
        ' btnAddDevice
        ' 
        btnAddDevice.Alignment = ToolStripItemAlignment.Right
        btnAddDevice.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnAddDevice.Image = CType(resources.GetObject("btnAddDevice.Image"), Image)
        btnAddDevice.ImageTransparentColor = Color.Magenta
        btnAddDevice.Name = "btnAddDevice"
        btnAddDevice.Size = New Size(23, 22)
        btnAddDevice.Text = "Insert device"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(6, 25)
        ' 
        ' btnGenerateStage
        ' 
        btnGenerateStage.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnGenerateStage.ForeColor = SystemColors.ButtonFace
        btnGenerateStage.Image = CType(resources.GetObject("btnGenerateStage.Image"), Image)
        btnGenerateStage.ImageTransparentColor = Color.Magenta
        btnGenerateStage.Name = "btnGenerateStage"
        btnGenerateStage.Size = New Size(89, 22)
        btnGenerateStage.Text = "Generate stage"
        ' 
        ' btnGenerateSliders
        ' 
        btnGenerateSliders.ForeColor = SystemColors.ControlLightLight
        btnGenerateSliders.Image = My.Resources.Resources.iconDMXslider
        btnGenerateSliders.ImageTransparentColor = Color.Magenta
        btnGenerateSliders.Name = "btnGenerateSliders"
        btnGenerateSliders.Size = New Size(89, 22)
        btnGenerateSliders.Text = "DMX sliders"
        ' 
        ' TabGroups
        ' 
        TabGroups.Controls.Add(RichTextBox4)
        TabGroups.Controls.Add(ToolStripGroups)
        TabGroups.Controls.Add(DG_Groups)
        TabGroups.Location = New Point(4, 24)
        TabGroups.Name = "TabGroups"
        TabGroups.Padding = New Padding(3)
        TabGroups.Size = New Size(1836, 849)
        TabGroups.TabIndex = 8
        TabGroups.Text = "Groups"
        TabGroups.UseVisualStyleBackColor = True
        ' 
        ' RichTextBox4
        ' 
        RichTextBox4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        RichTextBox4.BackColor = Color.DimGray
        RichTextBox4.BorderStyle = BorderStyle.None
        RichTextBox4.Location = New Point(3, 31)
        RichTextBox4.Name = "RichTextBox4"
        RichTextBox4.ReadOnly = True
        RichTextBox4.Size = New Size(1830, 32)
        RichTextBox4.TabIndex = 4
        RichTextBox4.Text = "U kunt hier groepen aanmaken. Elke groep kan 1 of meerdere leds bevatten van 1 of meerdere devices."
        ' 
        ' ToolStripGroups
        ' 
        ToolStripGroups.BackColor = Color.MidnightBlue
        ToolStripGroups.GripStyle = ToolStripGripStyle.Hidden
        ToolStripGroups.Items.AddRange(New ToolStripItem() {btnGroupDeleteRow, btnGroupAddRowBefore, btnGroupAddRowAfter, btnGroupsAutoSplit, btnGroupDMXSlider})
        ToolStripGroups.Location = New Point(3, 3)
        ToolStripGroups.Name = "ToolStripGroups"
        ToolStripGroups.Size = New Size(1830, 25)
        ToolStripGroups.TabIndex = 1
        ToolStripGroups.Text = "DMS Slider"
        ' 
        ' btnGroupDeleteRow
        ' 
        btnGroupDeleteRow.Alignment = ToolStripItemAlignment.Right
        btnGroupDeleteRow.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnGroupDeleteRow.Image = My.Resources.Resources.iconRowDelete
        btnGroupDeleteRow.ImageTransparentColor = Color.Magenta
        btnGroupDeleteRow.Name = "btnGroupDeleteRow"
        btnGroupDeleteRow.Size = New Size(23, 22)
        btnGroupDeleteRow.Text = "Remove row"
        ' 
        ' btnGroupAddRowBefore
        ' 
        btnGroupAddRowBefore.Alignment = ToolStripItemAlignment.Right
        btnGroupAddRowBefore.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnGroupAddRowBefore.Image = My.Resources.Resources.iconRowAddBefore
        btnGroupAddRowBefore.ImageTransparentColor = Color.Magenta
        btnGroupAddRowBefore.Name = "btnGroupAddRowBefore"
        btnGroupAddRowBefore.Size = New Size(23, 22)
        btnGroupAddRowBefore.Text = "Add row before"
        ' 
        ' btnGroupAddRowAfter
        ' 
        btnGroupAddRowAfter.Alignment = ToolStripItemAlignment.Right
        btnGroupAddRowAfter.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnGroupAddRowAfter.Image = My.Resources.Resources.iconRowAddAfter
        btnGroupAddRowAfter.ImageTransparentColor = Color.Magenta
        btnGroupAddRowAfter.Name = "btnGroupAddRowAfter"
        btnGroupAddRowAfter.Size = New Size(23, 22)
        btnGroupAddRowAfter.Text = "Add row after"
        ' 
        ' btnGroupsAutoSplit
        ' 
        btnGroupsAutoSplit.ForeColor = SystemColors.ButtonFace
        btnGroupsAutoSplit.Image = CType(resources.GetObject("btnGroupsAutoSplit.Image"), Image)
        btnGroupsAutoSplit.ImageTransparentColor = Color.Magenta
        btnGroupsAutoSplit.Name = "btnGroupsAutoSplit"
        btnGroupsAutoSplit.Size = New Size(79, 22)
        btnGroupsAutoSplit.Text = "Auto Split"
        ' 
        ' btnGroupDMXSlider
        ' 
        btnGroupDMXSlider.ForeColor = SystemColors.ButtonFace
        btnGroupDMXSlider.Image = My.Resources.Resources.iconDMXslider
        btnGroupDMXSlider.ImageTransparentColor = Color.Magenta
        btnGroupDMXSlider.Name = "btnGroupDMXSlider"
        btnGroupDMXSlider.Size = New Size(84, 22)
        btnGroupDMXSlider.Text = "DMX slider"
        ' 
        ' DG_Groups
        ' 
        DG_Groups.AllowUserToAddRows = False
        DG_Groups.AllowUserToDeleteRows = False
        DG_Groups.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DG_Groups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Groups.Columns.AddRange(New DataGridViewColumn() {colGroupId, colGroupParentId, colGroupName, colGroupFixture, colGroupSegment, colGroupStartLedNr, colGroupStopLedNr, colGroupOrder, colAllFrames, colActiveFrame, colGroupRepeat, colGroupLayout})
        DG_Groups.Location = New Point(3, 69)
        DG_Groups.Name = "DG_Groups"
        DG_Groups.RowHeadersWidth = 11
        DG_Groups.Size = New Size(1830, 774)
        DG_Groups.TabIndex = 0
        ' 
        ' colGroupId
        ' 
        colGroupId.HeaderText = "ID"
        colGroupId.Name = "colGroupId"
        colGroupId.Width = 50
        ' 
        ' colGroupParentId
        ' 
        colGroupParentId.HeaderText = "Parent"
        colGroupParentId.Name = "colGroupParentId"
        colGroupParentId.Width = 50
        ' 
        ' colGroupName
        ' 
        colGroupName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colGroupName.HeaderText = "Groupname"
        colGroupName.Name = "colGroupName"
        ' 
        ' colGroupFixture
        ' 
        colGroupFixture.HeaderText = "Fixture"
        colGroupFixture.Name = "colGroupFixture"
        colGroupFixture.Width = 300
        ' 
        ' colGroupSegment
        ' 
        colGroupSegment.HeaderText = "Segment"
        colGroupSegment.Name = "colGroupSegment"
        colGroupSegment.Width = 300
        ' 
        ' colGroupStartLedNr
        ' 
        colGroupStartLedNr.HeaderText = "Start Led"
        colGroupStartLedNr.Name = "colGroupStartLedNr"
        ' 
        ' colGroupStopLedNr
        ' 
        colGroupStopLedNr.HeaderText = "Stop Led"
        colGroupStopLedNr.Name = "colGroupStopLedNr"
        ' 
        ' colGroupOrder
        ' 
        colGroupOrder.HeaderText = "Order"
        colGroupOrder.Name = "colGroupOrder"
        ' 
        ' colAllFrames
        ' 
        colAllFrames.HeaderText = "Frames"
        colAllFrames.Name = "colAllFrames"
        ' 
        ' colActiveFrame
        ' 
        colActiveFrame.HeaderText = "ActiveFrame"
        colActiveFrame.Name = "colActiveFrame"
        ' 
        ' colGroupRepeat
        ' 
        colGroupRepeat.HeaderText = "Repeat"
        colGroupRepeat.Name = "colGroupRepeat"
        ' 
        ' colGroupLayout
        ' 
        colGroupLayout.HeaderText = "Layout"
        colGroupLayout.Name = "colGroupLayout"
        ' 
        ' TabEffects
        ' 
        TabEffects.BackColor = Color.DimGray
        TabEffects.Controls.Add(ToolStrip_Effecten)
        TabEffects.Controls.Add(RichTextBox2)
        TabEffects.Controls.Add(DG_Effecten)
        TabEffects.Location = New Point(4, 24)
        TabEffects.Name = "TabEffects"
        TabEffects.Padding = New Padding(3)
        TabEffects.Size = New Size(1836, 849)
        TabEffects.TabIndex = 1
        TabEffects.Text = "Effecten"
        ' 
        ' ToolStrip_Effecten
        ' 
        ToolStrip_Effecten.BackColor = Color.MidnightBlue
        ToolStrip_Effecten.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip_Effecten.Items.AddRange(New ToolStripItem() {btnRebuildDGEffects, btnTestExistanceEffects})
        ToolStrip_Effecten.Location = New Point(3, 3)
        ToolStrip_Effecten.Name = "ToolStrip_Effecten"
        ToolStrip_Effecten.Size = New Size(1830, 25)
        ToolStrip_Effecten.TabIndex = 4
        ToolStrip_Effecten.Text = "ToolStrip2"
        ' 
        ' btnRebuildDGEffects
        ' 
        btnRebuildDGEffects.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnRebuildDGEffects.ForeColor = SystemColors.ControlLightLight
        btnRebuildDGEffects.Image = CType(resources.GetObject("btnRebuildDGEffects.Image"), Image)
        btnRebuildDGEffects.ImageTransparentColor = Color.Magenta
        btnRebuildDGEffects.Name = "btnRebuildDGEffects"
        btnRebuildDGEffects.Size = New Size(51, 22)
        btnRebuildDGEffects.Text = "Rebuild"
        ' 
        ' btnTestExistanceEffects
        ' 
        btnTestExistanceEffects.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnTestExistanceEffects.ForeColor = SystemColors.ControlLightLight
        btnTestExistanceEffects.Image = CType(resources.GetObject("btnTestExistanceEffects.Image"), Image)
        btnTestExistanceEffects.ImageTransparentColor = Color.Magenta
        btnTestExistanceEffects.Name = "btnTestExistanceEffects"
        btnTestExistanceEffects.Size = New Size(35, 22)
        btnTestExistanceEffects.Text = "Test "
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        RichTextBox2.BackColor = Color.DimGray
        RichTextBox2.BorderStyle = BorderStyle.None
        RichTextBox2.Location = New Point(3, 31)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.ReadOnly = True
        RichTextBox2.Size = New Size(1463, 34)
        RichTextBox2.TabIndex = 3
        RichTextBox2.Text = "Hier vindt u de beschikbare effecten die een specifieke WLED aan kan. " & vbLf & "U kunt het effect toepassen op het eerste segment door op het checkbox te dubbelklikken."
        ' 
        ' TabPaletten
        ' 
        TabPaletten.BackColor = Color.DimGray
        TabPaletten.Controls.Add(RichTextBox3)
        TabPaletten.Controls.Add(ToolStrip_Paletten)
        TabPaletten.Controls.Add(DG_Paletten)
        TabPaletten.Location = New Point(4, 24)
        TabPaletten.Name = "TabPaletten"
        TabPaletten.Padding = New Padding(3)
        TabPaletten.Size = New Size(1836, 849)
        TabPaletten.TabIndex = 3
        TabPaletten.Text = "Paletten"
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        RichTextBox3.BackColor = Color.DimGray
        RichTextBox3.BorderStyle = BorderStyle.None
        RichTextBox3.Location = New Point(3, 31)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.ReadOnly = True
        RichTextBox3.Size = New Size(1463, 29)
        RichTextBox3.TabIndex = 2
        RichTextBox3.Text = "Hier vindt u de beschikbare pallet met kleuren die toegepast kunnen worden. Door op een vinkje te klikken past u het palette toe op het eerste segment van dat WLED device."
        ' 
        ' ToolStrip_Paletten
        ' 
        ToolStrip_Paletten.BackColor = Color.MidnightBlue
        ToolStrip_Paletten.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip_Paletten.Items.AddRange(New ToolStripItem() {btnRebuildDGPalettes, ToolStripButton1})
        ToolStrip_Paletten.Location = New Point(3, 3)
        ToolStrip_Paletten.Name = "ToolStrip_Paletten"
        ToolStrip_Paletten.Size = New Size(1830, 25)
        ToolStrip_Paletten.TabIndex = 1
        ToolStrip_Paletten.Text = "ToolStrip1"
        ' 
        ' btnRebuildDGPalettes
        ' 
        btnRebuildDGPalettes.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnRebuildDGPalettes.ForeColor = SystemColors.ControlLightLight
        btnRebuildDGPalettes.Image = CType(resources.GetObject("btnRebuildDGPalettes.Image"), Image)
        btnRebuildDGPalettes.ImageTransparentColor = Color.Magenta
        btnRebuildDGPalettes.Name = "btnRebuildDGPalettes"
        btnRebuildDGPalettes.Size = New Size(51, 22)
        btnRebuildDGPalettes.Text = "Rebuild"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text
        ToolStripButton1.ForeColor = SystemColors.ControlLightLight
        ToolStripButton1.Image = My.Resources.Resources.iconBlackBullet1
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(32, 22)
        ToolStripButton1.Text = "Test"
        ' 
        ' DG_Paletten
        ' 
        DG_Paletten.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DG_Paletten.BackgroundColor = Color.DimGray
        DG_Paletten.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Paletten.Location = New Point(6, 66)
        DG_Paletten.Name = "DG_Paletten"
        DG_Paletten.RowHeadersWidth = 10
        DG_Paletten.Size = New Size(1827, 780)
        DG_Paletten.TabIndex = 0
        ' 
        ' TabSettings
        ' 
        TabSettings.BackColor = Color.DimGray
        TabSettings.Controls.Add(GroupBox8)
        TabSettings.Controls.Add(GroupBox4)
        TabSettings.Controls.Add(GroupBox2)
        TabSettings.Controls.Add(GroupBox1)
        TabSettings.Location = New Point(4, 24)
        TabSettings.Name = "TabSettings"
        TabSettings.Padding = New Padding(3)
        TabSettings.Size = New Size(1836, 849)
        TabSettings.TabIndex = 4
        TabSettings.Text = "Settings"
        ' 
        ' GroupBox8
        ' 
        GroupBox8.Controls.Add(btn_ScriptPDF)
        GroupBox8.Controls.Add(settings_ScriptPDF)
        GroupBox8.Controls.Add(Label4)
        GroupBox8.Controls.Add(Label14)
        GroupBox8.Controls.Add(settings_DDPPort)
        GroupBox8.Controls.Add(settings_EffectsPath)
        GroupBox8.Controls.Add(Label11)
        GroupBox8.Controls.Add(settings_PalettesPath)
        GroupBox8.Controls.Add(Label10)
        GroupBox8.Controls.Add(settings_ProjectName)
        GroupBox8.Controls.Add(Label6)
        GroupBox8.Controls.Add(btnProjectFolder)
        GroupBox8.Controls.Add(settings_ProjectFolder)
        GroupBox8.Controls.Add(Label5)
        GroupBox8.ForeColor = Color.MidnightBlue
        GroupBox8.Location = New Point(8, 206)
        GroupBox8.Name = "GroupBox8"
        GroupBox8.Size = New Size(338, 210)
        GroupBox8.TabIndex = 7
        GroupBox8.TabStop = False
        GroupBox8.Text = "Project settings"
        ' 
        ' btn_ScriptPDF
        ' 
        btn_ScriptPDF.Location = New Point(310, 179)
        btn_ScriptPDF.Name = "btn_ScriptPDF"
        btn_ScriptPDF.Size = New Size(24, 23)
        btn_ScriptPDF.TabIndex = 8
        btn_ScriptPDF.Text = ".."
        btn_ScriptPDF.UseVisualStyleBackColor = True
        ' 
        ' settings_ScriptPDF
        ' 
        settings_ScriptPDF.Location = New Point(132, 179)
        settings_ScriptPDF.Name = "settings_ScriptPDF"
        settings_ScriptPDF.Size = New Size(178, 23)
        settings_ScriptPDF.TabIndex = 13
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(6, 182)
        Label4.Name = "Label4"
        Label4.Size = New Size(61, 15)
        Label4.TabIndex = 12
        Label4.Text = "PDF Script"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.ForeColor = Color.Black
        Label14.Location = New Point(6, 156)
        Label14.Name = "Label14"
        Label14.Size = New Size(55, 15)
        Label14.TabIndex = 11
        Label14.Text = "DDP Port"
        ' 
        ' settings_DDPPort
        ' 
        settings_DDPPort.Location = New Point(132, 151)
        settings_DDPPort.Name = "settings_DDPPort"
        settings_DDPPort.Size = New Size(200, 23)
        settings_DDPPort.TabIndex = 9
        ' 
        ' settings_EffectsPath
        ' 
        settings_EffectsPath.Location = New Point(133, 123)
        settings_EffectsPath.Name = "settings_EffectsPath"
        settings_EffectsPath.Size = New Size(199, 23)
        settings_EffectsPath.TabIndex = 8
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.ForeColor = Color.Black
        Label11.Location = New Point(6, 126)
        Label11.Name = "Label11"
        Label11.Size = New Size(72, 15)
        Label11.TabIndex = 7
        Label11.Text = "Effect's path"
        ' 
        ' settings_PalettesPath
        ' 
        settings_PalettesPath.Location = New Point(133, 94)
        settings_PalettesPath.Name = "settings_PalettesPath"
        settings_PalettesPath.Size = New Size(199, 23)
        settings_PalettesPath.TabIndex = 6
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.ForeColor = Color.Black
        Label10.Location = New Point(6, 97)
        Label10.Name = "Label10"
        Label10.Size = New Size(78, 15)
        Label10.TabIndex = 5
        Label10.Text = "Palette's path"
        ' 
        ' settings_ProjectName
        ' 
        settings_ProjectName.Location = New Point(133, 45)
        settings_ProjectName.Name = "settings_ProjectName"
        settings_ProjectName.Size = New Size(199, 23)
        settings_ProjectName.TabIndex = 4
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(6, 48)
        Label6.Name = "Label6"
        Label6.Size = New Size(77, 15)
        Label6.TabIndex = 3
        Label6.Text = "Projectname:"
        ' 
        ' btnProjectFolder
        ' 
        btnProjectFolder.Location = New Point(310, 16)
        btnProjectFolder.Name = "btnProjectFolder"
        btnProjectFolder.Size = New Size(22, 23)
        btnProjectFolder.TabIndex = 2
        btnProjectFolder.Text = ".."
        btnProjectFolder.UseVisualStyleBackColor = True
        ' 
        ' settings_ProjectFolder
        ' 
        settings_ProjectFolder.Location = New Point(133, 16)
        settings_ProjectFolder.Name = "settings_ProjectFolder"
        settings_ProjectFolder.Size = New Size(177, 23)
        settings_ProjectFolder.TabIndex = 1
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(6, 20)
        Label5.Name = "Label5"
        Label5.Size = New Size(78, 15)
        Label5.TabIndex = 0
        Label5.Text = "Projectfolder:"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox4.Controls.Add(txt_APIResult)
        GroupBox4.ForeColor = Color.MidnightBlue
        GroupBox4.Location = New Point(352, 6)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(1114, 100)
        GroupBox4.TabIndex = 5
        GroupBox4.TabStop = False
        GroupBox4.Text = "Logging / Last status"
        ' 
        ' txt_APIResult
        ' 
        txt_APIResult.Dock = DockStyle.Fill
        txt_APIResult.Location = New Point(3, 19)
        txt_APIResult.Multiline = True
        txt_APIResult.Name = "txt_APIResult"
        txt_APIResult.Size = New Size(1108, 78)
        txt_APIResult.TabIndex = 4
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(pbSecondaryStatus)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(pbPrimaryStatus)
        GroupBox2.Controls.Add(cbMonitorSecond)
        GroupBox2.Controls.Add(pbControlStatus)
        GroupBox2.Controls.Add(cbMonitorPrime)
        GroupBox2.Controls.Add(cbMonitorControl)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(lblShowMonitor)
        GroupBox2.ForeColor = Color.MidnightBlue
        GroupBox2.Location = New Point(8, 65)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(338, 135)
        GroupBox2.TabIndex = 2
        GroupBox2.TabStop = False
        GroupBox2.Text = "Monitors"
        ' 
        ' pbSecondaryStatus
        ' 
        pbSecondaryStatus.Image = My.Resources.Resources.iconRedBullet1
        pbSecondaryStatus.Location = New Point(310, 103)
        pbSecondaryStatus.Name = "pbSecondaryStatus"
        pbSecondaryStatus.Size = New Size(22, 22)
        pbSecondaryStatus.TabIndex = 5
        pbSecondaryStatus.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(133, 41)
        Label1.Name = "Label1"
        Label1.Size = New Size(189, 15)
        Label1.TabIndex = 6
        Label1.Text = "You need to restart after changing."
        ' 
        ' pbPrimaryStatus
        ' 
        pbPrimaryStatus.Image = My.Resources.Resources.iconRedBullet1
        pbPrimaryStatus.Location = New Point(310, 75)
        pbPrimaryStatus.Name = "pbPrimaryStatus"
        pbPrimaryStatus.Size = New Size(22, 22)
        pbPrimaryStatus.TabIndex = 4
        pbPrimaryStatus.TabStop = False
        ' 
        ' cbMonitorSecond
        ' 
        cbMonitorSecond.FormattingEnabled = True
        cbMonitorSecond.Items.AddRange(New Object() {"Output 1", "Output 2", "Output 3"})
        cbMonitorSecond.Location = New Point(133, 102)
        cbMonitorSecond.Name = "cbMonitorSecond"
        cbMonitorSecond.Size = New Size(177, 23)
        cbMonitorSecond.TabIndex = 5
        ' 
        ' pbControlStatus
        ' 
        pbControlStatus.Image = My.Resources.Resources.iconRedBullet1
        pbControlStatus.Location = New Point(310, 16)
        pbControlStatus.Name = "pbControlStatus"
        pbControlStatus.Size = New Size(22, 22)
        pbControlStatus.TabIndex = 3
        pbControlStatus.TabStop = False
        ' 
        ' cbMonitorPrime
        ' 
        cbMonitorPrime.FormattingEnabled = True
        cbMonitorPrime.Items.AddRange(New Object() {"Output 1", "Output 2", "Output 3"})
        cbMonitorPrime.Location = New Point(133, 74)
        cbMonitorPrime.Name = "cbMonitorPrime"
        cbMonitorPrime.Size = New Size(177, 23)
        cbMonitorPrime.TabIndex = 4
        ' 
        ' cbMonitorControl
        ' 
        cbMonitorControl.FormattingEnabled = True
        cbMonitorControl.Items.AddRange(New Object() {"Output 1", "Output 2", "Output 3"})
        cbMonitorControl.Location = New Point(133, 15)
        cbMonitorControl.Name = "cbMonitorControl"
        cbMonitorControl.Size = New Size(177, 23)
        cbMonitorControl.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(6, 105)
        Label3.Name = "Label3"
        Label3.Size = New Size(108, 15)
        Label3.TabIndex = 2
        Label3.Text = "Secondairy beamer"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(6, 77)
        Label2.Name = "Label2"
        Label2.Size = New Size(91, 15)
        Label2.TabIndex = 1
        Label2.Text = "Primary beamer"
        ' 
        ' lblShowMonitor
        ' 
        lblShowMonitor.AutoSize = True
        lblShowMonitor.ForeColor = Color.Black
        lblShowMonitor.Location = New Point(6, 18)
        lblShowMonitor.Name = "lblShowMonitor"
        lblShowMonitor.Size = New Size(107, 15)
        lblShowMonitor.TabIndex = 0
        lblShowMonitor.Text = "Show controller on"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtIPRange)
        GroupBox1.Controls.Add(lblIPRange)
        GroupBox1.ForeColor = Color.MidnightBlue
        GroupBox1.Location = New Point(8, 6)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(338, 53)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Network"
        ' 
        ' txtIPRange
        ' 
        txtIPRange.Location = New Point(133, 16)
        txtIPRange.Name = "txtIPRange"
        txtIPRange.ReadOnly = True
        txtIPRange.Size = New Size(199, 23)
        txtIPRange.TabIndex = 1
        ' 
        ' lblIPRange
        ' 
        lblIPRange.AutoSize = True
        lblIPRange.ForeColor = Color.Black
        lblIPRange.Location = New Point(6, 19)
        lblIPRange.Name = "lblIPRange"
        lblIPRange.Size = New Size(55, 15)
        lblIPRange.TabIndex = 0
        lblIPRange.Text = "IP-Range"
        ' 
        ' ToolStrip_Form
        ' 
        ToolStrip_Form.BackColor = Color.LightGray
        ToolStrip_Form.Dock = DockStyle.Bottom
        ToolStrip_Form.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip_Form.Items.AddRange(New ToolStripItem() {btnSaveShow, ToolStripLabel1, btnLoadAll})
        ToolStrip_Form.Location = New Point(0, 957)
        ToolStrip_Form.Name = "ToolStrip_Form"
        ToolStrip_Form.Size = New Size(1844, 25)
        ToolStrip_Form.TabIndex = 5
        ToolStrip_Form.Text = "ToolStrip_General"
        ' 
        ' btnSaveShow
        ' 
        btnSaveShow.Alignment = ToolStripItemAlignment.Right
        btnSaveShow.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnSaveShow.Image = CType(resources.GetObject("btnSaveShow.Image"), Image)
        btnSaveShow.ImageTransparentColor = Color.Magenta
        btnSaveShow.Name = "btnSaveShow"
        btnSaveShow.Size = New Size(35, 22)
        btnSaveShow.Text = "Save"
        btnSaveShow.ToolTipText = "Save"
        ' 
        ' ToolStripLabel1
        ' 
        ToolStripLabel1.Name = "ToolStripLabel1"
        ToolStripLabel1.Size = New Size(0, 22)
        ' 
        ' btnLoadAll
        ' 
        btnLoadAll.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnLoadAll.Image = CType(resources.GetObject("btnLoadAll.Image"), Image)
        btnLoadAll.ImageTransparentColor = Color.Magenta
        btnLoadAll.Name = "btnLoadAll"
        btnLoadAll.Size = New Size(37, 22)
        btnLoadAll.Text = "Load"
        ' 
        ' TimerEverySecond
        ' 
        TimerEverySecond.Enabled = True
        TimerEverySecond.Interval = 1000
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
        PictureBox1.Image = My.Resources.Resources.logo_kklt_inverted1
        PictureBox1.Location = New Point(1693, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(151, 94)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 6
        PictureBox1.TabStop = False
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.AddExtension = False
        OpenFileDialog1.AddToRecent = False
        OpenFileDialog1.CheckFileExists = False
        OpenFileDialog1.CheckPathExists = False
        OpenFileDialog1.FileName = "OpenFileDialog1"
        OpenFileDialog1.Title = "Projectfolder"
        ' 
        ' lblTitleProject
        ' 
        lblTitleProject.AutoSize = True
        lblTitleProject.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitleProject.ForeColor = Color.Gold
        lblTitleProject.Location = New Point(10, 8)
        lblTitleProject.Name = "lblTitleProject"
        lblTitleProject.Size = New Size(27, 25)
        lblTitleProject.TabIndex = 7
        lblTitleProject.Text = "..."
        ' 
        ' lblCurrentTime
        ' 
        lblCurrentTime.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblCurrentTime.AutoSize = True
        lblCurrentTime.Font = New Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCurrentTime.ForeColor = Color.White
        lblCurrentTime.Location = New Point(1483, 8)
        lblCurrentTime.Name = "lblCurrentTime"
        lblCurrentTime.Size = New Size(204, 65)
        lblCurrentTime.TabIndex = 8
        lblCurrentTime.Text = "00:00:00"
        ' 
        ' TimerNextEvent
        ' 
        ' 
        ' TimerPingDevices
        ' 
        TimerPingDevices.Enabled = True
        TimerPingDevices.Interval = 60000
        ' 
        ' ddpTimer
        ' 
        ddpTimer.Enabled = True
        ' 
        ' stageTimer
        ' 
        stageTimer.Enabled = True
        stageTimer.Interval = 500
        ' 
        ' btnApply
        ' 
        btnApply.HeaderText = "Apply"
        btnApply.Name = "btnApply"
        btnApply.Resizable = DataGridViewTriState.False
        btnApply.Text = ">>>"
        btnApply.Width = 25
        ' 
        ' colAct
        ' 
        colAct.HeaderText = "Act"
        colAct.Items.AddRange(New Object() {"Pre-Show", "Act 1", "Pauze", "Act 2", "Act 3", "Post-Show"})
        colAct.Name = "colAct"
        colAct.Resizable = DataGridViewTriState.True
        colAct.SortMode = DataGridViewColumnSortMode.Automatic
        colAct.ToolTipText = "De hoofdindeling van de show. "
        colAct.Width = 50
        ' 
        ' colSceneId
        ' 
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        colSceneId.DefaultCellStyle = DataGridViewCellStyle1
        colSceneId.HeaderText = "Scene"
        colSceneId.Name = "colSceneId"
        colSceneId.ToolTipText = "Scene nummer van de show"
        colSceneId.Width = 50
        ' 
        ' colEventId
        ' 
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        colEventId.DefaultCellStyle = DataGridViewCellStyle2
        colEventId.HeaderText = "Event"
        colEventId.Name = "colEventId"
        colEventId.ToolTipText = "Het event nummer binnen een scene."
        colEventId.Width = 50
        ' 
        ' colTimer
        ' 
        colTimer.HeaderText = "Timer"
        colTimer.Name = "colTimer"
        colTimer.ToolTipText = "Aantal msec voordat we naar volgende event gaan."
        colTimer.Width = 50
        ' 
        ' colCue
        ' 
        colCue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colCue.HeaderText = "Cue"
        colCue.Name = "colCue"
        colCue.ToolTipText = "Wanneer is de overgang?"
        ' 
        ' colFixture
        ' 
        colFixture.HeaderText = "Device/Segment"
        colFixture.Name = "colFixture"
        colFixture.Resizable = DataGridViewTriState.True
        colFixture.SortMode = DataGridViewColumnSortMode.Automatic
        ' 
        ' colStateOnOff
        ' 
        colStateOnOff.HeaderText = "Aan/Uit"
        colStateOnOff.Items.AddRange(New Object() {"Aan", "Uit"})
        colStateOnOff.Name = "colStateOnOff"
        colStateOnOff.Width = 50
        ' 
        ' colEffectId
        ' 
        colEffectId.FillWeight = 25F
        colEffectId.HeaderText = "ID"
        colEffectId.Name = "colEffectId"
        colEffectId.Visible = False
        colEffectId.Width = 25
        ' 
        ' colEffect
        ' 
        colEffect.HeaderText = "Effect"
        colEffect.Name = "colEffect"
        colEffect.Resizable = DataGridViewTriState.True
        colEffect.SortMode = DataGridViewColumnSortMode.Automatic
        ' 
        ' colPaletteId
        ' 
        colPaletteId.FillWeight = 25F
        colPaletteId.HeaderText = "ID"
        colPaletteId.Name = "colPaletteId"
        colPaletteId.Visible = False
        colPaletteId.Width = 25
        ' 
        ' colPalette
        ' 
        colPalette.HeaderText = "Palette"
        colPalette.Name = "colPalette"
        colPalette.Resizable = DataGridViewTriState.True
        colPalette.SortMode = DataGridViewColumnSortMode.Automatic
        ' 
        ' colColor1
        ' 
        colColor1.HeaderText = "Kleur 1"
        colColor1.Name = "colColor1"
        colColor1.Visible = False
        colColor1.Width = 50
        ' 
        ' colColor2
        ' 
        colColor2.HeaderText = "Kleur 2"
        colColor2.Name = "colColor2"
        colColor2.Visible = False
        colColor2.Width = 50
        ' 
        ' colColor3
        ' 
        colColor3.HeaderText = "Kleur 3"
        colColor3.Name = "colColor3"
        colColor3.Visible = False
        colColor3.Width = 50
        ' 
        ' colBrightness
        ' 
        colBrightness.HeaderText = "Brightness"
        colBrightness.Name = "colBrightness"
        colBrightness.Visible = False
        colBrightness.Width = 50
        ' 
        ' colSpeed
        ' 
        colSpeed.HeaderText = "Snelheid"
        colSpeed.Name = "colSpeed"
        colSpeed.Visible = False
        colSpeed.Width = 50
        ' 
        ' colIntensity
        ' 
        colIntensity.HeaderText = "Intensiteit"
        colIntensity.Name = "colIntensity"
        colIntensity.Visible = False
        colIntensity.Width = 50
        ' 
        ' colTransition
        ' 
        colTransition.HeaderText = "Transition"
        colTransition.Name = "colTransition"
        colTransition.Visible = False
        colTransition.Width = 50
        ' 
        ' colBlend
        ' 
        colBlend.HeaderText = "Blend"
        colBlend.Name = "colBlend"
        colBlend.Resizable = DataGridViewTriState.True
        colBlend.SortMode = DataGridViewColumnSortMode.Automatic
        colBlend.Visible = False
        colBlend.Width = 50
        ' 
        ' colRepeat
        ' 
        colRepeat.HeaderText = "Repeat"
        colRepeat.Name = "colRepeat"
        colRepeat.Resizable = DataGridViewTriState.True
        colRepeat.SortMode = DataGridViewColumnSortMode.Automatic
        colRepeat.Width = 50
        ' 
        ' colSound
        ' 
        colSound.HeaderText = "Geluid"
        colSound.Name = "colSound"
        colSound.Resizable = DataGridViewTriState.True
        colSound.SortMode = DataGridViewColumnSortMode.Automatic
        colSound.Width = 50
        ' 
        ' colFilename
        ' 
        colFilename.HeaderText = "MP4"
        colFilename.Name = "colFilename"
        colFilename.Visible = False
        colFilename.Width = 200
        ' 
        ' colSend
        ' 
        colSend.HeaderText = "Send"
        colSend.Name = "colSend"
        colSend.Width = 50
        ' 
        ' ScriptPg
        ' 
        ScriptPg.HeaderText = "Paginanr"
        ScriptPg.Name = "ScriptPg"
        ScriptPg.Width = 50
        ' 
        ' FrmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(1844, 982)
        Controls.Add(lblCurrentTime)
        Controls.Add(lblTitleProject)
        Controls.Add(ToolStrip_Form)
        Controls.Add(TabControl)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "FrmMain"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "KKLT Show viewer"
        CType(DG_Devices, ComponentModel.ISupportInitialize).EndInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).EndInit()
        TabControl.ResumeLayout(False)
        TabShow.ResumeLayout(False)
        TabShow.PerformLayout()
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel2.ResumeLayout(False)
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        CType(DG_Show, ComponentModel.ISupportInitialize).EndInit()
        CType(pbPDFViewer, ComponentModel.ISupportInitialize).EndInit()
        gb_Controls.ResumeLayout(False)
        gb_DetailWLed.ResumeLayout(False)
        gb_DetailWLed.PerformLayout()
        CType(detailWLed_Effect, ComponentModel.ISupportInitialize).EndInit()
        GroupBox11.ResumeLayout(False)
        CType(detailWLed_Color3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox10.ResumeLayout(False)
        CType(detailWLed_Color2, ComponentModel.ISupportInitialize).EndInit()
        GroupBox9.ResumeLayout(False)
        CType(detailWLed_Color1, ComponentModel.ISupportInitialize).EndInit()
        CType(detailWLed_Speed, ComponentModel.ISupportInitialize).EndInit()
        CType(detailWLed_Intensity, ComponentModel.ISupportInitialize).EndInit()
        CType(detailWLed_Brightness, ComponentModel.ISupportInitialize).EndInit()
        CType(detailWLed_Palette, ComponentModel.ISupportInitialize).EndInit()
        gbSecondairyBeamer.ResumeLayout(False)
        gbSecondairyBeamer.PerformLayout()
        CType(WMP_SecondairyPlayer_Preview, ComponentModel.ISupportInitialize).EndInit()
        gbPrimaryBeamer.ResumeLayout(False)
        gbPrimaryBeamer.PerformLayout()
        CType(WMP_PrimaryPlayer_Preview, ComponentModel.ISupportInitialize).EndInit()
        ToolStip_Show.ResumeLayout(False)
        ToolStip_Show.PerformLayout()
        TabStage.ResumeLayout(False)
        TabStage.PerformLayout()
        SplitContainerStage.Panel1.ResumeLayout(False)
        SplitContainerStage.Panel2.ResumeLayout(False)
        CType(SplitContainerStage, ComponentModel.ISupportInitialize).EndInit()
        SplitContainerStage.ResumeLayout(False)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(pb_Stage, ComponentModel.ISupportInitialize).EndInit()
        ToolStripSegments.ResumeLayout(False)
        ToolStripSegments.PerformLayout()
        TabTables.ResumeLayout(False)
        TabTables.PerformLayout()
        ToolStripTables.ResumeLayout(False)
        ToolStripTables.PerformLayout()
        TabControlTables.ResumeLayout(False)
        TabTemplates.ResumeLayout(False)
        CType(DG_Templates, ComponentModel.ISupportInitialize).EndInit()
        TabTracks.ResumeLayout(False)
        CType(DG_Tracks, ComponentModel.ISupportInitialize).EndInit()
        TabLightSources.ResumeLayout(False)
        CType(DG_LightSources, ComponentModel.ISupportInitialize).EndInit()
        TabFrames.ResumeLayout(False)
        CType(DG_Frames, ComponentModel.ISupportInitialize).EndInit()
        TabDevices.ResumeLayout(False)
        TabDevices.PerformLayout()
        SplitContainer_Devices.Panel1.ResumeLayout(False)
        CType(SplitContainer_Devices, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer_Devices.ResumeLayout(False)
        ToolStrip_Devices.ResumeLayout(False)
        ToolStrip_Devices.PerformLayout()
        TabGroups.ResumeLayout(False)
        TabGroups.PerformLayout()
        ToolStripGroups.ResumeLayout(False)
        ToolStripGroups.PerformLayout()
        CType(DG_Groups, ComponentModel.ISupportInitialize).EndInit()
        TabEffects.ResumeLayout(False)
        TabEffects.PerformLayout()
        ToolStrip_Effecten.ResumeLayout(False)
        ToolStrip_Effecten.PerformLayout()
        TabPaletten.ResumeLayout(False)
        TabPaletten.PerformLayout()
        ToolStrip_Paletten.ResumeLayout(False)
        ToolStrip_Paletten.PerformLayout()
        CType(DG_Paletten, ComponentModel.ISupportInitialize).EndInit()
        TabSettings.ResumeLayout(False)
        GroupBox8.ResumeLayout(False)
        GroupBox8.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(pbSecondaryStatus, ComponentModel.ISupportInitialize).EndInit()
        CType(pbPrimaryStatus, ComponentModel.ISupportInitialize).EndInit()
        CType(pbControlStatus, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ToolStrip_Form.ResumeLayout(False)
        ToolStrip_Form.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub


    Friend WithEvents DG_Devices As DataGridView
    Friend WithEvents DG_Effecten As DataGridView
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabDevices As TabPage
    Friend WithEvents TabEffects As TabPage
    Friend WithEvents txt_APIResult As TextBox
    Friend WithEvents TabShow As TabPage
    Friend WithEvents DG_Show As DataGridView
    Friend WithEvents ToolStrip_Form As ToolStrip
    Friend WithEvents btnSaveShow As ToolStripButton
    Friend WithEvents TabPaletten As TabPage
    Friend WithEvents DG_Paletten As DataGridView
    Friend WithEvents ToolStip_Show As ToolStrip
    Friend WithEvents btn_DGGrid_AddNewRowBefore As ToolStripButton
    Friend WithEvents btn_DGGrid_AddNewRowAfter As ToolStripButton
    Friend WithEvents btn_DGGrid_RemoveCurrentRow As ToolStripButton
    Friend WithEvents lblFilter As ToolStripLabel
    Friend WithEvents filterAct As ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TabSettings As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblIPRange As Label
    Friend WithEvents txtIPRange As TextBox
    Friend WithEvents cbMonitorSecond As ComboBox
    Friend WithEvents cbMonitorPrime As ComboBox
    Friend WithEvents cbMonitorControl As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblShowMonitor As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents gbPrimaryBeamer As GroupBox
    Friend WithEvents pbControlStatus As PictureBox
    Friend WithEvents lblOutput3 As Label
    Friend WithEvents lblOutput2 As Label
    Friend WithEvents lblOutput1 As Label
    Friend WithEvents pbSecondaryStatus As PictureBox
    Friend WithEvents pbPrimaryStatus As PictureBox
    Friend WithEvents TimerEverySecond As Timer
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStrip_Devices As ToolStrip
    Friend WithEvents BtnScanNetwork As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents LblDeviceStatus As ToolStripLabel
    Friend WithEvents btnScanNetworkForWLed As ToolStripButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents gbSecondairyBeamer As GroupBox
    Friend WithEvents WMP_SecondairyPlayer_Preview As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents WMP_PrimaryPlayer_Preview As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnProjectFolder As Button
    Friend WithEvents settings_ProjectFolder As TextBox
    Friend WithEvents settings_ProjectName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTitleProject As Label
    Friend WithEvents lblCurrentTime As Label
    Friend WithEvents btnLockUnlocked As ToolStripButton
    Friend WithEvents ToolStrip_Paletten As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents ToolStrip_Effecten As ToolStrip
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents gb_DetailWLed As GroupBox
    Friend WithEvents detailWLed_Palette As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents detailWLed_Brightness As TrackBar
    Friend WithEvents Label9 As Label
    Friend WithEvents detailWLed_Speed As TrackBar
    Friend WithEvents Label8 As Label
    Friend WithEvents detailWLed_Intensity As TrackBar
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents detailWLed_Color1 As PictureBox
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents detailWLed_Color3 As PictureBox
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents detailWLed_Color2 As PictureBox
    Friend WithEvents detailWLed__EffectName As Label
    Friend WithEvents gb_Controls As GroupBox
    Friend WithEvents btnControl_NextEvent As Button
    Friend WithEvents btnControl_Start As Button
    Friend WithEvents btnControl_NextScene As Button
    Friend WithEvents lblControl_TimeLeft As Label
    Friend WithEvents TimerNextEvent As Timer
    Friend WithEvents TimerPingDevices As Timer
    Friend WithEvents btnPingDevice As ToolStripButton
    Friend WithEvents btnAddDevice As ToolStripButton
    Friend WithEvents btnDeleteDevice As ToolStripButton
    Friend WithEvents settings_EffectsPath As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents settings_PalettesPath As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents detailWLed_Effect As PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnTestExistanceEffects As ToolStripButton
    Friend WithEvents TabStage As TabPage
    Friend WithEvents btnGenerateStage As ToolStripButton
    Friend WithEvents pb_Stage As PictureBox
    Friend WithEvents ToolStripSegments As ToolStrip
    Friend WithEvents TabGroups As TabPage
    Friend WithEvents DG_Groups As DataGridView
    Friend WithEvents RichTextBox4 As RichTextBox
    Friend WithEvents ToolStripGroups As ToolStrip
    Friend WithEvents btnGroupAddRowAfter As ToolStripButton
    Friend WithEvents btnGroupAddRowBefore As ToolStripButton
    Friend WithEvents btnGroupDeleteRow As ToolStripButton
    Friend WithEvents SplitContainer_Devices As SplitContainer
    Friend WithEvents btnGenerateSliders As ToolStripButton
    Friend WithEvents Label14 As Label
    Friend WithEvents settings_DDPPort As TextBox
    Friend WithEvents ddpTimer As Timer
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ListCustomEffects As ToolStripComboBox
    Friend WithEvents SplitContainerStage As SplitContainer
    Friend WithEvents btnApplyCustomEffect As Button
    Friend WithEvents btnDevicesRefreshIPs As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnGroupsAutoSplit As ToolStripButton
    Friend WithEvents btnStopEffectPreview As Button
    Friend WithEvents btnStartEffectPreview As Button
    Friend WithEvents btnGroupDMXSlider As ToolStripButton
    Friend WithEvents stageTimer As Timer
    Friend WithEvents btnResetEffect As Button
    Friend WithEvents TabTables As TabPage
    Friend WithEvents TabControlTables As TabControl
    Friend WithEvents TabTracks As TabPage
    Friend WithEvents TabLightSources As TabPage
    Friend WithEvents TabFrames As TabPage
    Friend WithEvents TabTemplates As TabPage
    Friend WithEvents DG_LightSources As DataGridView
    Friend WithEvents DG_Frames As DataGridView
    Friend WithEvents DG_Templates As DataGridView
    Friend WithEvents DG_Tracks As DataGridView
    Friend WithEvents PanelTracks As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ToolStripTables As ToolStrip
    Friend WithEvents btnDeleteAllTables As ToolStripButton
    Friend WithEvents btnTablesAddRowBefore As ToolStripButton
    Friend WithEvents btnTablesAddRowAfter As ToolStripButton
    Friend WithEvents btnTablesDeleteSingleRow As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents BtnZoomPulldown As ToolStripDropDownButton
    Friend WithEvents btnZoom10 As ToolStripMenuItem
    Friend WithEvents btnZoom30 As ToolStripMenuItem
    Friend WithEvents btnZoom60 As ToolStripMenuItem
    Friend WithEvents btnZoom90 As ToolStripMenuItem
    Friend WithEvents BtnAddTrack As ToolStripButton
    Friend WithEvents BtnRemoveTrack As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents btnAddShape As ToolStripButton
    Friend WithEvents btnRemoveShape As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents btnLoadAll As ToolStripButton
    Friend WithEvents btnResetFrames As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents cbSelectedEffect As ToolStripComboBox
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents btnEffectAdd As ToolStripButton
    Friend WithEvents btnEffectDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents lblPreviewFromPosition As ToolStripTextBox
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents lblPreviewToPosition As ToolStripTextBox
    Friend WithEvents btnPreviewPlayPause As ToolStripButton
    Friend WithEvents btnRepeat As ToolStripButton
    Friend WithEvents pbPreview As ToolStripProgressBar
    Friend WithEvents colGroupId As DataGridViewTextBoxColumn
    Friend WithEvents colGroupParentId As DataGridViewTextBoxColumn
    Friend WithEvents colGroupName As DataGridViewTextBoxColumn
    Friend WithEvents colGroupFixture As DataGridViewComboBoxColumn
    Friend WithEvents colGroupSegment As DataGridViewTextBoxColumn
    Friend WithEvents colGroupStartLedNr As DataGridViewTextBoxColumn
    Friend WithEvents colGroupStopLedNr As DataGridViewTextBoxColumn
    Friend WithEvents colGroupOrder As DataGridViewTextBoxColumn
    Friend WithEvents colAllFrames As DataGridViewTextBoxColumn
    Friend WithEvents colActiveFrame As DataGridViewTextBoxColumn
    Friend WithEvents colGroupRepeat As DataGridViewCheckBoxColumn
    Friend WithEvents colGroupLayout As DataGridViewTextBoxColumn
    Friend WithEvents colNrOfSegments As DataGridViewTextBoxColumn
    Friend WithEvents btnRebuildDGEffects As ToolStripButton
    Friend WithEvents btnRebuildDGPalettes As ToolStripButton
    Friend WithEvents btnSendUpdatedSegmentsToWLED As ToolStripButton
    Friend WithEvents colIPAddress As DataGridViewTextBoxColumn
    Friend WithEvents colInstance As DataGridViewTextBoxColumn
    Friend WithEvents colLayout As DataGridViewTextBoxColumn
    Friend WithEvents colLedCount As DataGridViewTextBoxColumn
    Friend WithEvents colSegments As DataGridViewTextBoxColumn
    Friend WithEvents colEffects As DataGridViewTextBoxColumn
    Friend WithEvents colPalettes As DataGridViewTextBoxColumn
    Friend WithEvents colEnabled As DataGridViewCheckBoxColumn
    Friend WithEvents colOnline As DataGridViewImageColumn
    Friend WithEvents colDDPData As DataGridViewTextBoxColumn
    Friend WithEvents colDDPOffset As DataGridViewTextBoxColumn
    Friend WithEvents colSegmentsData As DataGridViewTextBoxColumn
    Friend WithEvents colDataProvider As DataGridViewComboBoxColumn
    Friend WithEvents colProcessed As DataGridViewComboBoxColumn
    Friend WithEvents Timer_LoadBuffer As Timer
    Friend WithEvents btnControl_StopAll As Button
    Friend WithEvents btnStopLoopingAtEndOfVideo As Button
    Friend WithEvents btn_ReconnectSecondairyBeamer As Button
    Friend WithEvents btn_ReconnectPrimaryBeamer As Button
    Friend WithEvents warning_SecondairyBeamerOffline As Label
    Friend WithEvents warning_PrimaryBeamerOffline As Label
    Friend WithEvents btnControl_NextAct As Button
    Friend WithEvents colTrackId As DataGridViewTextBoxColumn
    Friend WithEvents colTrackTemplateId As DataGridViewTextBoxColumn
    Friend WithEvents colTrackName As DataGridViewTextBoxColumn
    Friend WithEvents colTrackActive As DataGridViewCheckBoxColumn
    Friend WithEvents colLSId As DataGridViewTextBoxColumn
    Friend WithEvents colLSTrackId As DataGridViewTextBoxColumn
    Friend WithEvents colLSTemplateId As DataGridViewTextBoxColumn
    Friend WithEvents colLSStartMoment As DataGridViewTextBoxColumn
    Friend WithEvents colLSDuration As DataGridViewTextBoxColumn
    Friend WithEvents colLSPositionX As DataGridViewTextBoxColumn
    Friend WithEvents colLSPositionY As DataGridViewTextBoxColumn
    Friend WithEvents colLSSize As DataGridViewTextBoxColumn
    Friend WithEvents colLSShape As DataGridViewTextBoxColumn
    Friend WithEvents colLSBlend As DataGridViewTextBoxColumn
    Friend WithEvents colLSDirection As DataGridViewTextBoxColumn
    Friend WithEvents colLSColor1 As DataGridViewTextBoxColumn
    Friend WithEvents colLSColor2 As DataGridViewTextBoxColumn
    Friend WithEvents colLSColor3 As DataGridViewTextBoxColumn
    Friend WithEvents colLSColor4 As DataGridViewTextBoxColumn
    Friend WithEvents colLSColor5 As DataGridViewTextBoxColumn
    Friend WithEvents colLSBrightnessBaseline As DataGridViewTextBoxColumn
    Friend WithEvents colLSBrightnessEffect As DataGridViewTextBoxColumn
    Friend WithEvents colLSEffect As DataGridViewTextBoxColumn
    Friend WithEvents colLSGroups As DataGridViewTextBoxColumn
    Friend WithEvents colLSEffectSpeed As DataGridViewTextBoxColumn
    Friend WithEvents colLSEffectIntensity As DataGridViewTextBoxColumn
    Friend WithEvents colLSEffectDispersion As DataGridViewTextBoxColumn
    Friend WithEvents colLSEffectStartPosition As DataGridViewComboBoxColumn
    Friend WithEvents colLSEffectDirection As DataGridViewComboBoxColumn
    Friend WithEvents colTemplateID As DataGridViewTextBoxColumn
    Friend WithEvents colTemplateName As DataGridViewTextBoxColumn
    Friend WithEvents colTemplateDescription As DataGridViewTextBoxColumn
    Friend WithEvents colTemplateDuration As DataGridViewTextBoxColumn
    Friend WithEvents colTemplateRepeat As DataGridViewCheckBoxColumn
    Friend WithEvents colTemplateDDPData As DataGridViewTextBoxColumn
    Friend WithEvents btnEditTemplate As ToolStripButton
    Friend WithEvents colFrame_Id As DataGridViewTextBoxColumn
    Friend WithEvents coFrame_FixtureID As DataGridViewTextBoxColumn
    Friend WithEvents colFrame_Frames As DataGridViewTextBoxColumn
    Friend WithEvents colFrame_FixtureID As DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents btn_ScriptPDF As Button
    Friend WithEvents settings_ScriptPDF As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents lblPDFPage As ToolStripLabel
    Friend WithEvents pbPDFViewer As PictureBox
    Friend WithEvents btnApply As DataGridViewButtonColumn
    Friend WithEvents colAct As DataGridViewComboBoxColumn
    Friend WithEvents colSceneId As DataGridViewTextBoxColumn
    Friend WithEvents colEventId As DataGridViewTextBoxColumn
    Friend WithEvents colTimer As DataGridViewTextBoxColumn
    Friend WithEvents colCue As DataGridViewTextBoxColumn
    Friend WithEvents colFixture As DataGridViewComboBoxColumn
    Friend WithEvents colStateOnOff As DataGridViewComboBoxColumn
    Friend WithEvents colEffectId As DataGridViewTextBoxColumn
    Friend WithEvents colEffect As DataGridViewComboBoxColumn
    Friend WithEvents colPaletteId As DataGridViewTextBoxColumn
    Friend WithEvents colPalette As DataGridViewComboBoxColumn
    Friend WithEvents colColor1 As DataGridViewTextBoxColumn
    Friend WithEvents colColor2 As DataGridViewTextBoxColumn
    Friend WithEvents colColor3 As DataGridViewTextBoxColumn
    Friend WithEvents colBrightness As DataGridViewTextBoxColumn
    Friend WithEvents colSpeed As DataGridViewTextBoxColumn
    Friend WithEvents colIntensity As DataGridViewTextBoxColumn
    Friend WithEvents colTransition As DataGridViewTextBoxColumn
    Friend WithEvents colBlend As DataGridViewCheckBoxColumn
    Friend WithEvents colRepeat As DataGridViewCheckBoxColumn
    Friend WithEvents colSound As DataGridViewCheckBoxColumn
    Friend WithEvents colFilename As DataGridViewTextBoxColumn
    Friend WithEvents colSend As DataGridViewCheckBoxColumn
    Friend WithEvents ScriptPg As DataGridViewTextBoxColumn

End Class
