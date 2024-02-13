Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
''' <summary>
'''  Entity Class of Patient Master
''' </summary>
''' <remarks></remarks>
<DataContract()>
Public Class clsPatient

    '<DataMember()>
    'Public Property PatientNo() As Integer
    <DataMember()>
    Public Property PatientNo() As Long 'anamika 20160902
    <DataMember()>
    Public Property PatientTitleCode() As Integer
    <DataMember()>
    Public Property PatientTitleCodeDesc() As String
    <DataMember()>
    Public Property PatientFirstName() As String
    <DataMember()>
    Public Property PatientMiddleName() As String
    <DataMember()>
    Public Property PatientLastName() As String
    <DataMember()>
    Public Property PatientFullName() As String
    <DataMember()>
    Public Property Gender() As String
    <DataMember()>
    Public Property BirthDate() As Nullable(Of Date)
    <DataMember()>
    Public Property Age() As String
    <DataMember()>
    Public Property AgeYY() As Integer 'anamika 20131210
    '<DataMember()>
    'Public Property InPatientNo() As Integer
    <DataMember()>
    Public Property InPatientNo() As Long 'anamika 20160907
    <DataMember()>
    Public Property DayCareNo() As Integer
    <DataMember()>
    Public Property Status() As Boolean
    <DataMember()>
    Public Property IsMember() As Boolean
    <DataMember()>
    Public Property MembershipID() As String
    <DataMember()>
    Public Property MRNo() As Integer
    <DataMember()>
    Public Property EMPNo() As String
    <DataMember()>
    Public Property NtnltyCd() As Integer
    <DataMember()>
    Public Property DocCd() As Integer
    <DataMember()>
    Public Property MobileNumber() As String
    <DataMember()>
    Public Property MobileNumber2() As String 'anamika 20160802
    <DataMember()>
    Public Property WhatsAppNo() As String 'anamika 20160802
    <DataMember()>
    Public Property Email() As String
    <DataMember()>
    Public Property CrtDtTm() As Date
    <DataMember()>
    Public Property VisitCompletedTm() As Date
    'mayur 20131220
    <DataMember()>
    Public Property SSno() As String
    <DataMember()>
    Public Property peraddress1() As String
    <DataMember()>
    Public Property prmnt_addrs2() As String
    <DataMember()>
    Public Property prmnt_pin() As String

    <DataMember()>
    Public Property prmnt_tel() As String
    <DataMember()>
    Public Property prmnt_cntry() As Integer 'String datatype changed to integer 'anamika 20150703(table level changes)
    <DataMember()>
    Public Property city() As String
    'end mayur 20131220
    'mayur 20140107
    <DataMember()>
    Public Property BillTyp() As Integer
    <DataMember()>
    Public Property TYPFLG() As String
    <DataMember()>
    Public Property EXPDT() As Date
    <DataMember()>
    Public Property UserDtTm() As Date
    <DataMember()>
    Public Property UserId() As String
    <DataMember()>
    Public Property ArCd() As Long
    'end 20140107
    'mayur 20140117
    <DataMember()>
    Public Property prmnt_addrs3() As String
    <DataMember()>
    Public Property Agemm() As Integer
    <DataMember()>
    Public Property Agedd() As Integer
    <DataMember()>
    Public Property cityCode() As Integer
    <DataMember()>
    Public Property StateCode() As Integer
    'end mayur 20140117
    <DataMember()>
    Public Property VisitNo As Integer 'anamika 20140121
    <DataMember()>
    Public Property FreeFlg As String 'anamika 20140122
    <DataMember()>
    Public Property ClncCd As Integer 'anamika 20140123
    <DataMember()>
    Public Property VchrNo As Integer 'anamika 20140123
    <DataMember()>
    Public Property TokenNo As String  'anamika 20140127
    <DataMember()>
    Public Property DepositBal As Double  'anamika 20140225
    <DataMember()>
    Public Property IsPtnBlackListed() As Boolean 'anamika 20160802
    '<DataMember()>
    'Public Property Aadhar As String 'Pramila 20jan2017
    <DataMember()>
    Public Property Aadhar As Char 'Pramila 20jan2017
    <DataMember()>
    Public Property CseTypCd As Integer 'Pramila 05Jun2017
    <DataMember()>
    Public Property PanNo As String 'RasikV 20180113
    <DataMember()>
    Public Property Address As String 'RasikV 20180113
    <DataMember()>
    Public Property ArEmpcd As String 'Rushikesh 20190731
    <DataMember()>
    Public Property PtnRefByTyp As Integer 'Rushikesh 20190731
    <DataMember()>
    Public Property PtnRefBycd As String 'Rushikesh 20190731

    <DataMember()>
    Public Property PtnBlackListedRsn As String 'shital 20191220

    <DataMember()>
    Public Property PtnRmrk As String 'Nikita 20200117
    <DataMember()>
    Public Property CampCd As Integer

    <DataMember()>
    Public Property MapConcType As Integer  'Amol 24-03-2020 CMCH-141969

    <DataMember()>
    Public Property Agetypflg As String


    <DataMember()>
    Public Property istranblocked As Integer


    <DataMember()>
    Public Property PtnCareModelRmrk As String


    <DataMember()>
    Public Property PtnCareModelDCd As String

    <DataMember()>
    Public Property PtnCareModelDescRmrk As String

    <DataMember()>
    Public Property PtnType As String

    <DataMember()>
    Public Property PrmntPtnno As Int64

    <DataMember()>
    Public Property BillType() As Integer
    <DataMember()>
    Public Property NRI() As Char
    <DataMember()>
    Public Property RegTypFlg() As Char



