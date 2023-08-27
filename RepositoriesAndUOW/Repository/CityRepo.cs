﻿using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class CityRepo : BaseRepo<City>, ICityRepo
    {
        public CityRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }
    }
}
