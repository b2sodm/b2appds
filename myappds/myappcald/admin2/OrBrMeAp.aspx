﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrBrMeAp.aspx.cs" Inherits="myappcald.admin2.OrBrMeAp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <h3>OrBrMeAp</h3>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblOrBr" BackColor="#ffcc00" runat="server"></asp:Label>
            <asp:Calendar ID="calOrBr" BackColor="#ff00ff" runat="server"></asp:Calendar>
        </div>
    </form>
</body>
</html>
