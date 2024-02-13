
Imports System.Runtime.Serialization
Imports SofCommon
Imports System
Imports System.Collections.Generic
Imports PostVoucher

Namespace PatientVisitAndBilInsTrn


#Region "CLASS : clsIpPtnQryDtls"
    'Pragya : 31-Aug-2017
    <DataContract()>
    Public Class clsIpPtnQryDtls
        Inherits clsIpPtnVst
        <DataMember()>
        Public Property CasetypeCd As Integer
        <DataMember()>
        Public Property SubCaseTypCd As Integer
        <DataMember()>
        Public Property SubCaseTypDesc As String
        <DataMember()>
        Public Property CaseManagerCd As Integer
        <DataMember()>
        Public Property CaseManagerDesc As String
        <DataMember()>
        Public Property CoordinatorCd As Integer
        <DataMember()>
        Public Property CoordinatorDesc As String
        <DataMember()>
        Public Property AdmissionTm As DateTime  ''Amol 2018-05-09
        <DataMember()>
        Public Property DiscahrgeTm As DateTime  ''Amol 2018-05-09


    End Class
#End Region
    <DataContract()>
    Public Class clsIpPatientVisit
        '<DataMember()>
        'Public Property CompanyCode() As String
        '<DataMember()>
        'Public Property DivisionCode() As Integer
        '<DataMember()>
        'Public Property LocationCode() As Integer
        '<DataMember()>
        'Public Property IpNo() As Integer
        <DataMember()>
        Public Property IpNo() As Long  'anamika 20160906
        '<DataMember()>
        'Public Property RsvNo() As Integer
        <DataMember()>
        Public Property RsvNo() As Long  'anamika 20160906
        '<DataMember()>
        'Public Property PatientNo() As Integer
        <DataMember()>
        Public Property PatientNo() As Long 'anamika 20160906
        <DataMember()>
        Public Property LocalAdd1() As String
        <DataMember()>
        Public Property LocalAdd2() As String
        <DataMember()>
        Public Property LocalAdd3() As String 'anamika 20150703
        <DataMember()>
        Public Property LocalCity() As Integer  'anamika 20150703'changed datatype from string to integer
        <DataMember()>
        Public Property LocalCountry() As Integer  'anamika 20150703'changed datatype from string to integer
        <DataMember()>
        Public Property LocalState() As Integer 'anamika 20150703
        <DataMember()>
        Public Property LocalPin() As String
        <DataMember()>
        Public Property LocalTel() As String
        <DataMember()>
        Public Property NewBrthFlg() As String
        <DataMember()>
        Public Property AdmDgnosCd() As Integer
        <DataMember()>
        Public Property AdmDgnosDesc() As String
        <DataMember()>
        Public Property DschgDgnosCd() As Integer
        <DataMember()>
        Public Property DschgDgnosDesc() As String
        <DataMember()>
        Public Property CsltyClncCd() As Integer
        <DataMember()>
        Public Property CsltyVstNo() As Integer
        <DataMember()>
        Public Property MedCseFlg() As String
        <DataMember()>
        Public Property BedNo() As String
        <DataMember()>
        Public Property WingCd() As Integer
        <DataMember()>
        Public Property WardCd() As Integer
        <DataMember()>
        Public Property BedTypCd() As Integer
        <DataMember()>
        Public Property PtnSrcCd() As Integer
        <DataMember()>
        Public Property CseTypCd() As Integer
        <DataMember()>
        Public Property DocCd2() As Integer 'mayur 20140402
        <DataMember()>
        Public Property DocCd() As Integer
        <DataMember()>
        Public Property AddDocCd1() As Integer
        <DataMember()>
        Public Property AddDocCd2() As Integer
        <DataMember()>
        Public Property ExptdNoDays() As Integer
        <DataMember()>
        Public Property PtnClsCd() As Integer
        <DataMember()>
        Public Property RsdFlg() As String
        <DataMember()>
        Public Property CnfInfFlg() As String
        <DataMember()>
        Public Property CrtClFlg() As String
        <DataMember()>
        Public Property BedTrnsfrNo() As Integer
        <DataMember()>
        Public Property ClsTrnsfrNo() As Integer
        <DataMember()>
        Public Property DocChngNo() As Integer
        <DataMember()>
        Public Property BedTrnsfrReqNo() As Integer
        <DataMember()>
        Public Property ClsTrnsfrReqNo() As Integer
        <DataMember()>
        Public Property DsChgAdvNo() As Integer
        <DataMember()>
        Public Property DsChgNo() As Integer
        <DataMember()>
        Public Property AdmCnclnNo() As Integer
        <DataMember()>
        Public Property AdmStsCd() As Integer
        <DataMember()>
        Public Property RsvStsCd() As Integer
        <DataMember()>
        Public Property AdmDt() As Date
        <DataMember()>
        Public Property DsChgDt() As Date
        <DataMember()>
        Public Property AdmTm() As Date
        <DataMember()>
        Public Property DonCd() As Integer
        <DataMember()>
        Public Property Rmrk() As String
        <DataMember()>
        Public Property DsChgTm() As Date
        <DataMember()>
        Public Property AdmCrtDt() As Date
        <DataMember()>
        Public Property AdmCrtTm() As Date
        <DataMember()>
        Public Property AdmUsrId() As String
        <DataMember()>
        Public Property BlockBedNo() As String
        <DataMember()>
        Public Property AutoPstDt() As Date
        <DataMember()>
        Public Property NoFol() As Integer
        <DataMember()>
        Public Property FolAmt() As Double
        <DataMember()>
        Public Property FolBal() As Double
        <DataMember()>
        Public Property DueDeptAmt() As Double
        <DataMember()>
        Public Property AthrtyCd() As Integer
        <DataMember()>
        Public Property DepAmt() As Double
        <DataMember()>
        Public Property DepBal() As Double
        <DataMember()>
        Public Property UpdtTrnCd() As String
        <DataMember()>
        Public Property UpdtDt() As Date
        <DataMember()>
        Public Property UpdtTm() As Date
        <DataMember()>
        Public Property UpdtUsrId() As String
        <DataMember()>
        Public Property CreateDt() As Date
        <DataMember()>
        Public Property CreateTm() As Date
        <DataMember()>
        Public Property CreateUsrId() As String
        <DataMember()>
        Public Property No() As Integer
        <DataMember()>
        Public Property ChiefComplaints() As String
        <DataMember()>
        Public Property LocalVillageCd() As Integer
        <DataMember()>
        Public Property RegionCd() As Integer
        <DataMember()>
        Public Property LocalDistrictCd() As Integer
        <DataMember()>
        Public Property PrefCls() As Integer
        <DataMember()>
        Public Property ExpectedDischrgeDate() As Date
        <DataMember()>
        Public Property CseTypDCd() As String
        <DataMember()>
        Public Property BedTypdCd() As String
        <DataMember()>
        Public Property WingdCd() As String
        <DataMember()>
        Public Property WarddCd() As String
        <DataMember()>
        Public Property ExptdNoDay() As Integer
        <DataMember()>
        Public Property LOS() As Integer
        <DataMember()>
        Public Property ADVSTSCD() As Integer
        <DataMember()>
        Public Property DocName() As String
        <DataMember()>
        Public Property AdmittedFlg() As String
        <DataMember()>
        Public Property BedTransno() As Integer 'mayur 20130827
        <DataMember()>
        Public Property ClsTransno() As Integer 'mayur 20130827
        <DataMember()>
        Public Property ptnname() As String 'mayur 20130827
        <DataMember()>
        Public Property RMK() As String 'mayur 20130913
        <DataMember()>
        Public Property CNCLRMK() As String 'mayur 20130913
        <DataMember()>
        Public Property PtnClsDcd() As String 'mayur 20131023
        <DataMember()>
        Public Property Ptngender() As String 'mayur 20131023
        <DataMember()>
        Public Property DschrgStsCd() As Integer 'mayur 20131024 Dropdown value
        <DataMember()>
        Public Property RoomNo() As String  'mayur 20140219
        <DataMember()>
        Public Property Age() As String  'mayur 20140219
        <DataMember()>
        Public Property BlockedBedRmno() As String  'mayur 20140219
        <DataMember()>
        Public Property EmailAddrs() As String 'anamika 20150703
        <DataMember()>
        Public Property EligibleCls() As Integer 'anamika 20160730
        <DataMember()>
        Public Property ConsentOfDataShare() As Boolean 'anamika 20160730
        <DataMember()>
        Public Property DepositRemark() As String 'anamika 20160730
        <DataMember()>
        Public Property CampCd() As Integer 'anamika 20160730
        <DataMember()>
        Public Property MobileNumber2() As String  'anamika 20160730
        <DataMember()>
        Public Property WhatsAppNo() As String 'anamika 20160730
        <DataMember()>
        Public Property CredalNo() As String   'PRAGYA 20160825
        <DataMember()>
        Public Property IsCredalAttached() As Char 'PRAGYA 20160825
        <DataMember()>
        Public Property IsPtnBlackListed() As Boolean 'RasikV 20160917
        <DataMember()>
        Public Property ArCd() As Integer   'RasikV 20161007
        <DataMember()>
        Public Property ArDcd As String 'RasikV 20161007
        <DataMember()>
        Public Property DefaultDietType As Integer 'PRAGYA : 06-FEB-2017
        <DataMember()>
        Public Property PtnRefByTyp As Integer 'APARNA : 29 MAR 2017
        <DataMember()>
        Public Property PtnRefByCd As Integer 'APARNA : 29 MAR 2017
        <DataMember()>
        Public Property CaseManagerCd As Integer 'APARNA : 26 MAY 2017
        <DataMember()>
        Public Property CoordinatorCd As Integer 'APARNA : 26 MAY 2017
        <DataMember()>
        Public Property SubCseTypCd As Integer 'anamika 20170714
        <DataMember()>
        Public Property folStsCd As Integer 'Amol Margaj 20170813
        <DataMember()>
        Public Property BlockedRoomDesc() As String  'aarti 07 May 2018
        <DataMember()>
        Public Property RoomDesc() As String  'aarti 07 May 2018
        <DataMember()>
        Public Property IsIsolation As Boolean ''Amol 10-11-2020 JSK001-147272	

#Region "GetIpPatientByIPNO"




        'mayur 20140206
        ''' <summary>
        ''' Function to select all data from table ip_ptn_vst for Admitted patient as per IPNO
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="IPNO"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetIpPtnWithDschrgAdvByIp(ByRef strErrMsg As List(Of String),
                                                  ByRef chrErrFlg As Char,
                                                  ByVal companycode As String,
                                                  ByVal div As Integer,
                                                  ByVal loc As Integer, ByVal IPNO As Long
                                                 ) As clsIpPatientVisit
            GetIpPtnWithDschrgAdvByIp = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST006(companycode, div, loc, IPNO))
                Dim obj As New clsIpPatientVisit
                If dr1.hasrows Then

                    While dr1.Read()

                        'obj.CompanyCode = companycode 'anamika 20160906
                        'obj.DivisionCode = div
                        'obj.LocationCode = loc
                        obj.BedNo = dr1.Item("bed_no")
                        obj.ExptdNoDay = dr1.Item("exptd_no_day")
                        obj.LOS = dr1.Item("LOS")
                        obj.IpNo = dr1.Item("ip_no")
                        obj.PatientNo = dr1.Item("ptn_no")
                        obj.WingdCd = dr1.Item("wing_dcd")
                        obj.WardCd = dr1.Item("wrd_cd")  'pragya : 24-may-2018
                        obj.WarddCd = dr1.Item("wrd_dcd")
                        obj.RoomNo = dr1.Item("rm_no")
                        obj.BedTypCd = dr1.Item("bed_typ_cd") 'pragya : 24-may-2018
                        obj.BedTypdCd = dr1.Item("bed_typ_dcd")
                        obj.CseTypCd = dr1.Item("cse_typ_cd") 'pragya : 24-may-2018
                        obj.CseTypDCd = dr1.Item("cse_typ_dcd")
                        obj.DocCd = dr1.Item("doc_cd")
                        obj.AdmDt = IIf(IsDBNull(dr1.Item("adm_dt")), Nothing, dr1.Item("adm_dt"))
                        obj.BedTrnsfrReqNo = dr1.Item("bed_trnsfr_req_no")
                        obj.ExpectedDischrgeDate = dr1.Item("EXPECTED_DISCHARGE_DATE")
                        obj.ADVSTSCD = dr1.Item("adv_sts_cd")
                        obj.DocName = dr1.Item("docname")
                        obj.AdmittedFlg = dr1.Item("admittedflg")
                        obj.ptnname = dr1.Item("ptnname")
                        obj.RMK = dr1.item("rmk")
                        obj.CNCLRMK = dr1.item("cnclrmk")
                        obj.PtnClsDcd = dr1.item("ptnclassDcd")
                        obj.Ptngender = dr1.item("ptngender")
                        obj.PtnClsCd = dr1.item("PtnClsCd")
                        obj.DschrgStsCd = dr1.item("dschg_sts_cd")
                        obj.Age = dr1.item("Age")
                        obj.PtnSrcCd = dr1.Item("ptn_src_cd") 'mayur 20150804
                        obj.WingCd = dr1.Item("wing_cd") 'mayur 20160616
                        '    objList.Add(obj)
                    End While
                    GetIpPtnWithDschrgAdvByIp = obj
                End If
                dr1.close()

                ofactory = Nothing
            Catch ex As Exception
                GetIpPtnWithDschrgAdvByIp = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
            Return GetIpPtnWithDschrgAdvByIp
        End Function

        ''' <summary>
        ''' stored procedure to select all data from table ip_ptn_vst for Admitted patient as per IPNO
        ''' </summary>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="IPNO"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SPSELIPPTNVST006(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IPNO As Long) As DBRequest
            'Shared Function SPSELIPPTNVST006(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IPNO As Integer) As DBRequest --anamika 20160906
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter

            With oRequest
                .Command = "[SPSELIPPTNVST006]"
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
                oParam.ParamName = "pIPNO"
                oParam.ParamValue = IPNO
                .Parameters.Add(oParam)

                .CommandType = CommandType.StoredProcedure
            End With
            Return oRequest
        End Function
        'mayur 20140206
#End Region

#Region "GetInPatient: Retrieves data from ip_ptn_vst for particular ip_no"

        ''mayur 20140402
        ''' <summary>
        ''' Get ip patient details 
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="ipno"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetInPatient(ByRef strErrMsg As List(Of String),
                                                          ByRef chrErrFlg As Char,
                                                          ByVal companycode As String,
                                                          ByVal div As Integer,
                                                          ByVal loc As Integer,
                                                          ByVal ipno As Long) As clsIpPatientVisit

            GetInPatient = Nothing
            Try

                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELINPTNMST001(companycode, div, loc, ipno))
                Dim objPatient As clsIpPatientVisit = Nothing
                If dr1.hasrows Then
                    dr1.read()
                    objPatient = New clsIpPatientVisit
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.ptnname = dr1.Item("PatientFullName")
                    objPatient.Ptngender = dr1.Item("Gender")
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))
                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.RoomNo = dr1.Item("Roomno")
                    objPatient.BedNo = dr1.item("Bedno")
                    objPatient.PtnClsDcd = dr1.item("PatientClassCodeDesc")
                    objPatient.AdmStsCd = dr1.item("AdmissionStatusCode")
                    objPatient.AdmDt = IIf(IsDBNull(dr1.item("AdmissionDate")), Nothing, dr1.item("AdmissionDate"))
                    objPatient.DocCd = dr1.Item("DocCd")
                    objPatient.DocCd2 = dr1.Item("DOCCD2")
                    objPatient.AddDocCd1 = dr1.Item("ADDDCT1")
                    objPatient.AddDocCd2 = dr1.Item("ADDDCT2")
                    objPatient.IsPtnBlackListed = IIf(dr1.item("IsPtnBlackListed") = 0, False, True) 'RasikV 20160917
                    objPatient.ArCd = dr1.item("ArCd")  'RasikV 20161007
                    objPatient.ArDcd = dr1.item("ArDcd") 'RasikV 20161007
                    objPatient.PtnClsCd = dr1.item("PatientClassCode") 'pragya : 29-jan-2017 
                    objPatient.DsChgDt = IIf(IsDBNull(dr1.item("DischargeDate")), Nothing, dr1.item("DischargeDate"))   ' Amol Margaj 01-07-2017 
                    objPatient.DocName = IIf(IsDBNull(dr1.Item("DocFullName")), "", dr1.Item("DocFullName"))  ' Amol Margaj 01-07-2017  
                    objPatient.folStsCd = IIf(IsDBNull(dr1.Item("fol_sts_cd")), 0, dr1.Item("fol_sts_cd"))  ' Aarti 10 Oct 2020
                    objPatient.IsIsolation = IIf(IsDBNull(dr1.item("IsIsolation")), Nothing, dr1.item("IsIsolation")) ''Amol 10-11-2020 JSK001-147272	

                End If
                dr1.close()
                GetInPatient = objPatient
                ofactory = Nothing
            Catch ex As Exception
                GetInPatient = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
        End Function
        ''mayur 20140402
        ''mayur 20140402

        ''' <summary>
        '''  adds paramters to store procedure SPSELINPTNMST001
        ''' </summary>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SPSELINPTNMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ipno As Long) As DBRequest
            'Shared Function SPSELINPTNMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ipno As Integer) As DBRequest 'anamika 20160906
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELINPTNMST001]"

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
                oParam.ParamName = "pipno"
                oParam.ParamValue = ipno
                .Parameters.Add(oParam)

                .CommandType = CommandType.StoredProcedure



            End With

            Return oRequest
        End Function
        ''mayur 20140402