#Region "Functions"
    'anamika 20130831
    ''' <summary>
    ''' Get list of not Admitted Patients(we can make conditional search)
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetNotAdmittedPatientList(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal companycode As String,
                                                      ByVal div As Integer,
                                                      ByVal loc As Integer,
                                                      Optional ByVal FirstNm As String = "",
                                                      Optional ByVal MiddleNm As String = "",
                                                      Optional ByVal LastNm As String = "",
                                                      Optional ByVal AdditionalCriteria As String = ""
                                                     ) As List(Of clsPatient)
        GetNotAdmittedPatientList = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELPTNMST002(companycode, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria))
            Dim objPatientlist As List(Of clsPatient) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsPatient)
                While dr1.Read()
                    With dr1
                        Dim objPatient As New clsPatient

                        objPatient.PatientNo = .Item("PatientNo")
                        objPatient.PatientFirstName = .Item("PatientFirstName")
                        objPatient.PatientMiddleName = .Item("PatientMiddleName")
                        objPatient.PatientLastName = .Item("PatientLastName")
                        objPatient.PatientFullName = .Item("PatientFullName")
                        objPatient.PatientTitleCode = .Item("PatientTitleCode")
                        objPatient.PatientTitleCodeDesc = .Item("PatientTitleCodeDesc")
                        objPatient.Status = .Item("Status")
                        '    objPatient.Gender = IIf(.Item("Gender") = "M", "Male", "Female") 'anamika 20130813
                        objPatient.Gender = .Item("Gender")  'anamika 20160120
                        objPatient.BirthDate = IIf(IsDBNull(.Item("BirthDate")), Nothing, .Item("BirthDate"))
                        objPatient.InPatientNo = .Item("InPatientNo")
                        objPatient.DayCareNo = 0
                        objPatient.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                        objPatient.IsMember = .Item("IsMember")
                        objPatient.MembershipID = .Item("MembershipID")
                        objPatient.MRNo = IIf(IsDBNull(.Item("MRNo")), 0, .Item("MRNo"))
                        objPatient.EMPNo = IIf(.Item("EMPNo") = "", 0, .Item("EMPNo"))
                        objPatient.MobileNumber = IIf(IsDBNull(.Item("mobile")), "", .Item("mobile")) 'anamika 20130814
                        objPatient.Email = IIf(.Item("email") = "", "", .Item("email"))  'anamika 20130814
                        objPatientlist.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            GetNotAdmittedPatientList = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetNotAdmittedPatientList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' Get list of not Admitted Patients(we can make conditional search)
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FirstNm"></param>
    ''' <param name="MiddleNm"></param>
    ''' <param name="LastNm"></param>
    ''' <param name="AdditionalCriteria"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELPTNMST002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FirstNm As String, ByVal MiddleNm As String, ByVal LastNm As String, ByVal AdditionalCriteria As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELPTNMST002]" 'cd_dcd

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
            oParam.ParamName = "PFSTNAME"
            oParam.ParamValue = FirstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMIDNAME"
            oParam.ParamValue = MiddleNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLSTNAME"
            oParam.ParamValue = LastNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdditionalParameter"
            oParam.ParamValue = AdditionalCriteria
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function

    '20130831

    ''' <summary>
    ''' Gets list of all patients 
    ''' format of Full name has been modified FML 'Manisha 20130829
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetPatientList(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal companycode As String,
                                                      ByVal div As Integer,
                                                      ByVal loc As Integer
                                                     ) As List(Of clsPatient)
        GetPatientList = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELPTNMST(companycode, div, loc))
            Dim objPatientlist As List(Of clsPatient) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsPatient)
                While dr1.Read()
                    With dr1
                        Dim objPatient As New clsPatient
                        'objPatient.CompanyCode = companycode
                        'objPatient.DivisionCode = div
                        'objPatient.LocationCode = loc
                        objPatient.PatientNo = .Item("PatientNo")
                        objPatient.PatientFirstName = .Item("PatientFirstName")
                        objPatient.PatientMiddleName = .Item("PatientMiddleName")
                        objPatient.PatientLastName = .Item("PatientLastName")
                        objPatient.PatientFullName = .Item("PatientFullName")
                        objPatient.PatientTitleCode = .Item("PatientTitleCode")
                        objPatient.PatientTitleCodeDesc = .Item("PatientTitleCodeDesc")
                        objPatient.Status = .Item("Status")
                        '  objPatient.Gender = IIf(.Item("Gender") = "M", "Male", "Female") 'anamika 20130813
                        objPatient.Gender = .Item("Gender")
                        objPatient.BirthDate = IIf(IsDBNull(.Item("BirthDate")), Nothing, .Item("BirthDate"))
                        objPatient.InPatientNo = .Item("InPatientNo")
                        objPatient.DayCareNo = 0
                        objPatient.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                        objPatient.IsMember = .Item("IsMember")
                        objPatient.MembershipID = .Item("MembershipID")
                        objPatient.MRNo = IIf(IsDBNull(.Item("MRNo")), 0, .Item("MRNo"))
                        objPatient.EMPNo = IIf(.Item("EMPNo") = "", 0, .Item("EMPNo"))
                        objPatient.MobileNumber = IIf(IsDBNull(.Item("mobile")), "", .Item("mobile")) 'anamika 20130814
                        objPatient.Email = IIf(.Item("email") = "", "", .Item("email"))  'anamika 20130814
                        objPatientlist.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            GetPatientList = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetPatientList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    ''' <summary>
    ''' Get patient details
    ''' format of Full name has been modified FML 'Manisha 20130829
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="patientno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Shared Function GetPatient(ByRef strErrMsg As List(Of String), _
    '                                                  ByRef chrErrFlg As Char, _
    '                                                  ByVal companycode As String, _
    '                                                  ByVal div As Integer, _
    '                                                  ByVal loc As Integer, _
    '                                                  ByVal patientno As Integer) As clsPatient
    Shared Function GetPatient(ByRef strErrMsg As List(Of String),
                                                  ByRef chrErrFlg As Char,
                                                  ByVal companycode As String,
                                                  ByVal div As Integer,
                                                  ByVal loc As Integer,
                                                  ByVal patientno As Long) As clsPatient 'anamika 20160905
        GetPatient = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELPTNMST001(companycode, div, loc, patientno))
            Dim objPatient As clsPatient = Nothing
            If dr1.hasrows Then
                dr1.read()
                With dr1
                    objPatient = New clsPatient
                    'objPatient.CompanyCode = companycode
                    'objPatient.DivisionCode = div
                    'objPatient.LocationCode = loc
                    objPatient.PatientNo = .Item("PatientNo")
                    objPatient.PatientFirstName = .Item("PatientFirstName")
                    objPatient.PatientMiddleName = .Item("PatientMiddleName")
                    objPatient.PatientLastName = .Item("PatientLastName")
                    objPatient.PatientFullName = .Item("PatientFullName")
                    objPatient.PatientTitleCode = .Item("PatientTitleCode")
                    objPatient.PatientTitleCodeDesc = .Item("PatientTitleCodeDesc")
                    objPatient.Status = .Item("Status")
                    objPatient.Gender = .Item("Gender")
                    objPatient.BirthDate = IIf(IsDBNull(.Item("BirthDate")), Nothing, .Item("BirthDate"))
                    objPatient.InPatientNo = .Item("InPatientNo")
                    objPatient.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                    objPatient.AgeYY = IIf(IsDBNull(.Item("AgeYY")), 0, .Item("AgeYY")) 'anamika 20131012
                    objPatient.DayCareNo = 0
                    objPatient.IsMember = .Item("IsMember")
                    objPatient.MembershipID = .Item("MembershipID")
                    objPatient.MRNo = IIf(IsDBNull(.Item("MRNo")), 0, .Item("MRNo"))
                    objPatient.EMPNo = IIf(.Item("EMPNo") = "", 0, .Item("EMPNo"))
                    objPatient.MobileNumber = IIf(IsDBNull(.Item("mobile")), "", .Item("mobile")) 'anamika 20130814
                    objPatient.Email = IIf(.Item("email") = "", "", .Item("email"))  'anamika 20130814
                    'mayur 20131220

                    ''mayur 20131012
                    objPatient.SSno = IIf(.Item("SSno") = "", "", .Item("SSno"))
                    objPatient.peraddress1 = IIf(.Item("prmnt_addrs1") = "", "", .Item("prmnt_addrs1"))
                    objPatient.prmnt_addrs2 = IIf(.Item("prmnt_addrs2") = "", "", .Item("prmnt_addrs2"))
                    objPatient.prmnt_pin = IIf(.Item("prmnt_pin") = "", "", .Item("prmnt_pin"))
                    objPatient.prmnt_tel = IIf(.Item("prmnt_tel") = "", "", .Item("prmnt_tel"))
                    '  objPatient.prmnt_cntry = IIf(.Item("prmnt_cntry") = "", "", .Item("prmnt_cntry"))
                    objPatient.prmnt_cntry = IIf(.Item("prmnt_cntry") = 0, 0, .Item("prmnt_cntry")) 'anamika 20150703
                    objPatient.city = IIf(.Item("city") = "", "", .Item("city"))
                    ''mayur 20131012
                    'end mayur 20140108
                    objPatient.ArCd = .Item("arcd")
                    objPatient.TYPFLG = .Item("TYPFLG")
                    objPatient.EXPDT = .Item("EXPDT")
                    objPatient.Status = .Item("Status")
                    objPatient.BillTyp = .Item("billtyp")
                    'end mayur 20140108
                    'mayur 20140117
                    objPatient.prmnt_addrs3 = IIf(.Item("prmnt_addrs3") = "", "", .Item("prmnt_addrs3"))
                    'objPatient.cityCode = IIf(.Item("prmnt_city") = "", 0, .Item("prmnt_city"))
                    objPatient.cityCode = .Item("prmnt_city") 'anamika 20150703
                    objPatient.StateCode = .Item("StateCd")
                    objPatient.Agemm = .Item("age_mm")  ' IIf(.Item("age_mm"), 0, .Item("age_mm")) 'anamika 20140522
                    objPatient.Agedd = .Item("age_dd")   'IIf(.Item("age_dd"), 0, .Item("age_dd"))  'anamika 20140522
                    'mayur 20140117
                    objPatient.MobileNumber2 = .Item("mobile2") 'anamika 20160802
                    objPatient.WhatsAppNo = .Item("WhatsAppNo")  'anamika 20160802
                    objPatient.IsPtnBlackListed = .Item("IsPtnBlackListed")  'anamika 20160802
                    objPatient.Aadhar = .Item("aadhar_no")  'Pramila 20jan2017
                    objPatient.CseTypCd = IIf(IsDBNull(.Item("cse_typ_cd")), 0, .Item("cse_typ_cd")) 'Pramila 20jan2017

                End With
            End If
            dr1.close()
            GetPatient = objPatient
            ofactory = Nothing
        Catch ex As Exception
            GetPatient = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    'anamika 20130615
    ''' <summary>
    ''' function used to retrieve patient list by passing patient full name or first,middle or sirname .it also pass particular criteria to additional parameter
    ''' format of Full name has been modified FML 'Manisha 20130829
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetPatientListByNameAndOtherParameter(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal companycode As String,
                                                      ByVal div As Integer,
                                                      ByVal loc As Integer,
                                                      Optional ByVal FirstNm As String = "",
                                                      Optional ByVal MiddleNm As String = "",
                                                      Optional ByVal LastNm As String = "",
                                                      Optional ByVal AdditionalCriteria As String = "", Optional ByVal AdharNo As String = Nothing,
                                                      Optional ByVal PanNo As String = Nothing,
                                                      Optional ByVal Address As String = Nothing
                                                     ) As List(Of clsPatient)
        GetPatientListByNameAndOtherParameter = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELPTNMSTBYNAME(companycode, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria, AdharNo, PanNo, Address))
            Dim objPatientlist As List(Of clsPatient) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsPatient)
                While dr1.Read()
                    With dr1
                        Dim objPatient As New clsPatient
                        'objPatient.CompanyCode = companycode
                        'objPatient.DivisionCode = div
                        'objPatient.LocationCode = loc
                        objPatient.PatientNo = .Item("PatientNo")
                        objPatient.PatientFirstName = .Item("PatientFirstName")
                        objPatient.PatientMiddleName = .Item("PatientMiddleName")
                        objPatient.PatientLastName = .Item("PatientLastName")
                        objPatient.PatientFullName = .Item("PatientFullName")
                        objPatient.PatientTitleCode = .Item("PatientTitleCode")
                        objPatient.PatientTitleCodeDesc = .Item("PatientTitleCodeDesc")
                        objPatient.Status = .Item("Status")
                        objPatient.Gender = .Item("Gender")
                        'If UCase(objPatient.Gender) = "M" Then 'anamika 20160120
                        '    objPatient.Gender = "Male"
                        'Else
                        '    objPatient.Gender = "Female"
                        'End If
                        objPatient.BirthDate = IIf(IsDBNull(.Item("BirthDate")), Nothing, .Item("BirthDate"))
                        objPatient.InPatientNo = .Item("InPatientNo")
                        objPatient.DayCareNo = 0
                        objPatient.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                        objPatient.IsMember = .Item("IsMember")
                        objPatient.MembershipID = .Item("MembershipID")
                        objPatient.MRNo = IIf(IsDBNull(.Item("MRNo")), 0, .Item("MRNo"))
                        objPatient.EMPNo = IIf(.Item("EMPNo") = "", 0, .Item("EMPNo"))
                        '  objPatient.MobileNumber = IIf(.item("mobile") = "", 0, .item("mobile")) 'anamika 20130617
                        objPatient.MobileNumber = IIf(IsDBNull(.Item("mobile")), "", .Item("mobile")) 'anamika 20130814
                        objPatient.Email = IIf(.Item("email") = "", "", .Item("email"))  'anamika 20130814
                        objPatient.Aadhar = IIf(IsDBNull(.Item("AadharNo")), "", .Item("AadharNo"))    'RasikV 20180113
                        objPatient.PanNo = IIf(IsDBNull(.Item("PanNo")), "", .Item("PanNo"))    'RasikV 20180113
                        objPatient.Address = IIf(IsDBNull(.Item("Address")), "", .Item("Address"))    'RasikV 20180113
                        objPatientlist.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            GetPatientListByNameAndOtherParameter = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetPatientListByNameAndOtherParameter = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    'end 20130615
    'anamika 20130617
    ''' <summary>
    ''' Get op  patient visit list.you can filter record by passing doctor code from date and to date
    ''' Get All Patients Visited By Doctor   (visit completed i.e. vstCompleted_tm is null ) 
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FromDate"></param>
    ''' <param name="ToDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    ''' <summary>
    ''' Get All Patients Visited By Doctor   (visit not completed i.e. vstCompleted_tm is not null )
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="DoctorCode"></param>
    ''' <param name="FromDate"></param>
    ''' <param name="ToDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    '20130617
    ''' <summary>
    ''' SPSELPTNMSTBYNAME to retrieve patient details depending on patient name.you can also pass additional criteria 
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELPTNMSTBYNAME(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FirstNm As String, ByVal MiddleNm As String, ByVal LastNm As String, ByVal AdditionalCriteria As String, Optional ByVal AdharNo As String = Nothing,
      Optional ByVal PanNo As String = Nothing, Optional ByVal Address As String = Nothing) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELPTNMSTBYNAME]" 'ptn_mst1,cd_dcd

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
            oParam.ParamName = "PFSTNAME"
            oParam.ParamValue = FirstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMIDNAME"
            oParam.ParamValue = MiddleNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLSTNAME"
            oParam.ParamValue = LastNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdditionalParameter"
            oParam.ParamValue = AdditionalCriteria
            .Parameters.Add(oParam)



            'RasikV 20180113 - Start Here
            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdharNo"
            oParam.ParamValue = AdharNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PPanNo"
            oParam.ParamValue = PanNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAddress"
            oParam.ParamValue = Address
            .Parameters.Add(oParam)
            'RasikV 20180113 - End Here
            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function

    ''' <summary>
    ''' adds paramters to store procedure SPSELPTNMST001
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="patientno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Shared Function SPSELPTNMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal patientno As Long) As DBRequest 'anamika 20160905
        'Shared Function SPSELPTNMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal patientno As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELPTNMST001]" 'ptn_mst1,CD_DCD

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
            oParam.ParamName = "pptnno"
            oParam.ParamValue = patientno
            .Parameters.Add(oParam)


            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function

    ''' <summary>
    '''  adds paramters to store procedure SPSELPTNMST
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELPTNMST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELPTNMST]" 'ptn_mst1 cd_dcd

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

    ''' <summary>
    ''' Gets Patient fullname in standard format
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="patientno"></param>
    ''' <returns>PatientFullName</returns>
    ''' <remarks></remarks>

    Shared Function GetPatientFullName(ByRef strErrMsg As List(Of String),
                              ByRef chrErrFlg As Char,
                              ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                              ByVal patientno As Long) As String
        GetPatientFullName = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .CommandType = CommandType.Text


                .Command = "SELECT dbo.[fn_IpOPName] (@IPOP ,@IPOPNo)" 'Ptn_Mst1 ip_pn_vst cd_dcd

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@IPOP"
                oParam.ParamValue = "O"
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@IPOPNo"
                oParam.ParamValue = patientno
                .Parameters.Add(oParam)


            End With
            Dim dr As Object = ofactory.ExecuteDataReader(oRequest)

            If dr.hasrows Then
                dr.read()
                GetPatientFullName = dr.item(0)
            End If
            dr.close()
            oRequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            GetPatientFullName = ""
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function


#End Region


#Region "Get Patient list by Mobile No."
    Shared Function GetPtnDtlByMobNoDetails(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal MobNo As String) As List(Of clsPtnBasicInfo)
        GetPtnDtlByMobNoDetails = Nothing
        Dim ofactory As New DBFactory

        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSelPtnMst1010(CoCd, Div, Loc, MobNo))

            Dim objPatientDet As List(Of clsPtnBasicInfo) = Nothing
            objPatientDet = New List(Of clsPtnBasicInfo)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim objPatientDet1 As New clsPtnBasicInfo
                        objPatientDet1.PatientNo = .Item("PtnNo")

                        objPatientDet1.PatientTitleCodeDesc = .Item("TitleCode")

                        objPatientDet1.PatientFirstName = .Item("PtnFirstName")
                        objPatientDet1.PatientMiddleName = .Item("PtnMiddleName")
                        objPatientDet1.PatientLastName = .Item("PtnLastName")


                        objPatientDet1.PatientFullName = .Item("PtnFullName")
                        objPatientDet1.Gender = dr1.Item("Gender")
                        objPatientDet1.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                        objPatientDet1.Address = IIf(IsDBNull(.Item("Address")), Nothing, .Item("Address"))
                        objPatientDet.Add(objPatientDet1)
                    End With
                End While

            End If

            dr1.close()

            GetPtnDtlByMobNoDetails = objPatientDet

            ofactory = Nothing

        Catch ex As Exception
            GetPtnDtlByMobNoDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    Shared Function SPSelPtnMst1010(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal MobNo As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSelPtnMst1010]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
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

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pMobileNo"
            oParam.ParamValue = MobNo
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function

#End Region


End Class

''' <summary>
''' In Patient class inherited from Entity class of Patient Master
''' </summary>
''' <remarks></remarks>
''' 


