Imports SofCommon
Imports CWReadClasses
Public Class clsinsertUpdateFCTAPTREQ

    ''' <summary>
    ''' adds paramters to store procedure SPINSFCTAPTREQUEST
    ''' </summary>
    ''' <param name="mobjFCTAPTREQ"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPINSFCTAPTREQUEST(ByVal mobjFCTAPTREQ As clsFCTAPTREQ) As DBRequest

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        ofactory = New DBFactory
        Dim oRequest As New DBRequest

        oRequest.Command = "SPINSFCTAPTREQUEST"
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTAPTREQ.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTAPTREQ.DivisionCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTAPTREQ.LocationCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pREQDATE"
        oParam.ParamValue = mobjFCTAPTREQ.REQDATE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjFCTAPTREQ.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjFCTAPTREQ.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTAPTREQ.FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFOR_SPCFC_FCT"
        oParam.ParamValue = mobjFCTAPTREQ.FORSPCFCFCT
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTAPTREQ.APPTNO
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDOCCD"
        oParam.ParamValue = mobjFCTAPTREQ.DOCCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pISPATIENT"
        oParam.ParamValue = mobjFCTAPTREQ.ISPATIENT
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOP"
        oParam.ParamValue = mobjFCTAPTREQ.IP_OP
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "PTNNO"
        oParam.ParamValue = mobjFCTAPTREQ.PTNNO
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "PTNLNGNM"
        oParam.ParamValue = mobjFCTAPTREQ.PTNLNGNM
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTMFROM"
        oParam.ParamValue = mobjFCTAPTREQ.APTMTMFROM
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTMTO"
        oParam.ParamValue = mobjFCTAPTREQ.APTMTMTO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pISSHIFTED"
        oParam.ParamValue = mobjFCTAPTREQ.ISSHIFTED
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pNEWFCTCODE"
        oParam.ParamValue = mobjFCTAPTREQ.NEWFCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pNEWAPPT_NO"
        oParam.ParamValue = mobjFCTAPTREQ.NEWAPPTNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCRTUSR_ID"
        oParam.ParamValue = mobjFCTAPTREQ.CRTUSRID
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCRTDTTM"
        oParam.ParamValue = mobjFCTAPTREQ.CRTDTTM
        oRequest.Parameters.Add(oParam)
        'End With

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTRMRK"
        oParam.ParamValue = mobjFCTAPTREQ.APPTRMRK
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pNurseName"
        oParam.ParamValue = mobjFCTAPTREQ.NurseName
        oRequest.Parameters.Add(oParam)




        oParam = New DBRequest.Parameter
        oParam.ParamName = "pANESTYPCD"
        oParam.ParamValue = mobjFCTAPTREQ.ANESTYPCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pANESTYP"
        oParam.ParamValue = 1606
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter    'Sumit 19-Sep-2018
        oParam.ParamName = "pBOOKING_TYPE"
        oParam.ParamValue = mobjFCTAPTREQ.BOOKING_TYPE
        oRequest.Parameters.Add(oParam)




        Return oRequest
    End Function

    ''' <summary>
    ''' adds paramters to store procedure SPINSFCTAPTREQUEST
    ''' </summary>
    ''' <param name="mobjFCTAPTREQ"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPUPDFCTREQ(ByVal mobjFCTAPTREQ As clsFCTAPTREQ) As DBRequest

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        ofactory = New DBFactory
        Dim oRequest As New DBRequest

        oRequest.Command = "SPUPDFCTREQ" 'FCT_APT_REQUEST
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTAPTREQ.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTAPTREQ.DivisionCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTAPTREQ.LocationCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pPRMREQNO"
        oParam.ParamValue = mobjFCTAPTREQ.REQNO
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTAPTREQ.FCTCODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTAPTREQ.APPTNO
        oRequest.Parameters.Add(oParam)

     
        Return oRequest
    End Function

    ''' <summary>
    ''' adds paramters to store procedure SPINSFCTAPTREQ
    ''' </summary>
    ''' <param name="mobjFCTAPTREQ"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPINSFCTAPTREQ(ByVal mobjFCTAPTREQ As clsFCTAPTREQ) As DBRequest

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        ofactory = New DBFactory
        Dim oRequest As New DBRequest

        oRequest.Command = "SPINSFCTAPTREQ" 'fct_apt_req
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTAPTREQ.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTAPTREQ.DivisionCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTAPTREQ.LocationCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pREQDATE"
        oParam.ParamValue = mobjFCTAPTREQ.REQDATE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjFCTAPTREQ.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjFCTAPTREQ.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTAPTREQ.FCTCODE
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTAPTREQ.APPTNO
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCRTUSRID"
        oParam.ParamValue = mobjFCTAPTREQ.CRTUSRID
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCRTDTTM"
        oParam.ParamValue = mobjFCTAPTREQ.CRTDTTM
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "UPDTUSRID"
        oParam.ParamValue = mobjFCTAPTREQ.UPDUSRID
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "UPDTDTTM"
        oParam.ParamValue = mobjFCTAPTREQ.UPDDTTM
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "IPOPNO"
        oParam.ParamValue = mobjFCTAPTREQ.IPOPNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "REQ_COMPLETE_YN"
        oParam.ParamValue = "N"
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "PRM_REQ_CODE"
        oParam.ParamValue = mobjFCTAPTREQ.PRMREQCODE
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
    Shared Function SPUPDFCTAPTREQUEST(ByVal CoCd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNO As Long, ByVal RsvNo As Long) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        oRequest.Command = "SPUPDFCTAPTREQUEST"
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


        Return oRequest
    End Function




End Class
