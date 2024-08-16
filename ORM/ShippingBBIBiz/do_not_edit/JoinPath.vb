Imports System
Imports System.Collections
Imports OrmLib

Namespace ShippingBiz
    Public Class JoinPath

        Private Sub New()
        End Sub


 
        Public Shared ReadOnly Property sysdiagrams() as JoinPath.o.sysdiagramsRelation
            Get
                return new JoinPath.o.sysdiagramsRelation(new ArrayList(), "sysdiagrams")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_AccessLevel() as JoinPath.o.TB_AccessLevelRelation
            Get
                return new JoinPath.o.TB_AccessLevelRelation(new ArrayList(), "TB_AccessLevel")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Account() as JoinPath.o.TB_AccountRelation
            Get
                return new JoinPath.o.TB_AccountRelation(new ArrayList(), "TB_Account")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Agents() as JoinPath.o.TB_AgentsRelation
            Get
                return new JoinPath.o.TB_AgentsRelation(new ArrayList(), "TB_Agents")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_AUTAdditionalDocs() as JoinPath.o.TB_AUTAdditionalDocsRelation
            Get
                return new JoinPath.o.TB_AUTAdditionalDocsRelation(new ArrayList(), "TB_AUTAdditionalDocs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_AUTDummy() as JoinPath.o.TB_AUTDummyRelation
            Get
                return new JoinPath.o.TB_AUTDummyRelation(new ArrayList(), "TB_AUTDummy")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_AUTDummyLog() as JoinPath.o.TB_AUTDummyLogRelation
            Get
                return new JoinPath.o.TB_AUTDummyLogRelation(new ArrayList(), "TB_AUTDummyLog")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_AUTJobLogs() as JoinPath.o.TB_AUTJobLogsRelation
            Get
                return new JoinPath.o.TB_AUTJobLogsRelation(new ArrayList(), "TB_AUTJobLogs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_AUTJobLogsDetail() as JoinPath.o.TB_AUTJobLogsDetailRelation
            Get
                return new JoinPath.o.TB_AUTJobLogsDetailRelation(new ArrayList(), "TB_AUTJobLogsDetail")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_AUTJobs() as JoinPath.o.TB_AUTJobsRelation
            Get
                return new JoinPath.o.TB_AUTJobsRelation(new ArrayList(), "TB_AUTJobs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_autoLog() as JoinPath.o.TB_autoLogRelation
            Get
                return new JoinPath.o.TB_autoLogRelation(new ArrayList(), "TB_autoLog")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_AUTSchedule() as JoinPath.o.TB_AUTScheduleRelation
            Get
                return new JoinPath.o.TB_AUTScheduleRelation(new ArrayList(), "TB_AUTSchedule")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_AUTSettings() as JoinPath.o.TB_AUTSettingsRelation
            Get
                return new JoinPath.o.TB_AUTSettingsRelation(new ArrayList(), "TB_AUTSettings")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Booking() as JoinPath.o.TB_BookingRelation
            Get
                return new JoinPath.o.TB_BookingRelation(new ArrayList(), "TB_Booking")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_BookingCns() as JoinPath.o.TB_BookingCnsRelation
            Get
                return new JoinPath.o.TB_BookingCnsRelation(new ArrayList(), "TB_BookingCns")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_BookingDeposits() as JoinPath.o.TB_BookingDepositsRelation
            Get
                return new JoinPath.o.TB_BookingDepositsRelation(new ArrayList(), "TB_BookingDeposits")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_BookingDetails() as JoinPath.o.TB_BookingDetailsRelation
            Get
                return new JoinPath.o.TB_BookingDetailsRelation(new ArrayList(), "TB_BookingDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_BookingReleasCntrs() as JoinPath.o.TB_BookingReleasCntrsRelation
            Get
                return new JoinPath.o.TB_BookingReleasCntrsRelation(new ArrayList(), "TB_BookingReleasCntrs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_BookingRelease() as JoinPath.o.TB_BookingReleaseRelation
            Get
                return new JoinPath.o.TB_BookingReleaseRelation(new ArrayList(), "TB_BookingRelease")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_CalculationBase() as JoinPath.o.TB_CalculationBaseRelation
            Get
                return new JoinPath.o.TB_CalculationBaseRelation(new ArrayList(), "TB_CalculationBase")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ChgLevelDetails() as JoinPath.o.TB_ChgLevelDetailsRelation
            Get
                return new JoinPath.o.TB_ChgLevelDetailsRelation(new ArrayList(), "TB_ChgLevelDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ChgLevelMaster() as JoinPath.o.TB_ChgLevelMasterRelation
            Get
                return new JoinPath.o.TB_ChgLevelMasterRelation(new ArrayList(), "TB_ChgLevelMaster")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Clients() as JoinPath.o.TB_ClientsRelation
            Get
                return new JoinPath.o.TB_ClientsRelation(new ArrayList(), "TB_Clients")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Cluses() as JoinPath.o.TB_ClusesRelation
            Get
                return new JoinPath.o.TB_ClusesRelation(new ArrayList(), "TB_Cluses")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_CODE() as JoinPath.o.TB_CODERelation
            Get
                return new JoinPath.o.TB_CODERelation(new ArrayList(), "TB_CODE")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_CodeMaster() as JoinPath.o.TB_CodeMasterRelation
            Get
                return new JoinPath.o.TB_CodeMasterRelation(new ArrayList(), "TB_CodeMaster")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Company() as JoinPath.o.TB_CompanyRelation
            Get
                return new JoinPath.o.TB_CompanyRelation(new ArrayList(), "TB_Company")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Country() as JoinPath.o.TB_CountryRelation
            Get
                return new JoinPath.o.TB_CountryRelation(new ArrayList(), "TB_Country")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_CustomMenu() as JoinPath.o.TB_CustomMenuRelation
            Get
                return new JoinPath.o.TB_CustomMenuRelation(new ArrayList(), "TB_CustomMenu")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Damage() as JoinPath.o.TB_DamageRelation
            Get
                return new JoinPath.o.TB_DamageRelation(new ArrayList(), "TB_Damage")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Deposits() as JoinPath.o.TB_DepositsRelation
            Get
                return new JoinPath.o.TB_DepositsRelation(new ArrayList(), "TB_Deposits")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_DetentionBase() as JoinPath.o.TB_DetentionBaseRelation
            Get
                return new JoinPath.o.TB_DetentionBaseRelation(new ArrayList(), "TB_DetentionBase")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_DetentionBaseDetails() as JoinPath.o.TB_DetentionBaseDetailsRelation
            Get
                return new JoinPath.o.TB_DetentionBaseDetailsRelation(new ArrayList(), "TB_DetentionBaseDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Documets() as JoinPath.o.TB_DocumetsRelation
            Get
                return new JoinPath.o.TB_DocumetsRelation(new ArrayList(), "TB_Documets")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_DocumetsDetail() as JoinPath.o.TB_DocumetsDetailRelation
            Get
                return new JoinPath.o.TB_DocumetsDetailRelation(new ArrayList(), "TB_DocumetsDetail")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_EcsContainers() as JoinPath.o.TB_EcsContainersRelation
            Get
                return new JoinPath.o.TB_EcsContainersRelation(new ArrayList(), "TB_EcsContainers")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_EcsMoves() as JoinPath.o.TB_EcsMovesRelation
            Get
                return new JoinPath.o.TB_EcsMovesRelation(new ArrayList(), "TB_EcsMoves")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_EcsReserveContainers() as JoinPath.o.TB_EcsReserveContainersRelation
            Get
                return new JoinPath.o.TB_EcsReserveContainersRelation(new ArrayList(), "TB_EcsReserveContainers")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_EventMail() as JoinPath.o.TB_EventMailRelation
            Get
                return new JoinPath.o.TB_EventMailRelation(new ArrayList(), "TB_EventMail")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Exchange() as JoinPath.o.TB_ExchangeRelation
            Get
                return new JoinPath.o.TB_ExchangeRelation(new ArrayList(), "TB_Exchange")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ExchangeDetails() as JoinPath.o.TB_ExchangeDetailsRelation
            Get
                return new JoinPath.o.TB_ExchangeDetailsRelation(new ArrayList(), "TB_ExchangeDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ExpInvoice() as JoinPath.o.TB_ExpInvoiceRelation
            Get
                return new JoinPath.o.TB_ExpInvoiceRelation(new ArrayList(), "TB_ExpInvoice")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ExpInvoiceDetails() as JoinPath.o.TB_ExpInvoiceDetailsRelation
            Get
                return new JoinPath.o.TB_ExpInvoiceDetailsRelation(new ArrayList(), "TB_ExpInvoiceDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ExpRecivedItems() as JoinPath.o.TB_ExpRecivedItemsRelation
            Get
                return new JoinPath.o.TB_ExpRecivedItemsRelation(new ArrayList(), "TB_ExpRecivedItems")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_FaxActions() as JoinPath.o.TB_FaxActionsRelation
            Get
                return new JoinPath.o.TB_FaxActionsRelation(new ArrayList(), "TB_FaxActions")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_FaxStatus() as JoinPath.o.TB_FaxStatusRelation
            Get
                return new JoinPath.o.TB_FaxStatusRelation(new ArrayList(), "TB_FaxStatus")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Inquery() as JoinPath.o.TB_InqueryRelation
            Get
                return new JoinPath.o.TB_InqueryRelation(new ArrayList(), "TB_Inquery")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InqueryDetails() as JoinPath.o.TB_InqueryDetailsRelation
            Get
                return new JoinPath.o.TB_InqueryDetailsRelation(new ArrayList(), "TB_InqueryDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Invoice() as JoinPath.o.TB_InvoiceRelation
            Get
                return new JoinPath.o.TB_InvoiceRelation(new ArrayList(), "TB_Invoice")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InvoiceDetails() as JoinPath.o.TB_InvoiceDetailsRelation
            Get
                return new JoinPath.o.TB_InvoiceDetailsRelation(new ArrayList(), "TB_InvoiceDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
                return new JoinPath.o.TB_InwardBLSRelation(new ArrayList(), "TB_InwardBLS")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardBlsComments() as JoinPath.o.TB_InwardBlsCommentsRelation
            Get
                return new JoinPath.o.TB_InwardBlsCommentsRelation(new ArrayList(), "TB_InwardBlsComments")
            End Get
        End Property 
        Public Shared ReadOnly Property Tb_InwardBlsFrs() as JoinPath.o.Tb_InwardBlsFrsRelation
            Get
                return new JoinPath.o.Tb_InwardBlsFrsRelation(new ArrayList(), "Tb_InwardBlsFrs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardBlsGoods() as JoinPath.o.TB_InwardBlsGoodsRelation
            Get
                return new JoinPath.o.TB_InwardBlsGoodsRelation(new ArrayList(), "TB_InwardBlsGoods")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardBlsNames() as JoinPath.o.TB_InwardBlsNamesRelation
            Get
                return new JoinPath.o.TB_InwardBlsNamesRelation(new ArrayList(), "TB_InwardBlsNames")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardCharges() as JoinPath.o.TB_InwardChargesRelation
            Get
                return new JoinPath.o.TB_InwardChargesRelation(new ArrayList(), "TB_InwardCharges")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardCnsImco() as JoinPath.o.TB_InwardCnsImcoRelation
            Get
                return new JoinPath.o.TB_InwardCnsImcoRelation(new ArrayList(), "TB_InwardCnsImco")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardCnsPkgs() as JoinPath.o.TB_InwardCnsPkgsRelation
            Get
                return new JoinPath.o.TB_InwardCnsPkgsRelation(new ArrayList(), "TB_InwardCnsPkgs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardCnsTemprature() as JoinPath.o.TB_InwardCnsTempratureRelation
            Get
                return new JoinPath.o.TB_InwardCnsTempratureRelation(new ArrayList(), "TB_InwardCnsTemprature")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardCntrs() as JoinPath.o.TB_InwardCntrsRelation
            Get
                return new JoinPath.o.TB_InwardCntrsRelation(new ArrayList(), "TB_InwardCntrs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardCntrsCharges() as JoinPath.o.TB_InwardCntrsChargesRelation
            Get
                return new JoinPath.o.TB_InwardCntrsChargesRelation(new ArrayList(), "TB_InwardCntrsCharges")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardDiscount() as JoinPath.o.TB_InwardDiscountRelation
            Get
                return new JoinPath.o.TB_InwardDiscountRelation(new ArrayList(), "TB_InwardDiscount")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_InwardStatus() as JoinPath.o.TB_InwardStatusRelation
            Get
                return new JoinPath.o.TB_InwardStatusRelation(new ArrayList(), "TB_InwardStatus")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ISOType() as JoinPath.o.TB_ISOTypeRelation
            Get
                return new JoinPath.o.TB_ISOTypeRelation(new ArrayList(), "TB_ISOType")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Lines() as JoinPath.o.TB_LinesRelation
            Get
                return new JoinPath.o.TB_LinesRelation(new ArrayList(), "TB_Lines")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Log() as JoinPath.o.TB_LogRelation
            Get
                return new JoinPath.o.TB_LogRelation(new ArrayList(), "TB_Log")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_LogDetails() as JoinPath.o.TB_LogDetailsRelation
            Get
                return new JoinPath.o.TB_LogDetailsRelation(new ArrayList(), "TB_LogDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_LogMaster() as JoinPath.o.TB_LogMasterRelation
            Get
                return new JoinPath.o.TB_LogMasterRelation(new ArrayList(), "TB_LogMaster")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_MenuItems() as JoinPath.o.TB_MenuItemsRelation
            Get
                return new JoinPath.o.TB_MenuItemsRelation(new ArrayList(), "TB_MenuItems")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_NOSPaymentTyps() as JoinPath.o.TB_NOSPaymentTypsRelation
            Get
                return new JoinPath.o.TB_NOSPaymentTypsRelation(new ArrayList(), "TB_NOSPaymentTyps")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Objects() as JoinPath.o.TB_ObjectsRelation
            Get
                return new JoinPath.o.TB_ObjectsRelation(new ArrayList(), "TB_Objects")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ObjectsUser() as JoinPath.o.TB_ObjectsUserRelation
            Get
                return new JoinPath.o.TB_ObjectsUserRelation(new ArrayList(), "TB_ObjectsUser")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
                return new JoinPath.o.TB_OutwardBLSRelation(new ArrayList(), "TB_OutwardBLS")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardBlsComments() as JoinPath.o.TB_OutwardBlsCommentsRelation
            Get
                return new JoinPath.o.TB_OutwardBlsCommentsRelation(new ArrayList(), "TB_OutwardBlsComments")
            End Get
        End Property 
        Public Shared ReadOnly Property Tb_OutwardBlsFrs() as JoinPath.o.Tb_OutwardBlsFrsRelation
            Get
                return new JoinPath.o.Tb_OutwardBlsFrsRelation(new ArrayList(), "Tb_OutwardBlsFrs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardBlsGoods() as JoinPath.o.TB_OutwardBlsGoodsRelation
            Get
                return new JoinPath.o.TB_OutwardBlsGoodsRelation(new ArrayList(), "TB_OutwardBlsGoods")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardBlsNames() as JoinPath.o.TB_OutwardBlsNamesRelation
            Get
                return new JoinPath.o.TB_OutwardBlsNamesRelation(new ArrayList(), "TB_OutwardBlsNames")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardBlsTemplate() as JoinPath.o.TB_OutwardBlsTemplateRelation
            Get
                return new JoinPath.o.TB_OutwardBlsTemplateRelation(new ArrayList(), "TB_OutwardBlsTemplate")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardCharges() as JoinPath.o.TB_OutwardChargesRelation
            Get
                return new JoinPath.o.TB_OutwardChargesRelation(new ArrayList(), "TB_OutwardCharges")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardCnsImco() as JoinPath.o.TB_OutwardCnsImcoRelation
            Get
                return new JoinPath.o.TB_OutwardCnsImcoRelation(new ArrayList(), "TB_OutwardCnsImco")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardCnsPkgs() as JoinPath.o.TB_OutwardCnsPkgsRelation
            Get
                return new JoinPath.o.TB_OutwardCnsPkgsRelation(new ArrayList(), "TB_OutwardCnsPkgs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardCnsTemprature() as JoinPath.o.TB_OutwardCnsTempratureRelation
            Get
                return new JoinPath.o.TB_OutwardCnsTempratureRelation(new ArrayList(), "TB_OutwardCnsTemprature")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardCntrs() as JoinPath.o.TB_OutwardCntrsRelation
            Get
                return new JoinPath.o.TB_OutwardCntrsRelation(new ArrayList(), "TB_OutwardCntrs")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardCntrsCharges() as JoinPath.o.TB_OutwardCntrsChargesRelation
            Get
                return new JoinPath.o.TB_OutwardCntrsChargesRelation(new ArrayList(), "TB_OutwardCntrsCharges")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_OutwardDiscount() as JoinPath.o.TB_OutwardDiscountRelation
            Get
                return new JoinPath.o.TB_OutwardDiscountRelation(new ArrayList(), "TB_OutwardDiscount")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_PermitDetails() as JoinPath.o.TB_PermitDetailsRelation
            Get
                return new JoinPath.o.TB_PermitDetailsRelation(new ArrayList(), "TB_PermitDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Permits() as JoinPath.o.TB_PermitsRelation
            Get
                return new JoinPath.o.TB_PermitsRelation(new ArrayList(), "TB_Permits")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_PInvoice() as JoinPath.o.TB_PInvoiceRelation
            Get
                return new JoinPath.o.TB_PInvoiceRelation(new ArrayList(), "TB_PInvoice")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_PInvoiceDetails() as JoinPath.o.TB_PInvoiceDetailsRelation
            Get
                return new JoinPath.o.TB_PInvoiceDetailsRelation(new ArrayList(), "TB_PInvoiceDetails")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Ports() as JoinPath.o.TB_PortsRelation
            Get
                return new JoinPath.o.TB_PortsRelation(new ArrayList(), "TB_Ports")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_RecivedItems() as JoinPath.o.TB_RecivedItemsRelation
            Get
                return new JoinPath.o.TB_RecivedItemsRelation(new ArrayList(), "TB_RecivedItems")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Reference() as JoinPath.o.TB_ReferenceRelation
            Get
                return new JoinPath.o.TB_ReferenceRelation(new ArrayList(), "TB_Reference")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ReleaseLetterSeq() as JoinPath.o.TB_ReleaseLetterSeqRelation
            Get
                return new JoinPath.o.TB_ReleaseLetterSeqRelation(new ArrayList(), "TB_ReleaseLetterSeq")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_ReportCustomFields() as JoinPath.o.TB_ReportCustomFieldsRelation
            Get
                return new JoinPath.o.TB_ReportCustomFieldsRelation(new ArrayList(), "TB_ReportCustomFields")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_SCNIDS() as JoinPath.o.TB_SCNIDSRelation
            Get
                return new JoinPath.o.TB_SCNIDSRelation(new ArrayList(), "TB_SCNIDS")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Seq() as JoinPath.o.TB_SeqRelation
            Get
                return new JoinPath.o.TB_SeqRelation(new ArrayList(), "TB_Seq")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_SOF() as JoinPath.o.TB_SOFRelation
            Get
                return new JoinPath.o.TB_SOFRelation(new ArrayList(), "TB_SOF")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_TaxBase() as JoinPath.o.TB_TaxBaseRelation
            Get
                return new JoinPath.o.TB_TaxBaseRelation(new ArrayList(), "TB_TaxBase")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Users() as JoinPath.o.TB_UsersRelation
            Get
                return new JoinPath.o.TB_UsersRelation(new ArrayList(), "TB_Users")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_UsersDept() as JoinPath.o.TB_UsersDeptRelation
            Get
                return new JoinPath.o.TB_UsersDeptRelation(new ArrayList(), "TB_UsersDept")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_UsersLine() as JoinPath.o.TB_UsersLineRelation
            Get
                return new JoinPath.o.TB_UsersLineRelation(new ArrayList(), "TB_UsersLine")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Vessels() as JoinPath.o.TB_VesselsRelation
            Get
                return new JoinPath.o.TB_VesselsRelation(new ArrayList(), "TB_Vessels")
            End Get
        End Property 
        Public Shared ReadOnly Property TB_Voyage() as JoinPath.o.TB_VoyageRelation
            Get
                return new JoinPath.o.TB_VoyageRelation(new ArrayList(), "TB_Voyage")
            End Get
        End Property

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>Public Class o

        Private Sub New()
        End Sub


        Public Class sysdiagramsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as sysdiagramsColumns
            Get
                return new sysdiagramsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_AccessLevelRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AccessLevelColumns
            Get
                return new TB_AccessLevelColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_MenuItems() as JoinPath.o.TB_MenuItemsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_MenuItems","ID","TB_AccessLevel","MenuItemID", Me.OrmAlias, Me.OrmAlias + "_TB_M1", true))
						return new JoinPath.o.TB_MenuItemsRelation( RelationList, Me.OrmAlias + "_TB_M1")
            End Get
        End Property
        Public ReadOnly Property TB_Users() as JoinPath.o.TB_UsersRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Users","ID","TB_AccessLevel","UserID", Me.OrmAlias, Me.OrmAlias + "_TB_U2", true))
						return new JoinPath.o.TB_UsersRelation( RelationList, Me.OrmAlias + "_TB_U2")
            End Get
        End Property

        End Class
			
        Public Class TB_AccountRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AccountColumns
            Get
                return new TB_AccountColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_AgentsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AgentsColumns
            Get
                return new TB_AgentsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_AUTAdditionalDocsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AUTAdditionalDocsColumns
            Get
                return new TB_AUTAdditionalDocsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_AUTDummyRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AUTDummyColumns
            Get
                return new TB_AUTDummyColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_AUTDummyLogRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AUTDummyLogColumns
            Get
                return new TB_AUTDummyLogColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_AUTJobLogsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AUTJobLogsColumns
            Get
                return new TB_AUTJobLogsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_AUTJobLogsDetail() as JoinPath.o.TB_AUTJobLogsDetailRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_AUTJobLogs","ID","TB_AUTJobLogsDetail","JobID", Me.OrmAlias, Me.OrmAlias + "_TB_A3", false))
						return new JoinPath.o.TB_AUTJobLogsDetailRelation( RelationList, Me.OrmAlias + "_TB_A3")
            End Get
        End Property

        End Class
			
        Public Class TB_AUTJobLogsDetailRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AUTJobLogsDetailColumns
            Get
                return new TB_AUTJobLogsDetailColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_AUTJobLogs() as JoinPath.o.TB_AUTJobLogsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_AUTJobLogs","ID","TB_AUTJobLogsDetail","JobID", Me.OrmAlias, Me.OrmAlias + "_TB_A3", true))
						return new JoinPath.o.TB_AUTJobLogsRelation( RelationList, Me.OrmAlias + "_TB_A3")
            End Get
        End Property

        End Class
			
        Public Class TB_AUTJobsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AUTJobsColumns
            Get
                return new TB_AUTJobsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_autoLogRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_autoLogColumns
            Get
                return new TB_autoLogColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_AUTScheduleRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AUTScheduleColumns
            Get
                return new TB_AUTScheduleColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_AUTSettingsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_AUTSettingsColumns
            Get
                return new TB_AUTSettingsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_BookingRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_BookingColumns
            Get
                return new TB_BookingColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_BookingCns() as JoinPath.o.TB_BookingCnsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingCns","PID", Me.OrmAlias, Me.OrmAlias + "_TB_B5", false))
						return new JoinPath.o.TB_BookingCnsRelation( RelationList, Me.OrmAlias + "_TB_B5")
            End Get
        End Property
        Public ReadOnly Property TB_BookingDetails() as JoinPath.o.TB_BookingDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingDetails","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B6", false))
						return new JoinPath.o.TB_BookingDetailsRelation( RelationList, Me.OrmAlias + "_TB_B6")
            End Get
        End Property
        Public ReadOnly Property TB_BookingRelease() as JoinPath.o.TB_BookingReleaseRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingRelease","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B8", false))
						return new JoinPath.o.TB_BookingReleaseRelation( RelationList, Me.OrmAlias + "_TB_B8")
            End Get
        End Property
        Public ReadOnly Property TB_EcsContainers() as JoinPath.o.TB_EcsContainersRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_EcsContainers","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_E11", false))
						return new JoinPath.o.TB_EcsContainersRelation( RelationList, Me.OrmAlias + "_TB_E11")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_OutwardBLS","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_O39", false))
						return new JoinPath.o.TB_OutwardBLSRelation( RelationList, Me.OrmAlias + "_TB_O39")
            End Get
        End Property
        Public ReadOnly Property TB_Clients() as JoinPath.o.TB_ClientsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_Booking","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_C4", true))
						return new JoinPath.o.TB_ClientsRelation( RelationList, Me.OrmAlias + "_TB_C4")
            End Get
        End Property

        End Class
			
        Public Class TB_BookingCnsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_BookingCnsColumns
            Get
                return new TB_BookingCnsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Booking() as JoinPath.o.TB_BookingRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingCns","PID", Me.OrmAlias, Me.OrmAlias + "_TB_B5", true))
						return new JoinPath.o.TB_BookingRelation( RelationList, Me.OrmAlias + "_TB_B5")
            End Get
        End Property

        End Class
			
        Public Class TB_BookingDepositsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_BookingDepositsColumns
            Get
                return new TB_BookingDepositsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_BookingDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_BookingDetailsColumns
            Get
                return new TB_BookingDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Booking() as JoinPath.o.TB_BookingRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingDetails","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B6", true))
						return new JoinPath.o.TB_BookingRelation( RelationList, Me.OrmAlias + "_TB_B6")
            End Get
        End Property

        End Class
			
        Public Class TB_BookingReleasCntrsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_BookingReleasCntrsColumns
            Get
                return new TB_BookingReleasCntrsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_BookingRelease() as JoinPath.o.TB_BookingReleaseRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_BookingRelease","ID","TB_BookingReleasCntrs","ReleaseID", Me.OrmAlias, Me.OrmAlias + "_TB_B7", true))
						return new JoinPath.o.TB_BookingReleaseRelation( RelationList, Me.OrmAlias + "_TB_B7")
            End Get
        End Property

        End Class
			
        Public Class TB_BookingReleaseRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_BookingReleaseColumns
            Get
                return new TB_BookingReleaseColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_BookingReleasCntrs() as JoinPath.o.TB_BookingReleasCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_BookingRelease","ID","TB_BookingReleasCntrs","ReleaseID", Me.OrmAlias, Me.OrmAlias + "_TB_B7", false))
						return new JoinPath.o.TB_BookingReleasCntrsRelation( RelationList, Me.OrmAlias + "_TB_B7")
            End Get
        End Property
        Public ReadOnly Property TB_Booking() as JoinPath.o.TB_BookingRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_BookingRelease","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B8", true))
						return new JoinPath.o.TB_BookingRelation( RelationList, Me.OrmAlias + "_TB_B8")
            End Get
        End Property

        End Class
			
        Public Class TB_CalculationBaseRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_CalculationBaseColumns
            Get
                return new TB_CalculationBaseColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_ChgLevelDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ChgLevelDetailsColumns
            Get
                return new TB_ChgLevelDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_ChgLevelMaster() as JoinPath.o.TB_ChgLevelMasterRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_ChgLevelMaster","ID","TB_ChgLevelDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_C9", true))
						return new JoinPath.o.TB_ChgLevelMasterRelation( RelationList, Me.OrmAlias + "_TB_C9")
            End Get
        End Property

        End Class
			
        Public Class TB_ChgLevelMasterRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ChgLevelMasterColumns
            Get
                return new TB_ChgLevelMasterColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_ChgLevelDetails() as JoinPath.o.TB_ChgLevelDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_ChgLevelMaster","ID","TB_ChgLevelDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_C9", false))
						return new JoinPath.o.TB_ChgLevelDetailsRelation( RelationList, Me.OrmAlias + "_TB_C9")
            End Get
        End Property

        End Class
			
        Public Class TB_ClientsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ClientsColumns
            Get
                return new TB_ClientsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Booking() as JoinPath.o.TB_BookingRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_Booking","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_B4", false))
						return new JoinPath.o.TB_BookingRelation( RelationList, Me.OrmAlias + "_TB_B4")
            End Get
        End Property
        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_InwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_I24", false))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I24")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_OutwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_O40", false))
						return new JoinPath.o.TB_OutwardBLSRelation( RelationList, Me.OrmAlias + "_TB_O40")
            End Get
        End Property

        End Class
			
        Public Class TB_ClusesRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ClusesColumns
            Get
                return new TB_ClusesColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_CODERelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_CODEColumns
            Get
                return new TB_CODEColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_CodeMaster() as JoinPath.o.TB_CodeMasterRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_CodeMaster","GroupCode","TB_CODE","GroupCode", Me.OrmAlias, Me.OrmAlias + "_TB_C10", true))
						return new JoinPath.o.TB_CodeMasterRelation( RelationList, Me.OrmAlias + "_TB_C10")
            End Get
        End Property

        End Class
			
        Public Class TB_CodeMasterRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_CodeMasterColumns
            Get
                return new TB_CodeMasterColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_CODE() as JoinPath.o.TB_CODERelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_CodeMaster","GroupCode","TB_CODE","GroupCode", Me.OrmAlias, Me.OrmAlias + "_TB_C10", false))
						return new JoinPath.o.TB_CODERelation( RelationList, Me.OrmAlias + "_TB_C10")
            End Get
        End Property

        End Class
			
        Public Class TB_CompanyRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_CompanyColumns
            Get
                return new TB_CompanyColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_CountryRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_CountryColumns
            Get
                return new TB_CountryColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_CustomMenuRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_CustomMenuColumns
            Get
                return new TB_CustomMenuColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_DamageRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_DamageColumns
            Get
                return new TB_DamageColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_EcsContainers() as JoinPath.o.TB_EcsContainersRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_Damage","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E13", true))
						return new JoinPath.o.TB_EcsContainersRelation( RelationList, Me.OrmAlias + "_TB_E13")
            End Get
        End Property

        End Class
			
        Public Class TB_DepositsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_DepositsColumns
            Get
                return new TB_DepositsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_DetentionBaseRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_DetentionBaseColumns
            Get
                return new TB_DetentionBaseColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_DetentionBaseDetails() as JoinPath.o.TB_DetentionBaseDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_DetentionBase","ID","TB_DetentionBaseDetails","BaseID", Me.OrmAlias, Me.OrmAlias + "_TB_D14", false))
						return new JoinPath.o.TB_DetentionBaseDetailsRelation( RelationList, Me.OrmAlias + "_TB_D14")
            End Get
        End Property

        End Class
			
        Public Class TB_DetentionBaseDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_DetentionBaseDetailsColumns
            Get
                return new TB_DetentionBaseDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_DetentionBase() as JoinPath.o.TB_DetentionBaseRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_DetentionBase","ID","TB_DetentionBaseDetails","BaseID", Me.OrmAlias, Me.OrmAlias + "_TB_D14", true))
						return new JoinPath.o.TB_DetentionBaseRelation( RelationList, Me.OrmAlias + "_TB_D14")
            End Get
        End Property

        End Class
			
        Public Class TB_DocumetsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_DocumetsColumns
            Get
                return new TB_DocumetsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_DocumetsDetail() as JoinPath.o.TB_DocumetsDetailRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Documets","ID","TB_DocumetsDetail","DocumentID", Me.OrmAlias, Me.OrmAlias + "_TB_D15", false))
						return new JoinPath.o.TB_DocumetsDetailRelation( RelationList, Me.OrmAlias + "_TB_D15")
            End Get
        End Property

        End Class
			
        Public Class TB_DocumetsDetailRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_DocumetsDetailColumns
            Get
                return new TB_DocumetsDetailColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Documets() as JoinPath.o.TB_DocumetsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Documets","ID","TB_DocumetsDetail","DocumentID", Me.OrmAlias, Me.OrmAlias + "_TB_D15", true))
						return new JoinPath.o.TB_DocumetsRelation( RelationList, Me.OrmAlias + "_TB_D15")
            End Get
        End Property

        End Class
			
        Public Class TB_EcsContainersRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_EcsContainersColumns
            Get
                return new TB_EcsContainersColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Damage() as JoinPath.o.TB_DamageRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_Damage","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_D13", false))
						return new JoinPath.o.TB_DamageRelation( RelationList, Me.OrmAlias + "_TB_D13")
            End Get
        End Property
        Public ReadOnly Property TB_EcsMoves() as JoinPath.o.TB_EcsMovesRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_EcsMoves","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E16", false))
						return new JoinPath.o.TB_EcsMovesRelation( RelationList, Me.OrmAlias + "_TB_E16")
            End Get
        End Property
        Public ReadOnly Property TB_PermitDetails() as JoinPath.o.TB_PermitDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_PermitDetails","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_P51", false))
						return new JoinPath.o.TB_PermitDetailsRelation( RelationList, Me.OrmAlias + "_TB_P51")
            End Get
        End Property
        Public ReadOnly Property TB_Booking() as JoinPath.o.TB_BookingRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_EcsContainers","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B11", true))
						return new JoinPath.o.TB_BookingRelation( RelationList, Me.OrmAlias + "_TB_B11")
            End Get
        End Property
        Public ReadOnly Property TB_Voyage() as JoinPath.o.TB_VoyageRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_EcsContainers","InVoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_V12", true))
						return new JoinPath.o.TB_VoyageRelation( RelationList, Me.OrmAlias + "_TB_V12")
            End Get
        End Property

        End Class
			
        Public Class TB_EcsMovesRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_EcsMovesColumns
            Get
                return new TB_EcsMovesColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_EcsContainers() as JoinPath.o.TB_EcsContainersRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_EcsMoves","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E16", true))
						return new JoinPath.o.TB_EcsContainersRelation( RelationList, Me.OrmAlias + "_TB_E16")
            End Get
        End Property

        End Class
			
        Public Class TB_EcsReserveContainersRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_EcsReserveContainersColumns
            Get
                return new TB_EcsReserveContainersColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_EventMailRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_EventMailColumns
            Get
                return new TB_EventMailColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_ExchangeRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ExchangeColumns
            Get
                return new TB_ExchangeColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_ExchangeDetails() as JoinPath.o.TB_ExchangeDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Exchange","ID","TB_ExchangeDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_E17", false))
						return new JoinPath.o.TB_ExchangeDetailsRelation( RelationList, Me.OrmAlias + "_TB_E17")
            End Get
        End Property

        End Class
			
        Public Class TB_ExchangeDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ExchangeDetailsColumns
            Get
                return new TB_ExchangeDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Exchange() as JoinPath.o.TB_ExchangeRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Exchange","ID","TB_ExchangeDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_E17", true))
						return new JoinPath.o.TB_ExchangeRelation( RelationList, Me.OrmAlias + "_TB_E17")
            End Get
        End Property

        End Class
			
        Public Class TB_ExpInvoiceRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ExpInvoiceColumns
            Get
                return new TB_ExpInvoiceColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_ExpInvoiceDetails() as JoinPath.o.TB_ExpInvoiceDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E19", false))
						return new JoinPath.o.TB_ExpInvoiceDetailsRelation( RelationList, Me.OrmAlias + "_TB_E19")
            End Get
        End Property
        Public ReadOnly Property TB_ExpRecivedItems() as JoinPath.o.TB_ExpRecivedItemsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpRecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E20", false))
						return new JoinPath.o.TB_ExpRecivedItemsRelation( RelationList, Me.OrmAlias + "_TB_E20")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_ExpInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O18", true))
						return new JoinPath.o.TB_OutwardBLSRelation( RelationList, Me.OrmAlias + "_TB_O18")
            End Get
        End Property

        End Class
			
        Public Class TB_ExpInvoiceDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ExpInvoiceDetailsColumns
            Get
                return new TB_ExpInvoiceDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_ExpInvoice() as JoinPath.o.TB_ExpInvoiceRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E19", true))
						return new JoinPath.o.TB_ExpInvoiceRelation( RelationList, Me.OrmAlias + "_TB_E19")
            End Get
        End Property

        End Class
			
        Public Class TB_ExpRecivedItemsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ExpRecivedItemsColumns
            Get
                return new TB_ExpRecivedItemsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_ExpInvoice() as JoinPath.o.TB_ExpInvoiceRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_ExpInvoice","ID","TB_ExpRecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_E20", true))
						return new JoinPath.o.TB_ExpInvoiceRelation( RelationList, Me.OrmAlias + "_TB_E20")
            End Get
        End Property

        End Class
			
        Public Class TB_FaxActionsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_FaxActionsColumns
            Get
                return new TB_FaxActionsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_FaxStatusRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_FaxStatusColumns
            Get
                return new TB_FaxStatusColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_InqueryRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InqueryColumns
            Get
                return new TB_InqueryColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InqueryDetails() as JoinPath.o.TB_InqueryDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Inquery","ID","TB_InqueryDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_I21", false))
						return new JoinPath.o.TB_InqueryDetailsRelation( RelationList, Me.OrmAlias + "_TB_I21")
            End Get
        End Property

        End Class
			
        Public Class TB_InqueryDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InqueryDetailsColumns
            Get
                return new TB_InqueryDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Inquery() as JoinPath.o.TB_InqueryRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Inquery","ID","TB_InqueryDetails","MasterID", Me.OrmAlias, Me.OrmAlias + "_TB_I21", true))
						return new JoinPath.o.TB_InqueryRelation( RelationList, Me.OrmAlias + "_TB_I21")
            End Get
        End Property

        End Class
			
        Public Class TB_InvoiceRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InvoiceColumns
            Get
                return new TB_InvoiceColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InvoiceDetails() as JoinPath.o.TB_InvoiceDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_InvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_I23", false))
						return new JoinPath.o.TB_InvoiceDetailsRelation( RelationList, Me.OrmAlias + "_TB_I23")
            End Get
        End Property
        Public ReadOnly Property TB_RecivedItems() as JoinPath.o.TB_RecivedItemsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_RecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_R55", false))
						return new JoinPath.o.TB_RecivedItemsRelation( RelationList, Me.OrmAlias + "_TB_R55")
            End Get
        End Property
        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_Invoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I22", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I22")
            End Get
        End Property

        End Class
			
        Public Class TB_InvoiceDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InvoiceDetailsColumns
            Get
                return new TB_InvoiceDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Invoice() as JoinPath.o.TB_InvoiceRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_InvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_I23", true))
						return new JoinPath.o.TB_InvoiceRelation( RelationList, Me.OrmAlias + "_TB_I23")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardBLSRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardBLSColumns
            Get
                return new TB_InwardBLSColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Invoice() as JoinPath.o.TB_InvoiceRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_Invoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I22", false))
						return new JoinPath.o.TB_InvoiceRelation( RelationList, Me.OrmAlias + "_TB_I22")
            End Get
        End Property
        Public ReadOnly Property TB_InwardBlsComments() as JoinPath.o.TB_InwardBlsCommentsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsComments","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I26", false))
						return new JoinPath.o.TB_InwardBlsCommentsRelation( RelationList, Me.OrmAlias + "_TB_I26")
            End Get
        End Property
        Public ReadOnly Property Tb_InwardBlsFrs() as JoinPath.o.Tb_InwardBlsFrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","Tb_InwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_Tb_I27", false))
						return new JoinPath.o.Tb_InwardBlsFrsRelation( RelationList, Me.OrmAlias + "_Tb_I27")
            End Get
        End Property
        Public ReadOnly Property TB_InwardBlsGoods() as JoinPath.o.TB_InwardBlsGoodsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I28", false))
						return new JoinPath.o.TB_InwardBlsGoodsRelation( RelationList, Me.OrmAlias + "_TB_I28")
            End Get
        End Property
        Public ReadOnly Property TB_InwardBlsNames() as JoinPath.o.TB_InwardBlsNamesRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I29", false))
						return new JoinPath.o.TB_InwardBlsNamesRelation( RelationList, Me.OrmAlias + "_TB_I29")
            End Get
        End Property
        Public ReadOnly Property TB_InwardCharges() as JoinPath.o.TB_InwardChargesRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I30", false))
						return new JoinPath.o.TB_InwardChargesRelation( RelationList, Me.OrmAlias + "_TB_I30")
            End Get
        End Property
        Public ReadOnly Property TB_InwardCntrs() as JoinPath.o.TB_InwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I34", false))
						return new JoinPath.o.TB_InwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_I34")
            End Get
        End Property
        Public ReadOnly Property TB_InwardDiscount() as JoinPath.o.TB_InwardDiscountRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I36", false))
						return new JoinPath.o.TB_InwardDiscountRelation( RelationList, Me.OrmAlias + "_TB_I36")
            End Get
        End Property
        Public ReadOnly Property TB_InwardStatus() as JoinPath.o.TB_InwardStatusRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardStatus","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I37", false))
						return new JoinPath.o.TB_InwardStatusRelation( RelationList, Me.OrmAlias + "_TB_I37")
            End Get
        End Property
        Public ReadOnly Property TB_PInvoice() as JoinPath.o.TB_PInvoiceRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_PInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_P53", false))
						return new JoinPath.o.TB_PInvoiceRelation( RelationList, Me.OrmAlias + "_TB_P53")
            End Get
        End Property
        Public ReadOnly Property TB_Clients() as JoinPath.o.TB_ClientsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_InwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_C24", true))
						return new JoinPath.o.TB_ClientsRelation( RelationList, Me.OrmAlias + "_TB_C24")
            End Get
        End Property
        Public ReadOnly Property TB_Voyage() as JoinPath.o.TB_VoyageRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_InwardBLS","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_V25", true))
						return new JoinPath.o.TB_VoyageRelation( RelationList, Me.OrmAlias + "_TB_V25")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardBlsCommentsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardBlsCommentsColumns
            Get
                return new TB_InwardBlsCommentsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsComments","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I26", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I26")
            End Get
        End Property

        End Class
			
        Public Class Tb_InwardBlsFrsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as Tb_InwardBlsFrsColumns
            Get
                return new Tb_InwardBlsFrsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","Tb_InwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I27", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I27")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardBlsGoodsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardBlsGoodsColumns
            Get
                return new TB_InwardBlsGoodsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I28", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I28")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardBlsNamesRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardBlsNamesColumns
            Get
                return new TB_InwardBlsNamesColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I29", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I29")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardChargesRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardChargesColumns
            Get
                return new TB_InwardChargesColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I30", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I30")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardCnsImcoRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardCnsImcoColumns
            Get
                return new TB_InwardCnsImcoColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardCntrs() as JoinPath.o.TB_InwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I31", true))
						return new JoinPath.o.TB_InwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_I31")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardCnsPkgsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardCnsPkgsColumns
            Get
                return new TB_InwardCnsPkgsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardCntrs() as JoinPath.o.TB_InwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I32", true))
						return new JoinPath.o.TB_InwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_I32")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardCnsTempratureRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardCnsTempratureColumns
            Get
                return new TB_InwardCnsTempratureColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardCntrs() as JoinPath.o.TB_InwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I33", true))
						return new JoinPath.o.TB_InwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_I33")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardCntrsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardCntrsColumns
            Get
                return new TB_InwardCntrsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardCnsImco() as JoinPath.o.TB_InwardCnsImcoRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I31", false))
						return new JoinPath.o.TB_InwardCnsImcoRelation( RelationList, Me.OrmAlias + "_TB_I31")
            End Get
        End Property
        Public ReadOnly Property TB_InwardCnsPkgs() as JoinPath.o.TB_InwardCnsPkgsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I32", false))
						return new JoinPath.o.TB_InwardCnsPkgsRelation( RelationList, Me.OrmAlias + "_TB_I32")
            End Get
        End Property
        Public ReadOnly Property TB_InwardCnsTemprature() as JoinPath.o.TB_InwardCnsTempratureRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I33", false))
						return new JoinPath.o.TB_InwardCnsTempratureRelation( RelationList, Me.OrmAlias + "_TB_I33")
            End Get
        End Property
        Public ReadOnly Property TB_InwardCntrsCharges() as JoinPath.o.TB_InwardCntrsChargesRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I35", false))
						return new JoinPath.o.TB_InwardCntrsChargesRelation( RelationList, Me.OrmAlias + "_TB_I35")
            End Get
        End Property
        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I34", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I34")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardCntrsChargesRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardCntrsChargesColumns
            Get
                return new TB_InwardCntrsChargesColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardCntrs() as JoinPath.o.TB_InwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardCntrs","ID","TB_InwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_I35", true))
						return new JoinPath.o.TB_InwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_I35")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardDiscountRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardDiscountColumns
            Get
                return new TB_InwardDiscountColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I36", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I36")
            End Get
        End Property

        End Class
			
        Public Class TB_InwardStatusRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_InwardStatusColumns
            Get
                return new TB_InwardStatusColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_InwardStatus","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I37", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I37")
            End Get
        End Property

        End Class
			
        Public Class TB_ISOTypeRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ISOTypeColumns
            Get
                return new TB_ISOTypeColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_LinesRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_LinesColumns
            Get
                return new TB_LinesColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_LogRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_LogColumns
            Get
                return new TB_LogColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_LogDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_LogDetailsColumns
            Get
                return new TB_LogDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_LogMaster() as JoinPath.o.TB_LogMasterRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_LogMaster","ID","TB_LogDetails","LogID", Me.OrmAlias, Me.OrmAlias + "_TB_L38", true))
						return new JoinPath.o.TB_LogMasterRelation( RelationList, Me.OrmAlias + "_TB_L38")
            End Get
        End Property

        End Class
			
        Public Class TB_LogMasterRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_LogMasterColumns
            Get
                return new TB_LogMasterColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_LogDetails() as JoinPath.o.TB_LogDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_LogMaster","ID","TB_LogDetails","LogID", Me.OrmAlias, Me.OrmAlias + "_TB_L38", false))
						return new JoinPath.o.TB_LogDetailsRelation( RelationList, Me.OrmAlias + "_TB_L38")
            End Get
        End Property

        End Class
			
        Public Class TB_MenuItemsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_MenuItemsColumns
            Get
                return new TB_MenuItemsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_AccessLevel() as JoinPath.o.TB_AccessLevelRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_MenuItems","ID","TB_AccessLevel","MenuItemID", Me.OrmAlias, Me.OrmAlias + "_TB_A1", false))
						return new JoinPath.o.TB_AccessLevelRelation( RelationList, Me.OrmAlias + "_TB_A1")
            End Get
        End Property

        End Class
			
        Public Class TB_NOSPaymentTypsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_NOSPaymentTypsColumns
            Get
                return new TB_NOSPaymentTypsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_ObjectsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ObjectsColumns
            Get
                return new TB_ObjectsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_ObjectsUserRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ObjectsUserColumns
            Get
                return new TB_ObjectsUserColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_OutwardBLSRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardBLSColumns
            Get
                return new TB_OutwardBLSColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_ExpInvoice() as JoinPath.o.TB_ExpInvoiceRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_ExpInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_E18", false))
						return new JoinPath.o.TB_ExpInvoiceRelation( RelationList, Me.OrmAlias + "_TB_E18")
            End Get
        End Property
        Public ReadOnly Property Tb_OutwardBlsFrs() as JoinPath.o.Tb_OutwardBlsFrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","Tb_OutwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_Tb_O41", false))
						return new JoinPath.o.Tb_OutwardBlsFrsRelation( RelationList, Me.OrmAlias + "_Tb_O41")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardBlsGoods() as JoinPath.o.TB_OutwardBlsGoodsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O42", false))
						return new JoinPath.o.TB_OutwardBlsGoodsRelation( RelationList, Me.OrmAlias + "_TB_O42")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardBlsNames() as JoinPath.o.TB_OutwardBlsNamesRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O43", false))
						return new JoinPath.o.TB_OutwardBlsNamesRelation( RelationList, Me.OrmAlias + "_TB_O43")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardCharges() as JoinPath.o.TB_OutwardChargesRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O44", false))
						return new JoinPath.o.TB_OutwardChargesRelation( RelationList, Me.OrmAlias + "_TB_O44")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardCntrs() as JoinPath.o.TB_OutwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O48", false))
						return new JoinPath.o.TB_OutwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_O48")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardDiscount() as JoinPath.o.TB_OutwardDiscountRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O50", false))
						return new JoinPath.o.TB_OutwardDiscountRelation( RelationList, Me.OrmAlias + "_TB_O50")
            End Get
        End Property
        Public ReadOnly Property TB_Booking() as JoinPath.o.TB_BookingRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Booking","ID","TB_OutwardBLS","BookingID", Me.OrmAlias, Me.OrmAlias + "_TB_B39", true))
						return new JoinPath.o.TB_BookingRelation( RelationList, Me.OrmAlias + "_TB_B39")
            End Get
        End Property
        Public ReadOnly Property TB_Clients() as JoinPath.o.TB_ClientsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Clients","ID","TB_OutwardBLS","ClientID", Me.OrmAlias, Me.OrmAlias + "_TB_C40", true))
						return new JoinPath.o.TB_ClientsRelation( RelationList, Me.OrmAlias + "_TB_C40")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardBlsCommentsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardBlsCommentsColumns
            Get
                return new TB_OutwardBlsCommentsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class Tb_OutwardBlsFrsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as Tb_OutwardBlsFrsColumns
            Get
                return new Tb_OutwardBlsFrsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","Tb_OutwardBlsFrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O41", true))
						return new JoinPath.o.TB_OutwardBLSRelation( RelationList, Me.OrmAlias + "_TB_O41")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardBlsGoodsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardBlsGoodsColumns
            Get
                return new TB_OutwardBlsGoodsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsGoods","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O42", true))
						return new JoinPath.o.TB_OutwardBLSRelation( RelationList, Me.OrmAlias + "_TB_O42")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardBlsNamesRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardBlsNamesColumns
            Get
                return new TB_OutwardBlsNamesColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardBlsNames","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O43", true))
						return new JoinPath.o.TB_OutwardBLSRelation( RelationList, Me.OrmAlias + "_TB_O43")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardBlsTemplateRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardBlsTemplateColumns
            Get
                return new TB_OutwardBlsTemplateColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_OutwardChargesRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardChargesColumns
            Get
                return new TB_OutwardChargesColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCharges","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O44", true))
						return new JoinPath.o.TB_OutwardBLSRelation( RelationList, Me.OrmAlias + "_TB_O44")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardCnsImcoRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardCnsImcoColumns
            Get
                return new TB_OutwardCnsImcoColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardCntrs() as JoinPath.o.TB_OutwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O45", true))
						return new JoinPath.o.TB_OutwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_O45")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardCnsPkgsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardCnsPkgsColumns
            Get
                return new TB_OutwardCnsPkgsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardCntrs() as JoinPath.o.TB_OutwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O46", true))
						return new JoinPath.o.TB_OutwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_O46")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardCnsTempratureRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardCnsTempratureColumns
            Get
                return new TB_OutwardCnsTempratureColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardCntrs() as JoinPath.o.TB_OutwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O47", true))
						return new JoinPath.o.TB_OutwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_O47")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardCntrsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardCntrsColumns
            Get
                return new TB_OutwardCntrsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardCnsImco() as JoinPath.o.TB_OutwardCnsImcoRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsImco","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O45", false))
						return new JoinPath.o.TB_OutwardCnsImcoRelation( RelationList, Me.OrmAlias + "_TB_O45")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardCnsPkgs() as JoinPath.o.TB_OutwardCnsPkgsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsPkgs","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O46", false))
						return new JoinPath.o.TB_OutwardCnsPkgsRelation( RelationList, Me.OrmAlias + "_TB_O46")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardCnsTemprature() as JoinPath.o.TB_OutwardCnsTempratureRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCnsTemprature","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O47", false))
						return new JoinPath.o.TB_OutwardCnsTempratureRelation( RelationList, Me.OrmAlias + "_TB_O47")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardCntrsCharges() as JoinPath.o.TB_OutwardCntrsChargesRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O49", false))
						return new JoinPath.o.TB_OutwardCntrsChargesRelation( RelationList, Me.OrmAlias + "_TB_O49")
            End Get
        End Property
        Public ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardCntrs","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O48", true))
						return new JoinPath.o.TB_OutwardBLSRelation( RelationList, Me.OrmAlias + "_TB_O48")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardCntrsChargesRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardCntrsChargesColumns
            Get
                return new TB_OutwardCntrsChargesColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardCntrs() as JoinPath.o.TB_OutwardCntrsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardCntrs","ID","TB_OutwardCntrsCharges","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_O49", true))
						return new JoinPath.o.TB_OutwardCntrsRelation( RelationList, Me.OrmAlias + "_TB_O49")
            End Get
        End Property

        End Class
			
        Public Class TB_OutwardDiscountRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_OutwardDiscountColumns
            Get
                return new TB_OutwardDiscountColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_OutwardBLS() as JoinPath.o.TB_OutwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_OutwardBLS","ID","TB_OutwardDiscount","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_O50", true))
						return new JoinPath.o.TB_OutwardBLSRelation( RelationList, Me.OrmAlias + "_TB_O50")
            End Get
        End Property

        End Class
			
        Public Class TB_PermitDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_PermitDetailsColumns
            Get
                return new TB_PermitDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_EcsContainers() as JoinPath.o.TB_EcsContainersRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_EcsContainers","ID","TB_PermitDetails","CntrID", Me.OrmAlias, Me.OrmAlias + "_TB_E51", true))
						return new JoinPath.o.TB_EcsContainersRelation( RelationList, Me.OrmAlias + "_TB_E51")
            End Get
        End Property
        Public ReadOnly Property TB_Permits() as JoinPath.o.TB_PermitsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Permits","ID","TB_PermitDetails","PermitID", Me.OrmAlias, Me.OrmAlias + "_TB_P52", true))
						return new JoinPath.o.TB_PermitsRelation( RelationList, Me.OrmAlias + "_TB_P52")
            End Get
        End Property

        End Class
			
        Public Class TB_PermitsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_PermitsColumns
            Get
                return new TB_PermitsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_PermitDetails() as JoinPath.o.TB_PermitDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Permits","ID","TB_PermitDetails","PermitID", Me.OrmAlias, Me.OrmAlias + "_TB_P52", false))
						return new JoinPath.o.TB_PermitDetailsRelation( RelationList, Me.OrmAlias + "_TB_P52")
            End Get
        End Property

        End Class
			
        Public Class TB_PInvoiceRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_PInvoiceColumns
            Get
                return new TB_PInvoiceColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_PInvoiceDetails() as JoinPath.o.TB_PInvoiceDetailsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_PInvoice","ID","TB_PInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_P54", false))
						return new JoinPath.o.TB_PInvoiceDetailsRelation( RelationList, Me.OrmAlias + "_TB_P54")
            End Get
        End Property
        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_InwardBLS","ID","TB_PInvoice","BLID", Me.OrmAlias, Me.OrmAlias + "_TB_I53", true))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I53")
            End Get
        End Property

        End Class
			
        Public Class TB_PInvoiceDetailsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_PInvoiceDetailsColumns
            Get
                return new TB_PInvoiceDetailsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_PInvoice() as JoinPath.o.TB_PInvoiceRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_PInvoice","ID","TB_PInvoiceDetails","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_P54", true))
						return new JoinPath.o.TB_PInvoiceRelation( RelationList, Me.OrmAlias + "_TB_P54")
            End Get
        End Property

        End Class
			
        Public Class TB_PortsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_PortsColumns
            Get
                return new TB_PortsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_RecivedItemsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_RecivedItemsColumns
            Get
                return new TB_RecivedItemsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Invoice() as JoinPath.o.TB_InvoiceRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Invoice","ID","TB_RecivedItems","InvoiceID", Me.OrmAlias, Me.OrmAlias + "_TB_I55", true))
						return new JoinPath.o.TB_InvoiceRelation( RelationList, Me.OrmAlias + "_TB_I55")
            End Get
        End Property

        End Class
			
        Public Class TB_ReferenceRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ReferenceColumns
            Get
                return new TB_ReferenceColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_ReleaseLetterSeqRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ReleaseLetterSeqColumns
            Get
                return new TB_ReleaseLetterSeqColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_ReportCustomFieldsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_ReportCustomFieldsColumns
            Get
                return new TB_ReportCustomFieldsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_SCNIDSRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_SCNIDSColumns
            Get
                return new TB_SCNIDSColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_SeqRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_SeqColumns
            Get
                return new TB_SeqColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_SOFRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_SOFColumns
            Get
                return new TB_SOFColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Voyage() as JoinPath.o.TB_VoyageRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_SOF","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_V56", true))
						return new JoinPath.o.TB_VoyageRelation( RelationList, Me.OrmAlias + "_TB_V56")
            End Get
        End Property

        End Class
			
        Public Class TB_TaxBaseRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_TaxBaseColumns
            Get
                return new TB_TaxBaseColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_UsersRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_UsersColumns
            Get
                return new TB_UsersColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_AccessLevel() as JoinPath.o.TB_AccessLevelRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Users","ID","TB_AccessLevel","UserID", Me.OrmAlias, Me.OrmAlias + "_TB_A2", false))
						return new JoinPath.o.TB_AccessLevelRelation( RelationList, Me.OrmAlias + "_TB_A2")
            End Get
        End Property

        End Class
			
        Public Class TB_UsersDeptRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_UsersDeptColumns
            Get
                return new TB_UsersDeptColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_UsersLineRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_UsersLineColumns
            Get
                return new TB_UsersLineColumns(RelationList, Me.OrmAlias)
            End Get
        End Property



        End Class
			
        Public Class TB_VesselsRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_VesselsColumns
            Get
                return new TB_VesselsColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_Voyage() as JoinPath.o.TB_VoyageRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Vessels","ID","TB_Voyage","VesselID", Me.OrmAlias, Me.OrmAlias + "_TB_V57", false))
						return new JoinPath.o.TB_VoyageRelation( RelationList, Me.OrmAlias + "_TB_V57")
            End Get
        End Property

        End Class
			
        Public Class TB_VoyageRelation : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub

        Public ReadOnly Property Columns() as TB_VoyageColumns
            Get
                return new TB_VoyageColumns(RelationList, Me.OrmAlias)
            End Get
        End Property


        Public ReadOnly Property TB_EcsContainers() as JoinPath.o.TB_EcsContainersRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_EcsContainers","InVoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_E12", false))
						return new JoinPath.o.TB_EcsContainersRelation( RelationList, Me.OrmAlias + "_TB_E12")
            End Get
        End Property
        Public ReadOnly Property TB_InwardBLS() as JoinPath.o.TB_InwardBLSRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_InwardBLS","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_I25", false))
						return new JoinPath.o.TB_InwardBLSRelation( RelationList, Me.OrmAlias + "_TB_I25")
            End Get
        End Property
        Public ReadOnly Property TB_SOF() as JoinPath.o.TB_SOFRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Voyage","ID","TB_SOF","VoyageID", Me.OrmAlias, Me.OrmAlias + "_TB_S56", false))
						return new JoinPath.o.TB_SOFRelation( RelationList, Me.OrmAlias + "_TB_S56")
            End Get
        End Property
        Public ReadOnly Property TB_Vessels() as JoinPath.o.TB_VesselsRelation
            Get
						RelationList.Add(new DataManagerBase.Relation("TB_Vessels","ID","TB_Voyage","VesselID", Me.OrmAlias, Me.OrmAlias + "_TB_V57", true))
						return new JoinPath.o.TB_VesselsRelation( RelationList, Me.OrmAlias + "_TB_V57")
            End Get
        End Property

        End Class
			


       Public Class sysdiagramsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property name() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("sysdiagrams", "name", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property principal_id() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("sysdiagrams", "principal_id", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property diagram_id() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("sysdiagrams", "diagram_id", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property version() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("sysdiagrams", "version", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property definition() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("sysdiagrams", "definition", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AccessLevelColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AccessLevel", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UserID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AccessLevel", "UserID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MenuItemID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AccessLevel", "MenuItemID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Accessble() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AccessLevel", "Accessble", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AccountColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Account", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Account", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargeCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Account", "ChargeCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Level1() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Account", "Level1", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Level2() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Account", "Level2", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Level3() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Account", "Level3", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Account", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Port() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Account", "Port", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Level4() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Account", "Level4", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AgentsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Agents", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Agents", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Port() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Agents", "Port", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property AgentName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Agents", "AgentName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Address() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Agents", "Address", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Tel() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Agents", "Tel", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Fax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Agents", "Fax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Code() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Agents", "Code", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DetentionClause() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Agents", "DetentionClause", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AUTAdditionalDocsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTAdditionalDocs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTAdditionalDocs", "JobCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTAdditionalDocs", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property HtmlContent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTAdditionalDocs", "HtmlContent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AUTDummyColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "JobCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RequestBy() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "RequestBy", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Result() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "Result", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ErrMsg() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "ErrMsg", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VoyageID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "VoyageID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Port() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "Port", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Priority() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "Priority", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsResend() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "IsResend", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DateTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "DateTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LogID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummy", "LogID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AUTDummyLogColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummyLog", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BlNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummyLog", "BlNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummyLog", "JobCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PropertyError() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTDummyLog", "Error", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AUTJobLogsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "JobCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RequestBy() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "RequestBy", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CreateTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "CreateTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FinishedTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "FinishedTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CancelJob() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "CancelJob", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Port() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "Port", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VoyageID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "VoyageID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Priority() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "Priority", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CancelBy() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "CancelBy", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CancelTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogs", "CancelTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AUTJobLogsDetailColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogsDetail", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogsDetail", "JobID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DocumentID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogsDetail", "DocumentID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Document() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogsDetail", "Document", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DocumentStatus() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogsDetail", "DocumentStatus", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GenerateTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogsDetail", "GenerateTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SentTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogsDetail", "SentTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Result() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogsDetail", "Result", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property sKey() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobLogsDetail", "sKey", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AUTJobsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobs", "JobCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobs", "JobName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RecipiantAsTo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobs", "RecipiantAsTo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RecipiantAsCC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobs", "RecipiantAsCC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property HTMLContent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobs", "HTMLContent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PIC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTJobs", "PIC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_autoLogColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FaxNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "FaxNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DocumentType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "DocumentType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DocumentStatus() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "DocumentStatus", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Subject() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "Subject", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GenerateTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "GenerateTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SentTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "SentTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FaxLog() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "FaxLog", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsReportedGenerate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "IsReportedGenerate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsreportedFailed() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_autoLog", "IsreportedFailed", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AUTScheduleColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "JobCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Saturday() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "Saturday", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Sunday() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "Sunday", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Monday() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "Monday", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Tuesday() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "Tuesday", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Wednesday() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "Wednesday", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Thursday() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "Thursday", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Friday() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "Friday", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Time() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSchedule", "Time", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_AUTSettingsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailServer() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "MailServer", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailUserName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "MailUserName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailPassword() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "MailPassword", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FAXServer() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "FAXServer", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FaxUserName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "FaxUserName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FaxPassword() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "FaxPassword", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FaxServerMailBox() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "FaxServerMailBox", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property AutomationProfile() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "AutomationProfile", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SentDocFolder() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_AUTSettings", "SentDocFolder", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_BookingColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "BookingNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "BookingDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ClientID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "ClientID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ClientRepID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "ClientRepID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Validity() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "Validity", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "POL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POLFreeDays() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "POLFreeDays", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POD() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "POD", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PODFreeDays() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "PODFreeDays", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POT() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "POT", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FPOD() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "FPOD", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Goods() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "Goods", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Depot() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "Depot", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PrincipalReference() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "PrincipalReference", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PrincipalConfirm() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "PrincipalConfirm", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SalesMan() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "SalesMan", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Status() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "Status", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Terms() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "Terms", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ExchangeFrt() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "ExchangeFrt", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ExchangeTHC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "ExchangeTHC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceInIrr() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "InvoiceInIrr", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Package() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "Package", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ExceptedMtyPickup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "ExceptedMtyPickup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLToBeUsed() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "BLToBeUsed", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SOC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "SOC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UNNO() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "UNNO", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IMDGCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "IMDGCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PakingGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "PakingGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PageNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "PageNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SwitchBLIn() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "SwitchBLIn", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PackageType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "PackageType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Payer() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Booking", "Payer", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_BookingCnsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingCns", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingCns", "PID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingCns", "CnType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingCns", "CnSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoOfCns() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingCns", "NoOfCns", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_BookingDepositsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDeposits", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDeposits", "BookingID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCodes() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDeposits", "ChargesCodes", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDeposits", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDeposits", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReturnBackDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDeposits", "ReturnBackDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReturnBackAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDeposits", "ReturnBackAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReturnBackRef() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDeposits", "ReturnBackRef", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaidRef() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDeposits", "PaidRef", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_BookingDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "BookingID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargeItem() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "ChargeItem", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "CnSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "CnType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property QTShipper() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "QTShipper", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property QTCarrier() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "QTCarrier", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TotalCntrs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "TotalCntrs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Payebleat() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "Payebleat", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BaseOn() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "BaseOn", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CurCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "CurCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SlotRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingDetails", "SlotRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_BookingReleasCntrsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingReleasCntrs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReleaseID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingReleasCntrs", "ReleaseID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingReleasCntrs", "CnType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingReleasCntrs", "CnSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoOfCntrs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingReleasCntrs", "NoOfCntrs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_BookingReleaseColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingRelease", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingRelease", "BookingID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Reference() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingRelease", "Reference", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RequestTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingRelease", "RequestTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingRelease", "IssueDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueOffice() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_BookingRelease", "IssueOffice", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_CalculationBaseColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ExchangeRateInward() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "ExchangeRateInward", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ExchangeRateOutward() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "ExchangeRateOutward", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DetentionInwardStartTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "DetentionInwardStartTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DetentionOutwardStartTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "DetentionOutwardStartTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TaxDutyInward() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "TaxDutyInward", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TaxDutyOutward() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "TaxDutyOutward", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsTaxDutyJoin() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "IsTaxDutyJoin", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReferenceFormula() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "ReferenceFormula", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceFormula() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CalculationBase", "InvoiceFormula", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ChgLevelDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MasterID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "MasterID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "CnType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SOC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "SOC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ShipmentType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "ShipmentType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Imco() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "Imco", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsFull() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "IsFull", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount20() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "Amount20", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount40() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "Amount40", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount45() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelDetails", "Amount45", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ChgLevelMasterColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ImportExport() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "ImportExport", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ApplyDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "ApplyDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Validity() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "Validity", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargeItem() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "ChargeItem", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsDeposit() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "IsDeposit", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BaseOn() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "BaseOn", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CurCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "CurCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DefaultAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "DefaultAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DividInLCL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "DividInLCL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Condition() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "Condition", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Tax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "Tax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Toll() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "Toll", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Port() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "Port", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ClientID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ChgLevelMaster", "ClientID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ClientsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property lName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "lName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property lAddress() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "lAddress", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property fName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "fName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property fAddress() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "fAddress", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Email() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "Email", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Fax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "Fax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TEL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "TEL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Country() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "Country", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property AccountA() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "AccountA", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property AccountB() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "AccountB", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property AccountC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "AccountC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POBOX() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "POBOX", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RegestrationNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "RegestrationNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EconomicNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "EconomicNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsReal() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "IsReal", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ClientCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "ClientCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Mobile() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "Mobile", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SendDocsByFax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "SendDocsByFax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SendDocsByEmail() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "SendDocsByEmail", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NationalCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "NationalCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NationalID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "NationalID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property City() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "City", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property State() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "State", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property AccountStatus() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "AccountStatus", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Deposit() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Clients", "Deposit", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ClusesColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Cluses", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CluseGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Cluses", "CluseGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Cluses", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Detail() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Cluses", "Detail", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_CODEColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CODE", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GroupCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CODE", "GroupCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property STDCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CODE", "STDCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NextCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CODE", "NextCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MEANING() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CODE", "MEANING", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MEANINGF() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CODE", "MEANINGF", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsEditeble() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CODE", "IsEditeble", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_CodeMasterColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CodeMaster", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GroupCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CodeMaster", "GroupCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GroupName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CodeMaster", "GroupName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsSystemCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CodeMaster", "IsSystemCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_CompanyColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CompanyName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "CompanyName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CompanyAddress() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "CompanyAddress", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Tel() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "Tel", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Fax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "Fax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EDICODE() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "EDICODE", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DomainName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "DomainName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POP3() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "POP3", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SMTP() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "SMTP", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CompanyFName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "CompanyFName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CompantFAddress() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "CompantFAddress", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CompanyFTel() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "CompanyFTel", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CompanyFFax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "CompanyFFax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CompanyAccount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "CompanyAccount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DetentionBySlab() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "DetentionBySlab", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POBOX() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "POBOX", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RegestrationNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "RegestrationNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EconomicNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "EconomicNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SOCEDICode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "SOCEDICode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CompanyBranchAdrs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "CompanyBranchAdrs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CompanyLBranchAdrs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Company", "CompanyLBranchAdrs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_CountryColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property CountryCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Country", "CountryCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CountryName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Country", "CountryName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FCountryName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Country", "FCountryName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Country", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_CustomMenuColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CustomMenu", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CustomMenu", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MenuGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CustomMenu", "MenuGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MenuItem() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CustomMenu", "MenuItem", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FormName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_CustomMenu", "FormName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_DamageColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReportDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "ReportDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DamageOn() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "DamageOn", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RepairShop() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "RepairShop", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property StartRepair() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "StartRepair", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FinishedRepair() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "FinishedRepair", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RepairCost() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "RepairCost", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceTo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "InvoiceTo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "InvoiceAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvCurrency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Damage", "InvCurrency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_DepositsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Deposits", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Deposits", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCodes() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Deposits", "ChargesCodes", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Deposits", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Deposits", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReturnBackDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Deposits", "ReturnBackDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReturnBackAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Deposits", "ReturnBackAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReturnBackRef() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Deposits", "ReturnBackRef", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaidRef() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Deposits", "PaidRef", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_DetentionBaseColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ImpExp() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "ImpExp", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ApplyDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "ApplyDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Validity() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "Validity", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Tax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "Tax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Toll() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "Toll", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsBase() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "IsBase", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Clause() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "Clause", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FClause() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "FClause", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBase", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_DetentionBaseDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBaseDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BaseID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBaseDetails", "BaseID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBaseDetails", "CnType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DayFrom() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBaseDetails", "DayFrom", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DayTo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBaseDetails", "DayTo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount20() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBaseDetails", "Amount20", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount40() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBaseDetails", "Amount40", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount45() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DetentionBaseDetails", "Amount45", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_DocumetsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Documets", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LineCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Documets", "LineCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DocumentType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Documets", "DocumentType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Documets", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FreeDocument() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Documets", "FreeDocument", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaperSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Documets", "PaperSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_DocumetsDetailColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DocumentID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "DocumentID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FieldDescription() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "FieldDescription", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FieldName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "FieldName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Visible() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "Visible", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property nTop() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "nTop", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property nLeft() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "nLeft", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property nHight() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "nHight", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property nWidth() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "nWidth", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FontName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "FontName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FontSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "FontSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FontItalic() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "FontItalic", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FontUnderLine() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "FontUnderLine", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FontBold() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "FontBold", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FontStrickOut() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_DocumetsDetail", "FontStrickOut", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_EcsContainersColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InVoyageID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "InVoyageID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "CntrNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "CnSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "CnType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DischargeTo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "DischargeTo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InStatus() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "InStatus", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InCellNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "InCellNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "BookingID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property OutVoyageID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "OutVoyageID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property OutStatus() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "OutStatus", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property OutCellNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "OutCellNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReturnTo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "ReturnTo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Destination() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "Destination", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LastDepot() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "LastDepot", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LastStatus() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "LastStatus", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LastStatusDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "LastStatusDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsTerminate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "IsTerminate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ExportPermit() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "ExportPermit", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InDjwazNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "InDjwazNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SOC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "SOC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SpecialOpr() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsContainers", "SpecialOpr", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_EcsMovesColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsMoves", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsMoves", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Status() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsMoves", "Status", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property StatusDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsMoves", "StatusDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property StatusDateToLine() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsMoves", "StatusDateToLine", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Depot() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsMoves", "Depot", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsMoves", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsReported() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsMoves", "IsReported", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_EcsReserveContainersColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsReserveContainers", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EcsReserveContainers", "CntrNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_EventMailColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EventMail", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EventCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EventMail", "EventCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailTo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EventMail", "MailTo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailCC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EventMail", "MailCC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailBCC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EventMail", "MailBCC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PORT() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EventMail", "PORT", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property HTMLContent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_EventMail", "HTMLContent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ExchangeColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Exchange", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ExchangeDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Exchange", "ExchangeDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ExchangeDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExchangeDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MasterID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExchangeDetails", "MasterID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CurCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExchangeDetails", "CurCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property THCRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExchangeDetails", "THCRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FRTRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExchangeDetails", "FRTRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ExpInvoiceColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "InvoiceNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "IssueTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueBy() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "IssueBy", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ConfirmTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "ConfirmTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ConfirmBy() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "ConfirmBy", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Status() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "Status", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueOffice() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "IssueOffice", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ConfirmOffice() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoice", "ConfirmOffice", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ExpInvoiceDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoiceDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoiceDetails", "InvoiceID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoiceDetails", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoiceDetails", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoiceDetails", "ChargesCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoiceDetails", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoiceDetails", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IRRAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpInvoiceDetails", "IRRAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ExpRecivedItemsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "InvoiceID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaymentType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "PaymentType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Bank() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "Bank", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IrrAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "IrrAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaidDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "PaidDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaidRef() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "PaidRef", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReceivedType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ExpRecivedItems", "ReceivedType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_FaxActionsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxActions", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DocumentCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxActions", "DocumentCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxActions", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DefualtFaxLine() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxActions", "DefualtFaxLine", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RecipiantAsTo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxActions", "RecipiantAsTo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RecipiantAsCC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxActions", "RecipiantAsCC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsInAction() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxActions", "IsInAction", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ActionID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxActions", "ActionID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LastActionTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxActions", "LastActionTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_FaxStatusColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxStatus", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxStatus", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DocumentType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxStatus", "DocumentType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GenerateDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxStatus", "GenerateDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SentDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxStatus", "SentDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Status() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxStatus", "Status", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsMailSent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxStatus", "IsMailSent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FaxLog() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxStatus", "FaxLog", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SavedPath() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_FaxStatus", "SavedPath", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InqueryColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Inquery", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ClinetID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Inquery", "ClinetID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InqueryDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Inquery", "InqueryDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InqueryValidity() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Inquery", "InqueryValidity", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PrincipalReference() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Inquery", "PrincipalReference", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Inquery", "POL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POD() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Inquery", "POD", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InqueryDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InqueryDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MasterID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InqueryDetails", "MasterID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InqueryDetails", "CnSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InqueryDetails", "CnType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsDG() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InqueryDetails", "IsDG", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InqueryDetails", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InvoiceColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "InvoiceNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "IssueTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueBy() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "IssueBy", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ConfirmTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "ConfirmTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ConfirmBy() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "ConfirmBy", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Status() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "Status", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueOffice() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "IssueOffice", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ConfirmOffice() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Invoice", "ConfirmOffice", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InvoiceDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InvoiceDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InvoiceDetails", "InvoiceID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InvoiceDetails", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InvoiceDetails", "ChargesCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InvoiceDetails", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InvoiceDetails", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InvoiceDetails", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IRRAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InvoiceDetails", "IRRAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardBLSColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Service() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "Service", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BlNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "BlNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssuePlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "IssuePlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "IssueDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property OnBoardDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "OnBoardDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POR() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "POR", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "POL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POT() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "POT", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POD() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "POD", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FPOD() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "FPOD", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PreVoyageID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "PreVoyageID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VoyageID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "VoyageID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoOfBls() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "NoOfBls", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TermsOfPayment() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "TermsOfPayment", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ClientID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "ClientID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FCLType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "FCLType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Reference() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "Reference", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailRelease() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "MailRelease", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailReleaseRem() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "MailReleaseRem", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FrtCoverdCarr() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "FrtCoverdCarr", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FrtCoverdBlNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "FrtCoverdBlNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Status() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "Status", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LcNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "LcNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLStatus() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "BLStatus", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "BookingID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "BookingNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MBL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "MBL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FwdLine() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "FwdLine", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FwAgent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "FwAgent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "JobNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueFU() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "IssueFU", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FinalizeDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "FinalizeDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FinalizeStatus() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "FinalizeStatus", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TFCCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "TFCCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BarCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "BarCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property HSCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBLS", "HSCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardBlsCommentsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsComments", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsComments", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CommentType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsComments", "CommentType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Comment() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsComments", "Comment", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CommentDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsComments", "CommentDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class Tb_InwardBlsFrsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_InwardBlsFrs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_InwardBlsFrs", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FCnee() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_InwardBlsFrs", "FCnee", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FGoods() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_InwardBlsFrs", "FGoods", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FPkgs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_InwardBlsFrs", "FPkgs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardBlsGoodsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Goods() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "Goods", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Marks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "Marks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MainCom() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "MainCom", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TTW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "TTW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TGW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "TGW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TTLPkgs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "TTLPkgs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TTLCBM() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "TTLCBM", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TTLNET() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsGoods", "TTLNET", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardBlsNamesColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Shipper() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Shipper", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Cnee() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Cnee", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify1() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Notify1", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify2() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Notify2", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify3() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Notify3", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Messers() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Messers", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ShipperID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "ShipperID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CneeID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "CneeID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify1ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Notify1ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify2ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Notify2ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify3ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Notify3ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Forwarder() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "Forwarder", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ForwarderID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardBlsNames", "ForwarderID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardChargesColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "ChargesCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Qty() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "Qty", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Rate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "Rate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PayAt() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "PayAt", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesBase() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "ChargesBase", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Terms() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "Terms", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ActPlaceExRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "ActPlaceExRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MeaUnitOfCharge() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "MeaUnitOfCharge", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FromPlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "FromPlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ToPlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "ToPlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PayAtBranch() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "PayAtBranch", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PayAtExRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "PayAtExRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PayAtPc() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "PayAtPc", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "InvoiceAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RealAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCharges", "RealAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardCnsImcoColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsImco", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsImco", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UNNO() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsImco", "UNNO", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IMDGCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsImco", "IMDGCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FlashPoint() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsImco", "FlashPoint", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PakingGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsImco", "PakingGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PageNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsImco", "PageNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EMSNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsImco", "EMSNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardCnsPkgsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PackageType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "PackageType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoOFPkgs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "NoOFPkgs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "GW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CBM() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "CBM", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NET() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "NET", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FlashPoint() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "FlashPoint", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IMDGCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "IMDGCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PakingGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "PakingGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PageNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "PageNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EMSNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsPkgs", "EMSNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardCnsTempratureColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsTemprature", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsTemprature", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TempMin() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsTemprature", "TempMin", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TempMax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsTemprature", "TempMax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TemperatureBase() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCnsTemprature", "TemperatureBase", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardCntrsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "CntrNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "CnSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "CnType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SealNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "SealNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "TW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "GW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CBM() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "CBM", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NET() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "NET", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FLE() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "FLE", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SOC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "SOC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PackageType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "PackageType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoOFPkgs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "NoOFPkgs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Goods() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "Goods", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsOOG() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "IsOOG", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Marks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "Marks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POLTerm() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "POLTerm", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PODTerm() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrs", "PODTerm", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardCntrsChargesColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "ChargesCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UnitRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "UnitRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MEARate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "MEARate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property WGTrate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "WGTrate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FromPlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "FromPlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ToPlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "ToPlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MinRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "MinRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Terms() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "Terms", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RealAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardCntrsCharges", "RealAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardDiscountColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property dFreeDays() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "dFreeDays", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property dPercent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "dPercent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property dAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "dAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LineSetel() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "LineSetel", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsFDaysAsDiscount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "IsFDaysAsDiscount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SpecialCalculate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "SpecialCalculate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PerDay20() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "PerDay20", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PerDay40() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "PerDay40", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PerDay45() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "PerDay45", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DetentionID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "DetentionID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoTax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardDiscount", "NoTax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_InwardStatusColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DoOffice() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "DoOffice", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DoDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "DoDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Detention() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "Detention", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Discont() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "Discont", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SetelmentDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "SetelmentDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceToClinet() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "InvoiceToClinet", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReportToCarrier() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "ReportToCarrier", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Closed() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_InwardStatus", "Closed", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ISOTypeColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ISOTypeID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "ISOTypeID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SizeIS() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "SizeIS", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TypeIS() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "TypeIS", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property HeightIS() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "HeightIS", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DispName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "DispName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ISOValue() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "ISOValue", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property WHLCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "WHLCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TareWeight() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "TareWeight", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property WHLSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "WHLSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property WHLType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "WHLType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property WHLHeight() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "WHLHeight", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PSOType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "PSOType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TEU() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "TEU", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property OurType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "OurType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ISOType", "InGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_LinesColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Lines", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LineCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Lines", "LineCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LineName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Lines", "LineName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EDICode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Lines", "EDICode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Address() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Lines", "Address", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Country() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Lines", "Country", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_LogColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Log", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DataID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Log", "DataID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TableNM() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Log", "TableNM", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Log", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Action() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Log", "Action", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LogText() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Log", "LogText", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LastUpdate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Log", "LastUpdate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LastUser() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Log", "LastUser", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_LogDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LogID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogDetails", "LogID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FieldName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogDetails", "FieldName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property OldValue() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogDetails", "OldValue", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NewValue() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogDetails", "NewValue", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_LogMasterColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogMaster", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TBName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogMaster", "TBName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TableKey() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogMaster", "TableKey", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ActionUser() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogMaster", "ActionUser", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ActionTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogMaster", "ActionTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ActionType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_LogMaster", "ActionType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_MenuItemsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_MenuItems", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_MenuItems", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ItemLevel() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_MenuItems", "ItemLevel", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ItemKey() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_MenuItems", "ItemKey", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_NOSPaymentTypsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaymentType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "PaymentType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Port() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "Port", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BANK() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "BANK", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DBAccount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "DBAccount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DBLevel1() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "DBLevel1", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DBLevel2() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "DBLevel2", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DBLevel3() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "DBLevel3", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DBLevel4() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "DBLevel4", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DBLevel5() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_NOSPaymentTyps", "DBLevel5", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ObjectsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Objects", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ObjectName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Objects", "ObjectName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ObjectContent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Objects", "ObjectContent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Objects", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CreateDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Objects", "CreateDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ModifyDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Objects", "ModifyDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ObjectsUserColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ObjectsUser", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ObjectLine() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ObjectsUser", "ObjectLine", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ObjectGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ObjectsUser", "ObjectGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ObjectName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ObjectsUser", "ObjectName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ObjectRemarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ObjectsUser", "ObjectRemarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ObjectContent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ObjectsUser", "ObjectContent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardBLSColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Service() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "Service", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BlNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "BlNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssuePlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "IssuePlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "IssueDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property OnBoardDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "OnBoardDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POR() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "POR", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "POL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POT() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "POT", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POD() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "POD", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FPOD() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "FPOD", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PreVoyageID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "PreVoyageID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VoyageID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "VoyageID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoOfBls() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "NoOfBls", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TermsOfPayment() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "TermsOfPayment", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ClientID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "ClientID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FCLType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "FCLType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Reference() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "Reference", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailRelease() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "MailRelease", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MailReleaseRem() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "MailReleaseRem", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FrtCoverdCarr() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "FrtCoverdCarr", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FrtCoverdBlNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "FrtCoverdBlNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Status() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "Status", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LcNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "LcNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BlStatus() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "BlStatus", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "BookingID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "BookingNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MBL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "MBL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FwdLine() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "FwdLine", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FwAgent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "FwAgent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property JobNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "JobNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TFCCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "TFCCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BarCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBLS", "BarCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardBlsCommentsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsComments", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsComments", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CommentType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsComments", "CommentType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Comment() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsComments", "Comment", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CommentDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsComments", "CommentDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class Tb_OutwardBlsFrsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_OutwardBlsFrs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_OutwardBlsFrs", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FCnee() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_OutwardBlsFrs", "FCnee", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FGoods() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_OutwardBlsFrs", "FGoods", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FPkgs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("Tb_OutwardBlsFrs", "FPkgs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardBlsGoodsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Goods() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "Goods", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Marks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "Marks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MainCom() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "MainCom", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TTW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "TTW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TGW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "TGW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TTLPkgs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "TTLPkgs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TTLCBM() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "TTLCBM", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TTLNET() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsGoods", "TTLNET", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardBlsNamesColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Shipper() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Shipper", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Cnee() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Cnee", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify1() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Notify1", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify2() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Notify2", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify3() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Notify3", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Messers() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Messers", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ShipperID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "ShipperID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CneeID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "CneeID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify1ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Notify1ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify2ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Notify2ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Notify3ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Notify3ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Forwarder() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "Forwarder", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ForwarderID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsNames", "ForwarderID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardBlsTemplateColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsTemplate", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsTemplate", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property XML() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardBlsTemplate", "XML", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardChargesColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "ChargesCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Qty() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "Qty", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Rate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "Rate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PayAt() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "PayAt", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesBase() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "ChargesBase", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Terms() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "Terms", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TariffClass() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "TariffClass", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ActPlaceExRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "ActPlaceExRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MeaUnitOfCharge() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "MeaUnitOfCharge", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FromPlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "FromPlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ToPlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "ToPlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PayAtBranch() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "PayAtBranch", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PayAtExRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "PayAtExRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PayAtPc() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "PayAtPc", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "InvoiceAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RealAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCharges", "RealAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardCnsImcoColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsImco", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsImco", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UNNO() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsImco", "UNNO", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IMDGCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsImco", "IMDGCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FlashPoint() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsImco", "FlashPoint", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PakingGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsImco", "PakingGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PageNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsImco", "PageNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EMSNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsImco", "EMSNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardCnsPkgsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PackageType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "PackageType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoOFPkgs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "NoOFPkgs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "GW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CBM() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "CBM", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NET() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "NET", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FlashPoint() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "FlashPoint", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IMDGCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "IMDGCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PakingGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "PakingGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PageNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "PageNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EMSNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsPkgs", "EMSNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardCnsTempratureColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsTemprature", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsTemprature", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TempMin() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsTemprature", "TempMin", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TempMax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsTemprature", "TempMax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TemperatureBase() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCnsTemprature", "TemperatureBase", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardCntrsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "CntrNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnSize() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "CnSize", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CnType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "CnType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SealNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "SealNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "TW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "GW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CBM() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "CBM", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NET() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "NET", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FLE() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "FLE", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SOC() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "SOC", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PackageType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "PackageType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoOFPkgs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "NoOFPkgs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Goods() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "Goods", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsOOG() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "IsOOG", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POLTerm() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "POLTerm", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PODTerm() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrs", "PODTerm", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardCntrsChargesColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "ChargesCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UnitRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "UnitRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MEARate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "MEARate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property WGTrate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "WGTrate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FromPlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "FromPlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ToPlace() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "ToPlace", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MinRate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "MinRate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Terms() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "Terms", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property RealAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardCntrsCharges", "RealAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_OutwardDiscountColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property dFreeDays() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "dFreeDays", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property dPercent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "dPercent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property dAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "dAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LineSetel() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "LineSetel", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsFDaysAsDiscount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "IsFDaysAsDiscount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SpecialCalculate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "SpecialCalculate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PerDay20() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "PerDay20", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PerDay40() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "PerDay40", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PerDay45() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "PerDay45", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DetentionID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "DetentionID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoTax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_OutwardDiscount", "NoTax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_PermitDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PermitID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "PermitID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CntrID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "CntrID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FLE() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "FLE", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "GW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PackageType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "PackageType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NoOFPkgs() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "NoOFPkgs", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SealNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "SealNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TempMin() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "TempMin", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TempMax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PermitDetails", "TempMax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_PermitsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PermitNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "PermitNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Status() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "Status", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Goods() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "Goods", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FPOD() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "FPOD", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property POT() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "POT", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IMDGCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "IMDGCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UNNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "UNNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FlashPoint() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "FlashPoint", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PackingGroup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "PackingGroup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PageNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "PageNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EMSNumber() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Permits", "EMSNumber", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_PInvoiceColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoice", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BLID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoice", "BLID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoice", "InvoiceNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoice", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueTime() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoice", "IssueTime", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IssueBy() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoice", "IssueBy", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_PInvoiceDetailsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoiceDetails", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoiceDetails", "InvoiceID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoiceDetails", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoiceDetails", "ChargesCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Remarks() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoiceDetails", "Remarks", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoiceDetails", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_PInvoiceDetails", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_PortsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Ports", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PortCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Ports", "PortCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PortName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Ports", "PortName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FPortName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Ports", "FPortName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Country() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Ports", "Country", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EDIIPCODE() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Ports", "EDIIPCODE", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_RecivedItemsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InvoiceID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "InvoiceID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Description() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "Description", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaymentType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "PaymentType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Bank() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "Bank", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Currency() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "Currency", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Amount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "Amount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IrrAmount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "IrrAmount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaidDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "PaidDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PaidRef() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "PaidRef", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReceivedType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_RecivedItems", "ReceivedType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ReferenceColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Reference", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Code() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Reference", "Code", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Section() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Reference", "Section", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property InternalCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Reference", "InternalCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ReleaseLetterSeqColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ReleaseLetterSeq", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LastSeq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ReleaseLetterSeq", "LastSeq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MaxSeq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ReleaseLetterSeq", "MaxSeq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_ReportCustomFieldsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ReportCustomFields", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReportName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ReportCustomFields", "ReportName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ReportFrindlyName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ReportCustomFields", "ReportFrindlyName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FieldName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ReportCustomFields", "FieldName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FieldFriendlyName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ReportCustomFields", "FieldFriendlyName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DataContent() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_ReportCustomFields", "DataContent", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_SCNIDSColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SCNIDS", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SCNID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SCNIDS", "SCNID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Name() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SCNIDS", "Name", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TEL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SCNIDS", "TEL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_SeqColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Seq", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SeqType() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Seq", "SeqType", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Office() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Seq", "Office", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SeqYear() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Seq", "SeqYear", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Seq() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Seq", "Seq", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Seq", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_SOFColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VoyageID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "VoyageID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Port() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "Port", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ArrivalAnchorage() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "ArrivalAnchorage", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Pilot() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "Pilot", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Arrival() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "Arrival", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Berthed() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "Berthed", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Jetty() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "Jetty", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FreePraGrnt() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "FreePraGrnt", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CustomInspect() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "CustomInspect", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GangOnBoard() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "GangOnBoard", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DschCmnc() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "DschCmnc", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DschCmpl() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "DschCmpl", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LoadCmnc() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "LoadCmnc", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property LoadCmpl() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "LoadCmpl", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DocOnBoard() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "DocOnBoard", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property PClear() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "PClear", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Unberthed() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "Unberthed", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Sailed() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "Sailed", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NextPort() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "NextPort", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ETANextPort() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "ETANextPort", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IFOArrival() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "IFOArrival", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MDOArrival() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "MDOArrival", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FWaterArrival() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "FWaterArrival", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IFOSup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "IFOSup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MDOSup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "MDOSup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FWaterSup() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "FWaterSup", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IFODep() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "IFODep", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property MDODep() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "MDODep", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property FWaterDep() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "FWaterDep", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DrftArvlFor() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "DrftArvlFor", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DrftArvlAft() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "DrftArvlAft", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DrftDepFor() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "DrftDepFor", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DrftDepAft() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "DrftDepAft", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DjwazNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "DjwazNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ETA() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_SOF", "ETA", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_TaxBaseColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_TaxBase", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ChargesCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_TaxBase", "ChargesCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ApplyDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_TaxBase", "ApplyDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property validity() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_TaxBase", "validity", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Port() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_TaxBase", "Port", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Tax() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_TaxBase", "Tax", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TOLL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_TaxBase", "TOLL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_UsersColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UserFirstName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "UserFirstName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UserLastName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "UserLastName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UserAccount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "UserAccount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UserCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "UserCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Password() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "Password", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EmailOffice() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "EmailOffice", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property EmailHome() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "EmailHome", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TEL() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "TEL", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsSalesAdmin() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "IsSalesAdmin", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsAccountAdmin() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "IsAccountAdmin", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsDocAdmin() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "IsDocAdmin", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property IsEcsAdmin() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "IsEcsAdmin", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BookingViewer() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Users", "BookingViewer", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_UsersDeptColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_UsersDept", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UserID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_UsersDept", "UserID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Department() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_UsersDept", "Department", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_UsersLineColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_UsersLine", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property UserID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_UsersLine", "UserID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Line() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_UsersLine", "Line", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_VesselsColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VesselCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "VesselCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VesselName() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "VesselName", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DeadWeight() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "DeadWeight", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Capacity() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "Capacity", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property GW() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "GW", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property NET() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "NET", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Speed() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "Speed", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property OfficalNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "OfficalNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property CallLetter() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "CallLetter", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property BuiltDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "BuiltDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Nationality() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "Nationality", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VesselAccount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Vessels", "VesselAccount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class
       Public Class TB_VoyageColumns : Inherits DataManagerBase.JoinPathRelation
            Friend Sub New(ByVal relationList As ArrayList, ByVal relationAlias As String)
                Me.RelationList = relationList
                Me.OrmAlias = relationAlias
            End Sub



					Public ReadOnly Property ID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "ID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VesselID() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "VesselID", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VoyageNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "VoyageNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Carrier() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "Carrier", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Service() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "Service", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property StartDate() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "StartDate", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ExchangeFrt() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "ExchangeFrt", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property ExchangeThc() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "ExchangeThc", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property DjwazNo() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "DjwazNo", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property Master() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "Master", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property SLOT() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "SLOT", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property VoyageAccount() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "VoyageAccount", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property
					Public ReadOnly Property TFCCode() As DataManagerBase.JoinPathRelation
							Get
								RelationList.Add(New DataManagerBase.Relation("TB_Voyage", "TFCCode", "", "", Me.OrmAlias, Me.OrmAlias))
								return Me
							End Get
					End Property

        End Class

    End Class

    End Class
    
End Namespace
