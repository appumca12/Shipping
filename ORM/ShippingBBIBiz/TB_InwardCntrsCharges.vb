Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InwardCntrsCharges : Inherits ShippingBiz.TB_InwardCntrsChargesOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InwardCntrsChargesCollection : Inherits ShippingBiz.TB_InwardCntrsChargesCollectionOrmTemplate

    End Class

End Namespace