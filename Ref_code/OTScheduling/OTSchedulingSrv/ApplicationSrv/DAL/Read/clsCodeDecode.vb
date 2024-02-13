Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient

<DataContract()>
Public Class clsConcessionSetup 'aparna 20161010
    <DataMember()>
    Public Property IsEnabled As Boolean = True
    <DataMember()>
    Public Property ConcTyp As Char = "B"
End Class
<DataContract()>
Public Class clsCodeDecode
    <DataMember()>
    Public Property Decode() As String
    <DataMember()>
    Public Property Code() As Integer
    <DataMember()>
    Public Property Type() As Integer
    <DataMember()>
    Public Property addinfo1() As String

#Region "TypeCode=7011"

    ''' <summary>
    ''' Get CRADLE LIST
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks>aparna 9 aug 2016</remarks>
    Public Function CradleDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            CradleDetails = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 7011)
            CradleDetails = objarrCodeDecode
        Catch ex As Exception
            CradleDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function


#End Region

#Region "TypeCode=2"
    'anamika 20131115
    ''' <summary>
    ''' Get Visit with TypeCode= 2
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WardDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            WardDetails = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 2)
            WardDetails = objarrCodeDecode
        Catch ex As Exception
            WardDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function


    'end 20131115
#End Region

#Region "TypeCode=3"
    'anamika 20140818
    ''' <summary>
    '''  TypeCode= 3
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Salutation(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            Salutation = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, cocd, pdiv, ploc, 3)
            Salutation = objarrCodeDecode
        Catch ex As Exception
            Salutation = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function


    'end 20131115
#End Region



#Region "TypeCode=7"
    'anamika 20140818
    ''' <summary>
    '''  TypeCode= 7
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Education(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            Education = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, cocd, pdiv, ploc, 7)
            Education = objarrCodeDecode
        Catch ex As Exception
            Education = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function


    'end 20131115
#End Region


#Region "TypeCode=10"
    'anamika 20140818
    ''' <summary>
    '''  TypeCode= 10
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Religion(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)
        Try
            Religion = Nothing
            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, cocd, pdiv, ploc, 10)
            Religion = objarrCodeDecode
        Catch ex As Exception
            Religion = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function



#End Region

#Region "TypeCode=11"
    'anamika 20140818
    ''' <summary>
    '''  TypeCode= 11
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Nationality(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            Nationality = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, cocd, pdiv, ploc, 11)
            Nationality = objarrCodeDecode
        Catch ex As Exception
            Nationality = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function


    'end 20131115
#End Region

#Region "TypeCode=12"
    'anamika 20140818
    ''' <summary>
    '''  TypeCode= 12
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BloodGrp(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            BloodGrp = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, cocd, pdiv, ploc, 12)
            BloodGrp = objarrCodeDecode
        Catch ex As Exception
            BloodGrp = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function



#End Region

#Region "TypeCode=13"
    'mayur 20140111


    ''' <summary>
    '''  TypeCode= 13
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PatientSource(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            PatientSource = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 13)
            PatientSource = objarrCodeDecode
        Catch ex As Exception
            PatientSource = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

#End Region

#Region "TypeCode=14"
    ''' <summary>
    '''  TypeCode= 14
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CountryDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            CountryDetails = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 14)
            CountryDetails = objarrCodeDecode
        Catch ex As Exception
            CountryDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

#End Region

#Region "TypeCode=15"
    'anamika 20140818
    ''' <summary>
    '''  TypeCode= 15
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Height(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            Height = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, cocd, pdiv, ploc, 15)
            Height = objarrCodeDecode
        Catch ex As Exception
            Height = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function


    'end 20131115
#End Region

#Region "TypeCode=16"
    'anamika 20140818
    ''' <summary>
    '''  TypeCode= 16
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Width(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            Width = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, cocd, pdiv, ploc, 16)
            Width = objarrCodeDecode
        Catch ex As Exception
            Width = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function



#End Region

#Region "TypeCode=18"
    ''' <summary>
    ''' Get Visit with TypeCode= 18 ( Speciality Code Details)
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SpecialityCodeDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            SpecialityCodeDetails = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 18)
            SpecialityCodeDetails = objarrCodeDecode
        Catch ex As Exception
            SpecialityCodeDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
    'end 20140111

#End Region

#Region "typecode=19"

    ''' <summary>
    ''' discharge type with TypeCode= 19
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DischargeType(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)
        Try
            DischargeType = Nothing
            Dim objarr As List(Of clsCodeDecode)
            objarr = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 19)
            DischargeType = objarr
        Catch ex As Exception
            DischargeType = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return DischargeType
    End Function
    '20130819

#End Region

#Region "TypeCode=23"
    ''' <summary>
    ''' Get Visit with TypeCode= 23
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DoctorVisitTyp(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            DoctorVisitTyp = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 23)
            DoctorVisitTyp = objarrCodeDecode
        Catch ex As Exception
            DoctorVisitTyp = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
    '20130830
#End Region

#Region "TypeCode= 28"
    ''' <summary>
    '''TypeCode= 28
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DoctorSpeciality(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)
        Try
            DoctorSpeciality = Nothing
            Dim objarr As List(Of clsCodeDecode)
            objarr = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 28)
            DoctorSpeciality = objarr
        Catch ex As Exception
            DoctorSpeciality = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return DoctorSpeciality
    End Function
    'anamika 20130819
#End Region

#Region "TypeCode=31"
    'Neha S.C. 20140311
    ''' <summary>
    ''' Item type =31
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetItemTypes(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            GetItemTypes = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 31)
            GetItemTypes = objarrCodeDecode
        Catch ex As Exception
            GetItemTypes = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
    'from neha
#End Region

#Region "TypeCode=61"
    ''' <summary>
    ''' Item Groups = 61
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetItemGroups(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            GetItemGroups = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 61)
            GetItemGroups = objarrCodeDecode
        Catch ex As Exception
            GetItemGroups = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
    'End of code Neha S.C. 20140311

#End Region

#Region "TypeCode=71"
    'mayur 20140806
    ''' <summary>
    ''' Get purchase type with TypeCode= 71
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetpurchaseType(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            GetpurchaseType = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 71)
            GetpurchaseType = objarrCodeDecode
        Catch ex As Exception
            GetpurchaseType = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    'end code 20140806


#End Region


