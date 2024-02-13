Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon

''' <summary>
''' Entity class of clsDoctor
''' </summary>
''' <remarks></remarks>
''' 
<DataContract()>
Public Class clsDoctor


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
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataMember()>
    Public Property DoctorLastName As String
    <DataMember()>
    Public Property DoctorFullName As String
    <DataMember()>
    Public Property SpecialityCode() As Integer
    <DataMember()>
    Public Property SpecialityCodeDesc() As String
    <DataMember()>
    Public Property Status() As Boolean
    <DataMember()>
    Public Property NoOfSlots() As Integer = 0
    <DataMember()>
    Public Property NoOfOverLoad() As Integer = 0
    <DataMember()>
    Public Property IsAdmissionAllowed() As Boolean = False 'anamika 20160801


#Region "Admission Doctor Help List"
    ''' <summary>
    ''' Gets list of all doctors
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function AdmissionDoctorList(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer
                                                     ) As List(Of clsDoctor)
        AdmissionDoctorList = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST005(companycode, div, loc))
            Dim objDoctorlist As List(Of clsDoctor) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of clsDoctor)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As New clsDoctor
                    'objDoctor.CompanyCode = companycode
                    'objDoctor.DivisionCode = div
                    'objDoctor.LocationCode = loc
                    objDoctor.DoctorCode = ds.Tables(0).Rows(i).Item("DoctorCode")
                    objDoctor.DoctorFirstName = ds.Tables(0).Rows(i).Item("DoctorFirstName")
                    objDoctor.DoctorMiddleName = ds.Tables(0).Rows(i).Item("DoctorMiddleName")
                    objDoctor.DoctorLastName = ds.Tables(0).Rows(i).Item("DoctorLastName")
                    objDoctor.DoctorFullName = ds.Tables(0).Rows(i).Item("DoctorFullName")
                    objDoctor.DoctorTitleCode = ds.Tables(0).Rows(i).Item("DoctorTitleCode")
                    objDoctor.DoctorTitleCodeDesc = ds.Tables(0).Rows(i).Item("DoctorTitleCodeDesc")
                    objDoctor.Status = ds.Tables(0).Rows(i).Item("Status")
                    objDoctor.SpecialityCode = ds.Tables(0).Rows(i).Item("SpecialityCode")
                    objDoctor.SpecialityCodeDesc = ds.Tables(0).Rows(i).Item("SpecialityCodeDesc")

                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            AdmissionDoctorList = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            AdmissionDoctorList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' adds paramters to store procedure SPSELDOCMST005
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELDOCMST005(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST005]" 'doc_mst,cd_dcd

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


#Region "Doctor Help List (All Doctors)"
    ''' <summary>
    ''' Gets list of all doctors
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetAllDoctorList(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer
                                                     ) As List(Of clsDoctor)
        GetAllDoctorList = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST013(companycode, div, loc))
            Dim objDoctorlist As List(Of clsDoctor) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of clsDoctor)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As New clsDoctor
                    'objDoctor.CompanyCode = companycode
                    'objDoctor.DivisionCode = div
                    'objDoctor.LocationCode = loc
                    objDoctor.DoctorCode = ds.Tables(0).Rows(i).Item("DoctorCode")
                    objDoctor.DoctorFirstName = ds.Tables(0).Rows(i).Item("DoctorFirstName")
                    objDoctor.DoctorMiddleName = ds.Tables(0).Rows(i).Item("DoctorMiddleName")
                    objDoctor.DoctorLastName = ds.Tables(0).Rows(i).Item("DoctorLastName")
                    objDoctor.DoctorFullName = ds.Tables(0).Rows(i).Item("DoctorFullName")
                    objDoctor.DoctorTitleCode = ds.Tables(0).Rows(i).Item("DoctorTitleCode")
                    objDoctor.DoctorTitleCodeDesc = ds.Tables(0).Rows(i).Item("DoctorTitleCodeDesc")
                    objDoctor.Status = ds.Tables(0).Rows(i).Item("Status")
                    objDoctor.SpecialityCode = ds.Tables(0).Rows(i).Item("SpecialityCode")
                    objDoctor.SpecialityCodeDesc = ds.Tables(0).Rows(i).Item("SpecialityCodeDesc")

                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            GetAllDoctorList = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            GetAllDoctorList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' adds paramters to store procedure SPSELDOCMST
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELDOCMST013(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST013]" 'doc_mst,cd_dcd

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


#Region "Doctor Help List(With Active Doctor)"
    ''' <summary>
    ''' Gets list of all doctors
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetDoctorList(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer
                                                     ) As List(Of clsDoctor)
        GetDoctorList = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST(companycode, div, loc))
            Dim objDoctorlist As List(Of clsDoctor) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of clsDoctor)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As New clsDoctor
                    'objDoctor.CompanyCode = companycode
                    'objDoctor.DivisionCode = div
                    'objDoctor.LocationCode = loc
                    objDoctor.DoctorCode = ds.Tables(0).Rows(i).Item("DoctorCode")
                    objDoctor.DoctorFirstName = ds.Tables(0).Rows(i).Item("DoctorFirstName")
                    objDoctor.DoctorMiddleName = ds.Tables(0).Rows(i).Item("DoctorMiddleName")
                    objDoctor.DoctorLastName = ds.Tables(0).Rows(i).Item("DoctorLastName")
                    objDoctor.DoctorFullName = ds.Tables(0).Rows(i).Item("DoctorFullName")
                    objDoctor.DoctorTitleCode = ds.Tables(0).Rows(i).Item("DoctorTitleCode")
                    objDoctor.DoctorTitleCodeDesc = ds.Tables(0).Rows(i).Item("DoctorTitleCodeDesc")
                    objDoctor.Status = ds.Tables(0).Rows(i).Item("Status")
                    objDoctor.SpecialityCode = ds.Tables(0).Rows(i).Item("SpecialityCode")
                    objDoctor.SpecialityCodeDesc = ds.Tables(0).Rows(i).Item("SpecialityCodeDesc")

                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            GetDoctorList = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            GetDoctorList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' adds paramters to store procedure SPSELDOCMST
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELDOCMST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST]" 'doc_mst,cd_dcd

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



#Region "Get Doctor With Scheduling Details"
    Shared Function GetDoctorWithScheduleDtl(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer, _
                                                      ByVal doctorcode As Integer) As clsDoctor
        GetDoctorWithScheduleDtl = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST001(companycode, div, loc, doctorcode))
            Dim objDoctor As clsDoctor = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctor = New clsDoctor
                objDoctor.DoctorCode = ds.Tables(0).Rows(0).Item("DoctorCode")
                objDoctor.DoctorFirstName = ds.Tables(0).Rows(0).Item("DoctorFirstName")
                objDoctor.DoctorMiddleName = ds.Tables(0).Rows(0).Item("DoctorMiddleName")
                objDoctor.DoctorLastName = ds.Tables(0).Rows(0).Item("DoctorLastName")
                objDoctor.DoctorFullName = ds.Tables(0).Rows(0).Item("DoctorFullName")
                objDoctor.DoctorTitleCode = ds.Tables(0).Rows(0).Item("DoctorTitleCode")
                objDoctor.DoctorTitleCodeDesc = ds.Tables(0).Rows(0).Item("DoctorTitleCodeDesc")
                '  objDoctor.Status = ds.Tables(0).Rows(0).Item("Status")
                objDoctor.Status = IIf(ds.Tables(0).Rows(0).Item("Status") = 2, False, True) 'anamika 20140714
                objDoctor.SpecialityCode = ds.Tables(0).Rows(0).Item("SpecialityCode")
                objDoctor.SpecialityCodeDesc = ds.Tables(0).Rows(0).Item("SpecialityCodeDesc")
                Dim objMstList As New List(Of clsMaster)
                objMstList = clsMaster.GetFctMstDtlList(strErrMsg, chrErrFlg, companycode, div, loc, doctorcode, objDoctor.SpecialityCode, 2)
                If objMstList IsNot Nothing Then

                    objDoctor.NoOfOverLoad = objMstList(0).data1
                    Dim mins As Long = 0
                    mins = (IIf(IsDBNull(objMstList(0).data2), 0, (objMstList(0).data2) * 60)) + IIf(IsDBNull(objMstList(0).data3), 0, objMstList(0).data3)
                    objDoctor.NoOfSlots = mins  'from here it will pass as a time of session in minutes
                    objMstList = Nothing

                Else

                    GetDoctorWithScheduleDtl = Nothing 'anamika 20170129
                    strErrMsg.Add("Please Schedule Doctor") 'anamika 20170129
                    chrErrFlg = "Y" 'anamika 20170129
                    Exit Function 'anamika 20170129
                    'objDoctor.NoOfOverLoad = 0
                    'objDoctor.NoOfSlots = 0 'from here it will pass as a time of session in minutes
                    'objMstList = Nothing
                End If

            End If
            ds.Dispose()
            GetDoctorWithScheduleDtl = objDoctor
            ofactory = Nothing
        Catch ex As Exception
            GetDoctorWithScheduleDtl = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
#End Region
#Region "Help for single doctor"
    ''' <summary>
    ''' Gets details of doctor
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="doctorcode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetDoctor(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer, _
                                                      ByVal doctorcode As Integer) As clsDoctor
        GetDoctor = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST001(companycode, div, loc, doctorcode))
            Dim objDoctor As clsDoctor = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctor = New clsDoctor
                objDoctor.DoctorCode = ds.Tables(0).Rows(0).Item("DoctorCode")
                objDoctor.DoctorFirstName = ds.Tables(0).Rows(0).Item("DoctorFirstName")
                objDoctor.DoctorMiddleName = ds.Tables(0).Rows(0).Item("DoctorMiddleName")
                objDoctor.DoctorLastName = ds.Tables(0).Rows(0).Item("DoctorLastName")
                objDoctor.DoctorFullName = ds.Tables(0).Rows(0).Item("DoctorFullName")
                objDoctor.DoctorTitleCode = ds.Tables(0).Rows(0).Item("DoctorTitleCode")
                objDoctor.DoctorTitleCodeDesc = ds.Tables(0).Rows(0).Item("DoctorTitleCodeDesc")
                '  objDoctor.Status = ds.Tables(0).Rows(0).Item("Status")
                objDoctor.Status = IIf(ds.Tables(0).Rows(0).Item("Status") = 2, False, True) 'anamika 20140714
                objDoctor.SpecialityCode = ds.Tables(0).Rows(0).Item("SpecialityCode")
                objDoctor.SpecialityCodeDesc = ds.Tables(0).Rows(0).Item("SpecialityCodeDesc")
                Dim objMstList As New List(Of clsMaster)
                objMstList = clsMaster.GetFctMstDtlList(strErrMsg, chrErrFlg, companycode, div, loc, doctorcode, objDoctor.SpecialityCode, 2)
                If objMstList IsNot Nothing Then

                    objDoctor.NoOfOverLoad = objMstList(0).data1
                    Dim mins As Long = 0
                    mins = (IIf(IsDBNull(objMstList(0).data2), 0, (objMstList(0).data2) * 60)) + IIf(IsDBNull(objMstList(0).data3), 0, objMstList(0).data3)
                    objDoctor.NoOfSlots = mins  'from here it will pass as a time of session in minutes
                    objMstList = Nothing

                Else

                    'GetDoctor = Nothing 'anamika 20170129
                    'strErrMsg.Add("Please Schedule Doctor") 'anamika 20170129
                    'chrErrFlg = "Y" 'anamika 20170129
                    'Exit Function 'anamika 20170129
                    objDoctor.NoOfOverLoad = 0
                    objDoctor.NoOfSlots = 0 'from here it will pass as a time of session in minutes
                    objMstList = Nothing
                End If

            End If
            ds.Dispose()
            GetDoctor = objDoctor
            ofactory = Nothing
        Catch ex As Exception
            GetDoctor = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' adds paramters to store procedure SPSELDOCMST001
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="doctorcode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELDOCMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal doctorcode As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST001]" 'doc_mst   cd_dcd

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
            oParam.ParamName = "pDCT"
            oParam.ParamValue = doctorcode
            .Parameters.Add(oParam)


            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function

#End Region

#Region "Specialitywise doctor  List"
    ''' <summary>
    '''Get doctor list by speciality
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="SpecialityCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Shared Function GetDoctorListBySpeciality(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer, _
                                                       ByVal SpecialityCd As Integer
                                                     ) As List(Of clsDoctor)
        GetDoctorListBySpeciality = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMSTBYSPECIALITY(companycode, div, loc, SpecialityCd))
            Dim objDoctorlist As List(Of clsDoctor) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of clsDoctor)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As New clsDoctor
                    'objDoctor.CompanyCode = companycode
                    'objDoctor.DivisionCode = div
                    'objDoctor.LocationCode = loc
                    objDoctor.DoctorCode = ds.Tables(0).Rows(i).Item("DoctorCode")
                    objDoctor.DoctorFirstName = ds.Tables(0).Rows(i).Item("DoctorFirstName")
                    objDoctor.DoctorMiddleName = ds.Tables(0).Rows(i).Item("DoctorMiddleName")
                    objDoctor.DoctorLastName = ds.Tables(0).Rows(i).Item("DoctorLastName")
                    objDoctor.DoctorFullName = ds.Tables(0).Rows(i).Item("DoctorFullName")
                    objDoctor.DoctorTitleCode = ds.Tables(0).Rows(i).Item("DoctorTitleCode")
                    objDoctor.DoctorTitleCodeDesc = ds.Tables(0).Rows(i).Item("DoctorTitleCodeDesc")
                    objDoctor.Status = ds.Tables(0).Rows(i).Item("Status")
                    objDoctor.SpecialityCode = ds.Tables(0).Rows(i).Item("SpecialityCode")
                    objDoctor.SpecialityCodeDesc = ds.Tables(0).Rows(i).Item("SpecialityCodeDesc")

                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            GetDoctorListBySpeciality = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            GetDoctorListBySpeciality = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' Stored procedure to get doctor details by speciality
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="SpecialityCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELDOCMSTBYSPECIALITY(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal SpecialityCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMSTBYSPECIALITY]"

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
            oParam.ParamName = "pSpecialityCd"
            oParam.ParamValue = SpecialityCd
            .Parameters.Add(oParam)


            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function
#End Region

#Region "Doctor full name"
    ''' <summary>
    ''' Gets Doctors fullname in standard format
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="doctorcode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetPatientFullName(ByRef strErrMsg As List(Of String), _
                               ByRef chrErrFlg As Char, _
                               ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                               ByVal doctorcode As Integer) As String
        GetPatientFullName = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .CommandType = CommandType.Text


                .Command = "SELECT dbo.[fn_IpOPName] (@IPOP ,@IPOPNo)"

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@IPOP"
                oParam.ParamValue = "O"
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@IPOPNo"
                oParam.ParamValue = doctorcode
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

#Region " Selects doctor details [cd/decode]"   'RasikV 20161019
    Shared Function GetDocDtls(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, _
           ByVal loc As Integer) As List(Of clsDoctorHelp)
        GetDocDtls = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST(companycode, div, loc))
            Dim objDoctorlist As List(Of clsDoctorHelp) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of clsDoctorHelp)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As New clsDoctorHelp
                    objDoctor.Code = ds.Tables(0).Rows(i).Item("DoctorCode")
                    objDoctor.Decode = ds.Tables(0).Rows(i).Item("DoctorFullName")
                    objDoctor.Speciality = ds.Tables(0).Rows(i).Item("SpecialityCodeDesc")
                    objDoctor.SpecialityCd = ds.Tables(0).Rows(i).Item("SpecialityCode")
                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            GetDocDtls = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            GetDocDtls = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
#End Region

#Region " Selects doctor details [cd/decode] for given cd"   'RasikV 20161020
    Shared Function GetDocNameByCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, _
           ByVal loc As Integer, ByVal DoctorCode As Integer) As String
        GetDocNameByCd = Nothing
        Dim ofactory As New DBFactory
        'Dim objDoctor As clsDoctorHelp = Nothing
        Try
            Dim ds As DataSet = ofactory.ExecuteDataSet(SpSelDocMst002(cocd, div, loc, DoctorCode))
            If ds.Tables(0).Rows.Count <> 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    GetDocNameByCd = ds.Tables(0).Rows(0).Item("ttl_Dcd") + " " + ds.Tables(0).Rows(0).Item("doc_lst_nm") + " " + ds.Tables(0).Rows(0).Item("doc_mid_nm") + " " + ds.Tables(0).Rows(0).Item("doc_frst_nm")
                Next
            End If
            ds.Dispose()


        Catch ex As Exception
            GetDocNameByCd = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            ofactory = Nothing
        End Try
        Return GetDocNameByCd
    End Function
#End Region

#End Region



#Region "Get Doctor Details By Passing doctor code"
    ''' <summary>
    ''' Get Doctor Details By Passing doctor code
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="doctorcode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetDoctorDetailByDocCd(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal cocd As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer, _
                                                      ByVal doctorcode As Integer) As clsDoctorDetails
        GetDoctorDetailByDocCd = Nothing
        Dim ofactory As New DBFactory
        Dim objDoctor As clsDoctorDetails = Nothing
        Try
            Dim ds As DataSet = ofactory.ExecuteDataSet(SpSelDocMst002(cocd, div, loc, doctorcode))
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctor = New clsDoctorDetails
                objDoctor.DoctorCode = ds.Tables(0).Rows(0).Item("doc_cd")
                objDoctor.OldDocCd = ds.Tables(0).Rows(0).Item("old_doc_cd")
                objDoctor.DoctorTitleCode = ds.Tables(0).Rows(0).Item("ttl_cd")
                objDoctor.DocRgs = ds.Tables(0).Rows(0).Item("doc_rgs")
                objDoctor.DoctorLastName = ds.Tables(0).Rows(0).Item("doc_lst_nm")
                objDoctor.DoctorFirstName = ds.Tables(0).Rows(0).Item("doc_frst_nm")
                objDoctor.DoctorMiddleName = ds.Tables(0).Rows(0).Item("doc_mid_nm")
                objDoctor.DoctorFullName = ds.Tables(0).Rows(0).Item("ttl_Dcd") + " " + ds.Tables(0).Rows(0).Item("doc_lst_nm") + " " + ds.Tables(0).Rows(0).Item("doc_mid_nm") + " " + ds.Tables(0).Rows(0).Item("doc_frst_nm")
                objDoctor.DocAbrvNm = ds.Tables(0).Rows(0).Item("doc_abrv_nm")
                objDoctor.DocEducation = ds.Tables(0).Rows(0).Item("doc_education")
                objDoctor.DocTypCd = ds.Tables(0).Rows(0).Item("doc_typ_cd")
                objDoctor.SpecialityCode = ds.Tables(0).Rows(0).Item("splty_cd")
                objDoctor.SchTypCd = ds.Tables(0).Rows(0).Item("sch_typ_cd")
                objDoctor.DocResAdd1 = ds.Tables(0).Rows(0).Item("doc_res_addrs1")
                objDoctor.DocResAdd2 = ds.Tables(0).Rows(0).Item("doc_res_addrs2")
                objDoctor.DocResAdd3 = ds.Tables(0).Rows(0).Item("doc_res_addrs3")
                objDoctor.DocResCity = ds.Tables(0).Rows(0).Item("doc_res_city")
                objDoctor.DocResCntry = ds.Tables(0).Rows(0).Item("doc_res_cntry")
                objDoctor.DocResPin = ds.Tables(0).Rows(0).Item("doc_res_pin")
                objDoctor.DocResTel = ds.Tables(0).Rows(0).Item("doc_res_tel")
                objDoctor.DocClncAdd1 = ds.Tables(0).Rows(0).Item("doc_clnc_addrs1")
                objDoctor.DocClncAdd2 = ds.Tables(0).Rows(0).Item("doc_clnc_addrs2")
                objDoctor.DocClncAdd3 = ds.Tables(0).Rows(0).Item("doc_clnc_addrs3")
                objDoctor.DocClncCity = ds.Tables(0).Rows(0).Item("doc_clnc_city")
                objDoctor.DocClncCntry = ds.Tables(0).Rows(0).Item("doc_clnc_cntry")
                objDoctor.DocClncPin = ds.Tables(0).Rows(0).Item("doc_clnc_pin")
                objDoctor.DocClncTel = ds.Tables(0).Rows(0).Item("doc_clnc_tel")
                objDoctor.TiFlg = ds.Tables(0).Rows(0).Item("ti_flg")
                objDoctor.PerAcFlg = ds.Tables(0).Rows(0).Item("per_ac_flg")
                objDoctor.Status = ds.Tables(0).Rows(0).Item("doc_sts_cd")
                objDoctor.DoctorStatus = ds.Tables(0).Rows(0).Item("doc_sts_cd") 'anamika 20140922
                objDoctor.DocDdnCd = ds.Tables(0).Rows(0).Item("doc_ddn_cd")
                objDoctor.MinDdn = ds.Tables(0).Rows(0).Item("min_ddn")
                objDoctor.MaxDdn = ds.Tables(0).Rows(0).Item("max_ddn")
                objDoctor.LstInvDt = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("lst_inv_dt")), Date.MinValue, ds.Tables(0).Rows(0).Item("lst_inv_dt"))
                objDoctor.LstPmntDt = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("lst_pmnt_dt")), Date.MinValue, ds.Tables(0).Rows(0).Item("lst_pmnt_dt"))
                objDoctor.LstBlPstDt = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("lst_bl_pst_dt")), Date.MinValue, ds.Tables(0).Rows(0).Item("lst_bl_pst_dt"))
                objDoctor.No = ds.Tables(0).Rows(0).Item("no")
                objDoctor.Email = ds.Tables(0).Rows(0).Item("Email")
                objDoctor.MobileNo = ds.Tables(0).Rows(0).Item("MobileNo")
                objDoctor.GenOpdTmFr = ds.Tables(0).Rows(0).Item("GenOpdTmFr")
                objDoctor.GenOpdTmTo = ds.Tables(0).Rows(0).Item("GenOpdTmTo")
                objDoctor.PvtOpdTmFr = ds.Tables(0).Rows(0).Item("PvtOpdTmFr")
                objDoctor.PvtOpdTmTo = ds.Tables(0).Rows(0).Item("PvtOpdTmTo")
                objDoctor.panno = ds.Tables(0).Rows(0).Item("panno")
                objDoctor.DocBnkCd = ds.Tables(0).Rows(0).Item("doc_bnk_cd")
                objDoctor.BankAc = ds.Tables(0).Rows(0).Item("bnk_ac")
                objDoctor.DocBranch = ds.Tables(0).Rows(0).Item("doc_branch")
                objDoctor.DocIfscCd = ds.Tables(0).Rows(0).Item("doc_ifscd")
                objDoctor.DocDeptCd = ds.Tables(0).Rows(0).Item("doc_dept_cd")
                objDoctor.Gender = ds.Tables(0).Rows(0).Item("gender")
                objDoctor.Tds = ds.Tables(0).Rows(0).Item("tds") 'anamika 20140923
                objDoctor.Dob = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dob")), Date.MinValue, ds.Tables(0).Rows(0).Item("dob"))
                objDoctor.IsAdmissionAllowed = ds.Tables(0).Rows(0).Item("IsAdmissionAllowed") 'anamika 20160730
                objDoctor.IsTdsVoluntary = ds.Tables(0).Rows(0).Item("IsTdsVoluntary") 'Pramila 20161105
            End If
            ds.Dispose()
            GetDoctorDetailByDocCd = objDoctor

        Catch ex As Exception
            GetDoctorDetailByDocCd = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
            objDoctor = Nothing
        End Try
        Return GetDoctorDetailByDocCd
    End Function
    ''' <summary>
    ''' sp to get details of doctor by passing doctor code
    ''' </summary>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="doctorcode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SpSelDocMst002(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal doctorcode As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelDocMst002]" 'doc_mst  
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivcd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLocCd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDoccd"
            oParam.ParamValue = doctorcode
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region

