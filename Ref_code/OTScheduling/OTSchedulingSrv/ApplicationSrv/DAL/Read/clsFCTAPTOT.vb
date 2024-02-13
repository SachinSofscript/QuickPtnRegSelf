Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsFCTAPTOT

    <DataMember()>
    Public Property CompanyCode() As String
    <DataMember()>
    Public Property DivisionCode() As Integer
    <DataMember()>
    Public Property LocationCode() As Integer
    <DataMember()>
    Public Property FctCatCode As Integer
    <DataMember()>
    Public Property FctMainCode As Integer
    <DataMember()>
    Public Property FCTCODE As Integer
    <DataMember()>
    Public Property APPTNO As Integer
    <DataMember()>
    Public Property APTMDATE As Date
    <DataMember()>
    Public Property DOCCD As Integer
    <DataMember()>
    Public Property DOCNAME As String
    <DataMember()>
    Public Property ISPATIENT As Boolean
    <DataMember()>
    Public Property IPOP As String
    '<DataMember()>
    'Public Property PTNNO As Integer
    '<DataMember()>
    'Public Property PTNNO As Integer
    <DataMember()>
    Public Property PTNNO As Long           'PRAGYA : 05-OCT-2016          'PRAGYA : 05-OCT-2016
    <DataMember()>
    Public Property PTNLNGNM As String
    <DataMember()>
    Public Property APTMTMFROM As Integer
    <DataMember()>
    Public Property APTMTMTO As Integer
    <DataMember()>
    Public Property NOOFSLOTSUSED As Integer
    <DataMember()>
    Public Property DURATION As Integer
    <DataMember()>
    Public Property ISPERFORMED As Boolean
    <DataMember()>
    Public Property ISPOSTED As Boolean
    <DataMember()>
    Public Property CRTUSRID As String
    <DataMember()>
    Public Property CRTDTTM As Date
    <DataMember()>
    Public Property FLG As String
    <DataMember>
    Public Property APPTRMRK() As String            'PRAGYA : 15-OCT-2016
    <DataMember>
    Public Property ANESTYPCD() As Integer          'PRAGYA : 15-OCT-2016
    <DataMember>
    Public Property Diagnosis() As String           'PRAGYA : 15-OCT-2016
    <DataMember>
    Public Property NurseName() As String           'PRAGYA : 15-OCT-2016




    <DataMember()>
    Public Property IsOfficePrmsnGiven As Boolean 'Trupti 14 JUn 2021
    <DataMember()>
    Public Property OfficePrmsnByUsrID As String  'Trupti 14 JUn 2021
    <DataMember()>
    Public Property OfficePrmsnRmrk As String  'Trupti 14 JUn 2021
    <DataMember()>
    Public Property OfficePrmsnDtTm As DateTime   'Trupti 14 JUn 2021



    <DataMember()>
    Public Property SurgeyName As String


    <DataMember()>
    Public Property Frmtm As String
    <DataMember()>
    Public Property ToTm As String



    <DataMember()>
    Public Property fct_name As String

    <DataMember()>
    Public Property APTM_DATE As String


    <DataMember()>
    Public Property BOOKING_TYPE As Integer



    <DataMember()>
    Public Property BOOKING_TYPE_DCD As String


    <DataMember>
    Public Property AnesthesiaTyp() As String




    <DataMember>
    Public Property ANAESTHESIST() As String



    <DataMember>
    Public Property APPTMSTSDCD() As String


    <DataMember()>
    Public Property PtnType As String

    <DataMember()>
    Public Property ArDcd As String  'Neha S.C. 20140219

    <DataMember()>
    Public Property PatientClassCodeDesc() As String



    <DataMember()>
    Public Property Bedno() As String

    <DataMember()>
    Public Property IPNO As Long


    <DataMember()>
    Public Property SurgeonName As String


    <DataMember()>
    Public Property FrmDTtm As DateTime

    <DataMember()>
    Public Property ToDTTm As DateTime

    <DataMember()>
    Public Property DisplayText As String



    ''' <summary>
    ''' Stored procedure to get OT Appointment details
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTCATCD"></param>
    ''' <param name="FCTMAINCD"></param>
    ''' <param name="APTMDATE"></param>
    ''' <param name="APTNO"></param>
    ''' <param name="APTMTMFRM"></param>
    ''' <param name="APTMTMTO"></param>
    ''' <param name="FLG"></param>
    Shared Function SPSELFCTAPTOT(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal APTMDATE As Date, ByVal APTNO As Integer, ByVal APTMTMFRM As Integer, ByVal APTMTMTO As Integer, ByVal FLG As String) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTAPTOT]" 'FCT_APT_OT
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = companycode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = div
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = loc
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCATCD"
        oParam.ParamValue = FCTCATCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTMAINCD"
        oParam.ParamValue = FCTMAINCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMDATE"
        oParam.ParamValue = APTMDATE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTNO"
        oParam.ParamValue = APTNO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTMFRM"
        oParam.ParamValue = APTMTMFRM
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMTMTO"
        oParam.ParamValue = APTMTMTO
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFLG"
        oParam.ParamValue = FLG
        oRequest.Parameters.Add(oParam)


        oRequest.CommandType = CommandType.StoredProcedure



        Return oRequest

    End Function

    ''' <summary>
    ''' TO get list of OT appointment details
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetOTAptDetails1(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                       ByVal companycode As String,
                                                       ByVal div As Integer,
                                                       ByVal loc As Integer,
                                                       ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal APTMDATE As Date, ByVal APTNO As Integer, ByVal APTMTMFRM As Integer, ByVal APTMTMTO As Integer, ByVal FLG As String) As List(Of clsFCTAPTOT) 'Mayur 20132409
        GetOTAptDetails1 = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTAPTOT(companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD, APTMDATE, APTNO, APTMTMFRM, APTMTMTO, FLG))


            Dim objArr As List(Of clsFCTAPTOT) = Nothing

            If dr1.hasrows Then

                objArr = New List(Of clsFCTAPTOT)

                While dr1.Read()

                    With dr1

                        Dim obj As New clsFCTAPTOT
                        With obj
                            obj.FctCatCode = dr1.Item("fct_cat_code")
                            obj.FctMainCode = dr1.Item("fct_main_code")
                            obj.FCTCODE = dr1.item("FCT_CODE")
                            obj.APPTNO = dr1.Item("APPT_NO")
                            obj.APTMDATE = dr1.Item("APTM_DATE")
                            obj.DOCCD = dr1.Item("DOC_CD")
                            obj.DOCNAME = dr1.Item("docname")
                            obj.ISPATIENT = dr1.item("ISPATIENT")
                            obj.IPOP = dr1.Item("IP_OP")
                            obj.PTNNO = dr1.Item("PTN_NO")
                            obj.PTNLNGNM = dr1.Item("PTN_LNG_NM")
                            obj.APTMTMFROM = dr1.Item("APTM_TM_FROM")
                            obj.APTMTMTO = dr1.Item("APTM_TM_TO")
                            obj.NOOFSLOTSUSED = dr1.Item("NO_OF_SLOTS_USED")
                            obj.DURATION = dr1.Item("DURATION")
                            obj.ISPERFORMED = dr1.Item("ISPERFORMED")
                            obj.ISPOSTED = dr1.Item("ISPOSTED")
                            obj.CRTUSRID = dr1.Item("CRT_USR_ID")
                            obj.CRTDTTM = dr1.Item("CRT_DT_TM")
                            obj.APPTRMRK = dr1.Item("APPTRMRK")         'PRAGYA : 02-NOV-2016
                            obj.IsOfficePrmsnGiven = dr1.Item("IsOfficePrmsnGiven") '#Trupti 14 JUN 2021
                            obj.OfficePrmsnRmrk = dr1.Item("OfficePrmsnRmrk") '#Trupti 14 JUN 2021 
                            obj.OfficePrmsnByUsrID = dr1.Item("OfficePrmsnByUsrID") '#Trupti 14 JUN 2021
                            obj.OfficePrmsnDtTm = dr1.Item("OfficePrmsnDtTm") '#Trupti 14 JUN 2021 

                            obj.BOOKING_TYPE = dr1.Item("BOOKING_TYPE")
                            objArr.Add(obj)

                        End With
                    End With
                End While
            End If

            dr1.close()

            GetOTAptDetails1 = objArr

            Return GetOTAptDetails1

            ofactory = Nothing

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function



    ''' <summary>
    ''' TO get list of OT appointment details
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetOTAptDetails(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                       ByVal companycode As String,
                                                       ByVal div As Integer,
                                                       ByVal loc As Integer,
                                                       ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer, ByVal APTMDATE As Date, ByVal APTNO As Integer, ByVal APTMTMFRM As Integer, ByVal APTMTMTO As Integer, ByVal FLG As String) As clsFCTAPTOT 'Mayur 20132409
        GetOTAptDetails = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTAPTOT(companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD, APTMDATE, APTNO, APTMTMFRM, APTMTMTO, FLG))


            Dim objArr As clsFCTAPTOT = Nothing
            Dim obj As New clsFCTAPTOT
            If dr1.hasrows Then

                objArr = New clsFCTAPTOT

                While dr1.Read()

                    With dr1


                        With obj
                            obj.FctCatCode = dr1.Item("fct_cat_code")
                            obj.FctMainCode = dr1.Item("fct_main_code")
                            obj.FCTCODE = dr1.item("FCT_CODE")
                            obj.APPTNO = dr1.Item("APPT_NO")
                            obj.APTMDATE = dr1.Item("APTM_DATE")
                            obj.DOCCD = dr1.Item("DOC_CD")
                            obj.ISPATIENT = dr1.item("ISPATIENT")
                            obj.IPOP = dr1.Item("IP_OP")
                            obj.PTNNO = dr1.Item("PTN_NO")
                            obj.PTNLNGNM = dr1.Item("PTN_LNG_NM")
                            obj.APTMTMFROM = dr1.Item("APTM_TM_FROM")
                            obj.APTMTMTO = dr1.Item("APTM_TM_TO")
                            obj.NOOFSLOTSUSED = dr1.Item("NO_OF_SLOTS_USED")
                            obj.DURATION = dr1.Item("DURATION")
                            obj.ISPERFORMED = dr1.Item("ISPERFORMED")
                            obj.ISPOSTED = dr1.Item("ISPOSTED")
                            obj.CRTUSRID = dr1.Item("CRT_USR_ID")
                            obj.CRTDTTM = dr1.Item("CRT_DT_TM")
                            obj.IsOfficePrmsnGiven = dr1.Item("IsOfficePrmsnGiven") '#Trupti 14 JUN 2021
                            obj.OfficePrmsnRmrk = dr1.Item("OfficePrmsnRmrk") '#Trupti 14 JUN 2021 

                            'objArr.Add(obj)

                        End With
                    End With
                End While
            End If

            dr1.close()

            GetOTAptDetails = obj

            Return GetOTAptDetails

            ofactory = Nothing

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


