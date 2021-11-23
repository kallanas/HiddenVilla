using AutoMapper;
using Business.Repositories.IRepositories;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class HotelAmenityRepository : IHotelAmenityRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public HotelAmenityRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task CreateAmenity(HotelAmenityDTO amenity)
        {
            HotelAmenity hotelAmenity = _mapper.Map<HotelAmenityDTO, HotelAmenity>(amenity);

            await _dbContext.HotelAmenities.AddAsync(hotelAmenity);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task DeleteAmenityById(int amenityId)
        {
            var amenityToDelete = await _dbContext.HotelAmenities.FindAsync(amenityId);
            _dbContext.Remove(amenityToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelAmenityDTO>> GetAllAmenities()
        {
            try
            {
                IEnumerable<HotelAmenityDTO> hotelAmenitiesDTO =
                    _mapper.Map<IEnumerable<HotelAmenity>, IEnumerable<HotelAmenityDTO>>(_dbContext.HotelAmenities);

                return hotelAmenitiesDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelAmenityDTO> GetHotelAmenityById(int amentityId)
        {
            var amenity = await _dbContext.HotelAmenities.FindAsync(amentityId);
            return _mapper.Map<HotelAmenity, HotelAmenityDTO>(amenity);
        }

        public async Task<HotelAmenityDTO> UpdateAmenity(int id, HotelAmenityDTO hotelAmenityDTO)
        {
            var amenityToUpdate = await _dbContext.HotelAmenities.FindAsync(id);
            if (amenityToUpdate != null)
            {
                var amenity = _mapper.Map<HotelAmenityDTO, HotelAmenity>(hotelAmenityDTO, amenityToUpdate);
                var updatedAm = _dbContext.Update(amenity);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<HotelAmenity, HotelAmenityDTO>(updatedAm.Entity);
            }
            return null;
        }
    }
}
