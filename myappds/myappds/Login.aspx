<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="myappds.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <h2>AppDiarySystem</h2>
    <form id="frmLog" runat="server">
        <div>
            <label>Info:</label>
            <asp:TextBox ID="txbInfo" Text="" MaxLength="30" ReadOnly="true" runat="server"></asp:TextBox>
            <br />
            <label>User Name:</label>
            <input type="email" id="usrEmail" required="required" maxlength="30" runat="server" /><br />
            <label>Password:</label>
            <input type="password" id="usrPasswd" required="required" minlength="2" maxlength="10" runat="server" /><br />
            <asp:Button ID="BtnLogin" Text="Login" runat="server" /><br />
            <asp:Label ID="lblFed" Text="" runat="server" ></asp:Label><br />
            <hr /><br />
        </div>
        <asp:Calendar ID="calInfo" SelectedDate="" runat="server"></asp:Calendar>
        <div>
            <asp:PlaceHolder ID="placeHolder" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
