Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient

Public Class FrmInqueryCheckList
    Private TB As DataTable

    Private Sub FrmInqueryCheckList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Vessel.InitControl(My.Settings.EditTextBackColor)
        Me.Voyage.InitControl(My.Settings.EditTextBackColor, Me.Vessel)
    End Sub

    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click

        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean

        Me.GridCost.DataSource = Nothing
        sSql = "SP_InqueryCheckListByVoyageID '" & Me.Voyage.VoyageID.ToString & "'"
        TableBySql(sSql, TB, lResult)
        Me.GridBls.DataSource = TB
        GridNumSeperator(Me.GridBls)

    End Sub
    Private Sub GridBls_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridBls.AfterRowActivate

        Dim sSql As String
        Dim lResult As Boolean
        Dim TBBL As New DataTable

        'sSql = "SP_InwardRateChecking '" & GridBls.ActiveRow.Cells("ID").Value.ToString & "' , '" & GridBls.ActiveRow.Cells("InqueryID").Value.ToString & "'"

        sSql = "SP_InwardRateChecking '" & GridBls.ActiveRow.Cells("ID").Value.ToString & "'"

        TableBySql(sSql, TB, lResult)
        Me.GridCost.DataSource = TB
        With Me.GridCost
            .DisplayLayout.Bands(0).Columns("RealAmount").MaskInput = "{LOC}nnn,nnn,nnn.nn"
            .DisplayLayout.Bands(0).Columns("UnitRate").MaskInput = "{LOC}nnn,nnn,nnn.nn"
            .DisplayLayout.Bands(0).Columns("RealAmount").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals
            .DisplayLayout.Bands(0).Columns("UnitRate").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals
        End With

        sSql = "SElect IssueFU from Tb_InwardBls Where ID = '" & GridBls.ActiveRow.Cells("ID").Value.ToString & "'"
        TableBySql(sSql, TBBL, lResult)
        If TBBL.Rows.Count > 0 Then
            Me.IssueFU.Checked = TBBL.Rows(0).Item(0)
        End If

        TB.AcceptChanges()



    End Sub

    Private Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        Dim DM As DataManager
        Dim TBChnge As DataTable
        Dim Dr As DataRow
        Dim BLID As Guid
        Dim Cns As TB_InwardCntrsCollection
        Dim Cn As TB_InwardCntrs
        Dim Chgs As TB_InwardCntrsChargesCollection
        Dim Chg As TB_InwardCntrsCharges
        Dim Imco As TB_InwardCnsImco
        Dim LogDataSet As DataSet

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim cTB As DataTable
        Dim cDr As DataRow


        If Me.GridBls.Rows.Count = 0 Then
            Exit Sub
        End If

        Me.GridCost.UpdateData()


        If TB.GetChanges Is Nothing Then
            Exit Sub
        End If

        Cnn.Open()
        With Cmd
            .CommandText = "SP_InwardCnsChargesByAll"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.Add(New SqlParameter("@BLID", SqlDbType.UniqueIdentifier))
            .Parameters.Add(New SqlParameter("@UNNO", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@IMDGCode", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@UnitRate", SqlDbType.Decimal, 16, 4))
            .Parameters.Add(New SqlParameter("@RealAmount", SqlDbType.Decimal, 16, 4))
            .Parameters.Add(New SqlParameter("@CnSize", SqlDbType.Char, 10))
            .Parameters.Add(New SqlParameter("@CnType", SqlDbType.Char, 10))
            .Parameters("@BLID").Value = GridBls.ActiveRow.Cells("ID").Value
        End With

        TBChnge = TB.GetChanges
        DM = New DataManager(My.Settings.DSN)

        If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
            For Each Dr In TBChnge.Rows
                With Cmd
                    .Parameters("@UNNO").Value = Trim(NullToValue(Dr("UNNO"), ""))
                    .Parameters("@IMDGCode").Value = Trim(NullToValue(Dr("IMDGCode"), ""))
                    .Parameters("@UnitRate").Value = NullToValue(Dr("UnitRate", DataRowVersion.Original), 0)
                    .Parameters("@RealAmount").Value = NullToValue(Dr("RealAmount", DataRowVersion.Original), 0)
                    .Parameters("@CnSize").Value = Trim(NullToValue(Dr("CnSize"), ""))
                    .Parameters("@CnType").Value = Trim(NullToValue(Dr("CnType"), ""))
                End With
                cTB = New DataTable
                DA.SelectCommand = Cmd
                DA.Fill(cTB)
                For Each cDr In cTB.Rows
                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_InwardCntrsCharges.Columns.ID, cDr("ID"), MatchType.Exact)
                    DM.QueryCriteria.And(JoinPath.TB_InwardCntrsCharges.Columns.ChargesCode, "OFT", MatchType.Exact)
                    Chg = DM.GetTB_InwardCntrsCharges
                    If Not Chg Is Nothing Then
                        Chg.RealAmount = Decimal.Parse(Dr("RealAmount"))
                        Chg.UnitRate = Decimal.Parse(Dr("UnitRate"))
                    End If
                Next
            Next

          
            Try
                LogDataSet = DM.DataSet.Copy
                DM.CommitAll()
                GenerateLog(LogDataSet)
                TB.AcceptChanges()
                MsgBoxSaveSuccessful()
            Catch ex As Exception
                MsgBoxSaveFailed()
                MsgBox(ex.ToString)

            End Try
        End If
    End Sub

    Private Sub SaveFU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveFU.Click


        Dim Dm As DataManager
        Dim Cns As TB_InwardCntrsCollection
        Dim Ecs As TB_EcsContainers
        Dim Mov As TB_EcsMoves
        Dim Cn As TB_InwardCntrs
        Dim BL As TB_InwardBLS
        Dim LogDataSet As DataSet
        Dim drs() As DataRow

        If Me.GridBls.Rows.Count = 0 Then
            Exit Sub
        End If

        Dm = New DataManager(My.Settings.DSN)

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.ID, GridBls.ActiveRow.Cells("ID").Value, MatchType.Exact)
        BL = Dm.GetTB_InwardBLS

        Dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, BL.ID)
        Cns = dm.GetTB_InwardCntrsCollection

        If Me.IssueFU.Checked = True Then
            BL.IssueFU = True
            If Not Me.FUDate.DateValue Is Nothing Then
                For Each Cn In Cns
                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.CntrNo, Cn.CntrNo, MatchType.Exact)
                    Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.InVoyageID, BL.VoyageID, MatchType.Exact)
                    Ecs = Dm.GetTB_EcsContainers
                    If Not Ecs Is Nothing Then
                        If Ecs.LastStatus = "FV" Or Ecs.LastStatus = "CV" Or Ecs.LastStatus = "TV" Then
                            Ecs.LastStatus = IIf(Ecs.SOC = "Y", "FS", "FU")
                            Ecs.LastStatusDate = Me.FUDate.DateValue
                            Dm.QueryCriteria.Clear()
                            Mov = Dm.NewTB_EcsMoves(Ecs)
                            Mov.Status = "FU"
                            Mov.StatusDate = Me.FUDate.DateValue
                            Mov.StatusDateToLine = Me.FUDate.DateValue
                            Mov.Remarks = "Added at D.O. Time"
                            Mov.IsReported = False
                            Mov.Depot = Ecs.LastDepot
                        Else
                            Dm.QueryCriteria.Clear()
                            Dm.QueryCriteria.And(JoinPath.TB_EcsMoves.Columns.CntrID, Ecs.ID, MatchType.Exact)
                            Dm.QueryCriteria.And(JoinPath.TB_EcsMoves.Columns.Status, "FU", MatchType.Exact)
                            Mov = Dm.GetTB_EcsMoves
                            If Not Mov Is Nothing Then
                                Mov.StatusDate = Me.FUDate.DateValue
                                Mov.StatusDateToLine = Me.FUDate.DateValue
                            End If
                        End If
                    End If
                Next
            End If
        Else
            BL.IssueFU = False
        End If

        Try
            LogDataSet = Dm.DataSet.Copy
            Dm.CommitAll()
            GenerateLog(LogDataSet)
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
        End Try

    End Sub
End Class