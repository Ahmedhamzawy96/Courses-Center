using Courses_Center.Models;
using System.Linq.Expressions;

namespace Courses_Center.Services.UserService
{
    public interface IUserService
    {
        List<Admin> getallAdmins();
        Admin AddAdmin(Admin A);
        Admin GetOneAdmin(string userName);
        Admin getOneAdmin(string username, string password);
       List<Admin> getOneAdminRole(Expression<Func<Admin, bool>> Condition);
        void removeAdmin(string userName);
        void updateAdmin(Admin A);
    }
}
