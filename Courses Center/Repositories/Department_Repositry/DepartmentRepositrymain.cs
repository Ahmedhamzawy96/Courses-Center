using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;

namespace Courses_Center.Repositories.Department_Repositry
{
    public class DepartmentRepositrymain : GenericRepositry<Department>, IDepartmentRepositrymain
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentRepositrymain(IUnitOfWork unit) : base(unit)
        {
            _unitOfWork = unit;
        }
       public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
    }
}
