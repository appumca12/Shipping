Imports System.IO
Public Class FrmShowDocuments

    Public Sub New(ByVal HtmlContent As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Browser.DocumentText = HtmlContent

    End Sub
End Class