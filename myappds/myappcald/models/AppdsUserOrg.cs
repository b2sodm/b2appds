using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace myappcald.models
{
    public class AppdsUserOrg
    {
        private int bracodev;
        private string errq;
        private SqlConnection sconnp;
        List<string> pList = new List<string>();
        models.DbSetting dbSetting = null;
        Thread thr;
        AppdsUserOrg thrp;
        //int thrn;
        private string porgname;
        private string pbranchname;
        private string punamep;
        private int pucodep;
        private string putypep;
        private string pymess;
        private string ppinfo;

        public AppdsUserOrg(string orgname, string branchname, string unamep, int ucodep, string utypep, string ymess, string info)
        {
            var trpn = 501;
            thrp = new AppdsUserOrg(orgname, branchname, unamep, ucodep, utypep, ymess, info, trpn);
            thr = new Thread(new ThreadStart(thrp.Dvalidate));
            thr.Start();
            //
        }

        public AppdsUserOrg(string orgname, string branchname, string unamep, int ucodep, string utypep, string ymess, string pinfo, int ptrp)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            porgname = orgname.Trim(cTrim);
            pbranchname = branchname.Trim(cTrim);
            punamep = unamep.Trim(cTrim);
            pucodep = ucodep;
            putypep = utypep.Trim(cTrim);
            pymess = ymess.Trim(cTrim);
            ppinfo = pinfo.Trim(cTrim);
        }

        //
        private void Dvalidate()
        {
            string db_sch_tblorg = @"[dbads].[dbads].[tblorganisation]";
            if (FindUser(porgname, db_sch_tblorg))
            {
                bracodev = 6101;
                Register();
            }
        }
        //
        public bool FindUser(string euser)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            var orgnamep = euser.Trim(cTrim);
            string db_sch_tbl = @"[dbads].[dbads].[tblorganisation]";
            //
            return FindUser(orgnamep, db_sch_tbl);
        }
        private bool FindUser(string euser, string db_sch_tbl)
        {
            bool esr = true;
            int errn = 0;
            var errp = " ";
            //
            List<object> dbreader = new List<object>();
            try
            {
                //string db_sch_tbl = @"[dbads].[dbads].[tblbranch]";
                string pCommand = @"SELECT * FROM " + db_sch_tbl +
                                  @" WHERE orgname =" +
                                  "'" + euser + "'";
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
            //int ucode = 7101;
            int ucode = 6101;
            int ydbs = 0;
            int xdbsize = 0;
            List<object> dbreader = new List<object>();
            try
            {
                //string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string db_sch_tbl = @"[dbads].[dbads].[tblorguser]";
                //string pCommand = @"SELECT pcode FROM " + db_sch_tbl;
                string pCommand = @"SELECT ucode FROM " + db_sch_tbl;
                //string pCommand = @"SELECT ccode FROM dbads.tblorguser";
                //if (ucode == pcode)
                if (ucode == bracodev)
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
                string db_sch_tbl = @"[dbads].[dbads].[tblorguser]";
                //
                string pCommand = @"INSERT INTO " + db_sch_tbl + @"
		      	                  ([ucode], pcode, pname,
                                    info, ptype, organisation)
		      	                  VALUES (" + usrn + ","
                                         + "'" + @pucodep + "',"
                                         + "'" + @punamep + "',"
                                         + "'" + @ppinfo + "',"
                                         + "'" + @putypep + "',"
                                         + "'" + @porgname + "')";
                //
                var pn = Dbads(pCommand);
            }
            //
        }
        //
        //
        public List<object> InfOrgL(string orgName)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            string orgnamep = orgName.Trim(cTrim);
            //string db_sch_tbl = @"[dbads].[dbads].[tblorganisation]";
            //string pqc = @"select orgcode, orgname from "+ db_sch_tbl + "where orgname = "+ orgName;
            string pqc = @"select orgcode, orgname from dbads.tblorganisation where orgname = '"+orgName+"';";
            return Dbads(pqc);
        }
        public List<object> InfOrgL()
        {
            string pqc = @"select orgcode, orgname from dbads.tblorganisation;";
            return Dbads(pqc);
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