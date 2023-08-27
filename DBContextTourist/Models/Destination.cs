using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBContextTourist.Models
{
    public partial class Destination
    {
        public Destination()
        {
            DestinationPictures = new HashSet<DestinationPicture>();
            TourHasDestinations = new HashSet<TourHasDestination>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Theme { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CityId { get; set; }
        [JsonIgnore]
        public virtual City City { get; set; } = null!;
        public virtual ICollection<DestinationPicture> DestinationPictures { get; set; }
        public virtual ICollection<TourHasDestination> TourHasDestinations { get; set; }
    }
}
