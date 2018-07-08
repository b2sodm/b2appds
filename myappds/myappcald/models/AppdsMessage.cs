using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace myappcald.models
{
    public class AppdsMessage
    {
        private int mcode;
        private int pcode;
        private string info;
        private string organisation;
        private string pbranch;
        private string pname;
        private string psurname;
        private string email;
        private string ptype;
        private string notes;
        private string message;
        const String Pname = "myappcald";
        int lptoken;
        long pticks, ptt;
        List<string> pList = new List<string>();
        SqlConnection sconnp = null;
        models.DbSetting dbSetting = null;
        Thread thr;
        AppdsMessage thrp;
        int thrn;
        private int mcodev;

        public AppdsMessage(int pmcode, int ppcode, string ppname, string ppsurname, string pemail, string pptype, string pinfo, string porganisation, string ppbranch, string pmessage, string pnotes)
        {
            var trpn = 41;
            thrp = new AppdsMessage(pmcode, ppcode, ppname, ppsurname, pemail, pptype, pinfo, porganisation, ppbranch, pmessage, pnotes, trpn);
            thr = new Thread(new ThreadStart(thrp.Dvalidate));
            thr.Start();
            //
        }

        public AppdsMessage(int pmcode, int ppcode, string ppname, string ppsurname, string pemail, string pptype, string pinfo, string porganisation, string ppbranch, string pmessage, string pnotes, int trp)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            mcode = pmcode;
            pcode = ppcode;
            pname = ppname.Trim(cTrim);
            psurname = ppsurname.Trim(cTrim);
            email = pemail.Trim();
            ptype = pptype.Trim(cTrim);
            //info = pinfo.Trim(cTrim);
            organisation = porganisation.Trim(cTrim);
            pbranch = ppbranch.Trim(cTrim);
            message = pmessage.Trim(cTrim);
            notes = pnotes.Trim(cTrim);
            //
            DateTime t = DateTime.Now;
            pticks = t.Ticks;
            info = t.ToString();
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
            if (FindUser(pcode + "", pCommand))
            {
                bra = 11;
            }
            else
            {
                bra = 9;
            }


            string db_sch_tblorg = @"[dbads].[dbads].[tblmessage]";
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
                mcodev = 99101;
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
            int ucode = 99101;
            int ydbs = 0;
            int xdbsize = 0;
            var errq = "0";
            List<object> dbreader = new List<object>();
            try
            {
                //string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string db_sch_tbl = @"[dbads].[dbads].[tblmessage]";
                //string pCommand = @"SELECT pcode FROM " + db_sch_tbl;
                string pCommand = @"SELECT mcode FROM " + db_sch_tbl;
                //if (ucode == pcode)
                if (ucode == mcodev)
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
                string db_sch_tbl = @"[dbads].[dbads].[tblmessage]";
                //
                string pCommand = @"INSERT INTO " + db_sch_tbl + @"
		      	                  ([mcode], pcode, pname, surname, email, type,
                                   info, organisation, branch, message, notes )
		      	                  VALUES (" + usrn + ","
                                         + "'" + @pcode + "',"
                                         + "'" + @pname + "',"
                                         + "'" + @psurname + "',"
                                         + "'" + @email + "',"
                                         + "'" + @ptype + "',"
                                         + "'" + @info + "',"
                                         + "'" + @organisation + "',"
                                         + "'" + @pbranch + "',"
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