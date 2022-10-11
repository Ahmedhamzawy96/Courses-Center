using Courses_Center.Models;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Repositories.University_Repositry.IUniversityRepositry
{
    public interface IUniversityRepositrymain : IGenericRepositry<University>
    {
        IEnumerable<University> GetUniverstyNotD();
        void SaveChanges();
        void AddByName(string name);
        int updateUniversity(University uni);

        bool CheckNameUniversity(string Name);
    }
}