#Region "Check Doctor Existance"
    Shared Function CheckDoctorCdExistance(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                               ByRef chrErrFlg As Char, _
                               ByVal cocd As String, _
                               ByVal div As Integer, _
                               ByVal loc As Integer, ByVal DocCd As Integer) As Boolean

        Dim ofactory As DBFactory
        CheckDoctorCdExistance = 0
        ofactory = New DBFactory

        Dim OutBedNo As Integer = 0
        Try

            Dim ds As DataSet = ofactory.ExecuteDataSet(FnCheckDoctorCdExistance(cocd, div, loc, docCd))
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    CheckDoctorCdExistance = IIf(IsDBNull(ds.Tables(0).Rows(i).Item(0)), 0, ds.Tables(0).Rows(i).Item(0))
                Next
            End If
            ds.Dispose()
        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            CheckDoctorCdExistance = Nothing
            Return CheckDoctorCdExistance
        End Try

    End Function
    Public Shared Function FnCheckDoctorCdExistance(ByVal cocd As String, _
                              ByVal div As Integer, _
                              ByVal loc As Integer, ByVal DocCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "SELECT dbo.[FnCheckDoctorCdExistance]('" & cocd & "','" & div & "','" & loc & "','" & DocCd & "')"
            .CommandType = CommandType.Text


        End With
        Return oRequest
    End Function
#End Region


#Region "Get doc mst data(join with op_token_doc)" 'mayur 20150128
    ''' <summary>
    '''Get doc mst data(join with op_token_doc)
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetDoctorDetailForVstRegType(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal cocd As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer
                                                      ) As List(Of clsDoctorDetails)
        GetDoctorDetailForVstRegType = Nothing
        Dim ofactory As New DBFactory
        Dim objDoctorlist As New List(Of clsDoctorDetails)
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelDocMst003(cocd, div, loc))
            While dr1.Read()
                With dr1
                    Dim objDoctor As New clsDoctorDetails
                    objDoctor.DoctorCode = .Item("doc_cd")
                    objDoctor.DoctorFullName = .Item("doc_nm")
                    objDoctor.SpecialityCode = .Item("splty_cd")
                    objDoctor.SpecialityCodeDesc = .Item("splty_dcd")
                    objDoctorlist.Add(objDoctor)
                End With
            End While
            dr1.close()
            GetDoctorDetailForVstRegType = objDoctorlist
        Catch ex As Exception
            GetDoctorDetailForVstRegType = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetDoctorDetailForVstRegType
    End Function
    ''' <summary>
    ''' Get doc mst data(join with op_token_doc)
    ''' </summary>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SpSelDocMst003(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelDocMst003]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
#End Region



#Region "all scheduled Doctor Help List "
    ''' <summary>
    ''' Gets list of all doctors
    ''' aparna 15 oct 2015
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetDoctorListByRevDt(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer, _
                                                      ByVal RevDt As String
                                                     ) As List(Of clsDoctor)
        GetDoctorListByRevDt = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST004(companycode, div, loc, RevDt))
            Dim objDoctorlist As List(Of clsDoctor) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of clsDoctor)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As New clsDoctor

                    objDoctor.DoctorCode = ds.Tables(0).Rows(i).Item("DoctorCode")
                    objDoctor.DoctorFirstName = ds.Tables(0).Rows(i).Item("DoctorFirstName")
                    objDoctor.DoctorMiddleName = ds.Tables(0).Rows(i).Item("DoctorMiddleName")
                    objDoctor.DoctorLastName = ds.Tables(0).Rows(i).Item("DoctorLastName")
                    objDoctor.DoctorFullName = ds.Tables(0).Rows(i).Item("DoctorFullName")
                    objDoctor.DoctorTitleCode = ds.Tables(0).Rows(i).Item("DoctorTitleCode")
                    objDoctor.DoctorTitleCodeDesc = ds.Tables(0).Rows(i).Item("DoctorTitleCodeDesc")
                    objDoctor.Status = ds.Tables(0).Rows(i).Item("Status")
                    objDoctor.SpecialityCode = ds.Tables(0).Rows(i).Item("SpecialityCode")
                    objDoctor.SpecialityCodeDesc = ds.Tables(0).Rows(i).Item("SpecialityCodeDesc")

                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            GetDoctorListByRevDt = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            GetDoctorListByRevDt = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' adds paramters to store procedure SPSELDOCMST
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELDOCMST004(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal RevDt As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST004]" 'doc_mst,cd_dcd

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
            oParam.ParamName = "pDate"
            oParam.ParamValue = RevDt
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function
#End Region


