Imports OrmLib
Imports Shippingbiz
Public Class Copran

    Private CoparnDS As New DataSet
    Private Ports As DataTable
    Public Sub GererateCOPARN(ByVal FleName As String, ByVal IsCOC As Boolean)

        Dim MessageString As String = ""
        Dim NumberOfSegment As Integer = 0
        Dim BL As DataRow
        Dim Cn As DataRow
        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim I As Long
        Dim Ds As DataSet = CoparnDS
        Dim Code As TB_CODE
        Dim Dm As DataManager

        If Ds.Tables("Header").Rows.Count = 0 Then
            Throw New System.Exception("The Header of message has not row or has more than a row")
        End If

        If Ds.Tables("BLs").Rows.Count = 0 Then
            Throw New System.Exception("BL empty")
        End If

        If Ds.Tables("BLContainer").Rows.Count = 0 Then
            Throw New System.Exception("BL container empty")
        End If

        If Ds.Tables("Containers").Rows.Count = 0 Then
            Throw New System.Exception("container empty")
        End If

        Dim strVoyage As String = Ds.Tables("Header").Rows(0).Item("VoyageNo").ToString()
        Dim strSender As String = Ds.Tables("Header").Rows(0).Item("Sender").ToString()
        Dim strReciveer As String = Ds.Tables("Header").Rows(0).Item("Receiver").ToString()
        Dim strVesselName As String = Ds.Tables("Header").Rows(0).Item("VesselName").ToString()
        Dim strVesselLine As String = Ds.Tables("Header").Rows(0).Item("VesselLine").ToString()
        Dim strVesselAgent As String = Ds.Tables("Header").Rows(0).Item("Sender").ToString()
        Dim strMessageDate As String = Format(Date.Now, "yyyyMMdd")
        Dim strMessageTime As String = Format(Date.Now, "HHmm")
        Dim strMessageNo As String = Ds.Tables("Header").Rows(0).Item("MessageNo").ToString()
        Dim strNationality As String = Ds.Tables("Header").Rows(0).Item("Nationality").ToString()
        Dim strVoyageType As String = Ds.Tables("Header").Rows(0).Item("VoyageType").ToString()
        Dim strVesselPOD As String = Ds.Tables("Header").Rows(0).Item("POD").ToString()
        Dim strVesselPOL As String = Ds.Tables("Header").Rows(0).Item("POL").ToString()
        Dim strArrivalDate As String = Format(Ds.Tables("Header").Rows(0).Item("ArrivalDate"), "yyyyMMdd")
        Dim strDepartureDate As String = Format(Ds.Tables("Header").Rows(0).Item("DepartureDate"), "yyyyMMdd")

        MessageString = "UNB+UNOA:2+" + strSender + "++" + strMessageDate + ":" + strMessageTime + "+" + strMessageNo + "+++H'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "UNH+1+COPARN:D:00A:UN'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "BGM+27+" + strMessageNo + "+9+AB'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "RFF+ZZZ'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "TDT+20+" + strVoyage + "+1+" + strVoyageType + "++++:103::" + strVesselName + ":" + strNationality + "'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "LOC+9+" + strVesselPOL + ":139:6'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "LOC+11+" + strVesselPOD + ":139:6'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "DTM+132:" + strArrivalDate + ":102'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "DTM+133:" + strDepartureDate + ":102'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "NAD+CA+++" + strVesselAgent + "'"
        NumberOfSegment = NumberOfSegment + 1
        MessageString = MessageString + "NAD+CG+++" + strVesselAgent + "'"
        NumberOfSegment = NumberOfSegment + 1

        'Bill of Lading Information 

        For Each BL In Ds.Tables("BLS").Rows
            Dim strBL As String = BL.Item("BL").ToString()
            Dim strGoodsDescription As String = BL.Item("GoodsDescription").ToString()
            Dim strHSCode As String = BL.Item("HSCode").ToString()
            Dim strNoOfPackageBL As String = BL.Item("NoOfPackage").ToString()
            Dim strPackageTypeCode As String = BL.Item("PackageTypeCode").ToString()
            Dim strPackageTypeDescription As String = BL.Item("PackageTypeDescription").ToString()
            Dim strGrossWeight As String = BL.Item("GrossWeight").ToString()
            Dim strConsignee As String = BL.Item("Consignee").ToString()
            Dim strConsigneeAdd As String = BL.Item("ConsigneeAdd").ToString()
            Dim strConsigneeNationalID As String = String.Empty
            Dim CneeDOB As String = String.Empty

            Dim sSql As String
            Dim lResult As Boolean
            Dim TB As New DataTable
            Dim TB2 As New DataTable
            Dim TB3 As New DataTable

            sSql = "select (select top 1 NationalID  from tb_clients where id = clientid and NationalID <> '') as NationalID from tb_inwardbls where blno = '" & BL.Item("BL").ToString() & "'"
            TableBySql(sSql, TB, lResult)


            If TB.Rows.Count > 0 Then
                If Not IsDBNull(TB.Rows(0).Item("NationalID")) Or TB.Rows(0).Item("NationalID").ToString() = "NULL" Then
                    strConsigneeNationalID = TB.Rows(0).Item("NationalID").ToString()

                Else
                    sSql = "select (select top 1 Nationalcode  from tb_clients where id = clientid) as Nationalcode from tb_inwardbls where blno = '" & BL.Item("BL").ToString() & "'"
                    TableBySql(sSql, TB, lResult)
                    If TB.Rows.Count > 0 Then
                        strConsigneeNationalID = TB.Rows(0).Item("Nationalcode").ToString()
                    Else
                        strConsigneeNationalID = ""
                    End If
                End If

            else
                sSql = "select (select top 1 Nationalcode  from tb_clients where id = clientid) as Nationalcode from tb_inwardbls where blno = '" & BL.Item("BL").ToString() & "'"
                TableBySql(sSql, TB, lResult)
                If TB.Rows.Count > 0 Then
                    strConsigneeNationalID = TB.Rows(0).Item("Nationalcode").ToString()
                Else
                    strConsigneeNationalID = ""
                End If
            End If

            sSql = "select (select top 1 DOB  from tb_clients where id = clientid) as DOB from tb_inwardbls where blno = '" & BL.Item("BL").ToString() & "'"
            TableBySql(sSql, TB3, lResult)
            If TB.Rows.Count > 0 And Not TB3.Rows(0).Item("DOB").ToString = "" Then
                CneeDOB = Format(TB3.Rows(0).Item("DOB"), "yyyyMMdd")
            Else
                CneeDOB = ""
            End If


            Dim strShipper As String = BL.Item("Shipper").ToString()
            Dim strNotify As String = BL.Item("Notify").ToString()

            'GID0 : GID+GoodsItemNumber+NumberofPackages:TypeofPackagesIdentification::CodeListResponsibleAgency,Coded:TypeofPackages 
            MessageString = MessageString + "GID+" + (I + 1).ToString() + "+" + strNoOfPackageBL + ":" + strPackageTypeCode + "::9:" + strPackageTypeDescription + "'"

            NumberOfSegment = NumberOfSegment + 1

            'appu
            'FTX3 : FTX+TextSubjectQualifier+++TextLiteral 
            MessageString = MessageString + "FTX+AAA+++" + strGoodsDescription + "'"
            NumberOfSegment = NumberOfSegment + 1

            ''appu
            ''FTX3 : FTX+TextSubjectQualifier+++TextLiteral 
            'MessageString = MessageString + "FTX+AAA+++" + "" + "'"
            'NumberOfSegment = NumberOfSegment + 1

            'appu
            'PIA : FTX+TextSubjectQualifier+++TextLiteral 
            MessageString = MessageString + "PIA+1+" + strHSCode + "'"
            NumberOfSegment = NumberOfSegment + 1

            'RFF3 : RFF+ReferenceQualifier:GoodsDeclarationNumber 

            sSql = "select top 1 IssueDate, RegNo from tb_inwardbls where blno = '" & BL.Item("BL").ToString() & "'"
            TableBySql(sSql, TB, lResult)
            If TB.Rows.Count > 0 Then
                MessageString = MessageString + "RFF+BM:" + strBL + NullToValue(TB.Rows(0).Item("RegNo").ToString(), "") + "'"
                NumberOfSegment = NumberOfSegment + 1
                MessageString = MessageString + "DTM+199:" + Format(TB.Rows(0).Item("IssueDate"), "yyyyMMdd") + ":201'"
            Else
                'MessageString = MessageString + "RFF+BM:" + strBL + "+" + "'"
                MessageString = MessageString + "RFF+BM:" + strBL + "'"
                NumberOfSegment = NumberOfSegment + 1
                MessageString = MessageString + "DTM+199:" + Format(TB.Rows(0).Item("IssueDate"), "yyyyMMdd") + ":201'"
            End If
            'MessageString = MessageString + "RFF+BM:" + strBL + "+" + NullToValue(TB.Rows(0).Item("Nationalcode").ToString(), "") + "'"
            NumberOfSegment = NumberOfSegment + 1

            'NAD3 : NAD+PartyQualifier+++Name&Address 
            MessageString = MessageString + "NAD+CN++" + strConsigneeNationalID + "+" + strConsignee + "+" + strConsigneeAdd + "'"
            NumberOfSegment = NumberOfSegment + 1
            If Not CneeDOB = "" Then
                MessageString = MessageString + "DTM+200:" + CneeDOB + ":201'"
                NumberOfSegment = NumberOfSegment + 1
            End If

            MessageString = MessageString + "NAD+CZ+++" + strShipper + "'"
            NumberOfSegment = NumberOfSegment + 1
            MessageString = MessageString + "NAD+NI+++" + strNotify + "'"
            NumberOfSegment = NumberOfSegment + 1

            'MEA3 : MEA+MeasrmentApplicationQualifier+MeasurementDimension,Coded+MeasureUnitQualifier:MeasurementValue 
            MessageString = MessageString + "MEA+AAE+G+KGM:" + strGrossWeight + "'"
            NumberOfSegment = NumberOfSegment + 1
            Drs = Ds.Tables("BLContainer").Select("BL = '" + strBL + "'")
            If Drs.Length = 0 Then
                Throw New System.Exception("bl has not container")
            End If
            For Each Dr In Drs
                Dim strContainerBL As String = Dr("ContainerNo").ToString()
                Dim NoOfPackageContainer As String = Dr("NumOfPackage").ToString()
                Dim strNetWeight = Dr("NetWeight").ToString()
                'SGP3 : SGP+EquipmentIdentificationNumber+NumberofPackages(Stowed in the item of equipment) 
                MessageString = MessageString + "SGP+" + strContainerBL + "+" + NoOfPackageContainer + "'"
                NumberOfSegment = NumberOfSegment + 1
                'MEA5 : MEA+MeasurementApplicationQualifier+MeasurementDimension,coded+MeasureUnitQualifier:MeasurementValue 
                MessageString = MessageString + "MEA+AAE+G+KGM:" + strNetWeight + "'"
                NumberOfSegment = NumberOfSegment + 1
                'appu - multiple package details added
                sSql = "select IMDGCode, GW, convert(decimal(10, 0), NoOfPkgs) NoOfPkgs from TB_InwardCnsPkgs where CntrID = '" & Dr("cntrid").ToString() & "'"
                TableBySql(sSql, TB, lResult)
                If TB.Rows.Count > 0 Then
                    Dim pk As DataRow
                    MessageString = MessageString + "CPID+"
                    For Each pk In TB.Rows
                        MessageString = MessageString + pk.Item("IMDGCode").ToString() + ":" + pk.Item("GW").ToString() + ":" + pk.Item("NoOfpkgs").ToString() + "+"
                    Next

                    If MessageString(MessageString.Length - 1) = "+" Then
                        MessageString = MessageString.Remove(MessageString.Length - 1, 1)
                    End If
                    MessageString = MessageString + "'"
                End If
            Next
        Next

        'Container Information 
        For Each Cn In Ds.Tables("Containers").Rows

            Dim strContainer As String = Cn.Item("ContainerNo").ToString()
            Dim strSizeType As String = Cn.Item("ContainerSizeType").ToString()
            Dim strShipment As String = Cn.Item("ShipmentType").ToString()
            Dim strContainerStatus As String = Cn.Item("ContainerStatus").ToString()
            Dim strMovementType As String = Cn.Item("MovementType").ToString()
            Dim strPOD As String = Cn.Item("POD").ToString()
            Dim strPOL As String = Cn.Item("POL").ToString()
            Dim strPOTransit As String = Cn.Item("POTransit").ToString()
            Dim strPOTranship As String = Cn.Item("POTranship").ToString()
            Dim strTareWeight As String = Cn.Item("TareWeight").ToString()
            Dim strSealNo As String = Cn.Item("SealNo").ToString()
            Dim strIMOClass As String = Cn.Item("IMOClass").ToString()
            Dim strHazardVersion As String = Cn.Item("HazardVersion").ToString()
            Dim strPageNo As String = Cn.Item("PageNumber").ToString()
            Dim strEquipmentFlashPoint As String = Cn.Item("EquipmentFlashPoint").ToString()
            Dim strFlashPointUnit As String = Cn.Item("FlashPointUnit").ToString()
            Dim strUNNumber As String = Cn.Item("UNNumber").ToString()

            Dim strPackingGroup As String = ""
            Dim strContainerOwner As String = Cn.Item("ContainerOwner").ToString()
            Dim strContainerAgent As String = Cn.Item("ContainerAgent").ToString()
            Dim StrTemprature As String = Cn.Item("Temprature")
            Dim StrTempratureUnit As String = Cn.Item("TempratureUnit")

            'EQD0 : EQD+EquipmentQualifier+EquipmentIdentificationNumber+:::EquipmentSizeandTypeIdentification++EquipmentStatus,Coded+Full/EmptyIndicator,Coded 
            MessageString = MessageString + "EQD+CN+" + strContainer + "+:::" + strSizeType + "++" + strShipment + "+" + strContainerStatus + "'"
            NumberOfSegment = NumberOfSegment + 1
            'RFF7 : RFF+ReferenceQualifier:ReferenceNumber 
            If strContainer.Length < 4 Then
                MessageString = MessageString + "RFF+CPR:" + strContainer + "'"
            Else
                MessageString = MessageString + "RFF+CPR:" + strContainer.Substring(0, 4) + "'"
            End If
            NumberOfSegment = NumberOfSegment + 1
            'TMD7 : TMD+MovementType,Coded 
            MessageString = MessageString + "TMD+" + strMovementType + "'"
            NumberOfSegment = NumberOfSegment + 1
            'Port of Loading 
            'LOC7 : LOC+Place/LocationQualifier+Place/LocationIdentification:CodeListQualifier:CodeListResponsibleAgency,Coded 
            MessageString = MessageString + "LOC+9+" + strPOL + ":139:6'"
            NumberOfSegment = NumberOfSegment + 1
            'Port of Discharge 
            MessageString = MessageString + "LOC+11+" + strPOD + ":139:6'"
            NumberOfSegment = NumberOfSegment + 1
            'Place of Transit or Tranship 

            'Must Revise 
            '-------------- 
            If strShipment = "6" Or strShipment = "1" Or strShipment = "5" Or strShipment = "4" Then
                MessageString = MessageString + "LOC+13+:139:6:" + strPOTransit + "'"
                NumberOfSegment = NumberOfSegment + 1
            End If
            ''-------------- 
            'MEA7 : MeasurementApplicationQualifier+MeasurementDimension,Coded+MeasurementUnitQualifier+MeasurementValue 
            MessageString = MessageString + "MEA+AAE+T+KGM:" + strTareWeight + "'"
            NumberOfSegment = NumberOfSegment + 1

            If StrTemprature <> "" Then
                MessageString = MessageString + "MEA+AAE+AAO+PCT:" + "" + "'"
                NumberOfSegment = NumberOfSegment + 1
                Dim sDummy As String = ""
                Dim Num As Long
                If Val(StrTemprature) < 0 Then
                    Num = Val(StrTemprature.Replace("-", ""))
                    sDummy = Format(Num, "000")
                Else
                    Num = Val(StrTemprature)
                    sDummy = "1" & Format(Num, "00")
                End If
                MessageString = MessageString + "TMP+2+" + "" + sDummy + ":CEL" + "'"
                NumberOfSegment = NumberOfSegment + 1

            End If
            'SEL7 : SEL+SealNumber+SealingParty,Coded+SealCondition,Coded 
            MessageString = MessageString + "SEL+" + strSealNo + "+SH+1'"
            NumberOfSegment = NumberOfSegment + 1
            'DGS7 : DGS+DangerousGoodsRegulations,Coded+HazardCode:HazardSubstance/Item/PageNumber:HazardCodeVersionNumber++DangerousGoodsFlashPoint:MeasureUnitQualifier+PackingGroup,Coded 
            If strIMOClass <> "" Then
                Dim TBt As DataTable
                Dim TBim As DataTable
                Dim lResult As Boolean
                Dim strSubsidaryHazard As String = ""
                Dim strPSN As String = ""
                Dim strMarinePollutant As String = ""

                TableBySql(" select pakinggroup, SubsidaryHazard,PSN, case when MarinePollutant = 'Y' then 'Yes' else 'No' end as MarinePollutant from tb_inwardcnsimco where cntrid = '" + Cn.Item("id") + "'", TBim, lResult)
                If TBim.Rows.Count > 0 Then
                    strSubsidaryHazard = TBim.Rows(0).Item("SubsidaryHazard").ToString()
                    strPSN = TBim.Rows(0).Item("PSN").ToString()
                    strMarinePollutant = TBim.Rows(0).Item("MarinePollutant").ToString()
                    strPackingGroup = TBim.Rows(0).Item("pakinggroup").ToString()
                End If
                'new code comtd for deployment - code under testing 
                MessageString = MessageString + "DGS+IMD+" + strIMOClass + ":" + strSubsidaryHazard + "+" + strUNNumber + "+" + strEquipmentFlashPoint + ":" + strFlashPointUnit + "+" + strPackingGroup + "'"
               
                ' testing code ' MessageString = MessageString + "DGS+IMD+" + strIMOClass + ":" + strPageNo + ":" + strHazardVersion + "++" + strEquipmentFlashPoint + ":" + strFlashPointUnit + "+" + strPackingGroup + "'"
                NumberOfSegment = NumberOfSegment + 1
                'new code comtd for deployment - code under testing '
                 Dim strTechinicalName As String
                TableBySql("Select ltrim(SUBSTRING(Meaning,CHARINDEX('-',Meaning)+1,LEN(Meaning))) Meaning From TB_Code Where GroupCode = 'HZ' and StdCode = '" + strIMOClass + "'", TBt, lResult)
                If TBt.Rows.Count > 0 Then
                    strTechinicalName = TBt.Rows(0).Item("Meaning").ToString()
                End If

                MessageString = MessageString + "FTX+AAD+P+" + strTechinicalName + "'"
                NumberOfSegment = NumberOfSegment + 1
                'new code comtd for deployment - code under testing
            End If
            'NAD7 : NAD+PartyQualifier+++Name&Address 
            'Container Owner 
            'cFile.Write "NAD+EO+++" & vContainerOwner + "'" 
            MessageString = MessageString + "NAD+EO+++" + strContainerOwner + "'"
            NumberOfSegment = NumberOfSegment + 1
            'Container Agent 
            'cFile.Write "NAD+AG+++" & vContainerAgent + "'" 
            MessageString = MessageString + "NAD+AG+++" + strContainerAgent + "'"
            NumberOfSegment = NumberOfSegment + 1
        Next
        'CNT : CNT+ControlQualifier:ControlVlaue 
        MessageString = MessageString + "CNT+16:" + Ds.Tables("Containers").Rows.Count.ToString() + "'"
        NumberOfSegment = NumberOfSegment + 1
        'UNT : UNT+Number of Segments in a message+Message Reference Number 
        MessageString = MessageString + "UNT+" + NumberOfSegment.ToString() + "+1'"
        'UNZ : UNZ+1+MessageNumber 
        MessageString = MessageString + "UNZ+1+" + strMessageNo + "'"

        Dim SW As New System.IO.StreamWriter(FleName)
        SW.Write(MessageString)
        SW.Flush()
        SW.Close()

    End Sub

    Public Sub CreateDataset(ByVal VoyageID As String, ByVal Drs() As DataRow, ByVal IsSOC As Boolean)

        Dim Tb As DataTable
        Dim Dm As New DataManager(My.Settings.DSN)
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim NewCn As DataRow
        Dim S As String
        Dim CnDrs() As DataRow
        Dim SOF As TB_SOF
        Dim Code As TB_CODE


        Dim Voy As TB_Voyage
        Dim Vsl As TB_Vessels

        Dim BLS As TB_InwardBLSCollection
        Dim BL As TB_InwardBLS

        Dim Names As TB_InwardBlsNames
        Dim Goods As TB_InwardBlsGoods
        Dim Goods2 As TB_InwardCnsPkgs
        Dim Cn As TB_InwardCntrs
        Dim Cns As TB_InwardCntrsCollection

        Dim Imco As TB_InwardCnsImco
        Dim Line As TB_Lines
        Dim RF As TB_InwardCnsTemprature

        Dim PkgCode As String

        Tb = New DataTable("Header")

        Try

            With Tb
                .Columns.Add(New DataColumn("MessageNo"))
                .Columns.Add(New DataColumn("MessageDateTime", System.Type.GetType("System.DateTime")))
                .Columns.Add(New DataColumn("Sender"))
                .Columns.Add(New DataColumn("Receiver"))
                .Columns.Add(New DataColumn("VesselName"))
                .Columns.Add(New DataColumn("VoyageNo"))
                .Columns.Add(New DataColumn("ArrivalDate", System.Type.GetType("System.DateTime")))
                .Columns.Add(New DataColumn("DepartureDate", System.Type.GetType("System.DateTime")))
                .Columns.Add(New DataColumn("VesselAgent"))
                .Columns.Add(New DataColumn("VesselLine"))
                .Columns.Add(New DataColumn("POL"))
                .Columns.Add(New DataColumn("POD"))
                .Columns.Add(New DataColumn("Nationality"))
                .Columns.Add(New DataColumn("VoyageType"))
            End With
            CoparnDS.Tables.Add(Tb)

            Tb = New DataTable("BLS")
            With Tb
                .Columns.Add(New DataColumn("BL"))
                .Columns.Add(New DataColumn("Consignee"))
                .Columns.Add(New DataColumn("ConsigneeAdd"))
                .Columns.Add(New DataColumn("Shipper"))
                .Columns.Add(New DataColumn("Notify"))
                .Columns.Add(New DataColumn("GoodsDescription"))
                .Columns.Add(New DataColumn("HSCode"))
                .Columns.Add(New DataColumn("PackageTypeCode"))
                .Columns.Add(New DataColumn("PackageTypeDescription"))
                .Columns.Add(New DataColumn("NoOfPackage", System.Type.GetType("System.Int32")))
                .Columns.Add(New DataColumn("GrossWeight", System.Type.GetType("System.Double")))
            End With
            CoparnDS.Tables.Add(Tb)

            Tb = New DataTable("Containers")
            With Tb
                .Columns.Add(New DataColumn("ContainerNo"))
                .Columns.Add(New DataColumn("ContainerSizeType"))
                .Columns.Add(New DataColumn("ContainerStatus"))
                .Columns.Add(New DataColumn("SealNo"))
                .Columns.Add(New DataColumn("ShipmentType"))
                .Columns.Add(New DataColumn("MovementType"))
                .Columns.Add(New DataColumn("TareWeight", System.Type.GetType("System.Int32")))
                .Columns.Add(New DataColumn("POL"))
                .Columns.Add(New DataColumn("POD"))
                .Columns.Add(New DataColumn("POTransit"))
                .Columns.Add(New DataColumn("POTranship"))
                .Columns.Add(New DataColumn("IMOClass"))
                .Columns.Add(New DataColumn("UNNumber"))
                .Columns.Add(New DataColumn("PageNumber"))
                .Columns.Add(New DataColumn("EquipmentFlashPoint"))
                .Columns.Add(New DataColumn("FlashPointUnit"))
                .Columns.Add(New DataColumn("HazardVersion"))
                .Columns.Add(New DataColumn("TempratureUnit"))
                .Columns.Add(New DataColumn("Temprature"))
                .Columns.Add(New DataColumn("ContainerOwner"))
                .Columns.Add(New DataColumn("ContainerAgent"))
                .Columns.Add(New DataColumn("IsOG"))
                .Columns.Add(New DataColumn("id"))

            End With
            CoparnDS.Tables.Add(Tb)


            Tb = New DataTable("BLContainer")
            With Tb
                .Columns.Add(New DataColumn("BL"))
                .Columns.Add(New DataColumn("ContainerNo"))
                .Columns.Add(New DataColumn("NumOfPackage", System.Type.GetType("System.Int32")))
                .Columns.Add(New DataColumn("NetWeight", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("cntrid"))
            End With
            CoparnDS.Tables.Add(Tb)

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortCode, "", MatchType.Not)
            Dm.GetTB_Ports()
            Ports = Dm.DataSet.Tables("TB_PORTS")

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyageID, MatchType.Exact)
            Voy = Dm.GetTB_Voyage

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
            Vsl = Dm.GetTB_Vessels

            For Each Dr In Drs

                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, Dr("Line"), MatchType.Exact)
                Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Dr("BlNo"), MatchType.Exact)
                BL = Dm.GetTB_InwardBLS

                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_InwardBlsNames.Columns.BLID, BL.ID, MatchType.Exact)
                Names = Dm.GetTB_InwardBlsNames

                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_InwardBlsGoods.Columns.BLID, BL.ID, MatchType.Exact)
                Goods = Dm.GetTB_InwardBlsGoods

                

                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, BL.ID, MatchType.Exact)
                If IsSOC = True Then
                    Dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.SOC, "Y", MatchType.Exact)
                Else
                    Dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.SOC, "N", MatchType.Exact)
                End If
                Cns = Dm.GetTB_InwardCntrsCollection

                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
                Line = Dm.GetTB_Lines

                NewDr = CoparnDS.Tables("BLS").NewRow

                NewDr("BL") = BL.BlNo
                NewDr("Consignee") = CleanStr(Names.Cnee)
                NewDr("ConsigneeAdd") = CleanStr(Names.CneeAdd)
                NewDr("Shipper") = "GEST"
                NewDr("Notify") = CleanStr(Names.Notify1)

                ' appu - map direct edi change
                Dim sSql As String
                Dim IResult As Boolean
                Dim dtPackages As New System.Data.DataTable

                sSql = "select top 1 imdgcode from  [TB_InwardCnsPkgs] left join TB_InwardCntrs on TB_InwardCntrs.id = [TB_InwardCnsPkgs].cntrid where TB_InwardCntrs.blid = '" & BL.ID.ToString() & "'"
                TableBySql(sSql, dtPackages, IResult)
                Dim HsCode As String
                HsCode = ""
                If Not dtPackages.Rows.Count = 0 Then
                    For Each Dr2 As DataRow In dtPackages.Rows
                        HsCode = HsCode + Dr2(0).ToString()
                        If Not dtPackages.Rows.Count = 0 Then
                            HsCode = HsCode + ","
                        End If
                    Next
                    HsCode = HsCode.Trim(",")
                    HsCode = HsCode + ":HS"
                End If

                NewDr("HSCode") = HsCode
                NewDr("GoodsDescription") = CleanStr(Goods.Goods)
                PkgCode = "PK"
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "PG", MatchType.Exact)
                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, Cns(0).PackageType, MatchType.Exact)
                Code = Dm.GetTB_CODE
                If Not Code Is Nothing Then
                    PkgCode = Code.NextCode
                End If
                NewDr("PackageTypeCode") = PkgCode
                NewDr("PackageTypeDescription") = GetMeaningCode("PG", Cns(0).PackageType)
                NewDr("NoOfPackage") = Int32.Parse(Goods.TTLPkgs)
                NewDr("GrossWeight") = Double.Parse(Goods.TGW)
                CoparnDS.Tables("BLS").Rows.Add(NewDr)

                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "ST", MatchType.Exact)
                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, BL.BLStatus, MatchType.Exact)
                Code = Dm.GetTB_CODE()


                For Each Cn In Cns
                    If Cn.CntrNo = "OOLU3653048" Then
                        Beep()
                    End If
                    NewDr = CoparnDS.Tables("BlContainer").NewRow
                    NewDr("BL") = BL.BlNo
                    NewDr("ContainerNo") = CntrFormat(Cn.CntrNo)
                    NewDr("NumOfPackage") = Int32.Parse(Cn.NoOFPkgs) 'IIf(Cn.SOC = "Y", Int32.Parse(Cn.NoOFPkgs) + 1, Int32.Parse(Cn.NoOFPkgs))
                    NewDr("NetWeight") = Double.Parse(Cn.GW) 'IIf(Cn.SOC = "Y", Double.Parse(Cn.GW + Cn.TW), Double.Parse(Cn.GW))
                    NewDr("CntrId") = Cn.ID.ToString 'IIf(Cn.SOC = "Y", Double.Parse(Cn.GW + Cn.TW), Double.Parse(Cn.GW))
                    CoparnDS.Tables("BlContainer").Rows.Add(NewDr)

                    CnDrs = CoparnDS.Tables("Containers").Select("ContainerNo = '" & CntrFormat(Cn.CntrNo) & "'")
                    If CnDrs.Length = 0 Then
                        NewDr = CoparnDS.Tables("Containers").NewRow
                        NewDr("ID") = Cn.ID
                        NewDr("ContainerNo") = CntrFormat(Cn.CntrNo)
                        NewDr("ContainerSizeType") = SizeTypeToTCTSISO(Cn.CnType, Cn.CnSize)

                        Try
                            If Not Cn.IsOOG.ToString = "Null" Then
                                If Cn.IsOOG = True Then
                                    ' Bad tidewater logic
                                    If Cn.CnSize = "20" Then
                                        NewDr("ContainerSizeType") = "2952"
                                    Else
                                        NewDr("ContainerSizeType") = "4952"
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox(BL.BlNo)
                            MsgBox(Cn.CntrNo)

                        End Try
                        NewDr("ContainerStatus") = IIf(Cn.FLE = "E", "4", "5")
                        NewDr("SealNo") = Cn.SealNo
                        NewDr("ShipmentType") = Code.NextCode
                        Select Case Code.NextCode
                            Case "0"
                                NewDr("ShipmentType") = "0"
                            Case "1"
                                NewDr("ShipmentType") = "3"
                            Case "2"
                                NewDr("ShipmentType") = "6"
                            Case "3"
                                NewDr("ShipmentType") = "2"
                            Case "4"
                                NewDr("ShipmentType") = "1"
                            Case "5"
                                NewDr("ShipmentType") = "5"
                            Case "6"
                                NewDr("ShipmentType") = "4"
                            Case "7"
                                NewDr("ShipmentType") = "7"
                        End Select
                        S = GetMeaningCode("VT", BL.FCLType)

                        'If Cn.FLE = "F" Or Cn.FLE = "E" Then
                        '    NewDr("MovementType") = "3"
                        'Else
                        '    NewDr("MovementType") = "2"
                        'End If
                        Select Case S

                            Case "LCL/LCL"
                                NewDr("MovementType") = "2"
                            Case "FCL/FCL"
                                NewDr("MovementType") = "3"
                            Case "FCL/LCL"
                                NewDr("MovementType") = "4"
                            Case "LCL/FCL"
                                NewDr("MovementType") = "5"
                        End Select
                        NewDr("TareWeight") = Int32.Parse(Cn.TW)
                        NewDr("POL") = GetEDIPORT(BL.POL)
                        NewDr("POD") = GetEDIPORT(BL.POD)
                        NewDr("POTransit") = GetEDIPORT(BL.POT)
                        NewDr("POTranship") = GetEDIPORT(BL.POT)
                        NewDr("ContainerOwner") = Line.EDICode
                        NewDr("ContainerAgent") = CurrentCompany.EDICODE
                        Dm.QueryCriteria.Clear()
                        Dm.QueryCriteria.And(JoinPath.TB_InwardCnsImco.Columns.CntrID, Cn.ID, MatchType.Exact)
                        Imco = Dm.GetTB_InwardCnsImco
                        If Not Imco Is Nothing Then
                            NewDr("IMOClass") = Imco.IMDGCode
                            NewDr("UNNumber") = Imco.UNNO
                            NewDr("PageNumber") = Imco.PageNumber
                            NewDr("EquipmentFlashPoint") = Imco.FlashPoint
                            NewDr("FlashPointUnit") = "CEL"
                            'NewDr("HazardVersion")
                        End If
                        Dm.QueryCriteria.Clear()
                        Dm.QueryCriteria.And(JoinPath.TB_InwardCnsTemprature.Columns.CntrID, Cn.ID, MatchType.Exact)
                        RF = Dm.GetTB_InwardCnsTemprature
                        If Not RF Is Nothing Then
                            NewDr("TempratureUnit") = "CEL"
                            NewDr("Temprature") = RF.TempMin
                        Else
                            NewDr("TempratureUnit") = ""
                            NewDr("Temprature") = ""
                        End If
                        CoparnDS.Tables("Containers").Rows.Add(NewDr)
                    End If
                Next
            Next

        Catch ex As Exception
            MsgBox(Dr("BlNo"))
        End Try


        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Voy.ID, MatchType.Exact)
        If (Not BL Is Nothing) Then
            Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.Port, BL.POD, MatchType.Exact)
        End If


        SOF = Dm.GetTB_SOF

        NewDr = CoparnDS.Tables("Header").NewRow
        NewDr("VoyageNo") = Voy.VoyageNo
        NewDr("Receiver") = "PMO"
        NewDr("VesselName") = Vsl.VesselName
        NewDr("VesselLine") = "" 'Line.EDICode
        NewDr("Sender") = CleanStr(CurrentCompany.CompanyName)
        '  NewDr("MessageDate") = Date.Now
        NewDr("MessageNo") = "99999"
        NewDr("Nationality") = Vsl.Nationality
        NewDr("VoyageType") = ""
        If (Not BL Is Nothing) Then
            NewDr("POD") = GetEDIPORT(BL.POD)

            NewDr("POL") = GetEDIPORT(BL.POL)
        End If
        If SOF Is Nothing Then
            NewDr("ArrivalDate") = Date.Parse(Now)
            NewDr("DepartureDate") = DateAdd(DateInterval.Day, -1, Now)

        Else
            NewDr("ArrivalDate") = Date.Parse(SOF.Arrival)
            NewDr("DepartureDate") = DateAdd(DateInterval.Day, -1, CDate(SOF.Arrival))
        End If
        CoparnDS.Tables("Header").Rows.Add(NewDr)

    End Sub

    Private Function GetEDIPORT(ByVal PortCode As String)

        Dim Drs() As DataRow
        Dim sPort As String = PortCode
        Drs = Ports.Select("PortCode = '" & PortCode & "'")
        If Drs.Length > 0 Then
            If NullToValue(Drs(0).Item("EDIIPCODE"), "") <> "" Then
                sPort = Drs(0).Item("EDIIPCODE")
            End If
        End If
        Return Trim(Mid(sPort, 1, 2) & " " & Mid(sPort, 3))

    End Function

    Private Function CleanStr(ByVal sStr As String) As String

        Dim nI As Long
        Dim AllowChrs As String = ""
        Dim sResult As String = ""
        Dim S As String = ""

        sStr = UCase(sStr)
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

    Private Function SizeTypeToTCTSISO(ByVal CnType As String, ByVal CnSize As String)

        Dim Ans As String = ""
        Select Case CnType
            Case "SD" ', "DC", "GP"
                Ans = "200"
            Case "DC"
                Ans = "200"
            Case "GP"
                Ans = "200"
            Case "HD" ', "HC", "SH"
                Ans = "500"
            Case "HC"
                Ans = "500"
            Case "SH"
                Ans = "500"
            Case "RF" ', "RS"
                Ans = "230"
            Case "RS"
                Ans = "230"
            Case "RH"
                Ans = "530"
            Case "OT" ', "FO"
                Ans = "250"
            Case "FO"
                Ans = "250"
            Case "OH"
                Ans = "550"
            Case "FC" ', "FL", "FR"
                Ans = "260"
            Case "FL"
                Ans = "260"
            Case "FR"
                Ans = "260"
            Case "FH"
                Ans = "560"
            Case "TK"
                Ans = "270"
            Case "TH"
                Ans = "570"
            Case Else
                Ans = "200"
        End Select

        Select Case CnSize
            Case "20"
                Ans = "2" & Ans
            Case "40"
                Ans = "4" & Ans
            Case "45"
                Ans = "9" & Ans
        End Select
         
        Return Ans
    End Function

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

End Class
