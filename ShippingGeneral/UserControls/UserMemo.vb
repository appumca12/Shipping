Public Class UserMemo

    Public Event CustomTextChanged()
    Private lChange As Boolean

    Public Property TextValue()

        Get
            Return GeneralText.Text
        End Get

        Set(ByVal value)
            GeneralText.Text = value
            lChange = False
        End Set

    End Property
    Public Sub SetLength(ByVal nLength As Byte)
        GeneralText.MaxLength = nLength
    End Sub

    Public Sub New()
        InitializeComponent()
        GeneralText.MaxLength = 5000
        GeneralText.Appearance.BackColorDisabled = My.Settings.TextBackColor
        GeneralText.Appearance.ForeColorDisabled = My.Settings.TextForcolor

    End Sub

    Public Function Changed() As Boolean
        Return lChange
    End Function
    Private Sub GeneralText_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralText.Enter
        GeneralText.BackColor = My.Settings.EditTextBackColor
        GeneralText.ForeColor = My.Settings.EditTextForcolor
    End Sub

    Private Sub GeneralText_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralText.Leave
        GeneralText.BackColor = My.Settings.TextBackColor
        GeneralText.ForeColor = My.Settings.TextForcolor
    End Sub
    Private Sub GeneralText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralText.ValueChanged
        lChange = True
        RaiseEvent CustomTextChanged()
    End Sub

    Private Sub GeneralText_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GeneralText.KeyDown

        If e.KeyCode = Keys.Enter Then
            '         SendKeys.Send("{ENTER}")
        End If

    End Sub
End Class
