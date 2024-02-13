Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient

<DataContract()>
Public Class ClsOtIndirectBooking   'RasikV 20160922

    <DataMember()>
    Public Property TrnNo As Integer
    <DataMember()>
    Public Property PtnNo As Long
    <DataMember()>
    Public Property DocCd As Integer
    <DataMember()>
    Public Property Status As Integer
    <DataMember()>
    Public Property ExpectedDate As Date
    <DataMember()>
    Public Property UserDtTm As Date
    <DataMember()>
    Public Property UserId As String
    <DataMember()>
    Public Property IsOfficePrmsnGiven As Boolean   ''Nutan 12 Jan 2022
    <DataMember()>
    Public Property FLG As String  ''Nutan 12 Jan 2022
    <DataMember()>
    Public Property OfficePrmsnByUsrID As String  ''Nutan 12 Jan 2022
    <DataMember()>
    Public Property OfficePrmsnRmrk As String  ''Nutan 12 Jan 2022
    <DataMember()>
    Public Property OfficePrmsnDtTm As DateTime   ''Nutan 12 Jan 2022

    Shared Function GetOtIndirectBookingLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer,
                                            ByVal loc As Integer, ByVal ExpDate As Date, ByVal ToDate As Date) As List(Of ClsOtIndirectBookingLst)

        Try
            GetOtIndirectBookingLst = Nothing
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelOtIndirectBooking(companycode, div, loc, ExpDate, ToDate))
            Dim objPatient As ClsOtIndirectBookingLst = Nothing
            Dim obj As New List(Of ClsOtIndirectBookingLst)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        objPatient = New ClsOtIndirectBookingLst
                        objPatient.TrnNo = dr1.item("ReqNo")
                        objPatient.PtnNo = dr1.Item("PtnNo")
                        objPatient.DocCd = dr1.Item("doccd") 'anamika 20160928
                        objPatient.PtnFullNm = dr1.Item("PatientFullName")
                        objPatient.DocFullNm = dr1.Item("DocFullName")
                        objPatient.Gender = dr1.Item("Gender")
                        objPatient.Age = dr1.item("Age")
                        objPatient.MobNo = dr1.item("MobNo")
                        objPatient.ExpectedDate = IIf(IsDBNull(dr1.item("ExpectedDate")), Date.MinValue, dr1.item("ExpectedDate")) 'anamika 20160928
                        objPatient.IsOfficePrmsnGiven = IIf(IsDBNull(dr1.Item("IsOfficePrmsnGiven")), 0, dr1.Item("IsOfficePrmsnGiven"))   ''Nutan 12 Jan 2022
                        objPatient.OfficePrmsnRmrk = dr1.Item("OfficePrmsnRmrk")
                        obj.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            GetOtIndirectBookingLst = obj
            ofactory = Nothing
        Catch ex As Exception
            GetOtIndirectBookingLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SpSelOtIndirectBooking(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ExpDate As Date, ByVal ToDate As Date) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelOtIndirectBooking]"
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
            oParam.ParamName = "PEXPECTEDDATE"
            oParam.ParamValue = ExpDate
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pToDate"
            oParam.ParamValue = ToDate
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function


    Shared Function GetOtIndirectBookingLst002(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String,
                                            ByVal div As Integer,
                                            ByVal loc As Integer, ByVal IpNo As Long,
                                            ByVal Doccd As Integer, ByVal ExpDate As DateTime) As List(Of ClsOtIndirectBookingLst)  'Aarti 21 Sep 2020

        Try
            GetOtIndirectBookingLst002 = Nothing
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelOtIndirectBooking002(companycode, div, loc, IpNo, Doccd, ExpDate))
            Dim objPatient As ClsOtIndirectBookingLst = Nothing
            Dim obj As New List(Of ClsOtIndirectBookingLst)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        objPatient = New ClsOtIndirectBookingLst
                        objPatient.TrnNo = dr1.item("ReqApptNo")
                        obj.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            GetOtIndirectBookingLst002 = obj
            ofactory = Nothing
        Catch ex As Exception
            GetOtIndirectBookingLst002 = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SpSelOtIndirectBooking002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                           ByVal IPNo As Long, ByVal Doccd As Integer, ByVal ExpDt As DateTime) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelOtIndirectBooking002]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpNo"
            oParam.ParamValue = IPNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "Doccd"
            oParam.ParamValue = Doccd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ExpDt"
            oParam.ParamValue = ExpDt
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function



    ''Amol 07-11-2020 JSK001-147271	
    Shared Function GetIpWiseOtAppList(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer,
                                            ByVal loc As Integer, ByVal IpNo As Long, ByVal ToDate As Date) As List(Of ClsOtIndirectBookingLst)

        Try
            GetIpWiseOtAppList = Nothing
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(GetIpWiseOtAppList(companycode, div, loc, IpNo, ToDate))
            Dim objPatient As ClsOtIndirectBookingLst = Nothing
            Dim obj As New List(Of ClsOtIndirectBookingLst)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        objPatient = New ClsOtIndirectBookingLst
                        objPatient.TrnNo = dr1.item("ReqNo")
                        objPatient.PtnNo = dr1.Item("PtnNo")
                        objPatient.DocCd = dr1.Item("doccd") 'anamika 20160928
                        objPatient.PtnFullNm = dr1.Item("PatientFullName")
                        objPatient.DocFullNm = dr1.Item("DocFullName")
                        objPatient.Title = dr1.Item("Title")
                        objPatient.IsToday = dr1.item("IsToday")
                        objPatient.ExpectedDate = IIf(IsDBNull(dr1.item("ExpectedDate")), Date.MinValue, dr1.item("ExpectedDate")) 'anamika 20160928
                        obj.Add(objPatient)
                    End With
                End While
            End If
            dr1.close()
            GetIpWiseOtAppList = obj
            ofactory = Nothing
        Catch ex As Exception
            GetIpWiseOtAppList = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function GetIpWiseOtAppList(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long, ByVal ToDate As Date) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[GetIpWiseOtAppList]"
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

<DataContract()>
Public Class ClsOtIndirectBookingLst 'RasikV 20160922
    Inherits ClsOtIndirectBooking

    <DataMember()>
    Public Property PtnFullNm() As String
    <DataMember()>
    Public Property DocFullNm() As String 'anamika 20160926
    <DataMember()>
    Public Property Gender() As String
    <DataMember()>
    Public Property Age() As String
    <DataMember()>
    Public Property MobNo() As String
    <DataMember()>
    Public Property Title As String   'pragya : 14-oct-2016
    <DataMember()>
    Public Property ISToday As Boolean   'pragya : 14-oct-2016
    <DataMember()>
    Public Property PtnActualPtnNo() As Long  'pragya : 14-oct-2016
End Class
