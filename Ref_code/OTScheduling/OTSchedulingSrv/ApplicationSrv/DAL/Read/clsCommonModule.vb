Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
Namespace CommonModule
    <DataContract()>
    Public Enum PayRcvdTyp
        <EnumMember()>
              CashRcvd = 501
        <EnumMember()>
             ChequeRcvd = 502
        <EnumMember()>
            CreditRcvd = 503
        <EnumMember()>
            DepositRcvd = 504 'anamika 20140314
        <EnumMember()>
        PtnOutStanding = 505 'pragya : 29-nov-2017
        <EnumMember()>
           TdsRcvd = 509 'anamika 20140326
        <EnumMember()>
    ReverseIpBill = 510 'aparna 20171104
     

    End Enum


    <DataContract()>
    Public Class clsCommonModule
        'anamika 20130924
#Region "LicenseDate"
        Shared Function GetFnLicenseDate(ByVal strErrMsg As List(Of String),
                                        ByVal chrErrFlg As Char,
                                        ByVal Cocd As String, ByVal Div As Integer, ByVal Loc As Integer) As Date

            GetFnLicenseDate = Nothing
            Dim ofactory As DBFactory
            ofactory = New DBFactory
            Try
                Dim objEncryptPwd As New SofCommon.Rijndael
                Dim ds As DataSet = ofactory.ExecuteDataSet(FnLicenseDate(Cocd, Div, Loc))
                If ds.Tables(0).Rows.Count <> 0 Then
                    GetFnLicenseDate = CDate(objEncryptPwd.Decrypt(ds.Tables(0).Rows(0).Item(0)))
                End If

                Return GetFnLicenseDate
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
        End Function
        Shared Function FnLicenseDate(ByVal Cocd As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "SELECT dbo.[FnLicenseDate]()"
                .CommandType = CommandType.Text

            End With
            Return oRequest
        End Function
#End Region
        ' 20130924
#Region "CalRate"


        ''' <summary>
        ''' Get cal Rate Details
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="pcompanycode"></param>
        ''' <param name="pdiv"></param>
        ''' <param name="ploc"></param>
        ''' <param name="objCalRate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function calRate(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal pcompanycode As String,
                                        ByVal pdiv As Integer,
                                        ByVal ploc As Integer, ByVal objCalRate As clsCalRate) As clsCalRate
            calRate = Nothing
            Dim iSchemeCd As Short = 0
            Dim obj As New clsCalRate
            Dim ofactory As DBFactory
            ofactory = New DBFactory
            Dim LvEmgAmt As Double = 0.0
            Dim objEmgAmt As New CommonModule.clsAdtInDt
            Try
                'aparna 20170106
                Dim SchemeCd As Integer = CommonModule.clsCommonModule.FnCalCompanyScheme(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, objCalRate.lvArCd, objCalRate.lvChrgCd, objCalRate.lvSrvCd)
                If (SchemeCd = 0) Then
                    strErrMsg.Add("Enter record in CREDIT COMPANY MASTER for ArCd : " & Val(CStr(objCalRate.lvArCd)) & " and  charge code : " & Val(CStr(objCalRate.lvChrgCd)) & " and service code : " & Val(CStr(objCalRate.lvSrvCd)))
                    chrErrFlg = "Y"

                    Exit Function

                End If

                Dim ds As DataSet = ofactory.ExecuteDataSet(GETSPSELCALRATE(pcompanycode, pdiv, ploc, objCalRate))
                If ds.Tables(1).Rows.Count <> 0 Then
                    For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                        iSchemeCd = ds.Tables(1).Rows(i).Item("SchemeId")
                        obj.SchemeId = iSchemeCd
                        obj.EmergencyFlg = objCalRate.EmergencyFlg 'anamika 20140604
                        obj.StdRt = ds.Tables(1).Rows(i).Item(1) 'anamika 20140606
                        obj.MinRate = ds.Tables(1).Rows(i).Item("min_std_rt_1")
                        obj.MaxRate = ds.Tables(1).Rows(i).Item("max_std_rt_1")
                        obj.Rate = ds.Tables(1).Rows(i).Item(1) 'It will be valid in the case of both after and bfore admission
                        If obj.lvFreeFlag = "F" Then
                            obj.RateChangeType = 1
                        Else
                            If obj.Rate = 0 Then
                                obj.RateChangeType = 3 'allow to enter any value
                                obj.RateChangeFlg = True 'anamika 20131217 flag decide rate field will be editable or not
                            Else
                                If (obj.Rate = obj.MaxRate And obj.Rate = obj.MinRate) Then
                                    obj.RateChangeType = 1 'do not allow user to change rate
                                    obj.RateChangeFlg = False 'anamika 20131217 flag decide rate field will be editable or not
                                Else
                                    If (obj.MaxRate = 0 And obj.MinRate = 0) Then
                                        obj.RateChangeType = 1 'do not allow user to change rate
                                        obj.RateChangeFlg = False 'anamika 20131217 flag decide rate field will be editable or not
                                    Else
                                        obj.RateChangeType = 2 'allow to change rate with min and max limit
                                        ' obj.RateChangeFlg = False 'anamika 20131217 flag decide rate field will be editable or not
                                        obj.RateChangeFlg = True  'anamika 20140411 flag decide rate field will be editable or not
                                    End If
                                End If
                            End If
                        End If
                    Next
                    If objCalRate.EmergencyFlg = "Y" Then
                        'objEmgAmt = CommonModule.clsCommonModule.GetADTInDt(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, objEmgAmt)
                        'LvEmgAmt = objEmgAmt.EmergencyPerc
                        'obj.EmergencyPerc = objEmgAmt.EmergencyPerc 'anamika 20140604
                        'LvEmgAmt = (obj.Rate + (obj.Rate * LvEmgAmt) / 100)
                        'LvEmgAmt = Math.Round(LvEmgAmt / 5, MidpointRounding.AwayFromZero) * 5
                        'obj.Rate = LvEmgAmt

                        ''maximum rate
                        'LvEmgAmt = objEmgAmt.EmergencyPerc
                        'LvEmgAmt = (obj.MaxRate + (obj.MaxRate * LvEmgAmt) / 100)
                        'LvEmgAmt = Math.Round(LvEmgAmt / 5, MidpointRounding.AwayFromZero) * 5
                        'obj.MaxRate = LvEmgAmt


                        '' minimum rate
                        'LvEmgAmt = objEmgAmt.EmergencyPerc
                        'LvEmgAmt = (obj.MinRate + (obj.MinRate * LvEmgAmt) / 100)
                        'LvEmgAmt = Math.Round(LvEmgAmt / 5, MidpointRounding.AwayFromZero) * 5
                        'obj.MinRate = LvEmgAmt

                        Dim objrate As New clsServiceRate
                        objrate = clsCommonModule.GetEmergencyAmt(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, objEmgAmt, obj.Rate, obj.MaxRate, obj.MinRate)
                        obj.EmergencyPerc = objrate.Per
                        obj.Rate = objrate.Rate
                        obj.MaxRate = objrate.MaxRate
                        obj.MinRate = objrate.MinRate
                        objrate = Nothing
                    Else
                        obj.EmergencyPerc = 0 'anamika 20140604
                    End If
                    Return obj
                Else
                    calRate = Nothing
                    iSchemeCd = ds.Tables(0).Rows(0).Item("SchemeId")
                    '  strErrMsg.Add("Enter record in service rate master for scheme code " & Val(CStr(iSchemeCd)))
                    strErrMsg.Add("Enter record in service rate master for scheme code : " & Val(iSchemeCd) & " Charge Code : " & objCalRate.lvChrgCd & " Service Code : " & objCalRate.lvSrvCd)  'pragya : 24-may-2017
                End If

            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
            Exit Function
        End Function
        Shared Function GETSPSELCALRATE(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal objCalRate As clsCalRate) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELCALRATE]" 'rulemst,ar_scheme_mst,srv_mst_rt

                'oParam = New DBRequest.Parameter
                'oParam.ParamName = "pCOCD"
                'oParam.ParamValue = companycode
                '.Parameters.Add(oParam)

                'oParam = New DBRequest.Parameter
                'oParam.ParamName = "pDIV"
                'oParam.ParamValue = div
                '.Parameters.Add(oParam)

                'oParam = New DBRequest.Parameter
                'oParam.ParamName = "pLOC"
                'oParam.ParamValue = loc
                '.Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvArCd"
                oParam.ParamValue = objCalRate.lvArCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvChrgCd"
                oParam.ParamValue = objCalRate.lvChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvSrvCd"
                oParam.ParamValue = objCalRate.lvSrvCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pAdmissionDt"
                oParam.ParamValue = objCalRate.AdmissionDate
                .Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvPtnClsCd"
                oParam.ParamValue = objCalRate.lvPtnClsCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvFreeFlag"
                oParam.ParamValue = objCalRate.lvFreeFlag
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pRate"
                oParam.ParamValue = objCalRate.Rate
                .Parameters.Add(oParam)



                oParam = New DBRequest.Parameter
                oParam.ParamName = "pMinRate"
                oParam.ParamValue = objCalRate.MinRate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pMaxRate"
                oParam.ParamValue = objCalRate.MaxRate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pRateChangeType"
                oParam.ParamValue = objCalRate.RateChangeType
                .Parameters.Add(oParam)




                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvIpNo"
                oParam.ParamValue = objCalRate.lvIpNo
                .Parameters.Add(oParam)


                .CommandType = CommandType.StoredProcedure

            End With

            Return oRequest
        End Function
#End Region
#Region "ADTInDt"
        Shared Function GetADTInDt(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal pcompanycode As String,
                                        ByVal pdiv As Integer,
                                        ByVal ploc As Integer, ByVal objAdtInDt As clsAdtInDt) As clsAdtInDt
            GetADTInDt = Nothing
            Dim ofactory As DBFactory
            ofactory = New DBFactory
            Try
                Dim obj As New clsAdtInDt
                Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELADTINDT(pcompanycode, pdiv, ploc, objAdtInDt))
                If ds.Tables(0).Rows.Count <> 0 Then
                    obj.EmergencyPerc = ds.Tables(0).Rows(0).Item("EMG_SRV_PRCNT")
                End If
                GetADTInDt = obj
                Return GetADTInDt
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try

        End Function

        Shared Function SPSELADTINDT(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal obj As clsAdtInDt) As DBRequest

            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELADTINDT]"

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCOCD"
                oParam.ParamValue = companycode
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pDIV"
                oParam.ParamValue = div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pLOC"
                oParam.ParamValue = loc
                .Parameters.Add(oParam)
                .CommandType = CommandType.StoredProcedure
            End With



            Return oRequest

        End Function
#End Region
#Region "ShareRate"
        ''' <summary>
        ''' Get Share Rate Details
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="pcompanycode"></param>
        ''' <param name="pdiv"></param>
        ''' <param name="ploc"></param>
        Shared Function CalShare(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal pcompanycode As String,
                                        ByVal pdiv As Integer,
                                        ByVal ploc As Integer, ByVal objCalShare As clsCalShare) As clsCalShare
            CalShare = Nothing
            'Dim strSql As String
            Dim iSchemeCd As Short = 0
            'Dim strAdmDt As Date
            'Dim strComName As String = ""
            'Dim Strdt As Date = ""


            Dim ofactory As DBFactory
            ofactory = New DBFactory

            Try

                Dim ds As DataSet = ofactory.ExecuteDataSet(GETSPSELCALSHARE(pcompanycode, pdiv, ploc, objCalShare))
                If ds.Tables(0).Rows.Count <> 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        Dim obj As New clsCalShare
                        iSchemeCd = ds.Tables(0).Rows(i).Item("SchemeId")
                        obj.SchemeId = iSchemeCd
                        obj.lvShare = ds.Tables(0).Rows(i).Item("prcnt_amt")
                        CalShare = obj
                    Next
                Else
                    '   CalShare = Nothing
                    ' strErrMsg.Add("Enter record in service rate master for scheme code " & Val(CStr(iSchemeCd)))
                    'anamika 20131230
                    CalShare = Nothing
                    iSchemeCd = ds.Tables(1).Rows(0).Item("SchemeId")
                    strErrMsg.Add("Enter record in service rate master for scheme code " & Val(CStr(iSchemeCd)))
                    'end 20131230
                End If
                ds.Dispose()
                Return CalShare
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
            Exit Function
        End Function
        Shared Function GETSPSELCALSHARE(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal objCalShare As clsCalShare) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELCALSHARE]" 'rule_mst,ar_scheme_mst,srv_mst_rt
                .CommandType = CommandType.StoredProcedure
                'oParam = New DBRequest.Parameter
                'oParam.ParamName = "pCOCD"
                'oParam.ParamValue = companycode
                '.Parameters.Add(oParam)

                'oParam = New DBRequest.Parameter
                'oParam.ParamName = "pDIV"
                'oParam.ParamValue = div
                '.Parameters.Add(oParam)

                'oParam = New DBRequest.Parameter
                'oParam.ParamName = "pLOC"
                'oParam.ParamValue = loc
                '.Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvArCd"
                oParam.ParamValue = objCalShare.lvArCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvChrgCd"
                oParam.ParamValue = objCalShare.lvChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvSrvCd"
                oParam.ParamValue = objCalShare.lvSrvCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvPtnClsCd"
                oParam.ParamValue = objCalShare.lvPtnClsCd
                .Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvShare"
                oParam.ParamValue = objCalShare.lvShare
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pAdmissionDt"
                oParam.ParamValue = objCalShare.AdmissionDate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvIpNo"
                oParam.ParamValue = objCalShare.lvIpNo
                .Parameters.Add(oParam)




            End With

            Return oRequest
        End Function
#End Region
#Region "CompRate"
        ''' <summary>
        ''' Select Comp Rate
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="pcompanycode"></param>
        ''' <param name="pdiv"></param>
        ''' <param name="ploc"></param>
        ''' <param name="objclsCompRate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function CompRate(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal pcompanycode As String,
                                        ByVal pdiv As Integer,
                                        ByVal ploc As Integer, ByVal objclsCompRate As clsCompRate) As clsCompRate
            CompRate = Nothing
            'Dim strSql As String
            Dim iSchemeCd As Short = 0
            'Dim strAdmDt As Date
            'Dim strComName As String = ""
            'Dim Strdt As Date = ""


            Dim ofactory As DBFactory
            ofactory = New DBFactory

            Try

                Dim ds As DataSet = ofactory.ExecuteDataSet(GETSPSELCOMPRATE(pcompanycode, pdiv, ploc, objclsCompRate))
                If ds.Tables(0).Rows.Count <> 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        Dim obj As New clsCompRate
                        iSchemeCd = ds.Tables(0).Rows(i).Item("SchemeId")
                        obj.SchemeId = iSchemeCd
                        obj.lvShare = ds.Tables(0).Rows(i).Item("prcnt_amt")
                        CompRate = obj
                    Next
                Else
                    CompRate = Nothing
                    ' strErrMsg.Add("Enter record in service rate master for scheme code " & Val(CStr(iSchemeCd)))
                    strErrMsg.Add("Enter record in service rate master for scheme code : " & Val(objclsCompRate.SchemeId) & " Charge Code : " & objclsCompRate.lvCompChrgCd & " Service Code : " & objclsCompRate.lvCompSrvCd)  'pragya : 23-may-2017
                End If
                ds.Dispose()
                Return CompRate
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
            Exit Function
        End Function
        Shared Function GETSPSELCOMPRATE(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal objCompRate As clsCompRate) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELCOMPRATE]"
                .CommandType = CommandType.StoredProcedure


                'oParam = New DBRequest.Parameter
                'oParam.ParamName = "pCOCD"
                'oParam.ParamValue = companycode
                '.Parameters.Add(oParam)

                'oParam = New DBRequest.Parameter
                'oParam.ParamName = "pDIV"
                'oParam.ParamValue = div
                '.Parameters.Add(oParam)

                'oParam = New DBRequest.Parameter
                'oParam.ParamName = "pLOC"
                'oParam.ParamValue = loc
                '.Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvArCd"
                oParam.ParamValue = objCompRate.lvArCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvChrgCd"
                oParam.ParamValue = objCompRate.lvChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvSrvCd"
                oParam.ParamValue = objCompRate.lvSrvCd
                .Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvCompChrgCd"
                oParam.ParamValue = objCompRate.lvCompChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvCompSrvCd "
                oParam.ParamValue = objCompRate.lvCompSrvCd
                .Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvPtnClsCd"
                oParam.ParamValue = objCompRate.lvPtnClsCd
                .Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvCompNo"
                oParam.ParamValue = objCompRate.lvCompNo
                .Parameters.Add(oParam)



                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvCompVal" 'anamika 20140310
                oParam.ParamValue = objCompRate.lvCompVal
                .Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "pAdmissionDt"
                oParam.ParamValue = objCompRate.AdmissionDate
                .Parameters.Add(oParam)



                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvIpNo"
                oParam.ParamValue = objCompRate.lvIpNo
                .Parameters.Add(oParam)



            End With

            Return oRequest
        End Function
