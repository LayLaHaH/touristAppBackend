using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBContextTourist.Models
{
    public partial class Itinerary
    {
        public int Id { get; set; }
        public string EachDayDescription { get; set; } = null!;
        public int TourId { get; set; }
        [JsonIgnore]
        public virtual Tour Tour { get; set; } = null!;
    }
}
