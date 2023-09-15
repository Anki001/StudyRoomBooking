using System.Collections.Generic;

namespace StudyRoomBooking.Models.Messages.Response
{
    public class RoomResponse
    {
        public IEnumerable<Room> Rooms { get; set; }

    }
}
