<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="myappds.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <h2>AppDiarySystem</h2>
    <form id="frmInd" runat="server">
        <div>
             <ul>
                <li><a href="Login.aspx">Login</a></li>
                <li><a href="views/Registration.aspx">Sign up</a></li>
                <li><a href="Login.aspx?=admin">Admin</a></li>
                <li><a href="Login.aspx?=neworg">New organisation</a></li>
                <li><a href="Login.aspx?=newbran">New branch</a></li>
            </ul>
        </div>
        <asp:Calendar ID="cldInfo" runat="server"></asp:Calendar>
    </form>
</body>
</html>
