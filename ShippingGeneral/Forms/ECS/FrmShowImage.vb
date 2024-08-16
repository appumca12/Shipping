Public Class FrmShowImage

    Private CurrentImg As Image
    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click


        Dim dialog As New SaveFileDialog
        dialog.Filter = "JPG Files (*.jpg)|*.jpg|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"
        dialog.ShowDialog()

        If dialog.FileName <> "" Then
            Try
                CurrentImg.Save(dialog.FileName)
                MsgBox("Save Sucsessful.")
            Catch ex As Exception
                MsgBox("Save Failed.", MsgBoxStyle.Critical)
            End Try
        End If
     
    End Sub

    Public Sub New(ByVal Img As Image)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CurrentImg = Img
        Me.Picture.Image = Img '.GetThumbnailImage(800, 600, AddressOf ThumbNailAbort, Nothing)

    End Sub

    Private Function ThumbNailAbort() As Boolean
        'Do Nothing Here
    End Function
End Class