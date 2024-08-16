Imports OrmLib
Imports ShippingBiz
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports System.IO


Public Class CLTctsMapLoad

    Private Dm As DataManager
    Public Event Reading()
    Public Event SkipRec()

    Private TTLCntrs As Long
    Private Counter As Long
    Private TmpRst As DataTable
    Private VOY As TB_Voyage
    Private VE As TB_Vessels

    Private TcCns As DataTable
    Private TcCnsBL As DataTable
    Private TcBls As DataTable
    Private TcVoyage As DataTable
    Private TcVessel As DataTable
    Private YY As String
    Private CcsPath As String
    Private Vesl As String

    Private BlNo As String
    Private sGoods As String
    Private sCntr As String
    Private sRtn As String
    Private sPermit As String
    Private sSql As String

    Private Pkgs As Long
    Private nFound As Long
    Private nI As Long

    Private n20F As Long
    Private n40F As Long
    Private n20E As Long
    Private n40E As Long

    Private GW As Double
    Private TW As Double

    Private Co As TB_Company

    Private DSTcts As New DataSet
    Private EdiCnn As New OleDb.OleDbConnection

    Private ADVessel As New OleDbDataAdapter()
    Private CBVessel = New OleDbCommandBuilder()

    Private ADVoy As New OleDbDataAdapter()
    Private CbVoy As New OleDbCommandBuilder

    Private ADBLCns As New OleDbDataAdapter()
    Private CBBLCns As New OleDbCommandBuilder()

    Private ADCns As New OleDbDataAdapter()
    Private CBCns As New OleDbCommandBuilder()

    Private ADBls As New OleDbDataAdapter()
    Private CBBls As New OleDbCommandBuilder()

    Public Sub SendToTctsLoadList(ByVal VoyID As Guid, ByVal PrmtSel As DataTable)

        Dim UpdDs As DataSet
        Dim Drs() As DataRow = PrmtSel.Select("Select = true")


        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyID, MatchType.Exact)
        VOY = Dm.GetTB_Voyage

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, VOY.VesselID, MatchType.Exact)
        VE = Dm.GetTB_Vessels


        Dm.QueryCriteria.Clear()
        Co = Dm.GetTB_Company


        If Drs.Length = 0 Then
            If Init(VOY.VoyageNo, VE.VesselName) = True Then
                FillTmpForEmptyCntrs(VOY.ID.ToString, VOY.VoyageNo)

                ADVoy.Update(DSTcts, "TbExpMVoyageID")
                ADBls.Update(DSTcts, "TbExpMBL")
                ADCns.Update(DSTcts, "TbExpMBContainer")
                ADBLCns.Update(DSTcts, "TbExpMBLContainer")
                UpdDs = DSTcts.GetChanges
                DSTcts.AcceptChanges()
                ChgsToText(DSTcts, VOY.VoyageNo)
                MsgBox("Map To TCTS Successful")
            End If
            Exit Sub
        End If

        Try
            If Init(VOY.VoyageNo, VE.VesselName) = True Then
                FillTmpForFullCntrs(Drs, VOY.VoyageNo)
                FillTmpForEmptyCntrs(VOY.ID.ToString, VOY.VoyageNo)

                'DSTcts.Tables("TbExpMVoyageID").WriteXml("c:\Voy.xml")
                'DSTcts.Tables("TbExpMBL").WriteXml("c:\TbExpMBL.xml")
                'DSTcts.Tables("TbExpMBContainer").WriteXml("c:\TbExpMBContainer.xml")
                'DSTcts.Tables("TbExpMBLContainer").WriteXml("c:\TbExpMBLContainer.xml")


                ADVoy.Update(DSTcts, "TbExpMVoyageID")
                ADBls.Update(DSTcts, "TbExpMBL")
                ADCns.Update(DSTcts, "TbExpMBContainer")
                ADBLCns.Update(DSTcts, "TbExpMBLContainer")
                DSTcts.WriteXml("c:\temp\Temp.xml")
                UpdDs = DSTcts.GetChanges
                DSTcts.AcceptChanges()
                ChgsToText(DSTcts, VOY.VoyageNo)
                MsgBox("Map To TCTS Successful")
            End If
        Catch ex As Exception
            MsgBox("Map Failed !", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub FillTmpForFullCntrs(ByVal Drs() As DataRow, ByVal VoyageNo As String)

        Dim Prmt As TB_Permits
        Dim PrmtDetails As TB_PermitDetailsCollection
        Dim Ecs As TB_EcsContainers
        Dim NewDr As DataRow
        Dim TmpDrs() As DataRow
        Dim prmtcns As TB_PermitDetails
        Dim TW As Long
        Dim aFld() As String = {"TW"}
        Dim lResult As Boolean
        Dim CnTw As Long
        Dim Line As TB_Lines
        Dim PkgCode As String
        Dim Code As TB_CODE
        Dim CnDrs() As DataRow


        Dm = New DataManager(My.Settings.DSN)

        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Line = Dm.GetTB_Lines
        Dm.QueryCriteria.Clear()


        Co = Dm.GetTB_Company

        For Each dr As DataRow In Drs
            Debug.Print(dr(1))
            Pkgs = 0
            GW = 0
            n20E = 0
            n40E = 0
            n20F = 0
            n40F = 0
            sCntr = ""

            Dm = New DataManager(My.Settings.DSN)
            Dm.QueryCriteria.And(JoinPath.TB_Permits.Columns.ID, dr(0), MatchType.Exact)
            Prmt = Dm.GetTB_Permits
            If Prmt Is Nothing Then
                Exit Sub
            End If

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_PermitDetails.Columns.PermitID, dr(0), MatchType.Exact)
            PrmtDetails = Dm.GetTB_PermitDetailsCollection

            If PrmtDetails.Count > 0 Then
                If PrmtDetails(0).FLE <> "E" Then
                    For Each prmtcns In PrmtDetails
                        Debug.Print(prmtcns.CntrID.ToString)
                        Dm.QueryCriteria.Clear()
                        Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, prmtcns.CntrID, MatchType.Exact)
                        Ecs = Dm.GetTB_EcsContainers
                        Try
                            If Ecs.OutVoyageID.ToString = VOY.ID.ToString Then
                                If Ecs.CnSize = "20" Then
                                    n20F = n20F + 1
                                Else
                                    n40F = n40F + 1
                                End If
                                GW += Double.Parse(NullToValue(prmtcns.GW, 0).ToString)
                                Pkgs += Long.Parse(NullToValue(prmtcns.NoOFPkgs, 0).ToString)
                            End If
                        Catch ex As Exception
                            MsgBox("Voyage wrong for container " & Ecs.CntrNo)
                        End Try
                    Next

                    sSql = "Select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Ecs.InVoyageID.ToString & "' , '" & Ecs.CntrNo & "') As TW"
                    TW = Val(FieldsBySql(sSql, aFld, lResult).Item(0).ToString)
                    If lResult = False Then
                        If Ecs.CnSize = "20" Then
                            TW = 2200
                        Else
                            TW = 4500
                        End If
                    End If

                    sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n20E > 0, Trim(Str(n20E)) & "X20' Empty", "")
                    sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n40E > 0, Trim(Str(n40E)) & "X40' Empty", "")

                    sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n20F > 0, Trim(Str(n20F)) & "X20' Full", "")
                    sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n40F > 0, Trim(Str(n40F)) & "X40' Full", "")

                    sGoods = sCntr & " " & ("" & Prmt.Goods) & " "
                    sGoods = sGoods & Trim(Str(Pkgs)) & " " & PrmtDetails(0).PackageType & " "
                    sGoods = sGoods & "Destination: " & Prmt.FPOD & " "
                    sGoods = sGoods & "** PERMIT NO. **" & " " & ("" & Prmt.PermitNo)
                    NewDr = TmpRst.NewRow

                    NewDr("PermitNo") = Prmt.PermitNo
                    NewDr("Goods") = sGoods
                    NewDr("TotalGW") = GW
                    NewDr("TotalPkgs") = Pkgs
                    NewDr("Goods") = sGoods
                    BlNo = CurrentShippingLine & "-" & Prmt.PermitNo
                    TmpRst.Rows.Add(NewDr)

                End If
            End If
        Next

        For Each Tmp As DataRow In TmpRst.Rows
            BlNo = CurrentShippingLine & "-" & Tmp("PermitNo")
            TmpDrs = DSTcts.Tables("TbExpMBL").Select("mYear = '" & YY & "' and " & _
                            "KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & "' And " & _
                            "TripNo = '" & VoyageNo & "' And " & _
                            "BlNumber = '" & BlNo & "'")
            If TmpDrs.Length = 0 Then
                sGoods = Tmp("Goods")
                Pkgs = Tmp("TotalPkgs")
                GW = Tmp("TotalGW")
                TctBlsIns(VoyageNo)
            End If
        Next

        For Each dr As DataRow In Drs

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Permits.Columns.ID, dr(0), MatchType.Exact)
            Prmt = Dm.GetTB_Permits

            If Prmt Is Nothing Then
                Exit Sub
            End If

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_PermitDetails.Columns.PermitID, dr(0), MatchType.Exact)
            PrmtDetails = Dm.GetTB_PermitDetailsCollection

            For Each prmtcns In PrmtDetails

                If PrmtDetails(0).FLE <> "E" Then
                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, prmtcns.CntrID, MatchType.Exact)
                    Ecs = Dm.GetTB_EcsContainers
                    Try
                        If Ecs.OutVoyageID.ToString = VOY.ID.ToString Then
                            sSql = "Select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Ecs.InVoyageID.ToString & "' , '" & Ecs.CntrNo & "') As TW"
                            CnTw = Val(FieldsBySql(sSql, aFld, lResult).Item(0).ToString)
                            If CnTw = 0 Then
                                If Ecs.CnSize = "20" Then
                                    CnTw = 2200
                                Else
                                    CnTw = 4500
                                End If
                            End If
                            CnDrs = DSTcts.Tables("TbExpMBContainer").Select("KeshtiCode = " & TcVessel.Rows(0).Item("Code") & " and TripNo = '" & VoyageNo & "' and ConFlag = '" & CntrFormat(Ecs.CntrNo) & "'")
                            If CnDrs.Length = 0 Then
                                NewDr = DSTcts.Tables("TbExpMBContainer").NewRow
                                NewDr("MYEAR") = YY
                                NewDr("KeshtiCode") = TcVessel.Rows(0).Item("Code")
                                NewDr("TripNo") = VoyageNo
                                NewDr("ConFlag") = CntrFormat(Ecs.CntrNo)
                                NewDr("SealNumber") = prmtcns.SealNo
                                NewDr("CSize") = Ecs.CnSize
                                NewDr("CType") = EcsCnTypeToTCTS(Ecs.CnType)
                                NewDr("NoeInput") = Prmt.Status
                                NewDr("MovementType") = "3"
                                NewDr("F_E") = True
                                NewDr("POD") = Left(NullToValue(Prmt.POT, ""), 2) & " " & Right(NullToValue(Prmt.POT, ""), 3)
                                NewDr("Des") = Left(NullToValue(Prmt.FPOD, ""), 2) & " " & Right(NullToValue(Prmt.FPOD, ""), 3)
                                NewDr("TareWeight") = CnTw
                                NewDr("TxtJavazWei") = prmtcns.GW
                                NewDr("ContainerOwner") = Co.EDICODE
                                NewDr("Line") = Line.EDICode

                                NewDr("IMDGCode") = NullToValue(Prmt.IMDGCode, "")
                                NewDr("TxtTemJavazNo") = ""
                                NewDr("TxtEXPPMT") = Prmt.PermitNo
                                NewDr("sTime") = Now()
                                DSTcts.Tables("TbExpMBContainer").Rows.Add(NewDr)

                                BlNo = CurrentShippingLine & "-" & Prmt.PermitNo
                                NewDr = DSTcts.Tables("TbExpMBLContainer").NewRow
                                NewDr("MYEAR") = YY
                                NewDr("KeshtiCode") = TcVessel.Rows(0).Item("Code")
                                NewDr("TripNo") = VoyageNo
                                NewDr("ConFlag") = CntrFormat(Ecs.CntrNo)
                                NewDr("BlNumber") = BlNo
                                NewDr("NoOfPackage") = Double.Parse(prmtcns.NoOFPkgs)
                                NewDr("NetWeight") = Double.Parse(prmtcns.GW.ToSqlString)
                                NewDr("sTime") = Now()
                                PkgCode = "PK"
                                Dm.QueryCriteria.Clear()
                                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PG", MatchType.Exact)
                                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, prmtcns.PackageType, MatchType.Exact)
                                Code = Dm.GetTB_CODE
                                If Not Code Is Nothing Then
                                    PkgCode = Code.NextCode
                                End If
                                NewDr("TxtPackType") = PkgCode '  prmtcns.PackageType
                                DSTcts.Tables("TbExpMBLContainer").Rows.Add(NewDr)
                            Else
                                CnDrs(0).Item("TxtJavazWei") = Val(CnDrs(0).Item("TxtJavazWei")) + prmtcns.GW
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Skiped Container " & Ecs.CntrNo)
                    End Try

                End If

            Next
        Next

    End Sub


    Private Sub FillTmpForEmptyCntrs(ByVal VoyageID As String, ByVal VoyageNo As String)

        Dim sSql As String
        Dim Line As TB_Lines
        Dim Tb As New DataTable
        Dim lResult As Boolean
        Dim Dr As DataRow
        Dim ReturnTo As String
        Dim NewDr As DataRow
        Dim Drs() As DataRow
        Dim aUnique As New ArrayList
        Dim SOF As TB_SOF

        Dim rFind() As DataRow


        Dm = New DataManager(My.Settings.DSN)
        '   Dm.GetTB_EcsContainers()

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Line = Dm.GetTB_Lines

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, VoyageID, MatchType.Exact)
        SOF = Dm.GetTB_SOF


        sSql = "SP_EcsEmptyListByVoyageID '" & VoyageID & "'"

        TableBySql(sSql, Tb, lResult)

        If lResult = False Then
            Exit Sub
        End If

        Drs = Tb.Select("Line = '" & CurrentShippingLine & "'", "ReturnTo")
        If Drs.Length = 0 Then
            Exit Sub
        End If
        ReturnTo = NullToValue(Drs(0).Item("ReturnTo"), "")


        For Each Dr In Drs

            Dr("ReturnTo") = NullToValue(Dr("ReturnTo"), "?????")
            If ReturnTo <> Dr("ReturnTo") Then

                BlNo = CurrentShippingLine & "-MTY-" & ReturnTo
                sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n20E > 0, Trim(Str(n20E)) & "X20' Empty", "")
                sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n40E > 0, Trim(Str(n40E)) & "X40' Empty", "")
                sGoods = sCntr
                TctBlsIns(VoyageNo)

                n20E = 0
                n40E = 0
                TW = 0
                GW = 0
                Pkgs = 0
                sCntr = ""
                ReturnTo = Dr("ReturnTo")
            End If

            If IsDBNull(Dr("TW")) = True Then
                If Dr("CnSize") = "20" Then
                    TW += 2200
                Else
                    TW += 4500
                End If
            Else
                TW += Dr("TW")
            End If

            If Dr("CnSize") = "20" Then
                n20E = n20E + 1
            Else
                n40E = n40E + 1
            End If
            Pkgs += 1
        Next

        BlNo = CurrentShippingLine & "-MTY-" & ReturnTo
        sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n20E > 0, Trim(Str(n20E)) & "X20' Empty", "")
        sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n40E > 0, Trim(Str(n40E)) & "X40' Empty", "")
        sGoods = sCntr
        TctBlsIns(VoyageNo)

        Tb.AcceptChanges()

        Drs = Tb.Select("Line = '" & CurrentShippingLine & "'", "ReturnTo")

        For Each Dr In Drs
            Try
                BlNo = CurrentShippingLine & "-MTY-" & Dr("ReturnTo")
                rFind = DSTcts.Tables("TbExpMBContainer").Select("MYear = '" & YY & "' and KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & "' and  TripNo = '" & VoyageNo & "' and  ConFlag = '" & CntrFormat(Dr("CntrNo")) & "'", "")
                If rFind.Length = 0 Then
                    NewDr = DSTcts.Tables("TbExpMBContainer").NewRow
                    NewDr("MYEAR") = YY
                    NewDr("KeshtiCode") = TcVessel.Rows(0).Item("Code")
                    NewDr("TripNo") = VoyageNo
                    NewDr("ConFlag") = CntrFormat(Dr("CntrNo"))
                    NewDr("SealNumber") = ""
                    NewDr("CSize") = Dr("CnSize")
                    NewDr("CType") = EcsCnTypeToTCTS(Dr("CnType"))
                    NewDr("NoeInput") = "3"
                    NewDr("MovementType") = "3"
                    NewDr("F_E") = False
                    NewDr("POD") = Left(Trim(NullToValue(Dr("ReturnTo"), "")), 2) & " " & Mid(Trim(NullToValue(Dr("ReturnTo"), "")), 3, 3)
                    NewDr("Des") = Left(Trim(NullToValue(Dr("Destination"), "")), 2) & " " & Mid(Trim(NullToValue(Dr("Destination"), "")), 3, 3)

                    If IsDBNull(Dr("TW")) = True Then
                        If Dr("CnSize") = "20" Then
                            NewDr("TareWeight") = 2200
                        Else
                            NewDr("TareWeight") = 4500
                        End If
                    Else
                        NewDr("TareWeight") = Dr("TW")
                    End If

                    NewDr("TxtJavazWei") = 0
                    NewDr("ContainerOwner") = Co.EDICODE
                    NewDr("IMDGCode") = ""
                    NewDr("TxtTemJavazNo") = "" '
                    NewDr("sTime") = Now()
                    NewDr("ContainerOwner") = Co.EDICODE
                    NewDr("Line") = Line.EDICode
                    If Not SOF Is Nothing Then
                        NewDr("TxtEXPPMT") = NullToValue(SOF.DjwazNo, "?????") ' NullToValue(Dr("ExportPermit"), "")
                    End If
                    DSTcts.Tables("TbExpMBContainer").Rows.Add(NewDr)
                Else
                    MsgBox("Skip  " & CntrFormat(Dr("CntrNo")))
                End If

                NewDr = DSTcts.Tables("TbExpMBLContainer").NewRow
                NewDr("MYEAR") = YY
                NewDr("KeshtiCode") = TcVessel.Rows(0).Item("Code")
                NewDr("TripNo") = VoyageNo
                NewDr("ConFlag") = CntrFormat(Dr("CntrNo"))
                NewDr("BlNumber") = BlNo
                NewDr("NoOfPackage") = 0
                NewDr("NetWeight") = 0
                NewDr("sTime") = Now()
                DSTcts.Tables("TbExpMBLContainer").Rows.Add(NewDr)
            Catch ex As Exception
                MsgBox("Skip  " & CntrFormat(Dr("CntrNo")))
                MsgBox(ex.ToString)
            End Try

        Next

    End Sub

    Private Sub TctBlsIns(ByVal VoyageNo As String)

        Dim NewDr As DataRow
        NewDr = DSTcts.Tables("TbExpMBL").NewRow
        NewDr("MYEAR") = YY
        NewDr("KeshtiCode") = TcVessel.Rows(0).Item("Code")
        NewDr("TripNo") = VoyageNo
        NewDr("BlNumber") = BlNo
        NewDr("GoodDescription") = Left(sGoods, 100)
        NewDr("NoOfPackageBL") = Pkgs
        NewDr("GrossWeight") = GW
        NewDr("Consignee") = CurrentShippingLine
        NewDr("Consignor") = "CARGO SHIPPING CO"
        NewDr("Notify") = CurrentShippingLine
        NewDr("sTime") = Now()
        DSTcts.Tables("TbExpMBL").Rows.Add(NewDr)

        ADBls.Update(DSTcts, "TbExpMBL")

    End Sub

    Public ReadOnly Property TotalCntrs() As Long
        Get
            Return TTLCntrs
        End Get
    End Property
    Public ReadOnly Property CurrentCn() As Long
        Get
            Return Counter
        End Get
    End Property

    Public Function Init(ByVal VoyageNo As String, ByVal sVessel As String) As Boolean

        Dim sSql As String
        Dim NewDr As DataRow

        EdiCnn = New OleDb.OleDbConnection
        EdiCnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & My.Settings.TctsCnn
        EdiCnn.Open()


        sSql = "Select * From TbKeshti where TName = '" & sVessel & "'"
        ADVessel.SelectCommand = New OleDbCommand(sSql, EdiCnn)
        CBVessel = New OleDbCommandBuilder(ADVessel)
        ADVessel.Fill(DSTcts, "TbKeshti")
        TcVessel = DSTcts.Tables("TbKeshti")

        If TcVessel.Rows.Count = 0 Then
            MsgBox("No valid Vessel In TCTS !")
            Return False
        End If

        YY = Mid(ToPersianDate(Date.Today), 3, 2)
        sSql = "delete * from TbKeshtiInput where tripno = '" & VoyageNo & "'"
        ExecuteSqlOnTcts(sSql)

        sSql = "Insert Into TbKeshtiInput (MYear , KeshtiCode , TripNo , ETA) values ('" & YY & "' , '" & TcVessel.Rows(0).Item("Code") & "' , '" & VoyageNo & "' , #" & Format(Now, "Short Date") & "#)"
        ExecuteSqlOnTcts(sSql)

        YY = Mid(ToPersianDate(Date.Today), 3, 2)
        Vesl = sVessel
        Vesl = Replace(Vesl, "-", " ")
        Vesl = Replace(Vesl, "_", " ")



        ExecuteSqlOnTcts("Delete  From TbExpMVoyageID where mYear = '" & YY & _
                                                      "' and KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & _
                                                      "' and TripNo = '" & VoyageNo & "'")
        ExecuteSqlOnTcts("delete from TbExpMBL where mYear = '" & YY & _
                                                      "' and KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & _
                                                      "' and TripNo = '" & VoyageNo & "'")
        ExecuteSqlOnTcts("delete from TbExpMBContainer  where mYear = '" & YY & _
                                                      "' and KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & _
                                                      "' and TripNo = '" & VoyageNo & "'")

        TmpRst = New DataTable
        With TmpRst
            .Columns.Add(New DataColumn("PermitNo", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("BLNO", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Goods", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("TotalGW", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("TotalPkgs", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("FE", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        End With

        sSql = "Select * From TbExpMBContainer where TripNo = '" & VoyageNo & "'"
        ADCns.SelectCommand = New OleDbCommand(sSql, EdiCnn)
        CBCns = New OleDbCommandBuilder(ADCns)
        ADCns.Fill(DSTcts, "TbExpMBContainer")

        sSql = "Select * From TbExpMBLContainer where TripNo = '" & VoyageNo & "'"
        ADBLCns.SelectCommand = New OleDbCommand(sSql, EdiCnn)
        CBBLCns = New OleDbCommandBuilder(ADBLCns)
        ADBLCns.Fill(DSTcts, "TbExpMBLContainer")

        sSql = "Select * From TbExpMBL where TripNo = '" & VoyageNo & "'"
        ADBls.SelectCommand = New OleDbCommand(sSql, EdiCnn)
        CBBls = New OleDbCommandBuilder(ADBls)
        ADBls.Fill(DSTcts, "TbExpMBL")

        sSql = "Select * From TbExpMVoyageID Where TripNo = '" & VoyageNo & "'"
        ADVoy.SelectCommand = New OleDbCommand(sSql, EdiCnn)
        CbVoy = New OleDbCommandBuilder(ADVoy)
        ADVoy.Fill(DSTcts, "TbExpMVoyageID")

        NewDr = DSTcts.Tables("TbExpMVoyageID").NewRow
        NewDr("MYEAR") = YY
        NewDr("KeshtiCode") = TcVessel.Rows(0).Item("Code")
        NewDr("TripNo") = VoyageNo
        NewDr("ArrivalDate") = Now
        NewDr("DepartureDate") = Now
        DSTcts.Tables("TbExpMVoyageID").Rows.Add(NewDr)

        Return True

    End Function

    Private Function EcsCnTypeToTCTS(ByVal sCode As String) As String

        Dim Ans As String
        Select Case sCode
            Case "RS"
                Ans = 2
            Case "FC"
                Ans = 9
            Case "RH"
                Ans = 7
            Case "TK"
                Ans = 6
            Case "SH"
                Ans = 5
            Case "HQ"
                Ans = 5
            Case Else
                Ans = 1
        End Select
        EcsCnTypeToTCTS = Ans

    End Function
    Private Sub ExecuteSqlOnTcts(ByVal sSql As String)

        Dim Cmd As New OleDb.OleDbCommand
        If EdiCnn.State = ConnectionState.Closed Then
            EdiCnn.ConnectionString = My.Settings.TctsCnn
            '          EdiCnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & GetUserConfigItem("TCTSDB") ' C:\Program Files\EDIIP\DB\TCTS_SLS.mdb"
            EdiCnn.Open()
        End If
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = sSql
        Cmd.Connection = EdiCnn
        Cmd.ExecuteNonQuery()

    End Sub

    Function CntrFormat(ByVal sCntr As String)

        Dim nLoop As Byte = 0
        Dim nI As Byte

        Dim nChr As Long
        Dim Pfx As String
        Dim sFx As String
        Dim ChkDgt As String
        Dim Dummy As String = ""
        Dim sS As String
        Dim Result As String

        sCntr = Trim(UCase(sCntr))

        For nI = 1 To Len(sCntr)
            sS = Mid(sCntr, nI, 1)
            If sS = " " Then
                sS = ""
            End If
            Dummy = Dummy & sS
        Next nI

        sCntr = Dummy

        If Len(sCntr) = 11 Then
            Result = Left(sCntr, 4) & Mid(sCntr, 5, 6) & "-" & Right(sCntr, 1)
        Else
            For nI = 1 To 4
                nChr = Asc(Mid(sCntr, nI, 1))
                If (nChr > 64 And nChr < 91) Then
                    Pfx = Pfx & Mid(sCntr, nI, 1)
                Else
                    sFx = sFx & Mid(sCntr, nI, 1)
                End If
            Next nI

            If Len(Pfx) > 4 Then
                sFx = Mid(Pfx, 4) + sFx
                Pfx = Left(Pfx, 4)
            End If

            If Len(sCntr) > 4 Then
                sFx = sFx & Mid(sCntr, 5)
            End If

            ChkDgt = Right(sFx, 1)
            sFx = Left(sFx, Len(sFx) - 1)

            If Pfx = "" Then
                Pfx = "NILL"
            End If

            Result = NullToValue(Pfx, "") & NullToValue(sFx, "") & "-" & NullToValue(ChkDgt, "")

        End If
        Return Result

    End Function
    Private Sub ChgsToText(ByVal UpdDs As DataSet, ByVal VoyageNo As String)


        Dim St As New IO.StreamWriter("c:\Test.txt")
        Dim COL As DataColumn
        Dim sStr As String
        Dim Drs() As DataRow
        Dim sSql As String
        Dim dr As DataRow


        sStr = ""
        For Each COL In UpdDs.Tables("TbExpMVoyageID").Columns
            sStr += COL.ColumnName & "|"
        Next

        St.WriteLine(sStr)
        sSql = "KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & "' And TripNo = '" & VoyageNo & "'"
        Drs = UpdDs.Tables("TbExpMVoyageID").Select(sSql)
        If Drs.Length > 0 Then
            For Each dr In Drs
                sStr = ""
                For Each COL In UpdDs.Tables("TbExpMVoyageID").Columns
                    sStr += dr(COL.ColumnName).ToString & "|"
                Next
                St.WriteLine(sStr)
            Next
        End If

        St.WriteLine("")
        St.WriteLine("TbExpMBL")
        sStr = ""
        For Each COL In UpdDs.Tables("TbExpMBL").Columns
            sStr += COL.ColumnName & "|"
        Next

        St.WriteLine(sStr)
        sSql = "KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & "' And TripNo = '" & VoyageNo & "'"
        Drs = UpdDs.Tables("TbExpMBL").Select(sSql)
        If Drs.Length > 0 Then
            For Each dr In Drs
                sStr = ""
                For Each COL In UpdDs.Tables("TbExpMBL").Columns
                    sStr += dr(COL.ColumnName).ToString & "|"
                Next
                St.WriteLine(sStr)
            Next
        End If


        St.WriteLine("")
        St.WriteLine("TbExpMBContainer")
        sStr = ""
        For Each COL In UpdDs.Tables("TbExpMBContainer").Columns
            sStr += COL.ColumnName & "|"
        Next

        St.WriteLine(sStr)
        sSql = "KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & "' And TripNo = '" & VoyageNo & "'"
        Drs = UpdDs.Tables("TbExpMBContainer").Select(sSql)
        If Drs.Length > 0 Then
            For Each dr In Drs
                sStr = ""
                For Each COL In UpdDs.Tables("TbExpMBContainer").Columns
                    sStr += dr(COL.ColumnName).ToString & "|"
                Next
                St.WriteLine(sStr)
            Next
        End If


        St.WriteLine("")
        St.WriteLine("TbExpMBLContainer")
        sStr = ""
        For Each COL In UpdDs.Tables("TbExpMBLContainer").Columns
            sStr += COL.ColumnName & "|"
        Next

        St.WriteLine(sStr)
        sSql = "KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & "' And TripNo = '" & VoyageNo & "'"
        Drs = UpdDs.Tables("TbExpMBLContainer").Select(sSql)
        If Drs.Length > 0 Then
            For Each dr In Drs
                sStr = ""
                For Each COL In UpdDs.Tables("TbExpMBLContainer").Columns
                    sStr += dr(COL.ColumnName).ToString & "|"
                Next
                St.WriteLine(sStr)
            Next
        End If
        St.WriteLine("")
        St.WriteLine("END")


        St.Flush()
        St.Close()

    End Sub


    Public Sub SendToTctsLoadListFromOutward(ByVal VoyID As Guid, ByVal PrmtSel As DataTable)

        Dim UpdDs As DataSet
        Dim Drs() As DataRow = PrmtSel.Select("Select = true")


        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyID, MatchType.Exact)
        VOY = Dm.GetTB_Voyage

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, VOY.VesselID, MatchType.Exact)
        VE = Dm.GetTB_Vessels


        Dm.QueryCriteria.Clear()
        Co = Dm.GetTB_Company


        'If Drs.Length = 0 Then
        '    If Init(VOY.VoyageNo, VE.VesselName) = True Then
        '        FillTmpForEmptyCntrs(VOY.ID.ToString, VOY.VoyageNo)

        '        ADVoy.Update(DSTcts, "TbExpMVoyageID")
        '        ADBls.Update(DSTcts, "TbExpMBL")
        '        ADCns.Update(DSTcts, "TbExpMBContainer")
        '        ADBLCns.Update(DSTcts, "TbExpMBLContainer")
        '        UpdDs = DSTcts.GetChanges
        '        DSTcts.AcceptChanges()
        '        ChgsToText(DSTcts, VOY.VoyageNo)
        '        MsgBox("Map To TCTS Successful")
        '    End If
        '    Exit Sub
        'End If

        Try
            If Init(VOY.VoyageNo, VE.VesselName) = True Then
                FillTmpForFullCntrsOutward(VOY.VoyageNo, VoyID)
                FillTmpForEmptyCntrs(VOY.ID.ToString, VOY.VoyageNo)
                ADVoy.Update(DSTcts, "TbExpMVoyageID")
                ADBls.Update(DSTcts, "TbExpMBL")
                ADCns.Update(DSTcts, "TbExpMBContainer")
                ADBLCns.Update(DSTcts, "TbExpMBLContainer")
                UpdDs = DSTcts.GetChanges
                DSTcts.AcceptChanges()
                ChgsToText(DSTcts, VOY.VoyageNo)
                MsgBox("Map To TCTS Successful")
            End If
        Catch ex As Exception
            MsgBox("Map Failed !", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub FillTmpForFullCntrsOutward(ByVal VoyageNo As String, ByVal VoyID As Guid)

        Dim Prmt As TB_OutwardBLSCollection
        Dim BL As TB_OutwardBLS
        Dim PrmtDetails As TB_OutwardCntrsCollection
        Dim Goods As TB_OutwardBlsGoods
        Dim NewDr As DataRow
        Dim TmpDrs() As DataRow
        Dim prmtcns As TB_OutwardCntrs
        Dim aFld() As String = {"TW"}
        Dim lResult As Boolean
        Dim CnTw As Long
        Dim Line As TB_Lines
        Dim PkgCode As String
        Dim Code As TB_CODE


        Dm = New DataManager(My.Settings.DSN)

        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Line = Dm.GetTB_Lines
        Dm.QueryCriteria.Clear()


        Co = Dm.GetTB_Company

        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.VoyageID, VoyID, MatchType.Exact)
        Prmt = Dm.GetTB_OutwardBLSCollection
        Dm.QueryCriteria.Clear()



        For Each BL In Prmt
            Pkgs = 0
            GW = 0
            n20E = 0
            n40E = 0
            n20F = 0
            n40F = 0
            sCntr = ""

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_OutwardCntrs.Columns.BLID, BL.ID, MatchType.Exact)
            PrmtDetails = Dm.GetTB_OutwardCntrsCollection

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_OutwardBlsGoods.Columns.BLID, BL.ID, MatchType.Exact)
            Goods = Dm.GetTB_OutwardBlsGoods


            If PrmtDetails.Count > 0 Then
                If PrmtDetails(0).FLE = "F" Then
                    For Each prmtcns In PrmtDetails
                        Dm.QueryCriteria.Clear()
                        If prmtcns.CnSize = "20" Then
                            n20F = n20F + 1
                        Else
                            n40F = n40F + 1
                        End If
                        GW += Double.Parse(NullToValue(prmtcns.GW, 0).ToString)
                        Pkgs += Long.Parse(NullToValue(prmtcns.NoOFPkgs, 0).ToString)
                    Next
                    sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n20E > 0, Trim(Str(n20E)) & "X20' Empty", "")
                    sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n40E > 0, Trim(Str(n40E)) & "X40' Empty", "")

                    sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n20F > 0, Trim(Str(n20F)) & "X20' Full", "")
                    sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n40F > 0, Trim(Str(n40F)) & "X40' Full", "")

                    sGoods = sCntr & " " & ("" & Goods.Goods) & " "
                    sGoods = sGoods & Trim(Str(Pkgs)) & " " & PrmtDetails(0).PackageType & " "
                    sGoods = sGoods & "Destination: " & BL.FPOD & " "
                    sGoods = sGoods ' & "** PERMIT NO. **" & " " & ("" & Prmt.PermitNo)
                    NewDr = TmpRst.NewRow
                    NewDr("PermitNo") = ""
                    NewDr("Goods") = sGoods
                    NewDr("TotalGW") = GW
                    NewDr("TotalPkgs") = Pkgs
                    NewDr("Goods") = sGoods
                    NewDr("BlNO") = BL.BlNo
                    TmpRst.Rows.Add(NewDr)

                End If
            End If
        Next

        For Each Tmp As DataRow In TmpRst.Rows
            BlNo = Tmp("BLNO")
            TmpDrs = DSTcts.Tables("TbExpMBL").Select("mYear = '" & YY & "' and " & _
                            "KeshtiCode = '" & TcVessel.Rows(0).Item("Code") & "' And " & _
                            "TripNo = '" & VoyageNo & "' And " & _
                            "BlNumber = '" & Tmp("BlNo") & "'")
            If TmpDrs.Length = 0 Then
                sGoods = Replace(Tmp("Goods"), " ", " ")
                sGoods = Replace(sGoods, "  ", " ")
                Pkgs = Tmp("TotalPkgs")
                GW = Tmp("TotalGW")
                TctBlsIns(VoyageNo)
            End If
        Next

        For Each BL In Prmt

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_OutwardCntrs.Columns.BLID, BL.ID, MatchType.Exact)
            PrmtDetails = Dm.GetTB_OutwardCntrsCollection
            For Each prmtcns In PrmtDetails

                If PrmtDetails(0).FLE <> "E" Then

                    Try
                        CnTw = prmtcns.TW
                        NewDr = DSTcts.Tables("TbExpMBContainer").NewRow
                        NewDr("MYEAR") = YY
                        NewDr("KeshtiCode") = TcVessel.Rows(0).Item("Code")
                        NewDr("TripNo") = VoyageNo
                        NewDr("ConFlag") = CntrFormat(prmtcns.CntrNo)
                        NewDr("SealNumber") = Mid(prmtcns.SealNo, 1, 10)
                        NewDr("CSize") = prmtcns.CnSize
                        NewDr("CType") = EcsCnTypeToTCTS(prmtcns.CnType)
                        NewDr("NoeInput") = BL.BlStatus
                        NewDr("MovementType") = "3"
                        NewDr("F_E") = True
                        NewDr("POD") = Left(NullToValue(BL.POT, ""), 2) & " " & Right(NullToValue(BL.POT, ""), 3)
                        NewDr("Des") = Left(NullToValue(BL.FPOD, ""), 2) & " " & Right(NullToValue(BL.FPOD, ""), 3)
                        NewDr("TareWeight") = CnTw
                        NewDr("TxtJavazWei") = prmtcns.GW
                        NewDr("ContainerOwner") = Co.EDICODE
                        NewDr("Line") = Line.EDICode

                        NewDr("IMDGCode") = ""
                        NewDr("TxtTemJavazNo") = ""
                        NewDr("TxtEXPPMT") = ""
                        NewDr("sTime") = Now()
                        DSTcts.Tables("TbExpMBContainer").Rows.Add(NewDr)

                        BlNo = BL.BlNo
                        NewDr = DSTcts.Tables("TbExpMBLContainer").NewRow
                        NewDr("MYEAR") = YY
                        NewDr("KeshtiCode") = TcVessel.Rows(0).Item("Code")
                        NewDr("TripNo") = VoyageNo
                        NewDr("ConFlag") = CntrFormat(prmtcns.CntrNo)
                        NewDr("BlNumber") = BlNo
                        NewDr("NoOfPackage") = Double.Parse(prmtcns.NoOFPkgs)
                        NewDr("NetWeight") = Double.Parse(prmtcns.GW.ToSqlString)
                        NewDr("sTime") = Now()
                        PkgCode = "PK"
                        Dm.QueryCriteria.Clear()
                        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PG", MatchType.Exact)
                        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, prmtcns.PackageType, MatchType.Exact)
                        Code = Dm.GetTB_CODE
                        If Not Code Is Nothing Then
                            PkgCode = Code.NextCode
                        End If
                        NewDr("TxtPackType") = PkgCode '  prmtcns.PackageType
                        DSTcts.Tables("TbExpMBLContainer").Rows.Add(NewDr)

                    Catch ex As Exception
                        MsgBox("Skiped Container " & prmtcns.CntrNo)
                    End Try

                End If

            Next
        Next

    End Sub
 

End Class
