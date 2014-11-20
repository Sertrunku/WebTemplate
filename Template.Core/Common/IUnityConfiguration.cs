using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Common
{
    public interface IUnityConfiguration
    {
        void Configure(IUnityContainer container);
    }
}
