using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using System.Threading.Tasks;

namespace StudyRoomBooking.Core.Services
{
    public class RoomDetailsService : IRoomDetails
    {
        private readonly IRoomDetailsRepository _repository;

        public RoomDetailsService(IRoomDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudyRoom> GetRoomDetailsById(int id)
        {
            if(id <= 0)
            {
                return null;
            }
            return await _repository.GetRoomDetailsById(id);
        }
    }
}
