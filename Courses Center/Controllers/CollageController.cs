using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    public class CollageController : Controller
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
