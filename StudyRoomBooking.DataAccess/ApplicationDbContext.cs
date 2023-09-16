using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyRoomBooking.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        // Db set properties
        public DbSet<BookingDetails> BookingDetails { get; set; }

        public DbSet<Room> RoomDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Code to enter default data
        }
    }
}
