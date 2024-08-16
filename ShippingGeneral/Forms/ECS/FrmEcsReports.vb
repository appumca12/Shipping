Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTree
Imports System.Data.SqlClient
Public Class FrmEcsReports

    Private Dm As DataManager
    Private Sub FrmEcsReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Status As New TB_CODECollection
        Dim St As TB_CODE
        Dim Node As UltraTreeNode
        Dim PNode As UltraTreeNode

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "ES", MatchType.Exact)
        Status = Dm.GetTB_CODECollection
        Status = Status.SortByMEANING(SortDirection.Ascending)

        With TreeStatus
            .Appearance.BackColor = Color.Aqua
            .Appearance.BackColor2 = Color.Black
            .Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
            PNode = New UltraTreeNode
            PNode.Text = "Containers Status"
            PNode.Key = "FirstLevel"
            PNode.Override.NodeAppearance.ForeColor = Color.White
            PNode.Override.NodeAppearance.FontData.Name = "verdana"
            PNode.Override.NodeAppearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            PNode.Override.NodeAppearance.FontData.SizeInPoints = "11"
            .Nodes.Add(PNode)
            For Each St In Status
                Node = New UltraTreeNode
                Node.Text = St.STDCode & " -> " & St.MEANING
                Node.Tag = St.STDCode
                Node.Override.NodeAppearance.ForeColor = Color.White
                Node.Override.NodeAppearance.FontData.Name = "verdana"
                Node.Override.NodeAppearance.FontData.SizeInPoints = "9"
                Node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox
                Node.CheckedState = CheckState.Checked
                .Nodes(PNode.Key).Nodes.Add(Node)
            Next
            .ExpandAll(ExpandAllType.Always)
        End With

        Dm.QueryCriteria.Clear()
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "DP", MatchType.Exact)
        Status = Dm.GetTB_CODECollection
        Status = Status.SortByMEANING(SortDirection.Ascending)
 
        With TreeDepot
            .Appearance.BackColor = Color.Aqua
            .Appearance.BackColor2 = Color.Black
            .Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal


            PNode = New UltraTreeNode
            PNode.Text = "Depots"
            PNode.Key = "FirstLevel"
            PNode.Override.NodeAppearance.ForeColor = Color.White
            PNode.Override.NodeAppearance.FontData.Name = "verdana"
            PNode.Override.NodeAppearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .RefreshSort(.Nodes)

            PNode.Override.NodeAppearance.FontData.SizeInPoints = "11"
            .Nodes.Add(PNode)
            For Each St In Status
                Node = New UltraTreeNode
                Node.Text = St.MEANING
                Node.Tag = St.STDCode
                Node.Override.NodeAppearance.ForeColor = Color.White
                Node.Override.NodeAppearance.FontData.Name = "verdana"
                Node.Override.NodeAppearance.FontData.SizeInPoints = "9"
                Node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox
                Node.CheckedState = CheckState.Checked
                .Nodes(PNode.Key).Nodes.Add(Node)
            Next
            .ExpandAll(ExpandAllType.Always)
        End With

        Me.dFrom.InitControl(False, False)
        Me.dTo.InitControl(False, False)
        
    End Sub
    Private Sub GenMovement()

        Dim Node As UltraTreeNode
        Dim Ds As New DataSet
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim dDummy As Date
        Dim XmlDepot As String = ""
        Dim xmlStatus As String = ""

        XmlDepot = "<DEPOT>"
        For Each Node In TreeDepot.Nodes(0).Nodes
            If Node.CheckedState = CheckState.Checked Then
                XmlDepot &= "<DP>" & Node.Tag.ToString & "</DP>"
            End If
        Next
        XmlDepot &= "</DEPOT>"


        xmlStatus = "<Status>"
        For Each Node In TreeStatus.Nodes(0).Nodes
            If Node.CheckedState = CheckState.Checked Then
                xmlStatus &= "<ST>" & Node.Tag.ToString & "</ST>"
            End If
        Next
        xmlStatus &= "</Status>"


        If Me.dFrom.GnrlDate.Value Is Nothing Then
            MsgBoxGeneral("From Date is Empty !")
            Exit Sub
        End If

        If Me.dTo.GnrlDate.Value Is Nothing Then
            MsgBoxGeneral("To Date is Empty !")
            Exit Sub
        End If

        dDummy = DateAdd(DateInterval.Hour, 23, Me.dTo.GnrlDate.Value)
        dDummy = DateAdd(DateInterval.Minute, 59, dDummy)


        Cnn.Open()
        Cmd = New SqlCommand("SP_EcsMovementList")

        With Cmd
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .CommandTimeout = 3000
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
            .Parameters.AddWithValue("@XMLStatus", xmlStatus)
            .Parameters.AddWithValue("@XMLDepot", XmlDepot)
            .Parameters.AddWithValue("@dFrom", Me.dFrom.GetSqlDateTime)
            .Parameters.AddWithValue("@dTo", dDummy)

        End With
        DA.SelectCommand = Cmd
        DA.Fill(Ds)

        PopulateGrid(Ds)

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Movement List From: " & Format(Me.dFrom.GnrlDate.Value, "short date") & " To:" & Format(Me.dTo.GnrlDate.Value.ToString, "short date")
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub GenInventory(ByVal IsOverDue As Boolean)

        Dim Node As UltraTreeNode
        Dim sStatus As String = ""
        Dim sDepot As String = ""
        Dim Ds As New DataSet

        Dim Cmd As New SqlCommand("SP_EcsInventory")
        Dim Cnn As SqlConnection
        Dim Da As New SqlDataAdapter

 
        Dim XmlDepot As String = ""
        Dim xmlStatus As String = ""

        XmlDepot = "<DEPOT>"
        For Each Node In TreeDepot.Nodes(0).Nodes
            If Node.CheckedState = CheckState.Checked Then
                XmlDepot &= "<DP>" & Node.Tag.ToString & "</DP>"
            End If
        Next
        XmlDepot &= "</DEPOT>"


        xmlStatus = "<Status>"
        For Each Node In TreeStatus.Nodes(0).Nodes
            If Node.CheckedState = CheckState.Checked Then
                xmlStatus &= "<ST>" & Node.Tag.ToString & "</ST>"
            End If
        Next
        xmlStatus &= "</Status>"

        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()

        Cmd = New SqlCommand("SP_EcsInventory")
        With Cmd
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .CommandTimeout = 3000
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
            .Parameters.AddWithValue("@XMLStatus", xmlStatus)
            .Parameters.AddWithValue("@XMLDepot", XmlDepot)
        End With


        Me.Cursor = Cursors.WaitCursor
        Da.SelectCommand = Cmd
        Da.Fill(Ds)


        PopulateGrid(Ds)
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Inventory"
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default


    End Sub

    Private Sub PopulateGrid(ByVal DS)

        Dim ChildBand As UltraGridBand
        Me.GridResult.DataSource = DS

        For Each ChildBand In Me.GridResult.DisplayLayout.Bands
            HideGridGUIDColoumn(ChildBand)
        Next
        Me.GridColumnChooser.SourceGrid = Me.GridResult

    End Sub

    Private Sub HideGridGUIDColoumn(ByVal Band As UltraGridBand)

        Dim Col As UltraGridColumn
        For Each Col In Band.Columns
            If Col.DataType.Name = "Guid" Then
                Col.Hidden = True
            End If
        Next

    End Sub

    Private Sub ExplorerBar_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles ExplorerBar.ItemClick
        Select Case e.Item.Text
            Case "Movement List"
                GenMovement()
            Case "Inventory"
                GenInventory(False)
            Case "List Of Cntrs By D.O. Date"
                GenListOfCnsDO()
            Case "Inventory With Detail"
                GenInventoryALL()
            Case "Container Trace"
                ContainerTrace()
            Case "OverDue"
                OverDue()

        End Select
    End Sub

    Private Sub ButtonToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonToExcel.Click
        SaveGridToExcel(Me.GridResult)
    End Sub

    Private Sub GenListOfCnsDO()

        Dim Cmd As SqlCommand
        Dim Cnn As SqlConnection
        Dim DS As New DataSet
        Dim DA As New SqlDataAdapter
        If Me.dFrom.GnrlDate.Value Is Nothing Then
            MsgBoxGeneral("From Date is Empty !")
            Exit Sub
        End If

        If Me.dTo.GnrlDate.Value Is Nothing Then
            MsgBoxGeneral("To Date is Empty !")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_ListOfCntrsDOByDate")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@dFrom", Me.dFrom.GnrlDate.Value)
        Cmd.Parameters.AddWithValue("@dTO", Me.dTo.GnrlDate.Value)
        Cmd.Connection = Cnn
        DA.SelectCommand = Cmd
        DA.Fill(ds)

        PopulateGrid(Ds)
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "D.O. Taken From: " & Format(Me.dFrom.GnrlDate.Value, "short date") & " To:" & Format(Me.dTo.GnrlDate.Value.ToString, "short date")
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default



    End Sub


    Private Sub GenInventoryALL()

        Dim Node As UltraTreeNode
        Dim sStatus As String = ""
        Dim sDepot As String = ""
        Dim Ds As New DataSet

        Dim Cmd As New SqlCommand("SP_EcsInverntoryALL")
        Dim Cnn As SqlConnection
        Dim Da As New SqlDataAdapter

        Dim XmlDepot As String = ""
        Dim xmlStatus As String = ""

        XmlDepot = "<DEPOT>"
        For Each Node In TreeDepot.Nodes(0).Nodes
            If Node.CheckedState = CheckState.Checked Then
                XmlDepot &= "<DP>" & Node.Tag.ToString & "</DP>"
            End If
        Next
        XmlDepot &= "</DEPOT>"


        xmlStatus = "<Status>"
        For Each Node In TreeStatus.Nodes(0).Nodes
            If Node.CheckedState = CheckState.Checked Then
                xmlStatus &= "<ST>" & Node.Tag.ToString & "</ST>"
            End If
        Next
        xmlStatus &= "</Status>"

        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()

        Cmd = New SqlCommand("SP_EcsInverntoryALL")
        With Cmd
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .CommandTimeout = 3000
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
            .Parameters.AddWithValue("@XMLStatus", xmlStatus)
            .Parameters.AddWithValue("@XMLDepot", XmlDepot)
        End With

        Me.Cursor = Cursors.WaitCursor
        Da.SelectCommand = Cmd
        Da.Fill(Ds)

        PopulateGrid(Ds)

        With Me.GridResult.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Inventory"
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default


        GridNumSeperator(Me.GridResult)
    End Sub

   
    Private Sub SelAllStatus_Click(sender As System.Object, e As System.EventArgs) Handles SelAllStatus.Click

        Dim Node As UltraTreeNode
        For Each Node In TreeStatus.Nodes(0).Nodes
            Node.CheckedState = CheckState.Checked
        Next


    End Sub

    Private Sub DeSelAllStatus_Click(sender As System.Object, e As System.EventArgs) Handles DeSelAllStatus.Click
        Dim Node As UltraTreeNode
        For Each Node In TreeStatus.Nodes(0).Nodes
            Node.CheckedState = CheckState.Unchecked
        Next
    End Sub

    Private Sub SelAllDep_Click(sender As System.Object, e As System.EventArgs) Handles SelAllDep.Click
        Dim Node As UltraTreeNode
        For Each Node In TreeDepot.Nodes(0).Nodes
            Node.CheckedState = CheckState.Checked
        Next
    End Sub

    Private Sub DeSelAllDep_Click(sender As System.Object, e As System.EventArgs) Handles DeSelAllDep.Click
        Dim Node As UltraTreeNode
        For Each Node In TreeDepot.Nodes(0).Nodes
            Node.CheckedState = CheckState.Unchecked
        Next
    End Sub
    Private Sub ContainerTrace()

        Dim Cmd As SqlCommand
        Dim Cnn As SqlConnection
        Dim DS As New DataSet
        Dim DA As New SqlDataAdapter
        If Me.dFrom.GnrlDate.Value Is Nothing Then
            MsgBoxGeneral("From Date is Empty !")
            Exit Sub
        End If

        If Me.dTo.GnrlDate.Value Is Nothing Then
            MsgBoxGeneral("To Date is Empty !")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_ContainerTraceByDschCmpl")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Parameters.AddWithValue("@dFrom", Me.dFrom.GnrlDate.Value)
        Cmd.Parameters.AddWithValue("@dTO", Me.dTo.GnrlDate.Value)
        Cmd.Connection = Cnn
        DA.SelectCommand = Cmd
        DA.Fill(DS)

        PopulateGrid(DS)
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Container Trace From: " & Format(Me.dFrom.GnrlDate.Value, "short date") & " To:" & Format(Me.dTo.GnrlDate.Value.ToString, "short date")
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub OverDue()

        Dim Cmd As SqlCommand
        Dim Cnn As SqlConnection
        Dim DS As New DataSet
        Dim DA As New SqlDataAdapter
       

        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_WHLOverDue")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Connection = Cnn
        DA.SelectCommand = Cmd
        DA.Fill(DS)

        PopulateGrid(DS)
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "OverDue "
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default

    End Sub
End Class



