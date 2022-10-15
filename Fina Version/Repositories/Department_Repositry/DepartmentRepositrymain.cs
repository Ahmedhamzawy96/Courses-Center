using Castle.Core.Internal;
using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;
using Courses_Center.ViewModels;
using Microsoft.EntityFrameworkCore;

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

        public bool CheckDeptName(string name)
        {
            return UnitOfWork.dbContext.Departments.Any(A => A.Name == name);
        }

        public IEnumerable<Department> GetDepartByUniColl(FilterDepartViewModel filter)
        {
            if (filter.CollageID is null || filter.UniverstyID is null
                || filter.CollageID <= 0 || filter.UniverstyID <= 0)
                return null;
            return  _unitOfWork.dbContext.Departments.Where(filt => filt.ColID == filter.CollageID);
        }

        public Department GetDeptWithColUni(int? id)
        {
            if (id == null || id <= 0)
                return null;

            return _unitOfWork.dbContext.Departments.Include(col => col.College).ThenInclude(uni => uni.University).FirstOrDefault(dept => dept.Id == id);
        }

        public void UpdateDepartment(Department old, Department updated)
        {
            _unitOfWork.dbContext.Entry<Department>(old).State = EntityState.Modified;
            old.Name = updated.Name;
            old.ColID = updated.ColID;
            _unitOfWork.Commit();
        }
    }
}
