Imports OrmLib
Imports ShippingBiz

Public Class FrmGenXML

    Private TB As DataTable
    Private DM As DataManager

    Private Bls As DataTable
    Private Cns As DataTable
    Private Chg As DataTable
    Private Nam As DataTable
    Private INF As DataTable
    Private VOY As DataTable
    Private Gds As DataTable
    Private BlsList As DataTable
    Private Ve As DataTable
    Private Fle As IO.StreamWriter
    Private Sub FrmGenXML_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Vessel.InitControl(Me.BackColor)
        Me.Voyage.InitControl(Me.BackColor, Me.Vessel)
        InitTemp()
    End Sub


    Private Sub GenretaeTsLineXml(ByVal FLEName As String, ByVal FileType As String)


      
        Dim Row As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim aSel As New ArrayList
        Dim BLNo As String
        Dim lFirst As Boolean = True


        DM = New DataManager(My.Settings.DSN)

        For Each Row In GridResult.Rows
            If Row.Cells("Select").Value = True Then
                aSel.Add(Row.Cells("BLNO").Value)
            End If
        Next

        If aSel.Count = 0 Then
            MsgBoxGeneral("No Any Selection ", "Faild")
            Exit Sub
        End If


        Fle = New IO.StreamWriter(FLEName)

        Try

            For Each BLNo In aSel

                DM = New DataManager(My.Settings.DSN)

                DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
                DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, BLNo, MatchType.Exact)
                DM.GetTB_OutwardBLS()
                Bls = DM.DataSet.Tables("TB_OutwardBLS")

                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_OutwardBlsNames.Columns.BLID, Bls.Rows(0).Item("ID"), MatchType.Exact)
                DM.GetTB_OutwardBlsNames()
                Nam = DM.DataSet.Tables("TB_OutwardBlsNames")

                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_OutwardCntrs.Columns.BLID, Bls.Rows(0).Item("ID"), MatchType.Exact)
                DM.GetTB_OutwardCntrs()
                Cns = DM.DataSet.Tables("TB_OutwardCntrs")


                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_OutwardCharges.Columns.BLID, Bls.Rows(0).Item("ID"), MatchType.Exact)
                DM.GetTB_OutwardCharges()
                Chg = DM.DataSet.Tables("TB_OutwardCharges")


                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_OutwardBlsGoods.Columns.BLID, Bls.Rows(0).Item("ID"), MatchType.Exact)
                DM.GetTB_OutwardBlsGoods()
                Gds = DM.DataSet.Tables("TB_OutwardBlsGoods")

                If lFirst = True Then

                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Bls.Rows(0).Item("VoyageID"), MatchType.Exact)
                    DM.GetTB_Voyage()
                    VOY = DM.DataSet.Tables("TB_Voyage")

                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, VOY.Rows(0).Item("VesselID"), MatchType.Exact)
                    DM.GetTB_Vessels()
                    Ve = DM.DataSet.Tables("TB_Vessels")

                    Fle.WriteLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & " standalone=" & """" & "yes" & """" & " ?>")
                    Fle.WriteLine("<BLLIST TrafficNo=" & """" & Ve.Rows(0).Item("VesselCode") & VOY.Rows(0).Item("VoyageNo") & """" & " Traffic_Model_Code=" & """" & "VES" & """" & ">")
                    lFirst = False

                End If

                If Not Cns Is Nothing Then
                    If Cns.Rows(0).Item("FLE") = "F" Then
                        BL2Xml(FileType)
                    Else
                        BL2Xml("E")

                    End If
                End If
            Next
            MsgBox("Generate File Successful")
        Catch ex As Exception
            MsgBox("Stop Generate XML At B/L NO " & BLNo, MsgBoxStyle.Critical)
            MsgBox(ex.ToString)
        Finally
            Fle.WriteLine("</BLLIST>")
            Fle.Flush()
            Fle.Close()
        End Try



    End Sub
    Private Sub BL2Xml(ByVal FileType As String)


        Dim VAN_HQ As Long
        Dim VAN_40 As Long
        Dim VAN_20 As Long

        Dim RATE_HQ As Double
        Dim RATE_40 As Double
        Dim RATE_20 As Double

        Dim Code As String
        Dim Seq As Long

        'Bls = BLByLineBlNo(LN, BL)
        'Chg = chargesByLineBLno(LN, BL)
        'Nam = MemoByLineBL(LN, BL)
        'INF = InfoByLineBL(LN, BL)

        'TotalBLWgt(LN, BL, BLGW, BLTW)
        'Pkg = TotalBLPkgs(LN, BL)

        'Hedaer

        Fle.WriteLine("<BL BL_NO=" & """" & Bls.Rows(0).Item("BlNo") & """" & ">")

        Fle.WriteLine("<M1012>")
        Fle.WriteLine("<Record NO=" & """" & "0" & """" & ">")
        Fle.WriteLine("<print_times></print_times>")
        Fle.WriteLine("<p_Loaded_on></p_Loaded_on>")
        Fle.WriteLine("<p_agent_for_carrier></p_agent_for_carrier>")
        Fle.WriteLine("<p_fright_printing></p_fright_printing> ")
        Fle.WriteLine("<p_attach></p_attach>")
        Fle.WriteLine("<p_fright_printing_type></p_fright_printing_type>")
        Fle.WriteLine("<p_date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</p_date>")
        Fle.WriteLine("<p_no_of_bl>" & Bls.Rows(0).Item("NoOfBls") & "</p_no_of_bl>")
        Fle.WriteLine("<p_ex_rate>9350</p_ex_rate>") ' Should be lookup from voyage rate
        Fle.WriteLine("<p_issue_date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</p_issue_date>")
        Fle.WriteLine("<p_issue_place>" & GetPortNameByCode(NullToValue(Bls.Rows(0).Item("IssuePlace"), "IRBND")) & "</p_issue_place>")
        Fle.WriteLine("<p_collect_at></p_collect_at>")
        Fle.WriteLine("<p_prepaid_at>IRBND</p_prepaid_at>")
        Fle.WriteLine("<p_total></p_total>")
        Fle.WriteLine("<p_collect></p_collect>")
        Fle.WriteLine("<p_prepaid></p_prepaid>")
        Fle.WriteLine("<p_rate></p_rate>")
        Fle.WriteLine("<p_weight_measure>KGS</p_weight_measure>")
        Fle.WriteLine("<p_freight>AS ARRANGED</p_freight>")
        Fle.WriteLine("<p_measure>0 CBM</p_measure>")
        Fle.WriteLine("<p_weight>" & Gds.Rows(0).Item("TGW") & " KGS</p_weight>")
        Fle.WriteLine("<p_description>" & CleanStr(UCase(NullToValue(Gds.Rows(0).Item("Goods"), ""))) & "</p_description>")
        Fle.WriteLine("<p_mark>" & CleanStr(UCase(NullToValue(Gds.Rows(0).Item("Marks"), ""))) & "</p_mark>")
        Fle.WriteLine("<p_packages>" & Gds.Rows(0).Item("TTLPkgs") & "(" & Cns.Rows(0).Item("PackageType") & ")</p_packages>")
        Fle.WriteLine("<p_seal_no_marks></p_seal_no_marks>")
        Fle.WriteLine("<p_container_no ></p_container_no >")
        Fle.WriteLine("<p_final_destination></p_final_destination>")
        Fle.WriteLine("<p_place_delivery>" & GetPortNameByCode(NullToValue(Bls.Rows(0).Item("FPOD"), "")) & "</p_place_delivery>")
        Fle.WriteLine("<p_place_receipt>" & GetPortNameByCode(NullToValue(Bls.Rows(0).Item("POR"), "")) & "</p_place_receipt>")
        Fle.WriteLine("<p_port_disc>" & GetPortNameByCode(NullToValue(Bls.Rows(0).Item("POD"), "")) & "</p_port_disc> ")
        Fle.WriteLine("<p_port_load>" & GetPortNameByCode(NullToValue(Bls.Rows(0).Item("POL"), "")) & "</p_port_load>")
        Fle.WriteLine("<p_agent>IRBND</p_agent>")
        Fle.WriteLine("<p_voyage>" & VOY.Rows(0).Item("VoyageNo") & "</p_voyage>")
        Fle.WriteLine("<p_ocean_vessel>" & NullToValue(Ve.Rows(0).Item("VesselCode"), "") & "</p_ocean_vessel>")
        Fle.WriteLine("<p_pre_carrier_vsl></p_pre_carrier_vsl>")
        Fle.WriteLine("<p_pre_carrier_voyage></p_pre_carrier_voyage>")
        Fle.WriteLine("<p_commodity_no></p_commodity_no>") ' Should check with principal
        Fle.WriteLine("<p_so></p_so>")
        Fle.WriteLine("<p_consignee>" & CleanStr(UCase(NullToValue(Nam.Rows(0).Item("Cnee"), ""))) & "</p_consignee>")
        Fle.WriteLine("<p_notify>" & CleanStr(UCase(NullToValue(Nam.Rows(0).Item("Notify1"), ""))) & "</p_notify>")
        Fle.WriteLine("<p_shipper>" & CleanStr(UCase(NullToValue(Nam.Rows(0).Item("Shipper"), ""))) & "</p_shipper>")
        Fle.WriteLine("</Record>")
        Fle.WriteLine("</M1012>")

        Fle.WriteLine("<M1009>")
        Fle.WriteLine("<Record No=" & """" & "0" & """" & ">")
        Fle.WriteLine("<Accu_TTL_Re_Write>1</Accu_TTL_Re_Write>")
        Fle.WriteLine("<Accu_TTL_Read>1</Accu_TTL_Read>")
        Fle.WriteLine("<Modify_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Modify_User_Date>")
        Fle.WriteLine("<Modify_User_code>TDZ</Modify_User_code>")
        Fle.WriteLine("<Entry_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Entry_User_Date>")
        Fle.WriteLine("<Entry_User_Code>TDZ</Entry_User_Code>")
        Fle.WriteLine("<Entry_Office>IRBND</Entry_Office>")
        Fle.WriteLine("<Tranship_Seq>1</Tranship_Seq>")
        Fle.WriteLine("<Next_Tranship_Port>" & Bls.Rows(0).Item("POT") & "</Next_Tranship_Port>")
        Fle.WriteLine("<Next_BL>" & Bls.Rows(0).Item("BlNo") & "</Next_BL>")
        Fle.WriteLine("<Next_Traffic_No>Unknown</Next_Traffic_No>")
        Fle.WriteLine("<Prev_Tranship_Port></Prev_Tranship_Port>")
        Fle.WriteLine("<Prev_BL></Prev_BL>")

        Fle.WriteLine("<Prev_Traffic_No></Prev_Traffic_No>")
        Fle.WriteLine("<Shut_off_Tranship_Mark>T</Shut_off_Tranship_Mark></Record></M1009>")

        If Not Chg Is Nothing Then
            If Chg.Rows.Count > 0 Then

                Fle.WriteLine("<M1006>")
                Seq = Chg.Rows.Count

                VAN_HQ = 0
                VAN_40 = 0
                VAN_20 = 0

                RATE_HQ = 0
                RATE_40 = 0
                RATE_20 = 0

                For Each Dr As DataRow In Chg.Rows
                    Fle.WriteLine("<Record NO=" & """" & Seq - 1 & """" & ">")
                    Fle.WriteLine("<Accu_TTL_Re_Write>0</Accu_TTL_Re_Write>")
                    Fle.WriteLine("<Accu_TTL_Read>0</Accu_TTL_Read>")
                    Fle.WriteLine("<Modify_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Modify_User_Date>")
                    Fle.WriteLine("<Modify_User_Code>TDZ</Modify_User_Code>")
                    Fle.WriteLine("<Entry_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Entry_User_Date> ")
                    Fle.WriteLine("<Entry_User_Code>TDZ</Entry_User_Code>")
                    Fle.WriteLine("<Entry_Office>IRBND</Entry_Office>")
                    Fle.WriteLine("<Remark_Mark></Remark_Mark>")
                    Fle.WriteLine("<Date_of_Payment></Date_of_Payment>")
                    Fle.WriteLine("<Approve_No></Approve_No>")
                    Fle.WriteLine("<Company_Code></Company_Code>")
                    Fle.WriteLine("<Payer>" & IIf(NullToValue(Bls.Rows(0).Item("TermsOfPayment"), "C") = "P", CleanStr(UCase(NullToValue(Nam.Rows(0).Item("Shipper"), ""))), CleanStr(UCase(NullToValue(Nam.Rows(0).Item("Cnee"), "")))) & "</Payer>")
                    Fle.WriteLine("<Pay_at>" & NullToValue(Dr("PayAt"), "") & "</Pay_at>")
                    Fle.WriteLine("<Exchange_Rate>1</Exchange_Rate>")
                    Fle.WriteLine("<USD_Amount>" & NullToValue(Dr("Amount"), 0) & "</USD_Amount>")
                    Fle.WriteLine("<Amount>" & NullToValue(Dr("Amount"), 0) & "</Amount>")
                    Fle.WriteLine("<Currency>" & NullToValue(Dr("Currency"), "") & "</Currency>")
                    Code = NullToValue(Dr("ChargesCode"), "")
                    Fle.WriteLine("<Charge_Code>" & Code & IIf(Code = "OFT", "-", "") & NullToValue(Dr("Terms"), "C") & "</Charge_Code>")
                    Fle.WriteLine("<Seq_No>" & Seq & "</Seq_No>")
                    Fle.WriteLine("</Record>")

                    If Mid(NullToValue(Dr("ChargesCode"), ""), 1, 2) = "OFT" Then
                        Select Case NullToValue(Dr("ChargesBase"), "")
                            Case "20D"
                                RATE_20 = NullToValue(Dr("Rate"), 0)
                                VAN_20 = NullToValue(Dr("Qty"), 0)
                            Case "40D"
                                RATE_40 = NullToValue(Dr("Rate"), 0)
                                VAN_40 = NullToValue(Dr("Qty"), 0)
                            Case "40H"
                                RATE_HQ = NullToValue(Dr("Rate"), 0)
                                VAN_HQ = NullToValue(Dr("Qty"), 0)
                        End Select
                    End If
                    Seq = Seq - 1

                Next
                Fle.WriteLine("</M1006>")

            Else
                Fle.WriteLine("<M1006>")
                Fle.WriteLine("</M1006>")
            End If
        Else
            Fle.WriteLine("<M1006>")
            Fle.WriteLine("</M1006>")
        End If

        Fle.WriteLine("<M1005>")
        Fle.WriteLine("<Record NO=" & """" & "1" & """" & ">")
        Fle.WriteLine("<Accu_TTL_Re_Write>0</Accu_TTL_Re_Write>")
        Fle.WriteLine("<Accu_TTL_Read>0</Accu_TTL_Read>")
        Fle.WriteLine("<Modify_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Modify_User_Date>")
        Fle.WriteLine("<Modify_User_Code>TDZ</Modify_User_Code>")
        Fle.WriteLine("<Entry_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Entry_User_Date> ")
        Fle.WriteLine("<Entry_User_Code>TDZ</Entry_User_Code>")
        Fle.WriteLine("<Entry_Office>IRBND</Entry_Office>")
        Fle.WriteLine("<Company_Code></Company_Code>")
        Fle.WriteLine("<SP_NF_CN_Rec>" & CleanStr(UCase(NullToValue(Nam.Rows(0).Item("Notify1"), ""))) & "</SP_NF_CN_Rec>")
        Fle.WriteLine("<Data_Type>NOTF</Data_Type>")
        Fle.WriteLine("</Record>")

        Fle.WriteLine("<Record NO=" & """" & "0" & """" & ">")
        Fle.WriteLine("<Accu_TTL_Re_Write>0</Accu_TTL_Re_Write>")
        Fle.WriteLine("<Accu_TTL_Read>0</Accu_TTL_Read>")
        Fle.WriteLine("<Modify_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Modify_User_Date>")
        Fle.WriteLine("<Modify_User_Code>TDZ</Modify_User_Code>")
        Fle.WriteLine("<Entry_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Entry_User_Date> ")
        Fle.WriteLine("<Entry_User_Code>TDZ</Entry_User_Code>")
        Fle.WriteLine("<Entry_Office>IRBND</Entry_Office>")
        Fle.WriteLine("<Company_Code></Company_Code>")
        Fle.WriteLine("<SP_NF_CN_Rec>" & CleanStr(UCase(NullToValue(Nam.Rows(0).Item("Cnee"), ""))) & "</SP_NF_CN_Rec>")
        Fle.WriteLine("<Data_Type>CSGN</Data_Type>")
        Fle.WriteLine("</Record>")

        Fle.WriteLine("<Record NO=" & """" & "2" & """" & ">")
        Fle.WriteLine("<Accu_TTL_Re_Write>0</Accu_TTL_Re_Write>")
        Fle.WriteLine("<Accu_TTL_Read>0</Accu_TTL_Read>")
        Fle.WriteLine("<Modify_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Modify_User_Date>")
        Fle.WriteLine("<Modify_User_Code>TDZ</Modify_User_Code>")
        Fle.WriteLine("<Entry_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Entry_User_Date> ")
        Fle.WriteLine("<Entry_User_Code>TDZ</Entry_User_Code>")
        Fle.WriteLine("<Entry_Office>IRBND</Entry_Office>")
        Fle.WriteLine("<Company_Code></Company_Code>")
        Fle.WriteLine("<SP_NF_CN_Rec>" & CleanStr(UCase(NullToValue(Nam.Rows(0).Item("Shipper"), ""))) & "</SP_NF_CN_Rec>")
        Fle.WriteLine("<Data_Type>SHPR</Data_Type>")
        Fle.WriteLine("</Record>")
        Fle.WriteLine("</M1005>")

        Fle.WriteLine("<M1003>")

        Seq = Cns.Rows.Count

        For Each Dr As DataRow In Cns.Rows
            Fle.WriteLine("<Record NO=" & """" & Seq & """" & ">")
            Fle.WriteLine("<Accu_TTL_Re_Write>0</Accu_TTL_Re_Write>")
            Fle.WriteLine("<Accu_TTL_Read>0</Accu_TTL_Read>")
            Fle.WriteLine("<Modify_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Modify_User_Date>")
            Fle.WriteLine("<Modify_User_Code>TDZ</Modify_User_Code>")
            Fle.WriteLine("<Entry_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Entry_User_Date> ")
            Fle.WriteLine("<Entry_User_Code>TDZ</Entry_User_Code>")
            Fle.WriteLine("<Entry_Office>IRBND</Entry_Office>")
            Fle.WriteLine("<Remark_Mark></Remark_Mark>")
            Fle.WriteLine("<CTNR_OVER_SIZE_WIDTH></CTNR_OVER_SIZE_WIDTH>")
            Fle.WriteLine("<CTNR_OVER_SIZE_LENGTH></CTNR_OVER_SIZE_LENGTH>")
            Fle.WriteLine("<CTNR_OVER_SIZE_HEIGHT></CTNR_OVER_SIZE_HEIGHT>")
            Fle.WriteLine("<D_Terminal></D_Terminal>")
            Fle.WriteLine("<L_Terminal></L_Terminal>")
            Fle.WriteLine("<RO_Print>N</RO_Print>")
            Fle.WriteLine("<Hold_Ctnr>N</Hold_Ctnr>")
            Fle.WriteLine("<MF_Part_Print></MF_Part_Print>")
            Fle.WriteLine("<Refer_Temperature_Type></Refer_Temperature_Type>")
            Fle.WriteLine("<Refer_Temperature></Refer_Temperature>")
            Fle.WriteLine("<Cargo_EMS_No></Cargo_EMS_No>")
            Fle.WriteLine("<Cargo_Flash_Point></Cargo_Flash_Point>")
            Fle.WriteLine("<Cargo_IMDG_Class></Cargo_IMDG_Class>")
            Fle.WriteLine("<Cargo_IMDG_Page></Cargo_IMDG_Page>")
            Fle.WriteLine("<Cargo_IMDG_Code></Cargo_IMDG_Code>")
            Fle.WriteLine("<Cargo_UN_Code></Cargo_UN_Code>")
            Fle.WriteLine("<Discharge_Status>1</Discharge_Status>")
            Fle.WriteLine("<Loading_Status>1</Loading_Status>")
            Fle.WriteLine("<Part_Service>N</Part_Service>")
            Fle.WriteLine("<In_Ctnr>N</In_Ctnr>")
            Fle.WriteLine("<Empty_or_Full>" & IIf(NullToValue(Dr("FLE"), "E") = "E", "E", "F") & "</Empty_or_Full>")
            Fle.WriteLine("<Seal_No3></Seal_No3>")
            Fle.WriteLine("<Seal_No2></Seal_No2>")
            Fle.WriteLine("<Seal_No1>" & NullToValue(Dr("SealNo"), "") & "</Seal_No1>")
            Fle.WriteLine("<Measure>0</Measure>")
            Fle.WriteLine("<Net_Weight>" & NullToValue(Dr("NET"), 0) & "</Net_Weight>")
            Fle.WriteLine("<Gross_Weight>" & NullToValue(Dr("GW"), 0) & "</Gross_Weight>")
            Fle.WriteLine("<Package_Unit>" & NullToValue(Dr("PackageType"), "CTN") & "</Package_Unit>")
            Fle.WriteLine("<No_of_Package>" & NullToValue(Dr("NoOfPkgs"), 0) & "</No_of_Package>")
            Fle.WriteLine("<Final_Destination></Final_Destination>")
            Fle.WriteLine("<Place_Delivery>" & NullToValue(Bls.Rows(0).Item("FPOD"), "") & "</Place_Delivery>")
            Fle.WriteLine("<Place_Receipt>" & NullToValue(Bls.Rows(0).Item("POR"), "") & "</Place_Receipt>")
            Fle.WriteLine("<Port_Disc>" & NullToValue(Bls.Rows(0).Item("POD"), "") & "</Port_Disc>")
            Fle.WriteLine("<Port_Load>" & NullToValue(Bls.Rows(0).Item("POL"), "") & "</Port_Load>")
            Fle.WriteLine("<COC_SOC>" & IIf(NullToValue(Dr("SOC"), "N") = "Y", "SOC", "COC") & "</COC_SOC>")
            Fle.WriteLine("<Ctnr_Type>" & NullToValue(Dr("CnSize"), "") & OurTypeToTSL(NullToValue(Dr("CnType"), "GP")) & "</Ctnr_Type>")
            Fle.WriteLine("<Maintain_Byte></Maintain_Byte>")
            Fle.WriteLine("<Container_No>" & NullToValue(Dr("CntrNo"), "") & "</Container_No>")
            Fle.WriteLine("</Record>")
            Seq = Seq - 1

        Next

        Fle.WriteLine("</M1003>")

        Fle.WriteLine("<M1002>")
        Fle.WriteLine("<Record NO=" & """" & "1" & """" & ">")
        Fle.WriteLine("<Accu_TTL_Re_Write>0</Accu_TTL_Re_Write>")
        Fle.WriteLine("<Accu_TTL_Read>0</Accu_TTL_Read>")
        Fle.WriteLine("<Modify_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Modify_User_Date>")
        Fle.WriteLine("<Modify_User_Code>TDZ</Modify_User_Code>")
        Fle.WriteLine("<Entry_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Entry_User_Date> ")
        Fle.WriteLine("<Entry_User_Code>TDZ</Entry_User_Code>")
        Fle.WriteLine("<Entry_Office>IRBND</Entry_Office>")
        Fle.WriteLine("<MA_DS_Rec>" & CleanStr(UCase(NullToValue(Gds.Rows(0).Item("Goods"), ""))) & "</MA_DS_Rec>")
        Fle.WriteLine("<Data_Type>DESC</Data_Type>")
        Fle.WriteLine("</Record>")

        Fle.WriteLine("<Record NO=" & """" & "0" & """" & ">")
        Fle.WriteLine("<Accu_TTL_Re_Write>0</Accu_TTL_Re_Write>")
        Fle.WriteLine("<Accu_TTL_Read>0</Accu_TTL_Read>")
        Fle.WriteLine("<Modify_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Modify_User_Date>")
        Fle.WriteLine("<Modify_User_Code>TDZ</Modify_User_Code>")
        Fle.WriteLine("<Entry_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Entry_User_Date> ")
        Fle.WriteLine("<Entry_User_Code>TDZ</Entry_User_Code>")
        Fle.WriteLine("<Entry_Office>IRBND</Entry_Office>")
        Fle.WriteLine("<MA_DS_Rec>" & CleanStr(UCase(NullToValue(Gds.Rows(0).Item("Marks"), ""))) & "</MA_DS_Rec>")
        Fle.WriteLine("<Data_Type>MARK</Data_Type>")
        Fle.WriteLine("</Record>")
        Fle.WriteLine("</M1002>")

        Fle.WriteLine("<M1001>")

        Fle.WriteLine("<Accu_TTL_Re_Write>0</Accu_TTL_Re_Write>")
        Fle.WriteLine("<Accu_TTL_Read>0</Accu_TTL_Read>")
        Fle.WriteLine("<No_Of_Bill>3</No_Of_Bill>")
        Fle.WriteLine("<OF_Prepaid_collect>" & NullToValue(Bls.Rows(0).Item("TermsOfPayment"), "") & "</OF_Prepaid_collect>")
        Fle.WriteLine("<Modify_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Modify_User_Date>")
        Fle.WriteLine("<Modify_User_code>TDZ</Modify_User_code>")
        Fle.WriteLine("<Entry_User_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Entry_User_Date>")
        Fle.WriteLine("<Entry_User_Code>TDZ</Entry_User_Code>")
        Fle.WriteLine("<Entry_Office>IRBND</Entry_Office>")
        Fle.WriteLine("<E>I</E>")
        Fle.WriteLine("<Discharge_Agent_Code>" & NullToValue(Bls.Rows(0).Item("POD"), "") & "</Discharge_Agent_Code>")
        Fle.WriteLine("<vessel_code>" & NullToValue(Ve.Rows(0).Item("VesselCode"), "") & "</vessel_code>")
        Fle.WriteLine("<Credit_Days>0</Credit_Days>")
        Fle.WriteLine("<Meanfest_No />")
        Fle.WriteLine("<To_Door_Mark_Import>N</To_Door_Mark_Import>")
        Fle.WriteLine("<To_Door_Mark_Export>N</To_Door_Mark_Export>")
        Fle.WriteLine("<Memo_Ocean_BL>O</Memo_Ocean_BL>")
        Fle.WriteLine("<Switch_BL_Mark>N</Switch_BL_Mark>")
        Fle.WriteLine("<Telex_Release_No />")
        Fle.WriteLine("<CFS_Rate>0</CFS_Rate>")
        Fle.WriteLine("<CFS_Ton>0</CFS_Ton>")
        Fle.WriteLine("<rate_hq>" & IIf(RATE_HQ = 0, 0, Format(RATE_HQ, ".00")) & "</rate_hq>")
        Fle.WriteLine("<van_hq>" & Str(VAN_HQ) & "</van_hq>")
        Fle.WriteLine("<rate_40>" & IIf(RATE_40 = 0, 0, Format(RATE_40, ".00")) & "</rate_40>")
        Fle.WriteLine("<van_40>" & Str(VAN_40) & "</van_40>")
        Fle.WriteLine("<rate_20>" & IIf(RATE_20 = 0, 0, Format(RATE_20, ".00")) & "</rate_20>")
        Fle.WriteLine("<van_20>" & Str(VAN_20) & "</van_20>")
        Fle.WriteLine("<Commodity_Code>770000</Commodity_Code>")
        Fle.WriteLine("<Arrival_Date>" & Format(NullToValue(Bls.Rows(0).Item("IssueDate"), Now()), "yyyy-MM-dd") & "</Arrival_Date>")
        If IsDBNull(Bls.Rows(0).Item("OnBoardDate")) Then
            Fle.WriteLine("<Onboard_Date></Onboard_Date>")
        Else
            Fle.WriteLine("<Onboard_Date>" & Format(Bls.Rows(0).Item("OnBoardDate"), "yyyy-MM-dd") & "</Onboard_Date>")
        End If

        Fle.WriteLine("<Package_Unit>" & NullToValue(Cns.Rows(0).Item("PackageType"), "CTN") & "</Package_Unit>")
        Fle.WriteLine("<TTL_No_of_Package>" & Gds.Rows(0).Item("TTLPkgs") & "</TTL_No_of_Package>")
        Fle.WriteLine("<Measure>0</Measure>")
        Fle.WriteLine("<Net_Weight>" & Format(Gds.Rows(0).Item("TTLNET"), ".00") & "</Net_Weight>")
        Fle.WriteLine("<Gross_Weight>" & Format(Gds.Rows(0).Item("TGW"), ".00") & "</Gross_Weight>")
        Fle.WriteLine("<Related_BL />")
        Fle.WriteLine("<All_in_Mark>N</All_in_Mark>")
        Fle.WriteLine("<Through_Rate_Mark>N</Through_Rate_Mark>")
        Fle.WriteLine("<Overflow_Mark>N</Overflow_Mark>")
        Fle.WriteLine("<Combine_or_Included_other_BL />")
        Fle.WriteLine("<Original_Voyage />")
        Fle.WriteLine("<Original_Vessel_Name />")
        Fle.WriteLine("<Original_BL_No />")
        Fle.WriteLine("<COC_SOC>COC</COC_SOC>")
        Fle.WriteLine("<Cargo_Type>O</Cargo_Type>")
        Fle.WriteLine("<Discharge_Status>1</Discharge_Status>")
        Fle.WriteLine("<Loading_Status>1</Loading_Status>")
        Fle.WriteLine("<Get_DO_Place>" & NullToValue(Bls.Rows(0).Item("FPOD"), "") & "</Get_DO_Place>")
        Fle.WriteLine("<Get_BL_Place>IRBND</Get_BL_Place>")
        Fle.WriteLine("<Final_Destination />")
        Fle.WriteLine("<Place_Delivery>" & NullToValue(Bls.Rows(0).Item("FPOD"), "") & "</Place_Delivery>")
        Fle.WriteLine("<Disc_Berth />")
        Fle.WriteLine("<Port_Disc>" & NullToValue(Bls.Rows(0).Item("POD"), "") & "</Port_Disc>")
        Fle.WriteLine("<Load_Berth />")
        Fle.WriteLine("<Port_Load>IRBND</Port_Load>")
        Fle.WriteLine("<Place_Receipt>IRBND</Place_Receipt>")
        Fle.WriteLine("<Booking_Place>IRBND</Booking_Place>")
        Fle.WriteLine("<SO />")
        Fle.WriteLine("<Bar_Code>" & Bls.Rows(0).Item("BLNo") & "</Bar_Code>")
        Fle.WriteLine("<Maintain_Byte />")
        Fle.WriteLine("<traffic_control_code>IRBND</traffic_control_code>")
        Fle.WriteLine("</M1001>")
        Fle.WriteLine("</BL>")

    End Sub

    Private Sub InitTemp()

        TB = New DataTable
        TB.TableName = "Result"
        TB.Columns.Add(New DataColumn("BlNo", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Shipper", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))
        Me.GridResult.DataSource = TB

    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        Dim Dr As DataRow
        Dim Bls As TB_OutwardBLSCollection
        Dim Bl As TB_OutwardBLS
        Dim Nm As TB_OutwardBlsNames


        TB.Clear()

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.VoyageID, Me.Voyage.VoyageID, MatchType.Exact)
        Bls = DM.GetTB_OutwardBLSCollection()


        For Each Bl In Bls
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_OutwardBlsNames.Columns.BLID, Bl.ID, MatchType.Exact)
            Nm = DM.GetTB_OutwardBlsNames()
            Dr = TB.NewRow
            Dr("BLNO") = Bl.BlNo
            If Not Nm Is Nothing Then
                Dr("Shipper") = Nm.Shipper
            End If
            Dr("Select") = True
            TB.Rows.Add(Dr)
        Next
        Me.GridResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns

    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        Dim FE As String
        Dim Dialog As New SaveFileDialog

        If MsgBox("Do you want To Generate Full XML ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            FE = "F"
        Else
            FE = "E"
        End If

        Dialog.Filter = "XML Files (*.XML)|*.XML|txt files (*.txt)|*.txt|All files (*.*)|*.*"

        If Dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            GenretaeTsLineXml(Dialog.FileName, FE)
        End If

    End Sub


    Private Function CleanStr(ByVal sStr As String) As String

        Dim nI As Long
        Dim AllowChrs As String
        Dim sResult As String
        Dim S As String

        AllowChrs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.,-()/=<> " & Chr(13) & Chr(10) ' & Chr(236)

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
        Return Trim(sResult)

    End Function

    Private Function OurTypeToTSL(ByVal sCode As String) As String

        Dim Ans As String = "GP"
        If sCode = "HQ" Or sCode = "HC" Then
            Ans = "HQ"
        End If
        Return Ans



    End Function

End Class