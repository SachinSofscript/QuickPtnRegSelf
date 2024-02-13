Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsFCTPREREQ
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
    Public Property APPTNO As Integer
    <DataMember()>
    Public Property IPOPNO As Integer
    <DataMember()>
    Public Property PRMREQCODE As Integer
    <DataMember()>
    Public Property REQCOMPLETEYN As Integer
    <DataMember()>
    Public Property CRTUSRID As String
    <DataMember()>
    Public Property CRTDTTM As Date
    <DataMember()>
    Public Property UPDTUSRID As String
    <DataMember()>
    Public Property UPDTDTTM As Date




    ''' <summary>
    ''' Stored procedure to get fct_apt_req details
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTCATCD"></param>
    ''' <param name="FCTMAINCD"></param>
    ''' <param name="PRMREQCODE"></param>
    ''' <param name="APPTNO"></param>
    ''' <param name="IPOPNO"></param>
    Shared Function SPSELFCTREQ(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal PRMREQCODE As Integer, ByVal APPTNO As Integer, ByVal IPOPNO As Long) As DBRequest

        'Shared Function SPSELFCTREQ(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal PRMREQCODE As Integer, ByVal APPTNO As Integer, ByVal IPOPNO As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTREQ]" 'fct_apt_req
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
        oParam.ParamName = "pFCTCATCD"
        oParam.ParamValue = FCTCATCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTMAINCD"
        oParam.ParamValue = FCTMAINCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pPRMREQCODE"
        oParam.ParamValue = PRMREQCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPPTNO"
        oParam.ParamValue = APPTNO
        oRequest.Parameters.Add(oParam)

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pIPOPNO"
        oParam.ParamValue = IPOPNO
        oRequest.Parameters.Add(oParam)



        oRequest.CommandType = CommandType.StoredProcedure



        Return oRequest

    End Function

    ''' <summary>
    ''' TO get list of  fct_apt_req
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetFCTAPTREQ(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal PRMREQCODE As Integer, ByVal APPTNO As Integer, ByVal IPOPNO As Long) As clsFCTPREREQ  'Mayur 20131109
        GetFCTAPTREQ = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTREQ(companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD, PRMREQCODE, APPTNO, IPOPNO))


            Dim objArr As List(Of clsFCTPREREQ) = Nothing

            If dr1.hasrows Then

                objArr = New List(Of clsFCTPREREQ)

                While dr1.Read()

                    With dr1

                        Dim obj As New clsFCTPREREQ
                        With obj
                            obj.FctCatCode = dr1.Item("fct_cat_code")
                            obj.FctMainCode = dr1.Item("fct_main_code")
                            obj.FCTCODE = dr1.item("FCT_CODE")
                            obj.APPTNO = dr1.Item("APPT_NO")
                            obj.CRTUSRID = dr1.Item("CRT_USR_ID")
                            obj.CRTDTTM = dr1.Item("CRT_DT_TM")
                            obj.UPDTUSRID = dr1.Item("UPDT_USR_ID")
                            obj.UPDTDTTM = dr1.Item("UPDT_DT_TM")
                            obj.IPOPNO = dr1.Item("UPDT_DT_TM")
                            obj.PRMREQCODE = dr1.Item("PRM_REQ_CODE")
                            obj.REQCOMPLETEYN = dr1.item("REQ_COMPLETE_YN")
                            '  objArr.Add(obj)

                        End With
                    End With
                End While
            End If

            dr1.close()

            '  GetFCTAPTREQ = objArr

            Return GetFCTAPTREQ

            ofactory = Nothing

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


   



End Class

