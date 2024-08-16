Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid

 Public Class FrmGeneralSearch
    'Public Event ButtonSearchClick()
    Public Event CustomFindClick()
    Public Enum InwardOutward
        InWard
        Outward
    End Enum

    Private mBLID As Guid
    Private mBLNO As String
    Private mLine As String
    Private Cmd As New SqlClient.SqlCommand
    Private adapter As New SqlClient.SqlDataAdapter
    Private Cnn As New SqlClient.SqlConnection
    Private ResultTable As DataTable
    Private DM As DataManager
    Private Tb As DataTable
    Private InOut As InwardOutward

    Public Sub New(ByVal InOut As InwardOutward)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.InOut = InOut
        Dim Dr As DataRow
        Dr = DSForm2.Tables(0).NewRow
        Me.DSForm2.Tables(0).Rows.Add(Dr)

    End Sub

    ' Assigning Shortcut Keys to ToolStrip Buttons    
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F3
                'ExecuteToolStripButton.PerformClick()
                'ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
                Call ButtonSearchClick()
                RaiseEvent CustomFindClick()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Sub ButtonSearchClick()
        Dim sSql As String
        Dim aParam As New ArrayList
        Dim WhereCrt As String = ""
        Dim aItem(1) As String
        Dim Gid As Guid
        Dim Ar() As String

        Dim lCntr As Boolean = False
        Dim lName As Boolean = False
        Dim lGoods As Boolean = False

        Dim Dr As DataRow
        Dim Col As DataColumn

        Dr = Me.DSForm2.Tables("TBSel").Rows(0)
        Me.GridSel.UpdateData()

        Dim aFld As New ArrayList

        For Each Col In Dr.Table.Columns
            If Dr(Col.ColumnName).ToString <> "" Then
                If Col.DataType.Name = "DateTime" Then
                    Ar = New String() {Col.ColumnName, Format(Dr(Col.ColumnName), "yyyy-MM-dd"), Col.DataType.Name}
                    aParam.Add(Ar)
                Else
                    Ar = New String() {Col.ColumnName, Dr(Col.ColumnName), Col.DataType.Name}
                    aParam.Add(Ar)
                End If
            End If
        Next

        If aParam.Count = 0 Then
            MsgBoxGeneral("No Any Selection !", "Data Needed !")
            Exit Sub
        End If

        If Cnn.State <> ConnectionState.Open Then
            Cnn.ConnectionString = My.Settings.DSN
            Cnn.Open()
        End If

        Cmd = New SqlCommand

        sSql = " from tb_InwardBls bl , TB_Voyage VO , TB_Vessels VE , TB_InwardBlsGoods GD , TB_InwardCntrs CN ,  TB_InwardBlsNames NM , TB_Clients CL "
        WhereCrt = "BL.VoyageID = VO.ID and VO.VesselID = VE.ID and Bl.ID = GD.BLID and " & _
                       "Bl.ID = CN.BLID  and Bl.ID = NM.BLID and BL.ClientID = CL.ID  "


        If InOut = InwardOutward.Outward Then
            sSql = Replace(sSql.ToUpper, "INWARD", "Outward")
        End If

        For Each Prm() As Object In aParam
            Col = Dr.Table.Columns(Prm(0))
            Select Case Prm(2)
                Case "Guid"
                    WhereCrt += IIf(WhereCrt = "", "", " and ") & Prm(0) & " = @" & Prm(0)
                Case "DateTime"
                    WhereCrt += IIf(WhereCrt = "", "", " and ") & Prm(0) & " = @" & Prm(0)
                Case Else
                    If Prm(0).ToString.ToUpper = "GOODS" Then
                        WhereCrt += IIf(WhereCrt = "", "", " and GD.") & Prm(0) & " like @" & Prm(0)
                    Else
                        WhereCrt += IIf(WhereCrt = "", "", " and ") & Prm(0) & " like @" & Prm(0)
                    End If
            End Select
        Next


        For Each Prm() As Object In aParam
            Select Case Prm(2).ToString

                Case "Guid"
                    Cmd.Parameters.AddWithValue("@" & Prm(0), Prm(1))
                Case "DateTime"
                    Cmd.Parameters.AddWithValue("@" & Prm(0), Prm(1))
                Case Else

                    Cmd.Parameters.AddWithValue("@" & Prm(0), "%" & Prm(1) & "%")
            End Select

        Next

        sSql = "Select distinct BL.ID , Line , bl.BlNO , POL , POD , VE.VesselName as Vessel, VO.VoyageNo , Cl.lName as Client " & sSql & " Where " & WhereCrt

        With Cmd
            .Connection = Cnn
            .CommandText = sSql
            .CommandType = CommandType.Text
        End With

        adapter = New SqlClient.SqlDataAdapter(Cmd)
        ResultTable = New DataTable
        adapter.Fill(ResultTable)
        Me.GridBls.DataSource = ResultTable

        GridNumSeperator(Me.GridBls)

        adapter = New SqlClient.SqlDataAdapter(Cmd)
        ResultTable = New DataTable
        adapter.Fill(ResultTable)
        Me.GridBls.DataSource = ResultTable

        GridNumSeperator(Me.GridBls)
    End Sub

    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click

        Dim sSql As String
        Dim aParam As New ArrayList
        Dim WhereCrt As String = ""
        Dim aItem(1) As String
        Dim Gid As Guid
        Dim Ar() As String

        Dim lCntr As Boolean = False
        Dim lName As Boolean = False
        Dim lGoods As Boolean = False

        Dim Dr As DataRow
        Dim Col As DataColumn

        Dr = Me.DSForm2.Tables("TBSel").Rows(0)
        Me.GridSel.UpdateData()

        Dim aFld As New ArrayList

        For Each Col In Dr.Table.Columns
            If Dr(Col.ColumnName).ToString <> "" Then
                If Col.DataType.Name = "DateTime" Then
                    Ar = New String() {Col.ColumnName, Format(Dr(Col.ColumnName), "yyyy-MM-dd"), Col.DataType.Name}
                    aParam.Add(Ar)
                Else
                    Ar = New String() {Col.ColumnName, Dr(Col.ColumnName), Col.DataType.Name}
                    aParam.Add(Ar)
                End If
            End If
        Next

        If aParam.Count = 0 Then
            MsgBoxGeneral("No Any Selection !", "Data Needed !")
            Exit Sub
        End If

        If Cnn.State <> ConnectionState.Open Then
            Cnn.ConnectionString = My.Settings.DSN
            Cnn.Open()
        End If

        Cmd = New SqlCommand

        sSql = " from tb_InwardBls bl , TB_Voyage VO , TB_Vessels VE , TB_InwardBlsGoods GD , TB_InwardCntrs CN ,  TB_InwardBlsNames NM , TB_Clients CL "
        WhereCrt = "BL.VoyageID = VO.ID and VO.VesselID = VE.ID and Bl.ID = GD.BLID and " & _
                       "Bl.ID = CN.BLID  and Bl.ID = NM.BLID and BL.ClientID = CL.ID  "


        If InOut = InwardOutward.Outward Then
            sSql = Replace(sSql.ToUpper, "INWARD", "Outward")
        End If

        For Each Prm() As Object In aParam
            Col = Dr.Table.Columns(Prm(0))
            Select Case Prm(2)
                Case "Guid"
                    WhereCrt += IIf(WhereCrt = "", "", " and ") & Prm(0) & " = @" & Prm(0)
                Case "DateTime"
                    WhereCrt += IIf(WhereCrt = "", "", " and ") & Prm(0) & " = @" & Prm(0)
                Case Else
                    If Prm(0).ToString.ToUpper = "GOODS" Then
                        WhereCrt += IIf(WhereCrt = "", "", " and GD.") & Prm(0) & " like @" & Prm(0)
                    Else
                        WhereCrt += IIf(WhereCrt = "", "", " and ") & Prm(0) & " like @" & Prm(0)
                    End If
            End Select
        Next


        For Each Prm() As Object In aParam
            Select Case Prm(2).ToString

                Case "Guid"
                    Cmd.Parameters.AddWithValue("@" & Prm(0), Prm(1))
                Case "DateTime"
                    Cmd.Parameters.AddWithValue("@" & Prm(0), Prm(1))
                Case Else

                    Cmd.Parameters.AddWithValue("@" & Prm(0), "%" & Prm(1) & "%")
            End Select

        Next

        sSql = "Select distinct BL.ID , Line , bl.BlNO , POL , POD , VE.VesselName as Vessel, VO.VoyageNo , Cl.lName as Client " & sSql & " Where " & WhereCrt

        With Cmd
            .Connection = Cnn
            .CommandText = sSql
            .CommandType = CommandType.Text
        End With

        adapter = New SqlClient.SqlDataAdapter(Cmd)
        ResultTable = New DataTable
        adapter.Fill(ResultTable)
        Me.GridBls.DataSource = ResultTable

        GridNumSeperator(Me.GridBls)

        adapter = New SqlClient.SqlDataAdapter(Cmd)
        ResultTable = New DataTable
        adapter.Fill(ResultTable)
        Me.GridBls.DataSource = ResultTable

        GridNumSeperator(Me.GridBls)
    End Sub

    Public ReadOnly Property BLID() As Guid
        Get
            Return mBLID
        End Get
    End Property
    Public ReadOnly Property BLNo() As String
        Get
            Return mBLNO
        End Get
    End Property
    Public ReadOnly Property Line() As String
        Get
            Return mLine
        End Get
    End Property

    Private Sub GridBls_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridBls.AfterRowActivate
        If Me.GridBls.Rows.Count > 0 Then
            mBLID = Me.GridBls.ActiveRow.Cells("ID").Value
            mBLNO = Me.GridBls.ActiveRow.Cells("BLNO").Value
            mLine = Me.GridBls.ActiveRow.Cells("Line").Value
        End If
    End Sub

    Private Sub ButtonSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click
        If Me.GridBls.Rows.Count > 0 Then
            Me.Close()
        End If
    End Sub
End Class
