using Castle.Core.Internal;
using Courses_Center.Models;
using Courses_Center.Services.College_Service;
using Courses_Center.Services.Department_Service;
using Courses_Center.Services.University_Service;
using Courses_Center.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Courses_Center.Controllers
{
    [Authorize(Roles = "Admin,Owner")]
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

        [HttpGet]
                [Authorize(Roles = "Admin,Owner")]
        public IActionResult Index()
        {
            var universtyItems = _UniversityService.GetUniverstyNotDelete().ToList();
            ViewData["Universities"] = universtyItems;
            
            //if (universtyItems.Count > 0)
            //{
            //    var collageItems = _CollegeService.filterCollegesByUni(universtyItems[0].Id)?.ToList();
            //    ViewData["collages"] = collageItems;
            //}
            //else
            //    ViewData["collages"] = null;

            return View();
        }

        [HttpGet]
                [Authorize(Roles = "Admin,Owner")]
        public IActionResult ChangeUniversty(int? UniverstyID)
        {
            if (UniverstyID is null || UniverstyID <= 0)
                return NoContent();
            var collageItems = _CollegeService.filterCollegesByUni(UniverstyID)?.ToList();
            return Ok(collageItems);
        }

        [HttpPost]
                [Authorize(Roles = "Admin,Owner")]
        public IActionResult DisplayDepartment( FilterDepartViewModel Modelfilter)
        {
            //Modelfilter.CollageID = null;
            if (Modelfilter.CollageID is null || Modelfilter.UniverstyID is null
                || Modelfilter.CollageID <= 0 || Modelfilter.UniverstyID <= 0)
            {
                return PartialView(nameof(DisplayDepartment), null);
            }
            return PartialView("DisplayDepartment",_departmentService.FilterDepart(Modelfilter).ToList());
        }
        [HttpGet]
                [Authorize(Roles = "Admin,Owner")]
        public IActionResult Add()
        {

            
            var universtyItems = _UniversityService.GetUniverstyNotDelete().ToList();
            ViewData["Universities"] = universtyItems;
            if (universtyItems.Count > 0)
            {
                var collageItems = _CollegeService.filterCollegesByUni(universtyItems[0].Id)?.ToList();
                ViewData["collages"] = collageItems;
            }
            else
                ViewData["collages"] = null;

            return View();
        }
        [HttpPost]
                [Authorize(Roles = "Admin,Owner")]
        public IActionResult AddDepartment(Department newDepartment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Add));
                }
                _departmentService.Add(newDepartment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Add));
            }
        }

        [HttpGet]
                [Authorize(Roles = "Admin,Owner")]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
                    return NoContent();
                //return RedirectToAction(nameof(Index));
            var res = _departmentService.GetDeptWithClUni(id);
            if (res == null)
                return RedirectToAction(nameof(Index));
            var universtyItems = _UniversityService.GetUniverstyNotDelete().ToList();
            ViewData["Universities"] = universtyItems;
            var collageItems = _CollegeService.filterCollegesByUni(res.College.University.Id)?.ToList();
            ViewData["collages"] = collageItems;
            return View(res);
        }
        [HttpPost]
                [Authorize(Roles = "Admin,Owner")]
        public IActionResult EditDepartment(int id, Department updateDepartment)
        {
            if (!ModelState.IsValid || id <= 0)
            {
               
                return RedirectToAction(nameof(Edit));
            }
            try
            {
               var old = _departmentService.GetDeptWithClUni(id);
                if(old==null)
                    return View(nameof(Index));

                var ok =  _departmentService.updateDepart(old,updateDepartment);
                if (ok)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Edit));
                }
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }


        [HttpGet]
                [Authorize(Roles = "Admin,Owner")]
        public IActionResult Delete(int? id)
        {
            var depart = _departmentService.Get(id);
            if (depart == null)
                return NoContent();
            _departmentService.Remove(depart);
            return RedirectToAction("Index");
        }
        [HttpGet]
                [Authorize(Roles = "Admin,Owner")]
        public IActionResult checkDeptname(string Name)
        {
            return Json(!_departmentService.checkDepart(Name));
        }
    }
}