#Region "TypeCode=99"
    'anamika 20140818
    ''' <summary>
    '''  TypeCode= 99
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TypeOfInjury(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            TypeOfInjury = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, cocd, pdiv, ploc, 99)
            TypeOfInjury = objarrCodeDecode
        Catch ex As Exception
            TypeOfInjury = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
#End Region
#Region "TypeCode=100"
    ''' <summary>
    '''  TypeCode= 100
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CityDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            CityDetails = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 100)
            CityDetails = objarrCodeDecode
        Catch ex As Exception
            CityDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

#End Region

#Region "TypeCode=101"
    '''anamika 20140114
    ''' <summary>
    '''  TypeCode= 101
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StateDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            StateDetails = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 101)
            StateDetails = objarrCodeDecode
        Catch ex As Exception
            StateDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
    'anamika 20140114
#End Region

#Region "TypeCode=154"
    '''anamika 20140114
    ''' <summary>
    '''  TypeCode= 154
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PatientType(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            PatientType = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 154)
            PatientType = objarrCodeDecode
        Catch ex As Exception
            PatientType = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
    'anamika 20140114
#End Region

#Region "TypeCode=901"

    ' Neha S.C. 20140311
    ''' <summary>
    ''' Generic Names = 901
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetGenNames(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            GetGenNames = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 901)
            GetGenNames = objarrCodeDecode
        Catch ex As Exception
            GetGenNames = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
#End Region
#Region "TypeCode=907"
    'anamika 20140820
    ''' <summary>
    ''' Get Bank Details with TypeCode= 907
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AreaCode(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            AreaCode = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 907)
            AreaCode = objarrCodeDecode
        Catch ex As Exception
            AreaCode = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
#End Region
#Region "TypeCode=908"
    'anamika 20130830 
    ''' <summary>
    ''' Get Bank Details with TypeCode= 908
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCodeDecodeBankList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            GetCodeDecodeBankList = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 908)
            GetCodeDecodeBankList = objarrCodeDecode
        Catch ex As Exception
            GetCodeDecodeBankList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
#End Region

#Region "TypeCode=5001"
    'mayur 20140811
    ''' <summary>
    '''Get other tax Details with TypeCode= 5001
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOtherTaxList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)
        Try
            GetOtherTaxList = Nothing
            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, 5001)
            GetOtherTaxList = objarrCodeDecode
        Catch ex As Exception
            GetOtherTaxList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    'end code 20140811
#End Region


#Region "Select  Data From Cd_Dcd by passing code and type  "
    'anamika 20140506
    ''' <summary>
    ''' Select  Data From Cd_Dcd by passing code and type  
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="typ"></param>
    ''' <param name="Cd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetCodeDeCodeDtlByTypByCd(ByRef strErrMsg As List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal cocd As String,
                                                   ByVal div As Integer,
                                                   ByVal loc As Integer, ByVal typ As Integer, ByVal Cd As Integer
                                                  ) As clsCodeDecode
        GetCodeDeCodeDtlByTypByCd = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCDDCD(cocd, div, loc, typ, Cd))
            Dim objCodeDecode As clsCodeDecode
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        objCodeDecode = New clsCodeDecode
                        '   objCodeDecode.Type = .Item("typ")
                        '  objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        GetCodeDeCodeDtlByTypByCd = objCodeDecode
                    End With
                End While
            End If
            dr1.close()


            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetCodeDeCodeDtlByTypByCd = Nothing
        End Try
        Return GetCodeDeCodeDtlByTypByCd
    End Function
    Shared Function SPSELCDDCD(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal Cd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCDDCD]" 'cd_dcd
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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCd"
            oParam.ParamValue = Cd
            .Parameters.Add(oParam)


        End With

        Return oRequest
    End Function

    'end code 20140506
#End Region
#Region "main function"

    ''' <summary>
    ''' Collection list of Code and Decode by passing type and add_info_1
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetCodeDeCodeList(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer, ByVal typ As Integer
                                                    ) As List(Of clsCodeDecode)
        GetCodeDeCodeList = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPCDDECDLIST(companycode, div, loc, typ))
            'declared array of class clscodedecode
            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Type = .Item("typ")
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")

                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            GetCodeDeCodeList = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    Shared Function SPCDDECDLIST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPCDDECDLIST]" ' cd_dcd

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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function

#End Region



#Region "Select  Data From Cd_Dcd  by passing code and type   and add_info_1    " 'anamika 20150128

    ''' <summary>
    ''' Select  Data From Cd_Dcd by passing code and type  
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="typ"></param>
    ''' <param name="Cd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetCdDcdDtlByTypByCdByAddInfo1(ByRef strErrMsg As List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal cocd As String,
                                                   ByVal div As Integer,
                                                   ByVal loc As Integer, ByVal typ As Integer, ByVal AddInfo1 As String
                                                  ) As clsCodeDecode
        GetCdDcdDtlByTypByCdByAddInfo1 = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelCdDcd002(cocd, div, loc, typ, AddInfo1))
            Dim objCodeDecode As clsCodeDecode
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        objCodeDecode = New clsCodeDecode
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        GetCdDcdDtlByTypByCdByAddInfo1 = objCodeDecode
                    End With
                End While
            End If
            dr1.close()


            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetCdDcdDtlByTypByCdByAddInfo1 = Nothing
        End Try
        Return GetCdDcdDtlByTypByCdByAddInfo1
    End Function
    Shared Function SpSelCdDcd002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal AddInfo1 As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelCdDcd002]" 'cd_dcd
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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pAddInfo1"
            oParam.ParamValue = AddInfo1
            .Parameters.Add(oParam)


        End With

        Return oRequest
    End Function


#End Region

#Region "select doctor fee source by doctor (20140915 -anamika)"
    ''' <summary>
    ''' select doctor fee source  
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="DocCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SelDoctorFeeSource(ByRef strErrMsg As List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal cocd As String,
                                                   ByVal div As Integer,
                                                   ByVal loc As Integer, ByVal DocCd As Integer
                                                  ) As List(Of clsCodeDecode)
        SelDoctorFeeSource = Nothing
        Dim arrCdDcd As New List(Of clsCodeDecode)
        Dim objCodeDecode As clsCodeDecode
        Dim ofactory As DBFactory
        Try
            ofactory = New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelCdDcd001(cocd, div, loc, EnumCodeDecode.DoctorFeeSource, DocCd))
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        objCodeDecode = New clsCodeDecode
                        objCodeDecode.Decode = .Item("dcd")
                        objCodeDecode.Code = .Item("cd")
                        arrCdDcd.Add(objCodeDecode)
                    End With
                End While
                SelDoctorFeeSource = arrCdDcd
            End If
            dr1.close()

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SelDoctorFeeSource = Nothing
        Finally
            arrCdDcd = Nothing
            objCodeDecode = Nothing
            ofactory = Nothing
        End Try
        Return SelDoctorFeeSource
    End Function
    Shared Function SpSelCdDcd001(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer,
                                  ByVal typ As Integer, ByVal DocCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelCdDcd001]" 'cd_dcd,srv_mst
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
            oParam.ParamName = "pTypCd"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "DocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region


