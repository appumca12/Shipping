Imports OrmLib
Imports ShippingBiz
Public Class UserComboGnrl

    Public Event CustomValueChanged()
    Dim TB As New DataTable
    Private lValidCode As Boolean
    
    Private Sub ComboGnrl_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        ComboGnrl.BackColor = My.Settings.EditTextBackColor
        ComboGnrl.ForeColor = My.Settings.EditTextForcolor
    End Sub
    Private Sub ComboGnrl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            '         SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub ComboGnrl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ComboGnrl.BackColor = My.Settings.TextBackColor
        ComboGnrl.ForeColor = My.Settings.TextForcolor
    End Sub

    Public Sub AddOutSide(ByVal Obj As Object)

        ComboGnrl.DataSource = Obj
        Me.ComboGnrl.Refresh()
    End Sub

    Public Property CustomDisplayMember() As String
        Get
            Return Me.ComboGnrl.DisplayMember
        End Get
        Set(ByVal value As String)
            Me.ComboGnrl.DisplayMember = value
        End Set
    End Property
    Public Property CustomSelectedItem() As String
        Get
            Try
                Return Me.ComboGnrl.SelectedItem.item(0)
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)
            ComboGnrl.DataSource = value
        End Set
    End Property

    Public Property CustomValueMember() As String
        Get
            Return ComboGnrl.ValueMember
        End Get
        Set(ByVal value As String)
            ComboGnrl.ValueMember = value
        End Set
    End Property

    Public Property CustomDatasource() As Object
        Get
            Return ComboGnrl.DataSource
        End Get
        Set(ByVal value As Object)
            ComboGnrl.DataSource = value
        End Set
    End Property
    Public ReadOnly Property CustomValue() As String
        Get
            Try
                If ComboGnrl.Text <> "" Then
                    Return ComboGnrl.SelectedItem(ComboGnrl.ValueMember).ToString
                Else
                    Return ""
                End If

            Catch ex As Exception
                Return ""
            End Try
                 End Get
    End Property

    Public Property CustomData() As String
        Get
            Return Me.ComboGnrl.SelectedItem
        End Get
        Set(ByVal value As String)
            ComboGnrl.Text = value
        End Set
    End Property

    Private Sub ComboGnrl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboGnrl.SelectedIndexChanged

    End Sub
End Class

 