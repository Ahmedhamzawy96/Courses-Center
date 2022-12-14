using Courses_Center.Models;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;

namespace Courses_Center.Repositories.BuyerRepositry
{
    public interface IBuyerRepositiry : IGenericRepositry<Buyer>
    {
        void SaveChanges();
        bool CheckUserName(string username);

    }
}
