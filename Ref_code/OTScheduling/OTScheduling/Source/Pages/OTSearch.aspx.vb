#Region "IMPORTS"
Imports OTScheduling.OTSchedulingSerRef
Imports OTScheduling.CmnSecurityFunSrvRef
#End Region

Partial Class Pages_OTSearch
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLRATIONS"
    Dim row As GridViewRow
    'Dim objclsFCTMST As List(Of clsFCTMST)
    Dim objclsFCTMST As List(Of clsFCTMstHelp)
    Dim lbl As Label
    Dim val1 As String
    Dim val2 As String
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            clsGeneral.CheckSession(Me.Context, Session("USERID"))
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
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

                'objclsFCTMST = OTScheduling.GetFCTMST(strErrMsg, chrErrFlg, 1, Session("DIVCODE"), Session("LOCCODE"), 1, 1, 1)

                objclsFCTMST = OTScheduling.GetFCTMstLst(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1) 'RasikV 20170130
                If IsNothing(objclsFCTMST) Then
                    GrdOTDetails.Visible = False
                    GrdOTDetails.DataSource = Nothing
                    GrdOTDetails.DataBind()
                    lblNoOfRecords.Text = 0
                Else
                    GrdOTDetails.Visible = True
                    GrdOTDetails.DataSource = objclsFCTMST
                    GrdOTDetails.DataBind()
                    lblNoOfRecords.Text = objclsFCTMST.Count
                    GrdOTDetails.Focus()
                    Session("Patient") = objclsFCTMST
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
#End Region

#Region "BUTTON EVENTS"
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

    End Sub
#End Region

End Class
