using StudyRoomBooking.Models.DomainModels;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repositorys.Interfaces
{
    public interface IBookingDetailsRepository
    {
        Task<BookingDetails> GetBookingDetailsById(int id);
    }
}
