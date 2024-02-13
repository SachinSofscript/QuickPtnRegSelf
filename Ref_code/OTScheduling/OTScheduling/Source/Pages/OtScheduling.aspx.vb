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
Imports Microsoft.Reporting.WebForms
#End Region

Partial Class Pages_OtScheduling
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLRATIONS"
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Shared lv_fct_slot_prd_hrs As Integer
    Shared lv_fct_slot_prd_mins As Integer
    Shared lvSessDur As Long
    Shared lvSlotDur As Long
    Dim SessionStartTIme As Date
    Dim SessionEndTIme As Date
    Dim SessionSlotDuration As Integer
    Dim CompleteScale As Boolean
    Public starttime As Date
    Public endtime As Date
    Shared btnarrcnt As Integer = 0
    Shared lblarrcnt As Integer = 0     'Sana :01-Nov-2019
    Dim stdfont As Font = New Font("MS Reference Sans Serif", 10)
    Dim divwt As Integer = 50
    Shared divht As Integer = 30
    Shared sttm As Date = CDate("00:00")
    Shared endtm As Date = CDate("00:00")
    Const sltdur As Integer = 60
    Dim sltcnt As Long = 24
    Dim sessttm As Date
    Dim sessltcnt As Long
    Dim sesdivwt As Integer = 50
    Dim scalewidth As Integer
    Dim leftmargin As Integer
    Public TimeScaleBackcolor As Color
    Public TimeScaleForecolor As Color
    Public BookingAreaBackcolor As Color
    Dim cmpscale As Boolean = False
    Shared sess() As clsSession
    Shared btnarr() As clsTimeSlot
    Shared lblarr() As clsTimeSlotLbl            'Sana :01-Nov-2019
    Shared arrsession() As clsSession
    Shared lvnoofsessions As Integer
    Shared flag As String
    Shared ipopflg As String
    Dim objcalrateData = New OTSchedulingSerRef.clsCalRate
    Public objArrOTSrvDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
    Public objArrOTDoctorsDtls As New List(Of OTSchedulingSerRef.clsOtDocDtls)
    Dim Msg As String = Nothing


    Public Shared IsDirectBookingAloowed As Boolean = True


#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Validate()
        SaveSrvRuleInfo9232()       'Aarti 27 Oct 2020

        strErrMsg = New List(Of String)
        chrErrFlg = "N"

        'IF THE RECORDS R SELECTED FOR OT-DOCTORS THN RELOAD THE DATA 
        If Session("objArrOTDoctorsDtls") IsNot Nothing Then
            txtot.Text = Session("OTSelected")
            txtdate.Text = Session("OTDateSelected")
            txtstrttime.Text = Session("OTStartTmSelected")
            txtendtime.Text = Session("OTEndTmSelected")

            'Getsessions()

            'txtdctid.Text = Session("OTDocIdSelected")
            'txtdctname.Text = Session("OTDocNameSelected")
            'txtpatid.Text = Session("OTPatIdSelected")
            'txtpatname.Text = Session("OTPatNameSelected")
            'txthrs.Text = Session("OTHrsSelected")
            'txtmins.Text = Session("OTMinsSelected")
            'txtstrttm1.Text = Session("OTStrtTme1Selected")
            'txtapptno.Text = Session("OTApptNoSelected")
            txtslots.Text = Session("OTSlotsSelected")
            'txtRmrk.Text = Session("OTRemarksSelected")
            clsGeneral.ShowConsoleTrack("IN PAGE LOAD &  If Session(objArrOTDoctorsDtls) IsNot Nothing Then", "", Page)



            If Session("TxtFlag") <> "" Then
                txtflag.Value = Session("TxtFlag")
            End If


            '' Added by Amol 2019-12-18
            Try
                lblRequestNo.Visible = True
                lblHeaderReqNo.Visible = True
                lblOtAppxDate.Visible = True
                lblHeaderDate.Visible = True

                lblRequestNo.Text = Session("OTApptNoSelected").ToString()
                lblOtAppxDate.Text = Session("OTDateSelected").ToString()

            Catch ex As Exception
                lblRequestNo.Visible = False
                lblHeaderReqNo.Visible = False
                lblOtAppxDate.Visible = False
                lblHeaderDate.Visible = False


            End Try
            '' Added by Amol 2019-12-18

            Exit Sub
        Else
            If Not IsPostBack And Session("OTSelected") IsNot Nothing And Session("OTDateSelected") IsNot Nothing And Session("OTStartTmSelected") IsNot Nothing And Session("OTEndTmSelected") IsNot Nothing Then
                txtot.Text = Session("OTSelected")
                txtdate.Text = Session("OTDateSelected")
                txtstrttime.Text = Session("OTStartTmSelected")
                txtendtime.Text = Session("OTEndTmSelected")

                Getsessions()

                txtdctid.Text = Session("OTDocIdSelected")
                txtdctname.Text = Session("OTDocNameSelected")
                txtpatid.Text = Session("OTPatIdSelected")
                txtpatname.Text = Session("OTPatNameSelected")
                txthrs.Text = Session("OTHrsSelected")
                txtmins.Text = Session("OTMinsSelected")
                txtstrttm1.Text = Session("OTStrtTme1Selected")
                txtapptno.Text = Session("OTApptNoSelected")
                txtslots.Text = Session("OTSlotsSelected")
                'txtRmrk.Text = Session("OTRemarksSelected")
                'txtCnclRmrk.Text = Session("OTCancelRemarksSelected")

                clsGeneral.ShowConsoleTrack("IN PAGE LOAD &   If Not IsPostBack ", "", Page)

                If Session("TxtFlag") <> "" Then
                    txtflag.Value = Session("TxtFlag")
                End If

                '' Added by Amol 2019-12-18
                Try
                    lblRequestNo.Visible = True
                    lblHeaderReqNo.Visible = True
                    lblOtAppxDate.Visible = True
                    lblHeaderDate.Visible = True

                    lblRequestNo.Text = Session("OTApptNoSelected").ToString()
                    lblOtAppxDate.Text = Session("OTDateSelected").ToString()
                Catch ex As Exception
                    lblRequestNo.Visible = False
                    lblHeaderReqNo.Visible = False
                    lblOtAppxDate.Visible = False
                    lblHeaderDate.Visible = False
                End Try
                '' Added by Amol 2019-12-18

                Exit Sub

            End If
        End If
        If Session("TxtFlag") <> "" Then
            txtflag.Value = Session("TxtFlag")
        End If

        'Session("TxtFlag") = txtflag.Value

        btnnewbkng.Enabled = True

        If Not IsPostBack Then

            'txtot_TextChanged
            'If Request.QueryString("otid") = "" And Request.QueryString("patid") = "" And Request.QueryString("docid") = "" Then

            If Request.QueryString("otno") = "" And Request.QueryString("patid") = "" And Request.QueryString("docid") = "" Then
                FnRights()  'APARNA 28 mar 2016
                strErrMsg = New List(Of String)
                chrErrFlg = "N"
                clsGeneral.CheckSession(Me.Context, Session("USERID"))
                clsGeneral.SetDefaultSessionValue(HfAppMdCd, HfAppSubMdCd, Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
                If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
                    Exit Sub
                End If
                txthrs.Text = "00"
                txtmins.Text = "00"
                txtdate.Text = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
                txtot.Focus()
                rdoip.Enabled = False
                rdoop.Enabled = False
                Session("img123") = Nothing
                pnlMainFrm.Enabled = True 'anamika 20161003
                btnsave.Enabled = True 'anamika 20161003

                txtpatid.Text = Request("patid")
                txtpatname.Text = Request("patname")

                'imageSearchDoc.Enabled = False   uncomment it

                txtdctid.Text = Request("docid")
                txtdctname.Text = Request("docname")
                ' txtapptno.Text = Request("TrnNo")     'Aarti 29 aug 2020
                Session("IpNoChnged") = txtpatid.Text
                Session("ActualPtnNo") = Request("PtnActualPtnNo")
                'btncncl.Enabled = False
                ButtonEnabled(False, False, False, False, False)  'RasikV 20170125
                rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
                CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

                Pnl2Enabled(False)  'RasikV 20170125
                Pnl1Enabled(False)  'RasikV 20170206


                '' Added by Amol 2019-12-18
                Try
                    lblRequestNo.Visible = True
                    lblHeaderReqNo.Visible = True
                    lblOtAppxDate.Visible = True
                    lblHeaderDate.Visible = True

                    lblRequestNo.Text = Request("TrnNo").ToString()
                    lblOtAppxDate.Text = Request("expdate").ToString()

                Catch ex As Exception
                    lblRequestNo.Visible = False
                    lblHeaderReqNo.Visible = False
                    lblOtAppxDate.Visible = False
                    lblHeaderDate.Visible = False


                End Try
                '' Added by Amol 2019-12-18

            Else
                FnRights()  'anamika 20161003
                Session("EditMode") = "true" 'anamika 20161003
                txtot.Enabled = False
                ImageButton2.Enabled = False
                txtot.Text = Request("otno")
                txtdate.Text = Request("expdate")
                Pnl1Enabled(False)  'RasikV 20170206
                txtot_TextChanged(sender, e)

                ' UP2.Update()
                Imgsearchptn.Enabled = False
                txtpatid.Enabled = False
                txtpatid.Text = Request("patid")
                txtpatname.Text = Request("patname")
                Session("IpNoChnged") = txtpatid.Text
                imageSearchDoc.Enabled = False
                txtdctid.Enabled = False
                txtdctid.Text = Request("docid")
                txtdctname.Text = Request("docname")

                txthrs.Enabled = True
                txthrs.Text = "00"
                txtmins.Enabled = True
                txtmins.Text = "00"
                txtstrttm1.Enabled = True

                'txtapptno.Text = Request("TrnNo")       'Aarti 29 Aug 2020
                Session("ActualPtnNo") = Request("PtnActualPtnNo")
                btncncl.Enabled = False 'anamika 20161003
                chkIsOffPerm.Checked = Request("op")  'Nutan 12-Jan-2022
                txtoffPermRmrk.Text = Request("opremark")   'Nutan 12-Jan-2022
                'UP3.Update()

                ButtonEnabled(False, False, False, False, False)  'RasikV 20170125
                btnnewbkng.CssClass = "divskyblue" 'anamika 20161003

                '' Added by Amol 2019-12-18
                Try
                    lblRequestNo.Visible = True
                    lblHeaderReqNo.Visible = True
                    lblOtAppxDate.Visible = True
                    lblHeaderDate.Visible = True

                    lblRequestNo.Text = Request("TrnNo").ToString()
                    lblOtAppxDate.Text = Request("expdate").ToString()

                Catch ex As Exception
                    lblRequestNo.Visible = False
                    lblHeaderReqNo.Visible = False
                    lblOtAppxDate.Visible = False
                    lblHeaderDate.Visible = False

                End Try
                '' Added by Amol 2019-12-18

            End If
            SaveSrvRuleInfo9232()
            CheckPtnType() '' Amol 2020-11-07 JSK001-147262	
            ChkRule9370() 'Trupti 14 JUN 2021
            FnUserWsModFnRights() 'Trupti 14 JUN 2021

            Dim objCdDcd As List(Of OTSchedulingSerRef.clsCodeDecode)
            objCdDcd = OTScheduling.GetCodeDeCodeList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), OTSchedulingSerRef.EnumCodeDecode.BookingType)

            If objCdDcd IsNot Nothing Then
                clsGeneral.FillDropDownList(drpBookingType, "Decode", "Code", objCdDcd, 1, "SELECT")
                If objCdDcd IsNot Nothing Then
                    For i As Integer = 0 To objCdDcd.Count - 1
                        If objCdDcd(i).addinfo1 = "1" Then
                            drpBookingType.SelectedValue = objCdDcd(i).Code
                        End If
                    Next
                End If
            End If

            'as per system parameter whether direct booking is allowed or not. changes are done for vpmh hospital
            'since client want to do booking only againsts requests
            CheckDirectBookingAllowed()

        End If



        DispalyOffIcePermission() 'Trupti 14 JUN 2021
    End Sub
#End Region

#Region "TEXTBOX EVENTS"
    Protected Sub txtot_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtot.TextChanged
        Try
            If (txtot.Text <> "" And txtdate.Text <> "") Then

                ' ClearAll()   CHK AFTRWDS
                'Getsessions()

                UP1.Update() 'RasikV 20170125
                If Session("EditMode") <> "true" Then
                    Pnl1Enabled(True)  'RasikV 20170206
                End If

                strErrMsg = New List(Of String)
                chrErrFlg = "N"
                Dim OTName As String

                If txtot.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)
                    txtot.Text = ""
                    Clr() 'RasikV 20170206
                    Exit Sub
                End If

                OTName = OTScheduling.GetOtName(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtot.Text))

                If OTName = "" And OTName = Nothing Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 11), "txtot", Page)
                    txtot.Text = ""
                    txtotname.Text = ""
                    Clr() 'RasikV 20170206
                Else
                    txtotname.Text = OTName.ToUpper()
                    If (Getsessions() = True) Then
                        UP3.Update()
                        ButtonEnabled(True, False, False, False, False)
                    End If
                    txtdate.Focus()
                End If
            Else
                Clr() 'RasikV 20170206
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Protected Sub txtpatid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpatid.TextChanged
        Try
            'Dim obj As New clsFCTAPTOT
            'obj.PTNNO = Long.Parse(txtpatid.Text)
            'obj.PTNLNGNM = txtpatname.Text
            'Session("IpNoChnged") = Long.Parse(txtpatid.Text)

            If (divPopupNewPtnReg.Visible = True) Then      'Aarti 20 Jan 2021
                divPopupNewPtnReg.Visible = False
                divOverlayPopupNewPtnReg.Visible = False
                UpdNewPtnReg.Update()
            End If


            If (txtot.Text <> "" And txtdate.Text <> "") Then
                UP2.Update()

                Pnl2Enabled(True)
                strErrMsg = New List(Of String)
                chrErrFlg = "N"
                Dim objIpPatientVisit As New clsIpPatientVisit

                If txtot.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)
                    txtot.Text = ""
                    txtpatid.Text = ""
                    txtpatname.Text = ""
                    Exit Sub
                End If

                If txtpatid.Text = "" And txtpatname.Text = Nothing Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 3), "txtpatid", Page)
                    txtpatid.Text = ""
                    txtpatname.Text = ""
                    Exit Sub
                End If


                If hfPtnType.Value <> "" Then  '''' Amol 2020-11-07 JSK001-147262	
                    rdbPatientType.SelectedValue = hfPtnType.Value
                End If

                If hfOffPermDtl.Value <> "" Then 'Trupti 15 JUN 2021
                    txtoffPermRmrk.ToolTip = hfOffPermDtl.Value
                End If

                Dim objPatientVisit As New PatientDetails
                If txtpatid.Text <> "0" Then '''' Amol 2020-11-07 JSK001-147262	
                    If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                        objPatientVisit = PatientHelp.GetPatientDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtpatid.Text))

                        If objPatientVisit Is Nothing Then '''' Amol 2020-11-07 JSK001-147262	
                            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 35), "txtOpPtnCd", Page)
                            txtpatid.Text = ""
                            txtpatname.Text = ""
                            txtpatid.Focus()
                        Else
                            txtpatname.Text = objPatientVisit.PatientFullName.ToUpper()
                            Dim obj As New clsFCTAPTOT
                            obj.PTNNO = Long.Parse(txtpatid.Text)
                            obj.PTNLNGNM = txtpatname.Text
                            Session("IpNoChnged") = Long.Parse(txtpatid.Text)
                            txthrs.Focus()
                        End If
                        '''' Amol 2020-11-07 JSK001-147262	


                    Else
                        objIpPatientVisit = OTScheduling.GetInpatientDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtpatid.Text))


                        If objIpPatientVisit Is Nothing Then
                            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 35), "txtpatid", Page)
                            txtpatid.Text = ""
                            txtpatname.Text = ""
                            txtpatid.Focus()
                        Else
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

                            txtpatname.Text = objIpPatientVisit.ptnname.ToUpper()
                            Dim obj As New clsFCTAPTOT
                            obj.PTNNO = Long.Parse(txtpatid.Text)
                            obj.PTNLNGNM = txtpatname.Text
                            Session("IpNoChnged") = Long.Parse(txtpatid.Text)
                            txthrs.Focus()
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub txtdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdate.TextChanged
        Try

            'If (CDate(txtdate.Text) < Date.Today) Then
            '    txtdate.Text = Date.Today
            'Else
            'End If
            '' btnnewbkng.Enabled = True
            'txtflag.Value = ""
            'getsessions()

            Dim DtRev As Date = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))

            UP1.Update() 'RasikV 20170125
            If txtdate.Text = "" Then 'RasikV 20170125
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtdate", Page)
                txtdate.Text = Format(DtRev, "dd/MM/yyyy")
                Exit Sub
            End If

            If IsDate(txtdate.Text) = False Then 'RasikV 20170125
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtdate", Page)
                txtdate.Text = Format(DtRev, "dd/MM/yyyy")
                Exit Sub
            End If

            If Request("TrnNo") = "" Then

                'If (CDate(txtdate.Text) < Date.Today) Then
                '    txtdate.Text = Date.Today
                'End If
                ' btnnewbkng.Enabled = True
                'txtflag.Value = ""
                'Getsessions()

                txtflag.Value = ""
                If (CDate(txtdate.Text) < DtRev) Then 'RasikV 20170206
                    txtdate.Text = Format(DtRev, "dd/MM/yyyy")
                End If

                If (Getsessions() = True) Then 'RasikV 20170206
                    UP3.Update()
                    ButtonEnabled(True, False, False, False, False)
                Else
                    UP2.Update()
                    rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
                    CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	
                    Pnl2Enabled(False)
                End If

            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub txtdctid_TextChanged(sender As Object, e As EventArgs) Handles txtdctid.TextChanged
        Try 'RasikV 20170125
            UP2.Update()
            Pnl2Enabled(True)
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Dim DocName As String

            If txtot.Text = "" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)
                txtot.Text = ""
                txtdctid.Text = ""
                txtdctname.Text = ""
                Exit Sub
            End If

            If txtdctid.Text = "" And txtdctname.Text = Nothing Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 4), "txtdctid", Page)
                txtdctid.Text = ""
                txtdctname.Text = ""
                Exit Sub
            End If

            DocName = OTScheduling.GetDoctorName(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtdctid.Text)

            If DocName = "" And DocName Is Nothing Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 35), "txtdctid", Page)
                txtdctid.Text = ""
                txtdctname.Text = ""
            Else
                txtdctname.Text = DocName.ToUpper()
                txtpatid.Focus()
            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub txthrs_TextChanged(sender As Object, e As EventArgs) Handles txthrs.TextChanged 'RasikV 20170128
        Try
            UP2.Update()
            Pnl2Enabled(True)

            If (txthrs.Text = "") Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 32), "txthrs", Page)
                txthrs.Text = ""
                Exit Sub
            End If

            If (Integer.Parse(txthrs.Text) > 24) Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 32), "txthrs", Page)
                txthrs.Text = ""
                Exit Sub
            End If

            If (NoOfSlots() = False) Then
                If Session("EditMode") <> "true" Then
                    '                    btncncl_Click(sender, e)
                    FnRights()   'Pushpa 20180512
                    UP2.Update() 'RasikV 20170125
                    UP3.Update()
                    'If txtflag.Value = "EDIT" Then
                    '    imageSearchDoc.Enabled = True
                    '    txtdctid.Enabled = False
                    'End If
                    'ButtonEnabled(True, False, False, False, False)
                    'Pnl2Enabled(False)
                    'ClearAll()
                Else
                    btncncl.Enabled = False
                End If
            End If

            txtmins.Focus()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub txtmins_TextChanged(sender As Object, e As EventArgs) Handles txtmins.TextChanged 'RasikV 20170128
        Try
            UP2.Update()
            Pnl2Enabled(True)

            If (txtmins.Text = "") Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 33), "txtmins", Page)
                txtmins.Text = ""
                Exit Sub
            End If

            If (Integer.Parse(txtmins.Text) > 59) Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 33), "txtmins", Page)
                txtmins.Text = ""
                Exit Sub
            End If

            If (NoOfSlots() = False) Then
                If Session("EditMode") <> "true" Then
                    btncncl_Click(sender, e)
                Else
                    btncncl.Enabled = False
                End If
            End If

            txtRmrk.Focus()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
#End Region


    Private Sub CheckDirectBookingAllowed()
        IsDirectBookingAloowed = True

        Dim ObjUserModuleFnRights As New List(Of clsUserModuleFunction)

        ObjUserModuleFnRights = OTScheduling.GetModFnDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))

        If ObjUserModuleFnRights IsNot Nothing Then
            If ObjUserModuleFnRights.Count > 0 Then
                For i As Integer = 0 To ObjUserModuleFnRights.Count - 1
                    If ObjUserModuleFnRights(i).FunctionID = 2 And ObjUserModuleFnRights(i).IsActive = True Then
                        btnnewbkng.CssClass = "btnDisabled"

                        IsDirectBookingAloowed = False

                        'clsGeneral.ShowSweetalert("Direct booking is not allowed as per system settings.", "", Page, True, True)

                        'btnnewbkng.CssClass = btnnewbkng.CssClass.Replace("", "btnDisabled")

                    End If
                Next i
            End If
        End If

    End Sub


