using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(myappcald.hubs.Startup))]

namespace myappcald.hubs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //
            app.MapSignalR();
        }
    }
}
