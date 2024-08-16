Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_BookingCns : Inherits ShippingBiz.TB_BookingCnsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_BookingCnsCollection : Inherits ShippingBiz.TB_BookingCnsCollectionOrmTemplate

    End Class

End Namespace