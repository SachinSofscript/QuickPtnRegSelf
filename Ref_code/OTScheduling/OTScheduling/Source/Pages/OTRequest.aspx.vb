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

Public Class OTRequest
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLRATIONS"
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Dim stdfont As Font = New Font("MS Reference Sans Serif", 10)
    Dim arrobjMsgMst As List(Of clsMsgMst)
    Shared sess() As clsSession
    Shared btnarr() As clsTimeSlot
    Shared arrsession() As clsSession
    Dim flag As Boolean
#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Validate()
        strErrMsg = New List(Of String)
        chrErrFlg = "N"

        If Not IsPostBack Then
            txtpatid.Focus()
            If Request.QueryString("patid") = "" And Request.QueryString("docid") = "" Then
                Call loadErrorMsg()
                strErrMsg = New List(Of String)
                chrErrFlg = "N"

                clsGeneral.CheckSession(Me.Context, Session("USERID"))
                clsGeneral.SetDefaultSessionValue(HfAppMdCd, HfAppSubMdCd, Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
                If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
                    Exit Sub
                End If
                txtdate.Text = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
                Session("img123") = Nothing

                grdOtList.DataSource = Nothing
                grdOtList.DataBind()
                LblHeaderTitle.Text = "NEW OT REQUEST" ''Amol 07-11-2020 JSK001-147271	
            Else
                LblHeaderTitle.Text = "EDIT OT REQUEST" ''Amol 07-11-2020 JSK001-147271	
                Imgsearchptn.Enabled = False
                txtpatid.Enabled = False
                ' txtdctid.Enabled = False
                'imageSearchDoc.Enabled = False

                txtpatid.Text = Request("patid")
                txtpatname.Text = Request("patname")
                txtdctid.Text = Request("docid")
                txtdctname.Text = Request("docname")
                txtdate.Text = Request("expdate")
                LoadAllOtDtl(Convert.ToInt64(txtpatid.Text), Convert.ToDateTime(txtdate.Text)) ''Amol 07-11-2020 JSK001-147271	
                chkIsOffPerm.Checked = Request("op")  'Nutan 12-Jan-2022
                txtoffPermRmrk.Text = Request("opremark")  'Nutan 12-Jan-2022
            End If


            'Dim dt As Date = clsGeneral.getdate().ToShortDateString()
            'txtdate.Text = dt

        End If
    End Sub
#End Region

#Region "TEXTBOX EVENTS"
    Protected Sub txtpatid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpatid.TextChanged

        'Try
        '    strErrMsg = New List(Of String)
        '    chrErrFlg = "N"

        '    txtpatname.Text = OTScheduling.GetPatientFullName(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtpatid.Text)
        '    If txtpatid.Text = "" Then
        '        'clsGeneral.ShowErrorPopUp("Enter Proper Patient Number", "", Page)
        '        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 3), "", Page)  'Aarti 20163009
        '        txtpatid.Text = ""
        '        txtpatname.Text = ""
        '    Else
        '    End If
        'Catch ex As Exception

        'End Try

        grdOtList.DataSource = Nothing ''Amol 07-11-2020 JSK001-147271	
        grdOtList.DataBind()

        Try
            If txtpatid.Text = "" And txtpatname.Text = Nothing Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 3), "txtpatid", Page)
                txtpatid.Text = ""
                txtpatname.Text = ""
                Exit Sub
            End If
            If hfOffPermDtl.Value <> "" Then 'Nutan 12 Jan 2022
                txtoffPermRmrk.ToolTip = hfOffPermDtl.Value
            End If

            Dim objIpPatientVisit As New clsIpPatientVisit 'clsInPatient
            objIpPatientVisit = OTScheduling.GetInpatientDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtpatid.Text))

            If objIpPatientVisit Is Nothing Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 35), "txtpatid", Page)
                txtpatid.Text = ""
                txtpatname.Text = ""
                txtpatid.Focus()
            Else
                txtpatname.Text = objIpPatientVisit.ptnname.ToUpper()  'PatientFullName
                If (DischrgFolioPtnRuleInfo9233() = False) Then         'Aarti 10 Oct 2020
                    If (objIpPatientVisit.folStsCd = 2) Then
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 51), "txtpatid", Page)
                        txtpatid.Text = ""
                        txtpatname.Text = ""
                        txtpatid.Focus()
                        Exit Sub
                    End If

                    If (objIpPatientVisit.AdmStsCd = 3) Then
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 52), "txtpatid", Page)
                        txtpatid.Text = ""
                        txtpatname.Text = ""
                        txtpatid.Focus()
                        Exit Sub
                    End If
                End If


                imgIsolated.Visible = objIpPatientVisit.IsIsolation ''Amol 10-11-2020 JSK001-147272	


                txtdctid.Focus() 'anamika 20161003
            End If




            LoadAllOtDtl(Convert.ToInt64(txtpatid.Text), Convert.ToDateTime(txtdate.Text)) ''Amol 07-11-2020 JSK001-147271	


        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadAllOtDtl(IPNo As Long, CurDate As Date) ''Amol 07-11-2020 JSK001-147271	
        Try
            Dim getindirectbooking As List(Of ClsOtIndirectBookingLst)
            getindirectbooking = OTScheduling.GetIpWiseOtAppList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), IPNo, CDate(txtdate.Text))
            'getindirectbooking(0).Status = 1

            If grdOtList IsNot Nothing Then
                grdOtList.DataSource = getindirectbooking
                grdOtList.DataBind()
            Else
                grdOtList.DataSource = Nothing
                grdOtList.DataBind()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtdctid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdctid.TextChanged
        Try
            strErrMsg = New List(Of String)
            chrErrFlg = "N"

            If txtdctid.Text = "" And txtdctname.Text = Nothing Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 4), "txtdctid", Page)
                txtdctid.Text = ""
                txtdctname.Text = ""
                Exit Sub
            End If

            Dim DocName As String
            DocName = OTScheduling.GetDoctorName(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtdctid.Text)
            If DocName = "" And DocName Is Nothing Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 35), "txtdctid", Page)
                txtdctid.Text = ""
                txtdctname.Text = ""
                txtdctid.Focus() 'anamika 20161003
            Else
                txtdctname.Text = DocName.ToUpper()
                txtdate.Focus() 'anamika 20161003
            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs) Handles txtdate.TextChanged
        Try
            grdOtList.DataSource = Nothing  ''Amol 07-11-2020 JSK001-147271	
            grdOtList.DataBind()

            Dim RevDt As Date
            RevDt = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))

            If txtdate.Text = "" Then 'RasikV 20170125
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtdate", Page)
                txtdate.Text = Format(RevDt, "dd/MM/yyyy")
                Exit Sub
            End If

            If IsDate(txtdate.Text) = False Then 'RasikV 20170125
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtdate", Page)
                txtdate.Text = Format(RevDt, "dd/MM/yyyy")
                txtdate.Focus()
                Exit Sub
            End If

            LoadAllOtDtl(Convert.ToInt64(txtpatid.Text), Convert.ToDateTime(txtdate.Text)) ''Amol 07-11-2020 JSK001-147271	

            'If Convert.ToDateTime(txtdate.Text) <= RevDt Then 'RasikV 20170131
            '    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 41), "txtdate", Page)
            '    txtdate.Text = Format(RevDt, "dd/MM/yyyy")
            '    Exit Sub
            'End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "BUTTON EVENTS"
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If (Page.IsValid) Then
            If (finalvalidations()) Then
                ScriptManager.RegisterClientScriptBlock(pnlMain, pnlMain.GetType(), Guid.NewGuid().ToString(), "savecnfirmation();", True)
            End If
        End If
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        IndirectBooking()
        ' txtdate.Text = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        ClearAll()

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearAll()
        Dim dt As Date = clsGeneral.getdate().ToShortDateString()
        txtdate.Text = Format(clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")), "dd/MM/yyyy")
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("Default.aspx")
    End Sub
#End Region

#Region "FUNCTIONS"


    Public Sub loadErrorMsg()
        arrobjMsgMst = New List(Of clsMsgMst)
        arrobjMsgMst = clsGeneral.GetmsgmstList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
        If arrobjMsgMst IsNot Nothing Then
            Session("ErrorMsg") = arrobjMsgMst
        End If
        arrobjMsgMst = Nothing
    End Sub

    Public Function IndirectBooking() As Boolean
        IndirectBooking = False
        Try
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Dim msg As String

            If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
                Exit Function
            End If

            If txtpatid.Text = "" Then
                'clsGeneral.ShowErrorPopUp("Enter Patient Number Information", txtpatid.Text, Page)
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 10), "txtpatid", Page)    'Aarti 30 Sep 2016
                Exit Function
            ElseIf txtdctid.Text = "" Then
                'clsGeneral.ShowErrorPopUp("Enter Doctor Number", txtdctid.Text, Page)
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 2), "txtpatid", Page)     'Aarti 30 Sep 2016
                Exit Function
            Else

                Dim save As New ClsOtIndirectBooking

                save.DocCd = txtdctid.Text
                'save.ExpectedDate = CDate(txtdate.Text).ToShortDateString
                save.ExpectedDate = CDate(txtdate.Text)
                save.PtnNo = txtpatid.Text
                save.Status = 1
                If Request("TrnNo") = "" Then
                    save.TrnNo = 0
                Else
                    save.TrnNo = Request("TrnNo")
                End If


                save.UserDtTm = clsGeneral.getdate
                save.UserId = Session("USERID")
                Dim dtserverdttm As Date = clsGeneral.getdate()  'Nutan 12 Jan 2022
                save.FLG = "A"  'Nutan 12 Jan 2022
                save.IsOfficePrmsnGiven = chkIsOffPerm.Checked   'Nutan 12 Jan 2022
                save.OfficePrmsnRmrk = txtoffPermRmrk.Text   'Nutan 12 Jan 2022
                Session("OffRemark") = txtoffPermRmrk.Text
                save.OfficePrmsnByUsrID = Session("USERID")  'Nutan 12 Jan 2022
                save.OfficePrmsnDtTm = dtserverdttm  'Nutan 12 Jan 2022
                Dim IndirectBookingchk As Boolean
                IndirectBookingchk = OTScheduling.SaveIndirectBooking(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), save)
                If (IndirectBookingchk) Then

                    If Request("TrnNo") = "" Then
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 6), "txtpatid", Page)   'Aarti 30 Sep 2016
                    Else
                        '  msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 12), "txtpatid", Page)
                        'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "Alert('" + msg + "');Window.location='~/Pages/AllOTRequest.aspx';", True)
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 12), "btnExit", Page)   'Aarti 02 Oct 201
                        'Response.Redirect("~/Pages/AllOTRequest.aspx")
                    End If


                    ClearAll()
                    Dim dt As Date = clsGeneral.getdate().ToShortDateString()
                    txtdate.Text = Format(clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")), "dd/MM/yyyy")
                    Return True

                Else
                    If strErrMsg IsNot Nothing Then
                        If strErrMsg.Count > 0 Then
                            clsGeneral.ShowErrorPopUp(strErrMsg(0), "txtapptno", Page)
                        Else
                            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 39), "txtapptno", Page)
                        End If
                    Else
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 39), "txtapptno", Page)
                    End If

                    Return False
                End If
            End If

        Catch ex As Exception
            ' IndirectBooking = False
            Return False
        End Try
        'Return IndirectBooking
    End Function

    Public Sub ClearAll()
        grdOtList.DataSource = Nothing ''Amol 07-11-2020 JSK001-147271	
        grdOtList.DataBind()
        txtdctid.Text = ""
        txtdctname.Text = ""
        txtpatid.Text = ""
        txtpatname.Text = ""
        txtdate.Text = ""
        txtreqno.Value = ""
        txtflag.Value = ""
        txtdate.Text = Format(clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")), "dd/MM/yyyy")
        chkIsOffPerm.Checked = False
        txtoffPermRmrk.Text = ""
    End Sub

    Public Function finalvalidations() As Boolean
        finalvalidations = False
        Dim RevDt As Date
        RevDt = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
        If (txtdctid.Text) = "" Then
            'clsGeneral.ShowErrorPopUp("please enter doctor code", "txtdctid", Page)
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 2), "", Page)  'Aarti 20163019
            Return False
        ElseIf (txtdctname.Text = "") Then
            'clsGeneral.ShowErrorPopUp("please enter doctor name", "txtdctname", Page)

            Return False
        ElseIf (txtpatid.Text = "") Then
            'clsGeneral.ShowErrorPopUp("please enter patient id", "txtpatid", Page)
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)  'Aarti 20163019
            Return False
        ElseIf (txtpatname.Text = "") Then
            'clsGeneral.ShowErrorPopUp("please enter patient name", "txtpatname", Page)
            'clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 2), "", Page)  'Aarti 20163019
            Return False
        ElseIf txtdate.Text = "" Then 'RasikV 20170125
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtdate", Page)
            txtdate.Text = Format(RevDt, "dd/MM/yyyy")
            Return False
        ElseIf IsDate(txtdate.Text) = False Then 'RasikV 20170125
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtdate", Page)
            txtdate.Text = Format(RevDt, "dd/MM/yyyy")
            txtdate.Focus()
            Return False

        ElseIf Convert.ToDateTime(txtdate.Text) < RevDt Then 'RasikV 20170131
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 41), "txtdate", Page)
            txtdate.Text = Format(RevDt, "dd/MM/yyyy")
            Return False
        End If
        Dim objArr = New List(Of ClsOtIndirectBookingLst)()

        objArr = OTScheduling.GetOtIndirectBookingLst002(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"),
                                                          Session("LOCCODE"), Convert.ToInt64(txtpatid.Text), Convert.ToInt32(txtdctid.Text), Convert.ToDateTime(txtdate.Text))
        If (objArr IsNot Nothing) Then
            If (objArr.Count > 1) Then
                clsGeneral.ShowErrorPopUp("Already Requested for this Ip no for " + txtdctid.Text + " Doctor!", "", Page)
                Return False
            End If
        End If


        Return True
    End Function

    Sub FnRights()
        Dim UserRights As String
        UserRights = clsGeneral.UserRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
        If UserRights <> "" Then
            Dim objSessVar As New SessionVariables
            objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btnsave, SessionVariables.EnumFunctionRights.Save, UserRights)
            'objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btnnewbkng, SessionVariables.EnumFunctionRights.Save, UserRights)
            'objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btnCancel, SessionVariables.EnumFunctionRights.Print, UserRights)
            objSessVar = Nothing

            Dim strArray() As String = Split(UserRights, ";")
            hfaccess.Value = strArray(0)
            hfsave.Value = strArray(1)
            hfdelete.Value = strArray(2)
            hfprint.Value = strArray(3)
            hfauth.Value = strArray(4)
        Else
            'btnexit_Click("", EventArgs.Empty)
        End If
    End Sub

    Public Function DischrgFolioPtnRuleInfo9233() As Boolean            'Aarti 10 Oct 2020
        Dim obj = New clsRuleMaster()
        obj = OTScheduling.GetRuleMstDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 9233)
        If (obj IsNot Nothing) Then
            If (obj.Data1 = "Y") Then
                DischrgFolioPtnRuleInfo9233 = True
            Else
                DischrgFolioPtnRuleInfo9233 = False
            End If
        End If
        obj = Nothing
    End Function
