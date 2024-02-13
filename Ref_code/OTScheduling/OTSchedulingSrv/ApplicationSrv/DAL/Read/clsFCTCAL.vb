Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsFCTCAL

    <DataMember()>
    Public Property CompanyCode() As String
    <DataMember()>
    Public Property DivisionCode() As Integer
    <DataMember()>
    Public Property LocationCode() As Integer
    <DataMember()>
    Public Property FctCatCode As Integer
    <DataMember()>
    Public Property FctMainCode As Integer
    <DataMember()>
    Public Property FCTCODE As Integer
    <DataMember()>
    Public Property FCTCDAY As Integer
    <DataMember()>
    Public Property SESSIONCODE As Integer
    <DataMember()>
    Public Property FCTCTMFRMHRS As Integer
    <DataMember()>
    Public Property FCTCTMFRMMIN As Integer
    <DataMember()>
    Public Property FCTCTMTOHRS As Integer
    <DataMember()>
    Public Property FCTCTMTOMNS As Integer
    '<DataMember()>
    'Public Property FCTCRMKS As Integer
    <DataMember()>
    Public Property FCTCRMKS As String 'alpesh 20161214
    <DataMember()>
    Public Property DOCCD As Integer
    <DataMember()>
    Public Property FCTCCRTUID As String
    <DataMember()>
    Public Property FCTCCRTDT As Date
    <DataMember()>
    Public Property FCTCCRTTM As Date
    <DataMember()>
    Public Property FCTCUPDUID As String
    <DataMember()>
    Public Property FCTCUPDDT As Date
    <DataMember()>
    Public Property FCTCUPDTM As Date
    <DataMember()>
    Public Property STRTTIME As Integer

    <DataMember()>
    Public Property ENDTIME As Integer

    ''' <summary>
    ''' Stored procedure to get start tiem of OT
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTCATCD"></param>
    ''' <param name="FCTMAINCD"></param>
    ''' <param name="FCTDAY"></param>
    Shared Function SPSELFCTSTRTTIME(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal FCTDAY As Integer) As DBRequest 'Mayur 20131309


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTSTRTTIME]" 'fct_cal
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = companycode
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
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = FCTCATCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = FCTMAINCD
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTDAY"
        oParam.ParamValue = FCTDAY
        oRequest.Parameters.Add(oParam)


        oRequest.CommandType = CommandType.StoredProcedure


        Return oRequest


    End Function

    ''' <summary>
    ''' TO get Strta Time of OT a per day
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetFCTFCTSTRTTIME(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                      ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer,
                                      ByVal FCTDAY As Integer) As Integer  'Mayur 20131309
        GetFCTFCTSTRTTIME = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim obj As New clsFCTCAL
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTSTRTTIME(companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD, FCTDAY))


            Dim objArr As clsFCTCAL = Nothing

            If dr1.hasrows Then

                objArr = New clsFCTCAL

                While dr1.Read()




                    With obj


                        'obj.STRTTIME = dr1.item("starttime")
                        obj.STRTTIME = IIf(IsDBNull(dr1.item("starttime")), 0, dr1.item("starttime"))  'anamika 20161114

                    End With

                End While
            End If

            dr1.close()

            GetFCTFCTSTRTTIME = obj.STRTTIME

            Return GetFCTFCTSTRTTIME

            ofactory = Nothing

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function



    ''' <summary>
    ''' Stored procedure to get start tiem of OT
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTCATCD"></param>
    ''' <param name="FCTMAINCD"></param>
    ''' <param name="FCTDAY"></param>
    Shared Function SPSELFCTENDTIME(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal FCTDAY As Integer) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTENDTIME]" 'fct_cal
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = companycode
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
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = FCTCATCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = FCTMAINCD
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTDAY"
        oParam.ParamValue = FCTDAY
        oRequest.Parameters.Add(oParam)


        oRequest.CommandType = CommandType.StoredProcedure


        Return oRequest


    End Function

    ''' <summary>
    ''' TO get End Time of OT a per day
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetFCTFCTENDTIME(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal FCTDAY As Integer) As Integer 'Mayur 20131309
        GetFCTFCTENDTIME = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTENDTIME(companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD, FCTDAY))
            Dim obj As New clsFCTCAL

            Dim objArr As clsFCTCAL = Nothing

            If dr1.hasrows Then

                objArr = New clsFCTCAL

                While dr1.Read()




                    With obj

                        obj.ENDTIME = dr1.item("endtime")

                    End With

                End While
            End If

            dr1.close()

            GetFCTFCTENDTIME = obj.ENDTIME

            Return GetFCTFCTENDTIME

            ofactory = Nothing

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' Stored procedure to get  OT Working times
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTCATCD"></param>
    ''' <param name="FCTMAINCD"></param>
    ''' <param name="FCTDAY"></param>
    Shared Function SPSELFCTCAL(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal FCTDAY As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTCAL]"  'fct_cal
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = companycode
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
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = FCTCATCD
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = FCTMAINCD
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTDAY"
        oParam.ParamValue = FCTDAY
        oRequest.Parameters.Add(oParam)


        oRequest.CommandType = CommandType.StoredProcedure


        Return oRequest


    End Function

    ''' <summary>
    ''' TO get  OT Working times
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetFCTCAL(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal FCTDAY As Integer) As List(Of clsFCTCAL)  'Mayur 20131309
        GetFCTCAL = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTCAL(companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD, FCTDAY))
            '  Dim obj As New clsFCTCAL
            Dim objArr As List(Of clsFCTCAL) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsFCTCAL)
                While dr1.Read()
                    Dim obj As New clsFCTCAL
                    With obj
                        obj.STRTTIME = dr1.item("starttime")
                        obj.ENDTIME = dr1.item("endtime")
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetFCTCAL = objArr
            Return GetFCTCAL
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
End Class
<DataContract()>
Public Class clsFctCalDetails
    Inherits clsFCTCAL
    <DataMember()>
    Public Property fctName As String

    <DataMember()>
    Public Property chkSelect As Boolean

    <DataMember()>
    Public Property dcd As String

    <DataMember()>
    Public Property docName As String
End Class