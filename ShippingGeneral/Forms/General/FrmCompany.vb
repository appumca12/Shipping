Imports OrmLib
Imports ShippingBiz
Public Class FrmCompany
    Private Dm As DataManager
    Private Co As TB_Company
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub TopMenu_CustomSaveClick() Handles TopMenu.CustomSaveClick
        Dim LogDataSet As New DataSet

        If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then

            Try
                Co.DomainName = Me.DomainName.TextValue
                Co.POP3 = Me.POP3.TextValue
                Co.SMTP = Me.SMTP.TextValue
                Co.CompanyName = Me.CompanyName.TextValue
                Co.CompanyAddress = Me.CompanyAddress.TextValue
                Co.EDICODE = Me.EDICode.TextValue
                Co.Tel = Me.Tel.TextValue
                Co.Fax = Me.Fax.TextValue
                Co.CompantFAddress = Me.CompanyFAddress.TextValue
                Co.CompanyFName = Me.CompanyFName.TextValue
                Co.CompanyFTel = Me.CompanyFTel.TextValue
                Co.CompanyFFax = Me.CompanyFFax.TextValue
                Co.CompanyAccount = Me.CompanyAccount.Text
                Co.POBOX = Me.POBOX.TextValue
                Co.RegestrationNo = Me.RegestrationNo.TextValue
                Co.EconomicNo = Me.EconomicNo.TextValue
                LogDataSet = Dm.DataSet.Copy
                Dm.CommitAll()
                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
            Catch ex As Exception
                MsgBoxSaveFailed()
                MsgBox(ex.ToString)
            End Try

        End If

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FrmCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dm = New DataManager(My.Settings.DSN)
        Co = Dm.GetTB_Company
        If Co Is Nothing Then
            Co = Dm.NewTB_Company("!", "!", "!", "", "")
            Co.Tel = ""
            Co.Fax = ""
            Co.ID = Guid.NewGuid
            Co.DomainName = ""
            Co.POP3 = ""
            Co.SMTP = ""
        End If


        Me.POBOX.SetLength(15)
        Me.RegestrationNo.SetLength(20)
        Me.EconomicNo.SetLength(20)

        Me.CompanyAddress.GeneralText.Text = NullToValue(Co.CompanyAddress, "")
        Me.CompanyName.GeneralText.Text = NullToValue(Co.CompanyName, "")
        Me.Tel.TextValue = NullToValue(Co.Tel, "")
        Me.Fax.TextValue = NullToValue(Co.Fax, "")

        Me.DomainName.TextValue = NullToValue(Co.DomainName, "")
        Me.EDICode.TextValue = NullToValue(Co.EDICODE, "")
        Me.POP3.TextValue = NullToValue(Co.POP3, "")
        Me.SMTP.TextValue = NullToValue(Co.SMTP, "")

        Me.CompanyFAddress.TextValue = NullToValue(Co.CompantFAddress, "")
        Me.CompanyFName.TextValue = NullToValue(Co.CompanyFName, "")
        Me.CompanyFTel.TextValue = NullToValue(Co.CompanyFTel, "")
        Me.CompanyFFax.TextValue = NullToValue(Co.CompanyFFax, "")
        Me.CompanyAccount.Text = NullToValue(Co.CompanyAccount, "")

        Me.POBOX.TextValue = NullToValue(Co.POBOX, "")
        Me.RegestrationNo.TextValue = NullToValue(Co.RegestrationNo, "")
        Me.EconomicNo.TextValue = NullToValue(Co.EconomicNo, "")

    End Sub

   
    Private Sub TopMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopMenu.Load

    End Sub
End Class