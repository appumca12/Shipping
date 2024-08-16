Imports OrmLib
Imports ShippingBiz
Imports System.Text
Imports System.IO
Imports Infragistics.Win.UltraWinGrid

Public Class EDICls
    Private DM As DataManager

    Public Sub GenerateBooking(ByVal EdiType As EType, ByVal Grid As UltraGrid)

        Dim FleName As String
        Dim Row As UltraGridRow
        Dim aRec As New ArrayList
        Dim Dr As DataRow
        Dim DrDetail As DataRow
        Dim sStr As String
        Dim nI As Byte
        Dim Ds As DataSet

        For Each Row In Grid.Rows
            If Row.Selected = True Then
                aRec.Add(Row.Cells("BookingNo").Value)
            End If
        Next

        If aRec.Count = 0 Then
            MsgBoxGeneral("No Any Selection !", "Generate File Aborted")
            Exit Sub
        End If

        FleName = GetFileNameForSave(EdiType)

        If FleName = "" Then
            MsgBoxGeneral("No Valid File Name !", "Generate File Aborted")
            Exit Sub
        End If

        Dim SWriter As New StreamWriter(FleName)
        SWriter.Write("###BK" & Format(Now, "YYYYMMDD") & FixStrLen(1, 10, True) & FixStrLen(10, 10, False))

        DM = New DataManager(My.Settings.DSN)

        For Each BookingNo As String In aRec

            Ds = StoredProcedures.SP_ZZBookingEDI(BookingNo, BookingNo)

            For Each Dr In Ds.Tables(0).Rows
                sStr = ""
                For nI = 0 To Dr.Table.Columns.Count - 1
                    If Dr.Item(nI).GetType.ToString = "System.Guid" Then
                        sStr += IIf(sStr = "", "", "{||}") & "{" & NullToValue(Dr.Item(nI).ToString, "") & "}"
                    Else
                        sStr += IIf(sStr = "", "", "{||}") & NullToValue(Dr.Item(nI).ToString, "")
                    End If
                Next nI
                SWriter.WriteLine(sStr)

                For Each DrDetail In Ds.Tables(1).Rows
                    sStr = ""
                    For nI = 0 To DrDetail.Table.Columns.Count - 1
                        If DrDetail.Item(nI).GetType.ToString = "System.Guid" Then
                            sStr += IIf(sStr = "", "", "{||}") & "{" & NullToValue(DrDetail(nI).ToString, "") & "}"
                        Else
                            sStr += IIf(sStr = "", "", "{||}") & NullToValue(DrDetail(nI).ToString, "")
                        End If
                    Next nI
                    SWriter.WriteLine(sStr)
                Next
            Next
        Next
        SWriter.Flush()
        SWriter.Close()
        Rename(FleName, Replace(FleName, ".txt", ".edi"))


    End Sub

    Private Function GetFileNameForSave(ByVal EdiType As EType) As String

        Dim Dialog As New SaveFileDialog
        If EdiType = EType.XMLType Then
            Dialog.Filter = "XML Files (*.XML)|*.XML"
        Else
            Dialog.Filter = "Text Files (*.txt)|*.txt"
        End If

        Dialog.ShowDialog()

        Return Dialog.FileName


    End Function
    Private Function GetFileNameForOpening(ByVal EdiType As EType) As String

        Dim Dialog As New OpenFileDialog
        If EdiType = EType.XMLType Then
            Dialog.Filter = "XML Files (*.XML)|*.XML"
        Else
            Dialog.Filter = "Text Files (*.txt)|*.txt"
        End If

        Dialog.ShowDialog()

        Return Dialog.FileName


    End Function
    Public Sub GenerateInwardData(ByVal EdiType As EType, ByVal ListOfBLID As ArrayList)

        Dim FleName As String
        Dim DsResult As New DataSet
        Dim Tb As DataTable
        Dim Ds As DataSet
        Dim nI As Int16
        Dim Dr As DataRow
        Dim aPorts As New ArrayList
        Dim aClients As New ArrayList
        Dim aTables() As String = {"TB_InwardBls", "Tb_InwardBlsNames", "TB_InwardBlsGoods", "TB_InwardCharges", "Tb_InwardCntrs", "TB_InwardCnsImco", "TB_InwardCnsTemprature", "TB_InwardCnsPkgs"}
        Dim VoyID As Guid
        Dim VslID As Guid
        FleName = GetFileNameForSave(EdiType)

        If FleName = "" Then
            MsgBoxGeneral("No Valid File Name !", "Generate File Aborted")
            Exit Sub
        End If

        DM = New DataManager(My.Settings.DSN)
        For Each BL As Object In ListOfBLID
            Ds = New DataSet
            Ds = StoredProcedures.SP_InwardAllDataByLineBlNo(BL(0), BL(1))
            For nI = 0 To aTables.Length - 1
                Ds.Tables(nI).TableName = aTables(nI)
            Next
            VoyID = Ds.Tables("TB_InwardBls").Rows(0).Item("VoyageID")
            If DsResult.Tables.Count = 0 Then
                DsResult = Ds.Copy
                Ds.EnforceConstraints = False
            Else
                For Each Tb In Ds.Tables
                    For Each Dr In Tb.Rows
                        DsResult.Tables(Dr.Table.TableName).ImportRow(Dr)
                    Next
                Next
            End If
        Next

        If Not DsResult.Tables("TB_InwardBls") Is Nothing Then
            For Each Dr In DsResult.Tables("TB_InwardBls").Rows
                If aPorts.IndexOf(NullToValue(Dr("POL"), "")) = -1 Then
                    aPorts.Add(NullToValue(Dr("POL"), ""))
                End If
                If aPorts.IndexOf(NullToValue(Dr("POD"), "")) = -1 Then
                    aPorts.Add(NullToValue(Dr("POD"), ""))
                End If
                If aPorts.IndexOf(NullToValue(Dr("POD"), "")) = -1 Then
                    aPorts.Add(NullToValue(Dr("POD"), ""))
                End If
                If aPorts.IndexOf(NullToValue(Dr("FPOD"), "")) = -1 Then
                    aPorts.Add(NullToValue(Dr("FPOD"), ""))
                End If
                If aPorts.IndexOf(NullToValue(Dr("POT"), "")) = -1 Then
                    aPorts.Add(NullToValue(Dr("POT"), ""))
                End If
                If aPorts.IndexOf(NullToValue(Dr("IssuePlace"), "")) = -1 Then
                    aPorts.Add(NullToValue(Dr("IssuePlace"), ""))
                End If
                If aClients.IndexOf(NullToValue(Dr("ClientID"), "")) = -1 Then
                    aClients.Add(NullToValue(Dr("ClientID"), ""))
                End If
            Next


            DsResult.AcceptChanges()
            DM = New DataManager(My.Settings.DSN)

            For Each Port As String In aPorts
                DM.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortCode, Port, MatchType.Exact)
                DM.GetTB_Ports()
                DM.QueryCriteria.Clear()
            Next


            DsResult.Tables.Add(DM.DataSet.Tables("TB_Ports").Copy)
            DsResult.AcceptChanges()

            For Each Client As Guid In aClients
                DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Client, MatchType.Exact)
                DM.GetTB_Clients()
                DM.QueryCriteria.Clear()
            Next

            DsResult.Tables.Add(DM.DataSet.Tables("TB_Clients").Copy)
            DsResult.AcceptChanges()

            DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyID, MatchType.Exact)
            DM.GetTB_Voyage()
            DsResult.Tables.Add(DM.DataSet.Tables("TB_Voyage").Copy)

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, VoyID, MatchType.Exact)
            DM.GetTB_SOF()
            DsResult.Tables.Add(DM.DataSet.Tables("TB_SOF").Copy)

            DM.QueryCriteria.Clear()
            VslID = DM.DataSet.Tables("TB_Voyage").Rows(0).Item("VesselID")
            DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, VslID, MatchType.Exact)
            DM.GetTB_Vessels()
            DsResult.Tables.Add(DM.DataSet.Tables("TB_Vessels").Copy)

            DsResult.AcceptChanges()
            If EdiType = EType.XMLType Then
                DsResult.WriteXml(FleName)
            Else
                GenEDIText(DsResult, FleName)
            End If
        End If

    End Sub
    Private Sub GenEDIText(ByVal DsResult As DataSet, ByVal FleName As String)


        Dim Sr As String = "|*|"
        Dim Voy As DataRow
        Dim Vsl As DataRow
        Dim VOD As DataRow
        Dim MemCls As CLMemo
        Dim BLS As DataRow
        Dim Cns() As DataRow
        Dim Mem() As DataRow
        Dim Good() As DataRow

        Dim nBLSeq As Long
        Dim nI As Byte
        Dim nJ As Int16

        Dim SWriter As New StreamWriter(FleName)
        DsResult.AcceptChanges()
        SWriter.WriteLine("###BL" & Sr & DsResult.Tables("TB_Voyage").Rows(0).Item("VoyageNo") & Sr & Format(Now, "yyyyMMdd"))
        Voy = DsResult.Tables("TB_Voyage").Rows(0)
        Vsl = DsResult.Tables("TB_Vessels").Rows(0)
        SWriter.WriteLine("VO" & "001" & Sr & _
        Voy("ID").ToString & Sr & _
        Voy("VoyageNo") & Sr & _
        Vsl("VesselCode") & Sr & _
        "AEJEA" & Sr & _
        Format(Voy("StartDate"), "yyyyMMdd") & Sr & _
        Voy("Master") & Sr & _
        Vsl("Nationality") & Sr & _
        "1")

        VOD = DsResult.Tables("TB_SOF").Rows(0)
        SWriter.WriteLine("VD" & "001" & Sr & _
                   VOD("ID").ToString & Sr & _
                   VOD("VoyageID").ToString & Sr & _
                   "1" & Sr & _
                   VOD("Port") & Sr & _
                   Format(NullToValue(VOD("Arrival"), Now), "yyyyMMdd") & Sr & _
                   Format(NullToValue(VOD("DschCmpl"), Now), "yyyyMMdd") & Sr & _
                   Format(NullToValue(VOD("LoadCmpl"), Now), "yyyyMMdd") & Sr & _
                   Format(NullToValue(VOD("Sailed"), Now), "yyyyMMdd"))


        For Each BLS In DsResult.Tables("TB_InwardBLS").Rows
            MemCls = New CLMemo
            Cns = DsResult.Tables("TB_InwardCntrs").Select("BLID = '" & BLS("ID").ToString & "'")
            Mem = DsResult.Tables("Tb_InwardBlsNames").Select("BLID = '" & BLS("ID").ToString & "'")
            Good = DsResult.Tables("TB_InwardBlsGoods").Select("BLID = '" & BLS("ID").ToString & "'")
            MemCls.ColInit(CLMemo.MemoTypes.Cnee, NullToValue(Mem(0).Item("Cnee"), ""), 150)
            MemCls.ColInit(CLMemo.MemoTypes.Notify1, NullToValue(Mem(0).Item("Notify1"), ""), 150)
            MemCls.ColInit(CLMemo.MemoTypes.Shipper, NullToValue(Mem(0).Item("Shipper"), ""), 150)
            MemCls.ColInit(CLMemo.MemoTypes.Goods, NullToValue(Good(0).Item("Goods"), ""), 150)
            MemCls.ColInit(CLMemo.MemoTypes.Marks, NullToValue(Good(0).Item("MARKS"), ""), 150)
            nBLSeq = nBLSeq + 1
            SWriter.WriteLine("BL" & Format(nBLSeq, "000") & Sr & _
                BLS("ID").ToString & Sr & _
                "PRM" & Sr & _
                NullToValue(BLS("BlNo"), "") & Sr & _
                NullToValue(BLS("IssuePlace"), "") & Sr & _
                Format(NullToValue(BLS("IssueDate"), Now), "yyyyMMdd") & Sr & _
                BLS("POL") & Sr & _
                NullToValue(BLS("POT"), "") & Sr & _
                NullToValue(BLS("POD"), "") & Sr & _
                NullToValue(BLS("FPOD"), "") & Sr & _
                NullToValue(BLS("NoOfBls"), 3) & Sr & _
                NullToValue(BLS("TermsOfPayment"), "C") & Sr & _
                 "IRTEH" & Sr & _
                NullToValue(BLS("VoyageID"), "").ToString & Sr & _
                NullToValue(BLS("PreVoyageID"), "").ToString & Sr & _
                "SQNo" & Sr & _
                NullToValue(BLS("POR"), "").ToString)

            If Mem.Length > 0 Then
                SWriter.WriteLine("MI001" & Sr & Mem(0).Item("ID").ToString)
            End If

            For nI = 1 To MemCls.Shpr.Count
                SWriter.WriteLine("SH" & Format(nI, "000") & Sr & MemCls.Shpr.Item(nI))
            Next nI

            For nI = 1 To MemCls.Cnee.Count
                SWriter.WriteLine("CE" & Format(nI, "000") & Sr & MemCls.Cnee.Item(nI))
            Next nI

            For nI = 1 To MemCls.Ntfy1.Count
                SWriter.WriteLine("NF" & Format(nI, "000") & Sr & MemCls.Ntfy1.Item(nI))
            Next nI

            For nI = 1 To MemCls.GOOD.Count
                SWriter.WriteLine("GD" & Format(nI, "000") & Sr & MemCls.GOOD.Item(nI))
            Next nI


            SWriter.WriteLine("IF" & "001" & Sr & _
              System.Guid.NewGuid.ToString & Sr & _
              "PRM" & Sr & _
              NullToValue(BLS("BlNo").ToString, "") & Sr & _
              NullToValue(Left(Mem(0).Item("Messers").ToString, 40), "") & Sr & _
              NullToValue(Left(Good(0).Item("MainCom").ToString, 40), "") & Sr & _
              NullToValue(BLS("MailReleaseRem"), "") & Sr & _
              NullToValue(BLS("MailRelease"), "") & Sr & _
              NullToValue("PCL", "") & Sr & _
              NullToValue("", "") & Sr & _
              NullToValue("", "") & Sr & _
              NullToValue("", "") & Sr & _
              NullToValue("", "") & Sr & _
                  "")
            nJ = 0
            'NullToValue("", "") & Sr & _
            '  "" & Sr & _
            '  NullToValue("", "") & Sr & _
            '  NullToValue("", "") & Sr & _
            '      "")
            If Cns.Length > 0 Then
                For Each Cn As DataRow In Cns
                    nJ += 1
                    SWriter.WriteLine("CN" & Format(nJ, "000") & Sr & _
                    "PRM" & Sr & _
                    NullToValue(BLS("BlNo"), "") & Sr & _
                    NullToValue(Cn("CntrNo"), "") & Sr & _
                    NullToValue(Cn("CnSize"), "") & Sr & _
                    NullToValue(Cn("CnType"), "") & Sr & _
                    NullToValue(Cn("TW"), "") & Sr & _
                    NullToValue(Cn("GW"), "") & Sr & _
                    NullToValue(Cn("SealNo"), "") & Sr & _
                    NullToValue(Cn("SOC"), "") & Sr & _
                    NullToValue(Cn("FLE"), "") & Sr & _
                    NullToValue("", "") & Sr & _
                    NullToValue(Cn("NoOfPkgs"), "") & Sr & _
                    NullToValue(Cn("PackageType"), "") & Sr & _
                    Cn("ID").ToString)
                Next
            End If
        Next
        ' GenerateMail(FLE, TxtSubject, TxtBody)
        SWriter.Flush()
        SWriter.Close()
        Rename(FleName, Replace(FleName, ".txt", ".blt"))

        MsgBox("Map Successful")
    End Sub

    Public Sub RestoreXMLInwardDataPart1(ByVal FleName As String, ByVal EdiType As EType, ByRef Grid As UltraGrid, ByRef Ds As DataSet, ByRef TBResult As DataTable)


        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Port As TB_Ports
        Dim Bls As TB_InwardBLS
        Dim Clnt As TB_Clients
        Dim Vsl As TB_Vessels
        Dim Voy As TB_Voyage
        Dim Tb As DataTable

        TBResult = New DataTable("Result")

        DM = New DataManager(My.Settings.DSN)

        TbResult.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TbResult.Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
        TbResult.Columns.Add(New DataColumn("Value", System.Type.GetType("System.String")))
        TbResult.Columns.Add(New DataColumn("Action", System.Type.GetType("System.String")))
        TBResult.Columns.Add(New DataColumn("Result", System.Type.GetType("System.String")))

        If FleName = "" Then
            MsgBoxGeneral("No Valid File Name !", "Generate File Aborted")
            Exit Sub
        End If

        DM = New DataManager(My.Settings.DSN)
        Ds.ReadXml(FleName)

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Ds.Tables("TB_Vessels").Rows(0).Item("ID"), MatchType.Exact)
        Vsl = DM.GetTB_Vessels
        NewDr = TbResult.NewRow
        NewDr("ID") = Ds.Tables("TB_Vessels").Rows(0).Item("ID")
        NewDr("Description") = "Vessel"
        NewDr("Value") = Ds.Tables("TB_Vessels").Rows(0).Item("VesselName")
        If Vsl Is Nothing Then
            NewDr("Action") = "Append"
        Else
            NewDr("Action") = "Revised"
        End If
        TbResult.Rows.Add(NewDr)


        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Ds.Tables("TB_Voyage").Rows(0).Item("ID"), MatchType.Exact)
        Voy = DM.GetTB_Voyage
        NewDr = TbResult.NewRow
        NewDr("ID") = Ds.Tables("TB_Voyage").Rows(0).Item("ID")
        NewDr("Description") = ("Voyage")
        NewDr("Value") = Ds.Tables("TB_Voyage").Rows(0).Item("VoyageNo")
        If Vsl Is Nothing Then
            NewDr("Action") = "Append"
        Else
            NewDr("Action") = "Revised"
        End If
        TbResult.Rows.Add(NewDr)

        Tb = Ds.Tables("TB_Clients")
        Dim drs() As DataRow = Ds.Tables("TB_Clients").Select
        For Each Dr In drs
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Dr("ID"), MatchType.Exact)
            Clnt = DM.GetTB_Clients
            If Clnt Is Nothing Then
                NewDr = TbResult.NewRow
                NewDr("ID") = Dr("ID")
                NewDr("Description") = "Clients"
                NewDr("Value") = Dr("LName")
                NewDr("Action") = "Append"
                TbResult.Rows.Add(NewDr)
            Else
                Dr.Delete()
            End If
        Next
        Ds.AcceptChanges()
        drs = Ds.Tables("TB_InwardBLS").Select
        For Each Dr In drs
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.ID, Dr("ID"), MatchType.Exact)
            Bls = DM.GetTB_InwardBLS
            NewDr = TbResult.NewRow
            NewDr("ID") = Dr("ID")
            NewDr("Description") = "B/L"
            NewDr("Value") = Dr("BLNO")
            If Bls Is Nothing Then
                NewDr("Action") = "Append"
            Else
                NewDr("Action") = "Revised"
            End If
            TbResult.Rows.Add(NewDr)
        Next

        drs = Ds.Tables("TB_Ports").Select
        For Each Dr In drs
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortCode, Dr("PortCode"), MatchType.Exact)
            Port = DM.GetTB_Ports
            If Port Is Nothing Then
                NewDr = TbResult.NewRow
                NewDr("ID") = Dr("ID")
                NewDr("Description") = "Ports"
                NewDr("Value") = Dr("PortName")
                NewDr("Action") = "Append"
                TbResult.Rows.Add(NewDr)
            Else
                Dr.Delete()
            End If
        Next
        Ds.AcceptChanges()
        Grid.DataSource = TbResult

    End Sub

    Public Sub RestoreXMLInwardDataPart2(ByVal DS As DataSet, ByRef TBresult As DataTable)

        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Drs() As DataRow
        Dim BL As TB_InwardBLS
        Dim Names As TB_InwardBlsNames
        Dim Goods As TB_InwardBlsGoods
        Dim Chgs As TB_InwardChargesCollection
        Dim Cns As TB_InwardCntrsCollection
        Dim ResultDr() As DataRow


        DM = New DataManager(My.Settings.DSN)
        If Not DS.Tables("TB_Ports") Is Nothing Then
            For Each Dr In DS.Tables("TB_Ports").Rows
                NewDr = DM.DataSet.Tables("TB_Ports").NewRow
                For Each Col As DataColumn In Dr.Table.Columns
                    Try
                        NewDr(Col.ColumnName) = Dr(Col.ColumnName)
                    Catch ex As Exception
                    End Try
                Next
                DM.DataSet.Tables("TB_Ports").Rows.Add(NewDr)
                ResultDr = TBresult.Select("ID = '" & Dr("ID") & "'")
                Try
                    DM.CommitAll()
                    ResultDr(0).Item("Result") = "Success"
                    ResultDr(0).RowError = ""
                Catch ex As Exception
                    ResultDr(0).Item("Result") = "Failed"
                    ResultDr(0).RowError = ex.ToString
                End Try
            Next
        End If

        DM = New DataManager(My.Settings.DSN)
        If Not DS.Tables("TB_Clients") Is Nothing Then
            For Each Dr In DS.Tables("TB_Clients").Rows
                NewDr = DM.DataSet.Tables("TB_Clients").NewRow
                For Each Col As DataColumn In Dr.Table.Columns
                    Try
                        NewDr(Col.ColumnName) = Dr(Col.ColumnName)
                    Catch ex As Exception
                    End Try
                    DM.DataSet.Tables("TB_Clients").Rows.Add(NewDr)
                    ResultDr = TBresult.Select("ID = '" & Dr("ID") & "'")
                    Try
                        DM.CommitAll()
                        ResultDr(0).Item("Result") = "Success"
                        ResultDr(0).RowError = ""
                    Catch ex As Exception
                        ResultDr(0).Item("Result") = "Failed"
                        ResultDr(0).RowError = ex.ToString

                    End Try
                Next
            Next
        End If

        DM = New DataManager(My.Settings.DSN)
        If Not DS.Tables("TB_Vessels") Is Nothing Then
            For Each Dr In DS.Tables("TB_Vessels").Rows
                NewDr = DM.DataSet.Tables("TB_Vessels").NewRow
                For Each Col As DataColumn In Dr.Table.Columns
                    Try
                        NewDr(Col.ColumnName) = Dr(Col.ColumnName)
                    Catch ex As Exception
                    End Try
                    ResultDr = TBresult.Select("ID = '" & Dr("ID") & "'")
                    Try
                        DM.CommitAll()
                        ResultDr(0).Item("Result") = "Success"
                        ResultDr(0).RowError = ""
                    Catch ex As Exception
                        ResultDr(0).Item("Result") = "Failed"
                        ResultDr(0).RowError = ex.ToString
                    End Try
                Next
            Next
        End If


        DM = New DataManager(My.Settings.DSN)
        If Not DS.Tables("TB_Voyage") Is Nothing Then
            For Each Dr In DS.Tables("TB_Voyage").Rows
                NewDr = DM.DataSet.Tables("TB_Voyage").NewRow
                For Each Col As DataColumn In Dr.Table.Columns
                    Try
                        NewDr(Col.ColumnName) = Dr(Col.ColumnName)
                    Catch ex As Exception
                    End Try
                    ResultDr = TBresult.Select("ID = '" & Dr("ID") & "'")
                    Try
                        DM.CommitAll()
                        ResultDr(0).Item("Result") = "Success"
                        ResultDr(0).RowError = ""
                    Catch ex As Exception
                        ResultDr(0).Item("Result") = "Failed"
                        ResultDr(0).RowError = ex.ToString
                    End Try
                Next
            Next
        End If

        If Not DS.Tables("TB_InwardBls") Is Nothing Then
            For Each Dr In DS.Tables("TB_InwardBls").Rows
                DM = New DataManager(My.Settings.DSN)
                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.ID, Dr("Id"), MatchType.Exact)
                BL = DM.GetTB_InwardBLS
                If BL Is Nothing Then
                    NewDr = DM.DataSet.Tables("TB_InwardBls").NewRow
                    For Each Col As DataColumn In Dr.Table.Columns
                        Try
                            NewDr(Col.ColumnName) = Dr(Col.ColumnName)
                        Catch ex As Exception
                        End Try
                        DM.DataSet.Tables("TB_InwardBls").Rows.Add(NewDr)
                    Next
                Else
                    For Each Col As DataColumn In DS.Tables("TB_InwardBls").Columns
                        Try
                            DM.DataSet.Tables("TB_InwardBls").Rows(0).Item(Col.ColumnName) = Dr(Col.ColumnName)
                        Catch ex As Exception
                        End Try
                    Next
                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_InwardBlsNames.Columns.BLID, Dr("ID"), MatchType.Exact)
                    Names = DM.GetTB_InwardBlsNames
                    If Not Names Is Nothing Then
                        Names.Delete()
                    End If

                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_InwardBlsGoods.Columns.BLID, Dr("ID"), MatchType.Exact)
                    Goods = DM.GetTB_InwardBlsGoods
                    If Not Goods Is Nothing Then
                        Goods.Delete()
                    End If

                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_InwardCharges.Columns.BLID, Dr("ID"), MatchType.Exact)
                    Chgs = DM.GetTB_InwardChargesCollection
                    If Not Chgs Is Nothing Then
                        Drs = DM.DataSet.Tables("TB_InwardCharges").Select("BLID = '" & Dr("ID").ToString & "'")
                        For Each xDr As DataRow In Drs
                            xDr.Delete()
                        Next
                    End If

                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, Dr("ID"), MatchType.Exact)
                    Cns = DM.GetTB_InwardCntrsCollection
                    If Not Cns Is Nothing Then
                        Drs = DM.DataSet.Tables("TB_InwardCntrs").Select("BLID = '" & Dr("ID").ToString & "'")
                        For Each xDr As DataRow In Drs
                            xDr.Delete()
                        Next
                    End If
                    DM.CommitAll()
                End If

                Drs = DS.Tables("TB_InwardBlsGoods").Select("BLID = '" & Dr("ID").ToString & "'")
                If Not Drs Is Nothing Then
                    NewDr = DM.DataSet.Tables("TB_InwardBlsGoods").NewRow
                    For Each Col As DataColumn In Drs(0).Table.Columns
                        Try
                            NewDr(Col.ColumnName) = Drs(0).Item(Col.ColumnName)
                        Catch ex As Exception
                        End Try
                    Next
                    DM.DataSet.Tables("TB_InwardBlsGoods").Rows.Add(NewDr)
                End If

                Drs = DS.Tables("TB_InwardBlsNames").Select("BLID = '" & Dr("ID").ToString & "'")
                If Not Drs Is Nothing Then
                    NewDr = DM.DataSet.Tables("TB_InwardBlsNames").NewRow
                    For Each Col As DataColumn In Drs(0).Table.Columns
                        Try
                            NewDr(Col.ColumnName) = Drs(0).Item(Col.ColumnName)
                        Catch ex As Exception
                        End Try
                    Next
                    DM.DataSet.Tables("TB_InwardBlsNames").Rows.Add(NewDr)
                End If

                Drs = DS.Tables("TB_InwardCntrs").Select("BLID = '" & Dr("ID").ToString & "'")
                If Not Drs Is Nothing Then
                    For Each xDr As DataRow In Drs
                        NewDr = DM.DataSet.Tables("TB_InwardCntrs").NewRow
                        For Each Col As DataColumn In Drs(0).Table.Columns
                            Try
                                NewDr(Col.ColumnName) = xDr.Item(Col.ColumnName)
                            Catch ex As Exception
                            End Try
                        Next
                        DM.DataSet.Tables("TB_InwardCntrs").Rows.Add(NewDr)
                    Next
                End If
                ResultDr = TBresult.Select("ID = '" & Dr("ID") & "'")
                Try
                    DM.CommitAll()
                    ResultDr(0).Item("Result") = "Success"
                    ResultDr(0).RowError = ""
                Catch ex As Exception
                    ResultDr(0).Item("Result") = "Failed"
                    ResultDr(0).RowError = ex.ToString
                End Try
            Next

        End If

    End Sub

    Private Function FixStrLen(ByVal sStr As String, ByVal nLen As Byte, ByVal RemoveLSpace As Boolean) As String

        Dim sAns As String

        If RemoveLSpace = True Then
            sAns = Trim(sStr)
        Else
            sAns = RTrim(sStr)
        End If

        If Len(sAns) > nLen Then
            Return sAns
            Exit Function
        End If

        If Len(sAns) = nLen Then
            Return sAns
        Else
            If sAns = "" Then
                Return Space(nLen)
            Else
                Return sAns + Space(nLen - Len(sAns))
            End If
        End If

    End Function

End Class