#Region "select doctor attached fee source by doctor (20170116 -anamika)"
    ''' <summary>
    ''' select doctor fee source  
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="DocCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SelDoctorAtachedFeeSource(ByRef strErrMsg As List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal cocd As String,
                                                   ByVal div As Integer,
                                                   ByVal loc As Integer, ByVal DocCd As Integer
                                                  ) As List(Of clsCodeDecode)
        SelDoctorAtachedFeeSource = Nothing
        Dim arrCdDcd As New List(Of clsCodeDecode)
        Dim objCodeDecode As clsCodeDecode
        Dim ofactory As DBFactory
        Dim IsDoctorContractApplicable As Boolean = False
        Try

            Dim objRule As New clsRuleMaster
            objRule = clsRuleMaster.GetRuleMstDtls(strErrMsg, chrErrFlg, cocd, div, loc, 7004)
            If objRule IsNot Nothing Then
                If objRule.Data1 = "Y" Then
                    IsDoctorContractApplicable = True
                Else
                    IsDoctorContractApplicable = False
                End If
            End If


            ofactory = New DBFactory
            Dim dr1 As Object
            If IsDoctorContractApplicable = False Then
                dr1 = ofactory.ExecuteDataReader(SPSELCDDCD010(cocd, div, loc, EnumCodeDecode.DoctorFeeSource, DocCd))
            Else
                dr1 = ofactory.ExecuteDataReader(SPSELCDDCD012(cocd, div, loc, EnumCodeDecode.DoctorFeeSource, DocCd))
            End If

            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        objCodeDecode = New clsCodeDecode
                        objCodeDecode.Decode = .Item("dcd")
                        objCodeDecode.Code = .Item("cd")
                        arrCdDcd.Add(objCodeDecode)
                    End With
                End While
                SelDoctorAtachedFeeSource = arrCdDcd
            End If
            dr1.close()

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SelDoctorAtachedFeeSource = Nothing
        Finally
            arrCdDcd = Nothing
            objCodeDecode = Nothing
            ofactory = Nothing
        End Try
        Return SelDoctorAtachedFeeSource
    End Function
    Shared Function SPSELCDDCD010(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer,
                                  ByVal typ As Integer, ByVal DocCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCDDCD010]" 'cd_dcd,srv_mst
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
            oParam.ParamName = "pTypCd"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "DocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function


    Shared Function SPSELCDDCD012(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer,
                                  ByVal typ As Integer, ByVal DocCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCDDCD012]" 'cd_dcd,srv_mst
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
            oParam.ParamName = "pTypCd"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "DocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region

#Region "Select  city desc,state cd ,state desc, cntry cd,cntry desc by passing patno and city cd"
    ''' <summary>
    ''' Select  city desc,state cd ,state desc, cntry cd,cntry desc by passing patno and city cd
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="Patno"></param>
    ''' <param name="CityCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SpSelCityStateCntry(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal Patno As Long, ByVal CityCd As String) As DBRequest 'anamika 20160906
        'Shared Function SpSelCityStateCntry(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal Patno As Integer, ByVal CityCd As String) As DBRequest 
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelCityStateCntry]"

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
            oParam.ParamName = "pPatno"
            oParam.ParamValue = Patno
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCityCd"
            oParam.ParamValue = CityCd
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function
    Public Function GetCntryStateByPatno(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                     ByVal Patno As Long, ByVal CityCd As String) As clsCityStateCntry
        GetCntryStateByPatno = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelCityStateCntry(companycode, div, loc, Patno, CityCd.Trim))
            Dim obj As clsCityStateCntry = Nothing
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj = New clsCityStateCntry
                        obj.CityCd = IIf(IsDBNull(.Item("citycd")), 0, .Item("citycd"))
                        obj.Citydesc = IIf(IsDBNull(.Item("cityname")), "", .Item("cityname"))
                        obj.StateCd = IIf(IsDBNull(.Item("statecd")), 0, .Item("statecd"))
                        obj.StateDesc = IIf(IsDBNull(.Item("statename")), "", .Item("statename"))
                        obj.CntryCd = IIf(IsDBNull(.Item("cntrycd")), 0, .Item("cntrycd"))
                        obj.CntryDesc = IIf(IsDBNull(.Item("cntryname")), "", .Item("cntryname"))
                    End With
                End While
            End If
            dr1.close()
            GetCntryStateByPatno = obj
            Return GetCntryStateByPatno
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
#End Region


#Region "To get Code and addinfo details of ledger based on ledger type"

    ''' <summary>
    '''  To get Code and addinfo details of ledger based on ledger type
    ''' aparna 15 jul 2015
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetLedgerDetails(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer, ByVal type As Integer
                                                    ) As List(Of clsCodeDecodeLedger)
        GetLedgerDetails = Nothing
        Try
            Dim ofactory As New DBFactory

            'Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELADDINFODCD(companycode, div, loc, type))
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCDDCD006(companycode, div, loc, type)) 'renamed sp SpSelCdDcd with SPSELCDDCD006
            'declared array of class clscodedecode
            Dim objCdAddinfolist As List(Of clsCodeDecodeLedger) = Nothing
            If dr1.hasrows Then
                objCdAddinfolist = New List(Of clsCodeDecodeLedger)
                While dr1.Read()
                    With dr1
                        Dim objAddinfoDecode As New clsCodeDecodeLedger
                        objAddinfoDecode.addinfo1 = .Item("add_info_1")
                        objAddinfoDecode.Decode = .Item("dcd")

                        objCdAddinfolist.Add(objAddinfoDecode)
                    End With
                End While
            End If
            dr1.close()
            GetLedgerDetails = objCdAddinfolist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    Shared Function SPSELCDDCD006(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal type As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            '  .Command = "[SpSelCdDcd]" SPSELCDDCD005
            .Command = "[SPSELCDDCD006]"
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
            oParam.ParamName = "pType"
            oParam.ParamValue = type
            .Parameters.Add(oParam)


            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function
#End Region



#Region "Get Diet Prm Fd Choices"

    ''' <summary>
    ''' Get Diet Prm Fd Choices
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetDietParamFoodChoices(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer, ByVal DietPrmFood As String
                                                    ) As List(Of clsCodeDecode)
        GetDietParamFoodChoices = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelCdDcd003(companycode, div, loc, EnumCodeDecode.FOODCHOICES, DietPrmFood))
            'declared array of class clscodedecode
            Dim objCdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objAddinfoDecode As New clsCodeDecode
                        objAddinfoDecode.Code = .Item("cd")
                        objAddinfoDecode.Decode = .Item("dcd")

                        objCdlist.Add(objAddinfoDecode)
                    End With
                End While
            End If
            dr1.close()
            GetDietParamFoodChoices = objCdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    Shared Function SpSelCdDcd003(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal type As Integer, ByVal pDietPrmFood As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelCdDcd003]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pTyp"
            oParam.ParamValue = type
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDietPrmFood"
            oParam.ParamValue = pDietPrmFood
            .Parameters.Add(oParam)




        End With

        Return oRequest
    End Function
