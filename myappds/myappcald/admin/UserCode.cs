/*////////////////////////////////////
//* @author: Brian
//* BM 2018
//* UserCode.cs
 *//////////////////////////////////////// 

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Web;

namespace myappcald.admin
{
    public class UserCode
    {
        string email;
        int ehash;
        DateTime edate;
        int pcode;
        private string dsName;
        private string serverNameDs;
        private SqlConnection sconnp;
        private string errq;
        models.DbSetting dbSetting = null;

        public UserCode(string euser)
        {
            Char[] cTrim = { '"', ' ', '<', '>', ';', '=', '\\', ',', '\'', '-', '+', '#' };
            Regex regEm = new Regex("^.+@.+\\..+$");
            Match memail = regEm.Match(euser);
            if (memail.Success)
            {
                email = euser.Trim(cTrim);
                ehash = email.GetHashCode();
                edate = DateTime.Now;
                pcode = 101;
            }
            else
            {
                pcode = 0;
            }
        }

        public int Codep()
        {
            int ucode = 101;
            int ydbs = 0;
            int xdbsize = 0;
            List<object> dbreader = new List<object>();
            try
            {
                string db_sch_tbl = @"[dbads].[dbads].[tbluser]";
                string pCommand = @"SELECT pcode FROM " + db_sch_tbl;
                if(ucode == pcode)
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


        /// <summary>
        /// handles database connections.
        /// process the database request.
        /// </summary>
        /// <param name="pqCommand"></param>
        /// <returns></returns>
        private List<object> Dbadsp(string pqCommand)
        {
            var errn = 0;
            var pfields = 0;
            var precords = 0;
            SqlDataReader dbReaderp = null;
            List<object> dbreaderb = new List<object>();
            try
            {
                //
                var wi = WindowsIdentity.GetCurrent();
                WindowsPrincipal p = new WindowsPrincipal(wi);
                char c = '\\';
                var dname = p.Identity.Name.Split(c);
                var domain = dname[0];
                //dsName = "MSSQL";
                //serverNameDs = @dsName;
                dsName = "sqlexpress";
                //Data source or Sever Name.
                serverNameDs = domain + "\\" + dsName;
                string pconnstr = @"User Id=newp4;Password=newp33;Initial Catalog=dbads;Integrated Security=SSPI;Data Source=" + @serverNameDs;
                //
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
                    }
                }

                sconnp.Close();
            }
            catch (Exception e)
            {
                errn++;
                errq = e.ToString();
            }
            //
            return dbreaderb;
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