<DataContract()>
Public Class clsInPatient
    Inherits clsPatient
    <DataMember()>
    Public Property Bedno() As String
    <DataMember()>
    Public Property WingCode() As Integer
    <DataMember()>
    Public Property WingCodeDesc() As String
    <DataMember()>
    Public Property WardCode() As Integer
    <DataMember()>
    Public Property WardCodeDesc() As String
    <DataMember()>
    Public Property BedTypeCode() As Integer
    <DataMember()>
    Public Property BedTypeDesc As String ' anamika 20130828  
    <DataMember()>
    Public Property PatientClassCode() As Integer
    <DataMember()>
    Public Property PatientClassCodeDesc() As String
    <DataMember()>
    Public Property AdmissionStatusCode() As Integer
    <DataMember()>
    Public Property AdmissionDate() As Date
    <DataMember()>
    Public Property DischargeDate() As Date
    <DataMember()>
    Public Property AdmissionTime() As Date
    <DataMember()>
    Public Property DischargeTime() As Date
    <DataMember()>
    Public Property DoctorCode As Integer
    <DataMember()>
    Public Property DoctorTitleCode As Integer
    <DataMember()>
    Public Property DoctorTitleCodeDesc As String
    <DataMember()>
    Public Property DoctorFirstName As String
    <DataMember()>
    Public Property DoctorMiddleName As String
    <DataMember()>
    Public Property DoctorLastName As String
    <DataMember()>
    Public Property DoctorFullName As String ' anamika 20131007  
    <DataMember()>
    Public Property CaseTypeDesc As String ' anamika 20130828  
    <DataMember()>
    Public Property CaseTypeCd As Integer ' anamika 20130828  
    <DataMember()>
    Public Property Floor As Integer ' anamika 20130828  
    <DataMember()>
    Public Property RoomNo As Integer ' anamika 20130828  

    <DataMember()>
    Public Property DschrgAdvNo() As Integer 'anamika 20130930

    '<DataMember()>
    'Public Property ArCd() As Integer 'anamika 20130930 'commented on 20140502 by anamika

    <DataMember()>
    Public Property BlockBedNo As String 'Neha S.C. 20140214
    <DataMember()>
    Public Property IsMemDisc As Boolean 'Neha S.C. 20140214
    <DataMember()>
    Public Property MemberType As String 'Neha S.C. 20140214
    <DataMember()>
    Public Property IsMemberValid As Boolean 'Neha S.C. 20140214
    '<DataMember()>
    'Public Property ParentPtnNo As Integer 'Neha S.C. 20140214
    <DataMember()>
    Public Property ParentPtnNo As Long 'anamika 20160902
    <DataMember()>
    Public Property ParentPtnRel As String 'Neha S.C. 20140214
    <DataMember()>
    Public Property MemberConcTyp() As Integer 'Neha S.C. 20140214
    <DataMember()>
    Public Property MemberTypCd() As Integer 'Neha S.C. 20140214
    <DataMember()>
    Public Property BedTransferNo As Integer 'Neha S.C. 20140219
    <DataMember()>
    Public Property BedTransferReqNo As Integer  'Neha S.C. 20140219
    <DataMember()>
    Public Property ArDcd As String  'Neha S.C. 20140219
    <DataMember()>
    Public Property PtnSrcCd As Integer  'Neha S.C. 20140219
    <DataMember()>
    Public Property AthrtyCd As Integer  'anamika 20140509
    <DataMember()>
    Public Property StatusDesc As String '' Amol Margaj 18-11-2017
    <DataMember()>
    Public Property IsIsolation As Boolean ''Amol 10-11-2020 JSK001-147272	



#Region "Get ip patient details "
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
                                                      ByVal ipno As Long) As clsInPatient

        GetInPatient = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELINPTNMST001(companycode, div, loc, ipno))
            Dim objPatient As clsInPatient = Nothing
            If dr1.hasrows Then
                dr1.read()
                objPatient = New clsInPatient
                objPatient.PatientNo = dr1.Item("PatientNo")
                objPatient.PatientTitleCode = dr1.Item("PatientTitleCode")
                objPatient.PatientTitleCodeDesc = dr1.Item("PatientTitleCodeDesc")
                objPatient.PatientFirstName = dr1.Item("PatientFirstName")
                objPatient.PatientMiddleName = dr1.Item("PatientMiddleName")
                objPatient.PatientLastName = dr1.Item("PatientLastName")
                objPatient.PatientFullName = dr1.Item("PatientFullName")
                objPatient.Status = dr1.Item("Status")
                objPatient.Gender = dr1.Item("Gender")
                objPatient.BirthDate = IIf(IsDBNull(dr1.Item("BirthDate")), Nothing, dr1.Item("BirthDate"))
                objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))
                objPatient.InPatientNo = dr1.Item("InPatientNo")
                objPatient.DayCareNo = 0
                objPatient.IsMember = dr1.Item("IsMember")
                objPatient.MembershipID = dr1.Item("MembershipID")
                objPatient.MRNo = dr1.Item("MRNo")
                objPatient.EMPNo = dr1.Item("EMPNo")
                objPatient.AthrtyCd = dr1.Item("AthrtyCd") 'anamika 201440509

                'anamika 20130813
                'for doctor details
                objPatient.DoctorCode = dr1.Item("DocCd")
                objPatient.DoctorTitleCode = dr1.Item("DocTitleCd")
                objPatient.DoctorTitleCodeDesc = dr1.Item("DocTitleDesc")
                objPatient.DoctorFirstName = dr1.Item("DocFirstName")
                objPatient.DoctorMiddleName = dr1.Item("DocMiddleName")
                objPatient.DoctorLastName = dr1.Item("DocLastName")
                objPatient.DoctorFullName = dr1.Item("DocTitleDesc") + " " + dr1.Item("DocLastName") + " " + dr1.Item("DocFirstName") + " " + dr1.Item("DocMiddleName")
                ' 20130813

                'anamika 20130828  
                objPatient.CaseTypeCd = dr1.Item("CaseTypcd")
                objPatient.CaseTypeDesc = dr1.Item("CaseTypDcd")
                objPatient.BedTypeDesc = dr1.Item("BedTypeDeCode")
                objPatient.RoomNo = dr1.Item("Roomno")
                objPatient.Floor = dr1.Item("Floor")
                ' 20130828  
                objPatient.Bedno = dr1.item("Bedno")
                objPatient.WingCode = dr1.item("WingCode")
                objPatient.WingCodeDesc = dr1.item("WingCodeDesc")
                objPatient.WardCode = dr1.item("WardCode")
                objPatient.WardCodeDesc = dr1.item("WardCodeDesc")
                objPatient.BedTypeCode = dr1.item("BedTypeCode")
                objPatient.PatientClassCode = dr1.item("PatientClassCode")
                objPatient.PatientClassCodeDesc = dr1.item("PatientClassCodeDesc")
                objPatient.AdmissionStatusCode = dr1.item("AdmissionStatusCode")
                objPatient.AdmissionDate = IIf(IsDBNull(dr1.item("AdmissionDate")), Nothing, dr1.item("AdmissionDate"))
                objPatient.DischargeDate = IIf(IsDBNull(dr1.item("DischargeDate")), Nothing, dr1.item("DischargeDate"))
                objPatient.AdmissionTime = IIf(IsDBNull(dr1.item("AdmissionTime")), Nothing, dr1.item("AdmissionTime"))
                objPatient.DischargeTime = IIf(IsDBNull(dr1.item("DischargeTime")), Nothing, dr1.item("DischargeTime"))
                objPatient.DschrgAdvNo = dr1.item("DschrgAdvNo")  'anamika 20130930
                objPatient.ArCd = dr1.item("ArCd")  'anamika 20131113

                objPatient.ArDcd = dr1.item("ArDcd") 'Neha S.C 20140212
                objPatient.PtnSrcCd = IIf(IsDBNull(dr1.item("PtnSrcCd")), Nothing, dr1.item("PtnSrcCd")) 'Neha S.C 20140214
                objPatient.BlockBedNo = IIf(IsDBNull(dr1.item("BlockBedNo")), Nothing, dr1.item("BlockBedNo")) 'Neha S.C 20140214
                objPatient.ParentPtnNo = IIf(IsDBNull(dr1.item("ParentPtnNo")), Nothing, dr1.item("ParentPtnNo")) 'Neha S.C 20140214
                objPatient.ParentPtnRel = IIf(IsDBNull(dr1.item("ParentPtnRel")), Nothing, dr1.item("ParentPtnRel")) 'Neha S.C 20140214
                objPatient.BedTransferNo = IIf(IsDBNull(dr1.item("BedTransferNo")), Nothing, dr1.item("BedTransferNo")) 'Neha S.C 20140219
                objPatient.BedTransferReqNo = IIf(IsDBNull(dr1.item("BedTransferReqNo")), Nothing, dr1.item("BedTransferReqNo")) 'Neha S.C 20140219
                objPatient.IsPtnBlackListed = IIf(dr1.item("IsPtnBlackListed") = 0, False, True) 'Neha S.C 20140219
                'amol 24 nov 2017
                If objPatient.AdmissionStatusCode = CInt(1) Then
                    objPatient.StatusDesc = "Reserved"
                ElseIf objPatient.AdmissionStatusCode = CInt(2) Then
                    objPatient.StatusDesc = "Admitted"
                ElseIf objPatient.AdmissionStatusCode = CInt(3) Then
                    objPatient.StatusDesc = "Discharged"
                ElseIf objPatient.AdmissionStatusCode = CInt(5) Then
                    objPatient.StatusDesc = "Cancelled"

                End If
                'amol 24 nov 2017

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




    ''' <summary>
    '''  adds paramters to store procedure SPSELINPTNMST001
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Shared Function SPSELINPTNMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ipno As Integer) As DBRequest 
    Shared Function SPSELINPTNMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ipno As Long) As DBRequest 'anamika 20160906
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELINPTNMST001]" 'ip_ptn_vst  ptn_mst1  cd_dcd ptn_cls_mst   doc_mst  cse_typ_mst  bed_mst  bed_typ_mst  ip_bil_instrn  ar_mst

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

#End Region

#Region "Gets list of all inpatients with adm_sts_cd=2"
    ''' <summary>
    ''' Gets list of all inpatients with adm_sts_cd=2
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetInPatientList(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal companycode As String,
                                                      ByVal div As Integer,
                                                      ByVal loc As Integer
                                                     ) As List(Of clsInPatient)
        GetInPatientList = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELINPTNMST(companycode, div, loc))
            Dim objPatientlist As List(Of clsInPatient) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatient)
                While dr1.read()
                    Dim objPatient As New clsInPatient
                    'objPatient.CompanyCode = companycode
                    'objPatient.DivisionCode = div
                    'objPatient.LocationCode = loc
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientTitleCode = dr1.Item("PatientTitleCode")
                    objPatient.PatientTitleCodeDesc = dr1.Item("PatientTitleCodeDesc")
                    objPatient.PatientFirstName = dr1.Item("PatientFirstName")
                    objPatient.PatientMiddleName = dr1.Item("PatientMiddleName")
                    objPatient.PatientLastName = dr1.Item("PatientLastName")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    objPatient.BirthDate = IIf(IsDBNull(dr1.Item("BirthDate")), Nothing, dr1.Item("BirthDate"))
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))
                    objPatient.InPatientNo = dr1.Item("InPatientNo")
                    objPatient.DayCareNo = 0
                    objPatient.IsMember = dr1.Item("IsMember")
                    objPatient.MembershipID = dr1.Item("MembershipID")
                    objPatient.MRNo = dr1.Item("MRNo")
                    objPatient.EMPNo = dr1.Item("EMPNo")

                    objPatient.Bedno = dr1.item("Bedno")
                    objPatient.WingCode = dr1.item("WingCode")
                    objPatient.WingCodeDesc = dr1.item("WingCodeDesc")
                    objPatient.WardCode = dr1.item("WardCode")
                    objPatient.WardCodeDesc = dr1.item("WardCodeDesc")
                    objPatient.BedTypeCode = dr1.item("BedTypeCode")
                    objPatient.PatientClassCode = dr1.item("PatientClassCode")
                    objPatient.PatientClassCodeDesc = dr1.item("PatientClassCodeDesc")
                    objPatient.AdmissionStatusCode = dr1.item("AdmissionStatusCode")
                    objPatient.AdmissionDate = IIf(IsDBNull(dr1.item("AdmissionDate")), Nothing, dr1.item("AdmissionDate"))
                    objPatient.DischargeDate = IIf(IsDBNull(dr1.item("DischargeDate")), Nothing, dr1.item("DischargeDate"))
                    objPatient.AdmissionTime = IIf(IsDBNull(dr1.item("AdmissionTime")), Nothing, dr1.item("AdmissionTime"))
                    objPatient.DischargeTime = IIf(IsDBNull(dr1.item("DischargeTime")), Nothing, dr1.item("DischargeTime"))
                    objPatient.DschrgAdvNo = dr1.item("DschrgAdvNo")  'anamika 20130930
                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetInPatientList = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetInPatientList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

