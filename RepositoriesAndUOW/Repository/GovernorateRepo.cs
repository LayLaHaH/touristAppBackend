using DBContextTourist.IRepository;
using DBContextTourist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class GovernorateRepo : BaseRepo<Governorate>, IGovernorateRepo
    {
        public GovernorateRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }

        public List<Governorate> GetAllWithCities()
        {
            return _touristsContext.Governorates.Include(e => e.Cities).ToList();
        }

        public List<Hotel> GetHotels(int id)
        {
            var governorate = _touristsContext.Governorates
                .Include(g => g.Cities)
                .ThenInclude(c => c.Hotels)
                .FirstOrDefault(g => g.Id == id);


            var hotels = governorate.Cities.SelectMany(c => c.Hotels);
            return hotels.ToList();
        }

        public List<Market> GetMarkets(int id)
        {
            var governorate = _touristsContext.Governorates
                .Include(g => g.Cities)
                .ThenInclude(c => c.Markets)
                .FirstOrDefault(g => g.Id == id);


            var markets = governorate.Cities.SelectMany(c => c.Markets);
            return markets.ToList();
        }

        public List<Restaurant> GetRestaurants(int id)
        {
            var governorate = _touristsContext.Governorates
                .Include(g => g.Cities)
                .ThenInclude(c => c.Restaurants)
                .FirstOrDefault(g => g.Id == id);


            var restaurants = governorate.Cities.SelectMany(c => c.Restaurants);
            return restaurants.ToList();
        }
    }
}
