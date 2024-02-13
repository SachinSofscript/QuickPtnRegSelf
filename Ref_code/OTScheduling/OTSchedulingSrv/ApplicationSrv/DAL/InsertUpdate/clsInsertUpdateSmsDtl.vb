#Region "IMPORTS"
Imports System.Runtime.Serialization
Imports SofCommon
Imports CWReadClasses
#End Region

Public Class clsInsertUpdateSmsDtl     'PRAGYA : 26-JUL-2016

#Region "SpInsSmsDtl : Insert into SMS_DTL table"

    ''' <summary>
    ''' INSERT INTO SMS_DTL 
    ''' </summary>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks>PRAGYA : 26-JUL-2016</remarks>

    Shared Function SpInsSmsDtl(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal obj As clsSmsDtl) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpInsSmsDtl]"
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSSrl"
            oParam.ParamValue = obj.SmsSrl
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSSubSrl"
            oParam.ParamValue = obj.SmsSubSrl
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSType"
            oParam.ParamValue = obj.SmsType
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSStsCd"
            oParam.ParamValue = obj.SmsStsCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSMobile"
            oParam.ParamValue = obj.SmsMobile
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSMessage"
            '  oParam.ParamValue = obj.SmsMessage
            oParam.ParamValue = obj.SmsMessage.Replace("|", "")   'PRAGYA : 01-NOV-2017
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSTimeToSend"
            oParam.ParamValue = obj.SmsTimeToSend
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSCrtby"
            oParam.ParamValue = obj.SmsCrtby
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSCrtTm"
            oParam.ParamValue = obj.SmsCrtTm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSSentTm"
            oParam.ParamValue = obj.SmsSentTm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSMSParts"
            oParam.ParamValue = obj.SmsParts
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPTNNo"
            oParam.ParamValue = obj.SmsPTNNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pVchNo"
            oParam.ParamValue = obj.SmsVchNo
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
#End Region


End Class
