using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository
{
    public interface IItineraryRepo : IBaseRepo<Itinerary>
    {

        void DeleteByTourId(int tourId);
    }
}
