Imports System.Data.SqlClient
Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win.UltraWinToolbars
Imports Shipping.UserGeneralForms

Public Class UserRemarks

    Public Event CustomTextChanged()
    Public Event CustomKeyDown()
    Public Event CustomFindClick()
    Private lChange As Boolean
    Private IsAutoComplete As Boolean = False
    Private TBName As String
    Private ColName As String
    Private Cnn As SqlConnection
    Private Cmd As SqlCommand
    Private DA As SqlDataAdapter
    Private TB As DataTable
    Private ExtraWhere As String
    Private sSql As String
    Dim Frm As New FrmGeneralSearch(FrmGeneralSearch.InwardOutward.InWard)
    'For ILS Shortcuts  
    'Private Sub GeneralText_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GeneralText.KeyPress
    '    If e.KeyChar = Convert.ToChar(13) Then
    '        Dim userGeneralForms As New Shipping.UserGeneralForms
    '        Dim toolClickEventArgs As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs
    '        Dim systemEventArgs As System.EventArgs
    '        'userGeneralForms.findClickEnter(sender, toolClickEventArgs)
    '        userGeneralForms.Toolbar_ToolClick(sender, toolClickEventArgs)
    '        userGeneralForms.ButtonPickupClientMergeText_Click(sender, systemEventArgs)
    '    End If
    'End Sub
    Public Property TextValue() As String

        Get
            Return StripControlChars(GeneralLabel.Text, False)
        End Get

        Set(ByVal value As String)
            If value Is Nothing Then
                GeneralLabel.Text = ""
            Else
                GeneralLabel.Text = value
            End If
            lChange = False
        End Set

    End Property

    Private Sub GeneralText_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
        '    '          SendKeys.Send("{TAB}")
        '    RaiseEvent CustomTextKeyPress()
        'End If
        lChange = True
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            RaiseEvent CustomKeyDown()
        End If

    End Sub

    Private Sub GeneralText_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '       GeneralText.BackColor = My.Settings.TextBackColor
        '      GeneralText.ForeColor = My.Settings.TextForcolor
    End Sub

    Private Sub GeneralText_TextChanged1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lChange = True
        RaiseEvent CustomTextChanged()
    End Sub

    Public Sub SetLength(ByVal nLength As Byte)
        'GeneralLabel.MaxLength = nLength
    End Sub

    Public Sub New()
        InitializeComponent()
        'GeneralLabel.MaxLength = 20
        Me.GeneralLabel.BackColor = My.Settings.TextBackColor
        Me.GeneralLabel.ForeColor = My.Settings.TextForcolor
    End Sub

    Public Function Changed() As Boolean
        Return lChange
    End Function

    Private Sub GeneralText_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GeneralLabel.BackColor = My.Settings.EditTextBackColor
        GeneralLabel.ForeColor = My.Settings.EditTextForcolor
    End Sub

    Private Sub GeneralText_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GeneralLabel.BackColor = My.Settings.TextBackColor
        GeneralLabel.ForeColor = My.Settings.TextForcolor

    End Sub

    Public Property GeneralLbl() As Label
        Get
            Return Me.GeneralLabel
        End Get
        Set(ByVal value As Label)
            Me.GeneralLabel = value
        End Set
    End Property

    'Public Property CustomMaxLength() As Byte
    '    Get
    '        Return Me.GeneralLabel.MaxLength
    '    End Get
    '    Set(ByVal value As Byte)
    '        Me.GeneralLabel.MaxLength = value
    '    End Set
    'End Property

    'Public Property Visible() As Boolean
    '    Get
    '        Visible = True
    '    End Get
    '    Set(ByVal value As Boolean)
    '        Visible = value
    '    End Set
    'End Property

    Public Property AutoCompleteTableName() As String
        Get
            Return TBName
        End Get
        Set(ByVal value As String)
            TBName = value
        End Set
    End Property

    Public Property AutoCompleteColumnName() As String
        Get
            Return ColName
        End Get
        Set(ByVal value As String)
            ColName = value
        End Set
    End Property

    Public Property AutoCompleteExtraWhere() As String
        Get
            Return ExtraWhere
        End Get
        Set(ByVal value As String)
            ExtraWhere = value
        End Set
    End Property

End Class
