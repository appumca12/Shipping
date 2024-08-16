Imports OrmLib
Imports ShippingBiz
Public Class FrmLogon

    Private FrmAns As Boolean = False
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
    
        Dim dm As New DataManager(My.Settings.DSN)

        dm.QueryCriteria.And(JoinPath.TB_Company.Columns.CompanyName, "", MatchType.IsNotNull)
        CurrentCompany = dm.GetTB_Company

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_Users.Columns.UserAccount, Me.UsernameTextBox.Text, MatchType.Exact)
        dm.QueryCriteria.And(JoinPath.TB_Users.Columns.Password, Me.PasswordTextBox.Text, MatchType.Exact)

        CurrentUser = dm.GetTB_Users

        If CurrentUser Is Nothing Then
            MsgBox("Your ID & Password Wrong !", MsgBoxStyle.Critical)
        Else
            CurrentUser = dm.GetTB_UsersCollectionFromDataSet(0)
            TbConfigInit()
            Me.Visible = False
            FrmAns = True
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub TbConfigInit()

        Dim sStream As String
        Dim myDataColumn As DataColumn
        Dim Dr As DataRow

        If Dir("c:\tmp", FileAttribute.Directory) = "" Then
            MkDir("C:\tmp")
        End If

        sStream = GetUserConfigFilePath() ' "c:\Tmp\" & CurrentUser.UserCode & "Config.Xml"

        If Dir(sStream) = "" Then

            With TbConfig
                myDataColumn = New DataColumn
                myDataColumn.DataType = System.Type.GetType("System.String")
                myDataColumn.ColumnName = "Key"
                .Columns.Add(myDataColumn)
                myDataColumn = New DataColumn
                myDataColumn.DataType = System.Type.GetType("System.String")
                myDataColumn.ColumnName = "Description"
                .Columns.Add(myDataColumn)
                .TableName = "TBConfig"
            End With
            Dr = TbConfig.NewRow
            Dr("Key") = "Initial Time"
            Dr("Description") = Today.ToString
            TbConfig.Rows.Add(Dr)
            TbConfig.WriteXml(sStream, XmlWriteMode.WriteSchema)
        Else
            TbConfig.ReadXml(sStream)
        End If

    End Sub

    Private Sub FrmLogon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public ReadOnly Property Ans() As Boolean
        Get
            Return FrmAns
        End Get
    End Property
    Private Sub UsernameTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Me.PasswordTextBox.Focus()
        End If
    End Sub
    Private Sub PasswordTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Me.OK.Focus()
        End If
    End Sub
End Class