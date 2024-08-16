Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinDataSource


Public Class CustomColumnChooser
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
    Friend WithEvents ultraGridBagLayoutManager1 As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents ultraComboBandSelector As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ultraButtonDeleteColumn As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ultraButtonNewColumn As Infragistics.Win.Misc.UltraButton
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents ultraGridColumnChooser1 As Infragistics.Win.UltraWinGrid.UltraGridColumnChooser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Dim GridBagConstraint2 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Dim GridBagConstraint3 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Dim GridBagConstraint4 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Me.ultraGridBagLayoutManager1 = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.ultraComboBandSelector = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ultraButtonDeleteColumn = New Infragistics.Win.Misc.UltraButton
        Me.ultraButtonNewColumn = New Infragistics.Win.Misc.UltraButton
        Me.ultraGridColumnChooser1 = New Infragistics.Win.UltraWinGrid.UltraGridColumnChooser
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.ultraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraComboBandSelector, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ultraGridBagLayoutManager1
        '
        Me.ultraGridBagLayoutManager1.ContainerControl = Me
        Me.ultraGridBagLayoutManager1.ExpandToFitHeight = True
        Me.ultraGridBagLayoutManager1.ExpandToFitWidth = True
        '
        'ultraComboBandSelector
        '
        Me.ultraComboBandSelector.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.ultraComboBandSelector.DisplayLayout.MaxColScrollRegions = 1
        Me.ultraComboBandSelector.DisplayLayout.MaxRowScrollRegions = 1
        Me.ultraComboBandSelector.DisplayLayout.Override.CellPadding = 0
        Me.ultraComboBandSelector.DisplayMember = ""
        Me.ultraComboBandSelector.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Horizontal
        GridBagConstraint1.Insets.Bottom = 1
        GridBagConstraint1.Insets.Left = 1
        GridBagConstraint1.Insets.Right = 1
        GridBagConstraint1.Insets.Top = 1
        GridBagConstraint1.OriginX = 0
        GridBagConstraint1.OriginY = 0
        GridBagConstraint1.SpanX = 2
        Me.ultraGridBagLayoutManager1.SetGridBagConstraint(Me.ultraComboBandSelector, GridBagConstraint1)
        Me.CNetHelpProvider.SetHelpKeyword(Me.ultraComboBandSelector, "Shipping_Form_CustomColumnChooser.htm#CustomColumnChooser_ultraComboBandSelector")
        Me.CNetHelpProvider.SetHelpNavigator(Me.ultraComboBandSelector, System.Windows.Forms.HelpNavigator.Topic)
        Me.ultraComboBandSelector.Location = New System.Drawing.Point(1, 1)
        Me.ultraComboBandSelector.Name = "ultraComboBandSelector"
        Me.ultraGridBagLayoutManager1.SetPreferredSize(Me.ultraComboBandSelector, New System.Drawing.Size(100, 21))
        Me.CNetHelpProvider.SetShowHelp(Me.ultraComboBandSelector, True)
        Me.ultraComboBandSelector.Size = New System.Drawing.Size(190, 22)
        Me.ultraComboBandSelector.TabIndex = 7
        Me.ultraComboBandSelector.ValueMember = ""
        '
        'ultraButtonDeleteColumn
        '
        GridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Horizontal
        GridBagConstraint2.Insets.Bottom = 2
        GridBagConstraint2.Insets.Left = 2
        GridBagConstraint2.Insets.Right = 2
        GridBagConstraint2.Insets.Top = 2
        GridBagConstraint2.OriginX = 1
        GridBagConstraint2.OriginY = 2
        GridBagConstraint2.WeightX = 1.0!
        Me.ultraGridBagLayoutManager1.SetGridBagConstraint(Me.ultraButtonDeleteColumn, GridBagConstraint2)
        Me.CNetHelpProvider.SetHelpKeyword(Me.ultraButtonDeleteColumn, "Shipping_Form_CustomColumnChooser.htm#CustomColumnChooser_ultraButtonDeleteColumn" & _
                "")
        Me.CNetHelpProvider.SetHelpNavigator(Me.ultraButtonDeleteColumn, System.Windows.Forms.HelpNavigator.Topic)
        Me.ultraButtonDeleteColumn.Location = New System.Drawing.Point(98, 269)
        Me.ultraButtonDeleteColumn.Name = "ultraButtonDeleteColumn"
        Me.ultraGridBagLayoutManager1.SetPreferredSize(Me.ultraButtonDeleteColumn, New System.Drawing.Size(75, 23))
        Me.CNetHelpProvider.SetShowHelp(Me.ultraButtonDeleteColumn, True)
        Me.ultraButtonDeleteColumn.Size = New System.Drawing.Size(92, 23)
        Me.ultraButtonDeleteColumn.TabIndex = 6
        Me.ultraButtonDeleteColumn.Text = "Delete Column"
        '
        'ultraButtonNewColumn
        '
        GridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Horizontal
        GridBagConstraint3.Insets.Bottom = 2
        GridBagConstraint3.Insets.Left = 2
        GridBagConstraint3.Insets.Right = 2
        GridBagConstraint3.Insets.Top = 2
        GridBagConstraint3.OriginX = 0
        GridBagConstraint3.OriginY = 2
        GridBagConstraint3.WeightX = 1.0!
        Me.ultraGridBagLayoutManager1.SetGridBagConstraint(Me.ultraButtonNewColumn, GridBagConstraint3)
        Me.CNetHelpProvider.SetHelpKeyword(Me.ultraButtonNewColumn, "Shipping_Form_CustomColumnChooser.htm#CustomColumnChooser_ultraButtonNewColumn")
        Me.CNetHelpProvider.SetHelpNavigator(Me.ultraButtonNewColumn, System.Windows.Forms.HelpNavigator.Topic)
        Me.ultraButtonNewColumn.Location = New System.Drawing.Point(2, 269)
        Me.ultraButtonNewColumn.Name = "ultraButtonNewColumn"
        Me.ultraGridBagLayoutManager1.SetPreferredSize(Me.ultraButtonNewColumn, New System.Drawing.Size(75, 23))
        Me.CNetHelpProvider.SetShowHelp(Me.ultraButtonNewColumn, True)
        Me.ultraButtonNewColumn.Size = New System.Drawing.Size(92, 23)
        Me.ultraButtonNewColumn.TabIndex = 5
        Me.ultraButtonNewColumn.Text = "New Column"
        '
        'ultraGridColumnChooser1
        '
        Me.ultraGridColumnChooser1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ultraGridColumnChooser1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ultraGridColumnChooser1.DisplayLayout.MaxColScrollRegions = 1
        Me.ultraGridColumnChooser1.DisplayLayout.MaxRowScrollRegions = 1
        Me.ultraGridColumnChooser1.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ultraGridColumnChooser1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Me.ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None
        Me.ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None
        Me.ultraGridColumnChooser1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ultraGridColumnChooser1.DisplayLayout.Override.CellPadding = 2
        Me.ultraGridColumnChooser1.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never
        Me.ultraGridColumnChooser1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.[Select]
        Me.ultraGridColumnChooser1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ultraGridColumnChooser1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed
        Me.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ultraGridColumnChooser1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.ultraGridColumnChooser1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ultraGridColumnChooser1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        GridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint4.OriginX = 0
        GridBagConstraint4.OriginY = 1
        GridBagConstraint4.SpanX = 2
        GridBagConstraint4.WeightY = 1.0!
        Me.ultraGridBagLayoutManager1.SetGridBagConstraint(Me.ultraGridColumnChooser1, GridBagConstraint4)
        Me.CNetHelpProvider.SetHelpKeyword(Me.ultraGridColumnChooser1, "Shipping_Form_CustomColumnChooser.htm#CustomColumnChooser_ultraGridColumnChooser1" & _
                "")
        Me.CNetHelpProvider.SetHelpNavigator(Me.ultraGridColumnChooser1, System.Windows.Forms.HelpNavigator.Topic)
        Me.ultraGridColumnChooser1.Location = New System.Drawing.Point(0, 23)
        Me.ultraGridColumnChooser1.MultipleBandSupport = Infragistics.Win.UltraWinGrid.MultipleBandSupport.SingleBandOnly
        Me.ultraGridColumnChooser1.Name = "ultraGridColumnChooser1"
        Me.ultraGridBagLayoutManager1.SetPreferredSize(Me.ultraGridColumnChooser1, New System.Drawing.Size(264, 240))
        Me.CNetHelpProvider.SetShowHelp(Me.ultraGridColumnChooser1, True)
        Me.ultraGridColumnChooser1.Size = New System.Drawing.Size(192, 244)
        Me.ultraGridColumnChooser1.SourceGrid = Nothing
        Me.ultraGridColumnChooser1.Style = Infragistics.Win.UltraWinGrid.ColumnChooserStyle.AllColumnsWithCheckBoxes
        Me.ultraGridColumnChooser1.TabIndex = 4
        Me.ultraGridColumnChooser1.Text = "ultraGridColumnChooser1"
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Shipping.chm"
        '
        'CustomColumnChooser
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(192, 294)
        Me.Controls.Add(Me.ultraComboBandSelector)
        Me.Controls.Add(Me.ultraButtonDeleteColumn)
        Me.Controls.Add(Me.ultraButtonNewColumn)
        Me.Controls.Add(Me.ultraGridColumnChooser1)
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Shipping_Form_CustomColumnChooser.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "CustomColumnChooser"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.Text = "CustomColumnChooser"
        CType(Me.ultraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraComboBandSelector, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "ultraButtonNewColumn_Click"

    Private Sub UltraButtonNewColumn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ultraButtonNewColumn.Click
        Dim selectedBand As UltraGridBand = Me.ultraGridColumnChooser1.CurrentBand
        If Nothing Is selectedBand Then
            Return
        End If

        Dim dlg As NewColumnDialog = New NewColumnDialog()
        dlg.Band = selectedBand
        dlg.ShowDialog()
    End Sub

#End Region   ' ultraButtonNewColumn_Click

#Region "ultraButtonDeleteColumn_Click"

    Private Sub UltraButtonDeleteColumn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ultraButtonDeleteColumn.Click
        ' Delete the column that's currently selected in the column chooser control.
        ' 

        If Not TypeOf Me.ultraGridColumnChooser1.CurrentSelectedItem Is UltraGridColumn Then
            MessageBox.Show(Me, "Please select a column to delete.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim column As UltraGridColumn = DirectCast(Me.ultraGridColumnChooser1.CurrentSelectedItem, UltraGridColumn)

        If column.IsBound Then
            MessageBox.Show(Me, "Only unbound columns can be deleted.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        dim dlgResult as System.Windows.Forms.DialogResult = MessageBox.Show(Me, _
                String.Format("Deleting {0} column. Continue?", column.Header.Caption), _
                Me.Text, _
                MessageBoxButtons.OKCancel, _
                MessageBoxIcon.Question)

        If DialogResult.OK = dlgResult Then
            column.Band.Columns.Remove(column)
        End If
    End Sub

#End Region   ' ultraButtonDeleteColumn_Click

#Region "Grid"

    Private _grid As UltraGridBase = Nothing

    '/ <summary>
    '/ Gets or sets the UltraGrid instances whose columns are displayed in the column chooser.
    '/ </summary>
    Public Property Grid() As UltraGridBase

        Get
            Return Me._grid
        End Get
        Set(ByVal Value As UltraGridBase)

            If Not Value Is Me._grid Then
                Me._grid = Value

                Me.ultraGridColumnChooser1.SourceGrid = Me._grid
                Me.InitializeBandsCombo(Me._grid)

                ' Select the first band in the band selector.
                If Me.ultraComboBandSelector.Rows.Count > 0 Then
                    Me.ultraComboBandSelector.SelectedRow = Me.ultraComboBandSelector.Rows(0)
                End If
            End If
        End Set
    End Property

#End Region   ' Grid

#Region "CurrentBand"

    '/ <summary>
    '/ Gets or sets the band whose columns are being displayed.
    '/ </summary>
    Public Property CurrentBand() As UltraGridBand
        Get
            Return Me.ColumnChooserControl.CurrentBand
        End Get
        Set(ByVal Value As UltraGridBand)

            If Not Nothing Is Value AndAlso (Nothing Is Me.Grid OrElse Not Me.Grid Is Value.Layout.Grid) Then
                Throw New ArgumentException()
            End If

            Me.ultraComboBandSelector.Value = Value
        End Set
    End Property

#End Region   ' CurrentBand

#Region "ColumnChooserControl"

    '/ <summary>
    '/ Returns the column chooser control.
    '/ </summary>
    Public ReadOnly Property ColumnChooserControl() As UltraGridColumnChooser
        Get
            Return Me.ultraGridColumnChooser1
        End Get
    End Property

#End Region   ' ColumnChooserControl

#Region "InitializeBandsCombo"

    Private Sub InitializeBandsCombo(ByVal grid As UltraGridBase)
        Me.ultraComboBandSelector.SetDataBinding(Nothing, Nothing)
        If Nothing Is grid Then
            Return
        End If

        ' Create the data source that we can bind to UltraCombo for displaying 
        ' list of bands. The datasource will have two columns. One that contains
        ' the instances of UltraGridBand and the other that contains the text
        ' representation of the bands.
        Dim bandsUDS As UltraDataSource = New UltraDataSource()
        bandsUDS.Band.Columns.Add("Band", GetType(UltraGridBand))
        bandsUDS.Band.Columns.Add("DisplayText", GetType(String))

        Dim band As UltraGridBand
        For Each band In grid.DisplayLayout.Bands
            If Not Me.IsBandExcluded(band) Then
                bandsUDS.Rows.Add(New Object() {band, band.Header.Caption})
            End If
        Next

        Me.ultraComboBandSelector.DisplayMember = "DisplayText"
        Me.ultraComboBandSelector.ValueMember = "Band"
        Me.ultraComboBandSelector.SetDataBinding(bandsUDS, Nothing)

        ' Hide the Band column.
        Me.ultraComboBandSelector.DisplayLayout.Bands(0).Columns("Band").Hidden = True

        ' Hide the column headers.
        Me.ultraComboBandSelector.DisplayLayout.Bands(0).ColHeadersVisible = False

        ' Set some properties to improve the look & feel of the ultra combo.
        Me.ultraComboBandSelector.DropDownWidth = 0
        Me.ultraComboBandSelector.DisplayLayout.Override.HotTrackRowAppearance.BackColor = Color.LightYellow
        Me.ultraComboBandSelector.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        Me.ultraComboBandSelector.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid
        Me.ultraComboBandSelector.DisplayLayout.Appearance.BorderColor = SystemColors.Highlight
    End Sub

#End Region   ' InitializeBandsCombo

#Region "IsBandExcluded"

    '/ <summary>
    '/ Checks to see if the ExcludeFromColumnChooser property of the band or
    '/ any of its ancestor bands is set to True.
    '/ </summary>
    '/ <param name="band"></param>
    '/ <returns></returns>
    Private Function IsBandExcluded(ByVal band As UltraGridBand) As Boolean
        While Not Nothing Is band
            If ExcludeFromColumnChooser.True = band.ExcludeFromColumnChooser Then
                Return True
            End If

            band = band.ParentBand
        End While

        Return False
    End Function

#End Region   ' IsBandExcluded

#Region "ultraComboBandSelector_RowSelected"

    Private Sub UltraComboBandSelector_RowSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles ultraComboBandSelector.RowSelected
        If Nothing Is Me.Grid OrElse Me.Grid.IsDisposed Then
            Return
        End If

        Dim selectedBand As UltraGridBand = Nothing

        If Not TypeOf Me.ultraComboBandSelector.Value Is UltraGridBand Then
            System.Diagnostics.Debug.Assert(False)
            selectedBand = Me.Grid.DisplayLayout.Bands(0)
            Me.ultraComboBandSelector.Value = selectedBand
        End If

        selectedBand = DirectCast(Me.ultraComboBandSelector.Value, UltraGridBand)

        Me.ultraGridColumnChooser1.CurrentBand = selectedBand
    End Sub

#End Region   ' ultraComboBandSelector_RowSelected

End Class
