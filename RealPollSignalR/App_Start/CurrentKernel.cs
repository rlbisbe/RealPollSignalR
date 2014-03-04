using Ninject;
using RealPollSignalR.Data;
using RealPollSignalR.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RealPollSignalR.App_Start
{
    public class CurrentKernel
    {
        public static IKernel Current { get; set; }


        public static IKernel Init()
        {
            if (Current != null)
            {
                return Current;
            }

            Current = new StandardKernel();

            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["FakeDB"]) == false)
            {
                Current.Bind<IQuestionRepository>().To<FakeQuestionRepository>();
            }
            else
            {
                Current.Bind<IQuestionRepository>().To<DBQuestionRepository>();
            }

            Current.Bind<IMailService>().To<MailService>();
            return Current;
        }
    }
}