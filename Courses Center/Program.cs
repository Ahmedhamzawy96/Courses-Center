using Courses_Center.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
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
