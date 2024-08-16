Imports WindowsApplication1.WHLEDI
Imports System.IO
Imports OrmLib
Imports ShippingBiz
Public Class WHLEDIGen
    Public Enum Types
        StringEnum
        DateEnum
        IntegrtEnum
        DecimalEnum
    End Enum
    'Dim CTA As SegmentCTAType
    Private SR As StreamWriter
    Public Sub GenerateWHLFileByList(ByRef DS As DataSet, ByVal TFCCode As String)


        Dim Drs() As DataRow
        Dim NewDr As DataRow

        DS.Tables(1).Clear()
        DS.AcceptChanges()

        Drs = DS.Tables(0).Select("Select = true")


        SR.WriteLine( _
        GenMFT("MFT663", "IRBND01", "TWTPE01", Format(Today, "yyyyMMdd"), Format(Now, "HHmmss"), TFCCode, "E", Format(Today, "yyyyMMdd") & " " & Format(Now, "HHmmss"), "", "", "", ""))
        SR.WriteLine("")
        For Each dr In Drs
            'Try
            GenerateWHLFileByBLID(dr("ID"), SR, TFCCode)
            '    Catch ex As Exception
            '        MsgBox("Skip " & dr("BLNO"))
            '        NewDr = DS.Tables(1).NewRow
            '        NewDr(0) = dr("BLNO")
            '        NewDr(1) = ex.ToString
            '        DS.Tables(1).Rows.Add(NewDr)
            '    End Try
        Next
        SR.WriteLine("EOF")
        SR.Flush()
        SR.Close()
        If DS.Tables(1).Rows.Count > 0 Then
            MsgBox("Generate Finished with Error ", MsgBoxStyle.Critical)
        Else
            MsgBox("Generate Successful")
        End If

    End Sub

    Private Sub GenerateWHLFileByBLID(ByVal BLID As Guid, ByRef sr As StreamWriter, ByVal TFCCode As String)

        Dim Dm As New DataManager(My.Settings.DSN)
        Dim BL As TB_OutwardBLS
        Dim Dec As TB_OutwardBlsGoods
        Dim Cntrs As TB_OutwardCntrsCollection
        Dim SPR As TB_OutwardBlsNames
        Dim Chgs As TB_OutwardChargesCollection
        Dim CntChgs As TB_OutwardCntrsChargesCollection
        Dim DG As TB_OutwardCnsImco
        Dim RF As TB_OutwardCnsTemprature
        Dim Clnt As TB_Clients
        Dim AgentPOL As TB_Agents
        Dim AgentPOD As TB_Agents
        Dim BK As TB_Booking
        Dim IsoTypes As TB_ISOTypeCollection
        Dim Drs() As DataRow
        Dim Tmp As TB_OutwardCnsTemprature

        Dim Memo As New CLMemo
        Dim nI As Integer
        Dim TB As New DataTable

        Dim lResult As Boolean
        Dim FlashPoint As String

        Dim CTASeq As Long
        Dim CTBSea As Long
        Dim CTCSeq As Long
        Dim CTDSeq As Long

        Dim TBD As New DataTable
        Dim sSql As String
        Dim lResult2 As Boolean

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.ID, BLID, MatchType.Exact)
        BL = Dm.GetTB_OutwardBLS

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBlsGoods.Columns.BLID, BLID, MatchType.Exact)
        Dec = Dm.GetTB_OutwardBlsGoods

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardCntrs.Columns.BLID, BLID, MatchType.Exact)
        Cntrs = Dm.GetTB_OutwardCntrsCollection

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBlsNames.Columns.BLID, BLID, MatchType.Exact)
        SPR = Dm.GetTB_OutwardBlsNames

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardCharges.Columns.BLID, BLID, MatchType.Exact)
        Chgs = Dm.GetTB_OutwardChargesCollection

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, BL.ClientID, MatchType.Exact)
        Clnt = Dm.GetTB_Clients


        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Agents.Columns.Port, BL.POL, MatchType.Exact)
        AgentPOL = Dm.GetTB_Agents

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Agents.Columns.Port, BL.POD, MatchType.Exact)
        AgentPOD = Dm.GetTB_Agents

        Try
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Booking.Columns.ID, BL.BookingID, MatchType.Exact)
            BK = Dm.GetTB_Booking
        Catch ex As Exception

        End Try

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_ISOType.Columns.ISOTypeID, "", MatchType.IsNotNull)
        Dm.GetTB_ISOType()


        TB = New DataTable
        TableBySql("SP_OutwardCntrsChargesByBLID '" & BL.ID.ToString & "'", TB, lResult)




        sr.WriteLine( _
                GenKEY("KEY", BL.BlNo, "", "", "9", CurrentShippingLine, BL.OnBoardDate.ToString, Mid(BL.BlNo, 1, 3), Mid(BL.BlNo, 4, 1), Mid(BL.BlNo, 5, 6), BL.POL, BL.POD, BL.POR, BL.FPOD, BL.POL, "01", "", "", "", ""))

        'sr.WriteLine( _
        '       GenBLB("BLB", "1", PortNameByCode(Dm, BL.POL) & " PORT OF ?", PortNameByCode(Dm, BL.POD) & " PORT OF ?", ""))

        'sr.WriteLine( _
        '       GenBLC("BLC", "1", PortNameByCode(Dm, BL.POL) & " PORT OF ?", PortNameByCode(Dm, BL.POD) & " PORT OF ?", ""))


        'sr.WriteLine( _
        '       GenBLE("BLE", "1", BL.IssueDate, "", "", "", "", "", "", "", ""))

        'sr.WriteLine( _
        '      GenBLH("BLH", "1", Cntrs(0).PackageType, "", ""))

        sr.WriteLine("")

        sr.WriteLine( _
                      GenMRK("MRK", "1", Dec.Marks, "", ""))


        Memo.ColInit(CLMemo.MemoTypes.Goods, Dec.Goods, 31)
        For nI = 1 To Memo.GOOD.Count
            sr.WriteLine( _
                          GenDEC("DEC", nI.ToString, Memo.GOOD.Item(nI), "", ""))

        Next
        Memo.ColInit(CLMemo.MemoTypes.Shipper, SPR.Shipper, 36)
        For nI = 1 To Memo.Shpr.Count
            If nI = 1 Then
                sr.WriteLine( _
                      GenSPR("SPR", nI.ToString, Memo.Shpr.Item(nI), ""))
            Else
                sr.WriteLine( _
                   GenSPA("SPA", (nI - 1).ToString, Memo.Shpr.Item(nI), ""))
            End If
        Next

        Memo.ColInit(CLMemo.MemoTypes.Cnee, SPR.Cnee, 36)
        For nI = 1 To Memo.Cnee.Count
            If nI = 1 Then
                sr.WriteLine( _
                      GenCEE("CEE", nI.ToString, Memo.Cnee.Item(nI), ""))
            Else
                sr.WriteLine( _
                   GenCEA("CEA", (nI - 1).ToString, Memo.Cnee.Item(nI), ""))
            End If
        Next
        Memo.ColInit(CLMemo.MemoTypes.Notify1, SPR.Notify1, 36)
        For nI = 1 To Memo.Ntfy1.Count
            If nI = 1 Then
                sr.WriteLine( _
                      GenNTF("NTF", nI.ToString, Memo.Ntfy1.Item(nI), ""))
            Else
                sr.WriteLine( _
                    GenNTF("NFA", (nI - 1).ToString, Memo.Ntfy1.Item(nI), ""))
            End If
        Next

        'Memo.ColInit(CLMemo.MemoTypes.Cnee, SPR.Cnee, 36)
        'For nI = 1 To Memo.Shpr.Count
        '    If nI = 1 Then
        '        sr.WriteLine( _
        '              GenCEE("DBA", nI.ToString, Memo.Cnee.Item(nI), ""))
        '    End If
        'Next

        sr.WriteLine( _
                   GenMGA("MGA", "1", "", "", "N", "N", "N", "O", BL.IssuePlace, BL.TermsOfPayment, BL.NoOfBls.ToString, BL.IssueDate, "", "", "", BL.NoOfBls.ToString, "Y", "Y", "Y", "            ", BL.IssueDate, "", "     " & "  ", "", "", ""))

        sr.WriteLine( _
                   GenMGB("MGB", "1", "", "", Dec.TTLPkgs.ToString, Cntrs(0).PackageType, Dec.TTLCBM.ToSqlString, Dec.TGW.ToString, Dec.TTLNET.ToString, "220-00", "1", "N", "Y", "N", "Y", "Y", "N", "N", "Y", "Y", "N", "N", "N", "N", "N", "N", "Y", "Y", "N", "N", "N", "N", "N", "4", "3", "MTQ", "KGM", "", "", ""))

        'sr.WriteLine( _
        '           GenMGC("MGC", "1", "", "", "", "", ""))

        'sr.WriteLine( _
        '                 GenMGD("MGD", "1", "?", "", ""))

        'sr.WriteLine( _
        '                 GenMGE("MGE", "1", "?", "?", ""))

        'sr.WriteLine( _
        '                 GenMGF("MGF", "1", PortNameByCode(Dm, BL.POL), "", "", PortNameByCode(Dm, BL.POL), "", "", PortNameByCode(Dm, BL.POT), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", BL.IssuePlace, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""))


        'sr.WriteLine( _
        '         GenMGG("MGG", "1", "", "?", ""))

        'sr.WriteLine( _
        '         GenMGH("MGH", "1", "?", "?", "", "", "", "", ""))

        sr.WriteLine( _
                       GenMGI("MGI", "1", BK.Payer, "", BK.Payer, "", "", "", "", "", ""))

        'sr.WriteLine( _
        '       GenMGJ("MGJ", "1", "", "", Dec.TTLPkgs.ToString, Cntrs(0).PackageType, "", "", Dec.TGW.ToString, "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""))

        'sr.WriteLine( _
        '       GenMGK("MGK", "1", PortNameByCode(Dm, BL.POL) & "01", "?", "", "", "", "", "", "", "", "", "", "", "", ""))

        'sr.WriteLine( _
        '      GenMGL("MGL", "1", "?", PortNameByCode(Dm, BL.POL) & "01", "?", "", "", "", "", "", "", "", ""))

        'sr.WriteLine( _
        '     GenMGN("MGN", "1", "?", "?", "?", ""))

        'sr.WriteLine( _
        '     GenMGO("MGO", "1", " ", " ", " ", "?", " ?", " ?", " ?", " ", " ", " ", " ", " "))

        'sr.WriteLine( _
        '     GenMGP("MGP", "1", " ", " ", PortNameByCode(Dm, BL.POL), " ", "  ", "  ", "  ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "))

        'sr.WriteLine( _
        '  GenMGQ("MGQ", "1", " ", " ", " ", "  ", "  ", "  ", " ", " ", "  ", "?"))

        'sr.WriteLine( _
        'GenMGR("MGR", "1", " ", " ", " "))

        'sr.WriteLine( _
        'GenMGV("MGV", "1", " ", " ", " ", " ", " ", " ", " ", " "))

        'Memo.ColInit(CLMemo.MemoTypes.Cnee, SPR.Cnee, 36)
        'For nI = 1 To Memo.Cnee.Count
        '    sr.WriteLine( _
        '          GenMGW("MGW", nI.ToString, Memo.Cnee.Item(nI), "", ""))
        'Next

        For Each dr In TB.Rows

            sr.WriteLine( _
            GenCGAE("CGAE", "1", dr("ChargesCode"), " ", " ", dr("Currency"), dr("RealAmount"), _
                                 IIf(dr("FromPlace") = "POL", BL.POL, BL.POD) & "", _
                                 IIf(dr("ToPlace") = "POL", BL.POL, BL.POD) & "", dr("AsPayAt"), _
                                 NullToValue(dr("PayAtBranch"), ""), "", dr("P1") & "", _
                                 dr("P2"), " "))
            If Not BK Is Nothing Then
                sr.WriteLine(GenCGB("CGB", "1", BK.Payer, "*", ""))
            Else
                sr.WriteLine(GenCGB("CGB", "1", Clnt.lName.ToUpper, "*", ""))
            End If
        Next

        'For Each Cntr As TB_OutwardCntrs In Cntrs

        '    Dm.QueryCriteria.Clear()
        '    Dm.QueryCriteria.And(JoinPath.TB_OutwardCnsImco.Columns.CntrID, Cntr.ID, MatchType.Exact)
        '    DG = Dm.GetTB_OutwardCnsImco

        '    Dm.QueryCriteria.Clear()
        '    Dm.QueryCriteria.And(JoinPath.TB_OutwardCnsTemprature.Columns.CntrID, Cntr.ID, MatchType.Exact)
        '    RF = Dm.GetTB_OutwardCnsTemprature

        '    Dm.QueryCriteria.Clear()
        '    Dm.QueryCriteria.And(JoinPath.TB_OutwardCntrsCharges.Columns.CntrID, Cntr.ID, MatchType.Exact)
        '    CntChgs = Dm.GetTB_OutwardCntrsChargesCollection

        '    If CntChgs.Count > 0 Then
        '        For Each CG As TB_OutwardCntrsCharges In CntChgs
        '            sr.WriteLine( _
        '            GenCGAE("CGAE", "1", CG.ChargesCode, " ", " ", CG.Currency, CG.RealAmount.ToString, _
        '                                  CG.FromPlace & "", CG.ToPlace & "", IIf(CG.Terms = "C", BL.POD, BL.POL), _
        '                                    IIf(CG.Terms = "C", Mid(AgentPOD.Code, 6, 2), Mid(AgentPOL.Code, 6, 2)), "", CG.Terms & "", _
        '                                  CG.Terms, " "))
        '        Next
        '    End If

        'Memo.ColInit(CLMemo.MemoTypes.Shipper, SPR.Shipper, 36)
        'For nI = 1 To Memo.Shpr.Count
        '    sr.WriteLine( _
        '          GenCGB("CGB", nI.ToString, Memo.Shpr.Item(nI), "", ""))
        'Next

        'sr.WriteLine( _
        '          GenCGC("CGC", "1", "", "", "?", ""))


        'sr.WriteLine( _
        '          GenCGD("CGD", "1", "?", "", "", "", "", "", "", "", "", "?", "", ""))
        'Next

        For Each Cntr As TB_OutwardCntrs In Cntrs
            CTASeq += 1
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_OutwardCnsImco.Columns.CntrID, Cntr.ID, MatchType.Exact)
            DG = Dm.GetTB_OutwardCnsImco
            If DG Is Nothing Then
                FlashPoint = ""
            Else
                FlashPoint = DG.FlashPoint.ToString
            End If


            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_OutwardCnsTemprature.Columns.CntrID, Cntr.ID, MatchType.Exact)
            Tmp = Dm.GetTB_OutwardCnsTemprature

           
          
            Drs = Dm.DataSet.Tables("TB_ISOType").Select("WHLSize = '" & Cntr.CnSize & "' and OurType = '" & Cntr.CnType & "'")
            sr.WriteLine( _
                    GenCTA("CTA", CTASeq, Cntr.SealNo, "", Cntr.CntrNo, IIf(Cntr.SOC = "Y", "S", "W"), Drs(0).Item("WHLType"), Cntr.FLE, Cntr.CnSize, Drs(0).Item("WHLHeight"), "", "", "", "CTR", "", "", "", "", Drs(0).Item("IsoValue"), "", ""))

            'If Not DG Is Nothing Then
            '    sr.WriteLine( _
            '             GenCTB("CTB", "1", "", DG.UNNO, DG.IMDGCode, DG.PageNumber, IIf(BL.FCLType = "FF", "FCL", "LCL"), IIf(BL.FCLType = "FL", "FCL", "LCL"), "LINER", "LINER", "", "", "", "", "", "", "", "", "", "", ""))
            'Else
            '    sr.WriteLine( _
            '          GenCTB("CTB", "1", "220-00", "", "", "", IIf(BL.FCLType = "FF", "FCL", "LCL"), IIf(BL.FCLType = "FF", "FCL", "LCL"), "LINER", "LINER", "", "", "", "", "", "", "", "", "", "", ""))
            'End If

            'If Not Tmp Is Nothing Then
            '    sr.WriteLine( _
            '             GenCTC("CTC", "1", Cntr.NoOFPkgs, Cntr.PackageType, "", "MTQ", Cntr.GW, Cntr.NET, "", "KGM", Tmp.TempMin, "CEL", Tmp.TempMin, FlashPoint, IIf(FlashPoint = "", "", "CEL"), IIf(Right(BL.FCLType, 1) = "F", "FCL", "LCL"), IIf(Left(BL.FCLType, 1) = "F", "FCL", "LCL"), "", "", "", "", ""))
            'Else
            '    If Cntr.FLE = "E" Then
            '        sr.WriteLine( _
            '            GenCTC("CTC", "1", Cntr.NoOFPkgs, Cntr.PackageType, "", "MTQ", Cntr.GW, Cntr.NET, "", "KGM", "", "", "", FlashPoint, IIf(FlashPoint = "", "", "CEL"), IIf(Right(BL.FCLType, 1) = "F", "FCL", "LCL"), IIf(Left(BL.FCLType, 1) = "F", "FCL", "LCL"), "", "", "", "", ""))

            '    Else
            '        sr.WriteLine( _
            '         GenCTC("CTC", "1", Cntr.NoOFPkgs, NullToValue(Cntr.PackageType, ""), "", "MTQ", Cntr.GW, Cntr.NET, "", "KGM", "", "", "", FlashPoint, IIf(FlashPoint = "", "", "CEL"), IIf(Right(BL.FCLType, 1) = "F", "FCL", "LCL"), IIf(Left(BL.FCLType, 1) = "F", "FCL", "LCL"), "", "", "", "", ""))

            ' Commented above code for 6- TOP URGENT /// WRONG FCL/FCL TERMS GENERATION OF GENERATED FILE FROM WHL MAPPING OUTWARD

            Dim POLDepot As String
            POLDepot = ""
            sSql = "select top 1 Depot from TB_outwardbls where BlNo = '" & BL.BlNo & "'"
            TableBySql(sSql, TBD, lResult2)
            If TBD.Rows.Count > 0 Then
                If Not (String.IsNullOrEmpty(TBD.Rows(0).Item("Depot").ToString)) Then
                    POLDepot = TBD.Rows(0).Item("Depot").ToString.Substring(0, 5)
                End If
            End If
            If Not DG Is Nothing Then
                sr.WriteLine( _
                         GenCTB("CTB", "1", "", DG.UNNO, DG.IMDGCode, DG.PageNumber, IIf(Left(BL.FCLType, 1) = "F", "FCL", "LCL"), IIf(Right(BL.FCLType, 1) = "L", "LCL", "FCL"), "LINER", "LINER", POLDepot, "", "", "", "", "", "", "", "", "", ""))
            Else
                sr.WriteLine( _
                      GenCTB("CTB", "1", "220-00", "", "", "", IIf(Left(BL.FCLType, 1) = "F", "FCL", "LCL"), IIf(Right(BL.FCLType, 1) = "L", "LCL", "FCL"), "LINER", "LINER", POLDepot, "", "", "", "", "", "", "", "", "", ""))
            End If

            If Not Tmp Is Nothing Then
                sr.WriteLine( _
                         GenCTC("CTC", "1", Cntr.NoOFPkgs, Cntr.PackageType, "", "MTQ", Cntr.GW, Cntr.NET, "", "KGM", Tmp.TempMin, "CEL", Tmp.TempMin, FlashPoint, IIf(FlashPoint = "", "", "CEL"), IIf(Right(BL.FCLType, 1) = "F", "FCL", "LCL"), IIf(Left(BL.FCLType, 1) = "F", "FCL", "LCL"), "", "", "", "", ""))
            Else
                If Cntr.FLE = "E" Then
                    sr.WriteLine( _
                        GenCTC("CTC", "1", Cntr.NoOFPkgs, Cntr.PackageType, "", "MTQ", Cntr.GW, Cntr.NET, "", "KGM", "", "", "", FlashPoint, IIf(FlashPoint = "", "", "CEL"), IIf(Right(BL.FCLType, 1) = "F", "FCL", "LCL"), IIf(Left(BL.FCLType, 1) = "F", "FCL", "LCL"), "", "", "", "", ""))

                Else
                    sr.WriteLine( _
                     GenCTC("CTC", "1", Cntr.NoOFPkgs, NullToValue(Cntr.PackageType, ""), "", "MTQ", Cntr.GW, Cntr.NET, "", "KGM", "", "", "", FlashPoint, IIf(FlashPoint = "", "", "CEL"), IIf(Right(BL.FCLType, 1) = "F", "FCL", "LCL"), IIf(Left(BL.FCLType, 1) = "F", "FCL", "LCL"), "", "", "", "", ""))
                End If
            End If

            sr.WriteLine( _
                     GenCTD("CTD", "1", " ", " ", "", "", "N", "N", "N", "N", "", "", " ", "", "", "", "", "", "", "", ""))

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_OutwardCntrsCharges.Columns.CntrID, Cntr.ID, MatchType.Exact)
            CntChgs = Dm.GetTB_OutwardCntrsChargesCollection
            nI = 0
            If CntChgs.Count > 0 Then
                If Not CntChgs Is Nothing Then
                    For Each Chg As TB_OutwardCntrsCharges In CntChgs
                        nI += 1
                        sr.WriteLine( _
                              GenCTRE("CTRE", nI.ToString, Chg.ChargesCode, Chg.RealAmount, "", "", IIf(Chg.FromPlace = "POL", BL.POL, BL.POD), IIf(Chg.ToPlace = "POL", BL.POL, BL.POD), "", Chg.Currency, "", Chg.Terms, ""))
                    Next
                End If
            End If

        Next

    End Sub


    Public Sub GenCTASegment(ByVal BELONG_TO_BOOK_NO As String)
        Dim sResult As String = ""
    End Sub

    Public Function FixLen(ByVal sItem As String, ByVal nlen As Long, ByVal Dec As Integer, ByVal MyType As Types) As String

        Dim Ans As String
        Dim DT As Date
        Dim Des As String

        sItem = Trim(sItem)
        Ans = ""
        Select Case MyType

            Case Types.DateEnum
                If nlen = 8 Then
                    Try
                        DT = CDate(sItem)
                        Ans = DT.Year.ToString & Format(DT.Month, "00") & Format(DT.Day, "00")
                    Catch ex As Exception
                        Ans = Space(nlen)
                    End Try
                Else
                    Try
                        DT = CDate(sItem)
                        Ans = DT.Year.ToString & Format(DT.Month, "00") & Format(DT.Day, "00") & " " & Format(DT.Hour, "00") & Format(DT.Minute, "00") & Format(DT.Second, "00")
                    Catch ex As Exception
                        Ans = Space(nlen)
                    End Try

                End If
            Case Types.DecimalEnum
                Try
                    If sItem = "0" Or sItem = "" Then
                        Ans = Space(nlen) & "." & Space(Dec)
                        Ans = Replace(Ans, " ", "0")
                        If Val(Ans) = 0 Then
                            Ans = Replace(Ans, "0", " ")
                            Ans = Replace(Ans, ".", " ")
                        End If
                    Else
                        If InStr(1, sItem, ".") = 0 Then
                            sItem &= "." & Space(Dec)
                            sItem = Replace(sItem, " ", "0")
                        End If

                        Ans = Mid(sItem, 1, InStr(sItem, ".") - 1)
                        Des = Mid(sItem, InStr(sItem, ".") + 1)
                        Des = Replace(Des & Space(Dec - Len(Des)), " ", "0")
                        If Ans.Length < nlen Then
                            Ans = Space(nlen - Ans.Length) & Ans
                        End If
                        If Des.Length < Dec Then
                            Des = Des & Space(Dec - Des.Length)
                        End If

                        Ans = Replace(Ans & "." & Des, " ", "0")
                        If Val(Ans) = 0 Then
                            Ans = Replace(Ans, "0", " ")
                            Ans = Replace(Ans, ".", " ")
                        End If
                    End If

                Catch ex As Exception
                    Ans = Space(3)

                End Try


            Case Types.IntegrtEnum
                Ans = Trim(sItem)
                Ans = Replace(Space(nlen - (Len(Ans))) & Ans, " ", "0")
            Case Types.StringEnum
                Try
                    Ans = Trim(sItem)
                    Ans = Ans & Space(nlen - (Len(Ans)))

                Catch ex As Exception
                    Ans = Space(nlen)

                End Try

        End Select

        Return Ans

    End Function

    Public Function GenMFT( _
            ByVal FILE_ID As String _
          , ByVal SENDER_CODE As String _
          , ByVal RECEIVER_CODE As String _
          , ByVal TRANSMISSION_DATE As String _
          , ByVal TRANSMISSION_TIME As String _
          , ByVal TFC_CODE As String _
          , ByVal LOADING_STATUS As String _
          , ByVal FINISH_DATE As String _
          , ByVal POD_RELEASE_DATE As String _
          , ByVal ENTRY_PROGRAM As String _
          , ByVal BL_SOURCE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(FILE_ID, 6, 0, Types.StringEnum)
        sResult &= FixLen(SENDER_CODE, 16, 0, Types.StringEnum)
        sResult &= FixLen(RECEIVER_CODE, 16, 0, Types.StringEnum)
        sResult &= FixLen(TRANSMISSION_DATE, 8, 0, Types.StringEnum)
        sResult &= FixLen(TRANSMISSION_TIME, 6, 0, Types.StringEnum)
        sResult &= FixLen(TFC_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(LOADING_STATUS, 2, 0, Types.StringEnum)
        sResult &= FixLen(FINISH_DATE, 15, 0, Types.StringEnum)
        sResult &= FixLen(POD_RELEASE_DATE, 15, 0, Types.StringEnum)
        sResult &= FixLen(ENTRY_PROGRAM, 8, 0, Types.StringEnum)
        sResult &= FixLen(BL_SOURCE, 8, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 18, 0, Types.StringEnum)

        Return sResult



    End Function


    Public Function GenKEY( _
        ByVal ROW_ID As String _
      , ByVal BOOK_NO As String _
      , ByVal SO_NO As String _
      , ByVal MO_NO As String _
      , ByVal TRANS_STATUS As String _
      , ByVal LINER_CODE As String _
      , ByVal OB_DATE As String _
      , ByVal BOOK_PREFIX As String _
      , ByVal BOOK_YEAR As String _
      , ByVal BOOK_SEQ As String _
      , ByVal POL As String _
      , ByVal POD As String _
      , ByVal PLR As String _
      , ByVal PLD As String _
      , ByVal BKG_PLACE As String _
      , ByVal BKG_BRANCH_CODE As String _
      , ByVal CONTRACT_NO As String _
      , ByVal FILLER As String _
      , ByVal BL_MASTER_HOUSE_TYPE_CODE As String _
      , ByVal BL_PROCESS_TYPE As String _
) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(BOOK_NO, 18, 0, Types.StringEnum)
        sResult &= FixLen(SO_NO, 8, 0, Types.StringEnum)
        sResult &= FixLen(MO_NO, 8, 0, Types.StringEnum)
        sResult &= FixLen(TRANS_STATUS, 3, 0, Types.StringEnum)
        sResult &= FixLen(LINER_CODE, 7, 0, Types.StringEnum)
        sResult &= FixLen(OB_DATE, 8, 0, Types.DateEnum)
        sResult &= FixLen(BOOK_PREFIX, 5, 0, Types.StringEnum)
        sResult &= FixLen(BOOK_YEAR, 4, 0, Types.StringEnum)
        sResult &= FixLen(BOOK_SEQ, 10, 0, Types.StringEnum)
        sResult &= FixLen(POL, 5, 0, Types.StringEnum)
        sResult &= FixLen(POD, 5, 0, Types.StringEnum)
        sResult &= FixLen(PLR, 5, 0, Types.StringEnum)
        sResult &= FixLen(PLD, 5, 0, Types.StringEnum)
        sResult &= FixLen(BKG_PLACE, 5, 0, Types.StringEnum)
        sResult &= FixLen(BKG_BRANCH_CODE, 2, 0, Types.StringEnum)
        sResult &= FixLen(CONTRACT_NO, 16, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 7, 0, Types.StringEnum)
        sResult &= FixLen(BL_MASTER_HOUSE_TYPE_CODE, 2, 0, Types.StringEnum)
        sResult &= FixLen(BL_PROCESS_TYPE, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_VESSEL As String _
          , ByVal BL_VOY_NO As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_VESSEL, 60, 0, Types.StringEnum)
        sResult &= FixLen(BL_VOY_NO, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLB( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_POL As String _
          , ByVal BL_POD As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_POL, 60, 0, Types.StringEnum)
        sResult &= FixLen(BL_POD, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLC( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_PLR As String _
          , ByVal BL_PLD As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_PLR, 60, 0, Types.StringEnum)
        sResult &= FixLen(BL_PLD, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLD( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_DSTN As String _
          , ByVal BL_TTL_PKG As String _
          , ByVal BL_CGO_MEA As String _
          , ByVal BL_CGO_WGT As String _
          , ByVal BL_CGO_NET_WGT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_DSTN, 60, 0, Types.StringEnum)
        sResult &= FixLen(BL_TTL_PKG, 8, 0, Types.StringEnum)
        sResult &= FixLen(BL_CGO_MEA, 15, 0, Types.StringEnum)
        sResult &= FixLen(BL_CGO_WGT, 15, 0, Types.StringEnum)
        sResult &= FixLen(BL_CGO_NET_WGT, 15, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 8, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLE( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal ISSUE_BL_DATE As String _
          , ByVal ISSUE_DO_DATE As String _
          , ByVal POL_VOICE_CODE As String _
          , ByVal POD_VOICE_CODE As String _
          , ByVal EC_MEMBER_ID As String _
          , ByVal ARRIVAL_DATE As String _
          , ByVal EX_RATE As String _
          , ByVal DO_PASSWD As String _
          , ByVal EC_NTFY_MEMBER_ID As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(ISSUE_BL_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(ISSUE_DO_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(POL_VOICE_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(POD_VOICE_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(EC_MEMBER_ID, 20, 0, Types.StringEnum)
        sResult &= FixLen(ARRIVAL_DATE, 8, 0, Types.DateEnum)
        sResult &= FixLen(EX_RATE, 18, 4, Types.DecimalEnum)
        sResult &= FixLen(DO_PASSWD, 5, 0, Types.StringEnum)
        sResult &= FixLen(EC_NTFY_MEMBER_ID, 20, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_REMARK As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_REMARK, 80, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 41, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLG( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POD_REMARK As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POD_REMARK, 80, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 41, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLH( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_PKG_UNIT As String _
          , ByVal BL_WGT_UNIT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_PKG_UNIT, 60, 0, Types.StringEnum)
        sResult &= FixLen(BL_WGT_UNIT, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLI( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_MEA_UNIT As String _
          , ByVal BL_PAID_TERM As String _
          , ByVal BL_PRE_CARRIAGE As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_MEA_UNIT, 60, 0, Types.StringEnum)
        sResult &= FixLen(BL_PAID_TERM, 1, 0, Types.StringEnum)
        sResult &= FixLen(BL_PRE_CARRIAGE, 60, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLJ( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_ISSUE_PLACE As String _
          , ByVal BL_FREIGHT_AT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_ISSUE_PLACE, 60, 0, Types.StringEnum)
        sResult &= FixLen(BL_FREIGHT_AT, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLK( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal VSL_CODE As String _
          , ByVal LOADED_ON As String _
          , ByVal CALL_SIGN As String _
          , ByVal VSL_REG_NO As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(VSL_CODE, 6, 0, Types.StringEnum)
        sResult &= FixLen(LOADED_ON, 60, 0, Types.StringEnum)
        sResult &= FixLen(CALL_SIGN, 6, 0, Types.StringEnum)
        sResult &= FixLen(VSL_REG_NO, 10, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 39, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLL( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal FREIGHT_PREPAID_AT As String _
          , ByVal PLACE_OF_ISSUE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(FREIGHT_PREPAID_AT, 60, 0, Types.StringEnum)
        sResult &= FixLen(PLACE_OF_ISSUE, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLM( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal TW_VIA_PORT_NAME As String _
          , ByVal TW_VIA_DATE As String _
          , ByVal DEST_ARRIVAL_DATE As String _
          , ByVal DOC_EXPIRED_DATE As String _
          , ByVal SRVC_TEL_NO As String _
          , ByVal DOC_PIC As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(TW_VIA_PORT_NAME, 10, 0, Types.StringEnum)
        sResult &= FixLen(TW_VIA_DATE, 10, 0, Types.DateEnum)
        sResult &= FixLen(DEST_ARRIVAL_DATE, 10, 0, Types.DateEnum)
        sResult &= FixLen(DOC_EXPIRED_DATE, 16, 0, Types.DateEnum)
        sResult &= FixLen(SRVC_TEL_NO, 20, 0, Types.StringEnum)
        sResult &= FixLen(DOC_PIC, 30, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 25, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBLN( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_LADEN_ON_BOARD As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_LADEN_ON_BOARD, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 61, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMRK( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal MARK As String _
          , ByVal C_INDICATOR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(MARK, 27, 0, Types.StringEnum)
        sResult &= FixLen(C_INDICATOR, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 93, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenDEC( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal DESCN As String _
          , ByVal C_INDICATOR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(DESCN, 31, 0, Types.StringEnum)
        sResult &= FixLen(C_INDICATOR, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 89, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenDCM( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal REMARK As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(REMARK, 31, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 90, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenLFW( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_FWRD_CODE As String _
          , ByVal POL_FWRD As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_FWRD_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(POL_FWRD, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 75, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenLFA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_FWRD_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_FWRD_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenLFF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_FWRD_FAX_HEAD As String _
          , ByVal POL_FWRD_FAX_AREA As String _
          , ByVal POL_FWRD_FAX As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_FWRD_FAX_HEAD, 6, 0, Types.StringEnum)
        sResult &= FixLen(POL_FWRD_FAX_AREA, 4, 0, Types.StringEnum)
        sResult &= FixLen(POL_FWRD_FAX, 10, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 101, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenLBK( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_BROKER As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_BROKER, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenLBA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_BROKER_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_BROKER_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenLBF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_BROKER_FAX_HEAD As String _
          , ByVal POL_BROKER_FAX_AREA As String _
          , ByVal POL_BROKER_FAX As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_BROKER_FAX_HEAD, 6, 0, Types.StringEnum)
        sResult &= FixLen(POL_BROKER_FAX_AREA, 4, 0, Types.StringEnum)
        sResult &= FixLen(POL_BROKER_FAX, 10, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 101, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenLBT( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_BROKER_TEL_HEAD As String _
          , ByVal POL_BROKER_TEL_AREA As String _
          , ByVal POL_BROKER_TEL As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_BROKER_TEL_HEAD, 6, 0, Types.StringEnum)
        sResult &= FixLen(POL_BROKER_TEL_AREA, 4, 0, Types.StringEnum)
        sResult &= FixLen(POL_BROKER_TEL, 10, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 101, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenSPR( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal SHPR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(SHPR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenSPA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal SHPR_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(SHPR_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenSPF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal SHPR_FAX_HEAD As String _
          , ByVal SHPR_FAX_AREA As String _
          , ByVal SHPR_FAX As String _
          , ByVal SHPR_MAIL_ACCT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(SHPR_FAX_HEAD, 6, 0, Types.StringEnum)
        sResult &= FixLen(SHPR_FAX_AREA, 4, 0, Types.StringEnum)
        sResult &= FixLen(SHPR_FAX, 10, 0, Types.StringEnum)
        sResult &= FixLen(SHPR_MAIL_ACCT, 70, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 31, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCSP( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C_SHPR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C_SHPR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCSA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C_SHPR_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C_SHPR_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCEE( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CONSIGNEE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CONSIGNEE, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCEA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CONSIGNEE_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CONSIGNEE_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCEF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CONSIGNEE_FAX_HEAD As String _
          , ByVal CONSIGNEE_FAX_AREA As String _
          , ByVal CONSIGNEE_FAX As String _
          , ByVal CNEE_MAIL_ACCT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CONSIGNEE_FAX_HEAD, 6, 0, Types.StringEnum)
        sResult &= FixLen(CONSIGNEE_FAX_AREA, 4, 0, Types.StringEnum)
        sResult &= FixLen(CONSIGNEE_FAX, 10, 0, Types.StringEnum)
        sResult &= FixLen(CNEE_MAIL_ACCT, 70, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 31, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCET( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CONSIGNEE_TEL_HEAD As String _
          , ByVal CONSIGNEE_TEL_AREA As String _
          , ByVal CONSIGNEE_TEL As String _
          , ByVal CONSIGNEE_TEL_EXT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CONSIGNEE_TEL_HEAD, 6, 0, Types.StringEnum)
        sResult &= FixLen(CONSIGNEE_TEL_AREA, 4, 0, Types.StringEnum)
        sResult &= FixLen(CONSIGNEE_TEL, 10, 0, Types.StringEnum)
        sResult &= FixLen(CONSIGNEE_TEL_EXT, 6, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 95, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCCE( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C_CONSIGNEE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C_CONSIGNEE, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCCA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C_CONSIGNEE_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C_CONSIGNEE_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCEP( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CONSIGNEE_PIC As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CONSIGNEE_PIC, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenNTF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal NOTIFY As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(NOTIFY, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenNFA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal NOTIFY_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(NOTIFY_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenNFF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal NOTIFY_FAX_HEAD As String _
          , ByVal NOTIFY_FAX_AREA As String _
          , ByVal NOTIFY_FAX As String _
          , ByVal NTFY_MAIL_ACCT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(NOTIFY_FAX_HEAD, 6, 0, Types.StringEnum)
        sResult &= FixLen(NOTIFY_FAX_AREA, 4, 0, Types.StringEnum)
        sResult &= FixLen(NOTIFY_FAX, 10, 0, Types.StringEnum)
        sResult &= FixLen(NTFY_MAIL_ACCT, 70, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 31, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenNFT( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal NOTIFY_TEL_HEAD As String _
          , ByVal NOTIFY_TEL_AREA As String _
          , ByVal NOTIFY_TEL As String _
          , ByVal NOTIFY_TEL_EXT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(NOTIFY_TEL_HEAD, 6, 0, Types.StringEnum)
        sResult &= FixLen(NOTIFY_TEL_AREA, 4, 0, Types.StringEnum)
        sResult &= FixLen(NOTIFY_TEL, 10, 0, Types.StringEnum)
        sResult &= FixLen(NOTIFY_TEL_EXT, 6, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 95, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCNF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C_NOTIFY As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C_NOTIFY, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCNA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C_NOTIFY_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C_NOTIFY_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenNTP( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal NTFY_PIC As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(NTFY_PIC, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenANY( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal ALSO_NOTIFY As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(ALSO_NOTIFY, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenANA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal ALSO_NOTIFY_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(ALSO_NOTIFY_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCAN( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C_ALSO_NOTIFY As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C_ALSO_NOTIFY, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCAA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C_ALSO_NOTIFY_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C_ALSO_NOTIFY_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenDFW( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POD_FWRD_CODE As String _
          , ByVal POD_FWRD As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POD_FWRD_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(POD_FWRD, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 75, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenDFA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POD_FWRD_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(POD_FWRD_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenDBK( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POD_BROKER As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(POD_BROKER, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenDBT( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POD_BROKER_TEL_HEAD As String _
          , ByVal POD_BROKER_TEL_AREA As String _
          , ByVal POD_BROKER_TEL As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(POD_BROKER_TEL_HEAD, 6, 0, Types.StringEnum)
        sResult &= FixLen(POD_BROKER_TEL_AREA, 4, 0, Types.StringEnum)
        sResult &= FixLen(POD_BROKER_TEL, 10, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 101, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenSLR( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal SELLER As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(SELLER, 35, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 86, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenSLA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal SELLER_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(SELLER_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBYR( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BUYER As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(BUYER, 35, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 86, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBYA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BUYER_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(BUYER_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMAR( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal MANUFACTURER As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(MANUFACTURER, 35, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 86, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMAA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal MANUFACTURER_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(MANUFACTURER_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenSTN( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal SHIP_TO As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(SHIP_TO, 35, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 86, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenSTA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal SHIP_TO_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(SHIP_TO_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCSR( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CONSOLIDATOR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(CONSOLIDATOR, 35, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 86, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCSRA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CONSOLIDATOR_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(CONSOLIDATOR_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBPN( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BOOK_PARTY As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(BOOK_PARTY, 35, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 86, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenBPA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BOOK_PARTY_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(BOOK_PARTY_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenPYO( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal OFT_PAYER As String _
          , ByVal OFT_PAYER_DISTRICT As String _
          , ByVal OFT_PAYER_REG_CODE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(OFT_PAYER, 72, 0, Types.StringEnum)
        sResult &= FixLen(OFT_PAYER_DISTRICT, 20, 0, Types.StringEnum)
        sResult &= FixLen(OFT_PAYER_REG_CODE, 14, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 15, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenPYH( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal THC_PAYER As String _
          , ByVal THC_PAYER_DISTRICT As String _
          , ByVal THC_PAYER_REG_CODE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(THC_PAYER, 72, 0, Types.StringEnum)
        sResult &= FixLen(THC_PAYER_DISTRICT, 20, 0, Types.StringEnum)
        sResult &= FixLen(THC_PAYER_REG_CODE, 14, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 15, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenPYD( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POD_PAYER As String _
          , ByVal POD_PAYER_DISTRICT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(POD_PAYER, 72, 0, Types.StringEnum)
        sResult &= FixLen(POD_PAYER_DISTRICT, 20, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 29, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenPYT( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal TAP_PAYER As String _
          , ByVal TAP_PAYER_DISTRICT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.StringEnum)
        sResult &= FixLen(TAP_PAYER, 72, 0, Types.StringEnum)
        sResult &= FixLen(TAP_PAYER_DISTRICT, 20, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 29, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal FINAL_PORT As String _
          , ByVal FINAL_DESTINATION As String _
          , ByVal IS_FREE_SUR_POL As String _
          , ByVal FILLER1 As String _
          , ByVal IS_FCL_OVER As String _
          , ByVal BL_TYPE As String _
          , ByVal GET_BL_PLACE As String _
          , ByVal OFT_PAYMENT_TYPE As String _
          , ByVal NO_OF_ORGN As String _
          , ByVal ISSUE_BL_DATE As String _
          , ByVal ISSUE_SWITCH_BL_PLACE As String _
          , ByVal ISSUE_MEMO_BL_PLACE As String _
          , ByVal ISSUE_MEMO_BL_TYPE As String _
          , ByVal ORGN_BL_NO As String _
          , ByVal IS_CALC_PMW As String _
          , ByVal IS_CHECK_OK As String _
          , ByVal IS_CALC_CHARGE As String _
          , ByVal FILLER2 As String _
          , ByVal FINISH_DATE As String _
          , ByVal POD_RELEASE_DATE As String _
          , ByVal GET_BL_OFFICE As String _
          , ByVal ISSUE_SWITCH_BL_BRANCH As String _
          , ByVal ISSUE_MEMO_BL_BRANCH As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(FINAL_PORT, 5, 0, Types.StringEnum)
        sResult &= FixLen(FINAL_DESTINATION, 5, 0, Types.StringEnum)
        sResult &= FixLen(IS_FREE_SUR_POL, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER1, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_FCL_OVER, 1, 0, Types.StringEnum)
        sResult &= FixLen(BL_TYPE, 1, 0, Types.StringEnum)
        sResult &= FixLen(GET_BL_PLACE, 5, 0, Types.StringEnum)
        sResult &= FixLen(OFT_PAYMENT_TYPE, 1, 0, Types.StringEnum)
        sResult &= FixLen(NO_OF_ORGN, 2, 0, Types.StringEnum)
        sResult &= FixLen(ISSUE_BL_DATE, 8, 0, Types.DateEnum)
        sResult &= FixLen(ISSUE_SWITCH_BL_PLACE, 5, 0, Types.StringEnum)
        sResult &= FixLen(ISSUE_MEMO_BL_PLACE, 5, 0, Types.StringEnum)
        sResult &= FixLen(ISSUE_MEMO_BL_TYPE, 1, 0, Types.StringEnum)
        sResult &= FixLen(ORGN_BL_NO, 22, 0, Types.StringEnum)
        sResult &= FixLen(IS_CALC_PMW, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_CHECK_OK, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_CALC_CHARGE, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER2, 13, 0, Types.StringEnum)
        sResult &= FixLen(FINISH_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(POD_RELEASE_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(GET_BL_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(ISSUE_SWITCH_BL_BRANCH, 2, 0, Types.StringEnum)
        sResult &= FixLen(ISSUE_MEMO_BL_BRANCH, 2, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGB( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_CUSTOMS_CODE As String _
          , ByVal POD_CUSTOMS_CODE As String _
          , ByVal TTL_PKG As String _
          , ByVal TTL_PKG_UNIT As String _
          , ByVal CGO_MEASURE As String _
          , ByVal CGO_GROSS_WEIGHT As String _
          , ByVal CGO_NET_WEIGHT As String _
          , ByVal ITEM_CODE As String _
          , ByVal IS_PRINT_FREIGHT As String _
          , ByVal IS__PRINT__VSL_CERT As String _
          , ByVal IS__PRINT__SEAL_CODE As String _
          , ByVal IS__PRINT__DEBT_NOTE As String _
          , ByVal IS__PRINT__SHPR As String _
          , ByVal IS__PRINT__SHPR_ADDR As String _
          , ByVal IS__PRINT__C_SHPR As String _
          , ByVal IS__PRINT__C_SHPR_ADDR As String _
          , ByVal IS__PRINT__NTFY As String _
          , ByVal IS__PRINT__NTFY_ADDR As String _
          , ByVal IS__PRINT__C_NTFY As String _
          , ByVal IS__PRINT__C_NTFY_ADDR As String _
          , ByVal IS__PRINT__ALSO_NTFY As String _
          , ByVal IS_PRINT_ALSO_NTFY_ADDR As String _
          , ByVal IS__PRINT__C_ALSO_NTFY As String _
          , ByVal IS_PRINT_C_ALSO_NTFY_ADDR As String _
          , ByVal IS__PRINT__CNEE As String _
          , ByVal IS__PRINT__CNEE_ADDR As String _
          , ByVal IS__PRINT__C_CNEE As String _
          , ByVal IS__PRINT__C_CNEE_ADDR As String _
          , ByVal IS__PRINT__C_MARK As String _
          , ByVal IS__PRINT__C_DESC As String _
          , ByVal IS_CTNR_ATTACH As String _
          , ByVal ATTACH_MARK As String _
          , ByVal MEASURE_PRINT_DECIMAL As String _
          , ByVal MEASURE_UNIT As String _
          , ByVal WEIGHT_UNIT As String _
          , ByVal IS_MONETARY As String _
          , ByVal IS_NON_MONETARY As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_CUSTOMS_CODE, 6, 0, Types.StringEnum)
        sResult &= FixLen(POD_CUSTOMS_CODE, 6, 0, Types.StringEnum)
        sResult &= FixLen(TTL_PKG, 8, 0, Types.IntegrtEnum)
        sResult &= FixLen(TTL_PKG_UNIT, 4, 0, Types.StringEnum)
        sResult &= FixLen(CGO_MEASURE, 10, 4, Types.DecimalEnum)
        sResult &= FixLen(CGO_GROSS_WEIGHT, 10, 4, Types.DecimalEnum)
        sResult &= FixLen(CGO_NET_WEIGHT, 10, 4, Types.DecimalEnum)
        sResult &= FixLen(ITEM_CODE, 16, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRINT_FREIGHT, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__VSL_CERT, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__SEAL_CODE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__DEBT_NOTE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__SHPR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__SHPR_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__C_SHPR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__C_SHPR_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__NTFY, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__NTFY_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__C_NTFY, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__C_NTFY_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__ALSO_NTFY, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRINT_ALSO_NTFY_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__C_ALSO_NTFY, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRINT_C_ALSO_NTFY_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__CNEE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__CNEE_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__C_CNEE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__C_CNEE_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__C_MARK, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS__PRINT__C_DESC, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_CTNR_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(ATTACH_MARK, 1, 0, Types.StringEnum)
        sResult &= FixLen(MEASURE_PRINT_DECIMAL, 1, 0, Types.StringEnum)
        sResult &= FixLen(MEASURE_UNIT, 4, 0, Types.StringEnum)
        sResult &= FixLen(WEIGHT_UNIT, 4, 0, Types.StringEnum)
        sResult &= FixLen(IS_MONETARY, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_NON_MONETARY, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGC( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal INCL_COMB As String _
          , ByVal INCL_COMB_LIST As String _
          , ByVal SCAC_CODE As String _
          , ByVal ISS_CODE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(INCL_COMB, 1, 0, Types.StringEnum)
        sResult &= FixLen(INCL_COMB_LIST, 80, 0, Types.StringEnum)
        sResult &= FixLen(SCAC_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(ISS_CODE, 20, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 10, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGD( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal ALLIN_LIST As String _
          , ByVal ALLIN_CURR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(ALLIN_LIST, 100, 0, Types.StringEnum)
        sResult &= FixLen(ALLIN_CURR, 3, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 18, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGE( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C131 As String _
          , ByVal C133 As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C131, 60, 0, Types.StringEnum)
        sResult &= FixLen(C133, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_STORE_PLACE As String _
          , ByVal POD_STORE_PLACE As String _
          , ByVal JV_CODE As String _
          , ByVal PREV_TRANS_PORT As String _
          , ByVal PREV_TFC_CODE As String _
          , ByVal P_TFC_CODE As String _
          , ByVal PLAN_TRANS_PORT As String _
          , ByVal PLAN_N_TFC_CODE As String _
          , ByVal IS_BL_CTNR_ATTACH As String _
          , ByVal IS_BL_MARK_ATTACH As String _
          , ByVal IS_BL_DESC_ATTACH As String _
          , ByVal IS_DO_CTNR_ATTACH As String _
          , ByVal IS_DO_MARK_ATTACH As String _
          , ByVal IS_DO_DESC_ATTACH As String _
          , ByVal IS_AN_CTNR_ATTACH As String _
          , ByVal IS_AN_MARK_ATTACH As String _
          , ByVal IS_AN_DESC_ATTACH As String _
          , ByVal GET_DO_PLACE As String _
          , ByVal GET_DO_BRANCH As String _
          , ByVal IS_PRT_POL_FWRD_ADDR As String _
          , ByVal IS_PRT_POD_FWRD_ADDR As String _
          , ByVal IS_PRT_POL_BRKR_ADDR As String _
          , ByVal IS_PRT_POD_BRKR_ADDR As String _
          , ByVal IS_EMPTY_CTNR As String _
          , ByVal IS_EMPTY_CTNR_DCLR As String _
          , ByVal IS_PRT_CGO_GROSS_WEIGHT As String _
          , ByVal IS_PRT_CGO_NET_WEIGHT As String _
          , ByVal IS_PROHIBIT_CHG As String _
          , ByVal IS_POD_PRT_DB_NOTE As String _
          , ByVal ISSUE_DO_OFFICE As String _
          , ByVal SUMM_CODE As String _
          , ByVal IS_BL_CHARGE_ATTACH As String _
          , ByVal IS_DO_CHARGE_ATTACH As String _
          , ByVal IS_AN_CHARGE_ATTACH As String _
          , ByVal IS_PRT_CGO_MEASURE As String _
          , ByVal IS_PRT_FCL_CLAUSE As String _
          , ByVal IS_PRT_SAY_TTL_CLAUSE As String _
          , ByVal IS_PRT_BL_OB_DATE As String _
          , ByVal IS_PRT_BL_EX_RATE As String _
          , ByVal IS_PRT_BL_ISSUE_DATE As String _
          , ByVal IS_PRT_BL_ATTACHED As String _
          , ByVal IS_CONFIRM_BY_MFT_OFFICE As String _
          , ByVal IS_NEW_BL_AFTER_VOYAGE_FINISH As String _
          , ByVal IS_DUMMY As String _
          , ByVal IS_URGENT_CARGO As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_STORE_PLACE, 8, 0, Types.StringEnum)
        sResult &= FixLen(POD_STORE_PLACE, 8, 0, Types.StringEnum)
        sResult &= FixLen(JV_CODE, 7, 0, Types.StringEnum)
        sResult &= FixLen(PREV_TRANS_PORT, 5, 0, Types.StringEnum)
        sResult &= FixLen(PREV_TFC_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(P_TFC_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(PLAN_TRANS_PORT, 5, 0, Types.StringEnum)
        sResult &= FixLen(PLAN_N_TFC_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(IS_BL_CTNR_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_BL_MARK_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_BL_DESC_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_DO_CTNR_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_DO_MARK_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_DO_DESC_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_AN_CTNR_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_AN_MARK_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_AN_DESC_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(GET_DO_PLACE, 5, 0, Types.StringEnum)
        sResult &= FixLen(GET_DO_BRANCH, 2, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_POL_FWRD_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_POD_FWRD_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_POL_BRKR_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_POD_BRKR_ADDR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_EMPTY_CTNR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_EMPTY_CTNR_DCLR, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_CGO_GROSS_WEIGHT, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_CGO_NET_WEIGHT, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PROHIBIT_CHG, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_POD_PRT_DB_NOTE, 1, 0, Types.StringEnum)
        sResult &= FixLen(ISSUE_DO_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(SUMM_CODE, 6, 0, Types.StringEnum)
        sResult &= FixLen(IS_BL_CHARGE_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_DO_CHARGE_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_AN_CHARGE_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_CGO_MEASURE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_FCL_CLAUSE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_SAY_TTL_CLAUSE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_BL_OB_DATE, 1, 0, Types.DateEnum)
        sResult &= FixLen(IS_PRT_BL_EX_RATE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_BL_ISSUE_DATE, 1, 0, Types.DateEnum)
        sResult &= FixLen(IS_PRT_BL_ATTACHED, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_CONFIRM_BY_MFT_OFFICE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_NEW_BL_AFTER_VOYAGE_FINISH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_DUMMY, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_URGENT_CARGO, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 5, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGG( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C132 As String _
          , ByVal POL_POD_TERM As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C132, 60, 0, Types.StringEnum)
        sResult &= FixLen(POL_POD_TERM, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGH( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C121 As String _
          , ByVal C122 As String _
          , ByVal C123 As String _
          , ByVal BULK_CARGO_TEU As String _
          , ByVal BULK_CARGO_POL_AREA_CODE As String _
          , ByVal BULK_CARGO_POD_AREA_CODE As String _
          , ByVal SAP_SHIPMENT_NO As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C121, 30, 0, Types.StringEnum)
        sResult &= FixLen(C122, 30, 0, Types.StringEnum)
        sResult &= FixLen(C123, 30, 0, Types.StringEnum)
        sResult &= FixLen(BULK_CARGO_TEU, 3, 0, Types.StringEnum)
        sResult &= FixLen(BULK_CARGO_POL_AREA_CODE, 6, 0, Types.StringEnum)
        sResult &= FixLen(BULK_CARGO_POD_AREA_CODE, 6, 0, Types.StringEnum)
        sResult &= FixLen(SAP_SHIPMENT_NO, 16, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGI( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CUSTOMER_INVOICE_SHIPMENT_NO As String _
          , ByVal ALLOW_PRT_ORIGINAL_BL_EC As String _
          , ByVal TRAN_EC_DATE As String _
          , ByVal TRAN_DO_PASSWD_TO_EC_DATE As String _
          , ByVal EC_DO_PASSWD As String _
          , ByVal COPY_NO As String _
          , ByVal TRUCK_COMPANY_CODE As String _
          , ByVal DEBIT_CODE As String _
          , ByVal FILLER As String _
    ) As String

        'Not match with Paragon output 

        'Dim sResult As String = ""
        'sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        'sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        'sResult &= FixLen(CUSTOMER_INVOICE_SHIPMENT_NO, 59, 0, Types.StringEnum)
        'sResult &= FixLen(ALLOW_PRT_ORIGINAL_BL_EC, 1, 0, Types.StringEnum)
        'sResult &= FixLen(TRAN_EC_DATE, 15, 0, Types.DateEnum)
        'sResult &= FixLen(TRAN_DO_PASSWD_TO_EC_DATE, 15, 0, Types.DateEnum)
        'sResult &= FixLen(EC_DO_PASSWD, 5, 0, Types.StringEnum)
        'sResult &= FixLen(COPY_NO, 3, 0, Types.StringEnum)
        'sResult &= FixLen(TRUCK_COMPANY_CODE, 12, 0, Types.StringEnum)
        'sResult &= FixLen(DEBIT_CODE, 10, 0, Types.StringEnum)
        'sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)

        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CUSTOMER_INVOICE_SHIPMENT_NO, 59, 0, Types.StringEnum)
        sResult &= Space(1)
        sResult &= FixLen(CUSTOMER_INVOICE_SHIPMENT_NO, 59, 0, Types.StringEnum)



        Return sResult
    End Function
    Public Function GenMGJ( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_EDI_REMARK As String _
          , ByVal POD_EDI_REMARK As String _
          , ByVal EDI_TTL_PKG As String _
          , ByVal EDI_PKG_UNIT As String _
          , ByVal CUSTOMS_CLEARANCE As String _
          , ByVal FILLER1 As String _
          , ByVal EDI_CGO_GROSS_WEIGHT As String _
          , ByVal CUSTOMS_SO_NO As String _
          , ByVal FILLER2 As String _
          , ByVal POL_EDI_STATUS As String _
          , ByVal POD_EDI_STATUS As String _
          , ByVal IS_POL_EDI As String _
          , ByVal IS_POL_DOC_ACCT As String _
          , ByVal IS_POD_EDI_DOC As String _
          , ByVal IS_POD_ACCT As String _
          , ByVal POD_CUSTOMS_DATE As String _
          , ByVal FIN_LINER_CODE As String _
          , ByVal FIN_PLR As String _
          , ByVal FIN_POL As String _
          , ByVal FIN_POD As String _
          , ByVal FIN_PLD As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_EDI_REMARK, 1, 0, Types.StringEnum)
        sResult &= FixLen(POD_EDI_REMARK, 1, 0, Types.StringEnum)
        sResult &= FixLen(EDI_TTL_PKG, 8, 0, Types.StringEnum)
        sResult &= FixLen(EDI_PKG_UNIT, 4, 0, Types.StringEnum)
        sResult &= FixLen(CUSTOMS_CLEARANCE, 17, 0, Types.StringEnum)
        sResult &= FixLen(FILLER1, 2, 0, Types.StringEnum)
        sResult &= FixLen(EDI_CGO_GROSS_WEIGHT, 15, 4, Types.StringEnum)
        sResult &= FixLen(CUSTOMS_SO_NO, 16, 0, Types.StringEnum)
        sResult &= FixLen(FILLER2, 7, 0, Types.StringEnum)
        sResult &= FixLen(POL_EDI_STATUS, 1, 0, Types.StringEnum)
        sResult &= FixLen(POD_EDI_STATUS, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_POL_EDI, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_POL_DOC_ACCT, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_POD_EDI_DOC, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_POD_ACCT, 1, 0, Types.StringEnum)
        sResult &= FixLen(POD_CUSTOMS_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(FIN_LINER_CODE, 7, 0, Types.StringEnum)
        sResult &= FixLen(FIN_PLR, 5, 0, Types.StringEnum)
        sResult &= FixLen(FIN_POL, 5, 0, Types.StringEnum)
        sResult &= FixLen(FIN_POD, 5, 0, Types.StringEnum)
        sResult &= FixLen(FIN_PLD, 5, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 2, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGK( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal PRT_BL_USER As String _
          , ByVal PRT_BL_OFFICE As String _
          , ByVal PRT_BL_DATE As String _
          , ByVal REPRT_BL_USER As String _
          , ByVal REPRT_BL_OFFICE As String _
          , ByVal REPRT_BL_DATE As String _
          , ByVal ISSUE_TLXRL_TYPE As String _
          , ByVal CONFIRM_TLXRL_USER As String _
          , ByVal CONFIRM_TLXRL_OFFICE As String _
          , ByVal CONFIRM_TLXRL_DATE As String _
          , ByVal TLXRL_TO_PLACE As String _
          , ByVal TLXRL_TO_BRANCH As String _
          , ByVal TLXRL_CODE As String _
          , ByVal IS_PRTED_BL As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(PRT_BL_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(PRT_BL_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(PRT_BL_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(REPRT_BL_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(REPRT_BL_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(REPRT_BL_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(ISSUE_TLXRL_TYPE, 1, 0, Types.StringEnum)
        sResult &= FixLen(CONFIRM_TLXRL_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(CONFIRM_TLXRL_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(CONFIRM_TLXRL_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(TLXRL_TO_PLACE, 5, 0, Types.StringEnum)
        sResult &= FixLen(TLXRL_TO_BRANCH, 2, 0, Types.StringEnum)
        sResult &= FixLen(TLXRL_CODE, 16, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRTED_BL, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGL( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal GENERATE_TLXRL_USER As String _
          , ByVal GENERATE_TLXRL_OFFICE As String _
          , ByVal GENERATE_TLXRL_DATE As String _
          , ByVal FILLER1 As String _
          , ByVal ISSUE_NOTICE_TLXRL_USER As String _
          , ByVal ISSUE_NOTICE_TLXRL_OFFICE As String _
          , ByVal ISSUE_NOTICE_TLXRL_DATE As String _
          , ByVal GENERATE_TLXRL_USER_SWITCHBL As String _
          , ByVal GENERATE_TLXRL_OFFICE_SWITCHBL As String _
          , ByVal GENERATE_TLXRL_DATE_SWITCHBL As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(GENERATE_TLXRL_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(GENERATE_TLXRL_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(GENERATE_TLXRL_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(FILLER1, 15, 0, Types.StringEnum)
        sResult &= FixLen(ISSUE_NOTICE_TLXRL_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(ISSUE_NOTICE_TLXRL_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(ISSUE_NOTICE_TLXRL_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(GENERATE_TLXRL_USER_SWITCHBL, 10, 0, Types.StringEnum)
        sResult &= FixLen(GENERATE_TLXRL_OFFICE_SWITCHBL, 7, 0, Types.StringEnum)
        sResult &= FixLen(GENERATE_TLXRL_DATE_SWITCHBL, 15, 0, Types.DateEnum)
        sResult &= FixLen(FILLER, 10, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGM( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_FAXOUT_USER As String _
          , ByVal BL_FAXOUT_OFFICE As String _
          , ByVal BL_FAXOUT_DATE As String _
          , ByVal FILLER1 As String _
          , ByVal PRT_DO_USER As String _
          , ByVal PRT_DO_OFFICE As String _
          , ByVal PRT_DO_DATE As String _
          , ByVal REPRT_DO_USER As String _
          , ByVal REPRT_DO_OFFICE As String _
          , ByVal REPRT_DO_DATE As String _
          , ByVal HOLD_CHG_USER As String _
          , ByVal HOLD_CHG_OFFICE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_FAXOUT_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(BL_FAXOUT_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(BL_FAXOUT_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(FILLER1, 5, 0, Types.StringEnum)
        sResult &= FixLen(PRT_DO_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(PRT_DO_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(PRT_DO_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(REPRT_DO_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(REPRT_DO_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(REPRT_DO_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(HOLD_CHG_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(HOLD_CHG_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 3, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGN( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal HOLD_CHG_DATE As String _
          , ByVal HOLD_CHG As String _
          , ByVal HOLD_CHG_REMARK As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(HOLD_CHG_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(HOLD_CHG, 1, 0, Types.StringEnum)
        sResult &= FixLen(HOLD_CHG_REMARK, 100, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 5, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGO( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal PRT_POL_MF_USER As String _
          , ByVal PRT_POL_MF_OFFICE As String _
          , ByVal PRT_POL_MF_DATE As String _
          , ByVal PRT_POD_MF_USER As String _
          , ByVal PRT_POD_MF_OFFICE As String _
          , ByVal PRT_POD_MF_DATE As String _
          , ByVal PRT_TRS_MF_USER As String _
          , ByVal PRT_TRS_MF_OFFICE As String _
          , ByVal PRT_TRS_MF_DATE As String _
          , ByVal TO_TLXRL_OFFICE_FOR_SWITCH_BL As String _
          , ByVal TLXRL_CODE_FOR_SWITCH_BL As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(PRT_POL_MF_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(PRT_POL_MF_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(PRT_POL_MF_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(PRT_POD_MF_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(PRT_POD_MF_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(PRT_POD_MF_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(PRT_TRS_MF_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(PRT_TRS_MF_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(PRT_TRS_MF_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(TO_TLXRL_OFFICE_FOR_SWITCH_BL, 7, 0, Types.StringEnum)
        sResult &= FixLen(TLXRL_CODE_FOR_SWITCH_BL, 16, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 2, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGP( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal MFT_DATE As String _
          , ByVal TWEDI_N_TFC_CODE As String _
          , ByVal TWEDI_TRANS_PORT As String _
          , ByVal MFT_OFFICE As String _
          , ByVal C124 As String _
          , ByVal C125 As String _
          , ByVal FILLER1 As String _
          , ByVal MFT_SORT_MARK As String _
          , ByVal TWT_VIA_PORT As String _
          , ByVal IS_PRT_CTNR_DETAIL As String _
          , ByVal IS_WEB_BL_CTNR_ATTACH As String _
          , ByVal IS_WEB_AN_CTNR_ATTACH As String _
          , ByVal IS_WEB_DO_CTNR_ATTACH As String _
          , ByVal IS_WEB_BL_MARK_ATTACH As String _
          , ByVal IS_WEB_AN_MARK_ATTACH As String _
          , ByVal IS_WEB_DO_MARK_ATTACH As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(MFT_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(TWEDI_N_TFC_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(TWEDI_TRANS_PORT, 5, 0, Types.StringEnum)
        sResult &= FixLen(MFT_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(C124, 30, 0, Types.StringEnum)
        sResult &= FixLen(C125, 30, 0, Types.StringEnum)
        sResult &= FixLen(FILLER1, 6, 0, Types.StringEnum)
        sResult &= FixLen(MFT_SORT_MARK, 5, 0, Types.StringEnum)
        sResult &= FixLen(TWT_VIA_PORT, 5, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_CTNR_DETAIL, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_WEB_BL_CTNR_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_WEB_AN_CTNR_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_WEB_DO_CTNR_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_WEB_BL_MARK_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_WEB_AN_MARK_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_WEB_DO_MARK_ATTACH, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGQ( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal ISSUE_MEMO_BL_OB As String _
          , ByVal POL_CUSTOMS_ITEM_CODE As String _
          , ByVal POD_CUSTOMS_ITEM_CODE As String _
          , ByVal NON_CTNR_POL_DEPOT_CODE As String _
          , ByVal NON_CTNR_POD_DEPOT_CODE As String _
          , ByVal NON_CTNR_VIA_DEPOT_CODE As String _
          , ByVal MF_REFERENCE_NO As String _
          , ByVal FINISH_USER As String _
          , ByVal MFT_FUNCTION As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(ISSUE_MEMO_BL_OB, 36, 0, Types.StringEnum)
        sResult &= FixLen(POL_CUSTOMS_ITEM_CODE, 20, 0, Types.StringEnum)
        sResult &= FixLen(POD_CUSTOMS_ITEM_CODE, 20, 0, Types.StringEnum)
        sResult &= FixLen(NON_CTNR_POL_DEPOT_CODE, 5, 0, Types.StringEnum)
        sResult &= FixLen(NON_CTNR_POD_DEPOT_CODE, 5, 0, Types.StringEnum)
        sResult &= FixLen(NON_CTNR_VIA_DEPOT_CODE, 5, 0, Types.StringEnum)
        sResult &= FixLen(MF_REFERENCE_NO, 15, 0, Types.StringEnum)
        sResult &= FixLen(FINISH_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(MFT_FUNCTION, 3, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 2, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGR( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal C134 As String _
          , ByVal C135 As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(C134, 60, 0, Types.StringEnum)
        sResult &= FixLen(C135, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGS( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal TLXRL_CANCEL_REMARK As String _
          , ByVal TLXRL_REMARK As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(TLXRL_CANCEL_REMARK, 60, 0, Types.StringEnum)
        sResult &= FixLen(TLXRL_REMARK, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGT( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal BL_LIST As String _
          , ByVal SO_LIST As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(BL_LIST, 60, 0, Types.StringEnum)
        sResult &= FixLen(SO_LIST, 60, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGU( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal INCL_COMB As String _
          , ByVal INCL_COMB_LIST As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(INCL_COMB, 1, 0, Types.StringEnum)
        sResult &= FixLen(INCL_COMB_LIST, 80, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 40, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGV( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal NANDA_SHPR As String _
          , ByVal NANDA_CNEE As String _
          , ByVal NANDA_NTFY As String _
          , ByVal IS_REGISTER_FDA As String _
          , ByVal NANDA_ALSO_NTFY As String _
          , ByVal NANDA_POD_FWRD As String _
          , ByVal NANDA_POD_BRKR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(NANDA_SHPR, 6, 0, Types.StringEnum)
        sResult &= FixLen(NANDA_CNEE, 6, 0, Types.StringEnum)
        sResult &= FixLen(NANDA_NTFY, 6, 0, Types.StringEnum)
        sResult &= FixLen(IS_REGISTER_FDA, 1, 0, Types.StringEnum)
        sResult &= FixLen(NANDA_ALSO_NTFY, 6, 0, Types.StringEnum)
        sResult &= FixLen(NANDA_POD_FWRD, 6, 0, Types.StringEnum)
        sResult &= FixLen(NANDA_POD_BRKR, 6, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 84, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGW( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal ACCOUNT_BULLET_NAME As String _
          , ByVal PLAN_OTH_PAYAT_LIST As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(ACCOUNT_BULLET_NAME, 72, 0, Types.StringEnum)
        sResult &= FixLen(PLAN_OTH_PAYAT_LIST, 35, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 14, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGX( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal ISF_DECLARE As String _
          , ByVal IMPORTER_NO As String _
          , ByVal COUNTRY_OF_ORIGIN As String _
          , ByVal HTSUS_CODE As String _
          , ByVal CTNR_STUFFING_LOC As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(ISF_DECLARE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IMPORTER_NO, 30, 0, Types.StringEnum)
        sResult &= FixLen(COUNTRY_OF_ORIGIN, 2, 0, Types.StringEnum)
        sResult &= FixLen(HTSUS_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_STUFFING_LOC, 35, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 110, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenMGY( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CNEE_NO As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CNEE_NO, 120, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 1, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCGAE( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CHARGE_CODE As String _
          , ByVal ACT_PLACE_EX_RATE As String _
          , ByVal MEA_UNIT_OF_CHARGE As String _
          , ByVal CURR As String _
          , ByVal AMOUNT As String _
          , ByVal FM_PLACE As String _
          , ByVal TO_PLACE As String _
          , ByVal PAY_AT As String _
          , ByVal PAY_AT_BRANCH As String _
          , ByVal PAY_AT_EX_RATE As String _
          , ByVal PAY_AT_PC As String _
          , ByVal PAID_TERM As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CHARGE_CODE, 4, 0, Types.StringEnum)
        sResult &= FixLen(ACT_PLACE_EX_RATE, 13, 4, Types.DecimalEnum)
        sResult &= FixLen(MEA_UNIT_OF_CHARGE, 3, 0, Types.StringEnum)
        sResult &= FixLen(CURR, 3, 0, Types.StringEnum)
        sResult &= FixLen(AMOUNT, 13, 4, Types.DecimalEnum)
        sResult &= FixLen(FM_PLACE, 8, 0, Types.StringEnum)
        sResult &= FixLen(TO_PLACE, 8, 0, Types.StringEnum)
        sResult &= FixLen(PAY_AT, 5, 0, Types.StringEnum)
        sResult &= FixLen(PAY_AT_BRANCH, 2, 0, Types.StringEnum)
        sResult &= FixLen(PAY_AT_EX_RATE, 13, 4, Types.DecimalEnum)
        sResult &= FixLen(PAY_AT_PC, 1, 0, Types.StringEnum)
        sResult &= FixLen(PAID_TERM, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 32, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCGB( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal PAYER As String _
          , ByVal PAYER_DISTRICT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(PAYER, 72, 0, Types.StringEnum)
        sResult &= FixLen(PAYER_DISTRICT, 20, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 29, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCGC( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal FILLER As String _
          , ByVal PAYER_REG_CODE As String _
          , ByVal PAYER_CODE As String _
          , ByVal FILLER1 As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(FILLER, 26, 0, Types.StringEnum)
        sResult &= FixLen(PAYER_REG_CODE, 14, 0, Types.StringEnum)
        sResult &= FixLen(PAYER_CODE, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER1, 45, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCGD( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal PRT_SEQ As String _
          , ByVal TEMP_PAY_AT As String _
          , ByVal TEMP_PAY_AT_BRANCH As String _
          , ByVal TEMP_PAY_AT_PC As String _
          , ByVal TEMP_PAY_AT_EX_RATE As String _
          , ByVal PAYER_TAX_CODE As String _
          , ByVal FILLER1 As String _
          , ByVal ORG_TRANS_AR_DATE As String _
          , ByVal ENTRY_OFFICE As String _
          , ByVal ENTRY_USER As String _
          , ByVal PAYAT_ORG_TRANS_AR_DATE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(PRT_SEQ, 4, 0, Types.StringEnum)
        sResult &= FixLen(TEMP_PAY_AT, 5, 0, Types.StringEnum)
        sResult &= FixLen(TEMP_PAY_AT_BRANCH, 2, 0, Types.StringEnum)
        sResult &= FixLen(TEMP_PAY_AT_PC, 1, 0, Types.StringEnum)
        sResult &= FixLen(TEMP_PAY_AT_EX_RATE, 15, 4, Types.DecimalEnum)
        sResult &= FixLen(PAYER_TAX_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(FILLER1, 1, 0, Types.StringEnum)
        sResult &= FixLen(ORG_TRANS_AR_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(ENTRY_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(ENTRY_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(PAYAT_ORG_TRANS_AR_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(FILLER, 36, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal SEAL_CODE As String _
          , ByVal WHL_SEAL_CODE As String _
          , ByVal CTNR_NO As String _
          , ByVal CTNR_OWNER As String _
          , ByVal CTNR_TYPE As String _
          , ByVal CTNR_FE_MARK As String _
          , ByVal CTNR_SIZE As String _
          , ByVal CTNR_HEIGHT As String _
          , ByVal SPCL_CARGO_LENGTH As String _
          , ByVal SPCL_CARGO_WIDTH_TTL As String _
          , ByVal SPCL_CARGO_HEIGHT As String _
          , ByVal CTNR_UNIT As String _
          , ByVal IS_IN_CTNR As String _
          , ByVal LPK_CLASS_CODE As String _
          , ByVal BELONG_TO_BOOK_NO As String _
          , ByVal EDI_SRVC_TYPE As String _
          , ByVal ISO_CTNR_TYPE As String _
          , ByVal TARE_WEIGHT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(SEAL_CODE, 12, 0, Types.StringEnum)
        sResult &= FixLen(WHL_SEAL_CODE, 12, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_NO, 12, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_OWNER, 1, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_TYPE, 2, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_FE_MARK, 2, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_SIZE, 2, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_HEIGHT, 2, 0, Types.StringEnum)
        sResult &= FixLen(SPCL_CARGO_LENGTH, 3, 2, Types.DecimalEnum)
        sResult &= FixLen(SPCL_CARGO_WIDTH_TTL, 3, 2, Types.DecimalEnum)
        sResult &= FixLen(SPCL_CARGO_HEIGHT, 3, 2, Types.DecimalEnum)
        sResult &= FixLen(CTNR_UNIT, 3, 0, Types.StringEnum)
        sResult &= FixLen(IS_IN_CTNR, 1, 0, Types.StringEnum)
        sResult &= FixLen(LPK_CLASS_CODE, 1, 0, Types.StringEnum)
        sResult &= FixLen(BELONG_TO_BOOK_NO, 18, 0, Types.StringEnum)
        sResult &= FixLen(EDI_SRVC_TYPE, 1, 0, Types.StringEnum)
        sResult &= FixLen(ISO_CTNR_TYPE, 4, 0, Types.StringEnum)
        sResult &= FixLen(TARE_WEIGHT, 10, 4, Types.DecimalEnum)
        sResult &= FixLen(FILLER, 20, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTB( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal ITEM_CODE As String _
          , ByVal DG_UN_CODE As String _
          , ByVal IMDG_CODE As String _
          , ByVal IMDG_CODE_PAGE As String _
          , ByVal POL_SRVC_TYPE As String _
          , ByVal POD_SRVC_TYPE As String _
          , ByVal POL_TERM As String _
          , ByVal POD_TERM As String _
          , ByVal POL_DEPOT_CODE As String _
          , ByVal POD_DEPOT_CODE As String _
          , ByVal VIA_DEPOT_CODE As String _
          , ByVal POL_AREA_CODE_HEADER As String _
          , ByVal POL_AREA_CODE_SEQ As String _
          , ByVal POD_AREA_CODE_HEADER As String _
          , ByVal POD_AREA_CODE_SEQ As String _
          , ByVal FILLER1 As String _
          , ByVal IS_CFS_THC As String _
          , ByVal REF_NO As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(ITEM_CODE, 16, 0, Types.StringEnum)
        sResult &= FixLen(DG_UN_CODE, 4, 0, Types.StringEnum)
        sResult &= FixLen(IMDG_CODE, 3, 0, Types.StringEnum)
        sResult &= FixLen(IMDG_CODE_PAGE, 6, 0, Types.StringEnum)
        sResult &= FixLen(POL_SRVC_TYPE, 10, 0, Types.StringEnum)
        sResult &= FixLen(POD_SRVC_TYPE, 10, 0, Types.StringEnum)
        sResult &= FixLen(POL_TERM, 8, 0, Types.StringEnum)
        sResult &= FixLen(POD_TERM, 8, 0, Types.StringEnum)
        sResult &= FixLen(POL_DEPOT_CODE, 5, 0, Types.StringEnum)
        sResult &= FixLen(POD_DEPOT_CODE, 5, 0, Types.StringEnum)
        sResult &= FixLen(VIA_DEPOT_CODE, 5, 0, Types.StringEnum)
        sResult &= FixLen(POL_AREA_CODE_HEADER, 3, 0, Types.StringEnum)
        sResult &= FixLen(POL_AREA_CODE_SEQ, 3, 0, Types.StringEnum)
        sResult &= FixLen(POD_AREA_CODE_HEADER, 3, 0, Types.StringEnum)
        sResult &= FixLen(POD_AREA_CODE_SEQ, 3, 0, Types.StringEnum)
        sResult &= FixLen(FILLER1, 16, 0, Types.StringEnum)
        sResult &= FixLen(IS_CFS_THC, 1, 0, Types.StringEnum)
        sResult &= FixLen(REF_NO, 10, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 2, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTC( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal PKG As String _
          , ByVal PKG_UNIT As String _
          , ByVal CGO_MEASURE As String _
          , ByVal MEASURE_UNIT As String _
          , ByVal CGO_GROSS_WEIGHT As String _
          , ByVal CGO_NET_WEIGHT As String _
          , ByVal WEIGHT As String _
          , ByVal WEIGHT_UNIT As String _
          , ByVal RF_TEMP As String _
          , ByVal RF_CF_TYPE As String _
          , ByVal RF_RANGE As String _
          , ByVal FLASHPOINT_TEMP As String _
          , ByVal FLASHPOINT_CF_TYPE As String _
          , ByVal EDI_POL_PART_SRVC As String _
          , ByVal EDI_POD_PART_SRVC As String _
          , ByVal LOWEST_TEMP As String _
          , ByVal LOWEST_CF_TYPE As String _
          , ByVal RF_TRANS_TEMP As String _
          , ByVal POD_CUST_STORING_PLACE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(PKG, 8, 0, Types.IntegrtEnum)
        sResult &= FixLen(PKG_UNIT, 3, 0, Types.StringEnum)
        sResult &= FixLen(CGO_MEASURE, 5, 4, Types.DecimalEnum)
        sResult &= FixLen(MEASURE_UNIT, 3, 0, Types.StringEnum)
        sResult &= FixLen(CGO_GROSS_WEIGHT, 5, 4, Types.DecimalEnum)
        sResult &= FixLen(CGO_NET_WEIGHT, 5, 4, Types.DecimalEnum)
        sResult &= FixLen(WEIGHT, 5, 4, Types.DecimalEnum)
        sResult &= FixLen(WEIGHT_UNIT, 3, 0, Types.StringEnum)
        sResult &= FixLen(RF_TEMP, 4, 0, Types.StringEnum)
        sResult &= FixLen(RF_CF_TYPE, 3, 0, Types.StringEnum)
        sResult &= FixLen(RF_RANGE, 20, 0, Types.StringEnum)
        sResult &= FixLen(FLASHPOINT_TEMP, 4, 0, Types.StringEnum)
        sResult &= FixLen(FLASHPOINT_CF_TYPE, 3, 0, Types.StringEnum)
        sResult &= FixLen(EDI_POL_PART_SRVC, 1, 0, Types.StringEnum)
        sResult &= FixLen(EDI_POD_PART_SRVC, 1, 0, Types.StringEnum)
        sResult &= FixLen(LOWEST_TEMP, 4, 0, Types.StringEnum)
        sResult &= FixLen(LOWEST_CF_TYPE, 3, 0, Types.StringEnum)
        sResult &= FixLen(RF_TRANS_TEMP, 4, 0, Types.StringEnum)
        sResult &= FixLen(POD_CUST_STORING_PLACE, 8, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 9, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTD( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal DAMAGE_REMARK As String _
          , ByVal SHUTOUT_MARK As String _
          , ByVal SHUTOUT_REMARK As String _
          , ByVal SHUTOUT_DATE As String _
          , ByVal IS_SHORING As String _
          , ByVal IS_CONSOLE As String _
          , ByVal IS_TOPPING As String _
          , ByVal IS_DOOR_OPEN As String _
          , ByVal REVENUE_TON As String _
          , ByVal SPCL_CTNR_WIDTH_L As String _
          , ByVal SPCL_CTNR_WIDTH_R As String _
          , ByVal DOOR_OPEN_LR As String _
          , ByVal VENTILATION_TYPE As String _
          , ByVal VENTILATION As String _
          , ByVal POD_RETURN_DEPOT As String _
          , ByVal UNIT_RATE_PCT As String _
          , ByVal IS_BUNDLE As String _
          , ByVal CTNR_SUBSTITUTE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(DAMAGE_REMARK, 30, 0, Types.StringEnum)
        sResult &= FixLen(SHUTOUT_MARK, 1, 0, Types.StringEnum)
        sResult &= FixLen(SHUTOUT_REMARK, 30, 0, Types.StringEnum)
        sResult &= FixLen(SHUTOUT_DATE, 8, 0, Types.DateEnum)
        sResult &= FixLen(IS_SHORING, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_CONSOLE, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_TOPPING, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_DOOR_OPEN, 1, 0, Types.StringEnum)
        sResult &= FixLen(REVENUE_TON, 6, 2, Types.DecimalEnum)
        sResult &= FixLen(SPCL_CTNR_WIDTH_L, 6, 2, Types.DecimalEnum)
        sResult &= FixLen(SPCL_CTNR_WIDTH_R, 6, 2, Types.DecimalEnum)
        sResult &= FixLen(DOOR_OPEN_LR, 1, 0, Types.StringEnum)
        sResult &= FixLen(VENTILATION_TYPE, 4, 0, Types.StringEnum)
        sResult &= FixLen(VENTILATION, 6, 2, Types.DecimalEnum)
        sResult &= FixLen(POD_RETURN_DEPOT, 5, 0, Types.StringEnum)
        sResult &= FixLen(UNIT_RATE_PCT, 6, 2, Types.DecimalEnum)
        sResult &= FixLen(IS_BUNDLE, 1, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_SUBSTITUTE, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 6, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTE( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_INLAND_TYPE As String _
          , ByVal POL_INLAND_REMARK As String _
          , ByVal POL_INLAND_FM As String _
          , ByVal POL_INLAND_TO As String _
          , ByVal POD_INLAND_TYPE As String _
          , ByVal POD_INLAND_REMARK As String _
          , ByVal POD_INLAND_FM As String _
          , ByVal POD_INLAND_TO As String _
          , ByVal POL_INLAND_VIA_PORT As String _
          , ByVal POD_INLAND_VIA_PORT As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_INLAND_TYPE, 2, 0, Types.StringEnum)
        sResult &= FixLen(POL_INLAND_REMARK, 30, 0, Types.StringEnum)
        sResult &= FixLen(POL_INLAND_FM, 5, 0, Types.StringEnum)
        sResult &= FixLen(POL_INLAND_TO, 5, 0, Types.StringEnum)
        sResult &= FixLen(POD_INLAND_TYPE, 2, 0, Types.StringEnum)
        sResult &= FixLen(POD_INLAND_REMARK, 30, 0, Types.StringEnum)
        sResult &= FixLen(POD_INLAND_FM, 5, 0, Types.StringEnum)
        sResult &= FixLen(POD_INLAND_TO, 5, 0, Types.StringEnum)
        sResult &= FixLen(POL_INLAND_VIA_PORT, 5, 0, Types.StringEnum)
        sResult &= FixLen(POD_INLAND_VIA_PORT, 5, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 27, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTF( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POL_INLAND_CORP As String _
          , ByVal POD_INLAND_CORP As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POL_INLAND_CORP, 36, 0, Types.StringEnum)
        sResult &= FixLen(POD_INLAND_CORP, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 49, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTG( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal OTHERS_REMARK As String _
          , ByVal OTHERS_CODE As String _
          , ByVal IS_PRT_POL_PART As String _
          , ByVal COM_BL_FM_PLACE_KIND As String _
          , ByVal IS_PRT_RO As String _
          , ByVal SEAL_CODE As String _
          , ByVal WHL_SEAL_CODE As String _
          , ByVal PLAN_LOAD_CONDITION As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(OTHERS_REMARK, 30, 0, Types.StringEnum)
        sResult &= FixLen(OTHERS_CODE, 2, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_POL_PART, 1, 0, Types.StringEnum)
        sResult &= FixLen(COM_BL_FM_PLACE_KIND, 1, 0, Types.StringEnum)
        sResult &= FixLen(IS_PRT_RO, 1, 0, Types.StringEnum)
        sResult &= FixLen(SEAL_CODE, 20, 0, Types.StringEnum)
        sResult &= FixLen(WHL_SEAL_CODE, 20, 0, Types.StringEnum)
        sResult &= FixLen(PLAN_LOAD_CONDITION, 39, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 7, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTH( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CODE_TYPE As String _
          , ByVal CTNR_SEQ As String _
          , ByVal UN_CODE As String _
          , ByVal IMDG_CODE As String _
          , ByVal IMDG_CODE_PAGE As String _
          , ByVal LPK_CLASS_CODE As String _
          , ByVal PKG As String _
          , ByVal PKG_UNIT As String _
          , ByVal CGO_GROSS_WEIGHT As String _
          , ByVal ITEM_CODE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CODE_TYPE, 4, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_SEQ, 18, 0, Types.StringEnum)
        sResult &= FixLen(UN_CODE, 4, 0, Types.StringEnum)
        sResult &= FixLen(IMDG_CODE, 3, 0, Types.StringEnum)
        sResult &= FixLen(IMDG_CODE_PAGE, 6, 0, Types.StringEnum)
        sResult &= FixLen(LPK_CLASS_CODE, 1, 0, Types.StringEnum)
        sResult &= FixLen(PKG, 8, 0, Types.StringEnum)
        sResult &= FixLen(PKG_UNIT, 3, 0, Types.StringEnum)
        sResult &= FixLen(CGO_GROSS_WEIGHT, 10, 4, Types.DecimalEnum)
        sResult &= FixLen(ITEM_CODE, 20, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 44, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTI( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CODE_TYPE As String _
          , ByVal CTNR_SEQ As String _
          , ByVal MANUFACTURER As String _
          , ByVal COUNTRY_OF_ORIGIN As String _
          , ByVal HTSUS_CODE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CODE_TYPE, 4, 0, Types.StringEnum)
        sResult &= FixLen(CTNR_SEQ, 18, 0, Types.StringEnum)
        sResult &= FixLen(MANUFACTURER, 35, 0, Types.StringEnum)
        sResult &= FixLen(COUNTRY_OF_ORIGIN, 2, 0, Types.StringEnum)
        sResult &= FixLen(HTSUS_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 89, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTJ( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal MANUFACTURER_ADDR As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(MANUFACTURER_ADDR, 36, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 85, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTK( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal POD_DEPOT_REMARK As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(POD_DEPOT_REMARK, 100, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 21, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTRE( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CHG_CODE As String _
          , ByVal UNIT_RATE As String _
          , ByVal MEA_RATE As String _
          , ByVal WGT_RATE As String _
          , ByVal FM_PLACE As String _
          , ByVal TO_PLACE As String _
          , ByVal MIN_RATE As String _
          , ByVal CURR As String _
          , ByVal FILLER1 As String _
          , ByVal PAID_TERM As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CHG_CODE, 4, 0, Types.StringEnum)
        sResult &= FixLen(UNIT_RATE, 13, 4, Types.DecimalEnum)
        sResult &= FixLen(MEA_RATE, 13, 4, Types.DecimalEnum)
        sResult &= FixLen(WGT_RATE, 13, 4, Types.DecimalEnum)
        sResult &= FixLen(FM_PLACE, 8, 0, Types.StringEnum)
        sResult &= FixLen(TO_PLACE, 8, 0, Types.StringEnum)
        sResult &= FixLen(MIN_RATE, 13, 4, Types.DecimalEnum)
        sResult &= FixLen(CURR, 3, 0, Types.StringEnum)
        sResult &= FixLen(FILLER1, 20, 0, Types.StringEnum)
        sResult &= FixLen(PAID_TERM, 1, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 5, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenCTRA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal CHG_CODE As String _
          , ByVal FM_PLACE As String _
          , ByVal TO_PLACE As String _
          , ByVal CURR As String _
          , ByVal APP_ID As String _
          , ByVal APP_OFFICE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(CHG_CODE, 4, 0, Types.StringEnum)
        sResult &= FixLen(FM_PLACE, 8, 0, Types.StringEnum)
        sResult &= FixLen(TO_PLACE, 8, 0, Types.StringEnum)
        sResult &= FixLen(CURR, 3, 0, Types.StringEnum)
        sResult &= FixLen(APP_ID, 18, 0, Types.StringEnum)
        sResult &= FixLen(APP_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 73, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenEOF( _
            ByVal ROW_ID As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 3, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 125, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenTFA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal LINER_CODE As String _
          , ByVal TFC_CODE As String _
          , ByVal MFT_TYPE As String _
          , ByVal OFFICE_CODE As String _
          , ByVal PLR As String _
          , ByVal POD As String _
          , ByVal PLD As String _
          , ByVal FINISH_USER As String _
          , ByVal FINISH_OFFICE As String _
          , ByVal FINISH_DATE As String _
          , ByVal FINISH_PROGRAM As String _
          , ByVal ENTRY_FINISH_DATE As String _
          , ByVal TW_ENTRY_FINISH_DATE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(LINER_CODE, 7, 0, Types.StringEnum)
        sResult &= FixLen(TFC_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(MFT_TYPE, 3, 0, Types.StringEnum)
        sResult &= FixLen(OFFICE_CODE, 7, 0, Types.StringEnum)
        sResult &= FixLen(PLR, 5, 0, Types.StringEnum)
        sResult &= FixLen(POD, 5, 0, Types.StringEnum)
        sResult &= FixLen(PLD, 5, 0, Types.StringEnum)
        sResult &= FixLen(FINISH_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(FINISH_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(FINISH_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(FINISH_PROGRAM, 8, 0, Types.StringEnum)
        sResult &= FixLen(ENTRY_FINISH_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(TW_ENTRY_FINISH_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(FILLER, 9, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenTFB( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal LINER_CODE As String _
          , ByVal TFC_CODE As String _
          , ByVal MFT_TYPE As String _
          , ByVal OFFICE_CODE As String _
          , ByVal PLR As String _
          , ByVal POD As String _
          , ByVal PLD As String _
          , ByVal ENTRY_SERVER As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(LINER_CODE, 7, 0, Types.StringEnum)
        sResult &= FixLen(TFC_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(MFT_TYPE, 3, 0, Types.StringEnum)
        sResult &= FixLen(OFFICE_CODE, 7, 0, Types.StringEnum)
        sResult &= FixLen(PLR, 5, 0, Types.StringEnum)
        sResult &= FixLen(POD, 5, 0, Types.StringEnum)
        sResult &= FixLen(PLD, 5, 0, Types.StringEnum)
        sResult &= FixLen(ENTRY_SERVER, 30, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 49, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenEXA( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal LINER_CODE As String _
          , ByVal TFC_CODE As String _
          , ByVal PORT As String _
          , ByVal MFT_TYPE As String _
          , ByVal EX_RATE As String _
          , ByVal EX_DATE As String _
          , ByVal OB_DATE As String _
          , ByVal ISSUE_DATE As String _
          , ByVal CLOSED_DATE As String _
          , ByVal ENTRY_USER As String _
          , ByVal ENTRY_OFFICE As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(LINER_CODE, 7, 0, Types.StringEnum)
        sResult &= FixLen(TFC_CODE, 10, 0, Types.StringEnum)
        sResult &= FixLen(PORT, 5, 0, Types.StringEnum)
        sResult &= FixLen(MFT_TYPE, 1, 0, Types.StringEnum)
        sResult &= FixLen(EX_RATE, 18, 4, Types.DecimalEnum)
        sResult &= FixLen(EX_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(OB_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(ISSUE_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(CLOSED_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(ENTRY_USER, 10, 0, Types.StringEnum)
        sResult &= FixLen(ENTRY_OFFICE, 7, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 3, 0, Types.StringEnum)
        Return sResult
    End Function
    Public Function GenEXB( _
            ByVal ROW_ID As String _
          , ByVal ROW_NO As String _
          , ByVal ENTRY_DATE As String _
          , ByVal ENTRY_PROGRAM As String _
          , ByVal TW_ENTRY_DATE As String _
          , ByVal ENTRY_SERVER As String _
          , ByVal FILLER As String _
    ) As String
        Dim sResult As String = ""
        sResult &= FixLen(ROW_ID, 4, 0, Types.StringEnum)
        sResult &= FixLen(ROW_NO, 3, 0, Types.IntegrtEnum)
        sResult &= FixLen(ENTRY_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(ENTRY_PROGRAM, 8, 0, Types.StringEnum)
        sResult &= FixLen(TW_ENTRY_DATE, 15, 0, Types.DateEnum)
        sResult &= FixLen(ENTRY_SERVER, 80, 0, Types.StringEnum)
        sResult &= FixLen(FILLER, 3, 0, Types.StringEnum)
        Return sResult
    End Function


    Public Sub New(ByVal FleName As String)
        SR = New StreamWriter(FleName)
    End Sub
End Class
