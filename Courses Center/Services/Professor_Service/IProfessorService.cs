using Courses_Center.Models;
using Courses_Center.Repositories.Course_Repository.ICourseRepository;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Professor_Repositry;
using Courses_Center.Services.Generic_Service;
using Courses_Center.ViewModels;

namespace Courses_Center.Services.Professor_Service
{
    public interface IProfessorService : IEntityServices<Professor>
    {
         List<Professor> getallProfs(int courseId);

         Professor GetOneProfessor(int id);
        bool Update(Professor @new, Professor old);
        bool checkProfName(string name);


    }
}
