<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetelment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.LBLIssue = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LBLInvoice = New System.Windows.Forms.Label
        Me.LBL = New System.Windows.Forms.Label
        Me.LBLDO = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ButtonDTN = New System.Windows.Forms.ToolStripButton
        Me.ButtonDTNLine = New System.Windows.Forms.ToolStripButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.InvoiceToCarrier = New Shipping.UserNum
        Me.InvoiceToClient = New Shipping.UserNum
        Me.SetelmetDate = New Shipping.UserGnrlDate
        Me.Discount = New Shipping.UserNum
        Me.Detention = New Shipping.UserNum
        Me.Label6 = New System.Windows.Forms.Label
        Me.BLNO = New Shipping.UserText
        Me.GeneralForms = New Shipping.UserGeneralForms
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.LBLIssue)
        Me.GroupBox.Controls.Add(Me.Label8)
        Me.GroupBox.Controls.Add(Me.LBLInvoice)
        Me.GroupBox.Controls.Add(Me.LBL)
        Me.GroupBox.Controls.Add(Me.LBLDO)
        Me.GroupBox.Controls.Add(Me.Label7)
        Me.GroupBox.Controls.Add(Me.ToolStrip1)
        Me.GroupBox.Controls.Add(Me.Label5)
        Me.GroupBox.Controls.Add(Me.Label4)
        Me.GroupBox.Controls.Add(Me.Label3)
        Me.GroupBox.Controls.Add(Me.Label2)
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Controls.Add(Me.InvoiceToCarrier)
        Me.GroupBox.Controls.Add(Me.InvoiceToClient)
        Me.GroupBox.Controls.Add(Me.SetelmetDate)
        Me.GroupBox.Controls.Add(Me.Discount)
        Me.GroupBox.Controls.Add(Me.Detention)
        Me.GroupBox.Location = New System.Drawing.Point(10, 85)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(368, 288)
        Me.GroupBox.SupportThemes = False
        Me.GroupBox.TabIndex = 2
        '
        'LBLIssue
        '
        Me.LBLIssue.AutoSize = True
        Me.LBLIssue.Location = New System.Drawing.Point(141, 66)
        Me.LBLIssue.Name = "LBLIssue"
        Me.LBLIssue.Size = New System.Drawing.Size(0, 13)
        Me.LBLIssue.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Issue Time:"
        '
        'LBLInvoice
        '
        Me.LBLInvoice.AutoSize = True
        Me.LBLInvoice.Location = New System.Drawing.Point(141, 91)
        Me.LBLInvoice.Name = "LBLInvoice"
        Me.LBLInvoice.Size = New System.Drawing.Size(0, 13)
        Me.LBLInvoice.TabIndex = 24
        '
        'LBL
        '
        Me.LBL.AutoSize = True
        Me.LBL.Location = New System.Drawing.Point(23, 91)
        Me.LBL.Name = "LBL"
        Me.LBL.Size = New System.Drawing.Size(71, 13)
        Me.LBL.TabIndex = 23
        Me.LBL.Text = "Confirm Time:"
        '
        'LBLDO
        '
        Me.LBLDO.AutoSize = True
        Me.LBLDO.Location = New System.Drawing.Point(141, 42)
        Me.LBLDO.Name = "LBLDO"
        Me.LBLDO.Size = New System.Drawing.Size(0, 13)
        Me.LBLDO.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "D.O. Date"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonDTN, Me.ButtonDTNLine})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(362, 25)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonDTN
        '
        Me.ButtonDTN.Image = Global.Shipping.My.Resources.Resources.print_24
        Me.ButtonDTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDTN.Name = "ButtonDTN"
        Me.ButtonDTN.Size = New System.Drawing.Size(74, 22)
        Me.ButtonDTN.Text = "Detention"
        '
        'ButtonDTNLine
        '
        Me.ButtonDTNLine.Image = Global.Shipping.My.Resources.Resources.print_24
        Me.ButtonDTNLine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDTNLine.Name = "ButtonDTNLine"
        Me.ButtonDTNLine.Size = New System.Drawing.Size(61, 22)
        Me.ButtonDTNLine.Text = "To Line"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Credit Line"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Debit Client"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Settlement Date To line"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Discount"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Detention"
        '
        'InvoiceToCarrier
        '
        Me.InvoiceToCarrier.CtrlValue = 0
        Me.InvoiceToCarrier.Location = New System.Drawing.Point(144, 235)
        Me.InvoiceToCarrier.Name = "InvoiceToCarrier"
        Me.InvoiceToCarrier.Size = New System.Drawing.Size(158, 23)
        Me.InvoiceToCarrier.TabIndex = 14
        '
        'InvoiceToClient
        '
        Me.InvoiceToClient.CtrlValue = 0
        Me.InvoiceToClient.Location = New System.Drawing.Point(144, 206)
        Me.InvoiceToClient.Name = "InvoiceToClient"
        Me.InvoiceToClient.Size = New System.Drawing.Size(158, 23)
        Me.InvoiceToClient.TabIndex = 13
        '
        'SetelmetDate
        '
        Me.SetelmetDate.DateValue = Nothing
        Me.SetelmetDate.Location = New System.Drawing.Point(144, 176)
        Me.SetelmetDate.Name = "SetelmetDate"
        Me.SetelmetDate.ShowTime = False
        Me.SetelmetDate.Size = New System.Drawing.Size(158, 24)
        Me.SetelmetDate.TabIndex = 12
        '
        'Discount
        '
        Me.Discount.CtrlValue = 0
        Me.Discount.Location = New System.Drawing.Point(144, 146)
        Me.Discount.Name = "Discount"
        Me.Discount.Size = New System.Drawing.Size(158, 23)
        Me.Discount.TabIndex = 11
        '
        'Detention
        '
        Me.Detention.CtrlValue = 0
        Me.Detention.Location = New System.Drawing.Point(144, 117)
        Me.Detention.Name = "Detention"
        Me.Detention.Size = New System.Drawing.Size(158, 23)
        Me.Detention.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "B/L No"
        '
        'BLNO
        '
        Me.BLNO.BackColor = System.Drawing.Color.Transparent
        Me.BLNO.CustomMaxLength = CType(100, Byte)
        Me.BLNO.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BLNO.Location = New System.Drawing.Point(71, 50)
        Me.BLNO.Name = "BLNO"
        Me.BLNO.Size = New System.Drawing.Size(225, 22)
        Me.BLNO.TabIndex = 17
        Me.BLNO.TextValue = ""
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(395, 399)
        Me.GeneralForms.TabIndex = 0
        '
        'FrmSetelment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 399)
        Me.Controls.Add(Me.BLNO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmSetelment"
        Me.Text = "Setelment"
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents InvoiceToCarrier As Shipping.UserNum
    Friend WithEvents InvoiceToClient As Shipping.UserNum
    Friend WithEvents SetelmetDate As Shipping.UserGnrlDate
    Friend WithEvents Discount As Shipping.UserNum
    Friend WithEvents Detention As Shipping.UserNum
    Friend WithEvents BLNO As Shipping.UserText
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonDTN As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonDTNLine As System.Windows.Forms.ToolStripButton
    Friend WithEvents LBLDO As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBL As System.Windows.Forms.Label
    Friend WithEvents LBLInvoice As System.Windows.Forms.Label
    Friend WithEvents LBLIssue As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
