Imports System.Data
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid

Public Class FrmNosaAccount

    Private TB As New DataTable
    Dim Ds As DataSet
    Dim DPLine As UltraDropDown
    Dim DPCharge As UltraDropDown
    Dim DPCharge2 As UltraDropDown
    Dim DPCharge3 As UltraDropDown

    Dim DPCharge4 As UltraDropDown
    Private Sub FrmNosaAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub
    Private Sub lStripButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lStripButtonSave.Click

        Dim Dr As DataRow
        Dim CmdIns As New SqlCommand
        Dim CmdUpd As New SqlCommand
        Dim Cmddel As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Sql As String

        Dim ChgMaster As DataTable
        Dim ChgDetail As DataTable


        Me.GridData.UpdateData()
        Cnn.Open()
        CmdIns.Connection = Cnn
        CmdIns.CommandType = CommandType.Text

        Sql = "INSERT INTO [Shipping].[dbo].[TB_NOSAAccount]" & _
           "([ID]" & _
           ",[ChargesCode]" & _
           ",[Description]" & _
           ",[Line]" & _
           ",[Port]" & _
           ",[DBAccount]" & _
           ",[DBLevel1]" & _
           ",[DBLevel2]" & _
           ",[DBLevel3]" & _
           ",[DBLevel4]" & _
           ",[DBLevel5]" & _
           ",[CRAccount]" & _
           ",[CRLevel1]" & _
           ",[CRLevel2]" & _
           ",[CRLevel3]" & _
           ",[CRLevel4]" & _
           ",[CRLevel5]" & _
           ",[AccType] )" & _
        "VALUES (" & _
           "  @ID " & _
           ", @ChargesCode " & _
           ", @Description " & _
           ", @Line " & _
           ", @Port  " & _
           ", @DBAccount " & _
           ", @DBLevel1 " & _
           ", @DBLevel2 " & _
           ", @DBLevel3 " & _
           ", @DBLevel4 " & _
           ", @DBLevel5 " & _
           ", @CRAccount " & _
           ", @CRLevel1 " & _
           ", @CRLevel2 " & _
           ", @CRLevel3 " & _
           ", @CRLevel4 " & _
           ", @CRLevel5 " & _
           ", @AccType )"


        CmdIns.CommandText = Sql
        CmdIns.Parameters.Add(New SqlParameter("@ID", SqlDbType.UniqueIdentifier))
        CmdIns.Parameters.Add(New SqlParameter("@ChargesCode", SqlDbType.NVarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 250))
        CmdIns.Parameters.Add(New SqlParameter("@Line", SqlDbType.VarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@Port", SqlDbType.VarChar, 5))
        CmdIns.Parameters.Add(New SqlParameter("@DBAccount", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel1", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel2", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel3", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel4", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel5", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRAccount", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel1", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel2", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel3", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel4", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@AccType", SqlDbType.VarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel5", SqlDbType.VarChar, 20))

        CmdUpd.Connection = Cnn
        CmdUpd.CommandType = CommandType.Text
        Sql = "Update TB_NOSAAccount " & _
              "SET " & _
              " [ChargesCode] = @ChargesCode " & _
              ",[Description] = @Description " & _
              ",[Line] = @Line " & _
              ",[Port] = @Port " & _
              ",[DBAccount] = @DBAccount " & _
              ",[DBLevel1] = @DBLevel1  " & _
              ",[DBLevel2] = @DBLevel2  " & _
              ",[DBLevel3] = @DBLevel3  " & _
              ",[DBLevel4] = @DBLevel4 " & _
              ",[DBLevel5] = @DBLevel5 " & _
              ",[CRAccount] = @CRAccount " & _
              ",[CRLevel1] = @CRLevel1 " & _
              ",[CRLevel2] = @CRLevel2 " & _
              ",[CRLevel3] = @CRLevel3 " & _
              ",[CRLevel4] = @CRLevel4 " & _
              ",[CRLevel5] = @CRLevel5 " & _
              ",[AccType] = @AccType " & _
              " WHERE ID = @ID"

        CmdUpd.CommandText = Sql
        CmdUpd.Parameters.Add(New SqlParameter("@ChargesCode", SqlDbType.NVarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 250))
        CmdUpd.Parameters.Add(New SqlParameter("@Line", SqlDbType.VarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@Port", SqlDbType.VarChar, 5))
        CmdUpd.Parameters.Add(New SqlParameter("@DBAccount", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel1", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel2", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel3", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel4", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel5", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRAccount", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel1", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel2", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel3", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel4", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel5", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@AccType", SqlDbType.VarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@ID", SqlDbType.UniqueIdentifier))
        

        Cmddel.Connection = Cnn
        Cmddel.CommandType = CommandType.Text
        Cmddel.CommandText = "Delete TB_NOSAAccount Where ID = @ID"
        Cmddel.Parameters.Add(New SqlParameter("@ID", SqlDbType.VarChar, 36))

        ChgMaster = Ds.Tables(0).GetChanges
        ChgDetail = Ds.Tables(1).GetChanges

        Try
            If Not ChgMaster Is Nothing Then
                For Each Dr In ChgMaster.Rows
                    Select Case Dr.RowState
                        Case DataRowState.Added
                            With CmdIns
                                .Parameters("@ID").Value = Guid.NewGuid
                                .Parameters("@ChargesCode").Value = Dr("ChargesCode")
                                .Parameters("@Description").Value = Dr("Description")
                                .Parameters("@Line").Value = Dr("Line")
                                .Parameters("@Port").Value = Dr("Port")
                                .Parameters("@DBAccount").Value = Dr("DBAccount")
                                .Parameters("@DBLevel1").Value = Dr("DBLevel1")
                                .Parameters("@DBLevel2").Value = Dr("DBLevel2")
                                .Parameters("@DBLevel3").Value = Dr("DBLevel3")
                                .Parameters("@DBLevel4").Value = Dr("DBLevel4")
                                .Parameters("@DBLevel5").Value = Dr("DBLevel5")
                                .Parameters("@CRAccount").Value = Dr("CRAccount")
                                .Parameters("@CRLevel1").Value = Dr("CRLevel1")
                                .Parameters("@CRLevel2").Value = Dr("CRLevel2")
                                .Parameters("@CRLevel3").Value = Dr("CRLevel3")
                                .Parameters("@CRLevel4").Value = Dr("CRLevel4")
                                .Parameters("@CRLevel5").Value = Dr("CRLevel5")
                                .Parameters("@AccType").Value = Dr("AccType")
                            End With
                            CmdIns.ExecuteNonQuery()
                        Case DataRowState.Deleted
                            With Cmddel
                                .Parameters("@ID").Value = Dr(0, DataRowVersion.Original).ToString
                            End With
                            Cmddel.ExecuteNonQuery()
                        Case DataRowState.Modified
                            With CmdUpd
                                .Parameters("@ID").Value = Dr("ID")
                                .Parameters("@ChargesCode").Value = Dr("ChargesCode")
                                .Parameters("@Description").Value = Dr("Description")
                                .Parameters("@Line").Value = Dr("Line")
                                .Parameters("@Port").Value = Dr("Port")
                                .Parameters("@DBAccount").Value = Dr("DBAccount")
                                .Parameters("@DBLevel1").Value = Dr("DBLevel1")
                                .Parameters("@DBLevel2").Value = Dr("DBLevel2")
                                .Parameters("@DBLevel3").Value = Dr("DBLevel3")
                                .Parameters("@DBLevel4").Value = Dr("DBLevel4")
                                .Parameters("@DBLevel5").Value = Dr("DBLevel5")
                                .Parameters("@CRAccount").Value = Dr("CRAccount")
                                .Parameters("@CRLevel1").Value = Dr("CRLevel1")
                                .Parameters("@CRLevel2").Value = Dr("CRLevel2")
                                .Parameters("@CRLevel3").Value = Dr("CRLevel3")
                                .Parameters("@CRLevel4").Value = Dr("CRLevel4")
                                .Parameters("@CRLevel5").Value = Dr("CRLevel5")
                                .Parameters("@AccType").Value = Dr("AccType")
                                CmdUpd.ExecuteNonQuery()
                            End With
                    End Select
                Next
            End If
            SaveDetail()
            SaveTaxDetail()
            Ds.AcceptChanges()
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(Err.Description)
        End Try
        Cnn.Close()



    End Sub

    Private Sub RefreshData()

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim TBA As New DataTable
        Dim TBB As New DataTable
        Dim TBTax As New DataTable
        Dim RL As DataRelation
        Dim PCol As DataColumn
        Dim CCol As DataColumn
        Dim Col As UltraGridColumn
        Dim TB As DataTable
        Dim Dr As DataRow
        Dim DummyTB As DataTable
        Dim lResult As Boolean

        Ds = New DataSet

        TableBySql("Select * From tb_NOSAAccount Order By Line", TBA, lResult)
        TableBySql("Select * From TB_NOSAAccountSub  ", TBB, lResult)
        TableBySql("Select * From TB_NOSPaidTaxTitle  ", TBTax, lResult)

        TBA.TableName = "Master"
        TBB.TableName = "Details"
        TBTax.TableName = "TAX"

        Ds.Tables.Add(TBA.Copy)
        Ds.Tables.Add(TBB.Copy)
        Ds.Tables.Add(TBTax.Copy)

        Try
            RL = Nothing
            PCol = Ds.Tables(0).Columns("ID")
            CCol = Ds.Tables(1).Columns("PID")
            RL = New DataRelation("Rel", PCol, CCol)
            Ds.Relations.Add(RL)
        Catch ex As Exception

        End Try

        Try
            RL = Nothing
            PCol = Ds.Tables(0).Columns("ID")
            CCol = Ds.Tables(2).Columns("PID")
            RL = New DataRelation("RelTax", PCol, CCol)
            Ds.Relations.Add(RL)
        Catch ex As Exception

        End Try


        Me.GridData.DataSource = Ds

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


        TableBySql("Select * From tb_Code Where GroupCode = 'CG' Or GroupCode = 'RT' or GroupCode = 'BK'", TB, lResult)

        DPCharge = New UltraDropDown
        With DPCharge
            .DataSource = TB.Copy  ' GetCodeList("CG")
            .DisplayMember = "Meaning"
            .ValueMember = "STDCode"
            .DisplayLayout.Bands(0).Columns("STDCode").Hidden = True
            With GridData.DisplayLayout.Bands(0)
                .Columns("ChargesCode").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("ChargesCode").ValueList = DPCharge
            End With
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With


        DPCharge2 = New UltraDropDown
        With DPCharge
            .DataSource = TB.Copy ' GetCodeList("CG")
            .DisplayMember = "Meaning"
            .ValueMember = "STDCode"
            .DisplayLayout.Bands(0).Columns("STDCode").Hidden = True
            With GridData.DisplayLayout.Bands(1)
                .Columns("ChargesCode").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("ChargesCode").ValueList = DPCharge
            End With
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With

        DPCharge4 = New UltraDropDown
        With DPCharge
            .DataSource = TB.Copy ' GetCodeList("CG")
            .DisplayMember = "Meaning"
            .ValueMember = "STDCode"
            .DisplayLayout.Bands(0).Columns("STDCode").Hidden = True
            With GridData.DisplayLayout.Bands(2)
                .Columns("ChargesCode").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("ChargesCode").ValueList = DPCharge
            End With
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With


        TB = New DataTable
        TB.Columns.Add(New DataColumn("Code"))
        TB.Columns.Add(New DataColumn("Meaning"))

        Dr = TB.NewRow
        Dr("Code") = "A"
        Dr("Meaning") = "Arrival"
        TB.Rows.Add(Dr)

        Dr = TB.NewRow
        Dr("Code") = "P"
        Dr("Meaning") = "Paid"
        TB.Rows.Add(Dr)

        DPCharge3 = New UltraDropDown
        With DPCharge3
            .DataSource = TB.Copy ' GetCodeList("CG")
            .DisplayMember = "Meaning"
            .ValueMember = "Code"
            .DisplayLayout.Bands(0).Columns("Code").Hidden = True
            With GridData.DisplayLayout.Bands(0)
                .Columns("AccType").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("AccType").ValueList = DPCharge3
            End With

            .DisplayLayout.Bands(0).Columns("Code").Hidden = True
        End With

        With Me.GridData.DisplayLayout.Bands(1)
            .Columns("ID").Hidden = True
            .Columns("PID").Hidden = True

            For Each Col In .Columns
                .Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Opaque
                .Header.Appearance.BackColor2 = Color.Bisque

            Next
        End With

        With Me.GridData.DisplayLayout.Bands(2)
            .Columns("ID").Hidden = True
            .Columns("PID").Hidden = True

            For Each Col In .Columns
                .Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Opaque
                .Header.Appearance.BackColor2 = Color.Bisque
            Next
            .Header.Caption = "TAX & Duty Brack For Paid Items "
        End With



 
    End Sub
    Private Sub ToolStripRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRefresh.Click
        RefreshData()
    End Sub

    Private Sub SaveDetail()

        Dim Dr As DataRow
        Dim CmdIns As New SqlCommand
        Dim CmdUpd As New SqlCommand
        Dim Cmddel As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Sql As String
        Dim ChgDetail As DataTable

        ChgDetail = Ds.Tables(1).GetChanges

        If ChgDetail Is Nothing Then
            Exit Sub
        End If


        Cnn.Open()
        CmdIns.Connection = Cnn
        CmdIns.CommandType = CommandType.Text

        Sql = "INSERT INTO [Shipping].[dbo].[TB_NOSAAccountSub] " & _
           "([ID]" & _
           ",[PID]" & _
           ",[ChargesCode]" & _
           ",[Description]" & _
           ",[DBAccount]" & _
           ",[DBLevel1]" & _
           ",[DBLevel2]" & _
           ",[DBLevel3]" & _
           ",[DBLevel4]" & _
           ",[DBLevel5]" & _
           ",[CRAccount]" & _
           ",[CRLevel1]" & _
           ",[CRLevel2]" & _
           ",[CRLevel3]" & _
           ",[CRLevel4]" & _
           ",[CRLevel5]" & _
           ",[Percentage] " & _
           ",[Amount] " & _
           ",[dFrom] " & _
           ",[dTo]) " & _
        "VALUES (" & _
           "  @ID " & _
           ", @PID " & _
           ", @ChargesCode " & _
           ", @Description " & _
           ", @DBAccount " & _
           ", @DBLevel1 " & _
           ", @DBLevel2 " & _
           ", @DBLevel3 " & _
           ", @DBLevel4 " & _
           ", @DBLevel5 " & _
           ", @CRAccount " & _
           ", @CRLevel1 " & _
           ", @CRLevel2 " & _
           ", @CRLevel3 " & _
           ", @CRLevel4 " & _
           ", @CRLevel5 " & _
           ", @Percentage " & _
           ", @Amount " & _
           ", @dFrom " & _
           ", @dTo)"

        CmdIns.CommandText = Sql
        CmdIns.Parameters.Add(New SqlParameter("@ID", SqlDbType.UniqueIdentifier))
        CmdIns.Parameters.Add(New SqlParameter("@PID", SqlDbType.UniqueIdentifier))
        CmdIns.Parameters.Add(New SqlParameter("@ChargesCode", SqlDbType.NVarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 250))
        CmdIns.Parameters.Add(New SqlParameter("@DBAccount", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel1", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel2", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel3", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel4", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel5", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRAccount", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel1", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel2", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel3", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel4", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel5", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@Percentage", SqlDbType.Float))
        CmdIns.Parameters.Add(New SqlParameter("@Amount", SqlDbType.BigInt))
        CmdIns.Parameters.Add(New SqlParameter("@dFrom", SqlDbType.SmallDateTime))
        CmdIns.Parameters.Add(New SqlParameter("@dTo", SqlDbType.SmallDateTime))

        CmdUpd.Connection = Cnn
        CmdUpd.CommandType = CommandType.Text
        Sql = "Update TB_NOSAAccountSub " & _
              "SET " & _
              " [PID] = @PID " & _
              ",[ChargesCode] = @ChargesCode " & _
              ",[Description] = @Description " & _
              ",[DBAccount] = @DBAccount " & _
              ",[DBLevel1] = @DBLevel1  " & _
              ",[DBLevel2] = @DBLevel2  " & _
              ",[DBLevel3] = @DBLevel3  " & _
              ",[DBLevel4] = @DBLevel4 " & _
              ",[DBLevel5] = @DBLevel5 " & _
              ",[CRAccount] = @CRAccount " & _
              ",[CRLevel1] = @CRLevel1 " & _
              ",[CRLevel2] = @CRLevel2 " & _
              ",[CRLevel3] = @CRLevel3 " & _
              ",[CRLevel4] = @CRLevel4 " & _
              ",[CRLevel5] = @CRLevel5 " & _
              ",[Percentage] = @Percentage " & _
              ",[Amount] = @Amount " & _
              ",[dFrom] = @dFrom " & _
              ",[dTo] = @dTo " & _
              " WHERE ID = @ID"

        CmdUpd.CommandText = Sql
        CmdUpd.Parameters.Add(New SqlParameter("@PID", SqlDbType.UniqueIdentifier))
        CmdUpd.Parameters.Add(New SqlParameter("@ChargesCode", SqlDbType.NVarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 250))
        CmdUpd.Parameters.Add(New SqlParameter("@DBAccount", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel1", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel2", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel3", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel4", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel5", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRAccount", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel1", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel2", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel3", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel4", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel5", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@Percentage", SqlDbType.Float))
        CmdUpd.Parameters.Add(New SqlParameter("@Amount", SqlDbType.BigInt))
        CmdUpd.Parameters.Add(New SqlParameter("@ID", SqlDbType.UniqueIdentifier))
        CmdUpd.Parameters.Add(New SqlParameter("@dFrom", SqlDbType.SmallDateTime))
        CmdUpd.Parameters.Add(New SqlParameter("@dTo", SqlDbType.SmallDateTime))


        Cmddel.Connection = Cnn
        Cmddel.CommandType = CommandType.Text
        Cmddel.CommandText = "Delete TB_NOSAAccountSub Where ID = @ID"
        Cmddel.Parameters.Add(New SqlParameter("@ID", SqlDbType.VarChar, 36))

        Try
            For Each Dr In ChgDetail.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        With CmdIns
                            .Parameters("@ID").Value = Guid.NewGuid
                            .Parameters("@PID").Value = Dr("PID")
                            .Parameters("@ChargesCode").Value = Dr("ChargesCode")
                            .Parameters("@Description").Value = Dr("Description")
                            .Parameters("@DBAccount").Value = Dr("DBAccount")
                            .Parameters("@DBLevel1").Value = Dr("DBLevel1")
                            .Parameters("@DBLevel2").Value = Dr("DBLevel2")
                            .Parameters("@DBLevel3").Value = Dr("DBLevel3")
                            .Parameters("@DBLevel4").Value = Dr("DBLevel4")
                            .Parameters("@DBLevel5").Value = Dr("DBLevel5")
                            .Parameters("@CRAccount").Value = Dr("CRAccount")
                            .Parameters("@CRLevel1").Value = Dr("CRLevel1")
                            .Parameters("@CRLevel2").Value = Dr("CRLevel2")
                            .Parameters("@CRLevel3").Value = Dr("CRLevel3")
                            .Parameters("@CRLevel4").Value = Dr("CRLevel4")
                            .Parameters("@CRLevel5").Value = Dr("CRLevel5")
                            .Parameters("@Percentage").Value = Dr("Percentage")
                            .Parameters("@dFrom").Value = Dr("dFrom")
                            .Parameters("@dTo").Value = Dr("dTo")
                            .Parameters("@Amount").Value = Dr("Amount")
                        End With
                        CmdIns.ExecuteNonQuery()
                    Case DataRowState.Deleted
                        With Cmddel
                            .Parameters("@ID").Value = Dr(0, DataRowVersion.Original).ToString
                        End With
                        Cmddel.ExecuteNonQuery()
                    Case DataRowState.Modified
                        With CmdUpd
                            .Parameters("@ID").Value = Dr("ID")
                            .Parameters("@PID").Value = Dr("PID")
                            .Parameters("@ChargesCode").Value = Dr("ChargesCode")
                            .Parameters("@Description").Value = Dr("Description")
                            .Parameters("@DBAccount").Value = Dr("DBAccount")
                            .Parameters("@DBLevel1").Value = Dr("DBLevel1")
                            .Parameters("@DBLevel2").Value = Dr("DBLevel2")
                            .Parameters("@DBLevel3").Value = Dr("DBLevel3")
                            .Parameters("@DBLevel4").Value = Dr("DBLevel4")
                            .Parameters("@DBLevel5").Value = Dr("DBLevel5")
                            .Parameters("@CRAccount").Value = Dr("CRAccount")
                            .Parameters("@CRLevel1").Value = Dr("CRLevel1")
                            .Parameters("@CRLevel2").Value = Dr("CRLevel2")
                            .Parameters("@CRLevel3").Value = Dr("CRLevel3")
                            .Parameters("@CRLevel4").Value = Dr("CRLevel4")
                            .Parameters("@CRLevel5").Value = Dr("CRLevel5")
                            .Parameters("@Percentage").Value = Dr("Percentage")
                            .Parameters("@Amount").Value = Dr("Amount")
                            .Parameters("@dFrom").Value = Dr("dFrom")
                            .Parameters("@dTo").Value = Dr("dTo")

                            CmdUpd.ExecuteNonQuery()
                        End With
                End Select
            Next
            'ChgDetail.AcceptChanges()
            TB.AcceptChanges()
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(Err.Description)
        End Try
        Cnn.Close()



    End Sub

    Private Sub SaveTaxDetail()

        Dim Dr As DataRow
        Dim CmdIns As New SqlCommand
        Dim CmdUpd As New SqlCommand
        Dim Cmddel As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Sql As String
        Dim ChgDetail As DataTable

        ChgDetail = Ds.Tables(2).GetChanges

        If ChgDetail Is Nothing Then
            Exit Sub
        End If

        Cnn.Open()
        CmdIns.Connection = Cnn
        CmdIns.CommandType = CommandType.Text

        Sql = "INSERT INTO [Shipping].[dbo].[TB_NOSPaidTaxTitle] " & _
           "([ID]" & _
           ",[PID]" & _
           ",[ChargesCode]" & _
           ",[Description]" & _
           ",[DBAccount]" & _
           ",[DBLevel1]" & _
           ",[DBLevel2]" & _
           ",[DBLevel3]" & _
           ",[DBLevel4]" & _
           ",[DBLevel5]" & _
           ",[CRAccount]" & _
           ",[CRLevel1]" & _
           ",[CRLevel2]" & _
           ",[CRLevel3]" & _
           ",[CRLevel4]" & _
           ",[CRLevel5]" & _
           ",[Percentage] " & _
           ",[Amount] " & _
           ") " & _
        "VALUES (" & _
           "  @ID " & _
           ", @PID " & _
           ", @ChargesCode " & _
           ", @Description " & _
           ", @DBAccount " & _
           ", @DBLevel1 " & _
           ", @DBLevel2 " & _
           ", @DBLevel3 " & _
           ", @DBLevel4 " & _
           ", @DBLevel5 " & _
           ", @CRAccount " & _
           ", @CRLevel1 " & _
           ", @CRLevel2 " & _
           ", @CRLevel3 " & _
           ", @CRLevel4 " & _
           ", @CRLevel5 " & _
           ", @Percentage " & _
           ", @Amount)"

        CmdIns.CommandText = Sql
        CmdIns.Parameters.Add(New SqlParameter("@ID", SqlDbType.UniqueIdentifier))
        CmdIns.Parameters.Add(New SqlParameter("@PID", SqlDbType.UniqueIdentifier))
        CmdIns.Parameters.Add(New SqlParameter("@ChargesCode", SqlDbType.NVarChar, 10))
        CmdIns.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 250))
        CmdIns.Parameters.Add(New SqlParameter("@DBAccount", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel1", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel2", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel3", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel4", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@DBLevel5", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRAccount", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel1", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel2", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel3", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel4", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@CRLevel5", SqlDbType.VarChar, 20))
        CmdIns.Parameters.Add(New SqlParameter("@Percentage", SqlDbType.Float))
        CmdIns.Parameters.Add(New SqlParameter("@Amount", SqlDbType.BigInt))

        CmdUpd.Connection = Cnn
        CmdUpd.CommandType = CommandType.Text
        Sql = "Update TB_NOSPaidTaxTitle " & _
              "SET " & _
              " [PID] = @PID " & _
              ",[ChargesCode] = @ChargesCode " & _
              ",[Description] = @Description " & _
              ",[DBAccount] = @DBAccount " & _
              ",[DBLevel1] = @DBLevel1  " & _
              ",[DBLevel2] = @DBLevel2  " & _
              ",[DBLevel3] = @DBLevel3  " & _
              ",[DBLevel4] = @DBLevel4 " & _
              ",[DBLevel5] = @DBLevel5 " & _
              ",[CRAccount] = @CRAccount " & _
              ",[CRLevel1] = @CRLevel1 " & _
              ",[CRLevel2] = @CRLevel2 " & _
              ",[CRLevel3] = @CRLevel3 " & _
              ",[CRLevel4] = @CRLevel4 " & _
              ",[CRLevel5] = @CRLevel5 " & _
              ",[Percentage] = @Percentage " & _
              ",[Amount] = @Amount " & _
              " WHERE ID = @ID"

        CmdUpd.CommandText = Sql
        CmdUpd.Parameters.Add(New SqlParameter("@PID", SqlDbType.UniqueIdentifier))
        CmdUpd.Parameters.Add(New SqlParameter("@ChargesCode", SqlDbType.NVarChar, 10))
        CmdUpd.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 250))
        CmdUpd.Parameters.Add(New SqlParameter("@DBAccount", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel1", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel2", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel3", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel4", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@DBLevel5", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRAccount", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel1", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel2", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel3", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel4", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@CRLevel5", SqlDbType.VarChar, 20))
        CmdUpd.Parameters.Add(New SqlParameter("@Percentage", SqlDbType.Float))
        CmdUpd.Parameters.Add(New SqlParameter("@Amount", SqlDbType.BigInt))
        CmdUpd.Parameters.Add(New SqlParameter("@ID", SqlDbType.UniqueIdentifier))

        Cmddel.Connection = Cnn
        Cmddel.CommandType = CommandType.Text
        Cmddel.CommandText = "Delete TB_NOSPaidTaxTitle Where ID = @ID"
        Cmddel.Parameters.Add(New SqlParameter("@ID", SqlDbType.VarChar, 36))

        Try
            For Each Dr In ChgDetail.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        With CmdIns
                            .Parameters("@ID").Value = Guid.NewGuid
                            .Parameters("@PID").Value = Dr("PID")
                            .Parameters("@ChargesCode").Value = Dr("ChargesCode")
                            .Parameters("@Description").Value = Dr("Description")
                            .Parameters("@DBAccount").Value = Dr("DBAccount")
                            .Parameters("@DBLevel1").Value = Dr("DBLevel1")
                            .Parameters("@DBLevel2").Value = Dr("DBLevel2")
                            .Parameters("@DBLevel3").Value = Dr("DBLevel3")
                            .Parameters("@DBLevel4").Value = Dr("DBLevel4")
                            .Parameters("@DBLevel5").Value = Dr("DBLevel5")
                            .Parameters("@CRAccount").Value = Dr("CRAccount")
                            .Parameters("@CRLevel1").Value = Dr("CRLevel1")
                            .Parameters("@CRLevel2").Value = Dr("CRLevel2")
                            .Parameters("@CRLevel3").Value = Dr("CRLevel3")
                            .Parameters("@CRLevel4").Value = Dr("CRLevel4")
                            .Parameters("@CRLevel5").Value = Dr("CRLevel5")
                            .Parameters("@Percentage").Value = Dr("Percentage")
                            .Parameters("@Amount").Value = Dr("Amount")
                        End With
                        CmdIns.ExecuteNonQuery()
                    Case DataRowState.Deleted
                        With Cmddel
                            .Parameters("@ID").Value = Dr(0, DataRowVersion.Original).ToString
                        End With
                        Cmddel.ExecuteNonQuery()
                    Case DataRowState.Modified
                        With CmdUpd
                            .Parameters("@ID").Value = Dr("ID")
                            .Parameters("@PID").Value = Dr("PID")
                            .Parameters("@ChargesCode").Value = Dr("ChargesCode")
                            .Parameters("@Description").Value = Dr("Description")
                            .Parameters("@DBAccount").Value = Dr("DBAccount")
                            .Parameters("@DBLevel1").Value = Dr("DBLevel1")
                            .Parameters("@DBLevel2").Value = Dr("DBLevel2")
                            .Parameters("@DBLevel3").Value = Dr("DBLevel3")
                            .Parameters("@DBLevel4").Value = Dr("DBLevel4")
                            .Parameters("@DBLevel5").Value = Dr("DBLevel5")
                            .Parameters("@CRAccount").Value = Dr("CRAccount")
                            .Parameters("@CRLevel1").Value = Dr("CRLevel1")
                            .Parameters("@CRLevel2").Value = Dr("CRLevel2")
                            .Parameters("@CRLevel3").Value = Dr("CRLevel3")
                            .Parameters("@CRLevel4").Value = Dr("CRLevel4")
                            .Parameters("@CRLevel5").Value = Dr("CRLevel5")
                            .Parameters("@Percentage").Value = Dr("Percentage")
                            .Parameters("@Amount").Value = Dr("Amount")
                            CmdUpd.ExecuteNonQuery()
                        End With
                End Select
            Next
            TB.AcceptChanges()
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(Err.Description)
        End Try
        Cnn.Close()

 
    End Sub

  Private Sub GridData_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GridData.AfterRowInsert
        Me.GridData.ActiveRow.Cells("Id").Value = Guid.NewGuid
    End Sub

     

End Class