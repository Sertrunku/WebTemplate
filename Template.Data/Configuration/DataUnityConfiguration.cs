using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Common;
using Template.Core.Infrastructure;
using Template.Core.Repository;
using Template.Data.Infrastructure;
using Template.Data.Repository;

namespace Template.Data.Configuration
{
    public class DataUnityConfiguration : IUnityConfiguration
    {
        public void Configure(IUnityContainer container)
        {
            container.RegisterType<TemplateContext>(new PerResolveLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
            container.RegisterType<IDummyRepository, DummyRepository>();
        }
    }
}
