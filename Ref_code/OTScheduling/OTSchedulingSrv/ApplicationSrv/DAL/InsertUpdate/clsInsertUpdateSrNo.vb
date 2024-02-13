
Imports System.Runtime.Serialization

Imports SofCommon
Public Class clsInsertUpdateSrNo
    Dim ofactory As DBFactory
    Dim oParam As DBRequest.Parameter







#Region "******************************************Csh_dept_wing**************************************************************************"



#Region "op_conc_no(csh_dept_wing)"
    'anaika 20140103
    ''' <summary>
    ''' Selects and updates op rcpt no from Conc no
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="CrtUsrId"></param>
    ''' <param name="CshDptCd"></param>
    ''' <param name="WingCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SpSelUpdOPConcNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                ByRef chrErrFlg As Char, _
                                ByVal pcompanycode As String, _
                                ByVal pdiv As Integer, _
                                ByVal ploc As Integer, _
                                ByVal CrtUsrId As String, ByVal CshDptCd As Integer, ByVal WingCd As Integer) As Integer

        SpSelUpdOPConcNo = Nothing
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim ConcNo As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try



            Dim REQSPSELUPDRCPTNO As New DBRequest
            REQSPSELUPDRCPTNO.Command = "[SpSelUpdOpConcNo]"  'anamika 20140218 csh_dept_wing
            REQSPSELUPDRCPTNO.CommandType = CommandType.StoredProcedure
            REQSPSELUPDRCPTNO.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUsrId"
            oParam.ParamValue = CrtUsrId
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCshDeptCd"
            oParam.ParamValue = CshDptCd
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pWingCd"
            oParam.ParamValue = WingCd
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pConcNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            REQSPSELUPDRCPTNO.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(REQSPSELUPDRCPTNO)
            For Each oprm As DBRequest.Parameter In REQSPSELUPDRCPTNO.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    ConcNo = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            SpSelUpdOPConcNo = ConcNo

            Return SpSelUpdOPConcNo


        Catch ex As Exception
            ofactory.RollBackExecution()
            SpSelUpdOPConcNo = 0 'anamika 20171016
            strErrMsg.Add("Concession Receipt Number not Generated")  'anamika 20171016
            chrErrFlg = "Y"
        End Try


    End Function
    '20140103
#End Region


#Region "rcpt_no(csh_dept_wing)"
    'anamika 20140319
    ''' <summary>
    ''' Selects and updates rcpt_no
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="CrtUsrId"></param>
    ''' <param name="CshDptCd"></param>
    ''' <param name="WingCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SpSelUpdRcpNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                ByRef chrErrFlg As Char, _
                                ByVal cocd As String, _
                                ByVal div As Integer, _
                                ByVal loc As Integer, _
                                ByVal CrtUsrId As String, ByVal CshDptCd As Integer, ByVal WingCd As Integer) As Integer

        SpSelUpdRcpNo = Nothing
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim OpDepRfndNo As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try
            Dim DbReq As New DBRequest
            DbReq.Command = "[SpSelUpdRcpNo]" 'csh_dept_wing
            DbReq.CommandType = CommandType.StoredProcedure
            DbReq.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = cocd
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = div
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = loc
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUsrId"
            oParam.ParamValue = CrtUsrId
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCshDeptCd"
            oParam.ParamValue = CshDptCd
            DbReq.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pWingCd"
            oParam.ParamValue = WingCd
            DbReq.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pRcptNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            DbReq.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(DbReq)
            For Each oprm As DBRequest.Parameter In DbReq.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    OpDepRfndNo = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            SpSelUpdRcpNo = OpDepRfndNo

            Return SpSelUpdRcpNo


        Catch ex As Exception
            ofactory.RollBackExecution()
            SpSelUpdRcpNo = 0
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try


    End Function
#End Region

#Region " op_rfnd_no(csh_dept_wing)"
    'anamika 2014022014
    ''' <summary>
    '''select and update op_rfnd_no from  csh_dept_wing
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="CrtUsrId"></param>
    ''' <param name="CshDptCd"></param>
    ''' <param name="WingCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GedUpdateOpRfndNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                 ByRef chrErrFlg As Char, _
                                 ByVal cocd As String, _
                                 ByVal div As Integer, _
                                 ByVal loc As Integer, _
                                 ByVal CrtUsrId As String, ByVal CshDptCd As Integer, ByVal WingCd As Integer) As Integer

        GedUpdateOpRfndNo = Nothing
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim OpRfndNo As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try
            Dim DbReq As New DBRequest
            DbReq.Command = "[SpSelUpdOpRfndNo]" 'csh_dept_wing
            DbReq.CommandType = CommandType.StoredProcedure
            DbReq.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = cocd
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = div
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = loc
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUsrId"
            oParam.ParamValue = CrtUsrId
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCshDeptCd"
            oParam.ParamValue = CshDptCd
            DbReq.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pWingCd"
            oParam.ParamValue = WingCd
            DbReq.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pOpRfndNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            DbReq.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(DbReq)
            For Each oprm As DBRequest.Parameter In DbReq.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    OpRfndNo = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            GedUpdateOpRfndNo = OpRfndNo

            Return GedUpdateOpRfndNo


        Catch ex As Exception
            ofactory.RollBackExecution()
            GedUpdateOpRfndNo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try


    End Function
    'end code 20140214
#End Region

#Region " op_csh_mem_no(csh_dept_wing)"
    'anamika 2014022014
    ''' <summary>
    '''select and update op_csh_mem_no from  csh_dept_wing
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="CrtUsrId"></param>
    ''' <param name="CshDptCd"></param>
    ''' <param name="WingCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GedUpdateOpCashMemoNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                 ByRef chrErrFlg As Char, _
                                 ByVal cocd As String, _
                                 ByVal div As Integer, _
                                 ByVal loc As Integer, _
                                 ByVal CrtUsrId As String, ByVal CshDptCd As Integer, ByVal WingCd As Integer) As Integer

        GedUpdateOpCashMemoNo = Nothing
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim OpCshMemoNo As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try
            Dim DbReq As New DBRequest
            DbReq.Command = "[SpSelUpdOpCshMemNo]"
            DbReq.CommandType = CommandType.StoredProcedure
            DbReq.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = cocd
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = div
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = loc
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUsrId"
            oParam.ParamValue = CrtUsrId
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCshDeptCd"
            oParam.ParamValue = CshDptCd
            DbReq.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pWingCd"
            oParam.ParamValue = WingCd
            DbReq.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pOpCshMemoNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            DbReq.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(DbReq)
            For Each oprm As DBRequest.Parameter In DbReq.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    OpCshMemoNo = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            GedUpdateOpCashMemoNo = OpCshMemoNo

            Return GedUpdateOpCashMemoNo


        Catch ex As Exception
            ofactory.RollBackExecution()
            GedUpdateOpCashMemoNo = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try


    End Function
    'end code 20140214
#End Region

