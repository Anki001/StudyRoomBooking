using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using StudyRoomBooking.Core.FactoryService;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.Exceptions;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;
    


        public RoomController(IServiceFactory serviceFactory)
        {
  
            _serviceFactory = serviceFactory;
        }

        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            try
            {
                var roomsResponse =  _serviceFactory.ProcessService<EmptyRequest, RoomResponse>(EmptyRequest.Instance);

                if (roomsResponse == null )
                {
                    return NotFound("No rooms found.");
                }

                return Ok(roomsResponse);
            }
            catch (StudyRoomBookingException ex)
            {
                return BadRequest($"Study Room Booking Error: {ex.Message}");
            }
        }
    }
}
