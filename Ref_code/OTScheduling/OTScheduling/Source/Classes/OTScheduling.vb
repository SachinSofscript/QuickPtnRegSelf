Imports OTScheduling.OTSchedulingSerRef
Imports OTScheduling.CmnSecurityFunSrvRef
Imports System.Data
Imports Microsoft.Reporting.WebForms


Public Class OTScheduling
    Public Shared SchedulingProxy As iOTSchedulingClient
    Public Shared commonfuncproxy As iCmnSecurityFunClient

    Public Shared Function GetPatientListByNameAndOtherParameter(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                          ByRef chrErrFlg As Char,
                                                          ByVal cocd As String,
                                                          ByVal div As Integer,
                                                          ByVal loc As Integer,
                                                          ByVal FirstNm As String,
                                                          ByVal MiddleNm As String,
                                                          ByVal LastNm As String,
                                                          ByVal MobileNo As String) As List(Of clsPatient)

        GetPatientListByNameAndOtherParameter = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetPatientListByNameAndOtherParameter = SchedulingProxy.GetPatientListByNameAndOtherParameter(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, FirstNm, MiddleNm, LastNm, MobileNo)
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
        Return GetPatientListByNameAndOtherParameter
    End Function
    Public Shared Function GetCodeDeCodeDtlByTypByCd(ByRef strErrMsg As List(Of String),
                                                 ByRef chrErrFlg As Char,
                                                 ByVal cocd As String,
                                                 ByVal div As Integer,
                                                 ByVal loc As Integer, ByVal typ As OTSchedulingSerRef.EnumCodeDecode, ByVal Cd As Integer) As OTSchedulingSerRef.clsCodeDecode
        GetCodeDeCodeDtlByTypByCd = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetCodeDeCodeDtlByTypByCd = SchedulingProxy.GetCodeDeCodeDtlByTypByCd(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, typ, Cd)
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
        Return GetCodeDeCodeDtlByTypByCd
    End Function

    Public Shared Function GetFCTFCTSTRTTIME(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FCTDAY As Integer) As Integer 'Implements iOTScheduling.GetPatientList
        GetFCTFCTSTRTTIME = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetFCTFCTSTRTTIME = SchedulingProxy.GetFCTFCTSTRTTIME(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, FctCatCode, FctMainCode, FCTCODE, FCTDAY)
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
        Return GetFCTFCTSTRTTIME
    End Function

    Public Shared Function GetFCTFCTENDTIME(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FCTDAY As Integer) As Integer  'Implements iOTScheduling.GetPatientList
        GetFCTFCTENDTIME = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"

        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetFCTFCTENDTIME = SchedulingProxy.GetFCTFCTENDTIME(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, FctCatCode, FctMainCode, FCTCODE, FCTDAY)
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
        Return GetFCTFCTENDTIME
    End Function

    Public Shared Function GetPatientList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of clsPatient) 'Implements iOTScheduling.GetPatientList

        GetPatientList = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetPatientList = SchedulingProxy.GetPatientList(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc)
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
        Return GetPatientList
    End Function

    Public Shared Function GetDoctorList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of clsDoctor) 'Implements iOTScheduling.GetDoctorList
        GetDoctorList = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetDoctorList = SchedulingProxy.GetDoctorList(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc)
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

    Public Shared Function DoctorSpeciality(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of OTSchedulingSerRef.clsCodeDecode)
        DoctorSpeciality = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

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

    Public Shared Function SAVERECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                      ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer,
                                      ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer,
                                      ByVal FCTCODE As Integer, ByVal FctDay As Integer, ByVal SCHDAT As Date,
                                      ByVal lvReqno As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT,
                                      ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ,
                                      ByVal objclsFCTSCH As clsFCTSCH,
                                      ByVal obj As OTSchedulingSerRef.ClsOtIndirectBooking,
                                      ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv),
                                      ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc),
                                      ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp),
                                      ByRef AptNo As Integer) As Boolean 'Implements iOTScheduling.SAVERECORD
        SAVERECORD = False
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"

        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            SAVERECORD = SchedulingProxy.SAVERECORD(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, FctCatCode, FctMainCode, FCTCODE, FctDay, SCHDAT, lvReqno, objclsFCTAPTOT, objclsFCTAPTMAIN, mobjFCTAPTREQ, objclsFCTSCH, obj, arrObjOtSrvLst, arrObjOtDocLst, arrObjOtEmpLst, AptNo)
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
        Return SAVERECORD
    End Function

    Public Shared Function SaveIndirectBooking(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef ChrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal obj As OTSchedulingSerRef.ClsOtIndirectBooking) As Boolean
        SaveIndirectBooking = False
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            SaveIndirectBooking = SchedulingProxy.SaveIndirectBooking(strErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, obj)
        Catch ex As Exception
            SchedulingProxy.Abort()
            strErrMsg.Add(ex.Message)
            ChrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                ChrErrFlg = "Y"
            End If
        End Try
        Return SaveIndirectBooking
    End Function

    Public Shared Function CancelOtIndirectBooking(ByRef StrErrMsg As System.Collections.Generic.List(Of String), ByRef ChrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal TrnNo As Integer, ByVal PtnNo As Long, ByVal UsrId As String, ByVal UsrDatTm As Date) As Boolean
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        StrErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            CancelOtIndirectBooking = SchedulingProxy.CancelOtIndirectBooking(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, TrnNo, PtnNo, UsrId, UsrDatTm)
        Catch ex As Exception
            SchedulingProxy.Abort()
            StrErrMsg.Add(ex.Message)
            ChrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                StrErrMsg.AddRange(tmpstrErrMsg)
                ChrErrFlg = "Y"
            End If
        End Try
        Return CancelOtIndirectBooking
    End Function


    Public Shared Function CNCLRECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal ApptNo As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal objclsFCTSCH As clsFCTSCH, ByVal objclsFCTAPTCNCL As clsFCTAPTCNCL) As Boolean 'Implements iOTScheduling.CLCLRECORD
        CNCLRECORD = False
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            CNCLRECORD = SchedulingProxy.CNCLRECORD(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, FctCatCode, FctMainCode, FCTCODE, ApptNo, objclsFCTAPTOT, objclsFCTAPTMAIN, objclsFCTSCH, objclsFCTAPTCNCL)
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
        Return CNCLRECORD
    End Function


    Public Shared Function GetOtIndirectBookingLst(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ExpDate As Date, ByVal ToDate As Date
                                                   ) As List(Of ClsOtIndirectBookingLst)
        GetOtIndirectBookingLst = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetOtIndirectBookingLst = SchedulingProxy.GetOtIndirectBookingLst(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, ExpDate, ToDate)
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
        Return GetOtIndirectBookingLst
    End Function

    Public Shared Function EDITERECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal FctDay As Integer, ByVal SCHDAT As Date, ByVal lvReqno As Integer, ByVal ApptNo As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp)) As Boolean 'Implements iOTScheduling.EDITERECORD
        EDITERECORD = False
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            EDITERECORD = SchedulingProxy.EDITERECORD(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, FctCatCode, FctMainCode, FCTCODE, FctDay, SCHDAT, lvReqno, ApptNo, objclsFCTAPTOT, objclsFCTAPTMAIN, mobjFCTAPTREQ, objclsFCTSCH, arrObjOtSrvLst, arrObjOtDocLst, arrObjOtEmpLst)
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
        Return EDITERECORD
    End Function

    Public Shared Function SHIFTRECORD(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal ApptNo As Integer, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal objclsFCTAPTCNCL As clsFCTAPTCNCL, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp)) As Boolean 'Implements iOTScheduling.SHIFTRECORD
        SHIFTRECORD = False
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            SHIFTRECORD = SchedulingProxy.SHIFTRECORD(tmpstrErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FctCatCode, FctMainCode, FCTCODE, ApptNo, objclsFCTAPTOT, objclsFCTAPTMAIN, mobjFCTAPTREQ, objclsFCTSCH, objclsFCTAPTCNCL, arrObjOtSrvLst, arrObjOtDocLst, arrObjOtEmpLst)
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
        Return SHIFTRECORD
    End Function

    Public Shared Function SHIFTNOW(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer, ByVal OldFCTCODE As Integer, ByVal FctDay As Integer, ByVal SCHDAT As Date, ByVal lvReqno As Integer, ByVal ApptNo As Integer, ByVal IPNO As Long, ByVal objclsFCTAPTOT As clsFCTAPTOT, ByVal objclsFCTAPTMAIN As clsFCTAPTMAIN, ByVal mobjFCTAPTREQ As clsFCTAPTREQ, ByVal objclsFCTSCH As clsFCTSCH, ByVal objclsFCTAPTCNCL As clsFCTAPTCNCL, ByVal arrObjOtSrvLst As List(Of clsFctAptOtSrv), ByVal arrObjOtDocLst As List(Of clsFctAptOtDoc), ByVal arrObjOtEmpLst As List(Of clsFctAptOtEmp)) As String 'Implements iOTScheduling.SHIFTNOW
        SHIFTNOW = ""
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            SHIFTNOW = SchedulingProxy.SHIFTNOW(tmpstrErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, FctCatCode, FctMainCode, FCTCODE, OldFCTCODE, FctDay, SCHDAT, lvReqno, ApptNo, IPNO, objclsFCTAPTOT, objclsFCTAPTMAIN, mobjFCTAPTREQ, objclsFCTSCH, objclsFCTAPTCNCL, arrObjOtSrvLst, arrObjOtDocLst, arrObjOtEmpLst)
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
        Return SHIFTNOW
    End Function

    Public Shared Function GetFCTAPTREQ(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctCatCode As Integer, ByVal FctMainCode As Integer, ByVal FCTCODE As Integer) As DataSet
        GetFCTAPTREQ = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetFCTAPTREQ = SchedulingProxy.GetFCTAPTREQ(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, FctCatCode, FctMainCode, FCTCODE)
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
        Return GetFCTAPTREQ
    End Function

    Public Shared Function GetFCTMST(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer) As List(Of clsFCTMST)
        GetFCTMST = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetFCTMST = SchedulingProxy.GetFCTMST(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD)
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
        Return GetFCTMST
    End Function

    Public Shared Function GetFctMstDtlList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer) As List(Of OTSchedulingSerRef.clsMaster) 'Implements iOTScheduling.GetDoctorList
        GetFctMstDtlList = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"

        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetFctMstDtlList = SchedulingProxy.GetFctMstDtlList(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, FCTCODE, FCTCATCD, FCTMAINCD)
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
        Return GetFctMstDtlList
    End Function

    Public Shared Function GetFCTHoliDayDay(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FctDay As Date, ByVal FCTCODE As Integer) As List(Of clsFCTMST) 'Implements iOTScheduling.GetPatientList
        GetFCTHoliDayDay = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetFCTHoliDayDay = SchedulingProxy.GetFCTHoliDayDay(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, FCTCODE, FctDay)
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
        Return GetFCTHoliDayDay
    End Function

    Public Shared Function GetFCCAL(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal FCTDAY As Integer) As List(Of clsFCTCAL)
        GetFCCAL = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"

        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetFCCAL = SchedulingProxy.GetFCTCAL(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD, FCTDAY)
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
        Return GetFCCAL
    End Function

    Public Shared Function GetOTAptDetails(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                       ByVal companycode As String,
                                                       ByVal div As Integer,
                                                       ByVal loc As Integer,
                                                       ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal APTMDATE As Date, ByVal APTNO As Integer, ByVal APTMTMFRM As Integer, ByVal APTMTMTO As Integer, ByVal FLG As String) As List(Of clsFCTAPTOT)
        GetOTAptDetails = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetOTAptDetails = SchedulingProxy.GetOTAptDetails1(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD, APTMDATE, APTNO, APTMTMFRM, APTMTMTO, "bydat")
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
        Return GetOTAptDetails
    End Function

    Public Shared Function GetPatientFullName(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                              ByRef chrErrFlg As Char, ByVal pcompanycode As String,
                                              ByVal pdiv As Integer, ByVal ploc As Integer, ByVal PATNO As Long) As String 'Implements iOTScheduling.GetDoctorList
        GetPatientFullName = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetPatientFullName = SchedulingProxy.GetPatientFullName(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, PATNO)
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
        Return GetPatientFullName
    End Function

    Public Shared Function GetDoctorName(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal companycode As String,
                                                    ByVal div As Integer,
                                                    ByVal loc As Integer,
                                                    ByVal doctorcode As Integer) As String


        GetDoctorName = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetDoctorName = SchedulingProxy.GetDoctor(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, doctorcode)
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
        Return GetDoctorName
    End Function

    Public Shared Function GetOtName(ByRef strErrMsg As List(Of String),
                                     ByRef chrErrFlg As Char,
                                     ByVal companycode As String,
                                     ByVal div As Integer,
                                     ByVal loc As Integer,
                                     ByVal OtNo As Integer) As String


        GetOtName = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetOtName = SchedulingProxy.GetOtName(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, OtNo)
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
        Return GetOtName
    End Function



    Public Shared Function GetInpatientDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long) As clsIpPatientVisit 'clsInPatient
        GetInpatientDetails = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetInpatientDetails = SchedulingProxy.GetInpatientDetails(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, IpNo)
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
        Return GetInpatientDetails
    End Function


    Public Shared Function UserRights(ByRef strErrMsg As List(Of String),
                                                         ByRef chrErrFlg As Char,
                                                         ByVal Cocd As String,
                                                         ByVal div As Integer,
                                                         ByVal loc As Integer,
                                                         ByVal UserId As String,
                                                            ByVal ModCd As Integer, ByVal SubModCd As Integer
                                                        ) As String
        UserRights = ""
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            commonfuncproxy = New iCmnSecurityFunClient
            UserRights = commonfuncproxy.UserRights(tmpstrErrMsg, chrErrFlg, Cocd, div, loc, UserId, ModCd, SubModCd)
        Catch ex As Exception
            commonfuncproxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            commonfuncproxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return UserRights
    End Function