#Region "conc_no(csh_dept_wing) used for IP trnasactions"
    'Neha S.C 20140218 
    ''' <summary>
    ''' Selects and updates op rcpt no from Conc no
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="CrtUsrId"></param>
    ''' <param name="CshDptCd"></param>
    ''' <param name="WingCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SpSelUpdConcNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                ByRef chrErrFlg As Char, _
                                ByVal pcompanycode As String, _
                                ByVal pdiv As Integer, _
                                ByVal ploc As Integer, _
                                ByVal CrtUsrId As String, ByVal CshDptCd As Integer, ByVal WingCd As Integer) As Integer

        SpSelUpdConcNo = Nothing
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim ConcNo As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try
            Dim REQSPSELUPDConcNo As New DBRequest
            REQSPSELUPDConcNo.Command = "[SPSELUPDConcNo]" 'csh_dept_wing
            REQSPSELUPDConcNo.CommandType = CommandType.StoredProcedure
            REQSPSELUPDConcNo.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            REQSPSELUPDConcNo.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            REQSPSELUPDConcNo.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            REQSPSELUPDConcNo.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUsrId"
            oParam.ParamValue = CrtUsrId
            REQSPSELUPDConcNo.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCshDeptCd"
            oParam.ParamValue = CshDptCd
            REQSPSELUPDConcNo.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pWingCd"
            oParam.ParamValue = WingCd
            REQSPSELUPDConcNo.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pConcNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            REQSPSELUPDConcNo.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(REQSPSELUPDConcNo)
            For Each oprm As DBRequest.Parameter In REQSPSELUPDConcNo.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    ConcNo = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            SpSelUpdConcNo = ConcNo

            Return SpSelUpdConcNo


        Catch ex As Exception
            ofactory.RollBackExecution()
            SpSelUpdConcNo = ""
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function
    'End of code  Neha S.C 20140218
#End Region

#Region "rfnd_no(csh_dept_wing)"
    'anamika 20140219
    ''' <summary>
    ''' Selects and updates rfnd_no
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <param name="CrtUsrId"></param>
    ''' <param name="CshDptCd"></param>
    ''' <param name="WingCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SpSelUpdIPDepRfndNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                ByRef chrErrFlg As Char, _
                                ByVal cocd As String, _
                                ByVal div As Integer, _
                                ByVal loc As Integer, _
                                ByVal CrtUsrId As String, ByVal CshDptCd As Integer, ByVal WingCd As Integer) As Integer

        SpSelUpdIPDepRfndNo = Nothing
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim OpDepRfndNo As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try
            Dim DbReq As New DBRequest
            DbReq.Command = "[SpSelUpdDepRfndNo]"
            DbReq.CommandType = CommandType.StoredProcedure
            DbReq.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = cocd
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = div
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = loc
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUsrId"
            oParam.ParamValue = CrtUsrId
            DbReq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCshDeptCd"
            oParam.ParamValue = CshDptCd
            DbReq.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pWingCd"
            oParam.ParamValue = WingCd
            DbReq.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pDepRfndNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            DbReq.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(DbReq)
            For Each oprm As DBRequest.Parameter In DbReq.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    OpDepRfndNo = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            SpSelUpdIPDepRfndNo = OpDepRfndNo

            Return SpSelUpdIPDepRfndNo


        Catch ex As Exception
            ofactory.RollBackExecution()
            SpSelUpdIPDepRfndNo = ""
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try


    End Function
    'anamika 20140219
#End Region

#Region "CSH_DEPT_WING(MISC_PMNT_NO)"
    ''mayur 20140208
    ''' <summary>
    ''' to get latest MISC_PMNT_NO from CSH_DEPT_WING
    ''' </summary>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetUpdMiscPmntNo(ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal CashCd As Integer) As Integer

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        GetUpdMiscPmntNo = 0
        ofactory = New DBFactory

        Dim paymentno As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SpSelUpdMISCPMNTNO]" 'CSH_DEPT_WING
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = cocd
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = div
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = loc
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pcshdeptcd"
            oParam.ParamValue = loc
            ReqDbRequest.Parameters.Add(oParam)



            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pMISCPMNTNO"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(paymentno), 0, paymentno)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    paymentno = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdMiscPmntNo = paymentno
            Return GetUpdMiscPmntNo



        Catch ex As Exception
            GetUpdMiscPmntNo = Nothing
            ofactory.RollBackExecution()
            Return GetUpdMiscPmntNo
        End Try

    End Function
    ''mayur 20140208
#End Region

#Region "op_dep_rfnd_no(csh_dept_wing)"
    ''' <summary>
    ''' Selects and updates op rcpt no from Conc no
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="CrtUsrId"></param>
    ''' <param name="CshDptCd"></param>
    ''' <param name="WingCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SpSelUpdOpDepRfndNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                ByRef chrErrFlg As Char, _
                                ByVal pcompanycode As String, _
                                ByVal pdiv As Integer, _
                                ByVal ploc As Integer, _
                                ByVal CrtUsrId As String, ByVal CshDptCd As Integer, ByVal WingCd As Integer) As Integer

        SpSelUpdOpDepRfndNo = Nothing
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim OpDepRfndNo As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try
            Dim REQSPSELUPDRCPTNO As New DBRequest
            REQSPSELUPDRCPTNO.Command = "[SpSelUpdOpDepRfndNo]" 'csh_dept_wing
            REQSPSELUPDRCPTNO.CommandType = CommandType.StoredProcedure
            REQSPSELUPDRCPTNO.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUsrId"
            oParam.ParamValue = CrtUsrId
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCshDeptCd"
            oParam.ParamValue = CshDptCd
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pWingCd"
            oParam.ParamValue = WingCd
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pOpDepRfndNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            REQSPSELUPDRCPTNO.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(REQSPSELUPDRCPTNO)
            For Each oprm As DBRequest.Parameter In REQSPSELUPDRCPTNO.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    OpDepRfndNo = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            SpSelUpdOpDepRfndNo = OpDepRfndNo

            Return SpSelUpdOpDepRfndNo


        Catch ex As Exception
            ofactory.RollBackExecution()
            SpSelUpdOpDepRfndNo = ""
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try


    End Function
#End Region


#Region "DOC PMNT NO(csh_dept_wing)"
    '
    ''' <summary>
    ''' Selects and updates DOC PMNT NO from CSH DEPT WING
    ''' APARNA 2 MAY 2018
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="CrtUsrId"></param>
    ''' <param name="CshDptCd"></param>
    ''' <param name="WingCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SpSelUpdDOCPMNTNO(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                ByRef chrErrFlg As Char, _
                                ByVal pcompanycode As String, _
                                ByVal pdiv As Integer, _
                                ByVal ploc As Integer, _
                                ByVal CrtUsrId As String, ByVal CshDptCd As Integer, ByVal WingCd As Integer) As Integer

        SpSelUpdDOCPMNTNO = Nothing
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim PMNTNO As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try



            Dim REQSPSELUPDRCPTNO As New DBRequest
            REQSPSELUPDRCPTNO.Command = "[SpSelUpddocpmntno]"
            REQSPSELUPDRCPTNO.CommandType = CommandType.StoredProcedure
            REQSPSELUPDRCPTNO.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUsrId"
            oParam.ParamValue = CrtUsrId
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCshDeptCd"
            oParam.ParamValue = CshDptCd
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pWingCd"
            oParam.ParamValue = WingCd
            REQSPSELUPDRCPTNO.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pdocpmntno"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            REQSPSELUPDRCPTNO.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(REQSPSELUPDRCPTNO)
            For Each oprm As DBRequest.Parameter In REQSPSELUPDRCPTNO.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    PMNTNO = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            SpSelUpdDOCPMNTNO = PMNTNO

            Return SpSelUpdDOCPMNTNO


        Catch ex As Exception
            ofactory.RollBackExecution()
            SpSelUpdDOCPMNTNO = 0
            strErrMsg.Add("DOC PMNT NO Receipt Number not Generated")
            chrErrFlg = "Y"
        End Try


    End Function

