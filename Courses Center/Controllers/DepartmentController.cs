using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }


    }
}
