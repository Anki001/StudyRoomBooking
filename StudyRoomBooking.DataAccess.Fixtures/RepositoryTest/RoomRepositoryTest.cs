using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudyRoomBooking.DataAccess;
using StudyRoomBooking.DataAccess.Repository;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Messages.Response;

namespace YourNamespace.Tests.DataAccess.Repository
{
    [TestFixture]
    public class RoomRepositoryTests
    {
        private ApplicationDbContext _context;
        private IRoomRepository _roomRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Use a unique database name
                .Options;

            _context = new ApplicationDbContext(options);
            _roomRepository = new RoomRepository(_context);

            // Seed some test data into the in-memory database
            _context.Rooms.AddRange(new List<Room>
            {
                new Room { Id = 1, Name = "Room 1", Roomno = "A101", Available = "yes" },
                new Room { Id = 2, Name = "Room 2", Roomno = "A102", Available = "yes" },
                new Room { Id = 3, Name = "Room 3", Roomno = "A103", Available = "yes" }
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
            Assert.IsInstanceOf<RoomResponse>(result);
            Assert.IsNotNull(result.Rooms);
            Assert.AreEqual(3, result.Rooms.Count());
        }
    }
}
