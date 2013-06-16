using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace HackMW2013.Controllers
{
    public class TreeChat : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}