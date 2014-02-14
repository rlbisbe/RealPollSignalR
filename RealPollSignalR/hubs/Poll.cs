using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace RealPollSignalR
{
    public class Poll : Hub
    {
        public void Vote(string name, int questionId, int option)
        {
            Clients.All.castVote(name, questionId, option);
        }
    }
}