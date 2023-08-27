using System;
using System.Collections.Generic;

namespace DBContextTourist.Models
{
    public partial class City
    {
        public City()
        {
            Destinations = new HashSet<Destination>();
            Hotels = new HashSet<Hotel>();
            Markets = new HashSet<Market>();
            Restaurants = new HashSet<Restaurant>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public int GovernerateId { get; set; }

        public virtual Governorate Governerate { get; set; } = null!;
        public virtual ICollection<Destination> Destinations { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Market> Markets { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
