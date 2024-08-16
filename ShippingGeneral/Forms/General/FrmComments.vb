Imports System.Windows.Forms
Imports OrmLib
Imports ShippingBiz
Public Class FrmComments
    Enum InwardOutward
        Inward
        Outward
    End Enum
    Private InOut As InwardOutward
    Private DM As DataManager
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim LogDataSet As DataSet
        If InOut = InwardOutward.Inward Then
            Me.BlsComments.GetDocument(DM.DataSet.Tables("TB_InwardBlsComments"))
        Else
            Me.BlsComments.GetDocument(DM.DataSet.Tables("TB_OutwardBlsComments"))
        End If
        Try
            LogDataSet = DM.DataSet.Copy
            DM.CommitAll()
            GenerateLog(LogDataSet)
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBoxGeneral(ex.ToString, "Error On Save Save !")
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmComments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByVal InOut As InwardOutward, ByVal BLID As Guid)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.InOut = InOut
        Me.BlsComments.InitControl(InOut)
    End Sub
    Public Sub SetDocument(ByVal BLID)

        DM = New DataManager(My.Settings.DSN)
        If InOut = InwardOutward.Inward Then
            DM.QueryCriteria.And(JoinPath.TB_InwardBlsComments.Columns.BLID, BLID, MatchType.Exact)
            DM.GetTB_InwardBlsCommentsCollection()
            Me.BlsComments.SetDocument(BLID, DM.DataSet.Tables("TB_InwardBlsComments"))
        Else
            DM.QueryCriteria.And(JoinPath.TB_OutwardBlsComments.Columns.BLID, BLID, MatchType.Exact)
            DM.GetTB_OutwardBlsCommentsCollection()
            Me.BlsComments.SetDocument(BLID, DM.DataSet.Tables("TB_OutwardBlsComments"))
        End If
      End Sub


End Class
