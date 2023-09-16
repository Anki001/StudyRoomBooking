using System;
using System.ComponentModel.DataAnnotations;

namespace StudyRoomBooking.Models.Models
{

    public class BookingDetails
    {
        [Key]
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime Date { get; set; }
        public Room RoomDetails { get; set; }
    }
}
