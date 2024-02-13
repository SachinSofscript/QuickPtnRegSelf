Imports System.Runtime.Serialization
Imports SofCommon
Imports System
Imports System.Collections.Generic

Public Class clsServiceMaster
#Region "Properties"
    <DataMember()>
    Public Property CompanyCode As String
    <DataMember()>
    Public Property DivisionCode As Integer
    <DataMember()>
    Public Property LocationCode As Integer
    <DataMember()>
    Public Property chrgcd As Integer
    <DataMember()>
    Public Property srvcd As Integer
    <DataMember()>
    Public Property srvdesc As String
    <DataMember()>
    Public Property sectno As Integer
    <DataMember()>
    Public Property cst As Double
    <DataMember()>
    Public Property srchrgflg As String
    <DataMember()>
    Public Property emgsrvflg As String
    <DataMember()>
    Public Property cmpntcd As Integer
    <DataMember()>
    Public Property cmpnttrnpstflag As String
    <DataMember()>
    Public Property shrchrgcd As Integer
    <DataMember()>
    Public Property shrsrvcd As Integer
    <DataMember()>
    Public Property srvstscd As Integer
    <DataMember()>
    Public Property procschflg As Integer
    <DataMember()>
    Public Property crtdt As Date
    <DataMember()>
    Public Property crttm As Date
    <DataMember()>
    Public Property crtusrid As String
    <DataMember()>
    Public Property updtdt As Date
    <DataMember()>
    Public Property updttm As Date
    <DataMember()>
    Public Property updtusrid As String
    <DataMember()>
    Public Property misgrp As Integer
    <DataMember()>
    Public Property SerCatg As Integer
    <DataMember()>
    Public Property DeptCd As Integer
    <DataMember()>
    Public Property stdtime As Double
    <DataMember()>
    Public Property Surgerytypcd As Integer
    <DataMember()>
    Public Property CPTcd As String
    <DataMember()>
    Public Property HIPPAcd As String
    <DataMember()>
    Public Property ICDgrpcd As String
    <DataMember()>
    Public Property icdcd As String
    <DataMember()>
    Public Property ipopflg As String
    <DataMember()>
    Public Property manpstflg As String
    <DataMember()>
    Public Property containercd As Integer
    <DataMember()>
    Public Property sensflg As String
    <DataMember()>
    Public Property ChrgDesc As String
    <DataMember()>
    Public Property UsrId As String
    <DataMember()>
    Public Property MultipleAllow As String  'anamika 20131113
    <DataMember()>
    Public Property FractionAllow As String  'anamika 20131113
    <DataMember()>
    Public Property Sharerflg As String  'anamika 20140107
    <DataMember()>
    Public Property IsRISSrv As Boolean  'anamika 20140910
    <DataMember()>
    Public Property RecLock As Integer  'anamika 20140910
    <DataMember()>
    Public Property IsLaboratory As Boolean 'anamika 20150929
    <DataMember()>
    Public Property IsRadiology As Boolean 'anamika 20150929
    <DataMember()>
    Public Property IsSurgery As Boolean 'anamika 20150929
    <DataMember()>
    Public Property IsProcedure As Boolean 'anamika 20150929
    <DataMember()>
    Public Property IsNurseStationOrdAllow As Boolean 'anamika 20150929
    <DataMember()>
    Public Property SerCatgDesc As String 'pragya : 31-jan-2017
    <DataMember()>
    Public Property SacCd As String   'AARTI 20170622
    <DataMember()>
    Public Property GstTaxCd As Integer   'AARTI 20170622
    <DataMember()>
    Public Property UnitType As Integer   'AARTI 13 March 2018

#End Region



