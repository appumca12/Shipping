<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserClientText
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.ButtonSrch = New Infragistics.Win.Misc.UltraButton
        Me.UserClients = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.UserClients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSrch, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UserClients, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(289, 28)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonSrch
        '
        Appearance1.Image = Global.Shipping.My.Resources.Resources.search_24
        Me.ButtonSrch.Appearance = Appearance1
        Me.ButtonSrch.Location = New System.Drawing.Point(254, 3)
        Me.ButtonSrch.Name = "ButtonSrch"
        Me.ButtonSrch.Size = New System.Drawing.Size(29, 21)
        Me.ButtonSrch.TabIndex = 3
        '
        'UserClients
        '
        Me.UserClients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserClients.Location = New System.Drawing.Point(3, 3)
        Me.UserClients.Name = "UserClients"
        Me.UserClients.Size = New System.Drawing.Size(245, 21)
        Me.UserClients.TabIndex = 2
        '
        'UserClientText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UserClientText"
        Me.Size = New System.Drawing.Size(289, 28)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.UserClients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UserClients As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ButtonSrch As Infragistics.Win.Misc.UltraButton

End Class