#End Region

#End Region
#Region "******************************************ad_in_dt**************************************************************************"
#Region "adt_in_dt(updte MRNo)"


    Public Function GetUpdateMRNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal Cocd As String, _
                                  ByVal Div As Integer, _
                                  ByVal Loc As Integer) As Integer 'anamika 20140825

        GetUpdateMRNo = 0
        ofactory = New DBFactory

        Dim MRNo As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SpSelUpdPrmntMRNo]" 'adt_in_dt
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = Cocd
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            ReqDbRequest.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(MRNo), 0, MRNo)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    MRNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdateMRNo = MRNo
            Return GetUpdateMRNo
            GetUpdateMRNo = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateMRNo = ""
            Return GetUpdateMRNo
        End Try

    End Function
#End Region


#Region "adt_in_dt(updte PRMNT_PTN_N)"


    'Public Function GetUpdatePrmntPtnNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
    '                              ByRef chrErrFlg As Char, _
    '                              ByVal Cocd As String, _
    '                              ByVal Div As Integer, _
    '                              ByVal Loc As Integer) As Integer 'anamika 20140825
    'Public Function GetUpdatePrmntPtnNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
    '                           ByRef chrErrFlg As Char, _
    '                           ByVal Cocd As String, _
    '                           ByVal Div As Integer, _
    '                           ByVal Loc As Integer) As Long  'anamika 20140825

    '    GetUpdatePrmntPtnNo = 0
    '    ofactory = New DBFactory

    '    Dim PrmntPtnNo As Long = 0
    '    Try

    '        ofactory.BeginExecution("Y")

    '        Dim ReqDbRequest As New DBRequest
    '        ReqDbRequest.Command = "[SpSelUpdPrmntPtnNo]" 'adt_in_dt 'anamika 20150127
    '        ReqDbRequest.CommandType = CommandType.StoredProcedure
    '        ReqDbRequest.Transactional = True

    '        oParam = New DBRequest.Parameter
    '        oParam.ParamName = "pCOCD"
    '        oParam.ParamValue = Cocd
    '        ReqDbRequest.Parameters.Add(oParam)

    '        oParam = New DBRequest.Parameter
    '        oParam.ParamName = "pDIV"
    '        oParam.ParamValue = Div
    '        ReqDbRequest.Parameters.Add(oParam)

    '        oParam = New DBRequest.Parameter
    '        oParam.ParamName = "pLOC"
    '        oParam.ParamValue = Loc
    '        ReqDbRequest.Parameters.Add(oParam)


    '        Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
    '        outparam1.ParamName = "pNo"
    '        outparam1.ParamDirection = DBRequest.Direction.Output
    '        outparam1.ParamSize = 30
    '        outparam1.ParamType = DbType.Int64
    '        outparam1.ParamValue = IIf(IsDBNull(PrmntPtnNo), 0, PrmntPtnNo)
    '        ReqDbRequest.Parameters.Add(outparam1)


    '        ofactory.ExecuteNonQuery(ReqDbRequest)

    '        For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
    '            If oprm.ParamDirection = DBRequest.Direction.Output Then
    '                oprm.ParamSize = 30
    '                oprm.ParamType = DbType.Int64
    '                PrmntPtnNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
    '            End If
    '        Next
    '        GetUpdatePrmntPtnNo = Val(Div.ToString + Loc.ToString + PrmntPtnNo.ToString) 'anamika 20160830
    '        ofactory.CommitExecution()



    '        Return GetUpdatePrmntPtnNo
    '        GetUpdatePrmntPtnNo = Nothing


    '    Catch ex As Exception
    '        ofactory.RollBackExecution()
    '        strErrMsg.Add(ex.Message)
    '        chrErrFlg = "Y"
    '        GetUpdatePrmntPtnNo = ""
    '        Return GetUpdatePrmntPtnNo
    '    End Try

    'End Function


    Public Function GetUpdatePrmntPtnNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                   ByRef chrErrFlg As Char, _
                                   ByVal Cocd As String, _
                                   ByVal Div As Integer, _
                                   ByVal Loc As Integer) As Long  'anamika 20140825

        GetUpdatePrmntPtnNo = 0
        ofactory = New DBFactory

        Dim PrmntPtnNo As Long = 0
        Try

            'ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SpSelUpdPrmntPtnNo]" 'adt_in_dt 'anamika 20150127
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = Cocd
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            ReqDbRequest.Parameters.Add(oParam)

            'RasikV 20161022 - Start Here
            'Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            'outparam1.ParamName = "pNo"
            'outparam1.ParamDirection = DBRequest.Direction.Output
            'outparam1.ParamSize = 30
            'outparam1.ParamType = DbType.Int64
            'outparam1.ParamValue = IIf(IsDBNull(PrmntPtnNo), 0, PrmntPtnNo)
            'ReqDbRequest.Parameters.Add(outparam1)


            'ofactory.ExecuteNonQuery(ReqDbRequest)

            'For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
            '    If oprm.ParamDirection = DBRequest.Direction.Output Then
            '        oprm.ParamSize = 30
            '        oprm.ParamType = DbType.Int64
            '        PrmntPtnNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
            '    End If
            'Next
            'GetUpdatePrmntPtnNo = Val(Div.ToString + Loc.ToString + PrmntPtnNo.ToString) 'anamika 20160830
            'ofactory.CommitExecution()

            Dim dr1 As Object = ofactory.ExecuteDataReader(ReqDbRequest)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        PrmntPtnNo = .Item("PtnNo")
                    End With
                End While
            End If
            dr1.close()

            GetUpdatePrmntPtnNo = PrmntPtnNo
            'RasikV 20161022 - End Here

            Return GetUpdatePrmntPtnNo
            GetUpdatePrmntPtnNo = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdatePrmntPtnNo = ""
            Return GetUpdatePrmntPtnNo
        End Try

    End Function


#End Region

