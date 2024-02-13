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
#End Region

Public Class frmOTDoctorsAdd
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLARATION "
    'Dim objcalrateData = New OTSchedulingSerRef.clsCalRate
    'Public objArrOTSrvDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
    Public objArrOTDoctorsDtls As New List(Of OTSchedulingSerRef.clsOtDocDtls)
    Public objArrOTDoctorsDtls1 As New List(Of OTSchedulingSerRef.clsOtDocDtls)
    Shared patid As String
    Shared patname As String
    Shared docid As String
    Shared docname As String
    Shared aptno As String
    Shared ipopflg As String
    Shared oldfctcode As String
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Public arrobjMsgMst As List(Of clsMsgMst)
    'objArrOTSrvDtls = Nothing
    '           objArrOTDoctorsDtls = Nothing
    '           Session("PtnNoChnged") = Nothing
    '           Session("objArrOTSrvDtls") = Nothing
    '           Session("objArrOTDoctorsDtls") = Nothing
    '           Session("IpNoChnged") = Nothing
    '           Session("OTSelected") = Nothing
    '           Session("OTDateSelected") = Nothing
    '           Session("OTStartTmSelected") = Nothing
    '           Session("OTEndTmSelected") = Nothing
    '           Session("OTDocIdSelected") = Nothing
    '           Session("OTDocNameSelected") = Nothing
    '           Session("OTPatIdSelected") = Nothing
    '           Session("OTPatNameSelected") = Nothing
    '           Session("OTHrsSelected") = Nothing
    '           Session("OTMinsSelected") = Nothing
    '           Session("OTStrtTme1Selected") = Nothing
    '           Session("OTApptNoSelected") = Nothing
    '           Session("OTSlotsSelected") = Nothing
    '           Session("OTRemarksSelected") = Nothing
    '           Session("objArrOTDoctorsDtls") = Nothing
