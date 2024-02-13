Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsFCTPREREQMST

    <DataMember()>
    Public Property CompanyCode() As String
    <DataMember()>
    Public Property DivisionCode() As Integer
    <DataMember()>
    Public Property LocationCode() As Integer
    <DataMember()>
    Public Property ChargeCode As Integer
    <DataMember()>
    Public Property TestCode As Integer
    <DataMember()>
    Public Property PREREQCD As Integer



    ''' <summary>
    ''' Stored procedure to get fct_apt_req_mst details
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="ChrgCd"></param>
    ''' <param name="TestCd"></param>
    Shared Function SPSELFCTREQMST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ChrgCd As Integer, ByVal TestCd As Integer) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTREQMST]"  'fct_prereq_mst
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
        oParam.ParamName = "pCHCD"
        oParam.ParamValue = ChrgCd
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pTSTCD"
        oParam.ParamValue = TestCd
        oRequest.Parameters.Add(oParam)






        oRequest.CommandType = CommandType.StoredProcedure



        Return oRequest

    End Function

    ''' <summary>
    ''' TO get list of  fct_apt_req_mst
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetFCTAPTREQMST(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ChrgCd As Integer, ByVal TestCd As Integer) As List(Of clsFCTPREREQMST)  'Mayur 20131109
        GetFCTAPTREQMST = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTREQMST(companycode, div, loc, ChrgCd, TestCd))


            Dim objArr As List(Of clsFCTPREREQMST) = Nothing

            If dr1.hasrows Then

                objArr = New List(Of clsFCTPREREQMST)

                While dr1.Read()

                    With dr1

                        Dim obj As New clsFCTPREREQMST

                        obj.PREREQCD = .Item("pre_req_code")
                        objArr.Add(obj)

                    End With

                End While
            End If

            dr1.close()

            GetFCTAPTREQMST = objArr

            Return GetFCTAPTREQMST

            ofactory = Nothing

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function



    ''' <summary>
    '''select record from fct_mst to insert schedules in  FCT_SCH
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    Shared Function SPSELFCTREQMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FctDay As Integer, ByVal pSCHDAT As Date) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTREQMST001]" 'fct_mst fct_cal
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
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = FctCatCode
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctDay"
        oParam.ParamValue = FctDay
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = FCTCODE
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pSCHDAT"
        oParam.ParamValue = pSCHDAT
        oRequest.Parameters.Add(oParam)




        oRequest.CommandType = CommandType.StoredProcedure



        Return oRequest

    End Function

    ''' <summary>
    ''' TO get list of  fct_apt_req_mst  to insert schedules in  FCT_SCH
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Shared Function GetFCTAPTREQMST001(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FctDay As Integer, ByVal SCHDAT As Date) As DataSet
        GetFCTAPTREQMST001 = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim ds1 As Object = ofactory.ExecuteDataSet(SPSELFCTREQMST001(companycode, div, loc, FctCatCode, FctMainCode, FCTCODE, FctDay, SCHDAT))
            ' Dim objArr As List(Of clsFCTPREREQMST) = Nothing
            If (ds1 IsNot Nothing) Then
                If ds1.Tables(0).Rows.Count <> 0 Then
                    Return ds1
                End If
            End If
            Return ds1
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

    ''' <summary>
    '''select record of  FCT_APT_REQUEST to know pendind schedules 
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    Shared Function SPSELFCTREQ001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTREQ001]" 'FCT_APT_REQUEST    fct_mst  Doc_Mst  Cd_DCd
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
        oParam.ParamName = "pFctCatCode"
        oParam.ParamValue = FctCatCode
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCD"
        oParam.ParamValue = FctMainCode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = FCTCODE
        oRequest.Parameters.Add(oParam)






        oRequest.CommandType = CommandType.StoredProcedure



        Return oRequest

    End Function

    ''' <summary>
    '''select record of  FCT_APT_REQUEST to know pendind schedules 
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetFCTAPTREQ001(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer) As DataSet
        GetFCTAPTREQ001 = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim ds1 As Object = ofactory.ExecuteDataSet(SPSELFCTREQ001(companycode, div, loc, FctCatCode, FctMainCode, FCTCODE))
            ' Dim objArr As List(Of clsFCTPREREQMST) = Nothing
            If (ds1 IsNot Nothing) Then
                If ds1.Tables(0).Rows.Count <> 0 Then
                    Return ds1
                End If
            End If
            Return ds1
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
End Class
