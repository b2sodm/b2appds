<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registration.aspx.vb" Inherits="myappds.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <div>
        <h2>AppDiarySystem</h2>
        <h3>Registration / Sign up</h3>
    </div>
    <form id="frmReg" runat="server">
        <div>
            <label>Info:</label>
            <asp:TextBox ID="txbInfo" Text="" ReadOnly="true" MaxLength="50" runat="server"></asp:TextBox><br />
            <label>Name:</label>
            <input type="text" id="usrName" required="required" maxlength="30" runat="server" /><br />
            <label>Surname:</label>
            <input type="text" id="usrSurname" required="required" maxlength="30" runat="server" /><br />
            <label>Email:</label>
            <input type="email" id="usrEmail" required="required" maxlength="30" runat="server"  />
            <asp:label ID="lblVemail" ForeColor="Red" runat="server"></asp:label><br />
            <label id="lblPwd" runat="server">Password:</label>
            <input type="password" id="usrPasswd" required="required" minlength="5"  maxlength="10" runat="server" />
            <asp:Label ID="lblVpasswd" ForeColor="Red" runat="server"></asp:Label><br />
            <asp:RadioButtonList ID="rdbList" runat="server">
                <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem> 
                <asp:ListItem Text="User" Value="User"></asp:ListItem>
                <asp:ListItem Text="Guest" Value="Guest"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="lblRlist" ForeColor="Red" runat="server"></asp:Label><br />
            <asp:Button ID="BtnRegister" Text="Register(SignUp)" runat="server" OnClick="BtnRegister_Click" /><br />
            <asp:Label ID="lblFed" runat="server"></asp:Label><br />
            <br /><hr /><br />
        </div>
        <asp:Calendar ID="cldInfo" runat="server"></asp:Calendar>
    </form>
</body>
</html>
