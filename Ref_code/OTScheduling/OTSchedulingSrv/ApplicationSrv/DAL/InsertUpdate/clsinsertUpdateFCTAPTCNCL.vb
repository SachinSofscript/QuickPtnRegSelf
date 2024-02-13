Imports SofCommon
Imports CWReadClasses
Public Class clsinsertUpdateFCTAPTCNCL
    ''' <summary>
    ''' adds paramters to store procedure SPINSFCTAPTCNCL
    ''' </summary>
    ''' <param name="mobjFCTAPTCNCL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPINSFCTAPTCNCL(ByVal mobjFCTAPTCNCL As clsFCTAPTCNCL) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        oRequest.Command = "SPINSFCTAPTCNCL" 'FCT_APT_CNCL
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTAPTCNCL.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTAPTCNCL.DivisionCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTAPTCNCL.LocationCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjFCTAPTCNCL.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjFCTAPTCNCL.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTAPTCNCL.FCTCODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTAPTCNCL.APPTNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTM_DATE"
        oParam.ParamValue = mobjFCTAPTCNCL.APTMDATE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDOCCD"
        oParam.ParamValue = mobjFCTAPTCNCL.DOCCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pISPATIENT"
        oParam.ParamValue = mobjFCTAPTCNCL.ISPATIENT
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOP"
        oParam.ParamValue = mobjFCTAPTCNCL.IP_OP
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pPTNNO"
        oParam.ParamValue = mobjFCTAPTCNCL.PTNNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pPTNLNGNM"
        oParam.ParamValue = mobjFCTAPTCNCL.PTNLNGNM
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTMFROM"
        oParam.ParamValue = mobjFCTAPTCNCL.APTMTMFROM
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTMTO"
        oParam.ParamValue = mobjFCTAPTCNCL.APTMTMTO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pNOOFSLOTSUSED"
        oParam.ParamValue = mobjFCTAPTCNCL.NOOFSLOTSUSED
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDURATION"
        oParam.ParamValue = mobjFCTAPTCNCL.DURATION
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pISPERFORMED"
        oParam.ParamValue = mobjFCTAPTCNCL.ISPERFORMED
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pISPOSTED"
        oParam.ParamValue = mobjFCTAPTCNCL.ISPOSTED
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pISSHIFTED"
        oParam.ParamValue = mobjFCTAPTCNCL.ISSHIFTED
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCRT_USR_ID"
        oParam.ParamValue = mobjFCTAPTCNCL.CRTUSRID
        oRequest.Parameters.Add(oParam)




        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCRT_DT_TM"
        oParam.ParamValue = mobjFCTAPTCNCL.CRTDTTM
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCNCL_USR_ID"
        oParam.ParamValue = mobjFCTAPTCNCL.CNCLUSRID
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCNCL_DTTM"
        oParam.ParamValue = mobjFCTAPTCNCL.CNCLDTTM
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter    'Sumit 19-Sep-2018
        oParam.ParamName = "pAPPTRMRK"
        oParam.ParamValue = mobjFCTAPTCNCL.APPTRMRK
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter    'RasikV 20210601
        oParam.ParamName = "pCNCL_RMRK"
        oParam.ParamValue = mobjFCTAPTCNCL.CNCL_RMRK
        oRequest.Parameters.Add(oParam)

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
    Shared Function SPUPDFCTAPTCNCL(ByVal CoCd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNO As Long, ByVal RsvNo As Long) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        oRequest.Command = "SPUPDFCTAPTCNCL" 'FCT_APT_CNCL
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
