using Courses_Center.Services.College_Service;
using Courses_Center.Services.Department_Service;
using Courses_Center.Services.University_Service;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService _departmentService;
        ICollegeService _CollegeService;
        IUniversityService _UniversityService;
        public DepartmentController(
            ICollegeService CollegeService, IUniversityService UniversityService,
            IDepartmentService DepartmentService)
        {
            _CollegeService = CollegeService;
            _UniversityService = UniversityService;
            _departmentService = DepartmentService;
        }
        public IActionResult Index()
        {
            ViewData["Universities"] = _UniversityService.GetAll();
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }


    }
}
