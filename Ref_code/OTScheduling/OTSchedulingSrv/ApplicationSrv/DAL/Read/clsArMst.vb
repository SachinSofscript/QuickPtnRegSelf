Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsArMst
    <DataMember()>
    Public Property ArCd() As Integer
    <DataMember()>
    Public Property ArStsCd() As Integer
    <DataMember()>
    Public Property ArLngNm() As String
    <DataMember()>
    Public Property ArShrtNm() As String
    <DataMember()>
    Public Property ArAddrs1() As String
    <DataMember()>
    Public Property ArAddrs2() As String
    <DataMember()>
    Public Property ArAddrs3() As String
    <DataMember()>
    Public Property ArCity() As String
    <DataMember()>
    Public Property ArCityCd() As Integer
    <DataMember()>
    Public Property ArCountry() As String
    <DataMember()>
    Public Property ArCountryCd() As Integer
    <DataMember()>
    Public Property ArPin() As String
    <DataMember()>
    Public Property ArTel() As String
    <DataMember()>
    Public Property ArTlx() As String
    <DataMember()>
    Public Property ArFax() As String
    <DataMember()>
    Public Property ArTypCd() As Integer
    <DataMember()>
    Public Property PerAcFlg() As Boolean
    <DataMember()>
    Public Property CntCtTtlCd() As Integer
    <DataMember()>
    Public Property CntCtLstNm() As String
    <DataMember()>
    Public Property CntCtFrstNm() As String
    <DataMember()>
    Public Property CntCtMidNm() As String
    <DataMember()>
    Public Property CntCtDsgnCd() As Integer
    <DataMember()>
    Public Property IntCd1() As Integer
    <DataMember()>
    Public Property IntCd2() As Integer
    <DataMember()>
    Public Property CrDays() As String
    <DataMember()>
    Public Property IntRtDt() As Date
    <DataMember()>
    Public Property DscntCd1() As Integer
    <DataMember()>
    Public Property DscntCd2() As Integer
    <DataMember()>
    Public Property DscntDays() As Integer
    <DataMember()>
    Public Property DscntDt() As Date
    <DataMember()>
    Public Property ArAmt() As Double
    <DataMember()>
    Public Property OpnFolAmt() As Double
    <DataMember()>
    Public Property DrFolAmt() As Double
    <DataMember()>
    Public Property CrFolAmt() As Double
    <DataMember()>
    Public Property LyrOpnFolAmt() As Double
    <DataMember()>
    Public Property LyrDrFolAmt() As Double
    <DataMember()>
    Public Property LyrCrFolAmt() As Double
    <DataMember()>
    Public Property OpnDepAmt() As Double
    <DataMember()>
    Public Property DrDepAmt() As Double
    <DataMember()>
    Public Property CrDepAmt() As Double
    <DataMember()>
    Public Property LyrOpnDepAmt() As Double
    <DataMember()>
    Public Property LyrDrDepAmt() As Double
    <DataMember()>
    Public Property LyrCrDepAmt() As Double
    <DataMember()>
    Public Property LstInvDt() As Date
    <DataMember()>
    Public Property LstRcptDt() As Date
    <DataMember()>
    Public Property LstBlPstDt() As Date
    <DataMember()>
    Public Property RecLock() As Boolean
    <DataMember()>
    Public Property ArEmail() As String
    <DataMember()>
    Public Property ArUrl() As String
    <DataMember()>
    Public Property ArContactPerson() As String
    <DataMember()>
    Public Property ArDesig() As String
    <DataMember()>
    Public Property IndlBillLimit() As Double
    <DataMember()>
    Public Property UserDtTm() As Date
    <DataMember()>
    Public Property UserId() As String
    <DataMember()>
    Public Property IsDoctorSharedAllowed As Boolean 'Pramila 20161104
    <DataMember()>
    Public Property StateCd As Integer 'Aarti  20171226
    <DataMember()>
    Public Property StateDcd As String 'Aarti  20171226
    <DataMember()>
    Public Property OpPtnSellingFlag As Integer 'Amol 2018-06-01
    <DataMember()>
    Public Property IpPtnSellingFlag As Integer 'Amol 2018-06-01
    <DataMember()>
    Public Property IsArStrLinked As Boolean 'Rushikesh 16 nov 2018
    <DataMember()>
    Public Property Phrm_Disc_Per As Decimal 'Maitri 20191017