#Region "To check doctor availability by passing rev dt and doc cd"

    ''' <summary>
    ''' APARNA 24-OCT-2015
    ''' To check doctor availability by passing rev dt and doc cd"
    ''' </summary>

    Shared Function CheckDocAvailablityByRevDt(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer,
                                              ByVal loc As Integer, ByVal currentdt As String, ByVal Doccd As Integer) As Integer

        Dim ofactory As DBFactory
        CheckDocAvailablityByRevDt = 0
        ofactory = New DBFactory
        Try

            Dim ds As DataSet = ofactory.ExecuteDataSet(Fn0000100001DCTAVLAPP(companycode, div, loc, currentdt, Doccd))
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    CheckDocAvailablityByRevDt = IIf(IsDBNull(ds.Tables(0).Rows(i).Item(0)), 0, ds.Tables(0).Rows(i).Item(0))
                Next
            End If
            ds.Dispose()
        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            CheckDocAvailablityByRevDt = Nothing
            Return CheckDocAvailablityByRevDt
        End Try

    End Function

    Shared Function Fn0000100001DCTAVLAPP(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal currentdt As String, ByVal Doccd As Integer) As DBRequest

        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        With orequest
            orequest.Command = "SELECT dbo.[Fn0000100001DCTAVLAPP]('" & companycode & "','" & div & "','" & loc & "','" & currentdt & "','" & Doccd & "') "
        End With
        Return orequest
    End Function


