using Courses_Center.Models;

namespace Courses_Center.Services.BuyingCartServices
{
    public interface IBuyingCartService
    {
        void AddBuyingCart(BuyingCart buyingCart);
        List<BuyingCart> DisplayBuyingCart(string username);
        List<BuyingCart> DisplayFinishBuyingCart(string username,int id);
        void UpdateBuyingCart(int id, int count, decimal price);
    }
}
