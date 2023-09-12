using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Code to enter default data
        }
    }
}
