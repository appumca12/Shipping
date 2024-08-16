Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_ObjectsUser : Inherits ShippingBiz.TB_ObjectsUserOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ObjectsUserCollection : Inherits ShippingBiz.TB_ObjectsUserCollectionOrmTemplate

    End Class

End Namespace