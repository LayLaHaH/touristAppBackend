using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBContextTourist.Models
{
    public partial class TourHasActivity
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int ActivityId { get; set; }
        [JsonIgnore]
        public virtual Activity Activity { get; set; } = null!;
        [JsonIgnore]
        public virtual Tour Tour { get; set; } = null!;
    }
}
