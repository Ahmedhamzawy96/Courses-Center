using Courses_Center.CustomHandler;
using Courses_Center.Models;
using Courses_Center.Repositories.BuyerRepositry;
using Courses_Center.Repositories.BuyingCart_Repositry;
using Courses_Center.Repositories.College_Repositry.CollegeRepositry;
using Courses_Center.Repositories.College_Repositry.ICollegeRepositry;
using Courses_Center.Repositories.Course_Repository.CourseRepository;
using Courses_Center.Repositories.Course_Repository.ICourseRepository;
using Courses_Center.Repositories.CourseProfessorRepos;
using Courses_Center.Repositories.Department_Repositry;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;
using Courses_Center.Repositories.Professor_Repositry;
using Courses_Center.Repositories.SourcesRepository.ISourcesRepository;
using Courses_Center.Repositories.SourcesRepository.SourcesRepository;
using Courses_Center.Repositories.University_Repositry.IUniversityRepositry;
using Courses_Center.Repositories.University_Repositry.UniversityRepositry;
using Courses_Center.Repositories.UserRepositry;
using Courses_Center.Services.BuyerService;
using Courses_Center.Services.BuyingCartServices;
using Courses_Center.Services.College_Service;
using Courses_Center.Services.Course_Service;
using Courses_Center.Services.CourseProfessorService;
using Courses_Center.Services.Department_Service;
using Courses_Center.Services.Professor_Service;
using Courses_Center.Services.SourcesService;
using Courses_Center.Services.University_Service;
using Courses_Center.Services.UserService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

string policy = "";
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICollegeService,CollegeService>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddScoped<ICollegeRepositrymain, CollegeRepositrymain>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUniversityRepositrymain, UniversityRepositrymain>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepositrymain, DepartmentRepositrymain>();

builder.Services.AddScoped<ICourseRepositorymain, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();

builder.Services.AddScoped<ICourseProfessorRepo, CourseProfessorRepo>();
builder.Services.AddScoped<ICourseProfessorService, CourseProfessorService>();
builder.Services.AddScoped(typeof(ISourceRepository), typeof(SourceRepository));
builder.Services.AddScoped(typeof(ISource), typeof(SourceSevice));
builder.Services.AddScoped(typeof(IUserRepositry), typeof(UserRepositiry));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IBuyerRepositiry), typeof(BuyerRepositiry));
builder.Services.AddScoped(typeof(IBuyerService), typeof(BuyerService));
builder.Services.AddScoped(typeof(IBuyingCart), typeof(BuyingCartRepositry));
builder.Services.AddScoped(typeof(IBuyingCartService), typeof(BuyingCartService));
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.LoginPath = "/Login/UserLogin";
        options.AccessDeniedPath = "/Login/UserAccessDenied";
    });

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("UserPolicy", policyBuilder =>
    {
        policyBuilder.RequireRole(ClaimTypes.Role);
    });
});
builder.Services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
builder.Services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddScoped(typeof(IUserService), typeof(UserService));

//builder.Services.AddAntiforgery(o => o.SuppressXFrameOptionsHeader = true);

builder.Services.AddAntiforgery(o => o.SuppressXFrameOptionsHeader = true);
builder.Services.AddDbContext<CenterContext>(options => options.UseSqlServer("server=.;database=CourseCenter;Trusted_Connection=True"));
builder.Services.AddCors(options => options.AddPolicy(policy, builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
}));
var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors(policy);
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "routeAdmin",
     pattern: "{Admin}/{controller=University}/{action=Index}/{id?}");
    endpoints.MapDefaultControllerRoute();
});


app.Run();
