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

Public Class frmOTEmpAdd
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLARATION "
    Public objArrOTEmpDtls As New List(Of OTSchedulingSerRef.clsFctAptOtEmpDtls)
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
#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim CSS_serverpath As String = System.Configuration.ConfigurationManager.AppSettings("CSS_serverpath")
        '''''''cssMaster.Attributes.Add("href", CSS_serverpath & "/Master.css")
        '''''''cssMaster.Attributes.Add("typ", "text/css")
        'CssCommon.Attributes.Add("href", CSS_serverpath & "/stylesheet.css")
        'CssCommon.Attributes.Add("typ", "text/css")
        'CssButton.Attributes.Add("href", CSS_serverpath & "/ButtonStyles.css")
        'CssButton.Attributes.Add("typ", "text/css")
        'cssAlertifyBoot.Attributes.Add("href", CSS_serverpath & "/alertify.bootstrap.css")
        'cssAlertifyBoot.Attributes.Add("typ", "text/css")
        'cssAlertify.Attributes.Add("href", CSS_serverpath & "/alertify.core.css")
        'cssAlertify.Attributes.Add("typ", "text/css")

        'If ContentPlaceHolder1_HfSrvCd.Value <> "" And ContentPlaceHolder1_HfSrvDcd.Value <> "" Then
        '    txtOtSrvCd.Text = ContentPlaceHolder1_HfSrvCd.Value
        '    txtOtSrvDesc.Text = ContentPlaceHolder1_HfSrvDcd.Value
        'End If
        'If ContentPlaceHolder1_HfChrgCd.Value <> "" And ContentPlaceHolder1_HfChrgDcd.Value <> "" Then
        '    txtOtChrgCd.Text = ContentPlaceHolder1_HfChrgCd.Value
        '    txtOtChrgDesc.Text = ContentPlaceHolder1_HfChrgDcd.Value
        'End If

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
            Dim objLstSrvDtlsMerge As New List(Of OTSchedulingSerRef.clsFctAptOtEmpDtls)
            If Session("objArrOTEmpDtls") IsNot Nothing Then
                objLstSrvDtlsMerge = Session("objArrOTEmpDtls")
            End If
            '' Amol 2019-12-17   ''For Maintain All Data 

            ipopflg = Session("OTIPOPFLAG") 'shital 20211202

            Dim objLstSrvDtls As New List(Of OTSchedulingSerRef.clsFctAptOtEmpDtls)
            If Session("OTApptNoSelected") <> "" Then    'if any appnmnt is saved thn only shw the data
                objLstSrvDtls = OTScheduling.GetLstOfOtEmpDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("FctCd"), Session("FctCatCd"), Session("FctMainCd"), Session("OTApptNoSelected"), Session("ActualPtnNo"), Session("OTPatIdSelected"), ipopflg)
                If objLstSrvDtls IsNot Nothing Then
                    If Session("objArrOTEmpDtls") IsNot Nothing Then
                        objLstSrvDtls = Session("objArrOTEmpDtls")

                        '' Amol 2019-12-17   ''For Maintain All Data 
                        If objLstSrvDtlsMerge.Count > objLstSrvDtls.Count Then
                            objLstSrvDtls = objLstSrvDtlsMerge
                        End If
                        '' Amol 2019-12-17   ''For Maintain All Data 

                        grdEmp.DataSource = objLstSrvDtls
                        grdEmp.DataBind()
                        'If objLstSrvDtls.Count > 0 Then
                        '    txtSrvDiagnosis.Text = objLstSrvDtls(0).SrvDiagnosis
                        'End If
                        Session("objArrOTEmpDtls") = objLstSrvDtls
                        Exit Sub
                    Else
                        Session("objArrOTEmpDtls") = objLstSrvDtls
                        grdEmp.DataSource = objLstSrvDtls
                        grdEmp.DataBind()
                        'If objLstSrvDtls.Count > 0 Then
                        '    txtSrvDiagnosis.Text = objLstSrvDtls(0).SrvDiagnosis
                        'End If
                        Exit Sub
                    End If
                Else
                    If Session("objArrOTEmpDtls") IsNot Nothing Then
                        objLstSrvDtls = Session("objArrOTEmpDtls")
                        grdEmp.DataSource = objLstSrvDtls
                        grdEmp.DataBind()
                        'If objLstSrvDtls.Count > 0 Then
                        '    txtSrvDiagnosis.Text = objLstSrvDtls(0).SrvDiagnosis
                        'End If
                        Exit Sub
                    End If
                End If
            Else
                If Session("objArrOTEmpDtls") IsNot Nothing Then
                    objLstSrvDtls = Session("objArrOTEmpDtls")
                    grdEmp.DataSource = objLstSrvDtls
                    grdEmp.DataBind()

                    'If objLstSrvDtls.Count > 0 Then
                    '    txtSrvDiagnosis.Text = objLstSrvDtls(0).SrvDiagnosis
                    'End If
                End If

            End If
        End If

        If grdEmp.Rows.Count <= 0 Then
            DefaultGridDatabind(grdEmp)
        End If
    End Sub
#End Region

