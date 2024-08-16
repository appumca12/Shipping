Imports System
Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Public Class UserEcsCntrsInsert

    Public Event ClickAccepte()
    Public Event ClickCancel()
    Private TB As New DataTable
    Private Sub ButtonAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAccept.Click
        RaiseEvent ClickAccepte()
    End Sub
    Public Sub IntData(ByVal EcsDate As DateTime)

        Dim DR As DataRow
        TB = New DataTable
        TB.Columns.Add(New DataColumn("CntrNo"))
        TB.Columns.Add(New DataColumn("EventDate", System.Type.GetType("System.DateTime")))
        Me.GridCntrs.DataSource = TB

        For nI As Long = 1 To 500
            DR = TB.NewRow
            DR("EventDate") = EcsDate ' Added for the requirement LINKING INPUTTED DATE IN APPLY CODECO MENU TO ALL PASTED CONTAINERS IMPORTED VIA EXCEL          
            TB.Rows.Add(DR)
        Next

        ' Added for the requirement LINKING INPUTTED DATE IN APPLY CODECO MENU TO ALL PASTED CONTAINERS IMPORTED VIA EXCEL 
        'Begin
        'Me.GridCntrs.DisplayLayout.Bands(0).Columns("EventDate").Style = ColumnStyle.DateTime
        Dim dateColumn As UltraGridColumn = Me.GridCntrs.DisplayLayout.Bands(0).Columns("EventDate")
        dateColumn.Format = "dd-MM-yy hh:mm tt"
        'End
        Me.GridCntrs.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All

    End Sub
   
    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        RaiseEvent ClickCancel()
    End Sub

    Public ReadOnly Property TBCntrs() As DataTable
        Get
            Return TB
        End Get
    End Property

    Public ReadOnly Property AsGateIn() As Boolean
        Get
            Return Me.CheckAsGateIn.Checked
        End Get
    End Property
    Public ReadOnly Property IsFull() As Boolean
        Get
            Return Me.CheckIsFull.Checked
        End Get
    End Property

    Private Sub UltraGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGroupBox1.Click

    End Sub
End Class
