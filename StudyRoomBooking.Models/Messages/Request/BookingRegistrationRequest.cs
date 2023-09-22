using StudyRoomBooking.Models.DomainModels;
using System;
using System.ComponentModel;

namespace StudyRoomBooking.Models.Messages.Request
{
    public class BookingRegistrationRequest
    {
       public BookingDetails BookingDetails { get; set; }
    }
}
