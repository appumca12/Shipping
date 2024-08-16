Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_AUTSchedule : Inherits ShippingBiz.TB_AUTScheduleOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AUTScheduleCollection : Inherits ShippingBiz.TB_AUTScheduleCollectionOrmTemplate

    End Class

End Namespace