Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Reflection

Imports OrmLib

Namespace ShippingBiz

	Public Class StoredProcedures 
	
        Private Shared dm As New DataManager(CustomSetting.DsnStr)
			

		Public Shared Function SP_OutwardCntrsChargesByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardCntrsChargesByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ClientsByName(   ClientName as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramClientName as new SqlParameter( "@ClientName", ClientName)
			paramClientName.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramClientName.Direction = ParameterDirection.Input
			paramClientName.Size = 50
			arrayParams.Add( paramClientName )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ClientsByName", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardCntrsChargesTotal(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardCntrsChargesTotal", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ClientsListCombo(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_ClientsListCombo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardCntrsCount(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardCntrsCount", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_CNIDSInsertS(   SCNID as System.String, _
   Name as System.String, _
   Tel as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramSCNID as new SqlParameter( "@SCNID", SCNID)
			paramSCNID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramSCNID.Direction = ParameterDirection.Input
			paramSCNID.Size = 50
			arrayParams.Add( paramSCNID )

			Dim paramName as new SqlParameter( "@Name", Name)
			paramName.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramName.Direction = ParameterDirection.Input
			paramName.Size = 510
			arrayParams.Add( paramName )

			Dim paramTel as new SqlParameter( "@Tel", Tel)
			paramTel.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramTel.Direction = ParameterDirection.Input
			paramTel.Size = 50
			arrayParams.Add( paramTel )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_CNIDSInsertS", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardCntrsForCost(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardCntrsForCost", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_CollectionSchdule(   DFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDFrom as new SqlParameter( "@DFrom", DFrom)
			paramDFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDFrom.Direction = ParameterDirection.Input
			paramDFrom.Size = 4
			arrayParams.Add( paramDFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_CollectionSchdule", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardCntrsForInv(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardCntrsForInv", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_CollectListByDate(   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_CollectListByDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardCntrsListByVoyageID(   Line as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardCntrsListByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ContainerTraceByDschCmpl(   Line as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ContainerTraceByDschCmpl", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardCntrsPkgsTotal(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardCntrsPkgsTotal", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_CreateItemInAccessLevel(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_CreateItemInAccessLevel", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardFreightList(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardFreightList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DemurrageControlByIssueTime(   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 20
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DemurrageControlByIssueTime", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardGeneralListBySailed(   DFrom as System.DateTime, _
   DTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDFrom as new SqlParameter( "@DFrom", DFrom)
			paramDFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDFrom.Direction = ParameterDirection.Input
			paramDFrom.Size = 4
			arrayParams.Add( paramDFrom )

			Dim paramDTo as new SqlParameter( "@DTo", DTo)
			paramDTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDTo.Direction = ParameterDirection.Input
			paramDTo.Size = 4
			arrayParams.Add( paramDTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardGeneralListBySailed", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionAllByID(   ID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionAllByID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardOfficialInv(   InvID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramInvID as new SqlParameter( "@InvID", InvID)
			paramInvID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramInvID.Direction = ParameterDirection.Input
			paramInvID.Size = 36
			arrayParams.Add( paramInvID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardOfficialInv", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionDetailByAll(   ImportExport as System.String, _
   DateParam as System.DateTime, _
   CnType as System.String, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramImportExport as new SqlParameter( "@ImportExport", ImportExport)
			paramImportExport.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramImportExport.Direction = ParameterDirection.Input
			paramImportExport.Size = 1
			arrayParams.Add( paramImportExport )

			Dim paramDate as new SqlParameter( "@Date", DateParam)
			paramDate.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "datetime", true)
			paramDate.Direction = ParameterDirection.Input
			paramDate.Size = 8
			arrayParams.Add( paramDate )

			Dim paramCnType as new SqlParameter( "@CnType", CnType)
			paramCnType.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCnType.Direction = ParameterDirection.Input
			paramCnType.Size = 2
			arrayParams.Add( paramCnType )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionDetailByAll", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardSearch(   BLNo as System.String, _
   CntrNo as System.String, _
   POL as System.String, _
   POD as System.String, _
   FPOD as System.String, _
   Shipper as System.String, _
   Cnee as System.String, _
   Notify as System.String, _
   Client as System.String, _
   Goods as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLNo as new SqlParameter( "@BLNo", BLNo)
			paramBLNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNo.Direction = ParameterDirection.Input
            paramBLNo.Size = 100
			arrayParams.Add( paramBLNo )

			Dim paramCntrNo as new SqlParameter( "@CntrNo", CntrNo)
			paramCntrNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCntrNo.Direction = ParameterDirection.Input
			paramCntrNo.Size = 11
			arrayParams.Add( paramCntrNo )

			Dim paramPOL as new SqlParameter( "@POL", POL)
			paramPOL.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPOL.Direction = ParameterDirection.Input
			paramPOL.Size = 5
			arrayParams.Add( paramPOL )

			Dim paramPOD as new SqlParameter( "@POD", POD)
			paramPOD.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPOD.Direction = ParameterDirection.Input
			paramPOD.Size = 5
			arrayParams.Add( paramPOD )

			Dim paramFPOD as new SqlParameter( "@FPOD", FPOD)
			paramFPOD.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramFPOD.Direction = ParameterDirection.Input
			paramFPOD.Size = 5
			arrayParams.Add( paramFPOD )

			Dim paramShipper as new SqlParameter( "@Shipper", Shipper)
			paramShipper.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramShipper.Direction = ParameterDirection.Input
			paramShipper.Size = 30
			arrayParams.Add( paramShipper )

			Dim paramCnee as new SqlParameter( "@Cnee", Cnee)
			paramCnee.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCnee.Direction = ParameterDirection.Input
			paramCnee.Size = 30
			arrayParams.Add( paramCnee )

			Dim paramNotify as new SqlParameter( "@Notify", Notify)
			paramNotify.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramNotify.Direction = ParameterDirection.Input
			paramNotify.Size = 30
			arrayParams.Add( paramNotify )

			Dim paramClient as new SqlParameter( "@Client", Client)
			paramClient.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramClient.Direction = ParameterDirection.Input
			paramClient.Size = 36
			arrayParams.Add( paramClient )

			Dim paramGoods as new SqlParameter( "@Goods", Goods)
			paramGoods.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramGoods.Direction = ParameterDirection.Input
			paramGoods.Size = 30
			arrayParams.Add( paramGoods )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardSearch", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionDetailIDCnType(   DetentionID as System.String, _
   CnType as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDetentionID as new SqlParameter( "@DetentionID", DetentionID)
			paramDetentionID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramDetentionID.Direction = ParameterDirection.Input
			paramDetentionID.Size = 36
			arrayParams.Add( paramDetentionID )

			Dim paramCnType as new SqlParameter( "@CnType", CnType)
			paramCnType.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCnType.Direction = ParameterDirection.Input
			paramCnType.Size = 2
			arrayParams.Add( paramCnType )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionDetailIDCnType", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardStatestical(   ddFrom as System.String, _
   ddTo as System.String, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramddFrom as new SqlParameter( "@ddFrom", ddFrom)
			paramddFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramddFrom.Direction = ParameterDirection.Input
			paramddFrom.Size = 8
			arrayParams.Add( paramddFrom )

			Dim paramddTo as new SqlParameter( "@ddTo", ddTo)
			paramddTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramddTo.Direction = ParameterDirection.Input
			paramddTo.Size = 8
			arrayParams.Add( paramddTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardStatestical", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionExpByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionExpByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardSummary(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardSummary", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionExpByBLIDForLine(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionExpByBLIDForLine", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardTempalteUpdate(   BLID as System.String, _
   XML as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )

			Dim paramXML as new SqlParameter( "@XML", XML)
			paramXML.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "ntext", true)
			paramXML.Direction = ParameterDirection.Input
			paramXML.Size = 16
			arrayParams.Add( paramXML )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardTempalteUpdate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionExpGnrlReport(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionExpGnrlReport", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardTHCByVoyageID(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardTHCByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionExpGnrlReportByLineBL(   Line as System.String, _
   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionExpGnrlReportByLineBL", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardVoyageAccount(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardVoyageAccount", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionExpGnrlReportByLineBLForLine(   Line as System.String, _
   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionExpGnrlReportByLineBLForLine", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardVoyageAccountBySailed(   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardVoyageAccountBySailed", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionGnrlReport(   Line as System.String, _
   Type as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramType as new SqlParameter( "@Type", Type)
			paramType.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramType.Direction = ParameterDirection.Input
			paramType.Size = 1
			arrayParams.Add( paramType )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionGnrlReport", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_PermitGenralListByVoyageID(   Line as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_PermitGenralListByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionGnrlReportBls(   Line as System.String, _
   Type as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramType as new SqlParameter( "@Type", Type)
			paramType.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramType.Direction = ParameterDirection.Input
			paramType.Size = 1
			arrayParams.Add( paramType )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionGnrlReportBls", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_PermitsAllByPermitNo(   PermitNo as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramPermitNo as new SqlParameter( "@PermitNo", PermitNo)
			paramPermitNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPermitNo.Direction = ParameterDirection.Input
			paramPermitNo.Size = 10
			arrayParams.Add( paramPermitNo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_PermitsAllByPermitNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionGnrlReportByLineBL(   Line as System.String, _
   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionGnrlReportByLineBL", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_PrintInwardBls(   Line as System.String, _
   BlNo as System.String, _
   ShowGoods as System.String, _
   ShowCntrs as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBlNo as new SqlParameter( "@BlNo", BlNo)
			paramBlNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBlNo.Direction = ParameterDirection.Input
            paramBlNo.Size = 100
			arrayParams.Add( paramBlNo )

			Dim paramShowGoods as new SqlParameter( "@ShowGoods", ShowGoods)
			paramShowGoods.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramShowGoods.Direction = ParameterDirection.Input
			paramShowGoods.Size = 1
			arrayParams.Add( paramShowGoods )

			Dim paramShowCntrs as new SqlParameter( "@ShowCntrs", ShowCntrs)
			paramShowCntrs.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramShowCntrs.Direction = ParameterDirection.Input
			paramShowCntrs.Size = 1
			arrayParams.Add( paramShowCntrs )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_PrintInwardBls", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionGnrlReportByLineBLForLine(   Line as System.String, _
   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionGnrlReportByLineBLForLine", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_PrintInwardBlsTran(   Line as System.String, _
   BlNo as System.String, _
   ShowGoods as System.String, _
   ShowCntrs as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBlNo as new SqlParameter( "@BlNo", BlNo)
			paramBlNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBlNo.Direction = ParameterDirection.Input
            paramBlNo.Size = 100
			arrayParams.Add( paramBlNo )

			Dim paramShowGoods as new SqlParameter( "@ShowGoods", ShowGoods)
			paramShowGoods.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramShowGoods.Direction = ParameterDirection.Input
			paramShowGoods.Size = 1
			arrayParams.Add( paramShowGoods )

			Dim paramShowCntrs as new SqlParameter( "@ShowCntrs", ShowCntrs)
			paramShowCntrs.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramShowCntrs.Direction = ParameterDirection.Input
			paramShowCntrs.Size = 1
			arrayParams.Add( paramShowCntrs )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_PrintInwardBlsTran", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionGnrlReportForLine(   Line as System.String, _
   Type as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramType as new SqlParameter( "@Type", Type)
			paramType.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramType.Direction = ParameterDirection.Input
			paramType.Size = 1
			arrayParams.Add( paramType )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionGnrlReportForLine", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_PrintOutwardBls(   Line as System.String, _
   BlNo as System.String, _
   ShowGoods as System.String, _
   ShowCntrs as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBlNo as new SqlParameter( "@BlNo", BlNo)
			paramBlNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBlNo.Direction = ParameterDirection.Input
            paramBlNo.Size = 100
			arrayParams.Add( paramBlNo )

			Dim paramShowGoods as new SqlParameter( "@ShowGoods", ShowGoods)
			paramShowGoods.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramShowGoods.Direction = ParameterDirection.Input
			paramShowGoods.Size = 1
			arrayParams.Add( paramShowGoods )

			Dim paramShowCntrs as new SqlParameter( "@ShowCntrs", ShowCntrs)
			paramShowCntrs.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramShowCntrs.Direction = ParameterDirection.Input
			paramShowCntrs.Size = 1
			arrayParams.Add( paramShowCntrs )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_PrintOutwardBls", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionImpByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionImpByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_PrintOutwardBlsTran(   Line as System.String, _
   BlNo as System.String, _
   ShowGoods as System.String, _
   ShowCntrs as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBlNo as new SqlParameter( "@BlNo", BlNo)
			paramBlNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBlNo.Direction = ParameterDirection.Input
            paramBlNo.Size = 100
			arrayParams.Add( paramBlNo )

			Dim paramShowGoods as new SqlParameter( "@ShowGoods", ShowGoods)
			paramShowGoods.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramShowGoods.Direction = ParameterDirection.Input
			paramShowGoods.Size = 1
			arrayParams.Add( paramShowGoods )

			Dim paramShowCntrs as new SqlParameter( "@ShowCntrs", ShowCntrs)
			paramShowCntrs.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramShowCntrs.Direction = ParameterDirection.Input
			paramShowCntrs.Size = 1
			arrayParams.Add( paramShowCntrs )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_PrintOutwardBlsTran", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionImpByBLIDForLine(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionImpByBLIDForLine", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ReadyCntrsForpermit(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ReadyCntrsForpermit", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionListByArrival(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionListByArrival", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ReadyEmptyCntrsForLoad(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ReadyEmptyCntrsForLoad", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionListByEA(   ImportExport as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramImportExport as new SqlParameter( "@ImportExport", ImportExport)
			paramImportExport.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramImportExport.Direction = ParameterDirection.Input
			paramImportExport.Size = 1
			arrayParams.Add( paramImportExport )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionListByEA", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ReadyFullCntrsForLoad(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ReadyFullCntrsForLoad", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DetentionListConfirmDate(   ImportExport as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramImportExport as new SqlParameter( "@ImportExport", ImportExport)
			paramImportExport.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramImportExport.Direction = ParameterDirection.Input
			paramImportExport.Size = 1
			arrayParams.Add( paramImportExport )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DetentionListConfirmDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ReleasePendingList(   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   BaseOnIssue as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramBaseOnIssue as new SqlParameter( "@BaseOnIssue", BaseOnIssue)
			paramBaseOnIssue.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBaseOnIssue.Direction = ParameterDirection.Input
			paramBaseOnIssue.Size = 1
			arrayParams.Add( paramBaseOnIssue )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ReleasePendingList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_DowenDate(   Line as System.String, _
   Status as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramStatus as new SqlParameter( "@Status", Status)
			paramStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramStatus.Direction = ParameterDirection.Input
			paramStatus.Size = 10
			arrayParams.Add( paramStatus )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_DowenDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_RptExpInvoice(   InvoiceID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramInvoiceID as new SqlParameter( "@InvoiceID", InvoiceID)
			paramInvoiceID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramInvoiceID.Direction = ParameterDirection.Input
			paramInvoiceID.Size = 36
			arrayParams.Add( paramInvoiceID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_RptExpInvoice", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsAllDataByID(   ID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsAllDataByID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_RptInvoice(   InvoiceID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramInvoiceID as new SqlParameter( "@InvoiceID", InvoiceID)
			paramInvoiceID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramInvoiceID.Direction = ParameterDirection.Input
			paramInvoiceID.Size = 36
			arrayParams.Add( paramInvoiceID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_RptInvoice", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsCntrsByLastStatus(   Line as System.String, _
   Status as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramStatus as new SqlParameter( "@Status", Status)
			paramStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramStatus.Direction = ParameterDirection.Input
			paramStatus.Size = 5
			arrayParams.Add( paramStatus )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsCntrsByLastStatus", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_RptInwardMnfSummary(   ID as System.String, _
   Doc as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramDoc as new SqlParameter( "@Doc", Doc)
			paramDoc.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "ntext", true)
			paramDoc.Direction = ParameterDirection.Input
			paramDoc.Size = 16
			arrayParams.Add( paramDoc )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_RptInwardMnfSummary", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsContainersByBookingID(   Line as System.String, _
   BookingID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBookingID as new SqlParameter( "@BookingID", BookingID)
			paramBookingID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBookingID.Direction = ParameterDirection.Input
			paramBookingID.Size = 36
			arrayParams.Add( paramBookingID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsContainersByBookingID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_RptoutwardMnfSummary(   ID as System.String, _
   Doc as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramDoc as new SqlParameter( "@Doc", Doc)
			paramDoc.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "ntext", true)
			paramDoc.Direction = ParameterDirection.Input
			paramDoc.Size = 16
			arrayParams.Add( paramDoc )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_RptoutwardMnfSummary", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsContainerSearch(   CntrNo as System.String, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramCntrNo as new SqlParameter( "@CntrNo", CntrNo)
			paramCntrNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCntrNo.Direction = ParameterDirection.Input
			paramCntrNo.Size = 11
			arrayParams.Add( paramCntrNo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsContainerSearch", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_SalesActivity(   SalesMan as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramSalesMan as new SqlParameter( "@SalesMan", SalesMan)
			paramSalesMan.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramSalesMan.Direction = ParameterDirection.Input
			paramSalesMan.Size = 36
			arrayParams.Add( paramSalesMan )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_SalesActivity", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsDailyReport(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsDailyReport", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_SaveObjects(   ObjectName as System.String, _
   ObjectContent as System.Byte(), _
   Remarks as System.String, _
   CreateDate as System.DateTime, _
   ModifyDate as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramObjectName as new SqlParameter( "@ObjectName", ObjectName)
			paramObjectName.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramObjectName.Direction = ParameterDirection.Input
			paramObjectName.Size = 100
			arrayParams.Add( paramObjectName )

			Dim paramObjectContent as new SqlParameter( "@ObjectContent", ObjectContent)
			paramObjectContent.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "image", true)
			paramObjectContent.Direction = ParameterDirection.Input
			paramObjectContent.Size = 16
			arrayParams.Add( paramObjectContent )

			Dim paramRemarks as new SqlParameter( "@Remarks", Remarks)
			paramRemarks.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramRemarks.Direction = ParameterDirection.Input
			paramRemarks.Size = 200
			arrayParams.Add( paramRemarks )

			Dim paramCreateDate as new SqlParameter( "@CreateDate", CreateDate)
			paramCreateDate.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramCreateDate.Direction = ParameterDirection.Input
			paramCreateDate.Size = 4
			arrayParams.Add( paramCreateDate )

			Dim paramModifyDate as new SqlParameter( "@ModifyDate", ModifyDate)
			paramModifyDate.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramModifyDate.Direction = ParameterDirection.Input
			paramModifyDate.Size = 4
			arrayParams.Add( paramModifyDate )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_SaveObjects", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsEmptyListByVoyageID(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsEmptyListByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_SeasonReportByDateLine(   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 20
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_SeasonReportByDateLine", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsGenralReport(   Line as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "datetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 8
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "datetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 8
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsGenralReport", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_SendHtmMail(   Subject as System.String, _
   ToParam as System.String, _
   CC as System.String, _
   HTML as System.String, _
   profile as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramSubject as new SqlParameter( "@Subject", Subject)
			paramSubject.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramSubject.Direction = ParameterDirection.Input
			paramSubject.Size = 500
			arrayParams.Add( paramSubject )

			Dim paramTo as new SqlParameter( "@To", ToParam)
			paramTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramTo.Direction = ParameterDirection.Input
			paramTo.Size = 500
			arrayParams.Add( paramTo )

			Dim paramCC as new SqlParameter( "@CC", CC)
			paramCC.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramCC.Direction = ParameterDirection.Input
			paramCC.Size = 500
			arrayParams.Add( paramCC )

			Dim paramHTML as new SqlParameter( "@HTML", HTML)
			paramHTML.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "ntext", true)
			paramHTML.Direction = ParameterDirection.Input
			paramHTML.Size = 16
			arrayParams.Add( paramHTML )

			Dim paramprofile as new SqlParameter( "@profile", profile)
			paramprofile.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramprofile.Direction = ParameterDirection.Input
			paramprofile.Size = 20
			arrayParams.Add( paramprofile )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_SendHtmMail", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsGenralReportDepot(   Line as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Depot as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "datetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 8
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "datetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 8
			arrayParams.Add( paramdTo )

			Dim paramDepot as new SqlParameter( "@Depot", Depot)
			paramDepot.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramDepot.Direction = ParameterDirection.Input
			paramDepot.Size = 1000
			arrayParams.Add( paramDepot )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsGenralReportDepot", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_SeqGenerateNew(   SeqType as System.String, _
   Office as System.String, _
   Line as System.String, _
  ByRef  Seq as System.Int64 ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramSeqType as new SqlParameter( "@SeqType", SeqType)
			paramSeqType.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramSeqType.Direction = ParameterDirection.Input
			paramSeqType.Size = 10
			arrayParams.Add( paramSeqType )

			Dim paramOffice as new SqlParameter( "@Office", Office)
			paramOffice.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramOffice.Direction = ParameterDirection.Input
			paramOffice.Size = 10
			arrayParams.Add( paramOffice )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramSeq as new SqlParameter( "@Seq", Seq)
			paramSeq.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "bigint", true)
			paramSeq.Direction = ParameterDirection.Output
			paramSeq.Size = 8
			arrayParams.Add( paramSeq )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_SeqGenerateNew", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			Seq = CType( paramSeq.Value, System.Int64)

			return ds
		End Function


		Public Shared Function SP_EcsGenralReportStatus(   Line as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Status as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "datetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 8
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "datetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 8
			arrayParams.Add( paramdTo )

			Dim paramStatus as new SqlParameter( "@Status", Status)
			paramStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramStatus.Direction = ParameterDirection.Input
			paramStatus.Size = 1000
			arrayParams.Add( paramStatus )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsGenralReportStatus", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_TDR(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_TDR", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsGenralReportStatusDepot(   Line as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Status as System.String, _
   Depot as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "datetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 8
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "datetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 8
			arrayParams.Add( paramdTo )

			Dim paramStatus as new SqlParameter( "@Status", Status)
			paramStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramStatus.Direction = ParameterDirection.Input
			paramStatus.Size = 1000
			arrayParams.Add( paramStatus )

			Dim paramDepot as new SqlParameter( "@Depot", Depot)
			paramDepot.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramDepot.Direction = ParameterDirection.Input
			paramDepot.Size = 1000
			arrayParams.Add( paramDepot )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsGenralReportStatusDepot", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_TEMPXXXXXXXXXXX(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_TEMPXXXXXXXXXXX", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsImportDataGetList(   line as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramline as new SqlParameter( "@line", line)
			paramline.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramline.Direction = ParameterDirection.Input
			paramline.Size = 10
			arrayParams.Add( paramline )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsImportDataGetList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_TopClientByLineDate(   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 20
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_TopClientByLineDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsInventory(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsInventory", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_TotalDetentionDepositBYClientID(   Clnt as System.String, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramClnt as new SqlParameter( "@Clnt", Clnt)
			paramClnt.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramClnt.Direction = ParameterDirection.Input
			paramClnt.Size = 36
			arrayParams.Add( paramClnt )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_TotalDetentionDepositBYClientID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsInverntoryALL(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsInverntoryALL", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_UserAccessAllByAccount(   UserAccount as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramUserAccount as new SqlParameter( "@UserAccount", UserAccount)
			paramUserAccount.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramUserAccount.Direction = ParameterDirection.Input
			paramUserAccount.Size = 10
			arrayParams.Add( paramUserAccount )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_UserAccessAllByAccount", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsMovementList(   Line as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsMovementList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_VoyageDisbursement(   VoyageID as System.String, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_VoyageDisbursement", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_EcsUpdateReportedToWHL(   ID as System.Guid ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "uniqueidentifier", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 16
			arrayParams.Add( paramID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_EcsUpdateReportedToWHL", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_VoyageListByDate(   DFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDFrom as new SqlParameter( "@DFrom", DFrom)
			paramDFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDFrom.Direction = ParameterDirection.Input
			paramDFrom.Size = 4
			arrayParams.Add( paramDFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_VoyageListByDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ExpInvoiceByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ExpInvoiceByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_WHLEQCReportList(   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   IsReported as System.Boolean, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramIsReported as new SqlParameter( "@IsReported", IsReported)
			paramIsReported.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "bit", true)
			paramIsReported.Direction = ParameterDirection.Input
			paramIsReported.Size = 1
			arrayParams.Add( paramIsReported )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_WHLEQCReportList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ExpLoadList(   LINE as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLINE as new SqlParameter( "@LINE", LINE)
			paramLINE.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLINE.Direction = ParameterDirection.Input
			paramLINE.Size = 10
			arrayParams.Add( paramLINE )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ExpLoadList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_WHLOverDue(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_WHLOverDue", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ExpPermitManifest(   LINE as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLINE as new SqlParameter( "@LINE", LINE)
			paramLINE.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLINE.Direction = ParameterDirection.Input
			paramLINE.Size = 10
			arrayParams.Add( paramLINE )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ExpPermitManifest", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ZZBookingEDI(   BookingNoFrom as System.String, _
   BookingNoTo as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBookingNoFrom as new SqlParameter( "@BookingNoFrom", BookingNoFrom)
			paramBookingNoFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBookingNoFrom.Direction = ParameterDirection.Input
			paramBookingNoFrom.Size = 10
			arrayParams.Add( paramBookingNoFrom )

			Dim paramBookingNoTo as new SqlParameter( "@BookingNoTo", BookingNoTo)
			paramBookingNoTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBookingNoTo.Direction = ParameterDirection.Input
			paramBookingNoTo.Size = 10
			arrayParams.Add( paramBookingNoTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ZZBookingEDI", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ExtractDataFromNosa(   VoyageId as System.String, _
   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageId as new SqlParameter( "@VoyageId", VoyageId)
			paramVoyageId.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageId.Direction = ParameterDirection.Input
			paramVoyageId.Size = 36
			arrayParams.Add( paramVoyageId )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ExtractDataFromNosa", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function sp_upgraddiagrams(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("sp_upgraddiagrams", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_FindTableLastUpdate(   Database as System.String, _
   TBName as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDatabase as new SqlParameter( "@Database", Database)
			paramDatabase.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramDatabase.Direction = ParameterDirection.Input
			paramDatabase.Size = 50
			arrayParams.Add( paramDatabase )

			Dim paramTBName as new SqlParameter( "@TBName", TBName)
			paramTBName.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramTBName.Direction = ParameterDirection.Input
			paramTBName.Size = 50
			arrayParams.Add( paramTBName )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_FindTableLastUpdate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_FUMAAnnoual(   Year as System.Int32, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramYear as new SqlParameter( "@Year", Year)
			paramYear.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramYear.Direction = ParameterDirection.Input
			paramYear.Size = 4
			arrayParams.Add( paramYear )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_FUMAAnnoual", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GeneralQuery(   SQL as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramSQL as new SqlParameter( "@SQL", SQL)
			paramSQL.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramSQL.Direction = ParameterDirection.Input
			paramSQL.Size = 3000
			arrayParams.Add( paramSQL )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GeneralQuery", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GenerateNewSeq(   SeqType as System.String, _
   Office as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramSeqType as new SqlParameter( "@SeqType", SeqType)
			paramSeqType.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramSeqType.Direction = ParameterDirection.Input
			paramSeqType.Size = 10
			arrayParams.Add( paramSeqType )

			Dim paramOffice as new SqlParameter( "@Office", Office)
			paramOffice.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramOffice.Direction = ParameterDirection.Input
			paramOffice.Size = 10
			arrayParams.Add( paramOffice )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GenerateNewSeq", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GenerateVochere(   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GenerateVochere", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GenerateWHLBLNO(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_GenerateWHLBLNO", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function sp_helpdiagrams(   diagramname as System.String, _
   owner_id as System.Int32 ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdiagramname as new SqlParameter( "@diagramname", diagramname)
			paramdiagramname.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramdiagramname.Direction = ParameterDirection.Input
			paramdiagramname.Size = 256
			arrayParams.Add( paramdiagramname )

			Dim paramowner_id as new SqlParameter( "@owner_id", owner_id)
			paramowner_id.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramowner_id.Direction = ParameterDirection.Input
			paramowner_id.Size = 4
			arrayParams.Add( paramowner_id )


			Dim ds as DataSet = dm.ExecuteProcedure("sp_helpdiagrams", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetBookingDetailViewByBookingID(   BookingID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBookingID as new SqlParameter( "@BookingID", BookingID)
			paramBookingID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBookingID.Direction = ParameterDirection.Input
			paramBookingID.Size = 36
			arrayParams.Add( paramBookingID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetBookingDetailViewByBookingID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function sp_helpdiagramdefinition(   diagramname as System.String, _
   owner_id as System.Int32 ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdiagramname as new SqlParameter( "@diagramname", diagramname)
			paramdiagramname.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramdiagramname.Direction = ParameterDirection.Input
			paramdiagramname.Size = 256
			arrayParams.Add( paramdiagramname )

			Dim paramowner_id as new SqlParameter( "@owner_id", owner_id)
			paramowner_id.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramowner_id.Direction = ParameterDirection.Input
			paramowner_id.Size = 4
			arrayParams.Add( paramowner_id )


			Dim ds as DataSet = dm.ExecuteProcedure("sp_helpdiagramdefinition", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetBookingFreight(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetBookingFreight", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function sp_creatediagram(   diagramname as System.String, _
   owner_id as System.Int32, _
   version as System.Int32, _
   definition as System.Byte() ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdiagramname as new SqlParameter( "@diagramname", diagramname)
			paramdiagramname.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramdiagramname.Direction = ParameterDirection.Input
			paramdiagramname.Size = 256
			arrayParams.Add( paramdiagramname )

			Dim paramowner_id as new SqlParameter( "@owner_id", owner_id)
			paramowner_id.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramowner_id.Direction = ParameterDirection.Input
			paramowner_id.Size = 4
			arrayParams.Add( paramowner_id )

			Dim paramversion as new SqlParameter( "@version", version)
			paramversion.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramversion.Direction = ParameterDirection.Input
			paramversion.Size = 4
			arrayParams.Add( paramversion )

			Dim paramdefinition as new SqlParameter( "@definition", definition)
			paramdefinition.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varbinary", true)
			paramdefinition.Direction = ParameterDirection.Input
			paramdefinition.Size = -1
			arrayParams.Add( paramdefinition )


			Dim ds as DataSet = dm.ExecuteProcedure("sp_creatediagram", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetBookingList(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetBookingList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function sp_renamediagram(   diagramname as System.String, _
   owner_id as System.Int32, _
   new_diagramname as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdiagramname as new SqlParameter( "@diagramname", diagramname)
			paramdiagramname.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramdiagramname.Direction = ParameterDirection.Input
			paramdiagramname.Size = 256
			arrayParams.Add( paramdiagramname )

			Dim paramowner_id as new SqlParameter( "@owner_id", owner_id)
			paramowner_id.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramowner_id.Direction = ParameterDirection.Input
			paramowner_id.Size = 4
			arrayParams.Add( paramowner_id )

			Dim paramnew_diagramname as new SqlParameter( "@new_diagramname", new_diagramname)
			paramnew_diagramname.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramnew_diagramname.Direction = ParameterDirection.Input
			paramnew_diagramname.Size = 256
			arrayParams.Add( paramnew_diagramname )


			Dim ds as DataSet = dm.ExecuteProcedure("sp_renamediagram", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetBookingViewByID(   BookingID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBookingID as new SqlParameter( "@BookingID", BookingID)
			paramBookingID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBookingID.Direction = ParameterDirection.Input
			paramBookingID.Size = 36
			arrayParams.Add( paramBookingID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetBookingViewByID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function sp_alterdiagram(   diagramname as System.String, _
   owner_id as System.Int32, _
   version as System.Int32, _
   definition as System.Byte() ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdiagramname as new SqlParameter( "@diagramname", diagramname)
			paramdiagramname.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramdiagramname.Direction = ParameterDirection.Input
			paramdiagramname.Size = 256
			arrayParams.Add( paramdiagramname )

			Dim paramowner_id as new SqlParameter( "@owner_id", owner_id)
			paramowner_id.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramowner_id.Direction = ParameterDirection.Input
			paramowner_id.Size = 4
			arrayParams.Add( paramowner_id )

			Dim paramversion as new SqlParameter( "@version", version)
			paramversion.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramversion.Direction = ParameterDirection.Input
			paramversion.Size = 4
			arrayParams.Add( paramversion )

			Dim paramdefinition as new SqlParameter( "@definition", definition)
			paramdefinition.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varbinary", true)
			paramdefinition.Direction = ParameterDirection.Input
			paramdefinition.Size = -1
			arrayParams.Add( paramdefinition )


			Dim ds as DataSet = dm.ExecuteProcedure("sp_alterdiagram", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetInwardCntrsListForPrintBL(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetInwardCntrsListForPrintBL", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function sp_dropdiagram(   diagramname as System.String, _
   owner_id as System.Int32 ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdiagramname as new SqlParameter( "@diagramname", diagramname)
			paramdiagramname.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramdiagramname.Direction = ParameterDirection.Input
			paramdiagramname.Size = 256
			arrayParams.Add( paramdiagramname )

			Dim paramowner_id as new SqlParameter( "@owner_id", owner_id)
			paramowner_id.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramowner_id.Direction = ParameterDirection.Input
			paramowner_id.Size = 4
			arrayParams.Add( paramowner_id )


			Dim ds as DataSet = dm.ExecuteProcedure("sp_dropdiagram", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetInwardCntrsListForPrintBLTran(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetInwardCntrsListForPrintBLTran", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetInwardCntrsPkgsByID(   CntrID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramCntrID as new SqlParameter( "@CntrID", CntrID)
			paramCntrID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramCntrID.Direction = ParameterDirection.Input
			paramCntrID.Size = 36
			arrayParams.Add( paramCntrID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetInwardCntrsPkgsByID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetInwardImcoByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetInwardImcoByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetLastBarCode(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetLastBarCode", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetLastInwardInvoiceNo(   OfficeCode as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramOfficeCode as new SqlParameter( "@OfficeCode", OfficeCode)
			paramOfficeCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramOfficeCode.Direction = ParameterDirection.Input
			paramOfficeCode.Size = 3
			arrayParams.Add( paramOfficeCode )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetLastInwardInvoiceNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetLastInwardReference(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetLastInwardReference", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetLastOutwardInvoiceNo(   OfficeCode as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramOfficeCode as new SqlParameter( "@OfficeCode", OfficeCode)
			paramOfficeCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramOfficeCode.Direction = ParameterDirection.Input
			paramOfficeCode.Size = 10
			arrayParams.Add( paramOfficeCode )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetLastOutwardInvoiceNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetLastOutwardReference(   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetLastOutwardReference", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GETNewBookingNo(   UserCode as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramUserCode as new SqlParameter( "@UserCode", UserCode)
			paramUserCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramUserCode.Direction = ParameterDirection.Input
			paramUserCode.Size = 2
			arrayParams.Add( paramUserCode )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GETNewBookingNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GETNewBookingNoPSH(   UerCode as System.String, _
   Line as System.String, _
   POL as System.String, _
   POD as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramUerCode as new SqlParameter( "@UerCode", UerCode)
			paramUerCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramUerCode.Direction = ParameterDirection.Input
			paramUerCode.Size = 2
			arrayParams.Add( paramUerCode )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramPOL as new SqlParameter( "@POL", POL)
			paramPOL.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPOL.Direction = ParameterDirection.Input
			paramPOL.Size = 10
			arrayParams.Add( paramPOL )

			Dim paramPOD as new SqlParameter( "@POD", POD)
			paramPOD.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPOD.Direction = ParameterDirection.Input
			paramPOD.Size = 10
			arrayParams.Add( paramPOD )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GETNewBookingNoPSH", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetObject(   ObjectName as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramObjectName as new SqlParameter( "@ObjectName", ObjectName)
			paramObjectName.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramObjectName.Direction = ParameterDirection.Input
			paramObjectName.Size = 100
			arrayParams.Add( paramObjectName )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetObject", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetOutwardCntrsListForPrintBL(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetOutwardCntrsListForPrintBL", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetTaxDutyByChargeCode(   ChargesCode as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramChargesCode as new SqlParameter( "@ChargesCode", ChargesCode)
			paramChargesCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramChargesCode.Direction = ParameterDirection.Input
			paramChargesCode.Size = 10
			arrayParams.Add( paramChargesCode )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetTaxDutyByChargeCode", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetTaxTollPercent(   BaseDate as System.DateTime, _
   ImportExport as System.String, _
   ChargesCode as System.String, _
   Port as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBaseDate as new SqlParameter( "@BaseDate", BaseDate)
			paramBaseDate.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramBaseDate.Direction = ParameterDirection.Input
			paramBaseDate.Size = 4
			arrayParams.Add( paramBaseDate )

			Dim paramImportExport as new SqlParameter( "@ImportExport", ImportExport)
			paramImportExport.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramImportExport.Direction = ParameterDirection.Input
			paramImportExport.Size = 10
			arrayParams.Add( paramImportExport )

			Dim paramChargesCode as new SqlParameter( "@ChargesCode", ChargesCode)
			paramChargesCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramChargesCode.Direction = ParameterDirection.Input
			paramChargesCode.Size = 10
			arrayParams.Add( paramChargesCode )

			Dim paramPort as new SqlParameter( "@Port", Port)
			paramPort.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPort.Direction = ParameterDirection.Input
			paramPort.Size = 5
			arrayParams.Add( paramPort )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetTaxTollPercent", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetTotalInwardCntrsByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetTotalInwardCntrsByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_GetTotalOutwardCntrsByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_GetTotalOutwardCntrsByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InqueryAmountByBLIDInqueryID(   BLID as System.String, _
   InqueryID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )

			Dim paramInqueryID as new SqlParameter( "@InqueryID", InqueryID)
			paramInqueryID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramInqueryID.Direction = ParameterDirection.Input
			paramInqueryID.Size = 36
			arrayParams.Add( paramInqueryID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InqueryAmountByBLIDInqueryID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InqueryCheckListByVoyageID(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InqueryCheckListByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InvoiceByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InvoiceByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InvoiceList(   DFrom as System.DateTime, _
   DTo as System.DateTime, _
   Status as System.String, _
   IsByIssueTime as System.String, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDFrom as new SqlParameter( "@DFrom", DFrom)
			paramDFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDFrom.Direction = ParameterDirection.Input
			paramDFrom.Size = 4
			arrayParams.Add( paramDFrom )

			Dim paramDTo as new SqlParameter( "@DTo", DTo)
			paramDTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDTo.Direction = ParameterDirection.Input
			paramDTo.Size = 4
			arrayParams.Add( paramDTo )

			Dim paramStatus as new SqlParameter( "@Status", Status)
			paramStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramStatus.Direction = ParameterDirection.Input
			paramStatus.Size = 1
			arrayParams.Add( paramStatus )

			Dim paramIsByIssueTime as new SqlParameter( "@IsByIssueTime", IsByIssueTime)
			paramIsByIssueTime.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramIsByIssueTime.Direction = ParameterDirection.Input
			paramIsByIssueTime.Size = 1
			arrayParams.Add( paramIsByIssueTime )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InvoiceList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardActivityReport(   DFrom as System.DateTime, _
   DTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDFrom as new SqlParameter( "@DFrom", DFrom)
			paramDFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDFrom.Direction = ParameterDirection.Input
			paramDFrom.Size = 4
			arrayParams.Add( paramDFrom )

			Dim paramDTo as new SqlParameter( "@DTo", DTo)
			paramDTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDTo.Direction = ParameterDirection.Input
			paramDTo.Size = 4
			arrayParams.Add( paramDTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardActivityReport", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardAllDataByLineBlNo(   LINE as System.String, _
   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLINE as new SqlParameter( "@LINE", LINE)
			paramLINE.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLINE.Direction = ParameterDirection.Input
			paramLINE.Size = 10
			arrayParams.Add( paramLINE )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardAllDataByLineBlNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardBlsByLineBlNo(   LINE as System.String, _
   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLINE as new SqlParameter( "@LINE", LINE)
			paramLINE.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLINE.Direction = ParameterDirection.Input
			paramLINE.Size = 10
			arrayParams.Add( paramLINE )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardBlsByLineBlNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardBlsGenralListByVoyageID(   Line as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardBlsGenralListByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardBlsNavigate(   Line as System.String, _
   BLNO as System.String, _
   Direction as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )

			Dim paramDirection as new SqlParameter( "@Direction", Direction)
			paramDirection.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramDirection.Direction = ParameterDirection.Input
			paramDirection.Size = 1
			arrayParams.Add( paramDirection )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardBlsNavigate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardBlsShortData(   Voyage as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyage as new SqlParameter( "@Voyage", Voyage)
			paramVoyage.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyage.Direction = ParameterDirection.Input
			paramVoyage.Size = 36
			arrayParams.Add( paramVoyage )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardBlsShortData", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardBlsSummary(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardBlsSummary", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCleintStatus(   ClientID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramClientID as new SqlParameter( "@ClientID", ClientID)
			paramClientID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramClientID.Direction = ParameterDirection.Input
			paramClientID.Size = 36
			arrayParams.Add( paramClientID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCleintStatus", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function Dummy(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("Dummy", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardClintsListByVoyageID(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardClintsListByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function InvoiceRecivedListByDateCharge(   DFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDFrom as new SqlParameter( "@DFrom", DFrom)
			paramDFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDFrom.Direction = ParameterDirection.Input
			paramDFrom.Size = 4
			arrayParams.Add( paramDFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("InvoiceRecivedListByDateCharge", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCnsChargesByAll(   BLID as System.Guid, _
   UNNO as System.String, _
   IMDGCode as System.String, _
   UnitRate as System.Decimal, _
   RealAmount as System.Decimal, _
   CnSize as System.String, _
   CnType as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "uniqueidentifier", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 16
			arrayParams.Add( paramBLID )

			Dim paramUNNO as new SqlParameter( "@UNNO", UNNO)
			paramUNNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramUNNO.Direction = ParameterDirection.Input
			paramUNNO.Size = 10
			arrayParams.Add( paramUNNO )

			Dim paramIMDGCode as new SqlParameter( "@IMDGCode", IMDGCode)
			paramIMDGCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramIMDGCode.Direction = ParameterDirection.Input
			paramIMDGCode.Size = 10
			arrayParams.Add( paramIMDGCode )

			Dim paramUnitRate as new SqlParameter( "@UnitRate", UnitRate)
			paramUnitRate.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "decimal", true)
			paramUnitRate.Direction = ParameterDirection.Input
			paramUnitRate.Size = 9
			arrayParams.Add( paramUnitRate )

			Dim paramRealAmount as new SqlParameter( "@RealAmount", RealAmount)
			paramRealAmount.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "decimal", true)
			paramRealAmount.Direction = ParameterDirection.Input
			paramRealAmount.Size = 9
			arrayParams.Add( paramRealAmount )

			Dim paramCnSize as new SqlParameter( "@CnSize", CnSize)
			paramCnSize.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCnSize.Direction = ParameterDirection.Input
			paramCnSize.Size = 10
			arrayParams.Add( paramCnSize )

			Dim paramCnType as new SqlParameter( "@CnType", CnType)
			paramCnType.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCnType.Direction = ParameterDirection.Input
			paramCnType.Size = 10
			arrayParams.Add( paramCnType )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCnsChargesByAll", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function MigrateBooking(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("MigrateBooking", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCnsChargesByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCnsChargesByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function MigrateECS(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("MigrateECS", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCntrsByVoyage(   FdrVsl as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramFdrVsl as new SqlParameter( "@FdrVsl", FdrVsl)
			paramFdrVsl.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramFdrVsl.Direction = ParameterDirection.Input
			paramFdrVsl.Size = 36
			arrayParams.Add( paramFdrVsl )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCntrsByVoyage", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function MigrateInvoice(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("MigrateInvoice", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCntrsChargesTotal(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCntrsChargesTotal", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function MigrateInvoiceMissingItems(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("MigrateInvoiceMissingItems", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCntrsCount(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCntrsCount", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function MigrateInward(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("MigrateInward", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCntrsForArr(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCntrsForArr", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function MigrateOutWard(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("MigrateOutWard", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCntrsListByVoyageID(   Line as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCntrsListByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ActivityReport(   ddFrom as System.DateTime, _
   ddTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramddFrom as new SqlParameter( "@ddFrom", ddFrom)
			paramddFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramddFrom.Direction = ParameterDirection.Input
			paramddFrom.Size = 4
			arrayParams.Add( paramddFrom )

			Dim paramddTo as new SqlParameter( "@ddTo", ddTo)
			paramddTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramddTo.Direction = ParameterDirection.Input
			paramddTo.Size = 4
			arrayParams.Add( paramddTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ActivityReport", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCntrsPkgsTotal(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCntrsPkgsTotal", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ArrivalNoticeDetail(   Line as System.String, _
   BlNo as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBlNo as new SqlParameter( "@BlNo", BlNo)
			paramBlNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBlNo.Direction = ParameterDirection.Input
            paramBlNo.Size = 100
			arrayParams.Add( paramBlNo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ArrivalNoticeDetail", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCollectList(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCollectList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AssignedBookingCntrs(   BookingID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBookingID as new SqlParameter( "@BookingID", BookingID)
			paramBookingID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBookingID.Direction = ParameterDirection.Input
			paramBookingID.Size = 36
			arrayParams.Add( paramBookingID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AssignedBookingCntrs", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardCnsList(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardCnsList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardDGListByVoyageID(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardDGListByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AssignNewReleaseSeq(   ReleaseID as System.String, _
   Office as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramReleaseID as new SqlParameter( "@ReleaseID", ReleaseID)
			paramReleaseID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramReleaseID.Direction = ParameterDirection.Input
			paramReleaseID.Size = 36
			arrayParams.Add( paramReleaseID )

			Dim paramOffice as new SqlParameter( "@Office", Office)
			paramOffice.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramOffice.Direction = ParameterDirection.Input
			paramOffice.Size = 10
			arrayParams.Add( paramOffice )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AssignNewReleaseSeq", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_RptCDR(   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_RptCDR", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardGeneralListByDschCmpl(   DFrom as System.DateTime, _
   DTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDFrom as new SqlParameter( "@DFrom", DFrom)
			paramDFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDFrom.Direction = ParameterDirection.Input
			paramDFrom.Size = 4
			arrayParams.Add( paramDFrom )

			Dim paramDTo as new SqlParameter( "@DTo", DTo)
			paramDTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDTo.Direction = ParameterDirection.Input
			paramDTo.Size = 4
			arrayParams.Add( paramDTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardGeneralListByDschCmpl", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_ArrivalCheckList(   VoyageID as System.String, _
   Port as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )

			Dim paramPort as new SqlParameter( "@Port", Port)
			paramPort.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramPort.Direction = ParameterDirection.Input
			paramPort.Size = 5
			arrayParams.Add( paramPort )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_ArrivalCheckList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardListOfChargesByDate(   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardListOfChargesByDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_ArrivalNotice(   VoyageID as System.String, _
   Port as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )

			Dim paramPort as new SqlParameter( "@Port", Port)
			paramPort.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPort.Direction = ParameterDirection.Input
			paramPort.Size = 5
			arrayParams.Add( paramPort )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_ArrivalNotice", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardOfficialInv(   InvID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramInvID as new SqlParameter( "@InvID", InvID)
			paramInvID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramInvID.Direction = ParameterDirection.Input
			paramInvID.Size = 36
			arrayParams.Add( paramInvID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardOfficialInv", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_ArrivalNoticeByBLID(   VoyageID as System.String, _
   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )

			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_ArrivalNoticeByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardRateChecking(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardRateChecking", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_ArrivalResendFailWarning(   JobID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramJobID as new SqlParameter( "@JobID", JobID)
			paramJobID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramJobID.Direction = ParameterDirection.Input
			paramJobID.Size = 36
			arrayParams.Add( paramJobID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_ArrivalResendFailWarning", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardSearch(   BLNo as System.String, _
   CntrNo as System.String, _
   POL as System.String, _
   POD as System.String, _
   FPOD as System.String, _
   Shipper as System.String, _
   Cnee as System.String, _
   Notify as System.String, _
   Client as System.String, _
   Goods as System.String, _
   Reference as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLNo as new SqlParameter( "@BLNo", BLNo)
			paramBLNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNo.Direction = ParameterDirection.Input
            paramBLNo.Size = 100
			arrayParams.Add( paramBLNo )

			Dim paramCntrNo as new SqlParameter( "@CntrNo", CntrNo)
			paramCntrNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCntrNo.Direction = ParameterDirection.Input
			paramCntrNo.Size = 11
			arrayParams.Add( paramCntrNo )

			Dim paramPOL as new SqlParameter( "@POL", POL)
			paramPOL.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPOL.Direction = ParameterDirection.Input
			paramPOL.Size = 5
			arrayParams.Add( paramPOL )

			Dim paramPOD as new SqlParameter( "@POD", POD)
			paramPOD.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPOD.Direction = ParameterDirection.Input
			paramPOD.Size = 5
			arrayParams.Add( paramPOD )

			Dim paramFPOD as new SqlParameter( "@FPOD", FPOD)
			paramFPOD.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramFPOD.Direction = ParameterDirection.Input
			paramFPOD.Size = 5
			arrayParams.Add( paramFPOD )

			Dim paramShipper as new SqlParameter( "@Shipper", Shipper)
			paramShipper.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramShipper.Direction = ParameterDirection.Input
			paramShipper.Size = 30
			arrayParams.Add( paramShipper )

			Dim paramCnee as new SqlParameter( "@Cnee", Cnee)
			paramCnee.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCnee.Direction = ParameterDirection.Input
			paramCnee.Size = 30
			arrayParams.Add( paramCnee )

			Dim paramNotify as new SqlParameter( "@Notify", Notify)
			paramNotify.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramNotify.Direction = ParameterDirection.Input
			paramNotify.Size = 30
			arrayParams.Add( paramNotify )

			Dim paramClient as new SqlParameter( "@Client", Client)
			paramClient.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramClient.Direction = ParameterDirection.Input
			paramClient.Size = 36
			arrayParams.Add( paramClient )

			Dim paramGoods as new SqlParameter( "@Goods", Goods)
			paramGoods.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramGoods.Direction = ParameterDirection.Input
			paramGoods.Size = 30
			arrayParams.Add( paramGoods )

			Dim paramReference as new SqlParameter( "@Reference", Reference)
			paramReference.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramReference.Direction = ParameterDirection.Input
			paramReference.Size = 10
			arrayParams.Add( paramReference )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardSearch", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_CheckLog(   LogID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLogID as new SqlParameter( "@LogID", LogID)
			paramLogID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLogID.Direction = ParameterDirection.Input
			paramLogID.Size = 36
			arrayParams.Add( paramLogID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_CheckLog", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardStatestical(   ddFrom as System.String, _
   ddTo as System.String, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramddFrom as new SqlParameter( "@ddFrom", ddFrom)
			paramddFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramddFrom.Direction = ParameterDirection.Input
			paramddFrom.Size = 8
			arrayParams.Add( paramddFrom )

			Dim paramddTo as new SqlParameter( "@ddTo", ddTo)
			paramddTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramddTo.Direction = ParameterDirection.Input
			paramddTo.Size = 8
			arrayParams.Add( paramddTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardStatestical", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_DummyIns(   ID as System.String, _
   JobCode as System.String, _
   RequestBy as System.String, _
   Remarks as System.String, _
   Result as System.Int32, _
   ErrMsg as System.String, _
   VoyageID as System.Guid, _
   Port as System.String, _
   Priority as System.String, _
   IsResend as System.String, _
   LogID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramJobCode as new SqlParameter( "@JobCode", JobCode)
			paramJobCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramJobCode.Direction = ParameterDirection.Input
			paramJobCode.Size = 2
			arrayParams.Add( paramJobCode )

			Dim paramRequestBy as new SqlParameter( "@RequestBy", RequestBy)
			paramRequestBy.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramRequestBy.Direction = ParameterDirection.Input
			paramRequestBy.Size = 10
			arrayParams.Add( paramRequestBy )

			Dim paramRemarks as new SqlParameter( "@Remarks", Remarks)
			paramRemarks.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramRemarks.Direction = ParameterDirection.Input
			paramRemarks.Size = 1000
			arrayParams.Add( paramRemarks )

			Dim paramResult as new SqlParameter( "@Result", Result)
			paramResult.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramResult.Direction = ParameterDirection.Input
			paramResult.Size = 4
			arrayParams.Add( paramResult )

			Dim paramErrMsg as new SqlParameter( "@ErrMsg", ErrMsg)
			paramErrMsg.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramErrMsg.Direction = ParameterDirection.Input
			paramErrMsg.Size = 1000
			arrayParams.Add( paramErrMsg )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "uniqueidentifier", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 16
			arrayParams.Add( paramVoyageID )

			Dim paramPort as new SqlParameter( "@Port", Port)
			paramPort.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPort.Direction = ParameterDirection.Input
			paramPort.Size = 5
			arrayParams.Add( paramPort )

			Dim paramPriority as new SqlParameter( "@Priority", Priority)
			paramPriority.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPriority.Direction = ParameterDirection.Input
			paramPriority.Size = 2
			arrayParams.Add( paramPriority )

			Dim paramIsResend as new SqlParameter( "@IsResend", IsResend)
			paramIsResend.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramIsResend.Direction = ParameterDirection.Input
			paramIsResend.Size = 1
			arrayParams.Add( paramIsResend )

			Dim paramLogID as new SqlParameter( "@LogID", LogID)
			paramLogID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLogID.Direction = ParameterDirection.Input
			paramLogID.Size = 36
			arrayParams.Add( paramLogID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_DummyIns", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardSummary(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardSummary", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_get_SQL_job_execution_status(   job_name as System.String, _
   select_data as System.Int32, _
  ByRef  execution_status as System.Int32 ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramjob_name as new SqlParameter( "@job_name", job_name)
			paramjob_name.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramjob_name.Direction = ParameterDirection.Input
			paramjob_name.Size = 256
			arrayParams.Add( paramjob_name )

			Dim paramselect_data as new SqlParameter( "@select_data", select_data)
			paramselect_data.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramselect_data.Direction = ParameterDirection.Input
			paramselect_data.Size = 4
			arrayParams.Add( paramselect_data )

			Dim paramexecution_status as new SqlParameter( "@execution_status", execution_status)
			paramexecution_status.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "int", true)
			paramexecution_status.Direction = ParameterDirection.Output
			paramexecution_status.Size = 4
			arrayParams.Add( paramexecution_status )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_get_SQL_job_execution_status", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			execution_status = CType( paramexecution_status.Value, System.Int32)

			return ds
		End Function


		Public Shared Function SP_InwardTHCByVoyageID(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardTHCByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_RunArrivalNotice(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_RunArrivalNotice", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardTotalBlChargesByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardTotalBlChargesByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_RunNoSettel(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_RunNoSettel", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardVoyageAccount(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardVoyageAccount", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_RunOverDue(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_RunOverDue", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_InwardVoyageAccountByArrival(   dFrom as System.DateTime, _
   dTo as System.DateTime, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_InwardVoyageAccountByArrival", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUT_VoyageStatus(   VoyageID as System.String, _
   Port as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )

			Dim paramPort as new SqlParameter( "@Port", Port)
			paramPort.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPort.Direction = ParameterDirection.Input
			paramPort.Size = 5
			arrayParams.Add( paramPort )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUT_VoyageStatus", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ListOfBlsByMasterBL(   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
			paramBLNO.Size = 35
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ListOfBlsByMasterBL", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTDetentionStatus(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTDetentionStatus", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ListOfCntrsDOByDate(   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ListOfCntrsDOByDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTDummyLogIns(   BlNo as System.String, _
   JobCode as System.String, _
   ErrorParam as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBlNo as new SqlParameter( "@BlNo", BlNo)
			paramBlNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBlNo.Direction = ParameterDirection.Input
            paramBlNo.Size = 100
			arrayParams.Add( paramBlNo )

			Dim paramJobCode as new SqlParameter( "@JobCode", JobCode)
			paramJobCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramJobCode.Direction = ParameterDirection.Input
			paramJobCode.Size = 10
			arrayParams.Add( paramJobCode )

			Dim paramError as new SqlParameter( "@Error", ErrorParam)
			paramError.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramError.Direction = ParameterDirection.Input
			paramError.Size = 510
			arrayParams.Add( paramError )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTDummyLogIns", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ListOfExportCntrsBySailingDate(   dFrom as System.DateTime, _
   dTO as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTO as new SqlParameter( "@dTO", dTO)
			paramdTO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTO.Direction = ParameterDirection.Input
			paramdTO.Size = 4
			arrayParams.Add( paramdTO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ListOfExportCntrsBySailingDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTGetRecipiantByDetailID(   ID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTGetRecipiantByDetailID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ListOfImportCntrsByArrivalDate(   dFrom as System.DateTime, _
   dTO as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTO as new SqlParameter( "@dTO", dTO)
			paramdTO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTO.Direction = ParameterDirection.Input
			paramdTO.Size = 4
			arrayParams.Add( paramdTO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ListOfImportCntrsByArrivalDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTInwardDetention(   Line as System.String, _
   BlNo as System.String, _
   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBlNo as new SqlParameter( "@BlNo", BlNo)
			paramBlNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBlNo.Direction = ParameterDirection.Input
            paramBlNo.Size = 100
			arrayParams.Add( paramBlNo )

			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTInwardDetention", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ListOfInvoiceByMasterBL(   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
			paramBLNO.Size = 35
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ListOfInvoiceByMasterBL", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTJOBLogDetailsIns(   ID as System.String, _
   JobID as System.String, _
   DocumentID as System.String, _
   Document as System.String, _
   GenerateTime as System.DateTime, _
   DocumentStatus as System.String, _
   Result as System.String, _
   sKey as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramJobID as new SqlParameter( "@JobID", JobID)
			paramJobID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramJobID.Direction = ParameterDirection.Input
			paramJobID.Size = 36
			arrayParams.Add( paramJobID )

			Dim paramDocumentID as new SqlParameter( "@DocumentID", DocumentID)
			paramDocumentID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramDocumentID.Direction = ParameterDirection.Input
			paramDocumentID.Size = 36
			arrayParams.Add( paramDocumentID )

			Dim paramDocument as new SqlParameter( "@Document", Document)
			paramDocument.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramDocument.Direction = ParameterDirection.Input
			paramDocument.Size = -1
			arrayParams.Add( paramDocument )

			Dim paramGenerateTime as new SqlParameter( "@GenerateTime", GenerateTime)
			paramGenerateTime.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramGenerateTime.Direction = ParameterDirection.Input
			paramGenerateTime.Size = 4
			arrayParams.Add( paramGenerateTime )

			Dim paramDocumentStatus as new SqlParameter( "@DocumentStatus", DocumentStatus)
			paramDocumentStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramDocumentStatus.Direction = ParameterDirection.Input
			paramDocumentStatus.Size = 10
			arrayParams.Add( paramDocumentStatus )

			Dim paramResult as new SqlParameter( "@Result", Result)
			paramResult.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramResult.Direction = ParameterDirection.Input
			paramResult.Size = -1
			arrayParams.Add( paramResult )

			Dim paramsKey as new SqlParameter( "@sKey", sKey)
			paramsKey.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramsKey.Direction = ParameterDirection.Input
			paramsKey.Size = 25
			arrayParams.Add( paramsKey )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTJOBLogDetailsIns", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ListOfPermitsByVoyage(   LINE as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLINE as new SqlParameter( "@LINE", LINE)
			paramLINE.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLINE.Direction = ParameterDirection.Input
			paramLINE.Size = 10
			arrayParams.Add( paramLINE )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ListOfPermitsByVoyage", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTJOBLogDetailsUpd(   ID as System.String, _
   Document as System.String, _
   DocumentStatus as System.String, _
   Result as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramDocument as new SqlParameter( "@Document", Document)
			paramDocument.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramDocument.Direction = ParameterDirection.Input
			paramDocument.Size = -1
			arrayParams.Add( paramDocument )

			Dim paramDocumentStatus as new SqlParameter( "@DocumentStatus", DocumentStatus)
			paramDocumentStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramDocumentStatus.Direction = ParameterDirection.Input
			paramDocumentStatus.Size = 10
			arrayParams.Add( paramDocumentStatus )

			Dim paramResult as new SqlParameter( "@Result", Result)
			paramResult.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramResult.Direction = ParameterDirection.Input
			paramResult.Size = -1
			arrayParams.Add( paramResult )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTJOBLogDetailsUpd", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_LoadedEmptyCntrs(   Line as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_LoadedEmptyCntrs", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTJOBLogDetailsUpdStatus(   ID as System.String, _
   DocumentStatus as System.String, _
   Result as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramDocumentStatus as new SqlParameter( "@DocumentStatus", DocumentStatus)
			paramDocumentStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramDocumentStatus.Direction = ParameterDirection.Input
			paramDocumentStatus.Size = 10
			arrayParams.Add( paramDocumentStatus )

			Dim paramResult as new SqlParameter( "@Result", Result)
			paramResult.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramResult.Direction = ParameterDirection.Input
			paramResult.Size = -1
			arrayParams.Add( paramResult )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTJOBLogDetailsUpdStatus", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_LoadedFullCntrs(   Line as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_LoadedFullCntrs", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTJOBLogIns(   ID as System.String, _
   JobCode as System.String, _
   RequestBy as System.String, _
   CancelJob as System.String, _
   Remarks as System.String, _
   Port as System.String, _
   VoyageID as System.String, _
   Priority as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramJobCode as new SqlParameter( "@JobCode", JobCode)
			paramJobCode.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramJobCode.Direction = ParameterDirection.Input
			paramJobCode.Size = 10
			arrayParams.Add( paramJobCode )

			Dim paramRequestBy as new SqlParameter( "@RequestBy", RequestBy)
			paramRequestBy.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramRequestBy.Direction = ParameterDirection.Input
			paramRequestBy.Size = 10
			arrayParams.Add( paramRequestBy )

			Dim paramCancelJob as new SqlParameter( "@CancelJob", CancelJob)
			paramCancelJob.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramCancelJob.Direction = ParameterDirection.Input
			paramCancelJob.Size = 1
			arrayParams.Add( paramCancelJob )

			Dim paramRemarks as new SqlParameter( "@Remarks", Remarks)
			paramRemarks.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramRemarks.Direction = ParameterDirection.Input
			paramRemarks.Size = 100
			arrayParams.Add( paramRemarks )

			Dim paramPort as new SqlParameter( "@Port", Port)
			paramPort.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPort.Direction = ParameterDirection.Input
			paramPort.Size = 5
			arrayParams.Add( paramPort )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )

			Dim paramPriority as new SqlParameter( "@Priority", Priority)
			paramPriority.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramPriority.Direction = ParameterDirection.Input
			paramPriority.Size = 10
			arrayParams.Add( paramPriority )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTJOBLogIns", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_LoadListFullByVoyageID(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_LoadListFullByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTJobLogsTerminate(   ID as System.String, _
   IsCancel as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramIsCancel as new SqlParameter( "@IsCancel", IsCancel)
			paramIsCancel.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramIsCancel.Direction = ParameterDirection.Input
			paramIsCancel.Size = 1
			arrayParams.Add( paramIsCancel )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTJobLogsTerminate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_LoadListFullMtyByVoyageID(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_LoadListFullMtyByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTJobsQuery(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTJobsQuery", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_LogAll(   User as System.String, _
   dFrom as System.DateTime, _
   dTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramUser as new SqlParameter( "@User", User)
			paramUser.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramUser.Direction = ParameterDirection.Input
			paramUser.Size = 30
			arrayParams.Add( paramUser )

			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 4
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 4
			arrayParams.Add( paramdTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_LogAll", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_AUTLogCancel(   ID as System.String, _
   Remarks as System.String, _
   User as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramRemarks as new SqlParameter( "@Remarks", Remarks)
			paramRemarks.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramRemarks.Direction = ParameterDirection.Input
			paramRemarks.Size = 200
			arrayParams.Add( paramRemarks )

			Dim paramUser as new SqlParameter( "@User", User)
			paramUser.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramUser.Direction = ParameterDirection.Input
			paramUser.Size = 10
			arrayParams.Add( paramUser )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_AUTLogCancel", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_LogDetailsIns(   ID as System.String, _
   LogID as System.String, _
   FieldName as System.String, _
   OldValue as System.String, _
   NewValue as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )

			Dim paramLogID as new SqlParameter( "@LogID", LogID)
			paramLogID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLogID.Direction = ParameterDirection.Input
			paramLogID.Size = 36
			arrayParams.Add( paramLogID )

			Dim paramFieldName as new SqlParameter( "@FieldName", FieldName)
			paramFieldName.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramFieldName.Direction = ParameterDirection.Input
			paramFieldName.Size = 100
			arrayParams.Add( paramFieldName )

			Dim paramOldValue as new SqlParameter( "@OldValue", OldValue)
			paramOldValue.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramOldValue.Direction = ParameterDirection.Input
			paramOldValue.Size = -1
			arrayParams.Add( paramOldValue )

			Dim paramNewValue as new SqlParameter( "@NewValue", NewValue)
			paramNewValue.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramNewValue.Direction = ParameterDirection.Input
			paramNewValue.Size = -1
			arrayParams.Add( paramNewValue )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_LogDetailsIns", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_autoLogByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_autoLogByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_LogMasterIns(   ID as System.Guid, _
   TBName as System.String, _
   TableKey as System.Guid, _
   ActionUser as System.String, _
   ActionType as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "uniqueidentifier", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 16
			arrayParams.Add( paramID )

			Dim paramTBName as new SqlParameter( "@TBName", TBName)
			paramTBName.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramTBName.Direction = ParameterDirection.Input
			paramTBName.Size = 100
			arrayParams.Add( paramTBName )

			Dim paramTableKey as new SqlParameter( "@TableKey", TableKey)
			paramTableKey.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "uniqueidentifier", true)
			paramTableKey.Direction = ParameterDirection.Input
			paramTableKey.Size = 16
			arrayParams.Add( paramTableKey )

			Dim paramActionUser as new SqlParameter( "@ActionUser", ActionUser)
			paramActionUser.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramActionUser.Direction = ParameterDirection.Input
			paramActionUser.Size = 100
			arrayParams.Add( paramActionUser )

			Dim paramActionType as new SqlParameter( "@ActionType", ActionType)
			paramActionType.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramActionType.Direction = ParameterDirection.Input
			paramActionType.Size = 20
			arrayParams.Add( paramActionType )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_LogMasterIns", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_autoLogByFaxNo(   Faxno as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramFaxno as new SqlParameter( "@Faxno", Faxno)
			paramFaxno.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramFaxno.Direction = ParameterDirection.Input
			paramFaxno.Size = 50
			arrayParams.Add( paramFaxno )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_autoLogByFaxNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_LogSingelByID(   ID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramID as new SqlParameter( "@ID", ID)
			paramID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramID.Direction = ParameterDirection.Input
			paramID.Size = 36
			arrayParams.Add( paramID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_LogSingelByID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BlsByVoyCntr(   VoyageID as System.String, _
   CntrNo as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )

			Dim paramCntrNo as new SqlParameter( "@CntrNo", CntrNo)
			paramCntrNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCntrNo.Direction = ParameterDirection.Input
			paramCntrNo.Size = 11
			arrayParams.Add( paramCntrNo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BlsByVoyCntr", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_MMMMM(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_MMMMM", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BookingAllBookingID(   BookingID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBookingID as new SqlParameter( "@BookingID", BookingID)
			paramBookingID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBookingID.Direction = ParameterDirection.Input
			paramBookingID.Size = 36
			arrayParams.Add( paramBookingID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BookingAllBookingID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_MtyCntrsSearch(   CntrNo as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramCntrNo as new SqlParameter( "@CntrNo", CntrNo)
			paramCntrNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramCntrNo.Direction = ParameterDirection.Input
			paramCntrNo.Size = 11
			arrayParams.Add( paramCntrNo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_MtyCntrsSearch", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BookingAllByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BookingAllByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_NOSAFinalVchr(  ) as DataSet
			Dim arrayParams as new ArrayList()
	

			Dim ds as DataSet = dm.ExecuteProcedure("SP_NOSAFinalVchr", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BookingAllByLineBLNo(   Line as System.String, _
   BlNo as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBlNo as new SqlParameter( "@BlNo", BlNo)
			paramBlNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBlNo.Direction = ParameterDirection.Input
            paramBlNo.Size = 100
			arrayParams.Add( paramBlNo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BookingAllByLineBLNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ObjectsIns(   ObjectName as System.String, _
   ObjectContent as System.Byte(), _
   Remarks as System.String, _
   CreateDate as System.DateTime, _
   ModifyDate as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramObjectName as new SqlParameter( "@ObjectName", ObjectName)
			paramObjectName.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramObjectName.Direction = ParameterDirection.Input
			paramObjectName.Size = 100
			arrayParams.Add( paramObjectName )

			Dim paramObjectContent as new SqlParameter( "@ObjectContent", ObjectContent)
			paramObjectContent.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "image", true)
			paramObjectContent.Direction = ParameterDirection.Input
			paramObjectContent.Size = 16
			arrayParams.Add( paramObjectContent )

			Dim paramRemarks as new SqlParameter( "@Remarks", Remarks)
			paramRemarks.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "nvarchar", true)
			paramRemarks.Direction = ParameterDirection.Input
			paramRemarks.Size = 200
			arrayParams.Add( paramRemarks )

			Dim paramCreateDate as new SqlParameter( "@CreateDate", CreateDate)
			paramCreateDate.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramCreateDate.Direction = ParameterDirection.Input
			paramCreateDate.Size = 4
			arrayParams.Add( paramCreateDate )

			Dim paramModifyDate as new SqlParameter( "@ModifyDate", ModifyDate)
			paramModifyDate.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramModifyDate.Direction = ParameterDirection.Input
			paramModifyDate.Size = 4
			arrayParams.Add( paramModifyDate )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ObjectsIns", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BookingAllByNo(   BookingNo as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBookingNo as new SqlParameter( "@BookingNo", BookingNo)
			paramBookingNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBookingNo.Direction = ParameterDirection.Input
			paramBookingNo.Size = 10
			arrayParams.Add( paramBookingNo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BookingAllByNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OOCLDischargeList(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OOCLDischargeList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BookingFirm(   BookingID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBookingID as new SqlParameter( "@BookingID", BookingID)
			paramBookingID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBookingID.Direction = ParameterDirection.Input
			paramBookingID.Size = 36
			arrayParams.Add( paramBookingID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BookingFirm", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OOCLLoadList(   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OOCLLoadList", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BookingMemo(   BookingID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBookingID as new SqlParameter( "@BookingID", BookingID)
			paramBookingID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBookingID.Direction = ParameterDirection.Input
			paramBookingID.Size = 36
			arrayParams.Add( paramBookingID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BookingMemo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardActivityReport(   DFrom as System.DateTime, _
   DTo as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDFrom as new SqlParameter( "@DFrom", DFrom)
			paramDFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDFrom.Direction = ParameterDirection.Input
			paramDFrom.Size = 4
			arrayParams.Add( paramDFrom )

			Dim paramDTo as new SqlParameter( "@DTo", DTo)
			paramDTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDTo.Direction = ParameterDirection.Input
			paramDTo.Size = 4
			arrayParams.Add( paramDTo )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardActivityReport", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BookingSearch(   dFrom as System.String, _
   dTo as System.String, _
   ClientID as System.String, _
   Status as System.String, _
   SalesMan as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 10
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 10
			arrayParams.Add( paramdTo )

			Dim paramClientID as new SqlParameter( "@ClientID", ClientID)
			paramClientID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramClientID.Direction = ParameterDirection.Input
			paramClientID.Size = 36
			arrayParams.Add( paramClientID )

			Dim paramStatus as new SqlParameter( "@Status", Status)
			paramStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramStatus.Direction = ParameterDirection.Input
			paramStatus.Size = 10
			arrayParams.Add( paramStatus )

			Dim paramSalesMan as new SqlParameter( "@SalesMan", SalesMan)
			paramSalesMan.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramSalesMan.Direction = ParameterDirection.Input
			paramSalesMan.Size = 36
			arrayParams.Add( paramSalesMan )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BookingSearch", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardAllDataByLineBlNo(   LINE as System.String, _
   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLINE as new SqlParameter( "@LINE", LINE)
			paramLINE.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLINE.Direction = ParameterDirection.Input
			paramLINE.Size = 10
			arrayParams.Add( paramLINE )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardAllDataByLineBlNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BookingSrch(   BookingNo as System.String, _
   Status as System.String, _
   ClientID as System.String, _
   SalesMan as System.String, _
   Line as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBookingNo as new SqlParameter( "@BookingNo", BookingNo)
			paramBookingNo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBookingNo.Direction = ParameterDirection.Input
			paramBookingNo.Size = 25
			arrayParams.Add( paramBookingNo )

			Dim paramStatus as new SqlParameter( "@Status", Status)
			paramStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramStatus.Direction = ParameterDirection.Input
			paramStatus.Size = 10
			arrayParams.Add( paramStatus )

			Dim paramClientID as new SqlParameter( "@ClientID", ClientID)
			paramClientID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramClientID.Direction = ParameterDirection.Input
			paramClientID.Size = 36
			arrayParams.Add( paramClientID )

			Dim paramSalesMan as new SqlParameter( "@SalesMan", SalesMan)
			paramSalesMan.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramSalesMan.Direction = ParameterDirection.Input
			paramSalesMan.Size = 36
			arrayParams.Add( paramSalesMan )

			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BookingSrch", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardBlsByLineBlNo(   LINE as System.String, _
   BLNO as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLINE as new SqlParameter( "@LINE", LINE)
			paramLINE.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramLINE.Direction = ParameterDirection.Input
			paramLINE.Size = 10
			arrayParams.Add( paramLINE )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardBlsByLineBlNo", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_BookingTrace(   dFrom as System.String, _
   dTo as System.String, _
   ClientID as System.String, _
   SalesMan as System.String, _
   Status as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramdFrom as new SqlParameter( "@dFrom", dFrom)
			paramdFrom.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramdFrom.Direction = ParameterDirection.Input
			paramdFrom.Size = 10
			arrayParams.Add( paramdFrom )

			Dim paramdTo as new SqlParameter( "@dTo", dTo)
			paramdTo.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramdTo.Direction = ParameterDirection.Input
			paramdTo.Size = 10
			arrayParams.Add( paramdTo )

			Dim paramClientID as new SqlParameter( "@ClientID", ClientID)
			paramClientID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramClientID.Direction = ParameterDirection.Input
			paramClientID.Size = 36
			arrayParams.Add( paramClientID )

			Dim paramSalesMan as new SqlParameter( "@SalesMan", SalesMan)
			paramSalesMan.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramSalesMan.Direction = ParameterDirection.Input
			paramSalesMan.Size = 10
			arrayParams.Add( paramSalesMan )

			Dim paramStatus as new SqlParameter( "@Status", Status)
			paramStatus.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramStatus.Direction = ParameterDirection.Input
			paramStatus.Size = 10
			arrayParams.Add( paramStatus )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_BookingTrace", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_outwardBlsGenralListByVoyageID(   Line as System.String, _
   VoyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramVoyageID as new SqlParameter( "@VoyageID", VoyageID)
			paramVoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramVoyageID.Direction = ParameterDirection.Input
			paramVoyageID.Size = 36
			arrayParams.Add( paramVoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_outwardBlsGenralListByVoyageID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_CheckExitCntrsForPermits(   voyageID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramvoyageID as new SqlParameter( "@voyageID", voyageID)
			paramvoyageID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramvoyageID.Direction = ParameterDirection.Input
			paramvoyageID.Size = 36
			arrayParams.Add( paramvoyageID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_CheckExitCntrsForPermits", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_OutwardBlsNavigate(   Line as System.String, _
   BLNO as System.String, _
   Direction as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramLine as new SqlParameter( "@Line", Line)
			paramLine.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramLine.Direction = ParameterDirection.Input
			paramLine.Size = 10
			arrayParams.Add( paramLine )

			Dim paramBLNO as new SqlParameter( "@BLNO", BLNO)
			paramBLNO.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLNO.Direction = ParameterDirection.Input
            paramBLNO.Size = 100
			arrayParams.Add( paramBLNO )

			Dim paramDirection as new SqlParameter( "@Direction", Direction)
			paramDirection.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramDirection.Direction = ParameterDirection.Input
			paramDirection.Size = 1
			arrayParams.Add( paramDirection )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_OutwardBlsNavigate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ChgLevelAllByDate(   DateParam as System.DateTime ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDate as new SqlParameter( "@Date", DateParam)
			paramDate.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDate.Direction = ParameterDirection.Input
			paramDate.Size = 4
			arrayParams.Add( paramDate )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ChgLevelAllByDate", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_outwardBlsSummary(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_outwardBlsSummary", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ChgLevelAllByDateClientID(   DateParam as System.DateTime, _
   ClientID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramDate as new SqlParameter( "@Date", DateParam)
			paramDate.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "smalldatetime", true)
			paramDate.Direction = ParameterDirection.Input
			paramDate.Size = 4
			arrayParams.Add( paramDate )

			Dim paramClientID as new SqlParameter( "@ClientID", ClientID)
			paramClientID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramClientID.Direction = ParameterDirection.Input
			paramClientID.Size = 36
			arrayParams.Add( paramClientID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ChgLevelAllByDateClientID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_outwardCntrsByVoyage(   FdrVsl as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramFdrVsl as new SqlParameter( "@FdrVsl", FdrVsl)
			paramFdrVsl.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "char", true)
			paramFdrVsl.Direction = ParameterDirection.Input
			paramFdrVsl.Size = 36
			arrayParams.Add( paramFdrVsl )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_outwardCntrsByVoyage", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function


		Public Shared Function SP_ClientsByBLID(   BLID as System.String ) as DataSet
			Dim arrayParams as new ArrayList()
	
			Dim paramBLID as new SqlParameter( "@BLID", BLID)
			paramBLID.SqlDbType = SqlDbType.Parse( GetType(SqlDbType), "varchar", true)
			paramBLID.Direction = ParameterDirection.Input
			paramBLID.Size = 36
			arrayParams.Add( paramBLID )


			Dim ds as DataSet = dm.ExecuteProcedure("SP_ClientsByBLID", CType( arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
			
			return ds
		End Function



	End Class
End NameSpace
