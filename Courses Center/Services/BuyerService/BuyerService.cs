using Courses_Center.Models;
using Courses_Center.Repositories.BuyerRepositry;
using Courses_Center.ViewModels;
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

        public bool CheckUserName(string username)
        {
            return _buyerRepositiry.CheckUserName(username);
        }
        public void UpdateDataProfile(Buyer buyer, UProfileViewModel newbuyer)
        {
            try
            {
                buyer.Fname = newbuyer.FnameProfile;
                buyer.Lname = newbuyer.LnameProfile;
                buyer.Email = newbuyer.EmailProfile;
                _buyerRepositiry.Update(buyer);
                _buyerRepositiry.SaveChanges();
            }
            catch { }
        }
        public void ChangePassword(Buyer OldPass, ChangePassViewModel NewPass)
        {
            try
            {
                OldPass.Password = NewPass.NewPassword;
                _buyerRepositiry.Update(OldPass);
                _buyerRepositiry.SaveChanges();
            }
            
            catch { }
        }
    }
}
