Imports OTScheduling.OTSchedulingSerRef

Public Class PatientHelp
#Region "Added by Farid 02-may-2017 for Pagging"
    Public Shared SchedulingProxy As iOTSchedulingClient

    Public Shared Function PatientHelpMst(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal companycode As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer, ByVal FirstNm As String,
                                              ByVal MiddleNm As String, ByVal LastNm As String,
                                              ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer,
                                               ByVal AdharNo As String, ByVal PanNo As String, ByVal Address As String, ByVal FathersName As String) As List(Of clsPatientHelp)
        Try
            PatientHelpMst = Nothing
            Dim tmpstrErrMsg As New List(Of String)
            Dim tmpchrErrFlg As Char = "N"
            SchedulingProxy = New iOTSchedulingClient
            PatientHelpMst = SchedulingProxy.PatientHelpMst(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria, Pageindex, PageSize, AdharNo, PanNo, Address, FathersName)
            '  Return PatientHelpMst 
        Catch ex As Exception
            SchedulingProxy.Abort()
            PatientHelpMst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If chrErrFlg = "Y" And strErrMsg.ToArray.Count <> 1 Then
                strErrMsg.AddRange(strErrMsg.ToArray)
                chrErrFlg = "Y"
            End If
        End Try
        Return PatientHelpMst
    End Function

    Public Shared Function PatientHelpListMst(ByRef strErrMsg As List(Of String),
                                               ByRef chrErrFlg As Char,
                                               ByVal companycode As String,
                                               ByVal div As Integer,
                                               ByVal loc As Integer, ByVal FirstNm As String,
                                              ByVal MiddleNm As String, ByVal LastNm As String,
                                              ByVal AdditionalCriteria As String, ByVal Pageindex As Integer, ByVal PageSize As Integer,
                                               ByVal AdharNo As String, ByVal PanNo As String, ByVal Address As String) As List(Of clsPatientHelp)
        Try
            PatientHelpListMst = Nothing
            Dim tmpstrErrMsg As New List(Of String)
            Dim tmpchrErrFlg As Char = "N"
            SchedulingProxy = New iOTSchedulingClient
            PatientHelpListMst = SchedulingProxy.PatientHelpListMst(tmpstrErrMsg, tmpchrErrFlg, companycode, div, loc, FirstNm, MiddleNm, LastNm, AdditionalCriteria, Pageindex, PageSize, AdharNo, PanNo, Address)
            'Return PatientHelpListMst
        Catch ex As Exception
            SchedulingProxy.Abort()
            PatientHelpListMst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If chrErrFlg = "Y" And strErrMsg.ToArray.Count <> 1 Then
                strErrMsg.AddRange(strErrMsg.ToArray)
                chrErrFlg = "Y"
            End If
        End Try
        Return PatientHelpListMst
    End Function


    Public Shared Function PopulatePager(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal recordCount As Integer, ByVal currentPage As Integer, ByVal DispNum As Integer, ByVal GridType As Char, ByVal Repeater As List(Of clsPaging), ByVal ItemCd As String, ByRef ReturnPageIndex As Integer, ByVal PageSize As Integer) As List(Of clsPaging)
        PopulatePager = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SchedulingProxy = New iOTSchedulingClient
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

#End Region

    Public Shared Function setproperties(ByVal strErrMsg As List(Of String), ByVal chrErrFlg As Char, ByVal Cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal objRuleMst As clsRuleMaster) As List(Of ClsPtnDtlsSetup)

        Dim clsproperty As New List(Of ClsPtnDtlsSetup)
        Dim tmpstrErrMsg As New List(Of String)()
        Dim tmpchrErrFlg As Char = Convert.ToChar("N")
        Try
            SchedulingProxy = New iOTSchedulingClient
            clsproperty = SchedulingProxy.setproperties(tmpstrErrMsg, tmpchrErrFlg, Cocd, div, loc, objRuleMst)
        Catch
            SchedulingProxy.Abort()
        Finally
            SchedulingProxy.Close()
            If chrErrFlg = Convert.ToChar("Y") Then
                If strErrMsg.Count > 0 Then
                    strErrMsg.AddRange(strErrMsg)
                    chrErrFlg = Convert.ToChar("Y")
                End If
            End If
        End Try
        setproperties = clsproperty
        Return setproperties
    End Function


    Public Shared Function GetPatientDetails(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                          ByRef chrErrFlg As Char,
                                          ByVal pcompanycode As String,
                                          ByVal pdiv As Integer,
                                          ByVal ploc As Integer,
                                          ByVal pptnno As Long) As PatientDetails
        GetPatientDetails = Nothing
        Try
            SchedulingProxy = New iOTSchedulingClient
            GetPatientDetails = SchedulingProxy.GetPatientDetails(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, pptnno)
        Catch ex As Exception
            SchedulingProxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            SchedulingProxy.Close()
            If chrErrFlg = "Y" And strErrMsg.Count <> 1 Then
                strErrMsg.AddRange(strErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetPatientDetails
    End Function

End Class