#End Region


#Region "TO GET CD_DCD LIST WITH ORDER BY ADD_INFO_1 DESC "

    ''' <summary>
    ''' Get list of CD_DCD with order by ADD_INFO_1 DESC
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="typ"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetCodeDeCodeListAddInfo1(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer, ByVal typ As Integer
                                                   ) As List(Of clsCodeDecode)
        GetCodeDeCodeListAddInfo1 = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelCdDcd004(companycode, div, loc, typ))

            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")

                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            GetCodeDeCodeListAddInfo1 = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function


    Shared Function SpSelCdDcd004(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelCdDcd004]"

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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function
#End Region


#Region "TO GET PATIENT GENDER LIST"

    ''' <summary>
    ''' TO GET PATIENT GENDER LIST
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns>APARNA 22 JAN 2016</returns>
    ''' <remarks></remarks>
    Shared Function GetCodeDeCodeListForPtnGender(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer, ByVal typ As Integer, ByVal IsBothTrue As Boolean
                                                    ) As List(Of clsCodeDecode)
        GetCodeDeCodeListForPtnGender = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCDDCD005(companycode, div, loc, typ, IsBothTrue))
            'declared array of class clscodedecode
            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCodeDecode.Type = .Item("typ")   'RasikV 20160929
                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            GetCodeDeCodeListForPtnGender = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    Shared Function SPSELCDDCD005(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal IsBothTrue As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCDDCD005]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "IsBoth"
            oParam.ParamValue = IsBothTrue
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function

#End Region

#Region "Selects all  records from code decode against code and decode"
    Shared Function SPCDDECDLIST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal Decode As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPCDDECDLIST001]"

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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDecode"
            oParam.ParamValue = Decode
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function
    ''' <summary>
    ''' Selects all  records from code decode against code and decode
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetCodeDeCodeListByTypAndDecode(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer, ByVal typ As Integer, ByVal Decode As String
                                                    ) As List(Of clsCodeDecode)
        GetCodeDeCodeListByTypAndDecode = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPCDDECDLIST001(companycode, div, loc, typ, Decode))
            'declared array of class clscodedecode
            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            GetCodeDeCodeListByTypAndDecode = objCdDecdlist
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
#End Region






#Region "Monthly Input Type for PMS(anamika 20160331)"

    ''' <summary>
    '''Monthly Input Type for PMS
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns>APARNA 22 JAN 2016</returns>
    ''' <remarks></remarks>
    Shared Function PMSMonthlyInputType(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer, ByVal typ As EnumCodeDecode
                                                    ) As List(Of clsCodeDecode)
        PMSMonthlyInputType = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCDDCD007(companycode, div, loc, typ))
            'declared array of class clscodedecode
            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            PMSMonthlyInputType = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    Shared Function SPSELCDDCD007(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCDDCD007]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function

#End Region


#Region "Order by code"



    Shared Function SPSELCDDCD008(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCDDCD008]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function
#End Region
#Region "cd_dcd & ip_ins_typcd join "
    ''' <summary>
    ''' cd_dcd & ip_ins_typcd join 
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    ''' <remarks>anamika  21 may 2016</remarks>
    Shared Function InsuranceCodeDcdListById(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer, ByVal Id As Integer
                                                    ) As List(Of clsCodeDecode)
        InsuranceCodeDcdListById = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCDDCD009(companycode, div, loc, Id))
            'declared array of class clscodedecode
            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            InsuranceCodeDcdListById = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    Shared Function SPSELCDDCD009(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal Id As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCDDCD009]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIVcd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOCcd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pid"
            oParam.ParamValue = Id
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function

#End Region



#Region "cd_dcd & ip_ins_typcd join  for getting desc by cd and typ"
    Shared Function GetDescByIdcd(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer, ByVal Id As Integer, ByVal cd As Integer
                                                   ) As clsCodeDecode
        GetDescByIdcd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim objCodeDecode As New clsCodeDecode

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCDDCD0010(companycode, div, loc, Id, cd))

            If dr1.hasrows Then

                While dr1.Read()
                    With dr1
                        objCodeDecode.Decode = .Item("dcd")
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        objCodeDecode.Type = .Item("typ")

                    End With
                End While
            End If
            dr1.close()
            GetDescByIdcd = objCodeDecode

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    Shared Function SPSELCDDCD0010(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal Id As Integer, ByVal cd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCDDCD0010]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pid"
            oParam.ParamValue = Id
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pcd"
            oParam.ParamValue = cd
            .Parameters.Add(oParam)


        End With

        Return oRequest
    End Function
#End Region


#Region "GetCdDcdLstWithModCdSubModCd : EXCLUSIVELY USED FOR SCANNING"

    ''' <summary>
    ''' GetCdDcdLstWithModCdSubModCd TIS FUNCTION WILL GET CHANGED ACCORDING TO NEW TABLE FOR SCANNING
    ''' FOR NOW TAKE DATA FROM CD_DCD TABLE
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="typ"></param>
    ''' <param name="ModCd"></param>
    ''' <param name="SubModCd"></param>
    ''' <returns></returns>
    ''' <remarks>PRAGYA : 03-AUG-2016</remarks>

    Shared Function GetScannedDocLstWithModCdSubModCd(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer,
                                                    ByVal ModCd As Integer,
                                                    ByVal SubModCd As Integer,
                                                    ByVal typ As Integer
                                                   ) As List(Of clsCodeDecode)
        GetScannedDocLstWithModCdSubModCd = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPCDDECDLISTNew(companycode, div, loc, typ, ModCd, SubModCd))
            'declared array of class clscodedecode
            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Type = .Item("typ")
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")

                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            GetScannedDocLstWithModCdSubModCd = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetScannedDocLstWithModCdSubModCd
    End Function


    Shared Function SPCDDECDLISTNew(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal ModCd As Integer,
                                                    ByVal SubModCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPCDDECDLIST]" ' cd_dcd

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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function


