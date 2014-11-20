using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Common;
using Template.Core.Service;

namespace Template.Domain.Configuration
{
    public class DomainUnityConfig: IUnityConfiguration
    {
        public void Configure(IUnityContainer container)
        {
            container.RegisterType<IDummyService, DummyService>();
        }
    }
}
