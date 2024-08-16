Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_DetentionBaseDetails : Inherits ShippingBiz.TB_DetentionBaseDetailsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_DetentionBaseDetailsCollection : Inherits ShippingBiz.TB_DetentionBaseDetailsCollectionOrmTemplate

    End Class

End Namespace