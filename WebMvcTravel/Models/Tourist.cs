using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMvcTravel.Models
{
    public class Tourist
    {
        public int TouristId { get; set; }
        public string TourisName { get; set; }
        public bool TourisSex { get; set; }
        public string IdentityCard { get; set; }
        public string TourisPhone { get; set; }
    }
}
