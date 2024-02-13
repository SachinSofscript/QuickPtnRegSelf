#Region "IMPORTS"
Imports OTScheduling.OTSchedulingSerRef
Imports OTScheduling.CmnSecurityFunSrvRef
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Drawing
Imports System.IO
Imports Microsoft.VisualBasic
Imports CWCommonLib.Sofscript
#End Region

Public Class Page_Default
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLRATIONS"
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Dim SessionStartTIme As Date
    Dim SessionEndTIme As Date
    Shared btnarrcnt As Integer = 0
    Dim stdfont As Font = New Font("MS Reference Sans Serif", 10)
    Shared serverdttm As Date
    Dim sessttm As Date
    Dim sessltcnt As Long
    Dim sesdivwt As Integer = 50
    Shared btnarr() As clsTimeSlot
    Shared arrsession() As clsSession
    Shared lvnoofsessions As Integer
    Shared flag As String
    Dim arrobjMsgMst As List(Of clsMsgMst)
#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Validate()

        If Not IsPostBack Then
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            FnRights()  'anamika 20161003
            Call loadErrorMsg()
            txtot.Focus()
            clsGeneral.CheckSession(Me.Context, Session("USERID"))
            clsGeneral.SetDefaultSessionValue(HfAppMdCd, HfAppSubMdCd, Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
            If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
                Exit Sub
            End If
            'txtdate.Text = "05-06-2016"
            txtdate.Text = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
            lblRevDate.Text = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")).ToString("dd/MM/yyyy")

            Dim getindirectbooking As List(Of ClsOtIndirectBookingLst)
            getindirectbooking = OTScheduling.GetOtIndirectBookingLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(lblRevDate.Text), CDate(txtdate.Text))
            'getindirectbooking(0).Status = 1

            If grdindirectbooking IsNot Nothing Then
                grdindirectbooking.DataSource = getindirectbooking
                grdindirectbooking.DataBind()
            Else
                DefaultGridDatabind(grdindirectbooking)
            End If

            LoadConvertOtToIp() ''Amol 10-11-2020 JSK001-147270
            txtot.Focus()

        End If
        If grdindirectbooking.Rows.Count <= 0 Then
            DefaultGridDatabind(grdindirectbooking)
        End If
    End Sub
#End Region