#End Region

#Region "GET REJECTION REASON TYPE LIST"
    ''' <summary>
    ''' GET REJECTION REASON TYPE LIST
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks>APARNA 13 OCT 2016</remarks>
    Public Shared Function GetRejectionReasonTyp(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As System.Collections.Generic.List(Of clsCodeDecode)

        Try
            GetRejectionReasonTyp = Nothing

            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeList(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, EnumCodeDecode.RejectionReasonType)
            GetRejectionReasonTyp = objarrCodeDecode
        Catch ex As Exception
            GetRejectionReasonTyp = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
#End Region




#Region "getAllDetailsCdDcd : get all data from code decode by passing typ"
    'alpesh : 20170127
    Shared Function getAllDetailsCdDcd(ByRef strErrMsg As List(Of String),
                                ByRef chrErrFlg As Char,
                                ByVal companycode As String,
                                ByVal div As Integer,
                                ByVal loc As Integer,
                                ByVal typ As Integer
                                ) As List(Of clsCodeDecodeDetails)
        getAllDetailsCdDcd = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(spSelCdDcd013(companycode, div, loc, typ))

            Dim objclsCdDcdList As List(Of clsCodeDecodeDetails) = Nothing
            If dr1.hasrows Then
                objclsCdDcdList = New List(Of clsCodeDecodeDetails)
                While dr1.Read()
                    With dr1
                        Dim objclsCdDcd As New clsCodeDecodeDetails
                        objclsCdDcd.chk = False
                        objclsCdDcd.Type = .Item("typ")
                        objclsCdDcd.Code = .Item("cd")
                        objclsCdDcd.Decode = .Item("dcd")
                        objclsCdDcd.addinfo1 = .Item("add_info_1")
                        objclsCdDcd.SysOrUser = .Item("SysOrUser")
                        objclsCdDcdList.Add(objclsCdDcd)
                    End With
                End While
            End If
            dr1.close()
            getAllDetailsCdDcd = objclsCdDcdList

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function


    Shared Function spSelCdDcd013(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[spSelCdDcd013]"

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
            oParam.ParamName = "pTyp"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure
        End With

        Return oRequest
    End Function
#End Region



#Region "Get Code and Decode from cd_dcd master where add_info_1(1,3) and typ "
    'Added by Farid 11/02/2017

    ''' <summary>
    ''' Get Code and Decode from cd_dcd master where add_info_1(1,3) and typ
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="typ"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetCodeDeCodeListAddByParaInfo1(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer, ByVal typ As Integer, ByVal padd_info_1 As String
                                                   ) As List(Of clsCodeDecode)
        GetCodeDeCodeListAddByParaInfo1 = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelCdDcd0015(companycode, div, loc, typ, padd_info_1))

            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCodeDecode.Type = .Item("typ") 'farid 20170223
                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            GetCodeDeCodeListAddByParaInfo1 = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function


    Shared Function SpSelCdDcd0015(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal padd_info_1 As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelCdDcd0015]"

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
            oParam.ParamName = "pTyp"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "padd_info_1"
            oParam.ParamValue = padd_info_1
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function
#End Region




#Region "InsCdDcdLstByTypId : cd_dcd & ip_ins_typcd join : new clas - clsCdDcdWithBol "
    'pragya : 11-mar-2017
    Shared Function InsCdDcdLstByTypId(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer,
                                                     ByVal Id As Integer
                                                    ) As List(Of clsCdDcdWithBol)
        InsCdDcdLstByTypId = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCDDCD009(companycode, div, loc, Id))
            Dim objCdDecdlist As List(Of clsCdDcdWithBol) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCdDcdWithBol)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCdDcdWithBol
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            InsCdDcdLstByTypId = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

#End Region



#Region "SELECT DATA FROM CD_DCD BY PASSING CODE, TYPE AND ADD_INFO_1" 'RasikV 20170303

    Shared Function GetCdDcdDtlByTypCdAddInfo1(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal Typ As Integer, ByVal AddInfo1 As String, ByVal Cd As Integer) As clsCodeDecodeLedger
        GetCdDcdDtlByTypCdAddInfo1 = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelCdDcd016(CoCd, Div, Loc, Typ, AddInfo1, Cd))
            Dim obj As clsCodeDecodeLedger
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj = New clsCodeDecodeLedger
                        obj.Decode = IIf(IsDBNull(.Item("Dcd")), Nothing, .Item("Dcd"))
                        obj.addinfo1 = IIf(IsDBNull(.Item("AddInfo1")), Nothing, .Item("AddInfo1"))
                    End With
                    GetCdDcdDtlByTypCdAddInfo1 = obj
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetCdDcdDtlByTypCdAddInfo1 = Nothing
        End Try
        Return GetCdDcdDtlByTypCdAddInfo1
    End Function

    Shared Function SpSelCdDcd016(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal Typ As Integer, ByVal AddInfo1 As String, ByVal Cd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[dbo].[SpSelCdDcd016]" 'cd_dcd
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
            oParam.ParamName = "pTyp"
            oParam.ParamValue = Typ
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pAddInfo1"
            oParam.ParamValue = AddInfo1
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCd"
            oParam.ParamValue = Cd
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function
#End Region


#Region "Select  Data From Cd_Dcd by passing code and type  "

    ''' <summary>
    ''' Select  Data From Cd_Dcd by passing code and type  
    ''' aparna 26 may 2017
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="typ"></param>
    ''' <param name="Cd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetCodeDeCodeListByTypByCd(ByRef strErrMsg As List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal cocd As String,
                                                   ByVal div As Integer,
                                                   ByVal loc As Integer, ByVal typ As Integer, ByVal Addinfo As String
                                                  ) As List(Of clsCodeDecode)
        GetCodeDeCodeListByTypByCd = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCDDCD017(cocd, div, loc, typ, Addinfo))
            Dim objCodeDecode As clsCodeDecode
            Dim objCodeDecodelist As New List(Of clsCodeDecode)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        objCodeDecode = New clsCodeDecode
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")

                        objCodeDecodelist.Add(objCodeDecode)
                    End With

                    GetCodeDeCodeListByTypByCd = objCodeDecodelist
                End While


            End If
            dr1.close()


            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetCodeDeCodeListByTypByCd = Nothing
        End Try
        Return GetCodeDeCodeListByTypByCd
    End Function
    Shared Function SPSELCDDCD017(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal Addinfo As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCDDCD017]" 'cd_dcd
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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pAddinfo"
            oParam.ParamValue = Addinfo
            .Parameters.Add(oParam)


        End With

        Return oRequest
    End Function

    'end code 20140506
