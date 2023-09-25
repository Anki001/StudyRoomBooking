using StudyRoomBooking.Models.DomainModels;
using System.Collections.Generic;

namespace StudyRoomBooking.Models.Messages.Response
{
    public class BookingDetailsResponse
    {
       public IEnumerable<BookingDetails> bookingDetails { get; set; }
    }
}