#End Region

#Region "GetBlockBedNo: (get block bed_no)"
        'mayur 20131021
        ''' <summary>
        ''' TO get block bed no by passing bed ipno from ip_ptn_vst table
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="pcompanycode"></param>
        ''' <param name="pdiv"></param>
        ''' <param name="ploc"></param>
        ''' <param name="ipno"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetBlockBedNo(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal pcompanycode As String,
                                      ByVal pdiv As Integer,
                                      ByVal ploc As Integer, ByVal ipno As Long) As String

            Dim ofactory As DBFactory
            'Dim oParam As DBRequest.Parameter
            GetBlockBedNo = 0
            ofactory = New DBFactory

            Dim OutBedNo As Integer = 0
            Try

                Dim ds As DataSet = ofactory.ExecuteDataSet(FnGetBlockBedNo(ipno))
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        GetBlockBedNo = ds.Tables(0).Rows(i).Item(0)
                    Next
                End If
                ds.Dispose()


            Catch ex As Exception
                ofactory.RollBackExecution()
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                GetBlockBedNo = ""
                Return GetBlockBedNo
            End Try

        End Function


        ''' <summary>
        '''  Function to Return block bed no 
        ''' </summary>
        ''' <param name="ipno"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function FnGetBlockBedNo(ByVal ipno As Long) As DBRequest

            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "SELECT dbo.[FnGetBlockbedNo]('" & ipno & "')"
                .CommandType = CommandType.Text


            End With
            Return oRequest
        End Function
        'end mayur 20131021
#End Region



#Region "GetIpPatientVisitListByDoctor"
        'mayur 20130814
        ''' <summary>
        ''' Function which calls list of ip_ptn_vst table for Admitted patient as per doctor
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="dctcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetIpPatientVisitListByDoctor(ByRef strErrMsg As List(Of String),
                                                  ByRef chrErrFlg As Char,
                                                  ByVal companycode As String,
                                                  ByVal div As Integer,
                                                  ByVal loc As Integer, ByVal dctcode As Integer,
ByVal PatientStatus As Integer
                                                 ) As List(Of clsIpPatientVisit)
            GetIpPatientVisitListByDoctor = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST001(companycode, div, loc, dctcode, PatientStatus))
                Dim objList As List(Of clsIpPatientVisit) = Nothing
                If dr1.hasrows Then
                    objList = New List(Of clsIpPatientVisit)
                    While dr1.Read()
                        Dim obj As New clsIpPatientVisit
                        'obj.CompanyCode = companycode 'anamika 20160906
                        'obj.DivisionCode = div
                        'obj.LocationCode = loc
                        obj.BedNo = dr1.Item("bed_no")
                        obj.ExptdNoDay = dr1.Item("exptd_no_day")
                        obj.LOS = dr1.Item("LOS")
                        obj.IpNo = dr1.Item("ip_no")
                        obj.PatientNo = dr1.Item("ptn_no")
                        obj.WingdCd = dr1.Item("wing_dcd")
                        obj.WarddCd = dr1.Item("wrd_dcd")
                        obj.RoomNo = dr1.Item("rm_no")
                        obj.BedTypdCd = dr1.Item("bed_typ_dcd")
                        obj.CseTypDCd = dr1.Item("cse_typ_dcd")
                        obj.DocCd = dr1.Item("doc_cd")
                        obj.AdmDt = IIf(IsDBNull(dr1.Item("adm_dt")), Nothing, dr1.Item("adm_dt"))  'dr1.Item("adm_dt")
                        obj.BedTrnsfrReqNo = dr1.Item("bed_trnsfr_req_no")
                        obj.ExpectedDischrgeDate = dr1.Item("EXPECTED_DISCHARGE_DATE")
                        obj.ADVSTSCD = dr1.Item("adv_sts_cd")
                        obj.DocName = dr1.Item("docname") 'mayur 20130821
                        obj.AdmittedFlg = dr1.Item("admittedflg") 'mayur 20130822
                        obj.ptnname = dr1.Item("ptnname") 'mayur 20130830
                        obj.RMK = dr1.item("rmk") 'mayur 20130913
                        obj.CNCLRMK = dr1.item("cnclrmk") 'mayur 20130913
                        obj.PtnClsDcd = dr1.item("ptnclassDcd") 'mayur 20131023
                        obj.Ptngender = dr1.item("ptngender") 'mayur 20131023
                        obj.PtnClsCd = dr1.item("PtnClsCd") 'mayur 20131023
                        obj.DschrgStsCd = dr1.item("dschg_sts_cd") 'mayur 20131023 Dropdown value
                        obj.folStsCd = IIf(IsDBNull(dr1.Item("fol_sts_cd")), 0, dr1.Item("fol_sts_cd")) 'Amol Margaj 23/08/2017  for Restirct Doctor Order Entry
                        objList.Add(obj)
                    End While
                End If
                dr1.close()
                GetIpPatientVisitListByDoctor = objList
                ofactory = Nothing
            Catch ex As Exception
                GetIpPatientVisitListByDoctor = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
            Return GetIpPatientVisitListByDoctor
        End Function
        ''' <summary>
        ''' stored procedure to select all data from table ip_ptn_vst for Admitted patient as per doctor
        ''' </summary>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="dctcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SPSELIPPTNVST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal dctcode As Integer,
ByVal PatientStatus As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter

            With oRequest
                .Command = "[SPSELIPPTNVST001]"  'ip_ptn_vst  bed_typ_mst  bed_mst wing_mst  cse_typ_mst  doc_mst  cd_dcd  DSCHG_ADV  ptn_cls_mst   ptn_mst1
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
                oParam.ParamName = "pDOCCD"
                oParam.ParamValue = dctcode
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter 'amol 20170608
                oParam.ParamName = "pADMSTSCD"
                oParam.ParamValue = PatientStatus
                .Parameters.Add(oParam)

                .CommandType = CommandType.StoredProcedure
            End With
            Return oRequest
        End Function
        'mayur 20130814
#End Region


#Region "GetIpPatientVisitList"
        ''' <summary>
        ''' Function which calls list of ip_ptn_vst table
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetIpPatientVisitList(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer
                                                   ) As List(Of clsIpPatientVisit)
            GetIpPatientVisitList = Nothing
            Try

                Dim ofactory As New DBFactory

                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST(companycode, div, loc))
                Dim objList As List(Of clsIpPatientVisit) = Nothing
                If dr1.hasrows Then
                    objList = New List(Of clsIpPatientVisit)
                    While dr1.Read()
                        ' With dr1
                        Dim obj As New clsIpPatientVisit
                        'obj.CompanyCode = companycode  'anamika 20160906
                        'obj.DivisionCode = div
                        'obj.LocationCode = loc
                        obj.IpNo = dr1.Item("ip_no")
                        obj.RsvNo = dr1.Item("rsv_no")
                        obj.PatientNo = dr1.Item("ptn_no")
                        obj.LocalAdd1 = dr1.Item("lcl_addrs1")
                        obj.LocalAdd2 = dr1.Item("lcl_addrs2")
                        obj.LocalAdd3 = dr1.Item("lcl_addrs3") 'anamika 20150703
                        obj.LocalState = dr1.Item("lcl_state") 'anamika 20150703
                        obj.LocalCity = dr1.Item("lcl_city")
                        obj.LocalCountry = dr1.Item("lcl_cntry")
                        obj.LocalPin = dr1.Item("lcl_pin")
                        obj.LocalPin = dr1.Item("lcl_tel")
                        obj.NewBrthFlg = dr1.Item("new_brth_flg")


                        obj.AdmDgnosCd = dr1.Item("adm_dgnos_cd")
                        obj.AdmDgnosDesc = dr1.Item("adm_dgnos_desc")
                        obj.DschgDgnosCd = dr1.Item("dschg_dgnos_cd")
                        obj.DschgDgnosDesc = dr1.Item("dschg_dgnos_desc")
                        obj.CsltyClncCd = dr1.Item("cslty_clnc_cd")
                        obj.CsltyVstNo = dr1.Item("cslty_vst_no")
                        obj.MedCseFlg = dr1.Item("med_cse_flg")
                        obj.BedNo = dr1.Item("bed_no")
                        obj.WingCd = dr1.Item("wing_cd")

                        obj.WardCd = dr1.Item("wrd_cd")
                        obj.BedTypCd = dr1.Item("bed_typ_cd")
                        obj.PtnSrcCd = dr1.Item("ptn_src_cd")
                        obj.CseTypCd = dr1.Item("cse_typ_cd")
                        obj.DocCd = dr1.Item("doc_cd")
                        obj.AddDocCd1 = dr1.Item("add_doc_cd_1")
                        obj.AddDocCd2 = dr1.Item("add_doc_cd_2")
                        obj.ExptdNoDays = dr1.Item("exptd_no_day")


                        obj.PtnClsCd = dr1.Item("ptn_cls_cd")
                        obj.RsdFlg = dr1.Item("rsd_flg")
                        obj.CnfInfFlg = dr1.Item("cnf_inf_flg")
                        obj.CrtClFlg = dr1.Item("crtcl_flg")
                        obj.BedTrnsfrNo = dr1.Item("bed_trnsfr_no")
                        obj.ClsTrnsfrNo = dr1.Item("cls_trnsfr_no")
                        obj.DocChngNo = dr1.Item("doc_chng_no")
                        obj.BedTrnsfrReqNo = dr1.Item("bed_trnsfr_req_no")


                        obj.ClsTrnsfrReqNo = dr1.Item("cls_trnsfr_req_no")
                        obj.DsChgAdvNo = dr1.Item("dschg_adv_no")
                        obj.DsChgNo = dr1.Item("dschg_no")
                        obj.AdmCnclnNo = dr1.Item("adm_cncln_no")
                        obj.AdmStsCd = dr1.Item("adm_sts_cd")
                        obj.RsvStsCd = dr1.Item("rsv_sts_cd")
                        'obj.AdmDt = IIf(IsDBNull(dr1.Item("adm_dt")), Nothing, dr1.Item("adm_dt"))  'dr1.Item("adm_dt")

                        'obj.DsChgDt = IIf(IsDBNull(dr1.Item("dschg_dt")), Nothing, dr1.Item("dschg_dt")) ' dr1.Item("dschg_dt")
                        'obj.AdmTm = IIf(IsDBNull(dr1.Item("adm_tm")), Nothing, dr1.Item("adm_tm")) ' dr1.Item("adm_tm")

                        obj.AdmDt = IIf(IsDBNull(dr1.Item("adm_dt")), Date.MinValue, dr1.Item("adm_dt")) 'anamika 20171108

                        obj.DsChgDt = IIf(IsDBNull(dr1.Item("dschg_dt")), Date.MinValue, dr1.Item("dschg_dt")) 'anamika 20171108
                        obj.AdmTm = IIf(IsDBNull(dr1.Item("adm_tm")), Date.MinValue, dr1.Item("adm_tm")) 'anamika 20171108
                        obj.DonCd = dr1.Item("don_cd")
                        obj.Rmrk = dr1.Item("rmrk")
                        obj.DsChgTm = IIf(IsDBNull(dr1.Item("dschg_tm")), Date.MinValue, dr1.Item("dschg_tm")) ' dr1.Item("dschg_tm")


                        obj.AdmCrtDt = IIf(IsDBNull(dr1.Item("adm_crt_dt")), Date.MinValue, dr1.Item("adm_crt_dt"))
                        obj.AdmCrtTm = IIf(IsDBNull(dr1.Item("adm_crt_tm")), Date.MinValue, dr1.Item("adm_crt_tm")) ' dr1.Item("adm_crt_tm")
                        obj.AdmUsrId = dr1.Item("adm_usr_id")
                        obj.BlockBedNo = dr1.Item("block_bed_no")
                        obj.AutoPstDt = IIf(IsDBNull(dr1.Item("auto_pst_dt")), Date.MinValue, dr1.Item("auto_pst_dt")) 'dr1.Item("auto_pst_dt")
                        obj.NoFol = dr1.Item("no_fol")
                        obj.FolAmt = dr1.Item("fol_amt")
                        obj.FolBal = dr1.Item("fol_bal")
                        obj.DueDeptAmt = dr1.Item("due_dep_amt")
                        obj.AthrtyCd = dr1.Item("athrty_cd")
                        obj.DepAmt = dr1.Item("dep_amt")
                        obj.DepBal = dr1.Item("dep_bal")
                        obj.UpdtTrnCd = dr1.Item("updt_trn_cd")


                        obj.UpdtDt = IIf(IsDBNull(dr1.Item("updt_dt")), Date.MinValue, dr1.Item("updt_dt"))  'dr1.Item("updt_dt")
                        obj.UpdtTm = IIf(IsDBNull(dr1.Item("updt_tm")), Date.MinValue, dr1.Item("updt_tm")) ' dr1.Item("updt_tm")
                        obj.UpdtUsrId = dr1.Item("updt_usr_id")
                        obj.CreateDt = IIf(IsDBNull(dr1.Item("crt_dt")), Date.MinValue, dr1.Item("crt_dt"))  'dr1.Item("crt_dt")
                        obj.CreateTm = IIf(IsDBNull(dr1.Item("crt_tm")), Date.MinValue, dr1.Item("crt_tm"))  ' dr1.Item("crt_tm")
                        obj.CreateUsrId = dr1.Item("crt_usr_id")

                        obj.No = dr1.Item("no")
                        obj.ChiefComplaints = dr1.Item("chief_complaints")
                        obj.LocalVillageCd = dr1.Item("lclvillagecd")
                        obj.RegionCd = dr1.Item("regioncd")
                        obj.LocalDistrictCd = dr1.Item("lcldistrictcd")
                        obj.PrefCls = dr1.Item("pref_cls")


                        objList.Add(obj)
                        'End With
                    End While
                End If
                dr1.close()
                GetIpPatientVisitList = objList

                ofactory = Nothing

            Catch ex As Exception
                GetIpPatientVisitList = Nothing

                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try

            Return GetIpPatientVisitList
        End Function
        ''' <summary>
        ''' stored procedure to select all data from table ip_ptn_vst
        ''' </summary>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SPSELIPPTNVST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELIPPTNVST]"
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

                .CommandType = CommandType.StoredProcedure



            End With

            Return oRequest
        End Function


#End Region



#Region "GetIpPatientVisitByIpNo"
        'anamika 20131106
        ''' <summary>
        ''' Select specific patient record  (Parameters:  @pIpNo)  
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="IpNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetIpPatientVisitByIpNo(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer,
                                                 ByVal IpNo As Long) As clsIpPatientVisit
            GetIpPatientVisitByIpNo = Nothing
            Try

                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST003(companycode, div, loc, IpNo))
                Dim obj As New clsIpPatientVisit
                If dr1.hasrows Then
                    While dr1.Read()

                        obj.IpNo = dr1.Item("ip_no")
                        obj.RsvNo = dr1.Item("rsv_no")
                        obj.PatientNo = dr1.Item("ptn_no")
                        obj.LocalAdd1 = dr1.Item("lcl_addrs1")
                        obj.LocalAdd2 = dr1.Item("lcl_addrs2")
                        obj.LocalAdd3 = dr1.Item("lcl_addrs3") 'anamika 20150703
                        obj.LocalState = dr1.Item("lcl_state") 'anamika 20150703
                        obj.LocalCity = dr1.Item("lcl_city")
                        obj.LocalCountry = dr1.Item("lcl_cntry")

                        obj.LocalPin = dr1.Item("lcl_pin")
                        obj.LocalPin = dr1.Item("lcl_tel")
                        obj.NewBrthFlg = dr1.Item("new_brth_flg")


                        obj.AdmDgnosCd = dr1.Item("adm_dgnos_cd")
                        obj.AdmDgnosDesc = dr1.Item("adm_dgnos_desc")
                        obj.DschgDgnosCd = dr1.Item("dschg_dgnos_cd")
                        obj.DschgDgnosDesc = dr1.Item("dschg_dgnos_desc")
                        obj.CsltyClncCd = dr1.Item("cslty_clnc_cd")
                        obj.CsltyVstNo = dr1.Item("cslty_vst_no")
                        obj.MedCseFlg = dr1.Item("med_cse_flg")
                        obj.BedNo = dr1.Item("bed_no")
                        obj.WingCd = dr1.Item("wing_cd")

                        obj.WardCd = dr1.Item("wrd_cd")
                        obj.BedTypCd = dr1.Item("bed_typ_cd")
                        obj.PtnSrcCd = dr1.Item("ptn_src_cd")
                        obj.CseTypCd = dr1.Item("cse_typ_cd")
                        obj.DocCd = dr1.Item("doc_cd")
                        obj.AddDocCd1 = dr1.Item("add_doc_cd_1")
                        obj.AddDocCd2 = dr1.Item("add_doc_cd_2")
                        obj.ExptdNoDays = dr1.Item("exptd_no_day")


                        obj.PtnClsCd = dr1.Item("ptn_cls_cd")
                        obj.RsdFlg = dr1.Item("rsd_flg")
                        obj.CnfInfFlg = dr1.Item("cnf_inf_flg")
                        obj.CrtClFlg = dr1.Item("crtcl_flg")
                        obj.BedTrnsfrNo = dr1.Item("bed_trnsfr_no")
                        obj.ClsTrnsfrNo = dr1.Item("cls_trnsfr_no")
                        obj.DocChngNo = dr1.Item("doc_chng_no")
                        obj.BedTrnsfrReqNo = dr1.Item("bed_trnsfr_req_no")


                        obj.ClsTrnsfrReqNo = dr1.Item("cls_trnsfr_req_no")
                        obj.DsChgAdvNo = dr1.Item("dschg_adv_no")
                        obj.DsChgNo = dr1.Item("dschg_no")
                        obj.AdmCnclnNo = dr1.Item("adm_cncln_no")
                        obj.AdmStsCd = dr1.Item("adm_sts_cd")
                        obj.RsvStsCd = dr1.Item("rsv_sts_cd")
                        obj.AdmDt = IIf(IsDBNull(dr1.Item("adm_dt")), Nothing, dr1.Item("adm_dt"))  'dr1.Item("adm_dt")

                        obj.DsChgDt = IIf(IsDBNull(dr1.Item("dschg_dt")), Nothing, dr1.Item("dschg_dt")) ' dr1.Item("dschg_dt")
                        obj.AdmTm = IIf(IsDBNull(dr1.Item("adm_tm")), Nothing, dr1.Item("adm_tm")) ' dr1.Item("adm_tm")
                        obj.DonCd = dr1.Item("don_cd")
                        obj.Rmrk = dr1.Item("rmrk")
                        obj.DsChgTm = IIf(IsDBNull(dr1.Item("dschg_tm")), Nothing, dr1.Item("dschg_tm")) ' dr1.Item("dschg_tm")


                        obj.AdmCrtDt = IIf(IsDBNull(dr1.Item("adm_crt_dt")), Nothing, dr1.Item("adm_crt_dt"))
                        obj.AdmCrtTm = IIf(IsDBNull(dr1.Item("adm_crt_tm")), Nothing, dr1.Item("adm_crt_tm")) ' dr1.Item("adm_crt_tm")
                        obj.AdmUsrId = dr1.Item("adm_usr_id")
                        obj.BlockBedNo = dr1.Item("block_bed_no")
                        obj.AutoPstDt = IIf(IsDBNull(dr1.Item("auto_pst_dt")), Nothing, dr1.Item("auto_pst_dt")) 'dr1.Item("auto_pst_dt")
                        obj.NoFol = dr1.Item("no_fol")
                        obj.FolAmt = dr1.Item("fol_amt")
                        obj.FolBal = dr1.Item("fol_bal")
                        obj.DueDeptAmt = dr1.Item("due_dep_amt")
                        obj.AthrtyCd = dr1.Item("athrty_cd")
                        obj.DepAmt = dr1.Item("dep_amt")
                        obj.DepBal = dr1.Item("dep_bal")
                        obj.UpdtTrnCd = dr1.Item("updt_trn_cd")


                        obj.UpdtDt = IIf(IsDBNull(dr1.Item("updt_dt")), Nothing, dr1.Item("updt_dt"))  'dr1.Item("updt_dt")
                        obj.UpdtTm = IIf(IsDBNull(dr1.Item("updt_tm")), Nothing, dr1.Item("updt_tm")) ' dr1.Item("updt_tm")
                        obj.UpdtUsrId = dr1.Item("updt_usr_id")
                        obj.CreateDt = IIf(IsDBNull(dr1.Item("crt_dt")), Nothing, dr1.Item("crt_dt"))  'dr1.Item("crt_dt")
                        obj.CreateTm = IIf(IsDBNull(dr1.Item("crt_tm")), Nothing, dr1.Item("crt_tm"))  ' dr1.Item("crt_tm")
                        obj.CreateUsrId = dr1.Item("crt_usr_id")

                        obj.No = dr1.Item("no")
                        obj.ChiefComplaints = dr1.Item("chief_complaints")
                        obj.LocalVillageCd = dr1.Item("lclvillagecd")
                        obj.RegionCd = dr1.Item("regioncd")
                        obj.LocalDistrictCd = dr1.Item("lcldistrictcd")
                        obj.PrefCls = dr1.Item("pref_cls")
                        GetIpPatientVisitByIpNo = obj
                    End While
                End If
                dr1.close()

                ofactory = Nothing

            Catch ex As Exception
                GetIpPatientVisitByIpNo = Nothing

                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try

            Return GetIpPatientVisitByIpNo
        End Function
        ''' <summary>
        ''' Select specific patient record  (Parameters:  @pIpNo)  
        ''' </summary>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="IpNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SPSELIPPTNVST003(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long) As DBRequest 'anamika 20160906
            'Shared Function SPSELIPPTNVST003(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELIPPTNVST003]" 'ip_ptn_vst
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
                oParam.ParamName = "pIpNo"
                oParam.ParamValue = IpNo
                .Parameters.Add(oParam)
                .CommandType = CommandType.StoredProcedure



            End With

            Return oRequest
        End Function
        'end 20131106
        'anamika 20130816
