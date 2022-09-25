using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.University_Repositry.IUniversityRepositry;
using Courses_Center.Services.Generic_Service;

namespace Courses_Center.Services.University_Service
{
    public class UniversityService:EntityService<University>,IUniversityService
    {
        IUnitOfWork _unitOfWork;
        IUniversityRepositrymain _universityRepositry;
        public UniversityService(IUniversityRepositrymain universityRepositry,IUnitOfWork unitOfWork) : base(universityRepositry,unitOfWork) {
            _unitOfWork=unitOfWork;
            _universityRepositry=universityRepositry;

        }

    }
}
