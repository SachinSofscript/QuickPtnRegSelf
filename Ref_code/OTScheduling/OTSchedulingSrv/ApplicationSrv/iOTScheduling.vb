Imports System.ServiceModel
Imports OTSchedulingSrv
Imports OTSchedulingSrv.PatientVisitAndBilInsTrn

<ServiceContract()>
Public Interface iOTScheduling
    <OperationContract()>
    Function GetOtIndirectBookingLst002(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String,
                                            ByVal div As Integer,
                                            ByVal loc As Integer, ByVal IpNo As Long,
                                            ByVal Doccd As Integer, ByVal ExpDate As DateTime) As List(Of ClsOtIndirectBookingLst)  'Aarti 21 Sep 2020
    <OperationContract()>
    Function GetFCTCAL(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FCTDAY As Integer) As List(Of clsFCTCAL) 'Implements iOTScheduling.GetFCTHoliDayDay


    <OperationContract()>
    Function GetFCTHoliDayDay(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTDAY As Date) As List(Of clsFCTMST) 'Implements iOTScheduling.GetFCTHoliDayDay


    <OperationContract()>
    Function GetFctMstDtlList(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer) As List(Of clsMaster) 'Implements iOTScheduling.GetFctMstDtlList


    'mayur 20130916
    <OperationContract()>
    Function GetPatientListByNameAndOtherParameter(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                     ByVal FirstNm As String,
                                                     ByVal MiddleNm As String,
                                                     ByVal LastNm As String,
                                                     ByVal AdditionalCriteria As String
                                                   ) As System.Collections.Generic.List(Of clsPatient) 'Implements iOTScheduling.GetPatientListByNameAndOtherParameter


    'mayur 20130916
    <OperationContract()>
    Function DoctorSpeciality(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)


    'mayur 20130916
    <OperationContract()>
    Function GetFCTFCTSTRTTIME(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FCTDAY As Integer) As Integer


    'mayur 20130916
    <OperationContract()>
    Function GetFCTFCTENDTIME(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FCTDAY As Integer) As Integer


    'mayur 20130916
    <OperationContract()>
    Function GetFCTAPTREQ(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer) As DataSet


    'mayur 20130913
    <OperationContract()>
    Function GetFCTMST(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer) As List(Of clsFCTMST)


    'mayur 20130913
    <OperationContract()>
    Function GetPatientList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of clsPatient)

    'mayur 20130913
    <OperationContract()>
    Function GetDoctorList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of clsDoctor)

    'mayur 20130913
    <OperationContract()>
    Function SAVERECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FctDay As Integer, ByVal SCHDAT As Date, ByVal lvReqno As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal objOtIndirectBooking As ClsOtIndirectBooking, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp), ByRef AptNo As Integer) As Boolean

    'mayur 20130913
    <OperationContract()>
    Function EDITERECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FctDay As Integer, ByVal SCHDAT As Date, ByVal lvReqno As Integer, ByVal ApptNo As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp)) As Boolean

    'mayur 20130913
    <OperationContract()>
    Function CNCLRECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal ApptNo As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal objclsFCTSCH As clsFCTSCH, ByVal objclsFCTAPTCNCL As clsFCTAPTCNCL) As Boolean

    'mayur 20130913
    <OperationContract()>
    Function SHIFTRECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal ApptNo As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal objclsFCTAPTCNCL As clsFCTAPTCNCL, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp)) As Boolean

    'mayur 20130913
    <OperationContract()>
    Function SHIFTNOW(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal OldFCTCODE As Integer, ByVal FctDay As Integer, ByVal SCHDAT As Date, ByVal lvReqno As Integer, ByVal ApptNo As Integer, ByVal IPNO As Long, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal objclsFCTAPTCNCL As clsFCTAPTCNCL, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp)) As String

    'mayur 20130913
    <OperationContract()>
    Function GetOTAptDetails1(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                       ByVal companycode As String,
                                                       ByVal div As Integer,
                                                       ByVal loc As Integer,
                                                       ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal APTMDATE As Date, ByVal APTNO As Integer, ByVal APTMTMFRM As Integer, ByVal APTMTMTO As Integer, ByVal FLG As String) As List(Of clsFCTAPTOT)
    '<OperationContract()>
    'Function GetPatientFullName(ByRef strErrMsg As List(Of String), _
    '                          ByRef chrErrFlg As Char, _
    '                          ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
    '                          ByVal patientno As Integer) As String
    <OperationContract()>
    Function GetPatientFullName(ByRef strErrMsg As List(Of String),
                              ByRef chrErrFlg As Char,
                              ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                              ByVal patientno As Long) As String 'anamika 20161202

    <OperationContract()>
    Function GetDoctor(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer,
                                                    ByVal doctorcode As Integer) As String

    <OperationContract()>
    Function GetCdDcdDtlByTypByCdByAddInfo1(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String,
                 ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal AddInfo1 As String) As clsCodeDecode


    <OperationContract>
    Function GetCodeDeCodeDtlByTypByCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String,
             ByVal div As Integer, ByVal loc As Integer, ByVal typ As EnumCodeDecode, ByVal Cd As Integer) As clsCodeDecode 'RasikV 20160929


