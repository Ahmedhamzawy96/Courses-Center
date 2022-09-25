using Courses_Center.Models;
using Courses_Center.Repositories.College_Repositry.CollegeRepositry;
using Courses_Center.Repositories.College_Repositry.ICollegeRepositry;
using Courses_Center.Repositories.Department_Repositry;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.University_Repositry.IUniversityRepositry;
using Courses_Center.Repositories.University_Repositry.UniversityRepositry;
using Courses_Center.Services.College_Service;
using Courses_Center.Services.Department_Service;
using Courses_Center.Services.University_Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICollegeService,CollegeService>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddScoped<ICollegeRepositrymain, CollegeRepositrymain>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUniversityRepositrymain, UniversityRepositrymain>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepositrymain, DepartmentRepositrymain>();


builder.Services.AddDbContext<CenterContext>(options => options.UseSqlServer("server=.;database=CourseCenter;Trusted_Connection=True"));

var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app
.MapDefaultControllerRoute();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "routeAdmin",
      pattern: "admin/{controller=Home}/{action=Index}/{id?}");  
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
   
});

app.Run();
