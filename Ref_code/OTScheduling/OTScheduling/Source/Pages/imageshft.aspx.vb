#Region "IMPORTS"
Imports System.IO
Imports System.Net
#End Region

Partial Class Pages_imageshft
    Inherits System.Web.UI.Page

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("imgshft123") IsNot Nothing) Then
            Dim img1 As Byte() = Nothing
            img1 = DirectCast(Session("imgshft123"), Byte())
            Context.Response.Clear()
            Context.Response.BufferOutput = False
            Context.Response.StatusCode = CInt(HttpStatusCode.OK)
            Context.Response.ContentType = "image/JPEG"
            ' Context.Response.ContentType = Response.Headers("Content-Type").ToString()
            Dim responseImage As Byte() = img1
            '   Response.OutputStream.Write(img1, 0, img1.Length)
            Response.AddHeader("Content-Length", img1.Length)
            Context.Response.OutputStream.Write((img1), 0, img1.Length)
            HttpContext.Current.ApplicationInstance.CompleteRequest()
            Context.Response.Flush()
            Session("imgshft123") = Nothing
        End If
    End Sub
#End Region

End Class
