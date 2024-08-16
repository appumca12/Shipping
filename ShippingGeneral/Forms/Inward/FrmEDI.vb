Imports OrmLib
Imports ShippingBiz
Imports System.Data.OleDb
Imports Infragistics.Win.UltraWinGrid
Public Class FrmEDI

    Public WithEvents XMLE As XMLEDI
    Private Tb As DataTable
    Private nLast As Long
    Private EdiCnn As New OleDb.OleDbConnection
    Private DaTCTS As New OleDb.OleDbDataAdapter
    Private BDTcts As New OleDb.OleDbCommandBuilder
    Private DsTcts As New DataSet

    Private ADVoy As New OleDbDataAdapter()
    Private CbVoy As New OleDbCommandBuilder

    Private ADBLCns As New OleDbDataAdapter()
    Private CBBLCns As New OleDbCommandBuilder()

    Private ADCns As New OleDbDataAdapter()
    Private CBCns As New OleDbCommandBuilder()

    Private ADBls As New OleDbDataAdapter()
    Private CBBls As New OleDbCommandBuilder()

    Private Dm As DataManager

    Private Bls As TB_InwardBLS
    Private Cns As New TB_InwardCntrsCollection
    Private Cn As TB_InwardCntrs
    Private Goods As TB_InwardBlsGoods
    Private Names As TB_InwardBlsNames
    Private Imco As TB_InwardCnsImcoCollection

    Private Sub FrmEDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.FVoyage.InitControl(Me.BackColor, Me.FVessel)
        Me.FVessel.InitControl(Me.BackColor)
        Me.FileDialog.Filter = "Database File (*.mdb)|*.mdb"
        Me.OptionSet.Items(0).CheckState = CheckState.Checked

    End Sub
    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click
        Call SetDocument()
    End Sub

    Private Sub SetDocument()

        Dim dm As New DataManager(My.Settings.DSN)
        Dim Ds As New DataSet
        Ds = StoredProcedures.SP_InwardBlsGenralListByVoyageID(CurrentShippingLine, Me.FVoyage.VoyageID.ToString)
        For Each dr As DataRow In Ds.Tables(0).Rows
            dr("Select") = True
        Next
        PopulateGrid(Ds.Tables(0), "")

    End Sub

    Private Sub PopulateGrid(ByVal TempTb As DataTable, ByVal Header As String)

        Dim Col As DataColumn
        Dim GC As Infragistics.Win.UltraWinGrid.UltraGridColumn

        Tb = New DataTable
        Tb = TempTb.Copy

        With Me.GridResult
            .DisplayLayout.ResetBands()
            .DataSource = Tb
        End With

        For Each Col In Tb.Columns
            If Col.DataType.Name = "Decimal" Then
                GridResult.DisplayLayout.Bands(0).Columns(Col.ColumnName).Format = "#,###.00"
                GridResult.DisplayLayout.Bands(0).Columns(Col.ColumnName).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double
                GridResult.DisplayLayout.Bands(0).Columns(Col.ColumnName).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            End If
        Next

        With Me.GridResult
            .DisplayLayout.Bands(0).HeaderVisible = True
            .DisplayLayout.Bands(0).Header.Caption = Header
            .DisplayLayout.Bands(0).Columns("Select").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        End With

        For Each GC In Me.GridResult.DisplayLayout.Bands(0).Columns
            GC.Hidden = True
        Next

        With Me.GridResult.DisplayLayout.Bands(0)
            .Columns("Line").Hidden = False
            .Columns("BlNo").Hidden = False
            .Columns("Client").Hidden = False
            .Columns("POL").Hidden = False
            .Columns("POD").Hidden = False
            .Columns("Total20").Hidden = False
            .Columns("Total40").Hidden = False
            .Columns("Total45").Hidden = False
            .Columns("Select").Hidden = False
            .Columns("SOC").Hidden = False
            .Columns("SOCBox").Hidden = False
            .Columns("COCBox").Hidden = False
            .Columns("POLTerm").Hidden = False
            .Columns("PODTerm").Hidden = False
            .Columns("ClientID").Hidden = True
        End With

    End Sub

    Private Sub ButtonMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMap.Click

        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If

        If GetUserConfigItem("TCTSDB") = "" Then
            MsgBoxGeneral("Plesae Co Checking First !", "Checking Requrid")
            Exit Sub
        End If
        GenTCTSEdi()
    End Sub
    Private Function EdiCntrFormat(ByVal sCntr As String)

        Dim nI As Byte
        Dim nChr As Long
        Dim Pfx As String = ""
        Dim sFx As String = ""
        Dim ChkDgt As String

        sCntr = Trim(UCase(sCntr))

        If Len(sCntr) = 11 Then
            EdiCntrFormat = Microsoft.VisualBasic.Left(sCntr, 4) & " " & Mid(sCntr, 5, 6) & "-" & Microsoft.VisualBasic.Right(sCntr, 1)
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
                Pfx = Microsoft.VisualBasic.Left(Pfx, 4)
            End If

            If Len(sCntr) > 4 Then
                sFx = sFx & Mid(sCntr, 5)
            End If
            If Len(sFx) < 7 Then
                sFx = Space(7 - Len(sFx)) & sFx
            End If

            ChkDgt = Microsoft.VisualBasic.Right(sFx, 1)
            sFx = Microsoft.VisualBasic.Left(sFx, Len(sFx) - 1)

            If Pfx = "" Then
                Pfx = "NILL"
            End If

            Return Pfx & " " & sFx & "-" & ChkDgt

        End If

    End Function


    Public Sub GenTCTSEdi()

        Dim Co As TB_Company
        Dim Line As TB_Lines
        Dim Vsl As TB_Vessels

        Dim SOFs As TB_SOFCollection
        Dim VOY As TB_Voyage
        Dim Code As TB_CODE
        Dim ds As New DataSet

        Dim aTables() As String = {"TB_InwardBls", "Tb_InwardBlsNames", "TB_InwardBlsGoods", "TB_InwardCharges", "Tb_InwardCntrs", "TB_InwardCnsImco", "TB_InwardCnsTemprature", "TB_InwardCnsPkgs"}
        Dim sSql As String
        Dim lResult As Boolean

        Dim SelTable As New DataTable
        Dim TVessel As New DataTable
        Dim Tmp As New DataTable
        Dim NewDr As DataRow
        Dim Dr As DataRow
        Dim nI As Int16
        Dim TTLGW As Double = 0
        Dim TTLPkgs As Long
        Dim PkgCode As String = ""
        Dim Crt As String
        Dim Dv As DataView

        Dim TctsVslcode As String
        Dim aErrorList As New ArrayList
        Dim DummyImco As TB_InwardCnsImco

        Dim TBSOCBL As DataTable
        Dim TBSOCCntr As DataTable


        Dim TBSOC As New DataTable
        Dim DrsSOC() As DataRow
        Dim xDr As DataRow
        Dim DrSoc As DataRow
        Dim Drs() As DataRow
        Dim ColName As String

        Dv = New DataView(Me.GridResult.DataSource, "Select = 1", "", DataViewRowState.CurrentRows)
        Me.ProgressBar.Maximum = Dv.Count
        Me.ProgressBar.Value = 0
        If Dv.Count = 0 Then
            MsgBoxGeneral("No Any Selection !", "Data Requird")
            Exit Sub
        End If


        SelTable = Me.GridResult.DataSource
        EdiCnn = New OleDb.OleDbConnection
        EdiCnn.ConnectionString = My.Settings.TctsCnn '  "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & My.Settings.TctsCnn
        EdiCnn.Open()

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Me.FVoyage.VoyageID, MatchType.Exact)
        VOY = Dm.GetTB_Voyage

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Me.FVoyage.VoyageID, MatchType.Exact)
        SOFs = Dm.GetTB_SOFCollection

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, VOY.VesselID, MatchType.Exact)
        Vsl = Dm.GetTB_Vessels

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Line = Dm.GetTB_Lines

        Dm.QueryCriteria.Clear()
        Co = Dm.GetTB_Company

        sSql = "Select * From TbKeshti Where TName = '" & Vsl.VesselName & "'"
        GetEdiTable(sSql, TVessel, lResult)

        If lResult = False Then
            MsgBox("Invalid Vessel Name in TCTS !", MsgBoxStyle.Critical)
            Exit Sub
        End If

        TctsVslcode = TVessel.Rows(0).Item("Code")


        ExecuteSqlOnTcts("delete * From TbMVoyageID Where TripNo = '" & VOY.VoyageNo & "'")

        GetEdiTable("select Max(ManiFestCode) From TbMVoyageID", Tmp, lResult)

        If lResult = True Then
            nLast = 0
        Else
            nLast = Tmp.Rows(0).Item(0)
        End If

        Me.ProgressBar.Visible = True
        nLast = nLast + 1

        EdiCnn.Close()
        InitDaTcts(VOY.VoyageNo)

        NewDr = DsTcts.Tables("TbMVoyageID").NewRow
        NewDr("MYEAR") = Mid(ToPersianDate(Date.Today), 3, 2)
        NewDr("KeshtiCode") = TVessel.Rows(0).Item("Code")
        NewDr("TripNo") = VOY.VoyageNo
        NewDr("POL") = "AE DXB"
        NewDr("POD") = "IR BND"
        NewDr("ArrivalDate") = Date.Today
        NewDr("DepartureDate") = Date.Today
        NewDr("ManiFestCode") = nLast
        NewDr("VesselAgent") = Line.EDICode ' Co.EDICode
        NewDr("BarnamehNoIn") = ""
        DsTcts.Tables("TbMVoyageID").Rows.Add(NewDr)
        ADVoy.Update(DsTcts, "TbMVoyageID")

        sSql = "delete * from TbKeshtiInput where tripno = '" & VOY.VoyageNo & "'"
        ExecuteSqlOnTcts(sSql)

        sSql = "Insert Into TbKeshtiInput (MYear , KeshtiCode , TripNo , ETA) values ('" & Mid(ToPersianDate(Date.Today), 3, 2) & "' , '" & TctsVslcode & "' , '" & VOY.VoyageNo & "' , #" & Format(Now, "Short Date") & "#)"
        ExecuteSqlOnTcts(sSql)

        For Each Dr In SelTable.Rows
            Try
                If Dr("Select") = 1 Then

                    Dm = New DataManager(My.Settings.DSN)
                    ds = StoredProcedures.SP_InwardAllDataByLineBlNo(CurrentShippingLine, Dr("BLNo"))
                    Dm.PopulateObjectsFromDataSet(ds, aTables)

                    For nI = 0 To aTables.Length - 1
                        Dm.DataSet.Tables(aTables(nI)).Merge(ds.Tables(nI))
                    Next

                    If Dm.DataSet.Tables("TB_InwardBls").Rows.Count > 0 Then
                        Bls = Dm.GetTB_InwardBLSCollectionFromDataSet(0)
                        Cns = Dm.GetTB_InwardCntrsCollectionFromDataSet
                        Names = Dm.GetTB_InwardBlsNamesCollectionFromDataSet(0)
                        Goods = Dm.GetTB_InwardBlsGoodsCollectionFromDataSet(0)
                        Imco = Dm.GetTB_InwardCnsImcoCollection
                        TTLGW = 0
                        PkgCode = "PK"
                        Dm.QueryCriteria.Clear()
                        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PG", MatchType.Exact)
                        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, Cns(0).PackageType, MatchType.Exact)
                        Code = Dm.GetTB_CODE
                        If Not Code Is Nothing Then
                            PkgCode = Code.NextCode
                        End If
                    End If

                    Dv = New DataView(DsTcts.Tables("TbMBL"), "BlNumber = '" & Bls.BlNo & "'", "", DataViewRowState.CurrentRows)
                    If Dv.Count > 0 Then
                        Dv.Item(0).Delete()
                    End If
                    NewDr = DsTcts.Tables("TbMBL").NewRow
                    NewDr("MYEAR") = DsTcts.Tables("TbMVoyageID").Rows(0).Item("MYEAR")
                    NewDr("KeshtiCode") = DsTcts.Tables("TbMVoyageID").Rows(0).Item("KeshtiCode")
                    NewDr("TripNo") = DsTcts.Tables("TbMVoyageID").Rows(0).Item("TripNo")
                    NewDr("BlNumber") = Bls.BlNo
                    NewDr("TypeOfPackage") = PkgCode
                    NewDr("BLCODE") = 0 ' nCount

                    If Not Goods Is Nothing Then
                        NewDr("GrossWeight") = Double.Parse(Goods.TGW)
                        NewDr("NoOfPackage") = Int32.Parse(Goods.TTLPkgs)
                        NewDr("GoodDescription") = CleanStr(UCase(Goods.Goods))
                    End If

                    If Not Names Is Nothing Then
                        NewDr("Consignee") = Mid(CleanStr(UCase(Names.Cnee)), 1, 130)
                        NewDr("Consignor") = "Gest"
                        NewDr("Notify") = Mid(CleanStr(UCase(Names.Notify1)), 1, 130)
                    End If

                    DsTcts.Tables("TbMBL").Rows.Add(NewDr)
                    Crt = "MYEAR = '" & DsTcts.Tables("TbMVoyageID").Rows(0).Item("MYEAR") & _
                        "' and KeshtiCode = '" & DsTcts.Tables("TbMVoyageID").Rows(0).Item("KeshtiCode") & _
                        "' and TripNo = '" & DsTcts.Tables("TbMVoyageID").Rows(0).Item("TripNo") & "'"
                    TTLPkgs = 0
                    For Each Cn In Cns
                        Dv = New DataView(DsTcts.Tables("TbMContainer"), Crt & " and ConFlag = '" & CntrFormat(Cn.CntrNo) & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count = 0 Then
                            NewDr = DsTcts.Tables("TbMContainer").NewRow
                            NewDr("MYEAR") = DsTcts.Tables("TbMVoyageID").Rows(0).Item("MYEAR")
                            NewDr("KeshtiCode") = DsTcts.Tables("TbMVoyageID").Rows(0).Item("KeshtiCode")
                            NewDr("TripNo") = DsTcts.Tables("TbMVoyageID").Rows(0).Item("TripNo")
                            NewDr("ConFlag") = CntrFormat(Cn.CntrNo)
                            NewDr("SealNumber") = Mid(CleanStr(UCase(Cn.SealNo)), 1, 10)
                            NewDr("CSize") = Cn.CnSize
                            NewDr("CType") = OurTypeToTCTSIP(Cn.CnType)
                            NewDr("NoeInput") = Bls.BLStatus
                            ' Change for SOC containers
                            If Cn.SOC = "Y" Then
                                NewDr("MovementType") = 2
                                DrSOC = TBSOC.NewRow
                                DrSOC("BLNO") = Bls.BlNo
                                DrSOC("CntrNo") = Cn.CntrNo
                                DrSOC("TW") = Int64.Parse(Cn.TW)
                                TBSOC.Rows.Add(DrSOC)
                            Else
                                NewDr("MovementType") = IIf(Cn.FLE = "L", 2, 3)
                            End If
                            NewDr("F_E") = IIf(Cn.FLE = "E", False, True)
                            NewDr("MovementType") = IIf(Cn.FLE = "L", 2, 3)
                            NewDr("POL") = GetEDIPORT(NullToValue(Bls.POL, "")) '    Mid(Bls.POL, 1, 2) & " " & Mid(Bls.POL, 3)
                            NewDr("POT") = GetEDIPORT(NullToValue(Bls.POT, "")) ' Mid(Bls.POT, 1, 2) & " " & Mid(Bls.POT, 3)
                            NewDr("TareWeight") = Int32.Parse(Cn.TW)
                            NewDr("ContainerOwner") = Co.EDICODE ' Line.EDICode
                            NewDr("ContainerAgent") = Line.EDICode ' Co.EDICODE
                            NewDr("HazardVersion") = ""
                            NewDr("HazardPageNumber") = ""
                            NewDr("EquipmentFlashPoint") = 0
                            NewDr("FPMeasureUnit") = 0
                            NewDr("PackingGroupCode") = ""
                            NewDr("TFlag") = False
                            NewDr("TypeLCL") = ""
                            NewDr("DamageAva") = False
                            DummyImco = Imco.FindByCntrID(Cn.ID)
                            If Not DummyImco Is Nothing Then
                                NewDr("IMDGCode") = DummyImco.IMDGCode
                            End If
                            DsTcts.Tables("TbMContainer").Rows.Add(NewDr)
                        End If
                        NewDr = DsTcts.Tables("TbMBLContainer").NewRow
                        NewDr("MYEAR") = DsTcts.Tables("TbMVoyageID").Rows(0).Item("MYEAR")
                        NewDr("KeshtiCode") = DsTcts.Tables("TbMVoyageID").Rows(0).Item("KeshtiCode")
                        NewDr("TripNo") = DsTcts.Tables("TbMVoyageID").Rows(0).Item("TripNo")
                        NewDr("ConFlag") = CntrFormat(Cn.CntrNo)
                        NewDr("BlNumber") = Bls.BlNo
                        NewDr("NetWeight") = Double.Parse(Cn.GW)
                        TTLGW += Cn.GW
                        NewDr("Strip") = ""
                        TTLPkgs = TTLPkgs + Cn.NoOFPkgs
                        NewDr("NoOfPackage") = Int32.Parse(Cn.NoOFPkgs.ToString)
                        DsTcts.Tables("TbMBLContainer").Rows.Add(NewDr)
                        Dv = New DataView(DsTcts.Tables("TbMBL"), "BlNumber = '" & Bls.BlNo & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            Dv.Item(0).Item("GrossWeight") = Format(TTLGW, ".00")
                        End If
                    Next

                    If TBSOC.Rows.Count > 0 Then

                        Drs = DsTcts.Tables("TbMBL").Select("BlNumber = '" & TBSOC.Rows(0).Item("BlNo") & "'")
                        TTLGW = 0
                        For Each mDr As DataRow In TBSOC.Rows
                            TTLGW += mDr("TW")
                        Next
                        Drs = DsTcts.Tables("TbMBL").Select("BlNumber = '" & TBSOC.Rows(0).Item("BlNo") & "'")
                        If Drs.Length > 0 Then
                            TBSOCBL = DsTcts.Tables("TbMBL").Copy
                            TBSOCBL.Clear()
                            TBSOCBL.AcceptChanges()
                            NewDr = DsTcts.Tables("TbMBL").NewRow
                            For Each col As DataColumn In Drs(0).Table.Columns
                                ColName = col.ColumnName
                                NewDr(ColName) = Drs(0).Item(ColName)
                            Next
                            NewDr("BlNumber") = NewDr("BlNumber") & "-A"
                            NewDr("GrossWeight") = TTLGW
                            NewDr("NoOfPackage") = 1
                            NewDr("TypeOfPackage") = "CBL"
                            NewDr("GoodDescription") = "EMPTY CONTAINER"
                            DsTcts.Tables("TbMBL").Rows.Add(NewDr)
                            For Each xDr In TBSOC.Rows
                                Drs = DsTcts.Tables("TbMBLContainer").Select("BlNumber = '" & xDr("BLNO") & "' and ConFlag = '" & CntrFormat(xDr("CntrNo")) & "'")
                                If Drs.Length > 0 Then
                                    TBSOCCntr = DsTcts.Tables("TbMBLContainer").Copy
                                    TBSOCCntr.Clear()
                                    TBSOCCntr.AcceptChanges()
                                    NewDr = DsTcts.Tables("TbMBLContainer").NewRow
                                    For Each col As DataColumn In Drs(0).Table.Columns
                                        ColName = col.ColumnName
                                        NewDr(ColName) = Drs(0).Item(ColName)
                                    Next
                                    NewDr("BlNumber") = NewDr("BlNumber") & "-A"
                                    NewDr("NetWeight") = Int32.Parse(xDr("TW"))
                                    NewDr("NoOfPackage") = 1
                                    DsTcts.Tables("TbMBLContainer").Rows.Add(NewDr)
                                End If
                            Next
                        End If
                    End If
                    ADBls.Update(DsTcts, "TbMBL")
                    ADCns.Update(DsTcts, "TbMContainer")
                    ADBLCns.Update(DsTcts, "TbMBLContainer")
                    Me.ProgressBar.Value += 1
                    Me.Refresh()
                Else
                    Beep()
                End If

            Catch ex As Exception
                aErrorList.Add(Dr("BlNo"))
                MsgBox("Error On B/L Number " & Dr("BlNo"), MsgBoxStyle.Critical)
                MsgBox(ex.ToString)
            End Try

        Next

        If aErrorList.Count = 0 Then
            MsgBox("Map To TCTS Successful")
        Else
            MsgBox("No Of skip B/Ls  " & aErrorList.Count)
        End If

        If Not EdiCnn Is Nothing Then
            If EdiCnn.State = ConnectionState.Open Then
                EdiCnn.Close()
            End If
        End If

        DsTcts.AcceptChanges()
        Me.ProgressBar.Visible = False

    End Sub

    Private Sub GetEdiTable(ByVal sSql As String, ByRef TB As DataTable, ByRef lResult As Boolean)

        Dim Da As New OleDb.OleDbDataAdapter
        Dim Cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand
        Dim Ds As New DataSet

        TB = New DataTable

        If EdiCnn.State = ConnectionState.Closed Then
            EdiCnn.ConnectionString = My.Settings.TctsCnn '  "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & GetUserConfigItem("TCTSDB")  ' C:\Program Files\EDIIP\DB\TCTS_SLS.mdb"
            EdiCnn.Open()
        End If

        Cmd.Connection = EdiCnn
        Cmd.CommandText = sSql
        Cmd.CommandType = CommandType.Text
        Da.SelectCommand = Cmd
        Da.Fill(Ds)

        If Ds.Tables(0).Rows.Count > 0 Then
            lResult = True
            TB = Ds.Tables(0).Copy
        Else
            lResult = False
        End If
        Ds.Dispose()

    End Sub

    Private Sub ExecuteSqlOnTcts(ByVal sSql As String)

        Dim Cmd As New OleDb.OleDbCommand
        If EdiCnn.State = ConnectionState.Closed Then
            EdiCnn.ConnectionString = My.Settings.TctsCnn '  "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & GetUserConfigItem("TCTSDB") ' C:\Program Files\EDIIP\DB\TCTS_SLS.mdb"
            EdiCnn.Open()
        End If
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = sSql
        Cmd.Connection = EdiCnn
        Cmd.ExecuteNonQuery()

    End Sub


    Private Sub InitDaTcts(ByVal Voyage As String)

        Dim sSql As String = ""

        DsTcts = New DataSet
        If EdiCnn.State = ConnectionState.Closed Then
            EdiCnn.ConnectionString = My.Settings.TctsCnn '   "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & GetUserConfigItem("TCTSDB")  'C:\Program Files\EDIIP\DB\TCTS_SLS.mdb"
            EdiCnn.Open()
        End If

        sSql = "Select * From TbMContainer where TripNo = '" & Voyage & "'"
        ADCns.SelectCommand = New OleDbCommand(sSql, EdiCnn)
        CBCns = New OleDbCommandBuilder(ADCns)
        ADCns.Fill(DsTcts, "TbMContainer")

        sSql = "Select * From TbMBLContainer where TripNo = '" & Voyage & "'"
        ADBLCns.SelectCommand = New OleDbCommand(sSql, EdiCnn)
        CBBLCns = New OleDbCommandBuilder(ADBLCns)
        ADBLCns.Fill(DsTcts, "TbMBLContainer")

        sSql = "Select * From TbMBL where TripNo = '" & Voyage & "'"
        ADBls.SelectCommand = New OleDbCommand(sSql, EdiCnn)
        CBBls = New OleDbCommandBuilder(ADBls)
        ADBls.Fill(DsTcts, "TbMBL")

        sSql = "Select * From TbMVoyageID Where TripNo = '" & Voyage & "'"
        ADVoy.SelectCommand = New OleDbCommand(sSql, EdiCnn)
        CbVoy = New OleDbCommandBuilder(ADVoy)
        ADVoy.Fill(DsTcts, "TbMVoyageID")

    End Sub

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
        End Select
        Return Ans
    End Function

   
    Private Sub ButtonChecking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonChecking.Click

        Dim Dv As DataView
        Dim lShow As Boolean = False
        Dim Dr As DataRow
        Dim Chk As New CLInwardChecking
        Dim lResult As Boolean

        Dv = New DataView(TbConfig, "Key = 'TCTSDB'", "", DataViewRowState.CurrentRows)

        If Dv.Count = 0 Then
            lShow = True
        Else
            If Dir(Dv.Item(0).Item("Description")) = "" Then
                lShow = False
            End If
        End If

        If lShow = True Then
            Me.FileDialog.ShowDialog()
            If Me.FileDialog.FileName <> "" Then
                If Dv.Count = 0 Then
                    Dr = TbConfig.NewRow
                    Dr("Key") = "TCTSDB"
                    Dr("Description") = Me.FileDialog.FileName
                    TbConfig.Rows.Add(Dr)
                Else
                    Dv.Item(0).Item("Description") = Me.FileDialog.FileName
                End If
                TbConfig.AcceptChanges()
                TbConfig.WriteXml(GetUserConfigFilePath, XmlWriteMode.WriteSchema)
            End If
        End If

        Chk.CheckingByVoyage(Me.FVoyage.VoyageID)

        If Chk.HasError Then
            Chk.ShowError()
        End If

        CheckEDIIPPorts()

    End Sub

    Private Sub CheckEDIIPPorts()

        Dim Tb As New DataTable
        Dim sSql As String
        Dim lResult As Boolean
        Dim NewDr As DataRow
        Dim Drs() As DataRow
        Dim TPort As New DataTable

        sSql = "Select distinct POL , dbo.FC_GetPortNameWithPortCode(POL) as PortName , (Select Top 1 EDIIPCODE From Tb_Ports Where PortCode = POL) as EDIIPCODE  From Tb_Inwardbls Where VoyageID = '" & Me.FVoyage.VoyageID.ToString & "'"
        sSql += "Union "
        sSql += "Select distinct POD , dbo.FC_GetPortNameWithPortCode(POD) as PortName ,(Select Top 1 EDIIPCODE From Tb_Ports Where PortCode = POD) as EDIIPCODE  From Tb_Inwardbls Where VoyageID = '" & Me.FVoyage.VoyageID.ToString & "'"
        sSql += "Union "
        sSql += "Select distinct FPOD , dbo.FC_GetPortNameWithPortCode(FPOD) as PortName ,(Select Top 1 EDIIPCODE From Tb_Ports Where PortCode = FPOD) as EDIIPCODE  From Tb_Inwardbls Where VoyageID = '" & Me.FVoyage.VoyageID.ToString & "'"
        sSql += "Union "
        sSql += "Select distinct POT , dbo.FC_GetPortNameWithPortCode(POT) as PortName ,(Select Top 1 EDIIPCODE From Tb_Ports Where PortCode = POT) as EDIIPCODE  From Tb_Inwardbls Where VoyageID = '" & Me.FVoyage.VoyageID.ToString & "'"

        TableBySql(sSql, Tb, lResult)

        With Me.DataSetForm.Tables(0)
            .Clear()
            For Each dr As DataRow In Tb.Rows
                Drs = .Select("OurPort = '" & dr("POL") & "'")
                If Drs.Length = 0 Then
                    NewDr = .NewRow
                    NewDr("OurPort") = dr("POL")
                    NewDr("EDIIPPORT") = dr("EDIIPCODE")
                    NewDr("PortName") = dr("PortName")
                    .Rows.Add(NewDr)
                End If
            Next
        End With

    End Sub

    Private Function GetEDIPORT(ByVal PortCode As String)

        Dim Drs() As DataRow
        Dim sPort As String
        Drs = Me.DataSetForm.Tables(0).Select("OurPort = '" & PortCode & "'")
        If Drs.Length > 0 Then
            sPort = NullToValue(Drs(0).Item("EDIIPPort"), PortCode)
        Else
            sPort = PortCode
        End If
        Return Mid(sPort, 1, 2) & " " & Mid(sPort, 3)

    End Function
    Private Sub ButtonDirect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDirect.Click

        Dim DLG As New SaveFileDialog
        Dim CP As Copran
        Dim Drs() As DataRow
        DLG.ShowDialog()
        If DLG.FileName = "" Then
            Exit Sub
        End If
        Dim Tb As DataTable

        Tb = Me.GridResult.DataSource

        If Me.OptionSet.Value = "COC" Then
            Drs = Tb.Select("COCBOX > 0  and Select = 1 ")
        Else
            Drs = Tb.Select("SOCBOX > 0 and Select = 1 ")
        End If


        CP = New Copran
        Try

            If Me.OptionSet.Value = "COC" Then 'Me.OptionSet.Items(0).CheckState = CheckState.Checked Then
                CP.CreateDataset(Me.FVoyage.VoyageID.ToString, Drs, False)
                CP.GererateCOPARN(DLG.FileName, False)
            Else
                CP.CreateDataset(Me.FVoyage.VoyageID.ToString, Drs, True)
                CP.GererateCOPARN(DLG.FileName, True)
            End If

            MsgBox("Generate successful")
        Catch ex As Exception
            MsgBox("Failed" & ex.ToString, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub ButtonSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For Each R As UltraGridRow In Me.GridResult.Rows
            R.Cells("Select").Value = True
        Next
        GridResult.UpdateData()

    End Sub

    Private Sub ButtonDeselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each R As UltraGridRow In Me.GridResult.Rows
            R.Cells("Select").Value = False
        Next
        GridResult.UpdateData()
    End Sub

    
    Private Sub ButtonUpdateWrongPorts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateWrongPorts.Click
        Dim Frm As New FrmWditPortWrongList(Me.GridMsgs.ActiveRow.Cells("OurPort").Text, Me.GridMsgs.ActiveRow.Cells("PortName").Text)
        Frm.Show()
    End Sub

    Private Sub ButtonXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXml.Click

        XMLE = New XMLEDI

        Dim DLG As New SaveFileDialog

        DLG.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
        DLG.ShowDialog()

        If DLG.FileName <> "" Then
            XMLE.GenEDIInXml(Me.GridResult.DataSource, Me.DataSetForm.Tables(0), Me.FVoyage.VoyageID.ToString, DLG.FileName)
        End If


    End Sub

    Private Sub XMLE_GenrateStart() Handles XMLE.GenrateStart
        Me.ProgressBar.Maximum = XMLE.RecordCount
    End Sub

    Private Sub XMLE_RecordSkip() Handles XMLE.RecordSkip
        Me.ProgressBar.Value = XMLE.RecordNo
    End Sub
    Function CntrFormat(ByVal sCntr As String)

        Dim nI As Byte

        Dim nChr As Long
        Dim Pfx As String = ""
        Dim sFx As String = ""
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
            Result = Microsoft.VisualBasic.Left(sCntr, 4) & Mid(sCntr, 5, 6) & "-" & Microsoft.VisualBasic.Right(sCntr, 1)
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
                Pfx = Microsoft.VisualBasic.Left(Pfx, 4)
            End If

            If Len(sCntr) > 4 Then
                sFx = sFx & Mid(sCntr, 5)
            End If

            ChkDgt = Microsoft.VisualBasic.Right(sFx, 1)
            sFx = Microsoft.VisualBasic.Left(sFx, Len(sFx) - 1)

            If Pfx = "" Then
                Pfx = "NILL"
            End If

            Result = NullToValue(Pfx, "") & NullToValue(sFx, "") & "-" & NullToValue(ChkDgt, "")

        End If

        Return Result

    End Function

    Private Sub ButtonSelect_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click
        For Each R As UltraGridRow In Me.GridResult.Rows
            R.Cells("Select").Value = True
        Next
        GridResult.UpdateData()

    End Sub

    Private Sub ButtonDeselect_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeselect.Click

        For Each R As UltraGridRow In Me.GridResult.Rows
            R.Cells("Select").Value = False
        Next
        GridResult.UpdateData()
    End Sub

    Private Sub ButtonForCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForCustom.Click
        Dim DLG As New SaveFileDialog
        Dim DPA As New CLGenerateDPA
        Dim SOF As TB_SOF
        Dim DM As New DataManager(My.Settings.DSN)
        Dim Drs() As DataRow
        Dim Tb As DataTable

        Tb = Me.GridResult.DataSource
        Drs = Tb.Select("Select = 1")


        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Me.FVoyage.VoyageID.ToString, MatchType.Exact)
        SOF = DM.GetTB_SOF


        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If

        DLG.ShowDialog()

        If DLG.FileName = "" Then
            Exit Sub
        End If

        Try
            DPA.GenerateDPA(Me.FVoyage.VoyageID.ToString, SOF.Port, Drs, DLG.FileName)
            MsgBox("Generate File Successful")
        Catch ex As Exception
            MsgBox("Generate File Faild", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub ButtonForCustomNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForCustomNew.Click
        Dim DLG As New SaveFileDialog
        Dim DPA As New CLGenerateDPA
        Dim SOF As TB_SOF
        Dim DM As New DataManager(My.Settings.DSN)
        Dim Drs() As DataRow
        Dim Tb As DataTable

        Me.GridResult.Update()
        Tb = Me.GridResult.DataSource
        Drs = Tb.Select("Select = 1")


        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Me.FVoyage.VoyageID.ToString, MatchType.Exact)
        SOF = DM.GetTB_SOF


        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If

        DLG.ShowDialog()

        If DLG.FileName = "" Then
            Exit Sub
        End If

        Try
            DPA.GenerateDPA_New(Me.FVoyage.VoyageID.ToString, SOF.Port, Drs, DLG.FileName)
            MsgBox("Generate File Successful")
        Catch ex As Exception
            MsgBox("Generate File Faild", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)
        End Try


    End Sub

End Class