#Region "OtIndirectBooking"  'RasikV 20160922
    <OperationContract()>
    Function SaveIndirectBooking(ByRef StrErrMsg As List(Of String), ByRef ChrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal obj As ClsOtIndirectBooking) As Boolean

    <OperationContract()>
    Function CancelOtIndirectBooking(ByRef StrErrMsg As List(Of String), ByRef ChrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal TrnNo As Integer, ByVal PtnNo As Long, ByVal UsrId As String, ByVal UsrDatTm As Date) As Boolean

    <OperationContract()>
    Function GetOtIndirectBookingLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String,
                                     ByVal div As Integer, ByVal loc As Integer, ByVal ExpDate As Date, ByVal ToDate As Date) As List(Of ClsOtIndirectBookingLst)
#End Region

#Region "Common Master" 'RasikV 20160922

    <OperationContract()>
    Function WardDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer) As List(Of clsCodeDecode)

    <OperationContract()>
    Function GetInPtnListByNameDocWard(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal Cocd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FrstNm As String, ByVal MidNm As String, ByVal LstNm As String, ByVal DocCd As Integer, ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As List(Of clsInPatientHelp)

    <OperationContract()>
    Function GetInpatientDetails(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, Optional ByVal IPNumber As Long = 0) As clsIpPatientVisit


    <OperationContract()>
    Function GetOtName(ByRef strErrMsg As List(Of String),
                                  ByRef chrErrFlg As Char,
                                  ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                  ByVal OtNo As Integer) As String 'anamika 20160930
#End Region

    <OperationContract()>
    Function GetOtSchSrvList(ByRef strErrMsg As List(Of String),
                                            ByRef chrErrFlg As Char,
                                            ByVal companycode As String,
                                            ByVal div As Integer,
                                            ByVal loc As Integer, ByVal Srvdesc As String) As List(Of ClsOtSrvLstDtls)   'pragya : 11-ocxt-2016
    <OperationContract()>
    Function GetLstOtSchSrvParaNm(ByRef strErrMsg As List(Of String),
                                                ByRef chrErrFlg As Char,
                                                ByVal companycode As String,
                                                ByVal div As Integer,
                                                ByVal loc As Integer,
                                                ByVal ChrgCd As Integer,
                                                ByVal SrvCd As Integer) As List(Of clsFctAptOtSrvprm)   'pragya : 11-ocxt-2016


    <OperationContract()>
    Function GetCalRate(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                           ByRef chrErrFlg As Char,
                           ByVal pcompanycode As String,
                           ByVal pdiv As Integer,
                           ByVal ploc As Integer,
                           ByVal objcalRate As CommonModule.clsCalRate,
                           Optional ByVal EmergencyFlg As String = "N") As CommonModule.clsCalRate    'pragya : 12-ocxt-2016

    <OperationContract()>
    Function GetPtnClsDtlByIpOpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal companycode As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IPNo As Long) As clsPtnVstPtnClsDtl          'pragya : 14-ocxt-2016

    <OperationContract()>
    Function GetArCdByIpOpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal companycode As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IPNo As Long) As Integer       'pragya : 14-ocxt-2016

    <OperationContract()>
    Function GetCodeDeCodeList(ByRef strErrMsg As List(Of String),
                                                 ByRef chrErrFlg As Char,
                                                 ByVal cocd As String,
                                                 ByVal div As Integer,
                                                 ByVal loc As Integer, ByVal typ As EnumCodeDecode
                                                ) As List(Of clsCodeDecode)         'pragya : 14-ocxt-2016
    <OperationContract()>
    Function GetFctAptOtDocList(ByRef strErrMsg As List(Of String),
                                            ByRef chrErrFlg As Char,
                                            ByVal companycode As String,
                                            ByVal div As Integer,
                                            ByVal loc As Integer,
                                            ByVal DocCd As Integer) As clsOtDocDtls      'pragya : 14-ocxt-2016

    <OperationContract()>
    Function GetLstOtDocDtlsByApptNoIpNo(ByRef strErrMsg As List(Of String),
                                                ByRef chrErrFlg As Char,
                                                    ByVal COCd As String,
                                                    ByVal Div As Integer,
                                                    ByVal Loc As Integer,
                                                    ByVal FctCd As Integer,
                                                    ByVal FctCatCd As Integer,
                                                    ByVal FctMainCd As Integer,
                                                    ByVal ApptNo As Integer,
                                                    ByVal PtnNo As Long,
                                                    ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of clsOtDocDtls)   'pragya : 15-ocxt-2016

    <OperationContract()>
    Function GetLstOtSrvDtlsByApptNoIpNo(ByRef strErrMsg As List(Of String),
                                                ByRef chrErrFlg As Char,
                                                ByVal COCd As String,
                                                ByVal Div As Integer,
                                                ByVal Loc As Integer,
                                                ByVal FctCd As Integer,
                                                ByVal FctCatCd As Integer,
                                                ByVal FctMainCd As Integer,
                                                ByVal ApptNo As Integer,
                                                ByVal PtnNo As Long,
                                                ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of ClsOtSrvLstDtls)                'PRGAYA : 31-OCT-2016

    <OperationContract()>
    Function GetPtnNoByIpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal companycode As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As Long                  'pragya : 02-nov-2016



    <OperationContract()>
    Function GetOtEmpIdLst(ByRef strErrMsg As List(Of String),
                                   ByRef chrErrFlg As Char,
                                   ByVal cocd As String,
                                   ByVal div As Integer,
                                   ByVal loc As Integer) As List(Of clsAttPayDbEmpId)  ' pragya : 01-dec-2016

    <OperationContract()>
    Function GetLstOtEmpDtlsByApptNoIpNo(ByRef strErrMsg As List(Of String),
                                            ByRef chrErrFlg As Char,
                                            ByVal COCd As String,
                                            ByVal Div As Integer,
                                            ByVal Loc As Integer,
                                            ByVal FctCd As Integer,
                                            ByVal FctCatCd As Integer,
                                            ByVal FctMainCd As Integer,
                                            ByVal ApptNo As Integer,
                                            ByVal PtnNo As Long,
                                            ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of clsFctAptOtEmpDtls)  ' pragya : 01-dec-2016

    <OperationContract()>
    Function GetOtEmpDtlsByEmpNo(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal companycode As String,
                                                      ByVal div As Integer,
                                                      ByVal loc As Integer,
                                                      ByVal EmpId As String) As clsAttPayDbEmpId  ' pragya : 01-dec-2016




