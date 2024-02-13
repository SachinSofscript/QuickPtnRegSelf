Imports OTScheduling.OTSchedulingSerRef

Public Class PtnQuickReg
    Inherits System.Web.UI.UserControl
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Dim objUsrMemoRights As List(Of clsPtnTypeMst)
    Dim objCdDcd As OTSchedulingSerRef.clsCodeDecode
    Dim li As ListItem
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strErrMsg = New List(Of String)
        chrErrFlg = "N"
        txtMobileNo.Focus()

        If Not IsPostBack Then

            ChkRule9215() 'aditi 26052023
            LoadSalutation()
            LoadPtnType()
            LoadNationality()
            LoadState()
            LoadCity()
            ddlPtnTtl_TextChanged(Nothing, Nothing)
            ChkRule9532() 'TRUPTI 03 AUG 2022
            ddlPtnType_SelectedIndexChanged(Nothing, Nothing) 'aditi 26052023
            ddlPtnTtl_SelectedIndexChanged(sender, EventArgs.Empty)  ''aditi 26052023
        End If

    End Sub

    Public Sub LoadSalutation()
        Try
            Dim ObjSalutn = New List(Of OTSchedulingSerRef.clsCodeDecode)
            ObjSalutn = OTScheduling.Salutation(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
            Dim query = From objAscending In ObjSalutn Where objAscending.Code = objAscending.Code Order By objAscending.Code Ascending
            If ObjSalutn.Count = 0 Then

            Else
                clsGeneral.FillDropDownList(ddlPtnTtl, "Decode", "Code", query, 0)

            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Public Sub LoadNationality()
        Try
            Dim ObjSalutn = New List(Of OTSchedulingSerRef.clsCodeDecode)
            ObjSalutn = OTScheduling.Nationality(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
            If ObjSalutn.Count = 0 Then

            Else
                clsGeneral.FillDropDownList(ddlNtnlity, "Decode", "Code", ObjSalutn, 0)

                Dim objCdDcd As OTSchedulingSerRef.clsCodeDecode
                objCdDcd = OTScheduling.GetCdDcdDtlByTypByCdByAddInfo1(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), OTSchedulingSerRef.EnumCodeDecode.Nationality, 1)
                If objCdDcd IsNot Nothing Then
                    ddlNtnlity.SelectedValue = objCdDcd.Code


                End If


            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
    'added by shivkumar 15/11/2021
    Public Sub LoadState()
        Try

            Dim objCdDcdState As OTSchedulingSerRef.StateMaster
            objCdDcdState = OTScheduling.GetIsBaseStateMst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), True)
            If objCdDcdState IsNot Nothing Then

                txtstate.Text = objCdDcdState.StateName
                Session("StateName") = txtstate.Text
                Session("Statecd") = objCdDcdState.StateCd
            Else
                Session("StateName") = Nothing
                Session("Statecd") = 0
            End If
            objCdDcdState = Nothing

            txtstate_TextChanged(txtstate, EventArgs.Empty)

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    'added by shivkumar 15/11/2021
    Public Sub LoadCity()
        Try

            Dim objCdDcdCity As OTSchedulingSerRef.CityMaster
            objCdDcdCity = OTScheduling.GetIsBaseCityMst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), True)
            If objCdDcdCity IsNot Nothing Then

                txtcity.Text = objCdDcdCity.CityName
                Session("Cityname") = txtcity.Text
            Else
                Session("Cityname") = Nothing
            End If
            objCdDcdCity = Nothing

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub


    Protected Sub txtMobileNo_TextChanged(sender As Object, e As EventArgs)
        Try
            If txtMobileNo.Text <> "" And txtMobileNo.Text.Length >= 12 Then
                Dim ObjLocPtnBasic1 = New List(Of clsPtnBasicInfo)

                ObjLocPtnBasic1 = OTScheduling.GetPtnDtlByMobNoDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtMobileNo.Text.ToString().Trim())
                If ObjLocPtnBasic1.Count = 0 Then
                    pnlMultiMobNo.Visible = False
                    grdMobileNo.DataSource = New List(Of String)()
                    grdMobileNo.DataBind()
                Else
                    pnlMultiMobNo.Visible = True
                    grdMobileNo.DataSource = ObjLocPtnBasic1
                    grdMobileNo.DataBind()
                End If

                Exit Sub


            Else
                ' clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 20), "txtMobileNo", Page)
                clsGeneral.ShowErrorPopUp("Enter 2 Digit Country Code along with 10 Digit Mobile Number", "txtMobile", Page)
                txtMobileNo.Text = ""
            End If
            ddlPtnTtl.Focus()
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Public Sub LoadPtnType()
        Try
            Dim objCdDcd1 As List(Of OTSchedulingSerRef.clsPtnTypeMst)
            'aditi 26052023
            Dim addinfo As String = ""
            If (ddlPtnType.Enabled = True) Then

                If (ViewState("RuleMst9215") = "Y") Then

                    'If ddlPtnType.SelectedValue Is Nothing Or ddlPtnType.SelectedValue = "" Then FillPatientType(Val(txtPtnNo.Text)) 'Trupti 26 JUn 2021

                    Dim ptntypcd As Integer = Val(ddlPtnType.SelectedValue)
                    objCdDcd1 = Nothing
                    'objCdDcd1 = clsFormPatientMasterIndex.GetCodeDeCodeList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), OTSchedulingSerRef.EnumCodeDecode.PatientTyp)

                    objCdDcd1 = OTScheduling.GetPtnTypByUser(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"), 0) 'Added By Trupti 26 JUN 2021


                    If objCdDcd1 IsNot Nothing Then
                        Dim objStaffptnTyp = New List(Of OTSchedulingSerRef.clsCodeDecode)
                        For i = 0 To objCdDcd1.Count - 1
                            Dim obj = New OTSchedulingSerRef.clsCodeDecode
                            'If objCdDcd1(i).addinfo1 = "S" Then
                            obj.Code = objCdDcd1(i).PtnTypCd
                                obj.Decode = objCdDcd1(i).PtnTypDesc
                                'obj.Type = objCdDcd1(i).Type
                                obj.addinfo1 = objCdDcd1(i).addinfo1
                                objStaffptnTyp.Add(obj)

                                If objCdDcd1(i).PtnTypCd = ptntypcd Then
                                    addinfo = objCdDcd1(i).addinfo1
                                End If

                            'End If
                        Next

                        clsGeneral.FillDropDownList(ddlPtnType, "Decode", "Code", objStaffptnTyp, 0)
                        If addinfo = "S" Then
                            If ddlPtnType.Items.Count > 0 Then
                                Dim LIPtnTypCd As ListItem = ddlPtnType.Items.FindByValue(ptntypcd.ToString())
                                If LIPtnTypCd IsNot Nothing Then
                                    ddlPtnType.SelectedValue = ptntypcd.ToString()
                                End If
                            End If
                        End If
                        objStaffptnTyp = Nothing
                    End If
                    objCdDcd = Nothing
                End If
            Else
                Dim ptntypcd As Integer = Val(ddlPtnType.SelectedValue)
                objCdDcd1 = Nothing
                'objCdDcd1 = clsFormPatientMasterIndex.GetCodeDeCodeList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), OTSchedulingSerRef.EnumCodeDecode.PatientTyp)

                objCdDcd1 = OTScheduling.GetPtnTypByUser(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"), 0)

                For i = 0 To objCdDcd1.Count - 1
                    Dim obj = New OTSchedulingSerRef.clsCodeDecode
                    If objCdDcd1(i).PtnTypCd = ptntypcd Then
                        If objCdDcd1(i).addinfo1 = "S" Then
                            ddlPtnType.SelectedValue = ptntypcd.ToString()
                        Else
                            clsGeneral.ShowErrorPopUp("Patient Type does not belong to Hospital Employee.Hence you cannot make this Patient as Hospital Employee.", "RbHospEmp", Page)
                        End If

                    End If
                Next


            End If

            'end


            'Dim ObjPtnTyp = New List(Of clsPtnTypeMst)
            'ObjPtnTyp = OTScheduling.GetPtnType(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 0)
            'If ObjPtnTyp.Count = 0 Then

            'Else
            '    clsGeneral.FillDropDownList(ddlPtnType, "PtnTypDesc", "PtnTypCd", ObjPtnTyp, 0)
            '    'shivkumar 15/11/2021 patient type  set default in userwise
            '    Dim objUsrDt As clsUserDet
            '    objUsrDt = OTScheduling.GetUserDetByCD(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"))
            '    If objUsrDt.DefPtnTypeCd.ToString() <> "0" Then
            '        ddlPtnType.SelectedValue = objUsrDt.DefPtnTypeCd.ToString()
            '    End If

            '    '
            'End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try

    End Sub
    Protected Sub btnRegNewPtn_Click(sender As Object, e As EventArgs)
        Try
            'If (txtMobileNo.Text.Trim() = "") Then
            '    clsGeneral.ShowErrorPopUp("Enter Patient Mobile No", txtMobileNo.ID, Page)
            '    Return
            'End If
            'If (txtLstName.Text.Trim() = "") Then
            '    clsGeneral.ShowErrorPopUp("Enter Patient Last Name", txtLstName.ID, Page)
            '    Return
            'End If
            If (txtFirstName.Text.Trim() = "") Then
                clsGeneral.ShowErrorPopUp("Enter Patient First Name", txtFirstName.ID, Page)
                Return
            End If
            'If (txtBirthDt.Text = "") Then
            '    clsGeneral.ShowErrorPopUp("Enter Patient Birth Date", txtBirthDt.ID, Page)
            '    Return
            'End If
            'If (txtstate.Text.Trim() = "") Then
            '    clsGeneral.ShowErrorPopUp("Enter Patient State", txtstate.ID, Page)
            '    Return
            'End If
            'If (txtcity.Text.Trim() = "") Then
            '    clsGeneral.ShowErrorPopUp("Enter Patient City", txtcity.ID, Page)
            '    Return
            'End If
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "savecnfirmationNewPtn();", True)

            ' btnFinalSave_Click(sender, e)

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Public Sub clear()
        txtMobileNo.Text = ""
        pnlMultiMobNo.Visible = False
        grdMobileNo.DataSource = New List(Of String)()
        grdMobileNo.DataBind()
        txtLstName.Text = ""
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtBirthDt.Text = ""
        txtYY.Text = ""
        txtMM.Text = ""
        txtDD.Text = ""
        txtstate.Text = ""
        txtcity.Text = ""
        ddlPtnTtl.SelectedValue = 1
        If Session("StateName") IsNot Nothing Then
            txtstate.Text = Session("StateName")

        End If
        If Session("Cityname") IsNot Nothing Then
            txtcity.Text = Session("Cityname")
        End If


        hdnStCd.Value = ""
        hdnCityCd.Value = ""
        ddlPtnType_SelectedIndexChanged(Nothing, Nothing) 'aditi 26052023

    End Sub
    Protected Sub btnBck_Click(sender As Object, e As EventArgs)
        Try
            Parent.FindControl("divPopupNewPtnReg").Visible = False
            Parent.FindControl("divOverlayPopupNewPtnReg").Visible = False
            clear()
            ddlPtnTtl_SelectedIndexChanged(sender, EventArgs.Empty)  'aditi 26052023
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub txtstate_TextChanged(sender As Object, e As EventArgs)

        Dim a As String = ""
        hdnStCd.Value = txtstate.Text.Split("{")(1).Replace("}", "")
        Session("Statecd") = hdnStCd.Value
        Dim Objarr As List(Of StateMaster)
        Objarr = OTScheduling.GetStateLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Convert.ToInt32(hdnStCd.Value), "")
        If Objarr IsNot Nothing Then
            If Objarr.Count > 0 Then
                hfCountrCd.Value = Objarr(0).CountryCd.ToString()
            Else
                hfCountrCd.Value = ""
            End If
        Else
            hfCountrCd.Value = ""
        End If
        txtcity.Focus()
    End Sub

    Function CalculateDOB(ByVal Cmpdate As Date, ByVal ageYY As String, ByVal ageMM As String, ByVal ageDD As String) As Date
        Dim X, Y, Z As Date

        If ageYY <> "" Then
            X = DateAdd(DateInterval.Year, -(Val(ageYY)), Cmpdate)
        Else
            X = DateAdd(DateInterval.Year, -(0), Cmpdate)
        End If
        If ageMM <> "" Then
            Y = DateAdd(DateInterval.Month, -(Val(ageMM)), X)
        Else
            Y = DateAdd(DateInterval.Month, -(0), X)
        End If
        If ageDD <> "" Then
            Z = DateAdd(DateInterval.Day, -(Val(ageDD)), Y)
        Else
            Z = DateAdd(DateInterval.Day, -(0), Y)
        End If
        '' MsgBox(VB6.Format(Z, "dd/MM/yyyy"))
        Return Format(Z, "dd/MM/yyyy")
    End Function
    Private Sub Set_YY_MM_DD(ByVal p_CurrDt As Date, ByVal p_DOB As Date)
        Try
            Dim dd As Integer = 0,
                mm As Integer = 0,
                yy As Integer = 0
            Dim tdays As TimeSpan = p_CurrDt.Subtract(p_DOB)

            mm = (12 * (p_CurrDt.Year - p_DOB.Year)) + (p_CurrDt.Month - p_DOB.Month)
            If p_CurrDt.Day < p_DOB.Day Then
                mm -= 1
                dd = DateTime.DaysInMonth(p_DOB.Year, p_DOB.Month) - p_DOB.Day + p_CurrDt.Day
            Else
                dd = p_CurrDt.Day - p_DOB.Day
            End If
            yy = Math.Floor(mm / 12)
            mm -= yy * 12

            txtYY.Text = yy
            txtMM.Text = mm
            txtDD.Text = dd
        Catch ex As Exception
            '' MsgBox(ex.Message, MsgBoxStyle.Critical, GV_PRODUCTNAME)
        End Try
    End Sub

    Protected Sub txtBirthDt_TextChanged(sender As Object, e As EventArgs)
        Try
            If (txtBirthDt.Text <> "") Then
                If txtBirthDt.Text.Length <> 10 Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 25), "txtBirthDt", Page)
                    txtBirthDt.Text = ""
                    txtBirthDt.Text = CalculateDOB(clsGeneral.getdate(), txtYY.Text, txtMM.Text, txtDD.Text)
                    Exit Sub
                End If
            End If

            If Trim(txtBirthDt.Text) <> "" Then
                If IsDate(txtBirthDt.Text) = False Then
                    clsGeneral.ShowErrorPopUp("enter valid birth date", "txtBirthDt", Page)
                    'clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 25), "txtBirthDt", Page) 
                    txtBirthDt.Focus()
                    txtBirthDt.Text = CalculateDOB(clsGeneral.getdate(), txtYY.Text, txtMM.Text, txtDD.Text)
                    Exit Sub
                Else
                    If CDate(txtBirthDt.Text) > Today Then
                        clsGeneral.ShowErrorPopUp("birth date cannot be greater than current date", "txtBirthDt", Page)
                        ' clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "txtBirthDt", Page)

                        txtBirthDt.Text = CalculateDOB(clsGeneral.getdate(), txtYY.Text, txtMM.Text, txtDD.Text)
                    End If

                    Call Set_YY_MM_DD(clsGeneral.getdate, CDate(txtBirthDt.Text))
                End If
            Else

                If Trim(txtBirthDt.Text) = "" Then
                    txtBirthDt.Text = CalculateDOB(clsGeneral.getdate(), txtYY.Text, txtMM.Text, txtDD.Text)
                End If

            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub


    Protected Sub txtYY_TextChanged(sender As Object, e As EventArgs)
        Try
            txtBirthDt.Text = CalculateDOB(clsGeneral.getdate(), txtYY.Text, txtMM.Text, txtDD.Text)


            Dim Birthdate As DateTime = txtBirthDt.Text

            txtMM.Focus()

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub txtDD_TextChanged(sender As Object, e As EventArgs)
        txtBirthDt.Text = CalculateDOB(clsGeneral.getdate(), txtYY.Text, txtMM.Text, txtDD.Text)


        Dim Birthdate As DateTime = txtBirthDt.Text
        ddlGender.Focus()
    End Sub

    Protected Sub txtMM_TextChanged(sender As Object, e As EventArgs)
        txtBirthDt.Text = CalculateDOB(clsGeneral.getdate(), txtYY.Text, txtMM.Text, txtDD.Text)

        Dim Birthdate As DateTime = txtBirthDt.Text
        txtDD.Focus()
    End Sub

    Protected Sub btnFinalSave_Click(sender As Object, e As EventArgs)
        Try
            Dim objBkdDtls As New clsPatient

            If ISNewPtnRegtrAsTemp Then
                objBkdDtls.TYPFLG = "T"
            Else
                objBkdDtls.TYPFLG = "P"
            End If

            objBkdDtls.PatientTitleCode = Val(ddlPtnTtl.SelectedValue)
            objBkdDtls.PatientFirstName = txtFirstName.Text
            objBkdDtls.PatientLastName = txtLstName.Text
            objBkdDtls.PatientMiddleName = txtMiddleName.Text
            objBkdDtls.Gender = ddlGender.SelectedValue.ToString()

            If (txtBirthDt.Text <> "") Then 'aditi 23052023
                objBkdDtls.BirthDate = CDate(txtBirthDt.Text).ToString("dd/MM/yyyy")
            Else
                objBkdDtls.BirthDate = Nothing
            End If

            objBkdDtls.Agedd = Val(txtDD.Text)
            objBkdDtls.Agemm = Val(txtMM.Text)
            objBkdDtls.AgeYY = Val(txtYY.Text)
            objBkdDtls.NtnltyCd = Val(ddlNtnlity.SelectedValue)
            objBkdDtls.prmnt_tel = txtMobileNo.Text
            objBkdDtls.DocCd = 0
            objBkdDtls.ClncCd = 0
            objBkdDtls.prmnt_cntry = Convert.ToInt32(Val(hfCountrCd.Value))
            objBkdDtls.StateCode = Val(Session("Statecd").ToString())

            If (txtcity.Text <> "") Then   'aditi 31052023
                objBkdDtls.cityCode = Val(txtcity.Text.Split("{")(1).Replace("}", ""))
            Else
                objBkdDtls.cityCode = 0
            End If

            objBkdDtls.BillType = Val(ddlPtnType.SelectedValue)
            objBkdDtls.UserDtTm = clsGeneral.getdate()
            objBkdDtls.NRI = CChar("N")
            objBkdDtls.WhatsAppNo = txtMobileNo.Text
            objBkdDtls.UserId = Session("USERID").ToString()

            Dim SessionId As Long = Val(Session("SESSIONID"))           'Aarti 20171028
            Dim SessionState As Integer = 0
            Dim ptnNo As Long

            If (OTScheduling.SaveConfirmEnqPtn(strErrMsg, chrErrFlg, SessionState, ptnNo, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("MAINMODCODE"), Session("MAINSUBMODCODE"), SessionId, Session("USERID"), clsGeneral.getdate(), objBkdDtls)) Then

                Session("PtnNo") = ptnNo
                clsGeneral.ShowErrorPopUp("Confirmed Enquire for Patient is done Successfully with Patient No : " + ptnNo.ToString(), "", Page)

                hfNewPtnno.Value = ptnNo
                clear()
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "GetNewPtnNo();", True)

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

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub grdMobileNo_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            Dim row As GridViewRow
            If e.CommandName = "SEL" Then
                row = DirectCast((e.CommandSource), LinkButton).NamingContainer
                Dim lblPtnNoforContact = DirectCast(grdMobileNo.Rows(row.RowIndex).FindControl("lblPtnNoforContact"), Label)

                hfNewPtnno.Value = lblPtnNoforContact.Text
                clear()

                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), Guid.NewGuid().ToString(), "GetNewPtnNo();", True)

            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub ddlPtnTtl_TextChanged(sender As Object, e As EventArgs)
        Try

            Dim objCdDcd As OTSchedulingSerRef.clsCodeDecode
            Dim StrGender As String = ddlGender.SelectedValue    'RasikV 20190403  [Not Auto Picking Gender: Transgender]

            objCdDcd = OTScheduling.GetCodeDeCodeDtlByTypByCd(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), OTSchedulingSerRef.EnumCodeDecode.TitleCd, Val(ddlPtnTtl.SelectedValue))
            If objCdDcd IsNot Nothing Then


                If objCdDcd IsNot Nothing Then
                    If UCase(objCdDcd.addinfo1) = "M" Then

                        ddlGender.SelectedValue = "M"


                    ElseIf UCase(objCdDcd.addinfo1) = "F" Then
                        ddlGender.SelectedValue = "F"


                    ElseIf UCase(objCdDcd.addinfo1) = "T" Then
                        ddlGender.SelectedValue = "T"


                    End If



                End If
                'APARNA 30 JAN 2016
            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub


    Private Sub ChkRule9215()
        ISNewPtnRegtrAsTemp = False
        Dim objRuleMst As New clsRuleMaster
        objRuleMst = OTScheduling.GetRuleMstDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 9215)
        If objRuleMst IsNot Nothing Then
            If objRuleMst.Data1 = "Y" Then
                ViewState("RuleMst9215") = objRuleMst.Data1
                ISNewPtnRegtrAsTemp = True
            End If
        End If
    End Sub

    'aditi 27052023
    Private Sub ChkRule9532()
        ISNewPtnRegtrAsTemp = False
        Dim objRuleMst As New clsRuleMaster
        objRuleMst = OTScheduling.GetRuleMstDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 9532)
        If objRuleMst IsNot Nothing Then
            If objRuleMst.Data1 = "Y" Then
                ISNewPtnRegtrAsTemp = True
            End If
        End If
    End Sub
    'end

    Public Property ISNewPtnRegtrAsTemp() As Boolean
        Get
            Return ViewState("ChkRule9532")
        End Get
        Set(ByVal value As Boolean)
            ViewState("ChkRule9532") = value
        End Set
    End Property

    Protected Sub ddlPtnType_SelectedIndexChanged(sender As Object, e As EventArgs)  'aditi 26052023

        GetRule9184()
        GetUserFreeMemoRights()

        If ViewState("Rule9184Data1") = "Y" Then


            If ViewState("Rule9184Data2") <> "" Then

                If ViewState("FREEMEMO") = "N" Then

                    If ddlPtnType.SelectedValue = ViewState("Rule9184Data2").ToString Then
                        Dim msg As String
                        If Session("MAINSUBMODCODE") = "412" Then
                            msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 55), ddlPtnType.SelectedItem.Text.ToString)

                        End If
                        clsGeneral.ShowErrorPopUp(msg, "txtptnno", Page)


                        ddlPtnType.SelectedValue = ViewState("PtnDefaultType")

                    End If
                    ' End If
                End If

            End If
        End If
        'End If
    End Sub

    Private Sub GetRule9184()  'aditi 26052023
        Dim objRuleMst9184 As New clsRuleMaster
        objRuleMst9184 = OTScheduling.GetRuleMstDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 9184)
        If objRuleMst9184 IsNot Nothing Then
            If objRuleMst9184.Data1 = "Y" Then
                ViewState("Rule9184Data1") = objRuleMst9184.Data1
                ViewState("Rule9184Data2") = objRuleMst9184.Data2
            End If
        End If
        objRuleMst9184 = Nothing
    End Sub


    Public Sub GetUserFreeMemoRights()  'aditi 26052023
        objUsrMemoRights = OTScheduling.GetDefaultValues(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Session("USERID"))

        If objUsrMemoRights IsNot Nothing Then
            If objUsrMemoRights.Count <> 0 Then
                For i = 0 To objUsrMemoRights.Count - 1


                    ViewState("FREEMEMO") = objUsrMemoRights(i).FREE


                Next
            End If
        End If

    End Sub

    Protected Sub ddlPtnTtl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPtnTtl.SelectedIndexChanged  'aditi 26052023
        Try
            Dim StrGender As String = ddlGender.SelectedValue

            objCdDcd = OTScheduling.GetCodeDeCodeDtlByTypByCd(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), OTSchedulingSerRef.EnumCodeDecode.TitleCd, Val(ddlPtnTtl.SelectedValue))
            If objCdDcd IsNot Nothing Then


                If objCdDcd IsNot Nothing Then
                    If UCase(objCdDcd.addinfo1) = "M" Then

                        ddlGender.SelectedValue = "F"
                        'RbGender.SelectedValue = "T"
                        ddlGender.Enabled = True






                        For Each lst As ListItem In ddlGender.Items
                            If (lst.Selected = True) Then
                                lst.Enabled = False
                            Else
                                lst.Enabled = True
                            End If

                        Next

                        If UCase(StrGender) = UCase("T") Then

                            If UCase(objCdDcd.addinfo1) = "M" Then
                                ddlGender.SelectedValue = "M"

                            End If

                        Else
                            ddlGender.SelectedValue = "M"

                        End If


                    ElseIf UCase(objCdDcd.addinfo1) = "F" Then
                        ddlGender.SelectedValue = "M"
                        '
                        ddlGender.Enabled = True


                        For Each lst As ListItem In ddlGender.Items
                            If (lst.Selected = True) Then
                                lst.Enabled = False
                            Else
                                lst.Enabled = True

                            End If

                        Next

                        If UCase(StrGender) = UCase("T") Then

                            If UCase(objCdDcd.addinfo1) = "F" Then
                                ddlGender.SelectedValue = "F"

                            End If

                        Else
                            ddlGender.SelectedValue = "F"

                        End If

                    End If


                End If

            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
End Class