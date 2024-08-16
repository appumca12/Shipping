Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors

Public Class FrmDeposits

    Private DM As DataManager
    Private BLID As Guid
    Private Tb As DataTable

    Private Sub FrmDeposits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn

        With Me.DropDownCharges
            .DataSource = GetCodeList("CG")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 300
        End With

        With Me.GridDeposits.DisplayLayout.Bands(0)

            .Columns("ID").Hidden = True
            .Columns("BLID").Hidden = True

            .Columns("ChargesCodes").Width = 300

            .Columns("Amount").MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn"
            .Columns("Amount").MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeLiterals


            .Columns("ChargesCodes").Style _
                               = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ChargesCodes").ValueList = Me.DropDownCharges

            .Columns("ReturnBackAmount").MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn"
            .Columns("ReturnBackAmount").MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeLiterals
 
        End With

        Dm = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_Deposits.Columns.BLID, Me.BLID, MatchType.Exact)
        DM.GetTB_DepositsCollection()
        Me.FormDataSet.Tables(0).Merge(DM.DataSet.Tables("TB_Deposits").Copy)



    End Sub

    Public Sub New(ByVal BLID As Guid)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.BLID = BLID
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub UserMenuItem1_CustomPrintClick() Handles UserMenuItem1.CustomPrintClick

        Dim Frm As FrmGeneralReportShow
        Dim Rpt As RptDeposit
        Dim Tb As DataTable
        Dim dr As DataRow
        Dim Ds As DataSet
        Dim Row As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim nI As Byte
        Dim Clnt As TB_Clients
        Dim BL As TB_InwardBLS
        Dim PH As New CLPrintHdr

        Dim RptItems As TB_ReportCustomFieldsCollection
        Dim RptItem As TB_ReportCustomFields


        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.ID, BLID, MatchType.Exact)
        BL = DM.GetTB_InwardBLS

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, BL.ClientID, MatchType.Exact)
        Clnt = DM.GetTB_Clients

        If Me.GridDeposits.Rows.Count = 0 Then
            Exit Sub
        End If

        Rpt = New RptDeposit
        Frm = New FrmGeneralReportShow

        Tb = New DataTable
        Tb.Columns.Add(New DataColumn("BlNo", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Reference", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Cntrs", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("FDate", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("FirstItem", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("FirstAmount", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("SecondItem", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("SecondAmount", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("Client", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("AccountA", System.Type.GetType("System.String")))

        Ds = New DataSet
        Ds = StoredProcedures.SP_GetTotalInwardCntrsByBLID(BLID.ToString)

        dr = Tb.NewRow
        dr("BLNo") = Bl.BlNo
        dr("Reference") = Bl.Line & "-" & Bl.Reference.ToString
        dr("Cntrs") = NullToValue(Ds.Tables(0).Rows(0).Item(0), "")
        dr("fdate") = ToPersianDate(Now.Date)
        dr("AccountA") = Clnt.AccountA

        nI = 0
        For Each Row In Me.GridDeposits.Rows
            nI += 1
            If nI = 1 Then
                dr("FirstItem") = Row.Cells("Remarks").Value.ToString
                dr("FirstAmount") = Row.Cells("Amount").Value
            ElseIf nI = 2 Then
                dr("SecondItem") = Row.Cells("Remarks").Value.ToString
                dr("SecondAmount") = Row.Cells("Amount").Value
            End If
        Next

        dr("Client") = NullToValue(Clnt.fName, NullToValue(Clnt.lName, ""))
        Tb.Rows.Add(dr)
        '   Rpt.Subreports(0).SetDataSource(PH.ImageTable)
        Rpt.SetDataSource(Tb)

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_ReportCustomFields.Columns.ReportName, "RptDeposit", MatchType.Exact)
        RptItems = DM.GetTB_ReportCustomFieldsCollection

        For Each RptItem In RptItems
            Rpt.SetParameterValue(RptItem.FieldName, GetImageInStr(RptItem.ID.ToString))
        Next


        Frm.ReportViewer.ReportSource = Rpt
        Frm.Show()

    End Sub

    Private Sub UserMenuItem1_CustomSaveClick() Handles UserMenuItem1.CustomSaveClick
        Dim Dr As DataRow
        Dim Dv As DataView
        Dim cLen As Byte
        Dim Dc As DataColumn
        Dim TbName As String
        Dim LogDataSet As New DataSet
        Me.GridDeposits.Update()

        If ValidateForm() = True Then

            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then

                TbName = "TB_Deposits"
                DM = New DataManager(My.Settings.DSN)
                DM.QueryCriteria.And(JoinPath.TB_Deposits.Columns.BLID, BLID, MatchType.Exact)
                DM.GetTB_DepositsCollection()
                For Each Dr In FormDataSet.Tables(0).GetChanges.Rows
                    Select Case Dr.RowState
                        Case DataRowState.Added
                            DM.DataSet.Tables(TbName).ImportRow(Dr)
                        Case DataRowState.Deleted
                            Dv = New DataView(DM.DataSet.Tables(TbName), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                            If Dv.Count > 0 Then
                                Dv.Item(0).Delete()
                            End If
                        Case DataRowState.Modified
                            Dv = New DataView(DM.DataSet.Tables(TbName), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                            If Dv.Count > 0 Then
                                cLen = Dr.ItemArray.Length
                                For Each Dc In DM.DataSet.Tables(TbName).Columns
                                    Dv.Item(0).Item(Dc.ColumnName) = Dr.Item(Dc.ColumnName)
                                Next
                            End If
                    End Select
                Next

                Try
                    LogDataSet = DM.DataSet.Copy
                    DM.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                Catch ex As Exception
                    MsgBoxSaveFailed()
                End Try
            End If
        End If


    End Sub

    Private Function ValidateForm() As Boolean

        Dim Dr As DataRow
        Dim Ans As Boolean = True

        For Each Dr In FormDataSet.Tables(0).Rows


            If Dr.RowState <> DataRowState.Deleted Then
                Ans = True
                Dr.RowError = ""
            
                If NullToValue(Dr("ChargesCodes"), "") = "" Then
                    Dr.SetColumnError("ChargesCodes", "Charge Codes Is Wrong!")
                    Ans = False
                Else
                    Dr.SetColumnError("ChargesCodes", "")
                End If

                If NullToValue(Dr("Remarks"), "") = "" Then
                    Dr.SetColumnError("Remarks", "Remarks Is Empty !")
                    Ans = False
                Else
                    Dr.SetColumnError("Remarks", "")
                End If

                If NullToValue(Dr("Amount"), 0) = 0 Then
                    Dr.SetColumnError("Amount", "Amount Is Zero")
                    Ans = False
                End If

                If Ans = False Then
                    Dr.RowError = "Validate Failed !"
                End If

            End If

        Next

        Return Ans

    End Function

    Private Sub GridDeposits_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridDeposits.BeforeRowUpdate
        If IsDBNull(GridDeposits.ActiveRow.Cells("BLID").Value) Then
            GridDeposits.ActiveRow.Cells("BLID").Value = BLID
            GridDeposits.ActiveRow.Cells("ID").Value = Guid.NewGuid
        End If
    End Sub

    Private Sub GridDeposits_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridDeposits.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub

End Class