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
            var dependencyResolver = new NinjectSignalRDependencyResolver(CurrentKernel.Init());
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR(new HubConfiguration()
            {
                EnableDetailedErrors = true,
                Resolver = dependencyResolver
            });
        }
    }
}