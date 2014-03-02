using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Hosting;
using System.IO;

namespace RealPollSignalR.Services
{
    public class MailService : IMailService
    {
        public string GenerateEmailBody(Models.Question q)
        {
            string template = string.Empty;
            string templatePath = HostingEnvironment.MapPath(@"~/App_Data/PriceModels.xml");
            using (StreamReader reader = new StreamReader(templatePath))
            {
                template = reader.ReadToEnd();
            }
            return RazorEngine.Razor.Parse(template, q);
        }

        public bool SendMail(string target, string content, int id)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(target));

                // From
                mailMsg.From = new MailAddress("no-reply@realpoll.azurewebsites.net", "Realpoll");

                // Subject and multipart/alternative Body
                mailMsg.Subject = string.Format("Question details for question #{0}", id);
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(content, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["sendgrid:username"], WebConfigurationManager.AppSettings["sendgrid:password"]);
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                return true;
            }
            catch
            {
                //TODO: Log
                return false;
            }
        }
    }
}