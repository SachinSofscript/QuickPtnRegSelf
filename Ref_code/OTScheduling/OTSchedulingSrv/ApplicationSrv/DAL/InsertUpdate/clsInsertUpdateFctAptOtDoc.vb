#Region "IMPORTS"
Imports SofCommon
Imports CWReadClasses
#End Region

Public Class clsInsertUpdateFctAptOtDoc
    'PRAGYA : 11-OCT-2016 : FOR SAVING RECORDS OF OT FCT_APT_OT_DOC

    Dim oRequest As DBRequest
    Dim oFactory As DBFactory
    Dim oParam As DBRequest.Parameter

#Region "SpInsUpdFctAptOtDoc: Insert or Update into FCT_APT_OT_Doc"
    'PRAGYA : 11-OCT-2016
    Shared Function SpInsUpdFctAptOtDoc(ByVal companycode As String,
                                        ByVal div As Integer,
                                        ByVal loc As Integer,
                                        ByVal obj As clsFctAptOtDoc) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpInsUpdFctAptOtDoc]" '
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pcocd"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pdivcd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ploccd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIPOP"
            oParam.ParamValue = obj.IpOp
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPtnNo"
            oParam.ParamValue = obj.PtnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpNo"
            oParam.ParamValue = obj.IpNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctCatCode"
            oParam.ParamValue = obj.FctCatCode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctMainCode"
            oParam.ParamValue = obj.FctMainCode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctCode"
            oParam.ParamValue = obj.FctCode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pApptNo"
            oParam.ParamValue = obj.ApptNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = obj.DocCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserDtTm"
            oParam.ParamValue = obj.UserDtTm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserId"
            oParam.ParamValue = obj.UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSurgnTypCd"
            oParam.ParamValue = obj.SurgnTypCd
            .Parameters.Add(oParam)



        End With
        Return oRequest
    End Function
#End Region

#Region "SpDelFctAptOtDoc: DELETE FROM FCT_APT_OT_DOC"
    'PRAGYA : 11-OCT-2016
    Shared Function SpDelFctAptOtDoc(ByVal companycode As String,
                                     ByVal div As Integer,
                                     ByVal loc As Integer,
                                     ByVal ApptNo As Integer,
                                     ByVal DocCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpDelFctAptOtDoc]" '
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pcocd"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pdivcd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ploccd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pApptNo"
            oParam.ParamValue = ApptNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)
        End With
        Return oRequest
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
    Shared Function SPUPDFCTAPTOTDOC(ByVal CoCd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNO As Long, ByVal RsvNo As Long, ByVal UpDtTm As Date, ByVal Userid As String) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        oRequest.Command = "SPUPDFCTAPTOTDOC"
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
End Class
