Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient


<DataContract()>
Public Class clsUserModuleFunction
    <DataMember()>
    Public Property cocd() As Integer
    <DataMember()>
    Public Property divcd() As Integer
    <DataMember()>
    Public Property loccd() As Integer
    <DataMember()>
    Public Property UserID() As String
    <DataMember()>
    Public Property ModCd() As Integer
    <DataMember()>
    Public Property SubModCd() As Integer
    <DataMember()>
    Public Property FunctionID() As Integer
    <DataMember()>
    Public Property HasRights() As Boolean
    <DataMember()>
    Public Property DisplayOrder() As Integer
    <DataMember()>
    Public Property FunctionName() As String
    <DataMember()>
    Public Property IsActive() As Boolean

    Shared Function spSelModuleFunction(ByVal companycode As String,
                                        ByVal div As Integer,
                                        ByVal loc As Integer,
                                        ByVal ModCd As Integer,
                               ByVal SubModCd As Integer,
                               ByVal FuncID As Integer,
                               ByVal UsrID As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[spSelModuleFunction]"

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
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
            oParam.ParamName = "pFunctionID"
            oParam.ParamValue = FuncID
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserID"
            oParam.ParamValue = UsrID
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With
        Return oRequest
    End Function


    Shared Function GetUserWsModFnDetails(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal companycode As String,
                                        ByVal div As Integer,
                                        ByVal loc As Integer,
                                        ByVal ModCd As Integer,
                                        ByVal SubModCd As Integer,
                                        ByVal FuncID As Integer,
                                        ByVal UsrID As String
                                        ) As clsUserModuleFunction
        GetUserWsModFnDetails = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(spSelModuleFunction(companycode, div, loc, ModCd, SubModCd, FuncID, UsrID))
            Dim obj As clsUserModuleFunction = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    obj = New clsUserModuleFunction
                    obj.ModCd = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("ModCd")), 0, ds.Tables(0).Rows(i).Item("ModCd"))
                    obj.SubModCd = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("SubModCd")), 0, ds.Tables(0).Rows(i).Item("SubModCd"))
                    obj.FunctionID = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("FunctionID")), 0, ds.Tables(0).Rows(i).Item("FunctionID"))
                    obj.FunctionName = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("FunctionName")), Nothing, ds.Tables(0).Rows(i).Item("FunctionName"))
                    obj.DisplayOrder = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("DisplayOrder")), 0, ds.Tables(0).Rows(i).Item("DisplayOrder"))
                    obj.UserID = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("UserID")), Nothing, ds.Tables(0).Rows(i).Item("UserID"))
                    obj.HasRights = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("HasRights")), 0, ds.Tables(0).Rows(i).Item("HasRights"))
                Next
            End If
            ds.Dispose()
            GetUserWsModFnDetails = obj
            ofactory = Nothing
        Catch ex As Exception
            GetUserWsModFnDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function


    Shared Function spSelModuleFunction001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ModCd As Integer,
                               ByVal SubModCd As Integer,
                               ByVal FuncID As Integer,
                               ByVal UsrID As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[spSelModuleFunction001]" 'doc_mst,cd_dcd

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
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
            oParam.ParamName = "pFunctionID"
            oParam.ParamValue = FuncID
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserID"
            oParam.ParamValue = UsrID
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure



        End With

        Return oRequest
    End Function




    Shared Function GetModFncLst(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char,
                                                      ByVal companycode As String,
                                                      ByVal div As Integer,
                                                      ByVal loc As Integer,
                                 ByVal ModCd As Integer,
                                 ByVal SubModCd As Integer,
                                 ByVal FuncID As Integer,
                                 ByVal UsrID As String
                                                     ) As List(Of clsUserModuleFunction)
        GetModFncLst = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(spSelModuleFunction(companycode, div, loc, ModCd, SubModCd, FuncID, UsrID))
            Dim objlist As List(Of clsUserModuleFunction) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                objlist = New List(Of clsUserModuleFunction)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim obj As New clsUserModuleFunction
                    obj.ModCd = ds.Tables(0).Rows(i).Item("ModCd")
                    obj.SubModCd = ds.Tables(0).Rows(i).Item("SubModCd")
                    obj.FunctionID = ds.Tables(0).Rows(i).Item("FunctionID")
                    obj.FunctionName = ds.Tables(0).Rows(i).Item("FunctionName")
                    obj.DisplayOrder = ds.Tables(0).Rows(i).Item("DisplayOrder")
                    obj.UserID = ds.Tables(0).Rows(i).Item("UserID")
                    obj.HasRights = ds.Tables(0).Rows(i).Item("HasRights")

                    objlist.Add(obj)
                Next
            End If
            ds.Dispose()
            GetModFncLst = objlist
            ofactory = Nothing
        Catch ex As Exception
            GetModFncLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    Shared Function spSelModuleFunction004(ByVal companycode As String,
                                        ByVal div As Integer,
                                        ByVal loc As Integer,
                                        ByVal ModCd As Integer,
                               ByVal SubModCd As Integer) As DBRequest  ''Nutan 24 Jan 2022
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[spSelModuleFunction004]"

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
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


    Shared Function GetModFnDetails(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal companycode As String,
                                        ByVal div As Integer,
                                        ByVal loc As Integer,
                                        ByVal ModCd As Integer,
                                        ByVal SubModCd As Integer
                                        ) As List(Of clsUserModuleFunction)  ''Nutan 24 Jan 2022
        GetModFnDetails = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(spSelModuleFunction004(companycode, div, loc, ModCd, SubModCd))
            Dim objlist As List(Of clsUserModuleFunction) = Nothing

            If ds.Tables(0).Rows.Count <> 0 Then
                objlist = New List(Of clsUserModuleFunction)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim obj As New clsUserModuleFunction
                    obj.ModCd = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("ModCd")), 0, ds.Tables(0).Rows(i).Item("ModCd"))
                    obj.SubModCd = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("SubModCd")), 0, ds.Tables(0).Rows(i).Item("SubModCd"))
                    obj.FunctionID = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("FunctionID")), 0, ds.Tables(0).Rows(i).Item("FunctionID"))
                    obj.FunctionName = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("FunctionName")), Nothing, ds.Tables(0).Rows(i).Item("FunctionName"))
                    obj.DisplayOrder = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("DisplayOrder")), 0, ds.Tables(0).Rows(i).Item("DisplayOrder"))
                    obj.IsActive = IIf(IsDBNull(ds.Tables(0).Rows(i).Item("IsActive")), 0, ds.Tables(0).Rows(i).Item("IsActive"))
                    objlist.Add(obj)
                Next
            End If
            ds.Dispose()
            GetModFnDetails = objlist
            ofactory = Nothing
        Catch ex As Exception
            GetModFnDetails = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
End Class
