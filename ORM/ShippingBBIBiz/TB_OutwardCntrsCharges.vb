Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardCntrsCharges : Inherits ShippingBiz.TB_OutwardCntrsChargesOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardCntrsChargesCollection : Inherits ShippingBiz.TB_OutwardCntrsChargesCollectionOrmTemplate

    End Class

End Namespace