Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors

Public Class FrmInvoiceEdit

    Private DM As DataManager

    Private ImpBl As TB_InwardBLS
    Private ImpInv As TB_Invoice
    Private ImpInvDetails As TB_InvoiceDetailsCollection

    Private ExpBl As TB_OutwardBLS
    Private ExpInv As TB_ExpInvoice
    Private ExpInvDetails As TB_ExpInvoiceDetailsCollection
    Private InvoiceID As String
    Private IO As InwardOutward

    Private Sub FrmInvoiceEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sSql As String
        Dim TbPOL As DataTable
        Dim TbPOD As DataTable
        Dim lResult As Boolean
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Drs() As DataRow

          
        sSql = "Select POL From Tb_InwardBls Group By POL"
        TableBySql(sSql, TbPOL, lResult)

        sSql = "Select POD From Tb_InwardBls Group By POD"
        TableBySql(sSql, TbPOD, lResult)

        '      TbPOD.Merge(TbPOL)

        For Each Dr In TbPOL.Rows
            Drs = TbPOD.Select("POD = '" & Dr("POL") & "'")
            If Drs.Length = 0 Then
                NewDr = TbPOD.NewRow
                NewDr("POD") = Dr("POL")
                TbPOD.Rows.Add(NewDr)
            End If
        Next

        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn

        With Me.DropDownCurrency
            .DataSource = GetCodeList("CU")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.DropDownOffice
            .DataSource = TbPOD
            .DisplayMember = "POD"
            .ValueMember = "POD"
            'For Each Col In .DisplayLayout.Bands(0).Columns
            '    Col.Hidden = True
            'Next
            '.DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With


        With Me.DropDownInvStatus
            .DataSource = GetCodeList("IS")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With

        With Me.DropDownCharges
            .DataSource = GetCodeList("CG")
            .DisplayMember = "STDCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.GridList.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("BLID").Hidden = True
            .Columns("Status").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("status").ValueList = Me.DropDownInvStatus

            .Columns("ConfirmOffice").Style _
                                    = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ConfirmOffice").ValueList = Me.DropDownOffice

            .Columns("IssueOffice").Style _
                                 = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("IssueOffice").ValueList = Me.DropDownOffice

        End With

        With Me.GridDetail.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("InvoiceID").Hidden = True
            .Columns("ChargesCode").Style _
                                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ChargesCode").ValueList = Me.DropDownCharges

            .Columns("Currency").Style _
                                                     = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("Currency").ValueList = Me.DropDownCurrency
        End With

    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        Dim Dr As DataRow

        If Me.InvoiceNo.TextValue = "" Then
            Exit Sub
        End If

        For Each TB As DataTable In DataSetForm.Tables
            TB.Clear()
        Next

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Invoice.Columns.InvoiceNo, Me.InvoiceNo.TextValue, MatchType.Exact)
        ImpInv = DM.GetTB_Invoice

        If ImpInv Is Nothing Then
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_ExpInvoice.Columns.InvoiceNo, Me.InvoiceNo.TextValue, MatchType.Exact)
            ExpInv = DM.GetTB_ExpInvoice
            If ExpInv Is Nothing Then
                MsgBoxGeneral("No Valid Invoice !", "Validate")
            Else
                IO = InwardOutward.Outward
                InvoiceID = ExpInv.ID.ToString
            End If
        Else
            IO = InwardOutward.Inward
            InvoiceID = ImpInv.ID.ToString
        End If



        If IO = InwardOutward.Inward Then
            DataSetForm.Tables(0).ImportRow(DM.DataSet.Tables("TB_Invoice").Rows(0))
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InvoiceDetails.Columns.InvoiceID, ImpInv.ID, MatchType.Exact)
            ImpInvDetails = DM.GetTB_InvoiceDetailsCollection()
            For Each Dr In DM.DataSet.Tables("TB_InvoiceDetails").Rows
                DataSetForm.Tables(1).ImportRow(Dr)
            Next
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.ID, ImpInv.BLID, MatchType.Exact)
            ImpBl = DM.GetTB_InwardBLS
            Me.BLNo.TextValue = ImpBl.BlNo
        Else
            DataSetForm.Tables(0).ImportRow(DM.DataSet.Tables("TB_ExpInvoice").Rows(0))
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_ExpInvoiceDetails.Columns.InvoiceID, ExpInv.ID, MatchType.Exact)
            ExpInvDetails = DM.GetTB_ExpInvoiceDetailsCollection()
            For Each Dr In DM.DataSet.Tables("TB_ExpInvoiceDetails").Rows
                DataSetForm.Tables(1).ImportRow(Dr)
            Next
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.ID, ExpInv.BLID, MatchType.Exact)
            ExpBl = DM.GetTB_OutwardBLS
            Me.BLNo.TextValue = ExpBl.BlNo
        End If

        DataSetForm.AcceptChanges()

    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        Dim ChgsDs As DataSet
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Tb As DataTable
        Dim TbName As String
        Dim ColName As String
        Dim Drs() As DataRow
        Dim LogDataset As New DataSet

        Me.GridDetail.UpdateData()
        Me.GridList.UpdateData()

        ChgsDs = Me.DataSetForm.GetChanges

        For Each Tb In ChgsDs.Tables
            If IO = InwardOutward.Inward Then
                TbName = Tb.TableName
            Else
                If UCase(Tb.TableName) = UCase("TB_Invoice") Then
                    TbName = "Tb_ExpInvoice"
                Else
                    TbName = "Tb_ExpInvoiceDetails"
                End If
            End If

            For Each Dr In Tb.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        NewDr = DM.DataSet.Tables(TbName).NewRow
                        For Each Col As DataColumn In Dr.Table.Columns
                            ColName = Col.ColumnName
                            NewDr(ColName) = Dr(ColName)
                        Next
                        NewDr("InvoiceID") = InvoiceID
                        DM.DataSet.Tables(TbName).Rows.Add(NewDr)
                    Case DataRowState.Deleted
                        Drs = DM.DataSet.Tables(TbName).Select("ID = '" & Dr("ID", DataRowVersion.Original).ToString & "'")
                        If Drs.Length > 0 Then
                            Drs(0).Delete()
                        End If
                    Case DataRowState.Modified
                        Drs = DM.DataSet.Tables(TbName).Select("ID = '" & Dr("ID", DataRowVersion.Original).ToString & "'")
                        If Drs.Length > 0 Then
                            For Each Col As DataColumn In Drs(0).Table.Columns
                                ColName = Col.ColumnName
                                Drs(0).Item(ColName) = Dr(ColName)
                            Next
                        End If
                End Select
            Next
        Next
    
        LogDataset = DM.DataSet.Copy
        Try
            DM.CommitAll()
            GenerateLog(LogDataset)
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class