Imports OrmLib
Imports ShippingBiz

Public Class xxBLTools

    Private CnTB As DataTable
    Private dm As DataManager
    Private OrgBL As TB_InwardBLS
    Private DestBl As TB_InwardBLS
    Private Cns As TB_InwardCntrsCollection
    Private Cn As TB_InwardCntrs
    Private IsValid As Boolean = False

    Private Sub FrmBLTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CnTB = New DataTable
        CnTB.Columns.Add(New DataColumn("CntrNo"))
        CnTB.Columns.Add(New DataColumn("CnSize"))
        CnTB.Columns.Add(New DataColumn("CnType"))
        CnTB.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))
        Me.GridCntrs.DataSource = CnTB

    End Sub

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click

        Dim DR As DataRow
        CnTB.Clear()

        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.SourceBL.Text, MatchType.Exact)
        OrgBL = dm.GetTB_InwardBLS

        If OrgBL Is Nothing Then
            MsgBox("No Valid B/L (Source)!")
            IsValid = False
            Exit Sub
        End If

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.DestinationBL.Text, MatchType.Exact)
        DestBl = dm.GetTB_InwardBLS

        If Me.OptionSet.Value <> "C" Then
            If DestBl Is Nothing Then
                MsgBox("No Valid B/L (Destination)")
                IsValid = False
                Exit Sub
            End If
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, OrgBL.ID, MatchType.Exact)
            Cns = dm.GetTB_InwardCntrsCollection
            For Each Cn In Cns
                DR = CnTB.NewRow
                DR("CntrNo") = Cn.CntrNo
                DR("CnType") = Cn.CnType
                DR("CnSize") = Cn.CnSize
                CnTB.Rows.Add(DR)
            Next
            IsValid = True
        Else
            If Not DestBl Is Nothing Then
                MsgBox("Destination B/L already existed")
                IsValid = False
            Else
                IsValid = True
            End If
        End If
    End Sub


    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        If IsValid = False Then
            Exit Sub
        End If

        Select Case OptionSet.Value
            Case "C"
                Call CopyBL()
            Case "S"
                Call SplitBL()
            Case "M"
                Call MergeBL()
        End Select



    End Sub
    Private Sub CopyBL()


        Dim Drs() As DataRow
        Dim DR As DataRow
        Dim NewDr As DataRow
        Dim Ref As Long
        Dim GID As Guid = Guid.NewGuid
        Dim aFld() As String = {"Reference"}
        Dim lResult As Boolean

        Ref = FieldsBySql("SP_GetLastInwardReference '" & CurrentShippingLine & "'", aFld, lResult).Item(0).ToString
        Ref += 1

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_InwardBlsGoods.Columns.BLID, OrgBL.ID, MatchType.Exact)
        dm.GetTB_InwardBlsGoods()

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_InwardBlsNames.Columns.BLID, OrgBL.ID, MatchType.Exact)
        dm.GetTB_InwardBlsNames()

        With dm.DataSet

            Drs = .Tables("TB_InwardBls").Select("ID = '" & OrgBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_InwardBls").NewRow

            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next

            NewDr("ID") = GID
            NewDr("Reference") = Ref
            NewDr("JobNumber") = GenerateJobNumber("I")
            .Tables("TB_InwardBls").Rows.Add(NewDr)

            Drs = .Tables("TB_InwardBlsNames").Select("BLID = '" & OrgBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_InwardBlsNames").NewRow
            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = GID
            .Tables("TB_InwardBlsNames").Rows.Add(NewDr)

        End With


    End Sub

    Private Sub MergeBL()

    End Sub

    Private Sub SplitBL()

    End Sub




    Private Sub GridCntrs_InitializeLayout(sender As System.Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridCntrs.InitializeLayout

    End Sub
End Class