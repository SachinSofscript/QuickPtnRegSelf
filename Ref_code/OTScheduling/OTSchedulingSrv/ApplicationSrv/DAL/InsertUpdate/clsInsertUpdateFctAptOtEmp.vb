#Region "IMPORTS"
Imports SofCommon
Imports CWReadClasses
#End Region

'PRAGYA : 01-Dec-2016 : FOR SAVING RECORDS OF OT FCT_APT_OT_Emp
Public Class clsInsertUpdateFctAptOtEmp

#Region "SpInsFctAptOtEmp: Insert into FCT_APT_OT_Emp"
    'PRAGYA : 01-Dec-2016
    Shared Function SpInsFctAptOtEmp(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal CoCd As String,
                                      ByVal Div As Integer,
                                      ByVal Loc As Integer,
                                      ByVal obj As clsFctAptOtEmp) As DBRequest

        SpInsFctAptOtEmp = Nothing

        Dim oParam As DBRequest.Parameter
        Try
            Dim oRequest As New DBRequest
            With oRequest
                .Command = "[SpInsFctAptOtEmp]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pcocd"
                oParam.ParamValue = CoCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pdivcd"
                oParam.ParamValue = Div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "ploccd"
                oParam.ParamValue = Loc
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
                oParam.ParamName = "pEmpCd"
                oParam.ParamValue = obj.EmpCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pUserDtTm"
                oParam.ParamValue = obj.UserDtTm
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pUserId"
                oParam.ParamValue = obj.UserId
                .Parameters.Add(oParam)


            End With

            SpInsFctAptOtEmp = oRequest
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpInsFctAptOtEmp = Nothing
        End Try

        Return SpInsFctAptOtEmp

    End Function
#End Region

#Region "SpDelFctAptOtEmp: DELETE FROM FCT_APT_OT_Emp"
    'PRAGYA : 01-Dec-2016
    Shared Function SpDelFctAptOtEmp(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                         ByRef chrErrFlg As Char,
                                         ByVal CoCd As String,
                                         ByVal Div As Integer,
                                         ByVal Loc As Integer,
                                         ByVal ApptNo As Integer,
                                         ByVal PtnNo As Long,
                                         ByVal IpNo As Long) As DBRequest

        SpDelFctAptOtEmp = Nothing

        Dim oParam As DBRequest.Parameter
        Try
            Dim oRequest As New DBRequest
            With oRequest
                .Command = "[SpDelFctAptOtEmp]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pcocd"
                oParam.ParamValue = CoCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pdivcd"
                oParam.ParamValue = Div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "ploccd"
                oParam.ParamValue = Loc
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pApptNo"
                oParam.ParamValue = ApptNo
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pIpNo"
                oParam.ParamValue = IpNo
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pPtnNo"
                oParam.ParamValue = PtnNo
                .Parameters.Add(oParam)


            End With

            SpDelFctAptOtEmp = oRequest
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpDelFctAptOtEmp = Nothing
        End Try

        Return SpDelFctAptOtEmp

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
    Shared Function SPUPDFCTAPTOTEmp(ByVal CoCd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNO As Long, ByVal RsvNo As Long, ByVal UpDtTm As Date, ByVal Userid As String) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        oRequest.Command = "SPUPDFCTAPTOTEmp"
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
