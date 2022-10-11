using Courses_Center.Models;
using Courses_Center.ViewModels;

namespace Courses_Center.Services.Department_Service
{
    public interface IDepartmentService
    {
        Department GetDeptWithClUni(int? id);
        Department Get(int? id);
        IEnumerable<Department> GetAll();
        void Add(Department entity);
        void AddRange(IEnumerable<Department> entity);
        void Remove(Department entity);
        void RemoveRange(IEnumerable<Department> entity);
        IEnumerable<Department> FilterDepart(FilterDepartViewModel filter);
        bool updateDepart(Department oldDepartment, Department updateDeparmtent);
        IEnumerable<Department> GetColDepts(int id);
        List<Department> getallDepartments(int ColID);
        Department GetOneDepart(int id);


    }
}
