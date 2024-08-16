Imports System.Windows.Forms
Imports OrmLib
Imports ShippingBiz

Public Class FrmClientDialog
    Private Clients As TB_ClientsCollection
    Private Dm As DataManager
    Private UClient As UserClientText
    Private UObjValue As Object
    Private UObjName As Object

    Private Sub ToolbarManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarManager.ToolClick


        Dim t As Infragistics.Win.UltraWinToolbars.TextBoxTool = Me.ToolbarManager.Tools("TxtClientSrch")
        Select Case e.Tool.Key
            Case "GoSearch"
                Dim Dm As New DataManager(My.Settings.DSN)
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.lName, t.Text, MatchType.Partial)
                Clients = Dm.GetTB_ClientsCollection
                Me.DataSetForm.Tables("TB_Clients").Clear()
                Me.DataSetForm.Tables("TB_Clients").Merge(Dm.DataSet.Tables("TB_Clients"))
            Case "By Code"
                Dim Dm As New DataManager(My.Settings.DSN)
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ClientCode, t.Text, MatchType.Partial)
                Clients = Dm.GetTB_ClientsCollection
                Me.DataSetForm.Tables("TB_Clients").Clear()
                Me.DataSetForm.Tables("TB_Clients").Merge(Dm.DataSet.Tables("TB_Clients"))
            Case "Select"
                If Me.GridClients.Rows.Count > 0 Then
                    If UClient Is Nothing Then
                        UObjValue.value = Me.GridClients.ActiveRow.Cells("ID").Value
                        UObjName.value = Me.GridClients.ActiveRow.Cells("lName").Text
                        Me.Close()
                    Else
                        UClient.ClientID = Me.GridClients.ActiveRow.Cells("ID").Value
                        UClient.ClientName = Me.GridClients.ActiveRow.Cells("lName").Text
                        Me.Close()
                    End If
                End If
        End Select


    End Sub

    Private Sub FrmClientDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Me.GridClients.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
        End With

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.ToolbarManager.Tools.Item("Select").SharedProps.Visible = False
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByRef Ctrl As UserClientText)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.UClient = Ctrl
        Me.ToolbarManager.Tools.Item("Select").SharedProps.Visible = True

    End Sub
    Public Sub New(ByRef ObjAsValue As Object, ByRef ObjAsName As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.UObjValue = ObjAsValue
        Me.UObjName = ObjAsName
        Me.ToolbarManager.Tools.Item("Select").SharedProps.Visible = True

    End Sub

End Class
