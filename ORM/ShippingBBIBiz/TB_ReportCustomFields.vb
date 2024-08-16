Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_ReportCustomFields : Inherits ShippingBiz.TB_ReportCustomFieldsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ReportCustomFieldsCollection : Inherits ShippingBiz.TB_ReportCustomFieldsCollectionOrmTemplate

    End Class

End Namespace