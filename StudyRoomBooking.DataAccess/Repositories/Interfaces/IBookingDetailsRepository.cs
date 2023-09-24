using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.DataAccess.Repositories.Interfaces
{
    public interface IBookingDetailsRepository
    {
        BookingDetailsResponse GetBookingDetailsById(int id);
    }
}
