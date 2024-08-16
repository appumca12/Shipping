Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports System.Text.RegularExpressions

Public Class FrmInwardSearch

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
        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        sSql = "select Accessble from TB_AccessLevel where USERid = '" & CurrentUser.ID.ToString() & "' and MenuItemID = (select id from TB_MenuItems where itemkey = '" & "ExcelExport" & "')"
        TableBySql(sSql, TB, lResult)
        If TB.Rows.Count > 0 Then
            If TB.Rows(0).Item(0) = "1" Then
                Me.MenuItem.ShowExcel = True
            Else
                Me.MenuItem.ShowExcel = False
            End If
        End If
    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick


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

        sSql = " from tb_InwardBls bl ,TB_Voyage VO , TB_Vessels VE , TB_InwardBlsGoods GD , TB_InwardCntrs CN ,  TB_InwardBlsNames NM , TB_Clients CL "
        WhereCrt = "BL.VoyageID = VO.ID and VO.VesselID = VE.ID and Bl.ID = GD.BLID and " & _
                       "Bl.ID = CN.BLID  and Bl.ID = NM.BLID and BL.ClientID = CL.ID  "

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

        sSql = "Select bl.*,dbo.FC_TotalInwardCntrsByBLID(BL.ID) as 'TOTAL TEU' , VE.VesselName as Vessel, VO.VoyageNo , Cl.lName as Client " & sSql & " Where " & WhereCrt

        With Cmd
            .Connection = Cnn
            .CommandText = sSql
            .CommandType = CommandType.Text
            .CommandTimeout = 5000
        End With

        adapter = New SqlClient.SqlDataAdapter(Cmd)
        ResultTable = New DataTable
        adapter.Fill(ResultTable)
        ''appu - calculate TEU
        For Each Dr In ResultTable.Rows

            Dim TEUFull As String
            Dim FirstTEU As Integer
            TEUFull = Dr("Total TEU")

            Dim isbns As New List(Of Integer)()
            FirstTEU = 0
            For Each i As Match In Regex.Matches(TEUFull, "X")
                isbns.Add(i.Index())
                If (TEUFull.IndexOf(i.Index() - 2) > 0) Then
                    FirstTEU += Convert.ToInt32(TEUFull.Substring(i.Index() - 2, 2)) * (Convert.ToInt32(TEUFull.Substring(i.Index() + 1, 2)) / 20)
                Else
                    FirstTEU += Convert.ToInt32(TEUFull.Substring(i.Index() - 1, 1)) * (Convert.ToInt32(TEUFull.Substring(i.Index() + 1, 2)) / 20)
                End If

            Next

            ' FirstTEU = Convert.ToInt32(TEUFull.Substring(0, 1)) * (Convert.ToInt32(TEUFull.Substring(2, 2)) / 20)

            Dr("Total TEU") = FirstTEU.ToString()
        Next

        Me.GridBls.DataSource = ResultTable

        GridNumSeperator(Me.GridBls)

        'adapter = New SqlClient.SqlDataAdapter(Cmd)
        'ResultTable = New DataTable
        'adapter.Fill(ResultTable)
        'Me.GridBls.DataSource = ResultTable

        GridNumSeperator(Me.GridBls)
 

    End Sub

    Private Sub Setdocument()
        Dim ds As New DataSet
        '      Dim aTables() As String = {"TB_OutwardBls", "Tb_OutwardBlsNames", "TB_OutwardBlsGoods", "TB_OutwardCharges", "Tb_OutwardCntrs", "TB_OutwardCnsImco", "TB_OutwardCnsTemprature", "TB_OutwardCnsPkgs"}

        DM = New DataManager(My.Settings.DSN)
        Try

            ds = StoredProcedures.SP_InwardAllDataByLineBlNo(Me.GridBls.ActiveRow.Cells("Line").Value, Me.GridBls.ActiveRow.Cells("BLNO").Value)
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
    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick
        Dim Exporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter

        Dim SaveDialog As SaveFileDialog

        If GridBls.Rows.Count = 0 Then
            Exit Sub
        End If
        'Dim S As String
        'For Each col As UltraGridColumn In Grid.DisplayLayout.Bands(0).Columns

        '    S = S & col.Key & vbCrLf

        'Next


        '  Grid.DisplayLayout.Bands(0).Hidden = True
        SaveDialog = New SaveFileDialog
        Exporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        SaveDialog.Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName = "" Then
            Exit Sub
        End If

        Try
            Exporter.Export(GridBls, SaveDialog.FileName)
            Process.Start(SaveDialog.FileName)
        Catch ex As Exception
            'MsgBox("Export to Excel Faild !", MsgBoxStyle.Critical)
        End Try
    End Sub
    
End Class