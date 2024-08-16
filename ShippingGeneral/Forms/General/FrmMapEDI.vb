Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid

Public Class FrmMapEDI
    Private EDI As New EDICls
    Private FileContent As EDIContent
    Private EdiType As EType
    Private Ds As DataSet
    Private TBResult As New DataTable
    Private Sub MenuItem_CustomOpenFileClick() Handles MenuItem.CustomOpenFileClick

        Dim Dialog As New OpenFileDialog

        If EdiType = EType.XMLType Then
            Dialog.Filter = "XML Files (*.XML)|*.XML"
        Else
            Dialog.Filter = "Text Files (*.txt)|*.txt"
        End If
        Dialog.ShowDialog()
        If Dialog.FileName <> "" Then
            RestorDataFromFile(Dialog.FileName)
            Me.GridResult.DisplayLayout.Bands(0).Columns("ID").Hidden = True
            Me.GridResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        End If

    End Sub

    Public Sub New(ByVal EdiType As EType, ByVal FileContent As EDIContent)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.EdiType = EdiType
        Me.FileContent = FileContent

    End Sub

    Private Sub RestorDataFromFile(ByVal FleName)

        EDI = New EDICls
        Ds = New DataSet
        If Me.FileContent = EDIContent.InwardData Then
            EDI.RestoreXMLInwardDataPart1(FleName, Me.EdiType, Me.GridResult, Ds, TBResult)
        End If


    End Sub

    Private Sub MenuItem_CustomProcess() Handles MenuItem.CustomProcess


        EDI = New EDICls
        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If
        EDI.RestoreXMLInwardDataPart2(Ds, TBResult)


    End Sub

    Private Sub GridResult_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridResult.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
    End Sub

End Class