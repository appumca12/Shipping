

Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Text
Imports Microsoft.SqlServer
Imports Microsoft.SqlServer.Server
Imports OrmLib
Imports ShippingBiz
Public Class ClDetentionPerCntr

    Private Cnn As SqlConnection
    Private Cmd As SqlCommand
    Private ResultTable As DataTable
    Private TotalDetantion As Long
    Private TotalDiscount As Double
    Private TotalDamageCost As Long
    Private TotalDamageCostUsd As Double
    Private lIsMasterBL As Boolean = False
    Private lIsChaildBL As Boolean = False
    Private IsBlSetFromOutSide As Boolean = False

    Public Function DetentionPerCntr(ByVal ImportExport As String, _
                                              ByVal CnSize As String, _
                                              ByVal CnType As String, _
                                              ByVal dFrom As DateTime, _
                                              ByVal dTo As DateTime, _
                                              ByVal BLID As String, ByVal LCLCount As Int16, ByVal WGTPercent As Double, Optional ByVal CntrNo As String = "na")

        ' 0 Success 
        ' 1 No valid rate 

        'Dim ImportExport As String = "I"
        'Dim CnSize As String = "20"
        'Dim CnType As String = "HC"
        'Dim dFrom As DateTime = Now
        'Dim dTo As DateTime = DateAdd(DateInterval.Day, 20, Now)
        'Dim BLID As String = "4144cb80-96ab-473e-acf9-04804561f197"


        Dim DtnTable As New DataTable
        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim adapter2 As New SqlDataAdapter
        Dim dr As DataRow
        Dim nFrreDaysNoDiscount As Int16 = 0
        Dim TotalCntrs As Long

        Dim Msg As String = ""
        Dim sSql As String

        Dim FreeDays As Long
        Dim Totaldays As Long
        Dim NewDays As Long
        Dim NewDays1 As Long
        Dim DifDays As Long
        Dim TotalAmt As Long
        Dim Amount As Long
        Dim detentionNet As Long
        Dim AmountDiscount As Double
        Dim ds As New DataSet
        Dim OriginFreedays As Long
        Dim DSCNT As New DataTable

        Dim DummyBoolean As Boolean
        Dim DetentionID As Guid
        Dim lResult As Boolean

        Dim DA As New SqlDataAdapter

        If lIsMasterBL = True Then
            WGTPercent = 100
            LCLCount = 1
        End If

        dFrom = dFrom.Date
        dTo = dTo.Date

        ResultTable.Clear()
        ResultTable.AcceptChanges()

        'If ImportExport = "I" Then
        '    sSql = "Select Count(*) as TotalCntrs From Tb_InwardCntrs Where BLID = @BLID"
        'Else
        '    sSql = "Select Count(*) As TotalCntrs From  Tb_OutwardCntrs Where BLID = @BLID"
        'End If

        If ImportExport = "I" Or ImportExport = "ET" Then
            sSql = "Select Count(*) as TotalCntrs From Tb_InwardCntrs Where BLID = @BLID"
        Else
            sSql = "Select Count(*) As TotalCntrs From  Tb_OutwardCntrs Where BLID = @BLID"
        End If

        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@BLID", BLID)
        adapter2 = New SqlDataAdapter(Cmd)
        adapter2.Fill(Table)
        TotalCntrs = NullToValue(Table.Rows(0).Item(0), 1)

        Table = New DataTable
        'If ImportExport = "I" Then
        '    sSql = "Select * From TB_InwardDiscount Where BLID = @BLID"
        'Else
        '    sSql = "Select * From TB_OutwardDiscount Where BLID = @BLID"
        'End If
        If ImportExport = "I" Or ImportExport = "ET" Then
            sSql = "Select * From TB_InwardDiscount Where BLID = @BLID"
        Else
            sSql = "Select * From TB_OutwardDiscount Where BLID = @BLID"
        End If

        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@BLID", BLID)
        adapter2 = New SqlDataAdapter(Cmd)
        adapter2.Fill(Table)

        If Table.Rows.Count > 0 Then
            If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = False Then
                If Table.Rows(0).Item("dFreeDays") > 0 Then
                    nFrreDaysNoDiscount = Table.Rows(0).Item("dFreeDays")

                End If
            End If
            DetentionID = NullToValue(Table.Rows(0).Item("DetentionID"), Guid.Empty)
        End If

        If IsBlSetFromOutSide = False Then
            SetBlMasterChild(BLID)
        End If


        If CurrentCompany.DetentionBySlab = True Then
            If DetentionID = Guid.Empty Then
                Cnn.Open()
                Cmd = New SqlCommand("SP_DetentionDetailByAll")
                With Cmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cnn
                    .Parameters.AddWithValue("@ImportExport", ImportExport)
                    .Parameters.AddWithValue("@Date", dFrom.Date)
                    .Parameters.AddWithValue("@CnType", CnType)
                    .Parameters.AddWithValue("@Line", CurrentShippingLine)

                End With
                DA.SelectCommand = Cmd
                DA.Fill(ds)

                'ds = StoredProcedures.SP_DetentionDetailByAll((ImportExport, dFrom.Date, CnType, "LSL")
                DtnTable = ds.Tables(0)
            Else
                TableBySql("SP_DetentionDetailIDCnType '" & DetentionID.ToString & "' , '" & CnType & "'", DtnTable, lResult)
            End If

            Cnn.Close()

            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
            If Not CurrentShippingLine = "FDR" And Not CurrentShippingLine = "ABLE" And Not CurrentShippingLine = "OTLO" Then
                If DtnTable.Rows.Count > 0 Then
                    If nFrreDaysNoDiscount > 0 Then
                        FreeDays = nFrreDaysNoDiscount
                    Else
                        FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                    End If
                    OriginFreedays = FreeDays
                    For Each dr In DtnTable.Rows
                        Select Case CnSize
                            Case "20"
                                Amount = Long.Parse(dr("Amount20").ToString)
                            Case "40"
                                Amount = Long.Parse(dr("Amount40").ToString)
                            Case "45"
                                Amount = Long.Parse(dr("Amount45").ToString)
                        End Select

                        If Totaldays > 0 Then
                            If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                TotalAmt += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                If Totaldays < 1 Then
                                    Totaldays = 0
                                End If
                            Else
                                TotalAmt += (Totaldays * Amount)
                                Totaldays = 0
                                Exit For
                            End If
                        End If
                    Next
                    Msg = ""
                Else
                    Msg = "No Valid Rate For CnType " & CnType
                End If

                If IsChaildBL = True Then
                    TotalAmt = 0
                End If
                If TotalAmt < 1 Then
                    TotalAmt = 0
                End If

                If TotalAmt > 0 Then

                    If Table.Rows.Count > 0 Then
                        If Long.Parse(Table.Rows(0).Item("dFreeDays").ToString) > 0 Then
                            FreeDays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                            Totaldays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                            For Each dr In DtnTable.Rows
                                Select Case CnSize
                                    Case "20"
                                        Amount = Long.Parse(dr("Amount20").ToString)
                                    Case "40"
                                        Amount = Long.Parse(dr("Amount40").ToString)
                                    Case "45"
                                        Amount = Long.Parse(dr("Amount45").ToString)
                                End Select
                                If Totaldays > 0 Then
                                    If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                        AmountDiscount += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                        Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                        If Totaldays < 1 Then
                                            Totaldays = 0
                                        End If
                                    Else
                                        AmountDiscount += (Totaldays * Amount)
                                        Totaldays = 0
                                        Exit For
                                    End If
                                End If
                            Next
                        End If

                        If AmountDiscount > 0 Then
                            If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = False Then
                                TotalAmt -= AmountDiscount
                                AmountDiscount = 0
                                If TotalAmt < 1 Then
                                    TotalAmt = 0
                                End If
                            End If
                        End If

                        If AmountDiscount > TotalAmt Then
                            AmountDiscount = TotalAmt
                        End If

                        Try
                            AmountDiscount += (Long.Parse(Table.Rows(0).Item("dAmount").ToString) / TotalCntrs)
                        Catch ex As Exception
                            Msg += " " & Left(ex.ToString, 100)
                        End Try

                        If Not IsDBNull(Table.Rows(0).Item("dPercent")) Then
                            If Long.Parse(Table.Rows(0).Item("dPercent").ToString) > 0 Then
                                Try
                                    AmountDiscount += Long.Parse((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)
                                Catch ex As Exception
                                    Msg += " " & Left(ex.ToString, 100)
                                End Try
                            End If
                        End If
                    End If
                End If

                Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

                detentionNet = TotalAmt - AmountDiscount
            Else
                If DtnTable.Rows.Count > 0 Then
                    If nFrreDaysNoDiscount > 0 Then
                        FreeDays = nFrreDaysNoDiscount
                    Else
                        FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                    End If
                    OriginFreedays = FreeDays
                    For Each dr In DtnTable.Rows
                        Select Case CnSize
                            Case "20"
                                Amount = Long.Parse(dr("Amount20").ToString)
                            Case "40"
                                Amount = Long.Parse(dr("Amount40").ToString)
                            Case "45"
                                Amount = Long.Parse(dr("Amount45").ToString)
                        End Select

                        ''new jumper logic
                        If Totaldays > 0 Then
                            If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                NewDays = (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1)
                            Else
                                NewDays = Totaldays
                            End If

                            If FreeDays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                NewDays1 = (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1)
                            Else
                                NewDays1 = FreeDays
                            End If

                            DifDays = NewDays - NewDays1
                            If DifDays > 0 Then
                                TotalAmt += DifDays * Amount
                            End If

                            Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                            FreeDays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)

                            If Totaldays < 0 Then
                                Totaldays = 0
                            End If

                            If FreeDays < 0 Then
                                FreeDays = 0
                            End If
                        End If

                    Next
                Else
                    Msg = "No Valid Rate For CnType " & CnType
                End If

                If IsChaildBL = True Then
                    TotalAmt = 0
                End If
                If TotalAmt < 1 Then
                    TotalAmt = 0
                End If
            End If
            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
            FreeDays = OriginFreedays
            detentionNet = TotalAmt

            dr = ResultTable.NewRow
            dr("CntrNo") = CntrNo
            dr("FreeDays") = FreeDays
            dr("TotalDays") = Totaldays
            If LCLCount = 0 Then
                LCLCount = 1
            End If
            If Not lIsChaildBL = True Then
                If LCLCount > 1 And WGTPercent <> 0 Then
                    dr("Detention") = Int((TotalAmt * WGTPercent) / 100) '  Int(TotalAmt / LCLCount)
                    dr("Discount") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100)  ' Int(detentionNet / LCLCount)
                Else
                    dr("Detention") = Int(TotalAmt / LCLCount)
                    dr("Discount") = Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int(detentionNet / LCLCount)
                End If
            Else
                dr("Detention") = 0
                dr("Discount") = 0
                dr("DiscountCntr") = 0
                dr("DetentionNet") = 0
            End If
            dr("Message") = Msg
            If Table.Rows.Count > 0 Then
                If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = True Then
                    dr("OriginFreedays") = OriginFreedays
                Else
                    If NullToValue(Table.Rows(0).Item("dFreeDays"), 0) > 0 Then
                        dr("OriginFreedays") = nFrreDaysNoDiscount
                    Else
                        dr("OriginFreedays") = OriginFreedays
                    End If
                End If
            Else
                dr("OriginFreedays") = OriginFreedays
            End If
            TotalDetantion += Int((TotalAmt * WGTPercent) / 100) '   Int(TotalAmt / LCLCount)
            'TotalDetantion += Int((TotalAmt * Convert.ToInt64(WGTPercent)) / 100) '   Int(TotalAmt / LCLCount)
            TotalDiscount += (AmountDiscount * WGTPercent) / 100  ' Int(AmountDiscount / LCLCount)





            ResultTable.Rows.Add(dr)
            Return ResultTable
        Else
            ds = StoredProcedures.SP_DetentionDetailByAll(ImportExport, dFrom.Date, CnType, CurrentShippingLine)
            DtnTable = ds.Tables(0)
            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            If DtnTable.Rows.Count > 0 Then
                FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                If nFrreDaysNoDiscount > 0 Then
                    Totaldays -= (nFrreDaysNoDiscount - FreeDays)
                End If
                OriginFreedays = FreeDays
                For Each dr In DtnTable.Rows
                    Select Case CnSize
                        Case "20"
                            Amount = Long.Parse(dr("Amount20").ToString)
                        Case "40"
                            Amount = Long.Parse(dr("Amount40").ToString)
                        Case "45"
                            Amount = Long.Parse(dr("Amount45").ToString)
                    End Select

                    If Totaldays > 0 Then
                        If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                            TotalAmt += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                            Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                            If Totaldays < 1 Then
                                Totaldays = 0
                            End If
                        Else
                            TotalAmt += (Totaldays * Amount)
                            Totaldays = 0
                            Exit For
                        End If
                    End If
                Next
                Msg = ""
            Else
                Msg = "No Valid Rate For CnType " & CnType
            End If

            If TotalAmt < 1 Then
                TotalAmt = 0
            End If

            If TotalAmt > 0 Then

                If Table.Rows.Count > 0 Then
                    If Long.Parse(Table.Rows(0).Item("dFreeDays").ToString) > 0 Then

                        FreeDays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                        ' Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
                        Totaldays -= (Table.Rows(0).Item("dFreeDays") - DtnTable.Rows(0).Item("DayTo"))
                        For Each dr In DtnTable.Rows
                            Select Case CnSize
                                Case "20"
                                    Amount = Long.Parse(dr("Amount20").ToString)
                                Case "40"
                                    Amount = Long.Parse(dr("Amount40").ToString)
                                Case "45"
                                    Amount = Long.Parse(dr("Amount45").ToString)
                            End Select
                            If Totaldays > 0 Then
                                If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                    AmountDiscount += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                    Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                    If Totaldays < 1 Then
                                        Totaldays = 0
                                    End If
                                Else
                                    AmountDiscount += (Totaldays * Amount)
                                    Totaldays = 0
                                    Exit For
                                End If
                            End If
                        Next
                        If AmountDiscount = 0 Then
                            AmountDiscount = TotalAmt
                        End If
                    End If

                    If AmountDiscount > 0 Then
                        Try
                            DummyBoolean = Boolean.Parse(Table.Rows(0).Item("IsFDaysAsDiscount").ToString)

                        Catch ex As Exception
                            DummyBoolean = False
                        End Try
                        If DummyBoolean = True Then
                            '       AmountDiscount = TotalAmt - AmountDiscount
                        Else
                            '    TotalAmt = (TotalAmt - AmountDiscount)
                            AmountDiscount = 0
                            If TotalAmt < 1 Then
                                TotalAmt = 0
                            End If
                        End If
                    End If

                    If AmountDiscount > TotalAmt Then
                        AmountDiscount = TotalAmt
                    End If

                    Try
                        AmountDiscount += (Long.Parse(Table.Rows(0).Item("dAmount").ToString) / TotalCntrs)
                    Catch ex As Exception
                        Msg += " " & Left(ex.ToString, 100)
                    End Try

                    If Not IsDBNull(Table.Rows(0).Item("dPercent")) Then
                        If Long.Parse(Table.Rows(0).Item("dPercent").ToString) > 0 Then
                            Try
                                AmountDiscount += Long.Parse((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)
                            Catch ex As Exception
                                Msg += " " & Left(ex.ToString, 100)
                            End Try
                        End If
                    End If
                End If
            End If


            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            detentionNet = TotalAmt - AmountDiscount

            dr = ResultTable.NewRow
            dr("CntrNo") = CntrNo
            dr("FreeDays") = FreeDays
            dr("TotalDays") = Totaldays

            If Not lIsChaildBL Then
                If LCLCount > 0 And WGTPercent <> 0 Then
                    dr("Detention") = Int((TotalAmt * WGTPercent) / 100) '  Int(TotalAmt / LCLCount)
                    dr("Discount") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100)  ' Int(detentionNet / LCLCount)
                Else
                    dr("Detention") = Int(TotalAmt / LCLCount)
                    dr("Discount") = Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int(detentionNet / LCLCount)
                End If
            Else
                dr("Detention") = 0
                dr("Discount") = 0
                dr("DiscountCntr") = 0
                dr("DetentionNet") = 0
            End If

            'dr("Detention") = Int(TotalAmt / LCLCount)  ' Int(TotalAmt / LCLCount)
            'dr("Discount") = Int((AmountDiscount * WGTPercent) / 100) ' Int(AmountDiscount / LCLCount)
            'dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100) ' Int(detentionNet / LCLCount)
            dr("Message") = Msg
            If Table.Rows.Count > 0 Then
                If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = True Then
                    dr("OriginFreedays") = OriginFreedays
                Else
                    dr("OriginFreedays") = nFrreDaysNoDiscount
                End If
            Else
                dr("OriginFreedays") = OriginFreedays
            End If

            TotalDetantion += Int((TotalAmt * WGTPercent) / 100)  ' Int(TotalAmt / LCLCount)
            TotalDiscount += Int(AmountDiscount * WGTPercent / 100) ' Int(AmountDiscount / LCLCount)
            ResultTable.Rows.Add(dr)
            Return ResultTable

        End If

    End Function
    'Export Detention Report
    Public Function DetentionPerCntrExport(ByVal ImportExport As String, _
                                              ByVal CnSize As String, _
                                              ByVal CnType As String, _
                                              ByVal dFrom As DateTime, _
                                              ByVal dTo As DateTime, _
                                              ByVal BLID As String, ByVal LCLCount As Int16, ByVal WGTPercent As Double, Optional ByVal CntrNo As String = "na")

        ' 0 Success 
        ' 1 No valid rate 

        'Dim ImportExport As String = "I"
        'Dim CnSize As String = "20"
        'Dim CnType As String = "HC"
        'Dim dFrom As DateTime = Now
        'Dim dTo As DateTime = DateAdd(DateInterval.Day, 20, Now)
        'Dim BLID As String = "4144cb80-96ab-473e-acf9-04804561f197"


        Dim DtnTable As New DataTable
        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim adapter2 As New SqlDataAdapter
        Dim dr As DataRow
        Dim nFrreDaysNoDiscount As Int16 = 0
        Dim TotalCntrs As Long

        Dim Msg As String = ""
        Dim sSql As String

        Dim FreeDays As Long
        Dim Totaldays As Long
        Dim TotalAmt As Long
        Dim Amount As Long
        Dim detentionNet As Long
        Dim AmountDiscount As Long
        Dim ds As New DataSet
        Dim OriginFreedays As Long
        Dim DSCNT As New DataTable

        Dim DummyBoolean As Boolean
        Dim DetentionID As Guid
        Dim lResult As Boolean

        Dim DA As New SqlDataAdapter

        If lIsMasterBL = True Then
            WGTPercent = 100
            LCLCount = 1
        End If

        dFrom = dFrom.Date
        dTo = dTo.Date

        ResultTable.Clear()
        ResultTable.AcceptChanges()

        If ImportExport = "I" Then
            sSql = "Select Count(*) as TotalCntrs From Tb_InwardCntrs Where BLID = @BLID"
        Else
            sSql = "Select Count(*) As TotalCntrs From  Tb_OutwardCntrs Where BLID = @BLID"
        End If

        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@BLID", BLID)
        adapter2 = New SqlDataAdapter(Cmd)
        adapter2.Fill(Table)
        TotalCntrs = NullToValue(Table.Rows(0).Item(0), 1)

        Table = New DataTable
        If ImportExport = "I" Then
            sSql = "Select * From TB_InwardDiscount Where BLID = @BLID"
        Else
            sSql = "Select * From TB_OutwardDiscount Where BLID = @BLID"
        End If

        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@BLID", BLID)
        adapter2 = New SqlDataAdapter(Cmd)
        adapter2.Fill(Table)

        If Table.Rows.Count > 0 Then
            If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = False Then
                If Table.Rows(0).Item("dFreeDays") > 0 Then
                    nFrreDaysNoDiscount = Table.Rows(0).Item("dFreeDays")

                End If
            End If
            DetentionID = NullToValue(Table.Rows(0).Item("DetentionID"), Guid.Empty)
        End If

        If IsBlSetFromOutSide = False Then
            SetBlMasterChild(BLID)
        End If


        If CurrentCompany.DetentionBySlab = True Then
            If DetentionID = Guid.Empty Then
                Cnn.Open()
                Cmd = New SqlCommand("SP_DetentionDetailByAllExport")
                With Cmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cnn
                    .Parameters.AddWithValue("@ImportExport", ImportExport)
                    .Parameters.AddWithValue("@Date", dFrom.Date)
                    .Parameters.AddWithValue("@CnType", CnType)
                    .Parameters.AddWithValue("@Line", CurrentShippingLine)

                End With
                DA.SelectCommand = Cmd
                DA.Fill(ds)

                'ds = StoredProcedures.SP_DetentionDetailByAll((ImportExport, dFrom.Date, CnType, "LSL")
                DtnTable = ds.Tables(0)
            Else
                TableBySql("SP_DetentionDetailIDCnTypeExport'" & DetentionID.ToString & "' , '" & CnType & "'", DtnTable, lResult)
            End If

            Cnn.Close()

            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
            If DtnTable.Rows.Count > 0 Then
                If nFrreDaysNoDiscount > 0 Then
                    FreeDays = nFrreDaysNoDiscount
                Else
                    FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                End If
                OriginFreedays = FreeDays
                For Each dr In DtnTable.Rows
                    Select Case CnSize
                        Case "20"
                            Amount = Long.Parse(dr("Amount20").ToString)
                        Case "40"
                            Amount = Long.Parse(dr("Amount40").ToString)
                        Case "45"
                            Amount = Long.Parse(dr("Amount45").ToString)
                    End Select

                    If Totaldays > 0 Then
                        If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                            TotalAmt += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                            Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                            If Totaldays < 1 Then
                                Totaldays = 0
                            End If
                        Else
                            TotalAmt += (Totaldays * Amount)
                            Totaldays = 0
                            Exit For
                        End If
                    End If
                Next
                Msg = ""
            Else
                Msg = "No Valid Rate For CnType " & CnType
            End If

            If IsChaildBL = True Then
                TotalAmt = 0
            End If
            If TotalAmt < 1 Then
                TotalAmt = 0
            End If

            If TotalAmt > 0 Then

                If Table.Rows.Count > 0 Then
                    If Long.Parse(Table.Rows(0).Item("dFreeDays").ToString) > 0 Then
                        FreeDays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                        Totaldays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                        For Each dr In DtnTable.Rows
                            Select Case CnSize
                                Case "20"
                                    Amount = Long.Parse(dr("Amount20").ToString)
                                Case "40"
                                    Amount = Long.Parse(dr("Amount40").ToString)
                                Case "45"
                                    Amount = Long.Parse(dr("Amount45").ToString)
                            End Select
                            If Totaldays > 0 Then
                                If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                    AmountDiscount += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                    Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                    If Totaldays < 1 Then
                                        Totaldays = 0
                                    End If
                                Else
                                    AmountDiscount += (Totaldays * Amount)
                                    Totaldays = 0
                                    Exit For
                                End If
                            End If
                        Next
                    End If

                    If AmountDiscount > 0 Then
                        If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = False Then
                            TotalAmt -= AmountDiscount
                            AmountDiscount = 0
                            If TotalAmt < 1 Then
                                TotalAmt = 0
                            End If
                        End If
                    End If

                    If AmountDiscount > TotalAmt Then
                        AmountDiscount = TotalAmt
                    End If

                    Try
                        AmountDiscount += (Long.Parse(Table.Rows(0).Item("dAmount").ToString) / TotalCntrs)
                    Catch ex As Exception
                        Msg += " " & Left(ex.ToString, 100)
                    End Try

                    If Not IsDBNull(Table.Rows(0).Item("dPercent")) Then
                        If Long.Parse(Table.Rows(0).Item("dPercent").ToString) > 0 Then
                            Try
                                AmountDiscount += Long.Parse((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)
                            Catch ex As Exception
                                Msg += " " & Left(ex.ToString, 100)
                            End Try
                        End If
                    End If
                End If
            End If

            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            detentionNet = TotalAmt - AmountDiscount

            dr = ResultTable.NewRow
            dr("CntrNo") = CntrNo
            dr("FreeDays") = FreeDays
            dr("TotalDays") = Totaldays
            If LCLCount = 0 Then
                LCLCount = 1
            End If
            If Not lIsChaildBL = True Then
                If LCLCount > 1 And WGTPercent <> 0 Then
                    dr("Detention") = Int((TotalAmt * WGTPercent) / 100) '  Int(TotalAmt / LCLCount)
                    dr("Discount") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100)  ' Int(detentionNet / LCLCount)
                Else
                    dr("Detention") = Int(TotalAmt / LCLCount)
                    dr("Discount") = Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int(detentionNet / LCLCount)
                End If
            Else
                dr("Detention") = 0
                dr("Discount") = 0
                dr("DiscountCntr") = 0
                dr("DetentionNet") = 0
            End If
            dr("Message") = Msg
            If Table.Rows.Count > 0 Then
                If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = True Then
                    dr("OriginFreedays") = OriginFreedays
                Else
                    If NullToValue(Table.Rows(0).Item("dFreeDays"), 0) > 0 Then
                        dr("OriginFreedays") = nFrreDaysNoDiscount
                    Else
                        dr("OriginFreedays") = OriginFreedays
                    End If
                End If
            Else
                dr("OriginFreedays") = OriginFreedays
            End If
            TotalDetantion += Int((TotalAmt * WGTPercent) / 100) '   Int(TotalAmt / LCLCount)
            TotalDiscount += Int((AmountDiscount * WGTPercent) / 100)  ' Int(AmountDiscount / LCLCount)





            ResultTable.Rows.Add(dr)
            Return ResultTable
        Else
            ds = StoredProcedures.SP_DetentionDetailByAll(ImportExport, dFrom.Date, CnType, CurrentShippingLine)
            DtnTable = ds.Tables(0)
            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            If DtnTable.Rows.Count > 0 Then
                FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                If nFrreDaysNoDiscount > 0 Then
                    Totaldays -= (nFrreDaysNoDiscount - FreeDays)
                End If
                OriginFreedays = FreeDays
                For Each dr In DtnTable.Rows
                    Select Case CnSize
                        Case "20"
                            Amount = Long.Parse(dr("Amount20").ToString)
                        Case "40"
                            Amount = Long.Parse(dr("Amount40").ToString)
                        Case "45"
                            Amount = Long.Parse(dr("Amount45").ToString)
                    End Select

                    If Totaldays > 0 Then
                        If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                            TotalAmt += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                            Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                            If Totaldays < 1 Then
                                Totaldays = 0
                            End If
                        Else
                            TotalAmt += (Totaldays * Amount)
                            Totaldays = 0
                            Exit For
                        End If
                    End If
                Next
                Msg = ""
            Else
                Msg = "No Valid Rate For CnType " & CnType
            End If

            If TotalAmt < 1 Then
                TotalAmt = 0
            End If

            If TotalAmt > 0 Then

                If Table.Rows.Count > 0 Then
                    If Long.Parse(Table.Rows(0).Item("dFreeDays").ToString) > 0 Then

                        FreeDays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                        ' Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
                        Totaldays -= (Table.Rows(0).Item("dFreeDays") - DtnTable.Rows(0).Item("DayTo"))
                        For Each dr In DtnTable.Rows
                            Select Case CnSize
                                Case "20"
                                    Amount = Long.Parse(dr("Amount20").ToString)
                                Case "40"
                                    Amount = Long.Parse(dr("Amount40").ToString)
                                Case "45"
                                    Amount = Long.Parse(dr("Amount45").ToString)
                            End Select
                            If Totaldays > 0 Then
                                If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                    AmountDiscount += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                    Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                    If Totaldays < 1 Then
                                        Totaldays = 0
                                    End If
                                Else
                                    AmountDiscount += (Totaldays * Amount)
                                    Totaldays = 0
                                    Exit For
                                End If
                            End If
                        Next
                        If AmountDiscount = 0 Then
                            AmountDiscount = TotalAmt
                        End If
                    End If

                    If AmountDiscount > 0 Then
                        Try
                            DummyBoolean = Boolean.Parse(Table.Rows(0).Item("IsFDaysAsDiscount").ToString)

                        Catch ex As Exception
                            DummyBoolean = False
                        End Try
                        If DummyBoolean = True Then
                            '       AmountDiscount = TotalAmt - AmountDiscount
                        Else
                            '    TotalAmt = (TotalAmt - AmountDiscount)
                            AmountDiscount = 0
                            If TotalAmt < 1 Then
                                TotalAmt = 0
                            End If
                        End If
                    End If

                    If AmountDiscount > TotalAmt Then
                        AmountDiscount = TotalAmt
                    End If

                    Try
                        AmountDiscount += (Long.Parse(Table.Rows(0).Item("dAmount").ToString) / TotalCntrs)
                    Catch ex As Exception
                        Msg += " " & Left(ex.ToString, 100)
                    End Try

                    If Not IsDBNull(Table.Rows(0).Item("dPercent")) Then
                        If Long.Parse(Table.Rows(0).Item("dPercent").ToString) > 0 Then
                            Try
                                AmountDiscount += Long.Parse((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)
                            Catch ex As Exception
                                Msg += " " & Left(ex.ToString, 100)
                            End Try
                        End If
                    End If
                End If
            End If


            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            detentionNet = TotalAmt - AmountDiscount

            dr = ResultTable.NewRow
            dr("CntrNo") = CntrNo
            dr("FreeDays") = FreeDays
            dr("TotalDays") = Totaldays

            If Not lIsChaildBL Then
                If LCLCount > 0 And WGTPercent <> 0 Then
                    dr("Detention") = Int((TotalAmt * WGTPercent) / 100) '  Int(TotalAmt / LCLCount)
                    dr("Discount") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100)  ' Int(detentionNet / LCLCount)
                Else
                    dr("Detention") = Int(TotalAmt / LCLCount)
                    dr("Discount") = Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int(detentionNet / LCLCount)
                End If
            Else
                dr("Detention") = 0
                dr("Discount") = 0
                dr("DiscountCntr") = 0
                dr("DetentionNet") = 0
            End If

            'dr("Detention") = Int(TotalAmt / LCLCount)  ' Int(TotalAmt / LCLCount)
            'dr("Discount") = Int((AmountDiscount * WGTPercent) / 100) ' Int(AmountDiscount / LCLCount)
            'dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100) ' Int(detentionNet / LCLCount)
            dr("Message") = Msg
            If Table.Rows.Count > 0 Then
                If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = True Then
                    dr("OriginFreedays") = OriginFreedays
                Else
                    dr("OriginFreedays") = nFrreDaysNoDiscount
                End If
            Else
                dr("OriginFreedays") = OriginFreedays
            End If

            TotalDetantion += Int((TotalAmt * WGTPercent) / 100)  ' Int(TotalAmt / LCLCount)
            TotalDiscount += Int(AmountDiscount * WGTPercent / 100) ' Int(AmountDiscount / LCLCount)
            ResultTable.Rows.Add(dr)
            Return ResultTable

        End If

    End Function

    Public Sub New()

        Dim columns(1) As DataColumn
        ResultTable = New DataTable

        With ResultTable

            .Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
            .Columns.Add(New DataColumn("TotalDays", System.Type.GetType("System.Int64")))
            .Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
            .Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
            .Columns.Add(New DataColumn("DetentionNet", System.Type.GetType("System.Int64")))
            .Columns.Add(New DataColumn("Message", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("CntrNo", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("OriginFreeDays", System.Type.GetType("System.Int64")))
            .Columns.Add(New DataColumn("DiscountCntr", System.Type.GetType("System.Int64")))
            .Columns.Add(New DataColumn("DamageCost", System.Type.GetType("System.Int64")))
            .Columns.Add(New DataColumn("DamageCurrency", System.Type.GetType("System.String")))

        End With

        columns(0) = ResultTable.Columns("CntrNo")
        ResultTable.PrimaryKey = columns

        Cnn = New SqlConnection(My.Settings.DSN)

    End Sub

    Public ReadOnly Property GetTotaldetention() As Long

        Get
            Return TotalDetantion
        End Get

    End Property

    Public ReadOnly Property GetTotalDiscount() As Long

        Get
            Return TotalDiscount
        End Get

    End Property

    Public ReadOnly Property CntrsTB() As DataTable
        Get
            Return ResultTable
        End Get
    End Property

    Public Function GetDamageCost() As Long

        If TotalDamageCost = 0 Then
            For Each dr As DataRow In ResultTable.Rows
                If NullToValue(dr("DamageCurrency"), "IRR") = "IRR" Then
                    TotalDamageCost += NullToValue(dr("DamageCost"), 0)
                End If
            Next
        End If
        Return (TotalDamageCost)

    End Function

    Public Function GetDamageCostUsd() As Long

        If TotalDamageCost = 0 Then
            For Each dr As DataRow In ResultTable.Rows
                If dr("DamageCurrency") <> "IRR" Then
                    TotalDamageCostusd += dr("DamageCost")
                End If
            Next
        End If
        Return (TotalDamageCost)

    End Function
    Public Property IsMasterBL() As Boolean
        Get
            Return lIsMasterBL
        End Get
        Set(ByVal value As Boolean)
            lIsMasterBL = value
            IsBlSetFromOutSide = True
        End Set
    End Property

    Public Property IsChaildBL() As Boolean
        Get
            Return lIsChaildBL
        End Get
        Set(ByVal value As Boolean)
            lIsChaildBL = value
        End Set
    End Property

    Private Sub SetBlMasterChild(ByVal BLID As String)

        Dim Tb As New DataTable
        Dim lResult As Boolean
        Dim BLNo As String
        Dim Line As String

        TableBySql("Select Line , BLNO , isnull(FrtCoverdBlNo,'') as Coverd From Tb_InwardBls where ID = '" & BLID.ToString & "'", Tb, lResult)

        If Tb.Rows.Count > 0 Then
            Line = Tb.Rows(0).Item("Line")
            BLNo = Tb.Rows(0).Item("BLNO")
            If Tb.Rows(0).Item("Coverd") = "" Then
                IsChaildBL = False
            Else
                IsChaildBL = True
            End If
        End If

        Tb = New DataTable
        TableBySql("Select BLNO , isnull(FrtCoverdBlNo,'') as Coverd From Tb_InwardBls where FrtCoverdBlNo = '" & BLNo & "' and Line = '" & Line & "'", Tb, lResult)
        If Tb.Rows.Count > 0 Then
            lIsMasterBL = True
        Else
            lIsMasterBL = False
        End If


    End Sub

    'New one for Detention calculation - 21'June'2018
    Public Function DetentionPerCntr(ByVal InwardOutward As String, ByVal ImportExport As String, _
                                              ByVal CnSize As String, _
                                              ByVal CnType As String, _
                                              ByVal dFrom As DateTime, _
                                              ByVal dTo As DateTime, _
                                              ByVal BLID As String, ByVal LCLCount As Int16, ByVal WGTPercent As Double, Optional ByVal CntrNo As String = "na")

        ' 0 Success 
        ' 1 No valid rate 

        'Dim ImportExport As String = "I"
        'Dim CnSize As String = "20"
        'Dim CnType As String = "HC"
        'Dim dFrom As DateTime = Now
        'Dim dTo As DateTime = DateAdd(DateInterval.Day, 20, Now)
        'Dim BLID As String = "4144cb80-96ab-473e-acf9-04804561f197"


        Dim DtnTable As New DataTable
        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim adapter2 As New SqlDataAdapter
        Dim dr As DataRow
        Dim nFrreDaysNoDiscount As Int16 = 0
        Dim TotalCntrs As Long

        Dim Msg As String = ""
        Dim sSql As String

        Dim FreeDays As Long
        Dim Totaldays As Long
        Dim TotalAmt As Long
        Dim Amount As Long
        Dim detentionNet As Long
        Dim AmountDiscount As Double
        Dim ds As New DataSet
        Dim OriginFreedays As Long
        Dim DSCNT As New DataTable

        Dim DummyBoolean As Boolean
        Dim DetentionID As Guid
        Dim lResult As Boolean
        Dim NewDays As Long
        Dim NewDays1 As Long
        Dim DifDays As Long
        Dim DA As New SqlDataAdapter
        Dim ExportDetnCur As String


        If lIsMasterBL = True Then
            WGTPercent = 100
            LCLCount = 1
        End If

        dFrom = dFrom.Date
        dTo = dTo.Date

        ResultTable.Clear()
        ResultTable.AcceptChanges()

        If InwardOutward = "Inward" Then
            If ImportExport = "I" Or ImportExport = "ET" Then
                sSql = "Select Count(*) as TotalCntrs From Tb_InwardCntrs Where BLID = @BLID"
            Else
                sSql = "Select Count(*) As TotalCntrs From  Tb_OutwardCntrs Where BLID = @BLID"
            End If
        ElseIf InwardOutward = "Outward" Then
            If ImportExport = "E" Or ImportExport = "ET" Then
                sSql = "Select Count(*) as TotalCntrs From Tb_OutwardCntrs Where BLID = @BLID"
            Else
                sSql = "Select Count(*) As TotalCntrs From  Tb_InwardCntrs Where BLID = @BLID"
            End If
        End If

        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@BLID", BLID)
        adapter2 = New SqlDataAdapter(Cmd)
        adapter2.Fill(Table)
        TotalCntrs = NullToValue(Table.Rows(0).Item(0), 1)

        Table = New DataTable
        If InwardOutward = "Inward" Then
            If ImportExport = "I" Or ImportExport = "ET" Then
                sSql = "Select * From TB_InwardDiscount Where BLID = @BLID"
            Else
                sSql = "Select * From TB_OutwardDiscount Where BLID = @BLID"
            End If
        ElseIf InwardOutward = "Outward" Then
            If ImportExport = "E" Or ImportExport = "ET" Then
                sSql = "Select * From TB_OutwardDiscount Where BLID = @BLID"
            Else
                sSql = "Select * From TB_InwardDiscount Where BLID = @BLID"
            End If
        End If

        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@BLID", BLID)
        adapter2 = New SqlDataAdapter(Cmd)
        adapter2.Fill(Table)

        If Table.Rows.Count > 0 Then
            If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = False Then
                If Table.Rows(0).Item("dFreeDays") > 0 Then
                    nFrreDaysNoDiscount = Table.Rows(0).Item("dFreeDays")

                End If
            End If
            DetentionID = NullToValue(Table.Rows(0).Item("DetentionID"), Guid.Empty)
        End If

        If IsBlSetFromOutSide = False Then
            SetBlMasterChild(BLID)
        End If
        If dFrom.Date >= "12/06/2021" Then
            ExportDetnCur = "USD"
        Else
            ExportDetnCur = "IRR"
        End If

        If CurrentCompany.DetentionBySlab = True Then
            If DetentionID = Guid.Empty Then
                Cnn.Open()
                Cmd = New SqlCommand("SP_DetentionDetailByAllNew")
                With Cmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cnn
                    .Parameters.AddWithValue("@ImportExport", ImportExport)
                    .Parameters.AddWithValue("@Date", dFrom.Date)
                    .Parameters.AddWithValue("@CnType", CnType)
                    .Parameters.AddWithValue("@Line", CurrentShippingLine)
                    'New Param code added 
                    .Parameters.AddWithValue("@Currency", IIf(InwardOutward = "Inward", NullToValue(FrmInwardInvoice.DetnCurrency, "IRR"), ExportDetnCur))

                End With
                DA.SelectCommand = Cmd
                DA.Fill(ds)

                'ds = StoredProcedures.SP_DetentionDetailByAll((ImportExport, dFrom.Date, CnType, "LSL")
                DtnTable = ds.Tables(0)
            Else
                TableBySql("SP_DetentionDetailIDCnType '" & DetentionID.ToString & "' , '" & CnType & "'", DtnTable, lResult)
            End If

            Cnn.Close()

            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
            If Not CurrentShippingLine = "RUS" And Not CurrentShippingLine = "FDR" And Not CurrentShippingLine = "ABLE" And Not CurrentShippingLine = "OTLO" And Not CurrentShippingLine = "LEX" And Not CurrentShippingLine = "AXL" Then
                If DtnTable.Rows.Count > 0 Then
                    If nFrreDaysNoDiscount > 0 Then
                        FreeDays = nFrreDaysNoDiscount
                    Else
                        FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                    End If
                    OriginFreedays = FreeDays
                    For Each dr In DtnTable.Rows
                        Select Case CnSize
                            Case "20"
                                Amount = Long.Parse(dr("Amount20").ToString)
                            Case "40"
                                Amount = Long.Parse(dr("Amount40").ToString)
                            Case "45"
                                Amount = Long.Parse(dr("Amount45").ToString)
                        End Select

                        If Totaldays > 0 Then
                            If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                TotalAmt += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                If Totaldays < 1 Then
                                    Totaldays = 0
                                End If
                            Else
                                TotalAmt += (Totaldays * Amount)
                                Totaldays = 0
                                Exit For
                            End If
                        End If
                    Next
                    Msg = ""
                Else
                    Msg = "No Valid Rate For CnType " & CnType
                End If

                If IsChaildBL = True Then
                    TotalAmt = 0
                End If
                If TotalAmt < 1 Then
                    TotalAmt = 0
                End If

                If TotalAmt > 0 Then

                    If Table.Rows.Count > 0 Then
                        If Long.Parse(Table.Rows(0).Item("dFreeDays").ToString) > 0 Then
                            FreeDays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                            Totaldays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                            For Each dr In DtnTable.Rows
                                Select Case CnSize
                                    Case "20"
                                        Amount = Long.Parse(dr("Amount20").ToString)
                                    Case "40"
                                        Amount = Long.Parse(dr("Amount40").ToString)
                                    Case "45"
                                        Amount = Long.Parse(dr("Amount45").ToString)
                                End Select
                                If Totaldays > 0 Then
                                    If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                        AmountDiscount += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                        Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                        If Totaldays < 1 Then
                                            Totaldays = 0
                                        End If
                                    Else
                                        AmountDiscount += (Totaldays * Amount)
                                        Totaldays = 0
                                        Exit For
                                    End If
                                End If
                            Next
                        End If

                        If AmountDiscount > 0 Then
                            If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = False Then
                                TotalAmt -= AmountDiscount
                                AmountDiscount = 0
                                If TotalAmt < 1 Then
                                    TotalAmt = 0
                                End If
                            End If
                        End If

                        If AmountDiscount > TotalAmt Then
                            AmountDiscount = TotalAmt
                        End If

                        Try
                            AmountDiscount += (Long.Parse(Table.Rows(0).Item("dAmount").ToString) / TotalCntrs)
                        Catch ex As Exception
                            Msg += " " & Left(ex.ToString, 100)
                        End Try

                        If Not IsDBNull(Table.Rows(0).Item("dPercent")) Then
                            If Long.Parse(Table.Rows(0).Item("dPercent").ToString) > 0 Then
                                Try
                                    AmountDiscount += ((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)
                                    '  AmountDiscount = Long.Parse(AmountDiscount)
                                    'AmountDiscount = Long.Parse((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)

                                    ''  AmountDiscount += Long.Parse((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100) appu lida case
                                Catch ex As Exception
                                    Msg += " " & Left(ex.ToString, 100)
                                End Try
                            End If
                        End If
                    End If
                End If

                Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

                detentionNet = TotalAmt - AmountDiscount
            Else
                If DtnTable.Rows.Count > 0 Then
                    If nFrreDaysNoDiscount > 0 Then
                        FreeDays = nFrreDaysNoDiscount
                    Else
                        FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                    End If
                    OriginFreedays = FreeDays
                    For Each dr In DtnTable.Rows
                        Select Case CnSize
                            Case "20"
                                Amount = Long.Parse(dr("Amount20").ToString)
                            Case "40"
                                Amount = Long.Parse(dr("Amount40").ToString)
                            Case "45"
                                Amount = Long.Parse(dr("Amount45").ToString)
                        End Select

                        ''new jumper logic
                        If Totaldays > 0 Then
                            If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                NewDays = (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1)
                            Else
                                NewDays = Totaldays
                            End If

                            If FreeDays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                NewDays1 = (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1)
                            Else
                                NewDays1 = FreeDays
                            End If


                            DifDays = NewDays - NewDays1
                            If DifDays > 0 Then
                                TotalAmt += DifDays * Amount
                            End If

                            Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                            FreeDays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)

                            ''discount

                            If Totaldays < 0 Then
                                Totaldays = 0
                            End If

                            If FreeDays < 0 Then
                                FreeDays = 0
                            End If
                        End If

                    Next

                    ''discount


                    'If AmountDiscount > 0 Then
                    '    If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = False Then
                    '        TotalAmt -= AmountDiscount
                    '        AmountDiscount = 0
                    '        If TotalAmt < 1 Then
                    '            TotalAmt = 0
                    '        End If
                    '    End If
                    'End If

                    'If AmountDiscount > TotalAmt Then
                    '    AmountDiscount = TotalAmt
                    'End If
                    If Table.Rows.Count > 0 Then
                        Try
                            AmountDiscount += (Long.Parse(Table.Rows(0).Item("dAmount").ToString) / TotalCntrs)
                        Catch ex As Exception
                            Msg += " " & Left(ex.ToString, 100)
                        End Try

                        If Not IsDBNull(Table.Rows(0).Item("dPercent")) Then
                            If Long.Parse(Table.Rows(0).Item("dPercent").ToString) > 0 Then
                                Try
                                    AmountDiscount += ((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)
                                Catch ex As Exception
                                    Msg += " " & Left(ex.ToString, 100)
                                End Try
                            End If
                        End If
                    End If
                Else
                    Msg = "No Valid Rate For CnType " & CnType
                End If

                If IsChaildBL = True Then
                    TotalAmt = 0
                End If
                If TotalAmt < 1 Then
                    TotalAmt = 0
                End If
                Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
                FreeDays = OriginFreedays
                detentionNet = TotalAmt - AmountDiscount
            End If
            dr = ResultTable.NewRow
            dr("CntrNo") = CntrNo
            dr("FreeDays") = FreeDays
            dr("TotalDays") = Totaldays
            If LCLCount = 0 Then
                LCLCount = 1
            End If
            If Not lIsChaildBL = True Then
                If LCLCount > 1 And WGTPercent <> 0 Then
                    dr("Detention") = Int((TotalAmt * WGTPercent) / 100) '  Int(TotalAmt / LCLCount)
                    dr("Discount") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100)  ' Int(detentionNet / LCLCount)
                Else
                    dr("Detention") = Int(TotalAmt / LCLCount)
                    dr("Discount") = Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int(detentionNet / LCLCount)
                End If
            Else
                dr("Detention") = 0
                dr("Discount") = 0
                dr("DiscountCntr") = 0
                dr("DetentionNet") = 0
            End If
            dr("Message") = Msg
            If Table.Rows.Count > 0 Then
                If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = True Then
                    dr("OriginFreedays") = OriginFreedays
                Else
                    If NullToValue(Table.Rows(0).Item("dFreeDays"), 0) > 0 Then
                        dr("OriginFreedays") = nFrreDaysNoDiscount
                    Else
                        dr("OriginFreedays") = OriginFreedays
                    End If
                End If
            Else
                dr("OriginFreedays") = OriginFreedays
            End If
            TotalDetantion += Int((TotalAmt * WGTPercent) / 100) '   Int(TotalAmt / LCLCount)
            'TotalDetantion += Int((TotalAmt * Convert.ToInt64(WGTPercent)) / 100) '   Int(TotalAmt / LCLCount)
            TotalDiscount += (AmountDiscount * WGTPercent) / 100  ' Int(AmountDiscount / LCLCount)





            ResultTable.Rows.Add(dr)
            Return ResultTable
        Else
            ds = StoredProcedures.SP_DetentionDetailByAll(ImportExport, dFrom.Date, CnType, CurrentShippingLine)
            DtnTable = ds.Tables(0)
            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            If DtnTable.Rows.Count > 0 Then
                FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                If nFrreDaysNoDiscount > 0 Then
                    Totaldays -= (nFrreDaysNoDiscount - FreeDays)
                End If
                OriginFreedays = FreeDays
                For Each dr In DtnTable.Rows
                    Select Case CnSize
                        Case "20"
                            Amount = Long.Parse(dr("Amount20").ToString)
                        Case "40"
                            Amount = Long.Parse(dr("Amount40").ToString)
                        Case "45"
                            Amount = Long.Parse(dr("Amount45").ToString)
                    End Select

                    If Totaldays > 0 Then
                        If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                            TotalAmt += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                            Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                            If Totaldays < 1 Then
                                Totaldays = 0
                            End If
                        Else
                            TotalAmt += (Totaldays * Amount)
                            Totaldays = 0
                            Exit For
                        End If
                    End If
                Next
                Msg = ""
            Else
                Msg = "No Valid Rate For CnType " & CnType
            End If

            If TotalAmt < 1 Then
                TotalAmt = 0
            End If

            If TotalAmt > 0 Then

                If Table.Rows.Count > 0 Then
                    If Long.Parse(Table.Rows(0).Item("dFreeDays").ToString) > 0 Then

                        FreeDays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                        ' Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
                        Totaldays -= (Table.Rows(0).Item("dFreeDays") - DtnTable.Rows(0).Item("DayTo"))
                        For Each dr In DtnTable.Rows
                            Select Case CnSize
                                Case "20"
                                    Amount = Long.Parse(dr("Amount20").ToString)
                                Case "40"
                                    Amount = Long.Parse(dr("Amount40").ToString)
                                Case "45"
                                    Amount = Long.Parse(dr("Amount45").ToString)
                            End Select
                            If Totaldays > 0 Then
                                If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                    AmountDiscount += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                    Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                    If Totaldays < 1 Then
                                        Totaldays = 0
                                    End If
                                Else
                                    AmountDiscount += (Totaldays * Amount)
                                    Totaldays = 0
                                    Exit For
                                End If
                            End If
                        Next
                        If AmountDiscount = 0 Then
                            AmountDiscount = TotalAmt
                        End If
                    End If

                    If AmountDiscount > 0 Then
                        Try
                            DummyBoolean = Boolean.Parse(Table.Rows(0).Item("IsFDaysAsDiscount").ToString)

                        Catch ex As Exception
                            DummyBoolean = False
                        End Try
                        If DummyBoolean = True Then
                            '       AmountDiscount = TotalAmt - AmountDiscount
                        Else
                            '    TotalAmt = (TotalAmt - AmountDiscount)
                            AmountDiscount = 0
                            If TotalAmt < 1 Then
                                TotalAmt = 0
                            End If
                        End If
                    End If

                    If AmountDiscount > TotalAmt Then
                        AmountDiscount = TotalAmt
                    End If

                    Try
                        AmountDiscount += (Long.Parse(Table.Rows(0).Item("dAmount").ToString) / TotalCntrs)
                    Catch ex As Exception
                        Msg += " " & Left(ex.ToString, 100)
                    End Try

                    If Not IsDBNull(Table.Rows(0).Item("dPercent")) Then
                        If Long.Parse(Table.Rows(0).Item("dPercent").ToString) > 0 Then
                            Try
                                AmountDiscount += Long.Parse((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)
                            Catch ex As Exception
                                Msg += " " & Left(ex.ToString, 100)
                            End Try
                        End If
                    End If
                End If
            End If


            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            detentionNet = TotalAmt - AmountDiscount

            dr = ResultTable.NewRow
            dr("CntrNo") = CntrNo
            dr("FreeDays") = FreeDays
            dr("TotalDays") = Totaldays

            If Not lIsChaildBL Then
                If LCLCount > 0 And WGTPercent <> 0 Then
                    dr("Detention") = Int((TotalAmt * WGTPercent) / 100) '  Int(TotalAmt / LCLCount)
                    dr("Discount") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100)  ' Int(detentionNet / LCLCount)
                Else
                    dr("Detention") = Int(TotalAmt / LCLCount)
                    dr("Discount") = Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int(detentionNet / LCLCount)
                End If
            Else
                dr("Detention") = 0
                dr("Discount") = 0
                dr("DiscountCntr") = 0
                dr("DetentionNet") = 0
            End If

            'dr("Detention") = Int(TotalAmt / LCLCount)  ' Int(TotalAmt / LCLCount)
            'dr("Discount") = Int((AmountDiscount * WGTPercent) / 100) ' Int(AmountDiscount / LCLCount)
            'dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100) ' Int(detentionNet / LCLCount)
            dr("Message") = Msg
            If Table.Rows.Count > 0 Then
                If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = True Then
                    dr("OriginFreedays") = OriginFreedays
                Else
                    dr("OriginFreedays") = nFrreDaysNoDiscount
                End If
            Else
                dr("OriginFreedays") = OriginFreedays
            End If

            TotalDetantion += Int((TotalAmt * WGTPercent) / 100)  ' Int(TotalAmt / LCLCount)
            TotalDiscount += Int(AmountDiscount * WGTPercent / 100) ' Int(AmountDiscount / LCLCount)
            ResultTable.Rows.Add(dr)
            Return ResultTable

        End If

    End Function

End Class
