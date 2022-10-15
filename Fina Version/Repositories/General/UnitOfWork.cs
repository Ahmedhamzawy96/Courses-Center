using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Courses_Center.Models;

namespace Courses_Center.Repositories.General
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private CenterContext _dbContext;

        public CenterContext dbContext { get => _dbContext; }

        public UnitOfWork(CenterContext Context) {
            _dbContext = Context;
        }


        public int Commit()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch { return 0;  }
        }
    }
}
