using Courses_Center.Models;
using System.Linq.Expressions;

namespace Courses_Center.Services.BuyerService
{
    public interface IBuyerService
    {
        Buyer getOneBuyer(string username, string password);
        Buyer AddBuyer(Buyer B);
        List<Buyer> getOneBuyerRole(Expression<Func<Buyer, bool>> Condition);

    }
}
