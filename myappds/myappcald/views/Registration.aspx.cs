/*////////////////////////////////////
//* @author: Brian
//* BM 2018
//* Registration.aspx.cs
 *//////////////////////////////////////// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data.Sql;
//using System.Security.Principal;

namespace myappcald.views
{
    public partial class Registration : System.Web.UI.Page
    {
        String name, surname, email, passwd, puser, info, strTrim;
        const String Pname = "myappcald";
        int lptoken;
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
            DateTime t = DateTime.Now;
            pticks = t.Ticks;
            txbInfo.Text = t.ToString();
            cldInfo.SelectedDate = t.Date;
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            Char []cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            name = usrName.Value.Trim(cTrim);
            surname = usrSurname.Value.Trim(cTrim);
            email = usrEmail.Value.Trim();
            passwd = usrPasswd.Value.Trim(cTrim);
            puser = rdbList.Text.Trim(cTrim);
            info = txbInfo.Text.Trim(cTrim);
            lblRlist.Text = "";
            lblVemail.Text = "";
            lblVpasswd.Text = "";
            strTrim = " ";
            lblFed.ForeColor = Color.Green;
            lblFed.BackColor = Color.SkyBlue;
            int i;
            for( i = 0; i < cTrim.Length; i++)
            {
                strTrim += cTrim.GetValue(i);
                //Response.Write("<br> " + i + " " + cTrim.GetValue(i));
            }

            Dvalidate();
        }

        private void Dvalidate()
        {
            //Response.Write("<br> " + strTrim);
            //Response.Write("<br> " + strTrim.Length);
            int err = 0;
            String dval = " ";
            Regex regEm = new Regex("^.+@.+\\..+$");
            Match memail = regEm.Match(email);
            if (!memail.Success)
            {
                err += 1;
                lblVemail.Text = "Invalid email: " + email;
                usrEmail.Focus();
                lblFed.ForeColor = Color.Red;
            }

            if(passwd.Length < 5)
            {
                err += 1;
                lblVpasswd.Text = "Passwd < 5, trim: " + strTrim;
                usrPasswd.Focus();
                lblFed.ForeColor = Color.Yellow;
            }

            if(puser == "")
            {
                err += 1;
                lblRlist.Text = "Please select one radio button.";
                lblFed.ForeColor = Color.Orange;
            }

            dval = ("<br>Info: " + info);
            dval += ("<br>Name: " + name);
            dval += ("<br>Surname:" + surname);
            dval += ("<br>Email: " + email);
            dval += ("<br>Pwd: ");
            dval += ("<br>User: " + puser);
            dval += ("<br>Err: " + err);
            lblFed.Text = (dval);
            if(err < 1)
            {
                if (FindUser(email))
                {
                    dval += ("<br>Err: " + email + ", online.");
                    Response.Write("<br>Err: " + email +", is already online!" );
                    lblFed.Text = (dval);
                }
                else
                {
                    Processp();
                }
            }

        }

        private void Processp()
        {
            Response.Write("<br>Processing...");
            //ASCII character set 0 to 127.
            //Bytes 0 to 255.
            String temp = "temp1@";
            temp += passwd;
            temp += email.ElementAt(0);
            temp += Pname.ElementAt(6);
            temp += email;
            int tl = temp.Length;
            Byte[] b = new Byte[tl];
            //////////////////////////////////////////////////////
            Byte[] bt = Encoding.UTF8.GetBytes(temp);
            int btl = bt.Length;
            int t4 = 0;
            Response.Write("//<br>#bt3 " + btl + "<br>");
            int i;
            for (i = 0; i < tl; i++)
            {
                t4 += i;
            }
            //Base64FormattingOptions b64 = new Base64FormattingOptions();
            Response.Write("<br>#t " + i + " t4 " + t4);
            SHA512 dhash = SHA512.Create();
            Byte[] dbyte = dhash.ComputeHash(bt);
            ASCIIEncoding dasc = new ASCIIEncoding();
            String rslt = dasc.GetString(dbyte);
            int rsltl = rslt.Length;
            Response.Write("<br>#rslt " + rsltl + " AsciiEnco# " + rslt);
            String tm127 = "#";
            String tm;
            int th;
            //String tmh;
            //String thx123p = "#";
            String tm255 = "#";
            String tmob = "";
            String thx123 = Convert.ToBase64String(dbyte);
            for (i = 0; i < rsltl; i++)
            {
                tm = rslt[i]+"";
                tm127 += tm;
                Response.Write("<br>#byte " + i + " # " + tm);
                th = dbyte.ElementAt(i);
                tm255 += th;
                //tmh = Hex(th);
                //thx123p += tmh;
                tmob += th;
                Response.Write("<br>#ASCII127 " + i + " # " + th);
                //Response.Write("<br>#HEX " + i + " # " + tmh);
            }
            Response.Write("<br>#t127 " + rsltl + "<br>" + tm127);
            Response.Write("<br>#255 " + rsltl + "<br>" + tm255);
            Response.Write("<br>#hex " + i + " <br> " + thx123);
            Response.Write("<br>#t127 " + rsltl + "<br>" + tm127.Length);
            Response.Write("<br>#255 " + rsltl + "<br>" + tm255.Length);
            Response.Write("<br>#hex " + i + " <br> " + thx123.Length);
            lptoken = email.Length + t4;
            passwd = "p" + thx123 + "" + lptoken;
            
            Register();
        }

