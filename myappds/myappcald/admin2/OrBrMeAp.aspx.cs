using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myappcald.admin2
{
    public partial class OrBrMeAp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var t = DateTime.Now;
            Response.Write("<br> ORG: " + t.ToString());


        }
    }
}