using myappcald.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myappcald.admin
{
    public partial class UserOrg : System.Web.UI.Page
    {
        private int usscode;

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            var t = DateTime.Now;
            //
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //var branchadm = "branchadm";
            //var orgname = orgp.trim();
            //var branchname = branchp.trim();
            //var branchl = [namep, codep, typep, branchadm, branchname, branchpc, orgname, orgpc];
            //$("#infoOrg").load("/admin/OrgAdmin.aspx?usrname=" + namep + ",usrcode=" + codep + ",orgadm=" + orgadm + ",orgname=" + orgp + ",orgccode=" + orgpc);
            //$("#infoBranch").load("/admin/BranchAdmin.aspx?branchad=" + branchl);
            //AppdsBranch(int pbracode, string pbraname, int porgcode, string porgname, int ppcode, string ppname, string pinfo, string pptype, int ppuser, string pnotes);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //
            //var orgname = orgp.trim();
            //var branchname = branchp.trim();
            //var ymess = ymessage.trim();
            //var jorgl = [orgname, branchname, namep, codep, typep, ymess];
            //$("#infoOrg").load("/admin/UserOrg.aspx?jorgad=" + jorgl);
            //
            ////////////////////////////////////////////////////////////////////////////////////////
            Response.Write("<br> T: " + t + "<br>");
            try
            {
                var jorgadml = Request["jorgad"];
                var orl = jorgadml.Length;
                Response.Write("<br> UNL: " + orl + "<br>");
                Response.Write("<br> UName: " + jorgadml + "<br>");
                var l2 = jorgadml.Split(',');
                var orgname = l2[0];
                var branchname = l2[1];
                var unamep = l2[2];
                var ucodep = l2[3];
                var utypep = l2[4];
                var ymess = l2[5];
                //
                Response.Write("<br> OrgName: " + orgname + "<br>");
                Response.Write("<br> BranchName: " + branchname + "<br>");
                Response.Write("<br> UName: " + unamep + "<br>");
                Response.Write("<br> UCode: " + ucodep + "<br>");
                Response.Write("<br> UType: " + utypep + "<br>");
                Response.Write("<br> Mess: " + ymess + "<br>");
                //
                usscode = Int32.Parse(ucodep);
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //AppdsUserOrg(string orgname, string branchname, string unamep, int ucodep, string utypep, string ymess, string info)
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                AppdsUserOrg orgu = new AppdsUserOrg(orgname, branchname, unamep, usscode, utypep, ymess, t.ToString());
                var orgl = orgu.InfOrgL();
                var orgl2 = orgu.InfOrgL(orgname);
                var orgl3 = orgu.FindUser(orgname);
                Response.Write(orgname + " : "+ orgl3 +"<br>");
                var i = 0;
                foreach(var n in orgl)
                {
                    Response.Write(i +" resl: " + n +"<br>");
                    i++;
                }

                var j = 0;
                foreach (var l in orgl2)
                {
                    Response.Write(j + " res: " + l + "<br>");
                    j++;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<br> Ex: " + ex.ToString() + "<br>");
            }


            //
        }
    }
}