using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class ExcludesRepo : BaseRepo<Exclude>, IExcludesRepo
    { 
        public ExcludesRepo(touristsContext touristsContext) : base(touristsContext)
        {


        }

        public void DeleteByTourId(int tourId)
        {
            var excludes = _touristsContext.Set<Exclude>().Where(i => i.TourId == tourId);
            _touristsContext.Set<Exclude>().RemoveRange(excludes);
        }
    }
}
