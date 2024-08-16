Public Class CLDPAStructure

    Partial Public Class BOL
        Private S As String
        Private mBILLOFLADINGNO As String = ""
        Private mBOXPARTNERINGLINE As String = ""
        Private mBOXPARTNERINGAGENT As String = ""
        Private mPORTCODEOFORIGIN As String = ""
        Private mPORTCODEOFLOADING As String = ""
        Private mPORTCODEOFDISCHARGE As String = ""
        Private mPORTCODEOFDESTINATION As String = ""
        Private mDATEOFLOADING As String = ""
        Private mMANIFESTREGISTRATION As String = ""
        Private mTRADECODE As String = ""
        Private mTRANSSHIPMENTMODE As String = ""
        Private mBILLOFLADINGOWNERNAME As String = ""
        Private mBILLOFLADINGOWNERADDRESS As String = ""
        Private mCARGOCODE As String = ""
        Private mCONSOLIDATEDCARGO As String = ""
        Private mSTORAGEREQUESTCODE As String = ""
        Private mCONTAINERSERVICETYPE As String = ""
        Private mCOUNTRYOFORIGIN As String = ""
        Private mORIGINALCONSIGNEENAME As String = ""
        Private mORIGINALCONSIGNEE As String = ""
        Private mORIGINALVESSELNAME As String = ""
        Private mORIGINALVOYAGENUMBER As String = ""
        Private mORIGINALBOLNUMBER As String = ""
        Private mORIGINALSHIPPERNAME As String = ""
        Private mORIGINALSHIPPERADDRESS As String = ""
        Private mSHIPPERNAME As String = ""
        Private mSHIPPERADDRESS As String = ""
        Private mSHIPPERCOUNTRYCODE As String = ""
        Private mCONSIGNEECODE As String = ""
        Private mCONSIGNEENAME As String = ""
        Private mCONSIGNEEADDRESS As String = ""
        Private mNOTIFY1CODE As String = ""
        Private mNOTIFY1NAME As String = ""
        Private mNOTIFY1ADDRESS As String = ""
        Private mNOTIFY2CODE As String = ""
        Private mNOTIFY2NAME As String = ""
        Private mNOTIFY2ADDRESS As String = ""
        Private mNOTIFY3CODE As String = ""
        Private mNOTIFY3NAME As String = ""
        Private mNOTIFY3ADDRESS As String = ""
        Private mMARKSNUMBERS As String = ""
        Private mCOMMODITYCODE As String = ""
        Private mCOMMODITYDESCRIPTION As String = ""
        Private mPACKAGES As Double = 0
        Private mPACKAGETYPE As String = ""
        Private mPACKAGETYPECODE As String = ""
        Private mCONTAINERNUMBER As String = ""
        Private mCHECKDIGIT As String = ""
        Private mNOOFCONTAINERS As Double = 0
        Private mNOOFTEUS As Double = 0
        Private mTOTALTAREWEIGHTINMT As Double = 0
        Private mCARGOWEIGHTINKG As Double = 0
        Private mGROSSWEIGHTINKG As Double = 0
        Private mCARGOVOLUMEINCUBIC As Double = 0
        Private mTOTALQUANTITY As Double = 0
        Private mFREIGHTTONNE As Double = 0
        Private mNOOFPALLETS As Double = 0
        Private mSLACINDICATOR As String = ""
        Private mCONTRACTCARRIAGE As String = ""
        Private mREMARKS As String = ""
        Public Property H_BILLOFLADINGNO() As String
            Get
                Return mBILLOFLADINGNO
            End Get
            Set(ByVal value As String)
                mBILLOFLADINGNO = value
            End Set
        End Property
        Public Property H_BOXPARTNERINGLINE() As String
            Get
                Return mBOXPARTNERINGLINE
            End Get
            Set(ByVal value As String)
                mBOXPARTNERINGLINE = value
            End Set
        End Property
        Public Property H_BOXPARTNERINGAGENT() As String
            Get
                Return mBOXPARTNERINGAGENT
            End Get
            Set(ByVal value As String)
                mBOXPARTNERINGAGENT = value
            End Set
        End Property
        Public Property H_PORTCODEOFORIGIN() As String
            Get
                Return mPORTCODEOFORIGIN
            End Get
            Set(ByVal value As String)
                mPORTCODEOFORIGIN = value
            End Set
        End Property
        Public Property H_PORTCODEOFLOADING() As String
            Get
                Return mPORTCODEOFLOADING
            End Get
            Set(ByVal value As String)
                mPORTCODEOFLOADING = value
            End Set
        End Property
        Public Property H_PORTCODEOFDISCHARGE() As String
            Get
                Return mPORTCODEOFDISCHARGE
            End Get
            Set(ByVal value As String)
                mPORTCODEOFDISCHARGE = value
            End Set
        End Property
        Public Property H_PORTCODEOFDESTINATION() As String
            Get
                Return mPORTCODEOFDESTINATION
            End Get
            Set(ByVal value As String)
                mPORTCODEOFDESTINATION = value
            End Set
        End Property
        Public Property O_DATEOFLOADING() As String
            Get
                Return mDATEOFLOADING
            End Get
            Set(ByVal value As String)
                mDATEOFLOADING = value
            End Set
        End Property
        Public Property O_MANIFESTREGISTRATION() As String
            Get
                Return mMANIFESTREGISTRATION
            End Get
            Set(ByVal value As String)
                mMANIFESTREGISTRATION = value
            End Set
        End Property
        Public Property H_TRADECODE() As String
            Get
                Return mTRADECODE
            End Get
            Set(ByVal value As String)
                mTRADECODE = value
            End Set
        End Property
        Public Property C_TRANSSHIPMENTMODE() As String
            Get
                Return mTRANSSHIPMENTMODE
            End Get
            Set(ByVal value As String)
                mTRANSSHIPMENTMODE = value
            End Set
        End Property
        Public Property O_BILLOFLADINGOWNERNAME() As String
            Get
                Return mBILLOFLADINGOWNERNAME
            End Get
            Set(ByVal value As String)
                mBILLOFLADINGOWNERNAME = value
            End Set
        End Property
        Public Property O_BILLOFLADINGOWNERADDRESS() As String
            Get
                Return mBILLOFLADINGOWNERADDRESS
            End Get
            Set(ByVal value As String)
                mBILLOFLADINGOWNERADDRESS = value
            End Set
        End Property
        Public Property H_CARGOCODE() As String
            Get
                Return mCARGOCODE
            End Get
            Set(ByVal value As String)
                mCARGOCODE = value
            End Set
        End Property
        Public Property H_CONSOLIDATEDCARGO() As String
            Get
                Return mCONSOLIDATEDCARGO
            End Get
            Set(ByVal value As String)
                mCONSOLIDATEDCARGO = value
            End Set
        End Property
        Public Property O_STORAGEREQUESTCODE() As String
            Get
                Return mSTORAGEREQUESTCODE
            End Get
            Set(ByVal value As String)
                mSTORAGEREQUESTCODE = value
            End Set
        End Property
        Public Property C_CONTAINERSERVICETYPE() As String
            Get
                Return mCONTAINERSERVICETYPE
            End Get
            Set(ByVal value As String)
                mCONTAINERSERVICETYPE = value
            End Set
        End Property
        Public Property H_COUNTRYOFORIGIN() As String
            Get
                Return mCOUNTRYOFORIGIN
            End Get
            Set(ByVal value As String)
                mCOUNTRYOFORIGIN = value
            End Set
        End Property
        Public Property C_ORIGINALCONSIGNEENAME() As String
            Get
                Return mORIGINALCONSIGNEENAME
            End Get
            Set(ByVal value As String)
                mORIGINALCONSIGNEENAME = value
            End Set
        End Property
        Public Property C_ORIGINALCONSIGNEE() As String
            Get
                Return mORIGINALCONSIGNEE
            End Get
            Set(ByVal value As String)
                mORIGINALCONSIGNEE = value
            End Set
        End Property
        Public Property C_ORIGINALVESSELNAME() As String
            Get
                Return mORIGINALVESSELNAME
            End Get
            Set(ByVal value As String)
                mORIGINALVESSELNAME = value
            End Set
        End Property
        Public Property C_ORIGINALVOYAGENUMBER() As String
            Get
                Return mORIGINALVOYAGENUMBER
            End Get
            Set(ByVal value As String)
                mORIGINALVOYAGENUMBER = value
            End Set
        End Property
        Public Property O_ORIGINALBOLNUMBER() As String
            Get
                Return mORIGINALBOLNUMBER
            End Get
            Set(ByVal value As String)
                mORIGINALBOLNUMBER = value
            End Set
        End Property
        Public Property C_ORIGINALSHIPPERNAME() As String
            Get
                Return mORIGINALSHIPPERNAME
            End Get
            Set(ByVal value As String)
                mORIGINALSHIPPERNAME = value
            End Set
        End Property
        Public Property C_ORIGINALSHIPPERADDRESS() As String
            Get
                Return mORIGINALSHIPPERADDRESS
            End Get
            Set(ByVal value As String)
                mORIGINALSHIPPERADDRESS = value
            End Set
        End Property
        Public Property H_SHIPPERNAME() As String
            Get
                Return mSHIPPERNAME
            End Get
            Set(ByVal value As String)
                mSHIPPERNAME = value
            End Set
        End Property
        Public Property H_SHIPPERADDRESS() As String
            Get
                Return mSHIPPERADDRESS
            End Get
            Set(ByVal value As String)
                mSHIPPERADDRESS = value
            End Set
        End Property
        Public Property H_SHIPPERCOUNTRYCODE() As String
            Get
                Return mSHIPPERCOUNTRYCODE
            End Get
            Set(ByVal value As String)
                mSHIPPERCOUNTRYCODE = value
            End Set
        End Property
        Public Property H_CONSIGNEECODE() As String
            Get
                Return mCONSIGNEECODE
            End Get
            Set(ByVal value As String)
                mCONSIGNEECODE = value
            End Set
        End Property
        Public Property H_CONSIGNEENAME() As String
            Get
                Return mCONSIGNEENAME
            End Get
            Set(ByVal value As String)
                mCONSIGNEENAME = value
            End Set
        End Property
        Public Property H_CONSIGNEEADDRESS() As String
            Get
                Return mCONSIGNEEADDRESS
            End Get
            Set(ByVal value As String)
                mCONSIGNEEADDRESS = value
            End Set
        End Property
        Public Property O_NOTIFY1CODE() As String
            Get
                Return mNOTIFY1CODE
            End Get
            Set(ByVal value As String)
                mNOTIFY1CODE = value
            End Set
        End Property
        Public Property H_NOTIFY1NAME() As String
            Get
                Return mNOTIFY1NAME
            End Get
            Set(ByVal value As String)
                mNOTIFY1NAME = value
            End Set
        End Property
        Public Property H_NOTIFY1ADDRESS() As String
            Get
                Return mNOTIFY1ADDRESS
            End Get
            Set(ByVal value As String)
                mNOTIFY1ADDRESS = value
            End Set
        End Property
        Public Property O_NOTIFY2CODE() As String
            Get
                Return mNOTIFY2CODE
            End Get
            Set(ByVal value As String)
                mNOTIFY2CODE = value
            End Set
        End Property
        Public Property O_NOTIFY2NAME() As String
            Get
                Return mNOTIFY2NAME
            End Get
            Set(ByVal value As String)
                mNOTIFY2NAME = value
            End Set
        End Property
        Public Property O_NOTIFY2ADDRESS() As String
            Get
                Return mNOTIFY2ADDRESS
            End Get
            Set(ByVal value As String)
                mNOTIFY2ADDRESS = value
            End Set
        End Property
        Public Property O_NOTIFY3CODE() As String
            Get
                Return mNOTIFY3CODE
            End Get
            Set(ByVal value As String)
                mNOTIFY3CODE = value
            End Set
        End Property
        Public Property O_NOTIFY3NAME() As String
            Get
                Return mNOTIFY3NAME
            End Get
            Set(ByVal value As String)
                mNOTIFY3NAME = value
            End Set
        End Property
        Public Property O_NOTIFY3ADDRESS() As String
            Get
                Return mNOTIFY3ADDRESS
            End Get
            Set(ByVal value As String)
                mNOTIFY3ADDRESS = value
            End Set
        End Property
        Public Property H_MARKSNUMBERS() As String
            Get
                Return mMARKSNUMBERS
            End Get
            Set(ByVal value As String)
                mMARKSNUMBERS = value
            End Set
        End Property
        Public Property H_COMMODITYCODE() As String
            Get
                Return mCOMMODITYCODE
            End Get
            Set(ByVal value As String)
                mCOMMODITYCODE = value
            End Set
        End Property
        Public Property H_COMMODITYDESCRIPTION() As String
            Get
                Return mCOMMODITYDESCRIPTION
            End Get
            Set(ByVal value As String)
                mCOMMODITYDESCRIPTION = value
            End Set
        End Property
        Public Property H_PACKAGES() As Double
            Get
                Return mPACKAGES
            End Get
            Set(ByVal value As Double)
                mPACKAGES = value
            End Set
        End Property
        Public Property H_PACKAGETYPE() As String
            Get
                Return mPACKAGETYPE
            End Get
            Set(ByVal value As String)
                mPACKAGETYPE = value
            End Set
        End Property
        Public Property H_PACKAGETYPECODE() As String
            Get
                Return mPACKAGETYPECODE
            End Get
            Set(ByVal value As String)
                mPACKAGETYPECODE = value
            End Set
        End Property
        Public Property C_CONTAINERNUMBER() As String
            Get
                Return mCONTAINERNUMBER
            End Get
            Set(ByVal value As String)
                mCONTAINERNUMBER = value
            End Set
        End Property
        Public Property C_CHECKDIGIT() As String
            Get
                Return mCHECKDIGIT
            End Get
            Set(ByVal value As String)
                mCHECKDIGIT = value
            End Set
        End Property
        Public Property C_NOOFCONTAINERS() As Double
            Get
                Return mNOOFCONTAINERS
            End Get
            Set(ByVal value As Double)
                mNOOFCONTAINERS = value
            End Set
        End Property
        Public Property C_NOOFTEUS() As Double
            Get
                Return mNOOFTEUS
            End Get
            Set(ByVal value As Double)
                mNOOFTEUS = value
            End Set
        End Property
        Public Property C_TOTALTAREWEIGHTINMT() As Double
            Get
                Return mTOTALTAREWEIGHTINMT
            End Get
            Set(ByVal value As Double)
                mTOTALTAREWEIGHTINMT = value
            End Set
        End Property
        Public Property H_CARGOWEIGHTINKG() As Double
            Get
                Return mCARGOWEIGHTINKG
            End Get
            Set(ByVal value As Double)
                mCARGOWEIGHTINKG = value
            End Set
        End Property
        Public Property H_GROSSWEIGHTINKG() As Double
            Get
                Return mGROSSWEIGHTINKG
            End Get
            Set(ByVal value As Double)
                mGROSSWEIGHTINKG = value
            End Set
        End Property
        Public Property C_CARGOVOLUMEINCUBIC() As Double
            Get
                Return mCARGOVOLUMEINCUBIC
            End Get
            Set(ByVal value As Double)
                mCARGOVOLUMEINCUBIC = value
            End Set
        End Property
        Public Property C_TOTALQUANTITY() As Double
            Get
                Return mTOTALQUANTITY
            End Get
            Set(ByVal value As Double)
                mTOTALQUANTITY = value
            End Set
        End Property
        Public Property C_FREIGHTTONNE() As Double
            Get
                Return mFREIGHTTONNE
            End Get
            Set(ByVal value As Double)
                mFREIGHTTONNE = value
            End Set
        End Property
        Public Property C_NOOFPALLETS() As Double
            Get
                Return mNOOFPALLETS
            End Get
            Set(ByVal value As Double)
                mNOOFPALLETS = value
            End Set
        End Property
        Public Property O_SLACINDICATOR() As String
            Get
                Return mSLACINDICATOR
            End Get
            Set(ByVal value As String)
                mSLACINDICATOR = value
            End Set
        End Property
        Public Property O_CONTRACTCARRIAGE() As String
            Get
                Return mCONTRACTCARRIAGE
            End Get
            Set(ByVal value As String)
                mCONTRACTCARRIAGE = value
            End Set
        End Property
        Public Property O_REMARKS() As String
            Get
                Return mREMARKS
            End Get
            Set(ByVal value As String)
                mREMARKS = value
            End Set
        End Property
        Public Function GenerateSegmentBOL() As String
            S = chr(34) & "BOL" & Chr(34) & Chr(44)
            s &= chr(34) & mid(H_BILLOFLADINGNO, 1, 20) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_BOXPARTNERINGLINE, 1, 6) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_BOXPARTNERINGAGENT, 1, 6) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_PORTCODEOFORIGIN, 1, 5) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_PORTCODEOFLOADING, 1, 5) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_PORTCODEOFDISCHARGE, 1, 5) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_PORTCODEOFDESTINATION, 1, 5) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_DATEOFLOADING, 1, 11) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_MANIFESTREGISTRATION, 1, 8) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_TRADECODE, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_TRANSSHIPMENTMODE, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_BILLOFLADINGOWNERNAME, 1, 30) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_BILLOFLADINGOWNERADDRESS, 1, 240) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_CARGOCODE, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_CONSOLIDATEDCARGO, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_STORAGEREQUESTCODE, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_CONTAINERSERVICETYPE, 1, 7) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_COUNTRYOFORIGIN, 1, 2) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_ORIGINALCONSIGNEENAME, 1, 30) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_ORIGINALCONSIGNEE, 1, 240) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_ORIGINALVESSELNAME, 1, 30) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_ORIGINALVOYAGENUMBER, 1, 10) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_ORIGINALBOLNUMBER, 1, 20) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_ORIGINALSHIPPERNAME, 1, 30) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_ORIGINALSHIPPERADDRESS, 1, 240) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_SHIPPERNAME, 1, 30) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_SHIPPERADDRESS, 1, 240) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_SHIPPERCOUNTRYCODE, 1, 2) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_CONSIGNEECODE, 1, 5) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_CONSIGNEENAME, 1, 48) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_CONSIGNEEADDRESS, 1, 240) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_NOTIFY1CODE, 1, 6) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_NOTIFY1NAME, 1, 48) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_NOTIFY1ADDRESS, 1, 240) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_NOTIFY2CODE, 1, 6) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_NOTIFY2NAME, 1, 48) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_NOTIFY2ADDRESS, 1, 240) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_NOTIFY3CODE, 1, 6) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_NOTIFY3NAME, 1, 48) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_NOTIFY3ADDRESS, 1, 240) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_MARKSNUMBERS, 1, 200) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_COMMODITYCODE, 1, 10) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_COMMODITYDESCRIPTION, 1, 100) & chr(34) & Chr(44)
            s &= chr(34) & format(H_PACKAGES, "000000000") & chr(34) & Chr(44)
            s &= chr(34) & mid(H_PACKAGETYPE, 1, 30) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_PACKAGETYPECODE, 1, 3) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_CONTAINERNUMBER, 1, 10) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_CHECKDIGIT, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & format(C_NOOFCONTAINERS, "000") & chr(34) & Chr(44)
            s &= chr(34) & format(C_NOOFTEUS, "000") & chr(34) & Chr(44)
            s &= chr(34) & format(C_TOTALTAREWEIGHTINMT, "0000.0") & chr(34) & Chr(44)
            S &= Chr(34) & Format(H_CARGOWEIGHTINKG, "000000000.000") & Chr(34) & Chr(44)
            S &= Chr(34) & Format(H_GROSSWEIGHTINKG, "000000000.000") & Chr(34) & Chr(44)
            S &= Chr(34) & Format(C_CARGOVOLUMEINCUBIC, "000000000.000") & Chr(34) & Chr(44)
            s &= chr(34) & format(C_TOTALQUANTITY, "000000000") & chr(34) & Chr(44)
            s &= chr(34) & format(C_FREIGHTTONNE, "000000000.000") & chr(34) & Chr(44)
            s &= chr(34) & format(C_NOOFPALLETS, "0000") & chr(34) & Chr(44)
            s &= chr(34) & mid(O_SLACINDICATOR, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_CONTRACTCARRIAGE, 1, 3) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_REMARKS, 1, 200) & chr(34) & Chr(44)
            Return S
        End Function
    End Class
    Partial Public Class CON
        Private S As String
        Private mSERIALNUMBER As Double = 0
        Private mMARKSNUMBERS As String = ""
        Private mCARGODESCRIPTION As String = ""
        Private mUSEDORNEWINDICATOR As String = ""
        Private mCOMMODITYCODE As String = ""
        Private mCONSIGNMENTPACKAGES As Double = 0
        Private mPACKAGETYPE As String = ""
        Private mPACKAGETYPECODE As String = ""
        Private mNOOFPALLETS As Double = 0
        Private mCONSIGNMENTWEIGHTIN As Double = 0
        Private mCONSIGNMENTVOLUMEIN As Double = 0
        Private mDANGEROUSGOODS As String = ""
        Private mIMOCLASSNUMBER As String = ""
        Private mUNNUMBEROFDANGEROUS As String = ""
        Private mFLASHPOINT As Double = 0
        Private mUNITOFTEMPERATUREImco As String = ""
        Private mSTORAGEREQUESTEDFOR As String = ""
        Private mREFRIGERATIONREQUIRED As String = ""
        Private mMINIMUMTEMPERATUREOF As Double = 0
        Private mMAXIMUMTEMPERATUREOF As Double = 0
        Private mUNITOFTEMPERATUREReefer As String = ""
        Public Property H_SERIALNUMBER() As Double
            Get
                Return mSERIALNUMBER
            End Get
            Set(ByVal value As Double)
                mSERIALNUMBER = value
            End Set
        End Property
        Public Property H_MARKSNUMBERS() As String
            Get
                Return mMARKSNUMBERS
            End Get
            Set(ByVal value As String)
                mMARKSNUMBERS = value
            End Set
        End Property
        Public Property H_CARGODESCRIPTION() As String
            Get
                Return mCARGODESCRIPTION
            End Get
            Set(ByVal value As String)
                mCARGODESCRIPTION = value
            End Set
        End Property
        Public Property O_USEDORNEWINDICATOR() As String
            Get
                Return mUSEDORNEWINDICATOR
            End Get
            Set(ByVal value As String)
                mUSEDORNEWINDICATOR = value
            End Set
        End Property
        Public Property H_COMMODITYCODE() As String
            Get
                Return mCOMMODITYCODE
            End Get
            Set(ByVal value As String)
                mCOMMODITYCODE = value
            End Set
        End Property
        Public Property H_CONSIGNMENTPACKAGES() As Double
            Get
                Return mCONSIGNMENTPACKAGES
            End Get
            Set(ByVal value As Double)
                mCONSIGNMENTPACKAGES = value
            End Set
        End Property
        Public Property H_PACKAGETYPE() As String
            Get
                Return mPACKAGETYPE
            End Get
            Set(ByVal value As String)
                mPACKAGETYPE = value
            End Set
        End Property
        Public Property H_PACKAGETYPECODE() As String
            Get
                Return mPACKAGETYPECODE
            End Get
            Set(ByVal value As String)
                mPACKAGETYPECODE = value
            End Set
        End Property
        Public Property H_NOOFPALLETS() As Double
            Get
                Return mNOOFPALLETS
            End Get
            Set(ByVal value As Double)
                mNOOFPALLETS = value
            End Set
        End Property
        Public Property H_CONSIGNMENTWEIGHTIN() As Double
            Get
                Return mCONSIGNMENTWEIGHTIN
            End Get
            Set(ByVal value As Double)
                mCONSIGNMENTWEIGHTIN = value
            End Set
        End Property
        Public Property H_CONSIGNMENTVOLUMEIN() As Double
            Get
                Return mCONSIGNMENTVOLUMEIN
            End Get
            Set(ByVal value As Double)
                mCONSIGNMENTVOLUMEIN = value
            End Set
        End Property
        Public Property H_DANGEROUSGOODS() As String
            Get
                Return mDANGEROUSGOODS
            End Get
            Set(ByVal value As String)
                mDANGEROUSGOODS = value
            End Set
        End Property
        Public Property C_IMOCLASSNUMBER() As String
            Get
                Return mIMOCLASSNUMBER
            End Get
            Set(ByVal value As String)
                mIMOCLASSNUMBER = value
            End Set
        End Property
        Public Property C_UNNUMBEROFDANGEROUS() As String
            Get
                Return mUNNUMBEROFDANGEROUS
            End Get
            Set(ByVal value As String)
                mUNNUMBEROFDANGEROUS = value
            End Set
        End Property
        Public Property C_FLASHPOINT() As Double
            Get
                Return mFLASHPOINT
            End Get
            Set(ByVal value As Double)
                mFLASHPOINT = value
            End Set
        End Property
        Public Property C_UNITOFTEMPERATUREImco() As String
            Get
                Return mUNITOFTEMPERATUREImco
            End Get
            Set(ByVal value As String)
                mUNITOFTEMPERATUREImco = value
            End Set
        End Property
        Public Property C_STORAGEREQUESTEDFOR() As String
            Get
                Return mSTORAGEREQUESTEDFOR
            End Get
            Set(ByVal value As String)
                mSTORAGEREQUESTEDFOR = value
            End Set
        End Property
        Public Property H_REFRIGERATIONREQUIRED() As String
            Get
                Return mREFRIGERATIONREQUIRED
            End Get
            Set(ByVal value As String)
                mREFRIGERATIONREQUIRED = value
            End Set
        End Property
        Public Property C_MINIMUMTEMPERATUREOF() As Double
            Get
                Return mMINIMUMTEMPERATUREOF
            End Get
            Set(ByVal value As Double)
                mMINIMUMTEMPERATUREOF = value
            End Set
        End Property
        Public Property C_MAXIMUMTEMPERATUREOF() As Double
            Get
                Return mMAXIMUMTEMPERATUREOF
            End Get
            Set(ByVal value As Double)
                mMAXIMUMTEMPERATUREOF = value
            End Set
        End Property
        Public Property C_UNITOFTEMPERATUREReefer() As String
            Get
                Return mUNITOFTEMPERATUREReefer
            End Get
            Set(ByVal value As String)
                mUNITOFTEMPERATUREReefer = value
            End Set
        End Property
        Public Function GenerateSegmentCON() As String
            S = chr(34) & "CON" & Chr(34) & Chr(44)
            s &= chr(34) & format(H_SERIALNUMBER, "000000") & chr(34) & Chr(44)
            s &= chr(34) & mid(H_MARKSNUMBERS, 1, 200) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_CARGODESCRIPTION, 1, 100) & chr(34) & Chr(44)
            s &= chr(34) & mid(O_USEDORNEWINDICATOR, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_COMMODITYCODE, 1, 10) & chr(34) & Chr(44)
            s &= chr(34) & format(H_CONSIGNMENTPACKAGES, "000000000") & chr(34) & Chr(44)
            s &= chr(34) & mid(H_PACKAGETYPE, 1, 30) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_PACKAGETYPECODE, 1, 3) & chr(34) & Chr(44)
            s &= chr(34) & format(H_NOOFPALLETS, "0000") & chr(34) & Chr(44)
            s &= chr(34) & format(H_CONSIGNMENTWEIGHTIN, "000000000.000") & chr(34) & Chr(44)
            s &= chr(34) & format(H_CONSIGNMENTVOLUMEIN, "000000000.000") & chr(34) & Chr(44)
            s &= chr(34) & mid(H_DANGEROUSGOODS, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_IMOCLASSNUMBER, 1, 3) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_UNNUMBEROFDANGEROUS, 1, 5) & chr(34) & Chr(44)
            s &= chr(34) & format(C_FLASHPOINT, "0000.0") & chr(34) & Chr(44)
            s &= chr(34) & mid(C_UNITOFTEMPERATUREImco, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_STORAGEREQUESTEDFOR, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_REFRIGERATIONREQUIRED, 1, 1) & chr(34) & Chr(44)
            s &= chr(34) & format(C_MINIMUMTEMPERATUREOF, "0000.0") & chr(34) & Chr(44)
            s &= chr(34) & format(C_MAXIMUMTEMPERATUREOF, "0000.0") & chr(34) & Chr(44)
            s &= chr(34) & mid(C_UNITOFTEMPERATUREReefer, 1, 1) & chr(34) & Chr(44)
            Return S
        End Function
    End Class
    Partial Public Class CTR
        Private S As String
        Private mCONTAINERNUMBER As String = ""
        Private mCHECKDIGIT As String = ""
        Private mTAREWEIGHTINMT As Double = 0
        Private mSEALNO As String = ""
        Public Property H_CONTAINERNUMBER() As String
            Get
                Return mCONTAINERNUMBER
            End Get
            Set(ByVal value As String)
                mCONTAINERNUMBER = value
            End Set
        End Property
        Public Property H_CHECKDIGIT() As String
            Get
                Return mCHECKDIGIT
            End Get
            Set(ByVal value As String)
                mCHECKDIGIT = value
            End Set
        End Property
        Public Property H_TAREWEIGHTINMT() As Double
            Get
                Return mTAREWEIGHTINMT
            End Get
            Set(ByVal value As Double)
                mTAREWEIGHTINMT = value
            End Set
        End Property
        Public Property H_SEALNO() As String
            Get
                Return mSEALNO
            End Get
            Set(ByVal value As String)
                mSEALNO = value
            End Set
        End Property
        Public Function GenerateSegmentCTR() As String
            S = chr(34) & "CTR" & Chr(34) & Chr(44)
            S &= Chr(34) & H_CONTAINERNUMBER & Chr(34) & Chr(44)
            S &= Chr(34) & "1" & Chr(34) & Chr(44)
            'S &= Chr(34) & Mid(H_CHECKDIGIT, 1, 1) & Chr(34) & Chr(44)
            'S &= Chr(34) & Mid(H_CONTAINERNUMBER, 1, 10) & Mid(H_CHECKDIGIT, 1, 1) & Chr(34) & Chr(44) --Included by Paragon
            ' Commented the above lines for the case :"REMOVING CHECK DIGIT SEGRATION IN GENERATED FILE FROM MAP FOR CUSTOMS UNDER EDI TOOLS MENU"
            ' And modified as above
            s &= chr(34) & format(H_TAREWEIGHTINMT, "0000.0") & chr(34) & Chr(44)
            s &= chr(34) & mid(H_SEALNO, 1, 10) & chr(34) & Chr(44)
            Return S
        End Function
    End Class
    Partial Public Class ENDS
        Private S As String
        Private mNOOFCONTAINERRELATED As Double = 0
        Private mBOL As Double = 0
        Private mNOOFOTHERBOL As Double = 0
        Private mREMARKS As String = ""
        Public Property H_NOOFCONTAINERRELATED() As Double
            Get
                Return mNOOFCONTAINERRELATED
            End Get
            Set(ByVal value As Double)
                mNOOFCONTAINERRELATED = value
            End Set
        End Property
        Public Property HBOL() As Double
            Get
                Return mBOL
            End Get
            Set(ByVal value As Double)
                mBOL = value
            End Set
        End Property
        Public Property H_NOOFOTHERBOL() As Double
            Get
                Return mNOOFOTHERBOL
            End Get
            Set(ByVal value As Double)
                mNOOFOTHERBOL = value
            End Set
        End Property
        Public Property O_REMARKS() As String
            Get
                Return mREMARKS
            End Get
            Set(ByVal value As String)
                mREMARKS = value
            End Set
        End Property
        Public Function GenerateSegmentEND() As String
            S = chr(34) & "END" & Chr(34) & Chr(44)
            s &= chr(34) & format(H_NOOFCONTAINERRELATED, "0000") & chr(34) & Chr(44)
            s &= chr(34) & format(HBOL, "0000000000") & chr(34) & Chr(44)
            s &= chr(34) & format(H_NOOFOTHERBOL, "0000") & chr(34) & Chr(44)
            s &= chr(34) & mid(O_REMARKS, 1, 100) & chr(34) & Chr(44)
            Return S
        End Function
    End Class
    Partial Public Class VOY
        Private S As String
        Private mLINECODE As String = ""
        Private mVOYAGEAGENTCODE As String = ""
        Private mVESSELNAME As String = ""
        Private mAGENTSVOYAGENUMBER As String = ""
        Private mPORTCODEOFDISCHARGE As String = ""
        Private mEXPECTEDTOARRIVEDATE As String = ""
        Private mROTATIONNUMBER As String = ""
        Private mMESSAGETYPE As String = ""
        Private mNOOFINSTALMENT As Double = 0
        Private mAGENTSMANIFEST As Double = 0
        Public Property H_LINECODE() As String
            Get
                Return mLINECODE
            End Get
            Set(ByVal value As String)
                mLINECODE = value
            End Set
        End Property
        Public Property H_VOYAGEAGENTCODE() As String
            Get
                Return mVOYAGEAGENTCODE
            End Get
            Set(ByVal value As String)
                mVOYAGEAGENTCODE = value
            End Set
        End Property
        Public Property H_VESSELNAME() As String
            Get
                Return mVESSELNAME
            End Get
            Set(ByVal value As String)
                mVESSELNAME = value
            End Set
        End Property
        Public Property H_AGENTSVOYAGENUMBER() As String
            Get
                Return mAGENTSVOYAGENUMBER
            End Get
            Set(ByVal value As String)
                mAGENTSVOYAGENUMBER = value
            End Set
        End Property
        Public Property H_PORTCODEOFDISCHARGE() As String
            Get
                Return mPORTCODEOFDISCHARGE
            End Get
            Set(ByVal value As String)
                mPORTCODEOFDISCHARGE = value
            End Set
        End Property
        Public Property H_EXPECTEDTOARRIVEDATE() As String
            Get
                Return mEXPECTEDTOARRIVEDATE
            End Get
            Set(ByVal value As String)
                mEXPECTEDTOARRIVEDATE = value
            End Set
        End Property
        Public Property C_ROTATIONNUMBER() As String
            Get
                Return mROTATIONNUMBER
            End Get
            Set(ByVal value As String)
                mROTATIONNUMBER = value
            End Set
        End Property
        Public Property H_MESSAGETYPE() As String
            Get
                Return mMESSAGETYPE
            End Get
            Set(ByVal value As String)
                mMESSAGETYPE = value
            End Set
        End Property
        Public Property H_NOOFINSTALMENT() As Double
            Get
                Return mNOOFINSTALMENT
            End Get
            Set(ByVal value As Double)
                mNOOFINSTALMENT = value
            End Set
        End Property
        Public Property H_AGENTSMANIFEST() As Double
            Get
                Return mAGENTSMANIFEST
            End Get
            Set(ByVal value As Double)
                mAGENTSMANIFEST = value
            End Set
        End Property
        Public Function GenerateSegmentVOY() As String
            S = chr(34) & "VOY" & Chr(34) & Chr(44)
            s &= chr(34) & mid(H_LINECODE, 1, 6) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_VOYAGEAGENTCODE, 1, 6) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_VESSELNAME, 1, 30) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_AGENTSVOYAGENUMBER, 1, 10) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_PORTCODEOFDISCHARGE, 1, 5) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_EXPECTEDTOARRIVEDATE, 1, 11) & chr(34) & Chr(44)
            s &= chr(34) & mid(C_ROTATIONNUMBER, 1, 6) & chr(34) & Chr(44)
            s &= chr(34) & mid(H_MESSAGETYPE, 1, 3) & chr(34) & Chr(44)
            s &= chr(34) & format(H_NOOFINSTALMENT, "000") & chr(34) & Chr(44)
            s &= chr(34) & format(H_AGENTSMANIFEST, "00000") & chr(34) & Chr(44)
            Return S
        End Function
    End Class

End Class
