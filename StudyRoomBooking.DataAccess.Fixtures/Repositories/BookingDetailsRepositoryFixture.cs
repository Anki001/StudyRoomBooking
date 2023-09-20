using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.DataAccess.Repositories;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Fixtures.Repositories
{
    [TestFixture]
    public class StudyRoomRepositoryTests
    {
        [Test]
        public void GetRooms_ReturnsListOfRooms()
        {
            // Arrange
            var dbContext = CreateMockDbContext(); // Create a mock context for testing
            var repository = new StudyRoomRepository(dbContext);

            // Act
            var result = repository.GetRooms();

            // Assert
            Assert.IsInstanceOf<StudyRoomResponse>(result);
            Assert.IsNotNull(result.Rooms);
            Assert.AreEqual(3, result.Rooms.Count); // Adjust the count based on your mock data
        }

        private ApplicationDbContext CreateMockDbContext()
        {
            // Implement a mock ApplicationDbContext for testing
            var mockDbContext = new ApplicationDbContext();

            // Create a mock list of StudyRooms
            var studyRooms = new List<StudyRoom>
            {
                new StudyRoom { Id = 1, Name = "Room 1" },
                new StudyRoom { Id = 2, Name = "Room 2" },
                new StudyRoom { Id = 3, Name = "Room 3" }
            };

            // Set up the StudyRooms property to return the mock data
            mockDbContext.StudyRooms = studyRooms.AsQueryable();

            return mockDbContext;
        }
    }

    // Define mock classes to represent your data model
    public class StudyRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Add any other properties you need for testing
    }

    // Define a mock ApplicationDbContext class
    public class ApplicationDbContext
    {
        public IQueryable<StudyRoom> StudyRooms { get; set; }
        // Add other DbSet properties as needed for your application
    }
}
