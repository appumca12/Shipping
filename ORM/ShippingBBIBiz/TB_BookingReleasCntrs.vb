Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_BookingReleasCntrs : Inherits ShippingBiz.TB_BookingReleasCntrsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_BookingReleasCntrsCollection : Inherits ShippingBiz.TB_BookingReleasCntrsCollectionOrmTemplate

    End Class

End Namespace