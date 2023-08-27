using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository
{
    public interface IExcludesRepo : IBaseRepo<Exclude>
    {

        void DeleteByTourId(int tourId);

    }
}
