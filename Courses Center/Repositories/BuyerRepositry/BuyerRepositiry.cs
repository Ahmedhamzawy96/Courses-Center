using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;

namespace Courses_Center.Repositories.BuyerRepositry
{
    public class BuyerRepositiry:GenericRepositry<Buyer>,IBuyerRepositiry
    {
        private readonly IUnitOfWork _unitOfWork;
        public BuyerRepositiry(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
        public bool CheckUserName(string username)
        {
            bool res = _entities.Buyers.Any(buy => buy.UserName == username);
            return res;
        }
    }
}
