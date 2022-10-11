using Courses_Center.Models;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;
using Courses_Center.Repositories.UserRepositry;
using System.Linq.Expressions;

namespace Courses_Center.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepositry _userRepositry;

        public UserService(IUserRepositry userRepositry)
        {
            _userRepositry = userRepositry;

        }
        public List<Admin> getallAdmins()
        {
            return _userRepositry.GetAllWithCondation(a => a.ISDeleted == false).ToList();
        }
        public Admin getOneAdmin(string username , string password)
        {
            return _userRepositry.GetAllWithCondation(a => a.ISDeleted == false&&a.UserName== username && a.Password== password).FirstOrDefault();
        }
        public List<Admin> getOneAdminRole(Expression<Func<Admin, bool>> Condition)
        {
            return _userRepositry.GetAllWithCondation(Condition);
        }
       
        public Admin AddAdmin(Admin A)
        {



             _userRepositry.Add(A);
            _userRepositry.SaveChanges();
            return A;
        }
        public Admin GetOneAdmin(string userName)
        {
            return _userRepositry.Get(userName);
        }
        public void removeAdmin(string userName)
        {
            Admin A = GetOneAdmin(userName);

            A.ISDeleted = true;
            _userRepositry.Update(A);
            _userRepositry.SaveChanges();
        }
        public void updateAdmin(Admin A)
        {
            _userRepositry.Update(A);
            _userRepositry.SaveChanges();
        }
    }
}
