using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using myappcald.models;

namespace myappcald.hubs
{
    public class ApdisyHub : Hub
    {
        List<string> pmList = new List<string>();
        List<string> orgList = new List<string>();
        List<string> braList = new List<string>();

        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string name, string mess)
        {
            Clients.All.broadcastMessage(name, mess);
            pmList.Add(name + " : " + mess);
        }

        public void SendToGroup(string orgBraGrp, string txt)
        {

        }

        public void Join(string orgBranGrp, string pname, string pcode)
        {

        }

        public void Leave(string orgBranGrp)
        {

        }

        public Task Join(string orgBranGrp)
        {
            return Groups.Add(Context.ConnectionId, orgBranGrp);
        }

        public bool RegisterOrganisation(AppdsOrganisation orgn)
        {
            bool reg = true;

            return reg;
        }

        public bool RegisterBranch(AppdsBranch branchp)
        {
            bool reg = true;

            return reg;
        }
    }
}