using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public decimal Area { get; set; }
        public int DoorCount { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
