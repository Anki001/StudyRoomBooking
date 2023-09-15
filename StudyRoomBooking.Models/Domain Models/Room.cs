using System.ComponentModel.DataAnnotations;

namespace StudyRoomBooking.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Room number is required")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Room number can only contain letters, numbers, and spaces")]
        public string Roomno { get; set; }
        [Required(ErrorMessage = "Availability status is required")]
        public string Available { get; set; } 
    }
}
