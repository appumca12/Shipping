Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.Misc
Imports System.Text


Public Class UserComboVoyage

    Private dm As DataManager
    Private Voys As TB_VoyageCollection
    Private VslId As Guid
    Private WithEvents UVessel As New UserComboVessel

    Public Sub InitControl(ByVal BColor As Color)
        Me.BackColor = bColor
    End Sub
    Public Sub InitControl(ByVal BColor As Color, ByVal Vessel As UserComboVessel)
        UVessel = Vessel
        Me.BackColor = BColor
    End Sub

    Private Sub CmbVoyage_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        CmbVoyage.BackColor = My.Settings.EditTextBackColor
        CmbVoyage.ForeColor = My.Settings.EditTextForcolor
    End Sub

    Private Sub CmbVoyage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            '         SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CmbVoyage_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CmbVoyage.BackColor = My.Settings.TextBackColor
        CmbVoyage.ForeColor = My.Settings.TextForcolor
    End Sub

    Private Sub SetDocumentByVoyageID(ByVal VoyId As Guid)

        Dim Voy As TB_Voyage
        Dim VslID As Guid

        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, VoyId, MatchType.Exact)
        Voy = dm.GetTB_Voyage

        If Not Voy Is Nothing Then
            VslID = Voy.VesselID
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.VesselID, VslID, MatchType.Exact)
            Voys = dm.GetTB_VoyageCollection()
            Me.CmbVoyage.DataSource = dm.DataSet.Tables("TB_Voyage")
            With Me.CmbVoyage
                .DataSource = dm.DataSet.Tables("TB_Voyage")
                .ValueMember = "ID"
                .DisplayMember = "VoyageNo"
            End With
        End If

        If dm.DataSet.Tables("TB_Voyage").Rows.Count = 0 Then
            Me.CmbVoyage.Text = ""
            Me.UVessel.VesselID = System.Guid.NewGuid
        Else
            Me.CmbVoyage.Text = Voy.VoyageNo
            Me.UVessel.VesselID = Voy.VesselID
        End If

        SetToolTip()

    End Sub

    Public Sub FillVoyage(ByVal VesselId As Guid)

        If VesselId = VslId Then
            Exit Sub
        Else
            VslId = VesselId
        End If
        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.VesselID, VesselId, MatchType.Exact)
        Voys = dm.GetTB_VoyageCollection()
        Me.CmbVoyage.DataSource = dm.DataSet.Tables("TB_Voyage")
        With Me.CmbVoyage
            .DataSource = dm.DataSet.Tables("TB_Voyage")
            .ValueMember = "ID"
            .DisplayMember = "VoyageNo"
        End With
        Me.CmbVoyage.Text = ""

    End Sub

    Public Property VoyageID() As Guid
        Get
            Return GetDocumentID()
        End Get
        Set(ByVal value As Guid)
            SetDocumentByVoyageID(value)
        End Set
    End Property

    Private Function GetDocumentID() As Guid


        Dim voy As TB_VoyageCollection

        If Not Voys Is Nothing Then
            voy = Voys.FilterByVoyageNo(Me.CmbVoyage.Text)
            If voy.Count = 0 Then
                Return Guid.Empty
            Else
                Return voy(0).ID
            End If
        Else
            Return Guid.Empty
        End If

    End Function

    Public ReadOnly Property GetVesselID() As Guid

        Get
            If Not Voys Is Nothing Then
                If Voys.Count = 0 Then
                    Return Guid.Empty
                Else
                    Dim Voy As TB_Voyage
                    Voy = Voys.FindByID(GetDocumentID)
                    If Voy Is Nothing Then
                        Return Guid.Empty
                    Else
                        Return Voy.VesselID
                    End If
                End If
            Else
                Return Guid.Empty

            End If
        End Get

    End Property

    Public Function GetDocument() As TB_Voyage

        Dim voy As TB_VoyageCollection
        If Not Voys Is Nothing Then
            voy = Voys.FilterByVoyageNo(Me.CmbVoyage.Text)
            If voy.Count = 0 Then
                Return Nothing
            Else
                Return voy(0)
            End If
        Else
            Return Nothing
        End If

    End Function
    Private Sub UVessel_CustomVesselChanged() Handles UVessel.CustomVesselChanged
        FillVoyage(UVessel.VesselID)
    End Sub

    Public ReadOnly Property VesselName() As String
        Get
            Return UVessel.VesselName
        End Get
    End Property
    

    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click

        Dim DummyID As Guid = VslId
        VslId = Guid.NewGuid
        FillVoyage(DummyID)

    End Sub

    Private Sub SetToolTip()

        Dim toolTipInfo As UltraToolTipInfo = UltraToolTipManager1.GetUltraToolTip(Me.CmbVoyage)
        Dim sb As StringBuilder = New StringBuilder()
        Dim Sof As TB_SOF

        toolTipInfo.ToolTipTitle = "S.O.F Details"

        If Me.CmbVoyage.Text <> "" Then
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, VoyageID, MatchType.Exact)
            Sof = dm.GetTB_SOF

            sb.Length = 0
            If Not Sof Is Nothing Then
                sb.Append("Arrival: " & Sof.Arrival.ToString)
                sb.Append(Environment.NewLine)
                sb.Append("Commence Dischare:" & Sof.DschCmnc.ToString)
                sb.Append(Environment.NewLine)
                sb.Append("Complet Dischare:" & Sof.DschCmpl.ToString)
                sb.Append(Environment.NewLine)
                sb.Append("Commence Load:" & Sof.DschCmnc.ToString)
                sb.Append(Environment.NewLine)
                sb.Append("Complet Load:" & Sof.DschCmpl.ToString)
                sb.Append(Environment.NewLine)
                sb.Append("Saild:" & Sof.Sailed.ToString)
            End If
        End If
        toolTipInfo.ToolTipText = sb.ToString()

    End Sub

    Private Sub UserComboVoyage_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        Me.UltraToolTipManager1.ShowToolTip(Me.CmbVoyage)
    End Sub
  
End Class
