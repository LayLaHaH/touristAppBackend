using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository
{
    public interface IGovernorateRepo : IBaseRepo<Governorate>
    {
        public List<Governorate> GetAllWithCities();
        public List<Market> GetMarkets(int id);
        public List<Hotel> GetHotels(int id);
        public List<Restaurant> GetRestaurants(int id);


    }
}
