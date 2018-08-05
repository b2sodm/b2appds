<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAdmin.aspx.cs" Inherits="myappcald.admin.CustomerAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <h3>Customer Admin.</h3>
    <div><hr /></div>
    <form id="frmCad22" runat="server">
        <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell><label id="lblAd22" runat="server">Admin:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="adminCode" maxlength="30" readonly="true" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label id="lblCo22" runat="server">Code:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrCode" maxlength="30" required="required" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label id="lblNa22" runat="server">Name:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrName" maxlength="30" required="required" runat="server"  /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label id="lblSu22" runat="server">Surname:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrSurname" maxlength="30" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label id="lblEm22" runat="server">Email:</label></asp:TableCell>
            <asp:TableCell><input type="email" id="usrEmail" maxlength="50" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label id="lblOr22" runat="server">Organisation:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrOrg" maxlength="50" readonly="true" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><label id="lblBr22" runat="server">Branch:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrBra" maxlength="50" readonly="true" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow>
            <asp:TableCell><label id="lblDs22" runat="server">Disabled:</label></asp:TableCell>
            <asp:TableCell><select id="usrDis" runat="server"><option value="f">False</option><option value="t">True</option></select></asp:TableCell>
        </asp:TableFooterRow>
        <asp:TableRow>
            <asp:TableCell><label id="lblNt22" runat="server">Notes:</label></asp:TableCell>
            <asp:TableCell><input type="text" id="usrNotes" maxlength="250" runat="server" /></asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        <br /><hr />
        <asp:Button ID="BtnOk2" ForeColor="#cc3300" Text="OK" runat="server" OnClick="BtnOk223_Click" /><label id="lblOk2" runat="server">  </label>
        <asp:Button ID="BtnUp2" ForeColor="#6600cc" Text="Update" runat="server" /><label id="lblUp2" runat="server">  </label><br /><hr />
        <asp:Button ID="BtnDe2" ForeColor="#669999" Text="Delete" runat="server" /><label id="lblDe2" runat="server">  </label><br />
        <br />
        <asp:TextBox ID="txbInf2" BorderColor="#66ff66" ForeColor="#996600" BackColor="#cc99ff" ReadOnly="true" Rows="3" runat="server"></asp:TextBox><br />
        <br />
    </form>
    <div id="usrDiv">
        <hr />
    </div>
    <script type="text/javascript" lang="javascript">
        alert("CADmin");
        $(document).ready(function () {
            $('#BtnOk2').click(function () {
                //ymessage = $('#txtMessage').val();
                alert("OK...");
                $("#txbInf2").val("OK...");
                ResetCp();
                return false;
            });
            $('#BtnUp2').click(function () {
                //ymessage = $('#txtMessage').val();
                alert("Update...");
                $("#txbInf2").val("Done up...");
                ResetCp();
                return false;
            });
            $('#BtnDe2').click(function () {
                //ymessage = $('#txtMessage').val();
                alert("Delete...");
                $("#txbInf2").val("Done del...");
                ResetCp();
                return false;
            });
        });
        function ResetCp() {
            $("#usrCode").val("");
            $("#usrName").val("");
            $("#usrSurname").val("");
            $("#usrEmail").val("");
            alert("Done..");
        }
    </script>
</body>
</html>
