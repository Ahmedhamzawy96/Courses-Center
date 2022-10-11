using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;

namespace Courses_Center.Repositories.Professor_Repositry
{
    public class ProfessorRepository:GenericRepositry<Professor> , IProfessorRepository
    {
        public ProfessorRepository(CenterContext context):base(context)
        {
        }

    }
}
