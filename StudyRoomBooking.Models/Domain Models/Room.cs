using System.ComponentModel.DataAnnotations;

namespace StudyRoomBooking.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
          public string Roomno { get; set; }
         public string Available { get; set; } 
    }
}
