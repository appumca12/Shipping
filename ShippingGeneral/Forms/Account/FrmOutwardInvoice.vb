Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Data.SqlClient
Imports System.Globalization

Public Class FrmOutWardInvoice

    Private InvID As Guid
    Private Bls As TB_OutwardBLSCollection
    Private Bl As TB_OutwardBLS
    Private Clnt As TB_Clients
    Private Voy As TB_Voyage
    Private Vsl As TB_Vessels
    Private Sof As TB_SOF
    Private InvStatus As InvoiceStatus
    Private ItemLevel As String = "303"
    Private lValidBlNno As Boolean
    Private Dm As DataManager
    Private DummyTB As DataTable
    Private InvoiceInIrr As Boolean
    Private IsBlank As Boolean
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
            .Columns("Amount").Format = "###,###.00"
        End With


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

        CreateDummyTB()

    End Sub

    Private Sub ToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarsManager.ToolClick

        Select Case e.Tool.Key
            Case "Find"
                FindInvoices()
            Case "Close"
                Me.Close()
            Case "Blank Invoice"
                IsBlank = True
                GenerateNew(False)
            Case "Edit"
                IsBlank = False
                EditInvoices()
            Case "Generate"
                IsBlank = False
                GenerateNew(True)
            Case "Detention List"
                GenerateDetention()

        End Select

    End Sub

    Private Sub FindInvoices()

        Dim aTables() As String = {"TB_ExpInvoice", "TB_ExpInvoiceDetails", "TB_OutWardCharges"}
        Dim DS As New DataSet
        Dim nI As Byte
        lValidBlNno = False

        Me.DataSetForm.Tables(0).Clear()
        Me.DataSetForm.Tables(1).Clear()


        Bls = Nothing
        Clnt = Nothing

        Dm = New DataManager(My.Settings.DSN)

        DS = StoredProcedures.SP_OutwardBlsByLineBlNo(CurrentShippingLine, Me.TextBlNo.TextValue)
        If DS.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No valid B/L No ?", "Data Requird")
            Exit Sub
        End If

        Dm.PopulateObjectsFromDataSet(DS, "TB_OutWardBls")
        Dm.DataSet.Tables("TB_OutWardBls").Merge(DS.Tables(0))

        Bls = Dm.GetTB_OutwardBLSCollectionFromDataSet()

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

        DS = StoredProcedures.SP_ExpInvoiceByBLID(Bl.ID.ToString)
        Dm.PopulateObjectsFromDataSet(DS, aTables)
        For nI = 0 To aTables.Length - 1
            Dm.DataSet.Tables(aTables(nI)).Merge(DS.Tables(nI))
        Next
        Me.DataSetForm.Tables("TB_ExpInvoice").Merge(Dm.DataSet.Tables("TB_ExpInvoice"))
        If Dm.DataSet.Tables("TB_ExpInvoice").Rows.Count > 0 Then
            Me.Remarks.TextValue = Dm.DataSet.Tables("TB_ExpInvoice").Rows(0).Item("Description")
        Else
            Me.Remarks.TextValue = ""
        End If
        Me.GridBLCharges.DataSource = Dm.DataSet.Tables("TB_OutWardCharges")
        GridNumSeperator(Me.GridBLCharges)
        Me.DataSetForm.AcceptChanges()
        lValidBlNno = True
        SetDocument()

    End Sub

    Private Sub GenerateNew(ByVal IsCalculateNew As Boolean)

        Dim Dpt As CLDeparturCost
        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Err As DataTable
        Dim Frm As FrmRaiseError
        Dim Dtn As New CLDetention
        Dim BookingCost As New CLBookingCost
        Dim Drs() As DataRow
        Dim Seq As Byte
        Dim Tax As Double
        Dim Toll As Double
        Dim IrrTax As Double = 0
        Dim IrrToll As Double = 0
        Dim CalBase As CLCalculationBase = New CLCalculationBase
        Dim TaxUsd As Double
        Dim TaxIrr As Double
        Dim TaxOther As Double
        Dim TollUsd As Double
        Dim TollIrr As Double
        Dim TollOther As Double
        Dim sSql As String
        Dim IResult As Boolean
        Dim ClientTHCP As Integer
        Dim TBct As New DataTable
        Dim NewDrTHC As DataRow

        Dim TbTax As New DataTable
        TbTax.Columns.Add(New DataColumn("Currency"))
        TbTax.Columns.Add(New DataColumn("TaxAmount", System.Type.GetType("System.Double")))
        TbTax.Columns.Add(New DataColumn("DutyAmount", System.Type.GetType("System.Double")))

        If Me.TextBlNo.TextValue = "" Then
            Exit Sub
        End If



        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, Me.TextBlNo.TextValue, MatchType.Exact)
        Dm.GetTB_OutwardBLS()
        DataSetForm.Tables("TB_ExpInvoice").Clear()
        DataSetForm.Tables("TB_ExpInvoiceDetails").Clear()
        Me.DataSetForm.AcceptChanges()

        InvStatus = InvoiceStatus.Issue
        Me.Remarks.TextValue = ""

        If lValidBlNno = False Then
            MsgBox("Invalid B/L No.!")
            Exit Sub
        End If

        'If IsCalculateNew = True Then
        '    If Sof.DschCmnc.ToString() = "Null" Then
        '        MsgBox("Commence Discharge in S.O.F. is Null !")
        '        Exit Sub
        '    End If
        'End If

        InvID = System.Guid.NewGuid

        DummyTB.Clear()
        DummyTB.AcceptChanges()

        If IsCalculateNew = True Then
            Me.Remarks.TextValue = IIf(Clnt.fName = "", Clnt.lName, Clnt.fName)
            Dpt = New CLDeparturCost
            'appu - voyage case
            'Dpt.GenDeparturCost(Dm.DataSet.Tables("TB_OutWardBls").Rows(0), Now, Voy)
            If Sof.Berthed.IsNull Then
                MsgBox("Please Enter Berth Date for the Voyage SOF!")
                Exit Sub
            End If
            'Dpt.GenDeparturCost(Dm.DataSet.Tables("TB_OutWardBls").Rows(0), Sof.Berthed, Voy)
            Dpt.GenDeparturCost(Dm.DataSet.Tables("TB_OutWardBls").Rows(0), Now, Voy)
            Err = Dpt.GetTbError
            Tb = Dpt.GetTBDetails
            If Err.Rows.Count > 0 Then
                Frm = New FrmRaiseError(Err)
                Frm.ShowDialog()
                Exit Sub
            End If
            For Each Dr In Tb.Rows
                If Dr("IsDeposit") = False And (Dr("ActualAmount") + Dr("MandatoryAmount") + Dr("ConditionalAmount")) > 0 Then
                    NewDr = DummyTB.NewRow
                    NewDr("ID") = System.Guid.NewGuid
                    NewDr("InvoiceID") = InvID
                    NewDr("ChargesCode") = Dr("ChargeItem")
                    NewDr("Seq") = Dr("Seq")
                    NewDr("Amount") = Dr("MandatoryAmount") + Dr("ConditionalAmount") ' Dr("ActualAmount")
                    NewDr("IrrAmount") = Dr("MandatoryAmount") + Dr("ConditionalAmount")
                    NewDr("Currency") = "IRR"
                    NewDr("Remarks") = Dr("MeaningF")
                    DummyTB.Rows.Add(NewDr)
                End If
            Next



            Dtn.CalExpDetention(Dm.DataSet.Tables("TB_OutWardBls").Rows(0).Item("BLNO"), Dm.DataSet.Tables("TB_OutWardBls").Rows(0).Item("ID"), False)
            If Dtn.IsCalculateByError = True Then
                MsgBox("Please Check Detention List " & vbCr & "Some Container Calculate Terminated !")
            End If

            If Dtn.TotalAmount > 0 Then
                NewDr = DummyTB.NewRow 'NewDr = DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                NewDr("ID") = System.Guid.NewGuid
                NewDr("InvoiceID") = InvID
                NewDr("ChargesCode") = "DETN"
                NewDr("Seq") = 10
                NewDr("Amount") = Dtn.Balance
                NewDr("IrrAmount") = Dtn.Balance
                NewDr("Currency") = "IRR"
                NewDr("Remarks") = "حق توقف"
                DummyTB.Rows.Add(NewDr) 'DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(NewDr)
            End If

            BookingCost.CallBookingFreight(Bl, Dpt)
            For Each Dr In BookingCost.TBBooking.Rows
                NewDr = DummyTB.NewRow
                NewDr("ID") = System.Guid.NewGuid
                NewDr("InvoiceID") = InvID
                NewDr("ChargesCode") = Dr("ChargesCode")
                NewDr("Seq") = 20
                NewDr("Amount") = Dr("Amount")
                NewDr("IrrAmount") = IIf(Dr("Currency") = "IRR", Dr("Amount"), 0)
                NewDr("Currency") = Dr("Currency")
                NewDr("Remarks") = GetMeaningFCode("CG", Dr("ChargesCode"))
                DummyTB.Rows.Add(NewDr)
            Next

            ''adding 10% discount for Forwarders
            sSql = "select ClientType from TB_Clients where ID = '" & Bl.ClientID.ToString & "'"
            TableBySql(sSql, TBct, IResult)

            Drs = DummyTB.Select("ChargesCode = 'EPL'")
            If Drs.Length > 0 Then

                If TBct.Rows.Count > 0 Then
                    If Not TBct.Rows(0).Item("ClientType") = "NR" Then
                        For Each Dr In Drs
                            Dr("Amount") = Dr("Amount") - (Dr("Amount") / 100 * 20) ' Dr("ActualAmount")
                            Dr("IrrAmount") = Dr("IrrAmount") - (Dr("IrrAmount") / 100 * 20)

                        Next
                    End If
                End If
            End If

            Drs = DummyTB.Select("ChargesCode = 'B/L'")
            If Drs.Length > 0 Then

                If TBct.Rows.Count > 0 Then
                    If Not TBct.Rows(0).Item("ClientType") = "NR" Then
                        For Each Dr In Drs
                            Dr("Amount") = Dr("Amount") - (Dr("Amount") / 100 * 20) ' Dr("ActualAmount")
                            Dr("IrrAmount") = Dr("IrrAmount") - (Dr("IrrAmount") / 100 * 20)

                        Next
                    End If
                End If
            End If

            'Drs = DummyTB.Select("ChargesCode = 'SEAL'")
            'If Drs.Length > 0 Then

            '    If TBct.Rows.Count > 0 Then
            '        If Not TBct.Rows(0).Item("ClientType") = "NR" Then
            '            For Each Dr In Drs
            '                Dr("Amount") = Dr("Amount") - (Dr("Amount") / 100 * 20) ' Dr("ActualAmount")
            '                Dr("IrrAmount") = Dr("IrrAmount") - (Dr("IrrAmount") / 100 * 20)

            '            Next
            '        End If
            '    End If
            'End If



            Tax = 0
            Toll = 0
            InvID = Guid.NewGuid
            NewDr = Dm.DataSet.Tables("TB_ExpInvoice").NewRow
            NewDr("ID") = InvID
            NewDr("BlID") = Bl.ID
            NewDr("IssueTime") = Format(Now)
            NewDr("IssueBy") = CurrentUser.UserCode
            NewDr("Status") = Int32.Parse(InvStatus)
            NewDr("Description") = Me.Remarks.TextValue
            Dm.DataSet.Tables("TB_ExpInvoice").Rows.Add(NewDr)
            Seq = 0

            For Each Dr In DummyTB.Rows
                Seq += 1
                NewDr = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                NewDr("ID") = Guid.NewGuid
                NewDr("InvoiceID") = InvID
                NewDr("ChargesCode") = Dr("ChargesCode")
                NewDr("Seq") = Seq
                NewDr("Amount") = Dr("Amount")
                NewDr("IrrAmount") = IIf(Dr("Currency") = "IRR", Dr("IrrAmount"), 0)
                NewDr("Currency") = Dr("Currency")
                NewDr("Remarks") = Dr("Remarks")
                Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(NewDr)
                CalBase.GetTaxDutyDyDate(Now.Date, Dr("ChargesCode"))

                Drs = TbTax.Select("Currency = '" & Dr("Currency") & "'")
                If Drs.Length = 0 Then

                    NewDr = TbTax.NewRow
                    NewDr("Currency") = Dr("Currency")
                    NewDr("TaxAmount") = ((Dr("Amount") * CalBase.Tax) / 100)
                    NewDr("DutyAmount") = ((Dr("Amount") * CalBase.Duty) / 100)
                    TbTax.Rows.Add(NewDr)
                Else
                    Drs(0).Item("TaxAmount") += ((Dr("Amount") * CalBase.Tax) / 100)
                    Drs(0).Item("DutyAmount") += ((Dr("Amount") * CalBase.Duty) / 100)
                End If

            Next

            If Now.Date >= DateTime.ParseExact("03/21/2021", "MM/dd/yyyy", CultureInfo.InvariantCulture) Then

                Drs = DummyTB.Select("ChargesCode = 'THC'")
                If Drs.Length > 0 Then
                    sSql = "select ClientType from TB_Clients where ID = '" & Bl.ClientID.ToString & "'"
                    TableBySql(sSql, TBct, IResult)
                    If TBct.Rows.Count > 0 Then
                        If TBct.Rows(0).Item("ClientType") = "NR" Then
                            ClientTHCP = 3
                        Else
                            ClientTHCP = 2
                        End If
                        For Each Dr In Drs
                            NewDrTHC = DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                            NewDrTHC("ID") = System.Guid.NewGuid
                            NewDrTHC("InvoiceID") = InvID
                            NewDrTHC("ChargesCode") = "THC-A"
                            NewDrTHC("Seq") = 3
                            NewDrTHC("Amount") = (Dr("Amount") / 100) * ClientTHCP
                            NewDrTHC("IrrAmount") = (Dr("Amount") / 100) * ClientTHCP
                            NewDrTHC("Currency") = "IRR"
                            NewDrTHC("Remarks") = "THC هزینه کارگزاری"
                            DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(NewDrTHC)
                            CalBase.GetTaxDutyDyDate(Now.Date, Dr("ChargesCode"))

                            Drs = TbTax.Select("Currency = '" & Dr("Currency") & "'")
                            If Drs.Length = 0 Then

                                NewDr = TbTax.NewRow
                                NewDr("Currency") = Dr("Currency")
                                NewDr("TaxAmount") = ((((Dr("Amount") / 100) * ClientTHCP) * CalBase.Tax) / 100)
                                NewDr("DutyAmount") = ((((Dr("Amount") / 100) * ClientTHCP) * CalBase.Duty) / 100)
                                TbTax.Rows.Add(NewDr)
                            Else
                                Drs(0).Item("TaxAmount") += ((((Dr("Amount") / 100) * ClientTHCP) * CalBase.Tax) / 100)
                                Drs(0).Item("DutyAmount") += ((((Dr("Amount") / 100) * ClientTHCP) * CalBase.Duty) / 100)
                            End If
                        Next
                    End If
                End If
            End If

            TbTax.AcceptChanges()
            For Each Dr In TbTax.Rows
                If Dr("TaxAmount") + Dr("DutyAmount") = 0 Then
                    Dr.Delete()
                End If
            Next


            TbTax.AcceptChanges()

            If CalBase.Tax + CalBase.Duty = 0 Then
                CalBase.GetTaxDutyOutward(Bl.ID, "B/L")
            End If

            If calculationBase.IsTaxDutyJoin = True Then
                For Each Dr In TbTax.Rows
                    Seq += 1
                    NewDr = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                    NewDr("ID") = Guid.NewGuid
                    NewDr("InvoiceID") = InvID
                    NewDr("ChargesCode") = "TAX"
                    NewDr("Seq") = Seq
                    NewDr("Amount") = Dr("TaxAmount") + Dr("DutyAmount")
                    NewDr("IrrAmount") = IIf(Dr("Currency") = "IRR", Dr("TaxAmount") + Dr("DutyAmount"), 0)
                    NewDr("Currency") = Dr("Currency")
                    NewDr("Remarks") = (CalBase.Tax + CalBase.Duty).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                    Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(NewDr)
                Next
            Else
                For Each Dr In TbTax.Rows
                    Seq += 1
                    NewDr = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                    NewDr("ID") = Guid.NewGuid
                    NewDr("InvoiceID") = InvID
                    NewDr("ChargesCode") = "TAX"
                    NewDr("Seq") = Seq
                    NewDr("Amount") = Dr("TaxAmount") ' + Dr("DutyAmount")
                    NewDr("IrrAmount") = IIf(Dr("Currency") = "IRR", Dr("TaxAmount"), 0)
                    NewDr("Currency") = Dr("Currency")
                    NewDr("Remarks") = (CalBase.Tax).ToString & "%" & " بابت مالیات ارزش افزوده "
                    Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(NewDr)

                    Seq += 1
                    NewDr = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                    NewDr("ID") = Guid.NewGuid
                    NewDr("InvoiceID") = InvID
                    NewDr("ChargesCode") = "TOLL"
                    NewDr("Seq") = Seq
                    NewDr("Amount") = Dr("DutyAmount")
                    NewDr("IrrAmount") = IIf(Dr("Currency") = "IRR", Dr("DutyAmount"), 0)
                    NewDr("Currency") = Dr("Currency")
                    NewDr("Remarks") = (CalBase.Duty).ToString & "%" & " بابت عوارض ارزش افزوده "
                    Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(NewDr)
                Next
            End If

        Else
            If Me.GridList.Rows.Count > 0 Then
                Me.DataSetForm.AcceptChanges()
            End If
            Me.Remarks.TextValue = IIf(Clnt.fName = "", Clnt.lName, Clnt.fName)
        End If

        Me.GridDetail.DataSource = Me.DataSetForm.Tables("TB_ExpInvoiceDetails")
        Me.GridDetail.DisplayLayout.Bands(0).Columns("IrrAmount").Hidden = False
        InvStatus = InvoiceStatus.Issue

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


        Dv = New DataView(Dm.DataSet.Tables("TB_ExpInvoice"), "ID = '" & InvID.ToString & "'", "", DataViewRowState.CurrentRows)
        If Dv.Count = 0 Then
            Dr = Dm.DataSet.Tables("TB_ExpInvoice").NewRow()
            Dr("ID") = InvID
            Dr("BlID") = Bl.ID
            ' by appu on 18-01-2016
            'Dr("IssueTime") = Format(Now, "dd/MM/yyyy")
            Dr("IssueTime") = Now 'Format(Now, "dd/MM/yyyy")
            Dr("IssueBy") = CurrentUser.UserCode
            Dr("Status") = Int32.Parse(InvStatus)
            Dr("Description") = Me.Remarks.TextValue
            Dm.DataSet.Tables("TB_ExpInvoice").Rows.Add(Dr)
            CurrentStatus = Int32.Parse(InvStatus)
        Else
            CurrentStatus = Dv.Item(0).Item("Status")
            If Byte.Parse(InvStatus) < 3 Then
                If NullToValue(Dv.Item(0).Item("InvoiceNo"), "") = "" And InvStatus = InvoiceStatus.Confirm Then
                    Dv.Item(0).Item("InvoiceNo") = GetNewInvNo(InOut.OutWard)
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

        Tb = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").GetChanges
        If Not Tb Is Nothing Then
            For Each Dr In Tb.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        Dm.DataSet.Tables("TB_ExpInvoiceDetails").ImportRow(Dr)
                    Case DataRowState.Deleted
                        Dv = New DataView(Dm.DataSet.Tables("TB_ExpInvoiceDetails"), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            Dv.Item(0).Delete()
                        End If
                    Case DataRowState.Modified
                        Dv = New DataView(Dm.DataSet.Tables("TB_ExpInvoiceDetails"), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            For Each DC In Tb.Columns
                                Dv.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                            Next
                        End If
                End Select
            Next
        End If

        nI = 0
        Dv = New DataView(Dm.DataSet.Tables("TB_ExpInvoiceDetails"), "", "Seq", DataViewRowState.CurrentRows)
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
        Catch ex As Exception
            InvStatus = CurrentStatus
            MsgBoxSaveFailed()
        End Try

    End Sub

    Private Sub SetDocument()

        Dim aRows() As DataRow
        Dim Dr As DataRow
        Dim sCntr As String = ""
        Dim TB As DataTable
        Dim lResult As Boolean

        Me.DataSetForm.Tables("TB_Summary").Clear()
        aRows = Dm.DataSet.Tables("TB_ExpInvoiceDetails").Select("InvoiceID = '" & InvID.ToString & "'")
        Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Clear()

        For Each Dr In aRows
            Me.DataSetForm.Tables("TB_ExpInvoiceDetails").ImportRow(Dr)
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

        OutwardCntrsCount(Bl.ID, sCntr)
        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Total Containers"
        Dr("Value") = Replace(sCntr, vbCrLf, " & ")
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)

        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Status"
        Dr("Value") = GetMeaningCode("ST", Bl.BlStatus)
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)

        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Exchage Rate Freight"
        Dr("Value") = Voy.ExchangeFrt
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)

        Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
        Dr("Description") = "Exchage Rate THC"
        Dr("Value") = Voy.ExchangeThc.ToString
        Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)

        Try
            Dr = Me.DataSetForm.Tables("TB_Summary").NewRow
            Dr("Description") = "Sailed"
            Dr("Value") = Sof.Sailed
            Me.DataSetForm.Tables("TB_Summary").Rows.Add(Dr)
        Catch ex As Exception
        End Try

        TableBySql("Select dbo.FC_OutwardBLIsImco ('" & Bl.ID.ToString & "')", TB, lResult)

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

        For Each dr In DataSetForm.Tables("TB_ExpInvoiceDetails").Rows
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

    Private Sub GridDetail_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GridDetail.AfterRowUpdate
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
        'e.Layout.Bands(0).Columns("Amount").Format = "#,###"
        'e.Layout.Bands(0).Columns("IrrAmount").Format = "#,###"
        'e.Layout.Bands(0).Columns("Seq").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
        'e.Layout.Bands(0).Columns("Remarks").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

    End Sub

    Private Sub GridDeposits_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        e.Layout.Bands(0).Columns("Amount").Format = "#,###"
        e.Layout.Bands(0).Columns("Remarks").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click

        Dim LogDataSet As New DataSet
        Dim Dv As DataView
        Dim dr As DataRow
        If Me.GridList.Rows.Count = 0 Then
            Exit Sub
        End If

        If Int32.Parse(InvStatus) = InvoiceStatus.Confirm Then
            MsgBoxGeneral("Not allow !", "Change Invoice Status")
            Exit Sub
        End If

        If Int32.Parse(InvStatus) = InvoiceStatus.Cancel Then
            MsgBoxGeneral("Not allow !", "Change Invoice Status")
            Exit Sub
        End If

        If Int32.Parse(InvStatus) = InvoiceStatus.ToAccount Then
            MsgBoxGeneral("Not allow !", "Change Invoice Status")
            Exit Sub
        End If


        If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
            Dv = New DataView(Dm.DataSet.Tables("TB_ExpInvoice"), "ID = '" & InvID.ToString & "'", "", DataViewRowState.CurrentRows)
            If Dv.Count > 0 Then
                For Each dr In Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows
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

    Private Sub GenerateDetention()

        Dim Sum As CLOutwardBlsSummary
        Dim Dtn As New CLDetention
        Dim BLID As Guid
        Dim ds As New DataSet
        Dim Report As RptOutwardDetention
        Dim Frm As New FrmGeneralReportShow
        Dim PH As New CLPrintHdr
        Dim Dscnt As TB_OutwardDiscount
        Dim sDscnt As String = ""
        Dim Col As DataColumn
        Dim Clnt As TB_Clients

        ds = StoredProcedures.SP_OutwardBlsByLineBlNo(CurrentShippingLine, Me.TextBlNo.TextValue)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No valid B/L No ?", "Data Requird")
            Exit Sub
        End If
        Sum = New CLOutwardBlsSummary(ds.Tables(0).Rows(0).Item("Id"))

        BLID = ds.Tables(0).Rows(0).Item("ID")
        Dtn.GenerateExportDetention(BLID)
        ds = Dtn.CalExpDetention(Me.TextBlNo.TextValue, BLID)

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardDiscount.Columns.BLID, BLID, MatchType.Exact)
        Dscnt = Dm.GetTB_OutwardDiscount()
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
            sDscnt = IIf(sDscnt = "", "", "DISCOUNT DETAILS :") & sDscnt
        End If
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bl.ClientID, MatchType.Exact)
        Clnt = Dm.GetTB_Clients

        Report = New RptOutwardDetention

        Col = New DataColumn("dscnt", System.Type.GetType("System.String"))
        Col.DefaultValue = sDscnt
        ds.Tables(1).Columns.Add(Col)

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

        For Each dr As DataRow In ds.Tables(0).Rows

            dr("Reference") = Int64.Parse(Bl.Reference)
            If Not Clnt Is Nothing Then
                dr("TEL") = Clnt.TEL
                dr("Fax") = Clnt.Fax
                dr("EMAIL") = Clnt.Email
            End If
        Next

        Col = New DataColumn("Paid", System.Type.GetType("System.Int64"))
        Col.DefaultValue = 0
        ds.Tables(1).Columns.Add(Col)
        For Each dr As DataRow In ds.Tables(1).Rows
            If NullToValue(ds.Tables(0).Rows(0).Item("Paid"), 0) > 0 Then
                dr("Paid") = NullToValue(ds.Tables(0).Rows(0).Item("Paid"), 0) + ds.Tables(1).Rows(0).Item("Tax")
            Else
                dr("Paid") = NullToValue(ds.Tables(0).Rows(0).Item("Paid"), 0)
            End If


        Next

        If Dtn.IsCalculateByError = True Then
            MsgBox("Some Container Calculate Failed !")
        End If
        For Each dr As DataRow In ds.Tables(1).Rows
            dr("Dscnt") = sDscnt
        Next
        Report.SetDataSource(ds.Tables(0))
        Report.Subreports("RptInwardDetentionSub").SetDataSource(ds.Tables(1))
        '      Report.Subreports(0).SetDataSource(PH.ImageTable)

        Frm.ReportViewer.ReportSource = Report
        Frm.Show()

    End Sub

    Private Sub GridDetail_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles GridDetail.AfterCellUpdate
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

        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Frm As New FrmGeneralReportShow
        Dim DS As New DataSet
        Dim Dv As DataView
        Dim nI As Long = 0
        Dim PH As New CLPrintHdr
        Dim Ans As Boolean
        Dim nDrs() As DataRow
        Dim pValue As String

        Ans = RetriveObject(CurrentShippingLine & "_Invoice", "C:\INV")
        If Ans = True Then
            Report = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Report.Load("C:\INV")
        Else
            Report = New RptInvoice
        End If


        Try
            DS = StoredProcedures.SP_RptExpInvoice(InvID.ToString)
            If DS.Tables(0).Select("ChargesCode = 'OFT'").Length > 0 Then
                pValue = "Y"
            Else
                pValue = "N"
            End If

            DS.Tables(0).Columns.Add(New DataColumn("CompanyAccount"))
            DS.Tables(0).Columns.Add(New DataColumn("Account"))
            DS.Tables(0).Columns.Add(New DataColumn("InvoiceID"))
            DS.Tables(0).Columns.Add(New DataColumn("ISOCE"))

            Dv = New DataView(DS.Tables(0), "", "Seq", DataViewRowState.CurrentRows)
            For Each dr As DataRowView In Dv
                nI += 1
                dr("Seq") = nI
                dr("FPrintTime") = ToPersianDate(Now.Date)
                If DS.Tables(1).Rows.Count > 0 Then
                    dr("CompanyAccount") = CurrentCompany.CompanyAccount
                    dr("InvoiceID") = InvID.ToString
                    dr("ISOCE") = pValue
                End If
                dr("CompanyAccount") = CurrentCompany.CompanyAccount
            Next

            DS.AcceptChanges()

            '         Report.Subreports(0).SetDataSource(PH.ImageTable)


            DS.Tables(0).WriteXml("c:\tmp\1.Xml")
            DS.Tables(1).WriteXml("c:\tmp\2.Xml")

            Report.SetDataSource(DS.Tables(0))

            Report.Subreports("RptRecivedItems").SetDataSource(DS.Tables(1))
            'Report.SetParameterValue("ISOCE", pValue)
            Frm.ReportViewer.ReportSource = Report
            Frm.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub ButtonPrintInvIWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrintInvIWS.Click

        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Frm As New FrmGeneralReportShow
        Dim DS As New DataSet
        Dim Dv As DataView
        Dim nI As Long = 0
        Dim PH As New CLPrintHdr
        Dim Ans As Boolean
        Dim nDrs() As DataRow
        Dim pValue As String
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)

        Ans = RetriveObject(CurrentShippingLine & "_Invoice", "C:\INV")
        If Ans = True Then
            Report = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Report.Load("C:\INV")
        Else
            Report = New RptInvoiceIWS
        End If


        Try
            'DS = StoredProcedures.SP_RptExpInvoice(InvID.ToString)
            Me.Cursor = Cursors.WaitCursor
            Cmd = New SqlCommand("SP_RptExpInvoiceIWS")
            Cnn = New SqlConnection(My.Settings.DSN)
            Cnn.Open()
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@InvoiceID", InvID.ToString)

            Cmd.Connection = Cnn
            DA.SelectCommand = Cmd
            Cmd.CommandTimeout = 5000
            DA.Fill(DS)

            If DS.Tables(0).Select("Remarks = 'OFT'").Length > 0 Then
                pValue = "Y"
            Else
                pValue = "N"
            End If

            DS.Tables(0).Columns.Add(New DataColumn("CompanyAccount"))
            DS.Tables(0).Columns.Add(New DataColumn("Account"))
            DS.Tables(0).Columns.Add(New DataColumn("InvoiceID"))
            DS.Tables(0).Columns.Add(New DataColumn("ISOCE"))

            Dv = New DataView(DS.Tables(0), "", "Seq", DataViewRowState.CurrentRows)
            For Each dr As DataRowView In Dv
                nI += 1
                dr("Seq") = nI
                dr("FPrintTime") = ToPersianDate(Now.Date)
                If DS.Tables(1).Rows.Count > 0 Then
                    dr("CompanyAccount") = CurrentCompany.CompanyAccount
                    dr("InvoiceID") = InvID.ToString
                    dr("ISOCE") = pValue
                End If
            Next
            DS.AcceptChanges()

            '         Report.Subreports(0).SetDataSource(PH.ImageTable)


            DS.Tables(0).WriteXml("c:\tmp\1.Xml")
            DS.Tables(1).WriteXml("c:\tmp\2.Xml")

            Report.SetDataSource(DS.Tables(0))

            'Report.Subreports("RptRecivedItems").SetDataSource(DS.Tables(1))
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

        TB = New DataTable("TB_ExpInvoice")
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

        TB = New DataTable("TB_ExpInvoiceDetails")
        TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("InvoiceID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
        TB.Columns.Add(New DataColumn("ChargesCode", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Remarks", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Currency", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Amount", System.Type.GetType("System.Double")))
        TB.Columns.Add(New DataColumn("IRRAmount", System.Type.GetType("System.Double")))
        DataSetForm.Tables.Add(TB)

        TB = New DataTable("TB_Summary")
        TB.Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Value", System.Type.GetType("System.String")))
        DataSetForm.Tables.Add(TB)

        With Me.GridList
            .DataSource = Me.DataSetForm
            .DataMember = "TB_ExpInvoice"
        End With

        With Me.GridDetail
            .DataSource = Me.DataSetForm
            .DataMember = "TB_ExpInvoiceDetails"
            .DisplayLayout.Bands(0).Columns("Amount").Format = "#,###"
            .DisplayLayout.Bands(0).Columns("IrrAmount").Format = "#,###"
            .DisplayLayout.Bands(0).Columns("Seq").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .DisplayLayout.Bands(0).Columns("Remarks").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With

        With Me.GridSummary
            .DataSource = Me.DataSetForm
            .DataMember = "TB_Summary"
        End With

    End Sub

    Private Sub CreateDummyTB()
        DummyTB = New DataTable("Dummy")
        DummyTB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.String")))
        DummyTB.Columns.Add(New DataColumn("InvoiceID", System.Type.GetType("System.String")))
        DummyTB.Columns.Add(New DataColumn("ChargesCode", System.Type.GetType("System.String")))
        DummyTB.Columns.Add(New DataColumn("Seq", System.Type.GetType("System.String")))
        DummyTB.Columns.Add(New DataColumn("Amount", System.Type.GetType("System.String")))
        DummyTB.Columns.Add(New DataColumn("IrrAmount", System.Type.GetType("System.String")))
        DummyTB.Columns.Add(New DataColumn("Currency", System.Type.GetType("System.String")))
        DummyTB.Columns.Add(New DataColumn("Remarks", System.Type.GetType("System.String")))
    End Sub

    Private Sub GridDetail_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetail.AfterRowsDeleted
        If Not IsBlank Then
            RecalculateTax()
        End If
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
            For Each dr As DataRow In Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows
                If dr.RowState <> DataRowState.Deleted Then

                    CalBase.GetTaxDutyDyDate(Now.Date, dr("ChargesCode"))

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

        Drs = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Select("ChargesCode = 'TAX' or ChargesCode = 'TOLL'")

        For Each dr As DataRow In Drs
            If dr.RowState <> DataRowState.Deleted Then
                dr.Delete()
            End If
        Next

        If CalBase.Tax + CalBase.Duty = 0 Then
            CalBase.GetTaxDutyDyDate(Now.Date, "B/L")
        End If

        If Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Count > 0 Then
            If calculationBase.IsTaxDutyJoin = True Then
                nDR = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                nDR("Seq") = 98
                nDR("ID") = Guid.NewGuid
                nDR("InvoiceID") = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows(0).Item("InvoiceID")
                nDR("ChargesCode") = "TAX"
                nDR("IRRAmount") = TTLTaxIrr
                nDR("Amount") = TTLTaxIrr
                nDR("Remarks") = (CalBase.Tax + CalBase.Duty).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                nDR("Currency") = "IRR"
                Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(nDR)

                If TTLTaxUsd > 0 Then
                    nDR = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                    nDR("Seq") = 98
                    nDR("ID") = Guid.NewGuid
                    nDR("InvoiceID") = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows(0).Item("InvoiceID")
                    nDR("ChargesCode") = "TAX"
                    nDR("IRRAmount") = 0
                    nDR("Amount") = TTLTaxUsd
                    nDR("Remarks") = (CalBase.Tax + CalBase.Duty).ToString & "%" & "  بابت مالیات و عوارض ارزش افزوده ارزی"
                    nDR("Currency") = "USD"
                    Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(nDR)
                End If

            Else
                nDR = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                nDR("Seq") = 98
                nDR("ID") = Guid.NewGuid
                nDR("InvoiceID") = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows(0).Item("InvoiceID")
                nDR("IRRAmount") = TTLTaxIrr
                nDR("Amount") = TTLTaxIrr
                nDR("ChargesCode") = "TAX"
                nDR("Remarks") = (CalBase.Tax).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                nDR("Currency") = "IRR"
                Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(nDR)
                nDR = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                nDR("Seq") = 99
                nDR("ID") = Guid.NewGuid
                nDR("InvoiceID") = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows(0).Item("InvoiceID")
                nDR("ChargesCode") = "TOLL"
                nDR("IRRAmount") = TTLTollIrr
                nDR("Amount") = TTLTollIrr
                nDR("Remarks") = (CalBase.Duty).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                nDR("Currency") = "IRR"
                Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(nDR)

                If TTLTaxUsd > 0 Then

                    nDR = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                    nDR("Seq") = 100
                    nDR("ID") = Guid.NewGuid
                    nDR("InvoiceID") = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows(0).Item("InvoiceID")
                    nDR("IRRAmount") = 0
                    nDR("Amount") = TTLTaxUsd
                    nDR("ChargesCode") = "TAX"
                    nDR("Remarks") = (CalBase.Tax).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                    nDR("Currency") = "USD"
                    Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(nDR)
                    nDR = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").NewRow
                    nDR("Seq") = 101
                    nDR("ID") = Guid.NewGuid
                    nDR("InvoiceID") = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows(0).Item("InvoiceID")
                    nDR("ChargesCode") = "TOLL"
                    nDR("IRRAmount") = 0
                    nDR("Amount") = TTLTollUsd
                    nDR("Remarks") = (CalBase.Duty).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                    nDR("Currency") = "USD"
                    Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Rows.Add(nDR)

                End If


            End If
        End If

        Drs = Me.DataSetForm.Tables("TB_ExpInvoiceDetails").Select("", "Seq")

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

End Class

