using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class ItineraryRepo : BaseRepo<Itinerary>, IItineraryRepo
    {
        public ItineraryRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }

        public void DeleteByTourId(int tourId)
        {
            var itineraries = _touristsContext.Set<Itinerary>().Where(i => i.TourId == tourId);
            _touristsContext.Set<Itinerary>().RemoveRange(itineraries);
        }
    }
}
