Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient

<DataContract()>
Public Class clsMaster
    <DataMember()>
    Public Property Decode() As String
    <DataMember()>
    Public Property Code() As Integer
    <DataMember()>
    Public Property fromDt() As Date
    <DataMember()>
    Public Property ToDt() As Date
    <DataMember()>
    Public Property Typ() As String
    <DataMember()>
    Public Property data1 As String 'generalized fields
    <DataMember()>
    Public Property data2 As String 'generalized fields
    <DataMember()>
    Public Property data3 As String 'generalized fields








#Region "fct_mst"


    '2013- 06-04
    ''' <summary>
    ''' Select data from fct_mst.doctor code is optional if user provides doctor code then it select data for particular doctor else it will retrieve all the data from fct_mst
    ''' 
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="DoctorCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetFctMstDtlList(ByRef strErrMsg As List(Of String), _
                                                ByRef chrErrFlg As Char, _
                                                ByVal companycode As String, _
                                                ByVal div As Integer, _
                                                ByVal loc As Integer,
                                                Optional ByVal DoctorCd As Integer = 0,
                                                Optional ByVal SpecialityCd As Integer = 0, Optional ByVal CategoryCd As Integer = 0) As List(Of clsMaster)


        Try
            GetFctMstDtlList = Nothing
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTMST(companycode, div, loc, DoctorCd, SpecialityCd, CategoryCd))
            'declared array of class clscodedecode
            Dim objList As List(Of clsMaster) = Nothing
            If dr1.hasrows Then
                objList = New List(Of clsMaster)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsMaster
                        'obj.Code = .Item("DNTMSTCODE")
                        'obj.Decode = .Item("DNTMSTNME")
                        obj.data1 = .item("fct_max_overbook")
                        obj.data2 = .item("fct_slot_prd_hrs")
                        obj.data3 = .item("fct_slot_prd_mins")
                        objList.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetFctMstDtlList = objList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try

    End Function

    Shared Function SPSELFCTMST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal DoctorCd As Integer, ByVal SpecialityCd As Integer, ByVal CategoryCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELFCTMST]" 'fct_mst

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

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctCd"
            oParam.ParamValue = DoctorCd
            .Parameters.Add(oParam)
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctCatCd"
            oParam.ParamValue = CategoryCd
            .Parameters.Add(oParam)
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctMainCd"
            oParam.ParamValue = SpecialityCd
            .Parameters.Add(oParam)
            .CommandType = CommandType.StoredProcedure

        End With
        Return oRequest
    End Function
#End Region


    'anamika 20130801






#Region "get class desc "
    ''' <summary>
    ''' aparna 26 dec 2016
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Shared Function GetPtnClassDescByCd(ByRef strErrMsg As List(Of String), _
                            ByRef chrErrFlg As Char, _
                            ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                            ByVal cd As Integer) As String
        GetPtnClassDescByCd = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .CommandType = CommandType.Text


                .Command = "SELECT dbo.[FnGetClassDesc] (@pCocd ,@pDiv,@pLoc,@pCd)"

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@pCocd"
                oParam.ParamValue = companycode
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@pDiv"
                oParam.ParamValue = div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@pLoc"
                oParam.ParamValue = loc
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@pCd"
                oParam.ParamValue = cd
                .Parameters.Add(oParam)


            End With
            Dim dr As Object = ofactory.ExecuteDataReader(oRequest)

            If dr.hasrows Then
                dr.read()
                GetPtnClassDescByCd = dr.item(0)
            End If
            dr.close()
            oRequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            GetPtnClassDescByCd = ""
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

#End Region


#Region "GET WING MASTER DESCRIPTION BY PASSING WING CODE" 'RasikV 20170202

    Shared Function FnGetWingMstDesc(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal WingCd As Integer) As String
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnGetWingMstDesc]  ('" & CoCd &
                                                  "', " & Div & _
                                                  ", " & Loc & _
                                                  ", " & WingCd & _
                                                  ") GetWingMstDesc "
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                FnGetWingMstDesc = ds.Tables(0).Rows(0).Item("GetWingMstDesc")
            Else
                FnGetWingMstDesc = Nothing
            End If
            orequest = Nothing
            ofactory = Nothing
            Return FnGetWingMstDesc
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnGetWingMstDesc = Nothing
        End Try
    End Function

#End Region
#Region "Chrg_mst with flag"
    ''' <summary>
    ''' aparna 10 apr 2017
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="condition"></param>
    ''' <param name="UserId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetChargeMstWithFlgAndUserId(ByRef strErrMsg As List(Of String), _
                                                  ByRef chrErrFlg As Char, _
                                                  ByVal companycode As String, _
                                                  ByVal div As Integer, _
                                                  ByVal loc As Integer, ByVal condition As String, ByVal UserId As String
                                                 ) As List(Of clsMaster)

        GetChargeMstWithFlgAndUserId = Nothing

        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELCHRGMST023(companycode, div, loc, condition, UserId))
            'declared array of class clscodedecode
            Dim objList As List(Of clsMaster) = Nothing
            If dr1.hasrows Then
                objList = New List(Of clsMaster)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsMaster
                        obj.Code = .Item("chrg_cd")
                        obj.Decode = .Item("chrg_dcd")
                        objList.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetChargeMstWithFlgAndUserId = objList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try

    End Function

    Shared Function SPSELCHRGMST023(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal condition As String, ByVal UserId As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELCHRGMST023]" 'chrg_mst

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

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFLG"
            oParam.ParamValue = condition
            .Parameters.Add(oParam)
            .CommandType = CommandType.StoredProcedure


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)
            .CommandType = CommandType.StoredProcedure
        End With

        Return oRequest
    End Function
