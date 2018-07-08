'//////////////////////////////
'// @author:Brian
'// BM 2018
'// Login.aspx.vb
'//////////////////////////////////

Imports System
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports myappcald

Public Class Login
    Inherits System.Web.UI.Page

    Dim strBrowser, strUrl, strIP As String
    Dim name, email, passwd, puser, info, ph As String
    Const Pname As String = "myappcald"
    Dim lptoken As Integer
    Dim pticks As Long
    Dim pmess As myappcald.admin.Paiclock

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        name = "Name01"
        puser = "User01"
        pmess = New admin.Paiclock
        info = Request.QueryString.Get("info")
        strUrl = Request.Url.ToString()
        strBrowser = Request.Browser.Browser.ToString()
        strIP = Request.UserHostAddress.ToString()
        pticks = Now.Ticks
        ph += "<br>Date: " & Now().Date
        ph += "<br>Timex: " & Now.ToLocalTime()
        ph += "<br>Timey: " & Now.TimeOfDay().ToString()
        ph += "<br>Ticks: " & pticks
        ph += "<br> " & info
        ph += "<br>Url:  " & strUrl
        ph += "<br>IP: " & strIP
        ph += "<br>Browser: " & strBrowser
        ph += "<br>M: " & pmess.Pmessage()
        ph += "<br>T: " & pmess.Ptime()
        txbInfo.Text = Now()
        calInfo.SelectedDate = Now().Date
        placeHolder.Controls.Add(New LiteralControl(ph.ToString()))
    End Sub

    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim cTrim() As Char = {" ", "\", "'", ",", ";", "<", ">", "=", "-", "+", "#", """", "''"}
        email = usrEmail.Value.Trim()
        passwd = usrPasswd.Value.Trim(cTrim)
        info = txbInfo.Text.Trim(cTrim)
        lblFed.Text = ""
        lblFed.ForeColor = Color.Green
        lblFed.BackColor = Color.SkyBlue
        Dvalidate()
    End Sub

    Private Sub Dvalidate()
        Dim err As Integer = 0
        Dim dval As String = " "
        Dim regEm As Regex = New Regex("^.+@.+\..+$")
        Dim memail As Match = regEm.Match(email)
        If Not (memail.Success) Then
            err += 1
            lblFed.Text = "<br>Err: " & err
            lblFed.ForeColor = Color.Red
        End If

        If (passwd.Length < 5) Then
            err += 1
            lblFed.Text = "<br>Err: " & err
            lblFed.ForeColor = Color.Yellow
        End If

        dval = ("<br>Info: " & info)
        dval += ("<br>Name: " & name)
        dval += ("<br>Email: " & email)
        dval += ("<br>User: " & puser)
        dval += ("<br>Err: " & err)
        lblFed.Text = (dval)
        If (err < 1) Then
            Processp()
        End If
    End Sub

    Private Sub Processp()
        '//ASCII character set 0 to 127.
        '//Bytes 0 to 255.
        Dim temp As String = "temp1@"
        temp += passwd
        temp += email.ElementAt(0)
        temp += Pname.ElementAt(6)
        temp += email
        Dim tl As Integer = temp.Length
        Dim t4 As Integer = 0
        '//////////////////////////////////////////////////////
        For i As Integer = 0 To tl - 1
            t4 += i
            'Response.Write(" # " & t4)
        Next
        Dim bt As Byte() = Encoding.UTF8.GetBytes(temp)
        Dim dhash As SHA512 = SHA512.Create()
        Dim dbyte As Byte() = dhash.ComputeHash(bt)
        Dim thx123 As String = Convert.ToBase64String(dbyte)
        lptoken = email.Length + t4
        passwd = "p" & thx123 + "" & lptoken
        Pconnect()
    End Sub

    Private Sub Pconnect()
        Dim lpt As Long = DateTime.Now.Ticks
        Const Portnp As String = "49368"
        Const LogOutp As String = "<a href=" & "http://localhost:" & Portnp & "/Index.aspx" & ">Log out</a>"
        Const LogInp As String = "<a href=" & "http://localhost:" & Portnp & "/views/Login.aspx" & ">Login</a>"
        Response.Write("<br>" & lpt)
        lpt += lptoken
        Response.Write("<br>" & lpt)
        Dim mtoken As String = "T" & lpt.GetHashCode().ToString() & "T"
        Response.Write("<br>")
        Response.Write(LogOutp)
        Response.Write("<br>" & email)
        Response.Write("<br>" & passwd)
        Response.Write("<br>" & mtoken)
        Response.Write("<br>" & pticks)
        Response.Write("<br>")
        Response.Write(LogInp)
        Response.Write("<br>" & Portnp)
    End Sub
End Class