using Courses_Center.Models;
using Courses_Center.Repositories.Course_Repository.ICourseRepository;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Professor_Repositry;
using Courses_Center.Services.Generic_Service;
using Courses_Center.ViewModels;

namespace Courses_Center.Services.Professor_Service
{
    public class ProfessorService:EntityService<Professor> , IProfessorService
    {

        IUnitOfWork _unitOfWork;
        IProfessorRepository _professorRepository;
        public ProfessorService(IProfessorRepository professorRepository, IUnitOfWork unitOfWork) : base(professorRepository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _professorRepository = professorRepository;

        }
        public List<Professor> getallProfs(int courseId)
        {
            return _professorRepository.GetAllWithCondation(c => c.Courses.Select(cc => cc.Id).FirstOrDefault() == courseId);
        }
        public Professor GetOneProfessor(int id)
        {
            return _professorRepository.Get(id);
        }

        public bool Update(Professor @new, Professor old)
        {
            if (old == null || @new == null)
            {
                throw new ArgumentNullException("entity is null");
            }
            else
            {
                _professorRepository.Update(@new, old);
                _unitOfWork.Commit();
                return true;
            }
        }
       
    }
}
