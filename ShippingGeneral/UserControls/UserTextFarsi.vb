Public Class UserTextFarsi

    Private lChange As Boolean  
    Public Property TextValue()

        Get
            Return FarsiText.Text
        End Get

        Set(ByVal value)
            FarsiText.Text = value
            lChange = False
        End Set

    End Property
    Private Sub FarsiText_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FarsiText.GotFocus
        KeyboardLaguage(LangType.Persian)
        FarsiText.BackColor = My.Settings.EditTextBackColor
        FarsiText.ForeColor = My.Settings.EditTextForcolor
    End Sub
  
    Private Sub FarsiText_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FarsiText.LostFocus
        KeyboardLaguage(LangType.English)
        FarsiText.BackColor = My.Settings.TextBackColor
        FarsiText.ForeColor = My.Settings.TextForcolor
    End Sub
    Private Sub FarsiText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FarsiText.TextChanged
        lChange = True
    End Sub
    Public Sub SetLength(ByVal nLength As Int16)
        FarsiText.MaxLength = nLength
    End Sub
    Public Sub New()
        InitializeComponent()
        FarsiText.Font = My.Settings.FarsiFont
        FarsiText.MaxLength = 100
    End Sub
    Public Function Changed() As Boolean
        Return lChange
    End Function
    Public Property IsMultiline() As Boolean
        Get
            Return Me.FarsiText.Multiline
        End Get
        Set(ByVal value As Boolean)
            Me.FarsiText.Multiline = value
        End Set
    End Property

End Class
