#Region "IMPORTS"
Imports System.IO
Imports System.Net
#End Region

Partial Class Pages_image
    Inherits System.Web.UI.Page

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("img123") IsNot Nothing) Then

            Dim img1 As Byte() = Nothing
            img1 = DirectCast(Session("img123"), Byte())
            Context.Response.Clear()
            Context.Response.BufferOutput = False
            Context.Response.StatusCode = CInt(HttpStatusCode.OK)
            ' Context.Response.ContentType = "image/JPEG"
            Dim responseImage As Byte() = img1
            ' Response.AddHeader("Content-Length", img1.Length)
            Context.Response.Clear()
            Context.Response.ContentType = "image/jpg"
            'Context.Response.BinaryWrite(img1)
            Context.Response.OutputStream.Write((img1), 0, img1.Length)
            HttpContext.Current.ApplicationInstance.CompleteRequest()
            Context.Response.Flush()
            Context.Response.End()

            Session("img123") = Nothing


            'Dim bytes() As Byte = img1
            'Response.Buffer = True
            'Response.Charset = ""
            'Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Response.ContentType = "images/jpg"
            'Response.BinaryWrite(bytes)
            'Response.Flush()
            'Response.End()


        End If
    End Sub
#End Region

End Class
