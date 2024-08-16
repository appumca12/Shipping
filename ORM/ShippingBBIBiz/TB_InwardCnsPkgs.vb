Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InwardCnsPkgs : Inherits ShippingBiz.TB_InwardCnsPkgsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InwardCnsPkgsCollection : Inherits ShippingBiz.TB_InwardCnsPkgsCollectionOrmTemplate

    End Class

End Namespace