Imports System
Imports System.Web.SessionState
Imports System.Text
Imports System.IO

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
        Dim excp As String = " "
        Dim url As String = " "
        Try
            Dim strFile As String
            strFile = Server.MapPath("log3.txt")
            Dim fStream As FileStream = New FileStream(strFile, FileMode.Append, FileAccess.Write)
            Dim log As New System.IO.StreamWriter(fStream)
            Dim exc As Exception = Server.GetLastError()
            url = Request.Url.ToString()
            excp = exc.ToString()
            log.WriteLine("######################################################")
            log.WriteLine(excp)
            log.WriteLine(url)
            log.WriteLine(Now())
            log.WriteLine(Request.UserHostAddress)
            log.WriteLine(Request.Browser.Browser.ToString())
            log.WriteLine(excp.Count())
            log.WriteLine("//////////////////////////////////////////////////////////")
            log.Close()
        Catch ex As Exception
            Response.Write("<br> Exception : <br> " & ex.ToString() & "<br>")
        Finally
            Response.Write("<a href=" & "Login.aspx?info=" & excp.Count() & ">Login</a>")
            If (url.Contains("views")) Then
                Response.Redirect("../Login.aspx?info=" & excp.Count())
            Else
                Response.Redirect("/Login.aspx?info=" & excp.Count())
            End If
        End Try
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class