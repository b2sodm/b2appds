/*////////////////////////////////////
//* @author: Brian
//* BM 2018
//* DbSetting.cs
 *////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace myappcald.models
{
    public class DbSetting
    {
        private string dsName;
        private string serverNameDs;
        private string pconnstr;

        public DbSetting()
        {
            var wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal p = new WindowsPrincipal(wi);
            char c = '\\';
            var dname = p.Identity.Name.Split(c);
            var domain = dname[0];
            dsName = "sqlexpress";
            serverNameDs = domain + "\\" + dsName;
            pconnstr = @"User Id=newp4;Password=newp33;Initial Catalog=dbads;Integrated Security=SSPI;Data Source=" + @serverNameDs;
        }

        public string SqlConnStr() => pconnstr;

    }
}