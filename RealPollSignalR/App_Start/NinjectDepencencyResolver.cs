using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Syntax;
namespace RealPollSignalR.App_Start
{
    public class NinjectDepencencyResolver : Microsoft.AspNet.SignalR.DefaultDependencyResolver, IDependencyResolver 
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDepencencyResolver(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }
}