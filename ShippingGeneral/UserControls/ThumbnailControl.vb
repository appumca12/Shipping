Imports System.IO
Public Class ThumbnailControl

    Public Event CustomRefresh()

    Private _Image As Image
    Private _Images As ArrayList
    Private _FileNames As ArrayList
    Private _FileName As String

    Private _FolderPath As String
    Private _UseEditor As Boolean = False
    Private _CntrID As String


    Public Property FolderPath()
        Get
            Return _FolderPath
        End Get
        Set(ByVal value)
            _FolderPath = value
        End Set
    End Property
    Public Property UseEditor() As Boolean
        Get
            Return _UseEditor
        End Get
        Set(ByVal value As Boolean)
            _UseEditor = value
        End Set
    End Property


    Public ReadOnly Property GetSelectedImage() As Image
        Get
            Return _Image
        End Get
    End Property

    Private Sub GenerateThumbs(ByVal ImgPath() As String)
        Try
            Dim Row As Integer = 1
            Dim Col As Integer = 1

            For Counter As Integer = 0 To ImgPath.Length - 1

                If Row >= Me.ImageThumbnail.Width - 100 Then
                    Col = Col + 90
                    Row = 1
                End If

                Dim P As New PictureBox

                AddHandler P.Click, AddressOf PictureBox_Click
                AddHandler P.Click, AddressOf PictureBox_DoubleClick

                P.BackColor = Color.Black
                P.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle

                P.SizeMode = PictureBoxSizeMode.StretchImage
                P.Location = New System.Drawing.Point(Row, Col)

                Row = Row + 80

                P.Name = "PictureBox" & Counter.ToString
                P.Size = New System.Drawing.Size(72, 82)
                P.TabIndex = 0
                P.TabStop = False

                P.Image = Image.FromFile(ImgPath(Counter)).GetThumbnailImage(72, 80, AddressOf ThumbNailAbort, Nothing)

                P.Tag = ImgPath(Counter)

                Me.ImageThumbnail.Controls.Add(P)

                System.Threading.Thread.Sleep(10)
            Next

        Catch ex As Exception
            Throw New Exception("GenerateThumbs", ex)
        End Try
    End Sub
    Public Sub GenerateThumbsFromArryList(ByVal sFolder As String, ByVal aImages As ArrayList, ByVal aFiles As ArrayList)

        Dim Counter As Byte
        _Images = aImages
        _FileNames = aFiles
        _FolderPath = sFolder
        Try
            Dim Row As Integer = 1
            Dim Col As Integer = 1
            Dim Img As Image
            Dim Obj As Object

            For Each Obj In aImages

                Img = DirectCast(Obj, Image)

                If Row >= Me.ImageThumbnail.Width - 100 Then
                    Col = Col + 90
                    Row = 1
                End If

                Dim P As New PictureBox

                AddHandler P.Click, AddressOf PictureBox_Click
                AddHandler P.Click, AddressOf PictureBox_DoubleClick

                P.BackColor = Color.Black
                P.BorderStyle = System.Windows.Forms.BorderStyle.None

                P.SizeMode = PictureBoxSizeMode.StretchImage
                P.Location = New System.Drawing.Point(Row, Col)

                Row = Row + 80

                P.Name = "PictureBox" & Counter.ToString
                P.Size = New System.Drawing.Size(72, 82)
                P.TabIndex = 0
                P.TabStop = False

                P.Image = Img.GetThumbnailImage(72, 80, AddressOf ThumbNailAbort, Nothing) ' Image.FromFile(ImgPath(Counter)).GetThumbnailImage(72, 80, AddressOf ThumbNailAbort, Nothing)

                P.Tag = Counter
                P.Top = 30
                Me.ImageThumbnail.Controls.Add(P)

                System.Threading.Thread.Sleep(10)
                Counter += 1
            Next

        Catch ex As Exception
            Throw New Exception("GenerateThumbs", ex)
        End Try


    End Sub
    Private Function ThumbNailAbort() As Boolean
        'Do Nothing Here
    End Function

    Private Sub PictureBox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim p As PictureBox = CType(sender, PictureBox)
            If Me.UseEditor = True Then
                System.Diagnostics.Process.Start(p.Tag)
            Else

            End If

            _Image = _Images.Item(p.Tag)

        Catch ex As Exception
            '           Throw New Exception("PictureBox_DoubleClick", ex)
        End Try

    End Sub

    Private Sub PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim p As PictureBox = CType(sender, PictureBox)
            Dim CTL As Control
            Dim Dummy As PictureBox

            For Each CTL In Me.ImageThumbnail.Controls
                If TypeOf CTL Is System.Windows.Forms.PictureBox Then
                    Dummy = DirectCast(CTL, PictureBox)
                    Dummy.BorderStyle = Windows.Forms.BorderStyle.None
                End If
            Next

            p.BorderStyle = Windows.Forms.BorderStyle.Fixed3D

            _Image = _Images.Item(p.Tag)
            _Image.Tag = p.Tag

        Catch ex As Exception
            '         Throw New Exception("PictureBox_Click", ex)
        End Try

    End Sub
    Public Sub RemoveImages()

        Dim CTL As Control
        Dim aCtrls As New ArrayList

        For Each CTL In Me.ImageThumbnail.Controls
            If TypeOf CTL Is System.Windows.Forms.PictureBox Then
                aCtrls.Add(CTL)
            End If
        Next

        For Each OBJ As Object In aCtrls
            CTL = DirectCast(OBJ, Control)
            Me.ImageThumbnail.Controls.Remove(CTL)
        Next
        _Image = Nothing

    End Sub
    Public Sub InitControl(ByVal Titel As String)
        Me.ShowHeader.Text = Titel
    End Sub

    Private Property CntrID() As String
        Get
            Return _CntrID
        End Get
        Set(ByVal value As String)
            _CntrID = value
        End Set

    End Property

    Private Sub ButtonShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonShow.Click

        If _Image Is Nothing Then
            Exit Sub
        End If

        Dim Frm As New FrmShowImage(_Image)
        Frm.ShowDialog()

    End Sub

    Private Sub ButtonDownLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownLoad.Click

        Dim dialog As New OpenFileDialog
        Dim cFTP As FTP
        dialog.Filter = "JPG Files (*.jpg)|*.jpg|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"
        dialog.ShowDialog()
        If dialog.FileName <> "" Then
            cFTP = New FTP
            cFTP.UploadFile(_FolderPath, dialog.FileName)
        End If
        RaiseEvent CustomRefresh()

    End Sub

    Private Sub ButtonRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemove.Click
        If _Image Is Nothing Then
            Exit Sub
        End If
        Dim CFTP As New FTP
        Dim lResult As Boolean

        CFTP.DeleteFile(_FolderPath, _FileNames.Item(_Image.Tag), lResult)
        RaiseEvent CustomRefresh()

    End Sub

    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click
        RaiseEvent CustomRefresh()
    End Sub
End Class
