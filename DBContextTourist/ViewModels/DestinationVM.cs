using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextTourist.ViewModels
{
    public class DestinationVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Theme { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CityId { get; set; }
        public List<String> selectedPictures { get; set; }
    }
}
