namespace Courses_Center.Services.Generic_Service
{
    public interface IEntityServices<T>:IService
        where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
