using Courses_Center.Models;
using Courses_Center.Repositories.College_Repositry.ICollegeRepositry;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;
using Microsoft.EntityFrameworkCore;

namespace Courses_Center.Repositories.College_Repositry.CollegeRepositry
{
    public class CollegeRepositrymain:GenericRepositry<College>, ICollegeRepositrymain
    {
        public CollegeRepositrymain(CenterContext context) :base(context)
        { }

        public College GetColWithUni(int? id)
        {
            if (id == null || id <= 0)
                return null;
            return _entities.Colleges.Include(uni => uni.University).FirstOrDefault(col => col.Id == id);
        }

        public bool CheckNameCollege(string Name,int uniId)
        {
            bool res = _entities.Colleges.Any(col => col.Name == Name && col.UniID == uniId);
            return res;
        }
    }
}
