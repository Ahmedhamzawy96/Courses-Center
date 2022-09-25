using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;

namespace Courses_Center.Repositories.Department_Repositry
{
    public interface IDepartmentRepositrymain:IGenericRepositry<Department>
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
