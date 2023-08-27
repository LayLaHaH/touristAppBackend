using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextTourist.ViewModels
{
    public class RestaurantVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string? Url { get; set; }
        public string Address { get; set; } = null!;
        public int ClassStar { get; set; }
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
        public string Cuisine { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int CityId { get; set; }
    }
}
