
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsRuleMaster

    '<DataMember()>  commented by Neha
    'Public Property CompanyCode As String
    '<DataMember()>
    'Public Property DivisionCode As Integer
    '<DataMember()>
    'Public Property LocationCode As Integer

    <DataMember()>
    Public Property Data1 As String

    'Neha S.C 20140214
    <DataMember()>
    Public Property RuleID As Integer
    <DataMember()>
    Public Property RuleName As String
    <DataMember()>
    Public Property Data2 As String
    <DataMember()>
    Public Property DetFlag As String
    <DataMember()>
    Public Property Desciption As String
    'end of code  Neha S.C 20140214



    'Neha S.C. 20140214
    ' ''' <summary>
    ' ''' 
    ' ''' </summary>
    ' ''' <param name="strErrMsg"></param>
    ' ''' <param name="chrErrFlg"></param>
    ' ''' <param name="companycode"></param>
    ' ''' <param name="div"></param>
    ' ''' <param name="loc"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>

    'Shared Function GetruleMasterDtls(ByRef strErrMsg As List(Of String), _
    '                                                ByRef chrErrFlg As Char, _
    '                                                ByVal companycode As String, _
    '                                                ByVal div As Integer, _
    '                                                ByVal loc As Integer
    '                                               ) As List(Of clsRuleMaster)

    '    GetruleMasterDtls = Nothing

    '    Try
    '        Dim ofactory As New DBFactory

    '        Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELRULEMST(companycode, div, loc))
    '        'declared array of class clscodedecode
    '        Dim objClncList As List(Of clsRuleMaster) = Nothing
    '        If dr1.hasrows Then
    '            objClncList = New List(Of clsRuleMaster)
    '            While dr1.Read()
    '                With dr1
    '                    Dim obj As New clsRuleMaster
    '                    obj.Data1 = .Item("clnc_cd")
    '                    objClncList.Add(obj)
    '                End With
    '            End While
    '        End If
    '        dr1.close()
    '        GetruleMasterDtls = objClncList
    '        ofactory = Nothing
    '    Catch ex As Exception
    '        strErrMsg.Add(ex.Message)
    '        chrErrFlg = "Y"
    '        Return Nothing
    '    End Try

    'End Function

    Shared Function GetRuleMstDtls(ByRef strErrMsg As List(Of String), _
                                                     ByRef chrErrFlg As Char, _
                                                     ByVal companycode As String, _
                                                     ByVal div As Integer, _
                                                     ByVal loc As Integer, _
                                                     ByVal RuleId As Integer) As clsRuleMaster 'Neha S.C 20140214


        GetRuleMstDtls = Nothing

        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELRULEMST(companycode, div, loc, RuleId))
            'declared array of class clsRuleMaster
            Dim objRuleMst As clsRuleMaster = Nothing
            objRuleMst = New clsRuleMaster

            If dr1.hasrows Then
                While dr1.Read()
                    With dr1

                        objRuleMst.RuleID = IIf(IsDBNull(.Item("RuleID")), Nothing, .Item("RuleID"))
                        objRuleMst.RuleName = IIf(IsDBNull(.Item("RuleName")), Nothing, .Item("RuleName"))
                        objRuleMst.Data1 = IIf(IsDBNull(.Item("Data1")), Nothing, .Item("Data1"))
                        objRuleMst.Data2 = IIf(IsDBNull(.Item("Data2")), Nothing, .Item("Data2"))
                        objRuleMst.DetFlag = IIf(IsDBNull(.Item("DetFlag")), Nothing, .Item("DetFlag"))
                        objRuleMst.Desciption = IIf(IsDBNull(.Item("Desciption")), Nothing, .Item("Desciption"))

                    End With
                End While
            Else
                objRuleMst = Nothing
            End If
            dr1.close()
            GetRuleMstDtls = objRuleMst
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try

    End Function

    'end of Code Neha S.C. 20140214

    Shared Function SPSELRULEMST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal RuleId As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELRULEMST]"

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


            oParam = New DBRequest.Parameter 'Neha S.C. 20140214
            oParam.ParamName = "pRuleId"
            oParam.ParamValue = RuleId
            .Parameters.Add(oParam)


            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function



#Region "TO CHECK WHETHER ISSUE RETURN VOUCHER SHOW [SHOW UN-SETTLED ISSUE RETURN ON SETTLEMENT SCREEN"  'RasikV 20170117
    Shared Function FnChkIssRetVchrShow(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal RuleId As Integer) As Boolean
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnChkIssRetVchrShow]  ('" & CoCd & "','" & Div & "','" & Loc & "','" & RuleId & "') IsChkIssRetVchrShow"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                FnChkIssRetVchrShow = ds.Tables(0).Rows(0).Item("IsChkIssRetVchrShow")
            Else
                FnChkIssRetVchrShow = Nothing
            End If
            orequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnChkIssRetVchrShow = False
        End Try
        Return FnChkIssRetVchrShow
    End Function
#End Region




End Class
