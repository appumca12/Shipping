Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.Layout
Imports Shipping.WHLEDI
Imports System.IO

Public Class FrmWHLMapping



    Private TB As New DataTable
    Private Counter As Long = 0
    Private ListOfBls As List(Of WHLEDI)
    Private TFCCode As String

    Private Sub MenuItem_CustomOpenFileClick() Handles MenuItem.CustomOpenFileClick

        Dim Dialog As New OpenFileDialog
        Me.FleName.TextValue = ""
        Dialog.Filter = "EDI Files (*.edi)|*.edi|txt files (*.txt)|*.txt|All files (*.*)|*.*"
        If Dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.FleName.TextValue = Dialog.FileName
        End If

    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        If Me.FleName.TextValue = "" Then
            Exit Sub
        End If

        If Not IO.File.Exists(Me.FleName.TextValue) Then
            MsgBoxGeneral("File Dose Not Existed !")
            Exit Sub
        End If
        ReadingFile()

    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        If MsgBox("Do You Want Import Selected Data ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim Drs() As DataRow
            Dim Key As SegmentKEYType
            Dim Cl As New WHLEDI
            Dim nI As Long
            Dim sGoods As String
            Dim dt As DataTable
            Dim FoundChemical As New ArrayList()
            Dim tch As String

            GridResult.UpdateData()

            nI = 0
            sGoods = ""
            dt = GetChemicalTable()
            For Each Cl In ListOfBls
                sGoods = ""
                For Each DEC In Cl.ListOfDEC
                    sGoods &= DEC.DESCN + vbCrLf
                Next
                Key = Cl.ListOfKEY(0)
                'appu - chemical check

                For Each cDR In dt.Rows
                    If sGoods.Contains(cDR.Item("ChemicalName").ToString()) Then
                        FoundChemical.Add(Key.BOOK_NO.ToString() + "-" + cDR.Item("ChemicalName").ToString())
                    End If
                Next
            Next

            If Not FoundChemical.Count = 0 Then

                For Each ch As String In FoundChemical
                    tch += vbCrLf + ch + vbCrLf
                Next

                If MsgBox("Forbidden GOODS Found !" + tch + vbCrLf + vbCrLf + " Do you want to Continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    For Each Cl In ListOfBls

                        nI += 1
                        Key = Cl.ListOfKEY(0)
                        Drs = Me.DataSetForm.Tables(0).Select("BLNO = '" & Key.BOOK_NO & "' and Select = true")
                        If Drs.Length > 0 Then
                            Try
                                GenerateData(Cl, Drs(0).Item("ClientID"), Drs(0).Item("Status"))
                            Catch ex As Exception
                                MsgBox("B/L NO " & Key.BOOK_NO & " skiped !", MsgBoxStyle.Critical)
                                MsgBox(ex.ToString)
                            End Try
                        End If
                        Me.Refresh()

                    Next
                    Try
                        CorrectLCL()
                    Catch ex As Exception

                    End Try

                    MsgBoxSaveSuccessful()
                    ReadingFile()

                End If
            Else
                For Each Cl In ListOfBls

                    nI += 1
                    Key = Cl.ListOfKEY(0)
                    Drs = Me.DataSetForm.Tables(0).Select("BLNO = '" & Key.BOOK_NO & "' and Select = true")
                    If Drs.Length > 0 Then
                        Try
                            GenerateData(Cl, Drs(0).Item("ClientID"), Drs(0).Item("Status"))
                         Catch ex As Exception
                            MsgBox("B/L NO " & Key.BOOK_NO & " skiped !", MsgBoxStyle.Critical)
                            MsgBox(ex.ToString)
                        End Try
                    End If
                    Me.Refresh()

                Next
                Try
                    CorrectLCL()
                Catch ex As Exception

                End Try

                MsgBoxSaveSuccessful()
                ReadingFile()
            End If



        End If


    End Sub
    Function GetChemicalTable() As DataTable

        Dim ChemicalTable As DataTable = New DataTable
        ChemicalTable.Columns.Add("Id", GetType(Integer))
        ChemicalTable.Columns.Add("ChemicalName", GetType(String))

        ChemicalTable.Rows.Add(1, "acetic anhydride")
        ChemicalTable.Rows.Add(2, "N-acetylanthranilic acid")
        ChemicalTable.Rows.Add(3, "ephedrine")
        ChemicalTable.Rows.Add(4, "ergometrine")
        ChemicalTable.Rows.Add(5, "ergotamine")
        ChemicalTable.Rows.Add(6, "isosafrole")
        ChemicalTable.Rows.Add(7, "lysergic acid")
        ChemicalTable.Rows.Add(8, " 3,4-methylenedioxyphenyl-2-propanone")
        ChemicalTable.Rows.Add(9, "norephedrine")
        ChemicalTable.Rows.Add(10, "phenylacetic acid")
        ChemicalTable.Rows.Add(11, "1-phenyl-2-propanone")
        ChemicalTable.Rows.Add(12, "piperonal")
        ChemicalTable.Rows.Add(13, "potassium permanganate")
        ChemicalTable.Rows.Add(14, "pseudoephedrine")
        ChemicalTable.Rows.Add(15, "safrole")
        ChemicalTable.Rows.Add(16, "acetone")
        ChemicalTable.Rows.Add(17, "anthranilic acid")
        ChemicalTable.Rows.Add(18, "diethyl ether")
        ChemicalTable.Rows.Add(19, "hydrochloric acid")
        ChemicalTable.Rows.Add(20, "hydrogen chloride")
        ChemicalTable.Rows.Add(21, "methyl ethyl ketone")
        ChemicalTable.Rows.Add(22, "piperidine")
        ChemicalTable.Rows.Add(23, "sulphuric acid")
        ChemicalTable.Rows.Add(24, "toluene")

        Return ChemicalTable
    End Function
    Private Sub ReadingFile()

        Dim DLG As New OpenFileDialog
        Dim Cl As New WHLEDI
        Dim Goods As String = ""
        Dim nCount As Long = 0
        Dim Key As SegmentKEYType
        Dim DR As DataRow
        Dim BL As TB_InwardBLS
        Dim DM As New DataManager(My.Settings.DSN)
        Dim SCnee As String = ""
        Dim SGoods As String = ""
        Dim nI As Long
        Dim ListCns As New ArrayList
        Dim TTL20 As Long
        Dim TTl40 As Long
        Dim Mrk As SegmentMRKType
        Dim Notif As SegmentNTFType
        Dim sMark As String
        Dim sNotify As String

        Dim objReader As New StreamReader(FleName.TextValue)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        ListOfBls = New List(Of WHLEDI)
        Me.DataSetForm.Tables(0).Clear()
        Me.DataSetForm.Tables(1).Clear()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing

        objReader.Close()

        For Each sLine In arrText
            If Mid(sLine, 1, 3) = "KEY" Then
                If Cl.ListOfKEY.Count > 0 Then
                    ListOfBls.Add(Cl)
                End If
                Cl = New WHLEDI
            End If
            Cl.ExtractDataLine(sLine)
            If Mid(sLine, 1, 3) = "MFT" And Len(sLine) > 10 Then
                TFCCode = Trim(Mid(sLine, 53, 10))
            End If
        Next

        If Me.Voyage.GetDocument.TFCCode <> TFCCode Then
            MsgBox("TFCCode Not Match !", MsgBoxStyle.Critical)
        End If

        If Cl.ListOfKEY.Count > 0 Then
            ListOfBls.Add(Cl)
        End If

        DataSetForm.Tables(0).Clear()
        DataSetForm.Tables(0).AcceptChanges()
        Dim dt As DataTable
        dt = GetChemicalTable()
        Dim FoundChemical As New ArrayList()
        For Each Cl In ListOfBls

            nI += 1
            Key = Cl.ListOfKEY.Item(0)
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Key.BOOK_NO, MatchType.Exact)
            BL = DM.GetTB_InwardBLS
            DR = DataSetForm.Tables(0).NewRow

            DR("BLNO") = Key.BOOK_NO
            DR("ShowBL") = Format(nI, "000") & " - " & Key.BOOK_NO

            If BL Is Nothing Then
                DR("Select") = True
                DR("Exists") = False
            Else
                DR("Select") = False
                DR("Exists") = True
            End If

            SCnee = ""
            SGoods = ""
            sMark = ""
            sNotify = ""

            For Each CEE In Cl.ListOfCEE
                SCnee &= Trim(CEE.CONSIGNEE) & vbCrLf
            Next

            For Each Notif In Cl.ListOfNTF
                sNotify &= Trim(Notif.NOTIFY) & vbCrLf
            Next

            For Each CEA In Cl.ListOfCEA
                SCnee &= Trim(CEA.CONSIGNEE_ADDR) & vbCrLf
            Next

            For Each CEF In Cl.ListOfCEF
                If CEF.CONSIGNEE_FAX <> "" Then
                    SCnee &= "FAX:" & Trim(CEF.CONSIGNEE_FAX) & vbCrLf
                End If
            Next

            For Each DEC In Cl.ListOfDEC
                SGoods &= DEC.DESCN + vbCrLf
            Next

            'appu - chemical check

            For Each cDR In dt.Rows
                If SGoods.Contains(cDR.Item("ChemicalName").ToString()) Then
                    FoundChemical.Add(Key.BOOK_NO.ToString() + "-" + cDR.Item("ChemicalName").ToString())
                End If
            Next

            For Each Mrk In Cl.ListOfMRK
                sMark &= Mrk.MARK & vbCrLf
            Next

            DR("Cnee") = SCnee
            DR("Goods") = SGoods
            DR("Status") = 1
            DR("ClientID") = "306d5270-ecb0-4bfc-90df-ab0eb5dda478"
            DR("Client") = "Not Defined"
            DR("Marks") = sMark
            DR("Notify") = sNotify

            DataSetForm.Tables(0).Rows.Add(DR)

            Dim CTA As SegmentCTAType
            For Each CTA In Cl.ListOfCTA
                If ListCns.IndexOf(Trim(CTA.CTNR_NO)) = -1 Then
                    ListCns.Add(Trim(CTA.CTNR_NO))
                    If CTA.CTNR_SIZE = "20" Then
                        TTL20 += 1
                    Else
                        TTl40 += 1
                    End If
                End If
            Next
        Next

        Me.LabelBls.Text = "Total B/L(s) :" & nI.ToString
        Me.Label20.Text = "TTL20':" & TTL20.ToString
        Me.Labe40.Text = " TTL40':" & TTl40.ToString

        InitGrid()
        MakeFilter()
        If Not FoundChemical.Count = 0 Then
            Dim tch As String
            For Each ch As String In FoundChemical
                tch += vbCrLf + ch + vbCrLf
            Next
            MessageBox.Show("Forbidden GOODS Found !" + tch, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub GenerateData(ByVal CL As WHLEDI, ByVal ClientId As Guid, ByVal BlStatus As String)

        Dim DM As New DataManager(My.Settings.DSN)

        Dim Key As SegmentKEYType
        Dim BLE As SegmentBLEType
        'Dim BLJ As SegmentBLJType
        'Dim BLI As SegmentBLIType
        Dim MRK As SegmentMRKType
        Dim DEC As SegmentDECType

        Dim SPR As SegmentSPRType
        Dim SPA As SegmentSPAType
        Dim SPF As SegmentSPFType

        Dim NTF As SegmentNTFType
        Dim NFA As SegmentNFAType
        Dim NFF As SegmentNFFType

        Dim CEE As SegmentCEEType
        Dim CEA As SegmentCEAType
        Dim CEF As SegmentCEFType

        Dim DBA As SegmentDBAType

        Dim CTA As SegmentCTAType
        Dim CTB As SegmentCTBType
        Dim CTC As SegmentCTCType
        Dim CTH As SegmentCTHType
        Dim CTI As SegmentCTIType
        Dim CTRE As SegmentCTREType

        Dim MGA As SegmentMGAType

        Dim CGAE As SegmentCGAEType
        Dim Mgk As SegmentMGKType
        'Dim CGC As SegmentCGCType

        Dim BL As TB_InwardBLS
        Dim Cntr As TB_InwardCntrs
        Dim IMCO As TB_InwardCnsImco
        Dim RF As TB_InwardCnsTemprature
        Dim Names As TB_InwardBlsNames
        Dim Charges As TB_InwardCharges
        Dim CnsChg As TB_InwardCntrsCharges
        Dim CnsPkg As TB_InwardCnsPkgs

        Dim SGoods As String = ""
        Dim sShipper As String = ""
        Dim SCnee As String = ""
        Dim sNotify As String = ""
        Dim sFWD As String = ""
        Dim sMark As String = ""
        Dim Hscode As String = ""
        Dim BLID As Guid = Guid.NewGuid
        Dim CntrID As Guid
        Dim shipperID As Guid = Guid.NewGuid
        Dim ChargesID As Guid = Guid.NewGuid
        Dim HSCodeTemp As String = ""
        Dim Iso As TB_ISOTypeCollection
        Dim nI As Byte
        Dim Drs() As DataRow

        Dim TTLGW As Double
        Dim TTLNet As Double
        Dim TTLCBM As Double
        Dim TTLPkgs As Long
        Dim TTLTw As Long
        Dim aHS As New ArrayList


        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_ISOType.Columns.WHLSize, "", MatchType.IsNotNull)
        Iso = DM.GetTB_ISOTypeCollection

        Counter += 1

        If CL.ListOfKEY.Count > 0 Then
            Key = CL.ListOfKEY.Item(0)
        End If
        If CL.ListOfBLE.Count > 0 Then
            BLE = CL.ListOfBLE.Item(0)
        End If
        If CL.ListOfMRK.Count > 0 Then
            MRK = CL.ListOfMRK.Item(0)
        End If
        If CL.ListOfMGA.Count > 0 Then
            MGA = CL.ListOfMGA(0)
        End If
        If CL.ListOfCGAE.Count > 0 Then
            CGAE = CL.ListOfCGAE(0)
        End If

        'Map B/L'

        BL = DM.NewTB_InwardBLS("IGI", CurrentShippingLine, "", "", "", "")
        BL.ID = BLID
        BL.BlNo = Trim(Key.BOOK_NO)
        BL.POL = Trim(Key.POL)
        BL.POD = Trim(Key.POD)
        BL.POT = Trim(Key.POL)

        If Trim(MGA.FINAL_PORT) = "" Then
            BL.FPOD = Key.POD
        Else
            BL.FPOD = MGA.FINAL_PORT
        End If

        BL.POR = Trim(Key.PLR)
        BL.BLStatus = BlStatus
        BL.MailRelease = False
        BL.TermsOfPayment = "C"
        BL.FCLType = "FF"
        BL.ClientID = ClientId
        BL.VoyageID = Me.Voyage.VoyageID
        BL.IssueFU = True
        BL.TFCCode = TFCCode

        If CL.ListOfMGA.Count > 0 Then
            MGA = CL.ListOfMGA(0)
            If MGA.BL_TYPE = "R" Then
                BL.MailRelease = True
            End If
            If MGA.OFT_PAYMENT_TYPE = "P" Then
                BL.TermsOfPayment = "P"
            End If
            BL.NoOfBls = Val(MGA.NO_OF_ORGN)
        Else
            BL.NoOfBls = 3
        End If

        BL.IssueDate = STODATE(BLE.ISSUE_BL_DATE)

        If CL.ListOfBLJ.Count > 0 Then
            BL.IssuePlace = Mid(CL.ListOfBLJ(0).BL_ISSUE_PLACE, 1, 5)
        Else
            BL.IssuePlace = Key.POL
        End If
        BL.OnBoardDate = STODATE(Key.OB_DATE)

        If CL.ListOfMGK.Count > 0 Then
            Mgk = CL.ListOfMGK(0)
            If Mgk.TLXRL_CODE <> "" Then
                BL.MailRelease = True
                BL.MailReleaseRem = Mgk.TLXRL_CODE
            End If
        End If

        For Each SPR In CL.ListOfSPR
            sShipper &= Trim(SPR.SHPR) & vbCrLf
        Next

        For Each SPA In CL.ListOfSPA
            sShipper &= Trim(SPA.SHPR_ADDR) & vbCrLf
        Next

        For Each SPF In CL.ListOfSPF
            If SPF.SHPR_FAX <> "" Then
                sShipper &= "FAX:" & Trim(SPF.SHPR_FAX) & vbCrLf
            End If
            If SPF.SHPR_MAIL_ACCT <> "" Then
                sShipper &= "EMAIL:" & Trim(SPF.SHPR_MAIL_ACCT) & vbCrLf
            End If
        Next

        For Each NTF In CL.ListOfNTF
            sNotify &= Trim(NTF.NOTIFY) & vbCrLf
        Next

        For Each MRK In CL.ListOfMRK
            sMark &= Trim(MRK.MARK) & vbCrLf
        Next


        For Each NFA In CL.ListOfNFA
            sNotify &= NFA.NOTIFY_ADDR
        Next

        For Each NFF In CL.ListOfNFF
            If NFF.NOTIFY_FAX <> "" Then
                sNotify &= "FAX:" & NFF.NOTIFY_FAX
            End If
            If NFF.NTFY_MAIL_ACCT <> "" Then
                sNotify &= "EMAIL:" & NFF.NTFY_MAIL_ACCT
            End If
        Next

        For Each CEE In CL.ListOfCEE
            SCnee &= Trim(CEE.CONSIGNEE) & vbCrLf
        Next

        For Each CEA In CL.ListOfCEA
            SCnee &= Trim(CEA.CONSIGNEE_ADDR) & vbCrLf
        Next

        For Each CEF In CL.ListOfCEF
            If CEF.CONSIGNEE_FAX <> "" Then
                SCnee &= "FAX:" & Trim(CEF.CONSIGNEE_FAX) & vbCrLf
            End If
        Next

        For Each DBA In CL.ListOfDBA
            sFWD &= Trim(DBA.Desc) & vbCrLf
        Next

        Names = DM.NewTB_InwardBlsNames(BL)
        Names.Cnee = SCnee
        Names.Shipper = sShipper
        Names.Notify1 = sNotify
        Names.Forwarder = sFWD

        For Each DEC In CL.ListOfDEC
            SGoods &= DEC.DESCN + vbCrLf
        Next


        BL.NewTB_InwardBlsGoods()
        BL.TB_InwardBlsGoodss(0).Goods = SGoods
        BL.TB_InwardBlsGoodss(0).Marks = sMark
        BL.TB_InwardBlsGoodss(0).BLID = BLID
        BL.TB_InwardBlsGoodss(0).MainCom = "-"

        BL.TB_InwardBlsGoodss(0).ID = Guid.NewGuid

        BL.ID = BLID


        For Each CTA In CL.ListOfCTA

            Drs = DM.DataSet.Tables("TB_ISOType").Select("WHLHeight = '" & CTA.CTNR_HEIGHT & "' and WHLSize = '" & CTA.CTNR_SIZE & "' and WHLType = '" & CTA.CTNR_TYPE & "'")

            CntrID = Guid.NewGuid
            Cntr = BL.NewTB_InwardCntrs
            Cntr.ID = CntrID
            Cntr.BLID = BLID
            Cntr.CntrNo = Trim(CTA.CTNR_NO)

            If Drs.Length > 0 Then
                Cntr.CnSize = Trim(CTA.CTNR_SIZE)
                Cntr.CnType = Trim(Drs(0).Item("OurType"))
            Else
                Cntr.CnSize = Trim(CTA.CTNR_SIZE)
                Cntr.CnType = Trim(CTA.CTNR_TYPE)
            End If

            Cntr.TW = Val(Trim(CTA.TARE_WEIGHT))

            If Trim(CTA.WHL_SEAL_CODE) = "" Then
                Cntr.SealNo = Trim(CTA.SEAL_CODE)
            Else
                Cntr.SealNo = Trim(CTA.WHL_SEAL_CODE)
            End If

            Cntr.FLE = Trim(CTA.CTNR_FE_MARK)
            Cntr.SOC = IIf(CTA.CTNR_OWNER = "S", "Y", "N")
            CTC = CL.ListOfCTC(Val(CTA.ROW_NO) - 1)
            Cntr.GW = Val(Trim(CTC.CGO_GROSS_WEIGHT))
            Cntr.NET = Val(NullToValue(Trim(CTC.CGO_NET_WEIGHT), 0))
            Cntr.CBM = Val(Trim(CTC.CGO_MEASURE))
            Cntr.PackageType = CTC.PKG_UNIT
            Cntr.NoOFPkgs = CTC.PKG

            TTLTw += Val(Trim(CTA.TARE_WEIGHT))
            TTLGW += Val(Trim(CTC.CGO_GROSS_WEIGHT))
            TTLNet += Val(NullToValue(Trim(CTC.CGO_NET_WEIGHT), 0))
            TTLCBM += Val(Trim(CTC.CGO_MEASURE))
            TTLPkgs += CTC.PKG

            If CL.ListOfCTB.Count > 0 Then
                CTB = CL.ListOfCTB.Item(Val(CTA.ROW_NO) - 1)
                If aHS.IndexOf(CTB.ITEM_CODE) = -1 Then
                    aHS.Add(CTB.ITEM_CODE)
                End If
                If Trim(CTB.IMDG_CODE) <> "" Then
                    IMCO = Cntr.NewTB_InwardCnsImco
                    IMCO.ID = Guid.NewGuid
                    IMCO.CntrID = CntrID
                    IMCO.PageNumber = Val(Trim(CTB.IMDG_CODE_PAGE))
                    IMCO.UNNO = Trim(CTB.DG_UN_CODE)
                    IMCO.IMDGCode = Trim(CTB.IMDG_CODE)
                    IMCO.FlashPoint = Val(Trim(CTC.FLASHPOINT_TEMP))
                    IMCO.PakingGroup = ""
                    IMCO.EMSNumber = Val(Trim(""))
                End If
                Cntr.POLTerm = CTB.POL_TERM
                Cntr.PODTerm = CTB.POD_TERM
            Else
                Cntr.POLTerm = ""
                Cntr.PODTerm = ""
            End If


            'appu - pakg type
            If CTA.DGPackages.Count = 0 And CTA.CTIPackages.Count = 0 Then
                If CL.ListOfCTC.Count > 0 Then

                    CTC = CL.ListOfCTC.Item(Val(CTA.ROW_NO) - 1)

                    If aHS.IndexOf(CTB.ITEM_CODE) = -1 Then
                        aHS.Add(CTB.ITEM_CODE)
                    End If
                    'If Trim(CTB.IMDG_CODE) <> "" Then
                    CnsPkg = Cntr.NewTB_InwardCnsPkgs
                    CnsPkg.ID = Guid.NewGuid
                    CnsPkg.CntrID = CntrID
                    CnsPkg.PackageType = Trim(CTC.PKG_UNIT)

                    'If Not Trim(CTB.ITEM_CODE) Is Nothing Then
                    '    HSCodeTemp = Trim(CTB.ITEM_CODE)
                    '    CnsPkg.IMDGCode = Trim(CTB.ITEM_CODE)
                    'Else
                    '    CnsPkg.IMDGCode = HSCodeTemp
                    'End If
                    CnsPkg.IMDGCode = Trim(CTB.ITEM_CODE)
                    CnsPkg.NoOFPkgs = Val(Trim(CTC.PKG))
                    CnsPkg.GW = Val(Trim(CTC.CGO_GROSS_WEIGHT))
                    CnsPkg.NET = Val(Trim(CTC.CGO_NET_WEIGHT))
                    CnsPkg.CBM = Val(Trim(CTC.MEASURE_UNIT))
                    CnsPkg.FlashPoint = Val(Trim(CTC.FLASHPOINT_TEMP))
                    CnsPkg.PakingGroup = 0
                    Dim TB As New DataTable
                    Dim sSql As String
                    Dim lResult As Boolean
                    sSql = "select top 1 Meaning from TB_CODE where Groupcode = 'PG' and STDCode = '" & Trim(CTC.PKG_UNIT) & "'"
                    TableBySql(sSql, TB, lResult)
                    If TB.Rows.Count > 0 Then
                        CnsPkg.EMSNumber = TB.Rows(0).Item(0).ToString
                    Else
                        CnsPkg.EMSNumber = "PK"
                    End If

                    'End If
                Else

                End If
            End If

            'If CL.ListOfCTH.Count > 0 Then

            '    CTH = CL.ListOfCTH.Item(Val(CTA.ROW_NO) - 1)

            '    If aHS.IndexOf(CTB.ITEM_CODE) = -1 Then
            '        aHS.Add(CTB.ITEM_CODE)
            '    End If
            '    CnsPkg = Cntr.NewTB_InwardCnsPkgs
            '    CnsPkg.ID = Guid.NewGuid
            '    CnsPkg.CntrID = CntrID
            '    CnsPkg.PackageType = Trim(CTH.PKG_UNIT)

            '    If Not Trim(CTB.ITEM_CODE) Is Nothing Then
            '        HSCodeTemp = Trim(CTB.ITEM_CODE)
            '        CnsPkg.IMDGCode = Trim(CTB.ITEM_CODE)
            '    Else
            '        CnsPkg.IMDGCode = HSCodeTemp
            '    End If

            '    CnsPkg.NoOFPkgs = Val(Trim(CTH.PKG))
            '    CnsPkg.GW = Val(Trim(CTH.CGO_GROSS_WEIGHT))
            '    CnsPkg.PakingGroup = 0
            '    CnsPkg.EMSNumber = Trim(CTH.PKG_UNIT)

            'End If

            'For Each CTH In CL.ListOfCTH
            '    CTH = CL.ListOfCTH.Item(Val(CTA.ROW_NO) - 1)
            '    CnsPkg = Cntr.NewTB_InwardCnsPkgs
            '    CnsPkg.ID = Guid.NewGuid
            '    CnsPkg.CntrID = CntrID
            '    CnsPkg.PackageType = Trim(CTH.PKG_UNIT)

            '    If Not Trim(CTB.ITEM_CODE) Is Nothing Then
            '        HSCodeTemp = Trim(CTB.ITEM_CODE)
            '        CnsPkg.IMDGCode = Trim(CTB.ITEM_CODE)
            '    Else
            '        CnsPkg.IMDGCode = HSCodeTemp
            '    End If
            '    CnsPkg.NoOFPkgs = Val(Trim(CTH.PKG))
            '    CnsPkg.GW = Val(Trim(CTH.CGO_GROSS_WEIGHT))
            '    CnsPkg.PakingGroup = 0
            '    CnsPkg.EMSNumber = Trim(CTH.PKG_UNIT)
            'Next

            If Not CTA.DGPackages Is Nothing Then
                For Each CTHP In CTA.DGPackages
                    CnsPkg = Cntr.NewTB_InwardCnsPkgs
                    CnsPkg.ID = Guid.NewGuid
                    CnsPkg.CntrID = CntrID
                    CnsPkg.PackageType = Trim(CTHP.PKG_UNIT)

                    'If Not Trim(CTB.ITEM_CODE) Is Nothing Then
                    '    HSCodeTemp = Trim(CTB.ITEM_CODE)
                    '    CnsPkg.IMDGCode = Trim(CTB.ITEM_CODE)
                    'Else
                    '    CnsPkg.IMDGCode = HSCodeTemp
                    'End If
                    CnsPkg.IMDGCode = Trim(CTB.ITEM_CODE)
                    CnsPkg.NoOFPkgs = Val(Trim(CTHP.PKG))
                    CnsPkg.GW = Val(Trim(CTHP.CGO_GROSS_WEIGHT))
                    CnsPkg.PakingGroup = 0


                    Dim TB As New DataTable
                    Dim sSql As String
                    Dim lResult As Boolean
                    sSql = "select top 1 Meaning from TB_CODE where Groupcode = 'PG' and STDCode = '" & Trim(CTHP.PKG_UNIT) & "'"
                    TableBySql(sSql, TB, lResult)
                    If TB.Rows.Count > 0 Then
                        CnsPkg.EMSNumber = TB.Rows(0).Item(0).ToString
                    Else
                        CnsPkg.EMSNumber = "PK"
                    End If
                Next
            End If

            If Not CTA.CTIPackages Is Nothing Then
                For Each CTI In CTA.CTIPackages
                    CnsPkg = Cntr.NewTB_InwardCnsPkgs
                    CnsPkg.ID = Guid.NewGuid
                    CnsPkg.CntrID = CntrID
                    CnsPkg.IMDGCode = Trim(CTI.MANUFACTURER)

                    CTC = CL.ListOfCTC.Item(Val(CTA.ROW_NO) - 1)

                    If Trim(Mid(CTI.FILLER, 5, 3)) = "" Or Trim(Mid(CTI.FILLER, 5, 3)) Is Nothing Then
                        CnsPkg.PackageType = Trim(CTC.PKG_UNIT)
                    Else
                        CnsPkg.PackageType = Mid(CTI.FILLER, 5, 3)
                    End If

                    If Trim(Mid(CTI.FILLER, 1, 4)) = "" Or Trim(Mid(CTI.FILLER, 1, 4)) Is Nothing Then
                        CnsPkg.NoOFPkgs = Val(Trim(CTC.PKG))
                    Else
                        CnsPkg.NoOFPkgs = Mid(CTI.FILLER, 1, 4)
                    End If


                    If Trim(Mid(CTI.FILLER, 8, 10)) = "" Or Trim(Mid(CTI.FILLER, 8, 10)) Is Nothing Then
                        CnsPkg.GW = Val(Trim(CTC.CGO_GROSS_WEIGHT))
                    Else
                        CnsPkg.GW = Val(Mid(CTI.FILLER, 8, 10))
                    End If


                    CnsPkg.PakingGroup = 0

                    Dim TB As New DataTable
                    Dim sSql As String
                    Dim lResult As Boolean
                    If Trim(Mid(CTI.FILLER, 5, 3)) = "" Or Trim(Mid(CTI.FILLER, 5, 3)) Is Nothing Then
                        sSql = "select top 1 Meaning from TB_CODE where Groupcode = 'PG' and STDCode = '" & Trim(CTC.PKG_UNIT) & "'"
                    Else
                        sSql = "select top 1 Meaning from TB_CODE where Groupcode = 'PG' and STDCode = '" & Mid(CTI.FILLER, 5, 3) & "'"
                    End If
                    TableBySql(sSql, TB, lResult)
                    If TB.Rows.Count > 0 Then
                        CnsPkg.EMSNumber = TB.Rows(0).Item(0).ToString
                    Else
                        CnsPkg.EMSNumber = "PK"
                    End If
                Next
            End If

            ' appu end

            If Trim(CTC.RF_TEMP) <> "" Then
                RF = Cntr.NewTB_InwardCnsTemprature
                RF.ID = Guid.NewGuid
                RF.CntrID = CntrID
                RF.TemperatureBase = Val(Trim(CTC.RF_TEMP))
                RF.TempMin = Val(Trim(CTC.LOWEST_TEMP))
            End If

            If Not CTA.Charges Is Nothing Then
                For Each CTRE In CTA.Charges
                    If Val(CTRE.UNIT_RATE) + Val(Trim(CTRE.WGT_RATE)) + Val(Trim(CTRE.MEA_RATE)) > 0 Then
                        CnsChg = DM.NewTB_InwardCntrsCharges("", "", 0, "", Cntr)
                        CnsChg.ChargesCode = Trim(CTRE.CHG_CODE)
                        CnsChg.Currency = Trim(CTRE.CURR)
                        CnsChg.UnitRate = Trim(CTRE.UNIT_RATE)
                        CnsChg.WGTrate = Val(Trim(CTRE.WGT_RATE))
                        CnsChg.MEARate = Val(Trim(CTRE.MEA_RATE))
                        CnsChg.FromPlace = Mid(Trim(CTRE.FM_PLACE), 1, 5)
                        CnsChg.ToPlace = Mid(Trim(CTRE.TO_PLACE), 1, 5)
                        CnsChg.MinRate = Val(Trim(CTRE.MIN_RATE))
                        CnsChg.Terms = Trim(CTRE.PAID_TERM)
                    End If
                Next
            End If
        Next

        nI = 0

        For Each CGAE In CL.ListOfCGAE
            If Val(Trim(CGAE.AMOUNT)) > 0 Then
                nI += 1
                Charges = DM.NewTB_InwardCharges(0, "", "", 0, 0, 0, "", BL)
                Charges.Seq = nI
                Charges.ChargesCode = Trim(CGAE.CHARGE_CODE)
                Charges.Currency = Trim(CGAE.CURR)
                Charges.Amount = Val(Trim(CGAE.AMOUNT))
                Charges.Rate = Val(Trim(CGAE.AMOUNT))
                Charges.Qty = 1
                Charges.FromPlace = Trim(CGAE.FM_PLACE)
                Charges.ToPlace = Trim(CGAE.TO_PLACE)
                Charges.PayAt = Trim(CGAE.PAY_AT)
                Charges.PayAtBranch = Trim(CGAE.PAY_AT_BRANCH)
                Charges.PayAtExRate = Val(Trim(CGAE.PAY_AT_EX_RATE))
                Charges.PayAtPc = Trim(CGAE.PAY_AT_PC)
                Charges.Terms = Trim(CGAE.PAID_TERM)
                Charges.MeaUnitOfCharge = Trim(CGAE.MEA_UNIT_OF_CHARGE)
            End If
        Next

        For Each hs As String In aHS
            Hscode &= Trim(hs) & ","
        Next
        If Hscode.Length > 0 Then
            Hscode = Mid(Hscode, 1, Len(Hscode) - 1)
        End If


        BL.HSCode = Hscode
        BL.TB_InwardBlsGoodss(0).TTW = TTLTw
        BL.TB_InwardBlsGoodss(0).TGW = TTLGW
        BL.TB_InwardBlsGoodss(0).TTLPkgs = TTLPkgs
        BL.TB_InwardBlsGoodss(0).TTLCBM = TTLCBM
        BL.TB_InwardBlsGoodss(0).TTLNET = TTLNet

        DM.CommitAll()

    End Sub
    Private Sub InitGrid()

        With Me.DropDownStatus
            .DataSource = GetCodeList("ST")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col As UltraGridColumn In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With

        With Me.GridResult.DisplayLayout.Bands(0)
            .Columns("Cnee").CellMultiLine = Infragistics.Win.DefaultableBoolean.True
            .Columns("Goods").CellMultiLine = Infragistics.Win.DefaultableBoolean.True
            .Columns("Marks").CellMultiLine = Infragistics.Win.DefaultableBoolean.True
            .Columns("Client").Style = ColumnStyle.Button
            .Columns("ClientID").Hidden = True
            .Columns("Status").Style _
                                        = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("Status").ValueList = Me.DropDownStatus
        End With

        Checkdata()
        With Me.GridResult.DisplayLayout.Bands(0)
            .Override.CardCaptionAppearance.BackColor = Color.White
            .Override.CardCaptionAppearance.ForeColor = Color.Black
            .Override.ActiveRowAppearance.BackColor = Color.White
            .Override.ActiveRowAppearance.ForeColor = Color.Black

        End With

        Me.GridResult.DisplayLayout.Appearance.BackColor = Color.White
        Me.GridResult.DisplayLayout.Appearance.ForeColor = Color.Black


    End Sub
    Private Sub FrmTSMapping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Vessel.InitControl(Me.BackColor)
        Me.Voyage.InitControl(Me.BackColor, Me.Vessel)

    End Sub

    Private Sub GridResult_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles GridResult.ClickCellButton

        Dim Frm As New FrmClientDialog(GridResult.ActiveRow.Cells("ClientID"), GridResult.ActiveRow.Cells("Client"))
        Frm.ShowDialog()


    End Sub


    Private Sub GridResult_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridResult.InitializeLayout

        Dim info As RowLayoutColumnInfo

        For Each col As UltraGridColumn In GridResult.DisplayLayout.Bands(0).Columns
            info = col.RowLayoutColumnInfo
        Next

        With Me.GridResult.DisplayLayout.Bands(0)
            .CardView = True
            .RowLayoutStyle = RowLayoutStyle.ColumnLayout
            .CardSettings.Style = CardStyle.Compressed
        End With

        info = GridResult.DisplayLayout.Bands(0).Columns("BLNO").RowLayoutColumnInfo
        info.SpanX = 2
        info.SpanY = 2
        info.OriginX = 0
        info.OriginY = 0
        info.PreferredCellSize = New Size(106, 0)


        info = GridResult.DisplayLayout.Bands(0).Columns("Cnee").RowLayoutColumnInfo
        info.SpanX = 5
        info.SpanY = 6
        info.OriginX = 0
        info.OriginY = 2
        info.PreferredCellSize = New Size(384, 70)

        info = GridResult.DisplayLayout.Bands(0).Columns("Status").RowLayoutColumnInfo
        info.SpanX = 3
        info.SpanY = 2
        info.OriginX = 2
        info.OriginY = 0
        info.PreferredCellSize = New Size(214, 0)

        info = GridResult.DisplayLayout.Bands(0).Columns("Goods").RowLayoutColumnInfo
        info.SpanX = 5
        info.SpanY = 10
        info.OriginX = 0
        info.OriginY = 8
        info.PreferredCellSize = New Size(384, 119)

        info = GridResult.DisplayLayout.Bands(0).Columns("Client").RowLayoutColumnInfo
        info.SpanX = 3
        info.SpanY = 2
        info.OriginX = 0
        info.OriginY = 18
        info.PreferredCellSize = New Size(384, 0)


        info = GridResult.DisplayLayout.Bands(0).Columns("Marks").RowLayoutColumnInfo
        info.SpanX = 7
        info.SpanY = 12
        info.OriginX = 0
        info.OriginY = 22
        info.PreferredCellSize = New Size(384, 119)


        info = GridResult.DisplayLayout.Bands(0).Columns("ClientID").RowLayoutColumnInfo
        info.SpanX = 2
        info.SpanY = 2
        info.OriginX = 3
        info.OriginY = 18
        info.PreferredCellSize = New Size(168, 0)

        info = GridResult.DisplayLayout.Bands(0).Columns("Select").RowLayoutColumnInfo
        info.SpanX = 2
        info.SpanY = 2
        info.OriginX = 0
        info.OriginY = 20
        info.PreferredCellSize = New Size(106, 0)


        info = GridResult.DisplayLayout.Bands(0).Columns("Notify").RowLayoutColumnInfo
        info.SpanX = 8
        info.SpanY = 12
        info.OriginX = 2
        info.OriginY = 24
        info.PreferredCellSize = New Size(384, 119)


        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32

        e.Layout.Override.CardCaptionAppearance.BackColor = Color.Magenta
        e.Layout.Override.CardCaptionAppearance.ForeColor = Color.Yellow

        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        e.Layout.Override.RowSelectorWidth = 60


    End Sub

    Private Sub Checkdata()

    End Sub

    Private Sub Selection_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Selection.Enter

    End Sub

    Private Sub ButtonAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAll.CheckedChanged
        MakeFilter()
    End Sub

    Private Sub ButtonExists_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonExists.CheckedChanged
        MakeFilter()
    End Sub

    Private Sub ButtonNoExists_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNoExists.CheckedChanged
        MakeFilter()
    End Sub

    Private Sub MakeFilter()

        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If
        With Me.GridResult.DisplayLayout.Bands(0)
            .ColumnFilters.ClearAllFilters()
            If Me.ButtonExists.Checked = True Then
                .Layout.Bands(0).ColumnFilters("Exists").FilterConditions.Add(FilterComparisionOperator.Equals, True)
            End If
            If Me.ButtonNoExists.Checked = True Then
                .Layout.Bands(0).ColumnFilters("Exists").FilterConditions.Add(FilterComparisionOperator.Equals, False)
            End If
        End With

    End Sub
    Private Function STODATE(ByVal DateString As String) As Date

        Return CDate(Mid(DateString, 1, 4) & "/" & Mid(DateString, 5, 2) & "/" & Mid(DateString, 7, 2))

    End Function
    Private Sub CorrectLCL()

        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim LogDataSet As DataSet
        Dim Bls As TB_InwardBLSCollection
        Dim BL As TB_InwardBLS
        Dim DM = New DataManager(My.Settings.DSN)
        Dim Cns As TB_InwardCntrsCollection
        Dim Cn As TB_InwardCntrs

        sSql = "Select CntrNo , Count(*) From Tb_InwardBls Bls , TB_InwardCntrs Cns Where Bls.ID = Cns.BLID and VoyageID = '" & Me.Voyage.VoyageID.ToString & "' Group By CntrNo Having Count(*) > 1"

        TableBySql(sSql, TB, lResult)

        DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.VoyageID, Me.Voyage.VoyageID, MatchType.Exact)
        Bls = DM.GetTB_InwardBLSCollection

        If TB.Rows.Count = 0 Then
            For Each BL In Bls
                If BL.FCLType <> "FF" Then
                    BL.FCLType = "FF"
                End If
            Next
        Else
            For Each BL In Bls
                DM.QueryCriteria.Clear()
                For Each dr In TB.Rows
                    DM.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, BL.ID, MatchType.Exact)
                    DM.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.CntrNo, dr("CntrNO"), MatchType.Exact)
                    Cns = DM.GetTB_InwardCntrsCollection
                    If Not Cns Is Nothing Then
                        Cns(0).FLE = "L"
                        BL.FCLType = "LL"
                    End If
                Next
            Next
        End If

        LogDataSet = DM.DataSet.Copy
        DM.CommitAll()
        GenerateLog(LogDataSet)

    End Sub

End Class