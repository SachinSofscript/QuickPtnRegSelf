#Region "IMPORTS"
Imports OTScheduling.clsGeneral
Imports CWCommonLib.Sofscript
#End Region

Public Class MasterPage
    Inherits System.Web.UI.MasterPage

#Region "GLOBAL DECLRATIONS"
    Dim strErrMsg As New List(Of String)
    Dim chrErrFlg As Char = CChar("N")
    ' Dim clsSession As New SessionVariables
    Dim clsSession As SessionVariables  'aparna 28 mar 2015
    Dim BottomText As String = System.Configuration.ConfigurationManager.AppSettings("BottomText") 'anamika 20130920
    Dim ClientImg As String = System.Configuration.ConfigurationManager.AppSettings("ClientImg")
    Dim SofImg As String = System.Configuration.ConfigurationManager.AppSettings("SofImg")
#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init



        Try

            Dim IsCWDebugModeOn As String = "N"
            IsCWDebugModeOn = System.Configuration.ConfigurationManager.AppSettings("IsCWDebugModeOn")
            If (IsCWDebugModeOn = "Y") Then
                Dim CSS_serverpath As String = System.Configuration.ConfigurationManager.AppSettings("CSS_serverpath")

                'local use
                'cssMaster.Attributes.Add("href", CSS_serverpath & "/Master.css")
                'cssMaster.Attributes.Add("typ", "text/css")
                'CssCommon.Attributes.Add("href", CSS_serverpath & "/stylesheet.css")
                'CssCommon.Attributes.Add("typ", "text/css")
                'CssButton.Attributes.Add("href", CSS_serverpath & "/ButtonStyles.css")
                'CssButton.Attributes.Add("typ", "text/css")
                'cssAlertifyBoot.Attributes.Add("href", CSS_serverpath & "/alertify.bootstrap.css")
                'cssAlertifyBoot.Attributes.Add("typ", "text/css")
                'cssAlertify.Attributes.Add("href", CSS_serverpath & "/alertify.core.css")
                'cssAlertify.Attributes.Add("typ", "text/css")
                'local use end

                'userid = "SSSL"
                'companycode = "1"
                'div = 1
                'loc = 1
                'Session("USERID") = userid
                'Session("COMPANYCODE") = companycode
                'Session("DIVCODE") = div
                'Session("LOCCODE") = loc
                ''Session("SHIFT") = clsSession.Shift
                'lblUser.Text = Session("USERID").ToString.ToUpper()
                'lblClient.Text = "Sofscript Hospital Pvt. Ltd."
                'lblAppName.Text = "OT SCHEDULING"
                'lblDiv.Text = "Sofscript Hospital"
                'lblLoc.Text = "Mumbai"
                'lblBottomText.Text = "@ 2013 Sofscript System & Services Ltd."
                'imgSof.ImageUrl = SofImg
                'imgClient.ImageUrl = ClientImg
                'Session("MAINMODCODE") = 439
                'Session("MAINSUBMODCODE") = 412
            Else

                clsSession = New SessionVariables   'aparna 28 mar 2015
                If Not Page.IsPostBack Then
                    If Request.QueryString.Count <> 0 Then
                        If Request.QueryString("ref") IsNot Nothing Then
                            clsGeneral.SetValues(Request.QueryString("ref"))
                            clsSession = SessionVariables.RetrieveSessionData(Request.QueryString("ref"))
                            Dim objSesVar As New SessionVariables   'aparna 28 mar 2015
                            clsSession = objSesVar.ReadSessionData(Request.QueryString("ref"))
                            objSesVar = Nothing

                            Session("RequestParameter") = Request.QueryString("ref")
                            Session("SESSIONVERIABLE") = clsSession
                            Session("USERID") = clsSession.userid
                            Session("COMPANYCODE") = clsSession.companycode
                            Session("DIVCODE") = clsSession.div
                            Session("LOCCODE") = clsSession.loc
                            Session("USERDOCCD") = clsSession.UserDocCd
                            Session("MAINMODCODE") = clsSession.ModCd
                            Session("MAINSUBMODCODE") = clsSession.SubModCd
                            Session("SHIFT") = clsSession.Shift
                            lblUser.Text = Session("USERID").ToString.ToUpper()
                            lblUser.Text = clsSession.UserNickName 'anamika 20160201
                            lblUser.Text = Session("USERID").ToString.ToUpper()
                            Session("AppName") = clsSession.ApplicationName
                            lblAppName.Text = Session("AppName")
                            lblClient.Text = clsSession.CompanyName
                            lblDiv.Text = clsSession.DivisionName
                            lblLoc.Text = clsSession.LocationName
                            lblBottomText.Text = BottomText
                            imgSof.ImageUrl = SofImg
                            imgClient.ImageUrl = ClientImg
                            If Request.QueryString("AppName") IsNot Nothing Then
                                Session("AppName") = Request.QueryString("AppName")
                                lblAppName.Text = Session("AppName")
                            End If
                        Else
                            GetCommonValues()
                        End If
                    Else
                        GetCommonValues()
                    End If
                    GetCommonValues()
                End If
                clsGeneral.CheckSession(Me.Context, Session("USERID"))

            End If
        Catch ex As Exception
            clsGeneral.CheckSession(Me.Context, Session("USERID"))
        Finally
            clsSession = Nothing
        End Try



    End Sub
#End Region

#Region "FUNCTIONS"
    Public Sub GetCommonValues()
        clsSession = New SessionVariables  'aparna 28 mar 2015
        clsSession = Session("SESSIONVERIABLE")
        If clsSession IsNot Nothing Then
            Session("USERID") = clsSession.userid
            Session("COMPANYCODE") = clsSession.companycode
            Session("DIVCODE") = clsSession.div
            Session("LOCCODE") = clsSession.loc
            'anamika 20140204
            Session("USERDOCCD") = clsSession.UserDocCd
            Session("MAINMODCODE") = clsSession.ModCd
            Session("MAINSUBMODCODE") = clsSession.SubModCd
            '20140204
            'lblUser.Text = Session("USERID").ToString.ToUpper()
            lblUser.Text = clsSession.UserNickName 'anamika 20160201
            lblAppName.Text = Session("AppName")
            lblClient.Text = clsSession.CompanyName
            lblDiv.Text = clsSession.DivisionName
            lblLoc.Text = clsSession.LocationName
            lblBottomText.Text = BottomText
            imgSof.ImageUrl = SofImg
            imgClient.ImageUrl = ClientImg
        End If
    End Sub
#End Region

End Class