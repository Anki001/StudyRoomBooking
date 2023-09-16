using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.Core.Services.Interfaces
{
    public interface IBookingRegistration
    {
         bool  UserDetailsValidation(UserDetails userDetails);
         string RoomAvilabilty(UserDetails userDetails);
          int BookingIdByRoomId(String roomNo);
         void ChangeRoomavilabity(String roomNo);
    }
}