#End Region


#Region "Get Doctor With Admission"
    ''' <summary>
    ''' Get Admission Doctor by cd
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="doctorcode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetAdmissionDoctorByCd(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer, _
                                                      ByVal doctorcode As Integer) As clsDoctor
        GetAdmissionDoctorByCd = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST001(companycode, div, loc, doctorcode))
            Dim objDoctor As clsDoctor = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctor = New clsDoctor
                objDoctor.DoctorCode = ds.Tables(0).Rows(0).Item("DoctorCode")
                objDoctor.DoctorFirstName = ds.Tables(0).Rows(0).Item("DoctorFirstName")
                objDoctor.DoctorMiddleName = ds.Tables(0).Rows(0).Item("DoctorMiddleName")
                objDoctor.DoctorLastName = ds.Tables(0).Rows(0).Item("DoctorLastName")
                objDoctor.DoctorFullName = ds.Tables(0).Rows(0).Item("DoctorFullName")
                objDoctor.DoctorTitleCode = ds.Tables(0).Rows(0).Item("DoctorTitleCode")
                objDoctor.DoctorTitleCodeDesc = ds.Tables(0).Rows(0).Item("DoctorTitleCodeDesc")
                '  objDoctor.Status = ds.Tables(0).Rows(0).Item("Status")
                objDoctor.Status = IIf(ds.Tables(0).Rows(0).Item("Status") = 2, False, True)
                objDoctor.SpecialityCode = ds.Tables(0).Rows(0).Item("SpecialityCode")
                objDoctor.SpecialityCodeDesc = ds.Tables(0).Rows(0).Item("SpecialityCodeDesc")
                objDoctor.IsAdmissionAllowed = ds.Tables(0).Rows(0).Item("IsAdmissionAllowed")

            End If
            ds.Dispose()
            GetAdmissionDoctorByCd = objDoctor
            ofactory = Nothing
        Catch ex As Exception
            GetAdmissionDoctorByCd = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function


