using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Ninject;
using Owin;
using RealPollSignalR.App_Start;
using RealPollSignalR.Data;

[assembly: OwinStartup(typeof(RealPollSignalR.Startup))]
namespace RealPollSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Create another dependency resolver that uses the same kernel

            var kernel = new StandardKernel();
            kernel.Bind<IQuestionRepository>().To<DBQuestionRepository>();

            var depencencyResolver = new NinjectDepencencyResolver(kernel);
            //GlobalHost.DependencyResolver = new SignalR;

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}