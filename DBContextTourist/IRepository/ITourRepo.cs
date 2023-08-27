using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository
{
    public interface ITourRepo : IBaseRepo<Tour>
    {

        public IQueryable<Tour> GetAll2();
       
    }
}
