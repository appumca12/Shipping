Imports OrmLib
Imports ShippingBiz
Imports System.Data
Imports System.Data.SqlClient
Imports System.String
Imports System.IO
Imports System.Text

Public Class CLNOSAVocher

    Private TBNoInArrival As New DataTable
    Private TBNoInInvoice As New DataTable
    Private TbSame As New DataTable
    Private TBNoSame As New DataTable
    Private TBFinal As DataTable

    Public Sub GenerateArrival(ByVal VoyageID As String, ByRef Result As String)

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Arvl As CLArrivalNotice
        Dim BLS As DataTable
        Dim BL As DataRow
        Dim SOF As TB_SOF
        Dim lResult As Boolean
        Dim DM As New DataManager(My.Settings.DSN)
        Dim Voy As TB_Voyage
        Dim TB As New DataTable
        Dim Dr As DataRow

        Dim Title As New DataTable
        Dim Titles() As DataRow

        Dim TitleSubs() As DataRow
        Dim TitleSub As DataTable
        Dim Tdr As DataRow

        Dim sArticle As String
        Dim Client As TB_Clients
        Dim Code As TB_CODE
        Dim Temp As New DataTable("Temp")
        Dim nDR As DataRow
        Dim nDrs() As DataRow
        Dim nPer As Double
        Dim AllArvl As DataTable
        Dim Xml As String
        Dim MS As New MemoryStream
        Dim SR As New StringWriter
        Dim Toll As Double
        Dim BlData As TB_InwardBLS
        Dim DateOf As Date
        Dim IsChaild As Boolean = False
        Dim sDate As String

        With Temp
            .Columns.Add(New DataColumn("LevelAcc"))
            .Columns.Add(New DataColumn("Level1"))
            .Columns.Add(New DataColumn("Level2"))
            .Columns.Add(New DataColumn("Level3"))
            .Columns.Add(New DataColumn("Level4"))
            .Columns.Add(New DataColumn("Level5"))
            .Columns.Add(New DataColumn("Amount"))
            .Columns.Add(New DataColumn("Desc"))
        End With

        DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyageID, MatchType.Exact)
        Voy = DM.GetTB_Voyage

        If Voy Is Nothing Then
            MsgBox("No Valid Voyage !")
        End If
 
        TableBySql("Select * From tb_InwardBls Where VoyageID = '" & VoyageID & "'", BLS, lResult)

        If lResult = False Then
            MsgBox("Something Wrong !")
        End If
 
        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, VoyageID, MatchType.Exact)
        SOF = DM.GetTB_SOF

        If SOF Is Nothing Then
            MsgBox("No SOF Date For This Voyage !")
            Exit Sub
        End If
 
        TableBySql("Select * From tb_NOSAAccount", Title, lResult)
        TableBySql("Select * From tb_NOSAAccountsub", TitleSub, lResult)
        TitleSub.Columns.Add("sFrom")
        TitleSub.Columns.Add("sTo")

        For Each Dr In TitleSub.Rows
            If Not IsDBNull(Dr("dFrom")) = True Then
                Dr("sFrom") = DTOS(Dr("dFrom"))
            End If
            If Not IsDBNull(Dr("dTo")) = True Then
                Dr("sTo") = DTOS(Dr("dTo"))
            End If
        Next
        TitleSub.AcceptChanges()

        Dim SB As New StringBuilder

        SB.AppendLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & "?>")
        SB.AppendLine("<_XPXML>")

        For Each BL In BLS.Rows

            If NullToValue(BL("FrtCoverdBlNo"), "") = "" Then
                IsChaild = False
            Else
                IsChaild = True
            End If

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, BL("ClienTID"), MatchType.Exact)
            Client = DM.GetTB_Clients

            Arvl = New CLArrivalNotice
            Arvl.GenArrivalNotice(BL, SOF.Berthed, Voy)
            Temp.Clear()

            Toll = 0
 
            Arvl.GetTBDetails.AcceptChanges()

            For Each Dr In Arvl.GetTBDetails.Rows
                If Dr("MandatoryAmount") + Dr("ConditionalAmount") + Dr("DepositAmount") = 0 Then
                    Dr.Delete()
                End If
            Next

            Arvl.GetTBDetails.AcceptChanges()

            For Each Dr In Arvl.GetTBDetails.Rows
                If Dr("Chargeitem") = "TOLL" Then
                    Toll = Dr("ConditionalAmount") + Dr("MandatoryAmount")
                End If
                If IsChaild = True And Dr("Chargeitem") = "DO" Then
                    Dr("Chargeitem") = "DOLCL"
                End If
            Next

            If AllArvl Is Nothing Then
                AllArvl = Arvl.GetTBDetails
            Else
                For Each Dr In Arvl.GetTBDetails.Rows
                    AllArvl.ImportRow(Dr)
                Next
            End If

            sDate = DTOS(SOF.Arrival)

            For Each Dr In Arvl.GetTBDetails.Rows

                If Dr("ConditionalAmount") + Dr("MandatoryAmount") > 0 Then
                    Temp.AcceptChanges()
                    Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                    If Titles.Length = 0 Then
                        MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                        Exit Sub
                    Else
                        TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= sFrom and '" & sDate & "' <= sTo")
                        If TitleSubs.Length = 0 Then
                            nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DBAccount") & "' and " & _
                                               "Level1 = '" & GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                               "Level2 = '" & GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                               "Level3 = '" & GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                               "Level4 = '" & GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                               "Level5 = '" & GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client) & "'")
                            If nDrs.Length = 0 Then
                                nDR = Temp.NewRow
                                nDR("LevelAcc") = Titles(0).Item("DBAccount")
                                nDR("Level1") = GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client)
                                nDR("Level2") = GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client)
                                nDR("Level3") = GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client)
                                nDR("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client)
                                nDR("Level5") = GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client)
                                nDR("Amount") = Dr("ConditionalAmount") + Dr("MandatoryAmount")
                                Temp.Rows.Add(nDR)
                            Else
                                nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + (Dr("ConditionalAmount") + Dr("MandatoryAmount"))
                            End If
                        Else
                            For Each Tdr In TitleSubs
                                nDrs = Temp.Select("LevelAcc = '" & Tdr("DBAccount") & "' and " & _
                                                                         "Level1 = '" & GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level2 = '" & GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level3 = '" & GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level4 = '" & GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level5 = '" & GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client) & "'")
                                If nDrs.Length = 0 Then
                                    nDR = Temp.NewRow
                                    nDR("LevelAcc") = Titles(0).Item("DBAccount")
                                    nDR("Level1") = GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client)
                                    nDR("Level2") = GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client)
                                    nDR("Level3") = GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client)
                                    nDR("Level4") = GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client)
                                    nDR("Level5") = GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client)
                                    If NullToValue(Tdr("Amount"), 0) > 0 Then
                                        nDR("Amount") = Tdr("Amount")
                                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                        nPer = (Dr("ConditionalAmount") + Dr("MandatoryAmount"))
                                        nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                        nDR("Amount") = nPer
                                    End If
                                    Temp.Rows.Add(nDR)
                                Else
                                    If NullToValue(Tdr("Amount"), 0) > 0 Then
                                        nDR("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
                                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                        nPer = (Dr("ConditionalAmount") + Dr("MandatoryAmount"))
                                        nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                        nDR("Amount") = nDrs(0).Item("Amount") + nPer
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            Next

            For Each nDR In Temp.Rows

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDR("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDR("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDR("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDR("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDR("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "


                sArticle += "Deb=" & """"
                sArticle += (NullToValue(nDR("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & "بابت هزینه ترخیصیه بارنامه " & Dr("BLNO") & """" & " "
                sArticle += "ODesc=" & """" & Dr("BLNO") & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)

            Next

            Temp.Clear()
            Temp.AcceptChanges()


            For Each Dr In Arvl.GetTBDetails.Rows

                If Dr("ConditionalAmount") + Dr("MandatoryAmount") > 0 Then

                    Temp.AcceptChanges()
                    Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                    If Titles.Length = 0 Then
                        MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                        Exit Sub
                    Else
                        TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= sFrom and '" & sDate & "' <= sTo")
                        If TitleSubs.Length = 0 Then
                            nDR = Temp.NewRow
                            nDR("LevelAcc") = Titles(0).Item("CRAccount")
                            nDR("Level1") = GetLevel(Titles(0).Item("CRLevel1").ToString, BL, Voy, Client)
                            nDR("Level2") = GetLevel(Titles(0).Item("CRLevel2").ToString, BL, Voy, Client)
                            nDR("Level3") = GetLevel(Titles(0).Item("CRLevel3").ToString, BL, Voy, Client)
                            nDR("Level4") = GetLevel(Titles(0).Item("CRLevel4").ToString, BL, Voy, Client)
                            nDR("Level5") = GetLevel(Titles(0).Item("CRLevel5").ToString, BL, Voy, Client)
                            nDR("Amount") = Dr("ConditionalAmount") + Dr("MandatoryAmount")
                            nDR("Desc") = Titles(0).Item("Description") & " بابت بارنامه " & Dr("BLNO")
                            Temp.Rows.Add(nDR)
                        Else
                            For Each Tdr In TitleSubs
                                nDR = Temp.NewRow
                                nDR("LevelAcc") = Tdr("CRAccount")
                                nDR("Level1") = GetLevel(Tdr("CRLevel1").ToString, BL, Voy, Client)
                                nDR("Level2") = GetLevel(Tdr("CRLevel2").ToString, BL, Voy, Client)
                                nDR("Level3") = GetLevel(Tdr("CRLevel3").ToString, BL, Voy, Client)
                                nDR("Level4") = GetLevel(Tdr("CRLevel4").ToString, BL, Voy, Client)
                                nDR("Level5") = GetLevel(Tdr("CRLevel5").ToString, BL, Voy, Client)
                                If NullToValue(Tdr("Amount"), 0) > 0 Then
                                    nDR("Amount") = Tdr("Amount")
                                ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                    nPer = (Dr("ConditionalAmount") + Dr("MandatoryAmount"))
                                    nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                    nDR("Amount") = nPer
                                End If
                                nDR("Desc") = Tdr("Description") & " بابت بارنامه " & Dr("BLNO")
                                Temp.Rows.Add(nDR)
                            Next
                        End If
                    End If
                End If
            Next

            For Each nDR In Temp.Rows

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDR("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDR("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDR("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDR("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDR("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "

                sArticle += "Cre=" & """"
                sArticle += (NullToValue(nDR("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & nDR("Desc") & """" & " "
                sArticle += "ODesc=" & """" & Dr("BLNO") & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)

            Next

        Next

        SB.AppendLine("</_XPXML>")
        Result = SB.ToString

        Cmd = New SqlCommand
        If Cnn.State <> ConnectionState.Open Then
            Cnn.Open()
        End If
        AllArvl.Columns.Remove("Condition")
        AllArvl.Columns.Remove("Meaning")
        AllArvl.Columns.Remove("MeaningF")


        AllArvl.TableName = "ArrivalTB"
        AllArvl.WriteXml(SR)
        With Cmd
            .Connection = Cnn
            .CommandText = "Update TB_Voyage Set Nosavchr = @XML where ID = @ID"
            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@XML", SR.ToString)
            .Parameters.AddWithValue("@ID", VoyageID)
        End With
        Cmd.ExecuteNonQuery()

    End Sub

    Private Function GetLevel(ByVal Level As String, ByVal BL As DataRow, ByVal Voy As TB_Voyage, ByVal CL As TB_Clients) As String

        Dim Ans As String = Level

        If Level = "VOYAGE" Then
            Return Voy.VoyageAccount
        End If

        If Level = "CLIENT" Then
            If CL.IsReal = True Then
                Return CL.AccountA
            Else
                Return CL.AccountA
            End If
        End If

        If Level = "BL" Then
            Return BL("BLNO")
        End If

        If Level = "LINE" Then
            Return "2/151"
        End If


        If Level = "BANK" Then
            Return "???"
        End If
 
        Return Ans

    End Function

    Private Function TotalPer(ByVal Drs() As DataRow) As Integer

        Dim Dr As DataRow
        Dim nTotal As Double
        For Each Dr In Drs
            nTotal += Dr("Percentage")
        Next

        Return Integer.Parse(nTotal)


    End Function

    Public Sub GenerateConfirmVocher(ByVal DT As Date, ByRef Result As String)

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Arvl As CLArrivalNotice
        Dim BLData As TB_InwardBLS
        Dim SOF As TB_SOF
        Dim lResult As Boolean
        Dim DM As New DataManager(My.Settings.DSN)
        Dim Voy As TB_Voyage
        Dim TB As New DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim nDr As DataRow
        Dim Sql As String
        Dim BlRow As DataRow
        Dim TTlCR As Double
        Dim TTLDB As Double
        Dim Client As TB_Clients
        Dim BL As DataRow
        Dim Banks As TB_CODECollection
        Dim PTypes As TB_CODECollection

        Dim Bank As TB_CODE
        Dim PType As TB_CODE

        Dim ListOfInvoice As TB_InvoiceCollection
        Dim Invoice As TB_Invoice

        Dim InvoiceDetails As TB_InvoiceDetailsCollection
        Dim InvoiceDetail As TB_InvoiceDetails

        Dim RcvdItems As TB_RecivedItemsCollection
        Dim Rcvd As TB_RecivedItems

        Dim ArrivalItems As DataTable

        Dim Title As New DataTable
        Dim Titles() As DataRow

        Dim TitleSubs() As DataRow
        Dim TitleSub As DataTable
        Dim Tdr As DataRow
        Dim nPer As Double
        Dim nDrs() As DataRow

        Dim sArticle As String
        Dim SB As New StringBuilder

        Dim TbCompare As New DataTable
        Dim TbCompareAll As New DataTable

        Dim TTL As Double
        Dim VatPercent As Double

        Dim nTaxOver As Long
        Dim nTaxLess As Long

        Dim nChargeOver As Double
        Dim nChargeLess As Double
 
        Dim TbBase As New DataTable

        Dim TTLArvl As Double
        Dim TTLPaid As Double
        Dim TaxSub As DataTable
        Dim FirstPaid As Double
        Dim FirstPaidTB As New DataTable
        Dim DetnARow As DataRow
        Dim sDate As String
        Dim Calbase As New CLCalculationBase

        TbCompareAll.Columns.Add(New DataColumn("ChargeItem"))
        TbCompareAll.Columns.Add(New DataColumn("ArrivalAmount", System.Type.GetType("System.Double")))
        TbCompareAll.Columns.Add(New DataColumn("InvoiceAmount", System.Type.GetType("System.Double")))
        TbCompareAll.Columns.Add(New DataColumn("InvNo"))
 
        With TBNoInArrival
            .Columns.Add(New DataColumn("ChargeItem"))
            .Columns.Add(New DataColumn("InvoiceAmount", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Tax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("InvNo"))
        End With

        With TbSame
            .Columns.Add(New DataColumn("ChargeItem"))
            .Columns.Add(New DataColumn("InvoiceAmount", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Tax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("InvNo"))
        End With

        With TBNoSame
            .Columns.Add(New DataColumn("ChargeItem"))
            .Columns.Add(New DataColumn("InvoiceAmount", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("ArrivalAmount", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Tax", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("InvNo"))
        End With

        Dim Temp As New DataTable
        With Temp
            .Columns.Add(New DataColumn("LevelAcc"))
            .Columns.Add(New DataColumn("Level1"))
            .Columns.Add(New DataColumn("Level2"))
            .Columns.Add(New DataColumn("Level3"))
            .Columns.Add(New DataColumn("Level4"))
            .Columns.Add(New DataColumn("Level5"))
            .Columns.Add(New DataColumn("Amount"))
            .Columns.Add(New DataColumn("Desc"))
            .Columns.Add(New DataColumn("InvNo"))

        End With

        TableBySql("Select * From tb_NOSAAccount", Title, lResult)
        TableBySql("Select * From tb_NOSAAccountsub", TitleSub, lResult)
        '  TableBySql("Select * From TB_NOSPaidTaxTitle", TaxSub, lResult)

        TitleSub.Columns.Add("sFrom")
        TitleSub.Columns.Add("sTo")

        For Each Dr In TitleSub.Rows
            If Not IsDBNull(Dr("dFrom")) = True Then
                Dr("sFrom") = DTOS(Dr("dFrom"))
            End If
            If Not IsDBNull(Dr("dTo")) = True Then
                Dr("sTo") = DTOS(Dr("dTo"))
            End If
        Next
 
        nDrs = Title.Select("ChargesCode = 'DETN-A' and AccType = 'P'")
        If nDrs.Length > 0 Then
            DetnARow = nDrs(0)
        End If


        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "BK", MatchType.Exact)
        Banks = DM.GetTB_CODECollection

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "RT", MatchType.Exact)
        PTypes = DM.GetTB_CODECollection

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Invoice.Columns.ConfirmTime, DT, MatchType.Exact)
        ' DM.QueryCriteria.And(JoinPath.TB_Invoice.Columns.InvoiceNo, "T13I-00338", MatchType.Exact)
        ListOfInvoice = DM.GetTB_InvoiceCollection

        SB.AppendLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & "?>")
        SB.AppendLine("<_XPXML>")



        For Each Invoice In ListOfInvoice


            sDate = DTOS(Invoice.ConfirmTime)
            Calbase.GetTaxDutyDyDate(Invoice.ConfirmTime)

            TbCompare.Clear()
            TbCompareAll.Clear()
            Temp.Clear()
            TbBase.Clear()

            TTL = 0
            TTLArvl = 0
            TTLPaid = 0
            FirstPaid = 0

            DM = New DataManager(My.Settings.DSN)
            DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.ID, Invoice.BLID, MatchType.Exact)
            BLData = DM.GetTB_InwardBLS

            BLData = DM.GetTB_InwardBLS
            BL = DM.DataSet.Tables("TB_InwardBLS").Rows(0)

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, BL("ClienTID"), MatchType.Exact)
            Client = DM.GetTB_Clients

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, BLData.VoyageID, MatchType.Exact)
            Voy = DM.GetTB_Voyage

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, BLData.VoyageID, MatchType.Exact)
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.Port, BLData.POD, MatchType.Exact)
            SOF = DM.GetTB_SOF

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InvoiceDetails.Columns.InvoiceID, Invoice.ID, MatchType.Exact)
            InvoiceDetails = DM.GetTB_InvoiceDetailsCollection

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_RecivedItems.Columns.InvoiceID, Invoice.ID, MatchType.Exact)
            RcvdItems = DM.GetTB_RecivedItemsCollection

            Drs = DM.DataSet.Tables("TB_InvoiceDetails").Select("ChargesCode = 'DETN' or ChargesCode = 'DMCT'")

            TbCompare = New DataTable
            TbCompare = TbCompareAll.Copy

            TbBase = DM.DataSet.Tables("TB_InvoiceDetails").Copy
            TbBase.Clear()

            For Each Dr In DM.DataSet.Tables("TB_InvoiceDetails").Rows
                If Dr("ChargesCode") = "DETN-A" Or Dr("ChargesCode") = "TAX" Then
                Else
                    TbBase.ImportRow(Dr)
                End If
            Next

            If CDate(SOF.Arrival).Date > CDate("2013-02-25") Then
                Compare(DM.DataSet.Tables("TB_InwardBLS").Rows(0).Item("BLNO").ToString, DM.DataSet.Tables("TB_InwardBLS").Rows(0).Item("VoyageID").ToString, DM.DataSet.Tables("TB_InvoiceDetails"), VatPercent, Invoice)

            End If

            If TbBase.Rows.Count > 0 Then
                ' Process For New Items 
                For Each Dr In TBNoInArrival.Rows
                    Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                    If Titles.Length = 0 Then
                        MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                        Exit Sub
                    End If
                    If Dr("ChargeItem") = "DETN" Then
                        FirstPaidTB = New DataTable
                        TableBySql("select dbo.FC_InwardTotalChargByBIChgCurrency('" & Invoice.BLID.ToString & "' , 'DETN-A' , 'IRR')", FirstPaidTB, lResult)
                        FirstPaid = NullToValue(FirstPaidTB.Rows(0).Item(0), 0)
                    End If
                    If Titles(0).Item("AccType") = "A" Then
                        TTLArvl += Dr("InvoiceAmount")
                    Else
                        If FirstPaid > 0 And Dr("ChargeItem") = "DETN" Then
                            Dr("InvoiceAmount") = Dr("InvoiceAmount") + FirstPaid ' + ((Dr("InvoiceAmount") + FirstPaid) * 5 / 100)
                        End If
                        TTLPaid += Dr("InvoiceAmount")
                        Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                        If Titles.Length = 0 Then
                            MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                            Exit Sub
                        Else
                            TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= sFrom and '" & sDate & "' <= sTo")
                            For Each Tdr In TitleSubs
                                nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DBAccount") & "' and " & _
                                                                             "Level1 = '" & GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                                                             "Level2 = '" & GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                                                             "Level3 = '" & GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                                                             "Level4 = '" & GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                                                             "Level5 = '" & GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client) & "'")
                                If nDrs.Length = 0 Then
                                    nDr = Temp.NewRow
                                    nDr("LevelAcc") = Titles(0).Item("DBAccount")
                                    nDr("Level1") = GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client)
                                    nDr("Level2") = GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client)
                                    nDr("Level3") = GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client)
                                    nDr("Level4") = GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client)
                                    nDr("Level5") = GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client)
                                    If Titles(0).Item("AccType") = "A" Then
                                        nDr("Desc") = "بابت هزینه ترخیصیه بارنامه " & BLData.BlNo & " صورتحساب " & nDr("InvNo")
                                    Else
                                        nDr("Desc") = " بابت " & Titles(0).Item("Description") & " بارنامه " & BLData.BlNo & " صورتحساب " & Invoice.InvoiceNo
                                    End If
                                    If NullToValue(Tdr("Amount"), 0) > 0 Then
                                        nDr("Amount") = Tdr("Amount")
                                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                        nPer = Dr("InvoiceAmount")
                                        nPer = Math.Round((nPer * Tdr("Percentage") / 100))
                                        nDr("Amount") = nPer
                                    End If
                                    nDr("InvNo") = Invoice.InvoiceNo
                                    Temp.Rows.Add(nDr)
                                Else
                                    If NullToValue(Tdr("Amount"), 0) > 0 Then
                                        nDr("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
                                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                        nPer = Dr("InvoiceAmount")
                                        nPer = Math.Round((nPer * Tdr("Percentage") / 100))
                                        nDr("Amount") = nDrs(0).Item("Amount") + nPer
                                    End If
                                End If
                            Next

                            If FirstPaid > 0 Then
                                nDrs = Temp.Select("LevelAcc = '" & DetnARow("DBAccount") & "' and " & _
                                                                                                             "Level1 = '" & GetLevel(DetnARow.Item("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                                                                                             "Level2 = '" & GetLevel(DetnARow.Item("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                                                                                             "Level3 = '" & GetLevel(DetnARow.Item("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                                                                                             "Level4 = '" & GetLevel(DetnARow.Item("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                                                                                             "Level5 = '" & GetLevel(DetnARow.Item("DBLevel5").ToString, BL, Voy, Client) & "'")

                                nDr = Temp.NewRow
                                nDr("LevelAcc") = DetnARow.Item("DBAccount")
                                nDr("Level1") = GetLevel(DetnARow("DBLevel1").ToString, BL, Voy, Client)
                                nDr("Level2") = GetLevel(DetnARow("DBLevel2").ToString, BL, Voy, Client)
                                nDr("Level3") = GetLevel(DetnARow("DBLevel3").ToString, BL, Voy, Client)
                                nDr("Level4") = GetLevel(DetnARow("DBLevel4").ToString, BL, Voy, Client)
                                nDr("Level5") = GetLevel(DetnARow("DBLevel5").ToString, BL, Voy, Client)
                                nDr("Desc") = " بابت حق توقف بارنامه " & BLData.BlNo & " صورتحساب " & Invoice.InvoiceNo
                                nDr("Amount") = FirstPaid
                                Temp.Rows.Add(nDr)
                            End If
                        End If

                        'If Dr("ChargeItem") = "DETN" Then
                        '    TTL += Dr("InvoiceAmount") - FirstPaid
                        '    TTLPaid -= FirstPaid
                        'End If
                    End If
                Next

                'If TTLArvl > 0 Then
                '    Dr = TBNoInArrival.NewRow
                '    Dr("ChargeItem") = "TAX"
                '    Dr("InvoiceAmount") = Microsoft.VisualBasic.Fix((TTLPaid * (Calbase.Tax + Calbase.Duty) / 100))
                '    TBNoInArrival.Rows.Add(Dr)
                'End If

                'If TTLPaid > 0 Then
                '    Dr = TBNoInArrival.NewRow
                '    Dr("ChargeItem") = "TAX"
                '    Dr("InvoiceAmount") = Microsoft.VisualBasic.Fix((TTLPaid * (Calbase.Tax + Calbase.Duty) / 100))
                '    TBNoInArrival.Rows.Add(Dr)
                'End If

                For Each Dr In TBNoInArrival.Rows
                     
                    Temp.AcceptChanges()
                    Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                    If Titles.Length = 0 Then
                        MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                        Exit Sub
                    Else
                        TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= sFrom and '" & sDate & "' <= sTo")
                        If TitleSubs.Length = 0 Then
                            nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DBAccount") & "' and " & _
                                               "Level1 = '" & GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                               "Level2 = '" & GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                               "Level3 = '" & GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                               "Level4 = '" & GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                               "Level5 = '" & GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client) & "'")
                            If nDrs.Length = 0 Then
                                nDr = Temp.NewRow
                                nDr("LevelAcc") = Titles(0).Item("DBAccount")
                                nDr("Level1") = GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client)
                                nDr("Level2") = GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client)
                                nDr("Level3") = GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client)
                                nDr("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client)
                                nDr("Level5") = GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client)
                                If FirstPaid > 0 And Dr("ChargeItem") = "DETN" Then
                                    nDr("Amount") = (Dr("InvoiceAmount") - FirstPaid) + (Dr("InvoiceAmount") * (Calbase.Tax + Calbase.Duty) / 100)
                                Else
                                    nDr("Amount") = Dr("InvoiceAmount") + (Dr("InvoiceAmount") * (Calbase.Tax + Calbase.Duty) / 100)
                                End If
                                nDr("InvNo") = Invoice.InvoiceNo
                                If Titles(0).Item("AccType") = "A" Then
                                    nDr("Desc") = "بابت هزینه ترخیصیه بارنامه " & BLData.BlNo & " صورتحساب " & nDr("InvNo")
                                Else
                                    nDr("Desc") = " بابت " & " بارنامه " & BLData.BlNo & " صورتحساب " & Invoice.InvoiceNo
                                End If
                                Temp.Rows.Add(nDr)
                            Else
                                If FirstPaid > 0 And Dr("ChargeItem") = "DETN" Then
                                    nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + Dr("InvoiceAmount") + (Dr("InvoiceAmount") * (Calbase.Tax + Calbase.Duty) / 100) - FirstPaid
                                Else
                                    nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + Dr("InvoiceAmount") + (Dr("InvoiceAmount") * (Calbase.Tax + Calbase.Duty) / 100)
                                End If

                            End If
                        Else
                            For Each Tdr In TitleSubs
                                nDrs = Temp.Select("LevelAcc = '" & Tdr("DBAccount") & "' and " & _
                                                                         "Level1 = '" & GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level2 = '" & GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level3 = '" & GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level4 = '" & GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level5 = '" & GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client) & "'")
                                If nDrs.Length = 0 Then
                                    nDr = Temp.NewRow
                                    nDr("LevelAcc") = Titles(0).Item("DBAccount")
                                    nDr("Level1") = GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client)
                                    nDr("Level2") = GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client)
                                    nDr("Level3") = GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client)
                                    nDr("Level4") = GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client)
                                    nDr("Level5") = GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client)
                                    If NullToValue(Tdr("Amount"), 0) > 0 Then
                                        nDr("Amount") = Tdr("Amount")
                                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                        nPer = Dr("InvoiceAmount")
                                        nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
                                        nDr("Amount") = nPer
                                    End If
                                    nDr("InvNo") = Invoice.InvoiceNo
                                    If Titles(0).Item("AccType") = "A" Then
                                        nDr("Desc") = "بابت هزینه ترخیصیه بارنامه " & BLData.BlNo & " صورتحساب " & nDr("InvNo")
                                    Else
                                        nDr("Desc") = " بابت " & Titles(0).Item("Description") & " بارنامه " & BLData.BlNo & " صورتحساب " & Invoice.InvoiceNo
                                    End If

                                    Temp.Rows.Add(nDr)
                                Else
                                    If NullToValue(Tdr("Amount"), 0) > 0 Then
                                        nDr("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
                                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                        nPer = Dr("InvoiceAmount")
                                        nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
                                        nDr("Amount") = nDrs(0).Item("Amount") + nPer
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If

            For Each nDr In Temp.Rows
                If nDr("Amount") > 0 Then

                    sArticle = "<_FTrans Acc=" & """"
                    sArticle += nDr("LevelAcc") & """" & " "

                    sArticle += "Det1=" & """"
                    sArticle += nDr("Level1").ToString & """" & " "

                    sArticle += "Det2=" & """"
                    sArticle += nDr("Level2").ToString & """" & " "

                    sArticle += "Det3=" & """"
                    sArticle += nDr("Level3").ToString & """" & " "

                    sArticle += "Det4=" & """"
                    sArticle += nDr("Level4").ToString & """" & " "

                    sArticle += "Det5=" & """" & """" & " "


                    sArticle += "Deb=" & """"
                    sArticle += (NullToValue(nDr("Amount"), 0) / 100).ToString & """" & " "

                    '                   sArticle += "Desc=" & """" & "بابت هزینه ترخیصیه بارنامه " & BLData.BlNo & " صورتحساب " & nDr("InvNo") & """" & " "
                    sArticle += "Desc=" & """" & nDr("Desc") & """" & " "

                    sArticle += "ODesc=" & """" & BLData.BlNo & """" & " "

                    sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                    SB.AppendLine.AppendLine(sArticle)
                End If
            Next

            Temp.Clear()
            Temp.AcceptChanges()

            If TTLPaid > 0 Then
                Dr = TBNoInArrival.NewRow
                Dr("ChargeItem") = "TAX"
                Dr("InvoiceAmount") = Microsoft.VisualBasic.Fix((TTLPaid * (Calbase.Tax + Calbase.Duty) / 100))
                TBNoInArrival.Rows.Add(Dr)
            End If

            For Each Dr In TBNoInArrival.Rows

                Temp.AcceptChanges()
                Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                If Titles.Length = 0 Then
                    MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                    Exit Sub
                Else
                    TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= sFrom and '" & sDate & "' <= sTo")
                    If TitleSubs.Length = 0 Then
                        nDr = Temp.NewRow
                        nDr("LevelAcc") = Titles(0).Item("CRAccount")
                        nDr("Level1") = GetLevel(Titles(0).Item("CRLevel1").ToString, BL, Voy, Client)
                        nDr("Level2") = GetLevel(Titles(0).Item("CRLevel2").ToString, BL, Voy, Client)
                        nDr("Level3") = GetLevel(Titles(0).Item("CRLevel3").ToString, BL, Voy, Client)
                        nDr("Level4") = GetLevel(Titles(0).Item("CRLevel4").ToString, BL, Voy, Client)
                        nDr("Level5") = GetLevel(Titles(0).Item("CRLevel5").ToString, BL, Voy, Client)
                        nDr("Amount") = Dr("InvoiceAmount")
                        nDr("InvNo") = Invoice.InvoiceNo
                        nDr("Desc") = " بابت " & Titles(0).Item("Description") & " بارنامه " & BLData.BlNo & " صورتحساب " & Invoice.InvoiceNo
                        Temp.Rows.Add(nDr)
                    Else
                        For Each Tdr In TitleSubs
                            nDr = Temp.NewRow
                            nDr("LevelAcc") = Tdr("CRAccount")
                            nDr("Level1") = GetLevel(Tdr("CRLevel1").ToString, BL, Voy, Client)
                            nDr("Level2") = GetLevel(Tdr("CRLevel2").ToString, BL, Voy, Client)
                            nDr("Level3") = GetLevel(Tdr("CRLevel3").ToString, BL, Voy, Client)
                            nDr("Level4") = GetLevel(Tdr("CRLevel4").ToString, BL, Voy, Client)
                            nDr("Level5") = GetLevel(Tdr("CRLevel5").ToString, BL, Voy, Client)
                            nDr("InvNo") = Invoice.InvoiceNo
                            If NullToValue(Tdr("Amount"), 0) > 0 Then
                                nDr("Amount") = Tdr("Amount")
                            ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                nPer = Dr("InvoiceAmount")
                                nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
                                nDr("Amount") = nPer
                            End If
                            nDr("Desc") = " بابت " & Tdr("Description") & " بارنامه " & BLData.BlNo & " صورتحساب " & Invoice.InvoiceNo
                            Temp.Rows.Add(nDr)
                        Next
                    End If
                End If
            Next

            Temp.TableName = "Test"
            Temp.WriteXml("c:\Temp\Temp.xml")

            For Each nDr In Temp.Rows
                If nDr("Amount") > 0 Then
                    sArticle = "<_FTrans Acc=" & """"
                    sArticle += nDr("LevelAcc") & """" & " "

                    sArticle += "Det1=" & """"
                    sArticle += nDr("Level1").ToString & """" & " "

                    sArticle += "Det2=" & """"
                    sArticle += nDr("Level2").ToString & """" & " "

                    sArticle += "Det3=" & """"
                    sArticle += nDr("Level3").ToString & """" & " "

                    sArticle += "Det4=" & """"
                    sArticle += nDr("Level4").ToString & """" & " "

                    sArticle += "Det5=" & """" & """" & " "

                    sArticle += "Cre=" & """"
                    sArticle += (NullToValue(nDr("Amount"), 0) / 100).ToString & """" & " "

                    sArticle += "Desc=" & """" & nDr("Desc") & """" & " "
                    sArticle += "ODesc=" & """" & BLData.BlNo & """" & " "

                    sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                    SB.AppendLine.AppendLine(sArticle)
                End If
            Next

        Next

        Temp.Clear()
        Temp.AcceptChanges()

        ' Process For deferent Amount In Invoice & Arrival 

        Drs = TBNoSame.Select("InvoiceAmount > ArrivalAmount")

        TBNoInArrival = New DataTable
        TBNoInArrival.Columns.Add(New DataColumn("ChargeItem"))
        TBNoInArrival.Columns.Add(New DataColumn("InvoiceAmount", System.Type.GetType("System.Double")))
        TBNoInArrival.Columns.Add(New DataColumn("Tax", System.Type.GetType("System.Double")))

        For Each Dr In Drs
            VatPercent = Dr("Tax")
            nChargeOver = Dr("InvoiceAmount") - Dr("ArrivalAmount")
            nTaxOver = Math.Round(((nChargeOver * VatPercent / 100)))
            nDr = TBNoInArrival.NewRow
            nDr("ChargeItem") = Dr("ChargeItem")
            nDr("InvoiceAmount") = nChargeOver
            nDr("Tax") = nTaxOver
            TBNoInArrival.Rows.Add(nDr)

            nDr = TBNoInArrival.NewRow
            nDr("ChargeItem") = "TAX"
            nDr("InvoiceAmount") = nTaxOver
            nDr("Tax") = nTaxOver
            TBNoInArrival.Rows.Add(nDr)

        Next

        For Each Dr In TBNoInArrival.Rows
            Temp.AcceptChanges()
            Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
            If Titles.Length = 0 Then
                MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                Exit Sub
            Else
                TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= sFrom and '" & sDate & "' <= sTo")
                If TitleSubs.Length = 0 Then
                    nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DBAccount") & "' and " & _
                                       "Level1 = '" & GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                       "Level2 = '" & GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                       "Level3 = '" & GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                       "Level4 = '" & GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                       "Level5 = '" & GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client) & "'")
                    If nDrs.Length = 0 Then
                        nDr = Temp.NewRow
                        nDr("LevelAcc") = Titles(0).Item("DBAccount")
                        nDr("Level1") = GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client)
                        nDr("Level2") = GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client)
                        nDr("Level3") = GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client)
                        nDr("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client)
                        nDr("Level5") = GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client)
                        nDr("Amount") = Dr("InvoiceAmount")
                        nDr("InvNo") = Dr("InvoiceNo")
                        Temp.Rows.Add(nDr)
                    Else
                        nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + (Dr("InvoiceAmount"))
                    End If
                Else
                    For Each Tdr In TitleSubs
                        nDrs = Temp.Select("LevelAcc = '" & Tdr("DBAccount") & "' and " & _
                                                                 "Level1 = '" & GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                                                 "Level2 = '" & GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                                                 "Level3 = '" & GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                                                 "Level4 = '" & GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                                                 "Level5 = '" & GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client) & "'")
                        If nDrs.Length = 0 Then
                            nDr = Temp.NewRow
                            nDr("LevelAcc") = Titles(0).Item("DBAccount")
                            nDr("Level1") = GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client)
                            nDr("Level2") = GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client)
                            nDr("Level3") = GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client)
                            nDr("Level4") = GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client)
                            nDr("Level5") = GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client)
                            nDr("InvNo") = Dr("InvoiceNo")
                            If NullToValue(Tdr("Amount"), 0) > 0 Then
                                nDr("Amount") = Tdr("Amount")
                            ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                nPer = Dr("InvoiceAmount")
                                nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
                                nDr("Amount") = nPer
                            End If
                            Temp.Rows.Add(nDr)
                        Else
                            If NullToValue(Tdr("Amount"), 0) > 0 Then
                                nDr("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
                            ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                nPer = Dr("InvoiceAmount")
                                nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
                                nDr("Amount") = nDrs(0).Item("Amount") + nPer
                            End If
                        End If
                    Next
                End If
            End If
        Next


        For Each nDr In Temp.Rows

            If nDr("Amount") > 0 Then
                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDr("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDr("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDr("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDr("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDr("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "


                sArticle += "Deb=" & """"
                sArticle += (NullToValue(nDr("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & "بابت ما به التفاوت ترخیصیه بارنامه " & BLData.BlNo & " صورتحساب " & nDr("InvNo") & """" & " "
                sArticle += "ODesc=" & """" & BLData.BlNo & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)
            End If
        Next

        Temp.Clear()
        Temp.AcceptChanges()

        For Each Dr In TBNoInArrival.Rows

            Temp.AcceptChanges()
            Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
            If Titles.Length = 0 Then
                MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                Exit Sub
            Else
                TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= sFrom and '" & sDate & "' <= sTo")
                If TitleSubs.Length = 0 Then
                    nDr = Temp.NewRow
                    nDr("LevelAcc") = Titles(0).Item("CRAccount")
                    nDr("Level1") = GetLevel(Titles(0).Item("CRLevel1").ToString, BL, Voy, Client)
                    nDr("Level2") = GetLevel(Titles(0).Item("CRLevel2").ToString, BL, Voy, Client)
                    nDr("Level3") = GetLevel(Titles(0).Item("CRLevel3").ToString, BL, Voy, Client)
                    nDr("Level4") = GetLevel(Titles(0).Item("CRLevel4").ToString, BL, Voy, Client)
                    nDr("Level5") = GetLevel(Titles(0).Item("CRLevel5").ToString, BL, Voy, Client)
                    nDr("Amount") = Dr("InvoiceAmount")
                    nDr("InvNo") = Dr("InvoiceNo")
                    nDr("Desc") = Titles(0).Item("Description") & " بابت بارنامه " & BLData.BlNo & " صورتحساب " & Dr("InvoiceNo")
                    Temp.Rows.Add(nDr)
                Else
                    For Each Tdr In TitleSubs
                        nDr = Temp.NewRow
                        nDr("LevelAcc") = Tdr("CRAccount")
                        nDr("Level1") = GetLevel(Tdr("CRLevel1").ToString, BL, Voy, Client)
                        nDr("Level2") = GetLevel(Tdr("CRLevel2").ToString, BL, Voy, Client)
                        nDr("Level3") = GetLevel(Tdr("CRLevel3").ToString, BL, Voy, Client)
                        nDr("Level4") = GetLevel(Tdr("CRLevel4").ToString, BL, Voy, Client)
                        nDr("Level5") = GetLevel(Tdr("CRLevel5").ToString, BL, Voy, Client)
                        nDr("InvNo") = Dr("InvoiceNo")
                        If NullToValue(Tdr("Amount"), 0) > 0 Then
                            nDr("Amount") = Tdr("Amount")
                        ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                            nPer = Dr("InvoiceAmount")
                            nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
                            nDr("Amount") = nPer
                        End If
                        nDr("Desc") = Tdr("Description") & " بابت ما به التفاوت ترخیصیه بارنامه" & BLData.BlNo & " صورتحساب " & Dr("InvoiceNo")
                        Temp.Rows.Add(nDr)
                    Next
                End If
            End If
        Next

        For Each nDr In Temp.Rows

            If nDr("amount") > 0 Then
                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDr("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDr("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDr("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDr("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDr("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "

                sArticle += "Cre=" & """"
                sArticle += (NullToValue(nDr("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & nDr("Desc") & """" & " "
                sArticle += "ODesc=" & """" & BLData.BlNo & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)
            End If

        Next


        'Process Less Amount 

        Temp.Clear()
        Temp.AcceptChanges()

        Drs = TBNoSame.Select("InvoiceAmount < ArrivalAmount")
        TBNoInArrival = New DataTable
        TBNoInArrival.Columns.Add(New DataColumn("ChargeItem"))
        TBNoInArrival.Columns.Add(New DataColumn("InvoiceAmount", System.Type.GetType("System.Double")))
        TBNoInArrival.Columns.Add(New DataColumn("Tax", System.Type.GetType("System.Double")))

        For Each Dr In Drs
            nChargeLess = Dr("ArrivalAmount") - Dr("InvoiceAmount")
            nTaxLess = Math.Round((nChargeLess * VatPercent / 100))
            nDr = TBNoInArrival.NewRow
            nDr("ChargeItem") = Dr("ChargeItem")
            nDr("InvoiceAmount") = nChargeOver
            nDr("Tax") = nTaxOver
            nDr("InvNo") = Dr("InvoiceNo")
            TBNoInArrival.Rows.Add(nDr)

            nDr = TBNoInArrival.NewRow
            nDr("ChargeItem") = "TAX"
            nDr("InvoiceAmount") = nTaxOver
            nDr("Tax") = nTaxOver
            nDr("InvNo") = Dr("InvoiceNo")
            TBNoInArrival.Rows.Add(nDr)

        Next

        For Each Dr In TBNoInArrival.Rows

            Temp.AcceptChanges()
            Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
            If Titles.Length = 0 Then
                MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                Exit Sub
            Else
                TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= sFrom and '" & sDate & "' <= sTo")
                If TitleSubs.Length = 0 Then
                    nDr = Temp.NewRow
                    nDr("LevelAcc") = Titles(0).Item("DBAccount")
                    nDr("Level1") = GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client)
                    nDr("Level2") = GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client)
                    nDr("Level3") = GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client)
                    nDr("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client)
                    nDr("Level5") = GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client)
                    nDr("Amount") = Dr("InvoiceAmount")
                    nDr("InvNo") = Dr("InvoiceNo")
                    nDr("Desc") = Titles(0).Item("Description") & " بابت برگشت ترخیصیه بارنامه " & BLData.BlNo & " صورتحساب " & Dr("InvNo")
                    Temp.Rows.Add(nDr)
                Else
                    For Each Tdr In TitleSubs
                        nDr = Temp.NewRow
                        nDr("LevelAcc") = Tdr("DBAccount")
                        nDr("Level1") = GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client)
                        nDr("Level2") = GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client)
                        nDr("Level3") = GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client)
                        nDr("Level4") = GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client)
                        nDr("Level5") = GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client)
                        nDr("InvNo") = Dr("InvoiceNo")
                        If NullToValue(Tdr("Amount"), 0) > 0 Then
                            nDr("Amount") = Tdr("Amount")
                        ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                            nPer = Dr("InvoiceAmount")
                            nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
                            nDr("Amount") = nPer
                        End If
                        nDr("Desc") = Tdr("Description") & " بابت بارنامه " & BLData.BlNo & " صورتحساب " & Dr("InvNo")
                        Temp.Rows.Add(nDr)
                    Next
                End If
            End If
        Next

        For Each nDr In Temp.Rows

            If nDr("Amount") > 0 Then

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDr("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDr("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDr("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDr("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDr("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "

                sArticle += "Deb=" & """"
                sArticle += (NullToValue(nDr("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & nDr("Desc") & """" & " "
                sArticle += "ODesc=" & """" & BLData.BlNo & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)
            End If

        Next

        For Each Dr In TBNoInArrival.Rows
            Temp.AcceptChanges()
            Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
            If Titles.Length = 0 Then
                MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                Exit Sub
            Else
                TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= sFrom and '" & sDate & "' <= sTo")
                If TitleSubs.Length = 0 Then
                    nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("CrAccount") & "' and " & _
                                       "Level1 = '" & GetLevel(Titles(0).Item("CrLevel1").ToString, BL, Voy, Client) & "' and " & _
                                       "Level2 = '" & GetLevel(Titles(0).Item("CrLevel2").ToString, BL, Voy, Client) & "' and " & _
                                       "Level3 = '" & GetLevel(Titles(0).Item("CrLevel3").ToString, BL, Voy, Client) & "' and " & _
                                       "Level4 = '" & GetLevel(Titles(0).Item("CrLevel4").ToString, BL, Voy, Client) & "' and " & _
                                       "Level5 = '" & GetLevel(Titles(0).Item("CrLevel5").ToString, BL, Voy, Client) & "'")
                    If nDrs.Length = 0 Then
                        nDr = Temp.NewRow
                        nDr("LevelAcc") = Titles(0).Item("CrAccount")
                        nDr("Level1") = GetLevel(Titles(0).Item("CrLevel1").ToString, BL, Voy, Client)
                        nDr("Level2") = GetLevel(Titles(0).Item("CrLevel2").ToString, BL, Voy, Client)
                        nDr("Level3") = GetLevel(Titles(0).Item("CrLevel3").ToString, BL, Voy, Client)
                        nDr("Level4") = GetLevel(Titles(0).Item("CrLevel4").ToString, BL, Voy, Client)
                        nDr("Level5") = GetLevel(Titles(0).Item("CrLevel5").ToString, BL, Voy, Client)
                        nDr("Amount") = Dr("InvoiceAmount")
                        nDr("InvNo") = Dr("InvoiceNo")
                        Temp.Rows.Add(nDr)
                    Else
                        nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + Dr("InvoiceAmount")
                    End If
                Else
                    For Each Tdr In TitleSubs
                        nDrs = Temp.Select("LevelAcc = '" & Tdr("CrAccount") & "' and " & _
                                                                 "Level1 = '" & GetLevel(Tdr("CrLevel1").ToString, BL, Voy, Client) & "' and " & _
                                                                 "Level2 = '" & GetLevel(Tdr("CrLevel2").ToString, BL, Voy, Client) & "' and " & _
                                                                 "Level3 = '" & GetLevel(Tdr("CrLevel3").ToString, BL, Voy, Client) & "' and " & _
                                                                 "Level4 = '" & GetLevel(Tdr("CrLevel4").ToString, BL, Voy, Client) & "' and " & _
                                                                 "Level5 = '" & GetLevel(Tdr("CrLevel5").ToString, BL, Voy, Client) & "'")
                        If nDrs.Length = 0 Then
                            nDr = Temp.NewRow
                            nDr("LevelAcc") = Titles(0).Item("CrAccount")
                            nDr("Level1") = GetLevel(Tdr("CrLevel1").ToString, BL, Voy, Client)
                            nDr("Level2") = GetLevel(Tdr("CrLevel2").ToString, BL, Voy, Client)
                            nDr("Level3") = GetLevel(Tdr("CrLevel3").ToString, BL, Voy, Client)
                            nDr("Level4") = GetLevel(Tdr("CrLevel4").ToString, BL, Voy, Client)
                            nDr("Level5") = GetLevel(Tdr("CrLevel5").ToString, BL, Voy, Client)
                            nDr("InvNo") = Dr("InvoiceNo")
                            If NullToValue(Tdr("Amount"), 0) > 0 Then
                                nDr("Amount") = Tdr("Amount")
                            ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                nPer = Dr("InvoiceAmount")
                                nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
                                nDr("Amount") = nPer
                            End If
                            Temp.Rows.Add(nDr)
                        Else
                            If NullToValue(Tdr("Amount"), 0) > 0 Then
                                nDr("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
                            ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                nPer = Dr("InvoiceAmount")
                                nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
                                nDr("Amount") = nDrs(0).Item("Amount") + nPer
                            End If
                        End If
                    Next
                End If
            End If
        Next


        For Each nDr In Temp.Rows

            If nDr("Amount") > 0 Then
                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDr("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDr("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDr("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDr("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDr("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "


                sArticle += "Cre=" & """"
                sArticle += (NullToValue(nDr("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & "بابت برگشت ترخیصیه بارنامه " & BLData.BlNo & " صورتحساب " & Dr("InvNo") & """" & " "
                sArticle += "ODesc=" & """" & BLData.BlNo & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)
            End If
        Next

        SB.AppendLine("</_XPXML>")
        Result = SB.ToString

        MsgBox("Generate Successful")

    End Sub

    Private Sub Compare(ByVal BLNo As String, ByVal VoyageID As String, ByVal InvoiceDetails As DataTable, ByRef TaxPercent As Double, ByVal Invoice As TB_Invoice)

        Dim Tb As New DataTable
        Dim sSql As String
        Dim lResult As Boolean
        Dim InvDr As DataRow
        Dim InvDrs() As DataRow
        Dim ArrRow As DataRow
        Dim ArrRows() As DataRow
        Dim CompDr As DataRow
        Dim TTLMan As Double
        Dim Dr As DataRow
        Dim TaxAmount As Double
        Dim Drs() As DataRow
        Dim calBase As New CLCalculationBase

        TBNoInArrival.Clear()
        TBNoInInvoice.Clear()

        TBNoInArrival.AcceptChanges()
        TBNoInInvoice.AcceptChanges()

         For Each Dr In Tb.Rows
            If Dr("ChargeItem") = "TAX" Or Dr("ChargeItem") = "TOLL" Or Dr("ChargeItem") = "DUTY" Then
                TaxAmount += Dr("MandatoryAmount")
            Else
                TTLMan += Dr("MandatoryAmount")
            End If
        Next

        Drs = InvoiceDetails.Select("ChargesCode = 'DETN' or ChargesCode = 'DMCT'")

        sSql = "SP_ExtractDataFromNosa '" & VoyageID & "' , '" & LTrim(RTrim((BLNo))) & "'"
 

        TableBySql(sSql, Tb, lResult)
 
        If TTLMan = 0 Then
            calBase.GetTaxDutyDyDate(Invoice.ConfirmTime)
            TaxPercent = calBase.Tax + calBase.Duty
        Else
            TaxPercent = TaxAmount * 100 / TTLMan
        End If

        For Each Dr In Tb.Rows
            If Dr("ChargeItem") = "DOLCL" Then
                Dr("ChargeItem") = "DO"
            End If
        Next
        Tb.AcceptChanges()

        For Each Dr In InvoiceDetails.Rows
            If Dr("ChargesCode") = "DOLCL" Then
                Dr("ChargesCode") = "DO"
            End If
        Next

        InvoiceDetails.AcceptChanges()



        If Tb.Rows.Count = 0 Then
            For Each InvDr In InvoiceDetails.Rows
                If InvDr("ChargesCode") = "DETN-A" Or InvDr("ChargesCode") = "TAX" Or InvDr("ChargesCode") = "TOLL" Then
                Else
                    CompDr = TBNoInArrival.NewRow
                    CompDr("ChargeItem") = InvDr("ChargesCode")
                    CompDr("InvoiceAmount") = InvDr("IrrAmount")
                    CompDr("InvNo") = Invoice.InvoiceNo
                    TBNoInArrival.Rows.Add(CompDr)
                End If
            Next
            TaxPercent = 0
        Else
            For Each InvDr In InvoiceDetails.Rows
                If InvDr("ChargesCode") = "DETN-A" Or InvDr("ChargesCode") = "TAX" Or InvDr("ChargesCode") = "TOLL" Then
                Else

                    ArrRows = Tb.Select("ChargeItem = '" & InvDr("ChargesCode") & "' and ActualAmount + MandatoryAmount + ConditionalAmount > 0 ")
                    If ArrRows.Length = 0 Then
                        CompDr = TBNoInArrival.NewRow
                        CompDr("ChargeItem") = InvDr("ChargesCode")
                        If InvDr("Currency") <> "IRR" And InvDr("IrrAmount") = 0 Then
                            CompDr("InvoiceAmount") = InvDr("Amount") * 12260
                        Else
                            CompDr("InvoiceAmount") = IIf(InvDr("IrrAmount") > 0, InvDr("IrrAmount"), 0)
                        End If

                        CompDr("Tax") = TaxPercent
                        CompDr("InvNo") = Invoice.InvoiceNo
                        TBNoInArrival.Rows.Add(CompDr)
                    Else
                        If Drs.Length > 0 Then
                            If ArrRows(0).Item("ConditionalAmount") + ArrRows(0).Item("MandatoryAmount") <> InvDr("IrrAmount") Then
                                CompDr = TBNoSame.NewRow
                                CompDr("ChargeItem") = InvDr("ChargesCode")
                                CompDr("InvoiceAmount") = InvDr("IrrAmount")
                                CompDr("ArrivalAmount") = ArrRows(0).Item("ConditionalAmount") + ArrRows(0).Item("MandatoryAmount")
                                CompDr("Tax") = TaxPercent
                                CompDr("InvNo") = Invoice.InvoiceNo
                                TBNoSame.Rows.Add(CompDr)
                            Else
                                CompDr = TbSame.NewRow
                                CompDr("ChargeItem") = InvDr("ChargesCode")
                                If InvDr("Currency") <> "IRR" And InvDr("IrrAmount") = 0 Then
                                    CompDr("InvoiceAmount") = InvDr("Amount") * 12260
                                Else
                                    CompDr("InvoiceAmount") = IIf(InvDr("IrrAmount") > 0, InvDr("IrrAmount"), 0)
                                End If
                                CompDr("Tax") = TaxPercent
                                CompDr("InvNo") = Invoice.InvoiceNo
                                TbSame.Rows.Add(CompDr)
                            End If
                        End If
                    End If
                End If
            Next
        End If

    End Sub

    Public Sub GenerateNOSAClose(ByRef Result As String, ByVal DateOf As Date, _
                                   ByVal RegenrateDate As String)

        Dim DS As New DataSet
        Dim TbBls As New DataTable
        Dim lResult As Boolean
        Dim DrBls() As DataRow
        Dim DrBl As DataRow
        Dim TBDetail As New DataTable
        Dim TaxPercent As Double
        Dim TBResult As New DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection
        Dim DA As New SqlDataAdapter
        Dim Vsl As TB_Vessels

        Dim YY As String = DateOf.Year.ToString
        Dim MM As String = DateOf.Month.ToString
        Dim DD As String = DateOf.Day

        Dim Title As New DataTable
        Dim Titles() As DataRow

        Dim TitleSubs() As DataRow
        Dim TitleSub As DataTable

        Dim TaxSub As DataTable

        Dim nDR As DataRow
        Dim nDrs() As DataRow

        Dim Voy As TB_Voyage
        Dim Client As TB_Clients
        Dim Bldata As TB_InwardBLS
        Dim Tdr As DataRow

        Dim DM As New DataManager(My.Settings.DSN)

        Dim Temp As New DataTable
        Dim TBReturn As New DataTable

        Dim nPer As Double

        Dim SB As New StringBuilder
        Dim sArticle As String

        Dim nI As Long
        Dim sDate As String
        Dim SOF As TB_SOF
 
        If Len(MM) = 1 Then
            MM = "0" & MM
        End If

        If Len(DD) = 1 Then
            DD = "0" & DD
        End If

        sDate = YY & MM & DD

        SB.AppendLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & "?>")
        SB.AppendLine("<_XPXML>")

        With Temp
            .Columns.Add(New DataColumn("LevelAcc"))
            .Columns.Add(New DataColumn("Level1"))
            .Columns.Add(New DataColumn("Level2"))
            .Columns.Add(New DataColumn("Level3"))
            .Columns.Add(New DataColumn("Level4"))
            .Columns.Add(New DataColumn("Level5"))
            .Columns.Add(New DataColumn("Amount"))
            .Columns.Add(New DataColumn("Desc"))
            .Columns.Add(New DataColumn("InvNo"))
        End With

        With TBReturn
            .Columns.Add(New DataColumn("BLID"))
            .Columns.Add(New DataColumn("InvNo"))
            .Columns.Add(New DataColumn("BLNO"))
            .Columns.Add(New DataColumn("ChargeItem"))
            .Columns.Add(New DataColumn("ConditionalAmount", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("MandatoryAmount", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Tax", System.Type.GetType("System.Double")))
        End With

        TableBySql("Select * From TB_NOSAAccount", Title, lResult)
        TableBySql("Select * From TB_NOSAAccountsub", TitleSub, lResult)
        TableBySql("Select * From TB_NOSPaidTaxTitle", TaxSub, lResult)

        If RegenrateDate = "Y" Then
            Cnn.ConnectionString = My.Settings.DSN
            Cnn.Open()
            With Cmd
                .CommandText = "SP_NOSAFinalVchrReGen"
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@FinalizeDate", DateOf.Date)
                .Connection = Cnn
            End With
            DA.SelectCommand = Cmd
            DA.Fill(DS)
            DrBls = DS.Tables(0).Select("", "")
        Else
            DataSetBySql("SP_NOSAFinalVchr", DS, lResult)
            DrBls = DS.Tables(0).Select("AllCnsReturned = 'YES' and LastReturn <= '" & sDate & "'")
        End If
        '    DrBls = DS.Tables(0).Select("BLNO = '2018100230'")
 
        TBFinal = DS.Tables(0)

        TBResult = DS.Tables(1).Copy
        TBResult.Clear()
        TBResult.AcceptChanges()

        TBResult.Columns.Add(New DataColumn("Status"))
        TBResult.Columns.Add(New DataColumn("Balance", System.Type.GetType("System.Double")))
        TBResult.Columns.Add(New DataColumn("BLNO"))

        'Prossess for Returned Items 

        For Each DrBl In DrBls

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, DrBl("VoyageID"), MatchType.Exact)
            SOF = DM.GetTB_SOF

            If SOF Is Nothing Then
                DrBl.Delete()
            End If
        Next
        DS.AcceptChanges()
        DrBls = DS.Tables(0).Select("AllCnsReturned = 'YES' and LastReturn <= '" & sDate & "'")
 
        For Each DrBl In DrBls

            nI += 1
            Temp.Clear()
            Temp.AcceptChanges()
            TBReturn.Clear()
            TBReturn.AcceptChanges()
            CompareFinal(DrBl("ID").ToString, DrBl("BLNO"), DrBl("VoyageID").ToString, DS.Tables(1), TaxPercent, TBResult, TBReturn)

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, DrBl("ClientID"), MatchType.Exact)
            Client = DM.GetTB_Clients

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, DrBl("VoyageID"), MatchType.Exact)
            Voy = DM.GetTB_Voyage

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, DrBl("VoyageID"), MatchType.Exact)
            SOF = DM.GetTB_SOF

            If SOF Is Nothing Then
                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Voy.VesselID, MatchType.Exact)
                Vsl = DM.GetTB_Vessels
                MsgBox("No SOF Data for " & Vsl.VesselName & " " & Voy.VoyageNo)
                Exit Sub
            End If


            sDate = DTOS(SOF.Arrival)

            sDate = Mid(sDate, 1, 4) & "-" & Mid(sDate, 5, 2) & "-" & Mid(sDate, 7, 2)

            For Each Dr In TBReturn.Rows

                If Dr("ConditionalAmount") + Dr("MandatoryAmount") > 0 Then

                    Temp.AcceptChanges()
                    Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                    If Titles.Length = 0 Then
                        MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                        Exit Sub
                    Else
                        '      TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' ")
                        TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & CDate(sDate) & "' >= dFrom and '" & sDate & "' <= dTo")

                        If TitleSubs.Length = 0 Then
                            nDR = Temp.NewRow
                            nDR("LevelAcc") = Titles(0).Item("CrAccount")
                            nDR("Level1") = GetLevel(Titles(0).Item("CrLevel1").ToString, Dr, Voy, Client)
                            nDR("Level2") = GetLevel(Titles(0).Item("CrLevel2").ToString, Dr, Voy, Client)
                            nDR("Level3") = GetLevel(Titles(0).Item("CrLevel3").ToString, Dr, Voy, Client)
                            nDR("Level4") = GetLevel(Titles(0).Item("CrLevel4").ToString, Dr, Voy, Client)
                            nDR("Level5") = GetLevel(Titles(0).Item("CrLevel5").ToString, Dr, Voy, Client)
                            nDR("Amount") = Dr("ConditionalAmount") + Dr("MandatoryAmount")
                            nDR("Desc") = Titles(0).Item("Description") & " بابت برگشت بارنامه " & Dr("BLNO")
                            Temp.Rows.Add(nDR)
                        Else
                            For Each Tdr In TitleSubs
                                nDR = Temp.NewRow
                                nDR("LevelAcc") = Tdr("CrAccount")
                                nDR("Level1") = GetLevel(Tdr("CrLevel1").ToString, Dr, Voy, Client)
                                nDR("Level2") = GetLevel(Tdr("CrLevel2").ToString, Dr, Voy, Client)
                                nDR("Level3") = GetLevel(Tdr("CrLevel3").ToString, Dr, Voy, Client)
                                nDR("Level4") = GetLevel(Tdr("CrLevel4").ToString, Dr, Voy, Client)
                                nDR("Level5") = GetLevel(Tdr("CrLevel5").ToString, Dr, Voy, Client)
                                If NullToValue(Tdr("Amount"), 0) > 0 Then
                                    nDR("Amount") = Tdr("Amount")
                                ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                    nPer = (Dr("ConditionalAmount") + Dr("MandatoryAmount"))
                                    nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                    nDR("Amount") = Math.Round(nPer)
                                End If
                                nDR("Desc") = Tdr("Description") & " بابت برگشت بارنامه " & Dr("BLNO")
                                Temp.Rows.Add(nDR)
                            Next
                        End If
                    End If
                End If
            Next

            For Each nDR In Temp.Rows

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDR("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDR("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDR("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDR("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDR("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "

                sArticle += "Deb=" & """"
                sArticle += (NullToValue(nDR("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & nDR("Desc") & """" & " "
                sArticle += "ODesc=" & """" & DrBl("BLNO") & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)

            Next

            Temp.Clear()
            Temp.AcceptChanges()

            For Each Dr In TBReturn.Select("", "BLID")
                Temp.AcceptChanges()
                Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")

                If Titles.Length = 0 Then
                    MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                    Exit Sub
                Else
                    '       TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                    TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= dFrom and '" & sDate & "' <= dTo")

                    If TitleSubs.Length = 0 Then
                        nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DbAccount") & "' and " & _
                                           "Level1 = '" & GetLevel(Titles(0).Item("DbLevel1").ToString, Dr, Voy, Client) & "' and " & _
                                           "Level2 = '" & GetLevel(Titles(0).Item("DbLevel2").ToString, Dr, Voy, Client) & "' and " & _
                                           "Level3 = '" & GetLevel(Titles(0).Item("DbLevel3").ToString, Dr, Voy, Client) & "' and " & _
                                           "Level4 = '" & GetLevel(Titles(0).Item("DbLevel4").ToString, Dr, Voy, Client) & "' and " & _
                                           "Level5 = '" & GetLevel(Titles(0).Item("DbLevel5").ToString, Dr, Voy, Client) & "'")
                        If nDrs.Length = 0 Then
                            nDR = Temp.NewRow
                            nDR("LevelAcc") = Titles(0).Item("DbAccount")
                            nDR("Level1") = GetLevel(Titles(0).Item("DbLevel1").ToString, Dr, Voy, Client)
                            nDR("Level2") = GetLevel(Titles(0).Item("DbLevel2").ToString, Dr, Voy, Client)
                            nDR("Level3") = GetLevel(Titles(0).Item("DbLevel3").ToString, Dr, Voy, Client)
                            nDR("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, Dr, Voy, Client)
                            nDR("Level5") = GetLevel(Titles(0).Item("DbLevel5").ToString, Dr, Voy, Client)
                            nDR("Amount") = Dr("ConditionalAmount") + Dr("MandatoryAmount")
                            Temp.Rows.Add(nDR)
                        Else
                            nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + (Dr("ConditionalAmount") + Dr("MandatoryAmount"))
                        End If
                    Else
                        For Each Tdr In TitleSubs
                            nDrs = Temp.Select("LevelAcc = '" & Tdr("DBAccount") & "' and " & _
                                                                     "Level1 = '" & GetLevel(Tdr("DBLevel1").ToString, Dr, Voy, Client) & "' and " & _
                                                                     "Level2 = '" & GetLevel(Tdr("DbLevel2").ToString, Dr, Voy, Client) & "' and " & _
                                                                     "Level3 = '" & GetLevel(Tdr("DbLevel3").ToString, Dr, Voy, Client) & "' and " & _
                                                                     "Level4 = '" & GetLevel(Tdr("DbLevel4").ToString, Dr, Voy, Client) & "' and " & _
                                                                     "Level5 = '" & GetLevel(Tdr("DbLevel5").ToString, Dr, Voy, Client) & "'")
                            If nDrs.Length = 0 Then
                                nDR = Temp.NewRow
                                nDR("LevelAcc") = Titles(0).Item("DbAccount")
                                nDR("Level1") = GetLevel(Tdr("DbLevel1").ToString, Dr, Voy, Client)
                                nDR("Level2") = GetLevel(Tdr("DbLevel2").ToString, Dr, Voy, Client)
                                nDR("Level3") = GetLevel(Tdr("DbLevel3").ToString, Dr, Voy, Client)
                                nDR("Level4") = GetLevel(Tdr("DBLevel4").ToString, Dr, Voy, Client)
                                nDR("Level5") = GetLevel(Tdr("DbLevel5").ToString, Dr, Voy, Client)
                                If NullToValue(Tdr("Amount"), 0) > 0 Then
                                    nDR("Amount") = Tdr("Amount")
                                ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                    nPer = (Dr("ConditionalAmount") + Dr("MandatoryAmount"))
                                    nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                    nDR("Amount") = Math.Round(nPer)
                                End If
                                Temp.Rows.Add(nDR)
                            Else
                                If NullToValue(Tdr("Amount"), 0) > 0 Then
                                    nDR("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
                                ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                    nPer = (Dr("ConditionalAmount") + Dr("MandatoryAmount"))
                                    nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                    nDR("Amount") = nDrs(0).Item("Amount") + Math.Round(nPer)
                                End If
                            End If
                        Next
                    End If
                End If

            Next

            Temp.AcceptChanges()
            For Each nDR In Temp.Rows

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDR("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDR("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDR("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDR("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDR("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "

                sArticle += "Cre=" & """"
                sArticle += (NullToValue(nDR("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & "بابت برگشت بارنامه " & DrBl("BLNO") & """" & " "
                sArticle += "ODesc=" & """" & DrBl("BLNO") & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)


            Next

        Next

        'Prossess for no balance Items 

        TbBls = New DataTable
        TbBls.Columns.Add(New DataColumn("BLNO"))
        TbBls.Columns.Add(New DataColumn("BLID"))
        TbBls.Columns.Add(New DataColumn("TTLAMT", System.Type.GetType("System.Double")))

        nDrs = TBResult.Select("status = 'G' ", "BLNO")
        For Each Dr In nDrs
            Drs = TbBls.Select("BLNO = '" & Dr("BLNO") & "'")
            If Drs.Length = 0 Then
                nDR = TbBls.NewRow
                nDR("BLID") = Dr("BLID")
                nDR("BLNO") = Dr("BLNO")
                nDR("TTlamt") = Dr("Balance")
                TbBls.Rows.Add(nDR)
            Else
                Drs(0).Item("TTlamt") = Drs(0).Item("TTlamt") + Dr("Balance")
            End If
        Next

        For Each Dr In TbBls.Rows
            nDR = TBResult.NewRow
            nDR("BLID") = Dr("BLID")
            nDR("BLNO") = Dr("BLNO")
            nDR("Amount") = Math.Round(Dr("TTLAmt") * 5 / 100)
            nDR("Balance") = Math.Round(Dr("TTLAmt") * 5 / 100)
            nDR("ChargesCode") = "TAX"
            TBResult.Rows.Add(nDR)
        Next

        For Each DrBl In TbBls.Rows


            Temp.Clear()
            Temp.AcceptChanges()

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, DrBl("BLNO"), MatchType.Exact)
            Bldata = DM.GetTB_InwardBLS
            DrBl("BLNO") = Bldata.BlNo


            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bldata.ClientID, MatchType.Exact)
            Client = DM.GetTB_Clients

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Bldata.VoyageID, MatchType.Exact)
            Voy = DM.GetTB_Voyage

            For Each Dr In TBResult.Select("BLNO = '" & DrBl("BLNO") & "'")

                Titles = Title.Select("ChargesCode = '" & Dr("ChargesCode") & "'")
                If Titles.Length = 0 Then
                    MsgBox("No Charge Define [" & Dr("ChargesCode") & "]")
                    Exit Sub
                Else
                    ' TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                    TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= dFrom and '" & sDate & "' <= dTo")

                    If TitleSubs.Length = 0 Then
                        nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DBAccount") & "' and " & _
                                           "Level1 = '" & GetLevel(Titles(0).Item("DBLevel1").ToString, DrBl, Voy, Client) & "' and " & _
                                           "Level2 = '" & GetLevel(Titles(0).Item("DBLevel2").ToString, DrBl, Voy, Client) & "' and " & _
                                           "Level3 = '" & GetLevel(Titles(0).Item("DBLevel3").ToString, DrBl, Voy, Client) & "' and " & _
                                           "Level4 = '" & GetLevel(Titles(0).Item("DBLevel4").ToString, DrBl, Voy, Client) & "' and " & _
                                           "Level5 = '" & GetLevel(Titles(0).Item("DBLevel5").ToString, DrBl, Voy, Client) & "'")
                        If nDrs.Length = 0 Then
                            nDR = Temp.NewRow
                            nDR("LevelAcc") = Titles(0).Item("DBAccount")
                            nDR("Level1") = GetLevel(Titles(0).Item("DBLevel1").ToString, DrBl, Voy, Client)
                            nDR("Level2") = GetLevel(Titles(0).Item("DBLevel2").ToString, DrBl, Voy, Client)
                            nDR("Level3") = GetLevel(Titles(0).Item("DBLevel3").ToString, DrBl, Voy, Client)
                            nDR("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, DrBl, Voy, Client)
                            nDR("Level5") = GetLevel(Titles(0).Item("DBLevel5").ToString, DrBl, Voy, Client)
                            nDR("Amount") = Dr("Balance")
                            Temp.Rows.Add(nDR)
                        Else
                            nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + Dr("Balance")
                        End If
                    Else
                        For Each Tdr In TitleSubs
                            nDrs = Temp.Select("LevelAcc = '" & Tdr("DBAccount") & "' and " & _
                                                                     "Level1 = '" & GetLevel(Tdr("DBLevel1").ToString, DrBl, Voy, Client) & "' and " & _
                                                                     "Level2 = '" & GetLevel(Tdr("DBLevel2").ToString, DrBl, Voy, Client) & "' and " & _
                                                                     "Level3 = '" & GetLevel(Tdr("DBLevel3").ToString, DrBl, Voy, Client) & "' and " & _
                                                                     "Level4 = '" & GetLevel(Tdr("DBLevel4").ToString, DrBl, Voy, Client) & "' and " & _
                                                                     "Level5 = '" & GetLevel(Tdr("DBLevel5").ToString, DrBl, Voy, Client) & "'")
                            If nDrs.Length = 0 Then
                                nDR = Temp.NewRow
                                nDR("LevelAcc") = Titles(0).Item("DBAccount")
                                nDR("Level1") = GetLevel(Tdr("DBLevel1").ToString, DrBl, Voy, Client)
                                nDR("Level2") = GetLevel(Tdr("DBLevel2").ToString, DrBl, Voy, Client)
                                nDR("Level3") = GetLevel(Tdr("DBLevel3").ToString, DrBl, Voy, Client)
                                nDR("Level4") = GetLevel(Tdr("DBLevel4").ToString, DrBl, Voy, Client)
                                nDR("Level5") = GetLevel(Tdr("DBLevel5").ToString, DrBl, Voy, Client)
                                If NullToValue(Tdr("Amount"), 0) > 0 Then
                                    nDR("Amount") = Tdr("Amount")
                                ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                    nPer = Tdr("Amount")
                                    nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                    nDR("Amount") = Math.Round(nPer)
                                End If
                                Temp.Rows.Add(nDR)
                            Else
                                If NullToValue(Tdr("Amount"), 0) > 0 Then
                                    nDR("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
                                ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                    nPer = Dr("Amount")
                                    nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                    nDR("Amount") = nDrs(0).Item("Amount") + Math.Round(nPer)
                                End If
                            End If
                        Next
                    End If
                End If
            Next


            For Each nDR In Temp.Rows

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDR("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDR("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDR("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDR("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDR("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "


                sArticle += "Deb=" & """"
                sArticle += (NullToValue(nDR("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & "بابت مابه التفاوت بارنامه " & DrBl("BLNO") & """" & " "
                sArticle += "ODesc=" & """" & DrBl("BLNO") & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)

            Next

            Temp.Clear()
            Temp.AcceptChanges()
            For Each Dr In TBResult.Select("BLNO = '" & DrBl("BLNo") & "'")

                Titles = Title.Select("ChargesCode = '" & Dr("ChargesCode") & "'")
                If Titles.Length = 0 Then
                    MsgBox("No Charge Define [" & Dr("ChargesCode") & "]")
                    Exit Sub
                Else
                    '                TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                    TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= dFrom and '" & sDate & "' <= dTo")

                    If TitleSubs.Length = 0 Then
                        nDR = Temp.NewRow
                        nDR("LevelAcc") = Titles(0).Item("CRAccount")
                        nDR("Level1") = GetLevel(Titles(0).Item("CRLevel1").ToString, DrBl, Voy, Client)
                        nDR("Level2") = GetLevel(Titles(0).Item("CRLevel2").ToString, DrBl, Voy, Client)
                        nDR("Level3") = GetLevel(Titles(0).Item("CRLevel3").ToString, DrBl, Voy, Client)
                        nDR("Level4") = GetLevel(Titles(0).Item("CRLevel4").ToString, DrBl, Voy, Client)
                        nDR("Level5") = GetLevel(Titles(0).Item("CRLevel5").ToString, DrBl, Voy, Client)
                        nDR("Amount") = Dr("Balance")
                        nDR("Desc") = Titles(0).Item("Description") & " بابت ما به التفاوت بارنامه " & DrBl("BLNO")
                        Temp.Rows.Add(nDR)
                    Else
                        For Each Tdr In TitleSubs
                            nDR = Temp.NewRow
                            nDR("LevelAcc") = Tdr("CRAccount")
                            nDR("Level1") = GetLevel(Tdr("CRLevel1").ToString, DrBl, Voy, Client)
                            nDR("Level2") = GetLevel(Tdr("CRLevel2").ToString, DrBl, Voy, Client)
                            nDR("Level3") = GetLevel(Tdr("CRLevel3").ToString, DrBl, Voy, Client)
                            nDR("Level4") = GetLevel(Tdr("CRLevel4").ToString, DrBl, Voy, Client)
                            nDR("Level5") = GetLevel(Tdr("CRLevel5").ToString, DrBl, Voy, Client)
                            If NullToValue(Tdr("Amount"), 0) > 0 Then
                                nDR("Amount") = Tdr("Amount")
                            ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                nPer = (Dr("Amount"))
                                nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                nDR("Amount") = Math.Round(nPer)
                            End If
                            nDR("Desc") = Tdr("Description") & " بابت مابه التفاوت بارنامه " & DrBl("BLNO")
                            Temp.Rows.Add(nDR)
                        Next
                    End If
                End If
            Next

            For Each nDR In Temp.Rows

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDR("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDR("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDR("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDR("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDR("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "

                sArticle += "Cre=" & """"
                sArticle += (NullToValue(nDR("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & nDR("Desc") & """" & " "
                sArticle += "ODesc=" & """" & DrBl("BLNO") & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)

            Next

        Next

        'Prossess for no balance Items 

        TbBls = New DataTable
        TbBls.Columns.Add(New DataColumn("BLNO"))
        TbBls.Columns.Add(New DataColumn("BLID"))
        TbBls.Columns.Add(New DataColumn("TTLAMT", System.Type.GetType("System.Double")))
        Temp.Clear()
        Temp.AcceptChanges()


        For Each Dr In TBResult.Select("Balance < 0")
            Drs = TbBls.Select("BLNO = '" & Dr("BLNO").ToString & "'")
            If Drs.Length = 0 Then
                nDR = TbBls.NewRow
                nDR("BLID") = Dr("BLID")
                nDR("BLNO") = Dr("BLNO")
                nDR("TTlamt") = (Dr("Balance") * -1)
                TbBls.Rows.Add(nDR)
            Else
                Drs(0).Item("TTlamt") = Drs(0).Item("TTlamt") + (Dr("Balance") * -1)
            End If
        Next

        For Each Dr In TbBls.Rows

            nDR = TBResult.NewRow
            nDR("BLID") = Dr("BLID")
            nDR("BLNO") = Dr("BLNO")
            nDR("Amount") = Math.Round(Dr("TTLAmt") * 5 / 100)
            nDR("Balance") = Math.Round(Dr("TTLAmt") * 5 / 100)
            nDR("ChargesCode") = "TAX"
            TBResult.Rows.Add(nDR)
        Next

        'TBResult.WriteXml("c:\tmp\L.xml")

        'TbBls.TableName = "XX"
        'TbBls.WriteXml("c:\tmp\L2.xml")

        For Each DrBl In TbBls.Rows

            Temp.Clear()
            Temp.AcceptChanges()

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, DrBl("BLNO"), MatchType.Exact)
            Bldata = DM.GetTB_InwardBLS
            DrBl("BLNO") = Bldata.BlNo

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bldata.ClientID, MatchType.Exact)
            Client = DM.GetTB_Clients

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Bldata.VoyageID, MatchType.Exact)
            Voy = DM.GetTB_Voyage

            Temp.Clear()
            Temp.AcceptChanges()
            For Each Dr In TBResult.Select("BLNO = '" & DrBl("BLNO") & "'")

                Titles = Title.Select("ChargesCode = '" & Dr("ChargesCode") & "'")
                If Titles.Length = 0 Then
                    MsgBox("No Charge Define [" & Dr("ChargesCode") & "]")
                    Exit Sub
                Else
                    '  TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                    TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= dFrom and '" & sDate & "' <= dTo")

                    If TitleSubs.Length = 0 Then
                        nDR = Temp.NewRow
                        nDR("LevelAcc") = Titles(0).Item("CRAccount")
                        nDR("Level1") = GetLevel(Titles(0).Item("CRLevel1").ToString, DrBl, Voy, Client)
                        nDR("Level2") = GetLevel(Titles(0).Item("CRLevel2").ToString, DrBl, Voy, Client)
                        nDR("Level3") = GetLevel(Titles(0).Item("CRLevel3").ToString, DrBl, Voy, Client)
                        nDR("Level4") = GetLevel(Titles(0).Item("CRLevel4").ToString, DrBl, Voy, Client)
                        nDR("Level5") = GetLevel(Titles(0).Item("CRLevel5").ToString, DrBl, Voy, Client)
                        nDR("Amount") = Dr("Balance") * -1
                        nDR("Desc") = Titles(0).Item("Description") & " بابت برگشت بارنامه " & DrBl("BLNO")
                        Temp.Rows.Add(nDR)
                    Else
                        For Each Tdr In TitleSubs
                            nDR = Temp.NewRow
                            nDR("LevelAcc") = Tdr("CRAccount")
                            nDR("Level1") = GetLevel(Tdr("CRLevel1").ToString, DrBl, Voy, Client)
                            nDR("Level2") = GetLevel(Tdr("CRLevel2").ToString, DrBl, Voy, Client)
                            nDR("Level3") = GetLevel(Tdr("CRLevel3").ToString, DrBl, Voy, Client)
                            nDR("Level4") = GetLevel(Tdr("CRLevel4").ToString, DrBl, Voy, Client)
                            nDR("Level5") = GetLevel(Tdr("CRLevel5").ToString, DrBl, Voy, Client)
                            If NullToValue(Tdr("Amount"), 0) > 0 Then
                                nDR("Amount") = Tdr("Amount")
                            ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                nPer = (Dr("Amount"))
                                nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                nDR("Amount") = Math.Round(nPer)
                            End If
                            nDR("Desc") = Tdr("Description") & " بابت برگشت بارنامه " & DrBl("BLNO")
                            Temp.Rows.Add(nDR)
                        Next
                    End If
                End If
            Next

            For Each nDR In Temp.Rows

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDR("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDR("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDR("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDR("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDR("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "

                sArticle += "Deb=" & """"
                sArticle += (NullToValue(nDR("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & nDR("Desc") & """" & " "
                sArticle += "ODesc=" & """" & DrBl("BLNO") & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)

            Next

            Temp.Clear()
            Temp.AcceptChanges()

            For Each Dr In TBResult.Select("BLNO = '" & DrBl("BLNO") & "'")

                Titles = Title.Select("ChargesCode = '" & Dr("ChargesCode") & "'")
                If Titles.Length = 0 Then
                    MsgBox("No Charge Define [" & Dr("ChargesCode") & "]")
                    Exit Sub
                Else
                    '  TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                    TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "' and '" & sDate & "' >= dFrom and '" & sDate & "' <= dTo")

                    If TitleSubs.Length = 0 Then
                        nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DBAccount") & "' and " & _
                                           "Level1 = '" & GetLevel(Titles(0).Item("DBLevel1").ToString, DrBl, Voy, Client) & "' and " & _
                                           "Level2 = '" & GetLevel(Titles(0).Item("DBLevel2").ToString, DrBl, Voy, Client) & "' and " & _
                                           "Level3 = '" & GetLevel(Titles(0).Item("DBLevel3").ToString, DrBl, Voy, Client) & "' and " & _
                                           "Level4 = '" & GetLevel(Titles(0).Item("DBLevel4").ToString, DrBl, Voy, Client) & "' and " & _
                                           "Level5 = '" & GetLevel(Titles(0).Item("DBLevel5").ToString, DrBl, Voy, Client) & "'")
                        If nDrs.Length = 0 Then
                            nDR = Temp.NewRow
                            nDR("LevelAcc") = Titles(0).Item("DBAccount")
                            nDR("Level1") = GetLevel(Titles(0).Item("DBLevel1").ToString, DrBl, Voy, Client)
                            nDR("Level2") = GetLevel(Titles(0).Item("DBLevel2").ToString, DrBl, Voy, Client)
                            nDR("Level3") = GetLevel(Titles(0).Item("DBLevel3").ToString, DrBl, Voy, Client)
                            nDR("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, DrBl, Voy, Client)
                            nDR("Level5") = GetLevel(Titles(0).Item("DBLevel5").ToString, DrBl, Voy, Client)
                            nDR("Amount") = Dr("Balance") * -1
                            Temp.Rows.Add(nDR)
                        Else
                            nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + (Dr("Balance") * -1)
                        End If
                    Else
                        For Each Tdr In TitleSubs
                            nDrs = Temp.Select("LevelAcc = '" & Tdr("DBAccount") & "' and " & _
                                                                     "Level1 = '" & GetLevel(Tdr("DBLevel1").ToString, DrBl, Voy, Client) & "' and " & _
                                                                     "Level2 = '" & GetLevel(Tdr("DBLevel2").ToString, DrBl, Voy, Client) & "' and " & _
                                                                     "Level3 = '" & GetLevel(Tdr("DBLevel3").ToString, DrBl, Voy, Client) & "' and " & _
                                                                     "Level4 = '" & GetLevel(Tdr("DBLevel4").ToString, DrBl, Voy, Client) & "' and " & _
                                                                     "Level5 = '" & GetLevel(Tdr("DBLevel5").ToString, DrBl, Voy, Client) & "'")
                            If nDrs.Length = 0 Then
                                nDR = Temp.NewRow
                                nDR("LevelAcc") = Titles(0).Item("DBAccount")
                                nDR("Level1") = GetLevel(Tdr("DBLevel1").ToString, DrBl, Voy, Client)
                                nDR("Level2") = GetLevel(Tdr("DBLevel2").ToString, DrBl, Voy, Client)
                                nDR("Level3") = GetLevel(Tdr("DBLevel3").ToString, DrBl, Voy, Client)
                                nDR("Level4") = GetLevel(Tdr("DBLevel4").ToString, DrBl, Voy, Client)
                                nDR("Level5") = GetLevel(Tdr("DBLevel5").ToString, DrBl, Voy, Client)
                                If NullToValue(Tdr("Amount"), 0) > 0 Then
                                    nDR("Amount") = Tdr("Amount")
                                ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                    nPer = Tdr("Amount")
                                    nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                    nDR("Amount") = Math.Round(nPer)
                                End If
                                Temp.Rows.Add(nDR)
                            Else
                                If NullToValue(Tdr("Amount"), 0) > 0 Then
                                    nDR("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
                                ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                    nPer = Dr("Amount")
                                    nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                    nDR("Amount") = nDrs(0).Item("Amount") + Math.Round(nPer)
                                End If
                            End If
                        Next
                    End If
                End If
            Next


            For Each nDR In Temp.Rows

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDR("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDR("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDR("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDR("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDR("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "


                sArticle += "Cre=" & """"
                sArticle += (NullToValue(nDR("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & "بابت مابه التفاوت بارنامه " & DrBl("BLNO") & """" & " "
                sArticle += "ODesc=" & """" & DrBl("BLNO") & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)
            Next

        Next



        Temp.Clear()
        Temp.AcceptChanges()

        Temp.Clear()
        Temp.AcceptChanges()
        SB.AppendLine("</_XPXML>")
        Result = SB.ToString

    End Sub

    Private Sub CompareFinal(ByVal BLID As String, ByVal BLNo As String, _
              ByVal VoyageID As String, _
              ByVal InvoiceDetails As DataTable, _
              ByVal TaxPercent As Double, _
              ByRef TBResult As DataTable, _
              ByRef TBReturn As DataTable)

        Dim Tb As New DataTable
        Dim sSql As String
        Dim lResult As Boolean
        Dim InvDr As DataRow
        Dim InvDrs() As DataRow
        Dim ArrRow As DataRow
        Dim ArrRows() As DataRow
        Dim CompDr As DataRow
        Dim TTLMan As Double
        Dim Dr As DataRow
        Dim TaxAmount As Double
        Dim Drs() As DataRow
        Dim TBInv As New DataTable
        Dim InvID As String
        Dim InvoiceNo As String

        Dim ColName As String
        Dim nDr As DataRow

        For Each Dr In InvoiceDetails.Select("BLID = '" & BLID & "'")
            InvID = Dr("InvID").ToString
            InvoiceNo = Dr("InvoiceNo")
            If Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL" Or Dr("ChargesCode") = "DUTY" Then
                TaxAmount += Dr("IrrAmount")
            Else
                TTLMan += Dr("IrrAmount")
            End If
            If Dr("ChargesCode") = "DOLCL" Then
                Dr("ChargesCode") = "DO"
            End If
        Next

        Drs = InvoiceDetails.Select("ChargesCode = 'DETN' or ChargesCode = 'DMCT'")
        sSql = "SP_ExtractDataFromNosa '" & VoyageID & "' , '" & BLNo & "'"
        TableBySql(sSql, Tb, lResult)

        If TTLMan = 0 Then
            TaxPercent = 5
        Else
            TaxPercent = TaxAmount * 100 / TTLMan
        End If

        For Each Dr In Tb.Rows
            If Dr("ChargeItem") = "DOLCL" Then
                Dr("ChargeItem") = "DO"
            End If
        Next

        For Each Dr In Tb.Rows
            If Dr("ChargeItem") = "TAX" Or Dr("ChargeItem") = "TOLL" Then
            Else
                If Dr("MandatoryAmount") + Dr("ConditionalAmount") > 0 Then
                    Drs = InvoiceDetails.Select("BLID = '" & BLID & "' and ChargesCode = '" & Dr("ChargeItem") & "'")
                    If Drs.Length = 0 Then
                        nDr = TBReturn.NewRow
                        nDr("BLID") = BLID
                        nDr("InvNo") = InvoiceNo
                        nDr("BLNO") = BLNo
                        nDr("ChargeItem") = Dr("ChargeItem")
                        nDr("ConditionalAmount") = Dr("ConditionalAmount")
                        nDr("MandatoryAmount") = Dr("MandatoryAmount")
                        nDr("Tax") = TaxPercent
                        TBReturn.Rows.Add(nDr)
                        nDr = TBReturn.NewRow
                        nDr("BLID") = BLID
                        nDr("InvNo") = InvoiceNo
                        nDr("BLNO") = BLNo
                        nDr("ChargeItem") = "TAX"
                        nDr("ConditionalAmount") = 0
                        nDr("MandatoryAmount") = ((Dr("MandatoryAmount") + Dr("ConditionalAmount")) * TaxPercent / 100)
                        TBReturn.Rows.Add(nDr)
                    Else
                        If Dr("MandatoryAmount") + Dr("ConditionalAmount") <> Drs(0).Item("IrrAmount") Then
                            nDr = TBResult.NewRow
                            For Each col As DataColumn In Drs(0).Table.Columns
                                nDr(col.ColumnName) = Drs(0).Item(col.ColumnName)
                            Next
                            nDr("BLNO") = BLNo
                            nDr("Balance") = Drs(0).Item("IrrAmount") - (Dr("MandatoryAmount") + Dr("ConditionalAmount"))
                            If nDr("Balance") < 0 Then
                                nDr("Amount") = nDr("Balance") * -1
                                nDr("Status") = "L"
                            Else
                                nDr("Status") = "G"
                            End If
                            TBResult.Rows.Add(nDr)
                        End If
                    End If
                End If
            End If
 
        Next

        

    End Sub

    Public Sub GenerateConfirmVocherExp(ByVal DT As Date, ByRef Result As String)

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Arvl As CLArrivalNotice
        Dim BLData As TB_OutwardBLS
        Dim SOF As TB_SOF
        Dim lResult As Boolean
        Dim DM As New DataManager(My.Settings.DSN)
        Dim Voy As TB_Voyage
        Dim TB As New DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim nDr As DataRow
        Dim Sql As String
        Dim BlRow As DataRow
        Dim TTlCR As Double
        Dim TTLDB As Double
        Dim Client As TB_Clients
        Dim BL As DataRow
        Dim Banks As TB_CODECollection
        Dim PTypes As TB_CODECollection

        Dim Bank As TB_CODE
        Dim PType As TB_CODE

        Dim ListOfInvoice As TB_ExpInvoiceCollection
        Dim Invoice As TB_ExpInvoice

        Dim InvoiceDetails As TB_ExpInvoiceDetailsCollection
        Dim InvoiceDetail As TB_ExpInvoiceDetails

        Dim RcvdItems As TB_ExpRecivedItemsCollection
        Dim Rcvd As TB_ExpRecivedItems

        Dim DepartItems As DataTable

        Dim Title As New DataTable
        Dim Titles() As DataRow

        Dim TitleSubs() As DataRow
        Dim TitleSub As DataTable
        Dim Tdr As DataRow
        Dim nPer As Double
        Dim nDrs() As DataRow

        Dim sArticle As String
        Dim SB As New StringBuilder

        Dim TTL As Double
        Dim VatPercent As Double

        Dim nTaxOver As Long
        Dim nTaxLess As Long

        Dim nChargeOver As Double
        Dim nChargeLess As Double

        Dim TbBase As New DataTable

        Dim TTLArvl As Double
        Dim TTLPaid As Double
        Dim TaxSub As DataTable
        Dim FirstPaid As Double
        Dim FirstPaidTB As New DataTable
        Dim DetnARow As DataRow

        Dim Temp As New DataTable
        Dim ExchangeBase As Double = 1226

        Dim Amount As Double
        Dim IrrAmount As Double

        Dim Dummy As TB_ExpInvoiceDetailsCollection



        With Temp
            .Columns.Add(New DataColumn("LevelAcc"))
            .Columns.Add(New DataColumn("Level1"))
            .Columns.Add(New DataColumn("Level2"))
            .Columns.Add(New DataColumn("Level3"))
            .Columns.Add(New DataColumn("Level4"))
            .Columns.Add(New DataColumn("Level5"))
            .Columns.Add(New DataColumn("Amount"))
            .Columns.Add(New DataColumn("Desc"))
            .Columns.Add(New DataColumn("InvNo"))

        End With

        TableBySql("Select * From tb_NOSAAccountExp", Title, lResult)
        TableBySql("Select * From tb_NOSAAccountsubExp", TitleSub, lResult)
        TableBySql("Select * From TB_NOSPaidTaxTitleExp", TaxSub, lResult)

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "BK", MatchType.Exact)
        Banks = DM.GetTB_CODECollection

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "RT", MatchType.Exact)
        PTypes = DM.GetTB_CODECollection

   
        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_ExpInvoice.Columns.ConfirmTime, DT, MatchType.Exact)
        ListOfInvoice = DM.GetTB_ExpInvoiceCollection

        SB.AppendLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & "?>")
        SB.AppendLine("<_XPXML>")


        ' ListOfInvoice = ListOfInvoice.FilterByInvoiceNo("T12E-01086")

        For Each Invoice In ListOfInvoice

            Temp.Clear()
            Temp.AcceptChanges()

            DM = New DataManager(My.Settings.DSN)
            DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.ID, Invoice.BLID, MatchType.Exact)

            BLData = DM.GetTB_OutwardBLS
            BL = DM.DataSet.Tables("TB_OutwardBLS").Rows(0)

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, BL("ClienTID"), MatchType.Exact)
            Client = DM.GetTB_Clients

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, BLData.VoyageID, MatchType.Exact)
            Voy = DM.GetTB_Voyage

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, BLData.VoyageID, MatchType.Exact)
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.Port, BLData.POD, MatchType.Exact)
            SOF = DM.GetTB_SOF

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_ExpInvoiceDetails.Columns.InvoiceID, Invoice.ID, MatchType.Exact)
            InvoiceDetails = DM.GetTB_ExpInvoiceDetailsCollection

            For Each InvoiceDetail In InvoiceDetails
                If InvoiceDetail.ChargesCode = "TAX" Or InvoiceDetail.ChargesCode = "TOLL" Then

                Else
                    Dr = DM.DataSet.Tables("TB_ExpInvoiceDetails").Select("ID = '" & InvoiceDetail.ID.ToString & "'")(0)

                    IrrAmount = Dr("IrrAmount") + Microsoft.VisualBasic.Fix((Dr("IrrAmount") * 6 / 100))
                    Amount = Dr("Amount") + Microsoft.VisualBasic.Fix((Dr("Amount") * 6 / 100))

                    Temp.AcceptChanges()
                    Titles = Title.Select("ChargesCode = '" & Dr("ChargesCode") & "'")

                    If Titles.Length = 0 Then
                        MsgBox("No Charge Define [" & Dr("ChargesCode") & "]")
                        Exit Sub
                    Else

                        TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                        'If TitleSubs.Length = 0 Then
                        '    TitleSubs = TaxSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                        'End If
                        If TitleSubs.Length = 0 Then
                            nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DBAccount") & "' and " & _
                                               "Level1 = '" & GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                               "Level2 = '" & GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                               "Level3 = '" & GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                               "Level4 = '" & GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                               "Level5 = '" & GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client) & "'")
                            If nDrs.Length = 0 Then
                                nDr = Temp.NewRow
                                nDr("LevelAcc") = Titles(0).Item("DBAccount")
                                nDr("Level1") = GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client)
                                nDr("Level2") = GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client)
                                nDr("Level3") = GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client)
                                nDr("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client)
                                nDr("Level5") = GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client)
                                nDr("Amount") = IIf(IrrAmount > 0, IrrAmount, Amount * ExchangeBase)

                                Temp.Rows.Add(nDr)
                            Else
                                nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + IIf(IrrAmount > 0, IrrAmount, Amount * ExchangeBase)
                            End If
                        Else
                            For Each Tdr In TitleSubs
                                nDrs = Temp.Select("LevelAcc = '" & Tdr("DBAccount") & "' and " & _
                                                                         "Level1 = '" & GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level2 = '" & GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level3 = '" & GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level4 = '" & GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
                                                                         "Level5 = '" & GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client) & "'")
                                If nDrs.Length = 0 Then
                                    nDr = Temp.NewRow
                                    nDr("LevelAcc") = Titles(0).Item("DBAccount")
                                    nDr("Level1") = GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client)
                                    nDr("Level2") = GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client)
                                    nDr("Level3") = GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client)
                                    nDr("Level4") = GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client)
                                    nDr("Level5") = GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client)
                                    If NullToValue(Tdr("Amount"), 0) > 0 Then
                                        nDr("Amount") = Tdr("Amount") + Microsoft.VisualBasic.Fix((Tdr("Amount") * 6 / 100))
                                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                        nPer = IIf(IrrAmount > 0, IrrAmount, Amount * ExchangeBase)
                                        nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                        nDr("Amount") = nPer
                                    End If

                                    Temp.Rows.Add(nDr)
                                Else
                                    If NullToValue(Tdr("Amount"), 0) > 0 Then
                                        nDr("Amount") = nDrs(0).Item("Amount") + Tdr("Amount") + Microsoft.VisualBasic.Fix((Tdr("Amount") * 6 / 100))
                                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                        nPer = (IIf(IrrAmount > 0, IrrAmount, Amount * ExchangeBase))
                                        nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                        nDr("Amount") = nDrs(0).Item("Amount") + nPer
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

            Next



            For Each nDr In Temp.Rows
                If nDr("Amount") > 0 Then

                    sArticle = "<_FTrans Acc=" & """"
                    sArticle += nDr("LevelAcc") & """" & " "

                    sArticle += "Det1=" & """"
                    sArticle += nDr("Level1").ToString & """" & " "

                    sArticle += "Det2=" & """"
                    sArticle += nDr("Level2").ToString & """" & " "

                    sArticle += "Det3=" & """"
                    sArticle += nDr("Level3").ToString & """" & " "

                    sArticle += "Det4=" & """"
                    sArticle += nDr("Level4").ToString & """" & " "

                    sArticle += "Det5=" & """" & """" & " "


                    sArticle += "Deb=" & """"
                    sArticle += (NullToValue(nDr("Amount"), 0) / 100).ToString & """" & " "

                    sArticle += "Desc=" & """" & "بابت بارنامه " & BL("BLNO") & " صورتحساب " & Invoice.InvoiceNo & """" & " "

                    sArticle += "ODesc=" & """" & BLData.BlNo & """" & " "

                    sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                    SB.AppendLine.AppendLine(sArticle)
                End If
            Next


            Temp.Clear()
            Temp.AcceptChanges()

            Amount = 0
            IrrAmount = 0
            For Each InvoiceDetail In InvoiceDetails
                If Not (InvoiceDetail.ChargesCode = "TAX" Or InvoiceDetail.ChargesCode = "TOLL") Then
                    Amount += InvoiceDetail.Amount
                    IrrAmount += InvoiceDetail.IRRAmount
                End If
            Next

            If InvoiceDetails.FilterByChargesCode("TAX").Count > 0 Then
                InvoiceDetails.FilterByChargesCode("TAX")(0).Amount = IrrAmount * 6 / 100
                Drs = DM.DataSet.Tables("TB_ExpInvoiceDetails").Select("ChargesCode = 'TAX'")
                Drs(0).Item("IrrAmount") = IrrAmount * 6 / 100
                Drs(0).Item("Amount") = Amount * 6 / 100
            End If


            For Each InvoiceDetail In InvoiceDetails

                Dr = DM.DataSet.Tables("TB_ExpInvoiceDetails").Select("ID = '" & InvoiceDetail.ID.ToString & "'")(0)

                Titles = Title.Select("ChargesCode = '" & Dr("Chargescode") & "'")
                If Titles.Length = 0 Then
                    MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                    Exit Sub
                Else
                    TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                    If TitleSubs.Length = 0 Then
                        nDr = Temp.NewRow
                        nDr("LevelAcc") = Titles(0).Item("CRAccount")
                        nDr("Level1") = GetLevel(Titles(0).Item("CRLevel1").ToString, BL, Voy, Client)
                        nDr("Level2") = GetLevel(Titles(0).Item("CRLevel2").ToString, BL, Voy, Client)
                        nDr("Level3") = GetLevel(Titles(0).Item("CRLevel3").ToString, BL, Voy, Client)
                        nDr("Level4") = GetLevel(Titles(0).Item("CRLevel4").ToString, BL, Voy, Client)
                        nDr("Level5") = GetLevel(Titles(0).Item("CRLevel5").ToString, BL, Voy, Client)
                        nDr("Amount") = IIf(Dr("IrrAmount") > 0, Dr("IrrAmount"), Dr("Amount") * ExchangeBase)
                        If Dr("IrrAmount") > 0 Then
                            nDr("Desc") = Titles(0).Item("Description") & " بابت بارنامه " & BL("BLNO")
                        Else
                            nDr("Desc") = Titles(0).Item("Description") & " بابت بارنامه " & BL("BLNO") & " به مبلغ " & Format(Dr("Amount"), "Standard")
                        End If
                        Temp.Rows.Add(nDr)
                    Else
                        For Each Tdr In TitleSubs
                            nDr = Temp.NewRow
                            nDr("LevelAcc") = Tdr("CRAccount")
                            nDr("Level1") = GetLevel(Tdr("CRLevel1").ToString, BL, Voy, Client)
                            nDr("Level2") = GetLevel(Tdr("CRLevel2").ToString, BL, Voy, Client)
                            nDr("Level3") = GetLevel(Tdr("CRLevel3").ToString, BL, Voy, Client)
                            nDr("Level4") = GetLevel(Tdr("CRLevel4").ToString, BL, Voy, Client)
                            nDr("Level5") = GetLevel(Tdr("CRLevel5").ToString, BL, Voy, Client)
                            If NullToValue(Tdr("Amount"), 0) > 0 Then
                                nDr("Amount") = Tdr("Amount")
                            ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                nPer = IIf(Dr("IrrAmount") > 0, Dr("IrrAmount"), Dr("Amount") * ExchangeBase)
                                nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                nDr("Amount") = nPer
                            End If
                            If Dr("IrrAmount") > 0 Then
                                nDr("Desc") = Tdr("Description") & " بابت بارنامه " & BL("BLNO") & " صورتحساب " & Invoice.InvoiceNo
                            Else
                                nDr("Desc") = Tdr("Description") & " بابت بارنامه " & BL("BLNO") & " به مبلغ " & Format(Dr("Amount"), "Standard") & " صورتحساب " & Invoice.InvoiceNo
                            End If
                            Temp.Rows.Add(nDr)
                        Next
                    End If
                End If
            Next

            For Each nDr In Temp.Rows

                sArticle = "<_FTrans Acc=" & """"
                sArticle += nDr("LevelAcc") & """" & " "

                sArticle += "Det1=" & """"
                sArticle += nDr("Level1").ToString & """" & " "

                sArticle += "Det2=" & """"
                sArticle += nDr("Level2").ToString & """" & " "

                sArticle += "Det3=" & """"
                sArticle += nDr("Level3").ToString & """" & " "

                sArticle += "Det4=" & """"
                sArticle += nDr("Level4").ToString & """" & " "

                sArticle += "Det5=" & """" & """" & " "

                sArticle += "Cre=" & """"
                sArticle += (NullToValue(nDr("Amount"), 0) / 100).ToString & """" & " "

                sArticle += "Desc=" & """" & nDr("Desc") & """" & " "
                sArticle += "ODesc=" & """" & BL("BLNO") & """" & " "

                sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

                SB.AppendLine.AppendLine(sArticle)

            Next

        Next



        SB.AppendLine("</_XPXML>")
        Result = SB.ToString

        MsgBox("Generate Successful")


        'If TTLArvl > 0 Then
        '    Dr = TBNoInArrival.NewRow
        '    Dr("ChargeItem") = "TAX"
        '    Dr("InvoiceAmount") = Microsoft.VisualBasic.Fix((TTLArvl * 5 / 100))
        '    TBNoInArrival.Rows.Add(Dr)
        'End If

        'For Each Dr In TBNoInArrival.Rows
        '    Temp.AcceptChanges()
        '    Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
        '    If Titles.Length = 0 Then
        '        MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
        '        Exit Sub
        '    Else
        '        TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
        '        If TitleSubs.Length = 0 Then
        '            nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DBAccount") & "' and " & _
        '                               "Level1 = '" & GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
        '                               "Level2 = '" & GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
        '                               "Level3 = '" & GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
        '                               "Level4 = '" & GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
        '                               "Level5 = '" & GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client) & "'")
        '            If nDrs.Length = 0 Then
        '                nDr = Temp.NewRow
        '                nDr("LevelAcc") = Titles(0).Item("DBAccount")
        '                nDr("Level1") = GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client)
        '                nDr("Level2") = GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client)
        '                nDr("Level3") = GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client)
        '                nDr("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client)
        '                nDr("Level5") = GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client)
        '                If FirstPaid > 0 And Dr("ChargeItem") = "DETN" Then
        '                    nDr("Amount") = Dr("InvoiceAmount") - FirstPaid
        '                Else
        '                    nDr("Amount") = Dr("InvoiceAmount")
        '                End If
        '                nDr("InvNo") = Invoice.InvoiceNo
        '                If Titles(0).Item("AccType") = "A" Then
        '                    nDr("Desc") = "بابت هزینه صدور بارنامه " & BLData.BlNo & " صورتحساب " & nDr("InvNo")
        '                Else
        '                    nDr("Desc") = " بابت " & Titles(0).Item("Description") & " بارنامه " & BLData.BlNo & " صورتحساب " & Invoice.InvoiceNo
        '                End If
        '                Temp.Rows.Add(nDr)
        '            Else
        '                If FirstPaid > 0 And Dr("ChargeItem") = "DETN" Then
        '                    nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + Dr("InvoiceAmount") - FirstPaid
        '                Else
        '                    nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + Dr("InvoiceAmount")
        '                End If

        '            End If
        '        Else
        '            For Each Tdr In TitleSubs
        '                nDrs = Temp.Select("LevelAcc = '" & Tdr("DBAccount") & "' and " & _
        '                                                         "Level1 = '" & GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
        '                                                         "Level2 = '" & GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
        '                                                         "Level3 = '" & GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
        '                                                         "Level4 = '" & GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
        '                                                         "Level5 = '" & GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client) & "'")
        '                If nDrs.Length = 0 Then
        '                    nDr = Temp.NewRow
        '                    nDr("LevelAcc") = Titles(0).Item("DBAccount")
        '                    nDr("Level1") = GetLevel(Tdr("DBLevel1").ToString, BL, Voy, Client)
        '                    nDr("Level2") = GetLevel(Tdr("DBLevel2").ToString, BL, Voy, Client)
        '                    nDr("Level3") = GetLevel(Tdr("DBLevel3").ToString, BL, Voy, Client)
        '                    nDr("Level4") = GetLevel(Tdr("DBLevel4").ToString, BL, Voy, Client)
        '                    nDr("Level5") = GetLevel(Tdr("DBLevel5").ToString, BL, Voy, Client)
        '                    If NullToValue(Tdr("Amount"), 0) > 0 Then
        '                        nDr("Amount") = Tdr("Amount")
        '                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
        '                        nPer = Dr("InvoiceAmount")
        '                        nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
        '                        nDr("Amount") = nPer
        '                    End If
        '                    nDr("InvNo") = Invoice.InvoiceNo
        '                    If Titles(0).Item("AccType") = "A" Then
        '                        nDr("Desc") = "بابت هزینه صدور بارنامه " & BLData.BlNo & " صورتحساب " & nDr("InvNo")
        '                    Else
        '                        nDr("Desc") = " بابت " & Titles(0).Item("Description") & " بارنامه " & BLData.BlNo & " صورتحساب " & Invoice.InvoiceNo
        '                    End If

        '                    Temp.Rows.Add(nDr)
        '                Else
        '                    If NullToValue(Tdr("Amount"), 0) > 0 Then
        '                        nDr("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
        '                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
        '                        nPer = Dr("InvoiceAmount")
        '                        nPer = Math.Round((nPer * Tdr("Percentage")) / TotalPer(TitleSubs))
        '                        nDr("Amount") = nDrs(0).Item("Amount") + nPer
        '                    End If
        '                End If
        '            Next
        '        End If
        '    End If
        'Next

  

    End Sub


    Public ReadOnly Property TBFinalShow() As DataTable
        Get
            Return TBFinal
        End Get
    End Property


    Public Sub GenNosaDetentinDebit(ByRef sResult As String, ByVal DateF As Date)

        Dim Temp As New DataTable
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim sArticle As String
        Dim SB As New StringBuilder

        With Cmd
            Cnn.Open()
            .Connection = Cnn
            .CommandText = "SP_NosaDetentionDebit"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Date", DateF)
        End With
        Cmd.ExecuteNonQuery()

        DA.SelectCommand = Cmd
        DA.Fill(Temp)


        SB.AppendLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & "?>")
        SB.AppendLine("<_XPXML>")


        For Each nDr In Temp.Rows

            sArticle = "<_FTrans Acc=" & """"
            sArticle += nDr("LevelAcc") & """" & " "

            sArticle += "Det1=" & """"
            sArticle += nDr("Level1").ToString & """" & " "

            sArticle += "Det2=" & """"
            sArticle += nDr("Level2").ToString & """" & " "

            sArticle += "Det3=" & """"
            sArticle += nDr("Level3").ToString & """" & " "

            sArticle += "Det4=" & """"
            sArticle += nDr("Level4").ToString & """" & " "

            sArticle += "Det5=" & """" & """" & " "

            If nDr("Deb") > 0 Then
                sArticle += "Deb=" & """"
                sArticle += (NullToValue(nDr("Deb"), 0) / 100).ToString & """" & " "
            Else
                sArticle += "Cre=" & """"
                sArticle += (NullToValue(nDr("Cre"), 0) / 100).ToString & """" & " "
            End If

            sArticle += "Desc=" & """" & nDr("Desc") & """" & " "
            sArticle += "ODesc=" & """" & nDr("Level5") & """" & " "
            sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

            SB.AppendLine.AppendLine(sArticle)
        Next
        SB.AppendLine("</_XPXML>")
        sResult = SB.ToString

    End Sub





End Class
