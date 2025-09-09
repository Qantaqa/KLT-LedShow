Imports System.Windows.Forms

Module Tracks
    Private _initialized As Boolean

    ' Call once (e.g., after EffectBuilder.Initialize in FrmMain_Load)
    Public Sub Initialize()
        If _initialized Then Return
        AddHandler EffectBuilder.TrackClicked, AddressOf OnTrackClicked
        _initialized = True
    End Sub

    Private Sub OnTrackClicked(trackId As Integer)
        If trackId < 0 Then Return
        EditTrackById(trackId)
    End Sub

    Public Sub EditTrackById(trackId As Integer)
        Dim tracks = FrmMain.DG_Tracks
        If tracks Is Nothing Then Return

        Dim colTrackId = FindColumn(tracks, "colTrackId", "colTrackID", "TrackId", "ID")
        Dim colTrackName = FindColumn(tracks, "colTrackName", "TrackName", "Name")
        Dim colTrackActive = FindColumn(tracks, "colTrackActive", "Active")
        Dim colTrackTemplateId = FindColumn(tracks, "colTrackMEId", "colTrackTemplateId", "TemplateId", "MEId")

        If colTrackId Is Nothing OrElse colTrackName Is Nothing OrElse colTrackActive Is Nothing Then
            MessageBox.Show("DG_Tracks mist vereiste kolommen (Id/Name/Active).", "Tracks", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim row As DataGridViewRow = Nothing
        For Each r As DataGridViewRow In tracks.Rows
            If r.IsNewRow Then Continue For
            If SafeInt(r.Cells(colTrackId.Index).Value, -1) = trackId Then
                row = r
                Exit For
            End If
        Next
        If row Is Nothing Then Return

        Dim trackName As String = SafeStr(row.Cells(colTrackName.Index).Value)
        Dim trackActive As Boolean = SafeBool(row.Cells(colTrackActive.Index).Value, False)
        Dim templateId As Integer = If(colTrackTemplateId IsNot Nothing, SafeInt(row.Cells(colTrackTemplateId.Index).Value, -1), -1)
        Dim templateName As String = ResolveTemplateName(templateId)

        Using dlg As New TrackEditorForm(trackId, templateName, trackName, trackActive)
            dlg.StartPosition = FormStartPosition.CenterParent
            If dlg.ShowDialog(FrmMain) = DialogResult.OK Then
                row.Cells(colTrackName.Index).Value = dlg.TrackName
                row.Cells(colTrackActive.Index).Value = dlg.IsActive
                EffectBuilder.RefreshTimeline()
            End If
        End Using
    End Sub

    Private Function ResolveTemplateName(templateId As Integer) As String
        If templateId < 0 Then Return "(none)"
        Dim tGrid = FrmMain.DG_Templates
        If tGrid Is Nothing Then Return "(none)"
        Dim colTplId = FindColumn(tGrid, "colTemplateId", "TemplateId", "Id")
        Dim colTplName = FindColumn(tGrid, "colTemplateName", "TemplateName", "Name")
        If colTplId Is Nothing OrElse colTplName Is Nothing Then Return "(none)"
        For Each r As DataGridViewRow In tGrid.Rows
            If r.IsNewRow Then Continue For
            If SafeInt(r.Cells(colTplId.Index).Value, -1) = templateId Then
                Return SafeStr(r.Cells(colTplName.Index).Value)
            End If
        Next
        Return "(none)"
    End Function

    Private Function FindColumn(grid As DataGridView, ParamArray candidates() As String) As DataGridViewColumn
        For Each c In candidates
            If grid.Columns.Contains(c) Then Return grid.Columns(c)
        Next
        For Each col As DataGridViewColumn In grid.Columns
            For Each c In candidates
                If col.Name.IndexOf(c, StringComparison.OrdinalIgnoreCase) >= 0 Then Return col
                If Not String.IsNullOrEmpty(col.HeaderText) AndAlso col.HeaderText.IndexOf(c, StringComparison.OrdinalIgnoreCase) >= 0 Then Return col
            Next
        Next
        Return Nothing
    End Function

    Private Function SafeStr(v As Object) As String
        If v Is Nothing OrElse v Is DBNull.Value Then Return ""
        Return Convert.ToString(v)
    End Function

    Private Function SafeInt(v As Object, defVal As Integer) As Integer
        Try
            If v Is Nothing OrElse v Is DBNull.Value Then Return defVal
            If TypeOf v Is Integer Then Return CInt(v)
            If TypeOf v Is Long Then Return CInt(CLng(v))
            If TypeOf v Is Decimal Then Return CInt(CDec(v))
            If TypeOf v Is Double Then Return CInt(CDbl(v))
            Dim s = Convert.ToString(v)
            If String.IsNullOrWhiteSpace(s) Then Return defVal
            Dim n As Integer
            If Integer.TryParse(s, n) Then Return n
        Catch
        End Try
        Return defVal
    End Function

    Private Function SafeBool(v As Object, defVal As Boolean) As Boolean
        Try
            If v Is Nothing OrElse v Is DBNull.Value Then Return defVal
            If TypeOf v Is Boolean Then Return CBool(v)
            If TypeOf v Is Integer Then Return (CInt(v) <> 0)
            Dim s = Convert.ToString(v)
            If String.IsNullOrWhiteSpace(s) Then Return defVal
            Dim b As Boolean
            If Boolean.TryParse(s, b) Then Return b
            Dim i As Integer
            If Integer.TryParse(s, i) Then Return (i <> 0)
        Catch
        End Try
        Return defVal
    End Function

    ' Simple runtime-built editor dialog for a track
    Private NotInheritable Class TrackEditorForm
        Inherits Form

        Private ReadOnly txtTrackId As New TextBox()
        Private ReadOnly txtTemplate As New TextBox()
        Private ReadOnly txtName As New TextBox()
        Private ReadOnly chkActive As New CheckBox()
        Private ReadOnly btnOK As New Button()
        Private ReadOnly btnCancel As New Button()

        Public ReadOnly Property TrackName As String
            Get
                Return txtName.Text.Trim()
            End Get
        End Property

        Public ReadOnly Property IsActive As Boolean
            Get
                Return chkActive.Checked
            End Get
        End Property

        Public Sub New(trackId As Integer, templateName As String, trackName As String, active As Boolean)
            Me.Text = "Edit Track"
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MinimizeBox = False
            Me.MaximizeBox = False
            Me.ShowInTaskbar = False
            Me.Width = 520
            Me.Height = 260

            Dim lblId As New Label() With {.Text = "Track ID:", .AutoSize = True, .Left = 12, .Top = 15}
            txtTrackId.Left = 120 : txtTrackId.Top = 12 : txtTrackId.Width = 360 : txtTrackId.ReadOnly = True
            txtTrackId.Text = trackId.ToString()

            Dim lblTpl As New Label() With {.Text = "Template:", .AutoSize = True, .Left = 12, .Top = 50}
            txtTemplate.Left = 120 : txtTemplate.Top = 48 : txtTemplate.Width = 360 : txtTemplate.ReadOnly = True
            txtTemplate.Text = templateName

            Dim lblName As New Label() With {.Text = "Track name:", .AutoSize = True, .Left = 12, .Top = 85}
            txtName.Left = 120 : txtName.Top = 82 : txtName.Width = 360 : txtName.Text = trackName

            Dim lblActive As New Label() With {.Text = "Active:", .AutoSize = True, .Left = 12, .Top = 120}
            chkActive.Left = 120 : chkActive.Top = 118 : chkActive.Checked = active

            btnOK.Text = "OK" : btnOK.Left = Me.ClientSize.Width - 180 : btnOK.Top = Me.ClientSize.Height - 36 : btnOK.Width = 80
            btnCancel.Text = "Cancel" : btnCancel.Left = Me.ClientSize.Width - 90 : btnCancel.Top = Me.ClientSize.Height - 36 : btnCancel.Width = 80

            AddHandler btnOK.Click, AddressOf OnOk
            AddHandler btnCancel.Click, Sub() Me.DialogResult = DialogResult.Cancel

            Me.AcceptButton = btnOK
            Me.CancelButton = btnCancel

            txtTrackId.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            txtTemplate.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            txtName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            btnOK.Anchor = AnchorStyles.Right Or AnchorStyles.Bottom
            btnCancel.Anchor = AnchorStyles.Right Or AnchorStyles.Bottom

            Me.Controls.AddRange(New Control() {
                lblId, txtTrackId,
                lblTpl, txtTemplate,
                lblName, txtName,
                lblActive, chkActive,
                btnOK, btnCancel
            })
        End Sub

        Private Sub OnOk(sender As Object, e As EventArgs)
            If String.IsNullOrWhiteSpace(txtName.Text) Then
                MessageBox.Show("Track name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtName.Focus()
                Return
            End If
            Me.DialogResult = DialogResult.OK
        End Sub
    End Class
End Module