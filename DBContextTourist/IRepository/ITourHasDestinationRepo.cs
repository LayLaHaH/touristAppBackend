using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository

{
    public interface ITourHasDestinationRepo : IBaseRepo<TourHasDestination>
    {

        void DeleteByTourId(int tourId);
    }
}
