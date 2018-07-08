using myappcald.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myappcald.admin
{
    public partial class BranchAdmin : System.Web.UI.Page
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
            Response.Write("<br> T: " + t + "<br>");
            try
            {
                var branchadml = Request["branchad"];
                var orl = branchadml.Length;
                Response.Write("<br> UNL: " + orl + "<br>");
                Response.Write("<br> UName: " + branchadml + "<br>");
                var l2 = branchadml.Split(',');
                var uname = l2[0];
                var ucodep = l2[1];
                var utype = l2[2];
                var branchadm = l2[3];
                var branchname = l2[4];
                var branchpc = l2[5];
                var orgname = l2[6];
                var orgpc = l2[7];
                //
                Response.Write("<br> UName: " + uname + "<br>");
                Response.Write("<br> UCode: " + ucodep + "<br>");
                Response.Write("<br> UType: " + utype + "<br>");
                Response.Write("<br> BranchAdm: " + branchadm + "<br>");
                Response.Write("<br> BranchName: " + branchname + "<br>");
                Response.Write("<br> Branchpc: " + branchpc + "<br>");
                Response.Write("<br> OrgName: " + orgname + "<br>");
                Response.Write("<br> Orgc: " + orgpc + "<br>");
                usscode = Int32.Parse(ucodep);
                //
                //AppdsOrganisation(int orcode, string orname, int opcode, string opname, string opinfo, string optype, int orbranch, string ornotes);
                //AppdsBranch(string branchname, string orgname, int usscode, string uname, string v, string utype)
                AppdsBranch orgpn = new AppdsBranch(branchname, orgname, usscode, uname, t.ToString(), utype);
            }
            catch (Exception ex)
            {
                Response.Write("<br> Ex: " + ex.ToString() + "<br>");
            }


            //
        }
    }
}