#Region "OT SERVICES HELP"
    'pragya : 12-oct-2016
    Public Shared Function GetListOfOTSrvDtls(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer, ByVal Srvdesc As String) As List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
        GetListOfOTSrvDtls = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        SchedulingProxy = New iOTSchedulingClient()
        Try
            GetListOfOTSrvDtls = SchedulingProxy.GetOtSchSrvList(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, Srvdesc).ToList
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
        Return GetListOfOTSrvDtls
    End Function

#End Region

#Region "OT SERVICES PARAM HELP"
    'pragya : 12-oct-2016
    Public Shared Function GetListOfOTSrvParamDtls(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal ChrgCd As Integer,
                                               ByVal SrvCd As Integer) As List(Of OTSchedulingSerRef.clsFctAptOtSrvprm)
        GetListOfOTSrvParamDtls = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        SchedulingProxy = New iOTSchedulingClient()
        Try
            GetListOfOTSrvParamDtls = SchedulingProxy.GetLstOtSchSrvParaNm(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, ChrgCd, SrvCd).ToList
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
        Return GetListOfOTSrvParamDtls
    End Function

#End Region

#Region "GetCalRate"
    'pragya : 12-oct-2016
    Public Shared Function GetCalRate(ByRef strErrMsg As List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal pcompanycode As String,
                                      ByVal pdiv As Integer,
                                      ByVal ploc As Integer,
                                       ByRef objcalRate As OTSchedulingSerRef.clsCalRate, ByVal EmergencyFlg As String) As OTSchedulingSerRef.clsCalRate
        GetCalRate = Nothing
        'Dim tmpstrErrMsg As New List(Of String)
        'Dim tmpchrErrFlg As Char = "N"
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetCalRate = SchedulingProxy.GetCalRate(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, objcalRate, EmergencyFlg)
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
        Return GetCalRate
    End Function
