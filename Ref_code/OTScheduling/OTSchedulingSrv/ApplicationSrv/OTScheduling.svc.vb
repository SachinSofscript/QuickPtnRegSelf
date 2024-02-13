Imports SofCommon
Imports System.Runtime.Serialization
Imports Microsoft.Reporting
Imports OTSchedulingSrv.PatientVisitAndBilInsTrn
Imports OTSchedulingSrv
Imports OTSchedulingSrv.CommonModule

Public Class OTScheduling
    Implements iOTScheduling

#Region "Get Prod Hrs And Mins Of OT"
    ''' <summary>
    ''' Get Prod Hrs And Mins Of OT
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTCATCD"></param>
    ''' <param name="FCTMAINCD"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetFctMstDtlList(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer) As List(Of clsMaster) Implements iOTScheduling.GetFctMstDtlList
        GetFctMstDtlList = Nothing
        Try
            GetFctMstDtlList = clsMaster.GetFctMstDtlList(strErrMsg, chrErrFlg, companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD)
        Catch ex As Exception
            GetFctMstDtlList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetFctMstDtlList
    End Function
#End Region

#Region "Get Start Time Of OT against date"
    'mayur 20130913
    ''' <summary>
    ''' '
    ''' Get Start Time Of OT against date
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FctCatCode"></param>
    ''' <param name="FctMainCode"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTDAY"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetFCTFCTSTRTTIME(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FCTDAY As Integer) As Integer Implements iOTScheduling.GetFCTFCTSTRTTIME
        GetFCTFCTSTRTTIME = Nothing
        Try
            GetFCTFCTSTRTTIME = clsFCTCAL.GetFCTFCTSTRTTIME(strErrMsg, chrErrFlg, companycode, companycode, loc, FCTCODE, FctCatCode, FctMainCode, FCTDAY)
        Catch ex As Exception
            GetFCTFCTSTRTTIME = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetFCTFCTSTRTTIME
    End Function
#End Region

#Region "Get End TIME OF OT"
    'mayur 20130913
    ''' <summary>
    ''' 
    ''' Get End TIME OF OT
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FctCatCode"></param>
    ''' <param name="FctMainCode"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTDAY"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 

    Function GetFCTFCTENDTIME(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FCTDAY As Integer) As Integer Implements iOTScheduling.GetFCTFCTENDTIME
        GetFCTFCTENDTIME = Nothing
        Try
            GetFCTFCTENDTIME = clsFCTCAL.GetFCTFCTENDTIME(strErrMsg, chrErrFlg, companycode, companycode, loc, FCTCODE, FctCatCode, FctMainCode, FCTDAY)
        Catch ex As Exception
            GetFCTFCTENDTIME = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetFCTFCTENDTIME
    End Function

#End Region

#Region " Get Data Drom FCTMST"
    'mayur 20130913
    ''' <summary>
    ''' Get Data Drom FCTMST
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTCATCD"></param>
    ''' <param name="FCTMAINCD"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFCTMST(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer) As List(Of clsFCTMST) Implements iOTScheduling.GetFCTMST
        GetFCTMST = Nothing
        Try
            'GetFCTMST = clsFCTMST.GetFCTMST(strErrMsg, chrErrFlg, companycode, companycode, loc, FCTCODE, FCTCATCD, FCTMAINCD)
            GetFCTMST = clsFCTMST.GetFCTMST(strErrMsg, chrErrFlg, companycode, companycode, loc, FCTCODE, 1, FCTMAINCD) 'anamika 20161003 'discussed with sachin
        Catch ex As Exception
            GetFCTMST = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetFCTMST
    End Function

    'mayur 20130913
#End Region

#Region " Get  Patient Details"
    ''' <summary>
    ''' Get  Patient Details
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPatientList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of clsPatient) Implements iOTScheduling.GetPatientList
        GetPatientList = Nothing
        Try
            GetPatientList = clsPatient.GetPatientList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc)
        Catch ex As Exception
            GetPatientList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetPatientList
    End Function
#End Region

#Region "Get Doctor List"
    ''' <summary>
    ''' Get Doctor List
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDoctorList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of clsDoctor) Implements iOTScheduling.GetDoctorList
        GetDoctorList = Nothing
        Try
            GetDoctorList = clsDoctor.GetDoctorList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc)
        Catch ex As Exception
            GetDoctorList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetDoctorList
    End Function
#End Region

#Region " Get OT request Details"
    'mayur 20130916
    ''' <summary>
    ''' Get OT request Details
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FctCatCode"></param>
    ''' <param name="FctMainCode"></param>
    ''' <param name="FCTCODE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFCTAPTREQ(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer) As DataSet Implements iOTScheduling.GetFCTAPTREQ
        GetFCTAPTREQ = Nothing
        Try
            GetFCTAPTREQ = clsFCTPREREQMST.GetFCTAPTREQ001(strErrMsg, chrErrFlg, companycode, div, loc, FctCatCode, FctMainCode, FCTCODE)
        Catch ex As Exception
            GetFCTAPTREQ = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetFCTAPTREQ
    End Function
#End Region


