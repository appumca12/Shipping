Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win

Public Class FrmCalculationBase
    Private dm As DataManager

    Private Sub FrmCalculationBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        dm = New DataManager(My.Settings.DSN)

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_CalculationBase.Columns.IsTaxDutyJoin, False, MatchType.IsNotNull)
        calculationBase = dm.GetTB_CalculationBase

        With calculationBase
            Me.ExchangeRateInward.Value = .ExchangeRateInward
            Me.ExchangeRateOutward.Value = .ExchangeRateOutward
            Me.DetentionInwardStartTime.Value = .DetentionInwardStartTime
            Me.DetentionOutwardStartTime.Value = .DetentionOutwardStartTime
            Me.TaxDutyInward.Value = .TaxDutyInward
            Me.TaxDutyOutwardBase.Value = .TaxDutyOutward
            Me.IsTaxDutyJoin.Checked = .IsTaxDutyJoin
            Me.ReferenceFormula.Text = .ReferenceFormula
            Me.InvoiceFormula.Text = .InvoiceFormula
        End With

        'Dim Cal As New CLCalculationBase(CLCalculationBase.CalculationType.ArrivalNotice, Guid.NewGuid, "THC")
        'Dim A, B As Double
        'Cal.TaxDutyCal(A, B)

    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim LogDataSet As New DataSet
        With calculationBase

            .ExchangeRateInward = Me.ExchangeRateInward.Value
            .ExchangeRateOutward = Me.ExchangeRateOutward.Value
            .DetentionInwardStartTime = Me.DetentionInwardStartTime.Value
            .DetentionOutwardStartTime = Me.DetentionOutwardStartTime.Value
            .TaxDutyInward = Me.TaxDutyInward.Value
            .TaxDutyOutward = Me.TaxDutyOutwardBase.Value
            .IsTaxDutyJoin = Me.IsTaxDutyJoin.Checked
            .ReferenceFormula = Me.ReferenceFormula.Text
            .InvoiceFormula = Me.InvoiceFormula.Text
            Try
                LogDataSet = dm.DataSet.Copy
                dm.CommitAll()
                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
            Catch ex As Exception
                General.MsgBoxSaveFailed()
                MessageBox.Show(ex.ToString)
            End Try


        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim A, B As Double
        Dim GID As New Guid("F18F2516-62A7-47BB-9067-8F07265A5722")
        Dim Cal As New CLCalculationBase()

        'If Cal.TaxDutyCal(A, B) = False Then
        '    MsgBox(Cal.GetException)
        'End If

        If Cal.GetDetentionOutwardEndTime(GID, "CAIU8334921") = True Then
            MsgBox(Cal.DateOf)
        Else
            MsgBox(Cal.GetException)

        End If

        ' Cal = new CLCalculationBase(


    End Sub

    Private Sub ExchangeRateOutward_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExchangeRateOutward.ValueChanged

    End Sub

    Private Sub ButtonShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonShow.Click

        MsgBox(GenerateJobNumber("I"))


    End Sub



End Class