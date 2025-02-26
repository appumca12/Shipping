Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient

Public Class CLDeparturCost

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
    Private BLS As TB_OutWardBLS
    Private Vsl As TB_Vessels
    Private ExTHC As Double
    Private ExFrt As Double
    Private ExTB As TB_Exchange
    Private ExDetailTb As TB_ExchangeDetailsCollection
    Private TTax As Double
    Private TToll As Double
    Private CalBase As New CLCalculationBase
    Private Sof As TB_SOF
    Public THCBerthDate As DateTime


    Public Sub GenDeparturCost(ByVal BlDr As DataRow, ByVal CalDate As DateTime, ByVal Voy As TB_Voyage)

        If TBDetails Is Nothing Then
            InitTemp()
            Me.Voyage = Voy
            Dm = New DataManager(My.Settings.DSN)
            Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
            Vsl = Dm.GetTB_Vessels
        End If

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, BlDr("Line"), MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, BlDr("BLNO"), MatchType.Exact)
        BLS = Dm.GetTB_OutwardBLS

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, BLS.VoyageID, MatchType.Exact)
        Sof = Dm.GetTB_SOF
        'commented for RE: THC DISCREPENCY mail case 
        'CalDate = CalDate.Date ' CDate(CalDate.ToString("dd/MM/yyyy"))
        CalDate = Sof.Berthed ' CDate(CalDate.ToString("dd/MM/yyyy"))
        '' CalDate = CDate(CalDate.ToString("dd/MM/yyyy"))
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Exchange.Columns.ExchangeDate, CalDate, MatchType.Exact)
        ExTB = Dm.GetTB_Exchange

        If ExTB Is Nothing Then
            ' commented for RE: THC DISCREPENCY case
            MsgBox("No Valid THC Exchange Rate For (Berth Date)" & CalDate.ToString)
            Exit Sub
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_ExchangeDetails.Columns.MasterID, ExTB.ID, MatchType.Exact)
        ExDetailTb = Dm.GetTB_ExchangeDetailsCollection

        If ExDetailTb Is Nothing Then
            ' commented for RE: THC DISCREPENCY case
            MsgBox("No Valid THC Exchange Rate For (Berth Date) " & CalDate.ToString)
            Exit Sub
        End If

        Me.BlDataRow = BlDr
        Me.Arrival = CalDate

      

        If PrepareCntrsData(BLS.ID) Then
            'CalculateCharges(CalDate)

            CalculateCharges_THCSpecial(CalDate, Sof.Berthed)
            GenMasterData(BlDr)
            TaxCal_THC(CalDate, Sof.Berthed)
        End If

    End Sub

    Private Function PrepareCntrsData(ByVal BLID As Guid) As Boolean

        Dim sSql As String = "SP_OutWardCntrsForArr '" & BLID.ToString & "'"
        Dim Ds As DataSet
        Dim Ans As Boolean = True

        Ds = StoredProcedures.SP_OutwardCntrsForCost(BLID.ToString)

        If Ds.Tables(0).Rows.Count = 0 Then
            Ans = False
        Else
            TBCns = Ds.Tables(0).Copy
        End If

        Return Ans

    End Function

    Private Function CalculateCharges(ByVal CalDate As Date) As Calstatus

        Dim Ds As DataSet
        Dim Mstr As New DataTable
        Dim Detail As New DataTable
        Dim NewDr As DataRow
        Dim dr As DataRow
        Dim Cn As DataRow
        Dim Dummy As Double
        Dim Dv As DataView
        Dim nBLTax As Double
        Dim nBLToll As Double
        Dim Drs() As DataRow
        Ds = StoredProcedures.SP_ChgLevelAllByDate(CalDate)

        If Ds.Tables(0).Rows.Count = 0 Then
            Return Calstatus.NoMasterData
        End If

        If Ds.Tables(1).Rows.Count = 0 Then
            Return Calstatus.NoDetailData
        End If

        Mstr = Ds.Tables(0)
        Detail = Ds.Tables(1)

        For Each dr In Mstr.Rows
            If dr("ImportExport") <> "I" Then
                If dr("BaseOn") = "B" Then
                    NewDr = TBDetails.NewRow
                    NewDr("BlNo") = BLS.BlNo
                    NewDr("ChargeItem") = dr("ChargeItem")
                    NewDr("Meaning") = dr("Meaning")
                    NewDr("MeaningF") = dr("MeaningF")
                    NewDr("CurCode") = dr("CurCode")
                    NewDr("ActualAmount") = dr("DefaultAmount")
                    NewDr("Seq") = dr("Seq")
                    NewDr("IsDeposit") = dr("IsDeposit")
                    If dr("IsDeposit") Then
                        NewDr("DepositAmount") = GetExchage(dr("DefaultAmount"), dr("CurCode"), dr("ChargeItem"))
                        NewDr("Condition") = "یه صورت سپرده"
                    Else
                        If dr("Condition") = "T" Then
                            NewDr("ConditionalAmount") = GetExchage(dr("DefaultAmount"), dr("CurCode"), dr("ChargeItem"))
                        Else
                            NewDr("MandatoryAmount") = GetExchage(dr("DefaultAmount"), dr("CurCode"), dr("ChargeItem"))
                        End If
                        NewDr("Condition") = IIf(dr("Condition") = "T", "در صورت خروج از محوطه", "هزینه های عمومی")
                    End If
                    TBDetails.Rows.Add(NewDr)
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
                                    End If
                                End If
                            End If

                        End If
                    Next
                End If
            End If
        Next

        CalBase.GetTaxDutyOutward(BLS.ID, dr("ChargeItem"))
        If (dr("ChargeItem") = "DO") Then
            nBLTax = CalBase.Tax
            nBLToll = CalBase.Duty
        End If
        Drs = TBDetails.Select("ChargeItem='B/L'")
        For Each dr In Drs

            'Dim Tb1 As New DataTable
            'Dim lResult As Boolean
            'Dim sSql As String

            'sSql = "select count(distinct IMDGCode) from tb_inwardcnspkgs where CntrID in (select id from TB_InwardCntrs  where blid = '" & BLS.ID.ToString & " ')"

            If TBCns.Rows.Count > 0 And TBCns.Rows.Count <= 5 Then
                'dr("ActualAmount") = 4650000
                dr("ActualAmount") = dr("ActualAmount")
            ElseIf TBCns.Rows.Count >= 6 Then   'And TBCns.Rows.Count <= 20
                dr("ActualAmount") = dr("ActualAmount") + ((TBCns.Rows.Count - 5) * 900000)
                'ElseIf TBCns.Rows.Count >= 21 Then
                '    dr("ActualAmount") = 24375000
            Else
                dr("ActualAmount") = 0
            End If

            dr("MandatoryAmount") = dr("ActualAmount")
        Next

    End Function
    Private Function CalculateCharges_THCSpecial(ByVal CalDate_now As Date, ByVal CalDate_Brth As Date) As Calstatus

        Dim Ds As DataSet
        Dim Mstr As New DataTable
        Dim Detail As New DataTable
        Dim NewDr As DataRow
        Dim dr As DataRow
        Dim Cn As DataRow
        Dim Dummy As Double
        Dim Dv As DataView
        Dim nBLTax As Double
        Dim nBLToll As Double
        Dim Drs() As DataRow
        Dim adapter As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Cmd As New SqlCommand
        Dim sSql As String
        THCBerthDate = CalDate_Brth

        sSql = "exec SP_ChgLevelAllByDate_THCSpl @Date_Now, @Date_Berth  "
        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@Date_Now", CalDate_now)
        Cmd.Parameters.AddWithValue("@Date_Berth", CalDate_Brth)
        Cmd.CommandTimeout = 3000
        adapter = New SqlDataAdapter(Cmd)

        'Try
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Ds = New DataSet()
        adapter.Fill(Ds)
        'Ds = StoredProcedures.SP_ChgLevelAllByDate(CalDate_now, CalDate_Brth)

        If Ds.Tables(0).Rows.Count = 0 Then
            Return Calstatus.NoMasterData
        End If

        If Ds.Tables(1).Rows.Count = 0 Then
            Return Calstatus.NoDetailData
        End If

        Mstr = Ds.Tables(0)
        Detail = Ds.Tables(1)

        For Each dr In Mstr.Rows
            If dr("ImportExport") <> "I" Then
                If dr("BaseOn") = "B" Then
                    NewDr = TBDetails.NewRow
                    NewDr("BlNo") = BLS.BlNo
                    NewDr("ChargeItem") = dr("ChargeItem")
                    NewDr("Meaning") = dr("Meaning")
                    NewDr("MeaningF") = dr("MeaningF")
                    NewDr("CurCode") = dr("CurCode")
                    NewDr("ActualAmount") = dr("DefaultAmount")
                    NewDr("Seq") = dr("Seq")
                    NewDr("IsDeposit") = dr("IsDeposit")
                    If dr("IsDeposit") Then
                        NewDr("DepositAmount") = GetExchage(dr("DefaultAmount"), dr("CurCode"), dr("ChargeItem"))
                        NewDr("Condition") = "یه صورت سپرده"
                    Else
                        If dr("Condition") = "T" Then
                            NewDr("ConditionalAmount") = GetExchage(dr("DefaultAmount"), dr("CurCode"), dr("ChargeItem"))
                        Else
                            NewDr("MandatoryAmount") = GetExchage(dr("DefaultAmount"), dr("CurCode"), dr("ChargeItem"))
                        End If
                        NewDr("Condition") = IIf(dr("Condition") = "T", "در صورت خروج از محوطه", "هزینه های عمومی")
                    End If
                    TBDetails.Rows.Add(NewDr)
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
                                    End If
                                End If
                            End If

                        End If
                    Next
                End If
            End If
        Next

        CalBase.GetTaxDutyOutward(BLS.ID, dr("ChargeItem"))
        If (dr("ChargeItem") = "DO") Then
            nBLTax = CalBase.Tax
            nBLToll = CalBase.Duty
        End If
        Drs = TBDetails.Select("ChargeItem='B/L'")
        For Each dr In Drs

            'Dim Tb1 As New DataTable
            'Dim lResult As Boolean
            'Dim sSql As String

            'sSql = "select count(distinct IMDGCode) from tb_inwardcnspkgs where CntrID in (select id from TB_InwardCntrs  where blid = '" & BLS.ID.ToString & " ')"

            If TBCns.Rows.Count > 0 And TBCns.Rows.Count <= 5 Then
                'dr("ActualAmount") = 4650000
                dr("ActualAmount") = dr("ActualAmount")
            ElseIf TBCns.Rows.Count >= 6 Then   'And TBCns.Rows.Count <= 20
                dr("ActualAmount") = dr("ActualAmount") + ((TBCns.Rows.Count - 5) * 900000)
                'ElseIf TBCns.Rows.Count >= 21 Then
                '    dr("ActualAmount") = 24375000
            Else
                dr("ActualAmount") = 0
            End If

            dr("MandatoryAmount") = dr("ActualAmount")
        Next

    End Function

    Private Function CalAmonut(ByVal Mstr As DataRow, ByVal Dtls As DataTable, ByVal Cn As DataRow) As Double

        Dim Dv As DataView
        Dim Amount As Double = 0
        Dim sCrt As String
        Dim ByPass As New ArrayList
        Dim lFound As Boolean = False

        sCrt = "(MasterID = '" & Mstr("ID").ToString & "') and ( CnType = '***' or CnType = '" & Cn("CnType") & "' ) and " & _
        "( ShipmentType = '***' or ShipmentType = '" & Cn("BlStatus") & "' ) and " & _
        "( Imco = '***' or Imco = '" & Cn("IsImco") & "' ) and " & _
        "( IsFull = '***' or IsFull = '" & Cn("IsFull") & "' ) and " & _
        "( SOC = '***' or Soc = '" & Cn("SOC") & "' )"

        Try
            If (Mstr("BaseOn") = "LW" Or Mstr("BaseOn") = "LT") And Cn("LCLCount") = 1 Then
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

                    If Mstr.Item("DividInLCL") = True Then
                        If Mstr("BaseOn") = "C" Then
                            Amount = Amount / Cn("LCLCount")
                        Else
                            If Cn("TTLGW") = 0 Then
                                Amount = 0
                            Else
                                If Convert.ToInt32(Cn("GW")) = 0 Then
                                    MessageBox.Show("GW can not be Zero. Fill GW value for all Containers of this BL!", "Shipping", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End

                                Else
                                    Amount = (Amount / Cn("TTLGW")) * Cn("GW")
                                End If
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
        Dim Names As TB_OutwardBlsNames
        Dim Goods As TB_OutwardBlsGoods
        Dim NoOfCntrs As String = ""

        NewDr = TBMaster.NewRow
        NewDr("BlNo") = Dr("BLNo")
        NewDr("reference") = Dr("Reference")
        NewDr("POL") = Dr("POL")
        NewDr("POD") = Dr("POD")
        NewDr("POLCode") = Dr("POL")
        NewDr("arrival") = Arrival

        NewDr("vesselname") = Vsl.VesselName
        NewDr("voyageno") = Voyage.VoyageNo

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBlsNames.Columns.BLID, BLS.ID, MatchType.Exact)
        Names = Dm.GetTB_OutwardBlsNames

        If Not Names Is Nothing Then
            NewDr("cnee") = Names.Cnee
            NewDr("Notify") = Names.Notify1
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBlsGoods.Columns.BLID, BLS.ID, MatchType.Exact)
        Goods = Dm.GetTB_OutwardBlsGoods

        If Not Goods Is Nothing Then
            NewDr("TW") = Double.Parse(Goods.TTW)
            NewDr("GW") = Double.Parse(Goods.TGW)
            NewDr("NW") = Double.Parse(Goods.TTLNET)
        End If

        OutwardCntrsCount(BLS.ID, NoOfCntrs)
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

        Col = New DataColumn("Seq", System.Type.GetType("System.String"))
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

        Col = New DataColumn("Tax", System.Type.GetType("System.Double"))
        Col.DefaultValue = 0
        Col.AllowDBNull = True
        TBDetails.Columns.Add(Col)

        Col = New DataColumn("Toll", System.Type.GetType("System.Double"))
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

            Col = New DataColumn("POLCode", System.Type.GetType("System.String"))
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

    End Sub

    Private Sub TaxCal(ByVal BaseDate As Date)

        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim dDr As DataRow
        Dim Tax As Double
        Dim Toll As Double

        For Each Dr In TBMaster.Rows
            Drs = TBDetails.Select("BLNO = '" & Dr("BlNo") & "'")
            For Each dDr In Drs
                If dDr("IsDeposit") = False Then
                    Tax = 0
                    Toll = 0
                    CalBase.GetTaxDutyDyDate(BaseDate, dDr("ChargeItem"))
                    'GetTaxTollPercent(dDr("ChargeItem"), BaseDate, Dr("POLCode"), "E", Tax, Toll)
                    dDr("Tax") = CalBase.Tax
                    dDr("Toll") = CalBase.Duty
                End If
            Next
        Next

    End Sub
    Private Sub TaxCal_THC(ByVal BaseDate As Date, ByVal BirthDate As Date)

        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim dDr As DataRow
        Dim Tax As Double
        Dim Toll As Double

        For Each Dr In TBMaster.Rows
            Drs = TBDetails.Select("BLNO = '" & Dr("BlNo") & "'")
            For Each dDr In Drs
                If dDr("IsDeposit") = False Then
                    Tax = 0
                    Toll = 0
                    If Not dDr("ChargeItem") = "THC" Then
                        CalBase.GetTaxDutyDyDate(BaseDate, dDr("ChargeItem"))
                    Else
                        CalBase.GetTaxDutyDyDate(BirthDate, dDr("ChargeItem"))
                    End If
                    'GetTaxTollPercent(dDr("ChargeItem"), BaseDate, Dr("POLCode"), "E", Tax, Toll)
                    dDr("Tax") = CalBase.Tax
                    dDr("Toll") = CalBase.Duty
                End If
            Next
        Next

    End Sub
    Private Function GetExchage(ByVal Amt As Double, ByVal Cur As String, ByVal ChargeItem As String) As Long

        Dim Exs As TB_ExchangeDetailsCollection
        Dim Ex As TB_ExchangeDetails
        Dim sSql As String
        Dim lResult As Boolean
        Dim TB As New DataTable
        If Cur = "IRR" Then
            Return Amt
        Else
            Exs = ExDetailTb.FilterByCurCode(Cur)
            If Exs.Count > 0 Then
                Ex = Exs(0)
                If Left(ChargeItem, 3) = "THC" Then
                    sSql = "Select * From TB_Exchange EX , TB_ExchangeDetails EXD  where EX.ID = EXD.MasterID and CurCode = '" & Cur & "' and ExchangeDate = '" & Format(THCBerthDate, "yyyy-MM-dd") & "'"
                    TableBySql(sSql, TB, lResult)
                    If lResult = True Then
                        If TB.Rows.Count > 0 Then
                            Return Amt * TB.Rows(0).Item("THCRate")
                        End If
                    Else
                        MsgBox("No Valid Rate For THC " & Cur & THCBerthDate.ToString())
                    End If

                Else
                    Return Amt * Ex.FRTRate
                End If
            Else
                MsgBox("No Valid Rate For " & Cur)
            End If
            End If

    End Function
    'Private Function SetExchange() As Boolean

    '    Dim sSql As String
    '    Dim lResult As Boolean
    '    Dim TB As New DataTable

    '    sSql = "Select * From TB_Exchange EX , TB_ExchangeDetails EXD  where EX.ID = EXD.MasterID and CurCode = '" & Currency & "' and ExchangeDate = '" & Format(DateOf, "yyyy-MM-dd") & "'"
    '    TableBySql(sSql, TB, lResult)
    '    If lResult = True Then
    '        If TB.Rows.Count > 0 Then
    '            lResult = True
    '        Else
    '            lResult = False
    '        End If
    '    End If

    '    If lResult = False Then
    '        ExchgFrt = -1
    '        ExchgThc = -1
    '        ExchgDETN = -1
    '        Excep = "No Found Valid Exchange Rate: " & Format(DateOf.Date, "dd-MM-yyyy") & " ,Please Check Exchange Rate Screen "
    '    Else
    '        ExchgThc = TB.Rows(0).Item("THCRate")
    '        ExchgFrt = TB.Rows(0).Item("FrtRate")
    '        ExchgDETN = TB.Rows(0).Item("DETNRate")
    '    End If

    '    Return lResult

    'End Function

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
    Public ReadOnly Property GetExchangeFRT(ByVal Cur As String) As Double
        Get
            Return GetExchangeRate(Cur, False)
        End Get
    End Property

    Public ReadOnly Property GetExchangeTHC(ByVal Cur As String) As Double
        Get
            Return GetExchangeRate(Cur, True)
        End Get
    End Property

    Private Function GetExchangeRate(ByVal Cur As String, ByVal IsTHC As Boolean) As Double

        Dim Exs As TB_ExchangeDetailsCollection
        Dim Ex As TB_ExchangeDetails

        If ExDetailTb Is Nothing Then
            MsgBox("No Valid Rate For " & Cur)
            Return 0
        End If

        If Cur = "IRR" Then
            Return 1
        Else
            Exs = ExDetailTb.FilterByCurCode(Cur)

            If Cur = "USD" Then
                If Not Exs Is Nothing Then
                    'Added by thenmozhi
                    If (Exs.Count > 0) Then
                        Ex = Exs(0)
                        If IsTHC = True Then
                            Return Ex.THCRate
                        Else
                            Return Ex.FRTRate
                        End If
                    End If
                Else
                    MsgBox("No Valid Rate For " & Cur)
                End If
            End If
        End If

    End Function


End Class


