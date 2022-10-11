using Courses_Center.Models;
using Courses_Center.Repositories.Course_Repository.ICourseRepository;
using Courses_Center.Services.College_Service;
using Courses_Center.Services.Course_Service;
using Courses_Center.Services.Department_Service;
using Courses_Center.Services.University_Service;
using Courses_Center.ViewModels;
using Courses_Center.ViewModels.Extentsion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace Courses_Center.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        ICourseService _CourseService;
        IUniversityService _UniversityService;
        ICollegeService _Collageservice;
        IDepartmentService _departmentService;



        public CourseController(ICourseService courseService, 
                                IUniversityService universityService, 
                                ICollegeService collegeService, 
                                IDepartmentService departmentService)
        {
            _CourseService = courseService;
            _UniversityService = universityService;
            _Collageservice = collegeService;
            _departmentService = departmentService;
        }

        
        public IActionResult Index()
        {
            var uni = _UniversityService.GetAll();
            ViewBag.Universities = uni;
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            var uni = _UniversityService.GetAll();
            ViewBag.Universities = uni;
            return View();
        }

        [HttpPost]
        public IActionResult Add(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Add");
            _CourseService.Add(courseDTO.DTOToCourse());
            return PartialView("CourseDisplay", _CourseService.GetDeptCourses(courseDTO.DeptID));

        }

        [HttpGet]
        public IActionResult ChangeUniversty(int UniID)
        {
            if (UniID == 0)
                return RedirectToAction(nameof(Index));
            var collageItems = _Collageservice.filterCollegesByUni(UniID);
            return Ok(collageItems);
        }

        [HttpGet]
        public IActionResult ChangeCollage(int ColID)
        {
            if (ColID == 0)
                return RedirectToAction(nameof(Index));
            return Ok(_departmentService.GetColDepts(ColID));
        }

        [HttpPost]
        public IActionResult DisplayCourses(CourseDisplay Course)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            return PartialView("CourseDisplay", _CourseService.GetDeptCourses(Course.DeptID));
        }

        [HttpGet]
        public IActionResult Edite(int id)
        {
            var uni = _UniversityService.GetAll();
            ViewBag.Universities = uni;
            var cols = _Collageservice.GetAll();
            ViewBag.Cols = cols;
            var departs = _departmentService.GetAll();
            ViewBag.Depts = departs;

            if ( id != 0)
            {
                var cors = _CourseService.Get(id).CourseToDTO();
                var dept = _departmentService.Get(cors.DeptID);
                var col = _Collageservice.Get(dept.ColID);
                cors.ColID = col.Id;
                cors.UniID = col.UniID;
                return View(cors);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]

        public IActionResult Edite(int id,CourseDTO courseDTO)
        {
            if(!ModelState.IsValid || id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var old = _CourseService.Get(id);
                if (old == null)
                    return RedirectToAction("Index");
                try
                {

                    _CourseService.Update(courseDTO.DTOToCourse(), old);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return  RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cors = _CourseService.Get(id);
            if(cors == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _CourseService.Remove(cors);
            }

            return   RedirectToAction("Index");
        }


    }
}
