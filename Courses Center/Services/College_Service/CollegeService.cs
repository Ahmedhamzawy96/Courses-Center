using Courses_Center.Models;
using Courses_Center.Repositories.College_Repositry.ICollegeRepositry;
using Courses_Center.Repositories.General;
using Courses_Center.Services.Generic_Service;

namespace Courses_Center.Services.College_Service
{
    public class CollegeService:EntityService<College>,ICollegeService
    {
        IUnitOfWork _unitOfWork;
        ICollegeRepositrymain _CollegeRepositrymain;
        public CollegeService(ICollegeRepositrymain CollegeRepositrymain, IUnitOfWork unitOfWork) : base(CollegeRepositrymain, unitOfWork) {
            _unitOfWork = unitOfWork;
            _CollegeRepositrymain = CollegeRepositrymain;
        }

    }
}
