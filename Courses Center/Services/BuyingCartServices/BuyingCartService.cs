using Courses_Center.Repositories.BuyerRepositry;
using Courses_Center.Models;

using Courses_Center.Repositories.BuyingCart_Repositry;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Services.BuyingCartServices
{
    public class BuyingCartService: IBuyingCartService
    {
       
        private readonly IBuyingCart _buyerRepositiry;
        public BuyingCartService(IBuyingCart buyerRepositiry)
        {
            _buyerRepositiry = buyerRepositiry;
        }
        public void AddBuyingCart(BuyingCart buyingCart)
        {
            
           
           
            buyingCart.Count = 1;
            buyingCart.Date = DateTime.Now;
           
            _buyerRepositiry.Add(buyingCart);
            _buyerRepositiry.SaveChanges();
        }
        public List<BuyingCart> DisplayBuyingCart(string username)
        {
            var buyingCart = _buyerRepositiry.GetAllWithCondation(u => u.BuyUserName == username && u.ISDeleted==false);
            return buyingCart;
        }
        public List<BuyingCart> DisplayFinishBuyingCart(string username,int Id)
        {
            var buyingCart = _buyerRepositiry.GetAllWithCondation(u => u.BuyUserName == username&&u.SId==Id && u.ISDeleted == true);
            return buyingCart;
        }
        public void UpdateBuyingCart(int id,int count,decimal price )
        {
            var buyingC = _buyerRepositiry.GetAllWithCondation(b=>b.SId==id).FirstOrDefault();
           buyingC.Count = count;
            buyingC.Total = count * price;


            _buyerRepositiry.Update(buyingC);
            _buyerRepositiry.SaveChanges();

        }

       
    }
}