#Region "TEXTBOX EVENTS"
    Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs) Handles txtdate.TextChanged
        'txtdate.Text = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) 
        Dim getindirectbooking As List(Of ClsOtIndirectBookingLst)
        getindirectbooking = OTScheduling.GetOtIndirectBookingLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(lblRevDate.Text), CDate(txtdate.Text))

        grdindirectbooking.DataSource = getindirectbooking
        grdindirectbooking.DataBind()
    End Sub

    Protected Sub txtot_TextChanged(sender As Object, ByVal e As System.EventArgs) Handles txtot.TextChanged
        Try
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            txtotname.Text = OTScheduling.GetOtName(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtot.Text)
            If txtot.Text = "" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 11), "txtot", Page)  'Aarti 20163009
                txtot.Text = ""
                txtotname.Text = ""

            Else

                grdindirectbooking.Focus()
            End If

        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "BUTTON EVENTS"
    Protected Sub btncancelrequest_Click(sender As Object, e As EventArgs) Handles btncancelrequest.Click
        strErrMsg = New List(Of String)
        chrErrFlg = "N"
        If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
            Exit Sub
        End If
        Dim rdb As RadioButton

        '' Amol 2019-12-18 Remove Validation Bcz this unwanted
        'If txtot.Text = "" Then
        '    'clsGeneral.ShowErrorPopUp("Enter OT Number", "txtot", Page)
        '    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)   'Aarti 30 Sep 2016
        '    Exit Sub

        'End If
        '' Amol 2019-12-18 Remove Validation Bcz this unwanted

        Dim count As Integer

        For i As Integer = 0 To grdindirectbooking.Rows.Count - 1
            rdb = DirectCast(grdindirectbooking.Rows(i).FindControl("rbSel"), RadioButton)
            If rdb.Checked = False Then
            Else
                ScriptManager.RegisterClientScriptBlock(pnlMain, pnlMain.GetType(), Guid.NewGuid().ToString(), "savecnfirmation();", True)
                Exit Sub
            End If
        Next

        If count = 0 Then
            'clsGeneral.ShowErrorPopUp("Please Select OT Request Number", "", Page)
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 8), "", Page)    'Aarti 30 sep 2016
        End If


    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            cancelrequest()
            Dim getindirectbooking As List(Of ClsOtIndirectBookingLst)
            getindirectbooking = OTScheduling.GetOtIndirectBookingLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"),
                                                                      CDate(lblRevDate.Text), CDate(txtdate.Text))
            grdindirectbooking.DataSource = getindirectbooking
            grdindirectbooking.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnnewotrequest_Click(sender As Object, e As EventArgs) Handles btnnewotrequest.Click
        Response.Redirect("~/Pages/OTRequest.aspx")
    End Sub

    Protected Sub btndirectbking_Click(sender As Object, e As EventArgs) Handles btndirectbking.Click
        ' start Nutan 24 Jan 2022

        'Dim ObjUserModuleFnRights As New List(Of clsUserModuleFunction)
        'ObjUserModuleFnRights = OTScheduling.GetModFnDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
        'If ObjUserModuleFnRights IsNot Nothing Then
        '    If ObjUserModuleFnRights.Count > 0 Then
        '        For i As Integer = 0 To ObjUserModuleFnRights.Count - 1
        '            If ObjUserModuleFnRights(i).FunctionID = 2 And ObjUserModuleFnRights(i).IsActive = True Then
        '                clsGeneral.ShowErrorPopUp("Please set IsActive status 1 for function ID 2", "", Page)
        '                'btndirectbking.Enabled = False
        '            Else
        '                Response.Redirect("OtScheduling.aspx")
        '                'btndirectbking.Enabled = True
        '            End If
        '        Next i
        '    End If
        'End If

        'end Nutan 24 Jan 2022

        Response.Redirect("OtScheduling.aspx")
    End Sub

    Protected Sub btnindirectbking_Click(sender As Object, e As EventArgs) Handles btnindirectbking.Click

        strErrMsg = New List(Of String)
        chrErrFlg = "N"
        If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
            Exit Sub
        End If
        Dim rdb As RadioButton

        If txtot.Text = "" Then
            'clsGeneral.ShowErrorPopUp("Enter OT Number", "txtot", Page)
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)   'Aarti 30 Sep 2016
            Exit Sub

        End If

        Dim count As Integer


        For i As Integer = 0 To grdindirectbooking.Rows.Count - 1
            rdb = DirectCast(grdindirectbooking.Rows(i).FindControl("rbSel"), RadioButton)
            Dim chkop As New CheckBox
            chkop = DirectCast(grdindirectbooking.Rows(i).FindControl("chkOP"), CheckBox)

            If rdb.Checked = False Then
            Else
                count = 1
                Dim getindirectbooking As List(Of ClsOtIndirectBookingLst)
                getindirectbooking = OTScheduling.GetOtIndirectBookingLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(lblRevDate.Text), CDate(txtdate.Text))

                'COMMNTED BY APRANA : 23-NOV-2016
                'getindirectbooking(i).PtnNo.ToString()
                'getindirectbooking(i).DocCd.ToString()

                Response.Redirect("OtScheduling.aspx?otno=" + txtot.Text + "&patid=" + getindirectbooking(i).PtnNo.ToString() + "&docid=" + getindirectbooking(i).DocCd.ToString() + " &patname=" + getindirectbooking(i).PtnFullNm.ToString() + " &docname=" + getindirectbooking(i).DocFullNm.ToString() + " &expdate=" + getindirectbooking(i).ExpectedDate.Date.ToShortDateString() + "&TrnNo=" + getindirectbooking(i).TrnNo.ToString() + " &PtnActualPtnNo=" + getindirectbooking(i).PtnActualPtnNo.ToString() + "" + "&op=" + getindirectbooking(i).IsOfficePrmsnGiven.ToString() + "" + "&opremark=" + getindirectbooking(i).OfficePrmsnRmrk.ToString() + "")
                Exit Sub
            End If
        Next


        If count = 0 Then
            'clsGeneral.ShowErrorPopUp("Please Select OT Request Number", "", Page)
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 8), "", Page)    'Aarti 30 sep 2016
        End If

    End Sub

    Protected Sub btneditrequest_Click(sender As Object, e As EventArgs) Handles btneditrequest.Click

        strErrMsg = New List(Of String)
        chrErrFlg = "N"
        If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
            Exit Sub
        End If
        Dim rdb As RadioButton
        Dim count As Integer

        For i As Integer = 0 To grdindirectbooking.Rows.Count - 1
            rdb = DirectCast(grdindirectbooking.Rows(i).FindControl("rbSel"), RadioButton)
            If rdb.Checked = False Then

            Else
                count = 1
                Dim getindirectbooking As List(Of ClsOtIndirectBookingLst)
                getindirectbooking = OTScheduling.GetOtIndirectBookingLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(lblRevDate.Text), CDate(txtdate.Text))

                getindirectbooking(i).PtnNo.ToString()
                getindirectbooking(i).DocCd.ToString()

                Response.Redirect("~/Pages/OTRequest.aspx?patid=" + getindirectbooking(i).PtnNo.ToString() + "&docid=" + getindirectbooking(i).DocCd.ToString() + " &patname=" + getindirectbooking(i).PtnFullNm.ToString() + " &docname=" + getindirectbooking(i).DocFullNm.ToString() + " &expdate=" + getindirectbooking(i).ExpectedDate.Date.ToShortDateString() + "&TrnNo=" + getindirectbooking(i).TrnNo.ToString() + "" + "&op=" + getindirectbooking(i).IsOfficePrmsnGiven.ToString() + "" + "&opremark=" + getindirectbooking(i).OfficePrmsnRmrk.ToString() + "")
                Exit Sub
            End If
        Next

        If count = 0 Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 8), "", Page)
            'clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "rdb", Page)    'Aarti 30 sep 2016

        End If

    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Try
            Dim SubMenuPath As String
            SubMenuPath = ConfigurationManager.AppSettings("SubMenuPath") + "?" + Now
            ScriptManager.RegisterStartupScript(Me, [GetType](), "", "window.parent.location.href='" & SubMenuPath & "';", True)
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'rbByPatient.Checked = False
        txtot.Text = ""
        txtotname.Text = ""

        rdbOrderBy.SelectedValue = 0
        rdbOrderBy_CheckedChanged(sender, e)

        Dim rdb As RadioButton

        'Dim row As GridViewRow 
        For i As Integer = 0 To grdindirectbooking.Rows.Count - 1
            rdb = DirectCast(grdindirectbooking.Rows(i).FindControl("rbSel"), RadioButton)
            rdb.Checked = False
        Next

    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Response.Redirect("ViewPrint.aspx")
    End Sub
