<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DG_Devices = New DataGridView()
        colIPAddress = New DataGridViewTextBoxColumn()
        colInstance = New DataGridViewTextBoxColumn()
        colLayout = New DataGridViewTextBoxColumn()
        colLedCount = New DataGridViewTextBoxColumn()
        colEnabled = New DataGridViewCheckBoxColumn()
        colDDPData = New DataGridViewTextBoxColumn()
        colDDPOffset = New DataGridViewTextBoxColumn()
        colDataProvider = New DataGridViewComboBoxColumn()
        colOnline = New DataGridViewImageColumn()
        DG_Effecten = New DataGridView()
        TabControl = New TabControl()
        TabShow = New TabPage()
        gb_Controls = New GroupBox()
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
        GroupBox3 = New GroupBox()
        WMP_Preview_B2 = New AxWMPLib.AxWindowsMediaPlayer()
        gbMonitor1 = New GroupBox()
        WMP_Preview_B1 = New AxWMPLib.AxWindowsMediaPlayer()
        ToolStip_Show = New ToolStrip()
        lblFilter = New ToolStripLabel()
        filterAct = New ToolStripComboBox()
        btn_DGGrid_RemoveCurrentRow = New ToolStripButton()
        btn_DGGrid_AddNewRowAfter = New ToolStripButton()
        btn_DGGrid_AddNewRowBefore = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        btnLockUnlocked = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        DG_Show = New DataGridView()
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
        colMicrophone = New DataGridViewCheckBoxColumn()
        colFilename = New DataGridViewTextBoxColumn()
        TabStage = New TabPage()
        SplitContainerStage = New SplitContainer()
        SplitContainer1 = New SplitContainer()
        TabStageControl = New TabControl()
        TabPage2 = New TabPage()
        PanelTracks = New Panel()
        TabPage1 = New TabPage()
        gbEffectSettings = New GroupBox()
        tbEffectDispersion = New TrackBar()
        lblEffectDispersion = New Label()
        tbEffectFPS = New TrackBar()
        lblEffectFPS = New Label()
        tbEffectBrightnessEffect = New TrackBar()
        Label16 = New Label()
        tbEffectDuration = New TrackBar()
        Label18 = New Label()
        cbEffectRepeat = New CheckBox()
        tbEffectBrightnessBaseline = New TrackBar()
        Label17 = New Label()
        tbEffectIntensity = New TrackBar()
        tbEffectSpeed = New TrackBar()
        Label15 = New Label()
        LblSpeed = New Label()
        cbListCustomEffects = New ComboBox()
        lblCustomEffect = New Label()
        GroupBox13 = New GroupBox()
        EffectColor1 = New Button()
        EffectColor2 = New Button()
        EffectColor3 = New Button()
        EffectColor4 = New Button()
        EffectColor5 = New Button()
        GroupBox12 = New GroupBox()
        tvGroupsSelected = New TreeView()
        gbEffectsStartPosition = New GroupBox()
        EffectStartPositionBottomRight = New RadioButton()
        EffectStartPositionBottom = New RadioButton()
        EffectStartPositionBottomLeft = New RadioButton()
        EffectStartPositionRight = New RadioButton()
        EffectStartPositionCenter = New RadioButton()
        EffectStartPositionLeft = New RadioButton()
        EffectStartPositionTopRight = New RadioButton()
        EffectStartPositionTop = New RadioButton()
        EffectStartPositionTopLeft = New RadioButton()
        gbEffectDirection = New GroupBox()
        EffectDirectionDownRight = New RadioButton()
        EffectDirectionDown = New RadioButton()
        EffectDirectionDownLeft = New RadioButton()
        EffectDirectionRight = New RadioButton()
        EffectDirectionLeft = New RadioButton()
        EffectDirectionUpRight = New RadioButton()
        EffectDirectionUp = New RadioButton()
        EffectDirectionUpLeft = New RadioButton()
        btnApplyCustomEffect = New Button()
        btnResetEffect = New Button()
        btnStopEffectPreview = New Button()
        btnStartEffectPreview = New Button()
        pb_Stage = New PictureBox()
        ToolStripSegments = New ToolStrip()
        btnUpdateStage = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        BtnZoomPulldown = New ToolStripDropDownButton()
        btnZoom10 = New ToolStripMenuItem()
        btnZoom30 = New ToolStripMenuItem()
        btnZoom60 = New ToolStripMenuItem()
        btnZoom90 = New ToolStripMenuItem()
        ToolStripSeparator6 = New ToolStripSeparator()
        BtnAddTrack = New ToolStripButton()
        BtnRemoveTrack = New ToolStripButton()
        ToolStripSeparator8 = New ToolStripSeparator()
        btnAddShape = New ToolStripButton()
        btnRemoveShape = New ToolStripButton()
        ToolStripSeparator7 = New ToolStripSeparator()
        TabTables = New TabPage()
        ToolStripTables = New ToolStrip()
        btnTablesAddRowBefore = New ToolStripButton()
        btnTablesAddRowAfter = New ToolStripButton()
        btnTablesDeleteSingleRow = New ToolStripButton()
        ToolStripSeparator3 = New ToolStripSeparator()
        btnDeleteAllTables = New ToolStripButton()
        ToolStripSeparator5 = New ToolStripSeparator()
        TabControlTables = New TabControl()
        TabTracks = New TabPage()
        DG_Tracks = New DataGridView()
        colTrackId = New DataGridViewTextBoxColumn()
        colTrackName = New DataGridViewTextBoxColumn()
        colTrackActive = New DataGridViewCheckBoxColumn()
        TabMyEffects = New TabPage()
        DG_MyEffects = New DataGridView()
        colMEID = New DataGridViewTextBoxColumn()
        colMEName = New DataGridViewTextBoxColumn()
        colMEDescription = New DataGridViewTextBoxColumn()
        colMEDDPData = New DataGridViewTextBoxColumn()
        TabLightSources = New TabPage()
        DG_LightSources = New DataGridView()
        colLSTrackId = New DataGridViewTextBoxColumn()
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
        TabFrames = New TabPage()
        DG_MyEffectsFrames = New DataGridView()
        colMF_MEID = New DataGridViewTextBoxColumn()
        colMF_FixtureID = New DataGridViewTextBoxColumn()
        colMF_Frames = New DataGridViewTextBoxColumn()
        TabDevices = New TabPage()
        SplitContainer_Devices = New SplitContainer()
        RichTextBox1 = New RichTextBox()
        ToolStrip_Devices = New ToolStrip()
        LblDeviceStatus = New ToolStripLabel()
        btnScanNetworkForWLed = New ToolStripButton()
        btnDevicesRefreshIPs = New ToolStripButton()
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
        colGroupStartLedNr = New DataGridViewTextBoxColumn()
        colGroupStopLedNr = New DataGridViewTextBoxColumn()
        colGroupOrder = New DataGridViewTextBoxColumn()
        colAllFrames = New DataGridViewTextBoxColumn()
        colActiveFrame = New DataGridViewTextBoxColumn()
        colGroupRepeat = New DataGridViewCheckBoxColumn()
        colGroupLayout = New DataGridViewTextBoxColumn()
        TabEffects = New TabPage()
        ToolStrip_Effecten = New ToolStrip()
        btnTestExistanceEffects = New ToolStripButton()
        RichTextBox2 = New RichTextBox()
        TabPaletten = New TabPage()
        RichTextBox3 = New RichTextBox()
        ToolStrip_Paletten = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        DG_Paletten = New DataGridView()
        TabSettings = New TabPage()
        GroupBox8 = New GroupBox()
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
        GroupBox5 = New GroupBox()
        SplitContainerSettingsMediaplayers = New SplitContainer()
        GroupBox6 = New GroupBox()
        Label4 = New Label()
        WMP_Preview_B1_2 = New AxWMPLib.AxWindowsMediaPlayer()
        WMP_Preview_B1_1 = New AxWMPLib.AxWindowsMediaPlayer()
        RadioButton1 = New RadioButton()
        RadioButton3 = New RadioButton()
        RadioButton2 = New RadioButton()
        GroupBox7 = New GroupBox()
        WMP_Preview_B2_2 = New AxWMPLib.AxWindowsMediaPlayer()
        WMP_Preview_B2_1 = New AxWMPLib.AxWindowsMediaPlayer()
        RadioButton6 = New RadioButton()
        RadioButton4 = New RadioButton()
        RadioButton5 = New RadioButton()
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
        CType(DG_Devices, ComponentModel.ISupportInitialize).BeginInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).BeginInit()
        TabControl.SuspendLayout()
        TabShow.SuspendLayout()
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
        GroupBox3.SuspendLayout()
        CType(WMP_Preview_B2, ComponentModel.ISupportInitialize).BeginInit()
        gbMonitor1.SuspendLayout()
        CType(WMP_Preview_B1, ComponentModel.ISupportInitialize).BeginInit()
        ToolStip_Show.SuspendLayout()
        CType(DG_Show, ComponentModel.ISupportInitialize).BeginInit()
        TabStage.SuspendLayout()
        CType(SplitContainerStage, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainerStage.Panel1.SuspendLayout()
        SplitContainerStage.Panel2.SuspendLayout()
        SplitContainerStage.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        TabStageControl.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage1.SuspendLayout()
        gbEffectSettings.SuspendLayout()
        CType(tbEffectDispersion, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbEffectFPS, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbEffectBrightnessEffect, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbEffectDuration, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbEffectBrightnessBaseline, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbEffectIntensity, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbEffectSpeed, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox13.SuspendLayout()
        GroupBox12.SuspendLayout()
        gbEffectsStartPosition.SuspendLayout()
        gbEffectDirection.SuspendLayout()
        CType(pb_Stage, ComponentModel.ISupportInitialize).BeginInit()
        ToolStripSegments.SuspendLayout()
        TabTables.SuspendLayout()
        ToolStripTables.SuspendLayout()
        TabControlTables.SuspendLayout()
        TabTracks.SuspendLayout()
        CType(DG_Tracks, ComponentModel.ISupportInitialize).BeginInit()
        TabMyEffects.SuspendLayout()
        CType(DG_MyEffects, ComponentModel.ISupportInitialize).BeginInit()
        TabLightSources.SuspendLayout()
        CType(DG_LightSources, ComponentModel.ISupportInitialize).BeginInit()
        TabFrames.SuspendLayout()
        CType(DG_MyEffectsFrames, ComponentModel.ISupportInitialize).BeginInit()
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
        GroupBox5.SuspendLayout()
        CType(SplitContainerSettingsMediaplayers, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainerSettingsMediaplayers.Panel1.SuspendLayout()
        SplitContainerSettingsMediaplayers.Panel2.SuspendLayout()
        SplitContainerSettingsMediaplayers.SuspendLayout()
        GroupBox6.SuspendLayout()
        CType(WMP_Preview_B1_2, ComponentModel.ISupportInitialize).BeginInit()
        CType(WMP_Preview_B1_1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox7.SuspendLayout()
        CType(WMP_Preview_B2_2, ComponentModel.ISupportInitialize).BeginInit()
        CType(WMP_Preview_B2_1, ComponentModel.ISupportInitialize).BeginInit()
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
        DG_Devices.Columns.AddRange(New DataGridViewColumn() {colIPAddress, colInstance, colLayout, colLedCount, colEnabled, colDDPData, colDDPOffset, colDataProvider, colOnline})
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
        ' colEnabled
        ' 
        colEnabled.HeaderText = "Enabled"
        colEnabled.Name = "colEnabled"
        colEnabled.Width = 55
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
        ' colDataProvider
        ' 
        colDataProvider.HeaderText = "Source"
        colDataProvider.Items.AddRange(New Object() {"DMX", "Effects", "Show"})
        colDataProvider.MaxDropDownItems = 3
        colDataProvider.Name = "colDataProvider"
        colDataProvider.Resizable = DataGridViewTriState.True
        colDataProvider.SortMode = DataGridViewColumnSortMode.Automatic
        ' 
        ' colOnline
        ' 
        colOnline.HeaderText = "Online"
        colOnline.Name = "colOnline"
        colOnline.Width = 48
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
        TabShow.Controls.Add(gb_Controls)
        TabShow.Controls.Add(gb_DetailWLed)
        TabShow.Controls.Add(GroupBox3)
        TabShow.Controls.Add(gbMonitor1)
        TabShow.Controls.Add(ToolStip_Show)
        TabShow.Controls.Add(DG_Show)
        TabShow.Location = New Point(4, 24)
        TabShow.Name = "TabShow"
        TabShow.Size = New Size(1836, 849)
        TabShow.TabIndex = 2
        TabShow.Text = "Show"
        ' 
        ' gb_Controls
        ' 
        gb_Controls.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        gb_Controls.AutoSize = True
        gb_Controls.Controls.Add(lblControl_TimeLeft)
        gb_Controls.Controls.Add(btnControl_NextScene)
        gb_Controls.Controls.Add(btnControl_NextEvent)
        gb_Controls.Controls.Add(btnControl_Start)
        gb_Controls.ForeColor = Color.Gold
        gb_Controls.Location = New Point(798, 661)
        gb_Controls.Name = "gb_Controls"
        gb_Controls.Size = New Size(835, 186)
        gb_Controls.TabIndex = 7
        gb_Controls.TabStop = False
        gb_Controls.Text = "Show controls"
        ' 
        ' lblControl_TimeLeft
        ' 
        lblControl_TimeLeft.BackColor = Color.Black
        lblControl_TimeLeft.BorderStyle = BorderStyle.Fixed3D
        lblControl_TimeLeft.FlatStyle = FlatStyle.Flat
        lblControl_TimeLeft.ForeColor = Color.White
        lblControl_TimeLeft.Image = My.Resources.Resources.iconTime
        lblControl_TimeLeft.ImageAlign = ContentAlignment.MiddleLeft
        lblControl_TimeLeft.Location = New Point(419, 23)
        lblControl_TimeLeft.Name = "lblControl_TimeLeft"
        lblControl_TimeLeft.Size = New Size(129, 40)
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
        btnControl_NextScene.Size = New Size(302, 41)
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
        btnControl_NextEvent.Size = New Size(302, 41)
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
        btnControl_Start.Location = New Point(6, 22)
        btnControl_Start.Name = "btnControl_Start"
        btnControl_Start.Size = New Size(99, 41)
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
        ' GroupBox3
        ' 
        GroupBox3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        GroupBox3.Controls.Add(WMP_Preview_B2)
        GroupBox3.ForeColor = Color.MidnightBlue
        GroupBox3.Location = New Point(1643, 661)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(268, 188)
        GroupBox3.TabIndex = 5
        GroupBox3.TabStop = False
        GroupBox3.Text = "Beamer 2"
        ' 
        ' WMP_Preview_B2
        ' 
        WMP_Preview_B2.Dock = DockStyle.Fill
        WMP_Preview_B2.Enabled = True
        WMP_Preview_B2.Location = New Point(3, 19)
        WMP_Preview_B2.Name = "WMP_Preview_B2"
        WMP_Preview_B2.OcxState = CType(resources.GetObject("WMP_Preview_B2.OcxState"), AxHost.State)
        WMP_Preview_B2.Size = New Size(262, 166)
        WMP_Preview_B2.TabIndex = 0
        ' 
        ' gbMonitor1
        ' 
        gbMonitor1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        gbMonitor1.BackColor = Color.DimGray
        gbMonitor1.Controls.Add(WMP_Preview_B1)
        gbMonitor1.ForeColor = Color.MidnightBlue
        gbMonitor1.Location = New Point(8, 661)
        gbMonitor1.Name = "gbMonitor1"
        gbMonitor1.Size = New Size(268, 188)
        gbMonitor1.TabIndex = 4
        gbMonitor1.TabStop = False
        gbMonitor1.Text = "Beamer 1"
        ' 
        ' WMP_Preview_B1
        ' 
        WMP_Preview_B1.Dock = DockStyle.Fill
        WMP_Preview_B1.Enabled = True
        WMP_Preview_B1.Location = New Point(3, 19)
        WMP_Preview_B1.Name = "WMP_Preview_B1"
        WMP_Preview_B1.OcxState = CType(resources.GetObject("WMP_Preview_B1.OcxState"), AxHost.State)
        WMP_Preview_B1.Size = New Size(262, 166)
        WMP_Preview_B1.TabIndex = 0
        ' 
        ' ToolStip_Show
        ' 
        ToolStip_Show.BackColor = Color.MidnightBlue
        ToolStip_Show.GripStyle = ToolStripGripStyle.Hidden
        ToolStip_Show.Items.AddRange(New ToolStripItem() {lblFilter, filterAct, btn_DGGrid_RemoveCurrentRow, btn_DGGrid_AddNewRowAfter, btn_DGGrid_AddNewRowBefore, ToolStripSeparator2, btnLockUnlocked, ToolStripButton2})
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
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(23, 22)
        ToolStripButton2.Text = "ToolStripButton2"
        ' 
        ' DG_Show
        ' 
        DG_Show.AllowUserToAddRows = False
        DG_Show.AllowUserToDeleteRows = False
        DG_Show.AllowUserToResizeRows = False
        DG_Show.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DG_Show.BackgroundColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        DG_Show.ColumnHeadersHeight = 28
        DG_Show.Columns.AddRange(New DataGridViewColumn() {btnApply, colAct, colSceneId, colEventId, colTimer, colCue, colFixture, colStateOnOff, colEffectId, colEffect, colPaletteId, colPalette, colColor1, colColor2, colColor3, colBrightness, colSpeed, colIntensity, colTransition, colBlend, colRepeat, colMicrophone, colFilename})
        DG_Show.Location = New Point(0, 26)
        DG_Show.Name = "DG_Show"
        DG_Show.RowHeadersWidth = 10
        DG_Show.Size = New Size(1833, 629)
        DG_Show.TabIndex = 0
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
        colAct.Width = 150
        ' 
        ' colSceneId
        ' 
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        colSceneId.DefaultCellStyle = DataGridViewCellStyle3
        colSceneId.HeaderText = "Scene"
        colSceneId.Name = "colSceneId"
        colSceneId.ToolTipText = "Scene nummer van de show"
        colSceneId.Width = 50
        ' 
        ' colEventId
        ' 
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        colEventId.DefaultCellStyle = DataGridViewCellStyle4
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
        colFixture.Width = 150
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
        colEffect.Width = 200
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
        colPalette.Width = 200
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
        colTransition.HeaderText = "Overgang"
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
        ' colMicrophone
        ' 
        colMicrophone.HeaderText = "Geluid"
        colMicrophone.Name = "colMicrophone"
        colMicrophone.Resizable = DataGridViewTriState.True
        colMicrophone.SortMode = DataGridViewColumnSortMode.Automatic
        colMicrophone.Width = 50
        ' 
        ' colFilename
        ' 
        colFilename.HeaderText = "MP4"
        colFilename.Name = "colFilename"
        colFilename.Visible = False
        colFilename.Width = 200
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
        SplitContainer1.Panel1.Controls.Add(TabStageControl)
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
        ' TabStageControl
        ' 
        TabStageControl.Controls.Add(TabPage2)
        TabStageControl.Controls.Add(TabPage1)
        TabStageControl.Dock = DockStyle.Fill
        TabStageControl.Location = New Point(0, 0)
        TabStageControl.Name = "TabStageControl"
        TabStageControl.SelectedIndex = 0
        TabStageControl.Size = New Size(1671, 171)
        TabStageControl.TabIndex = 11
        ' 
        ' TabPage2
        ' 
        TabPage2.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        TabPage2.Controls.Add(PanelTracks)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(1663, 143)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Design"
        ' 
        ' PanelTracks
        ' 
        PanelTracks.Dock = DockStyle.Fill
        PanelTracks.Location = New Point(3, 3)
        PanelTracks.Name = "PanelTracks"
        PanelTracks.Size = New Size(1657, 137)
        PanelTracks.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        TabPage1.Controls.Add(gbEffectSettings)
        TabPage1.Controls.Add(GroupBox13)
        TabPage1.Controls.Add(GroupBox12)
        TabPage1.Controls.Add(gbEffectsStartPosition)
        TabPage1.Controls.Add(gbEffectDirection)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(1663, 143)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Custom"
        ' 
        ' gbEffectSettings
        ' 
        gbEffectSettings.Controls.Add(tbEffectDispersion)
        gbEffectSettings.Controls.Add(lblEffectDispersion)
        gbEffectSettings.Controls.Add(tbEffectFPS)
        gbEffectSettings.Controls.Add(lblEffectFPS)
        gbEffectSettings.Controls.Add(tbEffectBrightnessEffect)
        gbEffectSettings.Controls.Add(Label16)
        gbEffectSettings.Controls.Add(tbEffectDuration)
        gbEffectSettings.Controls.Add(Label18)
        gbEffectSettings.Controls.Add(cbEffectRepeat)
        gbEffectSettings.Controls.Add(tbEffectBrightnessBaseline)
        gbEffectSettings.Controls.Add(Label17)
        gbEffectSettings.Controls.Add(tbEffectIntensity)
        gbEffectSettings.Controls.Add(tbEffectSpeed)
        gbEffectSettings.Controls.Add(Label15)
        gbEffectSettings.Controls.Add(LblSpeed)
        gbEffectSettings.Controls.Add(cbListCustomEffects)
        gbEffectSettings.Controls.Add(lblCustomEffect)
        gbEffectSettings.ForeColor = SystemColors.ButtonFace
        gbEffectSettings.Location = New Point(3, 6)
        gbEffectSettings.Name = "gbEffectSettings"
        gbEffectSettings.Size = New Size(873, 129)
        gbEffectSettings.TabIndex = 0
        gbEffectSettings.TabStop = False
        gbEffectSettings.Text = "Effect"
        ' 
        ' tbEffectDispersion
        ' 
        tbEffectDispersion.Location = New Point(481, 45)
        tbEffectDispersion.Maximum = 100
        tbEffectDispersion.Name = "tbEffectDispersion"
        tbEffectDispersion.Size = New Size(104, 45)
        tbEffectDispersion.TabIndex = 22
        tbEffectDispersion.TickFrequency = 10
        ' 
        ' lblEffectDispersion
        ' 
        lblEffectDispersion.AutoSize = True
        lblEffectDispersion.Location = New Point(423, 52)
        lblEffectDispersion.Name = "lblEffectDispersion"
        lblEffectDispersion.Size = New Size(62, 15)
        lblEffectDispersion.TabIndex = 21
        lblEffectDispersion.Text = "Dispersion"
        ' 
        ' tbEffectFPS
        ' 
        tbEffectFPS.LargeChange = 30
        tbEffectFPS.Location = New Point(763, 74)
        tbEffectFPS.Maximum = 60
        tbEffectFPS.Minimum = 15
        tbEffectFPS.Name = "tbEffectFPS"
        tbEffectFPS.Size = New Size(104, 45)
        tbEffectFPS.SmallChange = 10
        tbEffectFPS.TabIndex = 15
        tbEffectFPS.TickFrequency = 5
        tbEffectFPS.Value = 15
        ' 
        ' lblEffectFPS
        ' 
        lblEffectFPS.AutoSize = True
        lblEffectFPS.Location = New Point(731, 81)
        lblEffectFPS.Name = "lblEffectFPS"
        lblEffectFPS.Size = New Size(26, 15)
        lblEffectFPS.TabIndex = 14
        lblEffectFPS.Text = "FPS"
        ' 
        ' tbEffectBrightnessEffect
        ' 
        tbEffectBrightnessEffect.Location = New Point(312, 74)
        tbEffectBrightnessEffect.Maximum = 100
        tbEffectBrightnessEffect.Name = "tbEffectBrightnessEffect"
        tbEffectBrightnessEffect.Size = New Size(104, 45)
        tbEffectBrightnessEffect.TabIndex = 20
        tbEffectBrightnessEffect.TickFrequency = 10
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(208, 81)
        Label16.Name = "Label16"
        Label16.Size = New Size(95, 15)
        Label16.TabIndex = 19
        Label16.Text = "Brightness effect"
        ' 
        ' tbEffectDuration
        ' 
        tbEffectDuration.LargeChange = 45
        tbEffectDuration.Location = New Point(764, 46)
        tbEffectDuration.Maximum = 90
        tbEffectDuration.Minimum = 1
        tbEffectDuration.Name = "tbEffectDuration"
        tbEffectDuration.Size = New Size(104, 45)
        tbEffectDuration.TabIndex = 18
        tbEffectDuration.TickFrequency = 10
        tbEffectDuration.Value = 10
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(705, 51)
        Label18.Name = "Label18"
        Label18.Size = New Size(53, 15)
        Label18.TabIndex = 17
        Label18.Text = "Duration"
        ' 
        ' cbEffectRepeat
        ' 
        cbEffectRepeat.AutoSize = True
        cbEffectRepeat.CheckAlign = ContentAlignment.MiddleRight
        cbEffectRepeat.Checked = True
        cbEffectRepeat.CheckState = CheckState.Checked
        cbEffectRepeat.Location = New Point(805, 21)
        cbEffectRepeat.Name = "cbEffectRepeat"
        cbEffectRepeat.Size = New Size(62, 19)
        cbEffectRepeat.TabIndex = 16
        cbEffectRepeat.Text = "Repeat"
        cbEffectRepeat.TextAlign = ContentAlignment.MiddleCenter
        cbEffectRepeat.UseVisualStyleBackColor = True
        ' 
        ' tbEffectBrightnessBaseline
        ' 
        tbEffectBrightnessBaseline.Location = New Point(312, 45)
        tbEffectBrightnessBaseline.Maximum = 100
        tbEffectBrightnessBaseline.Name = "tbEffectBrightnessBaseline"
        tbEffectBrightnessBaseline.Size = New Size(104, 45)
        tbEffectBrightnessBaseline.TabIndex = 13
        tbEffectBrightnessBaseline.TickFrequency = 10
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(208, 52)
        Label17.Name = "Label17"
        Label17.Size = New Size(108, 15)
        Label17.TabIndex = 12
        Label17.Text = "Brightness baseline"
        ' 
        ' tbEffectIntensity
        ' 
        tbEffectIntensity.Location = New Point(74, 74)
        tbEffectIntensity.Maximum = 100
        tbEffectIntensity.Name = "tbEffectIntensity"
        tbEffectIntensity.Size = New Size(104, 45)
        tbEffectIntensity.TabIndex = 6
        tbEffectIntensity.TickFrequency = 10
        ' 
        ' tbEffectSpeed
        ' 
        tbEffectSpeed.Location = New Point(74, 45)
        tbEffectSpeed.Maximum = 100
        tbEffectSpeed.Name = "tbEffectSpeed"
        tbEffectSpeed.Size = New Size(104, 45)
        tbEffectSpeed.TabIndex = 5
        tbEffectSpeed.TickFrequency = 10
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(16, 81)
        Label15.Name = "Label15"
        Label15.Size = New Size(52, 15)
        Label15.TabIndex = 3
        Label15.Text = "Intensity"
        ' 
        ' LblSpeed
        ' 
        LblSpeed.AutoSize = True
        LblSpeed.Location = New Point(15, 50)
        LblSpeed.Name = "LblSpeed"
        LblSpeed.Size = New Size(39, 15)
        LblSpeed.TabIndex = 2
        LblSpeed.Text = "Speed"
        ' 
        ' cbListCustomEffects
        ' 
        cbListCustomEffects.FormattingEnabled = True
        cbListCustomEffects.Items.AddRange(New Object() {"DawnHarbor      " & vbTab & "- Vroege ochtendgloed vanaf onderen in warm oranje", "FixedTwinkle" & vbTab & "- Een vaste kleur achtergrond met een willekeurige twinkle in kleur 5", "CalmOcean" & vbTab & "- Langzame, vloeiende pulseringen die het ritme van rustige oceaangolven", "Iceberg" & vbTab & vbTab & "- Een naderende ijsberg waarbij we die raken en stukken afbreken.", "IcebergHit " & vbTab & "- We raken een ijsberg, knipperend en fel wit "})
        cbListCustomEffects.Location = New Point(74, 17)
        cbListCustomEffects.Name = "cbListCustomEffects"
        cbListCustomEffects.Size = New Size(725, 23)
        cbListCustomEffects.TabIndex = 1
        ' 
        ' lblCustomEffect
        ' 
        lblCustomEffect.AutoSize = True
        lblCustomEffect.Location = New Point(14, 22)
        lblCustomEffect.Name = "lblCustomEffect"
        lblCustomEffect.Size = New Size(37, 15)
        lblCustomEffect.TabIndex = 0
        lblCustomEffect.Text = "Effect"
        ' 
        ' GroupBox13
        ' 
        GroupBox13.Controls.Add(EffectColor1)
        GroupBox13.Controls.Add(EffectColor2)
        GroupBox13.Controls.Add(EffectColor3)
        GroupBox13.Controls.Add(EffectColor4)
        GroupBox13.Controls.Add(EffectColor5)
        GroupBox13.ForeColor = SystemColors.Control
        GroupBox13.Location = New Point(882, 6)
        GroupBox13.Name = "GroupBox13"
        GroupBox13.Size = New Size(122, 129)
        GroupBox13.TabIndex = 9
        GroupBox13.TabStop = False
        GroupBox13.Text = "Palette"
        ' 
        ' EffectColor1
        ' 
        EffectColor1.Location = New Point(6, 22)
        EffectColor1.Name = "EffectColor1"
        EffectColor1.Size = New Size(23, 23)
        EffectColor1.TabIndex = 7
        EffectColor1.Text = "Button1"
        EffectColor1.UseVisualStyleBackColor = True
        ' 
        ' EffectColor2
        ' 
        EffectColor2.Location = New Point(35, 22)
        EffectColor2.Name = "EffectColor2"
        EffectColor2.Size = New Size(23, 23)
        EffectColor2.TabIndex = 8
        EffectColor2.Text = "Button2"
        EffectColor2.UseVisualStyleBackColor = True
        ' 
        ' EffectColor3
        ' 
        EffectColor3.Location = New Point(64, 22)
        EffectColor3.Name = "EffectColor3"
        EffectColor3.Size = New Size(23, 23)
        EffectColor3.TabIndex = 9
        EffectColor3.Text = "Button3"
        EffectColor3.UseVisualStyleBackColor = True
        ' 
        ' EffectColor4
        ' 
        EffectColor4.Location = New Point(93, 22)
        EffectColor4.Name = "EffectColor4"
        EffectColor4.Size = New Size(23, 23)
        EffectColor4.TabIndex = 10
        EffectColor4.Text = "Button4"
        EffectColor4.UseVisualStyleBackColor = True
        ' 
        ' EffectColor5
        ' 
        EffectColor5.Location = New Point(6, 50)
        EffectColor5.Name = "EffectColor5"
        EffectColor5.Size = New Size(23, 23)
        EffectColor5.TabIndex = 11
        EffectColor5.Text = "Button5"
        EffectColor5.UseVisualStyleBackColor = True
        ' 
        ' GroupBox12
        ' 
        GroupBox12.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox12.Controls.Add(tvGroupsSelected)
        GroupBox12.ForeColor = SystemColors.ButtonFace
        GroupBox12.Location = New Point(1266, 6)
        GroupBox12.Name = "GroupBox12"
        GroupBox12.Size = New Size(390, 129)
        GroupBox12.TabIndex = 6
        GroupBox12.TabStop = False
        GroupBox12.Text = "Selected groups"
        ' 
        ' tvGroupsSelected
        ' 
        tvGroupsSelected.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        tvGroupsSelected.BorderStyle = BorderStyle.None
        tvGroupsSelected.CheckBoxes = True
        tvGroupsSelected.Dock = DockStyle.Fill
        tvGroupsSelected.ForeColor = SystemColors.ButtonFace
        tvGroupsSelected.Location = New Point(3, 19)
        tvGroupsSelected.Name = "tvGroupsSelected"
        tvGroupsSelected.Size = New Size(384, 107)
        tvGroupsSelected.TabIndex = 5
        ' 
        ' gbEffectsStartPosition
        ' 
        gbEffectsStartPosition.Controls.Add(EffectStartPositionBottomRight)
        gbEffectsStartPosition.Controls.Add(EffectStartPositionBottom)
        gbEffectsStartPosition.Controls.Add(EffectStartPositionBottomLeft)
        gbEffectsStartPosition.Controls.Add(EffectStartPositionRight)
        gbEffectsStartPosition.Controls.Add(EffectStartPositionCenter)
        gbEffectsStartPosition.Controls.Add(EffectStartPositionLeft)
        gbEffectsStartPosition.Controls.Add(EffectStartPositionTopRight)
        gbEffectsStartPosition.Controls.Add(EffectStartPositionTop)
        gbEffectsStartPosition.Controls.Add(EffectStartPositionTopLeft)
        gbEffectsStartPosition.ForeColor = SystemColors.Control
        gbEffectsStartPosition.Location = New Point(1010, 6)
        gbEffectsStartPosition.Name = "gbEffectsStartPosition"
        gbEffectsStartPosition.Size = New Size(122, 129)
        gbEffectsStartPosition.TabIndex = 2
        gbEffectsStartPosition.TabStop = False
        gbEffectsStartPosition.Text = "Start position"
        ' 
        ' EffectStartPositionBottomRight
        ' 
        EffectStartPositionBottomRight.AutoSize = True
        EffectStartPositionBottomRight.Location = New Point(82, 97)
        EffectStartPositionBottomRight.Name = "EffectStartPositionBottomRight"
        EffectStartPositionBottomRight.Size = New Size(14, 13)
        EffectStartPositionBottomRight.TabIndex = 9
        EffectStartPositionBottomRight.UseVisualStyleBackColor = True
        ' 
        ' EffectStartPositionBottom
        ' 
        EffectStartPositionBottom.AutoSize = True
        EffectStartPositionBottom.Location = New Point(53, 96)
        EffectStartPositionBottom.Name = "EffectStartPositionBottom"
        EffectStartPositionBottom.Size = New Size(14, 13)
        EffectStartPositionBottom.TabIndex = 8
        EffectStartPositionBottom.UseVisualStyleBackColor = True
        ' 
        ' EffectStartPositionBottomLeft
        ' 
        EffectStartPositionBottomLeft.AutoSize = True
        EffectStartPositionBottomLeft.Location = New Point(24, 96)
        EffectStartPositionBottomLeft.Name = "EffectStartPositionBottomLeft"
        EffectStartPositionBottomLeft.Size = New Size(14, 13)
        EffectStartPositionBottomLeft.TabIndex = 7
        EffectStartPositionBottomLeft.UseVisualStyleBackColor = True
        ' 
        ' EffectStartPositionRight
        ' 
        EffectStartPositionRight.AutoSize = True
        EffectStartPositionRight.Location = New Point(82, 65)
        EffectStartPositionRight.Name = "EffectStartPositionRight"
        EffectStartPositionRight.Size = New Size(14, 13)
        EffectStartPositionRight.TabIndex = 6
        EffectStartPositionRight.UseVisualStyleBackColor = True
        ' 
        ' EffectStartPositionCenter
        ' 
        EffectStartPositionCenter.AutoSize = True
        EffectStartPositionCenter.Checked = True
        EffectStartPositionCenter.Location = New Point(53, 64)
        EffectStartPositionCenter.Name = "EffectStartPositionCenter"
        EffectStartPositionCenter.Size = New Size(14, 13)
        EffectStartPositionCenter.TabIndex = 5
        EffectStartPositionCenter.TabStop = True
        EffectStartPositionCenter.UseVisualStyleBackColor = True
        ' 
        ' EffectStartPositionLeft
        ' 
        EffectStartPositionLeft.AutoSize = True
        EffectStartPositionLeft.Location = New Point(24, 64)
        EffectStartPositionLeft.Name = "EffectStartPositionLeft"
        EffectStartPositionLeft.Size = New Size(14, 13)
        EffectStartPositionLeft.TabIndex = 4
        EffectStartPositionLeft.UseVisualStyleBackColor = True
        ' 
        ' EffectStartPositionTopRight
        ' 
        EffectStartPositionTopRight.AutoSize = True
        EffectStartPositionTopRight.Location = New Point(82, 36)
        EffectStartPositionTopRight.Name = "EffectStartPositionTopRight"
        EffectStartPositionTopRight.Size = New Size(14, 13)
        EffectStartPositionTopRight.TabIndex = 3
        EffectStartPositionTopRight.UseVisualStyleBackColor = True
        ' 
        ' EffectStartPositionTop
        ' 
        EffectStartPositionTop.AutoSize = True
        EffectStartPositionTop.Location = New Point(53, 35)
        EffectStartPositionTop.Name = "EffectStartPositionTop"
        EffectStartPositionTop.Size = New Size(14, 13)
        EffectStartPositionTop.TabIndex = 2
        EffectStartPositionTop.UseVisualStyleBackColor = True
        ' 
        ' EffectStartPositionTopLeft
        ' 
        EffectStartPositionTopLeft.AutoSize = True
        EffectStartPositionTopLeft.Location = New Point(24, 35)
        EffectStartPositionTopLeft.Name = "EffectStartPositionTopLeft"
        EffectStartPositionTopLeft.Size = New Size(14, 13)
        EffectStartPositionTopLeft.TabIndex = 1
        EffectStartPositionTopLeft.UseVisualStyleBackColor = True
        ' 
        ' gbEffectDirection
        ' 
        gbEffectDirection.Controls.Add(EffectDirectionDownRight)
        gbEffectDirection.Controls.Add(EffectDirectionDown)
        gbEffectDirection.Controls.Add(EffectDirectionDownLeft)
        gbEffectDirection.Controls.Add(EffectDirectionRight)
        gbEffectDirection.Controls.Add(EffectDirectionLeft)
        gbEffectDirection.Controls.Add(EffectDirectionUpRight)
        gbEffectDirection.Controls.Add(EffectDirectionUp)
        gbEffectDirection.Controls.Add(EffectDirectionUpLeft)
        gbEffectDirection.ForeColor = SystemColors.Control
        gbEffectDirection.Location = New Point(1138, 6)
        gbEffectDirection.Name = "gbEffectDirection"
        gbEffectDirection.Size = New Size(122, 129)
        gbEffectDirection.TabIndex = 3
        gbEffectDirection.TabStop = False
        gbEffectDirection.Text = "Direction"
        ' 
        ' EffectDirectionDownRight
        ' 
        EffectDirectionDownRight.AutoSize = True
        EffectDirectionDownRight.Location = New Point(82, 97)
        EffectDirectionDownRight.Name = "EffectDirectionDownRight"
        EffectDirectionDownRight.Size = New Size(14, 13)
        EffectDirectionDownRight.TabIndex = 9
        EffectDirectionDownRight.UseVisualStyleBackColor = True
        ' 
        ' EffectDirectionDown
        ' 
        EffectDirectionDown.AutoSize = True
        EffectDirectionDown.Location = New Point(53, 96)
        EffectDirectionDown.Name = "EffectDirectionDown"
        EffectDirectionDown.Size = New Size(14, 13)
        EffectDirectionDown.TabIndex = 8
        EffectDirectionDown.UseVisualStyleBackColor = True
        ' 
        ' EffectDirectionDownLeft
        ' 
        EffectDirectionDownLeft.AutoSize = True
        EffectDirectionDownLeft.Location = New Point(24, 96)
        EffectDirectionDownLeft.Name = "EffectDirectionDownLeft"
        EffectDirectionDownLeft.Size = New Size(14, 13)
        EffectDirectionDownLeft.TabIndex = 7
        EffectDirectionDownLeft.UseVisualStyleBackColor = True
        ' 
        ' EffectDirectionRight
        ' 
        EffectDirectionRight.AutoSize = True
        EffectDirectionRight.Location = New Point(82, 65)
        EffectDirectionRight.Name = "EffectDirectionRight"
        EffectDirectionRight.Size = New Size(14, 13)
        EffectDirectionRight.TabIndex = 6
        EffectDirectionRight.UseVisualStyleBackColor = True
        ' 
        ' EffectDirectionLeft
        ' 
        EffectDirectionLeft.AutoSize = True
        EffectDirectionLeft.Location = New Point(24, 64)
        EffectDirectionLeft.Name = "EffectDirectionLeft"
        EffectDirectionLeft.Size = New Size(14, 13)
        EffectDirectionLeft.TabIndex = 4
        EffectDirectionLeft.UseVisualStyleBackColor = True
        ' 
        ' EffectDirectionUpRight
        ' 
        EffectDirectionUpRight.AutoSize = True
        EffectDirectionUpRight.Location = New Point(82, 36)
        EffectDirectionUpRight.Name = "EffectDirectionUpRight"
        EffectDirectionUpRight.Size = New Size(14, 13)
        EffectDirectionUpRight.TabIndex = 3
        EffectDirectionUpRight.UseVisualStyleBackColor = True
        ' 
        ' EffectDirectionUp
        ' 
        EffectDirectionUp.AutoSize = True
        EffectDirectionUp.Checked = True
        EffectDirectionUp.Location = New Point(53, 35)
        EffectDirectionUp.Name = "EffectDirectionUp"
        EffectDirectionUp.Size = New Size(14, 13)
        EffectDirectionUp.TabIndex = 2
        EffectDirectionUp.TabStop = True
        EffectDirectionUp.UseVisualStyleBackColor = True
        ' 
        ' EffectDirectionUpLeft
        ' 
        EffectDirectionUpLeft.AutoSize = True
        EffectDirectionUpLeft.Location = New Point(24, 35)
        EffectDirectionUpLeft.Name = "EffectDirectionUpLeft"
        EffectDirectionUpLeft.Size = New Size(14, 13)
        EffectDirectionUpLeft.TabIndex = 1
        EffectDirectionUpLeft.UseVisualStyleBackColor = True
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
        ToolStripSegments.Items.AddRange(New ToolStripItem() {btnUpdateStage, ToolStripSeparator1, BtnZoomPulldown, ToolStripSeparator6, BtnAddTrack, BtnRemoveTrack, ToolStripSeparator8, btnAddShape, btnRemoveShape, ToolStripSeparator7})
        ToolStripSegments.Location = New Point(3, 3)
        ToolStripSegments.Name = "ToolStripSegments"
        ToolStripSegments.Size = New Size(1830, 25)
        ToolStripSegments.TabIndex = 1
        ToolStripSegments.Text = "ToolStripSegments"
        ' 
        ' btnUpdateStage
        ' 
        btnUpdateStage.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnUpdateStage.ForeColor = SystemColors.AppWorkspace
        btnUpdateStage.Image = CType(resources.GetObject("btnUpdateStage.Image"), Image)
        btnUpdateStage.ImageTransparentColor = Color.Magenta
        btnUpdateStage.Name = "btnUpdateStage"
        btnUpdateStage.Size = New Size(81, 22)
        btnUpdateStage.Text = "Redraw stage"
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
        ' ToolStripSeparator7
        ' 
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New Size(6, 25)
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
        TabControlTables.Controls.Add(TabTracks)
        TabControlTables.Controls.Add(TabMyEffects)
        TabControlTables.Controls.Add(TabLightSources)
        TabControlTables.Controls.Add(TabFrames)
        TabControlTables.Dock = DockStyle.Bottom
        TabControlTables.Location = New Point(0, 32)
        TabControlTables.Name = "TabControlTables"
        TabControlTables.SelectedIndex = 0
        TabControlTables.Size = New Size(1836, 817)
        TabControlTables.TabIndex = 0
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
        DG_Tracks.Columns.AddRange(New DataGridViewColumn() {colTrackId, colTrackName, colTrackActive})
        DG_Tracks.Dock = DockStyle.Fill
        DG_Tracks.Location = New Point(3, 3)
        DG_Tracks.Name = "DG_Tracks"
        DG_Tracks.Size = New Size(1822, 783)
        DG_Tracks.TabIndex = 0
        ' 
        ' colTrackId
        ' 
        colTrackId.HeaderText = "ID"
        colTrackId.Name = "colTrackId"
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
        ' TabMyEffects
        ' 
        TabMyEffects.Controls.Add(DG_MyEffects)
        TabMyEffects.Location = New Point(4, 24)
        TabMyEffects.Name = "TabMyEffects"
        TabMyEffects.Size = New Size(1828, 789)
        TabMyEffects.TabIndex = 3
        TabMyEffects.Text = "Effects"
        TabMyEffects.UseVisualStyleBackColor = True
        ' 
        ' DG_MyEffects
        ' 
        DG_MyEffects.AllowUserToAddRows = False
        DG_MyEffects.AllowUserToDeleteRows = False
        DG_MyEffects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_MyEffects.Columns.AddRange(New DataGridViewColumn() {colMEID, colMEName, colMEDescription, colMEDDPData})
        DG_MyEffects.Dock = DockStyle.Fill
        DG_MyEffects.Location = New Point(0, 0)
        DG_MyEffects.Name = "DG_MyEffects"
        DG_MyEffects.Size = New Size(1828, 789)
        DG_MyEffects.TabIndex = 0
        ' 
        ' colMEID
        ' 
        colMEID.HeaderText = "colMEID"
        colMEID.Name = "colMEID"
        ' 
        ' colMEName
        ' 
        colMEName.HeaderText = "colMEName"
        colMEName.Name = "colMEName"
        ' 
        ' colMEDescription
        ' 
        colMEDescription.HeaderText = "colMEDescription"
        colMEDescription.Name = "colMEDescription"
        ' 
        ' colMEDDPData
        ' 
        colMEDDPData.HeaderText = "colMEDDPData"
        colMEDDPData.Name = "colMEDDPData"
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
        DG_LightSources.Columns.AddRange(New DataGridViewColumn() {colLSTrackId, colLSStartMoment, colLSDuration, colLSPositionX, colLSPositionY, colLSSize, colLSShape, colLSBlend, colLSDirection, colLSColor1, colLSColor2, colLSColor3, colLSColor4, colLSColor5, colLSBrightnessBaseline, colLSBrightnessEffect, colLSEffect, colLSGroups})
        DG_LightSources.Dock = DockStyle.Fill
        DG_LightSources.Location = New Point(3, 3)
        DG_LightSources.Name = "DG_LightSources"
        DG_LightSources.Size = New Size(1822, 783)
        DG_LightSources.TabIndex = 0
        ' 
        ' colLSTrackId
        ' 
        colLSTrackId.HeaderText = "colLSTrackId"
        colLSTrackId.Name = "colLSTrackId"
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
        ' TabFrames
        ' 
        TabFrames.Controls.Add(DG_MyEffectsFrames)
        TabFrames.Location = New Point(4, 24)
        TabFrames.Name = "TabFrames"
        TabFrames.Size = New Size(1828, 789)
        TabFrames.TabIndex = 2
        TabFrames.Text = "Frames"
        TabFrames.UseVisualStyleBackColor = True
        ' 
        ' DG_MyEffectsFrames
        ' 
        DG_MyEffectsFrames.AllowUserToAddRows = False
        DG_MyEffectsFrames.AllowUserToDeleteRows = False
        DG_MyEffectsFrames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_MyEffectsFrames.Columns.AddRange(New DataGridViewColumn() {colMF_MEID, colMF_FixtureID, colMF_Frames})
        DG_MyEffectsFrames.Dock = DockStyle.Fill
        DG_MyEffectsFrames.Location = New Point(0, 0)
        DG_MyEffectsFrames.Name = "DG_MyEffectsFrames"
        DG_MyEffectsFrames.Size = New Size(1828, 789)
        DG_MyEffectsFrames.TabIndex = 1
        ' 
        ' colMF_MEID
        ' 
        colMF_MEID.HeaderText = "ID"
        colMF_MEID.Name = "colMF_MEID"
        ' 
        ' colMF_FixtureID
        ' 
        colMF_FixtureID.HeaderText = "Fixture"
        colMF_FixtureID.Name = "colMF_FixtureID"
        ' 
        ' colMF_Frames
        ' 
        colMF_Frames.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colMF_Frames.HeaderText = "Frames"
        colMF_Frames.Name = "colMF_Frames"
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
        ToolStrip_Devices.Items.AddRange(New ToolStripItem() {LblDeviceStatus, btnScanNetworkForWLed, btnDevicesRefreshIPs, btnPingDevice, btnDeleteDevice, btnAddDevice, ToolStripSeparator4, btnGenerateStage, btnGenerateSliders})
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
        btnGenerateSliders.ForeColor = SystemColors.Control
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
        DG_Groups.Columns.AddRange(New DataGridViewColumn() {colGroupId, colGroupParentId, colGroupName, colGroupFixture, colGroupStartLedNr, colGroupStopLedNr, colGroupOrder, colAllFrames, colActiveFrame, colGroupRepeat, colGroupLayout})
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
        ToolStrip_Effecten.Items.AddRange(New ToolStripItem() {btnTestExistanceEffects})
        ToolStrip_Effecten.Location = New Point(3, 3)
        ToolStrip_Effecten.Name = "ToolStrip_Effecten"
        ToolStrip_Effecten.Size = New Size(1830, 25)
        ToolStrip_Effecten.TabIndex = 4
        ToolStrip_Effecten.Text = "ToolStrip2"
        ' 
        ' btnTestExistanceEffects
        ' 
        btnTestExistanceEffects.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnTestExistanceEffects.ForeColor = SystemColors.ButtonShadow
        btnTestExistanceEffects.Image = CType(resources.GetObject("btnTestExistanceEffects.Image"), Image)
        btnTestExistanceEffects.ImageTransparentColor = Color.Magenta
        btnTestExistanceEffects.Name = "btnTestExistanceEffects"
        btnTestExistanceEffects.Size = New Size(32, 22)
        btnTestExistanceEffects.Text = "Test"
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
        ToolStrip_Paletten.Items.AddRange(New ToolStripItem() {ToolStripButton1})
        ToolStrip_Paletten.Location = New Point(3, 3)
        ToolStrip_Paletten.Name = "ToolStrip_Paletten"
        ToolStrip_Paletten.Size = New Size(1830, 25)
        ToolStrip_Paletten.TabIndex = 1
        ToolStrip_Paletten.Text = "ToolStrip1"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.ForeColor = SystemColors.ControlLightLight
        ToolStripButton1.Image = My.Resources.Resources.iconBlackBullet1
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(112, 22)
        ToolStripButton1.Text = "Reload previews"
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
        TabSettings.Controls.Add(GroupBox5)
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
        ' GroupBox5
        ' 
        GroupBox5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox5.Controls.Add(SplitContainerSettingsMediaplayers)
        GroupBox5.ForeColor = Color.MidnightBlue
        GroupBox5.Location = New Point(352, 109)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(1114, 307)
        GroupBox5.TabIndex = 6
        GroupBox5.TabStop = False
        GroupBox5.Text = "Active mediaplayers"
        ' 
        ' SplitContainerSettingsMediaplayers
        ' 
        SplitContainerSettingsMediaplayers.Dock = DockStyle.Fill
        SplitContainerSettingsMediaplayers.Location = New Point(3, 19)
        SplitContainerSettingsMediaplayers.Name = "SplitContainerSettingsMediaplayers"
        ' 
        ' SplitContainerSettingsMediaplayers.Panel1
        ' 
        SplitContainerSettingsMediaplayers.Panel1.Controls.Add(GroupBox6)
        ' 
        ' SplitContainerSettingsMediaplayers.Panel2
        ' 
        SplitContainerSettingsMediaplayers.Panel2.Controls.Add(GroupBox7)
        SplitContainerSettingsMediaplayers.Size = New Size(1108, 285)
        SplitContainerSettingsMediaplayers.SplitterDistance = 578
        SplitContainerSettingsMediaplayers.TabIndex = 0
        ' 
        ' GroupBox6
        ' 
        GroupBox6.Controls.Add(Label4)
        GroupBox6.Controls.Add(WMP_Preview_B1_2)
        GroupBox6.Controls.Add(WMP_Preview_B1_1)
        GroupBox6.Controls.Add(RadioButton1)
        GroupBox6.Controls.Add(RadioButton3)
        GroupBox6.Controls.Add(RadioButton2)
        GroupBox6.Dock = DockStyle.Fill
        GroupBox6.ForeColor = Color.DarkGray
        GroupBox6.Location = New Point(0, 0)
        GroupBox6.Name = "GroupBox6"
        GroupBox6.Size = New Size(578, 285)
        GroupBox6.TabIndex = 3
        GroupBox6.TabStop = False
        GroupBox6.Text = "Beamer 1"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(24, 234)
        Label4.Name = "Label4"
        Label4.Size = New Size(28, 15)
        Label4.TabIndex = 5
        Label4.Text = "File:"
        ' 
        ' WMP_Preview_B1_2
        ' 
        WMP_Preview_B1_2.Enabled = True
        WMP_Preview_B1_2.Location = New Point(275, 72)
        WMP_Preview_B1_2.Name = "WMP_Preview_B1_2"
        WMP_Preview_B1_2.OcxState = CType(resources.GetObject("WMP_Preview_B1_2.OcxState"), AxHost.State)
        WMP_Preview_B1_2.Size = New Size(241, 150)
        WMP_Preview_B1_2.TabIndex = 4
        ' 
        ' WMP_Preview_B1_1
        ' 
        WMP_Preview_B1_1.Enabled = True
        WMP_Preview_B1_1.Location = New Point(24, 72)
        WMP_Preview_B1_1.Name = "WMP_Preview_B1_1"
        WMP_Preview_B1_1.OcxState = CType(resources.GetObject("WMP_Preview_B1_1.OcxState"), AxHost.State)
        WMP_Preview_B1_1.Size = New Size(241, 150)
        WMP_Preview_B1_1.TabIndex = 3
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Checked = True
        RadioButton1.ForeColor = Color.Black
        RadioButton1.Location = New Point(24, 22)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(54, 19)
        RadioButton1.TabIndex = 0
        RadioButton1.TabStop = True
        RadioButton1.Text = "Blank"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' RadioButton3
        ' 
        RadioButton3.AutoSize = True
        RadioButton3.ForeColor = Color.Black
        RadioButton3.Location = New Point(275, 47)
        RadioButton3.Name = "RadioButton3"
        RadioButton3.Size = New Size(34, 19)
        RadioButton3.TabIndex = 2
        RadioButton3.Text = "2:"
        RadioButton3.UseVisualStyleBackColor = True
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.ForeColor = Color.Black
        RadioButton2.Location = New Point(24, 47)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(34, 19)
        RadioButton2.TabIndex = 1
        RadioButton2.Text = "1:"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' GroupBox7
        ' 
        GroupBox7.Controls.Add(WMP_Preview_B2_2)
        GroupBox7.Controls.Add(WMP_Preview_B2_1)
        GroupBox7.Controls.Add(RadioButton6)
        GroupBox7.Controls.Add(RadioButton4)
        GroupBox7.Controls.Add(RadioButton5)
        GroupBox7.Dock = DockStyle.Fill
        GroupBox7.ForeColor = Color.DarkGray
        GroupBox7.Location = New Point(0, 0)
        GroupBox7.Name = "GroupBox7"
        GroupBox7.Size = New Size(526, 285)
        GroupBox7.TabIndex = 6
        GroupBox7.TabStop = False
        GroupBox7.Text = "Beamer 2"
        ' 
        ' WMP_Preview_B2_2
        ' 
        WMP_Preview_B2_2.Enabled = True
        WMP_Preview_B2_2.Location = New Point(270, 71)
        WMP_Preview_B2_2.Name = "WMP_Preview_B2_2"
        WMP_Preview_B2_2.OcxState = CType(resources.GetObject("WMP_Preview_B2_2.OcxState"), AxHost.State)
        WMP_Preview_B2_2.Size = New Size(241, 150)
        WMP_Preview_B2_2.TabIndex = 7
        ' 
        ' WMP_Preview_B2_1
        ' 
        WMP_Preview_B2_1.Enabled = True
        WMP_Preview_B2_1.Location = New Point(19, 71)
        WMP_Preview_B2_1.Name = "WMP_Preview_B2_1"
        WMP_Preview_B2_1.OcxState = CType(resources.GetObject("WMP_Preview_B2_1.OcxState"), AxHost.State)
        WMP_Preview_B2_1.Size = New Size(241, 150)
        WMP_Preview_B2_1.TabIndex = 6
        ' 
        ' RadioButton6
        ' 
        RadioButton6.AutoSize = True
        RadioButton6.Checked = True
        RadioButton6.ForeColor = Color.Black
        RadioButton6.Location = New Point(19, 22)
        RadioButton6.Name = "RadioButton6"
        RadioButton6.Size = New Size(54, 19)
        RadioButton6.TabIndex = 3
        RadioButton6.TabStop = True
        RadioButton6.Text = "Blank"
        RadioButton6.UseVisualStyleBackColor = True
        ' 
        ' RadioButton4
        ' 
        RadioButton4.AutoSize = True
        RadioButton4.Location = New Point(270, 47)
        RadioButton4.Name = "RadioButton4"
        RadioButton4.Size = New Size(34, 19)
        RadioButton4.TabIndex = 5
        RadioButton4.Text = "2:"
        RadioButton4.UseVisualStyleBackColor = True
        ' 
        ' RadioButton5
        ' 
        RadioButton5.AutoSize = True
        RadioButton5.ForeColor = Color.Black
        RadioButton5.Location = New Point(19, 47)
        RadioButton5.Name = "RadioButton5"
        RadioButton5.Size = New Size(34, 19)
        RadioButton5.TabIndex = 4
        RadioButton5.Text = "1:"
        RadioButton5.UseVisualStyleBackColor = True
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
        Text = "KLT Show viewer"
        CType(DG_Devices, ComponentModel.ISupportInitialize).EndInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).EndInit()
        TabControl.ResumeLayout(False)
        TabShow.ResumeLayout(False)
        TabShow.PerformLayout()
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
        GroupBox3.ResumeLayout(False)
        CType(WMP_Preview_B2, ComponentModel.ISupportInitialize).EndInit()
        gbMonitor1.ResumeLayout(False)
        CType(WMP_Preview_B1, ComponentModel.ISupportInitialize).EndInit()
        ToolStip_Show.ResumeLayout(False)
        ToolStip_Show.PerformLayout()
        CType(DG_Show, ComponentModel.ISupportInitialize).EndInit()
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
        TabStageControl.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        gbEffectSettings.ResumeLayout(False)
        gbEffectSettings.PerformLayout()
        CType(tbEffectDispersion, ComponentModel.ISupportInitialize).EndInit()
        CType(tbEffectFPS, ComponentModel.ISupportInitialize).EndInit()
        CType(tbEffectBrightnessEffect, ComponentModel.ISupportInitialize).EndInit()
        CType(tbEffectDuration, ComponentModel.ISupportInitialize).EndInit()
        CType(tbEffectBrightnessBaseline, ComponentModel.ISupportInitialize).EndInit()
        CType(tbEffectIntensity, ComponentModel.ISupportInitialize).EndInit()
        CType(tbEffectSpeed, ComponentModel.ISupportInitialize).EndInit()
        GroupBox13.ResumeLayout(False)
        GroupBox12.ResumeLayout(False)
        gbEffectsStartPosition.ResumeLayout(False)
        gbEffectsStartPosition.PerformLayout()
        gbEffectDirection.ResumeLayout(False)
        gbEffectDirection.PerformLayout()
        CType(pb_Stage, ComponentModel.ISupportInitialize).EndInit()
        ToolStripSegments.ResumeLayout(False)
        ToolStripSegments.PerformLayout()
        TabTables.ResumeLayout(False)
        TabTables.PerformLayout()
        ToolStripTables.ResumeLayout(False)
        ToolStripTables.PerformLayout()
        TabControlTables.ResumeLayout(False)
        TabTracks.ResumeLayout(False)
        CType(DG_Tracks, ComponentModel.ISupportInitialize).EndInit()
        TabMyEffects.ResumeLayout(False)
        CType(DG_MyEffects, ComponentModel.ISupportInitialize).EndInit()
        TabLightSources.ResumeLayout(False)
        CType(DG_LightSources, ComponentModel.ISupportInitialize).EndInit()
        TabFrames.ResumeLayout(False)
        CType(DG_MyEffectsFrames, ComponentModel.ISupportInitialize).EndInit()
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
        GroupBox5.ResumeLayout(False)
        SplitContainerSettingsMediaplayers.Panel1.ResumeLayout(False)
        SplitContainerSettingsMediaplayers.Panel2.ResumeLayout(False)
        CType(SplitContainerSettingsMediaplayers, ComponentModel.ISupportInitialize).EndInit()
        SplitContainerSettingsMediaplayers.ResumeLayout(False)
        GroupBox6.ResumeLayout(False)
        GroupBox6.PerformLayout()
        CType(WMP_Preview_B1_2, ComponentModel.ISupportInitialize).EndInit()
        CType(WMP_Preview_B1_1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox7.ResumeLayout(False)
        GroupBox7.PerformLayout()
        CType(WMP_Preview_B2_2, ComponentModel.ISupportInitialize).EndInit()
        CType(WMP_Preview_B2_1, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gbMonitor1 As GroupBox
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
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents WMP_Preview_B2 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents WMP_Preview_B1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents SplitContainerSettingsMediaplayers As SplitContainer
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents WMP_Preview_B1_2 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents WMP_Preview_B1_1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents WMP_Preview_B2_2 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents WMP_Preview_B2_1 As AxWMPLib.AxWindowsMediaPlayer
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
    Friend WithEvents colMicrophone As DataGridViewCheckBoxColumn
    Friend WithEvents colFilename As DataGridViewTextBoxColumn
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
    Friend WithEvents btnUpdateStage As ToolStripButton
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
    Friend WithEvents gbEffectSettings As GroupBox
    Friend WithEvents LblSpeed As Label
    Friend WithEvents cbListCustomEffects As ComboBox
    Friend WithEvents lblCustomEffect As Label
    Friend WithEvents EffectColor5 As Button
    Friend WithEvents EffectColor4 As Button
    Friend WithEvents EffectColor3 As Button
    Friend WithEvents EffectColor2 As Button
    Friend WithEvents EffectColor1 As Button
    Friend WithEvents tbEffectIntensity As TrackBar
    Friend WithEvents tbEffectSpeed As TrackBar
    Friend WithEvents Label15 As Label
    Friend WithEvents gbEffectsStartPosition As GroupBox
    Friend WithEvents EffectStartPositionBottomRight As RadioButton
    Friend WithEvents EffectStartPositionBottom As RadioButton
    Friend WithEvents EffectStartPositionBottomLeft As RadioButton
    Friend WithEvents EffectStartPositionRight As RadioButton
    Friend WithEvents EffectStartPositionCenter As RadioButton
    Friend WithEvents EffectStartPositionLeft As RadioButton
    Friend WithEvents EffectStartPositionTopRight As RadioButton
    Friend WithEvents EffectStartPositionTop As RadioButton
    Friend WithEvents EffectStartPositionTopLeft As RadioButton
    Friend WithEvents gbEffectDirection As GroupBox
    Friend WithEvents EffectDirectionDownRight As RadioButton
    Friend WithEvents EffectDirectionDown As RadioButton
    Friend WithEvents EffectDirectionDownLeft As RadioButton
    Friend WithEvents EffectDirectionRight As RadioButton
    Friend WithEvents EffectDirectionLeft As RadioButton
    Friend WithEvents EffectDirectionUpRight As RadioButton
    Friend WithEvents EffectDirectionUp As RadioButton
    Friend WithEvents EffectDirectionUpLeft As RadioButton
    Friend WithEvents btnApplyCustomEffect As Button
    Friend WithEvents btnDevicesRefreshIPs As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnGroupsAutoSplit As ToolStripButton
    Friend WithEvents tbEffectBrightnessBaseline As TrackBar
    Friend WithEvents Label17 As Label
    Friend WithEvents tbEffectFPS As TrackBar
    Friend WithEvents lblEffectFPS As Label
    Friend WithEvents cbEffectRepeat As CheckBox
    Friend WithEvents btnStopEffectPreview As Button
    Friend WithEvents btnStartEffectPreview As Button
    Friend WithEvents tbEffectDuration As TrackBar
    Friend WithEvents Label18 As Label
    Friend WithEvents colIPAddress As DataGridViewTextBoxColumn
    Friend WithEvents colInstance As DataGridViewTextBoxColumn
    Friend WithEvents colLayout As DataGridViewTextBoxColumn
    Friend WithEvents colLedCount As DataGridViewTextBoxColumn
    Friend WithEvents colEnabled As DataGridViewCheckBoxColumn
    Friend WithEvents colDDPData As DataGridViewTextBoxColumn
    Friend WithEvents colDDPOffset As DataGridViewTextBoxColumn
    Friend WithEvents colDataProvider As DataGridViewComboBoxColumn
    Friend WithEvents colOnline As DataGridViewImageColumn
    Friend WithEvents btnGroupDMXSlider As ToolStripButton
    Friend WithEvents colGroupId As DataGridViewTextBoxColumn
    Friend WithEvents colGroupParentId As DataGridViewTextBoxColumn
    Friend WithEvents colGroupName As DataGridViewTextBoxColumn
    Friend WithEvents colGroupFixture As DataGridViewComboBoxColumn
    Friend WithEvents colGroupStartLedNr As DataGridViewTextBoxColumn
    Friend WithEvents colGroupStopLedNr As DataGridViewTextBoxColumn
    Friend WithEvents colGroupOrder As DataGridViewTextBoxColumn
    Friend WithEvents colAllFrames As DataGridViewTextBoxColumn
    Friend WithEvents colActiveFrame As DataGridViewTextBoxColumn
    Friend WithEvents colGroupRepeat As DataGridViewCheckBoxColumn
    Friend WithEvents colGroupLayout As DataGridViewTextBoxColumn
    Friend WithEvents stageTimer As Timer
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents tbEffectBrightnessEffect As TrackBar
    Friend WithEvents Label16 As Label
    Friend WithEvents tbEffectDispersion As TrackBar
    Friend WithEvents lblEffectDispersion As Label
    Friend WithEvents btnResetEffect As Button
    Friend WithEvents TabTables As TabPage
    Friend WithEvents TabControlTables As TabControl
    Friend WithEvents TabTracks As TabPage
    Friend WithEvents TabLightSources As TabPage
    Friend WithEvents TabFrames As TabPage
    Friend WithEvents TabMyEffects As TabPage
    Friend WithEvents DG_LightSources As DataGridView
    Friend WithEvents DG_MyEffectsFrames As DataGridView
    Friend WithEvents colLSTrackId As DataGridViewTextBoxColumn
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
    Friend WithEvents colMF_MEID As DataGridViewTextBoxColumn
    Friend WithEvents colMF_FixtureID As DataGridViewTextBoxColumn
    Friend WithEvents colMF_Frames As DataGridViewTextBoxColumn
    Friend WithEvents DG_MyEffects As DataGridView
    Friend WithEvents colMEID As DataGridViewTextBoxColumn
    Friend WithEvents colMEName As DataGridViewTextBoxColumn
    Friend WithEvents colMEDescription As DataGridViewTextBoxColumn
    Friend WithEvents colMEDDPData As DataGridViewTextBoxColumn
    Friend WithEvents DG_Tracks As DataGridView
    Friend WithEvents colTrackId As DataGridViewTextBoxColumn
    Friend WithEvents colTrackName As DataGridViewTextBoxColumn
    Friend WithEvents colTrackActive As DataGridViewCheckBoxColumn
    Friend WithEvents TabStageControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
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
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents BtnAddTrack As ToolStripButton
    Friend WithEvents BtnRemoveTrack As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents btnAddShape As ToolStripButton
    Friend WithEvents btnRemoveShape As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents btnLoadAll As ToolStripButton
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents tvGroupsSelected As TreeView

End Class
