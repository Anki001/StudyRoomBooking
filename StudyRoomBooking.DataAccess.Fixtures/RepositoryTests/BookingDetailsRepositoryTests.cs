using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudyRoomBooking.DataAccess.Repositories;
using StudyRoomBooking.Models.DomainModels;

namespace StudyRoomBooking.DataAccess.Fixtures.RepositoryTests
{
    [TestFixture]
    public class BookingDetailsRepositoryTests
    {
        private ApplicationDbContext _dbContext;
        private BookingDetailsRepository _repository;

        [SetUp]
        public void Setup()
        {
            // Initialize an in-memory database context
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new ApplicationDbContext(options);

            _repository = new BookingDetailsRepository(_dbContext);

            // Seed some test data
            MockTestData();
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the database context after each test
            _dbContext.Dispose();
        }

        private void MockTestData()
        {
            _dbContext.BookingDetails.AddRange(
                new BookingDetails { BookingId = 1, FirstName = "Siva", LastName = "K", Date = DateTime.Now, StudyRoom = new StudyRoom { Id = 101, Name = "Villa", RoomNumber = "a1223", IsAvailable = true } },
                new BookingDetails { BookingId = 2, FirstName = "John", LastName = "Doe", Date = DateTime.Now, StudyRoom = new StudyRoom { Id = 102, Name = "Apartment", RoomNumber = "b456", IsAvailable = false } }
            );

            _dbContext.SaveChanges();
        }

        [Test]
        public async Task GetBookingDetailsById_ValidId_ReturnsBookingDetailsWithRoom()
        {
            // Arrange
            int bookingId = 1;

            // Act
            var result = await _repository.GetBookingDetailsById(bookingId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(bookingId, result.BookingId);
            Assert.AreEqual("Siva", result.FirstName);
            Assert.IsNotNull(result.StudyRoom); // Ensure StudyRoom property is loaded
            Assert.AreEqual("Villa", result.StudyRoom.Name);
        }

        [Test]
        public async Task GetBookingDetailsById_InvalidId_ReturnsNull()
        {
            // Arrange
            int invalidId = -1;

            // Act
            var result = await _repository.GetBookingDetailsById(invalidId);

            // Assert
            Assert.IsNull(result);
        }
       
    }
}
