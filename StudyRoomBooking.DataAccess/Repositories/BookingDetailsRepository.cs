using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.DataAccess.Repositorys.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repositorys
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
                                  .Include(x => x.Room)
                                  .FirstOrDefaultAsync(b => b.BookingId == id);
        }

    }
}
