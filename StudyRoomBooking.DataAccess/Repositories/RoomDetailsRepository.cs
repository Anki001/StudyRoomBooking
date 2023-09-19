using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repositories
{
    public class RoomDetailsRepository :IRoomDetailsRepository 
    {
        private readonly ApplicationDbContext _context;

        public RoomDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public async Task<StudyRoom> GetRoomDetailsById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return await _context.FindAsync<StudyRoom>(id);
        }
    }
}
