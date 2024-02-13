Imports System.Runtime.Serialization
Imports SofCommon

Public Class clsConvertOpToIp

    <DataMember()>
    Public Property TrnNo As Integer
    <DataMember()>
    Public Property PtnNo As Long
    <DataMember()>
    Public Property IpNo As Long
    <DataMember()>
    Public Property DocCd As Integer
    <DataMember()>
    Public Property ExpectedDate As Date
    <DataMember()>
    Public Property PtnFullNm() As String
    <DataMember()>
    Public Property DocFullNm() As String 'anamika 20160926


    ''Amol 10-11-2020 JSK001-147270	
    Shared Function GetOpToIpConvertPtnListForOt(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer,
                                            ByVal loc As Integer, ByVal IpNo As Long, ByVal ToDate As Date) As List(Of clsConvertOpToIp)

        Try
            GetOpToIpConvertPtnListForOt = Nothing
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(GetOpToIpConvertPtnListForOt(companycode, div, loc, IpNo, ToDate))
            Dim obj As New List(Of clsConvertOpToIp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim objPatient As New clsConvertOpToIp
                        objPatient = New clsConvertOpToIp
                        objPatient.TrnNo = dr1.item("APPT_NO")
                        objPatient.PtnNo = dr1.Item("ptn_no")
                        objPatient.IpNo = dr1.Item("adm_ip_no")
                        objPatient.DocCd = dr1.Item("doccd") 'anamika 20160928
                        objPatient.PtnFullNm = dr1.Item("PatientFullName")
                        objPatient.DocFullNm = dr1.Item("DocFullName")
                        objPatient.ExpectedDate = IIf(IsDBNull(dr1.item("APTM_DATE")), Date.MinValue, dr1.item("APTM_DATE"))
                        obj.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            GetOpToIpConvertPtnListForOt = obj
            ofactory = Nothing
        Catch ex As Exception
            GetOpToIpConvertPtnListForOt = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function GetOpToIpConvertPtnListForOt(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long, ByVal ToDate As Date) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[GetOpToIpConvertPtnListForOt]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PCOCD"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PLOCCD"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDIVCD"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpNo"
            oParam.ParamValue = IpNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pToDate"
            oParam.ParamValue = ToDate
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function


End Class
