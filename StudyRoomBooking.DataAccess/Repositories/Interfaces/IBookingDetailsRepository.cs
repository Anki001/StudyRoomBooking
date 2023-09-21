using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Response;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repositories.Interfaces
{
    public interface IBookingDetailsRepository
    {
        BookingDetailsResponse GetBookingDetailsById(int id);
    }
}
