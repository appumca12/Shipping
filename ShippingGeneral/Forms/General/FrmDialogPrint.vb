Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine  
Imports CRAXDDRT
Imports System.IO
'Imports Aspose.Words
'Imports Aspose.Words.Fields
'Imports Aspose.Words.Reporting
Public Class FrmDialogPrint

    ' Private RptFld As CRAXDDRT.TextObject
    Private IOStatus As InwardOutward
    Private Dm As DataManager
    Private TBMaster As DataTable
    Private sBLNO As String
    Private Grid As UltraGrid
    Private ResultTable As DataTable

    Enum InwardOutward
        Inward
        Outward
    End Enum
    Private Sub GenerateBL()

        Dim Dfinal As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'Dim Cr As CRAXDDRT.Application
        'Dim DocRpt As CRAXDDRT.Report
        Dim BL As TB_InwardBLS
        Dim Goods As TB_InwardBlsGoods
        Dim Cntrs As TB_InwardCntrsCollection
        Dim doc As TB_Documets
        Dim docs As TB_DocumetsDetailCollection
        Dim CntrsList As New ArrayList
        Dim CntrsCount As String
        Dim GoodsList As New ArrayList
        Dim Ds As New DataSet

        Dim Memo As CLMemo
        Dim MaxLen As Int16 = 0
        Dim IsShowGoods As Boolean = True
        Dim IsShowCntrs As Boolean = True
        Dim Rpt As New BL
        '   Dim Rpt2 As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Frm As New FrmGeneralReportShow
        Dim TB As DataTable
        Dim Dv As DataView
        Dim nBeginGoods As Int16 = 0
        Dim nBeginCntrs As Int16 = 0
        Dim Dr As DataRow
        Dim RAttachment As RPTBLNewAtch
        Dim TempTB As New DataTable
        Dim TmpDS As New DataSet
        Dim SummaryTB As DataTable
        Dim TempStr As String
        Dim Drs() As DataRow
        Dim Col As DataColumn
        Dim Ans As Boolean
        Dim Rpt2 As BLBlank


        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.BlNo.TextValue, MatchType.Exact)
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

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Documets.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_Documets.Columns.DocumentType, "BL", MatchType.Exact)

        doc = Dm.GetTB_Documets
        If doc Is Nothing Then
            MsgBoxGeneral("No B/L Defenition !", "Validate Failed")
            Exit Sub
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_DocumetsDetail.Columns.DocumentID, doc.ID)
        docs = Dm.GetTB_DocumetsDetailCollection
        If docs Is Nothing Then
            MsgBoxGeneral("No B/L Defenition !", "Validate Failed")
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
        Memo.GetFree(Goods.Goods, GoodsList, 30)

        TempStr = NullToValue(SummaryTB.Rows(0).Item("Imco"), "")
        TempStr += SummaryTB.Rows(0).Item("Cntrs")

        Ds = StoredProcedures.SP_PrintInwardBls(CurrentShippingLine, BlNo.TextValue, "Y", "Y")
        If Me.BLtype.Code <> "NP" Then
            Ds.Tables(0).Rows(0).Item("BlType") = Me.BLtype.ComboCode.Text
            Ds.AcceptChanges()
        End If

        GenerateCols(Dm.DataSet.Tables("TB_InwardCntrs"), TempStr, Goods.Goods, Ds.Tables(0), NullToValue(Goods.Marks, ""))

        TB = Dm.DataSet.Tables("TB_DocumetsDetail")
        Dv = New DataView(TB, "FieldDescription = 'Goods'", "", DataViewRowState.CurrentRows)
        If Dv.Count > 0 Then
            nBeginGoods = Dv.Item(0).Item("nHight")
        End If

        PrepareBoday(Ds.Tables(0), nBeginGoods)
        Col = New DataColumn("TPkgs", System.Type.GetType("System.String"))
        Col.DefaultValue = SummaryTB.Rows(0).Item("Pkgs")
        Ds.Tables(0).Columns.Add(Col)
        Dr = Ds.Tables(0).Rows(0)

        If CheckAttach.Checked = True Then

            Drs = DataSetForm.Tables("TBdetails").Select("Flag <> 'Y'")
            If Drs.Length = 0 Then
                MsgBoxGeneral("No Data For Print Attachment !")
                Exit Sub
            End If
            RAttachment = New RPTBLNewAtch
            RAttachment.SetDataSource(DataSetForm.Tables("TBdetails"))
            RAttachment.SetParameterValue("TTLGW", Ds.Tables(0).Rows(0).Item("TGW"))
            RAttachment.SetParameterValue("TTLNET", Ds.Tables(0).Rows(0).Item("TNet"))
            RAttachment.SetParameterValue("TTLCBM", Ds.Tables(0).Rows(0).Item("TCBM"))
            Frm.ReportViewer.ReportSource = RAttachment
            Frm.Show()

        Else
            Ds.Tables(0).Rows(0).Item("Cntrs") = Replace(Ds.Tables(0).Rows(0).Item("cntrs").ToString, "##", vbCrLf)
            'Ds.Tables(0).Rows(0).Item("TGW") = "T.Gross" & vbCrLf & Format(Ds.Tables(0).Rows(0).Item("TGW"), "standard")
            'Ds.Tables(0).Rows(0).Item("TNet") = "T.Net" & vbCrLf & Format(Ds.Tables(0).Rows(0).Item("TNet"), "standard")
            'Ds.Tables(0).Rows(0).Item("TTW") = "T.Tare" & vbCrLf & Format(Ds.Tables(0).Rows(0).Item("TTW"), "standard")
            'Ds.Tables(0).Rows(0).Item("TCBM") = "T.CMB" & vbCrLf & Format(Ds.Tables(0).Rows(0).Item("TCBM"), "standard")
            'Ds.Tables(0).Rows(0).Item("TGW") = "T.Gross" & vbCrLf & Format(Ds.Tables(0).Rows(0).Item("TGW"), "standard")
            Ds.Tables(0).Rows(0).Item("TNet") = Format(Ds.Tables(0).Rows(0).Item("TNet"), "standard")
            Ds.Tables(0).Rows(0).Item("TTW") = Format(Ds.Tables(0).Rows(0).Item("TTW"), "standard")
            Ds.Tables(0).Rows(0).Item("TCBM") = Format(Ds.Tables(0).Rows(0).Item("TCBM"), "standard")
            Ds.Tables(0).Rows(0).Item("Cluses") = Me.Details.TextValue
            Ds.Tables(0).Columns.Add(New DataColumn("Image", System.Type.GetType("System.Byte[]")))

            If ShowImage.Checked = True Then
                Rpt = New BL
                Rpt.SetDataSource(Ds.Tables(0))
                Frm.ReportViewer.ReportSource = Rpt
            Else
                Rpt2 = New BLBlank
                Rpt2.SetDataSource(Ds.Tables(0))
                Frm.ReportViewer.ReportSource = Rpt2

                '     Rpt.Section3.ReportObjects("Picture2").ObjectFormat.EnableSuppress = True
            End If
            'Rpt.SetDataSource(Ds.Tables(0))
            'Frm.ReportViewer.ReportSource = Rpt
            Frm.Show()
        End If

    End Sub

    'Private Sub MakeupReport(ByRef Rpt As Object)

    '    Dim Fld As CrystalDecisions.CrystalReports.Engine.FieldObject
    '    Dim Dr As DataRow
    '    Dim TB As DataTable
    '    Dim Fnt As New Font("arial", 17.0!, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline, GraphicsUnit.Pixel)

    '    TB = Dm.DataSet.Tables("TB_DocumetsDetail")

    '    For Each Dr In TB.Rows

    '        Try
    '            Fld = Rpt.ReportDefinition.ReportObjects.Item(Replace(Dr("FieldDescription"), " ", ""))
    '            Fld.ApplyFont(GenerateFont(Dr))
    '            Fld.Top = Dr("nTop") * 100
    '            Fld.Left = Dr("nLeft") * 100

    '            Fld.Height = Dr("nHight")
    '            Fld.Width = Dr("nWidth") * 100

    '            If Dr("Visible") = False Then
    '                Fld.ObjectFormat.EnableSuppress = True
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try
    '    Next


    'End Sub
    'Private Sub MakeupReportCdx(ByRef Rpt As CRAXDDRT.Report)

    '    Dim Fld As CRAXDDRT.FieldObject
    '    Dim Dr As DataRow
    '    Dim TB As DataTable
    '    Dim Fnt As New Font("arial", 17.0!, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline, GraphicsUnit.Pixel)
    '    Dim SystemFnt As Font
    '    TB = Dm.DataSet.Tables("TB_DocumetsDetail")
    '    For Each Dr In TB.Rows

    '        Try
    '            Fld = Rpt.Sections(3).ReportObjects.Item(Replace(Dr("FieldDescription"), " ", ""))
    '            SystemFnt = GenerateFont(Dr)
    '            GenerateFontCdx(Dr, Fld)
    '            Fld.Top = Dr("nTop") * 100
    '            Fld.Left = Dr("nLeft") * 100
    '            Fld.Width = Dr("nWidth") * 100
    '            '            Fld.Height = SystemFnt.Height
    '            Fld.CanGrow = True
    '            Fld.MaxNumberOfLines = Dr("nHight")
    '            If Dr("Visible") = False Then
    '                Fld.Suppress = True
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '            MsgBox(Dr("FieldDescription"))
    '        End Try
    '    Next

    'End Sub
    'Private Function GenerateFont(ByVal Dr As DataRow) As Font

    '    Dim Fnt As New Font("Arial", 9)
    '    Dim ResultFnt As New Font("Arial", 9)

    '    Try
    '        Fnt = New Font(Dr("FontName").ToString, NullToValue(Dr("FontSize"), 9), FontStyle.Regular)
    '        ResultFnt = Fnt

    '        If NullToValue(Dr("FontBold"), False) = True Then
    '            ResultFnt = Fnt
    '            ResultFnt = New Font(Fnt.Name, Fnt.Size, FontStyle.Bold)
    '        End If

    '        If NullToValue(Dr("FontItalic"), False) = True Then
    '            ResultFnt = New Font(Fnt.Name, Fnt.Size, FontStyle.Italic)
    '        End If

    '        If NullToValue(Dr("FontUnderline"), False) = True Then
    '            Fnt = ResultFnt
    '            ResultFnt = New Font(Fnt.Name, Fnt.Size, FontStyle.Underline)
    '        End If

    '        If NullToValue(Dr("FontStrickOut"), False) = True Then
    '            If NullToValue(Dr("FontUnderline"), False) = True Then
    '                ResultFnt = New Font(Fnt.Name, Fnt.Size, FontStyle.Strikeout Or FontStyle.Underline)
    '            Else
    '                ResultFnt = New Font(Fnt.Name, Fnt.Size, FontStyle.Strikeout)
    '            End If
    '        End If


    '    Catch ex As Exception

    '    End Try

    '    Return ResultFnt

    'End Function
    'Private Sub GenerateFontCdx(ByVal Dr As DataRow, ByRef Fld As CRAXDDRT.FieldObject)

    '    Try
    '        With Fld.Font
    '            .Name = NullToValue(Dr("FontName"), "Arial")
    '            .Size = NullToValue(Dr("FontSize"), 9)
    '            .Bold = NullToValue(Dr("FontBold"), False)
    '            .Italic = NullToValue(Dr("FontItalic"), False)
    '            .Underline = NullToValue(Dr("FontUnderline"), False)
    '            .Strikethrough = NullToValue(Dr("FontStrickOut"), False)
    '        End With
    '    Catch ex As Exception

    '    End Try


    'End Sub

    Private Sub FrmDialogPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Group As String

        Group = IIf(IOStatus = InwardOutward.Inward, "BI", "BO")
        Dm = New DataManager(My.Settings.DSN)

        Me.BLtype.InitControl("PT", UserComboCode.ShowCoumn.Meaning)
        Me.BLtype.AddItemOutSide("NP", "No Print", "")

        Dm.QueryCriteria.And(JoinPath.TB_Cluses.Columns.CluseGroup, Group, MatchType.Exact)
        Dm.GetTB_ClusesCollection()


        'If Not Dm.DataSet.Tables("TB_Cluses") Is Nothing Then
        '    For Each dr As DataRow In Dm.DataSet.Tables("TB_Cluses").Rows
        '        Me.DataSetForm.Tables(0).ImportRow(dr)
        '    Next
        'End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, "", MatchType.Greater)
        Dm.GetTB_Lines()

        Dim Dr As DataRow
        Dim nDr As DataRow
        For Each Dr In Dm.DataSet.Tables("TB_Lines").Rows
            nDr = DataSetForm.Tables("TBBLFormat").NewRow
            nDr("Line") = Dr("LineCode")
            nDr("LineName") = Dr("LineName")
            DataSetForm.Tables("TBBLFormat").Rows.Add(nDr)
        Next

        With Me.BLLineFormat.DisplayLayout.Bands(0)
            .Columns("Line").Hidden = True
            .Columns("LineName").Width = 300
        End With



        Me.BlNo.TextValue = sBLNO

        If Grid Is Nothing Then
            Me.CheckAll.Visible = False
        End If

    End Sub

    Private Function MakeAttachment(ByVal BlNo As String, _
                               ByVal Vessel As String, _
                               ByVal Voyage As String, _
                               ByVal Cntrs As ArrayList, _
                               ByVal Goods As ArrayList, _
                               ByVal nBeginGoods As Long, _
                               ByVal nBeginCntrs As Long) As DataTable

        Dim Tb As New DataTable
        Dim Dr As DataRow
        Dim nI As Long
        Dim nJ As Long
        Dim Col As DataColumn
        Dim Dv As DataView

        Tb.Columns.Add(New DataColumn("BLNo", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Vessel", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Voyage", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Cntrs", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Goods", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Seq", System.Type.GetType("System.String")))
        For Each Col In Tb.Columns
            Col.AllowDBNull = True
        Next

        If Cntrs.Count > nBeginCntrs Then
            For nI = nBeginCntrs To Cntrs.Count - 1
                Dr = Tb.NewRow
                nJ += 1
                Dr("BlNo") = BlNo
                Dr("Vessel") = Vessel
                Dr("Voyage") = Voyage
                Dr("Cntrs") = Cntrs(nI)
                Dr("Seq") = nJ
                Tb.Rows.Add(Dr)
            Next
        End If

        If Goods.Count > nBeginGoods Then
            For nI = nBeginGoods To Goods.Count - 1
                Dv = New DataView(Tb, "seq = " & nI, "", DataViewRowState.CurrentRows)
                If Dv.Count > 0 Then
                    Dv.Item(0).Item("Goods") = Goods(nI)
                Else
                    nJ += 1
                    Dr = Tb.NewRow
                    nJ += 1
                    Dr("BlNo") = BlNo
                    Dr("Vessel") = Vessel
                    Dr("Voyage") = Voyage
                    Dr("Goods") = Goods(nI)
                    Dr("Seq") = nJ
                    Tb.Rows.Add(Dr)
                End If
            Next
        End If
        Return Tb

    End Function

    Public Function GenerateExpBL(ByVal Line As String, ByVal BlNo As String) As DataSet

        Dim Dfinal As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '   Dim Cr As CRAXDDRT.Application
        '  Dim DocRpt As CRAXDDRT.Report
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

        Dm = New DataManager(My.Settings.DSN)
        'Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        'Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, Me.BlNo.TextValue, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, Line, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, BlNo, MatchType.Exact)

        BL = Dm.GetTB_OutwardBLS

        If BL Is Nothing Then
            MsgBoxGeneral("Invalid B/L No !", "Validate Failed")
            Exit Function
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

        doc = Dm.GetTB_Documets
        If doc Is Nothing Then
            MsgBoxGeneral("No B/L Defenition !", "Validate Failed")
            Exit Function
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_DocumetsDetail.Columns.DocumentID, doc.ID)
        docs = Dm.GetTB_DocumetsDetailCollection
        If docs Is Nothing Then
            MsgBoxGeneral("No B/L Defenition !", "Validate Failed")
            Exit Function
        End If

        TmpDS = StoredProcedures.SP_OutwardSummary(BL.ID.ToString)
        SummaryTB = TmpDS.Tables(0)

        sWeight = vbCrLf & "TOTAL GROSS WEIGHT " & Format(SummaryTB.Rows(0).Item("TGW"), "#,###,###,###.00")
        sWeight += vbCrLf & "TOTAL NET WEIGHT " & Format(SummaryTB.Rows(0).Item("TNW"), "#,###,###,###.00")


        Ds = StoredProcedures.SP_GetTotalOutwardCntrsByBLID(BL.ID.ToString)
        CntrsCount = NullToValue(Ds.Tables(0).Rows(0).Item(0).ToString, "")

        Memo = New CLMemo
        Ds = StoredProcedures.SP_GetOutwardCntrsListForPrintBL(BL.ID.ToString)
        Memo.GetFree(CntrsCount & Replace(Ds.Tables(0).Rows(0).Item(0).ToString, "##", vbCrLf), CntrsList, 20)

        Memo = New CLMemo
        Memo.GetFree(Goods.Goods + sWeight, GoodsList, 30)

        TempStr = NullToValue(SummaryTB.Rows(0).Item("Imco"), "")
        TempStr += SummaryTB.Rows(0).Item("Cntrs")

        Ds = StoredProcedures.SP_PrintOutwardBls(CurrentShippingLine, BlNo, "Y", "Y")
        If Me.BLtype.Code <> "NP" Then
            Ds.Tables(0).Rows(0).Item("BlType") = Me.BLtype.ComboCode.Text
            Ds.AcceptChanges()
        End If

        GenerateCols(Dm.DataSet.Tables("TB_OutwardCntrs"), TempStr, Goods.Goods + sWeight, Ds.Tables(0), NullToValue(Goods.Marks, ""))

        TB = Dm.DataSet.Tables("TB_DocumetsDetail")
        Dv = New DataView(TB, "FieldDescription = 'Goods'", "", DataViewRowState.CurrentRows)
        If Dv.Count > 0 Then
            nBeginGoods = Dv.Item(0).Item("nHight")
        End If

        PrepareBoday(Ds.Tables(0), nBeginGoods)

        Col = New DataColumn("TPkgs", System.Type.GetType("System.String"))
        Col.DefaultValue = SummaryTB.Rows(0).Item("Pkgs")
        Ds.Tables(0).Columns.Add(Col)
        Dr = Ds.Tables(0).Rows(0)


        Col = New DataColumn("Image", System.Type.GetType("System.Byte[]"))

        Ds.Tables(0).Columns.Add(Col)
        Dr = Ds.Tables(0).Rows(0)

        ''     RetriveObject(Me.BLLineFormat.Value & "BL", "C:\Temp\Image.jpg")
        'Ds.Tables(0).Rows(0).Item("Image") = GetImageData("C:\Temp\Image.jpg")


        If CheckAttach.Checked = True Then
            'Drs = DataSetForm.Tables("TBdetails").Select("Flag <> 'Y'")
            'If Drs.Length = 0 Then
            '    MsgBoxGeneral("No Data For Print Attachment !")
            '    Exit Sub
            'End If
            'RAttachment = New RPTBLNewAtch
            'RAttachment.SetDataSource(DataSetForm.Tables("TBdetails"))
            'Frm.ReportViewer.ReportSource = RAttachment
            'Frm.Show()
            Ds.Tables(0).Rows(0).Item("TGW") = Format(Ds.Tables(0).Rows(0).Item("TGW"), "standard") ' Double.Parse(Format(Ds.Tables(0).Rows(0).Item("TGW").ToString, "standard")).ToString()
            Ds.Tables(0).Rows(0).Item("TNet") = Format(NullToValue(Ds.Tables(0).Rows(0).Item("TNet"), 0), "standard")
            Ds.Tables(0).Rows(0).Item("TTW") = Format(Ds.Tables(0).Rows(0).Item("TTW"), "standard")
            Ds.Tables(0).Rows(0).Item("TCBM") = Format(Ds.Tables(0).Rows(0).Item("TCBM"), "standard")

        Else
            Ds.Tables(0).Rows(0).Item("Cntrs") = Replace(Ds.Tables(0).Rows(0).Item("cntrs").ToString, "##", vbCrLf)
            'Ds.Tables(0).Rows(0).Item("TGW") = "T.Gross (KGS)" & vbCrLf & Format(Ds.Tables(0).Rows(0).Item("TGW"), "standard") ' Double.Parse(Format(Ds.Tables(0).Rows(0).Item("TGW").ToString, "standard")).ToString()
            'Ds.Tables(0).Rows(0).Item("TNet") = "T.Net (KGS)" & vbCrLf & Format(NullToValue(Ds.Tables(0).Rows(0).Item("TNet"), 0), "standard")
            'Ds.Tables(0).Rows(0).Item("TTW") = "T.Tare (KGS)" & vbCrLf & Format(Ds.Tables(0).Rows(0).Item("TTW"), "standard")
            'Ds.Tables(0).Rows(0).Item("TCBM") = "T.CMB" & vbCrLf & Format(Ds.Tables(0).Rows(0).Item("TCBM"), "standard")
            Ds.Tables(0).Rows(0).Item("TGW") = Format(Ds.Tables(0).Rows(0).Item("TGW"), "standard") ' Double.Parse(Format(Ds.Tables(0).Rows(0).Item("TGW").ToString, "standard")).ToString()
            Ds.Tables(0).Rows(0).Item("TNet") = Format(NullToValue(Ds.Tables(0).Rows(0).Item("TNet"), 0), "standard")
            Ds.Tables(0).Rows(0).Item("TTW") = Format(Ds.Tables(0).Rows(0).Item("TTW"), "standard")
            Ds.Tables(0).Rows(0).Item("TCBM") = Format(Ds.Tables(0).Rows(0).Item("TCBM"), "standard")


            Ds.Tables(0).Rows(0).Item("PayAT") = sPort
            Ds.Tables(0).Rows(0).Item("Cluses") = Me.Details.TextValue
            '   Ds.Tables(0).Columns.Add(New DataColumn("Image", System.Type.GetType("System.Byte[]")))

        End If

        Col = New DataColumn("BLID", System.Type.GetType("System.String"))
        Ds.Tables(0).Columns.Add(Col)
        For Each Dr In Ds.Tables(0).Rows
            Dr("BLID") = BL.ID
        Next

        Return Ds
        '      Ds.WriteXml("c:\temp\bl.xml")
    End Function

    Public Sub New(ByVal InOut As InwardOutward, ByVal sBlNo As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        IOStatus = InOut
        Me.sBLNO = sBlNo

    End Sub

    Public Sub New(ByVal InOut As InwardOutward, ByVal sBlNo As String, ByVal Grid As UltraGrid)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        IOStatus = InOut
        Me.sBLNO = sBlNo
        Me.Grid = Grid

    End Sub
    Public Sub New(ByVal InOut As InwardOutward, ByVal sBlNo As String, ByRef TB As DataTable)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        IOStatus = InOut
        Me.sBLNO = sBlNo
        Me.Grid = Grid

    End Sub

    Private Function FillDataInDs(ByVal TempDr As DataRow, ByVal FileName As String) As DataTable

        Dim dsImgRpt As New DSPrintBL
        Dim Col As DataColumn

        Dim dr As DSPrintBL.BLRow = dsImgRpt.BL.NewBLRow
        For Each Col In TempDr.Table.Columns
            Try
                dr(Col.ColumnName) = TempDr(Col.ColumnName)
            Catch ex As Exception

            End Try
        Next
        '       dr.Photo = GetImageData(FileName)
        dsImgRpt.BL.Rows.Add(dr)

        Return dsImgRpt.Tables(0)

    End Function

    Private Function GetImageData(ByVal fileName As String) As Byte()

        'Method to load an image from disk and return it as a bytestream

        Dim fs As System.IO.FileStream = _
 New System.IO.FileStream(fileName, _
                System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim br As System.IO.BinaryReader = New System.IO.BinaryReader(fs)

        Return (br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)))

    End Function



    Private Sub GenerateBlForm()


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
        Dim Rpt As New RptTranshipBL
        Dim Frm As New FrmGeneralReportShow
        Dim TB As DataTable
        Dim nBeginGoods As Int16 = 0
        Dim nBeginCntrs As Int16 = 0
        Dim HasAttach As Boolean
        Dim Dr As DataRow
        Dim RAttachment As Object
        Dim TempTB As New DataTable
        Dim PH As New CLPrintHdr

        'PaperA4 = 9 
        'PaperFanfoldUS = 39 

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.BlNo.TextValue, MatchType.Exact)
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

        Ds = StoredProcedures.SP_GetTotalInwardCntrsByBLID(BL.ID.ToString)
        CntrsCount = NullToValue(Ds.Tables(0).Rows(0).Item(0).ToString, "")

        Memo = New CLMemo
        Ds = StoredProcedures.SP_GetInwardCntrsListForPrintBLTran(BL.ID.ToString)
        Memo.GetFree(CntrsCount & Ds.Tables(0).Rows(0).Item(0).ToString, CntrsList, 35)

        Memo = New CLMemo
        Memo.GetFree(Goods.Goods, GoodsList, 30)

        Ds = StoredProcedures.SP_PrintInwardBlsTran(CurrentShippingLine, BlNo.TextValue, IIf(IsShowGoods, "Y", "N"), IIf(IsShowCntrs, "Y", "N"))
        If Me.BLtype.Code <> "NP" Then
            Ds.Tables(0).Rows(0).Item("BlType") = Me.BLtype.ComboCode.Text
            Ds.AcceptChanges()
        End If

        Dr = Ds.Tables(0).Rows(0)
        TB = Ds.Tables(0)

        For Each Dr In TB.Rows
            Dr("Cntrs") = Replace(Dr("Cntrs"), "##", vbCrLf)
            Dr("TW") = Replace(Dr("TW"), vbCr, " ")
            Dr("TW") = Replace(Dr("TW"), "(KGS)", " ")

            Dr("GW") = Replace(Dr("GW"), vbCr, " ")
            Dr("GW") = Replace(Dr("GW"), "(KGS)", "")
        Next


        If HasAttach = True And Me.CheckFormAttach.CheckState = CheckState.Checked Then
            RAttachment = New RptBlAttachment
            RAttachment.Subreports(0).SetDataSource(PH.ImageTable)
            RAttachment.SetDataSource(MakeAttachment(Dr("BLNO"), Dr("Vessel"), Dr("Voyage"), CntrsList, GoodsList, nBeginGoods, nBeginCntrs))
            Frm.ReportViewer.ReportSource = RAttachment
            Frm.Show()
        Else
            Rpt.SetDataSource(TB)
            Rpt.SetParameterValue(0, CurrentShippingLine)
            Frm.ReportViewer.ReportSource = Rpt
            Frm.Show()
        End If

    End Sub

    Private Sub GenerateExpBLForm()

        Dim BL As TB_OutwardBLS
        Dim Goods As TB_OutwardBlsGoods
        Dim Cntrs As TB_OutwardCntrsCollection
        Dim CntrsList As New ArrayList
        Dim CntrsCount As String
        Dim GoodsList As New ArrayList
        Dim Ds As New DataSet
        Dim Memo As CLMemo
        Dim MaxLen As Int16 = 0
        Dim IsShowGoods As Boolean = True
        Dim IsShowCntrs As Boolean = True
        Dim Rpt As New RptTranshipBL
        Dim Frm As New FrmGeneralReportShow
        Dim TB As DataTable
        Dim nBeginGoods As Int16 = 0
        Dim nBeginCntrs As Int16 = 0
        Dim HasAttach As Boolean
        Dim Dr As DataRow
        Dim RAttachment As Object
        Dim lResult As Boolean
        Dim TempList As New ArrayList
        Dim TempStr As String = ""
        Dim aFld() As String = {"FLD"}
        Dim PH As New CLPrintHdr

        'PaperA4 = 9 
        'PaperFanfoldUS = 39 

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, Me.BlNo.TextValue, MatchType.Exact)
        BL = Dm.GetTB_OutwardBLS
        If BL Is Nothing Then
            MsgBoxGeneral("Invalid B/L No !", "Validate Failed")
            Exit Sub
        End If


        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBlsGoods.Columns.BLID, BL.ID, MatchType.Exact)
        Goods = Dm.GetTB_OutwardBlsGoods
        If Goods Is Nothing Then
            MsgBoxGeneral("No Goods Detail data !", "Validate Failed")
            Exit Sub
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardCntrs.Columns.BLID, BL.ID, MatchType.Exact)
        Cntrs = Dm.GetTB_OutwardCntrsCollection
        If Goods Is Nothing Then
            MsgBoxGeneral("No Containers data !", "Validate Failed")
            Exit Sub
        End If


        TempList = FieldsBySql("select dbo.FC_GetOutwardImco('" & BL.ID.ToString & "') As FLD ", aFld, lResult)
        If TempList.Count > 0 Then
            TempStr = TempList(0)
        End If

        TempList = FieldsBySql("Select dbo.FC_TotalOutwardCntrsByBLID ('" & BL.ID.ToString & "') as FLD ", aFld, lResult)
        If TempList.Count > 0 Then
            If TempStr = "" Then
                TempStr = TempList(0)
            Else
                TempStr += " " & vbCrLf & TempList(0)
            End If
        End If

        '    GenerateCols(Dm.DataSet.Tables("TB_OutwardCntrs"), TempStr, Goods.Goods, BL.BlNo, "", "", "")

        Ds = StoredProcedures.SP_GetTotalOutwardCntrsByBLID(BL.ID.ToString)
        CntrsCount = NullToValue(Ds.Tables(0).Rows(0).Item(0).ToString, "")

        Memo = New CLMemo
        Ds = StoredProcedures.SP_GetOutwardCntrsListForPrintBL(BL.ID.ToString)
        Memo.GetFree(CntrsCount & Ds.Tables(0).Rows(0).Item(0).ToString, CntrsList, 20)

        Memo = New CLMemo
        Memo.GetFree(Goods.Goods, GoodsList, 30)

        Ds = StoredProcedures.SP_PrintOutwardBlsTran(CurrentShippingLine, BlNo.TextValue, IIf(IsShowGoods, "Y", "N"), IIf(IsShowCntrs, "Y", "N"))
        If Me.BLtype.Code <> "NP" Then
            Ds.Tables(0).Rows(0).Item("BlType") = Me.BLtype.ComboCode.Text
            Ds.AcceptChanges()
        End If

        Dr = Ds.Tables(0).Rows(0)
        TB = Ds.Tables(0)

        For Each Dr In TB.Rows
            Dr("Cntrs") = Replace(NullToValue(Dr("Cntrs"), ""), "##", vbCrLf)
            Dr("TW") = Replace(NullToValue(Dr("TW"), 0), vbCr, " ")
            Dr("TW") = Replace(NullToValue(Dr("TW"), 0), "(KGS)", " ")
            Dr("GW") = Replace(NullToValue(Dr("GW"), 0), vbCr, " ")
            Dr("GW") = Replace(NullToValue(Dr("GW"), 0), "(KGS)", "")
        Next

        If HasAttach = True And Me.CheckFormAttach.CheckState = CheckState.Checked Then
            RAttachment = New RptBlAttachment
            RAttachment.Subreports(0).SetDataSource(PH.ImageTable)
            RAttachment.SetDataSource(MakeAttachment(Dr("BLNO"), Dr("Vessel"), Dr("Voyage"), CntrsList, GoodsList, nBeginGoods, nBeginCntrs))
            Frm.ReportViewer.ReportSource = RAttachment
            Frm.Show()
        Else
            Rpt.SetDataSource(TB)
            Rpt.SetParameterValue(0, CurrentShippingLine)
            Frm.ReportViewer.ReportSource = Rpt
            Frm.Show()
        End If

    End Sub

   

    Private Sub GenerateCols(ByVal Cns As DataTable, ByVal CnsStr As String, ByVal Goods As String, ByVal TB As DataTable, ByVal Marks As String)


        Dim Mem As New CLMemo
        Dim Col As New ArrayList
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim nI As Long
        Dim nJ As Long


        Mem = New CLMemo
        Mem.GetFree(CnsStr & " ", Col, 20)
        Me.DataSetForm.Tables("TBDetails").Clear()

        For nI = 0 To Col.Count - 1
            Dr = Me.DataSetForm.Tables("TBDetails").NewRow
            Dr("Seq") = nI + 1
            Dr("Cns") = Col(nI)
            Dr("Pkgs") = ""
            Dr("BLNO") = TB.Rows(0).Item("BlNo")
            Dr("Vessel") = TB.Rows(0).Item("Vessel")
            Dr("Voyage") = TB.Rows(0).Item("Voyage")
            Dr("POD") = TB.Rows(0).Item("Pod")
            Dr("Flag") = "N"
            Dr("FPOD") = TB.Rows(0).Item("FPOD")
            Dr("NW") = 0
            Dr("GW") = 0
            Dr("TW") = 0
            Dr("Npkgs") = 0
            Me.DataSetForm.Tables("TBDetails").Rows.Add(Dr)
        Next


      
        Col = New ArrayList
        Mem = New CLMemo
        Mem.GetFree(Goods, Col, 30)

        For nI = 0 To Col.Count - 1
            Drs = Me.DataSetForm.Tables("TBDetails").Select("Seq = " & nI + 1)
            If Drs.Length = 0 Then
                Dr = Me.DataSetForm.Tables("TBDetails").NewRow
                Dr("Seq") = nI + 1
                Dr("Goods") = Col(nI)
                Dr("BLNO") = TB.Rows(0).Item("BlNo")
                Dr("Vessel") = TB.Rows(0).Item("Vessel")
                Dr("Voyage") = TB.Rows(0).Item("Voyage")
                Dr("Pkgs") = ""
                Dr("POD") = TB.Rows(0).Item("Pod")
                Dr("Flag") = "N"
                Dr("FPOD") = TB.Rows(0).Item("FPOD")
                Dr("NW") = 0
                Dr("GW") = 0
                Dr("TW") = 0
                Dr("Npkgs") = 0
                Me.DataSetForm.Tables("TBDetails").Rows.Add(Dr)
            Else
                Drs(0).Item("Goods") = Col(nI)
            End If
        Next

        nI = Me.DataSetForm.Tables("TBDetails").Rows.Count
        For Each TempDr As DataRow In Cns.Rows
            nI += 1
            Dr = Me.DataSetForm.Tables("TBDetails").NewRow
            Dr("Seq") = nI
            Dr("Cns") = TempDr("CntrNo") & "/" & TempDr("CnSize") & "'" & TempDr("CnType")
            Dr("Pkgs") = TempDr("NoOfPkgs")
            Dr("Goods") = Mid(NullToValue(TempDr("Goods"), ""), 1, 30)
            Dr("NW") = Format(NullToValue(TempDr("NET"), 0), "standard")
            Dr("GW") = Format(TempDr("GW"), "standard")
            Dr("TW") = Format(TempDr("TW"), "standard")
            Dr("BLNO") = TB.Rows(0).Item("BlNo")
            Dr("Vessel") = TB.Rows(0).Item("Vessel")
            Dr("Voyage") = TB.Rows(0).Item("Voyage")
            Dr("POD") = TB.Rows(0).Item("Pod")
            Dr("Npkgs") = TempDr("NoOfPkgs")
            Dr("Flag") = "N"
            Dr("FPOD") = TB.Rows(0).Item("FPOD")
            Me.DataSetForm.Tables("TBDetails").Rows.Add(Dr)
            nI += 1
            Dr = Me.DataSetForm.Tables("TBDetails").NewRow
            Dr("Seq") = nI
            Dr("Cns") = "Seal:" & TempDr("SealNo")
            Dr("Pkgs") = GetMeaningCode("PG", NullToValue(TempDr("PackageType"), ""))
            Dr("BLNO") = TB.Rows(0).Item("BlNo")
            Dr("Vessel") = TB.Rows(0).Item("Vessel")
            Dr("Voyage") = TB.Rows(0).Item("Voyage")
            Dr("POD") = TB.Rows(0).Item("Pod")
            Dr("Npkgs") = 0
            Dr("NW") = 0
            Dr("GW") = 0
            Dr("TW") = 0
            Dr("Flag") = "N"
            Dr("FPOD") = TB.Rows(0).Item("FPOD")
            Me.DataSetForm.Tables("TBDetails").Rows.Add(Dr)
        Next

        Col = New ArrayList
        Mem = New CLMemo
        Mem.GetFree(Marks & " ", Col, 20)

        nJ = Me.DataSetForm.Tables("TBDetails").Rows.Count
        For nI = 0 To Col.Count - 1
            Dr = Me.DataSetForm.Tables("TBDetails").NewRow
            nJ += 1
            Dr("Seq") = nJ
            Dr("Cns") = Col(nI)
            Dr("Pkgs") = ""
            Dr("BLNO") = TB.Rows(0).Item("BlNo")
            Dr("Vessel") = TB.Rows(0).Item("Vessel")
            Dr("Voyage") = TB.Rows(0).Item("Voyage")
            Dr("POD") = TB.Rows(0).Item("Pod")
            Dr("Flag") = "N"
            Dr("FPOD") = TB.Rows(0).Item("FPOD")
            Dr("NW") = 0
            Dr("GW") = 0
            Dr("TW") = 0
            Dr("Npkgs") = 0
            Me.DataSetForm.Tables("TBDetails").Rows.Add(Dr)
        Next

    End Sub

    Private Sub PrepareBoday(ByVal TB As DataTable, ByVal DocLen As Int16)

        Dim sCns As String = ""
        Dim sPkgs As String = ""
        Dim sGoods As String = ""
        Dim sNW As String = ""
        Dim sGW As String = ""
        Dim sTW As String = ""
       
        Dim Drs() As DataRow = DataSetForm.Tables("TBDetails").Select("Seq > 0", "Seq")
        For Each dr As DataRow In Drs
            If Int16.Parse(dr("Seq").ToString) = DocLen Then
                sGoods += vbCr & "B/L Continue In Attachment List"
                Exit For
            End If
            sCns += Replace(Trim(NullToValue(dr("Cns"), "")), vbCrLf, "") & vbCrLf
            sGoods += Replace(Trim(NullToValue(dr("Goods"), "")), vbCrLf, "") & vbCrLf
            sPkgs += Replace(Trim(NullToValue(dr("Pkgs"), "")), vbCrLf, "") & vbCrLf
            sNW += Format(IIf(NullToValue(dr("NW"), 0) = 0, "", NullToValue(dr("NW"), 0)), "Standard") & vbCrLf
            sGW += Format(IIf(NullToValue(dr("GW"), 0) = 0, "", NullToValue(dr("GW"), 0)), "Standard") & vbCrLf
            sTW += Format(IIf(NullToValue(dr("TW"), 0) = 0, "", NullToValue(dr("TW"), 0)), "Standard") & vbCrLf
            dr("Flag") = "Y"
        Next

        TB.Rows(0).Item("Cntrs") = sCns
        TB.Rows(0).Item("Goods") = sGoods
        TB.Rows(0).Item("Pkgs") = sPkgs
        TB.Rows(0).Item("NET") = sNW
        TB.Rows(0).Item("GW") = sGW
        TB.Rows(0).Item("TW") = sTW

    End Sub

    Private Sub FrmPrnt_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrmPrnt_Button.Click
        If IOStatus = InwardOutward.Inward Then
            GenerateBlForm()
        Else
            GenerateExpBLForm()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim Row As UltraGridRow
        Dim aBls As New ArrayList

        If Me.CheckAll.Checked = True Then
            For Each Row In Grid.Rows
                If Row.Cells("Select").Value = 1 Then
                    aBls.Add(New String() {Row.Cells("Line").Value.ToString, Row.Cells("BLNO").Value.ToString})
                End If
            Next
        Else
            aBls.Add(New String() {CurrentShippingLine, Me.BlNo.TextValue})
        End If
     
        If IOStatus = InwardOutward.Inward Then
            GenerateBL()
        Else
            PrePaerPreExpBL(aBls)
        End If
    End Sub


    Private Sub PrePaerPreExpBL(ByVal aBls As ArrayList)

        Dim Dfinal As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '   Dim Cr As CRAXDDRT.Application
        '  Dim DocRpt As CRAXDDRT.Report
        Dim Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Rpt2 As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim RAttachment As RPTBLNewAtch
        Dim Frm As New FrmGeneralReportShow
        Dim Fld As CrystalDecisions.CrystalReports.Engine.TextObject

        Dim Drs() As DataRow
        Dim Ds As DataSet
        Dim Ans As Boolean
        Dim DsTemp As DataSet
        Dim Dr As DataRow

        Dim FrmTmpl As FrmOutwardTempalte
        Dim FleName As String
        Dim Pcol(0) As DataColumn
        Dim cCol(0) As DataColumn
        Dim DsFinal As New DataSet
        '   Dim DOC As Document
        Dim aField() As String = {""}
        Dim aValue() As String = {""}

        Dim Rel As DataRelation

        For Each Item() As String In aBls
            DsTemp = GenerateExpBL(Item(0), Item(1))
            If Ds Is Nothing Then
                Ds = DsTemp.Copy
            Else
                Ds.Tables(0).Merge(DsTemp.Tables(0))
            End If
        Next
        If CheckAttach.Checked = True Then
            Drs = DataSetForm.Tables("TBdetails").Select("Flag = 'N'")
            If Drs.Length = 0 Then
                MsgBoxGeneral("No Data For Print Attachment !")
                Exit Sub
            End If
            Drs = DataSetForm.Tables("TBdetails").Select("Flag = 'Y'")
            For Each Dr In Drs
                Dr.Delete()
            Next
            DataSetForm.Tables("TBdetails").AcceptChanges()

            'strart Remove to Change By Word
            RAttachment = New RPTBLNewAtch
            RAttachment.SetDataSource(DataSetForm.Tables("TBdetails"))
            RAttachment.SetParameterValue("TTLGW", Ds.Tables(0).Rows(0).Item("TGW"))
            RAttachment.SetParameterValue("TTLNET", Ds.Tables(0).Rows(0).Item("TNet"))
            RAttachment.SetParameterValue("TTLPKGS", Ds.Tables(0).Rows(0).Item("TPkgs"))
            RAttachment.SetParameterValue("POL", DsTemp.Tables(0).Rows(0).Item("POL"))
            Frm.ReportViewer.ReportSource = RAttachment
            Frm.Show()
            'End Remove to Change By Word

            'DsFinal = New DataSet
            'DsFinal.Tables.Add(DataSetForm.Tables("TBdetails").Copy)
            'DsFinal.Tables(0).Clear()
            'DsFinal.Tables(0).TableName = "BL"
            'DsFinal.Tables(0).ImportRow(DataSetForm.Tables("TBdetails").Rows(0))

            'With DsFinal.Tables(0)
            '    .Columns.Add(New DataColumn("TTLGW"))
            '    .Columns.Add(New DataColumn("TTLNET"))
            '    .Columns.Add(New DataColumn("TTLPKG"))
            'End With

            'DsFinal.Tables(0).Rows(0).Item("TTLGW") = Ds.Tables(0).Rows(0).Item("TGW")
            'DsFinal.Tables(0).Rows(0).Item("TTLNET") = Ds.Tables(0).Rows(0).Item("TNeT")
            'DsFinal.Tables(0).Rows(0).Item("TTLPKG") = Ds.Tables(0).Rows(0).Item("TPKGS")

            'DsFinal.Tables.Add(DataSetForm.Tables("TBdetails").Copy)
            'DsFinal.Tables(1).TableName = "Item"

            'Pcol(0) = DsFinal.Tables(0).Columns("BLNO")
            'cCol(0) = DsFinal.Tables(1).Columns("BLNO")
            'Rel = New DataRelation("BLDetail", Pcol, cCol)
            'DsFinal.Relations.Add(Rel)
            'FleName = "BLATCH"
            'FleName = RetriveObject(FleName, "C:\Temp\Temp")
            'DOC = New Document("C:\Temp\Temp")
            'doc.MailMerge.ExecuteWithRegions(DsFinal)
            'DOC.Save("c:\Temp\" & Me.BlNo.TextValue & "ATHC" & ".docx")
            'Process.Start("c:\Temp\doc.doc")
        Else
            Ds.Tables(0).TableName = "BL"
            Dr = Ds.Tables(0).Rows(0)
            If MsgBox("Do you want to edit data in tempalte ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                FrmTmpl = New FrmOutwardTempalte(Ds.Tables(0), Me.BLLineFormat.Value)
                FrmTmpl.Show()
            Else
                If ShowImage.Checked = True Then
                    'strart Remove to Change By Word
                    FleName = Me.BLLineFormat.Value & "-BL-IMAGE"
                    RetriveObject(FleName, "C:\Temp\Image.jpg")
                    Ds.Tables(0).Rows(0).Item("Image") = GetImageData("C:\Temp\Image.jpg")
                    FleName = Me.BLLineFormat.Value & "-BL-FORM"
                    Rpt = New CrystalDecisions.CrystalReports.Engine.ReportDocument 'RptTasa
                    RetriveObject(FleName, "C:\Temp\RPT.rpt")
                    Rpt.Load("C:\Temp\RPT.rpt")
                    Rpt.SetDataSource(Ds.Tables(0))
                    Frm.ReportViewer.ReportSource = Rpt
                    'End Remove to Change By Word
                    'FleName = Me.BLLineFormat.Value & "-BL-IMAGE"
                    'RetriveObject(FleName, "C:\Temp\Temp")
                    'DOC = New Document("C:\Temp\Temp")
                    'TableToArray(Ds.Tables(0), aField, aValue)
                    'DOC.MailMerge.Execute(aField, aValue)
                    'DOC.Save("c:\Temp\" & BlNo.TextValue & ".doc")
                    'Process.Start("c:\Temp\" & BlNo.TextValue & ".doc")
                Else
                    Rpt2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    FleName = Me.BLLineFormat.Value & "-BL-BLANK"
                    RetriveObject(FleName, "C:\Temp\RPT.rpt")
                    Rpt2.Load("C:\Temp\RPT.rpt")
                    Rpt2.SetDataSource(Ds.Tables(0))
                    Frm.ReportViewer.ReportSource = Rpt2
                    'FleName = Me.BLLineFormat.Value & "-BL-BLANK"
                    'RetriveObject(FleName, "C:\Temp\Temp")
                    'DOC = New Document("C:\Temp\Temp")
                    'TableToArray(Ds.Tables(0), aField, aValue)
                    'DOC.MailMerge.Execute(aField, aValue)
                    'DOC.Save("c:\Temp\" & BlNo.TextValue & ".doc")
                    'Process.Start("c:\Temp\" & BlNo.TextValue & ".doc")
                End If
                Frm.Show()
            End If
            Me.Close()
        End If


    End Sub

   


End Class
