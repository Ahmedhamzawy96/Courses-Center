using Courses_Center.Models;
using Courses_Center.Repositories.CourseProfessorRepos;
using Courses_Center.Repositories.General;
using Courses_Center.Services.Generic_Service;

namespace Courses_Center.Services.CourseProfessorService
{
    public class CourseProfessorService:EntityService<CourseProfessor> , ICourseProfessorService
    {
        IUnitOfWork _unitOfWork;
        ICourseProfessorRepo _courseProfessorRepo;

        public CourseProfessorService(ICourseProfessorRepo courseProfessorRepo , IUnitOfWork unitOfWork):base(courseProfessorRepo , unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseProfessorRepo = courseProfessorRepo;
        }   
    }
}
