Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon

<DataContract()>
Public Class CityMaster

    'shivkumar 15/11/2021
    <DataMember()>
    Dim CityCd As Integer
    <DataMember()>
    Dim CityName As String
    <DataMember()>
    Public Property IsActive() As Boolean
    <DataMember()>
    Public Property IsBase() As Boolean
    <DataMember()>
    Dim StateCd As Integer
    <DataMember()>
    Public Property IsBaseCity() As Boolean



#Region "GET IS BASE CITY MASTER DETAILS"
    Shared Function GetIsBaseCityMst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal IsBase As Boolean) As CityMaster
        GetIsBaseCityMst = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelCityMst003(CoCd, Div, Loc, IsBase))
            Dim obj As CityMaster
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj = New CityMaster
                        'obj.CityCd = IIf(IsDBNull(.Item("CityCd")), 0, .Item("CityCd"))
                        'obj.CityName = IIf(IsDBNull(.Item("CityName")), Nothing, .Item("CityName"))
                        obj.CityName = IIf(IsDBNull(.Item("DispVal")), Nothing, .Item("DispVal"))
                        obj.StateCd = IIf(IsDBNull(.Item("StateCd")), 0, .Item("StateCd"))
                        obj.IsActive = IIf(IsDBNull(.Item("IsActive")), 0, .Item("IsActive"))
                        obj.IsBaseCity = IIf(IsDBNull(.Item("IsBaseCity")), 0, .Item("IsBaseCity"))
                    End With
                    GetIsBaseCityMst = obj
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetIsBaseCityMst = Nothing
        End Try
        Return GetIsBaseCityMst
    End Function

    Shared Function SpSelCityMst003(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal IsBase As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[dbo].[SpSelCityMst003]"   'CityMaster, StateMaster, CountryMaster
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