#End Region

    ''' <summary>
    '''  adds paramters to store procedure SPSELINPTNMST
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELINPTNMST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELINPTNMST]"

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

    'anamika 20131114
    ''' <summary>
    ''' Retrieve data for ip_ptn_vst  by passing doctor code , ward code, patient name and status
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="Cocd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <param name="FrstNm"></param>
    ''' <param name="MidNm"></param>
    ''' <param name="LstNm"></param>
    ''' <param name="DocCd"></param>
    ''' <param name="WardCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetInPtnListByNameDocWard(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal Cocd As String,
                                                      ByVal Div As Integer,
                                                      ByVal Loc As Integer,
                                                      ByVal FrstNm As String,
                                                      ByVal MidNm As String,
                                                      ByVal LstNm As String,
                                                      ByVal DocCd As Integer,
                                                      ByVal WardCd As Integer, ByVal AdmSts As Integer) As List(Of clsInPatientHelp)
        GetInPtnListByNameDocWard = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst002(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123  'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))

                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If
                    'anamika 20140116
                    objPatient.BedTypDesc = dr1.Item("BedTypDesc")
                    objPatient.mobile = dr1.Item("mobile")
                    objPatient.WardCd = dr1.Item("WardCd")
                    objPatient.WardDCd = dr1.Item("WardDCd")
                    ' 20140116
                    objPatient.AdmDt = dr1.Item("AdmDt") 'IIf(dr1.Item("AdmDt") = "", Date.MinValue, dr1.Item("AdmDt")) 'anamika 20150702

                    If objPatient.Status = 3 Then
                        objPatient.DschgDt = dr1.Item("DschgDt")  'IIf(dr1.Item("DschgDt") = "", Date.MinValue, dr1.Item("DschgDt")) 'anamika 20150702
                    Else
                        objPatient.DschgDt = "" ''
                    End If

                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetInPtnListByNameDocWard = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetInPtnListByNameDocWard = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' Retrieve data for ip_ptn_vst  by passing doctor code , ward code, patient name and status
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FrstNm"></param>
    ''' <param name="MidNm"></param>
    ''' <param name="LstNm"></param>
    ''' <param name="DocCd"></param>
    ''' <param name="WardCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SpSelInPtnMst002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer, ByVal AdmSts As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst002]" 'ip_ptn_vst    ptn_mst1   cd_dcd   doc_mst bed_typ_mst

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)





        End With

        Return oRequest
    End Function
    'anamika 20131114

#Region " ip_ptn_vst  by passing doctor code , ward code, patient name and status and follio status code 1"
    ''' <summary>
    ''' Retrieve data for ip_ptn_vst  by passing doctor code , ward code, patient name and status and follio status code  1
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="Cocd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <param name="FrstNm"></param>
    ''' <param name="MidNm"></param>
    ''' <param name="LstNm"></param>
    ''' <param name="DocCd"></param>
    ''' <param name="WardCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetInPtnListByNameDocWardValidatingFolioStscd(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal Cocd As String,
                                                      ByVal Div As Integer,
                                                      ByVal Loc As Integer,
                                                      ByVal FrstNm As String,
                                                      ByVal MidNm As String,
                                                      ByVal LstNm As String,
                                                      ByVal DocCd As Integer,
                                                      ByVal WardCd As Integer, ByVal AdmSts As Integer) As List(Of clsInPatientHelp)
        GetInPtnListByNameDocWardValidatingFolioStscd = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst004(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123 'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))

                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If
                    'anamika 20140116
                    objPatient.BedTypDesc = dr1.Item("BedTypDesc")
                    objPatient.mobile = dr1.Item("mobile")
                    objPatient.WardCd = dr1.Item("WardCd")
                    objPatient.WardDCd = dr1.Item("WardDCd")
                    ' 20140116
                    objPatient.AdmDt = dr1.Item("AdmDt") 'IIf(dr1.Item("AdmDt") = "", Date.MinValue, dr1.Item("AdmDt")) 'anamika 20150707

                    If objPatient.Status = 3 Then
                        objPatient.DschgDt = dr1.Item("DschgDt") 'Format(dr1.Item("DschgDt"), "dd/MM/yyyy") 'IIf(dr1.Item("DschgDt") = "", Date.MinValue, dr1.Item("DschgDt")) 'anamika 20150707
                    Else
                        objPatient.DschgDt = "" ''
                    End If

                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetInPtnListByNameDocWardValidatingFolioStscd = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetInPtnListByNameDocWardValidatingFolioStscd = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function


    ''' <summary>
    ''' Retrieve data for ip_ptn_vst  by passing doctor code , ward code, patient name and status
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FrstNm"></param>
    ''' <param name="MidNm"></param>
    ''' <param name="LstNm"></param>
    ''' <param name="DocCd"></param>
    ''' <param name="WardCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SpSelInPtnMst004(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer, ByVal AdmSts As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst004]"

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)





        End With

        Return oRequest
    End Function



#End Region


    ''mayur 20140118


    ''' <summary>
    ''' Retrieve data for ip_ptn_vst  by passing doctor code , ward code, patient name and status
    ''' retrieves records whose whose bill amount is not zero( For IpConcession Module)  (join on ip_bill)
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="Cocd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <param name="FrstNm"></param>
    ''' <param name="MidNm"></param>
    ''' <param name="LstNm"></param>
    ''' <param name="DocCd"></param>
    ''' <param name="WardCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetInPtnListByNameDocWard001(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal Cocd As String,
                                                      ByVal Div As Integer,
                                                      ByVal Loc As Integer,
                                                      ByVal FrstNm As String,
                                                      ByVal MidNm As String,
                                                      ByVal LstNm As String,
                                                      ByVal DocCd As Integer,
                                                      ByVal WardCd As Integer, ByVal AdmSts As Integer) As List(Of clsInPatientHelp)
        GetInPtnListByNameDocWard001 = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst003(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123 'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))
                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If

                    objPatient.AdmDt = dr1.Item("AdmDt") 'IIf(dr1.Item("AdmDt") = "", Date.MinValue, dr1.Item("AdmDt")) 'anamika 20150702

                    If objPatient.Status = 3 Then

                        objPatient.DschgDt = (dr1.Item("DschgDt")) ''aparna 28 nov 2016
                    Else
                        objPatient.DschgDt = "" ''
                    End If

                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetInPtnListByNameDocWard001 = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetInPtnListByNameDocWard001 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' Retrieve data for ip_ptn_vst  by passing doctor code , ward code, patient name and status
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FrstNm"></param>
    ''' <param name="MidNm"></param>
    ''' <param name="LstNm"></param>
    ''' <param name="DocCd"></param>
    ''' <param name="WardCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SpSelInPtnMst003(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer, ByVal AdmSts As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst003]" 'ip_ptn_vst,ptn_mst1,cd_dcd,doc_mst,IP_BILL

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)





        End With

        Return oRequest
    End Function

#Region "GetPatientHelpWithOpenFolio"
    ''' <summary>
    ''' anamika  20170331
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="Cocd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <param name="FrstNm"></param>
    ''' <param name="MidNm"></param>
    ''' <param name="LstNm"></param>
    ''' <param name="DocCd"></param>
    ''' <param name="WardCd"></param>
    ''' <param name="AdmSts"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetPatientHelpWithOpenFolio(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal Cocd As String,
                                                      ByVal Div As Integer,
                                                      ByVal Loc As Integer,
                                                      ByVal FrstNm As String,
                                                      ByVal MidNm As String,
                                                      ByVal LstNm As String,
                                                      ByVal DocCd As Integer,
                                                      ByVal WardCd As Integer, ByVal AdmSts As Integer) As List(Of clsInPatientHelp)
        GetPatientHelpWithOpenFolio = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst005(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123  'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))

                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If
                    'anamika 20140116
                    objPatient.BedTypDesc = dr1.Item("BedTypDesc")
                    objPatient.mobile = dr1.Item("mobile")
                    objPatient.WardCd = dr1.Item("WardCd")
                    objPatient.WardDCd = dr1.Item("WardDCd")
                    ' 20140116
                    objPatient.AdmDt = dr1.Item("AdmDt") 'IIf(dr1.Item("AdmDt") = "", Date.MinValue, dr1.Item("AdmDt")) 'anamika 20150702

                    If objPatient.Status = 3 Then
                        objPatient.DschgDt = dr1.Item("DschgDt")  'IIf(dr1.Item("DschgDt") = "", Date.MinValue, dr1.Item("DschgDt")) 'anamika 20150702
                    Else
                        objPatient.DschgDt = "" ''
                    End If

                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetPatientHelpWithOpenFolio = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetPatientHelpWithOpenFolio = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try



    End Function
    Shared Function SpSelInPtnMst005(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer, ByVal AdmSts As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst005]"

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)





        End With

        Return oRequest
    End Function
#End Region




#Region " For Op: PatientHelp:SPSELPTNMSTBYNAME001" 'Pramila 29April2017
    Shared Function PatientHelpMst(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                      ByVal FirstNm As String,
                                                      ByVal MiddleNm As String,
                                                      ByVal LastNm As String,
                                                      ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer, Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing,
                                                            Optional ByVal Address As String = Nothing, Optional ByVal FathersName As String = Nothing
                                                    ) As List(Of clsPatientHelp)
        PatientHelpMst = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELPTNMSTBYNAME001(companycode, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria, Pageindex, PageSize, AdharNo, PanNo, Address, FathersName))
            Dim objPatientlist As List(Of clsPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsPatientHelp)
                While dr1.Read()
                    With dr1
                        Dim objPatient As New clsPatientHelp
                        objPatient.PatientNo = .Item("PatientNo")
                        objPatient.PatientFirstName = .Item("PatientFirstName")
                        objPatient.PatientMiddleName = .Item("PatientMiddleName")
                        objPatient.PatientLastName = .Item("PatientLastName")
                        objPatient.PatientFullName = .Item("PatientFullName")
                        objPatient.PatientTitleCodeDesc = .Item("PatientTitleCodeDesc")
                        objPatient.Gender = .Item("Gender")
                        'If UCase(objPatient.Gender) = "M" Then  'anamika 20160120
                        '    objPatient.Gender = "Male"
                        'Else
                        '    objPatient.Gender = "Female"
                        'End If
                        objPatient.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                        objPatient.MobileNumber = IIf(IsDBNull(.Item("mobile")), "", .Item("mobile"))
                        objPatient.totalcnt = IIf(IsDBNull(.Item("totalcnt")), "", .Item("totalcnt"))

                        objPatient.AdharNo = IIf(IsDBNull(.Item("AadharNo")), "", .Item("AadharNo"))        'Aarti 09 Jan 2018
                        objPatient.PanNO = IIf(IsDBNull(.Item("PanNo")), "", .Item("PanNo"))                'Aarti 09 Jan 2018
                        objPatient.Address = IIf(IsDBNull(.Item("Address")), "", .Item("Address"))              'Aarti 09 Jan 2018
                        objPatientlist.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            PatientHelpMst = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            PatientHelpMst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SPSELPTNMSTBYNAME001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FirstNm As String, ByVal MiddleNm As String, ByVal LastNm As String, ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer, Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing,
                                               Optional ByVal Address As String = Nothing, Optional ByVal FathersName As String = Nothing) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELPTNMSTBYNAME001]" 'ptn_mst1,cd_dcd

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
            oParam.ParamName = "PFSTNAME"
            oParam.ParamValue = FirstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMIDNAME"
            oParam.ParamValue = MiddleNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLSTNAME"
            oParam.ParamValue = LastNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdditionalParameter"
            oParam.ParamValue = AdditionalCriteria
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)


            'Aarti 09 Jan 2018
            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdharNo"
            oParam.ParamValue = AdharNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PPanNo"
            oParam.ParamValue = PanNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAddress"
            oParam.ParamValue = Address
            .Parameters.Add(oParam)
            'Aarti 09 Jan 2018


            oParam = New DBRequest.Parameter
            oParam.ParamName = "FathersName"
            oParam.ParamValue = FathersName
            .Parameters.Add(oParam)



            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function

#End Region

