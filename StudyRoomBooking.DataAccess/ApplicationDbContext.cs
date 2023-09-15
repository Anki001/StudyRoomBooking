using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.Models;
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
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Code to enter default data
        }
    }
}
