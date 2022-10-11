using Courses_Center.Models;
using Courses_Center.Repositories.BuyerRepositry;
using System.Linq.Expressions;

namespace Courses_Center.Services.BuyerService
{
    public class BuyerService:IBuyerService
    {
        private readonly IBuyerRepositiry _buyerRepositiry;

        public BuyerService(IBuyerRepositiry buyerRepositiry)
        {
            _buyerRepositiry = buyerRepositiry;

        }
        public Buyer getOneBuyer(string username, string password)
        {
            return _buyerRepositiry.GetAllWithCondation(a => a.ISDeleted == false && a.UserName == username && a.Password == password).FirstOrDefault();
        }
        public List<Buyer> getOneBuyerRole(Expression<Func<Buyer, bool>> Condition)
        {
            return _buyerRepositiry.GetAllWithCondation(Condition);
        }
        public Buyer AddBuyer(Buyer B)
        {



            _buyerRepositiry.Add(B);
            _buyerRepositiry.SaveChanges();
            return B;
        }
    }
}
