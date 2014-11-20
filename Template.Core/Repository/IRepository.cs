using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(params object[] keys);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        void Delete(Expression<Func<TEntity, bool>> where);
    }
}
