Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinCalcManager
Imports Infragistics.Win.UltraWinCalcManager.FormulaBuilder


Public Class NewColumnDialog
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ultraLabelFormula As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ultraTextEditorFormula As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ultraButtonCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ultraButtonOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ultraComboEditorType As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents ultraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ultraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ultraTextEditorName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ultraLabelFormula = New Infragistics.Win.Misc.UltraLabel()
        Me.ultraTextEditorFormula = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.ultraButtonCancel = New Infragistics.Win.Misc.UltraButton()
        Me.ultraButtonOk = New Infragistics.Win.Misc.UltraButton()
        Me.ultraComboEditorType = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.ultraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.ultraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.ultraTextEditorName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.ultraTextEditorFormula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraComboEditorType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraTextEditorName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ultraLabelFormula
        '
        Me.ultraLabelFormula.Location = New System.Drawing.Point(8, 64)
        Me.ultraLabelFormula.Name = "ultraLabelFormula"
        Me.ultraLabelFormula.TabIndex = 15
        Me.ultraLabelFormula.Text = "Formula (optional)"
        '
        'ultraTextEditorFormula
        '
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.TextHAlign = Infragistics.Win.HAlign.Center
        Appearance1.TextVAlign = Infragistics.Win.VAlign.Middle
        EditorButton1.Appearance = Appearance1
        EditorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button
        EditorButton1.Text = "..."
        Me.ultraTextEditorFormula.ButtonsRight.Add(EditorButton1)
        Me.ultraTextEditorFormula.Location = New System.Drawing.Point(112, 64)
        Me.ultraTextEditorFormula.Name = "ultraTextEditorFormula"
        Me.ultraTextEditorFormula.Size = New System.Drawing.Size(144, 21)
        Me.ultraTextEditorFormula.TabIndex = 14
        '
        'ultraButtonCancel
        '
        Me.ultraButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ultraButtonCancel.Location = New System.Drawing.Point(136, 96)
        Me.ultraButtonCancel.Name = "ultraButtonCancel"
        Me.ultraButtonCancel.TabIndex = 13
        Me.ultraButtonCancel.Text = "&Cancel"
        '
        'ultraButtonOk
        '
        Me.ultraButtonOk.Location = New System.Drawing.Point(48, 96)
        Me.ultraButtonOk.Name = "ultraButtonOk"
        Me.ultraButtonOk.TabIndex = 12
        Me.ultraButtonOk.Text = "&Ok"
        '
        'ultraComboEditorType
        '
        Me.ultraComboEditorType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.ultraComboEditorType.Location = New System.Drawing.Point(112, 40)
        Me.ultraComboEditorType.Name = "ultraComboEditorType"
        Me.ultraComboEditorType.TabIndex = 11
        '
        'ultraLabel2
        '
        Me.ultraLabel2.Location = New System.Drawing.Point(8, 40)
        Me.ultraLabel2.Name = "ultraLabel2"
        Me.ultraLabel2.TabIndex = 10
        Me.ultraLabel2.Text = "Type"
        '
        'ultraLabel1
        '
        Me.ultraLabel1.Location = New System.Drawing.Point(8, 16)
        Me.ultraLabel1.Name = "ultraLabel1"
        Me.ultraLabel1.TabIndex = 9
        Me.ultraLabel1.Text = "Name"
        '
        'ultraTextEditorName
        '
        Me.ultraTextEditorName.Location = New System.Drawing.Point(112, 16)
        Me.ultraTextEditorName.Name = "ultraTextEditorName"
        Me.ultraTextEditorName.Size = New System.Drawing.Size(144, 21)
        Me.ultraTextEditorName.TabIndex = 8
        '
        'NewColumnDialog
        '
        Me.AcceptButton = Me.ultraButtonOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.ultraButtonCancel
        Me.ClientSize = New System.Drawing.Size(266, 128)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ultraLabelFormula, Me.ultraTextEditorFormula, Me.ultraButtonCancel, Me.ultraButtonOk, Me.ultraComboEditorType, Me.ultraLabel2, Me.ultraLabel1, Me.ultraTextEditorName})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NewColumnDialog"
        Me.Text = "New Column"
        CType(Me.ultraTextEditorFormula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraComboEditorType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraTextEditorName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "NewColumnDialog_Load"

    Private Sub NewColumnDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadTypesCombo()
    End Sub

#End Region   ' NewColumnDialog_Load

#Region "LoadTypesCombo"

    Private Sub LoadTypesCombo()
        Dim arr As Object() = New Object() { _
            GetType(String), "Text", _
            GetType(Boolean), "Checkbox", _
            GetType(Decimal), "Currency", _
            GetType(Integer), "Whole Number", _
            GetType(Double), "Real Number", _
            GetType(DateTime), "Date" _
        }

        Me.ultraComboEditorType.Items.Clear()

        Dim i As Integer
        For i = 0 To arr.Length - 1 Step 2
            Dim type As Type = DirectCast(arr(i), Type)
            Dim description As String = arr(i + 1).ToString()
            Me.ultraComboEditorType.Items.Add(type, description)
        Next

        Dim vl As ValueList = Me.ultraComboEditorType.Items(0).ValueList
        vl.DisplayStyle = ValueListDisplayStyle.DisplayText
        vl.SortStyle = ValueListSortStyle.Ascending

        ' Select a default type.
        If Me.ultraComboEditorType.Items.Count > 0 Then
            Me.ultraComboEditorType.SelectedIndex = 0
        End If
    End Sub

#End Region   ' LoadTypesCombo

#Region "Band"

    Private _band As UltraGridBand = Nothing

    '/ <summary>
    '/ Gets or sets the band object to which the new column will be added.
    '/ </summary>
    Public Property Band() As UltraGridBand
        Get
            Return Me._band
        End Get
        Set(ByVal Value As UltraGridBand)
            Me._band = Value
        End Set
    End Property

#End Region   ' Band

#Region "CreatedColumn"

    Private _createdColumn As UltraGridColumn = Nothing

    '/ <summary>
    '/ Returns the new column that was created. It will return null if the user cancels the process.
    '/ </summary>
    Public ReadOnly Property CreatedColumn() As UltraGridColumn
        Get
            Return Me._createdColumn
        End Get
    End Property

#End Region   ' CreatedColumn

#Region "ultraButtonOk_Click"

    Private Sub UltraButtonOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ultraButtonOk.Click
        Dim success As Boolean = Me.CreateColumnHelper()

        If success Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

#End Region   ' ultraButtonOk_Click

#Region "CreateColumnHelper"

    '/ <summary>
    '/ Creates the column based on currently input data. If a column was previously created
    '/ then reuses that.
    '/ </summary>
    Private Function CreateColumnHelper() As Boolean
        Dim columnName As String = Me.ultraTextEditorName.Text
        If Not Nothing Is columnName Then
            columnName = columnName.Trim()
        End If

        ' Don't allow empty string as the column name.
        If Nothing Is columnName OrElse columnName.Length <= 0 Then
            MessageBox.Show(Me, "Please enter a column name.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        ' Make sure that a column by the same name doesn't exist already.
        If Me.Band.Columns.Exists(columnName) AndAlso _
           (Nothing Is Me.CreatedColumn OrElse Me.CreatedColumn.Key <> columnName) Then

            MessageBox.Show(Me, "A column by this name already exists. Please enter a different name.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If


        Dim item As ValueListItem = Me.ultraComboEditorType.SelectedItem
        If Nothing Is item Then
            MessageBox.Show(Me, "Please select the type of column you want to add.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        ' If we haven't already created the column then create one.
        If Nothing Is Me.CreatedColumn Then
            Me._createdColumn = Me.Band.Columns.Add(columnName)
        Else
            ' If we had already created the column then make sure that 
            ' the key is the same.
            Me.CreatedColumn.Key = columnName

            ' Assing the newly selected data tyle and formula if any.
            Me.CreatedColumn.DataType = DirectCast(item.DataValue, Type)
            Me.CreatedColumn.Formula = Me.ultraTextEditorFormula.Text
        End If

        Return True
    End Function

#End Region   ' CreateColumnHelper

#Region "ultraTextEditorFormula_EditorButtonClick"

    Private Sub UltraTextEditorFormula_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles ultraTextEditorFormula.EditorButtonClick
        'Me.CreateColumnHelper()

        'If Nothing Is Me.CreatedColumn Then
        '    Return
        'End If

        '' In order to design a formula, CalcManager property of the grid must
        '' be assigned an instance of a calc manager. If none is assigned then
        '' create a new one and assign it.
        'If Nothing Is Me.CreatedColumn.Layout.Grid.CalcManager Then
        '    Me.createdColumn.Layout.Grid.CalcManager = New UltraCalcManager()
        'End If

        'Dim dlg As FormulaBuilderialoDg = New FormulaBuilderDialog(Me.CreatedColumn, True)
        'Dim result As DialogResult = dlg.ShowDialog(Me)

        'If DialogResult.OK = result Then
        '    Me.ultraTextEditorFormula.Text = dlg.Formula
        'End If

        'Me.CreatedColumn.Formula = Me.ultraTextEditorFormula.Text
    End Sub

#End Region   ' ultraTextEditorFormula_EditorButtonClick

#Region "ultraButtonCancel_Click"

    Private Sub UltraButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ultraButtonCancel.Click
        Me.DialogResult = DialogResult.Cancel

        ' If the dialog gets canceled then remove the column if we added one.
        ' 
        If Not Nothing Is Me.CreatedColumn Then
            Me.band.Columns.Remove(Me.createdColumn)
        End If

        Me._createdColumn = Nothing
    End Sub

#End Region   ' ultraButtonCancel_Click


End Class