#Region " For IP:1- GetIpPatientHelpMst" 'Pramila 2may2017

    Shared Function GetIpPatientHelpMst(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal Cocd As String,
                                                      ByVal Div As Integer,
                                                      ByVal Loc As Integer,
                                                      ByVal FrstNm As String,
                                                      ByVal MidNm As String,
                                                      ByVal LstNm As String,
                                                      ByVal DocCd As Integer,
                                                      ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer, Optional ByVal MobNo As String = Nothing, Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing, Optional ByVal Address As String = Nothing) As List(Of clsInPatientHelp)
        GetIpPatientHelpMst = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst007(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts, Pageindex, PageSize, MobNo, AdharNo, PanNo, Address))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123  'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))

                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If
                    'anamika 20140116
                    objPatient.BedTypDesc = dr1.Item("BedTypDesc")
                    objPatient.mobile = dr1.Item("mobile")
                    objPatient.WardCd = dr1.Item("WardCd")
                    objPatient.WardDCd = dr1.Item("WardDCd")
                    ' 20140116
                    objPatient.AdmDt = dr1.Item("AdmDt") 'IIf(dr1.Item("AdmDt") = "", Date.MinValue, dr1.Item("AdmDt")) 'anamika 20150702

                    If objPatient.Status = 3 Then
                        objPatient.DschgDt = dr1.Item("DschgDt")  'IIf(dr1.Item("DschgDt") = "", Date.MinValue, dr1.Item("DschgDt")) 'anamika 20150702
                    Else
                        objPatient.DschgDt = "" ''
                    End If
                    objPatient.AdharNo = IIf(IsDBNull(dr1.Item("AadharNo")), "", dr1.Item("AadharNo"))    'RasikV 11/01/2018
                    objPatient.PanNo = IIf(IsDBNull(dr1.Item("PanNo")), "", dr1.Item("PanNo"))    'RasikV 11/01/2018
                    objPatient.Address = IIf(IsDBNull(dr1.Item("Address")), "", dr1.Item("Address"))  'RasikV 11/01/2018


                    objPatient.totalcnt = IIf(IsDBNull(dr1.Item("totalcnt")), 0, dr1.Item("totalcnt"))
                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetIpPatientHelpMst = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetIpPatientHelpMst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try



    End Function
    Shared Function SpSelInPtnMst007(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer, Optional ByVal MobNo As String = Nothing, Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing, Optional ByVal Address As String = Nothing) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst007]"

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)

            'RasikV 11/01/2018 - Start Here
            oParam = New DBRequest.Parameter
            oParam.ParamName = "pMobNo"
            oParam.ParamValue = MobNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pAdharNo"
            oParam.ParamValue = AdharNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPanNo"
            oParam.ParamValue = PanNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pAddress"
            oParam.ParamValue = Address
            .Parameters.Add(oParam)
            'RasikV 11/01/2018 - End Here

        End With

        Return oRequest
    End Function
#End Region

#Region " For IP:2- GetIpPatientHelpMst001" 'Pramila 2may2017

    Shared Function GetIpPatientHelpMst001(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal Cocd As String,
                                                    ByVal Div As Integer,
                                                    ByVal Loc As Integer,
                                                    ByVal FrstNm As String,
                                                    ByVal MidNm As String,
                                                    ByVal LstNm As String,
                                                    ByVal DocCd As Integer,
                                                    ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As List(Of clsInPatientHelp)
        GetIpPatientHelpMst001 = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst008(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts, Pageindex, PageSize))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123  'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))

                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If
                    'anamika 20140116
                    objPatient.BedTypDesc = dr1.Item("BedTypDesc")
                    objPatient.mobile = dr1.Item("mobile")
                    objPatient.WardCd = dr1.Item("WardCd")
                    objPatient.WardDCd = dr1.Item("WardDCd")
                    ' 20140116
                    objPatient.AdmDt = dr1.Item("AdmDt") 'IIf(dr1.Item("AdmDt") = "", Date.MinValue, dr1.Item("AdmDt")) 'anamika 20150702

                    If objPatient.Status = 3 Then
                        objPatient.DschgDt = dr1.Item("DschgDt")  'IIf(dr1.Item("DschgDt") = "", Date.MinValue, dr1.Item("DschgDt")) 'anamika 20150702
                    Else
                        objPatient.DschgDt = "" ''
                    End If
                    objPatient.totalcnt = IIf(IsDBNull(dr1.Item("totalcnt")), 0, dr1.Item("totalcnt"))
                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetIpPatientHelpMst001 = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetIpPatientHelpMst001 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SpSelInPtnMst008(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst008]" 'ip_ptn_vst    ptn_mst1   cd_dcd   doc_mst bed_typ_mst

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function
#End Region
#Region "For IP:3-GetIpPatientHelpMst002" 'Pramila 2may2017
    Shared Function GetIpPatientHelpMst002(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal Cocd As String,
                                                    ByVal Div As Integer,
                                                    ByVal Loc As Integer,
                                                    ByVal FrstNm As String,
                                                    ByVal MidNm As String,
                                                    ByVal LstNm As String,
                                                    ByVal DocCd As Integer,
                                                    ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As List(Of clsInPatientHelp)
        GetIpPatientHelpMst002 = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst009(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts, Pageindex, PageSize))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123 'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))

                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If
                    'anamika 20140116
                    objPatient.BedTypDesc = dr1.Item("BedTypDesc")
                    objPatient.mobile = dr1.Item("mobile")
                    objPatient.WardCd = dr1.Item("WardCd")
                    objPatient.WardDCd = dr1.Item("WardDCd")
                    ' 20140116
                    objPatient.AdmDt = dr1.Item("AdmDt") 'IIf(dr1.Item("AdmDt") = "", Date.MinValue, dr1.Item("AdmDt")) 'anamika 20150707

                    If objPatient.Status = 3 Then
                        objPatient.DschgDt = dr1.Item("DschgDt")
                    Else
                        objPatient.DschgDt = "" ''
                    End If
                    objPatient.totalcnt = IIf(IsDBNull(dr1.Item("totalcnt")), 0, dr1.Item("totalcnt"))

                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetIpPatientHelpMst002 = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetIpPatientHelpMst002 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SpSelInPtnMst009(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst009]"

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function

#End Region
#Region "For IP:4-GetIpPatientHelpMst003" 'Pramila 2may2017
    Shared Function GetIpPatientHelpMst003(ByRef strErrMsg As List(Of String),
                                                        ByRef chrErrFlg As Char,
                                                        ByVal Cocd As String,
                                                        ByVal Div As Integer,
                                                        ByVal Loc As Integer,
                                                        ByVal FrstNm As String,
                                                        ByVal MidNm As String,
                                                        ByVal LstNm As String,
                                                        ByVal DocCd As Integer,
                                                        ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As List(Of clsInPatientHelp)
        GetIpPatientHelpMst003 = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst010(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts, Pageindex, PageSize))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123 'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))
                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If

                    objPatient.AdmDt = dr1.Item("AdmDt")

                    If objPatient.Status = 3 Then

                        objPatient.DschgDt = (dr1.Item("DschgDt")) ''aparna 28 nov 2016
                    Else
                        objPatient.DschgDt = "" ''
                    End If
                    objPatient.totalcnt = IIf(IsDBNull(dr1.Item("totalcnt")), 0, dr1.Item("totalcnt"))
                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetIpPatientHelpMst003 = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetIpPatientHelpMst003 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SpSelInPtnMst010(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst010]" 'ip_ptn_vst,ptn_mst1,cd_dcd,doc_mst,IP_BILL

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function

#End Region


#Region "PatientHelp:SPSELPTNMST1017" 'Farid 2 May -2017
    Shared Function PatientHelpListMst(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                      ByVal FirstNm As String,
                                                      ByVal MiddleNm As String,
                                                      ByVal LastNm As String,
                                                      ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer,
 Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing,
                                               Optional ByVal Address As String = Nothing
                                                    ) As List(Of clsPatientHelp)
        PatientHelpListMst = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELPTNMST1017(companycode, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria, Pageindex, PageSize, AdharNo, PanNo, Address))
            Dim objPatientlist As List(Of clsPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsPatientHelp)
                While dr1.Read()
                    With dr1
                        Dim objPatient As New clsPatientHelp
                        objPatient.PatientNo = .Item("PatientNo")
                        objPatient.PatientFirstName = .Item("PatientFirstName")
                        objPatient.PatientMiddleName = .Item("PatientMiddleName")
                        objPatient.PatientLastName = .Item("PatientLastName")
                        objPatient.PatientFullName = .Item("PatientFullName")
                        objPatient.PatientTitleCodeDesc = .Item("PatientTitleCodeDesc")
                        objPatient.Gender = .Item("Gender")
                        'If UCase(objPatient.Gender) = "M" Then  'anamika 20160120
                        '    objPatient.Gender = "Male"
                        'Else
                        '    objPatient.Gender = "Female"
                        'End If
                        objPatient.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                        objPatient.MobileNumber = IIf(IsDBNull(.Item("mobile")), "", .Item("mobile"))
                        objPatient.totalcnt = IIf(IsDBNull(.Item("totalcnt")), 0, .Item("totalcnt"))
                        objPatient.AdharNo = IIf(IsDBNull(.Item("AadharNo")), "", .Item("AadharNo"))        'Aarti 10 Jan 2018
                        objPatient.PanNO = IIf(IsDBNull(.Item("PanNo")), "", .Item("PanNo"))                'Aarti 10 Jan 2018
                        objPatient.Address = IIf(IsDBNull(.Item("Address")), "", .Item("Address"))              'Aarti 10 Jan 2018
                        objPatientlist.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            PatientHelpListMst = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            PatientHelpListMst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SPSELPTNMST1017(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FirstNm As String, ByVal MiddleNm As String, ByVal LastNm As String, ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer, Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing,
                                               Optional ByVal Address As String = Nothing) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELPTNMST1017]" 'ptn_mst1,cd_dcd

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
            oParam.ParamName = "PFSTNAME"
            oParam.ParamValue = FirstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMIDNAME"
            oParam.ParamValue = MiddleNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLSTNAME"
            oParam.ParamValue = LastNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdditionalParameter"
            oParam.ParamValue = AdditionalCriteria
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)


            'Aarti 10 Jan 2018
            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdharNo"
            oParam.ParamValue = AdharNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PPanNo"
            oParam.ParamValue = PanNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAddress"
            oParam.ParamValue = Address
            .Parameters.Add(oParam)
            'Aarti 10 Jan 2018

            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function

#End Region

#Region "PatientHelp:SPSELPTNMST011" 'Farid 3 May -2017
    Shared Function PatientHelpMst011(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                      ByVal FirstNm As String,
                                                      ByVal MiddleNm As String,
                                                      ByVal LastNm As String,
                                                      ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer, Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing,
                                                            Optional ByVal Address As String = Nothing
                                                    ) As List(Of clsPatientHelp)
        PatientHelpMst011 = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELPTNMST011(companycode, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria, Pageindex, PageSize, AdharNo, PanNo, Address))
            Dim objPatientlist As List(Of clsPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsPatientHelp)
                While dr1.Read()
                    With dr1
                        Dim objPatient As New clsPatientHelp
                        objPatient.PatientNo = .Item("PatientNo")
                        objPatient.PatientFirstName = .Item("PatientFirstName")
                        objPatient.PatientMiddleName = .Item("PatientMiddleName")
                        objPatient.PatientLastName = .Item("PatientLastName")
                        objPatient.PatientFullName = .Item("PatientFullName")
                        objPatient.PatientTitleCodeDesc = .Item("PatientTitleCodeDesc")
                        objPatient.Gender = .Item("Gender")
                        'If UCase(objPatient.Gender) = "M" Then  'anamika 20160120
                        '    objPatient.Gender = "Male"
                        'Else
                        '    objPatient.Gender = "Female"
                        'End If
                        objPatient.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                        objPatient.MobileNumber = IIf(IsDBNull(.Item("mobile")), "", .Item("mobile"))
                        objPatient.totalcnt = IIf(IsDBNull(.Item("totalcnt")), 0, .Item("totalcnt"))
                        objPatient.AdharNo = IIf(IsDBNull(.Item("AadharNo")), "", .Item("AadharNo"))        'Aarti 31 Jan 2018
                        objPatient.PanNO = IIf(IsDBNull(.Item("PanNo")), "", .Item("PanNo"))                'Aarti 31 Jan 2018
                        objPatient.Address = IIf(IsDBNull(.Item("Address")), "", .Item("Address"))              'Aarti 31 Jan 2018
                        objPatientlist.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            PatientHelpMst011 = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            PatientHelpMst011 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SPSELPTNMST011(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FirstNm As String, ByVal MiddleNm As String, ByVal LastNm As String, ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer, Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing,
                                               Optional ByVal Address As String = Nothing) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELPTNMST011]" 'ptn_mst1,cd_dcd

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
            oParam.ParamName = "PFSTNAME"
            oParam.ParamValue = FirstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMIDNAME"
            oParam.ParamValue = MiddleNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLSTNAME"
            oParam.ParamValue = LastNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdditionalParameter"
            oParam.ParamValue = AdditionalCriteria
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)

            'Aarti 31 Jan 2018
            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdharNo"
            oParam.ParamValue = AdharNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PPanNo"
            oParam.ParamValue = PanNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAddress"
            oParam.ParamValue = Address
            .Parameters.Add(oParam)
            'END 31 Jan 2018

            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function

