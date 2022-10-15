using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.GenericRepositry;
using Courses_Center.Repositories.SourcesRepository.ISourcesRepository;

namespace Courses_Center.Repositories.SourcesRepository.SourcesRepository
{
    public class SourceRepository : GenericRepositry<Source>, ISourceRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SourceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<dynamic> getallSourceForBuyer(string username)
        {
            var Sources = _entities.BuyingCarts.GroupJoin(// outer sequence 
                                  _entities.Sources,  // inner sequence 
                                  buyer => buyer.SId,    // outerKeySelector
                                  source => source.Id,  // innerKeySelector
                                  (buyer, source) => new  // result selector
                                  {
                                      buyer = buyer.BuyUserName,
                                      source = source
                                  }).Where(buy => buy.buyer == username).ToList();
            return Sources;
        }
    }
}
