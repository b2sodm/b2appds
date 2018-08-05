<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OrgBraCal.aspx.vb" Inherits="myappds.OrgBraCal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <a href="../Index.aspx">Log out</a>
    <hr />
    <h1>AppDS</h1>
    <h3>OrgBraCal</h3>
    <label id="lblDate" runat="server"></label><br />
    <form id="frmOrgCal" runat="server">
        <div>
            <br />
            <label>Date</label>
            <asp:TextBox ID="txbDate" ReadOnly="true" runat="server"></asp:TextBox>
            <br />
            <label>Time</label>
            <asp:DropDownList ID="DdlH" ReadOnly="true" runat="server">
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                <asp:ListItem Text="12" Value="12"></asp:ListItem>
            </asp:DropDownList>
             <asp:DropDownList ID="DdlM" ReadOnly="true" runat="server">
                <asp:ListItem Text=":00" Value=":00"></asp:ListItem>
                <asp:ListItem Text=":15" Value=":15"></asp:ListItem>
                <asp:ListItem Text=":30" Value=":30"></asp:ListItem>
                <asp:ListItem Text=":45" Value=":45"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DdlAPM" ReadOnly="true" runat="server">
                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <label>Slot</label>
            <asp:DropDownList ID="DdlSl" ReadOnly="true" runat="server">
                <asp:ListItem Text="Slot1" Value="Slot1"></asp:ListItem>
                <asp:ListItem Text="Slot2" Value="Slot2"></asp:ListItem>
                <asp:ListItem Text="Slot3" Value="Slot3"></asp:ListItem>
                <asp:ListItem Text="Slot4" Value="Slot4"></asp:ListItem>
                <asp:ListItem Text="Slot5" Value="Slot5"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <label>Colour Code</label>
            <asp:DropDownList ID="DdlSc" ReadOnly="true" runat="server">
                <asp:ListItem Text="yellow" Value="yellow"></asp:ListItem>
                <asp:ListItem Text="red" Value="red"></asp:ListItem>
                <asp:ListItem Text="pink" Value="pink"></asp:ListItem>
                <asp:ListItem Text="green" Value="green"></asp:ListItem>
                <asp:ListItem Text="violet" Value="violet"></asp:ListItem>
                <asp:ListItem Text="orange" Value="orange"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <label>Description</label>
            <textarea id="txaDes" rows="3" runat="server"></textarea><br />
            <br />
            <asp:Calendar ID="calOrg" runat="server"></asp:Calendar>
            <br />
            <asp:Button ID="BtnCal" Text="OK" ForeColor="#ff0000" runat="server" />
            <br />
        </div>
    </form>
</body>
</html>
