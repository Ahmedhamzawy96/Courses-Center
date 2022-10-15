using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;

namespace Courses_Center.Repositories.UserRepositry
{
    
    public class UserRepositiry : GenericRepositry<Admin>, IUserRepositry
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRepositiry(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
           _unitOfWork=unitOfWork;
        }
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
