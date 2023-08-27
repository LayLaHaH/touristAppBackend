using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBContextTourist.Models
{
    public partial class DestinationPicture
    {
        public int Id { get; set; }
        public string Picture { get; set; } = null!;
        public int DestId { get; set; }
        [JsonIgnore]
        public virtual Destination Dest { get; set; } = null!;
    }
}
