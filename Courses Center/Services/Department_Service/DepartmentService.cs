using Courses_Center.Models;
using Courses_Center.Repositories.Department_Repositry;
using Courses_Center.ViewModels;

namespace Courses_Center.Services.Department_Service
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepositrymain _departmentRepM;

        public DepartmentService(IDepartmentRepositrymain DepartmentRepM)
        {
            _departmentRepM = DepartmentRepM;
        }

        public void Add(Department entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _departmentRepM.Add(entity);
            _departmentRepM.UnitOfWork.Commit();
        }

        public void AddRange(IEnumerable<Department> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _departmentRepM.AddRange(entity);
            _departmentRepM.UnitOfWork.Commit();
        }

        public  Department GetDeptWithClUni(int? id)
        {
            if (id == null)
                return null;
            return _departmentRepM.GetDeptWithColUni(id);
        }
        public  IEnumerable<Department> GetAll()
        {
            return _departmentRepM.GetAll();

        }

        public IEnumerable<Department> FilterDepart(FilterDepartViewModel filter)
        {
            if (filter.CollageID is null || filter.UniverstyID is null
                || filter.CollageID <= 0 || filter.UniverstyID <= 0)
                return null;
                return _departmentRepM.GetDepartByUniColl(filter);
        }

        public void Remove(Department entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _departmentRepM.Remove(entity);
            _departmentRepM.UnitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<Department> entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _departmentRepM.RemoveRange(entity);
            _departmentRepM.UnitOfWork.Commit();
        }

        public bool updateDepart(Department oldDepartment,Department updateDeparmtent)
        {
            if (updateDeparmtent == null||oldDepartment==null) throw new ArgumentNullException("entity is null");

            _departmentRepM.UpdateDepartment(oldDepartment, updateDeparmtent);

            return true;
        }

        public Department Get(int? id)
        {
            if (id == null)
                return null;
            return _departmentRepM.Get((int)id);
        }

        public IEnumerable<Department> GetColDepts(int id)
        {
            if (id == 0 )
            {
                throw new Exception("Id of Collage Can't be Zero");
            }
            else
            {
                return _departmentRepM.GetAll().Where(A => A.ColID == id && A.ISDeleted == false).ToList();
            }
        }
        public List<Department> getallDepartments(int ColID)
        {
            return _departmentRepM.GetAllWithCondation(c => c.ColID == ColID);
        }
        public Department GetOneDepart(int id)
        {
            return _departmentRepM.Get(id);
        }
       
       
    }
}
