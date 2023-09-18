using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.DataAccess.Repository
{
    public interface IStudyRoomRepository
    {
       StudyRoomResponse GetRooms();
    }
}
