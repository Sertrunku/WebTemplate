using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Common;

namespace Template.Core.Service
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetByID(params object[] keys);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<ValidationResult> CanAdd(TEntity entity);

        IEnumerable<ValidationResult> CanDelete(TEntity entity);

        void SaveChanges();
    }
}
