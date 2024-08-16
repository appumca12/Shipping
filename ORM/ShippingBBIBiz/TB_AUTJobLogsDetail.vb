Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_AUTJobLogsDetail : Inherits ShippingBiz.TB_AUTJobLogsDetailOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AUTJobLogsDetailCollection : Inherits ShippingBiz.TB_AUTJobLogsDetailCollectionOrmTemplate

    End Class

End Namespace