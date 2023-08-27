using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBContextTourist.Models
{
    public partial class TourHasDestination
    {
        public int Id { get; set; }
        public int DestId { get; set; }
        public int TourId { get; set; }
        [JsonIgnore]
        public virtual Destination Dest { get; set; } = null!;
        [JsonIgnore]
        public virtual Tour Tour { get; set; } = null!;
    }
}