#Region "adt_in_dt(updte TMP_PTN_NO)"


    'Public Function GetUpdateTmpPtnNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
    '                              ByRef chrErrFlg As Char, _
    '                              ByVal Cocd As String, _
    '                              ByVal Div As Integer, _
    '                              ByVal Loc As Integer) As Integer 'anamika 20140825

    '    GetUpdateTmpPtnNo = 0
    '    ofactory = New DBFactory

    '    Dim TmpPtnNo As Integer = 0
    '    Try

    '        ofactory.BeginExecution("Y")

    '        Dim ReqDbRequest As New DBRequest
    '        ReqDbRequest.Command = "[SpSelUpdTmpPtnNo]" 'adt_in_dt
    '        ReqDbRequest.CommandType = CommandType.StoredProcedure
    '        ReqDbRequest.Transactional = True

    '        oParam = New DBRequest.Parameter
    '        oParam.ParamName = "pCOCD"
    '        oParam.ParamValue = Cocd
    '        ReqDbRequest.Parameters.Add(oParam)

    '        oParam = New DBRequest.Parameter
    '        oParam.ParamName = "pDIV"
    '        oParam.ParamValue = Div
    '        ReqDbRequest.Parameters.Add(oParam)

    '        oParam = New DBRequest.Parameter
    '        oParam.ParamName = "pLOC"
    '        oParam.ParamValue = Loc
    '        ReqDbRequest.Parameters.Add(oParam)


    '        Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
    '        outparam1.ParamName = "pNo"
    '        outparam1.ParamDirection = DBRequest.Direction.Output
    '        outparam1.ParamSize = 30
    '        outparam1.ParamType = DbType.Int64
    '        outparam1.ParamValue = IIf(IsDBNull(TmpPtnNo), 0, TmpPtnNo)
    '        ReqDbRequest.Parameters.Add(outparam1)


    '        ofactory.ExecuteNonQuery(ReqDbRequest)

    '        For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
    '            If oprm.ParamDirection = DBRequest.Direction.Output Then
    '                oprm.ParamSize = 30
    '                oprm.ParamType = DbType.Int64
    '                TmpPtnNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
    '            End If
    '        Next

    '        ofactory.CommitExecution()
    '        GetUpdateTmpPtnNo = TmpPtnNo
    '        Return GetUpdateTmpPtnNo
    '        GetUpdateTmpPtnNo = Nothing


    '    Catch ex As Exception
    '        ofactory.RollBackExecution()
    '        strErrMsg.Add(ex.Message)
    '        chrErrFlg = "Y"
    '        GetUpdateTmpPtnNo = ""
    '        Return GetUpdateTmpPtnNo
    '    End Try

    'End Function


    Public Function GetUpdateTmpPtnNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                      ByRef chrErrFlg As Char, _
                                      ByVal Cocd As String, _
                                      ByVal Div As Integer, _
                                      ByVal Loc As Integer) As Integer 'anamika 20140825

        GetUpdateTmpPtnNo = 0
        ofactory = New DBFactory

        Dim TmpPtnNo As Integer = 0
        Try

            'ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SpSelUpdTmpPtnNo]" 'adt_in_dt
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = Cocd
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = Div
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = Loc
            ReqDbRequest.Parameters.Add(oParam)

            'RasikV 20161022 - Start Here
            'Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            'outparam1.ParamName = "pNo"
            'outparam1.ParamDirection = DBRequest.Direction.Output
            'outparam1.ParamSize = 30
            'outparam1.ParamType = DbType.Int64
            'outparam1.ParamValue = IIf(IsDBNull(TmpPtnNo), 0, TmpPtnNo)
            'ReqDbRequest.Parameters.Add(outparam1)


            'ofactory.ExecuteNonQuery(ReqDbRequest)

            'For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
            '    If oprm.ParamDirection = DBRequest.Direction.Output Then
            '        oprm.ParamSize = 30
            '        oprm.ParamType = DbType.Int64
            '        TmpPtnNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
            '    End If
            'Next

            'ofactory.CommitExecution()
            '

            Dim dr1 As Object = ofactory.ExecuteDataReader(ReqDbRequest)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        TmpPtnNo = .Item("PtnNo")
                    End With
                End While
            End If
            dr1.close()

            'RasikV 20161022 - End Here

            GetUpdateTmpPtnNo = TmpPtnNo

            Return GetUpdateTmpPtnNo
            GetUpdateTmpPtnNo = Nothing

        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateTmpPtnNo = ""
            Return GetUpdateTmpPtnNo
        End Try

    End Function
#End Region
#Region "adt_in_dt(updte ip_no)"


    'Public Function GetUpdateIpNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
    '                              ByRef chrErrFlg As Char, _
    '                              ByVal pcompanycode As String, _
    '                              ByVal pdiv As Integer, _
    '                              ByVal ploc As Integer) As Integer
    'Public Function GetUpdateIpNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
    '                            ByRef chrErrFlg As Char, _
    '                            ByVal pcompanycode As String, _
    '                            ByVal pdiv As Integer, _
    '                            ByVal ploc As Integer) As Long 'anamika 20160907

    '    GetUpdateIpNo = 0
    '    ofactory = New DBFactory

    '    Dim IpNo As Long = 0
    '    Try

    '        '  ofactory.BeginExecution("Y")

    '        Dim ReqDbRequest As New DBRequest
    '        ReqDbRequest.Command = "[SPSELUPDIPNO]" 'adt_in_dt
    '        ReqDbRequest.CommandType = CommandType.StoredProcedure
    '        ReqDbRequest.Transactional = True

    '        oParam = New DBRequest.Parameter
    '        oParam.ParamName = "pCOCD"
    '        oParam.ParamValue = pcompanycode
    '        ReqDbRequest.Parameters.Add(oParam)

    '        oParam = New DBRequest.Parameter
    '        oParam.ParamName = "pDIV"
    '        oParam.ParamValue = pdiv
    '        ReqDbRequest.Parameters.Add(oParam)

    '        oParam = New DBRequest.Parameter
    '        oParam.ParamName = "pLOC"
    '        oParam.ParamValue = ploc
    '        ReqDbRequest.Parameters.Add(oParam)


    '        Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
    '        outparam1.ParamName = "pIpNo"
    '        outparam1.ParamDirection = DBRequest.Direction.Output
    '        outparam1.ParamSize = 30
    '        outparam1.ParamType = DbType.Int64
    '        outparam1.ParamValue = IIf(IsDBNull(IpNo), 0, IpNo)
    '        ReqDbRequest.Parameters.Add(outparam1)


    '        ofactory.ExecuteNonQuery(ReqDbRequest)

    '        For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
    '            If oprm.ParamDirection = DBRequest.Direction.Output Then
    '                oprm.ParamSize = 30
    '                oprm.ParamType = DbType.Int64
    '                IpNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
    '            End If
    '        Next

    '        '  ofactory.CommitExecution()
    '        GetUpdateIpNo = IpNo
    '        Return GetUpdateIpNo
    '        GetUpdateIpNo = Nothing


    '    Catch ex As Exception
    '        ofactory.RollBackExecution()
    '        strErrMsg.Add(ex.Message)
    '        chrErrFlg = "Y"
    '        GetUpdateIpNo = ""
    '        Return GetUpdateIpNo
    '    End Try

    'End Function
