using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class TourCompanyRepo : BaseRepo<TourCompany>, ITourCompanyRepo
    {
        public TourCompanyRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }
    }
}
