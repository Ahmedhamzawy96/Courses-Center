using System.Linq;
using Courses_Center.Models;
using Courses_Center.Services.College_Service;
using Courses_Center.Services.Department_Service;
using Courses_Center.Services.University_Service;
using Courses_Center.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
 
    public class UniversityController : Controller
    {

        private readonly IUniversityService _iUni;
        private readonly ICollegeService _collegeServices;
        private readonly IDepartmentService _departmentService;
        public UniversityController(IUniversityService Iuni, ICollegeService collegeServices, IDepartmentService departmentService)
        {
            this._iUni = Iuni;
            this._collegeServices = collegeServices;
            this._departmentService = departmentService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var univs = _iUni.GetAll().ToList();
            return View(univs);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            ViewBag.name = "Add";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(University university)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.name = "Add";
                return View();
            }
            _iUni.AddbyName(university.Name);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        
        public IActionResult update(int id)
        {
            try
            {
                ViewBag.name = "updatePost";
                var univer = _iUni.Get(id);
                if (univer == null)
                    return RedirectToAction(nameof(Index));
                return View(univer);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        
        public IActionResult updatePost(int universityID, University university)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var univer = _iUni.Get(universityID);
                    if (univer == null)
                        return RedirectToAction(nameof(Index));
                    univer.Name = university.Name;
                    var check = _iUni.updateUniversity(univer);
                    if(check==0)
                    {
                        return RedirectToAction(nameof(update));
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
               
            }
            else
            {
                return RedirectToAction(nameof(update));
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            try
            {
                var univer = _iUni.Get(id);
                if (univer == null)
                    return RedirectToAction(nameof(Index));
                _iUni.Remove(univer);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CheckNameUni(string Name)
        {
            bool res = _iUni.CheckNameUni(Name);
            return Json(!res);

        }
        
        public ActionResult Universities()
        {

            List<University> universities = _iUni.getallUniversies();
            return View(universities);
        }
        [HttpPost]
        public ActionResult Universities(string search)
        {

            List<University> universities = _iUni.SearchUniversites(search);
            return View(universities);
        }
        List<Department> D = new List<Department>();
        List<Department> departments = new List<Department>();
        CollageDepts collageDepts = new CollageDepts();
        
        public ActionResult Details(int Id)
        {

            List<College> colleges = _collegeServices.getallCollege(Id);
            foreach (var c in colleges)
            {
                departments = _departmentService.getallDepartments(c.Id);
                collageDepts.collegdpts.Add(c, departments);


            }
            //University u = new University();
            //u = _iUni.GetOneUniversity(Id);
            //collageDepts.uniName = u.Name;
            // ViewBag.Name = _universityService.GetOneUniversity(Id).Name.ToString();
            return View(collageDepts);
        }
        public IActionResult Search(string wordSearch)
        {
            var university = _iUni.SearchUniversites(wordSearch).ToList();
            if(university.Count > 0)
                return Ok(university);
            return NoContent();
        }
    }
}
