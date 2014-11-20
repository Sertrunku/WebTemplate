using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Models;
using Template.Core.Repository;
using Template.Data.Infrastructure;

namespace Template.Data.Repository
{
    public class DummyRepository : RepositoryBase<DummyItem>, IDummyRepository
    {
        public DummyRepository(TemplateContext context)
            : base(context)
        {

        }
    }
}