#End Region


#Region "GetIpPatientHelpMstNoFolio/SpSelInPtnMst011" 'Pragya : 03-jun-2017

    Shared Function GetIpPatientHelpMstNoFolio(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal Cocd As String,
                                                      ByVal Div As Integer,
                                                      ByVal Loc As Integer,
                                                      ByVal FrstNm As String,
                                                      ByVal MidNm As String,
                                                      ByVal LstNm As String,
                                                      ByVal DocCd As Integer,
                                                      ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As List(Of clsInPatientHelp)
        GetIpPatientHelpMstNoFolio = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst011(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts, Pageindex, PageSize))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123  'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))

                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If
                    'anamika 20140116
                    objPatient.BedTypDesc = dr1.Item("BedTypDesc")
                    objPatient.mobile = dr1.Item("mobile")
                    objPatient.WardCd = dr1.Item("WardCd")
                    objPatient.WardDCd = dr1.Item("WardDCd")
                    ' 20140116
                    objPatient.AdmDt = dr1.Item("AdmDt") 'IIf(dr1.Item("AdmDt") = "", Date.MinValue, dr1.Item("AdmDt")) 'anamika 20150702

                    If objPatient.Status = 3 Then
                        objPatient.DschgDt = dr1.Item("DschgDt")  'IIf(dr1.Item("DschgDt") = "", Date.MinValue, dr1.Item("DschgDt")) 'anamika 20150702
                    Else
                        objPatient.DschgDt = "" ''
                    End If

                    objPatient.totalcnt = IIf(IsDBNull(dr1.Item("totalcnt")), 0, dr1.Item("totalcnt"))
                    objPatient.CreditCompany = IIf(IsDBNull("ArDesc"), "", dr1.Item("ArDesc")) ''DEVEN 15 OCT 2018
                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetIpPatientHelpMstNoFolio = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetIpPatientHelpMstNoFolio = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try



    End Function

    Shared Function SpSelInPtnMst011(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer,
                                     ByVal AdmSts As Integer,
                                     ByVal Pageindex As Integer,
                                     ByVal PageSize As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst011]"

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function
#End Region



#Region "GET PATIENT DETAILS FOR RADIOLOGY ENTRY PROGRAM RULE BY IP NO" 'RasikV 20170529
    Shared Function GetIpDtlsByIpNo(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer,
           ByVal Loc As Integer, ByVal IpNo As Long) As clsPtnNmAdmDisDtDtls
        GetIpDtlsByIpNo = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelPtnMst012(CoCd, Div, Loc, IpNo))
            Dim obj As clsPtnNmAdmDisDtDtls
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj = New clsPtnNmAdmDisDtDtls
                        obj.PtnNm = IIf(IsDBNull(.Item("PtnNm")), Nothing, .Item("PtnNm"))
                        obj.AdmDt = IIf(IsDBNull(.Item("AdmDt")), Date.MinValue, .Item("AdmDt"))
                        obj.DisDt = IIf(IsDBNull(.Item("DisDt")), Date.MinValue, .Item("DisDt"))
                    End With
                    GetIpDtlsByIpNo = obj
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetIpDtlsByIpNo = Nothing
        End Try
        Return GetIpDtlsByIpNo
    End Function

    Shared Function SpSelPtnMst012(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal IpNo As Long) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[dbo].[SpSelPtnMst012]" 'ptn_mst1, ip_ptn_vst, cd_dcd
            .CommandType = CommandType.StoredProcedure
            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
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

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpNo"
            oParam.ParamValue = IpNo
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region

#Region "exclusively used in nursing workbench" 'RasikV 20170822
    Shared Function GetPtnHelpWithOpenFolio(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal FrstNm As String, ByVal MidNm As String, ByVal LstNm As String,
           ByVal DocCd As Integer, ByVal WardCd As Integer, ByVal AdmSts As Integer) As List(Of clsInPatientHelp)
        GetPtnHelpWithOpenFolio = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst013(CoCd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = IIf(IsDBNull(dr1.Item("PatientNo")), 0, dr1.Item("PatientNo"))
                    objPatient.PatientFullName = IIf(IsDBNull(dr1.Item("PatientFullName")), Nothing, dr1.Item("PatientFullName"))
                    objPatient.Status = IIf(IsDBNull(dr1.Item("Status")), 0, dr1.Item("Status"))
                    objPatient.Gender = IIf(IsDBNull(dr1.Item("Gender")), Nothing, dr1.Item("Gender"))
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), Nothing, dr1.Item("Age"))
                    objPatient.IpNo = IIf(IsDBNull(dr1.Item("InPatientNo")), 0, dr1.Item("InPatientNo"))
                    objPatient.DoctorCd = IIf(IsDBNull(dr1.Item("DocCd")), 0, dr1.Item("DocCd"))
                    objPatient.DoctorName = IIf(IsDBNull(dr1.Item("DocNm")), Nothing, dr1.Item("DocNm"))
                    objPatient.BedNo = IIf(IsDBNull(dr1.Item("BedNo")), Nothing, dr1.Item("BedNo"))
                    objPatient.Status = IIf(IsDBNull(dr1.Item("Status")), Nothing, dr1.Item("Status"))
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"
                    End If
                    objPatient.BedTypDesc = IIf(IsDBNull(dr1.Item("BedTypDesc")), Nothing, dr1.Item("BedTypDesc"))
                    objPatient.mobile = IIf(IsDBNull(dr1.Item("mobile")), Nothing, dr1.Item("mobile"))
                    objPatient.WardCd = IIf(IsDBNull(dr1.Item("WardCd")), 0, dr1.Item("WardCd"))
                    objPatient.WardDCd = IIf(IsDBNull(dr1.Item("WardDCd")), Nothing, dr1.Item("WardDCd"))
                    objPatient.AdmDt = IIf(IsDBNull(dr1.Item("AdmDt")), Date.MinValue, dr1.Item("AdmDt"))
                    If objPatient.Status = 3 Then
                        objPatient.DschgDt = IIf(IsDBNull(dr1.Item("DschgDt")), Date.MinValue, dr1.Item("DschgDt"))
                    Else
                        objPatient.DschgDt = ""
                    End If
                    objPatient.folStsCd = dr1.item("fol_sts_cd") 'Amol Margaj 23/08/2017  for Restirct Doctor Order Entry
                    objPatientlist.Add(objPatient)
                End While
            End If
            dr1.close()
            GetPtnHelpWithOpenFolio = objPatientlist
            ofactory = Nothing
        Catch ex As Exception
            GetPtnHelpWithOpenFolio = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SpSelInPtnMst013(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FrstNm As String,
           ByVal MidNm As String, ByVal LstNm As String, ByVal DocCd As Integer, ByVal WardCd As Integer, ByVal AdmSts As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst013]"
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
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

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region



    '' Added by Amol Margaj 14-11-2017
    '' get Patient Admission Date by IpNo
    Shared Function GetDateForDischargeSummary(IpOpFlag As Char, IPOPNO As Long) As Date
        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        orequest.Command = "select dbo.[FN_getPatientAdmDate] ('" & Char.ToUpper(IpOpFlag) & "'," & IPOPNO & ") AdmDate "

        Dim ofactory As New DBFactory
        Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

        If ds.Tables(0).Rows.Count <> 0 Then
            GetDateForDischargeSummary = ds.Tables(0).Rows(0).Item("AdmDate")
        Else
            GetDateForDischargeSummary = ""
        End If
        orequest = Nothing
        ofactory = Nothing
        Return GetDateForDischargeSummary
    End Function


#Region " For Op: PatientHelp Active / Inactive :SPSELPTNMSTBYNAME002" 'Amol 2018-02-12
    Shared Function PatientHelpMstForAll(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                      ByVal FirstNm As String,
                                                      ByVal MiddleNm As String,
                                                      ByVal LastNm As String,
                                                      ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer, Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing,
                                                            Optional ByVal Address As String = Nothing
                                                    ) As List(Of clsPatientHelp)
        PatientHelpMstForAll = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELPTNMSTBYNAME002(companycode, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria, Pageindex, PageSize, AdharNo, PanNo, Address))
            Dim objPatientlist As List(Of clsPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsPatientHelp)
                While dr1.Read()
                    With dr1
                        Dim objPatient As New clsPatientHelp
                        objPatient.PatientNo = .Item("PatientNo")
                        objPatient.PatientFirstName = .Item("PatientFirstName")
                        objPatient.PatientMiddleName = .Item("PatientMiddleName")
                        objPatient.PatientLastName = .Item("PatientLastName")
                        objPatient.PatientFullName = .Item("PatientFullName")
                        objPatient.PatientTitleCodeDesc = .Item("PatientTitleCodeDesc")
                        objPatient.Gender = .Item("Gender")
                        'If UCase(objPatient.Gender) = "M" Then  'anamika 20160120
                        '    objPatient.Gender = "Male"
                        'Else
                        '    objPatient.Gender = "Female"
                        'End If
                        objPatient.Age = IIf(IsDBNull(.Item("Age")), "", .Item("Age"))
                        objPatient.MobileNumber = IIf(IsDBNull(.Item("mobile")), "", .Item("mobile"))
                        objPatient.totalcnt = IIf(IsDBNull(.Item("totalcnt")), "", .Item("totalcnt"))

                        objPatient.AdharNo = IIf(IsDBNull(.Item("AadharNo")), "", .Item("AadharNo"))        'Aarti 09 Jan 2018
                        objPatient.PanNO = IIf(IsDBNull(.Item("PanNo")), "", .Item("PanNo"))                'Aarti 09 Jan 2018
                        objPatient.Address = IIf(IsDBNull(.Item("Address")), "", .Item("Address"))              'Aarti 09 Jan 2018
                        objPatientlist.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            PatientHelpMstForAll = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            PatientHelpMstForAll = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SPSELPTNMSTBYNAME002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FirstNm As String, ByVal MiddleNm As String, ByVal LastNm As String, ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer, Optional ByVal AdharNo As String = Nothing, Optional ByVal PanNo As String = Nothing,
                                               Optional ByVal Address As String = Nothing) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELPTNMSTBYNAME002]" 'ptn_mst1,cd_dcd

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
            oParam.ParamName = "PFSTNAME"
            oParam.ParamValue = FirstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMIDNAME"
            oParam.ParamValue = MiddleNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLSTNAME"
            oParam.ParamValue = LastNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdditionalParameter"
            oParam.ParamValue = AdditionalCriteria
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)


            'Aarti 09 Jan 2018
            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdharNo"
            oParam.ParamValue = AdharNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PPanNo"
            oParam.ParamValue = PanNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAddress"
            oParam.ParamValue = Address
            .Parameters.Add(oParam)
            'Aarti 09 Jan 2018



            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function

#End Region




