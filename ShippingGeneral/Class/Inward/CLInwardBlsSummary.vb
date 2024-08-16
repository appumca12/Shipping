Imports OrmLib
Imports ShippingBiz
Public Class CLInwardBlsSummary

    Private Result As New DataTable

    Public Sub New(ByVal BLID As Guid)

        Dim dm As New DataManager(My.Settings.DSN)
        Dim ds As New DataSet
        Dim Cns As String = ""

        ds = StoredProcedures.SP_InwardBlsSummary(BLID.ToString)
        Result = ds.Tables(0).Copy
        Result.TableName = "Result"

        If Result.Rows.Count > 0 Then
            InwardCntrsCount(BLID, Cns)
            Result.Rows(0).Item("Totalcntrs") = Cns
        End If

    End Sub

    Public ReadOnly Property GetResult() As DataTable
        Get
            Return Result
        End Get
    End Property
    Public ReadOnly Property BlNo() As String

        Get
            If Result.Rows.Count > 0 Then
                Return Result.Rows(0).Item("BlNo")
            Else
                Return ""
            End If
        End Get

    End Property

    Public ReadOnly Property VesselName() As String

        Get
            If Result.Rows.Count > 0 Then
                Return Result.Rows(0).Item("VesselName")
            Else
                Return ""
            End If
        End Get

    End Property

    Public ReadOnly Property VoyageNo() As String

        Get
            If Result.Rows.Count > 0 Then
                Return Result.Rows(0).Item("VoyageNo")
            Else
                Return ""
            End If
        End Get

    End Property

    Public ReadOnly Property Cntrs() As String

        Get
            If Result.Rows.Count > 0 Then
                Return Result.Rows(0).Item("TotalCntrs")
            Else
                Return ""
            End If
        End Get

    End Property




End Class
