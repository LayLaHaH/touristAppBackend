using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class IncludesRepo : BaseRepo<Include>, IIncludesRepo
    {
        public IncludesRepo(touristsContext touristsContext) : base(touristsContext)
        {
           
        }

        public void DeleteByTourId(int tourId)
        {
            var includes = _touristsContext.Set<Include>().Where(i => i.TourId == tourId);
            _touristsContext.Set<Include>().RemoveRange(includes);
        }
    }
}
