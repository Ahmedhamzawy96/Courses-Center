using Courses_Center.Models;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;

namespace Courses_Center.Repositories.BuyingCart_Repositry
{
    public interface IBuyingCart:IGenericRepositry<BuyingCart>
    {
        void SaveChanges();
    }
}
