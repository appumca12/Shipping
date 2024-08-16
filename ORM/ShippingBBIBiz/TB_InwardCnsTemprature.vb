Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InwardCnsTemprature : Inherits ShippingBiz.TB_InwardCnsTempratureOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InwardCnsTempratureCollection : Inherits ShippingBiz.TB_InwardCnsTempratureCollectionOrmTemplate

    End Class

End Namespace