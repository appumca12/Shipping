Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid
Imports System.Text

Public Class FrmPermitTools

    Private Ds As DataSet

    Private Sub FrmPermitTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Vessel.InitControl(Me.BackColor)
        Me.Voyage.InitControl(Me.BackColor, Me.Vessel)
        Me.GridPermits.UpdateMode = UpdateMode.OnCellChangeOrLostFocus
    End Sub

    Private Sub MenuItem_CustomDeSelectAll() Handles MenuItem.CustomDeSelectAll

        Dim GR As UltraGridRow

        For Each GR In GridPermits.Rows
            GR.Cells("Select").Value = False
        Next

    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        Dim ds As DataSet

        Dim Dr As DataRow
        If Me.Voyage.VoyageID.ToString Is Nothing Then
            Exit Sub
        End If

        ds = New DataSet
        ds = StoredProcedures.SP_ListOfPermitsByVoyage(CurrentShippingLine, Me.Voyage.VoyageID.ToString)

        Me.DataSetForm.Tables(0).Clear()
        For Each Dr In ds.Tables(0).Rows
            DataSetForm.Tables(0).ImportRow(Dr)
        Next

        With Me.GridPermits.DisplayLayout.Bands(0)
            .Columns("PermitID").Hidden = True
        End With

        If BtnCheckList.Checked = True Then
            GenCheckList()
        End If


    End Sub

    Private Sub MenuItem_CustomPrintClick() Handles MenuItem.CustomPrintClick

        Dim aRecs() As DataRow

        If Me.Voyage.VoyageID.ToString Is Nothing Then
            Exit Sub
        End If

        Me.GridPermits.Update()
        Me.GridPermits.UpdateData()
        Me.GridPermits.UpdateData()
        If Me.BtnManifest.Checked = True Then

            aRecs = DataSetForm.Tables(0).Select("Select = True")

            'If aRecs.Length = 0 Then
            '    MsgBox("No Any selection")
            '    Exit Sub
            'End If
            GenManifest(aRecs)
        Else
            If BtnLoadListFull.Checked = True Then
                GenLoadList("F")
            End If
            If BtnLoadListMty.Checked = True Then
                GenLoadList("E")
            End If
        End If
    End Sub

    Private Sub GenManifest(ByVal aRecs() As DataRow)

        Dim Frm As New FrmGeneralReportShow
        Dim Rpt As New RptExManifest
        Dim Mnf As CLPermitManifest
        Dim aList As New ArrayList
        Dim Dr As DataRow
        Dim PH As New CLPrintHdr
        Mnf = New CLPermitManifest
        If Not aRecs Is Nothing Then
            For Each Dr In aRecs
                aList.Add(Dr("PermitID").ToString)
            Next
            Mnf.GenerateMnf(Me.Voyage.VoyageID.ToString, aList)
        End If

        Mnf.GenEmptyManifest(Me.Voyage.VoyageID)
        If Mnf.Result.Rows.Count = 0 Then
            MsgBox("No Any Record !")
            Exit Sub
        End If
        Rpt.SetDataSource(Mnf.Result)
        '     Rpt.Subreports(0).SetDataSource(PH.ImageTable)
        Frm.ReportViewer.ReportSource = Rpt
        Frm.Show()

    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        Dim TCTS As New CLTctsMapLoad
        Me.GridPermits.Update()
        Me.GridPermits.UpdateData()
        If Me.EDI.Checked = True Then
            TCTS.SendToTctsLoadList(Me.Voyage.VoyageID, Me.DataSetForm.Tables(0))
        ElseIf Me.EDIXML.Checked = True Then
            GenEDIInXml()
        ElseIf Me.BtnMapDirect.Checked = True Then
            MapDirect()
        ElseIf Me.BtnMapDirectCCS.Checked = True Then
            MapDirect_CCS()
        Else
            MsgBox("Please Select A type of EDI")
        End If


    End Sub

    Private Sub MenuItem_CustomSelectAll() Handles MenuItem.CustomSelectAll

        Dim GR As UltraGridRow
        For Each GR In GridPermits.Rows
            GR.Cells("Select").Value = True
        Next

    End Sub

    Private Sub GenLoadList(FE As String)

        Dim Frm As New FrmGeneralReportShow
        Dim PH As New CLPrintHdr
        Dim sSql As String
        Dim Tb As New DataTable
        Dim lResult As Boolean
        Dim Rpt As PCLRptExpLoadList
        Dim Dr As DataRow
        Dim TempTB As New DataTable
        Dim Drs() As DataRow
        Dim CntrNo As String = ""
        Dim Seq As Byte
        Dim DataDr() As DataRow
        Dim ChgDr As DataRow
        Dim TTLGW As Double
        Dim TargetDr() As DataRow
        Dim aPrmt As New ArrayList

        Me.GridPermits.UpdateData()
        With TempTB
            .Columns.Add(New DataColumn("CntrNo", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("GW", System.Type.GetType("System.Double")))
        End With

        sSql = "SP_LoadListFullMtyByVoyageID '" & Me.Voyage.VoyageID.ToString & "'"
        TableBySql(sSql, Tb, lResult)

        For Each x As UltraGridRow In Me.GridPermits.Rows

            If x.Cells("Select").Value = True Then
                aPrmt.Add(x.Cells("PermitNo").Text)
            End If
        Next

        Tb.Columns.Add(New DataColumn("Count", System.Type.GetType("System.Int16")))
        Drs = Tb.Select("", "CntrNo")

        For Each Dr In Drs
             If FE = "F" Then
                If aPrmt.IndexOf(Dr("PermitNo")) = -1 Then
                    Dr.Delete()
                Else
                    If CntrNo <> Dr("CntrNo") Then
                        Seq = 0
                    End If
                    CntrNo = Dr("CntrNo")
                    Seq += 1
                    Dr("Count") = Seq
                End If
            End If
        Next

        Tb.AcceptChanges()
        Drs = Tb.Select("Count= 2", "CntrNo")

        For Each Dr In Drs
            TTLGW = 0
            DataDr = Tb.Select("CntrNo = '" & Dr("CntrNo") & "'")
            For Each ChgDr In DataDr
                TTLGW += NullToValue(ChgDr("GW"), 0)
            Next
            TargetDr = Tb.Select("CntrNo = '" & Dr("CntrNo") & "' and Count = 1")
            TargetDr(0).Item("GW") = TTLGW
        Next

        Drs = Tb.Select("Count > 1")
        For Each Dr In Drs
            Dr.Delete()
        Next
        Tb.AcceptChanges()

        For Each Dr In Tb.Rows
            If Dr("Status") = "EMPTY" Then
                Dr("GOODS") = "EMPTY CONTAINER"
            End If
            If NullToValue(Dr("TW"), 0) = 0 Then
                If Dr("CnSize") = "20" Then
                    Dr("TW") = 2200
                Else
                    Dr("TW") = 4500
                End If
            End If
            Dr("POT") = GetPortNameByCode(NullToValue(Dr("POT"), ""))
        Next

        For Each Dr In Tb.Rows
            If FE = "F" Then
                If Dr("Status") = "EMPTY" Then
                    Dr.Delete()
                End If
            Else
                If Dr("Status") <> "EMPTY" Then
                    Dr.Delete()
                End If
            End If
       Next

        Tb.AcceptChanges()


        If lResult = True Then
            Rpt = New PCLRptExpLoadList
            'Rpt.Subreports("RptHedaerLogo.rpt").SetDataSource(PH.ImageTable)
            Rpt.SetDataSource(Tb)
            Frm.ReportViewer.ReportSource = Rpt
            Frm.Text = "Load List"
            Frm.Show()
        End If

    End Sub

    Private Sub GenCheckList()

        Dim ssql As String
        Dim Tb As New DataTable
        Dim lResult As Boolean
        Dim DR As DataRow

        ssql = "SP_CheckExitCntrsForPermits '" & Me.Voyage.VoyageID.ToString & "'"
        TableBySql(ssql, Tb, lResult)
        If lResult = True Then
            Tb.Columns.Add(New DataColumn("DPDate"))
            For Each DR In Tb.Rows
                If Not IsDBNull(DR("Saild")) Then
                    DR("DPDate") = ToPersianDate(DR("Saild"))
                End If
            Next
            Me.GridCheckList.DataSource = Tb
            Me.UltraTabControl1.Tabs(1).Selected = True
            With Me.GridCheckList.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Djwaz Check List For Vessel:" & Me.Vessel.VesselName & " Voyage:" & Me.Voyage.CmbVoyage.Text
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
        End If


    End Sub
    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick

        If Me.UltraTabControl1.SelectedTab.Text = "List Of Permits" Then
            If Me.GridPermits.Rows.Count > 0 Then
                SaveGridToExcel(Me.GridPermits)
            End If
        Else
            If Me.GridCheckList.Rows.Count > 0 Then
                SaveGridToExcel(Me.GridCheckList)
            End If

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TCTS As New CLTctsMapLoad
        TCTS.SendToTctsLoadListFromOutward(Me.Voyage.VoyageID, Me.DataSetForm.Tables(0))
    End Sub



    Public Function GenEDIInXml() As String

        Dim Dm As DataManager
        Dim SB As New StringBuilder
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim TTLGW As Double
        Dim CoName As String
        Dim MainLine As String
        Dim PkgCode As String

        Dim Prm As TB_Permits
        Dim Cns As TB_PermitDetailsCollection
        Dim Cn As TB_PermitDetails
        Dim Codes As TB_CODECollection

        Dim Eqc As TB_EcsContainers
        Dim sSql As String
        Dim TBTW As DataTable = New DataTable
        Dim lResult As Boolean

        Dim SaveDialog As SaveFileDialog
 
        SaveDialog = New SaveFileDialog
        SaveDialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*"
        SaveDialog.ShowDialog()

        Dm = New DataManager(My.Settings.DSN)
        Dm.GetTB_Company()
        CoName = Dm.DataSet.Tables("TB_Company").Rows(0).Item("CompanyName")

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Dm.GetTB_Lines()
        MainLine = Dm.DataSet.Tables("TB_Lines").Rows(0).Item("LineName")

        InitDsXml()

        SB.Append("<?xml version=" & """" & "1.0" & """" & " standalone=" & """" & "yes" & """" & "?>")
        SB.Append("<Manifest>")

        For Each Dr In DataSetForm.Tables(0).Rows
            '          Try
            If Dr("Select") = True Then
                TTLGW = 0
                Dm = New DataManager(My.Settings.DSN)

                Dm.QueryCriteria.And(JoinPath.TB_Permits.Columns.PermitNo, Dr("PermitNo"), MatchType.Exact)
                Prm = Dm.GetTB_Permits

                If Not Prm Is Nothing Then
                    NewDr = Ds.Tables(0).NewRow
                    NewDr("BlNO") = CurrentShippingLine & Prm.PermitNo
                    NewDr("FK_POL") = "IRBND"
                    NewDr("FK_POD") = Prm.FPOD
                    NewDr("FK_PlaceOfIssue") = "IRBND"
                    NewDr("FK_OriginPort") = "IRBND"
                    NewDr("FK_DestinationPort") = Prm.FPOD
                    NewDr("FK_POT") = Prm.POT
                    NewDr("IsDirectDelivery") = False
                    NewDr("IssueDate") = Format(Now, "yyyy/MM/dd hh:mm")
                    NewDr("SailedDate") = Format(Now, "yyyy/MM/dd hh:mm")
                    NewDr("FK_ShipmentType") = NewTCTSShipmentType(Prm.Status)

                    NewDr("GoodsDesc") = CleanStr(UCase(Prm.Goods))
                    NewDr("Consignee") = CleanStr(UCase(MainLine))
                    NewDr("Shipper") = CoName
                    NewDr("Notify") = CleanStr(UCase(MainLine))

                    Ds.Tables(0).Rows.Add(NewDr)
                    SB.Append("<BL>")
                    SB.Append(DataRowToXml(NewDr))
                    SB.Append("<Containers>")

                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_PermitDetails.Columns.PermitID, Prm.ID, MatchType.Exact)
                    Cns = Dm.GetTB_PermitDetailsCollection

                    For Each Cn In Cns
                        Dm.QueryCriteria.Clear()
                        Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, Cn.CntrID, MatchType.Exact)
                        Eqc = Dm.GetTB_EcsContainers
                        NewDr = Ds.Tables(1).NewRow
                        NewDr("ContainerNo") = Eqc.CntrNo
                        NewDr("SealNo") = CleanStr(UCase(Cn.SealNo))
                        NewDr("Status") = IIf(Cn.FLE = "E", 0, 1)
                        NewDr("FK_ContainerSize") = TCTSCnSize(Eqc.CnSize)
                        NewDr("FK_ContainerType") = TCTSCnType(Eqc.CnType)
                        sSql = "select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Eqc.InVoyageID.ToString & "' , '" & Eqc.CntrNo & "')"
                        TableBySql(sSql, TBTW, lResult)
                        If lResult = True Then
                            If TBTW.Rows.Count > 0 Then
                                NewDr("TareWeight") = NullToValue(TBTW.Rows(0).Item(0), "")
                            Else
                                If Eqc.CnSize = "20" Then
                                    NewDr("TareWeight") = "2200"
                                Else
                                    NewDr("TareWeight") = "4200"
                                End If
                            End If
                        End If
                        NewDr("ISLCL") = IIf(Cn.FLE = "L", 1, 0)
                        NewDr("GrossWeight") = Double.Parse(Cn.GW)
                        NewDr("ISSOC") = 0
                        NewDr("ISOG") = 0
                        If NullToValue(Prm.IMDGCode, "") <> "" Then
                            NewDr("FK_IMDGClass") = NullToValue(Prm.IMDGCode, "")
                            NewDr("FlashPoint") = NullToValue(Prm.FlashPoint, "")
                            NewDr("PageNo") = NullToValue(Prm.PageNumber, "")
                            NewDr("IsDG") = 1
                        Else
                            NewDr("IsDG") = 0
                        End If
                        Dm.QueryCriteria.Clear()
                        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PG", MatchType.Exact)
                        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, Cn.PackageType, MatchType.Exact)
                        Codes = Dm.GetTB_CODECollection
                        PkgCode = "PG"
                        If Not Codes Is Nothing Then
                            If Codes.Count > 0 Then
                                PkgCode = Codes(0).NextCode
                            End If
                        End If
                        NewDr("FK_PacakgeType") = PkgCode
                        NewDr("NoPackage") = Cn.NoOFPkgs.ToString
                        Ds.Tables(1).Rows.Add(NewDr)
                        SB.Append("<Container>")
                        SB.Append(DataRowToXml(NewDr))
                        SB.Append("</Container>")
                    Next
                    SB.Append("</Containers>")
                    SB.Append("</BL>")
                End If
            End If


            'Catch ex As Exception
            '    MsgBox("Error On B/L Number " & Prm.PermitNo, MsgBoxStyle.Critical)
            '    MsgBox(ex.ToString)
            'End Try

        Next
        GenEmptyXml(Ds, SB)
        SB.Append("</Manifest>")

        Dim Output As New IO.StreamWriter(SaveDialog.FileName)
        Output.Write(SB.ToString)
        Output.Flush()
        Output.Close()

        MsgBox("Generate Sucsess")


        Return SB.ToString

    End Function

    Public Sub GenEmptyXml(ByRef DsXml As DataSet, ByRef SB As StringBuilder)


        Dim VoyageID As Guid = Me.Voyage.VoyageID
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
        Dim nSeq As Byte
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

                NewDr = DsXml.Tables(0).NewRow
                NewDr("BlNO") = BLNo
                NewDr("FK_POL") = "IRBND"
                NewDr("FK_POD") = Port
                NewDr("FK_PlaceOfIssue") = "IRBND"
                NewDr("FK_OriginPort") = "IRBND"
                NewDr("FK_DestinationPort") = Port
                NewDr("FK_POT") = Port
                NewDr("IsDirectDelivery") = False
                NewDr("IssueDate") = Format(Now, "yyyy/MM/dd hh:mm")
                NewDr("SailedDate") = Format(Now, "yyyy/MM/dd hh:mm")
                NewDr("FK_ShipmentType") = 1

                NewDr("GoodsDesc") = CleanStr(UCase(sgoods))
                NewDr("Consignee") = CleanStr(UCase(MainLine))
                NewDr("Shipper") = CoName
                NewDr("Notify") = CleanStr(UCase(MainLine))

                DsXml.Tables(0).Rows.Add(NewDr)
                SB.Append("<BL>")
                SB.Append(DataRowToXml(NewDr))
                SB.Append("<Containers>")

                TempDrs = TBTemp.Select("Port = '" & Port & "'")

                For Each TempDr In TempDrs
                    Drs = Dm.DataSet.Tables("TB_EcsContainers").Select("ID = '" & TempDr("ID").ToString & "'", "")
                    DrsMove = Dm.DataSet.Tables("TB_EcsMoves").Select("CntrID = '" & TempDr("ID").ToString & "'")
                    If Drs.Length > 0 Then
                        Dr = Drs(0)
                        NewDr = DsXml.Tables(1).NewRow
                        NewDr("ContainerNo") = Dr("CntrNo")
                        NewDr("SealNo") = ""
                        NewDr("Status") = 0
                        NewDr("FK_ContainerSize") = TCTSCnSize(Dr("CnSize"))
                        NewDr("FK_ContainerType") = TCTSCnType(Dr("CnType"))
                        ssql = "select dbo.FC_GetInwardCnsTWByVoyageCntr('" & Dr("InVoyageID").ToString & "' , '" & Dr("CntrNo") & "')"
                        TableBySql(ssql, TbTw, lResult)
                        If lResult = True Then
                            If TbTw.Rows.Count > 0 And Not NullToValue(TbTw.Rows(0).Item(0), "") = "" Then
                                NewDr("TareWeight") = NullToValue(TbTw.Rows(0).Item(0), "")
                            Else
                                If Dr("CnSize") = "20" Then
                                    NewDr("TareWeight") = "2200"
                                Else
                                    NewDr("TareWeight") = "4200"
                                End If
                            End If
                        End If
                        NewDr("ISLCL") = 0
                        NewDr("GrossWeight") = 0
                        NewDr("ISSOC") = 0
                        NewDr("ISOG") = 0
                        NewDr("IsDG") = 0
                        NewDr("FK_PacakgeType") = "PK"
                        NewDr("NoPackage") = 1
                        DsXml.Tables(1).Rows.Add(NewDr)
                        SB.Append("<Container>")
                        SB.Append(DataRowToXml(NewDr))
                        SB.Append("</Container>")

                    End If
                Next
                SB.Append("</Containers>")
                SB.Append("</BL>")
            Next
        End If
    End Sub


    Private Sub InitDsXml()

        Dim Tb As DataTable

        Ds = New DataSet
        Tb = New DataTable("BL")

        Tb.Columns.Add(New DataColumn("BLNO"))
        Tb.Columns.Add(New DataColumn("Consignee"))
        Tb.Columns.Add(New DataColumn("Shipper"))
        Tb.Columns.Add(New DataColumn("GoodsDesc"))
        Tb.Columns.Add(New DataColumn("IsDirectDelivery", System.Type.GetType("System.Boolean")))
        Tb.Columns.Add(New DataColumn("FK_POL", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("FK_POD", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("FK_PlaceOfIssue", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("FK_OriginPort", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("FK_DestinationPort", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Remark", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("IssueDate", System.Type.GetType("System.DateTime")))
        Tb.Columns.Add(New DataColumn("SailedDate", System.Type.GetType("System.DateTime")))
        Tb.Columns.Add(New DataColumn("FK_POT", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("TemporaryCustomPermission", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("FK_ShipmentType", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Notify", System.Type.GetType("System.String")))
        DS.Tables.Add(Tb)


        Tb = New DataTable("Containers")
        Tb.Columns.Add(New DataColumn("ContainerNo"))
        Tb.Columns.Add(New DataColumn("NoPackage", System.Type.GetType("System.Int32")))
        Tb.Columns.Add(New DataColumn("Status"))
        Tb.Columns.Add(New DataColumn("FK_IMDGClass"))
        Tb.Columns.Add(New DataColumn("FlashPoint"))
        Tb.Columns.Add(New DataColumn("PageNo"))
        Tb.Columns.Add(New DataColumn("RFTemp"))
        Tb.Columns.Add(New DataColumn("SealNo"))
        Tb.Columns.Add(New DataColumn("CargoVolume", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("GrossWeight", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("FK_PacakgeType"))
        Tb.Columns.Add(New DataColumn("FK_ContainerSize"))
        Tb.Columns.Add(New DataColumn("FK_ContainerType"))
        Tb.Columns.Add(New DataColumn("IsSOC"))
        Tb.Columns.Add(New DataColumn("TareWeight"))
        Tb.Columns.Add(New DataColumn("IsLCL"))
        Tb.Columns.Add(New DataColumn("IsDG"))
        Tb.Columns.Add(New DataColumn("IsOG"))
        DS.Tables.Add(Tb)

    End Sub

    Private Function DataRowToXml(ByVal dr As DataRow) As String


        Dim SB As New StringBuilder
        Dim Col As DataColumn
        Dim ColName As String

        For Each Col In dr.Table.Columns
            ColName = Col.ColumnName
            SB.Append("<" & ColName & ">" & NullToValue(dr(ColName), "").ToString & "</" & ColName & ">")
        Next
        Return SB.ToString

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

    Private Function TCTSCnSize(ByVal CnSize As String) As String

        Select Case CnSize
            Case "20"
                Return "2"
            Case "40"
                Return "4"
            Case "45"
                Return "9"
            Case Else
                Return CnSize
        End Select


    End Function

    Private Function TCTSCnType(ByVal CnType As String) As String

        Select Case CnType

            Case "FC"
                Return "260"
            Case "FO"
                Return "250"
            Case "FR"
                Return "250"
            Case "RF"
                Return "230"
            Case "RH"
                Return "530"
            Case "RS"
                Return "230"
            Case "SD"
                Return "200"
            Case "SG"
                Return "200"
            Case "SH"
                Return "500"
            Case "HC"
                Return "500"
            Case "TK"
                Return "270"
            Case "HD"
                Return "200"
            Case "OT"
                Return "250"
            Case "FR"
                Return "260"
            Case Else
                Return "200"
        End Select

    End Function

    Private Function NewTCTSShipmentType(ByVal sType As String) As String

        Select Case sType
            Case "0"
                Return "0"
            Case "1"
                Return "3"
            Case "2"
                Return "6"
            Case "3"
                Return "2"
            Case "4"
                Return "1"
            Case "5"
                Return "5"
            Case "6"
                Return "4"
            Case "7"
                Return "7"
            Case Else
                Return sType
        End Select

    End Function

    Private Sub GridPermits_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridPermits.InitializeLayout
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.Default
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub GridCheckList_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridCheckList.InitializeLayout
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.Default
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub MapDirect()
        Dim CL As New CLEditTextFormat(Me.Voyage.VoyageID)
        Dim Row As UltraGridRow

        For Each Row In Me.GridPermits.Rows
            If Row.Cells("Select").Value = True Then
                CL.GenEDITextFormatByPermit(Row.Cells("PermitNo").Value)
            End If
        Next
        CL.GenEDITextFormatMtyCntrs(Me.Voyage.VoyageID)

        CL.SaveData()
    End Sub

    Private Sub MapDirect_CCS()
        Dim CL As New CLEditTextFormat(Me.Voyage.VoyageID, "CCS")
        Dim Row As UltraGridRow

        For Each Row In Me.GridPermits.Rows
            If Row.Cells("Select").Value = True Then
                CL.GenEDITextFormatByPermit_CCS(Row.Cells("PermitNo").Value)
            End If
        Next
        CL.GenEDITextFormatMtyCntrs_CCS(Me.Voyage.VoyageID)

        CL.SaveData()
    End Sub


End Class