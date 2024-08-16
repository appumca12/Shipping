Imports OrmLib
Imports ShippingBiz

Public Class CLPermitManifest

    Private ResultTB As DataTable
    Public Sub GenerateMnf(ByVal VoyageID As String, ByVal aPermits As ArrayList)

        Dim Ds As New DataSet
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim PermitID As String
        Dim aRows() As DataRow
        Dim Dm As DataManager
        Dim CoName As String
        Dim MainLine As String
        Dim CC As CLCntrCount
        Dim TotalPkgs As Long
        Dim Pkgs As String
        Dim PermitNo As String = ""
        Dim nSeq As Long
        Dim Mem As New CLMemo
        Dim Goods As String = ""
        Dim Dv As DataView
        Dim nI As Long
        Dim lFirst As Boolean = True
        Dim UNNO As String
        Dim Imdg As String
        Dim sImco As String
        Dim Agent As TB_Agents
        Dim lResult As Boolean



        Dm = New DataManager(My.Settings.DSN)
        Dm.GetTB_Company()
        CoName = Dm.DataSet.Tables("TB_Company").Rows(0).Item("CompanyName")

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Dm.GetTB_Lines()
        MainLine = Dm.DataSet.Tables("TB_Lines").Rows(0).Item("LineName")
        Mem = New CLMemo
        Mem.ColInit(CLMemo.MemoTypes.Cnee, "", 15)
        Ds = New DataSet
        DataSetBySql("SP_ExpPermitManifest '" & CurrentShippingLine & "' , '" & VoyageID.ToString & "'", Ds, lResult) ' StoredProcedures.SP_ExpPermitManifest(CurrentShippingLine, VoyageID)
        For Each PermitID In aPermits

            aRows = Ds.Tables(0).Select("PermitID = '" & PermitID & "'")
            If aRows.Length > 0 Then
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_Agents.Columns.Port, aRows(0).Item("FPODCode"), MatchType.Exact)
                Dm.QueryCriteria.And(JoinPath.TB_Agents.Columns.Line, CurrentShippingLine, MatchType.Exact)
                Agent = Dm.GetTB_Agents
            End If
            If Not Agent Is Nothing Then
                Mem.ColInit(CLMemo.MemoTypes.Cnee, "(SH) " & CoName & vbCrLf & "(CO) " & Agent.AgentName & vbCrLf & "(NF) " & Agent.AgentName, 25)
            Else
                Mem.ColInit(CLMemo.MemoTypes.Cnee, "(SH) " & CoName & vbCrLf & "(CO) " & MainLine & vbCrLf & "(NF) " & MainLine, 25)
            End If
            CC = New CLCntrCount
            nSeq = 0
            TotalPkgs = 0
            For Each Dr In aRows

                'Mem = New CLMemo
                'Mem.ColInit(CLMemo.MemoTypes.Cnee, "", 15)

                nSeq += 1
                PermitNo = Dr("PermitNo")
                Goods = Dr("Goods")
                Pkgs = Dr("PackageType")
                UNNO = Dr("UnNO")
                Imdg = Dr("Imdg")
                NewDr = ResultTB.NewRow
                NewDr("PermitNo") = PermitNo
                NewDr("Seq") = nSeq
                NewDr("BLNO") = CurrentShippingLine & PermitNo
                NewDr("VslVoy") = Dr("Vessel") & " " & Dr("VoyageNo")
                NewDr("POL") = Dr("POL")
                NewDr("POD") = Dr("POD")
                NewDr("Status") = Dr("Status")
                NewDr("COL1") = CurrentShippingLine & PermitNo
                If nSeq <= Mem.Cnee.Count Then
                    NewDr("COL2") = Mem.Cnee.Item(nSeq)
                End If
                NewDr("COL3") = ""
                NewDr("COL4") = "(CN) " & Dr("CntrNo") & "/" & Dr("CnSize") & "'" & Dr("CnType")
                NewDr("COL5") = Dr("DJWazNo")
                NewDr("COL6") = Dr("NoOfPkgs")
                NewDr("COL7") = "TW"
                NewDr("COL8") = Dr("TW")

                If NullToValue(NewDr("COL8"), "") = "" Then
                    NewDr("COL8") = IIf(Dr("CnSize") = "20", 2200, 4500) ' Dr("TW")
                End If

                ResultTB.Rows.Add(NewDr)

                nSeq += 1

                NewDr = ResultTB.NewRow
                NewDr("PermitNo") = PermitNo
                NewDr("Seq") = nSeq
                NewDr("BLNO") = CurrentShippingLine & PermitNo
                NewDr("VslVoy") = Dr("Vessel") & " " & Dr("VoyageNo")
                NewDr("POL") = Dr("POL")
                NewDr("POD") = Dr("POD")
                NewDr("Status") = Dr("Status")

                NewDr("COL1") = CurrentShippingLine & PermitNo
                If nSeq <= Mem.Cnee.Count Then
                    NewDr("COL2") = Mem.Cnee.Item(nSeq)
                End If
                NewDr("COL3") = ""
                NewDr("COL4") = "(SN) " & Dr("SealNo")
                NewDr("COL5") = ""
                NewDr("COL6") = ""
                NewDr("COL7") = "GW"
                NewDr("COL8") = Dr("GW")
                ResultTB.Rows.Add(NewDr)
                CC.Add(Dr("CnType"), Dr("CnSize"), Dr("FLE"))
                TotalPkgs += Dr("NoOfPkgs")

            Next

            sImco = ""
            If Imdg & UNNO <> "" Then
                sImco += vbCrLf
                sImco += "IMCO CLASS:" & Imdg
                sImco += vbCrLf
                sImco += "UN Number:" & UNNO
            End If



            Mem.ColInit(CLMemo.MemoTypes.Goods, CC.GetInString & vbCrLf & _
                                                             "STC:" & vbCrLf & _
                                                             TotalPkgs.ToString & " " & Pkgs & vbCrLf & _
                                                             Goods & sImco & _
                                                             vbCrLf & "** Permit NO. " & PermitNo & "**", 40)

            Dv = New DataView(ResultTB, "PermitNo = '" & PermitNo & "'", "Seq", DataViewRowState.CurrentRows)
            If Dv.Count < Mem.GOOD.Count Then
                nSeq = Dv.Count + 1
                For nSeq = Dv.Count To Mem.GOOD.Count
                    NewDr = ResultTB.NewRow
                    NewDr("Seq") = nSeq
                    NewDr("BLNO") = aRows(0).Item("PermitNo")
                    NewDr("PermitNo") = aRows(0).Item("PermitNo")
                    NewDr("VslVoy") = aRows(0).Item("Vessel") & " " & aRows(0).Item("VoyageNo")
                    NewDr("POL") = aRows(0).Item("POL")
                    NewDr("POD") = aRows(0).Item("POD")
                    NewDr("Status") = aRows(0).Item("Status")
                    NewDr("COL1") = CurrentShippingLine & aRows(0).Item("PermitNo")
                    If nSeq <= Mem.Cnee.Count Then
                        NewDr("COL2") = Mem.Cnee.Item(nSeq)
                    End If
                    ResultTB.Rows.Add(NewDr)
                Next
                Dv = New DataView(ResultTB, "PermitNo = '" & PermitNo & "'", "Seq", DataViewRowState.CurrentRows)
            End If
            Dv = New DataView(ResultTB, "PermitNo = '" & PermitNo & "'", "Seq", DataViewRowState.CurrentRows)
            For nI = 1 To Dv.Count - 1
                If Mem.GOOD.Count >= nI Then
                    Dv.Item(nI - 1).Item("COL3") = Mem.GOOD.Item(nI)
                End If
                If nSeq <= Mem.Cnee.Count Then
                    NewDr("COL2") = Mem.Cnee.Item(nSeq)
                End If
            Next
        Next

    End Sub
    Public Sub New()

        ResultTB = New DataTable
        With ResultTB
            .TableName = "TBResult"
            .Columns.Add(New DataColumn("PermitNo", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int32")))
            .Columns.Add(New DataColumn("BLNO", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("VslVoy", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("POL", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("POD", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("COL1", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("COL2", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("COL3", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("COL4", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("COL5", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("COL6", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("COL7", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("COL8", System.Type.GetType("System.String")))
        End With

    End Sub

    Public ReadOnly Property Result() As DataTable
        Get
            Return ResultTB
        End Get
    End Property

    Public Sub GenEmptyManifest(ByVal VoyageID As Guid)

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
        Dim nSeq As Int16
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
            End If
        Next

        TempDrs = TBTemp.Select("", "Port")
        StorPort = ""
        nSeq = 0
        For Each TempDr In TempDrs

            If TempDr("Port") <> StorPort Then
                BLNo = "-MTY-" & TempDr("Port") & "-" & TempDr("Seq").ToString

                TDR = TBTotal.Select("Port = '" & TempDr("Port") & "'")
                If TDR.Length > 0 Then
                    sgoods = IIf(TDR(0).Item("TTL20") > 0, TDR(0).Item("TTL20").ToString & "X20'", "")
                    sgoods += " " & IIf(TDR(0).Item("TTL40") > 0, TDR(0).Item("TTL40").ToString & "X40'", "")

                End If
                lFirst = True
                StorPort = TempDr("Port")
            End If

            Drs = Dm.DataSet.Tables("TB_EcsContainers").Select("ID = '" & TempDr("ID").ToString & "'", "")
            DrsMove = Dm.DataSet.Tables("TB_EcsMoves").Select("CntrID = '" & TempDr("ID").ToString & "'")

            If Drs.Length > 0 Then
                Dr = Drs(0)
                nSeq += 1
                NewDr = ResultTB.NewRow
                NewDr("PermitNo") = BLNo
                NewDr("Seq") = nSeq
                NewDr("BLNO") = CurrentShippingLine & BLNo
                NewDr("VslVoy") = Vsl.VesselName & " " & Voy.VoyageNo
                NewDr("POL") = GetPortNameByCode(Dr("DischargeTo"))
                NewDr("POD") = GetPortNameByCode(Dr("ReturnTo"))
                NewDr("Status") = "Empty" ' Dr("Status")
                NewDr("COL1") = CurrentShippingLine & BLNo

                If lFirst = True Then
                    NewDr("COL2") = "(SH) " & CoName
                End If

                If lFirst = True Then
                    NewDr("COL3") = sgoods & " EMPTY CONTAINERS"
                Else
                    NewDr("COL3") = ""
                End If

                If trd = True Then
                    NewDr("COL2") = "(NF) " & CoName & " " & Dr("ReturnTo")
                    trd = False
                End If

                If snd = True Then
                    NewDr("COL2") = "(NF) " & CoName & " " & Dr("ReturnTo")
                    snd = False
                    trd = True
                End If

                If lFirst Then
                    lFirst = False
                    snd = True
                End If

                sgoods = ""
                NewDr("COL4") = "(CN) " & Dr("CntrNo") & "/" & Dr("CnSize") & "'" & Dr("CnType")
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Dr("InVoyageID"), MatchType.Exact)
                SOf = Dm.GetTB_SOF
                If Not SOf Is Nothing Then
                    NewDr("COL5") = SOf.DjwazNo ' Dr("DJWazNo")
                End If
                NewDr("COL6") = "" '1 'Dr("NoOfPkgs")
                NewDr("COL7") = "TW"
                NewDr("COL8") = ""
                ssql = "select dbo.FC_GetInwardCnsTWByVoyageCntr('" & TempDr("VoyageID").ToString & "' , '" & TempDr("CntrNo") & "')"
                TableBySql(ssql, TbTw, lResult)
                If lResult = True Then
                    If TbTw.Rows.Count > 0 Then
                        NewDr("COL8") = NullToValue(TbTw.Rows(0).Item(0), "")
                    End If
                End If
                If NewDr("COL8") = "" Then
                    NewDr("COL8") = IIf(Dr("CnSize") = "20", 2200, 4500) ' Dr("TW")
                End If
                ResultTB.Rows.Add(NewDr)

                TotalPkgs += 1
            End If
        Next
 
    End Sub

End Class
'Imports OrmLib
'Imports ShippingBiz

'Public Class CLPermitManifest

'    Private ResultTB As DataTable
'    Public Sub GenerateMnf(ByVal VoyageID As String, ByVal aPermits As ArrayList)

'        Dim Ds As New DataSet
'        Dim Dr As DataRow
'        Dim NewDr As DataRow
'        Dim PermitID As String
'        Dim aRows() As DataRow
'        Dim Dm As DataManager
'        Dim CoName As String
'        Dim MainLine As String
'        Dim CC As CLCntrCount
'        Dim TotalPkgs As Long
'        Dim Pkgs As String
'        Dim PermitNo As String = ""
'        Dim nSeq As Long
'        Dim Mem As New CLMemo
'        Dim Goods As String = ""
'        Dim Dv As DataView
'        Dim nI As Long
'        Dim lFirst As Boolean = True

'        Dm = New DataManager(My.Settings.DSN)
'        Dm.GetTB_Company()
'        CoName = Dm.DataSet.Tables("TB_Company").Rows(0).Item("CompanyName")

'        Dm = New DataManager(My.Settings.DSN)
'        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
'        Dm.GetTB_Lines()
'        MainLine = Dm.DataSet.Tables("TB_Lines").Rows(0).Item("LineName")

'        Ds = StoredProcedures.SP_ExpPermitManifest(CurrentShippingLine, VoyageID)

'        For Each PermitID In aPermits
'            aRows = Ds.Tables(0).Select("PermitID = '" & PermitID & "'")
'            CC = New CLCntrCount
'            nSeq = 0
'            TotalPkgs = 0
'            For Each Dr In aRows
'                nSeq += 1
'                PermitNo = Dr("PermitNo")
'                Goods = Dr("Goods")
'                Pkgs = Dr("PackageType")
'                NewDr = ResultTB.NewRow
'                NewDr("PermitNo") = PermitNo
'                NewDr("Seq") = nSeq
'                NewDr("BLNO") = CurrentShippingLine & PermitNo
'                NewDr("VslVoy") = Dr("Vessel") & " " & Dr("VoyageNo")
'                NewDr("POL") = Dr("POL")
'                NewDr("POD") = Dr("POD")
'                NewDr("Status") = Dr("Status")
'                NewDr("COL1") = CurrentShippingLine & PermitNo
'                If lFirst = True Then
'                    NewDr("COL2") = "(SH) " & CoName
'                End If
'                NewDr("COL3") = ""
'                NewDr("COL4") = "(CN) " & Dr("CntrNo") & "/" & Dr("CnSize") & "'" & Dr("CnType")
'                NewDr("COL5") = Dr("DJWazNo")
'                NewDr("COL6") = Dr("NoOfPkgs")
'                NewDr("COL7") = "TW"
'                NewDr("COL8") = Dr("TW")
'                ResultTB.Rows.Add(NewDr)

'                nSeq += 1

'                NewDr = ResultTB.NewRow
'                NewDr("PermitNo") = PermitNo
'                NewDr("Seq") = nSeq
'                NewDr("BLNO") = CurrentShippingLine & PermitNo
'                NewDr("VslVoy") = Dr("Vessel") & " " & Dr("VoyageNo")
'                NewDr("POL") = Dr("POL")
'                NewDr("POD") = Dr("POD")
'                NewDr("Status") = Dr("Status")

'                NewDr("COL1") = CurrentShippingLine & PermitNo
'                If lFirst = True Then
'                    NewDr("COL2") = "(NF) " & MainLine
'                    lFirst = False
'                End If
'                NewDr("COL3") = ""
'                NewDr("COL4") = "(SN) " & Dr("SealNo")
'                NewDr("COL5") = ""
'                NewDr("COL6") = ""
'                NewDr("COL7") = "GW"
'                NewDr("COL8") = Dr("GW")
'                ResultTB.Rows.Add(NewDr)
'                CC.Add(Dr("CnType"), Dr("CnSize"), "F")
'                TotalPkgs += Dr("NoOfPkgs")

'            Next

'            Mem = New CLMemo

'            Mem.ColInit(CLMemo.MemoTypes.Goods, CC.GetInString & vbCrLf & _
'                                                             "STC:" & vbCrLf & _
'                                                             TotalPkgs.ToString & " " & Pkgs & vbCrLf & _
'                                                             Goods & vbCrLf & "** Permit NO. " & PermitNo & "**", 40)

'            Dv = New DataView(ResultTB, "PermitNo = '" & PermitNo & "'", "Seq", DataViewRowState.CurrentRows)
'            If Dv.Count < Mem.GOOD.Count Then
'                nSeq = Dv.Count + 1
'                For nSeq = Dv.Count To Mem.GOOD.Count
'                    NewDr = ResultTB.NewRow
'                    NewDr("Seq") = nSeq
'                    NewDr("BLNO") = aRows(0).Item("PermitNo")
'                    NewDr("PermitNo") = aRows(0).Item("PermitNo")
'                    NewDr("VslVoy") = aRows(0).Item("Vessel") & " " & aRows(0).Item("VoyageNo")
'                    NewDr("POL") = aRows(0).Item("POL")
'                    NewDr("POD") = aRows(0).Item("POD")
'                    NewDr("Status") = aRows(0).Item("Status")
'                    NewDr("COL1") = CurrentShippingLine & aRows(0).Item("PermitNo")
'                    ResultTB.Rows.Add(NewDr)
'                Next
'                Dv = New DataView(ResultTB, "PermitNo = '" & PermitNo & "'", "Seq", DataViewRowState.CurrentRows)
'            End If
'            Dv = New DataView(ResultTB, "PermitNo = '" & PermitNo & "'", "Seq", DataViewRowState.CurrentRows)
'            For nI = 1 To Dv.Count - 1
'                If Mem.GOOD.Count >= nI Then
'                    Dv.Item(nI - 1).Item("COL3") = Mem.GOOD.Item(nI)
'                End If
'            Next
'        Next

'    End Sub
'    Public Sub New()

'        ResultTB = New DataTable
'        With ResultTB
'            .TableName = "TBResult"
'            .Columns.Add(New DataColumn("PermitNo", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int32")))
'            .Columns.Add(New DataColumn("BLNO", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("VslVoy", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("POL", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("POD", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("COL1", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("COL2", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("COL3", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("COL4", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("COL5", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("COL6", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("COL7", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("COL8", System.Type.GetType("System.String")))
'        End With

'    End Sub

'    Public ReadOnly Property Result() As DataTable
'        Get
'            Return ResultTB
'        End Get
'    End Property

'    Public Sub GenEmptyManifest(ByVal VoyageID As Guid)

'        Dim Cns As TB_EcsContainersCollection
'        Dim Cn As TB_EcsContainers
'        Dim Mov As TB_EcsMovesCollection
'        Dim Dm As New DataManager(My.Settings.DSN)
'        Dim TBTemp As New DataTable
'        Dim OE As String = "EL" 'should change for multi lines 
'        Dim Tb As DataTable
'        Dim Dr As DataRow
'        Dim Drs() As DataRow
'        Dim StorPort As String
'        Dim BLNo As String
'        Dim nSeq As Byte
'        Dim NewDr As DataRow
'        Dim Voy As TB_Voyage
'        Dim Vsl As TB_Vessels
'        Dim lFirst As Boolean
'        Dim TTlPkgs As Int16
'        Dim CoName As String
'        Dim TempDr As DataRow
'        Dim TempDrs() As DataRow
'        Dim MainLine As String
'        Dim CC As New CLCntrCount
'        Dim TotalPkgs As Int16
'        Dim SOf As TB_SOF
'        Dim DrsMove() As DataRow
'        Dim TBTotal As DataTable
'        Dim TDR() As DataRow
'        Dim sgoods As String
'        Dim DS As DataSet
'        Dim snd As Boolean
'        Dim trd As Boolean
'        Dim ssql As String
'        Dim TbTw As DataTable
'        Dim lResult As Boolean


'        With TBTemp
'            .TableName = "Temp"
'            .Columns.Add(New DataColumn("Port", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
'            .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
'            .Columns.Add(New DataColumn("VoyageID", System.Type.GetType("System.Guid")))
'            .Columns.Add(New DataColumn("CntrNo", System.Type.GetType("System.String")))
'        End With

'        TBTotal = New DataTable

'        With TBTotal
'            .TableName = "Total"
'            .Columns.Add(New DataColumn("Port", System.Type.GetType("System.String")))
'            .Columns.Add(New DataColumn("TTL20", System.Type.GetType("System.Int16")))
'            .Columns.Add(New DataColumn("TTL40", System.Type.GetType("System.Int16")))
'        End With

'        Dm.QueryCriteria.Clear()
'        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
'        Dm.GetTB_Lines()
'        MainLine = Dm.DataSet.Tables("TB_Lines").Rows(0).Item("LineName")


'        Dm.QueryCriteria.Clear()
'        Dm.GetTB_Company()
'        CoName = Dm.DataSet.Tables("TB_Company").Rows(0).Item("CompanyName")

'        Dm.QueryCriteria.Clear()
'        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyageID, MatchType.Exact)
'        Voy = Dm.GetTB_Voyage

'        Dm.QueryCriteria.Clear()
'        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
'        Vsl = Dm.GetTB_Vessels

'        Dm.QueryCriteria.Clear()
'        Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.OutVoyageID, VoyageID)
'        Cns = Dm.GetTB_EcsContainersCollection

'        For Each Cn In Cns
'            Dm.QueryCriteria.Clear()
'            Dm.QueryCriteria.And(JoinPath.TB_EcsMoves.Columns.CntrID, Cn.ID, MatchType.Exact)
'            Dm.QueryCriteria.And(JoinPath.TB_EcsMoves.Columns.Status, OE, MatchType.Exact)

'            Mov = Dm.GetTB_EcsMovesCollection
'            If Mov.Count <> 0 Then
'                nSeq = TBTemp.Rows.Count + 1
'                Dr = TBTemp.NewRow
'                Dr("Port") = Cn.ReturnTo
'                Dr("ID") = Cn.ID
'                Dr("Seq") = nSeq
'                Dr("VoyageID") = Cn.InVoyageID
'                Dr("CntrNo") = Cn.CntrNo
'                TBTemp.Rows.Add(Dr)
'                Drs = TBTotal.Select("Port = '" & Cn.ReturnTo & "'")
'                If Drs.Length = 0 Then
'                    Dr = TBTotal.NewRow
'                    Dr("Port") = Cn.ReturnTo
'                    Dr("TTL20") = 0
'                    Dr("TTL40") = 0
'                    If Cn.CnSize = "20" Then
'                        Dr("TTL20") += 1
'                    Else
'                        Dr("TTL40") += 1
'                    End If
'                    TBTotal.Rows.Add(Dr)
'                Else
'                    If Cn.CnSize = "20" Then
'                        Drs(0).Item("TTL20") += 1
'                    Else
'                        Drs(0).Item("TTL40") += 1
'                    End If

'                End If
'            End If
'        Next

'        TempDrs = TBTemp.Select("", "Port")
'        StorPort = ""
'        nSeq = 0
'        For Each TempDr In TempDrs

'            If TempDr("Port") <> StorPort Then
'                BLNo = "-MTY-" & TempDr("Port") & "-" & TempDr("Seq").ToString

'                TDR = TBTotal.Select("Port = '" & TempDr("Port") & "'")
'                If TDR.Length > 0 Then
'                    sgoods = IIf(TDR(0).Item("TTL20") > 0, TDR(0).Item("TTL20").ToString & "X20'", "")
'                    sgoods += " " & IIf(TDR(0).Item("TTL40") > 0, TDR(0).Item("TTL40").ToString & "X40'", "")

'                End If
'                lFirst = True
'                StorPort = TempDr("Port")
'            End If

'            Drs = Dm.DataSet.Tables("TB_EcsContainers").Select("ID = '" & TempDr("ID").ToString & "'", "")
'            DrsMove = Dm.DataSet.Tables("TB_EcsMoves").Select("CntrID = '" & TempDr("ID").ToString & "'")

'            If Drs.Length > 0 Then
'                Dr = Drs(0)
'                nSeq += 1
'                NewDr = ResultTB.NewRow
'                NewDr("PermitNo") = BLNo
'                NewDr("Seq") = nSeq
'                NewDr("BLNO") = CurrentShippingLine & BLNo
'                NewDr("VslVoy") = Vsl.VesselName & " " & Voy.VoyageNo
'                NewDr("POL") = Dr("DischargeTo")
'                NewDr("POD") = Dr("ReturnTo")
'                NewDr("Status") = "Empty" ' Dr("Status")
'                NewDr("COL1") = CurrentShippingLine & BLNo

'                If lFirst = True Then
'                    NewDr("COL2") = "(SH) " & CoName
'                End If

'                If lFirst = True Then
'                    NewDr("COL3") = sgoods
'                Else
'                    NewDr("COL3") = ""
'                End If

'                If trd = True Then
'                    NewDr("COL2") = "(NF) " & CoName & " " & Dr("ReturnTo")
'                    trd = False
'                End If

'                If snd = True Then
'                    NewDr("COL2") = "(NF) " & CoName & " " & Dr("ReturnTo")
'                    snd = False
'                    trd = True
'                End If

'                If lFirst Then
'                    lFirst = False
'                    snd = True
'                End If

'                sgoods = ""
'                NewDr("COL4") = "(CN) " & Dr("CntrNo") & "/" & Dr("CnSize") & "'" & Dr("CnType")
'                Dm.QueryCriteria.Clear()
'                Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Dr("InVoyageID"), MatchType.Exact)
'                SOf = Dm.GetTB_SOF
'                If Not SOf Is Nothing Then
'                    NewDr("COL5") = SOf.DjwazNo ' Dr("DJWazNo")
'                End If
'                NewDr("COL6") = "" '1 'Dr("NoOfPkgs")
'                NewDr("COL7") = "TW"
'                NewDr("COL8") = ""
'                ssql = "select dbo.FC_GetInwardCnsTWByVoyageCntr('" & TempDr("VoyageID").ToString & "' , '" & TempDr("CntrNo") & "')"
'                TableBySql(ssql, TbTw, lResult)
'                If lResult = True Then
'                    If TbTw.Rows.Count > 0 Then
'                        NewDr("COL8") = NullToValue(TbTw.Rows(0).Item(0), "")
'                    End If
'                End If
'                If NewDr("COL8") = "" Then
'                    NewDr("COL8") = IIf(Dr("CnSize") = "20", 2200, 4500) ' Dr("TW")
'                End If
'                ResultTB.Rows.Add(NewDr)

'                TotalPkgs += 1
'            End If
'        Next




'    End Sub




'End Class