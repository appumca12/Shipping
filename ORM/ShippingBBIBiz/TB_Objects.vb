Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Objects : Inherits ShippingBiz.TB_ObjectsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ObjectsCollection : Inherits ShippingBiz.TB_ObjectsCollectionOrmTemplate

    End Class

End Namespace