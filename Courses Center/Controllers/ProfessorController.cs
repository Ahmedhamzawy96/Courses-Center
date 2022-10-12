using Courses_Center.Models;
using Courses_Center.Services.College_Service;
using Courses_Center.Services.Course_Service;
using Courses_Center.Services.CourseProfessorService;
using Courses_Center.Services.Department_Service;
using Courses_Center.Services.Professor_Service;
using Courses_Center.Services.University_Service;
using Courses_Center.ViewModels;
using Courses_Center.ViewModels.Extentsion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProfessorController : Controller
    {
        IUniversityService _universityService;
        ICollegeService _collegeService;
        IDepartmentService _departmentService;
        ICourseService _courseService;
        IProfessorService _professorService;
        ICourseProfessorService _CourseProfessorService;
        public ProfessorController(IUniversityService universityService , 
                                    ICollegeService collegeService ,
                                    IDepartmentService departmentService ,
                                    ICourseService courseService , 
                                    IProfessorService professorService,
                                    ICourseProfessorService courseProfessorService)
        {
            _universityService = universityService;
            _collegeService = collegeService;
            _departmentService = departmentService;
            _courseService = courseService;
            _professorService = professorService;
            _CourseProfessorService = courseProfessorService;
        }
        public IActionResult Index()
        {
            var uni = _universityService.GetAll();
            ViewBag.Universities = uni;
            return View();
        }
        [HttpGet]
        public IActionResult ChangeDeptID(int DeptID)
        {
            if (DeptID == 0)
                return RedirectToAction(nameof(Index));
            var deptItems = _courseService.GetAll().Where(A => A.DeptID == DeptID && A.ISDeleted == false).ToList();
            return Ok(deptItems);
        }

        [HttpPost]
        public IActionResult DisplayProfessors(ProfessorDisplay Prof)
        {
            if (!ModelState.IsValid )
                return RedirectToAction("Index");
            var crsProf = _CourseProfessorService.GetAll().Where(A => A.CrsId == Prof.CrsID).ToList();
            var Profess = new List<Professor>();
            foreach (var item in crsProf)
            {
                Profess.Add(_professorService.Get(item.ProfId));
            }
            return PartialView("DisplayProfessors", Profess);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var uni = _universityService.GetAll();
            ViewBag.Universities = uni;
            return View();
        }

        public IActionResult Add(ProfessorDTO professorDTO )
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Add");
            Professor Prof = professorDTO.DTOToProfessor();
            _professorService.Add(Prof);
            CourseProfessor coursProf = new CourseProfessor() { ProfId = Prof.Id, CrsId = (int)professorDTO.CrsId };
            _CourseProfessorService.Add(coursProf);
            return RedirectToAction(nameof(Add));
            //return PartialView("CourseDisplay", _professorService.GetAll());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == 0 ) 
                return RedirectToAction(nameof(Index));
            var prof = _professorService.Get(id);
            var CrsProf = _CourseProfessorService.Get(id);
            _professorService.Remove(prof);
            _CourseProfessorService.Remove(CrsProf);
            return  RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edite(int id)
        {
            var uni = _universityService.GetAll();
            ViewBag.Universities = uni;
            var cols = _collegeService.GetAll();
            ViewBag.Cols = cols;
            var departs = _departmentService.GetAll();
            ViewBag.Depts = departs;
            var cours = _collegeService.GetAll();
            ViewBag.Cors = cours;


            if (id == 0)
            {
                return RedirectToAction("Index");

            }
            else
            {
                var CorsProf = _CourseProfessorService.GetAll().Where(A => A.ProfId == id).FirstOrDefault();
                var cors = _courseService.Get(CorsProf.CrsId);
                var dept = _departmentService.Get(cors.DeptID);
                var col = _collegeService.Get(dept.ColID);
                var prof = _professorService.Get(id).ProfessorToDTO();
                prof.UniID = col.UniID;
                prof.ColID = col.Id;
                prof.DeptID = dept.Id;
                prof.CrsId = cors.Id;
                return View(prof);
            }


        }

        [HttpPost]

        public IActionResult Edite( int id , ProfessorDTO professorDTO)
        {
            if (!ModelState.IsValid || id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var old = _professorService.Get(id);
                if (old == null)
                    return RedirectToAction("Index");
                try
                {

                    _professorService.Update(professorDTO.DTOToProfessor(), old);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
        }
    }
}
