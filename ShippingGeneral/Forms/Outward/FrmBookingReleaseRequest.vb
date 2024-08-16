Imports OrmLib
Imports ShippingBiz
Imports System.Text
Imports System.Data.SqlClient
Public Class FrmBookingReleaseRequest

    Private DM As DataManager
    Private BookingID As Guid
    Private ReleaseID As Guid
    Private TB As DataTable
    Private Sub FrmBookingReleaseRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn

        TB = New DataTable("Cntrs")
        TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("CnType", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("CnSize", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("NoOfCntrs", System.Type.GetType("System.Int16")))

        Me.GridRelease.DataSource = TB

        With Me.DropDownSize
            .DataSource = GetCodeList("CS")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.DropDownType
            .DataSource = GetCodeList("CT")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.GridRelease.DisplayLayout.Bands(0)
            .Columns("CnType").Style _
                               = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CnType").ValueList = Me.DropDownType

            .Columns("CnSize").Style _
                                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CnSize").ValueList = Me.DropDownSize
            .Columns("ID").Hidden = True
        End With

    End Sub

    Public Sub New(ByVal BookingID As Guid)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.BookingID = BookingID

    End Sub

    Private Sub SetDocument()

        Dim Rls As TB_BookingRelease
        Dim RlsCns As TB_BookingReleasCntrsCollection
        Dim DR As DataRow
        Dim NewDr As DataRow

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_BookingRelease.Columns.BookingID, BookingID, MatchType.Exact)
        Rls = DM.GetTB_BookingRelease()

        If Not Rls Is Nothing Then
            Me.ReleaseID = Rls.ID
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_BookingReleasCntrs.Columns.ReleaseID, Rls.ID, MatchType.Exact)
            RlsCns = DM.GetTB_BookingReleasCntrsCollection
        End If

        For Each DR In DM.DataSet.Tables("TB_BookingReleasCntrs").Rows
            NewDr = TB.NewRow
            NewDr("ID") = DR("ID")
            NewDr("CnSize") = DR("CnSize")
            NewDr("CnType") = DR("CnType")
            NewDr("NoOfCntrs") = DR("NoOfCntrs")
            TB.Rows.Add(NewDr)
        Next

        With Me.GridRelease.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
        End With

    End Sub
    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        Dim NewRow As DataRow
        Dim ID As Guid = New Guid
        Dim Dr As DataRow

        Me.GridRelease.UpdateData()
        If Me.GridRelease.Rows.Count = 0 Then
            Exit Sub
        End If
        If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then

            DM = New DataManager(My.Settings.DSN)
            ID = Guid.NewGuid
            NewRow = DM.DataSet.Tables("TB_BookingRelease").NewRow
            NewRow("ID") = ID
            NewRow("BookingID") = BookingID
            NewRow("RequestTime") = Now
            DM.DataSet.Tables("TB_BookingRelease").Rows.Add(NewRow)

            For Each Dr In TB.Rows
                NewRow = DM.DataSet.Tables("TB_BookingReleasCntrs").NewRow
                NewRow("ReleaseID") = ID
                NewRow("CnType") = Dr("CnType")
                NewRow("CnSize") = Dr("CnSIze")
                NewRow("NoOfCntrs") = Dr("NoOfCntrs")
                DM.DataSet.Tables("TB_BookingReleasCntrs").Rows.Add(NewRow)
            Next
            Try
                DM.CommitAll()
                MsgBoxSaveSuccessful()
                Generatemail(ID)
            Catch ex As Exception
                MsgBoxSaveFailed()
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Generatemail(ByVal ReqID As Guid)

        Dim SB As New StringBuilder("")
        Dim Cmd As New SqlCommand("SP_SendHtmMail")
        Dim cnn As New SqlConnection(My.Settings.DSN)

        Dim Dr As DataRow

        Dim Bk As TB_Booking
        Dim Req As TB_BookingRelease
        Dim Cns As TB_BookingReleasCntrsCollection
        Dim Cn As TB_BookingReleasCntrs
        Dim Client As TB_Clients
        Dim User As TB_Users
        Dim ClntMail As String

        Dim TB As New DataTable
        Dim sSql As String
        Dim lResult As Boolean
        Dim sDummy As String = ""

        Dim sTo As String
        Dim sCc As String
        Dim sBcc As String


        SB.Append("<html> ")
        SB.Append("<style type='text/css'>")
        SB.Append("<!--")
        SB.Append(".MyStyle {")
        SB.Append("Font(-family) : Verdana, Arial, Helvetica, sans - serif")
        SB.Append("}")
        SB.Append("-->")
        SB.Append("</style>")
        SB.Append("<body>")
        SB.Append("<p class='MyStyle'>DEAR STAFF</p>")
        SB.Append("<p class='MyStyle'>PLEASE ISSUE CONTAINER RELEASING ORDER TO @Shipper WITH BELOW DETAILS:</p>")
        SB.Append("<table width='589' border='1'>")
        SB.Append("<tr>")
        SB.Append("<td width='152'  class='MyStyle'>BOOKING NUMBER</td>")
        SB.Append("<td width='421' class='MyStyle'>@BN</td>")
        SB.Append("</tr>")
        SB.Append("<tr>")
        SB.Append("<td class='MyStyle'>P.O.D.</td>")
        SB.Append("<td class='MyStyle'>@POD</td>")
        SB.Append("</tr>")
        SB.Append("<tr>")
        SB.Append("<td class='MyStyle'>DEPOT</td>")
        SB.Append("<td class='MyStyle'>@Depot</td>")
        SB.Append("</tr>")

        SB.Append("<tr>")
        SB.Append("<td class='MyStyle'>NO OF CONTAINERS</td>")
        SB.Append("<td class='MyStyle'>@NoOfCntrs</td>")
        SB.Append("</tr>")
        SB.Append("<tr>")
        SB.Append("<td height='23' class='MyStyle'>REQUEST TIME</td>")
        SB.Append("<td class='MyStyle'>@Request</td>")
        SB.Append("</tr>")
        SB.Append("<tr>")
        SB.Append("<td height='23' class='MyStyle'>CLIENT REP</td>")
        SB.Append("<td class='MyStyle'>@Rep</td>")
        SB.Append("</tr>")
        SB.Append("<tr>")
        SB.Append("<td height='23' class='MyStyle'>REMARKS</td>")
        SB.Append("<td class='MyStyle'>@Rem</td>")
        SB.Append("</tr>")
        SB.Append("</table>")

        SB.Append("<p class='MyStyle'>WITH REGARDS</p>")
        SB.Append("<p class='MyStyle'>@SalesMan</p>")
        SB.Append("<p class='MyStyle'>&nbsp;</p>")
        SB.Append("<p>&nbsp;</p>")
        SB.Append("<p>&nbsp; </p>")
        SB.Append("<p>&nbsp;</p>")
        SB.Append("<p>&nbsp; </p>")
        SB.Append("</body>")
        SB.Append("</html>")

        DM = New DataManager(My.Settings.DSN)

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Booking.Columns.ID, BookingID, MatchType.Exact)

        Bk = DM.GetTB_Booking
        SB.Replace("@POD", UCase(GetPortNameByCode(Bk.POD)))
        SB.Replace("@BN", Bk.BookingNo)
        SB.Replace("@Depot", UCase(GetMeaningCode("DP", Bk.Depot)))
        SB.Replace("@Rem", UCase(Bk.Remarks))

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bk.ClientID, MatchType.Exact)
        Client = DM.GetTB_Clients
        SB.Replace("@Shipper", UCase(Client.lName))
        ClntMail = NullToValue(Client.Email, "")
        If ClntMail = "" Or Not ClntMail.Contains("@") Then
            MessageBox.Show("Email Failed! - Invalid Mail Id!")
            Exit Sub
        End If
        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bk.ClientRepID, MatchType.Exact)
        Client = DM.GetTB_Clients
        If Not Client Is Nothing Then
            SB.Replace("@Rep", UCase(Client.lName))
        End If

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_BookingRelease.Columns.ID, ReqID, MatchType.Exact)
        Req = DM.GetTB_BookingRelease
        SB.Replace("@Request", Req.RequestTime)

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_BookingReleasCntrs.Columns.ReleaseID, ReqID, MatchType.Exact)
        Cns = DM.GetTB_BookingReleasCntrsCollection
        For Each Cn In Cns
            If sDummy <> "" Then
                sDummy += " "
            End If
            sDummy += Cn.NoOfCntrs.ToString & "X" & Cn.CnSize & "' " & Cn.CnType
        Next

        SB.Replace("@NoOfCntrs", UCase(sDummy))

        Try
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Users.Columns.ID, Bk.SalesMan, MatchType.Exact)
            SB.Replace("@SalesMan", UCase(User.UserFirstName & " " & User.UserLastName))
            User = DM.GetTB_Users
        Catch ex As Exception

        End Try

        sSql = "Select * From TB_EventMail where Port = '" & Bk.POL & "' and EventCode = 'RO'"
        TableBySql(sSql, TB, lResult)

        If TB.Rows.Count = 0 Then
            MsgBox("Mail Generate Failed ! (No Recipiant)", MsgBoxStyle.Critical)
            Exit Sub
        End If

        sTo = ""
        sCc = ""
        sBcc = ""
        ExtractRecipiants(TB.Rows(0), Client, sTo, sCC, sBcc)

        With Cmd
            .CommandType = CommandType.StoredProcedure
            cnn.Open()
            .Connection = cnn
            .Parameters.AddWithValue("@Subject", "Container Releasing Order")
            .Parameters.AddWithValue("@TO", sTo) ' "h.shayan@parsseaharmony.com")
            .Parameters.AddWithValue("@CC", sCC) ' ClntMail & ";" & User.EmailOffice & ";")
            .Parameters.AddWithValue("@HTML", SB.ToString)
            .Parameters.AddWithValue("@Profile", "Automation")
        End With
        Cmd.ExecuteNonQuery()


    End Sub


End Class