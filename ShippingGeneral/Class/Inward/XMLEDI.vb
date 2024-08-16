Imports OrmLib
Imports ShippingBiz
Imports System.Io
Imports System.Text
Public Class XMLEDI

    Public Event RecordSkip()
    Public Event GenrateStart()
    Private DM As DataManager
    Private TotalRec As Int32
    Private Bls As TB_InwardBLS
    Private Cns As New TB_InwardCntrsCollection
    Private Cn As TB_InwardCntrs
    Private Goods As TB_InwardBlsGoods
    Private Names As TB_InwardBlsNames
    Private Imco As TB_InwardCnsImcoCollection
    Private TBPorts As DataTable
    Private CurrentRecNo As Int32
    Private DS As New DataSet

    Public Sub GenEDIInXml(ByVal SelTable As DataTable, ByVal Ports As DataTable, ByVal VoyageID As String, ByVal FleName As String)

        Dim Co As TB_Company
        Dim Line As TB_Lines
        Dim Vsl As TB_Vessels
        Dim VOY As TB_Voyage
        Dim DummyImco As TB_InwardCnsImcoCollection
        Dim Imcos As TB_InwardCnsImcoCollection
        Dim Pkgs As TB_InwardCnsPkgsCollection

        Dim SOFs As TB_SOFCollection
        Dim Codes As TB_CODECollection
        Dim Temp As TB_InwardCnsTempratureCollection
        Dim DummyTemp As TB_InwardCnsTempratureCollection

        Dim aTables() As String = {"TB_InwardBls", "Tb_InwardBlsNames", "TB_InwardBlsGoods", "TB_InwardCharges", "Tb_InwardCntrs", "TB_InwardCnsImco", "TB_InwardCnsTemprature", "TB_InwardCnsPkgs"}
        Dim sSql As String
        Dim lResult As Boolean


        Dim TVessel As New DataTable
        Dim Tmp As New DataTable
        Dim NewDr As DataRow
        Dim Dr As DataRow
        Dim nI As Int16
        Dim TTLGW As Double = 0
        Dim TTLPkgs As Long
        Dim PkgCode As String = ""
        Dim MyDs As DataSet
        Dim aErrorList As New ArrayList


        Dim SB As New StringBuilder
        Dim Sr As New StreamWriter(FleName)
        Dim Drs() As DataRow

        TBPorts = Ports
        Drs = SelTable.Select("Select = 1", "")
        TotalRec = Drs.Length
        RaiseEvent GenrateStart()

        'Dv = New DataView(Me.GridResult.DataSource, "Select = 1", "", DataViewRowState.CurrentRows)
        'Me.ProgressBar.Maximum = Dv.Count
        'Me.ProgressBar.Value = 0

        If Drs.Length = 0 Then
            MsgBoxGeneral("No Any Selection !", "Data Requird")
            Exit Sub
        End If

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyageID, MatchType.Exact)
        VOY = DM.GetTB_Voyage

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, VoyageID, MatchType.Exact)
        SOFs = DM.GetTB_SOFCollection

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, VOY.VesselID, MatchType.Exact)
        Vsl = DM.GetTB_Vessels

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        Line = DM.GetTB_Lines

        DM.QueryCriteria.Clear()
        Co = DM.GetTB_Company

        InitDsXml()

        Sr.Write("<?xml version=" & """" & "1.0" & """" & " standalone=" & """" & "yes" & """" & "?>")
        Sr.Write("<Manifest>")



        For Each Dr In SelTable.Rows
            Try
                If Dr("Select") = 1 Then

                    DM = New DataManager(My.Settings.DSN)
                    MyDs = StoredProcedures.SP_InwardAllDataByLineBlNo(CurrentShippingLine, Dr("BLNo"))
                    DM.PopulateObjectsFromDataSet(MyDs, aTables)

                    For nI = 0 To aTables.Length - 1
                        DM.DataSet.Tables(aTables(nI)).Merge(MyDs.Tables(nI))
                    Next

                    If DM.DataSet.Tables("TB_InwardBls").Rows.Count > 0 Then
                        Bls = DM.GetTB_InwardBLSCollectionFromDataSet(0)
                        Cns = DM.GetTB_InwardCntrsCollectionFromDataSet
                        Names = DM.GetTB_InwardBlsNamesCollectionFromDataSet(0)
                        Goods = DM.GetTB_InwardBlsGoodsCollectionFromDataSet(0)
                        Imcos = DM.GetTB_InwardCnsImcoCollectionFromDataSet
                        Temp = DM.GetTB_InwardCnsTempratureCollectionFromDataSet
                        Pkgs = DM.GetTB_InwardCnsPkgsCollectionFromDataSet
                        TTLGW = 0
                    End If

                    NewDr = DS.Tables(0).NewRow
                    NewDr("BlNO") = Bls.BlNo
                    NewDr("FK_POL") = Replace(GetEDIPORT(NullToValue(Bls.POL, "")), " ", "")
                    NewDr("FK_POD") = Replace(GetEDIPORT(NullToValue(Bls.POD, "")), " ", "")
                    NewDr("FK_PlaceOfIssue") = Replace(GetEDIPORT(NullToValue(Bls.POL, "")), " ", "")
                    NewDr("FK_OriginPort") = Replace(GetEDIPORT(NullToValue(Bls.POL, "")), " ", "")
                    NewDr("FK_DestinationPort") = Replace(GetEDIPORT(NullToValue(Bls.POD, "")), " ", "")
                    NewDr("FK_POT") = Replace(GetEDIPORT(NullToValue(Bls.POT, "")), " ", "")
                    NewDr("IsDirectDelivery") = False
                    NewDr("IssueDate") = Format(Now, "yyyy/MM/dd hh:mm")
                    NewDr("SailedDate") = Format(Now, "yyyy/MM/dd hh:mm")
                    NewDr("FK_ShipmentType") = NewTCTSShipmentType(Bls.BLStatus)

                    If Not Goods Is Nothing Then
                        NewDr("GoodsDesc") = CleanStr(UCase(Goods.Goods))
                    End If

                    If Not Names Is Nothing Then
                        NewDr("Consignee") = CleanStr(UCase(Names.Cnee))
                        NewDr("Shipper") = "Gest"
                        NewDr("Notify") = CleanStr(UCase(Names.Notify1))
                    End If

                    DS.Tables(0).Rows.Add(NewDr)
                    Sr.Write("<BL>")
                    Sr.Write(DataRowToXml(NewDr))
                    Sr.Write("<Containers>")

                    For Each Cn In Cns

                        NewDr = DS.Tables(1).NewRow
                        NewDr("ContainerNo") = Cn.CntrNo
                        NewDr("SealNo") = CleanStr(UCase(Cn.SealNo))
                        NewDr("Status") = 1
                        NewDr("FK_ContainerSize") = TCTSCnSize(Cn.CnSize)
                        NewDr("FK_ContainerType") = TCTSCnType(Cn.CnType)
                        NewDr("TareWeight") = Cn.TW
                        NewDr("ISLCL") = IIf(Cn.FLE = "L", 1, 0)
                        NewDr("GrossWeight") = Double.Parse(Cn.GW)
                        NewDr("ISSOC") = IIf(Cn.SOC = "Y", 1, 0)

                        If Cn.IsOOG = True Then
                            NewDr("ISOG") = 1
                        Else
                            NewDr("ISOG") = 0
                        End If

                        DummyImco = Imcos.FilterByCntrID(Cn.ID, lResult)
                        NewDr("IsDG") = 0

                        If Not DummyImco Is Nothing Then
                            If DummyImco.Count > 0 Then
                                NewDr("FK_IMDGClass") = DummyImco(0).IMDGCode ' TCTSIMCO(DummyImco(0).IMDGCode)
                                NewDr("PageNo") = DummyImco(0).PageNumber
                                NewDr("FlashPoint") = DummyImco(0).FlashPoint
                                NewDr("IsDG") = 1
                            End If
                        End If

                        DummyTemp = Temp.FilterByCntrID(Cn.ID, lResult)
                        If Not DummyTemp Is Nothing Then
                            If DummyTemp.Count > 0 Then
                                NewDr("RFTemp") = DummyTemp(0).TempMin
                            End If
                        End If

                        PkgCode = "PK"
                        DM.QueryCriteria.Clear()
                        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PG", MatchType.Exact)
                        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, Cn.PackageType, MatchType.Exact)
                        Codes = DM.GetTB_CODECollection
                        If Not Codes Is Nothing Then
                            If Codes.Count > 0 Then
                                PkgCode = Codes(0).NextCode
                            End If
                        End If

                        NewDr("FK_PackageType") = PkgCode '  TCTSPAckageType(Cn.PackageType)
                        TTLPkgs = Cn.NoOFPkgs
                        For Each Pk As TB_InwardCnsPkgs In Pkgs
                            TTLPkgs += NullToValue(Pk.NoOFPkgs, 0)
                        Next

                        NewDr("NoPackage") = TTLPkgs
                        DS.Tables(1).Rows.Add(NewDr)
                        Sr.Write("<Container>")
                        Sr.Write(DataRowToXml(NewDr))
                        Sr.Write("</Container>")

                    Next
                    Sr.Write("</Containers>")
                    Sr.Write("</BL>")
                    CurrentRecNo += 1
                    RaiseEvent RecordSkip()
                End If
            Catch ex As Exception
                aErrorList.Add(Dr("BlNo"))
                MsgBox("Error On B/L Number " & Dr("BlNo"), MsgBoxStyle.Critical)
                MsgBox(ex.ToString)
            End Try

        Next
        Sr.Write("</Manifest>")
        If aErrorList.Count = 0 Then
            MsgBox("Generate XML Successful")
        Else
            MsgBox("No Of skiped B/Ls  " & aErrorList.Count)
        End If

        Sr.Flush()
        Sr.Close()

    End Sub

    Private Function GetEDIPORT(ByVal PortCode As String)

        Dim Drs() As DataRow
        Dim sPort As String
        Drs = TBPorts.Select("OurPort = '" & PortCode & "'")
        If Drs.Length > 0 Then
            sPort = NullToValue(Drs(0).Item("EDIIPPORT"), PortCode)
        Else
            sPort = PortCode
        End If
        Return Trim(Mid(sPort, 1, 2) & " " & Mid(sPort, 3))

    End Function
   
    Private Function NewTCTSShipmentType(ByVal sType As String) As String

        '  Return sType

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

    Private Function DataRowToXml(ByVal dr As DataRow)

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
            Case Else
                Return "200"
        End Select

    End Function

    Private Sub InitDsXml()

        Dim Tb As DataTable

        DS = New DataSet
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
        Tb.Columns.Add(New DataColumn("FK_PackageType"))
        Tb.Columns.Add(New DataColumn("FK_ContainerSize"))
        Tb.Columns.Add(New DataColumn("FK_ContainerType"))
        Tb.Columns.Add(New DataColumn("IsSOC"))
        Tb.Columns.Add(New DataColumn("TareWeight"))
        Tb.Columns.Add(New DataColumn("IsLCL"))
        Tb.Columns.Add(New DataColumn("IsDG"))
        Tb.Columns.Add(New DataColumn("IsOG"))
        DS.Tables.Add(Tb)

    End Sub

    Public ReadOnly Property RecordCount() As Int32
        Get
            Return TotalRec
        End Get
    End Property

    Public ReadOnly Property RecordNo() As Int32
        Get
            Return CurrentRecNo
        End Get
    End Property

End Class
