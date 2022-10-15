using Castle.Core.Internal;
using Courses_Center.Models;
using Courses_Center.Services.BuyerService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Courses_Center.Controllers
{
    public class RegisterationController : Controller
    {
       
        private readonly IBuyerService _buyerService;
        public RegisterationController( IBuyerService buyerService)
        {
            
            _buyerService = buyerService;
        }
        [HttpGet]
        public IActionResult NewUser()
        {
            var claims = HttpContext.Session.GetString("username");
            if (!claims.IsNullOrEmpty())
            {
                HttpContext.Session.Clear();
                HttpContext.Session.Remove(".AspNetCore.Session");
                HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
                HttpContext.SignOutAsync();
                return Redirect("/Login/UserLogin");
            }
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(Buyer B)
        {  
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(NewUser));
            Buyer buyer = _buyerService.AddBuyer(B);

            if (buyer != null)
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
                HttpContext.Session.SetString("ProCount", "0");

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

                return RedirectToAction("Index", "Home");

                //HttpContext.SignInAsync(userPrincipal);


            }

            return View();
        }

        [HttpGet]
        public IActionResult checkUsername(string username)
        {
            bool res = _buyerService.CheckUserName(username);
            return Json(!res);

        }
    }
}
