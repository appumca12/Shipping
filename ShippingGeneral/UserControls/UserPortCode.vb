Imports OrmLib
Imports ShippingBiz
Public Class UserPortCode

    Private Dm As DataManager
    Private Port As TB_Ports
    Private ValidPort As Boolean

    Public Sub InitControl(ByVal BColor As Color)
        TxtPortCode.SetLength(5)

        Me.LblPortName.BackColor = BColor
        Me.LblPortName.Appearance.BackColor = BColor
        Me.LblPortName.Appearance.BackColorDisabled = BColor
        Me.LblPortName.Appearance.ForeColorDisabled = My.Settings.EditTextForcolor
        Me.LblPortName.Refresh()
        Me.BackColor = BColor


    End Sub
 
    Public ReadOnly Property IsValidPort() As Boolean

        Get
            Return ValidPort
        End Get

    End Property

    Public Property PortCode() As String
        Get
            If Port Is Nothing Or Me.TxtPortCode.TextValue = "" Then
                Return ""
            Else
                Return Port.PortCode
            End If
            Return Port.PortCode
        End Get
        Set(ByVal value As String)
            SetDocument(value)
        End Set

    End Property


    Private Sub SetDocument(ByVal Value As String)

        ValidPort = False
        Dm = New DataManager(My.Settings.DSN)
        Me.TxtPortCode.TextValue = Value
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortCode, Me.TxtPortCode.TextValue, MatchType.Exact)
        Port = Dm.GetTB_Ports()

        If Not Port Is Nothing Then
            ValidPort = True
            LblPortName.Text = Port.PortName
            If Me.TxtPortCode.TextValue <> Value Then
                Me.TxtPortCode.TextValue = Value
            End If
        End If


    End Sub

    Public Property TextPort() As UserText
        Get
            Return TxtPortCode
        End Get
        Set(ByVal value As UserText)
            TxtPortCode = value
        End Set
    End Property

    Private Sub TxtPortCode_CustomTextChanged() Handles TxtPortCode.CustomTextChanged
        LblPortName.Text = ""
        ValidPort = False

        If Len(TxtPortCode.TextValue) = 5 Then
            SetDocument(TxtPortCode.TextValue)
        End If
    End Sub

End Class