#Region "BUTTON EVENTS"
    Protected Sub btnAddEmp_Click(sender As Object, e As EventArgs) Handles btnAddEmp.Click
        Try
            If Trim(txtEmpNo.Text) = "" And txtEmpDesc.Text = "" Then
                ' enter VALID docotr CODE
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 23), "txtEmpNo", Page)
                txtEmpNo.Focus()
                Exit Sub
            End If

            If Session("objArrOTEmpDtls") IsNot Nothing Then
                objArrOTEmpDtls = Session("objArrOTEmpDtls")

                Dim x = From obj In objArrOTEmpDtls Where obj.EmpCd = txtEmpNo.Text Select obj
                If x.Any() = True Then
                    ' Duplicate Employees code nt allowed
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 24), "txtEmpNo", Page)
                    txtEmpNo.Focus()
                    txtEmpNo.Text = ""
                    txtEmpDesc.Text = ""
                    'MpOtDoctors.Show()
                    'clsGeneral.ShowErrorPopUp("Duplicate Doctor code nt allowed", "txtOtDoc", Page)
                    Exit Sub
                End If

                Dim objEmp = New OTSchedulingSerRef.clsFctAptOtEmpDtls
                objEmp.EmpCd = Val(txtEmpNo.Text)
                objEmp.EmpName = txtEmpDesc.Text
                objArrOTEmpDtls.Add(objEmp)

                grdEmp.DataSource = objArrOTEmpDtls
                grdEmp.DataBind()

                Session("objArrOTEmpDtls") = objArrOTEmpDtls

            Else

                Dim objEmp = New OTSchedulingSerRef.clsFctAptOtEmpDtls
                objEmp.EmpCd = Val(txtEmpNo.Text)
                objEmp.EmpName = txtEmpDesc.Text
                objArrOTEmpDtls.Add(objEmp)

                grdEmp.DataSource = objArrOTEmpDtls
                grdEmp.DataBind()

                Session("objArrOTEmpDtls") = objArrOTEmpDtls

            End If

            clearEmpInfo()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "txtEmpNo", Page)
        End Try
    End Sub

    Protected Sub btnOtEmpvOk_Click(sender As Object, e As EventArgs) Handles btnOtEmpvOk.Click
        Try
            If Session("objArrOTEmpDtls") IsNot Nothing Then

                objArrOTEmpDtls = Session("objArrOTEmpDtls")
                grdEmp.DataSource = objArrOTEmpDtls
                grdEmp.DataBind()

                Session("objArrOTEmpDtls") = objArrOTEmpDtls

            End If

            'Response.Redirect("OtScheduling.aspx?Mode")
            ScriptManager.RegisterClientScriptBlock(UPOTEmp, UPOTEmp.GetType(), "scr12", "parent.closeAppWindow();", True) 'RasikV 20170127

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Protected Sub btnOtEmpExit_Click(sender As Object, e As EventArgs) Handles btnOtEmpExit.Click

    End Sub
#End Region

#Region "TEXTBOX EVENTS"
    Protected Sub txtEmpNo_TextChanged(sender As Object, e As EventArgs) Handles txtEmpNo.TextChanged
        Try
            Dim objclsEmpId As New OTSchedulingSerRef.clsAttPayDbEmpId
            If (txtEmpNo.Text <> "") Then
                objclsEmpId = OTScheduling.GetOtEmpDtlsByEmpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtEmpNo.Text)
                If (objclsEmpId IsNot Nothing) Then
                    txtEmpDesc.Text = objclsEmpId.EmpName
                Else
                    txtEmpDesc.Text = ""
                    txtEmpNo.Text = ""
                    'clsGeneral.ShowErrorPopUp("Enter valid OT Employee Id", "txtempid", Page)
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 23), "txtEmpNo", Page)
                    txtEmpNo.Focus()
                End If
            Else
                txtEmpDesc.Text = ""
                txtEmpNo.Text = ""
                txtEmpNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "GRID EVENTS"
    Protected Sub grdEmp_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdEmp.RowCommand
        Try
            Dim row As GridViewRow
            If e.CommandName = "delete" Then
                Dim lbl As Label
                row = DirectCast((e.CommandSource), ImageButton).NamingContainer
                lbl = DirectCast(row.FindControl("grdlblEmpId"), Label)

                If Session("objArrOTEmpDtls") IsNot Nothing Then          'WHEN DATA IS DIRECTLY ADDED IN GRID BY USER
                    objArrOTEmpDtls = Session("objArrOTEmpDtls")
                    objArrOTEmpDtls.RemoveAt(row.RowIndex)
                    If objArrOTEmpDtls.Count = 0 Then
                        objArrOTEmpDtls = Nothing
                    End If
                    grdEmp.DataSource = objArrOTEmpDtls
                    grdEmp.DataBind()
                    Session("objArrOTEmpDtls") = objArrOTEmpDtls

                End If
            End If

            If objArrOTEmpDtls Is Nothing Then
                DefaultGridDatabind(grdEmp)
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Protected Sub grdEmp_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdEmp.RowDeleting

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

    Public Sub DefaultGridDatabind(ByVal grd As GridView)
        Try
            grd.DataSource = New List(Of String)
            grd.DataBind()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Private Sub clearEmpInfo()
        txtEmpNo.Text = ""
        txtEmpDesc.Text = ""

        txtEmpDesc.Focus()

    End Sub
#End Region

End Class