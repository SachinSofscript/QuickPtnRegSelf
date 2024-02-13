Public Class CreditCompHelp
    Inherits System.Web.UI.Page

    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As String = "N"
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


            strErrMsg = New List(Of String)
            Dim chrErrFlg As String = "N"
            '  Dim CodeType As String = Request.QueryString("Ref")
            Dim CodeType As String = Request.QueryString("frmname").Trim
            '  clsGeneral.ShowErrorPopUp(CodeType, "", Page)





            If CodeType = "CreditCo" Then
                lblHeader.Text = "Company List"
                gddetails.DataSource = OTScheduling.GetCreditCoListSts(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
                gddetails.DataBind()
                lblNoOfRecords.Text = gddetails.Rows.Count
                pnlAreaCd.Visible = True
            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub


    Protected Sub gddetails_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gddetails.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Header Then


                If lblHeader.Text = "Company List" Then

                        e.Row.Cells(0).Text = "COMPANY  CODE"
                        e.Row.Cells(1).Text = "COMPANY DESCRIPTION"
                    End If
                End If
        Catch ex As Exception
            'clsGeneral.ShowErrorPopUp(ex.Message, "", Page) 'aparna 07 JAN 2016
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page) 'aparna 07 JAN 2016
        End Try
    End Sub

End Class