#End Region




#Region "GetPtnClsCdFrmIpNo"
    'pragya : 12-oct-2016
    Public Shared Function GetPtnClsCdFrmIpNo(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal pcompanycode As String,
                                      ByVal pdiv As Integer,
                                      ByVal ploc As Integer,
                                      ByVal IpNo As Long) As OTSchedulingSerRef.clsPtnVstPtnClsDtl
        GetPtnClsCdFrmIpNo = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetPtnClsCdFrmIpNo = SchedulingProxy.GetPtnClsDtlByIpOpNo(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, IpNo)
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
        Return GetPtnClsCdFrmIpNo
    End Function
#End Region

#Region "GetArCdCdFrmIpNo"
    'pragya : 12-oct-2016
    Public Shared Function GetArCdCdFrmIpNo(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal pcompanycode As String,
                                      ByVal pdiv As Integer,
                                      ByVal ploc As Integer,
                                      ByVal IpNo As Long) As Integer
        GetArCdCdFrmIpNo = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetArCdCdFrmIpNo = SchedulingProxy.GetArCdByIpOpNo(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, IpNo)
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
        Return GetArCdCdFrmIpNo
    End Function
#End Region

#Region "GetCodeDeCodeList"
    'PRAGYA : 14-OCT-2016
    Public Shared Function GetCodeDeCodeList(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal typ As OTSchedulingSerRef.EnumCodeDecode
                                              ) As List(Of OTSchedulingSerRef.clsCodeDecode)
        GetCodeDeCodeList = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetCodeDeCodeList = SchedulingProxy.GetCodeDeCodeList(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, typ)
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
        Return GetCodeDeCodeList
    End Function

