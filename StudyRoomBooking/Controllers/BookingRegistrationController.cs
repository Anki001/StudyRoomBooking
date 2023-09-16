using Microsoft.AspNetCore.Mvc;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRegistrationController : ControllerBase
    {
         private readonly IBookingRegistration _bookingRegistration;
         public BookingRegistrationController(IBookingRegistration bookingRegistration)
         {
             _bookingRegistration = bookingRegistration;
         }

         [HttpPost("RoomBooking")]
        public  IActionResult RoomBooking(UserDetails userDetails)
        {
            try
            {
               bool result=  _bookingRegistration.UserDetailsValidation(userDetails);
                if (!result)
                {
                    return BadRequest("UserDetails Are Invalid");
                }
                string roomresult= _bookingRegistration.RoomAvilabilty(userDetails);
                if (roomresult.Equals("no"))
                {
                    return Ok("Room is Unavailable");
                }
               
                int bookingId =  _bookingRegistration.BookingIdByRoomId(roomresult);
                return Ok(bookingId);
              

               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
               
            }
        }

    }

}
