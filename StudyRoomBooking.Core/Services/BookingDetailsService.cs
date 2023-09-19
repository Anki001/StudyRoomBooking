using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess.Repositorys.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using System.Threading.Tasks;

namespace StudyRoomBooking.Core.Services
{
    public class BookingDetailsService : IBookingDetails
    {
        private readonly IBookingDetailsRepository _repository;

        public BookingDetailsService(IBookingDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookingDetails> GetBookingDetailsById(int id)
         {
             var bookingDetails = await _repository.GetBookingDetailsById(id);
             return bookingDetails;
         }
    

    }
}
