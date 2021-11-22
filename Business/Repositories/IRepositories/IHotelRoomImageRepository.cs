using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.IRepositories
{
    public interface IHotelRoomImageRepository
    {
        public Task<int> CreateHotelRoomImage(HotelRoomImageDTO image);
        public Task<int> DeleteHotelRoomImageById(int imageId);
        public Task<int> DeleteHotelRoomImageByRoomId(int roomId);
        public Task<int> DeleteHotelRoomImageByImageUrl(string imageUrl);
        public Task<IEnumerable<HotelRoomImageDTO>> GetAllHotelRoomImages(int roomId);
    }
}
