Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_EventMail : Inherits ShippingBiz.TB_EventMailOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_EventMailCollection : Inherits ShippingBiz.TB_EventMailCollectionOrmTemplate

    End Class

End Namespace