#Region "All Service list where service type =46(exclusively used in service master"
    ''' <summary>
    ''' All Service list where service type =46(exclusively used in service master
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="ChrgCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetSrvList(ByRef strErrMsg As List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal companycode As String, _
                                  ByVal div As Integer, _
                                  ByVal loc As Integer, _
                                  ByVal ChrgCd As Integer
                                  ) As List(Of ClsServiceMasterHelp)
        GetSrvList = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvList002(companycode, div, loc, ChrgCd))
            'declared array of class clscodedecode
            Dim objList As New List(Of ClsServiceMasterHelp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsServiceMasterHelp
                        obj.chrgcd = .item("chrg_cd")
                        obj.srvcd = .item("srv_cd")
                        obj.ChrgDesc = .item("chrg_dcd")
                        obj.srvdesc = .item("srv_desc")
                        obj.ServiceTypCd = .item("SerCatg")
                        obj.ServiceTypDCd = .item("dcd")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetSrvList = objList
            Return GetSrvList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function SpSelSrvList002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal chrgcd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest

            .Command = "[SpSelSrvList002]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = chrgcd
            .Parameters.Add(oParam)


        End With

        Return oRequest
    End Function


#End Region





#Region "Get Service List By Passing service type"
    'mayur 20140122
    ''' <summary>
    ''' Get Service List By Passing service type
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="UserId"></param>
    ''' <param name="srvtype"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetServiceListByServiceType(ByRef strErrMsg As List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal companycode As String, _
                                  ByVal div As Integer, _
                                  ByVal loc As Integer, _
                                  ByVal UserId As String, _
                                  ByVal srvtype As Integer
                                  ) As List(Of ClsServiceMasterHelp)
        GetServiceListByServiceType = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSRVLIST001(companycode, div, loc, UserId, srvtype))
            'declared array of class clscodedecode
            Dim objList As New List(Of ClsServiceMasterHelp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsServiceMasterHelp
                        obj.chrgcd = .item("chrg_cd")
                        obj.srvcd = .item("srv_cd")
                        obj.ChrgDesc = .item("chrg_dcd")
                        obj.srvdesc = .item("srv_desc")
                        obj.ServiceTypCd = .item("SerCatg")
                        obj.ServiceTypDCd = .item("SrvTypDcd")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetServiceListByServiceType = objList
            Return GetServiceListByServiceType
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function SPSELSRVLIST001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal srvtype As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest

            .Command = "[SPSELSRVLIST001]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "psrvtyp"
            oParam.ParamValue = srvtype
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function

    'end mayur 20140122
#End Region



#Region "function to retrieve data from service master"
    'anamika 20131113
    ''' <summary>
    ''' function to retrieve data from service master
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="srvcd"></param>
    ''' <param name="chrgcd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetSrvMstDtlWithoutUser(ByRef strErrMsg As List(Of String), _
                                   ByRef chrErrFlg As Char, _
                                   ByVal companycode As String, _
                                   ByVal div As Integer, _
                                   ByVal loc As Integer, _
                                   ByVal srvcd As Integer, _
                                   ByVal chrgcd As Integer, _
                                         Optional ByVal StatusFlg As Boolean = True) As clsServiceMaster 'new parameter statusflg added by anamika on 20140910

        GetSrvMstDtlWithoutUser = Nothing

        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSRVCHRG001(companycode, div, loc, srvcd, chrgcd, StatusFlg))
            'declared array of class clscodedecode
            Dim obj As New clsServiceMaster
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1

                        obj.CompanyCode = companycode '.item("") 'companycode
                        obj.DivisionCode = div '.item("") 'div
                        obj.LocationCode = loc '.item("") 'loc
                        obj.chrgcd = .item("chrg_cd")
                        obj.srvcd = .item("srv_cd")
                        obj.srvdesc = .item("srv_desc")
                        obj.sectno = .item("sect_no")
                        obj.cst = IIf(IsDBNull(dr1.Item("cst")), 0, dr1.Item("cst"))
                        obj.srchrgflg = .item("srchrg_flg")
                        obj.emgsrvflg = .item("emg_srv_flg")
                        obj.cmpntcd = .item("cmpnt_cd")
                        obj.cmpnttrnpstflag = .item("cmpnt_trn_pst_flag")
                        obj.shrchrgcd = .item("shr_chrg_cd")
                        obj.shrsrvcd = .item("shr_srv_cd")
                        obj.srvstscd = .item("srv_sts_cd")
                        obj.procschflg = IIf(IsDBNull(dr1.Item("proc_sch_flg")), Nothing, dr1.Item("proc_sch_flg"))
                        obj.procschflg = 0 'error'.item("proc_sch_flg")
                        obj.crtdt = IIf(IsDBNull(dr1.Item("crt_dt")), Date.MinValue, dr1.Item("crt_dt"))
                        obj.crttm = IIf(IsDBNull(dr1.Item("crt_tm")), Date.MinValue, dr1.Item("crt_tm")) 'error'.item("crt_tm")
                        obj.crtusrid = IIf(IsDBNull(dr1.Item("crt_usr_id")), "", dr1.Item("crt_usr_id")) '.item("crt_usr_id")
                        obj.updtdt = IIf(IsDBNull(dr1.Item("updt_dt")), Date.MinValue, dr1.item("updt_dt"))
                        obj.updttm = IIf(IsDBNull(dr1.Item("updt_tm")), Date.MinValue, dr1.item("updt_tm")) '.item("updt_tm")
                        obj.updtusrid = .item("updt_usr_id")
                        obj.misgrp = IIf(IsDBNull(dr1.Item("mis_grp")), Nothing, dr1.Item("mis_grp"))
                        'obj.misgrp = .item("mis_grp") 'error
                        obj.SerCatg = .item("SerCatg")
                        obj.DeptCd = .item("DeptCd")
                        obj.stdtime = IIf(IsDBNull(.item("std_time")), 0.0, .item("std_time"))
                        obj.Surgerytypcd = .item("Surgery_typ_cd")
                        obj.CPTcd = IIf(IsDBNull(.item("CPT_cd")), "", .item("CPT_cd"))
                        obj.HIPPAcd = IIf(IsDBNull(.item("HIPPA_cd")), "", .item("HIPPA_cd"))
                        obj.ICDgrpcd = IIf(IsDBNull(.item("ICDgrp_cd")), "", .item("ICDgrp_cd"))
                        obj.icdcd = IIf(IsDBNull(.item("icd_cd")), "", .item("icd_cd"))
                        obj.ipopflg = IIf(IsDBNull(.item("ip_op_flg")), "", .item("ip_op_flg"))
                        obj.manpstflg = IIf(IsDBNull(.item("man_pst_flg")), "", .item("man_pst_flg"))
                        obj.containercd = IIf(IsDBNull(dr1.Item("container_cd")), Nothing, dr1.Item("container_cd"))
                        obj.sensflg = IIf(IsDBNull(dr1.Item("sens_flg")), Nothing, dr1.Item("sens_flg"))
                        obj.FractionAllow = IIf(IsDBNull(dr1.Item("fraction_allow")), Nothing, dr1.Item("fraction_allow")) 'anamika 20131311
                        obj.MultipleAllow = IIf(IsDBNull(dr1.Item("multiple_allow")), Nothing, dr1.Item("multiple_allow")) 'anamika 20131311
                        obj.IsRISSrv = IIf(IsDBNull(dr1.Item("IsRISsrv")), False, dr1.Item("IsRISsrv")) 'anamika 20140911
                        obj.IsLaboratory = IIf(IsDBNull(dr1.Item("IsLaboratorySrv")), False, dr1.Item("IsLaboratorySrv")) 'anamika 20150929
                        obj.IsRadiology = IIf(IsDBNull(dr1.Item("IsRadiologySrv")), False, dr1.Item("IsRadiologySrv")) 'anamika 20150929
                        obj.IsSurgery = IIf(IsDBNull(dr1.Item("IsSurgerySrv")), False, dr1.Item("IsSurgerySrv")) 'anamika 20150929
                        obj.IsProcedure = IIf(IsDBNull(dr1.Item("IsProcedureSrv")), False, dr1.Item("IsProcedureSrv")) 'anamika 20150929
                        obj.IsNurseStationOrdAllow = IIf(IsDBNull(dr1.Item("IsNstTestOrdAllowed")), False, dr1.Item("IsNstTestOrdAllowed")) 'anamika 20150929
                        obj.SerCatgDesc = IIf(IsDBNull(.item("SerCatgDesc")), "", .item("SerCatgDesc"))  'pragya : 31-jan-2017
                        obj.SacCd = IIf(IsDBNull(.item("SACCD")), "", .item("SACCD"))  'aarti : 22-jun-2017
                        obj.GstTaxCd = IIf(IsDBNull(.item("GSTTAXCD")), 0, .item("GSTTAXCD"))  'aarti : 22-jun-2017
                        obj.UnitType = .item("UnitTyp")                            'aarti : 13 March 2018

                    End With

                End While
            Else
                'anamika 20141030
                If StatusFlg = 0 Then
                    strErrMsg.Add("Record No Found In Service Master for Charge Code" & " " & chrgcd & " and Service Code " & srvcd)
                    chrErrFlg = "Y"
                    GetSrvMstDtlWithoutUser = Nothing  'anamika 20170512
                Else
                    strErrMsg.Add("Record No Found In Service Master for Charge Code" & " " & chrgcd & " and Service Code " & srvcd & " Or Service is inactive")
                    chrErrFlg = "Y"
                    GetSrvMstDtlWithoutUser = Nothing 'anamika 20170512
                End If
                'anamika 20141030
                ' strErrMsg.Add("Record No Found In Service Master for Charge Code" & " " & chrgcd & " and Service Code " & srvcd)
                Return Nothing
            End If
            dr1.close()
            GetSrvMstDtlWithoutUser = obj
            Return GetSrvMstDtlWithoutUser
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try

    End Function
    ''' <summary>
    '''  function to retrieve data from service master
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="srvcd"></param>
    ''' <param name="chrgcd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELSRVCHRG001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal srvcd As Integer,
                                    ByVal chrgcd As Integer, ByVal StatusFlg As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSRVCHRG001]" 'chrg_mst,srv_mst
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pSrvCd"
            oParam.ParamValue = srvcd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = chrgcd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pStatusFlg"
            oParam.ParamValue = StatusFlg
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function
    'end 20131230
#End Region



#Region " Get Service Details by Passing Charge Code Service Code and User Id"
    ''' <summary>
    ''' Get Service Details by Passing Charge Code Service Code and User Id
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="srvcd"></param>
    ''' <param name="chrgcd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELSRVCHRG(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal srvcd As Integer, ByVal chrgcd As Integer, ByVal UserID As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSRVCHRG]" 'chrg_mst,srv_mst,srv_typ_mst
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pSrvCd"
            oParam.ParamValue = srvcd
            .Parameters.Add(oParam)



            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserID
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = chrgcd
            .Parameters.Add(oParam)


        End With

        Return oRequest
    End Function
    Shared Function GetSrvMstDtl(ByRef strErrMsg As List(Of String), _
                                   ByRef chrErrFlg As Char, _
                                   ByVal companycode As String, _
                                   ByVal div As Integer, _
                                   ByVal loc As Integer, _
                                   ByVal srvcd As Integer, _
                                   ByVal chrgcd As Integer, _
                                   ByVal UserId As String
                                   ) As clsServiceMaster

        GetSrvMstDtl = Nothing

        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSRVCHRG(companycode, div, loc, srvcd, chrgcd, UserId))
            'declared array of class clscodedecode
            Dim obj As New clsServiceMaster
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1

                        obj.CompanyCode = 1 '.item("") 'companycode
                        obj.DivisionCode = 1 '.item("") 'div
                        obj.LocationCode = 1 '.item("") 'loc
                        obj.chrgcd = .item("chrg_cd")
                        obj.srvcd = .item("srv_cd")
                        obj.srvdesc = .item("srv_desc")
                        obj.sectno = .item("sect_no")
                        obj.cst = IIf(IsDBNull(dr1.Item("cst")), 0, dr1.Item("cst")) '.item("sect_no") anamika 20140616
                        obj.srchrgflg = .item("srchrg_flg")
                        obj.emgsrvflg = .item("emg_srv_flg")
                        obj.cmpntcd = .item("cmpnt_cd")
                        obj.cmpnttrnpstflag = .item("cmpnt_trn_pst_flag")
                        obj.shrchrgcd = .item("shr_chrg_cd")
                        obj.shrsrvcd = .item("shr_srv_cd")
                        obj.srvstscd = .item("srv_sts_cd")
                        obj.procschflg = IIf(IsDBNull(dr1.Item("proc_sch_flg")), Nothing, dr1.Item("proc_sch_flg"))
                        obj.procschflg = 0 'error'.item("proc_sch_flg")
                        obj.crtdt = .item("crt_dt")
                        obj.crttm = IIf(IsDBNull(dr1.Item("crt_tm")), Nothing, dr1.Item("crt_tm")) 'error'.item("crt_tm")
                        obj.crtusrid = .item("crt_usr_id")
                        obj.updtdt = .item("updt_dt")
                        obj.updttm = IIf(IsDBNull(dr1.Item("updt_tm")), Date.MinValue, dr1.Item("updt_tm")) 'ANAMIKA 20160301
                        obj.updtusrid = .item("updt_usr_id")
                        obj.misgrp = IIf(IsDBNull(dr1.Item("mis_grp")), Nothing, dr1.Item("mis_grp"))
                        ' obj.misgrp = .item("mis_grp") 'error
                        obj.SerCatg = .item("SerCatg")
                        obj.DeptCd = .item("DeptCd")
                        obj.stdtime = IIf(IsDBNull(.item("std_time")), 0.0, .item("std_time"))
                        obj.Surgerytypcd = .item("Surgery_typ_cd")
                        obj.CPTcd = IIf(IsDBNull(.item("CPT_cd")), "", .item("CPT_cd"))
                        obj.HIPPAcd = IIf(IsDBNull(.item("HIPPA_cd")), "", .item("HIPPA_cd"))
                        obj.ICDgrpcd = IIf(IsDBNull(.item("ICDgrp_cd")), "", .item("ICDgrp_cd"))
                        obj.icdcd = IIf(IsDBNull(.item("icd_cd")), "", .item("icd_cd"))
                        obj.ipopflg = IIf(IsDBNull(.item("ip_op_flg")), "", .item("ip_op_flg"))
                        obj.manpstflg = IIf(IsDBNull(.item("man_pst_flg")), "", .item("man_pst_flg"))
                        obj.containercd = IIf(IsDBNull(dr1.Item("container_cd")), Nothing, dr1.Item("container_cd"))

                        obj.sensflg = IIf(IsDBNull(dr1.Item("sens_flg")), Nothing, dr1.Item("sens_flg"))
                        obj.FractionAllow = IIf(IsDBNull(dr1.Item("fraction_allow")), Nothing, dr1.Item("fraction_allow")) 'anamika 20131311
                        obj.MultipleAllow = IIf(IsDBNull(dr1.Item("multiple_allow")), Nothing, dr1.Item("multiple_allow")) 'anamika 20131311
                        obj.Sharerflg = IIf(IsDBNull(dr1.Item("shareflg")), Nothing, dr1.Item("shareflg")) 'mayur 20140107

                        obj.GstTaxCd = IIf(IsDBNull(dr1.Item("GSTTAXCD")), 0, dr1.Item("GSTTAXCD")) 'Pramila 20170627
                    End With

                End While
            Else
                strErrMsg.Add("Record No Found In Service Master for Charge Code" & " " & chrgcd & " and Service Code " & srvcd)
                Return Nothing
            End If
            dr1.close()
            GetSrvMstDtl = obj
            Return GetSrvMstDtl
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try

    End Function

#End Region

