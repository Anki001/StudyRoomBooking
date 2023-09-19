using Microsoft.AspNetCore.Mvc;
using StudyRoomBooking.Core.Services.Interfaces;

namespace StudyRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingDetails _bookingDetails;
        public BookingsController(IBookingDetails bookingDetails)
        {
            _bookingDetails = bookingDetails;
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingDetailsById(int id)
        {
            try
            {
                if(id <=0)
                {
                    return NotFound($"Given ID {id} is Invalid");
                }
                var booking = await _bookingDetails.GetBookingDetailsById(id);
                if (booking == null)
                {
                    return NotFound($"Booking with ID {id} not found.");
                }
                return Ok(booking);
            }catch (Exception ex)
            {
                return BadRequest($"An error occurred while retrieving booking details:{ex.Message}");
            }

        }
    }
}
