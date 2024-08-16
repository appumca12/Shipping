<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMenuItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserMenuItem))
        Me.GnrlToolStrip = New System.Windows.Forms.ToolStrip
        Me.ButtonPickup = New System.Windows.Forms.ToolStripButton
        Me.ButtonNew = New System.Windows.Forms.ToolStripButton
        Me.ButtonEdit = New System.Windows.Forms.ToolStripButton
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton
        Me.ButtonDelete = New System.Windows.Forms.ToolStripButton
        Me.ButtonRefresh = New System.Windows.Forms.ToolStripButton
        Me.ButtonConfirm = New System.Windows.Forms.ToolStripButton
        Me.ButtonCancel = New System.Windows.Forms.ToolStripButton
        Me.ButtonPrint = New System.Windows.Forms.ToolStripButton
        Me.ButtonReset = New System.Windows.Forms.ToolStripButton
        Me.ButtonOpenFile = New System.Windows.Forms.ToolStripButton
        Me.ButtonRecivedItems = New System.Windows.Forms.ToolStripButton
        Me.ButtonAssign = New System.Windows.Forms.ToolStripButton
        Me.ButtonExcel = New System.Windows.Forms.ToolStripButton
        Me.ButtonDeposits = New System.Windows.Forms.ToolStripButton
        Me.ButtonProcess = New System.Windows.Forms.ToolStripButton
        Me.ButtonSelectAll = New System.Windows.Forms.ToolStripButton
        Me.ButtonDeselectAll = New System.Windows.Forms.ToolStripButton
        Me.ButtonAdditional = New System.Windows.Forms.ToolStripButton
        Me.GnrlToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'GnrlToolStrip
        '
        Me.GnrlToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.GnrlToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonPickup, Me.ButtonNew, Me.ButtonEdit, Me.ButtonSave, Me.ButtonDelete, Me.ButtonRefresh, Me.ButtonConfirm, Me.ButtonCancel, Me.ButtonPrint, Me.ButtonReset, Me.ButtonOpenFile, Me.ButtonRecivedItems, Me.ButtonAssign, Me.ButtonExcel, Me.ButtonDeposits, Me.ButtonProcess, Me.ButtonSelectAll, Me.ButtonDeselectAll, Me.ButtonAdditional})
        Me.GnrlToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.GnrlToolStrip.Name = "GnrlToolStrip"
        Me.GnrlToolStrip.Size = New System.Drawing.Size(794, 31)
        Me.GnrlToolStrip.TabIndex = 0
        Me.GnrlToolStrip.Text = "ToolStrip"
        '
        'ButtonPickup
        '
        Me.ButtonPickup.Image = CType(resources.GetObject("ButtonPickup.Image"), System.Drawing.Image)
        Me.ButtonPickup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonPickup.Name = "ButtonPickup"
        Me.ButtonPickup.Size = New System.Drawing.Size(65, 28)
        Me.ButtonPickup.Text = "Pickup"
        '
        'ButtonNew
        '
        Me.ButtonNew.Image = CType(resources.GetObject("ButtonNew.Image"), System.Drawing.Image)
        Me.ButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNew.Name = "ButtonNew"
        Me.ButtonNew.Size = New System.Drawing.Size(56, 28)
        Me.ButtonNew.Text = "New"
        '
        'ButtonEdit
        '
        Me.ButtonEdit.Image = CType(resources.GetObject("ButtonEdit.Image"), System.Drawing.Image)
        Me.ButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonEdit.Name = "ButtonEdit"
        Me.ButtonEdit.Size = New System.Drawing.Size(53, 28)
        Me.ButtonEdit.Text = "Edit"
        '
        'ButtonSave
        '
        Me.ButtonSave.Image = CType(resources.GetObject("ButtonSave.Image"), System.Drawing.Image)
        Me.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(59, 28)
        Me.ButtonSave.Text = "Save"
        '
        'ButtonDelete
        '
        Me.ButtonDelete.Image = CType(resources.GetObject("ButtonDelete.Image"), System.Drawing.Image)
        Me.ButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(66, 28)
        Me.ButtonDelete.Text = "Delete"
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.Image = CType(resources.GetObject("ButtonRefresh.Image"), System.Drawing.Image)
        Me.ButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(73, 28)
        Me.ButtonRefresh.Text = "Refresh"
        '
        'ButtonConfirm
        '
        Me.ButtonConfirm.Image = CType(resources.GetObject("ButtonConfirm.Image"), System.Drawing.Image)
        Me.ButtonConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonConfirm.Name = "ButtonConfirm"
        Me.ButtonConfirm.Size = New System.Drawing.Size(72, 28)
        Me.ButtonConfirm.Text = "Confirm"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Image = CType(resources.GetObject("ButtonCancel.Image"), System.Drawing.Image)
        Me.ButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(67, 28)
        Me.ButtonCancel.Text = "Cancel"
        '
        'ButtonPrint
        '
        Me.ButtonPrint.Image = CType(resources.GetObject("ButtonPrint.Image"), System.Drawing.Image)
        Me.ButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(57, 28)
        Me.ButtonPrint.Text = "Print"
        '
        'ButtonReset
        '
        Me.ButtonReset.Image = Global.Shipping.My.Resources.Resources.undo_24
        Me.ButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(63, 28)
        Me.ButtonReset.Text = "Reset"
        '
        'ButtonOpenFile
        '
        Me.ButtonOpenFile.Image = Global.Shipping.My.Resources.Resources.folder_open_24
        Me.ButtonOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonOpenFile.Name = "ButtonOpenFile"
        Me.ButtonOpenFile.Size = New System.Drawing.Size(80, 28)
        Me.ButtonOpenFile.Text = "Open File"
        Me.ButtonOpenFile.Visible = False
        '
        'ButtonRecivedItems
        '
        Me.ButtonRecivedItems.Image = Global.Shipping.My.Resources.Resources.finance_24
        Me.ButtonRecivedItems.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonRecivedItems.Name = "ButtonRecivedItems"
        Me.ButtonRecivedItems.Size = New System.Drawing.Size(103, 28)
        Me.ButtonRecivedItems.Text = "Received Items"
        Me.ButtonRecivedItems.Visible = False
        '
        'ButtonAssign
        '
        Me.ButtonAssign.Image = Global.Shipping.My.Resources.Resources.import_24
        Me.ButtonAssign.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAssign.Name = "ButtonAssign"
        Me.ButtonAssign.Size = New System.Drawing.Size(66, 28)
        Me.ButtonAssign.Text = "Assign"
        Me.ButtonAssign.Visible = False
        '
        'ButtonExcel
        '
        Me.ButtonExcel.Image = CType(resources.GetObject("ButtonExcel.Image"), System.Drawing.Image)
        Me.ButtonExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(75, 28)
        Me.ButtonExcel.Text = "To Excel"
        Me.ButtonExcel.Visible = False
        '
        'ButtonDeposits
        '
        Me.ButtonDeposits.Image = Global.Shipping.My.Resources.Resources.finance_24
        Me.ButtonDeposits.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDeposits.Name = "ButtonDeposits"
        Me.ButtonDeposits.Size = New System.Drawing.Size(76, 28)
        Me.ButtonDeposits.Text = "Deposits"
        Me.ButtonDeposits.Visible = False
        '
        'ButtonProcess
        '
        Me.ButtonProcess.Image = Global.Shipping.My.Resources.Resources.applications_24
        Me.ButtonProcess.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonProcess.Name = "ButtonProcess"
        Me.ButtonProcess.Size = New System.Drawing.Size(72, 28)
        Me.ButtonProcess.Text = "Process"
        Me.ButtonProcess.Visible = False
        '
        'ButtonSelectAll
        '
        Me.ButtonSelectAll.Image = Global.Shipping.My.Resources.Resources.add_24
        Me.ButtonSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSelectAll.Name = "ButtonSelectAll"
        Me.ButtonSelectAll.Size = New System.Drawing.Size(78, 28)
        Me.ButtonSelectAll.Text = "Select All"
        Me.ButtonSelectAll.Visible = False
        '
        'ButtonDeselectAll
        '
        Me.ButtonDeselectAll.Image = Global.Shipping.My.Resources.Resources.redo_24
        Me.ButtonDeselectAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDeselectAll.Name = "ButtonDeselectAll"
        Me.ButtonDeselectAll.Size = New System.Drawing.Size(90, 28)
        Me.ButtonDeselectAll.Text = "Deselect All"
        Me.ButtonDeselectAll.Visible = False
        '
        'ButtonAdditional
        '
        Me.ButtonAdditional.Image = Global.Shipping.My.Resources.Resources.calendar_24
        Me.ButtonAdditional.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAdditional.Name = "ButtonAdditional"
        Me.ButtonAdditional.Size = New System.Drawing.Size(28, 28)
        Me.ButtonAdditional.Visible = False
        '
        'UserMenuItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GnrlToolStrip)
        Me.Name = "UserMenuItem"
        Me.Size = New System.Drawing.Size(794, 31)
        Me.GnrlToolStrip.ResumeLayout(False)
        Me.GnrlToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GnrlToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonPickup As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonConfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonReset As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonOpenFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonRecivedItems As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonAssign As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonDeposits As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonProcess As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonSelectAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonDeselectAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonAdditional As System.Windows.Forms.ToolStripButton


End Class
