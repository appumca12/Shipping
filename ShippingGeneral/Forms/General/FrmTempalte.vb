Public Class FrmTempalte

  
    Private Sub FrmTempalte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MdiParent = FrmPMain
        Me.Top = 1
        Me.Left = 1
    End Sub

    Private Sub ToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Select Case e.Tool.Key
            Case "Find"

            Case "New"

            Case "Save"

            Case "Delete"

            Case "Close"
                Me.Close()
            Case "Edit"
        End Select

    End Sub
End Class