#End Region
#Region "ValidateUser"
        Shared Function ValidateUser(ByVal strErrMsg As List(Of String),
                                        ByVal chrErrFlg As Char,
                                        ByVal pcompanycode As String,
                                        ByVal pdiv As Integer,
                                        ByVal ploc As Integer, ByVal pUserId As String, ByVal pPassWord As String, ByVal ChkEncrypt As Boolean) As Boolean
            ValidateUser = Nothing


            Dim ofactory As DBFactory
            ofactory = New DBFactory

            Try
                'encrypt password
                Dim objEncryptPwd As New SofCommon.Rijndael
                If ChkEncrypt = True Then
                    pPassWord = objEncryptPwd.Encrypt(pPassWord)

                End If

                Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELVALIDATEUSER(pcompanycode, pdiv, ploc, pUserId, pPassWord))
                If ds.Tables(0).Rows.Count <> 0 Then
                    ValidateUser = True
                Else
                    ValidateUser = False
                End If
                ds.Dispose()
                Return ValidateUser
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
            Exit Function
        End Function
        Shared Function SPSELVALIDATEUSER(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal pUserId As String, ByVal pPassWord As String) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELVALIDATEUSER]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True


                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCOCD"
                oParam.ParamValue = companycode
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pDIV"
                oParam.ParamValue = div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pLOC"
                oParam.ParamValue = loc
                .Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "pUserId"
                oParam.ParamValue = pUserId
                .Parameters.Add(oParam)



                oParam = New DBRequest.Parameter
                oParam.ParamName = "pPassword"
                oParam.ParamValue = pPassWord
                .Parameters.Add(oParam)



            End With

            Return oRequest
        End Function
