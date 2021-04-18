using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String ContactEmail { get; set; }
        public String City { get; set; }
        public String Street { get; set; }
        public String PostalCode { get; set; }
        public String Parking { get; set; }
        public List<RoomDto> Rooms { get; set; }
 
    }
}
