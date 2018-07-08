using myappcald.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myappcald.admin
{
    public partial class OrgAdmin : System.Web.UI.Page
    {
        //private string ussname;
        private int usscode;
        //private string usstype;
        //private string ussrl;
        //private string oorgp;
        //private string oorgpc;
        //long pticks, ptt;

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            var t = DateTime.Now;
            /////////////////////////////////////////////////////////////////////////////////
            //var orgadm = "orgadm";
            //var orgname = orgp.trim();
            //var orgl = [namep, codep, typep, orgadm, orgname, orgpc];
            //$("#infoOrg").load("/admin/OrgAdmin.aspx?orgad=" + orgl);
            /////////////////////////////////////////////////////////////////////////////////
            //
            Response.Write("<br> T: " + t + "<br>");
            try
            {
                var orgadml = Request["orgad"];
                var orl = orgadml.Length;
                Response.Write("<br> UNL: " + orl + "<br>");
                Response.Write("<br> UName: " + orgadml + "<br>");
                var l2 = orgadml.Split(',');
                var uname = l2[0];
                var ucodep = l2[1];
                var utype = l2[2];
                var orgadm = l2[3];
                var orgname = l2[4];
                var orgpc = l2[5];
                //
                Response.Write("<br> UName: " + uname + "<br>");
                Response.Write("<br> UCode: " + ucodep + "<br>");
                Response.Write("<br> UType: " + utype + "<br>");
                Response.Write("<br> OrgAdm: " + orgadm + "<br>");
                Response.Write("<br> Org: " + orgname + "<br>");
                Response.Write("<br> Orgc: " + orgpc + "<br>");
                usscode = Int32.Parse(ucodep);
                //
                //AppdsOrganisation(int orcode, string orname, int opcode, string opname, string opinfo, string optype, int orbranch, string ornotes)
                AppdsOrganisation orgpn = new AppdsOrganisation( 0, orgname, usscode, uname, t.ToString(), utype, 0, orgadm);
            }
            catch (Exception ex)
            {
                Response.Write("<br> Ex: " + ex.ToString() + "<br>");
            }
            
        }
    }
}