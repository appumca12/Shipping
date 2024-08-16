Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_DetentionBase : Inherits ShippingBiz.TB_DetentionBaseOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_DetentionBaseCollection : Inherits ShippingBiz.TB_DetentionBaseCollectionOrmTemplate

    End Class

End Namespace