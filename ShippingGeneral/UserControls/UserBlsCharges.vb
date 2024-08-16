Imports ShippingBiz
Imports OrmLib

Public Class UserBlsCharges
  
    Private BLID As Guid
    Private Clr As Color
    Private IE As InwardOutward
    Enum InwardOutward
        Inward
        Outward
    End Enum
    Public Sub InitControl()

        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim dm As New DataManager(My.Settings.DSN)

        If dm Is Nothing Then
            dm = New DataManager(My.Settings.DSN)
        End If

        dm.GetTB_PortsCollection()
        Me.ChargesList.UpdateData()

        With Me.DropDownTerms
            .DataSource = GetCodeList("CP")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 200
        End With

        With Me.DropDownCharges
            .DataSource = GetCodeList("CG")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 200
        End With

        With Me.DropDownCurrency
            .DataSource = GetCodeList("CU")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 200
        End With


        With Me.DropDownChgBase
            .DataSource = GetCodeList("CB")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Width = 200
        End With

        With Me.ChargesList.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("BLID").Hidden = True
            .Columns("Seq").MaskInput = "{LOC}nn"
            .Columns("Qty").MaskInput = "{LOC}n,nnn"
            .Columns("Rate").MaskInput = "{LOC}nnn,nnn,nnn.nn"
            .Columns("Amount").MaskInput = "{LOC}nnn,nnn,nnn.nn"

            .Columns("Currency").Style _
                                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("Currency").ValueList = Me.DropDownCurrency

            .Columns("ChargesCode").Style _
                                        = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ChargesCode").ValueList = Me.DropDownCharges

            .Columns("ChargesBase").Style _
                                       = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ChargesBase").ValueList = Me.DropDownChgBase

            .Columns("Terms").Style _
                                        = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("Terms").ValueList = Me.DropDownTerms
          
        End With




        Me.ChargesList.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.RowsAndCells

    End Sub

    Public Sub SetDocument(ByVal BID As Guid, ByVal TB As DataTable, ByVal ImpExp As InwardOutward)


        Dim TBCnsChg As New DataTable
        Dim lResult As Boolean

        BLID = BID
        IE = ImpExp

        If Not Me.DatasetForm.Tables("Charges") Is Nothing Then
            Me.DatasetForm.Tables("Charges").Clear()
        End If

        If Not TB Is Nothing Then
            Me.DatasetForm.Tables("Charges").Merge(TB)
        End If

        If IE = InwardOutward.Inward Then
            TableBySql("SP_InwardCntrsChargesTotal '" & BLID.ToString & "'", TBCnsChg, lResult)
        Else
            TableBySql("SP_OutwardCntrsChargesTotal '" & BLID.ToString & "'", TBCnsChg, lResult)
        End If

        Me.GridCnCharges.DataSource = TBCnsChg

        With GridCnCharges
            .Text = "Container Charges Summary"
            .DisplayLayout.Bands(0).Header.Caption = "Container Charges Summary"
            .DisplayLayout.Bands(0).Columns("RealAmount").MaskInput = "{LOC}nnn,nnn,nnn.nn"
            .DisplayLayout.Bands(0).Columns("UnitRate").MaskInput = "{LOC}nnn,nnn,nnn.nn"
            .DisplayLayout.Bands(0).Columns("RealAmount").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals
            .DisplayLayout.Bands(0).Columns("UnitRate").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals


            .DisplayLayout.Bands(0).Columns("MEARate").Hidden = True
            .DisplayLayout.Bands(0).Columns("WGTRate").Hidden = True
            .DisplayLayout.Bands(0).Columns("MinRate").Hidden = True
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        End With

        With Me.ChargesList.DisplayLayout.Bands(0)
            .Columns("ActPlaceExRate").Hidden = True
            .Columns("MeaUnitofCharge").Hidden = True
            .Columns("PayAtBranch").Hidden = True
            .Columns("PayAtExRate").Hidden = True
            .Columns("PayAtPC").Hidden = True
            .Columns("ChargesBase").Hidden = True
        End With

    End Sub

    Public Sub GetDocument(ByRef TB As DataTable)

        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim dv As DataView
        Dim ChgsTB As DataTable

        Me.ChargesList.UpdateData()

        ChgsTB = Me.DatasetForm.Tables("Charges").GetChanges
        If Not ChgsTB Is Nothing Then
            For Each Dr In ChgsTB.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        NewDr = TB.NewRow
                        NewDr("ID") = Guid.NewGuid
                        NewDr("BLID") = BLID
                        NewDr("Seq") = Dr("Seq")
                        NewDr("ChargesCode") = Dr("ChargesCode")
                        NewDr("Qty") = Dr("Qty")
                        NewDr("Currency") = Dr("Currency")
                        NewDr("Amount") = Dr("Qty") * Dr("Rate")  'Dr("Amount")
                        NewDr("Rate") = Dr("Rate")
                        NewDr("PayAt") = Dr("PayAt")
                        NewDr("ChargesBase") = Dr("ChargesBase")
                        NewDr("Terms") = Dr("Terms")
                        TB.Rows.Add(NewDr)
                    Case DataRowState.Deleted
                        dv = New DataView(TB, "ID = '" & Dr("ID", DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If dv.Count > 0 Then
                            dv.Item(0).Delete()
                        End If
                    Case DataRowState.Modified
                        dv = New DataView(TB, "ID = '" & Dr("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                        If dv.Count > 0 Then
                            With dv.Item(0)
                                .Item("Seq") = Dr("Seq")
                                .Item("ChargesCode") = Dr("ChargesCode")
                                .Item("Qty") = Dr("Qty")
                                .Item("Currency") = Dr("Currency")
                                .Item("Amount") = Dr("Qty") * Dr("Rate") 'Dr("Amount")
                                .Item("Rate") = Dr("Rate")
                                .Item("PayAt") = Dr("PayAt")
                                .Item("ChargesBase") = Dr("ChargesBase")
                                .Item("Terms") = Dr("Terms")
                            End With
                        End If
                End Select
            Next
        End If
    End Sub

    
    Private Sub ChargesList_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles ChargesList.BeforeRowUpdate
        Dim Tb As New DataTable
        If ChargesList.ActiveRow.Cells("ID").Text = "" Then
            ChargesList.ActiveRow.Cells("ID").Value = Guid.NewGuid
        End If
        If ChargesList.ActiveRow.Cells("BLID").Text = "" Then
            ChargesList.ActiveRow.Cells("BLID").Value = BLID
        End If
        Checking(Tb)
    End Sub

    Public Function Checking(ByVal Tb As DataTable) As Boolean

        Dim Dr As DataRow
        Dim Ans As Boolean = True

        For Each Dr In Me.DatasetForm.Tables(0).Rows

            If Dr.RowState <> DataRowState.Deleted Then
                With Dr

                    If NullToValue(Dr("Seq"), 0) = 0 Then
                        Dr.SetColumnError("Seq", "Seq is Empty Or Zero !")
                    Else
                        Dr.SetColumnError("Seq", "")
                    End If

                    If NullToValue(Dr("ChargesCode"), "") = "" Then
                        Dr.SetColumnError("ChargesCode", "Charges Code Is Empty !")
                    Else
                        Dr.SetColumnError("ChargesCode", "")
                    End If

                    If NullToValue(Dr("Currency"), "") = "" Then
                        Dr.SetColumnError("Currency", "Currency Code Is Empty !")
                    Else
                        Dr.SetColumnError("Currency", "")
                    End If

                    If NullToValue(Dr("Qty"), 0) = 0 Then
                        Dr.SetColumnError("Qty", "Quantity Empty Or Zero !")
                    Else
                        Dr.SetColumnError("Qty", "")
                    End If

                    If NullToValue(Dr("Rate"), 0) = 0 Then
                        Dr.SetColumnError("Rate", "Rate Empty Or Zero !")
                    Else
                        Dr.SetColumnError("Rate", "")
                    End If


                    If NullToValue(Dr("Amount"), 0) = 0 Then
                        Dr.SetColumnError("Amount", "Amount Empty Or Zero !")
                    Else
                        Dr.SetColumnError("Amount", "")
                    End If

                    If Dr.GetColumnError("Seq").Length + _
                       Dr.GetColumnError("ChargesCode").Length + _
                       Dr.GetColumnError("Currency").Length + _
                       Dr.GetColumnError("Qty").Length + _
                       Dr.GetColumnError("Rate").Length + _
                       Dr.GetColumnError("Amount").Length > 0 Then
                        Dr.RowError = "Check The Data !"
                        Ans = False
                        AddRowToErrorTable(Tb, "Charges", "Charges Not Completed !", ErrMsgtype.Err)
                    Else
                        Dr.RowError = ""
                    End If

                End With
            End If

        Next


        Return Ans

    End Function

    Public ReadOnly Property ChrgesTable() As DataTable
        Get
            Return Me.DatasetForm.Tables("Charges")
        End Get
    End Property

End Class
