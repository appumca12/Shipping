Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardCnsPkgs : Inherits ShippingBiz.TB_OutwardCnsPkgsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardCnsPkgsCollection : Inherits ShippingBiz.TB_OutwardCnsPkgsCollectionOrmTemplate

    End Class

End Namespace