#Region "Get DCT speciality"
    'mayur 20130916
    ''' <summary>
    ''' Get DCT speciality
    ''' 
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DoctorSpeciality(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode) Implements iOTScheduling.DoctorSpeciality

        Try
            DoctorSpeciality = Nothing
            Dim objarr As List(Of clsCodeDecode)
            objarr = clsCodeDecode.DoctorSpeciality(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc)
            DoctorSpeciality = objarr
        Catch ex As Exception
            DoctorSpeciality = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return DoctorSpeciality
    End Function

    'mayur 20130916
#End Region
#Region "Patient search"
    Public Function GetPatientListByNameAndOtherParameter(ByRef strErrMsg As List(Of String),
                                                        ByRef chrErrFlg As Char,
                                                        ByVal companycode As String,
                                                        ByVal div As Integer,
                                                        ByVal loc As Integer,
                                                         ByVal FirstNm As String,
                                                         ByVal MiddleNm As String,
                                                         ByVal LastNm As String,
                                                         ByVal AdditionalCriteria As String
                                                       ) As System.Collections.Generic.List(Of clsPatient) Implements iOTScheduling.GetPatientListByNameAndOtherParameter

        GetPatientListByNameAndOtherParameter = Nothing
        Try
            If AdditionalCriteria <> "" Then
                AdditionalCriteria = "mobile='" + AdditionalCriteria + "'"
            End If

            Dim objPatientList As New List(Of clsPatient)
            objPatientList = clsPatient.GetPatientListByNameAndOtherParameter(strErrMsg, chrErrFlg, companycode, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria)
            GetPatientListByNameAndOtherParameter = objPatientList
        Catch ex As Exception
            GetPatientListByNameAndOtherParameter = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

#End Region

#Region "To save appointment"
    'mayur 20130912
    ''' <summary>
    ''' To save appointment
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="FctCatCode"></param>
    ''' <param name="FctMainCode"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FctDay"></param>
    ''' <param name="SCHDAT"></param>
    ''' <param name="lvReqno"></param>
    ''' <param name="objclsFCTAPTOT"></param>
    ''' <param name="objclsFCTAPTMAIN"></param>
    ''' <param name="mobjFCTAPTREQ"></param>
    ''' <param name="objclsFCTSCH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SAVERECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char,
                               ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer,
                               ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FctDay As Integer,
                               ByVal SCHDAT As Date, ByVal lvReqno As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT,
                               ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ,
                               ByVal objclsFCTSCH As clsFCTSCH, ByVal objOtIndirectBooking As ClsOtIndirectBooking,
                               ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv),
                               ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc),
                               ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp),
                               ByRef AptNo As Integer) As Boolean Implements iOTScheduling.SAVERECORD

        SAVERECORD = False

        Dim ofactory As DBFactory
        ofactory = New DBFactory
        Dim ds As New DataSet
        Dim obj As New clsInsertUpdateSrNo
        Dim inapptno As Integer

        Try


            'RasikV 20180918 [SMS] : Start Here
            inapptno = obj.GetUpdateFCTDOCUNO(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc)
            If inapptno = 0 Then
                chrErrFlg = "Y"
                strErrMsg.Add("Appointment No Not Generated")
                Return False
            Else
                objclsFCTAPTOT.APPTNO = inapptno
                objclsFCTAPTMAIN.APPTNO = inapptno
                objclsFCTSCH.APPTNO = inapptno
                mobjFCTAPTREQ.APPTNO = inapptno
            End If

            Dim ArrObjSmsEntry As New List(Of clsSmsDtl)
            Dim IsSmsTypeActive As Boolean = False
            Dim ModCd As Integer = clsMainModule.AccessModCode.OTScheduling
            Dim SubModCd As Integer = clsMainModule.AccessSubModCd.OTScheduling
            Dim CatTyp As Integer = clsMainModule.EnumSmsInternal.OtScheduling
            IsSmsTypeActive = clsSmsMst.FnIsSmsTypeActive(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, SubModCd, CatTyp)
            If IsSmsTypeActive = True And (objclsFCTAPTOT IsNot Nothing) Then
                Dim DSFetchDataMainDoc As New DataSet

                'SEND SMS TO MAIN DOCTOR
                Dim ArrObjSmsMainDocDtl As New List(Of clsSMSMstDetails)
                ArrObjSmsMainDocDtl = GetOtSchedulingSmsList(strErrMsg, chrErrFlg, DSFetchDataMainDoc, pcompanycode,
                                                             pdiv, ploc, ModCd, SubModCd, CatTyp,
                                                             objclsFCTAPTOT.DOCCD, Nothing, objclsFCTAPTOT)
                If ArrObjSmsMainDocDtl IsNot Nothing Then
                    If ArrObjSmsMainDocDtl.Count > 0 Then
                        If DSFetchDataMainDoc IsNot Nothing Then
                            If DSFetchDataMainDoc.Tables.Count > 0 Then

                                For iTblCnt As Integer = 0 To DSFetchDataMainDoc.Tables.Count - 1

                                    If DSFetchDataMainDoc.Tables(iTblCnt).Rows.Count > 0 Then
                                        Dim ArrObjSmsMainDoc As New List(Of clsSmsDtl)
                                        ArrObjSmsMainDoc = clsSmsDtl.ValidateSMSMain(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, SubModCd, objclsFCTAPTOT.CRTDTTM, objclsFCTAPTOT.CRTUSRID, CatTyp, ArrObjSmsMainDocDtl, DSFetchDataMainDoc)

                                        If ArrObjSmsMainDoc Is Nothing Then
                                            If strErrMsg.Count > 0 Then
                                                strErrMsg.Add(strErrMsg.Count - 1)
                                                ofactory.RollBackExecution()
                                                chrErrFlg = "Y"
                                                Return False
                                            End If
                                        End If

                                        If ArrObjSmsMainDoc.Count <= 0 Then
                                            If strErrMsg.Count > 0 Then
                                                strErrMsg.Add(strErrMsg.Count - 1)
                                                ofactory.RollBackExecution()
                                                chrErrFlg = "Y"
                                                Return False
                                            End If
                                        End If

                                        ArrObjSmsEntry.AddRange(ArrObjSmsMainDoc)
                                    End If

                                Next

                            End If
                        End If

                    End If
                End If

                'SEND SMS TO OPERATION DOCTORS
                If arrObjOtDocLst IsNot Nothing Then
                    If arrObjOtDocLst.Count > 0 Then

                        For iCnt As Integer = 0 To arrObjOtDocLst.Count - 1

                            If arrObjOtDocLst(iCnt).DocCd <> objclsFCTAPTOT.DOCCD Then  'CHECK OT DOCTOR AND OPERATION DOCTOR
                                Dim DSFetchDataDoc As New DataSet
                                Dim ArrObjSmsDocDtl As New List(Of clsSMSMstDetails)

                                ArrObjSmsDocDtl = GetOtSchedulingSmsList(strErrMsg, chrErrFlg, DSFetchDataDoc, pcompanycode, pdiv, ploc, ModCd, SubModCd, CatTyp, arrObjOtDocLst(iCnt).DocCd, Nothing, objclsFCTAPTOT)
                                If ArrObjSmsDocDtl IsNot Nothing Then
                                    If ArrObjSmsDocDtl.Count > 0 Then
                                        If DSFetchDataDoc IsNot Nothing Then
                                            If DSFetchDataDoc.Tables.Count > 0 Then

                                                For iTblCnt As Integer = 0 To DSFetchDataDoc.Tables.Count - 1

                                                    If DSFetchDataDoc.Tables(iTblCnt).Rows.Count > 0 Then
                                                        Dim ArrObjSmsDoc As New List(Of clsSmsDtl)
                                                        ArrObjSmsDoc = clsSmsDtl.ValidateSMSMain(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, SubModCd, objclsFCTAPTOT.CRTDTTM, objclsFCTAPTOT.CRTUSRID, CatTyp, ArrObjSmsDocDtl, DSFetchDataDoc)

                                                        If ArrObjSmsDoc Is Nothing Then
                                                            If strErrMsg.Count > 0 Then
                                                                strErrMsg.Add(strErrMsg.Count - 1)
                                                                ofactory.RollBackExecution()
                                                                chrErrFlg = "Y"
                                                                Return False
                                                            End If
                                                        End If

                                                        If ArrObjSmsDoc.Count <= 0 Then
                                                            If strErrMsg.Count > 0 Then
                                                                strErrMsg.Add(strErrMsg.Count - 1)
                                                                ofactory.RollBackExecution()
                                                                chrErrFlg = "Y"
                                                                Return False
                                                            End If
                                                        End If

                                                        ArrObjSmsEntry.AddRange(ArrObjSmsDoc)
                                                    End If

                                                Next

                                            End If
                                        End If

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

                'SEND SMS TO OPERATION EMPLOYEES
                If arrObjOtEmpLst IsNot Nothing Then
                    If arrObjOtEmpLst.Count > 0 Then

                        For iCnt As Integer = 0 To arrObjOtEmpLst.Count - 1
                            Dim DSFetchDataEmp As New DataSet
                            Dim ArrObjSmsEmpDtl As New List(Of clsSMSMstDetails)

                            ArrObjSmsEmpDtl = GetOtSchedulingSmsList(strErrMsg, chrErrFlg, DSFetchDataEmp, pcompanycode, pdiv, ploc, ModCd, SubModCd, CatTyp, Nothing, arrObjOtEmpLst(iCnt).EmpCd, objclsFCTAPTOT)
                            If ArrObjSmsEmpDtl IsNot Nothing Then
                                If ArrObjSmsEmpDtl.Count > 0 Then
                                    If DSFetchDataEmp IsNot Nothing Then
                                        If DSFetchDataEmp.Tables.Count > 0 Then

                                            For iTblCnt As Integer = 0 To DSFetchDataEmp.Tables.Count - 1

                                                If DSFetchDataEmp.Tables(iTblCnt).Rows.Count > 0 Then
                                                    Dim ArrObjSmsEmp As New List(Of clsSmsDtl)
                                                    ArrObjSmsEmp = clsSmsDtl.ValidateSMSMain(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, SubModCd, objclsFCTAPTOT.CRTDTTM, objclsFCTAPTOT.CRTUSRID, CatTyp, ArrObjSmsEmpDtl, DSFetchDataEmp)

                                                    If ArrObjSmsEmp Is Nothing Then
                                                        If strErrMsg.Count > 0 Then
                                                            strErrMsg.Add(strErrMsg.Count - 1)
                                                            ofactory.RollBackExecution()
                                                            chrErrFlg = "Y"
                                                            Return False
                                                        End If
                                                    End If

                                                    If ArrObjSmsEmp.Count <= 0 Then
                                                        If strErrMsg.Count > 0 Then
                                                            strErrMsg.Add(strErrMsg.Count - 1)
                                                            ofactory.RollBackExecution()
                                                            chrErrFlg = "Y"
                                                            Return False
                                                        End If
                                                    End If

                                                    ArrObjSmsEntry.AddRange(ArrObjSmsEmp)
                                                End If

                                            Next

                                        End If
                                    End If

                                End If
                            End If
                        Next

                    End If
                End If

            End If
            'RasikV 20180918 [SMS] : End Here

            ofactory.BeginExecution("Y")

            objclsFCTAPTOT.FctCatCode = FctCatCode
            objclsFCTAPTOT.FctMainCode = FctMainCode
            objclsFCTAPTOT.FCTCODE = FCTCODE
            objclsFCTAPTOT.CompanyCode = pcompanycode
            objclsFCTAPTOT.DivisionCode = pdiv
            objclsFCTAPTOT.LocationCode = ploc

            objclsFCTAPTMAIN.FctCatCode = FctCatCode
            objclsFCTAPTMAIN.FctMainCode = FctMainCode
            objclsFCTAPTMAIN.FCTCODE = FCTCODE
            objclsFCTAPTMAIN.CompanyCode = pcompanycode
            objclsFCTAPTMAIN.DivisionCode = pdiv
            objclsFCTAPTMAIN.LocationCode = ploc

            mobjFCTAPTREQ.FctCatCode = FctCatCode
            mobjFCTAPTREQ.FctMainCode = FctMainCode
            mobjFCTAPTREQ.FCTCODE = FCTCODE
            mobjFCTAPTREQ.CompanyCode = pcompanycode
            mobjFCTAPTREQ.DivisionCode = pdiv
            mobjFCTAPTREQ.LocationCode = ploc

            objclsFCTSCH.FctCatCode = FctCatCode
            objclsFCTSCH.FctMainCode = FctMainCode
            objclsFCTSCH.FCTCODE = FCTCODE
            objclsFCTSCH.CompanyCode = pcompanycode
            objclsFCTSCH.DivisionCode = pdiv
            objclsFCTSCH.LocationCode = ploc

            ds = clsFCTPREREQMST.GetFCTAPTREQMST001(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FctCatCode, FctMainCode, FCTCODE, FctDay, SCHDAT)

            If (ds IsNot Nothing) Then
                Dim lvSlotNo As Integer
                Dim lvSessSt As Date
                Dim lvSessEn As Date
                Dim lvSessDur As Long
                Dim lvSlotDur As Long
                Dim lvNoSlot As Long
                Dim lv2 As Date
                Dim lv3 As Date

                Dim lv_fct_slot_prd_hrs As Integer
                Dim lv_fct_slot_prd_mins As Integer

                If (ds.Tables(0).Rows.Count > 0) Then

                    For intI As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        lvSlotNo = 1

                        Dim clsmstr As List(Of clsMaster)
                        clsmstr = GetFctMstDtlList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, 1, 1)
                        lv_fct_slot_prd_hrs = clsmstr(0).data2
                        lv_fct_slot_prd_mins = clsmstr(0).data3

                        Dim fromhrs As String = ds.Tables(0).Rows(intI).Item("fctc_time_from_hrs").ToString()
                        Dim frommins As String = ds.Tables(0).Rows(intI).Item("fctc_time_from_mins").ToString()
                        Dim tohrs As String = ds.Tables(0).Rows(intI).Item("fctc_time_to_hrs").ToString()
                        Dim tomins As String = ds.Tables(0).Rows(intI).Item("fctc_time_to_mins").ToString()

                        If (fromhrs.Length = 3) Then
                            fromhrs = "0" & fromhrs
                        End If
                        If (frommins.Length = 3) Then
                            frommins = "0" & frommins
                        End If
                        If (tohrs.Length = 3) Then
                            tohrs = "0" & tohrs
                        End If
                        If (tomins.Length = 3) Then
                            tomins = "0" & tomins
                        End If

                        lvSessSt = CDate(fromhrs & ":" & frommins)
                        lvSessEn = CDate(tohrs & ":" & tomins)

                        lvSessDur = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, lvSessSt, lvSessEn)
                        If ds.Tables(0).Rows(intI).Item("fct_slot_prd_hrs") <> 0 Then
                            lvSlotDur = (lv_fct_slot_prd_hrs * 60) + lv_fct_slot_prd_mins
                        Else
                            lvSlotDur = lv_fct_slot_prd_mins
                        End If

                        lvNoSlot = System.Math.Abs(lvSessDur / lvSlotDur)
                        lv2 = lvSessSt
                        For i = 1 To lvNoSlot
                            Dim objFCT_SCH As New clsFCTSCH
                            objFCT_SCH.CompanyCode = pcompanycode
                            objFCT_SCH.DivisionCode = pdiv
                            objFCT_SCH.LocationCode = ploc
                            objFCT_SCH.FctCatCode = FctCatCode
                            objFCT_SCH.FCTCODE = ds.Tables(0).Rows(intI).Item("fct_code").ToString
                            objFCT_SCH.FctMainCode = FctMainCode
                            objFCT_SCH.SCHDATE = SCHDAT
                            objFCT_SCH.SESSIONCODE = (ds.Tables(0).Rows(intI).Item("fctc_session_code"))
                            objFCT_SCH.SLOTNO = lvNoSlot
                            objFCT_SCH.SCHTIMEFROMHRS = ds.Tables(0).Rows(intI).Item("fctc_time_from_hrs")
                            objFCT_SCH.SCHTIMETOHRS = ds.Tables(0).Rows(intI).Item("fctc_time_to_hrs")
                            objFCT_SCH.SCHTIMETOMINS = ds.Tables(0).Rows(intI).Item("fctc_time_to_mins")
                            objFCT_SCH.SCHTIMETOHRS = (ds.Tables(0).Rows(intI).Item("fctc_time_to_hrs"))
                            objFCT_SCH.APPTNO = 0
                            objFCT_SCH.APTMSTS = 0
                            objFCT_SCH.IPOPFLG = " "
                            objFCT_SCH.IPOPNO = 0
                            objFCT_SCH.CHRGCD = 0
                            objFCT_SCH.TESTCD = 0
                            objFCT_SCH.APTMREFBY = " "
                            objFCT_SCH.ICDGRPCD = " "
                            objFCT_SCH.ICDCODE = " "

                            Dim oRequest As DBRequest
                            oRequest = clsInsertUpdateFCTFCH.SPINSFCTSCH(objFCT_SCH)
                            ofactory.ExecuteNonQuery(oRequest)
                            lv2 = lv3
                            lvSlotNo = lvSlotNo + 1
                        Next i
                    Next
                Else 'mayur 20141031
                    'strErrMsg.Add("No record created for the given date and ot is not available for day")
                    'ofactory.RollBackExecution()
                    'chrErrFlg = "Y"
                    'Return False
                End If
            Else 'mayur 20141031
                'strErrMsg.Add("No record created for the given date and ot is not available for day")
                'ofactory.RollBackExecution()
                'chrErrFlg = "Y"
                'Return False
            End If

            ''RASIK 19 SEP 2018
            'inapptno = obj.GetUpdateFCTDOCUNO(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc)
            'objclsFCTAPTOT.APPTNO = inapptno
            'objclsFCTAPTMAIN.APPTNO = inapptno
            'objclsFCTSCH.APPTNO = inapptno
            'mobjFCTAPTREQ.APPTNO = inapptno
            ''RASIK 19 SEP 2018


            Dim dbreqSPINSFCTAPTOT As DBRequest
            dbreqSPINSFCTAPTOT = clsInsertUpdateFCTAPTOT.SPINSFCTAPTOT(objclsFCTAPTOT)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTOT)

            If (lvReqno <> 0) Then
                Dim dbreqSPUPDFCTREQ As DBRequest
                mobjFCTAPTREQ.REQNO = lvReqno
                dbreqSPUPDFCTREQ = clsinsertUpdateFCTAPTREQ.SPUPDFCTREQ(mobjFCTAPTREQ)
                ' ofactory.ExecuteNonQuery(dbreqSPUPDFCTREQ)
                If ofactory.ExecuteNonQuery(dbreqSPUPDFCTREQ) = 0 Then 'anamika 20140723
                    strErrMsg.Add("Record not updated into  FCT_APT_REQUEST")
                    ofactory.RollBackExecution()
                    chrErrFlg = "Y"
                    Return False
                End If
            End If


            Dim pobjclsFCTMST As List(Of clsFCTMST)
            'pobjclsFCTMST = clsFCTMST.GetFCTMST(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode)
            pobjclsFCTMST = clsFCTMST.GetFCTMST(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, 1, FctMainCode) 'anamika 20161003 discussed with sachin
            objclsFCTAPTMAIN.CHRGCD = pobjclsFCTMST(0).FCTRCHRGCD
            objclsFCTAPTMAIN.TESTCD = pobjclsFCTMST(0).FCTRTSTCD
            objclsFCTSCH.CHRGCD = pobjclsFCTMST(0).FCTRCHRGCD
            objclsFCTSCH.TESTCD = pobjclsFCTMST(0).FCTRTSTCD


            Dim dbreqSPINSFCTAPTMAIN As DBRequest
            dbreqSPINSFCTAPTMAIN = clsInsertUpdateFCTAPTMAIN.SPINSFCTAPTMAIN(objclsFCTAPTMAIN)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTMAIN)

            Dim dbreqSPUPDFCTSCH002 As DBRequest
            dbreqSPUPDFCTSCH002 = clsInsertUpdateFCTFCH.SPUPDFCTSCH002(objclsFCTSCH)
            ' ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH002)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH002) = 0 Then 'anamika 20140723
                'strErrMsg.Add("Record not updated into FCT_SCH ") 'do not uncomment this code
                'ofactory.RollBackExecution()
                'chrErrFlg = "Y"
                'Return False
            End If

            Dim pobjFCTAPTREQMST = clsFCTPREREQMST.GetFCTAPTREQMST(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, pobjclsFCTMST(0).FCTRCHRGCD, pobjclsFCTMST(0).FCTRTSTCD)


            If (pobjFCTAPTREQMST IsNot Nothing) Then
                For intI As Integer = 0 To pobjFCTAPTREQMST.Count - 1
                    Dim pobclsFCTPREREQ As clsFCTPREREQ
                    pobclsFCTPREREQ = clsFCTPREREQ.GetFCTAPTREQ(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode, pobjFCTAPTREQMST(intI).PREREQCD, inapptno, objclsFCTAPTMAIN.IPOP)
                    mobjFCTAPTREQ.PRMREQCODE = pobjFCTAPTREQMST(intI).PREREQCD
                    Dim dbreqSPINSFCTAPTREQUEST As DBRequest
                    dbreqSPINSFCTAPTREQUEST = clsinsertUpdateFCTAPTREQ.SPINSFCTAPTREQ(mobjFCTAPTREQ)
                    ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTREQUEST)
                Next intI
            End If


            If objOtIndirectBooking IsNot Nothing Then 'anamika 20161001
                Dim oRequest As DBRequest
                oRequest = clsInsertUpdateOtIndirectBooking.SpUpOtIndirctBookng001(strErrMsg, chrErrFlg, pcompanycode, pdiv,
                                                                                   ploc, objOtIndirectBooking.TrnNo,
                                                                                   objOtIndirectBooking.PtnNo, objOtIndirectBooking.Status, objOtIndirectBooking.UserId, objOtIndirectBooking.UserDtTm)
                ofactory.ExecuteNonQuery(oRequest)
            End If


            'save OT SERVICES RECORDS : pragya : 14-oct-2016
            If (arrObjOtSrvLst IsNot Nothing) Then
                If arrObjOtSrvLst.Count > 0 Then
                    Dim ApptNo As Integer = inapptno
                    Dim dbrequest As DBRequest = clsInsertUpdateFctAptOtSrv.SpDelFctAptOtSrv(pcompanycode, pdiv, ploc, ApptNo, FctCatCode, FctMainCode, FCTCODE)
                    'strErrMsg.Add("9")
                    ofactory.ExecuteNonQuery(dbrequest)
                    For iSrv As Integer = 0 To arrObjOtSrvLst.Count - 1
                        arrObjOtSrvLst(iSrv).ApptNo = inapptno
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtSrv.SpInsUpdFctAptOtSrv(pcompanycode, pdiv, ploc, arrObjOtSrvLst(iSrv))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            strErrMsg.Add("Record not Inserted into Fct_Apt_Ot_Srv.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iSrv
                    'strErrMsg.Add("10")
                End If

            End If

            'save OT DOCTORS RECORDS : pragya : 14-oct-2016
            If (arrObjOtDocLst IsNot Nothing) Then
                If arrObjOtDocLst.Count > 0 Then
                    Dim ApptNo As Integer = inapptno
                    Dim DocCd As Integer = arrObjOtDocLst(0).DocCd
                    Dim dbrequest As DBRequest = clsInsertUpdateFctAptOtDoc.SpDelFctAptOtDoc(pcompanycode, pdiv, ploc, ApptNo, DocCd)
                    ofactory.ExecuteNonQuery(dbrequest)
                    'strErrMsg.Add("A")
                    For iDoc As Integer = 0 To arrObjOtDocLst.Count - 1
                        'inapptno
                        arrObjOtDocLst(iDoc).ApptNo = inapptno
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtDoc.SpInsUpdFctAptOtDoc(pcompanycode, pdiv, ploc, arrObjOtDocLst(iDoc))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            'strErrMsg.Add("B")
                            strErrMsg.Add("Record not Inserted into FCT_APT_OT_DOC.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                        'strErrMsg.Add(iDoc)
                    Next iDoc
                End If

            End If
            'save OT EMPLOYEE/NURSE  RECORDS : pragya : 01-DEC-2016
            If (arrObjOtEmpLst IsNot Nothing) Then
                If arrObjOtEmpLst.Count > 0 Then
                    Dim ApptNo As Integer = inapptno
                    Dim IpNO As Long = arrObjOtEmpLst(0).IpNo
                    Dim PtnNo As Long = arrObjOtEmpLst(0).PtnNo
                    Dim dbrequest As DBRequest = clsInsertUpdateFctAptOtEmp.SpDelFctAptOtEmp(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, ApptNo, PtnNo, IpNO)
                    ofactory.ExecuteNonQuery(dbrequest)
                    'strErrMsg.Add("A")
                    For iEmp As Integer = 0 To arrObjOtEmpLst.Count - 1
                        arrObjOtEmpLst(iEmp).ApptNo = inapptno   'PRAGYA : 20161202
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtEmp.SpInsFctAptOtEmp(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, arrObjOtEmpLst(iEmp))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            'strErrMsg.Add("B")
                            strErrMsg.Add("Record not Inserted into FCT_APT_OT_EMP.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iEmp
                End If
            End If

            'RasikV 20180918 [SMS] : Start Here 
            If ArrObjSmsEntry IsNot Nothing Then
                If ArrObjSmsEntry.Count > 0 Then
                    Dim DBRequest As New DBRequest
                    For i As Integer = 0 To ArrObjSmsEntry.Count - 1
                        ArrObjSmsEntry(i).SmsVchNo = 0
                        ArrObjSmsEntry(i).SmsPTNNo = 0
                        DBRequest = clsInsertUpdateSmsDtl.SpInsSmsDtl(pcompanycode, pdiv, ploc, ArrObjSmsEntry(i))
                        ofactory.ExecuteNonQuery(DBRequest)
                    Next
                End If
            End If
            'RasikV 20180918 [SMS] : End Here 


            ofactory.CommitExecution()

            SAVERECORD = True


        Catch ex As Exception
            ofactory.RollBackExecution()
        End Try
        AptNo = inapptno
        Return SAVERECORD
    End Function

    'mayur20130912
#End Region

#Region " update OT appointment details"
    ''' <summary>
    ''' To update OT appointment details
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="FctCatCode"></param>
    ''' <param name="FctMainCode"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FctDay"></param>
    ''' <param name="SCHDAT"></param>
    ''' <param name="lvReqno"></param>
    ''' <param name="ApptNo"></param>
    ''' <param name="objclsFCTAPTOT"></param>
    ''' <param name="objclsFCTAPTMAIN"></param>
    ''' <param name="mobjFCTAPTREQ"></param>
    ''' <param name="objclsFCTSCH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EDITERECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FctDay As Integer, ByVal SCHDAT As Date, ByVal lvReqno As Integer, ByVal ApptNo As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp)) As Boolean Implements iOTScheduling.EDITERECORD

        EDITERECORD = False
        Dim ofactory As DBFactory
        ofactory = New DBFactory
        Dim ds As New DataSet
        Dim obj As New clsInsertUpdateSrNo
        Dim inapptno As Integer = 0
        Dim ErrorPoint As String = String.Empty
        Try

            ErrorPoint = "START EDIT RECORD APPLY VALUE"

            inapptno = ApptNo
            objclsFCTAPTOT.FctCatCode = FctCatCode
            objclsFCTAPTOT.FctMainCode = FctMainCode
            objclsFCTAPTOT.FCTCODE = FCTCODE
            objclsFCTAPTOT.CompanyCode = pcompanycode
            objclsFCTAPTOT.DivisionCode = pdiv
            objclsFCTAPTOT.LocationCode = ploc

            objclsFCTAPTMAIN.FctCatCode = FctCatCode
            objclsFCTAPTMAIN.FctMainCode = FctMainCode
            objclsFCTAPTMAIN.FCTCODE = FCTCODE
            objclsFCTAPTMAIN.CompanyCode = pcompanycode
            objclsFCTAPTMAIN.DivisionCode = pdiv
            objclsFCTAPTMAIN.LocationCode = ploc

            mobjFCTAPTREQ.FctCatCode = FctCatCode
            mobjFCTAPTREQ.FctMainCode = FctMainCode
            mobjFCTAPTREQ.FCTCODE = FCTCODE
            mobjFCTAPTREQ.CompanyCode = pcompanycode
            mobjFCTAPTREQ.DivisionCode = pdiv
            mobjFCTAPTREQ.LocationCode = ploc

            objclsFCTSCH.FctCatCode = FctCatCode
            objclsFCTSCH.FctMainCode = FctMainCode
            objclsFCTSCH.FCTCODE = FCTCODE
            objclsFCTSCH.CompanyCode = pcompanycode
            objclsFCTSCH.DivisionCode = pdiv
            objclsFCTSCH.LocationCode = ploc

            objclsFCTAPTOT.APPTNO = inapptno
            objclsFCTAPTMAIN.APPTNO = inapptno
            objclsFCTSCH.APPTNO = inapptno
            mobjFCTAPTREQ.APPTNO = inapptno


            ErrorPoint = "execute Object pobjclsFCTMST "

            Dim pobjclsFCTMST As List(Of clsFCTMST)
            pobjclsFCTMST = clsFCTMST.GetFCTMST(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode)

            objclsFCTSCH.CHRGCD = 0
            objclsFCTSCH.TESTCD = 0
            objclsFCTSCH.APPTNO = inapptno
            objclsFCTSCH.CHRGCD = pobjclsFCTMST(0).FCTRCHRGCD
            objclsFCTSCH.TESTCD = pobjclsFCTMST(0).FCTRTSTCD


            ErrorPoint = "execute Object pobjFCTAPTREQMST  "

            Dim pobjFCTAPTREQMST = clsFCTPREREQMST.GetFCTAPTREQMST(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, pobjclsFCTMST(0).FCTRCHRGCD, pobjclsFCTMST(0).FCTRTSTCD)


            ErrorPoint = "execute Object BeginExecution   "


            ofactory.BeginExecution("Y")

            '   inapptno = ApptNo 'obj.GetUpdateFCTDOCUNO(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc)


            ErrorPoint = "execute Object dbreqSPINSFCTAPTOT   "

            Dim dbreqSPINSFCTAPTOT As DBRequest
            dbreqSPINSFCTAPTOT = clsInsertUpdateFCTAPTOT.SPINSFCTAPTOT(objclsFCTAPTOT)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTOT)


            ErrorPoint = "execute Object dbreqSPUPDFCTAPTMAIN   "
            Dim dbreqSPUPDFCTAPTMAIN As DBRequest
            dbreqSPUPDFCTAPTMAIN = clsInsertUpdateFCTAPTMAIN.SPUPDFCTAPTMAIN(objclsFCTAPTMAIN)
            'ofactory.ExecuteNonQuery(dbreqSPUPDFCTAPTMAIN)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTAPTMAIN) = 0 Then 'anamika 20140723
                strErrMsg.Add("Record not updated into  FCT_APT_MAIN")
                ofactory.RollBackExecution()
                chrErrFlg = "Y"
                Return False
            End If



            ErrorPoint = "execute Object dbreqSPUPDFCTSCH   "
            Dim dbreqSPUPDFCTSCH As DBRequest
            dbreqSPUPDFCTSCH = clsInsertUpdateFCTFCH.SPUPDFCTSCH(objclsFCTSCH)
            '  ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH) = 0 Then 'anamika 20140723
                'strErrMsg.Add("Record not updated into  fct_sch")
                'ofactory.RollBackExecution()
                'chrErrFlg = "Y"
                'Return False
            End If


            ErrorPoint = "execute Object dbreqSPUPDFCTSCH002   "
            Dim dbreqSPUPDFCTSCH002 As DBRequest
            dbreqSPUPDFCTSCH002 = clsInsertUpdateFCTFCH.SPUPDFCTSCH002(objclsFCTSCH)
            ' ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH002)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH002) = 0 Then 'anamika 20140723
                'strErrMsg.Add("Record not updated into  ")'do not uncomment this code
                'ofactory.RollBackExecution()
                'chrErrFlg = "Y"
                'Return False
            End If



            ErrorPoint = "execute Object pobjFCTAPTREQMST   "
            If (pobjFCTAPTREQMST IsNot Nothing) Then
                For intI As Integer = 0 To pobjFCTAPTREQMST.Count - 1
                    Dim pobclsFCTPREREQ As clsFCTPREREQ
                    pobclsFCTPREREQ = clsFCTPREREQ.GetFCTAPTREQ(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode, pobjFCTAPTREQMST(intI).PREREQCD, inapptno, objclsFCTAPTMAIN.IPOP)
                    mobjFCTAPTREQ.PRMREQCODE = pobjFCTAPTREQMST(intI).PREREQCD
                    Dim dbreqSPINSFCTAPTREQUEST As DBRequest
                    dbreqSPINSFCTAPTREQUEST = clsinsertUpdateFCTAPTREQ.SPINSFCTAPTREQ(mobjFCTAPTREQ)
                    ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTREQUEST)
                Next intI
            End If

            ErrorPoint = "execute Object dbrequestSrvDel   "
            '' move Here by Amol 2019-12-19 For Delete  Record in Every cases
            Dim ApptNo1 As Integer
            Dim IsDataSrv As Boolean = False

            If arrObjOtSrvLst IsNot Nothing Then
                If arrObjOtSrvLst.Count > 0 Then
                    IsDataSrv = True
                End If
            End If

            If IsDataSrv = True Then
                ApptNo1 = arrObjOtSrvLst(0).ApptNo
            Else
                ApptNo1 = inapptno
            End If

            Dim dbrequestSrvDel As DBRequest = clsInsertUpdateFctAptOtSrv.SpDelFctAptOtSrv(pcompanycode, pdiv, ploc, ApptNo1, FctCatCode, FctMainCode, FCTCODE)
            ofactory.ExecuteNonQuery(dbrequestSrvDel)
            '' move Here by Amol 2019-12-19 For Delete  Record in Every cases

            ErrorPoint = "execute Object arrObjOtSrvLst   "
            'save OT SERVICES RECORDS : pragya : 14-oct-2016
            If (arrObjOtSrvLst IsNot Nothing) Then
                If arrObjOtSrvLst.Count > 0 Then

                    For iSrv As Integer = 0 To arrObjOtSrvLst.Count - 1
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtSrv.SpInsUpdFctAptOtSrv(pcompanycode, pdiv, ploc, arrObjOtSrvLst(iSrv))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            strErrMsg.Add("Record not Updated in Fct_Apt_Ot_Srv.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iSrv
                End If
            End If

            'strErrMsg.Add("8")


            ErrorPoint = "execute Object dbrequestDocDel   "
            'save OT DOCTORS RECORDS : pragya : 14-oct-2016

            '' move Here by Amol 2019-12-19 For Delete  Record in Every cases
            Dim IsDataDoc As Boolean = False
            Dim ApptNo2 As Integer
            Dim DocCd As Integer

            If arrObjOtDocLst IsNot Nothing Then
                If arrObjOtDocLst.Count > 0 Then
                    IsDataDoc = True
                End If
            End If


            If IsDataDoc = True Then
                ApptNo2 = arrObjOtDocLst(0).ApptNo
                DocCd = arrObjOtDocLst(0).DocCd
            Else
                ApptNo2 = inapptno
                DocCd = 0
            End If


            Dim dbrequestDocDel As DBRequest = clsInsertUpdateFctAptOtDoc.SpDelFctAptOtDoc(pcompanycode, pdiv, ploc, ApptNo2, DocCd)
            ofactory.ExecuteNonQuery(dbrequestDocDel)
            '' move Here by Amol 2019-12-19 For Delete  Record in Every cases

            ErrorPoint = "execute Object arrObjOtDocLst   "

            If (arrObjOtDocLst IsNot Nothing) Then
                If arrObjOtDocLst.Count > 0 Then
                    For iDoc As Integer = 0 To arrObjOtDocLst.Count - 1
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtDoc.SpInsUpdFctAptOtDoc(pcompanycode, pdiv, ploc, arrObjOtDocLst(iDoc))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            strErrMsg.Add("Record not Updated in FCT_APT_OT_DOC.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iDoc
                End If

            End If



            ErrorPoint = "execute Object dbrequestEmpDel   "
            'save OT EMPLOYEE/NURSE  RECORDS : pragya : 01-DEC-2016
            '' move Here by Amol 2019-12-19 For Delete  Record in Every cases
            Dim ApptNo3 As Integer
            Dim IsDataEmp As Boolean = False
            Dim IpNO As Long = 0
            Dim PtnNo As Long = 0
            If arrObjOtEmpLst IsNot Nothing Then
                If arrObjOtEmpLst.Count > 0 Then
                    IsDataEmp = True
                End If
            End If

            If IsDataEmp = True Then
                ApptNo3 = arrObjOtEmpLst(0).ApptNo
                IpNO = arrObjOtEmpLst(0).IpNo
                PtnNo = arrObjOtEmpLst(0).PtnNo
            Else
                ApptNo3 = inapptno
                IpNO = 0
                PtnNo = 0
            End If


            Dim dbrequestEmpDel As DBRequest = clsInsertUpdateFctAptOtEmp.SpDelFctAptOtEmp(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, ApptNo3, PtnNo, IpNO)
            ofactory.ExecuteNonQuery(dbrequestEmpDel)
            '' move Here by Amol 2019-12-19 For Delete  Record in Every cases


            ErrorPoint = "execute Object arrObjOtEmpLst   "
            If (arrObjOtEmpLst IsNot Nothing) Then
                If arrObjOtEmpLst.Count > 0 Then
                    'strErrMsg.Add("A")
                    For iEmp As Integer = 0 To arrObjOtEmpLst.Count - 1
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtEmp.SpInsFctAptOtEmp(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, arrObjOtEmpLst(iEmp))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            'strErrMsg.Add("B")
                            strErrMsg.Add("Record not Inserted into FCT_APT_OT_EMP.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iEmp
                End If
            End If


            ofactory.CommitExecution()
            EDITERECORD = True
        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ErrorPoint & " " & ex.Message.ToString())
            chrErrFlg = "Y"
            EDITERECORD = False
        End Try
        Return EDITERECORD
    End Function
#End Region

#Region "cancel Appointment"
    'mayur 20130912
    ''' <summary>
    ''' To cancel Appointment
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="FctCatCode"></param>
    ''' <param name="FctMainCode"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="ApptNo"></param>
    ''' <param name="objclsFCTAPTOT"></param>
    ''' <param name="objclsFCTAPTMAIN"></param>
    ''' <param name="objclsFCTSCH"></param>
    ''' <param name="objclsFCTAPTCNCL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CNCLRECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal ApptNo As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal objclsFCTSCH As clsFCTSCH, ByVal objclsFCTAPTCNCL As clsFCTAPTCNCL) As Boolean Implements iOTScheduling.CNCLRECORD
        CNCLRECORD = False


        Dim ofactory As DBFactory
        Dim inapptno As Integer = 0
        ofactory = New DBFactory
        Try
            inapptno = ApptNo
            Dim dtGetServerDate As Date = New commonFunctions().GetServerDateTime() 'anamika 20161202
            objclsFCTAPTOT.FctCatCode = FctCatCode
            objclsFCTAPTOT.FctMainCode = FctMainCode
            objclsFCTAPTOT.FCTCODE = FCTCODE
            objclsFCTAPTOT.CompanyCode = pcompanycode
            objclsFCTAPTOT.DivisionCode = pdiv
            objclsFCTAPTOT.LocationCode = ploc

            objclsFCTAPTMAIN.FctCatCode = FctCatCode
            objclsFCTAPTMAIN.FctMainCode = FctMainCode
            objclsFCTAPTMAIN.FCTCODE = FCTCODE
            objclsFCTAPTMAIN.CompanyCode = pcompanycode
            objclsFCTAPTMAIN.DivisionCode = pdiv
            objclsFCTAPTMAIN.LocationCode = ploc

            objclsFCTAPTCNCL.FctCatCode = FctCatCode
            objclsFCTAPTCNCL.FctMainCode = FctMainCode
            objclsFCTAPTCNCL.FCTCODE = FCTCODE
            objclsFCTAPTCNCL.CompanyCode = pcompanycode
            objclsFCTAPTCNCL.DivisionCode = pdiv
            objclsFCTAPTCNCL.LocationCode = ploc

            objclsFCTSCH.FctCatCode = FctCatCode
            objclsFCTSCH.FctMainCode = FctMainCode
            objclsFCTSCH.FCTCODE = FCTCODE
            objclsFCTSCH.CompanyCode = pcompanycode
            objclsFCTSCH.DivisionCode = pdiv
            objclsFCTSCH.LocationCode = ploc

            objclsFCTAPTOT.APPTNO = inapptno
            objclsFCTAPTMAIN.APPTNO = inapptno
            objclsFCTSCH.APPTNO = inapptno
            objclsFCTAPTCNCL.APPTNO = inapptno

            Dim pobjclsFCTAPTOT As clsFCTAPTOT
            pobjclsFCTAPTOT = clsFCTAPTOT.GetOTAptDetails(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode, dtGetServerDate, inapptno, 1, 1, "byaptno")

            objclsFCTAPTCNCL.PTNLNGNM = pobjclsFCTAPTOT.PTNLNGNM
            objclsFCTAPTCNCL.APTMDATE = pobjclsFCTAPTOT.APTMDATE
            objclsFCTAPTCNCL.DOCCD = pobjclsFCTAPTOT.DOCCD
            objclsFCTAPTCNCL.ISPATIENT = pobjclsFCTAPTOT.ISPATIENT
            objclsFCTAPTCNCL.IP_OP = pobjclsFCTAPTOT.IPOP
            objclsFCTAPTCNCL.PTNNO = pobjclsFCTAPTOT.PTNNO
            objclsFCTAPTCNCL.APTMTMFROM = pobjclsFCTAPTOT.APTMTMFROM
            objclsFCTAPTCNCL.APTMTMTO = pobjclsFCTAPTOT.APTMTMTO
            objclsFCTAPTCNCL.NOOFSLOTSUSED = pobjclsFCTAPTOT.NOOFSLOTSUSED
            objclsFCTAPTCNCL.DURATION = pobjclsFCTAPTOT.DURATION
            objclsFCTAPTCNCL.ISPERFORMED = pobjclsFCTAPTOT.ISPERFORMED
            objclsFCTAPTCNCL.ISPOSTED = pobjclsFCTAPTOT.ISPOSTED
            objclsFCTAPTCNCL.CRTUSRID = pobjclsFCTAPTOT.CRTUSRID
            objclsFCTAPTCNCL.CRTDTTM = pobjclsFCTAPTOT.CRTDTTM
            ofactory.BeginExecution("Y")





            Dim dbreqSPINSFCTAPTCNCL As DBRequest
            dbreqSPINSFCTAPTCNCL = clsinsertUpdateFCTAPTCNCL.SPINSFCTAPTCNCL(objclsFCTAPTCNCL)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTCNCL)

            Dim dbreqSPINSFCTDEL As DBRequest
            dbreqSPINSFCTDEL = clsInsertUpdateFCTAPTOT.SPDELFCTAPTOT(objclsFCTAPTOT)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTDEL)

            Dim dbreqSPUPDFCTAPTMAIN001 As DBRequest
            dbreqSPUPDFCTAPTMAIN001 = clsInsertUpdateFCTAPTMAIN.SPUPDFCTAPTMAIN001(objclsFCTAPTMAIN)
            '  ofactory.ExecuteNonQuery(dbreqSPUPDFCTAPTMAIN001)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTAPTMAIN001) = 0 Then 'anamika 20140723
                strErrMsg.Add("Record not updated into  FCT_APT_MAIN")
                ofactory.RollBackExecution()
                chrErrFlg = "Y"
                Return False
            End If


            Dim dbreqSPUPDFCTSCH001 As DBRequest
            dbreqSPUPDFCTSCH001 = clsInsertUpdateFCTFCH.SPUPDFCTSCH001(objclsFCTSCH)
            ' ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH001)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH001) = 0 Then 'anamika 20140723
                'strErrMsg.Add("Record not updated into  fct_sch")'do not uncomment this code
                'ofactory.RollBackExecution()
                'chrErrFlg = "Y"
                'Return False
            End If
            CNCLRECORD = True
            ofactory.CommitExecution()

        Catch ex As Exception
            ofactory.RollBackExecution()
        End Try
        Return CNCLRECORD
    End Function

    'mayur 20130912
#End Region

#Region "Shift Record"
    ''' <summary>
    ''' To shift required in request tabl
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="FctCatCode"></param>
    ''' <param name="FctMainCode"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="ApptNo"></param>
    ''' <param name="objclsFCTAPTOT"></param>
    ''' <param name="objclsFCTAPTMAIN"></param>
    ''' <param name="mobjFCTAPTREQ"></param>
    ''' <param name="objclsFCTSCH"></param>
    ''' <param name="objclsFCTAPTCNCL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SHIFTRECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal ApptNo As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal objclsFCTAPTCNCL As clsFCTAPTCNCL, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp)) As Boolean Implements iOTScheduling.SHIFTRECORD


        SHIFTRECORD = False
        Dim ofactory As DBFactory
        ofactory = New DBFactory
        Dim dtGetServerDate As Date = New commonFunctions().GetServerDateTime() 'anamika 20161202
        Try




            objclsFCTAPTOT.FctCatCode = FctCatCode
            objclsFCTAPTOT.FctMainCode = FctMainCode
            objclsFCTAPTOT.FCTCODE = FCTCODE
            objclsFCTAPTOT.CompanyCode = pcompanycode
            objclsFCTAPTOT.DivisionCode = pdiv
            objclsFCTAPTOT.LocationCode = ploc

            objclsFCTAPTMAIN.FctCatCode = FctCatCode
            objclsFCTAPTMAIN.FctMainCode = FctMainCode
            objclsFCTAPTMAIN.FCTCODE = FCTCODE
            objclsFCTAPTMAIN.CompanyCode = pcompanycode
            objclsFCTAPTMAIN.DivisionCode = pdiv
            objclsFCTAPTMAIN.LocationCode = ploc

            objclsFCTAPTCNCL.FctCatCode = FctCatCode
            objclsFCTAPTCNCL.FctMainCode = FctMainCode
            objclsFCTAPTCNCL.FCTCODE = FCTCODE
            objclsFCTAPTCNCL.CompanyCode = pcompanycode
            objclsFCTAPTCNCL.DivisionCode = pdiv
            objclsFCTAPTCNCL.LocationCode = ploc

            objclsFCTSCH.FctCatCode = FctCatCode
            objclsFCTSCH.FctMainCode = FctMainCode
            objclsFCTSCH.FCTCODE = FCTCODE
            objclsFCTSCH.CompanyCode = pcompanycode
            objclsFCTSCH.DivisionCode = pdiv
            objclsFCTSCH.LocationCode = ploc

            mobjFCTAPTREQ.FctCatCode = FctCatCode
            mobjFCTAPTREQ.FctMainCode = FctMainCode
            mobjFCTAPTREQ.FCTCODE = FCTCODE
            mobjFCTAPTREQ.CompanyCode = pcompanycode
            mobjFCTAPTREQ.DivisionCode = pdiv
            mobjFCTAPTREQ.LocationCode = ploc

            objclsFCTAPTOT.APPTNO = ApptNo
            objclsFCTAPTMAIN.APPTNO = ApptNo
            objclsFCTSCH.APPTNO = ApptNo
            objclsFCTAPTCNCL.APPTNO = ApptNo
            mobjFCTAPTREQ.APPTNO = ApptNo

            Dim pobjclsFCTAPTOT As clsFCTAPTOT
            'pobjclsFCTAPTOT = clsFCTAPTOT.GetOTAptDetails(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode, Date.Today, ApptNo, 1, 1, "byaptno")
            pobjclsFCTAPTOT = clsFCTAPTOT.GetOTAptDetails(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode, dtGetServerDate, ApptNo, 1, 1, "byaptno")



            objclsFCTAPTCNCL.PTNLNGNM = pobjclsFCTAPTOT.PTNLNGNM
            objclsFCTAPTCNCL.APTMDATE = pobjclsFCTAPTOT.APTMDATE
            objclsFCTAPTCNCL.DOCCD = pobjclsFCTAPTOT.DOCCD
            objclsFCTAPTCNCL.ISPATIENT = pobjclsFCTAPTOT.ISPATIENT
            objclsFCTAPTCNCL.IP_OP = pobjclsFCTAPTOT.IPOP
            objclsFCTAPTCNCL.PTNNO = pobjclsFCTAPTOT.PTNNO
            objclsFCTAPTCNCL.APTMTMFROM = pobjclsFCTAPTOT.APTMTMFROM
            objclsFCTAPTCNCL.APTMTMTO = pobjclsFCTAPTOT.APTMTMTO
            objclsFCTAPTCNCL.NOOFSLOTSUSED = pobjclsFCTAPTOT.NOOFSLOTSUSED
            objclsFCTAPTCNCL.DURATION = pobjclsFCTAPTOT.DURATION
            objclsFCTAPTCNCL.ISPERFORMED = pobjclsFCTAPTOT.ISPERFORMED
            objclsFCTAPTCNCL.ISPOSTED = pobjclsFCTAPTOT.ISPOSTED
            objclsFCTAPTCNCL.CRTUSRID = pobjclsFCTAPTOT.CRTUSRID
            objclsFCTAPTCNCL.CRTDTTM = pobjclsFCTAPTOT.CRTDTTM


            ofactory.BeginExecution("Y")

            Dim dbreqSPINSFCTAPTCNCL As DBRequest
            dbreqSPINSFCTAPTCNCL = clsinsertUpdateFCTAPTCNCL.SPINSFCTAPTCNCL(objclsFCTAPTCNCL)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTCNCL)




            mobjFCTAPTREQ.DOCCD = pobjclsFCTAPTOT.DOCCD
            mobjFCTAPTREQ.ISPATIENT = pobjclsFCTAPTOT.ISPATIENT
            mobjFCTAPTREQ.IP_OP = pobjclsFCTAPTOT.IPOP
            mobjFCTAPTREQ.PTNNO = pobjclsFCTAPTOT.PTNNO
            mobjFCTAPTREQ.PTNLNGNM = pobjclsFCTAPTOT.PTNLNGNM
            mobjFCTAPTREQ.APTMTMFROM = pobjclsFCTAPTOT.APTMTMFROM
            mobjFCTAPTREQ.APTMTMTO = pobjclsFCTAPTOT.APTMTMTO




            Dim dbreqSPINSFCTAPTREQUEST As DBRequest
            dbreqSPINSFCTAPTREQUEST = clsinsertUpdateFCTAPTREQ.SPINSFCTAPTREQUEST(mobjFCTAPTREQ)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTREQUEST)
            'request




            Dim dbreqSPINSFCTDEL As DBRequest
            dbreqSPINSFCTDEL = clsInsertUpdateFCTAPTOT.SPDELFCTAPTOT(objclsFCTAPTOT)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTDEL)




            Dim dbreqSPUPDFCTAPTMAIN001 As DBRequest
            dbreqSPUPDFCTAPTMAIN001 = clsInsertUpdateFCTAPTMAIN.SPUPDFCTAPTMAIN001(objclsFCTAPTMAIN)
            ' ofactory.ExecuteNonQuery(dbreqSPUPDFCTAPTMAIN001)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTAPTMAIN001) = 0 Then 'anamika 20140723
                strErrMsg.Add("Record not updated into  FCT_APT_MAIN")
                ofactory.RollBackExecution()
                chrErrFlg = "Y"
                Return False
            End If




            Dim dbreqSPUPDFCTSCH001 As DBRequest
            dbreqSPUPDFCTSCH001 = clsInsertUpdateFCTFCH.SPUPDFCTSCH001(objclsFCTSCH)
            ' ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH001)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH001) = 0 Then 'anamika 20140723
                'strErrMsg.Add("Record not updated into fct_sch ")'do not uncomment this code
                'ofactory.RollBackExecution()
                'chrErrFlg = "Y"
                'Return False
            End If



            'SAVE OT SERVICES RECORDS : 'RasikV 20170123
            If (arrObjOtSrvLst IsNot Nothing) Then
                If arrObjOtSrvLst.Count > 0 Then
                    Dim iApptNo As Integer = ApptNo
                    Dim dbrequest As DBRequest = clsInsertUpdateFctAptOtSrv.SpDelFctAptOtSrv(pcompanycode, pdiv, ploc, iApptNo, FctCatCode, FctMainCode, FCTCODE)
                    ofactory.ExecuteNonQuery(dbrequest)
                    For iSrv As Integer = 0 To arrObjOtSrvLst.Count - 1
                        arrObjOtSrvLst(iSrv).ApptNo = iApptNo
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtSrv.SpInsUpdFctAptOtSrv(pcompanycode, pdiv, ploc, arrObjOtSrvLst(iSrv))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            strErrMsg.Add("Record not Inserted into Fct_Apt_Ot_Srv.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iSrv
                End If
            End If

            'SAVE OT DOCTORS RECORDS : 'RasikV 20170123
            If (arrObjOtDocLst IsNot Nothing) Then
                If arrObjOtDocLst.Count > 0 Then
                    Dim iApptNo As Integer = ApptNo
                    Dim DocCd As Integer = arrObjOtDocLst(0).DocCd
                    Dim dbrequest As DBRequest = clsInsertUpdateFctAptOtDoc.SpDelFctAptOtDoc(pcompanycode, pdiv, ploc, iApptNo, DocCd)
                    ofactory.ExecuteNonQuery(dbrequest)
                    For iDoc As Integer = 0 To arrObjOtDocLst.Count - 1
                        arrObjOtDocLst(iDoc).ApptNo = iApptNo
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtDoc.SpInsUpdFctAptOtDoc(pcompanycode, pdiv, ploc, arrObjOtDocLst(iDoc))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            strErrMsg.Add("Record not Inserted into FCT_APT_OT_DOC.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iDoc
                End If
            End If

            'SAVE OT EMPLOYEE/NURSE RECORDS : 'RasikV 20170123
            If (arrObjOtEmpLst IsNot Nothing) Then
                If arrObjOtEmpLst.Count > 0 Then
                    Dim iApptNo As Integer = ApptNo
                    Dim iIpNo As Long = arrObjOtEmpLst(0).IpNo
                    Dim PtnNo As Long = arrObjOtEmpLst(0).PtnNo
                    Dim dbrequest As DBRequest = clsInsertUpdateFctAptOtEmp.SpDelFctAptOtEmp(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, iApptNo, PtnNo, iIpNo)
                    ofactory.ExecuteNonQuery(dbrequest)
                    For iEmp As Integer = 0 To arrObjOtEmpLst.Count - 1
                        arrObjOtEmpLst(iEmp).ApptNo = iApptNo
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtEmp.SpInsFctAptOtEmp(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, arrObjOtEmpLst(iEmp))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            strErrMsg.Add("Record not Inserted into FCT_APT_OT_EMP.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iEmp
                End If
            End If

            ofactory.CommitExecution()

            SHIFTRECORD = True
        Catch ex As Exception
            SHIFTRECORD = False 'anamika 20140723
            strErrMsg.Add(ex.Message)  'anamika 20140723
            ofactory.RollBackExecution()
        End Try
        Return SHIFTRECORD
    End Function
#End Region

#Region " Shifting record directly"
    ''' <summary>
    ''' For Shifting record directly
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="FctCatCode"></param>
    ''' <param name="FctMainCode"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="OldFCTCODE"></param>
    ''' <param name="FctDay"></param>
    ''' <param name="SCHDAT"></param>
    ''' <param name="lvReqno"></param>
    ''' <param name="oldApptNo"></param>
    ''' <param name="IPNO"></param>
    ''' <param name="objclsFCTAPTOT"></param>
    ''' <param name="objclsFCTAPTMAIN"></param>
    ''' <param name="mobjFCTAPTREQ"></param>
    ''' <param name="objclsFCTSCH"></param>
    ''' <param name="objclsFCTAPTCNCL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SHIFTNOW(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal OldFCTCODE As Integer, ByVal FctDay As Integer, ByVal SCHDAT As Date, ByVal lvReqno As Integer, ByVal oldApptNo As Integer, ByVal IPNO As Long, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal objclsFCTAPTCNCL As clsFCTAPTCNCL, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp)) As String Implements iOTScheduling.SHIFTNOW

        SHIFTNOW = False

        Dim ofactory As DBFactory
        ofactory = New DBFactory
        Dim ds As New DataSet
        Dim inapptno As Integer
        Dim obj As New clsInsertUpdateSrNo
        Dim arrdbobjFCT_SCH As New List(Of DBRequest) 'anamika 20161202
        Dim arrdbmobjFCTAPTREQ As New List(Of DBRequest) 'anamika 20161202
        Try

            objclsFCTAPTOT.FctCatCode = FctCatCode
            objclsFCTAPTOT.FctMainCode = FctMainCode
            objclsFCTAPTOT.FCTCODE = FCTCODE
            objclsFCTAPTOT.CompanyCode = pcompanycode
            objclsFCTAPTOT.DivisionCode = pdiv
            objclsFCTAPTOT.LocationCode = ploc

            objclsFCTAPTMAIN.FctCatCode = FctCatCode
            objclsFCTAPTMAIN.FctMainCode = FctMainCode
            objclsFCTAPTMAIN.FCTCODE = FCTCODE
            objclsFCTAPTMAIN.CompanyCode = pcompanycode
            objclsFCTAPTMAIN.DivisionCode = pdiv
            objclsFCTAPTMAIN.LocationCode = ploc

            mobjFCTAPTREQ.FctCatCode = FctCatCode
            mobjFCTAPTREQ.FctMainCode = FctMainCode
            mobjFCTAPTREQ.FCTCODE = FCTCODE
            mobjFCTAPTREQ.CompanyCode = pcompanycode
            mobjFCTAPTREQ.DivisionCode = pdiv
            mobjFCTAPTREQ.LocationCode = ploc

            objclsFCTSCH.FctCatCode = FctCatCode
            objclsFCTSCH.FctMainCode = FctMainCode
            objclsFCTSCH.FCTCODE = FCTCODE
            objclsFCTSCH.CompanyCode = pcompanycode
            objclsFCTSCH.DivisionCode = pdiv
            objclsFCTSCH.LocationCode = ploc


            objclsFCTAPTCNCL.FctCatCode = FctCatCode
            objclsFCTAPTCNCL.FctMainCode = FctMainCode
            objclsFCTAPTCNCL.FCTCODE = FCTCODE
            objclsFCTAPTCNCL.CompanyCode = pcompanycode
            objclsFCTAPTCNCL.DivisionCode = pdiv
            objclsFCTAPTCNCL.LocationCode = ploc

            SCHDAT = SCHDAT.AddDays(1)

            ds = clsFCTPREREQMST.GetFCTAPTREQMST001(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FctCatCode, FctMainCode, FCTCODE, FctDay, SCHDAT)


            If (ds IsNot Nothing) Then
                Dim lvSlotNo As Integer
                Dim lvSessSt As Date
                Dim lvSessEn As Date
                Dim lvSessDur As Long
                Dim lvSlotDur As Long
                Dim lvNoSlot As Long
                Dim lv2 As Date
                Dim lv3 As Date
                Dim lv_fct_slot_prd_hrs As Integer
                Dim lv_fct_slot_prd_mins As Integer

                If (ds.Tables(0).Rows.Count > 0) Then
                    For intI As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        lvSlotNo = 1

                        Dim clsmstr As List(Of clsMaster)
                        clsmstr = GetFctMstDtlList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, 1, 1)
                        lv_fct_slot_prd_hrs = clsmstr(0).data2
                        lv_fct_slot_prd_mins = clsmstr(0).data3

                        Dim fromhrs As String = ds.Tables(0).Rows(intI).Item("fctc_time_from_hrs").ToString()
                        Dim frommins As String = ds.Tables(0).Rows(intI).Item("fctc_time_from_mins").ToString()
                        Dim tohrs As String = ds.Tables(0).Rows(intI).Item("fctc_time_to_hrs").ToString()
                        Dim tomins As String = ds.Tables(0).Rows(intI).Item("fctc_time_to_mins").ToString()

                        If (fromhrs.Length = 3) Then
                            fromhrs = "0" & fromhrs
                        End If
                        If (frommins.Length = 3) Then
                            frommins = "0" & frommins
                        End If
                        If (tohrs.Length = 3) Then
                            tohrs = "0" & tohrs
                        End If
                        If (tomins.Length = 3) Then
                            tomins = "0" & tomins
                        End If

                        lvSessSt = CDate(fromhrs & ":" & frommins)
                        lvSessEn = CDate(tohrs & ":" & tomins)

                        lvSessDur = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, lvSessSt, lvSessEn)
                        If ds.Tables(0).Rows(intI).Item("fct_slot_prd_hrs") <> 0 Then
                            lvSlotDur = (lv_fct_slot_prd_hrs * 60) + lv_fct_slot_prd_mins
                        Else
                            lvSlotDur = lv_fct_slot_prd_mins
                        End If

                        lvNoSlot = System.Math.Abs(lvSessDur / lvSlotDur)
                        lv2 = lvSessSt
                        For i = 1 To lvNoSlot
                            Dim objFCT_SCH As New clsFCTSCH
                            objFCT_SCH.CompanyCode = pcompanycode
                            objFCT_SCH.DivisionCode = pdiv
                            objFCT_SCH.LocationCode = ploc
                            objFCT_SCH.FctCatCode = FctCatCode
                            objFCT_SCH.FCTCODE = ds.Tables(0).Rows(intI).Item("fct_code").ToString
                            objFCT_SCH.FctMainCode = FctMainCode
                            objFCT_SCH.SCHDATE = SCHDAT
                            objFCT_SCH.SESSIONCODE = (ds.Tables(0).Rows(intI).Item("fctc_session_code"))
                            objFCT_SCH.SLOTNO = lvNoSlot
                            objFCT_SCH.SCHTIMEFROMHRS = ds.Tables(0).Rows(intI).Item("fctc_time_from_hrs")
                            objFCT_SCH.SCHTIMETOHRS = ds.Tables(0).Rows(intI).Item("fctc_time_to_hrs")
                            objFCT_SCH.SCHTIMETOMINS = ds.Tables(0).Rows(intI).Item("fctc_time_to_mins")
                            objFCT_SCH.SCHTIMETOHRS = (ds.Tables(0).Rows(intI).Item("fctc_time_to_hrs"))
                            objFCT_SCH.APPTNO = 0
                            objFCT_SCH.APTMSTS = 0
                            objFCT_SCH.IPOPFLG = " "
                            objFCT_SCH.IPOPNO = 0
                            objFCT_SCH.CHRGCD = 0
                            objFCT_SCH.TESTCD = 0
                            objFCT_SCH.APTMREFBY = " "
                            objFCT_SCH.ICDGRPCD = " "
                            objFCT_SCH.ICDCODE = " "

                            Dim oRequest As DBRequest
                            oRequest = clsInsertUpdateFCTFCH.SPINSFCTSCH(objFCT_SCH)
                            arrdbobjFCT_SCH.Add(oRequest) 'anamika 20161202
                            ' ofactory.ExecuteNonQuery(oRequest) 'anamika 20161202
                            lv2 = lv3
                            lvSlotNo = lvSlotNo + 1
                        Next i
                    Next
                End If
            End If


            inapptno = obj.GetUpdateFCTDOCUNO(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc)


            Dim pobjclsFCTMST As List(Of clsFCTMST)
            pobjclsFCTMST = clsFCTMST.GetFCTMST(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode)
            objclsFCTSCH.CHRGCD = pobjclsFCTMST(0).FCTRCHRGCD
            objclsFCTSCH.TESTCD = pobjclsFCTMST(0).FCTRTSTCD


            objclsFCTAPTOT.APPTNO = inapptno
            objclsFCTAPTMAIN.APPTNO = inapptno
            objclsFCTSCH.APPTNO = inapptno



            Dim pobjclsFCTAPTOT As clsFCTAPTOT
            pobjclsFCTAPTOT = clsFCTAPTOT.GetOTAptDetails(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, OldFCTCODE, FctCatCode, FctMainCode, Date.Today, oldApptNo, 1, 1, "byaptno")

            Dim pobjFCTAPTREQMST = clsFCTPREREQMST.GetFCTAPTREQMST(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, pobjclsFCTMST(0).FCTRCHRGCD, pobjclsFCTMST(0).FCTRTSTCD)
            If (pobjFCTAPTREQMST IsNot Nothing) Then
                For intI As Integer = 0 To pobjFCTAPTREQMST.Count - 1
                    Dim pobclsFCTPREREQ As clsFCTPREREQ
                    pobclsFCTPREREQ = clsFCTPREREQ.GetFCTAPTREQ(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode, pobjFCTAPTREQMST(intI).PREREQCD, inapptno, IPNO)
                    mobjFCTAPTREQ.PRMREQCODE = pobjFCTAPTREQMST(intI).PREREQCD
                    Dim dbreqSPINSFCTAPTREQUEST As DBRequest
                    dbreqSPINSFCTAPTREQUEST = clsinsertUpdateFCTAPTREQ.SPINSFCTAPTREQUEST(mobjFCTAPTREQ)
                    ' ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTREQUEST) 'anamika 20161202
                    arrdbmobjFCTAPTREQ.Add(dbreqSPINSFCTAPTREQUEST) 'anamika 20161202
                Next intI
            End If



            ofactory.BeginExecution("Y")

            If arrdbobjFCT_SCH IsNot Nothing Then 'anamika 20161202
                For i As Integer = 0 To arrdbobjFCT_SCH.Count - 1
                    ofactory.ExecuteNonQuery(arrdbobjFCT_SCH(i))
                Next
            End If
            Dim dbreqSPINSFCTAPTOT As DBRequest
            dbreqSPINSFCTAPTOT = clsInsertUpdateFCTAPTOT.SPINSFCTAPTOT(objclsFCTAPTOT)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTOT)

            Dim dbreqSPINSFCTAPTMAIN As DBRequest
            dbreqSPINSFCTAPTMAIN = clsInsertUpdateFCTAPTMAIN.SPINSFCTAPTMAIN(objclsFCTAPTMAIN)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTMAIN)



            Dim dbreqSPUPDFCTSCH002 As DBRequest
            dbreqSPUPDFCTSCH002 = clsInsertUpdateFCTFCH.SPUPDFCTSCH002(objclsFCTSCH)
            '   ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH002)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH002) = 0 Then 'anamika 20140723
                'strErrMsg.Add("Record not updated into FCT_SCH ")
                'ofactory.RollBackExecution()
                'chrErrFlg = "Y"
                'Return False
            End If



            'If (pobjFCTAPTREQMST IsNot Nothing) Then
            '    For intI As Integer = 0 To pobjFCTAPTREQMST.Count - 1
            '        Dim pobclsFCTPREREQ As clsFCTPREREQ
            '        pobclsFCTPREREQ = clsFCTPREREQ.GetFCTAPTREQ(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FctCatCode, FctMainCode, pobjFCTAPTREQMST(intI).PREREQCD, inapptno, IPNO)
            '        mobjFCTAPTREQ.PRMREQCODE = pobjFCTAPTREQMST(intI).PREREQCD
            '        Dim dbreqSPINSFCTAPTREQUEST As DBRequest
            '        dbreqSPINSFCTAPTREQUEST = clsinsertUpdateFCTAPTREQ.SPINSFCTAPTREQUEST(mobjFCTAPTREQ)
            '        ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTREQUEST)
            '    Next intI
            'End If
            If arrdbmobjFCTAPTREQ IsNot Nothing Then 'anamika 20161202
                For i As Integer = 0 To arrdbmobjFCTAPTREQ.Count - 1
                    ofactory.ExecuteNonQuery(arrdbmobjFCTAPTREQ(i))
                Next
            End If

            ''''''OldRecords




            objclsFCTAPTCNCL.PTNLNGNM = pobjclsFCTAPTOT.PTNLNGNM
            objclsFCTAPTCNCL.APTMDATE = pobjclsFCTAPTOT.APTMDATE
            objclsFCTAPTCNCL.DOCCD = pobjclsFCTAPTOT.DOCCD
            objclsFCTAPTCNCL.ISPATIENT = pobjclsFCTAPTOT.ISPATIENT
            objclsFCTAPTCNCL.IP_OP = pobjclsFCTAPTOT.IPOP
            objclsFCTAPTCNCL.PTNNO = pobjclsFCTAPTOT.PTNNO
            objclsFCTAPTCNCL.APTMTMFROM = pobjclsFCTAPTOT.APTMTMFROM
            objclsFCTAPTCNCL.APTMTMTO = pobjclsFCTAPTOT.APTMTMTO
            objclsFCTAPTCNCL.NOOFSLOTSUSED = pobjclsFCTAPTOT.NOOFSLOTSUSED
            objclsFCTAPTCNCL.DURATION = pobjclsFCTAPTOT.DURATION
            objclsFCTAPTCNCL.ISPERFORMED = pobjclsFCTAPTOT.ISPERFORMED
            objclsFCTAPTCNCL.ISPOSTED = pobjclsFCTAPTOT.ISPOSTED
            objclsFCTAPTCNCL.CRTUSRID = pobjclsFCTAPTOT.CRTUSRID
            objclsFCTAPTCNCL.CRTDTTM = pobjclsFCTAPTOT.CRTDTTM

            objclsFCTAPTCNCL.APPTNO = oldApptNo
            objclsFCTAPTMAIN.APPTNO = oldApptNo
            objclsFCTSCH.APPTNO = oldApptNo
            objclsFCTAPTOT.APPTNO = oldApptNo

            objclsFCTAPTCNCL.FCTCODE = OldFCTCODE
            objclsFCTAPTMAIN.FCTCODE = OldFCTCODE
            objclsFCTSCH.FCTCODE = OldFCTCODE
            objclsFCTAPTOT.FCTCODE = OldFCTCODE

            Dim dbreqSPINSFCTAPTCNCL As DBRequest
            dbreqSPINSFCTAPTCNCL = clsinsertUpdateFCTAPTCNCL.SPINSFCTAPTCNCL(objclsFCTAPTCNCL)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTAPTCNCL)

            Dim dbreqSPINSFCTDEL As DBRequest
            dbreqSPINSFCTDEL = clsInsertUpdateFCTAPTOT.SPDELFCTAPTOT(objclsFCTAPTOT)
            ofactory.ExecuteNonQuery(dbreqSPINSFCTDEL)

            Dim dbreqSPUPDFCTAPTMAIN001 As DBRequest
            dbreqSPUPDFCTAPTMAIN001 = clsInsertUpdateFCTAPTMAIN.SPUPDFCTAPTMAIN001(objclsFCTAPTMAIN)
            'ofactory.ExecuteNonQuery(dbreqSPUPDFCTAPTMAIN001)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTAPTMAIN001) = 0 Then 'anamika 20140723
                strErrMsg.Add("Record not updated into FCT_APT_MAIN ")
                ofactory.RollBackExecution()
                chrErrFlg = "Y"
                Return False
            End If

            Dim dbreqSPUPDFCTSCH001 As DBRequest
            dbreqSPUPDFCTSCH001 = clsInsertUpdateFCTFCH.SPUPDFCTSCH001(objclsFCTSCH)
            '    ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH001)
            If ofactory.ExecuteNonQuery(dbreqSPUPDFCTSCH001) = 0 Then 'anamika 20140723
                'strErrMsg.Add("Record not updated into  fct_sch") 'do not uncomment this code
                'ofactory.RollBackExecution()
                'chrErrFlg = "Y"
                'Return False
            End If


            'SAVE OT SERVICES RECORDS : 'RasikV 20170123
            If (arrObjOtSrvLst IsNot Nothing) Then
                If arrObjOtSrvLst.Count > 0 Then
                    Dim ApptNo As Integer = oldApptNo
                    Dim dbrequest As DBRequest = clsInsertUpdateFctAptOtSrv.SpDelFctAptOtSrv(pcompanycode, pdiv, ploc, ApptNo, FctCatCode, FctMainCode, FCTCODE)
                    ofactory.ExecuteNonQuery(dbrequest)
                    For iSrv As Integer = 0 To arrObjOtSrvLst.Count - 1
                        arrObjOtSrvLst(iSrv).ApptNo = inapptno
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtSrv.SpInsUpdFctAptOtSrv(pcompanycode, pdiv, ploc, arrObjOtSrvLst(iSrv))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            strErrMsg.Add("Record not Inserted into Fct_Apt_Ot_Srv.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iSrv
                End If
            End If

            'SAVE OT DOCTORS RECORDS : 'RasikV 20170123
            If (arrObjOtDocLst IsNot Nothing) Then
                If arrObjOtDocLst.Count > 0 Then
                    Dim ApptNo As Integer = oldApptNo
                    Dim DocCd As Integer = arrObjOtDocLst(0).DocCd
                    Dim dbrequest As DBRequest = clsInsertUpdateFctAptOtDoc.SpDelFctAptOtDoc(pcompanycode, pdiv, ploc, ApptNo, DocCd)
                    ofactory.ExecuteNonQuery(dbrequest)
                    For iDoc As Integer = 0 To arrObjOtDocLst.Count - 1
                        arrObjOtDocLst(iDoc).ApptNo = inapptno
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtDoc.SpInsUpdFctAptOtDoc(pcompanycode, pdiv, ploc, arrObjOtDocLst(iDoc))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            strErrMsg.Add("Record not Inserted into FCT_APT_OT_DOC.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iDoc
                End If
            End If

            'SAVE OT EMPLOYEE/NURSE RECORDS : 'RasikV 20170123
            If (arrObjOtEmpLst IsNot Nothing) Then
                If arrObjOtEmpLst.Count > 0 Then
                    Dim ApptNo As Integer = oldApptNo
                    Dim iIpNo As Long = arrObjOtEmpLst(0).IpNo
                    Dim PtnNo As Long = arrObjOtEmpLst(0).PtnNo
                    Dim dbrequest As DBRequest = clsInsertUpdateFctAptOtEmp.SpDelFctAptOtEmp(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, ApptNo, PtnNo, iIpNo)
                    ofactory.ExecuteNonQuery(dbrequest)
                    For iEmp As Integer = 0 To arrObjOtEmpLst.Count - 1
                        arrObjOtEmpLst(iEmp).ApptNo = inapptno
                        Dim dbrequestIns As DBRequest = clsInsertUpdateFctAptOtEmp.SpInsFctAptOtEmp(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, arrObjOtEmpLst(iEmp))
                        If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                            strErrMsg.Add("Record not Inserted into FCT_APT_OT_EMP.")
                            ofactory.RollBackExecution()
                            chrErrFlg = "Y"
                            Return False
                        End If
                    Next iEmp
                End If
            End If
            ofactory.CommitExecution()

        Catch ex As Exception
            inapptno = 0
            ofactory.RollBackExecution()
        End Try

        Return inapptno.ToString() + "~" + oldApptNo.ToString()

    End Function

#End Region

#Region "Get Holiday details of OT"
    'mayur 20132013
    ''' <summary>
    ''' Get Holiday details of OT  
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTDAY"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFCTHoliDayDay(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTDAY As Date) As List(Of clsFCTMST) Implements iOTScheduling.GetFCTHoliDayDay
        GetFCTHoliDayDay = Nothing
        Try
            GetFCTHoliDayDay = clsFCTMST.GetHolidayDay(strErrMsg, chrErrFlg, companycode, companycode, loc, FCTCODE, FCTDAY)
        Catch ex As Exception
            GetFCTHoliDayDay = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetFCTHoliDayDay
    End Function

    'mayur 20130913
#End Region

    Public Function GetFCTCAL(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal FCTDAY As Integer) As List(Of clsFCTCAL) Implements iOTScheduling.GetFCTCAL
        GetFCTCAL = Nothing
        Try
            GetFCTCAL = clsFCTCAL.GetFCTCAL(strErrMsg, chrErrFlg, companycode, companycode, loc, FCTCODE, FCTCATCD, FCTMAINCD, FCTDAY)
        Catch ex As Exception
            GetFCTCAL = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetFCTCAL
    End Function
#Region "GetOTAptDetails saperately"
    ''' <summary>
    ''' GetOTAptDetails saperately
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTCATCD"></param>
    ''' <param name="FCTMAINCD"></param>
    ''' <param name="APTMDATE"></param>
    ''' <param name="APTNO"></param>
    ''' <param name="APTMTMFRM"></param>
    ''' <param name="APTMTMTO"></param>
    ''' <param name="FLG"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOTAptDetails1(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                       ByVal companycode As String,
                                                       ByVal div As Integer,
                                                       ByVal loc As Integer,
                                                       ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal APTMDATE As Date, ByVal APTNO As Integer, ByVal APTMTMFRM As Integer, ByVal APTMTMTO As Integer, ByVal FLG As String) As List(Of clsFCTAPTOT) Implements iOTScheduling.GetOTAptDetails1
        GetOTAptDetails1 = Nothing
        Try
            GetOTAptDetails1 = clsFCTAPTOT.GetOTAptDetails1(strErrMsg, chrErrFlg, companycode, companycode, loc, FCTCODE, FCTCATCD, FCTMAINCD, APTMDATE, APTNO, APTMTMFRM, APTMTMTO, FLG)
        Catch ex As Exception
            GetOTAptDetails1 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetOTAptDetails1
    End Function
#End Region


#Region " Get Patient full name"
    ''' <summary>
    ''' Get Patient full name
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="patientno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPatientFullName(ByRef strErrMsg As List(Of String),
                               ByRef chrErrFlg As Char,
                               ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                               ByVal patientno As Long) As String Implements iOTScheduling.GetPatientFullName
        GetPatientFullName = Nothing
        Try
            GetPatientFullName = clsPatient.GetPatientFullName(strErrMsg, chrErrFlg, companycode, div, loc, patientno)
        Catch ex As Exception
            GetPatientFullName = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetPatientFullName
    End Function

#End Region
#Region "Get Doctor Name"
    ''' <summary>
    ''' Get Doctor Name
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="doctorcode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDoctor(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                     ByVal doctorcode As Integer) As String Implements iOTScheduling.GetDoctor

        GetDoctor = Nothing
        Try
            Dim dct As New clsDoctor
            dct = clsDoctor.GetDoctor(strErrMsg, chrErrFlg, companycode, div, loc, doctorcode)
            'Return dct.DoctorFirstName + "" + dct.DoctorMiddleName + "" + dct.DoctorLastName

            Return dct.DoctorTitleCodeDesc + " " + dct.DoctorLastName + " " + dct.DoctorFirstName + " " + dct.DoctorMiddleName

        Catch ex As Exception
            GetDoctor = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
#End Region


#Region "OtIndirectBooking" 'RasikV 20160922

#Region "SaveRecord"

    Public Function SaveIndirectBooking(ByRef StrErrMsg As List(Of String), ByRef ChrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal obj As ClsOtIndirectBooking) As Boolean Implements iOTScheduling.SaveIndirectBooking

        Dim ofactory As New DBFactory
        Dim oRequest As New DBRequest
        Dim TrnNo As Integer
        Dim PtnNo As Integer
        Dim IsRecordExist As Boolean = False

        Try

            If obj.TrnNo = 0 Then
                IsRecordExist = False
                TrnNo = clsInsertUpdateSrNo.SpSelUpdAdtDcNos(StrErrMsg, ChrErrFlg, pcompanycode, pdiv, ploc, 2, obj.UserDtTm, obj.UserId)
            Else
                IsRecordExist = True
            End If
            ofactory.BeginExecution("Y")
            If (obj IsNot Nothing) Then

                If (IsRecordExist = False) Then
                    obj.TrnNo = TrnNo
                    obj.Status = 1
                    oRequest = clsInsertUpdateOtIndirectBooking.SpInsOtIndirctBookng(StrErrMsg, ChrErrFlg, pcompanycode, pdiv, ploc, obj)
                Else
                    obj.Status = 1
                    oRequest = clsInsertUpdateOtIndirectBooking.SpUpOtIndirctBookng(StrErrMsg, ChrErrFlg, pcompanycode, pdiv, ploc, obj)
                End If

                ofactory.ExecuteNonQuery(oRequest)
            End If

            ofactory.CommitExecution()
            SaveIndirectBooking = True

        Catch ex As Exception
            ofactory.RollBackExecution()
            StrErrMsg.Add(ex.Message)
            ChrErrFlg = "Y"
            SaveIndirectBooking = False
        End Try

        Return SaveIndirectBooking

    End Function

#End Region

#Region "CancelRecord"

    Public Function CancelOtIndirectBooking(ByRef StrErrMsg As List(Of String), ByRef ChrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal TrnNo As Integer, ByVal PtnNo As Long, ByVal UsrId As String, ByVal UsrDtTm As Date) As Boolean Implements iOTScheduling.CancelOtIndirectBooking

        Dim ofactory As New DBFactory
        Dim oRequest As New DBRequest

        Try
            ofactory.BeginExecution("Y")
            oRequest = clsInsertUpdateOtIndirectBooking.SpUpOtIndirctBookng001(StrErrMsg, ChrErrFlg, pcompanycode, pdiv, ploc, TrnNo, PtnNo, 3, UsrId, UsrDtTm)

            If ofactory.ExecuteNonQuery(oRequest) = 0 Then
                StrErrMsg.Add("Status for cancelling the Ot Indirect Booking Request is not updated into OtIndirectBooking.")
                ofactory.RollBackExecution()
                ChrErrFlg = "Y"
                Return False
            End If

            ofactory.CommitExecution()
            CancelOtIndirectBooking = True

        Catch ex As Exception
            ofactory.RollBackExecution()
            StrErrMsg.Add(ex.Message)
            ChrErrFlg = "Y"
            CancelOtIndirectBooking = False
        End Try

        Return CancelOtIndirectBooking

    End Function
#End Region

#Region "GetOtIndirectBookingLst"

    Public Function GetOtIndirectBookingLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String,
                                            ByVal div As Integer, ByVal loc As Integer, ByVal ExpDate As Date, ByVal ToDate As Date) As List(Of ClsOtIndirectBookingLst) Implements iOTScheduling.GetOtIndirectBookingLst
        Try

            GetOtIndirectBookingLst = ClsOtIndirectBooking.GetOtIndirectBookingLst(strErrMsg, chrErrFlg, companycode, div, loc, ExpDate, ToDate)

        Catch ex As Exception
            GetOtIndirectBookingLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetOtIndirectBookingLst
    End Function

