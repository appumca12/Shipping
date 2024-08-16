Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_EcsMoves : Inherits ShippingBiz.TB_EcsMovesOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_EcsMovesCollection : Inherits ShippingBiz.TB_EcsMovesCollectionOrmTemplate

    End Class

End Namespace