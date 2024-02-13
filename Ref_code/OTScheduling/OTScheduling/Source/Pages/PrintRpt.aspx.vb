Imports Microsoft.Reporting.WebForms
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports System.Net

Public Class PrintRpt
    Inherits System.Web.UI.Page

    Dim strErrMsg As New List(Of String)
    Dim chrErrFlg As Char = CChar("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Dim bytes As Byte()
            'bytes = DirectCast(Session("ppdf"), Byte())
            'Dim tempguid As String = System.Guid.NewGuid.ToString
            'Dim directorypath As String = Server.MapPath(String.Format("~/{0}/", "" & Session("Guid").ToString & ""))
            'If Not Directory.Exists(directorypath) Then
            '    Directory.CreateDirectory(directorypath)
            'End If
            'Dim pdfPath As String = Server.MapPath("~\" & Session("Guid").ToString & "\" & tempguid.ToString & ".pdf")
            'Dim pdfFile As New System.IO.FileStream(pdfPath, System.IO.FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
            'pdfFile.Write(bytes, 0, bytes.Length)
            'pdfFile.Close()
            'iFrameDiag.Attributes.Add("src", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & HttpRuntime.AppDomainAppVirtualPath & "/" & Session("Guid").ToString & "/" & tempguid.ToString & ".pdf")
            'Session("ppdf") = Nothing
            'Session("tempguid") = Nothing
            'Session("directorypath") = directorypath


            ''Added on 26-Oct-2016 by sadiq - referenced from Discharge Module.
            If (Session("ppdf") IsNot Nothing) Then

                Dim img1 As Byte() = Nothing
                img1 = DirectCast(Session("ppdf"), Byte())
                Context.Response.Clear()
                Context.Response.BufferOutput = False
                Context.Response.StatusCode = CInt(HttpStatusCode.OK)
                ' Context.Response.ContentType = "image/JPEG"
                Dim responseImage As Byte() = img1
                ' Response.AddHeader("Content-Length", img1.Length)
                Context.Response.Clear()
                Context.Response.ContentType = "application/pdf"
                'Context.Response.BinaryWrite(img1)
                Context.Response.OutputStream.Write((img1), 0, img1.Length)
                HttpContext.Current.ApplicationInstance.CompleteRequest()
                Context.Response.Flush()
                'Context.Response.End()

                ' Session("ppdf") = Nothing
            End If

        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub

End Class