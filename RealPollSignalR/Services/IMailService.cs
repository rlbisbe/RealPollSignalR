using RealPollSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealPollSignalR.Services
{
    public interface IMailService
    {
        string GenerateEmailBody(Question q);
        void SendMail(string target, string body);
    }
}