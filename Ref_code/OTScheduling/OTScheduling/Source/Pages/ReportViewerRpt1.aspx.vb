#Region "IMPORTS"
Imports OTScheduling.AllotmentServiceReference
Imports OTScheduling.CmnSecurityFunSrvRef
Imports Microsoft.Reporting.WebForms
Imports WebAppTemplate.CommonMstServiceReference
Imports OTScheduling.OTSchedulingServiceReference

#End Region


Public Class ReportViewerRpt1
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLRATIONS"
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If (Not Page.IsPostBack) Then

                Dim p_bytes() As Byte = Nothing
                SetParamAndViewReport(CType(Session("param"), List(Of Microsoft.Reporting.WebForms.ReportParameter)), Convert.ToInt32(Session("netid")), p_bytes)
            End If


        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
        End Try
    End Sub

    Protected Sub SetParamAndViewReport(ByVal param As List(Of Microsoft.Reporting.WebForms.ReportParameter), ByVal netid As Integer, <System.Runtime.InteropServices.Out()> ByRef p_bytes() As Byte)
        Try
            Dim MAINMODCODE As Integer = Convert.ToInt32(Session("MAINMODCODE"))
            Dim MAINSUBMODCODE As Integer = Convert.ToInt32(Session("MAINSUBMODCODE"))
            Dim COMPANYCODE As String = Convert.ToString(Session("COMPANYCODE"))
            Dim DIVCODE As Integer = Convert.ToInt32(Session("DIVCODE"))
            Dim LOCCODE As Integer = Convert.ToInt32(Session("LOCCODE"))

            Dim objclsNetIDParam As List(Of clsNetIDParam) = Nothing
            objclsNetIDParam = OTScheduling.GetNetIdParamDetails(strErrMsg, chrErrFlg, COMPANYCODE, DIVCODE, LOCCODE, MAINMODCODE, MAINSUBMODCODE, netid)


            Dim objclsnet As CmnSecurityFunSrvRef.clsNetId = Nothing
            objclsnet = OTScheduling.GetNetIdDetailsWithForReportPath(strErrMsg, chrErrFlg, COMPANYCODE, DIVCODE, LOCCODE, netid)
            If objclsnet IsNot Nothing Then
                rview.ServerReport.ReportServerUrl = New System.Uri(objclsnet.DefPath)
                rview.ServerReport.ReportPath = objclsnet.TableName
            End If
            rview.ProcessingMode = ProcessingMode.Remote

            Dim ispasswordset As String = System.Configuration.ConfigurationManager.AppSettings("HasPassword")
            If ispasswordset = "Y" Then
                Dim usernamepassword As New List(Of String)()
                usernamepassword = OTScheduling.GetReportServerUserNamePassword(strErrMsg, chrErrFlg, COMPANYCODE, DIVCODE, LOCCODE)
                Dim irsc As IReportServerCredentials = New ReportVererCredentials(usernamepassword(2), usernamepassword(3))

                rview.ServerReport.ReportServerCredentials = irsc

            End If

            Dim ListNetIdParams As New List(Of CWSQLServerReportLib.NetIDParam)()
            For i As Integer = 0 To objclsNetIDParam.Count - 1
                Dim objReportLibNetIDParam As New CWSQLServerReportLib.NetIDParam()
                objReportLibNetIDParam.ParamID = objclsNetIDParam(i).ParamID
                objReportLibNetIDParam.ParamType = objclsNetIDParam(i).ParamType
                objReportLibNetIDParam.ParamValue = objclsNetIDParam(i).ParamValue
                objReportLibNetIDParam.ParamName = objclsNetIDParam(i).ParamName
                ListNetIdParams.Add(objReportLibNetIDParam)
            Next i
            Dim deviceInfo As String = ""

            ' Aarti 20170906
            Dim mimeType As String = ""
            Dim encoding As String = ""
            Dim extension As String = ""
            Dim warnings() As Microsoft.Reporting.WebForms.Warning = Nothing
            Dim format As String = "PDF"
            ' Aarti 20170906

            Dim objClsReportParams As New CWSQLServerReportLib.ClsReportParams()
            objClsReportParams.SetReportParameters(rview, param, deviceInfo, ListNetIdParams, False)

            ' Aarti 20170906
            Dim strErrMsg2() As String = Nothing

            Dim bytes() As Byte = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, strErrMsg2, warnings)


            p_bytes = bytes

            Session("ppdf") = p_bytes
            ' Aarti 20170906
        Catch ex As Exception

            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)

        Finally

        End Try
    End Sub

    Protected Sub btnBack1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("OtScheduling.aspx")
    End Sub
End Class