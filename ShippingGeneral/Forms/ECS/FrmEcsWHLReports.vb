Imports System.Data.SqlClient
Imports System.IO
Imports Aspose.Cells
Imports System.Reflection

Public Class FrmEcsWHLReports

    Private Sub CheckWHL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckWHL.CheckedChanged

    End Sub

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Beep()
    End Sub

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click
        If Me.TabControl.SelectedTab.Text = "Movement " Then
            PickupMovement()
        End If

    End Sub
    Private Sub ButtonToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonToExcel.Click

        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DS As New DataSet
        Dim dFrom As Date
        Dim dTo As Date

        If Trim(Me.TabControl.SelectedTab.Text) = "Movement" Then
            If Me.GridSummary.Rows.Count > 0 Then
                SaveGridToExcel(Me.GridSummary)
            End If
        Else

            dFrom = Me.MoveDateFrom.DateValue
            dTo = Me.MoveDateFrom.DateValue
            dTo = DateAdd(DateInterval.Minute, 1434, dTo)


            Cnn.Open()

            With Cmd
                .CommandText = "SP_WHLEQCReportList"
                .CommandType = CommandType.StoredProcedure
                .Connection = Cnn
                .Parameters.AddWithValue("@dFrom", dFrom)
                .Parameters.AddWithValue("@dTo", dTo)
                .Parameters.AddWithValue("@IsReported", IIf(Me.CheckWHL.Checked = True, 1, 0))
                .Parameters.AddWithValue("@Line", CurrentShippingLine)
            End With

            DA.SelectCommand = Cmd
            DA.Fill(DS)

            Me.GridResult.DataSource = DS.Tables(0)
            GridNumSeperator(Me.GridResult)

            SaveGridToExcel(Me.GridResult)
        End If


       
    End Sub
    Private Sub PickupMovement()

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

        dFrom = Me.MoveDateFrom.DateValue
        dTo = Me.MoveDateTo.DateValue
        dTo = DateAdd(DateInterval.Minute, 1434, dTo)


        Cnn.Open()

        With Cmd
            .CommandText = "SP_WHLEQCReport"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@dFrom", dFrom)
            .Parameters.AddWithValue("@dTo", dTo)
            .Parameters.AddWithValue("@IsReported", IIf(Me.CheckWHL.Checked = True, 1, 0))
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
        End With

        DA.SelectCommand = Cmd
        DA.Fill(DS)


        DS.Tables(0).TableName = "Result"
        DS.Tables(1).TableName = "Summary"
        DS.Tables(2).TableName = "Details"

        DS2 = New DataSet
        DS2.Tables.Add(DS.Tables(1).Copy)
        DS2.Tables.Add(DS.Tables(2).Copy)
    

        PCol(0) = DS2.Tables(0).Columns("Status")
        cCol(0) = DS2.Tables(1).Columns("Status")

        RL = New DataRelation("Relation", PCol, cCol)

        DS2.Relations.Add(RL)

        Me.GridResult.DataSource = DS.Tables(0)
        Me.GridSummary.DataSource = DS2 

        GridNumSeperator(Me.GridResult)

    End Sub

    Private Sub ButtonSaveToText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveToText.Click

        Dim DLG As New SaveFileDialog
        Dim SaveDialog As SaveFileDialog
        Dim FS As FileStream
        Dim SB As New System.Text.StringBuilder
        Dim Row As Infragistics.Win.UltraWinGrid.UltraGridRow


        SaveDialog = New SaveFileDialog
        SaveDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*"
        SaveDialog.ShowDialog()

        If SaveDialog.FileName = "" Then
            Exit Sub
        End If

        For Each Row In GridResult.Rows
            SB.AppendLine(Row.Cells(1).Value.ToString)
        Next
        SB.AppendLine("EOF")

        Dim Output As New IO.StreamWriter(SaveDialog.FileName)
        Output.Write(SB.ToString)
        Output.Flush()
        Output.Close()

        MsgBox("Generate Sucsess")

     End Sub

    Private Sub ButtonDaily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDaily.Click

        Dim Book As New Aspose.Cells.Workbook
        Dim Sheet As Aspose.Cells.Worksheet
        Dim CellStyle As Style

        Dim Tb As New DataTable
        Dim lResult As Boolean
        Dim sSql As String = "SP_EcsDailyReport '" & CurrentShippingLine & "'"
        Dim Dr As DataRow
        Dim StorePort As String = ""
        Dim StoreStatus As String = ""
        Dim nRow As Long
        Dim HStyle As Style
        Dim FStyle As Style
        Dim dStyle As Style
        Dim nStyle As Style
        Dim bStyle As Style
        Dim TopStyle As Style
        Dim Total As Long
        Dim SR As System.IO.UnmanagedMemoryStream
        Dim Im As Image
        Dim FleName As String

        Im = My.Resources.PLOGO

        Dim imgStream As MemoryStream = New MemoryStream()

        Im.Save(imgStream, System.Drawing.Imaging.ImageFormat.Jpeg)

        TableBySql(sSql, Tb, lResult)
        Sheet = Book.Worksheets(0)

        bStyle = New Style
        With bStyle
            .BackgroundColor = Color.White
            .ForegroundColor = Color.White
            .Pattern = BackgroundType.Solid
        End With

        For nI As Integer = 0 To 10
            For nJ As Integer = 1 To 6
                Sheet.Cells(nI, nJ).SetStyle(bStyle)
            Next
        Next

        Sheet.Pictures.Add(1, 2, imgStream)
        imgStream.Close()

        CellStyle = New Style
        With CellStyle
            .Font.Size = 18
            .Font.Name = "Times New Roman"
            .Font.IsItalic = True
            .Font.IsBold = True

        End With

        Sheet.Cells("B1").PutValue("IRAN LAND & SEA")
        Sheet.Cells.SetRowHeight(0, 15)
        Sheet.Cells("B1").SetStyle(CellStyle)

        Sheet.Cells("F1").PutValue("Date:")
        Sheet.Cells("G1").PutValue(Format(Now.Date, "Short Date"))

        With CellStyle
            .Font.Size = 14
            .Font.IsItalic = False
            .HorizontalAlignment = TextAlignmentType.Center
            .VerticalAlignment = TextAlignmentType.Center
        End With

        Sheet.Cells.Merge(7, 1, 1, 6)
        Sheet.Cells("B8").PutValue("Container Status Summary")
        Sheet.Cells("B8").SetStyle(CellStyle)

        Sheet.Cells.SetColumnWidth(1, 35)

        HStyle = New Style
        With HStyle
            .BackgroundColor = Color.FromArgb(0, 35, 64, 98)
            .ForegroundColor = Color.FromArgb(0, 35, 64, 98)
            .Pattern = BackgroundType.Solid
            .HorizontalAlignment = TextAlignmentType.Center
            .VerticalAlignment = TextAlignmentType.Center
            .Font.Size = 10
            .Font.Name = "Times New Roman"
            .Font.IsBold = True
            .Font.Color = Color.White
            .Borders(BorderType.TopBorder).LineStyle = CellBorderType.Medium
            .Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Medium
        End With

        FStyle = New Style
        With FStyle
            .BackgroundColor = Color.FromArgb(0, 35, 64, 98)
            .ForegroundColor = Color.FromArgb(0, 35, 64, 98)
            .Pattern = BackgroundType.Solid
            .HorizontalAlignment = TextAlignmentType.Center
            .VerticalAlignment = TextAlignmentType.Center
            .Font.Size = 10
            .Font.Name = "Times New Roman"
            .Font.IsBold = True
            .Font.Color = Color.White
            .Borders(BorderType.TopBorder).LineStyle = CellBorderType.Medium
            .Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Medium
        End With

        dStyle = New Style
        With dStyle
            .BackgroundColor = Color.FromArgb(0, 217, 217, 217)
            .ForegroundColor = Color.FromArgb(0, 217, 217, 217)
            .Pattern = BackgroundType.Solid
            .HorizontalAlignment = TextAlignmentType.Left
            .VerticalAlignment = TextAlignmentType.Left
            .Font.Size = 9
            .Font.Name = "Times New Roman"
            .Font.IsBold = True
            .Font.Color = Color.Black
        End With

        nStyle = New Style
        With nStyle
            .BackgroundColor = Color.FromArgb(0, 184, 204, 228)
            .ForegroundColor = Color.FromArgb(0, 184, 204, 228)
            .Pattern = BackgroundType.Solid
            .HorizontalAlignment = TextAlignmentType.Left
            .VerticalAlignment = TextAlignmentType.Left
            .Font.Size = 9
            .Font.Name = "Times New Roman"
            .Font.IsBold = False
            .Font.Color = Color.Black
        End With

        TopStyle = New Style
        With TopStyle
            .Borders(BorderType.TopBorder).LineStyle = CellBorderType.Medium
        End With


        nRow = 11

        For Each Dr In Tb.Rows
            If StorePort <> Dr("DischargeTo") Then
                If Total > 0 Then
                    Sheet.Cells.Merge(nRow, 1, 1, 5)
                    Sheet.Cells(nRow, 1).PutValue("Total:")
                    Sheet.Cells(nRow, 6).PutValue(Format(Total, "###,###"))
                    Sheet.Cells(nRow, 1).SetStyle(FStyle)
                    Sheet.Cells(nRow, 6).SetStyle(FStyle)
                    For nI As Integer = 1 To 6
                        Sheet.Cells(nRow, nI).SetStyle(FStyle)
                    Next
                    FStyle.HorizontalAlignment = TextAlignmentType.Left
                    FStyle.VerticalAlignment = TextAlignmentType.Left
                    Sheet.Cells(nRow, 1).SetStyle(FStyle)
                    FStyle.HorizontalAlignment = TextAlignmentType.Center
                    FStyle.VerticalAlignment = TextAlignmentType.Center
                    Sheet.Cells(nRow, 6).SetStyle(FStyle)
                    Total = 0
                    nRow += 2
                End If

                Sheet.Cells.Merge(nRow, 1, 1, 6)
                Sheet.Cells(nRow, 1).PutValue("Port:" & Dr("DischargeTo"))
                Sheet.Cells(nRow, 1).SetStyle(HStyle)
                For nI As Integer = 1 To 6
                    Sheet.Cells(nRow, nI).SetStyle(HStyle)
                Next
                nRow += 1
                StorePort = Dr("DischargeTo")
                Sheet.Cells(nRow, 1).PutValue("Status")
                Sheet.Cells(nRow, 2).PutValue("ISO Type")
                Sheet.Cells(nRow, 3).PutValue("Size")
                Sheet.Cells(nRow, 4).PutValue("Type")
                Sheet.Cells(nRow, 5).PutValue("Hight")
                Sheet.Cells(nRow, 6).PutValue("Quantity")
                For nI As Integer = 1 To 6
                    Sheet.Cells(nRow, nI).SetStyle(HStyle)
                Next
                nRow += 1
                StorePort = Dr("DischargeTo")
            End If

            If StoreStatus <> Dr("Status") Or Total = 0 Then
                Sheet.Cells(nRow, 1).PutValue(Dr("LastStatus") & "-" & Dr("Status"))
                With dStyle
                    .Borders(BorderType.TopBorder).LineStyle = CellBorderType.Medium
                End With
                Sheet.Cells(nRow, 1).SetStyle(dStyle)
                dStyle.Borders(BorderType.TopBorder).LineStyle = CellBorderType.None
            Else
                Sheet.Cells(nRow, 1).SetStyle(dStyle)
            End If

            Sheet.Cells(nRow, 2).PutValue(Dr("DispName"))
            Sheet.Cells(nRow, 3).PutValue(Dr("CnSize"))
            Sheet.Cells(nRow, 4).PutValue(Dr("CnType"))
            Sheet.Cells(nRow, 5).PutValue(Dr("WHLHeight"))
            Sheet.Cells(nRow, 6).PutValue(Dr("Total"))

            If StoreStatus <> Dr("Status") Then
                With nStyle
                    .Borders(BorderType.TopBorder).LineStyle = CellBorderType.Medium
                End With
                For nI As Integer = 2 To 6
                    Sheet.Cells(nRow, nI).SetStyle(nStyle)
                Next
                With nStyle
                    .Borders(BorderType.TopBorder).LineStyle = CellBorderType.None
                End With
                StoreStatus = Dr("Status")
            Else
                For nI As Integer = 2 To 6
                    Sheet.Cells(nRow, nI).SetStyle(nStyle)
                Next
            End If
            nRow += 1

            For nI As Integer = 2 To 6
                Sheet.Cells(nRow, nI).SetStyle(nStyle)
            Next

            Sheet.Cells(nRow, 1).SetStyle(dStyle)
            nRow += 1
            Total += Dr("Total")

        Next

        If Total > 0 Then
            Sheet.Cells.Merge(nRow, 1, 1, 5)
            Sheet.Cells(nRow, 1).PutValue("Total:")
            Sheet.Cells(nRow, 6).PutValue(Format(Total, "###,###"))
            Sheet.Cells(nRow, 1).SetStyle(FStyle)
            Sheet.Cells(nRow, 6).SetStyle(FStyle)
            For nI As Integer = 1 To 6
                Sheet.Cells(nRow, nI).SetStyle(FStyle)
            Next
            FStyle.HorizontalAlignment = TextAlignmentType.Left
            FStyle.VerticalAlignment = TextAlignmentType.Left
            Sheet.Cells(nRow, 1).SetStyle(FStyle)
            FStyle.HorizontalAlignment = TextAlignmentType.Center
            FStyle.VerticalAlignment = TextAlignmentType.Center
            Sheet.Cells(nRow, 6).SetStyle(FStyle)
            Total = 0
            nRow += 2
        End If

        FleName = General.GenerateRandomFileName("xls")

        Book.Save(FleName)
        Book = Nothing

        Process.Start(FleName)


    End Sub

    Private Sub ButtonUpdateMovement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateMovement.Click


        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Tran As SqlTransaction
        Dim Row As Infragistics.Win.UltraWinGrid.UltraGridRow

        If Me.GridResult.Rows.Count > 0 Then
            If MsgBox("Do you want update recordes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Cnn.Open()
                Cmd = New SqlCommand
                 With Cmd
                    .Connection = Cnn
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "SP_EcsUpdateReportedToWHL"
                    .Parameters.Add(New SqlParameter("@ID", SqlDbType.UniqueIdentifier))
                End With
                Tran = Cnn.BeginTransaction("Ecs")
                Cmd.Transaction = Tran
                Try
                    For Each Row In GridResult.Rows
                        Cmd.Parameters("@ID").Value = Row.Cells(0).Value
                        Cmd.ExecuteNonQuery()
                    Next
                    Tran.Commit()
                    MsgBoxSaveSuccessful()
                Catch ex As Exception
                    Tran.Rollback()
                    MsgBoxSaveFailed()
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub FrmEcsWHLReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AnnualYear.SetLength(4)
        Me.AnnualYear.TextValue = Now.Year.ToString
    End Sub

     
    Private Sub ButtonFUMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFUMA.Click

        Dim TB As New DataTable
        Dim lResult As Boolean

        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)

        Cnn.Open()

        Me.Cursor = Cursors.WaitCursor
        With Cmd
            .CommandText = "SP_FUMAAnnoual"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@YEAR", Me.AnnualYear.GeneralText.Text)
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
            .CommandTimeout = 3000

        End With

        DA.SelectCommand = Cmd
        DA.Fill(TB)

        Me.GridResult.DataSource = TB
        GridNumSeperator(Me.GridResult)

        'Me.Cursor = Cursors.WaitCursor
        'TableBySql("SP_FUMAAnnoual " & Me.AnnualYear.GeneralText.Text & "," & CurrentShippingLine, TB, lResult)
        'Me.GridResult.DataSource = TB


        'With Me.GridResult.DisplayLayout.Bands(0)
        '     .HeaderVisible = True
        '    .Header.Activated = True
        '    .Header.Caption = "FV-MA Annoul Report For " & Me.AnnualYear.TextValue
        '    .Header.Appearance.BackColor = Color.Maroon
        '    .Header.Appearance.ForeColor = Color.Yellow
        '    .Header.Appearance.FontData.Name = "Verdana"
        '    .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
        '    .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        '    .Header.Appearance.FontData.SizeInPoints = 8
        'End With

        Me.Cursor = Cursors.Default


 
    End Sub
End Class