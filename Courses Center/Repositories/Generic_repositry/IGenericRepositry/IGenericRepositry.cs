namespace Courses_Center.Repositories.Generic_repositry.IGenericRepositry
{
    public interface IGenericRepositry<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Update(T entity);
        void Update(IEnumerable<T> entity);
        void Update(T entity, T oldentity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
