Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_BookingDeposits : Inherits ShippingBiz.TB_BookingDepositsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_BookingDepositsCollection : Inherits ShippingBiz.TB_BookingDepositsCollectionOrmTemplate

    End Class

End Namespace