#End Region

#Region "GetOtDocSpltyByDocCd"
    'PRAGYA : 14-OCT-2016
    Public Shared Function GetOtDocSpltyByDocCd(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal DocCd As Integer
                                              ) As OTSchedulingSerRef.clsOtDocDtls
        GetOtDocSpltyByDocCd = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetOtDocSpltyByDocCd = SchedulingProxy.GetFctAptOtDocList(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, DocCd)
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
        Return GetOtDocSpltyByDocCd
    End Function

#End Region

#Region "GetLstOfOtDocDtls"
    'PRAGYA : 15-OCT-2016
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FctCd"></param>
    ''' <param name="FctCatCd"></param>
    ''' <param name="FctMainCd"></param>
    ''' <param name="ApptNo"></param>
    ''' <param name="PtnNo"></param>
    ''' <param name="IpNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLstOfOtDocDtls(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal FctCd As Integer,
                                                    ByVal FctCatCd As Integer,
                                                    ByVal FctMainCd As Integer,
                                                    ByVal ApptNo As Integer,
                                                    ByVal PtnNo As Long,
                                                    ByVal IpNo As Long, ByVal IpOpFlag As String
                                              ) As List(Of OTSchedulingSerRef.clsOtDocDtls)
        GetLstOfOtDocDtls = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetLstOfOtDocDtls = SchedulingProxy.GetLstOtDocDtlsByApptNoIpNo(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, FctCd, FctCatCd, FctMainCd, ApptNo, PtnNo, IpNo, IpOpFlag).ToList
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
        Return GetLstOfOtDocDtls
    End Function

#End Region

#Region "GetLstOfOtSrvDtls"
    'PRAGYA : 31-OCT-2016
    Public Shared Function GetLstOfOtSrvDtls(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal FctCd As Integer,
                                               ByVal FctCatCd As Integer,
                                               ByVal FctMainCd As Integer,
                                               ByVal ApptNo As Integer,
                                               ByVal PtnNo As Long,
                                               ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
        GetLstOfOtSrvDtls = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetLstOfOtSrvDtls = SchedulingProxy.GetLstOtSrvDtlsByApptNoIpNo(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, FctCd, FctCatCd, FctMainCd, ApptNo, PtnNo, IpNo, IpOpFlag)
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
        Return GetLstOfOtSrvDtls
    End Function

#End Region

#Region "GetPtnNoByIpNo : get the ptnno by ipno of patient"
    'GetPtnNoByIpNo
    Public Shared Function GetPtnNoByIpNo(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal pcompanycode As String,
                                      ByVal pdiv As Integer,
                                      ByVal ploc As Integer,
                                      ByVal IpNo As Long) As Long
        GetPtnNoByIpNo = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetPtnNoByIpNo = SchedulingProxy.GetPtnNoByIpNo(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, IpNo)
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
        Return GetPtnNoByIpNo
    End Function
#End Region

#Region "GetOTEmpList"
    'PRAGYA : 01-DEC-2016
    Public Shared Function GetOTEmpList(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                ByRef chrErrFlg As Char,
                                ByVal cocd As String,
                                ByVal div As Integer,
                                ByVal loc As Integer) As List(Of clsAttPayDbEmpId)


        GetOTEmpList = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetOTEmpList = SchedulingProxy.GetOtEmpIdLst(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc).ToList
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
        Return GetOTEmpList
    End Function
#End Region

#Region "GetLstOfOtEmpDtls"
    'PRAGYA : 01-Dec-2016
    Public Shared Function GetLstOfOtEmpDtls(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal FctCd As Integer,
                                               ByVal FctCatCd As Integer,
                                               ByVal FctMainCd As Integer,
                                               ByVal ApptNo As Integer,
                                               ByVal PtnNo As Long,
                                               ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of OTSchedulingSerRef.clsFctAptOtEmpDtls)
        GetLstOfOtEmpDtls = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetLstOfOtEmpDtls = SchedulingProxy.GetLstOtEmpDtlsByApptNoIpNo(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, FctCd, FctCatCd, FctMainCd, ApptNo, PtnNo, IpNo, IpOpFlag).ToList
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
        Return GetLstOfOtEmpDtls
    End Function

#End Region

#Region "GetOtEmpDtlsByEmpNo"
    'PRAGYA : 01-Dec-2016
    Public Shared Function GetOtEmpDtlsByEmpNo(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal cocd As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer,
                                               ByVal EmpId As String) As OTSchedulingSerRef.clsAttPayDbEmpId
        GetOtEmpDtlsByEmpNo = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetOtEmpDtlsByEmpNo = SchedulingProxy.GetOtEmpDtlsByEmpNo(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, EmpId)
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
        Return GetOtEmpDtlsByEmpNo
    End Function

#End Region

#Region "GET ACTIVE OT DETAILS" 'RasikV 20170130
    Public Shared Function GetFCTMstLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer) As List(Of clsFCTMstHelp)
        GetFCTMstLst = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetFCTMstLst = SchedulingProxy.GetFCTMstLst(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc, FCTCatCd, FCTMainCd)
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
        Return GetFCTMstLst
    End Function
#End Region

    Public Shared Function GetWardDetails(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As List(Of OTSchedulingSerRef.clsCodeDecode)
        GetWardDetails = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetWardDetails = SchedulingProxy.WardDetails(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc)
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
        Return GetWardDetails
    End Function

    Public Shared Function GetDoctor(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal DocCd As String) As String
        GetDoctor = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetDoctor = SchedulingProxy.GetDoctor(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, DocCd)
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

    Public Shared Function GetInPtnListByNameDocWard(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal Cocd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FrstNm As String, ByVal MidNm As String, ByVal LstNm As String, ByVal DocCd As Integer, ByVal WardCd As Integer, ByVal AdmSts As Integer, ByVal Pageindex As Integer, ByVal PageSize As Integer) As List(Of clsInPatientHelp)
        GetInPtnListByNameDocWard = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
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
    Public Shared Function PopulatePager(ByRef strErrMsg As List(Of String),
                                                          ByRef chrErrFlg As Char,
                                                          ByVal recordCount As Integer, ByVal currentPage As Integer, ByVal DispNum As Integer, ByVal GridType As Char, ByVal Repeater As List(Of clsPaging), ByVal ItemCd As String, ByRef ReturnPageIndex As Integer, ByVal PageSize As Integer) As List(Of clsPaging)
        PopulatePager = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            PopulatePager = SchedulingProxy.PopulatePager(strErrMsg, chrErrFlg, recordCount, currentPage, DispNum, GridType, Repeater, ItemCd, ReturnPageIndex, PageSize)
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
        Return PopulatePager
    End Function
#Region "PRINT"

    Public Shared Function GetNetIdParamDetails(ByRef strErrMsg As List(Of String),
                       ByRef chrErrFlg As Char,
                       ByVal companycode As String,
                       ByVal div As Integer,
                       ByVal loc As Integer,
                       ByVal modcd As Integer, ByVal submodcd As Integer, ByVal netid As Integer) As List(Of clsNetIDParam)
        GetNetIdParamDetails = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try

            SchedulingProxy = New iOTSchedulingClient()
            GetNetIdParamDetails = SchedulingProxy.GetNetIdParamDetailsNew(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, modcd, submodcd, netid)
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
        Return GetNetIdParamDetails
    End Function

    Public Shared Function GetNetIdDetailsWithForReportPath(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                       ByVal companycode As String,
                                                       ByVal div As Integer,
                                                       ByVal loc As Integer,
                                                       ByVal UserINetid As Integer
                                                      ) As CmnSecurityFunSrvRef.clsNetId
        GetNetIdDetailsWithForReportPath = Nothing
        Dim tmpstrErrMsg() As String = {""}
        Dim tmpchrErrFlg As Char = "N"
        Try
            commonfuncproxy = New iCmnSecurityFunClient
            GetNetIdDetailsWithForReportPath = commonfuncproxy.GetNetIdDetailsWithForReportPath(tmpstrErrMsg.ToList, tmpchrErrFlg, companycode, div, loc, UserINetid)
        Catch ex As Exception
            commonfuncproxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            commonfuncproxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetNetIdDetailsWithForReportPath
    End Function

    Public Shared Function GetReportServerUserNamePassword(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal companycode As String,
                                                     ByVal div As Integer,
                                                     ByVal loc As Integer
                                                    ) As List(Of String)
        GetReportServerUserNamePassword = Nothing
        Dim tmpstrErrMsg() As String = {""}
        Dim tmpchrErrFlg As Char = "N"
        Try
            commonfuncproxy = New iCmnSecurityFunClient
            GetReportServerUserNamePassword = commonfuncproxy.GetReportServerUserNamePassword(tmpstrErrMsg.ToList, tmpchrErrFlg, companycode, div, loc)
        Catch ex As Exception
            commonfuncproxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            commonfuncproxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetReportServerUserNamePassword
    End Function

    Public Shared Function GetPrntRptViewerRule8013(ByVal strErrMsg As List(Of String), ByVal chrErrFlg As Char, ByVal Cocd As String,
                                                        ByVal div As Integer, ByVal loc As Integer) As Boolean      'Aarti 20170912
        'INSTANT VB NOTE: The local variable GetPrntRptViewerRule8013 was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
        Dim GetPrntRptViewerRule8013_Renamed As Boolean = False
        Dim tmpstrErrMsg As New List(Of String)()
        Dim tmpchrErrFlg As Char = Convert.ToChar("N")
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetPrntRptViewerRule8013 = SchedulingProxy.GetPrntRptViewerRule8013(tmpstrErrMsg, tmpchrErrFlg, Cocd, div, loc)
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
        Return GetPrntRptViewerRule8013
    End Function
    Public Shared Function SetParamAndViewReport(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char,
                              ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                              ByVal modcd As Integer, ByVal submodcd As Integer, ByVal netid As Integer,
                              ByRef Param As List(Of Microsoft.Reporting.WebForms.ReportParameter),
                              ByRef p_bytes As Byte(), ByVal page As System.Web.UI.Page) As Boolean

        Try
            Dim objclsNetIDParam As clsNetIDParam()
            'clsGeneral.ShowErrorPopUp("1 ", "", page)
            objclsNetIDParam = OTScheduling.GetNetIdParamDetails(strErrMsg, chrErrFlg, companycode, div, loc, modcd, submodcd, netid).ToArray ''Amol 21-06-2017
            Dim rview As New Microsoft.Reporting.WebForms.ReportViewer
            Dim objclsnet As CmnSecurityFunSrvRef.clsNetId
            objclsnet = OTScheduling.GetNetIdDetailsWithForReportPath(strErrMsg, chrErrFlg, companycode, div, loc, netid)
            If objclsnet IsNot Nothing Then
                rview.ServerReport.ReportServerUrl = New System.Uri(objclsnet.DefPath)
                rview.ServerReport.ReportPath = objclsnet.TableName
            End If

            rview.ProcessingMode = ProcessingMode.Remote

            Dim ispasswordset As String = System.Configuration.ConfigurationManager.AppSettings("HasPassword")
            If ispasswordset = "Y" Then
                Dim usernamepassword As New List(Of String)
                usernamepassword = OTScheduling.GetReportServerUserNamePassword(strErrMsg, chrErrFlg, companycode, div, loc)
                Dim irsc As IReportServerCredentials = New ReportVererCredentials(usernamepassword(2), usernamepassword(3))
                ' Dim irsc As IReportServerCredentials = New ReportVererCredentials(usernamepassword(1), usernamepassword(2))
                rview.ServerReport.ReportServerCredentials = irsc

            End If

            ''add these lines''
            'rview.ServerReport.SetParameters(Param)
            'rview.ShowParameterPrompts = True
            'rview.ShowPrintButton = True
            'rview.ServerReport.Refresh()
            ''add these lines''

            'rview.GetPageSettings.Landscape = True     ''DO NOT USE- ERROR OCCURED WHEN PUBLISHED.
            Dim ListNetIdParams As New List(Of CWSQLServerReportLib.NetIDParam)
            For i = 0 To objclsNetIDParam.Count - 1
                Dim objReportLibNetIDParam As New CWSQLServerReportLib.NetIDParam
                objReportLibNetIDParam.ParamID = objclsNetIDParam(i).ParamID
                objReportLibNetIDParam.ParamType = objclsNetIDParam(i).ParamType
                objReportLibNetIDParam.ParamValue = objclsNetIDParam(i).ParamValue
                objReportLibNetIDParam.ParamName = objclsNetIDParam(i).ParamName
                ListNetIdParams.Add(objReportLibNetIDParam)
            Next
            Dim deviceInfo As String = ""
            Dim mimeType As String = ""
            Dim encoding As String = ""
            Dim extension As String = ""
            Dim warnings() As Microsoft.Reporting.WebForms.Warning = Nothing
            Dim format As String = "PDF"

            Dim objClsReportParams As New CWSQLServerReportLib.ClsReportParams
            'clsGeneral.ShowErrorPopUp("before setting param, deviceInfo = " & deviceInfo, "", page)
            objClsReportParams.SetReportParameters(rview, Param, deviceInfo, ListNetIdParams, False)
            'clsGeneral.ShowErrorPopUp("before render, deviceInfo = " & deviceInfo, "", page)
            Dim bytes As Byte() = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, strErrMsg.ToArray, warnings)
            'clsGeneral.ShowErrorPopUp("after render, deviceInfo = " & deviceInfo, "", page)
            p_bytes = bytes
            'My.Computer.FileSystem.ReadAllText("printsettings.ini")
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), Guid.NewGuid().ToString(), "opendefault();", True)

            Return True

        Catch ex As Exception
            'clsGeneral.ShowErrorPopUp(ex.Message & "clsIP Catch", "", page)
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            clsGeneral.ShowErrorPopUp(ex.Message & " - clsIPRsrv Catch", "", page)
            Return False
            'Throw ex
        End Try

    End Function

    Public Shared Function GetOtIndirectBookingLst002(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                      ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer,
                                                      ByVal loc As Integer, ByVal IpNo As Long, ByVal Doccd As Integer, ByVal ExpDate As Date
                                                   ) As List(Of ClsOtIndirectBookingLst)
        GetOtIndirectBookingLst002 = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetOtIndirectBookingLst002 = SchedulingProxy.GetOtIndirectBookingLst002(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, IpNo, Doccd, ExpDate)
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
        Return GetOtIndirectBookingLst002
    End Function


#End Region


    Public Shared Function GetRuleMstDtls(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                       ByVal companycode As String,
                                                       ByVal div As Integer,
                                                       ByVal loc As Integer,
                                                       ByVal Ruleid As Integer
                                                      ) As clsRuleMaster            'Aarti 10 Oct 2020

        GetRuleMstDtls = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()

            GetRuleMstDtls = SchedulingProxy.GetRuleMstDtls(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, Ruleid)
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
        Return GetRuleMstDtls
    End Function



    Public Shared Function GetOpToIpConvertPtnListForOt(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char,
                                              ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                              ByVal IpNo As Long, ByVal ToDate As Date) As List(Of clsConvertOpToIp)  ''Amol 07-11-2020 JSK001-147270	
        GetOpToIpConvertPtnListForOt = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetOpToIpConvertPtnListForOt = SchedulingProxy.GetOpToIpConvertPtnListForOt(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, IpNo, ToDate)
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
        Return GetOpToIpConvertPtnListForOt
    End Function


    Public Shared Function GetIpWiseOtAppList(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char,
                                              ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                              ByVal IpNo As Long, ByVal ToDate As Date) As List(Of ClsOtIndirectBookingLst) ''Amol 07-11-2020 JSK001-147271	
        GetIpWiseOtAppList = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetIpWiseOtAppList = SchedulingProxy.GetIpWiseOtAppList(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, IpNo, ToDate)
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
        Return GetIpWiseOtAppList
    End Function


    Public Shared Function ConvertOpToIp(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char,
                               ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer,
                               ByVal AptNo As Integer, ByVal IPNO As Long, ByVal PtnNo As Long) As Boolean  ''Amol 10-11-2020 JSK001-147270	
        ConvertOpToIp = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            ConvertOpToIp = SchedulingProxy.ConvertOpToIp(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, AptNo, IPNO, PtnNo)
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
        Return ConvertOpToIp
    End Function

#Region "Get Patient list by Mobile No."
    Public Shared Function GetPtnDtlByMobNoDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char,
                                              CoCd As String, Div As Integer, Loc As Integer, MobNo As String) As List(Of clsPtnBasicInfo) ''Aarti 09 Jan 2020
        GetPtnDtlByMobNoDetails = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetPtnDtlByMobNoDetails = SchedulingProxy.GetPtnDtlByMobNoDetails(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc, MobNo)
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
        Return GetPtnDtlByMobNoDetails
    End Function
#End Region

#Region "Get Patient Title Code(Salutation)"
    Public Shared Function Salutation(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer) As List(Of OTSchedulingSerRef.clsCodeDecode) ''Aarti 09 Jan 2020
        Salutation = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            Salutation = SchedulingProxy.Salutation(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc)
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
        Return Salutation
    End Function
#End Region

#Region "Get Patient Nationality"
    Public Shared Function Nationality(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer) As List(Of OTSchedulingSerRef.clsCodeDecode) ''Aarti 09 Jan 2020
        Nationality = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            Nationality = SchedulingProxy.Nationality(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc)
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
        Return Nationality
    End Function
#End Region


    Public Shared Function GetCdDcdDtlByTypByCdByAddInfo1(ByRef strErrMsg As List(Of String),
                                                   ByRef chrErrFlg As Char,
                                                   ByVal cocd As String,
                                                   ByVal div As Integer,
                                                   ByVal loc As Integer, ByVal typ As Integer, ByVal AddInfo1 As String
                                                  ) As OTSchedulingSerRef.clsCodeDecode 'anamika 20150128
        GetCdDcdDtlByTypByCdByAddInfo1 = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetCdDcdDtlByTypByCdByAddInfo1 = SchedulingProxy.GetCdDcdDtlByTypByCdByAddInfo1(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, typ, AddInfo1)
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
        Return GetCdDcdDtlByTypByCdByAddInfo1
    End Function


#Region "Get Patient Type"
    Public Shared Function GetPtnType(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer, pPtnBillTyp As Integer) As List(Of clsPtnTypeMst) ''Aarti 09 Jan 2020
        GetPtnType = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetPtnType = SchedulingProxy.GetPtnType(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc, pPtnBillTyp)
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
        Return GetPtnType
    End Function
#End Region


    Public Shared Function GetStateLst(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer, statecd As Integer, stateName As String) As List(Of StateMaster) ''Aarti 09 Jan 2020
        GetStateLst = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetStateLst = SchedulingProxy.GetStateLst(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc, statecd, stateName)
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
        Return GetStateLst
    End Function

    Public Shared Function GetCityLst(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef chrErrFlg As Char, CoCd As String, Div As Integer, Loc As Integer, Statecd As Integer, citycd As Integer, cityname As String) As List(Of StateMaster) ''Aarti 09 Jan 2020
        GetCityLst = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetCityLst = SchedulingProxy.GetCityLst(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc, Statecd, citycd, cityname)
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
        Return GetCityLst
    End Function

    Public Shared Function SaveConfirmEnqPtn(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                     ByRef chrErrFlg As Char, ByRef SessionState As Integer,
                                     ByRef PtnNo As Long,
                                     ByVal CoCd As String,
                                     ByVal Div As Integer,
                                     ByVal Loc As Integer, ByVal ModCd As Integer,
                                               ByVal SubModCd As Integer,
                                               ByVal SessionId As Long,
                                     ByVal UsrId As String,
                                     ByVal UsrDtTm As Date,
                                     ByVal objBkdDtls As clsPatient) As Boolean
        SaveConfirmEnqPtn = False
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"

        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            SaveConfirmEnqPtn = SchedulingProxy.SaveConfirmEnqPtn(tmpstrErrMsg, tmpchrErrFlg, SessionState, PtnNo, CoCd, Div, Loc, ModCd, SubModCd, SessionId, UsrId, UsrDtTm, objBkdDtls)
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
        Return SaveConfirmEnqPtn
    End Function

    Public Shared Function GetUserWsModFnDetails(ByRef strErrMsg As List(Of String),
                                 ByRef chrErrFlg As Char,
                                 ByVal CoCd As String,
                                 ByVal Div As Integer,
                                 ByVal Loc As Integer,
                                 ByVal ModCd As Integer,
                                 ByVal SubModCd As Integer,
                                 ByVal FuncID As Integer,
                                 ByVal UserID As String) As List(Of clsUserModuleFunction)
        GetUserWsModFnDetails = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetUserWsModFnDetails = SchedulingProxy.GetModFncLst(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc, ModCd, SubModCd, FuncID, UserID)
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
        Return GetUserWsModFnDetails
    End Function



    Public Shared Function GetPtnTypListByUser(ByRef strErrMsg As List(Of String),
                                                          ByRef chrErrFlg As Char,
                                                          ByVal cocd As String,
                                                          ByVal div As Integer,
                                                          ByVal loc As Integer, ByVal UserId As String) As List(Of ClsUserPtnTypMst)
        GetPtnTypListByUser = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Dim OTDashBoardProxy As iOTSchedulingClient
        OTDashBoardProxy = New iOTSchedulingClient
        Try
            GetPtnTypListByUser = OTDashBoardProxy.GetPtnTypListByUser(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, UserId)
        Catch ex As Exception
            OTDashBoardProxy.Abort()
            tmpstrErrMsg.Add(ex.Message)
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            tmpchrErrFlg = "Y"
        Finally
            OTDashBoardProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetPtnTypListByUser
    End Function



    Public Shared Function GetArMstDetailsByArCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal ArCd As Integer) As clsArMst

        GetArMstDetailsByArCd = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetArMstDetailsByArCd = SchedulingProxy.GetArMstDetailsByArCd(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, ArCd)
            Return GetArMstDetailsByArCd
        Catch ex As Exception
            SchedulingProxy.Abort()
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetArMstDetailsByArCd


    End Function



    Public Shared Function GetDtlsByFilter(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                          ByRef chrErrFlg As Char,
                                                          ByVal cocd As String,
                                                          ByVal div As Integer,
                                                          ByVal loc As Integer,
                                                          ByVal FrmDt As Date,
                                                          ByVal ToDt As Date,
                                                          ByVal Flg As Char,
                                                          ByVal ApptSts As Int16, ByVal ArCd As String, ByVal OTCd As Integer, ByVal PtnType As Integer, ByVal ChkDtFlg As Boolean) As List(Of clsFCTAPTOT)

        GetDtlsByFilter = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetDtlsByFilter = SchedulingProxy.GetOTDtlsByFilter(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, FrmDt, ToDt, Flg, ApptSts, ArCd, OTCd, PtnType, ChkDtFlg)
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
        Return GetDtlsByFilter
    End Function



    Public Shared Function GetCreditCoListSts(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As List(Of clsArMstCdDcd)

        GetCreditCoListSts = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetCreditCoListSts = SchedulingProxy.GetCreditCoListSts(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc)
            Return GetCreditCoListSts
        Catch ex As Exception
            SchedulingProxy.Abort()
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetCreditCoListSts

    End Function

    'shivkumar 15/11/2021
    Public Shared Function GetUserDetByCD(ByRef strErrMsg As List(Of String),
                                                    ByRef chrErrFlg As Char,
                                                    ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UserId As String) As clsUserDet
        GetUserDetByCD = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetUserDetByCD = SchedulingProxy.GetUserDetByCD(tmpstrErrMsg, tmpchrErrFlg, COCd, Div, Loc, UserId)
            Return GetUserDetByCD
        Catch ex As Exception
            SchedulingProxy.Abort()
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try

        Return GetUserDetByCD

    End Function
    'default set state
    Public Shared Function GetIsBaseStateMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
          ByVal Div As Integer, ByVal Loc As Integer, IsBase As Boolean) As StateMaster
        GetIsBaseStateMst = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetIsBaseStateMst = SchedulingProxy.GetIsBaseStateMst(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc, IsBase)
        Catch ex As Exception
            SchedulingProxy.Abort()
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetIsBaseStateMst
    End Function
    '
    'default set city mumbai
    Public Shared Function GetIsBaseCityMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
          ByVal Div As Integer, ByVal Loc As Integer, IsBase As Boolean) As CityMaster
        GetIsBaseCityMst = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetIsBaseCityMst = SchedulingProxy.GetIsBaseCityMst(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc, IsBase)
        Catch ex As Exception
            SchedulingProxy.Abort()
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetIsBaseCityMst
    End Function
    Public Shared Function SaveOfficePermissionChk(ByRef strErrMsg As System.Collections.Generic.List(Of String), ByRef ChrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal obj As OTSchedulingSerRef.ClsOtIndirectBooking) As Boolean
        SaveOfficePermissionChk = True
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)

        Try
            SchedulingProxy = New iOTSchedulingClient()
            SaveOfficePermissionChk = SchedulingProxy.SaveOfficePermissionChk(strErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, obj)
        Catch ex As Exception
            SchedulingProxy.Abort()
            strErrMsg.Add(ex.Message)
            ChrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                ChrErrFlg = "Y"
            End If
        End Try
        Return SaveOfficePermissionChk
    End Function
    Public Shared Function GetModFnDetails(ByRef strErrMsg As List(Of String),
                                 ByRef chrErrFlg As Char,
                                 ByVal CoCd As String,
                                 ByVal Div As Integer,
                                 ByVal Loc As Integer,
                                 ByVal ModCd As Integer,
                                 ByVal SubModCd As Integer) As List(Of clsUserModuleFunction)
        GetModFnDetails = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetModFnDetails = SchedulingProxy.GetModFnDetails(tmpstrErrMsg, tmpchrErrFlg, CoCd, Div, Loc, ModCd, SubModCd)
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
        Return GetModFnDetails
    End Function


    Public Shared Function GetOTDataForDashBrdSch(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                          ByRef chrErrFlg As Char,
                                                          ByVal cocd As String,
                                                          ByVal div As Integer,
                                                          ByVal loc As Integer,
                                                          ByVal FrmDt As Date,
                                                          ByVal ToDt As Date,
                                                          ByVal Flg As Char,
                                                          ByVal ApptSts As Int16, ByVal ArCd As String, ByVal OTCd As Integer, ByVal PtnType As Integer, ByVal ChkDtFlg As Boolean) As List(Of clsFCTAPTOT) 'Trupti 15 NOV 2022

        GetOTDataForDashBrdSch = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        strErrMsg = New List(Of String)
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetOTDataForDashBrdSch = SchedulingProxy.GetOTDataForDashBrdSch(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, FrmDt, ToDt, Flg, ApptSts, ArCd, OTCd, PtnType, ChkDtFlg)
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
        Return GetOTDataForDashBrdSch
    End Function

    Public Shared Function GetDefaultValues(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                               ByRef chrErrFlg As Char,
                               ByVal pcompanycode As String,
                               ByVal pdiv As Integer,
                               ByVal ploc As Integer, ByVal pUsrId As String) As List(Of clsPtnTypeMst)
        GetDefaultValues = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetDefaultValues = SchedulingProxy.GetVarDef(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, pUsrId)
            Return GetDefaultValues
        Catch ex As Exception
            SchedulingProxy.Abort()
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetDefaultValues
    End Function

    Public Shared Function GetPtnTypByUser(ByRef strErrMsg As List(Of String),
                                              ByRef chrErrFlg As Char,
                                              ByVal cocd As String,
                                              ByVal div As Integer,
                                              ByVal loc As Integer,
                                        ByVal UserId As String,
                                              ByVal ptnno As Long) As List(Of clsPtnTypeMst) '#Trupti 26 JUN 2021
        GetPtnTypByUser = Nothing

        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient()
            GetPtnTypByUser = SchedulingProxy.GetPtnTypByUser(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, UserId, ptnno)
        Catch ex As Exception
            SchedulingProxy.Abort()
            strErrMsg.Add(Replace(ex.Message, "'", ""))
            chrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            Else
                chrErrFlg = "Y"
            End If
        End Try
        Return GetPtnTypByUser
    End Function
End Class
