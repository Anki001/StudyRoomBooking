using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.DataAccess.Repositories.Interfaces
{
    public interface IStudyRoomRepository
    {
        StudyRoomResponse GetRooms();
    }
}
