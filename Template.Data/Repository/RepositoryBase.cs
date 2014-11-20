using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Repository;
using Template.Data.Infrastructure;

namespace Template.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private TemplateContext _context;
        private readonly IDbSet<T> dbset;

        public RepositoryBase(TemplateContext context)
        {
            this._context = context;
            dbset = context.Set<T>();
        }

        public virtual T GetById(params object[] keys)
        {
            return dbset.Find(keys);
        }

        public virtual void Create(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }


        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public virtual T Get(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public virtual void Delete(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }
    }
}
