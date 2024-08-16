Imports System.Data.SqlClient
Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win.UltraWinToolbars
Imports Shipping.UserGeneralForms

Public Class UserText

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
    Private Sub GeneralText_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GeneralText.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Dim userGeneralForms As New Shipping.UserGeneralForms
            Dim toolClickEventArgs As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs
            Dim systemEventArgs As System.EventArgs
            'userGeneralForms.findClickEnter(sender, toolClickEventArgs)
            userGeneralForms.Toolbar_ToolClick(sender, toolClickEventArgs)
            userGeneralForms.ButtonPickupClientMergeText_Click(sender, systemEventArgs)
        End If
    End Sub
    Public Property TextValue() As String

        Get
            Return StripControlChars(GeneralText.Text, False)
        End Get

        Set(ByVal value As String)
            If value Is Nothing Then
                GeneralText.Text = ""
            Else
                GeneralText.Text = value
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
        GeneralText.MaxLength = nLength
    End Sub

    Public Sub New()
        InitializeComponent()
        GeneralText.MaxLength = 100
        Me.GeneralText.BackColor = My.Settings.TextBackColor
        Me.GeneralText.ForeColor = My.Settings.TextForcolor
    End Sub

    Public Function Changed() As Boolean
        Return lChange
    End Function

    Private Sub GeneralText_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GeneralText.BackColor = My.Settings.EditTextBackColor
        GeneralText.ForeColor = My.Settings.EditTextForcolor
    End Sub

    Private Sub GeneralText_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GeneralText.BackColor = My.Settings.TextBackColor
        GeneralText.ForeColor = My.Settings.TextForcolor

    End Sub

    Public Property GeneralTxt() As TextBox
        Get
            Return Me.GeneralText
        End Get
        Set(ByVal value As TextBox)
            Me.GeneralText = value
        End Set
    End Property

    Public Property CustomMaxLength() As Byte
        Get
            Return Me.GeneralText.MaxLength
        End Get
        Set(ByVal value As Byte)
            Me.GeneralText.MaxLength = value
        End Set
    End Property

    Public Property AutoComplete() As Boolean
        Get
            IsAutoComplete = True
        End Get
        Set(ByVal value As Boolean)
            IsAutoComplete = value
        End Set
    End Property

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
   
    Private Sub GeneralText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralText.TextChanged

        Dim Dummy As String
        Dim Dr As DataRow

        If IsAutoComplete = True Then
            TB = New DataTable
            DA = New SqlDataAdapter
            If Cnn Is Nothing Then
                Cnn = New SqlConnection(My.Settings.DSN)
            End If

            If Cnn.State = ConnectionState.Closed Then
                Cnn.Open()
            End If

            Dummy = Me.TextValue
            Dummy = Replace(Dummy, "%", "")
            Dummy = Replace(Dummy, "'", "")

            If ExtraWhere <> "" Then
                sSql = "Select top 7 " & ColName & " From " & TBName & " Where " & ExtraWhere & " and " & ColName & " Like '" & Dummy & "%'"
            Else
                sSql = "Select top 7 " & ColName & " From " & TBName & " Where " & ColName & " Like '" & Dummy & "%'"
            End If

            If Cmd Is Nothing Then
                Cmd = New SqlCommand(sSql)
                Cmd.Connection = Cnn
                Cmd.CommandType = CommandType.Text
            Else
                Cmd.CommandText = sSql
            End If

            TB = New DataTable
            DA.SelectCommand = Cmd
            DA.Fill(TB)

            GeneralTxt.AutoCompleteCustomSource.Clear()
            GeneralTxt.AutoCompleteMode = AutoCompleteMode.Suggest
            GeneralTxt.AutoCompleteSource = AutoCompleteSource.CustomSource
            For Each Dr In TB.Rows
                GeneralTxt.AutoCompleteCustomSource.Add(Dr(0))
            Next
         

        End If
        RaiseEvent CustomTextChanged()
    End Sub
 
End Class
