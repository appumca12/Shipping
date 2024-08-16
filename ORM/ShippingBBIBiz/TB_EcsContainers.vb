Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_EcsContainers : Inherits ShippingBiz.TB_EcsContainersOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_EcsContainersCollection : Inherits ShippingBiz.TB_EcsContainersCollectionOrmTemplate

    End Class

End Namespace