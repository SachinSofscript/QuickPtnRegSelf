Imports Microsoft.Reporting.WebForms

Public Class ReportVererCredentials


    Implements IReportServerCredentials
    Private _userName As String
    Private _password As String
    Private _domain As String
    Public Sub New(ByVal userName As String, ByVal password As String)
        _userName = userName


        _password = password





    End Sub
    Public ReadOnly Property ImpersonationUser() As System.Security.Principal.WindowsIdentity Implements Microsoft.Reporting.WebForms.IReportServerCredentials.ImpersonationUser
        Get
            Return Nothing
        End Get
    End Property
    Public ReadOnly Property NetworkCredentials() As System.Net.ICredentials Implements Microsoft.Reporting.WebForms.IReportServerCredentials.NetworkCredentials
        Get
            Return New Net.NetworkCredential(_userName, _password)
        End Get
    End Property
    Public Function GetFormsCredentials(ByRef authCookie As System.Net.Cookie, ByRef userName As String, ByRef password As String, ByRef authority As String) As Boolean Implements Microsoft.Reporting.WebForms.IReportServerCredentials.GetFormsCredentials
        userName = _userName


        password = _password





        Return Nothing
    End Function

End Class