#Region "GetIpPatientHelpMstWithOutFolioSts/SpSelInPtnMst016 : Get patient List Help without considering FolioSts"  'Pragya  : 17-apr-2018
    Shared Function GetIpPatientHelpMstWithOutFolioSts(ByRef strErrMsg As List(Of String),
                                                        ByRef chrErrFlg As Char,
                                                        ByVal Cocd As String,
                                                        ByVal Div As Integer,
                                                        ByVal Loc As Integer,
                                                        ByVal FrstNm As String,
                                                        ByVal MidNm As String,
                                                        ByVal LstNm As String,
                                                        ByVal DocCd As Integer,
                                                        ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As List(Of clsInPatientHelp)
        GetIpPatientHelpMstWithOutFolioSts = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelInPtnMst016(Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts, Pageindex, PageSize))
            Dim objPatientlist As List(Of clsInPatientHelp) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsInPatientHelp)
                While dr1.read()
                    Dim objPatient As New clsInPatientHelp
                    objPatient.PatientNo = dr1.Item("PatientNo")
                    objPatient.PatientFullName = dr1.Item("PatientFullName")
                    objPatient.Status = dr1.Item("Status")
                    objPatient.Gender = dr1.Item("Gender")
                    ''anamika 20131123 'anamika 20160120
                    'If objPatient.Gender = "M" Then
                    '    objPatient.Gender = "Male"
                    'ElseIf objPatient.Gender = "F" Then
                    '    objPatient.Gender = "Female"

                    'Else
                    '    objPatient.Gender = ""
                    'End If
                    ''end 20131123
                    objPatient.Age = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))
                    objPatient.IpNo = dr1.Item("InPatientNo")
                    objPatient.DoctorCd = dr1.Item("DocCd")
                    objPatient.DoctorName = dr1.Item("DocNm")
                    objPatient.BedNo = dr1.Item("BedNo")
                    objPatient.Status = dr1.Item("Status")
                    If objPatient.Status = CInt(1) Then
                        objPatient.StatusDesc = "Reserved"
                    ElseIf objPatient.Status = CInt(2) Then
                        objPatient.StatusDesc = "Admitted"
                    ElseIf objPatient.Status = CInt(3) Then
                        objPatient.StatusDesc = "Discharged"
                    ElseIf objPatient.Status = CInt(5) Then
                        objPatient.StatusDesc = "Cancelled"

                    End If

                    objPatient.AdmDt = dr1.Item("AdmDt")

                    If objPatient.Status = 3 Then

                        objPatient.DschgDt = (dr1.Item("DschgDt")) ''aparna 28 nov 2016
                    Else
                        objPatient.DschgDt = "" ''
                    End If
                    objPatient.totalcnt = IIf(IsDBNull(dr1.Item("totalcnt")), 0, dr1.Item("totalcnt"))
                    objPatientlist.Add(objPatient)

                End While
            End If
            dr1.close()
            GetIpPatientHelpMstWithOutFolioSts = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetIpPatientHelpMstWithOutFolioSts = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SpSelInPtnMst016(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrstNm As String,
                                     ByVal MidNm As String,
                                     ByVal LstNm As String,
                                     ByVal DocCd As Integer,
                                     ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelInPtnMst016]" 'ip_ptn_vst,ptn_mst1,cd_dcd,doc_mst,IP_BILL

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
            oParam.ParamName = "PFrstNm"
            oParam.ParamValue = FrstNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PMidNm"
            oParam.ParamValue = MidNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLstNm"
            oParam.ParamValue = LstNm
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PWardCd"
            oParam.ParamValue = WardCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAdmStsCd"
            oParam.ParamValue = AdmSts
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pageindex"
            oParam.ParamValue = Pageindex
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ppagesize"
            oParam.ParamValue = PageSize
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function

#End Region



End Class






Public Class clsInPatientHelp
    '<DataMember()>
    'Public Property PatientNo() As Integer
    <DataMember()>
    Public Property PatientNo() As Long 'anamika 20160902
    <DataMember()>
    Public Property PatientFullName() As String
    <DataMember()>
    Public Property Gender() As String
    <DataMember()>
    Public Property Age() As String
    <DataMember()>
    Public Property DoctorCd() As Integer
    <DataMember()>
    Public Property DoctorName() As String
    '<DataMember()>
    'Public Property IpNo() As Integer
    <DataMember()>
    Public Property IpNo() As Long 'anamika 20160907
    <DataMember()>
    Public Property BedNo() As String
    '<DataMember()>
    'Public Property PtnNo() As Integer
    <DataMember()>
    Public Property PtnNo() As Long 'anamika 20160902
    <DataMember()>
    Public Property Status() As Integer
    <DataMember()>
    Public Property StatusDesc() As String
    'anamika 20140116
    <DataMember()>
    Public Property BedTypDesc() As String
    <DataMember()>
    Public Property mobile() As String
    <DataMember()>
    Public Property WardCd() As Integer
    <DataMember()>
    Public Property WardDCd() As String
    'end  20140116
    <DataMember()>
    Public Property AdmDt() As Date 'anamika 20150702
    <DataMember()>
    Public Property DschgDt() As String 'anamika 20150702 'Data Type is string for only help page (Dont change)
    <DataMember()>
    Public Property folStsCd As Integer 'Amol Margaj 20170813
    <DataMember()>
    Public Property totalcnt As Integer 'Pramila 2May2017
    <DataMember()>
    Public Property AdharNo As String 'RasikV 11/01/2018
    <DataMember()>
    Public Property PanNo As String 'RasikV 11/01/2018
    <DataMember()>
    Public Property Address As String 'RasikV 11/01/2018
    <DataMember()>
    Public Property CreditCompany As String ' Deven 03/10/2018


End Class



<DataContract()>
Public Class clsPatientWithDct
    '<DataMember()>
    'Public Property PatientNo() As Integer
    <DataMember()>
    Public Property PatientNo() As Long 'anamika 20160902
    <DataMember()>
    Public Property PatientFullName() As String
    <DataMember()>
    Public Property DoctorName() As String
    <DataMember()>
    Public Property DctCd() As Integer
End Class
<DataContract()>
Public Class clsPatientHelp
    Inherits clsPtnBasicInfo 'anamika 20151205
    <DataMember()>
    Public Property MobileNumber() As String
    <DataMember()>
    Public Property EMail As String 'aparna 20151019
    <DataMember()>
    Public Property totalcnt As Integer 'Pramila 2May2017
    <DataMember()>
    Public Property AdmSts As Integer 'aparna 20171116

    <DataMember()>
    Public Property AdharNo As String 'Aarti 09 Jan 2018
    <DataMember()>
    Public Property PanNO As String 'Aarti 09 Jan 2018
End Class


<DataContract()>
Public Class clsPatientWithDocAr  'RasikV 20170117
    Inherits clsPatientWithDct
    <DataMember()>
    Public ArDcd As String
    <DataMember()>
    Public ArCd As Long
    <DataMember()>
    Public Property IsPtnBlackListed As Boolean
End Class

Public Class clsPtnCompleteHistory
    <DataMember()>
    Public Property VisitDate() As String
    <DataMember()>
    Public Property Time() As String
    <DataMember()>
    Public Property Bed() As String
    <DataMember()>
    Public Property Ward() As String
    <DataMember()>
    Public Property Patientclass() As String
    <DataMember()>
    Public Property Description() As String

End Class

<DataContract()>
Public Class clsPtnBasicInfo 'anamika 20151205
    '<DataMember()>
    'Public Property PatientNo As Integer
    <DataMember()>
    Public Property PatientNo As Long 'anamika 20160902
    <DataMember()>
    Public Property Gender As String
    <DataMember()>
    Public Property Age As String
    <DataMember()>
    Public Property PatientTitleCodeDesc As String
    <DataMember()>
    Public Property PatientFirstName As String
    <DataMember()>
    Public Property PatientMiddleName As String
    <DataMember()>
    Public Property PatientLastName As String
    <DataMember()>
    Public Property PatientFullName As String
    <DataMember()>
    Public Property Status As Char
    <DataMember()>
    Public Property Address As String 'RasikV 20170109
    <DataMember()>
    Public Property BillType As Integer         'Aarti 26 Jun 2018
End Class



#Region "CLASS : ReferdDocDisplayFrmPtnMst1OnAdm : EXCLUSIVELY USED IN DIRECT ADMISSION / ALLOT ADMISSION"
''' <summary>
'''  TO GET THE PtnRefByTyp & PtnRefByCd FROM PTN_MST1 TO DISPLAY REFFERED DOCTORS / EMPLOYEE / ARMST ETC ON Admissions
''' </summary>
''' <remarks></remarks>
<DataContract>
Public Class clsReferdDocDisplay

    <DataMember()>
    Public Property PtnRefByTyp() As Integer
    <DataMember()>
    Public Property PtnRefByCd() As Integer
End Class
#End Region



#Region "CLASS :clsBabyMotherHelp "
Public Class clsBabyMotherHelp  'aparna 17 aug 2016
    <DataMember()>
    Public Property FulNm As String
    '<DataMember()>
    'Public Property IpNo As Integer
    <DataMember()>
    Public Property IpNo As Long 'anamika 20160907
    '<DataMember()>
    'Public Property PtnNo As Integer
    <DataMember()>
    Public Property PtnNo As Long
    <DataMember()>
    Public Property BedNo As String
    <DataMember()>
    Public Property Ward As String
End Class
#End Region





#Region "CLASS : clsPtnDetails"
Public Class clsPtnDetails  'Pramila 8april2017

    <DataMember()>
    Public Property PtnNo() As Long
    <DataMember()>
    Public Property InPatientNo() As Long
    <DataMember()>
    Public Property PtnFrstNm As String
    <DataMember()>
    Public Property PtnLsttNm() As String
    <DataMember()>
    Public Property PtnMidNm() As String
    <DataMember()>
    Public Property PtnFulNm() As String
    <DataMember()>
    Public Property PtnGendr() As String
    <DataMember()>
    Public Property PtnAge() As String
    <DataMember()>
    Public Property WardCode() As Integer
    <DataMember()>
    Public Property WardCodeDesc() As String
    <DataMember()>
    Public Property BedTypeCode() As Integer
    <DataMember()>
    Public Property Bedno() As String
    <DataMember()>
    Public Property BedTypeDesc As String
    <DataMember()>
    Public Property PatientClassCode() As Integer
    <DataMember()>
    Public Property PatientClassCodeDesc() As String
    <DataMember()>
    Public Property AdmissionDate() As Date
    <DataMember()>
    Public Property DischargeDate() As Date
    <DataMember()>
    Public Property CaseTypeDesc As String
    <DataMember()>
    Public Property CaseTypeCd As Integer
    <DataMember()>
    Public Property DoctorCode As Integer
    <DataMember()>
    Public Property DoctorTitleCode As Integer
    <DataMember()>
    Public Property DoctorTitleCodeDesc As String
    <DataMember()>
    Public Property DoctorFirstName As String
    <DataMember()>
    Public Property DoctorMiddleName As String
    <DataMember()>
    Public Property DoctorLastName As String
    <DataMember()>
    Public Property DoctorFullName As String
    <DataMember()>
    Public Property PatientTitleCode() As Integer
    <DataMember()>
    Public Property PatientTitleCodeDesc() As String
    <DataMember()>
    Public Property WingCode() As Integer
    <DataMember()>
    Public Property WingCodeDesc() As String


#Region "GetInPatientByIpNo" 'Pramila 8april2017

    Shared Function GetInPatientByIpNo(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                     ByVal ipno As Long) As clsPtnDetails

        GetInPatientByIpNo = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELINPTNMST001(companycode, div, loc, ipno))
            Dim objPatient As clsPtnDetails = Nothing
            If dr1.hasrows Then
                dr1.read()
                objPatient = New clsPtnDetails
                objPatient.PtnNo = dr1.Item("PatientNo")
                objPatient.InPatientNo = dr1.Item("InPatientNo")
                objPatient.PtnFrstNm = dr1.Item("PatientFirstName")
                objPatient.PtnMidNm = dr1.Item("PatientMiddleName")
                objPatient.PtnLsttNm = dr1.Item("PatientLastName")
                objPatient.PtnFulNm = dr1.Item("PatientFullName")
                objPatient.PtnGendr = dr1.Item("Gender")
                objPatient.PtnAge = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))
                objPatient.CaseTypeCd = dr1.Item("CaseTypcd")
                objPatient.CaseTypeDesc = dr1.Item("CaseTypDcd")
                objPatient.BedTypeDesc = dr1.Item("BedTypeDeCode")
                objPatient.WardCode = dr1.item("WardCode")
                objPatient.WardCodeDesc = dr1.item("WardCodeDesc")
                objPatient.BedTypeCode = dr1.item("BedTypeCode")
                objPatient.Bedno = dr1.item("Bedno")
                objPatient.PatientClassCode = dr1.item("PatientClassCode")
                objPatient.PatientClassCodeDesc = dr1.item("PatientClassCodeDesc")
                objPatient.AdmissionDate = IIf(IsDBNull(dr1.item("AdmissionDate")), Nothing, dr1.item("AdmissionDate"))
                objPatient.DischargeDate = IIf(IsDBNull(dr1.item("DischargeDate")), Nothing, dr1.item("DischargeDate"))
                objPatient.PatientTitleCode = dr1.Item("PatientTitleCode")
                objPatient.PatientTitleCodeDesc = dr1.Item("PatientTitleCodeDesc")
                objPatient.WingCode = dr1.item("WingCode")
                objPatient.WingCodeDesc = dr1.item("WingCodeDesc")
                'anamika 20130813
                'for doctor details
                objPatient.DoctorCode = dr1.Item("DocCd")
                objPatient.DoctorTitleCode = dr1.Item("DocTitleCd")
                objPatient.DoctorTitleCodeDesc = dr1.Item("DocTitleDesc")
                objPatient.DoctorFirstName = dr1.Item("DocFirstName")
                objPatient.DoctorMiddleName = dr1.Item("DocMiddleName")
                objPatient.DoctorLastName = dr1.Item("DocLastName")
                objPatient.DoctorFullName = dr1.Item("DocTitleDesc") + " " + dr1.Item("DocLastName") + " " + dr1.Item("DocFirstName") + " " + dr1.Item("DocMiddleName")
                ' 20130813

            End If
            dr1.close()
            GetInPatientByIpNo = objPatient
            ofactory = Nothing
        Catch ex As Exception
            GetInPatientByIpNo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function


    Shared Function SPSELINPTNMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ipno As Long) As DBRequest 'anamika 20160906
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELINPTNMST001]" 'ip_ptn_vst  ptn_mst1  cd_dcd ptn_cls_mst   doc_mst  cse_typ_mst  bed_mst  bed_typ_mst  ip_bil_instrn  ar_mst

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