#Region "GET ACTIVE OT DETAILS" 'RasikV 20170130
    <OperationContract()>
    Function GetFCTMstLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer) As List(Of clsFCTMstHelp)
#End Region


    '<OperationContract()>
    'Function PopulatePager(ByRef strErrMsg As List(Of String),
    '                                              ByRef chrErrFlg As Char,
    '                                              ByVal recordCount As Integer, ByVal currentPage As Integer, ByVal DispNum As Integer, ByVal GridType As Char, ByVal Repeater As List(Of clsPaging), ByVal ItemCd As String, ByRef ReturnPageIndex As Integer,
    '                                              ByVal PageSize As Integer) As List(Of clsPaging)


#Region "Print"     'Aarti 21 May 2018
    <OperationContract()>
    Function GetNetIdParamDetailsNew(ByRef strErrMsg As List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal companycode As String,
                                      ByVal div As Integer,
                                      ByVal loc As Integer,
                                      ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal NetId As Integer) As List(Of clsNetIDParam)

    <OperationContract()>
    Function GetPrntRptViewerRule8013(ByRef strErrMsg As List(Of String),
                                  ByRef chrErrFlg As Char,
                                  ByVal cocd As String,
                                  ByVal div As Integer,
                                  ByVal loc As Integer) As Boolean
