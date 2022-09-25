using Courses_Center.Models;
using Courses_Center.Repositories.Department_Repositry;

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

        public  Department Get(int id)
        {
            return _departmentRepM.Get(id);
        }
        public  IEnumerable<Department> GetAll()
        {
            return _departmentRepM.GetAll();

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
    }
}