#Region "GetFctAptOtDtlForChkLst/SpSelFctAptOt001 - to GET THE LIST OF OT APPOINMENTS USED IN OT_CHEKLISTS"
    'PRAGYA : 05-OCT-2016

    Shared Function GetFctAptOtDtlForChkLst(ByRef strErrMsg As List(Of String),
                                            ByRef chrErrFlg As Char,
                                            ByVal companycode As String,
                                            ByVal div As Integer,
                                            ByVal loc As Integer,
                                            ByVal FctCd As Integer,
                                            ByVal FctCatCd As Integer,
                                            ByVal FctMainCd As Integer,
                                            ByVal AptDt As Date) As List(Of clsFctAptOtExtraDetails)
        GetFctAptOtDtlForChkLst = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFctAptOt001(companycode, div, loc, FctCd, FctCatCd, FctMainCd, AptDt))
            Dim arrObjFctOt As List(Of clsFctAptOtExtraDetails) = Nothing

            If dr1.hasrows Then
                arrObjFctOt = New List(Of clsFctAptOtExtraDetails)
                While dr1.Read()
                    With dr1
                        Dim objOt As New clsFctAptOtExtraDetails
                        With objOt
                            .FCTCODE = dr1.item("OTCd")
                            .FctCdDesc = dr1.item("OTDesc")
                            'obj.FctCatCode = dr1.Item("fct_cat_code")
                            'obj.FctMainCode = dr1.Item("fct_main_code")
                            .APPTNO = dr1.Item("ApptNo")
                            .APTMDATE = dr1.Item("ApptDate")
                            .DOCCD = dr1.Item("DocCd")
                            .DOCNAME = dr1.Item("DocNm")
                            .ISPATIENT = dr1.item("IsPtn")
                            .IPOP = dr1.Item("IpOp")
                            .PTNNO = dr1.Item("PtnNo")
                            .IpNo = dr1.Item("IpNo")
                            .PTNLNGNM = dr1.Item("PtnName")
                            .PtnFrstNm = dr1.Item("PtnFrstNm")
                            .NOOFSLOTSUSED = dr1.Item("Slot")
                            .APTMTMFROM = dr1.Item("From")
                            .APTMTMTO = dr1.Item("To")
                            .DURATION = dr1.Item("DURATION")
                            .ISPERFORMED = dr1.Item("ISPERFORMED")
                            .ISPOSTED = dr1.Item("ISPOSTED")
                            arrObjFctOt.Add(objOt)
                        End With
                    End With
                End While
            End If
            dr1.close()
            GetFctAptOtDtlForChkLst = arrObjFctOt
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    'PRAGYA : 05-OCT-2016
    Shared Function SpSelFctAptOt001(ByVal companycode As String,
                                     ByVal div As Integer,
                                     ByVal loc As Integer,
                                     ByVal FCTCODE As Integer,
                                     ByVal FCTCATCD As Integer,
                                     ByVal FCTMAINCD As Integer,
                                     ByVal APTMDATE As Date) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        oRequest.Command = "[SpSelFctAptOt001]" 'FCT_APT_OT
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = companycode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pDIV"
        oParam.ParamValue = div
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pLOC"
        oParam.ParamValue = loc
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCODE"
        oParam.ParamValue = FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTCATCD"
        oParam.ParamValue = FCTCATCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFCTMAINCD"
        oParam.ParamValue = FCTMAINCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pAPTMDATE"
        oParam.ParamValue = APTMDATE
        oRequest.Parameters.Add(oParam)


        oRequest.CommandType = CommandType.StoredProcedure



        Return oRequest

    End Function
