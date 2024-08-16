Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.Misc
Imports System.Text


Public Class UserClientText
    Private Table As DataTable
    Private lShowAll As Boolean
    Private ID As Guid
    Private clnt As TB_Clients
    Private Dm As DataManager
    Private ToolTipMngr As New UltraToolTipManager

    Public Property ClientID() As Guid
        Get
            Return ID
        End Get
        Set(ByVal value As Guid)
            ID = value
            SetDocument(ID)
        End Set
    End Property
    Public Property AgentID() As Guid
        Get
            Return ID
        End Get
        Set(ByVal value As Guid)
            ID = value
            SetDocument(ID)
        End Set
    End Property
    Public Property ClientName() As String
        Get
            Return Me.UserClients.Text
        End Get
        Set(ByVal value As String)
            Me.UserClients.Text = value
        End Set
    End Property
    Private Sub UserClients_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter, UserClients.Enter
        Me.UserClients.Appearance.BackColor = My.Settings.EditTextBackColor
        Me.UserClients.Appearance.ForeColor = My.Settings.EditTextForcolor
    End Sub

    Private Sub UserClients_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus, UserClients.Leave
        Me.UserClients.Appearance.BackColor = My.Settings.TextBackColor
        Me.UserClients.Appearance.ForeColor = My.Settings.TextForcolor
    End Sub

    Private Sub ButtonSrch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSrch.Click
        Dim Frm As New FrmClientDialog(Me)
        Frm.ShowDialog()
    End Sub
    Public Sub SetDocument(ByVal ClntID As Guid)
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, ID, MatchType.Exact)
        clnt = Dm.GetTB_Clients()
        ID = ClntID
        If clnt Is Nothing Then
            ClntID = Guid.Empty
            Me.UserClients.Text = ""
        Else
            ClntID = clnt.ID
            Me.UserClients.Text = clnt.lName
        End If
        SetToolTip()

    End Sub
    Public Sub InitControl(ByVal CLr As Color)

        Me.BackColor = CLr
    End Sub

    Private Sub SetToolTip()

      
        Try
    
            Dim toolTipInfo As UltraToolTipInfo = ToolTipMngr.GetUltraToolTip(Me.UserClients)
            Dim sb As StringBuilder = New StringBuilder()

            toolTipInfo.ToolTipTitle = "Details"

            If Me.UserClients.Text <> "" Then
                sb.Append("Client/Agent : " & clnt.lName)
                sb.Append(Environment.NewLine)
                sb.Append("Address: " & clnt.lAddress)
                sb.Append(Environment.NewLine)
                sb.Append("City: " & clnt.City)
                sb.Append(Environment.NewLine)
                sb.Append("Country: " & clnt.Country)
                sb.Append(Environment.NewLine)
                sb.Append("TEL: " & clnt.TEL)
                sb.Append(Environment.NewLine)
                sb.Append("FAX: " & clnt.Fax)
                sb.Append(Environment.NewLine)
                sb.Append("Mobile: " & clnt.Mobile)
                sb.Append(Environment.NewLine)


            End If
            toolTipInfo.ToolTipText = sb.ToString()
        Catch ex As Exception
            MsgBox("Error On Find ClientCode !")
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub

End Class
