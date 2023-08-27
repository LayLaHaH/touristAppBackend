using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class TourHasDestinationRepo : BaseRepo<TourHasDestination>, ITourHasDestinationRepo
    {
        public TourHasDestinationRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }
        public void DeleteByTourId(int tourId)
        {
            var tourDestinations = _touristsContext.Set<TourHasDestination>().Where(i => i.TourId == tourId);
            _touristsContext.Set<TourHasDestination>().RemoveRange(tourDestinations);
        }
    }
}
