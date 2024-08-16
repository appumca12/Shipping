Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_AUTAdditionalDocs : Inherits ShippingBiz.TB_AUTAdditionalDocsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AUTAdditionalDocsCollection : Inherits ShippingBiz.TB_AUTAdditionalDocsCollectionOrmTemplate

    End Class

End Namespace