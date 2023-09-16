using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.DataAccess.Repository.Interfaces;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Models;
using System;
using System.Linq;

namespace StudyRoomBooking.DataAccess.Repository
{
    public class BookingRegistrationRepo : IBookingRegistrationRepo
    {

        private readonly ApplicationDbContext _context;
        public BookingRegistrationRepo(ApplicationDbContext dbContext) { 
              _context = dbContext;
        }
        public int BookingIdByRoomId(string roomNo)
        {
            int roomid=Int32.Parse(roomNo);
            BookingDetails bookingDetails = _context.BookingDetails.Include(e=>e.RoomDetails).FirstOrDefault(ele=>ele.RoomDetails.Id.Equals(roomid));
            return bookingDetails.BookingId;
        }

        public void ChangeRoomAvilability(string refRoomNo)
        {
           
            Room room = _context.RoomDetails.FirstOrDefault(e => e.RoomNo.Equals(refRoomNo));

            room.Available = "no";
            _context.RoomDetails.Update(room);
            _context.SaveChanges();
        }

        public Room RoomAvilabity()
        {
            Room roomDetails = _context.RoomDetails.FirstOrDefault(e => e.Available.Equals("yes"));
            return roomDetails;
        }

        public void SaveBookingDetails(BookingDetails bookingDetails)
        {
            _context.BookingDetails.Add(bookingDetails);
            _context.SaveChanges();
        }

        
    }
}
