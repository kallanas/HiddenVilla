using AutoMapper;
using Business.Repositories.IRepositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class HotelRoomImageRepository :IHotelRoomImageRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public HotelRoomImageRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<int> CreateHotelRoomImage(HotelRoomImageDTO imageDTO)
        {
            var image = _mapper.Map<HotelRoomImageDTO, HotelRoomImage>(imageDTO);
            await _dbContext.HotelRoomImages.AddAsync(image);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageById(int imageId)
        {
            var image = await _dbContext.HotelRoomImages.FindAsync(imageId);
            _dbContext.HotelRoomImages.Remove(image);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByImageUrl(string imageUrl)
        {
            var image = await _dbContext.HotelRoomImages.SingleOrDefaultAsync(u => u.RoomImageUrl.ToLower() == imageUrl.ToLower());
            if (image == default)
                return 0;
            _dbContext.HotelRoomImages.Remove(image);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByRoomId(int roomId)
        {
            var images = await _dbContext.HotelRoomImages.Where(i => i.RoomId == roomId).ToListAsync();
            _dbContext.HotelRoomImages.RemoveRange(images);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<HotelRoomImageDTO>> GetAllHotelRoomImages(int roomId)
        {
            return _mapper.Map<IEnumerable<HotelRoomImage>, IEnumerable<HotelRoomImageDTO>>(
                await _dbContext.HotelRoomImages.Where(i => i.RoomId == roomId).ToListAsync());
        }
    }
}
