
Imports System
Imports System.Collections
Imports OrmLib

namespace ShippingBiz


	public class FetchPath
	
		private Sub New()
		End Sub
		

		public Shared ReadOnly Property sysdiagrams() as FetchPath.o.sysdiagramsRelation
			get
				return new FetchPath.o.sysdiagramsRelation(new ArrayList(), "sysdiagrams")
			end get
		end property
		public Shared ReadOnly Property TB_AccessLevel() as FetchPath.o.TB_AccessLevelRelation
			get
				return new FetchPath.o.TB_AccessLevelRelation(new ArrayList(), "TB_AccessLevel")
			end get
		end property
		public Shared ReadOnly Property TB_Account() as FetchPath.o.TB_AccountRelation
			get
				return new FetchPath.o.TB_AccountRelation(new ArrayList(), "TB_Account")
			end get
		end property
		public Shared ReadOnly Property TB_Agents() as FetchPath.o.TB_AgentsRelation
			get
				return new FetchPath.o.TB_AgentsRelation(new ArrayList(), "TB_Agents")
			end get
		end property
		public Shared ReadOnly Property TB_AUTAdditionalDocs() as FetchPath.o.TB_AUTAdditionalDocsRelation
			get
				return new FetchPath.o.TB_AUTAdditionalDocsRelation(new ArrayList(), "TB_AUTAdditionalDocs")
			end get
		end property
		public Shared ReadOnly Property TB_AUTDummy() as FetchPath.o.TB_AUTDummyRelation
			get
				return new FetchPath.o.TB_AUTDummyRelation(new ArrayList(), "TB_AUTDummy")
			end get
		end property
		public Shared ReadOnly Property TB_AUTDummyLog() as FetchPath.o.TB_AUTDummyLogRelation
			get
				return new FetchPath.o.TB_AUTDummyLogRelation(new ArrayList(), "TB_AUTDummyLog")
			end get
		end property
		public Shared ReadOnly Property TB_AUTJobLogs() as FetchPath.o.TB_AUTJobLogsRelation
			get
				return new FetchPath.o.TB_AUTJobLogsRelation(new ArrayList(), "TB_AUTJobLogs")
			end get
		end property
		public Shared ReadOnly Property TB_AUTJobLogsDetail() as FetchPath.o.TB_AUTJobLogsDetailRelation
			get
				return new FetchPath.o.TB_AUTJobLogsDetailRelation(new ArrayList(), "TB_AUTJobLogsDetail")
			end get
		end property
		public Shared ReadOnly Property TB_AUTJobs() as FetchPath.o.TB_AUTJobsRelation
			get
				return new FetchPath.o.TB_AUTJobsRelation(new ArrayList(), "TB_AUTJobs")
			end get
		end property
		public Shared ReadOnly Property TB_autoLog() as FetchPath.o.TB_autoLogRelation
			get
				return new FetchPath.o.TB_autoLogRelation(new ArrayList(), "TB_autoLog")
			end get
		end property
		public Shared ReadOnly Property TB_AUTSchedule() as FetchPath.o.TB_AUTScheduleRelation
			get
				return new FetchPath.o.TB_AUTScheduleRelation(new ArrayList(), "TB_AUTSchedule")
			end get
		end property
		public Shared ReadOnly Property TB_AUTSettings() as FetchPath.o.TB_AUTSettingsRelation
			get
				return new FetchPath.o.TB_AUTSettingsRelation(new ArrayList(), "TB_AUTSettings")
			end get
		end property
		public Shared ReadOnly Property TB_Booking() as FetchPath.o.TB_BookingRelation
			get
				return new FetchPath.o.TB_BookingRelation(new ArrayList(), "TB_Booking")
			end get
		end property
		public Shared ReadOnly Property TB_BookingCns() as FetchPath.o.TB_BookingCnsRelation
			get
				return new FetchPath.o.TB_BookingCnsRelation(new ArrayList(), "TB_BookingCns")
			end get
		end property
		public Shared ReadOnly Property TB_BookingDeposits() as FetchPath.o.TB_BookingDepositsRelation
			get
				return new FetchPath.o.TB_BookingDepositsRelation(new ArrayList(), "TB_BookingDeposits")
			end get
		end property
		public Shared ReadOnly Property TB_BookingDetails() as FetchPath.o.TB_BookingDetailsRelation
			get
				return new FetchPath.o.TB_BookingDetailsRelation(new ArrayList(), "TB_BookingDetails")
			end get
		end property
		public Shared ReadOnly Property TB_BookingReleasCntrs() as FetchPath.o.TB_BookingReleasCntrsRelation
			get
				return new FetchPath.o.TB_BookingReleasCntrsRelation(new ArrayList(), "TB_BookingReleasCntrs")
			end get
		end property
		public Shared ReadOnly Property TB_BookingRelease() as FetchPath.o.TB_BookingReleaseRelation
			get
				return new FetchPath.o.TB_BookingReleaseRelation(new ArrayList(), "TB_BookingRelease")
			end get
		end property
		public Shared ReadOnly Property TB_CalculationBase() as FetchPath.o.TB_CalculationBaseRelation
			get
				return new FetchPath.o.TB_CalculationBaseRelation(new ArrayList(), "TB_CalculationBase")
			end get
		end property
		public Shared ReadOnly Property TB_ChgLevelDetails() as FetchPath.o.TB_ChgLevelDetailsRelation
			get
				return new FetchPath.o.TB_ChgLevelDetailsRelation(new ArrayList(), "TB_ChgLevelDetails")
			end get
		end property
		public Shared ReadOnly Property TB_ChgLevelMaster() as FetchPath.o.TB_ChgLevelMasterRelation
			get
				return new FetchPath.o.TB_ChgLevelMasterRelation(new ArrayList(), "TB_ChgLevelMaster")
			end get
		end property
		public Shared ReadOnly Property TB_Clients() as FetchPath.o.TB_ClientsRelation
			get
				return new FetchPath.o.TB_ClientsRelation(new ArrayList(), "TB_Clients")
			end get
		end property
		public Shared ReadOnly Property TB_Cluses() as FetchPath.o.TB_ClusesRelation
			get
				return new FetchPath.o.TB_ClusesRelation(new ArrayList(), "TB_Cluses")
			end get
		end property
		public Shared ReadOnly Property TB_CODE() as FetchPath.o.TB_CODERelation
			get
				return new FetchPath.o.TB_CODERelation(new ArrayList(), "TB_CODE")
			end get
		end property
		public Shared ReadOnly Property TB_CodeMaster() as FetchPath.o.TB_CodeMasterRelation
			get
				return new FetchPath.o.TB_CodeMasterRelation(new ArrayList(), "TB_CodeMaster")
			end get
		end property
		public Shared ReadOnly Property TB_Company() as FetchPath.o.TB_CompanyRelation
			get
				return new FetchPath.o.TB_CompanyRelation(new ArrayList(), "TB_Company")
			end get
		end property
		public Shared ReadOnly Property TB_Country() as FetchPath.o.TB_CountryRelation
			get
				return new FetchPath.o.TB_CountryRelation(new ArrayList(), "TB_Country")
			end get
		end property
		public Shared ReadOnly Property TB_CustomMenu() as FetchPath.o.TB_CustomMenuRelation
			get
				return new FetchPath.o.TB_CustomMenuRelation(new ArrayList(), "TB_CustomMenu")
			end get
		end property
		public Shared ReadOnly Property TB_Damage() as FetchPath.o.TB_DamageRelation
			get
				return new FetchPath.o.TB_DamageRelation(new ArrayList(), "TB_Damage")
			end get
		end property
		public Shared ReadOnly Property TB_Deposits() as FetchPath.o.TB_DepositsRelation
			get
				return new FetchPath.o.TB_DepositsRelation(new ArrayList(), "TB_Deposits")
			end get
		end property
		public Shared ReadOnly Property TB_DetentionBase() as FetchPath.o.TB_DetentionBaseRelation
			get
				return new FetchPath.o.TB_DetentionBaseRelation(new ArrayList(), "TB_DetentionBase")
			end get
		end property
		public Shared ReadOnly Property TB_DetentionBaseDetails() as FetchPath.o.TB_DetentionBaseDetailsRelation
			get
				return new FetchPath.o.TB_DetentionBaseDetailsRelation(new ArrayList(), "TB_DetentionBaseDetails")
			end get
		end property
		public Shared ReadOnly Property TB_Documets() as FetchPath.o.TB_DocumetsRelation
			get
				return new FetchPath.o.TB_DocumetsRelation(new ArrayList(), "TB_Documets")
			end get
		end property
		public Shared ReadOnly Property TB_DocumetsDetail() as FetchPath.o.TB_DocumetsDetailRelation
			get
				return new FetchPath.o.TB_DocumetsDetailRelation(new ArrayList(), "TB_DocumetsDetail")
			end get
		end property
		public Shared ReadOnly Property TB_EcsContainers() as FetchPath.o.TB_EcsContainersRelation
			get
				return new FetchPath.o.TB_EcsContainersRelation(new ArrayList(), "TB_EcsContainers")
			end get
		end property
		public Shared ReadOnly Property TB_EcsMoves() as FetchPath.o.TB_EcsMovesRelation
			get
				return new FetchPath.o.TB_EcsMovesRelation(new ArrayList(), "TB_EcsMoves")
			end get
		end property
		public Shared ReadOnly Property TB_EcsReserveContainers() as FetchPath.o.TB_EcsReserveContainersRelation
			get
				return new FetchPath.o.TB_EcsReserveContainersRelation(new ArrayList(), "TB_EcsReserveContainers")
			end get
		end property
		public Shared ReadOnly Property TB_EventMail() as FetchPath.o.TB_EventMailRelation
			get
				return new FetchPath.o.TB_EventMailRelation(new ArrayList(), "TB_EventMail")
			end get
		end property
		public Shared ReadOnly Property TB_Exchange() as FetchPath.o.TB_ExchangeRelation
			get
				return new FetchPath.o.TB_ExchangeRelation(new ArrayList(), "TB_Exchange")
			end get
		end property
		public Shared ReadOnly Property TB_ExchangeDetails() as FetchPath.o.TB_ExchangeDetailsRelation
			get
				return new FetchPath.o.TB_ExchangeDetailsRelation(new ArrayList(), "TB_ExchangeDetails")
			end get
		end property
		public Shared ReadOnly Property TB_ExpInvoice() as FetchPath.o.TB_ExpInvoiceRelation
			get
				return new FetchPath.o.TB_ExpInvoiceRelation(new ArrayList(), "TB_ExpInvoice")
			end get
		end property
		public Shared ReadOnly Property TB_ExpInvoiceDetails() as FetchPath.o.TB_ExpInvoiceDetailsRelation
			get
				return new FetchPath.o.TB_ExpInvoiceDetailsRelation(new ArrayList(), "TB_ExpInvoiceDetails")
			end get
		end property
		public Shared ReadOnly Property TB_ExpRecivedItems() as FetchPath.o.TB_ExpRecivedItemsRelation
			get
				return new FetchPath.o.TB_ExpRecivedItemsRelation(new ArrayList(), "TB_ExpRecivedItems")
			end get
		end property
		public Shared ReadOnly Property TB_FaxActions() as FetchPath.o.TB_FaxActionsRelation
			get
				return new FetchPath.o.TB_FaxActionsRelation(new ArrayList(), "TB_FaxActions")
			end get
		end property
		public Shared ReadOnly Property TB_FaxStatus() as FetchPath.o.TB_FaxStatusRelation
			get
				return new FetchPath.o.TB_FaxStatusRelation(new ArrayList(), "TB_FaxStatus")
			end get
		end property
		public Shared ReadOnly Property TB_Inquery() as FetchPath.o.TB_InqueryRelation
			get
				return new FetchPath.o.TB_InqueryRelation(new ArrayList(), "TB_Inquery")
			end get
		end property
		public Shared ReadOnly Property TB_InqueryDetails() as FetchPath.o.TB_InqueryDetailsRelation
			get
				return new FetchPath.o.TB_InqueryDetailsRelation(new ArrayList(), "TB_InqueryDetails")
			end get
		end property
		public Shared ReadOnly Property TB_Invoice() as FetchPath.o.TB_InvoiceRelation
			get
				return new FetchPath.o.TB_InvoiceRelation(new ArrayList(), "TB_Invoice")
			end get
		end property
		public Shared ReadOnly Property TB_InvoiceDetails() as FetchPath.o.TB_InvoiceDetailsRelation
			get
				return new FetchPath.o.TB_InvoiceDetailsRelation(new ArrayList(), "TB_InvoiceDetails")
			end get
		end property
		public Shared ReadOnly Property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
			get
				return new FetchPath.o.TB_InwardBLSRelation(new ArrayList(), "TB_InwardBLS")
			end get
		end property
		public Shared ReadOnly Property TB_InwardBlsComments() as FetchPath.o.TB_InwardBlsCommentsRelation
			get
				return new FetchPath.o.TB_InwardBlsCommentsRelation(new ArrayList(), "TB_InwardBlsComments")
			end get
		end property
		public Shared ReadOnly Property Tb_InwardBlsFrs() as FetchPath.o.Tb_InwardBlsFrsRelation
			get
				return new FetchPath.o.Tb_InwardBlsFrsRelation(new ArrayList(), "Tb_InwardBlsFrs")
			end get
		end property
		public Shared ReadOnly Property TB_InwardBlsGoods() as FetchPath.o.TB_InwardBlsGoodsRelation
			get
				return new FetchPath.o.TB_InwardBlsGoodsRelation(new ArrayList(), "TB_InwardBlsGoods")
			end get
		end property
		public Shared ReadOnly Property TB_InwardBlsNames() as FetchPath.o.TB_InwardBlsNamesRelation
			get
				return new FetchPath.o.TB_InwardBlsNamesRelation(new ArrayList(), "TB_InwardBlsNames")
			end get
		end property
		public Shared ReadOnly Property TB_InwardCharges() as FetchPath.o.TB_InwardChargesRelation
			get
				return new FetchPath.o.TB_InwardChargesRelation(new ArrayList(), "TB_InwardCharges")
			end get
		end property
		public Shared ReadOnly Property TB_InwardCnsImco() as FetchPath.o.TB_InwardCnsImcoRelation
			get
				return new FetchPath.o.TB_InwardCnsImcoRelation(new ArrayList(), "TB_InwardCnsImco")
			end get
		end property
		public Shared ReadOnly Property TB_InwardCnsPkgs() as FetchPath.o.TB_InwardCnsPkgsRelation
			get
				return new FetchPath.o.TB_InwardCnsPkgsRelation(new ArrayList(), "TB_InwardCnsPkgs")
			end get
		end property
		public Shared ReadOnly Property TB_InwardCnsTemprature() as FetchPath.o.TB_InwardCnsTempratureRelation
			get
				return new FetchPath.o.TB_InwardCnsTempratureRelation(new ArrayList(), "TB_InwardCnsTemprature")
			end get
		end property
		public Shared ReadOnly Property TB_InwardCntrs() as FetchPath.o.TB_InwardCntrsRelation
			get
				return new FetchPath.o.TB_InwardCntrsRelation(new ArrayList(), "TB_InwardCntrs")
			end get
		end property
		public Shared ReadOnly Property TB_InwardCntrsCharges() as FetchPath.o.TB_InwardCntrsChargesRelation
			get
				return new FetchPath.o.TB_InwardCntrsChargesRelation(new ArrayList(), "TB_InwardCntrsCharges")
			end get
		end property
		public Shared ReadOnly Property TB_InwardDiscount() as FetchPath.o.TB_InwardDiscountRelation
			get
				return new FetchPath.o.TB_InwardDiscountRelation(new ArrayList(), "TB_InwardDiscount")
			end get
		end property
		public Shared ReadOnly Property TB_InwardStatus() as FetchPath.o.TB_InwardStatusRelation
			get
				return new FetchPath.o.TB_InwardStatusRelation(new ArrayList(), "TB_InwardStatus")
			end get
		end property
		public Shared ReadOnly Property TB_ISOType() as FetchPath.o.TB_ISOTypeRelation
			get
				return new FetchPath.o.TB_ISOTypeRelation(new ArrayList(), "TB_ISOType")
			end get
		end property
		public Shared ReadOnly Property TB_Lines() as FetchPath.o.TB_LinesRelation
			get
				return new FetchPath.o.TB_LinesRelation(new ArrayList(), "TB_Lines")
			end get
		end property
		public Shared ReadOnly Property TB_Log() as FetchPath.o.TB_LogRelation
			get
				return new FetchPath.o.TB_LogRelation(new ArrayList(), "TB_Log")
			end get
		end property
		public Shared ReadOnly Property TB_LogDetails() as FetchPath.o.TB_LogDetailsRelation
			get
				return new FetchPath.o.TB_LogDetailsRelation(new ArrayList(), "TB_LogDetails")
			end get
		end property
		public Shared ReadOnly Property TB_LogMaster() as FetchPath.o.TB_LogMasterRelation
			get
				return new FetchPath.o.TB_LogMasterRelation(new ArrayList(), "TB_LogMaster")
			end get
		end property
		public Shared ReadOnly Property TB_MenuItems() as FetchPath.o.TB_MenuItemsRelation
			get
				return new FetchPath.o.TB_MenuItemsRelation(new ArrayList(), "TB_MenuItems")
			end get
		end property
		public Shared ReadOnly Property TB_NOSPaymentTyps() as FetchPath.o.TB_NOSPaymentTypsRelation
			get
				return new FetchPath.o.TB_NOSPaymentTypsRelation(new ArrayList(), "TB_NOSPaymentTyps")
			end get
		end property
		public Shared ReadOnly Property TB_Objects() as FetchPath.o.TB_ObjectsRelation
			get
				return new FetchPath.o.TB_ObjectsRelation(new ArrayList(), "TB_Objects")
			end get
		end property
		public Shared ReadOnly Property TB_ObjectsUser() as FetchPath.o.TB_ObjectsUserRelation
			get
				return new FetchPath.o.TB_ObjectsUserRelation(new ArrayList(), "TB_ObjectsUser")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
			get
				return new FetchPath.o.TB_OutwardBLSRelation(new ArrayList(), "TB_OutwardBLS")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardBlsComments() as FetchPath.o.TB_OutwardBlsCommentsRelation
			get
				return new FetchPath.o.TB_OutwardBlsCommentsRelation(new ArrayList(), "TB_OutwardBlsComments")
			end get
		end property
		public Shared ReadOnly Property Tb_OutwardBlsFrs() as FetchPath.o.Tb_OutwardBlsFrsRelation
			get
				return new FetchPath.o.Tb_OutwardBlsFrsRelation(new ArrayList(), "Tb_OutwardBlsFrs")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardBlsGoods() as FetchPath.o.TB_OutwardBlsGoodsRelation
			get
				return new FetchPath.o.TB_OutwardBlsGoodsRelation(new ArrayList(), "TB_OutwardBlsGoods")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardBlsNames() as FetchPath.o.TB_OutwardBlsNamesRelation
			get
				return new FetchPath.o.TB_OutwardBlsNamesRelation(new ArrayList(), "TB_OutwardBlsNames")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardBlsTemplate() as FetchPath.o.TB_OutwardBlsTemplateRelation
			get
				return new FetchPath.o.TB_OutwardBlsTemplateRelation(new ArrayList(), "TB_OutwardBlsTemplate")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardCharges() as FetchPath.o.TB_OutwardChargesRelation
			get
				return new FetchPath.o.TB_OutwardChargesRelation(new ArrayList(), "TB_OutwardCharges")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardCnsImco() as FetchPath.o.TB_OutwardCnsImcoRelation
			get
				return new FetchPath.o.TB_OutwardCnsImcoRelation(new ArrayList(), "TB_OutwardCnsImco")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardCnsPkgs() as FetchPath.o.TB_OutwardCnsPkgsRelation
			get
				return new FetchPath.o.TB_OutwardCnsPkgsRelation(new ArrayList(), "TB_OutwardCnsPkgs")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardCnsTemprature() as FetchPath.o.TB_OutwardCnsTempratureRelation
			get
				return new FetchPath.o.TB_OutwardCnsTempratureRelation(new ArrayList(), "TB_OutwardCnsTemprature")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardCntrs() as FetchPath.o.TB_OutwardCntrsRelation
			get
				return new FetchPath.o.TB_OutwardCntrsRelation(new ArrayList(), "TB_OutwardCntrs")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardCntrsCharges() as FetchPath.o.TB_OutwardCntrsChargesRelation
			get
				return new FetchPath.o.TB_OutwardCntrsChargesRelation(new ArrayList(), "TB_OutwardCntrsCharges")
			end get
		end property
		public Shared ReadOnly Property TB_OutwardDiscount() as FetchPath.o.TB_OutwardDiscountRelation
			get
				return new FetchPath.o.TB_OutwardDiscountRelation(new ArrayList(), "TB_OutwardDiscount")
			end get
		end property
		public Shared ReadOnly Property TB_PermitDetails() as FetchPath.o.TB_PermitDetailsRelation
			get
				return new FetchPath.o.TB_PermitDetailsRelation(new ArrayList(), "TB_PermitDetails")
			end get
		end property
		public Shared ReadOnly Property TB_Permits() as FetchPath.o.TB_PermitsRelation
			get
				return new FetchPath.o.TB_PermitsRelation(new ArrayList(), "TB_Permits")
			end get
		end property
		public Shared ReadOnly Property TB_PInvoice() as FetchPath.o.TB_PInvoiceRelation
			get
				return new FetchPath.o.TB_PInvoiceRelation(new ArrayList(), "TB_PInvoice")
			end get
		end property
		public Shared ReadOnly Property TB_PInvoiceDetails() as FetchPath.o.TB_PInvoiceDetailsRelation
			get
				return new FetchPath.o.TB_PInvoiceDetailsRelation(new ArrayList(), "TB_PInvoiceDetails")
			end get
		end property
		public Shared ReadOnly Property TB_Ports() as FetchPath.o.TB_PortsRelation
			get
				return new FetchPath.o.TB_PortsRelation(new ArrayList(), "TB_Ports")
			end get
		end property
		public Shared ReadOnly Property TB_RecivedItems() as FetchPath.o.TB_RecivedItemsRelation
			get
				return new FetchPath.o.TB_RecivedItemsRelation(new ArrayList(), "TB_RecivedItems")
			end get
		end property
		public Shared ReadOnly Property TB_Reference() as FetchPath.o.TB_ReferenceRelation
			get
				return new FetchPath.o.TB_ReferenceRelation(new ArrayList(), "TB_Reference")
			end get
		end property
		public Shared ReadOnly Property TB_ReleaseLetterSeq() as FetchPath.o.TB_ReleaseLetterSeqRelation
			get
				return new FetchPath.o.TB_ReleaseLetterSeqRelation(new ArrayList(), "TB_ReleaseLetterSeq")
			end get
		end property
		public Shared ReadOnly Property TB_ReportCustomFields() as FetchPath.o.TB_ReportCustomFieldsRelation
			get
				return new FetchPath.o.TB_ReportCustomFieldsRelation(new ArrayList(), "TB_ReportCustomFields")
			end get
		end property
		public Shared ReadOnly Property TB_SCNIDS() as FetchPath.o.TB_SCNIDSRelation
			get
				return new FetchPath.o.TB_SCNIDSRelation(new ArrayList(), "TB_SCNIDS")
			end get
		end property
		public Shared ReadOnly Property TB_Seq() as FetchPath.o.TB_SeqRelation
			get
				return new FetchPath.o.TB_SeqRelation(new ArrayList(), "TB_Seq")
			end get
		end property
		public Shared ReadOnly Property TB_SOF() as FetchPath.o.TB_SOFRelation
			get
				return new FetchPath.o.TB_SOFRelation(new ArrayList(), "TB_SOF")
			end get
		end property
		public Shared ReadOnly Property TB_TaxBase() as FetchPath.o.TB_TaxBaseRelation
			get
				return new FetchPath.o.TB_TaxBaseRelation(new ArrayList(), "TB_TaxBase")
			end get
		end property
		public Shared ReadOnly Property TB_Users() as FetchPath.o.TB_UsersRelation
			get
				return new FetchPath.o.TB_UsersRelation(new ArrayList(), "TB_Users")
			end get
		end property
		public Shared ReadOnly Property TB_UsersDept() as FetchPath.o.TB_UsersDeptRelation
			get
				return new FetchPath.o.TB_UsersDeptRelation(new ArrayList(), "TB_UsersDept")
			end get
		end property
		public Shared ReadOnly Property TB_UsersLine() as FetchPath.o.TB_UsersLineRelation
			get
				return new FetchPath.o.TB_UsersLineRelation(new ArrayList(), "TB_UsersLine")
			end get
		end property
		public Shared ReadOnly Property TB_Vessels() as FetchPath.o.TB_VesselsRelation
			get
				return new FetchPath.o.TB_VesselsRelation(new ArrayList(), "TB_Vessels")
			end get
		end property
		public Shared ReadOnly Property TB_Voyage() as FetchPath.o.TB_VoyageRelation
			get
				return new FetchPath.o.TB_VoyageRelation(new ArrayList(), "TB_Voyage")
			end get
		end property

		<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>public class o
		
			private Sub New()
			End Sub


			public class sysdiagramsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as sysdiagramsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as sysdiagramsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as sysdiagramsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_AccessLevelRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AccessLevelRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_MenuItems","ID","TB_AccessLevel","MenuItemID", Me.OrmAlias, Me.OrmAlias + "_TB_M1", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Users","ID","TB_AccessLevel","UserID", Me.OrmAlias, Me.OrmAlias + "_TB_U2", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AccessLevelRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AccessLevelRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_MenuItems","ID","TB_AccessLevel","MenuItemID", Me.OrmAlias, Me.OrmAlias + "_TB_M1", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Users","ID","TB_AccessLevel","UserID", Me.OrmAlias, Me.OrmAlias + "_TB_U2", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_MenuItems() as FetchPath.o.TB_MenuItemsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_MenuItems","ID","TB_AccessLevel","MenuItemID", Me.OrmAlias, "_TB_M1", true ))
						return new FetchPath.o.TB_MenuItemsRelation(RelationList, Me.OrmAlias + "_TB_M1")
					end get
				end property

				
				public ReadOnly property TB_Users() as FetchPath.o.TB_UsersRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Users","ID","TB_AccessLevel","UserID", Me.OrmAlias, "_TB_U2", true ))
						return new FetchPath.o.TB_UsersRelation(RelationList, Me.OrmAlias + "_TB_U2")
					end get
				end property

				

			End Class
			
			public class TB_AccountRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AccountRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AccountRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AccountRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_AgentsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AgentsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AgentsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AgentsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_AUTAdditionalDocsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AUTAdditionalDocsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AUTAdditionalDocsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AUTAdditionalDocsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_AUTDummyRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AUTDummyRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AUTDummyRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AUTDummyRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_AUTDummyLogRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AUTDummyLogRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AUTDummyLogRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AUTDummyLogRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_AUTJobLogsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AUTJobLogsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_AUTJobLogs","ID","TB_AUTJobLogsDetail","JobID", Me.OrmAlias, Me.OrmAlias + "_TB_A3", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AUTJobLogsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_AUTJobLogs","ID","TB_AUTJobLogsDetail","JobID", Me.OrmAlias, Me.OrmAlias + "_TB_A3", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AUTJobLogsRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_AUTJobLogsDetail() as FetchPath.o.TB_AUTJobLogsDetailRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_AUTJobLogs","ID","TB_AUTJobLogsDetail","JobID", Me.OrmAlias, "_TB_A3", false ))
						return new FetchPath.o.TB_AUTJobLogsDetailRelation(RelationList, Me.OrmAlias + "_TB_A3")
					end get
				end property

				

			End Class
			
			public class TB_AUTJobLogsDetailRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AUTJobLogsDetailRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_AUTJobLogs","ID","TB_AUTJobLogsDetail","JobID", Me.OrmAlias, Me.OrmAlias + "_TB_A3", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AUTJobLogsDetailRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AUTJobLogsDetailRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_AUTJobLogs","ID","TB_AUTJobLogsDetail","JobID", Me.OrmAlias, Me.OrmAlias + "_TB_A3", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_AUTJobLogs() as FetchPath.o.TB_AUTJobLogsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_AUTJobLogs","ID","TB_AUTJobLogsDetail","JobID", Me.OrmAlias, "_TB_A3", true ))
						return new FetchPath.o.TB_AUTJobLogsRelation(RelationList, Me.OrmAlias + "_TB_A3")
					end get
				end property

				

			End Class
			
			public class TB_AUTJobsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AUTJobsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AUTJobsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AUTJobsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_autoLogRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_autoLogRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_autoLogRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_autoLogRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_AUTScheduleRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AUTScheduleRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AUTScheduleRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AUTScheduleRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_AUTSettingsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_AUTSettingsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_AUTSettingsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_AUTSettingsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_BookingRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_BookingRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingCns","PID", Me.OrmAlias, Me.OrmAlias + "_TB_B5", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingDetails","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B6", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingRelease","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B8", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_EcsContainers","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_E11", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_OutwardBLS","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_O39", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_Booking","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_C4", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_BookingRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingCns","PID", Me.OrmAlias, Me.OrmAlias + "_TB_B5", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingDetails","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B6", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingRelease","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B8", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_EcsContainers","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_E11", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_OutwardBLS","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_O39", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_BookingRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_Booking","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_C4", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_BookingCns() as FetchPath.o.TB_BookingCnsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingCns","PID", Me.OrmAlias, "_TB_B5", false ))
						return new FetchPath.o.TB_BookingCnsRelation(RelationList, Me.OrmAlias + "_TB_B5")
					end get
				end property

				
				public ReadOnly property TB_BookingDetails() as FetchPath.o.TB_BookingDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingDetails","BookingID", Me.OrmAlias, "_TB_B6", false ))
						return new FetchPath.o.TB_BookingDetailsRelation(RelationList, Me.OrmAlias + "_TB_B6")
					end get
				end property

				
				public ReadOnly property TB_BookingRelease() as FetchPath.o.TB_BookingReleaseRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingRelease","BookingID", Me.OrmAlias, "_TB_B8", false ))
						return new FetchPath.o.TB_BookingReleaseRelation(RelationList, Me.OrmAlias + "_TB_B8")
					end get
				end property

				
				public ReadOnly property TB_EcsContainers() as FetchPath.o.TB_EcsContainersRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_EcsContainers","BookingID", Me.OrmAlias, "_TB_E11", false ))
						return new FetchPath.o.TB_EcsContainersRelation(RelationList, Me.OrmAlias + "_TB_E11")
					end get
				end property

				
				public ReadOnly property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_OutwardBLS","BookingID", Me.OrmAlias, "_TB_O39", false ))
						return new FetchPath.o.TB_OutwardBLSRelation(RelationList, Me.OrmAlias + "_TB_O39")
					end get
				end property

				
				public ReadOnly property TB_Clients() as FetchPath.o.TB_ClientsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_Booking","ClientID", Me.OrmAlias, "_TB_C4", true ))
						return new FetchPath.o.TB_ClientsRelation(RelationList, Me.OrmAlias + "_TB_C4")
					end get
				end property

				

			End Class
			
			public class TB_BookingCnsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_BookingCnsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingCns","PID", Me.OrmAlias, Me.OrmAlias + "_TB_B5", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_BookingCnsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_BookingCnsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingCns","PID", Me.OrmAlias, Me.OrmAlias + "_TB_B5", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Booking() as FetchPath.o.TB_BookingRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingCns","PID", Me.OrmAlias, "_TB_B5", true ))
						return new FetchPath.o.TB_BookingRelation(RelationList, Me.OrmAlias + "_TB_B5")
					end get
				end property

				

			End Class
			
			public class TB_BookingDepositsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_BookingDepositsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_BookingDepositsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_BookingDepositsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_BookingDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_BookingDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingDetails","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B6", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_BookingDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_BookingDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingDetails","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B6", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Booking() as FetchPath.o.TB_BookingRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingDetails","BookingID", Me.OrmAlias, "_TB_B6", true ))
						return new FetchPath.o.TB_BookingRelation(RelationList, Me.OrmAlias + "_TB_B6")
					end get
				end property

				

			End Class
			
			public class TB_BookingReleasCntrsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_BookingReleasCntrsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_BookingRelease","ID","TB_BookingReleasCntrs","ReleaseID", Me.OrmAlias, Me.OrmAlias + "_TB_B7", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_BookingReleasCntrsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_BookingReleasCntrsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_BookingRelease","ID","TB_BookingReleasCntrs","ReleaseID", Me.OrmAlias, Me.OrmAlias + "_TB_B7", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_BookingRelease() as FetchPath.o.TB_BookingReleaseRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_BookingRelease","ID","TB_BookingReleasCntrs","ReleaseID", Me.OrmAlias, "_TB_B7", true ))
						return new FetchPath.o.TB_BookingReleaseRelation(RelationList, Me.OrmAlias + "_TB_B7")
					end get
				end property

				

			End Class
			
			public class TB_BookingReleaseRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_BookingReleaseRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_BookingRelease","ID","TB_BookingReleasCntrs","ReleaseID", Me.OrmAlias, Me.OrmAlias + "_TB_B7", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingRelease","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B8", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_BookingReleaseRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_BookingRelease","ID","TB_BookingReleasCntrs","ReleaseID", Me.OrmAlias, Me.OrmAlias + "_TB_B7", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_BookingReleaseRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingRelease","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B8", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_BookingReleasCntrs() as FetchPath.o.TB_BookingReleasCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_BookingRelease","ID","TB_BookingReleasCntrs","ReleaseID", Me.OrmAlias, "_TB_B7", false ))
						return new FetchPath.o.TB_BookingReleasCntrsRelation(RelationList, Me.OrmAlias + "_TB_B7")
					end get
				end property

				
				public ReadOnly property TB_Booking() as FetchPath.o.TB_BookingRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingRelease","BookingID", Me.OrmAlias, "_TB_B8", true ))
						return new FetchPath.o.TB_BookingRelation(RelationList, Me.OrmAlias + "_TB_B8")
					end get
				end property

				

			End Class
			
			public class TB_CalculationBaseRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_CalculationBaseRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_CalculationBaseRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_CalculationBaseRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_ChgLevelDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ChgLevelDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_ChgLevelMaster","ID","TB_ChgLevelDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_C9", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ChgLevelDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ChgLevelDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_ChgLevelMaster","ID","TB_ChgLevelDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_C9", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_ChgLevelMaster() as FetchPath.o.TB_ChgLevelMasterRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_ChgLevelMaster","ID","TB_ChgLevelDetails","MasterID", Me.OrmAlias, "_TB_C9", true ))
						return new FetchPath.o.TB_ChgLevelMasterRelation(RelationList, Me.OrmAlias + "_TB_C9")
					end get
				end property

				

			End Class
			
			public class TB_ChgLevelMasterRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ChgLevelMasterRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_ChgLevelMaster","ID","TB_ChgLevelDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_C9", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ChgLevelMasterRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_ChgLevelMaster","ID","TB_ChgLevelDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_C9", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ChgLevelMasterRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_ChgLevelDetails() as FetchPath.o.TB_ChgLevelDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_ChgLevelMaster","ID","TB_ChgLevelDetails","MasterID", Me.OrmAlias, "_TB_C9", false ))
						return new FetchPath.o.TB_ChgLevelDetailsRelation(RelationList, Me.OrmAlias + "_TB_C9")
					end get
				end property

				

			End Class
			
			public class TB_ClientsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ClientsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_Booking","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_B4", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_InwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_I24", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_OutwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_O40", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ClientsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_Booking","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_B4", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_InwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_I24", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_OutwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_O40", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ClientsRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_Booking() as FetchPath.o.TB_BookingRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_Booking","ClientID", Me.OrmAlias, "_TB_B4", false ))
						return new FetchPath.o.TB_BookingRelation(RelationList, Me.OrmAlias + "_TB_B4")
					end get
				end property

				
				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_InwardBLS","ClientID", Me.OrmAlias, "_TB_I24", false ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I24")
					end get
				end property

				
				public ReadOnly property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_OutwardBLS","ClientID", Me.OrmAlias, "_TB_O40", false ))
						return new FetchPath.o.TB_OutwardBLSRelation(RelationList, Me.OrmAlias + "_TB_O40")
					end get
				end property

				

			End Class
			
			public class TB_ClusesRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ClusesRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ClusesRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ClusesRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_CODERelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_CODERelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_CodeMaster","GroupCode","TB_CODE","GroupCode", Me.OrmAlias, Me.OrmAlias + "_TB_C10", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_CODERelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_CODERelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_CodeMaster","GroupCode","TB_CODE","GroupCode", Me.OrmAlias, Me.OrmAlias + "_TB_C10", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_CodeMaster() as FetchPath.o.TB_CodeMasterRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_CodeMaster","GroupCode","TB_CODE","GroupCode", Me.OrmAlias, "_TB_C10", true ))
						return new FetchPath.o.TB_CodeMasterRelation(RelationList, Me.OrmAlias + "_TB_C10")
					end get
				end property

				

			End Class
			
			public class TB_CodeMasterRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_CodeMasterRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_CodeMaster","GroupCode","TB_CODE","GroupCode", Me.OrmAlias, Me.OrmAlias + "_TB_C10", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_CodeMasterRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_CodeMaster","GroupCode","TB_CODE","GroupCode", Me.OrmAlias, Me.OrmAlias + "_TB_C10", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_CodeMasterRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_CODE() as FetchPath.o.TB_CODERelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_CodeMaster","GroupCode","TB_CODE","GroupCode", Me.OrmAlias, "_TB_C10", false ))
						return new FetchPath.o.TB_CODERelation(RelationList, Me.OrmAlias + "_TB_C10")
					end get
				end property

				

			End Class
			
			public class TB_CompanyRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_CompanyRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_CompanyRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_CompanyRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_CountryRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_CountryRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_CountryRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_CountryRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_CustomMenuRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_CustomMenuRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_CustomMenuRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_CustomMenuRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_DamageRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_DamageRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_Damage","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E13", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_DamageRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_DamageRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_Damage","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E13", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_EcsContainers() as FetchPath.o.TB_EcsContainersRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_Damage","CntrID", Me.OrmAlias, "_TB_E13", true ))
						return new FetchPath.o.TB_EcsContainersRelation(RelationList, Me.OrmAlias + "_TB_E13")
					end get
				end property

				

			End Class
			
			public class TB_DepositsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_DepositsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_DepositsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_DepositsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_DetentionBaseRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_DetentionBaseRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_DetentionBase","ID","TB_DetentionBaseDetails","BaseID", Me.OrmAlias, Me.OrmAlias + "_TB_D14", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_DetentionBaseRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_DetentionBase","ID","TB_DetentionBaseDetails","BaseID", Me.OrmAlias, Me.OrmAlias + "_TB_D14", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_DetentionBaseRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_DetentionBaseDetails() as FetchPath.o.TB_DetentionBaseDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_DetentionBase","ID","TB_DetentionBaseDetails","BaseID", Me.OrmAlias, "_TB_D14", false ))
						return new FetchPath.o.TB_DetentionBaseDetailsRelation(RelationList, Me.OrmAlias + "_TB_D14")
					end get
				end property

				

			End Class
			
			public class TB_DetentionBaseDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_DetentionBaseDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_DetentionBase","ID","TB_DetentionBaseDetails","BaseID", Me.OrmAlias, Me.OrmAlias + "_TB_D14", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_DetentionBaseDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_DetentionBaseDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_DetentionBase","ID","TB_DetentionBaseDetails","BaseID", Me.OrmAlias, Me.OrmAlias + "_TB_D14", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_DetentionBase() as FetchPath.o.TB_DetentionBaseRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_DetentionBase","ID","TB_DetentionBaseDetails","BaseID", Me.OrmAlias, "_TB_D14", true ))
						return new FetchPath.o.TB_DetentionBaseRelation(RelationList, Me.OrmAlias + "_TB_D14")
					end get
				end property

				

			End Class
			
			public class TB_DocumetsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_DocumetsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Documets","ID","TB_DocumetsDetail","DocumentID", Me.OrmAlias, Me.OrmAlias + "_TB_D15", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_DocumetsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Documets","ID","TB_DocumetsDetail","DocumentID", Me.OrmAlias, Me.OrmAlias + "_TB_D15", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_DocumetsRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_DocumetsDetail() as FetchPath.o.TB_DocumetsDetailRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Documets","ID","TB_DocumetsDetail","DocumentID", Me.OrmAlias, "_TB_D15", false ))
						return new FetchPath.o.TB_DocumetsDetailRelation(RelationList, Me.OrmAlias + "_TB_D15")
					end get
				end property

				

			End Class
			
			public class TB_DocumetsDetailRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_DocumetsDetailRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_Documets","ID","TB_DocumetsDetail","DocumentID", Me.OrmAlias, Me.OrmAlias + "_TB_D15", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_DocumetsDetailRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_DocumetsDetailRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Documets","ID","TB_DocumetsDetail","DocumentID", Me.OrmAlias, Me.OrmAlias + "_TB_D15", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Documets() as FetchPath.o.TB_DocumetsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Documets","ID","TB_DocumetsDetail","DocumentID", Me.OrmAlias, "_TB_D15", true ))
						return new FetchPath.o.TB_DocumetsRelation(RelationList, Me.OrmAlias + "_TB_D15")
					end get
				end property

				

			End Class
			
			public class TB_EcsContainersRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_EcsContainersRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_Damage","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_D13", false))
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_EcsMoves","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E16", false))
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_PermitDetails","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_P51", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_EcsContainers","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B11", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_EcsContainers","InVoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_V12", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_EcsContainersRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_Damage","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_D13", false))
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_EcsMoves","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E16", false))
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_PermitDetails","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_P51", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_EcsContainersRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_EcsContainers","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B11", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_EcsContainers","InVoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_V12", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Damage() as FetchPath.o.TB_DamageRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_Damage","CntrID", Me.OrmAlias, "_TB_D13", false ))
						return new FetchPath.o.TB_DamageRelation(RelationList, Me.OrmAlias + "_TB_D13")
					end get
				end property

				
				public ReadOnly property TB_EcsMoves() as FetchPath.o.TB_EcsMovesRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_EcsMoves","CntrID", Me.OrmAlias, "_TB_E16", false ))
						return new FetchPath.o.TB_EcsMovesRelation(RelationList, Me.OrmAlias + "_TB_E16")
					end get
				end property

				
				public ReadOnly property TB_PermitDetails() as FetchPath.o.TB_PermitDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_PermitDetails","CntrID", Me.OrmAlias, "_TB_P51", false ))
						return new FetchPath.o.TB_PermitDetailsRelation(RelationList, Me.OrmAlias + "_TB_P51")
					end get
				end property

				
				public ReadOnly property TB_Booking() as FetchPath.o.TB_BookingRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_EcsContainers","BookingID", Me.OrmAlias, "_TB_B11", true ))
						return new FetchPath.o.TB_BookingRelation(RelationList, Me.OrmAlias + "_TB_B11")
					end get
				end property

				
				public ReadOnly property TB_Voyage() as FetchPath.o.TB_VoyageRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_EcsContainers","InVoyageID", Me.OrmAlias, "_TB_V12", true ))
						return new FetchPath.o.TB_VoyageRelation(RelationList, Me.OrmAlias + "_TB_V12")
					end get
				end property

				

			End Class
			
			public class TB_EcsMovesRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_EcsMovesRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_EcsMoves","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E16", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_EcsMovesRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_EcsMovesRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_EcsMoves","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E16", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_EcsContainers() as FetchPath.o.TB_EcsContainersRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_EcsMoves","CntrID", Me.OrmAlias, "_TB_E16", true ))
						return new FetchPath.o.TB_EcsContainersRelation(RelationList, Me.OrmAlias + "_TB_E16")
					end get
				end property

				

			End Class
			
			public class TB_EcsReserveContainersRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_EcsReserveContainersRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_EcsReserveContainersRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_EcsReserveContainersRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_EventMailRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_EventMailRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_EventMailRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_EventMailRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_ExchangeRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ExchangeRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Exchange","ID","TB_ExchangeDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_E17", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ExchangeRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Exchange","ID","TB_ExchangeDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_E17", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ExchangeRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_ExchangeDetails() as FetchPath.o.TB_ExchangeDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Exchange","ID","TB_ExchangeDetails","MasterID", Me.OrmAlias, "_TB_E17", false ))
						return new FetchPath.o.TB_ExchangeDetailsRelation(RelationList, Me.OrmAlias + "_TB_E17")
					end get
				end property

				

			End Class
			
			public class TB_ExchangeDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ExchangeDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_Exchange","ID","TB_ExchangeDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_E17", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ExchangeDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ExchangeDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Exchange","ID","TB_ExchangeDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_E17", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Exchange() as FetchPath.o.TB_ExchangeRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Exchange","ID","TB_ExchangeDetails","MasterID", Me.OrmAlias, "_TB_E17", true ))
						return new FetchPath.o.TB_ExchangeRelation(RelationList, Me.OrmAlias + "_TB_E17")
					end get
				end property

				

			End Class
			
			public class TB_ExpInvoiceRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ExpInvoiceRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E19", false))
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpRecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E20", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_ExpInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O18", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ExpInvoiceRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E19", false))
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpRecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E20", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ExpInvoiceRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_ExpInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O18", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_ExpInvoiceDetails() as FetchPath.o.TB_ExpInvoiceDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpInvoiceDetails","InvoiceID", Me.OrmAlias, "_TB_E19", false ))
						return new FetchPath.o.TB_ExpInvoiceDetailsRelation(RelationList, Me.OrmAlias + "_TB_E19")
					end get
				end property

				
				public ReadOnly property TB_ExpRecivedItems() as FetchPath.o.TB_ExpRecivedItemsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpRecivedItems","InvoiceID", Me.OrmAlias, "_TB_E20", false ))
						return new FetchPath.o.TB_ExpRecivedItemsRelation(RelationList, Me.OrmAlias + "_TB_E20")
					end get
				end property

				
				public ReadOnly property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_ExpInvoice","BLID", Me.OrmAlias, "_TB_O18", true ))
						return new FetchPath.o.TB_OutwardBLSRelation(RelationList, Me.OrmAlias + "_TB_O18")
					end get
				end property

				

			End Class
			
			public class TB_ExpInvoiceDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ExpInvoiceDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E19", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ExpInvoiceDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ExpInvoiceDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E19", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_ExpInvoice() as FetchPath.o.TB_ExpInvoiceRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpInvoiceDetails","InvoiceID", Me.OrmAlias, "_TB_E19", true ))
						return new FetchPath.o.TB_ExpInvoiceRelation(RelationList, Me.OrmAlias + "_TB_E19")
					end get
				end property

				

			End Class
			
			public class TB_ExpRecivedItemsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ExpRecivedItemsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpRecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E20", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ExpRecivedItemsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ExpRecivedItemsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpRecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E20", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_ExpInvoice() as FetchPath.o.TB_ExpInvoiceRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpRecivedItems","InvoiceID", Me.OrmAlias, "_TB_E20", true ))
						return new FetchPath.o.TB_ExpInvoiceRelation(RelationList, Me.OrmAlias + "_TB_E20")
					end get
				end property

				

			End Class
			
			public class TB_FaxActionsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_FaxActionsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_FaxActionsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_FaxActionsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_FaxStatusRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_FaxStatusRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_FaxStatusRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_FaxStatusRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_InqueryRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InqueryRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Inquery","ID","TB_InqueryDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_I21", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InqueryRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Inquery","ID","TB_InqueryDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_I21", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InqueryRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_InqueryDetails() as FetchPath.o.TB_InqueryDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Inquery","ID","TB_InqueryDetails","MasterID", Me.OrmAlias, "_TB_I21", false ))
						return new FetchPath.o.TB_InqueryDetailsRelation(RelationList, Me.OrmAlias + "_TB_I21")
					end get
				end property

				

			End Class
			
			public class TB_InqueryDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InqueryDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_Inquery","ID","TB_InqueryDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_I21", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InqueryDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InqueryDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Inquery","ID","TB_InqueryDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_I21", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Inquery() as FetchPath.o.TB_InqueryRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Inquery","ID","TB_InqueryDetails","MasterID", Me.OrmAlias, "_TB_I21", true ))
						return new FetchPath.o.TB_InqueryRelation(RelationList, Me.OrmAlias + "_TB_I21")
					end get
				end property

				

			End Class
			
			public class TB_InvoiceRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InvoiceRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_InvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_I23", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_RecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_R55", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_Invoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I22", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InvoiceRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_InvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_I23", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_RecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_R55", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InvoiceRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_Invoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I22", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InvoiceDetails() as FetchPath.o.TB_InvoiceDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_InvoiceDetails","InvoiceID", Me.OrmAlias, "_TB_I23", false ))
						return new FetchPath.o.TB_InvoiceDetailsRelation(RelationList, Me.OrmAlias + "_TB_I23")
					end get
				end property

				
				public ReadOnly property TB_RecivedItems() as FetchPath.o.TB_RecivedItemsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_RecivedItems","InvoiceID", Me.OrmAlias, "_TB_R55", false ))
						return new FetchPath.o.TB_RecivedItemsRelation(RelationList, Me.OrmAlias + "_TB_R55")
					end get
				end property

				
				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_Invoice","BLID", Me.OrmAlias, "_TB_I22", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I22")
					end get
				end property

				

			End Class
			
			public class TB_InvoiceDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InvoiceDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_InvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_I23", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InvoiceDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InvoiceDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_InvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_I23", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Invoice() as FetchPath.o.TB_InvoiceRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_InvoiceDetails","InvoiceID", Me.OrmAlias, "_TB_I23", true ))
						return new FetchPath.o.TB_InvoiceRelation(RelationList, Me.OrmAlias + "_TB_I23")
					end get
				end property

				

			End Class
			
			public class TB_InwardBLSRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardBLSRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_Invoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I22", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsComments","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I26", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","Tb_InwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_Tb_I27", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I28", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I29", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I30", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I34", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I36", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardStatus","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I37", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_PInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_P53", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_InwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_C24", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_InwardBLS","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_V25", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardBLSRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_Invoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I22", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsComments","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I26", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","Tb_InwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_Tb_I27", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I28", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I29", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I30", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I34", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I36", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardStatus","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I37", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_PInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_P53", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardBLSRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_InwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_C24", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_InwardBLS","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_V25", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Invoice() as FetchPath.o.TB_InvoiceRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_Invoice","BLID", Me.OrmAlias, "_TB_I22", false ))
						return new FetchPath.o.TB_InvoiceRelation(RelationList, Me.OrmAlias + "_TB_I22")
					end get
				end property

				
				public ReadOnly property TB_InwardBlsComments() as FetchPath.o.TB_InwardBlsCommentsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsComments","BLID", Me.OrmAlias, "_TB_I26", false ))
						return new FetchPath.o.TB_InwardBlsCommentsRelation(RelationList, Me.OrmAlias + "_TB_I26")
					end get
				end property

				
				public ReadOnly property Tb_InwardBlsFrs() as FetchPath.o.Tb_InwardBlsFrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","Tb_InwardBlsFrs","BLID", Me.OrmAlias, "_Tb_I27", false ))
						return new FetchPath.o.Tb_InwardBlsFrsRelation(RelationList, Me.OrmAlias + "_Tb_I27")
					end get
				end property

				
				public ReadOnly property TB_InwardBlsGoods() as FetchPath.o.TB_InwardBlsGoodsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsGoods","BLID", Me.OrmAlias, "_TB_I28", false ))
						return new FetchPath.o.TB_InwardBlsGoodsRelation(RelationList, Me.OrmAlias + "_TB_I28")
					end get
				end property

				
				public ReadOnly property TB_InwardBlsNames() as FetchPath.o.TB_InwardBlsNamesRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsNames","BLID", Me.OrmAlias, "_TB_I29", false ))
						return new FetchPath.o.TB_InwardBlsNamesRelation(RelationList, Me.OrmAlias + "_TB_I29")
					end get
				end property

				
				public ReadOnly property TB_InwardCharges() as FetchPath.o.TB_InwardChargesRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCharges","BLID", Me.OrmAlias, "_TB_I30", false ))
						return new FetchPath.o.TB_InwardChargesRelation(RelationList, Me.OrmAlias + "_TB_I30")
					end get
				end property

				
				public ReadOnly property TB_InwardCntrs() as FetchPath.o.TB_InwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCntrs","BLID", Me.OrmAlias, "_TB_I34", false ))
						return new FetchPath.o.TB_InwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_I34")
					end get
				end property

				
				public ReadOnly property TB_InwardDiscount() as FetchPath.o.TB_InwardDiscountRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardDiscount","BLID", Me.OrmAlias, "_TB_I36", false ))
						return new FetchPath.o.TB_InwardDiscountRelation(RelationList, Me.OrmAlias + "_TB_I36")
					end get
				end property

				
				public ReadOnly property TB_InwardStatus() as FetchPath.o.TB_InwardStatusRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardStatus","BLID", Me.OrmAlias, "_TB_I37", false ))
						return new FetchPath.o.TB_InwardStatusRelation(RelationList, Me.OrmAlias + "_TB_I37")
					end get
				end property

				
				public ReadOnly property TB_PInvoice() as FetchPath.o.TB_PInvoiceRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_PInvoice","BLID", Me.OrmAlias, "_TB_P53", false ))
						return new FetchPath.o.TB_PInvoiceRelation(RelationList, Me.OrmAlias + "_TB_P53")
					end get
				end property

				
				public ReadOnly property TB_Clients() as FetchPath.o.TB_ClientsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_InwardBLS","ClientID", Me.OrmAlias, "_TB_C24", true ))
						return new FetchPath.o.TB_ClientsRelation(RelationList, Me.OrmAlias + "_TB_C24")
					end get
				end property

				
				public ReadOnly property TB_Voyage() as FetchPath.o.TB_VoyageRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_InwardBLS","VoyageID", Me.OrmAlias, "_TB_V25", true ))
						return new FetchPath.o.TB_VoyageRelation(RelationList, Me.OrmAlias + "_TB_V25")
					end get
				end property

				

			End Class
			
			public class TB_InwardBlsCommentsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardBlsCommentsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsComments","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I26", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardBlsCommentsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardBlsCommentsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsComments","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I26", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsComments","BLID", Me.OrmAlias, "_TB_I26", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I26")
					end get
				end property

				

			End Class
			
			public class Tb_InwardBlsFrsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as Tb_InwardBlsFrsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","Tb_InwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I27", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as Tb_InwardBlsFrsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as Tb_InwardBlsFrsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","Tb_InwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I27", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","Tb_InwardBlsFrs","BLID", Me.OrmAlias, "_TB_I27", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I27")
					end get
				end property

				

			End Class
			
			public class TB_InwardBlsGoodsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardBlsGoodsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I28", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardBlsGoodsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardBlsGoodsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I28", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsGoods","BLID", Me.OrmAlias, "_TB_I28", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I28")
					end get
				end property

				

			End Class
			
			public class TB_InwardBlsNamesRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardBlsNamesRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I29", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardBlsNamesRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardBlsNamesRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I29", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsNames","BLID", Me.OrmAlias, "_TB_I29", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I29")
					end get
				end property

				

			End Class
			
			public class TB_InwardChargesRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardChargesRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I30", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardChargesRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardChargesRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I30", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCharges","BLID", Me.OrmAlias, "_TB_I30", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I30")
					end get
				end property

				

			End Class
			
			public class TB_InwardCnsImcoRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardCnsImcoRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I31", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardCnsImcoRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardCnsImcoRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I31", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardCntrs() as FetchPath.o.TB_InwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsImco","CntrID", Me.OrmAlias, "_TB_I31", true ))
						return new FetchPath.o.TB_InwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_I31")
					end get
				end property

				

			End Class
			
			public class TB_InwardCnsPkgsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardCnsPkgsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I32", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardCnsPkgsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardCnsPkgsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I32", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardCntrs() as FetchPath.o.TB_InwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsPkgs","CntrID", Me.OrmAlias, "_TB_I32", true ))
						return new FetchPath.o.TB_InwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_I32")
					end get
				end property

				

			End Class
			
			public class TB_InwardCnsTempratureRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardCnsTempratureRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I33", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardCnsTempratureRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardCnsTempratureRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I33", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardCntrs() as FetchPath.o.TB_InwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsTemprature","CntrID", Me.OrmAlias, "_TB_I33", true ))
						return new FetchPath.o.TB_InwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_I33")
					end get
				end property

				

			End Class
			
			public class TB_InwardCntrsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardCntrsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I31", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I32", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I33", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I35", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I34", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardCntrsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I31", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I32", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I33", false))
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I35", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardCntrsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I34", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardCnsImco() as FetchPath.o.TB_InwardCnsImcoRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsImco","CntrID", Me.OrmAlias, "_TB_I31", false ))
						return new FetchPath.o.TB_InwardCnsImcoRelation(RelationList, Me.OrmAlias + "_TB_I31")
					end get
				end property

				
				public ReadOnly property TB_InwardCnsPkgs() as FetchPath.o.TB_InwardCnsPkgsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsPkgs","CntrID", Me.OrmAlias, "_TB_I32", false ))
						return new FetchPath.o.TB_InwardCnsPkgsRelation(RelationList, Me.OrmAlias + "_TB_I32")
					end get
				end property

				
				public ReadOnly property TB_InwardCnsTemprature() as FetchPath.o.TB_InwardCnsTempratureRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsTemprature","CntrID", Me.OrmAlias, "_TB_I33", false ))
						return new FetchPath.o.TB_InwardCnsTempratureRelation(RelationList, Me.OrmAlias + "_TB_I33")
					end get
				end property

				
				public ReadOnly property TB_InwardCntrsCharges() as FetchPath.o.TB_InwardCntrsChargesRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCntrsCharges","CntrID", Me.OrmAlias, "_TB_I35", false ))
						return new FetchPath.o.TB_InwardCntrsChargesRelation(RelationList, Me.OrmAlias + "_TB_I35")
					end get
				end property

				
				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCntrs","BLID", Me.OrmAlias, "_TB_I34", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I34")
					end get
				end property

				

			End Class
			
			public class TB_InwardCntrsChargesRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardCntrsChargesRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I35", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardCntrsChargesRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardCntrsChargesRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I35", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardCntrs() as FetchPath.o.TB_InwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCntrsCharges","CntrID", Me.OrmAlias, "_TB_I35", true ))
						return new FetchPath.o.TB_InwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_I35")
					end get
				end property

				

			End Class
			
			public class TB_InwardDiscountRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardDiscountRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I36", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardDiscountRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardDiscountRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I36", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardDiscount","BLID", Me.OrmAlias, "_TB_I36", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I36")
					end get
				end property

				

			End Class
			
			public class TB_InwardStatusRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_InwardStatusRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardStatus","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I37", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_InwardStatusRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_InwardStatusRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardStatus","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I37", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardStatus","BLID", Me.OrmAlias, "_TB_I37", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I37")
					end get
				end property

				

			End Class
			
			public class TB_ISOTypeRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ISOTypeRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ISOTypeRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ISOTypeRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_LinesRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_LinesRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_LinesRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_LinesRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_LogRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_LogRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_LogRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_LogRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_LogDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_LogDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_LogMaster","ID","TB_LogDetails","LogID", Me.OrmAlias, Me.OrmAlias + "_TB_L38", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_LogDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_LogDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_LogMaster","ID","TB_LogDetails","LogID", Me.OrmAlias, Me.OrmAlias + "_TB_L38", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_LogMaster() as FetchPath.o.TB_LogMasterRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_LogMaster","ID","TB_LogDetails","LogID", Me.OrmAlias, "_TB_L38", true ))
						return new FetchPath.o.TB_LogMasterRelation(RelationList, Me.OrmAlias + "_TB_L38")
					end get
				end property

				

			End Class
			
			public class TB_LogMasterRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_LogMasterRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_LogMaster","ID","TB_LogDetails","LogID", Me.OrmAlias, Me.OrmAlias + "_TB_L38", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_LogMasterRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_LogMaster","ID","TB_LogDetails","LogID", Me.OrmAlias, Me.OrmAlias + "_TB_L38", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_LogMasterRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_LogDetails() as FetchPath.o.TB_LogDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_LogMaster","ID","TB_LogDetails","LogID", Me.OrmAlias, "_TB_L38", false ))
						return new FetchPath.o.TB_LogDetailsRelation(RelationList, Me.OrmAlias + "_TB_L38")
					end get
				end property

				

			End Class
			
			public class TB_MenuItemsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_MenuItemsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_MenuItems","ID","TB_AccessLevel","MenuItemID", Me.OrmAlias, Me.OrmAlias + "_TB_A1", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_MenuItemsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_MenuItems","ID","TB_AccessLevel","MenuItemID", Me.OrmAlias, Me.OrmAlias + "_TB_A1", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_MenuItemsRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_AccessLevel() as FetchPath.o.TB_AccessLevelRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_MenuItems","ID","TB_AccessLevel","MenuItemID", Me.OrmAlias, "_TB_A1", false ))
						return new FetchPath.o.TB_AccessLevelRelation(RelationList, Me.OrmAlias + "_TB_A1")
					end get
				end property

				

			End Class
			
			public class TB_NOSPaymentTypsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_NOSPaymentTypsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_NOSPaymentTypsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_NOSPaymentTypsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_ObjectsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ObjectsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ObjectsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ObjectsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_ObjectsUserRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ObjectsUserRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ObjectsUserRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ObjectsUserRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_OutwardBLSRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardBLSRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_ExpInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_E18", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","Tb_OutwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_Tb_O41", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O42", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O43", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O44", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O48", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O50", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_OutwardBLS","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B39", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_OutwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_C40", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardBLSRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_ExpInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_E18", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","Tb_OutwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_Tb_O41", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O42", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O43", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O44", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O48", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O50", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardBLSRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_OutwardBLS","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B39", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_OutwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_C40", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_ExpInvoice() as FetchPath.o.TB_ExpInvoiceRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_ExpInvoice","BLID", Me.OrmAlias, "_TB_E18", false ))
						return new FetchPath.o.TB_ExpInvoiceRelation(RelationList, Me.OrmAlias + "_TB_E18")
					end get
				end property

				
				public ReadOnly property Tb_OutwardBlsFrs() as FetchPath.o.Tb_OutwardBlsFrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","Tb_OutwardBlsFrs","BLID", Me.OrmAlias, "_Tb_O41", false ))
						return new FetchPath.o.Tb_OutwardBlsFrsRelation(RelationList, Me.OrmAlias + "_Tb_O41")
					end get
				end property

				
				public ReadOnly property TB_OutwardBlsGoods() as FetchPath.o.TB_OutwardBlsGoodsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsGoods","BLID", Me.OrmAlias, "_TB_O42", false ))
						return new FetchPath.o.TB_OutwardBlsGoodsRelation(RelationList, Me.OrmAlias + "_TB_O42")
					end get
				end property

				
				public ReadOnly property TB_OutwardBlsNames() as FetchPath.o.TB_OutwardBlsNamesRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsNames","BLID", Me.OrmAlias, "_TB_O43", false ))
						return new FetchPath.o.TB_OutwardBlsNamesRelation(RelationList, Me.OrmAlias + "_TB_O43")
					end get
				end property

				
				public ReadOnly property TB_OutwardCharges() as FetchPath.o.TB_OutwardChargesRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCharges","BLID", Me.OrmAlias, "_TB_O44", false ))
						return new FetchPath.o.TB_OutwardChargesRelation(RelationList, Me.OrmAlias + "_TB_O44")
					end get
				end property

				
				public ReadOnly property TB_OutwardCntrs() as FetchPath.o.TB_OutwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCntrs","BLID", Me.OrmAlias, "_TB_O48", false ))
						return new FetchPath.o.TB_OutwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_O48")
					end get
				end property

				
				public ReadOnly property TB_OutwardDiscount() as FetchPath.o.TB_OutwardDiscountRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardDiscount","BLID", Me.OrmAlias, "_TB_O50", false ))
						return new FetchPath.o.TB_OutwardDiscountRelation(RelationList, Me.OrmAlias + "_TB_O50")
					end get
				end property

				
				public ReadOnly property TB_Booking() as FetchPath.o.TB_BookingRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_OutwardBLS","BookingID", Me.OrmAlias, "_TB_B39", true ))
						return new FetchPath.o.TB_BookingRelation(RelationList, Me.OrmAlias + "_TB_B39")
					end get
				end property

				
				public ReadOnly property TB_Clients() as FetchPath.o.TB_ClientsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_OutwardBLS","ClientID", Me.OrmAlias, "_TB_C40", true ))
						return new FetchPath.o.TB_ClientsRelation(RelationList, Me.OrmAlias + "_TB_C40")
					end get
				end property

				

			End Class
			
			public class TB_OutwardBlsCommentsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardBlsCommentsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardBlsCommentsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardBlsCommentsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class Tb_OutwardBlsFrsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as Tb_OutwardBlsFrsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","Tb_OutwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O41", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as Tb_OutwardBlsFrsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as Tb_OutwardBlsFrsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","Tb_OutwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O41", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","Tb_OutwardBlsFrs","BLID", Me.OrmAlias, "_TB_O41", true ))
						return new FetchPath.o.TB_OutwardBLSRelation(RelationList, Me.OrmAlias + "_TB_O41")
					end get
				end property

				

			End Class
			
			public class TB_OutwardBlsGoodsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardBlsGoodsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O42", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardBlsGoodsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardBlsGoodsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O42", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsGoods","BLID", Me.OrmAlias, "_TB_O42", true ))
						return new FetchPath.o.TB_OutwardBLSRelation(RelationList, Me.OrmAlias + "_TB_O42")
					end get
				end property

				

			End Class
			
			public class TB_OutwardBlsNamesRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardBlsNamesRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O43", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardBlsNamesRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardBlsNamesRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O43", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsNames","BLID", Me.OrmAlias, "_TB_O43", true ))
						return new FetchPath.o.TB_OutwardBLSRelation(RelationList, Me.OrmAlias + "_TB_O43")
					end get
				end property

				

			End Class
			
			public class TB_OutwardBlsTemplateRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardBlsTemplateRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardBlsTemplateRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardBlsTemplateRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_OutwardChargesRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardChargesRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O44", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardChargesRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardChargesRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O44", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCharges","BLID", Me.OrmAlias, "_TB_O44", true ))
						return new FetchPath.o.TB_OutwardBLSRelation(RelationList, Me.OrmAlias + "_TB_O44")
					end get
				end property

				

			End Class
			
			public class TB_OutwardCnsImcoRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardCnsImcoRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O45", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardCnsImcoRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardCnsImcoRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O45", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardCntrs() as FetchPath.o.TB_OutwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsImco","CntrID", Me.OrmAlias, "_TB_O45", true ))
						return new FetchPath.o.TB_OutwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_O45")
					end get
				end property

				

			End Class
			
			public class TB_OutwardCnsPkgsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardCnsPkgsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O46", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardCnsPkgsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardCnsPkgsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O46", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardCntrs() as FetchPath.o.TB_OutwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsPkgs","CntrID", Me.OrmAlias, "_TB_O46", true ))
						return new FetchPath.o.TB_OutwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_O46")
					end get
				end property

				

			End Class
			
			public class TB_OutwardCnsTempratureRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardCnsTempratureRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O47", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardCnsTempratureRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardCnsTempratureRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O47", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardCntrs() as FetchPath.o.TB_OutwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsTemprature","CntrID", Me.OrmAlias, "_TB_O47", true ))
						return new FetchPath.o.TB_OutwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_O47")
					end get
				end property

				

			End Class
			
			public class TB_OutwardCntrsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardCntrsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O45", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O46", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O47", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O49", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O48", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardCntrsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O45", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O46", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O47", false))
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O49", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardCntrsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O48", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardCnsImco() as FetchPath.o.TB_OutwardCnsImcoRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsImco","CntrID", Me.OrmAlias, "_TB_O45", false ))
						return new FetchPath.o.TB_OutwardCnsImcoRelation(RelationList, Me.OrmAlias + "_TB_O45")
					end get
				end property

				
				public ReadOnly property TB_OutwardCnsPkgs() as FetchPath.o.TB_OutwardCnsPkgsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsPkgs","CntrID", Me.OrmAlias, "_TB_O46", false ))
						return new FetchPath.o.TB_OutwardCnsPkgsRelation(RelationList, Me.OrmAlias + "_TB_O46")
					end get
				end property

				
				public ReadOnly property TB_OutwardCnsTemprature() as FetchPath.o.TB_OutwardCnsTempratureRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsTemprature","CntrID", Me.OrmAlias, "_TB_O47", false ))
						return new FetchPath.o.TB_OutwardCnsTempratureRelation(RelationList, Me.OrmAlias + "_TB_O47")
					end get
				end property

				
				public ReadOnly property TB_OutwardCntrsCharges() as FetchPath.o.TB_OutwardCntrsChargesRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCntrsCharges","CntrID", Me.OrmAlias, "_TB_O49", false ))
						return new FetchPath.o.TB_OutwardCntrsChargesRelation(RelationList, Me.OrmAlias + "_TB_O49")
					end get
				end property

				
				public ReadOnly property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCntrs","BLID", Me.OrmAlias, "_TB_O48", true ))
						return new FetchPath.o.TB_OutwardBLSRelation(RelationList, Me.OrmAlias + "_TB_O48")
					end get
				end property

				

			End Class
			
			public class TB_OutwardCntrsChargesRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardCntrsChargesRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O49", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardCntrsChargesRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardCntrsChargesRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O49", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardCntrs() as FetchPath.o.TB_OutwardCntrsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCntrsCharges","CntrID", Me.OrmAlias, "_TB_O49", true ))
						return new FetchPath.o.TB_OutwardCntrsRelation(RelationList, Me.OrmAlias + "_TB_O49")
					end get
				end property

				

			End Class
			
			public class TB_OutwardDiscountRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_OutwardDiscountRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O50", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_OutwardDiscountRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_OutwardDiscountRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O50", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_OutwardBLS() as FetchPath.o.TB_OutwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardDiscount","BLID", Me.OrmAlias, "_TB_O50", true ))
						return new FetchPath.o.TB_OutwardBLSRelation(RelationList, Me.OrmAlias + "_TB_O50")
					end get
				end property

				

			End Class
			
			public class TB_PermitDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_PermitDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_PermitDetails","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E51", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Permits","ID","TB_PermitDetails","PermitID", Me.OrmAlias, Me.OrmAlias + "_TB_P52", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_PermitDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_PermitDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_PermitDetails","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E51", true))
						RelationList.Add(new DataManagerBase.Relation("TB_Permits","ID","TB_PermitDetails","PermitID", Me.OrmAlias, Me.OrmAlias + "_TB_P52", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_EcsContainers() as FetchPath.o.TB_EcsContainersRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_PermitDetails","CntrID", Me.OrmAlias, "_TB_E51", true ))
						return new FetchPath.o.TB_EcsContainersRelation(RelationList, Me.OrmAlias + "_TB_E51")
					end get
				end property

				
				public ReadOnly property TB_Permits() as FetchPath.o.TB_PermitsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Permits","ID","TB_PermitDetails","PermitID", Me.OrmAlias, "_TB_P52", true ))
						return new FetchPath.o.TB_PermitsRelation(RelationList, Me.OrmAlias + "_TB_P52")
					end get
				end property

				

			End Class
			
			public class TB_PermitsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_PermitsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Permits","ID","TB_PermitDetails","PermitID", Me.OrmAlias, Me.OrmAlias + "_TB_P52", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_PermitsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Permits","ID","TB_PermitDetails","PermitID", Me.OrmAlias, Me.OrmAlias + "_TB_P52", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_PermitsRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_PermitDetails() as FetchPath.o.TB_PermitDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Permits","ID","TB_PermitDetails","PermitID", Me.OrmAlias, "_TB_P52", false ))
						return new FetchPath.o.TB_PermitDetailsRelation(RelationList, Me.OrmAlias + "_TB_P52")
					end get
				end property

				

			End Class
			
			public class TB_PInvoiceRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_PInvoiceRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_PInvoice","ID","TB_PInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_P54", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_PInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I53", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_PInvoiceRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_PInvoice","ID","TB_PInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_P54", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_PInvoiceRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_PInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I53", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_PInvoiceDetails() as FetchPath.o.TB_PInvoiceDetailsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_PInvoice","ID","TB_PInvoiceDetails","InvoiceID", Me.OrmAlias, "_TB_P54", false ))
						return new FetchPath.o.TB_PInvoiceDetailsRelation(RelationList, Me.OrmAlias + "_TB_P54")
					end get
				end property

				
				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_PInvoice","BLID", Me.OrmAlias, "_TB_I53", true ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I53")
					end get
				end property

				

			End Class
			
			public class TB_PInvoiceDetailsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_PInvoiceDetailsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_PInvoice","ID","TB_PInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_P54", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_PInvoiceDetailsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_PInvoiceDetailsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_PInvoice","ID","TB_PInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_P54", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_PInvoice() as FetchPath.o.TB_PInvoiceRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_PInvoice","ID","TB_PInvoiceDetails","InvoiceID", Me.OrmAlias, "_TB_P54", true ))
						return new FetchPath.o.TB_PInvoiceRelation(RelationList, Me.OrmAlias + "_TB_P54")
					end get
				end property

				

			End Class
			
			public class TB_PortsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_PortsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_PortsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_PortsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_RecivedItemsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_RecivedItemsRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_RecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_I55", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_RecivedItemsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_RecivedItemsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_RecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_I55", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Invoice() as FetchPath.o.TB_InvoiceRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_RecivedItems","InvoiceID", Me.OrmAlias, "_TB_I55", true ))
						return new FetchPath.o.TB_InvoiceRelation(RelationList, Me.OrmAlias + "_TB_I55")
					end get
				end property

				

			End Class
			
			public class TB_ReferenceRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ReferenceRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ReferenceRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ReferenceRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_ReleaseLetterSeqRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ReleaseLetterSeqRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ReleaseLetterSeqRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ReleaseLetterSeqRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_ReportCustomFieldsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_ReportCustomFieldsRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_ReportCustomFieldsRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_ReportCustomFieldsRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_SCNIDSRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_SCNIDSRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_SCNIDSRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_SCNIDSRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_SeqRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_SeqRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_SeqRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_SeqRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_SOFRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_SOFRelation
					get
						
						
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_SOF","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_V56", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_SOFRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_SOFRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_SOF","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_V56", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_Voyage() as FetchPath.o.TB_VoyageRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_SOF","VoyageID", Me.OrmAlias, "_TB_V56", true ))
						return new FetchPath.o.TB_VoyageRelation(RelationList, Me.OrmAlias + "_TB_V56")
					end get
				end property

				

			End Class
			
			public class TB_TaxBaseRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_TaxBaseRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_TaxBaseRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_TaxBaseRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_UsersRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_UsersRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Users","ID","TB_AccessLevel","UserID", Me.OrmAlias, Me.OrmAlias + "_TB_A2", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_UsersRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Users","ID","TB_AccessLevel","UserID", Me.OrmAlias, Me.OrmAlias + "_TB_A2", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_UsersRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_AccessLevel() as FetchPath.o.TB_AccessLevelRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Users","ID","TB_AccessLevel","UserID", Me.OrmAlias, "_TB_A2", false ))
						return new FetchPath.o.TB_AccessLevelRelation(RelationList, Me.OrmAlias + "_TB_A2")
					end get
				end property

				

			End Class
			
			public class TB_UsersDeptRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_UsersDeptRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_UsersDeptRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_UsersDeptRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_UsersLineRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_UsersLineRelation
					get
						
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_UsersLineRelation
					get
						
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_UsersLineRelation
					get
						
						return Me
					end get
				end property
				


			End Class
			
			public class TB_VesselsRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_VesselsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Vessels","ID","TB_Voyage","VesselID", Me.OrmAlias, Me.OrmAlias + "_TB_V57", false))
						
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_VesselsRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Vessels","ID","TB_Voyage","VesselID", Me.OrmAlias, Me.OrmAlias + "_TB_V57", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_VesselsRelation
					get
						
						return Me
					end get
				end property
				

				public ReadOnly property TB_Voyage() as FetchPath.o.TB_VoyageRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Vessels","ID","TB_Voyage","VesselID", Me.OrmAlias, "_TB_V57", false ))
						return new FetchPath.o.TB_VoyageRelation(RelationList, Me.OrmAlias + "_TB_V57")
					end get
				end property

				

			End Class
			
			public class TB_VoyageRelation : Inherits DataManagerBase.FetchPathRelation
				Friend Sub New(ByRef relationList as ArrayList, ByVal aliasName as string)
					Me.RelationList = relationList
					Me.OrmAlias = aliasName
				End Sub
			
				
				public ReadOnly property All() as TB_VoyageRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_EcsContainers","InVoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_E12", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_InwardBLS","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_I25", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_SOF","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_S56", false))
						
						RelationList.Add(new DataManagerBase.Relation("TB_Vessels","ID","TB_Voyage","VesselID", Me.OrmAlias, Me.OrmAlias + "_TB_V57", true))
						return Me
					end get
				end property
			
				public ReadOnly property AllChildren() as TB_VoyageRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_EcsContainers","InVoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_E12", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_InwardBLS","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_I25", false))
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_SOF","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_S56", false))
						return Me
					end get
				end property
			
				public ReadOnly property AllParents() as TB_VoyageRelation
					get
						
						RelationList.Add(new DataManagerBase.Relation("TB_Vessels","ID","TB_Voyage","VesselID", Me.OrmAlias, Me.OrmAlias + "_TB_V57", true))
						return Me
					end get
				end property
				

				public ReadOnly property TB_EcsContainers() as FetchPath.o.TB_EcsContainersRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_EcsContainers","InVoyageID", Me.OrmAlias, "_TB_E12", false ))
						return new FetchPath.o.TB_EcsContainersRelation(RelationList, Me.OrmAlias + "_TB_E12")
					end get
				end property

				
				public ReadOnly property TB_InwardBLS() as FetchPath.o.TB_InwardBLSRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_InwardBLS","VoyageID", Me.OrmAlias, "_TB_I25", false ))
						return new FetchPath.o.TB_InwardBLSRelation(RelationList, Me.OrmAlias + "_TB_I25")
					end get
				end property

				
				public ReadOnly property TB_SOF() as FetchPath.o.TB_SOFRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_SOF","VoyageID", Me.OrmAlias, "_TB_S56", false ))
						return new FetchPath.o.TB_SOFRelation(RelationList, Me.OrmAlias + "_TB_S56")
					end get
				end property

				
				public ReadOnly property TB_Vessels() as FetchPath.o.TB_VesselsRelation
					get
						RelationList.Add(new DataManagerBase.Relation("TB_Vessels","ID","TB_Voyage","VesselID", Me.OrmAlias, "_TB_V57", true ))
						return new FetchPath.o.TB_VesselsRelation(RelationList, Me.OrmAlias + "_TB_V57")
					end get
				end property

				

			End Class
			

		End Class
	End Class
End Namespace
		

