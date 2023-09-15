using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.DataAccess.Repository
{

    public  class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        
        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetRoomsAsyncData()
        {
           return await _context.Rooms.ToListAsync();
        }

    }
}
