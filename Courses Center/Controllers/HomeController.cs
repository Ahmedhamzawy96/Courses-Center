using Courses_Center.Models;
using Courses_Center.Services.University_Service;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUniversityService _universityService;
        public HomeController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        // GET: UniversitiesController
        public ActionResult Index()
        {

            ViewBag.uni1 = _universityService.getallUniversies().Take(3).ToList();
            ViewBag.Uni2 = _universityService.getallUniversies().Skip(3).Take(3).ToList();
            ViewBag.Uni3 = _universityService.getallUniversies().Skip(6).Take(3).ToList();
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult ProfileInfo()
        {
            return PartialView();
        }
        public IActionResult UpdateProfile()
        {
            return PartialView();
        }
        public IActionResult Sources()
        {
            return PartialView();
        }
        
    }
}