using System;
using System.Collections.Generic;

namespace DBContextTourist.Models
{
    public partial class Activity
    {
        public Activity()
        {
            TourHasActivities = new HashSet<TourHasActivity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CloseTime { get; set; }
        public DateTime? StartingDay { get; set; }
        public DateTime? EndingDay { get; set; }
        public string Image { get; set; } = null!;

        public virtual ICollection<TourHasActivity> TourHasActivities { get; set; }
    }
}
