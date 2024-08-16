Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_PInvoiceDetails : Inherits ShippingBiz.TB_PInvoiceDetailsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_PInvoiceDetailsCollection : Inherits ShippingBiz.TB_PInvoiceDetailsCollectionOrmTemplate

    End Class

End Namespace