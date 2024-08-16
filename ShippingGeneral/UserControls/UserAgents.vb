Imports ShippingBiz
Imports OrmLib
Imports System.Data.SqlClient
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.Misc
Imports System.Text
Public Class UserAgents

    Inherits ComboBox
    Private Table As DataTable
    Private lShowAll As Boolean
    Private ToolTipMngr As New UltraToolTipManager

    Public Sub InitControl()

        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Cmd As SqlCommand
        Dim Sql = "exec SP_ClientsListCombo"
        Dim Adptr As New SqlDataAdapter
        Table = New DataTable

        Try
            Cnn.Open()
            Cmd = New SqlCommand(Sql, Cnn)
            Adptr = New SqlDataAdapter(Cmd)
            Adptr.Fill(Table)
            Me.DisplayMember = "LName"
            Me.ValueMember = "ID"
            Me.DataSource = Table
            Me.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
            Me.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
        Catch ex As Exception
            MsgBox("Error On Reander Data !")
            MsgBox(ex.ToString)
        Finally
            Cnn.Close()
        End Try

    End Sub

    Public Property CustomShowALL() As Boolean
        Get
            Return lShowAll
        End Get
        Set(ByVal value As Boolean)
            lShowAll = value
        End Set
    End Property

    Public Property ClientID() As Guid
        Get
            Return SelectedValue
        End Get
        Set(ByVal value As Guid)
            Me.SelectedValue = value
        End Set
    End Property

    Public ReadOnly Property ClientName() As String
        Get
            Return Text
        End Get
    End Property
    Private Sub UserAgents_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        BackColor = My.Settings.EditTextBackColor
        ForeColor = My.Settings.EditTextForcolor
    End Sub

    Private Sub UserAgents_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub UserAgents_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        BackColor = My.Settings.TextBackColor
        ForeColor = My.Settings.TextForcolor
    End Sub

    Private Sub SetToolTip()

        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Cmd As SqlCommand
        Dim Sql = "Select * From Tb_Clients Where ID = '" & ClientID.ToString & "'"
        Dim Adptr As New SqlDataAdapter
        Table = New DataTable

        Try
            Cnn.Open()
            Cmd = New SqlCommand(Sql, Cnn)
            Adptr = New SqlDataAdapter(Cmd)
            Adptr.Fill(Table)

            Dim toolTipInfo As UltraToolTipInfo = ToolTipMngr.GetUltraToolTip(Me)
            Dim sb As StringBuilder = New StringBuilder()

            toolTipInfo.ToolTipTitle = "Client Code"

            If Me.Text <> "" Then
                sb.Append("Client Code: " & Table.Rows(0).Item("ClientCode"))
            End If
            toolTipInfo.ToolTipText = sb.ToString()
        Catch ex As Exception
            MsgBox("Error On Find ClientCode !")
            MsgBox(ex.ToString)
        Finally
            Cnn.Close()
        End Try
    End Sub

    Private Sub UserAgents_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        SetToolTip()
    End Sub
End Class
