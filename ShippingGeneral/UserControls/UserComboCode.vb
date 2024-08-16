Imports OrmLib
Imports ShippingBiz

Public Class UserComboCode

    Public Event CustomValueChanged()
    Private TB As DataTable
    Private GroupCode As String
    Private lShowAll As Boolean = False
    'Private IsShouldUpdate As Boolean = False
    'Private ShowCol As ShowCoumn
    'Private CurrentCode As String = ""

    Enum ShowCoumn
        StdCode
        NextCode
        Meaning
        MeaningF
    End Enum
    Private Dm As New DataManager(My.Settings.DSN)
    Private Codes As TB_CODECollection
    Private lValidCode As Boolean
    Private nCol As ShowCoumn
    Private LastUpdateTime As String
    Private IsInit As Boolean = False

    Public Sub InitControl(ByVal GroupCode As String, ByVal ShowCol As ShowCoumn)

        Dim Code As TB_CODE
        Me.GroupCode = GroupCode
        Dim lResult As Boolean
        Dim Tmp As New DataTable
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, GroupCode, MatchType.Exact)
        Codes = Dm.GetTB_CODECollection()
        ComboCode.DataSource = Codes

        Select Case ShowCol
            Case ShowCoumn.Meaning
                Me.ComboCode.DisplayMember = "Meaning"
            Case ShowCoumn.MeaningF
                Me.ComboCode.DisplayMember = "MeaningF"
            Case ShowCoumn.NextCode
                Me.ComboCode.DisplayMember = "NextCode"
            Case ShowCoumn.StdCode
                Me.ComboCode.DisplayMember = "StdCode"
        End Select
        nCol = ShowCol
        Me.ComboCode.ValueMember = "StdCode"
        Me.ComboCode.SelectedValue = ""
        If lShowAll = True Then
            Code = Dm.NewTB_CODE
            Code.ID = System.Guid.Empty
            Code.STDCode = "(ALL)"
            Code.MEANING = "(ALL)"
            Codes.Add(Code)
        End If

        IsInit = True

    End Sub
    Public Sub InitControl(ByVal GroupCode As String, ByVal ShowCol As ShowCoumn, ByVal docombo As String)

        Dim Code As TB_CODE
        Me.GroupCode = GroupCode
        Dim lResult As Boolean
        Dim Tmp As New DataTable
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, GroupCode, MatchType.Exact)
        Codes = Dm.GetTB_CODECollection().FilterBySTDCode(My.Settings.Office)
        ComboCode.DataSource = Codes

        Select Case ShowCol
            Case ShowCoumn.Meaning
                Me.ComboCode.DisplayMember = "Meaning"
            Case ShowCoumn.MeaningF
                Me.ComboCode.DisplayMember = "MeaningF"
            Case ShowCoumn.NextCode
                Me.ComboCode.DisplayMember = "NextCode"
            Case ShowCoumn.StdCode
                Me.ComboCode.DisplayMember = "StdCode"
        End Select
        nCol = ShowCol
        Me.ComboCode.ValueMember = "StdCode"
        Me.ComboCode.SelectedValue = ""
        If lShowAll = True Then
            Code = Dm.NewTB_CODE
            Code.ID = System.Guid.Empty
            Code.STDCode = "(ALL)"
            Code.MEANING = "(ALL)"
            Codes.Add(Code)
        End If

        IsInit = True

    End Sub
    Public Sub InitControl(ByVal Col As TB_CODECollection, ByVal ShowCol As ShowCoumn)

        Codes = Col
        ComboCode.DataSource = Codes
        Select Case ShowCol
            Case ShowCoumn.Meaning
                Me.ComboCode.DisplayMember = "Meaning"
            Case ShowCoumn.MeaningF
                Me.ComboCode.DisplayMember = "Meaningf"
            Case ShowCoumn.NextCode
                Me.ComboCode.DisplayMember = "NextCode"
            Case ShowCoumn.StdCode
                Me.ComboCode.DisplayMember = "StdCode"
        End Select
        nCol = ShowCol
        Me.ComboCode.ValueMember = "StdCode"
        IsInit = True

    End Sub
    Public Sub InitControl(ByVal ArCode As ArrayList, ByVal ArMean As ArrayList, ByVal ShowCol As ShowCoumn)

        Dim Code As TB_CODE = Dm.NewTB_CODE
        Dim nI As Long

        Dm = New DataManager(My.Settings.DSN)
        Codes = New TB_CODECollection
        For nI = 0 To ArCode.Count - 1
            Code = Dm.NewTB_CODE
            Code.ID = System.Guid.Empty
            Code.STDCode = ArCode(nI).ToString
            Code.MEANING = ArMean(nI).ToString
            Codes.Add(Code)
        Next

        If lShowAll = True Then
            Code = Dm.NewTB_CODE
            Code.ID = System.Guid.Empty
            Code.STDCode = "***"
            Code.MEANING = "(ALL)"
            Codes.Add(Code)
        End If

        ComboCode.DataSource = Codes

        Select Case ShowCol
            Case ShowCoumn.Meaning
                Me.ComboCode.DisplayMember = "Meaning"
            Case ShowCoumn.MeaningF
                Me.ComboCode.DisplayMember = "Meaningf"
            Case ShowCoumn.NextCode
                Me.ComboCode.DisplayMember = "NextCode"
            Case ShowCoumn.StdCode
                Me.ComboCode.DisplayMember = "StdCode"
        End Select
        nCol = ShowCol
        Me.ComboCode.ValueMember = "StdCode"
        IsInit = True

    End Sub
    Public Sub InitControl(ByVal GroupCode As String, ByVal ArCode As ArrayList, ByVal ShowCol As ShowCoumn)

        Dim Code As TB_CODE = Dm.NewTB_CODE
        Dim nI As Long
        Dim Drs() As DataRow
        Dim Dr As DataRow

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, GroupCode, MatchType.Exact)
        Codes = Dm.GetTB_CODECollection
        Dim sCritera As String = ""

        For nI = 0 To ArCode.Count - 1
            sCritera += IIf(Len(sCritera) = 0, "Stdcode = '", " Or StdCode = '") & ArCode(nI) & "'"
        Next

        Drs = Dm.DataSet.Tables("TB_Code").Select(sCritera, "")

        Codes = New TB_CODECollection
        For Each Dr In Drs
            Code = Dm.NewTB_CODE
            Code.ID = Dr("ID")
            Code.STDCode = Dr("STDCode")
            Code.MEANING = Dr("MEANING")
            Codes.Add(Code)
        Next

        If lShowAll = True Then
            Code = Dm.NewTB_CODE
            Code.ID = System.Guid.Empty
            Code.STDCode = "***"
            Code.MEANING = "(ALL)"
            Codes.Add(Code)
        End If

        ComboCode.DataSource = Codes

        Select Case ShowCol
            Case ShowCoumn.Meaning
                Me.ComboCode.DisplayMember = "Meaning"
            Case ShowCoumn.MeaningF
                Me.ComboCode.DisplayMember = "Meaningf"
            Case ShowCoumn.NextCode
                Me.ComboCode.DisplayMember = "NextCode"
            Case ShowCoumn.StdCode
                Me.ComboCode.DisplayMember = "StdCode"
        End Select
        nCol = ShowCol
        Me.ComboCode.ValueMember = "StdCode"
        IsInit = True

    End Sub

    Private Sub ComboCode_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        ComboCode.BackColor = My.Settings.EditTextBackColor
        ComboCode.ForeColor = My.Settings.EditTextForcolor
    End Sub
    Private Sub ComboCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCode.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            '        SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub ComboCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCode.Leave
        ComboCode.BackColor = My.Settings.TextBackColor
        ComboCode.ForeColor = My.Settings.TextForcolor
    End Sub

    Public Property Code() As String
        Get
            If Me.ComboCode.Text <> "" Then
                Try
                    Return ComboCode.SelectedItem.stdcode
                Catch ex As Exception
                    Return ""
                End Try
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ComboCode.Text = SetDocument(value)
        End Set
    End Property

    Private Function SetDocument(ByVal value As String) As String

        Dim Doc As TB_CODECollection

        If Codes Is Nothing Then
            Return ""
        End If

        doc = Codes.FilterBySTDCode(value)

        If doc.Count <> 0 Then
            Select Case nCol
                Case ShowCoumn.Meaning
                    Return doc(0).MEANING
                Case ShowCoumn.MeaningF
                    Return doc(0).MEANINGF
                Case ShowCoumn.NextCode
                    Return doc(0).NextCode
                Case ShowCoumn.StdCode
                    Return doc(0).STDCode
                Case Else
                    Return ""
            End Select
        Else
            Return ""
        End If

    End Function

    Private Sub ComboCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCode.SelectedIndexChanged
        Try
            If IsInit = True Then
                SetDocument(ComboCode.SelectedItem.stdcode)
                RaiseEvent CustomValueChanged()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub AddItemOutSide(ByVal StdCode As String, ByVal Meaning As String, ByVal MeaningF As String)

        Dim Code As TB_CODE = Dm.NewTB_CODE
        Code = Dm.NewTB_CODE
        Code.ID = System.Guid.Empty
        Code.STDCode = StdCode
        Code.MEANING = Meaning
        Code.Meaningf = MeaningF
        Codes.Add(Code)
        Me.ComboCode.Refresh()

    End Sub


    Public Property CustomShowAll() As Boolean
        Get
            Return lShowAll
        End Get
        Set(ByVal value As Boolean)
            lShowAll = value
        End Set
    End Property

    Public Sub AutoComplete(ByRef cb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal blnLimitToList As Boolean = False)
        Dim strFindStr As String

        If e.KeyChar = Chr(8) Then  'Backspace
            If cb.SelectionStart <= 1 Then
                cb.Text = ""
                Exit Sub
            End If
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
            End If
        Else
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text & e.KeyChar
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart) & e.KeyChar
            End If
        End If

        Dim intIdx As Integer = -1

        ' Search the string in the Combo Box List.
        intIdx = cb.FindString(strFindStr)

        If intIdx <> -1 Then ' String found in the List.
            cb.SelectedText = ""
            cb.SelectedIndex = intIdx
            cb.SelectionStart = strFindStr.Length
            cb.SelectionLength = cb.Text.Length
            e.Handled = True
        Else
            If blnLimitToList = True Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If
    End Sub


    Public Sub ApplyFilterByNextCode(ByVal sValue As String, ByVal ShowCol As ShowCoumn)

        Codes = Dm.GetTB_CODECollection
        Codes = Codes.FilterByNextCode(sValue)
        ComboCode.DataSource = Codes

        Select Case ShowCol
            Case ShowCoumn.Meaning
                Me.ComboCode.DisplayMember = "Meaning"
            Case ShowCoumn.MeaningF
                Me.ComboCode.DisplayMember = "Meaningf"
            Case ShowCoumn.NextCode
                Me.ComboCode.DisplayMember = "NextCode"
            Case ShowCoumn.StdCode
                Me.ComboCode.DisplayMember = "StdCode"
        End Select
        nCol = ShowCol
        Me.ComboCode.ValueMember = "StdCode"
        IsInit = True

    End Sub

    'Private Sub CheckUpdate()

    '    Dim Tmp As New DataTable
    '    Dim lResult As Boolean
    '    Dim Code As TB_CODE

    '    TableBySql("SP_FindTableLastUpdate '" & DatabaseName & "' , 'TB_CODE'", Tmp, lResult)
    '    If lResult = True Then
    '        If LastUpdateTime <> Tmp.Rows(0).Item(0).ToString Then
    '            CurrentCode = Me.Code
    '            InitControl(GroupCode, ShowCol)
    '            Me.ComboCode.Text = ""
    '            SetDocument(CurrentCode)
    '        End If
    '        LastUpdateTime = Tmp.Rows(0).Item(0).ToString
    '    End If
    'End Sub

    'Private Sub UserComboCode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
    '    If IsShouldUpdate = True Then
    '        CheckUpdate()
    '    End If
    'End Sub

End Class
