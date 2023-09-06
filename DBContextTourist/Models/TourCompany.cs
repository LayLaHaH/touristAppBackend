using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBContextTourist.Models
{
    public partial class TourCompany
    {
        public TourCompany()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Address { get; set; } = null!;

       public string UserId { get; set; } = null!;
        [JsonIgnore]
        public virtual IdentityUser User { get; set; } = null!;

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