        private void Register()
        {
            Response.Write("<br> Almost done..." + lptoken.GetHashCode());
            long lpt = DateTime.Now.Ticks;
            var pm = new admin.Paiclock();
            ptt = (lpt - pticks);
            Response.Write("<br>" + lpt);
            lpt += lptoken;
            string mtoken = "T"+ lpt.GetHashCode().ToString() +"T";
            //
            //int usrn = UserpCode();
            Application.Lock();
            int usrn = UserpCode(email);
            Response.Write("<br>pcode: " + usrn);
            string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
            //
            string pCommand = @"INSERT INTO " + db_sch_tbl + @"
		      	                  ([pcode], pname, surname, email,
                                    poption, info, password )
		      	                  VALUES (" + usrn +","
                                     + "'" + @name + "',"
                                     + "'" + @surname + "',"
                                     + "'" + @email + "',"
                                     + "'" + @puser + "',"
                                     + "'" + @info + "',"
                                     + "'" + @passwd + "')";
            //
            var pn = Dbads(pCommand);
            Response.Write("<br>pn:# " + pn.Count);
            Application.UnLock();
            //
            Response.Write("<br>" + lpt);
            Response.Write("<br>" + email);
            Response.Write("<br>" + passwd);
            Response.Write("<br>" + passwd.Length);
            Response.Write("<br>" + mtoken);
            Response.Write("<br>" + pticks);
            Response.Write("<br><a href=Login.aspx?info=" + mtoken + ">Login</a>");
            Response.Write("<br>" + ptt);
            Response.Write("<br>M: " + pm.Pmessage());
            Response.Write("<br>T: " + pm.Ptime());
        }

        private int UserpCode()
        {
            int n = 101;
            List<object> dbreader = new List<object>();
            try
            {
                string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                //string pCommand = @"SELECT pcode FROM " + db_sch_tbl;
                string pCommand = @"SELECT COUNT(*) FROM " + db_sch_tbl;
                //dbreader = Dbads(pCommand);
            }
            catch (Exception e)
            {
                Response.Write("<br>E: " + e.ToString());
            }

            int x = dbreader.Count;
            Response.Write("<br>x: " + x);
            //var pp = dbreader[x-1];
            var p = dbreader[0];
            Response.Write("<br>x: " + p);
            int d = Int32.Parse(p.ToString());
            n += d;
            Response.Write("<br>x: " + n);
            return n;
        }

        private int UserpCode(string euser)
        {
            admin.UserCode ucode = new admin.UserCode(euser);
            int pcode = ucode.Codep();
            Response.Write("<br>#code#: " + pcode);
            return pcode;
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
                /////////////////////////////////////////////////////////////////////
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
                ////////////////////////////////////////////////////////////////

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
                    for(int i = 0; i < pfields; i++ )
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

        private bool FindUser(string euser)
        {
            bool esr = true;
            int errn = 0;
            //
            List<object> dbreader = new List<object>();
            try
            {
                string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string pCommand = @"SELECT * FROM " + db_sch_tbl +
                                  @" WHERE email =" +
                                  "'" + euser + "'";
                dbreader = Dbads(pCommand);
                int d = dbreader.Count;
                Response.Write("<br>d#: " + d);
                esr = dbreader.Contains(euser);
                int i = 0;
                foreach (var dd in dbreader)
                {
                    Response.Write("<br>dd#: "+ i + " :#: " + dd);
                    i++;
                }
            }
            catch (Exception e)
            {
                errn++;
                Response.Write("<br> Exc: " + errn + " <br># " + e.ToString());
            }
            //
            //
            return esr;
        }
    }
}