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

        public int UserCompany(string UserId)
        {
            var company = _touristsContext.TourCompanies.FirstOrDefault(c => c.UserId == UserId);
            return company != null ? company.Id : 0;
        }
    }
}
