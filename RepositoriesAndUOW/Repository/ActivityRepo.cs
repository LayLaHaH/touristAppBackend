using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class ActivityRepo : BaseRepo<Activity>, IActivityRepo
    {
        public ActivityRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }
    }
}
