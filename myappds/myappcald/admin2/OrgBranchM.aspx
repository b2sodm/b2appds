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
    <input type="text" id="txbInfo" readonly="true" runat="server" /><br />
    <script type="text/javascript" lang="javascript">
        var subm2 = document.getElementById("txbInfo");
        var btnAdV3 = document.createElement("button");
        var btnId3 = $("#txbInfo").val();
        btnAdV3.textContent = "OK_" + btnId3;
        btnAdV3.id = "" + btnId3;
        subm2.parentNode.appendChild(btnAdV3);
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
                    //$("#txtBran").focus();
                    $("#txtVo").val("");
                    Resetv();
                }
                else {
                    //alert(txt);
                    $("#txtVo").val("");
                }
            });
            //
            ////////ms3////////
            //
            $("#" + btnId3).click(function () {
                //alert("To Admin3...");
                Resetv();
            });
            
            //////////////////////////////////////////////////
        });
        //
        //alert("OK!");
        function Resetv() {
            $("#txtVo").val("");
            $("#btnAppCal").focus();
            $("#infoOrg").hide("slow");
            $("#infoBranch").hide("slow");
            $("#infoMess").hide("slow");
            $("#infoOrgAdmn").hide("slow");
            $("#infoBraAdmn").hide("slow");
            $("#infoCustomer").hide("slow");
            $("#infoApp").hide("slow");
            $("#infoAppAdmn").hide("slow");
            $("#infoUser").hide("slow");
            $("#info101").hide("slow");
            //
        }
        //
    </script>
    </body>
</html>