#End Region
#Region "ChkSysLock"
        Shared Function ChkSysLock(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As Boolean

            ChkSysLock = Nothing
            Dim ofactory As DBFactory
            ofactory = New DBFactory
            Try

                Dim ds As DataSet = ofactory.ExecuteDataSet(GETFnCheckSysLock(pcompanycode, pdiv, ploc))

                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        If ds.Tables(0).Rows(i).Item(0) = "0" Then
                            ChkSysLock = True
                        Else
                            ChkSysLock = False
                        End If

                        '    Diagnostics.Process.GetCurrentProcess.Kill()
                        '  
                        'Else
                        '    Gv_RevDt = ds.Tables(0).Rows(i).Item("rev_dt")
                        '    ChkSysLock = False
                        'End If
                    Next
                End If
                ds.Dispose()
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return False
            End Try

            Return ChkSysLock
        End Function
        Shared Function GETFnCheckSysLock(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "SELECT dbo.[FnCheckSysLock]()" 'HSP_IN_Dt
                .CommandType = CommandType.Text

            End With
            Return oRequest
        End Function
#End Region
#Region "CompanyScheme"
        'anamike 20140310
        Shared Function FnCalCompanyScheme(ByVal strErrMsg As List(Of String),
                                       ByVal chrErrFlg As Char,
                                       ByVal Cocd As String, ByVal Div As Integer, ByVal Loc As Integer,
                                       ByVal ArCd As Integer, ByVal ChrgCd As Integer, ByVal SrvCd As Integer) As Integer

            FnCalCompanyScheme = Nothing
            Dim ofactory As DBFactory
            ofactory = New DBFactory
            Try
                If ArCd = 0 Then 'if credit company is not selected
                    Dim objRuleMst As clsRuleMaster
                    objRuleMst = New clsRuleMaster
                    objRuleMst = clsRuleMaster.GetRuleMstDtls(strErrMsg, chrErrFlg, Cocd, Div, Loc, 12)
                    If objRuleMst IsNot Nothing Then
                        FnCalCompanyScheme = Val(objRuleMst.Data1)
                    End If
                    objRuleMst = Nothing
                Else
                    Dim ds As DataSet = ofactory.ExecuteDataSet(FnCalCompanyScheme(ArCd, ChrgCd, SrvCd))
                    If ds.Tables(0).Rows.Count <> 0 Then
                        FnCalCompanyScheme = CInt(ds.Tables(0).Rows(0).Item(0))
                    End If
                End If

                Return FnCalCompanyScheme
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
        End Function
        Shared Function FnCalCompanyScheme(ByVal ArCd As Integer, ByVal ChrgCd As Integer, ByVal SrvCd As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "SELECT dbo.[FnCalCompanyScheme]('" & ArCd & "','" & ChrgCd & "','" & SrvCd & "')"
                .CommandType = CommandType.Text

            End With
            Return oRequest
        End Function
        'end code  20140310

#End Region

#Region "CheckLogOut"
        'anamika 20140416
        'Shared Function CheckLogOut(ByVal strErrMsg As List(Of String),
        '                                ByVal chrErrFlg As Char,
        '                                ByVal pcompanycode As String,
        '                                ByVal pdiv As Integer,
        '                                ByVal ploc As Integer, ByVal pUserId As String) As Boolean
        '    CheckLogOut = Nothing


        '    Dim ofactory As DBFactory
        '    ofactory = New DBFactory

        '    Try

        '        Dim ds As DataSet = ofactory.ExecuteDataSet(clsLogInOutDetail.SpCheckLogOut(pcompanycode, pdiv, ploc, pUserId))
        '        If ds.Tables(0).Rows.Count <> 0 Then
        '            CheckLogOut = False
        '        Else
        '            CheckLogOut = True
        '        End If
        '        ds.Dispose()
        '        Return CheckLogOut
        '    Catch ex As Exception
        '        strErrMsg.Add(ex.Message)
        '        chrErrFlg = "Y"
        '        Return Nothing
        '    End Try
        '    Exit Function
        'End Function


        'end code 20140416


#End Region

#Region "GetSharerAmt"
        'mayur 20140426
        Shared Function GetSharerAmt(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ArCd As Integer, ByVal ChrgCd As Integer, ByVal SrvCd As Integer, ByVal CmpntChrgCd As Integer, ByVal CmpntSrvCd As Integer, ByVal PtnClsCd As Integer, ByVal ProfileCmpntNo As Integer, ByVal CmpntCd As Integer, ByVal lvShare As Integer, ByVal IpNo As Long, ByVal AdmissionDate As Date, Optional EmerGencyFlg As Boolean = False) As clsSharerAmt
            Try

                GetSharerAmt = Nothing
                Dim objCompRate As New CommonModule.clsCompRate
                objCompRate.lvArCd = ArCd
                objCompRate.lvChrgCd = ChrgCd
                objCompRate.lvSrvCd = SrvCd
                objCompRate.lvCompChrgCd = CmpntChrgCd
                objCompRate.lvCompSrvCd = CmpntSrvCd
                objCompRate.lvPtnClsCd = PtnClsCd
                objCompRate.lvCompNo = ProfileCmpntNo
                objCompRate.lvShare = lvShare
                objCompRate.lvIpNo = IpNo
                objCompRate.AdmissionDate = AdmissionDate
                objCompRate = CommonModule.clsCommonModule.CompRate(strErrMsg, chrErrFlg, companycode, div, loc, objCompRate)
                Dim objclaSharerAmt As New clsSharerAmt
                If (objCompRate IsNot Nothing) Then
                    ' objclaSharerAmt.Amount = objCompRate.lvShare 'APARNA 6 MAR 2017
                    If (EmerGencyFlg = True) Then
                        Dim objrate As New clsServiceRate
                        Dim objEmgAmt As New clsAdtInDt
                        objrate = clsCommonModule.GetEmergencyAmt(strErrMsg, chrErrFlg, companycode, div, loc, objEmgAmt, objCompRate.lvShare, 0, 0)
                        objclaSharerAmt.Amount = objrate.Rate
                    Else

                        objclaSharerAmt.Amount = objCompRate.lvShare
                    End If

                    'Dim objarrSharerChrgsDtl As New List(Of clsSharerServiceDetails)
                    'Dim objSharerChrgs As New clsSharerServiceMain
                    'objSharerChrgs.ChrgCd = CmpntChrgCd
                    'objSharerChrgs.SrvCd = CmpntSrvCd
                    'objSharerChrgs.IpNo = IpNo
                    'objSharerChrgs.ArCd = ArCd
                    'objSharerChrgs.AdmissionDate = AdmissionDate
                    'objSharerChrgs.ShrerSrvCd = ShrSrvCd
                    'objSharerChrgs.SchemeCd = SchemeId
                    'objSharerChrgs.IsEmergency = EmerGencyFlg
                    'objSharerChrgs.PtnClsCd = PtnClsCd
                    'objSharerChrgs.CmpntCd = CmpntCd
                    'objarrSharerChrgsDtl = clsSrvMstShr.GetSharerServiceList(strErrMsg, chrErrFlg, companycode, div, loc, objSharerChrgs)
                    'If objarrSharerChrgsDtl IsNot Nothing Then
                    '    If (objarrSharerChrgsDtl.Count > 0) Then
                    '        For i As Integer = 0 To objarrSharerChrgsDtl.Count - 1
                    '            If objarrSharerChrgsDtl(i).CmpntCd = CInt(2) Then
                    '                objclaSharerAmt.ShrAmt = ConvertToDecimal((Val(CStr(objarrSharerChrgsDtl(i).ShrAmt)) * (Val(objclaSharerAmt.Amount) * Val(Qty))) / 100)
                    '            ElseIf objarrSharerChrgsDtl(i).CmpntCd = CInt(3) Then
                    '                objclaSharerAmt.ShrAmt = ConvertToDecimal(CStr((Val(CStr(objarrSharerChrgsDtl(i).ShrAmt)) * Val(Qty))))
                    '            End If
                    '        Next

                    '    End If
                    'End If




                    Dim objCalShare As New CommonModule.clsCalShare
                    objCalShare.lvArCd = ArCd
                    objCalShare.lvChrgCd = CmpntChrgCd
                    objCalShare.lvSrvCd = CmpntSrvCd
                    objCalShare.lvPtnClsCd = PtnClsCd
                    objCalShare.lvShare = lvShare
                    objCalShare.lvIpNo = IpNo
                    objCalShare.AdmissionDate = AdmissionDate
                    objCalShare = CommonModule.clsCommonModule.CalShare(strErrMsg, chrErrFlg, companycode, div, loc, objCalShare)
                    If (objCalShare IsNot Nothing) Then
                        If (CmpntCd = 2) Then
                            objclaSharerAmt.ShrAmt = (objclaSharerAmt.Amount * (objCalShare.lvShare / 100))
                        Else
                            objclaSharerAmt.ShrAmt = objCalShare.lvShare
                        End If
                    Else
                        'strErrMsg.Add(strErrMsg(strErrMsg.Count - 1))
                        strErrMsg.Add("Enter record in service rate master for scheme code : " & Val(objCalShare.SchemeId) & " Charge Code : " & objCalShare.lvChrgCd & " Service Code : " & objCalShare.lvSrvCd)  'pragya : 24-may-2017
                        chrErrFlg = "Y"
                        Return Nothing
                    End If








                Else
                    strErrMsg.Add(strErrMsg(strErrMsg.Count - 1))
                    chrErrFlg = "Y"
                    Return Nothing
                End If
                Return objclaSharerAmt
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
        End Function


        Public Shared Function ConvertToDecimal(ByVal value As String) As String
            ConvertToDecimal = Format(Conversion.Val(value), "0.00")
            Return ConvertToDecimal
        End Function
        'end mayur 20140426
#End Region

#Region "User Pwd should be greater than Pwd Length "   'RasikV 20161202
        Shared Function CheckIsUserPwdLenExists(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UserID As String) As Boolean
            Try
                Dim orequest As New DBRequest
                orequest.CommandType = CommandType.Text
                orequest.Command = "SELECT [dbo].[FnIsUserPwdLenExists]  ('" & CoCd &
                                                      "', " & Div & _
                                                      ", " & Loc & _
                                                      ", '" & UserID &
                                                      "') PwdLen "
                Dim ofactory As New DBFactory
                Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

                If ds.Tables(0).Rows.Count <> 0 Then
                    CheckIsUserPwdLenExists = ds.Tables(0).Rows(0).Item("PwdLen")
                Else
                    CheckIsUserPwdLenExists = Nothing
                End If
                orequest = Nothing
                ofactory = Nothing
                Return CheckIsUserPwdLenExists
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                CheckIsUserPwdLenExists = False
            End Try
        End Function

#End Region



        Public Shared Function GetEmergencyAmt(ByRef strErrMsg As List(Of String),
                                             ByRef chrErrFlg As Char,
                                             ByVal pcompanycode As String,
                                             ByVal pdiv As Integer,
                                             ByVal ploc As Integer, ByVal objAdtInDt As clsAdtInDt, ByVal Rate As Double, ByVal MaxRate As Double, ByVal MinRate As Double) As clsServiceRate

            Dim objEmgAmt As New clsAdtInDt
            Dim LvEmgAmt As Double
            Dim obj As New clsServiceRate


            Try

                objEmgAmt = CommonModule.clsCommonModule.GetADTInDt(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, objEmgAmt)

                obj.Per = objEmgAmt.EmergencyPerc
                LvEmgAmt = (Rate + (Rate * obj.Per) / 100)
                'LvEmgAmt = Math.Round(LvEmgAmt / 5, MidpointRounding.AwayFromZero) * 5
                obj.Rate = LvEmgAmt

                'maximum rate

                LvEmgAmt = (MaxRate + (MaxRate * obj.Per) / 100)
                ' LvEmgAmt = Math.Round(LvEmgAmt / 5, MidpointRounding.AwayFromZero) * 5
                obj.MaxRate = LvEmgAmt


                ' minimum rate

                LvEmgAmt = (MinRate + (MinRate * obj.Per) / 100)
                '  LvEmgAmt = Math.Round(LvEmgAmt / 5, MidpointRounding.AwayFromZero) * 5
                obj.MinRate = LvEmgAmt

            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try

            Return obj
        End Function
#Region "Get pswd_exp Date by  UserId and PassWord " 'Pramila 06March2017
        Shared Function GetPswdExpDate(ByVal strErrMsg As List(Of String),
                                        ByVal chrErrFlg As Char,
                                        ByVal pcompanycode As String,
                                        ByVal pdiv As Integer,
                                        ByVal ploc As Integer, ByVal pUserId As String, ByVal pPassWord As String) As Date
            GetPswdExpDate = Nothing


            Dim ofactory As DBFactory
            ofactory = New DBFactory
            Try
                Dim obj As New SofCommon.Rijndael
                pPassWord = obj.Encrypt(pPassWord)
                Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELVALIDATEUSER001(pcompanycode, pdiv, ploc, pUserId, pPassWord))
                If ds.Tables(0).Rows.Count <> 0 Then
                    GetPswdExpDate = CDate((ds.Tables(0).Rows(0).Item(0)))
                End If

                Return GetPswdExpDate
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
        End Function
        Shared Function SPSELVALIDATEUSER001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal pUserId As String, ByVal pPassWord As String) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELVALIDATEUSER001]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True


                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCOCD"
                oParam.ParamValue = companycode
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pDIV"
                oParam.ParamValue = div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pLOC"
                oParam.ParamValue = loc
                .Parameters.Add(oParam)


                oParam = New DBRequest.Parameter
                oParam.ParamName = "pUserId"
                oParam.ParamValue = pUserId
                .Parameters.Add(oParam)



                oParam = New DBRequest.Parameter
                oParam.ParamName = "pPassword"
                oParam.ParamValue = pPassWord
                .Parameters.Add(oParam)



            End With

            Return oRequest
        End Function