#End Region

#End Region


#Region "Common Master" 'RasikV 20160922

    Public Function WardDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer) As List(Of clsCodeDecode) Implements iOTScheduling.WardDetails

        Try
            WardDetails = Nothing
            Dim objarrCodeDecode As List(Of clsCodeDecode)
            Dim obj As New clsCodeDecode
            objarrCodeDecode = obj.WardDetails(strErrMsg, chrErrFlg, cocd, div, loc)
            WardDetails = objarrCodeDecode
        Catch ex As Exception
            WardDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

        Return WardDetails

    End Function

    Public Function GetInPtnListByNameDocWard(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal Cocd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FrstNm As String, ByVal MidNm As String, ByVal LstNm As String, ByVal DocCd As Integer, ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As List(Of clsInPatientHelp) Implements iOTScheduling.GetInPtnListByNameDocWard

        Try
            GetInPtnListByNameDocWard = Nothing
            Dim objarr As List(Of clsInPatientHelp)
            'objarr = clsInPatient.GetInPtnListByNameDocWard001(strErrMsg, chrErrFlg, Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts)
            '  objarr = clsInPatient.GetPatientHelpWithOpenFolio(strErrMsg, chrErrFlg, Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts) 'RasikV 20170206

            objarr = clsInPatient.GetIpPatientHelpMstNoFolio(strErrMsg, chrErrFlg, Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts, Pageindex, PageSize) 'Pushpa 20180508


            GetInPtnListByNameDocWard = objarr
        Catch ex As Exception
            GetInPtnListByNameDocWard = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

        Return GetInPtnListByNameDocWard

    End Function

    Public Function GetInpatientDetails(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, Optional ByVal IPNumber As Long = 0) As clsIpPatientVisit Implements iOTScheduling.GetInpatientDetails
        Try
            GetInpatientDetails = Nothing
            Dim objarr As clsIpPatientVisit
            objarr = PatientVisitAndBilInsTrn.clsIpPatientVisit.GetInPatient(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, IPNumber)

            If (objarr IsNot Nothing) Then
                If objarr.IsPtnBlackListed = False Then
                    GetInpatientDetails = objarr
                Else
                    GetInpatientDetails = Nothing
                    strErrMsg.Add("Patient is blacklisted... Cannot post Transactions")
                    chrErrFlg = "Y"
                    Exit Function
                End If
            End If

            GetInpatientDetails = objarr

        Catch ex As Exception
            GetInpatientDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

        Return GetInpatientDetails

    End Function

    Public Function GetOtName(ByRef strErrMsg As List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                      ByVal OtNo As Integer) As String Implements iOTScheduling.GetOtName

        Try
            GetOtName = Nothing

            GetOtName = clsFCTMST.GetOtName(strErrMsg, chrErrFlg, companycode, div, loc, OtNo)

        Catch ex As Exception
            GetOtName = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetOtName
    End Function
#End Region

#Region "Direct / Indirect Booking for OT-DOCTORS / OT-SERVICES / OT-EMPLOYESS"
    'pragya : 11-oct-2016

#Region "GetOtEmpIdLst : Get the Ot Employee List"
    'pragya : 01-dec-2016 
    Public Function GetOtEmpIdLst(ByRef strErrMsg As List(Of String),
                                   ByRef chrErrFlg As Char,
                                   ByVal cocd As String,
                                   ByVal div As Integer,
                                   ByVal loc As Integer) As List(Of clsAttPayDbEmpId) Implements iOTScheduling.GetOtEmpIdLst

        Try
            GetOtEmpIdLst = Nothing
            GetOtEmpIdLst = clsAttPayDbEmpId.GetEmpIDList(strErrMsg, chrErrFlg, cocd, div, loc)
        Catch ex As Exception
            GetOtEmpIdLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetOtEmpIdLst

    End Function
#End Region

#Region "GetLstOtEmpDtlsByApptNoIpNo"
    'pragya : 01-dec-2016
    Public Function GetLstOtEmpDtlsByApptNoIpNo(ByRef strErrMsg As List(Of String),
                                            ByRef chrErrFlg As Char,
                                            ByVal COCd As String,
                                            ByVal Div As Integer,
                                            ByVal Loc As Integer,
                                            ByVal FctCd As Integer,
                                            ByVal FctCatCd As Integer,
                                            ByVal FctMainCd As Integer,
                                            ByVal ApptNo As Integer,
                                            ByVal PtnNo As Long,
                                            ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of clsFctAptOtEmpDtls) Implements iOTScheduling.GetLstOtEmpDtlsByApptNoIpNo
        GetLstOtEmpDtlsByApptNoIpNo = Nothing
        Try

            GetLstOtEmpDtlsByApptNoIpNo = clsFctAptOtEmp.GetLstOtEmpDtlsByApptNoIpNo(strErrMsg, chrErrFlg, COCd, Div, Loc, FctCd, FctCatCd, FctMainCd, ApptNo, PtnNo, IpNo, IpOpFlag)

        Catch ex As Exception
            GetLstOtEmpDtlsByApptNoIpNo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetLstOtEmpDtlsByApptNoIpNo
    End Function
#End Region

#Region "GetOtEmpDtlsByEmpNo"
    'pragya : 01-dec-2016
    Public Function GetOtEmpDtlsByEmpNo(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal companycode As String,
                                                      ByVal div As Integer,
                                                      ByVal loc As Integer,
                                                      ByVal EmpId As String) As clsAttPayDbEmpId Implements iOTScheduling.GetOtEmpDtlsByEmpNo
        Try
            GetOtEmpDtlsByEmpNo = Nothing
            GetOtEmpDtlsByEmpNo = clsAttPayDbEmpId.GetEmpIDDetails(strErrMsg, chrErrFlg, companycode, div, loc, EmpId)
            Return GetOtEmpDtlsByEmpNo
        Catch ex As Exception
            GetOtEmpDtlsByEmpNo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetOtEmpDtlsByEmpNo
    End Function
#End Region
#Region "GetOtSchSrvList"
    Public Function GetOtSchSrvList(ByRef strErrMsg As List(Of String),
                                            ByRef chrErrFlg As Char,
                                            ByVal companycode As String,
                                            ByVal div As Integer,
                                            ByVal loc As Integer, ByVal Srvdesc As String) As List(Of ClsOtSrvLstDtls) Implements iOTScheduling.GetOtSchSrvList
        Try

            GetOtSchSrvList = clsServiceMaster.GetSrvListOtSch(strErrMsg, chrErrFlg, companycode, div, loc, Srvdesc)

        Catch ex As Exception
            GetOtSchSrvList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetOtSchSrvList
    End Function
#End Region

#Region "GetLstOtSchSrvParaNm"
    'PRAGYA : 11-OCT-2016
    Public Function GetLstOtSchSrvParaNm(ByRef strErrMsg As List(Of String),
                                            ByRef chrErrFlg As Char,
                                            ByVal companycode As String,
                                            ByVal div As Integer,
                                            ByVal loc As Integer,
                                            ByVal ChrgCd As Integer,
                                            ByVal SrvCd As Integer) As List(Of clsFctAptOtSrvprm) Implements iOTScheduling.GetLstOtSchSrvParaNm
        Try

            GetLstOtSchSrvParaNm = clsFctAptOtSrvprm.GetLstOtSrvPrmNm(strErrMsg, chrErrFlg, companycode, div, loc, ChrgCd, SrvCd)

        Catch ex As Exception
            GetLstOtSchSrvParaNm = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetLstOtSchSrvParaNm
    End Function
#End Region

#Region "GetLstOtSrvDtlsByApptNoIpNo"
    Public Function GetLstOtSrvDtlsByApptNoIpNo(ByRef strErrMsg As List(Of String),
                                            ByRef chrErrFlg As Char,
                                            ByVal COCd As String,
                                            ByVal Div As Integer,
                                            ByVal Loc As Integer,
                                            ByVal FctCd As Integer,
                                            ByVal FctCatCd As Integer,
                                            ByVal FctMainCd As Integer,
                                            ByVal ApptNo As Integer,
                                            ByVal PtnNo As Long,
                                            ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of ClsOtSrvLstDtls) Implements iOTScheduling.GetLstOtSrvDtlsByApptNoIpNo
        GetLstOtSrvDtlsByApptNoIpNo = Nothing
        Try

            GetLstOtSrvDtlsByApptNoIpNo = clsFctAptOtSrv.GetChrgSrvLstOtSch(strErrMsg, chrErrFlg, COCd, Div, Loc, FctCd, FctCatCd, FctMainCd, ApptNo, PtnNo, IpNo, IpOpFlag)

        Catch ex As Exception
            GetLstOtSrvDtlsByApptNoIpNo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetLstOtSrvDtlsByApptNoIpNo
    End Function
#End Region

#Region "GetCalRate"
    'PRAGYA : 11-OCT-2016
    Function GetCalRate(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                           ByRef chrErrFlg As Char,
                           ByVal pcompanycode As String,
                           ByVal pdiv As Integer,
                           ByVal ploc As Integer,
                           ByVal objcalRate As CommonModule.clsCalRate,
                           Optional ByVal EmergencyFlg As String = "N") As CommonModule.clsCalRate Implements iOTScheduling.GetCalRate
        Try
            GetCalRate = Nothing
            objcalRate.EmergencyFlg = EmergencyFlg
            GetCalRate = CommonModule.clsCommonModule.calRate(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, objcalRate)
            Return GetCalRate
        Catch ex As Exception
            GetCalRate = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetCalRate
    End Function
#End Region

#Region "GetPtnClsDtlByIpOpNo : Selects ptn_cls_cd from given ipno  "
    'pragya : 14-oct-2016
    Public Function GetPtnClsDtlByIpOpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal companycode As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IPNo As Long) As clsPtnVstPtnClsDtl Implements iOTScheduling.GetPtnClsDtlByIpOpNo
        Try
            GetPtnClsDtlByIpOpNo = Nothing
            GetPtnClsDtlByIpOpNo = clsIpPatientVisit.GetPtnNoClsByIpNo(strErrMsg, chrErrFlg, companycode, div, loc, IPNo)
        Catch ex As Exception
            GetPtnClsDtlByIpOpNo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetPtnClsDtlByIpOpNo
    End Function

