using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Syntax;
using Microsoft.AspNet.SignalR;
namespace RealPollSignalR.App_Start
{
    public class NinjectSignalRDepencencyResolver : DefaultDependencyResolver 
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectSignalRDepencencyResolver(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public override object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType) ?? base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType).Concat(base.GetServices(serviceType));
        }
    }
}