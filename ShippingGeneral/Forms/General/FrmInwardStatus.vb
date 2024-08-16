Imports OrmLib
Imports ShippingBiz
Public Class FrmInwardStatus


    Implements IFGeneral
    Private ItemLevel = "304"
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private BookingID As Guid
    Private Dm As DataManager
    Private TB As DataTable


    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus

        General.LockControls(Me, Status)

    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

     
    End Sub

    Private Sub Populate() Implements IFGeneral.Populate


    End Sub

    Private Sub FrmInwardStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GeneralForms.InitControl("Inward Status", ItemLevel)
    End Sub

    Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick

    End Sub
End Class