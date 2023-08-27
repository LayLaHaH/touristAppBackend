using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class TourRepo : BaseRepo<Tour>, ITourRepo
    {
        public TourRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }

        public IQueryable<Tour> GetAll2()
        {
            return _touristsContext.Tours;
        }
    }
}