#End Region

#Region "Get Doctor Room No By Passing Doc_Cd"
    ''' <summary>
    ''' Get Doctor Room No By Passing Doc_Cd
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="doctorcode"></param>
    ''' <returns></returns>
    ''' <remarks>APARNA 7 SEP 2016</remarks>
    Shared Function GetDoctorRoomNoByDocCd(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer, _
                                                      ByVal doctorcode As Integer) As String
        GetDoctorRoomNoByDocCd = Nothing
        Dim ofactory As DBFactory

        ofactory = New DBFactory
        Try

            Dim ds As DataSet = ofactory.ExecuteDataSet(FNGETROOMNOBYDOCCD(companycode, div, loc, doctorcode))
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    GetDoctorRoomNoByDocCd = IIf(IsDBNull(ds.Tables(0).Rows(i).Item(0)), "", ds.Tables(0).Rows(i).Item(0))
                Next
            End If
            ds.Dispose()
        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetDoctorRoomNoByDocCd = Nothing

        End Try
        Return GetDoctorRoomNoByDocCd
    End Function

    Shared Function FNGETROOMNOBYDOCCD(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                ByVal doctorcode As Integer) As DBRequest

        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        With orequest
            orequest.Command = "SELECT dbo.[FNGETROOMNOBYDOCCD]('" & companycode & "','" & div & "','" & loc & "','" & doctorcode & "') roomno"
        End With
        Return orequest
    End Function
