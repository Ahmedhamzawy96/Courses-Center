using Courses_Center.Models;

namespace Courses_Center.Repositories.General
{
    public interface IUnitOfWork
    {
         CenterContext dbContext { get; }

        int Commit();

    }
}