#Region "BUTTON EVENTS"
    Protected Sub btnnewbkng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnewbkng.Click
        'shivkumar 31/01/2022
        If IsDirectBookingAloowed = False Then
            clsGeneral.ShowSweetalert("Direct booking is not allowed as per system settings.", "", Page, True, True)
            Exit Sub
        End If




        'end shivkumar 31/01/2022



        'ButtonTab(sender)
        hfPtnType.Value = ""
        hfOffPermDtl.Value = ""
        txtflag.Value = ""
        UP2.Update() 'RasikV 20170125
        Pnl2Enabled(True)  'RasikV 20170125

        'txtstrttm1.Text = txtstrttime.Text
        'Dim strtm1 As DateTime = Convert.ToDateTime(txtstrttime.Text)
        'txtstrttm1.Text = Convert.ToDateTime(txtstrttime.Text).ToString("HH:mm:ss")
        'txtstrttm1.Text = Date.Now.ToString("HH:mm:ss")
        ' txtstrttm1.TextMode = TextBoxMode.Time

        Dim strtm1 As DateTime = txtstrttime.Text

        'txtstrttm1.Text = Convert.ToDateTime(txtstrttime.Text).ToString("HH:mm:ss") ''commented by aparna 2 sep 2019

        txtstrttm1.Text = Convert.ToDateTime(txtstrttime.Text).ToString("HH:mm")
        txtapptno.Text = ""
        Session("objArrOTSrvDtls") = Nothing
        Session("objArrOTEmpDtls") = Nothing
        '  txtstrttm1.TextMode = TextBoxMode.Time
        txtdctid.Focus()
    End Sub

    Protected Sub btnmdfybkng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmdfybkng.Click 'RasikV 20170125

        txtflag.Value = "EDIT"
        Session("TxtFlag") = txtflag.Value
        UP2.Update()
        imageSearchDoc.Enabled = False
        txtdctid.Enabled = False
        UP3.Update()
        ButtonEnabled(False, True, False, False, False)
        Pnl2Enabled(True) ''Amol 2019-12-17
        'Session("OTApptNoSelected") = txtapptno.Text


        ipopflg = rdbPatientType.SelectedValue
        'If (Session("OTPatIdSelected") = txtpatid.Text) Then

        'End If
        Dim objDocSvdLst As New List(Of OTSchedulingSerRef.clsOtDocDtls)
        'If Val(txtapptno.Text) <> 0 Then    'if any appnmnt is saved thn only shw the data
        '    objDocSvdLst = OTScheduling.GetLstOfOtDocDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtot.Text, 1, 1, Val(txtapptno.Text), Session("ActualPtnNo"), txtpatid.Text, ipopflg)
        '    If objDocSvdLst IsNot Nothing Then
        '        Session("objArrOTDoctorsDtls") = objDocSvdLst
        '    End If

        'End If


        'shital 20211202 start
        Dim lngPtnNo As Long = 0
        lngPtnNo = OTScheduling.GetPtnNoByIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt64(txtpatid.Text))

        Dim objLstSrvDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
        Dim objLstDocDtls As New List(Of OTSchedulingSerRef.clsOtDocDtls)
        Dim objLstEmpDtls As New List(Of OTSchedulingSerRef.clsFctAptOtEmpDtls)
        If Val(txtapptno.Text <> 0) Then
            objLstSrvDtls = OTScheduling.GetLstOfOtSrvDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"),
                                                           txtot.Text, 1, 1, txtapptno.Text, IIf(rdbPatientType.SelectedValue = "I", IIf(lngPtnNo <> 0, lngPtnNo, 0),
                                                                                                 txtpatid.Text), txtpatid.Text, ipopflg)
            If objLstSrvDtls IsNot Nothing Then


                Session("objArrOTSrvDtls") = objLstSrvDtls

                Session("FctCd") = txtot.Text '1
                Session("FctCatCd") = 1
                Session("FctMainCd") = 1
                Session("ActualPtnNo") = IIf(lngPtnNo <> 0, lngPtnNo, 0)
                Session("OTSelected") = txtot.Text
                Session("OTDateSelected") = txtdate.Text
                Session("OTStartTmSelected") = txtstrttime.Text
                Session("OTEndTmSelected") = txtendtime.Text
                Session("OTDocIdSelected") = txtdctid.Text
                Session("OTDocNameSelected") = txtdctname.Text
                Session("OTPatIdSelected") = txtpatid.Text
                Session("OTPatNameSelected") = txtpatname.Text
                Session("OTHrsSelected") = txthrs.Text
                Session("OTMinsSelected") = txtmins.Text
                Session("OTStrtTme1Selected") = txtstrttm1.Text
                Session("OTApptNoSelected") = txtapptno.Text
                Session("OTSlotsSelected") = txtslots.Text
                Session("OTRemarksSelected") = txtRmrk.Text
                Session("OTCancelRemarksSelected") = txtCnclRmrk.Text
                Session("OTIPOPFLAG") = rdbPatientType.SelectedValue 'shital 20211202

            End If


            objLstDocDtls = OTScheduling.GetLstOfOtDocDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"),
                                                          txtot.Text, 1, 1, txtapptno.Text, IIf(rdbPatientType.SelectedValue = "I", IIf(lngPtnNo <> 0, lngPtnNo, 0),
                                                                                                 txtpatid.Text),
                                                           txtpatid.Text, ipopflg)
            If objLstDocDtls IsNot Nothing Then
                Session("objArrOTDoctorsDtls") = objLstDocDtls

                Session("FctCd") = Integer.Parse(txtot.Text) '1
                Session("FctCatCd") = 1
                Session("FctMainCd") = 1
                Session("ActualPtnNo") = IIf(rdbPatientType.SelectedValue = "I", IIf(lngPtnNo <> 0, lngPtnNo, 0), txtpatid.Text)
                Session("OTSelected") = txtot.Text
                Session("OTDateSelected") = txtdate.Text
                Session("OTStartTmSelected") = txtstrttime.Text
                Session("OTEndTmSelected") = txtendtime.Text
                Session("OTDocIdSelected") = txtdctid.Text
                Session("OTDocNameSelected") = txtdctname.Text
                Session("OTPatIdSelected") = txtpatid.Text
                Session("OTPatNameSelected") = txtpatname.Text
                Session("OTHrsSelected") = txthrs.Text
                Session("OTMinsSelected") = txtmins.Text
                Session("OTStrtTme1Selected") = txtstrttm1.Text
                Session("OTApptNoSelected") = txtapptno.Text
                Session("OTSlotsSelected") = txtslots.Text
                Session("OTRemarksSelected") = txtRmrk.Text
                Session("OTCancelRemarksSelected") = txtCnclRmrk.Text
                Session("OTIPOPFLAG") = rdbPatientType.SelectedValue
            End If




            objLstEmpDtls = OTScheduling.GetLstOfOtEmpDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"),
                                                            txtot.Text, 1, 1, txtapptno.Text, IIf(rdbPatientType.SelectedValue = "I", IIf(lngPtnNo <> 0, lngPtnNo, 0),
                                                                                                 txtpatid.Text), txtpatid.Text, ipopflg)
            If objLstEmpDtls IsNot Nothing Then
                Session("objArrOTEmpDtls") = objLstEmpDtls



                Session("FctCd") = txtot.Text '1
                Session("FctCatCd") = 1
                Session("FctMainCd") = 1
                Session("ActualPtnNo") = IIf(lngPtnNo <> 0, lngPtnNo, 0)
                Session("OTSelected") = txtot.Text
                Session("OTDateSelected") = txtdate.Text
                Session("OTStartTmSelected") = txtstrttime.Text
                Session("OTEndTmSelected") = txtendtime.Text
                Session("OTDocIdSelected") = txtdctid.Text
                Session("OTDocNameSelected") = txtdctname.Text
                Session("OTPatIdSelected") = txtpatid.Text
                Session("OTPatNameSelected") = txtpatname.Text
                Session("OTHrsSelected") = txthrs.Text
                Session("OTMinsSelected") = txtmins.Text
                Session("OTStrtTme1Selected") = txtstrttm1.Text
                Session("OTApptNoSelected") = txtapptno.Text
                Session("OTSlotsSelected") = txtslots.Text
                Session("OTRemarksSelected") = txtRmrk.Text
                Session("OTCancelRemarksSelected") = txtCnclRmrk.Text
                Session("OTIPOPFLAG") = rdbPatientType.SelectedValue 'shital 20211202
            End If





        End If
        'shital 20210212 end

    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        UP2.Update()
        If (Page.IsValid) Then
            clsGeneral.ShowConsoleTrack("inide the btnsave_Click after If (Page.IsValid) ", "", Page)

            If (finalvalidations()) Then
                Dim StartTime, EndTime As String

                clsGeneral.ShowConsoleTrack("Else OF NOSlot", "", Page)
                If NoOfSlots() = True Then

                    If ViewState("pStartTime") IsNot Nothing And ViewState("pStartTime") IsNot Nothing Then
                        StartTime = IIf(IsDBNull(ViewState("pStartTime")), "", ViewState("pStartTime")) 'RasikV 20170131
                        StartTime = IIf(StartTime.Length = 3, "0" & Left(StartTime, 4), Left(StartTime, 5))
                        EndTime = IIf(IsDBNull(ViewState("pEndTime")), "", ViewState("pEndTime"))
                        EndTime = IIf(EndTime.Length = 3, "0" & Left(EndTime, 4), Left(EndTime, 5))
                    End If

                    clsGeneral.ShowConsoleTrack(ViewState("pStartTime").ToString(), "", Page)
                    clsGeneral.ShowConsoleTrack(ViewState("pEndTime").ToString(), "", Page)

                    Dim Msg As String = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 42), StartTime, EndTime)
                    btnsave.Enabled = False   ' Pushpa 20180512
                    ScriptManager.RegisterClientScriptBlock(UP2, UP2.GetType(), Guid.NewGuid().ToString(), "FinalSave('" + Msg + "');", True)
                Else
                    clsGeneral.ShowConsoleTrack("Else OF NOSlot", "", Page)
                    If (Getsessions() = True) Then
                        If Session("EditMode") <> "true" Then
                            clsGeneral.ShowConsoleTrack("Inside The Edit Mode", "", Page)
                            UP3.Update()
                            ButtonEnabled(True, False, False, False, False)

                            rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
                            CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

                            Pnl2Enabled(False)
                            ClearAll()
                        End If
                    End If
                End If

            Else
                btnarr = Nothing
                btnarrcnt = 0
                ' Getsessions()  ''Commented By Amol 2019-12-18 For Maintain Start Time Textbox value 
            End If
        Else
            btnarr = Nothing
            btnarrcnt = 0
            Getsessions()
        End If
    End Sub

    Protected Sub btnFinalSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalSave.Click 'RasikV 20170128
        Try
            UP2.Update()
            If (Page.IsValid) Then
                clsGeneral.ShowConsoleTrack("Page.IsValid", "", Page)
                btnsave.Enabled = False                ' Pushpa 20180512
                If Session("TxtFlag") <> "" Then
                    txtflag.Value = Session("TxtFlag")
                End If
                If (txtflag.Value = "EDIT") Then
                    clsGeneral.ShowConsoleTrack("EDIT", "", Page)
                    If (CheckSlotAvailable(CDate(txtstrttm1.Text), CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + txtmins.Text))) Then
                        EDITBOOKING()
                        txtflag.Value = ""

                        rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
                        CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

                        Pnl2Enabled(False)
                        UP3.Update()
                        ButtonEnabled(True, False, False, False, False)
                    Else
                        btnarr = Nothing
                        btnarrcnt = 0
                        ClearAll()
                        Getsessions()
                    End If
                Else
                    If (CheckSlotAvailable(CDate(txtstrttm1.Text), CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + txtmins.Text))) Then
                        clsGeneral.ShowConsoleTrack("SAVENEWBOOKING", "", Page)
                        SAVENEWBOOKING()
                        txtflag.Value = ""
                        rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
                        CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

                        Pnl2Enabled(False)
                        UP3.Update()
                        ButtonEnabled(True, False, False, False, False)
                    Else
                        clsGeneral.ShowConsoleTrack("SAVENEWBOOKING ClearAll", "", Page)
                        btnarr = Nothing
                        btnarrcnt = 0
                        ClearAll()
                        Getsessions()
                    End If
                End If
            Else
                btnarr = Nothing
                btnarrcnt = 0
                Getsessions()
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Protected Sub btnRedirect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRedirect.Click 'RasikV 20170128
        Session("EditMode") = Nothing
        Response.Redirect("~/Pages/Default.aspx")
    End Sub

    Protected Sub btnFinalCncl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalCncl.Click 'RasikV 20170128
        FnRights()                              'pushpa 20180512

        If (txtCnclRmrk.Text = "") Then     'Sana : 01-SEP-2019 
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 53), "txtCnclRmrk", Page)
            Exit Sub
        End If

        CANCELBOOKING()
        rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
        CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

        Pnl2Enabled(False)

        btnarr = Nothing
        btnarrcnt = 0
        ClearAll()
        Getsessions()
        UP3.Update()
        ButtonEnabled(True, False, False, False, False)
    End Sub

    Protected Sub btnFinalShift_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalShift.Click 'RasikV 20170128
        ShiftRecord()
        rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
        CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

        Pnl2Enabled(False)
        UP3.Update()
        ButtonEnabled(True, False, False, False, False)
    End Sub

    Protected Sub btnnext_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnext.Click

        'If (txtdate.Text <> "") Then

        If (txtot.Text <> "" And txtdate.Text <> "") Then
            UP1.Update() 'RasikV 20170125
            txtdctid.Text = ""
            txtdctname.Text = ""
            txtpatid.Text = ""
            txtpatname.Text = ""
            txthrs.Text = ""
            txtmins.Text = ""
            txtstrttm1.Text = ""
            txtapptno.Text = ""
            txtslots.Text = ""
            txtflag.Value = ""
            txtRmrk.Text = ""
            txtCnclRmrk.Text = ""
            '#Trupti 14 JUN 2021
            chkIsOffPerm.Checked = False
            txtoffPermRmrk.Text = ""

            drpBookingType.SelectedIndex = 0
            lblchkSts.Text = IIf(chkIsOffPerm.Checked, "Given", "Not Given")
            '#Trupti 14 JUN 2021

            clsGeneral.ShowConsoleTrack("btnnext_Click", "", Page)

            txtdate.Text = CDate(txtdate.Text).AddDays(1)
            If (Getsessions() = True) Then
                UP3.Update()
                ButtonEnabled(True, False, False, False, False)
            Else
                UP2.Update()
                rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
                CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

                Pnl2Enabled(False)
            End If

            'getsessions()
            'btnnewbkng.Enabled = True

        End If
    End Sub

    Protected Sub btnpre_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnpre.Click

        'If (txtdate.Text <> "") Then

        If (txtot.Text <> "" And txtdate.Text <> "") Then
            UP1.Update() 'RasikV 20170125
            txtdctid.Text = ""
            txtdctname.Text = ""
            txtpatid.Text = ""
            txtpatname.Text = ""
            txthrs.Text = ""
            txtmins.Text = ""
            txtstrttm1.Text = ""
            txtapptno.Text = ""
            txtslots.Text = ""
            txtflag.Value = ""
            txtRmrk.Text = ""
            txtCnclRmrk.Text = ""
            '#Trupti 14 JUN 2021
            chkIsOffPerm.Checked = False
            txtoffPermRmrk.Text = ""

            drpBookingType.SelectedValue = "SELECT"
            lblchkSts.Text = IIf(chkIsOffPerm.Checked, "Given", "Not Given")
            '#Trupti 14 JUN 2021


            clsGeneral.ShowConsoleTrack("btnpre_Click", "", Page)
            If (CDate(txtdate.Text) = Date.Today) Then
            Else
                txtflag.Value = ""
                txtdate.Text = CDate(txtdate.Text).AddDays(-1)
                If (Getsessions() = True) Then
                    UP3.Update()
                    ButtonEnabled(True, False, False, False, False)
                Else
                    UP2.Update()
                    rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
                    CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

                    Pnl2Enabled(False)
                End If

                'getsessions()

            End If
        End If
    End Sub

    Protected Sub btncncl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncncl.Click
        FnRights()   'Pushpa 20180512
        UP2.Update() 'RasikV 20170125
        UP3.Update()
        If txtflag.Value = "EDIT" Then
            imageSearchDoc.Enabled = True
            txtdctid.Enabled = False
        End If

        ButtonEnabled(True, False, False, False, False)
        rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
        CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

        Pnl2Enabled(False)
        ClearAll()
        clearSession()
    End Sub

    Protected Sub btnshftnow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnshftnow.Click 'RasikV 20170127
        Dim IpOpFlg As String = IIf(rdbPatientType.SelectedValue = "I", "I", "O")
        Dim BookingType As Integer = 0

        If (drpBookingType.SelectedValue <> "SELECT") Then
            BookingType = Convert.ToInt32(drpBookingType.SelectedValue)
        End If

        IFrame("shiftnow.aspx?docid=" & txtdctid.Text & "&docname=" & txtdctname.Text & "&patid=" & txtpatid.Text & "  &patname=" & txtpatname.Text & "&aptno=" & txtapptno.Text & "&ipflag=" & IpOpFlg & "&oldfctcd=" & txtot.Text & "&Remark=" & txtRmrk.Text & "&BookingType=" & BookingType)
    End Sub

    Protected Sub btnexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexit.Click
        'Try
        '    Dim SubMenuPath As String
        '    SubMenuPath = ConfigurationManager.AppSettings("SubMenuPath") + "?" + Now
        '    ScriptManager.RegisterStartupScript(Me, [GetType](), "", "window.parent.location.href='" & SubMenuPath & "';", True)
        'Catch ex As Exception
        '    clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        'End Try

        'pragya : 12-oct-2016
        objArrOTSrvDtls = Nothing
        Session("ActualPtnNo") = Nothing
        Session("objArrOTSrvDtls") = Nothing
        Session("objArrOTDoctorsDtls") = Nothing
        Session("IpNoChnged") = Nothing
        Session("OTSelected") = Nothing
        Session("OTDateSelected") = Nothing
        Session("OTStartTmSelected") = Nothing
        Session("OTEndTmSelected") = Nothing
        Session("OTDocIdSelected") = Nothing
        Session("OTDocNameSelected") = Nothing
        Session("OTPatIdSelected") = Nothing
        Session("OTPatNameSelected") = Nothing
        Session("OTHrsSelected") = Nothing
        Session("OTMinsSelected") = Nothing
        Session("OTStrtTme1Selected") = Nothing
        Session("OTApptNoSelected") = Nothing
        Session("OTSlotsSelected") = Nothing
        Session("OTRemarksSelected") = Nothing
        'pragya : 12-oct-2016
        Session("EditMode") = Nothing 'anamika 20161003
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub BtnSelDoc_Click(sender As Object, e As EventArgs) Handles BtnSelDoc.Click
        Try
            If ((txthrs.Text = "00" Or txthrs.Text = "0" Or txthrs.Text.Trim() = "") And (txtmins.Text = "00" Or txtmins.Text = "0" Or txtmins.Text.Trim() = "")) Then
                clsGeneral.ShowErrorPopUp("Enter Valid Hours & Minutes", "", Page)
                Exit Sub
            End If
            If txtpatid.Text <> "" And txtpatname.Text <> "" Then
                'get the patient no by passing IPno of patient
                Dim lngPtnNo As Long = 0
                lngPtnNo = OTScheduling.GetPtnNoByIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt64(txtpatid.Text))

                Session("FctCd") = Integer.Parse(txtot.Text) '1
                Session("FctCatCd") = 1
                Session("FctMainCd") = 1
                Session("ActualPtnNo") = IIf(rdbPatientType.SelectedValue = "I", IIf(lngPtnNo <> 0, lngPtnNo, 0), txtpatid.Text)
                Session("OTSelected") = txtot.Text
                Session("OTDateSelected") = txtdate.Text
                Session("OTStartTmSelected") = txtstrttime.Text
                Session("OTEndTmSelected") = txtendtime.Text
                Session("OTDocIdSelected") = txtdctid.Text
                Session("OTDocNameSelected") = txtdctname.Text
                Session("OTPatIdSelected") = txtpatid.Text
                Session("OTPatNameSelected") = txtpatname.Text
                Session("OTHrsSelected") = txthrs.Text
                Session("OTMinsSelected") = txtmins.Text
                Session("OTStrtTme1Selected") = txtstrttm1.Text
                Session("OTApptNoSelected") = txtapptno.Text
                Session("OTSlotsSelected") = txtslots.Text
                Session("OTRemarksSelected") = txtRmrk.Text
                Session("OTCancelRemarksSelected") = txtCnclRmrk.Text
                Session("OTIPOPFLAG") = rdbPatientType.SelectedValue

                If txtdctid.Text = "" And txtdctname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 21), "txtdctid", Page)
                    txtdctid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                If txtpatid.Text = "" And txtpatname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 22), "txtpatid", Page)
                    txtpatid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                If txtflag.Value <> "" Then
                    Session("TxtFlag") = txtflag.Value
                End If

                ' Session("objArrOTDoctorsDtls") = Nothing 'RasikV 20170123 ''Commented By Amol 2019-12-17 For View Data 

                'Response.Redirect("frmOTDoctorsAdd.aspx?MODE")
                'Response.Redirect("OtScheduling.aspx?otno=" + txtot.Text + "&patid=" + getindirectbooking(i).PtnNo.ToString() + "&docid=" + getindirectbooking(i).DocCd.ToString() + " &patname=" + getindirectbooking(i).PtnFullNm.ToString() + " &docname=" + getindirectbooking(i).DocFullNm.ToString() + " &expdate=" + getindirectbooking(i).ExpectedDate.Date.ToShortDateString() + "&TrnNo=" + getindirectbooking(i).TrnNo.ToString() + " &PtnActualPtnNo=" + getindirectbooking(i).PtnActualPtnNo.ToString() + "")

                IFrame("frmOTDoctorsAdd.aspx?MODE  & ipflag=" & rdbPatientType.SelectedValue) 'RasikV 20170127
            Else

                If txtdctid.Text = "" And txtdctname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 21), "txtdctid", Page)
                    txtdctid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                If txtpatid.Text = "" And txtpatname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 22), "txtpatid", Page)
                    txtpatid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                txtdctid.Focus()
                Getsessions()
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "txtOtDoc", Page)
        End Try
    End Sub

    Protected Sub BtnSelEmp_Click(sender As Object, e As EventArgs) Handles BtnSelEmp.Click
        Try
            If ((txthrs.Text = "00" Or txthrs.Text = "0" Or txthrs.Text.Trim() = "") And (txtmins.Text = "00" Or txtmins.Text = "0" Or txtmins.Text.Trim() = "")) Then
                clsGeneral.ShowErrorPopUp("Enter Valid Hours & Minutes", "", Page)
                Exit Sub
            End If

            If txtpatid.Text <> "" And txtpatname.Text <> "" Then
                'get the patient no by passing IPno of patient
                Dim lngPtnNo As Long = 0
                lngPtnNo = OTScheduling.GetPtnNoByIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt64(txtpatid.Text))

                Session("FctCd") = txtot.Text '1
                Session("FctCatCd") = 1
                Session("FctMainCd") = 1
                Session("ActualPtnNo") = IIf(lngPtnNo <> 0, lngPtnNo, 0)
                Session("OTSelected") = txtot.Text
                Session("OTDateSelected") = txtdate.Text
                Session("OTStartTmSelected") = txtstrttime.Text
                Session("OTEndTmSelected") = txtendtime.Text
                Session("OTDocIdSelected") = txtdctid.Text
                Session("OTDocNameSelected") = txtdctname.Text
                Session("OTPatIdSelected") = txtpatid.Text
                Session("OTPatNameSelected") = txtpatname.Text
                Session("OTHrsSelected") = txthrs.Text
                Session("OTMinsSelected") = txtmins.Text
                Session("OTStrtTme1Selected") = txtstrttm1.Text
                Session("OTApptNoSelected") = txtapptno.Text
                Session("OTSlotsSelected") = txtslots.Text
                Session("OTRemarksSelected") = txtRmrk.Text
                Session("OTCancelRemarksSelected") = txtCnclRmrk.Text
                Session("OTIPOPFLAG") = rdbPatientType.SelectedValue 'shital 20211202

                If txtdctid.Text = "" And txtdctname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 21), "txtdctid", Page)
                    txtdctid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                If txtpatid.Text = "" And txtpatname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 22), "txtpatid", Page)
                    txtpatid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                If txtflag.Value <> "" Then
                    Session("TxtFlag") = txtflag.Value
                End If

                ' Session("objArrOTEmpDtls") = Nothing 'RasikV 20170123  ''Commented By Amol 2019-12-17 For View Data 
                IFrame("frmOTEmpAdd.aspx?MODE & ipflag=" & rdbPatientType.SelectedValue) 'RasikV 20170127
            Else

                If txtdctid.Text = "" And txtdctname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 21), "txtdctid", Page)
                    txtdctid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                If txtpatid.Text = "" And txtpatname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 22), "txtpatid", Page)
                    txtpatid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                txtdctid.Focus()
                Getsessions()
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Protected Sub btnSelSrvDtls_Click(sender As Object, e As EventArgs) Handles btnSelSrvDtls.Click
        Try
            If ((txthrs.Text = "00" Or txthrs.Text = "0" Or txthrs.Text.Trim() = "") And (txtmins.Text = "00" Or txtmins.Text = "0" Or txtmins.Text.Trim() = "")) Then
                clsGeneral.ShowErrorPopUp("Enter Valid Hours & Minutes", "", Page)
                Exit Sub
            End If
            If txtpatid.Text <> "" And txtpatname.Text <> "" Then
                'get the patient no by passing IPno of patient
                Dim lngPtnNo As Long = 0
                lngPtnNo = OTScheduling.GetPtnNoByIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt64(txtpatid.Text))

                Session("ActualPtnNo") = IIf(lngPtnNo <> 0, lngPtnNo, 0) 'aditi 02062023

                'If txtflag.Value <> "" Then
                '    Session("TxtFlag") = txtflag.Value
                'End If

                'If txtdctid.Text = "" And txtdctname.Text = "" Then
                '    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 21), "txtdctid", Page)
                '    txtdctid.Focus()
                '    Getsessions()
                '    Exit Sub
                'End If

                'If txtpatid.Text = "" And txtpatname.Text = "" Then
                '    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 22), "txtpatid", Page)
                '    txtpatid.Focus()
                '    Getsessions()
                '    Exit Sub
                'End If


                '' & ipflag=" & rdbPatientType.SelectedValue
                ''  Session("objArrOTSrvDtls") = Nothing 'RasikV 20170123 ''Commented By Amol 2019-12-17 For View Data 
                '' IFrame("frmOTEmpAdd.aspx?MODE & ipflag=" & rdbPatientType.SelectedValue) 
                'IFrame("frmOTServicesAdd.aspx") 'RasikV 20170127
            Else
                If txtdctid.Text = "" And txtdctname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 21), "txtdctid", Page)
                    txtdctid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                If txtpatid.Text = "" And txtpatname.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 22), "txtpatid", Page)
                    txtpatid.Focus()
                    Getsessions()
                    Exit Sub
                End If

                txtdctid.Focus()
                Getsessions()
            End If

            Session("FctCd") = txtot.Text    'aditi 02062023 start
            Session("FctCatCd") = 1
            Session("FctMainCd") = 1
            Session("OTSelected") = txtot.Text
            Session("OTDateSelected") = txtdate.Text
            Session("OTStartTmSelected") = txtstrttime.Text
            Session("OTEndTmSelected") = txtendtime.Text
            Session("OTDocIdSelected") = txtdctid.Text
            Session("OTDocNameSelected") = txtdctname.Text
            Session("OTPatIdSelected") = txtpatid.Text
            Session("OTPatNameSelected") = txtpatname.Text
            Session("OTHrsSelected") = txthrs.Text
            Session("OTMinsSelected") = txtmins.Text
            Session("OTStrtTme1Selected") = txtstrttm1.Text
            Session("OTApptNoSelected") = txtapptno.Text
            Session("OTSlotsSelected") = txtslots.Text
            Session("OTRemarksSelected") = txtRmrk.Text
            Session("OTCancelRemarksSelected") = txtCnclRmrk.Text
            Session("OTIPOPFLAG") = rdbPatientType.SelectedValue


            If txtflag.Value <> "" Then
                Session("TxtFlag") = txtflag.Value
            End If

            If txtdctid.Text = "" And txtdctname.Text = "" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 21), "txtdctid", Page)
                txtdctid.Focus()
                Getsessions()
                Exit Sub
            End If

            If txtpatid.Text = "" And txtpatname.Text = "" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 22), "txtpatid", Page)
                txtpatid.Focus()
                Getsessions()
                Exit Sub
            End If

            IFrame("frmOTServicesAdd.aspx") 'aditi 02062023 end

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try

    End Sub

    Protected Sub btnCloseFrame_Click(sender As Object, e As EventArgs) 'RasikV 20170127
        Try
            divPopupFrame.Visible = False
            divOverlayPopupFrame.Style("display") = "none"

            If Not (sender.GetType().Name.Equals("LinkButton") And DirectCast(sender, LinkButton).ID.Equals("btnCloseFrame")) Then
                upFrame.Update()
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Protected Sub btnRowDblclicked_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRowDblclicked.Click 'RasikV 20170125
        UP2.Update()
        Pnl2.Enabled = True



        clsGeneral.ShowErrorPopUp("123", "txtOpPtnCd", Page)
    End Sub