#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CSS_serverpath As String = System.Configuration.ConfigurationManager.AppSettings("CSS_serverpath")
        ''''cssMaster.Attributes.Add("href", CSS_serverpath & "/Master.css")
        ''''cssMaster.Attributes.Add("typ", "text/css")
        'CssCommon.Attributes.Add("href", CSS_serverpath & "/stylesheet.css")
        'CssCommon.Attributes.Add("typ", "text/css")
        'CssButton.Attributes.Add("href", CSS_serverpath & "/ButtonStyles.css")
        'CssButton.Attributes.Add("typ", "text/css")
        'cssAlertifyBoot.Attributes.Add("href", CSS_serverpath & "/alertify.bootstrap.css")
        'cssAlertifyBoot.Attributes.Add("typ", "text/css")
        'cssAlertify.Attributes.Add("href", CSS_serverpath & "/alertify.core.css")
        'cssAlertify.Attributes.Add("typ", "text/css")

        If Not IsPostBack Then
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            clsGeneral.CheckSession(Me.Context, Session("USERID"))
            clsGeneral.SetDefaultSessionValue(ContentPlaceHolder1_HfAppMdCd, ContentPlaceHolder1_HfAppSubMdCd, Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
            If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
                Exit Sub
            End If
            loadErrorMsg()

            Dim objCdDcd As List(Of OTSchedulingSerRef.clsCodeDecode)
            objCdDcd = OTScheduling.GetCodeDeCodeList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), OTSchedulingSerRef.EnumCodeDecode.AnesthesiaTypes)

            If objCdDcd IsNot Nothing Then
                clsGeneral.FillDropDownList(ddlOtDocAneshthsia, "Decode", "Code", objCdDcd, 1, "Select")
            End If
            Dim objCdDcd1 As List(Of OTSchedulingSerRef.clsCodeDecode)
            objCdDcd1 = OTScheduling.GetCodeDeCodeList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), OTSchedulingSerRef.EnumCodeDecode.SurgeonType)

            If objCdDcd IsNot Nothing Then
                clsGeneral.FillDropDownList(ddlsurgntype, "Decode", "Code", objCdDcd1, 1, "Select")
            End If
            '' Amol 2019-12-17   ''For Maintain All Data 
            Dim objDocSvdLstMerge As New List(Of OTSchedulingSerRef.clsOtDocDtls)
            If Session("objArrOTDoctorsDtls") IsNot Nothing Then
                objDocSvdLstMerge = Session("objArrOTDoctorsDtls")
            End If
            '' Amol 2019-12-17   ''For Maintain All Data 

            ipopflg = Session("OTIPOPFLAG")

            Session("SHIFTFLAG") = "False"

            Dim objDocSvdLst As New List(Of OTSchedulingSerRef.clsOtDocDtls)
            If Session("OTApptNoSelected") <> "" Then    'if any appnmnt is saved thn only shw the data
                objDocSvdLst = OTScheduling.GetLstOfOtDocDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("FctCd"), Session("FctCatCd"), Session("FctMainCd"), Session("OTApptNoSelected"), Session("ActualPtnNo"), Session("OTPatIdSelected"), ipopflg)
                If objDocSvdLst IsNot Nothing Then
                    If Session("objArrOTDoctorsDtls") IsNot Nothing Then
                        objDocSvdLst = Session("objArrOTDoctorsDtls")

                        '' Amol 2019-12-17   ''For Maintain All Data 
                        If objDocSvdLstMerge.Count > objDocSvdLst.Count Then
                            objDocSvdLst = objDocSvdLstMerge
                        End If
                        '' Amol 2019-12-17   ''For Maintain All Data 

                        grdOtDoc.DataSource = objDocSvdLst
                        grdOtDoc.DataBind()
                        If objDocSvdLst.Count > 0 Then
                            txtOtDocNurseName.Text = objDocSvdLst(0).NurseName
                            ddlOtDocAneshthsia.SelectedValue = objDocSvdLst(0).AnesthesiaCd

                        End If
                        Session("objArrOTDoctorsDtls") = objDocSvdLst
                        Exit Sub
                    Else
                        Session("objArrOTDoctorsDtls") = objDocSvdLst
                        grdOtDoc.DataSource = objDocSvdLst
                        grdOtDoc.DataBind()
                        If objDocSvdLst.Count > 0 Then
                            txtOtDocNurseName.Text = objDocSvdLst(0).NurseName
                            ddlOtDocAneshthsia.SelectedValue = objDocSvdLst(0).AnesthesiaCd

                        End If
                        Exit Sub
                    End If
                Else
                    If Session("objArrOTDoctorsDtls") IsNot Nothing Then
                        objDocSvdLst = Session("objArrOTDoctorsDtls")
                        grdOtDoc.DataSource = objDocSvdLst
                        grdOtDoc.DataBind()

                        If objDocSvdLst.Count > 0 Then
                            txtOtDocNurseName.Text = objDocSvdLst(0).NurseName
                            ddlOtDocAneshthsia.SelectedValue = objDocSvdLst(0).AnesthesiaCd

                        End If
                    End If
                End If

            Else
                If Session("objArrOTDoctorsDtls") IsNot Nothing Then
                    objDocSvdLst = Session("objArrOTDoctorsDtls")
                    grdOtDoc.DataSource = objDocSvdLst
                    grdOtDoc.DataBind()

                    If objDocSvdLst.Count > 0 Then
                        txtOtDocNurseName.Text = objDocSvdLst(0).NurseName
                        ddlOtDocAneshthsia.SelectedValue = objDocSvdLst(0).AnesthesiaCd

                    End If
                End If

            End If
        End If

        If grdOtDoc.Rows.Count <= 0 Then
            DefaultGridDatabind(grdOtDoc)
        End If
        txtOtDoc.Focus()
    End Sub
#End Region

#Region "TEXTBOX EVENTS"
    Protected Sub txtOtDoc_TextChanged(sender As Object, e As EventArgs) Handles txtOtDoc.TextChanged
        'GetOtDocSpltyByDocCd
        If txtOtDoc.Text <> "" Then
            Dim objDcd As OTSchedulingSerRef.clsOtDocDtls
            objDcd = Nothing
            objDcd = OTScheduling.GetOtDocSpltyByDocCd(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtOtDoc.Text))
            If objDcd IsNot Nothing Then
                txtOtDocName.Text = objDcd.DoctorFullName
                txtOtDocSpltyCd.Text = objDcd.SpecialityCode
                txtOtDocSpltyDesc.Text = objDcd.SpecialityCodeDesc
                'MpOtDoctors.Show()
            Else
                txtOtDocName.Text = ""
                txtOtDocSpltyCd.Text = ""
                txtOtDocSpltyDesc.Text = ""
                txtOtDoc.Text = ""
                ddlsurgntype.SelectedItem.Text = ""
                'enter valid doc cd
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 4), "txtOtDoc", Page)
                txtOtDoc.Focus()
                ' clsGeneral.ShowErrorPopUp("enter valid doc cd", "txtOtDoc", Page)
                'MpOtDoctors.Show()
                'Exit Sub
            End If
        End If



    End Sub
#End Region

