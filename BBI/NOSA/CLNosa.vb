Imports OrmLib
Imports ShippingBiz
Imports System.Data
Imports System.Data.SqlClient
Imports System.String
Imports System.IO
Imports System.Text

Public Class CLNosa

    Private TbSame As New DataTable
    Private TbNoSame As New DataTable
    Private TbNoInInvoice As New DataTable
    Private TbNoInArrival As New DataTable
    Private TbError As DataTable
    Private lError As Boolean = False
    Private TitleSub As DataTable


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
        Dim Exchange As TB_Exchange
        Dim ExchanefDetail As TB_ExchangeDetailsCollection


        Dim Title As New DataTable
        Dim Titles() As DataRow

        Dim TitleSubs() As DataRow
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

        Dim IsChaild As Boolean = False

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

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Exchange.Columns.ExchangeDate, CDate(SOF.Arrival).Date, MatchType.Exact)
        Exchange = DM.GetTB_Exchange

        If Exchange Is Nothing Then
            MsgBox("No Exchange Rate For " & CDate(SOF.Arrival).Date.ToString)
            Exit Sub
        End If

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_ExchangeDetails.Columns.MasterID, Exchange.ID, MatchType.Exact)        ' "3E0FFB83-10FF-4314-AE32-A5F87895546C"
        ExchanefDetail = DM.GetTB_ExchangeDetailsCollection


        TableBySql("Select * From tb_NOSAAccount", Title, lResult)
        TableBySql("Select * From tb_NOSAAccountsub", TitleSub, lResult)

        Dim SB As New StringBuilder

        SB.AppendLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & "?>")
        SB.AppendLine("<_XPXML>")

        For Each BL In BLS.Rows ' .Select("BLNO = '1424a05759'")

            'If BL("BLNO") = "0083a07233" Then
            '    Beep()
            'End If

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

            For Each Dr In Arvl.GetTBDetails.Rows

                If Dr("CurCode") <> "IRR" And InStr(1, "THC,LCLDC,STR,LCL/DC", Dr("ChargeItem")) = 0 Then

                    If Dr("ConditionalAmount") > 0 Then
                        Dr("ConditionalAmount") = Dr("ConditionalAmount") * ExchanefDetail(0).FRTRate.Value
                    End If

                    If Dr("MandatoryAmount") > 0 Then
                        Dr("MandatoryAmount") = Dr("MandatoryAmount") * ExchanefDetail(0).FRTRate.Value
                    End If

                End If


            Next



            'Arvl.GetTBDetails.TableName = "t"
            'Arvl.GetTBDetails.WriteXml("c:\tmp\Items.xml")



            For Each Dr In Arvl.GetTBDetails.Rows '1 

                If Dr("ConditionalAmount") + Dr("MandatoryAmount") > 0 Then 'AA

                    Temp.AcceptChanges()
                    Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                    If Titles.Length = 0 Then
                        MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                        Exit Sub
                    Else

                        TitleSubs = GetTitleSubs(Titles(0).Item("ID")) ' TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                        If TitleSubs.Length = 0 Then 'BB
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
                        Else 'CC
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
                        End If 'CC

                    End If 'BB
                End If 'AA
            Next '1

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
                        TitleSubs = GetTitleSubs(Titles(0).Item("ID")) ' TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
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

    Public Sub GenerateDepature(ByVal VoyageID As String, ByRef Result As String)

        ' Dim Dpt As CLDeparturCost
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Arvl As CLDeparturCost
        Dim BLS As DataTable
        Dim BL As DataRow
        Dim SOF As TB_SOF
        Dim lResult As Boolean
        Dim DM As New DataManager(My.Settings.DSN)
        Dim Voy As TB_Voyage
        Dim TB As New DataTable
        Dim Dr As DataRow
        Dim Exchange As TB_Exchange
        Dim ExchanefDetail As TB_ExchangeDetailsCollection
        Dim Title As New DataTable
        Dim Titles() As DataRow
        Dim TitleSubs() As DataRow
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
        Dim InvCharges As New DataTable

        Dim IsChaild As Boolean = False

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

        TableBySql("Select * From tb_OutwardBls Where VoyageID = '" & VoyageID & "'", BLS, lResult)

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
        If IsNullOrEmpty(SOF.Sailed) Then
            MsgBox("Voyage is not Sailed !")
            Exit Sub
        End If


        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Exchange.Columns.ExchangeDate, CDate(SOF.Arrival).Date, MatchType.Exact)
        Exchange = DM.GetTB_Exchange

        'If Exchange Is Nothing Then
        '    MsgBox("No Exchange Rate For " & CDate(SOF.Arrival).Date.ToString)
        '    Exit Sub
        'End If

        'DM.QueryCriteria.Clear()
        'DM.QueryCriteria.And(JoinPath.TB_ExchangeDetails.Columns.MasterID, Exchange.ID, MatchType.Exact)        ' "3E0FFB83-10FF-4314-AE32-A5F87895546C"
        'ExchanefDetail = DM.GetTB_ExchangeDetailsCollection


        TableBySql("Select * From tb_NOSAAccountExp", Title, lResult)
        TableBySql("Select * From tb_NOSAAccountsubExp", TitleSub, lResult)

        Dim SB As New StringBuilder

        SB.AppendLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & "?>")
        SB.AppendLine("<_XPXML>")

        For Each BL In BLS.Rows ' .Select("BLNO = '1424a05759'")

            If BL("BLNO") = "0548511653" Then
                Beep()
            End If

            If NullToValue(BL("FrtCoverdBlNo"), "") = "" Then
                IsChaild = False
            Else
                IsChaild = True
            End If

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, BL("ClienTID"), MatchType.Exact)
            Client = DM.GetTB_Clients

            'appu - old logic
            'Arvl = New CLDeparturCost
            ''appu - voyage case
            ''Dpt.GenDeparturCost(Dm.DataSet.Tables("TB_OutWardBls").Rows(0), Now, Voy)
            'Arvl.GenDeparturCost(BL, SOF.Berthed, Voy)
            ''Err = Dpt.GetTbError
            'TB = Arvl.GetTBDetails
            'Temp.Clear()

            'Toll = 0


            'Arvl.GetTBDetails.AcceptChanges()

            'For Each Dr In Arvl.GetTBDetails.Rows
            '    If Dr("MandatoryAmount") + Dr("ConditionalAmount") + Dr("ActualAmount") = 0 Then
            '        Dr.Delete()
            '    End If
            'Next

            'Arvl.GetTBDetails.AcceptChanges()

            'For Each Dr In Arvl.GetTBDetails.Rows
            '    If Dr("Chargeitem") = "TOLL" Then
            '        Toll = Dr("ConditionalAmount") + Dr("MandatoryAmount")
            '    End If
            '    If IsChaild = True And Dr("Chargeitem") = "DO" Then
            '        Dr("Chargeitem") = "DOLCL"
            '    End If
            'Next

            'If AllArvl Is Nothing Then
            '    AllArvl = Arvl.GetTBDetails
            'Else
            '    For Each Dr In Arvl.GetTBDetails.Rows
            '        AllArvl.ImportRow(Dr)
            '    Next
            'End If

            'For Each Dr In Arvl.GetTBDetails.Rows

            '    If Dr("CurCode") <> "IRR" And InStr(1, "THC,LCLDC,STR,LCL/DC", Dr("ChargeItem")) = 0 Then

            '        If Dr("ConditionalAmount") > 0 Then
            '            Dr("ConditionalAmount") = Dr("ConditionalAmount") * ExchanefDetail(0).FRTRate.Value
            '        End If

            '        If Dr("MandatoryAmount") > 0 Then
            '            Dr("MandatoryAmount") = Dr("MandatoryAmount") * ExchanefDetail(0).FRTRate.Value
            '        End If

            '    End If


            'Next



            'Arvl.GetTBDetails.TableName = "t"
            'Arvl.GetTBDetails.WriteXml("c:\tmp\Items.xml")

            TableBySql("select i.id, (select BlNo from tb_outwardbls where id = Blid) As BlNo, InvoiceNo, Seq, Chargescode as ChargeItem, Currency, Amount, Irramount from Tb_Expinvoice i " & _
                                    "left join Tb_ExpinvoiceDetails d on i.id = d.InvoiceId where blid = (select id from tb_Outwardbls where blno = '" & BL("BLNO") & "')", InvCharges, lResult)




            For Each Dr In InvCharges.Rows '1 

                If Dr("IrrAmount") > 0 Then 'AA

                    Temp.AcceptChanges()
                    Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                    If Titles.Length = 0 Then
                        MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                        Exit Sub
                    Else

                        TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                        If TitleSubs.Length = 0 Then 'BB
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
                                nDR("Amount") = Dr("Irramount")
                                Temp.Rows.Add(nDR)
                            Else
                                nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + Dr("Irramount")
                            End If
                        Else 'CC
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
                                        nPer = (Dr("Irramount"))
                                        nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                        nDR("Amount") = nPer
                                    End If
                                    Temp.Rows.Add(nDR)
                                Else
                                    If NullToValue(Tdr("Amount"), 0) > 0 Then
                                        nDR("Amount") = nDrs(0).Item("Amount") + Tdr("Amount")
                                    ElseIf NullToValue(Tdr("Percentage"), 0) > 0 Then
                                        nPer = (Dr("Irramount"))
                                        nPer = (nPer * Tdr("Percentage")) / TotalPer(TitleSubs)
                                        nDR("Amount") = nDrs(0).Item("Amount") + nPer
                                    End If
                                End If
                            Next
                        End If 'CC

                    End If 'BB
                End If 'AA
            Next '1

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


            For Each Dr In InvCharges.Rows

                If Dr("Irramount") > 0 Then

                    Temp.AcceptChanges()
                    Titles = Title.Select("ChargesCode = '" & Dr("ChargeItem") & "'")
                    If Titles.Length = 0 Then
                        MsgBox("No Charge Define [" & Dr("ChargeItem") & "]")
                        Exit Sub
                    Else
                        TitleSubs = TitleSub.Select("PID = '" & Titles(0).Item("ID").ToString & "'")
                        If TitleSubs.Length = 0 Then
                            nDR = Temp.NewRow
                            nDR("LevelAcc") = Titles(0).Item("CRAccount")
                            nDR("Level1") = GetLevel(Titles(0).Item("CRLevel1").ToString, BL, Voy, Client)
                            nDR("Level2") = GetLevel(Titles(0).Item("CRLevel2").ToString, BL, Voy, Client)
                            nDR("Level3") = GetLevel(Titles(0).Item("CRLevel3").ToString, BL, Voy, Client)
                            nDR("Level4") = GetLevel(Titles(0).Item("CRLevel4").ToString, BL, Voy, Client)
                            nDR("Level5") = GetLevel(Titles(0).Item("CRLevel5").ToString, BL, Voy, Client)
                            nDR("Amount") = Dr("Irramount")
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
                                    nPer = (Dr("Irramount"))
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

            Temp.Clear()
            Temp.AcceptChanges()

        Next


        SB.AppendLine("</_XPXML>")
        Result = SB.ToString

        Cmd = New SqlCommand
        If Cnn.State <> ConnectionState.Open Then
            Cnn.Open()
        End If
        'AllArvl.Columns.Remove("Condition")
        'AllArvl.Columns.Remove("Meaning")
        'AllArvl.Columns.Remove("MeaningF")

        'AllArvl.TableName = "ArrivalTB"
        'AllArvl.WriteXml(SR)

        'With Cmd
        '    .Connection = Cnn
        '    .CommandText = "Update TB_Voyage Set Nosavchr = @XML where ID = @ID"
        '    .CommandType = CommandType.Text
        '    .Parameters.AddWithValue("@XML", SR.ToString)
        '    .Parameters.AddWithValue("@ID", VoyageID)
        'End With
        'Cmd.ExecuteNonQuery()

    End Sub

    Private Function GetLevel(ByVal Level As String, ByVal BL As DataRow, ByVal Voy As TB_Voyage, ByVal CL As TB_Clients) As String

        Dim Ans As String = Level

        If Level = "VOYAGE" Then
            Return Voy.VoyageAccount
        End If

        If Level = "CLIENT" Then
            Return CL.AccountA
        End If

        If Level = "BL" Then
            Return BL("BLNO")
        End If

        If Level = "LINE" Then
            If Shipping.CurrentShippingLine = "WAN" Then
                Return "2/151"           
            Else : Return "2/152"
            End If
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

    Private Function GetTitleSubs(ByVal PID As Guid) As DataRow()

        Dim TB As New DataTable
        TB = TitleSub.Copy
        TB.Clear()
        TB.AcceptChanges()
        For Each dr In TitleSub.Rows
            If dr("PID") = PID And (Now.Date >= dr("dFrom") And dr("dTo") >= Now.Date) Then
                TB.ImportRow(dr)
            End If
        Next
        Return TB.Select()


    End Function



    '  End Function

    '  Public Sub GenDailyInvoice(ByVal DT As String, ByVal FleName As String, ByRef GenResult As Boolean, ByRef Msg As String, ByVal Office As String)

    '      Dim sSql As String
    '      Dim lResult As Boolean
    '      Dim Ds As New DataSet
    '      Dim DR As DataRow
    '      Dim DrsInv() As DataRow
    '      Dim DrsPay() As DataRow
    '      Dim DrsForNotpaid() As DataRow
    '      Dim DrForNotpaid As DataRow
    '      Dim DrInv As DataRow
    '      Dim DrPay As DataRow

    '      Dim SB As New StringBuilder
    '      Dim Temp As New DataTable
    '      Dim nDr As DataRow
    '      Dim nDrs() As DataRow
    '      Dim DummyDs As New DataSet
    '      Dim sArticle As String

    '      Dim Title As New DataTable
    '      Dim Titles() As DataRow

    '      Dim TitleSubs() As DataRow
    '      Dim TitleSub As DataTable

    '      Dim Voy As New CLVoyage
    '      Dim Client As New CLClientsAccount
    '      Dim BL As New CLInwardBls

    '      Dim DepositTitle As DataTable
    '      Dim DepositTitleDr As DataRow
    '      Dim DepositTitleDrs() As DataRow
    '      Dim xDr As DataRow
    '      Dim xDrs() As DataRow
    '      Dim Drs() As DataRow
    '      Dim TBXML As New DataTable
    '      Dim TBXMLFinal As New DataTable

    '      Dim XmlRowSeq As Int32
    '      Dim Balance As Double
    '      Dim TTLRcvd As Double
    '      Dim TTLInv As Double
    '      Dim TTLNotPaid As Double

    '      Dim BABUser As String = "BAB-ACC;SALAR"
    '      Dim TEHUser As String = "MALEK;BABAK;MORVARID;TEHRANI;ARAFEE;NARGES;NOURI;ALIREZA;SARAG;SOHRAB"
    '      Dim KHOUser As String = "MATTORI"


    '      Dim TTLAmount As Double
    '      Dim TTLTax As Double
    '      Dim TaxPer As Double
    '      Dim TaxRangeTop As Double
    '      Dim TaxRangeBottom As Double
    '      Dim Tax As Double
    '      Dim Toll As Double

    '      GetTaxToll(Tax, Toll)

    '      With TbSame
    '          .Columns.Add(New DataColumn("ChargeItem"))
    '          .Columns.Add(New DataColumn("InvAmount"))
    '      End With

    '      With TbNoSame
    '          .Columns.Add(New DataColumn("ChargeItem"))
    '          .Columns.Add(New DataColumn("InvAmount"))
    '          .Columns.Add(New DataColumn("NosaAmount"))
    '      End With

    '      With TbNoInArrival
    '          .Columns.Add(New DataColumn("ChargeItem"))
    '          .Columns.Add(New DataColumn("InvAmount"))
    '      End With

    '      With TbNoInInvoice
    '          .Columns.Add(New DataColumn("ChargeItem"))
    '          .Columns.Add(New DataColumn("Amount"))
    '      End With

    '      With Temp
    '          .Columns.Add(New DataColumn("LevelAcc"))
    '          .Columns.Add(New DataColumn("Level1"))
    '          .Columns.Add(New DataColumn("Level2"))
    '          .Columns.Add(New DataColumn("Level3"))
    '          .Columns.Add(New DataColumn("Level4"))
    '          .Columns.Add(New DataColumn("Level5"))
    '          .Columns.Add(New DataColumn("Amount"))
    '          .Columns.Add(New DataColumn("Desc"))
    '          .Columns.Add(New DataColumn("InvNo"))
    '          .Columns.Add(New DataColumn("DC"))
    '          .Columns.Add(New DataColumn("Ref"))
    '          .Columns.Add(New DataColumn("BLNO"))

    '      End With

    '      With TBXML
    '          .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int32")))
    '          .Columns.Add(New DataColumn("LevelAcc"))
    '          .Columns.Add(New DataColumn("Det1"))
    '          .Columns.Add(New DataColumn("Det2"))
    '          .Columns.Add(New DataColumn("Det3"))
    '          .Columns.Add(New DataColumn("Det4"))
    '          .Columns.Add(New DataColumn("Det5"))
    '          .Columns.Add(New DataColumn("DC"))
    '          .Columns.Add(New DataColumn("Deb"))
    '          .Columns.Add(New DataColumn("Cre"))
    '          .Columns.Add(New DataColumn("Desc"))
    '          .Columns.Add(New DataColumn("ODesc"))
    '          .Columns.Add(New DataColumn("Ref"))
    '          .Columns.Add(New DataColumn("InvNo"))
    '      End With

    '      With TBXMLFinal
    '          .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int32")))
    '          .Columns.Add(New DataColumn("LevelAcc"))
    '          .Columns.Add(New DataColumn("Det1"))
    '          .Columns.Add(New DataColumn("Det2"))
    '          .Columns.Add(New DataColumn("Det3"))
    '          .Columns.Add(New DataColumn("Det4"))
    '          .Columns.Add(New DataColumn("Det5"))
    '          .Columns.Add(New DataColumn("DC"))
    '          .Columns.Add(New DataColumn("Deb"))
    '          .Columns.Add(New DataColumn("Cre"))
    '          .Columns.Add(New DataColumn("Desc"))
    '          .Columns.Add(New DataColumn("ODesc"))
    '          .Columns.Add(New DataColumn("Ref"))
    '      End With

    '      DummyDs = New DataSet
    '      FillDataInDataSetEMC("Select * From tb_NOSAAccount", DummyDs, "Title", lResult)
    '      Title = DummyDs.Tables(0)

    '      DummyDs = New DataSet
    '      FillDataInDataSetEMC("Select * From tb_NOSAAccountsub", DummyDs, "TitleSub", lResult)
    '      TitleSub = DummyDs.Tables(0)


    '      DummyDs = New DataSet
    '      FillDataInDataSetEMC("Select * From  TB_NOSARecivedItems", DummyDs, "Items", lResult)
    '      DepositTitle = DummyDs.Tables(0)

    '      sSql = "SP_NosaDaily '" & DT & "'"
    '      FillDataInDataSetEMC(sSql, Ds, "Daily", lResult)


    '      'Remove below line for generate export invoices 

    '      For Each DR In Ds.Tables(2).Rows
    '          If Mid(DR("InvNo"), 4, 1) = "E" Then
    '              DR.Delete()
    '          End If
    '      Next

    '      Ds.Tables(2).AcceptChanges()


    '      ' Find Tax Percent 


    '      Ds.Tables(2).Columns.Add(New DataColumn("Per", System.Type.GetType("System.Double")))
    '      For Each DR In Ds.Tables(2).Rows
    '          TTLAmount = 0
    '          TTLTax = 0
    '          Drs = Ds.Tables(0).Select("InvNo = '" & DR("InvNo") & "' and BlNo = '" & DR("BLNO") & "'")

    '          For Each xDr In Drs
    '              If xDr("ChargeCode") = "TAX" Or xDr("ChargeCode") = "TOLL" Then
    '                  TTLTax += xDr("Amount")
    '              Else
    '                  If xDr("ChargeCode") = "DETN-A" Or xDr("ChargeCode") = "D.D" Or xDr("ChargeCode") = "C.V.D" Then
    '                  Else
    '                      TTLAmount += xDr("Amount")
    '                  End If
    '              End If
    '          Next

    '          DR("Per") = 0

    '          If TTLAmount > 0 Then

    '              TaxPer = ((TTLAmount * 4) / 100)
    '              TaxRangeTop = TaxPer + 5
    '              TaxRangeBottom = TaxPer - 5

    '              If TaxPer = TTLTax Or (TTLTax <= TaxRangeTop And TTLTax >= TaxRangeBottom) Then
    '                  DR("Per") = 4
    '              End If

    '              TaxPer = ((TTLAmount * (Tax + Toll)) / 100)
    '              TaxRangeTop = TaxPer + 5
    '              TaxRangeBottom = TaxPer - 5
    '              If ((TTLAmount * 5) / 100) = TTLTax Or (TTLTax <= TaxRangeTop And TTLTax >= TaxRangeBottom) Then
    '                  DR("Per") = 5
    '              End If

    '              TaxPer = ((TTLAmount * (Tax + Toll)) / 100)
    '              TaxRangeTop = TaxPer + 6
    '              TaxRangeBottom = TaxPer - 6

    '              If ((TTLAmount * 6) / 100) = TTLTax Or (TTLTax <= TaxRangeTop And TTLTax >= TaxRangeBottom) Then
    '                  DR("Per") = 6
    '              End If

    '              If DR("Per") = 0 Then
    '                  MsgBox("No Tax Percent For B/L " & DR("BLNO") & " Invoice No " & DR("InvNo"))
    '              End If

    '          End If

    '          If TTLAmount = 0 Then
    '              DR("Per") = 5
    '          End If

    '      Next

    '      Ds.Tables(2).AcceptChanges()


    '      Ds.AcceptChanges()

    '      For Each DR In Ds.Tables(0).Rows
    '          If InStr(BABUser, DR("ConfirmBy")) > 0 And Office <> "B" Then
    '              DR.Delete()
    '          End If
    '          If DR.RowState = DataRowState.Unchanged Then
    '              If InStr(TEHUser, DR("ConfirmBy")) > 0 And Office <> "T" Then
    '                  DR.Delete()
    '              End If
    '          End If
    '          If DR.RowState = DataRowState.Unchanged Then
    '              If InStr(KHOUser, DR("ConfirmBy")) > 0 And Office <> "K" Then
    '                  DR.Delete()
    '              End If
    '          End If
    '      Next

    '      Ds.AcceptChanges()
    '      Ds.Tables(1).AcceptChanges()

    '      For Each DR In Ds.Tables(1).Rows
    '          If InStr(BABUser, DR("ConfirmBy")) > 0 And Office <> "B" Then
    '              DR.Delete()
    '          End If
    '          If DR.RowState = DataRowState.Unchanged Then
    '              If InStr(TEHUser, DR("ConfirmBy")) > 0 And Office <> "T" Then
    '                  DR.Delete()
    '              End If
    '          End If
    '          If DR.RowState = DataRowState.Unchanged Then
    '              If InStr(KHOUser, DR("ConfirmBy")) > 0 And Office <> "K" Then
    '                  DR.Delete()
    '              End If
    '          End If
    '      Next


    '      Ds.AcceptChanges()

    '      For Each DR In Ds.Tables(2).Rows
    '          If InStr(BABUser, DR("ConfirmBy")) > 0 And Office <> "B" Then
    '              DR.Delete()
    '          End If
    '          If DR.RowState = DataRowState.Unchanged Then
    '              If InStr(TEHUser, DR("ConfirmBy")) > 0 And Office <> "T" Then
    '                  DR.Delete()
    '              End If
    '          End If
    '          If DR.RowState = DataRowState.Unchanged Then
    '              If InStr(KHOUser, DR("ConfirmBy")) > 0 And Office <> "K" Then
    '                  DR.Delete()
    '              End If
    '          End If
    '      Next

    '      Ds.AcceptChanges()

    '      If Ds.Tables(2).Rows.Count = 0 Then
    '          MsgBox("No Any Data !")
    '          Exit Sub
    '      End If


    '      If DT < "20120830" Then
    '          If Mid(Office, 1) = "B" Then
    '              Drs = Ds.Tables(1).Select("ChargeCode = 'D.D' and PaymentType = 'D'")
    '              For Each DR In Drs
    '                  nDr = Ds.Tables(0).NewRow
    '                  nDr("IE") = "I"
    '                  nDr("InvNo") = DR("InvNo")
    '                  nDr("BLNO") = DR("BLNO")
    '                  nDr("ChargeCode") = "D.D"
    '                  nDr("CurCode") = "IRR"
    '                  nDr("Amount") = DR("IrrAmount")
    '                  nDr("ConfirmBy") = DR("ConfirmBy")
    '                  Ds.Tables(0).Rows.Add(nDr)
    '              Next
    '          End If
    '      End If


    '      SB.AppendLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & "?>")
    '      SB.AppendLine("<_XPXML>")


    '      For Each DR In Ds.Tables(2).Rows

    '          TTLRcvd = 0
    '          TTLInv = 0
    '          Balance = 0

    '          BL = New CLInwardBls
    '          Voy = New CLVoyage
    '          Client = New CLClientsAccount
    '          DrsInv = Ds.Tables(0).Select("InvNo = '" & DR("InvNo") & "' and BlNo = '" & DR("BLNo") & "'")
    '          DrsPay = Ds.Tables(1).Select("InvNo = '" & DR("InvNo") & "' and BlNo = '" & DR("BLNo") & "' and chargeCode = ''")
    '          BL.GetByCarrBlNo("V", DR("BLNO"), lResult)

    '          Voy.GetByVoyageID(BL.FdrVsl, lResult)
    '          Client.GetByClientID(BL.ClientID, lResult)

    '          Temp.Clear()
    '          Temp.AcceptChanges()

    '          For Each nDr In DrsInv
    '              If nDr("ChargeCode") = "D.D" Or nDr("ChargeCode") = "C.V.D" Then
    '              Else
    '                  TTLInv += nDr("Amount")
    '              End If
    '          Next

    '          For Each nDr In DrsPay
    '              TTLRcvd += nDr("IrrAmount")
    '          Next

    '          Balance = TTLInv - TTLRcvd



    '          If Balance <> 0 Then
    '              If Balance > 0 Then

    '              Else

    '              End If
    '          End If

    '          If DrsPay.Length > 0 Then
    '              CompareByArrival(IIf(BL.FdrVsl = "", BL.OcnVsl, BL.FdrVsl), BL.BlNo, DrsInv)


    '              For Each DrPay In DrsPay

    '                  nDr = Temp.NewRow
    '                  nDr("LevelAcc") = GetLevel(NZ(DrPay("DBAccount"), ""), BL, Voy, Client)
    '                  nDr("Level1") = GetLevel(NZ(DrPay("DBLevel1"), ""), BL, Voy, Client)
    '                  nDr("Level2") = GetLevel(NZ(DrPay("DBLevel2"), ""), BL, Voy, Client)
    '                  nDr("Level3") = GetLevel(NZ(DrPay("DBLevel3"), ""), BL, Voy, Client)
    '                  nDr("Amount") = Math.Round(DrPay("IrrAmount"))
    '                  nDr("Desc") = "دریافت بابت صورتحساب " & DrPay("InvNO") & " - شماره فیش " & DrPay("PaidRef")
    '                  nDr("Ref") = DrPay("PaidRef")
    '                  nDr("InvNo") = DR("InvNo")
    '                  nDr("DC") = "1D"
    '                  nDr("BLNO") = DrPay("BLNO")
    '                  Temp.Rows.Add(nDr)
    '              Next


    '              If Balance > 0 Then
    '                  xDrs = Title.Select("ChargesCode = 'LP'")
    '                  nDr = Temp.NewRow
    '                  nDr("LevelAcc") = xDrs(0).Item("DBAccount")
    '                  nDr("Level1") = GetLevel(xDrs(0).Item("DBLevel1"), BL, Voy, Client)
    '                  nDr("Level2") = GetLevel(xDrs(0).Item("DBLevel2"), BL, Voy, Client)
    '                  nDr("Level3") = GetLevel(xDrs(0).Item("DBLevel3"), BL, Voy, Client)
    '                  nDr("Amount") = Balance
    '                  nDr("Desc") = "کسر پرداخت " & DR("InvNo") & "بارنامه" & DrsInv(0).Item("BLNO")
    '                  nDr("InvNo") = DR("InvNo")
    '                  nDr("DC") = "1D"
    '                  nDr("BLNO") = DR("BLNO")
    '                  Temp.Rows.Add(nDr)
    '              End If

    '          End If
    '          AddToTemp(Temp, TBXML, XmlRowSeq, BL.BlNo)

    '          Temp.Clear()
    '          Temp.AcceptChanges()

    '          For Each DrInv In DrsInv

    '              Titles = Title.Select("ChargesCode = '" & DrInv("ChargeCode") & "'")
    '              If Titles.Length = 0 Then
    '                  Titles = TitleSub.Select("ChargesCode = '" & DrInv("ChargeCode") & "'")

    '                  If Titles.Length = 0 Then
    '                      Msg = "No Charge Define [" & DrInv("ChargeCode") & "]"
    '                      GenResult = False
    '                      Exit Sub
    '                  End If
    '              End If
    '              If DrInv("ChargeCode") = "D.D" Then
    '                  nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("CRAccount") & "' and " & _
    '                                                        "Level1 = '" & GetLevel(Titles(0).Item("CrLevel1").ToString, BL, Voy, Client) & "' and " & _
    '                                                        "Level2 = '" & GetLevel(Titles(0).Item("CrLevel2").ToString, BL, Voy, Client) & "' and " & _
    '                                                        "Level3 = '" & GetLevel(Titles(0).Item("CrLevel3").ToString, BL, Voy, Client) & "' and " & _
    '                                                        "Level4 = '" & GetLevel(Titles(0).Item("CrLevel4").ToString, BL, Voy, Client) & "' and " & _
    '                                                        "Level5 = '" & GetLevel(Titles(0).Item("CrLevel5").ToString, BL, Voy, Client) & "' and " & _
    '                                                        "InvNo = '" & DR("InvNo") & "'")

    '                  If nDrs.Length = 0 Then
    '                      nDr = Temp.NewRow
    '                      nDr("LevelAcc") = Titles(0).Item("CrAccount")
    '                      nDr("Level1") = GetLevel(Titles(0).Item("CrLevel1").ToString, BL, Voy, Client)
    '                      nDr("Level2") = GetLevel(Titles(0).Item("CrLevel2").ToString, BL, Voy, Client)
    '                      nDr("Level3") = GetLevel(Titles(0).Item("CrLevel3").ToString, BL, Voy, Client)
    '                      nDr("Level4") = GetLevel(Titles(0).Item("CrLevel4").ToString, BL, Voy, Client)
    '                      nDr("Level5") = GetLevel(Titles(0).Item("CRLevel5").ToString, BL, Voy, Client)
    '                      nDr("Amount") = Math.Round(DrInv("Amount"))
    '                      nDr("Desc") = " تسویه صورتحساب " & DrInv("InvNO")
    '                      nDr("InvNo") = DrInv("InvNO")
    '                      nDr("DC") = "2C"
    '                      nDr("BLNO") = DrInv("BLNO")
    '                      Temp.Rows.Add(nDr)
    '                  Else
    '                      nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + DrInv("Amount")
    '                  End If

    '              Else
    '                  If DrInv("ChargeCode") = "TAX" Or DrInv("ChargeCode") = "TOLL" Then
    '                  Else
    '                      nDrs = Temp.Select("LevelAcc = '" & Titles(0).Item("DBAccount") & "' and " & _
    '                                                            "Level1 = '" & GetLevel(Titles(0).Item("DBLevel1").ToString, BL, Voy, Client) & "' and " & _
    '                                                            "Level2 = '" & GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client) & "' and " & _
    '                                                            "Level3 = '" & GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client) & "' and " & _
    '                                                            "Level4 = '" & GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client) & "' and " & _
    '                                                            "Level5 = '" & GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client) & "' and " & _
    '                                                            "InvNo = '" & DR("InvNo") & "'")

    '                      If nDrs.Length = 0 Then
    '                          nDr = Temp.NewRow
    '                          nDr("LevelAcc") = Titles(0).Item("DBAccount")
    '                          nDr("Level1") = GetLevel(Titles(0).Item("DbLevel1").ToString, BL, Voy, Client)
    '                          nDr("Level2") = GetLevel(Titles(0).Item("DBLevel2").ToString, BL, Voy, Client)
    '                          nDr("Level3") = GetLevel(Titles(0).Item("DBLevel3").ToString, BL, Voy, Client)
    '                          nDr("Level4") = GetLevel(Titles(0).Item("DBLevel4").ToString, BL, Voy, Client)
    '                          nDr("Level5") = GetLevel(Titles(0).Item("DBLevel5").ToString, BL, Voy, Client)
    '                          If DrInv("ChargeCode") = "DETN-A" Then
    '                              nDr("Amount") = Math.Round((DrInv("Amount")))
    '                          Else
    '                              Select Case Int32.Parse(DR("Per").ToString)
    '                                  Case 4
    '                                      nDr("Amount") = Math.Round((DrInv("Amount") * 104) / 100)
    '                                  Case 5
    '                                      nDr("Amount") = Math.Round((DrInv("Amount") * 105) / 100)
    '                                  Case 6
    '                                      nDr("Amount") = Math.Round((DrInv("Amount") * 106) / 100)
    '                              End Select
    '                          End If
    '                          nDr("Desc") = " تسویه صورتحساب " & DrInv("InvNO")
    '                          nDr("InvNo") = DrInv("InvNO")
    '                          nDr("DC") = "2C"
    '                          nDr("BLNO") = DrInv("BLNO")
    '                          Temp.Rows.Add(nDr)
    '                      Else
    '                          If DrInv("ChargeCode") = "DETN-A" Then
    '                              nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + DrInv("Amount")
    '                          Else
    '                              Select Case Int32.Parse(DR("Per").ToString)
    '                                  Case 4
    '                                      nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + (Math.Round((DrInv("Amount") * 104) / 100))
    '                                  Case 5
    '                                      nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + (Math.Round((DrInv("Amount") * 105) / 100))
    '                                  Case 6
    '                                      nDrs(0).Item("Amount") = nDrs(0).Item("Amount") + (Math.Round((DrInv("Amount") * 106) / 100))
    '                              End Select

    '                          End If
    '                      End If

    '                  End If
    '              End If

    '          Next

    '          If Balance < 0 Then
    '              xDrs = Title.Select("ChargesCode = 'OVP'")
    '              nDr = Temp.NewRow
    '              nDr("LevelAcc") = xDrs(0).Item("CRAccount")
    '              nDr("Level1") = GetLevel(xDrs(0).Item("CRLevel1"), BL, Voy, Client)
    '              nDr("Level2") = GetLevel(xDrs(0).Item("CRLevel2"), BL, Voy, Client)
    '              nDr("Level3") = GetLevel(xDrs(0).Item("CRLevel3"), BL, Voy, Client)
    '              nDr("Amount") = Balance * -1
    '              nDr("Desc") = "اضافه پرداخت " & DR("InvNo") & "بارنامه" & DrsInv(0).Item("BLNO")
    '              nDr("InvNo") = DR("InvNo")
    '              nDr("DC") = "2C"
    '              nDr("BLNO") = DR("BLNO")
    '              Temp.Rows.Add(nDr)
    '          End If

    '          Dim NotPayDrs() As DataRow
    '          NotPayDrs = Ds.Tables(1).Select("InvNo = '" & DR("InvNo") & "'")
    '          TTLNotPaid = 0
    '          If NotPayDrs.Length = 0 Then
    '              DrsForNotpaid = Ds.Tables(0).Select("InvNo = '" & DR("InvNo") & "'")
    '              For Each DrForNotpaid In DrsForNotpaid
    '                  TTLNotPaid += DrForNotpaid("Amount")
    '              Next
    '          End If

    '          If TTLNotPaid > 0 Then
    '              xDrs = Title.Select("ChargesCode = 'LP'")
    '              nDr = Temp.NewRow
    '              nDr("LevelAcc") = xDrs(0).Item("DBAccount")
    '              nDr("Level1") = GetLevel(xDrs(0).Item("DBLevel1"), BL, Voy, Client)
    '              nDr("Level2") = GetLevel(xDrs(0).Item("DBLevel2"), BL, Voy, Client)
    '              nDr("Level3") = GetLevel(xDrs(0).Item("DBLevel3"), BL, Voy, Client)
    '              nDr("Amount") = TTLNotPaid
    '              nDr("Desc") = "کسر پرداخت " & DR("InvNo") & "بارنامه" & DrsInv(0).Item("BLNO")
    '              nDr("InvNo") = DR("InvNo")
    '              nDr("DC") = "1D"
    '              nDr("BLNO") = DR("BLNO")
    '              Temp.Rows.Add(nDr)
    '          End If
    '          AddToTemp(Temp, TBXML, XmlRowSeq, BL.BlNo)
    '      Next

    '      Temp.Clear()
    '      Temp.AcceptChanges()


    '      For Each DR In Ds.Tables(2).Rows

    '          BL = New CLInwardBls
    '          Voy = New CLVoyage
    '          Client = New CLClientsAccount
    '          DrsInv = Ds.Tables(0).Select("InvNo = '" & DR("InvNo") & "' and BlNo = '" & DR("BLNO") & "'")
    '          DrsPay = Ds.Tables(1).Select("InvNo = '" & DR("InvNo") & "'  and chargeCode <> '' and BlNo = '" & DR("BLNO") & "'")
    '          BL.GetByCarrBlNo("V", DrsInv(0).Item("BLNO"), lResult)
    '          Voy.GetByVoyageID(BL.FdrVsl, lResult)
    '          Client.GetByClientID(BL.ClientID, lResult)
    '          DrInv = DrsInv(0)


    '          For Each DrPay In DrsPay
    '              DepositTitleDrs = DepositTitle.Select("ChargesCode = '" & DrPay("ChargeCode") & "' and PaymentType = '" & DrPay("PaymentType") & "'")
    '              If DepositTitleDrs.Length = 0 Then
    '                  Msg = "No Valid Deposit items !" & DrsInv(0).Item("BLNO")
    '                  Exit Sub
    '              End If

    '              DepositTitleDr = DepositTitleDrs(0)
    '              nDr = Temp.NewRow
    '              nDr("LevelAcc") = DrPay("DBAccount")
    '              nDr("Level1") = GetLevel(DrPay("DBLevel1").ToString, BL, Voy, Client)
    '              nDr("Level2") = GetLevel(DrPay("DBLevel2").ToString, BL, Voy, Client)
    '              nDr("Level3") = GetLevel(DrPay("DBLevel3").ToString, BL, Voy, Client)
    '              nDr("Level4") = GetLevel("", BL, Voy, Client)
    '              nDr("Level5") = GetLevel("", BL, Voy, Client)
    '              nDr("Amount") = Math.Round(DrPay("IrrAmount"))
    '              nDr("BLNO") = DrPay("BLNO")

    '              If DrPay("ChargeCode") = "C.V.D" Then
    '                  If NZ(DrPay("PaidRef"), "") = "" Then
    '                      nDr("Desc") = " پرداخت بابت تضمین " & DrsInv(0).Item("InvNO")
    '                  Else
    '                      nDr("Desc") = " پرداخت بابت تضمین " & DrsInv(0).Item("InvNO") & " طی چک " & DrPay("PaidRef")
    '                  End If
    '              Else
    '                  If NZ(DrPay("PaidRef"), "") = "" Then
    '                      nDr("Desc") = " پرداخت بابت سپرده " & DrsInv(0).Item("InvNO")
    '                  Else
    '                      nDr("Desc") = " پرداخت بابت سپرده " & DrsInv(0).Item("InvNO") & " طی فیش " & DrPay("PaidRef")
    '                  End If
    '              End If


    '              nDr("DC") = "1D"
    '              nDr("INVNo") = DrsInv(0).Item("InvNO")
    '              nDr("Ref") = DrPay("PaidRef")

    '              Temp.Rows.Add(nDr)

    '              If Ds.Tables(0).Select("InvNo = '" & DR("InvNo") & "' and chargeCode = '" & DrPay("chargeCode") & "'").Length = 0 Then

    '                  nDr = Temp.NewRow
    '                  nDr("LevelAcc") = DepositTitleDr.Item("CRAccount")
    '                  nDr("Level1") = GetLevel(DepositTitleDr.Item("CRLevel1").ToString, BL, Voy, Client)
    '                  nDr("Level2") = GetLevel(DepositTitleDr.Item("CRLevel2").ToString, BL, Voy, Client)
    '                  nDr("Level3") = GetLevel(DepositTitleDr.Item("CRLevel3").ToString, BL, Voy, Client)
    '                  nDr("Level4") = GetLevel(DepositTitleDr.Item("CRLevel4").ToString, BL, Voy, Client)
    '                  nDr("Level5") = GetLevel(DepositTitleDr.Item("CRLevel5").ToString, BL, Voy, Client)
    '                  nDr("Amount") = Math.Round(DrPay("IrrAmount"))
    '                  nDr("BLNO") = DrPay("BLNO")

    '                  If DrPay("ChargeCode") = "C.V.D" Then
    '                      If NZ(DrPay("PaidRef"), "") = "" Then
    '                          nDr("Desc") = " پرداخت بابت تضمین " & DrsInv(0).Item("InvNO")
    '                      Else
    '                          nDr("Desc") = " پرداخت بابت تضمین " & DrsInv(0).Item("InvNO") & " طی چک " & DrPay("PaidRef")
    '                      End If
    '                  Else
    '                      If NZ(DrPay("PaidRef"), "") = "" Then
    '                          nDr("Desc") = " پرداخت بابت سپرده " & DrsInv(0).Item("InvNO")
    '                      Else
    '                          nDr("Desc") = " پرداخت بابت سپرده " & DrsInv(0).Item("InvNO") & " طی فیش " & DrPay("PaidRef")
    '                      End If
    '                  End If

    '                  nDr("DC") = "2C"
    '                  nDr("INVNo") = DrPay("InvNO")

    '                  Temp.Rows.Add(nDr)

    '              End If
    '          Next
    '          AddToTemp(Temp, TBXML, XmlRowSeq, BL.BlNo)
    '          Temp.Clear()
    '          Temp.AcceptChanges()

    '      Next

    '      Dim sResult As String
    '      sResult = WriteXML(TBXML) '   SB.ToString
    '      Dim SW As New IO.StreamWriter(FleName)
    '      SW.Write(sResult)
    '      SW.Flush()
    '      SW.Close()
    '      GenResult = True
    '      Msg = "Generate File Sucessful"

    '  End Sub

    '  Private Sub NoInArrival()

    '      'For Each DR In TbNoInArrival.Rows

    '      'Next
    '  End Sub

    '  Private Sub AddToTemp(ByRef Temp As DataTable, ByRef TBXML As DataTable, ByRef XmlRowSeq As Int32, ByVal BLNO As String)

    '      Dim nDR As DataRow
    '      Dim XMLRow As DataRow
    '      Dim XMLRows() As DataRow

    '      Dim Drs = Temp.Select("", "InvNo , DC")
    '      For Each nDR In Drs
    '          If nDR("InvNo") = "B12I-05243" Then
    '              Beep()
    '          End If
    '          If NZ(nDR("Amount"), 0) > 0 Then
    '              nDR("Amount") = Math.Round(Val(nDR("Amount")))
    '              XMLRows = TBXML.Select("LevelAcc = '" & nDR("LevelAcc") & "' and " & _
    '                                     "Det1 = '" & nDR("Level1") & "' and " & _
    '                                     "Det2 = '" & nDR("Level2") & "' and " & _
    '                                     "Det3 = '" & nDR("Level3") & "' and " & _
    '                                     "Det4 = '" & nDR("Level4") & "' and " & _
    '                                     "Ref  = '" & nDR("Ref") & "'")

    '              If XMLRows.Length = 0 Then
    '                  XmlRowSeq += 1
    '                  XMLRow = TBXML.NewRow
    '                  XMLRow("Seq") = XmlRowSeq
    '                  XMLRow("Levelacc") = nDR("LevelAcc")
    '                  XMLRow("Det1") = nDR("Level1")
    '                  XMLRow("Det2") = nDR("Level2")
    '                  XMLRow("Det3") = nDR("Level3")
    '                  XMLRow("Det4") = nDR("Level4")
    '                  XMLRow("Ref") = nDR("Ref")
    '                  XMLRow("InvNo") = nDR("InvNo")
    '                  If nDR("DC") = "1D" Then
    '                      XMLRow("Deb") = (NZ(nDR("Amount"), 0) / 100).ToString
    '                      XMLRow("Cre") = ""
    '                  Else
    '                      XMLRow("Cre") = (NZ(nDR("Amount"), 0) / 100).ToString
    '                      XMLRow("Deb") = ""
    '                  End If
    '                  XMLRow("Desc") = nDR("Desc")
    '                  XMLRow("ODesc") = nDR("BLNO")
    '                  TBXML.Rows.Add(XMLRow)
    '              Else
    '                  If nDR("DC") = "1D" Then
    '                      If XMLRows(0).Item("Deb") = "" Then
    '                          XMLRows(0).Item("Deb") = "0"
    '                      End If
    '                      XMLRows(0).Item("Deb") = (Double.Parse(XMLRows(0).Item("Deb") + (NZ(nDR("Amount"), 0) / 100))).ToString
    '                  Else
    '                      If XMLRows(0).Item("Cre") = "" Then
    '                          XMLRows(0).Item("Cre") = "0"
    '                      End If
    '                      XMLRows(0).Item("Cre") = (Double.Parse(XMLRows(0).Item("Cre") + (NZ(nDR("Amount"), 0) / 100))).ToString
    '                  End If
    '                  XMLRows(0).Item("Desc") = XMLRows(0).Item("Desc") & " " & nDR("Desc")
    '              End If
    '          End If
    '      Next

    '  End Sub

    '  Private Function WriteXML(ByVal TBXML As DataTable) As String

    '      Dim nDr As DataRow
    '      Dim sArticle As String
    '      Dim Drs() As DataRow = TBXML.Select("", "InvNo ,  DC , seq ")
    '      Dim SB As New StringBuilder

    '      SB.AppendLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "UTF-8" & """" & "?>")
    '      SB.AppendLine("<_XPXML>")

    '      For Each nDr In Drs

    '          sArticle = "<_FTrans Acc=" & """"
    '          sArticle += nDr("LevelAcc") & """" & " "

    '          sArticle += "Det1=" & """"
    '          sArticle += nDr("Det1").ToString & """" & " "

    '          sArticle += "Det2=" & """"
    '          sArticle += nDr("Det2").ToString & """" & " "

    '          sArticle += "Det3=" & """"
    '          sArticle += nDr("Det3").ToString & """" & " "

    '          sArticle += "Det4=" & """"
    '          sArticle += nDr("Det4").ToString & """" & " "

    '          sArticle += "Det5=" & """" & """" & " "

    '          If Microsoft.VisualBasic.Trim(nDr("Cre")) <> "" Then
    '              If nDr("Cre") < 0 Then
    '                  sArticle += "Deb=" & """"
    '                  sArticle += nDr("Cre") * -1 & """" & " "
    '              Else
    '                  sArticle += "Cre=" & """"
    '                  sArticle += nDr("Cre") & """" & " "
    '              End If

    '          Else
    '              If nDr("Deb") < 0 Then
    '                  sArticle += "Cre=" & """"
    '                  sArticle += nDr("Deb") & """" & " "
    '              Else
    '                  sArticle += "Deb=" & """"
    '                  sArticle += nDr("Deb") & """" & " "
    '              End If
    '          End If
    '          sArticle += "Desc=" & """" & nDr("Desc") & """" & " "
    '          sArticle += "ODesc=" & """" & nDr("oDesc") & """" & " "

    '          sArticle += " CurrAmount=" & """" & """" & " Curr=" & """" & """" & " UnitAmount=" & """" & """" & " Unit=" & """" & """" & " DueN=" & """" & """" & " DueD=" & """" & """" & " RefN=" & """" & """" & "/>"

    '          SB.AppendLine.AppendLine(sArticle)

    '      Next
    '      SB.AppendLine("</_XPXML>")

    '      Return SB.ToString

    '  End Function


    '  Private Sub CompareByArrival(ByVal VoyageID As String, ByVal BLNO As String, ByVal InvDrs() As DataRow)

    '      Dim Cmd As New SqlCommand("SP_ExtractDataFromNosa")
    '      Dim Cnn As New SqlConnection(My.Settings.ECSCnn)
    '      Dim sSql As String
    '      Dim lResult As Boolean
    '      Dim DS As New DataSet
    '      Dim TBNosa As New DataTable
    '      Dim InvDr As DataRow
    '      Dim NosaDr As DataRow
    '      Dim NosaDrs() As DataRow
    '      Dim NewDr As DataRow

    '      TbSame.Clear()
    '      TbNoInArrival.Clear()
    '      TbNoInInvoice.Clear()

    '      TbSame.AcceptChanges()
    '      TbNoInArrival.AcceptChanges()
    '      TbNoInInvoice.AcceptChanges()

    '      sSql = "SP_ExtractDataFromNosa '" & VoyageID & "' , '" & BLNO & "'"
    '      FillDataInDataSetEcs(sSql, DS, "NOSA", lResult)
    '      TBNosa = DS.Tables(0)

    '      For Each InvDr In InvDrs
    '          NosaDrs = TBNosa.Select("ChargeItem = '" & InvDr("Chargecode") & "'")
    '          If NosaDrs.Length = 0 Then
    '              ' Check for Itemes which are not in Arrival 
    '              NewDr = TbNoInArrival.NewRow
    '              NewDr("ChargeItem") = InvDr("Chargecode")
    '              NewDr("InvAmount") = InvDr("Amount")
    '              TbNoInArrival.Rows.Add(NewDr)
    '          Else
    '              If NosaDrs(0).Item("Amount") = InvDr("Amount") Then
    '                  ' Check For The Same Items 
    '                  NewDr = TbSame.NewRow
    '                  NewDr("ChargeItem") = InvDr("Chargecode")
    '                  NewDr("InvAmount") = InvDr("Amount")
    '                  TbSame.Rows.Add(NewDr)
    '              Else
    '                  ' Check For Items which are not Equal Amount 
    '                  NewDr = TbNoSame.NewRow
    '                  NewDr("ChargeItem") = InvDr("Chargecode")
    '                  NewDr("InvAmount") = InvDr("Amount")
    '                  NewDr("NosaAmount") = NosaDrs(0).Item("Amount")
    '                  TbNoSame.Rows.Add(NewDr)
    '              End If
    '          End If
    '      Next

    '      ' Check For The Items which are not in the invoice 
    '  End Sub

    '  Private Sub AddToError(ByVal Bl As CLInwardBls, ByVal Voy As CLVoyage, ByVal Cl As CLClientsAccount, ByVal problem As String)
    '      Dim Dr As DataRow
    '      Dim Drs() As DataRow
    '      Dim lResult As Boolean
    '      If TbError Is Nothing Then
    '          TbError = New DataTable
    '          TbError.Columns.Add(New DataColumn("VoyageNo"))
    '          TbError.Columns.Add(New DataColumn("BLNO"))
    '          TbError.Columns.Add(New DataColumn("ClientCode"))
    '          TbError.Columns.Add(New DataColumn("Problem"))
    '      End If

    '      Drs = TbError.Select("VoyageNo = '" & Voy.Vessel & "." & Voy.VoyageNo & "' and BlNo = '" & Bl.BlNo & "' and Problem = '" & problem & "'")
    '      If Drs.Length = 0 Then
    '          Dim Clint As New CLClients
    '          Dr = TbError.NewRow
    '          Dr("BLNO") = Bl.BlNo
    '          Dr("VoyageNo") = Voy.Vessel & "." & Voy.VoyageNo
    '          Dr("Problem") = problem
    '          Clint.GetByID(Cl.ClientID, lResult)
    '          If lResult = True Then
    '              Dr("ClientCode") = Clint.Code
    '          End If
    '          TbError.Rows.Add(Dr)
    '          lError = True
    '      End If
    '  End Sub

    '  Public ReadOnly Property GenerateWitError() As Boolean
    '      Get
    '          Return lError
    '      End Get
    '  End Property

    '  Public ReadOnly Property ErrorTable() As DataTable
    '      Get
    '          Return TbError
    '      End Get
    '  End Property



    



End Class
