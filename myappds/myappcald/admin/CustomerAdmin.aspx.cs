using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myappcald.admin
{
    public partial class CustomerAdmin : System.Web.UI.Page
    {
        private int usscode;

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            var t = DateTime.Now;
            Response.Write("<br> T: " + t + "<br>");
            /////////////////////////////////////////////////////////////////////////////////////
            //
            //branchp = $('#txtBran').val();
            //orgp = $('#txtOrg').val();
            //ymessage = $('#txtMessage').val();
            //var orgname = orgp.trim();
            //var branchname = branchp.trim();
            //var ymess = ymessage.trim();
            //var corgl = [orgname, branchname, namep, codep, typep, ymess];
            //$("#infoAdm2").load("/admin/CustomerAdmin.aspx?corgad=" + corgl);
            ////////////////////////////////////////////////////////////////////////////////////////
            //
            try
            {
                var orgadml = Request["corgad"];
                var orl = orgadml.Length;
                Response.Write("<br> UNL: " + orl + "<br>");
                Response.Write("<br> UName: " + orgadml + "<br>");
                var l2 = orgadml.Split(',');
                var orgname = l2[0];
                var branchname = l2[1];
                var namep = l2[2];
                var codep = l2[3];
                var typep = l2[4];
                var ymess = l2[5];
                //
                Response.Write("<br> Organisation: " + orgname + "<br>");
                Response.Write("<br> Branch: " + branchname + "<br>");
                Response.Write("<br> UType: " + typep + "<br>");
                Response.Write("<br> Code: " + codep + "<br>");
                Response.Write("<br> Mess: " + ymess + "<br>");
                usscode = Int32.Parse(codep);
                //
                //AppdsOrganisation(int orcode, string orname, int opcode, string opname, string opinfo, string optype, int orbranch, string ornotes);
                //AppdsBranch(string branchname, string orgname, int usscode, string uname, string v, string utype)
                //AppdsBranch orgpn = new AppdsBranch(branchname, orgname, usscode, uname, t.ToString(), utype);
            }
            catch (Exception ex)
            {
                Response.Write("<br> Ex: " + ex.ToString() + "<br>");
            }


            //
            //

        }
    }
}