/////////////////////////////////////
//* @author: Brian
//* BM 2018
//* Myappds.js
/////////////////////////////////////// 
//
//alert("Connecting...");
var nam2 = "Cool2";
var info = "201";
var mes2;
var mes3;
var nam3;
var orgp = "0";
var orgpc = "0";
var branchp = "0";
var branchpc = "0";
var messp;
var messq = "0";
var btnm;
var output;
var btnorg;
var btnbr;
var namep = "0";
var codep;
var typep;
//
var tginfo = 0;
var tgtodo = 0;
var tgdate;
var messagen = 0;
var xWdt;
var yHgt;
var dDay;
var xname = [];
var xmessage = [];
var ymessage;
var emess = [];
var ecountp = 0;
//
var myOrg = {
    oname: "orgName",
    oadmn: "OrgAdmin"
};
//alert(myOrg.oname);
var myBra = {
    bname: "braName",
    oname: "OrgN",
    badmn: "BraAdmin"
};
//alert(myBra.bname);
var mCust = {
    cname: "cName",
    oname: "oName",
    bname: "bName"
};
//alert(mCust.cname);
var mGuest = {
    gname: "gName",
    oname: "oName",
    bname: "bName"
};
//alert(mGuest.gname);
var mUser = {
    uname: "uName",
    oname: "oName",
    bname: "bName",
    ptype: "Ptype",
    ucode: "uCode"
};
//alert(mUser.uname);
var myMess = {
    oname: "oName",
    bname: "bName",
    uname: "uName",
    mess: "mMess"
};
//alert(myMess.mess);
//var xMess = myMess;
//alert(xMess);
//alert(xMess.mess);
//xMess = nam2;
//alert(xMess.mess);
//alert(xMess);
//xMess = myMess;
//alert(xMess.oname);
//
$(function () {
    var appd = $.connection.apdisyHub;
    appd.client.broadcastMessage = function (pname, gmessage) {
        messagen += 1;
        tgdate = new Date();
        //
        $('#inMessage').append('<tr><td>' + '<a href="#lblIn2"><input type="button" id="btnInbox" value="# ' + messagen + ' #" onclick="showMessage(' + messagen + ');" /></a>' + '</td><td id="inb"' + messagen + '>' + gmessage + '</td><td id="inbn"' + messagen + '>' + pname + '</td><td>' + tgdate + '</td></tr>');
        xname.push(pname);
        xmessage.push(gmessage);
        //$('#lblIn1').focus();
        //$('#lblInbox1').focus();
        $('#lblInbox1').text(messagen);
        $('#lblInbox0').text(messagen);
        $('#lblInbox0').show('slow');
        $('#lblInbox1').show('slow');
        //$('#lblInbox2').hide('slow');
        $('#lblIn0').show('slow');
        $('#lblIn1').show('slow');
        $('#lblIn2').hide('slow');
        //
        //xMess = gmessage;
        //alert(xMess.oname);
        //alert(xMess);
        /////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////
    };
    //$('#txtMessage').focus();
    //$('#lblInbox1').focus();
    $('#btnAdmin').focus();
    $.connection.hub.start().done(function () {
        //
        if (namep === "0")
        {
            //alert("@hub..." + namep);
            info = "302";
            init();
            //alert("@hub..." + namep);
        }
        if (info === "201")
        {
            info = "301";
            init();
            //alert("@hub..." + info);
        }
        appd.server.send(namep, "New member.");
        $('#btnMessage').click(function () {
            mes2 = $('#txtMessage').val();
            var mes22 = mes2.trim();
            appd.server.send(namep, mes22);
            if (messq === "0")
            {
                messq = "msq...ok";
            }
            else
            {
                //$('#txtMessage').val('').focus();
                $('#txtMessage').val('');
                //$('#btnAdmin').focus();
                //alert(messq);
                messq = "0";
            }
            if (mes2 === "")
            {
                alert("Mess:......... ? " + mes2);
            }
            //
            //var vorgp = $('#txtOrg').val();
            //var vbranchp = $('#txtBran').val();
            //
            //myMess.oname = "" + vorgp.trim() + "";
            //myMess.bname = "" + vbranchp.trim() + "";
            //myMess.uname = "" + namep.trim() + "";
            //myMess.mess = "" + mes2.trim() + "";
            //alert(myMess.oname);
            //alert(myMess.bname);
            //alert(myMess.uname);
            //alert(myMess.mess);
            //appd.server.send(namep, myMess);
            /////////////////////////////////////////////////////////////
            //
            //
            //
            /////////////////////////////////////////////////////////////
        });
        $('#btnOrg').click(function () {
            if (orgp === "")
            {
                alert("ORG:  ? " + orgp);
            }
            else
            {
                appd.server.send(namep, "New OrgAdmin..." + orgp + " : " + orgpc);
            }
            
        });
        $('#btnBran').click(function () {
            var brh = 0;
            if (orgp === "")
            {
                brh += 1;
                alert("ORG: ? " + orgp);
            }
            if (branchp === "")
            {
                brh += 1;
                alert("BRA: ? " + branchp);
            }
            if (brh === 0)
            {
                appd.server.send(namep, "New BranchAdmin.." + orgp + " : " + branchp + " : " + branchpc);
            }
            
        });
        $('#btnJOrg').click(function () {
            if (orgp === "")
            {
                alert("JORG:.. ? " + orgp);
            }
            else
            {
                if (typep === "User")
                {
                    ecountp++;
                }
                else if (typep === "Customer")
                {
                    ecountp++;
                }
                if (typep === "Guest")
                {
                    ecountp++;
                }
                appd.server.send(namep, "New OrgUser/Customer/G..." + orgp);
            }
            //alert(ecountp);
        });
        $('#btnJBran').click(function () {
            //alert("JBRA:" + branchp);
            if (branchp === "")
            {
                alert("JBranch: ? " + branchp);
            }
            else
            {
                if (typep === "User")
                {
                    ecountp++;
                }
                else if (typep === "Customer")
                {
                    ecountp++;
                }
                if (typep === "Guest")
                {
                    ecountp++;
                }
                appd.server.send(namep, "New BranchUser/Customer/G.." + branchp);
            }
            //alert(ecountp);
        });

        $('#btnHelp').click(function () {
            //alert("HELP");
            appd.server.send(namep, "Help...");
        });
        $('#btnInfo').click(function () {
            //alert("INF" + ttinfo);
            appd.server.send(namep, "Info...");
        });
        $('#btnExit').click(function () {
            //alert("EXIT");
            appd.server.send(namep, "Exit...");
        });
        $('#btnAdmin').click(function () {
            //alert("EXIT");
            appd.server.send(namep, "Admin...");
        });

    });
});
//
//
//
var aUrl;
var urlList = [];
var urlList2 = [];
var urlLL;
var urlLL2;
//var bDomain = document.domain;
//var cLinks = document.links;
//var dLocation = document.location;
//
//alert("aUrl: " + "aUrl?");
//alert("bDom: " + bDomain);
//alert("cLinks: " + cLinks.length);
//alert("dLoc: " + dLocation);
////////////////////////////////////////////////////////////////////////////////////////////////////
//aUrl: http://localhost:49368/views/myappds.html?code=CODE,name=NAME,type=TYPE,org=ORG,bran=BRAN
//http://localhost:49368/views/myappdsb.html?code=Code,name=Name,type=Type,org=oName,bran=bName,dinfo=
////////////////////////////////////////////////////////////////////////////////////////////////////
var urlList3;
var urlList4;
var urlList5;
var urlList6;
var urlList7;
//var urlListL = 5;
var urlListL = 6;
var urlListA;
//
function init() {
    aUrl = document.URL;
    tgdate = Date.now();
    //alert(tgdate);
    //alert("aUrl: " + aUrl);
    urlList = aUrl.split("?");
    urlList2 = urlList[1].split(",");
    urlLL2 = urlList2.length;
    //alert("uL2: " + urlLL2);
    if (urlLL2 === urlListL)
    {
        urlList3 = urlList2[0].split("=");
        urlList4 = urlList2[1].split("=");
        urlList5 = urlList2[2].split("=");
        urlList6 = urlList2[3].split("=");
        urlList7 = urlList2[4].split("=");
        //alert("ul2");
    }
    
    urlLL = urlList3.length;
    //alert("uL: " + urlLL);
    if (urlLL > 1)
    {
        codep = urlList3[1];
        //alert(codep);
        document.frmH.txtCode.value = codep;
        namep = urlList4[1];
        document.frmH.txtName.value = namep;
        typep = urlList5[1];
        document.frmH.txtType.value = typep;
        mUser.uname = namep;
        mUser.ptype = typep;
        mUser.ucode = codep;
        //alert(mUser.uname);
        //alert(mUser.ucode);
        //alert(mUser.ptype);
    }
    var urlL6 = urlList6.length;
    //alert("uL6: " + urlL6);
    if (urlL6 > 1)
    {
        orgp = urlList6[1];
        //alert(orgp);
        document.frmH.txtOrg.value = orgp;
        myOrg.oname = orgp;
        //alert(myOrg.oname);
    }

    var urlL7 = urlList7.length;
    //alert("uL7: " + urlL7);
    if (urlL7 > 1)
    {
        branchp = urlList7[1];
        //alert(branchp);
        document.frmH.txtBran.value = branchp;
        myBra.bname = branchp;
        //alert(myBra.bname);
    }
    //alert("init..");
    SettCookie();
    $('#lblIn2').hide('slow');
    $('#lblIn1').hide('slow');
    $('#lblIn0').hide('slow');
    if (typep !== "User")
    {
        $('#btnOrg').hide('slow');
        $('#btnBran').hide('slow');
        $('#btnCAdm').hide('slow');
    }
    if (typep === "Guest")
    {
        $('#btnMessage').hide('slow');
        mGuest.gname = namep;
        //alert(mGuest.gname);
    }
    if (typep === "Customer")
    {
        mCust.cname = namep;
        //alert(mCust.cname);
    }
}
//
//
//
function showMessage(vmessage)
{
    //alert(vmessage);
    //alert($('#inbn' + vmessage + '').val());
    //alert($('#inb' + vmessage + '').val());
    $('#inMessage2').append('<li style="background-color:silver">' + " # " + vmessage + " " + xname[vmessage - 1] + " : " + xmessage[vmessage - 1] + '</li>');
    //$('#lblIn2').focus();
    //$('#lblInbox2').focus();
    $('#lblInbox2').text(vmessage);
    $('#lblInbox0').hide('slow');
    $('#lblInbox1').hide('slow');
    $('#lblInbox2').show('slow');
    $('#lblIn0').hide('slow');
    $('#lblIn1').hide('slow');
    $('#lblIn2').show('slow');
}
//
//
//
function ToIndex()
{
    urlListA = urlList[0].split("/views");
    //alert(urlListA[0]);
    window.location = urlListA[0] + "/Index.aspx";
    //window.location = "http://localhost:49368/Index.aspx";
}
//
///////////////////////////////////////////////////////////////////
function ToMyappdsb() {
    urlListA = urlList[0].split("/views");
    //alert(urlListA[0]);
    window.location = urlListA[0] + "/views/myappdsb.html?code=" + mUser.ucode + ",name=" + mUser.uname + ",type=" + mUser.ptype + ",org=" + mUser.oname + ",bran=" + mUser.bname + ",dinfo=";
    //window.location = "http://localhost:49368/Index.aspx";
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //aUrl: http://localhost:49368/views/myappds.html?code=CODE,name=NAME,type=TYPE,org=ORG,bran=BRAN
    //http://localhost:49368/views/myappdsb.html?code=Code,name=Name,type=Type,org=oName,bran=bName,dinfo=
    ////////////////////////////////////////////////////////////////////////////////////////////////////
}
//
//
//
$(document).ready(function () {
    //alert("DocReady...1#: " + namep);
    if (namep === "0")
    {
        info = "402";
        init();
    }
    //alert("DocReady...2#: " + namep);
    
    $('#btnOrg').click(function () {
        var orgerr = 0;
        orgp = $('#txtOrg').val();
        if (orgp === "")
        {
            orgerr += 1;
        }
        if (orgpc === "0")
        {
            //orgerr += 2;
            alert("ORG2..." + orgp + " : " + orgpc);
            $('#txtOrg').focus();
        }
        if (orgerr === 0)
        {
            //$("#infoOrg").load('/admin/OrgAdmin.aspx', {"usrname":namep, "usrcode":codep, "usrtype":typep, "usrl":"orgadmin", "orgp":orgp, "orgpc":orgpc });
            //
            var orgadm = "orgadm";
            var orgname = orgp.trim();
            var orgl = [namep, codep, typep, orgadm, orgname, orgpc];
            //$("#infoOrg").load("/admin/OrgAdmin.aspx?usrname=" + namep + ",usrcode=" + codep + ",orgadm=" + orgadm + ",orgname=" + orgp + ",orgccode=" + orgpc);
            $("#infoOrg").load("/admin/OrgAdmin.aspx?orgad=" + orgl);
        }
        
    });
    $('#selOrgC').click(function () {
        orgpc = $('#selOrgC').val();
        document.getElementById("lblIn0").style.backgroundColor = orgpc;
    });
    $('#btnBran').click(function () {
        branchp = $('#txtBran').val();
        orgp = $('#txtOrg').val();
        var brerr = 0;
        if (branchpc === "0")
        {
            //brerr += 1;
            alert("BRA2..." + branchp + " : " + branchpc);
            $('#txtBran').focus();
        }
        if (branchp === "")
        {
            brerr += 2;
            alert("BRA2...?" + branchp);
            $('#txtBran').focus();
        }
        if (orgp === "")
        {
            brerr += 3;
        }
        if (brerr === 0)
        {
            //
            var branchadm = "branchadm";
            var orgname = orgp.trim();
            var branchname = branchp.trim();
            var branchl = [namep, codep, typep, branchadm, branchname, branchpc , orgname, orgpc];
            //$("#infoOrg").load("/admin/OrgAdmin.aspx?usrname=" + namep + ",usrcode=" + codep + ",orgadm=" + orgadm + ",orgname=" + orgp + ",orgccode=" + orgpc);
            $("#infoBranch").load("/admin/BranchAdmin.aspx?branchad=" + branchl);
        }
    });
    $('#selBranchC').click(function () {
        branchpc = $('#selBranchC').val();
        document.getElementById("lblInbox0").style.backgroundColor = branchpc;
    });
    //
    $('#btnJOrg').click(function () {
        orgp = $('#txtOrg').val();
        ymessage = $('#txtMessage').val();
        if (orgp === "")
        {
            alert("JORG: ? " + orgp);
        }
        else
        {
            //if (typep === "User") {}
            //else if (typep === "Customer") {}
            //if (typep === "Guest") {}
            var orgname = orgp.trim();
            var branchname = branchp.trim();
            var ymess = ymessage.trim();
            var jorgl = [orgname, branchname, namep, codep, typep, ymess];
            $("#infoOrg").load("/admin/UserOrg.aspx?jorgad=" + jorgl);

        }

    });
    //
    $('#btnJBran').click(function () {
        //alert("JBRA:" + branchp);
        //
        branchp = $('#txtBran').val();
        orgp = $('#txtOrg').val();
        ymessage = $('#txtMessage').val();
        if ((orgp === "") | (branchp === "")) {
            alert("JORG: ? " + orgp + " : " + branchp);
        }
        else {
            //if (typep === "User") {}
            //else if (typep === "Customer") {}
            //if (typep === "Guest") {}
            var orgname = orgp.trim();
            var branchname = branchp.trim();
            var ymess = ymessage.trim();
            var jorgl = [orgname, branchname, namep, codep, typep, ymess];
            $("#infoOrg").load("/admin/BranchUserAdm.aspx?jorgad=" + jorgl);

        }

        //
        if (branchp === "") {
            alert("JBranch: ? " + branchp);
        }
        else {
            if (typep === "User")
            {
                ecountp++;
            }
            else if (typep === "Customer")
            {
                ecountp++;
            }
            if (typep === "Guest")
            {
                ecountp++;
            }
            //
        }
    });
    //
    $('#btnMessage').click(function () {
        orgp = $('#txtOrg').val();
        branchp = $('#txtBran').val();
        ymessage = $('#txtMessage').val();
        $('#lblIn2').show('slow');
        var msq = "0";
        if (orgp === "")
        {
            alert("ORG:  ? " + orgp);
        }
        else
        {
            var orgname = orgp.trim();
            var branchname = branchp.trim();
            var ymess = ymessage.trim();
            var dinfo = "0";
            //var messl = [orgname, branchname, namep, codep, typep, ymess, dinfo];
            //$("#infoMess").load("/admin/MessageAdmin.aspx?messad=" + messl);
            msq = "2";
            if (ymess === "")
            {
                alert("Mess: ? " + ymess);
                $('#txtMessage').focus();
            }
            else
            {
                ToMyappdsb();
            }
        }
        if (messq === "0")
        {
            if (msq === "2")
            {
                messq = "msq...done";
            }
        }
        else
        {
            //alert(messq);
            messq = "0";
            $('#txtMessage').val('');
        }
        //return false;
    });

    $('#btnHelp').click(function () {
        //alert("HELP2...");
        if (tgtodo === 0) {
            //$("todo").focus();
            $("#todo").hide(1000);
            tgtodo = 1;
        }
        else {
            $("#todo").show('slow');
            tgtodo = 0;
            //$("todo").focus();
        }
    });
    $('#btnInfo').click(function () {
        //alert("INFO2...");
        if (tginfo === 0) {
            //$(".dilst").focus();
            $(".dlist").hide(1000);
            tginfo = 1;
        }
        else {
            $(".dlist").show('slow');
            tginfo = 0;
            //$(".dilst").focus();
        }

    });
    $('#btnExit').click(function () {
        //alert("Exit2...");
        ToIndex();
    });
    $('#btnCAdm').click(function () {
        ToMyappdsb();
        ///////////////////////////////////////////
        //branchp = $('#txtBran').val();
        //orgp = $('#txtOrg').val();
        //ymessage = $('#txtMessage').val();
        //var orgname = orgp.trim();
        //var branchname = branchp.trim();
        //var ymess = ymessage.trim();
        //var corgl = [orgname, branchname, namep, codep, typep, ymess];
        //$("#infoAdm2").load("/admin/CustomerAdmin.aspx?corgad=" + corgl);
        ///////////////////////////////////////////////////////////////////
    });
    $('#btnAdmin').click(function () {
        //ymessage = $('#txtMessage').val();
        $('#txtOrg').focus();
        return false;
    });
    //
    //////////////////////////////////////////////////////////////
    $('#btnApp2').click(function () {
        //alert("App2...");
        ToMyappdsb();
    });
    $('#btnOrg2').click(function () {
        //alert("Org2...");
        ToMyappdsb();
    });
    $('#btnBra2').click(function () {
        //alert("Bra2...");
        ToMyappdsb();
    });
    $(".bApp").click(function () {
        //alert("App...");
        ToMyappdsb();
    });
});
//
//
//
function SettCookie()
{
    //alert(namep);
    if (namep === "")
    {
        //alert("Name: ? " + namep);
        ToIndex();
        //window.location = "http://localhost:49368/Index.aspx";
    }
    else if (namep === "0")
    {
        //alert("Name: ? " + namep);
        ToIndex();
    }
    Screendp();
    var datec = new Date();
    var ddate = datec.getDate();
    var dhr = datec.getHours();
    var dmin = datec.getMinutes();
    var dsec = datec.getSeconds();
    var dyer = datec.getFullYear();
    dDay = datec.getDay();
    //alert(dDay + " : " + ddate + " : " + dhr + " : " + dmin + " : " + dsec + " : " + datec);
    var info1 = xWdt * codep * dsec;
    var info2 = codep * codep * dsec;
    var info3 = yHgt * codep * dmin;
    var infop = info1 + "p" + info2 + "p" + info3 + "p" + datec;
    var cookiei = escape(infop) + ";";
    document.cookie = "pinfo=" + cookiei;
    $(".log").text("" + dyer + "");
}
//
//
//
function Screendp()
{
    xWdt = window.screen.width;
    yHgt = window.screen.height;
    //alert(xWdt + " : " + yHgt);
    //alert(namep);
    //alert(info);
}
//
//
//
window.onload = function ()
{
    Screendp();
    //alert("Done2...");
    //alert("info:  " + info);
    if (info === "201")
    {
        info = "401";
        init();
        //alert("@win.onl..." + info);
    }
    //alert("Done3...");
    //alert("1namep: " + namep);
    if (namep === "0")
    {
        ToIndex();
        //window.location="http://localhost:49368/Index.aspx";
        //setTimeout('ToIndex()', 10000);
        //alert("0codep: " + codep);
        init();
        //alert("1Codep:  " + codep)
        if (codep === "")
        {
            //alert("2Codep:  " + codep);
            ToIndex();
            //window.location="http://localhost:49368/Index.aspx";
        }
    }
};
//
//
//
window.onerror = function (msg, url, ln) {
    //alert("WMess: " + msg);
    //alert("Url: " + url);
    //alert("L#: " + ln);
    emess.push(msg);
    emess.push(url);
    emess.push(ln);
};
//
//alert("2018Done1");
//