#End Region


    <OperationContract()>
    Function GetOtSchedulingSmsList(ByRef strErrMsg As List(Of String),
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
                                           ByVal ObjFctAptOT As clsFCTAPTOT) As List(Of clsSMSMstDetails)
#Region "Get Info From rule Master by rule ID"
    <OperationContract()>
    Function GetRuleMstDtls(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                     ByVal RuleId As Integer) As clsRuleMaster      'Aarti 10 Oct 2020

#End Region


    <OperationContract()>
    Function PatientHelpListMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, cocd As String, div As Integer, loc As Integer, FirstNm As String, MiddleNm As String, LastNm As String, AdditionalCriteria As String, Pageindex As Integer, PageSize As Integer, AdharNo As String, PanNo As String, Address As String) As List(Of clsPatientHelp)

    <OperationContract()>
    Function PatientHelpMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, cocd As String, div As Integer, loc As Integer, FirstNm As String, MiddleNm As String, LastNm As String, AdditionalCriteria As String, Pageindex As Integer, PageSize As Integer, AdharNo As String, PanNo As String, Address As String, FathersName As String) As List(Of clsPatientHelp)

    <OperationContract()>
    Function PopulatePager(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, recordCount As Integer, currentPage As Integer, DispNum As Integer, GridType As Char, Repeater As List(Of clsPaging), ItemCd As String, ByRef ReturnPageIndex As Integer, PageSize As Integer) As List(Of clsPaging)

    <OperationContract()>
    Function GetPatientDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal pptnno As Long) As PatientDetails

    <OperationContract()>
    Function setproperties(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                         ByRef chrErrFlg As Char,
                                                         ByVal CoCd As String,
                                                         ByVal Div As Integer,
                                                         ByVal Loc As Integer, ByVal objRuleMst As clsRuleMaster) As List(Of ClsPtnDtlsSetup)
    <OperationContract()>
    Function GetIpWiseOtAppList(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String,
                                            ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long, ByVal ToDate As Date) As List(Of ClsOtIndirectBookingLst)

    <OperationContract()>
    Function GetOpToIpConvertPtnListForOt(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String,
                                           ByVal div As Integer, ByVal loc As Integer,
                                           ByVal IpNo As Long, ByVal ToDate As Date) As List(Of clsConvertOpToIp)
    <OperationContract()>
    Function ConvertOpToIp(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char,
                               ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer,
                               ByVal AptNo As Integer, ByVal IPNO As Long, ByVal PtnNo As Long) As Boolean

#Region "QUICK PATIENT REGISTRATION FUNCTIONS Added By AARTI 06 JAN 2020"
    <OperationContract()>
    Function Salutation(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, cocd As String, pdiv As Integer, ploc As Integer) As List(Of clsCodeDecode)

    <OperationContract()>
    Function GetPtnType(ByRef strErrMsg As List(Of String),
                                                            ByRef chrErrFlg As Char,
                                                            ByVal Cocd As String,
                                                            ByVal Div As Integer,
                                                            ByVal Loc As Integer,
                                                           ByVal pPtnBillTyp As Integer) As List(Of clsPtnTypeMst)
    <OperationContract()>
    Function GetPtnTypByUser(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, companycode As String, div As Integer, loc As Integer, userid As String, PtnNo As Long) As List(Of clsPtnTypeMst)

#End Region


