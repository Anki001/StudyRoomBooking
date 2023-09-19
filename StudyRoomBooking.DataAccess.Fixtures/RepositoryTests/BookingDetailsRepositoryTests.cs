using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudyRoomBooking.DataAccess.Repositorys;
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
                new BookingDetails { BookingId = 1, FirstName = "Siva", LastName = "K", Date = DateTime.Now, Room = new Room { Id = 101, Name = "Villa", Roomno = "a1223", Available = "Yes" } },
                new BookingDetails { BookingId = 2, FirstName = "John", LastName = "Doe", Date = DateTime.Now, Room = new Room { Id = 102, Name = "Apartment", Roomno = "b456", Available = "No" } }
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
            Assert.IsNotNull(result.Room); // Ensure Room property is loaded
            Assert.AreEqual("Villa", result.Room.Name);
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
