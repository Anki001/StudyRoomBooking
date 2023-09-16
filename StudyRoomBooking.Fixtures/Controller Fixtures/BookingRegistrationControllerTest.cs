using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.Controllers;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess;
using StudyRoomBooking.DataAccess.Repository.Interfaces;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.Fixtures.Controller_Tests
{
    [TestFixture]
    public class BookingRegistrationControllerTest
    {
       

    [TestFixture]
    public class RoomBookingControllerTests
    {
        private Mock<IBookingRegistration> _mockBookingRegistration; 
        private BookingRegistrationController _controller; 

        [SetUp]
        public void SetUp()
        {
            _mockBookingRegistration = new Mock<IBookingRegistration>();
            _controller = new BookingRegistrationController(_mockBookingRegistration.Object); 
        }

        [Test]
        public void RoomBooking_InvalidUserDetails_ReturnsBadRequest()
        {
            _mockBookingRegistration.Setup(x => x.UserDetailsValidation(It.IsAny<UserDetails>())).Returns(false);

                var userDetails = new UserDetails()
                {
                    FirstName = "",
                    LastName = "Pernati",
                    Email = "rakesh@gmail.com",
                    Date = new DateTime(2023 - 09 - 13),
                };
                var result = _controller.RoomBooking(userDetails) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(400));
            Assert.That(result.Value, Is.EqualTo("UserDetails Are Invalid"));
        }

        [Test]
        public void RoomBooking_ValidUserDetailsButRoomUnavailable_ReturnsOkWithRoomUnavailableMessage()
        {
            _mockBookingRegistration.Setup(x => x.UserDetailsValidation(It.IsAny<UserDetails>())).Returns(true);
            _mockBookingRegistration.Setup(x => x.RoomAvilabilty(It.IsAny<UserDetails>())).Returns("no");


                var userDetails = new UserDetails()
                {
                    FirstName = "Rakesh",
                    LastName = "Pernati",
                    Email = "rakesh@gmail.com",
                    Date = new DateTime(2023 - 09 - 13),
                };
                var result = _controller.RoomBooking(userDetails) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo("Room is Unavailable"));
        }

        [Test]
        public void RoomBooking_ValidUserDetailsAndRoomAvailable_ReturnsOkWithBookingId()
        {
            _mockBookingRegistration.Setup(x => x.UserDetailsValidation(It.IsAny<UserDetails>())).Returns(true);
            _mockBookingRegistration.Setup(x => x.RoomAvilabilty(It.IsAny<UserDetails>())).Returns("yes");
            _mockBookingRegistration.Setup(x => x.BookingIdByRoomId(It.IsAny<string>())).Returns(1);
                var userDetails = new UserDetails()
                {
                    FirstName = "Rakesh",
                    LastName = "Pernati",
                    Email = "rakesh@gmail.com",
                    Date = new DateTime(2023 - 09 - 13),
                };
                var result = _controller.RoomBooking(userDetails) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(1));
        }

        [Test]
        public void RoomBooking_ExceptionThrown_ReturnsInternalError()
        {
            _mockBookingRegistration.Setup(x => x.UserDetailsValidation(It.IsAny<UserDetails>())).Throws(new Exception("Error"));

            var result = _controller.RoomBooking(new UserDetails()) as ObjectResult;

            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(500));
        }
    }




}
}
