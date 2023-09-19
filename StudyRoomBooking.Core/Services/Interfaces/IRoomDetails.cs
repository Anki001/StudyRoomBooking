using StudyRoomBooking.Models.DomainModels;
using System.Threading.Tasks;

namespace StudyRoomBooking.Core.Services.Interfaces
{
    public interface IRoomDetails
    {
        Task<Room> GetRoomDetailsById(int id);
    }
}
