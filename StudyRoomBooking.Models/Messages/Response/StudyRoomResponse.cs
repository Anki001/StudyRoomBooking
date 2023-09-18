using System.Collections.Generic;

namespace StudyRoomBooking.Models.Messages.Response
{
    public class StudyRoomResponse
    {
        public IEnumerable<StudyRoom> Rooms { get; set; }

    }
}
