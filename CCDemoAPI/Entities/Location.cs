using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI.Entities
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Type { get; set; }
        public String ContactEmail { get; set;  }
        public List<Room> Rooms { get; set; }
        public int ParkingId { get; set; }
        public virtual Parking Parking { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }


    }
}
