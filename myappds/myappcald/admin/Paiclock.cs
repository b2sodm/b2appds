/*////////////////////////////////////
//* @author: Brian
//* BM 2018
//* Paiclock.cs
 *//////////////////////////////////////// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myappcald.admin
{
    public class Paiclock
    {
        public string Ptime()
        {
            string dtime = DateTime.Now.TimeOfDay.ToString();
            return dtime;
        }

        public string Pday()
        {
            string dday = DateTime.Now.DayOfWeek.ToString();
            return dday;
        }

        public string Pdate()
        {
            string ddate = DateTime.Now.Date.ToString();
            return ddate;
        }

        public long Plticks()
        {
            long lpt = DateTime.Now.Ticks;
            return lpt;
        }

        public string Pmessage()
        {
            string[] dmessage = {
                "The only reason for time, is that things don't happen all at the same time.",
                "To be or not to be.",
                "In search for something, one find something else.",
                "Let there be light.",
                "The speed of light is: 299,792,458 m/s.",
                "Welcome to the linguistic world.",
                "Do something and do it well."
            };
            int dl = dmessage.Length;
            Random rd = new Random();
            int p = rd.Next(0, dl);
            return dmessage[p];
        }
    }
}