#Region " Get Service List By Passing Charge Code and User Id   ,if chrg code is zero then it will show all services "
    ''' <summary>
    ''' Get Service List By Passing Charge Code and User Id   ,if chrg code is zero then it will show all services 
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="UserId"></param>
    ''' <param name="chrgcd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetServiceList(ByRef strErrMsg As List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal companycode As String, _
                                  ByVal div As Integer, _
                                  ByVal loc As Integer, _
                                  ByVal UserId As String, _
                                  ByVal chrgcd As Integer
                                  ) As List(Of ClsServiceMasterHelp)
        GetServiceList = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(GETSPSELSRVLIST(companycode, div, loc, UserId, chrgcd))
            'declared array of class clscodedecode
            Dim objList As New List(Of ClsServiceMasterHelp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsServiceMasterHelp
                        obj.chrgcd = .item("chrg_cd")
                        obj.srvcd = .item("srv_cd")
                        obj.ChrgDesc = .item("chrg_dcd")
                        obj.srvdesc = .item("srv_desc")
                        obj.ServiceTypCd = .item("SerCatg")
                        obj.ServiceTypDCd = .item("SrvTypDcd")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetServiceList = objList
            Return GetServiceList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function GETSPSELSRVLIST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal chrgcd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSRVLIST]" 'chrg_mst  user_chrg  srv_mst  srv_typ_mst
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = chrgcd
            .Parameters.Add(oParam)
        End With

        Return oRequest
    End Function

#End Region

#Region "Get List of all Department and Services accessible to user"
    ''' <summary>
    '''    Get List of all Department and Services accessible to user
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="UserId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetUsersChargeServiceList(ByRef strErrMsg As List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal companycode As String, _
                                  ByVal div As Integer, _
                                  ByVal loc As Integer, _
                                  ByVal UserId As String
                                  ) As List(Of clsServiceMaster)
        GetUsersChargeServiceList = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(GETSPSELUSRCHRGSRVLIST(companycode, div, loc, UserId))
            'declared array of class clscodedecode
            Dim objList As New List(Of clsServiceMaster)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New clsServiceMaster
                        obj.chrgcd = .item("chrg_cd")
                        obj.srvcd = .item("srv_cd")
                        obj.ChrgDesc = .item("chrg_dcd")
                        obj.srvdesc = .item("srv_desc")
                        obj.UsrId = .item("Usr_id")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetUsersChargeServiceList = objList
            Return GetUsersChargeServiceList
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function GETSPSELUSRCHRGSRVLIST(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELUSRCHRGSRVLIST]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function
#End Region



#Region "Service master details by type" 'mayur 20150128



    Shared Function GetServiceListByServiceType(ByRef strErrMsg As List(Of String), _
                                 ByRef chrErrFlg As Char, _
                                ByVal companycode As String, _
                               ByVal div As Integer, _
                               ByVal loc As Integer, ByVal pdepartmentcode As Integer, _
                               ByVal pchargecode As Integer, _
                               ByVal pPTNLSTUSE As Integer
                                 ) As List(Of ClsSrvMstByType)
        GetServiceListByServiceType = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(FILLSEPSRV(companycode, div, loc, pdepartmentcode, pchargecode, pPTNLSTUSE))
            Dim objList As New List(Of ClsSrvMstByType)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsSrvMstByType
                        obj.ServiceCode = .Item("ServiceCode")
                        obj.ServiceDescription = .Item("ServiceDescription")
                        obj.ChargeCode = .Item("ChargeCode")
                        obj.Cmpntcd = .Item("cmpnt_cd")  'anamika 20161001
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetServiceListByServiceType = objList
            Return GetServiceListByServiceType
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function FILLSEPSRV(ByVal pcompanycode As String, _
                               ByVal pdiv As Integer, _
                               ByVal ploc As Integer, ByVal pdepartmentcode As Integer, _
                               ByVal pchargecode As Integer, _
                               ByVal pPTNLSTUSE As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest


            oRequest.Command = "[SPSELSTDDEPORDSRV]"
            oRequest.CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pdeptcd"
            oParam.ParamValue = pdepartmentcode
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pchrgcd"
            oParam.ParamValue = pchargecode
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "srvtyp"
            oParam.ParamValue = pPTNLSTUSE
            oRequest.Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region

#Region "Get Service List By Passing service type ,user id,ipopflag and sharer existance"
    'mayur 20140122
    ''' <summary>
    ''' Get Service List By Passing service type
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="UserId"></param>
    ''' <param name="srvtype"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetSrvLstBySrvTypSexFlgUserNstTstOrdAllow(ByRef strErrMsg As List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal companycode As String, _
                                  ByVal div As Integer, _
                                  ByVal loc As Integer, _
                                  ByVal UserId As String, _
                                  ByVal srvtype As Integer, ByVal IpOpFlg As Char, ByVal IsNstTestOrdAllowed As Boolean) As List(Of ClsServiceMasterHelp)
        Dim oRequest As DBRequest = New DBRequest
        GetSrvLstBySrvTypSexFlgUserNstTstOrdAllow = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst003(companycode, div, loc, UserId, srvtype, IpOpFlg, IsNstTestOrdAllowed))
            'declared array of class clscodedecode
            Dim objList As New List(Of ClsServiceMasterHelp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsServiceMasterHelp
                        obj.chrgcd = .item("DepartmentCode")
                        obj.srvcd = .item("srv_cd")
                        obj.ChrgDesc = .item("DepartmentName")
                        obj.srvdesc = .item("srv_desc")
                        obj.ServiceTypCd = 0
                        obj.ServiceTypDCd = ""
                        obj.SharerExist = .item("IsShrExist")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetSrvLstBySrvTypSexFlgUserNstTstOrdAllow = objList
            Return GetSrvLstBySrvTypSexFlgUserNstTstOrdAllow
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function SpSelSrvMst003(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal srvtype As Integer, ByVal IpOpFlg As Char, ByVal IsNstTestOrdAllowed As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest

            .Command = "[SpSelSrvMst003]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pUsrId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "psrvtyp"
            oParam.ParamValue = srvtype
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpOpFlg"
            oParam.ParamValue = UCase(IpOpFlg)
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIsNstTestOrdAllowed"
            oParam.ParamValue = IsNstTestOrdAllowed
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function


#End Region





#Region "Get Service Details by Passing Charge Code Service Code and User Id,ipop flag and srvtype"
    ''' <summary>
    ''' Get Service Details by Passing Charge Code Service Code and User Id,ipop flag and srvtype
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="srvcd"></param>
    ''' <param name="chrgcd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELSRVCHRG002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal srvcd As Integer, ByVal chrgcd As Integer, ByVal UserID As String, ByVal IpOpFlag As String, ByVal SrvType As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSRVCHRG002]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pSrvCd"
            oParam.ParamValue = srvcd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserID
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = chrgcd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpOpFlag"
            oParam.ParamValue = IpOpFlag
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSrvType"
            oParam.ParamValue = SrvType
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
    Shared Function GetSrvMstDtlByIpOpFlagSrvType(ByRef strErrMsg As List(Of String), _
                                 ByRef chrErrFlg As Char, _
                                 ByVal companycode As String, _
                                 ByVal div As Integer, _
                                 ByVal loc As Integer, _
                                 ByVal srvcd As Integer, _
                                 ByVal chrgcd As Integer, _
                                 ByVal UserId As String, ByVal IpOpFlag As String, ByVal SrvType As Integer
                                 ) As ClsServiceMasterDtl

        GetSrvMstDtlByIpOpFlagSrvType = Nothing

        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSRVCHRG002(companycode, div, loc, srvcd, chrgcd, UserId, IpOpFlag, SrvType))
            'declared array of class clscodedecode
            Dim obj As New ClsServiceMasterDtl
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj.srvdesc = .item("srv_desc")
                        obj.emgsrvflg = .item("emg_srv_flg")
                        obj.cmpntcd = .item("cmpnt_cd")
                        obj.manpstflg = IIf(IsDBNull(.item("man_pst_flg")), "", .item("man_pst_flg"))
                        obj.FractionAllow = IIf(IsDBNull(dr1.Item("fraction_allow")), Nothing, dr1.Item("fraction_allow"))
                        obj.MultipleAllow = IIf(IsDBNull(dr1.Item("multiple_allow")), Nothing, dr1.Item("multiple_allow"))
                        obj.SharerExist = IIf(IsDBNull(dr1.Item("shareflg")), False, dr1.Item("shareflg"))
                    End With
                End While
            Else
                strErrMsg.Add("Record No Found In Service Master for Charge Code" & " " & chrgcd & " and Service Code " & srvcd)
                Return Nothing
            End If
            dr1.close()
            GetSrvMstDtlByIpOpFlagSrvType = obj
            Return GetSrvMstDtlByIpOpFlagSrvType
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
#End Region


#Region "Get service list for specific charge type"


    Public Shared Function GetSrvHelpWithMultipleParam(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                   ByRef chrErrFlg As Char, _
                                   ByVal pcompanycode As String, _
                                   ByVal pdiv As Integer, _
                                   ByVal ploc As Integer, _
                                   ByVal pUsrId As String, _
                                   ByVal psrvtyp As Integer, _
                                   ByVal pchrgcd As Integer, _
                                   ByVal pIpOpFlg As Char, _
                                   ByVal pIsNstTestOrdAllowed As Boolean) As List(Of clsSrvMst)
        GetSrvHelpWithMultipleParam = Nothing
        Dim ofactory As New DBFactory
        Dim objarrservice = New List(Of clsSrvMst)
        Dim dr1 As Object
        Try
            dr1 = ofactory.ExecuteDataReader(SpSelSrvMst004(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, pUsrId, psrvtyp, pchrgcd, pIpOpFlg, pIsNstTestOrdAllowed))
            '  If dr1.hasrows Then
            If dr1.hasrows Then
                While dr1.read()
                    With dr1
                        Dim objservice As New clsSrvMst

                        objservice.srvcd = .Item("ServiceCode")
                        objservice.srvdesc = .Item("ServiceDescription")
                        objarrservice.Add(objservice)
                    End With
                End While
            Else
                objarrservice = Nothing
            End If
            Return objarrservice
        Catch ex As Exception
            GetSrvHelpWithMultipleParam = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function


    Shared Function SpSelSrvMst004(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                         ByRef chrErrFlg As Char, _
                         ByVal pcompanycode As String, _
                         ByVal pdiv As Integer, _
                         ByVal ploc As Integer,
                           ByVal pUsrId As String, _
                                   ByVal psrvtyp As Integer, _
                                   ByVal pchrgcd As Integer, _
                                   ByVal pIpOpFlg As Char, _
                                   ByVal pIsNstTestOrdAllowed As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest
            .Command = "[SpSelSrvMst004]" 'chrg_mst,srv_mst

            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUsrId"
            oParam.ParamValue = pUsrId
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "psrvtyp"
            oParam.ParamValue = psrvtyp
            oRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pchrgcd"
            oParam.ParamValue = pchrgcd
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpOpFlg"
            oParam.ParamValue = pIpOpFlg
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIsNstTestOrdAllowed"
            oParam.ParamValue = pIsNstTestOrdAllowed
            oRequest.Parameters.Add(oParam)

        End With

        Return oRequest
    End Function

#End Region






#Region "To Get Service Master & Charge Master Details By Passing Mod Cd ,Sub Mod cd & prefix"
    'APARNA 20 NOV 205
    ''' <summary>
    ''' To  Get Service Master & Charge Master Details By Passing Mod Cd ,Sub Mod cd & prefix
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="ModCd"></param>
    ''' <param name="SubModCd"></param>
    ''' <param name="IpOpFlg"></param>
    ''' <param name="Prefix"></param>
    ''' <param name="UserId"></param>
    ''' <param name="srvtype"></param>
    ''' <param name="IsNstTestOrdAllowed"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetSrvLstByModSubModCdPrefix(ByRef strErrMsg As List(Of String), _
                                           ByRef chrErrFlg As Char, _
                                           ByVal cocd As String, _
                                           ByVal div As Integer, _
                                           ByVal loc As Integer, _
                                           ByVal ModCd As Integer, _
                                           ByVal SubModCd As Integer, _
                                           ByVal IpOpFlg As Char, _
                                           ByVal Prefix As String, _
                                           ByVal UserId As String, _
                                           ByVal srvtype As Integer, _
                                           ByVal IsNstTestOrdAllowed As Boolean
                                            ) As List(Of ClsSrvMstMainHelp)
        Dim oRequest As DBRequest = New DBRequest
        GetSrvLstByModSubModCdPrefix = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSRVMST005(cocd, div, loc, ModCd, SubModCd, IpOpFlg, Prefix, UserId, srvtype, IsNstTestOrdAllowed))
            'declared array of class clscodedecode
            Dim objList As New List(Of ClsSrvMstMainHelp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsSrvMstMainHelp
                        obj.chrgcd = .item("chrgcd")
                        obj.srvcd = .item("srvcd")
                        obj.ChrgDesc = .item("ChrgDesc")
                        obj.srvdesc = .item("srvdesc")
                        obj.SharerExist = .item("IsShrExist")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetSrvLstByModSubModCdPrefix = objList
            Return GetSrvLstByModSubModCdPrefix
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function SPSELSRVMST005(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal IpOpFlg As Char, ByVal Prefix As String, ByVal UserId As String, ByVal srvtype As Integer, ByVal IsNstTestOrdAllowed As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest

            .Command = "[SPSELSRVMST005]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV "
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

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpOpFlg"
            oParam.ParamValue = IpOpFlg
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPrefix"
            oParam.ParamValue = Prefix
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUsrId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "psrvtyp"
            oParam.ParamValue = srvtype
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIsNstTestOrdAllowed"
            oParam.ParamValue = IsNstTestOrdAllowed
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter

        End With

        Return oRequest
    End Function


#End Region


#Region "To Get Service Master & Charge Master Details By Passing Mod Cd ,Sub Mod cd"
    'APARNA 20 NOV 205
    ''' <summary>
    ''' To  Get Service Master & Charge Master Details By Passing Mod Cd ,Sub Mod cd
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="ModCd"></param>
    ''' <param name="SubModCd"></param>
    ''' <param name="IpOpFlg"></param>
    ''' <param name="Prefix"></param>
    ''' <param name="UserId"></param>
    ''' <param name="srvtype"></param>
    ''' <param name="IsNstTestOrdAllowed"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetSrvLstByUserIdModSubModCd(ByRef strErrMsg As List(Of String), _
                                           ByRef chrErrFlg As Char, _
                                           ByVal cocd As String, _
                                           ByVal div As Integer, _
                                           ByVal loc As Integer, _
                                           ByVal ModCd As Integer, _
                                           ByVal SubModCd As Integer, _
                                           ByVal IpOpFlg As Char, _
                                           ByVal UserId As String, _
                                           ByVal srvtype As Integer, _
                                           ByVal IsNstTestOrdAllowed As Boolean
                                            ) As List(Of ClsSrvMstMainHelp)
        Dim oRequest As DBRequest = New DBRequest
        GetSrvLstByUserIdModSubModCd = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSRVMST006(cocd, div, loc, ModCd, SubModCd, IpOpFlg, UserId, srvtype, IsNstTestOrdAllowed))
            'declared array of class clscodedecode
            Dim objList As New List(Of ClsSrvMstMainHelp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsSrvMstMainHelp
                        obj.chrgcd = .item("chrgcd")
                        obj.srvcd = .item("srvcd")
                        obj.ChrgDesc = .item("ChrgDesc")
                        obj.srvdesc = .item("srvdesc")
                        obj.SharerExist = .item("IsShrExist")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetSrvLstByUserIdModSubModCd = objList
            Return GetSrvLstByUserIdModSubModCd
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function SPSELSRVMST006(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal ModCd As Integer, ByVal SubModCd As Integer, ByVal IpOpFlg As Char, ByVal UserId As String, ByVal srvtype As Integer, ByVal IsNstTestOrdAllowed As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest

            .Command = "[SPSELSRVMST006]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV "
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

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpOpFlg"
            oParam.ParamValue = IpOpFlg
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUsrId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "psrvtyp"
            oParam.ParamValue = srvtype
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIsNstTestOrdAllowed"
            oParam.ParamValue = IsNstTestOrdAllowed
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter

        End With

        Return oRequest
    End Function


#End Region

#Region "Get Service Mst Detail by mod cd,sub mod cd,userid, charg id"
    'APARNA 21 NOV 2015
    'used in ip post voucher 20151121
    ''' <summary>
    '''  Get Service Mst Detail by mod cd,sub mod cd,userid, charg id"
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="UserId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetSrvMstDtlByUserIdModSubmodcd(ByRef strErrMsg As List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal companycode As String, _
                                  ByVal div As Integer, _
                                  ByVal loc As Integer, _
                                  ByVal srvcd As Integer, _
                                  ByVal chrgcd As Integer, _
                                  ByVal UserId As String, _
                                  ByVal ModCd As Integer,
                                  ByVal SubModCd As Integer,
                                  ByVal IpOpFlg As Char,
                                  ByVal srvtype As Integer,
                                  ByVal IsNstTestOrdAllowed As Boolean
                                  ) As ClsServiceMasterDtl

        GetSrvMstDtlByUserIdModSubmodcd = Nothing

        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSRVMST007(companycode, div, loc, srvcd, chrgcd, UserId, ModCd, SubModCd, IpOpFlg, srvtype, IsNstTestOrdAllowed))
            'declared array of class clscodedecode
            Dim obj As New ClsServiceMasterDtl
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj.srvcd = .item("srv_cd")
                        obj.srvdesc = .item("srv_desc")
                        obj.emgsrvflg = .item("emg_srv_flg")
                        obj.cmpntcd = .item("cmpnt_cd")
                        obj.FractionAllow = IIf(IsDBNull(dr1.Item("fraction_allow")), Nothing, dr1.Item("fraction_allow"))
                        obj.MultipleAllow = IIf(IsDBNull(dr1.Item("multiple_allow")), Nothing, dr1.Item("multiple_allow"))
                        obj.manpstflg = IIf(IsDBNull(.item("man_pst_flg")), "", .item("man_pst_flg")) 'mayur 20160315
                        obj.SharerExist = IIf(IsDBNull(dr1.Item("shareflg")), False, dr1.Item("shareflg")) 'mayur 20160315
                        obj.GstTaxCd = IIf(IsDBNull(dr1.Item("GSTTAXCD")), 0, dr1.Item("GSTTAXCD"))   'RasikV 20170701
                        obj.SrvTyp = IIf(IsDBNull(dr1.Item("SrvTyp")), Nothing, dr1.Item("SrvTyp"))   'RasikV 20180510


                    End With

                End While
            Else
                strErrMsg.Add("Record No Found In Service Master for Charge Code" & " " & chrgcd & " and Service Code " & srvcd)
                Return Nothing
            End If
            dr1.close()
            GetSrvMstDtlByUserIdModSubmodcd = obj
            Return GetSrvMstDtlByUserIdModSubmodcd
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try

    End Function


    Shared Function SPSELSRVMST007(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal srvcd As Integer, ByVal chrgcd As Integer, ByVal UserID As String, ByVal ModCd As Integer,
                                  ByVal SubModCd As Integer, ByVal IpOpFlg As Char, ByVal srvtype As Integer, ByVal IsNstTestOrdAllowed As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSRVMST007]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pSrvCd"
            oParam.ParamValue = srvcd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserID
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = chrgcd
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
            oParam.ParamName = "pIpOpFlg"
            oParam.ParamValue = IpOpFlg
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "psrvtyp"
            oParam.ParamValue = srvtype
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIsNstTestOrdAllowed"
            oParam.ParamValue = IsNstTestOrdAllowed
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function
#End Region


#Region "get service desc by passing charge & service code "

    ''' <summary>
    ''' get service desc by passing charge & service code
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="chrgcd"></param>
    ''' <param name="chkstatus"></param>
    ''' <returns>APARNA 19 FEB 2016</returns>
    ''' <remarks></remarks>
    Shared Function GetSrvDescByChrgCD(ByRef strErrMsg As List(Of String), _
                        ByRef chrErrFlg As Char, _
                        ByVal cocd As String, _
                        ByVal div As Integer, _
                        ByVal loc As Integer, _
                        ByVal chrgcd As Integer, _
                        ByVal srvcd As Integer, _
                        ByVal chkstatus As Boolean) As String

        Dim ofactory As DBFactory
        GetSrvDescByChrgCD = 0
        ofactory = New DBFactory
        Try

            Dim ds As DataSet = ofactory.ExecuteDataSet(FNSrvMst001(cocd, div, loc, chrgcd, srvcd, chkstatus))
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    GetSrvDescByChrgCD = IIf(IsDBNull(ds.Tables(0).Rows(i).Item(0)), 0, ds.Tables(0).Rows(i).Item(0))
                Next
            End If
            ds.Dispose()
        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetSrvDescByChrgCD = Nothing
            Return GetSrvDescByChrgCD
        End Try

    End Function

    Shared Function FNSrvMst001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal chrgcd As Integer, ByVal srvcd As Integer, ByVal chkstatus As Boolean) As DBRequest

        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        With orequest
            orequest.Command = "SELECT dbo.[fnSrvMst001]('" & companycode & "','" & div & "','" & loc & "','" & chrgcd & "','" & srvcd & "','" & chkstatus & "') srvdesc"
        End With
        Return orequest
    End Function


#End Region



#Region "GetSrvLstByModSubModCdSrvCatCd/SPSELSRVMST008 To Get Service DESC s By Passing Mod Cd ,Sub Mod cd &  SERVICE CATEGORY = 3(SURGICAL PROCEDURES)"
    'PRAGYA : 09-OCT-2016
    Shared Function GetSrvLstByModSubModCdSrvCatCd(ByRef strErrMsg As List(Of String), _
                                           ByRef chrErrFlg As Char, _
                                           ByVal cocd As String, _
                                           ByVal div As Integer, _
                                           ByVal loc As Integer, _
                                           ByVal SrvCatCd As Integer, _
                                           ByVal ChrgCd As Integer, _
                                           ByVal ModCd As Integer, _
                                           ByVal SubModCd As Integer, _
                                           ByVal IpOpFlg As Char, _
                                           ByVal UserId As String, _
                                           ByVal srvtype As Integer, _
                                           ByVal IsNstTestOrdAllowed As Boolean
                                            ) As List(Of clsSrvMstSurgCatServices)
        Dim oRequest As DBRequest = New DBRequest
        GetSrvLstByModSubModCdSrvCatCd = Nothing
        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSRVMST008(cocd, div, loc, SrvCatCd, ChrgCd, ModCd, SubModCd, IpOpFlg, UserId, srvtype, IsNstTestOrdAllowed))
            'declared array of class clscodedecode
            Dim objList As New List(Of clsSrvMstSurgCatServices)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New clsSrvMstSurgCatServices
                        obj.chrgcd = .item("chrgcd")
                        obj.srvcd = .item("srvcd")
                        obj.ChrgDesc = .item("ChrgDesc")
                        obj.srvdesc = .item("srvdesc")
                        obj.SurgeySrvDtls = .item("SurgSvdSrvCd")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetSrvLstByModSubModCdSrvCatCd = objList
            Return GetSrvLstByModSubModCdSrvCatCd
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

    Shared Function SPSELSRVMST008(ByVal cocd As String,
                                   ByVal div As Integer,
                                   ByVal loc As Integer,
                                   ByVal SrvCatCd As Integer,
                                   ByVal ChrgCd As Integer, _
                                   ByVal ModCd As Integer,
                                   ByVal SubModCd As Integer,
                                   ByVal IpOpFlg As Char,
                                   ByVal UserId As String,
                                   ByVal srvtype As Integer,
                                   ByVal IsNstTestOrdAllowed As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest

            .Command = "[SPSELSRVMST008]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV "
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSrvCat"
            oParam.ParamValue = SrvCatCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = ChrgCd
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
            oParam.ParamName = "pIpOpFlg"
            oParam.ParamValue = ipopflg
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUsrId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "psrvtyp"
            oParam.ParamValue = srvtype
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIsNstTestOrdAllowed"
            oParam.ParamValue = IsNstTestOrdAllowed
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter

        End With

        Return oRequest
    End Function


#End Region


#Region "GetSrvListOtSch/SpSelSrvMst009 : All Service list where service type =47 and srvmst.SerCatg =3(exclusively used in OT SCHEDULING)"
    'pragya : 11-OCT-2016
    Shared Function GetSrvListOtSch(ByRef strErrMsg As List(Of String),
                                  ByRef chrErrFlg As Char,
                                  ByVal companycode As String,
                                  ByVal div As Integer,
                                  ByVal loc As Integer, ByVal Srvdesc As String) As List(Of ClsOtSrvLstDtls)
        GetSrvListOtSch = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst009(companycode, div, loc, Srvdesc))
            'declared array of class clscodedecode
            Dim objList As New List(Of ClsOtSrvLstDtls)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsOtSrvLstDtls
                        obj.chrgcd = .item("ChrgCd")
                        obj.ChrgDesc = .item("ChrgDesc")
                        obj.srvcd = .item("SrvCd")
                        obj.srvdesc = .item("SrvDesc")
                        obj.SrvTypCd = .item("SurgTypCd")
                        obj.SrvTypDesc = .item("SurgTypDesc")
                        obj.SrvRate = "0.00"
                        obj.SrvDiagnosis = ""
                        obj.AnesTypCd = 0
                        obj.AnesTypDesc = ""
                        'obj.SrvParamCd = 0
                        'obj.SrvParamName = ""
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetSrvListOtSch = objList
            Return GetSrvListOtSch
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function

    Shared Function SpSelSrvMst009(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal Srvdesc As String) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest

            .Command = "[SpSelSrvMst009]"
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "srvdec"
            oParam.ParamValue = Srvdesc
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function