#End Region

#Region "FUNCTIONS"

    Public Sub SaveSrvRuleInfo9232()            'Aarti 10 Oct 2020
        Dim obj = New clsRuleMaster()
        obj = OTScheduling.GetRuleMstDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 9232)
        If (obj IsNot Nothing) Then
            If (obj.Data1 = "Y") Then
                btnSelSrvDtls.Visible = True
            Else
                btnSelSrvDtls.Visible = False
            End If
        End If
        obj = Nothing


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
    Public Function GetpendingDetails() As Boolean
        Try
            UP2.Update() 'RasikV 20170125

            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Dim day As Integer = Weekday(txtdate.Text, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)

            Dim clsfctmstr As List(Of clsFCTMST)
            clsfctmstr = OTScheduling.GetFCTHoliDayDay(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(txtdate.Text), Integer.Parse(txtot.Text))

            If (clsfctmstr IsNot Nothing) Then
                If (clsfctmstr(0).FCTRMKS <> "") Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 25), "", Page)
                    ClearDrawTimeScale()
                    Return False
                End If
            End If


            Dim strtime As Integer = OTScheduling.GetFCTFCTSTRTTIME(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), day)
            Dim Endtime As Integer = OTScheduling.GetFCTFCTENDTIME(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), day)



            If (strtime = 0.ToString()) Then
                ClearDrawTimeScale()
                AddMessage()
                Return False
            End If

            Dim ActStTm As Integer
            If (txtstrttime.Text IsNot Nothing) And (txtstrttime.Text <> "") Then

            End If

            If (strtime.ToString().Length = 3) Then
                txtstrttime.Text = "0" & Left(strtime.ToString(), 1) & ":" & Right(strtime.ToString(), 2)
            ElseIf (strtime.ToString().Length = 2) Then                     'Aarti 16 Oct 2020
                txtstrttime.Text = "00" & ":" & Right(strtime.ToString(), 2)
            ElseIf (strtime.ToString().Length = 1) Then
                txtstrttime.Text = "00" & ":" & "0" & Right(strtime.ToString(), 1)
            Else
                txtstrttime.Text = Left(strtime.ToString(), 2) & ":" & Right(strtime.ToString(), 2)
            End If
            If (Endtime.ToString().Length = 3) Then
                txtendtime.Text = "0" & Left(Endtime.ToString(), 1) & ":" & Right(Endtime.ToString(), 2)
            ElseIf (Endtime.ToString().Length = 2) Then
                txtendtime.Text = "00" & ":" & Right(Endtime.ToString(), 2)
            ElseIf (Endtime.ToString().Length = 1) Then
                txtendtime.Text = "00" & ":" & "0" & Right(Endtime.ToString(), 1)
            Else
                txtendtime.Text = Left(Endtime.ToString(), 2) & ":" & Right(Endtime.ToString(), 2)
            End If
            GetpendingDetails = False
            Dim clsmstr As List(Of OTSchedulingSerRef.clsMaster)
            clsmstr = OTScheduling.GetFctMstDtlList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Integer.Parse(txtot.Text), 1, 1)
            If (clsmstr IsNot Nothing) Then
                lv_fct_slot_prd_hrs = clsmstr(0).data2
                lv_fct_slot_prd_mins = clsmstr(0).data3
            End If
            Dim DS As New DataSet
            DS = OTScheduling.GetFCTAPTREQ(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text))

            UP5.Update() 'RasikV 20170125

            If (DS IsNot Nothing) Then
                If (DS.Tables(0).Rows.Count > 0) Then
                    GrdReqDetails.DataSource = DS
                    GrdReqDetails.DataBind()
                    regscript()
                Else
                    GrdReqDetails.DataSource = Nothing
                    GrdReqDetails.DataBind()
                End If
            Else
                GrdReqDetails.DataSource = Nothing
                GrdReqDetails.DataBind()
            End If

            'txthrs.Text = "00"
            'txtmins.Text = lvSlotDur.ToString()
            'txtstrttm1.Text = txtstrttime.Text

            Dim strtm1 As String = txtstrttime.Text
            txtstrttm1.Text = Convert.ToDateTime(txtstrttime.Text).ToString("HH:mm")

            'txtstrttm1.Text = Date.Now.ToString("HH:mm:ss")

            GetpendingDetails = True
        Catch ex As Exception
            GetpendingDetails = False
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 39), "", Page)
        End Try
        Return GetpendingDetails
    End Function

    Public Function Getsessions() As Boolean
        Try
            If (txtot.Text <> "") Then
                arrsession = Nothing
                btnarr = Nothing
                btnarrcnt = 0
                If (GetpendingDetails()) Then
                    strErrMsg = New List(Of String)
                    chrErrFlg = "N"
                    GetSlotsCount()
                    Dim day As Integer = Weekday(txtdate.Text, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)
                    Dim clsfctcal As List(Of clsFCTCAL)
                    clsfctcal = OTScheduling.GetFCCAL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Integer.Parse(txtot.Text), 1, 1, day)
                    If (clsfctcal IsNot Nothing) Then
                        For i As Integer = 0 To clsfctcal.Count - 1
                            Dim tmp As New clsSession
                            ReDim Preserve arrsession(i)
                            If (clsfctcal(i).STRTTIME.ToString().Length = 3) Then
                                tmp.starttime = CDate("0" & Left(clsfctcal(i).STRTTIME.ToString(), 1) & ":" & Right(clsfctcal(i).STRTTIME.ToString(), 2))
                            ElseIf (clsfctcal(i).STRTTIME.ToString().Length = 2) Then
                                tmp.starttime = CDate("00" & ":" & Right(clsfctcal(i).STRTTIME.ToString(), 2))
                            ElseIf (clsfctcal(i).STRTTIME.ToString().Length = 1) Then
                                tmp.starttime = CDate("00" & ":" & "0" & Right(clsfctcal(i).STRTTIME.ToString(), 1))
                            Else
                                tmp.starttime = CDate(Left(clsfctcal(i).STRTTIME.ToString(), 2) & ":" & Right(clsfctcal(i).STRTTIME.ToString(), 2))
                            End If
                            If (clsfctcal(i).ENDTIME.ToString().Length = 3) Then
                                tmp.endtime = CDate("0" & Left(clsfctcal(i).ENDTIME.ToString(), 1) & ":" & Right(clsfctcal(i).ENDTIME.ToString(), 2))
                            ElseIf (clsfctcal(i).ENDTIME.ToString().Length = 2) Then
                                tmp.endtime = CDate("00" & ":" & Right(clsfctcal(i).ENDTIME.ToString(), 2))
                            ElseIf (clsfctcal(i).ENDTIME.ToString().Length = 1) Then
                                tmp.endtime = CDate("00" & ":" & "0" & Right(clsfctcal(i).ENDTIME.ToString(), 1))
                            Else
                                tmp.endtime = CDate(Left(clsfctcal(i).ENDTIME.ToString(), 2) & ":" & Right(clsfctcal(i).ENDTIME.ToString(), 2))
                            End If
                            arrsession(i) = tmp
                        Next
                        sess = arrsession
                    Else
                        txtdate.Text = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 11), "", Page)
                    End If

                    If arrsession Is Nothing Then
                        AddMessage()
                    Else
                        DrawTimeControl()
                        FillBooking(Integer.Parse(txtot.Text), CDate(txtdate.Text))
                    End If
                    Getsessions = True
                Else
                    Getsessions = False
                End If
            End If
        Catch ex As Exception
            Getsessions = False
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 39), "", Page)
        End Try
    End Function

    Public Sub FillBooking(ByVal Resource_Code As Integer, ByVal AppointmentDate As Date)
        Try
            UP4.Update() 'RasikV 20170125
            Dim clsFCTAPTOT As List(Of clsFCTAPTOT)
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            clsFCTAPTOT = OTScheduling.GetOTAptDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Resource_Code, 1, 1, AppointmentDate, 0, 0, 0, "")
            If (clsFCTAPTOT IsNot Nothing) Then
                For i As Integer = 0 To clsFCTAPTOT.Count - 1
                    Dim APTM_TM_FROM As String = clsFCTAPTOT(i).APTMTMFROM
                    If (APTM_TM_FROM.Length = 1) Then
                        APTM_TM_FROM = "0" & Right(APTM_TM_FROM, 1)
                    End If

                    Dim APTM_TM_TO As String = clsFCTAPTOT(i).APTMTMTO
                    If (APTM_TM_TO.Length = 1) Then
                        APTM_TM_TO = "0" & Right(APTM_TM_TO, 1)
                    End If

                    Dim pstartime As Date = CDate(Strings.Right("00" & Mid(APTM_TM_FROM, 1, APTM_TM_FROM.Length - 2), 2) & ":" & Strings.Right(APTM_TM_FROM, 2))
                    Dim pendime As Date = CDate(Strings.Right("00" & Mid(APTM_TM_TO, 1, APTM_TM_TO.Length - 2), 2) & ":" & Strings.Right(APTM_TM_TO, 2))
                    Dim pslots As Long = clsFCTAPTOT(i).NOOFSLOTSUSED
                    Dim dctcode As Long = clsFCTAPTOT(i).DOCCD
                    Dim apptno As Long = clsFCTAPTOT(i).APPTNO
                    Dim patno As Long = clsFCTAPTOT(i).PTNNO
                    Dim patnname As String = clsFCTAPTOT(i).PTNLNGNM
                    Dim DOCNAME As String = clsFCTAPTOT(i).DOCNAME
                    Dim AptRmrks As String = clsFCTAPTOT(i).APPTRMRK                'pragya : 02-nov-2016

                    Dim PtnType As String = clsFCTAPTOT(i).IPOP '' Amol 2020-11-07 JSK001-147262	

                    Dim BlnIsOffPerm As Boolean = clsFCTAPTOT(i).IsOfficePrmsnGiven
                    Dim OfficePrmsnRmrk As String = clsFCTAPTOT(i).OfficePrmsnRmrk
                    Dim OffPermDtl As String = ""
                    If BlnIsOffPerm = True Then

                        OffPermDtl = "Office Permission Given By " + clsFCTAPTOT(i).OfficePrmsnByUsrID.ToString() + " On " + clsFCTAPTOT(i).OfficePrmsnDtTm.ToString("dd/MM/yyyy HH:mm")
                    End If


                    Dim BookingType As Integer

                    BookingType = clsFCTAPTOT(i).BOOKING_TYPE

                    DrawButtons(pstartime, pendime, pslots, clsFCTAPTOT(i).APPTNO, AppointmentDate, DOCNAME, dctcode, patno, patnname, AptRmrks, PtnType, BlnIsOffPerm, OfficePrmsnRmrk, OffPermDtl, BookingType)
                    DrawLabel(pstartime, pendime, pslots, clsFCTAPTOT(i).APPTNO, AppointmentDate, DOCNAME, dctcode, patno, patnname, AptRmrks, PtnType)
                Next
                regscript()
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Public Function SAVENEWBOOKING() As Boolean
        SAVENEWBOOKING = False
        Try


            clsGeneral.ShowConsoleTrack("SAVENEWBOOKING starrt1 ", "", Page)

            Dim AptNo As Integer 'shital 20190921
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
                Exit Function
            End If
            Dim dtserverdttm As Date = clsGeneral.getdate()
            GetSlotsCount()
            Dim tomins As String = txtmins.Text
            If (Integer.Parse(txthrs.Text) = 0) Then
                If (Integer.Parse(tomins) <> 0) Then
                    If (Integer.Parse(tomins) < lvSlotDur) Then
                        tomins = lvSlotDur.ToString()
                        txtmins.Text = tomins
                    End If
                End If
            End If

            If (Integer.Parse(txthrs.Text) = 0) Then
                If (Integer.Parse(tomins) = 0) Then
                    If (Integer.Parse(tomins) < lvSlotDur) Then
                        tomins = lvSlotDur.ToString()
                        txtmins.Text = tomins
                    End If
                End If
            End If
            clsGeneral.ShowConsoleTrack("SAVENEWBOOKING starrt 2 ", "", Page)
            'If (Integer.Parse(txthrs.Text) = 0) Then
            '    If (Integer.Parse(tomins) = 0) Then
            '        ' If (Integer.Parse(tomins) < lvSlotDur) Then
            '        tomins = lvSlotDur.ToString()
            '        ' If
            '    End If
            'End If
            'If (txthrs.Text = "00") Then
            '    If (Integer.Parse(txtmins.Text) <> 0) Then
            '        If (Integer.Parse(tomins) < lvSlotDur) Then
            '            tomins = lvSlotDur.ToString()
            '        End If
            '    End If
            'End If

            ''to adjust slot duration if tomins is greater that ot slot duration
            If (Integer.Parse(tomins) > lvSlotDur) Then
                Dim tem As Integer
                tem = Integer.Parse(tomins) + (lvSlotDur - (Integer.Parse(tomins) - lvSlotDur))
                tomins = tem.ToString()
                txtmins.Text = tomins
            End If

            Dim pstartime As Date = CDate(txtstrttm1.Text)
            Dim pendime As Date = CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + tomins)

            Dim span As TimeSpan = pendime.Subtract(pstartime)
            Dim actstartime As Date = AdjustDate(pstartime, True)
            Dim actpendime As Date = AdjustDate(pendime, False)
            '  txtmins.Text = tomins

            Dim boolmsg As Boolean = False
            If pstartime <> actstartime Then
                boolmsg = True
                actpendime = AdjustDate(CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + txtmins.Text))
                Dim actpendime1 As Date = AdjustDate(actpendime, False)
                If actpendime <> actpendime1 Then
                    actpendime = actpendime1
                End If
            End If

            Dim actslots As Long = CalNoofSlotsRequired(actstartime, actpendime, lvSlotDur)
            pstartime = actstartime
            pendime = actpendime
            clsGeneral.ShowConsoleTrack("SAVENEWBOOKING starrt 3 ", "", Page)
            If (CheckSlotAvailable(pstartime, pendime)) Then
            Else
                clsGeneral.ShowConsoleTrack("SAVENEWBOOKING starrt 4 ", "", Page)
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "", Page)
                btnarr = Nothing
                btnarrcnt = 0
                ClearAll()
                Getsessions()
                Exit Function
            End If

            Dim pslots As Long = CalNoofSlotsRequired(pstartime, pendime, lvSlotDur)

            If (pslots = 0) Then
                pslots = 1
            End If

            Dim obj As New clsFCTAPTOT
            obj.FCTCODE = Integer.Parse(txtot.Text)
            obj.APTMDATE = CDate(txtdate.Text)
            obj.DOCCD = Integer.Parse(txtdctid.Text)
            obj.ISPATIENT = IIf(txtpatid.Text <> "", True, False)
            clsGeneral.ShowConsoleTrack("SAVENEWBOOKING starrt 5 ", "", Page)
            If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                If txtpatid.Text <> "" Then
                    obj.PTNNO = Long.Parse(txtpatid.Text)
                    obj.IPOP = "O"
                Else
                    obj.PTNNO = 0
                    obj.IPOP = "O"
                End If
            Else
                obj.PTNNO = Long.Parse(txtpatid.Text)
                obj.IPOP = "I"
            End If

            'If txtpatid.Text <> "" Then   '''' Amol 2020-11-07 JSK001-147262	
            '    obj.PTNNO = Long.Parse(txtpatid.Text)
            '    obj.IPOP = "I"
            'Else
            '    obj.PTNNO = 0
            '    obj.IPOP = "O"
            'End If
            clsGeneral.ShowConsoleTrack("SAVENEWBOOKING starrt 6 ", "", Page)
            obj.PTNLNGNM = txtpatname.Text
            obj.APTMTMFROM = pstartime.Hour * 100 + pstartime.Minute
            obj.APTMTMTO = pendime.Hour * 100 + pendime.Minute
            obj.NOOFSLOTSUSED = pslots
            obj.DURATION = pslots * lvSlotDur
            obj.ISPERFORMED = False
            obj.ISPOSTED = False
            obj.CRTUSRID = Session("USERID")
            obj.CRTDTTM = dtserverdttm
            obj.APPTRMRK = txtRmrk.Text   'PRAGYA : 15-OCT-2016
            obj.FLG = "A"
            obj.IsOfficePrmsnGiven = chkIsOffPerm.Checked
            obj.OfficePrmsnRmrk = txtoffPermRmrk.Text
            obj.OfficePrmsnByUsrID = Session("USERID")
            obj.OfficePrmsnDtTm = dtserverdttm


            clsGeneral.ShowConsoleTrack("SAVENEWBOOKING starrt 7 ", "", Page)

            If (drpBookingType.SelectedValue <> "SELECT") Then
                obj.BOOKING_TYPE = Convert.ToInt32(drpBookingType.SelectedValue)

            Else
                obj.BOOKING_TYPE = 0
            End If

            '   obj.BOOKING_TYPE = IIf(drpBookingType.SelectedValue = "SELECT", 0, Convert.ToInt32(drpBookingType.SelectedValue))
            Dim objFCT_APT_MAIN As New clsFCTAPTMAIN
            objFCT_APT_MAIN.FCTCODE = Integer.Parse(txtot.Text)

            If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                If txtpatid.Text <> "" Then
                    objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
                    objFCT_APT_MAIN.pIPOPFLG = "O"
                Else
                    objFCT_APT_MAIN.IPOP = 0
                    objFCT_APT_MAIN.pIPOPFLG = "O"
                End If
            Else
                objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
                objFCT_APT_MAIN.pIPOPFLG = "I"
            End If


            'If txtpatid.Text <> "" Then   '''' Amol 2020-11-07 JSK001-147262	
            '    objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
            '    objFCT_APT_MAIN.pIPOPFLG = "I"
            'Else
            '    objFCT_APT_MAIN.IPOP = 0
            '    objFCT_APT_MAIN.pIPOPFLG = "O"
            'End If
            objFCT_APT_MAIN.APTMDATE = CDate(txtdate.Text)
            objFCT_APT_MAIN.APTMSTS = 1 '<--BOOKING ( CD_DCD TYP = 404  )
            objFCT_APT_MAIN.REQNO = 0
            objFCT_APT_MAIN.REQSRNO = 0
            objFCT_APT_MAIN.APTMFROMHRS = pstartime.Hour
            objFCT_APT_MAIN.APTMFROMMIN = pstartime.Minute
            objFCT_APT_MAIN.APTMTOHRS = pendime.Hour
            objFCT_APT_MAIN.APTMTOMNS = pendime.Minute
            objFCT_APT_MAIN.APTMACTFROMHRS = 0
            objFCT_APT_MAIN.APTMACTFROMMIN = 0
            objFCT_APT_MAIN.APTMACTTOHRS = 0
            objFCT_APT_MAIN.APTMACTTOMNS = 0
            objFCT_APT_MAIN.Billed = "1"
            objFCT_APT_MAIN.BookFor = IIf(txtpatid.Text.Trim <> "", "P", "O")
            objFCT_APT_MAIN.WARDNO = 0 '<--
            objFCT_APT_MAIN.PTNCLSCD = 0 '<--
            objFCT_APT_MAIN.BEDNO = "" '<--
            objFCT_APT_MAIN.APTMREFBY = ""
            objFCT_APT_MAIN.ICDGRPCD = ""
            objFCT_APT_MAIN.ICDCD = ""
            objFCT_APT_MAIN.DR1CODE = 0
            objFCT_APT_MAIN.DR2CODE = 0
            objFCT_APT_MAIN.DR3CODE = 0
            objFCT_APT_MAIN.DR4CODE = 0
            objFCT_APT_MAIN.ANAS1CODE = 0
            objFCT_APT_MAIN.ANAS2CODE = 0
            objFCT_APT_MAIN.ANAS3CODE = 0
            objFCT_APT_MAIN.SURGNOTE1 = ""
            objFCT_APT_MAIN.SURGNOTE2 = ""
            objFCT_APT_MAIN.OPRSTFTYPE1 = 0
            objFCT_APT_MAIN.TYPE1NOS = 0
            objFCT_APT_MAIN.OPRSTFTYPE2 = 0
            objFCT_APT_MAIN.TYPE2NOS = 0
            objFCT_APT_MAIN.OPRSTFTYPE3 = 0
            objFCT_APT_MAIN.TYPE3NOS = 0
            objFCT_APT_MAIN.OPRSTFTYPE4 = 0
            objFCT_APT_MAIN.TYPE4NOS = 0
            objFCT_APT_MAIN.SPLINST = 0
            objFCT_APT_MAIN.CRTUSRID = Session("USERID")
            objFCT_APT_MAIN.CRTDTTM = dtserverdttm 'CDate(txtdate.Text)
            objFCT_APT_MAIN.UPDTTTM = dtserverdttm 'CDate(txtdate.Text)
            objFCT_APT_MAIN.UPDUSRID = Session("USERID")
            objFCT_APT_MAIN.PTNFSTNAME = txtpatname.Text 'IIf(Split(txtpatname.Text, " ").Length >= 2, Split(txtpatname.Text, " ")(2), "") '"" '<--
            objFCT_APT_MAIN.PTNLSTNAME = txtpatname.Text 'IIf(Split(txtpatname.Text, " ").Length >= 3, Split(txtpatname.Text, " ")(3), "") '"" '<--
            objFCT_APT_MAIN.PTNMIDNAME = txtpatname.Text 'IIf(Split(txtpatname.Text, " ").Length >= 1, Split(txtpatname.Text, " ")(1), "") '"" '<--

            clsGeneral.ShowConsoleTrack("SAVENEWBOOKING starrt 7 ", "", Page)

            Dim objFCTSCH As New clsFCTSCH

            objFCTSCH.FCTCODE = Integer.Parse(txtot.Text)
            objFCTSCH.FctCatCode = 1
            objFCTSCH.FctMainCode = 1
            objFCTSCH.SCHDATE = CDate(txtdate.Text)

            If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                If txtpatid.Text <> "" Then
                    objFCTSCH.IPOPNO = Long.Parse(txtpatid.Text)
                    'objFCTSCH.IPOPFLG = "I"

                    objFCTSCH.IPOPFLG = "O" 'shital 202100807
                Else
                    objFCTSCH.IPOPNO = 0
                    objFCTSCH.IPOPFLG = "O"
                End If
            Else
                objFCTSCH.IPOPNO = Long.Parse(txtpatid.Text)
                objFCTSCH.IPOPFLG = "I"
            End If


            'If txtpatid.Text <> "" Then   '''' Amol 2020-11-07 JSK001-147262	
            '    objFCTSCH.IPOPNO = Long.Parse(txtpatid.Text)
            '    objFCTSCH.IPOPFLG = "I"
            'Else
            '    objFCTSCH.IPOPNO = 0
            '    objFCTSCH.IPOPFLG = "O"
            'End If
            objFCTSCH.STRTHR = pstartime.Hour
            objFCTSCH.STRTMIN = pstartime.Minute
            objFCTSCH.ENDTHR = pendime.Hour
            objFCTSCH.ENDTMIN = pendime.Minute

            Dim objFCTAPTREQ As New clsFCTAPTREQ
            objFCTAPTREQ.FCTCODE = Integer.Parse(txtot.Text)
            objFCTAPTREQ.REQNO = 1
            objFCTAPTREQ.CRTUSRID = Session("USERID")
            objFCTAPTREQ.CRTDTTM = dtserverdttm
            objFCTAPTREQ.UPDUSRID = Session("USERID")
            objFCTAPTREQ.UPDDTTM = dtserverdttm

            'objFCTAPTREQ.IPOPNO = Long.Parse(txtpatid.Text)
            'If txtpatid.Text <> "" Then   '''' Amol 2020-11-07 JSK001-147262	
            '    objFCTAPTREQ.IPOPNO = Long.Parse(txtpatid.Text)
            'Else
            '    objFCTAPTREQ.IPOPNO = 0
            'End If

            clsGeneral.ShowConsoleTrack("SAVENEWBOOKING starrt 8 ", "", Page)
            If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                If txtpatid.Text <> "" Then
                    objFCTAPTREQ.IPOPNO = Long.Parse(txtpatid.Text)
                Else
                    objFCT_APT_MAIN.IPOP = 0
                End If
            Else
                objFCTAPTREQ.IPOPNO = Long.Parse(txtpatid.Text)
            End If



            Dim day As Integer = Weekday(txtdate.Text, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)

            Dim bkngstatus As New ClsOtIndirectBooking
            bkngstatus.DocCd = txtdctid.Text
            bkngstatus.ExpectedDate = txtdate.Text
            'bkngstatus.PtnNo = txtpatid.Text

            If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                If txtpatid.Text <> "" Then
                    bkngstatus.PtnNo = Convert.ToInt64(txtpatid.Text)
                Else
                    bkngstatus.PtnNo = 0
                End If
            Else
                bkngstatus.PtnNo = Convert.ToInt64(txtpatid.Text)
            End If


            'If txtpatid.Text <> "" Then   '''' Amol 2020-11-07 JSK001-147262	
            '    bkngstatus.PtnNo = Convert.ToInt64(txtpatid.Text)
            'Else
            '    bkngstatus.PtnNo = 0
            'End If


            bkngstatus.Status = 2           '1-new request 2-request completed 3-cancel request
            ' If txtapptno.Text = "" Then
            If Request("TrnNo") = "" Then

                bkngstatus.TrnNo = False
            Else
                'bkngstatus.TrnNo = IIf(Request("TrnNo"), False, txtapptno.Text)
                bkngstatus.TrnNo = IIf(IsDBNull(Request("TrnNo")), txtapptno.Text, Request("TrnNo"))
            End If

            bkngstatus.UserDtTm = clsGeneral.getdate
            bkngstatus.UserId = Session("USERID")

            If (txtreqno.Value = "") Then
                txtreqno.Value = "0"
            End If

            '20211204

            If (Session("SHIFTFLAG") <> "") Then
            Else
                If (txtflag.Value = "SHIFTMANUAL") Then
                    GetServicesDtls(Integer.Parse(txtot.Text), Integer.Parse(txtapptno.Text), IIf(rdoip.Checked = True, "I", "O")) 'FETCH OT SERVICES RECORDS : RasikV 20170123


                End If


            End If
            clsGeneral.ShowConsoleTrack("SHIFTMANUAL", "", Page)

            '20211104 end
            Dim objArrFctAptOtSrv = New List(Of clsFctAptOtSrv)   'PRAGYA : SAVE OT-SERVICS
            If Session("objArrOTSrvDtls") IsNot Nothing Then
                objArrOTSrvDtls = Session("objArrOTSrvDtls")
                For i As Integer = 0 To objArrOTSrvDtls.Count - 1
                    Dim objSrv = New clsFctAptOtSrv

                    If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                        If txtpatid.Text <> "" Then
                            objSrv.IpOp = "O"
                            objSrv.PtnNo = Long.Parse(txtpatid.Text)
                            objSrv.IpNo = 0

                        Else
                            objSrv.IpOp = "O"
                            objSrv.PtnNo = 0
                            objSrv.IpNo = 0S

                        End If
                    Else
                        objSrv.IpOp = "I"
                        objSrv.PtnNo = Long.Parse(Session("ActualPtnNo"))
                        objSrv.IpNo = Long.Parse(txtpatid.Text)

                    End If


                    'If txtpatid.Text <> "" Then   '''' Amol 2020-11-07 JSK001-147262	
                    '    objSrv.IpOp = "I"
                    '    objSrv.PtnNo = Long.Parse(Session("ActualPtnNo"))
                    '    objSrv.IpNo = Long.Parse(txtpatid.Text)

                    'Else
                    '    objSrv.IpOp = "O"
                    '    objSrv.PtnNo = 0
                    '    objSrv.IpNo = 0
                    'End If

                    'objSrv.IpOp = "I"
                    'objSrv.PtnNo = Long.Parse(Session("ActualPtnNo"))
                    'objSrv.IpNo = Long.Parse(txtpatid.Text)


                    objSrv.FctCode = Integer.Parse(txtot.Text)
                    objSrv.FctCatCode = 1
                    objSrv.FctMainCode = 1
                    objSrv.ApptNo = Val(txtapptno.Text)
                    objSrv.ChrgCd = objArrOTSrvDtls(i).chrgcd
                    objSrv.SrvCd = objArrOTSrvDtls(i).srvcd
                    objSrv.SrvRmrk = objArrOTSrvDtls(i).SrvDiagnosis
                    objSrv.UserDtTm = dtserverdttm
                    objSrv.UserId = Session("USERID")
                    objArrFctAptOtSrv.Add(objSrv)
                Next

                '---SAVE DATA INTO FCT_APT_OT IF OT_SERVICES ARE SELECTED 
                obj.Diagnosis = objArrOTSrvDtls(0).SrvDiagnosis
                '---SAVE DATA INTO FCT_APT_OT IF OT_SERVICES ARE SELECTED 

            End If



            clsGeneral.ShowConsoleTrack("objArrOTDoctorsDtls", "", Page)



            Dim objArrFctAptOtDoc = New List(Of clsFctAptOtDoc)         'PRAGYA : SAVE OT-SERVICS
            If Session("objArrOTDoctorsDtls") IsNot Nothing Then
                Dim objDocSavedDat = New List(Of clsOtDocDtls)
                objDocSavedDat = Session("objArrOTDoctorsDtls")
                For i As Integer = 0 To objDocSavedDat.Count - 1
                    Dim objDoc = New clsFctAptOtDoc

                    If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                        If txtpatid.Text <> "" Then
                            'objDoc.IpOp = "I" 'commented on 20210809
                            objDoc.IpOp = "O"


                            objDoc.PtnNo = Long.Parse(txtpatid.Text) '11100004006 'Long.Parse(Session("PtnNoChnged"))
                            objDoc.IpNo = 0
                        Else
                            objDoc.IpOp = "O"
                            objDoc.PtnNo = 0
                            objDoc.IpNo = 0
                        End If
                    Else
                        objDoc.IpOp = "I"
                        objDoc.PtnNo = Long.Parse(Session("ActualPtnNo")) '11100004006 'Long.Parse(Session("PtnNoChnged"))
                        objDoc.IpNo = Long.Parse(txtpatid.Text)
                    End If


                    'If txtpatid.Text <> "" Then   '''' Amol 2020-11-07 JSK001-147262	
                    '    objDoc.IpOp = "I"
                    '    objDoc.PtnNo = Long.Parse(Session("ActualPtnNo")) '11100004006 'Long.Parse(Session("PtnNoChnged"))
                    '    objDoc.IpNo = Long.Parse(txtpatid.Text)
                    'Else
                    '    objDoc.IpOp = "O"
                    '    objDoc.PtnNo = 0
                    '    objDoc.IpNo = 0
                    'End If

                    objDoc.FctCode = Integer.Parse(txtot.Text)
                    objDoc.FctCatCode = 1
                    objDoc.FctMainCode = 1
                    objDoc.ApptNo = Val(txtapptno.Text)
                    objDoc.DocCd = objDocSavedDat(i).DoctorCode
                    objDoc.UserDtTm = Today.Date
                    objDoc.UserId = Session("USERID")
                    objDoc.SurgnTypCd = objDocSavedDat(i).SurgnTypCd

                    ''20211204 START
                    'objDoc.NurseName = objDocSavedDat(0).NurseName
                    'objDoc.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd
                    ''20211204 END
                    objArrFctAptOtDoc.Add(objDoc)
                Next
                '---SAVE DATA INTO FCT_APT_OT IF OT_DOCTRS ARE SELECTED 



                'If (txtflag.Value = "SHIFTMANUAL") Then
                '    If (hdnNurseName.Value <> "") Then
                '        obj.NurseName = hdnNurseName.Value


                '    End If

                '    If (hdnANESTYPCD.Value <> "") Then
                '        obj.ANESTYPCD = hdnANESTYPCD.Value
                '    End If



                'Else
                '    obj.NurseName = objDocSavedDat(0).NurseName
                '    obj.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd


                'End If


                If (Session("SHIFTFLAG") <> "") Then

                    obj.NurseName = objDocSavedDat(0).NurseName
                    obj.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd

                Else

                    If (txtflag.Value = "SHIFTMANUAL") Then
                        If (hdnNurseName.Value <> "") Then
                            obj.NurseName = hdnNurseName.Value


                        End If

                        If (hdnANESTYPCD.Value <> "") Then
                            obj.ANESTYPCD = hdnANESTYPCD.Value
                        End If




                    End If


                End If



                '---SAVE DATA INTO FCT_APT_OT IF OT_DOCTRS ARE SELECTED 
            End If

            Dim objArrFctAptOtEmp = New List(Of clsFctAptOtEmp) 'PRAGYA : SAVE OT- EMPLOYEES  : 01-dec-2016
            If Session("objArrOTEmpDtls") IsNot Nothing Then
                Dim objEmpSavedDat = New List(Of clsFctAptOtEmpDtls)
                objEmpSavedDat = Session("objArrOTEmpDtls")
                For i As Integer = 0 To objEmpSavedDat.Count - 1
                    Dim objEmp = New clsFctAptOtEmp


                    If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                        If txtpatid.Text <> "" Then
                            objEmp.IpOp = "O"
                            objEmp.PtnNo = Long.Parse(txtpatid.Text)
                            objEmp.IpNo = 0
                        Else
                            objEmp.IpOp = "O"
                            objEmp.PtnNo = 0
                            objEmp.IpNo = 0
                        End If
                    Else
                        objEmp.IpOp = "I"
                        objEmp.PtnNo = Long.Parse(Session("ActualPtnNo"))
                        objEmp.IpNo = Long.Parse(txtpatid.Text)
                    End If



                    'If txtpatid.Text <> "" Then   '''' Amol 2020-11-07 JSK001-147262	
                    '    objEmp.IpOp = "I"
                    '    objEmp.PtnNo = Long.Parse(Session("ActualPtnNo"))
                    '    objEmp.IpNo = Long.Parse(txtpatid.Text)
                    'Else
                    '    objEmp.IpOp = "O"
                    '    objEmp.PtnNo = 0
                    '    objEmp.IpNo = 0
                    'End If

                    objEmp.FctCode = Integer.Parse(txtot.Text)
                    objEmp.FctCatCode = 1
                    objEmp.FctMainCode = 1
                    objEmp.ApptNo = Val(txtapptno.Text)
                    objEmp.EmpCd = objEmpSavedDat(i).EmpCd
                    objEmp.UserDtTm = Today.Date
                    objEmp.UserId = Session("USERID")
                    objArrFctAptOtEmp.Add(objEmp)
                Next
            End If
            clsGeneral.ShowConsoleTrack("SAVERECORD", "", Page)
            If (OTScheduling.SAVERECORD(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"),
                                        Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), day,
                                        CDate(txtdate.Text), Integer.Parse(txtreqno.Value), obj,
                                        objFCT_APT_MAIN, objFCTAPTREQ, objFCTSCH, bkngstatus, objArrFctAptOtSrv,
                                        objArrFctAptOtDoc, objArrFctAptOtEmp, AptNo)) Then

                btnarr = Nothing
                btnarrcnt = 0

                Getsessions()
                rdoip.Checked = True
                rdoop.Checked = False



                If Session("EditMode") = "true" Then
                    Msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 6), "", Page)
                    Msg += String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 49), "", Page)
                    ViewState("APPTNO") = AptNo.ToString()
                    clearSession()      'Aarti 27 Oct 2020

                    ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "printconfirmation('" & Msg & "');", True)
                Else
                    Msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 6), "", Page)
                    Msg += String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 49), "", Page)
                    'shital 20190921 
                    ViewState("APPTNO") = AptNo.ToString()
                    clearSession()      'Aarti 27 Oct 2020
                    Getsessions()

                    Session("OTDateSelected") = txtdate.Text
                    ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "printconfirmation('" & Msg & "');", True)
                End If
                SAVENEWBOOKING = True

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

                btnarr = Nothing
                btnarrcnt = 0
                ClearAll()
                Getsessions()
                rdoip.Checked = True
                rdoop.Checked = False
                'clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 39), "", Page)
            End If

        Catch ex As Exception
            SAVENEWBOOKING = False
        End Try
        Return SAVENEWBOOKING
    End Function

    Public Function EDITBOOKING() As Boolean
        Try
            strErrMsg = New List(Of String)
            chrErrFlg = "N"

            If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
                Exit Function
            End If

            Dim dtserverdttm As Date = clsGeneral.getdate()
            GetSlotsCount()

            'Dim i As String = txtapptno.Text
            'Dim pstartime As Date = CDate(txtstrttm1.Text)
            'Dim pendime As Date = CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + txtmins.Text)
            'Dim pslots As Long = CalNoofSlotsRequired(pstartime, pendime, lvSlotDur)

            Dim tomins As String = txtmins.Text

            If (Integer.Parse(txthrs.Text) = 0) Then
                If (Integer.Parse(tomins) <> 0) Then
                    If (Integer.Parse(tomins) < lvSlotDur) Then
                        tomins = lvSlotDur.ToString()
                        txtmins.Text = tomins
                    End If
                End If
            End If

            If (Integer.Parse(txthrs.Text) = 0) Then
                If (Integer.Parse(tomins) = 0) Then
                    tomins = lvSlotDur.ToString()
                    txtmins.Text = tomins
                    ' If
                End If
            End If

            If (Integer.Parse(tomins) > lvSlotDur) Then
                Dim tem As Integer
                tem = Integer.Parse(tomins) + (lvSlotDur - (Integer.Parse(tomins) - lvSlotDur))
                tomins = tem.ToString()
                txtmins.Text = tomins
            End If

            Dim pstartime As Date = CDate(txtstrttm1.Text)
            Dim pendime As Date = CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + tomins)
            Dim actstartime As Date = AdjustDate(pstartime, True)
            Dim actpendime As Date = AdjustDate(pendime, False)
            Dim boolmsg As Boolean = False

            If pstartime <> actstartime Then
                boolmsg = True
                actpendime = AdjustDate(CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + tomins))
                Dim actpendime1 As Date = AdjustDate(actpendime, False)
                If actpendime <> actpendime1 Then
                    actpendime = actpendime1
                End If
            End If

            Dim actslots As Long = CalNoofSlotsRequired(actstartime, actpendime, lvSlotDur)
            pstartime = actstartime
            pendime = actpendime

            If (CheckSlotAvailable(pstartime, pendime)) Then
            Else
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "", Page)
                btnarr = Nothing
                btnarrcnt = 0
                ClearAll()
                Getsessions()
                Exit Function
            End If

            Dim pslots As Long = CalNoofSlotsRequired(pstartime, pendime, lvSlotDur)

            If (pslots = 0) Then
                pslots = 1
            End If

            EDITBOOKING = False
            Dim obj As New clsFCTAPTOT
            obj.FCTCODE = Integer.Parse(txtot.Text)
            obj.APTMDATE = CDate(txtdate.Text)
            obj.DOCCD = Integer.Parse(txtdctid.Text)
            obj.ISPATIENT = IIf(txtpatid.Text <> "", True, False)
            ' obj.IPOP = "I"
            If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                If txtpatid.Text <> "" Then
                    obj.PTNNO = Long.Parse(txtpatid.Text)
                    obj.IPOP = "O"
                Else
                    obj.PTNNO = 0
                    obj.IPOP = "O"
                End If
            Else
                obj.PTNNO = Long.Parse(txtpatid.Text)
                obj.IPOP = "I"
            End If

            obj.PTNNO = Long.Parse(txtpatid.Text)
            obj.PTNLNGNM = txtpatname.Text
            obj.APTMTMFROM = pstartime.Hour * 100 + pstartime.Minute
            obj.APTMTMTO = pendime.Hour * 100 + pendime.Minute
            obj.NOOFSLOTSUSED = pslots
            obj.DURATION = pslots * lvSlotDur
            obj.ISPERFORMED = False
            obj.ISPOSTED = False
            obj.CRTUSRID = Session("USERID")
            obj.CRTDTTM = dtserverdttm
            obj.FLG = "E"
            obj.APPTRMRK = txtRmrk.Text.Replace("'", "")
            obj.IsOfficePrmsnGiven = chkIsOffPerm.Checked '#Trupti 14 JUN 2021
            obj.OfficePrmsnRmrk = txtoffPermRmrk.Text '#Trupti 14 JUN 2021
            obj.OfficePrmsnByUsrID = Session("USERID") '#Trupti 14 JUN 2021
            obj.OfficePrmsnDtTm = dtserverdttm '#Trupti 14 JUN 2021

            'obj.BOOKING_TYPE = IIf(drpBookingType.SelectedValue = "SELECT", 0, Convert.ToInt32(drpBookingType.SelectedValue))

            If (drpBookingType.SelectedValue <> "SELECT") Then
                obj.BOOKING_TYPE = Convert.ToInt32(drpBookingType.SelectedValue)

            Else
                obj.BOOKING_TYPE = 0
            End If
            Dim objFCT_APT_MAIN As New clsFCTAPTMAIN
            objFCT_APT_MAIN.FCTCODE = Integer.Parse(txtot.Text)
            objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
            objFCT_APT_MAIN.APTMFROMHRS = pstartime.Hour
            objFCT_APT_MAIN.APTMFROMMIN = pstartime.Minute
            objFCT_APT_MAIN.APTMTOHRS = pendime.Hour
            objFCT_APT_MAIN.APTMTOMNS = pendime.Minute
            objFCT_APT_MAIN.APTMACTFROMHRS = 0
            objFCT_APT_MAIN.APTMACTFROMMIN = 0
            objFCT_APT_MAIN.APTMACTTOHRS = 0
            objFCT_APT_MAIN.APTMACTTOMNS = 0





            'objFCT_APT_MAIN.pIPOPFLG = "I"




            If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                If txtpatid.Text <> "" Then
                    objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
                    objFCT_APT_MAIN.pIPOPFLG = "O"
                Else
                    objFCT_APT_MAIN.IPOP = 0
                    objFCT_APT_MAIN.pIPOPFLG = "O"
                End If
            Else
                objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
                objFCT_APT_MAIN.pIPOPFLG = "I"
            End If
            objFCT_APT_MAIN.BookFor = IIf(txtpatid.Text.Trim <> "", "P", "O")
            objFCT_APT_MAIN.UPDUSRID = Session("USERID")
            objFCT_APT_MAIN.UPDTTTM = dtserverdttm

            Dim objFCTSCH As New clsFCTSCH
            objFCTSCH.IPOPFLG = "I"
            objFCTSCH.IPOPNO = Long.Parse(txtpatid.Text)
            objFCTSCH.FCTCODE = Integer.Parse(txtot.Text)
            objFCTSCH.FctCatCode = 1
            objFCTSCH.FctMainCode = 1
            objFCTSCH.STRTHR = pstartime.Hour
            objFCTSCH.STRTMIN = pstartime.Minute
            objFCTSCH.ENDTHR = pendime.Hour
            objFCTSCH.ENDTMIN = pendime.Minute
            objFCTSCH.SCHDATE = CDate(txtdate.Text)

            Dim objFCTAPTREQ As New clsFCTAPTREQ
            objFCTAPTREQ.FCTCODE = Integer.Parse(txtot.Text)
            objFCTAPTREQ.REQNO = 1
            objFCTAPTREQ.CRTUSRID = Session("USERID")
            objFCTAPTREQ.CRTDTTM = dtserverdttm
            objFCTAPTREQ.UPDUSRID = Session("USERID")
            objFCTAPTREQ.UPDDTTM = dtserverdttm
            objFCTAPTREQ.IPOPNO = Long.Parse(txtpatid.Text)
            Dim day As Integer = Weekday(txtdate.Text, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)
            If (txtreqno.Value = "") Then
                txtreqno.Value = 0
            End If

            Dim objArrFctAptOtSrv = New List(Of clsFctAptOtSrv)
            If Session("objArrOTSrvDtls") IsNot Nothing Then
                objArrOTSrvDtls = Session("objArrOTSrvDtls")
                If objArrOTSrvDtls.Count > 0 Then
                    For i As Integer = 0 To objArrOTSrvDtls.Count - 1
                        Dim objSrv = New clsFctAptOtSrv
                        'objSrv.IpOp = "I"
                        'objSrv.PtnNo = Long.Parse(Session("ActualPtnNo"))
                        'objSrv.IpNo = Long.Parse(txtpatid.Text)

                        If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                            If txtpatid.Text <> "" Then
                                objSrv.IpOp = "O"
                                objSrv.PtnNo = Long.Parse(txtpatid.Text)
                                objSrv.IpNo = 0

                            Else
                                objSrv.IpOp = "O"
                                objSrv.PtnNo = 0
                                objSrv.IpNo = 0

                            End If
                        Else
                            objSrv.IpOp = "I"
                            objSrv.PtnNo = Long.Parse(Session("ActualPtnNo"))
                            objSrv.IpNo = Long.Parse(txtpatid.Text)

                        End If





                        objSrv.FctCode = Integer.Parse(txtot.Text)
                        objSrv.FctCatCode = 1
                        objSrv.FctMainCode = 1
                        objSrv.ApptNo = Integer.Parse(txtapptno.Text)
                        objSrv.ChrgCd = objArrOTSrvDtls(i).chrgcd
                        objSrv.SrvCd = objArrOTSrvDtls(i).srvcd
                        objSrv.SrvRmrk = objArrOTSrvDtls(i).SrvDiagnosis
                        objSrv.UserDtTm = dtserverdttm
                        objSrv.UserId = Session("USERID")
                        objArrFctAptOtSrv.Add(objSrv)
                    Next
                    '---SAVE DATA INTO FCT_APT_OT IF OT_SERVICES ARE SELECTED 
                    obj.Diagnosis = objArrOTSrvDtls(0).SrvDiagnosis
                    '---SAVE DATA INTO FCT_APT_OT IF OT_SERVICES ARE SELECTED 
                End If

            End If

            Dim objArrFctAptOtDoc = New List(Of clsFctAptOtDoc)
            If Session("objArrOTDoctorsDtls") IsNot Nothing Then
                Dim objDocSavedDat = New List(Of clsOtDocDtls)
                objDocSavedDat = Session("objArrOTDoctorsDtls")
                If objDocSavedDat.Count > 0 Then
                    For i As Integer = 0 To objDocSavedDat.Count - 1
                        Dim objDoc = New clsFctAptOtDoc
                        'objDoc.IpOp = "I"
                        'objDoc.PtnNo = Long.Parse(Session("ActualPtnNo"))
                        'objDoc.IpNo = Long.Parse(txtpatid.Text)



                        If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                            If txtpatid.Text <> "" Then
                                'objDoc.IpOp = "I" 'commented on 20210809
                                objDoc.IpOp = "O"


                                objDoc.PtnNo = Long.Parse(txtpatid.Text) '11100004006 'Long.Parse(Session("PtnNoChnged"))
                                objDoc.IpNo = 0
                            Else
                                objDoc.IpOp = "O"
                                objDoc.PtnNo = 0
                                objDoc.IpNo = 0
                            End If
                        Else
                            objDoc.IpOp = "I"
                            objDoc.PtnNo = Long.Parse(Session("ActualPtnNo")) '11100004006 'Long.Parse(Session("PtnNoChnged"))
                            objDoc.IpNo = Long.Parse(txtpatid.Text)
                        End If
                        objDoc.FctCode = Integer.Parse(txtot.Text)
                        objDoc.FctCatCode = 1
                        objDoc.FctMainCode = 1
                        objDoc.ApptNo = Val(txtapptno.Text)
                        objDoc.DocCd = objDocSavedDat(i).DoctorCode
                        objDoc.UserDtTm = dtserverdttm
                        objDoc.UserId = Session("USERID")
                        objDoc.SurgnTypCd = objDocSavedDat(i).SurgnTypCd

                        ''20211204 START
                        'objDoc.NurseName = objDocSavedDat(0).NurseName
                        'objDoc.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd
                        ''20211204 END
                        objArrFctAptOtDoc.Add(objDoc)
                    Next
                    '---SAVE DATA INTO FCT_APT_OT IF OT_DOCTRS ARE SELECTED 
                    obj.NurseName = objDocSavedDat(0).NurseName
                    obj.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd
                End If

            End If

            Dim objArrFctAptOtEmp = New List(Of clsFctAptOtEmp) 'PRAGYA : SAVE OT- EMPLOYEES  : 01-dec-2016
            If Session("objArrOTEmpDtls") IsNot Nothing Then
                Dim objEmpSavedDat = New List(Of clsFctAptOtEmpDtls)
                objEmpSavedDat = Session("objArrOTEmpDtls")
                If objEmpSavedDat.Count > 0 Then
                    For i As Integer = 0 To objEmpSavedDat.Count - 1
                        Dim objEmp = New clsFctAptOtEmp
                        'objEmp.IpOp = "I"
                        'objEmp.PtnNo = Long.Parse(Session("ActualPtnNo"))
                        'objEmp.IpNo = Long.Parse(txtpatid.Text)




                        If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                            If txtpatid.Text <> "" Then
                                objEmp.IpOp = "O"
                                objEmp.PtnNo = Long.Parse(txtpatid.Text)
                                objEmp.IpNo = 0
                            Else
                                objEmp.IpOp = "O"
                                objEmp.PtnNo = 0
                                objEmp.IpNo = 0
                            End If
                        Else
                            objEmp.IpOp = "I"
                            objEmp.PtnNo = Long.Parse(Session("ActualPtnNo"))
                            objEmp.IpNo = Long.Parse(txtpatid.Text)
                        End If



                        objEmp.FctCode = Integer.Parse(txtot.Text)
                        objEmp.FctCatCode = 1
                        objEmp.FctMainCode = 1
                        objEmp.ApptNo = Val(txtapptno.Text)
                        objEmp.EmpCd = objEmpSavedDat(i).EmpCd
                        objEmp.UserDtTm = Today.Date
                        objEmp.UserId = Session("USERID")
                        objArrFctAptOtEmp.Add(objEmp)
                    Next
                End If

            End If

            If (OTScheduling.EDITERECORD(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), day, CDate(txtdate.Text), Integer.Parse(txtreqno.Value), Integer.Parse(txtapptno.Text), obj, objFCT_APT_MAIN, objFCTAPTREQ, objFCTSCH, objArrFctAptOtSrv, objArrFctAptOtDoc, objArrFctAptOtEmp)) Then
                EDITBOOKING = True

                Msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 36), "txtapptno", Page)

                Msg += String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 49), "", Page)
                ViewState("APPTNO") = txtapptno.Text 'shital 20190922

                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "printconfirmation('" & Msg & "');", True)
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
            btnarr = Nothing



            btnarrcnt = 0
            Getsessions()
            rdoip.Checked = True
            rdoop.Checked = False
        Catch ex As Exception
            EDITBOOKING = False
        End Try
        Return EDITBOOKING
    End Function

    Public Function CANCELBOOKING() As Boolean
        Try
            CANCELBOOKING = False
            txtapptno.Enabled = True

            Dim dtserverdttm As Date = clsGeneral.getdate()

            Dim objclsFCTAPTCNCL As New clsFCTAPTCNCL
            objclsFCTAPTCNCL.FCTCODE = Integer.Parse(txtot.Text)
            objclsFCTAPTCNCL.APPTNO = Integer.Parse(txtapptno.Text)
            objclsFCTAPTCNCL.ISSHIFTED = False
            objclsFCTAPTCNCL.CNCLUSRID = Session("USERID")
            objclsFCTAPTCNCL.CNCLDTTM = dtserverdttm
            objclsFCTAPTCNCL.APPTRMRK = txtRmrk.Text
            objclsFCTAPTCNCL.CNCL_RMRK = txtCnclRmrk.Text 'RasikV 20210601

            Dim obj As New clsFCTAPTOT
            obj.FCTCODE = Integer.Parse(txtot.Text)
            obj.APPTNO = Integer.Parse(txtapptno.Text)

            Dim objFCT_APT_MAIN As New clsFCTAPTMAIN
            objFCT_APT_MAIN.FCTCODE = Integer.Parse(txtot.Text)
            objFCT_APT_MAIN.FctCatCode = 1
            objFCT_APT_MAIN.FctMainCode = 1
            objFCT_APT_MAIN.UPDUSRID = Session("USERID")
            objFCT_APT_MAIN.UPDTTTM = dtserverdttm
            objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
            objFCT_APT_MAIN.APPTNO = Integer.Parse(txtapptno.Text)

            Dim objFCTSCH As New clsFCTSCH
            objFCTSCH.FCTCODE = Integer.Parse(txtot.Text)
            objFCTSCH.FctCatCode = 1
            objFCTSCH.FctMainCode = 1
            objFCTSCH.SCHDATE = CDate(txtdate.Text)
            objFCTSCH.APPTNO = Integer.Parse(txtapptno.Text)

            If (OTScheduling.CNCLRECORD(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), Integer.Parse(txtapptno.Text), obj, objFCT_APT_MAIN, objFCTSCH, objclsFCTAPTCNCL)) Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 37), "txtapptno", Page)
                CANCELBOOKING = True
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
            btnarr = Nothing
            btnarrcnt = 0
            ClearAll()
            Getsessions()
            rdoip.Checked = True
            rdoop.Checked = False
        Catch ex As Exception
            CANCELBOOKING = False
        End Try
        Return CANCELBOOKING
    End Function

    Public Function ShiftRecord() As Boolean
        Try
            ShiftRecord = False
            Dim objclsFCTAPTCNCL As New clsFCTAPTCNCL
            Dim dtserverdttm As Date = clsGeneral.getdate()
            objclsFCTAPTCNCL.FCTCODE = Integer.Parse(txtot.Text)
            objclsFCTAPTCNCL.APPTNO = Integer.Parse(txtapptno.Text)
            objclsFCTAPTCNCL.ISSHIFTED = False
            objclsFCTAPTCNCL.CNCLUSRID = Session("USERID")
            objclsFCTAPTCNCL.CNCLDTTM = dtserverdttm
            Dim objFCTAPTREQ As New clsFCTAPTREQ
            objFCTAPTREQ.REQDATE = dtserverdttm.Date
            objFCTAPTREQ.FCTCODE = Integer.Parse(txtot.Text)
            objFCTAPTREQ.FORSPCFCFCT = True
            objFCTAPTREQ.APPTNO = Integer.Parse(txtapptno.Text)
            objFCTAPTREQ.ISSHIFTED = True
            objFCTAPTREQ.NEWFCTCODE = 0
            objFCTAPTREQ.NEWAPPTNO = 0
            objFCTAPTREQ.CRTUSRID = Session("USERID")
            objFCTAPTREQ.CRTDTTM = dtserverdttm
            Dim obj As New clsFCTAPTOT
            obj.FCTCODE = Integer.Parse(txtot.Text)
            obj.APPTNO = Integer.Parse(txtapptno.Text)
            Dim objFCT_APT_MAIN As New clsFCTAPTMAIN
            objFCT_APT_MAIN.FCTCODE = Integer.Parse(txtot.Text)
            objFCT_APT_MAIN.FctCatCode = 1
            objFCT_APT_MAIN.FctMainCode = 1
            objFCT_APT_MAIN.UPDUSRID = Session("USERID")
            objFCT_APT_MAIN.UPDTTTM = dtserverdttm
            objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
            objFCT_APT_MAIN.APPTNO = Integer.Parse(txtapptno.Text)
            Dim objFCTSCH As New clsFCTSCH
            objFCTSCH.FCTCODE = Integer.Parse(txtot.Text)
            objFCTSCH.FctCatCode = 1
            objFCTSCH.FctMainCode = 1
            objFCTSCH.SCHDATE = CDate(txtdate.Text)
            objFCTSCH.APPTNO = Integer.Parse(txtapptno.Text)

            GetServicesDtls(Integer.Parse(txtot.Text), Integer.Parse(txtapptno.Text), IIf(rdoip.Checked = True, "I", "O")) 'FETCH OT SERVICES RECORDS : RasikV 20170123

            Dim objArrFctAptOtSrv = New List(Of clsFctAptOtSrv) 'SAVE OT SERVICES RECORDS : RasikV 20170123
            If ViewState("objArrOTSrvDtls") IsNot Nothing Then
                objArrOTSrvDtls = ViewState("objArrOTSrvDtls")
                For i As Integer = 0 To objArrOTSrvDtls.Count - 1
                    Dim objSrv = New clsFctAptOtSrv
                    objSrv.IpOp = "I"
                    objSrv.PtnNo = Long.Parse(ViewState("ActualPtnNo"))
                    objSrv.IpNo = Long.Parse(txtpatid.Text)
                    objSrv.FctCode = Integer.Parse(txtot.Text)
                    objSrv.FctCatCode = 1
                    objSrv.FctMainCode = 1
                    objSrv.ApptNo = Integer.Parse(txtapptno.Text)
                    objSrv.ChrgCd = objArrOTSrvDtls(i).chrgcd
                    objSrv.SrvCd = objArrOTSrvDtls(i).srvcd
                    objSrv.SrvRmrk = objArrOTSrvDtls(i).SrvDiagnosis
                    objSrv.UserDtTm = dtserverdttm
                    objSrv.UserId = Session("USERID")
                    objArrFctAptOtSrv.Add(objSrv)
                Next
                '---SAVE DATA INTO FCT_APT_OT IF OT_SERVICES ARE SELECTED
                obj.Diagnosis = objArrOTSrvDtls(0).SrvDiagnosis
                '---SAVE DATA INTO FCT_APT_OT IF OT_SERVICES ARE SELECTED 
            End If

            Dim objArrFctAptOtDoc = New List(Of clsFctAptOtDoc) 'SAVE OT SERVICES RECORDS : RasikV 20170123
            If ViewState("objArrOTDoctorsDtls") IsNot Nothing Then
                Dim objDocSavedDat = New List(Of clsOtDocDtls)
                objDocSavedDat = ViewState("objArrOTDoctorsDtls")
                For i As Integer = 0 To objDocSavedDat.Count - 1
                    Dim objDoc = New clsFctAptOtDoc
                    objDoc.IpOp = "I"
                    objDoc.PtnNo = Long.Parse(ViewState("ActualPtnNo"))
                    objDoc.IpNo = Long.Parse(txtpatid.Text)
                    objDoc.FctCode = Integer.Parse(txtot.Text)
                    objDoc.FctCatCode = 1
                    objDoc.FctMainCode = 1
                    objDoc.ApptNo = Integer.Parse(txtapptno.Text)
                    objDoc.DocCd = objDocSavedDat(i).DoctorCode
                    objDoc.UserDtTm = Today.Date
                    objDoc.UserId = Session("USERID")
                    ''20211204 START
                    'objDoc.NurseName = objDocSavedDat(0).NurseName
                    'objDoc.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd
                    ''20211204 END
                    objArrFctAptOtDoc.Add(objDoc)
                Next
                '---SAVE DATA INTO FCT_APT_OT IF OT_DOCTRS ARE SELECTED 
                obj.NurseName = objDocSavedDat(0).NurseName
                obj.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd


                'shital 20211204 start

                objFCTAPTREQ.NurseName = objDocSavedDat(0).NurseName
                objFCTAPTREQ.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd


                objFCTAPTREQ.APPTRMRK = txtRmrk.Text


                If (drpBookingType.SelectedValue <> "SELECT") Then
                    objFCTAPTREQ.BOOKING_TYPE = Convert.ToInt32(drpBookingType.SelectedValue)

                Else
                    objFCTAPTREQ.BOOKING_TYPE = 0
                End If
                'end


                '---SAVE DATA INTO FCT_APT_OT IF OT_DOCTRS ARE SELECTED 
            End If

            Dim objArrFctAptOtEmp = New List(Of clsFctAptOtEmp) 'SAVE OT SERVICES RECORDS : RasikV 20170123
            If ViewState("objArrOTEmpDtls") IsNot Nothing Then
                Dim objEmpSavedDat = New List(Of clsFctAptOtEmpDtls)
                objEmpSavedDat = ViewState("objArrOTEmpDtls")
                For i As Integer = 0 To objEmpSavedDat.Count - 1
                    Dim objEmp = New clsFctAptOtEmp
                    objEmp.IpOp = "I"
                    objEmp.PtnNo = Long.Parse(ViewState("ActualPtnNo"))
                    objEmp.IpNo = Long.Parse(txtpatid.Text)
                    objEmp.FctCode = Integer.Parse(txtot.Text)
                    objEmp.FctCatCode = 1
                    objEmp.FctMainCode = 1
                    objEmp.ApptNo = Integer.Parse(txtapptno.Text)
                    objEmp.EmpCd = objEmpSavedDat(i).EmpCd
                    objEmp.UserDtTm = Today.Date
                    objEmp.UserId = Session("USERID")
                    objArrFctAptOtEmp.Add(objEmp)
                Next
            End If

            'If (OTScheduling.SHIFTRECORD(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), Integer.Parse(txtapptno.Text), obj, objFCT_APT_MAIN, objFCTAPTREQ, objFCTSCH, objclsFCTAPTCNCL)) Then

            If (OTScheduling.SHIFTRECORD(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), Integer.Parse(txtapptno.Text), obj, objFCT_APT_MAIN, objFCTAPTREQ, objFCTSCH, objclsFCTAPTCNCL, objArrFctAptOtSrv, objArrFctAptOtDoc, objArrFctAptOtEmp)) Then 'RasikV 20170123
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 38), "", Page)

                btnarr = Nothing
                btnarrcnt = 0
                ClearAll()
                Getsessions()
                rdoip.Checked = True
                rdoop.Checked = False

                ShiftRecord = True
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

            'Response.Redirect(Request.RawUrl)

            btnarr = Nothing
            btnarrcnt = 0
            ClearAll()
            Getsessions()
            rdoip.Checked = True
            rdoop.Checked = False
        Catch ex As Exception
            ShiftRecord = False
        End Try
        Return ShiftRecord
    End Function

    Public Function ShiftNowRecord() As Boolean
        Try
            Dim dtserverdttm As Date = clsGeneral.getdate()
            GetSlotsCount()
            Dim pstartime As Date = CDate(txtstrttm1.Text)
            Dim pendime As Date = CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + txtmins.Text)
            Dim pslots As Long = CalNoofSlotsRequired(pstartime, pendime, lvSlotDur)
            ShiftNowRecord = False
            Dim obj As New clsFCTAPTOT
            obj.FCTCODE = Integer.Parse(txtot.Text)
            obj.APTMDATE = CDate(txtdate.Text)
            obj.DOCCD = Integer.Parse(txtdctid.Text)
            obj.ISPATIENT = IIf(txtpatid.Text <> "", True, False)
            obj.IPOP = "I"
            obj.PTNNO = Long.Parse(txtpatid.Text)
            obj.PTNLNGNM = txtpatname.Text
            obj.APTMTMFROM = pstartime.Hour * 100 + pstartime.Minute
            obj.APTMTMTO = pendime.Hour * 100 + pendime.Minute
            obj.NOOFSLOTSUSED = pslots
            obj.DURATION = pslots * lvSlotDur
            obj.ISPERFORMED = False
            obj.ISPOSTED = False
            obj.CRTUSRID = Session("USERID")
            obj.CRTDTTM = dtserverdttm
            obj.FLG = "A"
            Dim objFCT_APT_MAIN As New clsFCTAPTMAIN
            objFCT_APT_MAIN.FCTCODE = Integer.Parse(txtot.Text)
            objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
            objFCT_APT_MAIN.APTMDATE = CDate(txtdate.Text)
            objFCT_APT_MAIN.APTMSTS = 1 '<--BOOKING ( CD_DCD TYP = 404  )
            objFCT_APT_MAIN.REQNO = 0
            objFCT_APT_MAIN.REQSRNO = 0
            objFCT_APT_MAIN.APTMFROMHRS = pstartime.Hour
            objFCT_APT_MAIN.APTMFROMMIN = pstartime.Minute
            objFCT_APT_MAIN.APTMTOHRS = pendime.Hour
            objFCT_APT_MAIN.APTMTOMNS = pendime.Minute
            objFCT_APT_MAIN.APTMACTFROMHRS = 0
            objFCT_APT_MAIN.APTMACTFROMMIN = 0
            objFCT_APT_MAIN.APTMACTTOHRS = 0
            objFCT_APT_MAIN.APTMACTTOMNS = 0
            'objFCT_APT_MAIN.pIPOPFLG = "I"




            If rdbPatientType.SelectedValue = "O" Then '''' Amol 2020-11-07 JSK001-147262	
                If txtpatid.Text <> "" Then
                    objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
                    objFCT_APT_MAIN.pIPOPFLG = "O"
                Else
                    objFCT_APT_MAIN.IPOP = 0
                    objFCT_APT_MAIN.pIPOPFLG = "O"
                End If
            Else
                objFCT_APT_MAIN.IPOP = Long.Parse(txtpatid.Text)
                objFCT_APT_MAIN.pIPOPFLG = "I"
            End If


            objFCT_APT_MAIN.BookFor = IIf(txtpatid.Text.Trim <> "", "P", "O")
            objFCT_APT_MAIN.WARDNO = 0 '<--
            objFCT_APT_MAIN.PTNCLSCD = 0 '<--
            objFCT_APT_MAIN.BEDNO = "" '<--
            objFCT_APT_MAIN.APTMREFBY = ""
            objFCT_APT_MAIN.ICDGRPCD = ""
            objFCT_APT_MAIN.ICDCD = ""
            objFCT_APT_MAIN.DR1CODE = 0
            objFCT_APT_MAIN.DR2CODE = 0
            objFCT_APT_MAIN.DR3CODE = 0
            objFCT_APT_MAIN.DR4CODE = 0
            objFCT_APT_MAIN.ANAS1CODE = 0
            objFCT_APT_MAIN.ANAS2CODE = 0
            objFCT_APT_MAIN.ANAS3CODE = 0
            objFCT_APT_MAIN.SURGNOTE1 = ""
            objFCT_APT_MAIN.SURGNOTE2 = ""
            objFCT_APT_MAIN.OPRSTFTYPE1 = 0
            objFCT_APT_MAIN.TYPE1NOS = 0
            objFCT_APT_MAIN.OPRSTFTYPE2 = 0
            objFCT_APT_MAIN.TYPE2NOS = 0
            objFCT_APT_MAIN.OPRSTFTYPE3 = 0
            objFCT_APT_MAIN.TYPE3NOS = 0
            objFCT_APT_MAIN.OPRSTFTYPE4 = 0
            objFCT_APT_MAIN.TYPE4NOS = 0
            objFCT_APT_MAIN.SPLINST = 0
            objFCT_APT_MAIN.CRTDTTM = dtserverdttm
            objFCT_APT_MAIN.CRTUSRID = Session("USERID")
            objFCT_APT_MAIN.CRTDTTM = dtserverdttm
            objFCT_APT_MAIN.UPDUSRID = Session("USERID")
            objFCT_APT_MAIN.PTNFSTNAME = IIf(Split(txtpatname.Text, " ").Length >= 2, Split(txtpatname.Text, " ")(2), "") '"" '<--
            objFCT_APT_MAIN.PTNLSTNAME = IIf(Split(txtpatname.Text, " ").Length >= 3, Split(txtpatname.Text, " ")(3), "") '"" '<--
            objFCT_APT_MAIN.PTNMIDNAME = IIf(Split(txtpatname.Text, " ").Length >= 1, Split(txtpatname.Text, " ")(1), "") '"" '<--
            Dim objFCTSCH As New clsFCTSCH
            objFCTSCH.FCTCODE = Integer.Parse(txtot.Text)
            objFCTSCH.FctCatCode = 1
            objFCTSCH.FctMainCode = 1
            objFCTSCH.SCHDATE = CDate(txtdate.Text)
            Dim objFCTAPTREQ As New clsFCTAPTREQ
            objFCTAPTREQ.FCTCODE = Integer.Parse(txtot.Text)
            objFCTAPTREQ.REQNO = 1
            Dim objclsFCTAPTCNCL As New clsFCTAPTCNCL
            objclsFCTAPTCNCL.FCTCODE = Integer.Parse(txtot.Text)
            objclsFCTAPTCNCL.APPTNO = txtapptno.Text
            objclsFCTAPTCNCL.ISSHIFTED = False
            objclsFCTAPTCNCL.CNCLUSRID = Session("USERID")
            objclsFCTAPTCNCL.CNCLDTTM = dtserverdttm
        Catch ex As Exception
            ShiftNowRecord = False
        End Try
        Return ShiftNowRecord
    End Function

    Public Function CalNoofSlotsRequired(ByVal pstartime As Date, ByVal pendime As Date, ByVal pSlotDur As Long) As Long
        If txtstrttime.Text.Trim <> "" And pSlotDur <> 0 Then
            Dim psttmmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(txtstrttime.Text), pstartime)
            Dim pentmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(txtstrttime.Text), pendime)
            Dim pslots As Long = System.Math.Floor((pentmins - psttmmins) / pSlotDur)
            Return pslots
        Else
            Return 0
        End If
    End Function

    Public Function GetSlotsCount() As Long
        Try
            lvSessDur = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(txtstrttime.Text), CDate(txtendtime.Text))
            If lv_fct_slot_prd_hrs <> 0 Then
                lvSlotDur = (lv_fct_slot_prd_hrs * 60) + lv_fct_slot_prd_mins
            Else
                lvSlotDur = lv_fct_slot_prd_mins
            End If
            GetSlotsCount = System.Math.Floor(lvSessDur / lvSlotDur)
        Catch ex As Exception
            GetSlotsCount = 0
        End Try
    End Function

    Public Sub DrawTimeControl()
        Dim bmp As New Bitmap(1500, 2500)
        Dim g As Graphics = System.Drawing.Graphics.FromImage(bmp)
        DrawTimeScale(g)
        CustomPaint(g, bmp)
        bmp.Dispose()
    End Sub

    Public Sub CustomPaint(ByVal g As Graphics, ByVal bmp As Bitmap)
        Try
            DrawSession(g, sess)
            g.Flush()
            Dim img_converter As New ImageConverter()
            Dim bytes As Byte() = DirectCast(img_converter.ConvertTo(bmp, GetType(Byte())), Byte())
            Dim dtm As String = Date.Today.ToString().Replace("/", "")
            Dim dtm1 As String = dtm.Replace(":", "")
            Dim random As New Random()
            Dim ran As String = Convert.ToString(random.[Next](10, 2000))

            'Response.BinaryWrite(bytes)
            'Dim img2 As Byte() = Nothing
            'img2 = bytes
            'Response.BinaryWrite(bytes)
            'File.WriteAllBytes(Server.MapPath("~/Images/" & dtm1 + ran & ".jpeg"), bytes)

            Session("img123") = Nothing

            'Session("~/Images/" & dtm1 + ran & ".jpeg") = bytes

            Session("img123") = bytes

            'txtimgsession.Value = "~/Images/" & dtm1 + ran & ".jpeg"
            'pnl001.BackColor = Color.White
            'pnl001.BackImageUrl = ("~/Images/" & dtm1 + ran & ".jpeg")
            'pnl001.Attributes.Add("style", "background-repeat:no-repeat")

        Catch ex As Exception
            Dim i As Integer = 45
        End Try
    End Sub

    Public Sub DrawTimeScale(ByVal g As Graphics)
        Try
            If cmpscale = False Then
                SessionStartTIme = CDate(txtstrttime.Text)
                SessionEndTIme = CDate(txtendtime.Text)
                sttm = CDate(Strings.Right("00" & SessionStartTIme.Hour, 2) & ":00")
                endtm = CDate(Strings.Right("00" & SessionEndTIme.Hour, 2) & ":00")
                If SessionEndTIme.Minute <> 0 Then
                    endtm = endtm.AddHours(1)
                End If
                sltcnt = DateDiff(DateInterval.Minute, sttm, endtm) / sltdur
            Else
                sttm = CDate("00:00")
                endtm = sttm.AddHours(23).AddMinutes(59)
                sltcnt = DateDiff(DateInterval.Minute, sttm, endtm) / sltdur
            End If
            If sltcnt <> 0 Then
                Dim i As Integer = Integer.Parse(pnl001.Width.ToString().Replace("px", "").Trim()) '+ 200
                Dim j As Integer = 30
                scalewidth = i * 0.9
                leftmargin = (i - scalewidth) / 2
                divwt = scalewidth / sltcnt
                Dim b As Brush = New SolidBrush(TimeScaleBackcolor)
                g.FillRectangle(b, 0, 0, i, divht)
                If cmpscale = False Then
                    b = New SolidBrush(BookingAreaBackcolor)
                Else
                    b = New SolidBrush(Color.LightGray)
                End If
                g.FillRectangle(b, 0, 30, i, Integer.Parse(pnl001.Height.ToString().Replace("px", "").Trim()) - 30)
                g.DrawLine(Pens.Black, 0, 30, i, 30)
                Dim k As Integer = 0
                Dim tmp As Date
                tmp = sttm
                While tmp <= endtm
                    Dim drawFont As New Font("Arial", 8, FontStyle.Regular)
                    Dim drawBrush As New SolidBrush(Color.Blue)

                    'g.FillRectangle(Brushes.Black, CInt((35 + (70 * k)) - 0.5), 30 - 10, 1, 10)

                    g.FillRectangle(Brushes.Black, CInt((leftmargin + (divwt * k)) - 0.5), divht - 10, 1, 10)
                    Dim str As String = Strings.Right("00" & tmp.Hour, 2) & Strings.Right("00" & tmp.Minute, 2)
                    Dim sz As SizeF = g.MeasureString(str, drawFont)
                    g.DrawString(str, drawFont, drawBrush, leftmargin + (divwt * (k)) - (sz.Width / 2), 5)
                    tmp = tmp.AddMinutes(sltdur)
                    k = k + 1
                End While
                g.Flush()
            End If
        Catch ex As Exception
            Dim i As Integer = 45
        End Try
    End Sub

    Public Sub DrawSession(ByVal g As Graphics, ByVal pobj() As clsSession)
        Dim psttmmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), CDate(txtstrttime.Text))
        Dim pentmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), CDate(txtendtime.Text))
        Dim xx1 As Integer
        xx1 = (divwt * psttmmins) / sltdur
        Dim xx2 As Integer
        xx2 = (divwt * pentmins) / sltdur
        Dim b As Brush = New SolidBrush(Color.Red)
        g.FillRectangle(b, leftmargin + xx1, divht, xx2 - xx1, Integer.Parse(pnl001.Height.ToString().Replace("px", "")) - divht)
        If Not pobj Is Nothing Then
            For Each obj As clsSession In pobj
                If Not obj Is Nothing Then
                    sessltcnt = System.Math.Floor(DateDiff(Microsoft.VisualBasic.DateInterval.Minute, obj.starttime, obj.endtime) / 30)
                    sesdivwt = (divwt * 30 / sltdur)
                    psttmmins = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), obj.starttime)
                    pentmins = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), obj.endtime)
                    xx1 = (divwt * psttmmins) / sltdur
                    xx2 = (divwt * pentmins) / sltdur
                    b = New SolidBrush(Color.White)
                    g.FillRectangle(b, leftmargin + xx1, divht, xx2 - xx1, Integer.Parse(pnl001.Height.ToString().Replace("px", "")) - divht)
                    If cmpscale = True Then
                        g.DrawLine(Pens.LightGreen, leftmargin + xx1, divht, leftmargin + xx1, Integer.Parse(pnl001.Height.ToString().Replace("px", "")))
                        g.DrawLine(Pens.LightGreen, leftmargin + xx2, divht, leftmargin + xx2, Integer.Parse(pnl001.Height.ToString().Replace("px", "")))
                    End If
                    For i As Integer = 0 To sessltcnt
                        Dim mmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), obj.starttime.AddMinutes(i * 30))
                        Dim xx As Integer = (divwt * mmins) / 60
                        g.FillRectangle(Brushes.Black, CInt((leftmargin + xx) - 0.5), divht - 5, 1, 5)
                    Next
                    g.DrawLine(Pens.Black, 0, divht, Integer.Parse(pnl001.Width.ToString().Replace("px", "")), divht)
                    g.Flush()
                End If
            Next
        End If
    End Sub

    Public Sub BtnResize()
        If Not btnarr Is Nothing Then
            For i As Integer = 0 To btnarr.Length - 1
                Dim psttm As Date = btnarr(i).StartTime
                Dim pentm As Date = btnarr(i).EndTime
                Dim psttmmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), psttm)
                Dim pentmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), pentm)
                Dim xx1 As Integer
                xx1 = (divwt * psttmmins) / sltdur
                Dim xx2 As Integer
                xx2 = (divwt * pentmins) / sltdur
                Dim PtnType As String = "" '' Amol 2020-11-07 JSK001-147262	
                SetButton(btnarr(i), (xx1 + leftmargin), (xx2 - xx1), psttm, pentm, btnarr(i).Noofslots, btnarr(i).BookingID, btnarr(i).ApptDate, btnarr(i).DoctorCd, btnarr(i).Doctor, btnarr(i).PatCd, btnarr(i).PatName, btnarr(i).AptRmrks, False, PtnType, False, "", "", "")
            Next
        End If
    End Sub

    Private Sub SetButton(ByRef btn As clsTimeSlot, ByVal left As Integer, ByVal width As Integer, ByVal StartTime As Date, ByVal EndTime As Date, ByVal NoofSlots As Long, ByVal pBookingID As Integer, ByVal pApptDate As Date, ByVal pDoctorCd As Long, ByVal pDoctor As String, ByVal pPatcd As Long, ByVal patname As String, ByVal pAptRmrk As String, ByVal add As Boolean, ByVal PtnType As String, ByVal IsoffPerm As Boolean, ByVal OffRmrk As String, ByVal OffPermDtl As String,ByVal BookingType As Integer)
        btn.Attributes.Add("style", "white-space: normal;position:absolute;top:" & divht + (Integer.Parse(pnl001.Height.ToString().Replace("px", "")) * 0.05) & "px;left:" & left + 3 & "px")
        btn.Width = width
        btn.Height = Integer.Parse(pnl001.Height.ToString().Replace("px", "")) - divht - (Integer.Parse(pnl001.Height.ToString().Replace("px", "")) * 0.1) - 25
        btn.StartTime = StartTime
        btn.EndTime = EndTime
        btn.Noofslots = NoofSlots
        btn.BookingID = pBookingID
        btn.ApptDate = pApptDate
        btn.Doctor = pDoctor.Replace("'", "")
        btn.PatCd = pPatcd
        btn.PatName = patname.Replace("'", "")
        btn.DoctorCd = pDoctorCd
        btn.BackColor = Color.FromArgb(192, 255, 192)
        btn.ForeColor = Color.Red
        btn.Text = pDoctor
        btn.AptRmrks = pAptRmrk.Replace("'", "")             'pragya : 02-nov-2016
        btn.PtnType = PtnType  '' Amol 2020-11-07 JSK001-147262	
        btn.ToolTip = "Doctor - " & Environment.NewLine & pDoctor & Environment.NewLine & "Remarks - " & Environment.NewLine & pAptRmrk.Replace("'", "")

        'Sana : 01-Nov-2019 Start
        ' Session("objArrOTSrvDtls") = Nothing  ''Commented By Amol 2019-12-17 For Maintain Updated Session State

        Dim lngPtnNo As Long = 0
        lngPtnNo = OTScheduling.GetPtnNoByIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt64(pPatcd))
        Dim objLstSrvDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)

        Session("ActualPtnNo") = IIf(lngPtnNo <> 0, lngPtnNo, 0)

        ''Commented By Amol 2019-12-17 For Maintain Updated Session State
        'If pBookingID.ToString() <> "" Then
        '    objLstSrvDtls = OTScheduling.GetLstOfOtSrvDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtot.Text, 1, 1, pBookingID, Session("ActualPtnNo"), pPatcd)
        '    If objLstSrvDtls IsNot Nothing Then
        '        If Session("objArrOTSrvDtls") IsNot Nothing Then
        '            objLstSrvDtls = Session("objArrOTSrvDtls")
        '            Session("objArrOTSrvDtls") = objLstSrvDtls
        '        Else
        '            Session("objArrOTSrvDtls") = objLstSrvDtls
        '        End If
        '    Else
        '        If Session("objArrOTSrvDtls") IsNot Nothing Then
        '            objLstSrvDtls = Session("objArrOTSrvDtls")
        '        End If
        '    End If
        'Else
        '    If Session("objArrOTSrvDtls") IsNot Nothing Then
        '        objLstSrvDtls = Session("objArrOTSrvDtls")
        '    End If
        'End If
        ''Commented By Amol 2019-12-17 For Maintain Updated Session State


        If Session("objArrOTSrvDtls") IsNot Nothing Then
            btn.ToolTip += Environment.NewLine & "Services - " & Environment.NewLine
            For i = 0 To objLstSrvDtls.Count - 1
                If i < objLstSrvDtls.Count - 1 Then
                    If objLstSrvDtls(i).srvcd <> 0 And objLstSrvDtls(i).srvdesc <> "" Then
                        btn.ToolTip += objLstSrvDtls(i).srvdesc & " " & "(" & objLstSrvDtls(i).chrgcd & " " & " " & objLstSrvDtls(i).ChrgDesc & ")" & " " & ", " & Environment.NewLine
                    End If
                Else
                    If objLstSrvDtls(i).srvcd <> 0 And objLstSrvDtls(i).srvdesc <> "" Then
                        btn.ToolTip += objLstSrvDtls(i).srvdesc & " " & "(" & objLstSrvDtls(i).chrgcd & " " & " " & objLstSrvDtls(i).ChrgDesc & ")"
                    End If
                End If
            Next

        ElseIf objLstSrvDtls IsNot Nothing Then
            btn.ToolTip += Environment.NewLine & "Services - "
            For i = 0 To objLstSrvDtls.Count - 1
                If i < objLstSrvDtls.Count - 1 Then
                    If objLstSrvDtls(i).srvcd <> 0 And objLstSrvDtls(i).srvdesc <> "" Then
                        btn.ToolTip += objLstSrvDtls(i).srvdesc & " " & "(" & objLstSrvDtls(i).chrgcd & " " & " " & objLstSrvDtls(i).ChrgDesc & ")" & " " & ", " & Environment.NewLine
                    End If
                Else
                    If objLstSrvDtls(i).srvcd <> 0 And objLstSrvDtls(i).srvdesc <> "" Then
                        btn.ToolTip += objLstSrvDtls(i).srvdesc & " " & "(" & objLstSrvDtls(i).chrgcd & " " & " " & objLstSrvDtls(i).ChrgDesc & ")"
                    End If
                End If
            Next
        End If
        'Sana : 01-Nov-2019 Start

        Dim span As TimeSpan = EndTime.Subtract(StartTime)

        'Dim hrs As String = DateDiff(Microsoft.VisualBasic.DateInterval.Hour, StartTime, EndTime)

        'If Session("OTSelected") IsNot Nothing And Session("OTDateSelected") IsNot Nothing And Session("OTStartTmSelected") IsNot Nothing And Session("OTEndTmSelected") IsNot Nothing Then

        '    'Dim valuetobesend As String = NoofSlots.ToString() + "~~" + pBookingID.ToString() + "~~" + pApptDate.ToString() + "~~" + pDoctorCd.ToString() + "~~" + pDoctor.Replace("'", "") + "~~" + Format(StartTime, "HH:mm") + "~~" + Format(EndTime, "HH:mm") + "~~" + pPatcd.ToString() + "~~" + patname.Replace("'", "") + "~~" + span.Hours.ToString() + "~~" + span.Minutes.ToString() + "~~" + pAptRmrk.ToString()
        '    'btn.OnClientClick = "javascript:RowDblclicked('" & valuetobesend & "');  return false;"

        '    Dim valuetobesend As String = NoofSlots.ToString() + "~~" + pBookingID.ToString() + "~~" + pApptDate.ToString() + "~~" + pDoctorCd.ToString() + "~~" + pDoctor.Replace("'", "") + "~~" + Format(StartTime, "HH:mm") + "~~" + Format(EndTime, "HH:mm") + "~~" + pPatcd.ToString() + "~~" + patname.Replace("'", "") + "~~" + span.Hours.ToString() + "~~" + span.Minutes.ToString() + "~~" + pAptRmrk.ToString()
        '    btn.OnClientClick = "javascript:getdetailsToModifiedData('" & valuetobesend & "');  return false;"

        'Else
        '    Dim valuetobesend As String = NoofSlots.ToString() + "~~" + pBookingID.ToString() + "~~" + pApptDate.ToString() + "~~" + pDoctorCd.ToString() + "~~" + pDoctor.Replace("'", "") + "~~" + Format(StartTime, "HH:mm") + "~~" + Format(EndTime, "HH:mm") + "~~" + pPatcd.ToString() + "~~" + patname.Replace("'", "") + "~~" + span.Hours.ToString() + "~~" + span.Minutes.ToString() + "~~" + pAptRmrk.ToString()
        '    btn.OnClientClick = "javascript:getdetails('" & valuetobesend & "');  return false;"
        'End If

        Dim valuetobesend As String = NoofSlots.ToString() + "~~" + pBookingID.ToString() + "~~" + pApptDate.ToString() + "~~" + pDoctorCd.ToString() + "~~" + pDoctor.Replace("'", "") + "~~" + Format(StartTime, "HH:mm") + "~~" + Format(EndTime, "HH:mm") + "~~" + pPatcd.ToString() + "~~" + patname.Replace("'", "") + "~~" + span.Hours.ToString() + "~~" + span.Minutes.ToString() + "~~" + pAptRmrk.ToString() + "~~" + PtnType.ToString() + "~~" + IsoffPerm.ToString() + "~~" + OffRmrk.ToString() + "~~" + OffPermDtl.ToString() + "~~" + BookingType.ToString() '''' Amol 2020-11-07 JSK001-147262	 [PtnType]

        btn.OnClientClick = "javascript:getdetails('" & valuetobesend & "');  return false;" 'RasikV 20170128

        'Dim valuetobesend As String = NoofSlots.ToString() + "~~" + pBookingID.ToString() + "~~" + pApptDate.ToString() + "~~" + pDoctorCd.ToString() + "~~" + pDoctor.Replace("'", "") + "~~" + Format(StartTime, "HH:mm") + "~~" + Format(EndTime, "HH:mm") + "~~" + pPatcd.ToString() + "~~" + patname.Replace("'", "") + "~~" + span.Hours.ToString() + "~~" + span.Minutes.ToString() + "~~" + pAptRmrk.ToString()
        'btn.OnClientClick = "javascript:getdetails('" & valuetobesend & "');  return false;"
        'anamika 20161003

        If Session("EditMode") = "true" Then
            btn.Enabled = False
        Else
            btn.Enabled = True
        End If
        'anamika 20161003
        If add = True Then
            Addbutton(btn)
        End If
    End Sub

    Private Sub SetLabel(ByRef lbl As clsTimeSlotLbl, ByVal left As Integer, ByVal width As Integer, ByVal StartTime As Date, ByVal EndTime As Date, ByVal NoofSlots As Long, ByVal pBookingID As Integer, ByVal pApptDate As Date, ByVal pDoctorCd As Long, ByVal pDoctor As String, ByVal pPatcd As Long, ByVal patname As String, ByVal pAptRmrk As String, ByVal add As Boolean, ByVal PtnType As String)       'Sana : 30-OCT-2019
        lbl.Attributes.Add("style", "background-color: #fff7c1;height: fit-content;position:absolute;font-size: 13px;text-align:center;border: 1px solid #ffb301;border-top: black;;top:" & divht + 80 + (Integer.Parse(pnl001.Height.ToString().Replace("px", "")) * 0.05) & "px;left:" & left + 3 & "px")
        lbl.Width = width - 2
        ' lbl.Height = Integer.Parse(pnl001.Height.ToString().Replace("px", "")) - divht - (Integer.Parse(pnl001.Height.ToString().Replace("px", "")) * 0.1) - 65
        lbl.StartTime = StartTime
        lbl.EndTime = EndTime
        lbl.Noofslots = NoofSlots
        lbl.BookingID = pBookingID
        lbl.ApptDate = pApptDate
        lbl.DoctorCd = pDoctorCd
        lbl.Doctor = pDoctor.Replace("'", "")
        lbl.PatCd = pPatcd
        lbl.PatName = patname.Replace("'", "")
        'lbl.BackColor = Color.FromArgb(249, 232, 184)
        lbl.ForeColor = Color.Black
        lbl.Text = pPatcd & " " & " " & " " & patname
        lbl.AptRmrks = pAptRmrk.Replace("'", "")
        lbl.PtnType = PtnType  '' Amol 2020-11-07 JSK001-147262	
        lbl.ToolTip = "Patient - " & Environment.NewLine & patname & Environment.NewLine & "Remarks - " & Environment.NewLine & pAptRmrk.Replace("'", "")

        'Sana : 01-Nov-2019 Start
        ' Session("objArrOTSrvDtls") = Nothing         ''Commented By Amol 2019-12-17 For Maintain Updated Session State

        Dim lngPtnNo As Long = 0
        lngPtnNo = OTScheduling.GetPtnNoByIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt64(pPatcd))
        Dim objLstSrvDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)

        Session("ActualPtnNo") = IIf(lngPtnNo <> 0, lngPtnNo, 0)

        ''Commented By Amol 2019-12-17 For Maintain Updated Session State
        'If pBookingID.ToString() <> "" Then
        '    objLstSrvDtls = OTScheduling.GetLstOfOtSrvDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtot.Text, 1, 1, pBookingID, Session("ActualPtnNo"), pPatcd)
        '    If objLstSrvDtls IsNot Nothing Then
        '        If Session("objArrOTSrvDtls") IsNot Nothing Then
        '            objLstSrvDtls = Session("objArrOTSrvDtls")
        '            Session("objArrOTSrvDtls") = objLstSrvDtls
        '        Else
        '            Session("objArrOTSrvDtls") = objLstSrvDtls
        '        End If
        '    Else
        '        If Session("objArrOTSrvDtls") IsNot Nothing Then
        '            objLstSrvDtls = Session("objArrOTSrvDtls")
        '        End If
        '    End If
        'Else
        '    If Session("objArrOTSrvDtls") IsNot Nothing Then
        '        objLstSrvDtls = Session("objArrOTSrvDtls")
        '    End If
        'End If
        ''Commented By Amol 2019-12-17 For Maintain Updated Session State

        If Session("objArrOTSrvDtls") IsNot Nothing Then
            lbl.ToolTip += Environment.NewLine & "Services - " & Environment.NewLine
            For i = 0 To objLstSrvDtls.Count - 1
                If i < objLstSrvDtls.Count - 1 Then
                    If objLstSrvDtls(i).srvcd <> 0 And objLstSrvDtls(i).srvdesc <> "" Then
                        lbl.ToolTip += objLstSrvDtls(i).srvdesc & " " & "(" & objLstSrvDtls(i).chrgcd & " " & " " & objLstSrvDtls(i).ChrgDesc & ")" & " " & ", " & Environment.NewLine
                    End If
                Else
                    If objLstSrvDtls(i).srvcd <> 0 And objLstSrvDtls(i).srvdesc <> "" Then
                        lbl.ToolTip += objLstSrvDtls(i).srvdesc & " " & "(" & objLstSrvDtls(i).chrgcd & " " & " " & objLstSrvDtls(i).ChrgDesc & ")"
                    End If
                End If
            Next

        ElseIf objLstSrvDtls IsNot Nothing Then
            lbl.ToolTip += Environment.NewLine & "Services - "
            For i = 0 To objLstSrvDtls.Count - 1
                If i < objLstSrvDtls.Count - 1 Then
                    If objLstSrvDtls(i).srvcd <> 0 And objLstSrvDtls(i).srvdesc <> "" Then
                        lbl.ToolTip += objLstSrvDtls(i).srvdesc & " " & "(" & objLstSrvDtls(i).chrgcd & " " & " " & objLstSrvDtls(i).ChrgDesc & ")" & " " & ", " & Environment.NewLine
                    End If
                Else
                    If objLstSrvDtls(i).srvcd <> 0 And objLstSrvDtls(i).srvdesc <> "" Then
                        lbl.ToolTip += objLstSrvDtls(i).srvdesc & " " & "(" & objLstSrvDtls(i).chrgcd & " " & " " & objLstSrvDtls(i).ChrgDesc & ")"
                    End If
                End If
            Next
        End If
        'Sana : 01-Nov-2019 Start

        Dim span As TimeSpan = EndTime.Subtract(StartTime)

        'Dim valuetobesend As String = NoofSlots.ToString() + "~~" + pBookingID.ToString() + "~~" + pApptDate.ToString() + "~~" + pDoctorCd.ToString() + "~~" + pDoctor.Replace("'", "") + "~~" + Format(StartTime, "HH:mm") + "~~" + Format(EndTime, "HH:mm") + "~~" + pPatcd.ToString() + "~~" + patname.Replace("'", "") + "~~" + span.Hours.ToString() + "~~" + span.Minutes.ToString() + "~~" + pAptRmrk.ToString()

        'lbl.OnClientClick = "javascript:getdetails('" & valuetobesend & "');  return false;" 

        If Session("EditMode") = "true" Then
            lbl.Enabled = False
        Else
            lbl.Enabled = True
        End If

        If add = True Then
            Addlabel(lbl)
        End If
    End Sub

    Private Sub Addbutton(ByRef btn As clsTimeSlot)
        pnl001.Controls.Add(btn)
        For Each abc As System.Web.UI.Control In pnl001.Controls
        Next
        btnarrcnt = btnarrcnt + 1
        ReDim Preserve btnarr(btnarrcnt - 1)
        btnarr(btnarrcnt - 1) = btn
    End Sub

    Private Sub Addlabel(ByRef lbl As clsTimeSlotLbl)         'Sana : 30-OCT-2019
        pnl001.Controls.Add(lbl)
        For Each abc As System.Web.UI.Control In pnl001.Controls
        Next
        lblarrcnt = lblarrcnt + 1
        ReDim Preserve lblarr(lblarrcnt - 1)
        lblarr(lblarrcnt - 1) = lbl
    End Sub

    Public Sub DrawButtons(ByVal psttm As Date, ByVal pentm As Date, ByVal pslots As Long, ByVal pBookingID As Integer, ByVal pApptDate As Date, ByVal pDoctor As String, ByVal pDoctorCd As Long, ByVal pPatCd As Long, ByVal pPatName As String, ByVal pAptRmrks As String, ByVal PtnType As String, ByVal IsoffPerm As Boolean, ByVal OffRmrk As String, ByVal OffPermDtl As String, ByVal BookingType As Integer)
        Dim psttmmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), psttm)
        Dim pentmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), pentm)
        Dim xx1 As Integer
        xx1 = (divwt * psttmmins) / sltdur
        Dim xx2 As Integer
        xx2 = (divwt * pentmins) / sltdur
        Dim btn As New clsTimeSlot
        Dim lft As Integer = xx1 + leftmargin
        SetButton(btn, lft, (xx2 - xx1), psttm, pentm, pslots, pBookingID, pApptDate, pDoctorCd, pDoctor, pPatCd, pPatName, pAptRmrks, True, PtnType, IsoffPerm, OffRmrk, OffPermDtl, BookingType)
    End Sub

    Public Sub DrawLabel(ByVal psttm As Date, ByVal pentm As Date, ByVal pslots As Long, ByVal pBookingID As Integer, ByVal pApptDate As Date, ByVal pDoctor As String, ByVal pDoctorCd As Long, ByVal pPatCd As Long, ByVal pPatName As String, ByVal pAptRmrks As String, ByVal PtnType As String)            'Sana : 30-OCT-2019
        Dim psttmmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), psttm)
        Dim pentmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), pentm)
        Dim xx1 As Integer
        xx1 = (divwt * psttmmins) / sltdur
        Dim xx2 As Integer
        xx2 = (divwt * pentmins) / sltdur
        Dim lbl As New clsTimeSlotLbl
        Dim lft As Integer = xx1 + leftmargin
        SetLabel(lbl, lft, (xx2 - xx1), psttm, pentm, pslots, pBookingID, pApptDate, pDoctorCd, pDoctor, pPatCd, pPatName, pAptRmrks, True, PtnType)
    End Sub

    Public Sub ClearDrawTimeScale()
        ClearButtons()
        Dim bmp As New Bitmap(1500, 2500)
        Dim g As Graphics = System.Drawing.Graphics.FromImage(bmp)
        DrawTimeScale(g)
        g.Flush()
        Dim img_converter As New ImageConverter()
        Dim bytes As Byte() = DirectCast(img_converter.ConvertTo(bmp, GetType(Byte())), Byte())
        Dim dtm As String = Date.Today.ToString().Replace("/", "") '.Hour.ToString() + Date.Today.TimeOfDay.ToString()
        Dim dtm1 As String = dtm.Replace(":", "")
        Dim random As New Random()
        Dim ran As String = Convert.ToString(random.[Next](10, 200))

        'File.WriteAllBytes(Server.MapPath("~/Images/" & dtm1 + ran & ".jpeg"), bytes)
        '   pnl001.BackColor = Color.White
        'pnl001.BackImageUrl = "~/Images/" & dtm1 + ran & ".jpeg"
        'pnl001.Attributes.Add("style", "background-repeat:no-repeat")

    End Sub

    Public Sub ClearButtons()
        btnarr = Nothing
        btnarrcnt = 0
        pnl001.Controls.Clear()
        For Each CurControl As Object In pnl001.Controls
            If TypeOf CurControl Is clsTimeSlot Then
                CurControl.dispose()
            End If
        Next
    End Sub

    Public Sub AddMessage(Optional ByVal msg As String = "OT CALENDAR NOT SET")
        UP3.Update() 'RasikV 20170125
        UP4.Update() 'RasikV 20170125
        UP5.Update() 'RasikV 20170125
        txtstrttime.Text = ""
        txtendtime.Text = ""
        ClearDrawTimeScale()
        Dim lbl As New WebControls.Label
        lbl.ForeColor = Color.Red
        lbl.Text = msg
        lbl.Attributes.Add("style", "position:absolute;font-size:40px;top:" & (Integer.Parse(pnl001.Height.ToString().Replace("px", "")) * 0.05) & "px;left:" & 280 & "px")
        pnl001.Controls.Add(lbl)
        GrdReqDetails.DataSource = Nothing
        GrdReqDetails.DataBind()
        btnnewbkng.Enabled = False
        Session("img123") = Nothing
    End Sub

    Public Sub ClearAll()
        FnRights()                    'Pushpa 20180512
        txtdctid.Text = ""
        txtdctname.Text = ""
        txtpatid.Text = ""
        txtpatname.Text = ""
        ' txtOpPtnCd.Text = "" '' Amol 2020-11-07 JSK001-147262	
        rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
        CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

        txthrs.Text = "00"
        txtmins.Text = "00"
        txtstrttm1.Text = ""
        txtapptno.Text = ""
        txtslots.Text = ""
        txtreqno.Value = ""
        txtflag.Value = ""
        txtRmrk.Text = ""           'pragya : 02-nov-2016
        txtCnclRmrk.Text = ""

        '#Trupti 14 JUN 2021
        chkIsOffPerm.Checked = False
        txtoffPermRmrk.Text = ""
        lblchkSts.Text = IIf(chkIsOffPerm.Checked, "Given", "Not Given")

        drpBookingType.SelectedValue = "SELECT"
        '#Trupti 14 JUN 2021

        clsGeneral.ShowConsoleTrack("ClearAll", "", Page)
        Session("TxtFlag") = Nothing
        ViewState("pStartTime") = Nothing
        ViewState("pStartTime") = Nothing

        Session("SHIFTFLAG") = Nothing '20211204

        hdnNurseName.Value = "" '20211204
        hdnANESTYPCD.Value = "0" '20211204
        'clear the data & session of OTDOC / OT SERVICE IF ANY ERROR COMES OR RECORDS R NT SAVED
        'If Session("objArrOTDoctorsDtls") IsNot Nothing Or Session("objArrOTSrvDtls") IsNot Nothing Or Session("objArrOTEmpDtls") IsNot Nothing Then
        chkIsOffPerm.Checked = False
        txtoffPermRmrk.Text = ""
        If Session("objArrOTDoctorsDtls") IsNot Nothing And Session("objArrOTSrvDtls") IsNot Nothing And Session("objArrOTEmpDtls") IsNot Nothing Then 'RasikV 20170123
            objArrOTSrvDtls = Nothing
            objArrOTDoctorsDtls = Nothing
            Session("ActualPtnNo") = Nothing
            Session("objArrOTSrvDtls") = Nothing
            Session("objArrOTDoctorsDtls") = Nothing
            Session("IpNoChnged") = Nothing
            Session("OTSelected") = Nothing
            Session("OTDateSelected") = Nothing
            Session("OTStartTmSelected") = Nothing
            Session("OTEndTmSelected") = Nothing
            Session("OTDocIdSelected") = Nothing
            Session("OTDocNameSelected") = Nothing
            Session("OTPatIdSelected") = Nothing
            Session("OTPatNameSelected") = Nothing
            Session("OTHrsSelected") = Nothing
            Session("OTMinsSelected") = Nothing
            Session("OTStrtTme1Selected") = Nothing
            Session("OTApptNoSelected") = Nothing
            Session("OTSlotsSelected") = Nothing
            Session("OTRemarksSelected") = Nothing
            Session("objArrOTDoctorsDtls") = Nothing
            Session("objArrOTEmpDtls") = Nothing
        End If
        Getsessions()
    End Sub
    Public Sub clearSession()

        objArrOTSrvDtls = Nothing
        objArrOTDoctorsDtls = Nothing
        Session("ActualPtnNo") = Nothing
        Session("objArrOTSrvDtls") = Nothing
        Session("objArrOTDoctorsDtls") = Nothing
        Session("IpNoChnged") = Nothing

        Session("OTDocIdSelected") = Nothing
        Session("OTDocNameSelected") = Nothing
        Session("OTPatIdSelected") = Nothing
        Session("OTPatNameSelected") = Nothing
        Session("OTHrsSelected") = Nothing
        Session("OTMinsSelected") = Nothing
        Session("OTStrtTme1Selected") = Nothing
        Session("OTApptNoSelected") = Nothing
        Session("OTSlotsSelected") = Nothing
        Session("OTRemarksSelected") = Nothing

        Session("objArrOTEmpDtls") = Nothing
    End Sub


    <System.Web.Services.WebMethod()>
    Public Shared Function GetPatName(ByVal patno As String) As String
        Dim strErrMsg As New List(Of String)
        Dim chrErrFlg As Char
        GetPatName = ""

        If (patno <> "") Then
            Dim objpatient As New clsIpPatientVisit 'clsInPatient
            objpatient = OTScheduling.GetInpatientDetails(strErrMsg, chrErrFlg, HttpContext.Current.Session("COMPANYCODE"), HttpContext.Current.Session("DIVCODE"), HttpContext.Current.Session("LOCCODE"), patno)

            If objpatient IsNot Nothing Then
                If chrErrFlg = "Y" Then
                Else
                    GetPatName = objpatient.ptnname 'PatientFullName
                End If
            End If

        End If
        Return GetPatName
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function GetDoctName(ByVal doctno As String) As String
        Dim strErrMsg As New List(Of String)
        GetDoctName = ""
        Dim chrErrFlg As Char
        If (doctno <> "") Then
            GetDoctName = OTScheduling.GetDoctorName(strErrMsg, chrErrFlg, HttpContext.Current.Session("COMPANYCODE"), HttpContext.Current.Session("DIVCODE"), HttpContext.Current.Session("LOCCODE"), doctno)
        End If
        Return GetDoctName
    End Function

    Public Function regscript()
        If (GrdReqDetails.Rows.Count <> 0) Then
            UP5.Update() 'RasikV 20170125
            For Each dg As GridViewRow In GrdReqDetails.Rows
                Dim lblDocCd1 As New WebControls.Label
                Dim lblDocName1 As New WebControls.Label
                Dim lblptnNo1 As New WebControls.Label
                Dim lblptnName1 As New WebControls.Label
                Dim lblstrttm1 As New WebControls.Label
                Dim lblendtm1 As New WebControls.Label
                Dim lblIPOP1 As New WebControls.Label
                Dim lblReqNo1 As New WebControls.Label
                Dim lblAppNo As New WebControls.Label

                Dim lblNurseName As New WebControls.Label 'shital 20211204

                Dim lblANESTYPCD As New WebControls.Label  'shital 20211204


                lblDocCd1 = dg.FindControl("lblDocCd")
                lblDocName1 = dg.FindControl("lblDocName")
                lblptnNo1 = dg.FindControl("lblptnNo")
                lblptnName1 = dg.FindControl("lblptnname")
                lblIPOP1 = dg.FindControl("lblIPOP")
                lblstrttm1 = dg.FindControl("lblaptmfrm")
                lblendtm1 = dg.FindControl("lblaptmto")
                lblAppNo = dg.FindControl("lblAppNo")



                lblNurseName = dg.FindControl("lblNurseName")


                lblANESTYPCD = dg.FindControl("lblANESTYPCD")


                Dim pstartime As Date
                Dim pendime As Date
                Dim APTM_TM_FROM As String = lblstrttm1.Text
                Dim APTM_TM_TO As String = lblendtm1.Text
                Dim IPOP As String

                If (APTM_TM_FROM.Length = 3) Then
                    pstartime = CDate("0" & Left(APTM_TM_FROM, 1) & ":" & Right(APTM_TM_FROM, 2))
                ElseIf (APTM_TM_FROM.Length = 2) Then
                    pstartime = CDate("00" & ":" & Right(APTM_TM_FROM, 2))
                ElseIf (APTM_TM_FROM.Length = 1) Then
                    pstartime = CDate("00" & ":" & "0" & Right(APTM_TM_FROM, 1))
                Else
                    pstartime = CDate(Left(APTM_TM_FROM, 2) & ":" & Right(APTM_TM_FROM, 2))
                End If

                If (APTM_TM_TO.Length = 3) Then
                    pendime = CDate("0" & Left(APTM_TM_TO, 1) & ":" & Right(APTM_TM_TO, 2))
                ElseIf (APTM_TM_TO.Length = 2) Then
                    pendime = CDate("00" & ":" & Right(APTM_TM_TO, 2))
                ElseIf (APTM_TM_TO.Length = 1) Then
                    pendime = CDate("00" & ":" & "0" & Right(APTM_TM_TO, 1))
                Else
                    pendime = CDate(Left(APTM_TM_TO, 2) & ":" & Right(APTM_TM_TO, 2))
                End If

                ' Dim pstartime As Date = CDate(APTM_TM_FROM)
                ' Dim pendime As Date   = CDate(APTM_TM_TO)

                Dim span As TimeSpan = pendime.Subtract(pstartime)

                'Dim pdiffmins As Long = DateDiff(DateInterval.Minute, pstartime, pendime)
                'Dim phrs As Single = pdiffmins / 60
                'phrs = Math.Round(phrs, 1)
                'Dim pmins As Integer = ((pdiffmins / 60) - phrs)

                Dim strttime As String

                'If (phrs.ToString.Contains(".")) Then
                '    If (pmins = 0) Then
                '        pmins = lvSlotDur
                '    End If
                'End If

                If (APTM_TM_FROM.Length = 3) Then
                    strttime = ("0" & Left(APTM_TM_FROM, 1) & ":" & Right(APTM_TM_FROM, 2))
                ElseIf (APTM_TM_FROM.Length = 2) Then
                    strttime = ("00" & ":" & Right(APTM_TM_FROM, 2))
                ElseIf (APTM_TM_FROM.Length = 1) Then
                    strttime = ("00" & ":" & "0" & Right(APTM_TM_FROM, 1))
                Else
                    strttime = (Left(APTM_TM_FROM, 2) & ":" & Right(APTM_TM_FROM, 2))
                End If

                Dim slots As String = CalNoofSlotsRequired(pstartime, pendime, lvSlotDur)

                'txtapptno.Text = "" commented as apno is geeting clear

                lblReqNo1 = dg.FindControl("lblReqNo")
                Dim lblReqNo As String = lblReqNo1.Text '.Cells("REQ_NO").Value
                If (lblIPOP1.Text = "I") Then
                    IPOP = "I"
                Else
                    IPOP = "o"
                End If
                Dim valuetobesend As String
                valuetobesend = lblDocCd1.Text + "~" + lblDocName1.Text.Replace("'", "") + "~" + lblptnNo1.Text + "~" + lblptnName1.Text.Replace("'", "") + "~" + strttime + "~" + slots + "~" + lblReqNo + "~" + span.Hours.ToString() + "~" + span.Minutes.ToString() + "~" + IPOP + "~" + lblAppNo.Text.Trim() + "~" + lblNurseName.Text.Trim() + "~" + lblANESTYPCD.Text.Trim()
                dg.Attributes.Add("ondblclick", "RowDblclicked('" & valuetobesend & "')")
            Next

            '     pnl001.Controls.Add(GrdReqDetails)

        End If
    End Function

    Public Function AdjustDate(ByVal pdt As Date, Optional ByVal ToLower As Boolean = True) As Date

        'Dim sltduration = GetSlotsCount()

        sessltcnt = System.Math.Floor(DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(txtstrttime.Text), CDate(txtendtime.Text)) / lvSlotDur)
        sessttm = CDate(txtstrttime.Text)
        For i As Integer = 0 To sessltcnt
            Dim tmp As Date = sessttm.AddMinutes(i * lvSlotDur)
            If pdt < tmp Then
                If ToLower = True Then
                    pdt = sessttm.AddMinutes((i - 1) * lvSlotDur)
                Else
                    pdt = tmp
                End If
                Return pdt
            ElseIf pdt = tmp Then
                Return pdt
            End If
        Next
        Return pdt
    End Function

    Public Function CheckSlotAvailable(ByVal psttm As Date, ByVal pentm As Date) As Boolean
        Try

            If psttm < sessttm Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "", Page)
                Return False
            End If

            If pentm > CDate(txtendtime.Text) Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "", Page)
                Return False
            End If

            Dim sessbool As Boolean = True

            For Each obj As clsSession In sess
                If (obj.starttime <= psttm And obj.endtime >= psttm) And (obj.starttime <= pentm And obj.endtime >= pentm) Then
                    sessbool = True
                    Exit For
                Else
                    sessbool = False
                End If
            Next

            If sessbool = False Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "", Page)
                Return False
            End If

            Dim tmpdt As Date = psttm

            If Not btnarr Is Nothing Then
                If btnarr.Length <> 0 Then
                    While tmpdt < pentm
                        For Each tmpTimeSlot As clsTimeSlot In btnarr
                            If psttm = tmpTimeSlot.StartTime And pentm = tmpTimeSlot.EndTime Then
                                If tmpTimeSlot.BookingID = Val(txtapptno.Text) And tmpTimeSlot.PatCd = Val(txtpatid.Text) Then
                                Else
                                    Msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 27), tmpTimeSlot.StartTime.ToShortTimeString, tmpTimeSlot.EndTime.ToShortTimeString)
                                    clsGeneral.ShowErrorPopUp(Msg, "", Page)
                                    Return False
                                End If
                            End If
                            If tmpdt >= tmpTimeSlot.StartTime And tmpdt < tmpTimeSlot.EndTime Then
                                If tmpTimeSlot.BookingID = Val(txtapptno.Text) And tmpTimeSlot.PatCd = Val(txtpatid.Text) Then
                                Else
                                    Msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 27), tmpTimeSlot.StartTime.ToShortTimeString, tmpTimeSlot.EndTime.ToShortTimeString)
                                    clsGeneral.ShowErrorPopUp(Msg, "", Page)
                                    Return False
                                End If
                            End If
                        Next
                        tmpdt = tmpdt.AddMinutes(lvSlotDur)
                    End While
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function finalvalidations() As Boolean
        finalvalidations = False
        clsGeneral.ShowConsoleTrack("inide the finalvalidations", "", Page)

        If (txtot.Text = "") Then 'RasikV 20170125
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)
            Return False
        ElseIf (txtdate.Text = "") Then 'RasikV 20170125
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtdate", Page)
            Return False
        ElseIf (IsDate(txtdate.Text) = False) Then 'RasikV 20170125
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 33), "txtdate", Page)
            Return False
        ElseIf (txtdctid.Text) = "" Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 2), "txtdctid", Page)
            Return False
        ElseIf (txtdctname.Text = "") Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 21), "txtdctname", Page)
            Return False
            'ElseIf (txtpatid.Text = "") Then  '' Amol 2020-11-07 JSK001-147262	
            '    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 3), "txtpatid", Page)
            '    Return False
        ElseIf (txtpatname.Text = "") Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 22), "txtpatname", Page)
            Return False
        ElseIf (txthrs.Text = "") Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 32), "txthrs", Page)
            Return False
        ElseIf (txtmins.Text = "") Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 33), "txtmins", Page)
            Return False
        ElseIf (txtstrttm1.Text = "") Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 31), "txtstrttm1", Page)
            Return False
        ElseIf (Integer.Parse(txthrs.Text) > 24) Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 32), "txthrs", Page)
            Return False
        ElseIf (Integer.Parse(txtmins.Text) > 59) Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 33), "txtmins", Page)
            Return False
        ElseIf (txtRmrk.Text = "") Then     'Sana : 01-SEP-2019 
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 47), "txtRmrk", Page)
            Return False
        End If
        Return True
    End Function

    Public Sub DefaultGridDatabind(ByVal grd As GridView)
        Try
            grd.DataSource = New List(Of String)
            grd.DataBind()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Sub FnRights()
        Dim UserRights As String
        UserRights = clsGeneral.UserRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
        If UserRights <> "" Then
            Dim objSessVar As New SessionVariables
            objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btnsave, SessionVariables.EnumFunctionRights.Save, UserRights)
            objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btnnewbkng, SessionVariables.EnumFunctionRights.Save, UserRights)

            'objSessVar.SetUserFunctionRights(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), Session("USERID"), Page, btnCancel, SessionVariables.EnumFunctionRights.Print, UserRights)

            objSessVar = Nothing

            Dim strArray() As String = Split(UserRights, ";")
            hfaccess.Value = strArray(0)
            hfsave.Value = strArray(1)
            hfdelete.Value = strArray(2)
            hfprint.Value = strArray(3)
            hfauth.Value = strArray(4)
        Else
            btnexit_Click("", EventArgs.Empty)
        End If
        ' Pushpa 20180512
        If btnsave.Enabled = True Then
            btnsave.Enabled = True
        End If
        ' pragya 20180512
    End Sub

    Public Sub GetServicesDtls(ByVal FCTCd As Integer, ByVal ApptNo As Integer, ByVal IpOpFlag As String) 'FETCH OT SERVICES RECORDS : RasikV 20170124
        Try
            Dim iPtnNo As Long = 0
            iPtnNo = OTScheduling.GetPtnNoByIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Long.Parse(txtpatid.Text))
            ViewState("ActualPtnNo") = iPtnNo



            Session("ActualPtnNo") = iPtnNo 'shital 20211204



            Dim objOtSrvLstDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
            '   objOtSrvLstDtls = OTScheduling.GetLstOfOtSrvDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, FCTCd, ApptNo, Long.Parse(ViewState("ActualPtnNo")), Long.Parse(txtpatid.Text), IpOpFlag)

            objOtSrvLstDtls = OTScheduling.GetLstOfOtSrvDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), FCTCd, 1, 1, ApptNo, Long.Parse(ViewState("ActualPtnNo")), Long.Parse(txtpatid.Text), IpOpFlag)
            If objOtSrvLstDtls IsNot Nothing Then
                ViewState("objArrOTSrvDtls") = objOtSrvLstDtls

                Session("objArrOTSrvDtls") = objOtSrvLstDtls
                objOtSrvLstDtls = Nothing
            End If

            Dim objOtDocDtls As New List(Of OTSchedulingSerRef.clsOtDocDtls)
            'objOtDocDtls = OTScheduling.GetLstOfOtDocDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, FCTCd, ApptNo, Long.Parse(ViewState("ActualPtnNo")), Long.Parse(txtpatid.Text), IpOpFlag)

            objOtDocDtls = OTScheduling.GetLstOfOtDocDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), FCTCd, 1, 1, ApptNo, Long.Parse(ViewState("ActualPtnNo")), Long.Parse(txtpatid.Text), IpOpFlag)
            If objOtDocDtls IsNot Nothing Then
                ViewState("objArrOTDoctorsDtls") = objOtDocDtls
                Session("objArrOTDoctorsDtls") = objOtDocDtls
                objOtDocDtls = Nothing
            End If

            Dim objFctAptOtEmpDtls As New List(Of OTSchedulingSerRef.clsFctAptOtEmpDtls)
            'objFctAptOtEmpDtls = OTScheduling.GetLstOfOtEmpDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, FCTCd, ApptNo, Long.Parse(ViewState("ActualPtnNo")), Long.Parse(txtpatid.Text), IpOpFlag)

            objFctAptOtEmpDtls = OTScheduling.GetLstOfOtEmpDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), FCTCd, 1, 1, ApptNo, Long.Parse(ViewState("ActualPtnNo")), Long.Parse(txtpatid.Text), IpOpFlag)
            If objFctAptOtEmpDtls IsNot Nothing Then
                ViewState("objArrOTEmpDtls") = objFctAptOtEmpDtls
                Session("objArrOTEmpDtls") = objFctAptOtEmpDtls
                objFctAptOtEmpDtls = Nothing
            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Private Sub ButtonEnabled(ByVal FlgBtnN As Boolean, ByVal FlgBtnM As Boolean, ByVal FlgBtnC As Boolean, ByVal FlgBtnSM As Boolean, ByVal FlgBtnSN As Boolean)  'RasikV 20170125
        Try
            btnnewbkng.Enabled = FlgBtnN
            btnmdfybkng.Enabled = FlgBtnM
            btncnclbkng.Enabled = FlgBtnC
            btnshft.Enabled = FlgBtnSM
            btnshftnow.Enabled = FlgBtnSN
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    'Private Sub ButtonTab(ByVal FlgBtnN As Button, ByVal FlgBtnM As Button, ByVal FlgBtnC As Button, ByVal FlgBtnSM As Button, ByVal FlgBtnSN As Button)  'RasikV 20170125
    '    Try
    '        btnnewbkng.Style
    '        flgBtnItmDtls.Style.Add("background-color", "#34A7C1")
    '        flgBtnItmDtls.Style.Add("color", "#FFFFFF")
    '        flgBtnOtherDtls.Style.Add("background-color", "#EEEEEE")
    '        flgBtnOtherDtls.Style.Add("color", "#4E3EC7") '"#999999")
    '    Catch ex As Exception
    '        clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
    '    End Try
    'End Sub

    Private Sub IFrame(ByVal iPath As String) 'RasikV 20170127
        Try
            Dim Path = iPath
            Dim litCon As New LiteralControl()

            'litCon.Text = "<iframe name='iFrameDiag' style='width: 100%;height:650px;' src='" + Path + "'></iframe>"

            litCon.Text = "<iframe name='iFrameDiag' frameborder='0' style='width: 100%; height: 650px; overflow: hidden; ' src='" + Path + "'></iframe>"
            pnlFrame.Controls.Add(litCon)
            divPopupFrame.Visible = True
            divPopupFrame.Style("height") = "100vh"
            divOverlayPopupFrame.Style("display") = "block"
            upFrame.Update()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Private Function NoOfSlots() As Boolean   'RasikV 20170128
        Try
            Dim dtserverdttm As Date = clsGeneral.getdate()
            GetSlotsCount()
            txthrs.Text = IIf(txthrs.Text = "" Or txthrs.Text = String.Empty, "0", txthrs.Text)
            txtmins.Text = IIf(txtmins.Text = "" Or txtmins.Text = String.Empty, "0", txtmins.Text)
            Dim tomins As String = txtmins.Text
            If (Integer.Parse(txthrs.Text) = 0) Then
                If (Integer.Parse(tomins) <> 0) Then
                    If (Integer.Parse(tomins) < lvSlotDur) Then
                        tomins = lvSlotDur.ToString()
                        'txtmins.Text = tomins
                    End If
                End If
            End If

            If (Integer.Parse(txthrs.Text) = 0) Then
                If (Integer.Parse(tomins) = 0) Then
                    If (Integer.Parse(tomins) < lvSlotDur) Then
                        tomins = lvSlotDur.ToString()
                        'txtmins.Text = tomins
                    End If
                End If
            End If

            Dim pstartime As Date = CDate(txtstrttm1.Text)
            Dim pendime As Date = CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + tomins)

            Dim span As TimeSpan = pendime.Subtract(pstartime)
            Dim actstartime As Date = AdjustDate(pstartime, True)
            Dim actpendime As Date = AdjustDate(pendime, False)

            Dim boolmsg As Boolean = False
            If pstartime <> actstartime Then
                boolmsg = True
                actpendime = AdjustDate(CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + tomins)) 'txtmins.Text))
                Dim actpendime1 As Date = AdjustDate(actpendime, False)
                If actpendime <> actpendime1 Then
                    actpendime = actpendime1
                End If
            End If

            Dim actslots As Long = CalNoofSlotsRequired(actstartime, actpendime, lvSlotDur)
            pstartime = actstartime
            pendime = actpendime

            If (CheckSlotAvailable(pstartime, pendime)) Then
                ViewState("pStartTime") = pstartime
                ViewState("pEndTime") = pendime
            Else
                btnarr = Nothing
                btnarrcnt = 0
                Getsessions()
                NoOfSlots = False
                Exit Function
            End If

            Dim pslots As Long = CalNoofSlotsRequired(pstartime, pendime, lvSlotDur)
            If (pslots = 0) Then
                pslots = 1
            End If
            txtslots.Text = pslots
            NoOfSlots = True
        Catch ex As Exception
            NoOfSlots = False
        End Try
    End Function

    Private Sub Pnl2Enabled(ByVal Pnl2Flg As Boolean)  'RasikV 20170125
        Try

            imageSearchDoc.Enabled = Pnl2Flg
            txtdctid.Enabled = Pnl2Flg
            Imgsearchptn.Enabled = Pnl2Flg
            txtpatid.Enabled = Pnl2Flg
            'txtOpPtnCd.Enabled = Pnl2Flg        '''' Amol 2020-11-07 JSK001-147262	
            imgOpPtnHelp.Enabled = Pnl2Flg      '''' Amol 2020-11-07 JSK001-147262	
            rdbPatientType.Enabled = Pnl2Flg    '''' Amol 2020-11-07 JSK001-147262	
            btnAddNewPtn.Enabled = Pnl2Flg      'Aarti 03 Jan 2021
            txthrs.Enabled = Pnl2Flg
            txtmins.Enabled = Pnl2Flg
            txtstrttm1.Enabled = Pnl2Flg
            txtapptno.Enabled = False
            txtRmrk.Enabled = Pnl2Flg
            btnSelSrvDtls.Enabled = Pnl2Flg
            SaveSrvRuleInfo9232()
            BtnSelDoc.Enabled = Pnl2Flg
            BtnSelEmp.Enabled = Pnl2Flg
            btnsave.Enabled = Pnl2Flg
            btncncl.Enabled = Pnl2Flg

            chkIsOffPerm.Enabled = Pnl2Flg
            txtoffPermRmrk.Enabled = Pnl2Flg
            lblchkSts.Text = IIf(chkIsOffPerm.Checked, "Given", "Not Given")


            txtCnclRmrk.Enabled = btncnclbkng.Enabled
            Dim Flg As String = IIf(Pnl2Flg = True, "True", "False")
            ScriptManager.RegisterClientScriptBlock(UP2, UP2.GetType(), Guid.NewGuid().ToString(), "EnabledDisabledPnl2('" + Flg + "');", True)
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Private Sub Pnl1Enabled(ByVal Pnl1Flg As Boolean)  'RasikV 20170206
        Try
            btnpre.Enabled = Pnl1Flg
            txtdate.Enabled = Pnl1Flg
            btnnext.Enabled = Pnl1Flg
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Private Sub ClrPnl2()       'Aarti 22 Nov 2020
        txtdctid.Text = ""
        txtdctname.Text = ""
        txtpatid.Text = ""
        txtpatname.Text = ""

        rdbPatientType.SelectedValue = "I"
        CheckPtnType()

        txthrs.Text = "00"
        txtmins.Text = "00"
        txtstrttm1.Text = ""
        txtapptno.Text = ""
        txtslots.Text = ""
        txtreqno.Value = ""
        txtflag.Value = ""
        txtRmrk.Text = ""
        txtCnclRmrk.Text = ""

        drpBookingType.SelectedValue = "SELECT"

        '#Trupti 14 JUN 2021
        chkIsOffPerm.Checked = False
        txtoffPermRmrk.Text = ""
        lblchkSts.Text = IIf(chkIsOffPerm.Checked, "Given", "Not Given")
        '#Trupti 14 JUN 2021

        clsGeneral.ShowConsoleTrack("ClearAll", "", Page)
        Session("TxtFlag") = Nothing
        ViewState("pStartTime") = Nothing
        ViewState("pStartTime") = Nothing
        Session("SHIFTFLAG") = Nothing '20211204
        hdnNurseName.Value = "" '20211204
        hdnANESTYPCD.Value = "0" '20211204
        objArrOTSrvDtls = Nothing
        objArrOTDoctorsDtls = Nothing
        Session("ActualPtnNo") = Nothing
        Session("objArrOTSrvDtls") = Nothing
        Session("objArrOTDoctorsDtls") = Nothing
        Session("IpNoChnged") = Nothing
        Session("OTSelected") = Nothing
        Session("OTDateSelected") = Nothing
        Session("OTStartTmSelected") = Nothing
        Session("OTEndTmSelected") = Nothing
        Session("OTDocIdSelected") = Nothing
        Session("OTDocNameSelected") = Nothing
        Session("OTPatIdSelected") = Nothing
        Session("OTPatNameSelected") = Nothing
        Session("OTHrsSelected") = Nothing
        Session("OTMinsSelected") = Nothing
        Session("OTStrtTme1Selected") = Nothing
        Session("OTApptNoSelected") = Nothing
        Session("OTSlotsSelected") = Nothing
        Session("OTRemarksSelected") = Nothing
        Session("objArrOTDoctorsDtls") = Nothing
        Session("objArrOTEmpDtls") = Nothing

        Pnl2Enabled(False)

        ButtonEnabled(False, False, False, False, False)

    End Sub


    Private Sub Clr() 'RasikV 20170206
        Try
            UP1.Update()
            Pnl1Enabled(False)
            ClrPnl1()
            UP2.Update()
            rdbPatientType.SelectedValue = "I"  '''' Amol 2020-11-07 JSK001-147262	
            CheckPtnType()                      '''' Amol 2020-11-07 JSK001-147262	

            Pnl2Enabled(False)
            UP3.Update()
            ButtonEnabled(False, False, False, False, False)
            UP4.Update()
            UP5.Update()
            ClearDrawTimeScale()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Private Sub ClrPnl1() 'RasikV 20170206
        Try
            txtot.Text = ""
            txtotname.Text = ""
            txtstrttime.Text = ""
            txtendtime.Text = ""
            txtdate.Text = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
#End Region

#Region "WEB METHODS" 'RasikV 20170123
    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetServicesDtls(ByVal ApptNo As Integer, ByVal IpNo As Long, ByVal IpOpFlag As String)
        Try
            Dim iPtnNo As Long = 0
            Dim tmpstrErrMsg As New List(Of String)
            Dim tmpchrErrFlg As Char = "N"

            iPtnNo = OTScheduling.GetPtnNoByIpNo(tmpstrErrMsg, tmpchrErrFlg, HttpContext.Current.Session("COMPANYCODE"), HttpContext.Current.Session("DIVCODE"), HttpContext.Current.Session("LOCCODE"), IpNo)

            HttpContext.Current.Session("ActualPtnNo") = iPtnNo
            HttpContext.Current.Session("OTPatIdSelected") = IpNo

            Dim objOtSrvLstDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
            objOtSrvLstDtls = OTScheduling.GetLstOfOtSrvDtls(tmpstrErrMsg, tmpchrErrFlg, HttpContext.Current.Session("COMPANYCODE"), HttpContext.Current.Session("DIVCODE"), HttpContext.Current.Session("LOCCODE"), 1, 1, 1, ApptNo, iPtnNo, IpNo, IpOpFlag)
            If objOtSrvLstDtls IsNot Nothing Then
                HttpContext.Current.Session("objArrOTSrvDtls") = objOtSrvLstDtls
                objOtSrvLstDtls = Nothing
            End If

            Dim objOtDocDtls As New List(Of OTSchedulingSerRef.clsOtDocDtls)
            objOtDocDtls = OTScheduling.GetLstOfOtDocDtls(tmpstrErrMsg, tmpchrErrFlg, HttpContext.Current.Session("COMPANYCODE"), HttpContext.Current.Session("DIVCODE"), HttpContext.Current.Session("LOCCODE"), 1, 1, 1, ApptNo, iPtnNo, IpNo, IpOpFlag)
            If objOtDocDtls IsNot Nothing Then
                HttpContext.Current.Session("objArrOTDoctorsDtls") = objOtDocDtls
                objOtDocDtls = Nothing
            End If

            Dim objFctAptOtEmpDtls As New List(Of OTSchedulingSerRef.clsFctAptOtEmpDtls)
            objFctAptOtEmpDtls = OTScheduling.GetLstOfOtEmpDtls(tmpstrErrMsg, tmpchrErrFlg, HttpContext.Current.Session("COMPANYCODE"), HttpContext.Current.Session("DIVCODE"), HttpContext.Current.Session("LOCCODE"), 1, 1, 1, ApptNo, iPtnNo, IpNo, IpOpFlag)
            If objFctAptOtEmpDtls IsNot Nothing Then
                HttpContext.Current.Session("objArrOTEmpDtls") = objFctAptOtEmpDtls
                objFctAptOtEmpDtls = Nothing
            End If

        Catch ex As Exception
        End Try
    End Function
#End Region



    Protected Sub btnCancelSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelSave.Click    'Pushpa 20180512
        FnRights()
        UP2.Update()
    End Sub

    Protected Sub txtstrttm1_TextChanged(sender As Object, e As EventArgs)          'Aarti 24 Jul 2018
        Try


            If (Val(txtstrttm1.Text) > 24) Then
                txtstrttm1.Text = "23:00"
                clsGeneral.ShowConsoleTrack("txtstrttm1_TextChanged => Inside The IF Block ", "", Page)
            Else

                If (txtstrttm1.Text.Length <= 2) Then
                    txtstrttm1.Text = txtstrttm1.Text + ":00"
                End If

                txtstrttm1.Text = Convert.ToDateTime(txtstrttm1.Text).ToString("HH:mm") 'txtstrttm1.Text + ":00"  ''Amol 2019-12-18
                clsGeneral.ShowConsoleTrack("txtstrttm1_TextChanged => Inside The Else Block ", "", Page)
            End If

        Catch ex As Exception
            clsGeneral.ShowConsoleTrack("txtstrttm1_TextChanged => Inside The Else Block ", "", Page)
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    'shital 20190921
    Private Sub btnFinalPrint_Click(sender As Object, e As EventArgs) Handles btnFinalPrint.Click
        'Aarti 16 JAN 2017
        Try
            Dim intNetID As Integer

            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Dim otno As Integer = 0
            Dim Doccd As Integer = 0
            Dim userid As String = Session("USERID")
            intNetID = 70734

            If txtot.Text = "" Then
                otno = 0
                Session("OTNo") = Nothing
                Session("OTNm") = Nothing
            Else
                otno = Convert.ToInt32(txtot.Text)
                Session("OTNo") = txtot.Text
                Session("OTNm") = txtotname.Text

            End If

            If txtdctid.Text = "" Then
                Doccd = 0
                Session("DocCd") = Nothing
                Session("DocNm") = Nothing
            Else
                Doccd = Convert.ToInt32(txtdctid.Text)
                Session("DocCd") = txtdctid.Text

            End If
            Dim ApptNo As String
            If txtapptno.Text = "" Then
                ApptNo = ViewState("APPTNO")
            Else
                ApptNo = txtapptno.Text
            End If

            Dim Param As New List(Of Microsoft.Reporting.WebForms.ReportParameter)

            Param.Add(New ReportParameter("PCOCD", Session("COMPANYCODE").ToString))
            Param.Add(New ReportParameter("PDIVCD", Session("DIVCODE").ToString))
            Param.Add(New ReportParameter("PLOCCD", Session("LOCCODE").ToString))

            Param.Add(New ReportParameter("FCTCODE", otno))
            Param.Add(New ReportParameter("APTM_DATE", txtdate.Text))

            Param.Add(New ReportParameter("flg", ""))
            Param.Add(New ReportParameter("APTM_STS", "1"))
            Param.Add(New ReportParameter("Doc_Cd", Doccd))
            Param.Add(New ReportParameter("Duplicate", ""))
            Param.Add(New ReportParameter("usrid", userid))
            Param.Add(New ReportParameter("Ptn_No", Convert.ToInt64(txtpatid.Text)))
            Param.Add(New ReportParameter("APPT_NO", ApptNo.ToString))

            Session("Param") = Param
            ClrPnl1()       'Aarti 22 Nov 2020
            ClrPnl2()       'Aarti 22 Nov 2020
            Dim UseReportViewer As Boolean = False
            UseReportViewer = OTScheduling.GetPrntRptViewerRule8013(strErrMsg, chrErrFlg, Convert.ToString(Session("COMPANYCODE")), Convert.ToInt32(Session("DIVCODE")), Convert.ToInt32(Session("LOCCODE")))

            If UseReportViewer = False Then
                Dim pByteArray() As Byte = Nothing
                OTScheduling.SetParamAndViewReport(strErrMsg, chrErrFlg, Session("COMPANYCODE").ToString(), Convert.ToInt32(Session("DIVCODE")), Convert.ToInt32(Session("LOCCODE")), Convert.ToInt32(Session("MAINMODCODE")), Convert.ToInt32(Session("MAINSUBMODCODE")), intNetID, Param, pByteArray, Page)
                Session("ppdf") = pByteArray
            Else
                Session("param") = Param
                Session("netid") = intNetID


                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "window.parent.location.href='ViewReport.aspx';", True)

                'END : PRINT IN REPORT VIEWER CONTROL
            End If
            ClearAll()


        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub btnFinalPrintCancel_Click(sender As Object, e As EventArgs)
        If Session("EditMode") = True Then
            btnexit_Click(sender, e)
        Else
            ClrPnl1()
            ClrPnl2()
        End If
    End Sub

    Protected Sub rdbPatientType_SelectedIndexChanged(sender As Object, e As EventArgs)  '''' Amol 2020-11-07 JSK001-147262	
        Try

            CheckPtnType() '' Amol 2020-11-07 JSK001-147262	

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckPtnType()   '' Amol 2020-11-07 JSK001-147262	
        Try

            If rdbPatientType.SelectedValue = "O" Then
                imgOpPtnHelp.Visible = True
                Imgsearchptn.Visible = False
                'txtpatid.Visible = False

                '   txtOpPtnCd.Visible = True
                txtpatname.Enabled = True
                BtnViewOsDtl.Visible = False
            Else
                imgOpPtnHelp.Visible = False
                Imgsearchptn.Visible = True
                'txtpatid.Visible = True
                'txtOpPtnCd.Visible = False
                txtpatname.Enabled = False
                BtnViewOsDtl.Visible = True
            End If

            UP2.Update()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtOpPtnCd_TextChanged(sender As Object, e As EventArgs)  '''' Amol 2020-11-07 JSK001-147262	

        Try


            If (txtot.Text <> "" And txtdate.Text <> "") Then
                UP2.Update()
                'Pnl2Enabled(True)

                strErrMsg = New List(Of String)
                chrErrFlg = "N"
                Dim objPatientVisit As New PatientDetails

                If txtot.Text = "" Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)
                    txtot.Text = ""
                    txtpatid.Text = ""
                    txtpatname.Text = ""
                    Exit Sub
                End If

                'If txtOpPtnCd.Text = "" And txtpatname.Text = Nothing Then
                '    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 3), "txtOpPtnCd", Page)
                '    txtpatid.Text = ""
                '    txtpatname.Text = ""
                '    Exit Sub
                'End If

                'If txtOpPtnCd.Text <> "0" Then
                '    objPatientVisit = PatientHelp.GetPatientDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtOpPtnCd.Text))
                'End If


                If objPatientVisit Is Nothing Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 35), "txtOpPtnCd", Page)
                    txtpatid.Text = ""
                    txtpatname.Text = ""
                    txtpatid.Focus()
                Else


                    'txtpatname.Text = objPatientVisit.PatientFullName.ToUpper()
                    'Dim obj As New clsFCTAPTOT
                    'obj.PTNNO = Long.Parse(txtOpPtnCd.Text)
                    'obj.PTNLNGNM = txtpatname.Text
                    'Session("IpNoChnged") = Long.Parse(txtOpPtnCd.Text)
                    'txthrs.Focus()
                End If
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub btnAddNewPtn_Click(sender As Object, e As EventArgs)
        rdbPatientType.SelectedValue = "O"
        rdbPatientType_SelectedIndexChanged(sender, e)
        divPopupNewPtnReg.Visible = True

        UpdNewPtnReg.Update()
    End Sub


    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetCode(ByVal prefix As String, ByVal name As String) As List(Of String)
        GetCode = Nothing
        Dim Item As New List(Of String)()
        Dim Item1 As New List(Of String)()
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Dim ObjList As List(Of StateMaster)




        Try
            Dim result = prefix.ToCharArray().Length
            If result <= 1 Then
                GoTo a
            End If

            ObjList = OTScheduling.GetStateLst(tmpstrErrMsg, tmpchrErrFlg, HttpContext.Current.Session("COMPANYCODE"), HttpContext.Current.Session("DIVCODE"), HttpContext.Current.Session("LOCCODE"), 0, prefix)


            If ObjList IsNot Nothing Then
                If ObjList.Count > 0 Then

                    For i As Integer = 0 To ObjList.Count - 1
                        Dim Code As String = ObjList(i).StateName.ToString.ToUpper()
                        Item.Add(Code)

                    Next
                End If

            End If
a:


            Return Item



        Catch ex As Exception

        Finally
            Item = Nothing

        End Try
    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetCityCode(ByVal prefix As String, ByVal name As String) As List(Of String)
        GetCityCode = Nothing
        Dim Item As New List(Of String)()
        Dim Item1 As New List(Of String)()
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Dim ObjList As List(Of StateMaster)



        Try
            Dim result = prefix.ToCharArray().Length
            If result <= 1 Then
                GoTo a
            End If

            ObjList = OTScheduling.GetCityLst(tmpstrErrMsg, tmpchrErrFlg, HttpContext.Current.Session("COMPANYCODE"), HttpContext.Current.Session("DIVCODE"), HttpContext.Current.Session("LOCCODE"), HttpContext.Current.Session("Statecd"), 0, prefix)


            If ObjList IsNot Nothing Then
                If ObjList.Count > 0 Then

                    For i As Integer = 0 To ObjList.Count - 1
                        Dim Code As String = ObjList(i).CityName.ToString.ToUpper()
                        Item.Add(Code)

                    Next
                End If

            End If
a:
            Return Item



        Catch ex As Exception

        Finally
            Item = Nothing

        End Try
    End Function
    Private Sub ChkRule9370() '#Trupti 14 JUN 2021

        Session("RULEMST9370") = "N"
        Session("RULEMST9372") = "N"
        Dim objRuleMst As New clsRuleMaster
        objRuleMst = OTScheduling.GetRuleMstDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 9370)
        If objRuleMst IsNot Nothing Then
            Session("RULEMST9370") = objRuleMst.Data1
        End If

        objRuleMst = New clsRuleMaster
        objRuleMst = OTScheduling.GetRuleMstDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 9372)
        If objRuleMst IsNot Nothing Then
            Session("RULEMST9372") = objRuleMst.Data1
        End If
    End Sub
    Protected Sub btnClosePopup_Click(sender As Object, e As EventArgs) Handles btnClosePopup.Click '#Trupti 14 JUN 2021
        divPopupIPOPPtntypwisetrn.Visible = False

        upPopupIPOPPtntypwisetrn.Update()
    End Sub


    Private Sub BtnViewOsDtl_Click(sender As Object, e As EventArgs) Handles BtnViewOsDtl.Click '#Trupti 14 JUN 2021
        Try
            If rdbPatientType.SelectedValue <> "I" Then
                Exit Sub
            End If

            Dim COMPANYCODE As String = Session("COMPANYCODE")
            Dim DIVCODE As Integer = Session("DIVCODE")
            Dim LOCCODE As Integer = Session("LOCCODE")
            Dim orgdue As Double
            Dim due As Double

            Dim objlst As List(Of IpPostVoucherServiceReference.clsIpDepRcpt) = New List(Of IpPostVoucherServiceReference.clsIpDepRcpt)
            ' Dim due As Double = 0.0
            due = 0.0

            objlst = clsIpPostVoucher.getBalanceDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtpatid.Text))
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
            If Val(txtpatid.Text) = 0 Then
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

    Private Sub FnUserWsModFnRights()  '#Trupti 14 JUN 2021
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


    Private Sub DispalyOffIcePermission()

        If Session("RULEMST9370") = "N" Then
            lblchkSts.Attributes.Add("style", "display:none")
            chkIsOffPerm.Attributes.Add("style", "display:none")
            txtoffPermRmrk.Attributes.Add("style", "display:none")
            lblIsOffPerm.Attributes.Add("style", "display:none")
        End If

        If Session("RULEMST9372") = "N" Then
            BtnViewOsDtl.Attributes.Add("style", "display:none")
        End If
    End Sub




    'Protected Sub GrdReqDetails_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    regscript()
    'End Sub

    'Protected Sub GrdReqDetails_RowDataBound(sender As Object, e As GridViewRowEventArgs)

    '    If e.Row.RowType = DataControlRowType.Header Then
    '        ' Hiding the Select Button Cell in Header Row.
    '        e.Row.Cells(0).Style.Add(HtmlTextWriterStyle.Display, "none")
    '    End If
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        e.Row.Cells(0).Style.Add(HtmlTextWriterStyle.Display, "none")
    '        e.Row.Attributes.Add("style", "cursor:pointer;")
    '        ' Attaching one onclick event for the entire row, so that it will
    '        ' fire SelectedIndexChanged, while we click anywhere on the row.
    '        e.Row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.GrdReqDetails, "Select$" & e.Row.RowIndex)

    '    End If
    'End Sub
End Class
