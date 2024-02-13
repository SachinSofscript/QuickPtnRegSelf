#Region "IMPORTS"
Imports OTScheduling.OTSchedulingSerRef
Imports OTScheduling.CmnSecurityFunSrvRef
#End Region

Partial Class InPatientHelp
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLRATIONS"
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Dim objWardList As List(Of OTSchedulingSerRef.clsCodeDecode)
    Dim objSpecialityList As List(Of OTSchedulingSerRef.clsCodeDecode)
    Dim objDoctor As List(Of clsDoctor)

    Dim Patienthelppagesize As Integer = Convert.ToInt32(ConfigurationManager.AppSettings("Patienthelppagesize"))
    Dim DispNum As Integer = Convert.ToInt32(ConfigurationManager.AppSettings("dispPatienthelppage"))

    Dim currentPage As Integer = 1
    Dim GridType As Char = Convert.ToChar("S")
    Dim Repeater As List(Of clsPaging) = Nothing
    Dim ItemCd As String
    Dim ReturnPageIndex As Integer = 0
    Dim PageSize As Integer = Patienthelppagesize
    Dim recordCount As Long

#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        clsGeneral.CheckSession(Me.Context, Session("USERID"))

        Try
            'Dim CSS_serverpath As String = System.Configuration.ConfigurationManager.AppSettings("CSS_serverpath")
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
                '   btnSearch.Attributes.Add("onclick", "hideshow();")
                'select All records from ip_ptn_vst
                objWardList = OTScheduling.GetWardDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))

                If objWardList IsNot Nothing Then
                    clsGeneral.FillDropDownList(ddlWard, "Decode", "Code", objWardList, 1, "All")
                End If
                'select All records from doctor_master
                objSpecialityList = OTScheduling.DoctorSpeciality(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
                If objSpecialityList IsNot Nothing Then
                    clsGeneral.FillDropDownList(ddlSpeciality, "Decode", "Code", objSpecialityList, 1, "All")
                End If
                'select All doctor speciality
                objDoctor = OTScheduling.GetDoctorList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))

                If objDoctor IsNot Nothing Then
                    lblNoOfDocRec.Text = objDoctor.Count
                    GrdDoctorDetails.DataSource = objDoctor
                    GrdDoctorDetails.DataBind()
                Else
                    lblNoOfDocRec.Text = 0
                    GrdDoctorDetails.DataSource = Nothing
                    GrdDoctorDetails.DataBind()
                End If
                RbAdmit.Checked = True
                search(currentPage)                    'Pushpa 20180508
                If (ViewState("recordCount") IsNot Nothing) Then
                    recordCount = ViewState("recordCount")
                    If (recordCount <> "0") Then
                        If (recordCount > PageSize) Then
                            GetPager(strErrMsg, chrErrFlg, recordCount, currentPage, DispNum, GridType, Repeater, ItemCd, ReturnPageIndex, PageSize)

                        End If
                    End If
                End If
            End If
            txtDocCd.Focus()
        Catch ex As Exception
            ' clsGeneral.ShowErrorPopUp(ex.Message, "", Page)'APARNA 2 JAN 2016
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page) 'APARNA 2 JAN 2016
        End Try
    End Sub
#End Region

#Region "TEXTBOX EVENTS"
    Protected Sub txtDocCd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocCd.TextChanged
        Try
            If txtDocCd.Text = "" Or txtDocCd.Text = CStr(0) Then
                lblDocNm.Text = ""
                txtDocCd.Focus()
                'clsGeneral.ShowErrorPopUp("Enter valid doctor code", "txtDocCd", Page)'APARNA 2 JAN 2016
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 4), "txtDocCd", Page) 'APARNA 2 JAN 2016
                Exit Sub
            End If

            Dim objDoctorInfo As String

            objDoctorInfo = OTScheduling.GetDoctor(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtDocCd.Text)
            If objDoctorInfo IsNot Nothing Then
                lblDocNm.Text = objDoctorInfo
                txtLastName.Focus()
            Else
                ' clsGeneral.ShowErrorPopUp("Enter valid doctor code", "txtDocCd", Page) 'APARNA 2 JAN 2016
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 4), "txtDocCd", Page) 'APARNA 2 JAN 2016
                txtDoctorFullName.Text = ""
                txtDocCd.Focus()
                Exit Sub
            End If
        Catch ex As Exception

            ' clsGeneral.ShowErrorPopUp(ex.Message, "", Page) 'Manisha 20130913
            ' clsGeneral.ShowErrorPopUp(ex.Message, "", Page)'APARNA 2 JAN 2016
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page) 'APARNA 2 JAN 2016
        End Try
    End Sub
