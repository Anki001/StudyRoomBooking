using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.DataAccess.Repositorys;
using StudyRoomBooking.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Fixtures.RepositoryTests
{
    [TestFixture]
    public class RoomDetailsRepositoryTests
    {
        private RoomDetailsRepository _repository;
        private Mock<ApplicationDbContext> _mockContext;

        [SetUp]
        public void SetUp()
        {
            // Create an instance of the mock DbContext
            _mockContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());

            _repository = new RoomDetailsRepository(_mockContext.Object);
        }
        [Test]
        public async Task GetRoomDetailsById_ValidId_ReturnsRoomDetails()
        {
            // Arrange
            int roomId = 1;
            var roomDetails = new Room { Id = roomId, Name = "Villa",Roomno = "a1223", Available = "Yes" };

            // Setup the mock DbContext to return the roomDetails when FindAsync is called
            _mockContext.Setup(c => c.FindAsync<Room>(roomId)).ReturnsAsync(roomDetails);

            // Act
            var result = await _repository.GetRoomDetailsById(roomId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(roomId, result.Id);
            Assert.AreEqual("Villa", result.Name);
        }

        [Test]
        public async Task GetRoomDetailsById_InvalidId_ReturnsNull()
        {
            // Arrange
            int invalidId = -1;

            // Act
            var result = await _repository.GetRoomDetailsById(invalidId);

            // Assert
            Assert.IsNull(result);
        }
        [TearDown]
        public void TearDown()
        {
            _mockContext.Object.Dispose();
        }
    }
}
