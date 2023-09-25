using StudyRoomBooking.Models;
using StudyRoomBooking.Models.DomainModels;
using System;

namespace StudyRoomBooking.Core.Helpers.Intefaces
{
    public interface IBookingRegistrationHelper
    {
        bool ValidateUserRequest(BookingDetails bookingDetails);
        bool IsRoomAvilable();
        
        int BookStudyRoom(BookingDetails bookingDetails);
        
    }
}