#End Region

#Region "BUTTON EVENTS"
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            'Pramila 2May2017

            Clear()

            search(1)

            If (ViewState("recordCount") IsNot Nothing) Then
                recordCount = ViewState("recordCount")
                If (recordCount <> "0") Then
                    If (recordCount > PageSize) Then
                        GetPager(strErrMsg, chrErrFlg, recordCount, currentPage, DispNum, GridType, Repeater, ItemCd, ReturnPageIndex, PageSize)

                    End If
                End If
            End If

            'end
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub
#End Region

#Region "FUNCTIONS"
    Public Sub search(ByVal pageindex As Integer)
        Try
            'If (txtFirstName.Text = "" And txtLastName.Text = "" And txtMidName.Text = "") Then
            '    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 43), "txtLastName", Page)
            '    Exit Sub
            'End If

            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            'select All records from ip_ptn_vst
            Dim AdmitStatus As Integer = 0
            If RbAll.Checked = True Then
                AdmitStatus = 0
            ElseIf RbAdmit.Checked = True Then
                AdmitStatus = 2
            ElseIf RbDschrg.Checked = True Then
                AdmitStatus = 3
            End If

            Dim objInPatientHelpList As List(Of clsInPatientHelp)
            objInPatientHelpList = OTScheduling.GetInPtnListByNameDocWard(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtFirstName.Text, txtMidName.Text, txtLastName.Text, CInt(IIf(txtDocCd.Text = "", 0, txtDocCd.Text)), CInt(IIf(ddlWard.SelectedValue = "All", 0, ddlWard.SelectedValue)), AdmitStatus, pageindex, PageSize)
            If objInPatientHelpList IsNot Nothing Then
                ViewState("obj") = objInPatientHelpList
                lblNoOfRecords.Text = objInPatientHelpList.Count
                grdInPatientDtl.DataSource = objInPatientHelpList
                grdInPatientDtl.DataBind()

                If (objInPatientHelpList(0).totalcnt > Patienthelppagesize) Then
                    ViewState("recordCount") = objInPatientHelpList(0).totalcnt
                End If
            Else
                lblNoOfRecords.Text = 0
                grdInPatientDtl.DataSource = Nothing
                grdInPatientDtl.DataBind()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "hideshow();", True)
                '     ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "savecnfirmation();", True)
                lblname.Text = Nothing
                ViewState("recordCount") = "0"
            End If

            'Dim Dschg As Label
            'Dim Adm As Label
            'Dim lblDschgDt As Label
            'Dim lblAdmDt As Label
            'For Each dg As GridViewRow In grdInPatientDtl.Rows
            '    If RbAdmit.Checked = True Then
            '        lblDschgDt = dg.FindControl("lblDschgDt")
            '        lblAdmDt = dg.FindControl("lblAdmDt")
            '        lblAdmDt.Visible = True
            '        lblDschgDt.Visible = False
            '    ElseIf RbDschrg.Checked = True Then
            '        lblDschgDt = dg.FindControl("lblDschgDt")
            '        lblAdmDt = dg.FindControl("lblAdmDt")
            '        lblAdmDt.Visible = False
            '        lblDschgDt.Visible = True
            '    Else
            '        lblDschgDt = dg.FindControl("lblDschgDt")
            '        lblAdmDt = dg.FindControl("lblAdmDt")
            '        lblAdmDt.Visible = True
            '        lblDschgDt.Visible = True
            '    End If
            'Next
            'For Each headerCell As TableCell In grdInPatientDtl.HeaderRow.Cells
            '    If RbAdmit.Checked = True Then
            '        Dschg = headerCell.FindControl("dsc")
            '        Adm = headerCell.FindControl("Adm") 'DirectCast(grdInPatientDtl.HeaderRow.FindControl("Adm"), Label)
            '        Adm.Visible = True
            '        Dschg.Visible = False
            '        Exit Sub
            '    ElseIf RbDschrg.Checked = True Then
            '        Dschg = headerCell.FindControl("dsc")
            '        Adm = headerCell.FindControl("Adm") 'DirectCast(grdInPatientDtl.HeaderRow.FindControl("Adm"), Label)
            '        Adm.Visible = False
            '        Dschg.Visible = True
            '        Exit Sub
            '    Else
            '        Dschg = headerCell.FindControl("dsc")
            '        Adm = headerCell.FindControl("Adm") 'DirectCast(grdInPatientDtl.HeaderRow.FindControl("Adm"), Label)
            '        Adm.Visible = True
            '        Dschg.Visible = True
            '        Exit Sub
            '    End If
            'Next
        Catch ex As Exception
            ' clsGeneral.ShowErrorPopUp(ex.Message, "", Page)'APARNA 2 JAN 2016
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page) 'APARNA 2 JAN 2016
        End Try
    End Sub
