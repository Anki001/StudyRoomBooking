using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repositories
{
    public class BookingDetailsRepository :IBookingDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookingDetails> GetBookingDetailsById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return await _context.BookingDetails
                                  .Include(x => x.StudyRoom)
                                  .FirstOrDefaultAsync(b => b.BookingId == id);
        }

    }
}
