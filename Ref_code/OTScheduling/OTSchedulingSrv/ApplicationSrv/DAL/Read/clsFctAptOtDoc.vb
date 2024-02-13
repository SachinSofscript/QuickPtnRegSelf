#Region "IMPORTS"
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
#End Region

<DataContract()>
Public Class clsFctAptOtDoc
    'PRAGYA : 11-OCT-2016 : READ DATA FROM FCT_APT_OT_Doc TABLE

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
    Public Property DocCd() As Integer
    <DataMember()>
      Public Property UserDtTm() As Date
    <DataMember()>
    Public Property UserId() As String
    <DataMember()>
    Public Property SurgnTypCd() As Integer






#Region "GetLstOtDocDtlsByApptNoIpNo/SpSelFctAptOtDoc : return typ : list of clsOtDocDtls"
    'PRAGYA : 15-OCT-2016
    Shared Function GetLstOtDocDtlsByApptNoIpNo(ByRef strErrMsg As List(Of String),
                                                ByRef chrErrFlg As Char,
                                                ByVal COCd As String,
                                                ByVal Div As Integer,
                                                ByVal Loc As Integer,
                                                ByVal FctCd As Integer,
                                                ByVal FctCatCd As Integer,
                                                ByVal FctMainCd As Integer,
                                                ByVal ApptNo As Integer,
                                                ByVal PtnNo As Long,
                                                ByVal IpNo As Long, ByVal IpOpFlag As String) As List(Of clsOtDocDtls)
        GetLstOtDocDtlsByApptNoIpNo = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFctAptOtDoc(COCd, Div, Loc, FctCd, FctCatCd, FctMainCd, ApptNo, PtnNo, IpNo, IpOpFlag))
            Dim objArr As List(Of clsOtDocDtls) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsOtDocDtls)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsOtDocDtls
                        obj.DoctorCode = .item("DocCd")
                        obj.DoctorFullName = .item("DoctorFullName")
                        obj.SpecialityCode = .item("DocSpltyCd")
                        obj.SpecialityCodeDesc = .item("DocSpltyDesc")
                        obj.AnesthesiaCd = .item("ANESTYPCD")
                        obj.AnesthesiaDesc = ""
                        obj.NurseName = .item("NurseName")
                        obj.SurgnTypCd = .item("SurgeonTypeCode")
                        obj.SurgnTypDcd = .item("SurgeonTypeCodeDesc")

                        obj.AnesthesiaTypCd = .item("ANESTYP")

                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetLstOtDocDtlsByApptNoIpNo = objArr
            Return GetLstOtDocDtlsByApptNoIpNo
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function SpSelFctAptOtDoc(ByVal COCd As String,
                                ByVal Div As Integer,
                                ByVal Loc As Integer,
                                ByVal FctCd As Integer,
                                ByVal FctCatCd As Integer,
                                ByVal FctMainCd As Integer,
                                ByVal ApptNo As Integer,
                                ByVal PtnNo As Long,
                                ByVal IpNo As Long, ByVal IpOpFlag As String) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelFctAptOtDoc]"

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
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

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function

#End Region


End Class
