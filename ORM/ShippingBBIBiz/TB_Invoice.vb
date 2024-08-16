Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Invoice : Inherits ShippingBiz.TB_InvoiceOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InvoiceCollection : Inherits ShippingBiz.TB_InvoiceCollectionOrmTemplate

    End Class

End Namespace