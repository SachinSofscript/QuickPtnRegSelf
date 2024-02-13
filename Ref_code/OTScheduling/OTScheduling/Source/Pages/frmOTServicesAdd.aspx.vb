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

Public Class frmOTServicesAdd
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLARATION "
    Dim objcalrateData = New OTSchedulingSerRef.clsCalRate
    Public objArrOTSrvDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
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
    '        objArrOTDoctorsDtls = Nothing
    '        Session("PtnNoChnged") = Nothing
    '        Session("objArrOTSrvDtls") = Nothing
    '        Session("objArrOTDoctorsDtls") = Nothing
    '        Session("IpNoChnged") = Nothing
    '        Session("OTSelected") = Nothing
    '        Session("OTDateSelected") = Nothing
    '        Session("OTStartTmSelected") = Nothing
    '        Session("OTEndTmSelected") = Nothing
    '        Session("OTDocIdSelected") = Nothing
    '        Session("OTDocNameSelected") = Nothing
    '        Session("OTPatIdSelected") = Nothing
    '        Session("OTPatNameSelected") = Nothing
    '        Session("OTHrsSelected") = Nothing
    '        Session("OTMinsSelected") = Nothing
    '        Session("OTStrtTme1Selected") = Nothing
    '        Session("OTApptNoSelected") = Nothing
    '        Session("OTSlotsSelected") = Nothing
    '        Session("OTRemarksSelected") = Nothing
    '        Session("objArrOTDoctorsDtls") = Nothing
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

        If ContentPlaceHolder1_HfSrvCd.Value <> "" And ContentPlaceHolder1_HfSrvDcd.Value <> "" Then
            txtOtSrvCd.Text = ContentPlaceHolder1_HfSrvCd.Value
            txtOtSrvDesc.Text = ContentPlaceHolder1_HfSrvDcd.Value
        End If
        If ContentPlaceHolder1_HfChrgCd.Value <> "" And ContentPlaceHolder1_HfChrgDcd.Value <> "" Then
            txtOtChrgCd.Text = ContentPlaceHolder1_HfChrgCd.Value
            txtOtChrgDesc.Text = ContentPlaceHolder1_HfChrgDcd.Value
        End If

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

            '' Amol 2019-12-17   ''For Maintain All Data 
            Dim objLstSrvDtlsMerge As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
            If Session("objArrOTSrvDtls") IsNot Nothing Then
                objLstSrvDtlsMerge = Session("objArrOTSrvDtls")
            End If
            '' Amol 2019-12-17   ''For Maintain All Data 

            ipopflg = Session("OTIPOPFLAG") 'shital 20211202


            Dim objLstSrvDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
            If Session("OTApptNoSelected") <> "" Then    'if any appnmnt is saved thn only shw the data
                objLstSrvDtls = OTScheduling.GetLstOfOtSrvDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("FctCd"), Session("FctCatCd"), Session("FctMainCd"), Session("OTApptNoSelected"), Session("ActualPtnNo"), Session("OTPatIdSelected"), ipopflg)
                If objLstSrvDtls IsNot Nothing Then
                    If Session("objArrOTSrvDtls") IsNot Nothing Then
                        objLstSrvDtls = Session("objArrOTSrvDtls")

                        '' Amol 2019-12-17   ''For Maintain All Data 
                        If objLstSrvDtlsMerge.Count > objLstSrvDtls.Count Then
                            objLstSrvDtls = objLstSrvDtlsMerge
                        End If
                        '' Amol 2019-12-17   ''For Maintain All Data 

                        grdSrv.DataSource = objLstSrvDtls
                        grdSrv.DataBind()
                        If objLstSrvDtls.Count > 0 Then
                            txtSrvDiagnosis.Text = objLstSrvDtls(0).SrvDiagnosis
                        End If
                        Session("objArrOTSrvDtls") = objLstSrvDtls
                        Exit Sub
                    Else
                        Session("objArrOTSrvDtls") = objLstSrvDtls
                        grdSrv.DataSource = objLstSrvDtls
                        grdSrv.DataBind()
                        If objLstSrvDtls.Count > 0 Then
                            txtSrvDiagnosis.Text = objLstSrvDtls(0).SrvDiagnosis
                        End If
                        Exit Sub
                    End If
                Else
                    If Session("objArrOTSrvDtls") IsNot Nothing Then
                        objLstSrvDtls = Session("objArrOTSrvDtls")
                        grdSrv.DataSource = objLstSrvDtls
                        grdSrv.DataBind()
                        If objLstSrvDtls.Count > 0 Then
                            txtSrvDiagnosis.Text = objLstSrvDtls(0).SrvDiagnosis
                        End If
                        Exit Sub
                    End If
                End If
            Else
                If Session("objArrOTSrvDtls") IsNot Nothing Then
                    objLstSrvDtls = Session("objArrOTSrvDtls")
                    grdSrv.DataSource = objLstSrvDtls
                    grdSrv.DataBind()

                    If objLstSrvDtls.Count > 0 Then
                        txtSrvDiagnosis.Text = objLstSrvDtls(0).SrvDiagnosis
                    End If
                End If

            End If
        End If

        If grdSrv.Rows.Count <= 0 Then
            DefaultGridDatabind(grdSrv)
        End If

    End Sub
