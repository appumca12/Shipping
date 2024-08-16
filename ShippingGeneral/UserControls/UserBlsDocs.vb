Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid
Public Class UserBlsDocs

    Private TB As DataTable
    Private BLNo As String
    Public Sub InitControl()

        TB = New DataTable
        Dim Col As UltraGridColumn
        Tb.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        Tb.Columns.Add(New DataColumn("JobCode", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Job", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("SentTime", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("Result", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("skey", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Show"))
        Me.DocsList.DataSource = Tb
        With DocsList.DisplayLayout.Bands(0)
            .Columns("Skey").Hidden = True
            .Columns("JobCode").Hidden = True
            .Columns("Show").Style = ColumnStyle.Button
            .Columns("Show").Header.Appearance.Image = My.Resources.search_16
            .Columns("SentTime").Format = "dd/MM/yyyy hh:mm"
        End With
        DocsList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        GridNumSeperator(Me.DocsList)

    End Sub

    Public Sub SetDocument(ByVal BlNo As String, ByVal PID As Guid)


        Dim dm As New DataManager(My.Settings.DSN)
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Job As TB_AUTJobs
        Dim JobLog As TB_AUTJobLogs

        dm.QueryCriteria.And(JoinPath.TB_AUTJobLogsDetail.Columns.DocumentID, PID, MatchType.Exact)
        dm.GetTB_AUTJobLogsDetailCollection()


        For Each Dr In dm.DataSet.Tables("TB_AUTJobLogsDetail").Rows
            NewDr = TB.NewRow
            NewDr("ID") = Dr("ID")
            NewDr("Status") = Dr("DocumentStatus")
            NewDr("SentTime") = Dr("SentTime")
            NewDr("Result") = Dr("Result")
            NewDr("sKey") = Dr("skey")
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_AUTJobLogs.Columns.ID, Dr("JobID"), MatchType.Exact)
            JobLog = dm.GetTB_AUTJobLogs()
            NewDr("Job") = "X"
            NewDr("JobCode") = "X"
            If Not JobLog Is Nothing Then
                dm.QueryCriteria.Clear()
                dm.QueryCriteria.And(JoinPath.TB_AUTJobs.Columns.JobCode, JobLog.JobCode, MatchType.Exact)
                Job = dm.GetTB_AUTJobs
                If Not Job Is Nothing Then
                    NewDr("Job") = Job.JobName
                    NewDr("JobCode") = Job.JobCode
                End If
            End If
            TB.Rows.Add(NewDr)
        Next
        GridNumSeperator(Me.DocsList)
        DocsList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.BLNo = BlNo
    End Sub

    Private Sub DocsList_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles DocsList.ClickCellButton

        Dim Path As String
        Path = My.Settings.SentDocFolder & Me.BLNo & "\" & Me.DocsList.ActiveRow.Cells("JobCode").Value & "\" & Me.DocsList.ActiveRow.Cells("sKey").Value & ".html"
        If IO.File.Exists(Path) Then
            Process.Start(Path)
        End If

    End Sub

End Class
