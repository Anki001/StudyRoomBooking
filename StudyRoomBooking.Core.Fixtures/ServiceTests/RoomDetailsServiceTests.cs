using Moq;
using NUnit.Framework;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.Core.Fixtures.ServiceTests
{
    [TestFixture]
    public class RoomDetailsServiceTests
    {
        [Test]
        public async Task GetRoomDetailsById_ValidId_ReturnsRoom()
        {
            // Arrange
            int roomId = 1;
            var mockRepository = new Mock<IRoomDetailsRepository>();
            mockRepository.Setup(repo => repo.GetRoomDetailsById(roomId))
                .ReturnsAsync(new StudyRoom { Id = roomId, Name = "StudyRoom 101",RoomNumber="room123",IsAvailable=true });
            var service = new RoomDetailsService(mockRepository.Object);

            // Act
            var result = await service.GetRoomDetailsById(roomId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(roomId, result.Id);
            Assert.AreEqual("StudyRoom 101", result.Name);
        }

        [Test]
        public async Task GetRoomDetailsById_InvalidId_ReturnsNull()
        {
            // Arrange
            int roomId = -1; // Invalid id
            var mockRepository = new Mock<IRoomDetailsRepository>();
            var service = new RoomDetailsService(mockRepository.Object);

            // Act
            var result = await service.GetRoomDetailsById(roomId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
