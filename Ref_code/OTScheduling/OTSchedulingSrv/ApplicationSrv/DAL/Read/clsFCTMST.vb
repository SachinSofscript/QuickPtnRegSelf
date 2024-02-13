Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient

#Region "alpesh 20161210 : select class for get session and hours"
<DataContract()>
Public Class clsFctMstSession
    <DataMember()>
    Public Property fctNoOfSessions As Integer

    <DataMember()>
    Public Property fctSlotPrdHrs As Integer

    <DataMember()>
    Public Property fctSlotPrdMins As Integer

End Class
#End Region

#Region "alpesh 20161203 : clsFctMstDetails details class ofclsFCTMST "
<DataContract()>
Public Class clsFctMstDetails
    Inherits clsFCTMST
    <DataMember()>
    Public Property fctonlinedt As Date
    <DataMember()>
    Public Property fctmaxhistprd As Integer
    <DataMember()>
    Public Property fctoverlapyn As String
    <DataMember()>
    Public Property fctmaxoverbook As Integer
    <DataMember()>
    Public Property fctprtslipyn As String
    <DataMember()>
    Public Property fctnoofsessions As Integer
    <DataMember()>
    Public Property fctslotprdmins As Integer
    <DataMember()>
    Public Property fctcrtuid As String
    <DataMember()>
    Public Property fcticdflg As String
    <DataMember()>
    Public Property MedNonMed As String
    <DataMember()>
    Public Property ptnmst As String
    <DataMember()>
    Public Property docapt As String
    <DataMember()>
    Public Property empapt As String
    <DataMember()>
    Public Property othapt As String
    <DataMember()>
    Public Property StrCd As Integer            'Aarti 20171212
End Class
#End Region



<DataContract()>
Public Class clsFCTMST

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
    Public Property FCTNAME As String
    <DataMember()>
    Public Property APPBOOKSTAT As String
    <DataMember()>
    Public Property FCTMAXCALPRD As String
    <DataMember()>
    Public Property FCTNOSESSION As Integer
    <DataMember()>
    Public Property FCTSLOTPRDHRS As Integer
    <DataMember()>
    Public Property FCTSLOTPRDMNS As Integer
    <DataMember()>
    Public Property FCTRCHRGCD As Integer
    <DataMember()>
    Public Property FCTRTSTCD As Integer
    <DataMember()>
    Public Property FCTRMKS As String
    <DataMember()>
    Public Property FCTDAY As Date

    ''' <summary>
    ''' Stored procedure to get fct_mst details
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTCATCD"></param>
    ''' <param name="FCTMAINCD"></param>
    Shared Function SPSELFCTMST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTMST]" 'fct_mst
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
        oParam.ParamName = "pFctCd"
        oParam.ParamValue = FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctCatCd"
        oParam.ParamValue = FCTCATCD
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "pFctMainCd"
        oParam.ParamValue = FCTMAINCD
        oRequest.Parameters.Add(oParam)


        oRequest.CommandType = CommandType.StoredProcedure


        Return oRequest


    End Function


    ''' <summary>
    ''' TO get list of  fct_apt_mst
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetFCTMST(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTCATCD As Integer, ByVal FCTMAINCD As Integer) As List(Of clsFCTMST) 'Mayur 20131109
        GetFCTMST = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTMST(companycode, div, loc, FCTCODE, FCTCATCD, FCTMAINCD))
            Dim objArr As List(Of clsFCTMST) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsFCTMST)
                While dr1.Read()
                    Dim obj As New clsFCTMST
                    With obj
                        obj.FCTCODE = dr1.item("fct_code")
                        obj.FCTNAME = dr1.Item("fct_name")
                        obj.APPBOOKSTAT = dr1.item("appbookstat")
                        obj.FCTMAXCALPRD = dr1.item("fct_max_cal_prd")
                        obj.FCTNOSESSION = dr1.Item("fct_no_of_sessions")
                        obj.FCTSLOTPRDHRS = dr1.item("fct_slot_prd_hrs")
                        obj.FCTSLOTPRDMNS = dr1.item("fct_slot_prd_mins")
                        obj.FCTRCHRGCD = dr1.item("fctr_chrg_cd")
                        obj.FCTRTSTCD = dr1.item("fctr_tst_cd")
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetFCTMST = objArr
            Return GetFCTMST
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' Stored procedure to get holiday day details
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="FCTCODE"></param>
    ''' <param name="FCTDATE"></param>
    Shared Function SPSELFCTMST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTDATE As Date) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTMST001]" 'fct_holi  fct_mst
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
        oParam.ParamName = "pFctCd"
        oParam.ParamValue = FCTCODE
        oRequest.Parameters.Add(oParam)


        oParam = New DBRequest.Parameter
        oParam.ParamName = "FCTHOLIDAYDATE"
        oParam.ParamValue = FCTDATE
        oRequest.Parameters.Add(oParam)


        oRequest.CommandType = CommandType.StoredProcedure


        Return oRequest


    End Function



    ''' <summary>
    ''' TO get list of  fct_apt_mst
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetHolidayDay(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, _
                                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer, ByVal FCTDATE As Date) As List(Of clsFCTMST) 'Mayur 20132009
        GetHolidayDay = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTMST001(companycode, div, loc, FCTCODE, FCTDATE))
            Dim objArr As List(Of clsFCTMST) = Nothing
            If dr1.hasrows Then
                objArr = New List(Of clsFCTMST)
                While dr1.Read()
                    Dim obj As New clsFCTMST
                    With obj
                        obj.FCTRMKS = dr1.item("fcth_remarks")
                        obj.FCTDAY = dr1.item("fcth_holiday_date")
                        objArr.Add(obj)
                    End With
                End While
            End If
            dr1.close()
            GetHolidayDay = objArr
            Return GetHolidayDay
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

