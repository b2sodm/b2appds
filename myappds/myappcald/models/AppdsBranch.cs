﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace myappcald.models
{
    public class AppdsBranch
    {
       
        //
        private string branchn;
        private string orgname;
        private int pcode;
        private string pname;
        private string info;
        private string ptype;
        private int orgcodev;
        private string errq;
        private SqlConnection sconnp;
        List<string> pList = new List<string>();
        models.DbSetting dbSetting = null;
        Thread thr;
        AppdsBranch thrp;

        //AppdsBranch orgpn = new AppdsBranch(branchname, orgname, usscode, uname, t.ToString(), utype);
        public AppdsBranch(string branchnm, string orname, int opcode, string opname, string opinfo, string optype)
        {
            var trpn = 501;
            thrp = new AppdsBranch(branchnm, orname, opcode, opname, opinfo, optype, trpn);
            thr = new Thread(new ThreadStart(thrp.Dvalidate));
            thr.Start();
            //
        }

        public AppdsBranch(string branchnm, string orname, int opcode, string opname, string opinfo, string optype, int ptrp)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            //
            branchn = branchnm.Trim(cTrim);
            orgname = orname.Trim(cTrim);
            pcode = opcode;
            pname = opname.Trim(cTrim);
            info = opinfo.Trim(cTrim);
            ptype = optype.Trim(cTrim);
        }
        //
        private void Dvalidate()
        {
            if (FindOrg(orgname))
            {
                if(FindBranch(branchn))
                {
                    orgcodev = 710107;
                }
                else
                {
                    orgcodev = 7101;
                    Register();
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
        public int Codep()
        {
            //int ucode = 101;
            int ucode = 7101;
            int ydbs = 0;
            int xdbsize = 0;
            List<object> dbreader = new List<object>();
            try
            {
                //string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string db_sch_tbl = @"[dbads].[dbads].[tblbranch]";
                //string pCommand = @"SELECT pcode FROM " + db_sch_tbl;
                string pCommand = @"SELECT bracode FROM " + db_sch_tbl;
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
                string db_sch_tbl = @"[dbads].[dbads].[tblbranch]";
                //AppdsBranch orgpn = new AppdsBranch(branchname, orgname, usscode, uname, t.ToString(), utype);
                string pCommand = @"INSERT INTO " + db_sch_tbl + @"
		      	                  ([bracode], braname, orgname, pcode, pname,
                                    info, ptype)
		      	                  VALUES (" + usrn + ","
                                         + "'" + @branchn + "',"
                                         + "'" + @orgname + "',"
                                         + "'" + @pcode + "',"
                                         + "'" + @pname + "',"
                                         + "'" + @info + "',"
                                         + "'" + @ptype + "')";
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