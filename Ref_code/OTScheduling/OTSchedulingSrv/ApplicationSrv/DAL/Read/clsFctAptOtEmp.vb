#Region "IMPORTS"
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
#End Region

'PRAGYA : 01-Dec-2016 : READ DATA FROM FCT_APT_OT_Emp TABLE

<DataContract()>
Public Class clsFctAptOtEmp
    <DataMember()>
    Public Property IpOp() As Char
    <DataMember()>
    Public Property PtnNo() As Long
    <DataMember()>
    Public Property IpNo() As Long
    <DataMember()>
    Public Property FctCatCode() As Integer
    <DataMember()>
    Public Property FctMainCode() As Integer
    <DataMember()>
    Public Property FctCode() As Integer
    <DataMember()>
    Public Property ApptNo() As Integer
    <DataMember()>
    Public Property EmpCd() As String
    <DataMember()>
    Public Property UserDtTm() As Date
    <DataMember()>
    Public Property UserId() As String


#Region "GetLstOtEmpDtlsByApptNoIpNo/SpSelFctAptOtEmp : Get list of FCT_APT_PT_EMP LIST"
    'PRAGYA : 01-Dec-2016
    Shared Function GetLstOtEmpDtlsByApptNoIpNo(ByRef strErrMsg As List(Of String),
                                                 ByRef chrErrFlg As Char,
                                                 ByVal Cocd As String,
                                                 ByVal div As Integer,
                                                 ByVal loc As Integer,
                                                 ByVal FctCd As Integer,
                                                 ByVal FctCatCd As Integer,
                                                 ByVal FctMainCd As Integer,
                                                 ByVal ApptNo As Integer,
                                                 ByVal PtnNo As Long,
                                                 ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of clsFctAptOtEmpDtls)
        Dim ofactory As New DBFactory

        GetLstOtEmpDtlsByApptNoIpNo = Nothing
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFctAptOtEmp(strErrMsg, chrErrFlg, Cocd, div, loc, FctCd, FctCatCd, FctMainCd, ApptNo, PtnNo, IpNo, IpOpFlag))
            Dim arrObjEmpdtl = New List(Of clsFctAptOtEmpDtls)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim objEmp As New clsFctAptOtEmpDtls
                        objEmp.EmpCd = .Item("EmpCd")
                        objEmp.EmpName = .Item("EmpName")
                        'objEmp.Gender = .Item("Gender")
                        'objEmp.DOB = .Item("DOB")

                        arrObjEmpdtl.Add(objEmp)
                    End With
                End While
            End If
            dr1.close()
            GetLstOtEmpDtlsByApptNoIpNo = arrObjEmpdtl
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetLstOtEmpDtlsByApptNoIpNo = Nothing
        Finally
            ofactory = Nothing
        End Try
        Return GetLstOtEmpDtlsByApptNoIpNo

    End Function

    Shared Function SpSelFctAptOtEmp(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                         ByRef chrErrFlg As Char,
                                         ByVal CoCd As String,
                                         ByVal Div As Integer,
                                         ByVal Loc As Integer,
                                         ByVal FctCd As Integer,
                                         ByVal FctCatCd As Integer,
                                         ByVal FctMainCd As Integer,
                                         ByVal ApptNo As Integer,
                                         ByVal PtnNo As Long,
                                         ByVal IpNo As Long, ByVal IpOpFlag As String) As DBRequest

        SpSelFctAptOtEmp = Nothing

        Dim oParam As DBRequest.Parameter
        Try
            Dim oRequest As New DBRequest
            With oRequest
                .Command = "[SpSelFctAptOtEmp]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCOCD"
                oParam.ParamValue = CoCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pdivcd"
                oParam.ParamValue = Div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "ploccd"
                oParam.ParamValue = Loc
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pFctCode"
                oParam.ParamValue = FctCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pFctCatCode"
                oParam.ParamValue = FctCatCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pFctMainCode"
                oParam.ParamValue = FctMainCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pPtnNo"
                oParam.ParamValue = PtnNo
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pIpNo"
                oParam.ParamValue = IpNo
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pApptNo"
                oParam.ParamValue = ApptNo
                .Parameters.Add(oParam)



                '20210809 shital 

                oParam = New DBRequest.Parameter
                oParam.ParamName = "IpOpFlag"
                oParam.ParamValue = IpOpFlag
                .Parameters.Add(oParam)

            End With

            SpSelFctAptOtEmp = oRequest
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpSelFctAptOtEmp = Nothing
        End Try

        Return SpSelFctAptOtEmp

    End Function
#End Region


End Class


#Region "CLASS : clsFctAptOtEmpDtls"
'PRAGYA : 01-dec-2016
Public Class clsFctAptOtEmpDtls
    <DataMember()>
    Public Property EmpCd() As String
    <DataMember()>
    Public Property EmpName() As String
    '<DataMember()>
    'Public Property Gender() As String
    '<DataMember()>
    'Public Property DOB() As DateTime
End Class
#End Region
