Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient

<DataContract()>
Public Class clsUserDetDtls 'RasikV 20161129
    Inherits clsUserDet
    <DataMember()>
    Public Property IsPoUnlimited() As Boolean
    <DataMember()>
    Public Property PoLimitDaily() As Double
    <DataMember()>
    Public Property PoLimitMonthly() As Double
    <DataMember()>
    Public Property PoLimitYearly() As Double
    <DataMember()>
    Public Property UserLevel() As Char
    <DataMember()>
    Public Property LvFlg() As Boolean
    <DataMember()>
    Public Property UserPwd() As String
    <DataMember()>
    Public Property UserPwdExpDt() As Date
    <DataMember()>
    Public Property TmIn() As String
    <DataMember()>
    Public Property TmOut() As String
    <DataMember()>
    Public Property UserAcExpDt() As Date
    <DataMember()>
    Public Property AllowExpiredItem() As Boolean
    <DataMember()>
    Public Property UserDefItemGrpCd() As Integer
    <DataMember()>
    Public Property UserDefItemclsfctnID() As Integer
    <DataMember()>
    Public Property UserDefItemGenCd() As Integer
    <DataMember()>
    Public Property TmAlw() As Date
    <DataMember()>
    Public Property LogInDt() As Integer
    <DataMember()>
    Public Property No() As Integer
    <DataMember()>
    Public Property UserId() As String
    <DataMember()>
    Public Property IsNewRecord() As Boolean  'RasikV 20170227
    <DataMember()>
    Public Property IsHeadCashier() As Boolean  'Pramila 23aug2017
#Region "Get HeadCash UserList"  ''24/08/2017

    Shared Function GetUserNameListOfHeadCashier(strErrMsg As List(Of String), chrErrFlg As Char, COCd As String, Div As Integer, Loc As Integer) As List(Of clsUserBasicDtl)
        GetUserNameListOfHeadCashier = Nothing
        Dim arrobj As New List(Of clsUserBasicDtl)

        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELUSRDET004(COCd, Div, Loc))
            Dim obj As clsUserBasicDtl

            If dr1.hasrows Then

                While dr1.Read()
                    With dr1
                        obj = New clsUserBasicDtl
                        obj.UserId = IIf(IsDBNull(.Item("UserId")), Nothing, .Item("UserId"))
                        obj.UserFullName = IIf(IsDBNull(.Item("UserFullName")), Nothing, .Item("UserFullName"))
                        arrobj.Add(obj)

                    End With
                End While
            End If
            dr1.close()
            GetUserNameListOfHeadCashier = arrobj
            Return GetUserNameListOfHeadCashier
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        Finally
            arrobj = Nothing
        End Try
    End Function
    Shared Function SPSELUSRDET004(ByVal COCD As String, ByVal Div As Integer, ByVal Loc As Integer) As DBRequest   'Amol 20170824
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELUSRDET004]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = COCD
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)


        End With
        Return oRequest
    End Function

#End Region

#Region "GET LIST OF USER ID'S FOR PARTICULAR HEADCASHIER USER"  'RasikV 20170824
    Shared Function FnGetUsrIdsForHdCshUsr(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer) As List(Of String)
        Try
            Dim UsrId As String = Nothing
            Dim ArrUsrId As List(Of String)
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnGetUsrIdsForHdCshUsr] ('" & CoCd & "'," & Div & "," & Loc & ") GetUsrIdsForHdCshUsr"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim Str As String = ds.Tables(0).Rows(0).Item("GetUsrIdsForHdCshUsr")
                Dim StrArr As List(Of String) = Str.Split("|").ToList()
                ArrUsrId = New List(Of String)
                For i = 0 To StrArr.Count - 1
                    UsrId = StrArr(i)
                    ArrUsrId.Add(UsrId)
                Next
                FnGetUsrIdsForHdCshUsr = ArrUsrId
            Else
                FnGetUsrIdsForHdCshUsr = Nothing
            End If
            orequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnGetUsrIdsForHdCshUsr = Nothing
        End Try
        Return FnGetUsrIdsForHdCshUsr
    End Function
#End Region


End Class

<DataContract()>
Public Class clsUserDet  'Neha S.C. 20140228
    <DataMember()>
    Public Property UsrLstNm As String
    <DataMember()>
    Public Property UsrFrstNm As String
    <DataMember()>
    Public Property UsrMidNm As String
    <DataMember()>
    Public Property GrpId As Integer
    <DataMember()>
    Public Property DeptCd As Integer
    <DataMember()>
    Public Property StrCd As Integer
    <DataMember()>
    Public Property StrDcd As String  'anamika 20140701
    <DataMember()>
    Public Property Shft As Integer
    <DataMember()>
    Public Property DocCd As Integer
    <DataMember()>
    Public Property VIPAcc As String
    <DataMember()>
    Public Property UserNickName As String 'anamika 20160129

    <DataMember()>
    Public Property DefPtnTypeCd As Integer

