Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient

Public Class CLCalculationBase

    Enum ExchangeRateInward
        DailyExchangeRateInvoiceGenerateTime
        DailyExchangeRateVoyageArrivalTime
        DailyExchangeRateDischargeCompleted
        VoyageExchangeRate
    End Enum
    Enum ExchangeRateOutward

        DailyExchangeRateInvoiceGenerateTime
        DailyExchangeRateOnBoardDate
        DailyExchangeRateCompletedLoading
        DailyExchangeRateVoyageDepartureTime
        VoyageExchangeRate

    End Enum
    Enum DetentionInwardStartTime
        VoyageArrivalTime
        VoyageCompletedDischarge
        BaseonDFDateInECS
    End Enum

    Enum DetentionOutwardEndTime
        FullForLoadingDateInECS
        OnboardDateOnBL
    End Enum

    Enum TaxDutyInward
        BaseOnInvoiceGenearteTime
        BaseOnArrivalTime
        BaseOnCompletedDischarge
        BaseOnBerth
    End Enum
    Enum TaxDutyOutward
        InvoiceGenerateTime
        VoyageDepartureTime
    End Enum

    Public Enum CalculationType
        TaxDutyInward
        TaxDutyOutWard
        ExchangeInward
        ExchangeOutWard
    End Enum

    Private CalType As CalculationType
    Private DocumentID As Guid
    Private mDateOf As Date = Nothing
    Private DM As DataManager
    Private Excep As String
    Private TaxRate, DutyRate As Double
    Private ExchgFrt, ExchgThc, ExchgDETN As Long
    Private Currency As String
    Private CntrNo As String
    Public Function GetExchangeInward(ByVal DocumentID As Guid, ByVal Currency As String, ByRef ExchFrt As Double, ByRef ExchTHC As Double, ByRef ExchDETN As Double) As Boolean

        Dim ExchgType As ExchangeRateInward
        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Me.Currency = Currency
        Me.ExchgFrt = -1
        Me.ExchgThc = -1
        Me.ExchgDETN = -1

        ExchgType = Byte.Parse(calculationBase.ExchangeRateInward)

        If ExchgType = ExchangeRateInward.VoyageExchangeRate Then
            sSql = "Select ExchangeFrt , ExchangeThc From TB_InwardBls BL , TB_Voyage VO Where " &
                                 "BL.VoyageID = VO.ID and BL.ID = '" &
                                 DocumentID.ToString & "'"
            TableBySql(sSql, TB, lResult)
            If lResult = True Then
                If TB.Rows.Count > 0 Then
                    ExchgFrt = TB.Rows(0).Item("ExchangeFrt")
                    ExchgThc = TB.Rows(0).Item("ExchangeThc")
                    lResult = True
                Else
                    lResult = False
                    Excep = "No Valid Rate in Voyage, Please check Exchange at Voyage Data."
                End If
            Else
                Excep = "No Valid Rate in Voyage, Please check Exchange at Voyage Data."
            End If
        Else
            If ExchgType = ExchangeRateInward.DailyExchangeRateInvoiceGenerateTime Then
                mDateOf = Now.Date
                lResult = True
            Else
                Select Case ExchgType

                    Case ExchangeRateInward.DailyExchangeRateDischargeCompleted
                        sSql = "Select Sof.DschCmpl From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " &
                            "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" &
                            DocumentID.ToString & "'"
                        TableBySql(sSql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If Not IsDBNull(TB.Rows(0).Item("DschCmpl")) Then
                                    mDateOf = TB.Rows(0).Item("DschCmpl")
                                    lResult = True
                                Else
                                    lResult = False
                                    Excep = "Dischareg Completed is Balnk, Please Check SOF Data"
                                End If
                            Else
                                lResult = False
                                Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Dischage Completed is set"
                            End If
                        Else
                            lResult = False
                            Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Dischage Completed is set"
                        End If

                    Case ExchangeRateInward.DailyExchangeRateVoyageArrivalTime
                        sSql = "Select convert(date,Berthed) AS Berthed From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " &
                          "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" &
                        DocumentID.ToString & "'"
                        TableBySql(sSql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If Not IsDBNull(TB.Rows(0).Item("Berthed")) Then
                                    mDateOf = TB.Rows(0).Item("Berthed")
                                    lResult = True
                                Else
                                    lResult = False
                                    Excep = "Berthed Date Is Balnk, Please Check SOF Data"
                                End If
                            Else
                                lResult = False
                                Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Berthed Date is set"
                            End If
                        Else
                            lResult = False
                            Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Berthed Date is set"
                        End If

                End Select

            End If

            If lResult = True Then
                lResult = SetExchange()
            End If

        End If

        ExchFrt = Me.ExchgFrt
        ExchTHC = Me.ExchgThc
        ExchDETN = Me.ExchgDETN


        Return lResult

    End Function

    Public Function GetExchangeInward(ByVal DocumentID As Guid, ByVal Currency As String, ByRef ExchFrt As Double, ByRef ExchTHC As Double) As Boolean

        Dim ExchgType As ExchangeRateInward
        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Me.Currency = Currency
        Me.ExchgFrt = -1
        Me.ExchgThc = -1

        ExchgType = Byte.Parse(calculationBase.ExchangeRateInward)

        If ExchgType = ExchangeRateInward.VoyageExchangeRate Then
            sSql = "Select ExchangeFrt , ExchangeThc From TB_InwardBls BL , TB_Voyage VO Where " & _
                                 "BL.VoyageID = VO.ID and BL.ID = '" & _
                                 DocumentID.ToString & "'"
            TableBySql(sSql, TB, lResult)
            If lResult = True Then
                If TB.Rows.Count > 0 Then
                    ExchgFrt = TB.Rows(0).Item("ExchangeFrt")
                    ExchgThc = TB.Rows(0).Item("ExchangeThc")
                    lResult = True
                Else
                    lResult = False
                    Excep = "No Valid Rate in Voyage, Please check Exchange at Voyage Data."
                End If
            Else
                Excep = "No Valid Rate in Voyage, Please check Exchange at Voyage Data."
            End If
        Else
            If ExchgType = ExchangeRateInward.DailyExchangeRateInvoiceGenerateTime Then
                mDateOf = Now.Date
                lResult = True
            Else
                Select Case ExchgType

                    Case ExchangeRateInward.DailyExchangeRateDischargeCompleted
                        sSql = "Select Sof.DschCmpl From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                            "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                            DocumentID.ToString & "'"
                        TableBySql(sSql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If Not IsDBNull(TB.Rows(0).Item("DschCmpl")) Then
                                    mDateOf = TB.Rows(0).Item("DschCmpl")
                                    lResult = True
                                Else
                                    lResult = False
                                    Excep = "Dischareg Completed is Balnk, Please Check SOF Data"
                                End If
                            Else
                                lResult = False
                                Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Dischage Completed is set"
                            End If
                        Else
                            lResult = False
                            Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Dischage Completed is set"
                        End If

                    Case ExchangeRateInward.DailyExchangeRateVoyageArrivalTime
                        sSql = "Select convert(date,Berthed) AS Berthed From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                          "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                        DocumentID.ToString & "'"
                        TableBySql(sSql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If Not IsDBNull(TB.Rows(0).Item("Berthed")) Then
                                    mDateOf = TB.Rows(0).Item("Berthed")
                                    lResult = True
                                Else
                                    lResult = False
                                    Excep = "Berthed Date Is Balnk, Please Check SOF Data"
                                End If
                            Else
                                lResult = False
                                Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Berthed Date is set"
                            End If
                        Else
                            lResult = False
                            Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Berthed Date is set"
                        End If

                End Select

            End If

            If lResult = True Then
                lResult = SetExchange()
            End If

        End If

        ExchFrt = Me.ExchgFrt
        ExchTHC = Me.ExchgThc

        Return lResult

    End Function

    Public Function GetExchangeOutward(ByVal DoecumentID As Guid, ByVal Currency As String, ByRef ExchFrt As Double, ByRef ExchTHC As Double) As Boolean

        Dim ExchgType As ExchangeRateOutward
        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Me.Currency = Currency
        Me.ExchgFrt = -1
        Me.ExchgThc = -1

        ExchgType = Byte.Parse(calculationBase.ExchangeRateInward)

        If ExchgType = ExchangeRateOutward.VoyageExchangeRate Then
            sSql = "Select ExchangeFrt , ExchangeThc From TB_OutwardBls BL , TB_Voyage VO Where " & _
                                 "BL.VoyageID = VO.ID and BL.ID = '" & _
                                 DocumentID.ToString & "'"
            TableBySql(sSql, TB, lResult)
            If lResult = True Then
                If TB.Rows.Count > 0 Then
                    ExchgFrt = TB.Rows(0).Item("ExchangeFrt")
                    ExchgThc = TB.Rows(0).Item("ExchangeThc")
                    lResult = True
                Else
                    lResult = False
                    Excep = "No Valid Rate in Voyage, Please chcek Exchange at Voyage Data."
                End If
            Else
                Excep = "No Valid Rate in Voyage, Please chcek Exchange at Voyage Data."
            End If

            If ExchgType = ExchangeRateOutward.DailyExchangeRateInvoiceGenerateTime Then
                mDateOf = Now.Date
                lResult = True
            Else
                Select Case ExchgType

                    Case ExchangeRateOutward.DailyExchangeRateOnBoardDate
                        sSql = "Select OnBoardDate From TB_OutwardBls BL Where " & _
                            " BL.ID = '" & DocumentID.ToString & "'"
                        TableBySql(sSql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If Not IsDBNull(TB.Rows(0).Item("OnBoardDate")) Then
                                    mDateOf = TB.Rows(0).Item("OnBoardDate")
                                    lResult = True
                                Else
                                    lResult = False
                                    Excep = "OnBoardDate is Balnk, Please Check Outward B/L Data"
                                End If
                            Else
                                lResult = False
                                Excep = "No Valid B/L !"
                            End If
                        Else
                            lResult = False
                            Excep = "No Valid B/L !"
                        End If

                    Case ExchangeRateOutward.DailyExchangeRateVoyageDepartureTime
                        'sSql = "Select Sof.Sailed From TB_OutwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                        '    "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                        '    DocumentID.ToString & "'"
                        sSql = "Select Sof.Berthed From TB_OutwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                           "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                           DocumentID.ToString & "'"
                        TableBySql(sSql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If Not IsDBNull(TB.Rows(0).Item("Berthed")) Then
                                    mDateOf = TB.Rows(0).Item("Berthed")
                                    lResult = True
                                Else
                                    lResult = False
                                    Excep = "Berthed Date is Balnk, Please Check SOF Data"
                                End If
                            Else
                                lResult = False
                                Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Berthed Date is set"
                            End If
                        Else
                            lResult = False
                            Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Berthed Date is set"
                        End If

                    Case ExchangeRateOutward.DailyExchangeRateCompletedLoading
                        sSql = "Select LoadCmpl From TB_OutwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                          "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                        DocumentID.ToString & "'"
                        TableBySql(sSql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If Not IsDBNull(TB.Rows(0).Item("LoadCmpl")) Then
                                    mDateOf = TB.Rows(0).Item("LoadCmpl")
                                    lResult = True
                                Else
                                    lResult = False
                                    Excep = "Loading Completed Date Is Balnk, Please Check SOF Data"
                                End If
                            Else
                                lResult = False
                                Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Loading Completed Date is set"
                            End If
                        Else
                            lResult = False
                            Excep = "No Valid Voyage/SOF Data! Please check Voyage & SOF And Make Sure Loading Completed Date is set"
                        End If

                End Select


            End If
            If lResult = True Then
                lResult = SetExchange()
            End If
        End If

        ExchFrt = Me.ExchgFrt
        ExchTHC = Me.ExchgThc

        Return lResult

    End Function

    Public Function GetDetentionInwardStartTime(ByVal BLID As Guid, ByVal CntrNo As String) As Boolean

        Dim EcsStartType As DetentionInwardStartTime
        Dim sSql As String
        Dim DA As New SqlDataAdapter
        Dim TB As New DataTable
        Dim VoyageID As String
        Dim Cmd As New SqlCommand()
        Dim Cnn As New SqlConnection(My.Settings.DSN)

        EcsStartType = Byte.Parse(calculationBase.DetentionInwardStartTime)
        Excep = ""
        Cnn.Open()

        Select Case EcsStartType

            Case DetentionInwardStartTime.BaseonDFDateInECS
                sSql = "select Top 1 dbo.FC_EcsDateByVoyCntrStatus(Voy.ID , @CntrNo , 'DF' , 'F' ) as EcsDate " & _
                      "From TB_Voyage Voy , TB_InwardBls Bls where " & _
                       "Voy.ID = Bls.VoyageID and " & _
                       "bls.ID = @BLID"
                With Cmd
                    .CommandText = sSql
                    .CommandType = CommandType.Text
                    .Connection = Cnn
                    .Parameters.AddWithValue("@BLID", BLID)
                    .Parameters.AddWithValue("@CntrNo", CntrNo)
                End With
                DA.SelectCommand = Cmd
                DA.Fill(TB)

                If TB.Rows.Count = 0 Then
                    Excep = "Please Check ECS Data For Container " & CntrNo
                Else
                    If IsDBNull(TB.Rows(0).Item("EcsDate")) Then
                        Excep = "Please Check ECS Data For Container " & CntrNo
                    Else
                        mDateOf = TB.Rows(0).Item("EcsDate")
                    End If
                End If

            Case DetentionInwardStartTime.VoyageArrivalTime
                sSql = "select Top 1 Arrival " & _
                      "From TB_Voyage Voy , TB_InwardBls Bls , TB_SOF SOF where " & _
                      "Voy.ID = Bls.VoyageID and " & _
                      "SOF.VoyageID = Voy.ID and " & _
                      "SOF.Port = Bls.POD and " & _
                      "bls.ID = @BLID"
                With Cmd
                    .CommandText = sSql
                    .CommandType = CommandType.Text
                    .Connection = Cnn
                    .Parameters.AddWithValue("@BLID", BLID)
                End With
                DA.SelectCommand = Cmd
                DA.Fill(TB)

                If TB.Rows.Count = 0 Then
                    Excep = "Please Check Arrival Date in Voyage Data "
                Else
                    If IsDBNull(TB.Rows(0).Item("Arrival")) Then
                        Excep = "Please Check Arrival Date in Voyage Data "
                    Else
                        mDateOf = TB.Rows(0).Item("Arrival")
                    End If
                End If

            Case DetentionInwardStartTime.VoyageCompletedDischarge
                sSql = "select Top 1 DschCmpl " & _
                     "From TB_Voyage Voy , TB_InwardBls Bls , TB_SOF SOF where " & _
                     "Voy.ID = Bls.VoyageID and " & _
                     "SOF.VoyageID = Voy.ID and " & _
                     "SOF.Port = Bls.POD and " & _
                     "bls.ID = @BLID"
                With Cmd
                    .CommandText = sSql
                    .CommandType = CommandType.Text
                    .Connection = Cnn
                    .Parameters.AddWithValue("@BLID", BLID)
                End With
                DA.SelectCommand = Cmd
                DA.Fill(TB)

                If TB.Rows.Count = 0 Then
                    Excep = "Please Check Dischareg Completed Date in Voyage Data "
                Else
                    If IsDBNull(TB.Rows(0).Item("DschCmpl")) Then
                        Excep = "Please Check Dischareg Completed Date in Voyage Data "
                    Else
                        mDateOf = TB.Rows(0).Item("DschCmpl")
                    End If
                End If

        End Select

        If Excep = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetDetentionOutwardEndTime(ByVal BLID As Guid, ByVal CntrNo As String) As Boolean

        Dim EcsStartType As DetentionOutwardEndTime
        Dim sSql As String
        Dim DA As New SqlDataAdapter
        Dim TB As New DataTable
        Dim VoyageID As String
        Dim Cmd As New SqlCommand()
        Dim Cnn As New SqlConnection(My.Settings.DSN)

        EcsStartType = Byte.Parse(calculationBase.DetentionOutwardStartTime)
        Excep = ""
        Cnn.Open()

        Select Case EcsStartType

            Case DetentionOutwardEndTime.FullForLoadingDateInECS
                sSql = "select Top 1 dbo.FC_EcsDateByRtnVoyCntrStatus(Voy.ID , @CntrNo , 'FL' , 'F' ) as EcsDate " & _
                       "From TB_Voyage Voy , TB_OutwardBls  Bls where " & _
                       "Voy.ID = Bls.VoyageID and " & _
                       "bls.ID = @BLID"
                With Cmd
                    .CommandText = sSql
                    .CommandType = CommandType.Text
                    .Connection = Cnn
                    .Parameters.AddWithValue("@BLID", BLID)
                    .Parameters.AddWithValue("@CntrNo", CntrNo)
                End With
                DA.SelectCommand = Cmd
                DA.Fill(TB)

                If TB.Rows.Count = 0 Then
                    Excep = "Please Check ECS Data For Container " & CntrNo
                Else
                    If IsDBNull(TB.Rows(0).Item("EcsDate")) Then
                        Excep = "Please Check ECS Data For Container " & CntrNo
                    Else
                        mDateOf = TB.Rows(0).Item("EcsDate")
                    End If
                End If

            Case DetentionOutwardEndTime.OnboardDateOnBL
                sSql = "select Top 1 OnBoardDate " & _
                      "From TB_Voyage Voy , TB_OutwardBls Bls where " & _
                      "bls.ID = @BLID"
                With Cmd
                    .CommandText = sSql
                    .CommandType = CommandType.Text
                    .Connection = Cnn
                    .Parameters.AddWithValue("@BLID", BLID)
                End With
                DA.SelectCommand = Cmd
                DA.Fill(TB)

                If TB.Rows.Count = 0 Then
                    Excep = "Please Check OnBoradr Date in B/L Data "
                Else
                    If IsDBNull(TB.Rows(0).Item("OnBoardDate")) Then
                        Excep = "Please Check OnBoradr Date in B/L Data "
                    Else
                        mDateOf = TB.Rows(0).Item("OnBoardDate")
                    End If
                End If

        End Select

        If Excep = "" Then
            Return True
        Else
            Return False
        End If


    End Function
    ' For the case NEW REPORT CREATION REQUEST : "DETENTION OUTSTANDING SUMMARY"
    Public Function GetTaxDutyInwardDetentionOutStanding(ByVal CharegsCoed As String, Optional ByVal ForceByDate As Boolean = False) As Boolean

        Dim ArvlType As TaxDutyInward
        Dim Sql As String
        Dim lResult As Boolean = False
        Dim TB As New DataTable

        Dim Sof As TB_SOF
        'Me.DocumentID = DocID

        ArvlType = Byte.Parse(calculationBase.TaxDutyInward)

        If ForceByDate = True Then
            mDateOf = Now.Date
            lResult = True
            SetTaxDuty(CharegsCoed)
        Else

            If ArvlType = TaxDutyInward.BaseOnInvoiceGenearteTime Then
                mDateOf = Now.Date
                lResult = True
            Else
                Select Case ArvlType
                    Case TaxDutyInward.BaseOnArrivalTime
                        Sql = "Select Arrival From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                              "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                              DocumentID.ToString & "'"
                        TableBySql(Sql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If IsDBNull(TB.Rows(0).Item("Arrival")) Then
                                    lResult = False
                                    Excep = "No Found Arriavl Date , Please Check Voyage & SOF Data."
                                Else
                                    mDateOf = TB.Rows(0).Item(0)
                                    lResult = SetTaxDuty()
                                End If
                            Else
                                lResult = False
                                Excep = "No Found Arriavl Date , Please Check Voyage & SOF Data."
                            End If
                        End If
                    Case TaxDutyInward.BaseOnCompletedDischarge
                        Sql = "Select Sof.DschCmpl From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                              "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                              DocumentID.ToString & "'"
                        TableBySql(Sql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If IsDBNull(TB.Rows(0).Item("DschCmpl")) Then
                                    lResult = False
                                    Excep = "No Found Dischareg Completed Date , Please Check Voyage & SOF Data."
                                Else
                                    mDateOf = TB.Rows(0).Item("DschCmpl")
                                End If
                            Else
                                lResult = False
                                Excep = "No Found Dischareg Completed , Please Check Voyage & SOF Data."
                            End If
                        End If
                    Case TaxDutyInward.BaseOnBerth
                        Sql = "Select Sof.Berthed From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                              "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                              DocumentID.ToString & "'"
                        TableBySql(Sql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If IsDBNull(TB.Rows(0).Item("Berthed")) Then
                                    lResult = False
                                    Excep = "No Found Bearth Date , Please Check Voyage & SOF Data."
                                Else
                                    mDateOf = TB.Rows(0).Item("Berthed")
                                End If
                            Else
                                lResult = False
                                Excep = "No Found Bearth Date , Please Check Voyage & SOF Data."
                            End If
                        End If

                End Select
            End If

            If lResult = True Then
                SetTaxDuty(CharegsCoed)
            End If

        End If

        Return lResult

    End Function
    Public Function GetTaxDutyInward(ByVal DocID As Guid, ByVal CharegsCoed As String, Optional ByVal ForceByDate As Boolean = False) As Boolean

        Dim ArvlType As TaxDutyInward
        Dim Sql As String
        Dim lResult As Boolean = False
        Dim TB As New DataTable
        Dim TB1 As New DataTable
        Dim Sof As TB_SOF
        Me.DocumentID = DocID

        ArvlType = Byte.Parse(calculationBase.TaxDutyInward)

        If ForceByDate = True Then
            mDateOf = Now.Date
            lResult = True
            SetTaxDuty(CharegsCoed)
        Else

            If ArvlType = TaxDutyInward.BaseOnInvoiceGenearteTime Then
                ' to tak the detn tax based on invoice generate date for old cases
                If CharegsCoed = "DETN" Then
                    'Sql = "select IssueTime from TB_Invoice i where blid ='" & DocumentID.ToString & "' and EXISTS (select top 1 id from TB_InvoiceDetails where InvoiceID = i.ID and ChargesCode in ('DETN','DMCT')) "
                    Sql = "select IssueTime from TB_Invoice i where blid ='" & DocumentID.ToString & "' and EXISTS (select top 1 id from TB_InvoiceDetails where InvoiceID = i.ID and ChargesCode in ('DETN')) "
                    TableBySql(Sql, TB1, lResult)
                    If TB1.Rows.Count > 0 Then
                        mDateOf = TB1.Rows(0).Item("IssueTime")
                        lResult = True
                    Else
                        mDateOf = Now.Date
                        lResult = True
                    End If
                ElseIf CharegsCoed = "DMCT" Then
                    Sql = "select IssueTime from TB_Invoice i where blid ='" & DocumentID.ToString & "' and EXISTS (select top 1 id from TB_InvoiceDetails where InvoiceID = i.ID and ChargesCode in ('DMCT')) "
                    TableBySql(Sql, TB1, lResult)
                    If TB1.Rows.Count > 0 Then
                        mDateOf = TB1.Rows(0).Item("IssueTime")
                        lResult = True
                    Else
                        mDateOf = Now.Date
                        lResult = True
                    End If

                Else
                    mDateOf = Now.Date
                    lResult = True
                End If

            Else
                Select Case ArvlType
                    Case TaxDutyInward.BaseOnArrivalTime
                        Sql = "Select Arrival From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                              "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                              DocumentID.ToString & "'"
                        TableBySql(Sql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If IsDBNull(TB.Rows(0).Item("Arrival")) Then
                                    lResult = False
                                    Excep = "No Found Arriavl Date , Please Check Voyage & SOF Data."
                                Else
                                    mDateOf = TB.Rows(0).Item(0)
                                    lResult = SetTaxDuty()
                                End If
                            Else
                                lResult = False
                                Excep = "No Found Arriavl Date , Please Check Voyage & SOF Data."
                            End If
                        End If
                    Case TaxDutyInward.BaseOnCompletedDischarge
                        Sql = "Select Sof.DschCmpl From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                              "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                              DocumentID.ToString & "'"
                        TableBySql(Sql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If IsDBNull(TB.Rows(0).Item("DschCmpl")) Then
                                    lResult = False
                                    Excep = "No Found Dischareg Completed Date , Please Check Voyage & SOF Data."
                                Else
                                    mDateOf = TB.Rows(0).Item("DschCmpl")
                                End If
                            Else
                                lResult = False
                                Excep = "No Found Dischareg Completed , Please Check Voyage & SOF Data."
                            End If
                        End If
                    Case TaxDutyInward.BaseOnBerth
                        Sql = "Select Sof.Berthed From TB_InwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                              "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POD and BL.ID = '" & _
                              DocumentID.ToString & "'"
                        TableBySql(Sql, TB, lResult)
                        If lResult = True Then
                            If TB.Rows.Count > 0 Then
                                If IsDBNull(TB.Rows(0).Item("Berthed")) Then
                                    lResult = False
                                    Excep = "No Found Bearth Date , Please Check Voyage & SOF Data."
                                Else
                                    mDateOf = TB.Rows(0).Item("Berthed")
                                End If
                            Else
                                lResult = False
                                Excep = "No Found Bearth Date , Please Check Voyage & SOF Data."
                            End If
                        End If

                End Select
            End If

            If lResult = True Then
                SetTaxDuty(CharegsCoed)
            End If

        End If

        Return lResult

    End Function

    Public Function GetTaxDutyOutward(ByVal DocID As Guid, ByVal ChargesCode As String) As Boolean

        Dim SailedType As TaxDutyOutward
        Dim Sql As String
        Dim lResult As Boolean = False
        Dim TB As New DataTable
        DocumentID = DocID

        SailedType = Byte.Parse(calculationBase.TaxDutyOutward)

        If SailedType = TaxDutyOutward.InvoiceGenerateTime Then
            mDateOf = Now.Date
            lResult = True
        Else
            Select Case SailedType
                Case SailedType = TaxDutyOutward.VoyageDepartureTime
                    Sql = "Select Sailed From TB_OutwardBls BL , TB_Voyage VO , TB_SOF SOF Where " & _
                          "BL.VoyageID = VO.ID and VO.ID = SOF.VoyageID and SOF.Port = BL.POL and BL.ID = '" & _
                          DocumentID.ToString & "'"
                    TableBySql(Sql, TB, lResult)
                    If lResult = True Then
                        If TB.Rows.Count > 0 Then
                            If IsDBNull(TB.Rows(0).Item("Sailed")) Then
                                lResult = False
                                Excep = "No Found Sailed Date , Please Check Voyage & SOF Data."
                            Else
                                mDateOf = TB.Rows(0).Item("Sailed")
                            End If
                        Else
                            lResult = False
                            Excep = "No Found Sailed Date , Please Check Voyage & SOF Data."
                        End If
                    End If

            End Select
        End If
        If lResult = True Then
            SetTaxDuty(ChargesCode)
        End If
        Return lResult

    End Function

    Private Function SetTaxDuty() As Boolean

        Dim sSql As String
        Dim lResult As Boolean
        Dim TB As New DataTable

        sSql = "Select top 1 * From TB_TaxBase where '" & Format(DateOf, "yyyy-MM-dd") & "' between ApplyDate and Validity"
        TableBySql(sSql, TB, lResult)

        If lResult = True Then
            If TB.Rows.Count > 0 Then
                lResult = True
            Else
                lResult = False
            End If
        End If

        If lResult = False Then
            TaxRate = 0
            DutyRate = 0
            Excep = "No Found Valid Tax: " & Format(DateOf.Date, "dd/MM/yyyy") & " ,Please Check Tax Base Data. "
        Else
            TaxRate = TB.Rows(0).Item("Tax")
            DutyRate = TB.Rows(0).Item("Toll")
        End If

        Return lResult

    End Function

    Private Function SetTaxDuty(ByVal ChargesCode As String) As Boolean


        Dim lResult As Boolean
        Dim TB As New DataTable
        Dim DA As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)


        With Cmd
            .CommandText = "SP_GetTaxDutyByChargeCode"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@date", DateOf)
            .Parameters.AddWithValue("@ChargesCode", ChargesCode)
        End With

        DA.SelectCommand = Cmd
        DA.Fill(TB)


        If TB.Rows.Count > 0 Then
            lResult = True
        Else
            lResult = False
        End If


        If lResult = False Then
            TaxRate = 0
            DutyRate = 0
            Excep = "No Found Valid Tax: " & Format(DateOf.Date, "dd/MM/yyyy") & " ,Please Check Tax Base Data. "
        Else
            TaxRate = TB.Rows(0).Item("Tax")
            DutyRate = TB.Rows(0).Item("Toll")
        End If

        Return lResult

    End Function

    Private Function SetExchange() As Boolean

        Dim sSql As String
        Dim lResult As Boolean
        Dim TB As New DataTable

        sSql = "Select * From TB_Exchange EX , TB_ExchangeDetails EXD  where EX.ID = EXD.MasterID and CurCode = '" & Currency & "' and ExchangeDate = '" & Format(DateOf, "yyyy-MM-dd") & "'"
        TableBySql(sSql, TB, lResult)
        If lResult = True Then
            If TB.Rows.Count > 0 Then
                lResult = True
            Else
                lResult = False
            End If
        End If

        If lResult = False Then
            ExchgFrt = -1
            ExchgThc = -1
            ExchgDETN = -1
            Excep = "No Found Valid Exchange Rate: " & Format(DateOf.Date, "dd-MM-yyyy") & " ,Please Check Exchange Rate Screen "
        Else
            ExchgThc = TB.Rows(0).Item("THCRate")
            ExchgFrt = TB.Rows(0).Item("FrtRate")
            ExchgDETN = TB.Rows(0).Item("DETNRate")
        End If

        Return lResult

    End Function

    Public Function GetTaxDutyDyDate(CalDate As Date) As Boolean

        mDateOf = CalDate
        SetTaxDuty()
        Return True


    End Function
    Public Function GetTaxDutyDyDate(ByVal CalDate As Date, ByVal ChargesCode As String) As Boolean

        mDateOf = CalDate
        SetTaxDuty(ChargesCode)
        Return True


    End Function


    Public ReadOnly Property GetException() As String
        Get
            Return Excep
        End Get
    End Property

    Public ReadOnly Property Tax() As Double
        Get
            Return TaxRate
        End Get
    End Property

    Public ReadOnly Property Duty() As Double
        Get
            Return DutyRate
        End Get
    End Property

    Public ReadOnly Property DateOf As Date
        Get
            Return mDateOf
        End Get
    End Property


End Class
