using System;
using System.Collections.Generic;

namespace DBContextTourist.Models
{
    public partial class Governorate
    {
        public Governorate()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }
    }
}
