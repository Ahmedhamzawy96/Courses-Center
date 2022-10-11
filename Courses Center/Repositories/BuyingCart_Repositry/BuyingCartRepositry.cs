﻿using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;

namespace Courses_Center.Repositories.BuyingCart_Repositry
{
    public class BuyingCartRepositry : GenericRepositry<BuyingCart>, IBuyingCart
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public BuyingCartRepositry(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