#End Region

        Shared Function CheckUserSeesionState(strErrMsg As List(Of String), chrErrFlg As Char, UserSessionId As Integer) As Integer

            CheckUserSeesionState = Nothing
            Dim orequest As New DBRequest

            Dim obj As Integer
            orequest.CommandType = CommandType.Text

            orequest.Command = "SELECT  dbo.[Fn_GetUserSessionStateBySessionId] (" & UserSessionId & ") UserSessionState"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)


            If ds.Tables(0).Rows.Count <> 0 Then
                obj = ds.Tables(0).Rows(0).Item("UserSessionState")
            Else
                obj = 0
            End If
          
            'CheckUserSeesionState = obj

            'If CheckUserSeesionState <> 1 Then
            '    strErrMsg.Add("Currently Login Session Id = " & UserSessionId.ToString & " Is Closed")
            '    chrErrFlg = "Y"
            'End If

            CheckUserSeesionState = 1 'anamika 20171016
            Return CheckUserSeesionState


        End Function


        Shared Function CheckUserSeesionStateByUserId(strErrMsg As List(Of String), chrErrFlg As Char, UserId As String) As Integer

            CheckUserSeesionStateByUserId = Nothing
            Dim orequest As New DBRequest

            Dim obj As Integer
            orequest.CommandType = CommandType.Text

            orequest.Command = "SELECT  dbo.[Fn_GetUserSessionStatusByUserId] ('" & UserId & "') UserSessionState"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)


            If ds.Tables(0).Rows.Count <> 0 Then
                obj = ds.Tables(0).Rows(0).Item("UserSessionState")
            Else
                obj = 0
            End If

            CheckUserSeesionStateByUserId = obj
            Return CheckUserSeesionStateByUserId

        End Function
        Shared Function CheckSessionState() As Boolean 'Pramila 27jul2017
            CheckSessionState = True
        End Function


