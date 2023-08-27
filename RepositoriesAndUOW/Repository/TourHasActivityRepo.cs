using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class TourHasActivityRepo : BaseRepo<TourHasActivity>, ITourHasActivityRepo
    {
        public TourHasActivityRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }
        public void DeleteByTourId(int tourId)
        {
            var tourActivities = _touristsContext.Set<TourHasActivity>().Where(i => i.TourId == tourId);
            _touristsContext.Set<TourHasActivity>().RemoveRange(tourActivities);
        }
    }
}
