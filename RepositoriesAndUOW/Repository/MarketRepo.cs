using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class MarketRepo : BaseRepo<Market>, IMarketRepo
    {
        public MarketRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }
    }
}
