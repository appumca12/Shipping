Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid

Public Class FrmOutwardSearch

    Private Cmd As New SqlClient.SqlCommand
    Private adapter As New SqlClient.SqlDataAdapter
    Private Cnn As New SqlClient.SqlConnection
    Private ResultTable As DataTable
    Private DM As DataManager
    Private Sub FrmInwardSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.POD.InitControl(Me.BackColor)
        'Me.POL.InitControl(Me.BackColor)
        'Me.FPOD.InitControl(Me.BackColor)
        'Me.Clients.InitControl()
        'Me.Clients.ClientID = System.Guid.Empty
        'Me.OnBoard.InitControl(False, False)
        Dim Dr As DataRow
        Dr = Me.DSForm2.Tables(0).NewRow
        Me.DSForm2.Tables(0).Rows.Add(Dr)

        With Me.GridSel
            .DisplayLayout.Appearance.FontData.SizeInPoints = 10
            .DisplayLayout.Override.RowSizing = RowSizing.Free
            .DisplayLayout.Override.DefaultRowHeight = 50
            .DisplayLayout.Override.RowSizingArea = RowSizingArea.Default
            '            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Bands(0).CardSettings.Width = 200
        End With
    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick


        Dim sSql As String
        Dim aParam As New ArrayList
        Dim WhereCrt As String = ""
        Dim aItem(1) As String
        Dim Gid As Guid

        Dim lCntr As Boolean = False
        Dim lName As Boolean = False
        Dim lGoods As Boolean = False

        Dim Dr As DataRow
        Dim Col As DataColumn

        Dim Ar() As String

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

        sSql = " from TB_OutwardBls bl , TB_Voyage VO , TB_Vessels VE , TB_OutwardBlsGoods GD , TB_OutwardCntrs CN ,  TB_OutwardBlsNames NM , TB_Clients CL , TB_Booking BK"
        WhereCrt = "BL.VoyageID = VO.ID and VO.VesselID = VE.ID and Bl.ID = GD.BLID and " & _
                       "Bl.ID = CN.BLID  and Bl.ID = NM.BLID and BL.ClientID = CL.ID and BL.BookingID = BK.ID "

        For Each Prm() As Object In aParam
            Col = Dr.Table.Columns(Prm(0))
            Select Case Prm(2)
                Case "Guid"
                    WhereCrt += IIf(WhereCrt = "", "", " and ") & Mid(Prm(0), 1, 2) & "." & Mid(Prm(0), 3) & " = @" & Mid(Prm(0), 3)
                Case "DateTime"
                    WhereCrt += IIf(WhereCrt = "", "", " and ") & Mid(Prm(0), 1, 2) & "." & Mid(Prm(0), 3) & " = @" & Mid(Prm(0), 3)
                Case Else
                    WhereCrt += IIf(WhereCrt = "", "", " and ") & Mid(Prm(0), 1, 2) & "." & Mid(Prm(0), 3) & " like @" & Mid(Prm(0), 3)
             End Select
        Next

        For Each Prm() As Object In aParam
            Select Case Prm(2).ToString

                Case "Guid"
                    Cmd.Parameters.AddWithValue("@" & Mid(Prm(0), 3), Prm(1))
                Case "DateTime"
                    Cmd.Parameters.AddWithValue("@" & Mid(Prm(0), 3), Prm(1))
                Case Else

                    Cmd.Parameters.AddWithValue("@" & Mid(Prm(0), 3), "%" & Prm(1) & "%")
            End Select

        Next

        sSql = "Select distinct bl.*  , VE.VesselName as Vessel, VO.VoyageNo , Cl.lName as Client , BK.BookingNo" & sSql & " Where " & WhereCrt

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

    Private Sub Setdocument()
        Dim ds As New DataSet
        '      Dim aTables() As String = {"TB_OutwardBls", "Tb_OutwardBlsNames", "TB_OutwardBlsGoods", "TB_OutwardCharges", "Tb_OutwardCntrs", "TB_OutwardCnsImco", "TB_OutwardCnsTemprature", "TB_OutwardCnsPkgs"}

        DM = New DataManager(My.Settings.DSN)
        Try

            ds = StoredProcedures.SP_OutwardAllDataByLineBlNo(Me.GridBls.ActiveRow.Cells("Line").Value, Me.GridBls.ActiveRow.Cells("BLNO").Value)
            If ds Is Nothing Then
                Exit Sub
            End If

            Me.DSForm.Tables(0).Clear()
            For Each dr As DataRow In ds.Tables(1).Rows
                DSForm.Tables(0).ImportRow(dr)
            Next

            '        Me.GridNames.DataSource = ds.Tables(1)
            Me.GridGoods.DataSource = ds.Tables(2)
            Me.GridCharges.DataSource = ds.Tables(3)
            Me.GridCntrs.DataSource = ds.Tables(4)

            '      GridNumSeperator(Me.GridNames)
            GridNumSeperator(Me.GridGoods)
            GridNumSeperator(Me.GridCharges)
            GridNumSeperator(Me.GridCntrs)

            Me.TxtCnee.Text = NullToValue(ds.Tables(1).Rows(0).Item("Cnee"), "")
            Me.TxtNotify1.Text = NullToValue(ds.Tables(1).Rows(0).Item("Notify1"), "")
            Me.TxtNotify2.Text = NullToValue(ds.Tables(1).Rows(0).Item("Notify2"), "")
            Me.TxtShipper.Text = NullToValue(ds.Tables(1).Rows(0).Item("Shipper"), "")

        Catch ex As Exception

        End Try


    End Sub

    Private Sub GridBls_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridBls.AfterRowActivate
        Setdocument()
    End Sub


End Class