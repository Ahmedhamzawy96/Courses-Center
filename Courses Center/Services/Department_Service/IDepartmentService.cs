using Courses_Center.Models;

namespace Courses_Center.Services.Department_Service
{
    public interface IDepartmentService
    {
        Department Get(int id);
        IEnumerable<Department> GetAll();
        void Add(Department entity);
        void AddRange(IEnumerable<Department> entity);
        void Remove(Department entity);
        void RemoveRange(IEnumerable<Department> entity);
        
    }
}
