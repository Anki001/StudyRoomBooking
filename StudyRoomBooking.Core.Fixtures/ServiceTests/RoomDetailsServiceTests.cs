using Moq;
using NUnit.Framework;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.DataAccess.Repositorys.Interfaces;
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
                .ReturnsAsync(new Room { Id = roomId, Name = "Room 101",Roomno="room123",Available="Yes" });
            var service = new RoomDetailsService(mockRepository.Object);

            // Act
            var result = await service.GetRoomDetailsById(roomId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(roomId, result.Id);
            Assert.AreEqual("Room 101", result.Name);
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
