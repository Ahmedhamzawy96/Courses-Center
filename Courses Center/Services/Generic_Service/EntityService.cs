using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;

namespace Courses_Center.Services.Generic_Service
{
    public abstract class EntityService<T>: IEntityServices<T> where T : class
    {
        IUnitOfWork _unitOfWork;
        IGenericRepositry<T> _repository;

        public EntityService(IGenericRepositry<T> repository, IUnitOfWork unitOfWork)
        {
            _repository=repository;
            _unitOfWork = unitOfWork;
        }

        public virtual T Get(int id)
        {
            return _repository.Get(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();

        }
        public void AddRange(IEnumerable<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.AddRange(entity);
            _unitOfWork.Commit();
        }

      

        

        public void Remove(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.RemoveRange(entity);
            _unitOfWork.Commit();
        }
    }
}
