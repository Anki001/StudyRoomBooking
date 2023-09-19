using StudyRoomBooking.DataAccess.Repositorys.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repositorys
{
    public class RoomDetailsRepository :IRoomDetailsRepository 
    {
        private readonly ApplicationDbContext _context;

        public RoomDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public async Task<Room> GetRoomDetailsById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return await _context.FindAsync<Room>(id);
        }
    }
}
