using Courses_Center.Models;
using Courses_Center.Services.Generic_Service;
using System.Data.OleDb;

namespace Courses_Center.Services.Course_Service
{
    public interface ICourseService : IEntityServices<Course>
    {
        IEnumerable<Course> GetDeptCourses(int id);
        bool Update(Course newCrs,Course old );
        List<Course> getallCources(int DeptID);
       
        Course GetOneCourse(int id);
        bool CheckCrsName(string name); 
    }
}
