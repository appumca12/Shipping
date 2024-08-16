Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid


Public Class UserBlsCntrsPkg

    Enum InwardOutward
        Inward
        Outward
    End Enum
    Private IOStatus As InwardOutward
    Private BkID As Guid
    Private BLID As Guid

    Public Sub InitControl(ByVal InOut As InwardOutward)

        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn

        IOStatus = InOut
        '    InitTemp(InOut)

        With Me.DropDownSize
            .DataSource = GetCodeList("CS")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.DropDownType
            .DataSource = GetCodeList("CT")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With

        With Me.DropDownFLE
            .DataSource = GetCodeList("FL")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With

        With Me.DropDownSoc
            .DataSource = GetCodeList("YN")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With


        With Me.DropDownPkgs

            .DataSource = GetCodeList("PG")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False

        End With

        With Me.DropDownPkgs2

            .DataSource = GetCodeList("PG")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False

        End With
        With Me.DropDownHazard

            .DataSource = GetCodeList("HZ")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False

        End With

        With Me.DropDownPackingGroup

            .DataSource = GetCodeList("PZ")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False

        End With



        With Me.DropDownPOLT

            .DataSource = GetCodeList("PR")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With


        With Me.GridCntrs.DisplayLayout.Bands(0)

            .Columns("ID").Hidden = True
            .Columns("BLID").Hidden = True
            .Columns("CntrNo").CharacterCasing = CharacterCasing.Upper
            .Columns("CntrNo").MaxLength = 11

            .Columns("SealNo").CharacterCasing = CharacterCasing.Upper
            .Columns("TW").MaskInput = "{LOC}n,nnn"
            .Columns("GW").MaskInput = "{LOC}nn,nnn.nn"
            .Columns("Net").MaskInput = "{LOC}nn,nnn.nn"
            .Columns("CBM").MaskInput = "{LOC}nn,nnn.nn"
            .Columns("NoOfPkgs").MaskInput = "{LOC}n,nnn,nnn"
            .Columns("VGM").MaskInput = "{LOC}nn,nnn.nn"
            .Columns("CnType").Style _
                               = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CnType").ValueList = Me.DropDownType

            .Columns("CnSize").Style _
                                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CnSize").ValueList = Me.DropDownSize

            .Columns("FLE").Style _
                             = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("FLE").ValueList = Me.DropDownFLE

            .Columns("SOC").Style _
                             = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("SOC").ValueList = Me.DropDownSoc

            .Columns("PackageType").Style _
                                   = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("PackageType").ValueList = Me.DropDownPkgs
            .Columns("IsOOG").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            .Columns("POLTerm").Style _
                                   = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("POLTerm").ValueList = Me.DropDownPOLT

            .Columns("PODTerm").Style _
                                   = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("PODTerm").ValueList = Me.DropDownPOLT

        End With
        With Me.GridCntrs.DisplayLayout.Bands(1)
            .Columns("PackageType").Style _
                                  = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("PackageType").ValueList = Me.DropDownPkgs2
        End With


        If InOut = InwardOutward.Inward Then
            Me.ToolbarRight.Toolbars(0).Tools("GetCntrsBaseonBooking").SharedProps.Visible = False
            Me.ToolbarRight.Toolbars(0).Tools("ImportEmptyContainers").SharedProps.Visible = False
        End If

        With Me.GridCntrs.DisplayLayout.Bands(0).Columns("Goods")
            .CharacterCasing = CharacterCasing.Upper
            .MaxLength = 25
            .CellAppearance.BackColor = Color.WhiteSmoke
        End With

        With Me.GridCntrs
            .DisplayLayout.Bands(0).Columns("CntrNo").Width = 110
            .DisplayLayout.Bands(0).Columns("CnSize").Width = 50
            .DisplayLayout.Bands(0).Columns("CnType").Width = 50
            .DisplayLayout.Bands(0).Columns("SealNo").Width = 100
            .DisplayLayout.Bands(0).Columns("GW").Width = 80
            .DisplayLayout.Bands(0).Columns("TW").Width = 80
            .DisplayLayout.Bands(0).Columns("CBM").Width = 50
            .DisplayLayout.Bands(0).Columns("NET").Width = 50
            .DisplayLayout.Bands(0).Columns("FLE").Width = 50
            .DisplayLayout.Bands(0).Columns("SOC").Width = 50
            .DisplayLayout.Bands(0).Columns("PackageType").Width = 80
            .DisplayLayout.Bands(0).Columns("NoOfPkgs").Width = 50
            .DisplayLayout.Bands(0).Columns("IsOOG").Width = 50
            .DisplayLayout.Bands(0).Columns("Marks").Width = 50
            .DisplayLayout.Bands(0).Columns("POLTerm").Width = 90
            .DisplayLayout.Bands(0).Columns("PODTerm").Width = 90
            .DisplayLayout.Bands(0).Columns("VGM").Width = 80






        End With

    End Sub

    Private Sub GridCntrs_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles GridCntrs.AfterCellUpdate
        If GridCntrs.ActiveCell Is Nothing Then
            Exit Sub
        End If
        If GridCntrs.ActiveCell.Column.Header.Caption = "PackageType" Then
            GridCntrs.ActiveRow.Cells("EMSNumber").Value = GridCntrs.ActiveRow.Cells("PackagetYpe").Text.ToString()
        End If
    End Sub

    Private Sub GridCntrs_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCntrs.AfterRowActivate

    End Sub

    Private Sub GridCntrs_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GridCntrs.AfterRowInsert

        Select Case e.Row.Band.Index

            Case 0
                If IsDBNull(GridCntrs.ActiveRow.Cells("ID").Value) = True Then
                    GridCntrs.ActiveRow.Cells("ID").Value = Guid.NewGuid
                    GridCntrs.ActiveRow.Cells("BLID").Value = BLID
                End If
            Case 1
                If IsDBNull(GridCntrs.ActiveRow.Cells("ID").Value) = True Then
                    GridCntrs.ActiveRow.Cells("ID").Value = Guid.NewGuid
                    GridCntrs.ActiveRow.Cells("CntrID").Value = GridCntrs.ActiveRow.Band.ParentBand.Columns("ID")
                End If
            Case 2
                If IsDBNull(GridCntrs.ActiveRow.Cells("ID").Value) = True Then
                    GridCntrs.ActiveRow.Cells("ID").Value = Guid.NewGuid
                    GridCntrs.ActiveRow.Cells("CntrID").Value = GridCntrs.ActiveRow.Band.ParentBand.Columns("ID")
                End If

        End Select


    End Sub
    Public Sub SetDocument(ByVal BID As Guid, ByVal ds As DataSet)

        Dim Dr As DataRow
        Dim Newdr As DataRow
        Dim Tb As DataTable
        Dim Col As DataColumn
        Dim TbName As String


        BLID = BID


        CntrsDS.Tables("CnsPkgs").Clear()

        For Each Tb In CntrsDS.Tables
            Tb.Clear()
        Next
        CntrsDS.AcceptChanges()
        'TB_InwardCnsTemprature()
        For Each Tb In CntrsDS.Tables
            TbName = IIf(IOStatus = InwardOutward.Inward, "TB_Inward", "TB_Outward") & Tb.TableName
            If TbName = "TB_InwardCntrs" Then
                Me.GridCntrs.DisplayLayout.Bands(0).Columns("VGM").Hidden = True
            End If

            For Each Dr In ds.Tables(TbName).Rows
                Newdr = Tb.NewRow
                For Each Col In Tb.Columns
                    If Col.ColumnName = "VGM" And TbName = "TB_InwardCntrs" Then
                        Me.GridCntrs.DisplayLayout.Bands(0).Columns("VGM").Hidden = True
                    Else
                        Newdr(Col.ColumnName) = Dr(Col.ColumnName)
                    End If
                Next
                Tb.Rows.Add(Newdr)
            Next
        Next

        CntrsDS.AcceptChanges()
        Me.GridCntrs.DisplayLayout.Bands(0).Columns("Goods").CharacterCasing = CharacterCasing.Upper
        Me.GridCntrs.DisplayLayout.Bands(1).Columns("ID").Hidden = True
        Me.GridCntrs.DisplayLayout.Bands(1).Columns("CntrID").Hidden = True

        RecalculateSummary()
        Colorized()

    End Sub

    Public Sub GetDocument(ByRef Ds As DataSet)

        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim DC As DataColumn
        Dim DV As DataView
        Dim CLen As Byte
        Dim TbName As String

        Dim Changes As DataSet = CntrsDS.GetChanges
        Me.GridCntrs.UpdateData()

        If Not Changes Is Nothing Then

            For Each Tb In Changes.Tables
                TbName = IIf(IOStatus = InwardOutward.Inward, "TB_Inward", "TB_Outward") & Tb.TableName

                For Each Dr In Tb.Rows
                    Select Case Dr.RowState
                        Case DataRowState.Added
                            Dr("BLID") = BLID
                            Ds.Tables(TbName).ImportRow(Dr)
                        Case DataRowState.Deleted
                            DV = New DataView(Ds.Tables(TbName), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                            If DV.Count > 0 Then
                                DV.Item(0).Delete()
                            End If

                        Case DataRowState.Modified
                            DV = New DataView(Ds.Tables(TbName), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                            If DV.Count > 0 Then
                                CLen = Dr.ItemArray.Length
                                For Each DC In Tb.Columns
                                    DV.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                                Next
                            End If
                    End Select
                Next
            Next
            CntrsDS.AcceptChanges()
        End If

    End Sub

    Public Sub Checking(ByRef TB As DataTable)

        Dim Row As Infragistics.Win.UltraWinGrid.UltraGridRow

        For Each Row In GridCntrs.Rows

            If Row.IsAddRow = False Then

                With Row

                    If .Cells("CntrNo").Text = "" Then
                        AddRowToErrorTable(TB, "Containers", "Container No is Blak On " & .Cells("CntrNo").Text, ErrMsgtype.Err)
                    End If

                    If .Cells("CnSize").Text = "" Then
                        AddRowToErrorTable(TB, "Containers", "Container Size Is Wrong On " & .Cells("CntrNo").Text, ErrMsgtype.Err)
                    End If

                    If .Cells("CnType").Text = "" Then
                        AddRowToErrorTable(TB, "Containers", "Container Type Is Wrong On " & .Cells("CntrNo").Text, ErrMsgtype.Err)
                    End If

                    If .Cells("FLE").Text = "" Then
                        AddRowToErrorTable(TB, "Containers", "Container FLE Is Wrong On " & .Cells("CntrNo").Text, ErrMsgtype.Err)
                    End If

                    If Val(.Cells("TW").Text) = 0 Then
                        AddRowToErrorTable(TB, "Containers", "Container TW Is Zero On " & .Cells("CntrNo").Text, ErrMsgtype.Err)
                    End If

                    If .Cells("SOC").Text = "" Then
                        AddRowToErrorTable(TB, "Containers", "S.O.C. Is Blank On " & .Cells("CntrNo").Text, ErrMsgtype.Err)
                    End If

                    If .Cells("FLE").Value.ToString <> "E" Then

                        'If Val(.Cells("GW").Text) = 0 Then
                        '    AddRowToErrorTable(TB, "Containers", "Container Gross Weight Is Zero On " & .Cells("CntrNo").Text, ErrMsgtype.Err)
                        'End If

                        If .Cells("Sealno").Text = "" Then
                            AddRowToErrorTable(TB, "Containers", "Seal No is Blank On " & .Cells("CntrNo").Text, ErrMsgtype.Err)
                        End If

                        'If Val(.Cells("CBM").Text) = 0 Then
                        '    AddRowToErrorTable(TB, "Containers", "C.B.M. Is Zero On " & .Cells("CntrNo").Text, ErrMsgtype.Warning)
                        'End If

                        'If Val(.Cells("Net").Text) = 0 Then
                        '    AddRowToErrorTable(TB, "Containers", "NET Weight Is Zero On " & .Cells("CntrNo").Text, ErrMsgtype.Warning)
                        'End If

                        If Val(.Cells("NoOfPkgs").Text) = 0 Then
                            AddRowToErrorTable(TB, "Containers", "Package Is Zero On " & Row.Cells("CntrNo").Text, ErrMsgtype.Err)
                        End If

                        If Trim(.Cells("PackageType").Text) = "" Then
                            AddRowToErrorTable(TB, "Containers", "Package Type Is Blank On " & Row.Cells("CntrNo").Text, ErrMsgtype.Err)
                        End If

                    End If
                End With

            End If

        Next

    End Sub

    Private Sub ToolbarRight_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarRight.ToolClick
        Select Case e.Tool.Key

            Case "Imco"
                If Me.GridCntrs.Rows.Count = 0 Then
                    Exit Sub
                End If
                OpenImcoFrm()
            Case "Pkgs"
            Case "GetCntrsBaseonBooking"
                OpenImportCntrs()

            Case "Temprature"
                If Me.GridCntrs.Rows.Count = 0 Then
                    Exit Sub
                End If
                OpenTempFrm()

            Case "ImportEmptyContainers"

                ImportsFromEcsMrtCntrs()

        End Select

    End Sub
    Private Sub OpenImcoFrm()

        Dim Frm As FrmImco

        Frm = New FrmImco(Me.GridCntrs.ActiveRow.Cells("ID").Value, Me.CntrsDS.Tables("CnsImco"), Me.CntrsDS.Tables("Cntrs"), Me)
        Frm.ShowDialog()
        Frm = Nothing
        Colorized()
    End Sub

    Private Sub OpenTempFrm()

        Dim Frm As FrmTemp

        Frm = New FrmTemp(Me.GridCntrs.ActiveRow.Cells("ID").Value, Me.CntrsDS.Tables("CnsTemprature"), Me.CntrsDS.Tables("Cntrs"), Me)
        Frm.ShowDialog()
        Frm = Nothing
        Colorized()
    End Sub


    Private Sub OpenImportCntrs()

        Dim Frm As FrmBookingCntrs

        If BkID = Guid.Empty Then
            MsgBox("no Valid Booking !")
            Exit Sub
        End If

        Frm = New FrmBookingCntrs(Me.BLID, BkID, Me.CntrsDS.Tables("Cntrs"))
        If Frm.FormAns = True Then
            Frm.Show()
        Else
            Frm = Nothing
        End If

    End Sub

    Public Property BookingID() As Guid
        Get
            Return BkID
        End Get
        Set(ByVal value As Guid)
            BkID = value
        End Set
    End Property

    Public ReadOnly Property TotalCntrString() As String
        Get
            Return Me.LableTotal.Text
        End Get
    End Property

    'Private Sub InitTemp(ByVal IOut As InOut)

    '    Dim Tb As DataTable
    '    Dim Col As DataColumn
    '    Dim sLeader As String


    '    Me.GridCntrs.DataSource = Nothing
    '    CntrsDS = New DataSet
    '    If IOut = InOut.InWard Then
    '        sLeader = "Tb_Inward"
    '    Else
    '        sLeader = "Tb_Outward"
    '    End If

    '    Tb = New DataTable

    '    Tb.TableName = sLeader & "Cntrs"
    '    Col = New DataColumn("ID", System.Type.GetType("System.Guid"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("BLID", System.Type.GetType("System.Guid"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("CntrNo", System.Type.GetType("System.String"))
    '    Col.Caption = "Container No."
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("CnSize", System.Type.GetType("System.String"))
    '    Col.Caption = "Size"
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("CnType", System.Type.GetType("System.String"))
    '    Col.Caption = "Type"
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("SealNo", System.Type.GetType("System.String"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("TW", System.Type.GetType("System.Int64"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("GW", System.Type.GetType("System.Double"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("CBM", System.Type.GetType("System.Double"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("Net", System.Type.GetType("System.Double"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("FLE", System.Type.GetType("System.String"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("SOC", System.Type.GetType("System.String"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("PackageType", System.Type.GetType("System.String"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)


    '    Col = New DataColumn("NoOFPkgs", System.Type.GetType("System.Int64"))
    '    Col.Caption = "PKGS"
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Me.CntrsDS.Tables.Add(Tb)


    '    Tb = New DataTable
    '    Tb.TableName = sLeader & "CnsImco"
    '    Col = New DataColumn("ID", System.Type.GetType("System.Guid"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("CntrID", System.Type.GetType("System.Guid"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("UNNO", System.Type.GetType("System.String"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("FlashPoint", System.Type.GetType("System.Double"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("PakingGroup", System.Type.GetType("System.String"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("IMDGCode", System.Type.GetType("System.String"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Me.CntrsDS.Tables.Add(Tb)



    '    Tb = New DataTable
    '    Tb.TableName = sLeader & "CnsPkgs"
    '    Col = New DataColumn("ID", System.Type.GetType("System.Guid"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("CntrID", System.Type.GetType("System.Guid"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("PackageType", System.Type.GetType("System.String"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)


    '    Col = New DataColumn("NoOFPkgs", System.Type.GetType("System.Int64"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Me.CntrsDS.Tables.Add(Tb)


    '    Tb = New DataTable
    '    Tb.TableName = sLeader & "CnsTemprature"
    '    Col = New DataColumn("ID", System.Type.GetType("System.Guid"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("CntrID", System.Type.GetType("System.Guid"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("Min", System.Type.GetType("System.Double"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Col = New DataColumn("Max", System.Type.GetType("System.Double"))
    '    Col.AllowDBNull = True
    '    Tb.Columns.Add(Col)

    '    Me.CntrsDS.Tables.Add(Tb)


    '    Me.GridCntrs.DataSource = Me.CntrsDS.Tables(sLeader & "Cntrs")


    'End Sub

    Public ReadOnly Property GetCntrsChanges() As DataSet
        Get
            Me.GridCntrs.UpdateData()
            Return CntrsDS.GetChanges
        End Get
    End Property

    Public Sub AcceptCntrsChanges()
        CntrsDS.AcceptChanges()
    End Sub

    Private Sub GridCntrs_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCntrs.AfterRowsDeleted
        RecalculateSummary()
    End Sub

    Private Sub GridCntrs_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GridCntrs.AfterRowUpdate
        Call RecalculateSummary()
    End Sub

    'Private Sub GridCntrs_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGridBeforeCellUpdateEventArgs) Handles GridCntrs.BeforeCellUpdate

    '    If GridCntrs.ActiveCell Is Nothing Then
    '        Exit Sub
    '    End If
    '    If GridCntrs.ActiveCell.Column.Header.Caption = "CntrNo" Then
    '        If CheckDigit(GridCntrs.ActiveCell.Text) = False Then
    '            MsgBox("Check Digit Failed !", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
    '        Else
    '            Dim sql As String
    '            Dim TB As DataTable
    '            Dim JResult As Boolean
    '            sql = " select TW from [TB_ECSBank] where cntrno = '" & GridCntrs.ActiveCell.Text & "'"
    '            TableBySql(sql, TB, JResult)
    '            If TB.Rows.Count > 0 Then
    '                If Not IsDBNull(TB.Rows(0).Item("TW")) Or Not TB.Rows(0).Item("TW").ToString() = "" Then
    '                    GridCntrs.ActiveRow.Cells("TW").Value = TB.Rows(0).Item("TW")
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub
    
    Private Sub GridCntrs_BeforeExitEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs) Handles GridCntrs.BeforeExitEditMode

        If GridCntrs.ActiveCell Is Nothing Then
            Exit Sub
        End If
        If GridCntrs.ActiveCell.Column.Header.Caption = "CntrNo" Then
            'If CheckDigit(GridCntrs.ActiveCell.Text) = False Then
            If 1 = 2 Then
                MsgBox("Check Digit Failed !", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
            Else
                Dim sql As String
                Dim TB As DataTable
                Dim JResult As Boolean
                sql = " select TW from [TB_ECSBank] where cntrno = '" & GridCntrs.ActiveCell.Text & "'"
                TableBySql(sql, TB, JResult)
                If TB.Rows.Count > 0 Then
                    If Not IsDBNull(TB.Rows(0).Item("TW")) Or Not TB.Rows(0).Item("TW").ToString() = "" Then
                        GridCntrs.ActiveRow.Cells("TW").Value = TB.Rows(0).Item("TW")
                    End If
                End If
            End If
        End If
        
    End Sub
    Private Sub RecalculateSummary()

        Dim Dr As DataRow
        Dim nI As Int16
        Dim sTest As String = ""
        Dim aItems As New ArrayList
        Dim aTotal As New ArrayList
        For Each Dr In CntrsDS.Tables("Cntrs").Rows
            If Dr.RowState <> DataRowState.Deleted Then
                sTest = Dr("CnSize") & " " & Dr("CnType")
                If aItems.Count <> 0 Then
                    nI = aItems.IndexOf(sTest)
                Else
                    nI = -1
                End If
                If nI = -1 Then
                    aItems.Add(sTest)
                    aTotal.Add(1)
                Else
                    aTotal.Item(nI) += 1
                End If
            End If
        Next

        sTest = ""
        For nI = 0 To aItems.Count - 1
            sTest += "( " & aTotal(nI).ToString & " X " & aItems(nI) & " ) "
        Next
        Me.LableTotal.Text = "No Of Containers : " & sTest

    End Sub
    Public Sub Colorized()

        Dim Dmg As DataTable
        Dim Dr() As DataRow
        Dim GRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If IOStatus = InwardOutward.Inward Then
            Dmg = CntrsDS.Tables(1)
        Else
            Dmg = CntrsDS.Tables(1)
        End If

        If Not Dmg Is Nothing Then
            For Each GRow In GridCntrs.Rows
                GRow.CellAppearance.BackColor = Color.White
                Dr = Dmg.Select("CntrID = '" & GRow.Cells("ID").Value.ToString & "'")
                If Dr.Length > 0 Then
                    If Dr(0).RowState <> DataRowState.Deleted Then
                        GRow.Cells("CntrNo").Appearance.BackColor = Color.Salmon
                    End If
                End If
            Next
        End If

    End Sub

    Private Function TotalMtyCntrsGWT() As Double

        Dim Tb As DataTable
        If Me.GridCntrs.Rows.Count = 0 Then
            Return 0
        End If
        Tb = Me.GridCntrs.DataSource.copy
        GridCntrs.UpdateData()
        Return GetSummaryFromDatatable(Infragistics.Win.UltraWinGrid.SummaryType.Sum, Tb, "GW", "FLE = 'E'")

    End Function

    Private Function TotalMtyCntrs() As Int32

        Dim Tb As DataTable
        If Me.GridCntrs.Rows.Count = 0 Then
            Return 0
        End If
        Tb = Me.GridCntrs.DataSource.Copy
        GridCntrs.UpdateData()
        Return GetSummaryFromDatatable(Infragistics.Win.UltraWinGrid.SummaryType.Sum, Tb, "GW", "FLE = 'E'")

    End Function

    Private Sub GridCntrs_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridCntrs.InitializeLayout
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

    End Sub

    Private Sub ImportsFromEcsMrtCntrs()


        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim NewDr As DataRow
        Dim Cmb As UserComboVoyage

        Cmb = Me.Parent.Parent.Parent.Parent.Controls(0).Controls("BlsData").Controls(0).Controls("Fvoyage")

        If Cmb.VoyageID.ToString = "" Then
            MsgBox("No Valid Voyage !")
            Exit Sub
        End If


        CntrsDS.Tables(0).Clear()


        TableBySql("Select *  , " & _
                   "isnull((select Top 1 TareWeight From Tb_IsoType Where CnSize = Ecs.CnSize and OurType = Ecs.CnType),0) as TW " & _
                   " from Tb_EcsContainers Ecs Where OutVoyageID = '" & Cmb.VoyageID.ToString & "' and LastStatus ='EL'", TB, lResult)

        For Each dr In TB.Rows
            NewDr = CntrsDS.Tables(0).NewRow
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = BLID
            NewDr("CntrNo") = dr("CntrNo")
            NewDr("CnSize") = dr("CnSize")
            NewDr("CnType") = dr("CnType")
            NewDr("FLE") = "E"
            NewDr("SOC") = dr("SOC")

            If dr("TW") = 0 Then
                If dr("CnSize") = 20 Then
                    NewDr("TW") = 2200
                Else
                    NewDr("GW") = 4000
                End If
            Else
                NewDr("TW") = dr("TW")
            End If
            NewDr("CBM") = 0
            NewDr("GW") = 0
            NewDr("SealNo") = ""
            NewDr("Net") = 0
            CntrsDS.Tables(0).Rows.Add(NewDr)

        Next
        RecalculateSummary()

    End Sub



    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class
