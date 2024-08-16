Public Class UserGnrlDate

    Inherits System.Windows.Forms.UserControl

    Public Event DateChanged()
    Private WithTime As Boolean
    Private InitValue As Date
    Private lShowTime As Boolean

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
    Friend WithEvents GnrlDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GnrlDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        CType(Me.GnrlDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GnrlDate
        '
        Me.GnrlDate.AutoSize = False
        Me.GnrlDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GnrlDate.Location = New System.Drawing.Point(0, 0)
        Me.GnrlDate.MaskInput = ""
        Me.GnrlDate.Name = "GnrlDate"
        Me.GnrlDate.Size = New System.Drawing.Size(114, 24)
        Me.GnrlDate.TabIndex = 0
        Me.GnrlDate.Value = Nothing
        '
        'UserGnrlDate
        '
        Me.Controls.Add(Me.GnrlDate)
        Me.Name = "UserGnrlDate"
        Me.Size = New System.Drawing.Size(114, 24)
        CType(Me.GnrlDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metods"

    Public Sub InitControl(ByVal lShowTime As Boolean, ByVal lCheckDate As Boolean)

        Dim dtfi As System.Globalization.DateTimeFormatInfo
        Dim sMask As String

        dtfi = New System.Globalization.DateTimeFormatInfo()

        If lShowTime = True Then
            GnrlDate.MaskInput = "{date} {time}"
        Else
            GnrlDate.MaskInput = "{date}"
        End If


        'If lShowTime Then
        '    GnrlDate.MaskInput = "{LOC}dd/mm/yyyy hh:mm"
        'Else
        '    GnrlDate.MaskInput = "{LOC}dd/mm/yyyy"
        'End If

        WithTime = lShowTime
        GnrlDate.Appearance.ForeColorDisabled = My.Settings.TextForcolor
        GnrlDate.Appearance.BackColorDisabled = My.Settings.TextBackColor

    End Sub

    Private Sub GnrlDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GnrlDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            '          SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub GnrlDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GnrlDate.Enter
        GnrlDate.ForeColor = My.Settings.EditTextForcolor
        GnrlDate.BackColor = My.Settings.EditTextBackColor
    End Sub

    Private Sub GnrlDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GnrlDate.Leave
        GnrlDate.ForeColor = My.Settings.TextForcolor
        GnrlDate.BackColor = My.Settings.TextBackColor
        RaiseEvent DateChanged()
    End Sub
    Public Property ShowTime() As Boolean
        Get
            Return lShowTime
        End Get
        Set(ByVal value As Boolean)
            lShowTime = value
            Dim dtfi As System.Globalization.DateTimeFormatInfo
            Dim sMask As String

            dtfi = New System.Globalization.DateTimeFormatInfo()

            If lShowTime = True Then
                sMask = "{LOC}" & dtfi.ShortDatePattern.ToString.ToLower & " hh:mm"
            Else
                sMask = "{LOC}" & dtfi.ShortDatePattern.ToString.ToLower
            End If
            GnrlDate.MaskInput = sMask
            'If lShowTime Then
            '    GnrlDate.MaskInput = "{LOC}dd/mm/yyyy hh:mm"
            'Else
            '    GnrlDate.MaskInput = "{LOC}dd/mm/yyyy"
            'End If
        End Set
    End Property
#End Region

#Region "Properties"

    Public ReadOnly Property DTOS() As String
        Get
            Try
                If WithTime Then
                    DTOS = Format(CDate(GnrlDate.Text), "yyyyMMddHHmm")
                Else
                    DTOS = Format(CDate(GnrlDate.Text), "yyyyMMdd")
                End If
            Catch Exp As Exception
                DTOS = ""
            End Try
        End Get

    End Property

    Public Property DateValue() As String
        Get
            Return GnrlDate.Value
        End Get
        Set(ByVal Value As String)
            Try
                InitValue = Value
                GnrlDate.Text = Value
            Catch Exp As Exception

            End Try
        End Set
    End Property

    Public Function GetSqlDateTime() As SqlTypes.SqlDateTime

        Dim DateWithTm As New SqlTypes.SqlDateTime(Me.GnrlDate.DateTime.Year, Me.GnrlDate.DateTime.Month, Me.GnrlDate.DateTime.Day, Me.GnrlDate.DateTime.Hour, Me.GnrlDate.DateTime.Minute, Me.GnrlDate.DateTime.Second)
        Dim DateOnly As New SqlTypes.SqlDateTime(Me.GnrlDate.DateTime.Year, Me.GnrlDate.DateTime.Month, Me.GnrlDate.DateTime.Day)

        If WithTime = True Then
            Return DateWithTm
        Else
            Return DateOnly
        End If
        
    End Function


#End Region
 
    Private Sub GnrlDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GnrlDate.ValueChanged

    End Sub
   
    
End Class
