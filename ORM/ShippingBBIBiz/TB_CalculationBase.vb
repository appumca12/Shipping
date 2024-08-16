Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_CalculationBase : Inherits ShippingBiz.TB_CalculationBaseOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_CalculationBaseCollection : Inherits ShippingBiz.TB_CalculationBaseCollectionOrmTemplate

    End Class

End Namespace