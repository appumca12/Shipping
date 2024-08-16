Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_BookingDetails : Inherits ShippingBiz.TB_BookingDetailsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_BookingDetailsCollection : Inherits ShippingBiz.TB_BookingDetailsCollectionOrmTemplate

    End Class

End Namespace