using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Core.Services
{
    public class BookingDetailsServiceHandler : IServiceHandler<BookingRequest,BookingDetailsResponse>
    {
        private readonly IBookingDetailsRepository _repository;
        public BookingDetailsServiceHandler(IBookingDetailsRepository repository)
        {
            _repository = repository;
        }
        public BookingDetailsResponse ExecuteService(BookingRequest request)
        {
            return _repository.GetBookingDetailsById(request.Id);
        }
    }
}
