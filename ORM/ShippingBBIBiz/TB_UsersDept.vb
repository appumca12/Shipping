Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_UsersDept : Inherits ShippingBiz.TB_UsersDeptOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_UsersDeptCollection : Inherits ShippingBiz.TB_UsersDeptCollectionOrmTemplate

    End Class

End Namespace