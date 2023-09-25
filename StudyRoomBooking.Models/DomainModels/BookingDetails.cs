using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudyRoomBooking.Models.DomainModels
{

    public class BookingDetails
    {
        [Key]
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime Date { get; set; }
       /* [JsonIgnore]*/
        public StudyRoom StudyRoom { get; set; }
    }
}
