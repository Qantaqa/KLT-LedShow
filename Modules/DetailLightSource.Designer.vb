<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetailLightSource
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnOK = New Button()
        txtStartMoment = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        txtDuration = New TextBox()
        Label3 = New Label()
        txtPositionX = New TextBox()
        txtPositionY = New TextBox()
        Label4 = New Label()
        txtSize = New TextBox()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        cmbShape = New ComboBox()
        Label8 = New Label()
        Label9 = New Label()
        cmbDirection = New ComboBox()
        chkBlend = New CheckBox()
        btnC1 = New Button()
        btnC5 = New Button()
        btnC4 = New Button()
        btnC3 = New Button()
        btnC2 = New Button()
        Label10 = New Label()
        Label11 = New Label()
        cmbEffect = New ComboBox()
        GroupBox1 = New GroupBox()
        Label13 = New Label()
        tbBrightnessEffect = New TrackBar()
        Label12 = New Label()
        tbBrightnessBaseline = New TrackBar()
        tvGroupsSelected = New TreeView()
        Label14 = New Label()
        GroupBox1.SuspendLayout()
        CType(tbBrightnessEffect, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbBrightnessBaseline, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnOK
        ' 
        btnOK.ForeColor = Color.Black
        btnOK.Location = New Point(349, 367)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 0
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' txtStartMoment
        ' 
        txtStartMoment.Location = New Point(95, 6)
        txtStartMoment.Name = "txtStartMoment"
        txtStartMoment.Size = New Size(90, 23)
        txtStartMoment.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(77, 15)
        Label1.TabIndex = 2
        Label1.Text = "Startmoment"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 35)
        Label2.Name = "Label2"
        Label2.Size = New Size(53, 15)
        Label2.TabIndex = 4
        Label2.Text = "Duration"
        ' 
        ' txtDuration
        ' 
        txtDuration.Location = New Point(95, 32)
        txtDuration.Name = "txtDuration"
        txtDuration.Size = New Size(90, 23)
        txtDuration.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 64)
        Label3.Name = "Label3"
        Label3.Size = New Size(50, 15)
        Label3.TabIndex = 6
        Label3.Text = "Position"
        ' 
        ' txtPositionX
        ' 
        txtPositionX.Location = New Point(95, 61)
        txtPositionX.Name = "txtPositionX"
        txtPositionX.Size = New Size(37, 23)
        txtPositionX.TabIndex = 5
        ' 
        ' txtPositionY
        ' 
        txtPositionY.Location = New Point(148, 61)
        txtPositionY.Name = "txtPositionY"
        txtPositionY.Size = New Size(37, 23)
        txtPositionY.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 91)
        Label4.Name = "Label4"
        Label4.Size = New Size(27, 15)
        Label4.TabIndex = 9
        Label4.Text = "Size"
        ' 
        ' txtSize
        ' 
        txtSize.Location = New Point(95, 88)
        txtSize.Name = "txtSize"
        txtSize.Size = New Size(90, 23)
        txtSize.TabIndex = 8
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(191, 91)
        Label5.Name = "Label5"
        Label5.Size = New Size(19, 15)
        Label5.TabIndex = 10
        Label5.Text = "px"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(191, 35)
        Label6.Name = "Label6"
        Label6.Size = New Size(24, 15)
        Label6.TabIndex = 11
        Label6.Text = "sec"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(191, 9)
        Label7.Name = "Label7"
        Label7.Size = New Size(24, 15)
        Label7.TabIndex = 12
        Label7.Text = "sec"
        ' 
        ' cmbShape
        ' 
        cmbShape.FormattingEnabled = True
        cmbShape.Items.AddRange(New Object() {"Circle", "Square", "Cone"})
        cmbShape.Location = New Point(95, 117)
        cmbShape.Name = "cmbShape"
        cmbShape.Size = New Size(124, 23)
        cmbShape.TabIndex = 13
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(12, 120)
        Label8.Name = "Label8"
        Label8.Size = New Size(39, 15)
        Label8.TabIndex = 14
        Label8.Text = "Shape"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(12, 149)
        Label9.Name = "Label9"
        Label9.Size = New Size(55, 15)
        Label9.TabIndex = 16
        Label9.Text = "Direction"
        ' 
        ' cmbDirection
        ' 
        cmbDirection.FormattingEnabled = True
        cmbDirection.Items.AddRange(New Object() {"LeftUp", "Up", "RightUp", "Right", "RightDown", "Down", "LeftDown", "Left"})
        cmbDirection.Location = New Point(95, 146)
        cmbDirection.Name = "cmbDirection"
        cmbDirection.Size = New Size(124, 23)
        cmbDirection.TabIndex = 15
        ' 
        ' chkBlend
        ' 
        chkBlend.AutoSize = True
        chkBlend.Location = New Point(95, 201)
        chkBlend.Name = "chkBlend"
        chkBlend.Size = New Size(56, 19)
        chkBlend.TabIndex = 17
        chkBlend.Text = "Blend"
        chkBlend.UseVisualStyleBackColor = True
        ' 
        ' btnC1
        ' 
        btnC1.Location = New Point(95, 175)
        btnC1.Name = "btnC1"
        btnC1.Size = New Size(20, 20)
        btnC1.TabIndex = 18
        btnC1.UseVisualStyleBackColor = True
        ' 
        ' btnC5
        ' 
        btnC5.Location = New Point(199, 175)
        btnC5.Name = "btnC5"
        btnC5.Size = New Size(20, 20)
        btnC5.TabIndex = 19
        btnC5.UseVisualStyleBackColor = True
        ' 
        ' btnC4
        ' 
        btnC4.Location = New Point(173, 175)
        btnC4.Name = "btnC4"
        btnC4.Size = New Size(20, 20)
        btnC4.TabIndex = 20
        btnC4.UseVisualStyleBackColor = True
        ' 
        ' btnC3
        ' 
        btnC3.Location = New Point(147, 175)
        btnC3.Name = "btnC3"
        btnC3.Size = New Size(20, 20)
        btnC3.TabIndex = 21
        btnC3.UseVisualStyleBackColor = True
        ' 
        ' btnC2
        ' 
        btnC2.Location = New Point(121, 175)
        btnC2.Name = "btnC2"
        btnC2.Size = New Size(20, 20)
        btnC2.TabIndex = 22
        btnC2.UseVisualStyleBackColor = True
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(12, 182)
        Label10.Name = "Label10"
        Label10.Size = New Size(41, 15)
        Label10.TabIndex = 23
        Label10.Text = "Colors"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(12, 229)
        Label11.Name = "Label11"
        Label11.Size = New Size(37, 15)
        Label11.TabIndex = 25
        Label11.Text = "Effect"
        ' 
        ' cmbEffect
        ' 
        cmbEffect.FormattingEnabled = True
        cmbEffect.Items.AddRange(New Object() {"LeftUp", "Up", "RightUp", "Right", "RightDown", "Down", "LeftDown", "Left"})
        cmbEffect.Location = New Point(95, 226)
        cmbEffect.Name = "cmbEffect"
        cmbEffect.Size = New Size(124, 23)
        cmbEffect.TabIndex = 24
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label13)
        GroupBox1.Controls.Add(tbBrightnessEffect)
        GroupBox1.Controls.Add(Label12)
        GroupBox1.Controls.Add(tbBrightnessBaseline)
        GroupBox1.Location = New Point(6, 255)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(213, 102)
        GroupBox1.TabIndex = 28
        GroupBox1.TabStop = False
        GroupBox1.Text = "Brightness"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(12, 61)
        Label13.Name = "Label13"
        Label13.Size = New Size(42, 15)
        Label13.TabIndex = 31
        Label13.Text = "Effects"
        ' 
        ' tbBrightnessEffect
        ' 
        tbBrightnessEffect.Location = New Point(84, 61)
        tbBrightnessEffect.Name = "tbBrightnessEffect"
        tbBrightnessEffect.Size = New Size(104, 45)
        tbBrightnessEffect.TabIndex = 30
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(12, 28)
        Label12.Name = "Label12"
        Label12.Size = New Size(50, 15)
        Label12.TabIndex = 29
        Label12.Text = "Baseline"
        ' 
        ' tbBrightnessBaseline
        ' 
        tbBrightnessBaseline.Location = New Point(84, 28)
        tbBrightnessBaseline.Name = "tbBrightnessBaseline"
        tbBrightnessBaseline.Size = New Size(104, 45)
        tbBrightnessBaseline.TabIndex = 28
        ' 
        ' tvGroupsSelected
        ' 
        tvGroupsSelected.BackColor = Color.DimGray
        tvGroupsSelected.Location = New Point(241, 32)
        tvGroupsSelected.Name = "tvGroupsSelected"
        tvGroupsSelected.Size = New Size(181, 329)
        tvGroupsSelected.TabIndex = 29
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(241, 9)
        Label14.Name = "Label14"
        Label14.Size = New Size(52, 15)
        Label14.TabIndex = 30
        Label14.Text = "Apply to"
        ' 
        ' DetailLightSource
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(431, 398)
        Controls.Add(Label14)
        Controls.Add(tvGroupsSelected)
        Controls.Add(GroupBox1)
        Controls.Add(Label11)
        Controls.Add(cmbEffect)
        Controls.Add(Label10)
        Controls.Add(btnC2)
        Controls.Add(btnC3)
        Controls.Add(btnC4)
        Controls.Add(btnC5)
        Controls.Add(btnC1)
        Controls.Add(chkBlend)
        Controls.Add(Label9)
        Controls.Add(cmbDirection)
        Controls.Add(Label8)
        Controls.Add(cmbShape)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(txtSize)
        Controls.Add(txtPositionY)
        Controls.Add(Label3)
        Controls.Add(txtPositionX)
        Controls.Add(Label2)
        Controls.Add(txtDuration)
        Controls.Add(Label1)
        Controls.Add(txtStartMoment)
        Controls.Add(btnOK)
        ForeColor = Color.White
        MaximizeBox = False
        MdiChildrenMinimizedAnchorBottom = False
        MinimizeBox = False
        Name = "DetailLightSource"
        Opacity = 0.5R
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        Text = "Details"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(tbBrightnessEffect, ComponentModel.ISupportInitialize).EndInit()
        CType(tbBrightnessBaseline, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents txtStartMoment As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDuration As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPositionX As TextBox
    Friend WithEvents txtPositionY As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSize As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbShape As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbDirection As ComboBox
    Friend WithEvents chkBlend As CheckBox
    Friend WithEvents btnC1 As Button
    Friend WithEvents btnC5 As Button
    Friend WithEvents btnC4 As Button
    Friend WithEvents btnC3 As Button
    Friend WithEvents btnC2 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbEffect As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tbBrightnessEffect As TrackBar
    Friend WithEvents Label12 As Label
    Friend WithEvents tbBrightnessBaseline As TrackBar
    Friend WithEvents tvGroupsSelected As TreeView
    Friend WithEvents Label14 As Label
End Class
