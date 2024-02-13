Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Public Class clsAttPayDbEmpId

    '<DataMember()>
    'Public Property CompanyCode As String 'anamika 20160927
    '<DataMember()>
    'Public Property DivisionCode As Integer
    '<DataMember()>
    'Public Property LocationCode As Integer
    <DataMember()>
    Public Property EMPId As String
    <DataMember()>
    Public Property EmpName As String


    ''' <summary>
    ''' Gets details of EMP ID against empid
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="EmpId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetEmpIDDetails(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal companycode As String,
                                                      ByVal div As Integer,
                                                      ByVal loc As Integer,
                                                      ByVal EmpId As String) As clsAttPayDbEmpId
        GetEmpIDDetails = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELEEMPID(companycode, div, loc, EmpId))
            Dim objclsEmpId As clsAttPayDbEmpId = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objclsEmpId = New clsAttPayDbEmpId
                objclsEmpId.EmpName = ds.Tables(0).Rows(0).Item("EmpName")
            End If
            ds.Dispose()
            GetEmpIDDetails = objclsEmpId
            ofactory = Nothing
        Catch ex As Exception
            GetEmpIDDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function



    ''' <summary>
    ''' adds paramters to store procedure SPSELEEMPID
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="EmpId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELEEMPID(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal EmpId As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELEEMPID]"

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
            oParam.ParamName = "pEMPID"
            oParam.ParamValue = EmpId
            .Parameters.Add(oParam)


            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function






    ''' <summary>
    ''' Gets list of  EMP ID from attpaydb.Dbo.PersonalDetails 
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetEmpIDList(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer
                                                   ) As List(Of clsAttPayDbEmpId)
        GetEmpIDList = Nothing
        Try
            Dim ofactory As New DBFactory
            'Dim ds As DataSet = ofactory.ExecuteDataSet(SPSELEEMPID001(companycode, div, loc))
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELEEMPID001(companycode, div, loc))
            Dim objclsEmpIdlist As New List(Of clsAttPayDbEmpId)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim objclsEmpId As New clsAttPayDbEmpId
                        objclsEmpId.EMPId = .Item("EmpID")
                        objclsEmpId.EmpName = .Item("EmpName")
                        objclsEmpIdlist.Add(objclsEmpId)
                    End With
                End While
            End If
            GetEmpIDList = objclsEmpIdlist
            ofactory = Nothing
        Catch ex As Exception
            GetEmpIDList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function



    ''' <summary>
    ''' adds paramters to store procedure SPSELEEMPID
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELEEMPID001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELEEMPID001]"
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



        End With

        Return oRequest
    End Function




End Class
