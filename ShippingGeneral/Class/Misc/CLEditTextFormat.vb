Imports System.Text
Imports System.IO
Imports ShippingBiz
Imports OrmLib

Public Class CLEditTextFormat

    Private TbExpMBL As DataTable
    Private TbExpMBContainer As DataTable
    Private TbExpMBLContainer As DataTable

    Private ExpMBL As StringBuilder
    Private ExpMBContainer As StringBuilder
    Private ExpMBLContainer As StringBuilder

    Private BL As TB_OutwardBLS
    Private Cn As TB_OutwardCntrs
    Private Cns As TB_OutwardCntrsCollection

    Private Permit As TB_Permits
    Private PrmtDetails As TB_PermitDetailsCollection
    Private PrmtDetail As TB_PermitDetails
    Private Ecs As TB_EcsContainers
    Private Voy As TB_Voyage
    Private Vsl As TB_Vessels
    Private YY As String

    Private DM As DataManager

    Public Sub GenEDITextFormatByPermit(ByVal PermitNo As String)

        Dim n20F As Int16
        Dim n40F As Int16

        Dim n20E As Int16
        Dim n40E As Int16

        Dim GW As Double
        Dim Pkgs As Int32

        Dim sSql As String
        Dim lResult As Boolean
        Dim aFld() As String = {"TW"}

        Dim sCntr As String
        Dim sGoods As String

        Dim TW As Int32
        Dim NewDr As DataRow

        Dim BLNO As String
        Dim CnTw As Integer

        Dim CnDrs() As DataRow
        Dim PkgCode As String

        Dim Code As TB_CODE

        Dim tbTIP As DataTable

        Dim Vsl As TB_Vessels

        DM = New DataManager(My.Settings.DSN)

        DM.QueryCriteria.And(JoinPath.TB_Permits.Columns.PermitNo, PermitNo, MatchType.Exact)
        Permit = DM.GetTB_Permits

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_PermitDetails.Columns.PermitID, Permit.ID, MatchType.Exact)
        PrmtDetails = DM.GetTB_PermitDetailsCollection

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
        Vsl = DM.GetTB_Vessels

        If PrmtDetails.Count > 0 Then
            If PrmtDetails(0).FLE <> "E" Then
                For Each prmtcns In PrmtDetails
                    Debug.Print(prmtcns.CntrID.ToString)
                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, prmtcns.CntrID, MatchType.Exact)
                    Ecs = DM.GetTB_EcsContainers
                    Try
                        If Ecs.OutVoyageID.ToString = Voy.ID.ToString Then
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
                Dim sql As String
                Dim TB As DataTable
                Dim JResult As Boolean
                'sql = "Select TW from [dbo].[TB_EcsContainers] Where InVoyageID = '" & Ecs.InVoyageID.ToString & "' and CntrNo = '" & Ecs.CntrNo & "'"
                sql = " select TW from [TB_ECSBank] where cntrno = '" & Ecs.CntrNo & "'"
                TableBySql(sql, TB, JResult)
                If TB.Rows.Count > 0 Then
                    If IsDBNull(TB.Rows(0).Item("TW")) Or TB.Rows(0).Item("TW").ToString() = "" Or TB.Rows(0).Item("TW").ToString() = "0" Then
                        sSql = "Select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Ecs.InVoyageID.ToString & "' , '" & Ecs.CntrNo & "') As TW"
                        TW = Val(FieldsBySql(sSql, aFld, lResult).Item(0).ToString)
                        If lResult = False Then
                            If Ecs.CnSize = "20" Then
                                TW = 2200
                            Else
                                TW = 4500
                            End If

                        End If
                    Else
                        'sSql = "Select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Ecs.InVoyageID.ToString & "' , '" & Ecs.CntrNo & "') As TW"
                        'TW = Val(FieldsBySql(sSql, aFld, lResult).Item(0).ToString)
                        'If lResult = False Then
                        TW = Val(TB.Rows(0).Item("TW"))
                        'End If
                    End If
                Else
                    sSql = "Select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Ecs.InVoyageID.ToString & "' , '" & Ecs.CntrNo & "') As TW"
                    TW = Val(FieldsBySql(sSql, aFld, lResult).Item(0).ToString)
                    If lResult = False Then
                        If Ecs.CnSize = "20" Then
                            TW = 2200
                        Else
                            TW = 4500
                        End If

                    End If
                End If
                sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n20E > 0, Trim(Str(n20E)) & "X20' Empty", "")
                sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n40E > 0, Trim(Str(n40E)) & "X40' Empty", "")

                sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n20F > 0, Trim(Str(n20F)) & "X20' Full", "")
                sCntr = IIf(sCntr = "", "", sCntr & " ") & IIf(n40F > 0, Trim(Str(n40F)) & "X40' Full", "")

                sGoods = sCntr & " " & ("" & Permit.Goods) & " "
                sGoods = sGoods & Trim(Str(Pkgs)) & " " & PrmtDetails(0).PackageType & " "
                sGoods = sGoods & "Destination: " & Permit.FPOD & " "
                sGoods = sGoods & "** PERMIT NO. **" & " " & ("" & Permit.PermitNo)

            End If
        End If

        BLNO = CurrentShippingLine & "-" & Permit.PermitNo

        NewDr = TbExpMBL.NewRow
        NewDr("MYear") = YY
        NewDr("KeshtiCode") = Vsl.IMONo
        NewDr("TripNo") = Voy.VoyageNo
        NewDr("BLNumber") = BLNO
        NewDr("GoodDescription") = Left(sGoods, 100)
        NewDr("NoOfPackageBL") = Pkgs
        NewDr("TypeOfPackageBL") = PrmtDetails(0).PackageType
        NewDr("GrossWeight") = GW
        NewDr("Consignee") = CurrentShippingLine
        NewDr("Consignor") = "CARGO SHIPPING CO"
        NewDr("Notify") = CurrentShippingLine
        '        NewDr("BlCode") = 0
        NewDr("Remark") = ""
        NewDr("Stime") = Date.Today
        TbExpMBL.Rows.Add(NewDr)

        For Each prmtcns In PrmtDetails

            If PrmtDetails(0).FLE <> "E" Then
                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, prmtcns.CntrID, MatchType.Exact)
                Ecs = DM.GetTB_EcsContainers
                'Try

                If Ecs.OutVoyageID.ToString = Voy.ID.ToString Then
                    Dim sql As String
                    Dim TB As DataTable
                    Dim JResult As Boolean
                    'sql = "Select TW from [dbo].[TB_EcsContainers] Where InVoyageID = '" & Ecs.InVoyageID.ToString & "' and CntrNo = '" & Ecs.CntrNo & "'"
                    sql = " select TW from [TB_ECSBank] where cntrno = '" & Ecs.CntrNo & "'"
                    TableBySql(sql, TB, JResult)
                    If TB.Rows.Count > 0 Then
                        If IsDBNull(TB.Rows(0).Item("TW")) Or TB.Rows(0).Item("TW").ToString() = "" Or TB.Rows(0).Item("TW").ToString() = "0" Then
                            sSql = "Select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Ecs.InVoyageID.ToString & "' , '" & Ecs.CntrNo & "') As TW"
                            CnTw = Val(FieldsBySql(sSql, aFld, lResult).Item(0).ToString)
                            If lResult = False Then
                                If Ecs.CnSize = "20" Then
                                    CnTw = 2200
                                Else
                                    CnTw = 4500
                                End If

                            End If
                        Else
                            'sSql = "Select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Ecs.InVoyageID.ToString & "' , '" & Ecs.CntrNo & "') As TW"
                            'CnTw = Val(FieldsBySql(sSql, aFld, lResult).Item(0).ToString)
                            'If lResult = False Then
                            CnTw = Val(TB.Rows(0).Item("TW"))
                            'End If
                        End If
                    Else
                        sSql = "Select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Ecs.InVoyageID.ToString & "' , '" & Ecs.CntrNo & "') As TW"
                        CnTw = Val(FieldsBySql(sSql, aFld, lResult).Item(0).ToString)
                        If lResult = False Then
                            If Ecs.CnSize = "20" Then
                                CnTw = 2200
                            Else
                                CnTw = 4500
                            End If

                        End If
                    End If
                    CnDrs = TbExpMBContainer.Select("KeshtiCode = " & Vsl.IMONo & " and TripNo = '" & Voy.VoyageNo & "' and ConFlag = '" & CntrFormat(Ecs.CntrNo) & "'")
                    'TIP No - appu
                    sSql = "Select dbo.FC_GetTIPByPermitVoy('" & Voy.ID.ToString & "' , '" & Permit.PermitNo & "', '" & Ecs.CntrNo & "') as InDjwazNo"
                    TableBySql(sSql, tbTIP, lResult)
                    

                        If CnDrs.Length = 0 Then
                            NewDr = TbExpMBContainer.NewRow
                            NewDr("MYEAR") = YY
                            NewDr("KeshtiCode") = Vsl.IMONo
                            NewDr("TripNo") = Voy.VoyageNo
                            NewDr("ConFlag") = CntrFormat(Ecs.CntrNo)
                            NewDr("SealNumber") = prmtcns.SealNo
                            NewDr("CSize") = Ecs.CnSize
                            'NewDr("CType") = EcsCnTypeToTCTS(Ecs.CnType)
                            NewDr("CType") = Ecs.CnType
                            NewDr("NoeInput") = Permit.Status
                            NewDr("MovementType") = "3"
                            NewDr("F_E") = IIf(prmtcns.FLE = "E", "0", "-1")
                            NewDr("POD") = Left(NullToValue(Permit.POT, ""), 2) & "  " & Right(NullToValue(Permit.POT, ""), 3)
                            NewDr("Des") = Left(NullToValue(Permit.FPOD, ""), 2) & " " & Right(NullToValue(Permit.FPOD, ""), 3)
                            NewDr("TareWeight") = CnTw
                            NewDr("TxtJavazWei") = prmtcns.GW
                            NewDr("ContainerOwner") = CurrentShippingLine
                            NewDr("Line") = "0000"

                            NewDr("IMDGCode") = Permit.IMDGCode
                            NewDr("EquipmentFlashPoint") = Permit.FlashPoint.ToString
                            NewDr("HazardPageNumber") = Permit.PageNumber.ToString
                            NewDr("UNNumber") = Permit.UNNumber
                            'NewDr("UNNumber") = ""
                            NewDr("TxtTemJavazNo") = ""
                            'NewDr("HazardVersion") = Permit.PermitNo
                            NewDr("HazardVersion") = ""
                            NewDr("TxtRfTem") = NullToValue(prmtcns.TempMin, "")
                        If lResult = True Then
                            NewDr("TIP") = tbTIP.Rows(0).Item("InDjwazNo")
                        Else
                            NewDr("TIP") = "50100-"
                        End If
                        NewDr("ExpPermission") = "50100-" + Permit.PermitNo


                        'If NullToValue(prmtcns.TempMin, -10000) <> -10000 Then
                        '    NewDr("TxtRfTem") = prmtcns.TempMin
                        'End If

                        NewDr("sTime") = Now()
                        TbExpMBContainer.Rows.Add(NewDr)

                        BLNO = CurrentShippingLine & "-" & Permit.PermitNo
                        NewDr = TbExpMBLContainer.NewRow
                        NewDr("MYEAR") = YY
                        NewDr("KeshtiCode") = Vsl.IMONo
                        NewDr("TripNo") = Voy.VoyageNo
                        NewDr("ConFlag") = CntrFormat(Ecs.CntrNo)
                        NewDr("BlNumber") = BLNO
                        NewDr("NoOfPackage") = Int64.Parse(prmtcns.NoOFPkgs.ToString)
                        NewDr("NetWeight") = Double.Parse(prmtcns.GW.ToString)
                        NewDr("sTime") = Now()
                        PkgCode = "PK"
                        DM.QueryCriteria.Clear()
                        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PG", MatchType.Exact)
                        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, prmtcns.PackageType, MatchType.Exact)
                        Code = DM.GetTB_CODE
                        If Not Code Is Nothing Then
                            PkgCode = Code.NextCode
                        End If
                        NewDr("TxtPackType") = PkgCode
                        TbExpMBLContainer.Rows.Add(NewDr)
                    Else
                        CnDrs(0).Item("TxtJavazWei") = Val(CnDrs(0).Item("TxtJavazWei")) + prmtcns.GW
                    End If
                    End If
                    'Catch ex As Exception
                    '    MsgBox("Skiped Container " & Ecs.CntrNo)
                    ' End Try

                End If

        Next

    End Sub

    Public Sub GenEDITextFormatByPermit_CCS(ByVal PermitNo As String)

        Dim n20F As Int16
        Dim n40F As Int16

        Dim n20E As Int16
        Dim n40E As Int16

        Dim GW As Double
        Dim Pkgs As Int32

        Dim sSql As String
        Dim lResult As Boolean
        Dim aFld() As String = {"TW"}

        Dim sCntr As String
        Dim sGoods As String

        Dim TW As Int32
        Dim NewDr As DataRow

        Dim BLNO As String
        Dim CnTw As Integer

        Dim CnDrs() As DataRow
        Dim PkgCode As String

        Dim Code As TB_CODE

        Dim Vsl As TB_Vessels
        DM = New DataManager(My.Settings.DSN)


        DM.QueryCriteria.And(JoinPath.TB_Permits.Columns.PermitNo, PermitNo, MatchType.Exact)
        Permit = DM.GetTB_Permits

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_PermitDetails.Columns.PermitID, Permit.ID, MatchType.Exact)
        PrmtDetails = DM.GetTB_PermitDetailsCollection

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
        Vsl = DM.GetTB_Vessels

        If PrmtDetails.Count > 0 Then
            If PrmtDetails(0).FLE <> "E" Then
                For Each prmtcns In PrmtDetails
                    Debug.Print(prmtcns.CntrID.ToString)
                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, prmtcns.CntrID, MatchType.Exact)
                    Ecs = DM.GetTB_EcsContainers
                    Try
                        If Ecs.OutVoyageID.ToString = Voy.ID.ToString Then
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

                sGoods = sCntr & " " & ("" & Permit.Goods) & " "
                sGoods = sGoods & Trim(Str(Pkgs)) & " " & PrmtDetails(0).PackageType & " "
                sGoods = sGoods & "Destination: " & Permit.FPOD & " "
                sGoods = sGoods & "** PERMIT NO. **" & " " & ("" & Permit.PermitNo)

            End If
        End If

        BLNO = CurrentShippingLine & "-" & Permit.PermitNo

        NewDr = TbExpMBL.NewRow
        NewDr("MYear") = YY
        NewDr("KeshtiCode") = Vsl.IMONo
        NewDr("TripNo") = Voy.VoyageNo
        NewDr("BLNumber") = BLNO
        NewDr("GoodDescription") = Left(sGoods, 100)
        NewDr("NoOfPackageBL") = Pkgs
        NewDr("TypeOfPackageBL") = ""
        NewDr("GrossWeight") = GW
        NewDr("Consignee") = CurrentShippingLine
        NewDr("Consignor") = "CARGO SHIPPING CO"
        NewDr("Notify") = CurrentShippingLine
        '        NewDr("BlCode") = 0
        NewDr("Remark") = ""
        NewDr("Stime") = Date.Today
        TbExpMBL.Rows.Add(NewDr)

        For Each prmtcns In PrmtDetails

            If PrmtDetails(0).FLE <> "E" Then
                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, prmtcns.CntrID, MatchType.Exact)
                Ecs = DM.GetTB_EcsContainers
                'Try

                If Ecs.OutVoyageID.ToString = Voy.ID.ToString Then
                    sSql = "Select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Ecs.InVoyageID.ToString & "' , '" & Ecs.CntrNo & "') As TW"
                    CnTw = Val(FieldsBySql(sSql, aFld, lResult).Item(0).ToString)
                    If lResult = False Then
                        If Ecs.CnSize = "20" Then
                            CnTw = 2200
                        Else
                            CnTw = 4500
                        End If
                    End If
                    CnDrs = TbExpMBContainer.Select("KeshtiCode = " & Vsl.IMONo & " and TripNo = '" & Voy.VoyageNo & "' and ConFlag = '" & CntrFormat(Ecs.CntrNo) & "'")
                    If CnDrs.Length = 0 Then
                        NewDr = TbExpMBContainer.NewRow
                        NewDr("MYEAR") = YY
                        NewDr("KeshtiCode") = Vsl.IMONo
                        NewDr("TripNo") = Voy.VoyageNo
                        NewDr("ConFlag") = CntrFormat(Ecs.CntrNo)
                        NewDr("SealNumber") = prmtcns.SealNo
                        NewDr("CSize") = Ecs.CnSize
                        'NewDr("CType") = EcsCnTypeToTCTS(Ecs.CnType)
                        NewDr("CType") = Ecs.CnType
                        NewDr("NoeInput") = Permit.Status
                        NewDr("MovementType") = "3"
                        NewDr("F_E") = IIf(prmtcns.FLE = "E", "0", "-1")
                        NewDr("POD") = Left(NullToValue(Permit.POT, ""), 2) & "  " & Right(NullToValue(Permit.POT, ""), 3)
                        NewDr("Des") = Left(NullToValue(Permit.FPOD, ""), 2) & " " & Right(NullToValue(Permit.FPOD, ""), 3)
                        NewDr("TareWeight") = CnTw
                        NewDr("TxtJavazWei") = prmtcns.GW
                        NewDr("ContainerOwner") = CurrentShippingLine
                        NewDr("Line") = "0"

                        NewDr("IMDGCode") = Permit.IMDGCode
                        NewDr("EquipmentFlashPoint") = Permit.FlashPoint.ToString
                        NewDr("HazardPageNumber") = Permit.PageNumber.ToString
                        NewDr("HazardVersion") = Permit.UNNumber
                        NewDr("TxtTemJavazNo") = ""
                        NewDr("TxtEXPPMT") = Permit.PermitNo
                        NewDr("TxtRfTem") = NullToValue(prmtcns.TempMin, "")

                        'If NullToValue(prmtcns.TempMin, -10000) <> -10000 Then
                        '    NewDr("TxtRfTem") = prmtcns.TempMin
                        'End If

                        NewDr("sTime") = Now()
                        TbExpMBContainer.Rows.Add(NewDr)

                        BLNO = CurrentShippingLine & "-" & Permit.PermitNo
                        NewDr = TbExpMBLContainer.NewRow
                        NewDr("MYEAR") = YY
                        NewDr("KeshtiCode") = Vsl.IMONo
                        NewDr("TripNo") = Voy.VoyageNo
                        NewDr("ConFlag") = CntrFormat(Ecs.CntrNo)
                        NewDr("BlNumber") = BLNO
                        NewDr("NoOfPackage") = Int64.Parse(prmtcns.NoOFPkgs.ToString)
                        NewDr("NetWeight") = Double.Parse(prmtcns.GW.ToString)
                        NewDr("sTime") = Now()
                        PkgCode = "PK"
                        DM.QueryCriteria.Clear()
                        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PG", MatchType.Exact)
                        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, prmtcns.PackageType, MatchType.Exact)
                        Code = DM.GetTB_CODE
                        If Not Code Is Nothing Then
                            PkgCode = Code.NextCode
                        End If
                        NewDr("TxtPackType") = PkgCode
                        TbExpMBLContainer.Rows.Add(NewDr)
                    Else
                        CnDrs(0).Item("TxtJavazWei") = Val(CnDrs(0).Item("TxtJavazWei")) + prmtcns.GW
                    End If
                End If
                'Catch ex As Exception
                '    MsgBox("Skiped Container " & Ecs.CntrNo)
                ' End Try

            End If

        Next

    End Sub

    Public Sub GenEDITextFormatByLineBL(ByVal Line As String, ByVal BlNo As String)

        DM = New DataManager(My.Settings.DSN)

        Dim Co As TB_Company
        Dim Vsl As TB_Vessels

        Dim SOFs As TB_SOFCollection

        Dim Code As TB_CODE
        Dim ds As New DataSet

        Dim aTables() As String = {"TB_OutwardBls", "Tb_OutwardBlsNames", "TB_OutwardBlsGoods", "TB_OutwardCharges", "Tb_OutwardCntrs", "TB_OutwardCnsImco", "TB_OutwardCnsTemprature", "TB_OutwardCnsPkgs"}


        Dim SelTable As New DataTable
        Dim TVessel As New DataTable
        Dim Tmp As New DataTable
        Dim NewDr As DataRow
        Dim nI As Int16
        Dim TTLGW As Double = 0
        Dim TTLPkgs As Long
        Dim PkgCode As String = ""
        Dim Crt As String
        Dim Dv As DataView

        Dim TctsVslcode As String
        Dim aErrorList As New ArrayList
        Dim DummyImco As TB_OutwardCnsImco


        Dim TBSOC As New DataTable
        Dim DrSoc As DataRow

        Dim Bls As TB_OutwardBLS
        Dim Lines As TB_Lines
        Dim Names As TB_OutwardBlsNames
        Dim Goods As TB_OutwardBlsGoods
        Dim Imco As TB_OutwardCnsImcoCollection

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Voy.ID, MatchType.Exact)
        SOFs = DM.GetTB_SOFCollection

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
        Vsl = DM.GetTB_Vessels

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Lines = DM.GetTB_Lines

        DM.QueryCriteria.Clear()
        Co = DM.GetTB_Company

        TctsVslcode = Vsl.IMONo
  
        DM = New DataManager(My.Settings.DSN)
        ds = StoredProcedures.SP_OutwardAllDataByLineBlNo(CurrentShippingLine, BlNo)
        DM.PopulateObjectsFromDataSet(ds, aTables)

        For nI = 0 To aTables.Length - 1
            DM.DataSet.Tables(aTables(nI)).Merge(ds.Tables(nI))
        Next

        If DM.DataSet.Tables("TB_OutwardBls").Rows.Count > 0 Then
            Bls = DM.GetTB_OutwardBLSCollection.FilterByBlNo(BlNo)(0)
            Cns = DM.GetTB_OutwardCntrsCollectionFromDataSet
            Names = DM.GetTB_OutwardBlsNamesCollectionFromDataSet(0)
            Goods = DM.GetTB_OutwardBlsGoodsCollectionFromDataSet(0)
            Imco = DM.GetTB_OutwardCnsImcoCollection
            TTLGW = 0
            PkgCode = "PK"
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PG", MatchType.Exact)
            DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, Cns(0).PackageType, MatchType.Exact)
            Code = DM.GetTB_CODE
            If Not Code Is Nothing Then
                PkgCode = Code.NextCode
            End If

      
            NewDr = TbExpMBL.NewRow
            NewDr("MYEAR") = YY
            NewDr("KeshtiCode") = Vsl.IMONo
            NewDr("TripNo") = Voy.VoyageNo
            NewDr("BlNumber") = Bls.BlNo
            '      NewDr("TypeOfPackage") = PkgCode
            NewDr("BLCODE") = 0 ' nCount

            'If Not Goods Is Nothing Then
            '    NewDr("GrossWeight") = Double.Parse(Goods.TGW)
            '    NewDr("NoOfPackage") = Int32.Parse(Goods.TTLPkgs)
            '    NewDr("GoodDescription") = CleanStr(UCase(Goods.Goods))
            'End If

            If Not Names Is Nothing Then
                NewDr("Consignee") = Mid(CleanStr(UCase(Names.Cnee)), 1, 130)
                NewDr("Consignor") = "Gest"
                NewDr("Notify") = Mid(CleanStr(UCase(Names.Notify1)), 1, 130)
            End If

            TbExpMBL.Rows.Add(NewDr)

            For Each Cn In Cns
                Dv = New DataView(TbExpMBContainer, "MYEAR = '" & YY & "' and KeshtiCode = '123' and ConFlag = '" & CntrFormat(Cn.CntrNo) & "'", "", DataViewRowState.CurrentRows)
                If Dv.Count = 0 Then
                    NewDr = TbExpMBContainer.NewRow
                    NewDr("MYEAR") = YY
                    NewDr("KeshtiCode") = Vsl.IMONo
                    NewDr("TripNo") = Voy.VoyageNo
                    NewDr("ConFlag") = CntrFormat(Cn.CntrNo)
                    NewDr("SealNumber") = Mid(CleanStr(UCase(Cn.SealNo)), 1, 10)
                    NewDr("CSize") = Cn.CnSize
                    NewDr("CType") = OurTypeToTCTSIP(Cn.CnType)
                    NewDr("NoeInput") = Bls.BlStatus
                    ' Change for SOC containers

                    'NewDr("MovementType") = IIf(Cn.FLE = "L", 2, 3)

                    NewDr("F_E") = IIf(Cn.FLE = "E", "0", "-1")
                    NewDr("MovementType") = 0 'IIf(Cn.FLE = "L", 2, 3)
                    NewDr("POD") = Left(NullToValue(Bls.POD, ""), 2) & "  " & Right(NullToValue(Bls.POD, ""), 3) 'GetEDIPORT(NullToValue(Bls.POD, " "))
                    NewDr("Des") = GetEDIPORT(NullToValue(Bls.FPOD, ""))
                    NewDr("TareWeight") = Int32.Parse(Cn.TW)
                    NewDr("TxtJavazWei") = Int32.Parse(Cn.GW)
                    NewDr("ContainerOwner") = Co.EDICODE
                    'NewDr("ContainerAgent") = ""
                    NewDr("UNNumber") = NullToValue(Permit.UNNumber, "")
                    NewDr("HazardPageNumber") = ""
                    NewDr("EquipmentFlashPoint") = 0
                    NewDr("HazardVersion") = "" 'Bls.PermitNo
                    NewDr("TxtTemJavazNo") = "" ' Cn.MtyDjwaz
                    'NewDr("FPMeasureUnit") = 0
                    'NewDr("PackingGroupCode") = ""
                    'NewDr("TFlag") = False
                    'NewDr("TypeLCL") = ""
                    'NewDr("DamageAva") = False
                    DummyImco = Imco.FindByCntrID(Cn.ID)
                    If Not DummyImco Is Nothing Then
                        NewDr("IMDGCode") = DummyImco.IMDGCode
                    End If
                    TbExpMBContainer.Rows.Add(NewDr)
                End If

                NewDr = TbExpMBLContainer.NewRow
                NewDr("MYEAR") = YY
                NewDr("KeshtiCode") = Vsl.IMONo
                NewDr("TripNo") = Voy.VoyageNo
                NewDr("ConFlag") = CntrFormat(Cn.CntrNo)
                NewDr("BlNumber") = Bls.BlNo
                NewDr("NetWeight") = Double.Parse(Cn.GW)
                TTLGW += Cn.GW
                NewDr("Strip") = ""
                TTLPkgs = TTLPkgs + Cn.NoOFPkgs
                NewDr("NoOfPackage") = Int32.Parse(Cn.NoOFPkgs.ToString)
                TbExpMBLContainer.Rows.Add(NewDr)
                Dv = New DataView(TbExpMBL, "BlNumber = '" & Bls.BlNo & "'", "", DataViewRowState.CurrentRows)
                If Dv.Count > 0 Then
                    Dv.Item(0).Item("GrossWeight") = Format(TTLGW, ".00")
                End If
            Next
        End If



    End Sub
    Public Sub New(ByVal VoyageID As Guid)


        ExpMBL = New StringBuilder
        ExpMBContainer = New StringBuilder
        ExpMBLContainer = New StringBuilder

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyageID, MatchType.Exact)
        Voy = DM.GetTB_Voyage

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
        Vsl = DM.GetTB_Vessels
        YY = Mid(ToPersianDate(Date.Today), 3, 2)

        '      ExpMBL.AppendLine("TbExpMBL")
        ExpMBL.AppendLine("MYear|KeshtiCode|TripNo|POD|POL|ArrivalDate|DepartureDate|ManiFestCode|BarnamehNoIn|")
        ExpMBL.AppendLine(YY & "|" & Vsl.IMONo & "|" & Voy.VoyageNo & "|||" & Today.Date.ToString & "|" & Today.Date.ToString & "||2")

        ExpMBL.AppendLine("")
        ExpMBL.AppendLine("TbExpMBL")
        ExpMBL.AppendLine("MYear|KeshtiCode|TripNo|BLNumber|GoodDescription|NoOfPackageBL|TypeOfPackageBL|GrossWeight|Consignee|Consignor|Notify|BlCode|Remark|Stime|")

        ExpMBContainer.AppendLine("")
        ExpMBContainer.AppendLine("TbExpMBContainer")
        ExpMBContainer.AppendLine("MYear|KeshtiCode|TripNo|ConFlag|SealNumber|CSize|CType|NoeInput|F_E|MovementType|POD|Des|TareWeight|TxtJavazWei|ContainerOwner|TxtPlanSto|IMDGCode|UNNumber|HazardPageNumber|EquipmentFlashPoint|TxtHumm|TxtVentilation|TxtRfTem|TxtTemJavazNo|HazardVersion|Remark|Stime|Line|TIP|ExpPermission|")

        ExpMBLContainer.AppendLine("")
        ExpMBLContainer.AppendLine("TbExpMBLContainer")
        ExpMBLContainer.AppendLine("MYear|KeshtiCode|TripNo|BLNumber|ConFlag|NoOfPackage|TxtPackType|NetWeight|Strip|Stime|")

        TbExpMBL = New DataTable
        With TbExpMBL.Columns
            .Add(New DataColumn("MYear"))
            .Add(New DataColumn("KeshtiCode"))
            .Add(New DataColumn("TripNo"))
            .Add(New DataColumn("BLNumber"))
            .Add(New DataColumn("GoodDescription"))
            .Add(New DataColumn("NoOfPackageBL", System.Type.GetType("System.Int32")))
            .Add(New DataColumn("TypeOfPackageBL"))
            .Add(New DataColumn("GrossWeight", System.Type.GetType("System.Double")))
            .Add(New DataColumn("Consignee"))
            .Add(New DataColumn("Consignor"))
            .Add(New DataColumn("Notify"))
            .Add(New DataColumn("BlCode", System.Type.GetType("System.Int16")))
            .Add(New DataColumn("Remark"))
            .Add(New DataColumn("Stime", System.Type.GetType("System.DateTime")))
        End With

        TbExpMBContainer = New DataTable
        With TbExpMBContainer.Columns
            .Add(New DataColumn("MYear"))
            .Add(New DataColumn("KeshtiCode"))
            .Add(New DataColumn("TripNo"))
            .Add(New DataColumn("ConFlag"))
            .Add(New DataColumn("SealNumber"))
            .Add(New DataColumn("CSize"))
            .Add(New DataColumn("CType"))
            .Add(New DataColumn("NoeInput"))
            .Add(New DataColumn("F_E")) ', System.Type.GetType("System.Boolean")))
            .Add(New DataColumn("MovementType"))
            .Add(New DataColumn("POD"))
            .Add(New DataColumn("Des"))
            .Add(New DataColumn("TareWeight", System.Type.GetType("System.Int32")))
            .Add(New DataColumn("TxtJavazWei"))
            .Add(New DataColumn("ContainerOwner"))
            .Add(New DataColumn("TxtPlanSto"))
            .Add(New DataColumn("IMDGCode"))
            .Add(New DataColumn("UNNumber"))
            .Add(New DataColumn("HazardPageNumber"))
            .Add(New DataColumn("EquipmentFlashPoint"))
            .Add(New DataColumn("TxtHumm"))
            .Add(New DataColumn("TxtVentilation"))
            .Add(New DataColumn("TxtRfTem"))
            .Add(New DataColumn("TxtTemJavazNo"))
            .Add(New DataColumn("HazardVersion"))
            .Add(New DataColumn("Remark"))
            .Add(New DataColumn("Stime", System.Type.GetType("System.DateTime")))
            .Add(New DataColumn("Line"))
            .Add(New DataColumn("TIP"))
            .Add(New DataColumn("ExpPermission"))
        End With

        TbExpMBLContainer = New DataTable
        With TbExpMBLContainer.Columns
            .Add(New DataColumn("MYear"))
            .Add(New DataColumn("KeshtiCode"))
            .Add(New DataColumn("TripNo"))
            .Add(New DataColumn("BLNumber"))
            .Add(New DataColumn("ConFlag"))
            .Add(New DataColumn("NoOfPackage", System.Type.GetType("System.Int32")))
            .Add(New DataColumn("TxtPackType"))
            .Add(New DataColumn("NetWeight", System.Type.GetType("System.Int32")))
            .Add(New DataColumn("Strip"))
            .Add(New DataColumn("Stime", System.Type.GetType("System.DateTime")))
        End With
      
    End Sub
    Public Sub New(ByVal VoyageID As Guid, ByVal CCS As String)


        ExpMBL = New StringBuilder
        ExpMBContainer = New StringBuilder
        ExpMBLContainer = New StringBuilder

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyageID, MatchType.Exact)
        Voy = DM.GetTB_Voyage
       
        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
        Vsl = DM.GetTB_Vessels

        YY = Mid(ToPersianDate(Date.Today), 3, 2)

        '      ExpMBL.AppendLine("TbExpMBL")
        ExpMBL.AppendLine("MYear|KeshtiCode|TripNo|POD|POL|ArrivalDate|DepartureDate|ManiFestCode|BarnamehNoIn|")
        ExpMBL.AppendLine(YY & "|" & Vsl.IMONo & "|" & Voy.VoyageNo & "|||" & Today.Date.ToString & "|" & Today.Date.ToString & "||2")

        ExpMBL.AppendLine("")
        ExpMBL.AppendLine("TbExpMBL")
        ExpMBL.AppendLine("MYear|KeshtiCode|TripNo|BLNumber|GoodDescription|NoOfPackageBL|TypeOfPackageBL|GrossWeight|Consignee|Consignor|Notify|BlCode|Remark|Stime|")

        ExpMBContainer.AppendLine("")
        ExpMBContainer.AppendLine("TbExpMBContainer")
        ExpMBContainer.AppendLine("MYear|KeshtiCode|TripNo|ConFlag|SealNumber|CSize|CType|NoeInput|F_E|MovementType|POD|Des|TareWeight|TxtJavazWei|ContainerOwner|TxtPlanSto|IMDGCode|HazardVersion|HazardPageNumber|EquipmentFlashPoint|TxtHumm|TxtVentilation|TxtRfTem|TxtTemJavazNo|TxtEXPPMT|Remark|Stime|Line|")

        ExpMBLContainer.AppendLine("")
        ExpMBLContainer.AppendLine("TbExpMBLContainer")
        ExpMBLContainer.AppendLine("MYear|KeshtiCode|TripNo|BLNumber|ConFlag|NoOfPackage|TxtPackType|NetWeight|Strip|Stime|")

        TbExpMBL = New DataTable
        With TbExpMBL.Columns
            .Add(New DataColumn("MYear"))
            .Add(New DataColumn("KeshtiCode"))
            .Add(New DataColumn("TripNo"))
            .Add(New DataColumn("BLNumber"))
            .Add(New DataColumn("GoodDescription"))
            .Add(New DataColumn("NoOfPackageBL", System.Type.GetType("System.Int32")))
            .Add(New DataColumn("TypeOfPackageBL"))
            .Add(New DataColumn("GrossWeight", System.Type.GetType("System.Double")))
            .Add(New DataColumn("Consignee"))
            .Add(New DataColumn("Consignor"))
            .Add(New DataColumn("Notify"))
            .Add(New DataColumn("BlCode", System.Type.GetType("System.Int16")))
            .Add(New DataColumn("Remark"))
            .Add(New DataColumn("Stime", System.Type.GetType("System.DateTime")))
        End With

        TbExpMBContainer = New DataTable
        With TbExpMBContainer.Columns
            .Add(New DataColumn("MYear"))
            .Add(New DataColumn("KeshtiCode"))
            .Add(New DataColumn("TripNo"))
            .Add(New DataColumn("ConFlag"))
            .Add(New DataColumn("SealNumber"))
            .Add(New DataColumn("CSize"))
            .Add(New DataColumn("CType"))
            .Add(New DataColumn("NoeInput"))
            .Add(New DataColumn("F_E")) ', System.Type.GetType("System.Boolean")))
            .Add(New DataColumn("MovementType"))
            .Add(New DataColumn("POD"))
            .Add(New DataColumn("Des"))
            .Add(New DataColumn("TareWeight", System.Type.GetType("System.Int32")))
            .Add(New DataColumn("TxtJavazWei"))
            .Add(New DataColumn("ContainerOwner"))
            .Add(New DataColumn("TxtPlanSto"))
            .Add(New DataColumn("IMDGCode"))
            .Add(New DataColumn("HazardVersion"))
            .Add(New DataColumn("HazardPageNumber"))
            .Add(New DataColumn("EquipmentFlashPoint"))
            .Add(New DataColumn("TxtHumm"))
            .Add(New DataColumn("TxtVentilation"))
            .Add(New DataColumn("TxtRfTem"))
            .Add(New DataColumn("TxtTemJavazNo"))
            .Add(New DataColumn("TxtEXPPMT"))
            .Add(New DataColumn("Remark"))
            .Add(New DataColumn("Stime", System.Type.GetType("System.DateTime")))
            .Add(New DataColumn("Line"))
        End With

        TbExpMBLContainer = New DataTable
        With TbExpMBLContainer.Columns
            .Add(New DataColumn("MYear"))
            .Add(New DataColumn("KeshtiCode"))
            .Add(New DataColumn("TripNo"))
            .Add(New DataColumn("BLNumber"))
            .Add(New DataColumn("ConFlag"))
            .Add(New DataColumn("NoOfPackage", System.Type.GetType("System.Int32")))
            .Add(New DataColumn("TxtPackType"))
            .Add(New DataColumn("NetWeight", System.Type.GetType("System.Int32")))
            .Add(New DataColumn("Strip"))
            .Add(New DataColumn("Stime", System.Type.GetType("System.DateTime")))
        End With

    End Sub
    Private Function CntrFormat(ByVal sCntr As String)

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
            Case "HC"
                Ans = 5
            Case Else
                Ans = 1
        End Select
        EcsCnTypeToTCTS = Ans

    End Function

    Private Function CleanStr(ByVal sStr As String) As String

        Dim nI As Long
        Dim AllowChrs As String = ""
        Dim sResult As String = ""
        Dim S As String = ""

        AllowChrs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.,-()/= "

        For nI = 1 To Len(sStr)
            S = Mid(sStr, nI, 1)
            If InStr(1, AllowChrs, S) > 0 Then
                sResult = sResult & S
            Else
                sResult = sResult & " "
            End If
        Next nI

        sResult = Replace(sResult, "  ", " ")
        sResult = Replace(sResult, "  ", " ")

        Return sResult
    End Function
    Private Function OurTypeToTCTSIP(ByVal CnType As String) As Long

        Dim Ans As Long
        Ans = 1
        Select Case CnType
            Case "HC"
                Ans = 11
            Case "SH"
                Ans = 11
            Case "OT"
                Ans = 12
            Case "TK"
                Ans = 6
            Case "RF"
                Ans = 2
            Case "RH"
                Ans = 2
            Case "FC"
                Ans = 9
            Case "FL"
                Ans = 9
        End Select
        Return Ans
    End Function
    Private Function GetEDIPORT(ByVal PortCode As String)

        'Dim Drs() As DataRow
        'Dim sPort As String
        'Drs = Me.DataSetForm.Tables(0).Select("OurPort = '" & PortCode & "'")
        'If Drs.Length > 0 Then
        '    sPort = NullToValue(Drs(0).Item("EDIIPPort"), PortCode)
        'Else
        '    sPort = PortCode
        'End If
        Return Mid(PortCode, 1, 2) & " " & Mid(PortCode, 3)

    End Function


    Public Sub SaveData()

        Dim Dlg As New SaveFileDialog
        Dim Col As DataColumn
        Dim Dr As DataRow
        Dim Line As String = ""
        Dim SR As StreamWriter
        Dlg.ShowDialog()

        If Dlg.FileName <> "" Then

            For Each Dr In TbExpMBL.Rows
                Line = ""
                For Each Col In Dr.Table.Columns
                    Line &= Dr(Col.ColumnName).ToString & "|"
                Next
                ExpMBL.AppendLine(Line)
            Next
            For Each Dr In TbExpMBLContainer.Rows
                Line = ""
                For Each Col In Dr.Table.Columns
                    Line &= Dr(Col.ColumnName).ToString & "|"
                Next
                ExpMBLContainer.AppendLine(Line)
            Next
            For Each Dr In TbExpMBContainer.Rows
                Line = ""
                For Each Col In Dr.Table.Columns
                    Line &= Dr(Col.ColumnName).ToString & "|"
                Next
                ExpMBContainer.AppendLine(Line)
            Next

            ExpMBLContainer.AppendLine()
            ExpMBLContainer.AppendLine("END")

            SR = New StreamWriter(Dlg.FileName)
            SR.Write(ExpMBL.ToString & ExpMBContainer.ToString & ExpMBLContainer.ToString)
            SR.Flush()
            SR.Close()
            MsgBox("Save Sucsessful")

        End If

    End Sub
 
    Public Sub GenEDITextFormatMtyCntrs(ByVal VoyageID As Guid)

        Dim Cns As TB_EcsContainersCollection
        Dim Cn As TB_EcsContainers
        Dim Mov As TB_EcsMovesCollection
        Dim Dm As New DataManager(My.Settings.DSN)

        Dim TBTemp As New DataTable
        Dim OE As String = "EL" 'should change for multi lines 
        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim StorPort As String
        Dim BLNo As String
        Dim nSeq As Int64
        Dim NewDr As DataRow
        Dim Voy As TB_Voyage
        Dim Vsl As TB_Vessels
        Dim lFirst As Boolean
        Dim TTlPkgs As Int16
        Dim CoName As String
        Dim TempDr As DataRow
        Dim TempDrs() As DataRow
        Dim MainLine As String
        Dim CC As New CLCntrCount
        Dim TotalPkgs As Int16
        Dim SOf As TB_SOF
        Dim DrsMove() As DataRow
        Dim TBTotal As DataTable
        Dim TDR() As DataRow
        Dim sgoods As String
        Dim DS As DataSet
        Dim snd As Boolean
        Dim trd As Boolean
        Dim ssql As String
        Dim TbTw As DataTable
        Dim lResult As Boolean
        Dim aPorts As New ArrayList
        Dim Ecs As TB_EcsContainers


        Dm = New DataManager(My.Settings.DSN)

        With TBTemp
            .TableName = "Temp"
            .Columns.Add(New DataColumn("Port", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
            .Columns.Add(New DataColumn("VoyageID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("CntrNo", System.Type.GetType("System.String")))
        End With

        TBTotal = New DataTable

        With TBTotal
            .TableName = "Total"
            .Columns.Add(New DataColumn("Port", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("TTL20", System.Type.GetType("System.Int16")))
            .Columns.Add(New DataColumn("TTL40", System.Type.GetType("System.Int16")))
        End With

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Dm.GetTB_Lines()
        MainLine = Dm.DataSet.Tables("TB_Lines").Rows(0).Item("LineName")

        Dm.QueryCriteria.Clear()
        Dm.GetTB_Company()
        CoName = Dm.DataSet.Tables("TB_Company").Rows(0).Item("CompanyName")

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyageID, MatchType.Exact)
        Voy = Dm.GetTB_Voyage

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
        Vsl = Dm.GetTB_Vessels

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.OutVoyageID, VoyageID)
        Cns = Dm.GetTB_EcsContainersCollection

        For Each Cn In Cns


            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_EcsMoves.Columns.CntrID, Cn.ID, MatchType.Exact)
            Dm.QueryCriteria.And(JoinPath.TB_EcsMoves.Columns.Status, OE, MatchType.Exact)
            Mov = Dm.GetTB_EcsMovesCollection
            If Mov.Count <> 0 Then
                nSeq = TBTemp.Rows.Count + 1
                Dr = TBTemp.NewRow
                Dr("Port") = Cn.ReturnTo
                Dr("ID") = Cn.ID
                Dr("Seq") = nSeq
                Dr("VoyageID") = Cn.InVoyageID
                Dr("CntrNo") = Cn.CntrNo
                TBTemp.Rows.Add(Dr)
                Drs = TBTotal.Select("Port = '" & Cn.ReturnTo & "'")
                If Drs.Length = 0 Then
                    Dr = TBTotal.NewRow
                    Dr("Port") = Cn.ReturnTo
                    Dr("TTL20") = 0
                    Dr("TTL40") = 0
                    If Cn.CnSize = "20" Then
                        Dr("TTL20") += 1
                    Else
                        Dr("TTL40") += 1
                    End If
                    TBTotal.Rows.Add(Dr)
                Else
                    If Cn.CnSize = "20" Then
                        Drs(0).Item("TTL20") += 1
                    Else
                        Drs(0).Item("TTL40") += 1
                    End If
                End If
                If aPorts.IndexOf(Cn.ReturnTo) = -1 Then
                    aPorts.Add(Cn.ReturnTo)
                End If
            End If
        Next

        If Not aPorts Is Nothing Then

            For Each Port As String In aPorts

                TDR = TBTotal.Select("Port = '" & Port & "'")
                If TDR.Length > 0 Then
                    sgoods = IIf(TDR(0).Item("TTL20") > 0, TDR(0).Item("TTL20").ToString & "X20'", "")
                    sgoods += " " & IIf(TDR(0).Item("TTL40") > 0, TDR(0).Item("TTL40").ToString & "X40'", "")
                    BLNo = CurrentShippingLine & "-MTY-" & Port
                Else
                    sgoods = "NOTHING"
                    BLNo = "????"
                End If

                NewDr = TbExpMBL.NewRow
                NewDr("MYear") = YY
                NewDr("KeshtiCode") = Vsl.IMONo
                NewDr("TripNo") = Voy.VoyageNo
                NewDr("BLNumber") = BLNo
                NewDr("GoodDescription") = Left(sgoods, 100)
                NewDr("NoOfPackageBL") = 0
                NewDr("TypeOfPackageBL") = ""
                NewDr("GrossWeight") = 0
                NewDr("Consignee") = CurrentShippingLine
                NewDr("Consignor") = "CARGO SHIPPING CO"
                NewDr("Notify") = CurrentShippingLine
                NewDr("Remark") = ""
                NewDr("Stime") = Date.Today
                TbExpMBL.Rows.Add(NewDr)

                TempDrs = TBTemp.Select("Port = '" & Port & "'")

                For Each TempDr In TempDrs
                    Drs = Dm.DataSet.Tables("TB_EcsContainers").Select("ID = '" & TempDr("ID").ToString & "'", "")
                    DrsMove = Dm.DataSet.Tables("TB_EcsMoves").Select("CntrID = '" & TempDr("ID").ToString & "'")
                    If Drs.Length > 0 Then
                        Dr = Drs(0)
                        NewDr = TbExpMBContainer.NewRow
                        NewDr("MYEAR") = YY
                        NewDr("KeshtiCode") = Vsl.IMONo
                        NewDr("TripNo") = Voy.VoyageNo
                        NewDr("ConFlag") = CntrFormat(TempDr("CntrNo"))
                        NewDr("SealNumber") = ""
                        NewDr("CSize") = Drs(0).Item("CnSize")
                        ' NewDr("CType") = EcsCnTypeToTCTS(Drs(0).Item("CnType"))
                        NewDr("CType") = Drs(0).Item("CnType")
                        NewDr("NoeInput") = "3"
                        NewDr("MovementType") = "1"
                        NewDr("F_E") = "0"
                        NewDr("POD") = Drs(0).Item("ReturnTo")
                        NewDr("Des") = Drs(0).Item("Destination")

                        Dim sql As String
                        Dim TB1 As DataTable
                        Dim JResult As Boolean
                        'sql = "Select TW from [dbo].[TB_EcsContainers] Where InVoyageID = '" & Dr("InVoyageID").ToString & "' and CntrNo = '" & Dr("CntrNo") & "'"
                       


                        sql = " select TW from [TB_ECSBank] where cntrno = '" & Dr("CntrNo") & "'"
                        TableBySql(sql, TB1, JResult)
                        If TB1.Rows.Count > 0 Then
                            If IsDBNull(TB1.Rows(0).Item("TW")) Or TB1.Rows(0).Item("TW").ToString() = "" Or TB1.Rows(0).Item("TW").ToString() = "0" Then
                                ssql = "select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Dr("InVoyageID").ToString & "' , '" & Dr("CntrNo") & "')"
                                TableBySql(ssql, TbTw, lResult)
                                If lResult = True Then
                                    If TbTw.Rows.Count > 0 And Not NullToValue(TbTw.Rows(0).Item(0).ToString(), "") = "" Then
                                        NewDr("TareWeight") = NullToValue(TbTw.Rows(0).Item(0), "")
                                    Else
                                        If Dr("CnSize") = "20" Then
                                            NewDr("TareWeight") = "2200"
                                        Else
                                            NewDr("TareWeight") = "4200"
                                        End If
                                    End If
                                End If
                            Else
                                ssql = "select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Dr("InVoyageID").ToString & "' , '" & Dr("CntrNo") & "')"
                                TableBySql(ssql, TbTw, lResult)
                                If lResult = True Then
                                    NewDr("TareWeight") = Val(TB1.Rows(0).Item("TW"))
                                Else
                                    If Dr("CnSize") = "20" Then
                                        NewDr("TareWeight") = "2200"
                                    Else
                                        NewDr("TareWeight") = "4200"
                                    End If
                                End If
                            End If
                        Else
                            ssql = "select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Dr("InVoyageID").ToString & "' , '" & Dr("CntrNo") & "')"
                            TableBySql(ssql, TbTw, lResult)
                            If lResult = True Then
                                If TbTw.Rows.Count > 0 And Not NullToValue(TbTw.Rows(0).Item(0).ToString(), "") = "" Then
                                    NewDr("TareWeight") = NullToValue(TbTw.Rows(0).Item(0), "")
                                Else
                                    If Dr("CnSize") = "20" Then
                                        NewDr("TareWeight") = "2200"
                                    Else
                                        NewDr("TareWeight") = "4200"
                                    End If
                                End If
                            Else
                                If Dr("CnSize") = "20" Then
                                    NewDr("TareWeight") = "2200"
                                Else
                                    NewDr("TareWeight") = "4200"
                                End If
                            End If
                        End If
                        NewDr("TxtJavazWei") = 0
                        NewDr("ContainerOwner") = CurrentShippingLine
                        NewDr("Line") = "0000"

                        NewDr("IMDGCode") = ""
                        NewDr("EquipmentFlashPoint") = 0
                        NewDr("HazardPageNumber") = ""
                        NewDr("UNNumber") = ""
                        NewDr("TxtTemJavazNo") = ""
                        NewDr("HazardVersion") = ""
                        'NewDr("TxtEXPPMT") = ""
                        NewDr("sTime") = Now()
                        TbExpMBContainer.Rows.Add(NewDr)

                        NewDr = TbExpMBLContainer.NewRow
                        NewDr("MYEAR") = YY
                        NewDr("KeshtiCode") = Vsl.IMONo
                        NewDr("TripNo") = Voy.VoyageNo
                        NewDr("ConFlag") = CntrFormat(Drs(0).Item("CntrNo"))
                        NewDr("BlNumber") = BLNo
                        NewDr("NoOfPackage") = 0
                        NewDr("NetWeight") = 0
                        NewDr("sTime") = Now()
                        NewDr("TxtPackType") = ""
                        TbExpMBLContainer.Rows.Add(NewDr)

                    End If
                Next
            Next
        End If




    End Sub

    Public Sub GenEDITextFormatMtyCntrs_CCS(ByVal VoyageID As Guid)

        Dim Cns As TB_EcsContainersCollection
        Dim Cn As TB_EcsContainers
        Dim Mov As TB_EcsMovesCollection
        Dim Dm As New DataManager(My.Settings.DSN)

        Dim TBTemp As New DataTable
        Dim OE As String = "EL" 'should change for multi lines 
        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim StorPort As String
        Dim BLNo As String
        Dim nSeq As Int64
        Dim NewDr As DataRow
        Dim Voy As TB_Voyage
        Dim Vsl As TB_Vessels
        Dim lFirst As Boolean
        Dim TTlPkgs As Int16
        Dim CoName As String
        Dim TempDr As DataRow
        Dim TempDrs() As DataRow
        Dim MainLine As String
        Dim CC As New CLCntrCount
        Dim TotalPkgs As Int16
        Dim SOf As TB_SOF
        Dim DrsMove() As DataRow
        Dim TBTotal As DataTable
        Dim TDR() As DataRow
        Dim sgoods As String
        Dim DS As DataSet
        Dim snd As Boolean
        Dim trd As Boolean
        Dim ssql As String
        Dim TbTw As DataTable
        Dim lResult As Boolean
        Dim aPorts As New ArrayList
        Dim Ecs As TB_EcsContainers


        Dm = New DataManager(My.Settings.DSN)

        With TBTemp
            .TableName = "Temp"
            .Columns.Add(New DataColumn("Port", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
            .Columns.Add(New DataColumn("VoyageID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("CntrNo", System.Type.GetType("System.String")))
        End With

        TBTotal = New DataTable

        With TBTotal
            .TableName = "Total"
            .Columns.Add(New DataColumn("Port", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("TTL20", System.Type.GetType("System.Int16")))
            .Columns.Add(New DataColumn("TTL40", System.Type.GetType("System.Int16")))
        End With

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Dm.GetTB_Lines()
        MainLine = Dm.DataSet.Tables("TB_Lines").Rows(0).Item("LineName")

        Dm.QueryCriteria.Clear()
        Dm.GetTB_Company()
        CoName = Dm.DataSet.Tables("TB_Company").Rows(0).Item("CompanyName")

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyageID, MatchType.Exact)
        Voy = Dm.GetTB_Voyage

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
        Vsl = Dm.GetTB_Vessels

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.OutVoyageID, VoyageID)
        Cns = Dm.GetTB_EcsContainersCollection

        For Each Cn In Cns


            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_EcsMoves.Columns.CntrID, Cn.ID, MatchType.Exact)
            Dm.QueryCriteria.And(JoinPath.TB_EcsMoves.Columns.Status, OE, MatchType.Exact)
            Mov = Dm.GetTB_EcsMovesCollection
            If Mov.Count <> 0 Then
                nSeq = TBTemp.Rows.Count + 1
                Dr = TBTemp.NewRow
                Dr("Port") = Cn.ReturnTo
                Dr("ID") = Cn.ID
                Dr("Seq") = nSeq
                Dr("VoyageID") = Cn.InVoyageID
                Dr("CntrNo") = Cn.CntrNo
                TBTemp.Rows.Add(Dr)
                Drs = TBTotal.Select("Port = '" & Cn.ReturnTo & "'")
                If Drs.Length = 0 Then
                    Dr = TBTotal.NewRow
                    Dr("Port") = Cn.ReturnTo
                    Dr("TTL20") = 0
                    Dr("TTL40") = 0
                    If Cn.CnSize = "20" Then
                        Dr("TTL20") += 1
                    Else
                        Dr("TTL40") += 1
                    End If
                    TBTotal.Rows.Add(Dr)
                Else
                    If Cn.CnSize = "20" Then
                        Drs(0).Item("TTL20") += 1
                    Else
                        Drs(0).Item("TTL40") += 1
                    End If
                End If
                If aPorts.IndexOf(Cn.ReturnTo) = -1 Then
                    aPorts.Add(Cn.ReturnTo)
                End If
            End If
        Next

        If Not aPorts Is Nothing Then

            For Each Port As String In aPorts

                TDR = TBTotal.Select("Port = '" & Port & "'")
                If TDR.Length > 0 Then
                    sgoods = IIf(TDR(0).Item("TTL20") > 0, TDR(0).Item("TTL20").ToString & "X20'", "")
                    sgoods += " " & IIf(TDR(0).Item("TTL40") > 0, TDR(0).Item("TTL40").ToString & "X40'", "")
                    BLNo = CurrentShippingLine & "-MTY-" & Port
                Else
                    sgoods = "NOTHING"
                    BLNo = "????"
                End If

                NewDr = TbExpMBL.NewRow
                NewDr("MYear") = YY
                NewDr("KeshtiCode") = Vsl.IMONo
                NewDr("TripNo") = Voy.VoyageNo
                NewDr("BLNumber") = BLNo
                NewDr("GoodDescription") = Left(sgoods, 100)
                NewDr("NoOfPackageBL") = 0
                NewDr("TypeOfPackageBL") = ""
                NewDr("GrossWeight") = 0
                NewDr("Consignee") = CurrentShippingLine
                NewDr("Consignor") = "CARGO SHIPPING CO"
                NewDr("Notify") = CurrentShippingLine
                NewDr("Remark") = ""
                NewDr("Stime") = Date.Today
                TbExpMBL.Rows.Add(NewDr)

                TempDrs = TBTemp.Select("Port = '" & Port & "'")

                For Each TempDr In TempDrs
                    Drs = Dm.DataSet.Tables("TB_EcsContainers").Select("ID = '" & TempDr("ID").ToString & "'", "")
                    DrsMove = Dm.DataSet.Tables("TB_EcsMoves").Select("CntrID = '" & TempDr("ID").ToString & "'")
                    If Drs.Length > 0 Then
                        Dr = Drs(0)
                        NewDr = TbExpMBContainer.NewRow
                        NewDr("MYEAR") = YY
                        NewDr("KeshtiCode") = Vsl.IMONo
                        NewDr("TripNo") = Voy.VoyageNo
                        NewDr("ConFlag") = CntrFormat(TempDr("CntrNo"))
                        NewDr("SealNumber") = ""
                        NewDr("CSize") = Drs(0).Item("CnSize")
                        ' NewDr("CType") = EcsCnTypeToTCTS(Drs(0).Item("CnType"))
                        NewDr("CType") = Drs(0).Item("CnType")
                        NewDr("NoeInput") = "3"
                        NewDr("MovementType") = "1"
                        NewDr("F_E") = "0"
                        NewDr("POD") = Drs(0).Item("ReturnTo")
                        NewDr("Des") = Drs(0).Item("Destination")
                        ssql = "select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Dr("InVoyageID").ToString & "' , '" & Dr("CntrNo") & "')"
                        TableBySql(ssql, TbTw, lResult)
                        If lResult = True Then
                            If TbTw.Rows.Count > 0 And Not NullToValue(TbTw.Rows(0).Item(0).ToString(), "") = "" Then
                                NewDr("TareWeight") = NullToValue(TbTw.Rows(0).Item(0), "")
                            Else
                                If Dr("CnSize") = "20" Then
                                    NewDr("TareWeight") = "2200"
                                Else
                                    NewDr("TareWeight") = "4200"
                                End If
                            End If
                        End If
                        NewDr("TxtJavazWei") = 0
                        NewDr("ContainerOwner") = CurrentShippingLine
                        NewDr("Line") = "0"

                        NewDr("IMDGCode") = ""
                        NewDr("EquipmentFlashPoint") = 0
                        NewDr("HazardPageNumber") = ""
                        NewDr("HazardVersion") = ""
                        NewDr("TxtTemJavazNo") = ""
                        NewDr("TxtEXPPMT") = ""
                        NewDr("sTime") = Now()
                        TbExpMBContainer.Rows.Add(NewDr)

                        NewDr = TbExpMBLContainer.NewRow
                        NewDr("MYEAR") = YY
                        NewDr("KeshtiCode") = Vsl.IMONo
                        NewDr("TripNo") = Voy.VoyageNo
                        NewDr("ConFlag") = CntrFormat(Drs(0).Item("CntrNo"))
                        NewDr("BlNumber") = BLNo
                        NewDr("NoOfPackage") = 0
                        NewDr("NetWeight") = 0
                        NewDr("sTime") = Now()
                        NewDr("TxtPackType") = ""
                        TbExpMBLContainer.Rows.Add(NewDr)

                    End If
                Next
            Next
        End If




    End Sub

End Class
