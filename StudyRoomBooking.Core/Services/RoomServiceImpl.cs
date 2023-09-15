using StudyRoomBooking.Core.FactoryService;
using StudyRoomBooking.DataAccess.Repository;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Core.Services
{

    public class RoomServiceImpl : IServiceHandler<EmptyRequest, RoomResponse>
    {
       public readonly IRoomRepository _roomRepository;
        public RoomServiceImpl(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public RoomResponse ExcecuteService(EmptyRequest request)
        {
           return _roomRepository.GetRooms();
        }
    }
}
