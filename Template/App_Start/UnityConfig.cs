using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Template.Data.Configuration;
using Template.Domain.Configuration;

namespace Template
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            new DataUnityConfiguration().Configure(container);
            new DomainUnityConfig().Configure(container);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}