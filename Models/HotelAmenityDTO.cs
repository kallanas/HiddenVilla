using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelAmenityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the hours this amenity is given")]

        public string Timing { get; set; }
        [Required(ErrorMessage = "Please enter a valid FontAwesome icon")]
        public string Icon { get; set; }
        public ICollection<HotelRoomDTO> HotelRooms { get; set; }
    }
}
