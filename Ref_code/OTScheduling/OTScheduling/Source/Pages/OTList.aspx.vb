#Region "IMPORTS"
Imports System.IO

Imports OTDashBoard.CmnSecurityFunSrvRef
Imports OTDashBoard.OTDashBoardSrvRef
Imports CWCommonLib.Sofscript
Imports Microsoft.Reporting.WebForms
Imports OTScheduling.OTSchedulingSerRef
Imports OTScheduling.CmnSecurityFunSrvRef


#End Region

Partial Class OTList
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLRATIONS"
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Dim arrobjMsgMst As List(Of clsMsgMst)



    Dim CurrentDt As Date
    Dim Revdate As Date

    ' Dim objList As New List(Of clsArPtnCoverLetterDtl)
    Dim objArMst As clsArMst
    Dim flg As Boolean
    'Dim objpatient As clsInPatient


#End Region

#Region "PAGE LOAD EVENTS"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            clsGeneral.CheckSession(Me.Context, Session("USERID"))
            clsGeneral.SetDefaultSessionValue(HfAppMdCd, HfAppSubMdCd, Session("MAINMODCODE"), Session("MAINSUBMODCODE"))

            Revdate = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")).ToString("dd/MM/yyyy")

            If Page.IsPostBack = False Then
                FnRights()  'APARNA 21 mar 2016
                loadErrorMsg()

                If ChkSysLock() = True Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 2), "txtsupcd", Page)
                    Exit Sub
                End If






                SetDefaultValues()
                GridBind(grdOTList)





            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub






#End Region

#Region "TEXTBOX EVENTS"

    Protected Sub txtFrmDate_TextChanged(sender As Object, e As EventArgs)

        Dim dt As Date
        If Date.TryParse(txtFrmDate.Text, dt) = False Then

            clsGeneral.ShowErrorPopUp("Enter Valid Date", "txtFrmDate", Page)
            txtFrmDate.Text = Revdate.ToString("dd/MM/yyyy")
            Return
        End If

        '        txtFrmDate.Text = Revdate.ToString("dd/MM/yyyy")





    End Sub


    Protected Sub txtToDate_TextChanged(sender As Object, e As EventArgs)

        Dim dt As Date  'Aart : 31AUg2018
        If Date.TryParse(txtToDate.Text, dt) = False Then

            clsGeneral.ShowErrorPopUp("Enter Valid Date", "txtToDate", Page)
            txtToDate.Text = Revdate.ToString("dd/MM/yyyy")
            Return
        End If

        ' txtToDate.Text = Revdate.ToString("dd/MM/yyyy")



    End Sub





#End Region

#Region "BUTTON EVENTS"












    Protected Sub BtnSessionState_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSessionState.Click  '  'Aarti 20171222

        Try
            Session.RemoveAll()
            Dim SubMenuPath As String
            SubMenuPath = ConfigurationManager.AppSettings("SessionClose") + "?" + Now
            ScriptManager.RegisterStartupScript(Me, [GetType](), "", "window.parent.location.href='" & SubMenuPath & "';", True)
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub


    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Try
            Session.RemoveAll() 'aparna 21 mar 2016
            Dim SubMenuPath As String
            SubMenuPath = ConfigurationManager.AppSettings("SubMenuPath") + "?" + Now
            ScriptManager.RegisterStartupScript(Me, [GetType](), "", "window.parent.location.href='" & SubMenuPath & "';", True)
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            '''''''added by khalid 28Nov2018 for task 	RGD001-13180
            'Response.Redirect(Request.Url.OriginalString)

            Clear()
            ClearAll()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub





