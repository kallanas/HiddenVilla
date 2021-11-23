using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.IRepositories
{
    public interface IHotelAmenityRepository
    {
        public Task<IEnumerable<HotelAmenityDTO>> GetAllAmenities();
        public Task<HotelAmenityDTO> GetHotelAmenityById(int amentityId);
        public Task DeleteAmenityById(int amenityId);
        public Task CreateAmenity(HotelAmenityDTO amenity);
        public Task<HotelAmenityDTO> UpdateAmenity(int id, HotelAmenityDTO amenityDTO);
    }
}
