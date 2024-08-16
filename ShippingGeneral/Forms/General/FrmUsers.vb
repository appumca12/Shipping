
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinTree
Public Class FrmUsers
    Implements IFGeneral

    Private ItemLevel As String = "405"
    Private Dm As DataManager
    Private Frmstatus As FormStatus
    Private UserID As Guid
    Public IsEdit As String

    Private Sub FrmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim pNode As UltraTreeNode
        Dim Node As UltraTreeNode = Nothing

        Dim Dr As DataRow
        Dim Dr2 As DataRow
        Dim Dr3 As DataRow
        Dim aListLevel1() As DataRow
        Dim aListLevel2() As DataRow
        Dim aListLevel3() As DataRow

        Dim Urs As TB_UsersCollection
        Dim Mis As TB_MenuItemsCollection
        Dim Acl As TB_AccessLevelCollection
        Dim Ac As TB_AccessLevel

        'Dim CM As TB_CustomMenu
        'Dim CMS As TB_CustomMenuCollection

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.Clear()
        Urs = Dm.GetTB_UsersCollection
        Mis = Dm.GetTB_MenuItemsCollection


        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.Clear()
        Dm.GetTB_MenuItemsCollection.SortByItemLevel(SortDirection.Ascending)

        aListLevel1 = Dm.DataSet.Tables("Tb_MenuItems").Select("len(ItemLevel) < 2", "ItemLevel")
        aListLevel2 = Dm.DataSet.Tables("Tb_MenuItems").Select("len(ItemLevel) = 3", "ItemLevel")
        aListLevel3 = Dm.DataSet.Tables("Tb_MenuItems").Select("len(ItemLevel) = 5", "ItemLevel")

        With TreeAccess
            .Appearance.BackColor = Color.Aqua
            .Appearance.BackColor2 = Color.Black
            .Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
            pNode = New UltraTreeNode
            pNode.Text = "Items For Access"
            pNode.Key = "FirstLevel"
            pNode.Override.NodeAppearance.ForeColor = Color.White
            pNode.Override.NodeAppearance.FontData.Name = "verdana"
            pNode.Override.NodeAppearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True

            pNode.Override.NodeAppearance.FontData.SizeInPoints = "11"
            .Nodes.Add(pNode)
            For Each Dr In aListLevel1
                Node = New UltraTreeNode
                Node.Text = Dr("Description")
                Node.Tag = Dr("ID")
                Node.Key = Dr("Description")
                Node.Override.NodeAppearance.ForeColor = Color.White
                Node.Override.NodeAppearance.FontData.Name = "verdana"
                Node.Override.NodeAppearance.FontData.SizeInPoints = "9"
                Node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox
                .Nodes(pNode.Key).Nodes.Add(Node)
                For Each Dr2 In aListLevel2
                    If Mid(Dr2("ItemLevel"), 1, 1) = Mid(Dr("ItemLevel"), 1, 1) Then
                        Node = New UltraTreeNode
                        Node.Text = Dr2("Description")
                        Node.Tag = Dr2("ID")
                        Node.Key = Dr2("Description")
                        Node.Override.NodeAppearance.ForeColor = Color.White
                        Node.Override.NodeAppearance.FontData.Name = "verdana"
                        Node.Override.NodeAppearance.FontData.SizeInPoints = "9"
                        Node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox
                        .Nodes(pNode.Key).Nodes(Dr("Description")).Nodes.Add(Node)
                        For Each Dr3 In aListLevel3
                            If Mid(Dr3("ItemLevel"), 1, 3) = Mid(Dr2("ItemLevel"), 1, 3) Then
                                Node = New UltraTreeNode
                                Node.Text = Dr3("Description")
                                Node.Tag = Dr3("ID")
                                Node.Key = Dr2("Description") & "|" & Dr3("Description")
                                Node.Override.NodeAppearance.ForeColor = Color.White
                                Node.Override.NodeAppearance.FontData.Name = "verdana"
                                Node.Override.NodeAppearance.FontData.SizeInPoints = "9"
                                Node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox
                                .Nodes(pNode.Key).Nodes(Dr("Description")).Nodes(Dr2("Description")).Nodes.Add(Node)
                            End If
                        Next
                    End If
                Next
            Next
            .Nodes(0).Expanded = True

        End With

        Me.Top = 0
        Me.Left = 0
        Me.GeneralForms.InitControl("User Information", ItemLevel)

        Me.UserFirstName.SetLength(50)
        Me.UserLastName.SetLength(50)
        Me.UserAccount.SetLength(10)
        Me.Password.SetLength(10)
        Me.UserCode.SetLength(2)
        Me.TxtSearch.SetLength(10)
        Me.EMailOffice.SetLength(50)

        LockStatus(False)
        Frmstatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, Frmstatus)
        Me.TxtSearch.GeneralText.Enabled = True

        Me.UserGroupDetail.Appearance.BackColor = My.Settings.MainColor
        ChangeControlColor(Me.UserGroupDetail, Me.LableSearch.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)

        Me.IsAccountAdmin.Appearance.BackColor = My.Settings.MainColor
        Me.IsDocAdmin.Appearance.BackColor = My.Settings.MainColor
        Me.IsEcsAdmin.Appearance.BackColor = My.Settings.MainColor
        Me.IsSalesAdmin.Appearance.BackColor = My.Settings.MainColor
        Me.UserGroupDetail.Appearance.BackColor = My.Settings.MainColor
        Me.BookingViewer.Appearance.BackColor = My.Settings.MainColor


    End Sub

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)
        Me.TxtSearch.GeneralText.Enabled = True
    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

        Dim Dr As DataRow

        If Frmstatus = FormStatus.NewRecord Then
            Dr = Dm.DataSet.Tables("TB_users").NewRow
        Else
            Dr = Dm.DataSet.Tables("Tb_users").Rows(0)
        End If

        Dr("UserFirstName") = Me.UserFirstName.TextValue
        Dr("UserLastName") = Me.UserLastName.TextValue
        Dr("UserAccount") = Me.UserAccount.TextValue
        Dr("Password") = Me.Password.TextValue
        Dr("UserCode") = Me.UserCode.TextValue
        Dr("EMailOffice") = Me.EMailOffice.TextValue
        Dr("TEL") = Me.Tel.TextValue

        Dr("IsSalesAdmin") = Me.IsSalesAdmin.Checked
        Dr("IsAccountAdmin") = Me.IsAccountAdmin.Checked
        Dr("IsDocAdmin") = Me.IsDocAdmin.Checked
        Dr("IsEcsAdmin") = Me.IsEcsAdmin.Checked
        Dr("BookingViewer") = Me.BookingViewer.Checked
        If Frmstatus = FormStatus.NewRecord Then
            Dr("id") = UserID
            Dm.DataSet.Tables("TB_users").Rows.Add(Dr)
        End If

        Try
            Dm.CommitAll()
            NodeToClass(Me.TreeAccess.Nodes(0))
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub NodeToClass(ByVal Node As UltraTreeNode)


        Dim Rows() As DataRow
        Dim Dr As DataRow
        Dim ChildNode As UltraTreeNode
        If Not Node.Tag Is Nothing Then
            Rows = Dm.DataSet.Tables("TB_AccessLevel").Select("MenuItemID = '" & Node.Tag.ToString & "' and UserID = '" & UserID.ToString & "'")
            If Rows.Length > 0 Then
                Dr = Rows(0)
                If Node.CheckedState = CheckState.Checked Then
                    Dr("Accessble") = 1
                Else
                    Dr("Accessble") = 0
                End If
            Else
                Dr = Dm.DataSet.Tables("TB_AccessLevel").NewRow
                Dr("ID") = System.Guid.NewGuid
                Dr("UserID") = UserID
                Dr("MenuItemID") = Node.Tag
                If Node.CheckedState = CheckState.Checked Then
                    Dr("Accessble") = 1
                Else
                    Dr("Accessble") = 0
                End If
                Dm.DataSet.Tables("TB_AccessLevel").Rows.Add(Dr)
            End If
        End If
        If Node.HasNodes = True Then
            For Each ChildNode In Node.Nodes
                NodeToClass(ChildNode)
            Next
        End If

    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

        Dim Dr As DataRow
        Dr = Dm.DataSet.Tables("TB_Users").Rows(0)
        Me.UserFirstName.TextValue = IIf(IsDBNull(Dr("UserFirstName")) = True, "", Dr("UserFirstName"))
        Me.UserLastName.TextValue = IIf(IsDBNull(Dr("UserLastName")) = True, "", Dr("UserLastName"))
        Me.UserAccount.TextValue = IIf(IsDBNull(Dr("UserAccount")) = True, "", Dr("UserAccount"))
        Me.Password.TextValue = IIf(IsDBNull(Dr("Password")) = True, "", Dr("Password"))
        Me.UserCode.TextValue = IIf(IsDBNull(Dr("UserCode")) = True, "", Dr("UserCode"))
        Me.EMailOffice.TextValue = IIf(IsDBNull(Dr("EMailOffice")) = True, "", Dr("EMailOffice"))
        Me.Tel.TextValue = IIf(IsDBNull(Dr("Tel")) = True, "", Dr("Tel"))
        Me.IsSalesAdmin.Checked = IIf(IsDBNull(Dr("IsSalesAdmin")) = True, False, Dr("IsSalesAdmin"))
        Me.IsAccountAdmin.Checked = IIf(IsDBNull(Dr("IsAccountAdmin")) = True, False, Dr("IsAccountAdmin"))
        Me.IsDocAdmin.Checked = IIf(IsDBNull(Dr("IsDocAdmin")) = True, False, Dr("IsDocAdmin"))
        Me.IsEcsAdmin.Checked = IIf(IsDBNull(Dr("IsEcsAdmin")) = True, False, Dr("IsEcsAdmin"))
        Me.BookingViewer.Checked = IIf(IsDBNull(Dr("BookingViewer")) = True, False, Dr("BookingViewer"))

        UserID = Dr("ID")

        populateNode(TreeAccess.Nodes(0))

    End Sub

    Private Sub ClearNode(ByVal Node As UltraTreeNode)

        Dim ChildNode As UltraTreeNode
        For Each ChildNode In Node.Nodes
            If ChildNode.HasNodes = True Then
                ClearNode(ChildNode)
            End If
            ChildNode.CheckedState = CheckState.Unchecked
        Next

    End Sub

    Private Function ValidateForm() As Boolean

        Dim aErrorList As New ArrayList
        Dim nI As Long
        Dim Ans As Boolean = True
        FormErrorProvider.Clear()

        If Me.UserFirstName.TextValue = "" Then
            aErrorList.Add(Me.UserFirstName)
        End If

        If Me.UserLastName.TextValue = "" Then
            aErrorList.Add(Me.UserLastName)
        End If

        If Me.UserAccount.TextValue = "" Then
            aErrorList.Add(Me.UserAccount)
        End If

        If Me.Password.TextValue = "" Then
            aErrorList.Add(Me.Password)
        End If

        If Len(Trim(Me.UserCode.TextValue)) = 0 Then
            aErrorList.Add(Me.UserCode)
        End If

        If aErrorList.Count > 0 Then
            For nI = 0 To aErrorList.Count - 1
                FormErrorProvider.SetError(aErrorList(nI), "Data Requird")
            Next
            MsgBoxValidateFaild()
            Ans = False
        End If

        Return Ans

    End Function

    Private Sub populateNode(ByVal Node As UltraTreeNode)


        Dim Dr As DataRow
        Dim Rows() As DataRow
        Dim ChildNode As UltraTreeNode

        If Not Node.Tag Is Nothing Then
            Rows = Dm.DataSet.Tables("TB_AccessLevel").Select("MenuItemID = '" & Node.Tag.ToString & "'")
            If Rows.Length > 0 Then
                Dr = Rows(0)
                If Dr("Accessble") = True Then
                    Node.CheckedState = CheckState.Checked
                Else
                    Node.CheckedState = CheckState.Unchecked
                End If
            Else
                Node.CheckedState = CheckState.Unchecked
            End If
        End If

        If Node.HasNodes = True Then
            For Each ChildNode In Node.Nodes
                populateNode(ChildNode)
            Next
        End If

    End Sub

    Private Sub CheckForNewItems()

        Dim Cmd As New SqlClient.SqlCommand("SP_CreateItemInAccessLevel")
        Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)

        Cnn.Open()

        With Cmd
            .Connection = Cnn
            .CommandType = CommandType.StoredProcedure
        End With

        Cmd.ExecuteNonQuery()

        'Dim Items As TB_MenuItemsCollection
        'Dim Drs() As DataRow
        'Dim Dr As DataRow
        'Dim CM As TB_CustomMenu
        'Dim aLevel As TB_AccessLevel
        'Dim NewRow As DataRow

        'Dm.QueryCriteria.Clear()
        'Dm.QueryCriteria.And(JoinPath.TB_MenuItems.Columns.ItemKey, "", MatchType.IsNotNull)

        'Items = Dm.GetTB_MenuItemsCollection()
        'Dm.QueryCriteria.Clear()
        'Dm.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.UserID, Dm.DataSet.Tables("TB_Users").Rows(0).Item("ID"), MatchType.Exact)
        'Dm.GetTB_AccessLevelCollection()

        'Dm.QueryCriteria.Clear()
        'Dm.GetTB_UsersCollection()

        'For Each Dr In Dm.DataSet.Tables("TB_Users").Rows
        '    For Each item As TB_MenuItems In Items
        '        Dm.QueryCriteria.Clear()
        '        Dm.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.UserID, Dr("ID"), MatchType.Exact)
        '        Dm.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.MenuItemID, item.ID, MatchType.Exact)
        '        aLevel = Dm.GetTB_AccessLevel
        '        If aLevel Is Nothing Then
        '            NewRow = Dm.DataSet.Tables("TB_AccessLevel").NewRow
        '            NewRow("ID") = Guid.NewGuid
        '            NewRow("UserID") = Dr("ID")
        '            NewRow("MenuItemID") = item.ID
        '            NewRow("Accessble") = False
        '            Dm.DataSet.Tables("TB_AccessLevel").Rows.Add(NewRow)
        '        End If
        '    Next
        'Next
        'Dm.CommitAll()

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts 

            Dim DummyValue As String = Me.TxtSearch.TextValue
            Dim Ds As New DataSet
            Dim nI As Byte
            Dim aTables() As String = {"TB_Users", "TB_AccessLevel"}

            ClearControl(Me)
            ClearNode(Me.TreeAccess.Nodes(0))

            Me.TxtSearch.TextValue = DummyValue

            If Me.TxtSearch.TextValue = "" Then
                Exit Sub
            End If
            Dm = New DataManager(My.Settings.DSN)

            Me.TxtSearch.TextValue = Replace(Replace(Me.TxtSearch.TextValue, "'", ""), "%", "")
            Ds = StoredProcedures.SP_UserAccessAllByAccount(Me.TxtSearch.TextValue)

            Frmstatus = FormStatus.NoAction


            Dm.PopulateObjectsFromDataSet(Ds, aTables)
            For nI = 0 To aTables.Length - 1
                Dm.DataSet.Tables(aTables(nI)).Merge(Ds.Tables(nI))
            Next
            If Dm.DataSet.Tables("TB_Users").Rows.Count > 0 Then
                CheckForNewItems()
                Populate()
                Frmstatus = FormStatus.HasData
            Else
                MsgBoxGeneral("No Any user Found !", "Find Failed")
            End If

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, Frmstatus)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            ClearControl(Me)
            'Me.UserAccount.Focus()
            Me.UserCode.Focus()
            Me.Password.Focus()
            Me.UserGroupDetail.Focus()
            ClearNode(Me.TreeAccess.Nodes(0))
            LockStatus(True)
            Frmstatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, Frmstatus)
            UserID = System.Guid.NewGuid
            IsEdit = "F"
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Frmstatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, Frmstatus)
            LockStatus(True)
            IsEdit = "T"
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts


            Dim LogDataSet As New DataSet

            If ValidateForm() = True Then
                Dim Tb As New DataTable
                Dim lResult As Boolean
                If IsEdit = "T" Then
                    TableBySql("select usercode from tb_users where UserCode <> '" & Me.UserCode.TextValue & "' and useraccount = '" & Me.UserAccount.TextValue & "'", Tb, lResult)

                    If Tb.Rows.Count > 0 Then
                        MessageBox.Show("Can not modify user code !", "Shipping", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    TableBySql("select usercode from tb_users where UserCode = '" & Me.UserCode.TextValue & "'", Tb, lResult)
                    If Tb.Rows.Count > 0 Then
                        MessageBox.Show("User Code already Exists !", "Shipping", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                    SendDataToClass()
                    Try
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        MsgBoxSaveSuccessful()
                        Frmstatus = FormStatus.HasData
                    Catch ex As Exception
                        MsgBoxSaveFailed()
                        MsgBox(ex.ToString())
                    End Try

                End If
            End If
            End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet
            Dim Dr As DataRow

            If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                For Each Dr In Dm.DataSet.Tables("TB_AccessLevel").Rows
                    Dr.Delete()
                Next
                Dm.DataSet.Tables("TB_Users").Rows(0).Delete()
                Try
                    LogDataSet = Dm.DataSet.Copy
                    Dm.CommitAll()
                    GenerateLog(LogDataSet)
                    Frmstatus = FormStatus.NoAction
                    LockStatus(False)
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, Frmstatus)
                    MsgBoxDeleteSuccessful()
                Catch ex As Exception
                    MsgBoxDeleteFailed()
                End Try
            End If
        End If

    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

End Class