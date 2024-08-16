Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_UsersLine : Inherits ShippingBiz.TB_UsersLineOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_UsersLineCollection : Inherits ShippingBiz.TB_UsersLineCollectionOrmTemplate

    End Class

End Namespace