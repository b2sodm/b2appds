<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgBranchM.aspx.cs" Inherits="myappcald.admin2.OrgBranchM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online App Diary System</title>
</head>
<body>
    <h3>OrgBranchM</h3>
    <label id="lblOBM" runat="server">ORG:</label><br />
    <textarea name="txtOg" id="txtOg" rows="4" placeholder="ORG" maxlength="250" readonly="readonly" runat="server"></textarea><br />
    <input type="text" id="txtVo" runat="server" /><br />
    <input type="button" id="btnVo" value="Select" runat="server" /><br />
    <input type="button" id="btnVb" value="Select" runat="server" /><br />
    <script type="text/javascript" lang="javascript">
        $(document).ready(function () {
            //alert("OrgReady");
            $('#btnVo').click(function () {
                var txt = $("#txtVo").val();
                var lst = $("#txtOg").val();
                //alert(lst);
                $.trim(txt);
                $.trim(lst);
                var lst2 = lst.split(",\n");
                
                if ($.inArray(txt,lst2) !== -1)
                {
                    $("#txtOrg").val(txt);
                    $("#txtOrg").focus();
                    $("#txtVo").val("");
                }
                else
                {
                    //alert(txt);
                    $("#txtVo").val("");
                }
            });
            //
            $('#btnVb').click(function () {
                var txt = $("#txtVo").val();
                var lst = $("#txtOg").val();
                //alert(lst);
                $.trim(txt);
                $.trim(lst);
                var lst2 = lst.split(",\n");

                if ($.inArray(txt, lst2) !== -1) {
                    $("#txtBran").val(txt);
                    $("#txtBran").focus();
                    $("#txtVo").val("");
                }
                else {
                    //alert(txt);
                    $("#txtVo").val("");
                }
            });
            //
        });
    </script>
    </body>
</html>
