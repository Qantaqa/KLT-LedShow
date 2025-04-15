<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopUp_Scannen
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Label1 = New Label()
        ProgressBar = New ProgressBar()
        Label2 = New Label()
        Label3 = New Label()
        lblFound = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.Info
        Label1.Location = New Point(183, 17)
        Label1.Name = "Label1"
        Label1.Size = New Size(166, 18)
        Label1.TabIndex = 0
        Label1.Text = "Scanning network"
        ' 
        ' ProgressBar
        ' 
        ProgressBar.Location = New Point(103, 62)
        ProgressBar.Name = "ProgressBar"
        ProgressBar.Size = New Size(392, 23)
        ProgressBar.Style = ProgressBarStyle.Marquee
        ProgressBar.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(14, 70)
        Label2.Name = "Label2"
        Label2.Size = New Size(52, 15)
        Label2.TabIndex = 2
        Label2.Text = "Progress"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(13, 91)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 15)
        Label3.TabIndex = 3
        Label3.Text = "WLed's found:"
        ' 
        ' lblFound
        ' 
        lblFound.AutoSize = True
        lblFound.Location = New Point(103, 91)
        lblFound.Name = "lblFound"
        lblFound.Size = New Size(34, 15)
        lblFound.TabIndex = 4
        lblFound.Text = "none"
        ' 
        ' PopUp_Scannen
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Highlight
        Controls.Add(lblFound)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(ProgressBar)
        Controls.Add(Label1)
        Name = "PopUp_Scannen"
        Size = New Size(516, 138)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblFound As Label

End Class
