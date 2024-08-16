Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_BookingRelease : Inherits ShippingBiz.TB_BookingReleaseOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_BookingReleaseCollection : Inherits ShippingBiz.TB_BookingReleaseCollectionOrmTemplate

    End Class

End Namespace