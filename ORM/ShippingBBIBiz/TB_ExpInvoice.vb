Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_ExpInvoice : Inherits ShippingBiz.TB_ExpInvoiceOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ExpInvoiceCollection : Inherits ShippingBiz.TB_ExpInvoiceCollectionOrmTemplate

    End Class

End Namespace