using myappcald.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myappcald.admin
{
    public partial class BranchUserAdm : System.Web.UI.Page
    {
        private int usscode;

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            var t = DateTime.Now;
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //
            //var orgname = orgp.trim();
            //var branchname = branchp.trim();
            //var ymess = ymessage.trim();
            //var jorgl = [orgname, branchname, namep, codep, typep, ymess];
            //$("#infoOrg").load("/admin/BranchUserAdm.aspx?jorgad=" + jorgl);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
                //AppdsUserBranch(string porganame, string pbraname, string ppname, int ppcode, string pptype, string pinfo)
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                AppdsUserBranch orgu = new AppdsUserBranch(orgname, branchname, unamep, usscode, utypep, t.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<br> Ex: " + ex.ToString() + "<br>");
            }
            //
        }
    }
}