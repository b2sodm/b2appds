using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace myappcald.models
{
    public class AppdsUserBranch
    {
        private string braname;
        private string orgname;
        private int pcode;
        private string pname;
        private string info;
        private string ptype;
        //private int bracodev;
        private string errq;
        private SqlConnection sconnp;
        List<string> pList = new List<string>();
        models.DbSetting dbSetting = null;
        Thread thr;
        AppdsUserBranch thrp;
        private int codev;

        //

        //
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //var orgname = orgp.trim();
        //var branchname = branchp.trim();
        //var ymess = ymessage.trim();
        //var jorgl = [orgname, branchname, namep, codep, typep, ymess];
        //$("#infoOrg").load("/admin/BranchUserAdm.aspx?jorgad=" + jorgl);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        public AppdsUserBranch(string porganame, string pbraname, string ppname, int ppcode, string pptype, string pinfo)
        {
            var trpn = 501;
            thrp = new AppdsUserBranch(porganame, pbraname, ppname, ppcode, pptype, pinfo, trpn);
            thr = new Thread(new ThreadStart(thrp.Dvalidate));
            thr.Start();
            //
        }

        public AppdsUserBranch(string porganame, string pbraname, string ppname, int ppcode, string pptype, string pinfo, int ptrp)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            
            orgname = porganame.Trim(cTrim);
            braname = pbraname.Trim(cTrim);
            pcode = ppcode;
            pname = ppname.Trim(cTrim);
            info = pinfo.Trim(cTrim);
            ptype = pptype.Trim(cTrim);
            codev = 610161;
        }

        public AppdsUserBranch(int usscode, string uname, string utype, string porgname, string pbranchn)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            pcode = usscode;
            pname = uname.Trim(cTrim);
            ptype = utype.Trim(cTrim);
            orgname = porgname.Trim(cTrim);
            braname = pbranchn.Trim(cTrim);
        }

        //

        //
        private void Dvalidate()
        {
            if (FindOrg(orgname))
            {
                if (FindBranch(braname))
                {
                    codev = 6101;
                    Register();
                }
                else
                {
                    codev = 610107;
                }
            }
        }
        //
        private bool FindOrg(string euser)
        {
            bool esr = true;
            int errn = 0;
            var errp = " ";
            //
            List<object> dbreader = new List<object>();
            try
            {
                string db_sch_tbl = @"[dbads].[dbads].[tblorganisation]";
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
        private bool FindBranch(string euser)
        {
            bool esr = true;
            int errn = 0;
            var errp = " ";
            //
            List<object> dbreader = new List<object>();
            try
            {
                string db_sch_tbl = @"[dbads].[dbads].[tblbranch]";
                string pCommand = @"SELECT * FROM " + db_sch_tbl +
                                  @" WHERE braname =" +
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
        //
        public int Codep()
        {
            //int ucode = 101;
            //vcodev = 6101;
            int ucode = 6101;
            int ydbs = 0;
            int xdbsize = 0;
            List<object> dbreader = new List<object>();
            try
            {
                //string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string db_sch_tbl = @"[dbads].[dbads].[tblbranchuser]";
                //string pCommand = @"SELECT pcode FROM " + db_sch_tbl;
                string pCommand = @"SELECT ucode FROM " + db_sch_tbl;
                //if (ucode == pcode)
                if (ucode == codev)
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
        //
        public List<object> BranchUserVL()
        {
            //Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            //string orgnamep = orgName.Trim(cTrim);
            //string db_sch_tbl = @"[dbads].[dbads].[tblorganisation]";
            //string pqc = @"select orgcode, orgname from "+ db_sch_tbl + "where orgname = "+ orgName;
            //string pqc = @"select ucode, pname, ptype, organisation, disabled from dbads.tblorguser where pcode = '" + pucodep + "';";
            string pqc = @"select branch from dbads.tblbranchuser where pcode = '" + pcode + "' and organisation ='" + orgname + "';";
            return Dbads(pqc);
        }
        //

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
                string db_sch_tbl = @"[dbads].[dbads].[tblbranchuser]";
                //
                string pCommand = @"INSERT INTO " + db_sch_tbl + @"
		      	                  ([ucode], pcode, pname, info, ptype, organisation,
                                    branch)
		      	                  VALUES (" + usrn + ","
                                         + "'" + @pcode + "',"
                                         + "'" + @pname + "',"
                                         + "'" + @info + "',"
                                         + "'" + @ptype + "',"
                                         + "'" + @orgname + "',"
                                         + "'" + @braname + "')";
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
    }
}