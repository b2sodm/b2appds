<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgBraCal.aspx.cs" Inherits="myappcald.admin3.OrgBraCal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <a href="../Index.aspx">Log out</a>
    <hr />
    <div id="divIfn0">
        <asp:Table CellSpacing="2" CellPadding="2" BorderWidth="1" runat="server">
            <asp:TableRow>
                <asp:TableCell><label id="lblOrg">Org</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbOrg" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label id="lblBra">Bra</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbBra" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label id="lblCode">Code</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbCode" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label id="lblName">Name</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbName" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label id="lblType">Type</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbType" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <input type="button" id="btnMore" value="More.." runat="server" /><br />
    <hr />
    <h1>AppDS</h1>
    <h3>OrgBraCal</h3>
    <label id="lblDate" runat="server"></label><br />
    <form id="frmOrgCal" runat="server">
        <div>
            <br />
            <asp:Table CellSpacing="2" CellPadding="2" BorderWidth="1" runat="server">
                <asp:TableRow>
                    <asp:TableCell><label>Date</label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txbDate" ReadOnly="true" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <label>Time</label>
                    </asp:TableCell>
                    <asp:TableCell>
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
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <label>SLT</label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="DdlSl" ReadOnly="true" runat="server">
                        <asp:ListItem Text="S1" Value="S1"></asp:ListItem>
                        <asp:ListItem Text="S2" Value="S2"></asp:ListItem>
                        <asp:ListItem Text="S3" Value="S3"></asp:ListItem>
                        <asp:ListItem Text="S4" Value="S4"></asp:ListItem>
                        <asp:ListItem Text="S5" Value="S5"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <label>Code</label>
                    </asp:TableCell>
                    <asp:TableCell>
                    <asp:DropDownList ID="DdlSc" ReadOnly="true" runat="server">
                        <asp:ListItem Text="yellow" Value="yellow"></asp:ListItem>
                        <asp:ListItem Text="red" Value="red"></asp:ListItem>
                        <asp:ListItem Text="pink" Value="pink"></asp:ListItem>
                        <asp:ListItem Text="green" Value="green"></asp:ListItem>
                        <asp:ListItem Text="violet" Value="violet"></asp:ListItem>
                        <asp:ListItem Text="orange" Value="orange"></asp:ListItem>
                    </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <label>Info</label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox id="txbInfo" TextMode="MultiLine" runat="server"></asp:TextBox><br />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Calendar ID="calOrg" runat="server" ToolTip="Click on the date." OnSelectionChanged="calOrg_SelectionChanged"></asp:Calendar>
            <br />
            <asp:Button ID="BtnCal" Text="OK" ForeColor="#ff0000" runat="server" OnClick="BtnCal_Click" />
            <asp:Button ID="Btnhelp" Text="Help" ForeColor="#0000cc" runat="server" OnClick="Btnhelp_Click" />
            <br />
            <asp:Label ID="LblH" BackColor="#3333cc" runat="server"></asp:Label>
            <br />
            <asp:Button ID="BtnViewC" Text="ViewC" BackColor="#0033cc" runat="server" OnClick="BtnViewC_Click" />
            <br />
        </div>
    </form>
    <hr />
    <div>
        <input type="button" id="btnView" value="View" runat="server" />
        <input type="button" id="btnExit" value="Exit" runat="server" />
    </div>
    <hr />
    <div id="dvCal1">
        INFO:1
        <br /><label id="lblInfo1" runat="server"></label><br />
    </div>
    <hr />
    <div id="dvCal2">
        INFO:2
        <br /><label id="lblInfo2" runat="server"></label><br />
    </div>
    <hr />
    <div id="dvCal3">
        INFO:3
        <br /><label id="lblInfo3" runat="server"></label><br />
        <input type="text" id="txbInfo3" readonly="true" style="background-color:aqua" runat="server" />
    </div>
    <hr />
    <br />
    <hr />
    <div id="divIfn1Admn">
        <asp:Table CellSpacing="2" CellPadding="2" BorderWidth="1" runat="server">
            <asp:TableRow>
                <asp:TableCell><label id="lblOrgA">Org</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbOrgA" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label id="lblBraA">Bra</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbBraA" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label id="lblCodeA">Code</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbCodeA" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label id="lblNameA">Name</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbNameA" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><label id="lblTypeA">Type</label></asp:TableCell>
                <asp:TableCell><input type="text" id="txbTypeA" readonly="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <input type="button" id="btnMoreA" value="More.." runat="server" /><br />
    <input type="button" id="btnSelA" value="Select User" runat="server" /><br />
    <input type="button" id="btnOkA" value="OK" runat="server" /><br />
    <hr />
    <br />
</body>
</html>
