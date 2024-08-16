Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports System.IO

Public Class CLDetention

    Private Dm As DataManager
    Private TotalDetention As Double
    Private lAllReturnBack As Boolean = True
    Private lHasError As Boolean
    Private BLID As Guid
    Private Result As DataTable
    Private nFistPaid As Int64
    Private nPaid As Int64
    Private nPaidUsd As Double
    Private nTotalDiscount As Int64
    Private nTotaldetention
    Private nBalance As Int64
    Private nUsdBalance As Int64
    Private sDetnExit As String
    Private nTax As Double
    Private nTaxAmount As Int64
    Private nTotalDamageCost As Long
    Private nPaidDamage As Double
    Private nPaidDamageUsd As Double
    Private nDamageTax As Double
    Private sDamageCurrency As String
    Private nFirstPaidUsd As Double
    Private nTotalDamageCostUsd As Double
    Private nDamageTaxUsd As Double
    Private IsChildBl As Boolean = False
    Private IsMasterBL As Boolean = False
    Private nDetnROE As Double = 0
    Private Bl As TB_InwardBLS
    Private Sof As TB_SOF



    Public Sub GenerateImportDetention(ByVal BLID As Guid, Optional ByVal ForLine As Boolean = False)

        Dim Cns As New TB_InwardCntrsCollection
        Dim Ds As New DataSet
        Dim Dr As DataRow

        lHasError = False
        lAllReturnBack = True

        Me.BLID = BLID
        Dm = New DataManager(My.Settings.DSN)
        If ForLine = False Then
            Ds = StoredProcedures.SP_DetentionImpByBLID(BLID.ToString)
        Else
            Ds = StoredProcedures.SP_DetentionImpByBLIDForLine(BLID.ToString)
        End If

        For Each Dr In Ds.Tables(0).Rows
            TotalDetention += Dr("Detention")
            If Dr("Status") = "F" Then
                lHasError = True
            End If
            If IsDBNull(Dr("EaDate")) Then
                lAllReturnBack = False
            End If
        Next
        Result = Ds.Tables(0).Copy
        Result.TableName = "Result"

    End Sub

    Public ReadOnly Property IsCntrsReturnBack() As Boolean
        Get
            Return lAllReturnBack
        End Get
    End Property

    Public ReadOnly Property IsCalculateByError() As Boolean
        Get
            Return lHasError
        End Get
    End Property

    Public ReadOnly Property TotalAmount() As Double
        Get
            Return TotalDetention
        End Get
    End Property

    Public ReadOnly Property GetDetetion() As DataTable
        Get
            Return Result
        End Get
    End Property

    Public Function CalExpDetention(ByVal BLNO As String, ByVal BID As Guid, Optional ByVal ForLine As Boolean = False) As DataSet

        Dim Ds As New DataSet
        Dim DPC As New ClDetentionPerCntr
        Dim Row As DataRow
        Dim Temp As DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim sCntrs As String = ""
        Dim DT As Date
        Dim Cmd As SqlClient.SqlCommand
        Dim tempTB As DataTable
        Dim Base As New CLCalculationBase

        If ForLine = False Then
            Ds = StoredProcedures.SP_DetentionExpGnrlReportByLineBL(CurrentShippingLine, BLNO)
        Else
            Ds = StoredProcedures.SP_DetentionExpGnrlReportByLineBLForLine(CurrentShippingLine, BLNO)
        End If


        lHasError = False
        Ds.Tables(1).Columns.Add(New DataColumn("DiscountCntr", System.Type.GetType("System.Int64")))

        For Each Row In Ds.Tables(1).Rows

            If IsDBNull(Row("DF")) Then
                Row.RowError = "Please Check MS Date & FL Date"
                lHasError = True
            Else
                'To get "Shipment" column value.
                Dim IsGoForNewDetentionCal As Boolean = False
                Dim strExport_ExportTransit As String
                strExport_ExportTransit = "E"

                'To get new caltulation for detention should have the delivery date is equal or more than that of '23/07/2018' - Requirement as on '21'June'2018'
                If Ds.Tables(0).Rows.Count > 0 Then
                    If Ds.Tables(0).Rows(0)("Discharge").ToString <> "" Then
                        Dim dischageDt As DateTime = Ds.Tables(0).Rows(0)("Discharge")
                        'New query from client
                        'They want the External transit for the new period from '22/06/2018' to '22/07/2018' - This is for old detention value.
                        'STATIC DATE - 23/07/2018 - - This is for new detention value.
                        Dim staticDate As Date = Date.ParseExact("22/06/2018", "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                        If staticDate <= dischageDt Then
                            IsGoForNewDetentionCal = True
                        Else
                            IsGoForNewDetentionCal = False
                        End If
                    End If
                End If

                'Calculation to get 'ET' or 'E' - (E-Export, ET-ExternalTransit)
                If IsGoForNewDetentionCal = True Then
                    Dim daST As New SqlDataAdapter
                    Dim dsST As New DataSet
                    Dim objConnection As New SqlConnection(My.Settings.DSN)
                    Dim strSQLBLStatus As String = "select BLStatus from TB_OutwardBls where BlNo = '" + BLNO + "'"
                    Dim objCommand As New SqlCommand(strSQLBLStatus, objConnection)
                    objConnection.Open()
                    daST.SelectCommand = objCommand
                    daST.Fill(dsST)

                    If dsST.Tables(0).Rows.Count > 0 Then
                        If dsST.Tables(0).Rows(0)(0).ToString = "5" Then
                            strExport_ExportTransit = "ET"
                        Else
                            strExport_ExportTransit = "E"
                        End If
                    Else
                        strExport_ExportTransit = "E"
                    End If

                    objConnection.Close()
                End If
                'End

                Temp = DPC.DetentionPerCntr("Outward", strExport_ExportTransit, Row("CnSize"), Row("Cntype"), Row("DF"),
                                           NullToValue(Row("EA"), Now()), Row("ID").ToString,
                                            Int16.Parse(Row("LCLCount").ToString), Row("LCLWgtPercent"), Row("CntrNo"))
                Drs = Temp.Select("CntrNo = '" & Row("CntrNo") & "'")
                Row("FreeDays") = Drs(0).Item("OriginFreedays")
                Row("FreeDays") = Drs(0).Item("Freedays")
                Row("Days") = IIf(Drs(0).Item("TotalDays") < 1, 0, Drs(0).Item("TotalDays"))
                Row("Detention") = Drs(0).Item("Detention")
                Row("DiscountCntr") = Drs(0).Item("Discount")
            End If
        Next

        nFistPaid = NullToValue(Ds.Tables(0).Rows(0).Item("FirstPaid"), 0)
        nPaid = NullToValue(Ds.Tables(0).Rows(0).Item("Paid"), 0)
        TotalDetention = DPC.GetTotaldetention
        Ds.Tables(0).Rows(0).Item("Detention") = DPC.GetTotaldetention
        Ds.Tables(0).Rows(0).Item("Discount") = DPC.GetTotalDiscount
        Ds.Tables(0).Rows(0).Item("Balance") = DPC.GetTotaldetention - (DPC.GetTotalDiscount + nFistPaid + nPaid)

        nBalance = DPC.GetTotaldetention - (DPC.GetTotalDiscount + nFistPaid + nPaid)

        nTotalDiscount = DPC.GetTotalDiscount
        nTotaldetention = DPC.GetTotaldetention
        nTotalDamageCost = DPC.GetDamageCost

        OutwardCntrsCount(BID, sCntrs)
        Ds.Tables(0).Rows(0).Item("Totalcntrs") = sCntrs

        Dr = Ds.Tables(0).Rows(0)
        For Each Row In Ds.Tables(1).Rows
            Row("FirstPaid") = NullToValue(Dr("FirstPaid"), 0)
            Row("Discount") = DPC.GetTotalDiscount
        Next

        If TotalDetention > 0 Then
            Dim sSql As String = "Select * , isnull(Remarks,0) as Tax  From TB_DetentionBase Where @Date Between  Applydate and Validity and ImpExp = 'I'"
            Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
            Dim adapter2 As SqlClient.SqlDataAdapter
            Dim Parm As New SqlClient.SqlParameter("@Date", SqlDbType.DateTime)

            Drs = Ds.Tables(1).Select("FreeDays > 0", "DF DESC")
            DT = Drs(0).Item("DF")
            DT = DT.Date
            'Base.GetTaxDutyDyDate(DT) - appu
            Base.GetTaxDutyDyDate(DT, "DETN")
            nTax = Base.Tax + Base.Duty
            If nTax > 0 Then
                If TotalDetention - nTotalDiscount > 0 Then
                    nTaxAmount = ((TotalDetention - nTotalDiscount) * nTax) / 100
                End If
            End If
        End If

        Ds.Tables(1).Columns.Add(New DataColumn("TAX", System.Type.GetType("System.Int64")))
        For Each Dr In Ds.Tables(1).Rows
            Dr("Tax") = TaxAmount
        Next

        Ds.Tables(0).Columns.Add(New DataColumn("AccountDetails", System.Type.GetType("System.String")))
        Ds.Tables(0).Rows(0).Item("AccountDetails") = CurrentCompany.CompanyAccount

        Return Ds

    End Function
    Public Sub GenerateExportDetention(ByVal BLID As Guid, Optional ByVal ForLine As Boolean = False)

        Dim Cns As New TB_OutwardCntrsCollection
        Dim Ds As New DataSet
        Dim Dr As DataRow

        lHasError = False
        lAllReturnBack = True

        Me.BLID = BLID
        Dm = New DataManager(My.Settings.DSN)
        If ForLine = False Then
            Ds = StoredProcedures.SP_DetentionExpByBLID(BLID.ToString)
        Else
            Ds = StoredProcedures.SP_DetentionExpByBLIDForLine(BLID.ToString)
        End If

        For Each Dr In Ds.Tables(0).Rows
            TotalDetention += Dr("Detention")
            If Dr("Status") = "F" Then
                lHasError = True
            End If
            If IsDBNull(Dr("EaDate")) Then
                lAllReturnBack = False
            End If
        Next
        Result = Ds.Tables(0).Copy
        Result.TableName = "Result"

    End Sub

    Public Function CalDetention(ByVal BLNO As String, ByVal BID As Guid, Optional ByVal ForLine As Boolean = False, Optional ByVal Extradays As Integer = 0) As DataSet

        Dim Ds As New DataSet
        Dim DPC As New ClDetentionPerCntr
        Dim Row As DataRow
        Dim Temp As DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim sCntrs As String = ""
        Dim Cmd As SqlClient.SqlCommand
        Dim Dt As Date
        Dim Col As New DataColumn
        Dim TempTB As DataTable
        Dim CalBase As New CLCalculationBase

        If ForLine = False Then
            Ds = StoredProcedures.SP_DetentionGnrlReportByLineBL(CurrentShippingLine, BLNO)
        Else
            Ds = StoredProcedures.SP_DetentionGnrlReportByLineBLForLine(CurrentShippingLine, BLNO)
        End If
        Ds.Tables(1).Columns.Add(New DataColumn("DiscountCntr", System.Type.GetType("System.Int64")))

        SetBlMasterChild(CurrentShippingLine, BLNO)
        DPC.IsChaildBL = IsChildBl
        DPC.IsMasterBL = IsMasterBL
        nTotalDamageCost = 0
        nTotalDamageCostUsd = 0
        For Each Row In Ds.Tables(1).Rows
            Ds.Tables(1).TableName = "V"
            If Row("SOC") <> "Y" Then
                If IsDBNull(Row("EA")) Then
                    lAllReturnBack = False
                End If
                If IsDBNull(Row("DF")) Then
                    '    Ds.Tables(0).Rows(1).RowError = "Please Check DF Date & MA Date"
                    Row.RowError = "Please Check DF Date & MA Date"
                Else
                    If IsMasterBL Then
                        Row("LCLCount") = 1
                        Row("LCLWgtPercent") = 100
                    End If

                    'To get "Shipment" column value.
                    Dim IsGoForNewDetentionCal As Boolean = False
                    Dim strImport_ExportTransit As String
                    strImport_ExportTransit = "I"

                    'To get new caltulation for detention should have the delivery date is equal or more than that of '23/07/2018' - Requirement as on '21'June'2018'
                    If Ds.Tables(0).Rows.Count > 0 Then
                        If Ds.Tables(0).Rows(0)("Discharge").ToString <> "" Then
                            Dim dischageDt As DateTime = Ds.Tables(0).Rows(0)("Discharge")
                            'New query from client
                            'They want the External transit for the new period from '22/06/2018' to '22/07/2018' - This is for old detention value.
                            'STATIC DATE - 23/07/2018 - - This is for new detention value.
                            Dim staticDate As Date = Date.ParseExact("22/06/2018", "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                            If staticDate <= dischageDt Then
                                IsGoForNewDetentionCal = True
                            Else
                                IsGoForNewDetentionCal = False
                            End If
                        End If
                    End If

                    'Calculation to get 'ET' or 'I' - (I-Import, ET-ExternalTransit)
                    If IsGoForNewDetentionCal = True Then
                        Dim daST As New SqlDataAdapter
                        Dim dsST As New DataSet
                        Dim objConnection As New SqlConnection(My.Settings.DSN)
                        Dim strSQLBLStatus As String = "select BLStatus from TB_InwardBls where BlNo = '" + BLNO + "'"
                        Dim objCommand As New SqlCommand(strSQLBLStatus, objConnection)
                        objConnection.Open()
                        daST.SelectCommand = objCommand
                        daST.Fill(dsST)

                        If dsST.Tables(0).Rows.Count > 0 Then
                            If dsST.Tables(0).Rows(0)(0).ToString = "5" Then
                                strImport_ExportTransit = "ET"
                            Else
                                strImport_ExportTransit = "I"
                            End If
                        Else
                            strImport_ExportTransit = "I"
                        End If

                        objConnection.Close()
                    End If
                    'End

                    'Temp = DPC.DetentionPerCntr(strImport_ExportTransit, Row("CnSize"), Row("Cntype"), Row("DF"), _
                    '                               NullToValue(Row("EA"), DateAdd(DateInterval.Day, Extradays, Now())), Row("ID").ToString, _
                    '                                Int16.Parse(Row("LCLCount").ToString), Row("LCLWgtPercent"), Row("CntrNo"))

                    Temp = DPC.DetentionPerCntr("Inward", strImport_ExportTransit, Row("CnSize"), Row("Cntype"), Row("DF"),
                                                   NullToValue(Row("EA"), DateAdd(DateInterval.Day, Extradays, Now())), Row("ID").ToString,
                                                    Int16.Parse(Row("LCLCount").ToString), Row("LCLWgtPercent"), Row("CntrNo"))
                    Drs = Temp.Select("CntrNo = '" & Row("CntrNo") & "'")
                    Row("FreeDays") = Drs(0).Item("OriginFreedays")
                    Row("Days") = IIf(Drs(0).Item("TotalDays") < 1, 0, Drs(0).Item("TotalDays"))
                    Row("Detention") = Drs(0).Item("Detention")
                    Row("DiscountCntr") = Drs(0).Item("DiscountCntr")
                    Drs(0).Item("DamageCost") = Row("DamageCost")
                    Drs(0).Item("DamageCurrency") = Row("DamageCurrency")
                    sDamageCurrency = Row("DamageCurrency")
                    If Row("DamageCurrency") = "IRR" Then
                        nTotalDamageCost += Row("DamageCost")
                    Else
                        nTotalDamageCostUsd += Row("DamageCost")
                    End If

                    Dm = New DataManager(My.Settings.DSN)
                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.ID, BID, MatchType.Exact)
                    Bl = Dm.GetTB_InwardBLS

                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Bl.VoyageID, MatchType.Exact)
                    Sof = Dm.GetTB_SOF

                    'If Me.IsCntrsReturnBack = True Then
                    ' add 06/30/2020 date for case- SYSTEM FLEXIBLITY ON DETENTION INVOICES
                    'If ((CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And (Sof.DschCmpl < Date.ParseExact("06/30/2020", "MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))) Then
                    If FrmInwardInvoice.DetnCurrency = "USD" Then
                        Dim sSql As String
                        Dim lResult As Boolean
                        Dim TB As New DataTable
                        Dim TB2 As New DataTable
                        Dim Drs2() As DataRow
                        Dim ExchangeDate As String
                        Drs2 = Ds.Tables("Table2").Select("ChargesCode = 'DETN'")
                        'appu - issutime logic for exrate commented based on mehdi mail and it should be always based on last cntr return date
                        'If Drs2.Length > 0 Then
                        '    sSql = "select IssueTime from tb_invoice left join tb_invoicedetails id on id.invoiceid =  tb_invoice.ID where InvoiceID ='" & Drs2(0).Item("invoiceId").ToString() & "' and ChargesCode = 'DETN'"
                        '    TableBySql(sSql, TB2, lResult)
                        '    ExchangeDate = Format((TB2.Rows(0).Item("IssueTime")), "yyyy-MM-dd")
                        'Else
                        sSql = "select [dbo].[FC_IsAllContainerReturnBackDate_exrate]('" & BID.ToString() & "') as returnbackdate"
                            TableBySql(sSql, TB2, lResult)
                            If TB2.Rows.Count > 0 And Not NullToValue(TB2.Rows(0).Item("returnbackdate").ToString(), "") = "" Then

                                ExchangeDate = Format((TB2.Rows(0).Item("returnbackdate")), "yyyy-MM-dd")
                            Else
                                'MessageBox.Show("None of the containers are returned back.", "Shipping")
                                'sDetnExit = "True"
                                'Exit Function
                                ExchangeDate = Format((System.DateTime.Now()), "yyyy-MM-dd")
                            End If

                        'End If
                        sSql = "Select DETNrate From TB_Exchange EX , TB_ExchangeDetails EXD  where EX.ID = EXD.MasterID and CurCode = '" & "USD" & "' and ExchangeDate = '" & ExchangeDate & "'"
                        TableBySql(sSql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If TB.Rows(0).Item("DETNrate") > 0 Then
                                    nUsdBalance += Drs(0).Item("Detention") * TB.Rows(0).Item("DETNrate")
                                    nDetnROE = TB.Rows(0).Item("DETNrate")
                                    sDetnExit = "False"
                                Else
                                    MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")
                                    sDetnExit = "True"
                                    Exit Function
                                End If
                            Else
                                MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")
                                sDetnExit = "True"
                                Exit Function
                            End If

                        End If
                    End If
                    ' End If


                End If
            Else
                Row("Detention") = 0
            End If
        Next

        InwardCntrsCount(BID, sCntrs)
        If Ds.Tables(0).Rows.Count > 0 Then
            nFistPaid = NullToValue(Ds.Tables(0).Rows(0).Item("FirstPaid"), 0)
            nPaid = NullToValue(Ds.Tables(0).Rows(0).Item("Paid"), 0)
            nPaidUsd = NullToValue(Ds.Tables(0).Rows(0).Item("Paid"), 0)
            nPaidDamage = NullToValue(Ds.Tables(0).Rows(0).Item("DamagePaid"), 0)
            nPaidDamageUsd = NullToValue(Ds.Tables(0).Rows(0).Item("DamagePaidUsd"), 0)
            nFirstPaidUsd = NullToValue(Ds.Tables(0).Rows(0).Item("FirstPaidUsd"), 0)
            Ds.Tables(0).Rows(0).Item("Detention") = DPC.GetTotaldetention
            Ds.Tables(0).Rows(0).Item("Discount") = DPC.GetTotalDiscount
            Ds.Tables(0).Rows(0).Item("Balance") = (DPC.GetTotaldetention + DPC.GetDamageCost) - (DPC.GetTotalDiscount + nFistPaid + nPaid + nPaidDamage)
            Ds.Tables(0).Rows(0).Item("Totalcntrs") = sCntrs
        End If

        nBalance = DPC.GetTotaldetention - (DPC.GetTotalDiscount + (nFistPaid) + nPaid)

        'If Not Sof Is Nothing Then
        'If ((CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And (Sof.DschCmpl < Date.ParseExact("06/30/2020", "MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)) And nDetnROE > 0 And DPC.GetTotalDiscount > 0) Then
        If FrmInwardInvoice.DetnCurrency = "USD" Then
            ' nUsdBalance -= ((DPC.GetTotalDiscount) * nDetnROE) - (nFistPaid)

            nUsdBalance = (DPC.GetTotaldetention * nDetnROE) - ((DPC.GetTotalDiscount * nDetnROE) + (nFistPaid) + nPaid)
            '  End If
        End If
        nTotalDiscount = DPC.GetTotalDiscount
        nTotaldetention = DPC.GetTotaldetention

        If Ds.Tables(0).Rows.Count > 0 Then
            Dr = Ds.Tables(0).Rows(0)
            For Each Row In Ds.Tables(1).Rows
                Row("FirstPaid") = NullToValue(Dr("FirstPaid"), 0)
                Row("Discount") = DPC.GetTotalDiscount
            Next
        End If


        TotalDetention = DPC.GetTotaldetention
        nTotalDiscount = DPC.GetTotalDiscount
        If Me.IsCntrsReturnBack = True Then
            CalBase.GetTaxDutyInward(BID, "DETN")
            ' CalBase.GetTaxDutyDyDate(Now.Date, "DETN")
        Else
            CalBase.GetTaxDutyInward(BID, "DETN-A")
            'CalBase.GetTaxDutyDyDate(Now.Date, "DETN-A")
        End If

        nTax = CalBase.Tax + CalBase.Duty

        If TotalDetention + DPC.GetDamageCost > 0 Then
            If nTax > 0 Then
                If (TotalDetention + DPC.GetDamageCost) > 0 Then
                    nTaxAmount = (((TotalDetention) - nTotalDiscount) * nTax) / 100
                    If DPC.GetDamageCost > 0 Then
                        nDamageTax = (((DPC.GetDamageCost)) * nTax) / 100
                        nDamageTaxUsd = (((DPC.GetDamageCostUsd)) * nTax) / 100
                    End If
                End If
            End If
        End If

        Ds.Tables(1).Columns.Add(New DataColumn("TAX", System.Type.GetType("System.Int64")))
        For Each Dr In Ds.Tables(1).Rows
            Dr("Tax") = TaxAmount
        Next
        Ds.AcceptChanges()

        Try
            If Ds.Tables(0).Rows.Count > 0 Then
                Ds.Tables(0).Columns.Add(New DataColumn("AccountDetails", System.Type.GetType("System.String")))
                Ds.Tables(0).Rows(0).Item("AccountDetails") = CurrentCompany.CompanyAccount
            End If
        Catch ex As Exception

        End Try


        Return Ds

    End Function
    ' For the case NEW REPORT CREATION REQUEST : "DETENTION OUTSTANDING SUMMARY"
    Public Function CalDetentionOutStandingSummary(ByVal BLNO As String, ByVal BID As Guid, Optional ByVal ForLine As Boolean = False, Optional ByVal Extradays As Integer = 0) As DataSet

        Dim Ds As New DataSet
        Dim DPC As New ClDetentionPerCntr
        Dim Row As DataRow
        Dim Temp As DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim sCntrs As String = ""
        'Dim Cmd As SqlClient.SqlCommand
        Dim Cmd As New SqlCommand
        Dim Dt As Date
        Dim Col As New DataColumn
        Dim TempTB As DataTable
        Dim CalBase As New CLCalculationBase
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)


        Cnn.Open()
        'f ForLine = False Then
        'Ds = StoredProcedures.SP_DetentionOutStandingSummary(CurrentShippingLine)
        'Else
        'Ds = StoredProcedures.SP_DetentionGnrlReportByLineBLForLine(CurrentShippingLine, BLNO)
        'End If

        'If ForLine = False Then
        'Ds = StoredProcedures.SP_DetentionGnrlReportByLineBL(CurrentShippingLine, BLNO)
        'Else
        '    Ds = StoredProcedures.SP_DetentionGnrlReportByLineBLForLine(CurrentShippingLine, BLNO)
        'End If



        With Cmd
            .CommandText = "SP_DetentionOutStandingSummary"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
            .Parameters.AddWithValue("@BLNO", BLNO)
        End With

        DA.SelectCommand = Cmd
        DA.Fill(Ds)
        Ds.Tables(1).Columns.Add(New DataColumn("DiscountCntr", System.Type.GetType("System.Int64")))

        'Ds.Tables(0).Columns.Add(New DataColumn("DiscountCntr", System.Type.GetType("System.Int64")))

        SetBlMasterChildDetentionOutStanding(CurrentShippingLine)
        DPC.IsChaildBL = IsChildBl
        DPC.IsMasterBL = IsMasterBL
        nTotalDamageCost = 0
        nTotalDamageCostUsd = 0
        For Each Row In Ds.Tables(1).Rows
            Ds.Tables(1).TableName = "V"
            If Row("SOC") <> "Y" Then
                If IsDBNull(Row("EA")) Then
                    lAllReturnBack = False
                End If
                If IsDBNull(Row("DF")) Then
                    '    Ds.Tables(0).Rows(1).RowError = "Please Check DF Date & MA Date"
                    Row.RowError = "Please Check DF Date & MA Date"
                Else
                    If IsMasterBL Then
                        Row("LCLCount") = 1
                        Row("LCLWgtPercent") = 100
                    End If
                    Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), Row("DF"),
                                                   NullToValue(Row("EA"), DateAdd(DateInterval.Day, Extradays, Now())), Row("ID").ToString,
                                                    Int16.Parse(Row("LCLCount").ToString), Row("LCLWgtPercent"), Row("CntrNo"))
                    Drs = Temp.Select("CntrNo = '" & Row("CntrNo") & "'")
                    Row("FreeDays") = Drs(0).Item("OriginFreedays")
                    Row("Days") = IIf(Drs(0).Item("TotalDays") < 1, 0, Drs(0).Item("TotalDays"))
                    Row("Detention") = Drs(0).Item("Detention")
                    Row("DiscountCntr") = Drs(0).Item("DiscountCntr")
                    Drs(0).Item("DamageCost") = Row("DamageCost")
                    Drs(0).Item("DamageCurrency") = Row("DamageCurrency")
                    sDamageCurrency = Row("DamageCurrency")
                    If Row("DamageCurrency") = "IRR" Then
                        nTotalDamageCost += Row("DamageCost")
                    Else
                        nTotalDamageCostUsd += Row("DamageCost")
                    End If
                    If Row("DamageCurrency2") = "IRR" Then
                        nTotalDamageCost += Row("DamageCost2")
                    Else
                        If Row("DamageCurrency2") = "USD" Then
                            nTotalDamageCostUsd += Row("DamageCost2")
                        End If
                    End If
                End If


            Else
                Row("Detention") = 0
            End If

        Next

        InwardCntrsCountForDetentionOutstanding(BID, sCntrs)
        'InwardCntrsCount(BID, sCntrs)
        If Ds.Tables(0).Rows.Count > 0 Then
            nFistPaid = NullToValue(Ds.Tables(0).Rows(0).Item("FirstPaid"), 0)
            nPaid = NullToValue(Ds.Tables(0).Rows(0).Item("Paid"), 0)
            nPaidUsd = NullToValue(Ds.Tables(0).Rows(0).Item("Paid"), 0)
            nPaidDamage = NullToValue(Ds.Tables(0).Rows(0).Item("DamagePaid"), 0)
            nPaidDamageUsd = NullToValue(Ds.Tables(0).Rows(0).Item("DamagePaidUsd"), 0)
            nFirstPaidUsd = NullToValue(Ds.Tables(0).Rows(0).Item("FirstPaidUsd"), 0)
            Ds.Tables(0).Rows(0).Item("Detention") = DPC.GetTotaldetention
            Ds.Tables(0).Rows(0).Item("Discount") = DPC.GetTotalDiscount
            Ds.Tables(0).Rows(0).Item("Balance") = (DPC.GetTotaldetention + DPC.GetDamageCost) - (DPC.GetTotalDiscount + nFistPaid + nPaid + nPaidDamage)
            Ds.Tables(0).Rows(0).Item("Totalcntrs") = sCntrs
        End If

        nBalance = DPC.GetTotaldetention - (DPC.GetTotalDiscount + nFistPaid + nPaid)
        nTotalDiscount = DPC.GetTotalDiscount
        nTotaldetention = DPC.GetTotaldetention

        If Ds.Tables(0).Rows.Count > 0 Then
            Dr = Ds.Tables(0).Rows(0)
            For Each Row In Ds.Tables(1).Rows
                Row("FirstPaid") = NullToValue(Dr("FirstPaid"), 0)
                Row("Discount") = DPC.GetTotalDiscount
            Next
        End If


        TotalDetention = DPC.GetTotaldetention
        nTotalDiscount = DPC.GetTotalDiscount
        If Me.IsCntrsReturnBack = True Then
            CalBase.GetTaxDutyInwardDetentionOutStanding("DETN")
            ' CalBase.GetTaxDutyDyDate(Now.Date, "DETN")
        Else
            CalBase.GetTaxDutyInwardDetentionOutStanding("DETN-A")
            'CalBase.GetTaxDutyDyDate(Now.Date, "DETN-A")
        End If

        nTax = CalBase.Tax + CalBase.Duty

        If TotalDetention + DPC.GetDamageCost > 0 Then
            If nTax > 0 Then
                If (TotalDetention + DPC.GetDamageCost) > 0 Then
                    nTaxAmount = (((TotalDetention) - nTotalDiscount) * nTax) / 100
                    If DPC.GetDamageCost > 0 Then
                        nDamageTax = (((DPC.GetDamageCost)) * nTax) / 100
                        nDamageTaxUsd = (((DPC.GetDamageCostUsd)) * nTax) / 100
                    End If
                End If
            End If
        End If

        Ds.Tables(1).Columns.Add(New DataColumn("TAX", System.Type.GetType("System.Int64")))
        For Each Dr In Ds.Tables(1).Rows
            Dr("Tax") = TaxAmount
        Next
        Ds.AcceptChanges()

        Try
            Ds.Tables(0).Columns.Add(New DataColumn("AccountDetails", System.Type.GetType("System.String")))
            If (ForLine.Equals(False)) Then
                Dim SaccDetails As String = ""
                Dim CompanyAccountTrim As String = ""
                Dim StrLength As Integer
                Dim k As Integer = 0
                Dim IsFirstNumeric As Boolean = False
                SaccDetails = CurrentCompany.CompanyAccount.ToString()
                Dim SaccountDetails() As String = SaccDetails.Split(":")
                For i = 0 To SaccountDetails.Length - 1
                    If i = 0 Then
                        CompanyAccountTrim = SaccountDetails(i) + " : "
                    End If
                    If i > 0 And i < 3 Then
                        k = 0
                        StrLength = SaccountDetails(i).Length
                        For Each ch In SaccountDetails(i)
                            k = k + 1
                            If (Char.IsNumber(ch) Or ch = "-" Or ch = " ") Then
                                'If Char.IsNumber(ch) And i = 1 Then
                                '    If (IsFirstNumeric = False) Then
                                '        CompanyAccountTrim += " : "
                                '        IsFirstNumeric = True
                                '    End If
                                'End If
                                If k = StrLength And i <> 2 Then
                                    CompanyAccountTrim += " : "
                                End If
                                CompanyAccountTrim += ch
                            Else
                                If i <> 2 Then
                                    CompanyAccountTrim += ch
                                End If

                            End If
                        Next
                    End If
                Next i
                Ds.Tables(0).Rows(0).Item("AccountDetails") = CompanyAccountTrim
            Else
                Ds.Tables(0).Rows(0).Item("AccountDetails") = CurrentCompany.CompanyAccount
            End If

        Catch ex As Exception

        End Try


        Return Ds

    End Function
    ' For the case NEW REPORT CREATION REQUEST : "DETENTION OUTSTANDING SUMMARY"
    Private Sub SetBlMasterChildDetentionOutStanding(ByVal Line As String)

        Dim Tb As New DataTable
        Dim lResult As Boolean


        TableBySql("Select Line , BLNO , isnull(FrtCoverdBlNo,'') as Coverd From Tb_InwardBls where Line = '" & Line & "'", Tb, lResult)

        If Tb.Rows.Count > 0 Then
            'BLNO = Tb.Rows(0).Item("BLNO")
            If Tb.Rows(0).Item("Coverd") = "" Then
                IsChildBl = False
            Else
                IsChildBl = True
            End If
        End If

        Tb = New DataTable
        'TableBySql("Select BLNO , isnull(FrtCoverdBlNo,'') as Coverd From Tb_InwardBls where FrtCoverdBlNo = '" & BLNO & "' and Line = '" & Line & "'", Tb, lResult)
        TableBySql("Select BLNO , isnull(FrtCoverdBlNo,'') as Coverd From Tb_InwardBls where Line = '" & Line & "'", Tb, lResult)

        If Tb.Rows.Count > 0 Then
            IsMasterBL = True
        Else
            IsMasterBL = False
        End If


    End Sub

    ' This method added for demurrage invoices changes (removal of last label - Company Account Details)REMOVING ONE SENTENCE FROM DEMURRAGE INVOICES
    Public Function CalDetentionInwardInvoice(ByVal BLNO As String, ByVal BID As Guid, Optional ByVal ForLine As Boolean = False, Optional ByVal Extradays As Integer = 0) As DataSet

        Dim Ds As New DataSet
        Dim DPC As New ClDetentionPerCntr
        Dim Row As DataRow
        Dim Temp As DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim sCntrs As String = ""
        Dim Cmd As SqlClient.SqlCommand
        Dim Dt As Date
        Dim Col As New DataColumn
        Dim TempTB As DataTable
        Dim CalBase As New CLCalculationBase

        Dim sSqlLine As String
        Dim lResultline As Boolean
        Dim TBLine As New DataTable

        sSqlLine = "select Line from tb_inwardbls where blno ='" & BLNO & "'"
        'and Line = '" & CurrentShippingLine & "'"
        TableBySql(sSqlLine, TBLine, lResultline)

        If ForLine = False Then
            Ds = StoredProcedures.SP_DetentionGnrlReportByLineBL(NullToValue(TBLine.Rows(0).Item("line"), CurrentShippingLine), BLNO)
        Else
            Ds = StoredProcedures.SP_DetentionGnrlReportByLineBLForLine(NullToValue(TBLine.Rows(0).Item("line"), CurrentShippingLine), BLNO)
        End If
        Ds.Tables(1).Columns.Add(New DataColumn("DiscountCntr", System.Type.GetType("System.Int64")))

        SetBlMasterChild(CurrentShippingLine, BLNO)
        DPC.IsChaildBL = IsChildBl
        DPC.IsMasterBL = IsMasterBL
        nTotalDamageCost = 0
        nTotalDamageCostUsd = 0
        For Each Row In Ds.Tables(1).Rows
            Ds.Tables(1).TableName = "V"
            If Row("SOC") <> "Y" Then
                If IsDBNull(Row("EA")) Then
                    lAllReturnBack = False
                End If
                If IsDBNull(Row("DF")) Then
                    '    Ds.Tables(0).Rows(1).RowError = "Please Check DF Date & MA Date"
                    Row.RowError = "Please Check DF Date & MA Date"
                Else
                    If IsMasterBL Then
                        Row("LCLCount") = 1
                        Row("LCLWgtPercent") = 100
                    End If

                    'To get "Shipment" column value.
                    Dim IsGoForNewDetentionCal As Boolean = False
                    Dim strImport_ExportTransit As String
                    strImport_ExportTransit = "I"

                    'To get new caltulation for detention should have the delivery date is equal or more than that of '23/07/2018' - Requirement as on '21'June'2018'
                    If Ds.Tables(0).Rows.Count > 0 Then
                        If Ds.Tables(0).Rows(0)("Discharge").ToString <> "" Then
                            Dim dischageDt As DateTime = Ds.Tables(0).Rows(0)("Discharge")
                            'New query from client
                            'They want the External transit for the new period from '22/06/2018' to '22/07/2018' - This is for old detention value.
                            'STATIC DATE - 23/07/2018 - - This is for new detention value.
                            Dim staticDate As Date = Date.ParseExact("22/06/2018", "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                            If staticDate <= dischageDt Then
                                IsGoForNewDetentionCal = True
                            Else
                                IsGoForNewDetentionCal = False
                            End If
                        End If
                    End If

                    'Calculation to get 'ET' or 'I' - (I-Import, ET-ExternalTransit)
                    If IsGoForNewDetentionCal = True Then
                        Dim daST As New SqlDataAdapter
                        Dim dsST As New DataSet
                        Dim objConnection As New SqlConnection(My.Settings.DSN)
                        Dim strSQLBLStatus As String = "select BLStatus from TB_InwardBls where BlNo = '" + BLNO + "'"
                        Dim objCommand As New SqlCommand(strSQLBLStatus, objConnection)
                        objConnection.Open()
                        daST.SelectCommand = objCommand
                        daST.Fill(dsST)

                        If dsST.Tables(0).Rows.Count > 0 Then
                            If dsST.Tables(0).Rows(0)(0).ToString = "5" Then
                                strImport_ExportTransit = "ET"
                            Else
                                strImport_ExportTransit = "I"
                            End If
                        Else
                            strImport_ExportTransit = "I"
                        End If

                        objConnection.Close()
                    End If
                    'End

                    Temp = DPC.DetentionPerCntr("Inward", strImport_ExportTransit, Row("CnSize"), Row("Cntype"), Row("DF"),
                                                   NullToValue(Row("EA"), DateAdd(DateInterval.Day, Extradays, Now())), Row("ID").ToString,
                                                    Int16.Parse(Row("LCLCount").ToString), Row("LCLWgtPercent"), Row("CntrNo"))
                    Drs = Temp.Select("CntrNo = '" & Row("CntrNo") & "'")
                    Row("FreeDays") = Drs(0).Item("OriginFreedays")
                    'Row("FreeDays") = Drs(0).Item("FreeDays")
                    Row("Days") = IIf(Drs(0).Item("TotalDays") < 1, 0, Drs(0).Item("TotalDays"))
                    Row("Detention") = Drs(0).Item("Detention")
                    Row("DiscountCntr") = Drs(0).Item("DiscountCntr")
                    Drs(0).Item("DamageCost") = Row("DamageCost")
                    Drs(0).Item("DamageCurrency") = Row("DamageCurrency")
                    sDamageCurrency = Row("DamageCurrency")
                    If Row("DamageCurrency") = "IRR" Then
                        nTotalDamageCost += Row("DamageCost")
                    Else
                        nTotalDamageCostUsd += Row("DamageCost")
                    End If
                    If Row("DamageCurrency2") = "IRR" Then
                        nTotalDamageCost += Row("DamageCost2")
                    Else
                        If Row("DamageCurrency2") = "USD" Then
                            nTotalDamageCostUsd += Row("DamageCost2")
                        End If
                    End If
                End If

                Dm = New DataManager(My.Settings.DSN)
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.ID, BID, MatchType.Exact)
                Bl = Dm.GetTB_InwardBLS

                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Bl.VoyageID, MatchType.Exact)
                Sof = Dm.GetTB_SOF

                'If Me.IsCntrsReturnBack = True Then
                ' add 06/30/2020 date for case- SYSTEM FLEXIBLITY ON DETENTION INVOICES
                'If ((CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And (Sof.DschCmpl < Date.ParseExact("06/30/2020", "MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))) Then
                If FrmInwardInvoice.DetnCurrency = "USD" Then
                    Dim sSql As String
                    Dim lResult As Boolean
                    Dim TB As New DataTable
                    Dim TB2 As New DataTable
                    Dim Drs2() As DataRow
                    Dim ExchangeDate As String
                    Drs2 = Ds.Tables("Table2").Select("ChargesCode = 'DETN'")
                    'appu - issutime logic for exrate commented based on mehdi mail and it should be always based on last cntr return date
                    'If Drs2.Length > 0 Then
                    '    sSql = "select IssueTime from tb_invoice left join tb_invoicedetails id on id.invoiceid =  tb_invoice.ID where InvoiceID ='" & Drs2(0).Item("invoiceId").ToString() & "' and ChargesCode = 'DETN'"
                    '    TableBySql(sSql, TB2, lResult)
                    '    ExchangeDate = Format((TB2.Rows(0).Item("IssueTime")), "yyyy-MM-dd")
                    '    sSql = "Select DETNrate From TB_Exchange EX , TB_ExchangeDetails EXD  where EX.ID = EXD.MasterID and CurCode = '" & "USD" & "' and ExchangeDate = '" & ExchangeDate & "'"
                    '    TableBySql(sSql, TB, lResult)
                    '    If lResult = True Then
                    '        If TB.Rows.Count > 0 Then
                    '            If TB.Rows(0).Item("DETNrate") > 0 Then
                    '                nUsdBalance += Drs(0).Item("Detention") * TB.Rows(0).Item("DETNrate")
                    '                nDetnROE = TB.Rows(0).Item("DETNrate")
                    '                sDetnExit = "False"
                    '            Else
                    '                MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")
                    '                sDetnExit = "True"
                    '                Exit Function
                    '            End If
                    '        Else
                    '            MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")
                    '            sDetnExit = "True"
                    '            Exit Function
                    '        End If
                    '    End If
                    'Else

                    sSql = "select [dbo].[FC_IsAllContainerReturnBackDate_exrate]('" & BID.ToString() & "') as returnbackdate"
                        TableBySql(sSql, TB2, lResult)
                        If TB2.Rows.Count > 0 And Not NullToValue(TB2.Rows(0).Item("returnbackdate").ToString(), "") = "" Then

                            ExchangeDate = Format((TB2.Rows(0).Item("returnbackdate")), "yyyy-MM-dd")
                        Else
                            'MessageBox.Show("None of the containers are returned back.", "Shipping")
                            'sDetnExit = "True"
                            'Exit Function
                            ExchangeDate = Format((System.DateTime.Now()), "yyyy-MM-dd")
                        End If
                        ''ExchangeDate = Format((System.DateTime.Now()), "yyyy-MM-dd")
                        If Not ExchangeDate = "NotValid" Then
                            sSql = "Select DETNrate From TB_Exchange EX , TB_ExchangeDetails EXD  where EX.ID = EXD.MasterID and CurCode = '" & "USD" & "' and ExchangeDate = '" & ExchangeDate & "'"
                            TableBySql(sSql, TB, lResult)
                            If lResult = True Then
                                If TB.Rows.Count > 0 Then
                                    If TB.Rows(0).Item("DETNrate") > 0 Then
                                        nUsdBalance += Drs(0).Item("Detention") * TB.Rows(0).Item("DETNrate")
                                        nDetnROE = TB.Rows(0).Item("DETNrate")
                                        sDetnExit = "False"
                                    Else
                                        MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")
                                        sDetnExit = "True"
                                        Exit Function
                                    End If
                                Else
                                    MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")
                                    sDetnExit = "True"
                                    Exit Function
                                End If
                            End If
                        End If
                    'End If

                    'sSql = "Select DETNrate From TB_Exchange EX , TB_ExchangeDetails EXD  where EX.ID = EXD.MasterID and CurCode = '" & "USD" & "' and ExchangeDate = '" & ExchangeDate & "'"
                    'TableBySql(sSql, TB, lResult)
                    'If lResult = True Then
                    '    If TB.Rows.Count > 0 Then
                    '        If TB.Rows(0).Item("DETNrate") > 0 Then
                    '            nUsdBalance += Drs(0).Item("Detention") * TB.Rows(0).Item("DETNrate")
                    '            nDetnROE = TB.Rows(0).Item("DETNrate")
                    '            sDetnExit = "False"
                    '        Else
                    '            MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")
                    '            sDetnExit = "True"
                    '            Exit Function
                    '        End If
                    '    Else
                    '        MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")
                    '        sDetnExit = "True"
                    '        Exit Function
                    '    End If
                    'End If
                End If
                ' End If


            Else
                Row("Detention") = 0
            End If

        Next

        InwardCntrsCount(BID, sCntrs)
        If Ds.Tables(0).Rows.Count > 0 Then
            nFistPaid = NullToValue(Ds.Tables(0).Rows(0).Item("FirstPaid"), 0)
            nPaid = NullToValue(Ds.Tables(0).Rows(0).Item("Paid"), 0)
            nPaidUsd = NullToValue(Ds.Tables(0).Rows(0).Item("Paid"), 0)
            nPaidDamage = NullToValue(Ds.Tables(0).Rows(0).Item("DamagePaid"), 0)
            nPaidDamageUsd = NullToValue(Ds.Tables(0).Rows(0).Item("DamagePaidUsd"), 0)
            nFirstPaidUsd = NullToValue(Ds.Tables(0).Rows(0).Item("FirstPaidUsd"), 0)
            Ds.Tables(0).Rows(0).Item("Detention") = DPC.GetTotaldetention
            Ds.Tables(0).Rows(0).Item("Discount") = DPC.GetTotalDiscount
            Ds.Tables(0).Rows(0).Item("Balance") = (DPC.GetTotaldetention + DPC.GetDamageCost) - (DPC.GetTotalDiscount + nFistPaid + nPaid + nPaidDamage)
            Ds.Tables(0).Rows(0).Item("Totalcntrs") = sCntrs
        End If

        nBalance = DPC.GetTotaldetention - (DPC.GetTotalDiscount + nFistPaid + nPaid)

        ' If ((CurrentShippingLine = "AXL" Or CurrentShippingLine = "LEX" Or CurrentShippingLine = "OTLO") And (Sof.DschCmpl < Date.ParseExact("06/30/2020", "MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)) And nDetnROE > 0 And DPC.GetTotalDiscount > 0) Then
        If FrmInwardInvoice.DetnCurrency = "USD" Then
            nUsdBalance -= (DPC.GetTotalDiscount) * nDetnROE
        End If
        nTotalDiscount = DPC.GetTotalDiscount
        nTotaldetention = DPC.GetTotaldetention

        If Ds.Tables(0).Rows.Count > 0 Then
            Dr = Ds.Tables(0).Rows(0)
            For Each Row In Ds.Tables(1).Rows
                Row("FirstPaid") = NullToValue(Dr("FirstPaid"), 0)
                Row("Discount") = DPC.GetTotalDiscount
            Next
        End If


        TotalDetention = DPC.GetTotaldetention
        nTotalDiscount = DPC.GetTotalDiscount
        If Me.IsCntrsReturnBack = True Then
            CalBase.GetTaxDutyInward(BID, "DETN")
            ' CalBase.GetTaxDutyDyDate(Now.Date, "DETN")
        Else
            CalBase.GetTaxDutyInward(BID, "DETN-A")
            'CalBase.GetTaxDutyDyDate(Now.Date, "DETN-A")
        End If

        nTax = CalBase.Tax + CalBase.Duty

        If TotalDetention + DPC.GetDamageCost > 0 Then
            If nTax > 0 Then
                If (TotalDetention + DPC.GetDamageCost) > 0 Then
                    nTaxAmount = (((TotalDetention) - nTotalDiscount) * nTax) / 100
                    If DPC.GetDamageCost > 0 Then
                        nDamageTax = (((DPC.GetDamageCost)) * nTax) / 100
                        nDamageTaxUsd = (((DPC.GetDamageCostUsd)) * nTax) / 100
                    End If
                End If
            End If
        End If

        Ds.Tables(1).Columns.Add(New DataColumn("TAX", System.Type.GetType("System.Int64")))
        For Each Dr In Ds.Tables(1).Rows
            Dr("Tax") = TaxAmount
        Next
        Ds.AcceptChanges()

        Try
            Ds.Tables(0).Columns.Add(New DataColumn("AccountDetails", System.Type.GetType("System.String")))
            If (ForLine.Equals(False)) Then
                Dim SaccDetails As String = ""
                Dim CompanyAccountTrim As String = ""
                Dim StrLength As Integer
                Dim k As Integer = 0
                Dim IsFirstNumeric As Boolean = False
                SaccDetails = CurrentCompany.CompanyAccount.ToString()
                Dim SaccountDetails() As String = SaccDetails.Split(":")
                For i = 0 To SaccountDetails.Length - 1
                    If i = 0 Then
                        CompanyAccountTrim = SaccountDetails(i) + " : "
                    End If
                    If i > 0 And i < 3 Then
                        k = 0
                        StrLength = SaccountDetails(i).Length
                        For Each ch In SaccountDetails(i)
                            k = k + 1
                            If (Char.IsNumber(ch) Or ch = "-" Or ch = " ") Then
                                'If Char.IsNumber(ch) And i = 1 Then
                                '    If (IsFirstNumeric = False) Then
                                '        CompanyAccountTrim += " : "
                                '        IsFirstNumeric = True
                                '    End If
                                'End If
                                If k = StrLength And i <> 2 Then
                                    CompanyAccountTrim += " : "
                                End If
                                CompanyAccountTrim += ch
                            Else
                                If i <> 2 Then
                                    CompanyAccountTrim += ch
                                End If

                            End If
                        Next
                    End If
                Next i
                'Ds.Tables(0).Rows(0).Item("AccountDetails") = CompanyAccountTrim
                Ds.Tables(0).Rows(0).Item("AccountDetails") = CurrentCompany.CompanyAccount
            Else
                Ds.Tables(0).Rows(0).Item("AccountDetails") = CurrentCompany.CompanyAccount
            End If

        Catch ex As Exception

        End Try


        Return Ds

    End Function

    Private Sub SetBlMasterChild(ByVal Line As String, ByVal BLNO As String)

        Dim Tb As New DataTable
        Dim lResult As Boolean


        TableBySql("Select Line , BLNO , isnull(FrtCoverdBlNo,'') as Coverd From Tb_InwardBls where Line = '" & Line & "' and BLNo = '" & BLNO & "'", Tb, lResult)

        If Tb.Rows.Count > 0 Then
            BLNO = Tb.Rows(0).Item("BLNO")
            If Tb.Rows(0).Item("Coverd") = "" Then
                IsChildBl = False
            Else
                IsChildBl = True
            End If
        End If

        Tb = New DataTable
        TableBySql("Select BLNO , isnull(FrtCoverdBlNo,'') as Coverd From Tb_InwardBls where FrtCoverdBlNo = '" & BLNO & "' and Line = '" & Line & "'", Tb, lResult)
        If Tb.Rows.Count > 0 Then
            IsMasterBL = True
        Else
            IsMasterBL = False
        End If


    End Sub

    Public ReadOnly Property TotalDiscount() As Int64
        Get
            Return nTotalDiscount
        End Get
    End Property

    Public ReadOnly Property FirstPaid() As Int64
        Get
            Return nFistPaid
        End Get
    End Property

    Public ReadOnly Property Paid() As Int64
        Get
            Return nPaid
        End Get
    End Property

    Public ReadOnly Property Balance() As Int64
        Get
            Return nBalance
        End Get
    End Property
    Public ReadOnly Property UsdBalance() As Int64
        Get
            Return nUsdBalance
        End Get
    End Property
    Public ReadOnly Property DetnExit() As String
        Get
            Return sDetnExit
        End Get
    End Property

    Public ReadOnly Property TaxPercent() As Int64
        Get
            Return nTax
        End Get
    End Property

    Public ReadOnly Property TaxAmount() As Int64
        Get
            Return nTaxAmount
        End Get
    End Property

    Public ReadOnly Property TotalDamageCost() As Long
        Get
            Return nTotalDamageCost
        End Get
    End Property

    Public ReadOnly Property TotalDamageCostUsd() As Long
        Get
            Return nTotalDamageCostUsd
        End Get
    End Property

    Public ReadOnly Property PaidDamage() As Double
        Get
            Return nPaidDamage
        End Get
    End Property

    Public ReadOnly Property PaidDamageUsd() As Double
        Get
            Return nPaidDamageUsd
        End Get
    End Property

    Public ReadOnly Property DamageTax() As Double
        Get
            Return nDamageTax
        End Get
    End Property

    Public ReadOnly Property DamageCurrency() As String
        Get
            Return sDamageCurrency
        End Get
    End Property

    Public ReadOnly Property PaidUsd() As String
        Get
            Return nPaidUsd
        End Get
    End Property

    Public ReadOnly Property FirstPaidUsd() As Double
        Get
            Return nFirstPaidUsd
        End Get
    End Property
End Class
