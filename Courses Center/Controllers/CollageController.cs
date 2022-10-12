
//using Aspose.Words;
using Aspose.Words;
using Aspose.Pdf.Devices;
using Courses_Center.Models;
using Courses_Center.Services.College_Service;
using Courses_Center.Services.Course_Service;
using Courses_Center.Services.Department_Service;
using Courses_Center.Services.Professor_Service;
using Courses_Center.Services.SourcesService;
using Courses_Center.Services.University_Service;
using Courses_Center.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Drawing;
using Aspose.Words.Saving;
using System;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using ceTe.DynamicPDF.Rasterizer;
using SautinSoft.Document;
using Courses_Center.Services.BuyingCartServices;

namespace Courses_Center.Controllers
{
    
    public class CollageController : Controller
    {
        ICollegeService _CollegeService;
        IUniversityService _UniversityService;
        private readonly IDepartmentService _departmentService;
        private readonly ICourseService _courcesService;
        private readonly ISource _source;
        private readonly IProfessorService _profService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        IBuyingCartService _buyingCartService;
        public CollageController(ICollegeService CollegeService, 
            IUniversityService UniversityService,
            IDepartmentService departmentService,
            ISource source, IProfessorService profService , 
            ICourseService courcesService, 
            IWebHostEnvironment webHostEnvironment,
            IBuyingCartService buyingCartService) {
            _CollegeService= CollegeService;
            _UniversityService= UniversityService;
            _departmentService = departmentService;
            _source= source;
            _profService = profService;
            _courcesService = courcesService;
            _webHostEnvironment= webHostEnvironment;
            _buyingCartService= buyingCartService;

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var universtyItems = _UniversityService.GetUniverstyNotDelete().ToList();
            ViewData["Universities"] = universtyItems;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DisplayCollage(int? UniverstyID)
        {
            //Modelfilter.CollageID = null;
            if (UniverstyID is null || UniverstyID <= 0 )
                return PartialView("DisplayCollage",null);
            return PartialView("DisplayCollage", _CollegeService.filterCollegesByUni(UniverstyID).ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            var universtyItems = _UniversityService.GetUniverstyNotDelete().ToList();
            ViewData["Universities"] = universtyItems;
            return View();
        }
        [HttpPost]
        public IActionResult AddCollage(College newCollage)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Add));
            try
            {
                _CollegeService.Add(newCollage);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Add));
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NoContent();
            //return RedirectToAction(nameof(Index));
            var res = _CollegeService.GetColWithUniversty(id);
            if (res == null)
                return RedirectToAction(nameof(Index));
            var universtyItems = _UniversityService.GetUniverstyNotDelete().ToList();
            ViewData["Universities"] = universtyItems;
            return View(res);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditCollage(int? id, College updateCollage)
        {
            if (!ModelState.IsValid || id <= 0 || id == null)
                return RedirectToAction(nameof(Edit));
            try
            {
                var old = _CollegeService.GetColWithUniversty(id);
                if (old == null)
                    return View(nameof(Index));
                var ok = _CollegeService.updateCollage(old, updateCollage);
                if (ok)
                {
                    //var universtyItems = _UniversityService.GetUniverstyNotDelete().ToList();
                    //ViewData["Universities"] = universtyItems;
                    //return View(nameof(Index));
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
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            var depart = _CollegeService.Get((int)id);
            if (depart == null)
                return NoContent();
            _CollegeService.Remove(depart);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CheckNameColl(string Name,int UniID)
       {
            bool res = _CollegeService.CheckNameColl(Name,UniID);
            return Json(!res);

        }
        List<Department> departments = new List<Department>();
        List<Course> CoursesList=new List<Course>();
        
        public IActionResult CollegeDepts(int Id)
        {
            try
            {
                ViewBag.NameCol = _UniversityService.Get(Id)?.Name;
            }
            catch { }
            departments = _departmentService.getallDepartments(Id);
            ViewBag.departments = new SelectList(departments, "Id", "Name"); ;
            return View();
        }
        [HttpPost]
        
        public async Task<List<Tuple<int, string>>> Courses(int Id)
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
       
        public async Task<List<SourceDto>> Details(int Id)
        {
            
            
            List<Source> x = _source.getallSource(Id);
            
           List<SourceDto> sourceDtos = new List<SourceDto>();

            foreach (var item in x)
            {
                SourceDto sd = new SourceDto();



                //sd.ProfName = _profService.GetOneProfessor(item.ProfID).Name;
                sd.Price = item.Price;
               var user= HttpContext.Session.GetString("username");
                var buy="";
                if (user != null)
                {
                    var buying = _buyingCartService.DisplayFinishBuyingCart(user, item.Id);


                    if(buying.Count >0)
                    sd.Url = "/resources/" + item.Url;
                }
                sd.Title = item.Title;
                sd.Id = item.Id;
                sd.ImageName = item.image;
                sourceDtos.Add(sd);


            }




               return sourceDtos;
        }
        [HttpGet]
        
        public IActionResult product(int Id)
        {


            Source x = _source.GetOneSource(Id);
            //    _source.getallSource(courses, instructor, department, colleges, unversity);
            //   universities = _universityService.getallUniversies();

            List<SourceDto> sourceDtos = new List<SourceDto>();

            SourceDto sd = new SourceDto();
           // sd.ProfName = _profService.GetOneProfessor(x.ProfID).Name;
            sd.Price = x.Price;
            sd.Url = x.Url;
            sd.Title = x.Title;
            sd.Id = x.Id;
            sd.Description = x.Description;

            return View(sd);
        }

    }
}
