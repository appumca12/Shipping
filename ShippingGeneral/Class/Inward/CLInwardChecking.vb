Imports OrmLib
Imports ShippingBiz

Public Class CLInwardChecking

    Private Dm As DataManager
    Private Bls As TB_InwardBLSCollection
    Private TB As DataTable
    Private lError As Boolean = False
  
    Public Sub CheckingByBLID(ByVal BLNO As String)
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, BLNO, MatchType.Exact)
        Bls = Dm.GetTB_InwardBLSCollection()
        If Not Bls Is Nothing Then
            Checking()
        End If

    End Sub
    Public Sub CheckingByVoyage(ByVal VoyageID As Guid)
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.VoyageID, VoyageID, MatchType.Exact)
        Bls = Dm.GetTB_InwardBLSCollection()
        If Not Bls Is Nothing Then
            Checking()
        End If

    End Sub

    Private Sub Checking()

        Dim BL As TB_InwardBLS
        Dim Cns As TB_InwardCntrsCollection
        Dim Cn As TB_InwardCntrs
        Dim Names As TB_InwardBlsNamesCollection
        Dim Goods As TB_InwardBlsGoodsCollection
        Dim Frs As TB_InwardChargesCollection
        Dim Fr As TB_InwardCharges

        Dim TTW As Long = 0
        Dim TGW As Long = 0
        Dim TNet As Long = 0
        Dim TPkgs As Long = 0

        For Each BL In Bls

        
            If IsDBNull(BL.IssueDate) Then
                AddRowToErrorTable(TB, "B/L Basic Data", "Issue Date Is Blank ! " & BL.BlNo, ErrMsgtype.Warning)
            End If

            If IsDBNull(BL.OnBoardDate) Then
                AddRowToErrorTable(TB, "B/L Basic Data", "OnBoard Date Is Blank ! " & BL.BlNo, ErrMsgtype.Warning)
            End If

            If NullToValue(BL.IssuePlace, "") = "" Then
                AddRowToErrorTable(TB, "B/L Basic Data", "Issue Place Is Wrong !" & BL.BlNo, ErrMsgtype.Err)
            End If

            If NullToValue(BL.POR, "") = "" Then
                AddRowToErrorTable(TB, "B/L Basic Data", "P.O.R. Is Wrong ! " & BL.BlNo, ErrMsgtype.Err)
            End If

            If NullToValue(BL.POL, "") = "" Then
                AddRowToErrorTable(TB, "B/L Basic Data", "P.O.L. Is Wrong ! " & BL.BlNo, ErrMsgtype.Err)
            End If

            If NullToValue(BL.POT, "") = "" Then
                AddRowToErrorTable(TB, "B/L Basic Data", "P.O.T. Is Wrong ! " & BL.BlNo, ErrMsgtype.Warning)
            End If

            If NullToValue(BL.FPOD, "") = "" Then
                AddRowToErrorTable(TB, "B/L Basic Data", "F.POD Is Wrong ! " & BL.BlNo, ErrMsgtype.Err)
            End If

            If NullToValue(BL.VoyageID, "").ToString = "" Then
                AddRowToErrorTable(TB, "B/L Basic Data", "Vessel Voyage Is Wrong ! " & BL.BlNo, ErrMsgtype.Err)
            End If

            Try
                If NullToValue(BL.PreVoyageID, "").ToString = "" Then
                    AddRowToErrorTable(TB, "B/L Basic Data", "M/Vessel Voyage Is Wrong ! " & BL.BlNo, ErrMsgtype.Warning)
                End If
            Catch ex As Exception

            End Try
         
            If NullToValue(BL.TermsOfPayment, "") = "" Then
                AddRowToErrorTable(TB, "B/L Basic Data", "Terms Of Payment Is Blank ! " & BL.BlNo, ErrMsgtype.Err)
            End If

            If BL.NoOfBls = 0 Then
                AddRowToErrorTable(TB, "B/L Basic Data", "No Of BL/s Is Zero ! " & BL.BlNo, ErrMsgtype.Err)
            End If

            If NullToValue(BL.FCLType, "") = "" Then
                AddRowToErrorTable(TB, "B/L Basic Data", "FCL/LCL Is Wrong ! " & BL.BlNo, ErrMsgtype.Err)
            End If

            If NullToValue(BL.Service, "") = "" Then
                AddRowToErrorTable(TB, "B/L Basic Data", "Service Is Wrong ! " & BL.BlNo, ErrMsgtype.Err)
            End If

            Try
                If NullToValue(BL.ClientID, "").ToString = "" Then
                    AddRowToErrorTable(TB, "B/L Basic Data", "Clients Is Wrong ! " & BL.BlNo, ErrMsgtype.Err)
                End If

            Catch ex As Exception

            End Try
      
            If NullToValue(BL.LcNo, "") = "" Then
                AddRowToErrorTable(Tb, "B/L Basic Data", "L/C No Is Blank !", ErrMsgtype.Warning)
            End If


            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, BL.ID, MatchType.Exact)
            Cns = Dm.GetTB_InwardCntrsCollection

            For Each Cn In Cns

                TPkgs += Cn.NoOFPkgs
                TTW += Cn.TW
                TGW += Cn.GW
                Try
                    TNet += IIf(IsDBNull(Cn.NET), 0, Cn.NET)
                Catch ex As Exception
                End Try

                If Cn.CntrNo = "" Then
                    AddRowToErrorTable(TB, "Containers", "Container No is Blak On " & Cn.CntrNo, ErrMsgtype.Err)
                End If

                If Cn.CnSize = "" Then
                    AddRowToErrorTable(TB, "Containers", "Container Size Is Wrong On " & Cn.CntrNo, ErrMsgtype.Err)
                End If

                If Cn.CnType = "" Then
                    AddRowToErrorTable(TB, "Containers", "Container Type Is Wrong On " & Cn.CntrNo, ErrMsgtype.Err)
                End If

                If Cn.FLE = "" Then
                    AddRowToErrorTable(TB, "Containers", "Container FLE Is Wrong On " & Cn.CntrNo, ErrMsgtype.Err)
                End If

                If Cn.TW = 0 Then
                    AddRowToErrorTable(TB, "Containers", "Container TW Is Zero On " & Cn.CntrNo, ErrMsgtype.Err)
                End If

                If Cn.SOC = "" Then
                    AddRowToErrorTable(TB, "Containers", "S.O.C. Is Blank On " & Cn.CntrNo, ErrMsgtype.Err)
                End If

                If Cn.FLE <> "E" Then

                    If Cn.GW = 0 Then
                        AddRowToErrorTable(TB, "Containers", "Container Gross Weight Is Zero On " & Cn.CntrNo, ErrMsgtype.Err)
                    End If

                    If Cn.SealNo = "" Then
                        AddRowToErrorTable(TB, "Containers", "Seal No is Blank On " & Cn.CntrNo, ErrMsgtype.Err)
                    End If

                    If Cn.CBM = 0 Then
                        AddRowToErrorTable(TB, "Containers", "C.M.B. Is Zero On " & Cn.CntrNo, ErrMsgtype.Warning)
                    End If

                    If Cn.NET = 0 Then
                        AddRowToErrorTable(TB, "Containers", "NET Weight Is Zero On " & Cn.CntrNo, ErrMsgtype.Warning)
                    End If

                    If Cn.NoOFPkgs = 0 Then
                        AddRowToErrorTable(TB, "Containers", "Package Is Zero On " & Cn.CntrNo, ErrMsgtype.Err)
                    End If

                    If Cn.PackageType = "" Then
                        AddRowToErrorTable(TB, "Containers", "Package Type Is Blank On " & Cn.CntrNo, ErrMsgtype.Err)
                    End If

                End If
            Next

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_InwardBlsNames.Columns.BLID, BL.ID, MatchType.Exact)
            Names = Dm.GetTB_InwardBlsNamesCollection
            If Not Names Is Nothing Then
                If Names(0).Shipper.ToString = "" Then
                    AddRowToErrorTable(Tb, "Names", "No Shipper" & BL.BlNo, ErrMsgtype.Err)
                End If
                If Names(0).Cnee.ToString = "" Then
                    AddRowToErrorTable(Tb, "Names", "No Cnee" & BL.BlNo, ErrMsgtype.Err)
                End If
                If Names(0).Cnee.ToString = "" Then
                    AddRowToErrorTable(Tb, "Names", "No Notgify Party" & BL.BlNo, ErrMsgtype.Err)
                End If
            Else
                AddRowToErrorTable(Tb, "Names", "No Shipper/Cnee/Nofify Record" & BL.BlNo, ErrMsgtype.Err)
            End If

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_InwardBlsGoods.Columns.BLID, BL.ID, MatchType.Exact)
            Goods = Dm.GetTB_InwardBlsGoodsCollection
            If Not Goods Is Nothing Then
                If Goods(0).Goods = "" Then
                    AddRowToErrorTable(TB, "Goods", "No Description Of Goods" & BL.BlNo, ErrMsgtype.Err)
                End If
                If Goods(0).MainCom = "" Then
                    AddRowToErrorTable(TB, "Goods", "Main Commodity is Blank" & BL.BlNo, ErrMsgtype.Err)
                End If
                If Goods(0).Marks = "" Then
                    AddRowToErrorTable(TB, "Goods", "Marks is Blank" & BL.BlNo, ErrMsgtype.Warning)
                End If
                If Goods(0).TGW <> TGW Then
                    AddRowToErrorTable(TB, "Goods", "Total GW Is Wrong " & BL.BlNo, ErrMsgtype.Warning)
                End If

                If Goods(0).TTW <> TGW Then
                    AddRowToErrorTable(TB, "Goods", "Total TW Is Wrong " & BL.BlNo, ErrMsgtype.Warning)
                End If
                If Goods(0).TTLNET <> TGW Then
                    AddRowToErrorTable(TB, "Goods", "Total NET Is Wrong " & BL.BlNo, ErrMsgtype.Warning)
                End If
                If Goods(0).TTLPkgs <> TPkgs Then
                    AddRowToErrorTable(TB, "Goods", "Total Packages Is Wrong " & BL.BlNo, ErrMsgtype.Warning)
                End If
            Else
                AddRowToErrorTable(TB, "Goods", "No Goods Record" & BL.BlNo, ErrMsgtype.Err)
            End If

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_InwardCharges.Columns.BLID, BL.ID, MatchType.Exact)
            Frs = Dm.GetTB_InwardChargesCollection

            If Not Frs Is Nothing Then
                For Each Fr In Frs
                    If Fr.ChargesCode = "" Then
                        AddRowToErrorTable(TB, "Charges", "Charges Code Is Blank" & BL.BlNo, ErrMsgtype.Err)
                    End If
                    If Fr.Amount = 0 Then
                        AddRowToErrorTable(TB, "Charges", "Amount is Zero" & BL.BlNo, ErrMsgtype.Err)
                    End If
                    If Fr.PayAt = "" Then
                        AddRowToErrorTable(TB, "Charges", "Pay Place is blank" & BL.BlNo, ErrMsgtype.Err)
                    End If
                    If Fr.Qty = 0 Then
                        AddRowToErrorTable(TB, "Charges", "Qty is Zero" & BL.BlNo, ErrMsgtype.Err)
                    End If
                    If Fr.Rate = 0 Then
                        AddRowToErrorTable(TB, "Charges", "Rate is Zero" & BL.BlNo, ErrMsgtype.Err)
                    End If
                    If Fr.Terms = "" Then
                        AddRowToErrorTable(TB, "Charges", "Terms is Blank" & BL.BlNo, ErrMsgtype.Err)
                    End If
                Next
            Else
                AddRowToErrorTable(TB, "Charges", "No Charges Record" & BL.BlNo, ErrMsgtype.Err)
            End If

        Next


        If Not TB Is Nothing Then
            If TB.Rows.Count > 0 Then
                lError = True
            End If
        End If

    End Sub

    Public ReadOnly Property ErrTable()
        Get
            Return TB
        End Get
    End Property
    Public Sub ShowError()

        If Not TB Is Nothing Then
            RaiseError(TB)
        End If
    End Sub


    Public ReadOnly Property HasError() As Boolean
        Get
            Return lError
        End Get
    End Property



End Class