#End Region

#Region "GetSrvCdDescByChrgPkgSrvGrpCd/SpSelSrvMst010 :Get the SrvCd & SrvDesc By passing the ChrgCd / PkgCD / PkgSrvGrpCd"
    'pragya : 10-nov-2016
    Shared Function GetSrvCdDescByChrgPkgSrvGrpCd(ByRef strErrMsg As List(Of String), _
                                      ByRef chrErrFlg As Char, _
                                      ByVal cocd As String, _
                                      ByVal div As Integer, _
                                      ByVal loc As Integer,
                                      ByVal ChrgCd As Integer,
                                      ByVal PkgCd As Integer,
                                      ByVal PkgSrvGrpCd As Integer) As List(Of ClsSrvMstIpPackageHelp)
        Dim ofactory As New DBFactory

        GetSrvCdDescByChrgPkgSrvGrpCd = Nothing
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst010(strErrMsg, chrErrFlg, cocd, div, loc, ChrgCd, PkgCd, PkgSrvGrpCd))
            Dim arrObjSrv = New List(Of ClsSrvMstIpPackageHelp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim objSrv As New ClsSrvMstIpPackageHelp
                        objSrv.srvcd = .Item("SrvCd")
                        objSrv.srvdesc = .Item("SrvDesc")
                        objSrv.chrgcd = 0
                        objSrv.ChrgDesc = ""
                        objSrv.chrgcd = .Item("Chrgcd")          'pragya : 20161118
                        objSrv.ChrgDesc = .Item("Chrgdesc")      'pragya : 20161118
                        objSrv.MaxQty = 1           'pragya : 20161118
                        objSrv.chkForSelect = False     'alpesh 20161127
                        arrObjSrv.Add(objSrv)
                    End With
                End While
            End If
            dr1.close()
            GetSrvCdDescByChrgPkgSrvGrpCd = arrObjSrv
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetSrvCdDescByChrgPkgSrvGrpCd
    End Function

    Shared Function SpSelSrvMst010(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                         ByRef chrErrFlg As Char,
                                         ByVal CoCd As String,
                                         ByVal Div As Integer,
                                         ByVal Loc As Integer,
                                         ByVal ChrgCd As Integer,
                                         ByVal PkgCd As Integer,
                                         ByVal PkgSrvGrpCd As Integer) As DBRequest

        SpSelSrvMst010 = Nothing

        Dim oParam As DBRequest.Parameter
        Try
            Dim oRequest As New DBRequest
            With oRequest
                .Command = "[SpSelSrvMst010]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCocd"
                oParam.ParamValue = CoCd
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
                oParam.ParamName = "pChrgCd"
                oParam.ParamValue = ChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pPkgcd"
                oParam.ParamValue = PkgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pPkgSrvGrpCd"
                oParam.ParamValue = PkgSrvGrpCd
                .Parameters.Add(oParam)

            End With

            SpSelSrvMst010 = oRequest
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpSelSrvMst010 = Nothing
        End Try

        Return SpSelSrvMst010

    End Function

#End Region

#Region "GetSrvCdDescByChrgCdSrvDescUsrId/SpSelSrvMst011 : Get the SrvCd/SrvDesc/Chrgcd/ChrgDesc By passing the ChrgCd-SrvDesc-UsrId"
    'pragya : 11-nov-2016
    Shared Function GetSrvCdDescByChrgCdSrvDescUsrId(ByRef strErrMsg As List(Of String), _
                                      ByRef chrErrFlg As Char, _
                                      ByVal cocd As String, _
                                      ByVal div As Integer, _
                                      ByVal loc As Integer,
                                      ByVal ChrgCd As Integer,
                                      ByVal SrvDesc As String,
                                      ByVal UsrId As String) As List(Of ClsSrvMstIpPackageHelp)
        Dim ofactory As New DBFactory

        GetSrvCdDescByChrgCdSrvDescUsrId = Nothing
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst011(strErrMsg, chrErrFlg, cocd, div, loc, ChrgCd, SrvDesc, UsrId))
            Dim arrObjSrv = New List(Of ClsSrvMstIpPackageHelp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim objSrv As New ClsSrvMstIpPackageHelp
                        objSrv.srvcd = .Item("srv_cd")
                        objSrv.srvdesc = .Item("srv_desc")
                        objSrv.chrgcd = .Item("chrg_cd")
                        objSrv.ChrgDesc = .Item("CHRG_DCD")
                        objSrv.MaxQty = 1        'pragya : 20161118
                        arrObjSrv.Add(objSrv)
                    End With
                End While
            End If
            dr1.close()
            GetSrvCdDescByChrgCdSrvDescUsrId = arrObjSrv
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetSrvCdDescByChrgCdSrvDescUsrId
    End Function

    Shared Function SpSelSrvMst011(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                         ByRef chrErrFlg As Char,
                                         ByVal CoCd As String,
                                         ByVal Div As Integer,
                                         ByVal Loc As Integer,
                                         ByVal ChrgCd As Integer,
                                         ByVal SrvDesc As String,
                                         ByVal UsrId As String) As DBRequest

        SpSelSrvMst011 = Nothing

        Dim oParam As DBRequest.Parameter
        Try
            Dim oRequest As New DBRequest
            With oRequest
                .Command = "[SpSelSrvMst011]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCocd"
                oParam.ParamValue = CoCd
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
                oParam.ParamName = "pChrgCd"
                oParam.ParamValue = ChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pSrvDesc"
                oParam.ParamValue = SrvDesc
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pUsrId"
                oParam.ParamValue = UsrId
                .Parameters.Add(oParam)

            End With

            SpSelSrvMst011 = oRequest
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpSelSrvMst011 = Nothing
        End Try

        Return SpSelSrvMst011

    End Function

#End Region

#Region "GetSrvDcdByChrgCdSrvCd/SpSelSrvMst012 : Get the SrvDesc by Passing Chrgcd & SrvDesc"
    'pragya : 11-nov-2016
    Shared Function GetSrvDcdByChrgCdSrvCd(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal cocd As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer,
                                                      ByVal ChrgCd As Integer,
                                                      ByVal SrvCd As Integer) As String
        Dim ofactory As New DBFactory

        GetSrvDcdByChrgCdSrvCd = Nothing
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst012(strErrMsg, chrErrFlg, cocd, div, loc, ChrgCd, SrvCd))
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        GetSrvDcdByChrgCdSrvCd = .item("SrvDesc")
                    End With
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetSrvDcdByChrgCdSrvCd
    End Function

    Shared Function SpSelSrvMst012(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                         ByRef chrErrFlg As Char,
                                         ByVal CoCd As String,
                                         ByVal Div As Integer,
                                         ByVal Loc As Integer,
                                         ByVal ChrgCd As Integer,
                                         ByVal SrvCd As Integer) As DBRequest

        SpSelSrvMst012 = Nothing

        Dim oParam As DBRequest.Parameter
        Try
            Dim oRequest As New DBRequest
            With oRequest
                .Command = "[SpSelSrvMst012]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCocd"
                oParam.ParamValue = CoCd
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
                oParam.ParamName = "pChrgCd"
                oParam.ParamValue = ChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pSrvCd"
                oParam.ParamValue = SrvCd
                .Parameters.Add(oParam)

            End With

            SpSelSrvMst012 = oRequest
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpSelSrvMst012 = Nothing
        End Try

        Return SpSelSrvMst012

    End Function

