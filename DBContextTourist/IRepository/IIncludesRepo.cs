using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository
{
    public interface IIncludesRepo : IBaseRepo<Include>
    {
        void DeleteByTourId(int tourId);
    }
}