#Region "BUTTON EVENTS"
    Protected Sub btnOtDocAdd_Click(sender As Object, e As EventArgs) Handles btnOtDocAdd.Click
        Try
            If Trim(txtOtDoc.Text) = "" And txtOtDocName.Text = "" Then
                ' enter VALID docotr CODE
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 4), "txtOtDoc", Page)
                txtOtDoc.Focus()

                'clsGeneral.ShowErrorPopUp("enter VALID docotr CODE", "txtOtDoc", Page)
                'MpOtDoctors.Show()
                Exit Sub
            End If
            If ddlsurgntype.SelectedItem.ToString = "Select" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 54), "ddlsurgntype", Page)
                ddlsurgntype.Focus()
                Exit Sub
            End If
            'clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 4), "ddlsurgntype", Page)
            'ddlsurgntype.Focus()
            If Session("objArrOTDoctorsDtls") IsNot Nothing Then
                objArrOTDoctorsDtls = Session("objArrOTDoctorsDtls")

                Dim x = From obj In objArrOTDoctorsDtls Where obj.DoctorCode = txtOtDoc.Text Select obj
                If x.Any() = True Then
                    ' Duplicate service code nt allowed
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 19), "txtOtDoc", Page)
                    txtOtDoc.Focus()
                    txtOtDoc.Text = ""
                    txtOtDocName.Text = ""
                    'MpOtDoctors.Show()
                    'clsGeneral.ShowErrorPopUp("Duplicate Doctor code nt allowed", "txtOtDoc", Page)
                    Exit Sub
                End If

                Dim objDoctors = New OTSchedulingSerRef.clsOtDocDtls
                objDoctors.DoctorCode = Val(txtOtDoc.Text)
                objDoctors.DoctorFullName = txtOtDocName.Text
                objDoctors.SpecialityCode = Val(txtOtDocSpltyCd.Text)
                objDoctors.SpecialityCodeDesc = txtOtDocSpltyDesc.Text
                objDoctors.SurgnTypDcd = ddlsurgntype.SelectedItem.ToString
                objDoctors.SurgnTypCd = Val(ddlsurgntype.SelectedValue)
                objArrOTDoctorsDtls.Add(objDoctors)

                grdOtDoc.DataSource = objArrOTDoctorsDtls
                grdOtDoc.DataBind()

                Session("objArrOTDoctorsDtls") = objArrOTDoctorsDtls

            Else

                Dim objDoctors = New OTSchedulingSerRef.clsOtDocDtls
                objDoctors.DoctorCode = Val(txtOtDoc.Text)
                objDoctors.DoctorFullName = txtOtDocName.Text
                objDoctors.SpecialityCode = Val(txtOtDocSpltyCd.Text)
                objDoctors.SpecialityCodeDesc = txtOtDocSpltyDesc.Text
                objDoctors.SurgnTypDcd = ddlsurgntype.SelectedItem.ToString
                objDoctors.SurgnTypCd = Val(ddlsurgntype.SelectedValue)
                objArrOTDoctorsDtls.Add(objDoctors)

                grdOtDoc.DataSource = objArrOTDoctorsDtls
                grdOtDoc.DataBind()

                Session("objArrOTDoctorsDtls") = objArrOTDoctorsDtls

            End If



            clearDoctorInfo()
            'If Session("objArrOTDoctorsDtls1") IsNot Nothing Then
            '    If grdOtDoc.Rows.Count <> 0 Then
            '        If ddlsurgntype.SelectedItem.ToString = "Select" Then
            '            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 20), "txtOtDoc", Page)
            '            ddlsurgntype.Focus()
            '            'clsGeneral.ShowErrorPopUp("Select DocAneshthsia", "txtOtDoc", Page)
            '            'MpOtDoctors.Show()
            '            Exit Sub
            '        End If
            '    End If

            '    objArrOTDoctorsDtls1 = Session("objArrOTDoctorsDtls1")
            '    For i As Integer = 0 To objArrOTDoctorsDtls1.Count - 1
            '        objArrOTDoctorsDtls1(i).SurgnTypDcd = ddlsurgntype.SelectedItem.Text = -1

            '    Next
            '    grdOtDoc.DataSource = objArrOTDoctorsDtls1
            '    grdOtDoc.DataBind()

            '    Session("objArrOTDoctorsDtls1") = objArrOTDoctorsDtls1
            'Else


            '    Dim objDoctors1 = New OTSchedulingSerRef.clsOtDocDtls
            '    objDoctors1.SurgnTypDcd = ddlsurgntype.SelectedItem.Text = -1

            '    objArrOTDoctorsDtls1.Add(objDoctors1)

            '    Session("objArrOTDoctorsDtls1") = objArrOTDoctorsDtls1
            'End If
            'MpOtDoctors.Show()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "txtOtDoc", Page)
        End Try
    End Sub

    Protected Sub btnOtDocExit_Click(sender As Object, e As EventArgs) Handles btnOtDocExit.Click
        'MpOtDoctors.Hide()
    End Sub

    Protected Sub btnOtDocOk_Click(sender As Object, e As EventArgs) Handles btnOtDocOk.Click
        Try
            If Session("objArrOTDoctorsDtls") IsNot Nothing Then
                If grdOtDoc.Rows.Count <> 0 Then
                    If ddlOtDocAneshthsia.SelectedItem.ToString = "Select" Then
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 20), "txtOtDoc", Page)
                        ddlOtDocAneshthsia.Focus()
                        Exit Sub
                    End If

                End If


                objArrOTDoctorsDtls = Session("objArrOTDoctorsDtls")
                For i As Integer = 0 To objArrOTDoctorsDtls.Count - 1
                    objArrOTDoctorsDtls(i).NurseName = txtOtDocNurseName.Text
                    objArrOTDoctorsDtls(i).AnesthesiaCd = ddlOtDocAneshthsia.SelectedValue
                    objArrOTDoctorsDtls(i).AnesthesiaDesc = ddlOtDocAneshthsia.SelectedItem.ToString
                   
                Next
                grdOtDoc.DataSource = objArrOTDoctorsDtls
                grdOtDoc.DataBind()

                Session("objArrOTDoctorsDtls") = objArrOTDoctorsDtls
            Else


                Dim objDoctors = New OTSchedulingSerRef.clsOtDocDtls
                objDoctors.NurseName = txtOtDocNurseName.Text
                objDoctors.AnesthesiaCd = ddlOtDocAneshthsia.SelectedValue
                objDoctors.AnesthesiaDesc = ddlOtDocAneshthsia.SelectedItem.ToString
               
                objArrOTDoctorsDtls.Add(objDoctors)

                Session("objArrOTDoctorsDtls") = objArrOTDoctorsDtls
            End If
            'Response.Redirect("OtScheduling.aspx?Mode")
            ScriptManager.RegisterClientScriptBlock(UPOTDoc, UPOTDoc.GetType(), "scr12", "parent.closeAppWindow();", True) 'RasikV 20170127

            'Response.Redirect("OtScheduling.aspx?otno=" + txtot.Text + "&patid=" + getindirectbooking(i).PtnNo.ToString() + "&docid=" + getindirectbooking(i).DocCd.ToString() + " &patname=" + getindirectbooking(i).PtnFullNm.ToString() + " &docname=" + getindirectbooking(i).DocFullNm.ToString() + " &expdate=" + getindirectbooking(i).ExpectedDate.Date.ToShortDateString() + "&TrnNo=" + getindirectbooking(i).TrnNo.ToString() + " &PtnActualPtnNo=" + getindirectbooking(i).PtnActualPtnNo.ToString() + "")
            ddlsurgntype.Focus()

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "txtOtDoc", Page)
            Exit Sub
        End Try
    End Sub
