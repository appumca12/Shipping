Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardCnsTemprature : Inherits ShippingBiz.TB_OutwardCnsTempratureOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardCnsTempratureCollection : Inherits ShippingBiz.TB_OutwardCnsTempratureCollectionOrmTemplate

    End Class

End Namespace