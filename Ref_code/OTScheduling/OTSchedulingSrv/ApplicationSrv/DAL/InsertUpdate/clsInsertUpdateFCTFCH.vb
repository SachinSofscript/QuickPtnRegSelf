Imports SofCommon
Imports CWReadClasses
Public Class clsInsertUpdateFCTFCH

    ''mayur 11092013
    ''' <summary>
    ''' adds paramters to store procedure SPINSFCTSCH
    ''' </summary>
    ''' <param name="mobjFCTSCH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPINSFCTSCH(ByVal mobjFCTSCH As clsFCTSCH) As DBRequest

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter

        ofactory = New DBFactory
        Dim oRequest As New DBRequest
        ' Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "SPINSFCTSCH"  'fct_sch
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTSCH.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTSCH.DivisionCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTSCH.LocationCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjFCTSCH.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjFCTSCH.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTSCH.FCTCODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSCHDAT"
        oParam.ParamValue = mobjFCTSCH.SCHDATE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSESSIONCODE"
        oParam.ParamValue = mobjFCTSCH.SESSIONCODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSLOTNO"
        oParam.ParamValue = mobjFCTSCH.SLOTNO
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSCHFRMHRS"
        oParam.ParamValue = mobjFCTSCH.SCHTIMEFROMHRS
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSCHTOHRS"
        oParam.ParamValue = mobjFCTSCH.SCHTIMETOHRS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSCHFRMMIN"
        oParam.ParamValue = mobjFCTSCH.SCHTIMEFROMMIN
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSCHTOMIN"
        oParam.ParamValue = mobjFCTSCH.SCHTIMETOMINS
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTSCH.APPTNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMSTS"
        oParam.ParamValue = mobjFCTSCH.APTMSTS
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPNO"
        oParam.ParamValue = mobjFCTSCH.IPOPNO
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPFLG"
        oParam.ParamValue = mobjFCTSCH.IPOPFLG
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCHRGCD"
        oParam.ParamValue = mobjFCTSCH.CHRGCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pTESTCD"
        oParam.ParamValue = mobjFCTSCH.TESTCD
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMREFBY"
        oParam.ParamValue = mobjFCTSCH.APTMREFBY
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pICDGRPCD"
        oParam.ParamValue = mobjFCTSCH.ICDGRPCD
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pICDCODE"
        oParam.ParamValue = mobjFCTSCH.ICDCODE
        oRequest.Parameters.Add(oParam)


        Return oRequest
    End Function

    ''mayur 11092013
    ''' <summary>
    ''' adds paramters to store procedure SPUPDFCTSCH
    ''' </summary>
    ''' <param name="mobjUPDFCTSCH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPUPDFCTSCH(ByVal mobjUPDFCTSCH As clsFCTSCH) As DBRequest

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter

        ofactory = New DBFactory
        Dim oRequest As New DBRequest
        ' Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "SPUPDFCTSCH" 'fct_sch
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjUPDFCTSCH.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjUPDFCTSCH.DivisionCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjUPDFCTSCH.LocationCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjUPDFCTSCH.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjUPDFCTSCH.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjUPDFCTSCH.FCTCODE
        oRequest.Parameters.Add(oParam)





        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjUPDFCTSCH.APPTNO
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPNO"
        oParam.ParamValue = mobjUPDFCTSCH.IPOPNO
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPFLG"
        oParam.ParamValue = mobjUPDFCTSCH.IPOPFLG
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCHRGCD"
        oParam.ParamValue = mobjUPDFCTSCH.CHRGCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pTESTCD"
        oParam.ParamValue = mobjUPDFCTSCH.TESTCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMSTS"
        oParam.ParamValue = mobjUPDFCTSCH.APTMSTS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSCHDAT"
        oParam.ParamValue = mobjUPDFCTSCH.SCHDATE
        oRequest.Parameters.Add(oParam)



        Return oRequest
    End Function

    ''mayur 11092013
    ''' <summary>
    ''' adds paramters to store procedure SPUPDFCTSCH001
    ''' </summary>
    ''' <param name="mobjUPDFCTSCH001"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPUPDFCTSCH001(ByVal mobjUPDFCTSCH001 As clsFCTSCH) As DBRequest

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter

        ofactory = New DBFactory
        Dim oRequest As New DBRequest


        oRequest.Command = "SPUPDFCTSCH001" 'fct_sch
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjUPDFCTSCH001.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjUPDFCTSCH001.DivisionCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjUPDFCTSCH001.LocationCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjUPDFCTSCH001.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjUPDFCTSCH001.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjUPDFCTSCH001.FCTCODE
        oRequest.Parameters.Add(oParam)





        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjUPDFCTSCH001.APPTNO
        oRequest.Parameters.Add(oParam)



     

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSCHDAT"
        oParam.ParamValue = mobjUPDFCTSCH001.SCHDATE
        oRequest.Parameters.Add(oParam)



        Return oRequest
    End Function

    ''mayur 11092013
    ''' <summary>
    ''' adds paramters to store procedure SPUPDFCTSCH002
    ''' </summary>
    ''' <param name="mobjUPDFCTSCH002"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPUPDFCTSCH002(ByVal mobjUPDFCTSCH002 As clsFCTSCH) As DBRequest

        Dim ofactory As New DBFactory
        Dim oParam As New DBRequest.Parameter

        ofactory = New DBFactory
        Dim oRequest As New DBRequest
        ' Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "SPUPDFCTSCH002" 'FCT_SCH
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjUPDFCTSCH002.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjUPDFCTSCH002.DivisionCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjUPDFCTSCH002.LocationCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjUPDFCTSCH002.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjUPDFCTSCH002.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjUPDFCTSCH002.FCTCODE
        oRequest.Parameters.Add(oParam)





        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjUPDFCTSCH002.APPTNO
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPNO"
        oParam.ParamValue = mobjUPDFCTSCH002.IPOPNO
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPFLG"
        oParam.ParamValue = mobjUPDFCTSCH002.IPOPFLG
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCHRGCD"
        oParam.ParamValue = mobjUPDFCTSCH002.CHRGCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pTESTCD"
        oParam.ParamValue = mobjUPDFCTSCH002.TESTCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMSTS"
        oParam.ParamValue = mobjUPDFCTSCH002.APTMSTS
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSCHDAT"
        oParam.ParamValue = mobjUPDFCTSCH002.SCHDATE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSTRTHR"
        oParam.ParamValue = mobjUPDFCTSCH002.STRTHR
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSTRTMIN"
        oParam.ParamValue = mobjUPDFCTSCH002.STRTMIN
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pENDTHR"
        oParam.ParamValue = mobjUPDFCTSCH002.ENDTHR
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pENDTMIN"
        oParam.ParamValue = mobjUPDFCTSCH002.ENDTMIN
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
    Shared Function SPUPDFCTSCH003(ByVal CoCd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNO As Long, ByVal RsvNo As Long) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        oRequest.Command = "SPUPDFCTSCH003"
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