#End Region

    Public Function ChkSysLock() As Boolean
        Try
            ChkSysLock = clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp("Error: " + ex.Message.Replace("'", ""), "", Page)
        End Try
    End Function

    Public Sub Clear()
        Try



            SetDefaultValues()



            GridBind(grdOTList)

















        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub

    Sub FnRights()
        Try
            Dim UserRights As String
            UserRights = clsGeneral.UserRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
            'If UserRights <> "" Then
            '    Dim objSessVar As New SessionVariables
            '    objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btnSave, SessionVariables.EnumFunctionRights.Save, UserRights)
            '    objSessVar = Nothing
            'Else
            '    btnExit_Click("", EventArgs.Empty)
            'End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub

    Private Sub SetDefaultValues()
        Try

            ChkDt.Checked = True
            txtFrmDate.Text = Format(Revdate, "dd/MM/yyyy")

            txtToDate.Text = Format(Revdate, "dd/MM/yyyy")



            GetPtnTypes()


            GetOTDtlsByFilter()


        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub


    Public Sub GetOTDtlsByFilter()
        Dim obj As List(Of clsFCTAPTOT)

        Dim APTM_STS As Int16 = 0
        If rdbActive.Checked Then
            APTM_STS = 1
        ElseIf rdbCancelled.Checked Then
            APTM_STS = 4


        End If

        obj = OTScheduling.GetDtlsByFilter(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(txtFrmDate.Text).ToString("dd/MM/yyyy"), CDate(txtToDate.Text).ToString("dd/MM/yyyy"), IIf(RBSurgary.Checked, "1", "2"), APTM_STS, IIf(txtCreditCoCd.Text <> "", txtCreditCoCd.Text, ""), IIf(txtOT.Text <> "", Convert.ToInt32(txtOT.Text), 0), IIf(ddlPtnTypByUser.SelectedValue.Trim <> "ALL", ddlPtnTypByUser.SelectedValue, 0))

        If obj IsNot Nothing Then
            grdOTList.DataSource = obj
            grdOTList.DataBind()
        End If
    End Sub





    Private Sub DropDownListBind(ByVal Ddl As DropDownList)  'RasikV 20161220
        Try
            Ddl.DataSource = New List(Of String)
            Ddl.DataBind()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub

    Private Sub GridBind(ByVal Grd As GridView)  'RasikV 20161220
        Try
            Grd.DataSource = New List(Of String)
            Grd.DataBind()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub

    Public Sub loadErrorMsg()
        arrobjMsgMst = New List(Of clsMsgMst)
        arrobjMsgMst = clsGeneral.GetmsgmstList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
        If arrobjMsgMst IsNot Nothing Then
            Session("ErrorMsg") = arrobjMsgMst
        End If
        arrobjMsgMst = Nothing
    End Sub


    'Protected Sub btnSearch_Click(sender As Object, e As EventArgs)


    '    If ValidateCreditCompany() = False Then

    '        Exit Sub
    '    End If

    '    Dim objIpDataList As New List(Of clsIpBill)
    '    Dim objOpDataList As New List(Of clsOpVch)


    '    Dim PatType As String = ""

    '    Dim PtnNo As Long = 0
    '    Dim IpNo As Long = 0


    '    Dim BillType As Integer
    '    If rdbCovered.Checked = True Then
    '        BillType = 1
    '    ElseIf rdbUnCovered.Checked = True Then
    '        BillType = 2
    '    Else
    '        BillType = 0

    '    End If


    '    Dim FrmDt As DateTime

    '    Dim ToDt As DateTime

    '    If (ChkDt.Checked = True) Then
    '        FrmDt = Convert.ToDateTime(txtFrmDate.Text)

    '        ToDt = Convert.ToDateTime(txtToDate.Text)

    '    Else
    '        FrmDt = Nothing
    '        ToDt = Nothing


    '    End If

    '    If RBInPtnno.Checked = True Then
    '        PatType = "I"
    '        If (txtIpOpNo.Text <> "") Then
    '            IpNo = Convert.ToInt64(txtIpOpNo.Text.Trim)

    '        End If

    '        objIpDataList = clsFrmOTDashBoard.GetDisPtnOutStandingBill(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), FrmDt, ToDt, PatType.Trim, PtnNo, IpNo, IIf(txtBillNo.Text.Trim = "", "0", Val(txtBillNo.Text.Trim)), BillType, Convert.ToInt64(txtCreditCoCd.Text))

    '        If objIpDataList IsNot Nothing Then
    '            If objIpDataList.Count > 0 Then
    '                grdLoadBill.DataSource = objIpDataList
    '                grdLoadBill.DataBind()
    '                caltotal()
    '            Else
    '                GridBind(grdLoadBill)
    '            End If

    '        Else
    '            GridBind(grdLoadBill)


    '        End If
    '    ElseIf RBPtnNo.Checked = True Then

    '            PatType = "O"

    '        If (txtIpOpNo.Text <> "") Then
    '            PtnNo = Convert.ToInt64(txtIpOpNo.Text.Trim)

    '        End If

    '        '   objOpDataList = clsFrmOTDashBoard.GetOpPtnOutStandingBill(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), FrmDt, ToDt, PatType.Trim, PtnNo, IpNo, IIf(txtBillNo.Text.Trim = "", "0", Val(txtBillNo.Text.Trim)), BillType, Convert.ToInt64(txtCreditCoCd.Text))
    '        If objOpDataList IsNot Nothing Then
    '            If objOpDataList.Count > 0 Then
    '                grdLoadBill.DataSource = objOpDataList
    '                grdLoadBill.DataBind()
    '                caltotal()
    '            Else
    '                GridBind(grdLoadBill)
    '            End If
    '        Else
    '            GridBind(grdLoadBill)

    '        End If

    '    End If







    'End Sub


    'Public Sub caltotal()
    '    Dim total As Decimal = 0.00D
    '    Dim totalAdjAmt As Decimal = 0.00D
    '    Dim totalBalAmt As Decimal = 0.00D
    '    Dim totaltdsAdjAmt As Decimal = 0.00D
    '    For Each dg1 As GridViewRow In grdLoadBill.Rows
    '        Dim TrnAmt As Label
    '        Dim TotAdjAmt As Label
    '        Dim TotBalAmt As Label
    '        Dim TottdsAdjAmt As Label

    '        TrnAmt = dg1.FindControl("lblDueAMT")
    '        TotAdjAmt = dg1.FindControl("lblAdjAmt")
    '        TotBalAmt = dg1.FindControl("lblBalAmt")

    '        TottdsAdjAmt = dg1.FindControl("lblTotTdsAdjAmt")

    '        total = Convert.ToDecimal(total) + Convert.ToDecimal(TrnAmt.Text)


    '    Next

    '    txttotal.Text = Convert.ToDecimal(total)

    'End Sub

    Protected Sub btnFinalSave_Click(sender As Object, e As EventArgs)


        'Try
        '    strErrMsg = New List(Of String)
        '    chrErrFlg = "N"

        '    Dim modcd As Integer = Session("MAINMODCODE")
        '    Dim submodcd As Integer = Session("MAINSUBMODCODE")
        '    Dim SessionId As Long = Val(Session("SESSIONID"))
        '    Dim SessionState As Integer = 0
        '    Revdate = Session("RevenueDate")
        '    Revdate = clsGeneral.Revdate()
        '    CurrentDt = clsGeneral.getdate

        '    If grdLoadBill.Rows.Count > 0 Then

        '        Dim clsobj As clsArPtnCoverLetterDtl = Nothing

        '        objList = New List(Of clsArPtnCoverLetterDtl)
        '        Dim cnt As Integer = 0
        '        For Each row As GridViewRow In grdLoadBill.Rows

        '            Dim chkselect As CheckBox = row.FindControl("chkselect")
        '            If chkselect.Checked = True Then
        '                cnt = cnt + 1
        '                clsobj = New clsArPtnCoverLetterDtl()
        '                Dim LetterNo As Long = 0
        '                LetterNo = Convert.ToInt64(txtletterNo.Text.Trim)
        '                Dim SrNo As Label = row.FindControl("lblSrNo")
        '                Dim IPOPflg As Label = row.FindControl("lblIpOp")
        '                Dim PtnNo As Label = row.FindControl("lblPtnNo")
        '                Dim IPNo As Label = row.FindControl("lblIpNo")

        '                Dim Wingcd As Label = row.FindControl("lblWindCd")
        '                Dim ArRefNo As Label = row.FindControl("lblCompRefNo")
        '                Dim BillNoVchNo As Label = row.FindControl("lblBillNo")

        '                Dim IPOPBillAmt As Label = row.FindControl("lblBILLAMT")
        '                Dim lblOpVchChargeCd As Label = row.FindControl("lblOpVchChargeCd")
        '                Dim lblOpVchFreeFlag As Label = row.FindControl("lblOpVchFreeFlag")

        '                Dim lblCompRefNo As Label = row.FindControl("lblCompRefNo")
        '                Dim lblWingCd As Label = row.FindControl("lblWingCd")

        '                Dim lblCashDepCd As Label = row.FindControl("lblCashDepCd")

        '                Dim lblBillYear As Label = row.FindControl("lblBillYear")

        '                Dim lblDueAMT As Label = row.FindControl("lblDueAMT")




        '                clsobj.ArCoverLetterNo = LetterNo
        '                clsobj.DtlSrNo = cnt



        '                clsobj.IPOPflg = IPOPflg.Text.Trim
        '                clsobj.PtnNo = Convert.ToInt64(PtnNo.Text)
        '                clsobj.IPNo = Convert.ToInt64(IPNo.Text)
        '                clsobj.OPVchChrgCd = IIf(lblOpVchChargeCd.Text = "", 0, Convert.ToInt32(lblOpVchChargeCd.Text)) 'Convert.ToInt32(lblOpVchChargeCd.Text)

        '                clsobj.OPFreeFlg = lblOpVchFreeFlag.Text


        '                clsobj.ArRefNo = lblCompRefNo.Text
        '                clsobj.OPCshDeptCd = IIf(lblCashDepCd.Text = "", 0, Convert.ToInt32(lblCashDepCd.Text)) ' Convert.ToInt32(lblCashDepCd.Text)

        '                clsobj.IPBillYear = IIf(lblBillYear.Text = "", 0, Convert.ToInt32(lblBillYear.Text)) ' 

        '                clsobj.IPOPBillAmt = Convert.ToDecimal(IPOPBillAmt.Text)

        '                clsobj.IPOPOsAmt = Convert.ToDecimal(lblDueAMT.Text)
        '                clsobj.CrtUsrID = Session("USERID").ToString

        '                clsobj.ArCd = Convert.ToInt32(txtCreditCoCd.Text)

        '                clsobj.LetterDate = Convert.ToDateTime(txtDt.Text)
        '                If RBInPtnno.Checked = True Then

        '                    clsobj.IPWingCd = IIf(lblWingCd.Text = "", 0, Convert.ToInt32(lblWingCd.Text))
        '                    clsobj.OPWingCd = Nothing
        '                    clsobj.IPBillNo = Convert.ToInt32(BillNoVchNo.Text)
        '                    clsobj.OPVchNo = Nothing

        '                Else


        '                    clsobj.IPWingCd = Nothing
        '                    clsobj.OPWingCd = Convert.ToInt32(lblWingCd.Text)

        '                    clsobj.IPBillNo = Nothing
        '                    clsobj.OPVchNo = Convert.ToInt32(BillNoVchNo.Text)
        '                End If


        '                objList.Add(clsobj)

        '            End If
        '        Next
        '    End If


        '    If clsFrmOTDashBoard.SaveRecord(strErrMsg, chrErrFlg, SessionState, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), SessionId, objList, Session("USERID")) = True Then
        '        Dim msg As String = ""
        '        msg = String.Format("Record Saved Successfully with LetterNo" & "    " & txtletterNo.Text.Trim & "  Do You Want to Print Report? ")


        '        ViewState("LetterNo") = txtletterNo.Text.ToString
        '        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "printconfirmation('  " & msg & "');", True)

        '        'clsGeneral.ShowErrorPopUp(msg, "", Page)
        '        'ClearAll()

        '    Else

        '        If (SessionState <> 1) Then
        '            'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "SessionStateConfirmation();", True)

        '            BtnSessionState_Click(sender, e)
        '        Else
        '            clsGeneral.ShowErrorPopUp(strErrMsg(0).Replace("'", "").Replace(",", "").Replace("""", ""), "", Page)
        '        End If
        '    End If


        'Catch ex As Exception

        'End Try
    End Sub

    'Protected Sub btnSave_Click(sender As Object, e As EventArgs)
    '    Try
    '        If ChkSysLock() = True Then
    '            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 2), "", Page)
    '            Exit Sub
    '        End If






    '        If grdLoadBill.Rows.Count = 0 Then
    '            clsGeneral.ShowErrorPopUp("No Record To Save", "", Page)


    '            'clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 6), "", Page)

    '            Exit Sub
    '        End If


    '        Dim cnt As Integer = 0
    '        For Each dg1 As GridViewRow In grdLoadBill.Rows


    '            Dim ChkSel As CheckBox = DirectCast(dg1.FindControl("chkselect"), CheckBox)


    '            If ChkSel.Checked = True Then

    '                cnt = cnt + 1

    '            End If
    '        Next


    '        If cnt = 0 Then
    '            clsGeneral.ShowErrorPopUp("Please Select Record", "", Page)
    '            Exit Sub
    '        End If



    '        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "savecnfirmation();", True)



    '    Catch ex As Exception

    '    End Try



    'End Sub



    Protected Sub txtCreditCoCd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCreditCoCd.TextChanged
        Try
            If ValidateCreditCompany() = False Then

                Exit Sub
            End If



            objArMst = OTScheduling.GetArMstDetailsByArCd(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtCreditCoCd.Text))
            If objArMst IsNot Nothing Then













                txtCreditCoDcd.Text = objArMst.ArLngNm















            Else
                If strErrMsg.Count > 0 Then
                    clsGeneral.ShowErrorPopUp(strErrMsg(0).Replace("'", "").Replace(",", "").Replace(".", ""), "txtCreditCoCd", Page)
                Else
                    clsGeneral.ShowErrorPopUp("Enter valid credit comapny code", "txtCreditCoCd", Page)
                    txtCreditCoCd.Text = ""
                    txtCreditCoDcd.Text = ""
                End If

                txtCreditCoDcd.Text = ""

            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "txtCreditCoCd", Page)
        End Try
    End Sub


    Public Function ValidateCreditCompany() As Boolean
        Try
            If txtCreditCoCd.Text = "" Then '
                clsGeneral.ShowErrorPopUp("Credit company code cannot be blank", "txtCreditCoCd", Page)

                'clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 8), "txtCreditCoCd", Page)

                txtCreditCoCd.Text = ""
                txtCreditCoDcd.Text = ""
                Return False
            End If

            If Integer.TryParse(txtCreditCoCd.Text, flg) = False Then '
                clsGeneral.ShowErrorPopUp("Enter valid credit comapny code", "txtCreditCoCd", Page)

                'clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 9), "txtCreditCoCd", Page)
                txtCreditCoCd.Text = ""
                txtCreditCoDcd.Text = ""
                Return False
            End If
            Return True
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
        Return True
    End Function



    'Protected Sub RBPtnNo_CheckedChanged(sender As Object, e As EventArgs) Handles RBPtnNo.CheckedChanged
    '    Try
    '        Clr()

    '        FunRbPtn()

    '        pnlDt.GroupingText = "VOUCHER DATE"


    '        'If (txtIpOpNo.Text <> "" And txtIpOpName.Text <> "") Then
    '        '    txtIpOpNo_TextChanged(sender, e)
    '        'End If
    '    Catch ex As Exception
    '        clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
    '    End Try
    'End Sub

    Public Sub Clr()
        txtOT.Text = ""
        txtOTDesc.Text = ""

        txtCreditCoCd.Text = ""
        txtCreditCoDcd.Text = ""


    End Sub



    'Protected Sub txtIpOpNo_TextChanged(sender As Object, e As EventArgs)


    '    Try


    '        strErrMsg = New List(Of String)
    '        chrErrFlg = "N"



    '        If txtCreditCoCd.Text = "" Then

    '            'clsGeneral.ShowErrorPopUp("Enter Credit Company", "txtCreditCoCd", Page)


    '            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 10), "txtCreditCoCd", Page)


    '            txtIpOpName.Text = ""
    '            txtIpOpNo.Text = ""
    '            Exit Sub

    '        End If

    '        If IsNumeric(txtCreditCoCd.Text.Trim()) Then
    '        Else
    '            '   clsGeneral.ShowErrorPopUp("Enter Credit Company", "txtCreditCoCd", Page)


    '            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 10), "txtCreditCoCd", Page)

    '            txtCreditCoCd.Text = ""
    '            txtCreditCoDcd.Text = ""
    '            txtIpOpName.Text = ""
    '            txtIpOpNo.Text = ""
    '            Exit Sub
    '        End If


    '        If RBInPtnno.Checked = True Then



    '            objpatient = clsFrmOTDashBoard.GetInpatientDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtIpOpNo.Text))
    '            If objpatient IsNot Nothing Then


    '                txtIpOpName.Text = objpatient.PatientFullName
    '                hdnPtnNo.Value = objpatient.PatientNo


    '                If objpatient.AdmissionStatusCode <> 3 Then

    '                    clsGeneral.ShowErrorPopUp("Patient Not Discharged", "txtIpOpNo", Page)

    '                    txtIpOpName.Text = ""
    '                    txtIpOpNo.Text = ""
    '                    Exit Sub
    '                End If

    '                'check bill exist for ip


    '                Dim obj As New clsIpBill

    '                obj = clsFrmOTDashBoard.CheckOSExistByIpNoArCd(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtIpOpNo.Text), Val(txtCreditCoCd.Text))
    '                If obj IsNot Nothing Then

    '                    If obj.AMT = 0 Then
    '                        clsGeneral.ShowErrorPopUp("No outstanding bills found for this patient", "txtIpOpNo", Page)


    '                        txtIpOpName.Text = ""
    '                        txtIpOpNo.Text = ""
    '                        Exit Sub

    '                    End If

    '                Else
    '                    clsGeneral.ShowErrorPopUp("No outstanding bills found for this patient", "txtIpOpNo", Page)


    '                    txtIpOpName.Text = ""
    '                    txtIpOpNo.Text = ""
    '                    Exit Sub






    '                End If




    '            Else


    '                clsGeneral.ShowErrorPopUp("Enter Valid Patient no", "txtIpNo", Page)

    '                txtIpOpName.Text = ""
    '                txtIpOpNo.Text = ""
    '                Exit Sub



    '            End If

    '        Else




    '            Dim objclsPatient As New clsPatient
    '            objclsPatient = clsFrmOTDashBoard.GetPatientDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt64(txtIpOpNo.Text))


    '            If (objclsPatient IsNot Nothing) Then
    '                txtIpOpName.Text = objclsPatient.PatientFullName




    '                'check vch exist

    '                Dim obj As New clsOpVchDetails
    '                obj = clsFrmOTDashBoard.CheckBillExistsForOp(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtIpOpNo.Text), Val(txtCreditCoCd.Text))
    '                If obj IsNot Nothing Then
    '                    If obj.UnStlmtAmt = 0 Then
    '                        clsGeneral.ShowErrorPopUp("No outstanding bills found for this patient", "txtIpOpNo", Page)


    '                        txtIpOpName.Text = ""
    '                        txtIpOpNo.Text = ""
    '                        Exit Sub

    '                    End If



    '                Else


    '                    clsGeneral.ShowErrorPopUp("No outstanding bills found for this patient", "txtIpOpNo", Page)


    '                    txtIpOpName.Text = ""
    '                    txtIpOpNo.Text = ""
    '                    Exit Sub


    '                End If
    '                'check vch exist end



    '            Else

    '                clsGeneral.ShowErrorPopUp("Enter Valid Patient no", "txtIpOpNo", Page)

    '                txtIpOpName.Text = ""
    '                txtIpOpNo.Text = ""
    '                Exit Sub




    '            End If




    '        End If















    '    Catch ex As Exception

    '    End Try






    '    ' ClearBillDtls()




    'End Sub



    Public Sub ClearAll()
        SetDefaultValues()
        txtOT.Text = ""
        txtOTDesc.Text = ""
        RBBooking.Checked = True
        RBSurgary.Checked = False
        rdbActive.Checked = False
        rdbCancelled.Checked = False
        rdbAll.Checked = True

        txttotal.Text = ""


        ChkDt.Checked = False
        txtFrmDate.Text = ""
        txtToDate.Text = ""


        GridBind(grdOTList)

        txtCreditCoCd.Text = ""
        txtCreditCoDcd.Text = ""

        txtOT.Text = ""
        txtOTDesc.Text = ""



    End Sub


    Protected Sub grdLoadBill_DataBound(sender As Object, e As EventArgs)



    End Sub

    Protected Sub grdLoadBill_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim lblBillType As Label = DirectCast(e.Row.FindControl("lblBillType"), Label)

            Dim chkSel As CheckBox = DirectCast(e.Row.FindControl("chkselect"), CheckBox)


            If lblBillType.Text = 1 Then
                chkSel.Enabled = False
                ' e.Row.BackColor = System.Drawing.Color.Bisque
            End If
        End If

    End Sub

    Protected Sub RBPtnNo_CheckedChanged1(sender As Object, e As EventArgs)

    End Sub

    Protected Sub RBInPtnno_CheckedChanged1(sender As Object, e As EventArgs)

    End Sub

    Protected Sub ChkDt_CheckedChanged(sender As Object, e As EventArgs)
        If ChkDt.Checked = True Then
            txtFrmDate.Enabled = True
            txtToDate.Enabled = True
            txtFrmDate.Text = Revdate.ToString("dd/MM/yyyy")
            txtToDate.Text = Revdate.ToString("dd/MM/yyyy")
        Else

            txtFrmDate.Enabled = False
            txtToDate.Enabled = False
            txtFrmDate.Text = ""
            txtToDate.Text = ""
        End If

    End Sub

    'Protected Sub btnFinalPrint_Click(sender As Object, e As EventArgs)

    '    Try
    '        Session("PrintPage") = "Default"
    '        Dim intNetID As Integer
    '        strErrMsg = New List(Of String)
    '        chrErrFlg = "N"
    '        Dim userid As String = Session("USERID")
    '        intNetID = 70956        ''Suppwisepayment.rdl
    '        'RevDt = Session("RevenueDate")
    '        Dim strNothing As String = Nothing
    '        Dim NUllDt As String = Nothing
    '        'Dim frmDt As Date = CDate(drpYear.Text & "/04/01")
    '        'Dim toDt As Date = CDate(Val(drpYear.Text) + 1 & "/03/31")

    '        Dim Param As New List(Of Microsoft.Reporting.WebForms.ReportParameter)

    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("Cocd", Session("COMPANYCODE").ToString))
    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("DivCd", Session("DIVCODE").ToString))
    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("LocCd", Session("LOCCODE").ToString))

    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("from_dt", NUllDt))
    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("to_date", NUllDt))


    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("ar_cd", Convert.ToInt32(txtCreditCoCd.Text)))

    '        Dim IpOpFlg As Char = ""

    '        If (RBInPtnno.Checked = True) Then
    '            IpOpFlg = "I"

    '        Else



    '            IpOpFlg = "O"
    '        End If


    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIpOpType", IpOpFlg.ToString))
    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("pLetterNo", ViewState("LetterNo").ToString()))

    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("usrid", userid))
    '        Param.Add(New Microsoft.Reporting.WebForms.ReportParameter("Duplicate", ""))


    '        'Pramila 13sep2017
    '        Session("Param") = Param

    '        Dim UseReportViewer As Boolean = False
    '        UseReportViewer = clsFrmOTDashBoard.GetPrntRptViewerRule8013(strErrMsg, chrErrFlg, Convert.ToString(Session("COMPANYCODE")), Convert.ToInt32(Session("DIVCODE")), Convert.ToInt32(Session("LOCCODE")))

    '        If UseReportViewer = False Then
    '            Dim pByteArray() As Byte = Nothing
    '            clsFrmOTDashBoard.SetParamAndViewReport(strErrMsg, chrErrFlg, Session("COMPANYCODE").ToString(), Convert.ToInt32(Session("DIVCODE")), Convert.ToInt32(Session("LOCCODE")), Convert.ToInt32(Session("MAINMODCODE")), Convert.ToInt32(Session("MAINSUBMODCODE")), intNetID, Param, pByteArray, Page)

    '            Session("ppdf") = pByteArray
    '        Else
    '            ''START : PRINT IN REPORT VIEWER CONTROL
    '            'USE BELOW PART OF CODE TO PRINT IN REPORT VIEWER CONTROL

    '            'comnted on 16May2017 and revert back to earlier code to print in pdf format on page.
    '            Session("param") = Param
    '            Session("netid") = intNetID
    '            ' ScriptManager.RegisterStartupScript(Me, [GetType](), "", "window.parent.location.href='ViewRpt1.aspx';", True)
    '            ' Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "window.parent.location.href='ReportViewerRpt.aspx';",  true);
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "window.parent.location.href='ReportViewerRpt.aspx';", True)

    '            'END : PRINT IN REPORT VIEWER CONTROL
    '        End If
    '        'Pramila 13sep2017

    '        ''SetSSRSParam will print the report
    '        ' clsBillPayment.SetParamAndViewReport(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), intNetID, Param, Session("ppdf"), Page)

    '    Catch ex As Exception
    '        clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
    '    End Try
    'End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs)
        Response.Redirect("AdmPrt.aspx")
    End Sub

    Protected Sub btnPrint_Click1(sender As Object, e As EventArgs)

    End Sub

    Protected Sub grdOTList_RowDataBound(sender As Object, e As GridViewRowEventArgs)

    End Sub


    Public Sub GetPtnTypes()

        Dim ObjPtnTypeList As New List(Of ClsUserPtnTypMst)
        Try


            ObjPtnTypeList = OTScheduling.GetPtnTypListByUser(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"))

            If strErrMsg IsNot Nothing Then
                If strErrMsg.Count > 0 Then
                    clsGeneral.ShowErrorPopUp("ObjPtnTypeList " & strErrMsg(0).ToString(), "", Page)
                End If
            End If


        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try

        If ObjPtnTypeList IsNot Nothing Then
            clsGeneral.FillDropDownList(ddlPtnTypByUser, "PtnTypDesc", "PtnTypCd", ObjPtnTypeList, 1, "ALL")
            Dim x = (From obj In ObjPtnTypeList Where obj.DefAccess = True Select obj.PtnTypCd)
            If x.Any() Then
                ddlPtnTypByUser.SelectedValue = x.FirstOrDefault
                Session("DefPtnTyp") = x.FirstOrDefault
            Else
                ddlPtnTypByUser.SelectedValue = "ALL"
            End If
        Else

            clsGeneral.ShowErrorPopUp("User do not have access to any of the patient type.", "", Page)
            Exit Sub

        End If
        '  btnexit_Click("", EventArgs.Empty)

    End Sub

    Protected Sub txtOT_TextChanged(sender As Object, e As EventArgs)
        Try
            strErrMsg = New List(Of String)
            chrErrFlg = "N"

            If txtOT.Text = "" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)
                txtOT.Text = ""
                txtOTDesc.Text = ""

            End If

            txtOTDesc.Text = OTScheduling.GetOtName(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtOT.Text))

            If txtOTDesc.Text = "" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 11), "txtot", Page)
                txtOT.Text = ""
                txtOTDesc.Text = ""

            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        GetOTDtlsByFilter()
    End Sub
End Class
