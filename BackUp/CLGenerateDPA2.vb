Imports System.Text
Imports OrmLib
Imports ShippingBiz
Imports System.IO
Public Class CLGenerateDPA

    Public Sub GenerateDPA(ByVal VoyageID As String, ByVal Port As String, ByVal BLS() As DataRow, ByVal FleName As String)

        Dim SW As New StreamWriter(FleName)

        Dim DM As New DataManager(My.Settings.DSN)
        Dim Voy As TB_Voyage
        Dim SOf As TB_SOF
        Dim BL As TB_InwardBLS
        Dim Cn As TB_InwardCntrs
        Dim Cns As TB_InwardCntrsCollection
        Dim Goods As TB_InwardBlsGoods
        Dim Names As TB_InwardBlsNames
        Dim Lines As TB_Lines
        Dim Clients As TB_Clients
        Dim VSL As TB_Vessels
        Dim Pkgs As TB_CODECollection
        Dim Code As TB_CODECollection

        Dim Dr As DataRow
        Dim nI As Integer


        Dim DPAVOY As New CLDPAStructure.VOY
        Dim DPABOL As New CLDPAStructure.BOL
        Dim DPACTR As New CLDPAStructure.CTR
        Dim DPACON As New CLDPAStructure.CON



        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyageID, MatchType.Exact)
        Voy = DM.GetTB_Voyage

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, VoyageID, MatchType.Exact)
        DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.Port, Port, MatchType.Exact)
        SOf = DM.GetTB_SOF

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
        VSL = DM.GetTB_Vessels

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "", MatchType.Not)
        Code = DM.GetTB_CODECollection


        With DPAVOY
            .H_AGENTSMANIFEST = Format(DateAndTime.Now, "HHssddMMyyyy")
            .H_AGENTSVOYAGENUMBER = Voy.VoyageNo
            .H_EXPECTEDTOARRIVEDATE = Format(Today, "dd-MMM-yyyy")
            .H_LINECODE = "LC"
            .H_MESSAGETYPE = "MFI"
            .H_NOOFINSTALMENT = 1
            .H_PORTCODEOFDISCHARGE = SOf.Port
            .C_ROTATIONNUMBER = ""
            .H_VESSELNAME = VSL.VesselName
            .H_VOYAGEAGENTCODE = "VGC"
        End With
        SW.WriteLine(DPAVOY.GenerateSegmentVOY())


        For Each Dr In BLS

            DM = New DataManager(My.Settings.DSN)
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, Dr("LINE"), MatchType.Exact)
            DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Dr("BLNO"), MatchType.Exact)
            BL = DM.GetTB_InwardBLS

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, Dr("ID"), MatchType.Exact)
            Cns = DM.GetTB_InwardCntrsCollection

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InwardBlsGoods.Columns.BLID, Dr("ID"), MatchType.Exact)
            Goods = DM.GetTB_InwardBlsGoods

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InwardBlsNames.Columns.BLID, Dr("ID"), MatchType.Exact)
            Names = DM.GetTB_InwardBlsNames

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
            Lines = DM.GetTB_Lines

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Dr("ClientID"), MatchType.Exact)
            Clients = DM.GetTB_Clients

            Pkgs = Code.FilterByGroupCode("PG")
            Pkgs = Pkgs.FilterBySTDCode(Cns(0).PackageType)


            With DPABOL
                .H_BILLOFLADINGNO = UCase(BL.BlNo)
                .H_BOXPARTNERINGAGENT = "1"
                .H_BOXPARTNERINGLINE = "1"
                .H_PORTCODEOFORIGIN = CleanStr(BL.POL)
                .H_PORTCODEOFLOADING = CleanStr(BL.POL)
                .H_PORTCODEOFDISCHARGE = CleanStr(BL.POD)
                .H_PORTCODEOFDESTINATION = CleanStr(BL.FPOD)
                .H_CARGOCODE = IIf(Cns(0).FLE = "E", "M", Cns(0).FLE)
                .H_COUNTRYOFORIGIN = CleanStr(BL.POL)
                .H_SHIPPERNAME = CleanStr(Mid(Names.Shipper, 1, 30))
                .H_SHIPPERADDRESS = NullToValue(CleanStr(Mid(Names.Shipper, 30)), CleanStr(Mid(Names.Shipper, 1, 30)))
                .H_SHIPPERCOUNTRYCODE = BL.POR
                '.H_CONSIGNEECODE = "D9999"
                Try

                    If Not String.IsNullOrEmpty(Clients.NationalID) Then
                        .H_CONSIGNEECODE = Clients.NationalID.ToString()
                    ElseIf Not String.IsNullOrEmpty(Clients.NationalCode) Then
                        .H_CONSIGNEECODE = Clients.NationalCode.ToString()
                    Else
                        .H_CONSIGNEECODE = ""
                    End If

                    'If Not IsNothing(Clients.NationalID) Then

                    '    .H_CONSIGNEECODE = Clients.NationalID.ToString()
                    'ElseIf Not IsNothing(Clients.NationalCode) Then
                    '    .H_CONSIGNEECODE = Clients.NationalCode.ToString()
                    'Else
                    '    .H_CONSIGNEECODE = ""
                    'End If

                Catch ex As Exception

                End Try
                .H_CONSIGNEENAME = CleanStr(Mid(Names.Cnee, 1, 30))
                .H_CONSIGNEEADDRESS = NullToValue(CleanStr(Mid(Names.Cnee, 30)), CleanStr(Mid(Names.Cnee, 1, 30)))
                .H_NOTIFY1NAME = CleanStr(Mid(Names.Notify1, 1, 30))
                .H_NOTIFY1ADDRESS = NullToValue(CleanStr(Mid(Names.Notify1, 30)), CleanStr(Mid(Names.Notify1, 1, 30)))
                .H_MARKSNUMBERS = CleanStr(Goods.Marks)
                .H_COMMODITYCODE = IIf(BL.HSCode = "", "1", BL.HSCode) 'CleanStr(Goods.MainCom)
                .H_COMMODITYDESCRIPTION = CleanStr(Goods.MainCom)
                .H_PACKAGES = Goods.TTLPkgs
                If Pkgs.Count > 0 Then
                    .H_PACKAGETYPE = Pkgs(0).MEANING
                    .H_PACKAGETYPECODE = Pkgs(0).STDCode
                Else
                    .H_PACKAGETYPE = "PK"
                    .H_PACKAGETYPECODE = "PK"
                End If
                .H_CARGOWEIGHTINKG = Goods.TGW
                .H_GROSSWEIGHTINKG = Goods.TGW
                .H_TRADECODE = "I"
            End With

            SW.WriteLine(DPABOL.GenerateSegmentBOL)

            For Each Cn In Cns

                With DPACTR
                    '.H_CONTAINERNUMBER = Mid(Cn.CntrNo, 1, 10)
                    .H_CONTAINERNUMBER = Cn.CntrNo
                    'Commented the above lines for the case :"REMOVING CHECK DIGIT SEGRATION IN GENERATED FILE FROM MAP FOR CUSTOMS UNDER EDI TOOLS MENU"
                    'And modified as above
                    .H_CHECKDIGIT = Right(Cn.CntrNo, 1)
                    .H_TAREWEIGHTINMT = Cn.TW
                    .H_SEALNO = Cn.SealNo
                End With

                SW.WriteLine(DPACTR.GenerateSegmentCTR)


                With DPACON
                    .H_SERIALNUMBER = 1
                    .H_CARGODESCRIPTION = CleanStr(Goods.Goods)
                    .H_COMMODITYCODE = IIf(BL.HSCode = "", "1", BL.HSCode) '"1"
                    .H_CONSIGNMENTPACKAGES = Goods.TTLPkgs
                    .H_PACKAGETYPE = Pkgs(0).MEANING
                    .H_PACKAGETYPECODE = Pkgs(0).STDCode
                    .H_CONSIGNMENTWEIGHTIN = Cn.GW 'Goods.TGW
                    .H_DANGEROUSGOODS = "N"
                    .H_REFRIGERATIONREQUIRED = "N"
                End With
                SW.WriteLine(DPACON.GenerateSegmentCON)
            Next
        Next

        SW.Flush()
        SW.Close()


    End Sub

    Private Function CleanStr(ByVal sStr As String) As String

        Dim nI As Long
        Dim AllowChrs As String = ""
        Dim sResult As String = ""
        Dim S As String = ""
        sStr = UCase(sStr)

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





End Class
