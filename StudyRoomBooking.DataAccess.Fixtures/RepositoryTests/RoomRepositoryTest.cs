using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudyRoomBooking.DataAccess;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.DataAccess.Repository;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Messages.Response;

namespace YourNamespace.Tests.DataAccess.Repository
{
    [TestFixture]
    public class RoomRepositoryTests
    {
        private ApplicationDbContext _context;
        private IStudyRoomRepository _roomRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Use a unique database name
                .Options;

            _context = new ApplicationDbContext(options);
            _roomRepository = new StudyRoomRepository(_context);

            // Seed some test data into the in-memory database
            _context.StudyRooms.AddRange(new List<StudyRoom>
            {
                new StudyRoom { Id = 1, Name = "Room 1", RoomNumber = "A101", IsAvailable = true },
                new StudyRoom { Id = 2, Name = "Room 2", RoomNumber = "A102", IsAvailable = true },
                new StudyRoom { Id = 3, Name = "Room 3", RoomNumber = "A103", IsAvailable = true }
            });
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void GetRooms_ReturnsExpectedResponse()
        {
            // Act
            var result = _roomRepository.GetRooms();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<StudyRoomResponse>(result);
            Assert.IsNotNull(result.Rooms);
            Assert.That(result.Rooms.Count(), Is.EqualTo(3));
        }
    }
}
