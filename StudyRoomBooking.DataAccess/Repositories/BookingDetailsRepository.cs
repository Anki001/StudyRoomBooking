﻿using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.Messages.Response;
using System.Linq;

namespace StudyRoomBooking.DataAccess.Repositories
{
    public class BookingDetailsRepository :IBookingDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        BookingDetailsResponse IBookingDetailsRepository.GetBookingDetailsById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var booking = _context.BookingDetails.Include(x=>x.StudyRoom).FirstOrDefault(b=>b.BookingId == id);
            if (booking == null)
            {
                return null;
            }
            return new BookingDetailsResponse
            {
                BookingDetails = booking,
            };
        }


    }
}