#Region "TO CHECK WHETHER MODULE ACTIVE OR INACTIVE"  'RasikV 20180208
        Shared Function FnIsModuleActive(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
               ByVal Div As Integer, ByVal Loc As Integer, ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal UsrId As String) As Boolean
            Try
                Dim orequest As New DBRequest
                orequest.CommandType = CommandType.Text
                orequest.Command = "SELECT [dbo].[FnIsModuleActive]  ('" & CoCd & "', " & Div & ", " & Loc & ", " & ModCd & ", " & SubModCd & ", '" & UsrId & "') IsModuleActive"
                Dim ofactory As New DBFactory
                Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

                If ds.Tables(0).Rows.Count <> 0 Then
                    FnIsModuleActive = ds.Tables(0).Rows(0).Item("IsModuleActive")
                Else
                    FnIsModuleActive = 0
                End If

                If FnIsModuleActive = 0 Then
                    strErrMsg.Add("Module Not Active For Mod Code " & ModCd & ", Sub Mod Code " & SubModCd & " And User Id " & UsrId)
                    chrErrFlg = "Y"
                    FnIsModuleActive = 0
                End If

                orequest = Nothing
                ofactory = Nothing
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                FnIsModuleActive = 0
            End Try
            Return FnIsModuleActive
        End Function
