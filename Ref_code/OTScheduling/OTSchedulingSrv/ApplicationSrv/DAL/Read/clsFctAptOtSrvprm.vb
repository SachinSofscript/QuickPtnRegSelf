#Region "IMPORTS"
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
#End Region

<DataContract()>
Public Class clsFctAptOtSrvprm
    'PRAGYA : 11-OCT-2016 : READ DATA FROM FCT_APT_OT_SRVPRM TABLE
    <DataMember()>
    Public Property ChrgCd() As Integer
    <DataMember()>
    Public Property SrvCd() As Integer
    <DataMember()>
    Public Property SrNo() As Integer
    <DataMember()>
    Public Property ParamNm() As String


#Region "GetLstOtSrvPrmNm / SpSelFctAptOtSrvprm : Get the list of SrvLstParam"
    'PRAGYA : 11-OCT-2016
    Shared Function GetLstOtSrvPrmNm(ByRef StrErrMsgs As List(Of String), _
                                       ByRef chrErrFlg As Char, _
                                        ByVal companycode As String, _
                                        ByVal div As Integer, _
                                        ByVal loc As Integer,
                                        ByVal ChrgCd As Integer,
                                        ByVal SrvCd As Integer) As List(Of clsFctAptOtSrvprm)

        GetLstOtSrvPrmNm = Nothing
        Dim arrobj As New List(Of clsFctAptOtSrvprm)
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(clsFctAptOtSrvprm.SpSelFctAptOtSrvprm(companycode, div, loc, ChrgCd, SrvCd))
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New clsFctAptOtSrvprm
                        obj.SrNo = .item("cd")
                        obj.ParamNm = .item("dcd")
                        arrobj.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetLstOtSrvPrmNm = arrobj
            ofactory = Nothing
        Catch ex As Exception
            GetLstOtSrvPrmNm = Nothing
            StrErrMsgs.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SpSelFctAptOtSrvprm(ByVal companycode As String,
                                        ByVal div As Integer,
                                        ByVal loc As Integer,
                                        ByVal ChrgCd As Integer,
                                        ByVal SrvCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelFctAptOtSrvprm]" '
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

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
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = ChrgCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSrvCd"
            oParam.ParamValue = SrvCd
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
#End Region


End Class