#End Region

#Region "GetListFctCdDescFrmCatMainCd/SpSelFctMst003 : fct_Mst HELP by passing FctCd / FctCatCd / fCtMaiNcD - return type as clsCodeDecode"
    'PRAGYA : 05-OCT-2016
    Shared Function GetListFctCdDescFrmCatMainCd(ByRef strErrMsg As List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal COCd As String,
                                      ByVal Div As Integer,
                                      ByVal Loc As Integer,
                                      ByVal FctCd As Integer,
                                      ByVal FctCatCd As Integer,
                                      ByVal FctMainCd As Integer) As List(Of clsCodeDecode)
        GetListFctCdDescFrmCatMainCd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFctMst003(COCd, Div, Loc, FctCd, FctCatCd, FctMainCd))
            Dim objArr As List(Of clsCodeDecode) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsCodeDecode)
                While dr1.Read()
                    With dr1
                        Dim obj As New clsCodeDecode
                        obj.Code = IIf(IsDBNull(.Item("Code")), Nothing, .Item("Code"))
                        obj.Decode = IIf(IsDBNull(.Item("Desc")), Nothing, .Item("Desc"))
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetListFctCdDescFrmCatMainCd = objArr
            Return GetListFctCdDescFrmCatMainCd
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

    Shared Function SpSelFctMst003(ByVal COCd As String,
                                   ByVal Div As Integer,
                                   ByVal Loc As Integer,
                                   ByVal FctCd As Integer,
                                   ByVal FctCatCd As Integer,
                                   ByVal FctMainCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelFctMst003]"

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
            oParam.ParamName = "pFctCd"
            oParam.ParamValue = FctCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctCatCd"
            oParam.ParamValue = FctCatCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctMainCd"
            oParam.ParamValue = FctMainCd
            .Parameters.Add(oParam)


            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest
    End Function