#End Region
#Region "adt_in_dt(updte dsch_adv_no)"
    'mayur 20130819
    Public Function GetUpdateAdvNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal pcompanycode As String, _
                                  ByVal pdiv As Integer, _
                                  ByVal ploc As Integer) As Integer

        GetUpdateAdvNo = 0
        ofactory = New DBFactory

        Dim IpNo As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SPSELUPDADVNO]" 'adt_in_dt
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pAdvNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(IpNo), 0, IpNo)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    IpNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdateAdvNo = IpNo
            Return GetUpdateAdvNo
            GetUpdateAdvNo = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateAdvNo = ""
            Return GetUpdateAdvNo
        End Try

    End Function
    'mayur 20130819
#End Region
#Region "adt_in_dt(update RsvNo)"
    'mayur 20131213
    ''' <summary>
    ''' get RSV_NO from adt_in_dt
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUpdateRsvNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                 ByRef chrErrFlg As Char, _
                                 ByVal pcompanycode As String, _
                                 ByVal pdiv As Integer, _
                                 ByVal ploc As Integer) As Integer

        GetUpdateRsvNo = 0
        ofactory = New DBFactory

        Dim IpNo As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SPSELUPDRSVNO]" 'ADT_IN_DT
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "prsvNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(IpNo), 0, IpNo)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    IpNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdateRsvNo = IpNo
            Return GetUpdateRsvNo
            GetUpdateRsvNo = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateRsvNo = ""
            Return GetUpdateRsvNo
        End Try

    End Function
    ' mayur 20131213
#End Region
#Region "adt_in_dt(updte fct_docu_no)"
    'mayur 20131018
    Public Function GetUpdateFCTDOCUNO(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal pcompanycode As String, _
                                  ByVal pdiv As Integer, _
                                  ByVal ploc As Integer) As Integer

        GetUpdateFCTDOCUNO = 0
        ofactory = New DBFactory

        Dim FCTDOCUNO As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SPSELUPDFCTDOCUNO]"  'fct_inst_ctrl1
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)

            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pFctDocuNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(FCTDOCUNO), 0, FCTDOCUNO)
            ReqDbRequest.Parameters.Add(outparam1)

            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    FCTDOCUNO = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdateFCTDOCUNO = FCTDOCUNO
            Return GetUpdateFCTDOCUNO
            GetUpdateFCTDOCUNO = Nothing

        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateFCTDOCUNO = ""
            Return GetUpdateFCTDOCUNO
        End Try

    End Function
    'mayur 20131018
#End Region
#End Region


#Region "BED_TRNSFR_LOG(trnsfr_no)"
    'mayur 20131118
    ''' <summary>
    ''' update bed transfer no
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetUpdateBedMstTrnsNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal pcompanycode As String, _
                                  ByVal pdiv As Integer, _
                                  ByVal ploc As Integer) As Integer

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        GetUpdateBedMstTrnsNo = 0
        ofactory = New DBFactory

        Dim TrnsNo As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SPGETINCRTRNNO]" 'BED_TRNSFR_LOG
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pTrnsNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(TrnsNo), 0, TrnsNo)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    TrnsNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdateBedMstTrnsNo = TrnsNo
            Return GetUpdateBedMstTrnsNo
            GetUpdateBedMstTrnsNo = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateBedMstTrnsNo = ""
            Return GetUpdateBedMstTrnsNo
        End Try

    End Function
    'mayur 20131118
#End Region

    '********************************************************insurance**********************************************************************
#Region "INSURANCE"

#Region "GET UPDATED GEN_NO FROM INS_GENNO TABLE"


    Public Function GetUpdateGENNO(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                 ByRef chrErrFlg As Char, _
                                 ByVal pcompanycode As String, _
                                 ByVal pdiv As Integer, _
                                 ByVal ploc As Integer, ByVal InsId As String) As Integer

        GetUpdateGENNO = 0
        ofactory = New DBFactory

        Dim IpNo As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SPSELUPDINSGENNO]"
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pInsId"
            oParam.ParamValue = InsId
            ReqDbRequest.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pGENNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(IpNo), 0, IpNo)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    IpNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdateGENNO = IpNo
            Return GetUpdateGENNO
            GetUpdateGENNO = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateGENNO = ""
            Return GetUpdateGENNO
        End Try

    End Function

#End Region
#End Region


