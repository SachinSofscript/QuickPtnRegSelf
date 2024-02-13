Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports System.Data.SqlClient
Imports SofCommon
<DataContract()>
Public Class clsNetIDParam
    <DataMember()>
    Public Property NetID As Integer
    <DataMember()>
    Public Property ParamID As Integer
    <DataMember()>
    Public Property ParamType As String
    <DataMember()>
    Public Property ParamName As String
    <DataMember()>
    Public Property ParamDescription As String
    <DataMember()>
    Public Property ParamValue As String
    <DataMember()>
    Public Property modcd As Integer
    <DataMember()>
    Public Property submodcd As Integer
    <DataMember()>
    Public Property Isactive As Boolean
    <DataMember()>
    Public Property UsrId As String
    <DataMember()>
    Public Property DateTime As Date
    <DataMember()>
    Public Property VerNo As Integer
    <DataMember()>
    Public Property SubModName As String 'anamika 20160202


    Shared Function SPDELNETIDPARAM(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal paramID As Integer, ByVal NetId As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPDELNETIDPARAM]"
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
            oParam.ParamName = "pModCd"
            oParam.ParamValue = ModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSubModCd"
            oParam.ParamValue = SubModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSubModCd"
            oParam.ParamValue = SubModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pParamID"
            oParam.ParamValue = paramID
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pNetId"
            oParam.ParamValue = NetId
            .Parameters.Add(oParam)


        End With
        Return oRequest
    End Function

    Shared Function SPSELNETIDPARAM(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal NetID As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELNETIDPARAM]"
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
            oParam.ParamName = "pModCd"
            oParam.ParamValue = ModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSubModCd"
            oParam.ParamValue = SubModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pNetId"
            oParam.ParamValue = NetID
            .Parameters.Add(oParam)



        End With
        Return oRequest
    End Function

    Shared Function GetNetIdParamDetails(ByRef strErrMsg As List(Of String), _
                                                   ByRef chrErrFlg As Char, _
                                                   ByVal companycode As String, _
                                                   ByVal div As Integer, _
                                                   ByVal loc As Integer, _
                                                   ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal NetId As Integer) As List(Of clsNetIDParam)
        GetNetIdParamDetails = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELNETIDPARAM(companycode, div, loc, ModCd, SubModCd, NetId))
            Dim objArr As New List(Of clsNetIDParam)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New clsNetIDParam
                        obj.ParamID = .item("ParamID")
                        obj.ParamName = .Item("ParamName")
                        obj.ParamType = .Item("ParamType")
                        obj.ParamValue = .Item("ParamValue")
                        obj.ParamDescription = .Item("ParamDescription")
                        objArr.Add(obj)
                    End With
                End While
            Else
                GetNetIdParamDetails = Nothing
            End If
            dr1.close()
            GetNetIdParamDetails = objArr
            Return GetNetIdParamDetails
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

    Shared Function SPSELNETIDPARAM002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal NetID As Integer, ByVal ParamName As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELNETIDPARAM002]"
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
            oParam.ParamName = "pModCd"
            oParam.ParamValue = ModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSubModCd"
            oParam.ParamValue = SubModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pNetId"
            oParam.ParamValue = NetID
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pParamName"
            oParam.ParamValue = ParamName
            .Parameters.Add(oParam)


        End With
        Return oRequest
    End Function

    Shared Function GetNetIdParamDetailsAgainstModcdSubmodcdParamName(ByRef strErrMsg As List(Of String), _
                                                   ByRef chrErrFlg As Char, _
                                                   ByVal companycode As String, _
                                                   ByVal div As Integer, _
                                                   ByVal loc As Integer, _
                                                    ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal NetID As Integer, ByVal ParamName As String) As List(Of clsNetIDParam)
        GetNetIdParamDetailsAgainstModcdSubmodcdParamName = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELNETIDPARAM002(companycode, div, loc, ModCd, SubModCd, NetID, ParamName))
            Dim objArr As New List(Of clsNetIDParam)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New clsNetIDParam
                        obj.ParamID = .item("ParamID")
                        obj.ParamName = .Item("ParamName")
                        obj.ParamType = .Item("ParamType")
                        obj.ParamValue = .Item("ParamValue")
                        obj.ParamDescription = .Item("ParamDescription")
                        obj.SubModName = .Item("SubModName")
                        obj.modcd = .item("modcd")
                        obj.submodcd = .Item("submodcd")
                        obj.NetID = .Item("NetID")
                        objArr.Add(obj)
                    End With
                End While
            Else
                GetNetIdParamDetailsAgainstModcdSubmodcdParamName = Nothing
            End If
            dr1.close()
            GetNetIdParamDetailsAgainstModcdSubmodcdParamName = objArr
            Return GetNetIdParamDetailsAgainstModcdSubmodcdParamName
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


    Shared Function SPSELNETIDPARAM001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ModCd As Integer, ByVal SubModCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELNETIDPARAM001]"
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
            oParam.ParamName = "pModCd"
            oParam.ParamValue = ModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSubModCd"
            oParam.ParamValue = SubModCd
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
    Shared Function GetNetIdList(ByRef strErrMsg As List(Of String), _
                                               ByRef chrErrFlg As Char, _
                                               ByVal companycode As String, _
                                               ByVal div As Integer, _
                                               ByVal loc As Integer, _
                                               ByVal ModCd As Integer, ByVal SubModCd As Integer) As List(Of NetIdListForSetUp)
        GetNetIdList = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELNETIDPARAM001(companycode, div, loc, ModCd, SubModCd))
            Dim objArr As New List(Of NetIdListForSetUp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New NetIdListForSetUp
                        obj.NetIDList = .item("NetID")
                        objArr.Add(obj)
                    End With
                End While
            Else
                GetNetIdList = Nothing
            End If
            dr1.close()
            GetNetIdList = objArr
            Return GetNetIdList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
End Class
Public Class NetIdListForSetUp
    Inherits clsNetIDParam
    <DataMember()>
    Public Property NetIDList As Integer
End Class