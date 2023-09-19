using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.Controllers;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Models.DomainModels;

namespace StudyRoomBooking.Fixtures.ControllerTests
{
    [TestFixture]
    public class BookingControllerTests
    {
        private BookingsController _controller;
        private Mock<IBookingDetails> _bookingDetailsMock;
        [SetUp]
        public void Setup()
        {
            // Initialize mock objects
            _bookingDetailsMock = new Mock<IBookingDetails>();
            // Create the controller with mock dependencies
            _controller = new BookingsController(_bookingDetailsMock.Object);
        }

        [Test]
        public async Task GetBookingDetails_ExistingBooking_ReturnsOk()
        {
            // Arrange
            int bookingId = 1;
            var expectedBooking = new BookingDetails
            {
                // Initialize with sample data
                BookingId = bookingId,
                FirstName = "Sivakrishna",
                LastName = "K",
                Email = "siva123@gmail.com",
                Date = DateTime.Now,
                
                StudyRoom = new StudyRoom
                {
                    Id = 1,
                    Name = "Villa",
                    RoomNumber = "123A",
                    IsAvailable = true
                }
            };
            _bookingDetailsMock.Setup(b => b.GetBookingDetailsById(bookingId)).ReturnsAsync(expectedBooking);

            // Act
            var result = await _controller.GetBookingDetailsById(bookingId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedBooking, result.Value);
        }


        [Test]
        public async Task GetBookingDetails_NonExistentBooking_ReturnsNotFound()
        {
            // Arrange
            int bookingId = 2;
            _bookingDetailsMock.Setup(b => b.GetBookingDetailsById(bookingId));

            // Act
            var result = await _controller.GetBookingDetailsById(bookingId) as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual($"Booking with ID {bookingId} not found.", result.Value);
        }

    }
}
