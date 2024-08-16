Public Class ClDetentionNew

#Region " Internal Variables"

    Private BLID As Guid
    Private nToBePaidDetentionUsd As Double
    Private nToBePaidDetentionIrr As Long
    Private nToBePaidDamageCostIrr As Long
    Private nToBePaidDamageCostUsd As Double



    Private lFinishedByError As Boolean

#End Region

#Region " Public Methodes"

    Public Sub New(ByVal BLID As Guid)

        Me.BLID = BLID






    End Sub

    Public Sub New(ByVal BLID As Guid, ByVal Cntrno As String)

    End Sub


#End Region

#Region " Internal Methods"

#End Region

#Region " Misc Properties"

    Public ReadOnly Property FinishedByError() As Boolean
        Get
            Return lFinishedByError
        End Get
    End Property

    Public ReadOnly Property ErrorList() As Array
        Get

        End Get
    End Property



#End Region

#Region " To Be Paid Properties"

    Public ReadOnly Property ToBePaidDetentionUsd() As Double
        Get
            Return nToBePaidDetentionUsd
        End Get
    End Property

    Public ReadOnly Property ToBePaidDetentionIrr() As Long
        Get
            Return nToBePaidDetentionIrr
        End Get
    End Property


    Public ReadOnly Property ToBePaidDamageCostIrr() As Long
        Get
            Return nToBePaidDamageCostIrr
        End Get
    End Property

    Public ReadOnly Property ToBePaidDamageCostUsd() As Double
        Get
            Return nToBePaidDamageCostUsd
        End Get
    End Property
#End Region

#Region " Paid Properties"

    Public ReadOnly Property PaidDetentionUsd() As Double
        Get

        End Get
    End Property

    Public ReadOnly Property PaidDetentionIrr() As Long
        Get

        End Get
    End Property

    Public ReadOnly Property PaidDamageCostIrr() As Long
        Get

        End Get
    End Property

    Public ReadOnly Property PaidDamageCostUsd() As Double
        Get

        End Get
    End Property
#End Region

#Region " Settelments Properties"


    Public ReadOnly Property IsSettelWithClient() As Boolean
        Get

        End Get
    End Property

    Public ReadOnly Property IsSettelWithLine() As Boolean
        Get

        End Get
    End Property

    Public ReadOnly Property SettelDateWithClient() As Date
        Get

        End Get
    End Property

    Public ReadOnly Property SettelDateWithLine() As Date
        Get

        End Get
    End Property

#End Region


   
End Class
