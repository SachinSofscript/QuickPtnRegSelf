Imports System.Runtime.Serialization
Imports SofCommon
Namespace PatientVisitAndBilInsTrn

#Region "class : clsIpBillInstrnArcd"
    'pragya : 19-may-2017
    <DataContract>
    Public Class clsIpBillInstrnArcd
        <DataMember()>
        Public Property ArCd As Nullable(Of Long)
        <DataMember()>
        Public Property ArLngNm() As String
        <DataMember()>
        Public Property IntCd2() As Integer
    End Class
#End Region



    Public Class clsIpBilInsTrn
        '<DataMember()>
        'Public Property CompanyCode() As String 'commented by anamika on 20160914
        '<DataMember()>
        'Public Property DivisionCode() As Integer
        '<DataMember()>
        'Public Property LocationCode() As Integer
        <DataMember()>
        Public Property NewOldIp() As String
        '<DataMember()>
        'Public Property IpNo() As Integer
        <DataMember()>
        Public Property IpNo() As Long 'anamika 20160914
        <DataMember()>
        Public Property FreeFlag() As Char
        <DataMember()>
        Public Property AutoPstFreeFlag() As Char
        <DataMember()>
        Public Property EmployeeNo() As String
        <DataMember()>
        Public Property ArCd() As Long
        <DataMember()>
        Public Property CoRefncNo() As String
        <DataMember()>
        Public Property RtChngCd() As Integer
        <DataMember()>
        Public Property SurChrgCd() As Integer
        '<DataMember()>
        'Public Property CreateDt() As Date
        '<DataMember()>
        'Public Property CreateTm() As Date
        '<DataMember()>
        'Public Property CreateUsrId() As String
        <DataMember()>
        Public Property UpdtDt() As Date
        <DataMember()>
        Public Property UpdtTm() As Date
        <DataMember()>
        Public Property UpdtUsrId() As String
        <DataMember()>
        Public Property No() As Integer
        <DataMember()>
        Public Property SchemeCd() As Integer
        <DataMember()>
        Public Property GradeCd() As Integer
        ''' <summary>
        ''' Select all record from ip_bil_instrn
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetIpBilInsTrnList(ByRef strErrMsg As List(Of String), _
                                                    ByRef chrErrFlg As Char, _
                                                    ByVal companycode As String, _
                                                    ByVal div As Integer, _
                                                    ByVal loc As Integer
                                                   ) As List(Of clsIpBilInsTrn)
            GetIpBilInsTrnList = Nothing
            Try

                Dim ofactory As New DBFactory

                Dim dr1 As Object = ofactory.ExecuteDataReader(SPSELIPBILINSTRN(companycode, div, loc))
                Dim objList As List(Of clsIpBilInsTrn) = Nothing
                If dr1.hasrows Then
                    objList = New List(Of clsIpBilInsTrn)
                    While dr1.Read()
                        With dr1
                            Dim obj As New clsIpBilInsTrn
                            'obj.CompanyCode = companycode
                            'obj.DivisionCode = div
                            'obj.LocationCode = loc
                            obj.NewOldIp = .Item("new_old_ip")
                            obj.IpNo = .Item("ip_no")
                            obj.FreeFlag = .Item("free_flg")
                            obj.AutoPstFreeFlag = .Item("auto_pst_free_flg")
                            obj.EmployeeNo = .Item("emp_no")

                            obj.ArCd = .Item("ar_cd")
                            obj.CoRefncNo = .Item("co_refnc_no")
                            obj.RtChngCd = .Item("rt_chng_cd")
                            obj.SurChrgCd = .Item("srchrg_cd")
                            'obj.CreateDt = IIf(IsDBNull(.Item("crt_dt")), Nothing, .Item("crt_dt")) 'commented by anamika on 20150218
                            'obj.CreateTm = IIf(IsDBNull(.Item("crt_tm")), Nothing, .Item("crt_tm"))
                            'obj.CreateUsrId = .Item("crt_usr_id")

                            obj.UpdtDt = IIf(IsDBNull(.Item("updt_dt")), Nothing, .Item("updt_dt"))
                            obj.UpdtTm = IIf(IsDBNull(.Item("updt_tm")), Nothing, .Item("updt_tm"))
                            obj.UpdtUsrId = .Item("updt_usr_id")

                            obj.No = .Item("no")
                            obj.SchemeCd = .Item("scheme_cd")
                            obj.GradeCd = .Item("grade_cd")
                            objList.Add(obj)
                        End With
                    End While
                End If
                dr1.close()
                GetIpBilInsTrnList = objList

                ofactory = Nothing

            Catch ex As Exception
                GetIpBilInsTrnList = Nothing

                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try

            Return GetIpBilInsTrnList
        End Function


        'anamika 20131106
        ''' <summary>
        '''  Select  record from table ip_bil_instrn  for given Ip_no
        ''' </summary>
        ''' <param name="strErrMsg"></param>
        ''' <param name="chrErrFlg"></param>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <param name="IpNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetIpBilInsTrnByIpNo(ByRef strErrMsg As List(Of String), _
                                                    ByRef chrErrFlg As Char, _
                                                    ByVal companycode As String, _
                                                    ByVal div As Integer, _
                                                    ByVal loc As Integer, _
                                                  ByVal IpNo As Long) As clsIpBilInsTrn
            GetIpBilInsTrnByIpNo = Nothing
            Try

                Dim ofactory As New DBFactory

                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpBilInstrn001(companycode, div, loc, IpNo))
                Dim obj As New clsIpBilInsTrn
                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1

                            'obj.CompanyCode = companycode
                            'obj.DivisionCode = div
                            'obj.LocationCode = loc
                            obj.NewOldIp = .Item("new_old_ip")
                            obj.IpNo = .Item("ip_no")
                            obj.FreeFlag = .Item("free_flg")
                            obj.AutoPstFreeFlag = .Item("auto_pst_free_flg")
                            obj.EmployeeNo = .Item("emp_no")

                            obj.ArCd = .Item("ar_cd")
                            obj.CoRefncNo = .Item("co_refnc_no")
                            obj.RtChngCd = .Item("rt_chng_cd")
                            obj.SurChrgCd = .Item("srchrg_cd")
                            'obj.CreateDt = IIf(IsDBNull(.Item("crt_dt")), Nothing, .Item("crt_dt"))
                            'obj.CreateTm = IIf(IsDBNull(.Item("crt_tm")), Nothing, .Item("crt_tm"))
                            'obj.CreateUsrId = .Item("crt_usr_id")

                            obj.UpdtDt = IIf(IsDBNull(.Item("updt_dt")), Nothing, .Item("updt_dt"))
                            obj.UpdtTm = IIf(IsDBNull(.Item("updt_tm")), Nothing, .Item("updt_tm"))
                            obj.UpdtUsrId = .Item("updt_usr_id")

                            obj.No = .Item("no")
                            obj.SchemeCd = .Item("scheme_cd")
                            obj.GradeCd = .Item("grade_cd")

                        End With
                    End While
                End If
                dr1.close()
                GetIpBilInsTrnByIpNo = obj

                ofactory = Nothing

            Catch ex As Exception
                GetIpBilInsTrnByIpNo = Nothing

                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try

            Return GetIpBilInsTrnByIpNo
        End Function
        'end 20131106

#Region "Stored Procedures"
        ''' <summary>
        ''' stored procedure to retrieve from ip_bil_instrn
        ''' </summary>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SPSELIPBILINSTRN(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SPSELIPBILINSTRN]"
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

                .CommandType = CommandType.StoredProcedure



            End With

            Return oRequest
        End Function
        'anamika 20131106
        ''' <summary>
        '''  Select  record from table ip_bil_instrn  for given Ip_no
        ''' </summary>
        ''' <param name="companycode"></param>
        ''' <param name="div"></param>
        ''' <param name="loc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function SpSelIpBilInstrn001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Long) As DBRequest 'anamika 20160906
            'Shared Function SpSelIpBilInstrn001(ByVal companycode As String, ByVal div As Integer, ByVal loc As Integer, ByVal IpNo As Integer) As DBRequest

            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SpSelIpBilInstrn001]"  'ip_bil_instrn
                .CommandType = CommandType.StoredProcedure
                .Transactional = True
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
                oParam.ParamName = "pIpNo"
                oParam.ParamValue = IpNo
                .Parameters.Add(oParam)







            End With

            Return oRequest
        End Function

        'end 20131106
