Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.Layout
Imports Shipping.WHLEDI
Imports System.IO
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Net.Mail

Public Class FrmEcsBankImport


    Dim dtXLDup As DataTable
    Private TB As New DataTable

    Private Sub MenuItem_CustomEditClick() Handles MenuItem.CustomEditClick
        Dim Cmd As New SqlCommand
        Dim DA1 As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim sSql As String
        Dim TB1 As New System.Data.DataTable
        Dim lResult As Boolean

        If MsgBox("Do you want to Update?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If Not gridCntrs.Rows.Count = 0 Then
               
                For Each row As DataGridViewRow In gridCntrs.Rows
                    If Not row.Cells("ID").Value Is Nothing Then
                        Cmd = New SqlCommand("SP_ECSBankImport_Update")
                        Cnn = New SqlConnection(My.Settings.DSN)
                        Cnn.Open()
                        Cmd.CommandTimeout = 5000
                        Cmd.CommandType = CommandType.StoredProcedure
                        Cmd.Parameters.AddWithValue("@CntrNo", row.Cells("CntrNo").Value)
                        Cmd.Parameters.AddWithValue("@CntrSize", row.Cells("CntrSize").Value)
                        Cmd.Parameters.AddWithValue("@CntrType", row.Cells("CntrType").Value)
                        Cmd.Parameters.AddWithValue("@TW", Convert.ToInt32(row.Cells("TW").Value))
                        Cmd.Parameters.AddWithValue("@MaxGW", Convert.ToInt32(row.Cells("MaxGW").Value))
                        Cmd.Parameters.AddWithValue("@Payload", Convert.ToInt32(row.Cells("Payload").Value))
                        Cmd.Parameters.AddWithValue("@Modified_Date", Now())
                        Cmd.Parameters.AddWithValue("@CreatedBy", CurrentUser.ID.ToString())
                        Cmd.Connection = Cnn
                        Cmd.ExecuteNonQuery()
                        Cnn.Close()
                    End If
                Next
                MsgBoxSaveSuccessful()

            Else
                MsgBoxGeneral("No Data to Update!")
            End If
        End If
    End Sub

    Private Sub MenuItem_CustomOpenFileClick() Handles MenuItem.CustomOpenFileClick

        Dim Dialog As New OpenFileDialog
        Me.FleName.TextValue = ""
        Dialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        If Dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.FleName.TextValue = Dialog.FileName
        End If

    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        If Me.FleName.TextValue = "" Then
            Exit Sub
        End If

        If Not IO.File.Exists(Me.FleName.TextValue) Then
            MsgBoxGeneral("File Dose Not Existed !")
            Exit Sub
        End If
        ReadingFile()

    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        Dim TB As New DataTable
        Dim sSql As String
        Dim lResult As Boolean
        Dim dupcount As Integer
        dupcount = 0
        Dim StrDupCntrs As String
        Dim SaveMsg As String
        Dim dt As New DataTable()
        Dim dtLog As New DataTable()
        Dim dtDup As New DataTable()

        dt.Columns.Add("ID", GetType(Guid))
        dt.Columns.Add("CntrNo", GetType(String))
        dt.Columns.Add("CntrSize", GetType(Int32))
        dt.Columns.Add("CntrType", GetType(String))
        dt.Columns.Add("TW", GetType(Int32))
        dt.Columns.Add("MaxGW", GetType(Int32))
        dt.Columns.Add("Payload", GetType(Int32))
        dt.Columns.Add("Created_Date", GetType(Date))
        dt.Columns.Add("Modified_Date", GetType(Date))
        dt.Columns.Add("CreatedBy", GetType(String))

        dtDup.Columns.Add("CntrNo", GetType(String))
        dtDup.Columns.Add("CntrSize", GetType(Int32))
        dtDup.Columns.Add("CntrType", GetType(String))
        dtDup.Columns.Add("TW", GetType(Int32))
        dtDup.Columns.Add("MaxGW", GetType(Int32))
        dtDup.Columns.Add("Payload", GetType(Int32))

        dtLog.Columns.Add("ID", GetType(Guid))
        dtLog.Columns.Add("TBName", GetType(String))
        dtLog.Columns.Add("TableKey", GetType(Guid))
        dtLog.Columns.Add("ActionUser", GetType(String))
        dtLog.Columns.Add("ActionTime", GetType(Date))
        dtLog.Columns.Add("ActionType", GetType(String))

        StrDupCntrs = ""
        sSql = "select cntrno from TB_EcsBank"
        TableBySql(sSql, TB, lResult)
        If TB.Rows.Count > 0 Then

            For Each row As DataGridViewRow In gridCntrs.Rows
                If Not row.Cells("ID").Value Is Nothing Then
                    For Each rowdb As DataRow In TB.Rows
                        If Not row.Cells("ID").Value = 1 Then
                            If row.Cells("CntrNo").Value.ToString() = rowdb.Item(0).ToString() Then
                                dupcount += 1
                                dtDup.Rows.Add(row.Cells("CntrNo").Value.ToString(), row.Cells("CntrSize").Value, row.Cells("CntrType").Value.ToString(), row.Cells("TW").Value, row.Cells("MaxGW").Value, row.Cells("Payload").Value)
                                row.Cells("ID").Value = 1
                                Exit For
                            Else

                                row.Cells("ID").Value = 0
                            End If
                        End If
                    Next
                End If
            Next
        End If

        If (gridCntrs.Rows.Count - 1) - (dtXLDup.Rows.Count) = dupcount Then
            MsgBoxGeneral("All Containers are Already Imported!")
            Me.MenuItem.ShowSave = False
            Exit Sub
        End If
        If dupcount > 0 Then
            'MsgBoxGeneral("Duplicate Containers " + StrDupCntrs)
            'SaveMsg = dupcount.ToString() + " Cntrs are Already Inserted. Do You Want Import Selected Data ?"
            FrmEcsImportDialog.grdDBDup.DataSource = dtDup
            FrmEcsImportDialog.lblDBCount.Text = dtDup.Rows.Count.ToString()
            If dtXLDup.Rows.Count > 0 Then
                FrmEcsImportDialog.grdExcelDup.DataSource = dtXLDup
                FrmEcsImportDialog.lblxlCount.Text = dtXLDup.Rows.Count.ToString()
            End If
            FrmEcsImportDialog.ShowDialog()
        Else
            SaveMsg = "Do You Want Import Selected Data ?"
        End If
        If dupcount = 0 And dtXLDup.Rows.Count = 0 Then
            If MsgBox(SaveMsg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                mail()
                For Each row As DataGridViewRow In gridCntrs.Rows
                    If Not row.Cells("ID").Value Is Nothing Then
                        If Not row.Cells("ID").Value = 1 Then
                            Dim ID As Guid = New Guid()
                            ID = System.Guid.NewGuid
                            Dim CntrNo As String = row.Cells("CntrNo").Value.ToString()
                            Dim CntrSize As Integer = row.Cells("CntrSize").Value.ToString()
                            Dim CntrType As String = row.Cells("CntrType").Value.ToString()
                            Dim TW As Integer = Convert.ToInt32(row.Cells("TW").Value)
                            Dim MaxGW As Integer = Convert.ToInt32(row.Cells("MaxGW").Value)
                            Dim Payload As Integer = Convert.ToInt32(row.Cells("Payload").Value)
                            dt.Rows.Add(ID, CntrNo, CntrSize, CntrType, TW, MaxGW, Payload, Now(), Now(), CurrentUser.ID.ToString())
                            dtLog.Rows.Add(System.Guid.NewGuid, "TB_EcsBank", ID, CurrentUser.UserCode, DateTime.Now.ToShortDateString(), "Added")
                        End If
                    End If
                Next
                If dt.Rows.Count > 0 Then
                    Dim conString As String = My.Settings.DSN
                    Using con As New SqlConnection(conString)
                        Using sqlBulkCopy As New SqlBulkCopy(con)
                            sqlBulkCopy.DestinationTableName = "dbo.tb_ecsbank"
                            sqlBulkCopy.ColumnMappings.Add("ID", "ID")
                            sqlBulkCopy.ColumnMappings.Add("CntrNo", "CntrNo")
                            sqlBulkCopy.ColumnMappings.Add("CntrSize", "CntrSize")
                            sqlBulkCopy.ColumnMappings.Add("CntrType", "CntrType")
                            sqlBulkCopy.ColumnMappings.Add("TW", "TW")
                            sqlBulkCopy.ColumnMappings.Add("MaxGW", "MaxGW")
                            sqlBulkCopy.ColumnMappings.Add("Payload", "Payload")
                            sqlBulkCopy.ColumnMappings.Add("Created_Date", "Created_Date")
                            sqlBulkCopy.ColumnMappings.Add("Modified_Date", "Modified_Date")
                            sqlBulkCopy.ColumnMappings.Add("CreatedBy", "CreatedBy")
                            con.Open()
                            sqlBulkCopy.WriteToServer(dt)
                            con.Close()
                            Me.MenuItem.ShowSave = False
                            gridCntrs.DataSource = dt
                            gridCntrs.Columns(0).Visible = False
                        End Using
                        MsgBoxGeneral(dt.Rows.Count.ToString() + " Containers are Imported Sucessfully!")
                        Me.FleName.TextValue = ""
                        'log insert
                        Using sqlBulkCopyLog As New SqlBulkCopy(con)
                            sqlBulkCopyLog.DestinationTableName = "dbo.TB_LogMaster"
                            sqlBulkCopyLog.ColumnMappings.Add("ID", "ID")
                            sqlBulkCopyLog.ColumnMappings.Add("TBName", "TBName")
                            sqlBulkCopyLog.ColumnMappings.Add("TableKey", "TableKey")
                            sqlBulkCopyLog.ColumnMappings.Add("ActionUser", "ActionUser")
                            sqlBulkCopyLog.ColumnMappings.Add("ActionTime", "ActionTime")
                            sqlBulkCopyLog.ColumnMappings.Add("ActionType", "ActionType")
                            con.Open()
                            sqlBulkCopyLog.WriteToServer(dtLog)
                            con.Close()
                            Me.MenuItem.ShowSave = False
                            gridCntrs.DataSource = dt
                            gridCntrs.Columns(0).Visible = False
                        End Using
                    End Using
                End If
            End If
        Else
            If FrmEcsImportDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                mail()
                For Each row As DataGridViewRow In gridCntrs.Rows
                    If Not row.Cells("ID").Value Is Nothing Then
                        If Not row.Cells("ID").Value = 1 Then
                            Dim ID As Guid = New Guid()
                            ID = System.Guid.NewGuid
                            Dim CntrNo As String = row.Cells("CntrNo").Value.ToString()
                            Dim CntrSize As Integer = row.Cells("CntrSize").Value.ToString()
                            Dim CntrType As String = row.Cells("CntrType").Value.ToString()
                            Dim TW As Integer = Convert.ToInt32(row.Cells("TW").Value)
                            Dim MaxGW As Integer = Convert.ToInt32(row.Cells("MaxGW").Value)
                            Dim Payload As Integer = Convert.ToInt32(row.Cells("Payload").Value)
                            dt.Rows.Add(ID, CntrNo, CntrSize, CntrType, TW, MaxGW, Payload, Now(), Now(), CurrentUser.ID.ToString())
                            dtLog.Rows.Add(System.Guid.NewGuid, "TB_EcsBank", ID, CurrentUser.UserCode, DateTime.Now.ToShortDateString(), "Added")
                        End If
                    End If
                Next
                If dt.Rows.Count > 0 Then
                    Dim conString As String = My.Settings.DSN
                    Using con As New SqlConnection(conString)
                        Using sqlBulkCopy As New SqlBulkCopy(con)
                            sqlBulkCopy.DestinationTableName = "dbo.tb_ecsbank"

                            sqlBulkCopy.ColumnMappings.Add("ID", "ID")
                            sqlBulkCopy.ColumnMappings.Add("CntrNo", "CntrNo")
                            sqlBulkCopy.ColumnMappings.Add("CntrSize", "CntrSize")
                            sqlBulkCopy.ColumnMappings.Add("CntrType", "CntrType")
                            sqlBulkCopy.ColumnMappings.Add("TW", "TW")
                            sqlBulkCopy.ColumnMappings.Add("MaxGW", "MaxGW")
                            sqlBulkCopy.ColumnMappings.Add("Payload", "Payload")
                            sqlBulkCopy.ColumnMappings.Add("Created_Date", "Created_Date")
                            sqlBulkCopy.ColumnMappings.Add("Modified_Date", "Modified_Date")
                            sqlBulkCopy.ColumnMappings.Add("CreatedBy", "CreatedBy")
                            con.Open()
                            sqlBulkCopy.WriteToServer(dt)
                            con.Close()
                            Me.MenuItem.ShowSave = False
                            gridCntrs.DataSource = dt
                            gridCntrs.Columns(0).Visible = False

                        End Using
                        MsgBoxGeneral(dt.Rows.Count.ToString() + " Containers are Imported Sucessfully!")
                        Me.FleName.TextValue = ""
                        'log insert
                        Using sqlBulkCopyLog As New SqlBulkCopy(con)
                            sqlBulkCopyLog.DestinationTableName = "dbo.TB_LogMaster"
                            sqlBulkCopyLog.ColumnMappings.Add("ID", "ID")
                            sqlBulkCopyLog.ColumnMappings.Add("TBName", "TBName")
                            sqlBulkCopyLog.ColumnMappings.Add("TableKey", "TableKey")
                            sqlBulkCopyLog.ColumnMappings.Add("ActionUser", "ActionUser")
                            sqlBulkCopyLog.ColumnMappings.Add("ActionTime", "ActionTime")
                            sqlBulkCopyLog.ColumnMappings.Add("ActionType", "ActionType")
                            con.Open()
                            sqlBulkCopyLog.WriteToServer(dtLog)
                            con.Close()
                        End Using
                    End Using
                End If
            End If
        End If
    End Sub
    Public Sub mail()
        Try
            Dim mail As New MailMessage()
            Dim SmtpServer As New SmtpClient("Mail.iranlandsea.com")
            mail.From = New MailAddress("shipping@iranlandsea.com")
            mail.[To].Add("support@paragondynamics.in")
            mail.Subject = "ILS - Cntr Bank Import Excel"
            Dim attachment As System.Net.Mail.Attachment
            attachment = New System.Net.Mail.Attachment(Me.FleName.TextValue)
            mail.Attachments.Add(attachment)
            SmtpServer.Port = 2525 ' SMTP Email Server port
            SmtpServer.Credentials = New System.Net.NetworkCredential("shipping@iranlandsea.com", "shipping@BBi@IranLandSea@li")
            SmtpServer.EnableSsl = False
            SmtpServer.Send(mail)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ReadingFile()

        Dim conn As OleDbConnection
        Dim dtr As OleDbDataReader
        Dim dta As OleDbDataAdapter
        Dim cmd As OleDbCommand
        Dim dts As DataSet
        Dim excel As String
        Dim OpenFileDialog As New OpenFileDialog
        Dim rowcount As Integer
        Dim dtGrid As DataTable
        rowcount = 1
        gridCntrs.Visible = False

        dtXLDup = New DataTable()
        dtXLDup.Columns.Add("CntrNo", GetType(String))
        dtXLDup.Columns.Add("CntrSize", GetType(Int32))
        dtXLDup.Columns.Add("CntrType", GetType(String))
        dtXLDup.Columns.Add("TW", GetType(Int32))
        dtXLDup.Columns.Add("MaxGW", GetType(Int32))
        dtXLDup.Columns.Add("Payload", GetType(Int32))

        dtGrid = New DataTable()

        dtGrid.Columns.Add("CntrNo", GetType(String))
        dtGrid.Columns.Add("CntrSize", GetType(Int32))
        dtGrid.Columns.Add("CntrType", GetType(String))
        dtGrid.Columns.Add("TW", GetType(Int32))
        dtGrid.Columns.Add("MaxGW", GetType(Int32))
        dtGrid.Columns.Add("Payload", GetType(Int32))

        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Me.FleName.TextValue + ";Extended Properties=Excel 12.0;")
        dta = New OleDbDataAdapter("Select * From [Sheet1$]", conn)
        dts = New DataSet
        dta.Fill(dts, "[Sheet1$]")
        If gridCntrs.Columns.Contains("ID") = True Then
            gridCntrs.Columns.Remove("ID")
        End If
        gridCntrs.DataSource = dts
        gridCntrs.DataMember = "[Sheet1$]"

        If Not gridCntrs.Columns(0).Name = "CntrNo" Then
            MsgBoxGeneral("Invalid Excel Column - " + gridCntrs.Columns(0).Name + ", Please Import Correct Excel!", "ILSShipping")
            Exit Sub
        End If
        If Not gridCntrs.Columns(1).Name = "CntrSize" Then
            MsgBoxGeneral("Invalid Excel Column - " + gridCntrs.Columns(1).Name + ", Please Import Correct Excel!", "ILSShipping")
            Exit Sub
        End If
        If Not gridCntrs.Columns(2).Name = "CntrType" Then
            MsgBoxGeneral("Invalid Excel Column - " + gridCntrs.Columns(2).Name + ", Please Import Correct Excel!", "ILSShipping")
            Exit Sub
        End If
        If Not gridCntrs.Columns(3).Name = "TW" Then
            MsgBoxGeneral("Invalid Excel Column - " + gridCntrs.Columns(3).Name + ", Please Import Correct Excel!", "ILSShipping")
            Exit Sub
        End If
        If Not gridCntrs.Columns(4).Name = "MaxGW" Then
            MsgBoxGeneral("Invalid Excel Column - " + gridCntrs.Columns(4).Name + ", Please Import Correct Excel!", "ILSShipping")
            Exit Sub
        End If
        If Not gridCntrs.Columns(5).Name = "Payload" Then
            MsgBoxGeneral("Invalid Excel Column - " + gridCntrs.Columns(5).Name + ", Please Import Correct Excel!", "ILSShipping")
            Exit Sub
        End If
        If Not gridCntrs.Columns.Count >= 6 Then
            MsgBoxGeneral("Columns are mismatch. Please Import Correct Excel!", "ILSShipping")
            Exit Sub
        End If
        For Each row As DataGridViewRow In gridCntrs.Rows
            If Not row.Cells("CntrNo").Value Is Nothing And Not IsDBNull(row.Cells("CntrNo").Value) Then
                rowcount += 1

                If Not IsNumeric(row.Cells("TW").Value) Then
                    MsgBoxGeneral("TW value in Text - " + row.Cells("TW").Value.ToString() + " at the row - " + rowcount.ToString() + ". Please change to numeric Value!", "ILSShipping")
                    Exit Sub
                End If
                If Not IsNumeric(row.Cells("CntrSize").Value) Then
                    MsgBoxGeneral("Cntr Size value in Text - " + row.Cells("CntrSize").Value.ToString() + " at the row - " + rowcount.ToString() + ". Please change to numeric Value!", "ILSShipping")
                    Exit Sub
                End If
                If Not IsNumeric(row.Cells("MaxGW").Value) Then
                    MsgBoxGeneral("Cntr Size value in Text - " + row.Cells("MaxGW").Value.ToString() + " at the row - " + rowcount.ToString() + ". Please change to numeric Value!", "ILSShipping")
                    Exit Sub
                End If
                If Not IsNumeric(row.Cells("Payload").Value) Then
                    MsgBoxGeneral("Cntr Size value in Text - " + row.Cells("Payload").Value.ToString() + " at the row - " + rowcount.ToString() + ". Please change to numeric Value!", "ILSShipping")
                    Exit Sub
                End If
                dtGrid.Rows.Add(row.Cells("CntrNo").Value.ToString(), row.Cells("CntrSize").Value, row.Cells("CntrType").Value.ToString(), row.Cells("TW").Value, row.Cells("MaxGW").Value, row.Cells("Payload").Value)
            End If
        Next

        gridCntrs.DataMember = ""
        gridCntrs.DataSource = dtGrid
        gridCntrs.Columns.Add("ID", "ID")
        gridCntrs.AutoSize = True
        gridCntrs.Visible = True
        gridCntrs.Columns("ID").Visible = False
        gridCntrs.ReadOnly = True

        For i As Integer = 0 To Me.gridCntrs.RowCount - 2
            For j As Integer = 0 To Me.gridCntrs.RowCount - 2
                If i <> j Then
                    If gridCntrs.Rows(i).Cells("CntrNo").Value.ToString() = gridCntrs.Rows(j).Cells("CntrNo").Value.ToString() And Not gridCntrs.Rows(j).DefaultCellStyle.BackColor = Color.Coral Then
                        gridCntrs.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                        gridCntrs.Rows(j).DefaultCellStyle.BackColor = Color.Coral
                        dtXLDup.Rows.Add(gridCntrs.Rows(i).Cells("CntrNo").Value.ToString(), gridCntrs.Rows(i).Cells("CntrSize").Value, gridCntrs.Rows(i).Cells("CntrType").Value.ToString(), gridCntrs.Rows(i).Cells("TW").Value, gridCntrs.Rows(i).Cells("MaxGW").Value, gridCntrs.Rows(i).Cells("Payload").Value)
                        gridCntrs.Rows(i).Cells("ID").Value = 1
                        Exit For
                    Else
                        gridCntrs.Rows(i).Cells("ID").Value = 0
                    End If
                End If
            Next
        Next
        conn.Close()
        MsgBoxGeneral((gridCntrs.RowCount - 1).ToString() + " records. Click SAVE to Import")
        Me.MenuItem.ShowSave = True
        Me.MenuItem.ShowEdit = True
        Me.MenuItem.ButtonEdit.Text = "Update"
    End Sub

    Private Sub GenerateData(ByVal CL As WHLEDI, ByVal ClientId As Guid, ByVal BlStatus As String)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SaveDialog As New SaveFileDialog
        SaveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
        SaveDialog.Title = "Save an Excel File"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName <> "" Then
            saveExcelFile(SaveDialog.FileName)
        End If
    End Sub
    Private Sub saveExcelFile(ByVal FileName As String)
        Dim dsExcelExport As New DataSet
        Dim daExcelExport As New SqlDataAdapter
        Dim Excel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim intColumn, intRow, intColumnValue As Integer
        Dim strExcelFile As String
        Dim strFileName As String
        Dim varConnection As New SqlConnection
        Dim conCurrent As New SqlConnection
        Dim varCommand As SqlCommand
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DS As New DataSet
        Dim dFrom As Date
        Dim dTo As Date
        Dim RL As DataRelation
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn
        Dim DS2 As DataSet

        System.Threading.Thread.CurrentThread.CurrentCulture = _
               System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer
        xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        Dim DataTable As New System.Data.DataTable
        Dim table As New System.Data.DataTable
        Dim iCol As Integer = 0
        Dim rowIndex As Integer = 0
        Dim ColumnIndex As Integer = 0
        xlApp.Visible = False
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(xlApp.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
        worksheet.Activate()
        worksheet.AutoFilterMode = False

        xlWorkSheet.Cells(1, 1).Value = "CntrNo"
        xlWorkSheet.Cells(1, 2).Value = "CntrSize"
        xlWorkSheet.Cells(1, 3).Value = "CntrType"
        xlWorkSheet.Cells(1, 4).Value = "TW"
        xlWorkSheet.Cells(1, 5).Value = "MaxGW"
        xlWorkSheet.Cells(1, 6).Value = "Payload"

        xlWorkSheet.Cells(2, 1).Value = "AMFU8750807"
        xlWorkSheet.Cells(2, 2).Value = "40"
        xlWorkSheet.Cells(2, 3).Value = "HC"
        xlWorkSheet.Cells(2, 4).Value = "3780"
        xlWorkSheet.Cells(2, 5).Value = "1200"
        xlWorkSheet.Cells(2, 6).Value = "1200"

        xlWorkSheet.Cells(3, 1).Value = "AMFU8788680"
        xlWorkSheet.Cells(3, 2).Value = "40"
        xlWorkSheet.Cells(3, 3).Value = "HC"
        xlWorkSheet.Cells(3, 4).Value = "3780"
        xlWorkSheet.Cells(3, 5).Value = "1200"
        xlWorkSheet.Cells(3, 6).Value = "1200"

        xlWorkSheet.Cells(4, 1).Value = "BHCU3104110"
        xlWorkSheet.Cells(4, 2).Value = "20"
        xlWorkSheet.Cells(4, 3).Value = "DC"
        xlWorkSheet.Cells(4, 4).Value = "2250"
        xlWorkSheet.Cells(4, 5).Value = "1500"
        xlWorkSheet.Cells(4, 6).Value = "1300"

        xlWorkSheet.SaveAs(FileName)
        xlWorkBook.Close()
        xlApp.Quit()
        DA.Dispose()
        MsgBoxGeneral("Sample Excel Saved!")
        Exit Sub
        Me.Close()

    End Sub

End Class