using Microsoft.AspNetCore.Mvc;
using StudyRoomBooking.Core.FactoryService;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.Exceptions;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;
        public RoomController( IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            try
            {
                IRoomService roomService = _serviceFactory.CreateRoomService();

                IEnumerable<Room> rooms = await roomService.GetRoomsAsync();

                if (rooms == null || !rooms.Any())
                {

                    return NotFound("No rooms found.");
                }
                return Ok(rooms);
            }
            catch (StudyRoomBookingException ex)
            {
                return BadRequest($"Study Room Booking Error: {ex.Message}");
            }
        }
    }
}
