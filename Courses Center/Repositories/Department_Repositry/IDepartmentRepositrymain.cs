using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;
using Courses_Center.ViewModels;

namespace Courses_Center.Repositories.Department_Repositry
{
    public interface IDepartmentRepositrymain:IGenericRepositry<Department>
    {
        
        IUnitOfWork UnitOfWork { get; }
        IEnumerable<Department> GetDepartByUniColl(FilterDepartViewModel filter);
        void UpdateDepartment(Department old ,Department updated);
        Department GetDeptWithColUni(int? id);
        bool CheckDeptName(string name);

    }
}
