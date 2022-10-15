using Courses_Center.Models;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;

namespace Courses_Center.Repositories.SourcesRepository.ISourcesRepository
{
    public interface ISourceRepository: IGenericRepositry<Source>
    {
        void SaveChanges();
        public IEnumerable<dynamic> getallSourceForBuyer(string username);
    }
}
