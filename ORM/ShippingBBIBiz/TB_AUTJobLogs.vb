Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_AUTJobLogs : Inherits ShippingBiz.TB_AUTJobLogsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AUTJobLogsCollection : Inherits ShippingBiz.TB_AUTJobLogsCollectionOrmTemplate

    End Class

End Namespace