#Region "ADT:Transaction Number Update"


    ''' <summary>
    ''' Transaction Number Update
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks>anamika 27 Aug 2016</remarks>
    Shared Function SpSelUpdAdtDcNos(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal pcompanycode As String, _
                                  ByVal pdiv As Integer, _
                                  ByVal ploc As Integer, ByVal DocTypeID As Integer, ByVal UserDtTm As Date, ByVal UserId As String) As Long

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        SpSelUpdAdtDcNos = 0
        ofactory = New DBFactory

        Dim TrnsNo As Long = 0
        Try

            ' ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SpSelUpdAdtDcNos]" 'AdtDcNos
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "cocd"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "divcd"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "loccd"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "DocTypeID"
            oParam.ParamValue = DocTypeID
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crtdttm"
            oParam.ParamValue = UserDtTm
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crtusrid"
            oParam.ParamValue = UserId
            ReqDbRequest.Parameters.Add(oParam)



            'Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            'outparam1.ParamName = "id"
            'outparam1.ParamDirection = DBRequest.Direction.Output
            'outparam1.ParamSize = 30
            'outparam1.ParamType = DbType.Int64
            'outparam1.ParamValue = IIf(IsDBNull(TrnsNo), 0, TrnsNo)
            'ReqDbRequest.Parameters.Add(outparam1)


            Dim dr1 As Object = ofactory.ExecuteDataReader(ReqDbRequest)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        TrnsNo = .Item("srno")
                    End With
                End While
            End If
            dr1.close()
            'For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
            '    If oprm.ParamDirection = DBRequest.Direction.Output Then
            '        oprm.ParamSize = 30
            '        oprm.ParamType = DbType.Int64
            '        TrnsNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
            '    End If
            'Next

            '  ofactory.CommitExecution()

            SpSelUpdAdtDcNos = TrnsNo
            Return SpSelUpdAdtDcNos
            SpSelUpdAdtDcNos = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpSelUpdAdtDcNos = 0
            Return SpSelUpdAdtDcNos
        End Try

    End Function
    Shared Function GetUpdateRsvNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                      ByRef chrErrFlg As Char, _
                                      ByVal pcompanycode As String, _
                                      ByVal pdiv As Integer, _
                                      ByVal ploc As Integer, ByVal DocTypeID As Integer, ByVal UserDtTm As Date, ByVal UserId As String) As Long

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        GetUpdateRsvNo = 0
        ofactory = New DBFactory

        Dim TrnsNo As Long = 0
        Try

            ' ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SpSelUpdAdtDcNos]" 'AdtDcNos
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "cocd"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "divcd"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "loccd"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "DocTypeID"
            oParam.ParamValue = DocTypeID
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crtdttm"
            oParam.ParamValue = UserDtTm
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crtusrid"
            oParam.ParamValue = UserId
            ReqDbRequest.Parameters.Add(oParam)


            'anamika 20161012
            'Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            'outparam1.ParamName = "id"
            'outparam1.ParamDirection = DBRequest.Direction.Output
            'outparam1.ParamSize = 30
            'outparam1.ParamType = DbType.Int64
            'outparam1.ParamValue = IIf(IsDBNull(TrnsNo), 0, TrnsNo)
            'ReqDbRequest.Parameters.Add(outparam1)


            'ofactory.ExecuteNonQuery(ReqDbRequest)

            'For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
            '    If oprm.ParamDirection = DBRequest.Direction.Output Then
            '        oprm.ParamSize = 30
            '        oprm.ParamType = DbType.Int64
            '        TrnsNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
            '    End If
            'Next


            Dim dr1 As Object = ofactory.ExecuteDataReader(ReqDbRequest)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        TrnsNo = .Item("srno")
                    End With
                End While
            End If
            'end 20161012
            dr1.close()
            '    GetUpdateRsvNo = Val(pdiv.ToString + ploc.ToString + TrnsNo.ToString) 'anamika 20160830 'commented by anamika discussed with pooja 20171009

            GetUpdateRsvNo = TrnsNo
            ' ofactory.CommitExecution()
            Return GetUpdateRsvNo
            'GetUpdateRsvNo = Nothing


        Catch ex As Exception
            '   ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateRsvNo = 0
            Return GetUpdateRsvNo
        End Try

    End Function

    Shared Function GetUpdateIpNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                      ByRef chrErrFlg As Char, _
                                      ByVal pcompanycode As String, _
                                      ByVal pdiv As Integer, _
                                      ByVal ploc As Integer, ByVal DocTypeID As Integer, ByVal UserDtTm As Date, ByVal UserId As String) As Long

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        GetUpdateIpNo = 0
        ofactory = New DBFactory

        Dim TrnsNo As Long = 0
        Try

            '   ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SpSelUpdAdtDcNos]" 'AdtDcNos
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "cocd"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "divcd"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "loccd"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "DocTypeID"
            oParam.ParamValue = DocTypeID
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crtdttm"
            oParam.ParamValue = UserDtTm
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crtusrid"
            oParam.ParamValue = UserId
            ReqDbRequest.Parameters.Add(oParam)


            'anamika 20161012
            'Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter 
            'outparam1.ParamName = "id"
            'outparam1.ParamDirection = DBRequest.Direction.Output
            'outparam1.ParamSize = 30
            'outparam1.ParamType = DbType.UInt64
            'outparam1.ParamValue = IIf(IsDBNull(TrnsNo), 0, TrnsNo)
            'ReqDbRequest.Parameters.Add(outparam1)


            'ofactory.ExecuteNonQuery(ReqDbRequest)

            'For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
            '    If oprm.ParamDirection = DBRequest.Direction.Output Then
            '        oprm.ParamSize = 30
            '        oprm.ParamType = DbType.UInt64
            '        TrnsNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
            '    End If
            'Next


            Dim dr1 As Object = ofactory.ExecuteDataReader(ReqDbRequest)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        TrnsNo = .Item("srno")
                    End With
                End While
            End If
            dr1.close()
            'anamika 20161012
            GetUpdateIpNo = Val(pdiv.ToString + ploc.ToString + TrnsNo.ToString) 'anamika 20160830

            GetUpdateIpNo = TrnsNo
            Return GetUpdateIpNo
            GetUpdateIpNo = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateIpNo = 0
            Return GetUpdateIpNo
        End Try

    End Function
#End Region


#Region "APPOINTMENT SCHEDULING SERIAL NO UPDATE"
    ''' <summary>
    ''' APPOINTMENT SCHEDULING SERIAL NO UPDATE
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="DocTypeID"></param>
    ''' <param name="UserDtTm"></param>
    ''' <param name="UserId"></param>
    ''' <returns></returns>
    ''' <remarks>APARNA 7 SEP 2016</remarks>
    Shared Function SPUPDDocSchedulingDcNos(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal pcompanycode As String, _
                                  ByVal pdiv As Integer, _
                                  ByVal ploc As Integer, ByVal DocTypeID As Integer, ByVal UserDtTm As Date, ByVal UserId As String) As Long

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        SPUPDDocSchedulingDcNos = 0
        ofactory = New DBFactory

        Dim TrnsNo As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SPUPDDocSchedulingDcNos]"
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "cocd"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "divcd"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "loccd"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "DocTypeID"
            oParam.ParamValue = DocTypeID
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crtdttm"
            oParam.ParamValue = UserDtTm
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crtusrid"
            oParam.ParamValue = UserId
            ReqDbRequest.Parameters.Add(oParam)



            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "id"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(TrnsNo), 0, TrnsNo)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    TrnsNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            SPUPDDocSchedulingDcNos = TrnsNo
            Return SPUPDDocSchedulingDcNos
            SPUPDDocSchedulingDcNos = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SPUPDDocSchedulingDcNos = 0
            Return SPUPDDocSchedulingDcNos
        End Try

    End Function
#End Region

#Region "IpPackageBillingDcNos:DocTypeID Update"



    Shared Function SpSelUpdIpPackageBillingDcNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal pcompanycode As String, _
                                  ByVal pdiv As Integer, _
                                  ByVal ploc As Integer, ByVal DocTypeID As Integer, ByVal UserDtTm As Date, ByVal UserId As String) As Long

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        SpSelUpdIpPackageBillingDcNo = 0
        ofactory = New DBFactory

        Dim PkgLinkId As Integer = 0
        Try

            ' ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SpSelUpdIpPackageBillingDcNo]"
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "cocd"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "divcd"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "loccd"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "DocTypeID"
            oParam.ParamValue = DocTypeID
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crtdttm"
            oParam.ParamValue = UserDtTm
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "userid"
            oParam.ParamValue = UserId
            ReqDbRequest.Parameters.Add(oParam)



            Dim dr1 As Object = ofactory.ExecuteDataReader(ReqDbRequest)
            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        PkgLinkId = .Item("srno")
                    End With
                End While
            End If
            dr1.close()


            SpSelUpdIpPackageBillingDcNo = PkgLinkId
            Return SpSelUpdIpPackageBillingDcNo
            SpSelUpdIpPackageBillingDcNo = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpSelUpdIpPackageBillingDcNo = 0
            Return SpSelUpdIpPackageBillingDcNo
        End Try

    End Function

#End Region


