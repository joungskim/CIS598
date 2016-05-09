using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace CIS598PROJECT.Controllers
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            if(message != null && !message.Equals("") && !message.Equals("\n"))
                Clients.All.addNewMessageToPage(name, message);
        }
    }
}