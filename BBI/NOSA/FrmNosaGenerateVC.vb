Public Class FrmNosaGenerateVC

    Private Sub FrmNosaGenerateVC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Voyage.InitControl(My.Settings.TextBackColor, Me.Vessel)
        Me.Vessel.InitControl(My.Settings.TextBackColor)
    End Sub

    Private Sub StripButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StripButtonPickup.Click

        Dim sSql As String
        Dim lresult As Boolean
        Dim TB As New DataTable
        sSql = "select bl.BlNo , dbo.FC_GetClientNameWithClntID(bl.ClientID) Clinet , " & _
               "(select Top 1 isnull(accounta,'????') " & _
               "from TB_Clients " & _
               "Where ID = bl.ClientID) Account " & _
               "from TB_InwardBLS bl " & _
               "Where VoyageID = '" & Me.Voyage.VoyageID.ToString & "'"

        TableBySql(sSql, TB, lresult)
        Me.GridData.DataSource = TB

    End Sub
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click

        If Me.GridData.Rows.Count = 0 Then
            MsgBoxGeneral("No Any Data For Export")
            Exit Sub
        End If
        SaveGridToExcel(Me.GridData)

    End Sub
    Private Sub StripButtonPickupExp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles StripButtonPickup.Click

        Dim sSql As String
        Dim lresult As Boolean
        Dim TB As New DataTable
        sSql = "select bl.BlNo , dbo.FC_GetClientNameWithClntID(bl.ClientID) Clinet , " & _
               "(select Top 1 isnull(accounta,'????') " & _
               "from TB_Clients " & _
               "Where ID = bl.ClientID) Account " & _
               "from TB_OutwardBLS bl " & _
               "Where VoyageID = '" & Me.Voyage.VoyageID.ToString & "'"

        TableBySql(sSql, TB, lresult)
        Me.GridData.DataSource = TB

    End Sub

    Private Sub StripButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StripButtonSave.Click

        If Me.GridData.Rows.Count = 0 Then
            Exit Sub
        End If
        Call Generate()

    End Sub

    Private Sub Generate()

        Dim CLGen As New CLNosa
        Dim DLG As New SaveFileDialog
        Dim sResult As String
      
        DLG.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        DLG.ShowDialog()

        If DLG.FileName <> "" Then
            CLGen.GenerateArrival(Me.Voyage.VoyageID.ToString, sResult)
            Dim SW As New IO.StreamWriter(DLG.FileName)
            SW.Write(StripControlChars(sResult, False))
            SW.Flush()
            SW.Close()
            MsgBox("File Generate Successful")
        End If
    End Sub
 

    Private Sub GenerateExp()

        Dim CLGen As New CLNosa
        Dim DLG As New SaveFileDialog
        Dim sResult As String

        DLG.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        DLG.ShowDialog()

        If DLG.FileName <> "" Then
            CLGen.GenerateDepature(Me.Voyage.VoyageID.ToString, sResult)
            Dim SW As New IO.StreamWriter(DLG.FileName)
            SW.Write(StripControlChars(sResult, False))
            SW.Flush()
            SW.Close()
            MsgBox("File Generate Successful")
        End If
    End Sub

End Class