#End Region

#Region "FUNCTIONS" 'PRAGYA : 02-AUG-2016
    'Public Function finalvalidations() As Boolean
    '    finalvalidations = False
    '    If (txtdctid.Text) = "" Then
    '        clsGeneral.ShowErrorPopUp("please enter doctor code", "txtdctid", Page)
    '        Return False

    '    End If
    '    Return True
    'End Function

    Public Sub loadErrorMsg()
        arrobjMsgMst = New List(Of clsMsgMst)
        arrobjMsgMst = clsGeneral.GetmsgmstList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
        If arrobjMsgMst IsNot Nothing Then
            Session("ErrorMsg") = arrobjMsgMst
        End If
        arrobjMsgMst = Nothing
    End Sub

    Sub FnRights()


        Dim UserRights As String
        UserRights = clsGeneral.UserRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
        If UserRights <> "" Then
            Dim objSessVar As New SessionVariables
            objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btncancelrequest, SessionVariables.EnumFunctionRights.Delete, UserRights)
            objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btndirectbking, SessionVariables.EnumFunctionRights.Save, UserRights)
            objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btnindirectbking, SessionVariables.EnumFunctionRights.Save, UserRights)
            objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btnnewotrequest, SessionVariables.EnumFunctionRights.Save, UserRights)
            objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btneditrequest, SessionVariables.EnumFunctionRights.Save, UserRights)

            objSessVar = Nothing


        Else
            btnExit_Click("", EventArgs.Empty)
        End If
    End Sub

    Public Sub DefaultGridDatabind(ByVal grd As GridView)
        Try
            grd.DataSource = New List(Of String)
            grd.DataBind()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Private Sub cancelrequest()
        Try
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
                clsGeneral.ShowErrorPopUp("System is Locked", "", Page)
                Exit Sub
            End If

            Dim getindirectbooking As List(Of ClsOtIndirectBookingLst)
            getindirectbooking = OTScheduling.GetOtIndirectBookingLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(lblRevDate.Text), CDate(txtdate.Text))

            serverdttm = clsGeneral.getdate()

            Dim chkrequest As Boolean
            Dim rdb As RadioButton
            Dim PtnNo As Label
            Dim count As Integer

            For i As Integer = 0 To grdindirectbooking.Rows.Count - 1

                rdb = DirectCast(grdindirectbooking.Rows(i).FindControl("rbSel"), RadioButton)
                PtnNo = DirectCast(grdindirectbooking.Rows(i).FindControl("lblptnno"), Label)

                If rdb.Checked = False Then

                Else
                    count = 1
                    chkrequest = OTScheduling.CancelOtIndirectBooking(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), getindirectbooking(i).TrnNo.ToString(), Val(PtnNo.Text), Session("USERID"), CDate(serverdttm))
                    If (chkrequest = True) Then
                        txtot.Focus()
                    End If
                    Exit Sub
                End If

            Next
            If count = 0 Then
                'clsGeneral.ShowErrorPopUp("Please Select OT Request Number", "", Page)
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 8), "rdb", Page)    'Aarti 30 Sep 2016
                'Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "RADIO BUTTON EVENTS"
    Protected Sub rdbOrderBy_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdbOrderBy.SelectedIndexChanged

        Try


            strErrMsg = New List(Of String)
            chrErrFlg = "N"

            Dim objPatient As List(Of ClsOtIndirectBookingLst)
            Dim SortByPatientN As List(Of ClsOtIndirectBookingLst)
            objPatient = OTScheduling.GetOtIndirectBookingLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(lblRevDate.Text), CDate(txtdate.Text))


            If rdbOrderBy.SelectedValue = 0 Then  ''Req No Wise Order by
                SortByPatientN = (From obj1 In objPatient Order By obj1.TrnNo Select obj1).ToList()
            ElseIf rdbOrderBy.SelectedValue = 1 Then ''Ptn No Wise Order by
                SortByPatientN = (From obj1 In objPatient Order By obj1.PtnNo Select obj1).ToList()
            ElseIf rdbOrderBy.SelectedValue = 2 Then ''PtnName Wise Order by
                SortByPatientN = (From obj1 In objPatient Order By obj1.PtnFullNm Select obj1).ToList()
            ElseIf rdbOrderBy.SelectedValue = 3 Then ''Doc Name Wise Order by
                SortByPatientN = (From obj1 In objPatient Order By obj1.DocFullNm Select obj1).ToList()
            Else
                SortByPatientN = (From obj1 In objPatient Order By obj1.TrnNo Select obj1).ToList()
            End If


            If SortByPatientN.Count > 0 Then
                grdindirectbooking.DataSource = SortByPatientN
                grdindirectbooking.DataBind()

            End If
        Catch ex As Exception
            Dim msg As String
            msg = clsGeneral.singleQuote(Replace(ex.Message, "'", ""))
            clsGeneral.ShowErrorPopUp(msg, "", Page)
        End Try

    End Sub

    Protected Sub rbSel_CheckedChanged(sender As Object, e As EventArgs)
        Try

            ViewState("PatNo") = Nothing

            Dim rb As RadioButton = TryCast(sender, RadioButton)
            Dim row As GridViewRow = DirectCast(rb.NamingContainer, GridViewRow)
            Dim i As Integer
            i = System.Convert.ToInt32(row.RowIndex)

            Dim lblptnno As Label

            If rb.Checked = True Then
                lblptnno = DirectCast(grdindirectbooking.Rows(i).FindControl("lblptnno"), Label)

                ViewState("PatNo") = lblptnno.Text
            Else
                ViewState("PatNo") = Nothing

            End If





            'rb.Checked = False
            '






        Catch ex As Exception
            Dim msg As String
            msg = clsGeneral.singleQuote(Replace(ex.Message, "'", ""))
            clsGeneral.ShowErrorPopUp(msg, "", Page)
        End Try
    End Sub
