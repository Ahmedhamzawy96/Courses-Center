using Courses_Center.Models;
using Courses_Center.Services.College_Service;
using Courses_Center.Services.Course_Service;
using Courses_Center.Services.CourseProfessorService;
using Courses_Center.Services.Department_Service;
using Courses_Center.Services.Professor_Service;
using Courses_Center.Services.SourcesService;
using Courses_Center.Services.University_Service;
using Courses_Center.ViewModels;

using Courses_Center.ViewModels.Extentsion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Courses_Center.Controllers
{
   
    public class SourceController : Controller
    {

        private readonly IUniversityService _universityService;
        private readonly ICollegeService _collegeServices;
        private readonly IDepartmentService _departmentService;
        private readonly ICourseService _courcesService;
        private readonly IProfessorService _profService;
        private readonly ISource _source;
        private readonly ICourseProfessorService _courseProfessorService;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public SourceController(IUniversityService universityService,
                    ICollegeService collegeServices,
                    IDepartmentService departmentService, 
                    ICourseService courcesService, 
                    IProfessorService profService, 
                    ISource source, 
                    IWebHostEnvironment webHostEnvironment,
                    ICourseProfessorService courseProfessorService
            )
        {
            _universityService = universityService;
            _collegeServices = collegeServices;
            _departmentService = departmentService;
            _courcesService = courcesService;
            _profService = profService;
            _source = source;
            _webHostEnvironment = webHostEnvironment;
            _courseProfessorService = courseProfessorService;
        }

        List<University> universities;
        List<College> Colleges;
        List<Department> departmentsList;
        List<Course> CoursesList;
        List<Professor> prodList;
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {

            universities = _universityService.GetAll().ToList();




            ViewBag.universities = new SelectList(universities, "Id", "Name");

            return View();
        }
        //public void unversity(int Id)
        //{
        //    Colleges = _collegeServices.getallCollege(Id);
        //    ViewBag.colleges = new SelectList(Colleges, "Id", "Name");

        //}


        [HttpPost]
        public async Task<List<Tuple<int, string>>> unversity(int Id)
        {

            Colleges = _collegeServices.filterCollegesByUni(Id).ToList();
            List<string> names = Colleges.Select(x => x.Name).ToList();
            List<int> Ids = Colleges.Select(x => x.Id).ToList();
            List<Tuple<int, string>> mylist = new List<Tuple<int, string>>();
            //   mylist.Add(new Tuple<int, string>() { Id, names });
            for (int i = 0; i < names.Count; i++)
            {
                mylist.Add(new Tuple<int, string>(Ids[i], names[i]));
            }
            return mylist;
        }
        [HttpPost]
        public async Task<List<Tuple<int, string>>> departments(int Id)
        {
            FilterDepartViewModel filterDepartViewModel = new FilterDepartViewModel();
           
            departmentsList = _departmentService.getallDepartments(Id);
            List<string> names = departmentsList.Select(x => x.Name).ToList();
            List<int> Ids = departmentsList.Select(x => x.Id).ToList();
            List<Tuple<int, string>> mylist = new List<Tuple<int, string>>();
            //   mylist.Add(new Tuple<int, string>() { Id, names });
            for (int i = 0; i < names.Count; i++)
            {
                mylist.Add(new Tuple<int, string>(Ids[i], names[i]));
            }
            return mylist;

        }
        [HttpPost]
        public async Task<List<Tuple<int, string>>> courses(int Id)
        {
            CoursesList = _courcesService.getallCources(Id);
            List<string> names = CoursesList.Select(x => x.Name).ToList();
            List<int> Ids = CoursesList.Select(x => x.Id).ToList();
            List<Tuple<int, string>> mylist = new List<Tuple<int, string>>();
            //   mylist.Add(new Tuple<int, string>() { Id, names });
            for (int i = 0; i < names.Count; i++)
            {
                mylist.Add(new Tuple<int, string>(Ids[i], names[i]));
            }
            return mylist;
        }
        [HttpPost]
        public async Task<List<Tuple<int, string>>> Profs(int Id)
        {
            //var crsProf = _courseProfessorService.GetAll().Where(A => A.CrsId == Id).ToList();
            var Profess = new List<Professor>();
            //foreach (var item in crsProf)
            //{
            //    Profess.Add(_profService.Get(item.ProfId));
            //}
            Profess = _profService.getallProfs(Id);
            List<string> names = Profess.Select(x => x.Name).ToList();
            List<int> Ids = Profess.Select(x => x.Id).ToList();

            List<Tuple<int, string>> mylist = new List<Tuple<int, string>>();
            //   mylist.Add(new Tuple<int, string>() { Id, names });
            for (int i = 0; i < names.Count; i++)
            {
                mylist.Add(new Tuple<int, string>(Ids[i], names[i]));
            }
            // ViewBag["Id"] = Id;
            return mylist;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            universities = _universityService.GetAll().ToList();




            ViewBag.universities = new SelectList(universities, "Id", "Name");

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(SourceDto sourceDto, IFormFile sources)
        {
            //if(!ModelState.IsValid)
            //    return RedirectToAction("Index");
            _source.AddSource(sourceDto, sources);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Details(SourceDisplayDTO sourceDisplayDTO)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Index");
            var source = _source.getallSource(sourceDisplayDTO);

            return PartialView("SourceDisplay", source);
        
            //    _source.getallSource(courses, instructor, department, colleges, unversity);
            //   universities = _universityService.getallUniversies();

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Id)
        {
            if(Id == 0)
                return RedirectToAction("Index");
            _source.removeSource(Id);

            return PartialView("SourceDisplay", _source.GetAll());

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int Id, int department, int colleges, int unversity)
        {
            
            Source source = _source.GetOneSource(Id);
            SourceDto sourceDto = source.SourceToDTO();
            var cource = _courcesService.GetOneCourse(source.CrsID);
            var prof = _profService.GetOneProfessor(source.ProfID);
            var dept = _departmentService.GetOneDepart(department);
            var college = _collegeServices.GetColWithUniversty(colleges);
            var uni = _universityService.Get(unversity);
            sourceDto.deptId = department;

            sourceDto.uniId = unversity;

            sourceDto.colliId = colleges;

            sourceDto.uniName = uni.Name;
            sourceDto.collName = college.Name;
            sourceDto.deptName = dept.Name;
            var allcolleges = _collegeServices.filterCollegesByUni(unversity).ToList();
            var allDepts = _departmentService.getallDepartments(colleges);
            var allCources = _courcesService.getallCources(department);
            var allprof = _profService.getallProfs(source.CrsID);
            var allUni = _universityService.GetAll().ToList();
            // var  = { Name:"ملخص" };

            var allType = new[] { new { Name = "ملخص" }, new { Name = "حل تاسك" } };
            ViewBag.universities = new SelectList(allUni, "Id", "Name", unversity);
            ViewBag.Colleges = new SelectList(allcolleges, "Id", "Name", college);
            ViewBag.Departments = new SelectList(allDepts, "Id", "Name", department);
            ViewBag.Cources = new SelectList(allCources, "Id", "Name", source.CrsID);
            ViewBag.Profs = new SelectList(allprof, "Id", "Name", source.ProfID);
            ViewBag.Types = new SelectList(allType, "Name", "Name", source.Type);
            return View(sourceDto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(SourceDto sourceDto, IFormFile sources)
        {

        
            _source.Update(sourceDto,  sources);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin , Buyer")]
        public IActionResult DisplayOne(int Id)
        {
            return View();
        }

    }
}
