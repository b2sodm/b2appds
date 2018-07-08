/*////////////////////////////////////
//* @author: Brian
//* BM 2018
//* AppdsUser.cs
 *//////////////////////////////////////// 

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace myappcald.models
{
    public class AppdsUser
    {
        private string info;
        private string name;
        private string surname;
        private string email;
        private string passwd;
        private string puser;
        private string strTrim;
        const String Pname = "myappcald";
        int lptoken;
        long pticks, ptt;
        List<string> pList = new List<string>();
        SqlConnection sconnp = null;
        models.DbSetting dbSetting = null;
        Thread thr;
        AppdsUser thrp;
        int thrn;

        public AppdsUser(string infor, string namer, string surnamer, string emailr, string passwdr, string puserr)
        {
            var trpn = 10;
            thrp = new AppdsUser(infor, namer, surnamer, emailr, passwdr, puserr, trpn);
            thr = new Thread(new ThreadStart(thrp.Dvalidate));
            thr.Start();
            //
        }

        public AppdsUser(string infor, string namer, string surnamer, string emailr, string passwdr, string puserr, int trpn)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            info = infor.Trim(cTrim);
            name = namer.Trim(cTrim);
            surname = surnamer.Trim(cTrim);
            email = emailr.Trim();
            passwd = passwdr.Trim(cTrim);
            puser = puserr.Trim(cTrim);
            //
            strTrim = " ";
            int i;
            for (i = 0; i < cTrim.Length; i++)
            {
                strTrim += cTrim.GetValue(i);
            }
            thrn = trpn;
            DateTime t = DateTime.Now;
            pticks = t.Ticks;
            //
        }

        private void Dvalidate()
        {
            int err = 0;
            int erd = 0;
            //String dval = " ";
            Regex regEm = new Regex("^.+@.+\\..+$");
            Match memail = regEm.Match(email);
            if (!memail.Success)
            {
                err += 1;
            }

            if (passwd.Length < 5)
            {
                err += 1;
            }

            if (puser == "")
            {
                err += 1;
            }

            //dval = ("<br>Info: " + info);
            //dval += ("<br>Name: " + name);
            //dval += ("<br>Surname:" + surname);
            //dval += ("<br>Email: " + email);
            //dval += ("<br>Pwd: ");
            //dval += ("<br>User: " + puser);
            //dval += ("<br>Err: " + err);
            //lblFed.Text = (dval);
            if (err < 1)
            {
                if (FindUser(email))
                {
                    //dval += ("<br>Err: " + email + ", online.");
                    //Response.Write("<br>Err: " + email + ", is already online!");
                    //lblFed.Text = (dval);
                    erd += 1;
                }
                else
                {
                    Processp();
                }
            }
        }
        //
        private void Processp()
        {
            //Response.Write("<br>Processing...");
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
            //Response.Write("//<br>#bt3 " + btl + "<br>");
            int i;
            for (i = 0; i < tl; i++)
            {
                t4 += i;
            }
            //Base64FormattingOptions b64 = new Base64FormattingOptions();
            //Response.Write("<br>#t " + i + " t4 " + t4);
            SHA512 dhash = SHA512.Create();
            Byte[] dbyte = dhash.ComputeHash(bt);
            ASCIIEncoding dasc = new ASCIIEncoding();
            String rslt = dasc.GetString(dbyte);
            int rsltl = rslt.Length;
            //Response.Write("<br>#rslt " + rsltl + " AsciiEnco# " + rslt);
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
                tm = rslt[i] + "";
                tm127 += tm;
                //Response.Write("<br>#byte " + i + " # " + tm);
                th = dbyte.ElementAt(i);
                tm255 += th;
                //tmh = Hex(th);
                //thx123p += tmh;
                tmob += th;
                //Response.Write("<br>#ASCII127 " + i + " # " + th);
                //Response.Write("<br>#HEX " + i + " # " + tmh);
            }
            //
            lptoken = email.Length + t4;
            passwd = "p" + thx123 + "" + lptoken;

            Register();
        }
        //
        private void Register()
        {
            //Response.Write("<br> Almost done..." + lptoken.GetHashCode());
            long lpt = DateTime.Now.Ticks;
            var pm = new admin.Paiclock();
            ptt = (lpt - pticks);
            //Response.Write("<br>" + lpt);
            lpt += lptoken;
            string mtoken = "T" + lpt.GetHashCode().ToString() + "T";
            //
            //Application.Lock();
            lock (this)
            {
                int usrn = UserpCode(email);
                //Response.Write("<br>pcode: " + usrn);
                string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                //
                string pCommand = @"INSERT INTO " + db_sch_tbl + @"
		      	                  ([pcode], pname, surname, email,
                                    poption, info, password )
		      	                  VALUES (" + usrn + ","
                                         + "'" + @name + "',"
                                         + "'" + @surname + "',"
                                         + "'" + @email + "',"
                                         + "'" + @puser + "',"
                                         + "'" + @info + "',"
                                         + "'" + @passwd + "')";
                //
                var pn = Dbads(pCommand);
                //Response.Write("<br>pn:# " + pn.Count);
            }
            //Application.UnLock();
            //Response.Write("<br><a href=Login.aspx?info=" + mtoken + ">Login</a>");
        }
        //
        private int UserpCode(string euser)
        {
            admin.UserCode ucode = new admin.UserCode(euser);
            int pcode = ucode.Codep();
            //Response.Write("<br>#code#: " + pcode);
            return pcode;
        }
        //
        private bool FindUser(string euser)
        {
            bool esr = true;
            int errn = 0;
            var errp = " ";
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
                //Response.Write("<br>d#: " + d);
                esr = dbreader.Contains(euser);
                int i = 0;
                foreach (var dd in dbreader)
                {
                    //Response.Write("<br>dd#: " + i + " :#: " + dd);
                    i++;
                }
            }
            catch (Exception e)
            {
                errn++;
                errp = e.Message;
                //Response.Write("<br> Exc: " + errn + " <br># " + e.ToString());
            }
            //
            //
            return esr;
        }
        //
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
            var excp = " ";
            SqlDataReader dbReaderp = null;
            List<object> dbreaderb = new List<object>();
            try
            {
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
                        //Response.Write("<br> # " + i + " # " + dbReaderp.GetValue(i));
                    }
                }

                sconnp.Close();
            }
            catch (Exception e)
            {
                errn++;
                excp = e.Message;
                //Response.Write("<br> Exc: " + errn + " <br># " + e.ToString());
            }
            //
            //Response.Write("<br> Fields: " + pfields);
            //Response.Write("<br> Rec: " + precords);

            return dbreaderb;
        }
        //
    }
}