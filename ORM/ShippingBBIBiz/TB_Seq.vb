Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Seq : Inherits ShippingBiz.TB_SeqOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_SeqCollection : Inherits ShippingBiz.TB_SeqCollectionOrmTemplate

    End Class

End Namespace