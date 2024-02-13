Imports Microsoft.VisualBasic
Imports OTScheduling.OTSchedulingSerRef

Public Class clsFormInPatientHelp
    Public Shared SchedulingProxy As iOTSchedulingClient




    Public Shared Function WardDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer) As List(Of clsCodeDecode)
        WardDetails = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            WardDetails = SchedulingProxy.WardDetails(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc)
        Catch ex As Exception
            SchedulingProxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return WardDetails
    End Function

    Public Shared Function DoctorSpeciality(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of clsCodeDecode)
        DoctorSpeciality = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            DoctorSpeciality = SchedulingProxy.DoctorSpeciality(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc)
        Catch ex As Exception
            SchedulingProxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return DoctorSpeciality
    End Function

    Public Shared Function GetDoctorList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As List(Of clsDoctor)
        GetDoctorList = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetDoctorList = SchedulingProxy.GetDoctorList(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc)
        Catch ex As Exception
            SchedulingProxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetDoctorList
    End Function

    'Public Shared Function GetInPtnListByNameDocWard(ByRef strErrMsg As List(Of String), _
    '                                              ByRef chrErrFlg As Char, _
    '                                              ByVal Cocd As String, _
    '                                              ByVal Div As Integer, _
    '                                              ByVal Loc As Integer, _
    '                                              ByVal FrstNm As String, _
    '                                              ByVal MidNm As String, _
    '                                              ByVal LstNm As String, _
    '                                              ByVal DocCd As Integer, _
    '                                            ByVal WardCd As Integer, ByVal AdmSts As Integer) As CommonMstServiceReference.clsInPatientHelp()
    '    GetInPtnListByNameDocWard = Nothing
    '    Dim tmpstrErrMsg As New List(Of String)
    '    Dim tmpchrErrFlg As Char = "N"
    '    Try
    '        SchedulingProxy = New iOTSchedulingClient()
    '        GetInPtnListByNameDocWard = SchedulingProxy.GetInPtnListByNameDocWard(tmpstrErrMsg, tmpchrErrFlg, Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts)
    '        Return GetInPtnListByNameDocWard
    '    Catch ex As Exception
    '        SchedulingProxy.Abort()
    '    Finally
    '        SchedulingProxy.Close()
    '        If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count >0 Then
    '            strErrMsg.AddRange(tmpstrErrMsg)
    '            chrErrFlg = "Y"
    '        End If
    '    End Try

    '    Return GetInPtnListByNameDocWard

    'End Function

    Public Shared Function GetDoctor(ByRef strErrMsg As List(Of String), _
                                                     ByRef chrErrFlg As Char, _
                                                     ByVal companycode As String, _
                                                     ByVal div As Integer, _
                                                     ByVal loc As Integer, _
                                                     ByVal doctorcode As Integer) As String
        GetDoctor = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetDoctor = SchedulingProxy.GetDoctor(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, doctorcode)
        Catch ex As Exception
            SchedulingProxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetDoctor
    End Function

    Public Shared Function GetInPtnListByNameDocWard(ByRef strErrMsg As List(Of String), _
                                               ByRef chrErrFlg As Char, _
                                               ByVal Cocd As String, _
                                               ByVal Div As Integer, _
                                               ByVal Loc As Integer, _
                                               ByVal FrstNm As String, _
                                               ByVal MidNm As String, _
                                               ByVal LstNm As String, _
                                               ByVal DocCd As Integer, _
                                             ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As List(Of clsInPatientHelp)
        GetInPtnListByNameDocWard = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetInPtnListByNameDocWard = SchedulingProxy.GetInPtnListByNameDocWard(tmpstrErrMsg, tmpchrErrFlg, Cocd, Div, Loc, FrstNm, MidNm, LstNm, DocCd, WardCd, AdmSts, Pageindex, PageSize)
        Catch ex As Exception
            SchedulingProxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetInPtnListByNameDocWard
    End Function
    


End Class
