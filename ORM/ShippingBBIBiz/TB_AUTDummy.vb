Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_AUTDummy : Inherits ShippingBiz.TB_AUTDummyOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AUTDummyCollection : Inherits ShippingBiz.TB_AUTDummyCollectionOrmTemplate

    End Class

End Namespace