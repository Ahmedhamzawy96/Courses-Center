using Courses_Center.Models;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;

namespace Courses_Center.Repositories.UserRepositry
{
    public interface IUserRepositry : IGenericRepositry<Admin>
    {
        void SaveChanges();
    }
}
