Imports System.Data
Imports OTScheduling.OTSchedulingSerRef

Partial Class Pages_PatientSearch
    Inherits System.Web.UI.Page
    Dim objPatient As New List(Of clsPatientHelp)
    Dim row As GridViewRow
    Dim lbl As Label
    Dim val1 As String
    Dim val2 As String
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char

    Dim Patienthelppagesize As Integer = Convert.ToInt32(ConfigurationManager.AppSettings("Patienthelppagesize"))
    Dim DispNum As Integer = Convert.ToInt32(ConfigurationManager.AppSettings("dispPatienthelppage"))

    Dim currentPage As Integer
    Dim GridType As Char = Convert.ToChar("S")
    Dim Repeater As List(Of clsPaging)
    Dim ItemCd As String
    Dim ReturnPageIndex As Integer
    Dim PageSize As Integer
    Dim recordCount As Long


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        clsGeneral.CheckSession(Me.Context, Session("USERID"))
        If Not IsPostBack Then
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Try
                'objPatient = clsFormOPPostVoucher.CommonPatientHelpList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
                'If IsNothing(objPatient) Then
                '    dgvptn.Visible = False
                '    dgvptn.DataSource = Nothing
                '    dgvptn.DataBind()
                '    lblNoOfRecords.Text = 0
                'Else
                '    dgvptn.Visible = True
                '    dgvptn.DataSource = objPatient
                '    dgvptn.DataBind()
                '    lblNoOfRecords.Text = objPatient.Count
                '    txtPatnLastName.Focus()
                '    Session("Patient") = objPatient
                'End If
                txtPatnLastName.Focus()
            Catch ex As Exception
                'clsGeneral.ShowErrorPopUp(ex.Message, "", Page) 'aparna 14 Dec 2015
                clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page) 'aparna 14 Dec 2015
            End Try

            NameOrderFormat() 'aparna 14 mar 2018

        End If
    End Sub

    Protected Sub dgvptn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvptn.SelectedIndexChanged
        Try
            row = dgvptn.SelectedRow
            lbl = DirectCast(dgvptn.Rows(row.RowIndex).FindControl("lblPtnNo"), Label)
            val1 = lbl.Text
            lbl = DirectCast(dgvptn.Rows(row.RowIndex).FindControl("lblPtntFullName"), Label)
            val2 = lbl.Text
            clsGeneral.ExitChildPopup(val1, "", "txtopno", "txtopno", Page)
        Catch ex As Exception
            'clsGeneral.ShowErrorPopUp(ex.Message, "", Page) 'aparna 14 Dec 2015
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page) 'aparna 14 Dec 2015
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try

            Repeater = Nothing
            ItemCd = Nothing
            ReturnPageIndex = 0
            PageSize = Patienthelppagesize
            currentPage = "1"
            Clear()

            Getdetails(1)
            If (ViewState("recordCount") IsNot Nothing) Then
                recordCount = ViewState("recordCount")
                If (recordCount <> "0") Then
                    If (recordCount > PageSize) Then
                        GetPager(strErrMsg, chrErrFlg, recordCount, currentPage, DispNum, GridType, Repeater, ItemCd, ReturnPageIndex, PageSize)

                    End If
                End If
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try

    End Sub

    Public Sub Getdetails(ByVal pageindex As Integer)
        strErrMsg = New List(Of String)
        chrErrFlg = "N"


        Dim i As Integer
        i = 0

        Try
            If (txtPatnFirstName.Text = "" And txtPatnLastName.Text = "" And txtPatnMidName.Text = "" And txtPhoneNum.Text = "" And txtAadharNo.Text = "" And txtPanNo.Text = "" And txtAddress.Text = "" And txtPatFathersName.Text = "") Then
                ' clsGeneral.ShowErrorPopUp("Minimum one parameter is required", "", Page)  'aparna 14 Dec 2015
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 47), "", Page)  'aparna 14 Dec 2015
                Exit Sub
            Else
                'objPatient = clsFormOPPostVoucher.CommonPatientHelp(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtPatnFirstName.Text.Trim, txtPatnMidName.Text.Trim, txtPatnLastName.Text.Trim, txtPhoneNum.Text.Trim)
                objPatient = PatientHelp.PatientHelpMst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtPatnFirstName.Text.Trim, txtPatnMidName.Text.Trim, txtPatnLastName.Text.Trim, txtPhoneNum.Text.Trim, pageindex, Patienthelppagesize, txtAadharNo.Text, txtPanNo.Text, txtAddress.Text, txtPatFathersName.Text.Trim)
            End If

            If objPatient Is Nothing Then
                dgvptn.Visible = False
                rptPager.DataSource = Nothing
                rptPager.DataBind()
                lblname.Text = Nothing
                ViewState("recordCount") = "0"
                lblNoOfRecords.Text = 0
                dgvptn.DataSource = New List(Of String)
                dgvptn.DataBind()
                Exit Sub
            ElseIf objPatient IsNot Nothing And objPatient.Count > 0 Then
                dgvptn.Visible = True
                ViewState("obj") = objPatient
                dgvptn.DataSource = objPatient
                dgvptn.DataBind()
                lblNoOfRecords.Text = objPatient.Count

                If (objPatient(0).totalcnt > Patienthelppagesize) Then
                    ViewState("recordCount") = objPatient(0).totalcnt
                End If
                Exit Sub
            Else
                dgvptn.Visible = False
                rptPager.DataSource = Nothing
                rptPager.DataBind()
                lblname.Text = Nothing
                ViewState("recordCount") = "0"
                lblNoOfRecords.Text = 0
                dgvptn.DataSource = New List(Of String)
                dgvptn.DataBind()
                Exit Sub
            End If

            'If IsNothing(objPatient) Then
            '    'clsGeneral.ShowErrorPopUp("Record Not Found", "", Page)'aparna 14 Dec 2015
            '    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 48), "", Page) 'aparna 14 Dec 2015
            '    dgvptn.Visible = False
            '    dgvptn.DataSource = Nothing
            '    dgvptn.DataBind()
            '    lblNoOfRecords.Text = 0
            'Else
            '    dgvptn.Visible = True
            '    dgvptn.DataSource = objPatient
            '    dgvptn.DataBind()
            '    lblNoOfRecords.Text = objPatient.Count
            'End If

        Catch ex As Exception

            'clsGeneral.ShowErrorPopUp(ex.Message, "", Page) 'aparna 14 Dec 2015
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page) 'aparna 14 Dec 2015

        End Try
    End Sub


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

    Private Sub GetPager(ByRef strErrMsg As List(Of String),
                                                     ByRef chrErrFlg As Char,
                                                     ByVal recordCount As Integer, ByVal currentPage As Integer, ByVal DispNum As Integer, ByVal GridType As Char, ByVal Repeater As List(Of clsPaging), ByVal Itemcd As String, ByRef ReturnPageIndex As Integer, ByVal PageSize As Integer)
        Try

            Dim objpager As New List(Of clsPaging)

            If (GridType = "S") Then
                If (ViewState("rptPager") IsNot Nothing) Then
                    Repeater = ViewState("rptPager")
                End If
            End If

            objpager = PatientHelp.PopulatePager(strErrMsg, chrErrFlg, recordCount, currentPage, DispNum, GridType, Repeater, "", ReturnPageIndex, PageSize)


            If (GridType = "S") Then

                ViewState("rptPager") = Nothing


                If (currentPage <> 1) Then
                    Getdetails(ReturnPageIndex)
                Else
                    Getdetails(1)
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
            Dim obj As List(Of clsPatientHelp) = ViewState("obj")

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
        dgvptn.Visible = False
        rptPager.DataSource = Nothing
        rptPager.DataBind()
        lblname.Text = Nothing
        ViewState("recordCount") = "0"
        lblNoOfRecords.Text = 0
        dgvptn.DataSource = New List(Of String)
        dgvptn.DataBind()
    End Sub

#End Region


    Private Sub NameOrderFormat()
        Dim lblName As String = ""
        Dim Tooltip As String = ""
        Dim WaterMark As String = ""
        Dim objRuleMst As New clsRuleMaster
        Dim setproperties As New List(Of ClsPtnDtlsSetup)

        objRuleMst = OTScheduling.GetRuleMstDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 8025)


        setproperties = PatientHelp.setproperties(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), objRuleMst)



        If (setproperties IsNot Nothing) Then
            If (setproperties.Count > 0) Then

                If (setproperties.Count > 0) Then
                    lblLastName.Text = setproperties(0).Name
                    txtPatnLastName.ToolTip = setproperties(0).Tooltip
                End If


                If (setproperties.Count > 1) Then
                    lblFrstName.Text = setproperties(1).Name
                    txtPatnFirstName.ToolTip = setproperties(1).Tooltip
                End If

                If (setproperties.Count > 2) Then
                    lblMidName.Text = setproperties(2).Name
                    txtPatnMidName.ToolTip = setproperties(2).Tooltip
                End If


            End If

        End If
    End Sub










End Class
