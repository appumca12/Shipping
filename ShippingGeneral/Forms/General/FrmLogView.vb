Imports OrmLib
Imports ShippingBiz

Public Class FrmLogView

    Private Dm As DataManager
    Private Sub FrmLogView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      
        Dm = New DataManager(My.Settings.DSN)
        Dm.GetTB_Users()

        With Me.ComboUsers
            .CustomDatasource = Dm.DataSet.Tables("TB_Users")
            .CustomDisplayMember = "UserName"
            .CustomValueMember = "UserCode"
        End With

        Me.dFrom.InitControl(False, False)
        Me.dTo.InitControl(False, False)

    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        Dim ds As New DataSet
        Dim dr As DataRow
        Me.DataSetForm.Clear()






        ds = StoredProcedures.SP_LogAll(Me.ComboUsers.CustomValue, Me.dFrom.GnrlDate.Value, Me.dTo.GnrlDate.Value)

        For Each dr In ds.Tables(0).Rows
            Me.DataSetForm.Tables(0).ImportRow(dr)
        Next

        For Each dr In ds.Tables(1).Rows
            Me.DataSetForm.Tables(1).ImportRow(dr)
        Next

        With Me.GridLog.DisplayLayout
            .Bands(0).Columns("ID").Hidden = True
            .Bands(0).Columns("Tablekey").Hidden = True
            .Bands(1).Columns("ID").Hidden = True
            .Bands(1).Columns("LogID").Hidden = True
        End With


    End Sub

 
End Class