Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Net.Mail
Imports System.Data.SqlClient

Public Class FrmInwardInvoice

    Private InvID As Guid
    Private Bls As TB_InwardBLSCollection
    Private Bl As TB_InwardBLS
    Private Clnt As TB_Clients
    Private Voy As TB_Voyage
    Private Vsl As TB_Vessels
    Private Sof As TB_SOF
    Private InvStatus As InvoiceStatus
    Private ItemLevel As String = "300"
    Private lValidBlNno As Boolean
    Private Dm As DataManager
    Private IsDetention As Boolean
    Private TotalCostIrr As Double
    Private TotalCostUsd As Double
    Public isDiscount As Boolean
    Dim Arvl As CLArrivalNotice
    Dim ArvDep As CLArrivalNotice
    Dim isArrival As Boolean
    Dim IsBlank As Boolean
    Dim Isreturn As Boolean
    Public Shared DetnCurrency As String
    Dim TBDETN As New DataTable


    Private Sub FrmInvoiceList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim Items As TB_MenuItemsCollection
        Dim AccessLevel As TB_AccessLevelCollection

        MakeTempTable()

        With Me.DropDownCurrency
            .DataSource = GetCodeList("CU")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
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
            .DisplayLayout.Bands(0).Columns("MeaningF").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("StdCode").Width = 80
            .DisplayLayout.Bands(0).Columns("MeaningF").Width = 150
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 150
        End With

        With Me.GridList.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("BLID").Hidden = True
            .Columns("Status").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("status").ValueList = Me.DropDownInvStatus
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

            .Columns("Amount").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals
            .Columns("Amount").MaskInput = "{LOC}n,nnn,nnn,nnn.nn"


            .Columns("IrrAmount").MaskInput = "{LOC}nnn,nnn,nnn,nnn"
            .Columns("Amount").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals


        End With

        With Me.GridDeposits.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("BLID").Hidden = True
            .Columns("ChargesCodes").Style _
                                                  = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ChargesCodes").ValueList = Me.DropDownCharges

        End With

        With Me.GridDetnAdvance.DisplayLayout.Bands(0)

            .Columns("ChargesCodes").Style _
                                                  = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ChargesCodes").ValueList = Me.DropDownCharges

        End With

        If CurrentUser.IsAccountAdmin = False Then
            With Me.GridDeposits.DisplayLayout.Bands(0)
                .Override.AllowUpdate = DefaultableBoolean.False
            End With
        End If
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_MenuItems.Columns.ItemLevel, ItemLevel, MatchType.StartsWith)
        Items = Dm.GetTB_MenuItemsCollection

        Dm.QueryCriteria.Clear()
        For Each Item As TB_MenuItems In Items
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.MenuItemID, Item.ID, MatchType.Exact)
            Dm.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.UserID, CurrentUser.ID, MatchType.Exact)
            AccessLevel = Dm.GetTB_AccessLevelCollection
            If Not AccessLevel Is Nothing Then

                Try
                    Me.ToolbarsManager.Toolbars(0).Tools.Item(Item.ItemKey).SharedProps.Enabled = AccessLevel(0).Accessble
                Catch ex As Exception

                End Try

                Try
                    Me.ToolStripForm.Items(Item.ItemKey).Enabled = AccessLevel(0).Accessble
                Catch ex As Exception

                End Try
            End If
        Next
        If Not Me.TextBlNo.TextValue = "" Then
            FindInvoices()
        End If
    End Sub

    Private Sub ToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarsManager.ToolClick

        Select Case e.Tool.Key
            Case "Find"
                FindInvoices()
            Case "Close"
                Me.Close()
            Case "Blank Invoice"
                IsBlank = True
                isArrival = False
                GenerateNew(False, False)
            Case "Edit"
                IsBlank = False
                EditInvoices()
            Case "Generate"
                IsBlank = False
                isArrival = True
                If MsgBox("Do You Want To Calculate Only Strip Charges ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    GenerateNew(True, True)
                Else
                    GenerateNew(True, False)
                End If
            Case "DetentionList"
                GenerateDetention("Old")
            Case "DetentionListNew"
                GenerateDetention("New")
            Case "D.O."
                Generatedo()
            Case "Deposit"
                GenerateDeposit()
            Case "Generate Detention"
                isArrival = False
                GenerateDetentionInv()
            Case "Mail"
                InvoiceMail()
            Case "Fax"
                InvoiceFax()
        End Select

    End Sub

    Private Sub FindInvoices()

        Dim aTables() As String = {"TB_Invoice", "TB_InvoiceDetails", "TB_Deposits", "TB_InwardCharges"}
        Dim DS As New DataSet
        Dim nI As Byte
        Dim Codes As TB_CODE
        Dim TB As New DataTable

        Dim lResult As Boolean

        lValidBlNno = False

        Me.DataSetForm.Tables(0).Clear()
        Me.DataSetForm.Tables(1).Clear()
        Me.DataSetForm.Tables(2).Clear()

        Bls = Nothing
        Clnt = Nothing

        Dm = New DataManager(My.Settings.DSN)

        Me.LabelStatus.ForeColor = Color.Black
        Me.LabelDeposit.ForeColor = Color.Black
        Me.LabelStatus.Font = New Font(LabelStatus.Font, FontStyle.Regular)
        Me.LabelDeposit.Font = New Font(LabelDeposit.Font, FontStyle.Regular)
        Me.UltraLabel5.Text = ""
        Me.UltraLabel6.Text = ""

        DS = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, Me.TextBlNo.TextValue)
        If DS.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No valid B/L No ?", "Data Requird")
            Exit Sub
        End If

        Dm.PopulateObjectsFromDataSet(DS, "TB_InwardBls")
        Dm.DataSet.Tables("TB_InwardBls").Merge(DS.Tables(0))

        Bls = Dm.GetTB_InwardBLSCollectionFromDataSet()

        Bl = Bls(0)
        Try
            If IsDBNull(Bl.ClientID) Then
                MsgBoxGeneral("No Valid Client Assign To this B/L !", "Data Requird ")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBoxGeneral("No Valid Client Assign To this B/L !", "Data Requird ")
            Exit Sub
        End Try

        If Bl.ClientID.ToString = "" Then
            MsgBoxGeneral("No Valid Client Assign To This B/L !", "Data Requird ")
            Exit Sub
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bl.ClientID, MatchType.Exact)
        Clnt = Dm.GetTB_Clients

        If Clnt Is Nothing Then
            MsgBoxGeneral("Invalid Client !", "Data Requird ")
            Exit Sub
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "AS", MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, NullToValue(Clnt.AccountStatus, ""), MatchType.Exact)
        Codes = Dm.GetTB_CODE
        If Codes Is Nothing Then
            Me.LabelStatus.Text = "No Data"
        Else
            Me.LabelStatus.Text = Codes.MEANING
            ''If Codes.MEANING = "Bad Account" Then
            Me.LabelStatus.ForeColor = Color.Red
            Me.LabelDeposit.ForeColor = Color.Red
            Me.LabelStatus.Font = New Font(LabelStatus.Font, FontStyle.Bold)
            Me.LabelDeposit.Font = New Font(LabelDeposit.Font, FontStyle.Bold)

            'Else
            '    Me.LabelStatus.Font = New Font(LabelStatus.Font, FontStyle.Bold)
            '    Me.LabelDeposit.Font = New Font(LabelDeposit.Font, FontStyle.Bold)
            'End If
        End If
        Me.LabelDeposit.Text = Format(NullToValue(Clnt.Deposit.ToString, 0), "Standard")

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Bl.VoyageID, MatchType.Exact)
        Voy = Dm.GetTB_Voyage

        If Voy Is Nothing Then
            MsgBoxGeneral("No Valid Voyage In B/L Data !", "Data Requird ")
            Exit Sub
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Bl.VoyageID, MatchType.Exact)
        Sof = Dm.GetTB_SOF

        If Sof Is Nothing Then
            MsgBoxGeneral("No SOF Data For This Voyage !", "Data Requird ")
            Exit Sub
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
        Vsl = Dm.GetTB_Vessels

        DS = StoredProcedures.SP_InvoiceByBLID(Bl.ID.ToString)
        Dm.PopulateObjectsFromDataSet(DS, aTables)
        For nI = 0 To aTables.Length - 1
            Dm.DataSet.Tables(aTables(nI)).Merge(DS.Tables(nI))
        Next
        Me.DataSetForm.Tables("TB_Invoice").Merge(Dm.DataSet.Tables("TB_Invoice"))
        Me.DataSetForm.Tables("Tb_Deposits").Merge(Dm.DataSet.Tables("TB_Deposits"))
        If Dm.DataSet.Tables("TB_Invoice").Rows.Count > 0 Then
            Me.Remarks.TextValue = Dm.DataSet.Tables("TB_Invoice").Rows(0).Item("Description")
        Else
            Me.Remarks.TextValue = ""
        End If

        TableBySql("Select Seq,ChargesCode,Currency,Amount,RealAmount,Terms from TB_InwardCharges where Terms='P'and BLID  = '" & Bl.ID.ToString & "'", TB, lResult)

        If lResult = True Then
            If TB.Rows.Count > 0 Then
                Me.GridBLCharges.DataSource = TB
            End If
        End If

        TableBySql("select	'DETN-A' Chargescode, Amount, IrrAmount, Description Remarks from  TB_RecivedItems where invoiceid in (select id from tb_invoice where blid ='" & Bl.ID.ToString & "' ) and paymenttype = 'DETN-A'", TB, lResult)
        TableBySql("select	isnull(sum(Amount),0) Amount, isnull(sum(IrrAmount),0) IrrAmount from TB_RecivedItems where invoiceid in (select id from tb_invoice where blid ='" & Bl.ID.ToString & "' ) and paymenttype = 'DETN-A'", TBDETN, lResult)

        If lResult = True Then
            If TB.Rows.Count > 0 Then
                Me.GridDetnAdvance.DataSource = TB
            End If
        End If

        'Me.GridBLCharges.DataSource = Dm.DataSet.("Select ChargesCode,Currency,Amount,RealAmount,Terms from TB_InwardCharges where Terms='P'")
        GridNumSeperator(Me.GridBLCharges)
        Me.DataSetForm.AcceptChanges()
        lValidBlNno = True
        SetDocument()
        ' Significant Remark Required For B/Ls with Discount
        Dim labelBl = Me.ToolbarsManager.Tools.Item(5)
        labelBl.SharedProps.Caption = "B/L No"
        Dim TB1 As New System.Data.DataTable
        Dim sSql As String
        Dim lResults As Boolean

        sSql = "SELECT dPercent,dAmount FROM TB_InwardDiscount WHERE BLID='" & Bl.ID.ToString + "' and dpercent is not null and dAmount is not null"
        TableBySql(sSql, TB1, lResults)
        If (TB1.Rows.Count > 0) Then
            For Each drBldiscount As DataRow In TB1.Rows
                If (drBldiscount("dPercent") = 0 And drBldiscount("dAmount") = 0) Then
                    labelBl.SharedProps.Caption = "B/L No"
                ElseIf (drBldiscount("dPercent") > 0 Or drBldiscount("dAmount") > 0) Then
                    labelBl.SharedProps.Caption = "B/L No **"
                End If
            Next
        End If
        'End Significant Remark Required For B/Ls with Discount
        Dim TB2 As New System.Data.DataTable
        Dim sSql2 As String
        Dim lResults2 As Boolean
        sSql2 = "select (select top 1 lName from tb_clients where id = agentID) Agent,  (select top 1 Meaning from tb_code where groupcode = 'AS' and STDcode = (select top 1 AccountStatus from tb_clients where id = agentID)) as accountStatus from tb_inwardbls where  id = '" & Bl.ID.ToString + "' and agentid is not null"
        TableBySql(sSql2, TB2, lResults2)
        If (TB2.Rows.Count > 0) Then
            For Each drBldiscount As DataRow In TB2.Rows
                If Not IsDBNull(drBldiscount("Agent")) Then
                    UltraLabel5.Text = drBldiscount("Agent")
                End If
                If Not IsDBNull(drBldiscount("accountStatus")) Then
                    UltraLabel6.Text = drBldiscount("accountStatus")
                End If
                Me.UltraLabel5.Font = New Font(UltraLabel5.Font, FontStyle.Bold)
                Me.UltraLabel6.Font = New Font(UltraLabel6.Font, FontStyle.Bold)
                Me.UltraLabel5.ForeColor = Color.Red
                Me.UltraLabel6.ForeColor = Color.Red
            Next
        End If
    End Sub

    Private Sub GenerateNew(ByVal IsCalculateNew As Boolean, ByVal IsStrip As Boolean)


        Dim Tb As DataTable

        Dim TbDep As DataTable
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Err As DataTable
        Dim Frm As FrmRaiseError
        Dim Dtn As New CLDetention
        Dim Dv As DataView
        Dim nI As Long
        Dim Drs() As DataRow
        Dim NewDrTHC As DataRow
        Dim deposits As TB_DepositsCollection
        Dim Deposit As TB_Deposits
        Dim TBcur As New DataTable
        Dim sSql As String
        Dim IResult As Boolean
        Dim ClientTHCP As Integer
        Dim TBct As New DataTable

        If IsCalculateNew = True Then
            isArrival = True
        Else
            isArrival = False
        End If

        sSql = "select ClientType from TB_Clients where ID = '" & Bl.ClientID.ToString & "'"
        TableBySql(sSql, TBct, IResult)

        ' If MsgBox("Do You Want To Apply Discount for DO, EPL and TIL?", MsgBoxStyle.YesNo, "SAOI Membership Discount") = MsgBoxResult.Yes Then
        If TBct.Rows.Count > 0 Then
            If Not TBct.Rows(0).Item("ClientType") = "NR" Then
                isDiscount = True
            Else
                isDiscount = False
            End If
        Else
            isDiscount = False
        End If
        IsDetention = False
        TotalCostIrr = 0
        TotalCostUsd = 0

        DataSetForm.Tables("TB_Invoice").Clear()
        DataSetForm.Tables("TB_InvoiceDetails").Clear()
        DataSetForm.Tables("TB_Deposits").Clear()
        Me.DataSetForm.AcceptChanges()

        If Me.TextBlNo.TextValue = "" Then
            Exit Sub
        End If

        Dm = New DataManager(My.Settings.DSN)

        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.TextBlNo.TextValue, MatchType.Exact)
        Bl = Dm.GetTB_InwardBLS()

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Deposits.Columns.BLID, Bl.ID)
        deposits = Dm.GetTB_DepositsCollection

        sSql = "select DetnCurrency from TB_InwardBls where ID = '" & Bl.ID.ToString & "'"
        TableBySql(sSql, TBcur, IResult)

        DetnCurrency = "IRR"
        If Not TBcur.Rows.Count = 0 And Not TBcur.Rows(0).Item("DetnCurrency").ToString() = "" Then
            DetnCurrency = NullToValue(TBcur.Rows(0).Item("DetnCurrency").ToString(), "IRR")
        End If

        If deposits.Count > 0 Then
            For Each Deposit In deposits
                NewDr = DataSetForm.Tables("TB_Deposits").NewRow
                NewDr("ID") = Deposit.ID
                NewDr("BLID") = Deposit.BLID
                NewDr("ChargesCodes") = Deposit.ChargesCodes

                If Val(Deposit.Amount.ToString) = 0 Then
                    NewDr("Amount") = 0
                Else
                    NewDr("Amount") = Double.Parse(NullToValue(Deposit.Amount, 0).ToString)
                End If

                NewDr("Remarks") = Deposit.Remarks
                DataSetForm.Tables("TB_Deposits").Rows.Add(NewDr)
            Next
            Me.DataSetForm.AcceptChanges()
        End If

        InvStatus = InvoiceStatus.Issue
        Me.Remarks.TextValue = ""
        If lValidBlNno = False Then
            Exit Sub
        End If

        InvID = System.Guid.NewGuid

        If IsCalculateNew = True Then
            Arvl = New CLArrivalNotice
            ArvDep = New CLArrivalNotice
            ' Arvl.GenArrivalNotice(Dm.DataSet.Tables("TB_InwardBls").Rows(0), Sof.Berthed, Voy)
            'appu - based on mehdi reqrmnt
            Arvl.GenArrivalNotice(Dm.DataSet.Tables("TB_InwardBls").Rows(0), Now, Voy)
            Err = Arvl.GetTbError
            Tb = Arvl.GetTBDetails
            If Err.Rows.Count <> 0 Then
                Frm = New FrmRaiseError(Err)
                Frm.ShowDialog()
                Exit Sub
            End If
            Me.Remarks.TextValue = IIf(Clnt.fName = "", Clnt.lName, Clnt.fName)

            Tb.AcceptChanges()

            If IsStrip = True Then
                For Each Dr In Tb.Rows
                    If Dr("ConditionalAmount") > 0 Then
                        Dr.Delete()
                    End If
                Next
                Tb.AcceptChanges()
            End If

            For Each Dr In Tb.Rows
                If Dr("IsDeposit") = False And (Dr("ActualAmount") + Dr("MandatoryAmount") + Dr("ConditionalAmount")) > 0 Then
                    NewDr = DataSetForm.Tables("TB_InvoiceDetails").NewRow
                    NewDr("ID") = System.Guid.NewGuid
                    NewDr("InvoiceID") = InvID
                    NewDr("ChargesCode") = Dr("ChargeItem")
                    NewDr("Seq") = Dr("Seq")
                    NewDr("Amount") = Dr("ActualAmount")
                    If Mid(Dr("CurCode"), 1, 2) = "US" Then
                        If Dr("ChargeItem") = "THC" Or Dr("ChargeItem") = "LCL/DC" Or Dr("ChargeItem") = "STR" Then
                            NewDr("IrrAmount") = Dr("MandatoryAmount") + Dr("ConditionalAmount")
                        Else
                            NewDr("IrrAmount") = 0
                        End If
                    Else
                        NewDr("IrrAmount") = Dr("MandatoryAmount") + Dr("ConditionalAmount")
                    End If
                    NewDr("Currency") = Dr("CurCode")
                    NewDr("Remarks") = Dr("MeaningF")
                    DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(NewDr)
                Else
                    Beep()
                End If
            Next

            If Now.Date >= "03/21/2021" Then
                Drs = Tb.Select("ChargeItem = 'THC'")
                If Drs.Length > 0 Then

                    If TBct.Rows.Count > 0 Then
                        If TBct.Rows(0).Item("ClientType") = "NR" Then
                            ClientTHCP = 3
                        Else
                            ClientTHCP = 2
                        End If
                        For Each Dr In Drs
                            NewDrTHC = DataSetForm.Tables("TB_InvoiceDetails").NewRow
                            NewDrTHC("ID") = System.Guid.NewGuid
                            NewDrTHC("InvoiceID") = InvID
                            NewDrTHC("ChargesCode") = "THC-A"
                            NewDrTHC("Seq") = Dr("Seq")
                            NewDrTHC("Amount") = (Dr("ActualAmount") / 100) * ClientTHCP
                            NewDrTHC("IrrAmount") = (Dr("MandatoryAmount") / 100) * ClientTHCP
                            NewDrTHC("Currency") = "USD"
                            NewDrTHC("Remarks") = "THC هزینه کارگزاری"
                            DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(NewDrTHC)

                        Next
                    End If
                End If
            End If
            '       Dtn.GenerateImportDetention(Dm.DataSet.Tables("TB_InwardBls").Rows(0).Item(0))
            Dtn.CalDetention(Me.Bl.BlNo, Me.Bl.ID, False)

            If Dtn.Balance > 0 Then
                NewDr = DataSetForm.Tables("TB_InvoiceDetails").NewRow
                NewDr("ID") = System.Guid.NewGuid
                NewDr("InvoiceID") = InvID
                NewDr("ChargesCode") = "DETN-A"
                NewDr("Seq") = 10
                NewDr("Amount") = Dtn.Balance
                NewDr("IrrAmount") = Dtn.Balance
                NewDr("Currency") = "IRR"
                NewDr("Remarks") = "علی الحساب حق توقف"
                DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(NewDr)
            End If

            Dv = New DataView(DataSetForm.Tables("TB_InvoiceDetails"), "", "Seq", DataViewRowState.CurrentRows)
            For nI = 0 To Dv.Count - 1
                Dv.Item(nI).Item("Seq") = (nI + 1)
            Next


            'appu - deposit based on dschrdate by mehdi

            ArvDep = New CLArrivalNotice

            ''ArvDep.GenArrivalNotice(Dm.DataSet.Tables("TB_InwardBls").Rows(0), Sof.DschCmpl, Voy)
            ArvDep.GenArrivalNotice(Dm.DataSet.Tables("TB_InwardBls").Rows(0), Now, Voy)
            Err = ArvDep.GetTbError
            TbDep = ArvDep.GetTBDetails



            For Each Dr In TbDep.Rows
                If Dr("IsDeposit") = True Then
                    Drs = DataSetForm.Tables("TB_Deposits").Select("ChargesCodes = '" & Dr("ChargeItem") & "'")
                    If Drs.Length = 0 Then
                        NewDr = DataSetForm.Tables("TB_Deposits").NewRow
                        NewDr("ID") = System.Guid.NewGuid
                        NewDr("BLID") = Bl.ID
                        NewDr("ChargesCodes") = Dr("ChargeItem")
                        NewDr("Amount") = Dr("DepositAmount")
                        NewDr("Remarks") = Dr("MeaningF")
                        DataSetForm.Tables("TB_Deposits").Rows.Add(NewDr)
                    End If
                End If


            Next

        Else
            Me.Remarks.TextValue = IIf(Clnt.fName = "", Clnt.lName, Clnt.fName)
        End If

        InvStatus = InvoiceStatus.Issue

        If IsBlank = False Then
            RecalculateTax()
        End If
    End Sub

    Private Sub EditInvoices()

        If Me.GridList.Rows.Count = 0 Then
            Exit Sub
        End If

        InvID = Me.GridList.ActiveRow.Cells("ID").Value
        SetDocument()

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ToolStripSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        If ValidateForm() = False Then
            MsgBoxValidateFaild()
            Exit Sub
        End If
        SaveDocument(InvStatus)
    End Sub

    Private Sub SaveDocument(ByVal Status As InvoiceStatus)

        Dim LogDataSet As New DataSet
        Dim Dr As DataRow
        Dim DsChgs As DataSet = DataSetForm.GetChanges
        Dim Tb As DataTable
        Dim Dv As DataView
        Dim DC As DataColumn
        Dim CurrentStatus As InvoiceStatus
        Dim nI As Byte
        Dim Drv As DataRowView

        Me.GridDetail.Update()
        Me.GridDetail.UpdateData()

        If lValidBlNno = False Then
            MsgBoxValidateFaild()
            Exit Sub
        End If

        If Me.GridDetail.Rows.Count = 0 Then
            Exit Sub
        End If

        If InvStatus = InvoiceStatus.Confirm Or InvStatus = InvoiceStatus.Cancel Or InvStatus = InvoiceStatus.ToAccount Then
            MsgBoxGeneral("Not allow !", "Change Invoice Content")
            Exit Sub
        End If

        InvStatus = Status

        If MsgBoxUpdate() <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If

        Dv = New DataView(Dm.DataSet.Tables("TB_Invoice"), "ID = '" & InvID.ToString & "'", "", DataViewRowState.CurrentRows)
        If Dv.Count = 0 Then
            Dr = Dm.DataSet.Tables("TB_Invoice").NewRow()
            Dr("ID") = InvID
            Dr("BlID") = Bl.ID
            Dr("IssueTime") = Format(Now, "Short Date")
            Dr("IssueBy") = CurrentUser.UserCode
            Dr("Status") = Int32.Parse(InvStatus)
            Dr("Description") = Me.Remarks.TextValue
            Dm.DataSet.Tables("TB_Invoice").Rows.Add(Dr)
            CurrentStatus = Int32.Parse(InvStatus)
        Else
            CurrentStatus = Dv.Item(0).Item("Status")
            If Byte.Parse(InvStatus) < 3 Then
                If NullToValue(Dv.Item(0).Item("InvoiceNo"), "") = "" And InvStatus = InvoiceStatus.Confirm Then
                    Dv.Item(0).Item("InvoiceNo") = GetNewInvNo(InOut.InWard)
                    Dv.Item(0).Item("ConfirmTime") = Today
                    Dv.Item(0).Item("ConfirmBy") = CurrentUser.UserCode
                    Dv.Item(0).Item("IssueOffice") = My.Settings.Office
                End If
                Dv.Item(0).Item("Status") = Int32.Parse(InvStatus)
                Dv.Item(0).Item("Description") = Me.Remarks.TextValue
            Else
                MsgBox("Not Allowed !")
                Exit Sub
            End If
        End If


        For Each Dr In Me.DataSetForm.Tables("TB_InvoiceDetails").Rows
            If Dr.RowState = DataRowState.Added Or Dr.RowState = DataRowState.Modified Then
                If Dr("Currency") = "IRR" And NullToValue(Dr("Amount"), 0) = 0 Then
                    Dr("Amount") = Dr("IRRAmount")
                End If
            End If
        Next


        Tb = Me.DataSetForm.Tables("TB_InvoiceDetails").GetChanges
        If Not Tb Is Nothing Then
            For Each Dr In Tb.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        Dm.DataSet.Tables("TB_InvoiceDetails").ImportRow(Dr)
                    Case DataRowState.Deleted
                        Dv = New DataView(Dm.DataSet.Tables("TB_InvoiceDetails"), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            Dv.Item(0).Delete()
                        End If
                    Case DataRowState.Modified
                        Dv = New DataView(Dm.DataSet.Tables("TB_InvoiceDetails"), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            For Each DC In Tb.Columns
                                Dv.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                            Next
                        End If
                End Select
            Next
        End If


        Tb = Me.DataSetForm.Tables("TB_Deposits").GetChanges
        If Not Tb Is Nothing Then
            For Each Dr In Tb.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        Dm.DataSet.Tables("TB_Deposits").ImportRow(Dr)
                    Case DataRowState.Deleted
                        Dv = New DataView(Dm.DataSet.Tables("TB_Deposits"), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            Dv.Item(0).Delete()
                        End If
                    Case DataRowState.Modified
                        Dv = New DataView(Dm.DataSet.Tables("TB_Deposits"), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            For Each DC In Tb.Columns
                                Dv.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                            Next
                        End If
                End Select
            Next
        End If

        nI = 0
        Dv = New DataView(Dm.DataSet.Tables("TB_InvoiceDetails"), "", "Seq", DataViewRowState.CurrentRows)
        For Each Drv In Dv
            nI += 1
            Drv.Item("Seq") = nI
        Next

        Try
            LogDataSet = Dm.DataSet.Copy
            Dm.CommitAll()
            GenerateLog(LogDataSet)
            FindInvoices()
            MsgBoxSaveSuccessful()
            ' Significant Remark Required For B/Ls with Discount
            Dim TB1 As New System.Data.DataTable
            Dim sSql As String
            Dim lResults As Boolean
            sSql = "SELECT dPercent,dAmount FROM TB_InwardDiscount WHERE BLID='" & Bl.ID.ToString + "'"
            TableBySql(sSql, TB1, lResults)
            Dim labelBl = Me.ToolbarsManager.Tools.Item(5)
            If (TB1.Rows.Count > 0) Then
                For Each drBldiscount As DataRow In TB1.Rows
                    If (drBldiscount("dPercent") = 0 And drBldiscount("dAmount") = 0) Then
                        labelBl.SharedProps.Caption = "B/L No"
                    ElseIf (drBldiscount("dPercent") > 0 Or drBldiscount("dAmount") > 0) Then
                        labelBl.SharedProps.Caption = "B/L No **"
                    End If
                Next
            End If
            'End Significant Remark Required For B/Ls with Discount
        Catch ex As Exception
            InvStatus = CurrentStatus
            MsgBoxSaveFailed()
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub SetDocument()

        Dim aRows() As DataRow
        Dim Dr As DataRow
        Dim sCntr As String = ""
        Dim lResult As Boolean
        Dim TB As New DataTable


        aRows = Dm.DataSet.Tables("TB_InvoiceDetails").Select("InvoiceID = '" & InvID.ToString & "'")
        Me.DataSetForm.Tables("TB_InvoiceDetails").Clear()
        Me.DataSetForm.Tables("TB_Summary").Clear()

        For Each Dr In aRows
            Me.DataSetForm.Tables("TB_InvoiceDetails").ImportRow(Dr)
        Next

        If Not Me.GridList.ActiveRow Is Nothing Then
            Me.GridList.Rows(0).Selected = True
            Me.Remarks.TextValue = Me.GridList.ActiveRow.Cells("Description").Text
            InvStatus = Me.GridList.ActiveRow.Cells("Status").Value
        End If

        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Vessel"
        Dr("Value") = Vsl.VesselName
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)


        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Voyage"
        Dr("Value") = Voy.VoyageNo
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)

        InwardCntrsCount(Bl.ID, sCntr)
        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Total Containers"
        Dr("Value") = Replace(sCntr, vbCrLf, " & ")
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)

        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Status"
        Dr("Value") = GetMeaningCode("ST", Bl.BLStatus)
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)

        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Exchange Rate Freight"
        Dr("Value") = Voy.ExchangeFrt
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)

        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Exchange Rate THC"
        Dr("Value") = Voy.ExchangeThc
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)

        Try
            Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
            Dr("Description") = "Arrival"
            Dr("Value") = Sof.Arrival
            Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)
        Catch ex As Exception
        End Try

        TableBySql("Select dbo.FC_InwardBLIsImco ('" & Bl.ID.ToString & "')", TB, lResult)

        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "IMCO"

        If lResult = True Then
            If TB.Rows(0).Item(0) = "Y" Then
                Dr("Value") = "Yes"
            Else
                Dr("Value") = "No"
            End If
        Else
            Dr("Value") = "No"


        End If

        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)


    End Sub

    Private Sub GridList_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridList.AfterRowActivate

        If InvID <> Me.GridList.ActiveRow.Cells("ID").Value Then
            InvID = Me.GridList.ActiveRow.Cells("ID").Value
        End If
        SetDocument()

    End Sub

    Private Sub ToClientButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToClientButton.Click

        If InvStatus = InvoiceStatus.Issue Then
            SaveDocument(InvoiceStatus.ToClient)
        Else
            MsgBoxGeneral("Not allow !", "Change Invoice Status")
        End If

    End Sub

    Private Sub ToAccountButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToAccountButton.Click

        If Int32.Parse(InvStatus) = InvoiceStatus.Issue Or Int32.Parse(InvStatus) = InvoiceStatus.ToClient Then
            SaveDocument(InvoiceStatus.ToAccount)
        Else
            MsgBoxGeneral("Not allow !", "Change Invoice Status")
        End If

    End Sub

    Private Sub ConfirmButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Int32.Parse(InvStatus) = InvoiceStatus.ToAccount Then
            SaveDocument(InvoiceStatus.Confirm)
        Else
            MsgBoxGeneral("Not allow !", "Change Invoice Status")
        End If

    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Int32.Parse(InvStatus) = InvoiceStatus.Confirm Then
            SaveDocument(InvoiceStatus.Cancel)
        Else
            MsgBoxGeneral("Not allow !", "Change Invoice Status")
        End If

    End Sub

    Private Function ValidateForm() As Boolean

        Dim Ans As Boolean = True
        Dim dr As DataRow

        If Me.Remarks.TextValue = "" Then
            Ans = False
        End If

        If Me.GridDetail.Rows.Count = 0 Then
            Ans = False
        End If

        For Each dr In DataSetForm.Tables("TB_InvoiceDetails").Rows
            If dr.RowState <> DataRowState.Deleted Then
                If NullToValue(dr("Seq"), 0) = 0 Or _
                   NullToValue(dr("ChargesCode"), "") = "" Or _
                   NullToValue(dr("Remarks"), "") = "" Or _
                   NullToValue(dr("Currency"), "") = "" Or _
                   NullToValue(dr("Amount"), 0) + NullToValue(dr("IrrAmount"), 0) = 0 Then
                    dr.RowError = "No Completed Data !"
                    Ans = False
                Else
                    dr.RowError = ""
                End If
            End If
        Next
        Return Ans

    End Function

    Private Sub GridDetail_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GridDetail.AfterRowInsert
        If Not IsBlank Then
            RecalculateTax()
        End If
    End Sub

    Private Sub GridDetail_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetail.AfterRowsDeleted
        If Not IsBlank Then
            RecalculateTax()
        End If
    End Sub

    Private Sub GridDetail_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridDetail.BeforeRowUpdate
        If GridDetail.ActiveRow.Cells("InvoiceID").Value.ToString = "" Then
            GridDetail.ActiveRow.Cells("InvoiceID").Value = InvID
        End If
    End Sub

    Private Sub GridDetail_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridDetail.InitializeLayout

        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells

        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32

    End Sub

    Private Sub GridDeposits_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridDeposits.InitializeLayout
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click

        Dim LogDataSet As New DataSet
        Dim Dv As DataView
        Dim dr As DataRow
        If Me.GridList.Rows.Count = 0 Then
            Exit Sub
        End If

        If Int32.Parse(InvStatus) = InvoiceStatus.ToAccount Or Int32.Parse(InvStatus) = InvoiceStatus.Confirm Or Int32.Parse(InvStatus) = InvoiceStatus.Cancel Then
            MsgBoxGeneral("Not allow !", "Change Invoice Status")
            Exit Sub
        End If

        If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
            Dv = New DataView(Dm.DataSet.Tables("TB_Invoice"), "ID = '" & InvID.ToString & "'", "", DataViewRowState.CurrentRows)
            If Dv.Count > 0 Then
                For Each dr In Me.DataSetForm.Tables("TB_InvoiceDetails").Rows
                    If dr("InvoiceID").ToString = InvID.ToString Then
                        dr.Delete()
                    End If
                Next
                Dv.Item(0).Delete()
            End If
        Else
            Exit Sub
        End If

        Try
            LogDataSet = Dm.DataSet.Copy
            Dm.CommitAll()
            GenerateLog(LogDataSet)
            MsgBoxDeleteSuccessful()
        Catch ex As Exception
            MsgBoxDeleteFailed()
        End Try

        FindInvoices()

    End Sub

    Private Sub InvoiceMail()
        Dim Sum As CLInwardBlsSummary
        Dim Dtn As New CLDetention
        Dim BLID As Guid
        Dim ds As New DataSet
        Dim Report As RptInwardDetention
        Dim Frm As New FrmGeneralReportShow
        Dim PH As New CLPrintHdr
        Dim Dscnt As TB_InwardDiscount
        Dim sDscnt As String = ""
        Dim Col As DataColumn
        Dim Clnt As TB_Clients
        Dim Status As TB_InwardStatus
        Dim Inv As TB_Invoice
        Dim InvD As TB_InvoiceDetails
        Dim lResult As Boolean
        Dim TB As New DataTable
        Dim sSql As String
        Dim Cmd As New SqlCommand
        Dim DA1 As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)

        Dim TbSum As New DataTable


        isArrival = False

        ds = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, Me.TextBlNo.TextValue)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No valid B/L No ?", "Data Requird")
            Exit Sub
        End If
        Sum = New CLInwardBlsSummary(ds.Tables(0).Rows(0).Item("Id"))

        BLID = ds.Tables(0).Rows(0).Item("ID")
        '     Dtn.GenerateImportDetention(BLID)
        'ds = Dtn.CalDetention(Me.TextBlNo.TextValue, BLID, , Me.ExtraDays.Value)
        'Above code commented and below code added for demurrage invoices changes (removal of last label - Company Account Details) REMOVING ONE SENTENCE FROM DEMURRAGE INVOICES
        ds = Dtn.CalDetentionInwardInvoice(Me.TextBlNo.TextValue, BLID, False, Me.ExtraDays.Value)


        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLID, MatchType.Exact)
        Dscnt = Dm.GetTB_InwardDiscount()
        If Not Dscnt Is Nothing Then
            If Dscnt.dFreeDays > 0 And Dscnt.IsFDaysAsDiscount = True Then
                sDscnt = "Free Days is " & Dscnt.dFreeDays.ToString
            End If
            If Dscnt.dAmount > 0 Then
                sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Amount is " & Format(Double.Parse(Dscnt.dAmount), "#,###")
            End If
            If Dscnt.dPercent > 0 Then
                sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Persent is " & Dscnt.dPercent.ToString
            End If
            sDscnt = IIf(sDscnt <> "", "DISCOUNT DETAILS :", "") & sDscnt
        End If
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bl.ClientID, MatchType.Exact)
        Clnt = Dm.GetTB_Clients


        Col = New DataColumn("TEL", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("FAX", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("EMAIL", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("Reference", System.Type.GetType("System.Int64"))
        Col.DefaultValue = 0
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("DoDate", System.Type.GetType("System.DateTime"))
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("IssueDate", System.Type.GetType("System.DateTime"))
        ds.Tables(0).Columns.Add(Col)

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, BLID, MatchType.Exact)
        Status = Dm.GetTB_InwardStatus


        sSql = "Select Top 1 I.IssueTime  From TB_Invoice I, TB_InvoiceDetails D Where I.ID =D.InvoiceID and D.ChargesCode ='DETN' and I.Status < 4  and I.BLID = '" & BLID.ToString & "' Order by I.Status"
        TableBySql(sSql, TB, lResult)

        Dim sSqlRemarks As String
        For Each dr As DataRow In ds.Tables(0).Rows

            ' Significant Remark Required For B/Ls with Discount
            Dim TB1 As New System.Data.DataTable
            Dim lResults As Boolean
            Dim labelBl = Me.ToolbarsManager.Tools.Item(5)
            sSqlRemarks = "SELECT dPercent,dAmount FROM TB_InwardDiscount WHERE BLID='" & Bl.ID.ToString + "'"
            TableBySql(sSqlRemarks, TB1, lResults)
            If (TB1.Rows.Count > 0) Then
                For Each drBldiscount As DataRow In TB1.Rows
                    If (drBldiscount("dPercent") = 0 And drBldiscount("dAmount") = 0) Then
                        dr(2) = dr(2)
                    ElseIf (drBldiscount("dPercent") > 0 Or drBldiscount("dAmount") > 0) Then
                        dr(2) = "** " & dr(2) & " **"
                    End If
                Next
            End If
            'End Significant Remark Required For B/Ls with Discount

            Try
                dr("Reference") = Int64.Parse(Bl.Reference)
            Catch ex As Exception
                dr("Reference") = 0
            End Try
            If Not Clnt Is Nothing Then
                dr("TEL") = Clnt.TEL
                dr("Fax") = Clnt.Fax
                dr("EMAIL") = Clnt.Email
            End If

            If Not Status Is Nothing Then
                Try
                    dr("DoDate") = CDate(Status.DoDate)
                Catch ex As Exception

                End Try

            End If

            If TB.Rows.Count > 0 Then
                dr("IssueDate") = TB.Rows(0).Item(0)
            Else
                dr("IssueDate") = Today
            End If


        Next

        TbSum = GenSummaryDetention(Dtn, ds)

        With ds.Tables(1)
            .Columns.Add(New DataColumn("DetentionVat", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DamageVat", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Totalpaid", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DetentionBalance", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DamagePaid", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DamageBlanace", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Deposit", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Balance", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("TotalDamageCost", System.Type.GetType("System.Double")))
        End With


        Report = New RptInwardDetention
        Report.SetDataSource(ds.Tables(0))
        Report.Subreports("RptInwardDetentionSub").SetDataSource(ds.Tables(1))
        Report.Subreports("DetentionSub2").SetDataSource(TbSum)
        Frm.ReportViewer.ReportSource = Report
        Dim path As String = Directory.GetParent(Directory.GetCurrentDirectory()).ToString()
        If System.IO.File.Exists(path + "\Invoice.pdf") = True Then
            ' System.IO.File.Delete(MailFile)
        End If

        Report.ExportToDisk(ExportFormatType.PortableDocFormat, path + "\Invoice.pdf")


        Dim mail As New MailMessage()

        'Dim SmtpServer As New SmtpClient("smtp.gmail.com")
        'mail.From = New MailAddress("smappubca@gmail.com")
        'SmtpServer.Credentials = New System.Net.NetworkCredential("smappubca@gmail.com", "B@r@thi89")
        'SmtpServer.EnableSsl = True
        'SmtpServer.Port = 587 ' SMTP Email Server port


        Dim SmtpServer As New SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("SmtpClient").ToString())
        mail.From = New MailAddress(System.Configuration.ConfigurationSettings.AppSettings("MailAddress").ToString())
        SmtpServer.Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings("port").ToString()) ' SMTP Email Server port
        SmtpServer.Credentials = New System.Net.NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings("MailAddress").ToString(), System.Configuration.ConfigurationSettings.AppSettings("password").ToString())
        SmtpServer.EnableSsl = False


        Dim attachment As System.Net.Mail.Attachment
        attachment = New System.Net.Mail.Attachment(path + "\Invoice.pdf")
        mail.Attachments.Add(attachment)
        Dim clientmail As String
        clientmail = Clnt.Email

        If Clnt.Email = "" Then
            MessageBox.Show("Client has no Mail Id!")
            Exit Sub
        End If

        If Not Clnt.Email.Contains("@") Then
            MessageBox.Show("Client Invalid Client Mail id")
            Exit Sub
        Else
            Try
                If MessageBox.Show("Are You Sure To send the mail to " + clientmail + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    mail.[To].Add(clientmail)
                    'mail.[To].Add("appumca12@gmail.com")
                    mail.[CC].Add(System.Configuration.ConfigurationSettings.AppSettings("CC").ToString())
                    mail.[Bcc].Add(System.Configuration.ConfigurationSettings.AppSettings("BCC").ToString())
                    mail.Subject = "ILS-Detention Invoice for BL- " + Me.TextBlNo.TextValue
                    mail.Body = "Dear " + ds.Tables(0).Rows(0).Item("Client") + " !" + vbNewLine + vbNewLine + " Good day," + vbNewLine + vbNewLine + "Please find enclosed detention invoice of B/L no. " + Me.TextBlNo.TextValue + vbNewLine + "Seek your kind arrangements on earliest settlement." + vbNewLine + vbNewLine + "Thanks and regards," + vbNewLine + "Detention Department" + vbNewLine + "Iran land and sea company."
                    SmtpServer.Send(mail)

                    'Insert Email Log
                    Cmd = New SqlCommand("SP_MailLog_Insert")
                    Cnn = New SqlConnection(My.Settings.DSN)
                    Cnn.Open()
                    Cmd.CommandTimeout = 2000
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@ID", Guid.NewGuid)
                    Cmd.Parameters.AddWithValue("@ActionUser", CurrentUser.UserCode)
                    Cmd.Parameters.AddWithValue("@ActionType", "Send Mail")
                    Cmd.Parameters.AddWithValue("@From_id", System.Configuration.ConfigurationSettings.AppSettings("MailAddress").ToString())
                    Cmd.Parameters.AddWithValue("@To_id", clientmail)
                    Cmd.Parameters.AddWithValue("@Sent_On", Now())
                    Cmd.Parameters.AddWithValue("@Module_Name", "Accounts-Inward Invoice")
                    Cmd.Parameters.AddWithValue("@Action_Status", "Sent")
                    Cmd.Parameters.AddWithValue("@Comments", " ")
                    Cmd.Connection = Cnn
                    Cmd.ExecuteNonQuery()
                    MessageBox.Show("Mail Sent Sucessfully!")
                Else
                    Exit Sub

                End If
            Catch ex As Exception
                Cmd = New SqlCommand("SP_MailLog_Insert")
                Cnn = New SqlConnection(My.Settings.DSN)
                Cnn.Open()
                Cmd.CommandTimeout = 2000
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@ID", Guid.NewGuid)
                Cmd.Parameters.AddWithValue("@ActionUser", CurrentUser.UserCode)
                Cmd.Parameters.AddWithValue("@ActionType", "Send Mail")
                Cmd.Parameters.AddWithValue("@From_id", System.Configuration.ConfigurationSettings.AppSettings("MailAddress").ToString())
                Cmd.Parameters.AddWithValue("@To_id", clientmail)
                Cmd.Parameters.AddWithValue("@Sent_On", Now())
                Cmd.Parameters.AddWithValue("@Module_Name", "Accounts-Inward Invoice")
                Cmd.Parameters.AddWithValue("@Action_Status", "Failure")
                Cmd.Parameters.AddWithValue("@Comments", ex.Message.ToString())
                Cmd.Connection = Cnn
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Mail Sent Failure! " + ex.Message.ToString())
            End Try

        End If



    End Sub
    Private Sub InvoiceFax()
        Dim Sum As CLInwardBlsSummary
        Dim Dtn As New CLDetention
        Dim BLID As Guid
        Dim ds As New DataSet
        Dim Report As RptInwardDetention
        Dim Frm As New FrmGeneralReportShow
        Dim PH As New CLPrintHdr
        Dim Dscnt As TB_InwardDiscount
        Dim sDscnt As String = ""
        Dim Col As DataColumn
        Dim Clnt As TB_Clients
        Dim Status As TB_InwardStatus
        Dim Inv As TB_Invoice
        Dim InvD As TB_InvoiceDetails
        Dim lResult As Boolean
        Dim TB As New DataTable
        Dim sSql As String


        Dim TbSum As New DataTable


        isArrival = False

        ds = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, Me.TextBlNo.TextValue)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No valid B/L No ?", "Data Requird")
            Exit Sub
        End If
        Sum = New CLInwardBlsSummary(ds.Tables(0).Rows(0).Item("Id"))

        BLID = ds.Tables(0).Rows(0).Item("ID")
        '     Dtn.GenerateImportDetention(BLID)
        'ds = Dtn.CalDetention(Me.TextBlNo.TextValue, BLID, , Me.ExtraDays.Value)
        'Above code commented and below code added for demurrage invoices changes (removal of last label - Company Account Details) REMOVING ONE SENTENCE FROM DEMURRAGE INVOICES
        ds = Dtn.CalDetentionInwardInvoice(Me.TextBlNo.TextValue, BLID, False, Me.ExtraDays.Value)


        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLID, MatchType.Exact)
        Dscnt = Dm.GetTB_InwardDiscount()
        If Not Dscnt Is Nothing Then
            If Dscnt.dFreeDays > 0 And Dscnt.IsFDaysAsDiscount = True Then
                sDscnt = "Free Days is " & Dscnt.dFreeDays.ToString
            End If
            If Dscnt.dAmount > 0 Then
                sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Amount is " & Format(Double.Parse(Dscnt.dAmount), "#,###")
            End If
            If Dscnt.dPercent > 0 Then
                sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Persent is " & Dscnt.dPercent.ToString
            End If
            sDscnt = IIf(sDscnt <> "", "DISCOUNT DETAILS :", "") & sDscnt
        End If
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bl.ClientID, MatchType.Exact)
        Clnt = Dm.GetTB_Clients


        Col = New DataColumn("TEL", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("FAX", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("EMAIL", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("Reference", System.Type.GetType("System.Int64"))
        Col.DefaultValue = 0
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("DoDate", System.Type.GetType("System.DateTime"))
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("IssueDate", System.Type.GetType("System.DateTime"))
        ds.Tables(0).Columns.Add(Col)

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, BLID, MatchType.Exact)
        Status = Dm.GetTB_InwardStatus


        sSql = "Select Top 1 I.IssueTime  From TB_Invoice I, TB_InvoiceDetails D Where I.ID =D.InvoiceID and D.ChargesCode ='DETN' and I.Status < 4  and I.BLID = '" & BLID.ToString & "' Order by I.Status"
        TableBySql(sSql, TB, lResult)

        Dim sSqlRemarks As String
        For Each dr As DataRow In ds.Tables(0).Rows

            ' Significant Remark Required For B/Ls with Discount
            Dim TB1 As New System.Data.DataTable
            Dim lResults As Boolean
            Dim labelBl = Me.ToolbarsManager.Tools.Item(5)
            sSqlRemarks = "SELECT dPercent,dAmount FROM TB_InwardDiscount WHERE BLID='" & Bl.ID.ToString + "'"
            TableBySql(sSqlRemarks, TB1, lResults)
            If (TB1.Rows.Count > 0) Then
                For Each drBldiscount As DataRow In TB1.Rows
                    If (drBldiscount("dPercent") = 0 And drBldiscount("dAmount") = 0) Then
                        dr(2) = dr(2)
                    ElseIf (drBldiscount("dPercent") > 0 Or drBldiscount("dAmount") > 0) Then
                        dr(2) = "** " & dr(2) & " **"
                    End If
                Next
            End If
            'End Significant Remark Required For B/Ls with Discount

            Try
                dr("Reference") = Int64.Parse(Bl.Reference)
            Catch ex As Exception
                dr("Reference") = 0
            End Try
            If Not Clnt Is Nothing Then
                dr("TEL") = Clnt.TEL
                dr("Fax") = Clnt.Fax
                dr("EMAIL") = Clnt.Email
            End If

            If Not Status Is Nothing Then
                Try
                    dr("DoDate") = CDate(Status.DoDate)
                Catch ex As Exception

                End Try

            End If

            If TB.Rows.Count > 0 Then
                dr("IssueDate") = TB.Rows(0).Item(0)
            Else
                dr("IssueDate") = Today
            End If


        Next

        TbSum = GenSummaryDetention(Dtn, ds)

        With ds.Tables(1)
            .Columns.Add(New DataColumn("DetentionVat", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DamageVat", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Totalpaid", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DetentionBalance", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DamagePaid", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DamageBlanace", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Deposit", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Balance", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("TotalDamageCost", System.Type.GetType("System.Double")))
        End With


        Report = New RptInwardDetention
        Report.SetDataSource(ds.Tables(0))
        Report.Subreports("RptInwardDetentionSub").SetDataSource(ds.Tables(1))
        Report.Subreports("DetentionSub2").SetDataSource(TbSum)
        Frm.ReportViewer.ReportSource = Report
        Dim path As String = Directory.GetParent(Directory.GetCurrentDirectory()).ToString()
        If System.IO.File.Exists(path + "\Invoice.pdf") = True Then
            ' System.IO.File.Delete(MailFile)
        End If

        Report.ExportToDisk(ExportFormatType.PortableDocFormat, path + "\Invoice.pdf")


        'Try
        '    Dim objFaxDocument As New FAXCOMEXLib.FaxDocument
        '    Dim objFaxServer As New FAXCOMEXLib.FaxServer
        '    Dim objSender As FAXCOMEXLib.FaxSender = Nothing
        '    Dim JobID As Object


        '    'Connect to the local fax machine
        '    objFaxServer.Connect("") 'Change to //ComputerName if access a fax sever

        '    'Set high priority for bigger files
        '    objFaxDocument.Priority = FAXCOMEXLib.FAX_PRIORITY_TYPE_ENUM.fptHIGH

        '    'Set the body text of the fax to a file
        '    objFaxDocument.Body = path + "\Invoice.pdf"

        '    'The Faxes document name
        '    objFaxDocument.DocumentName = "ILS-Detention Invoice"

        '    'Set the recipient of the fax
        '    objFaxDocument.Recipients.Add(Clnt.Fax)
        '    objFaxDocument.AttachFaxToReceipt = True

        '    ''Any notes for the fax
        '    'objFaxDocument.Note = "first text fax of the day in vb"

        '    'Fax Subject
        '    objFaxDocument.Subject = "Please receive the Detentio Invoice for BL-" + TextBlNo.TextValue.ToString()

        '    ''Provide the address for the fax receipt 
        '    'objFaxDocument.ReceiptAddress = "*********@yahoo.com"

        '    'Set the receipt type to email 
        '    objFaxDocument.ReceiptType = FAXCOMEXLib.FAX_RECEIPT_TYPE_ENUM.frtMAIL

        '    JobID = objFaxDocument.ConnectedSubmit(objFaxServer)
        '    MsgBox("The Job ID is :" & JobID(0))
        '    MessageBox.Show("Fax Sent Sucessfully!")

        'Catch ex As Exception
        '    MsgBox("Error number: " & Hex(Err.Number) & ", " & Err.Description)
        'End Try

    End Sub
    Private Sub GenerateDetention(ByVal DetnNew As String)

        Dim Sum As CLInwardBlsSummary
        Dim Dtn As New CLDetention
        Dim BLID As Guid
        Dim ds As New DataSet
        Dim Report As RptInwardDetention
        Dim Frm As New FrmGeneralReportShow
        Dim PH As New CLPrintHdr
        Dim Dscnt As TB_InwardDiscount
        Dim sDscnt As String = ""
        Dim Col As DataColumn
        Dim Clnt As TB_Clients
        Dim Status As TB_InwardStatus
        Dim Inv As TB_Invoice
        Dim InvD As TB_InvoiceDetails
        Dim lResult As Boolean
        Dim TB As New DataTable
        Dim sSql As String
        Dim IResult As Boolean

        Dim TbSum As New DataTable


        isArrival = False

        ds = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, Me.TextBlNo.TextValue)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No valid B/L No ?", "Data Requird")
            Exit Sub
        End If
        Sum = New CLInwardBlsSummary(ds.Tables(0).Rows(0).Item("Id"))

        BLID = ds.Tables(0).Rows(0).Item("ID")

        sSql = "select DetnCurrency from TB_InwardBls where ID = '" & BLID.ToString & "'"
        TableBySql(sSql, TB, IResult)

        DetnCurrency = "IRR"
        If Not TB.Rows.Count = 0 And Not TB.Rows(0).Item("DetnCurrency").ToString() = "" Then
            DetnCurrency = NullToValue(TB.Rows(0).Item("DetnCurrency").ToString(), "IRR")
        End If

        'Dtn.GenerateImportDetention(BLID)
        'ds = Dtn.CalDetention(Me.TextBlNo.TextValue, BLID, , Me.ExtraDays.Value)
        'Above code commented and below code added for demurrage invoices changes (removal of last label - Company Account Details) REMOVING ONE SENTENCE FROM DEMURRAGE INVOICES
        ds = Dtn.CalDetentionInwardInvoice(Me.TextBlNo.TextValue, BLID, False, Me.ExtraDays.Value)
        If Dtn.DetnExit = "True" Then
            Exit Sub
        End If
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLID, MatchType.Exact)
        Dscnt = Dm.GetTB_InwardDiscount()
        If Not Dscnt Is Nothing Then
            If Dscnt.dFreeDays > 0 And Dscnt.IsFDaysAsDiscount = True Then
                sDscnt = "Free Days is " & Dscnt.dFreeDays.ToString
            End If
            If Dscnt.dAmount > 0 Then
                sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Amount is " & Format(Double.Parse(Dscnt.dAmount), "#,###")
            End If
            If Dscnt.dPercent > 0 Then
                sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Persent is " & Dscnt.dPercent.ToString
            End If
            sDscnt = IIf(sDscnt <> "", "DISCOUNT DETAILS :", "") & sDscnt
        End If
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bl.ClientID, MatchType.Exact)
        Clnt = Dm.GetTB_Clients


        Col = New DataColumn("TEL", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("FAX", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("EMAIL", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("Reference", System.Type.GetType("System.Int64"))
        Col.DefaultValue = 0
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("DoDate", System.Type.GetType("System.DateTime"))
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("IssueDate", System.Type.GetType("System.DateTime"))
        ds.Tables(0).Columns.Add(Col)

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, BLID, MatchType.Exact)
        Status = Dm.GetTB_InwardStatus


        sSql = "Select Top 1 I.IssueTime  From TB_Invoice I, TB_InvoiceDetails D Where I.ID =D.InvoiceID and D.ChargesCode ='DETN' and I.Status < 4  and I.BLID = '" & BLID.ToString & "' Order by I.Status"
        TableBySql(sSql, TB, lResult)

        Dim sSqlRemarks As String
        For Each dr As DataRow In ds.Tables(0).Rows

            ' Significant Remark Required For B/Ls with Discount
            Dim TB1 As New System.Data.DataTable
            Dim lResults As Boolean
            Dim labelBl = Me.ToolbarsManager.Tools.Item(5)
            sSqlRemarks = "SELECT dPercent,dAmount FROM TB_InwardDiscount WHERE BLID='" & Bl.ID.ToString + "'"
            TableBySql(sSqlRemarks, TB1, lResults)
            If (TB1.Rows.Count > 0) Then
                For Each drBldiscount As DataRow In TB1.Rows
                    If (drBldiscount("dPercent") = 0 And drBldiscount("dAmount") = 0) Then
                        dr(2) = dr(2)
                    ElseIf (drBldiscount("dPercent") > 0 Or drBldiscount("dAmount") > 0) Then
                        dr(2) = "** " & dr(2) & " **"
                    End If
                Next
            End If
            'End Significant Remark Required For B/Ls with Discount

            Try
                dr("Reference") = Int64.Parse(Bl.Reference)
            Catch ex As Exception
                dr("Reference") = 0
            End Try
            If Not Clnt Is Nothing Then
                dr("TEL") = Clnt.TEL
                dr("Fax") = Clnt.Fax
                dr("EMAIL") = Clnt.Email
            End If

            If Not Status Is Nothing Then
                Try
                    dr("DoDate") = CDate(Status.DoDate)
                Catch ex As Exception

                End Try

            End If

            If TB.Rows.Count > 0 Then
                dr("IssueDate") = TB.Rows(0).Item(0)
            Else
                dr("IssueDate") = Today
            End If


        Next
        Isreturn = False
        Isreturn = Dtn.IsCntrsReturnBack
        If DetnNew = "Old" Then
            TbSum = GenSummaryDetention(Dtn, ds)
        Else
            TbSum = GenSummaryDetentionNew(Dtn, ds)
        End If

        With ds.Tables(1)
            .Columns.Add(New DataColumn("DetentionVat", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DamageVat", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Totalpaid", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DetentionBalance", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DamagePaid", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("DamageBlanace", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Deposit", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Balance", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("TotalDamageCost", System.Type.GetType("System.Double")))
        End With



        Report = New RptInwardDetention
        Report.SetDataSource(ds.Tables(0))

        Report.Subreports("RptInwardDetentionSub").SetDataSource(ds.Tables(1))
        Report.Subreports("DetentionSub2").SetDataSource(TbSum)
        Frm.ReportViewer.ReportSource = Report
        Report.SetParameterValue("ShippingLine", CurrentShippingLine)
        Frm.Show()



    End Sub

    Private Sub GenerateDetentionInv()

        Dim Dtn As New CLDetention
        Dim BLID As Guid
        Dim ds As New DataSet
        Dim NewDr As DataRow
        Dim Drs() As DataRow
        Dim nSeq As Byte
        Dim CalBase As New CLCalculationBase
        Dim nTax As Double
        Dim sSql As String
        Dim TB As New System.Data.DataTable


        Dim IResult As Boolean

        CalBase.GetTaxDutyDyDate(Now.Date)


        IsDetention = True

        TotalCostIrr = 0
        TotalCostUsd = 0

        DataSetForm.Tables("TB_Invoice").Clear()
        DataSetForm.Tables("TB_InvoiceDetails").Clear()
        DataSetForm.Tables("TB_Deposits").Clear()
        Me.DataSetForm.AcceptChanges()

        Dm = New DataManager(My.Settings.DSN)

        ds = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, Me.TextBlNo.TextValue)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No valid B/L No ?", "Data Requird")
            Exit Sub
        End If

        BLID = ds.Tables(0).Rows(0).Item("ID")

        sSql = "select DetnCurrency from TB_InwardBls where ID = '" & BLID.ToString & "'"
        TableBySql(sSql, TB, IResult)

        DetnCurrency = "IRR"
        If Not TB.Rows.Count = 0 And Not TB.Rows(0).Item("DetnCurrency").ToString() = "" Then
            DetnCurrency = NullToValue(TB.Rows(0).Item("DetnCurrency").ToString(), "IRR")
        End If

        ds = Dtn.CalDetention(Me.TextBlNo.TextValue, BLID, , Me.ExtraDays.Value)
        If Dtn.DetnExit = "True" Then
            Exit Sub
        End If

        'ds = Dtn.CalDetention(Me.TextBlNo.TextValue, BLID)
        InvID = Guid.NewGuid

        If Dtn.Balance + Dtn.TotalDamageCost + Dtn.TotalDamageCostUsd = 0 Then
            MsgBox("Detention Balance Is Zero")
            Exit Sub
        End If

        nSeq += 1
        NewDr = DataSetForm.Tables("TB_InvoiceDetails").NewRow
        NewDr("ID") = System.Guid.NewGuid
        NewDr("InvoiceID") = InvID
        NewDr("Seq") = nSeq
        NewDr("Amount") = Dtn.Balance
        'If ((CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And (Sof.DschCmpl < Date.ParseExact("06/30/2020", "MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))) Then
        If DetnCurrency = "USD" Then
            If Dtn.IsCntrsReturnBack = True Then
                NewDr("IrrAmount") = Dtn.UsdBalance
                NewDr("Currency") = "USD"
            Else
                ' NewDr("IrrAmount") = Dtn.Balance
                NewDr("IrrAmount") = Dtn.UsdBalance
                NewDr("Currency") = "USD"
            End If
        Else
            NewDr("IrrAmount") = Dtn.Balance
            NewDr("Currency") = "IRR"
        End If

        If Dtn.IsCntrsReturnBack = True Then
            NewDr("Remarks") = "حق توقف"
            NewDr("ChargesCode") = "DETN"
            CalBase.GetTaxDutyDyDate(Now.Date, "DETN")
        Else
            NewDr("Remarks") = "علی الحساب حق توقف"
            NewDr("ChargesCode") = "DETN-A"
            CalBase.GetTaxDutyDyDate(Now.Date, "DETN-A")
        End If
        DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(NewDr)

        If Dtn.TotalDamageCost > 0 Then
            nSeq += 1
            NewDr = DataSetForm.Tables("TB_InvoiceDetails").NewRow
            NewDr("ID") = System.Guid.NewGuid
            NewDr("InvoiceID") = InvID
            NewDr("Seq") = nSeq
            NewDr("Amount") = Dtn.TotalDamageCost
            NewDr("IrrAmount") = Dtn.TotalDamageCost
            NewDr("Currency") = "IRR"
            NewDr("Remarks") = "خسارت کانتینر"
            NewDr("ChargesCode") = "DMCT"
            DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(NewDr)
        End If

        If Dtn.TotalDamageCostUsd > 0 Then
            nSeq += 1
            NewDr = DataSetForm.Tables("TB_InvoiceDetails").NewRow
            NewDr("ID") = System.Guid.NewGuid
            NewDr("InvoiceID") = InvID
            NewDr("Seq") = nSeq
            NewDr("Amount") = Dtn.TotalDamageCostUsd
            NewDr("IrrAmount") = 0
            NewDr("Currency") = "USD"
            NewDr("Remarks") = "خسارت کانتینر"
            NewDr("ChargesCode") = "DMCT"
            DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(NewDr)
        End If


        'If Dtn.IsCntrsReturnBack = True Then
        'If Dtn.TaxAmount > 0 Then
        '    nSeq += 1
        If Not CalBase.Tax = 0 Then
            NewDr = DataSetForm.Tables("TB_InvoiceDetails").NewRow
            NewDr("ID") = System.Guid.NewGuid
            NewDr("InvoiceID") = InvID
            NewDr("Seq") = 98
            'appu for TOP URGENT / WRONG TAX AND TOLL
            ''NewDr("Amount") = ((Dtn.TotalAmount * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
            ''NewDr("IrrAmount") = ((Dtn.TotalAmount * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
            'If ((CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And (Sof.DschCmpl < Date.ParseExact("06/30/2020", "MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))) Then
            If DetnCurrency = "USD" Then
                ' If Dtn.IsCntrsReturnBack = True Then
                NewDr("Amount") = ((Dtn.Balance * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
                NewDr("IrrAmount") = ((Dtn.UsdBalance * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
                NewDr("Currency") = "USD"
                'Else

                '    NewDr("Amount") = ((Dtn.Balance * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
                '    NewDr("IrrAmount") = ((Dtn.Balance * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
                '    NewDr("Currency") = "IRR"
                'End If
            Else
                NewDr("Amount") = ((Dtn.Balance * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
                NewDr("IrrAmount") = ((Dtn.Balance * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
                NewDr("Currency") = "IRR"
            End If
            'NewDr("Amount") = ((Dtn.Balance * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
            'NewDr("IrrAmount") = ((Dtn.Balance * CalBase.Tax) / 100) + ((Dtn.TotalDamageCost * CalBase.Tax) / 100)
            'NewDr("Currency") = "IRR"
            NewDr("Remarks") = (CalBase.Tax).ToString & "%" & "  بابت مالیات و عوارض ارزش افزوده "
            NewDr("ChargesCode") = "TAX"

            DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(NewDr)
            NewDr = DataSetForm.Tables("TB_InvoiceDetails").NewRow
            NewDr("ID") = System.Guid.NewGuid
            NewDr("InvoiceID") = InvID
            NewDr("Seq") = 99
            ''appu
            ''NewDr("Amount") = ((Dtn.TotalAmount * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
            ''NewDr("IrrAmount") = ((Dtn.TotalAmount * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
            'If ((CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And (Sof.DschCmpl < Date.ParseExact("06/30/2020", "MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))) Then
            If DetnCurrency = "USD" Then
                'If Dtn.IsCntrsReturnBack = True Then
                NewDr("Amount") = ((Dtn.Balance * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
                NewDr("IrrAmount") = ((Dtn.UsdBalance * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
                NewDr("Currency") = "USD"
                'Else

                '    NewDr("Amount") = ((Dtn.Balance * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
                '    NewDr("IrrAmount") = ((Dtn.Balance * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
                '    NewDr("Currency") = "IRR"
                'End If
            Else
                NewDr("Amount") = ((Dtn.Balance * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
                NewDr("IrrAmount") = ((Dtn.Balance * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
                NewDr("Currency") = "IRR"
            End If
            'NewDr("Amount") = ((Dtn.Balance * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
            'NewDr("IrrAmount") = ((Dtn.Balance * CalBase.Duty) / 100) + ((Dtn.TotalDamageCost * CalBase.Duty) / 100)
            'NewDr("Currency") = "IRR"
            NewDr("Remarks") = (CalBase.Duty).ToString & "%" & "  بابت مالیات و عوارض ارزش افزوده "
            NewDr("ChargesCode") = "TOLL"
            DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(NewDr)
        End If
        ' End If
        'Else
        '    If Dtn.TotalDamageCost > 0 Then
        '        nSeq += 1
        '        NewDr = DataSetForm.Tables("TB_InvoiceDetails").NewRow
        '        NewDr("ID") = System.Guid.NewGuid
        '        NewDr("InvoiceID") = InvID
        '        NewDr("Seq") = nSeq
        '        NewDr("Amount") = 0
        '        NewDr("IrrAmount") = 0
        '        NewDr("Currency") = "IRR"
        '        NewDr("Remarks") = "مالیات"
        '        NewDr("ChargesCode") = "TAX"
        '        DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(NewDr)
        '    End If
        'End If
        InvStatus = InvoiceStatus.Issue

        'If Mid(Dtn.DamageCurrency, 1, 2) = "US" Then
        'If Dtn.IsCntrsReturnBack = True Then
        '    TotalCostIrr = Dtn.TotalAmount + Dtn.TotalDamageCost
        '    TotalCostUsd = 0
        '    RecalculateTax()
        'End If





    End Sub

    Private Sub Generatedo()

        Dim Ds As New DataSet
        Dim Mem As New CLMemo
        Dim GoodsList As New ArrayList
        Dim CntrsList As New ArrayList
        Dim SealList As ArrayList
        Dim Tb As New DataTable
        Dim Row As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim lAllow As Boolean = False
        Dim Rpt As New RptDO
        Dim Frm As New FrmGeneralReportShow
        Dim Ref As Int64
        Dim aFld() As String = {"Reference"}
        Dim lResult As Boolean
        Dim ST As TB_InwardStatus
        Dim IsReprint As Boolean = False
        Dim TBMaster As New DataTable
        Dim sSql As String
        Dim sSql2 As String
        Dim dtLockDetails As New System.Data.DataTable
        Dim dtInvStatus As New System.Data.DataTable

        Dim IResult As Boolean

        If Me.LabelStatus.Text = "Bad Account" Then
            sSql = "select LockStatus from TB_LockStatus where BLNo = '" & Me.TextBlNo.TextValue & "'"
            TableBySql(sSql, dtLockDetails, IResult)

            If dtLockDetails.Rows.Count = 0 Then
                MessageBox.Show("Client Status - Bad Account. Not allow to DO. Please Contact Administrator!", "Shipping ILS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If dtLockDetails.Rows(0).Item("LockStatus").ToString() = "L" Then
                    MessageBox.Show("Client Status - Bad Account. Not allow to DO. Please Contact Administrator!", "Shipping ILS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        If Me.UltraLabel6.Text = "Bad Account" Then
            sSql = "select LockStatus from TB_LockStatusAgent where BLNo = '" & Me.TextBlNo.TextValue & "'"
            TableBySql(sSql, dtLockDetails, IResult)

            If dtLockDetails.Rows.Count = 0 Then
                MessageBox.Show("Agent Status - Bad Account. Not allow to DO. Please Contact Administrator!", "Shipping ILS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If dtLockDetails.Rows(0).Item("LockStatus").ToString() = "L" Then
                    MessageBox.Show("Agent Status - Bad Account. Not allow to DO. Please Contact Administrator!", "Shipping ILS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

            If Bl.Status = "HD" Then
                MsgBoxGeneral("This BL Is On Hold !")
                If CurrentUser.IsDocAdmin = False Then
                    Exit Sub
                End If
                If MsgBox("You are as administrator can reprint D.O., Do you want to do it ?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
            End If

            If GridList.Rows.Count = 0 Then
                Exit Sub
            End If

        For Each Row In GridList.Rows
            sSql = "select Status from TB_Invoice where ID = '" & Row.Cells("ID").Value.ToString & "'"
            TableBySql(sSql, dtInvStatus, IResult)

            If Not dtInvStatus.Rows.Count = 0 Then
                If dtInvStatus.Rows(0).Item("Status").ToString() = "3" Then
                    lAllow = True
                    Exit For
                End If
            End If

        Next

            sSql = "Select ID , dbo.FC_InwardTotalChargByBIChgCurrency(ID,'DO','IRR') as DO From Tb_InwardBls Where BLNO = '" & Bl.FrtCoverdBlNo & "'"
            TableBySql(sSql, TBMaster, lResult)
            If TBMaster.Rows.Count > 0 Then
                If NullToValue(TBMaster.Rows(0).Item("DO"), 0) > 0 Then
                    lAllow = True
                End If
            End If

            If lAllow = False Then
                MsgBoxGeneral("No any Confirm Invoice !")
                Exit Sub
            End If

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, Bl.ID, MatchType.Exact)
            ST = Dm.GetTB_InwardStatus
            If Not ST Is Nothing Then
                If NullToValue(ST.DoOffice, "") <> "" Then
                    IsReprint = True
                    MsgBoxGeneral("Already D.O. Issued at " & ST.DoDate.ToString & " " & ST.DoOffice)
                    If CurrentUser.IsDocAdmin = False Then
                        Exit Sub
                    End If
                    If MsgBox("You are as administrator can reprint D.O., Do you want to do it ?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            If Bl.Reference.IsNull Then
                Ref = Int64.Parse((FieldsBySql("SP_GetLastInwardReference '" & CurrentShippingLine & "'", aFld, lResult).Item(0).ToString))
                Ref += 1
                Bl.Reference = Ref
                Dm.CommitAll()
            Else
                If Bl.Reference = 0 Then
                    Ref = Int64.Parse((FieldsBySql("SP_GetLastInwardReference '" & CurrentShippingLine & "'", aFld, lResult).Item(0).ToString))
                    Ref += 1
                    Bl.Reference = Ref
                    Dm.CommitAll()
                End If
            End If

            Dim Frm2 As New FrmDOPrint(Bl, IsReprint)
            Frm2.Show()

    End Sub

    Private Sub GenerateDeposit()

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


        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.TextBlNo.TextValue, MatchType.Exact)
        BL = Dm.GetTB_InwardBLS

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, BL.ClientID, MatchType.Exact)
        Clnt = Dm.GetTB_Clients

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

        Ds = New DataSet
        Ds = StoredProcedures.SP_GetTotalInwardCntrsByBLID(BL.ID.ToString)

        dr = Tb.NewRow
        dr("BLNo") = BL.BlNo
        dr("Reference") = BL.Line & "-" & BL.Reference.ToString
        dr("Cntrs") = NullToValue(Ds.Tables(0).Rows(0).Item(0), "")
        dr("fdate") = ToPersianDate(Now.Date)

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

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_ReportCustomFields.Columns.ReportName, "RptDeposit", MatchType.Exact)
        RptItems = Dm.GetTB_ReportCustomFieldsCollection

        For Each RptItem In RptItems
            Rpt.SetParameterValue(RptItem.FieldName, GetImageInStr(RptItem.ID.ToString))
        Next
        Frm.ReportViewer.ReportSource = Rpt
        Frm.Show()
    End Sub

    Private Sub GridDetail_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles GridDetail.AfterCellUpdate, GridSummary.AfterCellUpdate
        Try
            If GridDetail.ActiveCell.Column.Key = "ChargesCode" Then
                Me.GridDetail.ActiveRow.Cells("Remarks").Value = GetMeaningFCode("CG", Me.GridDetail.ActiveRow.Cells("ChargesCode").Value.ToString)
            End If

        Catch ex As Exception
        End Try

        If Not IsBlank Then
            RecalculateTax()
        End If

    End Sub

    Private Sub ButtonPrintInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrintInv.Click

        Dim Frm As New FrmGeneralReportShow
        Dim DS As New DataSet
        Dim Dv As DataView
        Dim nI As Long = 0
        Dim PH As New CLPrintHdr
        Dim Ans As Boolean
        Dim Inv As TB_InvoiceCollection
        Dim InvDT As TB_InvoiceDetailsCollection
        Dim lFound As Boolean
        Dim pValue As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim Account As String = ""

        'Dim Drs As DataRow
        TableBySql("Select AccountA from TB_Clients where ID  = '" & Bl.ClientID.ToString & "'", TB, lResult)

        If lResult = True Then
            If TB.Rows.Count > 0 Then
                Account = TB.Rows(0).Item(0) & ""
            End If
        End If

        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Ans = RetriveObject(CurrentShippingLine & "_Invoice", "C:\INV")
        If Ans = True Then
            Report = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Report.Load("C:\INV")
        Else
            Report = New RptInvoice
        End If

        Try

            DS = StoredProcedures.SP_RptInvoice(InvID.ToString)
            DS.Tables(0).Columns.Add(New DataColumn("CompanyAccount"))
            DS.Tables(0).Columns.Add(New DataColumn("Account"))
            DS.Tables(0).Columns.Add(New DataColumn("InvoiceID"))
            DS.Tables(0).Columns.Add(New DataColumn("ISOCE"))
            Dv = New DataView(DS.Tables(0), "", "Seq", DataViewRowState.CurrentRows)
            If DS.Tables(0).Select("ChargesCode = 'OCE'").Length > 0 Then
                pValue = "Y"
            Else
                pValue = "N"
            End If

            For Each dr As DataRowView In Dv
                nI += 1
                dr("Seq") = nI
                dr("FPrintTime") = ToPersianDate(Now.Date)
                dr("Account") = Account
                If DS.Tables(1).Rows.Count > 0 Then
                    dr("InvoiceID") = DS.Tables(1).Rows(0).Item("InvoiceID")
                End If
                dr("ISOCE") = pValue
                dr("CompanyAccount") = CurrentCompany.CompanyAccount
            Next


            Report.SetDataSource(DS.Tables(0))
            Report.Subreports("RptRecivedItems").SetDataSource(DS.Tables(1))
            'Report.SetParameterValue("ISOCE", pValue)
            Frm.ReportViewer.ReportSource = Report
            Frm.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub MakeTempTable()

        Dim TB As DataTable

        Do While DataSetForm.Tables.Count > 0
            DataSetForm.Tables.Remove(DataSetForm.Tables(0).TableName)
        Loop

        TB = New DataTable("TB_Invoice")
        TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("BLID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("InvoiceNo", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Issuetime", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("IssueBy", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("ConfirmTime", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("ConfirmBy", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("IssueOffice", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("ConfirmOffice", System.Type.GetType("System.String")))
        DataSetForm.Tables.Add(TB)

        TB = New DataTable("TB_InvoiceDetails")
        TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("InvoiceID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
        TB.Columns.Add(New DataColumn("ChargesCode", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Remarks", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Currency", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Amount", System.Type.GetType("System.Double")))
        TB.Columns.Add(New DataColumn("IRRAmount", System.Type.GetType("System.Double")))
        DataSetForm.Tables.Add(TB)

        TB = New DataTable("TB_Deposits")
        TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("BLID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("ChargesCodes", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Remarks", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Amount", System.Type.GetType("System.Double")))
        DataSetForm.Tables.Add(TB)

        TB = New DataTable("TB_Summary")
        TB.Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Value", System.Type.GetType("System.String")))
        DataSetForm.Tables.Add(TB)

        TB = New DataTable("TB_ReceivedItems")
        
        TB.Columns.Add(New DataColumn("ChargesCodes", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("IrrAmount", System.Type.GetType("System.Double")))
        TB.Columns.Add(New DataColumn("Amount", System.Type.GetType("System.Double")))
        TB.Columns.Add(New DataColumn("Remarks", System.Type.GetType("System.String")))
        DataSetForm.Tables.Add(TB)

        With Me.GridDeposits
            .DataSource = Me.DataSetForm
            .DataMember = "TB_Deposits"
            .DisplayLayout.Bands(0).Columns("Amount").Format = "#,###"
            .DisplayLayout.Bands(0).Columns("Remarks").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With

        With Me.GridDetnAdvance
            .DataSource = Me.DataSetForm
            .DataMember = "tb_receiveditems"
            .DisplayLayout.Bands(0).Columns("amount").Format = "#,###"
            .DisplayLayout.Bands(0).Columns("remarks").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With
        With Me.GridList
            .DataSource = Me.DataSetForm
            .DataMember = "TB_Invoice"
        End With


        With Me.GridDetail
            .DataSource = Me.DataSetForm
            .DataMember = "TB_InvoiceDetails"
            .DisplayLayout.Bands(0).Columns("Amount").Format = "#,###.##"
            .DisplayLayout.Bands(0).Columns("IrrAmount").Format = "#,###"
            .DisplayLayout.Bands(0).Columns("Seq").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .DisplayLayout.Bands(0).Columns("Remarks").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With

        With Me.GridSummary
            .DataSource = Me.DataSetForm
            .DataMember = "TB_Summary"
            .DisplayLayout.Bands(0).Columns.Item("Description").Header.VisiblePosition = 0

        End With

    End Sub

    Private Sub DetentionByDay_CustomClick()
        GenerateDetention("Old")
    End Sub

    Private Sub RecalculateTax()

        Dim TTLTaxUsd As Double
        Dim TTLTollUsd As Double

        Dim TTLTaxIrr As Double
        Dim TTLTollIrr As Double



        Dim Drs() As DataRow
        Dim CalBase As New CLCalculationBase
        Dim nDR As DataRow
        Dim nI As Byte
        Dim nTax As Double
        Dim nToll As Double


        If InvStatus = InvoiceStatus.ToAccount Or InvStatus = InvoiceStatus.Issue Or InvStatus = InvoiceStatus.ToClient Then
            For Each dr As DataRow In Me.DataSetForm.Tables("TB_InvoiceDetails").Rows
                If dr.RowState <> DataRowState.Deleted Then
                    If isArrival = True Then
                        CalBase.GetTaxDutyInward(Bl.ID, dr("ChargesCode"))
                    Else
                        CalBase.GetTaxDutyInward(Bl.ID, dr("ChargesCode"), True)
                    End If
                    If CalBase.Tax + CalBase.Duty > 0 Then
                        If dr("IrrAmount") > 0 Then
                            If calculationBase.IsTaxDutyJoin = True Then
                                TTLTaxIrr += (dr("IrrAmount") * (CalBase.Tax + CalBase.Duty) / 100)
                            Else
                                TTLTaxIrr += (dr("IrrAmount") * (CalBase.Tax) / 100)
                                TTLTollIrr += (dr("IrrAmount") * (CalBase.Duty) / 100)
                            End If
                        Else
                            If calculationBase.IsTaxDutyJoin = True Then
                                TTLTaxUsd += (dr("Amount") * (CalBase.Tax + CalBase.Duty) / 100)
                            Else
                                TTLTaxUsd += (dr("Amount") * (CalBase.Tax) / 100)
                                TTLTollUsd += (dr("Amount") * (CalBase.Duty) / 100)
                            End If
                        End If
                    End If

                End If
            Next

        End If

        Drs = Me.DataSetForm.Tables("TB_InvoiceDetails").Select("ChargesCode = 'TAX' or ChargesCode = 'TOLL'")

        For Each dr As DataRow In Drs
            If dr.RowState <> DataRowState.Deleted Then
                dr.Delete()
            End If
        Next

        If CalBase.Tax + CalBase.Duty = 0 Then
            CalBase.GetTaxDutyInward(Bl.ID, "DO")
        End If

        If Me.DataSetForm.Tables("TB_InvoiceDetails").Rows.Count > 0 Then
            If calculationBase.IsTaxDutyJoin = True Then
                nDR = Me.DataSetForm.Tables("TB_InvoiceDetails").NewRow
                nDR("Seq") = 98
                nDR("ID") = Guid.NewGuid
                nDR("InvoiceID") = Me.DataSetForm.Tables("TB_InvoiceDetails").Rows(0).Item("InvoiceID")
                nDR("ChargesCode") = "TAX"
                nDR("IRRAmount") = TTLTaxIrr
                nDR("Amount") = TTLTaxIrr
                nDR("Remarks") = (CalBase.Tax + CalBase.Duty).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                nDR("Currency") = "IRR"
                Me.DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(nDR)

                If TTLTaxUsd > 0 Then
                    nDR = Me.DataSetForm.Tables("TB_InvoiceDetails").NewRow
                    nDR("Seq") = 98
                    nDR("ID") = Guid.NewGuid
                    nDR("InvoiceID") = Me.DataSetForm.Tables("TB_InvoiceDetails").Rows(0).Item("InvoiceID")
                    nDR("ChargesCode") = "TAX"
                    nDR("IRRAmount") = 0
                    nDR("Amount") = TTLTaxUsd
                    nDR("Remarks") = (CalBase.Tax + CalBase.Duty).ToString & "%" & "  بابت مالیات و عوارض ارزش افزوده ارزی"
                    nDR("Currency") = "USD"
                    Me.DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(nDR)
                End If

            Else
                nDR = Me.DataSetForm.Tables("TB_InvoiceDetails").NewRow
                nDR("Seq") = 98
                nDR("ID") = Guid.NewGuid
                nDR("InvoiceID") = Me.DataSetForm.Tables("TB_InvoiceDetails").Rows(0).Item("InvoiceID")
                nDR("IRRAmount") = TTLTaxIrr
                nDR("Amount") = TTLTaxIrr
                nDR("ChargesCode") = "TAX"
                nDR("Remarks") = (CalBase.Tax).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                nDR("Currency") = "IRR"
                Me.DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(nDR)
                nDR = Me.DataSetForm.Tables("TB_InvoiceDetails").NewRow
                nDR("Seq") = 99
                nDR("ID") = Guid.NewGuid
                nDR("InvoiceID") = Me.DataSetForm.Tables("TB_InvoiceDetails").Rows(0).Item("InvoiceID")
                nDR("ChargesCode") = "TOLL"
                nDR("IRRAmount") = TTLTollIrr
                nDR("Amount") = TTLTollIrr
                nDR("Remarks") = (CalBase.Duty).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                nDR("Currency") = "IRR"
                Me.DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(nDR)

                If TTLTaxUsd > 0 Then

                    nDR = Me.DataSetForm.Tables("TB_InvoiceDetails").NewRow
                    nDR("Seq") = 100
                    nDR("ID") = Guid.NewGuid
                    nDR("InvoiceID") = Me.DataSetForm.Tables("TB_InvoiceDetails").Rows(0).Item("InvoiceID")
                    nDR("IRRAmount") = 0
                    nDR("Amount") = TTLTaxUsd
                    nDR("ChargesCode") = "TAX"
                    nDR("Remarks") = (CalBase.Tax).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                    nDR("Currency") = "USD"
                    Me.DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(nDR)
                    nDR = Me.DataSetForm.Tables("TB_InvoiceDetails").NewRow
                    nDR("Seq") = 101
                    nDR("ID") = Guid.NewGuid
                    nDR("InvoiceID") = Me.DataSetForm.Tables("TB_InvoiceDetails").Rows(0).Item("InvoiceID")
                    nDR("ChargesCode") = "TOLL"
                    nDR("IRRAmount") = 0
                    nDR("Amount") = TTLTollUsd
                    nDR("Remarks") = (CalBase.Duty).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                    nDR("Currency") = "USD"
                    Me.DataSetForm.Tables("TB_InvoiceDetails").Rows.Add(nDR)

                End If


            End If
        End If

        Drs = Me.DataSetForm.Tables("TB_InvoiceDetails").Select("", "Seq")

        For Each dr As DataRow In Drs
            If dr.RowState <> DataRowState.Deleted Then
                If dr("IRRAmount") + dr("Amount") = 0 Then
                    dr.Delete()
                Else
                    nI += 1
                    dr("Seq") = nI
                End If
            End If
        Next



    End Sub

    Private Function GenSummaryDetention(ByVal DET As CLDetention, ByVal Ds As DataSet) As DataTable

        Dim TB As New DataTable
        Dim Dr As DataRow

        Dim PaidDMUsd As Double
        Dim PaidDM As Double

        Dim PaidDet As Double
        Dim PaidDetUsd As Double

        Dim Seq As Integer
        Dim Deposit As Double

        Dim PaifFromDeposit As Double
        Dim PaifFromDepositUsd As Double

        Dim sSql2 As String
        Dim IResult As Boolean
        Dim lResult As Boolean
        Dim dtLockDetails As New System.Data.DataTable
        Dim dtLockDetailsBL As New System.Data.DataTable

        With TB
            .Columns.Add(New DataColumn("ChargeCode", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
            .Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("ToPaidIrr", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ToBePaidIrrTax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ToPaidUsd", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ToBePaidUsdTax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidIrr", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidIrrTax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidUsd", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidUsdTax", System.Type.GetType("System.Double")))
        End With

        sSql2 = "select Id, Remarks, CreatedDate, ModifiedDate from TB_TAPDetention where BLNo = '" & Bl.BlNo.ToString() & "'"
        TableBySql(sSql2, dtLockDetailsBL, IResult)
        If dtLockDetailsBL.Rows.Count = 0 Then
            If DET.TotalAmount > 0 Then
                Seq += 1
                Dr = TB.NewRow
                Dr("ChargeCode") = "DETN"
                Dr = TB.NewRow
                Dr("Seq") = Seq
                Dr("Description") = "Detention"
                Dr("ToPaidIrr") = DET.TotalAmount - DET.TotalDiscount
                Dr("ToBePaidIrrTax") = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                Dr("ToPaidUsd") = 0
                Dr("ToBePaidUsdTax") = 0
                Dr("PaidIrr") = 0
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = 0
                Dr("PaidUsdTax") = 0
                TB.Rows.Add(Dr)
            End If
        Else
            MsgBox("TAP Entry Available!" & vbCrLf & "Remarks: " + dtLockDetailsBL.Rows(0).Item("Remarks").ToString(), MsgBoxStyle.Information)
        End If

        If DET.TotalDamageCost + DET.TotalDamageCostUsd > 0 Then

            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Damage Cost"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("Description") = "Damage Cost"

            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0

            If DET.TotalDamageCost > 0 Then
                Dr("ToPaidIrr") = DET.TotalDamageCost
                Dr("ToBePaidIrrTax") = DET.TotalDamageCost * DET.TaxPercent / 100
            End If

            If DET.TotalDamageCostUsd > 0 Then
                Dr("ToPaidUsd") = DET.TotalDamageCostUsd
                Dr("ToBePaidUsdTax") = DET.TotalDamageCostUsd * DET.TaxPercent / 100

            End If
            TB.Rows.Add(Dr)
        End If


        For Each Dr In Ds.Tables(3).Select("ChargesCodes = 'DD'")
            If NullToValue(Dr("PaidRef"), "") <> "" Then
                ' Deposit += (NullToValue(Dr("Amount"), 0) - NullToValue(Dr("ReturnBackAmount"), 0))
                Deposit += (NullToValue(Dr("Amount"), 0))
            End If
        Next

        If Deposit > 0 Then

            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Deposit"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Deposit"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("PaidIrr") = Deposit
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            TB.Rows.Add(Dr)
        End If

        If DET.FirstPaid + DET.FirstPaidUsd > 0 Then
            Dim FPinvdate As String
            Dim TB1 As New DataTable
            Dim TB3 As New DataTable
           
            Dim FPTAX

            
            If Not Ds.Tables(2).Select("ChargesCode = 'DETN-A'").Count = 0 Then
                For Each Dr2 In Ds.Tables(2).Select("ChargesCode = 'DETN-A'")

                    Dim DA As New SqlDataAdapter
                    Dim Cmd As New SqlCommand
                    Dim Cnn As New SqlConnection(My.Settings.DSN)
                    TableBySql("Select issuetime from TB_Invoice where id = '" & Dr2("InvoiceID").ToString() & "'", TB3, lResult)

                    If lResult = True Then
                        If TB3.Rows.Count > 0 Then
                            FPinvdate = TB3.Rows(0).Item("issuetime").ToString()
                        End If
                    End If
                    With Cmd
                        .CommandText = "SP_GetTaxDutyByChargeCode"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = Cnn
                        .Parameters.AddWithValue("@date", FPinvdate)
                        .Parameters.AddWithValue("@ChargesCode", "DETN-A")
                    End With

                    DA.SelectCommand = Cmd
                    DA.Fill(TB1)
                    If TB1.Rows.Count > 0 Then
                        lResult = True
                    Else
                        lResult = False
                    End If


                    If lResult = False Then
                        FPTAX = 0
                    Else
                        FPTAX = TB1.Rows(0).Item("Tax") + TB1.Rows(0).Item("Toll")
                    End If
                Next
            End If

            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "First Paid"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "First Paid"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If DET.FirstPaidUsd > 0 Then
                Dr("PaidIrr") = 0
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = DET.FirstPaidUsd
                Dr("PaidUsdTax") = DET.FirstPaidUsd * FPTAX / 100
                'Dr("PaidUsdTax") = DET.FirstPaidUsd * DET.TaxPercent / 100
            Else
                Dr("PaidIrr") = DET.FirstPaid
                Dr("PaidIrrTax") = DET.FirstPaid * FPTAX / 100
                Dr("PaidUsd") = 0
                Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        For Each Dr In Ds.Tables(2).Rows
            If Dr("Currency") = "IRR" Or Dr("IrrAmount") > 0 Then
                Select Case Dr("ChargesCode")
                    Case "DMCT"
                        PaidDM += Dr("IrrAmount")
                    Case "DETN"
                        PaidDet += Dr("IrrAmount")
                End Select
            Else
                Select Case Dr("ChargesCode")
                    Case "DMCT"
                        PaidDMUsd += Dr("Amount")
                    Case "DETN"
                        PaidDetUsd += Dr("Amount")
                End Select
            End If
        Next


        If PaidDM + PaidDMUsd > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Paid Damage"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Paid (Damage)"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("PaidIrr") = 0
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            If PaidDMUsd > 0 Then
                'Dr("PaidIrr") = 0
                'Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = PaidDMUsd
                Dr("PaidUsdTax") = PaidDMUsd * DET.TaxPercent / 100
            End If
            If PaidDM > 0 Then
                Dr("PaidIrr") = PaidDM
                Dr("PaidIrrTax") = PaidDM * DET.TaxPercent / 100
                'Dr("PaidUsd") = 0
                'Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        If PaidDet + PaidDetUsd > 0 Then
            Dim DA As New SqlDataAdapter
            Dim Cmd As New SqlCommand
            Dim Cnn As New SqlConnection(My.Settings.DSN)
            Dim tbtax As DataTable
            Dim invdetntax As Double
            invdetntax = 0
            TableBySql("select [dbo].[FC_DetnTax]('" & Bl.ID.ToString() & "') as taxamount", tbtax, lResult)

            If lResult = True Then
                If tbtax.Rows.Count > 0 And Not tbtax.Rows(0).Item("taxamount").ToString() = "" Then
                    invdetntax = tbtax.Rows(0).Item("taxamount")
                End If
            End If
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Invoice"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Invoice"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If PaidDetUsd > 0 Then
                'Dr("PaidIrr") = 0
                'Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = PaidDet
                Dr("PaidUsdTax") = (PaidDetUsd + DET.FirstPaidUsd) * DET.TaxPercent / 100
            Else
                Dr("PaidIrr") = PaidDet
                'Dr("PaidIrrTax") = ((DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent) / 100
                Dr("PaidIrrTax") = invdetntax
                '((PaidDet - DET.TotalDiscount) * DET.TaxPercent) / 100
                'Dr("PaidUsd") = 0
                'Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        For Each Dr In Ds.Tables(4).Rows
            If Dr("Currency") = "IRR" Then
                PaifFromDeposit += Dr("Amount")
            Else
                PaifFromDepositUsd += Dr("Amount")
            End If
        Next

        If PaifFromDeposit + PaifFromDepositUsd > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Paid From Deposit"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Paid From Deposit"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If PaifFromDepositUsd > 0 Then
                ' Dr("PaidIrr") = 0
                'Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = PaifFromDepositUsd * -1
                Dr("PaidUsdTax") = 0
            Else
                Dr("PaidIrr") = PaifFromDeposit * -1
                Dr("PaidIrrTax") = 0
                'Dr("PaidUsd") = 0
                'Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        Deposit = 0
        For Each Dr In Ds.Tables(3).Select("ChargesCodes = 'DD'")
            If NullToValue(Dr("PaidRef"), "") <> "" Then
                Deposit += NullToValue(Dr("ReturnBackAmount"), 0)
            End If
        Next

        If Deposit > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Settlement"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Settlement"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("PaidIrr") = Deposit * -1
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            TB.Rows.Add(Dr)
        End If

        For Each Dr In TB.Rows
            If IsDBNull(Dr("ToPaidIrr")) Then
                Dr("ToPaidIrr") = 0
            End If
            If IsDBNull(Dr("ToBePaidIrrTax")) Then
                Dr("ToBePaidIrrTax") = 0
            End If
            If IsDBNull(Dr("ToPaidUsd")) Then
                Dr("ToPaToPaidUsdidIrr") = 0
            End If
            If IsDBNull(Dr("ToBePaidUsdTax")) Then
                Dr("ToBePaidUsdTax") = 0
            End If
            If IsDBNull(Dr("PaidIrr")) Then
                Dr("PaidIrr") = 0
            End If
            If IsDBNull(Dr("PaidIrrTax")) Then
                Dr("PaidIrrTax") = 0
            End If
            If IsDBNull(Dr("PaidUsd")) Then
                Dr("PaidUsd") = 0
            End If
            If IsDBNull(Dr("PaidUsdTax")) Then
                Dr("PaidUsdTax") = 0
            End If
        Next

        Return TB

    End Function
    Private Function GenSummaryDetentionNew(ByVal DET As CLDetention, ByVal Ds As DataSet) As DataTable

        Dim TB As New DataTable
        Dim Dr As DataRow

        Dim PaidDMUsd As Double
        Dim PaidDM As Double

        Dim PaidDet As Double
        Dim PaidDetUsd As Double

        Dim Seq As Integer
        Dim Deposit As Double
        Dim DepositReal As Double

        Dim PaifFromDeposit As Double
        Dim PaifFromDepositUsd As Double

        Dim Detn As Double
        Dim DetnTax As Double
        Dim TotDetn As Double
        Detn = DetnTax = TotDetn = 0
        Dim ReveivedPay As Double
        ReveivedPay = 0
        Dim TotDM As Double
        TotDM = 0
        Dim FirstPaidPay As Double
        FirstPaidPay = 0

        Dim sSql2 As String
        Dim IResult As Boolean
        Dim dtLockDetails As New System.Data.DataTable
        Dim dtLockDetailsBL As New System.Data.DataTable

        Dim CalBase As New CLCalculationBase

        With TB
            .Columns.Add(New DataColumn("ChargeCode", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
            .Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("ToPaidIrr", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ToBePaidIrrTax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ToPaidUsd", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ToBePaidUsdTax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidIrr", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidIrrTax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidUsd", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidUsdTax", System.Type.GetType("System.Double")))
        End With

        
        sSql2 = "select Id, Remarks, CreatedDate, ModifiedDate from TB_TAPDetention where BLNo = '" & Bl.BlNo.ToString() & "'"
        TableBySql(sSql2, dtLockDetailsBL, IResult)
        If dtLockDetailsBL.Rows.Count = 0 Then
            If DET.TotalAmount > 0 Then
                Seq += 1
                Dr = TB.NewRow
                Dr("ChargeCode") = "DETN"
                Dr = TB.NewRow
                Dr("Seq") = Seq
                Dr("Description") = "Detention"
                Dr("ToPaidUsd") = 0
                Dr("ToBePaidUsdTax") = 0
                'If (Sof.DschCmpl < Date.ParseExact("06/30/2020", "MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)) Then
                '    Dim Drs() As DataRow
                '    Drs = Ds.Tables("Table2").Select("ChargesCode = 'DETN'")
                '    If (CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And Isreturn = True And Drs.Length > 0 Then
                '        Dr("ToPaidIrr") = DET.UsdBalance
                '        Dr("ToBePaidIrrTax") = DET.UsdBalance * DET.TaxPercent / 100
                '        Detn = DET.UsdBalance
                '        DetnTax = DET.UsdBalance * DET.TaxPercent / 100
                '        TotDetn = Detn + DetnTax
                '    ElseIf (CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And Isreturn = True And Drs.Length = 0 Then
                '        Dr("ToPaidUsd") = DET.TotalAmount - DET.TotalDiscount
                '        Dr("ToBePaidUsdTax") = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                '        Detn = DET.TotalAmount - DET.TotalDiscount
                '        DetnTax = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                '        TotDetn = Detn + DetnTax
                '    ElseIf (CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And Isreturn = False Then
                '        Dr("ToPaidUsd") = DET.TotalAmount - DET.TotalDiscount
                '        Dr("ToBePaidUsdTax") = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                '        Detn = DET.TotalAmount - DET.TotalDiscount
                '        DetnTax = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                '        TotDetn = Detn + DetnTax
                '    Else
                '        Dr("ToPaidIrr") = DET.TotalAmount - DET.TotalDiscount
                '        Dr("ToBePaidIrrTax") = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                '        Detn = DET.TotalAmount - DET.TotalDiscount
                '        DetnTax = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                '        TotDetn = Detn + DetnTax
                '    End If
                'Else
                '    Dr("ToPaidIrr") = DET.TotalAmount - DET.TotalDiscount
                '    Dr("ToBePaidIrrTax") = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                '    Detn = DET.TotalAmount - DET.TotalDiscount
                '    DetnTax = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                '    TotDetn = Detn + DetnTax
                'End If

                If DetnCurrency = "USD" Then
                  
                    Dr("ToPaidIrr") = DET.UsdBalance
                    Dr("ToBePaidIrrTax") = DET.UsdBalance * DET.TaxPercent / 100
                    Detn = DET.UsdBalance
                    DetnTax = DET.UsdBalance * DET.TaxPercent / 100
                    TotDetn = Detn + DetnTax
                Else
                    Dr("ToPaidIrr") = DET.TotalAmount - DET.TotalDiscount
                    Dr("ToBePaidIrrTax") = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                    Detn = DET.TotalAmount - DET.TotalDiscount
                    DetnTax = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                    TotDetn = Detn + DetnTax
                End If

                Dr("PaidIrr") = 0
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = 0
                Dr("PaidUsdTax") = 0
                TB.Rows.Add(Dr)
            End If
            Else
                MsgBox("TAP Entry Available!" & vbCrLf & "Remarks: " + dtLockDetailsBL.Rows(0).Item("Remarks").ToString(), MsgBoxStyle.Information)

                'Else
                '    If DET.TotalAmount > 0 Then
                '        Seq += 1
                '        Dr = TB.NewRow
                '        Dr("ChargeCode") = "DETN"
                '        Dr = TB.NewRow
                '        Dr("Seq") = Seq
                '        Dr("Description") = "Detention"
                '        Dr("ToPaidIrr") = 0
                '        Dr("ToBePaidIrrTax") = 0
                '        Detn = 0
                '        DetnTax = 0
                '        TotDetn = 0
                '        Dr("ToPaidUsd") = 0
                '        Dr("ToBePaidUsdTax") = 0
                '        Dr("PaidIrr") = 0
                '        Dr("PaidIrrTax") = 0
                '        Dr("PaidUsd") = 0
                '        Dr("PaidUsdTax") = 0
                '        TB.Rows.Add(Dr)
                '    End If
            End If
        If DET.TotalDamageCost + DET.TotalDamageCostUsd > 0 Then

            CalBase.GetTaxDutyInward(Bl.ID, "DMCT")

            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Damage Cost"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("Description") = "Damage Cost"

            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0

            If DET.TotalDamageCost > 0 Then
                Dr("ToPaidIrr") = DET.TotalDamageCost
                ' Dr("ToBePaidIrrTax") = DET.TotalDamageCost * DET.TaxPercent / 100
                Dr("ToBePaidIrrTax") = DET.TotalDamageCost * (CalBase.Tax + CalBase.Duty) / 100

                TotDM = Dr("ToPaidIrr") + Dr("ToBePaidIrrTax")
            End If

            If DET.TotalDamageCostUsd > 0 Then
                Dr("ToPaidUsd") = DET.TotalDamageCostUsd
                Dr("ToBePaidUsdTax") = DET.TotalDamageCostUsd * (CalBase.Tax + CalBase.Duty) / 100

            End If
            TB.Rows.Add(Dr)
        End If


        For Each Dr In Ds.Tables(3).Select("ChargesCodes = 'DD'")
            If NullToValue(Dr("PaidRef"), "") <> "" Then
                'Deposit += (NullToValue(Dr("Amount"), 0) - NullToValue(Dr("ReturnBackAmount"), 0))
                Deposit += (NullToValue(Dr("Amount"), 0))
                DepositReal += (NullToValue(Dr("Amount"), 0))
            End If
        Next

            If Deposit > 0 Then
                Seq += 1
                Dr = TB.NewRow
                Dr("ChargeCode") = "Deposit"
                Dr = TB.NewRow
                Dr("Seq") = Seq
                Dr("ToPaidIrr") = 0
                Dr("ToBePaidIrrTax") = 0
                Dr("Description") = "Deposit"
                Dr("ToPaidUsd") = 0
                Dr("ToBePaidUsdTax") = 0
                Dr("PaidIrr") = Deposit
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = 0
                Dr("PaidUsdTax") = 0
                TB.Rows.Add(Dr)
            End If

        If Not Ds.Tables(2).Select("ChargesCode = 'DETN'").Count = 0 Then
            For Each Dr In Ds.Tables(2).Select("ChargesCode = 'DETN'")

                Dim Tb1 As New DataTable
                Dim lResult As Boolean
                Dim sSql As String
                Dim Drs() As DataRow

                If (TotDetn + TotDM) > (DepositReal + DET.FirstPaid) Then
                    'If (TotDetn + TotDM) > (DepositReal + DET.FirstPaid) Then
                    sSql = "select sum(IrrAmount) as IrrAmount  from TB_RecivedItems where ReceivedType in ('CDS', 'POS', 'ER') and InvoiceID = '" & Dr("InvoiceID").ToString() & "'"
                Else
                    sSql = "select sum(IrrAmount) as IrrAmount from TB_RecivedItems where ReceivedType in ('CDS', 'POS', 'ER') and InvoiceID = '" & Dr("InvoiceID").ToString() & "'"
                End If
                TableBySql(sSql, Tb1, lResult)
                If Tb1.Rows.Count > 0 And Not IsDBNull(Tb1.Rows(0).Item("IrrAmount")) Then
                    ReveivedPay += Convert.ToDouble(Tb1.Rows(0).Item("IrrAmount"))
                End If

            Next
        Else
            For Each Dr In Ds.Tables(2).Select("ChargesCode = 'DMCT'")

                Dim Tb1 As New DataTable
                Dim lResult As Boolean
                Dim sSql As String
                Dim Drs() As DataRow

                If (TotDetn + TotDM) > (DepositReal + DET.FirstPaid) Then
                    'If (TotDetn + TotDM) > (DepositReal + DET.FirstPaid) Then
                    sSql = "select sum(IrrAmount) as IrrAmount  from TB_RecivedItems where ReceivedType in ('CDS', 'POS', 'ER') and InvoiceID = '" & Dr("InvoiceID").ToString() & "'"
                Else
                    sSql = "select sum(IrrAmount) as IrrAmount from TB_RecivedItems where ReceivedType in ('CDS', 'POS', 'ER') and InvoiceID = '" & Dr("InvoiceID").ToString() & "'"
                End If
                TableBySql(sSql, Tb1, lResult)
                If Tb1.Rows.Count > 0 And Not IsDBNull(Tb1.Rows(0).Item("IrrAmount")) Then
                    ReveivedPay += Convert.ToDouble(Tb1.Rows(0).Item("IrrAmount"))
                End If

            Next

        End If

        If Not Ds.Tables(2).Select("ChargesCode = 'DETN-A'").Count = 0 Then
            For Each Dr In Ds.Tables(2).Select("ChargesCode = 'DETN-A'")

                Dim Tb1 As New DataTable
                Dim lResult As Boolean
                Dim sSql As String
                Dim Drs() As DataRow

                sSql = "select sum(IrrAmount) as IrrAmount  from TB_RecivedItems where ReceivedType in ('CDS', 'POS', 'ER') and InvoiceID = '" & Dr("InvoiceID").ToString() & "'"

                TableBySql(sSql, Tb1, lResult)
                If Tb1.Rows.Count > 0 And Not IsDBNull(Tb1.Rows(0).Item("IrrAmount")) Then
                    FirstPaidPay += Convert.ToDouble(Tb1.Rows(0).Item("IrrAmount"))
                End If

            Next
        End If


        If TBDETN.Rows.Count > 0 Then
            FirstPaidPay += Convert.ToDouble(TBDETN.Rows(0).Item("IrrAmount"))
        End If


        If DET.FirstPaid + DET.FirstPaidUsd > 0 Or FirstPaidPay > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "First Paid"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "First Paid"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If DET.FirstPaidUsd > 0 Then
                Dr("PaidIrr") = 0
                Dr("PaidIrrTax") = 0
                'Dr("PaidUsd") = DET.FirstPaidUsd
                'Dr("PaidUsdTax") = DET.FirstPaidUsd * DET.TaxPercent / 100
                Dr("PaidUsd") = FirstPaidPay

            Else
                'Dr("PaidIrr") = DET.FirstPaid
                'Dr("PaidIrrTax") = DET.FirstPaid * DET.TaxPercent / 100
                Dr("PaidIrr") = FirstPaidPay
                Dr("PaidUsd") = 0
                Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        For Each Dr In Ds.Tables(2).Rows
            If Dr("Currency") = "IRR" Or Dr("IrrAmount") > 0 Then
                Select Case Dr("ChargesCode")
                    Case "DMCT"
                        PaidDM += Dr("IrrAmount")
                    Case "DETN"
                        PaidDet += Dr("IrrAmount")
                End Select
            Else
                Select Case Dr("ChargesCode")
                    Case "DMCT"
                        PaidDMUsd += Dr("Amount")
                    Case "DETN"
                        PaidDetUsd += Dr("Amount")
                End Select
            End If
        Next


        'If PaidDM + PaidDMUsd > 0 Then
        '    Seq += 1
        '    Dr = TB.NewRow
        '    Dr("ChargeCode") = "Paid Damage"
        '    Dr = TB.NewRow
        '    Dr("Seq") = Seq
        '    Dr("ToPaidIrr") = 0
        '    Dr("ToBePaidIrrTax") = 0
        '    Dr("Description") = "Paid (Damage)"
        '    Dr("ToPaidUsd") = 0
        '    Dr("ToBePaidUsdTax") = 0
        '    Dr("PaidIrr") = 0
        '    Dr("PaidIrrTax") = 0
        '    Dr("PaidUsd") = 0
        '    Dr("PaidUsdTax") = 0
        '    If PaidDMUsd > 0 Then
        '        'Dr("PaidIrr") = 0
        '        'Dr("PaidIrrTax") = 0
        '        Dr("PaidUsd") = PaidDMUsd
        '        Dr("PaidUsdTax") = PaidDMUsd * DET.TaxPercent / 100
        '    End If
        '    If PaidDM > 0 Then
        '        Dr("PaidIrr") = PaidDM
        '        Dr("PaidIrrTax") = PaidDM * DET.TaxPercent / 100
        '        'Dr("PaidUsd") = 0
        '        'Dr("PaidUsdTax") = 0
        '    End If
        '    TB.Rows.Add(Dr)
        'End If

        'If PaidDet + PaidDetUsd > 0 Then
        '    Seq += 1
        '    Dr = TB.NewRow
        '    Dr("ChargeCode") = "Invoice"
        '    Dr = TB.NewRow
        '    Dr("Seq") = Seq
        '    Dr("ToPaidIrr") = 0
        '    Dr("ToBePaidIrrTax") = 0
        '    Dr("Description") = "Invoice"
        '    Dr("ToPaidUsd") = 0
        '    Dr("ToBePaidUsdTax") = 0
        '    If PaidDetUsd > 0 Then
        '        'Dr("PaidIrr") = 0
        '        'Dr("PaidIrrTax") = 0
        '        Dr("PaidUsd") = PaidDet
        '        Dr("PaidUsdTax") = (PaidDetUsd + DET.FirstPaidUsd) * DET.TaxPercent / 100
        '    Else
        '        Dr("PaidIrr") = PaidDet
        '        Dr("PaidIrrTax") = ((DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent) / 100
        '        'Dr("PaidUsd") = 0
        '        'Dr("PaidUsdTax") = 0
        '    End If
        '    TB.Rows.Add(Dr)
        'End If

        For Each Dr In Ds.Tables(4).Rows
            If Dr("Currency") = "IRR" Then
                PaifFromDeposit += Dr("Amount")
            Else
                PaifFromDepositUsd += Dr("Amount")
            End If
        Next

        'If PaifFromDeposit + PaifFromDepositUsd > 0 Then
        '    Seq += 1
        '    Dr = TB.NewRow
        '    Dr("ChargeCode") = "Paid From Deposit"
        '    Dr = TB.NewRow
        '    Dr("Seq") = Seq
        '    Dr("ToPaidIrr") = 0
        '    Dr("ToBePaidIrrTax") = 0
        '    Dr("Description") = "Paid From Deposit"
        '    Dr("ToPaidUsd") = 0
        '    Dr("ToBePaidUsdTax") = 0
        '    If PaifFromDepositUsd > 0 Then
        '        ' Dr("PaidIrr") = 0
        '        'Dr("PaidIrrTax") = 0
        '        Dr("PaidUsd") = PaifFromDepositUsd * -1
        '        Dr("PaidUsdTax") = 0
        '    Else
        '        Dr("PaidIrr") = PaifFromDeposit * -1
        '        Dr("PaidIrrTax") = 0
        '        'Dr("PaidUsd") = 0
        '        'Dr("PaidUsdTax") = 0
        '    End If
        '    TB.Rows.Add(Dr)
        'End If

        Deposit = 0
        For Each Dr In Ds.Tables(3).Select("chargescodes = 'dd'")
            If NullToValue(Dr("paidref"), "") <> "" Then
                Deposit += NullToValue(Dr("returnbackamount"), 0)
            End If
        Next

        ' based on mehdi req-alone with detn usd case
        'If Not CurrentShippingLine = "AXL" And Not CurrentShippingLine = "LEX" And Not CurrentShippingLine = "OTLO" Then
        If Deposit > 0 Or ReveivedPay > 0 Then 'And ((TotDetn - ((Deposit + DET.FirstPaid + ReveivedPay) - PaidDM)) > 0) - original line
            ''If Deposit > 0 Or ((TotDetn - ((Deposit + DET.FirstPaid + ReveivedPay) - PaidDM)) > 0) Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Settlement"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0

            ' If (TotDetn + TotDM) > (DepositReal + DET.FirstPaid) Then
            Dr("Description") = "Payment"
            'Else
            '    Dr("Description") = "Refund"
            'End If

            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If (TotDetn + TotDM) > (DepositReal + DET.FirstPaid) Then
                'Dr("PaidIrr") = (TotDetn + TotDM) - ((Deposit + DET.FirstPaid + ReveivedPay) - PaidDM)
                'Dr("PaidIrr") = TotDetn - ((Deposit + DET.FirstPaid + ReveivedPay) - TotDM)
                'Dr("PaidIrr") = ReveivedPay - DepositReal
                Dr("PaidIrr") = ReveivedPay
            Else
                'Dr("PaidIrr") = (TotDetn + TotDM) - ((Deposit + DET.FirstPaid + ReveivedPay))
                Dr("PaidIrr") = ReveivedPay
            End If
            'Dr("PaidIrr") = Deposit * -1
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            TB.Rows.Add(Dr)
        End If
        If Deposit > 0 Then 'And ((TotDetn - ((Deposit + DET.FirstPaid + ReveivedPay) - PaidDM)) > 0) - original line
            ''If Deposit > 0 Or ((TotDetn - ((Deposit + DET.FirstPaid + ReveivedPay) - PaidDM)) > 0) Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Refund"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Refund"

            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0

            'Dr("PaidIrr") = (TotDetn + TotDM) - ((Deposit + DET.FirstPaid + ReveivedPay) - PaidDM)
            'Dr("PaidIrr") = TotDetn - ((Deposit + DET.FirstPaid + ReveivedPay) - TotDM)
            Dr("PaidIrr") = Deposit * -1

            'Dr("PaidIrr") = Deposit * -1
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            TB.Rows.Add(Dr)
        End If
        'End If

        For Each Dr In TB.Rows
            If IsDBNull(Dr("ToPaidIrr")) Then
                Dr("ToPaidIrr") = 0
            End If
            If IsDBNull(Dr("ToBePaidIrrTax")) Then
                Dr("ToBePaidIrrTax") = 0
            End If
            If IsDBNull(Dr("ToPaidUsd")) Then
                Dr("ToPaToPaidUsdidIrr") = 0
            End If
            If IsDBNull(Dr("ToBePaidUsdTax")) Then
                Dr("ToBePaidUsdTax") = 0
            End If
            If IsDBNull(Dr("PaidIrr")) Then
                Dr("PaidIrr") = 0
            End If
            If IsDBNull(Dr("PaidIrrTax")) Then
                Dr("PaidIrrTax") = 0
            End If
            If IsDBNull(Dr("PaidUsd")) Then
                Dr("PaidUsd") = 0
            End If
            If IsDBNull(Dr("PaidUsdTax")) Then
                Dr("PaidUsdTax") = 0
            End If
        Next

        Return TB
    End Function
    Private Function GenSummaryDetentionNew_original(ByVal DET As CLDetention, ByVal Ds As DataSet) As DataTable

        Dim TB As New DataTable
        Dim Dr As DataRow

        Dim PaidDMUsd As Double
        Dim PaidDM As Double

        Dim PaidDet As Double
        Dim PaidDetUsd As Double

        Dim Seq As Integer
        Dim Deposit As Double

        Dim PaifFromDeposit As Double
        Dim PaifFromDepositUsd As Double

        Dim Detn As Double
        Dim DetnTax As Double
        Dim TotDetn As Double
        Detn = DetnTax = TotDetn = 0
        Dim ReveivedPay As Double
        ReveivedPay = 0

        Dim sSql2 As String
        Dim IResult As Boolean
        Dim dtLockDetails As New System.Data.DataTable
        Dim dtLockDetailsBL As New System.Data.DataTable

        With TB
            .Columns.Add(New DataColumn("ChargeCode", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
            .Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("ToPaidIrr", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ToBePaidIrrTax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ToPaidUsd", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ToBePaidUsdTax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidIrr", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidIrrTax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidUsd", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("PaidUsdTax", System.Type.GetType("System.Double")))
        End With


        sSql2 = "select Id, Remarks, CreatedDate, ModifiedDate from TB_TAPDetention where BLNo = '" & Bl.BlNo.ToString() & "'"
        TableBySql(sSql2, dtLockDetailsBL, IResult)
        If dtLockDetailsBL.Rows.Count = 0 Then
            If DET.TotalAmount > 0 Then
                Seq += 1
                Dr = TB.NewRow
                Dr("ChargeCode") = "DETN"
                Dr = TB.NewRow
                Dr("Seq") = Seq
                Dr("Description") = "Detention"
                Dr("ToPaidIrr") = DET.TotalAmount - DET.TotalDiscount
                Dr("ToBePaidIrrTax") = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                Detn = DET.TotalAmount - DET.TotalDiscount
                DetnTax = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
                TotDetn = Detn + DetnTax
                Dr("ToPaidUsd") = 0
                Dr("ToBePaidUsdTax") = 0
                Dr("PaidIrr") = 0
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = 0
                Dr("PaidUsdTax") = 0
                TB.Rows.Add(Dr)
            End If
        Else
            MsgBox("TAP Entry Available!" & vbCrLf & "Remarks: " + dtLockDetailsBL.Rows(0).Item("Remarks").ToString(), MsgBoxStyle.Information)

            'Else
            '    If DET.TotalAmount > 0 Then
            '        Seq += 1
            '        Dr = TB.NewRow
            '        Dr("ChargeCode") = "DETN"
            '        Dr = TB.NewRow
            '        Dr("Seq") = Seq
            '        Dr("Description") = "Detention"
            '        Dr("ToPaidIrr") = 0
            '        Dr("ToBePaidIrrTax") = 0
            '        Detn = 0
            '        DetnTax = 0
            '        TotDetn = 0
            '        Dr("ToPaidUsd") = 0
            '        Dr("ToBePaidUsdTax") = 0
            '        Dr("PaidIrr") = 0
            '        Dr("PaidIrrTax") = 0
            '        Dr("PaidUsd") = 0
            '        Dr("PaidUsdTax") = 0
            '        TB.Rows.Add(Dr)
            '    End If
        End If
        If DET.TotalDamageCost + DET.TotalDamageCostUsd > 0 Then

            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Damage Cost"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("Description") = "Damage Cost"

            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0

            If DET.TotalDamageCost > 0 Then
                Dr("ToPaidIrr") = DET.TotalDamageCost
                Dr("ToBePaidIrrTax") = DET.TotalDamageCost * DET.TaxPercent / 100
            End If

            If DET.TotalDamageCostUsd > 0 Then
                Dr("ToPaidUsd") = DET.TotalDamageCostUsd
                Dr("ToBePaidUsdTax") = DET.TotalDamageCostUsd * DET.TaxPercent / 100

            End If
            TB.Rows.Add(Dr)
        End If


        For Each Dr In Ds.Tables(3).Select("ChargesCodes = 'DD'")
            If NullToValue(Dr("PaidRef"), "") <> "" Then
                ' Deposit += (NullToValue(Dr("Amount"), 0) - NullToValue(Dr("ReturnBackAmount"), 0))
                Deposit += (NullToValue(Dr("Amount"), 0))
            End If
        Next

        If Deposit > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Deposit"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Deposit"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("PaidIrr") = Deposit
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            TB.Rows.Add(Dr)
        End If

        For Each Dr In Ds.Tables(2).Select("ChargesCode = 'DETN'")

            Dim Tb1 As New DataTable
            Dim lResult As Boolean
            Dim sSql As String
            Dim Drs() As DataRow
            sSql = "select IrrAmount from TB_RecivedItems where ReceivedType = 'CDS' and InvoiceID = '" & Dr("InvoiceID").ToString() & "'"

            TableBySql(sSql, Tb1, lResult)
            If Tb1.Rows.Count > 0 Then
                ReveivedPay += Convert.ToDouble(Tb1.Rows(0).Item("IrrAmount"))
            End If

        Next

        If DET.FirstPaid + DET.FirstPaidUsd > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "First Paid"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "First Paid"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If DET.FirstPaidUsd > 0 Then
                Dr("PaidIrr") = 0
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = DET.FirstPaidUsd
                Dr("PaidUsdTax") = 0
            Else
                Dr("PaidIrr") = DET.FirstPaid + ReveivedPay
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = 0
                Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        For Each Dr In Ds.Tables(2).Rows
            If Dr("Currency") = "IRR" Or Dr("IrrAmount") > 0 Then
                Select Case Dr("ChargesCode")
                    Case "DMCT"
                        PaidDM += Dr("IrrAmount")
                    Case "DETN"
                        PaidDet += Dr("IrrAmount")
                End Select
            Else
                Select Case Dr("ChargesCode")
                    Case "DMCT"
                        PaidDMUsd += Dr("Amount")
                    Case "DETN"
                        PaidDetUsd += Dr("Amount")
                End Select
            End If
        Next


        'If PaidDM + PaidDMUsd > 0 Then
        '    Seq += 1
        '    Dr = TB.NewRow
        '    Dr("ChargeCode") = "Paid Damage"
        '    Dr = TB.NewRow
        '    Dr("Seq") = Seq
        '    Dr("ToPaidIrr") = 0
        '    Dr("ToBePaidIrrTax") = 0
        '    Dr("Description") = "Paid (Damage)"
        '    Dr("ToPaidUsd") = 0
        '    Dr("ToBePaidUsdTax") = 0
        '    Dr("PaidIrr") = 0
        '    Dr("PaidIrrTax") = 0
        '    Dr("PaidUsd") = 0
        '    Dr("PaidUsdTax") = 0
        '    If PaidDMUsd > 0 Then
        '        'Dr("PaidIrr") = 0
        '        'Dr("PaidIrrTax") = 0
        '        Dr("PaidUsd") = PaidDMUsd
        '        Dr("PaidUsdTax") = PaidDMUsd * DET.TaxPercent / 100
        '    End If
        '    If PaidDM > 0 Then
        '        Dr("PaidIrr") = PaidDM
        '        Dr("PaidIrrTax") = PaidDM * DET.TaxPercent / 100
        '        'Dr("PaidUsd") = 0
        '        'Dr("PaidUsdTax") = 0
        '    End If
        '    TB.Rows.Add(Dr)
        'End If

        'If PaidDet + PaidDetUsd > 0 Then
        '    Seq += 1
        '    Dr = TB.NewRow
        '    Dr("ChargeCode") = "Invoice"
        '    Dr = TB.NewRow
        '    Dr("Seq") = Seq
        '    Dr("ToPaidIrr") = 0
        '    Dr("ToBePaidIrrTax") = 0
        '    Dr("Description") = "Invoice"
        '    Dr("ToPaidUsd") = 0
        '    Dr("ToBePaidUsdTax") = 0
        '    If PaidDetUsd > 0 Then
        '        'Dr("PaidIrr") = 0
        '        'Dr("PaidIrrTax") = 0
        '        Dr("PaidUsd") = PaidDet
        '        Dr("PaidUsdTax") = (PaidDetUsd + DET.FirstPaidUsd) * DET.TaxPercent / 100
        '    Else
        '        Dr("PaidIrr") = PaidDet
        '        Dr("PaidIrrTax") = ((DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent) / 100
        '        'Dr("PaidUsd") = 0
        '        'Dr("PaidUsdTax") = 0
        '    End If
        '    TB.Rows.Add(Dr)
        'End If

        For Each Dr In Ds.Tables(4).Rows
            If Dr("Currency") = "IRR" Then
                PaifFromDeposit += Dr("Amount")
            Else
                PaifFromDepositUsd += Dr("Amount")
            End If
        Next

        'If PaifFromDeposit + PaifFromDepositUsd > 0 Then
        '    Seq += 1
        '    Dr = TB.NewRow
        '    Dr("ChargeCode") = "Paid From Deposit"
        '    Dr = TB.NewRow
        '    Dr("Seq") = Seq
        '    Dr("ToPaidIrr") = 0
        '    Dr("ToBePaidIrrTax") = 0
        '    Dr("Description") = "Paid From Deposit"
        '    Dr("ToPaidUsd") = 0
        '    Dr("ToBePaidUsdTax") = 0
        '    If PaifFromDepositUsd > 0 Then
        '        ' Dr("PaidIrr") = 0
        '        'Dr("PaidIrrTax") = 0
        '        Dr("PaidUsd") = PaifFromDepositUsd * -1
        '        Dr("PaidUsdTax") = 0
        '    Else
        '        Dr("PaidIrr") = PaifFromDeposit * -1
        '        Dr("PaidIrrTax") = 0
        '        'Dr("PaidUsd") = 0
        '        'Dr("PaidUsdTax") = 0
        '    End If
        '    TB.Rows.Add(Dr)
        'End If

        'Deposit = 0
        'For Each Dr In Ds.Tables(3).Select("ChargesCodes = 'DD'")
        '    If NullToValue(Dr("PaidRef"), "") <> "" Then
        '        Deposit += NullToValue(Dr("ReturnBackAmount"), 0)
        '    End If
        'Next

        If Deposit > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Settlement"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Settlement"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("PaidIrr") = TotDetn - ((Deposit + DET.FirstPaid + ReveivedPay) - PaidDM)
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            TB.Rows.Add(Dr)
        End If

        For Each Dr In TB.Rows
            If IsDBNull(Dr("ToPaidIrr")) Then
                Dr("ToPaidIrr") = 0
            End If
            If IsDBNull(Dr("ToBePaidIrrTax")) Then
                Dr("ToBePaidIrrTax") = 0
            End If
            If IsDBNull(Dr("ToPaidUsd")) Then
                Dr("ToPaToPaidUsdidIrr") = 0
            End If
            If IsDBNull(Dr("ToBePaidUsdTax")) Then
                Dr("ToBePaidUsdTax") = 0
            End If
            If IsDBNull(Dr("PaidIrr")) Then
                Dr("PaidIrr") = 0
            End If
            If IsDBNull(Dr("PaidIrrTax")) Then
                Dr("PaidIrrTax") = 0
            End If
            If IsDBNull(Dr("PaidUsd")) Then
                Dr("PaidUsd") = 0
            End If
            If IsDBNull(Dr("PaidUsdTax")) Then
                Dr("PaidUsdTax") = 0
            End If
        Next

        Return TB
    End Function
    Private Sub GridDetail_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GridDetail.AfterRowUpdate
        If Not IsBlank Then
            RecalculateTax()
        End If
    End Sub
End Class