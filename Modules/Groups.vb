Imports System.Windows.Forms

Module Groups
    Public Sub PopulateTreeView(tv As TreeView, dgGroups As DataGridView)
        If tv Is Nothing OrElse dgGroups Is Nothing Then Return

        tv.BeginUpdate()
        tv.Nodes.Clear()

        Dim colId = FindColumn(dgGroups, "colGroupId", "GroupId", "Id")
        Dim colParent = FindColumn(dgGroups, "colParentId", "colGroupParentId", "ParentId")
        Dim colName = FindColumn(dgGroups, "colGroupName", "GroupName", "Name")

        ' If we cannot identify an ID column, bail out gracefully
        If colId Is Nothing Then
            tv.Nodes.Add(New TreeNode("(no groups available)"))
            tv.EndUpdate()
            Return
        End If

        ' Build nodes dictionary
        Dim nodesById As New Dictionary(Of Integer, TreeNode)
        Dim parentById As New Dictionary(Of Integer, Integer)

        For Each r As DataGridViewRow In dgGroups.Rows
            If r.IsNewRow Then Continue For
            Dim id = SafeInt(r.Cells(colId.Index).Value, -1)
            If id < 0 Then Continue For

            Dim text As String = If(colName IsNot Nothing, SafeStr(r.Cells(colName.Index).Value), Nothing)
            If String.IsNullOrWhiteSpace(text) Then text = $"Group {id}"

            Dim n As New TreeNode(text) With {.Tag = id.ToString()}
            nodesById(id) = n

            If colParent IsNot Nothing Then
                Dim parentId = SafeInt(r.Cells(colParent.Index).Value, -1)
                If parentId > 0 Then parentById(id) = parentId
            End If
        Next

        ' Attach to parents when possible
        For Each kvp In nodesById
            Dim id = kvp.Key
            Dim node = kvp.Value
            Dim parentId As Integer = -1
            If parentById.TryGetValue(id, parentId) Then
                Dim parentNode As TreeNode = Nothing
                If nodesById.TryGetValue(parentId, parentNode) Then
                    parentNode.Nodes.Add(node)
                    Continue For
                End If
            End If
            ' No parent -> add as root
            tv.Nodes.Add(node)
        Next

        tv.ExpandAll()
        tv.EndUpdate()
    End Sub

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
            Dim n As Integer
            If Integer.TryParse(s, n) Then Return n
        Catch
        End Try
        Return defVal
    End Function
End Module