#End Region

#Region "COMMENTS"
    '<System.Web.Services.WebMethod()> _
    'Public Shared Function GetPatName(ByVal patno As String) As String
    '    Dim strErrMsg As New List(Of String)
    '    Dim chrErrFlg As Char
    '    GetPatName = ""
    '    If (patno <> "") Then
    '        '    GetPatName = OTScheduling.GetPatientFullName(strErrMsg, chrErrFlg, "001", 1, 1, patno)
    '        '
    '        ' Dim objpatient As New CommonMstServiceReference.clsInPatient
    '        GetPatName = OTScheduling.GetPatientFullName(strErrMsg, chrErrFlg, 1, 1, 1, patno)
    '        'If GetPatName IsNot Nothing Then
    '        '    If chrErrFlg = "Y" Then
    '        '    Else
    '        '        GetPatName = GetPatName.PatientFullName
    '        '    End If
    '        'End If
    '    End If
    '    Return GetPatName
    'End Function
    '<System.Web.Services.WebMethod()> _
    'Public Shared Function GetDoctName(ByVal doctno As String) As String
    '    Dim strErrMsg As New List(Of String)
    '    GetDoctName = ""
    '    Dim chrErrFlg As Char
    '    If (doctno <> "") Then
    '        GetDoctName = OTScheduling.GetDoctorName(strErrMsg, chrErrFlg, "1", 1, 1, doctno)
    '    End If
    '    Return GetDoctName
    'End Function
#End Region

End Class