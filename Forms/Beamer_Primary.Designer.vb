<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Beamer_Primary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Beamer_Primary))
        WMP_PrimaryPlayer_Live = New AxWMPLib.AxWindowsMediaPlayer()
        CType(WMP_PrimaryPlayer_Live, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' WMP_PrimaryPlayer_Live
        ' 
        WMP_PrimaryPlayer_Live.Dock = DockStyle.Fill
        WMP_PrimaryPlayer_Live.Enabled = True
        WMP_PrimaryPlayer_Live.Location = New Point(0, 0)
        WMP_PrimaryPlayer_Live.Name = "WMP_PrimaryPlayer_Live"
        WMP_PrimaryPlayer_Live.OcxState = CType(resources.GetObject("WMP_PrimaryPlayer_Live.OcxState"), AxHost.State)
        WMP_PrimaryPlayer_Live.Size = New Size(800, 450)
        WMP_PrimaryPlayer_Live.TabIndex = 5
        ' 
        ' Beamer_Primary
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(800, 450)
        Controls.Add(WMP_PrimaryPlayer_Live)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Name = "Beamer_Primary"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Beamer_1"
        CType(WMP_PrimaryPlayer_Live, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents WMP_PrimaryPlayer_Live As AxWMPLib.AxWindowsMediaPlayer
End Class
