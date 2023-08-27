using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DBContextTourist.ViewModels
{
    public class TourVM
    {
        public TourVM()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string DaysNnights { get; set; } = null!;
        public decimal Cost { get; set; }
        public string Theme { get; set; } = null!;
        public bool IsPrivate { get; set; }
        public string GuidLanguage { get; set; } = null!;
        public int CompanyId { get; set; }
        public List<int> SelectedDestinations { get; set; }
        public List<int>? SelectedActivities { get; set; }
        public List<String> InsertedIncludes { get; set; }
        public List<String> InsertedExcludes { get; set; }
        public List<String> InsertedItineraries { get; set; }




    }
}
