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
        btnScanNetwork = New Button()
        DG_Devices = New DataGridView()
        colIPAddress = New DataGridViewTextBoxColumn()
        colInstance = New DataGridViewTextBoxColumn()
        colNumberOfSegments = New DataGridViewTextBoxColumn()
        colPreview = New DataGridViewImageColumn()
        DG_Effecten = New DataGridView()
        TabControl1 = New TabControl()
        TabShow = New TabPage()
        ToolStip_Show = New ToolStrip()
        lblFilter = New ToolStripLabel()
        filterAct = New ToolStripComboBox()
        btn_DGGrid_RemoveCurrentRow = New ToolStripButton()
        btn_DGGrid_AddNewRowAfter = New ToolStripButton()
        btn_DGGrid_AddNewRowBefore = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
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
        colMicrophone = New DataGridViewCheckBoxColumn()
        colFilename = New DataGridViewTextBoxColumn()
        TabDevices = New TabPage()
        TabEffects = New TabPage()
        TabPaletten = New TabPage()
        DG_Paletten = New DataGridView()
        TabSettings = New TabPage()
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
        txt_APIResult = New TextBox()
        ToolStrip_Form = New ToolStrip()
        btnSaveShow = New ToolStripButton()
        btnLoad = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        TimerEverySecond = New Timer(components)
        CType(DG_Devices, ComponentModel.ISupportInitialize).BeginInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).BeginInit()
        TabControl1.SuspendLayout()
        TabShow.SuspendLayout()
        ToolStip_Show.SuspendLayout()
        CType(DG_Show, ComponentModel.ISupportInitialize).BeginInit()
        TabDevices.SuspendLayout()
        TabEffects.SuspendLayout()
        TabPaletten.SuspendLayout()
        CType(DG_Paletten, ComponentModel.ISupportInitialize).BeginInit()
        TabSettings.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(pbSecondaryStatus, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbPrimaryStatus, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbControlStatus, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        ToolStrip_Form.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnScanNetwork
        ' 
        btnScanNetwork.Location = New Point(7, 12)
        btnScanNetwork.Name = "btnScanNetwork"
        btnScanNetwork.Size = New Size(156, 23)
        btnScanNetwork.TabIndex = 0
        btnScanNetwork.Text = "Scan"
        btnScanNetwork.UseVisualStyleBackColor = True
        ' 
        ' DG_Devices
        ' 
        DG_Devices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Devices.Columns.AddRange(New DataGridViewColumn() {colIPAddress, colInstance, colNumberOfSegments, colPreview})
        DG_Devices.Dock = DockStyle.Fill
        DG_Devices.Location = New Point(3, 3)
        DG_Devices.Name = "DG_Devices"
        DG_Devices.Size = New Size(1429, 650)
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
        TabShow.Controls.Add(ToolStip_Show)
        TabShow.Controls.Add(DG_Show)
        TabShow.Location = New Point(4, 24)
        TabShow.Name = "TabShow"
        TabShow.Size = New Size(1435, 656)
        TabShow.TabIndex = 2
        TabShow.Text = "Show"
        TabShow.UseVisualStyleBackColor = True
        ' 
        ' ToolStip_Show
        ' 
        ToolStip_Show.BackColor = Color.Black
        ToolStip_Show.Items.AddRange(New ToolStripItem() {lblFilter, filterAct, btn_DGGrid_RemoveCurrentRow, btn_DGGrid_AddNewRowAfter, btn_DGGrid_AddNewRowBefore, ToolStripSeparator2})
        ToolStip_Show.Location = New Point(0, 0)
        ToolStip_Show.Name = "ToolStip_Show"
        ToolStip_Show.Size = New Size(1435, 25)
        ToolStip_Show.TabIndex = 3
        ToolStip_Show.Text = "ToolStrip2"
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
        ' DG_Show
        ' 
        DG_Show.AllowUserToAddRows = False
        DG_Show.AllowUserToDeleteRows = False
        DG_Show.AllowUserToResizeRows = False
        DG_Show.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DG_Show.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Show.Columns.AddRange(New DataGridViewColumn() {colAct, colSceneId, colEventId, colCue, colFixture, colStateOnOff, colEffectId, colEffect, colPaletteId, colPalette, colColor1, colColor2, colColor3, colBrightness, colSpeed, colIntensity, colTransition, colMicrophone, colFilename})
        DG_Show.Location = New Point(0, 30)
        DG_Show.Name = "DG_Show"
        DG_Show.Size = New Size(1408, 602)
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
        colSpeed.Width = 50
        ' 
        ' colIntensity
        ' 
        colIntensity.HeaderText = "Intensiteit"
        colIntensity.Name = "colIntensity"
        colIntensity.Width = 50
        ' 
        ' colTransition
        ' 
        colTransition.HeaderText = "Overgang"
        colTransition.Name = "colTransition"
        colTransition.Visible = False
        colTransition.Width = 50
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
        TabDevices.Controls.Add(DG_Devices)
        TabDevices.Location = New Point(4, 24)
        TabDevices.Name = "TabDevices"
        TabDevices.Padding = New Padding(3)
        TabDevices.Size = New Size(1435, 656)
        TabDevices.TabIndex = 0
        TabDevices.Text = "Devices"
        TabDevices.UseVisualStyleBackColor = True
        ' 
        ' TabEffects
        ' 
        TabEffects.Controls.Add(DG_Effecten)
        TabEffects.Location = New Point(4, 24)
        TabEffects.Name = "TabEffects"
        TabEffects.Padding = New Padding(3)
        TabEffects.Size = New Size(1435, 656)
        TabEffects.TabIndex = 1
        TabEffects.Text = "Effecten"
        TabEffects.UseVisualStyleBackColor = True
        ' 
        ' TabPaletten
        ' 
        TabPaletten.Controls.Add(DG_Paletten)
        TabPaletten.Location = New Point(4, 24)
        TabPaletten.Name = "TabPaletten"
        TabPaletten.Padding = New Padding(3)
        TabPaletten.Size = New Size(1435, 656)
        TabPaletten.TabIndex = 3
        TabPaletten.Text = "Paletten"
        TabPaletten.UseVisualStyleBackColor = True
        ' 
        ' DG_Paletten
        ' 
        DG_Paletten.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Paletten.Dock = DockStyle.Fill
        DG_Paletten.Location = New Point(3, 3)
        DG_Paletten.Name = "DG_Paletten"
        DG_Paletten.Size = New Size(1429, 650)
        DG_Paletten.TabIndex = 0
        ' 
        ' TabSettings
        ' 
        TabSettings.Controls.Add(GroupBox2)
        TabSettings.Controls.Add(GroupBox1)
        TabSettings.Location = New Point(4, 24)
        TabSettings.Name = "TabSettings"
        TabSettings.Padding = New Padding(3)
        TabSettings.Size = New Size(1435, 656)
        TabSettings.TabIndex = 4
        TabSettings.Text = "Settings"
        TabSettings.UseVisualStyleBackColor = True
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
        Label3.Location = New Point(6, 105)
        Label3.Name = "Label3"
        Label3.Size = New Size(108, 15)
        Label3.TabIndex = 2
        Label3.Text = "Secondairy beamer"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 77)
        Label2.Name = "Label2"
        Label2.Size = New Size(91, 15)
        Label2.TabIndex = 1
        Label2.Text = "Primary beamer"
        ' 
        ' lblShowMonitor
        ' 
        lblShowMonitor.AutoSize = True
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
        lblIPRange.Location = New Point(6, 19)
        lblIPRange.Name = "lblIPRange"
        lblIPRange.Size = New Size(55, 15)
        lblIPRange.TabIndex = 0
        lblIPRange.Text = "IP-Range"
        ' 
        ' txt_APIResult
        ' 
        txt_APIResult.Location = New Point(169, 12)
        txt_APIResult.Multiline = True
        txt_APIResult.Name = "txt_APIResult"
        txt_APIResult.Size = New Size(624, 59)
        txt_APIResult.TabIndex = 4
        ' 
        ' ToolStrip_Form
        ' 
        ToolStrip_Form.Dock = DockStyle.Bottom
        ToolStrip_Form.Items.AddRange(New ToolStripItem() {btnSaveShow, btnLoad, ToolStripSeparator1})
        ToolStrip_Form.Location = New Point(0, 736)
        ToolStrip_Form.Name = "ToolStrip_Form"
        ToolStrip_Form.Size = New Size(1443, 25)
        ToolStrip_Form.TabIndex = 5
        ToolStrip_Form.Text = "ToolStrip1"
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
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 25)
        ' 
        ' TimerEverySecond
        ' 
        TimerEverySecond.Enabled = True
        TimerEverySecond.Interval = 5000
        ' 
        ' FrmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1443, 761)
        Controls.Add(ToolStrip_Form)
        Controls.Add(txt_APIResult)
        Controls.Add(TabControl1)
        Controls.Add(btnScanNetwork)
        Name = "FrmMain"
        Text = "KLT Show viewer"
        CType(DG_Devices, ComponentModel.ISupportInitialize).EndInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).EndInit()
        TabControl1.ResumeLayout(False)
        TabShow.ResumeLayout(False)
        TabShow.PerformLayout()
        ToolStip_Show.ResumeLayout(False)
        ToolStip_Show.PerformLayout()
        CType(DG_Show, ComponentModel.ISupportInitialize).EndInit()
        TabDevices.ResumeLayout(False)
        TabEffects.ResumeLayout(False)
        TabPaletten.ResumeLayout(False)
        CType(DG_Paletten, ComponentModel.ISupportInitialize).EndInit()
        TabSettings.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(pbSecondaryStatus, ComponentModel.ISupportInitialize).EndInit()
        CType(pbPrimaryStatus, ComponentModel.ISupportInitialize).EndInit()
        CType(pbControlStatus, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ToolStrip_Form.ResumeLayout(False)
        ToolStrip_Form.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnScanNetwork As Button
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
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TabPaletten As TabPage
    Friend WithEvents DG_Paletten As DataGridView
    Friend WithEvents ToolStip_Show As ToolStrip
    Friend WithEvents btn_DGGrid_AddNewRowBefore As ToolStripButton
    Friend WithEvents btn_DGGrid_AddNewRowAfter As ToolStripButton
    Friend WithEvents btn_DGGrid_RemoveCurrentRow As ToolStripButton
    Friend WithEvents lblFilter As ToolStripLabel
    Friend WithEvents filterAct As ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
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
    Friend WithEvents colMicrophone As DataGridViewCheckBoxColumn
    Friend WithEvents colFilename As DataGridViewTextBoxColumn
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
    Friend WithEvents GroupBox3 As GroupBox
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

End Class
