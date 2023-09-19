using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StudyRoomBooking.Models.DomainModels
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roomno { get; set; }
        public string Available { get; set; }
        [JsonIgnore]
        public List<BookingDetails> Bookings { get; set; }



    }
}
