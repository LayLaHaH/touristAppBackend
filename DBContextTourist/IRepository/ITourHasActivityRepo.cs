using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository
{
    public interface ITourHasActivityRepo : IBaseRepo<TourHasActivity>
    {

        void DeleteByTourId(int tourId);
    }
}