#End Region

#Region "GetFctDescFrmOtCdCatCdMainCd/SpSelFctMst003 : get FCT CD DESC BY PASSING - FCTCD / FctCatCd / fCtMaiNcD - return type as STRING"
    'PRAGYA : 06-OCT-2016
    Shared Function GetFctDescFrmOtCdCatCdMainCd(ByRef strErrMsg As List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal COCd As String,
                                      ByVal Div As Integer,
                                      ByVal Loc As Integer,
                                      ByVal FctCd As Integer,
                                      ByVal FctCatCd As Integer,
                                      ByVal FctMainCd As Integer) As String
        GetFctDescFrmOtCdCatCdMainCd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFctMst003(COCd, Div, Loc, FctCd, FctCatCd, FctMainCd))
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        GetFctDescFrmOtCdCatCdMainCd = IIf(IsDBNull(.Item("Desc")), Nothing, .Item("Desc"))
                    End With
                End While
            End If
            dr1.close()

            Return GetFctDescFrmOtCdCatCdMainCd
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

#End Region


#Region "GET APPOINTMENT LIST FOR OT CHARGE POSTING BY PASSING FCTCATCD, FCTMAINCD" 'RasikV 20170309
    Shared Function GetOtApptList(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer) As List(Of clsFctAptOtExtraDetails)
        GetOtApptList = Nothing
        Dim ofactory As New DBFactory
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFctAptOt002(CoCd, Div, Loc, FCTCatCd, FCTMainCd))
            Dim objArr As List(Of clsFctAptOtExtraDetails) = Nothing
            Dim obj As clsFctAptOtExtraDetails = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsFctAptOtExtraDetails)
                While dr1.Read()
                    With dr1
                        obj = New clsFctAptOtExtraDetails
                        obj.FCTCODE = IIf(IsDBNull(.Item("FctCd")), 0, .Item("FctCd"))
                        obj.FctCdDesc = IIf(IsDBNull(.Item("FctDcd")), Nothing, .Item("FctDcd"))
                        obj.APPTNO = IIf(IsDBNull(.Item("ApptNo")), 0, .Item("ApptNo"))
                        obj.APTMDATE = IIf(IsDBNull(.Item("ApTmDt")), Nothing, .Item("ApTmDt"))
                        obj.DOCCD = IIf(IsDBNull(.Item("DocCd")), 0, .Item("DocCd"))
                        obj.DOCNAME = IIf(IsDBNull(.Item("DocDcd")), Nothing, .Item("DocDcd"))
                        obj.ISPATIENT = IIf(IsDBNull(.Item("IsPtn")), 0, .Item("IsPtn"))
                        obj.IPOP = IIf(IsDBNull(.Item("IpOp")), Nothing, .Item("IpOp"))
                        obj.PTNNO = IIf(IsDBNull(.Item("PtnNo")), 0, .Item("PtnNo"))
                        obj.PTNLNGNM = IIf(IsDBNull(.Item("PtnDcd")), 0, .Item("PtnDcd"))
                        obj.APTMTMFROM = IIf(IsDBNull(.Item("ApTmFrom")), Nothing, .Item("ApTmFrom"))
                        obj.APTMTMTO = IIf(IsDBNull(.Item("ApTmTo")), Nothing, .Item("ApTmTo"))
                        obj.NOOFSLOTSUSED = IIf(IsDBNull(.Item("Slots")), 0, .Item("Slots"))
                        obj.DURATION = IIf(IsDBNull(.Item("Dur")), 0, .Item("Dur"))
                        obj.ISPERFORMED = IIf(IsDBNull(.Item("IsPer")), 0, .Item("IsPer"))
                        obj.ISPOSTED = IIf(IsDBNull(.Item("IsPos")), 0, .Item("IsPos"))
                        obj.CRTUSRID = IIf(IsDBNull(.Item("CrtUsrId")), Nothing, .Item("CrtUsrId"))
                        obj.CRTDTTM = IIf(IsDBNull(.Item("CrtDt")), Nothing, .Item("CrtDt"))
                    End With
                    objArr.Add(obj)
                End While
            End If
            dr1.close()
            GetOtApptList = objArr
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetOtApptList
    End Function

    Shared Function SpSelFctAptOt002(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest
            .Command = "[dbo].[SpSelFctAptOt002]" 'FCT_APT_OT
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
            oParam.ParamName = "pFctCatCd"
            oParam.ParamValue = FCTCatCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctMainCd"
            oParam.ParamValue = FCTMainCd
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
#End Region

#Region "GET APPOINTMENT DETAILS FOR OT CHARGE POSTING BY PASSING FCTCATCD, FCTMAINCD, APPTNO" 'RasikV 20170309
    Shared Function GetOtApptNoDtls(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer, ByVal ApptNo As Integer) As clsFctAptOtExtraDetails
        GetOtApptNoDtls = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFctAptOt003(CoCd, Div, Loc, FCTCatCd, FCTMainCd, ApptNo))
            Dim obj As clsFctAptOtExtraDetails = Nothing
            obj = New clsFctAptOtExtraDetails
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj.FCTCODE = IIf(IsDBNull(.Item("FctCd")), 0, .Item("FctCd"))
                        obj.FctCdDesc = IIf(IsDBNull(.Item("FctDcd")), Nothing, .Item("FctDcd"))
                        obj.APPTNO = IIf(IsDBNull(.Item("ApptNo")), 0, .Item("ApptNo"))
                        obj.APTMDATE = IIf(IsDBNull(.Item("ApTmDt")), Nothing, .Item("ApTmDt"))
                        obj.DOCCD = IIf(IsDBNull(.Item("DocCd")), 0, .Item("DocCd"))
                        obj.DOCNAME = IIf(IsDBNull(.Item("DocDcd")), Nothing, .Item("DocDcd"))
                        obj.ISPATIENT = IIf(IsDBNull(.Item("IsPtn")), 0, .Item("IsPtn"))
                        obj.IPOP = IIf(IsDBNull(.Item("IpOp")), Nothing, .Item("IpOp"))
                        obj.PTNNO = IIf(IsDBNull(.Item("PtnNo")), 0, .Item("PtnNo"))
                        obj.PTNLNGNM = IIf(IsDBNull(.Item("PtnDcd")), 0, .Item("PtnDcd"))
                        obj.APTMTMFROM = IIf(IsDBNull(.Item("ApTmFrom")), Nothing, .Item("ApTmFrom"))
                        obj.APTMTMTO = IIf(IsDBNull(.Item("ApTmTo")), Nothing, .Item("ApTmTo"))
                        obj.NOOFSLOTSUSED = IIf(IsDBNull(.Item("Slots")), 0, .Item("Slots"))
                        obj.DURATION = IIf(IsDBNull(.Item("Dur")), 0, .Item("Dur"))
                        obj.ISPERFORMED = IIf(IsDBNull(.Item("IsPer")), 0, .Item("IsPer"))
                        obj.ISPOSTED = IIf(IsDBNull(.Item("IsPos")), 0, .Item("IsPos"))
                        obj.CRTUSRID = IIf(IsDBNull(.Item("CrtUsrId")), Nothing, .Item("CrtUsrId"))
                        obj.CRTDTTM = IIf(IsDBNull(.Item("CrtDt")), Nothing, .Item("CrtDt"))
                        obj.ANESTYPCD = IIf(IsDBNull(.Item("AnestypCd")), 0, .Item("AnestypCd"))
                    End With
                    GetOtApptNoDtls = obj
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetOtApptNoDtls
    End Function

    Shared Function SpSelFctAptOt003(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer, ByVal ApptNo As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest
            .Command = "[dbo].[SpSelFctAptOt003]" 'FCT_APT_OT
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
            oParam.ParamName = "pFctCatCd"
            oParam.ParamValue = FCTCatCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctMainCd"
            oParam.ParamValue = FCTMainCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pApptNo"
            oParam.ParamValue = ApptNo
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region




    Shared Function GetOTDtlsByFilter(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                       ByVal companycode As String,
                                                       ByVal div As Integer,
                                                       ByVal loc As Integer,
                                                      ByVal FrmDt As Date,
                                                          ByVal ToDt As Date,
                                                          ByVal Flg As Char,
                                                          ByVal ApptSts As Int16, ByVal ArCd As String, ByVal OTCd As Integer, ByVal PtnType As Integer,
                                      ByVal ChkDt As Boolean) As List(Of clsFCTAPTOT) 'Mayur 20132409
        GetOTDtlsByFilter = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTAPTOT004(companycode, div, loc, FrmDt, ToDt, Flg, ApptSts, ArCd, OTCd, PtnType, ChkDt))


            Dim objArr As List(Of clsFCTAPTOT) = Nothing

            If dr1.hasrows Then

                objArr = New List(Of clsFCTAPTOT)

                While dr1.Read()

                    With dr1

                        Dim obj As New clsFCTAPTOT
                        With obj



                            obj.APTM_DATE = IIf(IsDBNull(dr1.Item("APTM_DATE")), Nothing, dr1.Item("APTM_DATE"))

                            obj.fct_name = IIf(IsDBNull(dr1.Item("SEQ")), Nothing, dr1.Item("SEQ"))




                            obj.PTNLNGNM = IIf(IsDBNull(dr1.Item("PATIENTNAME")), Nothing, dr1.Item("PATIENTNAME"))

                            obj.Frmtm = IIf(IsDBNull(dr1.Item("OTFRMTIME")), Nothing, dr1.Item("OTFRMTIME"))
                            obj.ToTm = IIf(IsDBNull(dr1.Item("OTTOTIME")), Nothing, dr1.Item("OTTOTIME"))

                            obj.DOCNAME = IIf(IsDBNull(dr1.Item("SURGEONNAME")), Nothing, dr1.Item("SURGEONNAME"))




                            obj.SurgeonName = IIf(IsDBNull(dr1.Item("ASSISTSURGEONNAME")), Nothing, dr1.Item("ASSISTSURGEONNAME"))








                            obj.SurgeyName = IIf(IsDBNull(dr1.Item("SURGERYNAME")), Nothing, dr1.Item("SURGERYNAME"))

                            obj.CRTDTTM = IIf(IsDBNull(dr1.Item("CRT_DT_TM")), Nothing, dr1.Item("CRT_DT_TM"))

                            obj.APPTNO = IIf(IsDBNull(dr1.Item("APPT_NO")), Nothing, dr1.Item("APPT_NO"))

                            obj.APPTRMRK = IIf(IsDBNull(dr1.Item("REMARK")), Nothing, dr1.Item("REMARK"))


                            obj.AnesthesiaTyp = IIf(IsDBNull(dr1.Item("AnesthesiaTyp")), Nothing, dr1.Item("AnesthesiaTyp"))

                            obj.ANAESTHESIST = IIf(IsDBNull(dr1.Item("ANAESTHESIST")), Nothing, dr1.Item("ANAESTHESIST"))


                            obj.APPTMSTSDCD = IIf(IsDBNull(dr1.Item("APPTMSTSDCD")), Nothing, dr1.Item("APPTMSTSDCD"))

                            obj.BOOKING_TYPE_DCD = IIf(IsDBNull(dr1.Item("BOOKING_TYPE")), Nothing, dr1.Item("BOOKING_TYPE"))


                            obj.PtnType = IIf(IsDBNull(dr1.Item("ptnType")), Nothing, dr1.Item("ptnType"))


                            obj.ArDcd = IIf(IsDBNull(dr1.Item("ar_lng_nm")), Nothing, dr1.Item("ar_lng_nm"))

                            obj.Bedno = IIf(IsDBNull(dr1.Item("BED_NO")), Nothing, dr1.Item("BED_NO"))

                            obj.PatientClassCodeDesc = IIf(IsDBNull(dr1.Item("ptn_cls_dcd")), Nothing, dr1.Item("ptn_cls_dcd"))


                            obj.PTNNO = IIf(IsDBNull(dr1.Item("PTNNO")), Nothing, dr1.Item("PTNNO"))

                            obj.DOCNAME = IIf(IsDBNull(dr1.Item("SURGEONNAME")), Nothing, dr1.Item("SURGEONNAME"))

                            obj.IPNO = IIf(IsDBNull(dr1.Item("IPNO")), Nothing, dr1.Item("IPNO"))
                            objArr.Add(obj)

                        End With
                    End With
                End While
            End If

            dr1.close()
            GetOTDtlsByFilter = objArr

            Return GetOTDtlsByFilter

            ofactory = Nothing

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function




    Shared Function SPSELFCTAPTOT004(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrmDt As Date,
                                                          ByVal ToDt As Date,
                                                          ByVal Flg As Char,
                                                          ByVal ApptSts As Int16, ByVal ArCd As String, ByVal OTCd As Integer, ByVal PtnType As Integer, ByVal ChkDt As Boolean) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTAPTOT004]" 'FCT_APT_OT
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = companycode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "PDIVCD"
        oParam.ParamValue = div
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "PLOCCD"
        oParam.ParamValue = loc
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "FCTCODE"
        oParam.ParamValue = OTCd
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "@APTM_FRM_DATE"
        oParam.ParamValue = FrmDt
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "@APTM_TO_DATE"
        oParam.ParamValue = ToDt
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "flg"
        oParam.ParamValue = Flg
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "APTM_STS"
        oParam.ParamValue = ApptSts
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pArCd"
        oParam.ParamValue = ArCd
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pPtnType"
        oParam.ParamValue = PtnType
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "ChkDt"
        oParam.ParamValue = ChkDt
        oRequest.Parameters.Add(oParam)





        oRequest.CommandType = CommandType.StoredProcedure



        Return oRequest

    End Function




