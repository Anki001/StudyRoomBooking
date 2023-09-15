using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.DataAccess.Repository
{

    public  class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        
        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        RoomResponse IRoomRepository.GetRooms()
        {
            
            var rooms = _context.Rooms.ToList();

            return new RoomResponse
            {
                Rooms = rooms
            };
        }
    }
}
