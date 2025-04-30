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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DG_Devices = New DataGridView()
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
        pb_Stage = New PictureBox()
        ToolStripSegments = New ToolStrip()
        btnUpdateStage = New ToolStripButton()
        TabDevices = New TabPage()
        SplitContainer_Devices = New SplitContainer()
        RichTextBox1 = New RichTextBox()
        ToolStrip_Devices = New ToolStrip()
        LblDeviceStatus = New ToolStripLabel()
        btnScanNetworkForWLed = New ToolStripButton()
        btnPingDevice = New ToolStripButton()
        btnDeleteDevice = New ToolStripButton()
        btnAddDevice = New ToolStripButton()
        btnGenerateStage = New ToolStripButton()
        btnGenerateSliders = New ToolStripButton()
        TabGroups = New TabPage()
        RichTextBox4 = New RichTextBox()
        ToolStrip1 = New ToolStrip()
        btnGroupDeleteRow = New ToolStripButton()
        btnGroupAddRowBefore = New ToolStripButton()
        btnGroupAddRowAfter = New ToolStripButton()
        DG_Groups = New DataGridView()
        colGroupName = New DataGridViewTextBoxColumn()
        colGroupFixture = New DataGridViewComboBoxColumn()
        colGroupStartLedNr = New DataGridViewTextBoxColumn()
        colGroupStopLedNr = New DataGridViewTextBoxColumn()
        colGroupOrder = New DataGridViewTextBoxColumn()
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
        SplitContainer1 = New SplitContainer()
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
        btnLoad = New ToolStripDropDownButton()
        SegmentsStageToolStripMenuItem = New ToolStripMenuItem()
        btnLoadEffectPalettes = New ToolStripMenuItem()
        btnLoadShow = New ToolStripMenuItem()
        btnLoadAll = New ToolStripMenuItem()
        TimerEverySecond = New Timer(components)
        PictureBox1 = New PictureBox()
        OpenFileDialog1 = New OpenFileDialog()
        lblTitleProject = New Label()
        lblCurrentTime = New Label()
        TimerNextEvent = New Timer(components)
        TimerPingDevices = New Timer(components)
        ddpTimer = New Timer(components)
        colIPAddress = New DataGridViewTextBoxColumn()
        colInstance = New DataGridViewTextBoxColumn()
        colLayout = New DataGridViewTextBoxColumn()
        colLedCount = New DataGridViewTextBoxColumn()
        colEnabled = New DataGridViewCheckBoxColumn()
        colDDPData = New DataGridViewTextBoxColumn()
        colOnline = New DataGridViewImageColumn()
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
        CType(pb_Stage, ComponentModel.ISupportInitialize).BeginInit()
        ToolStripSegments.SuspendLayout()
        TabDevices.SuspendLayout()
        CType(SplitContainer_Devices, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer_Devices.Panel1.SuspendLayout()
        SplitContainer_Devices.SuspendLayout()
        ToolStrip_Devices.SuspendLayout()
        TabGroups.SuspendLayout()
        ToolStrip1.SuspendLayout()
        CType(DG_Groups, ComponentModel.ISupportInitialize).BeginInit()
        TabEffects.SuspendLayout()
        ToolStrip_Effecten.SuspendLayout()
        TabPaletten.SuspendLayout()
        ToolStrip_Paletten.SuspendLayout()
        CType(DG_Paletten, ComponentModel.ISupportInitialize).BeginInit()
        TabSettings.SuspendLayout()
        GroupBox8.SuspendLayout()
        GroupBox5.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
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
        DG_Devices.Columns.AddRange(New DataGridViewColumn() {colIPAddress, colInstance, colLayout, colLedCount, colEnabled, colDDPData, colOnline})
        DG_Devices.Dock = DockStyle.Fill
        DG_Devices.Location = New Point(0, 0)
        DG_Devices.MultiSelect = False
        DG_Devices.Name = "DG_Devices"
        DG_Devices.RowHeadersWidth = 10
        DG_Devices.Size = New Size(1827, 393)
        DG_Devices.TabIndex = 1
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
        ToolStip_Show.Items.AddRange(New ToolStripItem() {lblFilter, filterAct, btn_DGGrid_RemoveCurrentRow, btn_DGGrid_AddNewRowAfter, btn_DGGrid_AddNewRowBefore, ToolStripSeparator2, btnLockUnlocked})
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
        TabStage.Controls.Add(pb_Stage)
        TabStage.Controls.Add(ToolStripSegments)
        TabStage.Location = New Point(4, 24)
        TabStage.Name = "TabStage"
        TabStage.Padding = New Padding(3)
        TabStage.Size = New Size(1836, 849)
        TabStage.TabIndex = 6
        TabStage.Text = "Stage"
        ' 
        ' pb_Stage
        ' 
        pb_Stage.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        pb_Stage.BackColor = Color.Black
        pb_Stage.Location = New Point(0, 31)
        pb_Stage.Name = "pb_Stage"
        pb_Stage.Size = New Size(1836, 818)
        pb_Stage.TabIndex = 2
        pb_Stage.TabStop = False
        ' 
        ' ToolStripSegments
        ' 
        ToolStripSegments.BackColor = Color.MidnightBlue
        ToolStripSegments.GripStyle = ToolStripGripStyle.Hidden
        ToolStripSegments.Items.AddRange(New ToolStripItem() {btnUpdateStage})
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
        ToolStrip_Devices.Items.AddRange(New ToolStripItem() {LblDeviceStatus, btnScanNetworkForWLed, btnPingDevice, btnDeleteDevice, btnAddDevice, btnGenerateStage, btnGenerateSliders})
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
        btnGenerateSliders.Image = CType(resources.GetObject("btnGenerateSliders.Image"), Image)
        btnGenerateSliders.ImageTransparentColor = Color.Magenta
        btnGenerateSliders.Name = "btnGenerateSliders"
        btnGenerateSliders.Size = New Size(89, 22)
        btnGenerateSliders.Text = "DMX sliders"
        ' 
        ' TabGroups
        ' 
        TabGroups.Controls.Add(RichTextBox4)
        TabGroups.Controls.Add(ToolStrip1)
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
        ' ToolStrip1
        ' 
        ToolStrip1.BackColor = Color.MidnightBlue
        ToolStrip1.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnGroupDeleteRow, btnGroupAddRowBefore, btnGroupAddRowAfter})
        ToolStrip1.Location = New Point(3, 3)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1830, 25)
        ToolStrip1.TabIndex = 1
        ToolStrip1.Text = "ToolStrip1"
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
        ' DG_Groups
        ' 
        DG_Groups.AllowUserToAddRows = False
        DG_Groups.AllowUserToDeleteRows = False
        DG_Groups.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DG_Groups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Groups.Columns.AddRange(New DataGridViewColumn() {colGroupName, colGroupFixture, colGroupStartLedNr, colGroupStopLedNr, colGroupOrder})
        DG_Groups.Location = New Point(3, 69)
        DG_Groups.Name = "DG_Groups"
        DG_Groups.RowHeadersWidth = 11
        DG_Groups.Size = New Size(1830, 774)
        DG_Groups.TabIndex = 0
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
        GroupBox5.Controls.Add(SplitContainer1)
        GroupBox5.ForeColor = Color.MidnightBlue
        GroupBox5.Location = New Point(352, 109)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(1114, 307)
        GroupBox5.TabIndex = 6
        GroupBox5.TabStop = False
        GroupBox5.Text = "Active mediaplayers"
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(3, 19)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(GroupBox6)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(GroupBox7)
        SplitContainer1.Size = New Size(1108, 285)
        SplitContainer1.SplitterDistance = 554
        SplitContainer1.TabIndex = 0
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
        GroupBox6.Size = New Size(554, 285)
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
        GroupBox7.Size = New Size(550, 285)
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
        ToolStrip_Form.Items.AddRange(New ToolStripItem() {btnSaveShow, ToolStripLabel1, btnLoad})
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
        ' btnLoad
        ' 
        btnLoad.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnLoad.DropDownItems.AddRange(New ToolStripItem() {SegmentsStageToolStripMenuItem, btnLoadEffectPalettes, btnLoadShow, btnLoadAll})
        btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), Image)
        btnLoad.ImageTransparentColor = Color.Magenta
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(46, 22)
        btnLoad.Text = "Load"
        ' 
        ' SegmentsStageToolStripMenuItem
        ' 
        SegmentsStageToolStripMenuItem.Name = "SegmentsStageToolStripMenuItem"
        SegmentsStageToolStripMenuItem.Size = New Size(166, 22)
        SegmentsStageToolStripMenuItem.Text = "Segments & Stage"
        ' 
        ' btnLoadEffectPalettes
        ' 
        btnLoadEffectPalettes.Name = "btnLoadEffectPalettes"
        btnLoadEffectPalettes.Size = New Size(166, 22)
        btnLoadEffectPalettes.Text = "Effects && Palettes"
        ' 
        ' btnLoadShow
        ' 
        btnLoadShow.Name = "btnLoadShow"
        btnLoadShow.Size = New Size(166, 22)
        btnLoadShow.Text = "Show"
        ' 
        ' btnLoadAll
        ' 
        btnLoadAll.Name = "btnLoadAll"
        btnLoadAll.Size = New Size(166, 22)
        btnLoadAll.Text = "All"
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
        ' colOnline
        ' 
        colOnline.HeaderText = "Online"
        colOnline.Name = "colOnline"
        colOnline.Width = 48
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
        Name = "FrmMain"
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
        CType(pb_Stage, ComponentModel.ISupportInitialize).EndInit()
        ToolStripSegments.ResumeLayout(False)
        ToolStripSegments.PerformLayout()
        TabDevices.ResumeLayout(False)
        TabDevices.PerformLayout()
        SplitContainer_Devices.Panel1.ResumeLayout(False)
        CType(SplitContainer_Devices, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer_Devices.ResumeLayout(False)
        ToolStrip_Devices.ResumeLayout(False)
        ToolStrip_Devices.PerformLayout()
        TabGroups.ResumeLayout(False)
        TabGroups.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
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
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
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
    Friend WithEvents SplitContainer1 As SplitContainer
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
    Friend WithEvents btnLoad As ToolStripDropDownButton
    Friend WithEvents btnLoadEffectPalettes As ToolStripMenuItem
    Friend WithEvents btnLoadShow As ToolStripMenuItem
    Friend WithEvents btnLoadAll As ToolStripMenuItem
    Friend WithEvents settings_EffectsPath As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents settings_PalettesPath As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents detailWLed_Effect As PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnTestExistanceEffects As ToolStripButton
    Friend WithEvents TabStage As TabPage
    Friend WithEvents SegmentsStageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnGenerateStage As ToolStripButton
    Friend WithEvents pb_Stage As PictureBox
    Friend WithEvents ToolStripSegments As ToolStrip
    Friend WithEvents btnUpdateStage As ToolStripButton
    Friend WithEvents TabGroups As TabPage
    Friend WithEvents DG_Groups As DataGridView
    Friend WithEvents RichTextBox4 As RichTextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGroupAddRowAfter As ToolStripButton
    Friend WithEvents btnGroupAddRowBefore As ToolStripButton
    Friend WithEvents btnGroupDeleteRow As ToolStripButton
    Friend WithEvents colGroupName As DataGridViewTextBoxColumn
    Friend WithEvents colGroupFixture As DataGridViewComboBoxColumn
    Friend WithEvents colGroupStartLedNr As DataGridViewTextBoxColumn
    Friend WithEvents colGroupStopLedNr As DataGridViewTextBoxColumn
    Friend WithEvents colGroupOrder As DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer_Devices As SplitContainer
    Friend WithEvents btnGenerateSliders As ToolStripButton
    Friend WithEvents Label14 As Label
    Friend WithEvents settings_DDPPort As TextBox
    Friend WithEvents ddpTimer As Timer
    Friend WithEvents colIPAddress As DataGridViewTextBoxColumn
    Friend WithEvents colInstance As DataGridViewTextBoxColumn
    Friend WithEvents colLayout As DataGridViewTextBoxColumn
    Friend WithEvents colLedCount As DataGridViewTextBoxColumn
    Friend WithEvents colEnabled As DataGridViewCheckBoxColumn
    Friend WithEvents colDDPData As DataGridViewTextBoxColumn
    Friend WithEvents colOnline As DataGridViewImageColumn

End Class
