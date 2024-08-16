Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win.UltraWinGrid
Imports System.Data.SqlClient

Public Class FrmAccountTitle
    ''test test
    Dim Dm As DataManager
    Dim Tb As DataTable
    Dim DPLine As UltraDropDown
    Dim DPCharge As UltraDropDown

    Private Sub FrmAccountDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetDocument()

    End Sub

    Private Sub SetDocument()

        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim DummyTB As DataTable
        Dim lResult As Boolean
        TableBySql("Select * From tb_Account Order By Line", Tb, lResult)

        Me.GridData.DataSource = Tb

        With (Me.GridData.DisplayLayout.Bands(0))
            .Columns("ID").Hidden = True
        End With

        TableBySql("Select LineCode From tb_Lines Order By LineCode", DummyTB, lResult)

        DPLine = New UltraDropDown
        With DPLine
            .DataSource = DummyTB
            .DisplayMember = "LineCode"
            .ValueMember = "LineCode"
            With GridData.DisplayLayout.Bands(0)
                .Columns("Line").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("Line").ValueList = DPLine
            End With
        End With

        DPCharge = New UltraDropDown
        With DPCharge
            .DataSource = GetCodeList("CG")
            .DisplayMember = "Meaning"
            .ValueMember = "STDCode"
            .DisplayLayout.Bands(0).Columns("STDCode").Hidden = True
            With GridData.DisplayLayout.Bands(0)
                .Columns("ChargeCode").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("ChargeCode").ValueList = DPCharge
            End With
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With

    End Sub

    Private Sub MenuItem_CustomDeleteClick() Handles MenuItem.CustomDeleteClick

    End Sub
    Private Sub MenuItem_CustomRefreshClick() Handles MenuItem.CustomRefreshClick
        SetDocument()
    End Sub

    Private Sub GridData_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles GridData.AfterCellUpdate
        If Me.GridData.ActiveCell.Column.Header.Caption = "ChargeCode" Then
            Me.GridData.ActiveRow.Cells("Description").Value = Me.DPCharge.ActiveRow.Cells("MeaningF").Text
        End If
    End Sub

    Private Sub GridData_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles GridData.BeforeCellUpdate
     
    End Sub
    Private Function ValidateForm() As Boolean
        Dim lResult As Boolean = True
        For Each dr As DataRow In Tb.Rows
            If dr.RowState <> DataRowState.Deleted Then
                If NullToValue(dr("Line"), "") = "" Or NullToValue(dr("ChargeCode"), "") = "" Or NullToValue(dr("Level1"), "") = "" Or NullToValue(dr("Description"), "") = "" Then
                    dr.RowError = "Plesae Check Data !"
                    lResult = False
                Else
                    dr.RowError = ""
                End If
            End If
        Next
        Return lResult

    End Function

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick
        Me.GridData.UpdateData()
        If Tb.GetChanges Is Nothing Then
            Exit Sub
        End If
        If Tb.GetChanges.Rows.Count > 0 Then
            If ValidateForm() = True Then
                SaveData()
            End If
        End If

    End Sub
    Private Sub SaveData()

        Dim Dr As DataRow
        Dim CmdIns As New SqlCommand
        Dim CmdUpd As New SqlCommand
        Dim Cmddel As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)


        Cnn.Open()
        CmdIns.Connection = Cnn
        CmdIns.CommandType = CommandType.Text
        CmdIns.CommandText = "Insert into TB_Account (Line,ChargeCode,Level1, Level2,Level3,Description,port , Level4) values (@Line,@ChargeCode,@Level1, @Level2,@Level3,@Description ,@port , @Level4)"
        CmdIns.Parameters.Add(New SqlParameter("@Line", SqlDbType.NVarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@ChargeCode", SqlDbType.NVarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@Level1", SqlDbType.NVarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@Level2", SqlDbType.NVarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@Level3", SqlDbType.NVarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 100))
        CmdIns.Parameters.Add(New SqlParameter("@Port", SqlDbType.NVarChar, 5))
        CmdIns.Parameters.Add(New SqlParameter("@Level4", SqlDbType.NVarChar, 10))


        CmdUpd.Connection = Cnn
        CmdUpd.CommandType = CommandType.Text
        CmdUpd.CommandText = "Update TB_Account Set Line = @Line , ChargeCode = @ChargeCode , Level1 = @Level1 , Level2 = @Level2 , Level3 = @Level3 , Description = @Description , Port = @port , Level4 = @Level4 Where ID = @ID"
        CmdUpd.Parameters.Add(New SqlParameter("@Line", SqlDbType.NVarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@ChargeCode", SqlDbType.NVarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@Level1", SqlDbType.NVarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@Level2", SqlDbType.NVarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@Level3", SqlDbType.NVarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 100))
        CmdUpd.Parameters.Add(New SqlParameter("@ID", SqlDbType.VarChar, 36))
        CmdUpd.Parameters.Add(New SqlParameter("@Port", SqlDbType.VarChar, 5))
        CmdUpd.Parameters.Add(New SqlParameter("@Level4", SqlDbType.NVarChar, 10))

        Cmddel.Connection = Cnn
        Cmddel.CommandType = CommandType.Text
        Cmddel.CommandText = "Delete TB_Account Where ID = @ID"
        Cmddel.Parameters.Add(New SqlParameter("@ID", SqlDbType.VarChar, 36))

        Try

            For Each Dr In Tb.GetChanges.Rows

                Select Case Dr.RowState
                    Case DataRowState.Added
                        With CmdIns
                            .Parameters("@Line").Value = Dr("Line")
                            .Parameters("@ChargeCode").Value = Dr("ChargeCode")
                            .Parameters("@Level1").Value = Dr("Level1")
                            .Parameters("@Level2").Value = Dr("Level2")
                            .Parameters("@Level3").Value = Dr("Level3")
                            .Parameters("@Description").Value = Dr("Description")
                            .Parameters("@Port").Value = Dr("Port")
                            .Parameters("@Level4").Value = Dr("Level4")
                        End With
                        CmdIns.ExecuteNonQuery()
                    Case DataRowState.Deleted
                        With Cmddel
                            .Parameters("@ID").Value = Dr(0, DataRowVersion.Original).ToString
                        End With
                        Cmddel.ExecuteNonQuery()
                    Case DataRowState.Modified
                        With CmdUpd
                            .Parameters("@Line").Value = Dr("Line")
                            .Parameters("@ChargeCode").Value = Dr("ChargeCode")
                            .Parameters("@Level1").Value = Dr("Level1")
                            .Parameters("@Level2").Value = Dr("Level2")
                            .Parameters("@Level3").Value = Dr("Level3")
                            .Parameters("@Description").Value = Dr("Description")
                            .Parameters("@ID").Value = Dr("ID").ToString
                            .Parameters("@Port").Value = Dr("Port").ToString
                            .Parameters("@Level4").Value = Dr("Level4")
                            CmdUpd.ExecuteNonQuery()
                        End With
                End Select
            Next
            Tb.AcceptChanges()
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(Err.Description)


        End Try
        Cnn.Close()
    End Sub

    Private Sub GridData_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridData.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub
    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick
        SaveGridToExcel(Me.GridData)
    End Sub
End Class