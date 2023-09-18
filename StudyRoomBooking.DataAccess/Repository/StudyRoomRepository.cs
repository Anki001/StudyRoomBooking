using StudyRoomBooking.Models.Messages.Response;
using System.Linq;

namespace StudyRoomBooking.DataAccess.Repository
{

    public  class StudyRoomRepository : IStudyRoomRepository
    {
        private readonly ApplicationDbContext _context;
        
        public StudyRoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        StudyRoomResponse IStudyRoomRepository.GetRooms()
        {
            
            var rooms = _context.StudyRooms.ToList();

            return new StudyRoomResponse
            {
                Rooms = rooms
            };
        }
    }
}
