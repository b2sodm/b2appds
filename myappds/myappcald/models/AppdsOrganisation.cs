using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace myappcald.models
{
    public class AppdsOrganisation
    {
        private int orgcode;
        private string orgname;
        private int pcode;
        private string pname;
        private string info;
        private string ptype;
        private int pbranch;
        private string notes;
        private int orgcodev;
        private string errq;
        private SqlConnection sconnp;
        List<string> pList = new List<string>();
        models.DbSetting dbSetting = null;
        Thread thr;
        AppdsOrganisation thrp;

        public AppdsOrganisation(int orcode, string orname, int opcode, string opname, string opinfo, string optype, int orbranch, string ornotes)
        {
            var trpn = 501;
            thrp = new AppdsOrganisation(orcode, orname, opcode, opname, opinfo, optype, orbranch, ornotes, trpn);
            thr = new Thread(new ThreadStart(thrp.Dvalidate));
            thr.Start();
            //
        }

        public AppdsOrganisation(int orcode, string orname, int opcode, string opname, string opinfo, string optype, int orbranch, string ornotes, int ptrp)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            orgcode = orcode;
            orgname = orname.Trim(cTrim);
            pcode = opcode;
            pname = opname.Trim(cTrim);
            info = opinfo.Trim(cTrim);
            ptype = optype.Trim(cTrim);
            pbranch = orbranch;
            notes = ornotes.Trim(cTrim);
        }

        public AppdsOrganisation(int ucode, string uname, string utype)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            pcode = ucode;
            pname = uname.Trim(cTrim);
            ptype = utype.Trim(cTrim);
        }

        //
        private void Dvalidate()
        {
            if (FindUser(orgname))
            {
                orgcodev = 51015101;
            }
            else
            {
                orgcodev = 5101;
                Register();
            }
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
        public int Codep()
        {
            //int ucode = 101;
            int ucode = 5101;
            int ydbs = 0;
            int xdbsize = 0;
            List<object> dbreader = new List<object>();
            try
            {
                //string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string db_sch_tbl = @"[dbads].[dbads].[tblorganisation]";
                //string pCommand = @"SELECT pcode FROM " + db_sch_tbl;
                string pCommand = @"SELECT orgcode FROM " + db_sch_tbl;
                //if (ucode == pcode)
                if (ucode == orgcodev)
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
        public List<object> OrgAdmnVL()
        {
            //Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            //string orgnamep = orgName.Trim(cTrim);
            //string db_sch_tbl = @"[dbads].[dbads].[tblorganisation]";
            //string pqc = @"select orgcode, orgname from "+ db_sch_tbl + "where orgname = "+ orgName;
            //string pqc = @"select ucode, pname, ptype, organisation, disabled from dbads.tblorguser where pcode = '" + pucodep + "';";
            string pqc = @"select orgname from dbads.tblorganisation where pcode = '" + pcode + "';";
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
                string db_sch_tbl = @"[dbads].[dbads].[tblorganisation]";
                //
                string pCommand = @"INSERT INTO " + db_sch_tbl + @"
		      	                  ([orgcode], orgname, pcode, pname,
                                    info, ptype, notes )
		      	                  VALUES (" + usrn + ","
                                         + "'" + @orgname + "',"
                                         + "'" + @pcode + "',"
                                         + "'" + @pname + "',"
                                         + "'" + @info + "',"
                                         + "'" + @ptype + "',"
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

    }
}