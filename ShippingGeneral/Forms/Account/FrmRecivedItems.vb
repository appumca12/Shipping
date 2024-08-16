Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors

Public Class FrmRecivedItems

    Private BLID As Guid
    Private InvID As Guid
    Private Dm As DataManager
    Private Tb As DataTable
    Private Direction As String
    Private IrrAmount As Double
    Private FDate As String

    Private Sub FrmRecivedItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

       
        Dim xTb As New DataTable
        Dim lResult As Boolean

        InitGrid()

        TableBySql("select dbo.FC_ToPersianDate('" & Format(Now(), "yyyy-MM-dd") & "')", xtb, lResult)
        FDate = xtb.Rows(0).Item(0).ToString


        If Direction = "E" Then
            Dm = New DataManager(My.Settings.DSN)
            Dm.QueryCriteria.And(JoinPath.TB_ExpRecivedItems.Columns.InvoiceID, Me.InvID, MatchType.Exact)
            Dm.GetTB_ExpRecivedItemsCollection()
            Me.DataSetForm.Tables(0).Merge(Dm.DataSet.Tables("TB_expRecivedItems").Copy)
        Else
            Dm = New DataManager(My.Settings.DSN)
            Dm.QueryCriteria.And(JoinPath.TB_RecivedItems.Columns.InvoiceID, Me.InvID, MatchType.Exact)
            Dm.GetTB_RecivedItemsCollection()
            Me.DataSetForm.Tables(0).Merge(Dm.DataSet.Tables("TB_RecivedItems").Copy)
        End If

        Try
            Me.GridPayment.DisplayLayout.Bands(0).Columns("Id").Hidden = True
            Me.GridPayment.DisplayLayout.Bands(0).Columns("Rowguid").Hidden = True
        Catch ex As Exception

        End Try


    End Sub
    Public Sub New(ByVal Direction As String, ByVal BLID As Guid, ByVal InvID As Guid, ByVal IrrAmount As Double, ByVal UsdAmount As Double)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.BLID = BLID
        Me.InvID = InvID
        Me.Direction = Direction
        Me.TotalIRR.Text = "Total IRR : " & Format(IrrAmount, "#,###,###,####,####")
        Me.TotalUsd.Text = "Total USD : " & Format(UsdAmount, "standard")

        Me.IrrAmount = IrrAmount

    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        Dim Dr As DataRow
        Dim Dv As DataView
        Dim cLen As Byte
        Dim Dc As DataColumn
        Dim TbName As String
        Dim LogDataSet As New DataSet
        Dim DummyAmt As Long

        Me.GridPayment.UpdateData()
        If Me.GridPayment.Rows.Count = 0 Then
            Exit Sub
        End If

        If ValidateForm() = True Then
            For Each Dr In DataSetForm.Tables(0).Rows
                If Dr.RowState <> DataRowState.Deleted Then
                    DummyAmt += Dr("IrrAmount")
                End If
            Next
            If DummyAmt <> Math.Round(IrrAmount) Then
                MsgBox("Amount is not Balance , Do you Want To Continue ?", MsgBoxStyle.Critical)
            End If
        End If
        If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
            If Direction = "I" Then
                TbName = "TB_RecivedItems"
                Dm = New DataManager(My.Settings.DSN)
                Dm.QueryCriteria.And(JoinPath.TB_RecivedItems.Columns.InvoiceID, InvID, MatchType.Exact)
                Dm.GetTB_RecivedItemsCollection()
            Else
                TbName = "TB_ExpRecivedItems"
                Dm = New DataManager(My.Settings.DSN)
                Dm.QueryCriteria.And(JoinPath.TB_ExpRecivedItems.Columns.InvoiceID, InvID, MatchType.Exact)
                Dm.GetTB_ExpRecivedItemsCollection()
            End If
            For Each Dr In DataSetForm.Tables(0).Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        Dm.DataSet.Tables(TbName).ImportRow(Dr)
                    Case DataRowState.Deleted
                        Dv = New DataView(Dm.DataSet.Tables(TbName), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            Dv.Item(0).Delete()
                        End If
                    Case DataRowState.Modified
                        Dv = New DataView(Dm.DataSet.Tables(TbName), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            For Each Dc In Dr.Table.Columns
                                Dv.Item(0).Item(Dc.ColumnName) = Dr.Item(Dc.ColumnName)
                            Next
                        End If
                End Select
            Next

            Try
                LogDataSet = Dm.DataSet.Copy
                Dm.CommitAll()
                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
            Catch ex As Exception
                MsgBoxSaveFailed()
            End Try
        End If



    End Sub

    Private Function ValidateForm() As Boolean

        Dim Dr As DataRow
        Dim Ans As Boolean = True

        For Each Dr In DataSetForm.Tables(0).Rows


            If Dr.RowState <> DataRowState.Deleted Then
                Ans = True
                Dr.RowError = ""
                If NullToValue(Dr("Seq"), 0) = 0 Then
                    Dr.SetColumnError("SEQ", "Seq Is Empty!")
                    Ans = False
                Else
                    Dr.SetColumnError("SEQ", "")

                End If

                If NullToValue(Dr("PaymentType"), "") = "" Then
                    Dr.SetColumnError("PaymentType", "Payment Type Is Wrong!")
                    Ans = False
                Else
                    Dr.SetColumnError("PaymentType", "")
                End If

                If NullToValue(Dr("Description"), "") = "" Then
                    Dr.SetColumnError("Description", "Description Is Empty !")
                    Ans = False
                Else
                    Dr.SetColumnError("Description", "")
                End If

                If NullToValue(Dr("Amount"), 0) + NullToValue(Dr("IrrAmount"), 0) = 0 Then
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

    Private Sub GridPayment_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GridPayment.AfterRowUpdate

    End Sub

    Private Sub GridPayment_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridPayment.BeforeRowUpdate

        If IsDBNull(GridPayment.ActiveRow.Cells("InvoiceID").Value) Then
            GridPayment.ActiveRow.Cells("InvoiceID").Value = InvID
            GridPayment.ActiveRow.Cells("ID").Value = Guid.NewGuid
        End If

        Try
            If IsDBNull(GridPayment.ActiveRow.Cells("Rowguid").Value) Then
                GridPayment.ActiveRow.Cells("Rowguid").Value = Guid.NewGuid
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub GridPayment_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridPayment.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
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

        If Direction = "I" Then
            TableBySql("Select ChargesCode from TB_InvoiceDetails where InvoiceID = '" & InvID.ToString & "'", TB5, lResult)
        Else
            TableBySql("Select ChargesCode from TB_ExpInvoiceDetails where InvoiceID = '" & InvID.ToString & "'", TB5, lResult)
        End If
 
        'TB5 = New DataTable

        'With UDPChg
        '    .DataSource = TB5
        '    .DisplayMember = "ChargesCode"
        '    .ValueMember = "ChargesCode"

        '    .DisplayLayout.Bands(0).Columns("ChargesCode").Hidden = False
        '    .DisplayLayout.Bands(0).Columns("ChargesCode").Width = 100
        'End With

        'With GridPayment
        '    .DisplayLayout.Bands(0).Columns("Description").Style _
        '                 = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
        '    .DisplayLayout.Bands(0).Columns("Description").ValueList = UDPChg

        'End With

        With GridPayment
            .DisplayLayout.Bands(0).Columns("Seq").Hidden = True
            .DisplayLayout.Bands(0).Columns("IrrAmount").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals
            .DisplayLayout.Bands(0).Columns("IrrAmount").MaskInput = "{LOC}-n,nnn,nnn,nnn,nnn"
            .DisplayLayout.Bands(0).Columns("Amount").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals
            .DisplayLayout.Bands(0).Columns("Amount").MaskInput = "{LOC}-n,nnn,nnn,nnn.nn"

        End With


    End Sub

End Class