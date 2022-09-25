using Courses_Center.Models;
using Courses_Center.Models.Entity;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;
using Microsoft.EntityFrameworkCore;

namespace Courses_Center.Repositories.Generic_repositry.GenericRepositry
{
    public abstract class GenericRepositry<T> : IGenericRepositry<T>
               where T : class

    {
        protected CenterContext _entities;
        protected readonly DbSet<T> _dbset;

        public GenericRepositry(IUnitOfWork unitOfWork)
        {
            _entities = unitOfWork.dbContext;
            _dbset = unitOfWork.dbContext.Set<T>();

        }
        public GenericRepositry(CenterContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();

        }

        public T Get(int id)
        {
            return _dbset.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }
        public T Add(T entity)
        {
            return _dbset.Add(entity) as T;
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _dbset.AddRange(entity);
        }

        public void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Detached;
            _entities.Entry(entity).State = EntityState.Modified;
        }
        public void Update(T entity, T oldentity)
        {
            _entities.Entry(oldentity).CurrentValues.SetValues(entity);
        }
        public void Update(IEnumerable<T> entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbset.RemoveRange(entity);
        }




    }
}
