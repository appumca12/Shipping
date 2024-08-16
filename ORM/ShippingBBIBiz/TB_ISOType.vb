Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_ISOType : Inherits ShippingBiz.TB_ISOTypeOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ISOTypeCollection : Inherits ShippingBiz.TB_ISOTypeCollectionOrmTemplate

    End Class

End Namespace