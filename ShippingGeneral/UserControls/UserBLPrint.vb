Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Imports System.Data.SqlClient
Imports Aspose
Imports Aspose.Words
Imports Aspose.Words.Fields
Imports Aspose.Words.Reporting
Imports Infragistics.Win.Misc
Imports Aspose.BarCode
Public Class UserBLPrint
    Enum InwardOutward
        Inward
        Outward
    End Enum
    Private IOStatus As InwardOutward
    Private Dm As DataManager
    Private TBMaster As DataTable
    Private sBLNO As String
    Private ResultTable As DataTable
    Private DataSetForm As DataSet
    Private POL As String
    Private BodyLines As Integer
    Private Direction As InwardOutward
    Private BarCodeAddress As String


    Public Sub Init(ByVal Direction As InwardOutward, ByVal BLNo As String)

        Dim TB As New DataTable
        Dim lResult As Boolean
        Me.Direction = Direction
        DataSetForm = New DataSet

        With TB.Columns
            .Add(New DataColumn("Seq", System.Type.GetType("System.Int32")))
            .Add(New DataColumn("Cns"))
            .Add(New DataColumn("Pkgs"))
            .Add(New DataColumn("NPkgs", System.Type.GetType("System.Int64")))
            .Add(New DataColumn("Goods"))
            .Add(New DataColumn("NW", System.Type.GetType("System.Double")))
            .Add(New DataColumn("GW", System.Type.GetType("System.Double")))
            .Add(New DataColumn("TW", System.Type.GetType("System.Double")))
            .Add(New DataColumn("BLNO"))
            .Add(New DataColumn("Vessel"))
            .Add(New DataColumn("Voyage"))
            .Add(New DataColumn("POD"))
            .Add(New DataColumn("Flag"))
            .Add(New DataColumn("FPOD"))
            .Add(New DataColumn("Column1"))
            .Add(New DataColumn("SealNo"))

        End With
        TB.TableName = "TBDetails"

        DataSetForm.Tables.Add(TB)

        TB = New DataTable
        IOStatus = Direction

        TableBySql("Select ID , ObjectName from TB_ObjectsUser Where ObjectLine = '" & CurrentShippingLine & "' and ObjectGroup = 'BL'", TB, lResult)

        With Me.ComboList.ComboGnrl
            .DataSource = TB
            .SelectedItem = "ID"
            .DisplayMember = "ObjectName"
        End With

        Dim Group As String

        Group = IIf(IOStatus = InwardOutward.Inward, "BI", "BO")
        Dm = New DataManager(My.Settings.DSN)

        Dm.QueryCriteria.And(JoinPath.TB_Cluses.Columns.CluseGroup, Group, MatchType.Exact)
        Dm.GetTB_ClusesCollection()

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, "", MatchType.Greater)
        Dm.GetTB_Lines()

        sBLNO = BLNo

        If IOStatus = InwardOutward.Inward Then
            Me.ButtonTemplate.Enabled = False
        End If

    End Sub
    Private Sub GenerateBL(ByVal CheckAttach As Boolean, ByRef TBResult As DataTable)

        Dim BL As TB_InwardBLS
        Dim Goods As TB_InwardBlsGoods
        Dim Cntrs As TB_InwardCntrsCollection
        Dim CntrsList As New ArrayList
        Dim CntrsCount As String
        Dim GoodsList As New ArrayList
        Dim Ds As New DataSet

        Dim Memo As CLMemo
        Dim MaxLen As Int16 = 0
        Dim IsShowGoods As Boolean = True
        Dim IsShowCntrs As Boolean = True
        Dim Rpt As New BL
        Dim TB As DataTable
        Dim Dv As DataView
        Dim nBeginGoods As Int16 = 0
        Dim nBeginCntrs As Int16 = 0
        Dim Dr As DataRow
        Dim TempTB As New DataTable
        Dim TmpDS As New DataSet
        Dim SummaryTB As DataTable
        Dim TempStr As String
        Dim Drs() As DataRow
        Dim Col As DataColumn
        Dim lResult As Boolean
        Dim XmlTB As DataTable


        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, sBLNO, MatchType.Exact)
        BL = Dm.GetTB_InwardBLS

        If BL Is Nothing Then
            MsgBoxGeneral("Invalid B/L No !", "Validate Failed")
            Exit Sub
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardBlsGoods.Columns.BLID, BL.ID, MatchType.Exact)
        Goods = Dm.GetTB_InwardBlsGoods
        If Goods Is Nothing Then
            MsgBoxGeneral("No Goods Detail data !", "Validate Failed")
            Exit Sub
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, BL.ID, MatchType.Exact)
        Cntrs = Dm.GetTB_InwardCntrsCollection
        If Goods Is Nothing Then
            MsgBoxGeneral("No Containers data !", "Validate Failed")
            Exit Sub
        End If

        TmpDS = StoredProcedures.SP_InwardSummary(BL.ID.ToString)
        SummaryTB = TmpDS.Tables(0)

        Ds = StoredProcedures.SP_GetTotalInwardCntrsByBLID(BL.ID.ToString)
        CntrsCount = NullToValue(Ds.Tables(0).Rows(0).Item(0).ToString, "")

        Memo = New CLMemo
        Ds = StoredProcedures.SP_GetInwardCntrsListForPrintBL(BL.ID.ToString)
        Memo.GetFree(CntrsCount & Replace(Ds.Tables(0).Rows(0).Item(0).ToString, "##", vbCrLf), CntrsList, 20)

        Memo = New CLMemo
        Memo.GetFree(Goods.Goods, GoodsList, 30) 'Changed from 45 to 30 for correction case

        TempStr = NullToValue(SummaryTB.Rows(0).Item("Imco"), "")
        TempStr += SummaryTB.Rows(0).Item("Cntrs")

        Ds = StoredProcedures.SP_PrintInwardBls(CurrentShippingLine, sBLNO, "Y", "Y")

        GenerateCols(Dm.DataSet.Tables("TB_InwardCntrs"), TempStr, Goods.Goods, Ds.Tables(0), NullToValue(Goods.Marks, ""))


        Ds.Tables(0).Columns.Add("SealNo")
        PrepareBoday(Ds.Tables(0))

        Col = New DataColumn("TPkgs", System.Type.GetType("System.String"))
        Col.DefaultValue = SummaryTB.Rows(0).Item("Pkgs")
        Ds.Tables(0).Columns.Add(Col)
        Dr = Ds.Tables(0).Rows(0)

        If CheckAttach = True Then
            Drs = DataSetForm.Tables("TBdetails").Select("Flag <> 'Y'")
            TBResult = DataSetForm.Tables("TBdetails")
        Else
            Ds.Tables(0).Rows(0).Item("Cntrs") = Replace(Ds.Tables(0).Rows(0).Item("cntrs").ToString, "##", vbCrLf)
            Ds.Tables(0).Rows(0).Item("TNet") = Format(NullToValue(Ds.Tables(0).Rows(0).Item("TNet"), 0), "standard")
            Ds.Tables(0).Rows(0).Item("TTW") = Format(NullToValue(Ds.Tables(0).Rows(0).Item("TTW"), 0), "standard")
            Ds.Tables(0).Rows(0).Item("TCBM") = Format(NullToValue(Ds.Tables(0).Rows(0).Item("TCBM"), 0), "standard")
            '    Ds.Tables(0).Rows(0).Item("Cluses") = GetDetentionClause(BL.POD)
            Ds.Tables(0).Columns.Add(New DataColumn("Image", System.Type.GetType("System.Byte[]")))
            TBResult = Ds.Tables(0)
        End If

    End Sub
    Private Sub GenerateCols(ByVal Cns As DataTable, ByVal CnsStr As String, ByVal Goods As String, ByVal TB As DataTable, ByVal Marks As String)

        Dim Mem As New CLMemo
        Dim Col As New ArrayList
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim nI As Long
        Dim nJ As Long
        Dim lNew As Boolean
        Dim fclline As Boolean

        Mem = New CLMemo
        Mem.GetFree(Replace(CnsStr, "  ", " ") & " ", Col, 20)
        DataSetForm.Tables("TBDetails").Clear()

        For nI = 0 To Col.Count - 1
            Dr = DataSetForm.Tables("TBDetails").NewRow
            nJ += 1
            Dr("Seq") = nJ
            Dr("Cns") = Col(nI)
            Dr("BLNO") = TB.Rows(0).Item("BlNo")
            Dr("Vessel") = TB.Rows(0).Item("Vessel")
            Dr("Voyage") = TB.Rows(0).Item("Voyage")
            Dr("POD") = TB.Rows(0).Item("Pod")
            Dr("Flag") = IIf(BodyLines >= nJ, "N", "Y")
            Dr("FPOD") = TB.Rows(0).Item("FPOD")
            Dr("NW") = 0
            Dr("GW") = 0
            Dr("TW") = 0
            Dr("Npkgs") = 0
            DataSetForm.Tables("TBDetails").Rows.Add(Dr)
        Next

        Col = New ArrayList
        Mem = New CLMemo
        Mem.GetFree(Goods, Col, 30) 'Changed from 45 to 30 for correction case

        nJ = 0
        For nI = 0 To Col.Count - 1
            If Len(Col(nI)) > 1 Then
                nJ += 1
                Drs = DataSetForm.Tables("TBDetails").Select("Seq = " & nJ)

                If Drs.Length = 0 Then
                    Dr = DataSetForm.Tables("TBDetails").NewRow
                    Dr("Seq") = nJ
                    Dr("Goods") = Col(nI)
                    Dr("BLNO") = TB.Rows(0).Item("BlNo")
                    Dr("Vessel") = TB.Rows(0).Item("Vessel")
                    Dr("Voyage") = TB.Rows(0).Item("Voyage")
                    Dr("Pkgs") = ""
                    Dr("POD") = TB.Rows(0).Item("Pod")
                    Dr("Flag") = IIf(nJ >= BodyLines, "N", "Y")
                    Dr("FPOD") = TB.Rows(0).Item("FPOD")
                    Dr("NW") = 0
                    Dr("GW") = 0
                    Dr("TW") = 0
                    Dr("Npkgs") = 0
                    DataSetForm.Tables("TBDetails").Rows.Add(Dr)
                Else
                    Drs(0).Item("Goods") = Col(nI)
                End If
            End If
        Next
        nJ = 0

        'appu - fcl/fcl line

        If Not IOStatus = InwardOutward.Inward Then
            fclline = False
            For Each TempDr As DataRow In Cns.Rows
                nJ += 1
                Drs = DataSetForm.Tables("TBDetails").Select("Seq = " & nJ)
                If Drs.Length = 0 Then
                    Dr = DataSetForm.Tables("TBDetails").NewRow
                    lNew = True
                Else
                    Dr = Drs(0)
                    lNew = False
                End If
                Dr("Seq") = nJ
                If fclline = False Then
                    fclline = True
                    Dr("Cns") = "Pol/Pod Srvc=FCL/FCL" + vbCrLf + TempDr("CntrNo") & "/" & TempDr("CnSize") & "'" & TempDr("CnType")
                    Dr("Pkgs") = vbCrLf + TempDr("NoOfPkgs").ToString & " " & GetMeaningCode("PG", NullToValue(TempDr("PackageType"), ""))
                    ' Dr("Goods") = ' Mid(NullToValue(TempDr("Goods"), ""), 1, 30)
                    Dr("NW") = vbCrLf + Format(NullToValue(TempDr("NET"), 0), "standard")
                    Dr("GW") = vbCrLf + Format(TempDr("GW"), "standard")
                    Dr("TW") = vbCrLf + Format(TempDr("TW"), "standard")
                    Dr("BLNO") = vbCrLf + TB.Rows(0).Item("BlNo")
                    Dr("Vessel") = vbCrLf + TB.Rows(0).Item("Vessel")
                    Dr("Voyage") = vbCrLf + TB.Rows(0).Item("Voyage")
                    Dr("POD") = vbCrLf + TB.Rows(0).Item("Pod")
                    Dr("Npkgs") = TempDr("NoOfPkgs")
                    Dr("Flag") = IIf(nJ >= BodyLines, "N", "Y")
                    Dr("FPOD") = vbCrLf + TB.Rows(0).Item("FPOD")
                    Dr("SealNo") = vbCrLf + TempDr("SealNo")
                Else

                    Dr("Cns") = TempDr("CntrNo") & "/" & TempDr("CnSize") & "'" & TempDr("CnType")
                    Dr("Pkgs") = TempDr("NoOfPkgs").ToString & " " & GetMeaningCode("PG", NullToValue(TempDr("PackageType"), ""))
                    ' Dr("Goods") = ' Mid(NullToValue(TempDr("Goods"), ""), 1, 30)
                    Dr("NW") = Format(NullToValue(TempDr("NET"), 0), "standard")
                    Dr("GW") = Format(TempDr("GW"), "standard")
                    Dr("TW") = Format(TempDr("TW"), "standard")
                    Dr("BLNO") = TB.Rows(0).Item("BlNo")
                    Dr("Vessel") = TB.Rows(0).Item("Vessel")
                    Dr("Voyage") = TB.Rows(0).Item("Voyage")
                    Dr("POD") = TB.Rows(0).Item("Pod")
                    Dr("Npkgs") = TempDr("NoOfPkgs")
                    Dr("Flag") = IIf(nJ >= BodyLines, "N", "Y")
                    Dr("FPOD") = TB.Rows(0).Item("FPOD")
                    Dr("SealNo") = TempDr("SealNo")
                End If
                If lNew = True Then
                    DataSetForm.Tables("TBDetails").Rows.Add(Dr)
                End If
            Next
        Else

            For Each TempDr As DataRow In Cns.Rows
                nJ += 1
                Drs = DataSetForm.Tables("TBDetails").Select("Seq = " & nJ)
                If Drs.Length = 0 Then
                    Dr = DataSetForm.Tables("TBDetails").NewRow
                    lNew = True
                Else
                    Dr = Drs(0)
                    lNew = False
                End If
                Dr("Seq") = nJ
                Dr("Cns") = TempDr("CntrNo") & "/" & TempDr("CnSize") & "'" & TempDr("CnType")
                Dr("Pkgs") = TempDr("NoOfPkgs").ToString & " " & GetMeaningCode("PG", NullToValue(TempDr("PackageType"), ""))
                ' Dr("Goods") = ' Mid(NullToValue(TempDr("Goods"), ""), 1, 30)
                Dr("NW") = Format(NullToValue(TempDr("NET"), 0), "standard")
                Dr("GW") = Format(TempDr("GW"), "standard")
                Dr("TW") = Format(TempDr("TW"), "standard")
                Dr("BLNO") = TB.Rows(0).Item("BlNo")
                Dr("Vessel") = TB.Rows(0).Item("Vessel")
                Dr("Voyage") = TB.Rows(0).Item("Voyage")
                Dr("POD") = TB.Rows(0).Item("Pod")
                Dr("Npkgs") = TempDr("NoOfPkgs")
                Dr("Flag") = IIf(nJ >= BodyLines, "N", "Y")
                Dr("FPOD") = TB.Rows(0).Item("FPOD")
                Dr("SealNo") = TempDr("SealNo")

                If lNew = True Then
                    DataSetForm.Tables("TBDetails").Rows.Add(Dr)
                End If
            Next
        End If
        'appu fcl print end

        Col = New ArrayList
        Mem = New CLMemo
        Mem.GetFree(Marks & " ", Col, 20)

        nJ = DataSetForm.Tables("TBDetails").Rows.Count
        For nI = 0 To Col.Count - 1
            Dr = DataSetForm.Tables("TBDetails").NewRow
            lNew = True
            nJ += 1
            Dr("Seq") = nJ
            Dr("Cns") = Col(nI)
            Dr("Pkgs") = ""
            Dr("BLNO") = TB.Rows(0).Item("BlNo")
            Dr("Vessel") = TB.Rows(0).Item("Vessel")
            Dr("Voyage") = TB.Rows(0).Item("Voyage")
            Dr("POD") = TB.Rows(0).Item("Pod")
            Dr("Flag") = IIf(nJ >= BodyLines, "N", "Y")
            Dr("FPOD") = TB.Rows(0).Item("FPOD")
            Dr("NW") = 0
            Dr("GW") = 0
            Dr("TW") = 0
            Dr("Npkgs") = 0
            DataSetForm.Tables("TBDetails").Rows.Add(Dr)
        Next

    End Sub
    Private Sub PrepareBoday(ByVal TB As DataTable)

        Dim sCns As String = ""
        Dim sPkgs As String = ""
        Dim sGoods As String = ""
        Dim sNW As String = ""
        Dim sGW As String = ""
        Dim sTW As String = ""
        Dim sSealNo As String = ""

        'BodyLines += 1
        Dim Drs() As DataRow = DataSetForm.Tables("TBDetails").Select("Seq <= " & BodyLines.ToString, "Seq")

        For Each dr As DataRow In Drs
            If Int16.Parse(dr("Seq").ToString) >= BodyLines Then
                sGoods += vbLf & "B/L Continue In Attachment List"
                Exit For
            End If
            sCns += Replace(Trim(NullToValue(dr("Cns"), "")), vbLf, "") & vbLf
            sGoods += Replace(Trim(NullToValue(dr("Goods"), "")), vbLf, "") & vbLf
            sPkgs += Replace(Trim(NullToValue(dr("Pkgs"), "")), vbLf, "") & vbLf
            sNW += Format(IIf(NullToValue(dr("NW"), 0) = 0, "", NullToValue(dr("NW"), 0)), "Standard") & vbLf
            If NullToValue(dr("GW"), 0) > 0 Then
                sGW &= Format(IIf(NullToValue(dr("GW"), 0) = 0, "", NullToValue(dr("GW"), 0)), "Standard") & " KGS" & vbLf
            Else
                sGW &= vbLf
            End If
            sTW += Format(IIf(NullToValue(dr("TW"), 0) = 0, "", NullToValue(dr("TW"), 0)), "Standard") & vbLf
            sSealNo &= NullToValue(dr("SealNo"), "") & vbLf
            dr("Flag") = "Y"
        Next

        sGoods = Replace(sGoods, (vbLf + vbLf), vbLf)
        sGoods = Replace(sGoods, (vbLf + vbLf), vbLf)
        TB.Rows(0).Item("Cntrs") = sCns
        TB.Rows(0).Item("Goods") = sGoods
        TB.Rows(0).Item("Pkgs") = sPkgs
        TB.Rows(0).Item("NET") = sNW
        TB.Rows(0).Item("GW") = sGW
        TB.Rows(0).Item("TW") = sTW
        TB.Rows(0).Item("SealNo") = sSealNo

    End Sub


    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click

        Dim Tb As New DataTable
        Dim FleName As String
        Dim sSql As String = "Select ObjectContentXML from TB_ObjectsUser where ObjectLine = '" & CurrentShippingLine & "' and ObjectGroup = 'BL' and Objectname = '" & Me.ComboList.ComboGnrl.Text & "'"

        Try
            If RestorXml(sSql, FleName) = True Then
                Tb.ReadXml(FleName)
                Try
                    BodyLines = Integer.Parse(Tb.Rows(0).Item("value").ToString)
                    BodyLines = BodyLines - 1
                Catch ex As Exception
                    BodyLines = 15
                End Try
            Else
                BodyLines = 15
            End If
        Catch ex As Exception
            BodyLines = 15
        End Try

        Tb = New DataTable
        If IOStatus = InwardOutward.Inward Then
            GenerateBL(False, Tb)
        Else
            PrePaerPreExpBL(False, Tb, False)
        End If

        OpenBLDoc(Tb)

    End Sub

    Private Sub OpenBLDoc(ByVal TbData As DataTable)

        Dim Doc As Document
        Dim FleName As String
        Dim Tb As DataTable
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim barrImg As Byte()
        Dim strfn As String
        Dim fs As FileStream
        Dim SaveDialog As New SaveFileDialog

        FleName = GenerateRandomFileName("Docx")
        Cmd = New SqlCommand("select ObjectContent from TB_ObjectsUser where ObjectLine = '" & CurrentShippingLine & "' and ObjectGroup = 'BL' and Objectname = '" & Me.ComboList.ComboGnrl.Text & "'", Cnn)
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If

        barrImg = Cmd.ExecuteScalar

        If Not barrImg Is Nothing Then
            strfn = FleName
            If IO.File.Exists(FleName) Then
                IO.File.Delete(FleName)
            End If
            fs = New FileStream(strfn, FileMode.CreateNew, FileAccess.Write)
            fs.Write(barrImg, 0, barrImg.Length)
            fs.Flush()
            fs.Close()
        End If



        Doc = New Document(FleName)
        Doc.MailMerge.Execute(TbData)

 
        FleName = GenerateRandomFileName("Docx")

        Dim DB As New DocumentBuilder(Doc)

        DB.MoveToBookmark("BarCode")
        If DB.MoveToBookmark("BarCode") = True Then
            DB.InsertImage(BarCodeAddress, 150, 40)
        End If


        Doc.Save(FleName)
       
        Doc = Nothing

        Process.Start(FleName)


    End Sub

    Private Sub ButtonAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachment.Click

        Dim Tb As New DataTable
        Dim Drs() As DataRow
        Dim Frm As New FrmGeneralReportShow
        Dim TGW As Double
        Dim TNET As Double
        Dim TTW As Double
        Dim TCBM As Double
        Dim TTLPkgs As Long

        Dim FleName As String
        Dim sSql As String = "Select ObjectContentXML from TB_ObjectsUser where ObjectLine = '" & CurrentShippingLine & "' and ObjectGroup = 'BL' and Objectname = '" & Me.ComboList.ComboGnrl.Text & "'"
        If RestorXml(sSql, FleName) = True Then
            Tb.ReadXml(FleName)
            Try
                'BodyLines = Integer.Parse(Tb.Rows(0).Item("value").ToString)
                BodyLines = 15
            Catch ex As Exception
                BodyLines = 15
            End Try
        Else
            BodyLines = 15
        End If

        Dim RAttachment As RptBlAttachment
        If IOStatus = InwardOutward.Inward Then
            GenerateBL(True, Tb)
            Drs = Tb.Select("Flag <> 'Y'")
            If Drs.Length = 0 Then
                MsgBoxGeneral("No Data For Print Attachment !")
                Exit Sub
            End If
            RAttachment = New RptBlAttachment
            RAttachment.SetDataSource(DataSetForm.Tables("TBdetails"))
            'RAttachment.SetParameterValue("TTLGW", Tb.Rows(0).Item("TGW"))
            'RAttachment.SetParameterValue("TTLNET", Tb.Rows(0).Item("TNet"))
            'RAttachment.SetParameterValue("TTLCBM", Tb.Rows(0).Item("TCBM"))

            'RAttachment.SetParameterValue("TTLGW", 0)
            'RAttachment.SetParameterValue("TTLNET", 0)
            'RAttachment.SetParameterValue("TTLPkgs", 0)
            'RAttachment.SetParameterValue("POL", "")

            Frm.ReportViewer.ReportSource = RAttachment
            Frm.Show()
        Else
            PrePaerPreExpBL(True, Tb, False, False)
            Drs = DataSetForm.Tables("TBdetails").Select("Flag <> 'Y'")
            If Drs.Length = 0 Then
                MsgBoxGeneral("No Data For Print Attachment !")
                Exit Sub
            End If

            'For Each dr As DataRow In Tb.Rows
            '    TTW += NullToValue(dr("TW"), 0)
            '    TNET += NullToValue(dr("NW"), 0)
            '    TGW += NullToValue(dr("GW"), 0)
            '    TTLPkgs += NullToValue(dr("nPkgs"), 0)
            'Next

            'Tb.AcceptChanges()
            For Each dr As DataRow In DataSetForm.Tables("TBdetails").Rows
                If NullToValue(dr("Flag"), "N") = "Y" Then
                    dr.Delete()
                End If
            Next

            'Added for Missing label
            'For Each dr As DataRow In DataSetForm.Tables("TBdetails").Rows
            '    Dim s As String = ""
            '    Dim commaIndex As Integer
            '    Dim part As String = ""
            '    If NullToValue(dr("Flag"), "Y") = "Y" Then
            '        'dr.Delete()
            '        If (dr("Flag").ToString().Contains(",")) Then
            '            s = dr("Flag").ToString().Trim()
            '            commaIndex = s.IndexOf(",")
            '            part = s.Substring(commaIndex)
            '        End If
            '    End If
            'Next
            'End Added for Missing label

            DataSetForm.Tables("TBdetails").AcceptChanges()
            RAttachment = New RptBlAttachment
            RAttachment.SetDataSource(DataSetForm.Tables("TBdetails"))

            'RAttachment.SetParameterValue("TTLGW", TGW)
            'RAttachment.SetParameterValue("TTLNET", TNET)
            'RAttachment.SetParameterValue("TTLPkgs", TTLPkgs)
            'RAttachment.SetParameterValue("POL", POL)
            Frm.ReportViewer.ReportSource = RAttachment
            Frm.Show()
        End If

    End Sub

    Private Sub PrePaerPreExpBL(ByVal CheckAttach As Boolean, ByRef TBResult As DataTable, ByVal IsGotoTemplate As Boolean, Optional ByVal RemoveAttachedRows As Boolean = True)

        Dim Drs() As DataRow
        Dim Ds As DataSet
        Dim DsTemp As DataSet
        Dim Dr As DataRow

        Dim FrmTmpl As FrmOutwardTempalte
        Dim Pcol(0) As DataColumn
        Dim cCol(0) As DataColumn
        Dim DsFinal As New DataSet
        Dim aField() As String = {""}
        Dim aValue() As String = {""}


        DsTemp = GenerateExpBL(CurrentShippingLine, sBLNO, CheckAttach)

        If CheckAttach = True Then
            Drs = DataSetForm.Tables("TBdetails").Select("Flag = 'N'")
            If Drs.Length = 0 Then
                MsgBoxGeneral("No Data For Print Attachment !")
                Exit Sub
            End If
            If RemoveAttachedRows = True Then
                Drs = DataSetForm.Tables("TBdetails").Select("Flag = 'Y'")
                For Each Dr In Drs
                    Dr.Delete()
                Next
            End If
            DataSetForm.Tables("TBdetails").AcceptChanges()
            TBResult = DataSetForm.Tables("TBdetails")
        Else
            If IsGotoTemplate = True Then
                FrmTmpl = New FrmOutwardTempalte(DsTemp.Tables(0), CurrentShippingLine)
                FrmTmpl.Show()
            Else
                TBResult = DsTemp.Tables(0)
            End If
        End If

    End Sub

    Public Function GenerateExpBL(ByVal Line As String, ByVal BlNo As String, ByVal CheckAttach As Boolean) As DataSet

        Dim Dfinal As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim BL As TB_OutwardBLS
        Dim Goods As TB_OutwardBlsGoods
        Dim Cntrs As TB_OutwardCntrsCollection
        Dim doc As TB_Documets
        Dim docs As TB_DocumetsDetailCollection
        Dim CntrsList As New ArrayList
        Dim CntrsCount As String
        Dim GoodsList As New ArrayList
        Dim Ds As New DataSet
        Dim CGS As TB_OutwardChargesCollection
        Dim Port As TB_Ports
        Dim sPort As String

        Dim Memo As CLMemo
        Dim MaxLen As Int16 = 0
        Dim IsShowGoods As Boolean = True
        Dim IsShowCntrs As Boolean = True
        Dim Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Frm As New FrmGeneralReportShow
        Dim TB As DataTable
        Dim Dv As DataView
        Dim nBeginGoods As Int16 = 0
        Dim nBeginCntrs As Int16 = 0
        Dim RAttachment As RPTBLNewAtch
        Dim TempTB As New DataTable
        Dim TmpDS As New DataSet
        Dim SummaryTB As DataTable
        Dim TempStr As String
        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim Col As DataColumn
        Dim Ans As Boolean
        Dim sWeight As String
        Dim sTTCntr As String
        Dim sTTPGK
        Dim BC As BarCodeBuilder

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, Line, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, BlNo, MatchType.Exact)

        BL = Dm.GetTB_OutwardBLS

        If BL Is Nothing Then
            MsgBoxGeneral("Invalid B/L No !", "Validate Failed")
            Exit Function
        End If
        If Not BL.BarCode = "" Then
            BC = New BarCodeBuilder(NullToValue(BL.BarCode, " "), Symbology.Code128)
            BC.CaptionBelow.Text = BL.BarCode
            BC.CodeTextAlignment = StringAlignment.Center
            BarCodeAddress = GenerateRandomFileName("JPG")
            If BL.BarCode <> Nothing Then
                BC.Save(BarCodeAddress)
            End If
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardCharges.Columns.BLID, BL.ID, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardCharges.Columns.ChargesCode, "OFT", MatchType.Exact)
        CGS = Dm.GetTB_OutwardChargesCollection

        Try
            If Not CGS Is Nothing Then
                sPort = CGS(0).PayAt
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortCode, sPort, MatchType.Exact)
                Port = Dm.GetTB_Ports
                If Not Port Is Nothing Then
                    sPort = Port.PortName
                End If
            End If
        Catch ex As Exception
        End Try

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBlsGoods.Columns.BLID, BL.ID, MatchType.Exact)
        Goods = Dm.GetTB_OutwardBlsGoods
        If Goods Is Nothing Then
            MsgBoxGeneral("No Goods Detail data !", "Validate Failed")
            Exit Function
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardCntrs.Columns.BLID, BL.ID, MatchType.Exact)
        Cntrs = Dm.GetTB_OutwardCntrsCollection
        If Goods Is Nothing Then
            MsgBoxGeneral("No Containers data !", "Validate Failed")
            Exit Function
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Documets.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_Documets.Columns.DocumentType, "BL", MatchType.Exact)


        TmpDS = StoredProcedures.SP_OutwardSummary(BL.ID.ToString)
        SummaryTB = TmpDS.Tables(0)

        sWeight = vbCrLf & "TOTAL GROSS WEIGHT " & Format(SummaryTB.Rows(0).Item("TGW"), "#,###,###,###.00" & "KGS")
        sWeight += vbCrLf & "TOTAL NET WEIGHT " & Format(SummaryTB.Rows(0).Item("TNW"), "#,###,###,###.00" & "KGS")


        Ds = StoredProcedures.SP_GetTotalOutwardCntrsByBLID(BL.ID.ToString)
        CntrsCount = NullToValue(Ds.Tables(0).Rows(0).Item(0).ToString, "")

        Memo = New CLMemo
        Ds = StoredProcedures.SP_GetOutwardCntrsListForPrintBL(BL.ID.ToString)
        Memo.GetFree(CntrsCount & Replace(Ds.Tables(0).Rows(0).Item(0).ToString, "##", vbCrLf), CntrsList, 20)

        Memo = New CLMemo
        Memo.GetFree(Goods.Goods + sWeight, GoodsList, 30) 'Changed from 35 to 30 for correction case

        TempStr = NullToValue(SummaryTB.Rows(0).Item("Imco"), "")
        TempStr += SummaryTB.Rows(0).Item("Cntrs")

        Ds = StoredProcedures.SP_PrintOutwardBls(CurrentShippingLine, BlNo, "Y", "Y")

        sTTCntr = vbCrLf & Ds.Tables(0).Rows(0).Item("TotalCntrsInWord")
        sTTPGK = vbCrLf & Ds.Tables(0).Rows(0).Item("TTLPkgs") & " " & Ds.Tables(0).Rows(0).Item("MainCom") & vbCrLf
        GenerateCols(Dm.DataSet.Tables("TB_OutwardCntrs"), TempStr, "SHIPPER'S LOAD, STOW, COUNT AND SEALED SAID TO CONTAIN " + sTTCntr + sTTPGK + Goods.Goods + sWeight, Ds.Tables(0), NullToValue(Goods.Marks, ""))

        Ds.Tables(0).Columns.Add("SealNo")
        PrepareBoday(Ds.Tables(0))

        Col = New DataColumn("TPkgs", System.Type.GetType("System.String"))
        Col.DefaultValue = SummaryTB.Rows(0).Item("Pkgs") '+ sTTCntr + sTTPGK
        Ds.Tables(0).Columns.Add(Col)
        Dr = Ds.Tables(0).Rows(0)


        Col = New DataColumn("Image", System.Type.GetType("System.Byte[]"))

        Ds.Tables(0).Columns.Add(Col)
        Dr = Ds.Tables(0).Rows(0)

        If CheckAttach = True Then
            Ds.Tables(0).Rows(0).Item("TGW") = Format(Ds.Tables(0).Rows(0).Item("TGW"), "standard") ' Double.Parse(Format(Ds.Tables(0).Rows(0).Item("TGW").ToString, "standard")).ToString()
            Ds.Tables(0).Rows(0).Item("TNet") = Format(NullToValue(Ds.Tables(0).Rows(0).Item("TNet"), 0), "standard")
            Ds.Tables(0).Rows(0).Item("TTW") = Format(Ds.Tables(0).Rows(0).Item("TTW"), "standard")
            Ds.Tables(0).Rows(0).Item("TCBM") = Format(Ds.Tables(0).Rows(0).Item("TCBM"), "standard")
            Ds.Tables(0).Rows(0).Item("Cluses") = GetDetentionClause(BL.POD)

        Else
            Ds.Tables(0).Rows(0).Item("Cntrs") = Replace(Ds.Tables(0).Rows(0).Item("cntrs").ToString, "##", vbCrLf)
            Ds.Tables(0).Rows(0).Item("TGW") = Format(Ds.Tables(0).Rows(0).Item("TGW"), "standard") ' Double.Parse(Format(Ds.Tables(0).Rows(0).Item("TGW").ToString, "standard")).ToString()
            Ds.Tables(0).Rows(0).Item("TNet") = Format(NullToValue(Ds.Tables(0).Rows(0).Item("TNet"), 0), "standard")
            Ds.Tables(0).Rows(0).Item("TTW") = Format(Ds.Tables(0).Rows(0).Item("TTW"), "standard")
            Ds.Tables(0).Rows(0).Item("TCBM") = Format(Ds.Tables(0).Rows(0).Item("TCBM"), "standard")
            Ds.Tables(0).Rows(0).Item("PayAT") = sPort
            Ds.Tables(0).Rows(0).Item("Cluses") = GetDetentionClause(BL.POD)

        End If

        Col = New DataColumn("BLID", System.Type.GetType("System.String"))
        Ds.Tables(0).Columns.Add(Col)

        For Each Dr In Ds.Tables(0).Rows
            Dr("BLID") = BL.ID
        Next
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortCode, BL.POL, MatchType.Exact)
        Dm.GetTB_Ports()
        If Dm.DataSet.Tables("TB_Ports").Rows.Count > 0 Then
            POL = Dm.DataSet.Tables("TB_Ports").Rows(0).Item("PortName")
        End If
        Return Ds

    End Function

    Private Sub ButtonTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTemplate.Click

        Dim Tb As New DataTable
        PrePaerPreExpBL(False, Tb, True)

    End Sub

    Public ReadOnly Property CmdPrint() As UltraButton
        Get
            Return ButtonPrint
        End Get
    End Property

    Public ReadOnly Property CmdAttachment() As UltraButton
        Get
            Return ButtonAttachment
        End Get
    End Property

    Public ReadOnly Property CmdTemplace() As UltraButton
        Get
            Return ButtonTemplate
        End Get
    End Property

    Public ReadOnly Property ComboType() As UserComboGnrl
        Get
            Return Me.ComboList
        End Get
    End Property
    Private Function GetDetentionClause(ByVal BLID)

        Dim Cmd As SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim TB As New DataTable

        Cnn.Open()

        If Direction = InwardOutward.Inward Then
            Cmd = New SqlCommand("Select dbo.FC_DetentionInformationInward('" & BLID.ToString & "')", Cnn)
        Else
            Cmd = New SqlCommand("Select dbo.FC_DetentionInformationOutward('" & BLID.ToString & "'", Cnn)
        End If

        With Cmd
            .CommandType = CommandType.Text
        End With
        DA.SelectCommand = Cmd
        DA.Fill(TB)

        Try
            Return TB.Rows(0).Item(0)
        Catch ex As Exception
            Return ""
        End Try

        Cnn.Close()


    End Function


    Private Function GetDetentionClause(ByVal POD As String)

        Dim Agent As TB_Agents
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Agents.Columns.Port, POD, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_Agents.Columns.Line, CurrentShippingLine, MatchType.Exact)

        Agent = Dm.GetTB_Agents
        If Not Agent Is Nothing Then
            Return NullToValue(Agent.DetentionClause, "")
        Else
            Return ""
        End If


    End Function


End Class
