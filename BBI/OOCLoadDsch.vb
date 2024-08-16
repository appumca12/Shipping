Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports System.IO
Public Class OOCLoadDsch

    Dim DM As DataManager
    Dim TB As DataTable
    
    Public Function GenerateLoadList(ByVal VoyageID As Guid, ByVal RotationNo As String) As Boolean

        Dim FleName As String
        Dim Ans As Boolean = False
        Dim Dr As DataRow
        Dim Cmd As SqlCommand
        Dim Cnn As SqlConnection
        Dim DA As New SqlDataAdapter
        Dim TBTemp As New DataTable
        Dim SW As StreamWriter
        Dim Str As String

        FleName = SaveFile()

        If FleName = "" Then
            Return Ans
            Exit Function
        End If

        Cmd = New SqlCommand("SP_OOCLLoadList")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@VoyageID", VoyageID.ToString)
        Cmd.Connection = Cnn
        DA.SelectCommand = Cmd
        DA.Fill(TBTemp)

        If TBTemp.Rows.Count = 0 Then
            MsgBox("No Data !")
            Return Ans
        End If

        For Each CnDr As DataRow In TBTemp.Rows
            Dr = TB.NewRow
            Dr("rotation_no") = RotationNo
            Dr("line_code") = "OOCL"
            Dr("container_no") = CnDr("CntrNo").ToString.Substring(0, 10)
            Dr("check_dgt") = CnDr("CntrNo").ToString.Substring(10, 1)
            Dr("iso_code") = CnDr("CnSize") & CnDr("CnType") '  IsoCntr.TypeToIso(CnDr("CnSize") & CnDr("CnType"))
            Dr("designation") = "T/S"
            Dr("Load_Port") = "IRBND"
            Dr("Discharge_port") = CnDr("ReturnTo")
            Dr("Destination_port") = CnDr("Destination")
            If NullToValue(CnDr("GW"), 0) > 0 Then
                Dr("weight_in_kl") = Int(CnDr("GW") / 1000)
            Else
                Dr("weight_in_kl") = 0
            End If
            Dr("imco_code") = NullToValue(CnDr("Imdg"), "")
            Dr("un_no_of_imco") = NullToValue(CnDr("UNNO"), "")
            Dr("reefer_set_temp") = NullToValue(CnDr("Temprature"), "")
            TB.Rows.Add(Dr)
        Next
        Str = ""
        SW = New StreamWriter(FleName)
        For Each Col As DataColumn In TB.Columns
            If Col.ColumnName.Substring(1, 5) <> "Field" Then
                Str += IIf(Str.Length > 0, ",", "")
                Str += Col.ColumnName.Replace("_", " ")
            End If
        Next
        SW.WriteLine(Str)
        For Each Dr In TB.Rows
            Str = ""
            For Each Col As DataColumn In TB.Columns
                If Col.ColumnName.Substring(1, 5) <> "Field" Then
                    Str += IIf(Str.Length > 0, ",", "")
                    Str += NullToValue(Dr(Col.ColumnName), "")
                End If
            Next
            SW.WriteLine(Str)
        Next

        SW.Flush()
        SW.Close()
        Process.Start(FleName)

    End Function

    Private Function SaveFile() As String

        Dim SaveDialog As New SaveFileDialog
        SaveDialog.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*"
        SaveDialog.ShowDialog()
        Return SaveDialog.FileName

    End Function
    Public Sub New()

        Dim sFld As String = "rotation no,line code,container no,check dgt,iso code,designation,stowage,seal no,content code,origin port,load port,discharge port ,destination port ,consignee name,weight in kl,imco code,un no of imco,imco code 2,un no of imco 2,imco code 3,un no of imco 3,reefer set temp,unit of temp.,out of guage indicator,out of guage in Cms Top,out of guage in Cms Right,out of guage in Cms Left,out of guage in Cms Front,out of guage in Cms Back,Source Code,Vessel Code,Agents Voyage NO,Outbound Rotation,IPT Indicator,"
        Dim aFld() As String
        Dim nSeq As Byte
        TB = New DataTable

        aFld = sFld.Split(",")

        For Each fld As String In aFld
            fld = Trim(fld)
            If Trim(fld) = "" Then
                nSeq += 1
                fld = "Field" & nSeq.ToString
            End If
            TB.Columns.Add(New DataColumn(fld.Replace(" ", "_")))

        Next





    End Sub
End Class
