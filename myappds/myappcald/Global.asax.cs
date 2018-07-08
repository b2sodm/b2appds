using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace myappcald
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            string excp = " ";
            string url = " ";
            try
            {
                url = Request.Url.ToString();
                string strFile = Server.MapPath("log2.txt");
                //
                FileStream fStream = new FileStream(strFile, FileMode.Append, FileAccess.Write);
                var log = new System.IO.StreamWriter(fStream);
                //var log = new System.IO.StreamWriter(strFile);
                var exc = Server.GetLastError();
                excp = exc.ToString();
                log.WriteLine("##########################");
                log.WriteLine(DateTime.Now);
                log.WriteLine(excp);
                log.WriteLine(url);
                log.WriteLine(Request.UserHostAddress);
                log.WriteLine(Request.Browser.Browser.ToString());
                log.WriteLine(excp.Count());
                log.WriteLine("/////////////////////////////");
                log.Close();
            }
            catch (Exception exc)
            {
                Response.Write("<br> Exception : <br> " + exc.ToString() + "<br>");
            }
            finally
            {
                if(url.Contains("views"))
                {
                    Response.Redirect("login.aspx?info=" + excp.Count());
                }
                else
                {
                    Response.Redirect("views/login.aspx?info=" + excp.Count());
                }
                
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}