#End Region

#Region "TEXTBOX EVENTS" 'pragya : 12-oct-2016
    Protected Sub txtOtSrvCd_TextChanged(sender As Object, e As EventArgs) Handles txtOtSrvCd.TextChanged
        Try
            'If Val(txtOtSrvCd.Text) > 0 And txtOtSrvDesc.Text <> "" Then
            If Val(txtOtSrvCd.Text) > 0 Then
                Dim objSrvParamDtls As List(Of OTSchedulingSerRef.clsFctAptOtSrvprm)
                objSrvParamDtls = Nothing
                objSrvParamDtls = OTScheduling.GetListOfOTSrvParamDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtOtChrgCd.Text), Val(txtOtSrvCd.Text))
                If objSrvParamDtls IsNot Nothing Then
                    If objSrvParamDtls.Count > 1 Then
                        ddlAddtnInfo.Enabled = True
                        ddlAddtnInfo.Focus()
                    Else
                        ddlAddtnInfo.Enabled = False
                    End If
                    clsGeneral.FillDropDownList(ddlAddtnInfo, "ParamNm", "SrNo", objSrvParamDtls, 0)

                Else
                    ddlAddtnInfo.Enabled = False
                End If

                'MpOtServices.Show()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
#End Region

#Region "FUNCTIONS" 'pragya : 11 -oct-2016
    Private Sub clearSrvInfo()
        txtOtSrvCd.Text = ""
        txtOtSrvDesc.Text = ""
        txtOtChrgCd.Text = ""
        txtOtChrgDesc.Text = ""
        ContentPlaceHolder1_HfSrvCd.Value = ""
        ContentPlaceHolder1_HfSrvDcd.Value = ""
        ContentPlaceHolder1_HfChrgCd.Value = ""
        ContentPlaceHolder1_HfChrgDcd.Value = ""
        ddlAddtnInfo.DataSource = Nothing
        ddlAddtnInfo.DataBind()
        ddlAddtnInfo.SelectedIndex = 0
        ddlAddtnInfo.Enabled = False
        txtOtSrvCd.Focus()
    End Sub

    Public Sub loadErrorMsg()
        arrobjMsgMst = New List(Of clsMsgMst)
        arrobjMsgMst = clsGeneral.GetmsgmstList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"))
        If arrobjMsgMst IsNot Nothing Then
            Session("ErrorMsg") = arrobjMsgMst
        End If
        arrobjMsgMst = Nothing
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

