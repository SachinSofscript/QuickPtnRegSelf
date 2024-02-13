#Region "IMPORTS"
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
#End Region

<DataContract()>
Public Class clsFctAptOtSrv
    'PRAGYA : 11-OCT-2016 : READ DATA FROM FCT_APT_OT_SRV TABLE

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
    Public Property ChrgCd() As Integer
    <DataMember()>
    Public Property SrvCd() As Integer
    <DataMember()>
    Public Property SrvRmrk() As String
    <DataMember()>
    Public Property UserDtTm() As Date
    <DataMember()>
    Public Property UserId() As String

#Region "GetChrgSrvLstOtSch/SpSelFctAptOtSrv : Get the details of FCT_APT_OT_SRV BY PASSING FCTCD/FCTCATCD/FCTMAINCD/APPTNO/PTNNO/IPNO"
    'pragya : 31-oct-2016
    Shared Function GetChrgSrvLstOtSch(ByRef strErrMsg As List(Of String),
                                    ByRef chrErrFlg As Char,
                                    ByVal COCd As String,
                                    ByVal Div As Integer,
                                    ByVal Loc As Integer,
                                    ByVal FctCd As Integer,
                                    ByVal FctCatCd As Integer,
                                    ByVal FctMainCd As Integer,
                                    ByVal ApptNo As Integer,
                                    ByVal PtnNo As Long,
                                    ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of ClsOtSrvLstDtls)
        GetChrgSrvLstOtSch = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFctAptOtSrv(COCd, Div, Loc, FctCd, FctCatCd, FctMainCd, ApptNo, PtnNo, IpNo, IpOpFlag))
            Dim objList As New List(Of ClsOtSrvLstDtls)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsOtSrvLstDtls
                        obj.chrgcd = .item("ChrgCd")
                        obj.ChrgDesc = .item("ChrgDesc")
                        obj.srvcd = .item("SrvCd")
                        obj.srvdesc = .item("SrvDesc")
                        obj.SrvTypCd = .item("SurgTypCd")
                        obj.SrvTypDesc = .item("SurgTypDesc")
                        obj.SrvRate = .item("SrvRate")
                        'obj.SrvParamCd = .item("SrvParamCd")
                        'obj.SrvParamName = .item("SrvParamName")
                        obj.SrvDiagnosis = .item("Diagnosis")
                        obj.AnesTypCd = .item("AnesTypCd")
                        obj.AnesTypDesc = .item("AnesTypDesc")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetChrgSrvLstOtSch = objList
            Return GetChrgSrvLstOtSch
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

    Shared Function SpSelFctAptOtSrv(ByVal companycode As String,
                                     ByVal div As Integer,
                                     ByVal loc As Integer,
                                     ByVal FctCd As Integer,
                                     ByVal FctCatCd As Integer,
                                     ByVal FctMainCd As Integer,
                                     ByVal ApptNo As Integer,
                                     ByVal PtnNo As Long,
                                     ByVal IpNo As Long, ByVal IpOpFlag As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest

            .Command = "[SpSelFctAptOtSrv]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pcocd"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pdivcd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ploccd"
            oParam.ParamValue = loc
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


            oParam = New DBRequest.Parameter
            oParam.ParamName = "IpOpFlag"
            oParam.ParamValue = IpOpFlag
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function


#End Region

End Class