#End Region



#Region "GETALLRATECALULATION / GETSPSELCALRATE001 : For Get All Charge & service code"



        Shared Function GETALLRATECALULATION(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal pcompanycode As String,
                                        ByVal pdiv As Integer,
                                        ByVal ploc As Integer, ByVal objCalRate As clsCalRate) As List(Of clsCalRate)
            GETALLRATECALULATION = New List(Of clsCalRate)
            Dim iSchemeCd As Short = 0
            Dim obj As New clsCalRate
            Dim ofactory As DBFactory
            ofactory = New DBFactory
            Dim LvEmgAmt As Double = 0.0
            Dim objEmgAmt As New CommonModule.clsAdtInDt
            Try

                Dim ds As DataSet = ofactory.ExecuteDataSet(GETSPSELCALRATE001(pcompanycode, pdiv, ploc, objCalRate))
                If ds.Tables(0).Rows.Count <> 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        obj = New clsCalRate
                        iSchemeCd = ds.Tables(0).Rows(i).Item("scheme_cd")
                        obj.SchemeId = iSchemeCd
                        obj.EmergencyFlg = objCalRate.EmergencyFlg
                        obj.lvChrgCd = ds.Tables(0).Rows(i).Item("chrg_Cd")
                        obj.lvSrvCd = ds.Tables(0).Rows(i).Item("srv_cd")
                        obj.StdRt = ds.Tables(0).Rows(i).Item("std_rt")
                        obj.MinRate = ds.Tables(0).Rows(i).Item("min_std_rt_1")
                        obj.MaxRate = ds.Tables(0).Rows(i).Item("max_std_rt_1")
                        obj.Rate = ds.Tables(0).Rows(i).Item("std_rt") 'It will be valid in the case of both after and bfore admission
                        If obj.lvFreeFlag = "F" Then
                            obj.RateChangeType = 1
                        Else
                            If obj.Rate = 0 Then
                                obj.RateChangeType = 3 'allow to enter any value
                                obj.RateChangeFlg = True 'anamika 20131217 flag decide rate field will be editable or not
                            Else
                                If (obj.Rate = obj.MaxRate And obj.Rate = obj.MinRate) Then
                                    obj.RateChangeType = 1 'do not allow user to change rate
                                    obj.RateChangeFlg = False 'anamika 20131217 flag decide rate field will be editable or not
                                Else
                                    If (obj.MaxRate = 0 And obj.MinRate = 0) Then
                                        obj.RateChangeType = 1 'do not allow user to change rate
                                        obj.RateChangeFlg = False 'anamika 20131217 flag decide rate field will be editable or not
                                    Else
                                        obj.RateChangeType = 2 'allow to change rate with min and max limit
                                        ' obj.RateChangeFlg = False 'anamika 20131217 flag decide rate field will be editable or not
                                        obj.RateChangeFlg = True  'anamika 20140411 flag decide rate field will be editable or not
                                    End If
                                End If
                            End If
                        End If

                        If objCalRate.EmergencyFlg = "Y" Then

                            Dim objrate As New clsServiceRate
                            objrate = clsCommonModule.GetEmergencyAmt(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, objEmgAmt, obj.Rate, obj.MaxRate, obj.MinRate)
                            obj.EmergencyPerc = objrate.Per
                            obj.Rate = objrate.Rate
                            obj.MaxRate = objrate.MaxRate
                            obj.MinRate = objrate.MinRate
                            objrate = Nothing
                        Else
                            obj.EmergencyPerc = 0 'anamika 20140604
                        End If

                        obj.lvPtnClsCd = ds.Tables(0).Rows(i).Item("ptn_cls_cd")  '' Amol 2018-11-28
                        GETALLRATECALULATION.Add(obj)
                    Next




                Else
                    GETALLRATECALULATION = Nothing
                    'iSchemeCd = ds.Tables(0).Rows(0).Item("SchemeId")
                    strErrMsg.Clear() '' Added By Amol 2018-08-17  
                    strErrMsg.Add("NO RECORD FOUND IN CAL RATE")
                End If
                Return GETALLRATECALULATION
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
            Exit Function
        End Function
        Shared Function GETSPSELCALRATE001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal objCalRate As clsCalRate) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELCALRATE001]"

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvArCd"
                oParam.ParamValue = objCalRate.lvArCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvChrgCd"
                oParam.ParamValue = objCalRate.lvChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvSrvCd"
                oParam.ParamValue = objCalRate.lvSrvCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pAdmissionDt"
                oParam.ParamValue = objCalRate.AdmissionDate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvPtnClsCd"
                oParam.ParamValue = objCalRate.lvPtnClsCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvFreeFlag"
                oParam.ParamValue = objCalRate.lvFreeFlag
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pRate"
                oParam.ParamValue = objCalRate.Rate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pMinRate"
                oParam.ParamValue = objCalRate.MinRate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pMaxRate"
                oParam.ParamValue = objCalRate.MaxRate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pRateChangeType"
                oParam.ParamValue = objCalRate.RateChangeType
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvIpNo"
                oParam.ParamValue = objCalRate.lvIpNo
                .Parameters.Add(oParam)


                .CommandType = CommandType.StoredProcedure

            End With

            Return oRequest
        End Function
