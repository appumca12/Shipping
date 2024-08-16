Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win.UltraWinGrid

Public Class UserFreeTime
    Private TB As DataTable
    Private DM As DataManager
    Public Sub InitTable()
        Dim Dr As DataRow
        TB = New DataTable
        TB.Columns.Add(New DataColumn("BLNO"))

        TB.Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int16")))
        Me.GridData.DataSource = TB
        For nI = 1 To 200
            Dr = TB.NewRow
            TB.Rows.Add(Dr)
        Next
        Me.GridData.Enabled = True

    End Sub
    Public ReadOnly Property TBData() As DataTable
        Get
            Me.GridData.UpdateData()
            Return TB
        End Get
    End Property

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        Dim Dr As DataRow
        Dim LogDataSet As DataSet
        Dim nCount As Int16
        Dim nBls As Int16
        Dim Bls As TB_InwardBLS
        Dim Dscnt As TB_InwardDiscount
        Dim nSkip As Int16

        DM = New DataManager(My.Settings.DSN)


        For Each Dr In TB.Rows
            If NullToValue(Dr("BLNO"), "") <> "" Then
                nCount += 1
                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
                DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Dr("BLNO"), MatchType.Exact)
                Bls = DM.GetTB_InwardBLS
                If Bls Is Nothing Then
                    Dr.RowError = "B/L Not Found !"
                    nSkip += 1
                Else
                    nBls += 1
                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, Bls.ID, MatchType.Exact)
                    Dscnt = DM.GetTB_InwardDiscount
                    If Dscnt Is Nothing Then
                        Dscnt = DM.NewTB_InwardDiscount(Bls)
                        Dscnt.dFreeDays = Int32.Parse(Dr("FreeDays").ToString)
                        Dscnt.IsFDaysAsDiscount = False
                    Else
                        Dscnt.dFreeDays = Int32.Parse(Dr("FreeDays").ToString)
                        Dscnt.IsFDaysAsDiscount = False
                    End If
                End If
            End If
        Next

        If nBls > 0 Then
            Try
                LogDataSet = DM.DataSet.Copy
                DM.CommitAll()
                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
            Catch ex As Exception
                MsgBoxSaveFailed()
            End Try
        Else
            MsgBox("No Any Selection !", MsgBoxStyle.Question)
        End If

    End Sub

    Private Sub GridData_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridData.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub
End Class
