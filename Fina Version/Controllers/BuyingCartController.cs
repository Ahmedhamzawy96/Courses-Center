using Courses_Center.Models;
using Courses_Center.Services.BuyingCartServices;
using Courses_Center.Services.SourcesService;
using Courses_Center.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    [Authorize("Buyer")]
    public class BuyingCartController : Controller
    {
        IBuyingCartService _buyingCartService;
        private readonly ISource _source;
        public BuyingCartController(IBuyingCartService buyingCartService,ISource source)
        {
            _buyingCartService = buyingCartService;
            _source = source;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToBuyingCart(int Id,decimal price)
        {
             BuyingCart  buyingCart = new BuyingCart();
            buyingCart.BuyUserName = HttpContext.Session.GetString("username");
            if(buyingCart.BuyUserName==null)
              return RedirectToAction(actionName: "Login", controllerName: "Home");
            buyingCart.SId = Id;
            buyingCart.Total = price;
            _buyingCartService.AddBuyingCart(buyingCart);
            HttpContext.Session.SetString("ProCount", _buyingCartService.DisplayBuyingCart(buyingCart.BuyUserName).Count.ToString());
            return Content("ok");
        }
        public IActionResult Display()
        {
            decimal t = 0;
           List<BuyingCartDto> buyingCartDto= new List<BuyingCartDto>();
           var buyingcart = _buyingCartService.DisplayBuyingCart(HttpContext.Session.GetString("username"));
            int c = 1;
            foreach(var item in buyingcart)
            {
                var source = _source.GetOneSource(item.SId);
                buyingCartDto.Add(new BuyingCartDto(
                    )
                {
                    CartId=item.SId,
                    Id=1,
                    Count = item.Count,
                    Price = source.Price,
                    Title = source.Title,
                    Total = source.Price * item.Count
                }) ;
                c++;
                t += source.Price * item.Count;
            }
            ViewBag.total = t;
            return View(buyingCartDto);
        }

        [HttpPost]
        public void UpdateCount(int Id,int Count,decimal Price)
        {
            _buyingCartService.UpdateBuyingCart(Id,Count, Price);
        }

    }
}
