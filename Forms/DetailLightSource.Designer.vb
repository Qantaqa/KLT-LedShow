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
        Label11 = New Label()
        cmbEffect = New ComboBox()
        tbBrightnessEffect = New TrackBar()
        tvGroupsSelected = New TreeView()
        Label14 = New Label()
        btnCancel = New Button()
        Label15 = New Label()
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
        GroupBox2 = New GroupBox()
        tbEffectSpeed = New TrackBar()
        TBEffectIntensity = New TrackBar()
        TBEffectDispersion = New TrackBar()
        Label10 = New Label()
        Label16 = New Label()
        Label17 = New Label()
        tbBrightnessBaseline = New TrackBar()
        Label12 = New Label()
        Label13 = New Label()
        Label18 = New Label()
        Panel1 = New Panel()
        CType(tbBrightnessEffect, ComponentModel.ISupportInitialize).BeginInit()
        gbEffectsStartPosition.SuspendLayout()
        gbEffectDirection.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(tbEffectSpeed, ComponentModel.ISupportInitialize).BeginInit()
        CType(TBEffectIntensity, ComponentModel.ISupportInitialize).BeginInit()
        CType(TBEffectDispersion, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbBrightnessBaseline, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnOK
        ' 
        btnOK.BackColor = Color.DarkGreen
        btnOK.ForeColor = Color.Black
        btnOK.Location = New Point(459, 377)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(102, 23)
        btnOK.TabIndex = 0
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = False
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
        Label3.Size = New Size(75, 15)
        Label3.TabIndex = 6
        Label3.Text = "Position (x,y)"
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
        txtPositionY.Location = New Point(147, 61)
        txtPositionY.Name = "txtPositionY"
        txtPositionY.Size = New Size(38, 23)
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
        Label5.Size = New Size(24, 15)
        Label5.TabIndex = 10
        Label5.Text = "cm"
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
        chkBlend.Location = New Point(6, 104)
        chkBlend.Name = "chkBlend"
        chkBlend.Size = New Size(56, 19)
        chkBlend.TabIndex = 17
        chkBlend.Text = "Blend"
        chkBlend.UseVisualStyleBackColor = True
        ' 
        ' btnC1
        ' 
        btnC1.Location = New Point(6, 22)
        btnC1.Name = "btnC1"
        btnC1.Size = New Size(20, 20)
        btnC1.TabIndex = 18
        btnC1.UseVisualStyleBackColor = True
        ' 
        ' btnC5
        ' 
        btnC5.Location = New Point(51, 48)
        btnC5.Name = "btnC5"
        btnC5.Size = New Size(20, 20)
        btnC5.TabIndex = 19
        btnC5.UseVisualStyleBackColor = True
        ' 
        ' btnC4
        ' 
        btnC4.Location = New Point(6, 48)
        btnC4.Name = "btnC4"
        btnC4.Size = New Size(20, 20)
        btnC4.TabIndex = 20
        btnC4.UseVisualStyleBackColor = True
        ' 
        ' btnC3
        ' 
        btnC3.Location = New Point(96, 22)
        btnC3.Name = "btnC3"
        btnC3.Size = New Size(20, 20)
        btnC3.TabIndex = 21
        btnC3.UseVisualStyleBackColor = True
        ' 
        ' btnC2
        ' 
        btnC2.Location = New Point(51, 22)
        btnC2.Name = "btnC2"
        btnC2.Size = New Size(20, 20)
        btnC2.TabIndex = 22
        btnC2.UseVisualStyleBackColor = True
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(12, 178)
        Label11.Name = "Label11"
        Label11.Size = New Size(37, 15)
        Label11.TabIndex = 25
        Label11.Text = "Effect"
        ' 
        ' cmbEffect
        ' 
        cmbEffect.FormattingEnabled = True
        cmbEffect.Items.AddRange(New Object() {"Twinkle - Willekeurig fonkelen van LEDs (sterren, romantiek, rust).", "Flicker - Onregelmatig knipperende lampen, perfect voor stroomstoringen", "FadePulse - Zachte op- en afbouw in helderheid, bruikbaar voor ademend licht of rustmomenten.", "FloodFill - Geleidelijke LED-opvulling van onder naar boven (bijv. water dat stijgt).", "TiltedFlood - Schuin vollopen water, met verloop (voor het hellende schi", "WaterWave  Horizontale golfbeweging met zacht verloop.", "DripEffect - Druppelachtig langzaam vollopen, beetje als lekkage, met fade-ins.", "RisingTwinkle  - Zoals Twinkle, maar pas zichtbaar vanaf bepaald waterniveau.", "SunsetFade - Warm verloop van geel/oranje/rood met afnemende intensiteit. Ideaal voor scènes als Wat een bijzondere eeuw.", "Nightfall - Langzame overgang naar diepblauw met twinkling stars.", "DawnBreak - Omgekeerde van sunset: opkomend licht in koude pastelkleuren.", "AlarmFlash - Flitsend patroon ", "Sirenwave -  doorlopende golf (zoals politielicht, maar subtieler).", "ShortCircuit -  Simulatie van kortsluiting: snel, heftig flikkerend licht, gevolgd door duisternis.", "ImpactFlash - Eén intense witte flits met naschokken van licht, als botsing.", "Heathbeat - Langzame pulse ", "GhostFade - Langzaam verschijnend/wisselend licht — zielen aan dek of herinneringen", "Frozen - Ijzige, knipperende blauw-witte koude gloed.", "EchoFade - Stappen-achtig uitvagend licht, alsof het geheugen verdwijnt.", "LastBreath - Licht dooft in drie pulsen — ideaal als slot of bij individuele sterfscènes."})
        cmbEffect.Location = New Point(95, 175)
        cmbEffect.Name = "cmbEffect"
        cmbEffect.Size = New Size(124, 23)
        cmbEffect.TabIndex = 24
        ' 
        ' tbBrightnessEffect
        ' 
        tbBrightnessEffect.LargeChange = 10
        tbBrightnessEffect.Location = New Point(79, 44)
        tbBrightnessEffect.Maximum = 100
        tbBrightnessEffect.Name = "tbBrightnessEffect"
        tbBrightnessEffect.Size = New Size(124, 45)
        tbBrightnessEffect.TabIndex = 30
        tbBrightnessEffect.TickFrequency = 10
        ' 
        ' tvGroupsSelected
        ' 
        tvGroupsSelected.BackColor = Color.DimGray
        tvGroupsSelected.BorderStyle = BorderStyle.None
        tvGroupsSelected.CheckBoxes = True
        tvGroupsSelected.ForeColor = SystemColors.Menu
        tvGroupsSelected.Location = New Point(380, 36)
        tvGroupsSelected.Name = "tvGroupsSelected"
        tvGroupsSelected.Size = New Size(178, 325)
        tvGroupsSelected.TabIndex = 29
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(380, 13)
        Label14.Name = "Label14"
        Label14.Size = New Size(52, 15)
        Label14.TabIndex = 30
        Label14.Text = "Apply to"
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.DarkRed
        btnCancel.ForeColor = Color.Black
        btnCancel.Location = New Point(378, 377)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 31
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(191, 64)
        Label15.Name = "Label15"
        Label15.Size = New Size(24, 15)
        Label15.TabIndex = 32
        Label15.Text = "cm"
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
        gbEffectsStartPosition.Location = New Point(240, 276)
        gbEffectsStartPosition.Name = "gbEffectsStartPosition"
        gbEffectsStartPosition.Size = New Size(122, 129)
        gbEffectsStartPosition.TabIndex = 33
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
        gbEffectDirection.Location = New Point(240, 141)
        gbEffectDirection.Name = "gbEffectDirection"
        gbEffectDirection.Size = New Size(122, 129)
        gbEffectDirection.TabIndex = 34
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
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(btnC1)
        GroupBox2.Controls.Add(btnC2)
        GroupBox2.Controls.Add(btnC3)
        GroupBox2.Controls.Add(btnC4)
        GroupBox2.Controls.Add(btnC5)
        GroupBox2.Controls.Add(chkBlend)
        GroupBox2.ForeColor = SystemColors.Control
        GroupBox2.Location = New Point(240, 6)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(122, 129)
        GroupBox2.TabIndex = 34
        GroupBox2.TabStop = False
        GroupBox2.Text = "Colors"
        ' 
        ' tbEffectSpeed
        ' 
        tbEffectSpeed.LargeChange = 10
        tbEffectSpeed.Location = New Point(89, 315)
        tbEffectSpeed.Maximum = 100
        tbEffectSpeed.Name = "tbEffectSpeed"
        tbEffectSpeed.Size = New Size(124, 45)
        tbEffectSpeed.TabIndex = 32
        tbEffectSpeed.TickFrequency = 10
        ' 
        ' TBEffectIntensity
        ' 
        TBEffectIntensity.LargeChange = 10
        TBEffectIntensity.Location = New Point(89, 346)
        TBEffectIntensity.Maximum = 100
        TBEffectIntensity.Name = "TBEffectIntensity"
        TBEffectIntensity.Size = New Size(124, 45)
        TBEffectIntensity.TabIndex = 35
        TBEffectIntensity.TickFrequency = 10
        ' 
        ' TBEffectDispersion
        ' 
        TBEffectDispersion.LargeChange = 10
        TBEffectDispersion.Location = New Point(88, 376)
        TBEffectDispersion.Maximum = 100
        TBEffectDispersion.Name = "TBEffectDispersion"
        TBEffectDispersion.Size = New Size(124, 45)
        TBEffectDispersion.TabIndex = 37
        TBEffectDispersion.TickFrequency = 10
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(17, 320)
        Label10.Name = "Label10"
        Label10.Size = New Size(39, 15)
        Label10.TabIndex = 38
        Label10.Text = "Speed"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(17, 346)
        Label16.Name = "Label16"
        Label16.Size = New Size(52, 15)
        Label16.TabIndex = 39
        Label16.Text = "Intensity"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(17, 376)
        Label17.Name = "Label17"
        Label17.Size = New Size(62, 15)
        Label17.TabIndex = 40
        Label17.Text = "Dispersion"
        ' 
        ' tbBrightnessBaseline
        ' 
        tbBrightnessBaseline.LargeChange = 10
        tbBrightnessBaseline.Location = New Point(79, 17)
        tbBrightnessBaseline.Maximum = 100
        tbBrightnessBaseline.Name = "tbBrightnessBaseline"
        tbBrightnessBaseline.Size = New Size(124, 45)
        tbBrightnessBaseline.TabIndex = 28
        tbBrightnessBaseline.TickFrequency = 10
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(19, 20)
        Label12.Name = "Label12"
        Label12.Size = New Size(50, 15)
        Label12.TabIndex = 29
        Label12.Text = "Baseline"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(19, 45)
        Label13.Name = "Label13"
        Label13.Size = New Size(42, 15)
        Label13.TabIndex = 31
        Label13.Text = "Effects"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(5, -3)
        Label18.Name = "Label18"
        Label18.Size = New Size(62, 15)
        Label18.TabIndex = 41
        Label18.Text = "Brightness"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label18)
        Panel1.Controls.Add(tbBrightnessEffect)
        Panel1.Controls.Add(tbBrightnessBaseline)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(Label13)
        Panel1.Location = New Point(12, 217)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(207, 84)
        Panel1.TabIndex = 42
        ' 
        ' DetailLightSource
        ' 
        AcceptButton = btnOK
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        CancelButton = btnCancel
        ClientSize = New Size(573, 415)
        ControlBox = False
        Controls.Add(Panel1)
        Controls.Add(Label17)
        Controls.Add(Label16)
        Controls.Add(Label10)
        Controls.Add(TBEffectDispersion)
        Controls.Add(TBEffectIntensity)
        Controls.Add(tbEffectSpeed)
        Controls.Add(GroupBox2)
        Controls.Add(gbEffectsStartPosition)
        Controls.Add(gbEffectDirection)
        Controls.Add(Label15)
        Controls.Add(btnCancel)
        Controls.Add(Label14)
        Controls.Add(tvGroupsSelected)
        Controls.Add(Label11)
        Controls.Add(cmbEffect)
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
        FormBorderStyle = FormBorderStyle.SizableToolWindow
        MaximizeBox = False
        MdiChildrenMinimizedAnchorBottom = False
        MinimizeBox = False
        Name = "DetailLightSource"
        Opacity = 0.5R
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "Details"
        CType(tbBrightnessEffect, ComponentModel.ISupportInitialize).EndInit()
        gbEffectsStartPosition.ResumeLayout(False)
        gbEffectsStartPosition.PerformLayout()
        gbEffectDirection.ResumeLayout(False)
        gbEffectDirection.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(tbEffectSpeed, ComponentModel.ISupportInitialize).EndInit()
        CType(TBEffectIntensity, ComponentModel.ISupportInitialize).EndInit()
        CType(TBEffectDispersion, ComponentModel.ISupportInitialize).EndInit()
        CType(tbBrightnessBaseline, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
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
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbEffect As ComboBox
    Friend WithEvents tbBrightnessEffect As TrackBar
    Friend WithEvents tvGroupsSelected As TreeView
    Friend WithEvents Label14 As Label
    Friend WithEvents btnCancel As Button
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tbEffectSpeed As TrackBar
    Friend WithEvents TBEffectIntensity As TrackBar
    Friend WithEvents TBEffectDispersion As TrackBar
    Friend WithEvents Label10 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents tbBrightnessBaseline As TrackBar
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel1 As Panel
End Class
