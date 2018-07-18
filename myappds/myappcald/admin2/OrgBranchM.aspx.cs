/////////////////////////////////////
//* @author: Brian
//* BM 2018
//* OrgBranchM.aspx.cs
/////////////////////////////////////// 
//

using myappcald.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myappcald.admin2
{
    public partial class OrgBranchM : System.Web.UI.Page
    {
        private int usscode;
        const int Logt = 313;
        const int Logts = 363;
        //string[] columns;
        //private ListView lstVorg;
        //private ListViewItem lsti;
        //private ListViewItemType lstT;
        //private ListViewDataItem lstD;
        private string txbV;

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            var t = DateTime.Now;

            //////////////////////////////////////////////////////////////////////////////////////////////////
            // var dinfd = "org";
            // var dinfo = "0";
            // var orgl = [mUser.uname, mUser.oname, mUser.bname, mUser.ptype, mUser.ucode, dinfd, dinfo];
            // $("#infoOrg").load("/admin2/OrgBranchM.aspx?orgav=" + orgl);
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                /////////////////admin2////////////////
                //
                var orgadml = Request["orgav"];
                var orl = orgadml.Length;
                Response.Write("<br> RL: " + orl + "<br>");
                Response.Write("<br> Request: " + orgadml + "<br>");
                var l2 = orgadml.Split(',');
                var uname = l2[0].Trim(cTrim);
                //Code:
                //@data/Myappdsb.exe
                ///////////////////////admin2//////////////////
            }
            catch ( Exception exc)
            {
                Response.Write("<br>Exc: " + exc.ToString());
                var mtoken2 = t.GetHashCode();
                Response.Write("<br><a href=../views/Login.aspx?info=" + mtoken2 + ">Login</a>");
            }
           //
        }

        private void ProcessOrg(string dinfd, string ucodep, string utype, string branchname, string orgname, string uname)
        {
            var t = DateTime.Now;
            if (dinfd == "org")
            {
                ////////////////////////////////////////
                Response.Write("<br> ORG: " + t.ToString());
                ////////////////////////////////////////////////
                //
				//Code:
                //@Myappdsb.exe
                ////////////////////////////////////////////
            }
            else if(dinfd == "branch")
            {
                ///////////////////////////////
                Response.Write("<br> Bra: " + t.ToString());
                ////////////////////////////////////////////
                //
				//Code:
                //@Myappdsb.exe
                //////////////////////////////////////////////////
            }
            else if(dinfd == "orgAdmn")
            {
                //////////////////////////////////
                Response.Write("<br> ORGADMN: " + t.ToString());
                /////////////////////////////////////////////////////
                btnVo.Visible = false;
                btnVb.Visible = false;
                //////////////////////////////////////////////////////////////
            }
            else if (dinfd == "branchAdmn")
            {
                ///////////////////////////////
                Response.Write("<br> BraAdmn: " + t.ToString());
                //////////////////////////////////////////////////////////////
                btnVo.Visible = false;
                btnVb.Visible = false;
                ////////////////////////////////////////////////////////////////////////
            }
            else if (dinfd == "custAdmn")
            {
                ///////////////////////////////
                Response.Write("<br> CustAdmn: " + t.ToString());
                ///////////////////////////////////////////////////////////
                //
                ////////////////////////////////////////////
                //
				//Code:
                //@Myappdsb.exe
                ////////////////////////////////////////////
                btnVo.Visible = false;
                btnVb.Visible = false;
                ///////////////////////////////////////////////////////////////////
            }
            else if (dinfd == "orgmss")
            {
                ///////////////////////////////
                Response.Write("<br> ORGMss: " + t.ToString());
                ///////////////////////////////////////////////////////
                //
				//Code:
                //@Myappdsb.exe
				//////////////////////////////////////////////////
                btnVo.Visible = false;
                btnVb.Visible = false;
                /////////////////////////////////////////////////////////////////////
            }
            else if (dinfd == "appAdmn")
            {
                ///////////////////////////////
                Response.Write("<br> AppAdmn: " + t.ToString());
                ///////////////////////////////////////////////////////
				//Code:
                //@Myappdsb.exe
				///////////////////////////////////////////////////////
                btnVo.Visible = false;
                btnVb.Visible = false;
                /////////////////////////////////////////////////////////////////////
            }
            else if (dinfd == "appV")
            {
                ///////////////////////////////
                Response.Write("<br> AppV: " + t.ToString());
                ///////////////////////////////////////////////////////////////////
				//Code:
                //@Myappdsb.exe
				///////////////////////////////////////////////////////////////////
                btnVo.Visible = false;
                btnVb.Visible = false;
                //////////////////////////////////////////////////////////////////////
            }
            else
            {
                Response.Write("<br> T: " + t.ToString());
                btnVo.Visible = false;
                btnVb.Visible = false;
            }
            ///////////////////////////////////////////////////////////////////////////
        }
    }
}