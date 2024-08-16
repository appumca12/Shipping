Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.Misc
Imports System.Text


Public Class UserComboVessel

    Public Event CustomVesselChanged()
    Private dm As DataManager
    Private Vessel As TB_Vessels
    Private Vessels As TB_VesselsCollection

    Public Sub InitControl(ByVal bColor As Color)

        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.VesselCode, "", MatchType.Greater)
        Vessels = dm.GetTB_VesselsCollection()

        Me.BackColor = bColor

        With Me.CmbVessel
            .Sorted = True
            .DataSource = dm.DataSet.Tables("TB_Vessels")
            .DisplayMember = "VesselName"
            .ValueMember = "ID"
            .Text = ""
        End With

    End Sub

    Private Sub CmbVessel_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbVessel.Enter
        CmbVessel.BackColor = My.Settings.EditTextBackColor
        CmbVessel.ForeColor = My.Settings.EditTextForcolor
    End Sub

    Private Sub CmbVessel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            '         SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CmbVessel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbVessel.Leave
        CmbVessel.BackColor = My.Settings.TextBackColor
        CmbVessel.ForeColor = My.Settings.TextForcolor
    End Sub

    Public Property VesselID() As Guid

        Get

            If Me.CmbVessel.Text = "" Then
                Return Guid.Empty
            Else
                Try
                    Return Me.CmbVessel.SelectedItem(0)
                Catch ex As Exception
                    Return Guid.Empty
                End Try
            End If

        End Get

        Set(ByVal value As Guid)

            SetDocument(value)

        End Set

    End Property

    Private Sub SetDocument(ByVal ID As Guid)

        If ID = Guid.Empty Then
            Me.CmbVessel.Text = ""
        Else
            If Not Vessels Is Nothing Then
                Vessel = Vessels.FindByID(ID)
                If Vessel Is Nothing Then
                    Me.CmbVessel.Text = ""
                Else
                    Me.CmbVessel.Text = Vessel.VesselName
                End If
            Else
                Me.CmbVessel.Text = ""
            End If
        End If
        SetTooltip()
    End Sub

    Private Sub CmbVessel_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbVessel.Validated

        RaiseEvent CustomVesselChanged()

    End Sub

    Public ReadOnly Property VesselName() As String
        Get
            Return Me.CmbVessel.Text
        End Get
    End Property

    Private Sub CmbVessel_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CmbVessel.MouseDoubleClick
        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.VesselCode, "", MatchType.Greater)
        Vessels = dm.GetTB_VesselsCollection()
        With Me.CmbVessel
            .Sorted = True
            .DataSource = dm.DataSet.Tables("TB_Vessels")
            .DisplayMember = "VesselName"
            .ValueMember = "ID"
            .Text = ""
        End With
    End Sub

    Private Sub CmbVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbVessel.SelectedIndexChanged

    End Sub

    Private Sub CmbVessel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CmbVessel.MouseDown

        If e.Button.ToString = "Right" Then
            Me.Cursor = Cursors.WaitCursor
            Vessels = dm.GetTB_VesselsCollection()
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click
        InitControl(Me.BackColor)
    End Sub

    Private Sub SetToolTip()


        Dim toolTipInfo As UltraToolTipInfo = UltraToolTipManager1.GetUltraToolTip(Me.CmbVessel)
        Dim sb As StringBuilder = New StringBuilder()

        toolTipInfo.ToolTipTitle = "Vessel Code"

        If Me.CmbVessel.Text <> "" Then
            sb.Append("Vessel Code: " & Vessel.VesselCode)
        End If
        toolTipInfo.ToolTipText = sb.ToString()
    End Sub

    Private Sub UserComboVessel_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        Me.UltraToolTipManager1.ShowToolTip(Me.CmbVessel)
    End Sub
End Class
