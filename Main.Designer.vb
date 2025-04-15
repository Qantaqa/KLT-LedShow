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
        colIPAddress = New DataGridViewTextBoxColumn()
        colInstance = New DataGridViewTextBoxColumn()
        colNumberOfSegments = New DataGridViewTextBoxColumn()
        colPreview = New DataGridViewImageColumn()
        DG_Effecten = New DataGridView()
        TabControl1 = New TabControl()
        TabShow = New TabPage()
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
        colAct = New DataGridViewComboBoxColumn()
        colSceneId = New DataGridViewTextBoxColumn()
        colEventId = New DataGridViewTextBoxColumn()
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
        TabDevices = New TabPage()
        ToolStrip_Devices = New ToolStrip()
        LblDeviceStatus = New ToolStripLabel()
        btnScanNetworkForWLed = New ToolStripButton()
        TabEffects = New TabPage()
        TabPaletten = New TabPage()
        DG_Paletten = New DataGridView()
        TabSettings = New TabPage()
        GroupBox8 = New GroupBox()
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
        btnLoad = New ToolStripButton()
        ToolStripLabel1 = New ToolStripLabel()
        TimerEverySecond = New Timer(components)
        PictureBox1 = New PictureBox()
        OpenFileDialog1 = New OpenFileDialog()
        lblTitleProject = New Label()
        lblCurrentTime = New Label()
        CType(DG_Devices, ComponentModel.ISupportInitialize).BeginInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).BeginInit()
        TabControl1.SuspendLayout()
        TabShow.SuspendLayout()
        GroupBox3.SuspendLayout()
        CType(WMP_Preview_B2, ComponentModel.ISupportInitialize).BeginInit()
        gbMonitor1.SuspendLayout()
        CType(WMP_Preview_B1, ComponentModel.ISupportInitialize).BeginInit()
        ToolStip_Show.SuspendLayout()
        CType(DG_Show, ComponentModel.ISupportInitialize).BeginInit()
        TabDevices.SuspendLayout()
        ToolStrip_Devices.SuspendLayout()
        TabEffects.SuspendLayout()
        TabPaletten.SuspendLayout()
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
        DG_Devices.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DG_Devices.BackgroundColor = Color.DimGray
        DG_Devices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Devices.Columns.AddRange(New DataGridViewColumn() {colIPAddress, colInstance, colNumberOfSegments, colPreview})
        DG_Devices.Location = New Point(3, 31)
        DG_Devices.Name = "DG_Devices"
        DG_Devices.Size = New Size(1429, 601)
        DG_Devices.TabIndex = 1
        ' 
        ' colIPAddress
        ' 
        colIPAddress.HeaderText = "IP Address"
        colIPAddress.Name = "colIPAddress"
        ' 
        ' colInstance
        ' 
        colInstance.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colInstance.HeaderText = "Omschrijving"
        colInstance.Name = "colInstance"
        ' 
        ' colNumberOfSegments
        ' 
        colNumberOfSegments.HeaderText = "Segments"
        colNumberOfSegments.Name = "colNumberOfSegments"
        ' 
        ' colPreview
        ' 
        colPreview.HeaderText = "Peek"
        colPreview.Name = "colPreview"
        colPreview.ReadOnly = True
        colPreview.Width = 1000
        ' 
        ' DG_Effecten
        ' 
        DG_Effecten.BackgroundColor = Color.DimGray
        DG_Effecten.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Effecten.Dock = DockStyle.Fill
        DG_Effecten.Location = New Point(3, 3)
        DG_Effecten.Name = "DG_Effecten"
        DG_Effecten.Size = New Size(1429, 650)
        DG_Effecten.TabIndex = 2
        ' 
        ' TabControl1
        ' 
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl1.Controls.Add(TabShow)
        TabControl1.Controls.Add(TabDevices)
        TabControl1.Controls.Add(TabEffects)
        TabControl1.Controls.Add(TabPaletten)
        TabControl1.Controls.Add(TabSettings)
        TabControl1.Location = New Point(0, 77)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1443, 684)
        TabControl1.TabIndex = 3
        ' 
        ' TabShow
        ' 
        TabShow.BackColor = Color.DimGray
        TabShow.Controls.Add(GroupBox3)
        TabShow.Controls.Add(gbMonitor1)
        TabShow.Controls.Add(ToolStip_Show)
        TabShow.Controls.Add(DG_Show)
        TabShow.Location = New Point(4, 24)
        TabShow.Name = "TabShow"
        TabShow.Size = New Size(1435, 656)
        TabShow.TabIndex = 2
        TabShow.Text = "Show"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        GroupBox3.Controls.Add(WMP_Preview_B2)
        GroupBox3.ForeColor = Color.MidnightBlue
        GroupBox3.Location = New Point(1159, 440)
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
        gbMonitor1.Location = New Point(8, 440)
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
        ToolStip_Show.Size = New Size(1435, 25)
        ToolStip_Show.TabIndex = 3
        ToolStip_Show.Text = "ToolStrip_Show"
        ' 
        ' lblFilter
        ' 
        lblFilter.ForeColor = SystemColors.ControlLightLight
        lblFilter.Name = "lblFilter"
        lblFilter.Size = New Size(72, 22)
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
        DG_Show.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Show.Columns.AddRange(New DataGridViewColumn() {colAct, colSceneId, colEventId, colCue, colFixture, colStateOnOff, colEffectId, colEffect, colPaletteId, colPalette, colColor1, colColor2, colColor3, colBrightness, colSpeed, colIntensity, colTransition, colBlend, colRepeat, colMicrophone, colFilename})
        DG_Show.Location = New Point(0, 26)
        DG_Show.Name = "DG_Show"
        DG_Show.Size = New Size(1432, 408)
        DG_Show.TabIndex = 0
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
        colColor1.Width = 50
        ' 
        ' colColor2
        ' 
        colColor2.HeaderText = "Kleur 2"
        colColor2.Name = "colColor2"
        colColor2.Width = 50
        ' 
        ' colColor3
        ' 
        colColor3.HeaderText = "Kleur 3"
        colColor3.Name = "colColor3"
        colColor3.Width = 50
        ' 
        ' colBrightness
        ' 
        colBrightness.HeaderText = "Brightness"
        colBrightness.Name = "colBrightness"
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
        ' TabDevices
        ' 
        TabDevices.BackColor = Color.DimGray
        TabDevices.Controls.Add(ToolStrip_Devices)
        TabDevices.Controls.Add(DG_Devices)
        TabDevices.Location = New Point(4, 24)
        TabDevices.Name = "TabDevices"
        TabDevices.Padding = New Padding(3)
        TabDevices.Size = New Size(1435, 656)
        TabDevices.TabIndex = 0
        TabDevices.Text = "Devices"
        ' 
        ' ToolStrip_Devices
        ' 
        ToolStrip_Devices.BackColor = Color.MidnightBlue
        ToolStrip_Devices.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolStrip_Devices.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip_Devices.Items.AddRange(New ToolStripItem() {LblDeviceStatus, btnScanNetworkForWLed})
        ToolStrip_Devices.Location = New Point(3, 3)
        ToolStrip_Devices.Name = "ToolStrip_Devices"
        ToolStrip_Devices.Size = New Size(1429, 25)
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
        btnScanNetworkForWLed.Image = My.Resources.Resources.iconScanNetwork_3
        btnScanNetworkForWLed.ImageTransparentColor = Color.Magenta
        btnScanNetworkForWLed.Name = "btnScanNetworkForWLed"
        btnScanNetworkForWLed.Size = New Size(192, 22)
        btnScanNetworkForWLed.Text = "Scan network for WLED devices"
        ' 
        ' TabEffects
        ' 
        TabEffects.BackColor = Color.DimGray
        TabEffects.Controls.Add(DG_Effecten)
        TabEffects.Location = New Point(4, 24)
        TabEffects.Name = "TabEffects"
        TabEffects.Padding = New Padding(3)
        TabEffects.Size = New Size(1435, 656)
        TabEffects.TabIndex = 1
        TabEffects.Text = "Effecten"
        ' 
        ' TabPaletten
        ' 
        TabPaletten.BackColor = Color.DimGray
        TabPaletten.Controls.Add(DG_Paletten)
        TabPaletten.Location = New Point(4, 24)
        TabPaletten.Name = "TabPaletten"
        TabPaletten.Padding = New Padding(3)
        TabPaletten.Size = New Size(1435, 656)
        TabPaletten.TabIndex = 3
        TabPaletten.Text = "Paletten"
        ' 
        ' DG_Paletten
        ' 
        DG_Paletten.BackgroundColor = Color.DimGray
        DG_Paletten.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Paletten.Dock = DockStyle.Fill
        DG_Paletten.Location = New Point(3, 3)
        DG_Paletten.Name = "DG_Paletten"
        DG_Paletten.Size = New Size(1429, 650)
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
        TabSettings.Size = New Size(1435, 656)
        TabSettings.TabIndex = 4
        TabSettings.Text = "Settings"
        ' 
        ' GroupBox8
        ' 
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
        GroupBox5.Size = New Size(1072, 307)
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
        SplitContainer1.Size = New Size(1066, 285)
        SplitContainer1.SplitterDistance = 533
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
        GroupBox6.Size = New Size(533, 285)
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
        GroupBox7.Size = New Size(529, 285)
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
        GroupBox4.Size = New Size(1075, 100)
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
        txt_APIResult.Size = New Size(1069, 78)
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
        ToolStrip_Form.Items.AddRange(New ToolStripItem() {btnSaveShow, btnLoad, ToolStripLabel1})
        ToolStrip_Form.Location = New Point(0, 736)
        ToolStrip_Form.Name = "ToolStrip_Form"
        ToolStrip_Form.Size = New Size(1443, 25)
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
        ' btnLoad
        ' 
        btnLoad.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), Image)
        btnLoad.ImageTransparentColor = Color.Magenta
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(58, 22)
        btnLoad.Text = "(Re)Load"
        ' 
        ' ToolStripLabel1
        ' 
        ToolStripLabel1.Name = "ToolStripLabel1"
        ToolStripLabel1.Size = New Size(0, 22)
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
        PictureBox1.Location = New Point(1292, 2)
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
        lblCurrentTime.Location = New Point(1082, 8)
        lblCurrentTime.Name = "lblCurrentTime"
        lblCurrentTime.Size = New Size(204, 65)
        lblCurrentTime.TabIndex = 8
        lblCurrentTime.Text = "00:00:00"
        ' 
        ' FrmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(1443, 761)
        Controls.Add(lblCurrentTime)
        Controls.Add(lblTitleProject)
        Controls.Add(ToolStrip_Form)
        Controls.Add(TabControl1)
        Controls.Add(PictureBox1)
        Name = "FrmMain"
        Text = "KLT Show viewer"
        CType(DG_Devices, ComponentModel.ISupportInitialize).EndInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).EndInit()
        TabControl1.ResumeLayout(False)
        TabShow.ResumeLayout(False)
        TabShow.PerformLayout()
        GroupBox3.ResumeLayout(False)
        CType(WMP_Preview_B2, ComponentModel.ISupportInitialize).EndInit()
        gbMonitor1.ResumeLayout(False)
        CType(WMP_Preview_B1, ComponentModel.ISupportInitialize).EndInit()
        ToolStip_Show.ResumeLayout(False)
        ToolStip_Show.PerformLayout()
        CType(DG_Show, ComponentModel.ISupportInitialize).EndInit()
        TabDevices.ResumeLayout(False)
        TabDevices.PerformLayout()
        ToolStrip_Devices.ResumeLayout(False)
        ToolStrip_Devices.PerformLayout()
        TabEffects.ResumeLayout(False)
        TabPaletten.ResumeLayout(False)
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
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabDevices As TabPage
    Friend WithEvents TabEffects As TabPage
    Friend WithEvents txt_APIResult As TextBox
    Friend WithEvents TabShow As TabPage
    Friend WithEvents DG_Show As DataGridView
    Friend WithEvents ToolStrip_Form As ToolStrip
    Friend WithEvents btnSaveShow As ToolStripButton
    Friend WithEvents btnLoad As ToolStripButton
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
    Friend WithEvents colIPAddress As DataGridViewTextBoxColumn
    Friend WithEvents colInstance As DataGridViewTextBoxColumn
    Friend WithEvents colNumberOfSegments As DataGridViewTextBoxColumn
    Friend WithEvents colPreview As DataGridViewImageColumn
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
    Friend WithEvents colAct As DataGridViewComboBoxColumn
    Friend WithEvents colSceneId As DataGridViewTextBoxColumn
    Friend WithEvents colEventId As DataGridViewTextBoxColumn
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
    Friend WithEvents btnLockUnlocked As ToolStripButton

End Class
