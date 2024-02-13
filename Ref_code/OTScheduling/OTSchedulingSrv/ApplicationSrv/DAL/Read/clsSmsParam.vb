#Region "IMPORTS"
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
#End Region

<DataContract()>
Public Class clsSmsParam            'PRAGYA : 28-JUL-2016

    <DataMember()>
    Public Property SmsPort() As Integer
    <DataMember()>
    Public Property SmsLastNo() As Integer
    <DataMember()>
    Public Property SmsValidMobStart() As String
    <DataMember()>
    Public Property SmsMaxLength() As Integer
    <DataMember()>
    Public Property SmsMobileLength() As Integer
    <DataMember()>
    Public Property SmsUSEGATEWAY() As Boolean
    <DataMember()>
    Public Property SMSGATEWAYURL() As String
    <DataMember()>
    Public Property SmsURLRespSuccessLike() As String
    <DataMember()>
    Public Property SmsURLRespFailedLike() As String


#Region "GetSmsParamDataWithNoParamters : SMS_Port,SMS_Last_No,SMS_Valid_Mob_Start,SMS_Max_Length,SMS_Mobile_Length  "

    ''' <summary>
    ''' GetSmsParamDataWithNoParamters : GET SMS_Port,SMS_Last_No,SMS_Valid_Mob_Start,SMS_Max_Length,SMS_Mobile_Length DETAILS FROM SMS_PARAM WITOUT PASSSING PARAMETERS
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="COCd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <returns></returns>
    ''' <remarks>PRAGYA : 28-JUL-2016</remarks>
    Shared Function GetSmsParamDataWithNoParamters(
                                                   ByVal COCd As String,
                                                   ByVal Div As Integer,
                                                   ByVal Loc As Integer) As clsSmsParam

        GetSmsParamDataWithNoParamters = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSmsParam(COCd, Div, Loc))
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New clsSmsParam
                        obj.SmsPort = IIf(IsDBNull(.Item("SMS_Port")), 0, .Item("SMS_Port"))
                        obj.SmsLastNo = IIf(IsDBNull(.Item("SMS_Last_No")), 0, .Item("SMS_Last_No"))
                        obj.SmsValidMobStart = IIf(IsDBNull(.Item("SMS_Valid_Mob_Start")), "", .Item("SMS_Valid_Mob_Start"))
                        obj.SmsMaxLength = IIf(IsDBNull(.Item("SMS_Max_Length")), 0, .Item("SMS_Max_Length"))
                        obj.SmsMobileLength = IIf(IsDBNull(.Item("SMS_Mobile_Length")), 0, .Item("SMS_Mobile_Length"))
                        GetSmsParamDataWithNoParamters = obj
                    End With
                End While
            Else
                GetSmsParamDataWithNoParamters = Nothing
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            '  strErrMsg.Add(ex.Message)
            GetSmsParamDataWithNoParamters = Nothing
        End Try

        Return GetSmsParamDataWithNoParamters

    End Function

    ''' <summary>
    ''' SpSelSmsParam :Always get the Top 1 record of SMS_PARAM
    ''' </summary>
    ''' <param name="COCd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <returns></returns>
    ''' <remarks>PRAGYA : 28-JUL-2016</remarks>

    Shared Function SpSelSmsParam(ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelSmsParam]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pcocd"
            oParam.ParamValue = COCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pdivcd"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ploccd"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function

#End Region

End Class
