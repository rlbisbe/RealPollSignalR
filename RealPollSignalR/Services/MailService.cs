using System;
using System.Collections.Generic;
using System.Web.Configuration; 
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace RealPollSignalR.Services
{
    public class MailService : IMailService
    {
        public string GenerateEmailBody(Models.Question q)
        {
            string template =
@"<html>
<body>
Hi:

<p>Here are the details of your question:</p>

<b>Title:</b> @Model.QuestionText

<p><b>Answers:</b></p>
<ul>
@foreach(var answer in Model.Answers) {
    <li>
    @answer.AnswerText
    @if(answer.IsCorrect)
    {
        <b>(Correct)</b>
    }
    </li>
}
</ul>

Get the links from the question <a href=""http://realpoll.azurewebsites.net/Question/Created/@Model.DisplayHash"">details page!!</a>

<div style=""font-size: small"">
<p>Powered by <a href=""http://realpoll.azurewebsites.net"">RealPoll</a></p>
<hr/>
<p>Created by <a href=""http://rlbisbe.net"">@@rlbisbe</a><br/>
Check out what's under the hood on my <a href=""http://rlbisbe.net"">blog</a><br/>
Code available on <a href=""http://rlbisbe.net"">Github</a></p>
</div>
</body>
</html>";
            return RazorEngine.Razor.Parse(template, q);
        }

        public void SendMail(string target, string content)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(target));

                // From
                mailMsg.From = new MailAddress("no-reply@realpoll.azurewebsites.net", "Realpoll");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "subject";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(content, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["sendgrid:username"], WebConfigurationManager.AppSettings["sendgrid:password"]);
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}