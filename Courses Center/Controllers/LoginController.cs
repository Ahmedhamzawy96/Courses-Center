using Courses_Center.Models;
using Courses_Center.Services.BuyerService;
using Courses_Center.Services.BuyingCartServices;
using Courses_Center.Services.UserService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Courses_Center.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBuyerService _buyerService;
        private readonly IBuyingCartService _buyingCartService;
        public LoginController(IUserService userService,IBuyerService buyerService,IBuyingCartService buyingCartService)
        {
            _userService = userService;
            _buyerService = buyerService;
            _buyingCartService = buyingCartService;
        }
      
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin([Bind] string username, [Bind] string password)
        {
            // username = anet  
            //     var user = new Users().GetUsers().Where(u => u.UserName == userModel.UserName).SingleOrDefault();
            Admin admin = _userService.getOneAdmin(username, password);
            Buyer buyer = _buyerService.getOneBuyer(username, password);
            if (admin != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("UserName", admin.UserName),
                 //   new Claim("PassWord", admin.Password),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                 };

                var userIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };
                //var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                //HttpContext.SignInAsync(userPrincipal);
                 HttpContext.SignInAsync(

            new ClaimsPrincipal(userIdentity));

                return RedirectToAction("Index", "University");

            }
            else if (buyer != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("UserName", buyer.UserName),
                    new Claim("PassWord", buyer.Password),
                    new Claim(ClaimTypes.Email, buyer.Email),
                   // new Claim("Fname", buyer.Fname),
                   // new Claim("Lname", buyer.Lname),
                    new Claim(ClaimTypes.Role, "Buyer")

                 };
                HttpContext.Session.SetString("username", buyer.UserName);
                HttpContext.Session.SetString("ProCount", _buyingCartService.DisplayBuyingCart(buyer.UserName).Count.ToString());

                var userIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };
                //var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                //HttpContext.SignInAsync(userPrincipal);
                 HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(userIdentity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            });

                return RedirectToAction("Index", "University");

                //HttpContext.SignInAsync(userPrincipal);


            }

            return View();
        }

        [HttpGet]
        public ActionResult UserAccessDenied()
        {
            return View();
        }
    }
}