#Region "Get data From usr_det against a usrid  "
    ''' <summary>
    ''' Get data From usr_det against a usrid 
    ''' </summary>
    ''' <param name="COCd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <param name="USRID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Shared Function SPSELUSERDETBYCD(ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal USRID As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELUSERDETBYCD]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = COCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUSRID"
            oParam.ParamValue = USRID
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function

    Shared Function GetUserDetByCD(ByRef strErrMsg As List(Of String), _
                                                    ByRef chrErrFlg As Char, _
                                                    ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal USRID As String) As clsUserDet
        GetUserDetByCD = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELUSERDETBYCD(COCd, Div, Loc, USRID))
            Dim obj As clsUserDet
            If dr1.hasrows Then
                obj = New clsUserDet
                dr1.Read()
                With dr1
                    obj.UsrLstNm = IIf(IsDBNull(.Item("usr_lst_nm")), "", .Item("usr_lst_nm"))
                    obj.UsrFrstNm = IIf(IsDBNull(.Item("usr_frst_nm")), "", .Item("usr_frst_nm"))
                    obj.UsrMidNm = IIf(IsDBNull(.Item("usr_mid_nm")), "", .Item("usr_mid_nm"))
                    obj.GrpId = IIf(IsDBNull(.Item("grp_id")), 0, .Item("grp_id"))
                    obj.DeptCd = IIf(IsDBNull(.Item("dept_cd")), 0, .Item("dept_cd"))
                    obj.StrCd = IIf(IsDBNull(.Item("str_cd")), 0, .Item("str_cd"))
                    obj.StrDcd = IIf(IsDBNull(.Item("str_dcd")), "", .Item("str_dcd")) 'anamika 20140701
                    obj.Shft = IIf(IsDBNull(.Item("shft")), 0, .Item("shft"))
                    obj.DocCd = IIf(IsDBNull(.Item("doc_cd")), 0, .Item("doc_cd"))
                    obj.VIPAcc = IIf(IsDBNull(.Item("VIP_Acc")), "N", .Item("VIP_Acc"))
                    obj.UserNickName = IIf(IsDBNull(.Item("UserNickName")), "", .Item("UserNickName")) 'anamika 20160129
                    obj.DefPtnTypeCd = IIf(IsDBNull(.Item("DefPtnTypeCd")), "", .Item("DefPtnTypeCd"))  'Divya 20201211
                End With
            End If
            dr1.close()
            GetUserDetByCD = obj
            Return GetUserDetByCD
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

#End Region


#Region "Get User Details By User Code"
    '''Get User Details By User Code
    ''' APARNA 16 DEC 2015

    Shared Function SPSELUSRDET(ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal USRID As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELUSRDET]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = COCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUSRID"
            oParam.ParamValue = USRID
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function

    Shared Function GetUserDtlByUserCd(ByRef strErrMsg As List(Of String), _
                                                    ByRef chrErrFlg As Char, _
                                                    ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal USRID As String) As clsUserDtl
        GetUserDtlByUserCd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELUSRDET(COCd, Div, Loc, USRID))
            Dim obj As clsUserDtl
            If dr1.hasrows Then
                obj = New clsUserDtl
                dr1.Read()
                With dr1
                    obj.UserDefItemclsfctnID = IIf(IsDBNull(.Item("UserDefItemclsfctnID")), Nothing, .Item("UserDefItemclsfctnID"))
                    obj.UserDefItemGrpCd = IIf(IsDBNull(.Item("UserDefItemGrpCd")), Nothing, .Item("UserDefItemGrpCd"))
                    obj.UserDefItemGenCd = IIf(IsDBNull(.Item("UserDefItemGenCd")), Nothing, .Item("UserDefItemGenCd"))
                    obj.Strcd = IIf(IsDBNull(.Item("str_cd")), Nothing, .Item("str_cd"))
                End With
            End If
            dr1.close()
            GetUserDtlByUserCd = obj
            Return GetUserDtlByUserCd
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

#End Region


