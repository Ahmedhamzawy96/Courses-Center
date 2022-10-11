using Courses_Center.Models;
using Courses_Center.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            List<Admin> admin = _userService.getallAdmins();

            return View(admin);
        }
        public IActionResult Details(string User_Type)
        {

            List<Admin> admin = _userService.getallAdmins();

            return View("Index", admin);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Admin A)
        {
            _userService.AddAdmin(A);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string UserName)
        {
            _userService.removeAdmin(UserName);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(string UserName)
        {
            Admin A = _userService.GetOneAdmin(UserName);
            return View(A);
        }
        [HttpPost]
        public IActionResult Update(Admin A)
        {
            _userService.updateAdmin(A);
            return RedirectToAction("Index");
        }

    }
}