#End Region

#Region "Get Service Code and Desc By Charge Code" 'Aarti 20161214
    Public Shared Function GetSrvCdWithDesc(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                   ByRef chrErrFlg As Char, _
                                   ByVal cocd As String, _
                                   ByVal div As Integer, _
                                   ByVal loc As Integer, ByVal ChrgCd As Integer) As List(Of clsSrvMst)
        GetSrvCdWithDesc = Nothing
        Dim ofactory As New DBFactory
        Dim objarrservice = New List(Of clsSrvMst)
        Dim dr1 As Object
        Try
            dr1 = ofactory.ExecuteDataReader(SPSELSRVMST015(strErrMsg, chrErrFlg, cocd, div, loc, ChrgCd))
            If dr1.hasrows Then
                While dr1.read()
                    With dr1
                        Dim objservice As New clsSrvMst
                        objservice.srvcd = .Item("srv_cd")
                        objservice.srvdesc = .Item("srv_desc")
                        objarrservice.Add(objservice)
                    End With
                End While
            Else
                objarrservice = Nothing
            End If
            Return objarrservice
        Catch ex As Exception
            GetSrvCdWithDesc = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

    Shared Function SPSELSRVMST015(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                         ByRef chrErrFlg As Char, _
                         ByVal cocd As String, _
                         ByVal div As Integer, _
                         ByVal loc As Integer, ByVal ChrgCd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest
            .Command = "[SPSELSRVMST015]"

            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = cocd
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = div
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
            oParam.ParamValue = loc
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = ChrgCd
            oRequest.Parameters.Add(oParam)

        End With

        Return oRequest
    End Function

#End Region



#Region "GET SURGERY TYPE DETAILS FOR OT CHARGE POSTING BY PASSING CHARGE CODE, SERVICE CODE" 'RasikV 20170309
    Shared Function GetOTSurTypByChrgSrvCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal ChrgCd As Integer, ByVal SrvCd As Integer) As clsSurgeryTypeMst
        GetOTSurTypByChrgSrvCd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst021(CoCd, Div, Loc, ChrgCd, SrvCd))
            Dim obj As clsSurgeryTypeMst = Nothing
            obj = New clsSurgeryTypeMst
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj.Code = IIf(IsDBNull(.Item("Cd")), 0, .Item("Cd"))
                        obj.Decode = IIf(IsDBNull(.Item("Dcd")), 0, .Item("Dcd"))
                    End With
                    GetOTSurTypByChrgSrvCd = obj
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetOTSurTypByChrgSrvCd
    End Function

    Shared Function SpSelSrvMst021(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal ChrgCd As Integer, ByVal SrvCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest
            .Command = "[dbo].[SpSelSrvMst021]" 'SRV_MST
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
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = ChrgCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSrvCd"
            oParam.ParamValue = SrvCd
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function

#Region "TO CHECK WHETHER PROCEDURAL SERVICE OR NOT BY PASSING CHARGE CODE AND SERVICE CODE"  'RasikV 20170311
    Shared Function FnChkIsProceduralSrv(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal ChrgCd As Integer, ByVal SrvCd As Integer) As Boolean
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnChkIsProceduralSrv]  ('" & CoCd & "','" & Div & "','" & Loc & "','" & ChrgCd & "','" & SrvCd & "') ChkIsProceduralSrv"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                FnChkIsProceduralSrv = ds.Tables(0).Rows(0).Item("ChkIsProceduralSrv")
            Else
                FnChkIsProceduralSrv = Nothing
            End If
            orequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnChkIsProceduralSrv = Nothing
        End Try
        Return FnChkIsProceduralSrv
    End Function
