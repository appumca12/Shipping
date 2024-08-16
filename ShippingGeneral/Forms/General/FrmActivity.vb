Imports System.Data
Imports System.Data.SqlClient
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors

Public Class FrmActivity

    Private DsForm As New DataSet
    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        Dim sSql As String
        Dim Command As SqlCommand
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim adapter As New SqlDataAdapter
        Dim Ds As New DataSet

        sSql = "SP_ActivityReport "
        Command = New SqlCommand(sSql, connection)
        Command.CommandText = sSql
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@ddFrom", Me.dFrom.DTOS)
        Command.Parameters.AddWithValue("@ddTo", Me.dTo.DTOS)

        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            adapter.Fill(Ds)
            Ds.AcceptChanges()
        Catch ex As Exception
            connection.Close()
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        Me.GridDetails.DataSource = Ds.Tables(0)
        Me.ChartCmprPorts.DataSource = Ds.Tables(1)
        Me.ChartSharePorts.DataSource = Ds.Tables(1)
        Me.ChartShareLines.DataSource = Ds.Tables(2)

        Me.ChartImpExp.DataSource = Ds.Tables(3)
        Me.ChartImpExpShare.DataSource = Ds.Tables(3)

        Me.ChartCmprPorts.TitleTop.Text = "Compare POL From " & dFrom.DateValue & " To " & dFrom.DateValue
        Me.ChartCmprPorts.TitleBottom.Text = Format(Now.Day, "00") & "/" & Format(Now.Month, "00") & "/" & Now.Year
        Me.ChartCmprPorts.TitleBottom.HorizontalAlign = StringAlignment.Far

        Me.ChartShareLines.TitleTop.Text = "Share Lines From " & dFrom.DateValue & " To " & dFrom.DateValue
        Me.ChartShareLines.TitleBottom.Text = Format(Now.Day, "00") & "/" & Format(Now.Month, "00") & "/" & Now.Year
        Me.ChartShareLines.TitleBottom.HorizontalAlign = StringAlignment.Far

        Me.ChartSharePorts.TitleTop.Text = "Share POL From " & dFrom.DateValue & " To " & dFrom.DateValue
        Me.ChartSharePorts.TitleBottom.Text = Format(Now.Day, "00") & "/" & Format(Now.Month, "00") & "/" & Now.Year
        Me.ChartSharePorts.TitleBottom.HorizontalAlign = StringAlignment.Far

        Me.ChartImpExpShare.TitleTop.Text = "Import VS Export " & dFrom.DateValue & " To " & dFrom.DateValue
        Me.ChartImpExpShare.TitleBottom.Text = Format(Now.Day, "00") & "/" & Format(Now.Month, "00") & "/" & Now.Year
        Me.ChartImpExpShare.TitleBottom.HorizontalAlign = StringAlignment.Far

        With Me.GridDetails.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Voyage Summary:" & Format(Me.dFrom.DateValue, "Short date") & "  To:" & Format(Me.dTo.DateValue, "Short date")
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        GridNumSeperator(Me.GridDetails)

    End Sub
    Private Sub FrmActivity_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.dFrom.InitControl(False, False)
        Me.dTo.InitControl(False, False)
    End Sub
    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick

        If (Me.GridDetails).Rows.Count > 0 Then
            SaveGridToExcel((Me.ChartCmprPorts.DataSource))
        End If

    End Sub
End Class