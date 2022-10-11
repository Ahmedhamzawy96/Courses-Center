using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.University_Repositry.IUniversityRepositry;
using Courses_Center.Services.Generic_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Courses_Center.Services.University_Service
{
    public class UniversityService:IUniversityService
    {

        IUniversityRepositrymain _universityRepositry;
        public UniversityService(IUniversityRepositrymain universityRepositry)
        {

            _universityRepositry = universityRepositry;

        }
        public IEnumerable<University> GetUniverstyNotDelete()
        {
            return _universityRepositry.GetUniverstyNotD();
        }
        public void Add(University entity)
        {
            if (entity is not null)
            {
                _universityRepositry.Add(entity);
                _universityRepositry.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }

        }

        public void AddRange(IEnumerable<University> entity)
        {
            if (entity.Count() > 0)
            {
                _universityRepositry.AddRange(entity);
                _universityRepositry.SaveChanges();
            }
        }

        public University Get(int id)
        {
            if (id != 0)
            {
                var un = _universityRepositry.Get(id);
                return un;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddbyName(string uniName)
        {
            _universityRepositry.AddByName(uniName);
            _universityRepositry.SaveChanges();
        }

        public IEnumerable<University> GetAll()
        {
            return _universityRepositry.GetAll();
        }

        public void Remove(University entity)
        {
            _universityRepositry.Remove(entity);
            _universityRepositry.SaveChanges();
        }

        public void RemoveRange(IEnumerable<University> entity)
        {
            throw new System.NotImplementedException();
        }
        // return int if we want to check in action method so that return alert for instance
        public int updateUniversity(University uni)
        {
            int res = _universityRepositry.updateUniversity(uni);
            if (res == 1)
            {
                _universityRepositry.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public List<University> getallUniversies()
        {
            return _universityRepositry.GetAll().ToList();
        }
        public University GetOneUniversity(int id)
        {
            return _universityRepositry.Get(id);
        }
        public bool CheckNameUni(string Name)
        {
            return _universityRepositry.CheckNameUniversity(Name);
        }
        public List<University> SearchUniversites(string search)
        {
            return _universityRepositry.GetAllWithCondation(u => u.Name.Contains(search));
        }
    }
}