#Region "GET OPERATION NO BASED FOR OT CHARGE POSTING"  'RasikV 20170310

    Public Shared Function GetUpdIblInDtOprtnNo(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal UpdtDate As Date, ByVal UpdtTime As Date, ByVal UpdtUsrId As String) As Integer

        GetUpdIblInDtOprtnNo = Nothing

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim OprtnNo As Integer = 0
        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try

            Dim dbreq As New DBRequest
            dbreq.Command = "[dbo].[SpSelIblInDtOprtnNo]"
            dbreq.CommandType = CommandType.StoredProcedure
            dbreq.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
            oParam.ParamValue = CoCd
            dbreq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivCd"
            oParam.ParamValue = Div
            dbreq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLocCd"
            oParam.ParamValue = Loc
            dbreq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUpdtDt"
            oParam.ParamValue = Format(UpdtDate, "yyyy-MM-dd")
            dbreq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUpdtTm"
            oParam.ParamValue = UpdtTime 'Format(UpdtTime, "HH:mm:ss")
            dbreq.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUpdtUsrId"
            oParam.ParamValue = UpdtUsrId
            dbreq.Parameters.Add(oParam)

            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pOprtnNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(OprtnNo), 0, OprtnNo)
            dbreq.Parameters.Add(outparam1)

            ofactory.ExecuteNonQuery(dbreq)

            For Each oprm As DBRequest.Parameter In dbreq.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    OprtnNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdIblInDtOprtnNo = OprtnNo
            Return GetUpdIblInDtOprtnNo

        Catch ex As Exception
            ofactory.RollBackExecution()
            GetUpdIblInDtOprtnNo = ""
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
    End Function

#End Region


#Region "get updated deduction number"

    ''' <summary>
    ''' aparna 25 may 2017
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="DOCINVFYr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUpdateDocTrnDeductionNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                 ByRef chrErrFlg As Char, _
                                 ByVal pcompanycode As String, _
                                 ByVal pdiv As Integer, _
                                 ByVal ploc As Integer, _
                                 ByVal DOCINVFYr As Integer) As Integer

        GetUpdateDocTrnDeductionNo = 0
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter

        ofactory = New DBFactory
        Dim DedNo As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SPSELDOCDTRNNO]"
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDOCINVComp"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDOCINVDiv"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDOCINVLoc"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "PDOCINVFYr"
            oParam.ParamValue = DOCINVFYr
            ReqDbRequest.Parameters.Add(oParam)

            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pDOCDTRNTRNNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(DedNo), 0, DedNo)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    DedNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdateDocTrnDeductionNo = DedNo
            Return GetUpdateDocTrnDeductionNo
            GetUpdateDocTrnDeductionNo = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdateDocTrnDeductionNo = ""
            Return GetUpdateDocTrnDeductionNo
        End Try

    End Function
#End Region

    '******************************************OPD PAckage*************************************

#Region "OPPACKAGEREGNOS(updte PKGREGNO)"

    ''' <summary>
    ''' increment  PKGREGNO  by 1   into the table OPPACKAGEREGNOS
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="cocd"></param>
    ''' <param name="div"></param>
    ''' <param name="loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUpdOpdPackageRegNos(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                  ByRef chrErrFlg As Char, _
                                  ByVal cocd As String, _
                                  ByVal div As Integer, _
                                  ByVal loc As Integer, ByVal year As Integer) As Integer

        GetUpdOpdPackageRegNos = 0
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        ofactory = New DBFactory

        Dim DocRefNo As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SPSelUpdOPPACKAGEREGNOS]" 'OPPACKAGEREGNOS
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "COCD"
            oParam.ParamValue = cocd
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "DIVcd"
            oParam.ParamValue = div
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "LOCcd"
            oParam.ParamValue = loc
            ReqDbRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "PKGREGYR"
            oParam.ParamValue = year
            ReqDbRequest.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "PKGREGNO"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(DocRefNo), 0, DocRefNo)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    DocRefNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdOpdPackageRegNos = DocRefNo
            Return GetUpdOpdPackageRegNos
            GetUpdOpdPackageRegNos = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdOpdPackageRegNos = 0
            Return GetUpdOpdPackageRegNos
        End Try

    End Function

    'end code 20140407
#End Region

#Region "CSH_DEPT_WING(misc_rcpt_no)"   'RasikV 20171107
    Shared Function GetUpdMiscRcptNo(ByVal CoCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal CashDeptCd As Integer) As Integer

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        GetUpdMiscRcptNo = 0
        ofactory = New DBFactory

        Dim paymentno As Integer = 0
        Try
            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SpSelUpdMiscRcptNo]" 'CSH_DEPT_WING
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
            oParam.ParamValue = CoCd
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = Div
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
            oParam.ParamValue = Loc
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCshDeptCd"
            oParam.ParamValue = CashDeptCd
            ReqDbRequest.Parameters.Add(oParam)

            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pMiscRcptNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int64
            outparam1.ParamValue = IIf(IsDBNull(paymentno), 0, paymentno)
            ReqDbRequest.Parameters.Add(outparam1)

            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int64
                    paymentno = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdMiscRcptNo = paymentno
            Return GetUpdMiscRcptNo
        Catch ex As Exception
            GetUpdMiscRcptNo = Nothing
            ofactory.RollBackExecution()
            Return GetUpdMiscRcptNo
        End Try
    End Function
#End Region

#Region "GLDOCNOS"
#Region " fadnPostno(fadocsno)"
    'Neha S.C. 20140318
    ''' <summary>
    ''' select and update  fadocsno -> fadnPostno
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="RevDt"></param>
    ''' <param name="MainEventID"></param>
    ''' <param name="EventID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function GetFADocSNoForPost(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                ByRef chrErrFlg As Char, _
                                ByVal pcompanycode As String, _
                                ByVal pdiv As Integer, _
                                ByVal ploc As Integer, _
                                ByVal RevDt As Date, _
                                ByVal MainEventID As Integer, _
                                ByVal EventID As Integer, ByVal Yr As Integer) As Integer ' , Optional ByVal Yr As Integer = 2017

        GetFADocSNoForPost = Nothing

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim FADNPostNo As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try

            Dim REQSPSELUPDTFADOCSNO As New DBRequest
            REQSPSELUPDTFADOCSNO.Command = "[SPSELUPDTFADOCSNO001]"
            REQSPSELUPDTFADOCSNO.CommandType = CommandType.StoredProcedure
            REQSPSELUPDTFADOCSNO.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = CStr(pdiv)
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pRevDt"
            oParam.ParamValue = RevDt
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pMainEventID"
            oParam.ParamValue = MainEventID
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pEventID"
            oParam.ParamValue = EventID
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter 'aparna 6 nov 2017
            oParam.ParamName = "yr"
            oParam.ParamValue = Yr
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pFADNPostNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            REQSPSELUPDTFADOCSNO.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(REQSPSELUPDTFADOCSNO)
            For Each oprm As DBRequest.Parameter In REQSPSELUPDTFADOCSNO.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    FADNPostNo = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            GetFADocSNoForPost = FADNPostNo

            Return GetFADocSNoForPost


        Catch ex As Exception
            ofactory.RollBackExecution()
            GetFADocSNoForPost = ""
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
    'end 20140318
#End Region


