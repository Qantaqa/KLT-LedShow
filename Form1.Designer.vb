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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        btnScanNetwork = New Button()
        DG_Devices = New DataGridView()
        colIPAddress = New DataGridViewTextBoxColumn()
        colInstance = New DataGridViewTextBoxColumn()
        DG_Effecten = New DataGridView()
        TabControl1 = New TabControl()
        TabDevices = New TabPage()
        TabEffects = New TabPage()
        TabShow = New TabPage()
        DG_Show = New DataGridView()
        colAct = New DataGridViewTextBoxColumn()
        colSceneId = New DataGridViewTextBoxColumn()
        colDialog = New DataGridViewTextBoxColumn()
        colCue = New DataGridViewTextBoxColumn()
        txt_APIResult = New TextBox()
        ToolStrip1 = New ToolStrip()
        btnSaveShow = New ToolStripButton()
        btnLoad = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        TabPaletten = New TabPage()
        DG_Paletten = New DataGridView()
        CType(DG_Devices, ComponentModel.ISupportInitialize).BeginInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).BeginInit()
        TabControl1.SuspendLayout()
        TabDevices.SuspendLayout()
        TabEffects.SuspendLayout()
        TabShow.SuspendLayout()
        CType(DG_Show, ComponentModel.ISupportInitialize).BeginInit()
        ToolStrip1.SuspendLayout()
        TabPaletten.SuspendLayout()
        CType(DG_Paletten, ComponentModel.ISupportInitialize).BeginInit()
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
        DG_Devices.Columns.AddRange(New DataGridViewColumn() {colIPAddress, colInstance})
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
        TabControl1.Controls.Add(TabDevices)
        TabControl1.Controls.Add(TabEffects)
        TabControl1.Controls.Add(TabPaletten)
        TabControl1.Controls.Add(TabShow)
        TabControl1.Location = New Point(0, 77)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1443, 684)
        TabControl1.TabIndex = 3
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
        ' TabShow
        ' 
        TabShow.Controls.Add(DG_Show)
        TabShow.Location = New Point(4, 24)
        TabShow.Name = "TabShow"
        TabShow.Size = New Size(1435, 656)
        TabShow.TabIndex = 2
        TabShow.Text = "Show"
        TabShow.UseVisualStyleBackColor = True
        ' 
        ' DG_Show
        ' 
        DG_Show.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DG_Show.Columns.AddRange(New DataGridViewColumn() {colAct, colSceneId, colDialog, colCue})
        DG_Show.Dock = DockStyle.Fill
        DG_Show.Location = New Point(0, 0)
        DG_Show.Name = "DG_Show"
        DG_Show.Size = New Size(1435, 656)
        DG_Show.TabIndex = 0
        ' 
        ' colAct
        ' 
        colAct.HeaderText = "Act"
        colAct.Name = "colAct"
        ' 
        ' colSceneId
        ' 
        colSceneId.HeaderText = "Scene"
        colSceneId.Name = "colSceneId"
        ' 
        ' colDialog
        ' 
        colDialog.HeaderText = "Dialog"
        colDialog.Name = "colDialog"
        ' 
        ' colCue
        ' 
        colCue.HeaderText = "Cue"
        colCue.Name = "colCue"
        ' 
        ' txt_APIResult
        ' 
        txt_APIResult.Location = New Point(169, 12)
        txt_APIResult.Multiline = True
        txt_APIResult.Name = "txt_APIResult"
        txt_APIResult.Size = New Size(624, 59)
        txt_APIResult.TabIndex = 4
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Dock = DockStyle.Bottom
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnSaveShow, btnLoad, ToolStripSeparator1})
        ToolStrip1.Location = New Point(0, 736)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1443, 25)
        ToolStrip1.TabIndex = 5
        ToolStrip1.Text = "ToolStrip1"
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
        ' FrmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1443, 761)
        Controls.Add(ToolStrip1)
        Controls.Add(txt_APIResult)
        Controls.Add(TabControl1)
        Controls.Add(btnScanNetwork)
        Name = "FrmMain"
        Text = "KLT Show viewer"
        CType(DG_Devices, ComponentModel.ISupportInitialize).EndInit()
        CType(DG_Effecten, ComponentModel.ISupportInitialize).EndInit()
        TabControl1.ResumeLayout(False)
        TabDevices.ResumeLayout(False)
        TabEffects.ResumeLayout(False)
        TabShow.ResumeLayout(False)
        CType(DG_Show, ComponentModel.ISupportInitialize).EndInit()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        TabPaletten.ResumeLayout(False)
        CType(DG_Paletten, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents colIPAddress As DataGridViewTextBoxColumn
    Friend WithEvents colInstance As DataGridViewTextBoxColumn
    Friend WithEvents TabShow As TabPage
    Friend WithEvents DG_Show As DataGridView
    Friend WithEvents colAct As DataGridViewTextBoxColumn
    Friend WithEvents colSceneId As DataGridViewTextBoxColumn
    Friend WithEvents colDialog As DataGridViewTextBoxColumn
    Friend WithEvents colCue As DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnSaveShow As ToolStripButton
    Friend WithEvents btnLoad As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TabPaletten As TabPage
    Friend WithEvents DG_Paletten As DataGridView

End Class
