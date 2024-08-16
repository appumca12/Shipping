Imports OrmLib
Imports ShippingBiz
Imports System.IO

Public Class CLOutwardManifest



    Private TempMnf As New DataTable
    Private TempCns As New DataTable
    Private TempTTL As New DataTable
    Private TempUnique As New DataTable
    Private TempSummary As New DataTable
    Private TempBls As New DataTable
    Private TempBlList As New DataTable
    Private TempCover As New DataTable
    Private Bls As TB_OutwardBLS
    Private Cns As New TB_OutwardCntrsCollection
    Private Goods As TB_OutwardBlsGoods
    Private Names As TB_OutwardBlsNames
    Private Memo As New CLMemo
    Private Voys As TB_Voyage
    Private Dm As DataManager
    Private TBChg As DataTable
    Private TBPkgs As DataTable
    Private TBlsList As New DataTable

    Public Sub GenrateMnf(ByVal SelTB As DataTable, ByVal Voy As TB_Voyage)

        Dim Dr As DataRow
        Dim TmpDr As DataRow
        Dim Ds As New DataSet
        Dim nFound As Long
        Dim FileContent As String
        Dim sr As StreamReader
        Dim tempDs As New DataSet

        Dim Cmd As New SqlClient.SqlCommand
        Dim Prm As New SqlClient.SqlParameter

        Call InitDs()
        Me.Voys = Voy
        Dm = New DataManager(My.Settings.DSN)

        tempDs = StoredProcedures.SP_OutwardCntrsPkgsTotal(Voy.ID.ToString)
        TBPkgs = tempDs.Tables(0)

        For Each Dr In SelTB.Rows
            If Dr("Select") = 1 Then
                TmpDr = TempBls.NewRow
                TmpDr("BlNo") = Dr("BlNo")
                TempBls.Rows.Add(TmpDr)
                Call GenMnfBl(Dr("Line"), Dr("BlNo"))
            End If
        Next

        If TempBls.Rows.Count = 0 Then
            MsgBoxGeneral("No Any Selection ", "Data Requird")
            Exit Sub
        End If
        Ds.Tables.Add(TempMnf.Copy)
        Ds.Tables.Add(TempCns.Copy)
        Ds.Tables.Add(TempTTL.Copy)
        Ds.Tables.Add(TempBlList.Copy) 'Added for RE: IMPORTANT & TOP TOP URGENT //RECIEVING ERROR / TOP URGENT
        Ds.WriteXml("C:\temp\Mnfst.xml")
        Ds = New DataSet

        Ds.Tables.Add(TempBls.Copy)
        Ds.WriteXml("c:\temp\Bls.xml")

        sr = File.OpenText("c:\temp\Bls.xml")
        FileContent = sr.ReadToEnd
        sr.Close()

        nFound = InStr(1, FileContent, "<NewDataSet>")
        FileContent = Mid(FileContent, nFound)

        With Cmd

            .CommandText = "SP_RptOutwardMnfSummary"
            .CommandType = CommandType.StoredProcedure
            .Connection = New SqlClient.SqlConnection

            .Connection.ConnectionString = ""

            Prm = New SqlClient.SqlParameter
            Prm.ParameterName = "@ID"
            Prm.Value = Voys.ID
            Prm.SqlDbType = SqlDbType.VarChar
            Prm.Size = 36
            Cmd.Parameters.Add(Prm)

            Prm = New SqlClient.SqlParameter
            Prm.ParameterName = "@Doc"
            Prm.Value = FileContent
            Prm.SqlDbType = SqlDbType.NText
            Prm.Size = 1073741823
            Cmd.Parameters.Add(Prm)

        End With

        Ds = New DataSet
        Ds.WriteXml("c:\temp\Bls.xml")

    End Sub

    Public Sub GenrateMnf(ByVal Line As String, ByVal BlNo As String)

        Dim Dr As DataRow
        Dim TmpDr As DataRow
        Dim Ds As New DataSet
        Dim nFound As Long
        Dim FileContent As String
        Dim sr As StreamReader
        Dim tempDs As New DataSet
        Dim BLDoc As TB_OutwardBLS

        Dim Cmd As New SqlClient.SqlCommand
        Dim Prm As New SqlClient.SqlParameter

        Call InitDs()
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, Line, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, BlNo, MatchType.Exact)
        BLDoc = Dm.GetTB_OutwardBLS
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, BLDoc.VoyageID, MatchType.Exact)
        voy = Dm.GetTB_Voyage()

        tempDs = StoredProcedures.SP_OutwardCntrsPkgsTotal(voy.ID.ToString)
        TBPkgs = tempDs.Tables(0)

        Call GenMnfBl(Line, BlNo)

        TmpDr = TempBls.NewRow
        TmpDr("BlNo") = BlNo
        TempBls.Rows.Add(TmpDr)


        Ds.Tables.Add(TempMnf.Copy)
        Ds.Tables.Add(TempCns.Copy)
        Ds.Tables.Add(TempTTL.Copy)
        Ds.Tables.Add(TempBlList.Copy) 'Added for RE: IMPORTANT & TOP TOP URGENT //RECIEVING ERROR / TOP URGENT
        Ds.WriteXml("C:\temp\Mnfst.xml")
        Ds = New DataSet

        Ds.Tables.Add(TempBls.Copy)
        Ds.WriteXml("c:\temp\Bls.xml")

        sr = File.OpenText("c:\temp\Bls.xml")
        FileContent = sr.ReadToEnd
        sr.Close()

        nFound = InStr(1, FileContent, "<NewDataSet>")
        FileContent = Mid(FileContent, nFound)

        With Cmd

            .CommandText = "SP_RptOutwardMnfSummary"
            .CommandType = CommandType.StoredProcedure
            .Connection = New SqlClient.SqlConnection

            .Connection.ConnectionString = ""

            Prm = New SqlClient.SqlParameter
            Prm.ParameterName = "@ID"
            Prm.Value = Voys.ID
            Prm.SqlDbType = SqlDbType.VarChar
            Prm.Size = 36
            Cmd.Parameters.Add(Prm)

            Prm = New SqlClient.SqlParameter
            Prm.ParameterName = "@Doc"
            Prm.Value = FileContent
            Prm.SqlDbType = SqlDbType.NText
            Prm.Size = 1073741823
            Cmd.Parameters.Add(Prm)

        End With

        Ds = New DataSet
        Ds.WriteXml("c:\temp\Bls.xml")


    End Sub


    Private Sub GenMnfBl(ByVal Carrier As String, ByVal BLNo As String)


        Dim nI As Byte
        Dim Cn As TB_OutwardCntrs
        Dim Dr As DataRow
        Dim aKey(0) As String
        Dim aKeyMnf(1) As String
        Dim Counter As Long
        Dim nCntrPkgs As Long
        Dim sCntrPkgs As String = ""
        Dim aTables() As String = {"TB_OutwardBls", "Tb_OutwardBlsNames", "TB_OutwardBlsGoods", "TB_OutwardCharges", "Tb_OutwardCntrs", "TB_OutwardCnsImco", "TB_OutwardCnsTemprature", "TB_OutwardCnsPkgs"}
        Dim Ds As DataSet
        Dim DV As DataView
        Dim Drs() As DataRow
        Dim POL As String = ""
        Dim POD As String = ""
        Dim Master As String = ""
        Dim Ve As TB_Vessels
        Dim Nationality As String = ""
        Dim VesselVoyage As String = ""
        Dim Imdg As TB_OutwardCnsImcoCollection
        Dim ImdgTemp As TB_OutwardCnsImcoCollection

        Dim TempRefs As TB_OutwardCnsTempratureCollection
        Dim TempRef As TB_OutwardCnsTempratureCollection
        Dim lResult As Boolean

        Dm = New DataManager(My.Settings.DSN)

        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voys.VesselID, MatchType.Exact)
        Ve = Dm.GetTB_Vessels

        VesselVoyage = Ve.VesselName & " " & Voys.VoyageNo
        Nationality = GetMeaningCode("", Ve.Nationality)

        Ds = StoredProcedures.SP_OutwardAllDataByLineBlNo(CurrentShippingLine, BLNo)
        Dm.PopulateObjectsFromDataSet(Ds, aTables)

        For nI = 0 To aTables.Length - 1
            Dm.DataSet.Tables(aTables(nI)).Merge(Ds.Tables(nI))
        Next

        Bls = Nothing
        Cns = Nothing
        Names = Nothing
        Goods = Nothing

        If Dm.GetTB_OutwardBLSCollectionFromDataSet.Count > 0 Then
            Bls = Dm.GetTB_OutwardBLSCollectionFromDataSet(0)
            POL = GetPortNameByCode(Bls.POL)
            POD = GetPortNameByCode(Bls.POD)
            Cns = Dm.GetTB_OutwardCntrsCollectionFromDataSet
            If Dm.GetTB_OutwardBlsNamesCollectionFromDataSet.Count > 0 Then
                Names = Dm.GetTB_OutwardBlsNamesCollectionFromDataSet(0)
            End If
            If Dm.GetTB_OutwardBlsGoodsCollectionFromDataSet.Count > 0 Then
                Goods = Dm.GetTB_OutwardBlsGoodsCollectionFromDataSet(0)
            End If
            Imdg = Dm.GetTB_OutwardCnsImcoCollectionFromDataSet
            TempRefs = Dm.GetTB_OutwardCnsTempratureCollectionFromDataSet
        End If
        Memo = New CLMemo
        If Not Names Is Nothing Then
            Memo.ColInit(CLMemo.MemoTypes.Cnee, Names.Cnee, 25)
            Memo.ColInit(CLMemo.MemoTypes.Notify1, Names.Notify1, 25)
            Memo.ColInit(CLMemo.MemoTypes.Shipper, Names.Shipper, 25)
        End If

        If Not Goods Is Nothing Then
            Memo.ColInit(CLMemo.MemoTypes.Goods, Goods.Goods, 35)
            Memo.ColInit(CLMemo.MemoTypes.Marks, Goods.Marks, 17)
        End If

        Counter = 0

        If Not Memo.Shpr Is Nothing Then
            For nI = 1 To Memo.Shpr.Count
                If Len(Trim(Memo.Shpr.Item(nI))) > 0 Then
                    Counter = Counter + 1
                    Dr = TempMnf.NewRow
                    Dr("BLID") = Bls.ID.ToString
                    Dr("BlNo") = Bls.BlNo
                    Dr("Seq") = Format(Counter, "0000")
                    If nI <= Memo.Shpr.Count Then
                        Dr("Col1") = "(SH)"
                        Dr("Col2") = Memo.Shpr.Item(nI)
                    End If
                    TempMnf.Rows.Add(Dr)
                End If

            Next
        End If

        If Not Memo.Cnee Is Nothing Then
            For nI = 1 To Memo.Cnee.Count
                If Len(Trim(Memo.Cnee.Item(nI))) > 0 Then
                    Counter = Counter + 1
                    Dr = TempMnf.NewRow
                    Dr("BLID") = Bls.ID.ToString
                    Dr("BlNo") = Bls.BlNo
                    Dr("Seq") = Format(Counter, "0000")
                    Dr("Col1") = "(CO)"
                    Dr("Col2") = Memo.Cnee.Item(nI)
                    TempMnf.Rows.Add(Dr)
                End If
            Next
        End If

        If Not Memo.Ntfy1 Is Nothing Then
            For nI = 1 To Memo.Ntfy1.Count
                If Len(Trim(Memo.Ntfy1.Item(nI))) > 0 Then
                    Counter = Counter + 1
                    Dr = TempMnf.NewRow
                    Dr("BLID") = Bls.ID.ToString
                    Dr("BlNo") = Bls.BlNo
                    Dr("Seq") = Format(Counter, "0000")
                    Dr("Col1") = "(NF)"
                    Dr("Col2") = Memo.Ntfy1.Item(nI)
                    TempMnf.Rows.Add(Dr)
                End If
            Next
        End If

        If Not Memo.GOOD Is Nothing Then
            For nI = 1 To Memo.GOOD.Count
                aKeyMnf(0) = Bls.BlNo
                aKeyMnf(1) = Format(nI, "0000")
                Dr = TempMnf.Rows.Find(aKeyMnf)
                If (Dr Is Nothing) Then
                    Dr = TempMnf.NewRow
                    Dr("BLID") = Bls.ID.ToString
                    Dr("BlNo") = Bls.BlNo
                    Dr("Seq") = Format(nI, "0000")
                    Dr("Col5") = Memo.GOOD.Item(nI)
                    TempMnf.Rows.Add(Dr)
                Else
                    Dr("Col5") = Memo.GOOD.Item(nI)
                End If
            Next
        End If

        If Not Memo.Mark Is Nothing Then
            For nI = 1 To Memo.Mark.Count
                aKeyMnf(0) = Bls.BlNo
                aKeyMnf(1) = Format(nI, "0000")
                Dr = TempMnf.Rows.Find(aKeyMnf)
                If (Dr Is Nothing) Then
                    Dr = TempMnf.NewRow
                    Dr("BLID") = Bls.ID.ToString
                    Dr("BlNo") = Bls.BlNo
                    Dr("Seq") = Format(nI, "0000")
                    Dr("Col4") = Memo.Mark.Item(nI)
                    TempMnf.Rows.Add(Dr)
                Else
                    Dr("Col4") = Memo.Mark.Item(nI)
                End If
            Next
        End If

        aKeyMnf(0) = Bls.BlNo
        aKeyMnf(1) = Format(1, "0000")
        Dr = TempMnf.Rows.Find(aKeyMnf)
        If (Dr Is Nothing) Then
            Dr = TempMnf.NewRow
            Dr("BLID") = Bls.ID.ToString
            Dr("BlNo") = Bls.BlNo
            Dr("Seq") = Format(1, "0000")
            Dr("Col3") = Bls.BlNo
            Dr("Col6") = "(TW)"
            If Not Goods Is Nothing Then
                Dr("Col7") = Format(NullToValue(Goods.TTW, 0), "standard")
            End If
        Else
            Dr("Col3") = Bls.BlNo
            Dr("Col6") = "(TW)"
            Dr("Col7") = Format(Double.Parse(Goods.TTW), "standard")
        End If

        aKeyMnf(0) = Bls.BlNo
        aKeyMnf(1) = Format(2, "0000")
        Dr = TempMnf.Rows.Find(aKeyMnf)
        If (Dr Is Nothing) Then
            Dr = TempMnf.NewRow
            Dr("BLID") = Bls.ID.ToString
            Dr("BlNo") = Bls.BlNo
            Dr("Seq") = Format(2, "0000")
            Dr("Col6") = "(GW)"
            If Not Memo.GOOD Is Nothing Then
                Dr("Col7") = Format(Double.Parse(Goods.TGW), "standard")
            End If
        Else
            Dr("Col6") = "(GW)"
            If Goods.TGW.IsNull Then
                Dr("Col7") = ""
            Else
                Dr("Col7") = Format(Double.Parse(Goods.TGW), "standard")
            End If

        End If

        For Each Cn In Cns
            Dr = TempCns.NewRow

            Dr("BlNo") = Bls.BlNo
            Dr("CntrNo") = Cn.CntrNo
            Dr("CnSize") = Cn.CnSize
            Dr("CnType") = Cn.CnType
            Dr("SealNo") = Cn.SealNo
            Dr("SVC") = Cn.FLE
            Dr("GW") = Format(Double.Parse(Cn.GW), "standard")
            Dr("TW") = Format(Double.Parse(Cn.TW), "standard")
            Dr("TTLWGT") = Format(Double.Parse(Cn.GW + Cn.TW), "standard")
            DV = New DataView(TBPkgs, "CntrID = '" & Cn.ID.ToString & "'", "", DataViewRowState.CurrentRows)
            If DV.Count > 0 Then
                nCntrPkgs = NullToValue(DV.Item(0).Item("TTLPKGS"), 0)
            Else
                nCntrPkgs = 0
            End If
            ' VbDecodes.InCntrTotalPkgs(Cn.ID, sCntrPkgs, nCntrPkgs)
            Dr("Pkgs") = nCntrPkgs & Cn.PackageType
            If Not Imdg Is Nothing Then
                ImdgTemp = Imdg.FilterByCntrID(Cn.ID)
                If ImdgTemp.Count > 0 Then
                    Dr("IMDG") = ImdgTemp(0).IMDGCode
                    Dr("UNNO") = ImdgTemp(0).UNNO
                    Dr("FLASHPoint") = ImdgTemp(0).FlashPoint
                End If
            End If

            If Not TempRefs Is Nothing Then
                TempRef = TempRefs.FilterByCntrID(Cn.ID)
                If TempRef.Count > 0 Then
                    Dr("Temp") = TempRef(0).TempMin
            
                End If
            End If

            TempCns.Rows.Add(Dr)
            aKey(0) = Cn.CntrNo
            Dr = TempUnique.Rows.Find(aKey)
            If (Dr Is Nothing) Then
                Dr = TempUnique.NewRow
                Dr("CntrNo") = Cn.CntrNo
                TempUnique.Rows.Add(Dr)
                Dr = TempTTL.NewRow
                Dr("CntrNo") = Cn.CntrNo
                Dr("CnSize") = Cn.CnSize
                Dr("CnType") = Cn.CnType
                Dr("FE") = IIf(Cn.FLE = "F" Or Cn.FLE = "L", "Full", "Empty")
                Dr("Weight") = Double.Parse(Cn.TW + Cn.GW)
                TempTTL.Rows.Add(Dr)
            Else
                aKey(0) = Cn.CntrNo
                Dr = TempTTL.Rows.Find(aKey)
                If Not (Dr Is Nothing) Then
                    Dr("Weight") = Dr("Weight") + Double.Parse(Cn.GW)
                End If
            End If

        Next

        Drs = TempMnf.Select("BLNO = '" & BLNo & "'")

        For Each Dr In Drs
            Dr("POL") = POL
            Dr("POD") = POD
            Dr("Nationality") = Nationality
            Dr("Master") = Master
            Dr("VesselVoyage") = VesselVoyage
        Next

        If TBChg Is Nothing Then
            TBChg = Dm.DataSet.Tables("TB_OutwardCharges")
        Else
            TBChg.Merge(Dm.DataSet.Tables("TB_OutwardCharges"))
        End If
        TableBySql("SP_outwardBlsListByVoyageID '" & CurrentShippingLine & "', '" & voy.ID.ToString & "'", TBlsList, lResult)
        TempBlList = TBlsList
    End Sub
    Private Sub InitDs()

        Dim myDataColumn As DataColumn

        TempCns = New DataTable("BLS")
        With TempBls
            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "BlNo"
            .Columns.Add(myDataColumn)
        End With

        TempMnf = New DataTable("BlData")
        With TempMnf

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "BlNo"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Seq"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Col1"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Col2"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Col3"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Col4"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Col5"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Col6"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Col7"
            .Columns.Add(myDataColumn)


            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "BLID"
            .Columns.Add(myDataColumn)


            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "POL"
            .Columns.Add(myDataColumn)


            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "POD"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Master"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Nationality"
            .Columns.Add(myDataColumn)


            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "VesselVoyage"
            .Columns.Add(myDataColumn)


            Dim PrimaryKeyColumns(1) As DataColumn
            PrimaryKeyColumns(0) = .Columns("BlNo")
            PrimaryKeyColumns(1) = .Columns("Seq")
            .PrimaryKey = PrimaryKeyColumns

        End With

        TempCns = New DataTable("CntrData")
        With TempCns
            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "BlNo"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "CntrNo"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "CnSize"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "CnType"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "SealNo"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "SVC"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "GW"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "TW"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "TTLWGT"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Pkgs"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "IMDG"
            .Columns.Add(myDataColumn)


            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "UNNO"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "TEMP"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "FLASHPoint"
            .Columns.Add(myDataColumn)


        End With

        TempTTL = New DataTable("TotalData")
        With TempTTL

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "CntrNo"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "CnSize"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "CnType"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "FE"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Double")
            myDataColumn.ColumnName = "Weight"
            .Columns.Add(myDataColumn)

            Dim PrimaryKeyColumns(0) As DataColumn
            PrimaryKeyColumns(0) = .Columns("CntrNo")
            .PrimaryKey = PrimaryKeyColumns

        End With

        TempUnique = New DataTable("UniqueCns")
        With TempUnique
            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "CntrNo"
            .Columns.Add(myDataColumn)
            Dim PrimaryKeyColumns(0) As DataColumn
            PrimaryKeyColumns(0) = .Columns("CntrNo")
            .PrimaryKey = PrimaryKeyColumns
        End With

        TempSummary = New DataTable("Summary")
        With TempSummary
            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "CntrNo"
            .Columns.Add(myDataColumn)
            Dim PrimaryKeyColumns(0) As DataColumn
            PrimaryKeyColumns(0) = .Columns("CntrNo")
            .PrimaryKey = PrimaryKeyColumns
        End With

    End Sub
    Public Sub ShowReport(ByVal IsCargo As String)

        Dim Report As RptInwrdMnfst = New RptInwrdMnfst
        Dim SUBA As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim SUBB As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim SUBC As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim SUBD As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim PH As New CLPrintHdr
        Dim Frm As New FrmGeneralReportShow

        Report.SetDataSource(TempMnf)
        Dim subreportName As String
        Dim subreportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject

        subreportObject = Report.ReportDefinition.ReportObjects.Item("SUBA")
        subreportName = subreportObject.SubreportName
        SUBA = Report.OpenSubreport(subreportName)
        SUBA.SetDataSource(TempCns)

        subreportObject = Report.ReportDefinition.ReportObjects.Item("SUBB")
        subreportName = subreportObject.SubreportName
        SUBB = Report.OpenSubreport(subreportName)
        SUBB.SetDataSource(TempTTL)

        subreportObject = Report.ReportDefinition.ReportObjects.Item("SUBC")
        subreportName = subreportObject.SubreportName
        SUBC = Report.OpenSubreport(subreportName)
        SUBC.SetDataSource(TBChg)

        'Added for TOP URGENT \ INWARD GENERAL LIST Case
        subreportObject = Report.ReportDefinition.ReportObjects.Item("SUBD")
        subreportName = subreportObject.SubreportName
        SUBD = Report.OpenSubreport(subreportName)
        SUBD.SetDataSource(TempBlList)

        '  Report.Subreports(2).SetDataSource(PH.ImageTable)

        If Voys.TB_Vessels Is Nothing Then
            Report.SetParameterValue("VoyVsl", Voys.VoyageNo)
        Else
            Report.SetParameterValue("VoyVsl", Voys.VoyageNo & " " & Voys.TB_Vessels.VesselName)
        End If
        Report.SetParameterValue("Master", ".")
        Report.SetParameterValue("POD", ".")
        Report.SetParameterValue("IsCargo", IsCargo)
        Frm.ReportViewer.ReportSource = Report
        Frm.Show()

    End Sub
    Public Sub ShowSummary(ByVal SelTB As DataTable, ByVal Vessel As String, ByVal Voyage As String)

        'Dim Report As RptOutwardSumm = New RptOutwardSumm
        'Dim lResult As Boolean
        'Dim Frm As New FrmShowReport
        'Dim DS As DataSet
        'Dim FileContent As String
        'Dim sr As StreamReader
        'Dim nFound As Long
        'Dim Dr As DataRow
        'Dim TmpDr As DataRow

        'Dim Prm As New SqlClient.SqlParameter
        'Dim Cmd As New SqlClient.SqlCommand

        'Call InitDs()


        'For Each Dr In SelTB.Rows
        '    If Dr("Sel") = True Then
        '        TmpDr = TempBls.NewRow
        '        TmpDr("BlNo") = Dr("BlNo")
        '        TempBls.Rows.Add(TmpDr)
        '    End If
        'Next

        'If TempBls.Rows.Count < 1 Then
        '    MsgBox("No any Selected BLs !")
        '    Exit Sub
        'End If

        'DS = New DataSet
        'DS.Tables.Add(TempBls)
        'DS.WriteXml("c:\Bls.xml")

        'sr = File.OpenText("c:\Bls.xml")
        'FileContent = sr.ReadToEnd
        'sr.Close()

        'nFound = InStr(1, FileContent, "<NewDataSet>")
        'FileContent = Mid(FileContent, nFound)

        'With Cmd

        '    .CommandText = "SP_RptOutwardMnfSummary"
        '    .CommandType = CommandType.StoredProcedure

        '    Prm = New SqlClient.SqlParameter
        '    Prm.ParameterName = "@ID"
        '    Prm.Value = Voys.ID
        '    Prm.SqlDbType = SqlDbType.VarChar
        '    Prm.Size = 36
        '    Cmd.Parameters.Add(Prm)

        '    Prm = New SqlClient.SqlParameter
        '    Prm.ParameterName = "@Doc"
        '    Prm.Value = FileContent
        '    Prm.SqlDbType = SqlDbType.NText
        '    Prm.Size = 1073741823
        '    Cmd.Parameters.Add(Prm)

        'End With
        'Cmd.Connection = Cnn
        'DS = New DataSet
        'FillDatasetByCmd(Cmd, DS, "TempSummary", lResult)
        'Report.SetDataSource(DS.Tables("TempSummary"))
        'Report.SetParameterValue("Vessel", Vessel)
        'Report.SetParameterValue("Voyage", Voyage)
        'Frm.ReportViewer.ReportSource = Report
        'Frm.Show()

    End Sub
    Public Sub MnfCover(ByVal Voy As TB_Voyage, ByVal VesselName As String)

        Dim Report As RptInwardMnfCover = New RptInwardMnfCover
        Dim Frm As New FrmGeneralReportShow

        Dim sSql As String
        Dim DS As New DataSet
        Dim Dr As DataRow
        Dim nDr As DataRow
        Dim aKey(0) As String
        Dim Fld As String
        Dim PH As New CLPrintHdr

        Voys = Voy

        sSql = "SP_OutwardCntrsByVoyage '" & Voys.ID.ToString & "'"

        Dm = New DataManager(My.Settings.DSN)
        DS = StoredProcedures.SP_outwardCntrsByVoyage(Voys.ID.ToString)
        If DS.Tables(0).Rows.Count = 0 Then
            MsgBox("No Any Data !", MsgBoxStyle.Information)
            Exit Sub
        End If

        DS.Tables(0).TableName = "Cover"

        Call InitTempCover()

        For Each Dr In DS.Tables("Cover").Rows

            If NullToValue(Dr("FLE"), "F") = "E" Then
                aKey(0) = "6"
            Else
                Select Case Val(NullToValue(Dr("StatusCode"), 3))
                    Case 1
                        aKey(0) = "3"
                    Case "2"
                        aKey(0) = "5"
                    Case 4
                        aKey(0) = "2"
                    Case 5
                        aKey(0) = "1"
                    Case "6"
                        aKey(0) = "7"
                    Case Else
                        aKey(0) = "3"
                End Select
            End If
            nDr = TempCover.Rows.Find(aKey)
            If Not (nDr Is Nothing) Then
                Fld = "NRL" + IIf(NullToValue(Dr("CnSize"), "40") = "20", "20", "40")
                If Dr("Imco") = "Y" Then
                    If Dr("FLE") = "Y" Then
                        Fld = "IMCOL" & IIf(Dr("CnSize") = "20", "20", "40")
                    Else
                        Fld = "IMCO" & IIf(Dr("CnSize") = "20", "20", "40")
                    End If
                Else
                    If Dr("Refeer") = "Y" Then
                        Fld = "RF" & IIf(Dr("CnSize") = "20", "20", "40")
                    Else
                        If Dr("FLE") = "L" Then
                            Fld = "LCL" & IIf(Dr("CnSize") = "20", "20", "40")
                        Else
                            If Dr("CntrGroup") = "SP" Then
                                Fld = "SP" + IIf(NullToValue(Dr("CnSize"), "40") = "20", "20", "40")
                            End If
                        End If
                    End If
                End If
                nDr(Fld) = nDr(Fld) + 1
                If Dr("CnSize") = "20" Then
                    nDr("TTL20") = nDr("TTL20") + 1
                Else
                    nDr("TTL40") = nDr("TTL40") + 1
                End If
                nDr("TTLGW") = nDr("TTLGW") + NullToValue(Dr("GW"), 0)
                nDr("TTLTW") = nDr("TTLTW") + NullToValue(Dr("TW"), 0)
                nDr("TTLWGT") = nDr("TTLWGT") + (NullToValue(Dr("TW"), 0) + NullToValue(Dr("GW"), 0))
            End If
        Next Dr
        '   Report.Subreports(0).SetDataSource(PH.ImageTable)
        Report.SetDataSource(TempCover)
        Frm.ReportViewer.ReportSource = Report

        Report.SetParameterValue("Vessel", VesselName)
        Report.SetParameterValue("Voyage", Voys.VoyageNo)
        Frm.Show()

    End Sub
    Private Sub InitTempCover()

        Dim myDataColumn As DataColumn
        Dim NewDr As DataRow
        Dim nI As Long

        Dim Codes As TB_CODECollection


        With TempCover

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Seq"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Description"
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "NRL20"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "NRL40"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "SP20"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "SP40"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "RF20"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "RF40"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "IMCO20"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "IMCO40"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "IMCOL20"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "IMCOL40"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "LCL20"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "LCL40"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "TTL20"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "TTL40"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Double")
            myDataColumn.ColumnName = "TTLGW"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Double")
            myDataColumn.ColumnName = "TTLTW"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Double")
            myDataColumn.ColumnName = "TTLWGT"
            myDataColumn.DefaultValue = 0
            .Columns.Add(myDataColumn)

            Dim PrimaryKeyColumns(0) As DataColumn
            PrimaryKeyColumns(0) = .Columns("Seq")
            .PrimaryKey = PrimaryKeyColumns

        End With

        If Dm Is Nothing Then
            Dm = New DataManager(My.Settings.DSN)
        End If

        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "ST", MatchType.Exact)
        Codes = Dm.GetTB_CODECollection.SortBySTDCode(SortDirection.Ascending)

        For nI = 1 To Codes.Count - 1
            NewDr = TempCover.NewRow
            NewDr("Seq") = Trim(Str(nI))
            NewDr("Description") = Codes(nI).MEANINGF
            TempCover.Rows.Add(NewDr)
        Next
        Codes = Nothing

    End Sub
    Public Property voy() As Object
        Get
            Return Voys
        End Get
        Set(ByVal Value As Object)
            Voys = Value
        End Set
    End Property

End Class