#End Region

#Region "DROP DOWN EVENTS"
    Protected Sub ddlWard_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWard.TextChanged
        Try
            grdInPatientDtl.DataSource = Nothing
            grdInPatientDtl.DataBind()
            lblNoOfRecords.Text = 0
        Catch ex As Exception
            ' clsGeneral.ShowErrorPopUp(ex.Message, "", Page)'APARNA 2 JAN 2016
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page) 'APARNA 2 JAN 2016
        End Try
    End Sub
#End Region


#Region "Paging"
    Protected Sub Page_Changed(ByVal sender As Object, ByVal e As EventArgs)

        Try

            Dim currentPage As Integer = Integer.Parse(CType(sender, LinkButton).CommandArgument)

            currentPage = currentPage
            Repeater = Nothing
            ItemCd = Nothing
            ReturnPageIndex = 0
            PageSize = Patienthelppagesize


            If (ViewState("recordCount") IsNot Nothing) Then
                recordCount = ViewState("recordCount")
                If (recordCount > PageSize) Then
                    GetPager(strErrMsg, chrErrFlg, recordCount, currentPage, DispNum, GridType, Repeater, ItemCd, ReturnPageIndex, PageSize)
                End If

            Else
                recordCount = 0
            End If

            Dim Highlight As Long

            If (currentPage <> "777777777" Or currentPage <> "666666666") Then
                Highlight = ReturnPageIndex
            Else
                Highlight = currentPage - 1
            End If


            If (GridType = "S") Then
                If (ViewState("rptPager") IsNot Nothing) Then
                    Repeater = ViewState("rptPager")
                End If
            End If



            If (Repeater IsNot Nothing) Then
                For i As Integer = 0 To Repeater.Count - 1
                    If (Repeater(i).Value = Highlight) Then
                        Highlight = i
                        Exit For
                    End If
                Next

                Dim lnkPage2 As LinkButton = rptPager.Items(Highlight).FindControl("lnkPage")
                lnkPage2.ForeColor = Drawing.Color.Red

            End If



        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try

    End Sub

    Private Sub GetPager(ByRef strErrMsg As List(Of String), _
                                                     ByRef chrErrFlg As Char, _
                                                     ByVal recordCount As Integer, ByVal currentPage As Integer, ByVal DispNum As Integer, ByVal GridType As Char, ByVal Repeater As List(Of clsPaging), ByVal Itemcd As String, ByRef ReturnPageIndex As Integer, ByVal PageSize As Integer)
        Try

            Dim objpager As New List(Of clsPaging)

            If (GridType = "S") Then
                If (ViewState("rptPager") IsNot Nothing) Then
                    Repeater = ViewState("rptPager")
                End If
            End If

            objpager = OTScheduling.PopulatePager(strErrMsg, chrErrFlg, recordCount, currentPage, DispNum, GridType, Repeater, "", ReturnPageIndex, PageSize)


            If (GridType = "S") Then

                ViewState("rptPager") = Nothing


                If (currentPage <> 1) Then
                    search(ReturnPageIndex)
                Else
                    search(1)
                End If

                rptPager.DataSource = objpager
                rptPager.DataBind()

                ViewState("rptPager") = objpager

                Pagename(ReturnPageIndex)
            End If


        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try



    End Sub

    Public Sub Pagename(ByVal pageindex As Integer)
        Try
            Dim tocnt As Integer
            Dim frmCnt As Integer

            tocnt = (Patienthelppagesize * pageindex)

            frmCnt = (tocnt - (Patienthelppagesize - 1))

            If (pageindex = 1) Then
                frmCnt = 1
            End If
            Dim obj As List(Of clsInPatientHelp) = ViewState("obj")

            If (obj IsNot Nothing) Then
                If (tocnt > obj(0).totalcnt) Then
                    lblname.Text = "Records " + frmCnt.ToString() + " - " + obj(0).totalcnt.ToString() + " Out of " + obj(0).totalcnt.ToString()

                Else
                    lblname.Text = "Records " + frmCnt.ToString() + " - " + tocnt.ToString() + " Out of " + obj(0).totalcnt.ToString()

                End If
            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Public Sub Clear()


        lblNoOfRecords.Text = 0
        grdInPatientDtl.DataSource = New List(Of String)
        grdInPatientDtl.DataBind()
        rptPager.DataSource = Nothing
        rptPager.DataBind()
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "hideshow();", True)
        lblname.Text = Nothing
        ViewState("recordCount") = "0"

    End Sub
#End Region



    

End Class
