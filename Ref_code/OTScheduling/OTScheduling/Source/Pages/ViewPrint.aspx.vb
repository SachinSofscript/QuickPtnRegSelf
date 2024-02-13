Imports Microsoft.Reporting.WebForms

Public Class ViewPrint
    Inherits System.Web.UI.Page
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                If Session("chkDtRng") IsNot Nothing Then
                    chkDtRng.Checked = True
                    txtFrmDt.Enabled = True
                    txtToDt.Enabled = True
                Else
                    chkDtRng.Checked = False
                    txtFrmDt.Enabled = False
                    txtToDt.Enabled = False
                End If

                If Session("FrmDateWise") IsNot Nothing Then
                    txtFrmDt.Text = Session("FrmDateWise").ToString
                Else
                    txtFrmDt.Text = ""
                End If

                If Session("ToDateWise") IsNot Nothing Then
                    txtToDt.Text = Session("ToDateWise").ToString
                Else
                    txtToDt.Text = ""
                End If

                If Session("OTNo") IsNot Nothing Then
                    txtot.Text = Session("OTNo").ToString
                Else
                    txtot.Text = ""
                End If
                If Session("OTNm") IsNot Nothing Then
                    txtotname.Text = Session("OTNm").ToString
                Else
                    txtotname.Text = ""
                End If
                If Session("DocCd") IsNot Nothing Then
                    txtdctid.Text = Session("DocCd").ToString
                Else
                    txtdctid.Text = ""
                End If
                If Session("DocNm") IsNot Nothing Then
                    txtdctname.Text = Session("DocNm").ToString
                Else
                    txtdctname.Text = ""
                End If


                Dim objCdDcd As List(Of OTSchedulingSerRef.clsCodeDecode)
                objCdDcd = OTScheduling.GetCodeDeCodeList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), OTSchedulingSerRef.EnumCodeDecode.BookingType)

                If objCdDcd IsNot Nothing Then
                    clsGeneral.FillDropDownList(drpBookingType, "Decode", "Code", objCdDcd, 1, "SELECT")
                End If


            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub txtot_TextChanged(sender As Object, ByVal e As System.EventArgs) Handles txtot.TextChanged
        Try
            strErrMsg = New List(Of String)
            chrErrFlg = "N"

            If txtot.Text = "" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)
                txtot.Text = ""
                txtotname.Text = ""

            End If

            txtotname.Text = OTScheduling.GetOtName(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtot.Text))

            If txtotname.Text = "" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 11), "txtot", Page)
                txtot.Text = ""
                txtotname.Text = ""

            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try

    End Sub

    Protected Sub txtdctid_TextChanged(sender As Object, e As EventArgs) Handles txtdctid.TextChanged
        Try 'RasikV 20170125

            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Dim DocName As String

            If txtdctid.Text = "" And txtdctname.Text = Nothing Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 4), "txtdctid", Page)
                txtdctid.Text = ""
                txtdctname.Text = ""
                Exit Sub
            End If

            DocName = OTScheduling.GetDoctorName(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtdctid.Text))

            If DocName = "" And DocName Is Nothing Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 4), "txtdctid", Page)
                txtdctid.Text = ""
                txtdctname.Text = ""
            Else
                txtdctname.Text = DocName.ToUpper()

            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub chkDtRng_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If (chkDtRng.Checked = True) Then
                Dim DtRev As Date = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))

                txtFrmDt.Text = Format(DtRev, "dd/MM/yyyy")
                txtToDt.Text = Format(DtRev, "dd/MM/yyyy")
                txtFrmDt.Enabled = True
                txtToDt.Enabled = True
            Else
                txtFrmDt.Text = ""
                txtToDt.Text = ""
                txtFrmDt.Enabled = False
                txtToDt.Enabled = False
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs)
        Try
            Dim intNetID As Integer
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Dim userid As String = Session("USERID")


            Dim frmdt As String
            Dim ToDt As String
            Dim otno As Integer = 0
            Dim Doccd As Integer = 0

            If chkDtRng.Checked = True Then
                Session("chkDtRng") = "True"
                Session("FrmDateWise") = txtFrmDt.Text
                Session("ToDateWise") = txtToDt.Text

                If txtFrmDt.Text = "" Then
                    ' clsGeneral.ShowErrorPopUp("Please Enter From Date", txtFrmDt.ID, Page)
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 45), "txtFrmDt", Page)
                    Return
                ElseIf IsDate(txtFrmDt.Text) = False Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtFrmDt", Page)
                    txtFrmDt.Text = ""
                    txtFrmDt.Focus()
                    Return
                End If



                If txtToDt.Text = "" Then
                    ' clsGeneral.ShowErrorPopUp("Please Enter To Date", txtToDt.ID, Page)
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 46), "txtToDt", Page)
                    Return
                ElseIf IsDate(txtToDt.Text) = False Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtToDt", Page)
                    txtToDt.Text = ""
                    txtToDt.Focus()
                    Return
                End If

                If CDate(txtFrmDt.Text) > CDate(txtToDt.Text) Then
                    'clsGeneral.ShowErrorPopUp("From date Shoulf Not be Greater Than To Date", "txtToDt", Page)
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 44), "txtot", Page)
                    Return
                End If

            Else
                Session("FrmDateWise") = Nothing
                Session("ToDateWise") = Nothing
                Session("chkDtRng") = Nothing
            End If

            If txtFrmDt.Text = "" Then
                frmdt = Nothing
            Else
                frmdt = txtFrmDt.Text
            End If

            If txtToDt.Text = "" Then
                ToDt = Nothing
            Else
                ToDt = txtToDt.Text
            End If

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
                Session("DocNm") = txtdctname.Text
            End If

            Dim BookingType As Integer = 0


            If (drpBookingType.SelectedValue <> "SELECT") Then
                BookingType = Convert.ToInt32(drpBookingType.SelectedValue)
            End If




            Dim Param As New List(Of Microsoft.Reporting.WebForms.ReportParameter)

            If rdbSelectionRpt.SelectedValue = "1" Then
                intNetID = 70480           ''For OTScheduling.rdl
                Param.Add(New ReportParameter("PCOCD", Session("COMPANYCODE").ToString))
                Param.Add(New ReportParameter("PDIVCD", Session("DIVCODE").ToString))
                Param.Add(New ReportParameter("PLOCCD", Session("LOCCODE").ToString))
                Param.Add(New ReportParameter("FCTCODE", otno))
                Param.Add(New ReportParameter("APTM_FRM_DATE", frmdt))
                Param.Add(New ReportParameter("APTM_TO_DATE", ToDt))
                Param.Add(New ReportParameter("flg", ""))
                Param.Add(New ReportParameter("APTM_STS", "1"))
                Param.Add(New ReportParameter("Doc_Cd", Doccd))
                Param.Add(New ReportParameter("OTDesc", txtotname.Text))
                Param.Add(New ReportParameter("pBookingType", BookingType))


            ElseIf rdbSelectionRpt.SelectedValue = "2" Then
                intNetID = 70482           ''For OtRegDtwise.rdl
                Param.Add(New ReportParameter("PCOCD", Session("COMPANYCODE").ToString))
                Param.Add(New ReportParameter("PDIVCD", Session("DIVCODE").ToString))
                Param.Add(New ReportParameter("PLOCCD", Session("LOCCODE").ToString))
                Param.Add(New ReportParameter("FCTCODE", otno))
                Param.Add(New ReportParameter("APTM_FRM_DATE", frmdt))
                Param.Add(New ReportParameter("APTM_TO_DATE", ToDt))
                Param.Add(New ReportParameter("flg", ""))
                Param.Add(New ReportParameter("APTM_STS", "1"))
                Param.Add(New ReportParameter("Doc_Cd", Doccd))
                Param.Add(New ReportParameter("OTDesc", txtotname.Text))

            ElseIf rdbSelectionRpt.SelectedValue = "3" Then
                intNetID = 70971
                Param.Add(New ReportParameter("PCOCD", Session("COMPANYCODE").ToString))
                Param.Add(New ReportParameter("PDIVCD", Session("DIVCODE").ToString))
                Param.Add(New ReportParameter("PLOCCD", Session("LOCCODE").ToString))
                If (frmdt <> Nothing) Then
                    Param.Add(New ReportParameter("APTM_FRM_DATE", CDate(txtFrmDt.Text).ToString("dd/MM/yyyy")))
                Else
                    Param.Add(New ReportParameter("APTM_FRM_DATE", frmdt))
                End If
                If (ToDt <> Nothing) Then
                    Param.Add(New ReportParameter("APTM_TO_DATE", CDate(txtToDt.Text).ToString("dd/MM/yyyy")))
                Else
                    Param.Add(New ReportParameter("APTM_TO_DATE", ToDt))
                End If
                Param.Add(New ReportParameter("Doc_Cd", Doccd))

            ElseIf rdbSelectionRpt.SelectedValue = "4" Then
                intNetID = 71029           ''For OTScheduling.rdl
                Param.Add(New ReportParameter("PCOCD", Session("COMPANYCODE").ToString))
                Param.Add(New ReportParameter("PDIVCD", Session("DIVCODE").ToString))
                Param.Add(New ReportParameter("PLOCCD", Session("LOCCODE").ToString))
                Param.Add(New ReportParameter("FCTCODE", otno))
                Param.Add(New ReportParameter("APTM_FRM_DATE", frmdt))
                Param.Add(New ReportParameter("APTM_TO_DATE", ToDt))
                Param.Add(New ReportParameter("flg", ""))
                Param.Add(New ReportParameter("APTM_STS", "4"))
                Param.Add(New ReportParameter("Doc_Cd", Doccd))
                Param.Add(New ReportParameter("OTDesc", txtotname.Text))
            End If

            Param.Add(New ReportParameter("Duplicate", ""))
            Param.Add(New ReportParameter("usrid", userid))

            Session("Param") = Param

            Dim UseReportViewer As Boolean = False
            UseReportViewer = OTScheduling.GetPrntRptViewerRule8013(strErrMsg, chrErrFlg, Convert.ToString(Session("COMPANYCODE")), Convert.ToInt32(Session("DIVCODE")), Convert.ToInt32(Session("LOCCODE")))

            If UseReportViewer = False Then
                Dim pByteArray() As Byte = Nothing
                OTScheduling.SetParamAndViewReport(strErrMsg, chrErrFlg, Session("COMPANYCODE").ToString(), Convert.ToInt32(Session("DIVCODE")), Convert.ToInt32(Session("LOCCODE")), Convert.ToInt32(Session("MAINMODCODE")), Convert.ToInt32(Session("MAINSUBMODCODE")), intNetID, Param, pByteArray, Page)

                Session("ppdf") = pByteArray
            Else
                ''START : PRINT IN REPORT VIEWER CONTROL
                'USE BELOW PART OF CODE TO PRINT IN REPORT VIEWER CONTROL

                'comnted on 16May2017 and revert back to earlier code to print in pdf format on page.
                Session("param") = Param
                Session("netid") = intNetID
                ' ScriptManager.RegisterStartupScript(Me, [GetType](), "", "window.parent.location.href='ViewRpt1.aspx';", True)
                ' Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "window.parent.location.href='ReportViewerRpt.aspx';",  true);
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "window.parent.location.href='ReportViewerRpt.aspx';", True)

                'END : PRINT IN REPORT VIEWER CONTROL
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        Try
            txtot.Text = ""
            txtotname.Text = ""
            txtdctid.Text = ""
            txtdctname.Text = ""
            rdbSelectionRpt.SelectedValue = "1"
            chkDtRng.Checked = False
            chkDtRng_CheckedChanged(sender, e)

            drpBookingType.SelectedValue = "SELECT"

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Try
            Session("chkDtRng") = Nothing
            Session("FrmDateWise") = Nothing
            Session("ToDateWise") = Nothing
            Session("OTNo") = Nothing
            Session("OTNm") = Nothing
            Session("DocCd") = Nothing
            Session("DocNm") = Nothing

            Response.Redirect("Default.aspx")
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

    Protected Sub rdbSelectionRpt_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If (rdbSelectionRpt.SelectedValue = "3") Then
                ImageButton2.Enabled = False
                txtot.Enabled = False
                txtotname.Enabled = False
            Else
                ImageButton2.Enabled = True
                txtot.Enabled = True
                txtotname.Enabled = True
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
End Class