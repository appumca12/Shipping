Imports System.Data.SqlClient
Imports System.IO
Imports Aspose.Cells
Imports System.Reflection
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid
Imports Shipping.UserOutwardBlsBookingNo

Public Class FrmDuplicateFreeDays
    Dim checkFirstload = False
    Private Dm As DataManager
    Dim Items As TB_MenuItemsCollection
    Dim AccessLevel As TB_AccessLevelCollection
    Private ItemLevel As String = "307"
    
    Private Sub ButtonDeuplicateFreedays_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeuplicateFreedays.Click
        If Me.TabControl.SelectedTab.Text = "Outward Duplicate Freedays" Then

            PickupMovement()

        End If
    End Sub

    Public Sub dTo_DateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("hi")
    End Sub

    Private Sub PickupMovement()
        Me.DataGridView1.Refresh()
        Me.DataGridView1.DataSource = CreateDataSource()

        'For Each columnname As DataGridViewColumn In DataGridView1.Columns
        '    If (columnname.Name.ToString() = "Delete") Then
        '        Me.DataGridView1.Columns.Remove("Delete")
        '    End If
        '    'MessageBox.Show(columnname.ToString())
        'Next
        If DataGridView1.Columns.Count < 7 Then
            Dim buttonColumn As New DataGridViewButtonColumn
            buttonColumn.HeaderText = "Delete"
            buttonColumn.Name = "Delete"
            buttonColumn.Text = "Delete"
            buttonColumn.Width = 50
            buttonColumn.UseColumnTextForButtonValue = True
            buttonColumn.FlatStyle = FlatStyle.Standard
            buttonColumn.CellTemplate.Style.BackColor = Color.DarkSlateGray
            DataGridView1.Columns.Insert(5, buttonColumn)
        End If
        If checkFirstload = True Then
            Me.DataGridView1.Columns(0).Visible = False
        End If
        checkFirstload = False
        Me.DataGridView1.Columns(6).Visible = False
        Me.DataGridView1.AllowUserToAddRows = False
        'Me.DataGridView1.Columns(0).Visible = False
        Me.DataGridView1.Columns(1).Visible = False
       
    End Sub
    Private Function FillDatsSet()
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DS As New DataSet
        'Dim dFrom As Date
        'Dim dTo As Date
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn

        'dFrom = Me.MoveDateFrom.DateValue
        'dTo = Me.MoveDateTo.DateValue
        'dTo = DateAdd(DateInterval.Minute, 1434, dTo)

        Cnn.Open()

        With Cmd
            .CommandText = "SP_DuplicateFreeDays"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
            .Parameters.AddWithValue("@BLno", Me.BlNo.BlNo)
        End With

        DA.SelectCommand = Cmd
        DA.Fill(DS)
        Return DS
    End Function
    Private Function CreateDataSource()

        Me.DataGridView1.Refresh()
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DS As New DataSet
        'Dim dFrom As Date
        'Dim dTo As Date
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn

        'dFrom = Me.MoveDateFrom.DateValue
        'dTo = Me.MoveDateTo.DateValue
        'dTo = DateAdd(DateInterval.Minute, 1434, dTo)

        Cnn.Open()

        With Cmd
            .CommandText = "SP_DuplicateFreeDays"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
            .Parameters.AddWithValue("@BLno", Me.BlNo.BlNo)
        End With

        DA.SelectCommand = Cmd
        DA.Fill(DS)


        DS.Tables(0).TableName = "Result"

        Dim TB1 As New System.Data.DataTable
        Dim TBId As New System.Data.DataTable

        Dim lResult As Boolean
        If (DS.Tables(0).Rows.Count > 0) Then

            'Dim sSqlId As String = "SELECT TOP 1 dbo.TB_OutwardBLS.ID FROM dbo.TB_OutwardBLS Where dbo.TB_OutwardBLS.BlNo='" & DS.Tables(0).Rows(0)(3).ToString() & "'"
            'TableBySql(sSqlId, TBId, lResult)

            'If (TBId.Rows.Count > 0) Then

            Dim sSql As String = "SELECT ID,BLID,dFreeDays,dPercent,dAmount FROM TB_OutwardDiscount where BLID ='" & DS.Tables(0).Rows(0)(0).ToString() & "'"
            TableBySql(sSql, TB1, lResult)
            Me.DataGridView1.Visible = True
        End If
        '
        ' Create sample data for the DataGrid control.
        Dim dt As New System.Data.DataTable
        Dim dr As DataRow

        ' Define the columns of the table.
        dt.Columns.Add(New DataColumn("ID", GetType(String))) 'GetType(Int32)))
        dt.Columns.Add(New DataColumn("BLID", GetType(String)))
        dt.Columns.Add(New DataColumn("dFreeDay", GetType(Int32)))
        dt.Columns.Add(New DataColumn("dPercent", GetType(Int32)))
        dt.Columns.Add(New DataColumn("dAmount", GetType(Int32)))
        dt.Columns.Add(New DataColumn())
      
        'dt.Columns.Add(New Button("Delete", ))
        ' Populate the table with sample values.
        Dim i As Integer

        For i = 0 To TB1.Rows.Count - 1

            dr = dt.NewRow()

            dr(0) = TB1.Rows(i).Item(0).ToString()
            dr(1) = TB1.Rows(i).Item(1).ToString()
            dr(2) = TB1.Rows(i).Item(2).ToString()
            dr(3) = TB1.Rows(i).Item(3).ToString()
            dr(4) = TB1.Rows(i).Item(4).ToString()
            dt.Rows.Add(dr)

        Next i

        Dim dv As DataView = New DataView(dt)

        Return dv

    End Function

    Private Sub DataGridView1_RowDataBound(ByVal sender As System.Object, ByVal e As DataGridViewRowEventArgs)
        'e.Row().Cells(6).Visible = False
        'If e.Row.rRow.RowType == DataControlRowType.DataRow then
        'e.Row.Cells.Insert(5, DataGridViewButtonColumn)

        '// CREATE A LinkButton AND IT TO EACH ROW.
        'LinkButton lb = new LinkButton();
        'lb.ID = "lbBooks";
        'lb.Text = "Select";
        'Dim buttonColumn As New DataGridViewButtonColumn
        'buttonColumn.HeaderText = "Delete"
        'buttonColumn.Name = "Delete"
        'buttonColumn.Text = "Delete"
        'buttonColumn.Width = 50
        'buttonColumn.FlatStyle = FlatStyle.Standard
        ''Me.DataGridView1.Columns.Insert(6, buttonColumn)

        'Dim col1 As New System.Windows.Forms.Button
        'col1.Text = "Delete"

        'Dim tc As New DataColumn
        'Dim cell1 As DataGridViewCell

        'Dim buttonColumn As New DataGridViewButtonColumn()
        'buttonColumn.HeaderText = ""
        'buttonColumn.Name = "Status Request"
        'buttonColumn.Text = "Request Status"
        'buttonColumn.UseColumnTextForButtonValue = True


        'btnUpdate.ID = "btnupdate";
        'btnUpdate.ImageUrl = "~/SmartAdmin/Images/update.png";
        'btnUpdate.ToolTip = "Click Update";
        'btnUpdate.CommandName = "update";

        'e.Row.Cells.Insert(5, col1)
        'btnUpdate.Click += btnUpdate_Click;

        'TableCell tc = new TableCell();
        'tc.Container.Add(buttonColumn)
        'tc.Controls.Add(btnUpdate);
        ' Dim e1 As New System.Windows.Forms.DataGridViewCell()

        'e.Row.Cells.Insert(6, cell1)


        'e.Row.Cells[3].Controls.Add(buttonColumn);
        'End If
    End Sub

    Private Sub DataGridView1_RowCreated(ByVal sender As System.Object, ByVal e As DataGridViewRowEventArgs)

    End Sub

    Private Sub FrmDuplicateFreeDays_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AnnualYear.SetLength(4)
        Me.AnnualYear.TextValue = Now.Year.ToString
        Me.BlNo.InitControl()
        checkFirstload = True
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dm = New DataManager(My.Settings.DSN)
        Dim aTables() As String = {"TB_OutwardDiscount"}
        Dim LogDataSet As DataSet
        If e.ColumnIndex = 0 Then           '

            Dim ds As DataSet = FillDatsSet()
            Dm.PopulateObjectsFromDataSet(ds, aTables)
            '
            If Dm.DataSet.Tables("TB_OutwardDiscount").Rows.Count > 0 Then
                If MessageBox.Show("Are You Sure To Delete This Record ?", "Delete Record", MessageBoxButtons.OK) Then
                    Try
                        Dm.DataSet.Tables("TB_OutwardDiscount").Rows(e.RowIndex).Delete()
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)

                        Dim Id As String = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
                        Dim Cmd As New SqlCommand
                        Dim DA As New SqlDataAdapter
                        Dim Cnn As New SqlConnection(My.Settings.DSN)

                        Cmd.CommandType = System.Data.CommandType.Text
                        Cmd.Connection = Cnn
                        If Id <> "" Then
                            Cmd.CommandText = "DELETE FROM TB_OutwardDiscount WHERE ID = '" & Id & "'"
                            Cnn.Open()
                            Cmd.ExecuteNonQuery()
                            Me.DataGridView1.Refresh()
                            PickupMovement()
                        End If
                        MsgBoxDeleteSuccessful()
                        'Me.BlsDetailTab.Tabs(0).Selected = True
                        'LockStatus(True)
                        'ClearControl(Me)
                        'FrmStatus = FormStatus.NoAction
                        'General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                    Catch ex As Exception
                        MsgBoxDeleteFailed()
                        MsgBox(ex.ToString)
                    End Try
                End If
            End If
        End If
        If e.ColumnIndex = 5 Then
            Dim ds As DataSet = FillDatsSet()
            Dm.PopulateObjectsFromDataSet(ds, aTables)
            If Dm.DataSet.Tables("TB_OutwardDiscount").Rows.Count > 0 Then
                If MessageBox.Show("Are You Sure To Delete This Record ?", "Delete Record", MessageBoxButtons.OK) Then
                    Try
                        Dm.DataSet.Tables("TB_OutwardDiscount").Rows(e.RowIndex).Delete()
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        Dim Id As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
                        Dim Cmd As New SqlCommand
                        Dim DA As New SqlDataAdapter
                        Dim Cnn As New SqlConnection(My.Settings.DSN)

                        Cmd.CommandType = System.Data.CommandType.Text
                        Cmd.Connection = Cnn
                        If Id <> "" Then
                            Cmd.CommandText = "DELETE FROM TB_OutwardDiscount WHERE ID = '" & Id & "'"
                            Cnn.Open()
                            Cmd.ExecuteNonQuery()
                            Me.DataGridView1.Refresh()
                            PickupMovement()
                        End If

                        MsgBoxDeleteSuccessful()
                    Catch ex As Exception
                        MsgBoxDeleteFailed()
                        MsgBox(ex.ToString)
                    End Try
                End If
            End If

            'If e.ColumnIndex = 0 Then
            'Dim Id As String = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
            'Dim Cmd As New SqlCommand
            'Dim DA As New SqlDataAdapter
            'Dim Cnn As New SqlConnection(My.Settings.DSN)

            'Cmd.CommandType = System.Data.CommandType.Text
            'Cmd.Connection = Cnn
            'If Id <> "" Then
            '    Cmd.CommandText = "DELETE FROM TB_OutwardDiscount WHERE ID = '" & Id & "'"
            '    Cnn.Open()
            '    Cmd.ExecuteNonQuery()
            '    Me.DataGridView1.Refresh()
            '    PickupMovement()
            'End If

        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    
End Class
