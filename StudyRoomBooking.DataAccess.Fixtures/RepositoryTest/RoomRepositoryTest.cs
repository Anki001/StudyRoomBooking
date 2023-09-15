using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudyRoomBooking.DataAccess.Repository;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.DataAccess.Fixtures.RepositoryTest
{
    [TestFixture]
    public class RoomRepositoryTests
    {
        private ApplicationDbContext _context;
        private RoomRepository _roomRepository;

        public RoomRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "StudyRoomBooking")
                .Options;
            _context = new ApplicationDbContext(options);
        }

        [SetUp]
        public void Setup()
        {
            SeedSampleData();
            _roomRepository = new RoomRepository(_context);
        }

        [TearDown]
        public void Teardown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task GetRooms_ReturnsRoomsFromDatabase()
        {
            // Act
            var result = await _roomRepository.GetRoomsAsyncData();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Room>>(result);
            Assert.That(result.Count(), Is.EqualTo(3));
        }


        private void SeedSampleData()
        {
            var rooms = new List<Room>
            {
                new Room { Id = 1, Name = "Room 1" ,Roomno = "A101" , Available="yes"},
                new Room { Id = 2, Name = "Room 2" ,Roomno = "A102" , Available="yes"},
                new Room { Id = 3, Name = "Room 3" ,Roomno = "A103" , Available="yes"}
            };

            _context.Rooms.AddRange(rooms);
            _context.SaveChanges();
        }
    }
}
