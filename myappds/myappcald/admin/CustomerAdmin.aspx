<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAdmin.aspx.cs" Inherits="myappcald.admin.CustomerAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <h3>Customer Admin.</h3>
    <div><hr /></div>
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell><label>Code:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrCode" maxlength="30" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label>Name:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrName" maxlength="30" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label>Surname:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrSurname" maxlength="30" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label>Email:</label></asp:TableCell>
            <asp:TableCell><input type="email" id="usrEmail" maxlength="50" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label>Organisation:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrOrg" maxlength="50" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label>Branch:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrBra" maxlength="50" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow>
            <asp:TableCell><label>Disabled:</label></asp:TableCell>
            <asp:TableCell><select id="usrDis" runat="server"><option value="f">False</option><option value="t">True</option></select></asp:TableCell>
        </asp:TableFooterRow>
        <asp:TableRow>
            <asp:TableCell><label>Notes:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrNotes" maxlength="250" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><input type="button" id="btnUsrList" value="List" runat="server" /></asp:TableCell>
            <asp:TableCell><input type="button" id="btnUsrUpadete" value="Update" runat="server" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div id="usrDiv">
        <hr />
    </div>
</body>
</html>
