Imports System.Windows.Forms
Imports OrmLib
Imports ShippingBiz

Public Class FrmChangeLineDialog

    Private Codes As TB_LinesCollection
    Private code As TB_Lines
    Private Dm As DataManager
    Private TB As DataTable
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        CurrentShippingLine = Me.LineCode.Text
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        If CurrentShippingLine = "" Then
            MsgBox("Please Select A Line !")
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmChangeLineDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 
        Me.BackColor = Me.UltraTabStripControl1.Appearance.BackColor

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.Clear()
        Codes = Dm.GetTB_LinesCollection()
        TB = Dm.DataSet.Tables("TB_Lines").Copy
 
        If TB.Rows.Count > 1 Then

            With Me.UltraTabStripControl1

                .TabKeyMember = "LineCode"
                .ToolTipTextMember = "LineCode"
                .SetDataBinding(TB, "")
                Try
                    .Tabs(CurrentShippingLine).Selected = True
                Catch ex As Exception

                End Try
            End With
            Me.LineCode.DataBindings.Add("Text", TB, "LineCode")
            Me.LineName.DataBindings.Add("Text", TB, "LineName")
        Else
            CurrentShippingLine = TB.Rows(0).Item("LineCode")
            Me.Close()
        End If




    End Sub

End Class
