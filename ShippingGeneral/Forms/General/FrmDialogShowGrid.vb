Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Public Class FrmDialogShowGrid

    Private Title As String
    Public Sub New(ByVal FormCaption As String, ByVal GridTitle As String, ByVal Ds As DataSet)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = FormCaption
        Me.GridResult.DataSource = Ds
        Me.Title = GridTitle
        SetTitle()

    End Sub
    Public Sub New(ByVal FormCaption As String, ByVal GridTitel As String, ByVal TB As DataTable)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Text = FormCaption
        Me.GridResult.DataSource = TB
        Me.Title = GridTitel
        SetTitle()


    End Sub

    Private Sub SetTitle()
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = Title
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
    End Sub


    Private Sub FrmDialogShowGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick

        If Me.GridResult.Rows.Count > 0 Then
            SaveGridToExcel(Me.GridResult)
        End If
    End Sub

    
End Class