#End Region

#Region "GetFctAptOtDocList/SPSELDOCMST007 :"
    'pragya : 14-oct-2016
    Shared Function GetFctAptOtDocList(ByRef strErrMsg As List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal companycode As String, _
                                  ByVal div As Integer, _
                                  ByVal loc As Integer,
                                  ByVal DocCd As Integer) As clsOtDocDtls
        GetFctAptOtDocList = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELDOCMST007(companycode, div, loc, DocCd))
            Dim obj As New clsOtDocDtls
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj.DoctorCode = DocCd
                        obj.DoctorFullName = .item("DoctorFullName")
                        obj.SpecialityCode = .item("SpecialityCode")
                        obj.SpecialityCodeDesc = .item("SpecialityCodeDesc")
                        obj.AnesthesiaCd = 0
                        obj.AnesthesiaDesc = ""
                        obj.NurseName = ""

                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetFctAptOtDocList = obj
            Return GetFctAptOtDocList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


    Shared Function SPSELDOCMST007(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal DocCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST007]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function




#End Region
#Region " Selects doctor details "
    ''' <summary>
    ''' APARNA 7 NOV 2016
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetDocList(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, _
           ByVal loc As Integer, ByVal chrgcd As Integer, ByVal srvcd As Integer) As List(Of clsDoctorHelp)
        GetDocList = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST008(companycode, div, loc, chrgcd, srvcd))
            Dim objDoctorlist As List(Of clsDoctorHelp) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of clsDoctorHelp)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As New clsDoctorHelp
                    objDoctor.Code = ds.Tables(0).Rows(i).Item("doccd")
                    objDoctor.Decode = ds.Tables(0).Rows(i).Item("DoctorFullName")
                    objDoctor.SpecialityCd = ds.Tables(0).Rows(i).Item("SpecialityCode")
                    objDoctor.Speciality = ds.Tables(0).Rows(i).Item("SpecialityCodeDesc")

                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            GetDocList = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            GetDocList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function


    Shared Function SPSELDOCMST008(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal chrgcd As Integer, ByVal srvcd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST008]" 'doc_mst,cd_dcd

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
            oParam.ParamName = "pchrgcd"
            oParam.ParamValue = chrgcd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "psrvcd"
            oParam.ParamValue = srvcd
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function
#End Region
#Region " Get Doctor Code and Doctor Full Name By doc_sts_cd=1 and Typ=3 "   'Aarti 20161214
    Shared Function GetDocListWithTypWithDocStsCd(ByRef strErrMsg As List(Of String),
                                                  ByRef chrErrFlg As Char, ByVal cocd As String,
                                                  ByVal div As Integer, ByVal loc As Integer) As List(Of clsDoctorHelp)
        GetDocListWithTypWithDocStsCd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST012(cocd, div, loc))
            Dim objDoctorlist As List(Of clsDoctorHelp) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of clsDoctorHelp)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As New clsDoctorHelp
                    objDoctor.Code = ds.Tables(0).Rows(i).Item("cd")
                    objDoctor.Decode = ds.Tables(0).Rows(i).Item("dcd")
                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            GetDocListWithTypWithDocStsCd = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            GetDocListWithTypWithDocStsCd = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SPSELDOCMST012(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST012]" 'doc_mst,cd_dcd

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function
#End Region

#Region "GET DOCTOR TYPE CODE BY PASSING DOCTOR CODE"  'RasikV 20170311
    Shared Function FnGetDocTypByDocCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal DocCd As Integer) As Integer
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnGetDocTypByDocCd]  ('" & CoCd & "','" & Div & "','" & Loc & "','" & DocCd & "') GetDocTypByDocCd"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                FnGetDocTypByDocCd = ds.Tables(0).Rows(0).Item("GetDocTypByDocCd")
            Else
                FnGetDocTypByDocCd = Nothing
            End If
            orequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnGetDocTypByDocCd = Nothing
        End Try
        Return FnGetDocTypByDocCd
    End Function
#End Region

#Region "GET DOCTOR TYPE CODE BY PASSING DOCTOR CODE"  'RasikV 20170311
    Shared Function FnGetSpltyCdByDocCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal DocCd As Integer) As Integer
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnGetSpltyCdByDocCd]  ('" & CoCd & "','" & Div & "','" & Loc & "','" & DocCd & "') GetSpltyCdByDocCd"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                FnGetSpltyCdByDocCd = ds.Tables(0).Rows(0).Item("GetSpltyCdByDocCd")
            Else
                FnGetSpltyCdByDocCd = Nothing
            End If
            orequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnGetSpltyCdByDocCd = Nothing
        End Try
        Return FnGetSpltyCdByDocCd
    End Function
#End Region


#Region "GET DOCTOR NAME BY PASSING DOCTOR CODE"   'RasikV 20170602
    Shared Function GetDocNmByCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, _
           ByVal loc As Integer, ByVal DoctorCode As Integer) As List(Of clsDoctorNm)
        GetDocNmByCd = Nothing
        Dim ofactory As New DBFactory
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelDocMst002(cocd, div, loc, DoctorCode))
            Dim objArr As List(Of clsDoctorNm) = Nothing
            Dim obj As clsDoctorNm = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsDoctorNm)
                While dr1.Read()
                    With dr1
                        obj = New clsDoctorNm
                        obj.DoctorCode = IIf(IsDBNull(.Item("doc_cd")), 0, .Item("doc_cd"))
                        obj.DoctorTitleCode = IIf(IsDBNull(.Item("ttl_cd")), 0, .Item("ttl_cd"))
                        obj.DoctorTitleCodeDesc = IIf(IsDBNull(.Item("ttl_Dcd")), Nothing, .Item("ttl_Dcd"))
                        obj.DoctorFirstName = IIf(IsDBNull(.Item("doc_frst_nm")), Nothing, .Item("doc_frst_nm"))
                        obj.DoctorMiddleName = IIf(IsDBNull(.Item("doc_mid_nm")), Nothing, .Item("doc_mid_nm"))
                        obj.DoctorLastName = IIf(IsDBNull(.Item("doc_lst_nm")), Nothing, .Item("doc_lst_nm"))
                        obj.DoctorFullName = obj.DoctorTitleCodeDesc + " " + obj.DoctorFirstName + " " + obj.DoctorMiddleName + " " + obj.DoctorLastName
                    End With
                    objArr.Add(obj)
                End While
            End If
            dr1.close()
            GetDocNmByCd = objArr
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetDocNmByCd
    End Function
#End Region



