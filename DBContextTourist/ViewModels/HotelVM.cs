﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextTourist.ViewModels
{
    public class HotelVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string? Url { get; set; }
        public string Address { get; set; } = null!;
        public int ClassStar { get; set; }
        public string Image { get; set; } = null!;
        public int CityId { get; set; }
    }
}
