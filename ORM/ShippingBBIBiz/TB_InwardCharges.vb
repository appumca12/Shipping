Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InwardCharges : Inherits ShippingBiz.TB_InwardChargesOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InwardChargesCollection : Inherits ShippingBiz.TB_InwardChargesCollectionOrmTemplate

    End Class

End Namespace