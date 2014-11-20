using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Models;

namespace Template.Data.Infrastructure
{
    public class TemplateContext : DbContext
    {
        public TemplateContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<DummyItem> Dummys { get; set; }
    }
}
