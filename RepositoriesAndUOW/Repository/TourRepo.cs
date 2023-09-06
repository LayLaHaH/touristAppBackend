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

        public List<Tour> GetToursOfCompany(string userId)
        {
            var company = _touristsContext.TourCompanies.FirstOrDefault(c => c.UserId == userId);
            if (company != null)
            {
                var tours = _touristsContext.Tours
               .Where(t => t.CompanyId == company.Id)
               .ToList();

                return tours;
            }
            return new List<Tour>();
        }
    }
}
