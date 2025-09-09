Imports System.Windows.Forms

Module Template
    ' Entry point to be called from FrmMain.btnEditTemplate_Click
    Public Sub EditSelectedTemplate()
        Dim grid = FrmMain.DG_Templates
        If grid Is Nothing Then
            MessageBox.Show("DG_Templates grid is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim row As DataGridViewRow = GetSelectedTemplateRow()
        If row Is Nothing Then
            MessageBox.Show("Select a template first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Resolve columns in a resilient way
        Dim colName = FindColumn(grid, "colTemplateName", "TemplateName", "Name")
        Dim colDesc = FindColumn(grid, "colTemplateDescription", "TemplateDescription", "Description", "Desc")
        Dim colDuration = FindColumn(grid, "colTemplateDuration", "Duration", "Seconds", "DurationSec")
        Dim colRepeat = FindColumn(grid, "colTemplateRepeat", "Repeat", "IsRepeat", "RepeatFlag")
        Dim colDDP = FindColumn(grid, "colDDPData", "TemplateDDPData", "DDPData")

        If colName Is Nothing Then
            MessageBox.Show("Could not find the 'Name' column in DG_Templates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Read current values
        Dim nameVal As String = SafeStr(row.Cells(colName.Index).Value)
        Dim descVal As String = If(colDesc IsNot Nothing, SafeStr(row.Cells(colDesc.Index).Value), "")
        Dim durationVal As Integer = If(colDuration IsNot Nothing, SafeInt(row.Cells(colDuration.Index).Value, 0), 0)
        Dim repeatVal As Boolean = If(colRepeat IsNot Nothing, SafeBool(row.Cells(colRepeat.Index).Value, False), False)
        Dim ddpText As String = If(colDDP IsNot Nothing, SafeStr(row.Cells(colDDP.Index).Value), "(No DDPData column found)")

        Dim oldName As String = nameVal

        ' Show editor dialog
        Using dlg As New TemplateEditorForm(nameVal, descVal, durationVal, repeatVal, ddpText)
            dlg.StartPosition = FormStartPosition.CenterParent
            If dlg.ShowDialog(FrmMain) = DialogResult.OK Then
                ' Persist updates to the grid row
                row.Cells(colName.Index).Value = dlg.TemplateName
                If colDesc IsNot Nothing Then row.Cells(colDesc.Index).Value = dlg.Description
                If Not (IsNothing(colDuration)) Then row.Cells(colDuration.Index).Value = dlg.DurationSec
                If Not (IsNothing(colRepeat)) Then row.Cells(colRepeat.Index).Value = dlg.Repeat

                ' Refresh cbSelectedEffect content and keep selection coherent
                EffectBuilder.VulEffectCombo()

                    ' If the edited template was selected in the combo, update the selection to the new name
                    If String.Equals(FrmMain.cbSelectedEffect.Text, oldName, StringComparison.OrdinalIgnoreCase) Then
                        FrmMain.cbSelectedEffect.Text = dlg.TemplateName
                    End If
                End If
        End Using
    End Sub

    Private Function GetSelectedTemplateRow() As DataGridViewRow
        Dim grid = FrmMain.DG_Templates
        If grid.CurrentRow IsNot Nothing AndAlso Not grid.CurrentRow.IsNewRow Then
            Return grid.CurrentRow
        End If

        ' Fallback: resolve by cbSelectedEffect
        Dim selectedName As String = FrmMain.cbSelectedEffect.Text
        If Not String.IsNullOrWhiteSpace(selectedName) Then
            Dim nameCol = FindColumn(grid, "colTemplateName", "TemplateName", "Name")
            If nameCol IsNot Nothing Then
                For Each r As DataGridViewRow In grid.Rows
                    If r.IsNewRow Then Continue For
                    If String.Equals(SafeStr(r.Cells(nameCol.Index).Value), selectedName, StringComparison.OrdinalIgnoreCase) Then
                        Return r
                    End If
                Next
            End If
        End If
        Return Nothing
    End Function

    Private Function FindColumn(grid As DataGridView, ParamArray candidates() As String) As DataGridViewColumn
        ' Try exact name first
        For Each c In candidates
            If grid.Columns.Contains(c) Then Return grid.Columns(c)
        Next

        ' Then try contains
        For Each col As DataGridViewColumn In grid.Columns
            For Each c In candidates
                If col.Name.IndexOf(c, StringComparison.OrdinalIgnoreCase) >= 0 Then
                    Return col
                End If
            Next
        Next

        ' As a last resort, try header text
        For Each col As DataGridViewColumn In grid.Columns
            For Each c In candidates
                If (Not String.IsNullOrEmpty(col.HeaderText)) AndAlso col.HeaderText.IndexOf(c, StringComparison.OrdinalIgnoreCase) >= 0 Then
                    Return col
                End If
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
            Return defVal
        Catch
            Return defVal
        End Try
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
            If Integer.TryParse(s, Nothing) Then Return (CInt(s) <> 0)
            Return defVal
        Catch
            Return defVal
        End Try
    End Function

    ' Simple runtime-built dialog
    Private NotInheritable Class TemplateEditorForm
        Inherits Form

        Private ReadOnly txtName As New TextBox()
        Private ReadOnly txtDesc As New TextBox()
        Private ReadOnly nudDuration As New NumericUpDown()
        Private ReadOnly chkRepeat As New CheckBox()
        Private ReadOnly txtDDP As New TextBox()
        Private ReadOnly btnOK As New Button()
        Private ReadOnly btnCancel As New Button()

        Public ReadOnly Property TemplateName As String
            Get
                Return txtName.Text.Trim()
            End Get
        End Property

        Public ReadOnly Property Description As String
            Get
                Return txtDesc.Text
            End Get
        End Property

        Public ReadOnly Property DurationSec As Integer
            Get
                Return CInt(nudDuration.Value)
            End Get
        End Property

        Public ReadOnly Property Repeat As Boolean
            Get
                Return chkRepeat.Checked
            End Get
        End Property

        Public Sub New(nameVal As String, descVal As String, durationVal As Integer, repeatVal As Boolean, ddpText As String)
            Me.Text = "Edit Template"
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MinimizeBox = False
            Me.MaximizeBox = False
            Me.ShowInTaskbar = False
            Me.Width = 640
            Me.Height = 520

            ' Labels
            Dim lblName As New Label() With {.Text = "Name:", .AutoSize = True, .Left = 12, .Top = 15}
            Dim lblDesc As New Label() With {.Text = "Description:", .AutoSize = True, .Left = 12, .Top = 50}
            Dim lblDuration As New Label() With {.Text = "Duration (sec):", .AutoSize = True, .Left = 12, .Top = 230}
            Dim lblRepeat As New Label() With {.Text = "Repeat:", .AutoSize = True, .Left = 12, .Top = 265}
            Dim lblDDP As New Label() With {.Text = "DDP Data (read-only):", .AutoSize = True, .Left = 12, .Top = 300}

            ' Inputs
            txtName.Left = 140 : txtName.Top = 12 : txtName.Width = 460
            txtName.Text = nameVal

            txtDesc.Left = 140 : txtDesc.Top = 48 : txtDesc.Width = 460 : txtDesc.Height = 160
            txtDesc.Multiline = True : txtDesc.ScrollBars = ScrollBars.Vertical
            txtDesc.Text = descVal

            nudDuration.Left = 140 : nudDuration.Top = 228 : nudDuration.Width = 120
            nudDuration.Minimum = 0 : nudDuration.Maximum = 3600 : nudDuration.Value = Math.Max(Math.Min(durationVal, 3600), 0)

            chkRepeat.Left = 140 : chkRepeat.Top = 262 : chkRepeat.Width = 20
            chkRepeat.Checked = repeatVal

            txtDDP.Left = 12 : txtDDP.Top = 320 : txtDDP.Width = 588 : txtDDP.Height = 120
            txtDDP.Multiline = True : txtDDP.ScrollBars = ScrollBars.Both : txtDDP.ReadOnly = True : txtDDP.Text = ddpText
            txtDDP.WordWrap = False

            ' Buttons
            btnOK.Text = "OK" : btnOK.Left = Me.ClientSize.Width - 180 : btnOK.Top = Me.ClientSize.Height - 36 : btnOK.Width = 80
            btnCancel.Text = "Cancel" : btnCancel.Left = Me.ClientSize.Width - 90 : btnCancel.Top = Me.ClientSize.Height - 36 : btnCancel.Width = 80

            AddHandler btnOK.Click, AddressOf OnOk
            AddHandler btnCancel.Click, Sub() Me.DialogResult = DialogResult.Cancel

            Me.AcceptButton = btnOK
            Me.CancelButton = btnCancel

            ' Layout anchoring
            txtName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            txtDesc.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            txtDDP.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            btnOK.Anchor = AnchorStyles.Right Or AnchorStyles.Bottom
            btnCancel.Anchor = AnchorStyles.Right Or AnchorStyles.Bottom

            ' Add controls
            Me.Controls.AddRange(New Control() {
                lblName, txtName,
                lblDesc, txtDesc,
                lblDuration, nudDuration,
                lblRepeat, chkRepeat,
                lblDDP, txtDDP,
                btnOK, btnCancel
            })
        End Sub

        Private Sub OnOk(sender As Object, e As EventArgs)
            If String.IsNullOrWhiteSpace(txtName.Text) Then
                MessageBox.Show("Name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtName.Focus()
                Return
            End If
            Me.DialogResult = DialogResult.OK
        End Sub
    End Class
End Module