#End Region

#Region "FnAdmittedPatientStatus"
        ''' <summary>
        '''  Function to Return status of Admitted Patient from ip_ptn_vst table
        ''' </summary>
        ''' <param name="CoCd"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="PatientNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function FnAdmittedPatientStatus(ByVal CoCd As String, ByVal div As Integer, ByVal loc As Integer, ByVal PatientNo As Long) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "SELECT dbo.[FnAdmittedPatientStatus]('" & CoCd & "','" & div & "','" & loc & "','" & PatientNo & "')" 'ip_ptn_vst
                .CommandType = CommandType.Text


            End With
            Return oRequest
        End Function

        ''' <summary>
        ''' Function returns status of Admitted Patient
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="CoCd"></param>
        ''' <param name="Div"></param>
        ''' <param name="Loc"></param>
        ''' <param name="PatientNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Shared Function GetAdmittedPatientStatus(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal PatientNo As Long) As Integer 'anamika 20160829
            'Shared Function GetAdmittedPatientStatus(ByRef strErrMsg As List(Of String),
            '                                ByRef chrErrFlg As Char,
            '                                ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal PatientNo As Integer) As Integer
            GetAdmittedPatientStatus = Nothing
            Dim ofactory As DBFactory
            ofactory = New DBFactory
            Try
                Dim ds As DataSet = ofactory.ExecuteDataSet(FnAdmittedPatientStatus(CoCd, Div, Loc, PatientNo))
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        GetAdmittedPatientStatus = IIf(IsDBNull(ds.Tables(0).Rows(i).Item(0)), 0, ds.Tables(0).Rows(i).Item(0))
                    Next
                End If
                ds.Dispose()
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return False
            End Try
            Return GetAdmittedPatientStatus
        End Function

#End Region

#Region "GetIpPatientVisitDetailsByRsvNo"
        ''' <summary>
        ''' Select specific patient record  (Parameters:patient numbere)
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetIpPatientVisitDetailsByRsvNo(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer,
                                                 ByVal IPNO As Long) As clsIpPatientVisit
            GetIpPatientVisitDetailsByRsvNo = Nothing
            Try

                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST004(companycode, div, loc, IPNO))
                Dim obj As New clsIpPatientVisit
                If dr1.hasrows Then
                    While dr1.Read()
                        'obj.CompanyCode = companycode 'anamika 20160906
                        'obj.DivisionCode = div
                        'obj.LocationCode = loc
                        obj.IpNo = dr1.Item("ip_no")
                        obj.RsvNo = dr1.Item("rsv_no")
                        obj.PatientNo = dr1.Item("ptn_no")
                        obj.LocalAdd1 = dr1.Item("lcl_addrs1")
                        obj.LocalAdd2 = dr1.Item("lcl_addrs2")
                        obj.LocalAdd3 = dr1.Item("lcl_addrs3") 'anamika 20150703
                        obj.LocalState = dr1.Item("lcl_state") 'anamika 20150703
                        obj.LocalCity = dr1.Item("lcl_city")
                        obj.LocalCountry = dr1.Item("lcl_cntry")
                        obj.LocalPin = dr1.Item("lcl_pin")
                        obj.LocalPin = dr1.Item("lcl_tel")
                        obj.NewBrthFlg = dr1.Item("new_brth_flg")


                        obj.AdmDgnosCd = dr1.Item("adm_dgnos_cd")
                        obj.AdmDgnosDesc = dr1.Item("adm_dgnos_desc")
                        obj.DschgDgnosCd = dr1.Item("dschg_dgnos_cd")
                        obj.DschgDgnosDesc = dr1.Item("dschg_dgnos_desc")
                        obj.CsltyClncCd = dr1.Item("cslty_clnc_cd")
                        obj.CsltyVstNo = dr1.Item("cslty_vst_no")
                        obj.MedCseFlg = dr1.Item("med_cse_flg")
                        obj.BedNo = dr1.Item("bed_no")
                        obj.WingCd = dr1.Item("wing_cd")

                        obj.WardCd = dr1.Item("wrd_cd")
                        obj.BedTypCd = dr1.Item("bed_typ_cd")
                        obj.PtnSrcCd = dr1.Item("ptn_src_cd")
                        obj.CseTypCd = dr1.Item("cse_typ_cd")
                        obj.DocCd = dr1.Item("doc_cd")
                        obj.AddDocCd1 = dr1.Item("add_doc_cd_1")
                        obj.AddDocCd2 = dr1.Item("add_doc_cd_2")
                        obj.ExptdNoDays = dr1.Item("exptd_no_day")


                        obj.PtnClsCd = dr1.Item("ptn_cls_cd")
                        obj.RsdFlg = dr1.Item("rsd_flg")
                        obj.CnfInfFlg = dr1.Item("cnf_inf_flg")
                        obj.CrtClFlg = dr1.Item("crtcl_flg")
                        obj.BedTrnsfrNo = dr1.Item("bed_trnsfr_no")
                        obj.ClsTrnsfrNo = dr1.Item("cls_trnsfr_no")
                        obj.DocChngNo = dr1.Item("doc_chng_no")
                        obj.BedTrnsfrReqNo = dr1.Item("bed_trnsfr_req_no")


                        obj.ClsTrnsfrReqNo = dr1.Item("cls_trnsfr_req_no")
                        obj.DsChgAdvNo = dr1.Item("dschg_adv_no")
                        obj.DsChgNo = dr1.Item("dschg_no")
                        obj.AdmCnclnNo = dr1.Item("adm_cncln_no")
                        obj.AdmStsCd = dr1.Item("adm_sts_cd")
                        obj.RsvStsCd = dr1.Item("rsv_sts_cd")
                        obj.AdmDt = IIf(IsDBNull(dr1.Item("adm_dt")), Nothing, dr1.Item("adm_dt"))  'dr1.Item("adm_dt")

                        obj.DsChgDt = IIf(IsDBNull(dr1.Item("dschg_dt")), Nothing, dr1.Item("dschg_dt")) ' dr1.Item("dschg_dt")
                        obj.AdmTm = IIf(IsDBNull(dr1.Item("adm_tm")), Nothing, dr1.Item("adm_tm")) ' dr1.Item("adm_tm")
                        obj.DonCd = dr1.Item("don_cd")
                        obj.Rmrk = dr1.Item("rmrk")
                        obj.DsChgTm = IIf(IsDBNull(dr1.Item("dschg_tm")), Nothing, dr1.Item("dschg_tm")) ' dr1.Item("dschg_tm")


                        obj.AdmCrtDt = IIf(IsDBNull(dr1.Item("adm_crt_dt")), Nothing, dr1.Item("adm_crt_dt"))
                        obj.AdmCrtTm = IIf(IsDBNull(dr1.Item("adm_crt_tm")), Nothing, dr1.Item("adm_crt_tm")) ' dr1.Item("adm_crt_tm")
                        obj.AdmUsrId = dr1.Item("adm_usr_id")
                        obj.BlockBedNo = dr1.Item("block_bed_no")
                        obj.AutoPstDt = IIf(IsDBNull(dr1.Item("auto_pst_dt")), Nothing, dr1.Item("auto_pst_dt")) 'dr1.Item("auto_pst_dt")
                        obj.NoFol = dr1.Item("no_fol")
                        obj.FolAmt = dr1.Item("fol_amt")
                        obj.FolBal = dr1.Item("fol_bal")
                        obj.DueDeptAmt = dr1.Item("due_dep_amt")
                        obj.AthrtyCd = dr1.Item("athrty_cd")
                        obj.DepAmt = dr1.Item("dep_amt")
                        obj.DepBal = dr1.Item("dep_bal")
                        obj.UpdtTrnCd = dr1.Item("updt_trn_cd")


                        obj.UpdtDt = IIf(IsDBNull(dr1.Item("updt_dt")), Nothing, dr1.Item("updt_dt"))  'dr1.Item("updt_dt")
                        obj.UpdtTm = IIf(IsDBNull(dr1.Item("updt_tm")), Nothing, dr1.Item("updt_tm")) ' dr1.Item("updt_tm")
                        obj.UpdtUsrId = dr1.Item("updt_usr_id")
                        obj.CreateDt = IIf(IsDBNull(dr1.Item("crt_dt")), Nothing, dr1.Item("crt_dt"))  'dr1.Item("crt_dt")
                        obj.CreateTm = IIf(IsDBNull(dr1.Item("crt_tm")), Nothing, dr1.Item("crt_tm"))  ' dr1.Item("crt_tm")
                        obj.CreateUsrId = dr1.Item("crt_usr_id")

                        obj.No = dr1.Item("no")
                        obj.ChiefComplaints = dr1.Item("chief_complaints")
                        obj.LocalVillageCd = dr1.Item("lclvillagecd")
                        obj.RegionCd = dr1.Item("regioncd")
                        obj.LocalDistrictCd = dr1.Item("lcldistrictcd")
                        obj.PrefCls = dr1.Item("pref_cls")
                    End While
                End If
                dr1.close()
                GetIpPatientVisitDetailsByRsvNo = obj
                ofactory = Nothing

            Catch ex As Exception
                GetIpPatientVisitDetailsByRsvNo = Nothing

                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try

            Return GetIpPatientVisitDetailsByRsvNo
        End Function
        'Shared Function SPSELIPPTNVST004(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal RSVNO As Integer) As DBRequest
        Shared Function SPSELIPPTNVST004(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal RSVNO As Long) As DBRequest 'anamika 20160906
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELIPPTNVST004]" 'ip_ptn_vst
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
                oParam.ParamName = "pRsvNo"
                oParam.ParamValue = RSVNO
                .Parameters.Add(oParam)
                .CommandType = CommandType.StoredProcedure



            End With

            Return oRequest
        End Function

#End Region


#Region "GetBlockedIpPatientVisitDetails"


        ''' <summary>
        ''' Selects inpatient from ip_ptn_vst having blocked beds
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetBlockedIpPatientVisitDetails(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer
                                              ) As List(Of clsIpPatientVisit)
            GetBlockedIpPatientVisitDetails = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST005(companycode, div, loc))
                Dim objList As New List(Of clsIpPatientVisit)

                If dr1.hasrows Then
                    While dr1.Read()
                        Dim obj As New clsIpPatientVisit

                        obj.IpNo = dr1.Item("ip_no")
                        obj.PatientNo = dr1.Item("ptn_no")
                        obj.BedNo = dr1.Item("bed_no")
                        obj.BlockBedNo = dr1.Item("block_bed_no")
                        obj.WingCd = dr1.Item("wing_cd")
                        obj.WingdCd = dr1.Item("wing_dcd")
                        obj.WardCd = dr1.Item("wrd_cd")
                        obj.WardCd = dr1.Item("wrd_cd")
                        obj.WarddCd = dr1.Item("wrd_dcd")
                        obj.RoomNo = dr1.Item("rm_no")
                        obj.BlockedBedRmno = dr1.Item("blockedbedrmno")
                        obj.BedTypCd = dr1.Item("bed_typ_cd")
                        obj.BedTypdCd = dr1.Item("bed_typ_dcd")
                        obj.CseTypCd = dr1.Item("cse_typ_cd")
                        obj.CseTypDCd = dr1.Item("cse_typ_dcd")
                        obj.ptnname = dr1.Item("ptnname")
                        obj.Ptngender = dr1.Item("Ptngender")
                        obj.Age = dr1.Item("Age")
                        obj.BlockedRoomDesc = dr1.Item("BlockRm_name")      'Aarti 07 May 2018
                        obj.RoomDesc = dr1.Item("rm_name")      'Aarti 07 May 2018
                        objList.Add(obj)
                    End While
                End If
                dr1.close()
                GetBlockedIpPatientVisitDetails = objList
                ofactory = Nothing
            Catch ex As Exception
                GetBlockedIpPatientVisitDetails = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
            Return GetBlockedIpPatientVisitDetails
        End Function
        ''' <summary>
        ''' Selects inpatient from ip_ptn_vst having blocked beds
        ''' </summary>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SPSELIPPTNVST005(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest

                .Command = "[SPSELIPPTNVST005]"  'ip_ptn_vst  bed_mst  wing_mst  cse_typ_mst  doc_mst  cd_dcd  ptn_mst1  ptn_cls_mst
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


            End With

            Return oRequest
        End Function



#End Region


#Region "Exclusively used in patient query "
        ''' <summary>
        ''' APARNA 31 JUL 2015
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="Cocd"></param>
        ''' <param name="Div"></param>
        ''' <param name="Loc"></param>
        ''' <param name="IPNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>

        'Shared Function GetPtnIpPtnVst(ByRef strErrMsg As List(Of String), _
        '                          ByRef chrErrFlg As Char, ByVal Cocd As String, ByVal Div As Integer, ByVal Loc As Integer,
        '                               ByVal IPNo As Long) As List(Of clsIpPtnVst)
        '    GetPtnIpPtnVst = Nothing
        '    Dim ofactory As New DBFactory
        '    Try

        '        Dim dr2 As New Object
        '        dr2 = ofactory.ExecuteDataReader(SPSELIPPTNVST(Cocd, Div, Loc, IPNo))
        '        Dim objptndtl As List(Of clsIpPtnVst) = Nothing
        '        If dr2.hasrows Then
        '            objptndtl = New List(Of clsIpPtnVst)
        '            While dr2.Read()
        '                With dr2
        '                    Dim obj1 As New clsIpPtnVst
        '                    obj1.PatientNo = .Item("IpNo")
        '                    obj1.AdmissionDt = .Item("Admission")
        '                    obj1.Casetype = .Item("Casetype")
        '                    obj1.DiscahrgeDt = .Item("DiscahrgeDt")
        '                    obj1.DiscahrgeSt = .Item("DischSt")
        '                    obj1.Ptnclass = .Item("Ptncls")
        '                    obj1.Doctor = .Item("Doctor")
        '                    obj1.Outstanding = .Item("Outstanding")
        '                    obj1.TotalGrossAmt = .Item("TotalGrossAmt") 'aparna 20151019
        '                    objptndtl.Add(obj1)

        '                End With
        '            End While

        '        End If
        '        dr2.close()
        '        GetPtnIpPtnVst = objptndtl
        '        ofactory = Nothing
        '    Catch ex As Exception
        '        GetPtnIpPtnVst = Nothing
        '        strErrMsg.Add(ex.Message)
        '    Finally
        '        ofactory = Nothing
        '    End Try
        '    Return GetPtnIpPtnVst
        'End Function






        Shared Function GetPtnIpPtnVst(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal Cocd As String,
                                               ByVal Div As Integer,
                                               ByVal Loc As Integer,
                                               ByVal IPNo As Long) As List(Of clsIpPtnQryDtls) 'pragya 20170831
            GetPtnIpPtnVst = Nothing
            Dim ofactory As New DBFactory
            Try

                Dim dr2 As New Object
                dr2 = ofactory.ExecuteDataReader(SPSelIpPtnVst(Cocd, Div, Loc, IPNo))
                Dim objptndtl As List(Of clsIpPtnQryDtls) = Nothing
                If dr2.hasrows Then
                    objptndtl = New List(Of clsIpPtnQryDtls)
                    While dr2.Read()
                        With dr2
                            Dim obj1 As New clsIpPtnQryDtls
                            obj1.PatientNo = .Item("IpNo")
                            obj1.AdmissionDt = IIf(IsDBNull(.Item("Admission")), Date.MinValue, .Item("Admission")) '.Item("Admission") 'anamika 20171108
                            obj1.Casetype = .Item("Casetype")
                            obj1.DiscahrgeDt = IIf(IsDBNull(.Item("DiscahrgeDt")), Date.MinValue, .Item("DiscahrgeDt")) 'anamika 20171108
                            obj1.DiscahrgeSt = .Item("DischSt")
                            obj1.Ptnclass = .Item("Ptncls")
                            obj1.Doctor = .Item("Doctor")
                            obj1.Outstanding = .Item("Outstanding")
                            obj1.TotalGrossAmt = .Item("TotalGrossAmt") 'aparna 20151019

                            obj1.CasetypeCd = .Item("CaseTypCd") 'Pragya : 31-Aug-2017
                            obj1.SubCaseTypCd = .Item("SubCaseTypCd") 'Pragya : 31-Aug-2017
                            obj1.SubCaseTypDesc = .Item("SubCaseType") 'Pragya : 31-Aug-2017
                            obj1.CaseManagerCd = .Item("CaseManagerCd") 'Pragya : 31-Aug-2017
                            obj1.CaseManagerDesc = .Item("CaseManagerDesc") 'Pragya : 31-Aug-2017
                            obj1.CoordinatorCd = .Item("CoordinatorCd") 'Pragya : 31-Aug-2017
                            obj1.CoordinatorDesc = .Item("CoordinatorDesc") 'Pragya : 31-Aug-2017
                            obj1.BillAmt = IIf(IsDBNull(.Item("BillAmt")), 0, .Item("BillAmt")) 'RasikV 20180421
                            obj1.UnBillAmt = IIf(IsDBNull(.Item("UnBillAmt")), 0, .Item("UnBillAmt")) 'RasikV 20180421	
                            obj1.AdmissionTm = IIf(IsDBNull(.Item("ADMISSIONTm")), Date.MinValue, .Item("ADMISSIONTm")) ''Amol 2018-05-09

                            Try
                                obj1.DiscahrgeTm = IIf(IsDBNull(.Item("DiscahrgeTm")), Date.MinValue, .Item("DiscahrgeTm")) ''Amol 2018-05-09
                            Catch
                                obj1.DiscahrgeTm = Nothing
                            End Try
                            objptndtl.Add(obj1)

                        End With
                    End While

                End If
                dr2.close()
                GetPtnIpPtnVst = objptndtl
                ofactory = Nothing
            Catch ex As Exception
                GetPtnIpPtnVst = Nothing
                strErrMsg.Add(ex.Message)
            Finally
                ofactory = Nothing
            End Try
            Return GetPtnIpPtnVst
        End Function

        Shared Function SPSelIpPtnVst(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IPNo As Long) As DBRequest 'anamika 20160929
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSelIpPtnVst]"
                .CommandType = CommandType.StoredProcedure

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCOCD"
                oParam.ParamValue = cocd
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
                oParam.ParamName = "IPNo"
                oParam.ParamValue = IPNo
                .Parameters.Add(oParam)
            End With
            Return oRequest
        End Function
#End Region


#Region "Exclusively used in patient query"
        ''' <summary>
        ''' APARNA 31 JUL 2015
        ''' </summary>
        ''' <param name="Cocd"></param>
        ''' <param name="Div"></param>
        ''' <param name="Loc"></param>
        ''' <param name="IPNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SpSelPtndDetail(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long) As DBRequest
            'Shared Function SpSelPtndDetail(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSelIpPtnVst002]"
                .CommandType = CommandType.StoredProcedure

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCOCD"
                oParam.ParamValue = cocd
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
                oParam.ParamName = "IPNo"
                oParam.ParamValue = IpNo
                .Parameters.Add(oParam)

            End With
            Return oRequest
        End Function

#End Region

#Region "GetPtnClsDtlByIpOpNo: Selects  record from ptn_cls_mst table   for given ip_op no  "

        ''' <summary>
        '''  Selects  record from ptn_cls_mst table   for given ip_op no  
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks>aparna 19 may 2016</remarks>
        Shared Function GetPtnClsDtlByIpOpNo(ByRef strErrMsg As List(Of String),
                                                          ByRef chrErrFlg As Char,
                                                          ByVal companycode As String,
                                                          ByVal div As Integer,
                                                          ByVal loc As Integer,
                                                          ByVal IpNo As Long) As clsPtnVstDtl
            GetPtnClsDtlByIpOpNo = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST007(companycode, div, loc, IpNo))
                Dim objPTNCLASSList As clsPtnVstDtl
                objPTNCLASSList = New clsPtnVstDtl
                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1

                            objPTNCLASSList.PatientClassCode = .Item("ptn_cls_cd")
                            objPTNCLASSList.PatientClassDecode = .Item("ptn_cls_dcd")
                            objPTNCLASSList.PatientAdmDt = .item("adm_dt")
                            objPTNCLASSList.PatientName = .item("ptn_nm")

                        End With
                    End While
                    GetPtnClsDtlByIpOpNo = objPTNCLASSList
                End If
                dr1.close()
                ofactory = Nothing
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
        End Function

        ''' <summary>
        '''  Selects record from ptn_cls_mst table   for given ip_op no  
        ''' </summary>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SPSELIPPTNVST007(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELIPPTNVST007]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCocd"
                oParam.ParamValue = companycode
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pDivCd"
                oParam.ParamValue = div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pLocCd"
                oParam.ParamValue = loc
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pIpNo"
                oParam.ParamValue = IpNo
                .Parameters.Add(oParam)


            End With
            Return oRequest
        End Function

#End Region

#Region "SPSELIPPTNVST008:get record for selected ip(sp contain join of ptn_mst1,ip_ptn_Vst,doc_mst)  "
        'Shared Function SPSELIPPTNVST008(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ipno As Integer) As DBRequest
        Shared Function SPSELIPPTNVST008(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ipno As Long) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter

            With oRequest
                .Command = "[SPSELIPPTNVST008]"  'ptn_mst1,ip_ptn_Vst,doc_mst
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
                oParam.ParamName = "pIpNo"
                oParam.ParamValue = ipno
                .Parameters.Add(oParam)


            End With
            Return oRequest
        End Function
#End Region

#Region "GetPatientDtlsFrmIpNo/SPSELIPPTNVST009 :  TO GET THE PATIENT DETAILS FROM IP_PTN_VST & PTN_MST1"



        Shared Function GetPatientDtlsFrmIpNo(ByRef strErrMsg As List(Of String),
                                                        ByRef chrErrFlg As Char,
                                                        ByVal companycode As String,
                                                        ByVal div As Integer,
                                                        ByVal loc As Integer,
                                                        ByVal IpNo As Long) As clsPtnExtraDetails
            GetPatientDtlsFrmIpNo = Nothing
            Try

                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST009(companycode, div, loc, IpNo))
                Dim objPatient As clsPtnExtraDetails = Nothing
                If dr1.hasrows Then
                    dr1.read()
                    With dr1
                        objPatient = New clsPtnExtraDetails
                        objPatient.PatientNo = .Item("PatientNo")
                        objPatient.PtnFrstName = .Item("PatientFirstName")
                        objPatient.PtnMidName = .Item("PatientMiddleName")
                        objPatient.PtnLastName = .Item("PatientLastName")
                        objPatient.PtnFullName = .Item("PatientFullName")
                        objPatient.PtnTitleCode = .Item("PatientTitleCode")
                        objPatient.PtnTitleCodeDesc = .Item("PatientTitleCodeDesc")
                        objPatient.Gender = .Item("Gender")
                        objPatient.IpNo = .Item("InPatientNo")
                        objPatient.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                        objPatient.EMPNo = IIf(.Item("EMPNo") = "", 0, .Item("EMPNo"))
                        objPatient.Mobile = IIf(IsDBNull(.Item("mobile")), "", .Item("mobile"))
                        objPatient.Email = IIf(.Item("email") = "", "", .Item("email"))
                        objPatient.LocalAdd1 = IIf(.Item("prmnt_addrs1") = "", "", .Item("prmnt_addrs1"))
                        objPatient.LocalAdd2 = IIf(.Item("prmnt_addrs2") = "", "", .Item("prmnt_addrs2"))
                        objPatient.LocalAdd3 = IIf(.Item("prmnt_addrs3") = "", "", .Item("prmnt_addrs3"))
                        objPatient.LocalPin = IIf(.Item("prmnt_pin") = "", "", .Item("prmnt_pin"))
                        objPatient.LocalTel = IIf(.Item("prmnt_tel") = "", "", .Item("prmnt_tel"))
                        objPatient.LocalCountry = IIf(.Item("prmnt_cntry") = 0, 0, .Item("prmnt_cntry"))
                        objPatient.LocalCity = .Item("prmnt_city")
                        objPatient.LocalState = .Item("StateCd")
                        objPatient.EXPDT = .Item("EXPDT")
                        objPatient.Status = .Item("Status")
                        objPatient.MobileNumber2 = .Item("mobile2")
                        objPatient.WhatsAppNo = .Item("WhatsAppNo")
                        objPatient.IsPtnBlackListed = .Item("IsPtnBlackListed")
                        objPatient.ConsentOfDataShare = .Item("ConsentOfDataShare")
                        objPatient.PrefCls = .Item("pref_cls")
                        objPatient.EligibleCls = .Item("EligibleCls")
                        objPatient.DepositRemark = .Item("DepositRemark")
                        objPatient.BedNo = .Item("BedNo")
                        objPatient.RoomNo = .Item("RoomNo")
                        objPatient.BedTypCd = .Item("BedTypcd")
                        objPatient.BedTypdCd = .item("BedTypDesc")
                        objPatient.WingCd = .item("WngCd")
                        objPatient.WingdCd = .item("WngDesc")
                        objPatient.Floor = .item("Floor")
                        objPatient.WardCd = .item("WrdCd")
                        objPatient.WarddCd = .item("WrdDesc")
                        objPatient.PtnClsCd = .item("ptnclscd")
                        objPatient.PtnClsDcd = .item("ptnclassDcd")
                        objPatient.CseTypCd = .item("CseTypCd")
                        objPatient.PtnSrcCd = .item("ptn_src_cd")
                        objPatient.DocCd = .item("DocCd")
                        objPatient.DocCd2 = .item("DocCd2")
                        objPatient.AddDocCd1 = .item("AddDocCd1")
                        objPatient.AddDocCd2 = .item("AddDocCd2")
                        objPatient.CampCd = .item("CampCd")
                        objPatient.AlotNo = .item("AltNo")
                        objPatient.AdmCrtDt = .item("AdmDt")
                        objPatient.AdmCrtTm = .item("AdmTm")
                        objPatient.MLCCase = .item("MLCCase")
                        objPatient.Surchrge = .item("SurchrgCd")
                        objPatient.ArCd = .Item("arcd")
                        objPatient.CoRefNo = .Item("CoRefNo")
                        objPatient.RsvNo = .Item("RsvNo")   'aparna 27 nov 2016
                        objPatient.Bithdate = .Item("BirthDate") 'Pramila 20jan2017
                        objPatient.Agemm = .Item("age_mm") 'Pramila 20jan2017
                        objPatient.Agedd = .Item("age_dd")  'Pramila 20jan2017
                        objPatient.Aadhar = .Item("aadhar_no") 'Pramila 20jan2017
                        objPatient.DefaultDietType = .Item("DefaultDietType") 'pragya : 06-feb-2017
                        objPatient.CsltyClncCd = .item("cslty_clnc_cd")  'APARNA 29 MAR 2017
                        objPatient.CsltyVstNo = .item("cslty_vst_no")  'APARNA 29 MAR 2017
                        objPatient.CaseManagerCd = .item("CaseManagerCd")  'APARNA 26 MAY 2017
                        objPatient.CoordinatorCd = .item("CoordinatorCd")  'APARNA 26 MAY 2017
                        objPatient.SubCseTypCd = .item("SubCseTypCd")  'anamika 20170714
                        objPatient.PtnRefByTyp = .item("PtnRefByTyp")  'AARTI 14 JUN 2018
                        objPatient.PtnRefByCd = .item("PtnRefByCd")   'AARTI 14 JUN 2018
                    End With
                End If
                dr1.close()
                GetPatientDtlsFrmIpNo = objPatient
                ofactory = Nothing
            Catch ex As Exception
                GetPatientDtlsFrmIpNo = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
        End Function
        ''' <summary>
        ''' GetPatientFrmIpNo/SPSELIPPTNVST009 :  TO GET THE PATIENT DETAILS FROM IP_PTN_VST & PTN_MST1
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="IpNo"></param>
        ''' <returns></returns>
        ''' <remarks>PRAGYA : 08-AUG-2016</remarks>

        Shared Function SPSELIPPTNVST009(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IPNO As Long) As DBRequest 'anamika 20160906
            'Shared Function SPSELIPPTNVST009(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IPNO As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELIPPTNVST009]"

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
                oParam.ParamName = "pipno"
                oParam.ParamValue = IPNO
                .Parameters.Add(oParam)


                .CommandType = CommandType.StoredProcedure



            End With

            Return oRequest
        End Function

#End Region


#Region "GetEligibleCancelAdm:select admissions from  ip_ptn_vst which are eligible to cancel(cancel Admission)"
        ''' <summary>
        ''' select admissions from  ip_ptn_vst which are eligible to cancel
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>


        Shared Function GetEligibleCancelAdm(ByRef strErrMsg As List(Of String),
                                                        ByRef chrErrFlg As Char,
                                                        ByVal companycode As String,
                                                        ByVal div As Integer,
                                                        ByVal loc As Integer) As List(Of clsCancelAdmission)
            GetEligibleCancelAdm = Nothing
            Dim arrobjPatient As New List(Of clsCancelAdmission)
            Try

                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST012(companycode, div, loc))
                Dim objPatient As clsCancelAdmission = Nothing

                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1
                            objPatient = New clsCancelAdmission
                            objPatient.IpNo = .Item("ip_no")
                            objPatient.PtnNo = .Item("PtnNo")
                            objPatient.PtnName = .Item("PtnName")
                            objPatient.PtnClsCd = .Item("PtnClsCd")
                            objPatient.PtnClsDCd = .Item("PtnClsDCd")
                            objPatient.ptnDoccd = .Item("ptnDoccd")
                            objPatient.ptnDocName = .Item("ptnDocName")
                            objPatient.Remark = .Item("Remark")
                            objPatient.WardCd = .Item("WardCd")
                            objPatient.WardDesc = .Item("WardDesc")
                            objPatient.BedNo = .Item("bedno")
                            arrobjPatient.Add(objPatient)
                        End With
                    End While
                End If
                dr1.close()
                GetEligibleCancelAdm = arrobjPatient
                ofactory = Nothing
            Catch ex As Exception
                GetEligibleCancelAdm = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
            Return arrobjPatient
        End Function

        Shared Function SPSELIPPTNVST012(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELIPPTNVST012]"

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



                .CommandType = CommandType.StoredProcedure



            End With

            Return oRequest
        End Function

#End Region

#Region "GetPtnDiscSummFreezingDtl:GET PATIENT VST DETAILS"
        ''' <summary>
        ''' list contains patients discharge summary freezing details
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetPtnDiscSummFreezingDtl(ByRef strErrMsg As List(Of String),
                                                           ByRef chrErrFlg As Char,
                                                           ByVal companycode As String,
                                                           ByVal div As Integer,
                                                           ByVal loc As Integer
                                                          ) As List(Of clsDiscSummFreezingDtl)

            GetPtnDiscSummFreezingDtl = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST010(companycode, div, loc))
                Dim obj As New List(Of clsDiscSummFreezingDtl)
                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1
                            Dim objPTNCLASSList As clsDiscSummFreezingDtl
                            objPTNCLASSList = New clsDiscSummFreezingDtl

                            objPTNCLASSList.PatientNo = .Item("ptn_no")
                            objPTNCLASSList.PatientFullName = .Item("ptnname")
                            objPTNCLASSList.Gender = .item("GENDER")
                            objPTNCLASSList.Age = .item("AGE")
                            objPTNCLASSList.IpNo = .Item("Ip_No")
                            objPTNCLASSList.BedNo = .Item("bed_no")
                            objPTNCLASSList.mobile = .item("mobile")
                            objPTNCLASSList.WardDCd = .item("ward")
                            objPTNCLASSList.Status = .item("StatusCd")
                            objPTNCLASSList.StatusDesc = .item("StatusDesc")
                            objPTNCLASSList.IsDataFreezed = .item("IsDataFreezed")
                            objPTNCLASSList.WardCd = .item("wrd_cd")

                            obj.Add(objPTNCLASSList)


                        End With
                    End While
                    GetPtnDiscSummFreezingDtl = obj
                End If
                dr1.close()
                ofactory = Nothing
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
        End Function


        Shared Function SPSELIPPTNVST010(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELIPPTNVST010]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCocd"
                oParam.ParamValue = companycode
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pDivCd"
                oParam.ParamValue = div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pLocCd"
                oParam.ParamValue = loc
                .Parameters.Add(oParam)



            End With
            Return oRequest
        End Function


#End Region


#Region "Get patient no and name details by ipno"   'RasikV 20161005

        Shared Function GetPtnNameDtlByIpNo(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal Cocd As String,
               ByVal Div As Integer, ByVal Loc As Integer, ByVal IpNo As Long) As clsPtnDtl
            GetPtnNameDtlByIpNo = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST013(Cocd, Div, Loc, IpNo))
                While dr1.Read()
                    With dr1
                        Dim obj As New clsPtnDtl
                        obj.PtnNo = .Item("PtnNo")
                        obj.PtnName = .Item("PtnName")
                        GetPtnNameDtlByIpNo = obj
                    End With
                End While
                dr1.close()
                ofactory = Nothing
            Catch ex As Exception
                GetPtnNameDtlByIpNo = Nothing
                strErrMsg.Add(ex.Message)
            End Try
            Return GetPtnNameDtlByIpNo
        End Function

        Shared Function SPSELIPPTNVST013(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELIPPTNVST013]"
                .CommandType = CommandType.StoredProcedure

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCOCD"
                oParam.ParamValue = cocd
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
                oParam.ParamName = "pIpNo"
                oParam.ParamValue = IpNo
                .Parameters.Add(oParam)

            End With
            Return oRequest
        End Function

#End Region


#Region "GetPtnNoClsByIpNo / SpSelIpPtnVst014 : GET THE PTNCLS & PTNNO FROM IP_PTN_VST"
        Shared Function GetPtnNoClsByIpNo(ByRef strErrMsg As List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal companycode As String,
                                                   ByVal div As Integer,
                                                   ByVal loc As Integer,
                                                   ByVal IpNo As Long) As clsPtnVstPtnClsDtl
            GetPtnNoClsByIpNo = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst014(companycode, div, loc, IpNo))
                Dim objPTNCLASSList As clsPtnVstPtnClsDtl
                objPTNCLASSList = New clsPtnVstPtnClsDtl
                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1
                            objPTNCLASSList.PtnClsCd = .Item("PtnClsCd")
                            objPTNCLASSList.PtnNo = .Item("PtnNo")
                        End With
                    End While
                    GetPtnNoClsByIpNo = objPTNCLASSList
                End If
                dr1.close()
                ofactory = Nothing
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try
        End Function

        Shared Function SpSelIpPtnVst014(ByVal companycode As String,
                                         ByVal div As Integer,
                                         ByVal loc As Integer,
                                         ByVal ipno As Long) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter

            With oRequest
                .Command = "[SpSelIpPtnVst014]"  'ptn_mst1,ip_ptn_Vst,doc_mst
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
                oParam.ParamName = "pIpNo"
                oParam.ParamValue = ipno
                .Parameters.Add(oParam)


            End With
            Return oRequest
        End Function

#End Region



#Region "GetPtnBasicDtlsByIpNo / SpSelIpPtnVst015 : GET THE PATIENT DETAILS RETURN TYP : CLASS - clsPtnAllDtls"
        'PRAGYA : 12-NOV-2016
        Shared Function GetPtnBasicDtlsByIpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As clsPtnAllDtls
            GetPtnBasicDtlsByIpNo = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst015(strErrMsg, chrErrFlg, cocd, div, loc, IpNo))
                Dim objPtn As clsPtnAllDtls
                objPtn = New clsPtnAllDtls
                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1
                            objPtn.IpNo = .Item("IpNo")
                            objPtn.PtnNo = .Item("PtnNo")
                            objPtn.PatientFullName = .Item("PtnName")
                            objPtn.PtnClsCd = .Item("PtnClsCd")
                            objPtn.PtnClsDesc = .Item("PtnClsDesc")
                            objPtn.ArCd = .Item("ArCd")
                            objPtn.ArDesc = .Item("ArDesc")
                            objPtn.Gender = .Item("Gender")
                            objPtn.Age = .Item("AgeYY")
                            objPtn.WingCd = .Item("WngCd")
                            objPtn.WingDesc = .Item("WngDesc")
                            objPtn.WardCd = .Item("WrdCd")
                            objPtn.WardDCd = .Item("WardDesc")
                            objPtn.BedNo = .Item("BedNo")
                            objPtn.BedTypCd = .Item("BedTypCd")
                            objPtn.BedTypDesc = .Item("BedTypDesc")
                            objPtn.DoctorCd = .Item("DocCd")
                            objPtn.DoctorName = .Item("DocNm")
                            objPtn.CseTypCd = .Item("CseTypCd")
                            objPtn.CseTypDesc = .Item("CseTypDesc")
                            objPtn.SrchgCd = .Item("SrchgCd")
                            objPtn.SrchgPer = .Item("SrchgPer")
                            objPtn.PtnSrcCd = .Item("PtnSrcCd")

                        End With
                    End While
                    GetPtnBasicDtlsByIpNo = objPtn
                End If
                dr1.close()
                ofactory = Nothing
                Return GetPtnBasicDtlsByIpNo
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                GetPtnBasicDtlsByIpNo = Nothing
                Return Nothing
            End Try
        End Function

        Shared Function SpSelIpPtnVst015(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As DBRequest

            SpSelIpPtnVst015 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SpSelIpPtnVst015]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pCocd"
                    oParam.ParamValue = cocd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pDivCd"
                    oParam.ParamValue = div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pLocCd"
                    oParam.ParamValue = loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pIpNo"
                    oParam.ParamValue = IpNo
                    .Parameters.Add(oParam)

                End With

                SpSelIpPtnVst015 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpPtnVst015 = Nothing
            End Try

            Return SpSelIpPtnVst015

        End Function
#End Region

#Region "get referrence doctor by passing ip number / SPSELPTNMST010 "
        ''' <summary>
        ''' get referrence doctor by passing ip number
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="CoCd"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="IpNo"></param>
        ''' <returns></returns>
        ''' <remarks>anamika 20161212</remarks>
        Public Shared Function GetReferrenceDocByIpNo(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal CoCd As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                     ByVal IpNo As Long
                                                    ) As clsReferdDocDisplay

            Try


                Dim obj As New clsReferdDocDisplay
                obj = GetRefDocByIpNo(strErrMsg, chrErrFlg, CoCd, div, loc, IpNo)
                If obj IsNot Nothing Then
                    'GetReferrenceDocByIpNo = clsCommonHelp.GetCommonHelpByTypCdAndCode(strErrMsg, chrErrFlg, CoCd, div, loc, EnumCodeDecode.PatientReferralType, obj.PtnRefByTyp, obj.PtnRefByCd)
                    GetReferrenceDocByIpNo = obj
                Else
                    GetReferrenceDocByIpNo = Nothing
                End If
            Catch ex As Exception
                GetReferrenceDocByIpNo = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
            Return GetReferrenceDocByIpNo
        End Function
        Shared Function GetRefDocByIpNo(ByRef strErrMsg As List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal companycode As String,
                                                   ByVal div As Integer,
                                                   ByVal loc As Integer,
                                                   ByVal ipno As Long) As clsReferdDocDisplay

            GetRefDocByIpNo = Nothing
            Try

                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst016(companycode, div, loc, ipno))
                Dim objRefPat As clsReferdDocDisplay = Nothing
                If dr1.hasrows Then
                    dr1.read()
                    objRefPat = New clsReferdDocDisplay

                    objRefPat.PtnRefByTyp = dr1.Item("PtnRefByTyp")
                    objRefPat.PtnRefByCd = dr1.Item("PtnRefByCd")
                End If
                dr1.close()
                GetRefDocByIpNo = objRefPat
                ofactory = Nothing
            Catch ex As Exception
                GetRefDocByIpNo = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
            Return GetRefDocByIpNo
        End Function
        Shared Function SpSelIpPtnVst016(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SpSelIpPtnVst016]"

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
                oParam.ParamName = "pIpNo"
                oParam.ParamValue = IpNo
                .Parameters.Add(oParam)

                .CommandType = CommandType.StoredProcedure



            End With

            Return oRequest
        End Function
#End Region
#Region "get deposit amt"
        ''' <summary>
        ''' aparna 20 dec 2016
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Shared Function GetDueDepAmtByIpNo(ByRef strErrMsg As List(Of String),
                                ByRef chrErrFlg As Char,
                                ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                ByVal ipno As Long) As Double
            GetDueDepAmtByIpNo = Nothing
            Try

                Dim ofactory As New DBFactory

                Dim oRequest As DBRequest = New DBRequest
                Dim oParam As New DBRequest.Parameter
                With oRequest
                    .CommandType = CommandType.Text


                    .Command = "SELECT dbo.[FnGetDueDptAmt] (@pCocd ,@pDiv,@pLoc,@pipno)"

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pCocd"
                    oParam.ParamValue = companycode
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pDiv"
                    oParam.ParamValue = div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pLoc"
                    oParam.ParamValue = loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pipno"
                    oParam.ParamValue = ipno
                    .Parameters.Add(oParam)


                End With
                Dim dr As Object = ofactory.ExecuteDataReader(oRequest)

                If dr.hasrows Then
                    dr.read()
                    GetDueDepAmtByIpNo = dr.item(0)
                End If
                dr.close()
                oRequest = Nothing
                ofactory = Nothing
            Catch ex As Exception
                GetDueDepAmtByIpNo = ""
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
        End Function

#End Region


#Region "GetDischrgeDtByIpNo/SpSelIpPtnVst017 :Get discharge date by passing ipno where adm_sts=3"
        'pragya : 10-mar-2017
        Shared Function GetDischrgeDtByIpNo(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                          ByRef chrErrFlg As Char,
                                          ByVal CoCd As String,
                                          ByVal Div As Integer,
                                          ByVal Loc As Integer,
                                          ByVal IPNO As Long) As Date
            GetDischrgeDtByIpNo = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst017(strErrMsg, chrErrFlg, CoCd, Div, Loc, IPNO))
                While dr1.Read()
                    With dr1
                        GetDischrgeDtByIpNo = IIf(IsDBNull(.Item("DSCHG_DT")), Date.MinValue, .Item("DSCHG_DT"))
                    End With
                End While
                dr1.close()
                ofactory = Nothing
            Catch ex As Exception

                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            End Try

            Return GetDischrgeDtByIpNo

        End Function

        Shared Function SpSelIpPtnVst017(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                          ByRef chrErrFlg As Char,
                                          ByVal CoCd As String,
                                          ByVal Div As Integer,
                                          ByVal Loc As Integer,
                                          ByVal IPNO As Long) As DBRequest

            SpSelIpPtnVst017 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SpSelIpPtnVst017]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pCocd"
                    oParam.ParamValue = CoCd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pDivCd"
                    oParam.ParamValue = Div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pLocCd"
                    oParam.ParamValue = Loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pIPNO"
                    oParam.ParamValue = IPNO
                    .Parameters.Add(oParam)

                End With

                SpSelIpPtnVst017 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpPtnVst017 = Nothing
            End Try

            Return SpSelIpPtnVst017

        End Function

#End Region

#Region "GetBedAutoChrgPstngData/SpSelIpPtnVst017 :select data from ip_ptn_Vst where adm_sts_cd=2 and adm_dt is less than selected date(Exclusively used in night audit -bed auto charge posting" 'anamika 20170519
        Shared Function GetBedAutoChrgPstngData(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                  ByRef chrErrFlg As Char,
                                                  ByVal CoCd As String,
                                                  ByVal Div As Integer,
                                                  ByVal Loc As Integer,
                                                ByVal SelDate As Date) As List(Of clsAutoPostBedChrg)
            GetBedAutoChrgPstngData = Nothing
            Dim ofactory As New DBFactory
            Try



                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst018(strErrMsg, chrErrFlg, CoCd, Div, Loc, SelDate))
                Dim objList As New List(Of clsAutoPostBedChrg)

                If dr1.hasrows Then
                    While dr1.Read()
                        Dim obj As New clsAutoPostBedChrg

                        obj.BedTypeCode = dr1.Item("bed_typ_cd")
                        obj.ArCd = dr1.Item("ar_cd")
                        obj.WingCd = dr1.Item("wing_cd")
                        obj.IpNo = dr1.Item("ip_no")
                        obj.FolNo = dr1.Item("no_fol")
                        obj.WardCd = dr1.Item("wrd_Cd")
                        obj.CseTypCd = dr1.Item("cse_typ_cd")
                        obj.DocCd = dr1.Item("doc_cd")
                        obj.PtnSrcCd = dr1.Item("ptn_src_cd")
                        obj.PtnClsCd = dr1.Item("ptn_cls_cd")
                        obj.AdmissionDate = dr1.Item("adm_dt")
                        obj.BlockedBedNo = dr1.Item("block_bed_no")
                        obj.BedNo = dr1.Item("bed_no")
                        objList.Add(obj)
                    End While
                    GetBedAutoChrgPstngData = objList

                Else
                    GetBedAutoChrgPstngData = Nothing

                End If
                dr1.close()


            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            Finally
                ofactory = Nothing
            End Try
        End Function
        Shared Function SpSelIpPtnVst018(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                          ByRef chrErrFlg As Char,
                                          ByVal CoCd As String,
                                          ByVal Div As Integer,
                                          ByVal Loc As Integer,
                                          ByVal SelDate As Date) As DBRequest

            SpSelIpPtnVst018 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SpSelIpPtnVst018]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pCocd"
                    oParam.ParamValue = CoCd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pDivCd"
                    oParam.ParamValue = Div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pLocCd"
                    oParam.ParamValue = Loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pSelDate"
                    oParam.ParamValue = SelDate
                    .Parameters.Add(oParam)

                End With

                SpSelIpPtnVst018 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpPtnVst018 = Nothing
            End Try

            Return SpSelIpPtnVst018

        End Function
#End Region

#Region "GET ALL IP PATIENT VISIT LIST" 'RasikV 20170601
        Shared Function GetAllIpPatientVisitList(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
               ByVal Div As Integer, ByVal Loc As Integer, ByVal PatientStatus As Integer, ByVal UserId As String) As List(Of clsIpPatientVisit)
            GetAllIpPatientVisitList = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst019(CoCd, Div, Loc, PatientStatus, UserId))
                Dim objList As List(Of clsIpPatientVisit) = Nothing
                If dr1.hasrows Then
                    objList = New List(Of clsIpPatientVisit)
                    While dr1.Read()
                        Dim obj As New clsIpPatientVisit
                        obj.BedNo = IIf(IsDBNull(dr1.Item("bed_no")), Nothing, dr1.Item("bed_no"))
                        obj.ExptdNoDay = IIf(IsDBNull(dr1.Item("exptd_no_day")), 0, dr1.Item("exptd_no_day"))
                        obj.LOS = IIf(IsDBNull(dr1.Item("LOS")), 0, dr1.Item("LOS"))
                        obj.IpNo = IIf(IsDBNull(dr1.Item("ip_no")), 0, dr1.Item("ip_no"))
                        obj.PatientNo = IIf(IsDBNull(dr1.Item("ptn_no")), 0, dr1.Item("ptn_no"))
                        obj.WingdCd = IIf(IsDBNull(dr1.Item("wing_dcd")), Nothing, dr1.Item("wing_dcd"))
                        obj.WarddCd = IIf(IsDBNull(dr1.Item("wrd_dcd")), 0, dr1.Item("wrd_dcd"))
                        obj.RoomNo = IIf(IsDBNull(dr1.Item("rm_no")), Nothing, dr1.Item("rm_no"))
                        obj.BedTypdCd = IIf(IsDBNull(dr1.Item("bed_typ_dcd")), Nothing, dr1.Item("bed_typ_dcd"))
                        obj.CseTypDCd = IIf(IsDBNull(dr1.Item("cse_typ_dcd")), Nothing, dr1.Item("cse_typ_dcd"))
                        obj.DocCd = IIf(IsDBNull(dr1.Item("doc_cd")), 0, dr1.Item("doc_cd"))
                        obj.AdmDt = IIf(IsDBNull(dr1.Item("adm_dt")), Nothing, dr1.Item("adm_dt"))
                        obj.BedTrnsfrReqNo = IIf(IsDBNull(dr1.Item("bed_trnsfr_req_no")), 0, dr1.Item("bed_trnsfr_req_no"))
                        obj.ExpectedDischrgeDate = IIf(IsDBNull(dr1.Item("EXPECTED_DISCHARGE_DATE")), Nothing, dr1.Item("EXPECTED_DISCHARGE_DATE"))
                        obj.ADVSTSCD = IIf(IsDBNull(dr1.Item("adv_sts_cd")), 0, dr1.Item("adv_sts_cd"))
                        obj.DocName = IIf(IsDBNull(dr1.Item("docname")), Nothing, dr1.Item("docname"))
                        obj.AdmittedFlg = IIf(IsDBNull(dr1.Item("admittedflg")), Nothing, dr1.Item("admittedflg"))
                        obj.ptnname = IIf(IsDBNull(dr1.Item("ptnname")), Nothing, dr1.Item("ptnname"))
                        obj.RMK = IIf(IsDBNull(dr1.Item("rmk")), Nothing, dr1.Item("rmk"))
                        obj.CNCLRMK = IIf(IsDBNull(dr1.Item("cnclrmk")), Nothing, dr1.Item("cnclrmk"))
                        obj.PtnClsDcd = IIf(IsDBNull(dr1.Item("ptnclassDcd")), Nothing, dr1.Item("ptnclassDcd"))
                        obj.Ptngender = IIf(IsDBNull(dr1.Item("ptngender")), Nothing, dr1.Item("ptngender"))
                        obj.PtnClsCd = IIf(IsDBNull(dr1.Item("PtnClsCd")), 0, dr1.Item("PtnClsCd"))
                        obj.DschrgStsCd = IIf(IsDBNull(dr1.Item("dschg_sts_cd")), 0, dr1.Item("dschg_sts_cd"))

                        obj.folStsCd = IIf(IsDBNull(dr1.Item("fol_sts_cd")), 0, dr1.Item("fol_sts_cd")) 'Amol Margaj 23/08/2017  for Restirct Doctor Order Entry
                        objList.Add(obj)
                    End While
                End If
                dr1.close()
                GetAllIpPatientVisitList = objList
                ofactory = Nothing
            Catch ex As Exception
                GetAllIpPatientVisitList = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
            Return GetAllIpPatientVisitList
        End Function

        Shared Function SpSelIpPtnVst019(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal PatientStatus As Integer, ByVal UserId As String) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[dbo].[SpSelIpPtnVst019]"  'ip_ptn_vst  bed_typ_mst  bed_mst wing_mst  cse_typ_mst  doc_mst  cd_dcd  DSCHG_ADV  ptn_cls_mst   ptn_mst1
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCocd"
                oParam.ParamValue = CoCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pDiv"
                oParam.ParamValue = Div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pLoc"
                oParam.ParamValue = Loc
                .Parameters.Add(oParam)
                ' adding PatientStatus Amol Margaj 20170608
                oParam = New DBRequest.Parameter
                oParam.ParamName = "pAdmStsCd"
                oParam.ParamValue = PatientStatus
                .Parameters.Add(oParam)

                ' add UserId Pushpa 20180511
                oParam = New DBRequest.Parameter
                oParam.ParamName = "pUserId"
                oParam.ParamValue = UserId
                .Parameters.Add(oParam)

            End With
            Return oRequest
        End Function
#End Region


#Region "GetPatientVisitAndFolioDtls/SpSelIpPtnVst020 : GET PATIENT VISIT DETAILS"
        'PRAGYA : 02-SEP-2017
        Shared Function GetPatientVisitAndFolioDtls(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal CoCd As String,
                                                   ByVal Div As Integer,
                                                   ByVal Loc As Integer,
                                                 ByVal SelDate As Date) As List(Of clsAutoPostFolioChrgs)
            GetPatientVisitAndFolioDtls = Nothing
            Dim ofactory As New DBFactory
            Try
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst020(strErrMsg, chrErrFlg, CoCd, Div, Loc, SelDate))
                Dim objList As New List(Of clsAutoPostFolioChrgs)

                If dr1.hasrows Then
                    While dr1.Read()
                        Dim obj As New clsAutoPostFolioChrgs


                        obj.WingCd = dr1.Item("wing_cd")
                        obj.IpNo = dr1.Item("ip_no")
                        obj.FolNo = dr1.Item("fol_no")
                        obj.ptnclscd = dr1.Item("ptn_cls_cd")
                        obj.bedno = dr1.Item("bed_no")
                        obj.bedtypcd = dr1.Item("bed_typ_cd")
                        obj.wrdcd = dr1.Item("wrd_cd")

                        obj.csetypcd = dr1.Item("cse_typ_cd")
                        obj.doccd = dr1.Item("doc_cd")
                        obj.ptnsrccd = dr1.Item("ptn_src_cd")
                        obj.ptnno = dr1.Item("ptn_no")
                        obj.AdmDt = dr1.Item("adm_dt")
                        'obj.SchemeCd = dr1.Item("SchemeCd") pragya : 21-aug-2017


                        objList.Add(obj)
                    End While
                    GetPatientVisitAndFolioDtls = objList

                Else
                    GetPatientVisitAndFolioDtls = Nothing

                End If
                dr1.close()


            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            Finally
                ofactory = Nothing
            End Try
        End Function

        Shared Function SpSelIpPtnVst020(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                          ByRef chrErrFlg As Char,
                                          ByVal CoCd As String,
                                          ByVal Div As Integer,
                                          ByVal Loc As Integer,
                                          ByVal SelDate As Date) As DBRequest

            SpSelIpPtnVst020 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SpSelIpPtnVst020]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pCocd"
                    oParam.ParamValue = CoCd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pDivCd"
                    oParam.ParamValue = Div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pLocCd"
                    oParam.ParamValue = Loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pSelDate"
                    oParam.ParamValue = SelDate
                    .Parameters.Add(oParam)

                End With

                SpSelIpPtnVst020 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpPtnVst020 = Nothing
            End Try

            Return SpSelIpPtnVst020

        End Function
#End Region


#Region "get patient details by ipno"
        ''' <summary>
        ''' aparna 26 oct 2017
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="IPNO"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Shared Function GetIpPtnDtlsByIp(ByRef strErrMsg As List(Of String),
                                                          ByRef chrErrFlg As Char,
                                                          ByVal companycode As String,
                                                          ByVal div As Integer,
                                                          ByVal loc As Integer, ByVal IPNO As Long
                                                         ) As clspatientdtls
            GetIpPtnDtlsByIp = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST021(companycode, div, loc, IPNO))
                Dim obj As New clspatientdtls
                If dr1.hasrows Then

                    While dr1.Read()
                        obj.BedNo = dr1.Item("bed_no")
                        obj.IpNo = dr1.Item("ip_no")
                        obj.PtnNo = dr1.Item("ptn_no")
                        obj.PtnFstName = dr1.Item("ptn_frst_nm")
                        obj.PtnMName = dr1.Item("ptn_mid_nm")
                        obj.PtnLName = dr1.Item("ptn_lst_nm")
                        obj.BedTypcd = dr1.Item("bed_typ_cd")
                        obj.PtnClsCd = dr1.Item("ptn_cls_cd")
                        obj.PtnClsDCd = dr1.Item("ptn_cls_dcd")
                        obj.AdmDt = IIf(IsDBNull(dr1.Item("adm_dt")), Nothing, dr1.Item("adm_dt"))
                        obj.Sex = dr1.Item("sex")
                        obj.PtnAge = dr1.Item("ptnAge")
                        obj.WingCd = dr1.Item("wing_cd")
                        obj.WardCd = dr1.Item("wrd_cd")
                        obj.WardDCd = dr1.Item("wardDcd")
                        obj.DocCd = dr1.Item("doc_cd")
                        obj.CaseTypCd = dr1.item("cse_typ_cd")
                        obj.PtnSrcCd = dr1.item("ptn_src_cd")
                    End While
                    GetIpPtnDtlsByIp = obj
                End If
                dr1.close()

                ofactory = Nothing
            Catch ex As Exception
                GetIpPtnDtlsByIp = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
            Return GetIpPtnDtlsByIp
        End Function
        Shared Function SPSELIPPTNVST021(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IPNO As Long) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter

            With oRequest
                .Command = "[SPSELIPPTNVST021]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCocd"
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
                oParam.ParamName = "ipno"
                oParam.ParamValue = IPNO
                .Parameters.Add(oParam)

                .CommandType = CommandType.StoredProcedure
            End With
            Return oRequest
        End Function
#End Region



#Region " GET PATIENT VISIT DETAILS WITH ADMISSION STATUS CD 2 & 3"
        ''' <summary>
        ''' APARNA 7 NOV 2017
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="CoCd"></param>
        ''' <param name="Div"></param>
        ''' <param name="Loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetPatientName(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal CoCd As String,
                                                   ByVal Div As Integer,
                                                   ByVal Loc As Integer,
                                                 ByVal IpNo As Long) As String
            GetPatientName = Nothing
            Dim ofactory As New DBFactory
            Try
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst022(strErrMsg, chrErrFlg, CoCd, Div, Loc, IpNo))

                If dr1.hasrows Then
                    While dr1.Read()

                        GetPatientName = dr1.Item("name")

                    End While

                Else
                    GetPatientName = Nothing

                End If
                dr1.close()


            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            Finally
                ofactory = Nothing
            End Try
        End Function

        Shared Function SpSelIpPtnVst022(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                          ByRef chrErrFlg As Char,
                                          ByVal CoCd As String,
                                          ByVal Div As Integer,
                                          ByVal Loc As Integer,
                                           ByVal IpNo As Long) As DBRequest

            SpSelIpPtnVst022 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SpSelIpPtnVst022]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pCocd"
                    oParam.ParamValue = CoCd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pDivCd"
                    oParam.ParamValue = Div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pLocCd"
                    oParam.ParamValue = Loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "ipno"
                    oParam.ParamValue = IpNo
                    .Parameters.Add(oParam)

                End With

                SpSelIpPtnVst022 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpPtnVst022 = Nothing
            End Try

            Return SpSelIpPtnVst022

        End Function
#End Region

#Region " GET PATIENT ADMISSION STATUS LIST"
        ''' <summary>
        ''' APARNA 8 NOV 2017
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="CoCd"></param>
        ''' <param name="Div"></param>
        ''' <param name="Loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetPtnAdmStsList(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal CoCd As String,
                                                   ByVal Div As Integer,
                                                   ByVal Loc As Integer,
                                                 ByVal PtnNo As Long) As List(Of Integer)
            GetPtnAdmStsList = Nothing
            Dim ofactory As New DBFactory
            Try
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst023(strErrMsg, chrErrFlg, CoCd, Div, Loc, PtnNo))
                Dim arrno = New List(Of Integer)
                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1
                            arrno.Add(.Item("adm"))
                        End With
                    End While

                End If
                dr1.close()

                GetPtnAdmStsList = arrno
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            Finally
                ofactory = Nothing
            End Try
        End Function

        Shared Function SpSelIpPtnVst023(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                          ByRef chrErrFlg As Char,
                                          ByVal CoCd As String,
                                          ByVal Div As Integer,
                                          ByVal Loc As Integer,
                                           ByVal PtnNo As Long) As DBRequest

            SpSelIpPtnVst023 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SpSelIpPtnVst023]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pCocd"
                    oParam.ParamValue = CoCd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pDivCd"
                    oParam.ParamValue = Div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pLocCd"
                    oParam.ParamValue = Loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "PtnNo"
                    oParam.ParamValue = PtnNo
                    .Parameters.Add(oParam)

                End With

                SpSelIpPtnVst023 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpPtnVst023 = Nothing
            End Try

            Return SpSelIpPtnVst023

        End Function
#End Region



        '#Region "GetPtnBasicDtlsByIpNo/SpSelIpPtnVst024 : Get the Ptn Name/Bed/Ward/Class/Adm/Disch dt info by passing Ipno"
        '        'PRAGYA :17-nov-2017 
        '        Shared Function GetPtnBasicDtlsByIpNo(ByRef strErrMsg As List(Of String),
        '                                             ByRef chrErrFlg As Char,
        '                                             ByVal Cocd As String,
        '                                             ByVal div As Integer,
        '                                             ByVal loc As Integer,
        '                                             ByVal IpNo As Long) As clsIpDtls
        '            Dim ofactory As New DBFactory

        '            GetPtnBasicDtlsByIpNo = Nothing
        '            Try
        '                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst024(strErrMsg, chrErrFlg, Cocd, div, loc, IpNo))
        '                If dr1.hasrows Then
        '                    While dr1.Read()
        '                        With dr1
        '                            Dim objPtn As New clsIpDtls
        '                            objPtn.IpNo = .Item("IpNo")
        '                            objPtn.PtnNo = .Item("PtnNo")
        '                            objPtn.PtnName = .Item("PtnName")
        '                            objPtn.PtnClsCd = .Item("PtnClsCd")
        '                            objPtn.PtnClsDCd = .Item("PtnClsDesc")
        '                            objPtn.Gender = .Item("Gender")
        '                            objPtn.Age = .Item("AgeYY")
        '                            objPtn.WingCd = .Item("WngCd")
        '                            objPtn.WingDesc = .Item("WngDesc")
        '                            objPtn.WardCd = .Item("WrdCd")
        '                            objPtn.WardDesc = .Item("WardDesc")
        '                            objPtn.BedNo = .Item("BedNo")
        '                            objPtn.DocCd = .Item("DocCd")
        '                            objPtn.DocName = .Item("DocNm")

        '                            GetPtnBasicDtlsByIpNo = objPtn

        '                        End With
        '                    End While
        '                End If
        '                dr1.close()
        '                ofactory = Nothing
        '            Catch ex As Exception
        '                strErrMsg.Add(ex.Message)
        '                chrErrFlg = "Y"
        '                GetPtnBasicDtlsByIpNo = Nothing
        '            Finally
        '                ofactory = Nothing
        '            End Try
        '            Return GetPtnBasicDtlsByIpNo

        '        End Function

        '        Shared Function SpSelIpPtnVst024(ByRef strErrMsg As System.Collections.Generic.List(Of String),
        '                                             ByRef chrErrFlg As Char,
        '                                             ByVal CoCd As String,
        '                                             ByVal Div As Integer,
        '                                             ByVal Loc As Integer,
        '                                             ByVal IpNo As Long) As DBRequest

        '            SpSelIpPtnVst024 = Nothing

        '            Dim oParam As DBRequest.Parameter
        '            Try
        '                Dim oRequest As New DBRequest
        '                With oRequest
        '                    .Command = "[SpSelIpPtnVst024]"
        '                    .CommandType = CommandType.StoredProcedure
        '                    .Transactional = True

        '                    oParam = New DBRequest.Parameter
        '                    oParam.ParamName = "pCOCD"
        '                    oParam.ParamValue = CoCd
        '                    .Parameters.Add(oParam)

        '                    oParam = New DBRequest.Parameter
        '                    oParam.ParamName = "pDIV"
        '                    oParam.ParamValue = Div
        '                    .Parameters.Add(oParam)

        '                    oParam = New DBRequest.Parameter
        '                    oParam.ParamName = "pLOC"
        '                    oParam.ParamValue = Loc
        '                    .Parameters.Add(oParam)

        '                    oParam = New DBRequest.Parameter
        '                    oParam.ParamName = "pIPNO"
        '                    oParam.ParamValue = IpNo
        '                    .Parameters.Add(oParam)

        '                End With

        '                SpSelIpPtnVst024 = oRequest
        '            Catch ex As Exception
        '                strErrMsg.Add(ex.Message)
        '                chrErrFlg = "Y"
        '                SpSelIpPtnVst024 = Nothing
        '            End Try

        '            Return SpSelIpPtnVst024

        '        End Function
        '#End Region

#Region "GetLstAdmtdPtnDtlsByWrdCd/SpSelIpPtnVst025 : Load LIST OF Admitted PtnDtls by passing Wrdcd"
        'Pragya : 17-nov-2017
        Shared Function GetLstAdmtdPtnDtlsByWrdCd(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal CoCd As String,
                                                     ByVal Div As Integer,
                                                     ByVal Loc As Integer,
                                                     ByVal WardCd As Integer) As List(Of clsIpDtls)
            Dim ofactory As New DBFactory

            GetLstAdmtdPtnDtlsByWrdCd = Nothing
            Try
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst025(strErrMsg, chrErrFlg, CoCd, Div, Loc, WardCd))
                Dim arrObjCnclPkgIpDtl = New List(Of clsIpDtls)

                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1
                            Dim objPkg As New clsIpDtls
                            objPkg.BedNo = .Item("BedNo")
                            objPkg.IpNo = .Item("IpNo")
                            objPkg.PtnName = .Item("PtnName")
                            objPkg.DocName = .Item("DocNm")
                            objPkg.Age = .Item("age")
                            objPkg.AdmDt = .Item("AdmDt")

                            arrObjCnclPkgIpDtl.Add(objPkg)
                        End With

                    End While
                End If
                dr1.close()
                GetLstAdmtdPtnDtlsByWrdCd = arrObjCnclPkgIpDtl
                ofactory = Nothing
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                GetLstAdmtdPtnDtlsByWrdCd = Nothing
            Finally
                ofactory = Nothing
            End Try
            Return GetLstAdmtdPtnDtlsByWrdCd

        End Function

        Shared Function SpSelIpPtnVst025(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                             ByRef chrErrFlg As Char,
                                             ByVal CoCd As String,
                                             ByVal Div As Integer,
                                             ByVal Loc As Integer,
                                             ByVal WardCd As Integer) As DBRequest

            SpSelIpPtnVst025 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SpSelIpPtnVst025]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pCOCD"
                    oParam.ParamValue = CoCd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pDIV"
                    oParam.ParamValue = Div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pLOC"
                    oParam.ParamValue = Loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pWrdCd"
                    oParam.ParamValue = WardCd
                    .Parameters.Add(oParam)






                End With

                SpSelIpPtnVst025 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpPtnVst025 = Nothing
            End Try

            Return SpSelIpPtnVst025

        End Function
#End Region




#Region "GetFAPstngPtnBasicDtlsByIpNo / SpSelIpPtnVst026 : GET THE PATIENT DETAILS BY IPNO : EXCLSUSIVELY USED IN FA POSTING"
        'PRAGYA : 22-NOV-2017
        Shared Function GetFAPstngPtnBasicDtlsByIpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As clsFAPstngIpPtnVstDtls

            GetFAPstngPtnBasicDtlsByIpNo = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst026(strErrMsg, chrErrFlg, cocd, div, loc, IpNo))
                Dim objPtn As clsFAPstngIpPtnVstDtls
                objPtn = New clsFAPstngIpPtnVstDtls
                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1
                            objPtn.PtnNo = .Item("PtnNo")
                            objPtn.PtnClsCd = .Item("PtnClsCd")
                            objPtn.PtnBedNo = .Item("BedNo")
                            objPtn.PtnBedTypCd = .Item("BedTypCd")
                            objPtn.PtnWrdCd = .Item("WrdCd")
                            objPtn.PtnDocCd = .Item("DocCd")
                            objPtn.PtnCseTypCd = .Item("CseTypCd")
                            objPtn.PtnSrcCd = .Item("PtnSrcCd")
                            objPtn.PtnAthrtyCd = .Item("ArthyCd")
                            objPtn.PtnEmpNo = .Item("EmpNo")
                            objPtn.PtnArCd = .Item("ArCd")
                            objPtn.PtnCoRefNo = .Item("CoRefNo")
                        End With
                    End While
                    GetFAPstngPtnBasicDtlsByIpNo = objPtn
                End If
                dr1.close()
                ofactory = Nothing
                Return GetFAPstngPtnBasicDtlsByIpNo
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                GetFAPstngPtnBasicDtlsByIpNo = Nothing
                Return Nothing
            End Try
        End Function

        Shared Function SpSelIpPtnVst026(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As DBRequest

            SpSelIpPtnVst026 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SpSelIpPtnVst026]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pCOCD"
                    oParam.ParamValue = cocd
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
                    oParam.ParamName = "pIpno"
                    oParam.ParamValue = IpNo
                    .Parameters.Add(oParam)

                End With

                SpSelIpPtnVst026 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpPtnVst026 = Nothing
            End Try

            Return SpSelIpPtnVst026

        End Function
#End Region





#Region "TO CHECK WHETHER IP BLOCK OTHER BED NO OR NOT"   'RasikV 20180412
        Shared Function FnChkIpBlockOthrBed(ByRef strErrMsg As List(Of String),
                                  ByRef chrErrFlg As Char,
                                  ByVal CoCd As String,
                                  ByVal Div As Integer,
                                  ByVal Loc As Integer,
                                  ByVal IpNo As Long) As Boolean
            Try
                Dim orequest As New DBRequest
                orequest.CommandType = CommandType.Text
                orequest.Command = "SELECT [dbo].[FnChkIpBlockOthrBed]  ('" & CoCd & "', " & Div & ", " & Loc & ", " & IpNo & ") IpBlockOthrBed"
                Dim ofactory As New DBFactory
                Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

                If ds.Tables(0).Rows.Count <> 0 Then
                    FnChkIpBlockOthrBed = ds.Tables(0).Rows(0).Item("IpBlockOthrBed")
                Else
                    FnChkIpBlockOthrBed = False
                End If
                orequest = Nothing
                ofactory = Nothing
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                FnChkIpBlockOthrBed = False
            End Try
            Return FnChkIpBlockOthrBed
        End Function
#End Region


#Region "GetCredalBasicDtlsByIpNo / SpSelIpPtnVst027 : GET THE PATIENT Cardal DETAILS BY IPNO : EXCLSUSIVELY USED IN NIGHT AUDIT"  '' Amol 2018-05-16

        Shared Function GetCredalBasicDtlsByIpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As clsIpPatientCredal

            GetCredalBasicDtlsByIpNo = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst027(strErrMsg, chrErrFlg, cocd, div, loc, IpNo))
                Dim objPtn As clsIpPatientCredal
                objPtn = New clsIpPatientCredal
                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1
                            objPtn.IsCredalAttached = .Item("IsCredalAttached")
                            objPtn.CredalNo = .Item("CredalNo")

                            objPtn.IsCradleBedChargePosting = .Item("IsCradleBedChargePosting")
                            objPtn.CradleBedChargeCd = .Item("CradleBedChargeCd")




                        End With
                    End While
                    GetCredalBasicDtlsByIpNo = objPtn
                End If
                dr1.close()
                ofactory = Nothing
                Return GetCredalBasicDtlsByIpNo
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                GetCredalBasicDtlsByIpNo = Nothing
                Return Nothing
            End Try
        End Function

        Shared Function SpSelIpPtnVst027(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As DBRequest

            SpSelIpPtnVst027 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SPSELIPPTNVST027]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pCocd"
                    oParam.ParamValue = cocd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pDivCd"
                    oParam.ParamValue = div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pLocCd"
                    oParam.ParamValue = loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pIpNo"
                    oParam.ParamValue = IpNo
                    .Parameters.Add(oParam)

                End With

                SpSelIpPtnVst027 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpPtnVst027 = Nothing
            End Try

            Return SpSelIpPtnVst027

        End Function
#End Region



#Region "GetAddmisionDtlsByIpNo / SpSelIpPtnVst028 : GET THE PATIENT ADDMISSION DATE & TIME DETAILS BY IPNO : EXCLSUSIVELY USED IN NIGHT AUDIT"  '' Amol 2018-06-15

        Shared Function GetAddmisionDtlsByIpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As clsIpPatientAddmision

            GetAddmisionDtlsByIpNo = Nothing
            Try
                Dim ofactory As New DBFactory
                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPPTNVST028(strErrMsg, chrErrFlg, cocd, div, loc, IpNo))
                Dim objPtn As clsIpPatientAddmision
                objPtn = New clsIpPatientAddmision
                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1

                            objPtn.AddmissionDate = .Item("adm_dt")
                            objPtn.AddmissionTime = .Item("adm_tm")
                            ''objPtn.DischargeDate = .Item("dschg_dt")
                            ''objPtn.DischargeTime = .Item("dschg_tm")

                        End With
                    End While
                    GetAddmisionDtlsByIpNo = objPtn
                End If
                dr1.close()
                ofactory = Nothing
                Return GetAddmisionDtlsByIpNo
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                GetAddmisionDtlsByIpNo = Nothing
                Return Nothing
            End Try
        End Function

        Shared Function SPSELIPPTNVST028(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal IpNo As Long) As DBRequest

            SPSELIPPTNVST028 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SPSELIPPTNVST028]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pCocd"
                    oParam.ParamValue = cocd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pDivCd"
                    oParam.ParamValue = div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pLocCd"
                    oParam.ParamValue = loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pIpNo"
                    oParam.ParamValue = IpNo
                    .Parameters.Add(oParam)

                End With

                SPSELIPPTNVST028 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SPSELIPPTNVST028 = Nothing
            End Try

            Return SPSELIPPTNVST028

        End Function
#End Region


#Region "Check Today Bed Charge Posted or Not : Amol 2018-08-01"
        Shared Function CheckTodayBedChargePostForPatient(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                              ByRef chrErrFlg As Char,
                                              ByVal CoCd As String,
                                              ByVal Div As Integer,
                                              ByVal Loc As Integer,
                                            ByVal IpNo As Long) As Boolean
            CheckTodayBedChargePostForPatient = False
            Dim ofactory As New DBFactory
            Try

                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCHECKBEDCHARGEPOSTBYIP(strErrMsg, chrErrFlg, CoCd, Div, Loc, IpNo))
                Dim objList As New List(Of clsAutoPostBedChrg)

                If dr1.hasrows Then
                    While dr1.Read()
                        Dim VchNo As Integer = dr1.Item("vch_no")
                        If VchNo <> 0 Then
                            CheckTodayBedChargePostForPatient = True
                        End If
                    End While
                Else
                    CheckTodayBedChargePostForPatient = False
                End If
                dr1.close()
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                Return Nothing
            Finally
                ofactory = Nothing
            End Try
        End Function
        Shared Function SPSELCHECKBEDCHARGEPOSTBYIP(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                          ByRef chrErrFlg As Char,
                                          ByVal CoCd As String,
                                          ByVal Div As Integer,
                                          ByVal Loc As Integer,
                                          ByVal IpNo As Long) As DBRequest

            SPSELCHECKBEDCHARGEPOSTBYIP = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SPSELCHECKBEDCHARGEPOSTBYIP]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pCoCd"
                    oParam.ParamValue = CoCd
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pDivCd"
                    oParam.ParamValue = Div
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pLocCd"
                    oParam.ParamValue = Loc
                    .Parameters.Add(oParam)

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "@pIpNo"
                    oParam.ParamValue = IpNo
                    .Parameters.Add(oParam)

                End With

                SPSELCHECKBEDCHARGEPOSTBYIP = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SPSELCHECKBEDCHARGEPOSTBYIP = Nothing
            End Try

            Return SPSELCHECKBEDCHARGEPOSTBYIP

        End Function
#End Region


    End Class





End Namespace

#Region "CLASS : clsIpDtls : fPatient Basic Dtls"
'PRAGYA :17-nov-2017 
<DataContract()>
Public Class clsIpDtls
    Inherits clsCancelAdmission
    <DataMember()>
    Public Property WingCd() As Integer
    <DataMember()>
    Public Property WingDesc() As String
    <DataMember()>
    Public Property Gender() As String
    <DataMember()>
    Public Property Age() As String
    <DataMember()>
    Public Property DocCd() As Integer
    <DataMember()>
    Public Property DocName() As String
    <DataMember()>
    Public Property AdmDt() As Date
End Class
#End Region


<DataContract()>
Public Class clsIpPtnVst
    Inherits clsPatientHelp
    <DataMember()>
    Public Property AdmissionDt As String
    <DataMember()>
    Public Property Casetype As String
    <DataMember()>
    Public Property DiscahrgeDt As String
    <DataMember()>
    Public Property DiscahrgeSt As String
    <DataMember()>
    Public Property Ptnclass As String
    <DataMember()>
    Public Property Doctor As String
    <DataMember()>
    Public Property Outstanding As Double
    <DataMember()>
    Public Property TotalGrossAmt As Double 'aparna 20151019
    <DataMember()>
    Public Property BillAmt As Double 'RasikV 20180421
    <DataMember()>
    Public Property UnBillAmt As Double 'RasikV 20180421
End Class




Public Class clsPtnVstDtl   'aparna 19 may 2016
    <DataMember()>
    Public Property PatientAdmDt As Date
    <DataMember()>
    Public Property PatientClassCode() As Integer
    <DataMember()>
    Public Property PatientClassDecode() As String
    <DataMember()>
    Public Property PatientName() As String
End Class


#Region "CLASS : clsPtnExtraDetails"
''' <summary>
''' EDIT ADMISSION CLASS
''' </summary>
''' <remarks>PRAGYA : 09-AUG-2016</remarks>

Public Class clsPtnExtraDetails
    ' Inherits clsIpPatientVisit
    <DataMember()>
    Public Property AlotNo() As Integer
    <DataMember()>
    Public Property Surchrge() As Integer
    <DataMember()>
    Public Property CoRefNo() As String
    <DataMember()>
    Public Property MLCCase() As String
    <DataMember()>
    Public Property AdmissionDate() As Date
    <DataMember()>
    Public Property AdmissionTime() As Date
    <DataMember()>
    Public Property Floor As Integer
    <DataMember()>
    Public Property ArDcd As String
    <DataMember()>
    Public Property IsPtnBlackListed() As Boolean
    <DataMember()>
    Public Property PtnLastName() As String
    <DataMember()>
    Public Property PtnFrstName() As String
    <DataMember()>
    Public Property PtnMidName() As String
    <DataMember()>
    Public Property PtnTitleCode() As Integer
    <DataMember()>
    Public Property PtnTitleCodeDesc() As String
    <DataMember()>
    Public Property PtnFullName() As String
    <DataMember()>
    Public Property Gender() As String
    <DataMember()>
    Public Property Mobile() As String
    <DataMember()>
    Public Property EXPDT() As Date
    <DataMember()>
    Public Property ArCd() As Integer
    <DataMember()>
    Public Property EMPNo() As String
    <DataMember()>
    Public Property Email() As String
    <DataMember()>
    Public Property Status() As Boolean
    <DataMember()>
    Public Property FreeFlag() As Char
    <DataMember()>
    Public Property AutoPstFreeFlag() As Char
    '<DataMember()>
    'Public Property IpNo() As Integer
    <DataMember()>
    Public Property IpNo() As Long 'anamika 20160906
    '<DataMember()>
    'Public Property RsvNo() As Integer
    <DataMember()>
    Public Property RsvNo() As Long 'anamika 20160907
    '<DataMember()>
    'Public Property PatientNo() As Integer
    <DataMember()>
    Public Property PatientNo() As Long 'anamika 20160906
    <DataMember()>
    Public Property LocalAdd1() As String
    <DataMember()>
    Public Property LocalAdd2() As String
    <DataMember()>
    Public Property LocalAdd3() As String
    <DataMember()>
    Public Property LocalCity() As Integer
    <DataMember()>
    Public Property LocalCountry() As Integer
    <DataMember()>
    Public Property LocalState() As Integer
    <DataMember()>
    Public Property LocalPin() As String
    <DataMember()>
    Public Property LocalTel() As String
    <DataMember()>
    Public Property AdmDgnosCd() As Integer
    <DataMember()>
    Public Property AdmDgnosDesc() As String
    <DataMember()>
    Public Property MedCseFlg() As String
    <DataMember()>
    Public Property BedNo() As String
    <DataMember()>
    Public Property WingCd() As Integer
    <DataMember()>
    Public Property WardCd() As Integer
    <DataMember()>
    Public Property BedTypCd() As Integer
    <DataMember()>
    Public Property PtnSrcCd() As Integer
    <DataMember()>
    Public Property CseTypCd() As Integer
    <DataMember()>
    Public Property DocCd2() As Integer
    <DataMember()>
    Public Property DocCd() As Integer
    <DataMember()>
    Public Property AddDocCd1() As Integer
    <DataMember()>
    Public Property AddDocCd2() As Integer
    <DataMember()>
    Public Property ExptdNoDays() As Integer
    <DataMember()>
    Public Property PtnClsCd() As Integer
    <DataMember()>
    Public Property AdmStsCd() As Integer
    <DataMember()>
    Public Property AdmCrtDt() As Date
    <DataMember()>
    Public Property AdmCrtTm() As Date
    <DataMember()>
    Public Property UpdtDt() As Date
    <DataMember()>
    Public Property UpdtTm() As Date
    <DataMember()>
    Public Property UpdtUsrId() As String
    <DataMember()>
    Public Property CreateDt() As Date
    <DataMember()>
    Public Property CreateTm() As Date
    <DataMember()>
    Public Property CreateUsrId() As String
    <DataMember()>
    Public Property PrefCls() As Integer
    <DataMember()>
    Public Property CseTypDCd() As String
    <DataMember()>
    Public Property BedTypdCd() As String
    <DataMember()>
    Public Property WingdCd() As String
    <DataMember()>
    Public Property WarddCd() As String
    <DataMember()>
    Public Property ExptdNoDay() As Integer
    <DataMember()>
    Public Property PtnClsDcd() As String
    <DataMember()>
    Public Property RoomNo() As String
    <DataMember()>
    Public Property Age() As String
    <DataMember()>
    Public Property EligibleCls() As Integer
    <DataMember()>
    Public Property ConsentOfDataShare() As Boolean
    <DataMember()>
    Public Property DepositRemark() As String
    <DataMember()>
    Public Property CampCd() As Integer
    <DataMember()>
    Public Property MobileNumber2() As String
    <DataMember()>
    Public Property WhatsAppNo() As String
    <DataMember()>
    Public Property Bithdate As Date 'Pramila 20jan2017
    <DataMember()>
    Public Property Agemm As Integer 'Pramila 20jan2017
    <DataMember()>
    Public Property Agedd As Integer 'Pramila 20jan2017
    <DataMember()>
    Public Property Aadhar As Char  'Pramila 20jan2017
    <DataMember()>
    Public Property DefaultDietType() As Integer  'pragya : 06-feb-2017

    <DataMember()>
    Public Property PtnRefByTyp As Integer 'APARNA : 29 MAR 2017
    <DataMember()>
    Public Property PtnRefByCd As Integer 'APARNA : 29 MAR 2017

    <DataMember()>
    Public Property CsltyClncCd() As Integer 'APARNA : 29 MAR 2017
    <DataMember()>
    Public Property CsltyVstNo() As Integer 'APARNA : 29 MAR 2017
    <DataMember()>
    Public Property CaseManagerCd As Integer 'APARNA : 26 MAY 2017
    <DataMember()>
    Public Property CoordinatorCd As Integer 'APARNA : 26 MAY 2017
    <DataMember()>
    Public Property SubCseTypCd As Integer 'anamika 20170714
End Class
#End Region

<DataContract()>
Public Class clsCancelAdmission 'anamika 20160520
    '<DataMember()>
    'Public Property IpNo As Integer
    '<DataMember()>
    'Public Property PtnNo As Integer 'anamika 20160822
    <DataMember()>
    Public Property IpNo As Long 'anamika 20160914
    <DataMember()>
    Public Property PtnNo As Long 'anamika 20160914
    <DataMember()>
    Public Property PtnName As String
    <DataMember()>
    Public Property PtnClsCd As Integer
    <DataMember()>
    Public Property PtnClsDCd As String
    <DataMember()>
    Public Property ptnDoccd As Integer
    <DataMember()>
    Public Property ptnDocName As String
    <DataMember()>
    Public Property Remark As String
    <DataMember()>
    Public Property WardCd As Integer
    <DataMember()>
    Public Property WardDesc As String
    <DataMember()>
    Public Property BedNo As String
End Class

Public Class clsDiscSummFreezingDtl 'anamika 20160831
    '<DataMember()>  'aparna 22 sep 2016
    'Public Property PatientNo() As Integer
    <DataMember()>
    Public Property PatientNo() As Long
    '<DataMember()> 'aparna 22 sep 2016
    'Public Property IpNo() As Integer
    <DataMember()>
    Public Property IpNo() As Long

    <DataMember()>
    Public Property PatientFullName() As String
    <DataMember()>
    Public Property Gender() As String
    <DataMember()>
    Public Property Age() As String

    <DataMember()>
    Public Property BedNo() As String
    <DataMember()>
    Public Property Status() As Integer
    <DataMember()>
    Public Property StatusDesc() As String
    <DataMember()>
    Public Property mobile() As String
    <DataMember()>
    Public Property WardCd() As Integer
    <DataMember()>
    Public Property WardDCd() As String
    <DataMember()>
    Public Property IsDataFreezed() As Char


End Class

Public Class clsPtnDtl 'RasikV 20161005
    <DataMember()>
    Public Property PtnName As String
    <DataMember()>
    Public Property PtnNo As Long
End Class



#Region "CLASS : clsPtnVstPtnClsDtl"
Public Class clsPtnVstPtnClsDtl   'Pragya  14-oct-2016
    <DataMember()>
    Public Property PtnNo() As Long
    <DataMember()>
    Public Property PtnClsCd() As Integer

End Class
#End Region

#Region "CLASS : clsPtnAllDtls with Arcd/ArDesc/PtnClsCd/PtnClsDesc/BedTypCd/CseTypCd/CseTypDesc/SrchgCd/SrchgDesc/SrchgPer/PtnSrcCd/PtnSrcDesc"
'PRAGYA : 12-NOV-2016
Public Class clsPtnAllDtls
    Inherits clsInPatientHelp
    <DataMember()>
    Public Property PtnClsCd() As Integer
    <DataMember()>
    Public Property PtnClsDesc() As String
    <DataMember()>
    Public Property ArCd() As Integer
    <DataMember()>
    Public Property ArDesc() As String
    <DataMember()>
    Public Property BedTypCd() As Integer
    <DataMember()>
    Public Property CseTypCd() As Integer
    <DataMember()>
    Public Property CseTypDesc() As String
    <DataMember()>
    Public Property SrchgCd() As Integer
    <DataMember()>
    Public Property SrchgDesc() As String
    <DataMember()>
    Public Property SrchgPer() As Double
    <DataMember()>
    Public Property PtnSrcCd() As Integer
    <DataMember()>
    Public Property PtnSrcDesc() As String
    <DataMember()>
    Public Property WingCd() As Integer
    <DataMember()>
    Public Property WingDesc() As String
End Class
#End Region

'anamika 20170519
Public Class clsAutoPostBedChrg 'class used from auto bed charge posting
    <DataMember()>
    Public Property BedTypeCode As Integer
    <DataMember()>
    Public Property ArCd As Integer
    <DataMember()>
    Public Property WingCd As Integer
    <DataMember()>
    Public Property IpNo As Long
    <DataMember()>
    Public Property FolNo As Integer
    <DataMember()>
    Public Property BedNo As String
    <DataMember()>
    Public Property WardCd As Integer
    <DataMember()>
    Public Property CseTypCd As Integer
    <DataMember()>
    Public Property DocCd As Integer
    <DataMember()>
    Public Property PtnSrcCd As Integer
    <DataMember()>
    Public Property PtnClsCd As Integer
    <DataMember()>
    Public Property AdmissionDate As Date
    <DataMember()>
    Public Property BlockedBedNo As String

End Class



<DataContract()>
Public Class clspatientdtls 'aparna 26 oct 2017
    <DataMember()>
    Public Property IpNo As Long
    <DataMember()>
    Public Property PtnNo As Long
    <DataMember()>
    Public Property PtnFstName As String
    <DataMember()>
    Public Property PtnMName As String
    <DataMember()>
    Public Property PtnLName As String
    <DataMember()>
    Public Property BedTypcd As Integer
    <DataMember()>
    Public Property BedNo As String
    <DataMember()>
    Public Property PtnClsCd As Integer
    <DataMember()>
    Public Property PtnClsDCd As String
    <DataMember()>
    Public Property AdmDt As Date
    <DataMember()>
    Public Property Sex As String
    <DataMember()>
    Public Property PtnAge As String
    <DataMember()>
    Public Property WardCd As Integer
    <DataMember()>
    Public Property WardDCd As String
    <DataMember()>
    Public Property CaseTypCd As Integer
    <DataMember()>
    Public Property WingCd As Integer
    <DataMember()>
    Public Property PtnSrcCd As Integer
    <DataMember()>
    Public Property DocCd As Integer
End Class


#Region "CLASS : clsFAPstngIpPtnVstDtls   {EXCLUSIVELY USED IN FA POSTING FOR PTN BASIC DETAILS}"
'pragya : 22-nov-2017
<DataContract>
Public Class clsFAPstngIpPtnVstDtls
    <DataMember()>
    Public Property IpNo() As Long
    <DataMember()>
    Public Property PtnNo() As Long
    <DataMember()>
    Public Property PtnClsCd() As Integer
    <DataMember()>
    Public Property PtnBedNo() As String
    <DataMember()>
    Public Property PtnBedTypCd() As Integer
    <DataMember()>
    Public Property PtnWrdCd() As Integer
    <DataMember()>
    Public Property PtnDocCd() As Integer
    <DataMember()>
    Public Property PtnCseTypCd() As Integer
    <DataMember()>
    Public Property PtnSrcCd() As Integer
    <DataMember()>
    Public Property PtnAthrtyCd() As Integer
    <DataMember()>
    Public Property PtnEmpNo() As String
    <DataMember()>
    Public Property PtnArCd() As Integer
    <DataMember()>
    Public Property PtnCoRefNo() As String
End Class
#End Region


Public Class clsIpPatientCredal   'Amol 2018-05-16
    <DataMember()>
    Public Property IsCredalAttached As Char
    <DataMember()>
    Public Property CredalNo As String
    <DataMember()>
    Public Property IsCradleBedChargePosting As Boolean
    <DataMember()>
    Public Property CradleBedChargeCd As Integer
End Class

Public Class clsIpPatientAddmision   'Amol 2018-06-15
    <DataMember()>
    Public Property AddmissionDate As Date
    <DataMember()>
    Public Property AddmissionTime As DateTime
    <DataMember()>
    Public Property DischargeDate As Date
    <DataMember()>
    Public Property DischargeTime As DateTime

End Class
