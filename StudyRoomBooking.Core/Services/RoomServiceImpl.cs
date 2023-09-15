using System.Collections.Generic;
using System.Threading.Tasks;
using StudyRoomBooking.DataAccess.Repository;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.Core.Services
{

    public class RoomServiceImpl : IRoomService
    {
       public readonly IRoomRepository _roomRepository;
        public RoomServiceImpl(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

       public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
           return await _roomRepository.GetRoomsAsyncData();
        }

    }
}
