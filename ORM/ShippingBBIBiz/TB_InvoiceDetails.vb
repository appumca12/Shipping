Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InvoiceDetails : Inherits ShippingBiz.TB_InvoiceDetailsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InvoiceDetailsCollection : Inherits ShippingBiz.TB_InvoiceDetailsCollectionOrmTemplate

    End Class

End Namespace