#Region "GET USERID,USERNICKNAME FROM USER DET TABLE"
    Shared Function GetUserBasicDtl(ByRef strErrMsg As List(Of String), _
                                                  ByRef chrErrFlg As Char, _
                                                  ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer) As List(Of clsUserBasicDtl)

        GetUserBasicDtl = Nothing
        Dim arrobj As New List(Of clsUserBasicDtl)

        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELUSRDET001(COCd, Div, Loc))
            Dim obj As clsUserBasicDtl

            If dr1.hasrows Then

                While dr1.Read()
                    With dr1

                        obj = New clsUserBasicDtl
                        obj.UserId = IIf(IsDBNull(.Item("UserId")), Nothing, .Item("UserId"))
                        obj.UserNickName = IIf(IsDBNull(.Item("UserNickName")), Nothing, .Item("UserNickName"))
                        arrobj.Add(obj)

                    End With
                End While
            End If
            dr1.close()
            GetUserBasicDtl = arrobj
            Return GetUserBasicDtl
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        Finally
            arrobj = Nothing
        End Try
    End Function

    Shared Function SPSELUSRDET001(ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELUSRDET001]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = COCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)


        End With
        Return oRequest
    End Function
#End Region

    Shared Function GetUserFullName(ByRef strErrMsg As List(Of String), _
                                                  ByRef chrErrFlg As Char, _
                                                  ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer) As List(Of clsUserBasicDtl) 'Aarti 20161111

        GetUserFullName = Nothing
        Dim arrobj As New List(Of clsUserBasicDtl)

        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELUSRDET002(COCd, Div, Loc))
            Dim obj As clsUserBasicDtl

            If dr1.hasrows Then

                While dr1.Read()
                    With dr1
                        obj = New clsUserBasicDtl
                        obj.UserId = IIf(IsDBNull(.Item("UserId")), Nothing, .Item("UserId"))
                        obj.UserFullName = IIf(IsDBNull(.Item("UserFullName")), Nothing, .Item("UserFullName"))
                        arrobj.Add(obj)

                    End With
                End While
            End If
            dr1.close()
            GetUserFullName = arrobj
            Return GetUserFullName
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        Finally
            arrobj = Nothing
        End Try
    End Function

    Shared Function SPSELUSRDET002(ByVal COCD As String, ByVal Div As Integer, ByVal Loc As Integer) As DBRequest   'Aarti 20161111
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELUSRDET002]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = COCD
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function

#Region "Get User Details With PO Limit" 'RasikV 20161202
    Shared Function GetUserDtlsByCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UserId As String) As clsUserDetDtls
        GetUserDtlsByCd = Nothing
        Try
            Dim StrPwd As String = Nothing
            Dim objDecryptPwd As New SofCommon.Rijndael
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELUSERDETBYCD(CoCd, Div, Loc, UserId))
            Dim obj As clsUserDetDtls = Nothing
            If dr1.hasrows Then
                obj = New clsUserDetDtls
                dr1.Read()
                With dr1
                    obj.UsrLstNm = IIf(IsDBNull(.Item("usr_lst_nm")), "", .Item("usr_lst_nm"))
                    obj.UsrFrstNm = IIf(IsDBNull(.Item("usr_frst_nm")), "", .Item("usr_frst_nm"))
                    obj.UsrMidNm = IIf(IsDBNull(.Item("usr_mid_nm")), "", .Item("usr_mid_nm"))
                    obj.GrpId = IIf(IsDBNull(.Item("grp_id")), 0, .Item("grp_id"))
                    obj.DeptCd = IIf(IsDBNull(.Item("dept_cd")), 0, .Item("dept_cd"))
                    obj.StrCd = IIf(IsDBNull(.Item("str_cd")), 0, .Item("str_cd"))
                    obj.StrDcd = IIf(IsDBNull(.Item("str_dcd")), "", .Item("str_dcd"))
                    obj.Shft = IIf(IsDBNull(.Item("shft")), 0, .Item("shft"))
                    obj.DocCd = IIf(IsDBNull(.Item("doc_cd")), 0, .Item("doc_cd"))
                    obj.VIPAcc = IIf(IsDBNull(.Item("VIP_Acc")), "N", .Item("VIP_Acc"))
                    obj.UserPwdExpDt = IIf(IsDBNull(.Item("pswd_exp")), "", .Item("pswd_exp"))
                    obj.TmIn = IIf(IsDBNull(.Item("TmIn")), "", .Item("TmIn"))
                    obj.TmOut = IIf(IsDBNull(.Item("TmOut")), "", .Item("TmOut"))
                    obj.IsPoUnlimited = IIf(IsDBNull(.Item("IsPoUnlimited")), False, .Item("IsPoUnlimited"))
                    obj.PoLimitDaily = IIf(IsDBNull(.Item("PoLimitDaily")), 0, .Item("PoLimitDaily"))
                    obj.PoLimitMonthly = IIf(IsDBNull(.Item("PoLimitMonthly")), 0, .Item("PoLimitMonthly"))
                    obj.PoLimitYearly = IIf(IsDBNull(.Item("PoLimitYearly")), 0, .Item("PoLimitYearly"))
                    obj.LvFlg = IIf(IsDBNull(.Item("LvFlg")), False, .Item("LvFlg"))
                    obj.UserLevel = IIf(IsDBNull(.Item("UserLevel")), "", .Item("UserLevel"))
                    obj.UserPwd = IIf(IsDBNull(.Item("UserPwd")), "", .Item("UserPwd"))
                    If obj.UserPwd IsNot Nothing Then
                        obj.UserPwd = objDecryptPwd.Decrypt(obj.UserPwd)
                    End If
                    obj.UserNickName = IIf(IsDBNull(.Item("UserNickName")), "", .Item("UserNickName"))                 'Aarti  20171016
                    obj.IsHeadCashier = IIf(IsDBNull(.Item("IsHeadCashier")), 0, .Item("IsHeadCashier")) 'Pramila 23aug2017
                End With
            End If
            dr1.close()
            GetUserDtlsByCd = obj
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetUserDtlsByCd
    End Function
