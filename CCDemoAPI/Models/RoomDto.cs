using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI.Models
{
    public class RoomDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public decimal Area { get; set; }
        public int DoorCount { get; set; }
    }
}