#End Region

#End Region

#Region "GET SERVICE LIST FOR OT CHARGE POSTING BY PASSING USER ID" 'RasikV 20170315
    Shared Function GetSrvListByUsrId(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UsrId As String) As List(Of ClsSrvMstMainHelp)
        GetSrvListByUsrId = Nothing
        Dim ofactory As New DBFactory
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst022(CoCd, Div, Loc, UsrId))
            Dim objArr As List(Of ClsSrvMstMainHelp) = Nothing
            Dim obj As ClsSrvMstMainHelp = Nothing
            If dr1.hasrows Then
                objArr = New List(Of ClsSrvMstMainHelp)
                While dr1.Read()
                    With dr1
                        obj = New ClsSrvMstMainHelp
                        obj.chrgcd = IIf(IsDBNull(.Item("ChrgCd")), 0, .Item("ChrgCd"))
                        obj.ChrgDesc = IIf(IsDBNull(.Item("ChrgDcd")), Nothing, .Item("ChrgDcd"))
                        obj.srvcd = IIf(IsDBNull(.Item("SrvCd")), 0, .Item("SrvCd"))
                        obj.srvdesc = IIf(IsDBNull(.Item("SrvDcd")), Nothing, .Item("SrvDcd"))
                        obj.SharerExist = IIf(IsDBNull(.Item("IsShrExist")), 0, .Item("IsShrExist"))
                    End With
                    objArr.Add(obj)
                End While
            End If
            dr1.close()
            GetSrvListByUsrId = objArr
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetSrvListByUsrId
    End Function

    Shared Function SpSelSrvMst022(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UsrId As String) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest
            .Command = "[dbo].[SpSelSrvMst022]" 'chrg_mst, srv_mst, user_chrg, srv_typ_mst
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
            oParam.ParamName = "pUsrId"
            oParam.ParamValue = UsrId
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region