#End Region



#Region "GETALLCALSHARE : For MAX DATA LAOD : Amol 2018-08-02"

        Shared Function GETALLCALSHARE(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal pcompanycode As String,
                                        ByVal pdiv As Integer,
                                        ByVal ploc As Integer, ByVal objCalShare As clsCalShare) As List(Of clsCalShare)
            GETALLCALSHARE = Nothing
            Dim iSchemeCd As Short = 0
            Dim ofactory As DBFactory
            ofactory = New DBFactory

            Dim OBJALLCALSHARE = New List(Of clsCalShare)

            Try

                Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELCALSHARE001(pcompanycode, pdiv, ploc, objCalShare))
                If ds.Tables(0).Rows.Count <> 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        Dim obj As New clsCalShare

                        obj.lvShare = ds.Tables(0).Rows(i).Item("prcnt_amt")
                        obj.SchemeId = ds.Tables(0).Rows(i).Item("scheme_cd")
                        obj.lvPtnClsCd = ds.Tables(0).Rows(i).Item("ptn_cls_cd")
                        obj.lvChrgCd = ds.Tables(0).Rows(i).Item("chrg_Cd")
                        obj.lvSrvCd = ds.Tables(0).Rows(i).Item("srv_cd")

                        'iSchemeCd = ds.Tables(0).Rows(i).Item("scheme_cd")
                        'obj.SchemeId = iSchemeCd
                        'obj.lvShare = ds.Tables(0).Rows(i).Item("prcnt_amt")
                        OBJALLCALSHARE.Add(obj)
                    Next
                Else
                    '   CalShare = Nothing
                    ' strErrMsg.Add("Enter record in service rate master for scheme code " & Val(CStr(iSchemeCd)))
                    'anamika 20131230
                    OBJALLCALSHARE = Nothing
                    iSchemeCd = ds.Tables(1).Rows(0).Item("SchemeId")
                    strErrMsg.Clear() '' Added By Amol 2018-08-17  
                    strErrMsg.Add("Enter record in service rate master for scheme code " & Val(CStr(iSchemeCd)))
                    'end 20131230
                End If
                ds.Dispose()

                GETALLCALSHARE = OBJALLCALSHARE

                Return GETALLCALSHARE
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
            Exit Function
        End Function
        Shared Function SPSELCALSHARE001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal objCalShare As clsCalShare) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELCALSHARE001]"
                .CommandType = CommandType.StoredProcedure

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvArCd"
                oParam.ParamValue = objCalShare.lvArCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvChrgCd"
                oParam.ParamValue = objCalShare.lvChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvSrvCd"
                oParam.ParamValue = objCalShare.lvSrvCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvPtnClsCd"
                oParam.ParamValue = objCalShare.lvPtnClsCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvShare"
                oParam.ParamValue = objCalShare.lvShare
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pAdmissionDt"
                oParam.ParamValue = objCalShare.AdmissionDate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvIpNo"
                oParam.ParamValue = objCalShare.lvIpNo
                .Parameters.Add(oParam)

            End With

            Return oRequest
        End Function
#End Region



