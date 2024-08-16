Imports System.Data.SqlClient
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid

Public Class FrmGroupRcvd
    Private BLID As Guid
    Private InvID As Guid
    Private Dm As DataManager
    Private Tb As DataTable
    Private Direction As String
    Private IrrAmount As Double
    Private FDate As String
    Private DS As DataSet
    Private Sub FrmGroupRcvd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim xTb As New DataTable
        Dim lResult As Boolean

        InitGrid()

        TableBySql("select dbo.FC_ToPersianDate('" & Format(Now(), "yyyy-MM-dd") & "')", xTb, lResult)
        FDate = xTb.Rows(0).Item(0).ToString

        Dm = New DataManager(My.Settings.DSN)
            Dm.QueryCriteria.And(JoinPath.TB_RecivedItems.Columns.InvoiceID, Me.InvID, MatchType.Exact)
            Dm.GetTB_RecivedItemsCollection()
            Me.DataSetForm.Tables(0).Merge(Dm.DataSet.Tables("TB_RecivedItems").Copy)
        Try
            Me.GridPayment.DisplayLayout.Bands(0).Columns("Id").Hidden = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub InitGrid()

        Dim Tb As New DataTable
        Dim Tb2 As New DataTable
        Dim TB3 As New DataTable
        Dim TB4 As New DataTable
        Dim TB5 As New DataTable


        Dim UDP As New Infragistics.Win.UltraWinGrid.UltraDropDown
        Dim UDPBank As New Infragistics.Win.UltraWinGrid.UltraDropDown
        Dim UDPRcvd As New Infragistics.Win.UltraWinGrid.UltraDropDown
        Dim UDPCur As New Infragistics.Win.UltraWinGrid.UltraDropDown
        Dim UDPChg As New Infragistics.Win.UltraWinGrid.UltraDropDown

        Dim lResult As Boolean
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PT", MatchType.Exact)
        Dm.GetTB_CODECollection()
        Tb = Dm.DataSet.Tables("TB_Code").Copy

        With UDP
            .DataSource = Tb
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In UDP.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 250
            .DisplayLayout.Bands(0).Columns("Meaning").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
        End With

        With GridPayment
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("InvoiceID").Hidden = True
            .DisplayLayout.Bands(0).Columns("PaymentType").Style _
                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .DisplayLayout.Bands(0).Columns("PaymentType").ValueList = UDP
        End With

        Dm.DataSet.Tables("TB_Code").Clear()

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "BA", MatchType.Exact)
        Dm.GetTB_CODECollection()
        Tb2 = Dm.DataSet.Tables("TB_Code").Copy

        With UDPBank
            .DataSource = Tb2
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In UDPBank.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 250
        End With

        With GridPayment
            .DisplayLayout.Bands(0).Columns("Bank").Style _
                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .DisplayLayout.Bands(0).Columns("Bank").ValueList = UDPBank
        End With


        Dm.DataSet.Tables("TB_Code").Clear()

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "RT", MatchType.Exact)
        Dm.GetTB_CODECollection()
        TB3 = Dm.DataSet.Tables("TB_Code").Copy

        With UDPRcvd
            .DataSource = TB3
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In UDPRcvd.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 250
        End With

        With GridPayment
            .DisplayLayout.Bands(0).Columns("ReceivedType").Style _
                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .DisplayLayout.Bands(0).Columns("ReceivedType").ValueList = UDPRcvd

        End With

        Dm.DataSet.Tables("TB_Code").Clear()
        Dm.DataSet.AcceptChanges()

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.Or(JoinPath.TB_CODE.Columns.STDCode, "IRR", MatchType.Exact)
        Dm.QueryCriteria.Or(JoinPath.TB_CODE.Columns.STDCode, "USD", MatchType.Exact)
        Dm.QueryCriteria.Or(JoinPath.TB_CODE.Columns.STDCode, "AED", MatchType.Exact)

        Dm.GetTB_CODECollection()
        TB4 = Dm.DataSet.Tables("TB_CODE").Copy

        With UDPCur
            .DataSource = TB4
            .DisplayMember = "Meaning"
            .ValueMember = "STDCode"
            For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In UDPCur.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 100
        End With

        With GridPayment
            .DisplayLayout.Bands(0).Columns("Currency").Style _
                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .DisplayLayout.Bands(0).Columns("Currency").ValueList = UDPCur

        End With

        TableBySql("Select ChargesCode from TB_InvoiceDetails where InvoiceID = '" & InvID.ToString & "'", TB5, lResult)



        With GridPayment
            .DisplayLayout.Bands(0).Columns("Seq").Hidden = True
            .DisplayLayout.Bands(0).Columns("IrrAmount").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals
            .DisplayLayout.Bands(0).Columns("IrrAmount").MaskInput = "{LOC}n,nnn,nnn,nnn,nnn"
            .DisplayLayout.Bands(0).Columns("Amount").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals
            .DisplayLayout.Bands(0).Columns("Amount").MaskInput = "{LOC}n,nnn,nnn,nnn.nn"

        End With


    End Sub

    'For ILS Shortcuts  
    Private Sub TexBLNO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextBLNO.KeyDown

        If e.KeyValue = 13 Then
            ButtonPickup_Click(sender, e)
        End If

    End Sub

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click

        Dim lResult As Boolean
        DS = New DataSet
        DataSetBySql("SP_ListOfInvoiceByMasterBL '" & Me.TextBLNO.Text & "'", DS, lResult)

        Me.GridInvoices.DataSource = DS.Tables(0)
        GridNumSeperator(Me.GridInvoices)
        GridNumSeperator(Me.GridPayment)
        Recalculate()

        For Each GRow In GridInvoices.Rows
            If NullToValue(GRow.Cells("Total Rcvd IRR").Value, 0) > 0 Or NullToValue(GRow.Cells("Total Rcvd USD").Value, 0) > 0 Then
                GRow.Cells("BLNO").Appearance.BackColor = Color.Red
            Else
                GRow.Cells("BLNO").Appearance.BackColor = Color.White
            End If
        Next

    End Sub

    Private Sub Recalculate()

        Dim R As UltraGridRow

        Dim TTLIrr As Double
        Dim TTLUsd As Double

        Dim TTLRcvdIrr As Double
        Dim TTLRcvdUsd As Double

        Me.GridInvoices.UpdateData()
 
        For Each R In GridInvoices.Rows
            If NullToValue(R.Cells("Select").Value, False) = True Then
                TTLIrr += NullToValue(R.Cells("TotalIRR").Value, 0)
                TTLUsd += NullToValue(R.Cells("TotalUsd").Value, 0)
            End If
        Next
        Me.LabelInvIrr.Text = "T.Invoice(Irr):" & Format(TTLIrr, "Standard")
        Me.LabelInvUsd.Text = "T.Invoice(USD):" & Format(TTLUsd, "Standard")

         
        Try
            For Each R In GridPayment.Rows
                If R.Cells("Currency").Value = "IRR" Then
                    TTLRcvdIrr += NullToValue(R.Cells("IrrAmount").Value, 0)
                Else
                    TTLRcvdUsd += NullToValue(R.Cells("Amount").Value, 0)
                End If
            Next

        Catch ex As Exception

        End Try
     


        Me.LblBalanceIrr.Text = "Balance (Irr):" & Format(TTLRcvdIrr - TTLIrr, "Standard")
        Me.LblBalanceUSD.Text = "Balance (USD):" & Format(TTLRcvdUsd - TTLUsd, "Standard")

        If TTLRcvdIrr - TTLIrr <> 0 Then
            Me.LblBalanceIrr.Appearance.ForeColor = Color.Red
        Else
            Me.LblBalanceIrr.Appearance.ForeColor = Color.Black
        End If

        If TTLRcvdUsd - TTLUsd <> 0 Then
            Me.LblBalanceUSD.Appearance.ForeColor = Color.Red
        Else
            Me.LblBalanceUSD.Appearance.ForeColor = Color.Black
        End If
 
    End Sub

     Private Sub GridInvoices_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles GridInvoices.AfterCellUpdate
        Recalculate()
    End Sub
    
    Private Sub GridInvoices_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridInvoices.InitializeLayout
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub GridPayment_AfterCellActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPayment.AfterCellActivate

        If GridPayment.ActiveCell.Column.Key = "PaidDate" Then
            If GridPayment.ActiveRow.Cells("PaidDate").Value.ToString = "" Then
                GridPayment.ActiveCell.Value = FDate
            End If
        End If

        If GridPayment.ActiveCell.Column.Key = "IrrAmount" Then
            Select Case GridPayment.ActiveRow.Cells("Currency").Value.ToString
                Case "IRR"
                    GridPayment.ActiveRow.Cells("IrrAmount").Value = GridPayment.ActiveRow.Cells("Amount").Value
                Case "USD"
                    GridPayment.ActiveRow.Cells("IrrAmount").Value = GridPayment.ActiveRow.Cells("Amount").Value ' * Val(USDRate.Text)
                Case "AED"
                    GridPayment.ActiveRow.Cells("IrrAmount").Value = GridPayment.ActiveRow.Cells("Amount").Value ' * Val(AEDRate.Text)
            End Select
        End If

        If IsDBNull(GridPayment.ActiveRow.Cells("Seq").Value) Then
            GridPayment.ActiveRow.Cells("Seq").Value = GridPayment.Rows.Count
        End If

    End Sub

    Private Sub GridPayment_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridPayment.BeforeRowUpdate

        If IsDBNull(GridPayment.ActiveRow.Cells("InvoiceID").Value) Then
            GridPayment.ActiveRow.Cells("InvoiceID").Value = InvID
            GridPayment.ActiveRow.Cells("ID").Value = Guid.NewGuid
        End If
        Recalculate()

    End Sub

    Private Sub ButtonSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click

        For Each GRow In GridInvoices.Rows
            If NullToValue(GRow.Cells("Total Rcvd IRR").Value, 0) > 0 Or NullToValue(GRow.Cells("Total Rcvd USD").Value, 0) > 0 Then
            Else
                GRow.Cells("Select").Value = True
            End If
        Next
        GridInvoices.UpdateData()

    End Sub

    Private Sub ButtonUnselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUnselect.Click
        For Each GRow In GridInvoices.Rows
            If NullToValue(GRow.Cells("Total Rcvd IRR").Value, 0) > 0 Or NullToValue(GRow.Cells("Total Rcvd USD").Value, 0) > 0 Then
            Else
                GRow.Cells("Select").Value = False
            End If
        Next
        GridInvoices.UpdateData()

    End Sub

End Class