using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using CIS598PROJECT.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;

namespace CIS598PROJECT.Controllers
{
    public class ChatHub : Hub
    {
        BTBDatabaseEntities2 db = new BTBDatabaseEntities2();
        public void Send(string name, string message)
        {
            if (message != null && !message.Equals("") && !message.Equals("\n"))
            {
                MessageBoard mb = new MessageBoard();
                mb.Date = DateTime.UtcNow;
                mb.Description = message;
                mb.SubmittedBy = name;
                mb.Id = db.MessageBoards.Count() + 1;
                mb.Type = "chat";
                db.MessageBoards.Add(mb);
                db.SaveChanges();
                Clients.All.addNewMessageToPage(name, message);
            }
        }
    }
}