#End Region

#Region "GetArCdByIpOpNo/SpSelIpBilInstrn002 : GET AR_CD FROM Ipno"
        'pragya : 14-oct-2016
        Shared Function GetArCdByIpOpNo(ByRef strErrMsg As List(Of String), _
                                              ByRef chrErrFlg As Char, _
                                              ByVal companycode As String, _
                                              ByVal div As Integer, _
                                              ByVal loc As Integer, _
                                              ByVal IPNo As Long) As Integer
            GetArCdByIpOpNo = Nothing
            Try

                Dim ofactory As New DBFactory

                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpBilInstrn002(companycode, div, loc, IPNo))
                If dr1.hasrows Then
                    While dr1.Read()
                        GetArCdByIpOpNo = dr1.Item("ArCd")
                    End While
                End If
                dr1.close()
                ofactory = Nothing

            Catch ex As Exception
                GetArCdByIpOpNo = Nothing
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
            End Try
            Return GetArCdByIpOpNo
        End Function

        Shared Function SpSelIpBilInstrn002(ByVal companycode As String,
                                            ByVal div As Integer,
                                            ByVal loc As Integer,
                                            ByVal IpNo As Long) As DBRequest
            Dim oRequest As DBRequest = New DBRequest
            Dim oParam As New DBRequest.Parameter
            With oRequest
                .Command = "[SpSelIpBilInstrn002]"
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
                oParam.ParamName = "pIpNo "
                oParam.ParamValue = IpNo
                .Parameters.Add(oParam)

                .CommandType = CommandType.StoredProcedure



            End With

            Return oRequest
        End Function