#End Region

#Region "GetOPPatientByPtnNoDocCdPtnClsCd" 'Pramila 12april2017

    Shared Function GetOPPatientByPtnNoDocCdPtnClsCd(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                     ByVal PtnNo As Long, ByVal DocCd As Integer, ByVal PtnClsCd As Integer) As clsPtnDetails

        GetOPPatientByPtnNoDocCdPtnClsCd = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELINPTNMST006(companycode, div, loc, PtnNo, DocCd, PtnClsCd))
            Dim objPatient As clsPtnDetails = Nothing
            If dr1.hasrows Then
                dr1.read()
                objPatient = New clsPtnDetails
                objPatient.PtnNo = dr1.Item("PatientNo")
                objPatient.PtnFrstNm = dr1.Item("PatientFirstName")
                objPatient.PtnMidNm = dr1.Item("PatientMiddleName")
                objPatient.PtnLsttNm = dr1.Item("PatientLastName")
                objPatient.PtnFulNm = dr1.Item("PatientFullName")
                objPatient.PtnGendr = dr1.Item("Gender")
                objPatient.PtnAge = IIf(IsDBNull(dr1.Item("Age")), "", dr1.Item("Age"))
                objPatient.PatientClassCode = dr1.item("PatientClassCode")
                objPatient.PatientClassCodeDesc = dr1.item("PatientClassCodeDesc")
                objPatient.PatientTitleCode = dr1.Item("PatientTitleCode")
                objPatient.PatientTitleCodeDesc = dr1.Item("PatientTitleCodeDesc")
                objPatient.DoctorCode = dr1.Item("DocCd")
                objPatient.DoctorTitleCode = dr1.Item("DocTitleCd")
                objPatient.DoctorTitleCodeDesc = dr1.Item("DocTitleDesc")
                objPatient.DoctorFirstName = dr1.Item("DocFirstName")
                objPatient.DoctorMiddleName = dr1.Item("DocMiddleName")
                objPatient.DoctorLastName = dr1.Item("DocLastName")
                objPatient.DoctorFullName = dr1.Item("DocTitleDesc") + " " + dr1.Item("DocLastName") + " " + dr1.Item("DocFirstName") + " " + dr1.Item("DocMiddleName")
            End If
            dr1.close()
            GetOPPatientByPtnNoDocCdPtnClsCd = objPatient
            ofactory = Nothing
        Catch ex As Exception
            GetOPPatientByPtnNoDocCdPtnClsCd = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function


    Shared Function SPSELINPTNMST006(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal PtnNo As Long, ByVal DocCd As Integer, ByVal PtnClsCd As Integer) As DBRequest 'anamika 20160906
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELINPTNMST006]"

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
            oParam.ParamName = "pPtnNo"
            oParam.ParamValue = PtnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "DocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PtnClsCd"
            oParam.ParamValue = PtnClsCd
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function

#End Region

End Class

#End Region


<DataContract>
Public Class clsPtnNmAdmDisDtDtls 'RasikV 20170529
    <DataMember()>
    Public Property PtnNm() As String
    <DataMember()>
    Public Property AdmDt() As Date
    <DataMember()>
    Public Property DisDt() As Date
End Class


<DataContract>
Public Class clsPtnDetailsWithOtherInfo 'pragya 20170718
    Inherits clsPtnBasicInfo

    <DataMember()>
    Public Property prmntAddrs1() As String   'pRAGYA : 18-JUL-2017
    <DataMember()>
    Public Property prmntAddrs2() As String    'pRAGYA : 18-JUL-2017
    <DataMember()>
    Public Property prmntAddrs3() As String    'pRAGYA : 18-JUL-2017
    <DataMember()>
    Public Property prmntPin() As String       'pRAGYA : 18-JUL-2017
    <DataMember()>
    Public Property MarrigeSts() As String    'pRAGYA : 18-JUL-2017
    <DataMember()>
    Public Property OccupDesc() As String       'pRAGYA : 18-JUL-2017
    <DataMember()>
    Public Property BirthDate() As Date   'pRAGYA : 19-JUL-2017
    <DataMember()>
    Public Property PtnMobileNo() As String       'pRAGYA : 19-JUL-2017
End Class


#Region "CLASS :  clsFAPstngPtnMstDtls  {EXCLUSIVELY USED IN FA POSTING FOR PTN BASIC DETAILS}"

'pragya : 22-nov-2017
<DataContract>
Public Class clsFAPstngPtnMstDtls
    <DataMember()>
    Public Property PtnNo() As Long
    <DataMember()>
    Public Property PtnTtlCd() As Integer
    <DataMember()>
    Public Property PtnLstName() As String
    <DataMember()>
    Public Property PtnFrstName() As String
    <DataMember()>
    Public Property PtnMidName() As String
    <DataMember()>
    Public Property PtnTypFlg() As String
    <DataMember()>
    Public Property PtnGender() As String
    <DataMember()>
    Public Property PtnParentNo() As Long
    <DataMember()>
    Public Property PtnDepndNo() As Integer
    <DataMember()>
    Public Property PtnNationCd() As Integer
    <DataMember()>
    Public Property PtnMartialCd() As Integer
    <DataMember()>
    Public Property PtnOccupationCd() As Integer
    <DataMember()>
    Public Property PtnEducationCd() As Integer
    <DataMember()>
    Public Property PtnIncomeCd() As Integer
    <DataMember()>
    Public Property PtnReligionCd() As Integer
    <DataMember()>
    Public Property PtnCommunityCd() As Integer
End Class


#End Region



Public Class ClsPtnDtlsSetup

    <DataMember()>
    Public Property Name() As String
    <DataMember()>
    Public Property Tooltip() As String
    <DataMember()>
    Public Property WaterMark() As String



#Region "added to set patient label & textbox property dynamically"

    Public Shared Function setproperties(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                             ByRef chrErrFlg As Char,
                                                             ByVal CoCd As String,
                                                             ByVal Div As Integer,
                                                             ByVal Loc As Integer, ByVal objRuleMst As clsRuleMaster) As List(Of ClsPtnDtlsSetup)
        Try
            Dim clslst As New List(Of ClsPtnDtlsSetup)
            Dim cls As ClsPtnDtlsSetup
            Dim ptnnamelst() As String


            If objRuleMst IsNot Nothing Then
                If (objRuleMst.DetFlag = "Y") Then

                    ptnnamelst = objRuleMst.Data1.Split("-")

                    If (ptnnamelst IsNot Nothing) Then

                        If (ptnnamelst.Count > 0) Then
                            For i As Integer = 0 To ptnnamelst.Count - 1
                                cls = New ClsPtnDtlsSetup
                                cls = getproperties(ptnnamelst(i))
                                clslst.Add(cls)
                            Next

                        End If

                    End If


                Else
                    ptnnamelst = objRuleMst.Data2.Split("-")
                    If (ptnnamelst IsNot Nothing) Then

                        If (ptnnamelst.Count > 0) Then
                            For i As Integer = 0 To ptnnamelst.Count - 1
                                cls = New ClsPtnDtlsSetup
                                cls = getproperties(ptnnamelst(i))
                                clslst.Add(cls)
                            Next

                        End If

                    End If

                End If

            Else

                Dim namelst As New List(Of String)
                namelst.Add("L")
                namelst.Add("F")
                namelst.Add("M")

                If (namelst IsNot Nothing) Then

                    If (namelst.Count > 0) Then
                        For i As Integer = 0 To namelst.Count - 1
                            cls = New ClsPtnDtlsSetup
                            cls = getproperties(namelst(i))
                            clslst.Add(cls)
                        Next

                    End If

                End If
            End If

            setproperties = clslst

        Catch ex As Exception
            setproperties = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return setproperties
    End Function



    Public Shared Function getproperties(ByVal name As Char) As ClsPtnDtlsSetup
        Dim clsproperty As New ClsPtnDtlsSetup
        Select Case (name)
            Case "F"
                clsproperty.Name = "FIRST NAME"
                clsproperty.Tooltip = "ENTER FIRST NAME"
                clsproperty.WaterMark = "FIRST NAME"
            Case "M"

                clsproperty.Name = "MIDDLE NAME"
                clsproperty.Tooltip = "ENTER MIDDLE NAME"
                clsproperty.WaterMark = "MIDDLE NAME"
            Case "L"

                clsproperty.Name = "LAST NAME"
                clsproperty.Tooltip = "ENTER LAST NAME"
                clsproperty.WaterMark = "LAST NAME"
            Case Else

                clsproperty.Name = "NAME"
                clsproperty.Tooltip = "ENTER NAME"
                clsproperty.WaterMark = "NAME"
        End Select
        Return clsproperty
    End Function


#End Region





End Class
<DataContract()>
Public Class PatientDetails
    '<DataMember()>
    'Public Property PatientNo As Integer
    <DataMember()>
    Public Property PatientNo As Long 'anamika 20160927
    <DataMember()>
    Public Property Gender As String
    <DataMember()>
    Public Property Age As String
    <DataMember()>
    Public Property Agetypflg As String


    <DataMember()>
    Public Property PatientTitleCodeDesc As String
    <DataMember()>
    Public Property PatientFirstName As String
    <DataMember()>
    Public Property PatientMiddleName As String
    <DataMember()>
    Public Property PatientLastName As String
    <DataMember()>
    Public Property PatientFullName As String
    <DataMember()>
    Public Property PatientClass As String
    <DataMember()>
    Public Property MRNo As Integer
    <DataMember()>
    Public Property IsMember() As Boolean
    <DataMember()>
    Public Property MembershipPerc() As Double
    <DataMember()>
    Public Property Photo() As Byte()

    <DataMember()>
    Public Property DepositBalance As String
    <DataMember()>
    Public Property BillTyp() As Integer
    <DataMember()>
    Public Property ArCd() As Long
    <DataMember()>
    Public Property TYPFLG() As String
    <DataMember()>
    Public Property EXPDT() As DateTime
    <DataMember()>
    Public Property EMPNO() As String
    <DataMember()>
    Public Property Status() As Boolean
    <DataMember()>
    Public Property DctFullName As String 'mayur 20140724
    <DataMember()>
    Public Property DctStatus As Integer 'mayur 20140724
    <DataMember()>
    Public Property DoctorCode As Integer 'mayur 20140724
    <DataMember()>
    Public Property ArEmpcd As String 'Rushikesh 20190731
    <DataMember()>
    Public Property PtnRefByTyp As Integer 'Rushikesh 20190731
    <DataMember()>
    Public Property PtnRefBycd As String 'Rushikesh 20190731

    <DataMember()>
    Public Property IsPtnBlackListed() As Boolean 'shital 20191220

    <DataMember()>
    Public Property PtnBlackListedRsn As String 'shital 20191220

    <DataMember()>
    Public Property PtnRmrk As String 'Nikita 20200117
    <DataMember()>
    Public Property CampCd As Integer

    <DataMember()>
    Public Property MapConcType As Integer  'Amol 24-03-2020 CMCH-141969

    <DataMember()>
    Public Property BirthDate As Nullable(Of DateTime)

    <DataMember()>
    Public Property istranblocked As Integer

    <DataMember()>
    Public Property PtnCareModelDCd As String

    <DataMember()>
    Public Property PtnCareModelRmrk As String

    <DataMember()>
    Public Property PtnType As String


    <DataMember()>
    Public Property PrmntPtnno As String

End Class

