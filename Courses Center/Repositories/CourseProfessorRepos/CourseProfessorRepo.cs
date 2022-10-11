using Courses_Center.Models;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;

namespace Courses_Center.Repositories.CourseProfessorRepos
{
    public class CourseProfessorRepo:GenericRepositry<CourseProfessor> , ICourseProfessorRepo
    {

        public CourseProfessorRepo(CenterContext context):base(context)
        {

        }
    }
}
