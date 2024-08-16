
Imports OrmLib
Imports ShippingBiz

Public Class ClDetentionOutward

    Private Dm As DataManager
    Private TotalDetention As Double
    Private TotalDiscont As Double
    Private lAllReturnBack As Boolean
    Private lHasError As Boolean
    Private BLID As Guid
    Private Result As DataTable

    Public Sub GenerateExportDetention(ByVal BLID As Guid)

        Dim Cns As New TB_InwardCntrsCollection
        Dim Ds As New DataSet
        Dim Dr As DataRow

        lHasError = False
        lAllReturnBack = True

        Me.BLID = BLID
        Dm = New DataManager(My.Settings.DSN)
        Ds = StoredProcedures.SP_DetentionExpByBLID(BLID.ToString)

        For Each Dr In Ds.Tables(0).Rows
            TotalDetention += Dr("Detention")
            If Dr("Status") = "F" Then
                lHasError = True
            End If
            If IsDBNull(Dr("EaDate")) Then
                lAllReturnBack = False
            End If
        Next
        Result = Ds.Tables(0).Copy
        Result.TableName = "Result"

    End Sub

    Public ReadOnly Property IsCntrsReturnBack() As Boolean
        Get
            Return lAllReturnBack
        End Get
    End Property

    Public ReadOnly Property IsCalculateByError() As Boolean
        Get
            Return lHasError
        End Get
    End Property

    Public ReadOnly Property TotalAmount() As Double
        Get
            Return TotalDetention
        End Get
    End Property

    Public ReadOnly Property GetDetetion() As DataTable
        Get
            Return Result
        End Get
    End Property

End Class




