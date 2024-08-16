<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserComboVessel
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
        Me.components = New System.ComponentModel.Container
        Me.CmbVessel = New System.Windows.Forms.ComboBox
        Me.ButtonRefresh = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbVessel
        '
        Me.CmbVessel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbVessel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbVessel.Dock = System.Windows.Forms.DockStyle.Top
        Me.CmbVessel.FormattingEnabled = True
        Me.CmbVessel.Location = New System.Drawing.Point(10, 0)
        Me.CmbVessel.Name = "CmbVessel"
        Me.CmbVessel.Size = New System.Drawing.Size(437, 21)
        Me.CmbVessel.Sorted = True
        Me.CmbVessel.TabIndex = 0
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.Location = New System.Drawing.Point(0, 0)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(10, 22)
        Me.ButtonRefresh.TabIndex = 2
        Me.ButtonRefresh.Text = "Button1"
        Me.ButtonRefresh.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonRefresh)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 22)
        Me.Panel1.TabIndex = 4
        '
        'UserComboVessel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CmbVessel)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UserComboVessel"
        Me.Size = New System.Drawing.Size(447, 22)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbVessel As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonRefresh As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager

End Class
