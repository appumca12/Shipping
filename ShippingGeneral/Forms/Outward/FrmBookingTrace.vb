Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient

Public Class FrmBookingTrace

    Private Dm As DataManager
    Private ItemLevel = "601"

    Private Sub FrmBookingTrace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Users As TB_UsersCollection
        Dim Tb As New DataTable
        Dim Dr As DataRow


        Me.Clients.InitControl()
        Dm = New DataManager(My.Settings.DSN)


        Me.Status.InitControl("BS", UserComboCode.ShowCoumn.Meaning)
        Me.Status.AddItemOutSide("(ALL)", "(ALL)", "(ALL)")
        Me.Status.Code = "(ALL)"

        Me.DateFrom.InitControl(False, False)
        Me.DateTo.InitControl(False, False)

        Dm.QueryCriteria.Clear()

        If CurrentUser.IsSalesAdmin = True Or CurrentUser.BookingViewer = True Then
            Users = Dm.GetTB_UsersCollection()
            Tb = Dm.DataSet.Tables("TB_Users").Copy
            Dr = Tb.NewRow
            Dr("ID") = Guid.NewGuid
            Dr("password") = "***"
            Dr("UserFirstName") = "(ALL)"
            Dr("UserLastName") = "(ALL)"
            Dr("UserAccount") = "(ALL)"
            Dr("UserCode") = "**"
            Tb.Rows.Add(Dr)
        Else
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Users.Columns.ID, CurrentUser.ID, MatchType.Exact)
            Dm.GetTB_Users()
            Tb = Dm.DataSet.Tables("TB_Users").Copy
            Me.SalesMan.ComboGnrl.Enabled = False
        End If

        Me.SalesMan.CustomDatasource = Tb
        Me.SalesMan.CustomValueMember = "ID"
        Me.SalesMan.CustomDisplayMember = "UserAccount"
        Me.TopMenu.MenuItemsSetupOutSide(ItemLevel)
        Dm = New DataManager(My.Settings.DSN)
        Me.TopMenu.CustomSetAdditonalItem("Release Letter")
        TopMenu.ShowAdditional = True

        Me.DateFrom.GnrlDate.Value = DateAdd(DateInterval.Day, -20, Now)
        Me.DateTo.GnrlDate.Value = Now
     


    End Sub

    Private Sub TopMenu_CustomAdditional() Handles TopMenu.CustomAdditional

        Dim frm As FrmBookingReleaseRequest

       
        If UCase(Me.GridBooking.ActiveRow.Cells("Status").Text) = "C" Then
            frm = New FrmBookingReleaseRequest(Me.GridBooking.ActiveRow.Cells("ID").Value)
            frm.Show()
        Else
            MsgBoxGeneral("This booking status in confirm !", "Faild")
        End If



    End Sub

    Private Sub TopMenu_CustomCancelClick() Handles TopMenu.CustomCancelClick

        If Me.GridBooking.Rows.Count = 0 Then
            Exit Sub
        End If

        If UCase(Me.GridBooking.ActiveRow.Cells("Status").Text) = "R" Or CurrentUser.IsSalesAdmin = True Then
            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                ChangeBookingStatus("A")
            End If
        Else
            MsgBoxGeneral("You have no permission to delete this booking", "Faild")
        End If

    End Sub

    Private Sub TopMenu_CustomConfirmClick() Handles TopMenu.CustomConfirmClick

        If Me.GridBooking.Rows.Count = 0 Then
            Exit Sub
        End If

        If UCase(Me.GridBooking.ActiveRow.Cells("Status").Text) = "R" Then
            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                ChangeBookingStatus("C")
            End If
        Else
            MsgBoxGeneral("This booking status in not request !", "Faild")
        End If

    End Sub

    Private Sub TopMenu_CustomDeleteClick() Handles TopMenu.CustomDeleteClick


        If Me.GridBooking.Rows.Count = 0 Then
            Exit Sub
        End If

        If UCase(Me.GridBooking.ActiveRow.Cells("Status").Text) = "R" Or CurrentUser.IsSalesAdmin = True Then
            If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                ChangeBookingStatus("D")
            End If
        Else
            MsgBoxGeneral("You have no permission to delete this booking !", "Faild")
        End If

    End Sub

    Private Sub TopMenu_CustomPrintClick() Handles TopMenu.CustomPrintClick

        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Frm As FrmGeneralReportShow
        Dim subreportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject
        Dim SUBA As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim subreportName As String
        Dim PH As New CLPrintHdr
        Dim Usr As TB_Users
        Dim Ans As Boolean
        Dim Ds As DataSet
        Dim Mstr As DataTable
        Dim Detl As DataTable

        If Me.GridBooking.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim ID As String
        ID = Me.GridBooking.ActiveRow.Cells("ID").Value.ToString

        Ds = New DataSet
        Ds = StoredProcedures.SP_GetBookingViewByID(ID)
        Mstr = Ds.Tables(0)
        Mstr.Rows(0).Item("Terms") = IIf(Mstr.Rows(0).Item("Terms").ToString = "C", "COLLECT", "PREPAID")


        Ds = New DataSet
        Ds = StoredProcedures.SP_GetBookingDetailViewByBookingID(Mstr.Rows(0).Item("id").ToString)
        Detl = Ds.Tables(0)


        'Dm.QueryCriteria.Clear()
        'Dm.QueryCriteria.And(JoinPath.TB_Users.Columns.ID, Mstr.Rows(0).Item("SalesMan"), MatchType.Exact)
        'Usr = Dm.GetTB_Users

        'Ans = RetriveObject("Booking", "c:\Booking.rpt")
        'If Ans = True Then
        '    Report.Load("c:\Booking.rpt")
        'Else
        '    Report = New RptBooking
        'End If

        Report = New RptBooking
        'Try
        '    Report.Subreports("RptFooter.rpt").SetDataSource(GetReportFooterData)
        'Catch ex As Exception
        'End Try

        Frm = New FrmGeneralReportShow
        '     Report.Subreports("RptHedaerLogo.rpt").SetDataSource(PH.ImageTable)

        Report.SetDataSource(Mstr)

        If Detl.Rows.Count > 0 Then
            Report.SetParameterValue(0, Detl.Rows(0).Item("TotalCntrs"))
            Report.SetParameterValue(1, Detl.Rows(0).Item("CnSize") + "'")
            Report.SetParameterValue(2, Detl.Rows(0).Item("CnType"))
        Else
            Report.SetParameterValue(0, "")
            Report.SetParameterValue(1, "")
            Report.SetParameterValue(2, "")
        End If
        Frm.ReportViewer.ReportSource = Report
        Frm.Show()

    End Sub

    Private Sub TopMenu_CustomProcess() Handles TopMenu.CustomProcess

        Dim EDI As New EDICls
        EDI.GenerateBooking(EType.TextType, Me.GridBooking)

    End Sub

    Private Sub TopMenu_CustomRefreshClick() Handles TopMenu.CustomRefreshClick

        Dim Clnt As String
        Dim Status As String
        Dim Sales As String
        Dim ds As DataSet
        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim sSql As String = ""
        Dim Crt As String = ""
        Dim TB As DataTable
        Dim lResult As Boolean
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        If Me.Clients.Text = "" Or Me.Clients.Text = "(ALL)" Then
            Clnt = ""
        Else
            Clnt = Me.Clients.ClientID.ToString
        End If
        'Clnt = IIf(Me.Clients.CmbClients.Text = "" Or Me.Clients.CmbClients.Text = "(ALL)", "", Me.Clients.ClientID.ToString)
        Status = IIf(Me.Status.ComboCode.Text = "(ALL)" Or Me.Status.ComboCode.Text = "", "", Me.Status.Code.ToString)
        Sales = IIf(Me.SalesMan.ComboGnrl.Text = "(ALL)" Or Me.SalesMan.ComboGnrl.Text = "", "", Me.SalesMan.CustomValue.ToString)

        'If Clnt <> "" Then
        '    Crt += IIf(Crt = "", "", " and ") & " ClientID = '" & Clnt & "'"
        'End If

        'If Status <> "" Then
        '    Crt += IIf(Crt = "", "", " and ") & " Status = '" & Status & "'"
        'End If

        'If Sales <> "" Then
        '    Crt += IIf(Crt = "", "", " and ") & " SalesMan = '" & Sales & "'"
        'End If
        'Crt += IIf(Crt = "", "", " and ") & " (BookingDate Between @dFrom and " & " @dTo )"

        'sSql = "SELECT  ID, BookingNo, BookingDate, Line, dbo.FC_GetClientNameWithClntID(ClientID) AS Client, dbo.FC_GetClientNameWithClntID(ClientRepID) AS ClientRep, " & _
        '"Validity, dbo.FC_PortNamebyCode(POL) AS POL, POLFreeDays, dbo.FC_PortNamebyCode(POD) AS POD, PODFreeDays,  " & _
        '"dbo.FC_PortNamebyCode(POT) AS POT, dbo.FC_PortNamebyCode(FPOD) AS FPOD, Goods,   PrincipalReference, PrincipalConfirm, " & _
        '"dbo.FC_UserNameByID(SalesMan) AS [Sales Person],  Remarks, ClientID, ClientRepID, SalesMan, " & _
        '"dbo.FC_GetMeaningWithGroupStdCode('BS', Status) AS BookingStatus , Status " & _
        '"FROM dbo.TB_Booking " & IIf(Crt = "", "", "Where " & Crt)

        Cnn.Open()

        With Cmd
            .CommandText = "SP_BookingTrace"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.Add(New SqlParameter("@dFrom", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@dTo", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@ClientID", SqlDbType.Char, 36))
            .Parameters.Add(New SqlParameter("@SalesMan", SqlDbType.Char, 36))
            .Parameters.Add(New SqlParameter("@Status", SqlDbType.VarChar, 10))
            .Parameters("@dFrom").Value = Format(Date.Parse(Me.DateFrom.DateValue).Date, "yyyy/MM/dd")
            .Parameters("@dTo").Value = Format(Date.Parse(Me.DateTo.DateValue).Date, "yyyy/MM/dd")
            .Parameters("@ClientID").Value = Clnt
            .Parameters("@SalesMan").Value = Sales
            .Parameters("@Status").Value = Status


        End With

        DA.SelectCommand = Cmd
        TB = New DataTable("Search")
        DA.Fill(TB)

        Me.GridBooking.DataSource = TB

        For Each Col In Me.GridBooking.DisplayLayout.Bands(0).Columns
            If Col.DataType.ToString = "System.Guid" Then
                Col.Hidden = True
            End If
        Next

        Me.GridAssignCntrs.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None
        Me.GridBooking.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None
        Me.GridBooking.DisplayLayout.Bands(0).Columns("Status").Hidden = True

    End Sub

    Private Sub ChangeBookingStatus(ByVal Status As String)

        Dim Bk As TB_Booking
        Dim LogDataSet As New DataSet
        Dim ID As Guid = Me.GridBooking.ActiveRow.Cells("ID").Value
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Booking.Columns.ID, ID, MatchType.Exact)
        Bk = Dm.GetTB_Booking
        If Not Bk Is Nothing Then
            If Status = "D" Then
                Bk.Delete()
            Else
                Bk.Status = Status
            End If
            Try
                LogDataSet = Dm.DataSet.Copy
                Dm.CommitAll()
                GenerateLog(LogDataSet)
                If Status = "D" Then
                    MsgBoxDeleteSuccessful()
                Else
                    MsgBoxSaveSuccessful()
                End If

            Catch ex As Exception
                If Status = "D" Then
                    MsgBoxDeleteFailed()
                Else
                    MsgBoxSaveFailed()
                End If
            End Try
        End If

    End Sub

    Private Sub GridBooking_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridBooking.AfterRowActivate

        Dim ID As String
        Dim Ds As DataSet
        Dim aMster As DataColumn
        Dim aDetail As DataColumn
        Dim RL As DataRelation

        Try
            ID = Me.GridBooking.ActiveRow.Cells("ID").Value.ToString
            Me.GridAssignCntrs.DataSource = Nothing
            Ds = StoredProcedures.SP_AssignedBookingCntrs(ID)
            If Ds.Tables.Count <> 0 Then
                Me.GridAssignCntrs.DataSource = Ds.Tables(0)
                Ds.Tables(0).TableName = "Master"
                Ds.Tables.Remove("Master")
                'Ds.Tables(2).TableName = "Detail"
                'DsReleas.Tables.Add(Ds.Tables(1).Clone)
                'DsReleas.Tables.Add(Ds.Tables(2).Clone)
                'For Each Dr In Ds.Tables(1).Rows
                '    DsReleas.Tables(0).ImportRow(Dr)
                'Next

                'For Each Dr In Ds.Tables(2).Rows
                '    DsReleas.Tables(1).ImportRow(Dr)
                'Next
                aMster = Ds.Tables(0).Columns("ID")
                aDetail = Ds.Tables(1).Columns("ReleaseID")
                RL = New DataRelation("Me", aMster, aDetail)
                Ds.Relations.Add(RL)
                Me.GridReleaseLetter.DataSource = Ds 'Releas ' Ds.Tables(1)
            End If
        Catch ex As Exception
        End Try
 
        GridNumSeperator(Me.GridReleaseLetter)


    End Sub

    Private Sub TopMenu_CustomToExcelClick() Handles TopMenu.CustomToExcelClick

        SaveGridToExcel(Me.GridBooking)


    End Sub
End Class