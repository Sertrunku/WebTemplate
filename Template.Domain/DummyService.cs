using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Common;
using Template.Core.Infrastructure;
using Template.Core.Repository;
using Template.Core.Service;

namespace Template.Domain
{
    public class DummyService : IDummyService
    {
        private IUnitOfWork unitOfWork;
        private IDummyRepository dummyRepository;

        public DummyService(IUnitOfWork unitOfWork, IDummyRepository dummyRepository)
        {
            this.unitOfWork = unitOfWork;
            this.dummyRepository = dummyRepository;
        }

        public IEnumerable<Core.Models.DummyItem> GetAll()
        {
            return dummyRepository.GetAll();
        }

        public Core.Models.DummyItem GetByID(params object[] keys)
        {
            return dummyRepository.GetById(keys);
        }

        public void Create(Core.Models.DummyItem entity)
        {
            dummyRepository.Create(entity);
            SaveChanges();
        }

        public void Update(Core.Models.DummyItem entity)
        {
            dummyRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Core.Models.DummyItem entity)
        {
            dummyRepository.Delete(entity);
            SaveChanges();
        }

        public IEnumerable<Core.Common.ValidationResult> CanAdd(Core.Models.DummyItem entity)
        {
            if (String.IsNullOrEmpty(entity.DummyDescription))
            {
                yield return new ValidationResult("Description cannot be empty");
            }

            //add more validations as needed
        }

        public IEnumerable<Core.Common.ValidationResult> CanDelete(Core.Models.DummyItem entity)
        {
            //add validations before delete
            throw new NotImplementedException();            
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }

        public void Dispose()
        {
            
        }
    }
}
