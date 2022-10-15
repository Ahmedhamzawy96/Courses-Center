using Courses_Center.Models;
using Courses_Center.Repositories.Course_Repository.ICourseRepository;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;

namespace Courses_Center.Repositories.Course_Repository.CourseRepository
{
    public class CourseRepository : GenericRepositry<Course>, ICourseRepositorymain
    {
       

        public CourseRepository(CenterContext Context):base(Context)
        {
        
        }

    }
}
