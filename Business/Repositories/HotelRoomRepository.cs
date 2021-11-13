using AutoMapper;
using Business.Repositories.IRepositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public HotelRoomRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            HotelRoom hotelRoom = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "";

            var addedHotelRoom = await _dbContext.HotelRooms.AddAsync(hotelRoom);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HotelRoom, HotelRoomDTO>(addedHotelRoom.Entity);
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomToDelete = await _dbContext.HotelRooms.FindAsync(roomId);
            if (roomToDelete != default)
            {
                _dbContext.HotelRooms.Remove(roomToDelete);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
        {
            try
            {
                IEnumerable<HotelRoomDTO> hotelRoomsDTO = 
                    _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDTO>>(_dbContext.HotelRooms.Include(x => x.HotelRoomImages));

                return hotelRoomsDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int roomId)
        {
            try
            {
                HotelRoomDTO hotelRoomDTO =
                    _mapper.Map<HotelRoom, HotelRoomDTO>(
                        await _dbContext.HotelRooms.Include(x =>x.HotelRoomImages).SingleOrDefaultAsync(r => r.Id == roomId));
                return hotelRoomDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> IsRoomUnique(string name, int roomId = 0)
        {
            try
            {
                if (roomId == 0)
                {
                    HotelRoomDTO hotelRoomDTO =
                        _mapper.Map<HotelRoom, HotelRoomDTO>(
                            await _dbContext.HotelRooms.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower()));
                    return hotelRoomDTO;
                }
                else
                {
                    HotelRoomDTO hotelRoomDTO =
                        _mapper.Map<HotelRoom, HotelRoomDTO>(
                            await _dbContext.HotelRooms.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower() 
                            && r.Id != roomId));
                    return hotelRoomDTO;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
        {
            try
            {
                if (roomId == hotelRoomDTO.Id)
                {
                    //valid
                    var roomToUpdate = await _dbContext.HotelRooms.FindAsync(roomId);
                    var room = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO, roomToUpdate);
                    room.UpdatedBy = "";
                    room.UpdatedDate = DateTime.Now;
                    var updatedRoom = _dbContext.HotelRooms.Update(room);
                    await _dbContext.SaveChangesAsync();
                    return _mapper.Map<HotelRoom, HotelRoomDTO>(updatedRoom.Entity);    
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
