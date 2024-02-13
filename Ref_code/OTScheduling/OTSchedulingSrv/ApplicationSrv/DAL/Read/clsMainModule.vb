Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract ()>
Public Class clsMainModuleAccess  'Rasikv 20161128
    Inherits clsMainModule
    <DataMember()>
    Public Property ClrCd() As Integer
    <DataMember()>
    Public Property Typ() As Integer
    <DataMember()>
    Public Property Active() As Boolean
    <DataMember()>
    Public Property Access() As Boolean
    <DataMember()>
    Public Property Save() As Boolean
    <DataMember()>
    Public Property Delete() As Boolean
    <DataMember()>
    Public Property Print() As Boolean
    <DataMember()>
    Public Property Auth() As Boolean

End Class

<DataContract()>
Public Class clsMainModule
    <DataMember()>
    Public Property ModCd As Integer
    <DataMember()>
    Public Property ModName As String
    <DataMember()>
    Public Property LangCd As Integer
    <DataMember()>
    Public Property MainMenu As String
    <DataMember()>
    Public Property ActiveFlg As Char
    <DataMember()>
    Public Property IconNo As Integer
    <DataMember()>
    Public Property IconFileName As String 'anamika 20150928
    <DataMember()>
    Public Property AppNo As Integer
    <DataMember()>
    Public Property SubModCd As Integer
    <DataMember()>
    Public Property SubModName As String
    <DataMember()>
    Public Property GroupText As String
    <DataMember()>
    Public Property path As String
    <DataMember()>
    Public Property UserDocCd As Integer = 0 'anamika 20140203
    <DataMember()>
    Public Property Netid As Integer = 0 'anamika 20160202
    <DataMember()>
    Public Property ColorCode As String         'Aarti 20170809
    ''' <summary>
    ''' Get List of All Main Module By User
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="UserId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetMainModuleListByUser(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                       ByVal companycode As String, _
                                                       ByVal div As Integer, _
                                                       ByVal loc As Integer, _
                                                       ByVal UserId As String, _
                                                          ByVal AppNo As Integer, ByVal ShowParameter As Boolean
                                                      ) As List(Of clsMainModule)
        GetMainModuleListByUser = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELMAINMODULEBYUSER(companycode, div, loc, UserId, AppNo, ShowParameter))
            'declared array of class clscodedecode
            Dim objArr As List(Of clsMainModule) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsMainModule)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsMainModule

                        obj.ModCd = .Item("ModCd")
                        obj.ModName = .Item("ModName")
                        obj.LangCd = .item("LangCd")
                        obj.MainMenu = .Item("MainMenu")
                        obj.ActiveFlg = .Item("ActiveFlg")
                        obj.IconNo = .Item("IconNo")
                        obj.AppNo = .Item("APPNO")
                        obj.IconFileName = .Item("IconFileName") 'anamika 20150928
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetMainModuleListByUser = objArr
            Return GetMainModuleListByUser
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Get List of All Main Module By User(usrid)
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="UserId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELMAINMODULEBYUSER(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal Appno As Integer, ByVal ShowParameter As Boolean) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELMAINMODULEBYUSER]"

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
            oParam.ParamName = "PUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAppNo"
            oParam.ParamValue = Appno
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pShowParam"
            oParam.ParamValue = ShowParameter
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function
    ''' <summary>
    ''' 
    ''' select list of submodule by passing userid and modcd
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="UserId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELSUBMODULE(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal ModCd As Integer, ByVal Appno As Integer, ByVal ShowParameter As Boolean) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSUBMODULE]"

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
            oParam.ParamName = "PUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pModCd"
            oParam.ParamValue = ModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pAppNo"
            oParam.ParamValue = Appno
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pShowParam"
            oParam.ParamValue = ShowParameter
            .Parameters.Add(oParam)


            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function
    Shared Function GetSubModuleListByUser(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                       ByVal companycode As String, _
                                                       ByVal div As Integer, _
                                                       ByVal loc As Integer, _
                                                       ByVal UserId As String, _
                                                       ByVal ModCd As Integer, ByVal Appno As Integer, ByVal ShowParameter As Boolean
                                                      ) As List(Of clsMainModule) 'Manisha 20130729
        GetSubModuleListByUser = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSUBMODULE(companycode, div, loc, UserId, ModCd, Appno, ShowParameter))
            'declared array of class clscodedecode
            Dim objArr As List(Of clsMainModule) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsMainModule)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsMainModule

                        obj.ModCd = .Item("ModCd")
                        obj.ModName = .Item("ModName") 'anamika 20151120
                        obj.SubModCd = .Item("SubModCd")
                        obj.SubModName = .item("SubModName")
                        obj.GroupText = .Item("GroupText")
                        obj.path = .Item("path")
                        obj.IconFileName = .Item("IconFileName") 'anamika 20150928
                        obj.AppNo = .Item("APPNO")
                        obj.UserDocCd = 0 ' if user is a doctor then user doctor code else zero anamika 20140203
                        obj.ColorCode = .Item("colorName")          'Aarti 20170809
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetSubModuleListByUser = objArr
            Return GetSubModuleListByUser
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    'anamika 20131126
    Shared Function GetSubModuleTotalCountByUserAppNo(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                       ByVal companycode As String, _
                                                       ByVal div As Integer, _
                                                       ByVal loc As Integer, _
                                                       ByVal UserId As String, _
                                                       ByVal Appno As Integer, ByVal ShowParameter As Boolean
                                                      ) As Integer
        GetSubModuleTotalCountByUserAppNo = 0
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSUBMODULETOTALCOUNT(companycode, div, loc, UserId, Appno, ShowParameter))
            Dim obj As New clsMainModule
            If dr1.hasrows Then

                While dr1.Read()
                    With dr1
                        GetSubModuleTotalCountByUserAppNo = .Item("TotalCount")
                    End With
                End While
            End If
            dr1.close()
            Return GetSubModuleTotalCountByUserAppNo
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Return total count of total module which can accessible by user for particular application
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="UserId"></param>
    ''' <param name="Appno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELSUBMODULETOTALCOUNT(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal Appno As Integer, ByVal ShowParameter As Boolean) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSUBMODULETOTALCOUNT]"

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
            oParam.ParamName = "PUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pAppNo"
            oParam.ParamValue = Appno
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pShowParam"
            oParam.ParamValue = ShowParameter
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function

    'anamika 20131206
    ''' <summary>
    ''' stored procedure returns rights given to submodule
    ''' </summary>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="UserId"></param>
    ''' <param name="ModCd"></param>
    ''' <param name="SubModCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SpSelUsrRights(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal ModCd As Integer, ByVal SubModCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelUsrRights]"

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = cocd
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
            oParam.ParamName = "PUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pModCd"
            oParam.ParamValue = ModCd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSubModCd"
            oParam.ParamValue = SubModCd
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function
    ' end 20131206









#Region "netid parameter functions"

    ''' <summary>
    ''' Select All Main Modules         
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetAllMainModuleList(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                       ByVal companycode As String, _
                                                       ByVal div As Integer, _
                                                       ByVal loc As Integer
                                                      ) As List(Of clsMainModule)
        GetAllMainModuleList = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELMAINMODULE(companycode, div, loc))
            Dim objArr As List(Of clsMainModule) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsMainModule)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsMainModule
                        obj.ModCd = .Item("ModCd")
                        obj.ModName = .Item("ModName")
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetAllMainModuleList = objArr
            Return GetAllMainModuleList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELMAINMODULE(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELMAINMODULE]"

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

            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function


    ''' <summary>
    ''' Select All Sub Modules against ModCd        
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="ModCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELSUBMODULE001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ModCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSUBMODULE001]"

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


            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function


    Shared Function GetSubModuleListByModCd(ByRef strErrMsg As List(Of String), _
                                                     ByRef chrErrFlg As Char, _
                                                     ByVal companycode As String, _
                                                     ByVal div As Integer, _
                                                     ByVal loc As Integer, _
                                                     ByVal ModCd As Integer
                                                    ) As List(Of clsMainModule)
        GetSubModuleListByModCd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSUBMODULE001(companycode, div, loc, ModCd))
            'declared array of class clscodedecode
            Dim objArr As List(Of clsMainModule) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsMainModule)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsMainModule
                        obj.SubModCd = .Item("SubModCd")
                        obj.SubModName = .item("SubModName")
                        obj.path = .Item("path")
                        obj.Netid = .Item("netid")
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetSubModuleListByModCd = objArr
            Return GetSubModuleListByModCd
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function



#End Region



#Region "GetSubModNameBySubModcd" 'Trupti 25 JULY 2016
    Shared Function SPSELSUBMODULE002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ModCd As Integer, ByVal SubModCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSUBMODULE002]"

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


            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function


    Shared Function GetSubModNameBySubModcd(ByRef strErrMsg As List(Of String), _
                                                     ByRef chrErrFlg As Char, _
                                                     ByVal companycode As String, _
                                                     ByVal div As Integer, _
                                                     ByVal loc As Integer, _
                                                     ByVal ModCd As Integer, _
                                                     ByVal SubModCd As Integer
                                                    ) As clsMainModule
        GetSubModNameBySubModcd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSUBMODULE002(companycode, div, loc, ModCd, SubModCd))
            Dim obj As New clsMainModule
            If dr1.hasrows Then
                dr1.read()
                With dr1
                    obj.SubModCd = .Item("SubModCd")
                    obj.SubModName = .item("SubModName")
                    obj.IconFileName = .Item("IconFileName")       ' Aarti 20170729
                End With
            End If
            dr1.close()
            GetSubModNameBySubModcd = obj
            Return GetSubModNameBySubModcd
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


#End Region



#Region "SMS MASTER DATA FOR SMS GRP DTL " ' Trupti 27 JULY 2016
    Shared Function GetAllSmsMstMainModuleList(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                       ByVal companycode As String, _
                                                       ByVal div As Integer, _
                                                       ByVal loc As Integer
                                                      ) As List(Of clsMainModule)
        GetAllSmsMstMainModuleList = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSUBMODULE003(companycode, div, loc))
            Dim objArr As List(Of clsMainModule) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsMainModule)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsMainModule
                        obj.ModCd = .Item("ModCd")
                        obj.ModName = .Item("ModName")
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetAllSmsMstMainModuleList = objArr
            Return GetAllSmsMstMainModuleList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


    Shared Function SPSELSUBMODULE003(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSUBMODULE003]"

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

            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function

    Shared Function GetSmsMstSubModuleListByModCd(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                       ByVal companycode As String, _
                                                       ByVal div As Integer, _
                                                       ByVal loc As Integer, _
                                                       ByVal SubModCd As Integer
                                                      ) As List(Of clsMainModule)
        GetSmsMstSubModuleListByModCd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSUBMODULE004(companycode, div, loc, SubModCd))
            Dim objArr As List(Of clsMainModule) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsMainModule)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsMainModule
                        obj.ModCd = .Item("SubModCd")
                        obj.ModName = .Item("SubModName")
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetSmsMstSubModuleListByModCd = objArr
            Return GetSmsMstSubModuleListByModCd
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


    Shared Function SPSELSUBMODULE004(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal SubModcd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSUBMODULE004]"

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
            oParam.ParamName = "pModcd"
            oParam.ParamValue = SubModcd
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function

#End Region



#Region "Get Modules And User Rights With User Id" 'Rasikv 20161128
    Shared Function GetUserAccessWithUserId(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal UserId As String) As List(Of clsMainModuleAccess)
        GetUserAccessWithUserId = Nothing
        Dim ofactory As New DBFactory
        Dim objList As List(Of clsMainModuleAccess) = Nothing
        Dim obj As clsMainModuleAccess = Nothing
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSelSubModule005(CoCd, Div, Loc, UserId))
            If dr1.hasrows Then
                objList = New List(Of clsMainModuleAccess)
                While dr1.Read()
                    With dr1
                        obj = New clsMainModuleAccess
                        obj.ModCd = IIf(IsDBNull(.Item("MainModuleModCd")), 0, .Item("MainModuleModCd"))
                        obj.ModName = IIf(IsDBNull(.Item("MainModuleModName")), Nothing, .Item("MainModuleModName"))
                        obj.LangCd = IIf(IsDBNull(.Item("MainModuleLangCd")), 0, .Item("MainModuleLangCd"))
                        obj.MainMenu = IIf(IsDBNull(.Item("MainModuleMainMenu")), Nothing, .Item("MainModuleMainMenu"))
                        obj.ActiveFlg = IIf(IsDBNull(.Item("MainModuleActiveFlg")), Nothing, .Item("MainModuleActiveFlg"))
                        obj.IconNo = IIf(IsDBNull(.Item("MainModuleIconNo")), 0, .Item("MainModuleIconNo"))
                        obj.IconFileName = IIf(IsDBNull(.Item("MainModuleIconFileName")), Nothing, .Item("MainModuleIconFileName"))
                        obj.SubModCd = IIf(IsDBNull(.Item("ModuleSubModCd")), 0, .Item("ModuleSubModCd"))
                        obj.SubModName = IIf(IsDBNull(.Item("ModuleSubModName")), Nothing, .Item("ModuleSubModName"))
                        obj.Netid = IIf(IsDBNull(.Item("ModuleNetId")), 0, .Item("ModuleNetId"))
                        obj.Typ = IIf(IsDBNull(.Item("ModuleTyp")), 0, .Item("ModuleTyp"))
                        obj.GroupText = IIf(IsDBNull(.Item("ModuleGroupText")), 0, .Item("ModuleGroupText"))
                        obj.Active = IIf(IsDBNull(.Item("ModuleActive")), 0, .Item("ModuleActive"))
                        obj.Access = IIf(IsDBNull(.Item("Access")), 0, .Item("Access"))
                        obj.Save = IIf(IsDBNull(.Item("Save")), 0, .Item("Save"))
                        obj.Delete = IIf(IsDBNull(.Item("Delete")), 0, .Item("Delete"))
                        obj.Print = IIf(IsDBNull(.Item("Print")), 0, .Item("Print"))
                        obj.Auth = IIf(IsDBNull(.Item("Auth")), 0, .Item("Auth"))
                    End With
                    objList.Add(obj)
                End While
            End If
            dr1.close()
            GetUserAccessWithUserId = objList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetUserAccessWithUserId
    End Function

    Shared Function SPSelSubModule005(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UserId As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSelSubModule005]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
            oParam.ParamValue = CoCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserID"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function
#End Region

#Region "Get Modules And User Rights With Group Code And User Id" 'Rasikv 20161128
    Shared Function GetUserAccessWithGrpCdAndUserId(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal GrpCd As Integer, ByVal UserId As String) As List(Of clsMainModuleAccess)
        GetUserAccessWithGrpCdAndUserId = Nothing
        Dim ofactory As New DBFactory
        Dim objList As List(Of clsMainModuleAccess) = Nothing
        Dim obj As clsMainModuleAccess = Nothing
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSelSubModule006(CoCd, Div, Loc, GrpCd, UserId))
            If dr1.hasrows Then
                objList = New List(Of clsMainModuleAccess)
                While dr1.Read()
                    With dr1
                        obj = New clsMainModuleAccess
                        obj.ClrCd = IIf(IsDBNull(.Item("MainModuleClrCd")), 0, .Item("MainModuleClrCd"))
                        obj.ModCd = IIf(IsDBNull(.Item("MainModuleModCd")), 0, .Item("MainModuleModCd"))
                        obj.ModName = IIf(IsDBNull(.Item("MainModuleModName")), Nothing, .Item("MainModuleModName"))
                        obj.LangCd = IIf(IsDBNull(.Item("MainModuleLangCd")), 0, .Item("MainModuleLangCd"))
                        obj.MainMenu = IIf(IsDBNull(.Item("MainModuleMainMenu")), Nothing, .Item("MainModuleMainMenu"))
                        obj.ActiveFlg = IIf(IsDBNull(.Item("MainModuleActiveFlg")), Nothing, .Item("MainModuleActiveFlg"))
                        obj.IconNo = IIf(IsDBNull(.Item("MainModuleIconNo")), 0, .Item("MainModuleIconNo"))
                        obj.IconFileName = IIf(IsDBNull(.Item("MainModuleIconFileName")), Nothing, .Item("MainModuleIconFileName"))
                        obj.SubModCd = IIf(IsDBNull(.Item("ModuleSubModCd")), 0, .Item("ModuleSubModCd"))
                        obj.SubModName = IIf(IsDBNull(.Item("ModuleSubModName")), Nothing, .Item("ModuleSubModName"))
                        obj.Netid = IIf(IsDBNull(.Item("ModuleNetId")), 0, .Item("ModuleNetId"))
                        obj.Typ = IIf(IsDBNull(.Item("ModuleTyp")), 0, .Item("ModuleTyp"))
                        obj.GroupText = IIf(IsDBNull(.Item("ModuleGroupText")), 0, .Item("ModuleGroupText"))
                        obj.Active = IIf(IsDBNull(.Item("ModuleActive")), 0, .Item("ModuleActive"))
                        obj.Access = IIf(IsDBNull(.Item("Access")), 0, .Item("Access"))
                        obj.Save = IIf(IsDBNull(.Item("Save")), 0, .Item("Save"))
                        obj.Delete = IIf(IsDBNull(.Item("Delete")), 0, .Item("Delete"))
                        obj.Print = IIf(IsDBNull(.Item("Print")), 0, .Item("Print"))
                        obj.Auth = IIf(IsDBNull(.Item("Auth")), 0, .Item("Auth"))
                    End With
                    objList.Add(obj)
                End While
            End If
            dr1.close()
            GetUserAccessWithGrpCdAndUserId = objList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetUserAccessWithGrpCdAndUserId
    End Function

    Shared Function SPSelSubModule006(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal GrpCd As Integer, ByVal UserId As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSelSubModule006]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
            oParam.ParamValue = CoCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pGrpCd"
            oParam.ParamValue = GrpCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserID"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function
#End Region

#Region "Search Module by module name"
    'AARTI BHOPI 20170725

    Shared Function FilterMainModuleListByChar(ByRef strErrMsg As List(Of String), _
                                                           ByRef chrErrFlg As Char, _
                                                           ByVal companycode As String, _
                                                           ByVal div As Integer, _
                                                           ByVal loc As Integer, _
                                                           ByVal UserId As String, _
                                                              ByVal AppNo As Integer, ByVal prefix As String, ByVal IsMaster As Boolean
                                                          ) As List(Of clsMainModule)
        FilterMainModuleListByChar = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(Sp_SearchModNameByChar(companycode, div, loc, UserId, AppNo, prefix, IsMaster))

            Dim objArr As List(Of clsMainModule) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsMainModule)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsMainModule

                        'obj.ModCd = .Item("ModCd")
                        'obj.ModName = .Item("ModName")
                        'obj.LangCd = .item("LangCd")
                        'obj.MainMenu = .Item("MainMenu")
                        'obj.ActiveFlg = .Item("ActiveFlg")
                        'obj.IconNo = .Item("IconNo")
                        'obj.AppNo = .Item("APPNO")
                        'obj.IconFileName = .Item("IconFileName")
                        'obj.SubModCd = .Item("SubModCd")
                        'obj.path = .Item("path")
                        'obj.SubModName = .item("SubModName")
                        'obj.ColorCode = .item("colorName")




                        obj.ModCd = IIf(IsDBNull(.Item("ModCd")), 0, .Item("ModCd"))
                        obj.ModName = IIf(IsDBNull(.Item("ModName")), "", .Item("ModName"))
                        obj.LangCd = IIf(IsDBNull(.Item("LangCd")), 0, .Item("LangCd"))
                        obj.MainMenu = IIf(IsDBNull(.Item("SubModName")), "", .Item("MainMenu"))
                        obj.ActiveFlg = IIf(IsDBNull(.Item("ActiveFlg")), "", .Item("ActiveFlg"))
                        obj.IconNo = IIf(IsDBNull(.Item("IconNo")), 0, .Item("IconNo"))
                        obj.AppNo = IIf(IsDBNull(.Item("APPNO")), 0, .Item("APPNO"))
                        obj.IconFileName = IIf(IsDBNull(.Item("IconFileName")), "", .Item("IconFileName"))
                        obj.SubModCd = IIf(IsDBNull(.Item("SubModCd")), 0, .Item("SubModCd"))
                        obj.path = IIf(IsDBNull(.Item("path")), "", .Item("path"))
                        obj.SubModName = IIf(IsDBNull(.Item("SubModName")), "", .Item("SubModName"))
                        obj.ColorCode = IIf(IsDBNull(.Item("colorName")), "", .Item("colorName"))

                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            FilterMainModuleListByChar = objArr
            Return FilterMainModuleListByChar
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

    Shared Function Sp_SearchModNameByChar(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal Appno As Integer,
                                           ByVal prefix As String, ByVal IsMaster As Boolean) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[Sp_SearchModNameByChar]"

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
            oParam.ParamName = "PUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PAppNo"
            oParam.ParamValue = Appno
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "prefix"
            oParam.ParamValue = prefix
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "IsMaster"
            oParam.ParamValue = IsMaster
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function

#End Region


    <DataContract()>
    Public Enum AccessModCode
        <EnumMember()>
        DoctorsWorkbech = 401
        <EnumMember()>
        ADT = 402
        <EnumMember()>
        InPatientBilling = 403
        <EnumMember()>
        OutPatientBilling = 404
        <EnumMember()>
        EnterpriseScheduling = 405
        <EnumMember()>
        NursingWorkbench = 406 'anamika 20161203
        <EnumMember>
       Issue = 408 'aparna 20160404
        <EnumMember>
        PatientMasterIndex = 409 'pragya : 03-apr-2017
        <EnumMember>
        MASTERLINK = 410 'aparna 20160404
        <EnumMember>
        PurchaseManagement = 412 'aparna 20160404
        <EnumMember>
       Insurance = 427 'Pragya : 11-mar-2017
        <EnumMember()>
        InfoPanel = 434 'anamika 20151127
        <EnumMember()>
     OTScheduling = 439  'RasikV 20180918
        <EnumMember()>
       DoctorsWorkbenchForOutPtn = 440 'anamika 20161203
        <EnumMember()>
     DoctorsWorkbenchForInPtn = 441 'anamika 20161203
        <EnumMember()>
      GatePass = 476  'RasikV 20180618

    End Enum
    Public Enum AccessSubModCd
        <EnumMember()>
     DocWorkBenchForOutPtn = 401
        <EnumMember()>
      DocWorkBenchForInPtn = 402
        <EnumMember()>
       BedTransReq = 403
        <EnumMember()>
       BedTransfer = 404
        <EnumMember()>
       ExchangeOfBed = 405
        <EnumMember()>
       AdmissionFromAllotment = 406
        <EnumMember()>
       DirectAdmission = 407
        <EnumMember()>
       MiscallaneousPayment = 408
        <EnumMember()>
       PostTransForIp = 409
        <EnumMember()>
       OpdAcceptDeposit = 410
        <EnumMember()>
     VisitRegistration = 411
        <EnumMember()>
     OTScheduling = 412
        <EnumMember()>
     DoctorAvailability = 413
        <EnumMember()>
     DoctorScheduling = 414
        <EnumMember()>
     MedicalRecord = 415
        <EnumMember()>
     DischargeSummaryMedRec = 416
        <EnumMember()>
     DoctorsOrders = 417
        <EnumMember()>
     DoctorsAppointment = 418
        <EnumMember()>
     IpReservation = 419
        <EnumMember()>
     IpConcession = 420
        <EnumMember()>
     PostVoucher = 421
        <EnumMember()>
  AllotmentFromreservation = 422
        <EnumMember()>
  IpAcceptDeposit = 423
        <EnumMember()>
    NursingWorkbench = 424
        <EnumMember()>
OpRefundDeposit = 428  'anamika 20151128
        <EnumMember()>
  IpSettlement = 435 'anamika 20161115

        <EnumMember()>
  OpdRefundVocher = 433 'anamika 20151029
        <EnumMember()>
IpCreditCmpnySettlement = 436          'aparna 15 nov 2016
        <EnumMember()>
     OpdSettlement = 437 'anamika 20151128
        <EnumMember()>
OPDCreditSettlement = 438          'aparna 15 nov 2016
        <EnumMember()>
OPDOtherSettlement = 439          'aparna 15 nov 2016
        <EnumMember()>
OPDConcession = 441          'aparna 15 nov 2016
        <EnumMember()>
OPDDoctorSettlement = 442        'aparna 15 nov 2016

        <EnumMember()>
IpOtherSettlement = 443          'aparna 15 nov 2016
        <EnumMember()>
IpDoctorSettlement = 444         'aparna 15 nov 2016
        <EnumMember()>
   DischargeAdvice = 449 'anamika 20140602
        <EnumMember()>
      ReceiptVoucher = 512
        <EnumMember()>
        PaymentVoucher = 513
        <EnumMember()>
               JournalVoucher = 514
        <EnumMember()>
  QuickRegistration = 527 'anamika 20151110
        <EnumMember()>
    InfoPanel = 528 'anamika 20151127
        <EnumMember>
   NewIndent = 539 'aparna 20160404
        <EnumMember>
       ViewIndent = 540 'aparna 20160404
        <EnumMember>
       EditIndent = 541 'aparna 20160404
        <EnumMember>
       OpenIndent = 542 'aparna 20160404
        <EnumMember>
       CloseIndent = 543 'aparna 20160404
        <EnumMember>
       CancelIndent = 544 'aparna 20160404
        <EnumMember>
      AuthoriseIndent = 545 'aparna 20160404
        <EnumMember>
              NewPo = 546 'aparna 20160404
        <EnumMember>
       PrintPo = 547 'aparna 20160404
        <EnumMember>
       ViewPo = 548 'aparna 20160404
        <EnumMember>
       AuthorisePo = 549 'aparna 20160404
        <EnumMember>
       ClosePo = 550 'aparna 20160404
        <EnumMember>
       CancelPo = 551 'aparna 20160404
        <EnumMember>
      EditPo = 552 'aparna 20160404
        <EnumMember>
       DirectReceipt = 457 'aparna 20160404
        <EnumMember>
       PurchaseOrder = 490  'PRAGYA :27-OCT-2016
        <EnumMember()>
       InsRegistration = 553  'Aarti : 28-mar-2017
        <EnumMember()>
       InsApplication = 554   'Aarti : 28-mar-2017
        <EnumMember()>
      InsApproval = 556   'Aarti : 28-mar-2017
        <EnumMember>
        PurchasePointMaster = 558 'aparna 20160404
        <EnumMember>
       SupplierItemLinkMaster = 559 'aparna 20160404
        <EnumMember>
       AlternativeDrugsMaster = 560 'aparna 20160404
        <EnumMember()>
InsClaim = 570   'Aarti : 28-mar-2017
        <EnumMember()>
   InsQueries = 571   'Pragya : 01-nov-2017
        <EnumMember()>
   InsApprovalDenial = 579   'Pragya : 01-nov-2017
        <EnumMember>
       CostCentreWeakerSectionLink = 561 'aparna 20160404
        <EnumMember>
       LinkAItem = 562 'aparna 20160404
        <EnumMember>
       FractionQuantityParameters = 563 'aparna 20160404
        <EnumMember>
       Issue = 564 'aparna 20160404
        <EnumMember>
       IssueReturns = 565 'aparna 20160404
        <EnumMember>
       IntraStoreIssue = 566 'aparna 20160404
        <EnumMember>
       IntraStoreReceipt = 567 'aparna 20160404
        <EnumMember>
       IntraStoreIssueReturn = 568 'aparna 20160404
        <EnumMember()>
     AdmFrmReservation = 628 'pragya 20160830
        <EnumMember()>
    GrnFromRfndblItem = 639 'anamika  20161026
        <EnumMember()>
PORateContract = 641  'PRAGYA  : 03-NOV-2016
        <EnumMember()>
DietDashBoard = 674  'Pramila 9Jan2017
        <EnumMember()>
AmendPO = 679  'PRAGYA  : 02-feb-2017
        <EnumMember()>
    NewPORateContract = 680  'PRAGYA  : 02-feb-2017
        <EnumMember()>
    ViewPORateContract = 681  'PRAGYA  : 02-feb-2017
        <EnumMember()>
    EditPORateContract = 682  'PRAGYA  : 02-feb-2017
        <EnumMember()>
    CancelPORateContract = 683  'PRAGYA  : 02-feb-2017
        <EnumMember()>
    AuthorisePORateContract = 684  'PRAGYA  : 02-feb-2017
        <EnumMember()>
    ClosePORateContract = 685  'PRAGYA  : 02-feb-2017
        <EnumMember()>
    AmendPORateContract = 686  'PRAGYA  : 02-feb-2017
        <EnumMember()>
    PrintPORateContract = 687  'PRAGYA  : 02-feb-2017
        <EnumMember()>
  InsBillForwarding = 699  'PRAGYA  : 11-mar-2017
        <EnumMember()>
       InsReports = 701  'Aarti : 28-mar-2017
        <EnumMember()>
   ConfirmEnqForPtn = 703  'pragya : 03-apr-2017
        <EnumMember()>
 PrintIndent = 716  'aparna : 23 may 2017
        <EnumMember()>
PatientFollowUp = 717  'aparna : 27 may 2017
        <EnumMember()>
        POSTDISCHARGE = 723  'amol 20170609
        'RasikV 20171219 - Start Here
        <EnumMember()>
PharmaSettlement = 743  'aparna : 25 jan 2018
        <EnumMember()>
PharmaConcession = 744  'aparna : 25 jan 2018
        <EnumMember()>
        IssueInPatientCredit = 765
        <EnumMember()>
        IssueInPatientCash = 766
        <EnumMember()>
        IssueOutPatientCredit = 767
        <EnumMember()>
        IssueOutPatientCash = 768
        <EnumMember()>
        IssueWards = 769
        <EnumMember()>
        IssueDepartments = 770
        <EnumMember()>
        IssueDoctors = 771
        <EnumMember()>
        IssueSale = 772
        <EnumMember()>
       INTRASTORESTOCKTRANSFER = 773
        <EnumMember()>
       STOCKTAKER = 774
        'RasikV 20171219 - End Here
        <EnumMember()>
      IssueReturnInPatientCredit = 775
        <EnumMember()>
     IssueReturnInPatientCash = 776
        <EnumMember()>
    IssueReturnOutPatientCredit = 777
        <EnumMember()>
IssueReturnOutPatientCash = 778
        <EnumMember()>
IssueReturnWards = 779
        <EnumMember()>
IssueReturnDepartments = 780
        <EnumMember()>
IssueReturnDoctors = 781
        <EnumMember()>
IssueReturnSale = 782
        <EnumMember()>
INTRASTORESTOCKRETURN = 783
        <EnumMember()>
AcknowledgeOPDocVisit = 785  'RASIK 9 FEB 2018
        <EnumMember()>
VisitTokenNoDisplay = 786 'RASIK 9 FEB 2018
        <EnumMember()>
DIRECTINTRASTOREISSUE = 787 ''AMOL 16 FEB 2018
        <EnumMember()>
PharmacyOutPtnCrdStmnt = 789 ''Pragya : 26-feb-2018

        'RasikV 20180618 - Start Here
        <EnumMember()>
        GatePass = 816
        <EnumMember()>
        GatePassNew = 817
        <EnumMember()>
        GatePassEdit = 818
        <EnumMember()>
        GatePassView = 819
        <EnumMember()>
        GatePassCancel = 820
        <EnumMember()>
        GatePassAuthorise = 821
        <EnumMember()>
        GatePassClose = 822
        <EnumMember()>
        GatePassAccept = 823
        <EnumMember()>
        GatePassReturn = 824
        <EnumMember()>
        GatePassReturnedAccepted = 825
        <EnumMember()>
      GatePassAmendment = 827
        'RasikV 20180618 - End Here

        <EnumMember()>
       ReceiptVoucherAuthAndPosting = 847
        <EnumMember()>
        PaymentVoucherAuthAndPosting = 848

        <EnumMember()>
        JournalVoucherAuthAndPosting = 849
        <EnumMember()>
      OPDDirectConcession = 863  'RasikV 20181225
        <EnumMember()>
        OPDConcessionByRequest = 864  'RasikV 20181225
    End Enum


#Region "ENUM : EnumSmsInternal"
    '18-apr-2018
    Public Enum EnumSmsInternal
        <EnumMember>
        OtherHardcoded = 99  '(internally it wl send to ptn / doc - in Admission)
        <EnumMember>
        IPPatient = 1
        <EnumMember>
        OPPatient = 2
        <EnumMember>
        Doctor = 3
        <EnumMember>
      MaintenanceTracker = 51  'RasikV 20180604
        <EnumMember>
 OtScheduling = 52  'RasikV 20180918
    End Enum
#End Region

End Class


'Public Enum EnumSubModCd  'commented by anamika  on 20160203
'    <EnumMember()>
' VisitRegistration = 411
'    <EnumMember()>
' PostVoucher = 421


'End Enum