#End Region







        '#Region "GetPatientVisitAndFolioDtls/SpSelIpPtnVst020 : GET PATIENT VISIT DETAILS"
        '        'PRAGYA : 16-JUN-2017
        '        Shared Function GetPatientVisitAndFolioDtls(ByRef strErrMsg As System.Collections.Generic.List(Of String),
        '                                                  ByRef chrErrFlg As Char,
        '                                                  ByVal CoCd As String,
        '                                                  ByVal Div As Integer,
        '                                                  ByVal Loc As Integer,
        '                                                ByVal SelDate As Date) As List(Of clsAutoPostFolioChrgs)
        '            GetPatientVisitAndFolioDtls = Nothing
        '            Dim ofactory As New DBFactory
        '            Try



        '                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpPtnVst020(strErrMsg, chrErrFlg, CoCd, Div, Loc, SelDate))
        '                Dim objList As New List(Of clsAutoPostFolioChrgs)

        '                If dr1.hasrows Then
        '                    While dr1.Read()
        '                        Dim obj As New clsAutoPostFolioChrgs


        '                        obj.WingCd = dr1.Item("wing_cd")
        '                        obj.IpNo = dr1.Item("ip_no")
        '                        obj.FolNo = dr1.Item("fol_no")
        '                        obj.ptnclscd = dr1.Item("ptn_cls_cd")
        '                        obj.bedno = dr1.Item("bed_no")
        '                        obj.bedtypcd = dr1.Item("bed_typ_cd")
        '                        obj.wrdcd = dr1.Item("wrd_cd")

        '                        obj.csetypcd = dr1.Item("cse_typ_cd")
        '                        obj.doccd = dr1.Item("doc_cd")
        '                        obj.ptnsrccd = dr1.Item("ptn_src_cd")
        '                        obj.ptnno = dr1.Item("ptn_no")
        '                        obj.AdmDt = dr1.Item("adm_dt")
        '                        obj.SchemeCd = dr1.Item("SchemeCd")


        '                        objList.Add(obj)
        '                    End While
        '                    GetPatientVisitAndFolioDtls = objList

        '                Else
        '                    GetPatientVisitAndFolioDtls = Nothing

        '                End If
        '                dr1.close()


        '            Catch ex As Exception
        '                strErrMsg.Add(ex.Message)
        '                chrErrFlg = "Y"
        '                Return Nothing
        '            Finally
        '                ofactory = Nothing
        '            End Try
        '        End Function

        '        Shared Function SpSelIpPtnVst020(ByRef strErrMsg As System.Collections.Generic.List(Of String),
        '                                          ByRef chrErrFlg As Char,
        '                                          ByVal CoCd As String,
        '                                          ByVal Div As Integer,
        '                                          ByVal Loc As Integer,
        '                                          ByVal SelDate As Date) As DBRequest

        '            SpSelIpPtnVst020 = Nothing

        '            Dim oParam As DBRequest.Parameter
        '            Try
        '                Dim oRequest As New DBRequest
        '                With oRequest
        '                    .Command = "[SpSelIpPtnVst020]"
        '                    .CommandType = CommandType.StoredProcedure
        '                    .Transactional = True

        '                    oParam = New DBRequest.Parameter
        '                    oParam.ParamName = "pCocd"
        '                    oParam.ParamValue = CoCd
        '                    .Parameters.Add(oParam)

        '                    oParam = New DBRequest.Parameter
        '                    oParam.ParamName = "pDivCd"
        '                    oParam.ParamValue = Div
        '                    .Parameters.Add(oParam)

        '                    oParam = New DBRequest.Parameter
        '                    oParam.ParamName = "pLocCd"
        '                    oParam.ParamValue = Loc
        '                    .Parameters.Add(oParam)

        '                    oParam = New DBRequest.Parameter
        '                    oParam.ParamName = "pSelDate"
        '                    oParam.ParamValue = SelDate
        '                    .Parameters.Add(oParam)

        '                End With

        '                SpSelIpPtnVst020 = oRequest
        '            Catch ex As Exception
        '                strErrMsg.Add(ex.Message)
        '                chrErrFlg = "Y"
        '                SpSelIpPtnVst020 = Nothing
        '            End Try

        '            Return SpSelIpPtnVst020

        '        End Function
        '#End Region


