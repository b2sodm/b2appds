/*////////////////////////////////////
//* @author: Brian
//* BM 2018
//* Login.aspx.cs
 *////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
//using System.Security.Principal;

namespace myappcald.views
{
    public partial class Login : System.Web.UI.Page
    {
        string strBrowser, strUrl, strIP;
        string name, email, passwd, puser, info;
        const String Pname = "myappcald";
        int lptoken, lpticks;
        long pticks, ptt;
        List<string> pList = new List<string>();
        //string serverNameDs = "Data_Source";
        //static string pid = "0";
        //static int lineN;
        //static string dsName = "MSSQL";
        SqlConnection sconnp = null;
        models.DbSetting dbSetting = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToLocalTime();
            var t = DateTime.Now;
            name = "Name01";
            puser = "User01";
            pticks = t.Ticks;
            var info = Request.QueryString.Get("info");
            var ph = " ";
            var pm = new admin.Paiclock();
            //
            ph += "<br>Date: " + t.Date;
            ph += "<br>Timex: " + time;
            ph += "<br>Timey: " + t.TimeOfDay;
            ph += "<br>Ticks: " + pticks;
            ph += "<br> " + info;
            txbInfo.Text = t.ToString();
            cldInfo.SelectedDate = t.Date;
            strUrl = Request.Url.ToString();
            strIP = Request.UserHostAddress.ToString();
            strBrowser = Request.Browser.Browser.ToString();
            ph += "<br>Url:  " + strUrl;
            ph += "<br>IP: " + strIP;
            ph += "<br>Browser: " + strBrowser;
            ph += "<br>M: " + pm.Pmessage();
            ph += "<br>T: " + pm.Ptime();
            placeHolder.Controls.Add(new LiteralControl(ph.ToString()));

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            email = usrEmail.Value.Trim();
            passwd = usrPasswd.Value.Trim(cTrim);
            info = txbInfo.Text.Trim(cTrim);
            lblFed.Text = "";
            lblFed.ForeColor = Color.Green;
            lblFed.BackColor = Color.SkyBlue;
            Dvalidate();
        }

        private void Dvalidate()
        {
            var err = 0;
            var dval = " ";
            Regex regEm = new Regex("^.+@.+\\..+$");
            Match memail = regEm.Match(email);
            if (!memail.Success)
            {
                err++;
                //Response.Write("<br>Err: " + err);
                lblFed.Text = "<br>Err: " + err;
                lblFed.ForeColor = Color.Red;
            }
            if (passwd.Length < 5)
            {
                err++;
                //Response.Write("<br>Err: " + err);
                lblFed.Text = "<br>Err: " + err;
                lblFed.ForeColor = Color.Yellow;
            }

            dval = ("<br>Info: " + info);
            dval += ("<br>Name: " + name);
            dval += ("<br>Email: " + email);
            dval += ("<br>User: " + puser);
            dval += ("<br>Err: " + err);
            lblFed.Text = (dval);
            if(err < 1)
            {
                Processp();
            }
        }

        private void Processp()
        {
            //ASCII character set 0 to 127.
            //Bytes 0 to 255.
            String temp = "temp1@";
            temp += passwd;
            temp += email.ElementAt(0);
            temp += Pname.ElementAt(6);
            temp += email;
            int tl = temp.Length;
            int t4 = 0;
            //Byte[] b = new Byte[tl];
            //////////////////////////////////////////////////////
            for (int i = 0; i < tl; i++)
            {
                t4 += i;
                Response.Write(" # " + t4);
            }
            Byte[] bt = Encoding.UTF8.GetBytes(temp);
            //int btl = bt.Length;
            SHA512 dhash = SHA512.Create();
            Byte[] dbyte = dhash.ComputeHash(bt);
            //ASCIIEncoding dasc = new ASCIIEncoding();
            //String rslt = dasc.GetString(dbyte);
            //int rsltl = rslt.Length;
            String thx123 = Convert.ToBase64String(dbyte);
            lptoken = email.Length + t4;
            passwd = "p" + thx123 + "" + lptoken;
            Pconnect();
        }