#End Region


    '' Amol 2018-09-04
    Public Shared Function CheckCctypeRights(ByRef strErrMsg As List(Of String), _
                                               ByRef chrErrFlg As Char, _
                                               ByVal Cocd As String, _
                                               ByVal Div As Integer, _
                                               ByVal Loc As Integer) As Boolean

        CheckCctypeRights = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .CommandType = CommandType.Text
                .Command = "SELECT [dbo].[FnGetInvCCTypeFlag] (@pCOCD,@pDIV,@pLOC)"

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@pCOCD"
                oParam.ParamValue = Cocd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@pDIV"
                oParam.ParamValue = Div
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "@pLOC"
                oParam.ParamValue = Loc
                .Parameters.Add(oParam)

            End With
            Dim dr As Object = ofactory.ExecuteDataReader(oRequest)

            If dr.hasrows Then
                dr.read()
                CheckCctypeRights = dr.item(0)
            End If
            dr.close()
            oRequest = Nothing
            ofactory = Nothing

        Catch ex As Exception
            CheckCctypeRights = Nothing

            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

        Return CheckCctypeRights
    End Function
    '' Amol 2018-09-04

#Region "GET WHETHER INVENTORY POSTING ON NET RATE BASE OR NOT" 'RasikV 2019011
    Shared Function FnIsCWInvPstOnNetRate(ByRef strErrMsg As List(Of String),
                                        ByRef chrErrFlg As Char,
                                        ByVal CoCd As String,
                                        ByVal Div As Integer,
                                        ByVal Loc As Integer) As Boolean
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnIsCWInvPstOnNetRate]  ('" & CoCd & "', " & Div & ", " & Loc & ") IsCWInvPstOnNetRate"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                FnIsCWInvPstOnNetRate = ds.Tables(0).Rows(0).Item("IsCWInvPstOnNetRate")
            Else
                FnIsCWInvPstOnNetRate = False
            End If
            orequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnIsCWInvPstOnNetRate = False
        End Try
        Return FnIsCWInvPstOnNetRate
    End Function
#End Region

End Class



