using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.DataAccess;
using StudyRoomBooking.DataAccess.Repository;
using StudyRoomBooking.DataAccess.Repository.Interfaces;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.Core.Fixtures.Service_Fixtures
{
    [TestFixture]
    public class BookingRegistrationServiceTest:IDisposable
    {
        private IBookingRegistrationRepo _registrationRepo;
        private BookingRegistrationService _service;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetUp()
        {
           
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "roombooking")
                .Options;
            _context = new ApplicationDbContext(options);
            _registrationRepo = new BookingRegistrationRepo(_context);
            _service = new BookingRegistrationService(_registrationRepo);
        }
        [Test]
        public void Roomavilabilty_WhenRoomAvailable_ShouldReturnRoomNumber()
        {
            // arrange
            List<Room> roomlist = new List<Room>()
            {
                new Room() { Id = 1,Name="Superior",RoomNo="A101",Available="yes"},
                new Room() { Id = 2,Name="Superior",RoomNo="A102",Available="yes"},
                new Room() { Id = 3,Name="Victoria",RoomNo="A103",Available="yes"},
                new Room() { Id = 4,Name="Superior",RoomNo="A104",Available="yes"},
            };

            var userDetails = new UserDetails()
            {
                FirstName="Rakesh",
                LastName="Pernati",
                Email="rakesh@gmail.com",
                Date= new DateTime(2023 - 09 - 13),
            };
            _context.AddRange(roomlist);
            _context.SaveChanges();

            //act 
           string roomno= _service.RoomAvilabilty(userDetails);
            //assert
            Assert.That(roomno, Is.EqualTo("1"));
        }

        [Test]
        public void Roomavilabilty_WhenRoomNotAvailable_ShouldReturnRoomNumber()
        {
            // arrange
            List<Room> roomlist = new List<Room>()
            {
                new Room() { Id = 1,Name="Superior",RoomNo="A101",Available="no"},
                new Room() { Id = 2,Name="Superior",RoomNo="A102",Available="no"},
                new Room() { Id = 3,Name="Victoria",RoomNo="A103",Available="no"},
                new Room() { Id = 4,Name="Superior",RoomNo="A104",Available="no"},
            };

            var userDetails = new UserDetails()
            {
                FirstName = "Rakesh",
                LastName = "Pernati",
                Email = "rakesh@gmail.com",
                Date = DateTime.Now,
            };
            _context.AddRange(roomlist);
            _context.SaveChanges();

            //act 
            string roomno = _service.RoomAvilabilty(userDetails);
            //assert
            Assert.That(roomno, Is.EqualTo("no"));
        }

       

        [Test]
        public void UserDetailsValidation_Withalldetails_ShouldReturnTrue()
        {
            var userDetails = new UserDetails()
            {
                FirstName = "Rakesh",
                LastName = "Pernati",
                Email = "rakesh@gmail.com",
                Date = DateTime.Now,
            };
            bool result = _service.UserDetailsValidation(userDetails);
            Assert.That(result,Is.True);

        }


        [Test]
        public void UserDetailsValidation_WithNullvalues_ShouldReturnFalse()
        {
            var userDetails = new UserDetails()
            {
                FirstName = "",
                LastName = "",
                Email = "",
                Date = DateTime.Now,
            };
            bool result = _service.UserDetailsValidation(userDetails);
            Assert.That(result, Is.False);

        }


        [Test]
        public void UserDetailsValidation_WithNumbers_ShouldReturnFalse()
        {
            var userDetails = new UserDetails()
            {
                FirstName = "12345",
                LastName = "@42536$",
                Email = "abc",
                Date = new DateTime(),
            };
            bool result = _service.UserDetailsValidation(userDetails);
            Assert.That(result, Is.False);

        }


        [Test]
        public void EmailValidation_WithCorrect_ShouldReturnTrue()
        {
            var email = "rakesh@gmail.com";
            Boolean result=_service.Emailvalidation(email);
            Assert.That(result, Is.True);
        }

        [Test]
        public void EmailValidation_WithInCorrect_ShouldReturnFalse()
        {
            var email = "rakesh@gmail";
            Boolean result = _service.Emailvalidation(email);
            Assert.That(result, Is.False);
        }

        [Test]
        public void NameValidation_WithCorrect_ShouldReturnTrue()
        {
            var name = "rakesh";
            Boolean result = _service.NameValidation(name);
            Assert.That(result, Is.True);
        }

        [Test]
        public void NameValidation_WithInCorrect_ShouldReturnFalse()
        {
            var name = "rakesh123";
            Boolean result = _service.NameValidation(name);
            Assert.That(result, Is.False);
        }

        [Test]
        public void DateValidation_WithInCorrect_ShouldReturnTrue()
        {
            var date = DateTime.Now;
            Boolean result = _service.DateValidation(date);
            Assert.That(result, Is.True);
        }

        [TearDown]
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
