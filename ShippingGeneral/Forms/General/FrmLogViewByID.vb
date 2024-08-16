Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Public Class FrmLogViewByID

    Private ID As String
    Private Sub FrmLogViewByID_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByVal ID As Guid, ByVal ShowName As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Log For " & ShowName
        SetDocumentByID(ID.ToString)

    End Sub
    Public Sub New(ByVal ShowName As String, ByVal ID As Guid, ByVal ParentTable As String, ByVal Child As ArrayList, ByVal ChildPID As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Log For " & ShowName
        SetDocumentWithChild(ID.ToString, ParentTable, Child, ChildPID)

    End Sub
    Private Sub SetDocumentByID(ByVal ID As String)

        Dim Cmd As New SqlCommand("SP_LogByID")
        Dim Cnn As SqlConnection
        Dim DA As SqlDataAdapter
        Dim TB As New DataTable

        With Cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("ID", SqlDbType.VarChar, 36))
            .Parameters(0).Value = ID
        End With


        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.Connection = Cnn

        DA = New SqlDataAdapter
        DA.SelectCommand = Cmd
        DA.Fill(TB)

        For Each dr As DataRow In TB.Rows
            If (Len(Trim(dr("New Data"))) = 36 Or Len(Trim(dr("Old Data"))) = 36) And InStr(UCase(dr("Field")), "ID") > 0 Then
                dr.Delete()
            Else
                If UCase(Mid(dr("Table Name"), 1, 3)) = "TB_" Then
                    dr("Table Name") = Mid(dr("Table Name"), 4)
                End If
            End If
        Next


        Me.UltraGrid1.DataSource = TB
        With Me.UltraGrid1.DisplayLayout.Bands(0)
            .Columns(0).MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            .Columns(1).MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            .Columns(2).MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            .Columns(3).MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            .Columns(3).MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
        End With

    End Sub

    Private Sub SetDocumentWithChild(ByVal IDas As String, ByVal ParrentTable As String, ByVal Child As ArrayList, ByVal ChildPID As String)

        Dim Dm As DataManager
        Dim Tb As DataTable
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection
        Dim DA As New SqlDataAdapter
        Dim Dr As DataRow
        Dim LogDr As DataRow
        Dim TBLog As DataTable
        Dim NewDr As DataRow

        Dim TBTemp As New DataTable("Temp")
        TBTemp.Columns.Add(New DataColumn("TBName", System.Type.GetType("System.String")))
        TBTemp.Columns.Add(New DataColumn("ID", System.Type.GetType("System.String")))


        Dim TBResult As DataTable
        'TBResult.Columns.Add(New DataColumn("TBName", System.Type.GetType("System.String")))
        'TBResult.Columns.Add(New DataColumn("Time", System.Type.GetType("System.DateTime")))
        'TBResult.Columns.Add(New DataColumn("Action", System.Type.GetType("System.String")))
        'TBResult.Columns.Add(New DataColumn("User", System.Type.GetType("System.String")))
        'TBResult.Columns.Add(New DataColumn("Field", System.Type.GetType("System.String")))
        'TBResult.Columns.Add(New DataColumn("NewValue", System.Type.GetType("System.String")))
        'TBResult.Columns.Add(New DataColumn("OldValue", System.Type.GetType("System.String")))

        With Cnn
            .ConnectionString = My.Settings.DSN
            .Open()
        End With

        With Cmd
            .CommandType = CommandType.Text
            .Connection = Cnn
        End With

        Tb = New DataTable
        Cmd.CommandText = "Select ID from " & ParrentTable & " Where ID = '" & IDas & "'"
        DA.SelectCommand = Cmd
        DA.Fill(Tb)
        For Each Dr In Tb.Rows
            NewDr = TBTemp.NewRow
            NewDr("TBName") = ParrentTable
            NewDr("ID") = Dr("ID")
            TBTemp.Rows.Add(NewDr)
        Next

        For Each S As String In Child
            Tb = New DataTable
            Cmd.CommandText = "Select ID from " & S & " Where " & ChildPID & " = '" & IDas & "'"
            DA.SelectCommand = Cmd
            DA.Fill(Tb)
            For Each Dr In Tb.Rows
                NewDr = TBTemp.NewRow
                NewDr("TBName") = S
                NewDr("ID") = Dr("ID")
                TBTemp.Rows.Add(NewDr)
            Next
        Next

        Cmd = New SqlCommand
        Cmd.Connection = Cnn
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_LogSingelByID"
        Cmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.VarChar, 36))


        For Each Dr In TBTemp.Rows
            Cmd.Parameters(0).Value = Dr("ID")
            Cmd.CommandType = CommandType.StoredProcedure
            DA.SelectCommand = Cmd
            TBLog = New DataTable
            DA.Fill(TBLog)
            If TBResult Is Nothing Then
                TBResult = TBLog.Copy
            Else
                For Each LogDr In TBLog.Rows
                    TBResult.ImportRow(LogDr)
                Next
            End If
        Next

        For Each Dr In TBResult.Rows
            If (Len(Trim(Dr("New Data"))) = 36 Or Len(Trim(Dr("Old Data"))) = 36) And InStr(UCase(Dr("Field")), "ID") > 0 Then
                Dr.Delete()
            Else
                If UCase(Mid(Dr("Table Name"), 1, 3)) = "TB_" Then
                    Dr("Table Name") = Mid(Dr("Table Name"), 4)
                End If
            End If
        Next


        Me.UltraGrid1.DataSource = TBResult
        With Me.UltraGrid1.DisplayLayout.Bands(0)

            .Columns(0).MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            .Columns(1).MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            .Columns(2).MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            .Columns(2).Format = "dd/MM/yyyy HH:mm"

            .Columns(3).MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            .Columns(3).MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
        End With

    End Sub

    Private Sub UserMenuItem1_CustomToExcelClick() Handles UserMenuItem1.CustomToExcelClick
       
        If Me.UltraGrid1.Rows.Count > 0 Then
            SaveGridToExcel(Me.UltraGrid1)
        End If

    End Sub
End Class