#Region "BUTTON EVENTS"
    Protected Sub btnAddSrv_Click(sender As Object, e As EventArgs) Handles btnAddSrv.Click
        Try
            If Trim(txtOtSrvCd.Text) = "" And txtOtSrvDesc.Text <> "" Then
                ' enter VALID SERVICE CODE
                txtOtSrvCd.Focus()
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 13), "txtOtSrvCd", Page)
                'MpOtServices.Show()

                Exit Sub
            End If

            If Trim(txtOtChrgCd.Text) = "" Then
                ' ENTERED CHARGE CODE IS NOT VALID
                txtOtSrvCd.Focus()
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 14), "txtOtChrgCd", Page)
                'MpOtServices.Show()
                Exit Sub
            End If


            If ddlAddtnInfo.Enabled = True Then
                If ddlAddtnInfo.SelectedItem.ToString = "SELECT" Then
                    ' seelct ADDITION AL INFO
                    ddlAddtnInfo.Focus()
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 15), "txtOtChrgCd", Page)
                    ' MpOtServices.Show()
                    Exit Sub
                End If

            End If



            'GET THE RATE OF SELECTED SRV_CD & CHRGCD
            Dim objcalrate = New OTSchedulingSerRef.clsCalRate
            objcalrate.lvChrgCd = Integer.Parse(txtOtChrgCd.Text)
            objcalrate.lvSrvCd = Integer.Parse(txtOtSrvCd.Text)
            objcalrate.lvIpNo = Session("IpNoChnged")
            objcalrate.AdmissionDate = Date.Today '(same as postvch)

            'GET PTNCLSCD
            Dim objPtnCls = New clsPtnVstPtnClsDtl
            objPtnCls = OTScheduling.GetPtnClsCdFrmIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt64(Session("IpNoChnged")))
            If objPtnCls IsNot Nothing Then
                objcalrate.lvPtnClsCd = objPtnCls.PtnClsCd
                Session("PtnNoChnged") = objPtnCls.PtnNo
            Else
                objcalrate.lvPtnClsCd = 0
            End If
            'GET ARCD
            Dim iArCdPtn As Integer = OTScheduling.GetArCdCdFrmIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt64(Session("IpNoChnged")))
            objcalrate.lvArCd = iArCdPtn

            objcalrateData = OTScheduling.GetCalRate(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), objcalrate, "N")
            If objcalrateData Is Nothing Then
                clearSrvInfo()
                'ENTER RECORD IN SRV RATE MST
                txtOtSrvCd.Focus()

                If chrErrFlg = "Y" And strErrMsg.Count > 0 Then
                    clsGeneral.ShowErrorPopUp(strErrMsg(0).ToString, "txtOtChrgCd", Page)
                Else
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 16), "txtOtChrgCd", Page)
                End If


                'clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 16), "txtOtChrgCd", Page)
                ' MpOtServices.Show()
                Exit Sub

            Else
                '  If strErrMsg
            End If


            If Session("objArrOTSrvDtls") IsNot Nothing Then
                objArrOTSrvDtls = Session("objArrOTSrvDtls")
                'If objArrOTSrvDtls.Count > 0 Then
                If ddlAddtnInfo.Enabled = True And ddlAddtnInfo.SelectedItem.ToString <> "SELECT" Then
                    Dim x = From obj In objArrOTSrvDtls Where obj.srvcd = txtOtSrvCd.Text And obj.chrgcd = txtOtChrgCd.Text And obj.AnesTypDesc = ddlAddtnInfo.SelectedItem.ToString Select obj
                    If x.Any() = True Then
                        ' Duplicate service code nt allowed
                        txtOtSrvCd.Focus()
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 17), "txtOtSrvCd", Page)
                        ' MpOtServices.Show()
                        Exit Sub
                    End If
                Else
                    Dim x = From obj In objArrOTSrvDtls Where obj.srvcd = txtOtSrvCd.Text And obj.chrgcd = txtOtChrgCd.Text And obj.AnesTypDesc = ddlAddtnInfo.SelectedItem.ToString Select obj
                    If x.Any() = True Then
                        ' Duplicate service code nt allowed
                        txtOtSrvCd.Focus()
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 18), "txtOtSrvCd", Page)
                        ' MpOtServices.Show()
                        Exit Sub
                    End If
                End If



                Dim objSrv = New OTSchedulingSerRef.ClsOtSrvLstDtls
                If objcalrateData IsNot Nothing Then
                    objSrv.SrvRate = objcalrateData.Rate
                Else
                    objSrv.SrvRate = 0
                End If
                If ddlAddtnInfo.Enabled = True Then
                    objSrv.AnesTypCd = ddlAddtnInfo.SelectedIndex
                    objSrv.AnesTypDesc = IIf(ddlAddtnInfo.SelectedItem.ToString <> "", ddlAddtnInfo.SelectedItem.ToString, "")
                Else
                    objSrv.AnesTypCd = 0
                    objSrv.AnesTypDesc = ""
                End If
                objSrv.chrgcd = txtOtChrgCd.Text
                objSrv.ChrgDesc = txtOtChrgDesc.Text
                objSrv.srvcd = txtOtSrvCd.Text
                objSrv.srvdesc = txtOtSrvDesc.Text
                objSrv.SrvTypCd = ContentPlaceHolder1_HfSrvTypCd.Value
                objSrv.SrvTypDesc = ContentPlaceHolder1_HfSrvTypDcd.Value

                objArrOTSrvDtls.Add(objSrv)

                grdSrv.DataSource = objArrOTSrvDtls
                grdSrv.DataBind()

                Session("objArrOTSrvDtls") = objArrOTSrvDtls
            Else

                Dim objSrv = New OTSchedulingSerRef.ClsOtSrvLstDtls
                If objcalrateData IsNot Nothing Then
                    objSrv.SrvRate = objcalrateData.Rate
                Else
                    objSrv.SrvRate = 0
                End If
                If ddlAddtnInfo.Enabled = True Then
                    objSrv.AnesTypCd = ddlAddtnInfo.SelectedIndex
                    objSrv.AnesTypDesc = IIf(ddlAddtnInfo.SelectedItem.ToString <> "", ddlAddtnInfo.SelectedItem.ToString, "")
                Else
                    objSrv.AnesTypCd = 0
                    objSrv.AnesTypDesc = ""
                End If
                objSrv.chrgcd = txtOtChrgCd.Text
                objSrv.ChrgDesc = txtOtChrgDesc.Text
                objSrv.srvcd = txtOtSrvCd.Text
                objSrv.srvdesc = txtOtSrvDesc.Text
                objSrv.SrvTypCd = ContentPlaceHolder1_HfSrvTypCd.Value
                objSrv.SrvTypDesc = ContentPlaceHolder1_HfSrvTypDcd.Value

                objArrOTSrvDtls.Add(objSrv)

                grdSrv.DataSource = objArrOTSrvDtls
                grdSrv.DataBind()

                Session("objArrOTSrvDtls") = objArrOTSrvDtls

            End If

            clearSrvInfo()
            ' MpOtServices.Show()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "OTSrvDtls", Page)
        End Try

    End Sub

    Protected Sub btnOtSrvOk_Click(sender As Object, e As EventArgs) Handles btnOtSrvOk.Click
        Try
            ' If txtSrvDiagnosis.Text <> "" Then   ;Session("objArrOTSrvDtls")
            ContentPlaceHolder1_HfSrvCd.Value = ""
            ContentPlaceHolder1_HfSrvDcd.Value = ""
            ContentPlaceHolder1_HfChrgCd.Value = ""
            ContentPlaceHolder1_HfChrgDcd.Value = ""
            If Session("objArrOTSrvDtls") IsNot Nothing Then
                objArrOTSrvDtls = Session("objArrOTSrvDtls")
                ' For i As Integer = 1 To 1 commented by shital it was adding remark fr only oth index service
                For i As Integer = 0 To objArrOTSrvDtls.Count - 1
                    objArrOTSrvDtls(i).SrvDiagnosis = txtSrvDiagnosis.Text
                Next
                grdSrv.DataSource = objArrOTSrvDtls
                grdSrv.DataBind()

                Session("objArrOTSrvDtls") = objArrOTSrvDtls
            End If
            '  End If
            txtflag.Value = "A"
            'Response.Redirect("OtScheduling.aspx")
            ScriptManager.RegisterClientScriptBlock(UPOTServices, UPOTServices.GetType(), "scr12", "parent.closeAppWindow();", True) 'RasikV 20170127

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "OTSrvDtls", Page)
        End Try


        'Try
        '    If Session("objArrOTDoctorsDtls") IsNot Nothing Then
        '        If ddlOtDocAneshthsia.SelectedItem.ToString = "Select" Then
        '            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 20), "txtOtDoc", Page)
        '            ddlOtDocAneshthsia.Focus()
        '            'clsGeneral.ShowErrorPopUp("Select DocAneshthsia", "txtOtDoc", Page)
        '            'MpOtDoctors.Show()
        '            Exit Sub
        '        End If

        '        objArrOTDoctorsDtls = Session("objArrOTDoctorsDtls")
        '        For i As Integer = 0 To objArrOTDoctorsDtls.Count - 1
        '            objArrOTDoctorsDtls(i).NurseName = txtOtDocNurseName.Text
        '            objArrOTDoctorsDtls(i).AnesthesiaCd = ddlOtDocAneshthsia.SelectedValue
        '            objArrOTDoctorsDtls(i).AnesthesiaDesc = ddlOtDocAneshthsia.SelectedItem.ToString
        '        Next
        '        grdOtDoc.DataSource = objArrOTDoctorsDtls
        '        grdOtDoc.DataBind()

        '        Session("objArrOTDoctorsDtls") = objArrOTDoctorsDtls

        '    End If

        '    Response.Redirect("OtScheduling.aspx")

        'Catch ex As Exception
        '    clsGeneral.ShowErrorPopUp(Replace(

    End Sub

    Protected Sub btnOtSrvExit_Click(sender As Object, e As EventArgs) Handles btnOtSrvExit.Click
        ' clearSrvInfo()
        'MpOtServices.Hide()
    End Sub