#End Region

#Region "FUNCTIONS" 'PRAGYA : 02-AUG-2016
    Public Sub loadErrorMsg()
        arrobjMsgMst = New List(Of clsMsgMst)
        arrobjMsgMst = clsGeneral.GetmsgmstList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
        If arrobjMsgMst IsNot Nothing Then
            Session("ErrorMsg") = arrobjMsgMst
        End If
        arrobjMsgMst = Nothing
    End Sub

    Private Sub clearDoctorInfo()
        txtOtDoc.Text = ""
        txtOtDocName.Text = ""
        txtOtDocSpltyCd.Text = ""
        txtOtDocSpltyDesc.Text = ""
        txtOtDoc.Focus()
        ddlsurgntype.SelectedValue = "Select"
    End Sub

    Public Sub DefaultGridDatabind(ByVal grd As GridView)
        Try
            grd.DataSource = New List(Of String)
            grd.DataBind()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
#End Region

#Region "GRID EVENTS"
    Protected Sub grdOtDoc_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdOtDoc.RowCommand
        Try
            Dim row As GridViewRow
            If e.CommandName = "delete" Then
                row = DirectCast((e.CommandSource), ImageButton).NamingContainer
                If Session("objArrOTDoctorsDtls") IsNot Nothing Then          'WHEN DATA IS DIRECTLY ADDED IN GRID BY USER
                    objArrOTDoctorsDtls = Session("objArrOTDoctorsDtls")
                    objArrOTDoctorsDtls.RemoveAt(row.RowIndex)
                    If objArrOTDoctorsDtls.Count = 0 Then
                        objArrOTDoctorsDtls = Nothing
                    End If
                    grdOtDoc.DataSource = objArrOTDoctorsDtls
                    grdOtDoc.DataBind()
                    Session("objArrOTDoctorsDtls") = objArrOTDoctorsDtls

                End If
            End If

            If objArrOTDoctorsDtls Is Nothing Then
                DefaultGridDatabind(grdOtDoc)
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Protected Sub grdOtDoc_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdOtDoc.RowDeleting

    End Sub

    Protected Sub ddlsurgntype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlsurgntype.SelectedIndexChanged


    End Sub
#End Region

End Class