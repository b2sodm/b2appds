'//////////////////////////////
'// @author:Brian
'// BM 2018
'// Registration.aspx.vb
'//////////////////////////////////

Imports System
Imports System.Drawing
Imports System.Text
Imports System.Security.Cryptography
Imports myappcald

Public Class Registration
    Inherits System.Web.UI.Page

    Dim name, surname, email, passwd, puser, info, strTrim As String
    Const Pname As String = "myappcald"
    Dim lptoken As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim t As DateTime = DateTime.Now()
        txbInfo.Text = t.ToString()
        cldInfo.SelectedDate = t.Date
    End Sub

    Protected Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        Dim cTrim() As Char = {"\", " ", "'", ",", ";", "<", ">", "=", "-", "+", """", "#", "''"}
        name = usrName.Value.Trim(cTrim)
        surname = usrSurname.Value.Trim(cTrim)
        email = usrEmail.Value.Trim()
        passwd = usrPasswd.Value.Trim(cTrim)
        puser = rdbList.Text.Trim(cTrim)
        info = txbInfo.Text.Trim(cTrim)
        lblRlist.Text = ""
        lblVemail.Text = ""
        lblVpasswd.Text = ""
        strTrim = " "
        lblFed.ForeColor = Color.Green
        lblFed.BackColor = Color.SkyBlue
        Dim i As Integer
        For i = 0 To cTrim.Length - 1
            strTrim += cTrim.GetValue(i)
            'Response.Write("<br> " & i & " " & cTrim.GetValue(i))
        Next

        Dvalidate()

    End Sub

    Private Sub Dvalidate()
        'Response.Write("<br> " & strTrim)
        'Response.Write("<br> " & strTrim.Length)
        Dim err As Integer = 0
        Dim dval As String = " "
        Dim regEm As Regex = New Regex("^.+@.+\..+$")
        Dim memail As Match = regEm.Match(email)
        If Not (memail.Success) Then
            err += 1
            lblVemail.Text = "Invalid email: " + email
            usrEmail.Focus()
            lblFed.ForeColor = Color.Red
        End If

        If (passwd.Length < 5) Then
            err += 1
            lblVpasswd.Text = "Passwd < 5, trim: " + strTrim
            usrPasswd.Focus()
            lblFed.ForeColor = Color.Yellow
        End If

        If (puser = "") Then
            err += 1
            lblRlist.Text = "Please select one radio button."
            lblFed.ForeColor = Color.Orange
        End If

        dval = ("<br>Info: " + info)
        dval += ("<br>Name: " + name)
        dval += ("<br>Surname:" + surname)
        dval += ("<br>Email: " + email)
        dval += ("<br>Pwd: ")
        dval += ("<br>User: " + puser)
        dval += ("<br>Err: " & err)
        lblFed.Text = (dval)
        If (err < 1) Then
            Processp(info, name, surname, email, passwd, puser)
            Processp()
        End If
    End Sub

    Private Sub Processp()
        'Response.Write("<br>Processing...")
        'ASCII character set 0 to 127.
        'Bytes 0 to 255.
        Dim temp As String = "temp1@"
        temp += passwd
        temp += email.ElementAt(0)
        temp += Pname.ElementAt(6)
        temp += email
        Dim tl As Integer = temp.Length
        Dim b As Byte() = New Byte(tl) {}
        '//////////////////////////////////////////////////////
        Dim bt As Byte() = Encoding.UTF8.GetBytes(temp)
        Dim btl As Integer = bt.Length
        Dim t4 As Integer = 0
        'Response.Write("//<br>#bt3 " & btl & "<br>")
        Dim i As Integer
        For i = 0 To tl - 1
            t4 += i
        Next
        'Response.Write("<br>#bt " & i & " Enco# " & t4)
        Dim dhash As SHA512 = SHA512.Create()
        Dim dbyte As Byte() = dhash.ComputeHash(bt)
        Dim dasc As ASCIIEncoding = New ASCIIEncoding()
        Dim rslt As String = dasc.GetString(dbyte)
        Dim rsltl As Integer = rslt.Length
        'Response.Write("<br>#rslt " & rsltl & " AsciiEnco# " & rslt)
        Dim tm127 As String = "#"
        Dim tm As String
        Dim th As Integer
        Dim tmh As String
        Dim thx123p As String = "#"
        Dim tm255 As String = "#"
        Dim tmob As String = ""
        Dim thx123 As String = Convert.ToBase64String(dbyte)
        For i = 0 To rsltl - 1
            tm = rslt.ElementAt(i)
            tm127 &= tm
            'Response.Write("<br>#byte " & i & " # " & tm)
            th = dbyte.ElementAt(i)
            tm255 &= th
            tmh = Hex(th)
            thx123p += tmh
            tmob &= th
            'Response.Write("<br>#ASCII127 " & i & " # " & th)
            'Response.Write("<br>#HEX " & i & " # " & tmh)
        Next
        'Response.Write("<br>#t127 " & rsltl & "<br>" & tm127)
        'Response.Write("<br>#255 " & rsltl & "<br>" & tm255)
        Response.Write("<br>#hexp " & i & " <br> " & thx123p)
        Response.Write("<br>#hex " & i & " <br> " & thx123)
        'Response.Write("<br>#t127 " & rsltl & "<br>" & tm127.Length)
        'Response.Write("<br>#255 " & rsltl & "<br>" & tm255.Length)
        'Response.Write("<br>#hex " & i & " <br> " & thx123p.Length)
        lptoken = email.Length + t4
        'passwd = "p" + thx123 + "" & lptoken
        passwd = "p" & thx123 & "" & lptoken
        Register()
    End Sub

    Private Sub Register()
        Response.Write("<br> Almost done..." & lptoken.GetHashCode())
        'Dim portn As Integer = 49368
        Const Portnp As String = "49368"
        Const LogOutp As String = "<a href=" & "http://localhost:" & Portnp & "/Index.aspx" & ">Log out</a>"
        Const LogInp As String = "<a href=" & "http://localhost:" & Portnp & "/views/Login.aspx" & ">Login</a>"
        Dim lpt As Long = Now.Ticks
        Response.Write("<br>" & lpt)
        lpt += lptoken
        Dim mtoken As String = "T" & lpt.GetHashCode().ToString() & "T"
        Response.Write("<br>" & lpt)
        Response.Write("<br>" & email)
        Response.Write("<br>" & passwd)
        Response.Write("<br>" & passwd.Length)
        Response.Write("<br>" & mtoken)
        Response.Write("<br><a href=" & "../Login.aspx?info=" & mtoken & ">Info</a>")
        Response.Write("<br>" & LogInp & "<br>")
        Response.Write(LogInp)
        Response.Write("<br>" & LogOutp & "<br>")
        Response.Write(LogOutp)
        Response.Write("<br>" & Portnp)
        Dim myapp As myappcald.admin.Paiclock = New admin.Paiclock
        Response.Write("<br>" & myapp.Pmessage)
        Response.Write("<br>" & myapp.Ptime)
    End Sub

    Private Sub Processp(info As String, name As String, surname As String, email As String, passwd As String, puser As String)
        Try
            Dim myappd As myappcald.models.AppdsUser = New models.AppdsUser(info, name, surname, email, passwd, puser)
        Catch ex As Exception
            Response.Write("<br>PrExc: " & ex.ToString())
        End Try

    End Sub

End Class