#Region "GET DOCTOR LIST FOR RADIOLOGY ENTRY PROGRAM RULE BY PASSING DOCTOR CODE" 'RasikV 20170606
    Shared Function GetDocDtlsByDocCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal Data As String) As List(Of clsDoctorHelp)
        GetDocDtlsByDocCd = Nothing
        Dim ofactory As New DBFactory
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelDocMst014(CoCd, Div, Loc, Data))
            Dim objArr As List(Of clsDoctorHelp) = Nothing
            Dim obj As clsDoctorHelp = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsDoctorHelp)
                While dr1.Read()
                    With dr1
                        obj = New clsDoctorHelp
                        obj.Code = IIf(IsDBNull(.Item("Cd")), 0, .Item("Cd"))
                        obj.Decode = IIf(IsDBNull(.Item("Dcd")), Nothing, .Item("Dcd"))
                    End With
                    objArr.Add(obj)
                End While
            End If
            dr1.close()
            GetDocDtlsByDocCd = objArr
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetDocDtlsByDocCd
    End Function

    Shared Function SpSelDocMst014(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal Data As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[dbo].[SpSelDocMst014]" 'doc_mst
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
            oParam.ParamName = "pData"
            oParam.ParamValue = Data
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region



#Region "GET DOCTOR DETAILS FOR RADIOLOGY REPORT BY DOCTOR CODE" 'RasikV 20170613
    Shared Function GetDocInfoForRadioReport(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal DocCd As Integer) As clsDocInfoForRadioReport
        GetDocInfoForRadioReport = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelDocMst015(CoCd, Div, Loc, DocCd))
            Dim obj As clsDocInfoForRadioReport
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj = New clsDocInfoForRadioReport
                        obj.DocCd = IIf(IsDBNull(.Item("DocCd")), 0, .Item("DocCd"))
                        obj.DocDcd = IIf(IsDBNull(.Item("DocDcd")), Nothing, .Item("DocDcd"))
                        obj.Speciality = IIf(IsDBNull(.Item("Speciality")), Nothing, .Item("Speciality"))
                        obj.DocEducation = IIf(IsDBNull(.Item("DocEducation")), Nothing, .Item("DocEducation"))
                        obj.DocSignature = IIf(IsDBNull(.Item("DocSignature")), Nothing, .Item("DocSignature"))
                        obj.DocSignFileName = IIf(IsDBNull(.Item("DocSignFileName")), Nothing, .Item("DocSignFileName"))
                    End With
                    GetDocInfoForRadioReport = obj
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetDocInfoForRadioReport = Nothing
        End Try
        Return GetDocInfoForRadioReport
    End Function

    Shared Function SpSelDocMst015(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal DocCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[dbo].[SpSelDocMst015]" 'doc_mst, cd_dcd
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
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region

#Region "GET DOCTOR  DETAILS BY PASSING DOCTOR CODE FOR ACKNOWLEDGE OP DOCTOR VISIT" 'RasikV 20180113
    Shared Function GetDocDtlsByDocCdUsrId(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal DocCd As Integer, ByVal UserId As String) As clsDoctorHelp
        GetDocDtlsByDocCdUsrId = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelDocMst016(CoCd, Div, Loc, DocCd, UserId))
            Dim obj As clsDoctorHelp
            If dr1.hasrows Then
                obj = New clsDoctorHelp
                dr1.Read()
                With dr1
                    obj.Code = IIf(IsDBNull(.Item("DocCd")), 0, .Item("DocCd"))
                    obj.Decode = IIf(IsDBNull(.Item("DocDcd")), Nothing, .Item("DocDcd"))
                    obj.SpecialityCd = IIf(IsDBNull(.Item("SpecialityCd")), 0, .Item("SpecialityCd"))
                    obj.Speciality = IIf(IsDBNull(.Item("SpecialityDcd")), Nothing, .Item("SpecialityDcd"))
                End With
            End If
            dr1.close()
            GetDocDtlsByDocCdUsrId = obj
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetDocDtlsByDocCdUsrId
    End Function

    Shared Function SpSelDocMst016(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal DocCd As Integer, ByVal UserId As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[dbo].[SpSelDocMst016]" 'S_UsrDoc, doc_mst, cd_dcd
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
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region


#Region "Doctor Help List(With Active Doctor) Assigned to user"
    ''' <summary>
    ''' Gets list of all doctors
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetDoctorListByUser(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer,
                                                      ByVal userid As String
                                                     ) As List(Of clsDoctor)
        GetDoctorListByUser = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST017(companycode, div, loc, userid))
            Dim objDoctorlist As List(Of clsDoctor) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of clsDoctor)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As New clsDoctor
                    'objDoctor.CompanyCode = companycode
                    'objDoctor.DivisionCode = div
                    'objDoctor.LocationCode = loc
                    objDoctor.DoctorCode = ds.Tables(0).Rows(i).Item("DoctorCode")
                    objDoctor.DoctorFirstName = ds.Tables(0).Rows(i).Item("DoctorFirstName")
                    objDoctor.DoctorMiddleName = ds.Tables(0).Rows(i).Item("DoctorMiddleName")
                    objDoctor.DoctorLastName = ds.Tables(0).Rows(i).Item("DoctorLastName")
                    objDoctor.DoctorFullName = ds.Tables(0).Rows(i).Item("DoctorFullName")
                    objDoctor.DoctorTitleCode = ds.Tables(0).Rows(i).Item("DoctorTitleCode")
                    objDoctor.DoctorTitleCodeDesc = ds.Tables(0).Rows(i).Item("DoctorTitleCodeDesc")
                    objDoctor.Status = ds.Tables(0).Rows(i).Item("Status")
                    objDoctor.SpecialityCode = ds.Tables(0).Rows(i).Item("SpecialityCode")
                    objDoctor.SpecialityCodeDesc = ds.Tables(0).Rows(i).Item("SpecialityCodeDesc")

                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            GetDoctorListByUser = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            GetDoctorListByUser = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    ''' <summary>
    ''' adds paramters to store procedure SPSELDOCMST
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELDOCMST017(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal userid As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST017]"

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
            oParam.ParamValue = userid
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function
#End Region



#Region " Selects doctor details [cd/decode] for given cd according to user"   'Pushpa 20180510
    Shared Function GetDocNameByCdByUser(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, _
           ByVal loc As Integer, ByVal DoctorCode As Integer, ByVal UserId As String) As String
        GetDocNameByCdByUser = Nothing
        Dim ofactory As New DBFactory
        'Dim objDoctor As clsDoctorHelp = Nothing
        Try
            Dim ds As DataSet = ofactory.ExecuteDataSet(SpSelDocMst018(cocd, div, loc, DoctorCode, UserId))
            If ds.Tables(0).Rows.Count <> 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    GetDocNameByCdByUser = ds.Tables(0).Rows(0).Item("ttl_Dcd") + " " + ds.Tables(0).Rows(0).Item("doc_lst_nm") + " " + ds.Tables(0).Rows(0).Item("doc_mid_nm") + " " + ds.Tables(0).Rows(0).Item("doc_frst_nm")
                Next
            End If
            ds.Dispose()


        Catch ex As Exception
            GetDocNameByCdByUser = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            ofactory = Nothing
        End Try
        Return GetDocNameByCdByUser

    End Function