#Region "Get sharer charge code details by passing Ipno"

        Shared Function GetShrChrgCdByIpNo(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal CoCd As String,
                                                     ByVal Div As Integer,
                                                     ByVal Loc As Integer,
                                                     ByVal IpNo As Long) As clsIpBillInsShrChrgDtls
            Dim ofactory As New DBFactory

            GetShrChrgCdByIpNo = Nothing
            Try

                Dim objshrchrg As New clsIpBillInsShrChrgDtls

                Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelIpBilInstrn004(strErrMsg, chrErrFlg, CoCd, Div, Loc, IpNo))

                If dr1.hasrows Then
                    While dr1.Read()
                        With dr1
                            objshrchrg.ShrCd = .Item("srchrg_cd")
                            objshrchrg.ShrPercent = .Item("srchrg_prcnt_1")
                            objshrchrg.SchemeCd = .Item("SchemeCd")
                        End With
                    End While
                End If
                dr1.close()

                GetShrChrgCdByIpNo = objshrchrg
                ofactory = Nothing
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                GetShrChrgCdByIpNo = Nothing
            Finally
                ofactory = Nothing
            End Try
            Return GetShrChrgCdByIpNo

        End Function

        Shared Function SpSelIpBilInstrn004(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal CoCd As String,
                                                     ByVal Div As Integer,
                                                     ByVal Loc As Integer,
                                                     ByVal IpNo As Long) As DBRequest

            SpSelIpBilInstrn004 = Nothing

            Dim oParam As DBRequest.Parameter
            Try
                Dim oRequest As New DBRequest
                With oRequest
                    .Command = "[SpSelIpBilInstrn004]"
                    .CommandType = CommandType.StoredProcedure
                    .Transactional = True

                    oParam = New DBRequest.Parameter
                    oParam.ParamName = "pCOCD"
                    oParam.ParamValue = CoCd
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
                    oParam.ParamName = "pIpNo"
                    oParam.ParamValue = IpNo
                    .Parameters.Add(oParam)

                End With

                SpSelIpBilInstrn004 = oRequest
            Catch ex As Exception
                strErrMsg.Add(ex.Message)
                chrErrFlg = "Y"
                SpSelIpBilInstrn004 = Nothing
            End Try

            Return SpSelIpBilInstrn004

        End Function
#End Region






    End Class



#Region "CLASS : clsAutoPostFolioChrgs" 'PRAGYA : 16-JUN-2017
    Public Class clsAutoPostFolioChrgs
        <DataMember()>
        Public Property WingCd As Integer
        <DataMember()>
        Public Property IpNo As Long
        <DataMember()>
        Public Property FolNo As Integer
        <DataMember()>
        Public Property ptnclscd As Integer
        <DataMember()>
        Public Property bedno As String
        <DataMember()>
        Public Property bedtypcd As Integer
        <DataMember()>
        Public Property wrdcd As Integer
        <DataMember()>
        Public Property csetypcd As Integer
        <DataMember()>
        Public Property doccd As Integer
        <DataMember()>
        Public Property ptnsrccd As Integer
        <DataMember()>
        Public Property ptnno As Long
        <DataMember()>
        Public Property AdmDt As Date
        <DataMember()>
        Public Property SchemeCd As Integer
    End Class
#End Region

    <DataContract>
    Public Class clsIpBillInsShrChrgDtls  'APARNA 30 OCT 2017   
        <DataMember()>
        Public Property ShrPercent() As Double
        <DataMember()>
        Public Property ShrCd() As Integer
        <DataMember()>
        Public Property SchemeCd() As Integer
    End Class




    
End Namespace

