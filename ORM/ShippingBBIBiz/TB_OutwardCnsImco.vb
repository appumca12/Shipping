Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardCnsImco : Inherits ShippingBiz.TB_OutwardCnsImcoOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardCnsImcoCollection : Inherits ShippingBiz.TB_OutwardCnsImcoCollectionOrmTemplate

    End Class

End Namespace