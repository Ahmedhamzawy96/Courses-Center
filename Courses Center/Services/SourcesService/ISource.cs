using Courses_Center.Models;
using Courses_Center.ViewModels;

namespace Courses_Center.Services.SourcesService
{
    public interface ISource
    {
        List<Source> getallSource(SourceDisplayDTO sourceDisplayDTO);       
        IEnumerable<Source> GetAll();
        Source AddSource(SourceDto sourceDto, IFormFile file);
        Source GetOneSource(int id);
        void removeSource(int id);
        Source Update(SourceDto s, IFormFile sources);
        List<Source> getallSource(int CrsID);
    }

}
