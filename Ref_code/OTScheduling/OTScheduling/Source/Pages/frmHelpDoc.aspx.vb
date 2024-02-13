#Region "IMPORTS"
Imports OTScheduling.OTSchedulingSerRef
Imports OTScheduling.CmnSecurityFunSrvRef
#End Region

Public Class frmHelpDoc
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLRATIONS"
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Dim objClsDoctor As List(Of clsDoctor)
    Dim objDoctor As List(Of clsDoctor)
    Dim objClsCodeDecode As List(Of OTSchedulingSerRef.clsCodeDecode)
    Dim Speciality As String
#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim CSS_serverpath As String = System.Configuration.ConfigurationManager.AppSettings("CSS_serverpath")
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
                Dim serverdttm As Date = clsGeneral.getdate()
                strErrMsg = New List(Of String)
                chrErrFlg = "N"
                'select All records from doctor_master
                objClsCodeDecode = OTScheduling.DoctorSpeciality(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
                If objClsCodeDecode IsNot Nothing And objClsCodeDecode.Count > 0 Then
                    ddlSpeciality.DataSource = objClsCodeDecode
                    ddlSpeciality.DataTextField = "Decode"
                    ddlSpeciality.DataValueField = "Code"
                    ddlSpeciality.DataBind()
                End If
                AddDefField(ddlSpeciality)
                'select All doctor speciality
                objClsDoctor = OTScheduling.GetDoctorList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
                Session("Doctor") = objClsDoctor

                If objClsDoctor IsNot Nothing Then
                    lblNoOfRecords.Text = objClsDoctor.Count
                    GrdDoctorDetails.DataSource = objClsDoctor
                    GrdDoctorDetails.DataBind()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "BUTTON EVENTS"
    Protected Sub btnDoctSearch_Click(ByVal sender As Object, ByVal e As EventArgs) 'Handles btnDoctSearch.Click
        Try
            Search()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnDoctSearch_Click1(sender As Object, e As EventArgs) Handles btnDoctSearch.Click

    End Sub
#End Region

#Region "FUNCTIONS"
    Public Sub AddDefField(ByVal ddl As DropDownList)
        ddl.Items.Add("All")
        ddl.DataMember = "All"
        ddl.DataValueField = "9999"
        ddl.SelectedValue = "All"
    End Sub

    Public Sub Search()
        objDoctor = Session("Doctor")

        Speciality = (ddlSpeciality.SelectedItem).ToString
        If Speciality = "All" Then
            Speciality = ""
        End If
        Dim n = From obj In objDoctor Where (obj.DoctorFullName.IndexOf(Request("txtDoctorFullName"), StringComparison.OrdinalIgnoreCase)) >= 0 And (obj.SpecialityCodeDesc.IndexOf(Speciality, StringComparison.OrdinalIgnoreCase)) >= 0 Select obj
        If n IsNot Nothing Then
            GrdDoctorDetails.DataSource = n
            GrdDoctorDetails.DataBind()
            lblNoOfRecords.Text = n.Count
        End If
    End Sub
#End Region

#Region "DROP DOWN EVENTS"
    Protected Sub ddlSpeciality_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSpeciality.SelectedIndexChanged
        Try
            Search()
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Class