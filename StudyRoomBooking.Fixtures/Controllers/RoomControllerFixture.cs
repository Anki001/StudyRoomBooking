using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.Controllers;
using StudyRoomBooking.Core.FactoryService;
using StudyRoomBooking.Exceptions;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace YourNamespace.Tests.Controllers
{
    [TestFixture]
    public class RoomControllerTests
    {
        private RoomController _roomController;
        private Mock<IServiceFactory> _serviceFactoryMock;

        [SetUp]
        public void Setup()
        {
            _serviceFactoryMock = new Mock<IServiceFactory>();
            _roomController = new RoomController(_serviceFactoryMock.Object);
        }

       

        [Test]
        public async Task GetAllRooms_NoRoomsFound_ReturnsNotFound()
        {
            // Arrange
            _serviceFactoryMock.Setup(factory => factory.ProcessService<EmptyRequest, RoomResponse>(EmptyRequest.Instance))
                .Returns((RoomResponse)null);

            // Act
            var result = await _roomController.GetAllRooms() as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual("No rooms found.", result.Value);
        }

        
    }
}
