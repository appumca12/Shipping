Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Collections
Imports OrmLib

Namespace ShippingBiz
    Public Class Lookups

        Public Sub New(ByVal dsn As String)
            data = New DataManager(dsn)
			RefreshLookups()
        End Sub

        Private data As DataManager

        Public Function RefreshLookups() As DataSet
            Dim sql As New String("")
            Dim t As DataTable
            Dim r As DataRow

            data.QueryCriteria.Clear()

            data.OrderedTables.Clear()

            Dim ds As DataSet = OrmDataSet.NewDataSet()
            data.FillDataSet(sql, ds, True)

            If sql.Length > 0 And ( not t is nothing)  Then Return ds

            Return nothing
        End Function

    End Class
End Namespace