#Region "For Credit Company master"
    Shared Function GetArMstDetailsByArCd(ByRef strErrMsg As List(Of String),
                                                      ByRef chrErrFlg As Char, ByVal cocd As String,
                                                      ByVal div As Integer, ByVal loc As Integer, ByVal ArCd As Integer) As clsArMst
        GetArMstDetailsByArCd = Nothing
        Dim obj As New clsArMst
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(GETSPSELARMST(cocd, div, loc, ArCd))
            While dr1.Read()
                With dr1
                    obj.ArCd = .Item("ar_cd")
                    obj.ArStsCd = .Item("ar_cd")
                    obj.ArLngNm = .Item("ar_lng_nm")
                    obj.ArShrtNm = .Item("ar_shrt_nm")
                    obj.ArAddrs1 = .Item("ar_addrs1")
                    obj.ArAddrs2 = .Item("ar_addrs2")
                    obj.ArAddrs3 = .Item("ar_addrs3")
                    obj.ArCity = .Item("ar_city")
                    obj.ArCityCd = .Item("ArCityCd")
                    obj.ArCountry = .Item("ar_cntry")
                    obj.ArCountryCd = .Item("ArCntryCd")
                    obj.ArPin = .Item("ar_pin")
                    obj.ArTel = .Item("ar_tel")
                    obj.ArTlx = .Item("ar_tlx")
                    obj.ArFax = .Item("ar_fax")
                    obj.ArTypCd = .Item("ar_typ_cd")
                    obj.IntCd2 = .Item("int_cd_2")
                    obj.ArStsCd = .Item("ar_sts_cd") 'anamika 20141120
                    obj.IsDoctorSharedAllowed = .Item("IsDocShareAllowed") 'Pramila 20161104

                    obj.StateCd = IIf(IsDBNull(.Item("ArStateCd")), 0, .Item("ArStateCd")) 'Aarti 20171226
                    '' Amol 20180601
                    obj.OpPtnSellingFlag = .Item("OpSellingFlag")
                    obj.IpPtnSellingFlag = .Item("ipSellingFlag")
                    '' Amol 20180601
                    obj.IsArStrLinked = .Item("IsArStrLinked") 'Rushikesh 16 nov 2018

                    obj.Phrm_Disc_Per = .Item("Phrm_Disc_Per") 'maitri 20191017
                End With
                GetArMstDetailsByArCd = obj
            End While
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            GetArMstDetailsByArCd = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            obj = Nothing
        End Try

        Return GetArMstDetailsByArCd
    End Function
    Shared Function GETSPSELARMST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal ArCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELARMST]" 'ar_mst
            .CommandType = CommandType.StoredProcedure


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = companycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIVCd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOCCd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pArCd"
            oParam.ParamValue = ArCd
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
    Shared Function GetCreditCoLstSts(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal companycode As String, ByVal div As Integer,
                                                 ByVal loc As Integer) As List(Of clsArMstCdDcd)

        Try
            Dim ofactory As New DBFactory
            GetCreditCoLstSts = Nothing
            Dim dr1 As Object = ofactory.ExecuteDataReader(clsArMst.SPSELARMST003(companycode, div, loc))
            Dim objList As New List(Of clsArMstCdDcd)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New clsArMstCdDcd
                        obj.Code = .Item("ar_cd")
                        obj.Decode = .Item("ar_lng_nm")
                        objList.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetCreditCoLstSts = objList
            objList = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try

    End Function

    Shared Function SPSELARMST003(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELARMST003]" '(tables used ar_mst)

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
    Shared Function GetArMstList(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As List(Of clsArMst) 'Mayur 20131218
        GetArMstList = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(GETSPSELARMSTDTL(companycode, div, loc))
            Dim obj As New List(Of clsArMst)
            obj = New List(Of clsArMst)
            While dr1.Read()
                With dr1
                    Dim obj1 As New clsArMst
                    obj1.ArCd = .Item("ar_cd")
                    obj1.ArLngNm = .Item("ar_lng_nm")
                    obj.Add(obj1)
                End With
            End While
            dr1.close()
            GetArMstList = obj
            Return GetArMstList
            ofactory = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Shared Function GETSPSELARMSTDTL(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELARMSTDTL]" '(tables used ar_mst)

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
#End Region


End Class

<DataContract()>
Public Class clsArMstCdDcd 'anamika 20160520
    <DataMember()>
    Public Property Code() As Integer
    <DataMember()>
    Public Property Decode() As String
End Class
