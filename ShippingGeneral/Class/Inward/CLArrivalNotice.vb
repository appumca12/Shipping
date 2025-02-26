Imports OrmLib
Imports ShippingBiz

Public Class CLArrivalNotice

    Enum Calstatus
        NoMasterData
        NoDetailData
    End Enum

    Private Dm As DataManager
    Private DS As DataSet
    Private TBCns As DataTable
    Private TBMaster As DataTable
    Private TbError As DataTable
    Private TBDetails As DataTable
    Private Voyage As TB_Voyage
    Private BlDataRow As DataRow
    Private Arrival As DateTime
    Private BLID As String
    Private BLS As TB_InwardBLS
    Private SOF As TB_SOF
    Private Vsl As TB_Vessels
    Private ExTHC As Double
    Private ExFrt As Double
    Private TTLTax As Long
    Private TTLToll As Long
    Private AdditionalTax As Long
    Private IsCollectCharges As String = "N"
    Private TBBLCharges As DataTable
    Private CalBase As CLCalculationBase
    Private ClientID As Guid
    Private IsLCL As Boolean
    Private TBChaild As New DataTable
    Private IsMaster As Boolean = False

    Public Sub GenArrivalNotice(ByVal BlDr As DataRow, ByVal CalDate As DateTime, ByVal Voy As TB_Voyage, Optional ByVal CallForArrival As Boolean = False)

        Dim xdrs() As DataRow
        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim sSql As String

        If TBDetails Is Nothing Then
            InitTemp()
            Me.Voyage = Voy
            Dm = New DataManager(My.Settings.DSN)
            Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
            Vsl = Dm.GetTB_Vessels
        End If

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Voy.ID, MatchType.Exact)
        SOF = Dm.GetTB_SOF

        ExTHC = Voy.ExchangeThc
        ExFrt = Voy.ExchangeFrt

        Me.BlDataRow = BlDr
        Me.Arrival = SOF.DschCmpl


        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, BlDr("Line"), MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, BlDr("BLNO"), MatchType.Exact)
        BLS = Dm.GetTB_InwardBLS
 
        BLID = BLS.ID.ToString
        ClientID = BLS.ClientID

        sSql = "Select ID From Tb_InwardBls Where  FrtCoverdBLNO = '" & BLS.BlNo & "'"
        TableBySql(sSql, TBChaild, lResult)

        If BLS.FrtCoverdBlNo <> "" Then
            Exit Sub
        End If
        

        sSql = "Select dbo.FC_InwardBLIsLCL('" & BLS.ID.ToString & "')"
        TableBySql(sSql, TB, lResult)

        If TB.Rows(0).Item(0) = "Y" Or TBChaild.Rows.Count > 0 Then
            IsLCL = True
        Else
            IsLCL = False
        End If

        If TBChaild.Rows.Count > 0 Then
            IsMaster = True
        End If
 
        If PrepareCntrsData(BLS.ID) Then
            CalBase = New CLCalculationBase
            Try
                CalculateCharges(CalDate, BlDr("POD"), BlDr("Line"), BLS.FCLType)
            Catch ex As Exception
                CalculateCharges(CalDate, BlDr("POD"), BlDr("Line"), BLS.FCLType)
            End Try
            GenMasterData(BlDr)
            IsCollectCharges = "N"
            If CallForArrival = True Then
                AddBlCharges(BlDr, BLS.ID)
                xdrs = TBMaster.Select("BlNo = '" & BLS.BlNo & "'")
                If IsCollectCharges = "Y" Then
                    xdrs(0).Item("IsCollectCharges") = "جهت چک کردن برای هزینه های دلاری قبل از اقدام برای دریافت ترخیصیه، لطفا با واحد ترخیصیه این شرکت تماس بگیرید."
                Else
                    xdrs(0).Item("IsCollectCharges") = ""
                End If
            Else
                AddCnCharges(BlDr, BLS.ID)
                TBMaster.Rows(0).Item("IsCollectCharges") = ""
            End If
            CalTax(BLS.BlNo)
        End If
        TBMaster.TableName = "xx"

    End Sub

    Private Function PrepareCntrsData(ByVal BLID As Guid) As Boolean

        Dim sSql As String = "SP_InwardCntrsForArr '" & BLID.ToString & "'"
        Dim Ds As DataSet
        Dim Ans As Boolean = True

        Ds = StoredProcedures.SP_InwardCntrsForArr(BLID.ToString)

        If Ds.Tables(0).Rows.Count = 0 Then
            Ans = False
        Else
            TBCns = Ds.Tables(0).Copy
        End If

        Return Ans

    End Function

    Private Function CalculateCharges(ByVal CalDate As Date, ByVal Port As String, ByVal Line As String, ByVal FCLType As String) As Calstatus

        Dim Ds As DataSet
        Dim Mstr As New DataTable
        Dim Detail As New DataTable
        Dim NewDr As DataRow
        Dim dr As DataRow
        Dim Cn As DataRow
        Dim Dummy As Double
        Dim Dv As DataView
        Dim nTax As Double
        Dim nToll As Double
        Dim nDOTax As Double
        Dim nDOToll As Double
        Dim nEPLTax As Double
        Dim nEPLToll As Double
        Dim nTILTax As Double
        Dim nTILToll As Double
        Dim lResult2 As Boolean
        Dim TB As New DataTable


        Ds = StoredProcedures.SP_ChgLevelAllByDateClientID(CalDate.Date, ClientID.ToString)
 
        If Ds.Tables(0).Rows.Count = 0 Then
            Return Calstatus.NoMasterData
        End If

        If Ds.Tables(1).Rows.Count = 0 Then
            Return Calstatus.NoDetailData
        End If

        Mstr = Ds.Tables(0)
        Detail = Ds.Tables(1)

        If FCLType.Substring(1, 1) <> "L" And TBChaild.Rows.Count = 0 Then
            For Each dr In Mstr.Rows
                If Mid(dr("BaseOn"), 1, 1) = "L" Then
                    dr.Delete()
                End If
            Next
            Mstr.AcceptChanges()
        End If

        If FCLType.Substring(1, 1) = "L" Then
            For Each dr In Mstr.Rows
                If dr("ChargeItem") = "DROPW" Or dr("ChargeItem") = "TIL" Then
                    dr.Delete()
                End If
            Next
            Mstr.AcceptChanges()
        End If

        If IsLCL = True And Not FCLType.Substring(1, 1) = "L" Then
            For Each dr In Mstr.Rows
                If dr("ChargeItem") = "SPBL" Then
                    dr.Delete()
                End If
            Next
            Mstr.AcceptChanges()
        End If

        TableBySql("Select dbo.FC_InwardBLIsImco ('" & BLS.ID.ToString & "')", TB, lResult2)
        If lResult2 = True Then
            If TB.Rows(0).Item(0) = "N" Then
                For Each dr In Mstr.Rows
                    If dr("ChargeItem") = "DGM" Then
                        dr.Delete()
                    End If
                Next
                Mstr.AcceptChanges()
            End If
        End If

        For Each dr In Mstr.Rows
            'If dr("ChargeItem") = "STR" Then
            '    Beep()
            'End If
            CalBase.GetTaxDutyInward(BLS.ID, dr("ChargeItem"))
            If (dr("ChargeItem") = "DO") Then
                nDOTax = CalBase.Tax
                nDOToll = CalBase.Duty
            End If
            If (dr("ChargeItem") = "EPL") Then
                nEPLTax = CalBase.Tax
                nEPLToll = CalBase.Duty
            End If
            If (dr("ChargeItem") = "TIL") Then
                nTILTax = CalBase.Tax
                nTILToll = CalBase.Duty
            End If
            If dr("ImportExport") <> "E" And _
              (dr("Line") = "***" Or dr("Line") = Line) And _
              (dr("Port") = "***" Or dr("Port") = Port) Then
                If Left(dr("BaseOn"), 1) = "B" Then
                    If (dr("BaseOn") = "BS" And BLS.FrtCoverdBlNo <> "") Or dr("BaseOn") = "B" Or (dr("BaseOn") = "BL" And IsLCL = True) Or (dr("BaseOn") = "BF" And IsLCL = False) Or (dr("BaseOn") = "BS" And IsMaster = True) Then
                        NewDr = TBDetails.NewRow
                        NewDr("BlNo") = BLS.BlNo
                        NewDr("ChargeItem") = dr("ChargeItem")
                        NewDr("Meaning") = dr("Meaning")
                        NewDr("MeaningF") = dr("MeaningF")
                        NewDr("CurCode") = dr("CurCode")
                        If TBChaild.Rows.Count > 0 Then
                            Dummy = (TBChaild.Rows.Count * dr("DefaultAmount"))
                        Else
                            Dummy = dr("DefaultAmount")
                        End If

                        NewDr("ActualAmount") = Dummy
                        NewDr("Seq") = dr("Seq")
                        NewDr("IsDeposit") = dr("IsDeposit")
                        If dr("IsDeposit") Then
                            NewDr("DepositAmount") = GetExchage(dr("DefaultAmount"), dr("CurCode"), dr("ChargeItem"))
                            NewDr("Condition") = "یه صورت سپرده"
                        Else
                            If dr("Condition") = "T" Then
                                NewDr("ConditionalAmount") = GetExchage(Dummy, dr("CurCode"), dr("ChargeItem"))
                            Else
                                NewDr("MandatoryAmount") = GetExchage(Dummy, dr("CurCode"), dr("ChargeItem"))
                            End If
                            NewDr("Condition") = IIf(dr("Condition") = "T", "در صورت خروج از محوطه", "هزینه های عمومی")
                        End If
                        nTax = CalBase.Tax
                        If nTax > 0 Then
                            If NewDr("ConditionalAmount") > 0 Then
                                NewDr("ConditionTax") = (NewDr("ConditionalAmount") * nTax / 100)
                            End If
                            If NewDr("MandatoryAmount") > 0 Then
                                NewDr("MandatoryTax") = (NewDr("MandatoryAmount") * nTax / 100)
                            End If
                        End If
                        nToll = CalBase.Duty
                        If nToll > 0 Then
                            If NewDr("ConditionalAmount") > 0 Then
                                NewDr("ConditionToll") = (NewDr("ConditionalAmount") * nToll / 100)
                            End If
                            If NewDr("MandatoryAmount") > 0 Then
                                NewDr("MandatoryToll") = (NewDr("MandatoryAmount") * nToll / 100)
                            End If
                        End If
                        TBDetails.Rows.Add(NewDr)
                    End If

                Else
                    For Each Cn In TBCns.Rows

                        Dummy = CalAmonut(dr, Detail, Cn)

                        If Dummy = -1 Then
                            NewDr = TbError.NewRow
                            NewDr("BlNo") = BlDataRow("BLNO")
                            NewDr("ChargeItem") = dr("ChargeItem")
                            NewDr("ErrMsg") = "No Valid Rate For Cntr No:" & Cn("CntrNo") & " For Charge Item " & dr("ChargeItem")
                            TbError.Rows.Add(NewDr)
                        Else
                            Dv = New DataView(TBDetails, "BLNo = '" & BlDataRow("BLNO") & "' and ChargeItem = '" & dr("ChargeItem") & "'", "", DataViewRowState.CurrentRows)
                            If Dv.Count = 0 Then
                                NewDr = TBDetails.NewRow
                                NewDr("IsDeposit") = dr("IsDeposit")
                                NewDr("BlNo") = BlDataRow("BLNO")
                                NewDr("ChargeItem") = dr("ChargeItem")
                                NewDr("Meaning") = dr("Meaning")
                                NewDr("MeaningF") = dr("MeaningF")
                                NewDr("CurCode") = dr("CurCode")
                                NewDr("ActualAmount") = Dummy
                                NewDr("Seq") = dr("Seq")
                                If dr("IsDeposit") = True Then
                                    NewDr("DepositAmount") = GetExchage(Dummy, dr("CurCode"), dr("ChargeItem"))
                                    NewDr("Condition") = "یه صورت سپرده"
                                Else
                                    If dr("Condition") = "T" Then
                                        NewDr("ConditionalAmount") = GetExchage(Dummy, dr("CurCode"), dr("ChargeItem"))
                                    Else
                                        NewDr("MandatoryAmount") = GetExchage(Dummy, dr("CurCode"), dr("ChargeItem"))
                                    End If
                                    NewDr("Condition") = IIf(dr("Condition") = "T", "در صورت خروج از محوطه", "هزینه های عمومی")
                                End If
                                'nTax = Val(NullToValue(dr("Tax"), 0))
                                'If nTax = 0 Then
                                '    nTax = GetTaxPercent(dr("ChargeItem"))
                                'End If
                                nTax = CalBase.Tax
                                If nTax > 0 Then
                                    If NewDr("ConditionalAmount") > 0 Then
                                        NewDr("ConditionTax") = (NewDr("ConditionalAmount") * nTax / 100)
                                    End If
                                    If NewDr("MandatoryAmount") > 0 Then
                                        NewDr("MandatoryTax") = (NewDr("MandatoryAmount") * nTax / 100)
                                    End If
                                End If
                                'nToll = Val(NullToValue(dr("Toll"), 0))
                                'If nToll = 0 Then
                                '    nToll = GetTaxPercent(dr("ChargeItem"))
                                'End If
                                nToll = CalBase.Duty
                                If nToll > 0 Then
                                    If NewDr("ConditionalAmount") > 0 Then
                                        NewDr("ConditionToll") = (NewDr("ConditionalAmount") * nToll / 100)
                                    End If
                                    If NewDr("MandatoryAmount") > 0 Then
                                        NewDr("MandatoryToll") = (NewDr("MandatoryAmount") * nToll / 100)
                                    End If
                                End If
                                TBDetails.Rows.Add(NewDr)
                            Else
                                Dv.Item(0).Item("ActualAmount") += Dummy
                                If Dv.Item(0).Item("IsDeposit") = True Then
                                    Dv.Item(0).Item("DepositAmount") += GetExchage(Dummy, dr("CurCode"), dr("ChargeItem"))
                                Else
                                    If dr("IsDeposit") = True Then
                                        Dv.Item(0).Item("DepositAmount") += GetExchage(Dummy, dr("CurCode"), dr("ChargeItem"))
                                    Else
                                        If dr("Condition") = "T" Then
                                            Dv.Item(0).Item("ConditionalAmount") += GetExchage(Dummy, dr("CurCode"), dr("ChargeItem"))
                                        Else
                                            Dv.Item(0).Item("MandatoryAmount") += GetExchage(Dummy, dr("CurCode"), dr("ChargeItem"))
                                        End If
                                        'nTax = Val(NullToValue(dr("Tax"), 0))
                                        'If nTax = 0 Then
                                        '    nTax = GetTaxPercent(dr("ChargeItem"))
                                        'End If
                                        nTax = CalBase.Tax
                                        If nTax > 0 Then
                                            If Dv.Item(0).Item("ConditionalAmount") > 0 Then
                                                Dv.Item(0).Item("ConditionTax") = (Dv.Item(0).Item("ConditionalAmount") * nTax) / 100
                                            End If
                                            If Dv.Item(0).Item("MandatoryAmount") > 0 Then
                                                Dv.Item(0).Item("MandatoryTax") = (Dv.Item(0).Item("MandatoryAmount") * nTax) / 100
                                            End If
                                        End If
                                        'nToll = Val(NullToValue(dr("Toll"), 0))
                                        'If nToll = 0 Then
                                        '    nToll = GetTaxPercent(dr("ChargeItem"))
                                        'End If
                                        nToll = CalBase.Duty
                                        If nToll > 0 Then
                                            If Dv.Item(0).Item("ConditionalAmount") > 0 Then
                                                Dv.Item(0).Item("ConditionToll") = (Dv.Item(0).Item("ConditionalAmount") * nToll) / 100
                                            End If
                                            If Dv.Item(0).Item("MandatoryAmount") > 0 Then
                                                Dv.Item(0).Item("MandatoryToll") = (Dv.Item(0).Item("MandatoryAmount") * nToll) / 100
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next

        Dim Drs() As DataRow
        If IsMaster = True Then
            Drs = TBDetails.Select("ChargeItem='DROPW'")
            For Each dr In Drs
                dr("MandatoryAmount") = 0
                dr("ConditionalAmount") = 0
                dr("ActualAmount") = 0
                dr("MandatoryTax") = 0
                dr("MandatoryToll") = 0
                dr("ConditionToll") = 0
                dr("ConditionTax") = 0
            Next
        End If


        If SOF.Arrival >= "04/08/2020" And SOF.Arrival <= "03/21/2021" Then
            'Dim discountFlag As String
            'discountFlag = "No"
            'If MsgBox("Do You Want To Apply Discount for DO and EPL?", MsgBoxStyle.YesNo, "SAOI Membership Discount") = MsgBoxResult.Yes Then
            '    discountFlag = "Yes"
            'End If

            Drs = TBDetails.Select("ChargeItem='DO'")
            For Each dr In Drs


                If TBCns.Rows.Count > 0 And TBCns.Rows.Count <= 5 Then
                    'dr("ActualAmount") = 4650000
                    dr("ActualAmount") = dr("ActualAmount")
                ElseIf TBCns.Rows.Count >= 6 Then 'And TBCns.Rows.Count <= 20 
                    dr("ActualAmount") = dr("ActualAmount") + ((TBCns.Rows.Count - 5) * 900000)
                    'ElseIf TBCns.Rows.Count >= 21 Then
                    '    dr("ActualAmount") = 21800000
                Else
                    dr("ActualAmount") = 0
                End If
                If FrmInwardInvoice.isDiscount = True Then
                    dr("ActualAmount") = dr("ActualAmount") - (dr("ActualAmount") / 100 * 10)
                End If
                dr("MandatoryAmount") = dr("ActualAmount")
                If nDOTax > 0 Then
                    dr("MandatoryTax") = (dr("MandatoryAmount") * nDOTax) / 100
                End If

                If nDOToll > 0 Then
                    dr("MandatoryToll") = (dr("MandatoryAmount") * nDOToll) / 100
                End If

            Next

            Drs = TBDetails.Select("ChargeItem='EPL'")
            For Each dr In Drs

                Dim Tb1 As New DataTable
                Dim lResult As Boolean
                Dim sSql As String

                sSql = "select count(distinct IMDGCode) from tb_inwardcnspkgs where CntrID in (select id from TB_InwardCntrs  where blid = '" & BLS.ID.ToString & " ')"

                TableBySql(sSql, Tb1, lResult)
                If Tb1.Rows(0).Item(0) > 1 Then
                    dr("ActualAmount") = dr("ActualAmount") + (Tb1.Rows(0).Item(0) * 3850000)
                End If
                If FrmInwardInvoice.isDiscount = True Then
                    dr("ActualAmount") = dr("ActualAmount") - (dr("ActualAmount") / 100 * 10)
                End If
                dr("MandatoryAmount") = dr("ActualAmount")
                If nEPLTax > 0 Then
                    dr("MandatoryTax") = (dr("MandatoryAmount") * nEPLTax) / 100
                End If

                If nEPLToll > 0 Then
                    dr("MandatoryToll") = (dr("MandatoryAmount") * nEPLToll) / 100
                End If

            Next

            Drs = TBDetails.Select("ChargeItem='TIL'")
            For Each dr In Drs

                Dim Tb1 As New DataTable
                Dim lResult As Boolean
                Dim sSql As String

                'sSql = "select count(distinct IMDGCode) from tb_inwardcnspkgs where CntrID in (select id from TB_InwardCntrs  where blid = '" & BLS.ID.ToString & " ')"

                'TableBySql(sSql, Tb1, lResult)
                'If Tb1.Rows(0).Item(0) > 1 Then
                '    dr("ActualAmount") = dr("ActualAmount") + (Tb1.Rows(0).Item(0) * 250000)
                'End If
                If FrmInwardInvoice.isDiscount = True Then
                    dr("ActualAmount") = dr("ActualAmount") - (dr("ActualAmount") / 100 * 10)
                End If
                dr("ConditionalAmount") = dr("ActualAmount")
                If nTILTax > 0 Then
                    dr("ConditionTax") = (dr("ConditionalAmount") * nTILTax) / 100
                End If

                If nTILToll > 0 Then
                    dr("ConditionToll") = (dr("ConditionalAmount") * nTILToll) / 100
                End If

            Next
        End If

        If SOF.Arrival >= "03/21/2021" Then
            'Dim discountFlag As String
            'discountFlag = "No"
            'If MsgBox("Do You Want To Apply Discount for DO and EPL?", MsgBoxStyle.YesNo, "SAOI Membership Discount") = MsgBoxResult.Yes Then
            '    discountFlag = "Yes"
            'End If

            Drs = TBDetails.Select("ChargeItem='DO'")
            For Each dr In Drs


                If TBCns.Rows.Count > 0 And TBCns.Rows.Count <= 5 Then
                    'dr("ActualAmount") = 4650000
                    dr("ActualAmount") = dr("ActualAmount")
                ElseIf TBCns.Rows.Count >= 6 Then
                    dr("ActualAmount") = dr("ActualAmount") + ((TBCns.Rows.Count - 5) * 900000)
                    'ElseIf TBCns.Rows.Count >= 21 Then
                    '    dr("ActualAmount") = 27250000
                Else
                    dr("ActualAmount") = 0
                End If
                If FrmInwardInvoice.isDiscount = True Then
                    dr("ActualAmount") = dr("ActualAmount") - (dr("ActualAmount") / 100 * 20)
                End If
                dr("MandatoryAmount") = dr("ActualAmount")
                If nDOTax > 0 Then
                    dr("MandatoryTax") = (dr("MandatoryAmount") * nDOTax) / 100
                End If

                If nDOToll > 0 Then
                    dr("MandatoryToll") = (dr("MandatoryAmount") * nDOToll) / 100
                End If

            Next

            Drs = TBDetails.Select("ChargeItem='EPL'")
            For Each dr In Drs

                Dim Tb1 As New DataTable
                Dim lResult As Boolean
                Dim sSql As String

                sSql = "select count(distinct IMDGCode) from tb_inwardcnspkgs where CntrID in (select id from TB_InwardCntrs  where blid = '" & BLS.ID.ToString & " ')"

                TableBySql(sSql, Tb1, lResult)
                If Tb1.Rows(0).Item(0) > 1 Then
                    dr("ActualAmount") = dr("ActualAmount") + ((Tb1.Rows(0).Item(0) - 1) * 3850000)
                End If
                If FrmInwardInvoice.isDiscount = True Then
                    dr("ActualAmount") = dr("ActualAmount") - (dr("ActualAmount") / 100 * 20)
                End If
                dr("MandatoryAmount") = dr("ActualAmount")
                If nEPLTax > 0 Then
                    dr("MandatoryTax") = (dr("MandatoryAmount") * nEPLTax) / 100
                End If

                If nEPLToll > 0 Then
                    dr("MandatoryToll") = (dr("MandatoryAmount") * nEPLToll) / 100
                End If

            Next

            Drs = TBDetails.Select("ChargeItem='TIL'")
            For Each dr In Drs

                Dim Tb1 As New DataTable
                Dim lResult As Boolean
                Dim sSql As String

                'sSql = "select count(distinct IMDGCode) from tb_inwardcnspkgs where CntrID in (select id from TB_InwardCntrs  where blid = '" & BLS.ID.ToString & " ')"

                'TableBySql(sSql, Tb1, lResult)
                'If Tb1.Rows(0).Item(0) > 1 Then
                '    dr("ActualAmount") = dr("ActualAmount") + (Tb1.Rows(0).Item(0) * 250000)
                'End If
                If FrmInwardInvoice.isDiscount = True Then
                    dr("ActualAmount") = dr("ActualAmount") - (dr("ActualAmount") / 100 * 20)
                End If
                dr("ConditionalAmount") = dr("ActualAmount")
                If nTILTax > 0 Then
                    dr("ConditionTax") = (dr("ConditionalAmount") * nTILTax) / 100
                End If

                If nTILToll > 0 Then
                    dr("ConditionToll") = (dr("ConditionalAmount") * nTILToll) / 100
                End If

            Next

            'Drs = TBDetails.Select("ChargeItem='DD' and CurCode='USD'")
            'For Each dr In Drs

            '    Dim Tb1 As New DataTable
            '    Dim lResult As Boolean
            '    Dim sSql As String

            '    sSql = "Select DETNrate From TB_Exchange EX , TB_ExchangeDetails EXD  where EX.ID = EXD.MasterID and CurCode = '" & "USD" & "' and ExchangeDate = '" & Format((System.DateTime.Now()), "yyyy-MM-dd") & "'"
            '    TableBySql(sSql, Tb1, lResult)

            '    If lResult = True Then
            '        If Tb1.Rows.Count > 0 Then
            '            If Tb1.Rows(0).Item("DETNrate") > 0 Then
            '                dr("ActualAmount") = dr("ActualAmount") * Tb1.Rows(0).Item("DETNrate")
            '                dr("ConditionalAmount") = dr("ConditionalAmount") * Tb1.Rows(0).Item("DETNrate")
            '                dr("MandatoryAmount") = dr("MandatoryAmount") * Tb1.Rows(0).Item("DETNrate")
            '            Else
            '                MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")

            '            End If
            '        Else
            '            MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")

            '        End If

            '    End If

            'Next

            'Drs = TBDetails.Select("ChargeItem='CVDD' and CurCode='USD'")
            'For Each dr In Drs

            '    Dim Tb1 As New DataTable
            '    Dim lResult As Boolean
            '    Dim sSql As String

            '    sSql = "Select DETNrate From TB_Exchange EX , TB_ExchangeDetails EXD  where EX.ID = EXD.MasterID and CurCode = '" & "USD" & "' and ExchangeDate = '" & Format((System.DateTime.Now()), "yyyy-MM-dd") & "'"
            '    TableBySql(sSql, Tb1, lResult)

            '    If lResult = True Then
            '        If Tb1.Rows.Count > 0 Then
            '            If Tb1.Rows(0).Item("DETNrate") > 0 Then
            '                dr("ActualAmount") = dr("ActualAmount") * Tb1.Rows(0).Item("DETNrate")
            '                dr("ConditionalAmount") = dr("ConditionalAmount") * Tb1.Rows(0).Item("DETNrate")
            '                dr("MandatoryAmount") = dr("MandatoryAmount") * Tb1.Rows(0).Item("DETNrate")
            '            Else
            '                MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")

            '            End If
            '        Else
            '            MessageBox.Show("No DETN Exchange Rate found on " & Format(System.DateTime.Now(), "yyyy-MM-dd").ToString(), "Shipping")

            '        End If

            '    End If

            'Next
        End If

    End Function

    Private Function CalAmonut(ByVal Mstr As DataRow, ByVal Dtls As DataTable, ByVal Cn As DataRow) As Double

        Dim Dv As DataView
        Dim Amount As Double = 0
        Dim sCrt As String
        Dim ByPass As New ArrayList
        Dim lFound As Boolean = False
        Dim AmountCBM As Double = 0
        Dim AmountGW As Double = 0

        sCrt = "(MasterID = '" & Mstr("ID").ToString & "') and ( CnType = '***' or CnType = '" & Cn("CnType") & "' ) and " & _
        "( ShipmentType = '***' or ShipmentType = '" & Cn("BlStatus") & "' ) and " & _
        "( Imco = '***' or Imco = '" & Cn("IsImco") & "' ) and " & _
        "( IsFull = '***' or IsFull = '" & Cn("IsFull") & "' ) and " & _
        "( SOC = '***' or Soc = '" & Cn("SOC") & "' )"

        Try
            If ((Mstr("BaseOn") = "LW" Or Mstr("BaseOn") = "LT") And Cn("LCLCount") = 1) Or (Mstr("BaseOn") = "C" And (Cn("LCLCount") > 1 And IsMaster = False)) Then

                ' If ((Mstr("BaseOn") = "LW" Or Mstr("BaseOn") = "LT") And Cn("LCLCount") = 1) Or (Mstr("BaseOn") = "C" And (Cn("LCLCount") > 1 And IsMaster = False And BLS.FCLType <> "LL")) Then
                Amount = 0
            Else

                Dv = New DataView(Dtls, sCrt, "", DataViewRowState.CurrentRows)
                If Dv.Count > 0 Then
                    Select Case Cn("CnSize")
                        Case "20"
                            Amount = Dv.Item(0).Item("Amount20")
                        Case "40"
                            Amount = Dv.Item(0).Item("Amount40")
                        Case "45"
                            Amount = Dv.Item(0).Item("Amount45")
                    End Select
                    If TBChaild.Rows.Count = 0 Then
                        If Mstr.Item("DividInLCL") = True Then
                            If Mstr("BaseOn") = "C" Then
                                Amount = Amount / Cn("LCLCount")
                            Else
                                'Amount = (Amount / Cn("TTLGW")) * Cn("GW")
                                If Cn("TTLGW") = 0 Or Cn("GW") = 0 Then
                                    Amount = 0
                                Else
                                    Amount = (Amount / Cn("TTLGW")) * Cn("GW")
                                End If


                                'AmountCBM = (Amount / Cn("TTLCBM")) * Cn("CBM")
                                'If AmountGW > AmountCBM Then
                                '    Amount = AmountGW
                                'Else
                                '    Amount = AmountCBM
                                'End If
                            End If
                        End If
                    End If
                Else
                    Amount = -1
                End If
            End If
        Catch ex As Exception
            Amount = -1
        End Try

        Return Amount

    End Function

    Private Sub GenMasterData(ByVal Dr As DataRow)

        Dim NewDr As DataRow
        Dim Names As TB_InwardBlsNames
        Dim Goods As TB_InwardBlsGoods
        Dim NoOfCntrs As String = ""
        Dim Clnt As TB_Clients

        NewDr = TBMaster.NewRow
        NewDr("BlNo") = Dr("BLNo")
        NewDr("reference") = Dr("Reference")
        NewDr("POL") = Dr("POL")
        NewDr("POD") = Dr("POD")
        NewDr("arrival") = Arrival

        NewDr("vesselname") = Vsl.VesselName
        NewDr("voyageno") = Voyage.VoyageNo


        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardBlsNames.Columns.BLID, BLS.ID, MatchType.Exact)
        Names = Dm.GetTB_InwardBlsNames
        If Not Names Is Nothing Then
            NewDr("cnee") = Names.Cnee
            NewDr("Notify") = Names.Notify1
        End If


        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardBlsGoods.Columns.BLID, BLS.ID, MatchType.Exact)
        Goods = Dm.GetTB_InwardBlsGoods

        If Not Goods Is Nothing Then
            NewDr("TW") = Double.Parse(Goods.TTW)
            NewDr("GW") = Double.Parse(Goods.TGW)
            NewDr("NW") = Double.Parse(Goods.TTLNET)
        End If

        InwardCntrsCount(BLS.ID, NoOfCntrs)
        NewDr("totalcontainers") = NoOfCntrs
        NewDr("Status") = BlDataRow("Status")
        TBMaster.Rows.Add(NewDr)

    End Sub

    Private Sub InitTemp()

        Dim Col As DataColumn
        TBDetails = New DataTable

        Col = New DataColumn("BLNO", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("Seq", System.Type.GetType("System.Int32"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("Condition", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("ChargeItem", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("Meaning", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("MeaningF", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("IsDeposit", System.Type.GetType("System.Boolean"))
        Col.DefaultValue = False
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("CurCode", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("ActualAmount", System.Type.GetType("System.Double"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("MandatoryAmount", System.Type.GetType("System.Double"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("ConditionalAmount", System.Type.GetType("System.Double"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("DepositAmount", System.Type.GetType("System.Double"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("MandatoryTax", System.Type.GetType("System.Double"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("ConditionTax", System.Type.GetType("System.Double"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)


        Col = New DataColumn("MandatoryToll", System.Type.GetType("System.Double"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("ConditionToll", System.Type.GetType("System.Double"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        TBMaster = New DataTable
        With TBMaster

            Col = New DataColumn("BlNo", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("Reference", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("Arrival", System.Type.GetType("System.DateTime"))
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("POL", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("POD", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("VesselName", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("VoyageNo", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("Cnee", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("Notify", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("TotalContainers", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("TW", System.Type.GetType("System.Double"))
            Col.DefaultValue = 0
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("GW", System.Type.GetType("System.Double"))
            Col.DefaultValue = 0
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("NW", System.Type.GetType("System.Double"))
            Col.DefaultValue = 0
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("Status", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("IsCollectCharges", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

        End With

        TbError = New DataTable

        With TbError
            Col = New DataColumn("BlNo", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("ErrMsg", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)

            Col = New DataColumn("ChargeItem", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            Col.AllowDBNull = True
            .Columns.Add(Col)
        End With

        TBBLCharges = New DataTable
        With TBBLCharges
            .Columns.Add(New DataColumn("BLNO", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("ChargesItem", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Meaning", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Currency", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Amount", System.Type.GetType("System.Double")))
        End With



    End Sub

    Private Function GetExchage(ByVal Amt As Double, ByVal Cur As String, ByVal ChargeItem As String) As Long


        Dim lRestlt As Boolean
        Dim DocID As New Guid(BLID)
        Dim FRTRate As Double
        Dim THCRate As Double
        Dim DETNRate As Double

        If CalBase Is Nothing Then
            CalBase = New CLCalculationBase
        End If

        CalBase.GetExchangeInward(DocID, Cur, FRTRate, THCRate, DETNRate)

        If Cur = "IRR" Then
            Return Amt
        Else

            If Left(ChargeItem, 3) = "THC" Or ChargeItem = "LCL/DC" Then
                Return Amt * THCRate
            ElseIf (ChargeItem = "DD" Or ChargeItem = "CVDD") And Cur = "USD" Then
                Return Amt * DETNRate
            Else
                Return Amt * FRTRate
            End If
        End If

    End Function

    Private Sub CalculateSyndicateCommission(ByVal ID As String, ByVal BL As String)

        Dim Dr As DataRow
        Dim Additional As Long
        Dim sSql As String
        Dim lResult As Boolean
        Dim Temp As DataTable
        Dim Drs() As DataRow
        Dim Tb As DataTable
        Dim INCPer As Integer

        TableBySql("Select * From TB_Code Where GroupCode = 'CG' and StdCode = 'INC'", Tb, lResult)

        If lResult = True Then
            If Tb.Rows.Count = 0 Then
                Exit Sub
            End If
            INCPer = Val(NullToValue(Tb.Rows(0).Item("NextCode"), ""))
        End If

        sSql = "Select Count(*) from Tb_InwardCntrs Where BLID = '" & ID & "'"
        TableBySql(sSql, Temp, lResult)

        AdditionalTax = 0
        If lResult = True Then
            Select Case Temp.Rows(0).Item(0)
                Case 1 To 5
                    If INCPer > 0 Then
                        AdditionalTax = ((70000 * 4) / 100)
                    End If
                    Additional = 70000
                Case 6 To 50
                    If INCPer > 0 Then
                        AdditionalTax = ((200000 * 4) / 100)
                    End If
                    Additional = 200000
                Case 51 To 999999
                    If INCPer > 0 Then
                        AdditionalTax = ((300000 * 4) / 100)
                    End If
                    Additional = 300000
            End Select

            Drs = TBDetails.Select("BLNO = '" & BL & "' and ChargeItem = 'INC'")
            For Each Dr In Drs
                If Dr("chargeItem") = "INC" Then
                    If Dr("MandatoryAmount") > 0 Then
                        Dr("MandatoryAmount") += Int32.Parse(Additional.ToString)
                        Exit For
                    End If
                    If Dr("ActualAmount") > 0 Then
                        Dr("ActualAmount") += Int32.Parse(Additional.ToString)
                        Exit For
                    End If
                    If Dr("ConditionalAmount") > 0 Then
                        Dr("ConditionalAmount") += Int32.Parse(Additional.ToString)
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub
    Private Sub CalTax(ByVal BLNO As String)

        Dim Dr As DataRow
        Dim CondTax As Long = 0
        Dim ManTax As Long = 0
        Dim CondToll As Long = 0
        Dim ManToll As Long = 0
        Dim NewDr As DataRow
        Dim Drs() As DataRow
        Dim Tax As Double


        Drs = TBDetails.Select("BLNO = '" & BLNO & "'")

        For Each Dr In Drs
            If Dr("MandatoryTax") > 0 Then
                ManTax += Dr("MandatoryTax")
            End If
            If Dr("ConditionTax") > 0 Then
                CondTax += Dr("ConditionTax")
            End If
            If Dr("MandatoryToll") > 0 Then
                ManToll += Dr("Mandatorytoll")
            End If
            If Dr("ConditionToll") > 0 Then
                CondToll += Dr("ConditionToll")
            End If
        Next

        Tax = 0
        If ManTax + CondTax > 0 Then
            If CalBase.Tax + CalBase.Duty = 0 Then
                CalBase.GetTaxDutyDyDate(Now)
                Tax = CalBase.Tax + CalBase.Duty
            Else
                Tax = CalBase.Tax + CalBase.Duty
            End If
            NewDr = TBDetails.NewRow
            NewDr("IsDeposit") = False
            NewDr("BlNo") = BLNO
            NewDr("ChargeItem") = "TAX"
            NewDr("Meaning") = "TAX"
            NewDr("MeaningF") = Tax.ToString & "% بابت مالیات و عوارض ارزش افزوده "
            NewDr("CurCode") = "IRR"
            NewDr("MandatoryAmount") = ManTax + AdditionalTax + ManToll + AdditionalTax
            NewDr("ConditionalAmount") = CondTax + AdditionalTax + CondToll + AdditionalTax
            NewDr("Seq") = 90
            TBDetails.Rows.Add(NewDr)
        End If

    End Sub

    Public Sub AddBlCharges(ByVal BLdatarow As DataRow, ByVal BLID As Guid)

        Dim NewDr As DataRow
        Dim Drs() As DataRow
        Dim Seq As Byte
        Dim Cns As TB_InwardCntrsCollection
        Dim Cn As TB_InwardCntrs
        Dim CnChgs As TB_InwardCntrsChargesCollection
        Dim CnChg As TB_InwardCntrsCharges
        Dim aCharges As New ArrayList
        Dim sChargeName As String
        Dim TTL As Double
        Dim TTax As Double

        Drs = TBDetails.Select("BlNo = '" & BLdatarow("BlNo") & "'", "Seq")
        Seq = 0
        IsCollectCharges = "N"

        For Each dr As DataRow In Drs
            Seq += 1
            dr("Seq") = Seq
        Next

        Seq += 1
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, BLID, MatchType.Exact)
        Cns = Dm.GetTB_InwardCntrsCollection
 
        For Each Cn In Cns
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_InwardCntrsCharges.Columns.CntrID, Cn.ID, MatchType.Exact)
            Dm.QueryCriteria.And(JoinPath.TB_InwardCntrsCharges.Columns.Currency, "IRR", MatchType.Not)

            CnChgs = Dm.GetTB_InwardCntrsChargesCollection
            For Each CnChg In CnChgs
                CalBase.GetTaxDutyInward(BLS.ID, CnChg.ChargesCode)
                If (CnChg.Terms = "C" Or CnChg.ToPlace.Substring(1, 2) = "IR") And Mid(CnChg.ChargesCode, 1, 4) <> "BBI-" _
                         And Mid(CnChg.ChargesCode, 1, 3) <> "THC" And CnChg.ChargesCode <> "ALL" Then
                    Drs = TBBLCharges.Select("ChargesItem = '" & CnChg.ChargesCode & "' and Currency = '" & CnChg.Currency & "'")
                    If Drs.Length = 0 Then
                        NewDr = TBBLCharges.NewRow
                        sChargeName = GetMeaningFCode("CG", CnChg.ChargesCode)
                        If sChargeName = "" Then
                            sChargeName = GetMeaningCode("CG", CnChg.ChargesCode)
                        End If
                        NewDr = TBBLCharges.NewRow
                        NewDr("BlNo") = BLdatarow("BLNO")
                        NewDr("ChargesItem") = CnChg.ChargesCode
                        NewDr("Meaning") = GetMeaningFCode("CG", CnChg.ChargesCode)
                        NewDr("Currency") = CnChg.Currency
                        NewDr("Amount") = Double.Parse(CnChg.UnitRate)
                        TBBLCharges.Rows.Add(NewDr)
                        TTL += Double.Parse(CnChg.UnitRate)
                    Else
                        Drs(0).Item("Amount") += Double.Parse(CnChg.UnitRate)
                        TTL += Double.Parse(CnChg.UnitRate)
                    End If
                    If (CalBase.Tax + CalBase.Duty) = 0 Then
                        TTax = 0
                    Else
                        TTax += Double.Parse(CnChg.UnitRate) * (CalBase.Tax + CalBase.Duty) / 100
                    End If
                End If
            Next

        Next

        If TTax > 0 Then
            NewDr = TBBLCharges.NewRow
            NewDr("BlNo") = BLdatarow("BLNO")
            NewDr("ChargesItem") = "TAX"
            NewDr("Meaning") = (CalBase.Tax + CalBase.Duty).ToString & " % " & "مالیات و عوارض ارزش افزوده "
            NewDr("Currency") = "USD"
            NewDr("Amount") = TTax 'TTL * (CalBase.Tax + CalBase.Duty) / 100
            TBBLCharges.Rows.Add(NewDr)
        End If

        Drs = TBBLCharges.Select("Currency = 'IRR'")
        If Drs.Length > 0 Then
            For Each dr In Drs
                CalBase.GetTaxDutyInward(BLS.ID, dr("ChargesItem"))
                NewDr = TBDetails.NewRow
                NewDr("IsDeposit") = False
                NewDr("BlNo") = dr("BlNo")
                NewDr("ChargeItem") = dr("ChargesItem")
                NewDr("Meaning") = GetMeaningCode("CG", dr("ChargesItem"))
                NewDr("MeaningF") = GetMeaningFCode("CG", dr("ChargesItem"))
                NewDr("CurCode") = "IRR"
                NewDr("MandatoryAmount") = dr("Amount")
                NewDr("ConditionalAmount") = 0
                NewDr("ConditionToll") = 0
                NewDr("MandatoryToll") = (dr("Amount") * CalBase.Duty) / 100
                NewDr("ConditionTax") = 0
                NewDr("MandatoryTax") = (dr("Amount") * CalBase.Tax) / 100
                NewDr("Seq") = 90
                TBDetails.Rows.Add(NewDr)
            Next
        End If

        For Each dr In Drs
            dr.Delete()
        Next

    End Sub

    Public Sub AddCnCharges(ByVal BLdatarow As DataRow, ByVal BLID As Guid)

        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim DrsAdded() As DataRow
        Dim sSQl As String
        Dim NewDr As DataRow
        Dim nI As Long

        TableBySql("SP_InwardCnsChargesByBLID '" & BLID.ToString & "'", TB, lResult)
        Drs = TBDetails.Select("", "Seq Desc")
        If Drs.Length > 0 Then
            nI = Drs(0).Item("Seq")
        End If

        Drs = TB.Select()

        For Each Dr In Drs
            CalBase.GetTaxDutyInward(BLS.ID, Dr("ChargesCode"))
            If Dr("Terms") = "C" Then
                DrsAdded = TBDetails.Select("ChargeItem = '" & Dr("ChargesCode") & "'")
                If DrsAdded.Length = 0 And Mid(Dr("ChargesCode"), 1, 4) <> "BBI-" Or Dr("ChargesCode") <> "ALL" Then
                    nI += 1
                    NewDr = TBDetails.NewRow
                    NewDr("BlNo") = BLS.BlNo
                    NewDr("ChargeItem") = Dr("ChargesCode")
                    NewDr("Meaning") = GetMeaningCode("CG", Dr("ChargesCode"))
                    NewDr("MeaningF") = GetMeaningFCode("CG", Dr("ChargesCode"))
                    If NewDr("MeaningF") = "" Then
                        NewDr("MeaningF") = NewDr("Meaning")
                    End If
                    NewDr("CurCode") = Dr("Currency")
                    NewDr("ActualAmount") = Double.Parse(Dr("Amount"))
                    NewDr("Seq") = nI
                    NewDr("IsDeposit") = False
                    NewDr("DepositAmount") = 0
                    NewDr("ConditionalAmount") = 0
                    NewDr("MandatoryAmount") = Double.Parse(Dr("Amount")) ' GetExchage(Dr("DefaultAmount"), Dr("CurCode"), Dr("ChargeItem"))
                    NewDr("ConditionalAmount") = 0
                    NewDr("ConditionToll") = 0
                    NewDr("MandatoryToll") = (Dr("Amount") * CalBase.Duty) / 100
                    NewDr("ConditionTax") = 0
                    NewDr("MandatoryTax") = (Dr("Amount") * CalBase.Tax) / 100
                    TBDetails.Rows.Add(NewDr)
                Else
                    NewDr("MandatoryAmount") += Double.Parse(Dr("Amount")) ' GetExchage(Dr("DefaultAmount"), Dr("CurCode"), Dr("ChargeItem"))
                End If
            End If
        Next

    End Sub

    Public ReadOnly Property Master() As DataTable
        Get
            Return TBMaster
        End Get
    End Property

    Public ReadOnly Property Detail() As DataTable
        Get
            Return TBDetails
        End Get
    End Property

    Public ReadOnly Property GetTbError() As DataTable

        Get
            Return TbError
        End Get

    End Property

    Public ReadOnly Property GetTBDetails() As DataTable

        Get
            Return TBDetails
        End Get

    End Property


    Public ReadOnly Property GetExchangeFRT() As Double
        Get
            Return ExFrt
        End Get
    End Property

    Public ReadOnly Property GetExchangeTHC() As Double
        Get
            Return ExTHC
        End Get
    End Property

    Public ReadOnly Property BLCharges() As DataTable
        Get
            Return TBBLCharges
        End Get
    End Property

End Class
