using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository
{
    public interface IDestinationRepo : IBaseRepo<Destination>
    {

        public IQueryable<Destination> GetAll2();
    }
}