#End Region

#Region "TypeCode=8023"

    ''' <summary>
    '''Get CASE MANAGER LIST
    ''' APARNA 26 MAY 2017
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCaseManagerList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal typ As Integer, ByVal addinfo As String) As System.Collections.Generic.List(Of clsCodeDecode)
        Try
            GetCaseManagerList = Nothing
            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeListByTypByCd(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, typ, addinfo)
            GetCaseManagerList = objarrCodeDecode
        Catch ex As Exception
            GetCaseManagerList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

#End Region




#Region "TypeCode=8024"

    ''' <summary>
    '''Get CO-ORDINATOR LIST
    ''' APARNA 26 MAY 2017
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCoordinatorList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal typ As Integer, ByVal addinfo As String) As System.Collections.Generic.List(Of clsCodeDecode)
        Try
            GetCoordinatorList = Nothing
            Dim objarrCodeDecode As List(Of clsCodeDecode)
            objarrCodeDecode = clsCodeDecode.GetCodeDeCodeListByTypByCd(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, typ, addinfo)
            GetCoordinatorList = objarrCodeDecode
        Catch ex As Exception
            GetCoordinatorList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

#End Region



    Shared Function SelDoctorLinkedFeeSource(strErrMsg As List(Of String), chrErrFlg As Char, cocd As String, div As Integer, loc As Integer, DocCd As Integer) As List(Of clsCodeDecode)
        SelDoctorLinkedFeeSource = Nothing
        Dim arrCdDcd As New List(Of clsCodeDecode)
        Dim objCodeDecode As clsCodeDecode
        Dim ofactory As DBFactory
        Try
            ofactory = New DBFactory
            Dim dr3 As Object = ofactory.ExecuteDataReader(SPSELLINKEDFEESRCE(cocd, div, loc, DocCd))
            If dr3.hasrows Then
                While dr3.Read()
                    With dr3
                        objCodeDecode = New clsCodeDecode
                        objCodeDecode.Decode = .Item("dcd")
                        objCodeDecode.Code = .Item("cd")
                        arrCdDcd.Add(objCodeDecode)
                    End With
                End While
                SelDoctorLinkedFeeSource = arrCdDcd
            End If
            dr3.close()

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SelDoctorLinkedFeeSource = Nothing
        Finally
            arrCdDcd = Nothing
            objCodeDecode = Nothing
            ofactory = Nothing
        End Try
        Return SelDoctorLinkedFeeSource
    End Function

    Private Shared Function SPSELLINKEDFEESRCE(cocd As String, div As Integer, loc As Integer, DocCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "SPSELLINKEDFEESRCE" 'cd_dcd,srv_mst
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
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function



#Region "GetLstCdDcdDtlByTypAddInfo : get list frm cd_dcd by passing typ & addinfo"
    'pragya :  14-oct-2017
    Shared Function GetLstCdDcdDtlByTypAddInfo(ByRef strErrMsg As List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal cocd As String,
                                                   ByVal div As Integer,
                                                   ByVal loc As Integer,
                                                   ByVal typ As Integer,
                                                   ByVal AddInfo1 As String
                                                  ) As List(Of clsCodeDecode)
        GetLstCdDcdDtlByTypAddInfo = Nothing

        Dim ofactory As New DBFactory
        Dim dr1 As Object
        Try
            dr1 = ofactory.ExecuteDataReader(SpSelCdDcd002(cocd, div, loc, typ, AddInfo1))
            Dim objlist As New List(Of clsCodeDecode)
            If dr1.hasrows Then
                While dr1.read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        objlist.Add(objCodeDecode)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetLstCdDcdDtlByTypAddInfo = objlist
            ofactory = Nothing
        Catch ex As Exception
            GetLstCdDcdDtlByTypAddInfo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

        Return GetLstCdDcdDtlByTypAddInfo

    End Function
#End Region


#Region "Get Store Map COST CENTER GROUP "  '' Amol 19-02-2018

    Shared Function GetCostCenterGroupByStrCd(ByRef strErrMsg As List(Of String), _
                                                  ByRef chrErrFlg As Char, _
                                                  ByVal companycode As String, _
                                                  ByVal div As Integer, _
                                                  ByVal loc As Integer, ByVal typ As Integer, ByVal StrCd As Integer
                                                 ) As List(Of clsCodeDecode)
        GetCostCenterGroupByStrCd = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPCDDECDLIST001(companycode, div, loc, typ, StrCd))
            'declared array of class clscodedecode
            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Type = .Item("typ")
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")

                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            GetCostCenterGroupByStrCd = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function

    Shared Function SPCDDECDLIST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal StrCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPCDDECDLIST001]" ' cd_dcd

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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pStrCd"
            oParam.ParamValue = StrCd
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function


#End Region


    Shared Function GetDefaultCoutryStateCity(strErrMsg As List(Of String), chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer) As DefualtCountryStateCity   '' Amol 2018-06-13



        GetDefaultCoutryStateCity = Nothing
        Dim objCodeDecode As DefualtCountryStateCity
        Dim ofactory As DBFactory
        Try
            ofactory = New DBFactory
            Dim dr3 As Object = ofactory.ExecuteDataReader(SPSELGETDEFULTCOUNTRYSTATECITY(CoCd, Div, Loc))
            If dr3.hasrows Then
                While dr3.Read()
                    With dr3
                        objCodeDecode = New DefualtCountryStateCity
                        objCodeDecode.CountryCode = .Item("CountryCode")
                        objCodeDecode.StateCode = .Item("StateCode")
                        objCodeDecode.CityCode = .Item("CityCode")
                        GetDefaultCoutryStateCity = objCodeDecode
                    End With
                End While

            End If
            dr3.close()

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetDefaultCoutryStateCity = Nothing
        Finally

            objCodeDecode = Nothing
            ofactory = Nothing
        End Try
        Return GetDefaultCoutryStateCity


    End Function

    Private Shared Function SPSELGETDEFULTCOUNTRYSTATECITY(cocd As String, div As Integer, loc As Integer) As DBRequest    '' Amol 2018-06-13
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "SPSELGETDEFULTCOUNTRYSTATECITY"
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "@pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivCd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "@pLoccd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function



