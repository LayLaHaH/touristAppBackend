using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class RestaurantRepo : BaseRepo<Restaurant>, IRestaurantRepo
    {
        public RestaurantRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }
    }
}
