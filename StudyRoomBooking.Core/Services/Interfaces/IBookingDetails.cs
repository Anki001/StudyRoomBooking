using StudyRoomBooking.Models.DomainModels;
using System.Threading.Tasks;

namespace StudyRoomBooking.Core.Services.Interfaces
{
    public interface IBookingDetails
    {
         Task<BookingDetails> GetBookingDetailsById(int id);
    }
}
