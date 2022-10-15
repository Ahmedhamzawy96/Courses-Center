using Courses_Center.Models;
using Courses_Center.Repositories.College_Repositry.ICollegeRepositry;
using Courses_Center.Repositories.General;
using Courses_Center.Services.Generic_Service;

namespace Courses_Center.Services.College_Service
{
    public class CollegeService:EntityService<College>,ICollegeService
    {
        IUnitOfWork _unitOfWork;
        ICollegeRepositrymain _CollegeRepositrymain;
        public CollegeService(ICollegeRepositrymain CollegeRepositrymain, IUnitOfWork unitOfWork) : base(CollegeRepositrymain, unitOfWork) {
            _unitOfWork = unitOfWork;
            _CollegeRepositrymain = CollegeRepositrymain;
            
        }

        public bool CheckNameColl(string Name, int uniId)
        {
           return _CollegeRepositrymain.CheckNameCollege(Name,uniId);
        }

        public IEnumerable<College> filterCollegesByUni(int? uniID)
        {
            if (uniID > 0 && uniID is not null)
            { return _unitOfWork.dbContext.Colleges.Where(uni => uni.UniID == uniID&&uni.ISDeleted == false); }
            else
            {
                return null;
            }
        }

        public College GetColWithUniversty(int? id)
        {
            if (id == null)
                return null;
            return _CollegeRepositrymain.GetColWithUni(id);
        }

        public bool updateCollage(College old, College UpdateCollage)
        {
            if (UpdateCollage == null||old==null) throw new ArgumentNullException("entity is null");

            _CollegeRepositrymain.Update(UpdateCollage,old);
            _unitOfWork.Commit();
            return true;
        }
        public List<College> getallCollege(int UniID)
        {
            return _CollegeRepositrymain.GetAllWithCondation(
                c => c.UniID == UniID
                );
        }
        public College GetOneCollege(int id)
        {
            return _CollegeRepositrymain.Get(id);
        }
    }
}
