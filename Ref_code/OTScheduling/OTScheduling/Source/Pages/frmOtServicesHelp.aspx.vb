#Region "IMPORTS"
Imports OTScheduling.OTSchedulingSerRef
Imports OTScheduling.CmnSecurityFunSrvRef
#End Region

Partial Class Pages_frmOtServicesHelp
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLARATION"
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char

    Dim Speciality As String

    Dim row As GridViewRow
    Dim objSrvLst As List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
    Dim objSrv As OTSchedulingSerRef.ClsOtSrvLstDtls()
    Dim lbl As Label
    Dim val1 As String
    Dim val2 As String

#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        clsGeneral.CheckSession(Me.Context, Session("USERID"))
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

        If Not IsPostBack Then
            clsGeneral.CheckSession(Me.Context, Session("USERID"))
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Try
                GrdDoctorDetails.Visible = False
                GrdDoctorDetails.DataSource = Nothing
                GrdDoctorDetails.DataBind()
                lblNoOfRecords.Text = 0
                Session("SrvLstHelp") = Nothing




            Catch ex As Exception
                clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
            End Try
        End If

    End Sub
#End Region

#Region "BUTTON EVENTS"
    'Protected Sub btnSrvSrch_Click(sender As Object, e As EventArgs) Handles btnSrvSrch.Click
    '    Search()
    'End Sub
#End Region

#Region "FUNCTIONS"
    Public Sub Search()
        'objSrv = Session("SrvLstHelp")

        ''Speciality = (ddlSpeciality.SelectedItem).ToString
        ''If Speciality = "All" Then
        ''    Speciality = ""
        ''End If
        ''Dim n = From obj In objSrv Where (obj.srvdesc.IndexOf(Request("txtDoctorFullName"), StringComparison.OrdinalIgnoreCase)) >= 0 And (obj.SpecialityCodeDesc.IndexOf(Speciality, StringComparison.OrdinalIgnoreCase)) >= 0 Select obj
        'Dim n = From obj In objSrv Where (obj.srvdesc.IndexOf(Request("txtDoctorFullName"), StringComparison.OrdinalIgnoreCase)) >= 0 Select obj
        'If n IsNot Nothing Then
        '    GrdDoctorDetails.DataSource = n
        '    GrdDoctorDetails.DataBind()
        '    lblNoOfRecords.Text = n.Count
        'End If
        Dim result = txtCriteria.Text.Length
        If result < 3 Then
            clsGeneral.ShowErrorPopUp("Please Enter Atleast 3 letters", txtCriteria.Text, Page)
            Exit Sub
        End If

        objSrvLst = OTScheduling.GetListOfOTSrvDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), txtCriteria.Text)
        If IsNothing(objSrvLst) Then
            GrdDoctorDetails.Visible = False
            GrdDoctorDetails.DataSource = Nothing
            GrdDoctorDetails.DataBind()
            lblNoOfRecords.Text = 0
            Session("SrvLstHelp") = Nothing
        Else
            GrdDoctorDetails.Visible = True
            GrdDoctorDetails.DataSource = objSrvLst
            GrdDoctorDetails.DataBind()
            lblNoOfRecords.Text = objSrvLst.Count
            GrdDoctorDetails.Focus()
            Session("SrvLstHelp") = objSrvLst

        End If




    End Sub

    'Protected Sub btnSrvSrch_Click1(sender As Object, e As EventArgs)
    '    Search()
    'End Sub

    Protected Sub btnSrvSch_Click(sender As Object, e As EventArgs)
        Try
            Search()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "COMMENTS"
    'Public Sub AddDefField(ByVal ddl As DropDownList)
    '    ddl.Items.Add("All")
    '    ddl.DataMember = "All"
    '    ddl.DataValueField = "9999"
    '    ddl.SelectedValue = "All"
    'End Sub
    'Protected Sub ddlSpeciality_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSpeciality.SelectedIndexChanged
    '    Try
    '        Search()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub btnDoctSearch_Click(sender As Object, e As EventArgs) Handles btnDoctSearch.Click
    '    Try
    '        Search()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
    '    Search()
    'End Sub
#End Region

End Class
