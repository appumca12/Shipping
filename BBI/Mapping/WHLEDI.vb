Public Class WHLEDI
    Private CurrentCTA As SegmentCTAType
    Private CurrentCTH As SegmentCTAType
    Private CurrentCTI As SegmentCTAType
    Private ListOfSkipedSegment As New ArrayList
    Public sTFCCode As String

    Public Structure SegmentMFTType

        Public FILE_ID As String
        Public SENDER_CODE As String
        Public RECEIVER_CODE As String
        Public TRANSMISSION_DATE As String
        Public TRANSMISSION_TIME As String
        Public TFC_CODE As String
        Public LOADING_STATUS As String
        Public FINISH_DATE As String
        Public POD_RELEASE_DATE As String
        Public ENTRY_PROGRAM As String
        Public BL_SOURCE As String
        Public FILLER As String

    End Structure
    Public Structure SegmentKEYType
        Public ROW_ID As String
        Public BOOK_NO As String
        Public SO_NO As String
        Public MO_NO As String
        Public TRANS_STATUS As String
        Public LINER_CODE As String
        Public OB_DATE As String
        Public BOOK_PREFIX As String
        Public BOOK_YEAR As String
        Public BOOK_SEQ As String
        Public POL As String
        Public POD As String
        Public PLR As String
        Public PLD As String
        Public BKG_PLACE As String
        Public BKG_BRANCH_CODE As String
        Public CONTRACT_NO As String
        Public FILLER As String
        Public BL_MASTER_HOUSE_TYPE_CODE As String
        Public BL_PROCESS_TYPE As String
    End Structure
  
    Public Structure SegmentBLAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_VESSEL As String
        Public BL_VOY_NO As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLBType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_POL As String
        Public BL_POD As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLCType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_PLR As String
        Public BL_PLD As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLDType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_DSTN As String
        Public BL_TTL_PKG As String
        Public BL_CGO_MEA As String
        Public BL_CGO_WGT As String
        Public BL_CGO_NET_WGT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLEType
        Public ROW_ID As String
        Public ROW_NO As String
        Public ISSUE_BL_DATE As String
        Public ISSUE_DO_DATE As String
        Public POL_VOICE_CODE As String
        Public POD_VOICE_CODE As String
        Public EC_MEMBER_ID As String
        Public ARRIVAL_DATE As String
        Public EX_RATE As String
        Public DO_PASSWD As String
        Public EC_NTFY_MEMBER_ID As String
    End Structure
    Public Structure SegmentBLFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_REMARK As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLGType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POD_REMARK As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLHType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_PKG_UNIT As String
        Public BL_WGT_UNIT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLIType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_MEA_UNIT As String
        Public BL_PAID_TERM As String
        Public BL_PRE_CARRIAGE As String
    End Structure
    Public Structure SegmentBLJType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_ISSUE_PLACE As String
        Public BL_FREIGHT_AT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLKType
        Public ROW_ID As String
        Public ROW_NO As String
        Public VSL_CODE As String
        Public LOADED_ON As String
        Public CALL_SIGN As String
        Public VSL_REG_NO As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLLType
        Public ROW_ID As String
        Public ROW_NO As String
        Public FREIGHT_PREPAID_AT As String
        Public PLACE_OF_ISSUE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLMType
        Public ROW_ID As String
        Public ROW_NO As String
        Public TW_VIA_PORT_NAME As String
        Public TW_VIA_DATE As String
        Public DEST_ARRIVAL_DATE As String
        Public DOC_EXPIRED_DATE As String
        Public SRVC_TEL_NO As String
        Public DOC_PIC As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBLNType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_LADEN_ON_BOARD As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMRKType
        Public ROW_ID As String
        Public ROW_NO As String
        Public MARK As String
        Public C_INDICATOR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentDECType
        Public ROW_ID As String
        Public ROW_NO As String
        Public DESCN As String
        Public C_INDICATOR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentDCMType
        Public ROW_ID As String
        Public ROW_NO As String
        Public REMARK As String
        Public FILLER As String
    End Structure
    Public Structure SegmentLFWType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_FWRD_CODE As String
        Public POL_FWRD As String
        Public FILLER As String
    End Structure
    Public Structure SegmentLFAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_FWRD_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentLFFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_FWRD_FAX_HEAD As String
        Public POL_FWRD_FAX_AREA As String
        Public POL_FWRD_FAX As String
        Public FILLER As String
    End Structure
    Public Structure SegmentLBKType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_BROKER As String
        Public FILLER As String
    End Structure
    Public Structure SegmentLBAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_BROKER_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentLBFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_BROKER_FAX_HEAD As String
        Public POL_BROKER_FAX_AREA As String
        Public POL_BROKER_FAX As String
        Public FILLER As String
    End Structure
    Public Structure SegmentLBTType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_BROKER_TEL_HEAD As String
        Public POL_BROKER_TEL_AREA As String
        Public POL_BROKER_TEL As String
        Public FILLER As String
    End Structure
    Public Structure SegmentSPRType
        Public ROW_ID As String
        Public ROW_NO As String
        Public SHPR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentSPAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public SHPR_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentSPFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public SHPR_FAX_HEAD As String
        Public SHPR_FAX_AREA As String
        Public SHPR_FAX As String
        Public SHPR_MAIL_ACCT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCSPType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C_SHPR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCSAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C_SHPR_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCEEType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CONSIGNEE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCEAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CONSIGNEE_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCEFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CONSIGNEE_FAX_HEAD As String
        Public CONSIGNEE_FAX_AREA As String
        Public CONSIGNEE_FAX As String
        Public CNEE_MAIL_ACCT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCETType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CONSIGNEE_TEL_HEAD As String
        Public CONSIGNEE_TEL_AREA As String
        Public CONSIGNEE_TEL As String
        Public CONSIGNEE_TEL_EXT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCCEType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C_CONSIGNEE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCCAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C_CONSIGNEE_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCEPType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CONSIGNEE_PIC As String
        Public FILLER As String
    End Structure
    Public Structure SegmentNTFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public NOTIFY As String
        Public FILLER As String
    End Structure
    Public Structure SegmentNFAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public NOTIFY_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentNFFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public NOTIFY_FAX_HEAD As String
        Public NOTIFY_FAX_AREA As String
        Public NOTIFY_FAX As String
        Public NTFY_MAIL_ACCT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentNFTType
        Public ROW_ID As String
        Public ROW_NO As String
        Public NOTIFY_TEL_HEAD As String
        Public NOTIFY_TEL_AREA As String
        Public NOTIFY_TEL As String
        Public NOTIFY_TEL_EXT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCNFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C_NOTIFY As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCNAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C_NOTIFY_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentNTPType
        Public ROW_ID As String
        Public ROW_NO As String
        Public NTFY_PIC As String
        Public FILLER As String
    End Structure
    Public Structure SegmentANYType
        Public ROW_ID As String
        Public ROW_NO As String
        Public ALSO_NOTIFY As String
        Public FILLER As String
    End Structure
    Public Structure SegmentANAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public ALSO_NOTIFY_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCANType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C_ALSO_NOTIFY As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCAAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C_ALSO_NOTIFY_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentDFWType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POD_FWRD_CODE As String
        Public POD_FWRD As String
        Public FILLER As String
    End Structure
    Public Structure SegmentDFAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POD_FWRD_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentDBKType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POD_BROKER As String
        Public FILLER As String
    End Structure
    Public Structure SegmentDBTType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POD_BROKER_TEL_HEAD As String
        Public POD_BROKER_TEL_AREA As String
        Public POD_BROKER_TEL As String
        Public FILLER As String
    End Structure
    Public Structure SegmentSLRType
        Public ROW_ID As String
        Public ROW_NO As String
        Public SELLER As String
        Public FILLER As String
    End Structure
    Public Structure SegmentSLAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public SELLER_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBYRType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BUYER As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBYAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BUYER_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMARType
        Public ROW_ID As String
        Public ROW_NO As String
        Public MANUFACTURER As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMAAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public MANUFACTURER_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentSTNType
        Public ROW_ID As String
        Public ROW_NO As String
        Public SHIP_TO As String
        Public FILLER As String
    End Structure
    Public Structure SegmentSTAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public SHIP_TO_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCSRType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CONSOLIDATOR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCSRAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CONSOLIDATOR_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBPNType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BOOK_PARTY As String
        Public FILLER As String
    End Structure
    Public Structure SegmentBPAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BOOK_PARTY_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentPYOType
        Public ROW_ID As String
        Public ROW_NO As String
        Public OFT_PAYER As String
        Public OFT_PAYER_DISTRICT As String
        Public OFT_PAYER_REG_CODE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentPYHType
        Public ROW_ID As String
        Public ROW_NO As String
        Public THC_PAYER As String
        Public THC_PAYER_DISTRICT As String
        Public THC_PAYER_REG_CODE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentPYDType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POD_PAYER As String
        Public POD_PAYER_DISTRICT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentPYTType
        Public ROW_ID As String
        Public ROW_NO As String
        Public TAP_PAYER As String
        Public TAP_PAYER_DISTRICT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public FINAL_PORT As String
        Public FINAL_DESTINATION As String
        Public IS_FREE_SUR_POL As String
        Public FILLER1 As String
        Public IS_FCL_OVER As String
        Public BL_TYPE As String
        Public GET_BL_PLACE As String
        Public OFT_PAYMENT_TYPE As String
        Public NO_OF_ORGN As String
        Public ISSUE_BL_DATE As String
        Public ISSUE_SWITCH_BL_PLACE As String
        Public ISSUE_MEMO_BL_PLACE As String
        Public ISSUE_MEMO_BL_TYPE As String
        Public ORGN_BL_NO As String
        Public IS_CALC_PMW As String
        Public IS_CHECK_OK As String
        Public IS_CALC_CHARGE As String
        Public FILLER2 As String
        Public FINISH_DATE As String
        Public POD_RELEASE_DATE As String
        Public GET_BL_OFFICE As String
        Public ISSUE_SWITCH_BL_BRANCH As String
        Public ISSUE_MEMO_BL_BRANCH As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGBType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_CUSTOMS_CODE As String
        Public POD_CUSTOMS_CODE As String
        Public TTL_PKG As String
        Public TTL_PKG_UNIT As String
        Public CGO_MEASURE As String
        Public CGO_GROSS_WEIGHT As String
        Public CGO_NET_WEIGHT As String
        Public ITEM_CODE As String
        Public IS_PRINT_FREIGHT As String
        Public IS__PRINT__VSL_CERT As String
        Public IS__PRINT__SEAL_CODE As String
        Public IS__PRINT__DEBT_NOTE As String
        Public IS__PRINT__SHPR As String
        Public IS__PRINT__SHPR_ADDR As String
        Public IS__PRINT__C_SHPR As String
        Public IS__PRINT__C_SHPR_ADDR As String
        Public IS__PRINT__NTFY As String
        Public IS__PRINT__NTFY_ADDR As String
        Public IS__PRINT__C_NTFY As String
        Public IS__PRINT__C_NTFY_ADDR As String
        Public IS__PRINT__ALSO_NTFY As String
        Public IS_PRINT_ALSO_NTFY_ADDR As String
        Public IS__PRINT__C_ALSO_NTFY As String
        Public IS_PRINT_C_ALSO_NTFY_ADDR As String
        Public IS__PRINT__CNEE As String
        Public IS__PRINT__CNEE_ADDR As String
        Public IS__PRINT__C_CNEE As String
        Public IS__PRINT__C_CNEE_ADDR As String
        Public IS__PRINT__C_MARK As String
        Public IS__PRINT__C_DESC As String
        Public IS_CTNR_ATTACH As String
        Public ATTACH_MARK As String
        Public MEASURE_PRINT_DECIMAL As String
        Public MEASURE_UNIT As String
        Public WEIGHT_UNIT As String
        Public IS_MONETARY As String
        Public IS_NON_MONETARY As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGCType
        Public ROW_ID As String
        Public ROW_NO As String
        Public INCL_COMB As String
        Public INCL_COMB_LIST As String
        Public SCAC_CODE As String
        Public ISS_CODE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGDType
        Public ROW_ID As String
        Public ROW_NO As String
        Public ALLIN_LIST As String
        Public ALLIN_CURR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGEType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C131 As String
        Public C133 As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_STORE_PLACE As String
        Public POD_STORE_PLACE As String
        Public JV_CODE As String
        Public PREV_TRANS_PORT As String
        Public PREV_TFC_CODE As String
        Public P_TFC_CODE As String
        Public PLAN_TRANS_PORT As String
        Public PLAN_N_TFC_CODE As String
        Public IS_BL_CTNR_ATTACH As String
        Public IS_BL_MARK_ATTACH As String
        Public IS_BL_DESC_ATTACH As String
        Public IS_DO_CTNR_ATTACH As String
        Public IS_DO_MARK_ATTACH As String
        Public IS_DO_DESC_ATTACH As String
        Public IS_AN_CTNR_ATTACH As String
        Public IS_AN_MARK_ATTACH As String
        Public IS_AN_DESC_ATTACH As String
        Public GET_DO_PLACE As String
        Public GET_DO_BRANCH As String
        Public IS_PRT_POL_FWRD_ADDR As String
        Public IS_PRT_POD_FWRD_ADDR As String
        Public IS_PRT_POL_BRKR_ADDR As String
        Public IS_PRT_POD_BRKR_ADDR As String
        Public IS_EMPTY_CTNR As String
        Public IS_EMPTY_CTNR_DCLR As String
        Public IS_PRT_CGO_GROSS_WEIGHT As String
        Public IS_PRT_CGO_NET_WEIGHT As String
        Public IS_PROHIBIT_CHG As String
        Public IS_POD_PRT_DB_NOTE As String
        Public ISSUE_DO_OFFICE As String
        Public SUMM_CODE As String
        Public IS_BL_CHARGE_ATTACH As String
        Public IS_DO_CHARGE_ATTACH As String
        Public IS_AN_CHARGE_ATTACH As String
        Public IS_PRT_CGO_MEASURE As String
        Public IS_PRT_FCL_CLAUSE As String
        Public IS_PRT_SAY_TTL_CLAUSE As String
        Public IS_PRT_BL_OB_DATE As String
        Public IS_PRT_BL_EX_RATE As String
        Public IS_PRT_BL_ISSUE_DATE As String
        Public IS_PRT_BL_ATTACHED As String
        Public IS_CONFIRM_BY_MFT_OFFICE As String
        Public IS_NEW_BL_AFTER_VOYAGE_FINISH As String
        Public IS_DUMMY As String
        Public IS_URGENT_CARGO As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGGType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C132 As String
        Public POL_POD_TERM As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGHType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C121 As String
        Public C122 As String
        Public C123 As String
        Public BULK_CARGO_TEU As String
        Public BULK_CARGO_POL_AREA_CODE As String
        Public BULK_CARGO_POD_AREA_CODE As String
        Public SAP_SHIPMENT_NO As String
    End Structure
    Public Structure SegmentMGIType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CUSTOMER_INVOICE_SHIPMENT_NO As String
        Public ALLOW_PRT_ORIGINAL_BL_EC As String
        Public TRAN_EC_DATE As String
        Public TRAN_DO_PASSWD_TO_EC_DATE As String
        Public EC_DO_PASSWD As String
        Public COPY_NO As String
        Public TRUCK_COMPANY_CODE As String
        Public DEBIT_CODE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGJType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_EDI_REMARK As String
        Public POD_EDI_REMARK As String
        Public EDI_TTL_PKG As String
        Public EDI_PKG_UNIT As String
        Public CUSTOMS_CLEARANCE As String
        Public FILLER1 As String
        Public EDI_CGO_GROSS_WEIGHT As String
        Public CUSTOMS_SO_NO As String
        Public FILLER2 As String
        Public POL_EDI_STATUS As String
        Public POD_EDI_STATUS As String
        Public IS_POL_EDI As String
        Public IS_POL_DOC_ACCT As String
        Public IS_POD_EDI_DOC As String
        Public IS_POD_ACCT As String
        Public POD_CUSTOMS_DATE As String
        Public FIN_LINER_CODE As String
        Public FIN_PLR As String
        Public FIN_POL As String
        Public FIN_POD As String
        Public FIN_PLD As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGKType
        Public ROW_ID As String
        Public ROW_NO As String
        Public PRT_BL_USER As String
        Public PRT_BL_OFFICE As String
        Public PRT_BL_DATE As String
        Public REPRT_BL_USER As String
        Public REPRT_BL_OFFICE As String
        Public REPRT_BL_DATE As String
        Public ISSUE_TLXRL_TYPE As String
        Public CONFIRM_TLXRL_USER As String
        Public CONFIRM_TLXRL_OFFICE As String
        Public CONFIRM_TLXRL_DATE As String
        Public TLXRL_TO_PLACE As String
        Public TLXRL_TO_BRANCH As String
        Public TLXRL_CODE As String
        Public IS_PRTED_BL As String
    End Structure
    Public Structure SegmentMGLType
        Public ROW_ID As String
        Public ROW_NO As String
        Public GENERATE_TLXRL_USER As String
        Public GENERATE_TLXRL_OFFICE As String
        Public GENERATE_TLXRL_DATE As String
        Public FILLER1 As String
        Public ISSUE_NOTICE_TLXRL_USER As String
        Public ISSUE_NOTICE_TLXRL_OFFICE As String
        Public ISSUE_NOTICE_TLXRL_DATE As String
        Public GENERATE_TLXRL_USER_SWITCHBL As String
        Public GENERATE_TLXRL_OFFICE_SWITCHBL As String
        Public GENERATE_TLXRL_DATE_SWITCHBL As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGMType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_FAXOUT_USER As String
        Public BL_FAXOUT_OFFICE As String
        Public BL_FAXOUT_DATE As String
        Public FILLER1 As String
        Public PRT_DO_USER As String
        Public PRT_DO_OFFICE As String
        Public PRT_DO_DATE As String
        Public REPRT_DO_USER As String
        Public REPRT_DO_OFFICE As String
        Public REPRT_DO_DATE As String
        Public HOLD_CHG_USER As String
        Public HOLD_CHG_OFFICE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGNType
        Public ROW_ID As String
        Public ROW_NO As String
        Public HOLD_CHG_DATE As String
        Public HOLD_CHG As String
        Public HOLD_CHG_REMARK As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGOType
        Public ROW_ID As String
        Public ROW_NO As String
        Public PRT_POL_MF_USER As String
        Public PRT_POL_MF_OFFICE As String
        Public PRT_POL_MF_DATE As String
        Public PRT_POD_MF_USER As String
        Public PRT_POD_MF_OFFICE As String
        Public PRT_POD_MF_DATE As String
        Public PRT_TRS_MF_USER As String
        Public PRT_TRS_MF_OFFICE As String
        Public PRT_TRS_MF_DATE As String
        Public TO_TLXRL_OFFICE_FOR_SWITCH_BL As String
        Public TLXRL_CODE_FOR_SWITCH_BL As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGPType
        Public ROW_ID As String
        Public ROW_NO As String
        Public MFT_DATE As String
        Public TWEDI_N_TFC_CODE As String
        Public TWEDI_TRANS_PORT As String
        Public MFT_OFFICE As String
        Public C124 As String
        Public C125 As String
        Public FILLER1 As String
        Public MFT_SORT_MARK As String
        Public TWT_VIA_PORT As String
        Public IS_PRT_CTNR_DETAIL As String
        Public IS_WEB_BL_CTNR_ATTACH As String
        Public IS_WEB_AN_CTNR_ATTACH As String
        Public IS_WEB_DO_CTNR_ATTACH As String
        Public IS_WEB_BL_MARK_ATTACH As String
        Public IS_WEB_AN_MARK_ATTACH As String
        Public IS_WEB_DO_MARK_ATTACH As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGQType
        Public ROW_ID As String
        Public ROW_NO As String
        Public ISSUE_MEMO_BL_OB As String
        Public POL_CUSTOMS_ITEM_CODE As String
        Public POD_CUSTOMS_ITEM_CODE As String
        Public NON_CTNR_POL_DEPOT_CODE As String
        Public NON_CTNR_POD_DEPOT_CODE As String
        Public NON_CTNR_VIA_DEPOT_CODE As String
        Public MF_REFERENCE_NO As String
        Public FINISH_USER As String
        Public MFT_FUNCTION As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGRType
        Public ROW_ID As String
        Public ROW_NO As String
        Public C134 As String
        Public C135 As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGSType
        Public ROW_ID As String
        Public ROW_NO As String
        Public TLXRL_CANCEL_REMARK As String
        Public TLXRL_REMARK As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGTType
        Public ROW_ID As String
        Public ROW_NO As String
        Public BL_LIST As String
        Public SO_LIST As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGUType
        Public ROW_ID As String
        Public ROW_NO As String
        Public INCL_COMB As String
        Public INCL_COMB_LIST As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGVType
        Public ROW_ID As String
        Public ROW_NO As String
        Public NANDA_SHPR As String
        Public NANDA_CNEE As String
        Public NANDA_NTFY As String
        Public IS_REGISTER_FDA As String
        Public NANDA_ALSO_NTFY As String
        Public NANDA_POD_FWRD As String
        Public NANDA_POD_BRKR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGWType
        Public ROW_ID As String
        Public ROW_NO As String
        Public ACCOUNT_BULLET_NAME As String
        Public PLAN_OTH_PAYAT_LIST As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGXType
        Public ROW_ID As String
        Public ROW_NO As String
        Public ISF_DECLARE As String
        Public IMPORTER_NO As String
        Public COUNTRY_OF_ORIGIN As String
        Public HTSUS_CODE As String
        Public CTNR_STUFFING_LOC As String
        Public FILLER As String
    End Structure
    Public Structure SegmentMGYType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CNEE_NO As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCGAEType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CHARGE_CODE As String
        Public ACT_PLACE_EX_RATE As String
        Public MEA_UNIT_OF_CHARGE As String
        Public CURR As String
        Public AMOUNT As String
        Public FM_PLACE As String
        Public TO_PLACE As String
        Public PAY_AT As String
        Public PAY_AT_BRANCH As String
        Public PAY_AT_EX_RATE As String
        Public PAY_AT_PC As String
        Public PAID_TERM As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCGBType
        Public ROW_ID As String
        Public ROW_NO As String
        Public PAYER As String
        Public PAYER_DISTRICT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCGCType
        Public ROW_ID As String
        Public ROW_NO As String
        Public FILLER As String
        Public PAYER_REG_CODE As String
        Public PAYER_CODE As String
        Public FILLER1 As String
    End Structure
    Public Structure SegmentCGDType
        Public ROW_ID As String
        Public ROW_NO As String
        Public PRT_SEQ As String
        Public TEMP_PAY_AT As String
        Public TEMP_PAY_AT_BRANCH As String
        Public TEMP_PAY_AT_PC As String
        Public TEMP_PAY_AT_EX_RATE As String
        Public PAYER_TAX_CODE As String
        Public FILLER1 As String
        Public ORG_TRANS_AR_DATE As String
        Public ENTRY_OFFICE As String
        Public ENTRY_USER As String
        Public PAYAT_ORG_TRANS_AR_DATE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public SEAL_CODE As String
        Public WHL_SEAL_CODE As String
        Public CTNR_NO As String
        Public CTNR_OWNER As String
        Public CTNR_TYPE As String
        Public CTNR_FE_MARK As String
        Public CTNR_SIZE As String
        Public CTNR_HEIGHT As String
        Public SPCL_CARGO_LENGTH As String
        Public SPCL_CARGO_WIDTH_TTL As String
        Public SPCL_CARGO_HEIGHT As String
        Public CTNR_UNIT As String
        Public IS_IN_CTNR As String
        Public LPK_CLASS_CODE As String
        Public BELONG_TO_BOOK_NO As String
        Public EDI_SRVC_TYPE As String
        Public ISO_CTNR_TYPE As String
        Public TARE_WEIGHT As String
        Public FILLER As String
        Public Charges As IList(Of SegmentCTREType)
        Public DGPackages As IList(Of SegmentCTHType)
        Public CTIPackages As IList(Of SegmentCTIType)
    End Structure
    Public Structure SegmentCTBType
        Public ROW_ID As String
        Public ROW_NO As String
        Public ITEM_CODE As String
        Public DG_UN_CODE As String
        Public IMDG_CODE As String
        Public IMDG_CODE_PAGE As String
        Public POL_SRVC_TYPE As String
        Public POD_SRVC_TYPE As String

        Public POL_TERM As String
        Public POD_TERM As String
        Public POL_DEPOT_CODE As String
        Public POD_DEPOT_CODE As String
        Public VIA_DEPOT_CODE As String
        Public POL_AREA_CODE_HEADER As String
        Public POL_AREA_CODE_SEQ As String
        Public POD_AREA_CODE_HEADER As String
        Public POD_AREA_CODE_SEQ As String
        Public FILLER1 As String
        Public IS_CFS_THC As String
        Public REF_NO As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTCType
        Public ROW_ID As String
        Public ROW_NO As String
        Public PKG As String
        Public PKG_UNIT As String
        Public CGO_MEASURE As String
        Public MEASURE_UNIT As String
        Public CGO_GROSS_WEIGHT As String
        Public CGO_NET_WEIGHT As String
        Public WEIGHT As String
        Public WEIGHT_UNIT As String
        Public RF_TEMP As String
        Public RF_CF_TYPE As String
        Public RF_RANGE As String
        Public FLASHPOINT_TEMP As String
        Public FLASHPOINT_CF_TYPE As String
        Public EDI_POL_PART_SRVC As String
        Public EDI_POD_PART_SRVC As String
        Public LOWEST_TEMP As String
        Public LOWEST_CF_TYPE As String
        Public RF_TRANS_TEMP As String
        Public POD_CUST_STORING_PLACE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTDType
        Public ROW_ID As String
        Public ROW_NO As String
        Public DAMAGE_REMARK As String
        Public SHUTOUT_MARK As String
        Public SHUTOUT_REMARK As String
        Public SHUTOUT_DATE As String
        Public IS_SHORING As String
        Public IS_CONSOLE As String
        Public IS_TOPPING As String
        Public IS_DOOR_OPEN As String
        Public REVENUE_TON As String
        Public SPCL_CTNR_WIDTH_L As String
        Public SPCL_CTNR_WIDTH_R As String
        Public DOOR_OPEN_LR As String
        Public VENTILATION_TYPE As String
        Public VENTILATION As String
        Public POD_RETURN_DEPOT As String
        Public UNIT_RATE_PCT As String
        Public IS_BUNDLE As String
        Public CTNR_SUBSTITUTE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTEType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_INLAND_TYPE As String
        Public POL_INLAND_REMARK As String
        Public POL_INLAND_FM As String
        Public POL_INLAND_TO As String
        Public POD_INLAND_TYPE As String
        Public POD_INLAND_REMARK As String
        Public POD_INLAND_FM As String
        Public POD_INLAND_TO As String
        Public POL_INLAND_VIA_PORT As String
        Public POD_INLAND_VIA_PORT As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTFType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POL_INLAND_CORP As String
        Public POD_INLAND_CORP As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTGType
        Public ROW_ID As String
        Public ROW_NO As String
        Public OTHERS_REMARK As String
        Public OTHERS_CODE As String
        Public IS_PRT_POL_PART As String
        Public COM_BL_FM_PLACE_KIND As String
        Public IS_PRT_RO As String
        Public SEAL_CODE As String
        Public WHL_SEAL_CODE As String
        Public PLAN_LOAD_CONDITION As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTHType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CODE_TYPE As String
        Public CTNR_SEQ As String
        Public UN_CODE As String
        Public IMDG_CODE As String
        Public IMDG_CODE_PAGE As String
        Public LPK_CLASS_CODE As String
        Public PKG As String
        Public PKG_UNIT As String
        Public CGO_GROSS_WEIGHT As String
        Public ITEM_CODE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTIType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CODE_TYPE As String
        Public CTNR_SEQ As String
        Public MANUFACTURER As String
        Public COUNTRY_OF_ORIGIN As String
        Public HTSUS_CODE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTJType
        Public ROW_ID As String
        Public ROW_NO As String
        Public MANUFACTURER_ADDR As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTKType
        Public ROW_ID As String
        Public ROW_NO As String
        Public POD_DEPOT_REMARK As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTREType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CHG_CODE As String
        Public UNIT_RATE As String
        Public MEA_RATE As String
        Public WGT_RATE As String
        Public FM_PLACE As String
        Public TO_PLACE As String
        Public MIN_RATE As String
        Public CURR As String
        Public FILLER1 As String
        Public PAID_TERM As String
        Public FILLER As String
    End Structure
    Public Structure SegmentCTRAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public CHG_CODE As String
        Public FM_PLACE As String
        Public TO_PLACE As String
        Public CURR As String
        Public APP_ID As String
        Public APP_OFFICE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentEOFType
        Public ROW_ID As String
        Public FILLER As String
    End Structure
    Public Structure SegmentTFAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public LINER_CODE As String
        Public TFC_CODE As String
        Public MFT_TYPE As String
        Public OFFICE_CODE As String
        Public PLR As String
        Public POD As String
        Public PLD As String
        Public FINISH_USER As String
        Public FINISH_OFFICE As String
        Public FINISH_DATE As String
        Public FINISH_PROGRAM As String
        Public ENTRY_FINISH_DATE As String
        Public TW_ENTRY_FINISH_DATE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentTFBType
        Public ROW_ID As String
        Public ROW_NO As String
        Public LINER_CODE As String
        Public TFC_CODE As String
        Public MFT_TYPE As String
        Public OFFICE_CODE As String
        Public PLR As String
        Public POD As String
        Public PLD As String
        Public ENTRY_SERVER As String
        Public FILLER As String
    End Structure
    Public Structure SegmentEXAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public LINER_CODE As String
        Public TFC_CODE As String
        Public PORT As String
        Public MFT_TYPE As String
        Public EX_RATE As String
        Public EX_DATE As String
        Public OB_DATE As String
        Public ISSUE_DATE As String
        Public CLOSED_DATE As String
        Public ENTRY_USER As String
        Public ENTRY_OFFICE As String
        Public FILLER As String
    End Structure
    Public Structure SegmentDBAType
        Public ROW_ID As String
        Public ROW_NO As String
        Public Desc As String
    End Structure
    Private mListOfMFT As IList(Of SegmentMFTType)
    Public ReadOnly Property ListOfMFT() As IList
        Get
            Return mListOfMFT
        End Get
    End Property
    Private mListOfKEY As IList(Of SegmentKEYType)
    Public ReadOnly Property ListOfKEY() As IList
        Get
            Return mListOfKEY
        End Get
    End Property
    Private mListOfBLA As IList(Of SegmentBLAType)
    Public ReadOnly Property ListOfBLA() As IList
        Get
            Return mListOfBLA
        End Get
    End Property
    Private mListOfBLB As IList(Of SegmentBLBType)
    Public ReadOnly Property ListOfBLB() As IList
        Get
            Return mListOfBLB
        End Get
    End Property
    Private mListOfBLC As IList(Of SegmentBLCType)
    Public ReadOnly Property ListOfBLC() As IList
        Get
            Return mListOfBLC
        End Get
    End Property
    Private mListOfBLD As IList(Of SegmentBLDType)
    Public ReadOnly Property ListOfBLD() As IList
        Get
            Return mListOfBLD
        End Get
    End Property
    Private mListOfBLE As IList(Of SegmentBLEType)
    Public ReadOnly Property ListOfBLE() As IList
        Get
            Return mListOfBLE
        End Get
    End Property
    Private mListOfBLF As IList(Of SegmentBLFType)
    Public ReadOnly Property ListOfBLF() As IList
        Get
            Return mListOfBLF
        End Get
    End Property
    Private mListOfBLG As IList(Of SegmentBLGType)
    Public ReadOnly Property ListOfBLG() As IList
        Get
            Return mListOfBLG
        End Get
    End Property
    Private mListOfBLH As IList(Of SegmentBLHType)
    Public ReadOnly Property ListOfBLH() As IList
        Get
            Return mListOfBLH
        End Get
    End Property
    Private mListOfBLI As IList(Of SegmentBLIType)
    Public ReadOnly Property ListOfBLI() As IList
        Get
            Return mListOfBLI
        End Get
    End Property
    Private mListOfBLJ As IList(Of SegmentBLJType)
    Public ReadOnly Property ListOfBLJ() As IList
        Get
            Return mListOfBLJ
        End Get
    End Property
    Private mListOfBLK As IList(Of SegmentBLKType)
    Public ReadOnly Property ListOfBLK() As IList
        Get
            Return mListOfBLK
        End Get
    End Property
    Private mListOfBLL As IList(Of SegmentBLLType)
    Public ReadOnly Property ListOfBLL() As IList
        Get
            Return mListOfBLL
        End Get
    End Property
    Private mListOfBLM As IList(Of SegmentBLMType)
    Public ReadOnly Property ListOfBLM() As IList
        Get
            Return mListOfBLM
        End Get
    End Property
    Private mListOfBLN As IList(Of SegmentBLNType)
    Public ReadOnly Property ListOfBLN() As IList
        Get
            Return mListOfBLN
        End Get
    End Property
    Private mListOfMRK As IList(Of SegmentMRKType)
    Public ReadOnly Property ListOfMRK() As IList
        Get
            Return mListOfMRK
        End Get
    End Property
    Private mListOfDEC As IList(Of SegmentDECType)
    Public ReadOnly Property ListOfDEC() As IList
        Get
            Return mListOfDEC
        End Get
    End Property
    Private mListOfDCM As IList(Of SegmentDCMType)
    Public ReadOnly Property ListOfDCM() As IList
        Get
            Return mListOfDCM
        End Get
    End Property
    Private mListOfLFW As IList(Of SegmentLFWType)
    Public ReadOnly Property ListOfLFW() As IList
        Get
            Return mListOfLFW
        End Get
    End Property
    Private mListOfLFA As IList(Of SegmentLFAType)
    Public ReadOnly Property ListOfLFA() As IList
        Get
            Return mListOfLFA
        End Get
    End Property
    Private mListOfLFF As IList(Of SegmentLFFType)
    Public ReadOnly Property ListOfLFF() As IList
        Get
            Return mListOfLFF
        End Get
    End Property
    Private mListOfLBK As IList(Of SegmentLBKType)
    Public ReadOnly Property ListOfLBK() As IList
        Get
            Return mListOfLBK
        End Get
    End Property
    Private mListOfLBA As IList(Of SegmentLBAType)
    Public ReadOnly Property ListOfLBA() As IList
        Get
            Return mListOfLBA
        End Get
    End Property
    Private mListOfLBF As IList(Of SegmentLBFType)
    Public ReadOnly Property ListOfLBF() As IList
        Get
            Return mListOfLBF
        End Get
    End Property
    Private mListOfLBT As IList(Of SegmentLBTType)
    Public ReadOnly Property ListOfLBT() As IList
        Get
            Return mListOfLBT
        End Get
    End Property
    Private mListOfSPR As IList(Of SegmentSPRType)
    Public ReadOnly Property ListOfSPR() As IList
        Get
            Return mListOfSPR
        End Get
    End Property
    Private mListOfSPA As IList(Of SegmentSPAType)
    Public ReadOnly Property ListOfSPA() As IList
        Get
            Return mListOfSPA
        End Get
    End Property
    Private mListOfSPF As IList(Of SegmentSPFType)
    Public ReadOnly Property ListOfSPF() As IList
        Get
            Return mListOfSPF
        End Get
    End Property
    Private mListOfCSP As IList(Of SegmentCSPType)
    Public ReadOnly Property ListOfCSP() As IList
        Get
            Return mListOfCSP
        End Get
    End Property
    Private mListOfCSA As IList(Of SegmentCSAType)
    Public ReadOnly Property ListOfCSA() As IList
        Get
            Return mListOfCSA
        End Get
    End Property
    Private mListOfCEE As IList(Of SegmentCEEType)
    Public ReadOnly Property ListOfCEE() As IList
        Get
            Return mListOfCEE
        End Get
    End Property
    Private mListOfCEA As IList(Of SegmentCEAType)
    Public ReadOnly Property ListOfCEA() As IList
        Get
            Return mListOfCEA
        End Get
    End Property
    Private mListOfCEF As IList(Of SegmentCEFType)
    Public ReadOnly Property ListOfCEF() As IList
        Get
            Return mListOfCEF
        End Get
    End Property
    Private mListOfCET As IList(Of SegmentCETType)
    Public ReadOnly Property ListOfCET() As IList
        Get
            Return mListOfCET
        End Get
    End Property
    Private mListOfCCE As IList(Of SegmentCCEType)
    Public ReadOnly Property ListOfCCE() As IList
        Get
            Return mListOfCCE
        End Get
    End Property
    Private mListOfCCA As IList(Of SegmentCCAType)
    Public ReadOnly Property ListOfCCA() As IList
        Get
            Return mListOfCCA
        End Get
    End Property
    Private mListOfCEP As IList(Of SegmentCEPType)
    Public ReadOnly Property ListOfCEP() As IList
        Get
            Return mListOfCEP
        End Get
    End Property
    Private mListOfNTF As IList(Of SegmentNTFType)
    Public ReadOnly Property ListOfNTF() As IList
        Get
            Return mListOfNTF
        End Get
    End Property
    Private mListOfNFA As IList(Of SegmentNFAType)
    Public ReadOnly Property ListOfNFA() As IList
        Get
            Return mListOfNFA
        End Get
    End Property
    Private mListOfNFF As IList(Of SegmentNFFType)
    Public ReadOnly Property ListOfNFF() As IList
        Get
            Return mListOfNFF
        End Get
    End Property
    Private mListOfNFT As IList(Of SegmentNFTType)
    Public ReadOnly Property ListOfNFT() As IList
        Get
            Return mListOfNFT
        End Get
    End Property
    Private mListOfCNF As IList(Of SegmentCNFType)
    Public ReadOnly Property ListOfCNF() As IList
        Get
            Return mListOfCNF
        End Get
    End Property
    Private mListOfCNA As IList(Of SegmentCNAType)
    Public ReadOnly Property ListOfCNA() As IList
        Get
            Return mListOfCNA
        End Get
    End Property
    Private mListOfNTP As IList(Of SegmentNTPType)
    Public ReadOnly Property ListOfNTP() As IList
        Get
            Return mListOfNTP
        End Get
    End Property
    Private mListOfANY As IList(Of SegmentANYType)
    Public ReadOnly Property ListOfANY() As IList
        Get
            Return mListOfANY
        End Get
    End Property
    Private mListOfANA As IList(Of SegmentANAType)
    Public ReadOnly Property ListOfANA() As IList
        Get
            Return mListOfANA
        End Get
    End Property
    Private mListOfCAN As IList(Of SegmentCANType)
    Public ReadOnly Property ListOfCAN() As IList
        Get
            Return mListOfCAN
        End Get
    End Property
    Private mListOfCAA As IList(Of SegmentCAAType)
    Public ReadOnly Property ListOfCAA() As IList
        Get
            Return mListOfCAA
        End Get
    End Property
    Private mListOfDFW As IList(Of SegmentDFWType)
    Public ReadOnly Property ListOfDFW() As IList
        Get
            Return mListOfDFW
        End Get
    End Property
    Private mListOfDFA As IList(Of SegmentDFAType)
    Public ReadOnly Property ListOfDFA() As IList
        Get
            Return mListOfDFA
        End Get
    End Property
    Private mListOfDBK As IList(Of SegmentDBKType)
    Public ReadOnly Property ListOfDBK() As IList
        Get
            Return mListOfDBK
        End Get
    End Property
    Private mListOfDBT As IList(Of SegmentDBTType)
    Public ReadOnly Property ListOfDBT() As IList
        Get
            Return mListOfDBT
        End Get
    End Property
    Private mListOfSLR As IList(Of SegmentSLRType)
    Public ReadOnly Property ListOfSLR() As IList
        Get
            Return mListOfSLR
        End Get
    End Property
    Private mListOfSLA As IList(Of SegmentSLAType)
    Public ReadOnly Property ListOfSLA() As IList
        Get
            Return mListOfSLA
        End Get
    End Property
    Private mListOfBYR As IList(Of SegmentBYRType)
    Public ReadOnly Property ListOfBYR() As IList
        Get
            Return mListOfBYR
        End Get
    End Property
    Private mListOfBYA As IList(Of SegmentBYAType)
    Public ReadOnly Property ListOfBYA() As IList
        Get
            Return mListOfBYA
        End Get
    End Property
    Private mListOfMAR As IList(Of SegmentMARType)
    Public ReadOnly Property ListOfMAR() As IList
        Get
            Return mListOfMAR
        End Get
    End Property
    Private mListOfMAA As IList(Of SegmentMAAType)
    Public ReadOnly Property ListOfMAA() As IList
        Get
            Return mListOfMAA
        End Get
    End Property
    Private mListOfSTN As IList(Of SegmentSTNType)
    Public ReadOnly Property ListOfSTN() As IList
        Get
            Return mListOfSTN
        End Get
    End Property
    Private mListOfSTA As IList(Of SegmentSTAType)
    Public ReadOnly Property ListOfSTA() As IList
        Get
            Return mListOfSTA
        End Get
    End Property
    Private mListOfCSR As IList(Of SegmentCSRType)
    Public ReadOnly Property ListOfCSR() As IList
        Get
            Return mListOfCSR
        End Get
    End Property
    Private mListOfCSRA As IList(Of SegmentCSRAType)
    Public ReadOnly Property ListOfCSRA() As IList
        Get
            Return mListOfCSRA
        End Get
    End Property
    Private mListOfBPN As IList(Of SegmentBPNType)
    Public ReadOnly Property ListOfBPN() As IList
        Get
            Return mListOfBPN
        End Get
    End Property
    Private mListOfBPA As IList(Of SegmentBPAType)
    Public ReadOnly Property ListOfBPA() As IList
        Get
            Return mListOfBPA
        End Get
    End Property
    Private mListOfPYO As IList(Of SegmentPYOType)
    Public ReadOnly Property ListOfPYO() As IList
        Get
            Return mListOfPYO
        End Get
    End Property
    Private mListOfPYH As IList(Of SegmentPYHType)
    Public ReadOnly Property ListOfPYH() As IList
        Get
            Return mListOfPYH
        End Get
    End Property
    Private mListOfPYD As IList(Of SegmentPYDType)
    Public ReadOnly Property ListOfPYD() As IList
        Get
            Return mListOfPYD
        End Get
    End Property
    Private mListOfPYT As IList(Of SegmentPYTType)
    Public ReadOnly Property ListOfPYT() As IList
        Get
            Return mListOfPYT
        End Get
    End Property
    Private mListOfMGA As IList(Of SegmentMGAType)
    Public ReadOnly Property ListOfMGA() As IList
        Get
            Return mListOfMGA
        End Get
    End Property
    Private mListOfMGB As IList(Of SegmentMGBType)
    Public ReadOnly Property ListOfMGB() As IList
        Get
            Return mListOfMGB
        End Get
    End Property
    Private mListOfMGC As IList(Of SegmentMGCType)
    Public ReadOnly Property ListOfMGC() As IList
        Get
            Return mListOfMGC
        End Get
    End Property
    Private mListOfMGD As IList(Of SegmentMGDType)
    Public ReadOnly Property ListOfMGD() As IList
        Get
            Return mListOfMGD
        End Get
    End Property
    Private mListOfMGE As IList(Of SegmentMGEType)
    Public ReadOnly Property ListOfMGE() As IList
        Get
            Return mListOfMGE
        End Get
    End Property
    Private mListOfMGF As IList(Of SegmentMGFType)
    Public ReadOnly Property ListOfMGF() As IList
        Get
            Return mListOfMGF
        End Get
    End Property
    Private mListOfMGG As IList(Of SegmentMGGType)
    Public ReadOnly Property ListOfMGG() As IList
        Get
            Return mListOfMGG
        End Get
    End Property
    Private mListOfMGH As IList(Of SegmentMGHType)
    Public ReadOnly Property ListOfMGH() As IList
        Get
            Return mListOfMGH
        End Get
    End Property
    Private mListOfMGI As IList(Of SegmentMGIType)
    Public ReadOnly Property ListOfMGI() As IList
        Get
            Return mListOfMGI
        End Get
    End Property
    Private mListOfMGJ As IList(Of SegmentMGJType)
    Public ReadOnly Property ListOfMGJ() As IList
        Get
            Return mListOfMGJ
        End Get
    End Property
    Private mListOfMGK As IList(Of SegmentMGKType)
    Public ReadOnly Property ListOfMGK() As IList
        Get
            Return mListOfMGK
        End Get
    End Property
    Private mListOfMGL As IList(Of SegmentMGLType)
    Public ReadOnly Property ListOfMGL() As IList
        Get
            Return mListOfMGL
        End Get
    End Property
    Private mListOfMGM As IList(Of SegmentMGMType)
    Public ReadOnly Property ListOfMGM() As IList
        Get
            Return mListOfMGM
        End Get
    End Property
    Private mListOfMGN As IList(Of SegmentMGNType)
    Public ReadOnly Property ListOfMGN() As IList
        Get
            Return mListOfMGN
        End Get
    End Property
    Private mListOfMGO As IList(Of SegmentMGOType)
    Public ReadOnly Property ListOfMGO() As IList
        Get
            Return mListOfMGO
        End Get
    End Property
    Private mListOfMGP As IList(Of SegmentMGPType)
    Public ReadOnly Property ListOfMGP() As IList
        Get
            Return mListOfMGP
        End Get
    End Property
    Private mListOfMGQ As IList(Of SegmentMGQType)
    Public ReadOnly Property ListOfMGQ() As IList
        Get
            Return mListOfMGQ
        End Get
    End Property
    Private mListOfMGR As IList(Of SegmentMGRType)
    Public ReadOnly Property ListOfMGR() As IList
        Get
            Return mListOfMGR
        End Get
    End Property
    Private mListOfMGS As IList(Of SegmentMGSType)
    Public ReadOnly Property ListOfMGS() As IList
        Get
            Return mListOfMGS
        End Get
    End Property
    Private mListOfMGT As IList(Of SegmentMGTType)
    Public ReadOnly Property ListOfMGT() As IList
        Get
            Return mListOfMGT
        End Get
    End Property
    Private mListOfMGU As IList(Of SegmentMGUType)
    Public ReadOnly Property ListOfMGU() As IList
        Get
            Return mListOfMGU
        End Get
    End Property
    Private mListOfMGV As IList(Of SegmentMGVType)
    Public ReadOnly Property ListOfMGV() As IList
        Get
            Return mListOfMGV
        End Get
    End Property
    Private mListOfMGW As IList(Of SegmentMGWType)
    Public ReadOnly Property ListOfMGW() As IList
        Get
            Return mListOfMGW
        End Get
    End Property
    Private mListOfMGX As IList(Of SegmentMGXType)
    Public ReadOnly Property ListOfMGX() As IList
        Get
            Return mListOfMGX
        End Get
    End Property
    Private mListOfMGY As IList(Of SegmentMGYType)
    Public ReadOnly Property ListOfMGY() As IList
        Get
            Return mListOfMGY
        End Get
    End Property
    Private mListOfCGAE As IList(Of SegmentCGAEType)
    Public ReadOnly Property ListOfCGAE() As IList
        Get
            Return mListOfCGAE
        End Get
    End Property
    Private mListOfCGB As IList(Of SegmentCGBType)
    Public ReadOnly Property ListOfCGB() As IList
        Get
            Return mListOfCGB
        End Get
    End Property
    Private mListOfCGC As IList(Of SegmentCGCType)
    Public ReadOnly Property ListOfCGC() As IList
        Get
            Return mListOfCGC
        End Get
    End Property
    Private mListOfCGD As IList(Of SegmentCGDType)
    Public ReadOnly Property ListOfCGD() As IList
        Get
            Return mListOfCGD
        End Get
    End Property
    Private mListOfCTA As IList(Of SegmentCTAType)
    Public ReadOnly Property ListOfCTA() As IList
        Get
            Return mListOfCTA
        End Get
    End Property
    Private mListOfCTB As IList(Of SegmentCTBType)
    Public ReadOnly Property ListOfCTB() As IList
        Get
            Return mListOfCTB
        End Get
    End Property
    Private mListOfCTC As IList(Of SegmentCTCType)
    Public ReadOnly Property ListOfCTC() As IList
        Get
            Return mListOfCTC
        End Get
    End Property
    Private mListOfCTD As IList(Of SegmentCTDType)
    Public ReadOnly Property ListOfCTD() As IList
        Get
            Return mListOfCTD
        End Get
    End Property
    Private mListOfCTE As IList(Of SegmentCTEType)
    Public ReadOnly Property ListOfCTE() As IList
        Get
            Return mListOfCTE
        End Get
    End Property
    Private mListOfCTF As IList(Of SegmentCTFType)
    Public ReadOnly Property ListOfCTF() As IList
        Get
            Return mListOfCTF
        End Get
    End Property
    Private mListOfCTG As IList(Of SegmentCTGType)
    Public ReadOnly Property ListOfCTG() As IList
        Get
            Return mListOfCTG
        End Get
    End Property
    Private mListOfCTH As IList(Of SegmentCTHType)
    Public ReadOnly Property ListOfCTH() As IList
        Get
            Return mListOfCTH
        End Get
    End Property
    Private mListOfCTI As IList(Of SegmentCTIType)
    Public ReadOnly Property ListOfCTI() As IList
        Get
            Return mListOfCTI
        End Get
    End Property
    Private mListOfCTJ As IList(Of SegmentCTJType)
    Public ReadOnly Property ListOfCTJ() As IList
        Get
            Return mListOfCTJ
        End Get
    End Property
    Private mListOfCTK As IList(Of SegmentCTKType)
    Public ReadOnly Property ListOfCTK() As IList
        Get
            Return mListOfCTK
        End Get
    End Property
    Private mListOfCTRE As IList(Of SegmentCTREType)
    Public ReadOnly Property ListOfCTRE() As IList
        Get
            Return mListOfCTRE
        End Get
    End Property
    Private mListOfCTRA As IList(Of SegmentCTRAType)
    Public ReadOnly Property ListOfCTRA() As IList
        Get
            Return mListOfCTRA
        End Get
    End Property
    Private mListOfEOF As IList(Of SegmentEOFType)
    Public ReadOnly Property ListOfEOF() As IList
        Get
            Return mListOfEOF
        End Get
    End Property
    Private mListOfTFA As IList(Of SegmentTFAType)
    Public ReadOnly Property ListOfTFA() As IList
        Get
            Return mListOfTFA
        End Get
    End Property
    Private mListOfTFB As IList(Of SegmentTFBType)
    Public ReadOnly Property ListOfTFB() As IList
        Get
            Return mListOfTFB
        End Get
    End Property
    Private mListOfEXA As IList(Of SegmentEXAType)
    Public ReadOnly Property ListOfEXA() As IList
        Get
            Return mListOfEXA
        End Get
    End Property
    Private mListOfDBA As IList(Of SegmentDBAType)
    Public ReadOnly Property ListOfDBA() As IList
        Get
            Return mListOfDBA
        End Get
    End Property

    Public Sub SegmentMFT(ByVal DataLine As String)
        Dim MFT As SegmentMFTType
        If Len(DataLine) > 10 Then
            MFT.FILE_ID = Mid(DataLine, 1, 6)
            MFT.SENDER_CODE = Mid(DataLine, 7, 16)
            MFT.RECEIVER_CODE = Mid(DataLine, 23, 16)
            MFT.TRANSMISSION_DATE = Mid(DataLine, 39, 8)
            MFT.TRANSMISSION_TIME = Mid(DataLine, 47, 6)
            MFT.TFC_CODE = Mid(DataLine, 53, 10)
            mListOfMFT.Add(MFT)
            sTFCCode = Mid(DataLine, 53, 10)
        End If

    End Sub


    Public Sub SegmentKEY(ByVal DataLine As String)
        Dim KEY As SegmentKEYType
        KEY.ROW_ID = Mid(DataLine, 1, 4)
        KEY.BOOK_NO = Mid(DataLine, 5, 18)
        KEY.SO_NO = Mid(DataLine, 23, 8)
        KEY.MO_NO = Mid(DataLine, 31, 8)
        KEY.TRANS_STATUS = Mid(DataLine, 39, 3)
        KEY.LINER_CODE = Mid(DataLine, 42, 7)
        KEY.OB_DATE = Mid(DataLine, 49, 8)
        KEY.BOOK_PREFIX = Mid(DataLine, 57, 5)
        KEY.BOOK_YEAR = Mid(DataLine, 62, 4)
        KEY.BOOK_SEQ = Mid(DataLine, 66, 10)
        KEY.POL = Mid(DataLine, 76, 5)
        KEY.POD = Mid(DataLine, 81, 5)
        KEY.PLR = Mid(DataLine, 86, 5)
        KEY.PLD = Mid(DataLine, 91, 5)
        KEY.BKG_PLACE = Mid(DataLine, 96, 5)
        KEY.BKG_BRANCH_CODE = Mid(DataLine, 101, 2)
        KEY.CONTRACT_NO = Mid(DataLine, 103, 16)
        KEY.FILLER = Mid(DataLine, 119, 7)
        KEY.BL_MASTER_HOUSE_TYPE_CODE = Mid(DataLine, 126, 2)
        KEY.BL_PROCESS_TYPE = Mid(DataLine, 128, 1)
        mListOfKEY.Add(KEY)
    End Sub
    Public Sub SegmentBLA(ByVal DataLine As String)
        Dim BLA As SegmentBLAType
        BLA.ROW_ID = Mid(DataLine, 1, 4)
        BLA.ROW_NO = Mid(DataLine, 5, 3)
        BLA.BL_VESSEL = Mid(DataLine, 8, 60)
        BLA.BL_VOY_NO = Mid(DataLine, 68, 60)
        BLA.FILLER = Mid(DataLine, 128, 1)
        mListOfBLA.Add(BLA)
    End Sub
    Public Sub SegmentBLB(ByVal DataLine As String)
        Dim BLB As SegmentBLBType
        BLB.ROW_ID = Mid(DataLine, 1, 4)
        BLB.ROW_NO = Mid(DataLine, 5, 3)
        BLB.BL_POL = Mid(DataLine, 8, 60)
        BLB.BL_POD = Mid(DataLine, 68, 60)
        BLB.FILLER = Mid(DataLine, 128, 1)
        mListOfBLB.Add(BLB)
    End Sub
    Public Sub SegmentBLC(ByVal DataLine As String)
        Dim BLC As SegmentBLCType
        BLC.ROW_ID = Mid(DataLine, 1, 4)
        BLC.ROW_NO = Mid(DataLine, 5, 3)
        BLC.BL_PLR = Mid(DataLine, 8, 60)
        BLC.BL_PLD = Mid(DataLine, 68, 60)
        BLC.FILLER = Mid(DataLine, 128, 1)
        mListOfBLC.Add(BLC)
    End Sub
    Public Sub SegmentBLD(ByVal DataLine As String)
        Dim BLD As SegmentBLDType
        BLD.ROW_ID = Mid(DataLine, 1, 4)
        BLD.ROW_NO = Mid(DataLine, 5, 3)
        BLD.BL_DSTN = Mid(DataLine, 8, 60)
        BLD.BL_TTL_PKG = Mid(DataLine, 68, 8)
        BLD.BL_CGO_MEA = Mid(DataLine, 76, 15)
        BLD.BL_CGO_WGT = Mid(DataLine, 91, 15)
        BLD.BL_CGO_NET_WGT = Mid(DataLine, 106, 15)
        BLD.FILLER = Mid(DataLine, 121, 8)
        mListOfBLD.Add(BLD)
    End Sub
    Public Sub SegmentBLE(ByVal DataLine As String)
        Dim BLE As SegmentBLEType
        BLE.ROW_ID = Mid(DataLine, 1, 4)
        BLE.ROW_NO = Mid(DataLine, 5, 3)
        BLE.ISSUE_BL_DATE = Mid(DataLine, 8, 15)
        BLE.ISSUE_DO_DATE = Mid(DataLine, 23, 15)
        BLE.POL_VOICE_CODE = Mid(DataLine, 38, 10)
        BLE.POD_VOICE_CODE = Mid(DataLine, 48, 10)
        BLE.EC_MEMBER_ID = Mid(DataLine, 58, 20)
        BLE.ARRIVAL_DATE = Mid(DataLine, 78, 8)
        BLE.EX_RATE = Mid(DataLine, 86, 18)
        BLE.DO_PASSWD = Mid(DataLine, 104, 5)
        BLE.EC_NTFY_MEMBER_ID = Mid(DataLine, 109, 20)
        mListOfBLE.Add(BLE)
    End Sub
    Public Sub SegmentBLF(ByVal DataLine As String)
        Dim BLF As SegmentBLFType
        BLF.ROW_ID = Mid(DataLine, 1, 4)
        BLF.ROW_NO = Mid(DataLine, 5, 3)
        BLF.POL_REMARK = Mid(DataLine, 8, 80)
        BLF.FILLER = Mid(DataLine, 88, 41)
        mListOfBLF.Add(BLF)
    End Sub
    Public Sub SegmentBLG(ByVal DataLine As String)
        Dim BLG As SegmentBLGType
        BLG.ROW_ID = Mid(DataLine, 1, 4)
        BLG.ROW_NO = Mid(DataLine, 5, 3)
        BLG.POD_REMARK = Mid(DataLine, 8, 80)
        BLG.FILLER = Mid(DataLine, 88, 41)
        mListOfBLG.Add(BLG)
    End Sub
    Public Sub SegmentBLH(ByVal DataLine As String)
        Dim BLH As SegmentBLHType
        BLH.ROW_ID = Mid(DataLine, 1, 4)
        BLH.ROW_NO = Mid(DataLine, 5, 3)
        BLH.BL_PKG_UNIT = Mid(DataLine, 8, 60)
        BLH.BL_WGT_UNIT = Mid(DataLine, 68, 60)
        BLH.FILLER = Mid(DataLine, 128, 1)
        mListOfBLH.Add(BLH)
    End Sub
    Public Sub SegmentBLI(ByVal DataLine As String)
        Dim BLI As SegmentBLIType
        BLI.ROW_ID = Mid(DataLine, 1, 4)
        BLI.ROW_NO = Mid(DataLine, 5, 3)
        BLI.BL_MEA_UNIT = Mid(DataLine, 8, 60)
        BLI.BL_PAID_TERM = Mid(DataLine, 68, 1)
        BLI.BL_PRE_CARRIAGE = Mid(DataLine, 69, 60)
        mListOfBLI.Add(BLI)
    End Sub
    Public Sub SegmentBLJ(ByVal DataLine As String)
        Dim BLJ As SegmentBLJType
        BLJ.ROW_ID = Mid(DataLine, 1, 4)
        BLJ.ROW_NO = Mid(DataLine, 5, 3)
        BLJ.BL_ISSUE_PLACE = Mid(DataLine, 8, 60)
        BLJ.BL_FREIGHT_AT = Mid(DataLine, 68, 60)
        BLJ.FILLER = Mid(DataLine, 128, 1)
        mListOfBLJ.Add(BLJ)
    End Sub
    Public Sub SegmentBLK(ByVal DataLine As String)
        Dim BLK As SegmentBLKType
        BLK.ROW_ID = Mid(DataLine, 1, 4)
        BLK.ROW_NO = Mid(DataLine, 5, 3)
        BLK.VSL_CODE = Mid(DataLine, 8, 6)
        BLK.LOADED_ON = Mid(DataLine, 14, 60)
        BLK.CALL_SIGN = Mid(DataLine, 74, 6)
        BLK.VSL_REG_NO = Mid(DataLine, 80, 10)
        BLK.FILLER = Mid(DataLine, 90, 39)
        mListOfBLK.Add(BLK)
    End Sub
    Public Sub SegmentBLL(ByVal DataLine As String)
        Dim BLL As SegmentBLLType
        BLL.ROW_ID = Mid(DataLine, 1, 4)
        BLL.ROW_NO = Mid(DataLine, 5, 3)
        BLL.FREIGHT_PREPAID_AT = Mid(DataLine, 8, 60)
        BLL.PLACE_OF_ISSUE = Mid(DataLine, 68, 60)
        BLL.FILLER = Mid(DataLine, 128, 1)
        mListOfBLL.Add(BLL)
    End Sub
    Public Sub SegmentBLM(ByVal DataLine As String)
        Dim BLM As SegmentBLMType
        BLM.ROW_ID = Mid(DataLine, 1, 4)
        BLM.ROW_NO = Mid(DataLine, 5, 3)
        BLM.TW_VIA_PORT_NAME = Mid(DataLine, 8, 10)
        BLM.TW_VIA_DATE = Mid(DataLine, 18, 10)
        BLM.DEST_ARRIVAL_DATE = Mid(DataLine, 28, 10)
        BLM.DOC_EXPIRED_DATE = Mid(DataLine, 38, 16)
        BLM.SRVC_TEL_NO = Mid(DataLine, 54, 20)
        BLM.DOC_PIC = Mid(DataLine, 74, 30)
        BLM.FILLER = Mid(DataLine, 104, 25)
        mListOfBLM.Add(BLM)
    End Sub
    Public Sub SegmentBLN(ByVal DataLine As String)
        Dim BLN As SegmentBLNType
        BLN.ROW_ID = Mid(DataLine, 1, 4)
        BLN.ROW_NO = Mid(DataLine, 5, 3)
        BLN.BL_LADEN_ON_BOARD = Mid(DataLine, 8, 60)
        BLN.FILLER = Mid(DataLine, 68, 61)
        mListOfBLN.Add(BLN)
    End Sub
    Public Sub SegmentMRK(ByVal DataLine As String)
        Dim MRK As SegmentMRKType
        MRK.ROW_ID = Mid(DataLine, 1, 4)
        MRK.ROW_NO = Mid(DataLine, 5, 3)
        MRK.MARK = Mid(DataLine, 8, 27)
        MRK.C_INDICATOR = Mid(DataLine, 35, 1)
        MRK.FILLER = Mid(DataLine, 36, 93)
        mListOfMRK.Add(MRK)
    End Sub
    Public Sub SegmentDEC(ByVal DataLine As String)
        Dim DEC As SegmentDECType
        DEC.ROW_ID = Mid(DataLine, 1, 4)
        DEC.ROW_NO = Mid(DataLine, 5, 3)
        DEC.DESCN = Mid(DataLine, 8, 31)
        DEC.C_INDICATOR = Mid(DataLine, 39, 1)
        DEC.FILLER = Mid(DataLine, 40, 89)
        mListOfDEC.Add(DEC)
    End Sub
    Public Sub SegmentDCM(ByVal DataLine As String)
        Dim DCM As SegmentDCMType
        DCM.ROW_ID = Mid(DataLine, 1, 4)
        DCM.ROW_NO = Mid(DataLine, 5, 3)
        DCM.REMARK = Mid(DataLine, 8, 31)
        DCM.FILLER = Mid(DataLine, 39, 90)
        mListOfDCM.Add(DCM)
    End Sub
    Public Sub SegmentLFW(ByVal DataLine As String)
        Dim LFW As SegmentLFWType
        LFW.ROW_ID = Mid(DataLine, 1, 4)
        LFW.ROW_NO = Mid(DataLine, 5, 3)
        LFW.POL_FWRD_CODE = Mid(DataLine, 8, 10)
        LFW.POL_FWRD = Mid(DataLine, 18, 36)
        LFW.FILLER = Mid(DataLine, 54, 75)
        mListOfLFW.Add(LFW)
    End Sub
    Public Sub SegmentLFA(ByVal DataLine As String)
        Dim LFA As SegmentLFAType
        LFA.ROW_ID = Mid(DataLine, 1, 4)
        LFA.ROW_NO = Mid(DataLine, 5, 3)
        LFA.POL_FWRD_ADDR = Mid(DataLine, 8, 36)
        LFA.FILLER = Mid(DataLine, 44, 85)
        mListOfLFA.Add(LFA)
    End Sub
    Public Sub SegmentLFF(ByVal DataLine As String)
        Dim LFF As SegmentLFFType
        LFF.ROW_ID = Mid(DataLine, 1, 4)
        LFF.ROW_NO = Mid(DataLine, 5, 3)
        LFF.POL_FWRD_FAX_HEAD = Mid(DataLine, 8, 6)
        LFF.POL_FWRD_FAX_AREA = Mid(DataLine, 14, 4)
        LFF.POL_FWRD_FAX = Mid(DataLine, 18, 10)
        LFF.FILLER = Mid(DataLine, 28, 101)
        mListOfLFF.Add(LFF)
    End Sub
    Public Sub SegmentLBK(ByVal DataLine As String)
        Dim LBK As SegmentLBKType
        LBK.ROW_ID = Mid(DataLine, 1, 4)
        LBK.ROW_NO = Mid(DataLine, 5, 3)
        LBK.POL_BROKER = Mid(DataLine, 8, 36)
        LBK.FILLER = Mid(DataLine, 44, 85)
        mListOfLBK.Add(LBK)
    End Sub
    Public Sub SegmentLBA(ByVal DataLine As String)
        Dim LBA As SegmentLBAType
        LBA.ROW_ID = Mid(DataLine, 1, 4)
        LBA.ROW_NO = Mid(DataLine, 5, 3)
        LBA.POL_BROKER_ADDR = Mid(DataLine, 8, 36)
        LBA.FILLER = Mid(DataLine, 44, 85)
        mListOfLBA.Add(LBA)
    End Sub
    Public Sub SegmentLBF(ByVal DataLine As String)
        Dim LBF As SegmentLBFType
        LBF.ROW_ID = Mid(DataLine, 1, 4)
        LBF.ROW_NO = Mid(DataLine, 5, 3)
        LBF.POL_BROKER_FAX_HEAD = Mid(DataLine, 8, 6)
        LBF.POL_BROKER_FAX_AREA = Mid(DataLine, 14, 4)
        LBF.POL_BROKER_FAX = Mid(DataLine, 18, 10)
        LBF.FILLER = Mid(DataLine, 28, 101)
        mListOfLBF.Add(LBF)
    End Sub
    Public Sub SegmentLBT(ByVal DataLine As String)
        Dim LBT As SegmentLBTType
        LBT.ROW_ID = Mid(DataLine, 1, 4)
        LBT.ROW_NO = Mid(DataLine, 5, 3)
        LBT.POL_BROKER_TEL_HEAD = Mid(DataLine, 8, 6)
        LBT.POL_BROKER_TEL_AREA = Mid(DataLine, 14, 4)
        LBT.POL_BROKER_TEL = Mid(DataLine, 18, 10)
        LBT.FILLER = Mid(DataLine, 28, 101)
        mListOfLBT.Add(LBT)
    End Sub
    Public Sub SegmentSPR(ByVal DataLine As String)
        Dim SPR As SegmentSPRType
        SPR.ROW_ID = Mid(DataLine, 1, 4)
        SPR.ROW_NO = Mid(DataLine, 5, 3)
        SPR.SHPR = Mid(DataLine, 8, 36)
        SPR.FILLER = Mid(DataLine, 44, 85)
        mListOfSPR.Add(SPR)
    End Sub
    Public Sub SegmentSPA(ByVal DataLine As String)
        Dim SPA As SegmentSPAType
        SPA.ROW_ID = Mid(DataLine, 1, 4)
        SPA.ROW_NO = Mid(DataLine, 5, 3)
        SPA.SHPR_ADDR = Mid(DataLine, 8, 36)
        SPA.FILLER = Mid(DataLine, 44, 85)
        mListOfSPA.Add(SPA)
    End Sub
    Public Sub SegmentSPF(ByVal DataLine As String)
        Dim SPF As SegmentSPFType
        SPF.ROW_ID = Mid(DataLine, 1, 4)
        SPF.ROW_NO = Mid(DataLine, 5, 3)
        SPF.SHPR_FAX_HEAD = Mid(DataLine, 8, 6)
        SPF.SHPR_FAX_AREA = Mid(DataLine, 14, 4)
        SPF.SHPR_FAX = Mid(DataLine, 18, 10)
        SPF.SHPR_MAIL_ACCT = Mid(DataLine, 28, 70)
        SPF.FILLER = Mid(DataLine, 98, 31)
        mListOfSPF.Add(SPF)
    End Sub
    Public Sub SegmentCSP(ByVal DataLine As String)
        Dim CSP As SegmentCSPType
        CSP.ROW_ID = Mid(DataLine, 1, 4)
        CSP.ROW_NO = Mid(DataLine, 5, 3)
        CSP.C_SHPR = Mid(DataLine, 8, 36)
        CSP.FILLER = Mid(DataLine, 44, 85)
        mListOfCSP.Add(CSP)
    End Sub
    Public Sub SegmentCSA(ByVal DataLine As String)
        Dim CSA As SegmentCSAType
        CSA.ROW_ID = Mid(DataLine, 1, 4)
        CSA.ROW_NO = Mid(DataLine, 5, 3)
        CSA.C_SHPR_ADDR = Mid(DataLine, 8, 36)
        CSA.FILLER = Mid(DataLine, 44, 85)
        mListOfCSA.Add(CSA)
    End Sub
    Public Sub SegmentCEE(ByVal DataLine As String)
        Dim CEE As SegmentCEEType
        CEE.ROW_ID = Mid(DataLine, 1, 4)
        CEE.ROW_NO = Mid(DataLine, 5, 3)
        CEE.CONSIGNEE = Mid(DataLine, 8, 36)
        CEE.FILLER = Mid(DataLine, 44, 85)
        mListOfCEE.Add(CEE)
    End Sub
    Public Sub SegmentCEA(ByVal DataLine As String)
        Dim CEA As SegmentCEAType
        CEA.ROW_ID = Mid(DataLine, 1, 4)
        CEA.ROW_NO = Mid(DataLine, 5, 3)
        CEA.CONSIGNEE_ADDR = Mid(DataLine, 8, 36)
        CEA.FILLER = Mid(DataLine, 44, 85)
        mListOfCEA.Add(CEA)
    End Sub
    Public Sub SegmentCEF(ByVal DataLine As String)
        Dim CEF As SegmentCEFType
        CEF.ROW_ID = Mid(DataLine, 1, 4)
        CEF.ROW_NO = Mid(DataLine, 5, 3)
        CEF.CONSIGNEE_FAX_HEAD = Mid(DataLine, 8, 6)
        CEF.CONSIGNEE_FAX_AREA = Mid(DataLine, 14, 4)
        CEF.CONSIGNEE_FAX = Mid(DataLine, 18, 10)
        CEF.CNEE_MAIL_ACCT = Mid(DataLine, 28, 70)
        CEF.FILLER = Mid(DataLine, 98, 31)
        mListOfCEF.Add(CEF)
    End Sub
    Public Sub SegmentCET(ByVal DataLine As String)
        Dim CET As SegmentCETType
        CET.ROW_ID = Mid(DataLine, 1, 4)
        CET.ROW_NO = Mid(DataLine, 5, 3)
        CET.CONSIGNEE_TEL_HEAD = Mid(DataLine, 8, 6)
        CET.CONSIGNEE_TEL_AREA = Mid(DataLine, 14, 4)
        CET.CONSIGNEE_TEL = Mid(DataLine, 18, 10)
        CET.CONSIGNEE_TEL_EXT = Mid(DataLine, 28, 6)
        CET.FILLER = Mid(DataLine, 34, 95)
        mListOfCET.Add(CET)
    End Sub
    Public Sub SegmentCCE(ByVal DataLine As String)
        Dim CCE As SegmentCCEType
        CCE.ROW_ID = Mid(DataLine, 1, 4)
        CCE.ROW_NO = Mid(DataLine, 5, 3)
        CCE.C_CONSIGNEE = Mid(DataLine, 8, 36)
        CCE.FILLER = Mid(DataLine, 44, 85)
        mListOfCCE.Add(CCE)
    End Sub
    Public Sub SegmentCCA(ByVal DataLine As String)
        Dim CCA As SegmentCCAType
        CCA.ROW_ID = Mid(DataLine, 1, 4)
        CCA.ROW_NO = Mid(DataLine, 5, 3)
        CCA.C_CONSIGNEE_ADDR = Mid(DataLine, 8, 36)
        CCA.FILLER = Mid(DataLine, 44, 85)
        mListOfCCA.Add(CCA)
    End Sub
    Public Sub SegmentCEP(ByVal DataLine As String)
        Dim CEP As SegmentCEPType
        CEP.ROW_ID = Mid(DataLine, 1, 4)
        CEP.ROW_NO = Mid(DataLine, 5, 3)
        CEP.CONSIGNEE_PIC = Mid(DataLine, 8, 36)
        CEP.FILLER = Mid(DataLine, 44, 85)
        mListOfCEP.Add(CEP)
    End Sub
    Public Sub SegmentNTF(ByVal DataLine As String)
        Dim NTF As SegmentNTFType
        NTF.ROW_ID = Mid(DataLine, 1, 4)
        NTF.ROW_NO = Mid(DataLine, 5, 3)
        NTF.NOTIFY = Mid(DataLine, 8, 36)
        NTF.FILLER = Mid(DataLine, 44, 85)
        mListOfNTF.Add(NTF)
    End Sub
    Public Sub SegmentNFA(ByVal DataLine As String)
        Dim NFA As SegmentNFAType
        NFA.ROW_ID = Mid(DataLine, 1, 4)
        NFA.ROW_NO = Mid(DataLine, 5, 3)
        NFA.NOTIFY_ADDR = Mid(DataLine, 8, 36)
        NFA.FILLER = Mid(DataLine, 44, 85)
        mListOfNFA.Add(NFA)
    End Sub
    Public Sub SegmentNFF(ByVal DataLine As String)
        Dim NFF As SegmentNFFType
        NFF.ROW_ID = Mid(DataLine, 1, 4)
        NFF.ROW_NO = Mid(DataLine, 5, 3)
        NFF.NOTIFY_FAX_HEAD = Mid(DataLine, 8, 6)
        NFF.NOTIFY_FAX_AREA = Mid(DataLine, 14, 4)
        NFF.NOTIFY_FAX = Mid(DataLine, 18, 10)
        NFF.NTFY_MAIL_ACCT = Mid(DataLine, 28, 70)
        NFF.FILLER = Mid(DataLine, 98, 31)
        mListOfNFF.Add(NFF)
    End Sub
    Public Sub SegmentNFT(ByVal DataLine As String)
        Dim NFT As SegmentNFTType
        NFT.ROW_ID = Mid(DataLine, 1, 4)
        NFT.ROW_NO = Mid(DataLine, 5, 3)
        NFT.NOTIFY_TEL_HEAD = Mid(DataLine, 8, 6)
        NFT.NOTIFY_TEL_AREA = Mid(DataLine, 14, 4)
        NFT.NOTIFY_TEL = Mid(DataLine, 18, 10)
        NFT.NOTIFY_TEL_EXT = Mid(DataLine, 28, 6)
        NFT.FILLER = Mid(DataLine, 34, 95)
        mListOfNFT.Add(NFT)
    End Sub
    Public Sub SegmentCNF(ByVal DataLine As String)
        Dim CNF As SegmentCNFType
        CNF.ROW_ID = Mid(DataLine, 1, 4)
        CNF.ROW_NO = Mid(DataLine, 5, 3)
        CNF.C_NOTIFY = Mid(DataLine, 8, 36)
        CNF.FILLER = Mid(DataLine, 44, 85)
        mListOfCNF.Add(CNF)
    End Sub
    Public Sub SegmentCNA(ByVal DataLine As String)
        Dim CNA As SegmentCNAType
        CNA.ROW_ID = Mid(DataLine, 1, 4)
        CNA.ROW_NO = Mid(DataLine, 5, 3)
        CNA.C_NOTIFY_ADDR = Mid(DataLine, 8, 36)
        CNA.FILLER = Mid(DataLine, 44, 85)
        mListOfCNA.Add(CNA)
    End Sub
    Public Sub SegmentNTP(ByVal DataLine As String)
        Dim NTP As SegmentNTPType
        NTP.ROW_ID = Mid(DataLine, 1, 4)
        NTP.ROW_NO = Mid(DataLine, 5, 3)
        NTP.NTFY_PIC = Mid(DataLine, 8, 36)
        NTP.FILLER = Mid(DataLine, 44, 85)
        mListOfNTP.Add(NTP)
    End Sub
    Public Sub SegmentANY(ByVal DataLine As String)
        Dim ANY As SegmentANYType
        ANY.ROW_ID = Mid(DataLine, 1, 4)
        ANY.ROW_NO = Mid(DataLine, 5, 3)
        ANY.ALSO_NOTIFY = Mid(DataLine, 8, 36)
        ANY.FILLER = Mid(DataLine, 44, 85)
        mListOfANY.Add(ANY)
    End Sub
    Public Sub SegmentANA(ByVal DataLine As String)
        Dim ANA As SegmentANAType
        ANA.ROW_ID = Mid(DataLine, 1, 4)
        ANA.ROW_NO = Mid(DataLine, 5, 3)
        ANA.ALSO_NOTIFY_ADDR = Mid(DataLine, 8, 36)
        ANA.FILLER = Mid(DataLine, 44, 85)
        mListOfANA.Add(ANA)
    End Sub
    Public Sub SegmentCAN(ByVal DataLine As String)
        Dim CAN As SegmentCANType
        CAN.ROW_ID = Mid(DataLine, 1, 4)
        CAN.ROW_NO = Mid(DataLine, 5, 3)
        CAN.C_ALSO_NOTIFY = Mid(DataLine, 8, 36)
        CAN.FILLER = Mid(DataLine, 44, 85)
        mListOfCAN.Add(CAN)
    End Sub
    Public Sub SegmentCAA(ByVal DataLine As String)
        Dim CAA As SegmentCAAType
        CAA.ROW_ID = Mid(DataLine, 1, 4)
        CAA.ROW_NO = Mid(DataLine, 5, 3)
        CAA.C_ALSO_NOTIFY_ADDR = Mid(DataLine, 8, 36)
        CAA.FILLER = Mid(DataLine, 44, 85)
        mListOfCAA.Add(CAA)
    End Sub
    Public Sub SegmentDFW(ByVal DataLine As String)
        Dim DFW As SegmentDFWType
        DFW.ROW_ID = Mid(DataLine, 1, 4)
        DFW.ROW_NO = Mid(DataLine, 5, 3)
        DFW.POD_FWRD_CODE = Mid(DataLine, 8, 10)
        DFW.POD_FWRD = Mid(DataLine, 18, 36)
        DFW.FILLER = Mid(DataLine, 54, 75)
        mListOfDFW.Add(DFW)
    End Sub
    Public Sub SegmentDFA(ByVal DataLine As String)
        Dim DFA As SegmentDFAType
        DFA.ROW_ID = Mid(DataLine, 1, 4)
        DFA.ROW_NO = Mid(DataLine, 5, 3)
        DFA.POD_FWRD_ADDR = Mid(DataLine, 8, 36)
        DFA.FILLER = Mid(DataLine, 44, 85)
        mListOfDFA.Add(DFA)
    End Sub
    Public Sub SegmentDBK(ByVal DataLine As String)
        Dim DBK As SegmentDBKType
        DBK.ROW_ID = Mid(DataLine, 1, 4)
        DBK.ROW_NO = Mid(DataLine, 5, 3)
        DBK.POD_BROKER = Mid(DataLine, 8, 36)
        DBK.FILLER = Mid(DataLine, 44, 85)
        mListOfDBK.Add(DBK)
    End Sub
    Public Sub SegmentDBT(ByVal DataLine As String)
        Dim DBT As SegmentDBTType
        DBT.ROW_ID = Mid(DataLine, 1, 4)
        DBT.ROW_NO = Mid(DataLine, 5, 3)
        DBT.POD_BROKER_TEL_HEAD = Mid(DataLine, 8, 6)
        DBT.POD_BROKER_TEL_AREA = Mid(DataLine, 14, 4)
        DBT.POD_BROKER_TEL = Mid(DataLine, 18, 10)
        DBT.FILLER = Mid(DataLine, 28, 101)
        mListOfDBT.Add(DBT)
    End Sub
    Public Sub SegmentSLR(ByVal DataLine As String)
        Dim SLR As SegmentSLRType
        SLR.ROW_ID = Mid(DataLine, 1, 4)
        SLR.ROW_NO = Mid(DataLine, 5, 3)
        SLR.SELLER = Mid(DataLine, 8, 35)
        SLR.FILLER = Mid(DataLine, 43, 86)
        mListOfSLR.Add(SLR)
    End Sub
    Public Sub SegmentSLA(ByVal DataLine As String)
        Dim SLA As SegmentSLAType
        SLA.ROW_ID = Mid(DataLine, 1, 4)
        SLA.ROW_NO = Mid(DataLine, 5, 3)
        SLA.SELLER_ADDR = Mid(DataLine, 8, 36)
        SLA.FILLER = Mid(DataLine, 44, 85)
        mListOfSLA.Add(SLA)
    End Sub
    Public Sub SegmentBYR(ByVal DataLine As String)
        Dim BYR As SegmentBYRType
        BYR.ROW_ID = Mid(DataLine, 1, 4)
        BYR.ROW_NO = Mid(DataLine, 5, 3)
        BYR.BUYER = Mid(DataLine, 8, 35)
        BYR.FILLER = Mid(DataLine, 43, 86)
        mListOfBYR.Add(BYR)
    End Sub
    Public Sub SegmentBYA(ByVal DataLine As String)
        Dim BYA As SegmentBYAType
        BYA.ROW_ID = Mid(DataLine, 1, 4)
        BYA.ROW_NO = Mid(DataLine, 5, 3)
        BYA.BUYER_ADDR = Mid(DataLine, 8, 36)
        BYA.FILLER = Mid(DataLine, 44, 85)
        mListOfBYA.Add(BYA)
    End Sub
    Public Sub SegmentMAR(ByVal DataLine As String)
        Dim MAR As SegmentMARType
        MAR.ROW_ID = Mid(DataLine, 1, 4)
        MAR.ROW_NO = Mid(DataLine, 5, 3)
        MAR.MANUFACTURER = Mid(DataLine, 8, 35)
        MAR.FILLER = Mid(DataLine, 43, 86)
        mListOfMAR.Add(MAR)
    End Sub
    Public Sub SegmentMAA(ByVal DataLine As String)
        Dim MAA As SegmentMAAType
        MAA.ROW_ID = Mid(DataLine, 1, 4)
        MAA.ROW_NO = Mid(DataLine, 5, 3)
        MAA.MANUFACTURER_ADDR = Mid(DataLine, 8, 36)
        MAA.FILLER = Mid(DataLine, 44, 85)
        mListOfMAA.Add(MAA)
    End Sub
    Public Sub SegmentSTN(ByVal DataLine As String)
        Dim STN As SegmentSTNType
        STN.ROW_ID = Mid(DataLine, 1, 4)
        STN.ROW_NO = Mid(DataLine, 5, 3)
        STN.SHIP_TO = Mid(DataLine, 8, 35)
        STN.FILLER = Mid(DataLine, 43, 86)
        mListOfSTN.Add(STN)
    End Sub
    Public Sub SegmentSTA(ByVal DataLine As String)
        Dim STA As SegmentSTAType
        STA.ROW_ID = Mid(DataLine, 1, 4)
        STA.ROW_NO = Mid(DataLine, 5, 3)
        STA.SHIP_TO_ADDR = Mid(DataLine, 8, 36)
        STA.FILLER = Mid(DataLine, 44, 85)
        mListOfSTA.Add(STA)
    End Sub
    Public Sub SegmentCSR(ByVal DataLine As String)
        Dim CSR As SegmentCSRType
        CSR.ROW_ID = Mid(DataLine, 1, 4)
        CSR.ROW_NO = Mid(DataLine, 5, 3)
        CSR.CONSOLIDATOR = Mid(DataLine, 8, 35)
        CSR.FILLER = Mid(DataLine, 43, 86)
        mListOfCSR.Add(CSR)
    End Sub
    Public Sub SegmentCSRA(ByVal DataLine As String)
        Dim CSRA As SegmentCSRAType
        CSRA.ROW_ID = Mid(DataLine, 1, 4)
        CSRA.ROW_NO = Mid(DataLine, 5, 3)
        CSRA.CONSOLIDATOR_ADDR = Mid(DataLine, 8, 36)
        CSRA.FILLER = Mid(DataLine, 44, 85)
        mListOfCSRA.Add(CSRA)
    End Sub
    Public Sub SegmentBPN(ByVal DataLine As String)
        Dim BPN As SegmentBPNType
        BPN.ROW_ID = Mid(DataLine, 1, 4)
        BPN.ROW_NO = Mid(DataLine, 5, 3)
        BPN.BOOK_PARTY = Mid(DataLine, 8, 35)
        BPN.FILLER = Mid(DataLine, 43, 86)
        mListOfBPN.Add(BPN)
    End Sub
    Public Sub SegmentBPA(ByVal DataLine As String)
        Dim BPA As SegmentBPAType
        BPA.ROW_ID = Mid(DataLine, 1, 4)
        BPA.ROW_NO = Mid(DataLine, 5, 3)
        BPA.BOOK_PARTY_ADDR = Mid(DataLine, 8, 36)
        BPA.FILLER = Mid(DataLine, 44, 85)
        mListOfBPA.Add(BPA)
    End Sub
    Public Sub SegmentPYO(ByVal DataLine As String)
        Dim PYO As SegmentPYOType
        PYO.ROW_ID = Mid(DataLine, 1, 4)
        PYO.ROW_NO = Mid(DataLine, 5, 3)
        PYO.OFT_PAYER = Mid(DataLine, 8, 72)
        PYO.OFT_PAYER_DISTRICT = Mid(DataLine, 80, 20)
        PYO.OFT_PAYER_REG_CODE = Mid(DataLine, 100, 14)
        PYO.FILLER = Mid(DataLine, 114, 15)
        mListOfPYO.Add(PYO)
    End Sub
    Public Sub SegmentPYH(ByVal DataLine As String)
        Dim PYH As SegmentPYHType
        PYH.ROW_ID = Mid(DataLine, 1, 4)
        PYH.ROW_NO = Mid(DataLine, 5, 3)
        PYH.THC_PAYER = Mid(DataLine, 8, 72)
        PYH.THC_PAYER_DISTRICT = Mid(DataLine, 80, 20)
        PYH.THC_PAYER_REG_CODE = Mid(DataLine, 100, 14)
        PYH.FILLER = Mid(DataLine, 114, 15)
        mListOfPYH.Add(PYH)
    End Sub
    Public Sub SegmentPYD(ByVal DataLine As String)
        Dim PYD As SegmentPYDType
        PYD.ROW_ID = Mid(DataLine, 1, 4)
        PYD.ROW_NO = Mid(DataLine, 5, 3)
        PYD.POD_PAYER = Mid(DataLine, 8, 72)
        PYD.POD_PAYER_DISTRICT = Mid(DataLine, 80, 20)
        PYD.FILLER = Mid(DataLine, 100, 29)
        mListOfPYD.Add(PYD)
    End Sub
    Public Sub SegmentPYT(ByVal DataLine As String)
        Dim PYT As SegmentPYTType
        PYT.ROW_ID = Mid(DataLine, 1, 4)
        PYT.ROW_NO = Mid(DataLine, 5, 3)
        PYT.TAP_PAYER = Mid(DataLine, 8, 72)
        PYT.TAP_PAYER_DISTRICT = Mid(DataLine, 80, 20)
        PYT.FILLER = Mid(DataLine, 100, 29)
        mListOfPYT.Add(PYT)
    End Sub
    Public Sub SegmentMGA(ByVal DataLine As String)
        Dim MGA As SegmentMGAType
        MGA.ROW_ID = Mid(DataLine, 1, 4)
        MGA.ROW_NO = Mid(DataLine, 5, 3)
        MGA.FINAL_PORT = Mid(DataLine, 8, 5)
        MGA.FINAL_DESTINATION = Mid(DataLine, 13, 5)
        MGA.IS_FREE_SUR_POL = Mid(DataLine, 18, 1)
        MGA.FILLER1 = Mid(DataLine, 19, 1)
        MGA.IS_FCL_OVER = Mid(DataLine, 20, 1)
        MGA.BL_TYPE = Mid(DataLine, 21, 1)
        MGA.GET_BL_PLACE = Mid(DataLine, 22, 5)
        MGA.OFT_PAYMENT_TYPE = Mid(DataLine, 27, 1)
        MGA.NO_OF_ORGN = Mid(DataLine, 28, 2)
        MGA.ISSUE_BL_DATE = Mid(DataLine, 30, 8)
        MGA.ISSUE_SWITCH_BL_PLACE = Mid(DataLine, 38, 5)
        MGA.ISSUE_MEMO_BL_PLACE = Mid(DataLine, 43, 5)
        MGA.ISSUE_MEMO_BL_TYPE = Mid(DataLine, 48, 1)
        MGA.ORGN_BL_NO = Mid(DataLine, 49, 22)
        MGA.IS_CALC_PMW = Mid(DataLine, 71, 1)
        MGA.IS_CHECK_OK = Mid(DataLine, 72, 1)
        MGA.IS_CALC_CHARGE = Mid(DataLine, 73, 1)
        MGA.FILLER2 = Mid(DataLine, 74, 13)
        MGA.FINISH_DATE = Mid(DataLine, 87, 15)
        MGA.POD_RELEASE_DATE = Mid(DataLine, 102, 15)
        MGA.GET_BL_OFFICE = Mid(DataLine, 117, 7)
        MGA.ISSUE_SWITCH_BL_BRANCH = Mid(DataLine, 124, 2)
        MGA.ISSUE_MEMO_BL_BRANCH = Mid(DataLine, 126, 2)
        MGA.FILLER = Mid(DataLine, 128, 1)
        mListOfMGA.Add(MGA)
    End Sub
    Public Sub SegmentMGB(ByVal DataLine As String)
        Dim MGB As SegmentMGBType
        MGB.ROW_ID = Mid(DataLine, 1, 4)
        MGB.ROW_NO = Mid(DataLine, 5, 3)
        MGB.POL_CUSTOMS_CODE = Mid(DataLine, 8, 6)
        MGB.POD_CUSTOMS_CODE = Mid(DataLine, 14, 6)
        MGB.TTL_PKG = Mid(DataLine, 20, 8)
        MGB.TTL_PKG_UNIT = Mid(DataLine, 28, 4)
        MGB.CGO_MEASURE = Mid(DataLine, 32, 15)
        MGB.CGO_GROSS_WEIGHT = Mid(DataLine, 47, 15)
        MGB.CGO_NET_WEIGHT = Mid(DataLine, 62, 15)
        MGB.ITEM_CODE = Mid(DataLine, 77, 16)
        MGB.IS_PRINT_FREIGHT = Mid(DataLine, 93, 1)
        MGB.IS__PRINT__VSL_CERT = Mid(DataLine, 94, 1)
        MGB.IS__PRINT__SEAL_CODE = Mid(DataLine, 95, 1)
        MGB.IS__PRINT__DEBT_NOTE = Mid(DataLine, 96, 1)
        MGB.IS__PRINT__SHPR = Mid(DataLine, 97, 1)
        MGB.IS__PRINT__SHPR_ADDR = Mid(DataLine, 98, 1)
        MGB.IS__PRINT__C_SHPR = Mid(DataLine, 99, 1)
        MGB.IS__PRINT__C_SHPR_ADDR = Mid(DataLine, 100, 1)
        MGB.IS__PRINT__NTFY = Mid(DataLine, 101, 1)
        MGB.IS__PRINT__NTFY_ADDR = Mid(DataLine, 102, 1)
        MGB.IS__PRINT__C_NTFY = Mid(DataLine, 103, 1)
        MGB.IS__PRINT__C_NTFY_ADDR = Mid(DataLine, 104, 1)
        MGB.IS__PRINT__ALSO_NTFY = Mid(DataLine, 105, 1)
        MGB.IS_PRINT_ALSO_NTFY_ADDR = Mid(DataLine, 106, 1)
        MGB.IS__PRINT__C_ALSO_NTFY = Mid(DataLine, 107, 1)
        MGB.IS_PRINT_C_ALSO_NTFY_ADDR = Mid(DataLine, 108, 1)
        MGB.IS__PRINT__CNEE = Mid(DataLine, 109, 1)
        MGB.IS__PRINT__CNEE_ADDR = Mid(DataLine, 110, 1)
        MGB.IS__PRINT__C_CNEE = Mid(DataLine, 111, 1)
        MGB.IS__PRINT__C_CNEE_ADDR = Mid(DataLine, 112, 1)
        MGB.IS__PRINT__C_MARK = Mid(DataLine, 113, 1)
        MGB.IS__PRINT__C_DESC = Mid(DataLine, 114, 1)
        MGB.IS_CTNR_ATTACH = Mid(DataLine, 115, 1)
        MGB.ATTACH_MARK = Mid(DataLine, 116, 1)
        MGB.MEASURE_PRINT_DECIMAL = Mid(DataLine, 117, 1)
        MGB.MEASURE_UNIT = Mid(DataLine, 118, 4)
        MGB.WEIGHT_UNIT = Mid(DataLine, 122, 4)
        MGB.IS_MONETARY = Mid(DataLine, 126, 1)
        MGB.IS_NON_MONETARY = Mid(DataLine, 127, 1)
        MGB.FILLER = Mid(DataLine, 128, 1)
        mListOfMGB.Add(MGB)
    End Sub
    Public Sub SegmentMGC(ByVal DataLine As String)
        Dim MGC As SegmentMGCType
        MGC.ROW_ID = Mid(DataLine, 1, 4)
        MGC.ROW_NO = Mid(DataLine, 5, 3)
        MGC.INCL_COMB = Mid(DataLine, 8, 1)
        MGC.INCL_COMB_LIST = Mid(DataLine, 9, 80)
        MGC.SCAC_CODE = Mid(DataLine, 89, 10)
        MGC.ISS_CODE = Mid(DataLine, 99, 20)
        MGC.FILLER = Mid(DataLine, 119, 10)
        mListOfMGC.Add(MGC)
    End Sub
    Public Sub SegmentMGD(ByVal DataLine As String)
        Dim MGD As SegmentMGDType
        MGD.ROW_ID = Mid(DataLine, 1, 4)
        MGD.ROW_NO = Mid(DataLine, 5, 3)
        MGD.ALLIN_LIST = Mid(DataLine, 8, 100)
        MGD.ALLIN_CURR = Mid(DataLine, 108, 3)
        MGD.FILLER = Mid(DataLine, 111, 18)
        mListOfMGD.Add(MGD)
    End Sub
    Public Sub SegmentMGE(ByVal DataLine As String)
        Dim MGE As SegmentMGEType
        MGE.ROW_ID = Mid(DataLine, 1, 4)
        MGE.ROW_NO = Mid(DataLine, 5, 3)
        MGE.C131 = Mid(DataLine, 8, 60)
        MGE.C133 = Mid(DataLine, 68, 60)
        MGE.FILLER = Mid(DataLine, 128, 1)
        mListOfMGE.Add(MGE)
    End Sub
    Public Sub SegmentMGF(ByVal DataLine As String)
        Dim MGF As SegmentMGFType
        MGF.ROW_ID = Mid(DataLine, 1, 4)
        MGF.ROW_NO = Mid(DataLine, 5, 3)
        MGF.POL_STORE_PLACE = Mid(DataLine, 8, 8)
        MGF.POD_STORE_PLACE = Mid(DataLine, 16, 8)
        MGF.JV_CODE = Mid(DataLine, 24, 7)
        MGF.PREV_TRANS_PORT = Mid(DataLine, 31, 5)
        MGF.PREV_TFC_CODE = Mid(DataLine, 36, 10)
        MGF.P_TFC_CODE = Mid(DataLine, 46, 10)
        MGF.PLAN_TRANS_PORT = Mid(DataLine, 56, 5)
        MGF.PLAN_N_TFC_CODE = Mid(DataLine, 61, 10)
        MGF.IS_BL_CTNR_ATTACH = Mid(DataLine, 71, 1)
        MGF.IS_BL_MARK_ATTACH = Mid(DataLine, 72, 1)
        MGF.IS_BL_DESC_ATTACH = Mid(DataLine, 73, 1)
        MGF.IS_DO_CTNR_ATTACH = Mid(DataLine, 74, 1)
        MGF.IS_DO_MARK_ATTACH = Mid(DataLine, 75, 1)
        MGF.IS_DO_DESC_ATTACH = Mid(DataLine, 76, 1)
        MGF.IS_AN_CTNR_ATTACH = Mid(DataLine, 77, 1)
        MGF.IS_AN_MARK_ATTACH = Mid(DataLine, 78, 1)
        MGF.IS_AN_DESC_ATTACH = Mid(DataLine, 79, 1)
        MGF.GET_DO_PLACE = Mid(DataLine, 80, 5)
        MGF.GET_DO_BRANCH = Mid(DataLine, 85, 2)
        MGF.IS_PRT_POL_FWRD_ADDR = Mid(DataLine, 87, 1)
        MGF.IS_PRT_POD_FWRD_ADDR = Mid(DataLine, 88, 1)
        MGF.IS_PRT_POL_BRKR_ADDR = Mid(DataLine, 89, 1)
        MGF.IS_PRT_POD_BRKR_ADDR = Mid(DataLine, 90, 1)
        MGF.IS_EMPTY_CTNR = Mid(DataLine, 91, 1)
        MGF.IS_EMPTY_CTNR_DCLR = Mid(DataLine, 92, 1)
        MGF.IS_PRT_CGO_GROSS_WEIGHT = Mid(DataLine, 93, 1)
        MGF.IS_PRT_CGO_NET_WEIGHT = Mid(DataLine, 94, 1)
        MGF.IS_PROHIBIT_CHG = Mid(DataLine, 95, 1)
        MGF.IS_POD_PRT_DB_NOTE = Mid(DataLine, 96, 1)
        MGF.ISSUE_DO_OFFICE = Mid(DataLine, 97, 7)
        MGF.SUMM_CODE = Mid(DataLine, 104, 6)
        MGF.IS_BL_CHARGE_ATTACH = Mid(DataLine, 110, 1)
        MGF.IS_DO_CHARGE_ATTACH = Mid(DataLine, 111, 1)
        MGF.IS_AN_CHARGE_ATTACH = Mid(DataLine, 112, 1)
        MGF.IS_PRT_CGO_MEASURE = Mid(DataLine, 113, 1)
        MGF.IS_PRT_FCL_CLAUSE = Mid(DataLine, 114, 1)
        MGF.IS_PRT_SAY_TTL_CLAUSE = Mid(DataLine, 115, 1)
        MGF.IS_PRT_BL_OB_DATE = Mid(DataLine, 116, 1)
        MGF.IS_PRT_BL_EX_RATE = Mid(DataLine, 117, 1)
        MGF.IS_PRT_BL_ISSUE_DATE = Mid(DataLine, 118, 1)
        MGF.IS_PRT_BL_ATTACHED = Mid(DataLine, 119, 1)
        MGF.IS_CONFIRM_BY_MFT_OFFICE = Mid(DataLine, 120, 1)
        MGF.IS_NEW_BL_AFTER_VOYAGE_FINISH = Mid(DataLine, 121, 1)
        MGF.IS_DUMMY = Mid(DataLine, 122, 1)
        MGF.IS_URGENT_CARGO = Mid(DataLine, 123, 1)
        MGF.FILLER = Mid(DataLine, 124, 5)
        mListOfMGF.Add(MGF)
    End Sub
    Public Sub SegmentMGG(ByVal DataLine As String)
        Dim MGG As SegmentMGGType
        MGG.ROW_ID = Mid(DataLine, 1, 4)
        MGG.ROW_NO = Mid(DataLine, 5, 3)
        MGG.C132 = Mid(DataLine, 8, 60)
        MGG.POL_POD_TERM = Mid(DataLine, 68, 60)
        MGG.FILLER = Mid(DataLine, 128, 1)
        mListOfMGG.Add(MGG)
    End Sub
    Public Sub SegmentMGH(ByVal DataLine As String)
        Dim MGH As SegmentMGHType
        MGH.ROW_ID = Mid(DataLine, 1, 4)
        MGH.ROW_NO = Mid(DataLine, 5, 3)
        MGH.C121 = Mid(DataLine, 8, 30)
        MGH.C122 = Mid(DataLine, 38, 30)
        MGH.C123 = Mid(DataLine, 68, 30)
        MGH.BULK_CARGO_TEU = Mid(DataLine, 98, 3)
        MGH.BULK_CARGO_POL_AREA_CODE = Mid(DataLine, 101, 6)
        MGH.BULK_CARGO_POD_AREA_CODE = Mid(DataLine, 107, 6)
        MGH.SAP_SHIPMENT_NO = Mid(DataLine, 113, 16)
        mListOfMGH.Add(MGH)
    End Sub
    Public Sub SegmentMGI(ByVal DataLine As String)
        Dim MGI As SegmentMGIType
        MGI.ROW_ID = Mid(DataLine, 1, 4)
        MGI.ROW_NO = Mid(DataLine, 5, 3)
        MGI.CUSTOMER_INVOICE_SHIPMENT_NO = Mid(DataLine, 8, 59)
        MGI.ALLOW_PRT_ORIGINAL_BL_EC = Mid(DataLine, 67, 1)
        MGI.TRAN_EC_DATE = Mid(DataLine, 68, 15)
        MGI.TRAN_DO_PASSWD_TO_EC_DATE = Mid(DataLine, 83, 15)
        MGI.EC_DO_PASSWD = Mid(DataLine, 98, 5)
        MGI.COPY_NO = Mid(DataLine, 103, 3)
        MGI.TRUCK_COMPANY_CODE = Mid(DataLine, 106, 12)
        MGI.DEBIT_CODE = Mid(DataLine, 118, 10)
        MGI.FILLER = Mid(DataLine, 128, 1)
        mListOfMGI.Add(MGI)
    End Sub
    Public Sub SegmentMGJ(ByVal DataLine As String)
        Dim MGJ As SegmentMGJType
        MGJ.ROW_ID = Mid(DataLine, 1, 4)
        MGJ.ROW_NO = Mid(DataLine, 5, 3)
        MGJ.POL_EDI_REMARK = Mid(DataLine, 8, 1)
        MGJ.POD_EDI_REMARK = Mid(DataLine, 9, 1)
        MGJ.EDI_TTL_PKG = Mid(DataLine, 10, 8)
        MGJ.EDI_PKG_UNIT = Mid(DataLine, 18, 4)
        MGJ.CUSTOMS_CLEARANCE = Mid(DataLine, 22, 17)
        MGJ.FILLER1 = Mid(DataLine, 39, 2)
        MGJ.EDI_CGO_GROSS_WEIGHT = Mid(DataLine, 41, 15)
        MGJ.CUSTOMS_SO_NO = Mid(DataLine, 56, 16)
        MGJ.FILLER2 = Mid(DataLine, 72, 7)
        MGJ.POL_EDI_STATUS = Mid(DataLine, 79, 1)
        MGJ.POD_EDI_STATUS = Mid(DataLine, 80, 1)
        MGJ.IS_POL_EDI = Mid(DataLine, 81, 1)
        MGJ.IS_POL_DOC_ACCT = Mid(DataLine, 82, 1)
        MGJ.IS_POD_EDI_DOC = Mid(DataLine, 83, 1)
        MGJ.IS_POD_ACCT = Mid(DataLine, 84, 1)
        MGJ.POD_CUSTOMS_DATE = Mid(DataLine, 85, 15)
        MGJ.FIN_LINER_CODE = Mid(DataLine, 100, 7)
        MGJ.FIN_PLR = Mid(DataLine, 107, 5)
        MGJ.FIN_POL = Mid(DataLine, 112, 5)
        MGJ.FIN_POD = Mid(DataLine, 117, 5)
        MGJ.FIN_PLD = Mid(DataLine, 122, 5)
        MGJ.FILLER = Mid(DataLine, 127, 2)
        mListOfMGJ.Add(MGJ)
    End Sub
    Public Sub SegmentMGK(ByVal DataLine As String)
        Dim MGK As SegmentMGKType
        MGK.ROW_ID = Mid(DataLine, 1, 4)
        MGK.ROW_NO = Mid(DataLine, 5, 3)
        MGK.PRT_BL_USER = Mid(DataLine, 8, 10)
        MGK.PRT_BL_OFFICE = Mid(DataLine, 18, 7)
        MGK.PRT_BL_DATE = Mid(DataLine, 25, 15)
        MGK.REPRT_BL_USER = Mid(DataLine, 40, 10)
        MGK.REPRT_BL_OFFICE = Mid(DataLine, 50, 7)
        MGK.REPRT_BL_DATE = Mid(DataLine, 57, 15)
        MGK.ISSUE_TLXRL_TYPE = Mid(DataLine, 72, 1)
        MGK.CONFIRM_TLXRL_USER = Mid(DataLine, 73, 10)
        MGK.CONFIRM_TLXRL_OFFICE = Mid(DataLine, 83, 7)
        MGK.CONFIRM_TLXRL_DATE = Mid(DataLine, 90, 15)
        MGK.TLXRL_TO_PLACE = Mid(DataLine, 105, 5)
        MGK.TLXRL_TO_BRANCH = Mid(DataLine, 110, 2)
        MGK.TLXRL_CODE = Mid(DataLine, 112, 16)
        MGK.IS_PRTED_BL = Mid(DataLine, 128, 1)
        mListOfMGK.Add(MGK)
    End Sub
    Public Sub SegmentMGL(ByVal DataLine As String)
        Dim MGL As SegmentMGLType
        MGL.ROW_ID = Mid(DataLine, 1, 4)
        MGL.ROW_NO = Mid(DataLine, 5, 3)
        MGL.GENERATE_TLXRL_USER = Mid(DataLine, 8, 10)
        MGL.GENERATE_TLXRL_OFFICE = Mid(DataLine, 18, 7)
        MGL.GENERATE_TLXRL_DATE = Mid(DataLine, 25, 15)
        MGL.FILLER1 = Mid(DataLine, 40, 15)
        MGL.ISSUE_NOTICE_TLXRL_USER = Mid(DataLine, 55, 10)
        MGL.ISSUE_NOTICE_TLXRL_OFFICE = Mid(DataLine, 65, 7)
        MGL.ISSUE_NOTICE_TLXRL_DATE = Mid(DataLine, 72, 15)
        MGL.GENERATE_TLXRL_USER_SWITCHBL = Mid(DataLine, 87, 10)
        MGL.GENERATE_TLXRL_OFFICE_SWITCHBL = Mid(DataLine, 97, 7)
        MGL.GENERATE_TLXRL_DATE_SWITCHBL = Mid(DataLine, 104, 15)
        MGL.FILLER = Mid(DataLine, 119, 10)
        mListOfMGL.Add(MGL)
    End Sub
    Public Sub SegmentMGM(ByVal DataLine As String)
        Dim MGM As SegmentMGMType
        MGM.ROW_ID = Mid(DataLine, 1, 4)
        MGM.ROW_NO = Mid(DataLine, 5, 3)
        MGM.BL_FAXOUT_USER = Mid(DataLine, 8, 10)
        MGM.BL_FAXOUT_OFFICE = Mid(DataLine, 18, 7)
        MGM.BL_FAXOUT_DATE = Mid(DataLine, 25, 15)
        MGM.FILLER1 = Mid(DataLine, 40, 5)
        MGM.PRT_DO_USER = Mid(DataLine, 45, 10)
        MGM.PRT_DO_OFFICE = Mid(DataLine, 55, 7)
        MGM.PRT_DO_DATE = Mid(DataLine, 62, 15)
        MGM.REPRT_DO_USER = Mid(DataLine, 77, 10)
        MGM.REPRT_DO_OFFICE = Mid(DataLine, 87, 7)
        MGM.REPRT_DO_DATE = Mid(DataLine, 94, 15)
        MGM.HOLD_CHG_USER = Mid(DataLine, 109, 10)
        MGM.HOLD_CHG_OFFICE = Mid(DataLine, 119, 7)
        MGM.FILLER = Mid(DataLine, 126, 3)
        mListOfMGM.Add(MGM)
    End Sub
    Public Sub SegmentMGN(ByVal DataLine As String)
        Dim MGN As SegmentMGNType
        MGN.ROW_ID = Mid(DataLine, 1, 4)
        MGN.ROW_NO = Mid(DataLine, 5, 3)
        MGN.HOLD_CHG_DATE = Mid(DataLine, 8, 15)
        MGN.HOLD_CHG = Mid(DataLine, 23, 1)
        MGN.HOLD_CHG_REMARK = Mid(DataLine, 24, 100)
        MGN.FILLER = Mid(DataLine, 124, 5)
        mListOfMGN.Add(MGN)
    End Sub
    Public Sub SegmentMGO(ByVal DataLine As String)
        Dim MGO As SegmentMGOType
        MGO.ROW_ID = Mid(DataLine, 1, 4)
        MGO.ROW_NO = Mid(DataLine, 5, 3)
        MGO.PRT_POL_MF_USER = Mid(DataLine, 8, 10)
        MGO.PRT_POL_MF_OFFICE = Mid(DataLine, 18, 7)
        MGO.PRT_POL_MF_DATE = Mid(DataLine, 25, 15)
        MGO.PRT_POD_MF_USER = Mid(DataLine, 40, 10)
        MGO.PRT_POD_MF_OFFICE = Mid(DataLine, 50, 7)
        MGO.PRT_POD_MF_DATE = Mid(DataLine, 57, 15)
        MGO.PRT_TRS_MF_USER = Mid(DataLine, 72, 10)
        MGO.PRT_TRS_MF_OFFICE = Mid(DataLine, 82, 7)
        MGO.PRT_TRS_MF_DATE = Mid(DataLine, 89, 15)
        MGO.TO_TLXRL_OFFICE_FOR_SWITCH_BL = Mid(DataLine, 104, 7)
        MGO.TLXRL_CODE_FOR_SWITCH_BL = Mid(DataLine, 111, 16)
        MGO.FILLER = Mid(DataLine, 127, 2)
        mListOfMGO.Add(MGO)
    End Sub
    Public Sub SegmentMGP(ByVal DataLine As String)
        Dim MGP As SegmentMGPType
        MGP.ROW_ID = Mid(DataLine, 1, 4)
        MGP.ROW_NO = Mid(DataLine, 5, 3)
        MGP.MFT_DATE = Mid(DataLine, 8, 15)
        MGP.TWEDI_N_TFC_CODE = Mid(DataLine, 23, 10)
        MGP.TWEDI_TRANS_PORT = Mid(DataLine, 33, 5)
        MGP.MFT_OFFICE = Mid(DataLine, 38, 7)
        MGP.C124 = Mid(DataLine, 45, 30)
        MGP.C125 = Mid(DataLine, 75, 30)
        MGP.FILLER1 = Mid(DataLine, 105, 6)
        MGP.MFT_SORT_MARK = Mid(DataLine, 111, 5)
        MGP.TWT_VIA_PORT = Mid(DataLine, 116, 5)
        MGP.IS_PRT_CTNR_DETAIL = Mid(DataLine, 121, 1)
        MGP.IS_WEB_BL_CTNR_ATTACH = Mid(DataLine, 122, 1)
        MGP.IS_WEB_AN_CTNR_ATTACH = Mid(DataLine, 123, 1)
        MGP.IS_WEB_DO_CTNR_ATTACH = Mid(DataLine, 124, 1)
        MGP.IS_WEB_BL_MARK_ATTACH = Mid(DataLine, 125, 1)
        MGP.IS_WEB_AN_MARK_ATTACH = Mid(DataLine, 126, 1)
        MGP.IS_WEB_DO_MARK_ATTACH = Mid(DataLine, 127, 1)
        MGP.FILLER = Mid(DataLine, 128, 1)
        mListOfMGP.Add(MGP)
    End Sub
    Public Sub SegmentMGQ(ByVal DataLine As String)
        Dim MGQ As SegmentMGQType
        MGQ.ROW_ID = Mid(DataLine, 1, 4)
        MGQ.ROW_NO = Mid(DataLine, 5, 3)
        MGQ.ISSUE_MEMO_BL_OB = Mid(DataLine, 8, 36)
        MGQ.POL_CUSTOMS_ITEM_CODE = Mid(DataLine, 44, 20)
        MGQ.POD_CUSTOMS_ITEM_CODE = Mid(DataLine, 64, 20)
        MGQ.NON_CTNR_POL_DEPOT_CODE = Mid(DataLine, 84, 5)
        MGQ.NON_CTNR_POD_DEPOT_CODE = Mid(DataLine, 89, 5)
        MGQ.NON_CTNR_VIA_DEPOT_CODE = Mid(DataLine, 94, 5)
        MGQ.MF_REFERENCE_NO = Mid(DataLine, 99, 15)
        MGQ.FINISH_USER = Mid(DataLine, 114, 10)
        MGQ.MFT_FUNCTION = Mid(DataLine, 124, 3)
        MGQ.FILLER = Mid(DataLine, 127, 2)
        mListOfMGQ.Add(MGQ)
    End Sub
    Public Sub SegmentMGR(ByVal DataLine As String)
        Dim MGR As SegmentMGRType
        MGR.ROW_ID = Mid(DataLine, 1, 4)
        MGR.ROW_NO = Mid(DataLine, 5, 3)
        MGR.C134 = Mid(DataLine, 8, 60)
        MGR.C135 = Mid(DataLine, 68, 60)
        MGR.FILLER = Mid(DataLine, 128, 1)
        mListOfMGR.Add(MGR)
    End Sub
    Public Sub SegmentMGS(ByVal DataLine As String)
        Dim MGS As SegmentMGSType
        MGS.ROW_ID = Mid(DataLine, 1, 4)
        MGS.ROW_NO = Mid(DataLine, 5, 3)
        MGS.TLXRL_CANCEL_REMARK = Mid(DataLine, 8, 60)
        MGS.TLXRL_REMARK = Mid(DataLine, 68, 60)
        MGS.FILLER = Mid(DataLine, 128, 1)
        mListOfMGS.Add(MGS)
    End Sub
    Public Sub SegmentMGT(ByVal DataLine As String)
        Dim MGT As SegmentMGTType
        MGT.ROW_ID = Mid(DataLine, 1, 4)
        MGT.ROW_NO = Mid(DataLine, 5, 3)
        MGT.BL_LIST = Mid(DataLine, 8, 60)
        MGT.SO_LIST = Mid(DataLine, 68, 60)
        MGT.FILLER = Mid(DataLine, 128, 1)
        mListOfMGT.Add(MGT)
    End Sub
    Public Sub SegmentMGU(ByVal DataLine As String)
        Dim MGU As SegmentMGUType
        MGU.ROW_ID = Mid(DataLine, 1, 4)
        MGU.ROW_NO = Mid(DataLine, 5, 3)
        MGU.INCL_COMB = Mid(DataLine, 8, 1)
        MGU.INCL_COMB_LIST = Mid(DataLine, 9, 80)
        MGU.FILLER = Mid(DataLine, 89, 40)
        mListOfMGU.Add(MGU)
    End Sub
    Public Sub SegmentMGV(ByVal DataLine As String)
        Dim MGV As SegmentMGVType
        MGV.ROW_ID = Mid(DataLine, 1, 4)
        MGV.ROW_NO = Mid(DataLine, 5, 3)
        MGV.NANDA_SHPR = Mid(DataLine, 8, 6)
        MGV.NANDA_CNEE = Mid(DataLine, 14, 6)
        MGV.NANDA_NTFY = Mid(DataLine, 20, 6)
        MGV.IS_REGISTER_FDA = Mid(DataLine, 26, 1)
        MGV.NANDA_ALSO_NTFY = Mid(DataLine, 27, 6)
        MGV.NANDA_POD_FWRD = Mid(DataLine, 33, 6)
        MGV.NANDA_POD_BRKR = Mid(DataLine, 39, 6)
        MGV.FILLER = Mid(DataLine, 45, 84)
        mListOfMGV.Add(MGV)
    End Sub
    Public Sub SegmentMGW(ByVal DataLine As String)
        Dim MGW As SegmentMGWType
        MGW.ROW_ID = Mid(DataLine, 1, 4)
        MGW.ROW_NO = Mid(DataLine, 5, 3)
        MGW.ACCOUNT_BULLET_NAME = Mid(DataLine, 8, 72)
        MGW.PLAN_OTH_PAYAT_LIST = Mid(DataLine, 80, 35)
        MGW.FILLER = Mid(DataLine, 115, 14)
        mListOfMGW.Add(MGW)
    End Sub
    Public Sub SegmentMGX(ByVal DataLine As String)
        Dim MGX As SegmentMGXType
        MGX.ROW_ID = Mid(DataLine, 1, 4)
        MGX.ROW_NO = Mid(DataLine, 5, 3)
        MGX.ISF_DECLARE = Mid(DataLine, 8, 1)
        MGX.IMPORTER_NO = Mid(DataLine, 9, 30)
        MGX.COUNTRY_OF_ORIGIN = Mid(DataLine, 39, 2)
        MGX.HTSUS_CODE = Mid(DataLine, 41, 10)
        MGX.CTNR_STUFFING_LOC = Mid(DataLine, 51, 35)
        MGX.FILLER = Mid(DataLine, 86, 110)
        mListOfMGX.Add(MGX)
    End Sub
    Public Sub SegmentMGY(ByVal DataLine As String)
        Dim MGY As SegmentMGYType
        MGY.ROW_ID = Mid(DataLine, 1, 4)
        MGY.ROW_NO = Mid(DataLine, 5, 3)
        MGY.CNEE_NO = Mid(DataLine, 8, 120)
        MGY.FILLER = Mid(DataLine, 128, 1)
        mListOfMGY.Add(MGY)
    End Sub
    Public Sub SegmentCGAE(ByVal DataLine As String)
        Dim CGAE As SegmentCGAEType
        CGAE.ROW_ID = Mid(DataLine, 1, 4)
        CGAE.ROW_NO = Mid(DataLine, 5, 3)
        CGAE.CHARGE_CODE = Mid(DataLine, 8, 4)
        CGAE.ACT_PLACE_EX_RATE = Mid(DataLine, 12, 18)
        CGAE.MEA_UNIT_OF_CHARGE = Mid(DataLine, 30, 3)
        CGAE.CURR = Mid(DataLine, 33, 3)
        CGAE.AMOUNT = Mid(DataLine, 36, 18)
        CGAE.FM_PLACE = Mid(DataLine, 54, 8)
        CGAE.TO_PLACE = Mid(DataLine, 62, 8)
        CGAE.PAY_AT = Mid(DataLine, 70, 5)
        CGAE.PAY_AT_BRANCH = Mid(DataLine, 75, 2)
        CGAE.PAY_AT_EX_RATE = Mid(DataLine, 77, 18)
        CGAE.PAY_AT_PC = Mid(DataLine, 95, 1)
        CGAE.PAID_TERM = Mid(DataLine, 96, 1)
        CGAE.FILLER = Mid(DataLine, 97, 32)
        mListOfCGAE.Add(CGAE)
    End Sub
    Public Sub SegmentCGB(ByVal DataLine As String)
        Dim CGB As SegmentCGBType
        CGB.ROW_ID = Mid(DataLine, 1, 4)
        CGB.ROW_NO = Mid(DataLine, 5, 3)
        CGB.PAYER = Mid(DataLine, 8, 72)
        CGB.PAYER_DISTRICT = Mid(DataLine, 80, 20)
        CGB.FILLER = Mid(DataLine, 100, 29)
        mListOfCGB.Add(CGB)
    End Sub
    Public Sub SegmentCGC(ByVal DataLine As String)
        Dim CGC As SegmentCGCType
        CGC.ROW_ID = Mid(DataLine, 1, 4)
        CGC.ROW_NO = Mid(DataLine, 5, 3)
        CGC.FILLER = Mid(DataLine, 8, 26)
        CGC.PAYER_REG_CODE = Mid(DataLine, 34, 14)
        CGC.PAYER_CODE = Mid(DataLine, 48, 36)
        CGC.FILLER1 = Mid(DataLine, 84, 45)
        mListOfCGC.Add(CGC)
    End Sub
    Public Sub SegmentCGD(ByVal DataLine As String)
        Dim CGD As SegmentCGDType
        CGD.ROW_ID = Mid(DataLine, 1, 4)
        CGD.ROW_NO = Mid(DataLine, 5, 3)
        CGD.PRT_SEQ = Mid(DataLine, 8, 4)
        CGD.TEMP_PAY_AT = Mid(DataLine, 12, 5)
        CGD.TEMP_PAY_AT_BRANCH = Mid(DataLine, 17, 2)
        CGD.TEMP_PAY_AT_PC = Mid(DataLine, 19, 1)
        CGD.TEMP_PAY_AT_EX_RATE = Mid(DataLine, 20, 15)
        CGD.PAYER_TAX_CODE = Mid(DataLine, 35, 10)
        CGD.FILLER1 = Mid(DataLine, 45, 1)
        CGD.ORG_TRANS_AR_DATE = Mid(DataLine, 46, 15)
        CGD.ENTRY_OFFICE = Mid(DataLine, 61, 7)
        CGD.ENTRY_USER = Mid(DataLine, 68, 10)
        CGD.PAYAT_ORG_TRANS_AR_DATE = Mid(DataLine, 78, 15)
        CGD.FILLER = Mid(DataLine, 93, 36)
        mListOfCGD.Add(CGD)
    End Sub
    Public Sub SegmentCTA(ByVal DataLine As String)
        Dim CTA As New SegmentCTAType
        CTA.Charges = New List(Of SegmentCTREType)
        CTA.DGPackages = New List(Of SegmentCTHType)
        CTA.CTIPackages = New List(Of SegmentCTIType)
        CTA.ROW_ID = Mid(DataLine, 1, 4)
        CTA.ROW_NO = Mid(DataLine, 5, 3)
        CTA.SEAL_CODE = Mid(DataLine, 8, 12)
        CTA.WHL_SEAL_CODE = Mid(DataLine, 20, 12)
        CTA.CTNR_NO = Mid(DataLine, 32, 12)
        CTA.CTNR_OWNER = Mid(DataLine, 44, 1)
        CTA.CTNR_TYPE = Mid(DataLine, 45, 2)
        CTA.CTNR_FE_MARK = Mid(DataLine, 47, 2)
        CTA.CTNR_SIZE = Mid(DataLine, 49, 2)
        CTA.CTNR_HEIGHT = Mid(DataLine, 51, 2)
        CTA.SPCL_CARGO_LENGTH = Mid(DataLine, 53, 6)
        CTA.SPCL_CARGO_WIDTH_TTL = Mid(DataLine, 59, 6)
        CTA.SPCL_CARGO_HEIGHT = Mid(DataLine, 65, 6)
        CTA.CTNR_UNIT = Mid(DataLine, 71, 3)
        CTA.IS_IN_CTNR = Mid(DataLine, 74, 1)
        CTA.LPK_CLASS_CODE = Mid(DataLine, 75, 1)
        CTA.BELONG_TO_BOOK_NO = Mid(DataLine, 76, 18)
        CTA.EDI_SRVC_TYPE = Mid(DataLine, 94, 1)
        CTA.ISO_CTNR_TYPE = Mid(DataLine, 95, 4)
        CTA.TARE_WEIGHT = TWByCnSizeCnTypeHight(CTA.CTNR_SIZE, CTA.CTNR_TYPE, CTA.CTNR_HEIGHT) '  Mid(DataLine, 99, 10)
        CTA.FILLER = Mid(DataLine, 109, 20)




        mListOfCTA.Add(CTA)
        CurrentCTA = CTA
        CurrentCTH = CTA
        CurrentCTI = CTA


    End Sub
    Public Sub SegmentCTB(ByVal DataLine As String)
        Dim CTB As SegmentCTBType
        CTB.ROW_ID = Mid(DataLine, 1, 4)
        CTB.ROW_NO = Mid(DataLine, 5, 3)
        CTB.ITEM_CODE = Mid(DataLine, 8, 16)
        CTB.DG_UN_CODE = Mid(DataLine, 24, 4)
        CTB.IMDG_CODE = Mid(DataLine, 28, 3)
        CTB.IMDG_CODE_PAGE = Mid(DataLine, 31, 6)
        CTB.POL_SRVC_TYPE = Mid(DataLine, 37, 10)
        CTB.POD_SRVC_TYPE = Mid(DataLine, 47, 10)
        CTB.POL_TERM = Mid(DataLine, 57, 8)
        CTB.POD_TERM = Mid(DataLine, 65, 8)
        CTB.POL_DEPOT_CODE = Mid(DataLine, 73, 5)
        CTB.POD_DEPOT_CODE = Mid(DataLine, 78, 5)
        CTB.VIA_DEPOT_CODE = Mid(DataLine, 83, 5)
        CTB.POL_AREA_CODE_HEADER = Mid(DataLine, 88, 3)
        CTB.POL_AREA_CODE_SEQ = Mid(DataLine, 91, 3)
        CTB.POD_AREA_CODE_HEADER = Mid(DataLine, 94, 3)
        CTB.POD_AREA_CODE_SEQ = Mid(DataLine, 97, 3)
        CTB.FILLER1 = Mid(DataLine, 100, 16)
        CTB.IS_CFS_THC = Mid(DataLine, 116, 1)
        CTB.REF_NO = Mid(DataLine, 117, 10)
        CTB.FILLER = Mid(DataLine, 127, 2)
        mListOfCTB.Add(CTB)
    End Sub
    Public Sub SegmentCTC(ByVal DataLine As String)
        Dim CTC As SegmentCTCType
        CTC.ROW_ID = Mid(DataLine, 1, 4)
        CTC.ROW_NO = Mid(DataLine, 5, 3)
        CTC.PKG = Mid(DataLine, 8, 8)
        CTC.PKG_UNIT = Mid(DataLine, 16, 3)
        CTC.CGO_MEASURE = Mid(DataLine, 19, 10)
        CTC.MEASURE_UNIT = Mid(DataLine, 29, 3)
        CTC.CGO_GROSS_WEIGHT = Mid(DataLine, 32, 10)
        CTC.CGO_NET_WEIGHT = Mid(DataLine, 42, 10)
        CTC.WEIGHT = Mid(DataLine, 52, 10)
        CTC.WEIGHT_UNIT = Mid(DataLine, 62, 3)
        CTC.RF_TEMP = Mid(DataLine, 65, 4)
        CTC.RF_CF_TYPE = Mid(DataLine, 69, 3)
        CTC.RF_RANGE = Mid(DataLine, 72, 20)
        CTC.FLASHPOINT_TEMP = Mid(DataLine, 92, 4)
        CTC.FLASHPOINT_CF_TYPE = Mid(DataLine, 96, 3)
        CTC.EDI_POL_PART_SRVC = Mid(DataLine, 99, 1)
        CTC.EDI_POD_PART_SRVC = Mid(DataLine, 100, 1)
        CTC.LOWEST_TEMP = Mid(DataLine, 101, 4)
        CTC.LOWEST_CF_TYPE = Mid(DataLine, 105, 3)
        CTC.RF_TRANS_TEMP = Mid(DataLine, 108, 4)
        CTC.POD_CUST_STORING_PLACE = Mid(DataLine, 112, 8)
        CTC.FILLER = Mid(DataLine, 120, 9)
        mListOfCTC.Add(CTC)
    End Sub
    Public Sub SegmentCTD(ByVal DataLine As String)
        Dim CTD As SegmentCTDType
        CTD.ROW_ID = Mid(DataLine, 1, 4)
        CTD.ROW_NO = Mid(DataLine, 5, 3)
        CTD.DAMAGE_REMARK = Mid(DataLine, 8, 30)
        CTD.SHUTOUT_MARK = Mid(DataLine, 38, 1)
        CTD.SHUTOUT_REMARK = Mid(DataLine, 39, 30)
        CTD.SHUTOUT_DATE = Mid(DataLine, 69, 8)
        CTD.IS_SHORING = Mid(DataLine, 77, 1)
        CTD.IS_CONSOLE = Mid(DataLine, 78, 1)
        CTD.IS_TOPPING = Mid(DataLine, 79, 1)
        CTD.IS_DOOR_OPEN = Mid(DataLine, 80, 1)
        CTD.REVENUE_TON = Mid(DataLine, 81, 6)
        CTD.SPCL_CTNR_WIDTH_L = Mid(DataLine, 87, 6)
        CTD.SPCL_CTNR_WIDTH_R = Mid(DataLine, 93, 6)
        CTD.DOOR_OPEN_LR = Mid(DataLine, 99, 1)
        CTD.VENTILATION_TYPE = Mid(DataLine, 100, 4)
        CTD.VENTILATION = Mid(DataLine, 104, 6)
        CTD.POD_RETURN_DEPOT = Mid(DataLine, 110, 5)
        CTD.UNIT_RATE_PCT = Mid(DataLine, 115, 6)
        CTD.IS_BUNDLE = Mid(DataLine, 121, 1)
        CTD.CTNR_SUBSTITUTE = Mid(DataLine, 122, 1)
        CTD.FILLER = Mid(DataLine, 123, 6)
        mListOfCTD.Add(CTD)
    End Sub
    Public Sub SegmentCTE(ByVal DataLine As String)
        Dim CTE As SegmentCTEType
        CTE.ROW_ID = Mid(DataLine, 1, 4)
        CTE.ROW_NO = Mid(DataLine, 5, 3)
        CTE.POL_INLAND_TYPE = Mid(DataLine, 8, 2)
        CTE.POL_INLAND_REMARK = Mid(DataLine, 10, 30)
        CTE.POL_INLAND_FM = Mid(DataLine, 40, 5)
        CTE.POL_INLAND_TO = Mid(DataLine, 45, 5)
        CTE.POD_INLAND_TYPE = Mid(DataLine, 50, 2)
        CTE.POD_INLAND_REMARK = Mid(DataLine, 52, 30)
        CTE.POD_INLAND_FM = Mid(DataLine, 82, 5)
        CTE.POD_INLAND_TO = Mid(DataLine, 87, 5)
        CTE.POL_INLAND_VIA_PORT = Mid(DataLine, 92, 5)
        CTE.POD_INLAND_VIA_PORT = Mid(DataLine, 97, 5)
        CTE.FILLER = Mid(DataLine, 102, 27)
        mListOfCTE.Add(CTE)
    End Sub
    Public Sub SegmentCTF(ByVal DataLine As String)
        Dim CTF As SegmentCTFType
        CTF.ROW_ID = Mid(DataLine, 1, 4)
        CTF.ROW_NO = Mid(DataLine, 5, 3)
        CTF.POL_INLAND_CORP = Mid(DataLine, 8, 36)
        CTF.POD_INLAND_CORP = Mid(DataLine, 44, 36)
        CTF.FILLER = Mid(DataLine, 80, 49)
        mListOfCTF.Add(CTF)
    End Sub
    Public Sub SegmentCTG(ByVal DataLine As String)
        Dim CTG As SegmentCTGType
        CTG.ROW_ID = Mid(DataLine, 1, 4)
        CTG.ROW_NO = Mid(DataLine, 5, 3)
        CTG.OTHERS_REMARK = Mid(DataLine, 8, 30)
        CTG.OTHERS_CODE = Mid(DataLine, 38, 2)
        CTG.IS_PRT_POL_PART = Mid(DataLine, 40, 1)
        CTG.COM_BL_FM_PLACE_KIND = Mid(DataLine, 41, 1)
        CTG.IS_PRT_RO = Mid(DataLine, 42, 1)
        CTG.SEAL_CODE = Mid(DataLine, 43, 20)
        CTG.WHL_SEAL_CODE = Mid(DataLine, 63, 20)
        CTG.PLAN_LOAD_CONDITION = Mid(DataLine, 83, 39)
        CTG.FILLER = Mid(DataLine, 122, 7)
        mListOfCTG.Add(CTG)
    End Sub
    Public Sub SegmentCTH(ByVal DataLine As String)
        Dim CTH As SegmentCTHType
        CTH.ROW_ID = Mid(DataLine, 1, 4)
        CTH.ROW_NO = Mid(DataLine, 5, 3)
        CTH.CODE_TYPE = Mid(DataLine, 8, 4)
        CTH.CTNR_SEQ = Mid(DataLine, 12, 18)
        CTH.UN_CODE = Mid(DataLine, 30, 4)
        CTH.IMDG_CODE = Mid(DataLine, 34, 3)
        CTH.IMDG_CODE_PAGE = Mid(DataLine, 37, 6)
        CTH.LPK_CLASS_CODE = Mid(DataLine, 43, 1)
        CTH.PKG = Mid(DataLine, 44, 8)
        CTH.PKG_UNIT = Mid(DataLine, 52, 3)
        CTH.CGO_GROSS_WEIGHT = Mid(DataLine, 55, 10)
        CTH.ITEM_CODE = Mid(DataLine, 65, 20)
        CTH.FILLER = Mid(DataLine, 85, 44)
        mListOfCTH.Add(CTH)
        If CurrentCTH.DGPackages Is Nothing Then
            CurrentCTH.DGPackages = New List(Of SegmentCTHType)
        End If
        CurrentCTH.DGPackages.Add(CTH)
    End Sub
    Public Sub SegmentCTI(ByVal DataLine As String)
        Dim CTI As SegmentCTIType
        CTI.ROW_ID = Mid(DataLine, 1, 4)
        CTI.ROW_NO = Mid(DataLine, 5, 3)
        CTI.CODE_TYPE = Mid(DataLine, 8, 4)
        CTI.CTNR_SEQ = Mid(DataLine, 12, 18)
        CTI.MANUFACTURER = Mid(DataLine, 30, 35)
        CTI.COUNTRY_OF_ORIGIN = Mid(DataLine, 65, 2)
        CTI.HTSUS_CODE = Mid(DataLine, 67, 10)
        CTI.FILLER = Mid(DataLine, 77, 89)
        mListOfCTI.Add(CTI)
        If CurrentCTI.CTIPackages Is Nothing Then
            CurrentCTI.CTIPackages = New List(Of SegmentCTIType)
        End If
        CurrentCTI.CTIPackages.Add(CTI)
    End Sub
    Public Sub SegmentCTJ(ByVal DataLine As String)
        Dim CTJ As SegmentCTJType
        CTJ.ROW_ID = Mid(DataLine, 1, 4)
        CTJ.ROW_NO = Mid(DataLine, 5, 3)
        CTJ.MANUFACTURER_ADDR = Mid(DataLine, 8, 36)
        CTJ.FILLER = Mid(DataLine, 44, 85)
        mListOfCTJ.Add(CTJ)
    End Sub
    Public Sub SegmentCTK(ByVal DataLine As String)
        Dim CTK As New SegmentCTKType
        CTK.ROW_ID = Mid(DataLine, 1, 4)
        CTK.ROW_NO = Mid(DataLine, 5, 3)
        CTK.POD_DEPOT_REMARK = Mid(DataLine, 8, 100)
        CTK.FILLER = Mid(DataLine, 108, 21)
        mListOfCTK.Add(CTK)
    End Sub
    Public Sub SegmentCTRE(ByVal DataLine As String)
        Dim CTRE As SegmentCTREType
        CTRE.ROW_ID = Mid(DataLine, 1, 4)
        CTRE.ROW_NO = Mid(DataLine, 5, 3)
        CTRE.CHG_CODE = Mid(DataLine, 8, 4)
        CTRE.UNIT_RATE = Mid(DataLine, 12, 18)
        CTRE.MEA_RATE = Mid(DataLine, 30, 18)
        CTRE.WGT_RATE = Mid(DataLine, 48, 18)
        CTRE.FM_PLACE = Mid(DataLine, 66, 8)
        CTRE.TO_PLACE = Mid(DataLine, 74, 8)
        CTRE.MIN_RATE = Mid(DataLine, 82, 18)
        CTRE.CURR = Mid(DataLine, 100, 3)
        CTRE.FILLER1 = Mid(DataLine, 103, 20)
        CTRE.PAID_TERM = Mid(DataLine, 123, 1)
        CTRE.FILLER = Mid(DataLine, 124, 5)
        mListOfCTRE.Add(CTRE)
        If CurrentCTA.Charges Is Nothing Then
            CurrentCTA.Charges = New List(Of SegmentCTREType)
        End If
        CurrentCTA.Charges.Add(CTRE)
    End Sub
    Public Sub SegmentCTRA(ByVal DataLine As String)
        Dim CTRA As SegmentCTRAType
        CTRA.ROW_ID = Mid(DataLine, 1, 4)
        CTRA.ROW_NO = Mid(DataLine, 5, 3)
        CTRA.CHG_CODE = Mid(DataLine, 8, 4)
        CTRA.FM_PLACE = Mid(DataLine, 12, 8)
        CTRA.TO_PLACE = Mid(DataLine, 20, 8)
        CTRA.CURR = Mid(DataLine, 28, 3)
        CTRA.APP_ID = Mid(DataLine, 31, 18)
        CTRA.APP_OFFICE = Mid(DataLine, 49, 7)
        CTRA.FILLER = Mid(DataLine, 56, 73)
        mListOfCTRA.Add(CTRA)
    End Sub
    Public Sub SegmentEOF(ByVal DataLine As String)
        Dim EOF As SegmentEOFType
        EOF.ROW_ID = Mid(DataLine, 1, 3)
        EOF.FILLER = Mid(DataLine, 4, 125)
        mListOfEOF.Add(EOF)
    End Sub
    Public Sub SegmentTFA(ByVal DataLine As String)
        Dim TFA As SegmentTFAType
        TFA.ROW_ID = Mid(DataLine, 1, 4)
        TFA.ROW_NO = Mid(DataLine, 5, 3)
        TFA.LINER_CODE = Mid(DataLine, 8, 7)
        TFA.TFC_CODE = Mid(DataLine, 15, 10)
        TFA.MFT_TYPE = Mid(DataLine, 25, 3)
        TFA.OFFICE_CODE = Mid(DataLine, 28, 7)
        TFA.PLR = Mid(DataLine, 35, 5)
        TFA.POD = Mid(DataLine, 40, 5)
        TFA.PLD = Mid(DataLine, 45, 5)
        TFA.FINISH_USER = Mid(DataLine, 50, 10)
        TFA.FINISH_OFFICE = Mid(DataLine, 60, 7)
        TFA.FINISH_DATE = Mid(DataLine, 67, 15)
        TFA.FINISH_PROGRAM = Mid(DataLine, 82, 8)
        TFA.ENTRY_FINISH_DATE = Mid(DataLine, 90, 15)
        TFA.TW_ENTRY_FINISH_DATE = Mid(DataLine, 105, 15)
        TFA.FILLER = Mid(DataLine, 120, 9)
        mListOfTFA.Add(TFA)
    End Sub
    Public Sub SegmentTFB(ByVal DataLine As String)
        Dim TFB As SegmentTFBType
        TFB.ROW_ID = Mid(DataLine, 1, 4)
        TFB.ROW_NO = Mid(DataLine, 5, 3)
        TFB.LINER_CODE = Mid(DataLine, 8, 7)
        TFB.TFC_CODE = Mid(DataLine, 15, 10)
        TFB.MFT_TYPE = Mid(DataLine, 25, 3)
        TFB.OFFICE_CODE = Mid(DataLine, 28, 7)
        TFB.PLR = Mid(DataLine, 35, 5)
        TFB.POD = Mid(DataLine, 40, 5)
        TFB.PLD = Mid(DataLine, 45, 5)
        TFB.ENTRY_SERVER = Mid(DataLine, 50, 30)
        TFB.FILLER = Mid(DataLine, 80, 49)
        mListOfTFB.Add(TFB)
    End Sub
    Public Sub SegmentEXA(ByVal DataLine As String)
        Dim EXA As SegmentEXAType
        EXA.ROW_ID = Mid(DataLine, 1, 4)
        EXA.ROW_NO = Mid(DataLine, 5, 3)
        EXA.LINER_CODE = Mid(DataLine, 8, 7)
        EXA.TFC_CODE = Mid(DataLine, 15, 10)
        EXA.PORT = Mid(DataLine, 25, 5)
        EXA.MFT_TYPE = Mid(DataLine, 30, 1)
        EXA.EX_RATE = Mid(DataLine, 31, 18)
        EXA.EX_DATE = Mid(DataLine, 49, 15)
        EXA.OB_DATE = Mid(DataLine, 64, 15)
        EXA.ISSUE_DATE = Mid(DataLine, 79, 15)
        EXA.CLOSED_DATE = Mid(DataLine, 94, 15)
        EXA.ENTRY_USER = Mid(DataLine, 109, 10)
        EXA.ENTRY_OFFICE = Mid(DataLine, 119, 7)
        EXA.FILLER = Mid(DataLine, 126, 3)
        mListOfEXA.Add(EXA)
    End Sub
    Public Sub SegmentDBA(ByVal DataLine As String)
        Dim DBA As SegmentDBAType
        DBA.ROW_ID = Mid(DataLine, 1, 4)
        DBA.ROW_NO = Mid(DataLine, 5, 3)
        DBA.Desc = Mid(DataLine, 8)
        mListOfDBA.Add(DBA)
    End Sub


    Public Sub ExtractDataLine(ByVal DataLine As String)
        Dim RowID As String = Trim(Mid(DataLine, 1, 4))
        Select Case RowID
            Case "MFT"
                SegmentMFT(DataLine)
            Case "KEY"
                SegmentKEY(DataLine)
            Case "BLA"
                SegmentBLA(DataLine)
            Case "BLB"
                SegmentBLB(DataLine)
            Case "BLC"
                SegmentBLC(DataLine)
            Case "BLD"
                SegmentBLD(DataLine)
            Case "BLE"
                SegmentBLE(DataLine)
            Case "BLF"
                SegmentBLF(DataLine)
            Case "BLG"
                SegmentBLG(DataLine)
            Case "BLH"
                SegmentBLH(DataLine)
            Case "BLI"
                SegmentBLI(DataLine)
            Case "BLJ"
                SegmentBLJ(DataLine)
            Case "BLK"
                SegmentBLK(DataLine)
            Case "BLL"
                SegmentBLL(DataLine)
            Case "BLM"
                SegmentBLM(DataLine)
            Case "BLN"
                SegmentBLN(DataLine)
            Case "MRK"
                SegmentMRK(DataLine)
            Case "DEC"
                SegmentDEC(DataLine)
            Case "DCM"
                SegmentDCM(DataLine)
            Case "LFW"
                SegmentLFW(DataLine)
            Case "LFA"
                SegmentLFA(DataLine)
            Case "LFF"
                SegmentLFF(DataLine)
            Case "LBK"
                SegmentLBK(DataLine)
            Case "LBA"
                SegmentLBA(DataLine)
            Case "LBF"
                SegmentLBF(DataLine)
            Case "LBT"
                SegmentLBT(DataLine)
            Case "SPR"
                SegmentSPR(DataLine)
            Case "SPA"
                SegmentSPA(DataLine)
            Case "SPF"
                SegmentSPF(DataLine)
            Case "CSP"
                SegmentCSP(DataLine)
            Case "CSA"
                SegmentCSA(DataLine)
            Case "CEE"
                SegmentCEE(DataLine)
            Case "CEA"
                SegmentCEA(DataLine)
            Case "CEF"
                SegmentCEF(DataLine)
            Case "CET"
                SegmentCET(DataLine)
            Case "CCE"
                SegmentCCE(DataLine)
            Case "CCA"
                SegmentCCA(DataLine)
            Case "CEP"
                SegmentCEP(DataLine)
            Case "NTF"
                SegmentNTF(DataLine)
            Case "NFA"
                SegmentNFA(DataLine)
            Case "NFF"
                SegmentNFF(DataLine)
            Case "NFT"
                SegmentNFT(DataLine)
            Case "CNF"
                SegmentCNF(DataLine)
            Case "CNA"
                SegmentCNA(DataLine)
            Case "NTP"
                SegmentNTP(DataLine)
            Case "ANY"
                SegmentANY(DataLine)
            Case "ANA"
                SegmentANA(DataLine)
            Case "CAN"
                SegmentCAN(DataLine)
            Case "CAA"
                SegmentCAA(DataLine)
            Case "DFW"
                SegmentDFW(DataLine)
            Case "DFA"
                SegmentDFA(DataLine)
            Case "DBK"
                SegmentDBK(DataLine)
            Case "DBT"
                SegmentDBT(DataLine)
            Case "SLR"
                SegmentSLR(DataLine)
            Case "SLA"
                SegmentSLA(DataLine)
            Case "BYR"
                SegmentBYR(DataLine)
            Case "BYA"
                SegmentBYA(DataLine)
            Case "MAR"
                SegmentMAR(DataLine)
            Case "MAA"
                SegmentMAA(DataLine)
            Case "STN"
                SegmentSTN(DataLine)
            Case "STA"
                SegmentSTA(DataLine)
            Case "CSR"
                SegmentCSR(DataLine)
            Case "CSRA"
                SegmentCSRA(DataLine)
            Case "BPN"
                SegmentBPN(DataLine)
            Case "BPA"
                SegmentBPA(DataLine)
            Case "PYO"
                SegmentPYO(DataLine)
            Case "PYH"
                SegmentPYH(DataLine)
            Case "PYD"
                SegmentPYD(DataLine)
            Case "PYT"
                SegmentPYT(DataLine)
            Case "MGA"
                SegmentMGA(DataLine)
            Case "MGB"
                SegmentMGB(DataLine)
            Case "MGC"
                SegmentMGC(DataLine)
            Case "MGD"
                SegmentMGD(DataLine)
            Case "MGE"
                SegmentMGE(DataLine)
            Case "MGF"
                SegmentMGF(DataLine)
            Case "MGG"
                SegmentMGG(DataLine)
            Case "MGH"
                SegmentMGH(DataLine)
            Case "MGI"
                SegmentMGI(DataLine)
            Case "MGJ"
                SegmentMGJ(DataLine)
            Case "MGK"
                SegmentMGK(DataLine)
            Case "MGL"
                SegmentMGL(DataLine)
            Case "MGM"
                SegmentMGM(DataLine)
            Case "MGN"
                SegmentMGN(DataLine)
            Case "MGO"
                SegmentMGO(DataLine)
            Case "MGP"
                SegmentMGP(DataLine)
            Case "MGQ"
                SegmentMGQ(DataLine)
            Case "MGR"
                SegmentMGR(DataLine)
            Case "MGS"
                SegmentMGS(DataLine)
            Case "MGT"
                SegmentMGT(DataLine)
            Case "MGU"
                SegmentMGU(DataLine)
            Case "MGV"
                SegmentMGV(DataLine)
            Case "MGW"
                SegmentMGW(DataLine)
            Case "MGX"
                SegmentMGX(DataLine)
            Case "MGY"
                SegmentMGY(DataLine)
            Case "CGAE"
                SegmentCGAE(DataLine)
            Case "CGB"
                SegmentCGB(DataLine)
            Case "CGC"
                SegmentCGC(DataLine)
            Case "CGD"
                SegmentCGD(DataLine)
            Case "CTA"
                SegmentCTA(DataLine)
            Case "CTB"
                SegmentCTB(DataLine)
            Case "CTC"
                SegmentCTC(DataLine)
            Case "CTD"
                SegmentCTD(DataLine)
            Case "CTE"
                SegmentCTE(DataLine)
            Case "CTF"
                SegmentCTF(DataLine)
            Case "CTG"
                SegmentCTG(DataLine)
            Case "CTH"
                SegmentCTH(DataLine)
            Case "CTI"
                SegmentCTI(DataLine)
            Case "CTJ"
                SegmentCTJ(DataLine)
            Case "CTK"
                SegmentCTK(DataLine)
            Case "CTRE"
                SegmentCTRE(DataLine)
            Case "CTRA"
                SegmentCTRA(DataLine)
            Case "EOF"
                SegmentEOF(DataLine)
            Case "TFA"
                SegmentTFA(DataLine)
            Case "TFB"
                SegmentTFB(DataLine)
            Case "EXA"
                SegmentEXA(DataLine)
            Case "DBA"
                SegmentDBA(DataLine)
            Case Else
                If Mid(RowID, 1, 3) = "MFT" Then
                    SegmentMFT(DataLine)
                Else
                    SegmentMFT(DataLine)
                    If ListOfSkipedSegment.IndexOf(RowID) = -1 Then
                        ListOfSkipedSegment.Add(RowID)
                    End If

                End If
        End Select
    End Sub
    Public Sub New()

        mListOfMFT = New List(Of SegmentMFTType)
        mListOfKEY = New List(Of SegmentKEYType)
        mListOfBLA = New List(Of SegmentBLAType)
        mListOfBLB = New List(Of SegmentBLBType)
        mListOfBLC = New List(Of SegmentBLCType)
        mListOfBLD = New List(Of SegmentBLDType)
        mListOfBLE = New List(Of SegmentBLEType)
        mListOfBLF = New List(Of SegmentBLFType)
        mListOfBLG = New List(Of SegmentBLGType)
        mListOfBLH = New List(Of SegmentBLHType)
        mListOfBLI = New List(Of SegmentBLIType)
        mListOfBLJ = New List(Of SegmentBLJType)
        mListOfBLK = New List(Of SegmentBLKType)
        mListOfBLL = New List(Of SegmentBLLType)
        mListOfBLM = New List(Of SegmentBLMType)
        mListOfBLN = New List(Of SegmentBLNType)
        mListOfMRK = New List(Of SegmentMRKType)
        mListOfDEC = New List(Of SegmentDECType)
        mListOfDCM = New List(Of SegmentDCMType)
        mListOfLFW = New List(Of SegmentLFWType)
        mListOfLFA = New List(Of SegmentLFAType)
        mListOfLFF = New List(Of SegmentLFFType)
        mListOfLBK = New List(Of SegmentLBKType)
        mListOfLBA = New List(Of SegmentLBAType)
        mListOfLBF = New List(Of SegmentLBFType)
        mListOfLBT = New List(Of SegmentLBTType)
        mListOfSPR = New List(Of SegmentSPRType)
        mListOfSPA = New List(Of SegmentSPAType)
        mListOfSPF = New List(Of SegmentSPFType)
        mListOfCSP = New List(Of SegmentCSPType)
        mListOfCSA = New List(Of SegmentCSAType)
        mListOfCEE = New List(Of SegmentCEEType)
        mListOfCEA = New List(Of SegmentCEAType)
        mListOfCEF = New List(Of SegmentCEFType)
        mListOfCET = New List(Of SegmentCETType)
        mListOfCCE = New List(Of SegmentCCEType)
        mListOfCCA = New List(Of SegmentCCAType)
        mListOfCEP = New List(Of SegmentCEPType)
        mListOfNTF = New List(Of SegmentNTFType)
        mListOfNFA = New List(Of SegmentNFAType)
        mListOfNFF = New List(Of SegmentNFFType)
        mListOfNFT = New List(Of SegmentNFTType)
        mListOfCNF = New List(Of SegmentCNFType)
        mListOfCNA = New List(Of SegmentCNAType)
        mListOfNTP = New List(Of SegmentNTPType)
        mListOfANY = New List(Of SegmentANYType)
        mListOfANA = New List(Of SegmentANAType)
        mListOfCAN = New List(Of SegmentCANType)
        mListOfCAA = New List(Of SegmentCAAType)
        mListOfDFW = New List(Of SegmentDFWType)
        mListOfDFA = New List(Of SegmentDFAType)
        mListOfDBK = New List(Of SegmentDBKType)
        mListOfDBT = New List(Of SegmentDBTType)
        mListOfSLR = New List(Of SegmentSLRType)
        mListOfSLA = New List(Of SegmentSLAType)
        mListOfBYR = New List(Of SegmentBYRType)
        mListOfBYA = New List(Of SegmentBYAType)
        mListOfMAR = New List(Of SegmentMARType)
        mListOfMAA = New List(Of SegmentMAAType)
        mListOfSTN = New List(Of SegmentSTNType)
        mListOfSTA = New List(Of SegmentSTAType)
        mListOfCSR = New List(Of SegmentCSRType)
        mListOfCSRA = New List(Of SegmentCSRAType)
        mListOfBPN = New List(Of SegmentBPNType)
        mListOfBPA = New List(Of SegmentBPAType)
        mListOfPYO = New List(Of SegmentPYOType)
        mListOfPYH = New List(Of SegmentPYHType)
        mListOfPYD = New List(Of SegmentPYDType)
        mListOfPYT = New List(Of SegmentPYTType)
        mListOfMGA = New List(Of SegmentMGAType)
        mListOfMGB = New List(Of SegmentMGBType)
        mListOfMGC = New List(Of SegmentMGCType)
        mListOfMGD = New List(Of SegmentMGDType)
        mListOfMGE = New List(Of SegmentMGEType)
        mListOfMGF = New List(Of SegmentMGFType)
        mListOfMGG = New List(Of SegmentMGGType)
        mListOfMGH = New List(Of SegmentMGHType)
        mListOfMGI = New List(Of SegmentMGIType)
        mListOfMGJ = New List(Of SegmentMGJType)
        mListOfMGK = New List(Of SegmentMGKType)
        mListOfMGL = New List(Of SegmentMGLType)
        mListOfMGM = New List(Of SegmentMGMType)
        mListOfMGN = New List(Of SegmentMGNType)
        mListOfMGO = New List(Of SegmentMGOType)
        mListOfMGP = New List(Of SegmentMGPType)
        mListOfMGQ = New List(Of SegmentMGQType)
        mListOfMGR = New List(Of SegmentMGRType)
        mListOfMGS = New List(Of SegmentMGSType)
        mListOfMGT = New List(Of SegmentMGTType)
        mListOfMGU = New List(Of SegmentMGUType)
        mListOfMGV = New List(Of SegmentMGVType)
        mListOfMGW = New List(Of SegmentMGWType)
        mListOfMGX = New List(Of SegmentMGXType)
        mListOfMGY = New List(Of SegmentMGYType)
        mListOfCGAE = New List(Of SegmentCGAEType)
        mListOfCGB = New List(Of SegmentCGBType)
        mListOfCGC = New List(Of SegmentCGCType)
        mListOfCGD = New List(Of SegmentCGDType)
        mListOfCTA = New List(Of SegmentCTAType)
        mListOfCTB = New List(Of SegmentCTBType)
        mListOfCTC = New List(Of SegmentCTCType)
        mListOfCTD = New List(Of SegmentCTDType)
        mListOfCTE = New List(Of SegmentCTEType)
        mListOfCTF = New List(Of SegmentCTFType)
        mListOfCTG = New List(Of SegmentCTGType)
        mListOfCTH = New List(Of SegmentCTHType)
        mListOfCTI = New List(Of SegmentCTIType)
        mListOfCTJ = New List(Of SegmentCTJType)
        mListOfCTK = New List(Of SegmentCTKType)
        mListOfCTRE = New List(Of SegmentCTREType)
        mListOfCTRA = New List(Of SegmentCTRAType)
        mListOfEOF = New List(Of SegmentEOFType)
        mListOfTFA = New List(Of SegmentTFAType)
        mListOfTFB = New List(Of SegmentTFBType)
        mListOfEXA = New List(Of SegmentEXAType)
        mListOfDBA = New List(Of SegmentDBAType)

    End Sub

    Public ReadOnly Property SkipedSegments() As ArrayList
        Get
            Return ListOfSkipedSegment
        End Get
    End Property

    Public ReadOnly Property TFCCode() As String
        Get
            TFCCode = sTfcCode
        End Get
    End Property


End Class
