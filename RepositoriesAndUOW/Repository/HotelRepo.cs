using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class HotelRepo : BaseRepo<Hotel>, IHotelRepo
    {
        public HotelRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }
    }
}
