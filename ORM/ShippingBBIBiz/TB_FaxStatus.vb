Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_FaxStatus : Inherits ShippingBiz.TB_FaxStatusOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_FaxStatusCollection : Inherits ShippingBiz.TB_FaxStatusCollectionOrmTemplate

    End Class

End Namespace