#End Region

#Region "Selects Ar_Cd from given ipno  "
    'pragya : 14-oct-2016
    Public Function GetArCdByIpOpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal companycode As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IPNo As Long) As Integer Implements iOTScheduling.GetArCdByIpOpNo
        Try
            GetArCdByIpOpNo = Nothing
            GetArCdByIpOpNo = clsIpBilInsTrn.GetArCdByIpOpNo(strErrMsg, chrErrFlg, companycode, div, loc, IPNo)
        Catch ex As Exception
            GetArCdByIpOpNo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetArCdByIpOpNo
    End Function

#End Region

#Region "Code decode type list"
    Public Function GetCodeDeCodeList(ByRef strErrMsg As List(Of String),
                                                 ByRef chrErrFlg As Char,
                                                 ByVal cocd As String,
                                                 ByVal div As Integer,
                                                 ByVal loc As Integer, ByVal typ As EnumCodeDecode
                                                ) As List(Of clsCodeDecode) Implements iOTScheduling.GetCodeDeCodeList
        Try
            GetCodeDeCodeList = Nothing
            Dim obj As New List(Of clsCodeDecode)
            obj = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, cocd, div, loc, typ)
            GetCodeDeCodeList = obj
        Catch ex As Exception
            GetCodeDeCodeList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
