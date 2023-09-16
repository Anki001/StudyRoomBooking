using StudyRoomBooking.Models.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudyRoomBooking.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
       
        public string Name { get; set; }
       
         public string RoomNo { get; set; }
      
        public string Available { get; set; }
        [JsonIgnore]
        public List<BookingDetails> Bookings { get; set; }
    }
}
