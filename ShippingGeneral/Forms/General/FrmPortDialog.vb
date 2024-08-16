Imports ShippingBiz
Imports OrmLib
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars
Public Class FrmPortDialog

    Private Dm As DataManager
    Private Ports As TB_PortsCollection
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmPortDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.GridPorts
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
        End With
    End Sub

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles TopToolbars.ToolClick

        Dim t As TextBoxTool = Me.TopToolbars.Tools("TxtPortName")
        Select Case e.Tool.Key

            Case "Search"
                Dm = New DataManager(My.Settings.DSN)
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortName, t.Text, MatchType.Partial)
                Ports = Dm.GetTB_PortsCollection
                Me.DatasetForm.Tables("TB_Ports").Clear()
                Me.DatasetForm.Tables("TB_Ports").Merge(Dm.DataSet.Tables("TB_Ports"))
        End Select

    End Sub

End Class
