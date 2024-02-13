Imports SofCommon
Imports CWReadClasses
Public Class clsInsertUpdateFCTAPTMAIN

    Dim oRequest As DBRequest
    Dim oFactory As DBFactory
    Dim oParam As DBRequest.Parameter

    ''' <summary>
    ''' adds paramters to store procedure SPINSFCTAPTMAIN
    ''' </summary>
    ''' <param name="mobjFCTAPTMAIN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Shared Function SPINSFCTAPTMAIN(ByVal mobjFCTAPTMAIN As clsFCTAPTMAIN) As DBRequest


        Dim ofactory As New DBFactory
        Dim oParam As New DBRequest.Parameter

        ofactory = New DBFactory
        Dim oRequest As New DBRequest


        oRequest.Command = "SPINSFCTAPTMAIN"  'FCT_APT_MAIN
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTAPTMAIN.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTAPTMAIN.DivisionCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTAPTMAIN.LocationCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjFCTAPTMAIN.FctCatCode
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjFCTAPTMAIN.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTAPTMAIN.FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTAPTMAIN.APPTNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPNO"
        oParam.ParamValue = mobjFCTAPTMAIN.IPOP
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pICDGRPCD"
        oParam.ParamValue = mobjFCTAPTMAIN.ICDGRPCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMDAT"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMDATE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMSTS"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMSTS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pREQNO"
        oParam.ParamValue = mobjFCTAPTMAIN.REQNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMFROM_HRS"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMFROMHRS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMFROMMINS"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMFROMMIN
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTOHRS"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMTOHRS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTOMINS"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMTOMNS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMACTFROMHRS"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMACTFROMHRS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMACTFROMMINS"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMACTFROMMIN
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMACTTOHRS"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMACTTOHRS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pANASTYPE"
        oParam.ParamValue = 0
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pANASNOTE1"
        oParam.ParamValue = 0
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pANASNOTE2"
        oParam.ParamValue = 0
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMACTTOMINS"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMACTTOMNS
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOP_FLG"
        oParam.ParamValue = mobjFCTAPTMAIN.pIPOPFLG
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pWARDNO"
        oParam.ParamValue = mobjFCTAPTMAIN.WARDNO
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pPTNCLSCD"
        oParam.ParamValue = mobjFCTAPTMAIN.PTNCLSCD
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pBEDNO"
        oParam.ParamValue = mobjFCTAPTMAIN.BEDNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMREFBY"
        oParam.ParamValue = mobjFCTAPTMAIN.APTMREFBY
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCHRGCODE"
        oParam.ParamValue = mobjFCTAPTMAIN.CHRGCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pTESTCODE"
        oParam.ParamValue = mobjFCTAPTMAIN.TESTCD
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pICDCODE"
        oParam.ParamValue = mobjFCTAPTMAIN.ICDCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDR1CODE"
        oParam.ParamValue = mobjFCTAPTMAIN.DR1CODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDR2CODE"
        oParam.ParamValue = mobjFCTAPTMAIN.DR2CODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDR3CODE"
        oParam.ParamValue = mobjFCTAPTMAIN.DR3CODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDR4CODE"
        oParam.ParamValue = mobjFCTAPTMAIN.DR4CODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pANAS1CODE"
        oParam.ParamValue = mobjFCTAPTMAIN.ANAS1CODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pANAS2CODE"
        oParam.ParamValue = mobjFCTAPTMAIN.ANAS2CODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pANAS3CODE"
        oParam.ParamValue = mobjFCTAPTMAIN.ANAS3CODE
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSURGNOTE1"
        oParam.ParamValue = mobjFCTAPTMAIN.SURGNOTE1
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSURGNOTE2"
        oParam.ParamValue = mobjFCTAPTMAIN.SURGNOTE2
        oRequest.Parameters.Add(oParam)




        oParam = New DBRequest.Parameter
        oParam.ParamName = "pOPRSTFTYPE1"
        oParam.ParamValue = mobjFCTAPTMAIN.FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pTYPE1NOS"
        oParam.ParamValue = mobjFCTAPTMAIN.TYPE1NOS
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pOPRSTFTYPE2"
        oParam.ParamValue = mobjFCTAPTMAIN.OPRSTFTYPE2
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pTYPE2NOS"
        oParam.ParamValue = mobjFCTAPTMAIN.TYPE2NOS
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pOPRSTFTYPE3"
        oParam.ParamValue = mobjFCTAPTMAIN.OPRSTFTYPE3
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pTYPE3NOS"
        oParam.ParamValue = mobjFCTAPTMAIN.TYPE3NOS
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pOPRSTFTYPE4"
        oParam.ParamValue = mobjFCTAPTMAIN.OPRSTFTYPE4
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pTYPE4NOS"
        oParam.ParamValue = mobjFCTAPTMAIN.TYPE4NOS
        oRequest.Parameters.Add(oParam)




        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSPLINST"
        oParam.ParamValue = mobjFCTAPTMAIN.SPLINST
        oRequest.Parameters.Add(oParam)






        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCRTUSRID"
        oParam.ParamValue = mobjFCTAPTMAIN.CRTUSRID
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "CRTDTTM"
        oParam.ParamValue = mobjFCTAPTMAIN.CRTDTTM
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "UPDTUSRID"
        oParam.ParamValue = mobjFCTAPTMAIN.UPDUSRID
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "UPDTDTTM"
        oParam.ParamValue = mobjFCTAPTMAIN.UPDTTTM
        oRequest.Parameters.Add(oParam)





        oParam = New DBRequest.Parameter
        oParam.ParamName = "reqsrno"
        oParam.ParamValue = mobjFCTAPTMAIN.REQSRNO
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "Billed"
        oParam.ParamValue = mobjFCTAPTMAIN.Billed
        oRequest.Parameters.Add(oParam)




        oParam = New DBRequest.Parameter
        oParam.ParamName = "BookFor"
        oParam.ParamValue = mobjFCTAPTMAIN.BookFor
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "PtnLstNm"
        oParam.ParamValue = mobjFCTAPTMAIN.PTNLSTNAME
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "PtnMidNm"
        oParam.ParamValue = mobjFCTAPTMAIN.PTNMIDNAME
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "Ptn_Fst_Nm"
        oParam.ParamValue = mobjFCTAPTMAIN.PTNFSTNAME
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "ptndet"
        oParam.ParamValue = ""
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "sms_send_flg"
        oParam.ParamValue = "N"
        oRequest.Parameters.Add(oParam)


        'End With

        Return oRequest
    End Function



    ''' <summary>
    ''' adds paramters to store procedure SPUPDFCTAPTMAIN
    ''' </summary>
    ''' <param name="mobjFCTUPDMAIN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPUPDFCTAPTMAIN(ByVal mobjFCTUPDMAIN As clsFCTAPTMAIN) As DBRequest


        Dim ofactory As New DBFactory
        Dim oParam As New DBRequest.Parameter

        ofactory = New DBFactory
        Dim oRequest As New DBRequest

        oRequest.Command = "SPUPDFCTAPTMAIN"  'FCT_APT_MAIN
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTUPDMAIN.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTUPDMAIN.DivisionCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTUPDMAIN.LocationCode
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjFCTUPDMAIN.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjFCTUPDMAIN.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTUPDMAIN.FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTUPDMAIN.APPTNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPNO"
        oParam.ParamValue = mobjFCTUPDMAIN.IPOP
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMFROMHRS"
        oParam.ParamValue = mobjFCTUPDMAIN.APTMFROMHRS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMFROMMINS"
        oParam.ParamValue = mobjFCTUPDMAIN.APTMFROMMIN
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTOHRS"
        oParam.ParamValue = mobjFCTUPDMAIN.APTMTOHRS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTOMINS"
        oParam.ParamValue = mobjFCTUPDMAIN.APTMTOMNS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPFLG"
        oParam.ParamValue = mobjFCTUPDMAIN.pIPOPFLG
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "UPDTUSRID"
        oParam.ParamValue = mobjFCTUPDMAIN.UPDUSRID
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "UPDTDTTM"
        oParam.ParamValue = mobjFCTUPDMAIN.UPDTTTM
        oRequest.Parameters.Add(oParam)




        oParam = New DBRequest.Parameter
        oParam.ParamName = "BookFor"
        oParam.ParamValue = mobjFCTUPDMAIN.BookFor
        oRequest.Parameters.Add(oParam)




        'End With

        Return oRequest
    End Function



    ''' <summary>
    ''' adds paramters to store procedure SPUPDFCTAPTMAIN001
    ''' </summary>
    ''' <param name="mobjFCTUPDMAIN001"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPUPDFCTAPTMAIN001(ByVal mobjFCTUPDMAIN001 As clsFCTAPTMAIN) As DBRequest

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        ofactory = New DBFactory
        Dim oRequest As New DBRequest
        ' Dim oParam As New DBRequest.Parameter
        ' With oRequest

        oRequest.Command = "SPUPDFCTAPTMAIN001" 'FCT_APT_MAIN
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTUPDMAIN001.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTUPDMAIN001.DivisionCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTUPDMAIN001.LocationCode
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjFCTUPDMAIN001.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjFCTUPDMAIN001.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTUPDMAIN001.FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTUPDMAIN001.APPTNO
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "UPDTUSRID"
        oParam.ParamValue = mobjFCTUPDMAIN001.UPDUSRID
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "UPDTDTTM"
        oParam.ParamValue = mobjFCTUPDMAIN001.UPDTTTM
        oRequest.Parameters.Add(oParam)


        'End With

        Return oRequest
    End Function




    ''' <summary>
    ''' aparna 10 oct 2017
    ''' </summary>
    ''' <param name="CoCd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="IpNO"></param>
    ''' <param name="RsvNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPUPDfctaptmain002(ByVal CoCd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNO As Long, ByVal RsvNo As Long, ByVal UpDtTm As Date, ByVal Userid As String) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        oRequest.Command = "SPUPDfctaptmain002"
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = CoCd
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = div
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = loc
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIpNo"
        oParam.ParamValue = IpNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pRsvNo"
        oParam.ParamValue = RsvNo
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "UpDttm"
        oParam.ParamValue = UpDtTm
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "Userid"
        oParam.ParamValue = Userid
        oRequest.Parameters.Add(oParam)


        Return oRequest
    End Function



    Shared Function SpUpdConvertOpToIp(ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer,
                               ByVal AptNo As Integer, ByVal IPNO As Long, ByVal PtnNo As Long) As DBRequest


        Dim ofactory As New DBFactory
        Dim oParam As New DBRequest.Parameter

        ofactory = New DBFactory
        Dim oRequest As New DBRequest


        oRequest.Command = "SpUpdConvertOpToIp"
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = pcompanycode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "@PDIVCD"
        oParam.ParamValue = pdiv
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "@PLOCCD"
        oParam.ParamValue = ploc
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "@pPtnNo"
        oParam.ParamValue = PtnNo
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "@pIpNo"
        oParam.ParamValue = IPNO
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "@pApptNo"
        oParam.ParamValue = AptNo
        oRequest.Parameters.Add(oParam)




        'End With

        Return oRequest
    End Function




End Class