#End Region

#Region "GetFctAptOtDocList"
    'pragya : 14-oct-2016
    Public Function GetFctAptOtDocList(ByRef strErrMsg As List(Of String),
                                            ByRef chrErrFlg As Char,
                                            ByVal companycode As String,
                                            ByVal div As Integer,
                                            ByVal loc As Integer,
                                            ByVal DocCd As Integer) As clsOtDocDtls Implements iOTScheduling.GetFctAptOtDocList
        Try

            GetFctAptOtDocList = clsDoctor.GetFctAptOtDocList(strErrMsg, chrErrFlg, companycode, div, loc, DocCd)

        Catch ex As Exception
            GetFctAptOtDocList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetFctAptOtDocList
    End Function
#End Region

#Region "GetLstOtDocDtlsByApptNoIpNo"
    'pragya : 15-oct-2016
    Public Function GetLstOtDocDtlsByApptNoIpNo(ByRef strErrMsg As List(Of String),
                                                ByRef chrErrFlg As Char,
                                                    ByVal COCd As String,
                                                    ByVal Div As Integer,
                                                    ByVal Loc As Integer,
                                                    ByVal FctCd As Integer,
                                                    ByVal FctCatCd As Integer,
                                                    ByVal FctMainCd As Integer,
                                                    ByVal ApptNo As Integer,
                                                    ByVal PtnNo As Long,
                                                    ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of clsOtDocDtls) Implements iOTScheduling.GetLstOtDocDtlsByApptNoIpNo
        GetLstOtDocDtlsByApptNoIpNo = Nothing
        Try

            GetLstOtDocDtlsByApptNoIpNo = clsFctAptOtDoc.GetLstOtDocDtlsByApptNoIpNo(strErrMsg, chrErrFlg, COCd, Div, Loc, FctCd, FctCatCd, FctMainCd, ApptNo, PtnNo, IpNo, IpOpFlag)

        Catch ex As Exception
            GetLstOtDocDtlsByApptNoIpNo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetLstOtDocDtlsByApptNoIpNo
    End Function
