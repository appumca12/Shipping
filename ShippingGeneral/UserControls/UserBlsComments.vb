Imports Infragistics.Win.UltraWinGrid

Public Class UserBlsComments

    Enum InwardOutward
        Inward
        Outward
    End Enum

    Private IOStatus As InwardOutward
    Private BLID As Guid
    Private CommentsTB As DataTable

    Public Sub InitControl(ByVal InOut As InwardOutward)

        Dim DropDown As New UltraDropDown
        CommentsTB = New DataTable
        With CommentsTB
            .Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("BLID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("CommentType", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Comment", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("CommentDate", System.Type.GetType("System.DateTime")))
        End With
        Me.GridComments.DataSource = CommentsTB

        With DropDown
            .DataSource = GetCodeList("CM")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = True
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With

        With GridComments.DisplayLayout.Bands(0)
            .Columns("CommentType").Style _
                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CommentType").ValueList = DropDown
            .Columns("CommentType").Header.Caption = "Type"
            .Columns("CommentDate").Header.Caption = "Date"
            .Columns("CommentDate").Header.VisiblePosition = 4
            .Columns("Comment").Width = 500
        End With

    End Sub
    Private Sub GridComments_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GridComments.AfterRowInsert

        If IsDBNull(GridComments.ActiveRow.Cells("ID").Value) = True Then
            GridComments.ActiveRow.Cells("ID").Value = Guid.NewGuid
            GridComments.ActiveRow.Cells("BLID").Value = BLID
            GridComments.ActiveRow.Cells("CommentDate").Value = Now.Date
        End If

    End Sub
    Public Sub SetDocument(ByVal BID As Guid, ByVal TB As DataTable)

        Dim NewDr As DataRow

        CommentsTB.Clear()
        CommentsTB.AcceptChanges()
        Me.BLID = BID
        For Each Dr In TB.Rows
            NewDr = CommentsTB.NewRow
            For Each Col In TB.Columns
                NewDr(Col.ColumnName) = Dr(Col.ColumnName)
            Next
            CommentsTB.Rows.Add(NewDr)
        Next

        CommentsTB.AcceptChanges()

        Me.GridComments.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        Me.GridComments.DisplayLayout.Bands(0).Columns("BLID").Hidden = True
        Me.BLID = BID
    End Sub
    Public Sub GetDocument(ByRef TB As DataTable)

        Dim DR As DataRow
        Dim DV As DataView
        Dim cLen As Integer
        GridComments.UpdateData()

        For Each DR In CommentsTB.Rows
            Select Case DR.RowState
                Case DataRowState.Added
                    DR("BLID") = BLID
                    TB.ImportRow(DR)
                Case DataRowState.Deleted
                    DV = New DataView(TB, "ID = '" & DR(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                    If DV.Count > 0 Then
                        DV.Item(0).Delete()
                    End If
                Case DataRowState.Modified
                    DV = New DataView(TB, "ID = '" & DR.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                    If DV.Count > 0 Then
                        CLen = DR.ItemArray.Length
                        For Each DC In TB.Columns
                            DV.Item(0).Item(DC.ColumnName) = DR.Item(DC.ColumnName)
                        Next
                    End If
            End Select
        Next
    End Sub
    Public ReadOnly Property GetCommantsChanges() As DataTable
        Get
            Me.GridComments.UpdateData()
            Return CommentsTB.GetChanges
        End Get
    End Property
    Public Sub AcceptCntrsChanges()
        CommentsTB.AcceptChanges()
    End Sub
    Private Sub GridComments_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridComments.InitializeLayout
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

End Class
