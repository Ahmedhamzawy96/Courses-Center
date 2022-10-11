using Courses_Center.Models;
using Courses_Center.Repositories.Course_Repository.ICourseRepository;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.University_Repositry.IUniversityRepositry;
using Courses_Center.Services.Generic_Service;
using Courses_Center.ViewModels;

namespace Courses_Center.Services.Course_Service
{
    public class CourseService:EntityService<Course> , ICourseService
    {
        IUnitOfWork _unitOfWork;
        ICourseRepositorymain _CourseRepositoryMain;
        public CourseService(ICourseRepositorymain courseRepositorymain, IUnitOfWork unitOfWork) : base(courseRepositorymain, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _CourseRepositoryMain = courseRepositorymain;

        }

        public bool Update(Course newCrs , Course old )
        {
            if( old == null || newCrs == null)
            {
                throw new ArgumentNullException("entity is null");
            }
            else
            {
                _CourseRepositoryMain.Update(newCrs , old);
                _unitOfWork.Commit();
                return true;
            }
        }

        IEnumerable<Course> ICourseService.GetDeptCourses(int id)
        {
            if(id == 0)
            {
                throw new Exception("Id of department Can't be zero");

            } 
            else
            {
                 return _CourseRepositoryMain.GetAll()
                .Where(A => A.DeptID == id && A.ISDeleted == false).ToList();
            }
        }
        public List<Course> getallCources(int DeptID)
        {
            return _CourseRepositoryMain.GetAllWithCondation(c => c.DeptID == DeptID);
        }
        public Course GetOneCourse(int id)
        {
            return _CourseRepositoryMain.Get(id);
        }

      
       
    }
}
