Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
<DataContract()>
Public Class clsPtnTypeMst

    <DataMember()>
    Public Property PtnTypCd() As Integer
    <DataMember()>
    Public Property PtnTypDesc() As String
    <DataMember()>
    Public Property DefConcTypCd() As Integer
    <DataMember()>
    Public Property AllowedSelectedAr() As Integer
    <DataMember()>
    Public Property IsActive() As Boolean
    <DataMember()>
    Public Property CSHDEPTCD() As Integer
    <DataMember()>
    Public Property WINGCD() As Integer
    <DataMember()>
    Public Property PTNCLSCD() As Integer
    <DataMember()>
    Public Property VCHCHRGCD() As Integer
    <DataMember()>
    Public Property USRID() As String
    <DataMember()>
    Public Property CASH() As String
    <DataMember()>
    Public Property CREDIT() As String
    <DataMember()>
    Public Property FREE() As String
    <DataMember()>
    Public Property REFUND() As String
    <DataMember()>
    Public Property CONC() As String
    <DataMember()>
    Public Property CODE() As Integer
    <DataMember()>
    Public Property DECODE() As String

    <DataMember()>
    Public Property CSHDEPTDesc() As String
    <DataMember()>
    Public Property WINGDesc() As String
    <DataMember()>
    Public Property VCHCHRGDesc() As String
    <DataMember()>
    Public Property PTNCLSDesc() As String

    <DataMember()>
    Public Property IsNewRecord() As Boolean

    <DataMember()>
    Public Property addinfo1 As String

    Shared Function GetPtnType(ByRef strErrMsg As List(Of String),
                                                            ByRef chrErrFlg As Char,
                                                            ByVal Cocd As String,
                                                            ByVal Div As Integer,
                                                            ByVal Loc As Integer,
                                                           ByVal pPtnBillTyp As Integer) As List(Of clsPtnTypeMst)
        GetPtnType = Nothing
        Try

            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELPTNTYPEMST001(Cocd, Div, Loc, pPtnBillTyp))
            Dim objPatientlist As List(Of clsPtnTypeMst) = Nothing
            If dr1.hasrows Then
                objPatientlist = New List(Of clsPtnTypeMst)
                While dr1.read()
                    Dim objPatient As New clsPtnTypeMst
                    objPatient.PtnTypCd = dr1.Item("PtnTypCd")
                    objPatient.PtnTypDesc = dr1.Item("PtnTypDesc")

                    objPatient.DefConcTypCd = dr1.Item("DefConcTypCd")
                    objPatient.AllowedSelectedAr = dr1.Item("AllowedSelectedAr")
                    objPatient.IsActive = dr1.Item("IsActive")
                    objPatientlist.Add(objPatient)
                End While
            End If
            dr1.close()
            GetPtnType = objPatientlist

            ofactory = Nothing
        Catch ex As Exception
            GetPtnType = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function GetPtnTypByUser(ByRef strErrMsg As List(Of String),
                               ByRef chrErrFlg As Char, ByVal Cocd As String, ByVal Div As Integer, ByVal Loc As Integer,
                                    ByVal UserId As String, ByVal PtnNo As Long) As List(Of clsPtnTypeMst)
        GetPtnTypByUser = New List(Of clsPtnTypeMst)  '#Trupti 26 JUN 2021
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelUserPtnTypMst002(Cocd, Div, Loc, UserId, PtnNo))

            While dr1.Read()
                With dr1
                    Dim obj1 As New clsPtnTypeMst
                    obj1.PtnTypCd = .Item("PtnTypCd")
                    obj1.PtnTypDesc = .Item("PtnTypDesc")
                    obj1.addinfo1 = .item("addinfo1")
                    GetPtnTypByUser.Add(obj1)
                End With
            End While
            dr1.close()


            ofactory = Nothing
        Catch ex As Exception
            GetPtnTypByUser = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetPtnTypByUser
    End Function

    Shared Function SpSelUserPtnTypMst002(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal PtnNo As Long) As DBRequest
        '#Trupti 26 JUN 2021
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelUserPtnTypMst002]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "@pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "@pDivcd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "@pLoccd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "@pUserID"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "@PtnNo"
            oParam.ParamValue = PtnNo
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function

    Shared Function SPSELPTNTYPEMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal pPtnBillTyp As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELPTNTYPEMST001]"

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
            oParam.ParamName = "pPtnBillTyp"
            oParam.ParamValue = pPtnBillTyp
            .Parameters.Add(oParam)



        End With

        Return oRequest
    End Function

    Shared Function GetPtnTypListByUser(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal UserID As String) As List(Of ClsUserPtnTypMst)
        GetPtnTypListByUser = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim obj As ClsUserPtnTypMst = Nothing
            Dim objArr As List(Of ClsUserPtnTypMst) = Nothing
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelUserPtnTypMst001(CoCd, Div, Loc, UserID))
            If dr1.hasrows Then
                objArr = New List(Of ClsUserPtnTypMst)
                While dr1.Read()
                    With dr1
                        obj = New ClsUserPtnTypMst
                        obj.PtnTypCd = IIf(IsDBNull(.Item("PtnTypCd")), 0, .Item("PtnTypCd"))
                        obj.PtnTypDesc = IIf(IsDBNull(.Item("PtnTypDesc")), Nothing, .Item("PtnTypDesc"))
                        obj.HasAccess = IIf(IsDBNull(.Item("Access")), 0, .Item("Access"))
                        obj.DefAccess = IIf(IsDBNull(.Item("DefPtntyp")), 0, .Item("DefPtntyp"))
                    End With
                    objArr.Add(obj)
                End While
            End If
            dr1.close()
            GetPtnTypListByUser = objArr
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetPtnTypListByUser
    End Function


    Shared Function SpSelUserPtnTypMst001(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UserID As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[dbo].[SpSelUserPtnTypMst001]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivCd"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLocCd"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserID
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function

    Shared Function GetDefaultValues(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal USRID As String) As List(Of clsPtnTypeMst)
        GetDefaultValues = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSETDEFAULTVALUE(companycode, div, loc, USRID))
            Dim obj As New List(Of clsPtnTypeMst)
            obj = New List(Of clsPtnTypeMst)
            While dr1.Read()
                With dr1
                    Dim obj1 As New clsPtnTypeMst
                    obj1.CSHDEPTCD = .Item("csh_dept_cd")
                    obj1.WINGCD = .Item("wing_cd")
                    obj1.VCHCHRGCD = .Item("vch_chrg_cd")
                    obj1.PTNCLSCD = .Item("ptn_cls_cd")

                    obj1.FREE = .Item("free")
                    obj1.REFUND = .Item("refund")
                    obj1.CASH = .Item("cash")
                    obj1.CONC = .Item("conc")
                    obj1.CREDIT = .Item("credit")

                    obj1.CSHDEPTDesc = .Item("csh_dept_dcd")
                    obj1.WINGDesc = .Item("wing_dcd")
                    obj1.VCHCHRGDesc = .Item("chrg_dcd")
                    obj1.PTNCLSDesc = .Item("ptn_cls_dcd")
                    obj1.CODE = .Item("ptn_cls_cd")
                    obj1.DECODE = .Item("ptn_cls_dcd")

                    obj.Add(obj1)
                End With
            End While
            dr1.close()
            GetDefaultValues = obj
            Return GetDefaultValues
            ofactory = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Shared Function SPSETDEFAULTVALUE(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal USRID As String) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSETDEFAULTVALUE]" 'var_def  csh_dept_mst  wing_mst  chrg_mst  ptn_cls_mst

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
            oParam.ParamName = "pusr_id"
            oParam.ParamValue = USRID
            .Parameters.Add(oParam)


            .CommandType = CommandType.StoredProcedure
        End With
        Return oRequest
    End Function
End Class
