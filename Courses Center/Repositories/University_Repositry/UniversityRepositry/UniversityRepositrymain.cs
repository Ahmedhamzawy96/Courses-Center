using Courses_Center.Models;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;
using Courses_Center.Repositories.University_Repositry.IUniversityRepositry;

namespace Courses_Center.Repositories.University_Repositry.UniversityRepositry
{
    public class UniversityRepositrymain : GenericRepositry<University>,IUniversityRepositrymain
    {
        public UniversityRepositrymain(CenterContext context) : base(context)
        { }
    }
}