#End Region

#Region "GetPtnNoByIpNo : GET THE PTNNO FROM IP_PTN_VST BY PASSING IPNO : ReturnType - LONG"
    'pragya : 02-nov-2016
    Public Function GetPtnNoByIpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal companycode As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As Long Implements iOTScheduling.GetPtnNoByIpNo
        GetPtnNoByIpNo = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(clsIpPatientVisit.SpSelIpPtnVst014(companycode, div, loc, IpNo))
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        GetPtnNoByIpNo = .Item("PtnNo")
                    End With
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


#End Region


#End Region

#Region "GET ACTIVE OT DETAILS" 'RasikV 20170130
    Public Function GetFCTMstLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer) As List(Of clsFCTMstHelp) Implements iOTScheduling.GetFCTMstLst
        GetFCTMstLst = Nothing
        Try
            GetFCTMstLst = clsFCTMST.GetFCTMstLst(strErrMsg, chrErrFlg, CoCd, Div, Loc, FCTCatCd, FCTMainCd, "A")
        Catch ex As Exception
            GetFCTMstLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetFCTMstLst
    End Function
#End Region



    '#Region "PopulatePager : Add pager"
    '    Public Function PopulatePager(ByRef strErrMsg As List(Of String),
    '                                                  ByRef chrErrFlg As Char,
    '                                                  ByVal recordCount As Integer, ByVal currentPage As Integer, ByVal DispNum As Integer, ByVal GridType As Char, ByVal Repeater As List(Of clsPaging), ByVal ItemCd As String, ByRef ReturnPageIndex As Integer,
    '                                                  ByVal PageSize As Integer) As List(Of clsPaging) Implements iOTScheduling.PopulatePager  'Pushpa 20180508

    '        Try
    '            PopulatePager = Nothing

    '            Dim obj As List(Of clsPaging)
    '            obj = clsPaging.PopulatePager(strErrMsg, chrErrFlg, recordCount, currentPage, DispNum, GridType, Repeater, ItemCd, ReturnPageIndex, PageSize)
    '            PopulatePager = obj
    '        Catch ex As Exception
    '            PopulatePager = Nothing
    '            strErrMsg.Add(ex.Message)
    '            chrErrFlg = "Y"
    '        End Try

    '    End Function
    '#End Region

