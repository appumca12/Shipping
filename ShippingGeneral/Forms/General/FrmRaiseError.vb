Public Class FrmRaiseError

    Public Enum ErrMsgtype
        Err
        Warning
    End Enum
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal TB As DataTable, ByRef nErrCount As Byte)

        Dim Row As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Section As String = ""
        Dim IsHideSection As Boolean = True
        Dim drs() As DataRow
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Me.DataSetForm.Tables(0).Merge(TB)
        Me.GridMsgs.DisplayLayout.Bands(0).Columns("MsgType").Hidden = True

        For Each Row In Me.GridMsgs.Rows
            With Row
                If .Cells("MsgType").Value = ErrMsgtype.Err Then
                    .Cells("Message").Appearance.BackColor = Color.Tomato
                    nErrCount += 1
                Else
                    .Cells("Message").Appearance.BackColor = Color.Yellow
                End If
                If .Cells("Section").Text <> Section Then
                    If Section <> "" Then
                        IsHideSection = False
                    Else
                        Section = .Cells("Section").Text
                    End If
                End If
            End With
        Next
        Me.GridMsgs.DisplayLayout.Bands(0).Columns("Section").Hidden = IsHideSection

        drs = TB.Select("MsgType = 0")
        Me.TTLE.Text = drs.Length

        drs = TB.Select("MsgType = 1")
        Me.TTLW.Text = drs.Length


    End Sub
    Public Sub New(ByVal TB As DataTable)
        InitializeComponent()
        Me.GridMsgs.DataSource = TB
    End Sub
    Private Sub CmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        Me.Close()
    End Sub
    Public Sub AddError(ByVal Section As String, ByVal Message As String, ByVal MessageType As ErrMsgtype)

        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dr = Me.DataSetForm.Tables(0).NewRow
        Dr("Section") = Section
        Dr("Message") = Message
        Dr("MsgType") = MessageType
        Me.DataSetForm.Tables(0).Rows.Add(Dr)

        Drs = Me.DataSetForm.Tables(0).Select("MsgType = 0")
        Me.TTLE.Text = Drs.Length

        Drs = Me.DataSetForm.Tables(0).Select("MsgType = 1")
        Me.TTLW.Text = Drs.Length


    End Sub
    Public ReadOnly Property ErrorCount() As Integer
        Get
            Return Me.DataSetForm.Tables(0).Rows.Count
        End Get
    End Property



End Class