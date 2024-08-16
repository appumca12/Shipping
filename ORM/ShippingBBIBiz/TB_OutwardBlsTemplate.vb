Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardBlsTemplate : Inherits ShippingBiz.TB_OutwardBlsTemplateOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardBlsTemplateCollection : Inherits ShippingBiz.TB_OutwardBlsTemplateCollectionOrmTemplate

    End Class

End Namespace