Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_PInvoice : Inherits ShippingBiz.TB_PInvoiceOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_PInvoiceCollection : Inherits ShippingBiz.TB_PInvoiceCollectionOrmTemplate

    End Class

End Namespace