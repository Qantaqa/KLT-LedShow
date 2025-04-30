Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

' Deze module bevat functionaliteit voor het beheren van LED-groepen.
Module DG_Groups

    Public Sub UpdateFixuresPulldown_ForGroups(ByVal DG_Groups As DataGridView)
        Dim currentRow As DataGridViewRow
        If (DG_Groups.RowCount = 0) Then
            ' No show loaded yet, nothing to update
            Return
        Else
            currentRow = DG_Groups.Rows(DG_Groups.CurrentRow.Index)
        End If

        Dim fixtureColumn As DataGridViewComboBoxColumn = TryCast(DG_Groups.Columns("colGroupFixture"), DataGridViewComboBoxColumn)
        If fixtureColumn IsNot Nothing Then
            ' Clear de vorige items
            fixtureColumn.Items.Clear()

            ' Voeg de WLED devices en segmenten toe aan de dropdown list
            For Each kvp In DG_Devices.wledDevices
                Dim ipAddress As String = kvp.Key
                Dim wledName As String = kvp.Value.Item1
                Dim wledData As JObject = kvp.Value.Item2
                If wledData IsNot Nothing AndAlso wledData("state") IsNot Nothing AndAlso wledData("state")("seg") IsNot Nothing Then
                    Dim segmentCount = TryCast(wledData("state")("seg"), JArray).Count
                    For i As Integer = 0 To segmentCount - 1
                        fixtureColumn.Items.Add($"{wledName}/{i}") ' Bv: "WLED_Main/0", "WLED_Main/1", ...
                    Next
                End If
            Next
        End If

    End Sub


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

        UpdateFixuresPulldown_ForGroups(DG_Groups)

    End Sub

    ''' <summary>
    ''' Voegt een nieuwe rij toe aan de DataGridView voor de geselecteerde rij.
    ''' </summary>
    ''' <param name="dgv">De DataGridView waaraan de rij moet worden toegevoegd.</param>
    Public Sub GroupAddRowBefore(ByVal dgv As DataGridView)
        If dgv.CurrentCell IsNot Nothing Then
            Dim currentIndex = dgv.CurrentCell.RowIndex
            dgv.Rows.Insert(currentIndex, "", "", 1, 1, 0) ' Voeg een nieuwe rij in op de huidige index.
        Else
            dgv.Rows.Add("", "", 1, 1, 0) ' Voeg een nieuwe rij toe aan het einde als er geen rij is geselecteerd.
        End If
    End Sub

    Public Sub GroupDeleteRow(ByVal dgv As DataGridView)
        If dgv.CurrentCell IsNot Nothing Then
            Dim currentIndex = dgv.CurrentCell.RowIndex
            If dgv.Rows.Count > 0 Then
                dgv.Rows.RemoveAt(currentIndex) ' Verwijder de geselecteerde rij.
            End If
        End If
    End Sub


End Module
