﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace myappcald.hubs
{
    public class ApdisyHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string name, string mess)
        {
            Clients.All.broadcastMessage(name, mess);
        }
    }
}