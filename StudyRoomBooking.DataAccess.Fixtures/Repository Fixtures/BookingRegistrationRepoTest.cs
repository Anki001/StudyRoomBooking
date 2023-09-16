using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Org.BouncyCastle.Asn1.Mozilla;
using StudyRoomBooking.DataAccess.Repository;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Fixtures.Repository_Fixtures
{
    [TestFixture]
    public class BookingRegistrationRepoTest
    {
        private ApplicationDbContext _context;
        private BookingRegistrationRepo _registrationRepo;
       

      
        [SetUp]
        public void SetUp()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "roombooking")
                .Options;
            _context = new ApplicationDbContext(options);
            _registrationRepo = new BookingRegistrationRepo(_context);
           


        }
        [Test]
        public void BookingIdByRoomNo_ShouldReturnBookingId()
        {


            Room room1 = new Room() { Id = 1, Name = "Superior", RoomNo = "A101", Available = "Yes" };
            Room room2 = new Room() { Id = 2, Name = "Superior", RoomNo = "A102", Available = "Yes" };

            List<BookingDetails> bookingDetailsList = new List<BookingDetails>(){
              new BookingDetails(){BookingId=1,Date=new DateTime(),Email="rakesh@gmail.com",FirstName="rakesh",LastName="pernati",RoomDetails=room1},
              new BookingDetails(){BookingId=2,Date=new DateTime(),Email="siva@gmail.com",FirstName="siva",LastName="kamireddy",RoomDetails = room2}
            };

            _context.BookingDetails.AddRange(bookingDetailsList);

            _context.SaveChanges();

            string roomId = "1";

            int actualBookingId = _registrationRepo.BookingIdByRoomId(roomId);

            

            Assert.That(actualBookingId, Is.EqualTo(1));
        }
        [Test]
        public void RoomAvilability_ShouldReturnRoom()
        {

            Room room1 = new Room() { Id = 1, Name = "Superior", RoomNo = "A101", Available = "yes" };
            Room room2 = new Room() { Id = 2, Name = "Superior", RoomNo = "A102", Available = "yes" };
            _context.RoomDetails.AddRange(room1, room2);
            _context.SaveChanges();

            Room room = _registrationRepo.RoomAvilabity();
            Assert.That(room, Is.Not.Null);
            Assert.IsInstanceOf<Room>(room);
        }
        [Test]
        public void SaveBookingDetails_ShouldReturnCountOne()
        {
           BookingDetails details= new BookingDetails() { BookingId = 1, Date = new DateTime(), Email = "rakesh@gmail.com", FirstName = "rakesh", LastName = "pernati" };
           _registrationRepo.SaveBookingDetails(details);

            Assert.That(1,Is.EqualTo(_context.BookingDetails.Count()));

        }
        [TearDown]
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }


        
    }
}