#End Region

#Region "GRID EVENTS"
    Protected Sub grdSrv_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdSrv.RowCommand
        Try
            Dim row As GridViewRow
            If e.CommandName = "deleteROW" Then
                Dim lbl As Label
                row = DirectCast((e.CommandSource), ImageButton).NamingContainer
                lbl = DirectCast(row.FindControl("grdlblRate"), Label)

                If Session("objArrOTSrvDtls") IsNot Nothing Then          'WHEN DATA IS DIRECTLY ADDED IN GRID BY USER
                    objArrOTSrvDtls = Session("objArrOTSrvDtls")
                    objArrOTSrvDtls.RemoveAt(row.RowIndex)
                    If objArrOTSrvDtls.Count = 0 Then
                        objArrOTSrvDtls = Nothing
                    End If
                    grdSrv.DataSource = objArrOTSrvDtls
                    grdSrv.DataBind()
                    Session("objArrOTSrvDtls") = objArrOTSrvDtls

                End If
            End If

            If objArrOTSrvDtls Is Nothing Then
                DefaultGridDatabind(grdSrv)
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
        'Try
        '    Dim row As GridViewRow
        '    'If e.CommandName = "delete" Then
        '    '    row = DirectCast((e.CommandSource), ImageButton).NamingContainer
        '    '    If Session("objArrOTSrvDtls") IsNot Nothing Then          'WHEN DATA IS DIRECTLY ADDED IN GRID BY USER
        '    '        objArrOTSrvDtls = Session("objArrOTSrvDtls")
        '    '        objArrOTSrvDtls.RemoveAt(row.RowIndex)
        '    '        If objArrOTSrvDtls.Count = 0 Then
        '    '            objArrOTSrvDtls = Nothing
        '    '        End If
        '    '        grdSrv.DataSource = objArrOTSrvDtls
        '    '        grdSrv.DataBind()
        '    '        Session("objArrOTSrvDtls") = objArrOTSrvDtls

        '    '    End If
        '    'End If

        '    'If objArrOTSrvDtls Is Nothing Then
        '    '    DefaultGridDatabind(grdSrv)
        '    'End If
        'Catch ex As Exception
        '    clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        'End Try
    End Sub



    Private Sub grdSrv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSrv.RowDataBound
        If Session("IsHideRate") = True Then 'Trupti 15 JUN 2021
            For I = 0 To grdSrv.Columns.Count
                If grdSrv.Columns(I).HeaderText = "RATE" Then
                    grdSrv.Columns(I).Visible = False
                    Exit For
                End If
            Next
        End If
    End Sub
#End Region





End Class