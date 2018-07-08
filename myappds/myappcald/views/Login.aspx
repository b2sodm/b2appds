<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="myappcald.views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <h2>AppDiarySystem</h2>
    <form id="frmLog" runat="server">
        <asp:Table CellSpacing="2" CellPadding="2" BorderWidth="1" runat="server">
            <asp:TableRow>
                <asp:TableCell><label>Info:</label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txbInfo" Text="" ReadOnly="true" MaxLength="50" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label>User Name:</label></asp:TableCell>
                <asp:TableCell><input type="email" id="usrEmail" required="required" maxlength="30" runat="server"  /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label>Password:</label></asp:TableCell>
                <asp:TableCell><input type="password" id="usrPasswd" required="required" minlength="2"  maxlength="10" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell><asp:Button ID="BtnLogin" Text="Login" runat="server" OnClick="BtnLogin_Click" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div>
            <br />
            <a href="Registration.aspx">Sign up</a>
            <br />
            <asp:Label ID="lblFed" runat="server"></asp:Label><br />
            <br /><hr /><br />
        </div>
        <asp:Calendar ID="cldInfo" runat="server"></asp:Calendar>
        <div>
            <asp:PlaceHolder ID="placeHolder" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
