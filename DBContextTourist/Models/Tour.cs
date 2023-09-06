using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBContextTourist.Models
{
    public partial class Tour
    {
        public Tour()
        {
            Excludes = new HashSet<Exclude>();
            Includes = new HashSet<Include>();
            Itineraries = new HashSet<Itinerary>();
            TourHasActivities = new HashSet<TourHasActivity>();
            TourHasDestinations = new HashSet<TourHasDestination>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string DaysNnights { get; set; } = null!;
        public decimal Cost { get; set; }
        public string Theme { get; set; } = null!;
        public bool IsPrivate { get; set; }
        public string GuidLanguage { get; set; } = null!;
        public int CompanyId { get; set; }
        [JsonIgnore]
        public virtual TourCompany Company { get; set; } = null!;

        public virtual ICollection<Exclude> Excludes { get; set; }
        public virtual ICollection<Include> Includes { get; set; }
        public virtual ICollection<Itinerary> Itineraries { get; set; }
        public virtual ICollection<TourHasActivity> TourHasActivities { get; set; }
        public virtual ICollection<TourHasDestination> TourHasDestinations { get; set; }
    }
}
