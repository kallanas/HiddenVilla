using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class HotelAmenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Timing { get; set; }
        public string Icon { get; set; }
        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
