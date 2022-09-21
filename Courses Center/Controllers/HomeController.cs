using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
