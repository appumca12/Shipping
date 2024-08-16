Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_ReleaseLetterSeq : Inherits ShippingBiz.TB_ReleaseLetterSeqOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ReleaseLetterSeqCollection : Inherits ShippingBiz.TB_ReleaseLetterSeqCollectionOrmTemplate

    End Class

End Namespace