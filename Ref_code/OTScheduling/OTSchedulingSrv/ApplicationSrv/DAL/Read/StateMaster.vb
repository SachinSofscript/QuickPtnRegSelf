Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
<DataContract()>
Public Class StateMaster
    <DataMember()>
    Dim StateName As String
    <DataMember()>
    Dim CountryCd As Integer
    <DataMember()>
    Dim CityName As String
    'shivkumar 15/11/2021
    <DataMember()>
    Dim StateCd As Integer
    <DataMember()>
    Public Property IsActive() As Boolean
    <DataMember()>
    Public Property IsBase() As Boolean




    Shared Function GetStateLst(ByRef strErrMsg As List(Of String),
                                                            ByRef chrErrFlg As Char,
                                                            ByVal Cocd As String,
                                                            ByVal Div As Integer,
                                                            ByVal Loc As Integer,
                                                           ByVal statecd As Integer, ByVal stateName As String) As List(Of StateMaster)
        GetStateLst = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SpSelStateMst008(Cocd, Div, Loc, statecd, stateName))
            Dim ObjStateLst As List(Of StateMaster) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                ObjStateLst = New List(Of StateMaster)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objStateMSt As New StateMaster()
                    objStateMSt.StateName = ds.Tables(0).Rows(i).Item("DispVal").ToString()
                    objStateMSt.CountryCd = Convert.ToInt32(ds.Tables(0).Rows(i).Item("CountryCd").ToString())
                    ObjStateLst.Add(objStateMSt)
                Next

            End If
            ds.Dispose()
            GetStateLst = ObjStateLst
            ofactory = Nothing
        Catch ex As Exception
            GetStateLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try


    End Function

    Shared Function SpSelStateMst008(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal Statecd As Integer, ByVal StateName As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelStateMst008]"

            .CommandType = CommandType.StoredProcedure
            .Transactional = True


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
            oParam.ParamName = "pStateCd"
            oParam.ParamValue = Statecd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "StateName"
            oParam.ParamValue = StateName
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function

    Shared Function GetCityLst(ByRef strErrMsg As List(Of String),
                                                            ByRef chrErrFlg As Char,
                                                            ByVal Cocd As String,
                                                            ByVal Div As Integer,
                                                            ByVal Loc As Integer,
                                                           ByVal Statecd As Integer, ByVal citycd As Integer, ByVal cityname As String) As List(Of StateMaster)
        GetCityLst = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(SpSelCityMst006(Cocd, Div, Loc, Statecd, citycd, cityname))
            Dim ObjStateLst As List(Of StateMaster) = Nothing
            If ds.Tables(0).Rows.Count <> 0 Then
                ObjStateLst = New List(Of StateMaster)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objStateMSt As New StateMaster()
                    objStateMSt.CityName = ds.Tables(0).Rows(i).Item("DispVal").ToString()
                    ObjStateLst.Add(objStateMSt)
                Next

            End If
            ds.Dispose()
            GetCityLst = ObjStateLst
            ofactory = Nothing
        Catch ex As Exception
            GetCityLst = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try


    End Function

    Shared Function SpSelCityMst006(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal Statecd As Integer, ByVal citycd As Integer, ByVal cityname As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelCityMst006]"

            .CommandType = CommandType.StoredProcedure
            .Transactional = True


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
            oParam.ParamName = "pStateCd"
            oParam.ParamValue = Statecd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCityCd"
            oParam.ParamValue = citycd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "CityName"
            oParam.ParamValue = cityname
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function


    'default set state name
#Region "GET IS BASE COUNTRY MASTER DETAILS"
    Shared Function GetIsBaseStateMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, IsBase As Boolean) As StateMaster
        GetIsBaseStateMst = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelStateMst003(CoCd, Div, Loc, IsBase))
            Dim obj As StateMaster
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj = New StateMaster
                        obj.StateCd = IIf(IsDBNull(.Item("StateCd")), 0, .Item("StateCd"))
                        'obj.StateName = IIf(IsDBNull(.Item("StateName")), Nothing, .Item("StateName"))
                        obj.StateName = IIf(IsDBNull(.Item("DispVal")), Nothing, .Item("DispVal"))
                        obj.IsActive = IIf(IsDBNull(.Item("IsActive")), 0, .Item("IsActive"))
                        obj.IsBase = IIf(IsDBNull(.Item("IsBaseState")), 0, .Item("IsBaseState"))
                    End With
                    GetIsBaseStateMst = obj
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetIsBaseStateMst = Nothing
        End Try
        Return GetIsBaseStateMst
    End Function


    Shared Function SpSelStateMst003(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, IsBase As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[dbo].[SpSelStateMst003]"   'sate master
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
            oParam.ParamName = "pIsBase"
            oParam.ParamValue = IsBase
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
#End Region
End Class

