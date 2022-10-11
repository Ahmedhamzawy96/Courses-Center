using Courses_Center.Models;
using Courses_Center.Services.Generic_Service;

namespace Courses_Center.Services.College_Service
{
    public interface ICollegeService : IEntityServices<College>
    {
        IEnumerable<College> filterCollegesByUni(int? uniID);
        College GetColWithUniversty(int? id);
        bool updateCollage(College old, College @new);
        bool CheckNameColl(string Name,int uniId);
        List<College> getallCollege(int UniID);
        College GetOneCollege(int id);
    }
}
