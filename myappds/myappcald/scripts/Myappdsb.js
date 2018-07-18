/////////////////////////////////////
//* @author: Brian
//* BM 2018
//* Myappdsb.js
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
var version = 0;
//
//Code:
//@data/Myappdsb.exe
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
//alert("2018Done2");
//