#Region "GetOtName: SPSELFCTMST002"
    Shared Function GetOtName(ByRef strErrMsg As List(Of String), _
                                      ByRef chrErrFlg As Char, _
                                      ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer,
                                      ByVal OtNo As Integer) As String
        GetOtName = Nothing
        Try

            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELFCTMST002(companycode, div, loc, OtNo))
            Dim objArr As List(Of clsFCTMST) = Nothing
            If dr1.hasrows Then
                While dr1.Read()
                    GetOtName = dr1.item("fct_name")
                End While
            Else
                GetOtName = ""
            End If
            dr1.close()
        Catch ex As Exception
            GetOtName = ""
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetOtName
    End Function


    Shared Function SPSELFCTMST002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal FCTCODE As Integer) As DBRequest


        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        ' With oRequest
        oRequest.Command = "[SPSELFCTMST002]" 'fct_holi  fct_mst
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True

        With oRequest
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
            oParam.ParamName = "pfctcode"
            oParam.ParamValue = FCTCODE
            .Parameters.Add(oParam)


        End With

        Return oRequest


    End Function
#End Region


#Region "GET ACTIVE OT DETAILS" 'RasikV 20170130
    Shared Function GetFCTMstLst(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer, ByVal AppBookStat As Char) As List(Of clsFCTMstHelp)
        GetFCTMstLst = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim objArr As List(Of clsFCTMstHelp) = Nothing
            Dim obj As clsFCTMstHelp = Nothing
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFCTMst010(CoCd, Div, Loc, FCTCatCd, FCTMainCd, AppBookStat))
            If dr1.hasrows Then
                objArr = New List(Of clsFCTMstHelp)
                While dr1.Read()
                    With dr1
                        obj = New clsFCTMstHelp
                        obj.Code = IIf(IsDBNull(.Item("Cd")), 0, .Item("Cd"))
                        obj.Decode = IIf(IsDBNull(.Item("Dcd")), Nothing, .Item("Dcd"))
                    End With
                    objArr.Add(obj)
                End While
            End If
            dr1.close()
            GetFCTMstLst = objArr
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetFCTMstLst
    End Function

    Shared Function SpSelFCTMst010(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer, ByVal AppBookStat As Char) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        oRequest.Command = "[SpSelFCTMst010]" 'fct_mst
        oRequest.CommandType = CommandType.StoredProcedure
        oRequest.Transactional = True

        With oRequest
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
            oParam.ParamName = "pFCTCatCd"
            oParam.ParamValue = FCTCatCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFCTMainCd"
            oParam.ParamValue = FCTMainCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pAppBookStat"
            oParam.ParamValue = AppBookStat
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
#End Region


#Region "GET CHARGE CODE AND SERVICE CODE FOR OT CHARGE POSTING BY PASSING FCTCATCD, FCTMAINCD, FCTCD" 'RasikV 20170309
    Shared Function GetOTChrgSrvCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer, ByVal FCTCd As Integer) As clsFCTMstOTChrgSrvCd
        GetOTChrgSrvCd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelFCTMst012(CoCd, Div, Loc, FCTCatCd, FCTMainCd, FCTCd))
            Dim obj As clsFCTMstOTChrgSrvCd = Nothing
            obj = New clsFCTMstOTChrgSrvCd
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj.ChrgCd = IIf(IsDBNull(.Item("ChrgCd")), 0, .Item("ChrgCd"))
                        obj.SrvCd = IIf(IsDBNull(.Item("SrvCd")), 0, .Item("SrvCd"))
                    End With
                    GetOTChrgSrvCd = obj
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetOTChrgSrvCd
    End Function

    Shared Function SpSelFCTMst012(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal FCTCatCd As Integer, ByVal FCTMainCd As Integer, ByVal FCTCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest
            .Command = "[dbo].[SpSelFCTMst012]" 'FCT_MST
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
            oParam.ParamName = "pFctCd"
            oParam.ParamValue = FCTCd
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region

End Class

<DataContract()>
Public Class clsFCTMstHelp 'RasikV 20170130
    <DataMember()>
    Public Property Code() As Integer
    <DataMember()>
    Public Property Decode() As String
End Class


<DataContract()>
Public Class clsFCTMstOTChrgSrvCd 'RasikV 20170309
    <DataMember()>
    Public Property ChrgCd() As Integer
    <DataMember()>
    Public Property SrvCd() As Integer
End Class