#Region "For Get Csttype User wise by Rushikesh 2 nov 2018"
    Shared Function GetCodeDeCodeListByUid(ByRef strErrMsg As List(Of String), _
                                                     ByRef chrErrFlg As Char, _
                                                     ByVal companycode As String, _
                                                     ByVal div As Integer, _
                                                     ByVal loc As Integer, ByVal typ As Integer, ByVal StrCd As Integer, ByVal Uid As String
                                                    ) As List(Of clsCodeDecode) 'Added store Code 14 nov 2018
        GetCodeDeCodeListByUid = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPCDDECDLIST002(companycode, div, loc, typ, StrCd, Uid))
            'declared array of class clscodedecode
            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Type = .Item("typ")
                        objCodeDecode.addinfo1 = .Item("add_info_1")
                        objCodeDecode.Code = .Item("cd")
                        objCodeDecode.Decode = .Item("dcd")
                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            GetCodeDeCodeListByUid = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
    Shared Function SPCDDECDLIST002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal typ As Integer, ByVal StrCd As Integer, ByVal Uid As String) As DBRequest 'added str cd 14 nov 2018
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPCDDECDLIST002]" ' cd_dcd

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
            oParam.ParamName = "pTYP"
            oParam.ParamValue = typ
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter 'Added Strcd 14 nov 2018
            oParam.ParamName = "pStrCd"
            oParam.ParamValue = StrCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserId"
            oParam.ParamValue = Uid
            .Parameters.Add(oParam)
            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function
#End Region

    ''Anand:20190214
    Shared Function GetCostCentTypLstRptTyp(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer
                                                    ) As List(Of clsCodeDecode)
        GetCostCentTypLstRptTyp = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPCostCentTypLstRptTyp(companycode, div, loc))
            'declared array of class clscodedecode
            Dim objCdDecdlist As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objCdDecdlist = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim objCodeDecode As New clsCodeDecode
                        objCodeDecode.Code = .Item("CstCntrTypCd")
                        objCodeDecode.Decode = .Item("CstCntrTypDcd")
                        objCdDecdlist.Add(objCodeDecode)
                    End With
                End While
            End If
            dr1.close()
            GetCostCentTypLstRptTyp = objCdDecdlist

            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function






    Shared Function SPCostCentTypLstRptTyp(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPCostCentTypLstRptTyp]" ' cd_dcd

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

End Class
<DataContract()>
Public Enum EnumCodeDecode
    <EnumMember()>
      Ward = 2
    <EnumMember()>
      TitleCd = 3
    <EnumMember()>
     Relation = 4
    <EnumMember()>
  MaritalStatus = 5
    <EnumMember()>
        Occupation = 6
    <EnumMember()>
       Education = 7
    <EnumMember()>
      Income = 8
    <EnumMember()>
     Community = 9
    <EnumMember()>
    Religion = 10
    <EnumMember()>
  Nationality = 11
    <EnumMember()>
 BloodGrp = 12
    <EnumMember()>
     PatientSource = 13
    <EnumMember()>
       Country = 14
    <EnumMember()>
      Height = 15
    <EnumMember()>
      Width = 16
    <EnumMember()>
     SpecialRequirement = 18 'anamika 20160912
    <EnumMember()>
     DischargeStatus = 19 'RasikV 20161019
    <EnumMember()>
   DeliveryStatus = 20  'aparna 10 aug 2016
    <EnumMember()>
     DoctorFeeSource = 23
    <EnumMember()>
    AuthDesignation = 24
    <EnumMember()>
      DoctorTypes = 26
    <EnumMember()>
     DoctorSpeciality = 28
    <EnumMember()>
   TaxTable = 30     'Pramila 31jan2017
    <EnumMember()>
    ItemType = 31     'anamika 20161014
    <EnumMember()>
    Departments = 33 'anamika 20160331
    <EnumMember()>
    COSTHEADS = 39 'alpesh 20161015
    <EnumMember()>
      BillingGrp = 40
    <EnumMember()>
    ServiceCategory = 46
    <EnumMember()>
    SurgeryCategory = 47
    <EnumMember()>
  OperationNames = 48 'RasikV 20170304
    <EnumMember()>
  Dosage = 55
    <EnumMember()>
   Route = 56
    <EnumMember()>
   Stock = 57
    <EnumMember()>
      CreditCoTyp = 60
    <EnumMember()>
    ItemGroup = 61
    <EnumMember()>
       PurAuth = 62
    <EnumMember()>
        ConcernType = 70
    <EnumMember()>
       PurchaseType = 71 'anamika 20171130 (used in purchase order)
    <EnumMember()>
      TermHeads = 75 'pramilla 20161021
    <EnumMember()>
       InjuryType = 99
    <EnumMember()>
        City = 100
    <EnumMember()>
      State = 101
    <EnumMember()>
     PatientTyp = 154
    <EnumMember()>
  Reorder = 155
    <EnumMember()>
 InsuranceCompanyName = 156 'anamika 20171129 (used in insurance)
    <EnumMember()>
 ApplicationStatus = 157 'anamika 20171129 (used in insurance)
    <EnumMember()>
    RhFactor = 303 'anamika 20170114
    <EnumMember()>
 FCTCategory = 401 'anamika 20171205  (Please use in resource master)
    <EnumMember()>
FCTMainCode = 402 'anamika 20171205  (Please use in resource master)
    <EnumMember()>
 RoomShape = 727
    <EnumMember()>
RoomType = 729
    <EnumMember()>
  CostCenterGroup = 805
    <EnumMember>
  PharmaSetting = 807           'farid : 20170210
    <EnumMember>
