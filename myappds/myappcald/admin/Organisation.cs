/*////////////////////////////////////
//* @author: Brian
//* BM 2018
//* Organisation.cs
 *//////////////////////////////////////// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myappcald.admin
{
    public class Organisation
    {
        private int orgcode;
        private string orgname;
        private int pcode;
        private string pname;
        private string info;
        private string ptype;
        private int pbranch;
        private string notes;
        //private int orgcodev;

        public Organisation(int orcode, string orname, int opcode, string opname, string opinfo, string optype, int orbranch, string ornotes)
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
            //orgcodev = 5101;

        }

        
        //

    }
}