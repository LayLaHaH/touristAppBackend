using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class DestinationRepo : BaseRepo<Destination>, IDestinationRepo
    {
        public DestinationRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }
        public IQueryable<Destination> GetAll2()
        {
            return _touristsContext.Destinations;
        }
    }
}