#Region "GET SERVICE DETAILS FOR OT CHARGE POSTING BY PASSING USER ID, CHARGE CODE AND SERVICE CODE" 'RasikV 20170316
    Shared Function GetSrvDtlsByUsrIdChrgCdSrvCd(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UsrId As String, ByVal ChrgCd As Integer, ByVal SrvCd As Integer) As ClsServiceMasterDtl
        GetSrvDtlsByUsrIdChrgCdSrvCd = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst024(CoCd, Div, Loc, UsrId, ChrgCd, SrvCd))
            Dim obj As ClsServiceMasterDtl = Nothing
            If dr1.hasrows Then
                obj = New ClsServiceMasterDtl
                While dr1.Read()
                    With dr1
                        obj.cmpntcd = IIf(IsDBNull(.Item("CmpntCd")), 0, .Item("CmpntCd"))
                        obj.srvcd = IIf(IsDBNull(.Item("SrvCd")), 0, .Item("SrvCd"))
                        obj.srvdesc = IIf(IsDBNull(.Item("SrvDcd")), Nothing, .Item("SrvDcd"))
                        obj.emgsrvflg = IIf(IsDBNull(.Item("EmgSrvFlg")), Nothing, .Item("EmgSrvFlg"))
                        obj.manpstflg = IIf(IsDBNull(.Item("ManPstFlg")), Nothing, .Item("ManPstFlg"))
                        obj.SharerExist = IIf(IsDBNull(.Item("ShareFlg")), False, .Item("ShareFlg"))
                        obj.FractionAllow = IIf(IsDBNull(.Item("FractionAllow")), Nothing, .Item("FractionAllow"))
                        obj.MultipleAllow = IIf(IsDBNull(.Item("MultipleAllow")), Nothing, .Item("MultipleAllow"))
                    End With
                    GetSrvDtlsByUsrIdChrgCdSrvCd = obj
                End While
            Else
                strErrMsg.Add("Record Not Found In Service Master for Charge Code" & " " & ChrgCd & " and Service Code " & SrvCd)
                Return Nothing
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetSrvDtlsByUsrIdChrgCdSrvCd
    End Function

    Shared Function SpSelSrvMst024(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UsrId As String, ByVal ChrgCd As Integer, ByVal SrvCd As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest
            .Command = "[dbo].[SpSelSrvMst024]" 'chrg_mst, srv_mst, user_chrg, srv_typ_mst
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
            oParam.ParamName = "pUsrId"
            oParam.ParamValue = UsrId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = ChrgCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSrvCd"
            oParam.ParamValue = SrvCd
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region

#Region "GET SERVICE LIST FOR OT CHARGE POSTING BY PASSING USER ID AND PREFIX" 'RasikV 20170303
    Shared Function GetSrvListByUsrIdPrefix(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UsrId As String, ByVal Prefix As String) As List(Of ClsSrvMstMainHelp)
        GetSrvListByUsrIdPrefix = Nothing
        Dim ofactory As New DBFactory
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst020(CoCd, Div, Loc, UsrId, Prefix))
            Dim objArr As List(Of ClsSrvMstMainHelp) = Nothing
            Dim obj As ClsSrvMstMainHelp = Nothing
            If dr1.hasrows Then
                objArr = New List(Of ClsSrvMstMainHelp)
                While dr1.Read()
                    With dr1
                        obj = New ClsSrvMstMainHelp
                        obj.chrgcd = IIf(IsDBNull(.Item("ChrgCd")), 0, .Item("ChrgCd"))
                        obj.ChrgDesc = IIf(IsDBNull(.Item("ChrgDcd")), Nothing, .Item("ChrgDcd"))
                        obj.srvcd = IIf(IsDBNull(.Item("SrvCd")), 0, .Item("SrvCd"))
                        obj.srvdesc = IIf(IsDBNull(.Item("SrvDcd")), Nothing, .Item("SrvDcd"))
                        obj.SharerExist = IIf(IsDBNull(.Item("IsShrExist")), 0, .Item("IsShrExist"))
                    End With
                    objArr.Add(obj)
                End While
            End If
            dr1.close()
            GetSrvListByUsrIdPrefix = objArr
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetSrvListByUsrIdPrefix
    End Function

    Shared Function SpSelSrvMst020(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UsrId As String, ByVal Prefix As String) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter

        With oRequest
            .Command = "[dbo].[SpSelSrvMst020]" 'chrg_mst, srv_mst, user_chrg, srv_typ_mst
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
            oParam.ParamName = "pUsrId"
            oParam.ParamValue = UsrId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPrefix"
            oParam.ParamValue = Prefix
            .Parameters.Add(oParam)
        End With
        Return oRequest
    End Function
#End Region
#Region " Get Service List By Passing Charge Code and User Id   ,if chrg code is zero then it will show all services "

    'added by Farid 23-mar-2017'
    Shared Function GetServiceList03(ByRef strErrMsg As List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal companycode As String, _
                                  ByVal div As Integer, _
                                  ByVal loc As Integer, _
                                  ByVal UserId As String, _
                                  ByVal chrgcd As Integer
                                  ) As List(Of ClsServiceMasterHelp)
        GetServiceList03 = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(GETSPSELSRVLIST(companycode, div, loc, UserId, chrgcd))
            'declared array of class clscodedecode
            Dim objList As New List(Of ClsServiceMasterHelp)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        Dim obj As New ClsServiceMasterHelp
                        obj.chrgcd = .item("chrg_cd")
                        obj.srvcd = .item("srv_cd")
                        obj.ChrgDesc = .item("chrg_dcd")
                        obj.srvdesc = .item("srv_desc")
                        obj.ServiceTypCd = .item("SerCatg")
                        obj.ServiceTypDCd = .item("SrvTypDcd")
                        objList.Add(obj)
                    End With
                End While
            Else
                Return Nothing
            End If
            dr1.close()
            GetServiceList03 = objList
            Return GetServiceList03
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
    End Function
    Shared Function GETSPSELSRVLIST03(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal UserId As String, ByVal chrgcd As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelSrvList003]" 'chrg_mst  user_chrg  srv_mst  srv_typ_mst
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pUserId"
            oParam.ParamValue = UserId
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = chrgcd
            .Parameters.Add(oParam)
        End With

        Return oRequest
    End Function

#End Region

#Region "function to retrieve data from service master"
    'added by Farid 23-Mar-2017
    ''' <summary>
    ''' function to retrieve data from service master
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="srvcd"></param>
    ''' <param name="chrgcd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetSrvMstDtlWithoutUser03(ByRef strErrMsg As List(Of String), _
                                   ByRef chrErrFlg As Char, _
                                   ByVal companycode As String, _
                                   ByVal div As Integer, _
                                   ByVal loc As Integer, _
                                   ByVal srvcd As Integer, _
                                   ByVal chrgcd As Integer, _
                                         Optional ByVal StatusFlg As Boolean = True) As clsServiceMaster 'new parameter statusflg added by anamika on 20140910

        GetSrvMstDtlWithoutUser03 = Nothing

        Try
            Dim ofactory As New DBFactory

            Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELSRVCHRG003(companycode, div, loc, srvcd, chrgcd, StatusFlg))
            'declared array of class clscodedecode
            Dim obj As New clsServiceMaster
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1

                        obj.CompanyCode = companycode '.item("") 'companycode
                        obj.DivisionCode = div '.item("") 'div
                        obj.LocationCode = loc '.item("") 'loc
                        obj.chrgcd = .item("chrg_cd")
                        obj.srvcd = .item("srv_cd")
                        obj.srvdesc = .item("srv_desc")
                        obj.sectno = .item("sect_no")
                        obj.cst = IIf(IsDBNull(dr1.Item("cst")), 0, dr1.Item("cst"))
                        obj.srchrgflg = .item("srchrg_flg")
                        obj.emgsrvflg = .item("emg_srv_flg")
                        obj.cmpntcd = .item("cmpnt_cd")
                        obj.cmpnttrnpstflag = .item("cmpnt_trn_pst_flag")
                        obj.shrchrgcd = .item("shr_chrg_cd")
                        obj.shrsrvcd = .item("shr_srv_cd")
                        obj.srvstscd = .item("srv_sts_cd")
                        obj.procschflg = IIf(IsDBNull(dr1.Item("proc_sch_flg")), Nothing, dr1.Item("proc_sch_flg"))
                        obj.procschflg = 0 'error'.item("proc_sch_flg")
                        obj.crtdt = IIf(IsDBNull(dr1.Item("crt_dt")), Date.MinValue, dr1.Item("crt_dt"))
                        obj.crttm = IIf(IsDBNull(dr1.Item("crt_tm")), Date.MinValue, dr1.Item("crt_tm")) 'error'.item("crt_tm")
                        obj.crtusrid = IIf(IsDBNull(dr1.Item("crt_usr_id")), "", dr1.Item("crt_usr_id")) '.item("crt_usr_id")
                        obj.updtdt = IIf(IsDBNull(dr1.Item("updt_dt")), Date.MinValue, dr1.item("updt_dt"))
                        obj.updttm = IIf(IsDBNull(dr1.Item("updt_tm")), Date.MinValue, dr1.item("updt_tm")) '.item("updt_tm")
                        obj.updtusrid = .item("updt_usr_id")
                        obj.misgrp = IIf(IsDBNull(dr1.Item("mis_grp")), Nothing, dr1.Item("mis_grp"))
                        'obj.misgrp = .item("mis_grp") 'error
                        obj.SerCatg = .item("SerCatg")
                        obj.DeptCd = .item("DeptCd")
                        obj.stdtime = IIf(IsDBNull(.item("std_time")), 0.0, .item("std_time"))
                        obj.Surgerytypcd = .item("Surgery_typ_cd")
                        obj.CPTcd = IIf(IsDBNull(.item("CPT_cd")), "", .item("CPT_cd"))
                        obj.HIPPAcd = IIf(IsDBNull(.item("HIPPA_cd")), "", .item("HIPPA_cd"))
                        obj.ICDgrpcd = IIf(IsDBNull(.item("ICDgrp_cd")), "", .item("ICDgrp_cd"))
                        obj.icdcd = IIf(IsDBNull(.item("icd_cd")), "", .item("icd_cd"))
                        obj.ipopflg = IIf(IsDBNull(.item("ip_op_flg")), "", .item("ip_op_flg"))
                        obj.manpstflg = IIf(IsDBNull(.item("man_pst_flg")), "", .item("man_pst_flg"))
                        obj.containercd = IIf(IsDBNull(dr1.Item("container_cd")), Nothing, dr1.Item("container_cd"))
                        obj.sensflg = IIf(IsDBNull(dr1.Item("sens_flg")), Nothing, dr1.Item("sens_flg"))
                        obj.FractionAllow = IIf(IsDBNull(dr1.Item("fraction_allow")), Nothing, dr1.Item("fraction_allow")) 'anamika 20131311
                        obj.MultipleAllow = IIf(IsDBNull(dr1.Item("multiple_allow")), Nothing, dr1.Item("multiple_allow")) 'anamika 20131311
                        obj.IsRISSrv = IIf(IsDBNull(dr1.Item("IsRISsrv")), False, dr1.Item("IsRISsrv")) 'anamika 20140911
                        obj.IsLaboratory = IIf(IsDBNull(dr1.Item("IsLaboratorySrv")), False, dr1.Item("IsLaboratorySrv")) 'anamika 20150929
                        obj.IsRadiology = IIf(IsDBNull(dr1.Item("IsRadiologySrv")), False, dr1.Item("IsRadiologySrv")) 'anamika 20150929
                        obj.IsSurgery = IIf(IsDBNull(dr1.Item("IsSurgerySrv")), False, dr1.Item("IsSurgerySrv")) 'anamika 20150929
                        obj.IsProcedure = IIf(IsDBNull(dr1.Item("IsProcedureSrv")), False, dr1.Item("IsProcedureSrv")) 'anamika 20150929
                        obj.IsNurseStationOrdAllow = IIf(IsDBNull(dr1.Item("IsNstTestOrdAllowed")), False, dr1.Item("IsNstTestOrdAllowed")) 'anamika 20150929
                    End With

                End While
            Else
                'anamika 20141030
                If StatusFlg = 0 Then
                    strErrMsg.Add("Record No Found In Service Master for Charge Code" & " " & chrgcd & " and Service Code " & srvcd)
                    chrErrFlg = "Y"
                Else
                    strErrMsg.Add("Record No Found In Service Master for Charge Code" & " " & chrgcd & " and Service Code " & srvcd & " Or Service is inactive")
                    chrErrFlg = "Y"
                End If
                'anamika 20141030
                ' strErrMsg.Add("Record No Found In Service Master for Charge Code" & " " & chrgcd & " and Service Code " & srvcd)
                Return Nothing
            End If
            dr1.close()
            GetSrvMstDtlWithoutUser03 = obj
            Return GetSrvMstDtlWithoutUser03
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try

    End Function
    ''' <summary>
    '''  function to retrieve data from service master
    ''' </summary>
    ''' <param name="companycode"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="srvcd"></param>
    ''' <param name="chrgcd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPSELSRVCHRG003(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal srvcd As Integer,
                                    ByVal chrgcd As Integer, ByVal StatusFlg As Boolean) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SPSELSRVCHRG003]" 'chrg_mst,srv_mst
            .CommandType = CommandType.StoredProcedure

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
            oParam.ParamName = "pSrvCd"
            oParam.ParamValue = srvcd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pChrgCd"
            oParam.ParamValue = chrgcd
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pStatusFlg"
            oParam.ParamValue = StatusFlg
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function
    'end 23-Mar-2017
