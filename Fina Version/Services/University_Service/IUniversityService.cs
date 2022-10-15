using Courses_Center.Models;
using Courses_Center.Services.Generic_Service;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Services.University_Service
{
    public interface IUniversityService : IEntityServices<University>
    {
        IEnumerable<University> GetUniverstyNotDelete();
        List<University> getallUniversies();
        University GetOneUniversity(int id);
        void AddbyName(string uniName);
        int updateUniversity(University uni);
        bool CheckNameUni(string Name);
        List<University> SearchUniversites(string search);
    }
}
