using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Infrastructure;

namespace Template.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private TemplateContext _context;
        public UnitOfWork(TemplateContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