#Region "Get Patient list by Mobile No."
    <OperationContract()>
    Function GetPtnDtlByMobNoDetails(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal MobNo As String) As List(Of clsPtnBasicInfo)
#End Region
    <OperationContract()>
    Function Nationality(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)


#Region "Get State List with Country Name from state master table "
    <OperationContract()>
    Function GetStateLst(ByRef strErrMsg As List(Of String),
                                                            ByRef chrErrFlg As Char,
                                                            ByVal Cocd As String,
                                                            ByVal Div As Integer,
                                                            ByVal Loc As Integer,
                                                           ByVal statecd As Integer, ByVal stateName As String) As List(Of StateMaster)
#End Region

#Region "Get City List with state Name from city master table "
    <OperationContract()>
    Function GetCityLst(ByRef strErrMsg As List(Of String),
                                                            ByRef chrErrFlg As Char,
                                                            ByVal Cocd As String,
                                                            ByVal Div As Integer,
                                                            ByVal Loc As Integer,
                                                           ByVal Statecd As Integer, ByVal citycd As Integer, ByVal cityname As String) As List(Of StateMaster)
    <OperationContract()>
    Function SaveConfirmEnqPtn(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByRef SessionState As Integer, ByRef PtnNo As Long, CoCd As String, Div As Integer, Loc As Integer, ModCd As Integer, SubModCd As Integer, SessionId As Long, UsrId As String, UsrDtTm As Date, objBkdDtls As clsPatient) As Boolean

    <OperationContract()>
    Function GetModFncLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer, ModCd As Integer, SubModCd As Integer, FuncID As Integer, UsrID As String) As List(Of clsUserModuleFunction)
#End Region


    <OperationContract()>
    Function GetPtnTypListByUser(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
          ByVal Div As Integer, ByVal Loc As Integer, ByVal UserID As String) As List(Of ClsUserPtnTypMst)


    <OperationContract()>
    Function GetArMstDetailsByArCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal ArCd As Integer) As clsArMst



    <OperationContract()>
    Function GetOTDtlsByFilter(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
          ByVal Div As Integer, ByVal Loc As Integer, ByVal FrmDt As Date,
                                                          ByVal ToDt As Date,
                                                          ByVal Flg As Char,
                                                          ByVal ApptSts As Int16, ByVal ArCd As String, ByVal OTCd As Integer, ByVal PtnType As Integer, ByVal chkDt As Boolean) As List(Of clsFCTAPTOT)


    <OperationContract()>
    Function GetCreditCoListSts(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer) As List(Of clsArMstCdDcd)
    'added by shivkumar 15/11/2021
    <OperationContract()>
    Function GetUserDetByCD(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal COCd As String, ByVal Div As Integer,
                                      ByVal Loc As Integer, ByVal UserId As String) As clsUserDet
    'default value set maharashtra
    <OperationContract()>
    Function GetIsBaseStateMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
              ByVal Div As Integer, ByVal Loc As Integer, IsBase As Boolean) As StateMaster
    '
    'default value set mumbai

    <OperationContract()>
    Function GetIsBaseCityMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer, IsBase As Boolean) As CityMaster
    <OperationContract()>
    Function SaveOfficePermissionChk(ByRef StrErrMsg As List(Of String), ByRef ChrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal obj As ClsOtIndirectBooking) As Boolean  'Nutan 12 Jan 2022
    <OperationContract()>
    Function GetModFnDetails(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer, ModCd As Integer, SubModCd As Integer) As List(Of clsUserModuleFunction) 'Nutan 24 Jan 2022

    <OperationContract()>
    Function GetOTDataForDashBrdSch(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, companycode As String, div As Integer, loc As Integer, FrmDt As Date, ToDt As Date, Flg As Char, ApptSts As Short, ArCd As String, OTCd As Integer, PtnType As Integer, chkDt As Boolean) As List(Of clsFCTAPTOT)

    <OperationContract()>
    Function GetVarDef(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char,
                                  pcompanycode As String, pdiv As Integer,
                                  ploc As Integer,
                                  pUsrId As String) As List(Of clsPtnTypeMst)


End Interface