#Region "Print"         'Aarti 21 May 2018
    Public Function GetNetIdParamDetailsNew(ByRef strErrMsg As List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal companycode As String,
                                      ByVal div As Integer,
                                      ByVal loc As Integer,
                                      ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal NetId As Integer) As List(Of clsNetIDParam) Implements iOTScheduling.GetNetIdParamDetailsNew
        Try
            GetNetIdParamDetailsNew = Nothing
            Dim objarr As List(Of clsNetIDParam)
            objarr = clsNetIDParam.GetNetIdParamDetails(strErrMsg, chrErrFlg, companycode, div, loc, ModCd, SubModCd, NetId)
            GetNetIdParamDetailsNew = objarr
        Catch ex As Exception
            GetNetIdParamDetailsNew = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetNetIdParamDetailsNew
    End Function

    Public Function GetPrntRptViewerRule8013(ByRef strErrMsg As List(Of String),
                                  ByRef chrErrFlg As Char,
                                  ByVal cocd As String,
                                  ByVal div As Integer,
                                  ByVal loc As Integer) As Boolean Implements iOTScheduling.GetPrntRptViewerRule8013

        GetPrntRptViewerRule8013 = Nothing
        Try

            Dim l_PrintReportViewer As Boolean = False
            'CHECK RULE FOR 8013  : Print Report with ReportViewer or PrintPDF
            Dim objRuleMst = New clsRuleMaster
            objRuleMst = clsRuleMaster.GetRuleMstDtls(strErrMsg, chrErrFlg, cocd, div, loc, 8013)
            If objRuleMst IsNot Nothing Then
                If objRuleMst.Data1 = "Y" Then
                    l_PrintReportViewer = True
                Else
                    l_PrintReportViewer = False
                End If
            Else
                chrErrFlg = "Y"
                strErrMsg.Add(strErrMsg(strErrMsg.Count - 1))
                l_PrintReportViewer = False
                GetPrntRptViewerRule8013 = False
                Return GetPrntRptViewerRule8013
            End If
            objRuleMst = Nothing
            'CHECK RULE FOR 8013  : Print Report with ReportViewer or PrintPDF

            GetPrntRptViewerRule8013 = l_PrintReportViewer

        Catch ex As Exception
            GetPrntRptViewerRule8013 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

        Return GetPrntRptViewerRule8013

    End Function

#End Region

#Region "GET THE LIST OF SMS CATEGORY WISE TO SEND SMS DOCTOR AND PATIENT" 'Rushikesh 20180915
    Public Function GetOtSchedulingSmsList(ByRef strErrMsg As List(Of String),
                                           ByRef chrErrFlg As Char,
                                           ByRef DSFetchData As DataSet,
                                           ByVal CoCd As String,
                                           ByVal Div As Integer,
                                           ByVal Loc As Integer,
                                           ByVal ModCd As Integer,
                                           ByVal SubModCd As Integer,
                                           ByVal CatTyp As Integer,
                                           ByVal DocCd As Integer,
                                           ByVal EmpId As String,
                                           ByVal ObjFctAptOT As clsFCTAPTOT) As List(Of clsSMSMstDetails) Implements iOTScheduling.GetOtSchedulingSmsList
        GetOtSchedulingSmsList = Nothing
        Dim ArrObjSmsMstDtl As New List(Of clsSMSMstDetails)
        Try
            Dim ofactory As New DBFactory
            If (ObjFctAptOT IsNot Nothing) Then

                DSFetchData = New DataSet

                Dim ObjSmsMstDtl As New clsSMSMstDetails
                ObjSmsMstDtl.IpNo = ObjFctAptOT.PTNNO
                ObjSmsMstDtl.DocCd = DocCd
                ObjSmsMstDtl.CategoryCd = CatTyp
                ArrObjSmsMstDtl.Add(ObjSmsMstDtl)

                Dim TmpStr, StrStartTm, StrEndTm As String
                Dim IntStartTm, IntEndTm As Integer
                Dim DtStartTm, DtEndTm As Date

                IntStartTm = ObjFctAptOT.APTMTMFROM
                IntEndTm = ObjFctAptOT.APTMTMTO

                TmpStr = Right("0000" & CStr(IntStartTm), 4)
                DtStartTm = CDate(Left(TmpStr, 2) & ":" & Right(TmpStr, 2))
                StrStartTm = Format(DtStartTm, "hh:mm tt")

                TmpStr = Right("0000" & CStr(IntEndTm), 4)
                DtEndTm = CDate(Left(TmpStr, 2) & ":" & Right(TmpStr, 2))
                StrEndTm = Format(DtEndTm, "hh:mm tt")

                Dim DsFetchDocDtl As New DataSet
                DsFetchDocDtl = ofactory.ExecuteDataSet(clsSmsDtl.SpSelGetSmsDtlForReplaceStr(CoCd, Div, Loc, ModCd, SubModCd, CatTyp, 0, ObjSmsMstDtl.IpNo, ObjSmsMstDtl.DocCd, Nothing, 0, Nothing, Nothing, 0, 0, Nothing, Nothing, 0, EmpId, ObjFctAptOT.FCTCODE, ObjFctAptOT.APPTNO, ObjFctAptOT.APTMDATE, StrStartTm, StrEndTm))

                If DsFetchDocDtl IsNot Nothing Then
                    If DsFetchDocDtl.Tables.Count > 0 Then
                        DSFetchData = DsFetchDocDtl
                    End If
                End If

                If ArrObjSmsMstDtl IsNot Nothing Then
                    If ArrObjSmsMstDtl.Count > 0 Then
                        GetOtSchedulingSmsList = ArrObjSmsMstDtl
                    End If
                End If
            End If
        Catch ex As Exception
            GetOtSchedulingSmsList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ArrObjSmsMstDtl = Nothing
        End Try
        Return GetOtSchedulingSmsList
    End Function

    Public Function GetOtIndirectBookingLst002(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, companycode As String,
                                               div As Integer, loc As Integer, IpNo As Long, Doccd As Integer, ExpDate As Date) As List(Of ClsOtIndirectBookingLst) Implements iOTScheduling.GetOtIndirectBookingLst002
        Try

            GetOtIndirectBookingLst002 = ClsOtIndirectBooking.GetOtIndirectBookingLst002(strErrMsg, chrErrFlg, companycode, div, loc, IpNo,
                Doccd, ExpDate)

        Catch ex As Exception
            GetOtIndirectBookingLst002 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetOtIndirectBookingLst002
    End Function

#Region "Get Info From rule Master by rule ID"
    Public Function GetRuleMstDtls(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, companycode As String,
                                 div As Integer, loc As Integer,
                                   RuleId As Integer) As clsRuleMaster Implements iOTScheduling.GetRuleMstDtls      'Aarti 10 Oct 2020
        Try
            GetRuleMstDtls = Nothing
            GetRuleMstDtls = clsRuleMaster.GetRuleMstDtls(strErrMsg, chrErrFlg, companycode, div, loc, RuleId)
            Return GetRuleMstDtls
        Catch ex As Exception
            GetRuleMstDtls = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetRuleMstDtls
    End Function
#End Region

#End Region


#Region "Added by Farid for Post Voucher pagging"

    Public Function PatientHelpMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char,
                                            cocd As String, div As Integer, loc As Integer,
                                            ByVal FirstNm As String,
                                            ByVal MiddleNm As String, ByVal LastNm As String,
                                            ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer, ByVal AdharNo As String, ByVal PanNo As String, ByVal Address As String, ByVal FathersName As String) As List(Of clsPatientHelp) Implements iOTScheduling.PatientHelpMst 'Farid '02-may-02017'
        PatientHelpMst = Nothing
        Dim objarr As List(Of clsPatientHelp)
        Try
            If AdditionalCriteria <> "" Then
                AdditionalCriteria = "mobile='" + AdditionalCriteria + "'"
            End If
            objarr = New List(Of clsPatientHelp)
            objarr = clsInPatient.PatientHelpMst(strErrMsg, chrErrFlg, cocd, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria, Pageindex, PageSize, AdharNo, PanNo, Address, FathersName)
            If objarr IsNot Nothing Then
                PatientHelpMst = objarr
            End If
        Catch ex As Exception
            PatientHelpMst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            objarr = Nothing
        End Try
        Return PatientHelpMst
    End Function

    Public Function PatientHelpListMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char,
                                           cocd As String, div As Integer, loc As Integer,
                                           ByVal FirstNm As String,
                                           ByVal MiddleNm As String, ByVal LastNm As String,
                                           ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer,
ByVal AdharNo As String, ByVal PanNo As String, ByVal Address As String) As List(Of clsPatientHelp) Implements iOTScheduling.PatientHelpListMst 'Farid '02-may-02017'
        PatientHelpListMst = Nothing
        Dim objarr As List(Of clsPatientHelp)
        Try
            If AdditionalCriteria <> "" Then
                AdditionalCriteria = "mobile='" + AdditionalCriteria + "'"
            End If
            objarr = New List(Of clsPatientHelp)
            objarr = clsInPatient.PatientHelpListMst(strErrMsg, chrErrFlg, cocd, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria, Pageindex, PageSize, AdharNo, PanNo, Address)
            If objarr IsNot Nothing Then
                PatientHelpListMst = objarr
            End If
        Catch ex As Exception
            PatientHelpListMst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            objarr = Nothing
        End Try
        Return PatientHelpListMst
    End Function

    Public Function PopulatePager(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal recordCount As Integer, ByVal currentPage As Integer, ByVal DispNum As Integer, ByVal GridType As Char, ByVal Repeater As List(Of clsPaging), ByVal ItemCd As String, ByRef ReturnPageIndex As Integer,
                                               ByVal PageSize As Integer) As List(Of clsPaging) Implements iOTScheduling.PopulatePager  'Farid '02-may-02017'

        Try
            PopulatePager = Nothing

            Dim obj As List(Of clsPaging)
            obj = clsPaging.PopulatePager(strErrMsg, chrErrFlg, recordCount, currentPage, DispNum, GridType, Repeater, ItemCd, ReturnPageIndex, PageSize)
            PopulatePager = obj
        Catch ex As Exception
            PopulatePager = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

#End Region


#Region "GetPatientDetails"
    Public Function GetPatientDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal pptnno As Long) As PatientDetails Implements iOTScheduling.GetPatientDetails
        Try
            Dim objPTNNDET As PatientDetails
            objPTNNDET = Nothing
            Dim objpatient As clsPatient
            objpatient = clsPatient.GetPatient(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, pptnno)
            If chrErrFlg = "Y" Then Return Nothing
            If (Not objpatient Is Nothing) Then
                objPTNNDET = New PatientDetails()
                objPTNNDET.PatientNo = objpatient.PatientNo

                objPTNNDET.PatientFullName = objpatient.PatientFullName
                objPTNNDET.Gender = objpatient.Gender

                objPTNNDET.Age = objpatient.Age 'Rushikesh 06 sep 2018
                objPTNNDET.Agetypflg = objpatient.Agetypflg
                objPTNNDET.EMPNO = objpatient.EMPNo
                objPTNNDET.MRNo = objpatient.MRNo
                objPTNNDET.IsMember = objpatient.IsMember

                objPTNNDET.MembershipPerc = 0 '****NEED: CALL FUNCTION TO GET MEMBERSHIP %****
                objPTNNDET.PatientClass = "" '****DOUBT: Patient class for Out Patient ???****

                objPTNNDET.BillTyp = objpatient.BillTyp
                objPTNNDET.ArCd = objpatient.ArCd
                objPTNNDET.TYPFLG = objpatient.TYPFLG
                objPTNNDET.EXPDT = objpatient.EXPDT
                objPTNNDET.EMPNO = objpatient.EMPNo
                objPTNNDET.Status = objpatient.Status
                objPTNNDET.ArEmpcd = objpatient.ArEmpcd
                objPTNNDET.PtnRefByTyp = objpatient.PtnRefByTyp ''Rushikesh 20190801
                objPTNNDET.PtnRefBycd = objpatient.PtnRefBycd ''Rushikesh 20190801

                objPTNNDET.MapConcType = objpatient.MapConcType 'Amol 24-03-2020 CMCH-141969

                objPTNNDET.BirthDate = objpatient.BirthDate
                objPTNNDET.istranblocked = objpatient.istranblocked


                objPTNNDET.PtnCareModelDCd = objpatient.PtnCareModelDCd
                objPTNNDET.PtnCareModelRmrk = objpatient.PtnCareModelRmrk
                objPTNNDET.PtnType = objpatient.PtnType

                objPTNNDET.PrmntPtnno = objpatient.PrmntPtnno

                'shital 20191220 start

                objPTNNDET.IsPtnBlackListed = objpatient.IsPtnBlackListed
                objPTNNDET.PtnBlackListedRsn = objpatient.PtnBlackListedRsn
                'end
                objPTNNDET.PtnRmrk = objpatient.PtnRmrk 'Nikita 20200117
                objPTNNDET.CampCd = objpatient.CampCd 'maitri 20200219
            End If
            Return objPTNNDET
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

#End Region

    Public Function setproperties(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                         ByRef chrErrFlg As Char,
                                                         ByVal CoCd As String,
                                                         ByVal Div As Integer,
                                                         ByVal Loc As Integer, ByVal objRuleMst As clsRuleMaster) As List(Of ClsPtnDtlsSetup) Implements iOTScheduling.setproperties
        Try
            setproperties = ClsPtnDtlsSetup.setproperties(strErrMsg, chrErrFlg, CoCd, Div, Loc, objRuleMst)

        Catch ex As Exception
            setproperties = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return setproperties
    End Function


    Public Function GetIpWiseOtAppList(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String,
                                            ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long, ByVal ToDate As Date) As List(Of ClsOtIndirectBookingLst) Implements iOTScheduling.GetIpWiseOtAppList  ''Amol 07-11-2020 JSK001-147271	
        Try

            GetIpWiseOtAppList = ClsOtIndirectBooking.GetIpWiseOtAppList(strErrMsg, chrErrFlg, companycode, div, loc, IpNo, ToDate)

        Catch ex As Exception
            GetIpWiseOtAppList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetIpWiseOtAppList
    End Function

    Public Function GetOpToIpConvertPtnListForOt(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String,
                                            ByVal div As Integer, ByVal loc As Integer,
                                            ByVal IpNo As Long, ByVal ToDate As Date) As List(Of clsConvertOpToIp) Implements iOTScheduling.GetOpToIpConvertPtnListForOt  ''Amol 07-11-2020 JSK001-147270	
        Try

            GetOpToIpConvertPtnListForOt = clsConvertOpToIp.GetOpToIpConvertPtnListForOt(strErrMsg, chrErrFlg, companycode, div, loc, IpNo, ToDate)

        Catch ex As Exception
            GetOpToIpConvertPtnListForOt = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetOpToIpConvertPtnListForOt
    End Function



    Public Function ConvertOpToIp(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char,
                               ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer,
                               ByVal AptNo As Integer, ByVal IPNO As Long, ByVal PtnNo As Long) As Boolean Implements iOTScheduling.ConvertOpToIp

        ConvertOpToIp = False

        Dim ofactory As DBFactory
        ofactory = New DBFactory
        Dim ds As New DataSet
        Dim obj As New clsInsertUpdateSrNo
        Dim inapptno As Integer

        Try

            ofactory.BeginExecution("Y")

            Dim dbrequestIns As DBRequest = clsInsertUpdateFCTAPTMAIN.SpUpdConvertOpToIp(pcompanycode, pdiv, ploc, AptNo, IPNO, PtnNo)
            If ofactory.ExecuteNonQuery(dbrequestIns) = 0 Then
                'strErrMsg.Add("B")
                strErrMsg.Add("Record not Updated.")
                ofactory.RollBackExecution()
                chrErrFlg = "Y"
                Return False
            End If

            ofactory.CommitExecution()

            ConvertOpToIp = True


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

        Return ConvertOpToIp
    End Function

#Region "QUICK PATIENT REGISTRATION FUNCTIONS Added By AARTI 06 JAN 2020"
    Public Function Salutation(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of clsCodeDecode) Implements iOTScheduling.Salutation
        Try

            Salutation = clsCodeDecode.Salutation(strErrMsg, chrErrFlg, cocd, pdiv, ploc)

        Catch ex As Exception
            Salutation = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return Salutation
    End Function

    Public Function GetPtnType(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, Cocd As String, Div As Integer, Loc As Integer, pPtnBillTyp As Integer) As List(Of clsPtnTypeMst) Implements iOTScheduling.GetPtnType
        Try

            GetPtnType = clsPtnTypeMst.GetPtnType(strErrMsg, chrErrFlg, Cocd, Div, Loc, pPtnBillTyp)

        Catch ex As Exception
            GetPtnType = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetPtnType
    End Function

    Public Function GetPtnTypByUser(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String,
             ByVal div As Integer, ByVal loc As Integer, ByVal userid As String, ByVal PtnNo As Long) As List(Of clsPtnTypeMst) Implements iOTScheduling.GetPtnTypByUser
        GetPtnTypByUser = Nothing
        Try
            Dim objclsMRDLocnMstList As New List(Of clsPtnTypeMst)
            objclsMRDLocnMstList = clsPtnTypeMst.GetPtnTypByUser(strErrMsg, chrErrFlg, companycode, div, loc, userid, PtnNo)

            GetPtnTypByUser = objclsMRDLocnMstList
        Catch ex As Exception
            GetPtnTypByUser = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Public Function GetPtnDtlByMobNoDetails(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer, MobNo As String) As List(Of clsPtnBasicInfo) Implements iOTScheduling.GetPtnDtlByMobNoDetails
        Try

            GetPtnDtlByMobNoDetails = clsPatient.GetPtnDtlByMobNoDetails(strErrMsg, chrErrFlg, CoCd, Div, Loc, MobNo)

        Catch ex As Exception
            GetPtnDtlByMobNoDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetPtnDtlByMobNoDetails
    End Function




