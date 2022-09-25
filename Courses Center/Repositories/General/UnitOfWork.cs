using Courses_Center.Models;

namespace Courses_Center.Repositories.General
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        CenterContext _dbContext;
        public UnitOfWork(CenterContext Context) {
            _dbContext=Context;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}
