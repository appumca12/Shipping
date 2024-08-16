Imports OrmLib
Imports ShippingBiz

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


    Public Sub GenerateImportDetention(ByVal BLID As Guid, Optional ByVal ForLine As Boolean = False)

        Dim Cns As New TB_InwardCntrsCollection
        Dim Ds As New DataSet
        Dim Dr As DataRow

        lHasError = False
        lAllReturnBack = True

        Me.BLID = BLID
        Dm = New DataManager(My.Settings.DSN)
        If forLine = False Then
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

                Temp = DPC.DetentionPerCntr("E", Row("CnSize"), Row("Cntype"), Row("DF"), _
                                           NullToValue(Row("EA"), Now()), Row("ID").ToString, _
                                            Int16.Parse(Row("LCLCount").ToString), Row("LCLWgtPercent"), Row("CntrNo"))
                Drs = Temp.Select("CntrNo = '" & Row("CntrNo") & "'")
                Row("FreeDays") = Drs(0).Item("OriginFreedays")
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
            Base.GetTaxDutyDyDate(DT)
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
                    Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), Row("DF"), _
                                                   NullToValue(Row("EA"), DateAdd(DateInterval.Day, Extradays, Now())), Row("ID").ToString, _
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
            Ds.Tables(0).Rows(0).Item("AccountDetails") = CurrentCompany.CompanyAccount
        Catch ex As Exception

        End Try


        Return Ds

    End Function

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

        If ForLine = False Then
            Ds = StoredProcedures.SP_DetentionGnrlReportByLineBL(CurrentShippingLine, BLNO)
        Else
            Ds = StoredProcedures.SP_DetentionGnrlReportByLineBLForLine(CurrentShippingLine, BLNO)
        End If
        Ds.Tables(1).Columns.Add(New DataColumn("DiscountCntr", System.Type.GetType("System.Int64")))

        SetBlMasterChild(CurrentShippingLine, BLNO)
        DPC.IsChaildBL = IsChildBl
        DPC.IsMasterBL = IsMasterBL
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
                    Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), Row("DF"), _
                                                   NullToValue(Row("EA"), DateAdd(DateInterval.Day, Extradays, Now())), Row("ID").ToString, _
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
                Ds.Tables(0).Rows(0).Item("AccountDetails") = CompanyAccountTrim
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
