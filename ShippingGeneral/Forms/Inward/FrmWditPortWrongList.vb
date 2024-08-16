Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports OrmLib
Imports ShippingBiz
Public Class FrmWditPortWrongList

    Private PortName As String = ""
    Private portcode As String = ""

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection
        Dim TB As New DataTable
        Dim DA As New SqlDataAdapter

        Cnn = New SqlConnection(My.Settings.DSN)

        With Cmd
            Cmd.CommandText = "Select Tcts_PortCode , PortName From TBL_PC_Ports Where PortName Like '%" & Me.TextBox1.Text & "%'"
            Cmd.CommandType = CommandType.Text
            Cnn.Open()
            Cmd.Connection = Cnn
            DA.SelectCommand = Cmd
            DA.Fill(TB)
            TB.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))
            Me.GridMsgs.DataSource = TB
            For Each Row As UltraGridRow In GridMsgs.Rows
                Row.Cells("Select").Value = False
            Next
            GridMsgs.UpdateData()
            GridMsgs.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With

    End Sub

    Private Sub FrmWditPortWrongList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LablePortName.Text = Me.PortName
    End Sub

    Public Sub New(ByVal PortCode As String, ByVal PortName As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.portcode = PortCode
        Me.PortName = PortName
    End Sub


    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim UpdPortCode As String = ""
        Dim nI As Byte = 0
        Dim LogDataset As DataSet

        GridMsgs.UpdateData()

        For Each Row As UltraGridRow In GridMsgs.Rows
            If Row.Cells("Select").Value = True Then
                UpdPortCode = Row.Cells("Tcts_PortCode").Text
                nI += 1
            End If
        Next
        If nI = 0 Then
            MsgBox("No Any Selection !", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If nI > 1 Then
            MsgBox("Please select 1 port !", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim Dm As New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortCode, PortCode, MatchType.Exact)
        Dm.GetTB_PortsCollection()

        If Dm.DataSet.Tables("TB_Ports").Rows.Count > 0 Then
            Dm.DataSet.Tables("TB_Ports").Rows(0).Item("EDIIPCODE") = UpdPortCode
            LogDataSet = Dm.DataSet.Copy
            Try
                Dm.CommitAll()
                GenerateLog(LogDataset)
                MsgBoxSaveSuccessful()
            Catch ex As Exception
                MsgBoxSaveFailed()
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

End Class