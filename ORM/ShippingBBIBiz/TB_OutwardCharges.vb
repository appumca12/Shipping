Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardCharges : Inherits ShippingBiz.TB_OutwardChargesOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardChargesCollection : Inherits ShippingBiz.TB_OutwardChargesCollectionOrmTemplate

    End Class

End Namespace