#End Region



    Shared Function GetUserNameList(ByRef strErrMsg As List(Of String), _
                                               ByRef chrErrFlg As Char, _
                                               ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UserName As String) As List(Of clsUserBasicDtl) 'Amol 20170823

        GetUserNameList = Nothing
        Dim arrobj As New List(Of clsUserBasicDtl)

        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELUSRDET003(COCd, Div, Loc, UserName))
            Dim obj As clsUserBasicDtl

            If dr1.hasrows Then

                While dr1.Read()
                    With dr1
                        obj = New clsUserBasicDtl
                        obj.UserId = IIf(IsDBNull(.Item("UserId")), Nothing, .Item("UserId"))
                        obj.UserFullName = IIf(IsDBNull(.Item("UserFullName")), Nothing, .Item("UserFullName"))
                        arrobj.Add(obj)

                    End With
                End While
            End If
            dr1.close()
            GetUserNameList = arrobj
            Return GetUserNameList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        Finally
            arrobj = Nothing
        End Try
    End Function

    Shared Function SPSELUSRDET003(ByVal COCD As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UserName As String) As DBRequest   'Amol 20170823
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELUSRDET003]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = COCD
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserName"
            oParam.ParamValue = UserName
            .Parameters.Add(oParam)



        End With
        Return oRequest
    End Function

#Region "GET DEFAULT USER ASSGINED DOCTOR CODE" 'RasikV 20180113
    Shared Function FnGetDocCdByUsrId(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal UserID As String) As Integer
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnGetDocCdByUsrId]  ('" & CoCd & "', " & Div & ", " & Loc & ", '" & UserID & "') GetDocCdByUsrId"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                FnGetDocCdByUsrId = ds.Tables(0).Rows(0).Item("GetDocCdByUsrId")
            Else
                FnGetDocCdByUsrId = 0
            End If
            orequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnGetDocCdByUsrId = 0
        End Try
        Return FnGetDocCdByUsrId
    End Function
#End Region


#Region "Changes For Get Full Name Of User by Rushikesh 19 oct 2018 "
    Shared Function GetUserFullNameById(ByRef strErrMsg As List(Of String), _
                                                    ByRef chrErrFlg As Char, _
                                                    ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal USRID As String) As String
        GetUserFullNameById = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELUSRDET005(COCd, Div, Loc, USRID))
            Dim StrFullName As String
            If dr1.hasrows Then
                'obj = New String
                dr1.Read()
                With dr1
                    StrFullName = IIf(IsDBNull(.Item("UserFullName")), Nothing, .Item("UserFullName"))
                End With
            End If
            dr1.close()
            GetUserFullNameById = StrFullName
            Return GetUserFullNameById
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function SPSELUSRDET005(ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal USRID As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELUSRDET005]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = COCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUSRID"
            oParam.ParamValue = USRID
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region

End Class
Public Class clsUserDtl 'APARNA 20151217
    <DataMember()>
    Public Property UserDefItemclsfctnID As Integer
    <DataMember()>
    Public Property UserDefItemGrpCd As Integer
    <DataMember()>
    Public Property UserDefItemGenCd As Integer
    <DataMember()>
    Public Property Strcd As Integer
End Class


Public Class clsUserBasicDtl 'aparna 20160624
    <DataMember()>
    Public Property UserId As String
    <DataMember()>
    Public Property UserNickName As String
    <DataMember()>
    Public Property UserFullName As String 'Aarti 20161111
End Class