#End Region


    Private Sub LoadConvertOtToIp() ''Amol 10-11-2020 JSK001-147270
        Try

            DefaultGridDatabind(grdOtList)
            Dim IsDataFound As Boolean = False
            Dim ObjList As List(Of clsConvertOpToIp)
            ObjList = OTScheduling.GetOpToIpConvertPtnListForOt(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 0, CDate(txtdate.Text))

            If ObjList IsNot Nothing Then
                If ObjList.Count > 0 Then
                    IsDataFound = True
                End If
            End If


            If IsDataFound = True Then

                btnConvertToIp.Visible = True

                grdOtList.DataSource = ObjList
                grdOtList.DataBind()
            Else
                btnConvertToIp.Visible = False
                DefaultGridDatabind(grdOtList)
            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try


    End Sub

    Private Sub ShowHideCovertOpToIp(IsShow As Boolean) ''Amol 10-11-2020 JSK001-147270

        If IsShow = True Then
            divPopupCovertOpToIp.Visible = True
            divOverlayPopupCovertOpToIp.Style("display") = "block"
            UpPopupCovertOpToIp.Update()
        ElseIf IsShow = False Then
            divPopupCovertOpToIp.Visible = False
            divOverlayPopupCovertOpToIp.Style("display") = "none"
            UpPopupCovertOpToIp.Update()
        End If


    End Sub

    Protected Sub btnConvertToIp_Click(sender As Object, e As EventArgs) Handles btnConvertToIp.Click
        Try
            ShowHideCovertOpToIp(True)
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub


    Protected Sub btnClosePopupCovertOpToIp_Click(sender As Object, e As EventArgs) Handles btnClosePopupCovertOpToIp.Click
        Try
            ShowHideCovertOpToIp(False)
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Try
            Dim RowData = DirectCast((DirectCast(sender, Control).NamingContainer), GridViewRow)
            Dim PtnNo As Long = Convert.ToInt64(DirectCast(RowData.FindControl("lblptnno"), Label).Text)
            Dim IpNo As Long = Convert.ToInt64(DirectCast(RowData.FindControl("lblIpNo"), Label).Text)
            Dim ApptNo As Integer = Convert.ToInt32(DirectCast(RowData.FindControl("lblApptNo"), Label).Text)

            Dim IsUpdate As Boolean = False
            IsUpdate = OTScheduling.ConvertOpToIp(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), ApptNo, IpNo, PtnNo)

            If IsUpdate = True Then
                clsGeneral.ShowErrorPopUp("Record Converted Successfully", "", Page)
                LoadConvertOtToIp()
                'UpPopupCovertOpToIp.Update()
                ShowHideCovertOpToIp(False)
            Else

                If strErrMsg IsNot Nothing Then
                    If strErrMsg.Count > 0 Then
                        clsGeneral.ShowErrorPopUp(strErrMsg(0).ToString(), "", Page)
                    End If
                End If
            End If



        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub



    Protected Sub BtnOtList_Click(sender As Object, e As EventArgs) Handles BtnOtList.Click
        Try
            Response.Redirect("OTDashBoard.aspx")
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
    Protected Sub lnkOSDetail_Click(sender As Object, e As EventArgs)
        Try

            Dim COMPANYCODE As String = Session("COMPANYCODE")
            Dim DIVCODE As Integer = Session("DIVCODE")
            Dim LOCCODE As Integer = Session("LOCCODE")
            Dim orgdue As Double
            Dim due As Double
            'DirectCast(grdindirectbooking.Rows(RowData.RowIndex).FindControl("chkOP"), CheckBox)

            'Session("OS") =  


            'Dim lblptn As New Label
            'For i As Integer = 0 To grdindirectbooking.Rows.Count - 1
            '    lblptn = DirectCast(grdindirectbooking.Rows(i).FindControl("lblptnno"), Label)
            '    ViewState("PatNo") = lblptn.Text
            'Next

            Dim RowData = DirectCast((DirectCast(sender, Control).NamingContainer), GridViewRow)

            Dim lblptn As New Label
            lblptn = DirectCast(grdindirectbooking.Rows(RowData.RowIndex).FindControl("lblptnno"), Label)
            'lblptn = DirectCast(grdindirectbooking.FindControl("lblptnno"), Label)

            ViewState("PatNo") = lblptn.Text

            Dim objlst As List(Of IpPostVoucherServiceReference.clsIpDepRcpt) = New List(Of IpPostVoucherServiceReference.clsIpDepRcpt)
            ' Dim due As Double = 0.0
            due = 0.0

            objlst = clsIpPostVoucher.getBalanceDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), ViewState("PatNo"))
            If objlst IsNot Nothing Then
                If objlst.Count > 0 Then
                    lblunstldamnt.Text = Format(objlst(0).UnSettled_Amnt, "N2")
                    lblunbldamnt.Text = Format(objlst(0).UnBilled_Amnt, "N2")
                    lbldepbal.Text = Format(objlst(0).Deposit_Bal, "N2")



                    orgdue = objlst(0).Deposit_Bal - (Convert.ToDouble(objlst(0).UnSettled_Amnt) + Convert.ToDouble(objlst(0).UnBilled_Amnt))
                    due = objlst(0).Deposit_Bal - (Convert.ToDouble(objlst(0).UnSettled_Amnt) + Convert.ToDouble(objlst(0).UnBilled_Amnt))
                    If (orgdue < 0) Then
                        lbldueamntnm.Text = "Due Amount :  "
                    Else
                        lbldueamntnm.Text = "Balance Amount :  "
                    End If
                    lbldueamnt.Text = Format((Math.Abs(orgdue)), "N2")
                Else
                    lblunstldamnt.Text = "0.00"
                    lblunbldamnt.Text = "0.00"
                    lbldepbal.Text = "0.00"
                    lbldueamnt.Text = "0.00"


                End If
            Else
                lblunstldamnt.Text = "0.00"
                lblunbldamnt.Text = "0.00"
                lbldepbal.Text = "0.00"
                lbldueamnt.Text = "0.00"

            End If
            If ViewState("PatNo") = 0 Then
                lblunstldamnt.Text = "0.00"
                lblunbldamnt.Text = "0.00"
                lbldepbal.Text = "0.00"
                lbldueamnt.Text = "0.00"
            End If
            divPopupIPOPPtntypwisetrn.Visible = True
            upPopupIPOPPtntypwisetrn.Update()

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
    Protected Sub btnClosePopup_Click(sender As Object, e As EventArgs) Handles btnClosePopup.Click '#Trupti 14 JUN 2021
        divPopupIPOPPtntypwisetrn.Visible = False

        ckhoffcperm.Checked = False
        upPopupIPOPPtntypwisetrn.Update()
    End Sub

    Private Sub grdindirectbooking_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdindirectbooking.SelectedIndexChanged

    End Sub
    Protected Sub chkOP_CheckedChanged(sender As Object, e As EventArgs)   'Nutan 12 Jan 2022
        Try

            Dim chkop As New CheckBox
            Dim expDate As New Label
            Dim ptnNo As New Label
            Dim TrnNo As New Integer
            Dim RowData = DirectCast((DirectCast(sender, Control).NamingContainer), GridViewRow)
            Dim ApptNo As New Label

            chkop = DirectCast(grdindirectbooking.Rows(RowData.RowIndex).FindControl("chkOP"), CheckBox)
                ptnNo = DirectCast(grdindirectbooking.Rows(RowData.RowIndex).FindControl("lblptnno"), Label)
                ApptNo = DirectCast(grdindirectbooking.Rows(RowData.RowIndex).FindControl("lblApptNo"), Label)
                TrnNo = Convert.ToInt32(grdindirectbooking.Rows(RowData.RowIndex).Cells(1).Text)


                Dim save As New ClsOtIndirectBooking
                save.IsOfficePrmsnGiven = chkop.Checked
                save.UserDtTm = clsGeneral.getdate
                save.UserId = Session("USERID")
                save.ExpectedDate = CDate(lblRevDate.Text)
                save.OfficePrmsnDtTm = clsGeneral.getdate()
                save.OfficePrmsnByUsrID = Session("USERID")
                save.PtnNo = ptnNo.Text
                save.TrnNo = TrnNo
                Dim IndirectBookingOffchk As New Boolean
                IndirectBookingOffchk = True
                IndirectBookingOffchk = OTScheduling.SaveOfficePermissionChk(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), save)
            clsGeneral.ShowErrorPopUp("Office Permission is Updated", "", Page)
            If chkop.Checked = True Then
                chkop = DirectCast(grdindirectbooking.Rows(RowData.RowIndex).FindControl("chkOP"), CheckBox)

            Else

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub grdindirectbooking_RowDataBound(sender As Object, e As GridViewRowEventArgs)  'Nutan 14 Jan 2022
        Dim UserRights As String
        Dim objSessVar As New SessionVariables

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim chkop As CheckBox = DirectCast(e.Row.FindControl("chkop"), CheckBox)
            'Dim RowData = DirectCast((DirectCast(sender, Control).NamingContainer), GridViewRow)
            UserRights = clsGeneral.UserRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
            If UserRights <> "" Then
                objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, chkop, SessionVariables.EnumFunctionRights.Authorise, UserRights)
                ViewState("chkop") = chkop.Checked
                objSessVar = Nothing
            End If
        End If

    End Sub

    Public Sub ckhoffcperm_CheckedChanged(sender As Object, e As EventArgs)   'Nutan 24 Jan 2022
        '-------------------------------------------------------------------------
        ' OFFICE PERMISSION CHECKBOX ON PATIENT OS DETAILS POPUP....
        '-------------------------------------------------------------------------
        Try
            Dim rowSelected As GridViewRow = grdindirectbooking.Rows(Session("SelRowIndex"))
            Dim imgbutton As ImageButton = rowSelected.FindControl("imgOPStatus")


            Dim PtnNo As Label = rowSelected.FindControl("lblptnno")
            Dim save As New ClsOtIndirectBooking
            save.IsOfficePrmsnGiven = ckhoffcperm.Checked  ' Give or remove office permission from ot booking.
            save.UserDtTm = clsGeneral.getdate
            save.UserId = Session("USERID")
            save.ExpectedDate = CDate(lblRevDate.Text)
            save.OfficePrmsnDtTm = clsGeneral.getdate()
            save.OfficePrmsnByUsrID = Session("USERID")
            save.PtnNo = Session("PtnNo")
            save.TrnNo = Session("TrnNo")
            Dim IndirectBookingOffchk As New Boolean
            IndirectBookingOffchk = True
            IndirectBookingOffchk = OTScheduling.SaveOfficePermissionChk(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), save)


            If ckhoffcperm.Checked Then ' office permission is given then set tick image
                imgbutton.ImageUrl = "~/images/check.png"
                clsGeneral.ShowErrorPopUp("Office Permission is given", "", Page, True, "S")
            Else
                imgbutton.ImageUrl = "~/images/uncheck.png"
                clsGeneral.ShowErrorPopUp("Office Permission Removed", "", Page, True, "")
            End If

            upPopupIPOPPtntypwisetrn.Update()

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try

    End Sub

    Private Sub grdindirectbooking_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdindirectbooking.RowCommand

        If e.CommandName = "SelectOSDetails" Then
            Dim rowSelected As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
            Dim strcomData() As String
            strcomData = e.CommandArgument.ToString().Split(New Char() {","})
            Dim TrnNo As Integer = strcomData(1)
            Dim PtnNo As Integer = strcomData(0)
            Session("SelRowIndex") = -1
            Session("TrnNo") = TrnNo
            Session("PtnNo") = PtnNo

            Session("SelRowIndex") = rowSelected.RowIndex
            upPopupIPOPPtntypwisetrn.Update()



        End If


    End Sub

    Protected Sub btnOTDashBoardSche_Click(sender As Object, e As EventArgs) Handles btnOTDashBoardSche.Click
        Response.Redirect("~/Pages/OtDashboardSch.aspx")
    End Sub


    Private Sub FnUserWsModFnRights()  '#Trupti 21 NOV 2022
        Try
            Session("IsHideRate") = False
            Dim ObjUserModuleFnRights As New List(Of clsUserModuleFunction)
            ObjUserModuleFnRights = OTScheduling.GetUserWsModFnDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), 0, Session("USERID"))
            If ObjUserModuleFnRights IsNot Nothing Then
                If ObjUserModuleFnRights.Count > 0 Then
                    For i As Integer = 0 To ObjUserModuleFnRights.Count - 1
                        If ObjUserModuleFnRights(i).FunctionID = 1 And ObjUserModuleFnRights(i).HasRights Then
                            Session("IsHideRate") = True
                        End If
                    Next i
                End If
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message().Replace("'", ""), "", Page)
        End Try
    End Sub
End Class