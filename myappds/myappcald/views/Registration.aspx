<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="myappcald.views.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <a href="../Index.aspx">Info</a>
    <br /><hr />
    <div>
        <h2>AppDiarySystem</h2>
        <h3>Registration / Sign up</h3>
    </div>
    <form id="frmReg" runat="server">
        <asp:Table CellSpacing="2" CellPadding="2" BorderWidth="1" runat="server">
            <asp:TableRow>
                <asp:TableCell><label>Info:</label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txbInfo" Text="" ReadOnly="true" MaxLength="50" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label>Name:</label></asp:TableCell>
                <asp:TableCell><input type="text" id="usrName" required="required" maxlength="30" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label>Surname:</label></asp:TableCell>
                <asp:TableCell><input type="text" id="usrSurname" required="required" maxlength="30" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label>Email:</label></asp:TableCell>
                <asp:TableCell><input type="email" id="usrEmail" required="required" maxlength="30" runat="server"  /></asp:TableCell>
                <asp:TableCell><asp:label ID="lblVemail" ForeColor="Red" runat="server"></asp:label><br /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label id="lblPwd" runat="server">Password:</label></asp:TableCell>
                <asp:TableCell><input type="password" id="usrPasswd" required="required" minlength="5"  maxlength="10" runat="server" /></asp:TableCell>
                <asp:TableCell><asp:Label ID="lblVpasswd" ForeColor="Red" runat="server"></asp:Label><br /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="rdbList" runat="server">
                        <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem> 
                        <asp:ListItem Text="User" Value="User"></asp:ListItem>
                        <asp:ListItem Text="Guest" Value="Guest"></asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell><asp:Label ID="lblRlist" ForeColor="Red" runat="server"></asp:Label><br /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell><asp:Button ID="BtnRegister" Text="Register(SignUp)" runat="server" OnClick="BtnRegister_Click" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div>
            <br />
            <asp:Label ID="lblFed" runat="server"></asp:Label><br />
            <br /><hr /><br />
        </div>
        <asp:Calendar ID="cldInfo" runat="server"></asp:Calendar>
    </form>
</body>
</html>
