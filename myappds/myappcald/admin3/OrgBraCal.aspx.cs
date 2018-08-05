/////////////////////////////////////
//* @author: Brian
//* BM 2018
//* OrgBraCal.aspx.cs
/////////////////////////////////////// 
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace myappcald.admin3
{
    public partial class OrgBraCal : System.Web.UI.Page
    {
        private string org;
        private string bra;
        private string code;
        private string uName;
        private string uType;
        private bool pval;
        private string vdate;
        private string vhour;
        private string vmin;
        private string vdm;
        private string vslo;
        private string vcol;
        private string vmes;

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            var t = DateTime.Now;
            lblDate.InnerText = t.ToString();
            calOrg.SelectedDate = t.Date;
            //txbDate.Text = calOrg.SelectedDate.ToString();
            //
            try
            {
                /////////////////admin2////////////////
                // urlListA = urlList[0].split("/views");
                //alert(urlListA[0]);
                //window.location = urlListA[0] + "/admin3/OrgBraCal.aspx?code=" + mUser.ucode + ",name=" + mUser.uname + ",type=" + mUser.ptype + ",org=" + mUser.oname + ",bran=" + mUser.bname + ",dinfo=";
                //var dinfd = "orgAdmnC";
                //var dinfo = "0";
                //mUser.oname = $("#txtOrg").val();
                //mUser.bname = $("#txtBran").val();
                //var orgl = [mUser.uname, mUser.oname, mUser.bname, mUser.ptype, mUser.ucode, dinfd, dinfo];
                //window.location = urlListA[0] + "/admin3/OrgBraCal.aspx?orgav=" + orgl;
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                ////////////////////////////////////////////////
                //
				//Code:
                //@Myappdsb.exe
                ////////////////////////////////////////////
            }
            catch (Exception exc)
            {
                Response.Write("<br>Exc: " + exc.ToString());
                var mtoken2 = t.GetHashCode();
                Response.Write("<br><a href=../views/Login.aspx?info=" + mtoken2 + ">Login</a>");
            }

        }

        protected void calOrg_SelectionChanged(object sender, EventArgs e)
        {
            
            ////////////////////////////////////////////////
            //
		    //Code:
            //@Myappdsb.exe
            ////////////////////////////////////////////
        }

        protected void BtnCal_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////
            //
		    //Code:
            //@Myappdsb.exe
            ////////////////////////////////////////////
        }

        private void CalAppPro()
        {
            //
            //char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            ////////////////////////////////////////////////
            //
		    //Code:
            //@Myappdsb.exe
            ////////////////////////////////////////////
            //
        }

        private bool PCalVal()
        {
            var pval = true;
            //
            ////////////////////////////////////////////////
            //
		    //Code:
            //@Myappdsb.exe
            ////////////////////////////////////////////
            //
            return pval;
        }

        protected void Btnhelp_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////
            //
		    //Code:
            //@Myappdsb.exe
            ////////////////////////////////////////////
        }

        protected void BtnViewC_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////
            //
		    //Code:
            //@Myappdsb.exe
            ////////////////////////////////////////////
        }
    }
}