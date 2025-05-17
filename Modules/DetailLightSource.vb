Public Class DetailLightSource
    Public Property SelectedGroupIds As List(Of String)

    ' OK-button sluit het formulier met DialogResult.OK
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        SelectedGroupIds = New List(Of String)
        For Each node As TreeNode In tvGroupsSelected.Nodes
            CollectCheckedNodes(node, SelectedGroupIds)
        Next

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Public Sub CheckAndMarkNodes(nodes As TreeNodeCollection, selGroupIds As List(Of String))
        For Each node As TreeNode In nodes
            If node.Tag IsNot Nothing AndAlso selGroupIds.Contains(node.Tag.ToString()) Then
                node.Checked = True
            End If
            ' recursief in alle subnodes
            If node.Nodes.Count > 0 Then
                CheckAndMarkNodes(node.Nodes, selGroupIds)
            End If
        Next
    End Sub










    Private Sub CollectCheckedNodes(node As TreeNode, list As List(Of String))
        If node.Checked Then
            list.Add(node.Tag?.ToString())
        End If
        For Each child As TreeNode In node.Nodes
            CollectCheckedNodes(child, list)
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Optional: handle checking/unchecking of group nodes
    Private Sub tvGroupsSelected_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvGroupsSelected.AfterCheck
        ' If you want parent/child cascading:
        CheckAllChildNodes(e.Node, e.Node.Checked)
    End Sub

    Private Sub CheckAllChildNodes(node As TreeNode, isChecked As Boolean)
        For Each child As TreeNode In node.Nodes
            child.Checked = isChecked
            CheckAllChildNodes(child, isChecked)
        Next
    End Sub

    ' Color‐picker handlers for the 5 color buttons
    Private Sub btnC1_Click(sender As Object, e As EventArgs) Handles btnC1.Click
        PickColorForButton(btnC1)
    End Sub
    Private Sub btnC2_Click(sender As Object, e As EventArgs) Handles btnC2.Click
        PickColorForButton(btnC2)
    End Sub
    Private Sub btnC3_Click(sender As Object, e As EventArgs) Handles btnC3.Click
        PickColorForButton(btnC3)
    End Sub
    Private Sub btnC4_Click(sender As Object, e As EventArgs) Handles btnC4.Click
        PickColorForButton(btnC4)
    End Sub
    Private Sub btnC5_Click(sender As Object, e As EventArgs) Handles btnC5.Click
        PickColorForButton(btnC5)
    End Sub

    Private Sub PickColorForButton(btn As Button)
        Using dlg As New ColorDialog()
            dlg.Color = btn.BackColor
            If dlg.ShowDialog() = DialogResult.OK Then
                btn.BackColor = dlg.Color
            End If
        End Using
    End Sub

    Private Sub DetailLightSource_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        tvGroupsSelected.ExpandAll()
    End Sub


End Class