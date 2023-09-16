using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repository.Interfaces
{
    public interface IBookingRegistrationRepo
    {
        void SaveBookingDetails(BookingDetails bookingDetails);
        int BookingIdByRoomId(string roomNo);

        void ChangeRoomAvilability(string roomNo);

        Room RoomAvilabity();

      

      
    }
}
