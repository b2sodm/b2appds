using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace myappcald.models
{
    public class AppdsCustomer
    {
        private string info;
        private string organisation;
        private string pbranch;
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
        AppdsCustomer thrp;
        int thrn;
        private int ccode;
        private int pcode;
        private string pname;
        private string disable;
        private string notes;
        private int pcodev;

        public AppdsCustomer(int pccode, int ppcode, string ppname, string psurname, string pemail, string pinfo, string porganisation, string ppbranch, string pdisabled, string pnotes)
        {
            var trpn = 41;
            thrp = new AppdsCustomer(pccode, ppcode, ppname, psurname, pemail, pinfo, porganisation, ppbranch, pdisabled, pnotes,trpn);
            thr = new Thread(new ThreadStart(thrp.Dvalidate));
            thr.Start();
            //
        }

        public AppdsCustomer(int pccode, int ppcode, string ppname, string psurname, string pemail, string pinfo, string porganisation, string ppbranch, string pdisabled, string pnotes, int trpn)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            ccode = pccode;
            pcode = ppcode;
            pname = ppname.Trim(cTrim);
            surname = psurname.Trim(cTrim);
            email = pemail.Trim();
            info = info.Trim(cTrim);
            organisation = porganisation.Trim(cTrim);
            pbranch = ppbranch.Trim(cTrim);
            disable = pdisabled.Trim(cTrim);
            notes = pnotes.Trim(cTrim);
            //
            DateTime t = DateTime.Now;
            pticks = t.Ticks;
            //
        }
        //
        private void Dvalidate()
        {
            var bra = 11;
            string db_sch_tbluser = @"[dbads].[dbads].[tbluser]";
            string pCommand = @"SELECT * FROM " + db_sch_tbluser +
                              @" WHERE pcode =" +
                              "'" + pcode + "'";
            if (FindUser(pcode+"", pCommand))
            {
                bra = 11;
            }
            else
            {
                bra = 9;
            }


            string db_sch_tblorg = @"[dbads].[dbads].[tblorganisation]";
            string pCommandb = @"SELECT * FROM " + db_sch_tblorg +
                              @" WHERE orgname =" +
                              "'" + organisation + "'";
            if (FindUser(organisation, pCommandb))
            {
                bra = 11;
            }
            else
            {
                bra = 8;
            }
            if (bra == 11)
            {
                pcodev = 88101;
                Register();
            }
        }
        //
        private bool FindUser(string euser, string pCommand)
        {
            bool esr = true;
            int errn = 0;
            var errp = " ";
            //
            List<object> dbreader = new List<object>();
            try
            {
                //string db_sch_tbl = @"[dbads].[dbads].[tblbranch]";
                //string pCommand = @"SELECT * FROM " + db_sch_tbl +
                //                  @" WHERE branname =" +
                //                  "'" + euser + "'";
                dbreader = Dbads(pCommand);
                int d = dbreader.Count;
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
        public int Codep()
        {
            //int ucode = 101;
            int ucode = 88101;
            int ydbs = 0;
            int xdbsize = 0;
            var errq = "0";
            List<object> dbreader = new List<object>();
            try
            {
                //string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string db_sch_tbl = @"[dbads].[dbads].[tblcustomer]";
                //string pCommand = @"SELECT pcode FROM " + db_sch_tbl;
                string pCommand = @"SELECT ccode FROM " + db_sch_tbl;
                //if (ucode == pcode)
                if (ucode == pcodev)
                {
                    dbreader = Dbads(pCommand);
                    xdbsize = dbreader.Count;
                    ydbs = xdbsize - 1;
                    ucode = (int)dbreader[ydbs];
                    ucode += 1;
                }

            }
            catch (Exception e)
            {
                errq = e.ToString();
            }
            //
            return ucode;
        }

        //
        private void Register()
        {
            //Response.Write("<br> Almost done...");
            long lpt = DateTime.Now.Ticks;
            var pm = new admin.Paiclock();
            //
            lock (this)
            {
                //int usrn = UserpCode(email);
                int usrn = Codep();
                //Response.Write("<br>pcode: " + usrn);
                //string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string db_sch_tbl = @"[dbads].[dbads].[tblcustomer]";
                //
                string pCommand = @"INSERT INTO " + db_sch_tbl + @"
		      	                  ([ccode], pcode, pname, surname, email, info,
                                    organisation, branch, disabled, notes )
		      	                  VALUES (" + usrn + ","
                                         + "'" + @pcode + "',"
                                         + "'" + @pname + "',"
                                         + "'" + @surname + "',"
                                         + "'" + @email + "',"
                                         + "'" + @info + "',"
                                         + "'" + @organisation + "',"
                                         + "'" + @pbranch + "',"
                                         + "'" + @puser + "',"
                                         + "'" + @notes + "')";
                //
                var pn = Dbads(pCommand);
            }
            //
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

        //


    }
}