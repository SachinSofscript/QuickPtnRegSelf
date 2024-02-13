Imports SofCommon
Imports CWReadClasses
Public Class clsInsertUpdateFCTAPTOT
    Dim oRequest As DBRequest
    Dim oFactory As DBFactory
    Dim oParam As DBRequest.Parameter




    ''' <summary>
    ''' adds paramters to store procedure SPINSFCTAPTMAIN
    ''' </summary>
    ''' <param name="mobjFCTAPTOT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPINSFCTAPTOT(ByVal mobjFCTAPTOT As clsFCTAPTOT) As DBRequest

        Dim ofactory As New DBFactory
        Dim oParam As New DBRequest.Parameter

        ofactory = New DBFactory
        Dim oRequest As New DBRequest


        oRequest.Command = "SPINSFCTAPTOT"  'FCT_APT_OT
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTAPTOT.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTAPTOT.DivisionCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTAPTOT.LocationCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjFCTAPTOT.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjFCTAPTOT.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTAPTOT.FCTCODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTAPTOT.APPTNO
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOP"
        oParam.ParamValue = mobjFCTAPTOT.IPOP
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMDATE"
        oParam.ParamValue = mobjFCTAPTOT.APTMDATE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDOCCODE"
        oParam.ParamValue = mobjFCTAPTOT.DOCCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pISPATIENT"
        oParam.ParamValue = mobjFCTAPTOT.ISPATIENT
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pPTNNO"
        oParam.ParamValue = mobjFCTAPTOT.PTNNO
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTMFROM"
        oParam.ParamValue = mobjFCTAPTOT.APTMTMFROM
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTMTO"
        oParam.ParamValue = mobjFCTAPTOT.APTMTMTO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pNOOFSLOTSUSED"
        oParam.ParamValue = mobjFCTAPTOT.NOOFSLOTSUSED
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDURATION"
        oParam.ParamValue = mobjFCTAPTOT.DURATION
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pISPERFORMED"
        oParam.ParamValue = mobjFCTAPTOT.ISPERFORMED
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pISPOSTED"
        oParam.ParamValue = mobjFCTAPTOT.ISPOSTED
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCRTUSRID"
        oParam.ParamValue = mobjFCTAPTOT.CRTUSRID
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCRTDTTM"
        oParam.ParamValue = mobjFCTAPTOT.CRTDTTM
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFLG"
        oParam.ParamValue = mobjFCTAPTOT.FLG
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pPTNLNGNM"
        oParam.ParamValue = mobjFCTAPTOT.PTNLNGNM
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTRMRK"
        oParam.ParamValue = mobjFCTAPTOT.APPTRMRK   'pragya 20161103
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pANESTYPCD"
        oParam.ParamValue = mobjFCTAPTOT.ANESTYPCD  'pragya 20161103
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDiagnosis"
        oParam.ParamValue = mobjFCTAPTOT.Diagnosis  'pragya 20161103
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pNurseName"
        oParam.ParamValue = mobjFCTAPTOT.NurseName  'pragya 20161103
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "IsOfficePrmsnGiven"
        oParam.ParamValue = mobjFCTAPTOT.IsOfficePrmsnGiven
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "OfficePrmsnByUsrID"
        oParam.ParamValue = IIf(mobjFCTAPTOT.IsOfficePrmsnGiven = False And mobjFCTAPTOT.FLG = "A", Nothing, mobjFCTAPTOT.OfficePrmsnByUsrID)
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "OfficePrmsnRmrk"
        oParam.ParamValue = IIf(mobjFCTAPTOT.IsOfficePrmsnGiven = False And mobjFCTAPTOT.FLG = "A", Nothing, mobjFCTAPTOT.OfficePrmsnRmrk)
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "OfficePrmsnDtTm"
        oParam.ParamValue = IIf(mobjFCTAPTOT.IsOfficePrmsnGiven = False And mobjFCTAPTOT.FLG = "A", Nothing, mobjFCTAPTOT.OfficePrmsnDtTm)
        oRequest.Parameters.Add(oParam)

        'End With


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pBookingTyp"
        oParam.ParamValue = mobjFCTAPTOT.BOOKING_TYPE  'shital 20210810
        oRequest.Parameters.Add(oParam)


        Return oRequest
    End Function




    ''' <summary>
    ''' adds paramters to store procedure SPDELFCTAPTOT
    ''' </summary>
    ''' <param name="mobjFCTAPTOT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPDELFCTAPTOT(ByVal mobjFCTAPTOT As clsFCTAPTOT) As DBRequest

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter

        ofactory = New DBFactory
        Dim oRequest As New DBRequest
        ' Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "SPDELFCTAPTOT" 'FCT_APT_OT
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = mobjFCTAPTOT.CompanyCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = mobjFCTAPTOT.DivisionCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = mobjFCTAPTOT.LocationCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = mobjFCTAPTOT.FctCatCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = mobjFCTAPTOT.FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = mobjFCTAPTOT.FCTCODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = mobjFCTAPTOT.APPTNO
        oRequest.Parameters.Add(oParam)





        'End With

        Return oRequest
    End Function




#Region "UPDATE INTO FCT_APT_OT" ' RasikV 20170311
    Shared Function SpUpdFctAptOt(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal FctCd As Integer, ByVal ApptNo As Integer) As DBRequest
        SpUpdFctAptOt = Nothing
        Dim oParam As DBRequest.Parameter
        Try
            Dim oRequest As New DBRequest
            With oRequest
                .Command = "[dbo].[SpUpdFctAptOt]" 'FCT_APT_OT
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCoCd"
                oParam.ParamValue = CoCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pDivCd "
                oParam.ParamValue = Div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pLocCd"
                oParam.ParamValue = Loc
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pFctCd"
                oParam.ParamValue = FctCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pApptNo"
                oParam.ParamValue = ApptNo
                .Parameters.Add(oParam)

            End With

            SpUpdFctAptOt = oRequest

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpUpdFctAptOt = Nothing
        End Try
        Return SpUpdFctAptOt
    End Function
#End Region


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
    Shared Function SPUPDFCTAPTOT001(ByVal CoCd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNO As Long, ByVal RsvNo As Long) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        oRequest.Command = "SPUPDFCTAPTOT001"
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
