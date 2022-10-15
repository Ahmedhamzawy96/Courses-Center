using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;
using Courses_Center.Repositories.University_Repositry.IUniversityRepositry;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Center.Repositories.University_Repositry.UniversityRepositry
{
   
    public class UniversityRepositrymain : GenericRepositry<University>,IUniversityRepositrymain
    {
        private readonly IUnitOfWork _unitOfWork;
        public UniversityRepositrymain(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IEnumerable<University> GetUniverstyNotD()
        {
            return _unitOfWork.dbContext.Universities.Where(uni => uni.ISDeleted == false);
        }
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
        public void AddByName(string name)
        {

            if (_unitOfWork.dbContext.Universities.Where(r => r.Name == name).FirstOrDefault() == null && !string.IsNullOrEmpty(name))
            {
                _unitOfWork.dbContext.Universities.Add(new University() { Name = name, ISDeleted = false });

            }
            else
            {
            }
        }

        public int updateUniversity(University uni)
        {
            if (uni is not null)
            {
                _unitOfWork.dbContext.Universities.Update(uni);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public bool CheckNameUniversity(string Name)
        {
            bool res = _unitOfWork.dbContext.Universities.Any(uni=>uni.Name == Name);
            return res;
        }
    }
}