#End Region

#Region "Get State List with Country Name from state master table "
    Public Function GetStateLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, Cocd As String, Div As Integer, Loc As Integer, statecd As Integer, stateName As String) As List(Of StateMaster) Implements iOTScheduling.GetStateLst
        Try

            GetStateLst = StateMaster.GetStateLst(strErrMsg, chrErrFlg, Cocd, Div, Loc, statecd, stateName)

        Catch ex As Exception
            GetStateLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetStateLst
    End Function

    Public Function GetCityLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, Cocd As String, Div As Integer, Loc As Integer, Statecd As Integer, citycd As Integer, cityname As String) As List(Of StateMaster) Implements iOTScheduling.GetCityLst
        Try

            GetCityLst = StateMaster.GetCityLst(strErrMsg, chrErrFlg, Cocd, Div, Loc, Statecd, citycd, cityname)

        Catch ex As Exception
            GetCityLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetCityLst
    End Function

#End Region

#Region "Save Quick Registration"
    Public Function SaveConfirmEnqPtn(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                     ByRef chrErrFlg As Char, ByRef SessionState As Integer,
                                     ByRef PtnNo As Long,
                                     ByVal CoCd As String,
                                     ByVal Div As Integer,
                                     ByVal Loc As Integer, ByVal ModCd As Integer,
                                               ByVal SubModCd As Integer,
                                               ByVal SessionId As Long,
                                     ByVal UsrId As String,
                                     ByVal UsrDtTm As Date,
                                     ByVal objBkdDtls As clsPatient) As Boolean Implements iOTScheduling.SaveConfirmEnqPtn
        SaveConfirmEnqPtn = Nothing
        Dim ofactory As DBFactory
        Dim DbRequest As New DBRequest
        ofactory = New DBFactory
        Dim newptmno As Long
        Dim objPtnMst2 As New clsPtnMst2
        Dim objUpdSrNo As New clsInsertUpdateSrNo
        Dim Mrno As Integer = 0

        Try


            SessionState = clsCommonModule.CheckUserSeesionState(strErrMsg, chrErrFlg, SessionId)
            If SessionState <> 1 Then
                SaveConfirmEnqPtn = False
                Return SaveConfirmEnqPtn
            End If
            Mrno = objUpdSrNo.GetUpdateMRNo(strErrMsg, chrErrFlg, CoCd, Div, Loc)

            If objBkdDtls.TYPFLG = "P" Then  'FOR PARMANENT /

                newptmno = clsInsertUpdateSrNo.SpSelUpdAdtDcNos(strErrMsg, chrErrFlg, CoCd, Div, Loc, 11, UsrDtTm, UsrId)

            Else
                Dim objRuleMst As New clsRuleMaster
                objRuleMst = clsRuleMaster.GetRuleMstDtls(strErrMsg, chrErrFlg, CoCd, Div, Loc, 9175)
                If objRuleMst IsNot Nothing Then
                    If objRuleMst.Data1 = "Y" Then
                        newptmno = clsInsertUpdateSrNo.SpSelUpdAdtDcNos(strErrMsg, chrErrFlg, CoCd, Div, Loc, 21, objBkdDtls.UserDtTm, objBkdDtls.UserId)
                    Else
                        newptmno = clsInsertUpdateSrNo.SpSelUpdAdtDcNos(strErrMsg, chrErrFlg, CoCd, Div, Loc, 11, objBkdDtls.UserDtTm, objBkdDtls.UserId)
                    End If
                Else
                    newptmno = clsInsertUpdateSrNo.SpSelUpdAdtDcNos(strErrMsg, chrErrFlg, CoCd, Div, Loc, 11, objBkdDtls.UserDtTm, objBkdDtls.UserId)
                End If
                Dim objAdtInDt As New clsAdtInDt
                Dim objAdtInDt1 As New clsAdtInDt
                objAdtInDt = CommonModule.clsCommonModule.GetADTInDt(strErrMsg, chrErrFlg, CoCd, Div, Loc, objAdtInDt1)
                If objAdtInDt IsNot Nothing Then
                    objBkdDtls.EXPDT = DateAdd(Microsoft.VisualBasic.DateInterval.Day, IIf(IsDBNull(objAdtInDt.VldPrd), 0, objAdtInDt.VldPrd), objBkdDtls.UserDtTm)
                End If
            End If

            'Assign Data to Ptn_Mst2
            objPtnMst2.PtnNo = newptmno
            objPtnMst2.UserDtTm = UsrDtTm
            objPtnMst2.UserId = UsrId
            objBkdDtls.PatientNo = newptmno

            ofactory.BeginExecution("Y")


            'insert into ptn_mst1
            DbRequest = clsInsertUpdatePatMst.SpInsPtnMst1001(strErrMsg, chrErrFlg, CoCd, Div, Loc, objBkdDtls)
            If ofactory.ExecuteNonQuery(DbRequest) = 0 Then
                strErrMsg.Add("Record not into into  Ptn_Mst1 ")
                ofactory.RollBackExecution()
                chrErrFlg = "Y"
                Return False
            End If



            'insert into ptn_mst2
            DbRequest = clsInsertUpdatePatMst.SpInsPtnMst2001(strErrMsg, chrErrFlg, CoCd, Div, Loc, objPtnMst2)
            If ofactory.ExecuteNonQuery(DbRequest) = 0 Then
                strErrMsg.Add("Record not into into Ptn_Mst2 ")
                ofactory.RollBackExecution()
                chrErrFlg = "Y"
                Return False
            End If
            ofactory.CommitExecution()
            SaveConfirmEnqPtn = True



        Catch ex As Exception

            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return False
        End Try
        PtnNo = newptmno
        Return SaveConfirmEnqPtn
    End Function

    Public Function GetCdDcdDtlByTypByCdByAddInfo1(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String,
             ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal AddInfo1 As String) As clsCodeDecode Implements iOTScheduling.GetCdDcdDtlByTypByCdByAddInfo1
        Try
            GetCdDcdDtlByTypByCdByAddInfo1 = Nothing
            Dim obj As New clsCodeDecode
            obj = clsCodeDecode.GetCdDcdDtlByTypByCdByAddInfo1(strErrMsg, chrErrFlg, cocd, div, loc, typ, AddInfo1)
            GetCdDcdDtlByTypByCdByAddInfo1 = obj
        Catch ex As Exception
            GetCdDcdDtlByTypByCdByAddInfo1 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Public Function GetCodeDeCodeDtlByTypByCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String,
             ByVal div As Integer, ByVal loc As Integer, ByVal typ As EnumCodeDecode, ByVal Cd As Integer) As clsCodeDecode Implements iOTScheduling.GetCodeDeCodeDtlByTypByCd
        Try
            GetCodeDeCodeDtlByTypByCd = Nothing
            Dim obj As New clsCodeDecode
            obj = clsCodeDecode.GetCodeDeCodeDtlByTypByCd(strErrMsg, chrErrFlg, cocd, div, loc, typ, Cd)
            GetCodeDeCodeDtlByTypByCd = obj
        Catch ex As Exception
            GetCodeDeCodeDtlByTypByCd = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Public Function Nationality(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, cocd As String, pdiv As Integer, ploc As Integer) As List(Of clsCodeDecode) Implements iOTScheduling.Nationality
        Try

            Nationality = clsCodeDecode.Nationality(strErrMsg, chrErrFlg, cocd, pdiv, ploc)

        Catch ex As Exception
            Nationality = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return Nationality
    End Function
#End Region





#Region "For Module Wise Function Rights" '#Trupti 15 JUN 2021
    Public Function GetModFncLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer,
           ByVal Loc As Integer,
                                 ByVal ModCd As Integer,
                                 ByVal SubModCd As Integer,
                                 ByVal FuncID As Integer,
                                 ByVal UsrID As String) As List(Of clsUserModuleFunction) Implements iOTScheduling.GetModFncLst
        Try
            GetModFncLst = Nothing
            GetModFncLst = clsUserModuleFunction.GetModFncLst(strErrMsg, chrErrFlg, CoCd, Div, Loc, ModCd, SubModCd, FuncID, UsrID)
        Catch ex As Exception
            GetModFncLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetModFncLst
    End Function
    Public Function GetModFnDetails(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer,
           ByVal Loc As Integer,
                                 ByVal ModCd As Integer,
                                 ByVal SubModCd As Integer) As List(Of clsUserModuleFunction) Implements iOTScheduling.GetModFnDetails
        Try
            GetModFnDetails = Nothing
            GetModFnDetails = clsUserModuleFunction.GetModFnDetails(strErrMsg, chrErrFlg, CoCd, Div, Loc, ModCd, SubModCd)
        Catch ex As Exception
            GetModFnDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetModFnDetails
    End Function

#End Region





    Public Function GetPtnTypListByUser(ByRef strErrMsg As List(Of String),
                                       ByRef chrErrFlg As Char,
                                       ByVal companycode As String,
                                       ByVal div As Integer,
                                       ByVal loc As Integer, ByVal UserId As String) As List(Of ClsUserPtnTypMst) Implements iOTScheduling.GetPtnTypListByUser
        Try
            GetPtnTypListByUser = Nothing
            Dim obj1 As New List(Of ClsUserPtnTypMst)
            obj1 = clsPtnTypeMst.GetPtnTypListByUser(strErrMsg, chrErrFlg, companycode, div, loc, UserId)
            GetPtnTypListByUser = obj1
            Return GetPtnTypListByUser
        Catch ex As Exception
            GetPtnTypListByUser = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Public Function GetArMstDetailsByArCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal ArCd As Integer) As clsArMst Implements iOTScheduling.GetArMstDetailsByArCd
        Try
            GetArMstDetailsByArCd = Nothing
            GetArMstDetailsByArCd = clsArMst.GetArMstDetailsByArCd(strErrMsg, chrErrFlg, cocd, div, loc, ArCd)
            Return GetArMstDetailsByArCd
        Catch ex As Exception
            GetArMstDetailsByArCd = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetArMstDetailsByArCd
    End Function



    Public Function GetOTDtlsByFilter(ByRef strErrMsg As List(Of String),
                                       ByRef chrErrFlg As Char,
                                       ByVal companycode As String,
                                       ByVal div As Integer,
                                       ByVal loc As Integer, ByVal FrmDt As Date,
                                                          ByVal ToDt As Date,
                                                          ByVal Flg As Char,
                                                          ByVal ApptSts As Int16, ByVal ArCd As String, ByVal OTCd As Integer, ByVal PtnType As Integer, ByVal chkDt As Boolean) As List(Of clsFCTAPTOT) Implements iOTScheduling.GetOTDtlsByFilter
        Try
            GetOTDtlsByFilter = Nothing
            Dim obj1 As New List(Of clsFCTAPTOT)
            obj1 = clsFCTAPTOT.GetOTDtlsByFilter(strErrMsg, chrErrFlg, companycode, div, loc, FrmDt, ToDt, Flg, ApptSts, ArCd, OTCd, PtnType, chkDt)
            GetOTDtlsByFilter = obj1
            Return GetOTDtlsByFilter
        Catch ex As Exception
            GetOTDtlsByFilter = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"


            strErrMsg.Add(ex.Message)

            chrErrFlg = "Y"


            If (strErrMsg.Count > 0 And chrErrFlg = "Y") Then

                Throw New System.Exception(strErrMsg(0).ToString().Trim())
            End If

        End Try

    End Function


    Public Function GetCreditCoListSts(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer) As List(Of clsArMstCdDcd) Implements iOTScheduling.GetCreditCoListSts
        Try
            GetCreditCoListSts = Nothing
            GetCreditCoListSts = clsArMst.GetCreditCoLstSts(strErrMsg, chrErrFlg, cocd, div, loc)
            Return GetCreditCoListSts
        Catch ex As Exception
            GetCreditCoListSts = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetCreditCoListSts
    End Function
    'added by shivkumar 15/11/2021
    Public Function GetUserDetByCD(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal COCd As String, ByVal Div As Integer,
                                  ByVal Loc As Integer, ByVal UserId As String) As clsUserDet Implements iOTScheduling.GetUserDetByCD
        Try
            GetUserDetByCD = Nothing
            GetUserDetByCD = clsUserDet.GetUserDetByCD(strErrMsg, chrErrFlg, COCd, Div, Loc, UserId)
        Catch ex As Exception
            GetUserDetByCD = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetUserDetByCD
    End Function
    'default set sate name maharashtra
    Public Function GetIsBaseStateMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
          ByVal Div As Integer, ByVal Loc As Integer, IsBase As Boolean) As StateMaster Implements iOTScheduling.GetIsBaseStateMst
        Try
            GetIsBaseStateMst = Nothing
            GetIsBaseStateMst = StateMaster.GetIsBaseStateMst(strErrMsg, chrErrFlg, CoCd, Div, Loc, IsBase)
        Catch ex As Exception
            GetIsBaseStateMst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetIsBaseStateMst
    End Function

    ''default set city name mumbai

    Public Function GetIsBaseCityMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
       ByVal Div As Integer, ByVal Loc As Integer, ByVal IsBase As Boolean) As CityMaster Implements iOTScheduling.GetIsBaseCityMst
        Try
            GetIsBaseCityMst = Nothing
            GetIsBaseCityMst = CityMaster.GetIsBaseCityMst(strErrMsg, chrErrFlg, CoCd, Div, Loc, IsBase)
        Catch ex As Exception
            GetIsBaseCityMst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetIsBaseCityMst
    End Function
    Public Function SaveOfficePermissionChk(ByRef StrErrMsg As List(Of String), ByRef ChrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal obj As ClsOtIndirectBooking) As Boolean Implements iOTScheduling.SaveOfficePermissionChk  'Nutan 12 Jan 2022

        Dim ofactory As New DBFactory
        Dim oRequest As New DBRequest
        Dim PtnNo As Integer
        Dim TrnNo As Integer
        Dim IsRecordExist As Boolean = True

        Try


            ofactory.BeginExecution("Y")
            If (obj IsNot Nothing) Then


                If (IsRecordExist = True) Then
                    'obj.PtnNo = PtnNo
                    'obj.TrnNo = TrnNo
                    oRequest = clsInsertUpdateOtIndirectBooking.SpUpOtIndirctBookngChkop(StrErrMsg, ChrErrFlg, pcompanycode, pdiv, ploc, obj)
                End If
                ofactory.ExecuteNonQuery(oRequest)
            End If

            ofactory.CommitExecution()
            SaveOfficePermissionChk = True

        Catch ex As Exception
            ofactory.RollBackExecution()
            StrErrMsg.Add(ex.Message)
            ChrErrFlg = "Y"
            SaveOfficePermissionChk = False
        End Try

        Return SaveOfficePermissionChk

    End Function
    Public Function GetOTDataForDashBrdSch(ByRef strErrMsg As List(Of String),
                                           ByRef chrErrFlg As Char,
                                           ByVal companycode As String,
                                           ByVal div As Integer,
                                           ByVal loc As Integer, ByVal FrmDt As Date,
                                                              ByVal ToDt As Date,
                                                              ByVal Flg As Char,
                                                              ByVal ApptSts As Int16, ByVal ArCd As String, ByVal OTCd As Integer, ByVal PtnType As Integer, ByVal chkDt As Boolean) As List(Of clsFCTAPTOT) Implements iOTScheduling.GetOTDataForDashBrdSch
        Try
            GetOTDataForDashBrdSch = Nothing
            Dim obj1 As New List(Of clsFCTAPTOT)
            obj1 = clsFCTAPTOT.GetOTDataForDashBrdSch(strErrMsg, chrErrFlg, companycode, div, loc, FrmDt, ToDt, Flg, ApptSts, ArCd, OTCd, PtnType, chkDt)
            GetOTDataForDashBrdSch = obj1
            Return GetOTDataForDashBrdSch
        Catch ex As Exception
            GetOTDataForDashBrdSch = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"


            strErrMsg.Add(ex.Message)

            chrErrFlg = "Y"


            If (strErrMsg.Count > 0 And chrErrFlg = "Y") Then

                Throw New System.Exception(strErrMsg(0).ToString().Trim())
            End If

        End Try

    End Function


    Public Function GetVarDef(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char,
                                     pcompanycode As String, pdiv As Integer,
                                     ploc As Integer,
                                     pUsrId As String) As List(Of clsPtnTypeMst) Implements iOTScheduling.GetVarDef
        Try
            GetVarDef = Nothing

            Dim objarrVarDef As List(Of clsPtnTypeMst)
            objarrVarDef = clsPtnTypeMst.GetDefaultValues(pcompanycode, pdiv, ploc, pUsrId)
            GetVarDef = objarrVarDef
        Catch ex As Exception
            GetVarDef = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function




End Class
