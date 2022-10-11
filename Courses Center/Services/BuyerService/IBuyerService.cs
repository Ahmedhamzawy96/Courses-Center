using Courses_Center.Models;
using Courses_Center.ViewModels;
using System.Linq.Expressions;

namespace Courses_Center.Services.BuyerService
{
    public interface IBuyerService
    {
        Buyer getOneBuyer(string username, string password);
        Buyer AddBuyer(Buyer B);
        List<Buyer> getOneBuyerRole(Expression<Func<Buyer, bool>> Condition);
        bool CheckUserName(string username);
        public void UpdateDataProfile(Buyer buyer, UProfileViewModel newbuyer);
        public void ChangePassword(Buyer OldPass, ChangePassViewModel newPass);

    }
}
