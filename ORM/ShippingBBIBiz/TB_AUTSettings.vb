Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_AUTSettings : Inherits ShippingBiz.TB_AUTSettingsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AUTSettingsCollection : Inherits ShippingBiz.TB_AUTSettingsCollectionOrmTemplate

    End Class

End Namespace