#Region "GETALLRATECALULATION / GETSPSELCALRATE002 : For Get All Charge & service code Class diff."
        Shared Function GETALLRATECALULATION01(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal pcompanycode As String,
                                        ByVal pdiv As Integer,
                                        ByVal ploc As Integer, ByVal objCalRate As clsCalRate) As List(Of clsCalRate)
            GETALLRATECALULATION01 = New List(Of clsCalRate)
            Dim iSchemeCd As Short = 0
            Dim obj As New clsCalRate
            Dim ofactory As DBFactory
            ofactory = New DBFactory
            Dim LvEmgAmt As Double = 0.0
            Dim objEmgAmt As New CommonModule.clsAdtInDt
            Try

                Dim ds As DataSet = ofactory.ExecuteDataSet(GETSPSELCALRATE002(pcompanycode, pdiv, ploc, objCalRate))
                If ds.Tables(0).Rows.Count <> 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        obj = New clsCalRate
                        iSchemeCd = ds.Tables(0).Rows(i).Item("scheme_cd")
                        obj.SchemeId = iSchemeCd
                        obj.EmergencyFlg = objCalRate.EmergencyFlg
                        obj.lvChrgCd = ds.Tables(0).Rows(i).Item("chrg_Cd")
                        obj.lvSrvCd = ds.Tables(0).Rows(i).Item("srv_cd")
                        obj.StdRt = ds.Tables(0).Rows(i).Item("std_rt")
                        obj.MinRate = ds.Tables(0).Rows(i).Item("min_std_rt_1")
                        obj.MaxRate = ds.Tables(0).Rows(i).Item("max_std_rt_1")
                        obj.Rate = ds.Tables(0).Rows(i).Item("std_rt") 'It will be valid in the case of both after and bfore admission
                        If obj.lvFreeFlag = "F" Then
                            obj.RateChangeType = 1
                        Else
                            If obj.Rate = 0 Then
                                obj.RateChangeType = 3 'allow to enter any value
                                obj.RateChangeFlg = True 'anamika 20131217 flag decide rate field will be editable or not
                            Else
                                If (obj.Rate = obj.MaxRate And obj.Rate = obj.MinRate) Then
                                    obj.RateChangeType = 1 'do not allow user to change rate
                                    obj.RateChangeFlg = False 'anamika 20131217 flag decide rate field will be editable or not
                                Else
                                    If (obj.MaxRate = 0 And obj.MinRate = 0) Then
                                        obj.RateChangeType = 1 'do not allow user to change rate
                                        obj.RateChangeFlg = False 'anamika 20131217 flag decide rate field will be editable or not
                                    Else
                                        obj.RateChangeType = 2 'allow to change rate with min and max limit
                                        ' obj.RateChangeFlg = False 'anamika 20131217 flag decide rate field will be editable or not
                                        obj.RateChangeFlg = True  'anamika 20140411 flag decide rate field will be editable or not
                                    End If
                                End If
                            End If
                        End If

                        If objCalRate.EmergencyFlg = "Y" Then

                            Dim objrate As New clsServiceRate
                            objrate = clsCommonModule.GetEmergencyAmt(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, objEmgAmt, obj.Rate, obj.MaxRate, obj.MinRate)
                            obj.EmergencyPerc = objrate.Per
                            obj.Rate = objrate.Rate
                            obj.MaxRate = objrate.MaxRate
                            obj.MinRate = objrate.MinRate
                            objrate = Nothing
                        Else
                            obj.EmergencyPerc = 0 'anamika 20140604
                        End If
                        GETALLRATECALULATION01.Add(obj)
                    Next




                Else
                    GETALLRATECALULATION01 = Nothing
                    'iSchemeCd = ds.Tables(0).Rows(0).Item("SchemeId")
                    strErrMsg.Clear() '' Added By Amol 2018-08-17  
                    strErrMsg.Add("NO RECORD FOUND IN CAL RATE")
                End If
                Return GETALLRATECALULATION01
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
            Exit Function
        End Function
        Shared Function GETSPSELCALRATE002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal objCalRate As clsCalRate) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELCALRATE002]"

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvArCd"
                oParam.ParamValue = objCalRate.lvArCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvChrgCd"
                oParam.ParamValue = objCalRate.lvChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvSrvCd"
                oParam.ParamValue = objCalRate.lvSrvCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pAdmissionDt"
                oParam.ParamValue = objCalRate.AdmissionDate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvPtnClsCd"
                oParam.ParamValue = objCalRate.lvPtnClsCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvFreeFlag"
                oParam.ParamValue = objCalRate.lvFreeFlag
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pRate"
                oParam.ParamValue = objCalRate.Rate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pMinRate"
                oParam.ParamValue = objCalRate.MinRate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pMaxRate"
                oParam.ParamValue = objCalRate.MaxRate
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pRateChangeType"
                oParam.ParamValue = objCalRate.RateChangeType
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "plvIpNo"
                oParam.ParamValue = objCalRate.lvIpNo
                .Parameters.Add(oParam)


                .CommandType = CommandType.StoredProcedure

            End With

            Return oRequest
        End Function
#End Region

    End Class


    Public Class clsCalRate
        <DataMember()>
        Public Property lvArCd As Long
        <DataMember()>
        Public Property lvChrgCd As Integer
        <DataMember()>
        Public Property lvSrvCd As Integer
        <DataMember()>
        Public Property lvPtnClsCd As Integer
        <DataMember()>
        Public Property lvFreeFlag As String
        <DataMember()>
        Public Property Rate As Double
        <DataMember()>
        Public Property MinRate As Double
        <DataMember()>
        Public Property MaxRate As Double
        <DataMember()>
        Public Property RateChangeType As Integer
        '<DataMember()>
        'Public Property lvIpNo As Integer
        <DataMember()>
        Public Property lvIpNo As Long 'anamika  20160923
        <DataMember()>
        Public Property SchemeId As Integer
        <DataMember()>
        Public Property AdmissionDate As Date
        <DataMember()>
        Public Property RateChangeFlg As Boolean = False 'anamika 20131211
        <DataMember()>
        Public Property EmergencyFlg As String = "N" 'anamika 20131218
        <DataMember()>
        Public Property EmergencyPerc As Double 'anamika 20140604
        <DataMember()>
        Public Property StdRt As Double 'anamika 20140606
    End Class

    Public Class clsCalShare
        <DataMember()>
        Public Property lvArCd As Long
        <DataMember()>
        Public Property lvChrgCd As Integer
        <DataMember()>
        Public Property lvSrvCd As Integer
        <DataMember()>
        Public Property lvPtnClsCd As Integer
        <DataMember()>
        Public Property lvShare As Double
        '<DataMember()>
        'Public Property lvIpNo As Integer
        <DataMember()>
        Public Property lvIpNo As Long 'anamika 20160923
        <DataMember()>
        Public Property SchemeId As Integer

        <DataMember()>
        Public Property AdmissionDate As Date

    End Class
    Public Class clsCompRate
        <DataMember()>
        Public Property lvArCd As Long
        <DataMember()>
        Public Property lvChrgCd As Integer
        <DataMember()>
        Public Property lvSrvCd As Integer
        <DataMember()>
        Public Property lvCompChrgCd As Integer
        <DataMember()>
        Public Property lvCompSrvCd As Integer
        <DataMember()>
        Public Property lvPtnClsCd As Integer
        <DataMember()>
        Public Property lvCompNo As Integer
        <DataMember()>
        Public Property lvCompVal As String
        '<DataMember()>
        'Public Property lvIpNo As Integer
        <DataMember()>
        Public Property lvIpNo As Long 'anamika 20160927
        <DataMember()>
        Public Property AdmissionDate As Date
        'anamika 20140307
        <DataMember()>
        Public Property SchemeId As Integer
        <DataMember()>
        Public Property lvShare As Double
        'end 20140307
    End Class
    ''' <summary>
    ''' Created  by mayur on 26 Apr 20144
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsSharerAmt

        <DataMember()>
        Public Property Amount As Double
        <DataMember()>
        Public Property ShrAmt As Double
    End Class
    Public Class clsAdtInDt
        Public Property EmergencyPerc As Integer = 0
        Public Property VldPrd As Integer = 0 'anamika  20150128
    End Class
    'anamika 20131206
    Public Class MedicalImagesPath
        <DataMember()>
        Public Property Year As Integer
        <DataMember()>
        Public Property IpOp As String
        '<DataMember()>
        'Public Property PtnNo As Integer
        '<DataMember()>
        'Public Property IpNo As Integer
        <DataMember()>
        Public Property PtnNo As Long 'anamika 20161210
        <DataMember()>
        Public Property IpNo As Long  'anamika 20161210
        <DataMember()>
        Public Property MedRecUId As Long

    End Class
    '20131206

    Public Class clsServiceRate  'aparna 7 mar 2017
        <DataMember()>
        Public Property Rate As Double
        <DataMember()>
        Public Property MaxRate As Double
        <DataMember()>
        Public Property MinRate As Double
        <DataMember()>
        Public Property Per As Double
    End Class


End Namespace