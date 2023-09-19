using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudyRoomBooking.DataAccess;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.DataAccess.Repositories;
using StudyRoomBooking.Models.Messages.Response;
using StudyRoomBooking.Models.DomainModels;

namespace StudyRoomBooking.DataAccess.Fixtures.RepositoryTests
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
                new StudyRoom { Id = 1, Name = "StudyRoom 1", RoomNumber = "A101", IsAvailable = true },
                new StudyRoom { Id = 2, Name = "StudyRoom 2", RoomNumber = "A102", IsAvailable = true },
                new StudyRoom { Id = 3, Name = "StudyRoom 3", RoomNumber = "A103", IsAvailable = true }
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
            Assert.AreEqual(3, result.Rooms.Count());
        }
    }
}
