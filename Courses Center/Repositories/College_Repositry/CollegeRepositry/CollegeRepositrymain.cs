using Courses_Center.Models;
using Courses_Center.Repositories.College_Repositry.ICollegeRepositry;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;

namespace Courses_Center.Repositories.College_Repositry.CollegeRepositry
{
    public class CollegeRepositrymain:GenericRepositry<College>, ICollegeRepositrymain
    {
        public CollegeRepositrymain(CenterContext context) :base(context)
        { }
    }
}
