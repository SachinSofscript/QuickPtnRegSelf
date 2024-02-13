#Region "IMPORTS"
Imports OTScheduling.OTSchedulingSerRef
Imports OTScheduling.CmnSecurityFunSrvRef
#End Region

Public Class frmOTEmpHelp
    Inherits System.Web.UI.Page

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'clsGeneral.CheckSession(Me.Context, Session("USERID"))
        'Dim CSS_serverpath As String = System.Configuration.ConfigurationManager.AppSettings("CSS_serverpath")
        ''''''cssMaster.Attributes.Add("href", CSS_serverpath & "/Master.css")
        ''''''cssMaster.Attributes.Add("typ", "text/css")
        'CssCommon.Attributes.Add("href", CSS_serverpath & "/stylesheet.css")
        'CssCommon.Attributes.Add("typ", "text/css")
        'CssButton.Attributes.Add("href", CSS_serverpath & "/ButtonStyles.css")
        'CssButton.Attributes.Add("typ", "text/css")
        'cssAlertifyBoot.Attributes.Add("href", CSS_serverpath & "/alertify.bootstrap.css")
        'cssAlertifyBoot.Attributes.Add("typ", "text/css")
        'cssAlertify.Attributes.Add("href", CSS_serverpath & "/alertify.core.css")
        'cssAlertify.Attributes.Add("typ", "text/css")


        clsGeneral.CheckSession(Me.Context, Session("USERID"))
        Try
            Dim strErrMsg As New List(Of String)
            Dim chrErrFlg As String = "N"
            Dim objclsattpaydbEmpId As List(Of clsAttPayDbEmpId)
            objclsattpaydbEmpId = OTScheduling.GetOTEmpList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
            gddetails.DataSource = objclsattpaydbEmpId
            gddetails.DataBind()
            lblNoOfRecords.Text = gddetails.Rows.Count
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try


    End Sub
#End Region

End Class