#Region " fadnno(fadocsno)"
    'Neha S.C. 20140318
    ''' <summary>
    ''' select * update  fadocsno->fadnno
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="RevDt"></param>
    ''' <param name="MainEventID"></param>
    ''' <param name="EventID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function GetFADocSNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                ByRef chrErrFlg As Char, _
                                ByVal pcompanycode As String, _
                                ByVal pdiv As Integer, _
                                ByVal ploc As Integer, _
                                ByVal RevDt As Date, _
                                ByVal MainEventID As Integer, _
                                ByVal EventID As Integer, ByVal Yr As Integer) As Integer 'Optional ByVal Yr As Integer = 2017

        GetFADocSNo = Nothing

        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter
        Dim FADocSNo As Integer

        ofactory = New DBFactory
        ofactory.BeginExecution("Y")
        Try

            Dim REQSPSELUPDTFADOCSNO As New DBRequest
            REQSPSELUPDTFADOCSNO.Command = "[SPSELUPDTFADOCSNO]"
            REQSPSELUPDTFADOCSNO.CommandType = CommandType.StoredProcedure
            REQSPSELUPDTFADOCSNO.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = CStr(pdiv)
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pRevDt"
            oParam.ParamValue = RevDt
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pMainEventID"
            oParam.ParamValue = MainEventID
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pEventID"
            oParam.ParamValue = EventID
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter 'aparna 6 nov 2017
            oParam.ParamName = "yr"
            oParam.ParamValue = Yr
            REQSPSELUPDTFADOCSNO.Parameters.Add(oParam)

            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pFADNNO"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamValue = 0
            REQSPSELUPDTFADOCSNO.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(REQSPSELUPDTFADOCSNO)
            For Each oprm As DBRequest.Parameter In REQSPSELUPDTFADOCSNO.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    FADocSNo = oprm.ParamValue
                End If
            Next

            ofactory.CommitExecution()
            GetFADocSNo = FADocSNo

            Return GetFADocSNo


        Catch ex As Exception
            ofactory.RollBackExecution()
            GetFADocSNo = ""
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try

    End Function
    'end 20140318
#End Region











#End Region

    ''' <summary>
    ''' amol 8 mar 2018
    ''' </summary>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SPUPDTOKENNO001(pcompanycode As String, pdiv As Integer, ploc As Integer) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest

            .Command = "[SPUPDTOKENNO001]"
            .CommandType = CommandType.StoredProcedure
            .Transactional = True
            '**************************
            oParam = New DBRequest.Parameter
            oParam.ParamName = "@pCOCD"
            oParam.ParamValue = pcompanycode
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "@pDIV"
            oParam.ParamValue = pdiv
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "@pLOC"
            oParam.ParamValue = ploc
            .Parameters.Add(oParam)

            .CommandType = CommandType.StoredProcedure

        End With

        Return oRequest

    End Function


#Region "GET INTERNAL BATCH NO" 'RasikV 20180324
    Public Shared Function GetUpdItmMstIntrnlBchNo(ByRef strErrMsg As List(Of String), _
                                                ByRef chrErrFlg As Char, _
                                                ByVal CoCd As String, _
                                                ByVal Div As Integer, _
                                                ByVal Loc As Integer, _
                                                ByVal ItemCd As String, _
                                                ByVal IntrnlBchNo As Integer) As String

        GetUpdItmMstIntrnlBchNo = Nothing
        Dim ofactory As DBFactory
        Dim oParam As DBRequest.Parameter


        ofactory = New DBFactory
        Dim BchNo As String = Nothing
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[dbo].[SpSelUpdItmMstIntrnlBchNo]"
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCoCd"
            oParam.ParamValue = CoCd
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDiv"
            oParam.ParamValue = Div
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoc"
            oParam.ParamValue = Loc
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pItemCd"
            oParam.ParamValue = ItemCd
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIntrnlBchNo"
            oParam.ParamValue = IntrnlBchNo
            ReqDbRequest.Parameters.Add(oParam)

            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pBchNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.String
            outparam1.ParamValue = IIf(IsDBNull(BchNo), Nothing, BchNo)
            ReqDbRequest.Parameters.Add(outparam1)

            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.String
                    BchNo = IIf(IsDBNull(oprm.ParamValue), Nothing, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdItmMstIntrnlBchNo = BchNo
        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdItmMstIntrnlBchNo = Nothing
        End Try
        Return GetUpdItmMstIntrnlBchNo
    End Function

#End Region


#Region "get package close ref no of op package"

    ''' <summary>
    ''' get package close ref no of op package
    ''' aparna 11 jun 2018
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUpdatePkgClsRefNo(ByRef strErrMsg As System.Collections.Generic.List(Of String), _
                                 ByRef chrErrFlg As Char, _
                                 ByVal pcompanycode As String, _
                                 ByVal pdiv As Integer, _
                                 ByVal ploc As Integer) As Integer

        GetUpdatePkgClsRefNo = 0
        ofactory = New DBFactory

        Dim PkgClsRefNo As Integer = 0
        Try

            ofactory.BeginExecution("Y")

            Dim ReqDbRequest As New DBRequest
            ReqDbRequest.Command = "[SPSELUPDOPPKGREFNO]" 'ADT_IN_DT
            ReqDbRequest.CommandType = CommandType.StoredProcedure
            ReqDbRequest.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = pcompanycode
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIV"
            oParam.ParamValue = pdiv
            ReqDbRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOC"
            oParam.ParamValue = ploc
            ReqDbRequest.Parameters.Add(oParam)


            Dim outparam1 As DBRequest.Parameter = New DBRequest.Parameter
            outparam1.ParamName = "pPkgNo"
            outparam1.ParamDirection = DBRequest.Direction.Output
            outparam1.ParamSize = 30
            outparam1.ParamType = DbType.Int32
            outparam1.ParamValue = IIf(IsDBNull(PkgClsRefNo), 0, PkgClsRefNo)
            ReqDbRequest.Parameters.Add(outparam1)


            ofactory.ExecuteNonQuery(ReqDbRequest)

            For Each oprm As DBRequest.Parameter In ReqDbRequest.Parameters
                If oprm.ParamDirection = DBRequest.Direction.Output Then
                    oprm.ParamSize = 30
                    oprm.ParamType = DbType.Int32
                    PkgClsRefNo = IIf(IsDBNull(oprm.ParamValue), 0, oprm.ParamValue)
                End If
            Next

            ofactory.CommitExecution()
            GetUpdatePkgClsRefNo = PkgClsRefNo
            Return GetUpdatePkgClsRefNo
            GetUpdatePkgClsRefNo = Nothing


        Catch ex As Exception
            ofactory.RollBackExecution()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetUpdatePkgClsRefNo = ""
            Return GetUpdatePkgClsRefNo
        End Try

    End Function

#End Region
End Class

<DataContract()>
Public Class clsOpVoucherNo
    <DataMember()>
    Public Property CshDeptCd As Integer
    <DataMember()>
    Public Property WingsCd As Integer
    <DataMember()>
    Public Property FreeFlg As String
    <DataMember()>
    Public Property UserId As String
End Class