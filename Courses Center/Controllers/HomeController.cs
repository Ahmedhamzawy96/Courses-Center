using Courses_Center.Models;
using Courses_Center.Services.BuyerService;
using Courses_Center.Services.SourcesService;
using Courses_Center.Services.University_Service;
using Courses_Center.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUniversityService _universityService;
        private readonly IBuyerService _buyerServices;
        private readonly ISource _source;

        public HomeController(
            IUniversityService universityService
            , IBuyerService buyerService 
            , ISource source)
        {
            _universityService = universityService;
            _buyerServices = buyerService;
            _source = source;
        }

        // GET: UniversitiesController
        public ActionResult Index()
        {

            ViewBag.uni1 = _universityService.getallUniversies().Take(3).ToList();
            ViewBag.Uni2 = _universityService.getallUniversies().Skip(3).Take(3).ToList();
            ViewBag.Uni3 = _universityService.getallUniversies().Skip(6).Take(3).ToList();
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            var claims = User.Claims.ToList();
            var username = claims[0].Value;
            var password = claims[1].Value;
            if (claims[3].Value == "Admin")
            {
                return NoContent();
            }
            var user = _buyerServices.getOneBuyer(username, password);
            return View(user);
        }
        [Authorize]
        public IActionResult ProfileInfo()
        {
            var claims = User.Claims.ToList();
            var username = claims[0].Value;
            var password = claims[1].Value;

            var user = _buyerServices.getOneBuyer(username, password);

            return PartialView(user);
        }
        [Authorize]
        public IActionResult UpdateProfile()
        {
            var claims = User.Claims.ToList();
            var username = claims[0].Value;
            var password = claims[1].Value;
            if (claims[3].Value == "Admin")
            {
                return NoContent();
            }
            ViewData["BuyerOld"] = _buyerServices.getOneBuyer(username, password);
            return View("UpdateProfile");
        }
        [Authorize]
        [HttpPost]
        public IActionResult UpdateProfile(UProfileViewModel model, string UserName, string Password)
        {
            if (ModelState.IsValid)
            {

                var user = _buyerServices.getOneBuyer(UserName, Password);
                if (user == null)
                    return RedirectToAction(nameof(Profile));
                _buyerServices.UpdateDataProfile(user, model);
            }
            return RedirectToAction(nameof(Profile));
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            var claims = User.Claims.ToList();
            if (claims[3].Value == "Admin")
            {
                return NoContent();
            }
            return View("ChangePassword");
        }

        [HttpPost]

        public IActionResult ChangePassword(ChangePassViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ChangePassword");
            }
            else
            {
                var claims = User.Claims.ToList();
                var username = claims[0].Value;
                var password = claims[1].Value;
                var user = _buyerServices.getOneBuyer(username, password);
                if (user == null || user?.Password != model.OldPassword)
                    return NoContent();
                _buyerServices.ChangePassword(user, model);
                return RedirectToAction(nameof(Profile));

            }
        }
        public IActionResult Sources()
        {
            var claims = User.Claims.ToList();
            var username = claims[0].Value;
            var Sources = _source.getallSourceForBuyer(username).ToList();
            return View(Sources);
        }
        
    }
}