#Region "GET DATA FOR OT SCHEDULER"
    Shared Function GetOTDataForDashBrdSch(ByRef strErrMsg As List(Of String),
                                                       ByRef chrErrFlg As Char,
                                                       ByVal companycode As String,
                                                       ByVal div As Integer,
                                                       ByVal loc As Integer,
                                                      ByVal FrmDt As Date,
                                                          ByVal ToDt As Date,
                                                          ByVal Flg As Char,
                                                          ByVal ApptSts As Int16, ByVal ArCd As String, ByVal OTCd As Integer, ByVal PtnType As Integer,
                                      ByVal ChkDt As Boolean) As List(Of clsFCTAPTOT) 'Trupti 15 NOV 2022
        GetOTDataForDashBrdSch = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTAPTOT005(companycode, div, loc, FrmDt, ToDt, Flg, ApptSts, ArCd, OTCd, PtnType, ChkDt))


            Dim objArr As List(Of clsFCTAPTOT) = Nothing

            If dr1.hasrows Then

                objArr = New List(Of clsFCTAPTOT)

                While dr1.Read()

                    With dr1

                        Dim obj As New clsFCTAPTOT
                        With obj



                            obj.APTM_DATE = IIf(IsDBNull(dr1.Item("APTM_DATE")), Nothing, dr1.Item("APTM_DATE"))

                            obj.fct_name = IIf(IsDBNull(dr1.Item("SEQ")), Nothing, dr1.Item("SEQ"))
                            obj.FCTCODE = IIf(IsDBNull(dr1.Item("FCT_CODE")), Nothing, dr1.Item("FCT_CODE"))



                            obj.PTNLNGNM = IIf(IsDBNull(dr1.Item("PATIENTNAME")), Nothing, dr1.Item("PATIENTNAME"))

                            obj.Frmtm = IIf(IsDBNull(dr1.Item("OTFRMTIME")), Nothing, dr1.Item("OTFRMTIME"))
                            obj.ToTm = IIf(IsDBNull(dr1.Item("OTTOTIME")), Nothing, dr1.Item("OTTOTIME"))


                            Dim TemdateTime As DateTime = Convert.ToDateTime(obj.APTM_DATE)
                            Dim TemTime As DateTime = Convert.ToDateTime(obj.Frmtm)

                            obj.FrmDTtm = New DateTime(TemdateTime.Year, TemdateTime.Month, TemdateTime.Day, TemTime.Hour, TemTime.Minute, TemTime.Second, TemTime.Millisecond)
                            TemTime = Convert.ToDateTime(obj.ToTm)
                            obj.ToDTTm = New DateTime(TemdateTime.Year, TemdateTime.Month, TemdateTime.Day, TemTime.Hour, TemTime.Minute, TemTime.Second, TemTime.Millisecond)



                            obj.DOCNAME = IIf(IsDBNull(dr1.Item("SURGEONNAME")), Nothing, dr1.Item("SURGEONNAME"))




                            obj.SurgeonName = IIf(IsDBNull(dr1.Item("ASSISTSURGEONNAME")), Nothing, dr1.Item("ASSISTSURGEONNAME"))








                            obj.SurgeyName = IIf(IsDBNull(dr1.Item("SURGERYNAME")), Nothing, dr1.Item("SURGERYNAME"))

                            obj.CRTDTTM = IIf(IsDBNull(dr1.Item("CRT_DT_TM")), Nothing, dr1.Item("CRT_DT_TM"))

                            obj.APPTNO = IIf(IsDBNull(dr1.Item("APPT_NO")), Nothing, dr1.Item("APPT_NO"))

                            obj.APPTRMRK = IIf(IsDBNull(dr1.Item("REMARK")), Nothing, dr1.Item("REMARK"))


                            obj.AnesthesiaTyp = IIf(IsDBNull(dr1.Item("AnesthesiaTyp")), Nothing, dr1.Item("AnesthesiaTyp"))

                            obj.ANAESTHESIST = IIf(IsDBNull(dr1.Item("ANAESTHESIST")), Nothing, dr1.Item("ANAESTHESIST"))


                            obj.APPTMSTSDCD = IIf(IsDBNull(dr1.Item("APPTMSTSDCD")), Nothing, dr1.Item("APPTMSTSDCD"))

                            obj.BOOKING_TYPE_DCD = IIf(IsDBNull(dr1.Item("BOOKING_TYPE")), Nothing, dr1.Item("BOOKING_TYPE"))


                            obj.PtnType = IIf(IsDBNull(dr1.Item("ptnType")), Nothing, dr1.Item("ptnType"))


                            obj.ArDcd = IIf(IsDBNull(dr1.Item("ar_lng_nm")), Nothing, dr1.Item("ar_lng_nm"))

                            obj.Bedno = IIf(IsDBNull(dr1.Item("BED_NO")), Nothing, dr1.Item("BED_NO"))

                            obj.PatientClassCodeDesc = IIf(IsDBNull(dr1.Item("ptn_cls_dcd")), Nothing, dr1.Item("ptn_cls_dcd"))


                            obj.PTNNO = IIf(IsDBNull(dr1.Item("PTNNO")), Nothing, dr1.Item("PTNNO"))

                            obj.DOCNAME = IIf(IsDBNull(dr1.Item("SURGEONNAME")), Nothing, dr1.Item("SURGEONNAME"))

                            obj.IPNO = IIf(IsDBNull(dr1.Item("IPNO")), Nothing, dr1.Item("IPNO"))



                            obj.DisplayText = IIf(IsDBNull(dr1.Item("IPNO")), Nothing, dr1.Item("IPNO"))


                            objArr.Add(obj)

                        End With
                    End With
                End While
            End If

            dr1.close()
            GetOTDataForDashBrdSch = objArr

            Return GetOTDataForDashBrdSch

            ofactory = Nothing

        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function




    Shared Function SPSELFCTAPTOT005(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                     ByVal FrmDt As Date,
                                                          ByVal ToDt As Date,
                                                          ByVal Flg As Char,
                                                          ByVal ApptSts As Int16, ByVal ArCd As String, ByVal OTCd As Integer, ByVal PtnType As Integer, ByVal ChkDt As Boolean) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTAPTOT005]" 'FCT_APT_OT
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True

        oParam = New DBRequest.Parameter
        oParam.ParamName = "pCOCD"
        oParam.ParamValue = companycode
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "PDIVCD"
        oParam.ParamValue = div
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "PLOCCD"
        oParam.ParamValue = loc
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "FCTCODE"
        oParam.ParamValue = OTCd
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "@APTM_FRM_DATE"
        oParam.ParamValue = FrmDt
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "@APTM_TO_DATE"
        oParam.ParamValue = ToDt
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "flg"
        oParam.ParamValue = Flg
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "APTM_STS"
        oParam.ParamValue = ApptSts
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pArCd"
        oParam.ParamValue = ArCd
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pPtnType"
        oParam.ParamValue = PtnType
        oRequest.Parameters.Add(oParam)



        oParam = New DBRequest.Parameter
        oParam.ParamName = "ChkDt"
        oParam.ParamValue = ChkDt
        oRequest.Parameters.Add(oParam)





        oRequest.CommandType = CommandType.StoredProcedure



        Return oRequest

    End Function

#End Region
End Class
#Region "cls: clsFctAptOtExtraDetails"
'PRAGYA : 05-OCT-2016
Public Class clsFctAptOtExtraDetails
    Inherits clsFCTAPTOT

    <DataMember()>
    Public Property FctCdDesc() As String
    <DataMember()>
    Public Property IpNo() As Long   'IPNO IS SAVED HERE
    <DataMember()>
    Public Property PtnFrstNm() As String

End Class
#End Region