#End Region

#Region "Get Service desc from service code"
    'inside class clsServiceMaster
    'Amol Margaj : 30-MAY-2017
    Shared Function GetSrvDcdOnlyByChrgCdSrvCd(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                      ByVal cocd As String, _
                                                      ByVal div As Integer, _
                                                      ByVal loc As Integer,
                                                      ByVal ChrgCd As Integer,
                                                      ByVal SrvCd As Integer) As String
        Dim ofactory As New DBFactory

        GetSrvDcdOnlyByChrgCdSrvCd = Nothing
        Try
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSrvMst025(strErrMsg, chrErrFlg, cocd, div, loc, ChrgCd, SrvCd))
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        GetSrvDcdOnlyByChrgCdSrvCd = .item("SrvDesc")
                    End With
                End While
            End If
            dr1.close()
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            ofactory = Nothing
        End Try
        Return GetSrvDcdOnlyByChrgCdSrvCd
    End Function

    Shared Function SpSelSrvMst025(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                         ByRef chrErrFlg As Char,
                                         ByVal CoCd As String,
                                         ByVal Div As Integer,
                                         ByVal Loc As Integer,
                                         ByVal ChrgCd As Integer,
                                         ByVal SrvCd As Integer) As DBRequest

        SpSelSrvMst025 = Nothing

        Dim oParam As DBRequest.Parameter
        Try
            Dim oRequest As New DBRequest
            With oRequest
                .Command = "[SpSelSrvMst025]"
                .CommandType = CommandType.StoredProcedure
                .Transactional = True

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pCocd"
                oParam.ParamValue = CoCd
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
                oParam.ParamName = "pChrgCd"
                oParam.ParamValue = ChrgCd
                .Parameters.Add(oParam)

                oParam = New DBRequest.Parameter
                oParam.ParamName = "pSrvCd"
                oParam.ParamValue = SrvCd
                .Parameters.Add(oParam)

            End With

            SpSelSrvMst025 = oRequest
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpSelSrvMst025 = Nothing
        End Try

        Return SpSelSrvMst025

    End Function


#End Region







    'Added By Prashant 20180718
#Region "GetAllServiceCodeByChargeCode"
    Shared Function GetAllSrvDescByChrgCD(ByRef strErrMsg As List(Of String), _
                        ByRef chrErrFlg As Char, _
                        ByVal cocd As String, _
                        ByVal div As Integer, _
                        ByVal loc As Integer, _
                        ByVal chrgcd As Integer, _
                        ByVal srvcd As Integer) As String

        Dim ofactory As DBFactory
        GetAllSrvDescByChrgCD = 0
        ofactory = New DBFactory
        Try

            Dim ds As DataSet = ofactory.ExecuteDataSet(FNSrvMst002(cocd, div, loc, chrgcd, srvcd))
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    GetAllSrvDescByChrgCD = IIf(IsDBNull(ds.Tables(0).Rows(i).Item(0)), 0, ds.Tables(0).Rows(i).Item(0))
                Next
            End If
            ds.Dispose()
        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetAllSrvDescByChrgCD = Nothing
            Return GetAllSrvDescByChrgCD
        End Try

    End Function

    Shared Function FNSrvMst002(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal chrgcd As Integer, ByVal srvcd As Integer) As DBRequest

        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        With orequest
            orequest.Command = "SELECT dbo.[fnSrvMst002]('" & companycode & "','" & div & "','" & loc & "','" & chrgcd & "','" & srvcd & "') srvdesc"
        End With
        Return orequest
    End Function
#End Region

End Class

<DataContract()>
Public Class clsSurgeryTypeMst 'RasikV 20170309
    <DataMember()>
    Public Property Code As Integer
    <DataMember()>
    Public Property Decode As String
End Class
<DataContract()>
Public Class ClsSrvMstMainHelp 'anamika 20151120
    <DataMember()>
    Public Property chrgcd As Integer
    <DataMember()>
    Public Property srvcd As Integer
    <DataMember()>
    Public Property srvdesc As String
    <DataMember()>
    Public Property ChrgDesc As String
    <DataMember()>
    Public Property SharerExist As Boolean   'anamika 20151010
  
End Class


<DataContract()>
Public Class ClsServiceMasterHelp
    Inherits ClsSrvMstMainHelp    'class defination changed new class clssrvmstmainhelp inherited 
    <DataMember()>
    Public Property ServiceTypCd As Integer
    <DataMember()>
    Public Property ServiceTypDCd As String

End Class

<DataContract()>
Public Class ClsSrvMstByType 'mayur 20150128
    <DataMember()>
    Public Property ServiceCode As Integer
    <DataMember()>
    Public Property ServiceDescription As String
    <DataMember()>
    Public Property ChargeCode As Integer
    <DataMember()>
    Public Property Servicetype As Integer
    <DataMember()>
    Public Property Units As Integer
    <DataMember()>
    Public Property Cmpntcd As Integer 'anamika 20161001
End Class

<DataContract()>
Public Class ClsServiceMasterDtl
    Inherits ClsSrvMstMainHelp  ' ClsServiceMasterHelp  class replaced by anamika on 20151121
    <DataMember()>
    Public Property MultipleAllow As String
    <DataMember()>
    Public Property FractionAllow As String
    <DataMember()>
    Public Property emgsrvflg As String
    <DataMember()>
    Public Property cmpntcd As Integer
    <DataMember()>
    Public Property manpstflg As String

    <DataMember()>
    Public Property GstTaxCd As Integer   'RasikV 20170701
    <DataMember()>
    Public Property SrvTyp As String   'RasikV 20180510
End Class



Public Class clsSrvMst
    <DataMember()>
    Public Property srvcd As Integer
    <DataMember()>
    Public Property srvdesc As String
End Class


#Region "class : clsSrvMstSurgCatServices : Exclusevily used in OTCHKLIST - POSTCHKLIST - SURGRY DTLS"
<DataContract()>
Public Class clsSrvMstSurgCatServices
    Inherits ClsSrvMstMainHelp    'class defination changed new class clssrvmstmainhelp inherited 
    <DataMember()>
    Public Property SurgeySrvDtls As Integer
End Class
#End Region

#Region "ClsOtSrvLstDtls"
'pragya : 12-oct-2016
<DataContract()>
Public Class ClsOtSrvLstDtls
    Inherits ClsSrvMstMainHelp    'class defination changed new class clssrvmstmainhelp inherited 
    <DataMember()>
    Public Property SrvTypCd As Integer
    <DataMember()>
    Public Property SrvTypDesc As String
    <DataMember>
    Public Property SrvRate As Double
    <DataMember()>
    Public Property SrvDiagnosis As String          'pragya : 14-oct-2016
    <DataMember()>
    Public Property AnesTypCd As Integer            'pragya : 02-Nov-2016
    <DataMember()>
    Public Property AnesTypDesc As String            'pragya : 02-Nov-2016
End Class
#End Region


<DataContract()>
Public Class ClsSrvMstIpPackageHelp 'anamika 20151120
    Inherits ClsSrvMstMainHelp
    <DataMember()>
    Public Property MaxQty As Decimal   'alpesh : 20161118  :chnge
    <DataMember()>
    Public Property IsUnlimited As Boolean 'alpesh : 20161121  :chnge
    <DataMember()>
    Public Property chkForSelect() As Boolean      'alpesh 20161127
End Class


<DataContract()>
Public Class STDDEPORDSRV
    <DataMember()>
    Public Property ServiceCode As Integer
    <DataMember()>
    Public Property ServiceDescription As String
    <DataMember()>
    Public Property ChargeCode As Integer
    <DataMember()>
    Public Property Servicetype As Integer
    <DataMember()>
    Public Property Units As Integer
End Class

#Region "CLASS : ClsSrvMstAutoPost"
Public Class ClsSrvMstAutoPost  'PRAGYA : 16-JUN-2017
    <DataMember()>
    Public Property srvdesc As String
    <DataMember()>
    Public Property sectno As Integer
    <DataMember()>
    Public Property cst As Double
    <DataMember()>
    Public Property srchrgflg As String
    <DataMember()>
    Public Property cmpntcd As Integer
End Class
#End Region