        private void Pconnect()
        {
            long lpt = Plticks();
            int errn = 0;
            ptt = (lpt - pticks);
            lpticks = lpt.GetHashCode();
            Response.Write("<br>1: " + lpt);
            lpt += lptoken;
            Response.Write("<br>2: " + lpt);
            string mtoken = "T" + lpt.GetHashCode().ToString() + "T";
            Response.Write("<br>3: " + email);
            Response.Write("<br>4: " + passwd);
            Response.Write("<br>5: " + mtoken);
            Response.Write("<br>6: " + lpticks);
            Response.Write("<br>7: " + ptt);
            //
            List<object> dbreader = new List<object>();
            try
            {
                string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string pCommand = @"SELECT * FROM " + db_sch_tbl +
                                  @" WHERE password =" + 
                                  "'" + @passwd + "'";
                dbreader = Dbads(pCommand);
                int d = dbreader.Count;
                Response.Write("<br>d#: " + d);
                int i = 0;
                foreach(var dd in dbreader)
                {
                    Response.Write("<br>dd#: "+i +" :#: " + dd);
                    i++;
                }
                if(dbreader.Contains(email))
                {
                    var code = dbreader[0];
                    var name = dbreader[1];
                    var type = dbreader[4];
                    var org = dbreader[7];
                    var bran = dbreader[8];
                    var act = dbreader[11].ToString().ToLower();
                    Response.Write("<br>Code#: "+ code);
                    Response.Write("<br>Name#: " + name);
                    Response.Write("<br>Type#: " + type);
                    Response.Write("<br>Organisation#: " + org);
                    Response.Write("<br>Branch#: " + bran);
                    Response.Write("<br>Active#: " + act);
                    if(act != "f")
                    {
                        Response.Redirect("myappds.html?code=" + code + ",name=" + name + ",type=" + type + ",org=" + org + ",bran=" + bran + "");
                    }
                   
                }
            }
            catch(Exception e)
            {
                errn++;
                Response.Write("<br> Exc: "+ errn + " <br># " + e.ToString());
            }
            //
            lpt = Plticks();
            ptt = (lpt - pticks);
            Response.Write("<br>8: " + lpt);
            Response.Write("<br>9: " + pticks);
            Response.Write("<br>10: " + ptt);

        }

        public long Plticks()
        {
            long lpt = DateTime.Now.Ticks;
            return (lpt);
        }

        // 
        /// <summary>
        /// handles database connections.
        /// process the database request.
        /// </summary>
        /// <param name="pqCommand"></param>
        /// <returns></returns>
        private List<object> Dbads(string pqCommand)
        {
            var errn = 0;
            var pfields = 0;
            var precords = 0;
            SqlDataReader dbReaderp = null;
            List<object> dbreaderb = new List<object>();
            try
            {
                ///////////////////////////////////////////////
                //var wi = WindowsIdentity.GetCurrent();
                //WindowsPrincipal p = new WindowsPrincipal(wi);
                //char c = '\\';
                //var dname = p.Identity.Name.Split(c);
                //var domain = dname[0];
                //Response.Write("<br>Domain: " + domain);
                //dsName = "MSSQL";
                //serverNameDs = @dsName;
                //dsName = "sqlexpress";
                //Data source or Sever Name.
                //serverNameDs = domain + "\\" + dsName;
                //string pconnstr = @"User Id=newp4;Password=newp33;Initial Catalog=dbads;Integrated Security=SSPI;Data Source=" + @serverNameDs;
                //string pconnstr2 = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dbads;Data Source=" + @serverNameDs;
                //////////////////////////////////////////////////////
                dbSetting = new models.DbSetting();
                var pconnstr = dbSetting.SqlConnStr(); 
                sconnp = new SqlConnection(pconnstr);
                sconnp.Open();
                SqlCommand cmdp = sconnp.CreateCommand();
                cmdp.CommandText = pqCommand;
                dbReaderp = cmdp.ExecuteReader();
                pfields = dbReaderp.FieldCount;
                precords = dbReaderp.RecordsAffected;
                while (dbReaderp.Read())
                {
                    for (int i = 0; i < pfields; i++)
                    {
                        dbreaderb.Add(dbReaderp.GetValue(i));
                        Response.Write("<br> # " + i + " # " + dbReaderp.GetValue(i));
                    }
                }

                sconnp.Close();
            }
            catch (Exception e)
            {
                errn++;
                Response.Write("<br> Exc: " + errn + " <br># " + e.ToString());
            }
            //
            Response.Write("<br> Fields: " + pfields);
            Response.Write("<br> Rec: " + precords);

            return dbreaderb;
        }
        //
    }
}