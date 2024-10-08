Imports OrmLib
Imports ShippingBiz
Public Class CLExpInvoice

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
    Private BLS As TB_OutwardBLS
    Private Vsl As TB_Vessels


    Public Sub GenExpInvoice(ByVal BlDr As DataRow, ByVal CalDate As DateTime, ByVal Voy As TB_Voyage)

        If TBDetails Is Nothing Then
            InitTemp()
            Me.Voyage = Voy
            Dm = New DataManager(My.Settings.DSN)
            Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
            Vsl = Dm.GetTB_Vessels
        End If

        Me.BlDataRow = BlDr
        Me.Arrival = CalDate

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, BlDr("Line"), MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, BlDr("BLNO"), MatchType.Exact)
        BLS = Dm.GetTB_OutwardBLS

        If PrepareCntrsData(BLS.ID) Then
            CalculateCharges(CalDate)
            GenMasterData(BlDr)
        End If

    End Sub

    Private Function PrepareCntrsData(ByVal BLID As Guid) As Boolean

        Dim Ds As DataSet
        Dim Ans As Boolean = True

        Ds = StoredProcedures.SP_OutwardCntrsForInv(BLID.ToString)

        If Ds.Tables(0).Rows.Count = 0 Then
            Ans = False
        Else
            TBCns = Ds.Tables(0).Copy
        End If

        Return Ans

    End Function

    Private Function CalculateCharges(ByVal CalDate) As Calstatus

        Dim Ds As DataSet
        Dim Mstr As New DataTable
        Dim Detail As New DataTable
        Dim NewDr As DataRow
        Dim dr As DataRow
        Dim Cn As DataRow
        Dim Dummy As Double
        Dim Dv As DataView

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
        ReadingBooking(BLS.BlNo, TBCns)

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
                            Amount = (Amount / Cn("TTLGW")) * Cn("GW")
                        End If
                    End If
                Else
                    Dtls.WriteXml("C:\temp\ERR.XML")
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
            NewDr("GW") = Double.Parse(NullToValue(Goods.TGW, 0))
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

    Private Function GetExchage(ByVal Amt As Double, ByVal Cur As String, ByVal ChargeItem As String) As Long

        If Cur = "IRR" Then
            Return Amt
        Else
            If Left(ChargeItem, 3) = "THC" Then
                Return Amt * Voyage.ExchangeThc
            Else
                Return Amt * Voyage.ExchangeFrt
            End If
        End If

    End Function

    Private Sub ReadingBooking(ByVal BlNo As String, ByVal Cntrs As DataTable)

        Dim aTables() As String = {"TB_Booking", "Tb_BookingDetails"}

        Dim newDr As DataRow
        Dim DrBK As DataRow

        Dim Dv As DataView

        Dim Code As TB_CODE

        Dim nI As Byte
        Dim Dummy As Double
        Dim aFailed As New ArrayList

        Dm = New DataManager(My.Settings.DSN)

        Dim ds As DataSet = StoredProcedures.SP_BookingAllByLineBLNo(CurrentShippingLine, BlNo)
        Dm.PopulateObjectsFromDataSet(ds, aTables)

        For nI = 0 To aTables.Length - 1
            Dm.DataSet.Tables(aTables(nI)).Merge(ds.Tables(nI))
        Next

        Dv = New DataView(TBDetails, "", "Seq", DataViewRowState.CurrentRows)

        If Dv.Count > 0 Then
            For nI = 0 To Dv.Count - 1
                Dv.Item(nI).Item("Seq") = Dv.Item(nI).Item("Seq") + 10
            Next
        End If

        For Each DrBK In Dm.DataSet.Tables("TB_BookingDetails").Rows

            If Left(NullToValue(DrBK("Payebleat"), "IRTEH"), 2) = "IR" Then

                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "CG", MatchType.Exact)
                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, DrBK("ChargeItem"), MatchType.Exact)
                Code = Dm.GetTB_CODE

                If DrBK("BaseOn") = "B" Then
                    Dummy = NullToValue(DrBK("QTShipper"), 0)
                Else
                    Dummy = 0
                    Dv = New DataView(Cntrs, "CnSize = '" & DrBK("CnSize") & "' and CnType = '" & DrBK("CnType") & "'", "", DataViewRowState.CurrentRows)
                    If Dv.Count > 0 Then
                        Dummy = Dv.Count * NullToValue(DrBK("QTShipper"), 0)
                    End If
                End If


                If Dummy > 0 Then
                    newDr = TBDetails.NewRow
                    nI += 1
                    newDr("Seq") = nI
                    newDr = TBDetails.NewRow
                    newDr("IsDeposit") = False
                    newDr("BlNo") = BlDataRow("BLNO")
                    newDr("ChargeItem") = DrBK("ChargeItem")
                    newDr("CurCode") = DrBK("CurCode")
                    newDr("ActualAmount") = DrBK("QTShipper")
                    If Code Is Nothing Then
                        newDr("Meaning") = Code.MEANING
                        newDr("MeaningF") = Code.MEANINGF
                    Else
                        newDr("Meaning") = DrBK("ChargeItem")
                        newDr("MeaningF") = DrBK("ChargeItem")
                    End If
                    TBDetails.Rows.Add(newDr)
                Else
                    aFailed.Add(NullToValue(DrBK("ChargeItem"), "???"))
                End If
            End If



        Next

        Dv = New DataView(TBDetails, "", "Seq", DataViewRowState.CurrentRows)
        If Dv.Count > 0 Then
            For nI = 0 To Dv.Count - 1
                Dv.Item(nI).Item("Seq") = nI + 1
            Next
        End If

        If aFailed.Count > 0 Then
            For nI = 0 To aFailed.Count - 1
                Dv = New DataView(TBDetails, "ChargeItem = '" & aFailed(nI) & "'", "", DataViewRowState.CurrentRows)
                If Dv.Count = 0 Then
                    newDr = TbError.NewRow
                    newDr("BlNo") = BlDataRow("BLNO")
                    newDr("ChargeItem") = aFailed(nI)
                    newDr("ErrMsg") = "No Charge Item Found In Containers (" & aFailed(nI) & ")"
                    TbError.Rows.Add(newDr)
                End If
            Next
        End If

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

    


End Class
