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
    public class BookingDetailsServiceTests
    {
        [Test]
        public async Task GetBookingDetailsById_ValidId_ReturnsBookingDetails()
        {
            // Arrange
            int bookingId = 1;
            var mockRepository = new Mock<IBookingDetailsRepository>();
            var expectedBookingDetails = new BookingDetails
            {
                BookingId = bookingId,
                FirstName = "Siva",
                LastName = "K",
                Date = DateTime.Now,
                Room = new Room // Create a new Room object and initialize it
                {
                    Id = 101,
                    Name = "room name",
                    Roomno = "12A",
                    Available = "Yes"
                }
            };

            mockRepository.Setup(repo => repo.GetBookingDetailsById(bookingId))
                .ReturnsAsync(expectedBookingDetails);

            var service = new BookingDetailsService(mockRepository.Object);

            // Act
            var result = await service.GetBookingDetailsById(bookingId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(bookingId, result.BookingId);
            Assert.AreEqual(101, result.Room.Id);
            Assert.AreEqual("Siva", result.FirstName);
        }


        [Test]
        public async Task GetBookingDetailsById_InvalidId_ReturnsNull()
        {
            // Arrange
            int invalidBookingId = -1; // Invalid id
            var mockRepository = new Mock<IBookingDetailsRepository>();
            var service = new BookingDetailsService(mockRepository.Object);

            // Act
            var result = await service.GetBookingDetailsById(invalidBookingId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
