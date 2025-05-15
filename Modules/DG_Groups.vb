Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

' Deze module bevat functionaliteit voor het beheren van LED-groepen.
Module DG_Groups

    '*********************************************************************************************
    '  GroupAddRowAfter
    '  Voegt een nieuwe rij toe aan de DataGridView na de geselecteerde rij.
    '*********************************************************************************************
    Public Sub GroupAddRowAfter(ByVal DG_Groups As DataGridView)
        'Voeg hier de logica toe om een nieuwe rij na de huidige rij toe te voegen
        Dim currentRowIndex As Integer = 0

        If DG_Groups.Rows.Count > 0 Then
            currentRowIndex = DG_Groups.CurrentCell.RowIndex
            DG_Groups.Rows.Insert(currentRowIndex + 1, 1) 'Voegt een nieuwe rij in na de huidige rij
        Else
            DG_Groups.Rows.Insert(0, 1) 'Voegt een nieuwe rij in op de gespecificeerde index
            currentRowIndex = -1
        End If


        'Stel de focus op de nieuwe rij
        DG_Groups.CurrentCell = DG_Groups.Rows(currentRowIndex + 1).Cells(0)

    End Sub

    '*********************************************************************************************
    '  GroupAddRowBefore
    '  Voegt een nieuwe rij toe aan de DataGridView voor de geselecteerde rij.
    '*********************************************************************************************
    Public Sub GroupAddRowBefore(ByVal dgv As DataGridView)
        If dgv.CurrentCell IsNot Nothing Then
            Dim currentIndex = dgv.CurrentCell.RowIndex
            dgv.Rows.Insert(currentIndex, "", "", 1, 1, 0) ' Voeg een nieuwe rij in op de huidige index.
        Else
            dgv.Rows.Add("", "", 1, 1, 0) ' Voeg een nieuwe rij toe aan het einde als er geen rij is geselecteerd.
        End If
    End Sub

    '*********************************************************************************************
    '  GroupDeleteRow
    '  Verwijdert de geselecteerde rij uit de DataGridView.
    '*********************************************************************************************
    Public Sub GroupDeleteRow(ByVal dgv As DataGridView)
        If dgv.CurrentCell IsNot Nothing Then
            Dim currentIndex = dgv.CurrentCell.RowIndex
            If dgv.Rows.Count > 0 Then
                dgv.Rows.RemoveAt(currentIndex) ' Verwijder de geselecteerde rij.
            End If
        End If
    End Sub

    '*********************************************************************************************
    ' SplitIntoGroups
    ' Splitst de apparaten in groepen op basis van hun lay-out en voegt ze toe aan de groepen DataGridView.
    '*********************************************************************************************
    Public Sub SplitIntoGroups(ByVal dgDevices As DataGridView, ByVal dgGroups As DataGridView)
        dgGroups.Rows.Clear()
        Dim globalId As Integer = 1

        For Each devRow As DataGridViewRow In dgDevices.Rows
            If devRow.IsNewRow Then Continue For

            Dim fixtureName = Convert.ToString(devRow.Cells("colInstance").Value)
            Dim rawLayout = Convert.ToString(devRow.Cells("colLayout").Value)
            If String.IsNullOrWhiteSpace(fixtureName) OrElse String.IsNullOrWhiteSpace(rawLayout) Then Continue For

            Dim totalLeds As Integer = 1
            Integer.TryParse(Convert.ToString(devRow.Cells("colLedCount").Value), totalLeds)

            ' Voeg parentgroep toe
            Dim parentId = globalId
            dgGroups.Rows.Add(parentId, 0, fixtureName, fixtureName, 1, totalLeds, 0, Nothing, Nothing, FrmMain.cbEffectRepeat.Checked, rawLayout)
            globalId += 1

            ' Layout opsplitsen
            Dim segments = ValidateLayoutString(rawLayout).Split(","c).
            Select(Function(s) s.Trim().ToUpper()).
            Where(Function(s) s.Length > 0).ToList()

            Dim currentStart As Integer = 1
            Dim groupStart As Integer = -1
            Dim groupLayout As New List(Of String)
            Dim orderInFixture As Integer = 1

            ' Laatst bekende X/Y
            Dim lastX As String = Nothing
            Dim lastY As String = Nothing

            For Each seg In segments
                Dim isX = seg.StartsWith("X")
                Dim isY = seg.StartsWith("Y")
                Dim isReset = isX OrElse isY
                Dim num = 0

                If Not isReset Then
                    Integer.TryParse(New String(seg.Where(AddressOf Char.IsDigit).ToArray()), num)
                End If

                If isReset Then
                    ' Sla X/Y op voor later gebruik
                    If isX Then lastX = seg
                    If isY Then lastY = seg

                    ' Sluit actieve groep af
                    If groupStart > 0 AndAlso groupLayout.Count > 0 Then
                        Dim finalLayout = New List(Of String)(groupLayout)
                        ' Injecteer ontbrekende X/Y
                        If Not finalLayout.Any(Function(s) s.StartsWith("X")) AndAlso lastX IsNot Nothing Then finalLayout.Insert(0, lastX)
                        If Not finalLayout.Any(Function(s) s.StartsWith("Y")) AndAlso lastY IsNot Nothing Then
                            Dim insertAt = If(finalLayout.Count > 0 AndAlso finalLayout(0).StartsWith("X"), 1, 0)
                            finalLayout.Insert(insertAt, lastY)
                        End If

                        Dim grpName = $"{fixtureName}-Group{orderInFixture}"
                        dgGroups.Rows.Add(globalId, parentId, grpName, fixtureName, groupStart, currentStart - 1, orderInFixture, Nothing, Nothing, FrmMain.cbEffectRepeat.Checked, String.Join(",", finalLayout))
                        globalId += 1
                        orderInFixture += 1
                        groupLayout.Clear()
                        groupStart = -1
                    End If

                    groupLayout.Add(seg)
                Else
                    If groupStart < 0 Then groupStart = currentStart
                    groupLayout.Add(seg)
                    currentStart += num
                End If
            Next

            ' Sluit laatste groep
            If groupStart > 0 AndAlso groupLayout.Count > 0 Then
                Dim finalLayout = New List(Of String)(groupLayout)
                If Not finalLayout.Any(Function(s) s.StartsWith("X")) AndAlso lastX IsNot Nothing Then finalLayout.Insert(0, lastX)
                If Not finalLayout.Any(Function(s) s.StartsWith("Y")) AndAlso lastY IsNot Nothing Then
                    Dim insertAt = If(finalLayout.Count > 0 AndAlso finalLayout(0).StartsWith("X"), 1, 0)
                    finalLayout.Insert(insertAt, lastY)
                End If

                Dim grpName = $"{fixtureName}-Group{orderInFixture}"
                dgGroups.Rows.Add(globalId, parentId, grpName, fixtureName, groupStart, currentStart - 1, orderInFixture, Nothing, Nothing, FrmMain.cbEffectRepeat.Checked, String.Join(",", finalLayout))
                globalId += 1
            End If
        Next
    End Sub


    '*********************************************************************************************
    ' populateFixtureDropdown_InGroups
    ' Vul de fixture dropdown in de groepen DataGridView met unieke fixture-namen.
    '*********************************************************************************************
    Public Sub PopulateFixtureDropdown_InGroups(ByVal dgDevices As DataGridView, ByVal dgGroups As DataGridView)
        ' Verzamelen unieke fixture-namen
        Dim fixtures = dgDevices.Rows.Cast(Of DataGridViewRow)() _
                         .Where(Function(r) Not r.IsNewRow) _
                         .Select(Function(r) Convert.ToString(r.Cells("colInstance").Value)) _
                         .Where(Function(n) Not String.IsNullOrEmpty(n)) _
                         .Distinct() _
                         .ToList()
        ' Zorg dat kolom colGroupFixture een ComboBox-kolom is
        Dim col = TryCast(dgGroups.Columns("colGroupFixture"), DataGridViewComboBoxColumn)
        If col Is Nothing Then
            ' Vervang bestaande kolom door ComboBox             delete old >= assume exists
            Dim idx = dgGroups.Columns("colGroupFixture").Index
            dgGroups.Columns.RemoveAt(idx)
            Dim combo As New DataGridViewComboBoxColumn() With {
                .Name = "colGroupFixture",
                .HeaderText = "Fixture",
                .DataPropertyName = "colGroupFixture",
                .DataSource = fixtures
            }
            dgGroups.Columns.Insert(idx, combo)
        Else
            col.DataSource = fixtures
        End If
    End Sub


    '*********************************************************************************************
    ' PopulateTreeView
    ' Vul de TreeView met groepen op basis van de DataGridView.
    '*********************************************************************************************
    Public Sub PopulateTreeView(ByVal dgGroups As DataGridView, ByVal tvGroups As TreeView)

        tvGroups.BeginUpdate()
        tvGroups.Nodes.Clear()
        ' Dictionary om groupId naar TreeNode te mappen
        Dim nodeMap As New Dictionary(Of Integer, TreeNode)()
        For Each row As DataGridViewRow In dgGroups.Rows
            If row.IsNewRow Then Continue For
            Dim id As Integer = Convert.ToInt32(row.Cells("colGroupId").Value)
            Dim parentId As Integer = Convert.ToInt32(row.Cells("colGroupParentId").Value)
            Dim name As String = Convert.ToString(row.Cells("colGroupName").Value)

            Dim node As New TreeNode(name) With {
                    .Name = id.ToString(),
                    .Tag = id
            }
            nodeMap(id) = node

            ' Voeg toe aan boom
            If parentId = 0 Then
                tvGroups.Nodes.Add(node)
            ElseIf nodeMap.ContainsKey(parentId) Then
                nodeMap(parentId).Nodes.Add(node)
            End If
        Next
        tvGroups.ExpandAll()
        tvGroups.EndUpdate()
    End Sub



End Module
