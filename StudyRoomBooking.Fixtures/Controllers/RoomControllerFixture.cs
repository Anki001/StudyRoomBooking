using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.Controllers;
using StudyRoomBooking.Core.FactoryService;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.Exceptions;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.Fixtures.Controllers
{
    [TestFixture]
    public class RoomControllerFixture
    {
        private RoomController _roomController;
        private Mock<IRoomService> _roomServiceMock;
        private Mock<IServiceFactory> _serviceFactoryMock;

        [SetUp]
        public void Setup()
        {
            _roomServiceMock = new Mock<IRoomService>();
            _serviceFactoryMock = new Mock<IServiceFactory>();
            _serviceFactoryMock.Setup(factory => factory.CreateRoomService()).Returns(_roomServiceMock.Object);

            _roomController = new RoomController(_roomServiceMock.Object, _serviceFactoryMock.Object);
        }

        [Test]
        public async Task GetAllRooms_ReturnsOkResult()
        {
            var rooms = new List<Room>
            {
                new Room { Id = 1, Name = "Room 1", Roomno = "A101", Available = "yes" },
                new Room { Id = 2, Name = "Room 2", Roomno = "A102", Available = "yes" },
                new Room { Id = 3, Name = "Room 3", Roomno = "A103", Available = "yes" }
            };
            _roomServiceMock.Setup(service => service.GetRoomsAsync()).ReturnsAsync(rooms);

            IActionResult result = await _roomController.GetAllRooms();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(rooms));
        }

        [Test]
        public async Task GetAllRooms_NoRoomsFound_ReturnsBadRequest()
        {
            IEnumerable<Room> rooms = Enumerable.Empty<Room>();

            _roomServiceMock.Setup(service => service.GetRoomsAsync()).ReturnsAsync(rooms);

            var result = await _roomController.GetAllRooms() as ObjectResult;

            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(404)); // Use 404 for "Not Found"
            Assert.That(result.Value, Is.EqualTo("No rooms found."));
        }

        [Test]
        public async Task GetAllRooms_ExceptionThrown_ReturnsBadRequestWithErrorMessage()
        {
            var errorMessage = "An error occurred.";
            _roomServiceMock.Setup(service => service.GetRoomsAsync()).ThrowsAsync(new StudyRoomBookingException(errorMessage));

            var result = await _roomController.GetAllRooms() as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(400));
            Assert.That(result.Value, Is.EqualTo($"Study Room Booking Error: {errorMessage}"));
        }
    }
}
