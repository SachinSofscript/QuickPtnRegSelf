
Imports System
Imports System.Data
Imports Data
Imports DayPilot.Utils
Imports DayPilot.Web.Ui.Events
Imports DayPilot.Web.Ui.Events.Scheduler
Imports OTScheduling.CmnSecurityFunSrvRef
Imports OTScheduling.OTSchedulingSerRef

Public Class OtDashboardSch
    Inherits System.Web.UI.Page

    Dim row As GridViewRow
    'Dim objclsFCTMST As List(Of clsFCTMST)
    Dim objclsFCTMST As List(Of clsFCTMstHelp)
    Dim lbl As Label
    Dim val1 As String
    Dim val2 As String
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Dim Revdate As Date
    Dim arrobjMsgMst As List(Of clsMsgMst)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            clsGeneral.CheckSession(Me.Context, Session("USERID"))
            clsGeneral.SetDefaultSessionValue(HfAppMdCd, HfAppSubMdCd, Session("MAINMODCODE"), Session("MAINSUBMODCODE"))

            Revdate = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")).ToString("dd/MM/yyyy")
            If Not IsPostBack Then
                Call loadErrorMsg()
                txtFrmDate.Text = Format(Revdate, "dd/MM/yyyy")
                LoadResources()
                LoadData()


            End If
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

    Protected Sub DayPilotCalendar1_Command(ByVal sender As Object, ByVal e As CommandEventArgs)

    End Sub

    Protected Sub DayPilotCalendar1_EventMenuClick(ByVal sender As Object, ByVal e As EventMenuClickEventArgs)

    End Sub

    Private Sub LoadData()
        Try


            Dim obj As List(Of clsFCTAPTOT)
            obj = OTScheduling.GetOTDataForDashBrdSch(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(txtFrmDate.Text).ToString("dd/MM/yyyy"), CDate(txtFrmDate.Text).ToString("dd/MM/yyyy"), "1", 1, "", 0, 0, 1)

            If obj IsNot Nothing Then
                If strErrMsg IsNot Nothing Then
                    If strErrMsg.Count > 0 Then
                        For Each ob In strErrMsg
                            '  string a = ob.Substring(0, 50);
                            clsGeneral.ShowErrorPopUp(ob.ToString(), "", Page)
                        Next ob
                    End If
                End If



                If obj.Count > 0 Then


                    DayPilotScheduler1.StartDate = CDate(txtFrmDate.Text).ToString("dd/MM/yyyy")

                    ViewState("LoadData") = obj
                    DayPilotScheduler1.DataSource = obj
                    DayPilotScheduler1.DataBind()

                    DayPilotScheduler1.SetScrollX(CDate(txtFrmDate.Text).ToString("dd/MM/yyyy"))
                End If

            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try

    End Sub

    Private Sub LoadExistingData()
        Try
            If ViewState("LoadData") IsNot Nothing Then
                Dim objList As List(Of clsFCTAPTOT)
                objList = ViewState("LoadData")
                DayPilotScheduler1.DataSource = objList
                DayPilotScheduler1.DataBind()

                DayPilotScheduler1.SetScrollX(CDate(txtFrmDate.Text).ToString("dd/MM/yyyy"))
            End If



        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub

    Private Sub LoadResources()
        Try
            Dim locations As New DataTable
            clsGeneral.CheckSession(Me.Context, Session("USERID"))
            strErrMsg = New List(Of String)
            chrErrFlg = "N"


            objclsFCTMST = OTScheduling.GetFCTMstLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1)

            DayPilotScheduler1.Resources.Clear()
            If objclsFCTMST IsNot Nothing Then
                For Each obj As clsFCTMstHelp In objclsFCTMST
                    DayPilotScheduler1.Resources.Add(DirectCast(obj.Decode, String), Convert.ToString(obj.Code))
                Next
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try
    End Sub

    Protected Sub txtFrmDate_TextChanged(sender As Object, e As EventArgs)

        Dim dt As Date
        If Date.TryParse(txtFrmDate.Text, dt) = False Then

            clsGeneral.ShowErrorPopUp("Enter Valid Date", "txtFrmDate", Page)
            txtFrmDate.Text = Revdate.ToString("dd/MM/yyyy")
            Return
        End If
        LoadData()
    End Sub

    Protected Sub DayPilotScheduler1_BeforeEventRender(ByVal sender As Object, ByVal e As BeforeEventRenderEventArgs)


    End Sub

    Protected Sub DayPilotScheduler1_Command(sender As Object, e As CommandEventArgs)

    End Sub

    Protected Sub DayPilotScheduler1_EventMove(sender As Object, e As EventMoveEventArgs)

    End Sub

    Protected Sub DayPilotScheduler1_EventResize(sender As Object, e As EventResizeEventArgs)

    End Sub

    Protected Sub DayPilotScheduler1_EventMenuClick(sender As Object, e As EventMenuClickEventArgs)

        Try
            Select Case e.Command
                Case "Delete"
                    Dim id_Renamed As Integer = Convert.ToInt32(e.Id)
                    btnAppCancel_Click(btnAppCancel, EventArgs.Empty)
            End Select
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message.Replace("'", ""), "", Page)
        End Try

    End Sub

    Protected Sub DayPilotScheduler1_BeforeEventRender1(sender As Object, e As BeforeEventRenderEventArgs)
        e.InnerHTML = "Appt No. : " & e.DataItem("APPTNO") & " From Time : " & Convert.ToDateTime(e.DataItem("Frmtm")).ToString("hh:mm tt") & " TO " & Convert.ToDateTime(e.DataItem("ToTm")).ToString("hh:mm tt") & "<br/>" & e.DataItem("PTNLNGNM") & "<br/>" & e.DataItem("SurgeonName")

        e.ToolTip = "Appt No. : " & e.DataItem("APPTNO") & " From Time : " & Convert.ToDateTime(e.DataItem("Frmtm")).ToString("hh:mm tt") & " TO " & Convert.ToDateTime(e.DataItem("ToTm")).ToString("hh:mm tt") & Environment.NewLine & e.DataItem("PTNLNGNM") & Environment.NewLine & e.DataItem("SurgeonName")
    End Sub

    Protected Sub lnkPrev_Click(sender As Object, e As EventArgs)
        txtFrmDate.Text = Convert.ToDateTime(txtFrmDate.Text).AddDays(-1)
        LoadData()
    End Sub

    Protected Sub lnkNext_Click(sender As Object, e As EventArgs)
        txtFrmDate.Text = Convert.ToDateTime(txtFrmDate.Text).AddDays(1)
        LoadData()
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)

        Response.Redirect("~/Pages/Default.aspx")
    End Sub

    Protected Sub btnAppCancel_Click(sender As Object, e As EventArgs) Handles btnAppCancel.Click
        Try

            lblApptNo.Text = " Appointment No : " + hdnDeleteValue.Value.ToString
            ShowHideCovertOpToIp(True)
            LoadData()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
    Private Sub ShowHideCovertOpToIp(IsShow As Boolean) ''Amol 10-11-2020 JSK001-147270 
        If IsShow = True Then
            'hdnDeleteValue.Value
            divPopupCovertOpToIp.Visible = True
            divOverlayPopupCovertOpToIp.Style("display") = "block"
            UpPopupCovertOpToIp.Update()
        ElseIf IsShow = False Then
            divPopupCovertOpToIp.Visible = False
            divOverlayPopupCovertOpToIp.Style("display") = "none"
            UpPopupCovertOpToIp.Update()
        End If
    End Sub

    Protected Sub btnClosePopup_Click(sender As Object, e As EventArgs) Handles btnclosePopUp.Click
        Try
            ShowHideCovertOpToIp(False)
            LoadData()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
    Protected Sub btncnclBkng_Click(sender As Object, e As EventArgs)


        If txtCnclRmrk.Text = "" Then
            lblErrMsg.Text = "Enter Cancel Remark"
            txtCnclRmrk.Text = ""
            UpPopupCovertOpToIp.Update()
            LoadExistingData()
            Exit Sub
        End If
        btnFnlCanclBkg_Click(sender, e)
    End Sub

    Protected Sub btnFnlCanclBkg_Click(sender As Object, e As EventArgs)
        Dim id_Renamed As Integer = hdnDeleteValue.Value
        Dim dtserverdttm As Date = clsGeneral.getdate()
        If ViewState("LoadData") IsNot Nothing Then

            Dim objList As List(Of clsFCTAPTOT)
            objList = ViewState("LoadData")
            Dim objSelect As clsFCTAPTOT = (From O1 In objList Where O1.APPTNO = id_Renamed Select O1).FirstOrDefault
            If objSelect IsNot Nothing Then
                Dim objclsfctaptcncl As New clsFCTAPTCNCL
                objclsfctaptcncl.FCTCODE = Integer.Parse(objSelect.FCTCODE)
                objclsfctaptcncl.APPTNO = Integer.Parse(objSelect.APPTNO)
                objclsfctaptcncl.ISSHIFTED = False
                objclsfctaptcncl.CNCLUSRID = Session("userid")
                objclsfctaptcncl.CNCLDTTM = dtserverdttm
                objclsfctaptcncl.APPTRMRK = objSelect.APPTRMRK
                objclsfctaptcncl.CNCL_RMRK = txtCnclRmrk.Text 'rasikv 20210601

                Dim objFCTAPTOT As New clsFCTAPTOT
                objFCTAPTOT.FCTCODE = Integer.Parse(objSelect.FCTCODE)
                objFCTAPTOT.APPTNO = Integer.Parse(objSelect.APPTNO)

                Dim objFCT_APT_MAIN As New clsFCTAPTMAIN
                objFCT_APT_MAIN.FCTCODE = Integer.Parse(objSelect.FCTCODE)
                objFCT_APT_MAIN.FctCatCode = 1
                objFCT_APT_MAIN.FctMainCode = 1
                objFCT_APT_MAIN.UPDUSRID = Session("USERID")
                objFCT_APT_MAIN.UPDTTTM = dtserverdttm
                objFCT_APT_MAIN.IPOP = objSelect.IPOP
                objFCT_APT_MAIN.APPTNO = Integer.Parse(objSelect.APPTNO)

                Dim objFCTSCH As New clsFCTSCH
                objFCTSCH.FCTCODE = Integer.Parse(objSelect.FCTCODE)
                objFCTSCH.FctCatCode = 1
                objFCTSCH.FctMainCode = 1
                objFCTSCH.SCHDATE = CDate(txtFrmDate.Text)
                objFCTSCH.APPTNO = Integer.Parse(objSelect.APPTNO)

                If (OTScheduling.CNCLRECORD(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(objSelect.FCTCODE), Integer.Parse(objSelect.APPTNO), objFCTAPTOT, objFCT_APT_MAIN, objFCTSCH, objclsfctaptcncl)) Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 37), "txtapptno", Page)
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
                End If
            End If
        End If
        txtCnclRmrk.Text = ""
        ShowHideCovertOpToIp(False)
        LoadData()
    End Sub


End Class