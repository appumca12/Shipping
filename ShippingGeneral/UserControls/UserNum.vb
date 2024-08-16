Public Class UserNum

    Inherits System.Windows.Forms.UserControl
    Public Event NumChanged()
    Private lChanged As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GnrlNum As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GnrlNum = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        CType(Me.GnrlNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GnrlNum
        '
        Me.GnrlNum.AutoSize = False
        Me.GnrlNum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GnrlNum.Location = New System.Drawing.Point(0, 0)
        Me.GnrlNum.MaskInput = "{LOC}nn,nnn,nnn,nnn.nn"
        Me.GnrlNum.Name = "GnrlNum"
        Me.GnrlNum.Nullable = True
        Me.GnrlNum.NullText = ""
        Me.GnrlNum.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.GnrlNum.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.GnrlNum.Size = New System.Drawing.Size(104, 23)
        Me.GnrlNum.TabIndex = 0
        Me.GnrlNum.Value = Nothing
        Me.GnrlNum.MaxValue = 999999999999
        '
        'UserNum
        '
        Me.Controls.Add(Me.GnrlNum)
        Me.Name = "UserNum"
        Me.Size = New System.Drawing.Size(104, 23)
        CType(Me.GnrlNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub InitControl(ByVal nInteger As Byte, ByVal nDecimal As Byte)

        Dim sMask As String = ""
        Dim nI As Byte
        Dim nJ As Byte

        For nI = 1 To nInteger
            sMask = "n" & sMask
            nJ = nJ + 1
            If nJ = 3 Then
                sMask = "," & sMask
                nJ = 0
            End If
        Next

        If Mid(sMask, 1, 1) = "," Then
            sMask = Mid(sMask, 2)
        End If

        If nDecimal > 0 Then
            sMask = sMask & "."
            For nI = 1 To nDecimal
                sMask = sMask & "n"
            Next
        End If
        GnrlNum.MaskInput = sMask
        If nDecimal = 0 Then
            GnrlNum.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal
        Else
            GnrlNum.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double
        End If
        GnrlNum.Appearance.BackColorDisabled = My.Settings.TextBackColor
        GnrlNum.Appearance.BackColorDisabled2 = My.Settings.TextBackColor


    End Sub
    Public Property CtrlValue() As Double
        Get
            CtrlValue = Val(GnrlNum.Value)
        End Get
        Set(ByVal Value As Double)
            GnrlNum.Value = Value
            lChanged = False
        End Set
    End Property
    Private Sub GnrlNum_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GnrlNum.Enter

        GnrlNum.BackColor = My.Settings.EditTextBackColor
        GnrlNum.ForeColor = My.Settings.EditTextForcolor
        GnrlNum.SelectAll()

    End Sub
    Private Sub GnrlNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GnrlNum.KeyPress
        If Asc(e.KeyChar) = 13 Then
            '          SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub GnrlNum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GnrlNum.Leave
        GnrlNum.BackColor = My.Settings.TextBackColor
        GnrlNum.ForeColor = My.Settings.TextForcolor
    End Sub
    Private Sub GnrlNum_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GnrlNum.ValueChanged
        lChanged = True
    End Sub
    Public ReadOnly Property Changed()
        Get
            Return lChanged
        End Get
    End Property

End Class