#End Region

    ''' <summary>
    ''' sp to get details of doctor by passing doctor code assingnd to user
    ''' </summary>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="doctorcode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SpSelDocMst018(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal doctorcode As Integer, ByVal UserId As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST018]" 'doc_mst  
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivcd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLocCd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDoccd"
            oParam.ParamValue = doctorcode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function


#Region "select ALL Doctor Using DoctorName Prefix"         ''Aarti 30 Aug 2018

    Shared Function GetDocNmByPrefix(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer, ByVal Prefix As String
                                                     ) As List(Of String)
        GetDocNmByPrefix = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELDOCMST019(companycode, div, loc, Prefix))
            Dim objDoctorlist As List(Of String) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objDoctorlist = New List(Of String)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objDoctor As String = ""
                    objDoctor = ds.Tables(0).Rows(i).Item("DocName")
                    objDoctorlist.Add(objDoctor)
                Next
            End If
            ds.Dispose()
            GetDocNmByPrefix = objDoctorlist
            ofactory = Nothing
        Catch ex As Exception
            GetDocNmByPrefix = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SPSELDOCMST019(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal Prefix As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELDOCMST019]"

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivcd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLocCd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "Prefix"
            oParam.ParamValue = Prefix
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function
#End Region
End Class
Public Class clsDoctorDetails
    Inherits clsDoctor
    <DataMember()>
    Public Property RecLock As Integer
    <DataMember()>
    Public Property OldDocCd As Integer
    <DataMember()>
    Public Property DocRgs As String
    <DataMember()>
    Public Property DocAbrvNm As String
    <DataMember()>
    Public Property DocEducation As String
    <DataMember()>
    Public Property DocTypCd As Integer
    <DataMember()>
    Public Property SchTypCd As Integer
    <DataMember()>
    Public Property DocResAdd1 As String
    <DataMember()>
    Public Property DocResAdd2 As String
    <DataMember()>
    Public Property DocResAdd3 As String
    <DataMember()>
    Public Property DocResCity As String
    <DataMember()>
    Public Property DocResCntry As String
    <DataMember()>
    Public Property DocResPin As String
    <DataMember()>
    Public Property DocResTel As String
    <DataMember()>
    Public Property DocClncAdd1 As String
    <DataMember()>
    Public Property DocClncAdd2 As String
    <DataMember()>
    Public Property DocClncAdd3 As String
    <DataMember()>
    Public Property DocClncCity As String
    <DataMember()>
    Public Property DocClncCntry As String
    <DataMember()>
    Public Property DocClncPin As String
    <DataMember()>
    Public Property DocClncTel As String
    <DataMember()>
    Public Property TiFlg As String
    <DataMember()>
    Public Property PerAcFlg As String
    <DataMember()>
    Public Property DocDdnCd As Integer
    <DataMember()>
    Public Property MinDdn As Double
    <DataMember()>
    Public Property BankAc As String
    <DataMember()>
    Public Property Tds As Double
    <DataMember()>
    Public Property MaxDdn As Double
    <DataMember()>
    Public Property LstInvDt As Date
    <DataMember()>
    Public Property LstPmntDt As Date
    <DataMember()>
    Public Property LstBlPstDt As Date
    <DataMember()>
    Public Property UserDtTm As Date
    <DataMember()>
    Public Property UserId As String
    <DataMember()>
    Public Property UpdtTrnCd As String
    <DataMember()>
    Public Property No As Integer
    <DataMember()>
    Public Property Email As String
    <DataMember()>
    Public Property MobileNo As String
    <DataMember()>
    Public Property GenOpdTmFr As String
    <DataMember()>
    Public Property GenOpdTmTo As String
    <DataMember()>
    Public Property PvtOpdTmFr As String
    <DataMember()>
    Public Property PvtOpdTmTo As String
    <DataMember()>
    Public Property panno As String
    <DataMember()>
    Public Property DocBnkCd As Integer
    <DataMember()>
    Public Property DocBranch As String
    <DataMember()>
    Public Property DocIfscCd As String
    <DataMember()>
    Public Property DocDeptCd As Integer
    <DataMember()>
    Public Property Gender As Char
    <DataMember()>
    Public Property Dob As Date
    <DataMember()>
    Public Property DoctorStatus As Integer 'anamika  20140922
    <DataMember()>
    Public Property IsTdsVoluntary As Boolean 'Pramila 20161105
End Class


<DataContract()>
Public Class clsDoctorHelp   'RasikV 20161019
    <DataMember()>
    Public Property Code() As Integer
    <DataMember()>
    Public Property Decode() As String
    <DataMember()>
    Public Property SpecialityCd() As Integer
    <DataMember()>
    Public Property Speciality() As String

End Class

#Region "CLASS : clsOtDocDtls"
'PRAGYA : 14-OCT-2016
Public Class clsOtDocDtls
    <DataMember()>
    Public Property DoctorCode() As Integer
    <DataMember()>
    Public Property DoctorFullName() As String
    <DataMember()>
    Public Property SpecialityCode() As Integer
    <DataMember()>
    Public Property SpecialityCodeDesc() As String
    <DataMember()>
    Public Property AnesthesiaCd() As Integer
    <DataMember()>
    Public Property AnesthesiaDesc() As String
    <DataMember()>
    Public Property NurseName() As String
    <DataMember()>
    Public Property SurgnTypCd() As Integer
    <DataMember()>
    Public Property SurgnTypDcd() As String


    <DataMember()>
    Public Property AnesthesiaTypCd() As Integer
End Class
#End Region


<DataContract()>
Public Class clsDoctorNm  'RasikV 20170602
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
End Class

<DataContract()>
Public Class clsDocInfoForRadioReport  'RasikV 20170613
    <DataMember()>
    Public Property DocCd As Integer
    <DataMember()>
    Public Property DocDcd As String
    <DataMember()>
    Public Property DocEducation As String
    <DataMember()>
    Public Property Speciality As String
    <DataMember()>
    Public Property DocSignature As Byte()
    <DataMember()>
    Public Property DocSignFileName As String
End Class




Public Class ClsDoctorHolidayDtls '#.SACHIN 20190327
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
    Public Property SpecialityCode() As Integer
    <DataMember()>
    Public Property SpecialityCodeDesc() As String


    <DataMember()>
    Public Property HolidayDate As Date

    <DataMember()>
    Public Property HolidayRemarks As String



End Class