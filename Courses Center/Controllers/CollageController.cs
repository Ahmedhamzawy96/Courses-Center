using Courses_Center.Services.College_Service;
using Courses_Center.Services.University_Service;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    public class CollageController : Controller
    {
        ICollegeService _CollegeService;
        IUniversityService _UniversityService;
        public CollageController(ICollegeService CollegeService, IUniversityService UniversityService) {
            _CollegeService= CollegeService;
            _UniversityService= UniversityService;
        }
        public IActionResult Index()
        {
            _UniversityService.GetAll();
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