DocumentId = 808
    <EnumMember()>
  DoctorBankCodes = 905
    <EnumMember()>
     AreaCodes = 907
    <EnumMember()>
     CreditCardBanks = 908 'anamika 20160331 (not in use)
    <EnumMember()>
    MisChrg = 1007
    <EnumMember()>
FOODCHOICES = 1205 'anamika  20151005
    <EnumMember()>
DepositBreakTyp = 1510 'anamika  20171129 (used in insurance)
    <EnumMember()>
QueryType = 1511 'anamika  20171129 (used in insurance)
    <EnumMember()>
BillFwdDisc = 1513 'anamika  20171129 (used in insurance)
    <EnumMember()>
Gender = 1557 'aparna 02jul2015
    <EnumMember()>
PatientDocumentType = 1566      'PRAGYA : 25-JUL-2016
    <EnumMember()>
AnesthesiaTypes = 1606      'PRAGYA : 14-oct-2016
    <EnumMember()>
PurchaseOrderStatus = 1607      'aarti : 26-Dec-2016
    <EnumMember()>
CompTypes = 5002
    <EnumMember()>
CshDeptWing = 5003 'anamika 20150220
    <EnumMember()>
GLTypes = 5004 'aparna 23jun2015
    <EnumMember()>
AccTypes = 5005 'aparna 23jun2015
    <EnumMember()>
SubLedgerType = 5006 'aparna 02jul2015  
    '    <EnumMember()>
    'ReportParam = 5007 'mayur 20160129 (not in use)
    '    <EnumMember()>
    'PrintParam = 5008 'mayur 20160129 (not in use)
    <EnumMember()>
BlacklistReason = 5009 'pragya 20160719
    <EnumMember()>
  SmsCategoryType = 5010 'anamika 20160722
    <EnumMember()>
PatientReferralType = 5011 'PRAGYA : 20160723  '5010 'anamika 20160722
    <EnumMember()>
PatientStatus = 5012 'PRAGYA : 20160806
    <EnumMember()>
CradleTyp = 5013 'PRAGYA : 20160825
    <EnumMember()>
    AppointmentType = 5014  'aparna 7 sep 2016
    <EnumMember()>
 Resources = 5015 'aparna 7 sep 2016
    <EnumMember()>
  AppointmentCancellationType = 5016 'aparna 7 sep 2016
    <EnumMember()>
PatientCategory = 5017 'anamika 20161001
    <EnumMember()>
 CategoryConcessionType = 5018 'anamika 20161001
    <EnumMember>
AnswerSeriesPattern = 5019     'PRAGYA : 20160930
    <EnumMember>
RejectionReasonType = 5020 'aparna 13 oct 2016
    <EnumMember()>
    GLDocType = 5021  'RasikV 20161104
    <EnumMember()>
  DebitNoteType = 5022  'RasikV 20161104
    <EnumMember()>
  CreditNoteType = 5023  'RasikV 20161104
    <EnumMember()>
FOODCATEGORY = 5024 'Pramila 20161115
    <EnumMember()>
FOODUNITS = 5025 'Pramila 20161115
    <EnumMember()>
    MtrPriorityType = 5026 'Trupti 30 Nov 2016
    <EnumMember()>
PMSPayslipType = 7000 'anamika  20160323
    <EnumMember()>
PMSElementCategory = 7001 'anamika  20160323
    <EnumMember()>
PMSAttributes = 7002 'anamika 20160323
    <EnumMember()>
PMSSourceHow = 7003 'anamika 20160323
    <EnumMember()>
PMSElements = 7004 'anamika  20160323
    <EnumMember()>
PMSParameterTitles = 7005 'anamika 20160323
    <EnumMember()>
PMSHealthcareGroups = 7006 'anamika 20160323
    <EnumMember()>
PMSEmployeeCategory = 7007 'anamika 20160323
    <EnumMember()>
PMSDesignation = 7008 'anamika 20160323
    <EnumMember()>
PMSGrade = 7009 'anamika 20160323
    <EnumMember()>
PMSNameTitles = 7010 'anamika 20160323

    <EnumMember()>
            EqpFlg = 8012           'Aarti 25 Jan 2018
    <EnumMember()>
  CaseManager = 8023 'anamika  20171129  (Please use in admission)
    <EnumMember()>
  CaseCoordinator = 8024 'anamika  20171129 
    <EnumMember()>
    TaxCategory = 8025 'APARNA 29 MAY 2017
    <EnumMember()>
      SubCaseType = 8026 'APARNA 14 JUL 2017
    <EnumMember()>
 classification = 8027 'Pramila 17jul2017
    <EnumMember()>
ScanningDocuments = 8028 'Pragya : 14-oct-2017
    <EnumMember()>
CardType = 8029 'RasikV 20171121
    <EnumMember()>
    VisitType = 8031 'aparna 25 may 2018

    <EnumMember()>
    BookingType = 8109
    <EnumMember()>
    SurgeonType = 8113

End Enum

Public Class clsCityStateCntry
    <DataMember()>
    Public Property PatientNo As Integer
    <DataMember()>
    Public Property CityCd As Integer
    <DataMember()>
    Public Property Citydesc As String
    <DataMember()>
    Public Property StateCd As Integer
    <DataMember()>
    Public Property StateDesc As String
    <DataMember()>
    Public Property CntryCd As Integer
    <DataMember()>
    Public Property CntryDesc As String
End Class





Public Class clsCodeDecodeLedger

    <DataMember()>
    Public Property Decode() As String
    <DataMember()>
    Public Property addinfo1() As String


End Class


<DataContract()>
Public Class clsCodeDecodeDetails       'alpesh 20170127
    Inherits clsCodeDecode
    <DataMember()>
    Public Property SysOrUser As String
    <DataMember()>
    Public Property chk As Boolean
    <DataMember()>
    Public Property RecLock As Boolean
    <DataMember()>
    Public Property CrtUsrId As String
End Class


#Region "clsCdDcdWithBol"
'pragya : 11-mar-2017
<DataContract()>
Public Class clsCdDcdWithBol
    <DataMember()>
    Public Property Decode() As String
    <DataMember()>
    Public Property Code() As Integer
    <DataMember()>
    Public Property NoOfPages() As Integer
    <DataMember()>
    Public Property SelChk() As Boolean
End Class
#End Region

Public Class DefualtCountryStateCity

    <DataMember()>
    Public Property CountryCode As Integer
    <DataMember()>
    Public Property StateCode As Integer
    <DataMember()>
    Public Property CityCode As Integer


End Class
